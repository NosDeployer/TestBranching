using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.FullLengthLining
{
    /// <summary>
    /// ReinstateSectionReportGateway
    /// </summary>
    public class FlReinstateSectionReportGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FlReinstateSectionReportGateway()
            : base("ReinstateSection")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">DataSet</param>
        public FlReinstateSectionReportGateway(DataSet data)
            : base(data, "ReinstateSection")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new FlReinstateReportTDS();
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
            tableMapping.DataSetTable = "ReinstateSection";
            tableMapping.ColumnMappings.Add("WorkID", "WorkID");
            tableMapping.ColumnMappings.Add("AssetID", "AssetID");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("ProjectID", "ProjectID");
            tableMapping.ColumnMappings.Add("SectionID", "SectionID");
            tableMapping.ColumnMappings.Add("COMPANIES_ID", "COMPANIES_ID");
            tableMapping.ColumnMappings.Add("NAME", "NAME");
            tableMapping.ColumnMappings.Add("SubArea", "SubArea");
            tableMapping.ColumnMappings.Add("Street", "Street");
            tableMapping.ColumnMappings.Add("Length", "Length");
            tableMapping.ColumnMappings.Add("Size_", "Size_");
            tableMapping.ColumnMappings.Add("USMHDescription", "USMHDescription");
            tableMapping.ColumnMappings.Add("DSMHDescription", "DSMHDescription");
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
        /// LoadByCompaniesIdProjectId
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">COMPANIES_ID</param>        
        /// <param name="projectId">projectId</param>
        public DataSet LoadByCompaniesIdProjectId(int companyId, int companiesId, int projectId)
        {
            FillDataWithStoredProcedure("LFS_CWP_FLREINSTATESECTIONREPORTGATEWAY_LOADBYCOMPANIESIDPROJECTID", new SqlParameter("@companyId", companyId), new SqlParameter("@companiesId", companiesId), new SqlParameter("@projectId", projectId));//Note: COMPANY_ID
            return Data;
        }



        /// <summary>
        /// LoadByCompaniesId
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">COMPANIES_ID</param>        
        /// <returns></returns>
        public DataSet LoadByCompaniesId(int companyId, int companiesId)
        {
            FillDataWithStoredProcedure("LFS_CWP_FLREINSTATESECTIONREPORTGATEWAY_LOADBYCOMPANIESID", new SqlParameter("@companyId", companyId), new SqlParameter("@companiesId", companiesId));//Note: COMPANY_ID
            return Data;
        }



        /// <summary>
        /// Load
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <returns></returns>
        public DataSet Load(int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_FLREINSTATESECTIONREPORTGATEWAY_LOAD", new SqlParameter("@companyId", companyId));//Note: COMPANY_ID
            return Data;
        }



        /// <summary>
        /// LoadBySectionId
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="sectionId">sectionId</param>
        /// <returns></returns>
        public DataSet LoadBySectionId(int companyId, string sectionId)
        {
            FillDataWithStoredProcedure("LFS_CWP_FLREINSTATESECTIONREPORTGATEWAY_LOADBYSECTIONID", new SqlParameter("@companyId", companyId), new SqlParameter("@sectionId", sectionId));//Note: COMPANY_ID
            return Data;
        }



    }
}
