using System;
using System.Data;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Units;

namespace LiquiForce.LFSLive.DA.LabourHours.ProjectTime
{
    /// <summary>
    /// PrintHoursForProjectGateway
    /// </summary>
    public class PrintHoursForProjectGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //
        
        /// <summary>
        /// Default constructor
        /// </summary>
        public PrintHoursForProjectGateway()
            : base("PrintHoursForProject")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public PrintHoursForProjectGateway(DataSet data)
            : base(data, "PrintHoursForProject")
        {
        }



        /// <summary>
        /// InitData. Create a PrintHoursForPayrollPeriodTDS dataset
        /// </summary>
        protected override void InitData()
        {
            _data = new PrintHoursForProjectTDS();
        }


        /// <summary>
        /// InitAdapter (empty)
        /// </summary>
        protected override void InitAdapter()
        {
        }






        // ////////////////////////////////////////////////////////////////////////
        // METHODS - DATASET
        //

        /// <summary>
        /// Load project times for Print Hours For Project report without filters
        /// </summary>
        /// <param name="companyId">companyId</param>
        public void Load(int companyId)
        {
            PrintHoursForProjectOriginalGateway printHoursForProjectOriginalGateway = new PrintHoursForProjectOriginalGateway(Data);
            printHoursForProjectOriginalGateway.Load();

            this.FillData(companyId);
        }



        /// <summary>
        /// Load project times for Print Hours For Project report with filters
        /// </summary>
        /// <param name="startDate">Start date filter for project times</param>
        /// <param name="endDate">End date filter for project times</param>
        /// <param name="projectTimeState">State filter for project times</param>
        /// <returns>Dataset with original data table loaded</returns>
        /// <param name="companyId">companyId</param>
        public void LoadByStartDateEndDateProjectTimeState(DateTime startDate, DateTime endDate, string projectTimeState, int companyId)
        {
            PrintHoursForProjectOriginalGateway printHoursForProjectOriginalGateway = new PrintHoursForProjectOriginalGateway(Data);
            printHoursForProjectOriginalGateway.LoadByStartDateEndDateProjectTimeState(startDate, endDate, projectTimeState);

            this.FillData(companyId);
        }



        /// <summary>
        /// Load project times for Print Hours For Project report with filters
        /// </summary>
        /// <param name="startDate">Start date filter for project times</param>
        /// <param name="endDate">End date filter for project times</param>
        /// <param name="projectTimeState">State filter for project times</param>
        /// <returns>Dataset with original data table loaded</returns>
        /// <param name="teamMemberType">TeamMemberType</param>
        /// <param name="companyId">companyId</param>
        public void LoadByStartDateEndDateProjectTimeStateTeamMemberType(DateTime startDate, DateTime endDate, string projectTimeState, string teamMemberType, int companyId)
        {
            PrintHoursForProjectOriginalGateway printHoursForProjectOriginalGateway = new PrintHoursForProjectOriginalGateway(Data);
            printHoursForProjectOriginalGateway.LoadByStartDateEndDateProjectTimeStateTeamMemberType(startDate, endDate, projectTimeState, teamMemberType);

            this.FillData(companyId);
        }



        /// <summary>
        /// Load project times for Print Hours For Project report with filters
        /// </summary>
        /// <param name="companiesId">Companies filter (client) for project times</param>
        /// <param name="startDate">Start date filter for project times</param>
        /// <param name="endDate">End date filter for project times</param>
        /// <param name="projectTimeState">State filter for project times</param>
        /// <returns>Dataset with original data table loaded</returns>
        public void LoadByCompaniesIdStartDateEndDateProjectTimeState(int companiesId, DateTime startDate, DateTime endDate, string projectTimeState, int companyId)
        {
            PrintHoursForProjectOriginalGateway printHoursForProjectOriginalGateway = new PrintHoursForProjectOriginalGateway(Data);
            printHoursForProjectOriginalGateway.LoadByCompaniesIdStartDateEndDateProjectTimeState(companiesId, startDate, endDate, projectTimeState);

            this.FillData(companyId);
        }



        /// <summary>
        /// Load project times for Print Hours For Project report with filters
        /// </summary>
        /// <param name="companiesId">Companies filter (client) for project times</param>
        /// <param name="startDate">Start date filter for project times</param>
        /// <param name="endDate">End date filter for project times</param>
        /// <param name="projectTimeState">State filter for project times</param>
        /// <param name="teamMemberType">teamMemberType</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Dataset with original data table loaded</returns>
        public void LoadByCompaniesIdStartDateEndDateProjectTimeStateTeamMemberType(int companiesId, DateTime startDate, DateTime endDate, string projectTimeState, string teamMemberType, int companyId)
        {
            PrintHoursForProjectOriginalGateway printHoursForProjectOriginalGateway = new PrintHoursForProjectOriginalGateway(Data);
            printHoursForProjectOriginalGateway.LoadByCompaniesIdStartDateEndDateProjectTimeStateTeamMemberType(companiesId, startDate, endDate, projectTimeState, teamMemberType);

            this.FillData(companyId);
        }



