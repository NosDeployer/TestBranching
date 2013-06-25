using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.LabourHours.ProjectTime
{
    /// <summary>
    /// PrintManhoursPerPhaseJLInstallGateway
    /// </summary>
    public class PrintManhoursPerPhaseJLInstallGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public PrintManhoursPerPhaseJLInstallGateway()
            : base("printmanhoursperphasejlinstall")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public PrintManhoursPerPhaseJLInstallGateway(DataSet data)
            : base(data, "printmanhoursperphasejlinstall")
        {
        }



        /// <summary>
        /// InitData. Create a PrintManhoursPerPhaseTDS dataset
        /// </summary>
        protected override void InitData()
        {
            _data = new PrintManhoursPerPhaseTDS();
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
            tableMapping.DataSetTable = "printmanhoursperphasejlinstall";
            tableMapping.ColumnMappings.Add("ClientName", "ClientName");
            tableMapping.ColumnMappings.Add("ProjectName", "ProjectName");
            tableMapping.ColumnMappings.Add("Day", "Day");
            tableMapping.ColumnMappings.Add("Date", "Date");
            tableMapping.ColumnMappings.Add("Phase", "Phase");
            tableMapping.ColumnMappings.Add("Hrs", "Hrs");
            tableMapping.ColumnMappings.Add("Liners", "Liners");
            tableMapping.ColumnMappings.Add("ManHours", "ManHours");
            tableMapping.ColumnMappings.Add("LinersMeasured", "LinersMeasured");
            tableMapping.ColumnMappings.Add("LinersPrepped", "LinersPrepped");
            tableMapping.ColumnMappings.Add("Budget", "Budget");
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
        /// LoadByStartDateEndDateProjectTimeStateWorkFunction
        /// </summary>
        /// <para>Load Original with filters  </para>
        /// <param name="startDate">Start date filter for Project Costing report</param>
        /// <param name="endDate">End date filter for Project Costing report</param>
        /// <param name="projectTimeState">State filter for Project Costing report</param>
        /// <param name="work_">work_</param>
        /// <param name="function_">function_</param>
        public DataSet LoadByStartDateEndDateProjectTimeStateWorkFunction(int? countryId, DateTime startDate, DateTime endDate, string projectTimeState, string work_, string function_)
        {
            if (countryId.HasValue)
            {
                FillDataWithStoredProcedure("LFS_LABOURHOURS_PRINTMANHOURSPERPHASEGATEWAY_LOADBYSTARTDATEENDDATEPROJECTTIMESTATEWORKFUNCTIONCOUNTRYID", new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate), new SqlParameter("@projectTimeState", projectTimeState), new SqlParameter("@work_", work_), new SqlParameter("@function_", function_), new SqlParameter("@countryId", countryId));
            }
            else
            {
                FillDataWithStoredProcedure("LFS_LABOURHOURS_PRINTMANHOURSPERPHASEGATEWAY_LOADBYSTARTDATEENDDATEPROJECTTIMESTATEWORKFUNCTION", new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate), new SqlParameter("@projectTimeState", projectTimeState), new SqlParameter("@work_", work_), new SqlParameter("@function_", function_));
            }

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
            FillDataWithStoredProcedure("LFS_LABOURHOURS_PRINTMANHOURSPERPHASEGATEWAY_LOADBYCOMPANIESIDSTARTDATEENDDATEPROJECTTIMESTATEWORKFUNCTION", new SqlParameter("@companiesId", companiesId), new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate), new SqlParameter("@projectTimeState", projectTimeState), new SqlParameter("@work_", work_), new SqlParameter("@function_", function_));
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
            FillDataWithStoredProcedure("LFS_LABOURHOURS_PRINTMANHOURSPERPHASEGATEWAY_LOADBYCOMPANIESIDPROJECTIDSTARTDATEENDDATEPROJECTTIMESTATEWORKFUNCTION", new SqlParameter("@companiesId", companiesId), new SqlParameter("@projectId", projectId), new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate), new SqlParameter("@projectTimeState", projectTimeState), new SqlParameter("@work_", work_), new SqlParameter("@function_", function_));
            return Data;
        }



    }
}