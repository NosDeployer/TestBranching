using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Units;
using LiquiForce.LFSLive.DA.LabourHours.ProjectTime;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.LabourHours.ProjectTime
{
    /// <summary>
    /// Models the logic for PrintProjectCosting report
    /// </summary>
    public class PrintProjectCosting : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public PrintProjectCosting()
            : base("PrintProjectCosting")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public PrintProjectCosting(DataSet data)
            : base(data, "PrintProjectCosting")
        {
        }



        /// <summary>
        /// InitAdapter
        /// </summary>
        protected override void InitData()
        {
            _data = new PrintProjectCostingTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS 
        //
        
        /// <summary>
        /// LoadByStartDateEndDateProjectTimeState
        /// </summary>
        /// <para>Load Original to process data for Project Costing report with filters</para>
        /// <param name="startDate">Start date filter for Project Costing report</param>
        /// <param name="endDate">End date filter for Project Costing report</param>
        /// <param name="projectTimeState">State filter for Project Costing report</param>
        /// <param name="companyId">companyId</param>
        public void LoadByStartDateEndDateProjectTimeState(DateTime startDate, DateTime endDate, string projectTimeState, int companyId)
        {
            PrintProjectCostingGateway printProjectCostingGateway = new PrintProjectCostingGateway(Data);
            printProjectCostingGateway.LoadByStartDateEndDateProjectTimeState(startDate, endDate, projectTimeState);
            this.ProcessDataForProject(companyId);
        }



        /// <summary>
        /// LoadByStartDateEndDateProjectTimeStateWork
        /// </summary>
        /// <para>Load Original to process data for Project Costing report with filters</para>
        /// <param name="startDate">Start date filter for Project Costing report</param>
        /// <param name="endDate">End date filter for Project Costing report</param>
        /// <param name="projectTimeState">State filter for Project Costing report</param>
        /// <param name="work">work</param>
        /// <param name="companyId">companyId</param>
        public void LoadByStartDateEndDateProjectTimeStateWork(DateTime startDate, DateTime endDate, string projectTimeState, string work, int companyId)
        {
            PrintProjectCostingGateway printProjectCostingGateway = new PrintProjectCostingGateway(Data);
            printProjectCostingGateway.LoadByStartDateEndDateProjectTimeStateWork(startDate, endDate, projectTimeState, work);
            this.ProcessDataForProject(companyId);
        }


        
        /// <summary>
        /// LoadByStartDateEndDateProjectTimeStateWorkFunction
        /// </summary>
        /// <para>Load Original to process data for Project Costing report with filters</para>
        /// <param name="startDate">Start date filter for Project Costing report</param>
        /// <param name="endDate">End date filter for Project Costing report</param>
        /// <param name="projectTimeState">State filter for Project Costing report</param>
        /// <param name="work">work</param>
        /// <param name="companyId">companyId</param>
        public void LoadByStartDateEndDateProjectTimeStateWorkFunction(DateTime startDate, DateTime endDate, string projectTimeState, string work, string function, int companyId)
        {
            PrintProjectCostingGateway printProjectCostingGateway = new PrintProjectCostingGateway(Data);
            printProjectCostingGateway.LoadByStartDateEndDateProjectTimeStateWorkFunction(startDate, endDate, projectTimeState, work, function);
            this.ProcessDataForProject(companyId);
        }



        /// <summary>
        /// LoadByCompaniesIdStartDateEndDateProjectTimeState
        /// </summary>
        /// <para>Load Original to process data for Project Costing report with filters</para>
        /// <param name="companiesId">Company filter (client) for project Costing report</param>
        /// <param name="startDate">Start date filter for Project Costing report</param>
        /// <param name="endDate">End date filter for Project Costing report</param>
        /// <param name="projectTimeState">State filter for Project Costing report</param>
        /// <param name="companyId">companyId</param>
        public void LoadByCompaniesIdStartDateEndDateProjectTimeState(int companiesId, DateTime startDate, DateTime endDate, string projectTimeState, int companyId)
        {
            PrintProjectCostingGateway printProjectCostingGateway = new PrintProjectCostingGateway(Data);
            printProjectCostingGateway.LoadByCompaniesIdStartDateEndDateProjectTimeState(companiesId, startDate, endDate, projectTimeState);
            this.ProcessDataForProject(companyId);
        }


        
        /// <summary>
        /// LoadByCompaniesIdStartDateEndDateProjectTimeStateWork
        /// </summary>
        /// <para>Load Original to process data for Project Costing report with filters</para>
        /// <param name="companiesId">Company filter (client) for project Costing report</param>
        /// <param name="startDate">Start date filter for Project Costing report</param>
        /// <param name="endDate">End date filter for Project Costing report</param>
        /// <param name="projectTimeState">State filter for Project Costing report</param>
        /// <param name="work">work</param>
        /// <param name="companyId">companyId</param>
        public void LoadByCompaniesIdStartDateEndDateProjectTimeStateWork(int companiesId, DateTime startDate, DateTime endDate, string projectTimeState, string work, int companyId)
        {
            PrintProjectCostingGateway printProjectCostingGateway = new PrintProjectCostingGateway(Data);
            printProjectCostingGateway.LoadByCompaniesIdStartDateEndDateProjectTimeStateWork(companiesId, startDate, endDate, projectTimeState, work);
            this.ProcessDataForProject(companyId);
        }



        /// <summary>
        /// LoadByCompaniesIdStartDateEndDateProjectTimeStateWorkFunction
        /// </summary>
        /// <para>Load Original to process data for Project Costing report with filters</para>
        /// <param name="companiesId">Company filter (client) for project Costing report</param>
        /// <param name="startDate">Start date filter for Project Costing report</param>
        /// <param name="endDate">End date filter for Project Costing report</param>
        /// <param name="projectTimeState">State filter for Project Costing report</param>
        /// <param name="work">work</param>
        /// <param name="function">function</param>
        /// <param name="companyId">companyId</param>
        public void LoadByCompaniesIdStartDateEndDateProjectTimeStateWorkFunction(int companiesId, DateTime startDate, DateTime endDate, string projectTimeState, string work, string function, int companyId)
        {
            PrintProjectCostingGateway printProjectCostingGateway = new PrintProjectCostingGateway(Data);
            printProjectCostingGateway.LoadByCompaniesIdStartDateEndDateProjectTimeStateWorkFunction(companiesId, startDate, endDate, projectTimeState, work, function);
            this.ProcessDataForProject(companyId);
        }



        /// <summary>
        /// LoadByCompaniesIdProjectIdStartDateEndDateProjectTimeState
        /// </summary>
        /// <para>Load Original to process data for Project Costing report with filters</para> 
        /// <param name="companiesId">Company filter (client) for Project Costing report</param>
        /// <param name="projectId">Project filter for Project Costing reports</param>
        /// <param name="startDate">Start date filter Project Costing report</param>
        /// <param name="endDate">End date filter for Project Costing report</param>
        /// <param name="projectTimeState">State filter for Project Costing report</param>
        /// <param name="companyId">companyId</param>
        public void LoadByCompaniesIdProjectIdStartDateEndDateProjectTimeState(int companiesId, int projectId, DateTime startDate, DateTime endDate, string projectTimeState, int companyId)
        {
            PrintProjectCostingGateway printProjectCostingGateway = new PrintProjectCostingGateway(Data);
            printProjectCostingGateway.LoadByCompaniesIdProjectIdStartDateEndDateProjectTimeState(companiesId, projectId, startDate, endDate, projectTimeState);
            this.ProcessDataForProject(companyId);
        }



        /// <summary>
        /// LoadByCompaniesIdProjectIdStartDateEndDateProjectTimeStateWork
        /// </summary>
        /// <para>Load Original to process data for Project Costing report with filters</para> 
        /// <param name="companiesId">Company filter (client) for Project Costing report</param>
        /// <param name="projectId">Project filter for Project Costing reports</param>
        /// <param name="startDate">Start date filter Project Costing report</param>
        /// <param name="endDate">End date filter for Project Costing report</param>
        /// <param name="projectTimeState">State filter for Project Costing report</param>
        /// <param name="work">work</param>
        /// <param name="companyId">companyId</param>
        public void LoadByCompaniesIdProjectIdStartDateEndDateProjectTimeStateWork(int companiesId, int projectId, DateTime startDate, DateTime endDate, string projectTimeState, string work, int companyId)
        {
            PrintProjectCostingGateway printProjectCostingGateway = new PrintProjectCostingGateway(Data);
            printProjectCostingGateway.LoadByCompaniesIdProjectIdStartDateEndDateProjectTimeStateWork(companiesId, projectId, startDate, endDate, projectTimeState, work);
            this.ProcessDataForProject(companyId);
        }



        /// <summary>
        /// LoadByCompaniesIdProjectIdStartDateEndDateProjectTimeStateWorkFunction
        /// </summary>
        /// <para>Load Original to process data for Project Costing report with filters</para> 
        /// <param name="companiesId">Company filter (client) for Project Costing report</param>
        /// <param name="projectId">Project filter for Project Costing reports</param>
        /// <param name="startDate">Start date filter Project Costing report</param>
        /// <param name="endDate">End date filter for Project Costing report</param>
        /// <param name="projectTimeState">State filter for Project Costing report</param>
        /// <param name="work">work</param>
        /// <param name="function">function</param>
        /// <param name="companyId">companyId</param>
        public void LoadByCompaniesIdProjectIdStartDateEndDateProjectTimeStateWorkFunction(int companiesId, int projectId, DateTime startDate, DateTime endDate, string projectTimeState, string work, string function, int companyId)
        {
            PrintProjectCostingGateway printProjectCostingGateway = new PrintProjectCostingGateway(Data);
            printProjectCostingGateway.LoadByCompaniesIdProjectIdStartDateEndDateProjectTimeStateWorkFunction(companiesId, projectId, startDate, endDate, projectTimeState, work, function);
            this.ProcessDataForProject(companyId);
        }



        /// <summary>
        /// ProcessDataForProject
        /// </summary>
        /// <para>Process de data from the original table for the Project Costing report</para>
        /// <param name="companyId">companyId</param>
        public void ProcessDataForProject(int companyId)
        {            
            // Instanciate a new PrintProjectCostingGateway for the control of times that one unit is used in different projects
            PrintProjectCostingGateway verifGateway = new PrintProjectCostingGateway(new DataSet());
            
            // Fill rows from original data
            PrintProjectCostingGateway originalGateway = new PrintProjectCostingGateway(Data);
            foreach (PrintProjectCostingTDS.OriginalRow originalRow in (PrintProjectCostingTDS.OriginalDataTable)originalGateway.Table)
            {
                PrintProjectCostingTDS.PrintProjectCostingRow newRow = ((PrintProjectCostingTDS.PrintProjectCostingDataTable)Table).NewPrintProjectCostingRow();
                newRow.ClientID = originalRow.ClientID;
                newRow.ClientName = originalRow.ClientName;
                newRow.ProjectName = originalRow.ProjectName;
                newRow.CountryID = originalRow.CountryID;
                newRow.CountryName = originalRow.CountryName;
                newRow.EmployeeID = originalRow.EmployeeID;
                newRow.EmployeeName = originalRow.EmployeeName;
                newRow.Date_ = originalRow.Date_;
                if (!originalRow.IsWork_Null()) newRow.Work_ = originalRow.Work_; else newRow.SetWork_Null();
                if (!originalRow.IsFunction_Null()) newRow.Function_ = originalRow.Function_; else newRow.SetFunction_Null();
                if (!originalRow.IsFairWageNull()) newRow.FairWage = originalRow.FairWage; else newRow.FairWage = false;
                if (!originalRow.IsUnitNull()) newRow.Unit = originalRow.Unit; else newRow.SetUnitNull();
                if (!originalRow.IsTowedNull()) newRow.Towed = originalRow.Towed; else newRow.SetTowedNull();

                // ...Stablishing the country of the project
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

                // ...Stablishing the type of labour day: Sick Day, Holiday, Vacation or Normal work day
                if ((originalRow.WorkingDetails == "Sick Day") || (originalRow.WorkingDetails == "Holiday") || (originalRow.WorkingDetails == "Vacation / Other") || (originalRow.WorkingDetails == "Day Off - No Pay"))
                {
                    newRow.WorkingDetails = originalRow.WorkingDetails;
                }
                else
                {
                    newRow.WorkingDetails = "";
                }

                // ...Stablishing the total and the meals, depending on the MealsCountry defined: Canada or United States
                if (!originalRow.IsMealsCountryNull())
                {
                    if (originalRow.MealsCountry == 1)
                    {
                        newRow.MealsCA = true;
                        newRow.MealsUS = false;
                        newRow.TotalCA = originalRow.MealsAllowance;
                        newRow.TotalUS = 0;
                    }
                    else
                    {
                        newRow.MealsCA = false;
                        newRow.MealsUS = true;
                        newRow.TotalCA = 0;
                        newRow.TotalUS = originalRow.MealsAllowance;
                    }
                }
                else
                {
                    newRow.MealsCA = false;
                    newRow.MealsUS = false;
                    newRow.TotalCA = 0;
                    newRow.TotalUS = 0;
                }

                // ...Verifing if there is a comment or not
                if (!originalRow.IsCommentsNull())
                {
                    newRow.Comments = originalRow.Comments;
                }

                // ...Definition of project time state
                if (!originalRow.IsProjectTimeStateNull())
                {
                    newRow.ProjectTimeState = originalRow.ProjectTimeState;
                }
                else
                {
                    newRow.ProjectTimeState = "For Approval";
                }
                                                 
                // ...Definition of variables that will help in the calculation of the cost column at the report
                decimal valCostUnit = 0.00M;
                decimal valCostTowedUnit = 0.00M;

                int amountProjectsTowedVerified = 0;
                int amountFunctionTowedVerified = 0;
                int amountProjectsUnitVerified = 0;
                int amountFunctionUnitVerified = 0;
                decimal? dailyRateTowed = 0M;
                decimal? dailyRateUnit = 0M;

                if (!originalRow.IsTowedUnitIDNull())
                {
                    amountProjectsTowedVerified = verifGateway.TowedUnitSameDayUseSeveralProjects(originalRow.Date_, originalRow.TowedUnitID);
                    amountFunctionTowedVerified = verifGateway.TowedUnitSameDayUseSeveralWorkFunctions(originalRow.ProjectID, originalRow.Date_, originalRow.TowedUnitID);
                    dailyRateTowed = GetUnitDailyRate(originalRow.Date_, originalRow.Date_, originalRow.TowedUnitID, originalRow.Work_, originalRow.ProjectID, originalRow.CountryID);
                }
                
                if (!originalRow.IsUnitIDNull())
                {
                    amountProjectsUnitVerified = verifGateway.UnitSameDayUseSeveralProjects(originalRow.Date_, originalRow.UnitID);
                    amountFunctionUnitVerified = verifGateway.UnitSameDayUseSeveralWorkFunctions(originalRow.ProjectID, originalRow.Date_, originalRow.UnitID);
                    dailyRateUnit = GetUnitDailyRate(originalRow.Date_, originalRow.Date_, originalRow.UnitID, originalRow.Work_, originalRow.ProjectID, originalRow.CountryID);
                }

                // ...If only a unit was used
                if (!originalRow.IsUnitIDNull() && originalRow.IsTowedUnitIDNull())
                {
                    valCostTowedUnit = 0.00M;
                    if (UnitAlreadyProcessedInProjectWork_Function_(originalRow.ProjectName, originalRow.Date_, originalRow.UnitID, originalRow.Unit, companyId, originalRow.Work_, originalRow.Function_))
                    {
                        valCostUnit = 0.00M;
                    }
                    else
                    {
                        decimal? dailyRate = null; if (GetUnitDailyRate(originalRow.Date_, originalRow.Date_, originalRow.UnitID, originalRow.Work_, originalRow.ProjectID, originalRow.CountryID).HasValue) dailyRate = GetUnitDailyRate(originalRow.Date_, originalRow.Date_, originalRow.UnitID, originalRow.Work_, originalRow.ProjectID, originalRow.CountryID).Value;
                        if (amountProjectsUnitVerified > 1)
                        {
                            if (dailyRate.HasValue)
                            {
                                valCostUnit = Decimal.Round(dailyRate.Value / amountProjectsUnitVerified, 2);

                                if (amountFunctionUnitVerified > 0)
                                {
                                    valCostUnit = Decimal.Round(valCostUnit / amountFunctionUnitVerified, 2);
                                }
                            }
                            else
                            {
                                valCostUnit = 0.00M;
                            }
                        }
                        else
                        {
                            if (dailyRate.HasValue)
                            {
                                if (amountFunctionUnitVerified > 0)
                                {
                                    valCostUnit = Decimal.Round(dailyRate.Value / amountFunctionUnitVerified, 2);
                                }
                                else
                                {
                                    valCostUnit = dailyRate.Value;
                                }
                            }
                            else
                            {
                                valCostTowedUnit = 0.00M;
                            }
                        }
                    }
                }

                // ...If only a towed unit was used
                if (!originalRow.IsTowedUnitIDNull() && originalRow.IsUnitIDNull())
                {
                    valCostUnit = 0.00M;
                    if (TowedUnitAlreadyProcessedInProjectWork_Function_(originalRow.ProjectName, originalRow.Date_, originalRow.TowedUnitID, originalRow.Towed, companyId, originalRow.Work_, originalRow.Function_))
                    {
                        valCostTowedUnit = 0.00M;
                    }
                    else
                    {                                                
                        if (amountProjectsTowedVerified > 1)
                        {
                            if (dailyRateTowed.HasValue)
                            {
                                valCostTowedUnit = Decimal.Round(dailyRateTowed.Value / amountProjectsTowedVerified, 2);
                                                                 
                                 if (amountFunctionTowedVerified > 0)
                                 {
                                     valCostTowedUnit = Decimal.Round(valCostTowedUnit / amountFunctionTowedVerified, 2);
                                 }
                            }
                            else
                            {
                                valCostTowedUnit = 0.00M;
                            }
                        }
                        else
                        {
                            if (dailyRateTowed.HasValue)
                            {
                                if (amountFunctionTowedVerified > 0)
                                {
                                    valCostTowedUnit = Decimal.Round(dailyRateTowed.Value / amountFunctionTowedVerified, 2);
                                }
                                else
                                {
                                    valCostTowedUnit = dailyRateTowed.Value;
                                }
                            }
                            else
                            {
                                valCostTowedUnit = 0.00M;
                            }
                        }
                    }
                }

                // ...If towed unit and a unit were used
                if (!originalRow.IsTowedUnitIDNull() && !originalRow.IsUnitIDNull())
                {
                    if (UnitAlreadyProcessedInProjectWork_Function_(originalRow.ProjectName, originalRow.Date_, originalRow.UnitID, originalRow.Unit, companyId, originalRow.Work_, originalRow.Function_))
                    {
                        valCostUnit = 0.00M;
                    }
                    else
                    {
                        if (amountProjectsUnitVerified > 1)
                        {
                            if (dailyRateUnit.HasValue)
                            {
                                valCostUnit = Decimal.Round(dailyRateUnit.Value / amountProjectsUnitVerified, 2);

                                if (amountFunctionUnitVerified > 0)
                                {
                                    valCostUnit = Decimal.Round(valCostUnit / amountFunctionUnitVerified, 2);
                                }
                            }
                            else
                            {
                                valCostUnit = 0.00M;
                            }
                        }
                        else
                        {
                            if (dailyRateUnit.HasValue)
                            {
                                if (amountFunctionUnitVerified > 0)
                                {
                                    valCostUnit = Decimal.Round(dailyRateUnit.Value / amountFunctionUnitVerified, 2);
                                }
                                else
                                {
                                    valCostUnit = dailyRateUnit.Value;
                                }
                            }
                            else
                            {
                                valCostTowedUnit = 0.00M;
                            }
                        }
                    }

                    if (TowedUnitAlreadyProcessedInProjectWork_Function_(originalRow.ProjectName, originalRow.Date_, originalRow.TowedUnitID, originalRow.Towed, companyId, originalRow.Work_, originalRow.Function_))
                    {
                        valCostTowedUnit = 0.00M;
                    }
                    else
                    {                                                                                              
                        if (amountProjectsTowedVerified > 1)
                        {
                            if (dailyRateTowed.HasValue)
                            {
                                valCostTowedUnit = Decimal.Round(dailyRateTowed.Value / amountProjectsTowedVerified, 2);
                                                                
                                if (amountFunctionTowedVerified > 0)
                                {
                                    valCostTowedUnit = Decimal.Round(valCostTowedUnit / amountFunctionTowedVerified, 2);
                                }
                            }
                            else
                            {
                                valCostTowedUnit = 0.00M;
                            }
                        }
                        else
                        {
                            if (dailyRateTowed.HasValue)
                            {                                
                                if (amountFunctionTowedVerified > 0)
                                {
                                    valCostTowedUnit = Decimal.Round(dailyRateTowed.Value / amountFunctionTowedVerified, 2);
                                }
                                else
                                {
                                    valCostTowedUnit = dailyRateTowed.Value;
                                }
                            }
                            else
                            {
                                valCostTowedUnit = 0.00M;
                            }
                        }
                    }
                }

                // ...Summary of Unit and Towed cost
                if (!originalRow.IsUnitIDNull())
                {
                    if (!originalRow.IsTowedUnitIDNull())
                    {
                        newRow.EquipmentCost = valCostUnit + valCostTowedUnit;
                    }
                    else
                    {
                        newRow.EquipmentCost = valCostUnit;
                    }
                }
                else
                {
                    if (!originalRow.IsTowedUnitIDNull())
                    {
                        newRow.EquipmentCost = valCostTowedUnit;
                    }
                    else
                    {
                        newRow.EquipmentCost = 0.00M;
                    }
                }
                ((PrintProjectCostingTDS.PrintProjectCostingDataTable)Table).AddPrintProjectCostingRow(newRow);
            }
        }



        /// <summary>
        /// UnitAlreadyProcessedInProject
        /// </summary>
        /// <para>Process de data to validate if the unit was already used in the project </para>  
        /// <param name="localProjectName">Project Name filter to select the used units</param>
        /// <param name="localDateOfUse">Date filter to select the used units</param>
        /// <param name="localUnitID">Unit ID of the unit to be verified</param>
        /// <param name="unit">unit</param>
        /// <param name="companyId">companyId</param>
        /// <param name="work_">work_</param>
        /// <param name="function_">function_</param>        
        /// <returns>If the unit was used before returns TRUE</returns> 
        public bool UnitAlreadyProcessedInProjectWork_Function_(string localProjectName, DateTime localDateOfUse, int localUnitID, string unit, int companyId, string work_, string function_)
        {
            bool unitExists = false;           
            
            //Looking for a unit that was used already
            foreach (PrintProjectCostingTDS.PrintProjectCostingRow validateRow in (PrintProjectCostingTDS.PrintProjectCostingDataTable)this.Table)
            {
                if (!validateRow.IsUnitNull())
                {
                    if ((String.Equals(validateRow.ProjectName, localProjectName)) && (validateRow.Date_ == localDateOfUse) && (validateRow.Unit == unit) && (validateRow.Work_ == work_) && (validateRow.Function_ == function_))
                    {
                        unitExists = true;
                    }
                }
            }

            return unitExists;    
        }



        /// <summary>
        /// TowedUnitAlreadyProcessedInProjectWork_Function_
        /// </summary>
        /// <para>Process de data to validate if the towed unit was already used in the project </para>  
        /// <param name="localProjectName">Project Name filter to select the used units</param>
        /// <param name="localDateOfUse">Date filter to select the used units</param>
        /// <param name="localTowedUnitID">Towed unit ID of the unit to be verified</param>
        /// <param name="towed">towed</param>
        /// <param name="companyId">companyId</param>
        /// <param name="work_">work_</param>
        /// <param name="function_">function_</param>
        /// <returns>If the towed unit was used before returns TRUE</returns> 
        public bool TowedUnitAlreadyProcessedInProjectWork_Function_(string localProjectName, DateTime localDateOfUse, int localTowedUnitID, string towed, int companyId, string work_, string function_)
        {
            bool unitExists = false;  

            //Searching the towed units thar are used already
            foreach (PrintProjectCostingTDS.PrintProjectCostingRow validateRow in (PrintProjectCostingTDS.PrintProjectCostingDataTable)this.Table)
            {
                if (!validateRow.IsTowedNull())
                {
                    if ((String.Equals(validateRow.ProjectName, localProjectName)) && (validateRow.Date_ == localDateOfUse) && (validateRow.Towed == towed) && (validateRow.Work_ == work_) && (validateRow.Function_ == function_))
                    {
                        unitExists = true;
                    }
                }
            }

            return unitExists; 
        }

        

        /// <summary>
        /// GetUnitDailyRate
        /// </summary>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="unitId">unitId</param>
        /// <param name="work_">work_</param>
        /// <param name="projectId">projectId</param>
        /// <param name="countryId">countryId</param>
        /// <returns></returns>
        private decimal? GetUnitDailyRate(DateTime startDate, DateTime endDate, int unitId, string work_, int projectId, Int64 countryId)
        {
            decimal? dailyRate = null;

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
           
            if (countryId == 1) //Canada
            {
                decimal? costCad = projectCostingSheetAddUnitListGateway.GetCostCad(unitId);
                if (costCad.HasValue)
                {
                    dailyRate = costCad;
                }
            }
            else
            {
                decimal? costUsd =projectCostingSheetAddUnitListGateway.GetCostUsd(unitId);
                if (costUsd.HasValue)
                {
                    dailyRate = costUsd;
                }
            }

            return dailyRate;
        }



        /// <summary>
        /// UnitSameDayUseSeveralWorkFunctions
        /// </summary>
        /// <param name="date">date</param>
        /// <param name="unitId">unitId</param>
        /// <returns></returns>
        private int UnitSameDayUseSeveralWorkFunctions(DateTime date, int unitId)
        {
            int amount = 0;
            PrintProjectCostingGateway verifGateway = new PrintProjectCostingGateway(new DataSet());
            verifGateway.UnitSameDayUseSeveralProjects(date, unitId);
            amount = verifGateway.Table.Rows.Count;

            return amount;
        }
        


    }
}