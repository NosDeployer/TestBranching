using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.PointRepairs
{
    /// <summary>
    /// PrOverviewReportGateway
    /// </summary>
    public class PrOverviewReportGateway : DataTableGateway
    {
       // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public PrOverviewReportGateway()
            : base("PrOverview")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">DataSet</param>
        public PrOverviewReportGateway(DataSet data)
            : base(data, "PrOverview")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new PrOverviewReportTDS();
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
            tableMapping.DataSetTable = "PrOverview";
            tableMapping.ColumnMappings.Add("WorkID", "WorkID");
            tableMapping.ColumnMappings.Add("RepairPointID", "RepairPointID");
            tableMapping.ColumnMappings.Add("FlowOrderID", "FlowOrderID");
            tableMapping.ColumnMappings.Add("Type", "Type");
            tableMapping.ColumnMappings.Add("Street", "Street");
            tableMapping.ColumnMappings.Add("RepairDate", "RepairDate");
            tableMapping.ColumnMappings.Add("Reinstates", "Reinstates");
            tableMapping.ColumnMappings.Add("LTMH", "LTMH");
            tableMapping.ColumnMappings.Add("VTMH", "VTMH");
            tableMapping.ColumnMappings.Add("Distance", "Distance");
            tableMapping.ColumnMappings.Add("Size_", "Size_");
            tableMapping.ColumnMappings.Add("DefectQualifier", "DefectQualifier");
            tableMapping.ColumnMappings.Add("DefectDetails", "DefectDetails");
            tableMapping.ColumnMappings.Add("Comments", "Comments");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("ProjectName", "ProjectName");
            tableMapping.ColumnMappings.Add("COMPANIES_ID", "COMPANIES_ID");
            tableMapping.ColumnMappings.Add("ClientName", "ClientName");
            tableMapping.ColumnMappings.Add("ProjectNumber", "ProjectNumber");
            tableMapping.ColumnMappings.Add("USMH", "USMH");
            tableMapping.ColumnMappings.Add("DSMH", "DSMH");
            tableMapping.ColumnMappings.Add("Length", "Length");
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
            FillDataWithStoredProcedure("LFS_CWP_PROVERVIEWREPORTGATEWAY_LOAD", new SqlParameter("@companyId", companyId)); 
            return Data;
        }



        /// <summary>
        /// LoadByPrType
        /// </summary>
        /// <param name="type">type</param>
        /// <param name="companyId">companyId</param>
        public DataSet LoadByPrType(string type, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_PROVERVIEWREPORTGATEWAY_LOADBYPRTYPE", new SqlParameter("@type", type), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByCompaniesId
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">COMPANIES_ID</param>
        public DataSet LoadByCompaniesId(int companyId, int companiesId)
        {
            FillDataWithStoredProcedure("LFS_CWP_PROVERVIEWREPORTGATEWAY_LOADBYCOMPANIESID", new SqlParameter("@companyId", companyId), new SqlParameter("@companiesId", companiesId)); 
            return Data;
        }



        /// <summary>
        /// LoadByCompaniesIdPrType
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">COMPANIES_ID</param>
        /// <param name="type">type</param>
        public DataSet LoadByCompaniesIdPrType(int companyId, int companiesId, string type)
        {
            FillDataWithStoredProcedure("LFS_CWP_PROVERVIEWREPORTGATEWAY_LOADBYCOMPANIESIDPRTYPE", new SqlParameter("@type", type), new SqlParameter("@companyId", companyId), new SqlParameter("@companiesId", companiesId));
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
            FillDataWithStoredProcedure("LFS_CWP_PROVERVIEWREPORTGATEWAY_LOADBYCOMPANIESIDPROJECTID", new SqlParameter("@companyId", companyId), new SqlParameter("@companiesId", companiesId), new SqlParameter("@projectId", projectId)); 
            return Data;
        }



        /// <summary>
        /// LoadByCompaniesIdProjectIdPrType
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">COMPANIES_ID</param>
        /// <param name="projectId">projectId</param>
        /// <param name="type">type</param>
        public DataSet LoadByCompaniesIdProjectIdPrType(int companyId, int companiesId, int projectId, string type)
        {
            FillDataWithStoredProcedure("LFS_CWP_PROVERVIEWREPORTGATEWAY_LOADBYCOMPANIESIDPROJECTIDPRTYPE", new SqlParameter("@type", type), new SqlParameter("@companyId", companyId), new SqlParameter("@companiesId", companiesId), new SqlParameter("@projectId", projectId));
            return Data;
        }

        

    }
}