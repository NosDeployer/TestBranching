using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.FullLengthLining
{
    /// <summary>
    /// FlAllOutstandingIssuesReportGateway
    /// </summary>
    public class FlAllOutstandingIssuesReportGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FlAllOutstandingIssuesReportGateway()
            : base("AllOutstandingIssues")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">DataSet</param>
        public FlAllOutstandingIssuesReportGateway(DataSet data)
            : base(data, "AllOutstandingIssues")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new FlAllOutstandingIssuesReportTDS();
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
            tableMapping.DataSetTable = "AllOutstandingIssues";
            tableMapping.ColumnMappings.Add("AssetID", "AssetID");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("ProjectID", "ProjectID");
            tableMapping.ColumnMappings.Add("SectionID", "SectionID");
            tableMapping.ColumnMappings.Add("COMPANIES_ID", "COMPANIES_ID");
            tableMapping.ColumnMappings.Add("Street", "Street");
            tableMapping.ColumnMappings.Add("USMH", "USMH");
            tableMapping.ColumnMappings.Add("DSMH", "DSMH");
            tableMapping.ColumnMappings.Add("Comments", "Comments");
            tableMapping.ColumnMappings.Add("NAME", "NAME");
            tableMapping.ColumnMappings.Add("USMHDescription", "USMHDescription");
            tableMapping.ColumnMappings.Add("DSMHDescription", "DSMHDescription");
            tableMapping.ColumnMappings.Add("IssueSales", "IssueSales");
            tableMapping.ColumnMappings.Add("IssueLFS", "IssueLFS");            
            tableMapping.ColumnMappings.Add("IssueClient", "IssueClient");
            tableMapping.ColumnMappings.Add("IssueInvestigation", "IssueInvestigation");
            tableMapping.ColumnMappings.Add("ProjectName", "ProjectName");
            tableMapping.ColumnMappings.Add("FlowOrderID", "FlowOrderID");

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
        /// Load
        /// </summary>
        /// <param name="companyId">companyId</param>
        public DataSet Load(int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_FLALLOUTSTANDINGISSUESREPORTGATEWAY_LOAD", new SqlParameter("@companyId", companyId));//Note: COMPANY_ID   
            return Data;
        }



        /// <summary>
        /// LoadByCompaniesId
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">COMPANIES_ID</param>        
        public DataSet LoadByCompaniesId(int companyId, int companiesId)
        {
            FillDataWithStoredProcedure("LFS_CWP_FLALLOUTSTANDINGISSUESREPORTGATEWAY_LOADBYCOMPANIESID", new SqlParameter("@companyId", companyId), new SqlParameter("@companiesId", companiesId));//Note: COMPANY_ID
            return Data;
        }



        /// <summary>
        /// LoadByCompaniesIdProjectId
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">COMPANIES_ID</param>        
        /// <param name="projectId">projectId</param>
        public DataSet LoadByCompaniesIdProjectId(int companyId, int companiesId, int projectId)
        {
            FillDataWithStoredProcedure("LFS_CWP_FLALLOUTSTANDINGISSUESREPORTGATEWAY_LOADBYCOMPANIESIDPROJECTID", new SqlParameter("@companyId", companyId), new SqlParameter("@companiesId", companiesId), new SqlParameter("@projectId", projectId));//Note: COMPANY_ID
            return Data;
        }



    }
}



