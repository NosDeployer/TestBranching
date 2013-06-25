using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.LabourHours.ActualCosts
{
    /// <summary>
    /// ActualCostsReportOtherCostsGateway
    /// </summary>
    public class ActualCostsReportOtherCostsGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ActualCostsReportOtherCostsGateway()
            : base("OtherCosts")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ActualCostsReportOtherCostsGateway(DataSet data)
            : base(data, "OtherCosts")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ActualCostsReportTDS();
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
            tableMapping.DataSetTable = "OtherCosts";
            tableMapping.ColumnMappings.Add("ProjectID", "ProjectID");
            tableMapping.ColumnMappings.Add("RefID", "RefID");
            tableMapping.ColumnMappings.Add("Category", "Category");
            tableMapping.ColumnMappings.Add("Date", "Date");
            tableMapping.ColumnMappings.Add("RateCad", "RateCad");
            tableMapping.ColumnMappings.Add("RateUsd", "RateUsd");
            tableMapping.ColumnMappings.Add("Comment", "Comment");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("Client", "Client");
            tableMapping.ColumnMappings.Add("Project", "Project");
            tableMapping.ColumnMappings.Add("Active", "Active");
            tableMapping.ColumnMappings.Add("CountryID", "CountryID");
            tableMapping.ColumnMappings.Add("ClientID", "ClientID");


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
        /// LoadForClientProject
        /// </summary>
        /// <param name="companyId">companyId</param>
        public DataSet LoadForClientProject(int companyId)
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_ACTUALCOSTSREPORTOTHERCOSTSGATEWAY_LOADFORCLIENTPROJECT", new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByCompaniesId
        /// </summary>
        /// <param name="clientId">clientId</param>
        /// <param name="companyId">companyId</param>
        public DataSet LoadByCompaniesId(int clientId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_ACTUALCOSTSREPORTOTHERCOSTSGATEWAY_LOADBYCOMPANIESID", new SqlParameter("@clientId", clientId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByCompaniesIdProjectId
        /// </summary>
        /// <param name="clientId">clientId</param>
        /// <param name="projectId">projectId</param>
        /// <param name="companyId">companyId</param>
        public DataSet LoadByCompaniesIdProjectId(int clientId, int projectId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_ACTUALCOSTSREPORTOTHERCOSTSGATEWAY_LOADBYCOMPANIESIDPROJECTID", new SqlParameter("@clientId", clientId), new SqlParameter("@projectId", projectId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadStartDateEndDateForClientProject
        /// </summary>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="companyId">companyId</param>
        public DataSet LoadStartDateEndDateForClientProject(DateTime startDate, DateTime endDate, int companyId)
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_ACTUALCOSTSREPORTOTHERCOSTSGATEWAY_LOADBYSTARTDATEENDDATEFORCLIENTPROJECT", new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByCompaniesIdStartDateEndDate
        /// </summary>
        /// <param name="clientId">clientId</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="companyId">companyId</param>
        public DataSet LoadByCompaniesIdStartDateEndDate(int clientId, DateTime startDate, DateTime endDate, int companyId)
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_ACTUALCOSTSREPORTOTHERCOSTSGATEWAY_LOADBYCOMPANIESIDSTARTDATEENDDATE", new SqlParameter("@clientId", clientId), new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByCompaniesIdProjectIdStartDateEndDate
        /// </summary>
        /// <param name="clientId">clientId</param>
        /// <param name="projectId">projectId</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="companyId">companyId</param>
        public DataSet LoadByCompaniesIdProjectIdStartDateEndDate(int clientId, int projectId, DateTime startDate, DateTime endDate, int companyId)
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_ACTUALCOSTSREPORTOTHERCOSTSGATEWAY_LOADBYCOMPANIESIDPROJECTIDSTARTDATEENDDATE", new SqlParameter("@clientId", clientId), new SqlParameter("@projectId", projectId), new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate), new SqlParameter("@companyId", companyId));
            return Data;
        }
    }
}
