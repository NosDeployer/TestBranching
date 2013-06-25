using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Projects.Projects
{
    /// <summary>
    /// ProductionReportGateway
    /// </summary>
    public class ProductionReportGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProductionReportGateway()
            : base("Production")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public ProductionReportGateway(DataSet data)
            : base(data, "Production")
        {
        }



        /// <summary>
        /// InitData. Create a dataset
        /// </summary>
        protected override void InitData()
        {
            _data = new ProductionReportTDS();
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
            tableMapping.DataSetTable = "Production";
            tableMapping.ColumnMappings.Add("CountryID", "CountryID");
            tableMapping.ColumnMappings.Add("CountryName", "CountryName");
            tableMapping.ColumnMappings.Add("ClientID", "ClientID");
            tableMapping.ColumnMappings.Add("ClientName", "ClientName");
            tableMapping.ColumnMappings.Add("ProjectID", "ProjectID");
            tableMapping.ColumnMappings.Add("ProjectName", "ProjectName");
            tableMapping.ColumnMappings.Add("ID", "ID");
            tableMapping.ColumnMappings.Add("Description", "Description");
            tableMapping.ColumnMappings.Add("ConfirmedSize", "ConfirmedSize");
            tableMapping.ColumnMappings.Add("Length", "Length");
            tableMapping.ColumnMappings.Add("Function_", "Function_");
            tableMapping.ColumnMappings.Add("Module", "Module");
            tableMapping.ColumnMappings.Add("Date", "Date");
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
        /// LoadByStartDateEndDate
        /// </summary>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="companyId">companyId</param>        
        public DataSet LoadByStartDateEndDate(DateTime startDate, DateTime endDate, int companyId)
        {
            FillDataWithStoredProcedure("LFS_PROJECTS_PRODUCTIONREPORTGATEWAY_LOADBYSTARTDATEENDDATE", new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByClientIdStartDateEndDate
        /// </summary>
        /// <param name="clientId">clientId</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="companyId">companyId</param>
        public DataSet LoadByClientIdStartDateEndDate(int clientId, DateTime startDate, DateTime endDate, int companyId)
        {
            FillDataWithStoredProcedure("LFS_PROJECTS_PRODUCTIONREPORTGATEWAY_LOADBYCLIENTIDSTARTDATEENDDATE", new SqlParameter("@clientId", clientId), new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate), new SqlParameter("@companyId", companyId));
            return Data;
        }


        /// <summary>
        /// LoadByClientIdProjectIdStartDateEndDate
        /// </summary>
        /// <param name="clientId">clientId</param>
        /// <param name="projectId">projectId</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="companyId">companyId</param>
        public DataSet LoadByClientIdProjectIdStartDateEndDate(int clientId, int projectId, DateTime startDate, DateTime endDate, int companyId)
        {
            FillDataWithStoredProcedure("LFS_PROJECTS_PRODUCTIONREPORTGATEWAY_LOADBYCLIENTIDPROJECTIDSTARTDATEENDDATE", new SqlParameter("@clientId", clientId), new SqlParameter("@projectId", projectId), new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByCountryIdStartDateEndDate
        /// </summary>
        /// <param name="countryId">countryId</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="companyId">companyId</param>        
        public DataSet LoadByCountryIdStartDateEndDate(int countryId, DateTime startDate, DateTime endDate, int companyId)
        {
            FillDataWithStoredProcedure("LFS_PROJECTS_PRODUCTIONREPORTGATEWAY_LOADBYCOUNTRYIDSTARTDATEENDDATE", new SqlParameter("@countryId", countryId), new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate), new SqlParameter("@companyId", companyId));
            return Data;
        }


        /// <summary>
        /// LoadByCountryIdClientIdStartDateEndDate
        /// </summary>
        /// <param name="countryId">countryId</param>
        /// <param name="clientId">clientId</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="companyId">companyId</param>
        public DataSet LoadByCountryIdClientIdStartDateEndDate(int countryId, int clientId, DateTime startDate, DateTime endDate, int companyId)
        {
            FillDataWithStoredProcedure("LFS_PROJECTS_PRODUCTIONREPORTGATEWAY_LOADBYCOUNTRYIDCLIENTIDSTARTDATEENDDATE", new SqlParameter("@countryId", countryId), new SqlParameter("@clientId", clientId), new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate), new SqlParameter("@companyId", companyId));
            return Data;
        }


        /// <summary>
        /// LoadByCountryIdClientIdProjectIdStartDateEndDate
        /// </summary>
        /// <param name="countryId">countryId</param>
        /// <param name="clientId">clientId</param>
        /// <param name="projectId">projectId</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="companyId">companyId</param>
        public DataSet LoadByCountryIdClientIdProjectIdStartDateEndDate(int countryId, int clientId, int projectId, DateTime startDate, DateTime endDate, int companyId)
        {
            FillDataWithStoredProcedure("LFS_PROJECTS_PRODUCTIONREPORTGATEWAY_LOADBYCOUNTRYIDCLIENTIDPROJECTIDSTARTDATEENDDATE", new SqlParameter("@countryId", countryId), new SqlParameter("@clientId", clientId), new SqlParameter("@projectId", projectId), new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate), new SqlParameter("@companyId", companyId));
            return Data;
        }



    }
}