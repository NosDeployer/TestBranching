using System.Data;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.Common
{
    /// <summary>
    /// LateralLocationSheetLateralDetailsReportGateway
    /// </summary>
    public class LateralLocationSheetLateralDetailsReportGateway : DataTableGateway 
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public LateralLocationSheetLateralDetailsReportGateway() : base("LateralLocationSheetLateralDetails")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public LateralLocationSheetLateralDetailsReportGateway(DataSet data) : base(data, "LateralLocationSheetLateralDetails")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new LateralLocationSheetReportTDS();
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
            tableMapping.DataSetTable = "LateralLocationSheetLateralDetails";
            tableMapping.ColumnMappings.Add("AssetID", "AssetID");
            tableMapping.ColumnMappings.Add("Address", "Address");
            tableMapping.ColumnMappings.Add("LateralID", "LateralID");
            tableMapping.ColumnMappings.Add("ConnectionType", "ConnectionType");
            tableMapping.ColumnMappings.Add("VideoDistance", "VideoDistance");
            tableMapping.ColumnMappings.Add("VideoDistanceDouble", "VideoDistanceDouble");
            tableMapping.ColumnMappings.Add("ClockPosition", "ClockPosition");
            tableMapping.ColumnMappings.Add("ReverseSetup", "ReverseSetup");
            tableMapping.ColumnMappings.Add("ReverseSetupDouble", "ReverseSetupDouble");
            tableMapping.ColumnMappings.Add("State", "State");
            tableMapping.ColumnMappings.Add("LineLateral", "LineLateral");
            tableMapping.ColumnMappings.Add("LinerInstalled", "LinerInstalled");
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
        /// LoadBySectionIdWorkIdProjectId
        /// </summary>
        /// <param name="sectionId">sectionId</param>
        /// <param name="workId">workId</param>
        /// <param name="projectId">projectId</param>
        /// <param name="companyId">companyId</param>        
        /// <returns>Data</returns>
        public DataSet LoadBySectionIdWorkIdProjectId(int sectionId, int workId, int projectId, int companyId)
        {
            string command = string.Format("SELECT AASL.AssetID, AASL.Address, AASL.LateralID, AASL.ConnectionType, LWFLM1L.VideoDistance, 0.0 AS VideoDistanceDouble, "+
                                           "        LWFLM1L.ClockPosition, LWFLM1L.ReverseSetup, 0.0 AS ReverseSetupDouble, AASL.State, LWFLM1L.LineLateral, null as LinerInstalled  " +
                                           " FROM AM_ASSET_SEWER_LATERAL AASL INNER JOIN "+                                           
                                           "  AM_ASSET_SEWER_SECTION AASS ON AASL.Section_ = AASS.AssetID INNER JOIN "+
                                           "  LFS_WORK LW ON AASS.AssetID = LW.AssetID LEFT JOIN "+
                                           "  LFS_WORK_FULLLENGTHLINING_M1_LATERAL LWFLM1L ON AASL.AssetID = LWFLM1L.Lateral AND LWFLM1L.WorkID = LW.WorkID " +
                                           "WHERE (AASL.Section_ = {0}) AND (LW.WorkID = {1}) AND (LW.ProjectID = {2}) AND (AASL.COMPANY_ID = {3}) AND (AASL.deleted = 0) AND (LWFLM1L.Deleted = 0)", sectionId, workId, projectId, companyId);
            FillData(command);

            return Data;
        }



    }
}