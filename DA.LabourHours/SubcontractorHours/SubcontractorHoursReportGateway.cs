using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.LabourHours.SubcontractorHours
{
    /// <summary>
    /// SubcontractorHoursReportGateway
    /// </summary>
    public class SubcontractorHoursReportGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public SubcontractorHoursReportGateway()
            : base("SubcontractorHours")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public SubcontractorHoursReportGateway(DataSet data)
            : base(data, "SubcontractorHours")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new SubcontractorHoursReportTDS();
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
            tableMapping.DataSetTable = "SubcontractorHoursReportTDS";
            tableMapping.ColumnMappings.Add("ProjectID", "ProjectID");
            tableMapping.ColumnMappings.Add("RefID", "RefID");
            tableMapping.ColumnMappings.Add("SubcontractorID", "SubcontractorID");
            tableMapping.ColumnMappings.Add("Date", "Date");
            tableMapping.ColumnMappings.Add("Quantity", "Quantity");
            tableMapping.ColumnMappings.Add("RateCad", "RateCad");
            tableMapping.ColumnMappings.Add("TotalCad", "TotalCad");
            tableMapping.ColumnMappings.Add("RateUsd", "RateUsd");
            tableMapping.ColumnMappings.Add("TotalUsd", "TotalUsd");
            tableMapping.ColumnMappings.Add("Comment", "Comment");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("Subcontractor", "Subcontractor");
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
        /// LoadForSubcontractors
        /// </summary>
        /// <param name="companyId">companyId</param>
        public DataSet LoadForSubcontractors(int companyId)
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_SUBCONTRACTORHOURSGATEWAY_LOADFORSUBCONTRACTORS", new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadStartDateEndDateForSubcontractors
        /// </summary>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="companyId">companyId</param>
        public DataSet LoadStartDateEndDateForSubcontractors(DateTime startDate, DateTime endDate, int companyId)
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_SUBCONTRACTORHOURSGATEWAY_LOADBYSTARTDATEENDDATEFORSUBCONTRACTORS", new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadBySubcontractorId
        /// </summary>
        /// <param name="subcontractorId">subcontractorId</param>
        /// <param name="companyId">companyId</param>
        public DataSet LoadBySubcontractorId(int subcontractorId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_SUBCONTRACTORHOURSGATEWAY_LOADBYSUBCONTRACTORSID", new SqlParameter("@subcontractorId", subcontractorId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadBySubcontractorIdStartDateEndDate
        /// </summary>
        /// <param name="subcontractorId">subcontractorId</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="companyId">companyId</param>
        public DataSet LoadBySubcontractorIdStartDateEndDate(int subcontractorId, DateTime startDate, DateTime endDate, int companyId)
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_SUBCONTRACTORHOURSGATEWAY_LOADBYSUBCONTRACTORSIDSTARTDATEENDDATE", new SqlParameter("@subcontractorId", subcontractorId),  new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadForClientProject
        /// </summary>
        /// <param name="companyId">companyId</param>
        public DataSet LoadForClientProject(int companyId)
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_SUBCONTRACTORHOURSGATEWAY_LOADFORCLIENTPROJECT", new SqlParameter("@companyId", companyId));
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
            FillDataWithStoredProcedure("LFS_LABOURHOURS_SUBCONTRACTORHOURSGATEWAY_LOADBYSTARTDATEENDDATEFORCLIENTPROJECT", new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByCompaniesId
        /// </summary>
        /// <param name="clientId">clientId</param>
        /// <param name="companyId">companyId</param>
        public DataSet LoadByCompaniesId(int clientId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_SUBCONTRACTORHOURSGATEWAY_LOADBYCOMPANIESID", new SqlParameter("@clientId", clientId), new SqlParameter("@companyId", companyId));
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
            FillDataWithStoredProcedure("LFS_LABOURHOURS_SUBCONTRACTORHOURSGATEWAY_LOADBYCOMPANIESIDSTARTDATEENDDATE", new SqlParameter("@clientId", clientId),  new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate), new SqlParameter("@companyId", companyId));
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
            FillDataWithStoredProcedure("LFS_LABOURHOURS_SUBCONTRACTORHOURSGATEWAY_LOADBYCOMPANIESIDPROJECTID", new SqlParameter("@clientId", clientId), new SqlParameter("@projectId", projectId), new SqlParameter("@companyId", companyId));
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
            FillDataWithStoredProcedure("LFS_LABOURHOURS_SUBCONTRACTORHOURSGATEWAY_LOADBYCOMPANIESIDPROJECTIDSTARTDATEENDDATE", new SqlParameter("@clientId", clientId), new SqlParameter("@projectId", projectId), new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate), new SqlParameter("@companyId", companyId));
            return Data;
        }
    }
}
