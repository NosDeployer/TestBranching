using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.FullLengthLining
{
    /// <summary>
    /// ReinstateLateralReportGateway
    /// </summary>
    public class FlReinstateLateralReportGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FlReinstateLateralReportGateway()
            : base("ReinstateLateral")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">DataSet</param>
        public FlReinstateLateralReportGateway(DataSet data)
            : base(data, "ReinstateLateral")
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
            tableMapping.DataSetTable = "ReinstateLateral";
            tableMapping.ColumnMappings.Add("WorkID", "WorkID");
            tableMapping.ColumnMappings.Add("Lateral", "Lateral");
            tableMapping.ColumnMappings.Add("VideoDistance", "VideoDistance");
            tableMapping.ColumnMappings.Add("ClockPosition", "ClockPosition");
            tableMapping.ColumnMappings.Add("State", "State");
            tableMapping.ColumnMappings.Add("DistanceToCentre", "DistanceToCentre");
            tableMapping.ColumnMappings.Add("Size_", "Size_");
            tableMapping.ColumnMappings.Add("TimeOpened", "TimeOpened");
            tableMapping.ColumnMappings.Add("ReverseSetup", "ReverseSetup");
            tableMapping.ColumnMappings.Add("Reinstate", "Reinstate");
            tableMapping.ColumnMappings.Add("Comments", "Comments");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("ClientLateralID", "ClientLateralID");
            tableMapping.ColumnMappings.Add("Material", "Material");
            tableMapping.ColumnMappings.Add("DistanceFromUSMH", "DistanceFromUSMH");
            tableMapping.ColumnMappings.Add("DistanceFromDSMH", "DistanceFromDSMH");
            tableMapping.ColumnMappings.Add("FlowOrderIDLateralID", "FlowOrderIDLateralID");
            tableMapping.ColumnMappings.Add("LateralID", "LateralID");
            tableMapping.ColumnMappings.Add("ReverseClockPosition", "ReverseClockPosition");
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
        /// LoadByAssetId
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="companyId">companyId</param>
        /// <returns></returns>
        public DataSet LoadByAssetId(int assetId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_FLREINSTATELATERALREPORTGATEWAY_LOADBYASSETID", new SqlParameter("@assetId", assetId), new SqlParameter("@companyId", companyId));//Note: COMPANY_ID
            return Data;
        }



    }
}








