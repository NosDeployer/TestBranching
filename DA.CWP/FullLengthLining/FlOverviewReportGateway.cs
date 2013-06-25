using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.FullLengthLining
{
    /// <summary>
    /// FlOverviewReportGateway
    /// </summary>
    public class FlOverviewReportGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FlOverviewReportGateway()
            : base("OverviewReport")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">DataSet</param>
        public FlOverviewReportGateway(DataSet data)
            : base(data, "OverviewReport")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new FlOverviewReportTDS();
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
            tableMapping.DataSetTable = "OverviewReport";
            tableMapping.ColumnMappings.Add("AssetID", "AssetID");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("ProjectID", "ProjectID");
            tableMapping.ColumnMappings.Add("SubArea", "SubArea");
            tableMapping.ColumnMappings.Add("Street", "Street");
            tableMapping.ColumnMappings.Add("USMH", "USMH");
            tableMapping.ColumnMappings.Add("DSMH", "DSMH");
            tableMapping.ColumnMappings.Add("Size_", "Size_");
            tableMapping.ColumnMappings.Add("Size", "Size");
            tableMapping.ColumnMappings.Add("MapLength", "MapLength");
            tableMapping.ColumnMappings.Add("Length", "Length");
            tableMapping.ColumnMappings.Add("P1Date", "P1Date");
            tableMapping.ColumnMappings.Add("CXIsRemoved", "CXIsRemoved");
            tableMapping.ColumnMappings.Add("LiveLats", "LiveLats");
            tableMapping.ColumnMappings.Add("M1Date", "M1Date");
            tableMapping.ColumnMappings.Add("M2Date", "M2Date");
            tableMapping.ColumnMappings.Add("InstallDate", "InstallDate");
            tableMapping.ColumnMappings.Add("FinalVideo", "FinalVideo");
            tableMapping.ColumnMappings.Add("IssueIdentified", "IssueIdentified");
            tableMapping.ColumnMappings.Add("IssueSales", "IssueSales");
            tableMapping.ColumnMappings.Add("IssueLFS", "IssueLFS");
            tableMapping.ColumnMappings.Add("IssueClient", "IssueClient");
            tableMapping.ColumnMappings.Add("IssueGivenToClient", "IssueGivenToClient");
            tableMapping.ColumnMappings.Add("IssueResolved", "IssueResolved");
            tableMapping.ColumnMappings.Add("FullLengthLining", "FullLengthLining");
            tableMapping.ColumnMappings.Add("NAME", "NAME");
            tableMapping.ColumnMappings.Add("COMPANIES_ID", "COMPANIES_ID");
            tableMapping.ColumnMappings.Add("SectionID", "SectionID");
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
        /// LoadByCompaniesIdProjectId
        /// </summary>
        /// <param name="companiesId">COMPANIES_ID</param>
        /// <param name="projectId">projectId</param>
        /// <param name="companyId">companyId</param>
        public DataSet LoadByCompaniesIdProjectId(int companiesId, int projectId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_FLOVERVIEWREPORTGATEWAY_LOADBYCOMPANIESIDPROJECTID", new SqlParameter("@companiesId", companiesId), new SqlParameter("@projectId", projectId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByCompaniesIdProjectIdCountryId
        /// </summary>
        /// <param name="companiesId">COMPANIES_ID</param>
        /// <param name="projectId">projectId</param>
        /// <param name="countryId">countryId</param>
        /// <param name="companyId">companyId</param>
        public DataSet LoadByCompaniesIdProjectIdCountryId(int companiesId, int projectId, int countryId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_FLOVERVIEWREPORTGATEWAY_LOADBYCOMPANIESIDPROJECTIDCOUNTRYID", new SqlParameter("@companiesId", companiesId), new SqlParameter("@projectId", projectId), new SqlParameter("@countryId", countryId), new SqlParameter("@companyId", companyId));
            return Data;
        }


        
        /// <summary>
        /// LoadByCompaniesId
        /// </summary>
        /// <param name="companiesId">COMPANIES_ID</param>
        /// <param name="companyId">companyId</param>
        /// <returns></returns>
        public DataSet LoadByCompaniesId(int companiesId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_FLOVERVIEWREPORTGATEWAY_LOADBYCOMPANIESID", new SqlParameter("@companiesId", companiesId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByCompaniesIdCountryId
        /// </summary>
        /// <param name="companiesId">COMPANIES_ID</param>
        /// <param name="countryId">countryId</param>
        /// <param name="companyId">companyId</param>
        /// <returns></returns>
        public DataSet LoadByCompaniesIdCountryId(int companiesId, int countryId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_FLOVERVIEWREPORTGATEWAY_LOADBYCOMPANIESIDCOUNTRYID", new SqlParameter("@companiesId", companiesId), new SqlParameter("@countryId", countryId), new SqlParameter("@companyId", companyId));
            return Data;
        }
        


        /// <summary>
        /// Load
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <returns></returns>
        public DataSet Load(int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_FLOVERVIEWREPORTGATEWAY_LOAD", new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByCountryId
        /// </summary>
        /// <param name="countryId">countryId</param>
        /// <param name="companyId">companyId</param>
        /// <returns></returns>
        public DataSet LoadByCountryId(int countryId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_FLOVERVIEWREPORTGATEWAY_LOADBYCOUNTRYID", new SqlParameter("@countryId", countryId), new SqlParameter("@companyId", companyId));
            return Data;
        }



    }
}






