using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.LabourHours.ProjectTime
{
    /// <summary>
    /// PrintProjectCostingGateway
    /// </summary>
    public class PrintProjectCostingGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public PrintProjectCostingGateway()
            : base("Original")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public PrintProjectCostingGateway(DataSet data)
            : base(data, "Original")
        {
        }



        /// <summary>
        /// InitData. Create a PrintProjectCostingTDS dataset
        /// </summary>
        protected override void InitData()
        {
            _data = new PrintProjectCostingTDS();
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
            tableMapping.ColumnMappings.Add("ClientID", "ClientID");
            tableMapping.ColumnMappings.Add("ClientName", "ClientName");
            tableMapping.ColumnMappings.Add("ProjectName", "ProjectName");
            tableMapping.ColumnMappings.Add("CountryID", "CountryID");
            tableMapping.ColumnMappings.Add("CountryName", "CountryName");
            tableMapping.ColumnMappings.Add("EmployeeID", "EmployeeID");
            tableMapping.ColumnMappings.Add("EmployeeName", "EmployeeName");
            tableMapping.ColumnMappings.Add("Date_", "Date_");
            tableMapping.ColumnMappings.Add("ProjectTime", "ProjectTime");
            tableMapping.ColumnMappings.Add("WorkingDetails", "WorkingDetails");
            tableMapping.ColumnMappings.Add("MealsCountry", "MealsCountry");
            tableMapping.ColumnMappings.Add("MealsAllowance", "MealsAllowance");
            tableMapping.ColumnMappings.Add("Comments", "Comments");
            tableMapping.ColumnMappings.Add("UnitID", "UnitID");
            tableMapping.ColumnMappings.Add("Unit", "Unit");
            tableMapping.ColumnMappings.Add("TowedUnitID", "TowedUnitID");
            tableMapping.ColumnMappings.Add("Towed", "Towed");
            tableMapping.ColumnMappings.Add("Work_", "Work_");
            tableMapping.ColumnMappings.Add("Function_", "Function_");
            tableMapping.ColumnMappings.Add("ProjectTimeState", "ProjectTimeState");
            tableMapping.ColumnMappings.Add("FairWage", "FairWage");
            tableMapping.ColumnMappings.Add("ProjectID", "ProjectID");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandTimeout = 1200;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// LoadByStartDateEndDateProjectTimeState
        /// </summary>
        /// <para>Load Original with filters  </para>
        /// <param name="startDate">Start date filter for Project Costing report</param>
        /// <param name="endDate">End date filter for Project Costing report</param>
        /// <param name="projectTimeState">State filter for Project Costing report</param>
        public DataSet LoadByStartDateEndDateProjectTimeState(DateTime startDate, DateTime endDate, string projectTimeState)
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_PRINTPROJECTCOSTINGGATEWAY_LOADBYSTARTDATEENDDATEPROJECTTIMESTATE", new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate), new SqlParameter("@projectTimeState", projectTimeState));
            return Data;
        }



        /// <summary>
        /// LoadByStartDateEndDateProjectTimeStateWork
        /// </summary>
        /// <para>Load Original with filters  </para>
        /// <param name="startDate">Start date filter for Project Costing report</param>
        /// <param name="endDate">End date filter for Project Costing report</param>
        /// <param name="projectTimeState">State filter for Project Costing report</param>
        /// <param name="work">work</param>
        public DataSet LoadByStartDateEndDateProjectTimeStateWork(DateTime startDate, DateTime endDate, string projectTimeState, string work_)
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_PRINTPROJECTCOSTINGGATEWAY_LOADBYSTARTDATEENDDATEPROJECTTIMESTATEWORK", new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate), new SqlParameter("@projectTimeState", projectTimeState), new SqlParameter("@work_", work_));
            return Data;
        }



        /// <summary>
        /// LoadByStartDateEndDateProjectTimeStateWorkFunction
        /// </summary>
        /// <para>Load Original with filters  </para>
        /// <param name="startDate">Start date filter for Project Costing report</param>
        /// <param name="endDate">End date filter for Project Costing report</param>
        /// <param name="projectTimeState">State filter for Project Costing report</param>
        /// <param name="work_">work_</param>
        /// <param name="function_">function_</param>
        public DataSet LoadByStartDateEndDateProjectTimeStateWorkFunction(DateTime startDate, DateTime endDate, string projectTimeState, string work_, string function_)
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_PRINTPROJECTCOSTINGGATEWAY_LOADBYSTARTDATEENDDATEPROJECTTIMESTATEWORKFUNCTION", new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate), new SqlParameter("@projectTimeState", projectTimeState), new SqlParameter("@work_", work_), new SqlParameter("@function_", function_));
            return Data;
        }



        /// <summary>
        /// LoadByCompaniesIdStartDateEndDateProjectTimeState
        /// </summary>
        /// <para>Load Original with filters  </para>
        /// <param name="companiesId">Company filter (client) for project Costing report</param>/// 
        /// <param name="startDate">Start date filter for Project Costing report</param>
        /// <param name="endDate">End date filter for Project Costing report</param>
        /// <param name="projectTimeState">State filter for Project Costing report</param>
        public DataSet LoadByCompaniesIdStartDateEndDateProjectTimeState(int companiesId, DateTime startDate, DateTime endDate, string projectTimeState)
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_PRINTPROJECTCOSTINGGATEWAY_LOADBYCOMPANIESIDSTARTDATEENDDATEPROJECTTIMESTATE", new SqlParameter("@companiesId", companiesId), new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate), new SqlParameter("@projectTimeState", projectTimeState));
            return Data;
        }



        /// <summary>
        /// LoadByCompaniesIdStartDateEndDateProjectTimeStateWork
        /// </summary>
        /// <para>Load Original with filters  </para>
        /// <param name="companiesId">Company filter (client) for project Costing report</param>/// 
        /// <param name="startDate">Start date filter for Project Costing report</param>
        /// <param name="endDate">End date filter for Project Costing report</param>
        /// <param name="projectTimeState">State filter for Project Costing report</param>
        /// <param name="work_">work_</param>
        public DataSet LoadByCompaniesIdStartDateEndDateProjectTimeStateWork(int companiesId, DateTime startDate, DateTime endDate, string projectTimeState, string work_)
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_PRINTPROJECTCOSTINGGATEWAY_LOADBYCOMPANIESIDSTARTDATEENDDATEPROJECTTIMESTATEWORK", new SqlParameter("@companiesId", companiesId), new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate), new SqlParameter("@projectTimeState", projectTimeState), new SqlParameter("@work_", work_));
            return Data;
        }



        /// <summary>
        /// LoadByCompaniesIdStartDateEndDateProjectTimeStateWorkFunction
        /// </summary>
        /// <para>Load Original with filters  </para>
        /// <param name="companiesId">Company filter (client) for project Costing report</param>/// 
        /// <param name="startDate">Start date filter for Project Costing report</param>
        /// <param name="endDate">End date filter for Project Costing report</param>
        /// <param name="projectTimeState">State filter for Project Costing report</param>
        /// <param name="work_">work_</param>
        /// <param name="function_">function_</param>
        public DataSet LoadByCompaniesIdStartDateEndDateProjectTimeStateWorkFunction(int companiesId, DateTime startDate, DateTime endDate, string projectTimeState, string work_, string function_)
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_PRINTPROJECTCOSTINGGATEWAY_LOADBYCOMPANIESIDSTARTDATEENDDATEPROJECTTIMESTATEWORKFUNCTION", new SqlParameter("@companiesId", companiesId), new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate), new SqlParameter("@projectTimeState", projectTimeState), new SqlParameter("@work_", work_), new SqlParameter("@function_", function_));
            return Data;
        }



        /// <summary>
        /// LoadByCompaniesIdProjectIdStartDateEndDateProjectTimeState
        /// </summary>
        /// <para>Load Original with filters  </para> 
        /// <param name="companiesId">Company filter (client) for Project Costing report</param>
        /// <param name="projectId">Project filter for Project Costing report</param>
        /// <param name="startDate">Start date filter for Project Costing report</param>
        /// <param name="endDate">End date filter for  Project Costing report</param>
        /// <param name="projectTimeState">State filter for Project Costing report</param>
        public DataSet LoadByCompaniesIdProjectIdStartDateEndDateProjectTimeState(int companiesId, int projectId, DateTime startDate, DateTime endDate, string projectTimeState)
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_PRINTPROJECTCOSTINGGATEWAY_LOADBYCOMPANIESIDPROJECTIDSTARTDATEENDDATEPROJECTTIMESTATE", new SqlParameter("@companiesId", companiesId), new SqlParameter("@projectId", projectId), new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate), new SqlParameter("@projectTimeState", projectTimeState));
            return Data;
        }



        /// <summary>
        /// LoadByCompaniesIdProjectIdStartDateEndDateProjectTimeStateWork
        /// </summary>
        /// <para>Load Original with filters  </para> 
        /// <param name="companiesId">Company filter (client) for Project Costing report</param>
        /// <param name="projectId">Project filter for Project Costing report</param>
        /// <param name="startDate">Start date filter for Project Costing report</param>
        /// <param name="endDate">End date filter for  Project Costing report</param>
        /// <param name="projectTimeState">State filter for Project Costing report</param>
        /// <param name="work_">work_</param>
        public DataSet LoadByCompaniesIdProjectIdStartDateEndDateProjectTimeStateWork(int companiesId, int projectId, DateTime startDate, DateTime endDate, string projectTimeState, string work_)
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_PRINTPROJECTCOSTINGGATEWAY_LOADBYCOMPANIESIDPROJECTIDSTARTDATEENDDATEPROJECTTIMESTATEWORK", new SqlParameter("@companiesId", companiesId), new SqlParameter("@projectId", projectId), new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate), new SqlParameter("@projectTimeState", projectTimeState), new SqlParameter("@work_", work_));
            return Data;
        }



        /// <summary>
        /// LoadByCompaniesIdProjectIdStartDateEndDateProjectTimeStateWorkFunction
        /// </summary>
        /// <para>Load Original with filters  </para> 
        /// <param name="companiesId">Company filter (client) for Project Costing report</param>
        /// <param name="projectId">Project filter for Project Costing report</param>
        /// <param name="startDate">Start date filter for Project Costing report</param>
        /// <param name="endDate">End date filter for  Project Costing report</param>
        /// <param name="projectTimeState">State filter for Project Costing report</param>
        /// <param name="work_">work_</param>
        /// <param name="function_">function_</param>
        public DataSet LoadByCompaniesIdProjectIdStartDateEndDateProjectTimeStateWorkFunction(int companiesId, int projectId, DateTime startDate, DateTime endDate, string projectTimeState, string work_, string function_)
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_PRINTPROJECTCOSTINGGATEWAY_LOADBYCOMPANIESIDPROJECTIDSTARTDATEENDDATEPROJECTTIMESTATEWORKFUNCTION", new SqlParameter("@companiesId", companiesId), new SqlParameter("@projectId", projectId), new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate), new SqlParameter("@projectTimeState", projectTimeState), new SqlParameter("@work_", work_), new SqlParameter("@function_", function_));
            return Data;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - QUERIES
        //

        /// <summary>
        /// UnitSameDayUseSeveralProjects
        /// </summary>
        /// <para>Verifies the amount of projects that uses a unit  </para> 
        /// <param name="dateOfUse">Date when the unit was used</param>
        /// <param name="unitId">Unit used</param>
        /// <returns>The amout of rows that represents the amount of projects that used the unit</returns>
        public int UnitSameDayUseSeveralProjects(DateTime dateOfUse, int unitID)
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_PRINTPROJECTCOSTINGGATEWAY_UNITSAMEDAYUSESEVERALPROJECTS", new SqlParameter("@dateOfUse", dateOfUse), new SqlParameter("@unitID", unitID));
            return (int)Table.Rows.Count;
        }



        /// <summary>
        /// UnitUnitSameDayUseSeveralWorkFunctions
        /// </summary>
        /// <para>Verifies the amount of projects that uses a towed unit </para> 
        /// <param name="projectId">projectId</param>
        /// <param name="dateOfUse">Date when the unit was used</param>
        /// <param name="unitId">Unit used</param>
        /// <returns>The amout of rows that represents the amount of projects that used the towed unit</returns> 
        public int UnitSameDayUseSeveralWorkFunctions(int projectId, DateTime dateOfUse, int unitId)
        {
            string commandText = "SELECT COUNT(DISTINCT Work_+'.'+Function_) AS No FROM LFS_PROJECT_TIME WHERE (Deleted = 0) AND (Date_ = @dateOfUse) AND (UnitID = @unitId) AND (ProjectID = @projectId)";
            SqlCommand command = new SqlCommand(commandText, DB.Connection);
            command.Parameters.Add(new SqlParameter("@dateOfUse", dateOfUse));
            command.Parameters.Add(new SqlParameter("@unitId", unitId));
            command.Parameters.Add(new SqlParameter("@projectId", projectId));

            if (ExecuteScalar(command) == DBNull.Value)
            {
                return 0;
            }
            else
            {
                return ((int)ExecuteScalar(command));
            }
        }



        /// <summary>
        /// TowedUnitSameDayUseSeveralProjects
        /// </summary>
        /// <para>Verifies the amount of projects that uses a towed unit </para> 
        /// <param name="dateOfUse">Date when the unit was used</param>
        /// <param name="unitId">Unit used</param>
        /// <returns>The amout of rows that represents the amount of projects that used the towed unit</returns> 
        public int TowedUnitSameDayUseSeveralProjects(DateTime dateOfUse, int towedUnitID)
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_PRINTPROJECTCOSTINGGATEWAY_TOWEDUNITSAMEDAYUSESEVERALPROJECTS", new SqlParameter("@dateOfUse", dateOfUse), new SqlParameter("@towedUnitID", towedUnitID));
            return (int)Table.Rows.Count;
        }



        /// <summary>
        /// TowedUnitSameDayUseSeveralWorkFunctions
        /// </summary>
        /// <para>Verifies the amount of projects that uses a towed unit </para> 
        /// <param name="projectId">projectId</param>
        /// <param name="dateOfUse">Date when the unit was used</param>
        /// <param name="towedUnitID">Unit used</param>
        /// <returns>The amout of rows that represents the amount of projects that used the towed unit</returns> 
        public int TowedUnitSameDayUseSeveralWorkFunctions(int projectId, DateTime dateOfUse, int towedUnitId)
        {
            string commandText = "SELECT COUNT(DISTINCT Work_+'.'+Function_) AS No FROM LFS_PROJECT_TIME WHERE (Deleted = 0) AND (Date_ = @dateOfUse) AND (TowedUnitID = @towedUnitId) AND (ProjectID = @projectId)";
            SqlCommand command = new SqlCommand(commandText, DB.Connection);
            command.Parameters.Add(new SqlParameter("@dateOfUse", dateOfUse));
            command.Parameters.Add(new SqlParameter("@towedUnitId", towedUnitId));
            command.Parameters.Add(new SqlParameter("@projectId", projectId));

            if (ExecuteScalar(command) == DBNull.Value)
            {
                return 0;
            }
            else
            {
                return ((int)ExecuteScalar(command));
            }
        }



    }
}