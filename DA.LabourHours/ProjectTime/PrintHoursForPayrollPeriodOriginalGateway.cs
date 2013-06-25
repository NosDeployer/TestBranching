using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.LabourHours.ProjectTime
{
    /// <summary>
    /// PrintHoursForPayrollPeriodOriginalGateway
    /// </summary>
    public class PrintHoursForPayrollPeriodOriginalGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public PrintHoursForPayrollPeriodOriginalGateway()
            : base("Original")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public PrintHoursForPayrollPeriodOriginalGateway(DataSet data)
            : base(data, "Original")
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
            #region Adapter initialization

            this._adapter = new System.Data.SqlClient.SqlDataAdapter();
            System.Data.Common.DataTableMapping tableMapping = new System.Data.Common.DataTableMapping();
            tableMapping.SourceTable = "Table";
            tableMapping.DataSetTable = "Original";
            tableMapping.ColumnMappings.Add("EmployeeID", "EmployeeID");
            tableMapping.ColumnMappings.Add("EmployeeName", "EmployeeName");
            tableMapping.ColumnMappings.Add("CountryID", "CountryID");
            tableMapping.ColumnMappings.Add("CountryName", "CountryName");
            tableMapping.ColumnMappings.Add("Date_", "Date_");
            tableMapping.ColumnMappings.Add("StartTime", "StartTime");
            tableMapping.ColumnMappings.Add("EndTime", "EndTime");
            tableMapping.ColumnMappings.Add("Offset", "Offset");
            tableMapping.ColumnMappings.Add("ProjectTime", "ProjectTime");
            tableMapping.ColumnMappings.Add("WorkingDetails", "WorkingDetails");
            tableMapping.ColumnMappings.Add("ClientName", "ClientName");
            tableMapping.ColumnMappings.Add("Location", "Location");
            tableMapping.ColumnMappings.Add("MealsCountry", "MealsCountry");
            tableMapping.ColumnMappings.Add("MealsAllowance", "MealsAllowance");
            tableMapping.ColumnMappings.Add("Comments", "Comments");
            tableMapping.ColumnMappings.Add("ProjectName", "ProjectName");
            tableMapping.ColumnMappings.Add("ApprovedBy", "ApprovedBy");
            tableMapping.ColumnMappings.Add("ProjectTimeState", "ProjectTimeState");
            tableMapping.ColumnMappings.Add("Work_", "Work_");
            tableMapping.ColumnMappings.Add("Function_", "Function_");
            tableMapping.ColumnMappings.Add("FairWage", "FairWage");
            tableMapping.ColumnMappings.Add("ProjectTimeID", "ProjectTimeID");
            tableMapping.ColumnMappings.Add("JobClassType", "JobClassType");
            tableMapping.ColumnMappings.Add("Category", "Category");
            tableMapping.ColumnMappings.Add("JobClassProjectTime", "JobClassProjectTime");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            #endregion
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
        /// <returns>DataSet</returns>
        public DataSet LoadByEmployeeTypeStartDateEndDateEmployeeIdProjectTimeState(string employeeType, DateTime startDate, DateTime endDate, int employeeId, string projectTimeState, string personnelAgency)
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_PRINTHOURSFORPAYROLLPERIODORIGINALGATEWAY_LOADBYEMPLOYEETYPESTARTDATEENDDATEEMPLOYEEIDPROJECTTIMESTATE", new SqlParameter("@employeeType", employeeType), new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate), new SqlParameter("@employeeId", employeeId), new SqlParameter("@projectTimeState", projectTimeState), new SqlParameter("@personnelAgency", personnelAgency));
            return Data;
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
        /// <returns>DataSet</returns>
        public DataSet LoadByEmployeeTypeStartDateEndDateEmployeeIdProjectTimeStateClientId(string employeeType, DateTime startDate, DateTime endDate, int employeeId, string projectTimeState, int clientId, string personnelAgency)
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_PRINTHOURSFORPAYROLLPERIODORIGINALGATEWAY_LOADBYEMPLOYEETYPESTARTDATEENDDATEEMPLOYEEIDPROJECTTIMESTATECLIENTID", new SqlParameter("@employeeType", employeeType), new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate), new SqlParameter("@employeeId", employeeId), new SqlParameter("@projectTimeState", projectTimeState), new SqlParameter("@clientId", clientId), new SqlParameter("@personnelAgency", personnelAgency));
            return Data;
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
        /// <returns>DataSet</returns>
        public DataSet LoadByEmployeeTypeStartDateEndDateEmployeeIdProjectTimeStateClientIdProjectId(string employeeType, DateTime startDate, DateTime endDate, int employeeId, string projectTimeState, int clientId, int projectId, string personnelAgency)
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_PRINTHOURSFORPAYROLLPERIODORIGINALGATEWAY_LOADBYEMPLOYEETYPESTARTDATEENDDATEEMPLOYEEIDPROJECTTIMESTATECLIENTPROJ", new SqlParameter("@employeeType", employeeType), new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate), new SqlParameter("@employeeId", employeeId), new SqlParameter("@projectTimeState", projectTimeState), new SqlParameter("@clientId", clientId), new SqlParameter("@projectId", projectId), new SqlParameter("@personnelAgency", personnelAgency));
            return Data;
        }



        /// <summary>
        /// LoadByEmployeeTypeStartDateEndDateCountryIdEmployeeIdProjectTimeState
        /// </summary>
        /// <param name="employeeType">employeeType</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="countryId">countryId</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="projectTimeState">projectTimeState</param>
        /// <returns>DataSet</returns>
        public DataSet LoadByEmployeeTypeStartDateEndDateCountryIdEmployeeIdProjectTimeState(string employeeType, DateTime startDate, DateTime endDate, Int64 countryId, int employeeId, string projectTimeState, string personnelAgency)
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_PRINTHOURSFORPAYROLLPERIODORIGINALGATEWAY_LOADBYEMPLOYEETYPESTARTDATEENDDATECOUNTRYIDEMPLOYEEIDPROJECTTIMESTATE", new SqlParameter("@employeeType", employeeType), new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate), new SqlParameter("@countryId", countryId), new SqlParameter("employeeId", employeeId), new SqlParameter("@projectTimeState", projectTimeState), new SqlParameter("@personnelAgency", personnelAgency));
            return Data;
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
        /// <returns>DataSet</returns>
        public DataSet LoadByEmployeeTypeStartDateEndDateCountryIdEmployeeIdProjectTimeStateClientId(string employeeType, DateTime startDate, DateTime endDate, Int64 countryId, int employeeId, string projectTimeState, int clientId, string personnelAgency)
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_PRINTHOURSFORPAYROLLPERIODGATEWAY_LOADBYEMPLOYEETYPESTARTDATEENDDATECOUNTRYIDEMPLOYEEIDPROJECTTIMESTATECLIENTID", new SqlParameter("@employeeType", employeeType), new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate), new SqlParameter("@countryId", countryId), new SqlParameter("employeeId", employeeId), new SqlParameter("@projectTimeState", projectTimeState), new SqlParameter("@clientId", clientId), new SqlParameter("@personnelAgency", personnelAgency));
            return Data;
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
        /// <returns>DataSet</returns>
        public DataSet LoadByEmployeeTypeStartDateEndDateCountryIdEmployeeIdProjectTimeStateClientIdProjectId(string employeeType, DateTime startDate, DateTime endDate, Int64 countryId, int employeeId, string projectTimeState, int clientId, int projectId, string personnelAgency)
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_PRINTHOURSFORPAYROLLPERIODGATEWAY_LOADBYEMPLOYEETYPESTARTDATEENDDATECOUNTRYIDEMPLOYEEIDPROJECTTIMESTATECLIENTPRO", new SqlParameter("@employeeType", employeeType), new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate), new SqlParameter("@countryId", countryId), new SqlParameter("employeeId", employeeId), new SqlParameter("@projectTimeState", projectTimeState), new SqlParameter("@clientId", clientId), new SqlParameter("@projectId", projectId), new SqlParameter("@personnelAgency", personnelAgency));
            return Data;
        }
        


        /// <summary>
        /// LoadBySalariedStartDateEndDateEmployeeIdProjectTimeState
        /// </summary>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="projectTimeState">projectTimeState</param>
        /// <returns>DataSet</returns>
        public DataSet LoadBySalariedStartDateEndDateEmployeeIdProjectTimeState(DateTime startDate, DateTime endDate, int employeeId, string projectTimeState)
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_PRINTHOURSFORPAYROLLPERIODORIGINALGATEWAY_LOADBYSALARIEDSTARTDATEENDDATEEMPLOYEEIDPROJECTTIMESTATE", new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate), new SqlParameter("@employeeId", employeeId), new SqlParameter("@projectTimeState", projectTimeState));
            return Data;
        }



        /// <summary>
        /// LoadBySalariedStartDateEndDateEmployeeIdProjectTimeStateClientId
        /// </summary>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="projectTimeState">projectTimeState</param>
        /// <param name="clientId">clientId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadBySalariedStartDateEndDateEmployeeIdProjectTimeStateClientId(DateTime startDate, DateTime endDate, int employeeId, string projectTimeState, int clientId)
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_PRINTHOURSFORPAYROLLPERIODORIGINALGATEWAY_LOADBYSALARIEDSTARTDATEENDDATEEMPLOYEEIDPROJECTTIMESTATECLIENTID", new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate), new SqlParameter("@employeeId", employeeId), new SqlParameter("@projectTimeState", projectTimeState), new SqlParameter("@clientId", clientId));
            return Data;
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
        /// <returns>DataSet</returns>
        public DataSet LoadBySalariedStartDateEndDateEmployeeIdProjectTimeStateClientIdProjectId(DateTime startDate, DateTime endDate, int employeeId, string projectTimeState, int clientId, int projectId)
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_PRINTHOURSFORPAYROLLPERIODORIGINALGATEWAY_LOADBYSALARIEDSTARTDATEENDDATEEMPLOYEEIDPROJECTTIMESTATECLIENTIDPROJEC", new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate), new SqlParameter("@employeeId", employeeId), new SqlParameter("@projectTimeState", projectTimeState), new SqlParameter("@clientId", clientId), new SqlParameter("@projectId", projectId));
            return Data;
        }



        /// <summary>
        /// LoadBySalariedStartDateEndDateCountryIdEmployeeIdProjectTimeState
        /// </summary>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="countryId">countryId</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="projectTimeState">projectTimeState</param>
        /// <returns>DataSet</returns>
        public DataSet LoadBySalariedStartDateEndDateCountryIdEmployeeIdProjectTimeState(DateTime startDate, DateTime endDate, Int64 countryId, int employeeId, string projectTimeState)
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_PRINTHOURSFORPAYROLLPERIODORIGINALGATEWAY_LOADBYSALARIEDSTARTDATEENDDATECOUNTRYIDEMPLOYEEIDPROJECTTIMESTATE", new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate), new SqlParameter("@countryId", countryId), new SqlParameter("employeeId", employeeId), new SqlParameter("@projectTimeState", projectTimeState));
            return Data;
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
        /// <returns>DataSet</returns>
        public DataSet LoadBySalariedStartDateEndDateCountryIdEmployeeIdProjectTimeStateClientId(DateTime startDate, DateTime endDate, Int64 countryId, int employeeId, string projectTimeState, int clientId)
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_PRINTHOURSFORPAYROLLPERIODGATEWAY_LOADBYSALARIEDSTARTDATEENDDATECOUNTRYIDEMPLOYEEIDPROJECTTIMESTATECLIENTID", new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate), new SqlParameter("@countryId", countryId), new SqlParameter("employeeId", employeeId), new SqlParameter("@projectTimeState", projectTimeState), new SqlParameter("@clientId", clientId));
            return Data;
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
        /// <returns>DataSet</returns>
        public DataSet LoadBySalariedStartDateEndDateCountryIdEmployeeIdProjectTimeStateClientIdProjectId(DateTime startDate, DateTime endDate, Int64 countryId, int employeeId, string projectTimeState, int clientId, int projectId)
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_PRINTHOURSFORPAYROLLPERIODGATEWAY_LOADBYSALARIEDSTARTDATEENDDATECOUNTRYIDEMPLOYEEIDPROJECTTIMESTATECLIENTPROJECT", new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate), new SqlParameter("@countryId", countryId), new SqlParameter("employeeId", employeeId), new SqlParameter("@projectTimeState", projectTimeState), new SqlParameter("@clientId", clientId), new SqlParameter("@projectId", projectId));
            return Data;
        }




        public DataSet LoadByEmployeeTypeStartDateEndDateEmployeeIdProjectTimeStateClientIdProjectIdIncludeAllHours(string employeeType, DateTime startDate, DateTime endDate, int employeeId, string projectTimeState, int clientId, int projectId)
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_PRINTHOURSFORPAYROLLPERIODORIGINALGATEWAY_LOADBYEMPLOYEETYPESTARTDATEENDDATEEMPLOYEEIDPROJECTTIMESTATECLIENTPRO2", new SqlParameter("@employeeType", employeeType), new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate), new SqlParameter("@employeeId", employeeId), new SqlParameter("@projectTimeState", projectTimeState), new SqlParameter("@clientId", clientId), new SqlParameter("@projectId", projectId));
            return Data;
        }

        public DataSet LoadBySalariedStartDateEndDateEmployeeIdProjectTimeStateClientIdProjectIdIncludeAllHours(DateTime startDate, DateTime endDate, int employeeId, string projectTimeState, int clientId, int projectId)
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_PRINTHOURSFORPAYROLLPERIODORIGINALGATEWAY_LOADBYSALARIEDSTARTDATEENDDATEEMPLOYEEIDPROJECTTIMESTATECLIENTIDPROJE2", new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate), new SqlParameter("@employeeId", employeeId), new SqlParameter("@projectTimeState", projectTimeState), new SqlParameter("@clientId", clientId), new SqlParameter("@projectId", projectId));
            return Data;
        }

        public DataSet LoadByEmployeeTypeStartDateEndDateCountryIdEmployeeIdProjectTimeStateClientIdProjectIdIncludeAllHours(string employeeType, DateTime startDate, DateTime endDate, int countryId, int employeeId, string projectTimeState, int clientId, int projectId)
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_PRINTHOURSFORPAYROLLPERIODGATEWAY_LOADBYEMPLOYEETYPESTARTDATEENDDATECOUNTRYIDEMPLOYEEIDPROJECTTIMESTATECLIENTPR2", new SqlParameter("@employeeType", employeeType), new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate), new SqlParameter("@countryId", countryId), new SqlParameter("employeeId", employeeId), new SqlParameter("@projectTimeState", projectTimeState), new SqlParameter("@clientId", clientId), new SqlParameter("@projectId", projectId));
            return Data;
        }

        public DataSet LoadBySalariedStartDateEndDateCountryIdEmployeeIdProjectTimeStateClientIdProjectIdIncludeAllHours(DateTime startDate, DateTime endDate, int countryId, int employeeId, string projectTimeState, int clientId, int projectId)
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_PRINTHOURSFORPAYROLLPERIODGATEWAY_LOADBYSALARIEDSTARTDATEENDDATECOUNTRYIDEMPLOYEEIDPROJECTTIMESTATECLIENTPROJEC2", new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate), new SqlParameter("@countryId", countryId), new SqlParameter("employeeId", employeeId), new SqlParameter("@projectTimeState", projectTimeState), new SqlParameter("@clientId", clientId), new SqlParameter("@projectId", projectId));
            return Data;
        }
    }
}