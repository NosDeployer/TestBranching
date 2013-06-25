using System;
using System.Collections;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.BL.LabourHours.ProjectTime;
using LiquiForce.LFSLive.DA.LabourHours.PayPeriod;
using LiquiForce.LFSLive.DA.LabourHours.Timesheet;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.DA.Resources.Employees;
using LiquiForce.LFSLive.DA.Resources.Companies;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectCostingSheetAddLabourHoursInformation
    /// </summary>
    public class ProjectCostingSheetAddLabourHoursInformation : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectCostingSheetAddLabourHoursInformation()
            : base("LabourHoursInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectCostingSheetAddLabourHoursInformation(DataSet data)
            : base(data, "LabourHoursInformation")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ProjectCostingSheetAddTDS();
        }



        


        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Load
        /// </summary>
        /// <param name="works">works</param>
        /// <param name="projectId">projectId</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="companyId">companyId</param>
        public void Load(ArrayList works, int projectId, DateTime startDate, DateTime endDate, int companyId, string month)
        {
            ProjectGateway projectGateway = new ProjectGateway();
            projectGateway.LoadByProjectId(projectId);

            string projectName = projectGateway.GetName(projectId);

            int clientId = projectGateway.GetClientID(projectId);
            CompaniesGateway companiesGateway = new CompaniesGateway();
            companiesGateway.LoadAllByCompaniesId(clientId, companyId);
            string clientName = companiesGateway.GetName(clientId);

            // General vars
            int overtimeByCountry = 40; //Default for USA Projects
            int refId = GetNewRefId();

            // Foreach of Works (FLL, RA, JL, PR, MH Rehab, MOB, Other)
            foreach (string work_ in works)
            {
                // Load Functions by Work
                ProjectCostingSheetAddFunctionListGateway projectCostingSheetAddFunctionListGateway = new ProjectCostingSheetAddFunctionListGateway();
                projectCostingSheetAddFunctionListGateway.LoadByWork_(work_);

                // Foreach of Functions
                foreach (ProjectCostingSheetAddTDS.FunctionListRow functionListRow in (ProjectCostingSheetAddTDS.FunctionListDataTable)projectCostingSheetAddFunctionListGateway.Table)
                {
                    // Load Employees by ProjectId, StartDate, EndDate, Work
                    ProjectCostingSheetAddEmployeeListGateway projectCostingSheetAddEmployeeListGateway = new ProjectCostingSheetAddEmployeeListGateway(Data);
                    projectCostingSheetAddEmployeeListGateway.LoadByProjectIdStartDateEndDateWorkFunction(projectId, startDate, endDate, work_, functionListRow.Function_, companyId);

                    foreach (ProjectCostingSheetAddTDS.EmployeeListRow employeeListRow in (ProjectCostingSheetAddTDS.EmployeeListDataTable)projectCostingSheetAddEmployeeListGateway.Table)
                    {
                        DateTime newStartDate = new DateTime();
                        newStartDate = startDate;
                        DateTime newEndDate = new DateTime();
                        newEndDate = endDate;

                        //If Project is from Canada we get overtime
                        if (projectGateway.GetCountryID(projectId) == 1)
                        {
                            //Get Category of Employee
                            EmployeeGateway employeeGateway = new EmployeeGateway();
                            employeeGateway.LoadByEmployeeId(employeeListRow.EmployeeID);

                            switch (employeeGateway.GetCategory(employeeListRow.EmployeeID))
                            {
                                case "Special Forces":
                                    overtimeByCountry = 50;
                                    break;

                                case "Field":
                                    overtimeByCountry = 50;
                                    break;

                                case "Field 44":
                                    overtimeByCountry = 44;
                                    break;

                                case "Office/Admin":
                                    overtimeByCountry = 44;
                                    break;

                                case "Mechanic/Manufactoring":
                                    overtimeByCountry = 44;
                                    break;
                            }
                        }

                        ProjectCostingSheetAddEmployeePayPeriodGateway projectCostingSheetAddEmployeePayPeriodGateway = new ProjectCostingSheetAddEmployeePayPeriodGateway(Data);
                        projectCostingSheetAddEmployeePayPeriodGateway.LoadByStartDateEndDateEmployeeId(startDate, endDate, employeeListRow.EmployeeID);

                        if (projectCostingSheetAddEmployeePayPeriodGateway.Table.Rows.Count > 0)
                        {
                            foreach (ProjectCostingSheetAddTDS.EmployeePayPeriodRow employeePayPeriodRow in (ProjectCostingSheetAddTDS.EmployeePayPeriodDataTable)projectCostingSheetAddEmployeePayPeriodGateway.Table)
                            {
                                newEndDate = employeePayPeriodRow.Date_.AddDays(-1);

                                ProjectCostingSheetAddOriginalLabourHourGateway projectCostingSheetAddOriginalLabourHourGateway = new ProjectCostingSheetAddOriginalLabourHourGateway(Data);
                                projectCostingSheetAddOriginalLabourHourGateway.LoadByProjectStartDateEndDateWorkFunctionEmployeeId(projectId, newStartDate, newEndDate, work_, functionListRow.Function_, employeeListRow.EmployeeID);

                                if (projectCostingSheetAddOriginalLabourHourGateway.Table.Rows.Count > 0)
                                {
                                    double lhQuantity = 0;
                                    double overtime = 0;
                                    decimal mealsQuantity = 0;
                                    decimal motelQuantity = 0;
                                    string employeeName = "";
                                    refId++;

                                    foreach (ProjectCostingSheetAddTDS.OriginalLabourHourRow originalRow in (ProjectCostingSheetAddTDS.OriginalLabourHourDataTable)projectCostingSheetAddOriginalLabourHourGateway.Table)
                                    {
                                        employeeName = originalRow.EmployeeName;

                                        // Meal hours quantity
                                        if (!originalRow.IsMealsCountryNull())
                                        {
                                            if (originalRow.MealsAllowance > 0)
                                            {
                                                mealsQuantity++;
                                            }
                                        }

                                        double acumPeriod = GetTotalHoursByEmployeeIdPeriodId(originalRow.EmployeeID, originalRow.Date_, originalRow.ProjectTimeID);

                                        if (acumPeriod > overtimeByCountry)
                                        {
                                            overtime = overtime + originalRow.ProjectTime;
                                        }
                                        else
                                        {
                                            double newAcumPeriod = acumPeriod + originalRow.ProjectTime;

                                            if (newAcumPeriod > overtimeByCountry)
                                            {
                                                overtime = overtime + (newAcumPeriod - overtimeByCountry);
                                                lhQuantity = lhQuantity + (originalRow.ProjectTime - (newAcumPeriod - overtimeByCountry));
                                            }
                                            else
                                            {
                                                lhQuantity = lhQuantity + originalRow.ProjectTime;
                                            }
                                        }
                                    }

                                    if (lhQuantity > 0)
                                    {
                                        ProjectCostingSheetAddTDS.LabourHoursInformationRow newRow = ((ProjectCostingSheetAddTDS.LabourHoursInformationDataTable)Table).NewLabourHoursInformationRow();
                                        GetEmployeeData(newStartDate, newEndDate, employeeListRow.EmployeeID, work_, newRow);// ... Get Costs
                                        newRow.CostingSheetID = 0;
                                        newRow.Work_ = work_;
                                        newRow.EmployeeID = employeeListRow.EmployeeID;
                                        newRow.RefID = refId;
                                        newRow.LHQuantity = lhQuantity;
                                        newRow.MealsQuantity = Convert.ToInt32(mealsQuantity);
                                        if (mealsQuantity > 0) newRow.MealsUnitOfMeasurement = "Day"; else newRow.MealsUnitOfMeasurement = "";
                                        if (motelQuantity > 0) newRow.MotelUnitOfMeasurement = "Day"; else newRow.MotelUnitOfMeasurement = "";
                                        newRow.MealsCostCad = MealsAllowance.GetMealsAllowance(1, true, "Full Day");
                                        newRow.MotelCostCad = 0;
                                        newRow.TotalCostCad = (Convert.ToDecimal(lhQuantity) * decimal.Round(newRow.LHCostCad, 2)) + (mealsQuantity * newRow.MealsCostCad) + (motelQuantity * newRow.MotelCostCad);
                                        newRow.MealsCostUsd = MealsAllowance.GetMealsAllowance(2, true, "Full Day");
                                        newRow.MotelCostUsd = 0;
                                        newRow.TotalCostUsd = (Convert.ToDecimal(lhQuantity) * decimal.Round(newRow.LHCostUsd, 2)) + (mealsQuantity * newRow.MealsCostUsd) + (motelQuantity * newRow.MotelCostUsd);
                                        newRow.Deleted = false;
                                        newRow.InDatabase = false;
                                        newRow.COMPANY_ID = companyId;
                                        newRow.Name = employeeName;
                                        newRow.StartDate = newStartDate;
                                        newRow.EndDate = newEndDate;
                                        newRow.FromDatabase = true;
                                        newRow.Function_ = functionListRow.Function_;
                                        newRow.WorkFunction = work_ + " . " + functionListRow.Function_;
                                        newRow.Month = month;
                                        newRow.ClientName = clientName;
                                        newRow.ProjectName = projectName;
                                        ((ProjectCostingSheetAddTDS.LabourHoursInformationDataTable)Table).AddLabourHoursInformationRow(newRow);
                                    }

                                    if (overtime > 0)
                                    {
                                        refId++;
                                        ProjectCostingSheetAddTDS.LabourHoursInformationRow newRowOt = ((ProjectCostingSheetAddTDS.LabourHoursInformationDataTable)Table).NewLabourHoursInformationRow();
                                        GetEmployeeDataOvertime(newStartDate, newEndDate, employeeListRow.EmployeeID, work_, newRowOt);// ... Get Costs for Overtime
                                        newRowOt.CostingSheetID = projectId;
                                        newRowOt.Work_ = work_;
                                        newRowOt.EmployeeID = employeeListRow.EmployeeID;
                                        newRowOt.RefID = refId;
                                        newRowOt.LHQuantity = overtime;
                                        newRowOt.MealsQuantity = 0;//This is 0 because this row is only for overtime data
                                        mealsQuantity = 0;
                                        motelQuantity = 0;
                                        newRowOt.MealsUnitOfMeasurement = "";
                                        newRowOt.MotelUnitOfMeasurement = "";
                                        newRowOt.MealsCostCad = MealsAllowance.GetMealsAllowance(1, true, "Full Day");
                                        newRowOt.MotelCostCad = 0;
                                        newRowOt.TotalCostCad = (Convert.ToDecimal(overtime) * decimal.Round(newRowOt.LHCostCad, 2));
                                        newRowOt.MealsCostUsd = MealsAllowance.GetMealsAllowance(2, true, "Full Day");
                                        newRowOt.MotelCostUsd = 0;
                                        newRowOt.TotalCostUsd = (Convert.ToDecimal(overtime) * decimal.Round(newRowOt.LHCostUsd, 2));
                                        newRowOt.Deleted = false;
                                        newRowOt.InDatabase = false;
                                        newRowOt.COMPANY_ID = companyId;
                                        newRowOt.Name = employeeName + " - Overtime";
                                        newRowOt.StartDate = newStartDate;
                                        newRowOt.EndDate = newEndDate;
                                        newRowOt.FromDatabase = true;
                                        newRowOt.Function_ = functionListRow.Function_;
                                        newRowOt.WorkFunction = work_ + " . " + functionListRow.Function_;
                                        newRowOt.Month = month;
                                        newRowOt.ClientName = clientName;
                                        newRowOt.ProjectName = projectName;
                                        ((ProjectCostingSheetAddTDS.LabourHoursInformationDataTable)Table).AddLabourHoursInformationRow(newRowOt);
                                    }
                                }

                                newStartDate = newEndDate.AddDays(1);
                            }

                            if (newEndDate <= endDate)
                            {
                                ProjectCostingSheetAddOriginalLabourHourGateway projectCostingSheetAddOriginalLabourHourGateway = new ProjectCostingSheetAddOriginalLabourHourGateway(Data);
                                projectCostingSheetAddOriginalLabourHourGateway.LoadByProjectStartDateEndDateWorkFunctionEmployeeId(projectId, newStartDate, endDate, work_, functionListRow.Function_, employeeListRow.EmployeeID);

                                if (projectCostingSheetAddOriginalLabourHourGateway.Table.Rows.Count > 0)
                                {
                                    double lhQuantity = 0;
                                    double overtime = 0;
                                    decimal mealsQuantity = 0;
                                    decimal motelQuantity = 0;
                                    string employeeName = "";
                                    refId++;

                                    foreach (ProjectCostingSheetAddTDS.OriginalLabourHourRow originalRow in (ProjectCostingSheetAddTDS.OriginalLabourHourDataTable)projectCostingSheetAddOriginalLabourHourGateway.Table)
                                    {
                                        employeeName = originalRow.EmployeeName;

                                        // Meal hours quantity
                                        if (!originalRow.IsMealsCountryNull())
                                        {
                                            if (originalRow.MealsAllowance > 0)
                                            {
                                                mealsQuantity++;
                                            }
                                        }

                                        double acumPeriod = GetTotalHoursByEmployeeIdPeriodId(originalRow.EmployeeID, originalRow.Date_, originalRow.ProjectTimeID);

                                        if (acumPeriod > overtimeByCountry)
                                        {
                                            overtime = overtime + originalRow.ProjectTime;
                                        }
                                        else
                                        {
                                            double newAcumPeriod = acumPeriod + originalRow.ProjectTime;

                                            if (newAcumPeriod > overtimeByCountry)
                                            {
                                                overtime = overtime + (newAcumPeriod - overtimeByCountry);
                                                lhQuantity = lhQuantity + (originalRow.ProjectTime - (newAcumPeriod - overtimeByCountry));
                                            }
                                            else
                                            {
                                                lhQuantity = lhQuantity + originalRow.ProjectTime;
                                            }
                                        }
                                    }

                                    if (lhQuantity > 0)
                                    {
                                        ProjectCostingSheetAddTDS.LabourHoursInformationRow newRow = ((ProjectCostingSheetAddTDS.LabourHoursInformationDataTable)Table).NewLabourHoursInformationRow();
                                        GetEmployeeData(newStartDate, endDate, employeeListRow.EmployeeID, work_, newRow);
                                        newRow.CostingSheetID = 0;
                                        newRow.Work_ = work_;
                                        newRow.EmployeeID = employeeListRow.EmployeeID;
                                        newRow.RefID = refId;
                                        newRow.LHQuantity = lhQuantity;
                                        newRow.MealsQuantity = Convert.ToInt32(mealsQuantity);
                                        if (mealsQuantity > 0) newRow.MealsUnitOfMeasurement = "Day"; else newRow.MealsUnitOfMeasurement = "";
                                        if (motelQuantity > 0) newRow.MotelUnitOfMeasurement = "Day"; else newRow.MotelUnitOfMeasurement = "";
                                        newRow.MealsCostCad = MealsAllowance.GetMealsAllowance(1, true, "Full Day");
                                        newRow.MotelCostCad = 0;
                                        newRow.TotalCostCad = (Convert.ToDecimal(lhQuantity) * decimal.Round(newRow.LHCostCad, 2)) + (mealsQuantity * newRow.MealsCostCad) + (motelQuantity * newRow.MotelCostCad);
                                        newRow.MealsCostUsd = MealsAllowance.GetMealsAllowance(2, true, "Full Day");
                                        newRow.MotelCostUsd = 0;
                                        newRow.TotalCostUsd = (Convert.ToDecimal(lhQuantity) * decimal.Round(newRow.LHCostUsd, 2)) + (mealsQuantity * newRow.MealsCostUsd) + (motelQuantity * newRow.MotelCostUsd);
                                        newRow.Deleted = false;
                                        newRow.InDatabase = false;
                                        newRow.COMPANY_ID = companyId;
                                        newRow.Name = employeeName;
                                        newRow.StartDate = newStartDate;
                                        newRow.EndDate = endDate;
                                        newRow.FromDatabase = true;
                                        newRow.Function_ = functionListRow.Function_;
                                        newRow.WorkFunction = work_ + " . " + functionListRow.Function_;
                                        newRow.Month = month;
                                        newRow.ClientName = clientName;
                                        newRow.ProjectName = projectName;
                                        ((ProjectCostingSheetAddTDS.LabourHoursInformationDataTable)Table).AddLabourHoursInformationRow(newRow);
                                    }

                                    if (overtime > 0)
                                    {
                                        refId++;
                                        ProjectCostingSheetAddTDS.LabourHoursInformationRow newRowOt = ((ProjectCostingSheetAddTDS.LabourHoursInformationDataTable)Table).NewLabourHoursInformationRow();
                                        GetEmployeeDataOvertime(newStartDate, newEndDate, employeeListRow.EmployeeID, work_, newRowOt);// ... Get Costs for Overtime
                                        newRowOt.CostingSheetID = 0;
                                        newRowOt.Work_ = work_;
                                        newRowOt.EmployeeID = employeeListRow.EmployeeID;
                                        newRowOt.RefID = refId;
                                        newRowOt.LHQuantity = overtime;
                                        newRowOt.MealsQuantity = 0;//This is 0 because this row is only for overtime data
                                        mealsQuantity = 0;
                                        motelQuantity = 0;
                                        newRowOt.MealsUnitOfMeasurement = "";
                                        newRowOt.MotelUnitOfMeasurement = "";
                                        newRowOt.MealsCostCad = MealsAllowance.GetMealsAllowance(1, true, "Full Day");
                                        newRowOt.MotelCostCad = 0;
                                        newRowOt.TotalCostCad = (Convert.ToDecimal(overtime) * decimal.Round(newRowOt.LHCostCad, 2));
                                        newRowOt.MealsCostUsd = MealsAllowance.GetMealsAllowance(2, true, "Full Day");
                                        newRowOt.MotelCostUsd = 0;
                                        newRowOt.TotalCostUsd = (Convert.ToDecimal(overtime) * decimal.Round(newRowOt.LHCostUsd, 2));
                                        newRowOt.Deleted = false;
                                        newRowOt.InDatabase = false;
                                        newRowOt.COMPANY_ID = companyId;
                                        newRowOt.Name = employeeName + " - Overtime";
                                        newRowOt.StartDate = newStartDate;
                                        newRowOt.EndDate = endDate;
                                        newRowOt.FromDatabase = true;
                                        newRowOt.Function_ = functionListRow.Function_;
                                        newRowOt.WorkFunction = work_ + " . " + functionListRow.Function_;
                                        newRowOt.Month = month;
                                        newRowOt.ClientName = clientName;
                                        newRowOt.ProjectName = projectName;
                                        ((ProjectCostingSheetAddTDS.LabourHoursInformationDataTable)Table).AddLabourHoursInformationRow(newRowOt);
                                    }
                                }
                            }
                        }
                        else
                        {
                            ProjectCostingSheetAddOriginalLabourHourGateway projectCostingSheetAddOriginalLabourHourGateway = new ProjectCostingSheetAddOriginalLabourHourGateway(Data);
                            projectCostingSheetAddOriginalLabourHourGateway.LoadByProjectStartDateEndDateWorkFunctionEmployeeId(projectId, startDate, endDate, work_, functionListRow.Function_, employeeListRow.EmployeeID);

                            if (projectCostingSheetAddOriginalLabourHourGateway.Table.Rows.Count > 0)
                            {
                                double lhQuantity = 0;
                                double overtime = 0;
                                decimal mealsQuantity = 0;
                                decimal motelQuantity = 0;
                                string employeeName = "";
                                refId++;

                                foreach (ProjectCostingSheetAddTDS.OriginalLabourHourRow originalRow in (ProjectCostingSheetAddTDS.OriginalLabourHourDataTable)projectCostingSheetAddOriginalLabourHourGateway.Table)
                                {
                                    employeeName = originalRow.EmployeeName;

                                    // Meal hours quantity
                                    if (!originalRow.IsMealsCountryNull())
                                    {
                                        if (originalRow.MealsAllowance > 0)
                                        {
                                            mealsQuantity++;
                                        }
                                    }

                                    double acumPeriod = GetTotalHoursByEmployeeIdPeriodId(originalRow.EmployeeID, originalRow.Date_, originalRow.ProjectTimeID);

                                    if (acumPeriod > overtimeByCountry)
                                    {
                                        overtime = overtime + originalRow.ProjectTime;
                                    }
                                    else
                                    {
                                        double newAcumPeriod = acumPeriod + originalRow.ProjectTime;

                                        if (newAcumPeriod > overtimeByCountry)
                                        {
                                            overtime = overtime + (newAcumPeriod - overtimeByCountry);
                                            lhQuantity = lhQuantity + (originalRow.ProjectTime - (newAcumPeriod - overtimeByCountry));
                                        }
                                        else
                                        {
                                            lhQuantity = lhQuantity + originalRow.ProjectTime;
                                        }
                                    }
                                }

                                if (lhQuantity > 0)
                                {
                                    ProjectCostingSheetAddTDS.LabourHoursInformationRow newRow = ((ProjectCostingSheetAddTDS.LabourHoursInformationDataTable)Table).NewLabourHoursInformationRow();
                                    GetEmployeeData(startDate, endDate, employeeListRow.EmployeeID, work_, newRow);
                                    newRow.CostingSheetID = 0;
                                    newRow.Work_ = work_;
                                    newRow.EmployeeID = employeeListRow.EmployeeID;
                                    newRow.RefID = refId;
                                    newRow.LHQuantity = lhQuantity;
                                    newRow.MealsQuantity = Convert.ToInt32(mealsQuantity);
                                    if (mealsQuantity > 0) newRow.MealsUnitOfMeasurement = "Day"; else newRow.MealsUnitOfMeasurement = "";
                                    if (motelQuantity > 0) newRow.MotelUnitOfMeasurement = "Day"; else newRow.MotelUnitOfMeasurement = "";
                                    newRow.MealsCostCad = MealsAllowance.GetMealsAllowance(1, true, "Full Day");
                                    newRow.MotelCostCad = 0;
                                    newRow.TotalCostCad = (Convert.ToDecimal(lhQuantity) * decimal.Round(newRow.LHCostCad, 2)) + (mealsQuantity * newRow.MealsCostCad) + (motelQuantity * newRow.MotelCostCad);
                                    newRow.MealsCostUsd = MealsAllowance.GetMealsAllowance(2, true, "Full Day");
                                    newRow.MotelCostUsd = 0;
                                    newRow.TotalCostUsd = (Convert.ToDecimal(lhQuantity) * decimal.Round(newRow.LHCostUsd, 2)) + (mealsQuantity * newRow.MealsCostUsd) + (motelQuantity * newRow.MotelCostUsd);
                                    newRow.Deleted = false;
                                    newRow.InDatabase = false;
                                    newRow.COMPANY_ID = companyId;
                                    newRow.Name = employeeName;
                                    newRow.StartDate = startDate;
                                    newRow.EndDate = endDate;
                                    newRow.FromDatabase = true;
                                    newRow.Function_ = functionListRow.Function_;
                                    newRow.WorkFunction = work_ + " . " + functionListRow.Function_;
                                    newRow.Month = month;
                                    newRow.ClientName = clientName;
                                    newRow.ProjectName = projectName;
                                    ((ProjectCostingSheetAddTDS.LabourHoursInformationDataTable)Table).AddLabourHoursInformationRow(newRow);
                                }

                                if (overtime > 0)
                                {
                                    refId++;
                                    ProjectCostingSheetAddTDS.LabourHoursInformationRow newRowOt = ((ProjectCostingSheetAddTDS.LabourHoursInformationDataTable)Table).NewLabourHoursInformationRow();
                                    GetEmployeeDataOvertime(newStartDate, newEndDate, employeeListRow.EmployeeID, work_, newRowOt);// ... Get Costs for Overtime
                                    newRowOt.CostingSheetID = 0;
                                    newRowOt.Work_ = work_;
                                    newRowOt.EmployeeID = employeeListRow.EmployeeID;
                                    newRowOt.RefID = refId;
                                    newRowOt.LHQuantity = overtime;
                                    newRowOt.MealsQuantity = 0;//This is 0 because this row is only for overtime data
                                    mealsQuantity = 0;
                                    motelQuantity = 0;
                                    newRowOt.MealsUnitOfMeasurement = "";
                                    newRowOt.MotelUnitOfMeasurement = "";
                                    newRowOt.MealsCostCad = MealsAllowance.GetMealsAllowance(1, true, "Full Day");
                                    newRowOt.MotelCostCad = 0;
                                    newRowOt.TotalCostCad = (Convert.ToDecimal(overtime) * decimal.Round(newRowOt.LHCostCad, 2));
                                    newRowOt.MealsCostUsd = MealsAllowance.GetMealsAllowance(2, true, "Full Day");
                                    newRowOt.MotelCostUsd = 0;
                                    newRowOt.TotalCostUsd = (Convert.ToDecimal(overtime) * decimal.Round(newRowOt.LHCostUsd, 2));
                                    newRowOt.Deleted = false;
                                    newRowOt.InDatabase = false;
                                    newRowOt.COMPANY_ID = companyId;
                                    newRowOt.Name = employeeName + " - Overtime";
                                    newRowOt.StartDate = startDate;
                                    newRowOt.EndDate = endDate;
                                    newRowOt.FromDatabase = true;
                                    newRowOt.Function_ = functionListRow.Function_;
                                    newRowOt.WorkFunction = work_ + " . " + functionListRow.Function_;
                                    newRowOt.Month = month;
                                    newRowOt.ClientName = clientName;
                                    newRowOt.ProjectName = projectName;
                                    ((ProjectCostingSheetAddTDS.LabourHoursInformationDataTable)Table).AddLabourHoursInformationRow(newRowOt);
                                }
                            }
                        }
                    }
                }
            }
        }



        /// <summary>
        /// LoadFairWageProject
        /// </summary>
        /// <param name="works">works</param>
        /// <param name="jobClassType">jobClassType</param>
        /// <param name="projectId">projectId</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="companyId">companyId</param>
        public void LoadFairWageProject(ArrayList works, ArrayList jobClassType, int projectId, DateTime startDate, DateTime endDate, int companyId, string month)
        {
            ProjectGateway projectGateway = new ProjectGateway();
            projectGateway.LoadByProjectId(projectId);

            string projectName = projectGateway.GetName(projectId);

            int clientId = projectGateway.GetClientID(projectId);
            CompaniesGateway companiesGateway = new CompaniesGateway();
            companiesGateway.LoadAllByCompaniesId(clientId, companyId);
            string clientName = companiesGateway.GetName(clientId);

            // General vars
            int overtimeByCountry = 40; //Default for USA Projects
            int refId = GetNewRefId();

            int countryId = 1; //Default Canada
            if (projectGateway.GetCountryID(projectId) == 2)
            {
                countryId = 2;//USA
            }

            // Foreach of Works (FLL, RA, JL, PR, MH Rehab, MOB, Other)
            foreach (string work_ in works)
            {
                // Load Functions by Work
                ProjectCostingSheetAddFunctionListGateway projectCostingSheetAddFunctionListGateway = new ProjectCostingSheetAddFunctionListGateway();
                projectCostingSheetAddFunctionListGateway.LoadByWork_(work_);

                // Foreach of Functions
                foreach (ProjectCostingSheetAddTDS.FunctionListRow functionListRow in (ProjectCostingSheetAddTDS.FunctionListDataTable)projectCostingSheetAddFunctionListGateway.Table)
                {
                    // Foreach of Job Class (Laborer Group 2, Laborer Group 6, Operator Group 1, Operator Group 2, Regular Rate)
                    foreach (string jobClassType_ in jobClassType)
                    {
                        // Get Fringe Rate by Job Class
                        decimal fringeRate = projectGateway.GetOperatorGroupFringeRate(projectId, jobClassType_);

                        // Load Employees with Timesheet by ProjectId, StartDate, EndDate, Work, Function and Job Class
                        ProjectCostingSheetAddEmployeeListGateway projectCostingSheetAddEmployeeListGateway = new ProjectCostingSheetAddEmployeeListGateway(Data);
                        projectCostingSheetAddEmployeeListGateway.LoadByProjectIdStartDateEndDateWorkFunctionJobClass(projectId, startDate, endDate, work_, functionListRow.Function_, jobClassType_, companyId);

                        // Foreach of Employees with Timesheet
                        foreach (ProjectCostingSheetAddTDS.EmployeeListRow employeeListRow in (ProjectCostingSheetAddTDS.EmployeeListDataTable)projectCostingSheetAddEmployeeListGateway.Table)
                        {                            
                            DateTime newStartDate = new DateTime();
                            newStartDate = startDate;
                            
                            DateTime newEndDate = new DateTime();
                            newEndDate = endDate;

                            // If Project is from Canada we get overtime
                            if (projectGateway.GetCountryID(projectId) == 1)
                            {
                                // Get Category of Employee
                                EmployeeGateway employeeGateway = new EmployeeGateway();
                                employeeGateway.LoadByEmployeeId(employeeListRow.EmployeeID);

                                switch (employeeGateway.GetCategory(employeeListRow.EmployeeID))
                                {
                                    case "Special Forces":
                                        overtimeByCountry = 50;
                                        break;

                                    case "Field":
                                        overtimeByCountry = 50;
                                        break;

                                    case "Field 44":
                                        overtimeByCountry = 44;
                                        break;

                                    case "Office/Admin":
                                        overtimeByCountry = 44;
                                        break;

                                    case "Mechanic/Manufactoring":
                                        overtimeByCountry = 44;
                                        break;
                                }
                            }

                            // Load Cost Pay Periods of Employee by StartDate and EndDate
                            ProjectCostingSheetAddEmployeePayPeriodGateway projectCostingSheetAddEmployeePayPeriodGateway = new ProjectCostingSheetAddEmployeePayPeriodGateway(Data);
                            projectCostingSheetAddEmployeePayPeriodGateway.LoadByStartDateEndDateEmployeeId(startDate, endDate, employeeListRow.EmployeeID);

                            // If Employee has Cost Pay Periods between StartDate and EndDate
                            if (projectCostingSheetAddEmployeePayPeriodGateway.Table.Rows.Count > 0)
                            {
                                // Foreach of Cost Pay Periods
                                foreach (ProjectCostingSheetAddTDS.EmployeePayPeriodRow employeePayPeriodRow in (ProjectCostingSheetAddTDS.EmployeePayPeriodDataTable)projectCostingSheetAddEmployeePayPeriodGateway.Table)
                                {
                                    // Update newEndDate with Date of Cost Pay Period
                                    newEndDate = employeePayPeriodRow.Date_.AddDays(-1);

                                    // Load Project Times of Employee by ProjectId, StartDate, EndDate, Work, Function, Job Class
                                    ProjectCostingSheetAddOriginalLabourHourGateway projectCostingSheetAddOriginalLabourHourGateway = new ProjectCostingSheetAddOriginalLabourHourGateway(Data);
                                    projectCostingSheetAddOriginalLabourHourGateway.LoadByProjectStartDateEndDateWorkFunctionJobClassTypeEmployeeId(projectId, newStartDate, newEndDate, work_, functionListRow.Function_, jobClassType_, employeeListRow.EmployeeID);

                                    // If Employee has ProjectTime
                                    if (projectCostingSheetAddOriginalLabourHourGateway.Table.Rows.Count > 0)
                                    {
                                        double lhQuantity = 0;
                                        double overtime = 0;
                                        decimal mealsQuantity = 0;
                                        decimal motelQuantity = 0;
                                        string employeeName = "";
                                        refId++;

                                        // Foreach original ProjectTime
                                        foreach (ProjectCostingSheetAddTDS.OriginalLabourHourRow originalRow in (ProjectCostingSheetAddTDS.OriginalLabourHourDataTable)projectCostingSheetAddOriginalLabourHourGateway.Table)
                                        {
                                            employeeName = originalRow.EmployeeName;

                                            // Meal hours quantity
                                            if (!originalRow.IsMealsCountryNull())
                                            {
                                                if (originalRow.MealsAllowance > 0)
                                                {
                                                    mealsQuantity++;
                                                }
                                            }

                                            double acumPeriod = GetTotalHoursByEmployeeIdPeriodId(originalRow.EmployeeID, originalRow.Date_, originalRow.ProjectTimeID);

                                            if (acumPeriod > overtimeByCountry)
                                            {
                                                overtime = overtime + originalRow.ProjectTime;
                                            }
                                            else
                                            {
                                                double newAcumPeriod = acumPeriod + originalRow.ProjectTime;

                                                if (newAcumPeriod > overtimeByCountry)
                                                {
                                                    overtime = overtime + (newAcumPeriod - overtimeByCountry);
                                                    lhQuantity = lhQuantity + (originalRow.ProjectTime - (newAcumPeriod - overtimeByCountry));
                                                }
                                                else
                                                {
                                                    lhQuantity = lhQuantity + originalRow.ProjectTime;
                                                }
                                            }
                                        }

                                        if (lhQuantity > 0)
                                        {
                                            ProjectCostingSheetAddTDS.LabourHoursInformationRow newRow = ((ProjectCostingSheetAddTDS.LabourHoursInformationDataTable)Table).NewLabourHoursInformationRow();
                                            if (projectGateway.IsFairWageProjectWorkFunction(projectId, work_, functionListRow.Function_))
                                            {
                                                if (jobClassType_ != "Regular Rate")
                                                {
                                                    decimal fairWageRate = projectGateway.GetOperatorGroupRate(projectId, jobClassType_);

                                                    GetEmployeeDataFairWage(newStartDate, newEndDate, employeeListRow.EmployeeID, work_, newRow, countryId, fringeRate, fairWageRate);
                                                }
                                                else
                                                {
                                                    GetEmployeeData(newStartDate, newEndDate, employeeListRow.EmployeeID, work_, newRow); // Is same to non fair wage project
                                                }
                                            }
                                            else
                                            {
                                                GetEmployeeData(newStartDate, newEndDate, employeeListRow.EmployeeID, work_, newRow); // Is same to non fair wage project
                                            }

                                            newRow.CostingSheetID = 0;
                                            newRow.Work_ = work_;
                                            newRow.EmployeeID = employeeListRow.EmployeeID;
                                            newRow.RefID = refId;
                                            newRow.LHQuantity = lhQuantity;
                                            newRow.MealsQuantity = Convert.ToInt32(mealsQuantity);
                                            if (mealsQuantity > 0) newRow.MealsUnitOfMeasurement = "Day"; else newRow.MealsUnitOfMeasurement = "";
                                            if (motelQuantity > 0) newRow.MotelUnitOfMeasurement = "Day"; else newRow.MotelUnitOfMeasurement = "";
                                            newRow.MealsCostCad = MealsAllowance.GetMealsAllowance(1, true, "Full Day");
                                            newRow.MotelCostCad = 0;
                                            newRow.TotalCostCad = (Convert.ToDecimal(lhQuantity) * decimal.Round(newRow.LHCostCad,2)) + (mealsQuantity * newRow.MealsCostCad) + (motelQuantity * newRow.MotelCostCad);
                                            newRow.MealsCostUsd = MealsAllowance.GetMealsAllowance(2, true, "Full Day");
                                            newRow.MotelCostUsd = 0;
                                            newRow.TotalCostUsd = (Convert.ToDecimal(lhQuantity) * decimal.Round(newRow.LHCostUsd,2)) + (mealsQuantity * newRow.MealsCostUsd) + (motelQuantity * newRow.MotelCostUsd);
                                            newRow.Deleted = false;
                                            newRow.InDatabase = false;
                                            newRow.COMPANY_ID = companyId;
                                            newRow.Name = employeeName;
                                            newRow.StartDate = newStartDate;
                                            newRow.EndDate = newEndDate;
                                            newRow.FromDatabase = true;
                                            newRow.Function_ = functionListRow.Function_;
                                            newRow.WorkFunction = work_ + " . " + functionListRow.Function_;
                                            newRow.Month = month;
                                            newRow.ClientName = clientName;
                                            newRow.ProjectName = projectName;
                                            ((ProjectCostingSheetAddTDS.LabourHoursInformationDataTable)Table).AddLabourHoursInformationRow(newRow);
                                        }

                                        if (overtime > 0)
                                        {
                                            refId++;
                                            ProjectCostingSheetAddTDS.LabourHoursInformationRow newRowOt = ((ProjectCostingSheetAddTDS.LabourHoursInformationDataTable)Table).NewLabourHoursInformationRow();
                                            if (projectGateway.IsFairWageProjectWorkFunction(projectId, work_, functionListRow.Function_))
                                            {
                                                if (jobClassType_ != "Regular Rate")
                                                {
                                                    decimal fairWageRate = projectGateway.GetOperatorGroupRate(projectId, jobClassType_);

                                                    GetEmployeeDataFairWageOvertime(newStartDate, newEndDate, employeeListRow.EmployeeID, work_, newRowOt, countryId, fringeRate, fairWageRate);
                                                }
                                                else
                                                {
                                                    GetEmployeeDataOvertime(newStartDate, newEndDate, employeeListRow.EmployeeID, work_, newRowOt); // Is same to non fair wage project
                                                }
                                            }
                                            else
                                            {
                                                GetEmployeeDataOvertime(newStartDate, newEndDate, employeeListRow.EmployeeID, work_, newRowOt); // Is same to non fair wage project
                                            }

                                            newRowOt.CostingSheetID = 0;
                                            newRowOt.Work_ = work_;
                                            newRowOt.EmployeeID = employeeListRow.EmployeeID;
                                            newRowOt.RefID = refId;
                                            newRowOt.LHQuantity = overtime;
                                            newRowOt.MealsQuantity = 0;
                                            newRowOt.MealsUnitOfMeasurement = "";
                                            newRowOt.MotelUnitOfMeasurement = "";
                                            newRowOt.MealsCostCad = MealsAllowance.GetMealsAllowance(1, true, "Full Day");
                                            newRowOt.MotelCostCad = 0;
                                            newRowOt.TotalCostCad = (Convert.ToDecimal(overtime) * decimal.Round(newRowOt.LHCostCad,2));
                                            newRowOt.MealsCostUsd = MealsAllowance.GetMealsAllowance(2, true, "Full Day");
                                            newRowOt.MotelCostUsd = 0;
                                            newRowOt.TotalCostUsd = (Convert.ToDecimal(overtime) * decimal.Round(newRowOt.LHCostUsd,2));
                                            newRowOt.Deleted = false;
                                            newRowOt.InDatabase = false;
                                            newRowOt.COMPANY_ID = companyId;
                                            newRowOt.Name = employeeName + " - Overtime";
                                            newRowOt.StartDate = newStartDate;
                                            newRowOt.EndDate = newEndDate;
                                            newRowOt.FromDatabase = true;
                                            newRowOt.Function_ = functionListRow.Function_;
                                            newRowOt.WorkFunction = work_ + " . " + functionListRow.Function_;
                                            newRowOt.Month = month;
                                            newRowOt.ClientName = clientName;
                                            newRowOt.ProjectName = projectName;
                                            ((ProjectCostingSheetAddTDS.LabourHoursInformationDataTable)Table).AddLabourHoursInformationRow(newRowOt);
                                        }
                                    }

                                    newStartDate = newEndDate.AddDays(1);
                                }

                                if (newEndDate <= endDate)
                                {
                                    ProjectCostingSheetAddOriginalLabourHourGateway projectCostingSheetAddOriginalLabourHourGateway = new ProjectCostingSheetAddOriginalLabourHourGateway(Data);
                                    projectCostingSheetAddOriginalLabourHourGateway.LoadByProjectStartDateEndDateWorkFunctionJobClassTypeEmployeeId(projectId, newStartDate, endDate, work_, functionListRow.Function_, jobClassType_, employeeListRow.EmployeeID);

                                    if (projectCostingSheetAddOriginalLabourHourGateway.Table.Rows.Count > 0)
                                    {
                                        double lhQuantity = 0;
                                        double overtime = 0;
                                        decimal mealsQuantity = 0;
                                        decimal motelQuantity = 0;
                                        string employeeName = "";
                                        refId++;

                                        foreach (ProjectCostingSheetAddTDS.OriginalLabourHourRow originalRow in (ProjectCostingSheetAddTDS.OriginalLabourHourDataTable)projectCostingSheetAddOriginalLabourHourGateway.Table)
                                        {
                                            employeeName = originalRow.EmployeeName;

                                            // Meal hours quantity
                                            if (!originalRow.IsMealsCountryNull())
                                            {
                                                if (originalRow.MealsAllowance > 0)
                                                {
                                                    mealsQuantity++;
                                                }
                                            }

                                            double acumPeriod = GetTotalHoursByEmployeeIdPeriodId(originalRow.EmployeeID, originalRow.Date_, originalRow.ProjectTimeID);

                                            if (acumPeriod > overtimeByCountry)
                                            {
                                                overtime = overtime + originalRow.ProjectTime;
                                            }
                                            else
                                            {
                                                double newAcumPeriod = acumPeriod + originalRow.ProjectTime;

                                                if (newAcumPeriod > overtimeByCountry)
                                                {
                                                    overtime = overtime + (newAcumPeriod - overtimeByCountry);
                                                    lhQuantity = lhQuantity + (originalRow.ProjectTime - (newAcumPeriod - overtimeByCountry));
                                                }
                                                else
                                                {
                                                    lhQuantity = lhQuantity + originalRow.ProjectTime;
                                                }
                                            }
                                        }

                                        if (lhQuantity > 0)
                                        {
                                            ProjectCostingSheetAddTDS.LabourHoursInformationRow newRow = ((ProjectCostingSheetAddTDS.LabourHoursInformationDataTable)Table).NewLabourHoursInformationRow();
                                            if (projectGateway.IsFairWageProjectWorkFunction(projectId, work_, functionListRow.Function_))
                                            {
                                                if (jobClassType_ != "Regular Rate")
                                                {
                                                    decimal fairWageRate = projectGateway.GetOperatorGroupRate(projectId, jobClassType_);
                                                                                                        
                                                    GetEmployeeDataFairWage(newStartDate, endDate, employeeListRow.EmployeeID, work_, newRow, countryId, fringeRate, fairWageRate);
                                                }
                                                else
                                                {
                                                    GetEmployeeData(newStartDate, endDate, employeeListRow.EmployeeID, work_, newRow);
                                                }
                                            }
                                            else
                                            {
                                                GetEmployeeData(newStartDate, endDate, employeeListRow.EmployeeID, work_, newRow);
                                            }
                                            newRow.CostingSheetID = 0;
                                            newRow.Work_ = work_;
                                            newRow.EmployeeID = employeeListRow.EmployeeID;
                                            newRow.RefID = refId;
                                            newRow.LHQuantity = lhQuantity;
                                            newRow.MealsQuantity = Convert.ToInt32(mealsQuantity);
                                            if (mealsQuantity > 0) newRow.MealsUnitOfMeasurement = "Day"; else newRow.MealsUnitOfMeasurement = "";
                                            if (motelQuantity > 0) newRow.MotelUnitOfMeasurement = "Day"; else newRow.MotelUnitOfMeasurement = "";
                                            newRow.MealsCostCad = MealsAllowance.GetMealsAllowance(1, true, "Full Day");
                                            newRow.MotelCostCad = 0;
                                            newRow.TotalCostCad = (Convert.ToDecimal(lhQuantity) * decimal.Round(newRow.LHCostCad,2)) + (mealsQuantity * newRow.MealsCostCad) + (motelQuantity * newRow.MotelCostCad);
                                            newRow.MealsCostUsd = MealsAllowance.GetMealsAllowance(2, true, "Full Day");
                                            newRow.MotelCostUsd = 0;
                                            newRow.TotalCostUsd = (Convert.ToDecimal(lhQuantity) * decimal.Round(newRow.LHCostUsd,2)) + (mealsQuantity * newRow.MealsCostUsd) + (motelQuantity * newRow.MotelCostUsd);
                                            newRow.Deleted = false;
                                            newRow.InDatabase = false;
                                            newRow.COMPANY_ID = companyId;
                                            newRow.Name = employeeName;
                                            newRow.StartDate = newStartDate;
                                            newRow.EndDate = endDate;
                                            newRow.FromDatabase = true;
                                            newRow.Function_ = functionListRow.Function_;
                                            newRow.WorkFunction = work_ + " . " + functionListRow.Function_;
                                            newRow.Month = month;
                                            newRow.ClientName = clientName;
                                            newRow.ProjectName = projectName;
                                            ((ProjectCostingSheetAddTDS.LabourHoursInformationDataTable)Table).AddLabourHoursInformationRow(newRow);
                                        }

                                        if (overtime > 0)
                                        {
                                            refId++;
                                            ProjectCostingSheetAddTDS.LabourHoursInformationRow newRowOt = ((ProjectCostingSheetAddTDS.LabourHoursInformationDataTable)Table).NewLabourHoursInformationRow();
                                            if (projectGateway.IsFairWageProjectWorkFunction(projectId, work_, functionListRow.Function_))
                                            {
                                                if (jobClassType_ != "Regular Rate")
                                                {
                                                    decimal fairWageRate = projectGateway.GetOperatorGroupRate(projectId, jobClassType_);

                                                    GetEmployeeDataFairWageOvertime(newStartDate, newEndDate, employeeListRow.EmployeeID, work_, newRowOt, countryId, fringeRate, fairWageRate);
                                                }
                                                else
                                                {
                                                    GetEmployeeDataOvertime(newStartDate, newEndDate, employeeListRow.EmployeeID, work_, newRowOt); // Is same to non fair wage project
                                                }
                                            }
                                            else
                                            {
                                                GetEmployeeDataOvertime(newStartDate, newEndDate, employeeListRow.EmployeeID, work_, newRowOt); // Is same to non fair wage project
                                            }

                                            newRowOt.CostingSheetID = 0;
                                            newRowOt.Work_ = work_;
                                            newRowOt.EmployeeID = employeeListRow.EmployeeID;
                                            newRowOt.RefID = refId;
                                            newRowOt.LHQuantity = overtime;
                                            newRowOt.MealsQuantity = 0;
                                            newRowOt.MealsUnitOfMeasurement = "";
                                            newRowOt.MotelUnitOfMeasurement = "";
                                            newRowOt.MealsCostCad = MealsAllowance.GetMealsAllowance(1, true, "Full Day");
                                            newRowOt.MotelCostCad = 0;
                                            newRowOt.TotalCostCad = (Convert.ToDecimal(overtime) * decimal.Round(newRowOt.LHCostCad,2));
                                            newRowOt.MealsCostUsd = MealsAllowance.GetMealsAllowance(2, true, "Full Day");
                                            newRowOt.MotelCostUsd = 0;
                                            newRowOt.TotalCostUsd = (Convert.ToDecimal(overtime) * decimal.Round(newRowOt.LHCostUsd,2));
                                            newRowOt.Deleted = false;
                                            newRowOt.InDatabase = false;
                                            newRowOt.COMPANY_ID = companyId;
                                            newRowOt.Name = employeeName + " - Overtime";
                                            newRowOt.StartDate = newStartDate;
                                            newRowOt.EndDate = endDate;
                                            newRowOt.FromDatabase = true;
                                            newRowOt.Function_ = functionListRow.Function_;
                                            newRowOt.WorkFunction = work_ + " . " + functionListRow.Function_;
                                            newRowOt.Month = month;
                                            newRowOt.ClientName = clientName;
                                            newRowOt.ProjectName = projectName;                                         
                                            ((ProjectCostingSheetAddTDS.LabourHoursInformationDataTable)Table).AddLabourHoursInformationRow(newRowOt);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                ProjectCostingSheetAddOriginalLabourHourGateway projectCostingSheetAddOriginalLabourHourGateway = new ProjectCostingSheetAddOriginalLabourHourGateway(Data);
                                projectCostingSheetAddOriginalLabourHourGateway.LoadByProjectStartDateEndDateWorkFunctionJobClassTypeEmployeeId(projectId, startDate, endDate, work_, functionListRow.Function_, jobClassType_, employeeListRow.EmployeeID);

                                if (projectCostingSheetAddOriginalLabourHourGateway.Table.Rows.Count > 0)
                                {
                                    double lhQuantity = 0;
                                    double overtime = 0;
                                    decimal mealsQuantity = 0;
                                    decimal motelQuantity = 0;
                                    string employeeName = "";
                                    refId++;

                                    foreach (ProjectCostingSheetAddTDS.OriginalLabourHourRow originalRow in (ProjectCostingSheetAddTDS.OriginalLabourHourDataTable)projectCostingSheetAddOriginalLabourHourGateway.Table)
                                    {
                                        employeeName = originalRow.EmployeeName;

                                        // Meal hours quantity
                                        if (!originalRow.IsMealsCountryNull())
                                        {
                                            if (originalRow.MealsAllowance > 0)
                                            {
                                                mealsQuantity++;
                                            }
                                        }

                                        double acumPeriod = GetTotalHoursByEmployeeIdPeriodId(originalRow.EmployeeID, originalRow.Date_, originalRow.ProjectTimeID);

                                        if (acumPeriod > overtimeByCountry)
                                        {
                                            overtime = overtime + originalRow.ProjectTime;
                                        }
                                        else
                                        {
                                            double newAcumPeriod = acumPeriod + originalRow.ProjectTime;

                                            if (newAcumPeriod > overtimeByCountry)
                                            {
                                                overtime = overtime + (newAcumPeriod - overtimeByCountry);
                                                lhQuantity = lhQuantity + (originalRow.ProjectTime - (newAcumPeriod - overtimeByCountry));
                                            }
                                            else
                                            {
                                                lhQuantity = lhQuantity + originalRow.ProjectTime;
                                            }
                                        }
                                    }

                                    if (lhQuantity > 0)
                                    {
                                        ProjectCostingSheetAddTDS.LabourHoursInformationRow newRow = ((ProjectCostingSheetAddTDS.LabourHoursInformationDataTable)Table).NewLabourHoursInformationRow();
                                        if (projectGateway.IsFairWageProjectWorkFunction(projectId, work_, functionListRow.Function_))
                                        {
                                            if (jobClassType_ != "Regular Rate")
                                            {
                                                decimal fairWageRate = projectGateway.GetOperatorGroupRate(projectId, jobClassType_);

                                                GetEmployeeDataFairWage(startDate, endDate, employeeListRow.EmployeeID, work_, newRow, countryId, fringeRate, fairWageRate);
                                            }
                                            else
                                            {
                                                GetEmployeeData(startDate, endDate, employeeListRow.EmployeeID, work_, newRow);
                                            }
                                        }
                                        else
                                        {
                                            GetEmployeeData(startDate, endDate, employeeListRow.EmployeeID, work_, newRow);
                                        }
                                        newRow.CostingSheetID = 0;
                                        newRow.Work_ = work_;
                                        newRow.EmployeeID = employeeListRow.EmployeeID;
                                        newRow.RefID = refId;
                                        newRow.LHQuantity = lhQuantity;
                                        newRow.MealsQuantity = Convert.ToInt32(mealsQuantity);
                                        if (mealsQuantity > 0) newRow.MealsUnitOfMeasurement = "Day"; else newRow.MealsUnitOfMeasurement = "";
                                        if (motelQuantity > 0) newRow.MotelUnitOfMeasurement = "Day"; else newRow.MotelUnitOfMeasurement = "";
                                        newRow.MealsCostCad = MealsAllowance.GetMealsAllowance(1, true, "Full Day");
                                        newRow.MotelCostCad = 0;
                                        newRow.TotalCostCad = (Convert.ToDecimal(lhQuantity) * decimal.Round(newRow.LHCostCad,2)) + (mealsQuantity * newRow.MealsCostCad) + (motelQuantity * newRow.MotelCostCad);
                                        newRow.MealsCostUsd = MealsAllowance.GetMealsAllowance(2, true, "Full Day");
                                        newRow.MotelCostUsd = 0;
                                        newRow.TotalCostUsd = (Convert.ToDecimal(lhQuantity) * decimal.Round(newRow.LHCostUsd,2)) + (mealsQuantity * newRow.MealsCostUsd) + (motelQuantity * newRow.MotelCostUsd);
                                        newRow.Deleted = false;
                                        newRow.InDatabase = false;
                                        newRow.COMPANY_ID = companyId;
                                        newRow.Name = employeeName;
                                        newRow.StartDate = startDate;
                                        newRow.EndDate = endDate;
                                        newRow.FromDatabase = true;
                                        newRow.Function_ = functionListRow.Function_;
                                        newRow.WorkFunction = work_ + " . " + functionListRow.Function_;
                                        newRow.Month = month;
                                        newRow.ClientName = clientName;
                                        newRow.ProjectName = projectName;
                                        ((ProjectCostingSheetAddTDS.LabourHoursInformationDataTable)Table).AddLabourHoursInformationRow(newRow);
                                    }

                                    if (overtime > 0)
                                    {
                                        refId++;
                                        ProjectCostingSheetAddTDS.LabourHoursInformationRow newRowOt = ((ProjectCostingSheetAddTDS.LabourHoursInformationDataTable)Table).NewLabourHoursInformationRow();
                                        if (projectGateway.IsFairWageProjectWorkFunction(projectId, work_, functionListRow.Function_))
                                        {
                                            if (jobClassType_ != "Regular Rate")
                                            {
                                                decimal fairWageRate = projectGateway.GetOperatorGroupRate(projectId, jobClassType_);

                                                GetEmployeeDataFairWageOvertime(newStartDate, newEndDate, employeeListRow.EmployeeID, work_, newRowOt, countryId, fringeRate, fairWageRate);
                                            }
                                            else
                                            {
                                                GetEmployeeDataOvertime(newStartDate, newEndDate, employeeListRow.EmployeeID, work_, newRowOt); // Is same to non fair wage project
                                            }
                                        }
                                        else
                                        {
                                            GetEmployeeDataOvertime(newStartDate, newEndDate, employeeListRow.EmployeeID, work_, newRowOt); // Is same to non fair wage project
                                        }

                                        newRowOt.CostingSheetID = 0;
                                        newRowOt.Work_ = work_;
                                        newRowOt.EmployeeID = employeeListRow.EmployeeID;
                                        newRowOt.RefID = refId;
                                        newRowOt.LHQuantity = overtime;
                                        newRowOt.MealsQuantity = 0;
                                        newRowOt.MealsUnitOfMeasurement = "";
                                        newRowOt.MotelUnitOfMeasurement = "";
                                        newRowOt.MealsCostCad = MealsAllowance.GetMealsAllowance(1, true, "Full Day");
                                        newRowOt.MotelCostCad = 0;
                                        newRowOt.TotalCostCad = (Convert.ToDecimal(overtime) * decimal.Round(newRowOt.LHCostCad,2));
                                        newRowOt.MealsCostUsd = MealsAllowance.GetMealsAllowance(2, true, "Full Day");
                                        newRowOt.MotelCostUsd = 0;
                                        newRowOt.TotalCostUsd = (Convert.ToDecimal(overtime) * decimal.Round(newRowOt.LHCostUsd,2));
                                        newRowOt.Deleted = false;
                                        newRowOt.InDatabase = false;
                                        newRowOt.COMPANY_ID = companyId;
                                        newRowOt.Name = employeeName + " - Overtime";
                                        newRowOt.StartDate = startDate;
                                        newRowOt.EndDate = endDate;
                                        newRowOt.FromDatabase = true;
                                        newRowOt.Function_ = functionListRow.Function_;
                                        newRowOt.WorkFunction = work_ + " . " + functionListRow.Function_;
                                        newRowOt.Month = month;
                                        newRowOt.ClientName = clientName;
                                        newRowOt.ProjectName = projectName;
                                        ((ProjectCostingSheetAddTDS.LabourHoursInformationDataTable)Table).AddLabourHoursInformationRow(newRowOt);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="work_">work_</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="lHQuantity">lHQuantity</param>
        /// <param name="lHUnitOfMeasurement">lHUnitOfMeasurement</param>
        /// <param name="mealsUnitOfMeasurement">mealsUnitOfMeasurement</param>
        /// <param name="mealsQuantity">mealsQuantity</param>
        /// <param name="motelUnitOfMeasurement">motelUnitOfMeasurement</param>
        /// <param name="motelQuantity">motelQuantity</param>
        /// <param name="lHCostCad">lHCostCad</param>
        /// <param name="mealsCostCad">mealsCostCad</param>
        /// <param name="motelCostCad">motelCostCad</param>
        /// <param name="totalCostCad">totalCostCad</param>
        /// <param name="lHCostUsd">lHCostUsd</param>
        /// <param name="mealsCostUsd">mealsCostUsd</param>
        /// <param name="motelCostUsd">motelCostUsd</param>
        /// <param name="totalCostUsd">totalCostUsd</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="name">name</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="workFunction">workFunction</param>
        /// <param name="function_">function_</param>
        public void Insert(int costingSheetId, string work_, int employeeId, double lHQuantity, string lHUnitOfMeasurement, string mealsUnitOfMeasurement, int? mealsQuantity, string motelUnitOfMeasurement, int? motelQuantity, decimal lHCostCad, decimal? mealsCostCad, decimal? motelCostCad, decimal totalCostCad, decimal lHCostUsd, decimal? mealsCostUsd, decimal? motelCostUsd, decimal totalCostUsd, bool deleted, int companyId, string name, DateTime startDate, DateTime endDate, string workFunction, string function_)
        {
            ProjectCostingSheetAddTDS.LabourHoursInformationRow row = ((ProjectCostingSheetAddTDS.LabourHoursInformationDataTable)Table).NewLabourHoursInformationRow();

            row.CostingSheetID = costingSheetId;
            row.Work_ = work_;
            row.EmployeeID = employeeId;
            row.RefID = GetNewRefId();
            row.LHQuantity = lHQuantity;
            row.LHUnitOfMeasurement = lHUnitOfMeasurement;
            row.MealsUnitOfMeasurement = mealsUnitOfMeasurement.Trim();
            if (mealsQuantity.HasValue) row.MealsQuantity = mealsQuantity.Value ; else row.SetMealsQuantityNull();
            row.MotelUnitOfMeasurement = motelUnitOfMeasurement.Trim();
            if (motelQuantity.HasValue) row.MotelQuantity = motelQuantity.Value; else row.SetMotelQuantityNull();
            row.LHCostCad = lHCostCad;
            if (mealsCostCad.HasValue) row.MealsCostCad = mealsCostCad.Value; else row.SetMealsCostCadNull();
            if (motelCostCad.HasValue) row.MotelCostCad = motelCostCad.Value; else row.SetMotelCostCadNull();
            row.TotalCostCad = totalCostCad;
            row.LHCostUsd = lHCostUsd;
            if (mealsCostUsd.HasValue) row.MealsCostUsd = mealsCostUsd.Value; else row.SetMealsCostUsdNull();
            if (motelCostUsd.HasValue) row.MotelCostUsd = motelCostUsd.Value; else row.SetMotelCostUsdNull();
            row.TotalCostUsd = totalCostUsd;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.InDatabase = false;
            row.Name = name;
            row.StartDate = startDate;
            row.EndDate = endDate;
            row.FromDatabase = false;
            row.WorkFunction = workFunction;
            row.Function_ = function_;

            ((ProjectCostingSheetAddTDS.LabourHoursInformationDataTable)Table).AddLabourHoursInformationRow(row);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="work_">work_</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="refId">refId</param>
        /// <param name="lHQuantity">lHQuantity</param>
        /// <param name="lHUnitOfMeasurement">lHUnitOfMeasurement</param>
        /// <param name="mealsUnitOfMeasurement">mealsUnitOfMeasurement</param>
        /// <param name="mealsQuantity">mealsQuantity</param>
        /// <param name="motelUnitOfMeasurement">motelUnitOfMeasurement</param>
        /// <param name="motelQuantity">motelQuantity</param>
        /// <param name="lHCostCad">lHCostCad</param>
        /// <param name="mealsCostCad">mealsCostCad</param>
        /// <param name="motelCostCad">motelCostCad</param>
        /// <param name="totalCostCad">totalCostCad</param>
        /// <param name="lHCostUsd">lHCostUsd</param>
        /// <param name="mealsCostUsd">mealsCostUsd</param>
        /// <param name="motelCostUsd">motelCostUsd</param>
        /// <param name="totalCostUsd">totalCostUsd</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="name">name</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="workFunction">workFunction</param>
        /// <param name="function_">function_</param>
        public void Update(int costingSheetId, string work_, int employeeId, int refId, double lHQuantity, string lHUnitOfMeasurement, string mealsUnitOfMeasurement, int? mealsQuantity, string motelUnitOfMeasurement, int? motelQuantity, decimal lHCostCad, decimal? mealsCostCad, decimal? motelCostCad, decimal totalCostCad, decimal lHCostUsd, decimal? mealsCostUsd, decimal? motelCostUsd, decimal totalCostUsd, bool deleted, int companyId, string name, DateTime startDate, DateTime endDate, string workFunction, string function_)
        {
            ProjectCostingSheetAddTDS.LabourHoursInformationRow row = GetRow(costingSheetId, work_, employeeId, refId);

            row.LHQuantity = lHQuantity;
            row.LHUnitOfMeasurement = lHUnitOfMeasurement;
            row.MealsUnitOfMeasurement = mealsUnitOfMeasurement.Trim();
            if (mealsQuantity.HasValue) row.MealsQuantity = mealsQuantity.Value; else row.SetMealsQuantityNull();
            row.MotelUnitOfMeasurement = motelUnitOfMeasurement.Trim();
            if (motelQuantity.HasValue) row.MotelQuantity = motelQuantity.Value; else row.SetMotelQuantityNull();
            row.LHCostCad = lHCostCad;
            if (mealsCostCad.HasValue) row.MealsCostCad = mealsCostCad.Value; else row.SetMealsCostCadNull();
            if (motelCostCad.HasValue) row.MotelCostCad = motelCostCad.Value; else row.SetMotelCostCadNull();
            row.TotalCostCad = totalCostCad;
            row.LHCostUsd = lHCostUsd;
            if (mealsCostUsd.HasValue) row.MealsCostUsd = mealsCostUsd.Value; else row.SetMealsCostUsdNull();
            if (motelCostUsd.HasValue) row.MotelCostUsd = motelCostUsd.Value; else row.SetMotelCostUsdNull();
            row.TotalCostUsd = totalCostUsd;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.Name = name;
            row.StartDate = startDate;
            row.EndDate = endDate;
            row.WorkFunction = workFunction;
            row.Function_ = function_;
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="work_">work_</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="refId">refId</param>
        public void Delete(int costingSheetId, string work_, int employeeId, int refId)
        {
            ProjectCostingSheetAddTDS.LabourHoursInformationRow row = GetRow(costingSheetId, work_, employeeId, refId);
            row.Deleted = true;
        }



        /// <summary>
        /// Save all LH Costing Sheets to database (direct)
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="costingSheetId">costingSheetId</param>
        public void Save(int companyId, int costingSheetId)
        {
            ProjectCostingSheetAddTDS labourHourInformationChanges = (ProjectCostingSheetAddTDS)Data.GetChanges();

            if (labourHourInformationChanges.LabourHoursInformation.Rows.Count > 0)
            {
                foreach (ProjectCostingSheetAddTDS.LabourHoursInformationRow row in (ProjectCostingSheetAddTDS.LabourHoursInformationDataTable)labourHourInformationChanges.LabourHoursInformation)
                {
                    // Insert new costing sheet LH 
                    if ((!row.Deleted) && (!row.InDatabase))
                    {
                        int? mealsQuantity = null; if (!row.IsMealsQuantityNull()) mealsQuantity = row.MealsQuantity;
                        int? motelQuantity = null; if (!row.IsMotelQuantityNull()) motelQuantity = row.MotelQuantity;
                        decimal? measlCostCad = null; if (!row.IsMealsCostCadNull()) measlCostCad = row.MealsCostCad;
                        decimal? motelCostCad = null; if (!row.IsMotelCostCadNull()) motelCostCad = row.MotelCostCad;
                        decimal? measlCostUsd = null; if (!row.IsMealsCostUsdNull()) measlCostUsd = row.MealsCostUsd;
                        decimal? motelCostUsd = null; if (!row.IsMotelCostUsdNull()) motelCostUsd = row.MotelCostUsd;
                       
                        new ProjectCostingSheetLabourHours(null).InsertDirect(costingSheetId, row.Work_, row.EmployeeID, row.RefID, row.LHQuantity, row.LHUnitOfMeasurement, row.MealsUnitOfMeasurement, mealsQuantity, row.MotelUnitOfMeasurement, motelQuantity, row.LHCostCad, measlCostCad, motelCostCad, row.TotalCostCad, row.LHCostUsd, measlCostUsd, motelCostUsd, row.TotalCostUsd, false, companyId, row.StartDate, row.EndDate, row.Function_);
                    }
                }
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="work_">work_</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="refId">refId</param>
        /// <returns>row</returns>
        private ProjectCostingSheetAddTDS.LabourHoursInformationRow GetRow(int costingSheetId, string work_, int employeeId, int refId)
        {
            ProjectCostingSheetAddTDS.LabourHoursInformationRow row = ((ProjectCostingSheetAddTDS.LabourHoursInformationDataTable)Table).FindByRefIDEmployeeIDWork_CostingSheetID(refId, employeeId, work_, costingSheetId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Projects.Projects.ProjectCostingSheetAddLabourHoursInformation.GetRow");
            }

            return row;
        }



        /// <summary>
        /// GetNewRefId
        /// </summary>
        /// <returns>RefID</returns>
        private int GetNewRefId()
        {
            int newRefId = 0;

            foreach (ProjectCostingSheetAddTDS.LabourHoursInformationRow row in (ProjectCostingSheetAddTDS.LabourHoursInformationDataTable)Table)
            {
                if (newRefId < row.RefID)
                {
                    newRefId = row.RefID;
                }
            }

            newRefId++;

            return newRefId;
        }




        /// <summary>
        /// GetEmployeeDataFairWage
        /// </summary>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="work_">work_</param>
        /// <param name="newRow">newRow</param>
        /// <param name="contryId">contryId</param>
        /// <param name="fringeRate">fringeRate</param>
        /// <param name="fairWageRate">fairWageRate</param>
        private void GetEmployeeDataFairWage(DateTime startDate, DateTime endDate, int employeeId, string work_, ProjectCostingSheetAddTDS.LabourHoursInformationRow newRow, int contryId, decimal fringeRate, decimal fairWageRate)
        {
            // Load data
            ProjectCostingSheetAddEmployeeListGateway projectCostingSheetAddEmployeeListGateway = new ProjectCostingSheetAddEmployeeListGateway();
            projectCostingSheetAddEmployeeListGateway.LoadByStartDateEndDateEmployeeIdWork_FairWage(startDate, endDate, employeeId, work_);

            if (projectCostingSheetAddEmployeeListGateway.Table.Rows.Count <= 0)
            {
                projectCostingSheetAddEmployeeListGateway.LoadByStartDateEndDateEmployeeIdFairWage(startDate, endDate, employeeId);
                if (projectCostingSheetAddEmployeeListGateway.Table.Rows.Count <= 0)
                {
                    projectCostingSheetAddEmployeeListGateway.LoadByStartDateEmployeeIdWork_FairWage(startDate, employeeId, work_);
                    if (projectCostingSheetAddEmployeeListGateway.Table.Rows.Count <= 0)
                    {
                        projectCostingSheetAddEmployeeListGateway.LoadByStartDateEmployeeIdFairWage(startDate, employeeId);
                        if (projectCostingSheetAddEmployeeListGateway.Table.Rows.Count <= 0)
                        {
                            projectCostingSheetAddEmployeeListGateway.LoadByEmployeeId(employeeId);
                        }
                    }
                }
            }

            DataRow employeeRow = projectCostingSheetAddEmployeeListGateway.GetRow(employeeId);
            newRow.LHUnitOfMeasurement = (string)employeeRow["UnitOfMeasurement"];

            if (contryId == 1)
            {
                //Canada
                decimal regularRate = 0; if (!employeeRow.IsNull("PayRateCad")) { regularRate = (decimal)employeeRow["PayRateCad"]; }
                
                decimal rate = fairWageRate;
                decimal burdenRate = 0;

                if (fairWageRate < regularRate)
                {
                    rate = regularRate;
                }

                if (!employeeRow.IsNull("BourdenFactor"))
                {
                    decimal burdenFactor = (decimal)employeeRow["BourdenFactor"] / 100;
                    burdenRate = rate * burdenFactor;
                }

                newRow.LHCostCad = rate + fringeRate + burdenRate;
                newRow.LHCostUsd = rate + fringeRate + burdenRate;
            }
            else
            {
                //USA
                decimal regularRate = 0; if (!employeeRow.IsNull("PayRateUsd")) { regularRate = (decimal)employeeRow["PayRateUsd"]; }
                decimal benefitFactorUsd = 0; if (!employeeRow.IsNull("HealthBenefitUsd")) { benefitFactorUsd = (decimal)employeeRow["BenefitFactorUsd"]; }

                decimal healtBenefitFactor = 0;
                if (!employeeRow.IsNull("HealthBenefitUsd"))
                {                    
                    decimal usHealthBenefitFactor = (decimal)employeeRow["HealthBenefitUsd"] / 100;
                    healtBenefitFactor = benefitFactorUsd + (benefitFactorUsd * usHealthBenefitFactor);
                }
                else
                {
                    healtBenefitFactor = benefitFactorUsd;
                }
                decimal burdenRate = 0;
                decimal fringeDeficiency = fringeRate - benefitFactorUsd;
                decimal rate = fairWageRate;

                if (fairWageRate < regularRate)
                {
                    rate = regularRate;
                }

                if (!employeeRow.IsNull("BourdenFactor"))
                {
                    decimal burdenFactor = (decimal)employeeRow["BourdenFactor"] / 100;
                    burdenRate = (rate + fringeDeficiency) * burdenFactor;
                }                

                newRow.LHCostUsd = rate + fringeDeficiency + burdenRate + healtBenefitFactor;
                newRow.LHCostCad = rate + fringeDeficiency + burdenRate + healtBenefitFactor;
            }
        }



        /// <summary>
        /// GetEmployeeDataFairWageOvertime
        /// </summary>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="work_">work_</param>
        /// <param name="newRow">newRow</param>
        /// <param name="contryId">contryId</param>
        /// <param name="fringeRate">fringeRate</param>
        /// <param name="fairWageRate">fairWageRate</param>
        private void GetEmployeeDataFairWageOvertime(DateTime startDate, DateTime endDate, int employeeId, string work_, ProjectCostingSheetAddTDS.LabourHoursInformationRow newRow, int contryId, decimal fringeRate, decimal fairWageRate)
        {
            ProjectCostingSheetAddEmployeeListGateway projectCostingSheetAddEmployeeListGateway = new ProjectCostingSheetAddEmployeeListGateway();
            projectCostingSheetAddEmployeeListGateway.LoadByStartDateEndDateEmployeeIdWork_FairWage(startDate, endDate, employeeId, work_);

            if (projectCostingSheetAddEmployeeListGateway.Table.Rows.Count <= 0)
            {
                projectCostingSheetAddEmployeeListGateway.LoadByStartDateEndDateEmployeeIdFairWage(startDate, endDate, employeeId);
                if (projectCostingSheetAddEmployeeListGateway.Table.Rows.Count <= 0)
                {
                    projectCostingSheetAddEmployeeListGateway.LoadByStartDateEmployeeIdWork_FairWage(startDate, employeeId, work_);
                    if (projectCostingSheetAddEmployeeListGateway.Table.Rows.Count <= 0)
                    {
                        projectCostingSheetAddEmployeeListGateway.LoadByStartDateEmployeeIdFairWage(startDate, employeeId);
                        if (projectCostingSheetAddEmployeeListGateway.Table.Rows.Count <= 0)
                        {
                            projectCostingSheetAddEmployeeListGateway.LoadByEmployeeId(employeeId);
                        }
                    }
                }
            }

            DataRow employeeRow = projectCostingSheetAddEmployeeListGateway.GetRow(employeeId);
            newRow.LHUnitOfMeasurement = (string)employeeRow["UnitOfMeasurement"];

            if (contryId == 1)
            {
                //Canada
                decimal regularRate = 0; if (!employeeRow.IsNull("PayRateCad")) { regularRate = (decimal)employeeRow["PayRateCad"]; }

                decimal rate = fairWageRate * 1.5M;
                decimal burdenRate = 0;

                if (fairWageRate < regularRate)
                {
                    rate = regularRate * 1.5M;
                }

                if (!employeeRow.IsNull("BourdenFactor"))
                {
                    decimal burdenFactor = (decimal)employeeRow["BourdenFactor"] / 100;
                    burdenRate = rate * burdenFactor;
                }

                newRow.LHCostCad = rate + fringeRate + burdenRate;
                newRow.LHCostUsd = rate + fringeRate + burdenRate;
            }
            else
            {
                //USA
                decimal regularRate = 0; if (!employeeRow.IsNull("PayRateUsd")) { regularRate = (decimal)employeeRow["PayRateUsd"]; }
                decimal benefitFactorUsd = 0; if (!employeeRow.IsNull("HealthBenefitUsd")) { benefitFactorUsd = (decimal)employeeRow["BenefitFactorUsd"]; }

                decimal healtBenefitFactor = 0;
                if (!employeeRow.IsNull("HealthBenefitUsd"))
                {
                    decimal usHealthBenefitFactor = (decimal)employeeRow["HealthBenefitUsd"] / 100;
                    healtBenefitFactor = benefitFactorUsd + (benefitFactorUsd * usHealthBenefitFactor);
                }
                else
                {
                    healtBenefitFactor = benefitFactorUsd;
                }

                decimal burdenRate = 0;
                decimal fringeDeficiency = fringeRate - benefitFactorUsd;
                decimal rate = fairWageRate * 1.5M;

                if (fairWageRate < regularRate)
                {
                    rate = regularRate * 1.5M;
                }

                if (!employeeRow.IsNull("BourdenFactor"))
                {
                    decimal burdenFactor = (decimal)employeeRow["BourdenFactor"] / 100;
                    burdenRate = (rate + fringeDeficiency) * burdenFactor;
                } 

                newRow.LHCostUsd = rate + fringeDeficiency + burdenRate + healtBenefitFactor;
                newRow.LHCostCad = rate + fringeDeficiency + burdenRate + healtBenefitFactor;
            }
        }



        /// <summary>
        /// GetEmployeeData
        /// </summary>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="work_">work_</param>
        /// <param name="newRow">newRow</param>
        private void GetEmployeeData(DateTime startDate, DateTime endDate, int employeeId, string work_, ProjectCostingSheetAddTDS.LabourHoursInformationRow newRow)
        {
            ProjectCostingSheetAddEmployeeListGateway projectCostingSheetAddEmployeeListGateway = new ProjectCostingSheetAddEmployeeListGateway();
            projectCostingSheetAddEmployeeListGateway.LoadByStartDateEndDateEmployeeIdWork_(startDate, endDate, employeeId, work_);

            if (projectCostingSheetAddEmployeeListGateway.Table.Rows.Count <= 0)
            {
                projectCostingSheetAddEmployeeListGateway.LoadByStartDateEndDateEmployeeId(startDate, endDate, employeeId);
                if (projectCostingSheetAddEmployeeListGateway.Table.Rows.Count <= 0)
                {
                    projectCostingSheetAddEmployeeListGateway.LoadByStartDateEmployeeIdWork_(startDate, employeeId, work_);
                    if (projectCostingSheetAddEmployeeListGateway.Table.Rows.Count <= 0)
                    {
                        projectCostingSheetAddEmployeeListGateway.LoadByStartDateEmployeeId(startDate, employeeId);
                        if (projectCostingSheetAddEmployeeListGateway.Table.Rows.Count <= 0)
                        {
                            projectCostingSheetAddEmployeeListGateway.LoadByEmployeeId(employeeId);
                        }
                    }
                }
            }

            DataRow employeeRow = projectCostingSheetAddEmployeeListGateway.GetRow(employeeId);
            newRow.LHUnitOfMeasurement = (string)employeeRow["UnitOfMeasurement"];

            newRow.LHCostCad = (decimal)employeeRow["CostCad"] + (decimal)employeeRow["BenefitFactorCad"];//employeeRow["CostCad"] == PayRateCad + BurdenRateCad
            newRow.LHCostUsd = (decimal)employeeRow["CostUsd"] + (decimal)employeeRow["BenefitFactorUsd"];//employeeRow["CostUsd"] == PayRateUsd + BurdenRateUsd

            if ((decimal)employeeRow["CostCad"] > 0)
            {
                newRow.LHCostUsd = (decimal)employeeRow["CostCad"] + (decimal)employeeRow["BenefitFactorCad"];//employeeRow["CostUsd"] == PayRateUsd + BurdenRateUsd
            }
        }



        /// <summary>
        /// GetEmployeeDataOvertime
        /// </summary>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="work_">work_</param>
        /// <param name="newRow">newRow</param>
        private void GetEmployeeDataOvertime(DateTime startDate, DateTime endDate, int employeeId, string work_, ProjectCostingSheetAddTDS.LabourHoursInformationRow newRow)
        {
            ProjectCostingSheetAddEmployeeListGateway projectCostingSheetAddEmployeeListGateway = new ProjectCostingSheetAddEmployeeListGateway();
            projectCostingSheetAddEmployeeListGateway.LoadByStartDateEndDateEmployeeIdWork_(startDate, endDate, employeeId, work_);

            if (projectCostingSheetAddEmployeeListGateway.Table.Rows.Count <= 0)
            {
                projectCostingSheetAddEmployeeListGateway.LoadByStartDateEndDateEmployeeId(startDate, endDate, employeeId);
                if (projectCostingSheetAddEmployeeListGateway.Table.Rows.Count <= 0)
                {
                    projectCostingSheetAddEmployeeListGateway.LoadByStartDateEmployeeIdWork_(startDate, employeeId, work_);
                    if (projectCostingSheetAddEmployeeListGateway.Table.Rows.Count <= 0)
                    {
                        projectCostingSheetAddEmployeeListGateway.LoadByStartDateEmployeeId(startDate, employeeId);
                        if (projectCostingSheetAddEmployeeListGateway.Table.Rows.Count <= 0)
                        {
                            projectCostingSheetAddEmployeeListGateway.LoadByEmployeeId(employeeId);
                        }
                    }
                }
            }

            DataRow employeeRow = projectCostingSheetAddEmployeeListGateway.GetRow(employeeId);
            newRow.LHUnitOfMeasurement = (string)employeeRow["UnitOfMeasurement"];

            newRow.LHCostCad = ((decimal)employeeRow["CostCad"] * 1.5M) + (decimal)employeeRow["BenefitFactorCad"];//employeeRow["CostCad"] == PayRateCad + BurdenRateCad
            newRow.LHCostUsd = ((decimal)employeeRow["CostUsd"] * 1.5M) + (decimal)employeeRow["BenefitFactorUsd"];//employeeRow["CostUsd"] == PayRateUsd + BurdenRateUsd

            if ((decimal)employeeRow["CostCad"] > 0)
            {
                newRow.LHCostUsd = (decimal)employeeRow["CostCad"] + (decimal)employeeRow["BenefitFactorCad"];//employeeRow["CostUsd"] == PayRateUsd + BurdenRateUsd
            }
        }



        /// <summary>
        /// GetTotalHoursByEmployeeIdPeriodId
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="date">date</param>
        /// <returns>total</returns>
        private double GetTotalHoursByEmployeeIdPeriodId(int employeeId, DateTime date)
        {
            double total = 0;
            PayPeriodGateway payPeriodGateway = new PayPeriodGateway(new DataSet());
            int periodId = payPeriodGateway.GetPayPeriodId(date);

            TimesheetNavigatorGateway timesheetNavigatorGateway = new TimesheetNavigatorGateway();
            timesheetNavigatorGateway.LoadByEmployeIdPayPeriodId(employeeId, periodId);

            foreach (TimesheetNavigatorTDS.LFS_PROJECT_TIMERow row in (TimesheetNavigatorTDS.LFS_PROJECT_TIMEDataTable)timesheetNavigatorGateway.Table)
            {
                if (row.Date_ < date)
                {
                    if (!row.Deleted)
                    {
                        total = total + double.Parse(row.ProjectTime.ToString());
                    }
                }
            }

            return total;
        }



        /// <summary>
        /// GetTotalHoursByEmployeeIdPeriodId
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="date">date</param>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>total</returns>
        private double GetTotalHoursByEmployeeIdPeriodId(int employeeId, DateTime date, int projectTimeId)
        {
            double total = 0;
            PayPeriodGateway payPeriodGateway = new PayPeriodGateway(new DataSet());
            int periodId = payPeriodGateway.GetPayPeriodId(date);

            TimesheetNavigatorGateway timesheetNavigatorGateway = new TimesheetNavigatorGateway();
            timesheetNavigatorGateway.LoadByEmployeIdPayPeriodId(employeeId, periodId);

            foreach (TimesheetNavigatorTDS.LFS_PROJECT_TIMERow row in (TimesheetNavigatorTDS.LFS_PROJECT_TIMEDataTable)timesheetNavigatorGateway.Table)
            {
                if ((!row.IsStartTimeNull() && (!row.IsEndTimeNull())))
                {
                    if ((row.Date_ <= date) && (row.ProjectTimeID != projectTimeId))
                    {
                        if (!row.Deleted)
                        {
                            total = total + row.ProjectTime;
                        }
                    }
                    else
                    {
                        return total;
                    }
                }
            }

            return total;
        }



    }
}