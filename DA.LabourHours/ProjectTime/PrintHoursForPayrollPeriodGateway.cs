using System;
using System.Data;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.DA.LabourHours.PayPeriod;
using LiquiForce.LFSLive.DA.LabourHours.Timesheet;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.DA.LabourHours.ProjectTime
{
    /// <summary>
    /// PrintHoursForPayrollPeriodGateway
    /// </summary>
    public class PrintHoursForPayrollPeriodGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public PrintHoursForPayrollPeriodGateway()
            : base("PrintHoursForPayrollPeriod")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public PrintHoursForPayrollPeriodGateway(DataSet data)
            : base(data, "PrintHoursForPayrollPeriod")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new PrintHoursForPayrollPeriodTDS();
        }



        /// <summary>
        /// InitAdapter
        /// </summary>
        protected override void InitAdapter()
        {
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// LoadByEmployeeTypeStartDateEndDateEmployeeIdProjectTimeState
        /// </summary>
        /// <param name="employeeType">employeeType</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="projectTimeState">projectTimeState</param>
        public void LoadByEmployeeTypeStartDateEndDateEmployeeIdProjectTimeState(string employeeType, DateTime startDate, DateTime endDate, int employeeId, string projectTimeState, bool isNewReport, string personnelAgency)
        {
            PrintHoursForPayrollPeriodOriginalGateway originalGateway = new PrintHoursForPayrollPeriodOriginalGateway(Data);
            originalGateway.LoadByEmployeeTypeStartDateEndDateEmployeeIdProjectTimeState(employeeType, startDate, endDate, employeeId, projectTimeState, personnelAgency);

            if (isNewReport)
            {
                this.FillData2();
            }
            else
            {
                this.FillData();
            }
        }



        /// <summary>
        /// LoadByEmployeeTypeStartDateEndDateEmployeeIdProjectTimeStateClientId
        /// </summary>
        /// <param name="employeeType">employeeType</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="projectTimeState">projectTimeState</param>
        /// <param name="clientId">clientId</param>
        public void LoadByEmployeeTypeStartDateEndDateEmployeeIdProjectTimeStateClientId(string employeeType, DateTime startDate, DateTime endDate, int employeeId, string projectTimeState, int clientId, bool isNewReport, string personnelAgency)
        {
            PrintHoursForPayrollPeriodOriginalGateway originalGateway = new PrintHoursForPayrollPeriodOriginalGateway(Data);
            originalGateway.LoadByEmployeeTypeStartDateEndDateEmployeeIdProjectTimeStateClientId(employeeType, startDate, endDate, employeeId, projectTimeState, clientId, personnelAgency);

            if (isNewReport)
            {
                this.FillData2();
            }
            else
            {
                this.FillData();
            }
        }



        /// <summary>
        /// LoadByEmployeeTypeStartDateEndDateEmployeeIdProjectTimeStateClientIdProjectId
        /// </summary>
        /// <param name="employeeType">employeeType</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="projectTimeState">projectTimeState</param>
        /// <param name="clientId">clientId</param>
        /// <param name="projectId">projectId</param>
        public void LoadByEmployeeTypeStartDateEndDateEmployeeIdProjectTimeStateClientIdProjectId(string employeeType, DateTime startDate, DateTime endDate, int employeeId, string projectTimeState, int clientId, int projectId, bool isNewReport, string personnelAgency)
        {
            PrintHoursForPayrollPeriodOriginalGateway originalGateway = new PrintHoursForPayrollPeriodOriginalGateway(Data);
            originalGateway.LoadByEmployeeTypeStartDateEndDateEmployeeIdProjectTimeStateClientIdProjectId(employeeType, startDate, endDate, employeeId, projectTimeState, clientId, projectId, personnelAgency);

            if (isNewReport)
            {
                this.FillData2();
            }
            else
            {
                this.FillData();
            }
        }



        /// <summary>
        /// LoadByEmployeeTypeStartDateEndDateCountryIdEmployeeIdProjectTimeState
        /// </summary>
        /// <returns>Data</returns>
        /// <param name="employeeType">employeeType</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="countryId">countryId</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="projectTimeState">projectTimeState</param>
        public void LoadByEmployeeTypeStartDateEndDateCountryIdEmployeeIdProjectTimeState(string employeeType, DateTime startDate, DateTime endDate, Int64 countryId, int employeeId, string projectTimeState, bool isNewReport, string personnelAgency)
        {
            PrintHoursForPayrollPeriodOriginalGateway originalGateway = new PrintHoursForPayrollPeriodOriginalGateway(Data);
            originalGateway.LoadByEmployeeTypeStartDateEndDateCountryIdEmployeeIdProjectTimeState(employeeType, startDate, endDate, countryId, employeeId, projectTimeState, personnelAgency);

            if (isNewReport)
            {
                this.FillData2();
            }
            else
            {
                this.FillData();
            }
        }



        /// <summary>
        /// LoadByEmployeeTypeStartDateEndDateCountryIdEmployeeIdProjectTimeStateClientId
        /// </summary>
        /// <param name="employeeType">employeeType</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="countryId">countryId</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="projectTimeState">projectTimeState</param>
        /// <param name="clientId">clientId</param>
        public void LoadByEmployeeTypeStartDateEndDateCountryIdEmployeeIdProjectTimeStateClientId(string employeeType, DateTime startDate, DateTime endDate, Int64 countryId, int employeeId, string projectTimeState, int clientId, bool isNewReport, string personnelAgency)
        {
            PrintHoursForPayrollPeriodOriginalGateway originalGateway = new PrintHoursForPayrollPeriodOriginalGateway(Data);
            originalGateway.LoadByEmployeeTypeStartDateEndDateCountryIdEmployeeIdProjectTimeStateClientId(employeeType, startDate, endDate, countryId, employeeId, projectTimeState, clientId, personnelAgency);

            if (isNewReport)
            {
                this.FillData2();
            }
            else
            {
                this.FillData();
            }
        }



        /// <summary>
        /// LoadByEmployeeTypeStartDateEndDateCountryIdEmployeeIdProjectTimeStateClientIdProjectId
        /// </summary>
        /// <param name="employeeType">employeeType</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="countryId">countryId</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="projectTimeState">projectTimeState</param>
        /// <param name="clientId">clientId</param>
        /// <param name="projectId">projectId</param>
        public void LoadByEmployeeTypeStartDateEndDateCountryIdEmployeeIdProjectTimeStateClientIdProjectId(string employeeType, DateTime startDate, DateTime endDate, Int64 countryId, int employeeId, string projectTimeState, int clientId, int projectId, bool isNewReport, string personnelAgency)
        {
            PrintHoursForPayrollPeriodOriginalGateway originalGateway = new PrintHoursForPayrollPeriodOriginalGateway(Data);
            originalGateway.LoadByEmployeeTypeStartDateEndDateCountryIdEmployeeIdProjectTimeStateClientIdProjectId(employeeType, startDate, endDate, countryId, employeeId, projectTimeState, clientId, projectId, personnelAgency);

            if (isNewReport)
            {
                this.FillData2();
            }
            else
            {
                this.FillData();
            }
        }
        


        /// <summary>
        /// LoadBySalariedStartDateEndDateEmployeeIdProjectTimeState
        /// </summary>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="projectTimeState">projectTimeState</param>
        public void LoadBySalariedStartDateEndDateEmployeeIdProjectTimeState(DateTime startDate, DateTime endDate, int employeeId, string projectTimeState, bool isNewReport)
        {
            PrintHoursForPayrollPeriodOriginalGateway originalGateway = new PrintHoursForPayrollPeriodOriginalGateway(Data);
            originalGateway.LoadBySalariedStartDateEndDateEmployeeIdProjectTimeState(startDate, endDate, employeeId, projectTimeState);

            if (isNewReport)
            {
                this.FillData2();
            }
            else
            {
                this.FillData();
            }
        }



        /// <summary>
        /// LoadBySalariedStartDateEndDateEmployeeIdProjectTimeStateClientId
        /// </summary>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="projectTimeState">projectTimeState</param>
        /// <param name="clientId">clientId</param>
        public void LoadBySalariedStartDateEndDateEmployeeIdProjectTimeStateClientId(DateTime startDate, DateTime endDate, int employeeId, string projectTimeState, int clientId, bool isNewReport)
        {
            PrintHoursForPayrollPeriodOriginalGateway originalGateway = new PrintHoursForPayrollPeriodOriginalGateway(Data);
            originalGateway.LoadBySalariedStartDateEndDateEmployeeIdProjectTimeStateClientId(startDate, endDate, employeeId, projectTimeState, clientId);

            if (isNewReport)
            {
                this.FillData2();
            }
            else
            {
                this.FillData();
            }
        }



        /// <summary>
        /// LoadBySalariedStartDateEndDateEmployeeIdProjectTimeStateClientIdProjectId
        /// </summary>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="projectTimeState">projectTimeState</param>
        /// <param name="clientId">clientId</param>
        /// <param name="projectId">projectId</param>
        public void LoadBySalariedStartDateEndDateEmployeeIdProjectTimeStateClientIdProjectId(DateTime startDate, DateTime endDate, int employeeId, string projectTimeState, int clientId, int projectId, bool isNewReport)
        {
            PrintHoursForPayrollPeriodOriginalGateway originalGateway = new PrintHoursForPayrollPeriodOriginalGateway(Data);
            originalGateway.LoadBySalariedStartDateEndDateEmployeeIdProjectTimeStateClientIdProjectId(startDate, endDate, employeeId, projectTimeState, clientId, projectId);

            if (isNewReport)
            {
                this.FillData2();
            }
            else
            {
                this.FillData();
            }
        }



        /// <summary>
        /// LoadBySalariedStartDateEndDateCountryIdEmployeeIdProjectTimeState
        /// </summary>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="countryId">countryId</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="projectTimeState">projectTimeState</param>
        public void LoadBySalariedStartDateEndDateCountryIdEmployeeIdProjectTimeState(DateTime startDate, DateTime endDate, Int64 countryId, int employeeId, string projectTimeState, bool isNewReport)
        {
            PrintHoursForPayrollPeriodOriginalGateway originalGateway = new PrintHoursForPayrollPeriodOriginalGateway(Data);
            originalGateway.LoadBySalariedStartDateEndDateCountryIdEmployeeIdProjectTimeState(startDate, endDate, countryId, employeeId, projectTimeState);

            if (isNewReport)
            {
                this.FillData2();
            }
            else
            {
                this.FillData();
            }
        }



        /// <summary>
        /// LoadBySalariedStartDateEndDateCountryIdEmployeeIdProjectTimeStateClientId
        /// </summary>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="countryId">countryId</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="projectTimeState">projectTimeState</param>
        /// <param name="clientId">clientId</param>
        public void LoadBySalariedStartDateEndDateCountryIdEmployeeIdProjectTimeStateClientId(DateTime startDate, DateTime endDate, Int64 countryId, int employeeId, string projectTimeState, int clientId, bool isNewReport)
        {
            PrintHoursForPayrollPeriodOriginalGateway originalGateway = new PrintHoursForPayrollPeriodOriginalGateway(Data);
            originalGateway.LoadBySalariedStartDateEndDateCountryIdEmployeeIdProjectTimeStateClientId(startDate, endDate, countryId, employeeId, projectTimeState, clientId);

            if (isNewReport)
            {
                this.FillData2();
            }
            else
            {
                this.FillData();
            }
        }



        /// <summary>
        /// LoadBySalariedStartDateEndDateCountryIdEmployeeIdProjectTimeStateClientIdProjectId
        /// </summary>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="countryId">countryId</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="projectTimeState">projectTimeState</param>
        /// <param name="clientId">clientId</param>
        /// <param name="projectId">projectId</param>
        public void LoadBySalariedStartDateEndDateCountryIdEmployeeIdProjectTimeStateClientIdProjectId(DateTime startDate, DateTime endDate, Int64 countryId, int employeeId, string projectTimeState, int clientId, int projectId, bool isNewReport)
        {
            PrintHoursForPayrollPeriodOriginalGateway originalGateway = new PrintHoursForPayrollPeriodOriginalGateway(Data);
            originalGateway.LoadBySalariedStartDateEndDateCountryIdEmployeeIdProjectTimeStateClientIdProjectId(startDate, endDate, countryId, employeeId, projectTimeState, clientId, projectId);

            if (isNewReport)
            {
                this.FillData2();
            }
            else
            {
                this.FillData();
            }
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



        /// <summary>
        /// FillData
        /// </summary>
        private void FillData()
        {
            PrintHoursForPayrollPeriodOriginalGateway originalGateway = new PrintHoursForPayrollPeriodOriginalGateway(Data);

            foreach (PrintHoursForPayrollPeriodTDS.OriginalRow originalRow in (PrintHoursForPayrollPeriodTDS.OriginalDataTable)originalGateway.Table)
            {
                PrintHoursForPayrollPeriodTDS.PrintHoursForPayrollPeriodRow newRow = ((PrintHoursForPayrollPeriodTDS.PrintHoursForPayrollPeriodDataTable)Table).NewPrintHoursForPayrollPeriodRow();

                newRow.EmployeeID = originalRow.EmployeeID;
                newRow.EmployeeName = originalRow.EmployeeName;
                newRow.CountryID = originalRow.CountryID;
                newRow.CountryName = originalRow.CountryName;
                newRow.Date_ = originalRow.Date_;
                newRow.ProjectName = originalRow.ProjectName;
                if (!originalRow.IsWork_Null()) newRow.Work_ = originalRow.Work_; else newRow.SetWork_Null();
                if (!originalRow.IsFunction_Null()) newRow.Function_ = originalRow.Function_; else newRow.SetFunction_Null();
                if (!originalRow.IsStartTimeNull()) newRow.StartTime = originalRow.StartTime; else newRow.SetStartTimeNull();
                if (!originalRow.IsEndTimeNull()) newRow.EndTime = originalRow.EndTime; else newRow.SetEndTimeNull();
                if (!originalRow.IsOffsetNull()) newRow.Offset = originalRow.Offset; else newRow.SetOffsetNull();
                if (!originalRow.IsFairWageNull()) newRow.FairWage = originalRow.FairWage; else newRow.FairWage = false;

                if (originalRow.CountryID == 1)
                {
                    newRow.TimeCA = originalRow.ProjectTime;
                    newRow.TimeUS = 0;
                }
                else
                {
                    newRow.TimeCA = 0;
                    newRow.TimeUS = originalRow.ProjectTime;
                }

                if ((originalRow.WorkingDetails == "Sick Day") || (originalRow.WorkingDetails == "Holiday") || (originalRow.WorkingDetails == "Vacation / Other") || (originalRow.WorkingDetails == "Day Off - No Pay"))
                {
                    newRow.WorkingDetails = originalRow.WorkingDetails;
                }
                else
                {
                    newRow.WorkingDetails = "";
                }

                newRow.ClientName = originalRow.ClientName;
                newRow.Location = originalRow.Location;

                if (!originalRow.IsMealsCountryNull())
                {
                    if (originalRow.MealsCountry == 1)
                    {
                        newRow.MealsCA = true;
                        newRow.MealsUS = false;
                    }
                    else
                    {
                        newRow.MealsCA = false;
                        newRow.MealsUS = true;
                    }
                }
                else
                {
                    newRow.MealsCA = false;
                    newRow.MealsUS = false;
                }

                if (!originalRow.IsMealsCountryNull())
                {
                    if (originalRow.MealsCountry == 1)
                    {
                        newRow.TotalCA = originalRow.MealsAllowance;
                        newRow.TotalUS = 0;
                    }
                    else
                    {
                        newRow.TotalCA = 0;
                        newRow.TotalUS = originalRow.MealsAllowance;
                    }
                }
                else
                {
                    newRow.TotalCA = 0;
                    newRow.TotalUS = 0;
                }

                if (!originalRow.IsProjectTimeStateNull())
                {
                    if (originalRow.ProjectTimeState == "Approved")
                    {
                        newRow.IsApproved = true;
                    }
                    else
                    {
                        newRow.IsApproved = false;
                    }
                }
                else
                {
                    newRow.IsApproved = false;
                }

                if (!originalRow.IsApprovedByNull())
                {
                    newRow.ApprovedBy = originalRow.ApprovedBy;
                }
                else
                {
                    newRow.ApprovedBy = "";
                }

                if (!originalRow.IsProjectTimeStateNull())
                {
                    newRow.ProjectTimeState = originalRow.ProjectTimeState;
                }
                else
                {
                    newRow.ProjectTimeState = "New";
                }

                if (!originalRow.IsCommentsNull()) newRow.Comments = originalRow.Comments; else newRow.SetCommentsNull();

                newRow.TimeFairWage = 0;
                newRow.TimeFairWageOt = 0;
                newRow.TimeMob = 0;
                newRow.TimeMobOt = 0;
                newRow.TimeStandard = 0;
                newRow.TimeStandardOt = 0;

                ((PrintHoursForPayrollPeriodTDS.PrintHoursForPayrollPeriodDataTable)Table).AddPrintHoursForPayrollPeriodRow(newRow);
            }
        }

        

        /// <summary>
        /// FillData2
        /// </summary>
        private void FillData2()
        {
            PrintHoursForPayrollPeriodOriginalGateway originalGateway = new PrintHoursForPayrollPeriodOriginalGateway(Data);

            foreach (PrintHoursForPayrollPeriodTDS.OriginalRow originalRow in (PrintHoursForPayrollPeriodTDS.OriginalDataTable)originalGateway.Table)
            {
                PrintHoursForPayrollPeriodTDS.PrintHoursForPayrollPeriodRow newRow = ((PrintHoursForPayrollPeriodTDS.PrintHoursForPayrollPeriodDataTable)Table).NewPrintHoursForPayrollPeriodRow();

                newRow.EmployeeID = originalRow.EmployeeID;
                newRow.EmployeeName = originalRow.EmployeeName;
                newRow.CountryID = originalRow.CountryID;
                newRow.CountryName = originalRow.CountryName;
                newRow.Date_ = originalRow.Date_;
                newRow.ProjectName = originalRow.ProjectName;
                if (!originalRow.IsWork_Null()) newRow.Work_ = originalRow.Work_; else newRow.SetWork_Null();
                if (!originalRow.IsFunction_Null()) newRow.Function_ = originalRow.Function_; else newRow.SetFunction_Null();
                if (!originalRow.IsStartTimeNull()) newRow.StartTime = originalRow.StartTime; else newRow.SetStartTimeNull();
                if (!originalRow.IsEndTimeNull()) newRow.EndTime = originalRow.EndTime; else newRow.SetEndTimeNull();
                if (!originalRow.IsOffsetNull()) newRow.Offset = originalRow.Offset; else newRow.SetOffsetNull();
                newRow.FairWage = false;
                originalRow.FairWage = false;

                if (!originalRow.IsJobClassTypeNull()) newRow.JobClassType = originalRow.JobClassType; else newRow.JobClassType = " ";
                
                if (originalRow.CountryID == 1)
                {
                    newRow.TimeCA = originalRow.ProjectTime;
                    newRow.TimeUS = originalRow.ProjectTime;
                }
                else
                {
                    newRow.TimeCA = originalRow.ProjectTime;
                    newRow.TimeUS = originalRow.ProjectTime;
                }

                newRow.TimeFairWage = 0;
                newRow.TimeFairWageOt = 0;
                newRow.TimeMob = 0;
                newRow.TimeMobOt = 0;
                newRow.TimeStandard = 0;
                newRow.TimeStandardOt = 0;

                if (!originalRow.IsStartTimeNull() && !originalRow.IsEndTimeNull())
                {
                    if (originalRow.IsWork_Null()) originalRow.Work_ = "";
                    if (originalRow.IsFunction_Null()) originalRow.Function_ = "";
                    ProjectGateway projectGateway = new ProjectGateway(null);
                    ProjectTimeGateway projectTimeGateway = new ProjectTimeGateway();
                    projectTimeGateway.LoadByProjectTimeId(originalRow.ProjectTimeID);
                    if (projectGateway.IsFairWageProjectWorkFunction(projectTimeGateway.GetProjectId(originalRow.ProjectTimeID), originalRow.Work_, originalRow.Function_))
                    {
                        newRow.FairWage = true;
                        originalRow.FairWage = true;
                    }

                    int overtime = 40; //Default for USA

                    // Canada
                    if (originalRow.CountryID == 1)
                    {
                        switch (originalRow.Category)
                        {
                            case "Special Forces":
                                overtime = 50;
                                break;

                            case "Field":
                                overtime = 50;
                                break;

                            case "Field 44":
                                overtime = 44;
                                break;

                            case "Office/Admin":
                                overtime = 44;
                                break;

                            case "Mechanic/Manufactoring":
                                overtime = 44;
                                break;
                        }

                        if ((originalRow.Work_ == "Mobilization") && (originalRow.Function_ == "Prevail/Min Wage"))
                        {
                            double acumPeriod = GetTotalHoursByEmployeeIdPeriodId(originalRow.EmployeeID, originalRow.Date_, originalRow.ProjectTimeID);

                            if (acumPeriod > overtime)
                            {
                                newRow.TimeMob = 0;
                                newRow.TimeMobOt = originalRow.ProjectTime;
                            }
                            else
                            {
                                double newAcumPeriod = acumPeriod + originalRow.ProjectTime;

                                if (newAcumPeriod > overtime)
                                {
                                    newRow.TimeMobOt = newAcumPeriod - overtime;
                                    newRow.TimeMob = originalRow.ProjectTime - newRow.TimeMobOt;
                                }
                                else
                                {
                                    newRow.TimeMob = originalRow.ProjectTime;
                                    newRow.TimeMobOt = 0;
                                }
                            }
                        }
                        else
                        {
                            if ((originalRow.FairWage) && (originalRow.Work_ != "Mobilization"))
                            {
                                double acumPeriod = GetTotalHoursByEmployeeIdPeriodId(originalRow.EmployeeID, originalRow.Date_, originalRow.ProjectTimeID);

                                if (acumPeriod > overtime)
                                {
                                    newRow.TimeFairWage = 0;
                                    newRow.TimeFairWageOt = originalRow.ProjectTime;
                                }
                                else
                                {
                                    double newAcumPeriod = acumPeriod + originalRow.ProjectTime;

                                    if (newAcumPeriod > overtime)
                                    {
                                        newRow.TimeFairWageOt = newAcumPeriod - overtime;
                                        newRow.TimeFairWage = originalRow.ProjectTime - newRow.TimeFairWageOt;
                                    }
                                    else
                                    {
                                        newRow.TimeFairWage = originalRow.ProjectTime;
                                        newRow.TimeFairWageOt = 0;
                                    }
                                }
                            }
                            else
                            {
                                double acumPeriod = GetTotalHoursByEmployeeIdPeriodId(originalRow.EmployeeID, originalRow.Date_, originalRow.ProjectTimeID);

                                if (acumPeriod > overtime)
                                {
                                    newRow.TimeStandard = 0;
                                    newRow.TimeStandardOt = originalRow.ProjectTime;
                                }
                                else
                                {
                                    double newAcumPeriod = acumPeriod + originalRow.ProjectTime;

                                    if (newAcumPeriod > overtime)
                                    {
                                        newRow.TimeStandardOt = newAcumPeriod - overtime;
                                        newRow.TimeStandard = originalRow.ProjectTime - newRow.TimeStandardOt;
                                    }
                                    else
                                    {
                                        newRow.TimeStandard = originalRow.ProjectTime;
                                        newRow.TimeStandardOt = 0;
                                    }
                                }
                            }
                        }
                    }
                    else //USA
                    {
                        if ((originalRow.FairWage) && (originalRow.Work_ != "Mobilization"))
                        {
                            double acumPeriod = GetTotalHoursByEmployeeIdPeriodId(originalRow.EmployeeID, originalRow.Date_, originalRow.ProjectTimeID);

                            if (acumPeriod > overtime)
                            {
                                newRow.TimeFairWage = 0;
                                newRow.TimeFairWageOt = originalRow.ProjectTime;
                            }
                            else
                            {
                                double newAcumPeriod = acumPeriod + originalRow.ProjectTime;

                                if (newAcumPeriod > overtime)
                                {
                                    newRow.TimeFairWageOt = newAcumPeriod - overtime;
                                    newRow.TimeFairWage = originalRow.ProjectTime - newRow.TimeFairWageOt;
                                }
                                else
                                {
                                    newRow.TimeFairWage = originalRow.ProjectTime;
                                    newRow.TimeFairWageOt = 0;
                                }
                            }
                        }
                        else
                        {
                            double acumPeriod = GetTotalHoursByEmployeeIdPeriodId(originalRow.EmployeeID, originalRow.Date_, originalRow.ProjectTimeID);

                            if (acumPeriod > overtime)
                            {
                                newRow.TimeStandard = 0;
                                newRow.TimeStandardOt = originalRow.ProjectTime;
                            }
                            else
                            {
                                double newAcumPeriod = acumPeriod + originalRow.ProjectTime;

                                if (newAcumPeriod > overtime)
                                {
                                    newRow.TimeStandardOt = newAcumPeriod - overtime;
                                    newRow.TimeStandard = originalRow.ProjectTime - newRow.TimeStandardOt;
                                }
                                else
                                {
                                    newRow.TimeStandard = originalRow.ProjectTime;
                                    newRow.TimeStandardOt = 0;
                                }
                            }
                        }
                    }
                }

                if ((originalRow.WorkingDetails == "Sick Day") || (originalRow.WorkingDetails == "Holiday") || (originalRow.WorkingDetails == "Vacation / Other") || (originalRow.WorkingDetails == "Day Off - No Pay"))
                {
                    newRow.WorkingDetails = originalRow.WorkingDetails;
                }
                else
                {
                    newRow.WorkingDetails = "";
                }
                
                newRow.ClientName = originalRow.ClientName;
                newRow.Location = originalRow.Location;
                
                if (!originalRow.IsMealsCountryNull())
                {
                    if (originalRow.MealsCountry == 1)
                    {
                        newRow.MealsCA = true;
                        newRow.MealsUS = false;
                    }
                    else
                    {
                        newRow.MealsCA = false;
                        newRow.MealsUS = true;
                    }
                }
                else
                {
                    newRow.MealsCA = false;
                    newRow.MealsUS = false;
                }
                
                if (!originalRow.IsMealsCountryNull())
                {
                    if (originalRow.MealsCountry == 1)
                    {
                        newRow.TotalCA = originalRow.MealsAllowance;
                        newRow.TotalUS = 0;
                    }
                    else
                    {
                        newRow.TotalCA = 0;
                        newRow.TotalUS = originalRow.MealsAllowance;
                    }
                }
                else
                {
                    newRow.TotalCA = 0;
                    newRow.TotalUS = 0;
                }

                if (!originalRow.IsProjectTimeStateNull())
                {
                    if (originalRow.ProjectTimeState == "Approved")
                    {
                        newRow.IsApproved = true;
                    }
                    else
                    {
                        newRow.IsApproved = false;
                    }
                }
                else
                {
                    newRow.IsApproved = false;
                }

                if (!originalRow.IsApprovedByNull())
                {
                    newRow.ApprovedBy = originalRow.ApprovedBy;
                }
                else
                {
                    newRow.ApprovedBy = "";
                }

                if (!originalRow.IsProjectTimeStateNull())
                {
                    string projectTimeState = originalRow.ProjectTimeState;

                    if (projectTimeState == "Approved")
                    {
                        newRow.ProjectTimeState = originalRow.ApprovedBy;
                    }
                    else
                    {
                        newRow.ProjectTimeState = "--";
                    }
                }
                else
                {
                    newRow.ProjectTimeState = "--";
                }

                if (!originalRow.IsJobClassProjectTimeNull())
                {
                    string jobClassProjectTime = originalRow.JobClassProjectTime;

                    switch (jobClassProjectTime)
                    {
                        case "Laborer Group 2":
                            originalRow.JobClassProjectTime = "Lab 2";
                            break;

                        case "Laborer Group 6":
                            originalRow.JobClassProjectTime = "Lab 6";
                            break;

                        case "Operator Group 1":
                            originalRow.JobClassProjectTime = "Op 1";
                            break;

                        case "Operator Group 2":
                            originalRow.JobClassProjectTime = "Op 2";
                            break;

                        case "Regular Rate":
                            originalRow.JobClassProjectTime = "Reg Rate";
                            break;
                    }
                }

                // Show or not Job Class Project Time
                if (!originalRow.IsWork_Null())
                {
                    if (originalRow.Work_ != "Mobilization")
                    {
                        if (!originalRow.IsJobClassProjectTimeNull())
                        {
                            newRow.JobClassProjectTime = originalRow.JobClassProjectTime;
                        }
                        else
                        {
                            newRow.JobClassProjectTime = "";
                        }
                    }
                    else
                    {
                        newRow.JobClassProjectTime = "";
                    }
                }
                else
                {
                    if (!originalRow.IsJobClassProjectTimeNull())
                    {
                        newRow.JobClassProjectTime = originalRow.JobClassProjectTime;
                    }
                    else
                    {
                        newRow.JobClassProjectTime = "";
                    }
                }

                if (!originalRow.IsCommentsNull()) newRow.Comments = originalRow.Comments; else newRow.SetCommentsNull();
                
                ((PrintHoursForPayrollPeriodTDS.PrintHoursForPayrollPeriodDataTable)Table).AddPrintHoursForPayrollPeriodRow(newRow);
            }
        }




        public void LoadByEmployeeTypeStartDateEndDateEmployeeIdProjectTimeStateClientIdProjectIdIncludeAllHours(string employeeType, DateTime startDate, DateTime endDate, int employeeId, string projectTimeState, int clientId, int projectId, bool isNewReport)
        {
            PrintHoursForPayrollPeriodOriginalGateway originalGateway = new PrintHoursForPayrollPeriodOriginalGateway(Data);
            originalGateway.LoadByEmployeeTypeStartDateEndDateEmployeeIdProjectTimeStateClientIdProjectIdIncludeAllHours(employeeType, startDate, endDate, employeeId, projectTimeState, clientId, projectId);

            if (isNewReport)
            {
                this.FillData2();
            }
            else
            {
                this.FillData();
            }
        }

        public void LoadBySalariedStartDateEndDateEmployeeIdProjectTimeStateClientIdProjectIdIncludeAllHours(DateTime startDate, DateTime endDate, int employeeId, string projectTimeState, int clientId, int projectId, bool isNewReport)
        {
            PrintHoursForPayrollPeriodOriginalGateway originalGateway = new PrintHoursForPayrollPeriodOriginalGateway(Data);
            originalGateway.LoadBySalariedStartDateEndDateEmployeeIdProjectTimeStateClientIdProjectIdIncludeAllHours(startDate, endDate, employeeId, projectTimeState, clientId, projectId);

            if (isNewReport)
            {
                this.FillData2();
            }
            else
            {
                this.FillData();
            }
        }

        public void LoadByEmployeeTypeStartDateEndDateCountryIdEmployeeIdProjectTimeStateClientIdProjectIdIncludeAllHours(string employeeType, DateTime startDate, DateTime endDate, int countryId, int employeeId, string projectTimeState, int clientId, int projectId, bool isNewReport)
        {
            PrintHoursForPayrollPeriodOriginalGateway originalGateway = new PrintHoursForPayrollPeriodOriginalGateway(Data);
            originalGateway.LoadByEmployeeTypeStartDateEndDateCountryIdEmployeeIdProjectTimeStateClientIdProjectIdIncludeAllHours(employeeType, startDate, endDate, countryId, employeeId, projectTimeState, clientId, projectId);

            if (isNewReport)
            {
                this.FillData2();
            }
            else
            {
                this.FillData();
            }
        }

        public void LoadBySalariedStartDateEndDateCountryIdEmployeeIdProjectTimeStateClientIdProjectIdIncludeAllHours(DateTime startDate, DateTime endDate, int countryId, int employeeId, string projectTimeState, int clientId, int projectId, bool isNewReport)
        {
            PrintHoursForPayrollPeriodOriginalGateway originalGateway = new PrintHoursForPayrollPeriodOriginalGateway(Data);
            originalGateway.LoadBySalariedStartDateEndDateCountryIdEmployeeIdProjectTimeStateClientIdProjectIdIncludeAllHours(startDate, endDate, countryId, employeeId, projectTimeState, clientId, projectId);

            if (isNewReport)
            {
                this.FillData2();
            }
            else
            {
                this.FillData();
            }
        }



    }
}