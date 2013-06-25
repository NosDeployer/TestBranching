using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.Common
{
    /// <summary>
    /// BulkUploadGateway
    /// </summary>
    public class BulkUploadGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public BulkUploadGateway()
            : base("BulkUpload")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public BulkUploadGateway(DataSet data)
            : base(data, "BulkUpload")
        {
        }



        /// <summary>
        /// InitData. 
        /// </summary>
        protected override void InitData()
        {
            _data = new BulkUploadTDS();
        }



        /// <summary>
        /// InitAdapter (empty)
        /// </summary>
        protected override void InitAdapter()
        {
            #region Adapter initialization

            this._adapter = new System.Data.SqlClient.SqlDataAdapter();
            System.Data.Common.DataTableMapping tableMapping = new System.Data.Common.DataTableMapping();
            tableMapping.SourceTable = "Table";
            tableMapping.DataSetTable = "BulkUpload";
            tableMapping.ColumnMappings.Add("ID", "ID");
            tableMapping.ColumnMappings.Add("Street", "Street");
            tableMapping.ColumnMappings.Add("ClientID", "ClientID");
            tableMapping.ColumnMappings.Add("SubArea", "SubArea");
            tableMapping.ColumnMappings.Add("USMH", "USMH");
            tableMapping.ColumnMappings.Add("DSMH", "DSMH");
            tableMapping.ColumnMappings.Add("MapSize", "MapSize");
            tableMapping.ColumnMappings.Add("ConfirmedSize", "ConfirmedSize");
            tableMapping.ColumnMappings.Add("MapLength", "MapLength");
            tableMapping.ColumnMappings.Add("ActualLength", "ActualLength");
            tableMapping.ColumnMappings.Add("RAWork", "RAWork");
            tableMapping.ColumnMappings.Add("RAComments", "RAComments");
            tableMapping.ColumnMappings.Add("FLLWork", "FLLWork");
            tableMapping.ColumnMappings.Add("FLLComments", "FLLComments");
            tableMapping.ColumnMappings.Add("JLWork", "JLWork");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            #endregion
        }



    }
}