using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.FullLengthLining
{
    /// <summary>
    /// FlWetOutCatalystsReportGateway
    /// </summary>
    public class FlWetOutCatalystsReportGateway: DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FlWetOutCatalystsReportGateway()
            : base("LFS_WORK_FULLLENGTHLINING_WETOUT_CATALYSTS")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">DataSet</param>
        public FlWetOutCatalystsReportGateway(DataSet data)
            : base(data, "LFS_WORK_FULLLENGTHLINING_WETOUT_CATALYSTS")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new FlWetOutReportTDS();
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
            tableMapping.DataSetTable = "LFS_WORK_FULLLENGTHLINING_WETOUT_CATALYSTS";
            tableMapping.ColumnMappings.Add("WorkID", "WorkID");
            tableMapping.ColumnMappings.Add("RefID", "RefID");
            tableMapping.ColumnMappings.Add("CatalystID", "CatalystID");
            tableMapping.ColumnMappings.Add("PercentageByWeight", "PercentageByWeight");
            tableMapping.ColumnMappings.Add("LbsForMixQuantity", "LbsForMixQuantity");
            tableMapping.ColumnMappings.Add("LbsForDrum", "LbsForDrum");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("Name", "Name");
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
        /// LoadByWorkId
        /// </summary>
        /// <param name="companyId">companyId</param>        
        /// <param name="workId">workId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadByWorkId(int companyId, int workId)
        {
            FillDataWithStoredProcedure("LFS_CWP_FLWETOUTCATALYSTREPORTGATEWAY_LOADBYWORKID", new SqlParameter("@companyId", companyId), new SqlParameter("@workId", workId));
            return Data;
        }

    }
}
