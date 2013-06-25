using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.FullLengthLining
{
    /// <summary>
    /// FlWorkAheadReportGateway
    /// </summary>
    public class FlWorkAheadReportGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FlWorkAheadReportGateway()
            : base("WorkAhead")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">DataSet</param>
        public FlWorkAheadReportGateway(DataSet data)
            : base(data, "WorkAhead")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new FLWorkAheadReportTDS();
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
            tableMapping.DataSetTable = "WorkAhead";
            tableMapping.ColumnMappings.Add("COMPANIES_ID", "COMPANIES_ID");
            tableMapping.ColumnMappings.Add("ProjectID", "ProjectID");
            tableMapping.ColumnMappings.Add("Size_", "Size_");
            tableMapping.ColumnMappings.Add("SumScaled", "SumScaled");
            tableMapping.ColumnMappings.Add("TotalAhead", "TotalAhead");
            tableMapping.ColumnMappings.Add("NAME", "NAME");
            tableMapping.ColumnMappings.Add("Nro", "Nro");
            tableMapping.ColumnMappings.Add("SumConfirmed", "SumConfirmed");
            tableMapping.ColumnMappings.Add("TotalAhead2", "TotalAhead2");
            tableMapping.ColumnMappings.Add("ProjectName", "ProjectName");
            tableMapping.ColumnMappings.Add("MapLength", "AASS.MapLength");
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
            FillDataWithStoredProcedure("LFS_CWP_FLWORKAHEADREPORTGATEWAY_LOAD", new SqlParameter("@companyId", companyId));
            return Data;
        }



    }
}