        /// <summary>
        /// Load project times for Print Hours For Project report with filters
        /// </summary>
        /// <param name="companiesId">Company filter (client) for project times</param>
        /// <param name="projectId">Project filter for project times</param>
        /// <param name="startDate">Start date filter for project times</param>
        /// <param name="endDate">End date filter for project times</param>
        /// <param name="projectTimeState">State filter for project times</param>
        /// <returns>Dataset with original data table loaded</returns>
        /// <param name="companyId">companyId</param>
        public void LoadByCompaniesIdProjectIdStartDateEndDateProjectTimeState(int companiesId, int projectId, DateTime startDate, DateTime endDate, string projectTimeState, int companyId)
        {
            PrintHoursForProjectOriginalGateway printHoursForProjectOriginalGateway = new PrintHoursForProjectOriginalGateway(Data);
            printHoursForProjectOriginalGateway.LoadByCompaniesIdProjectIdStartDateEndDateProjectTimeState(companiesId,projectId, startDate, endDate, projectTimeState);

            this.FillData(companyId);
        }



        /// <summary>
        /// Load project times for Print Hours For Project report with filters
        /// </summary>
        /// <param name="companiesId">Company filter (client) for project times</param>
        /// <param name="projectId">Project filter for project times</param>
        /// <param name="startDate">Start date filter for project times</param>
        /// <param name="endDate">End date filter for project times</param>
        /// <param name="projectTimeState">State filter for project times</param>
        /// <returns>Dataset with original data table loaded</returns>
        /// <param name="teamMemberType">TeamMemberType</param>
        /// <param name="companyId">companyId</param>
        public void LoadByCompaniesIdProjectIdStartDateEndDateProjectTimeStateTeamMemberType(int companiesId, int projectId, DateTime startDate, DateTime endDate, string projectTimeState, string teamMemberType, int companyId)
        {
            PrintHoursForProjectOriginalGateway printHoursForProjectOriginalGateway = new PrintHoursForProjectOriginalGateway(Data);
            printHoursForProjectOriginalGateway.LoadByCompaniesIdProjectIdStartDateEndDateProjectTimeStateTeamMemberType(companiesId, projectId, startDate, endDate, projectTimeState, teamMemberType);

            this.FillData(companyId);
        }



        /// <summary>
        /// Fills data with rows loaded from PrintHoursForProjectsGateway
        /// </summary>
        /// <param name="companyId">companyId</param>
        public void FillData(int companyId)
        {
            // Fill rows from original data
            PrintHoursForProjectOriginalGateway originalGateway = new PrintHoursForProjectOriginalGateway(Data);
            foreach (PrintHoursForProjectTDS.OriginalRow originalRow in (PrintHoursForProjectTDS.OriginalDataTable)originalGateway.Table)
            {
                PrintHoursForProjectTDS.PrintHoursForProjectRow newRow = ((PrintHoursForProjectTDS.PrintHoursForProjectDataTable)Table).NewPrintHoursForProjectRow();

                newRow.ClientID = originalRow.ClientID;
                newRow.ClientName = originalRow.ClientName;
                newRow.ProjectName = originalRow.ProjectName;
                newRow.CountryID = originalRow.CountryID;
                newRow.CountryName = originalRow.CountryName;
                newRow.EmployeeID = originalRow.EmployeeID;
                newRow.EmployeeName = originalRow.EmployeeName;
                newRow.Type = originalRow.Type;
                newRow.Date_ = originalRow.Date_;
                
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
                
                if ((originalRow.WorkingDetails == "Sick Day") || (originalRow.WorkingDetails == "Holiday") || (originalRow.WorkingDetails == "Vacation / Other"))
                {
                    newRow.WorkingDetails = originalRow.WorkingDetails;
                }
                else
                {
                    newRow.WorkingDetails = "";
                }
                
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

                if (!originalRow.IsCommentsNull())
                {
                    newRow.Comments = originalRow.Comments;
                }

                if (!originalRow.IsUnitIDNull())
                {
                    UnitInformationUnitDetailsGateway unitInformationUnitDetailsGatewayForUnit = new UnitInformationUnitDetailsGateway();
                    unitInformationUnitDetailsGatewayForUnit.LoadAllByUnitId(originalRow.UnitID, companyId);

                    newRow.Unit = unitInformationUnitDetailsGatewayForUnit.GetUnitCode(originalRow.UnitID);
                }

                if (!originalRow.IsProjectTimeStateNull())
                {
                    newRow.ProjectTimeState = originalRow.ProjectTimeState;
                }
                else
                {
                    newRow.ProjectTimeState = "New";
                }

                if (!originalRow.IsTowedUnitIDNull())
                {
                    UnitInformationUnitDetailsGateway unitInformationUnitDetailsGatewayForTowedUnit = new UnitInformationUnitDetailsGateway();
                    unitInformationUnitDetailsGatewayForTowedUnit.LoadAllByUnitId(originalRow.TowedUnitID, companyId);

                    newRow.Towed = unitInformationUnitDetailsGatewayForTowedUnit.GetUnitCode(originalRow.TowedUnitID);
                }

                ((PrintHoursForProjectTDS.PrintHoursForProjectDataTable)Table).AddPrintHoursForProjectRow(newRow);
            }
        }



    }
}
