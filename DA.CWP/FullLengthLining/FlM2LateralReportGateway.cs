using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.FullLengthLining
{
    /// <summary>
    /// FlM2LateralReportGateway
    /// </summary>
    public class FlM2LateralReportGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FlM2LateralReportGateway()
            : base("M2_LATERAL")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">DataSet</param>
        public FlM2LateralReportGateway(DataSet data)
            : base(data, "M2_LATERAL")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new FlM2ReportTDS();
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
            tableMapping.DataSetTable = "M2_LATERAL";
            tableMapping.ColumnMappings.Add("WorkID", "WorkID");
            tableMapping.ColumnMappings.Add("Lateral", "Lateral");
            tableMapping.ColumnMappings.Add("VideoDistance", "SectionID");
            tableMapping.ColumnMappings.Add("ClockPosition", "ClockPosition");
            tableMapping.ColumnMappings.Add("State", "State");
            tableMapping.ColumnMappings.Add("DistanceToCentre", "DistanceToCentre");
            tableMapping.ColumnMappings.Add("Size_", "Size_");
            tableMapping.ColumnMappings.Add("TimeOpened", "TimeOpened");
            tableMapping.ColumnMappings.Add("Type", "Type");
            tableMapping.ColumnMappings.Add("ReverseSetup", "ReverseSetup");
            tableMapping.ColumnMappings.Add("Reinstate", "Reinstate");
            tableMapping.ColumnMappings.Add("Comments", "Comments");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
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
        /// LoadByAssetIdCompanyId
        /// </summary>
        /// <param name="assetId"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public DataSet LoadByAssetIdCompanyId(int assetId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_FLM2LATERALREPORTGATEWAY_LOADBYASSETIDCOMPANYID", new SqlParameter("@assetId", assetId), new SqlParameter("@companyId", companyId));//Note: COMPANY_ID
            return Data;
        }      



    }
}





