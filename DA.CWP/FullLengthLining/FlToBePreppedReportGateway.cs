using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.FullLengthLining
{
    /// <summary>
    /// FlToBePreppedReportGateway
    /// </summary>
    public class FlToBePreppedReportGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FlToBePreppedReportGateway()
            : base("ToBePrepped")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">DataSet</param>
        public FlToBePreppedReportGateway(DataSet data)
            : base(data, "ToBePrepped")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new FlToBePreppedReportTDS();
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
            tableMapping.DataSetTable = "ToBePrepped";
            tableMapping.ColumnMappings.Add("AssetID", "AssetID");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("ProjectID", "ProjectID");
            tableMapping.ColumnMappings.Add("SectionID", "SectionID");
            tableMapping.ColumnMappings.Add("COMPANIES_ID", "COMPANIES_ID");
            tableMapping.ColumnMappings.Add("SubArea", "SubArea");
            tableMapping.ColumnMappings.Add("Street", "Street");
            tableMapping.ColumnMappings.Add("USMH", "USMH");
            tableMapping.ColumnMappings.Add("DSMH", "DSMH");
            tableMapping.ColumnMappings.Add("Size_", "Size_");
            tableMapping.ColumnMappings.Add("Length", "Length");
            tableMapping.ColumnMappings.Add("P1Date", "P1 Date");
            tableMapping.ColumnMappings.Add("Comments", "Comments");
            tableMapping.ColumnMappings.Add("NAME", "NAME");
            tableMapping.ColumnMappings.Add("USMHDescription", "USMHDescription");
            tableMapping.ColumnMappings.Add("DSMHDescription", "DSMHDescription");
            tableMapping.ColumnMappings.Add("ProjectName", "ProjectName");
            tableMapping.ColumnMappings.Add("FlowOrderID", "FlowOrderID");
            tableMapping.ColumnMappings.Add("CountryName", "CountryName");

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
        /// <returns>Dataset</returns>
        public DataSet Load(int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_FLTOBEPREPPEDREPORTGATEWAY_LOAD", new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByCountryId
        /// </summary>
        /// <param name="countryId">countryId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Dataset</returns>
        public DataSet LoadByCountryId(int countryId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_FLTOBEPREPPEDREPORTGATEWAY_LOADBYCOUNTRYID", new SqlParameter("@countryId", countryId), new SqlParameter("@companyId", companyId));
            return Data;
        }

        

        /// <summary>
        /// LoadByCompaniesId
        /// </summary>
        /// <param name="companiesId">COMPANIES_ID</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Dataset</returns>
        public DataSet LoadByCompaniesId(int companiesId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_FLTOBEPREPPEDREPORTGATEWAY_LOADBYCOMPANIESID", new SqlParameter("@companiesId", companiesId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByCompaniesIdCountryId
        /// </summary>
        /// <param name="companiesId">COMPANIES_ID</param>     
        /// <param name="countryId">countryId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Dataset</returns>
        public DataSet LoadByCompaniesIdCountryId(int companiesId, int countryId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_FLTOBEPREPPEDREPORTGATEWAY_LOADBYCOMPANIESIDCOUNTRYID", new SqlParameter("@companiesId", companiesId), new SqlParameter("@countryId", countryId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByCompaniesIdProjectId
        /// </summary>
        /// <param name="companiesId">COMPANIES_ID</param>        
        /// <param name="projectId">projectId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Dataset</returns>
        public DataSet LoadByCompaniesIdProjectId(int companiesId, int projectId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_FLTOBEPREPPEDREPORTGATEWAY_LOADBYCOMPANIESIDPROJECTID", new SqlParameter("@companiesId", companiesId), new SqlParameter("@projectId", projectId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByCompaniesIdProjectIdCountryId
        /// </summary>
        /// <param name="companiesId">COMPANIES_ID</param>        
        /// <param name="projectId">projectId</param>
        /// <param name="countryId">countryId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Dataset</returns>
        public DataSet LoadByCompaniesIdProjectIdCountryId(int companiesId, int projectId, int countryId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_FLTOBEPREPPEDREPORTGATEWAY_LOADBYCOMPANIESIDPROJECTIDCOUNTRYID", new SqlParameter("@companiesId", companiesId), new SqlParameter("@projectId", projectId), new SqlParameter("@countryId", countryId), new SqlParameter("@companyId", companyId));
            return Data;
        }


        
    }
}