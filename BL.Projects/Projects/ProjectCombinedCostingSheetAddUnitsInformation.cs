using System;
using System.Collections;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.LabourHours.ProjectTime;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectCombinedCostingSheetAddUnitsInformation
    /// </summary>
    public class ProjectCombinedCostingSheetAddUnitsInformation : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectCombinedCostingSheetAddUnitsInformation()
            : base("CombinedUnitsInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectCombinedCostingSheetAddUnitsInformation(DataSet data)
            : base(data, "CombinedUnitsInformation")
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
        public void Load(ArrayList works, ArrayList projects, DateTime startDate, DateTime endDate, int companyId, int clientId)
        {
            int refId = 0;

            foreach (int projectId in projects)
            {
                ProjectGateway projectGateway = new ProjectGateway();
                projectGateway.LoadByProjectId(projectId);

                string project = projectGateway.GetName(projectId);

                // Foreach of Works (FLL, RA, JL, PR, MH Rehab, MOB, Other)
                foreach (string work_ in works)
                {
                    // Load Functions by Work
                    ProjectCostingSheetAddFunctionListGateway projectCostingSheetAddFunctionListGateway = new ProjectCostingSheetAddFunctionListGateway();
                    projectCostingSheetAddFunctionListGateway.LoadByWork_(work_);

                    // Foreach of Functions
                    foreach (ProjectCostingSheetAddTDS.FunctionListRow functionListRow in (ProjectCostingSheetAddTDS.FunctionListDataTable)projectCostingSheetAddFunctionListGateway.Table)
                    {
                        ProjectCostingSheetAddUnitListGateway projectCostingSheetAddUnitListGateway = new ProjectCostingSheetAddUnitListGateway(Data);
                        projectCostingSheetAddUnitListGateway.LoadByProjectIdStartDateEndDateWorkFunction(projectId, startDate, endDate, work_, functionListRow.Function_, companyId);

                        foreach (ProjectCostingSheetAddTDS.UnitListRow unitListRow in (ProjectCostingSheetAddTDS.UnitListDataTable)projectCostingSheetAddUnitListGateway.Table)
                        {
                            DateTime newStartDate = new DateTime();
                            newStartDate = startDate;
                            DateTime newEndDate = new DateTime();
                            newEndDate = endDate;

                            ProjectCostingSheetAddUnitPayPeriodGateway ProjectCostingSheetAddUnitPayPeriodGateway = new ProjectCostingSheetAddUnitPayPeriodGateway(Data);
                            ProjectCostingSheetAddUnitPayPeriodGateway.LoadByStartDateEndDateUnitId(startDate, endDate, unitListRow.UnitID);

                            if (ProjectCostingSheetAddUnitPayPeriodGateway.Table.Rows.Count > 0)
                            {
                                foreach (ProjectCostingSheetAddTDS.UnitPayPeriodRow unitPayPeriodRow in (ProjectCostingSheetAddTDS.UnitPayPeriodDataTable)ProjectCostingSheetAddUnitPayPeriodGateway.Table)
                                {
                                    newEndDate = unitPayPeriodRow.Date_.AddDays(-1);

                                    ProjectCostingSheetAddOriginalUnitGateway projectCostingSheetAddOriginalUnitGateway = new ProjectCostingSheetAddOriginalUnitGateway(Data);
                                    projectCostingSheetAddOriginalUnitGateway.Load(projectId, newStartDate, newEndDate, work_, functionListRow.Function_, unitListRow.UnitID);

                                    if (projectCostingSheetAddOriginalUnitGateway.Table.Rows.Count > 0)
                                    {
                                        ArrayList days = new ArrayList();
                                        ArrayList daysTowed = new ArrayList();
                                        double quantity = 0;
                                        bool isTowedUnitId = false;

                                        PrintProjectCostingGateway verifGateway = new PrintProjectCostingGateway(new DataSet());

                                        foreach (ProjectCostingSheetAddTDS.OriginalUnitRow originalUnitRow in (ProjectCostingSheetAddTDS.OriginalUnitDataTable)projectCostingSheetAddOriginalUnitGateway.Table)
                                        {
                                            int towedUnitId = 0;
                                            if (!originalUnitRow.IsTowedUnitIDNull())
                                            {
                                                towedUnitId = Convert.ToInt32(originalUnitRow.TowedUnitID);
                                            }
                                            if (originalUnitRow.UnitID != towedUnitId)
                                            {
                                                if (!days.Contains(originalUnitRow.Date_))
                                                {
                                                    int amountProjects = verifGateway.UnitSameDayUseSeveralProjects(originalUnitRow.Date_, originalUnitRow.UnitID);

                                                    if (amountProjects > 1)
                                                    {
                                                        double tempQuantity = 1 / Convert.ToDouble(amountProjects);

                                                        int amountFunctions = verifGateway.UnitSameDayUseSeveralWorkFunctions(projectId, originalUnitRow.Date_, originalUnitRow.UnitID);

                                                        if (amountFunctions > 0)
                                                        {
                                                            tempQuantity = tempQuantity / Convert.ToDouble(amountFunctions);
                                                        }

                                                        quantity = quantity + tempQuantity;
                                                    }
                                                    else
                                                    {
                                                        double tempQuantity = 1;

                                                        int amountFunctions = verifGateway.UnitSameDayUseSeveralWorkFunctions(projectId, originalUnitRow.Date_, originalUnitRow.UnitID);

                                                        if (amountFunctions > 0)
                                                        {
                                                            tempQuantity = 1 / Convert.ToDouble(amountFunctions);
                                                        }

                                                        quantity = quantity + tempQuantity;
                                                    }

                                                    days.Add(originalUnitRow.Date_);
                                                }
                                            }
                                            else
                                            {
                                                isTowedUnitId = true;

                                                if (!daysTowed.Contains(originalUnitRow.Date_))
                                                {
                                                    int amountProjects = verifGateway.TowedUnitSameDayUseSeveralProjects(originalUnitRow.Date_, originalUnitRow.UnitID);

                                                    if (amountProjects > 1)
                                                    {
                                                        double tempQuantity = 1 / Convert.ToDouble(amountProjects);

                                                        int amountFunctions = verifGateway.TowedUnitSameDayUseSeveralWorkFunctions(projectId, originalUnitRow.Date_, originalUnitRow.UnitID);

                                                        if (amountFunctions > 0)
                                                        {
                                                            tempQuantity = tempQuantity / Convert.ToDouble(amountFunctions);
                                                        }

                                                        quantity = quantity + tempQuantity;
                                                    }
                                                    else
                                                    {
                                                        double tempQuantity = 1;

                                                        int amountFunctions = verifGateway.TowedUnitSameDayUseSeveralWorkFunctions(projectId, originalUnitRow.Date_, originalUnitRow.UnitID);

                                                        if (amountFunctions > 0)
                                                        {
                                                            tempQuantity = 1 / Convert.ToDouble(amountFunctions);
                                                        }

                                                        quantity = quantity + tempQuantity;
                                                    }

                                                    daysTowed.Add(originalUnitRow.Date_);
                                                }
                                            }
                                        }

                                        ProjectCostingSheetAddTDS.CombinedUnitsInformationRow newRow = ((ProjectCostingSheetAddTDS.CombinedUnitsInformationDataTable)Table).NewCombinedUnitsInformationRow();
                                        GetUnitData(newStartDate, newEndDate, unitListRow.UnitID, work_, newRow, isTowedUnitId);
                                        newRow.CostingSheetID = 0;
                                        newRow.Work_ = work_;
                                        newRow.UnitID = unitListRow.UnitID;
                                        newRow.RefID = refId++;
                                        newRow.Quantity = quantity;
                                        newRow.TotalCostCad = (Convert.ToDecimal(quantity) * newRow.CostCad);
                                        newRow.TotalCostUsd = (Convert.ToDecimal(quantity) * newRow.CostUsd);
                                        newRow.Deleted = false;
                                        newRow.InDatabase = false;
                                        newRow.COMPANY_ID = companyId;
                                        newRow.UnitCode = unitListRow.UnitCode;
                                        newRow.UnitDescription = unitListRow.Description;
                                        newRow.UnitOfMeasurement = unitListRow.UnitOfMeasurement;
                                        newRow.StartDate = newStartDate;
                                        newRow.EndDate = newEndDate;
                                        newRow.FromDatabase = true;
                                        newRow.Function_ = functionListRow.Function_;
                                        newRow.WorkFunction = work_ + " . " + functionListRow.Function_;
                                        newRow.ClientID = clientId;
                                        newRow.ProjectID = projectId;
                                        newRow.Project = project;
                                        ((ProjectCostingSheetAddTDS.CombinedUnitsInformationDataTable)Table).AddCombinedUnitsInformationRow(newRow);
                                    }

                                    newStartDate = newEndDate.AddDays(1);
                                }

                                if (newEndDate <= endDate)
                                {
                                    ProjectCostingSheetAddOriginalUnitGateway projectCostingSheetAddOriginalUnitGateway = new ProjectCostingSheetAddOriginalUnitGateway(Data);
                                    projectCostingSheetAddOriginalUnitGateway.Load(projectId, newStartDate, endDate, work_, functionListRow.Function_, unitListRow.UnitID);

                                    if (projectCostingSheetAddOriginalUnitGateway.Table.Rows.Count > 0)
                                    {
                                        ArrayList days = new ArrayList();
                                        ArrayList daysTowed = new ArrayList();
                                        double quantity = 0;
                                        bool isTowedUnitId = false;

                                        PrintProjectCostingGateway verifGateway = new PrintProjectCostingGateway(new DataSet());

                                        foreach (ProjectCostingSheetAddTDS.OriginalUnitRow originalUnitRow in (ProjectCostingSheetAddTDS.OriginalUnitDataTable)projectCostingSheetAddOriginalUnitGateway.Table)
                                        {
                                            int towedUnitId = 0;
                                            if (!originalUnitRow.IsTowedUnitIDNull())
                                            {
                                                towedUnitId = Convert.ToInt32(originalUnitRow.TowedUnitID);
                                            }
                                            if (originalUnitRow.UnitID != towedUnitId)
                                            {
                                                if (!days.Contains(originalUnitRow.Date_))
                                                {
                                                    int amountProjects = verifGateway.UnitSameDayUseSeveralProjects(originalUnitRow.Date_, originalUnitRow.UnitID);

                                                    if (amountProjects > 1)
                                                    {
                                                        double tempQuantity = 1 / Convert.ToDouble(amountProjects);

                                                        int amountFunctions = verifGateway.UnitSameDayUseSeveralWorkFunctions(projectId, originalUnitRow.Date_, originalUnitRow.UnitID);

                                                        if (amountFunctions > 0)
                                                        {
                                                            tempQuantity = tempQuantity / Convert.ToDouble(amountFunctions);
                                                        }

                                                        quantity = quantity + tempQuantity;
                                                    }
                                                    else
                                                    {
                                                        double tempQuantity = 1;

                                                        int amountFunctions = verifGateway.UnitSameDayUseSeveralWorkFunctions(projectId, originalUnitRow.Date_, originalUnitRow.UnitID);

                                                        if (amountFunctions > 0)
                                                        {
                                                            tempQuantity = 1 / Convert.ToDouble(amountFunctions);
                                                        }

                                                        quantity = quantity + tempQuantity;
                                                    }

                                                    days.Add(originalUnitRow.Date_);
                                                }
                                            }
                                            else
                                            {
                                                isTowedUnitId = true;

                                                if (!daysTowed.Contains(originalUnitRow.Date_))
                                                {
                                                    int amountProjects = verifGateway.TowedUnitSameDayUseSeveralProjects(originalUnitRow.Date_, originalUnitRow.UnitID);

                                                    if (amountProjects > 1)
                                                    {
                                                        double tempQuantity = 1 / Convert.ToDouble(amountProjects);

                                                        int amountFunctions = verifGateway.TowedUnitSameDayUseSeveralWorkFunctions(projectId, originalUnitRow.Date_, originalUnitRow.UnitID);

                                                        if (amountFunctions > 0)
                                                        {
                                                            tempQuantity = tempQuantity / Convert.ToDouble(amountFunctions);
                                                        }

                                                        quantity = quantity + tempQuantity;
                                                    }
                                                    else
                                                    {
                                                        double tempQuantity = 1;

                                                        int amountFunctions = verifGateway.TowedUnitSameDayUseSeveralWorkFunctions(projectId, originalUnitRow.Date_, originalUnitRow.UnitID);

                                                        if (amountFunctions > 0)
                                                        {
                                                            tempQuantity = 1 / Convert.ToDouble(amountFunctions);
                                                        }

                                                        quantity = quantity + tempQuantity;
                                                    }

                                                    daysTowed.Add(originalUnitRow.Date_);
                                                }
                                            }
                                        }

                                        ProjectCostingSheetAddTDS.CombinedUnitsInformationRow newRow = ((ProjectCostingSheetAddTDS.CombinedUnitsInformationDataTable)Table).NewCombinedUnitsInformationRow();
                                        GetUnitData(newStartDate, endDate, unitListRow.UnitID, work_, newRow, isTowedUnitId);
                                        newRow.CostingSheetID = 0;
                                        newRow.Work_ = work_;
                                        newRow.UnitID = unitListRow.UnitID;
                                        newRow.RefID = refId++;
                                        newRow.Quantity = quantity;
                                        newRow.TotalCostCad = (Convert.ToDecimal(quantity) * newRow.CostCad);
                                        newRow.TotalCostUsd = (Convert.ToDecimal(quantity) * newRow.CostUsd);
                                        newRow.Deleted = false;
                                        newRow.InDatabase = false;
                                        newRow.COMPANY_ID = companyId;
                                        newRow.UnitCode = unitListRow.UnitCode;
                                        newRow.UnitDescription = unitListRow.Description;
                                        newRow.UnitOfMeasurement = unitListRow.UnitOfMeasurement;
                                        newRow.StartDate = newStartDate;
                                        newRow.EndDate = endDate;
                                        newRow.FromDatabase = true;
                                        newRow.Function_ = functionListRow.Function_;
                                        newRow.WorkFunction = work_ + " . " + functionListRow.Function_;
                                        newRow.ClientID = clientId;
                                        newRow.ProjectID = projectId;
                                        newRow.Project = project;
                                        ((ProjectCostingSheetAddTDS.CombinedUnitsInformationDataTable)Table).AddCombinedUnitsInformationRow(newRow);
                                    }
                                }
                            }
                            else
                            {
                                ProjectCostingSheetAddOriginalUnitGateway projectCostingSheetAddOriginalUnitGateway = new ProjectCostingSheetAddOriginalUnitGateway(Data);
                                projectCostingSheetAddOriginalUnitGateway.Load(projectId, startDate, endDate, work_, functionListRow.Function_, unitListRow.UnitID);

                                if (projectCostingSheetAddOriginalUnitGateway.Table.Rows.Count > 0)
                                {
                                    ArrayList days = new ArrayList();
                                    ArrayList daysTowed = new ArrayList();
                                    double quantity = 0;
                                    bool isTowedUnitId = false;

                                    PrintProjectCostingGateway verifGateway = new PrintProjectCostingGateway(new DataSet());

                                    foreach (ProjectCostingSheetAddTDS.OriginalUnitRow originalUnitRow in (ProjectCostingSheetAddTDS.OriginalUnitDataTable)projectCostingSheetAddOriginalUnitGateway.Table)
                                    {
                                        int towedUnitId = 0; if (!originalUnitRow.IsTowedUnitIDNull()) towedUnitId = Convert.ToInt32(originalUnitRow.TowedUnitID);
                                        if (originalUnitRow.UnitID != towedUnitId)
                                        {
                                            if (!days.Contains(originalUnitRow.Date_))
                                            {
                                                int amountProjects = verifGateway.UnitSameDayUseSeveralProjects(originalUnitRow.Date_, originalUnitRow.UnitID);

                                                if (amountProjects > 1)
                                                {
                                                    double tempQuantity = 1 / Convert.ToDouble(amountProjects);

                                                    int amountFunctions = verifGateway.UnitSameDayUseSeveralWorkFunctions(projectId, originalUnitRow.Date_, originalUnitRow.UnitID);

                                                    if (amountFunctions > 0)
                                                    {
                                                        tempQuantity = tempQuantity / Convert.ToDouble(amountFunctions);
                                                    }

                                                    quantity = quantity + tempQuantity;
                                                }
                                                else
                                                {
                                                    double tempQuantity = 1;

                                                    int amountFunctions = verifGateway.UnitSameDayUseSeveralWorkFunctions(projectId, originalUnitRow.Date_, originalUnitRow.UnitID);

                                                    if (amountFunctions > 0)
                                                    {
                                                        tempQuantity = 1 / Convert.ToDouble(amountFunctions);
                                                    }

                                                    quantity = quantity + tempQuantity;
                                                }

                                                days.Add(originalUnitRow.Date_);
                                            }
                                        }
                                        else
                                        {
                                            isTowedUnitId = true;

                                            if (!daysTowed.Contains(originalUnitRow.Date_))
                                            {
                                                int amountProjects = verifGateway.TowedUnitSameDayUseSeveralProjects(originalUnitRow.Date_, originalUnitRow.UnitID);

                                                if (amountProjects > 1)
                                                {
                                                    double tempQuantity = 1 / Convert.ToDouble(amountProjects);

                                                    int amountFunctions = verifGateway.TowedUnitSameDayUseSeveralWorkFunctions(projectId, originalUnitRow.Date_, originalUnitRow.UnitID);

                                                    if (amountFunctions > 0)
                                                    {
                                                        tempQuantity = tempQuantity / Convert.ToDouble(amountFunctions);
                                                    }

                                                    quantity = quantity + tempQuantity;
                                                }
                                                else
                                                {
                                                    double tempQuantity = 1;

                                                    int amountFunctions = verifGateway.TowedUnitSameDayUseSeveralWorkFunctions(projectId, originalUnitRow.Date_, originalUnitRow.UnitID);

                                                    if (amountFunctions > 0)
                                                    {
                                                        tempQuantity = 1 / Convert.ToDouble(amountFunctions);
                                                    }

                                                    quantity = quantity + tempQuantity;
                                                }

                                                daysTowed.Add(originalUnitRow.Date_);
                                            }
                                        }
                                    }

                                    ProjectCostingSheetAddTDS.CombinedUnitsInformationRow newRow = ((ProjectCostingSheetAddTDS.CombinedUnitsInformationDataTable)Table).NewCombinedUnitsInformationRow();
                                    GetUnitData(startDate, endDate, unitListRow.UnitID, work_, newRow, isTowedUnitId);
                                    newRow.CostingSheetID = 0;
                                    newRow.Work_ = work_;
                                    newRow.UnitID = unitListRow.UnitID;
                                    newRow.RefID = refId++;
                                    newRow.Quantity = quantity;
                                    newRow.TotalCostCad = (Convert.ToDecimal(quantity) * newRow.CostCad);
                                    newRow.TotalCostUsd = (Convert.ToDecimal(quantity) * newRow.CostUsd);
                                    newRow.Deleted = false;
                                    newRow.InDatabase = false;
                                    newRow.COMPANY_ID = companyId;
                                    newRow.UnitCode = unitListRow.UnitCode;
                                    newRow.UnitDescription = unitListRow.Description;
                                    newRow.UnitOfMeasurement = unitListRow.UnitOfMeasurement;
                                    newRow.StartDate = startDate;
                                    newRow.EndDate = endDate;
                                    newRow.FromDatabase = true;
                                    newRow.Function_ = functionListRow.Function_;
                                    newRow.WorkFunction = work_ + " . " + functionListRow.Function_;
                                    newRow.ClientID = clientId;
                                    newRow.ProjectID = projectId;
                                    newRow.Project = project;
                                    ((ProjectCostingSheetAddTDS.CombinedUnitsInformationDataTable)Table).AddCombinedUnitsInformationRow(newRow);
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
        /// <param name="unitId">unitId</param>
        /// <param name="unitOfMeasurement">unitOfMeasurement</param>
        /// <param name="quantity">quantity</param>
        /// <param name="costCad">costCad</param>
        /// <param name="totalCostCad">totalCostCad</param>
        /// <param name="costUsd">costUsd</param>
        /// <param name="totalCostUsd">totalCostUsd</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="unitCode">unitCode</param>
        /// <param name="unitDescription">unitDescription</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="workFunction">workFunction</param>
        /// <param name="function_">function_</param>
        public void Insert(int costingSheetId, string work_, int unitId, string unitOfMeasurement, double quantity, decimal costCad, decimal totalCostCad, decimal costUsd, decimal totalCostUsd, bool deleted, int companyId, string unitCode, string unitDescription, DateTime startDate, DateTime endDate, string workFunction, string function_, int projectId)
        {
            ProjectCostingSheetAddTDS.CombinedUnitsInformationRow row = ((ProjectCostingSheetAddTDS.CombinedUnitsInformationDataTable)Table).NewCombinedUnitsInformationRow();

            row.CostingSheetID = costingSheetId;
            row.Work_ = work_;
            row.UnitID = unitId;
            row.RefID = GetNewRefId();
            row.Quantity = quantity;
            row.UnitOfMeasurement = unitOfMeasurement;
            row.CostCad = costCad;
            row.TotalCostCad = totalCostCad;
            row.CostUsd = costUsd;
            row.TotalCostUsd = totalCostUsd;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.InDatabase = false;
            row.UnitCode = unitCode;
            row.UnitDescription = unitDescription;
            row.StartDate = startDate;
            row.EndDate = endDate;
            row.FromDatabase = false;
            row.WorkFunction = workFunction;
            row.Function_ = function_;
            row.ProjectID = projectId;

            ((ProjectCostingSheetAddTDS.CombinedUnitsInformationDataTable)Table).AddCombinedUnitsInformationRow(row);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="work_">work_</param>
        /// <param name="unitId">unitId</param>
        /// <param name="refId">refId</param>
        /// <param name="unitOfMeasurement">unitOfMeasurement</param>
        /// <param name="quantity">quantity</param>
        /// <param name="costCad">costCad</param>
        /// <param name="totalCostCad">totalCostCad</param>
        /// <param name="costUsd">costUsd</param>
        /// <param name="totalCostUsd">totalCostUsd</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="unitCode">unitCode</param>
        /// <param name="unitDescription">unitDescription</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="workFunction">workFunction</param>
        /// <param name="function_">function_</param>
        public void Update(int costingSheetId, string work_, int unitId, int refId, string unitOfMeasurement, double quantity, decimal costCad, decimal totalCostCad, decimal costUsd, decimal totalCostUsd, bool deleted, int companyId, string unitCode, string unitDescription, DateTime startDate, DateTime endDate, string workFunction, string function_)
        {
            ProjectCostingSheetAddTDS.CombinedUnitsInformationRow row = GetRow(costingSheetId, work_, unitId, refId);

            row.CostingSheetID = costingSheetId;
            row.Work_ = work_;
            row.UnitID = unitId;
            row.Quantity = quantity;
            row.UnitOfMeasurement = unitOfMeasurement;
            row.CostCad = costCad;
            row.TotalCostCad = totalCostCad;
            row.CostUsd = costUsd;
            row.TotalCostUsd = totalCostUsd;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.UnitCode = unitCode;
            row.UnitDescription = unitDescription;
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
        /// <param name="unitId">unitId</param>
        /// <param name="refId">refId</param>
        public void Delete(int costingSheetId, string work_, int unitId, int refId)
        {
            ProjectCostingSheetAddTDS.CombinedUnitsInformationRow row = GetRow(costingSheetId, work_, unitId, refId);
            row.Deleted = true;
        }



        /// <summary>
        /// Save all Units Costing Sheet
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="costingSheetId">costingSheetId</param>
        public void Save(int companyId, int costingSheetId)
        {
            ProjectCostingSheetAddTDS unitsInformationChanges = (ProjectCostingSheetAddTDS)Data.GetChanges();

            if (unitsInformationChanges.CombinedUnitsInformation.Rows.Count > 0)
            {
                foreach (ProjectCostingSheetAddTDS.CombinedUnitsInformationRow row in (ProjectCostingSheetAddTDS.CombinedUnitsInformationDataTable)unitsInformationChanges.CombinedUnitsInformation)
                {
                    // Insert new costing sheet Units 
                    if ((!row.Deleted) && (!row.InDatabase))
                    {
                        ProjectCombinedCostingSheetUnits units = new ProjectCombinedCostingSheetUnits(null);
                        units.InsertDirect(costingSheetId, row.Work_, row.UnitID, row.RefID, row.UnitOfMeasurement, row.Quantity, row.CostCad, row.TotalCostCad, row.CostUsd, row.TotalCostUsd, row.Deleted, row.COMPANY_ID, row.StartDate, row.EndDate, row.Function_, row.ProjectID);
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
        /// <param name="unitId">unitId</param>
        /// <param name="refId">refId</param>
        /// <returns>row</returns>
        private ProjectCostingSheetAddTDS.CombinedUnitsInformationRow GetRow(int costingSheetId, string work_, int unitId, int refId)
        {
            ProjectCostingSheetAddTDS.CombinedUnitsInformationRow row = ((ProjectCostingSheetAddTDS.CombinedUnitsInformationDataTable)Table).FindByRefIDUnitIDWork_CostingSheetID(refId, unitId, work_, costingSheetId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Projects.Projects.ProjectCombinedCostingSheetAddUnitsInformation.GetRow");
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

            foreach (ProjectCostingSheetAddTDS.CombinedUnitsInformationRow row in (ProjectCostingSheetAddTDS.CombinedUnitsInformationDataTable)Table)
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
        /// GetUnitData
        /// </summary>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="unitId">unitId</param>
        /// <param name="work_">work_</param>
        /// <param name="newRow">newRow</param>
        /// <param name="isTowedUnitId">isTowedUnitId</param>
        private void GetUnitData(DateTime startDate, DateTime endDate, int unitId, string work_, ProjectCostingSheetAddTDS.CombinedUnitsInformationRow newRow, bool isTowedUnitId)
        {
            ProjectCostingSheetAddUnitListGateway projectCostingSheetAddUnitListGateway = new ProjectCostingSheetAddUnitListGateway();
            projectCostingSheetAddUnitListGateway.LoadByStartDateEndDateUnitIdWork_(startDate, endDate, unitId, work_);

            if (projectCostingSheetAddUnitListGateway.Table.Rows.Count <= 0)
            {
                projectCostingSheetAddUnitListGateway.LoadByStartDateEndDateUnitId(startDate, endDate, unitId);
                if (projectCostingSheetAddUnitListGateway.Table.Rows.Count <= 0)
                {
                    projectCostingSheetAddUnitListGateway.LoadByStartDateUnitIdWork_(startDate, unitId, work_);
                    if (projectCostingSheetAddUnitListGateway.Table.Rows.Count <= 0)
                    {
                        projectCostingSheetAddUnitListGateway.LoadByStartDateUnitId(startDate, unitId);
                        if (projectCostingSheetAddUnitListGateway.Table.Rows.Count <= 0)
                        {
                            projectCostingSheetAddUnitListGateway.LoadByUnitId(unitId);
                        }
                    }
                }
            }

            DataRow unitRow = projectCostingSheetAddUnitListGateway.GetRow(unitId);

            if (isTowedUnitId)
            {
                try
                {
                    newRow.CostCad = (decimal)unitRow["CostCad"] / 2;
                    newRow.CostUsd = (decimal)unitRow["CostUsd"] / 2;
                }
                catch
                {
                    newRow.CostCad = 0;
                    newRow.CostUsd = 0;
                }
            }
            else
            {
                newRow.CostCad = (decimal)unitRow["CostCad"];
                newRow.CostUsd = (decimal)unitRow["CostUsd"];
            }
        }



    }
}