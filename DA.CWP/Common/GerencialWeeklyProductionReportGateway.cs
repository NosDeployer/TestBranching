using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.Common
{
    /// <summary>
    /// GerencialWeeklyProductionReportGateway
    /// </summary>
    public class GerencialWeeklyProductionReportGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public GerencialWeeklyProductionReportGateway()
            : base("WeeklyProductionReport")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">DataSet</param>
        public GerencialWeeklyProductionReportGateway(DataSet data)
            : base(data, "WeeklyProductionReport")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new GerencialWeeklyProductionReportTDS();
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
            tableMapping.DataSetTable = "WeeklyProductionReport";
            tableMapping.ColumnMappings.Add("AssetID", "AssetID");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("ProjectID", "ProjectID");
            tableMapping.ColumnMappings.Add("ClientID", "ClientID");
            tableMapping.ColumnMappings.Add("Name", "Name");
            tableMapping.ColumnMappings.Add("COMPANIES_ID", "COMPANIES_ID");
            tableMapping.ColumnMappings.Add("SectionID", "SectionID");
            tableMapping.ColumnMappings.Add("ProjectName", "ProjectName");
            tableMapping.ColumnMappings.Add("FlowOrderID", "FlowOrderID");
            tableMapping.ColumnMappings.Add("CountryName", "CountryName");
            tableMapping.ColumnMappings.Add("Date", "Date");
            tableMapping.ColumnMappings.Add("TotalFtInstalled", "TotalFtInstalled");
            tableMapping.ColumnMappings.Add("TotalLinersInstalled", "TotalLinersInstalled");
            tableMapping.ColumnMappings.Add("TotalLinersBuildNotInstalled", "TotalLinersBuildNotInstalled");
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
        /// <param name="date">date</param>
        /// <param name="companyId">companyId</param>
        public DataSet LoadByDate(DateTime date, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_COMMON_GERENCIALWEEKLYPRODUCTIONREPORTGATEWAY_LOADBYDATE", new SqlParameter("@date", date), new SqlParameter("@companyId", companyId));
            return Data;
        }

    }
}
