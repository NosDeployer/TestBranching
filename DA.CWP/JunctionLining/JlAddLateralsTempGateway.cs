using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.JunctionLining
{
    /// <summary>
    /// JlAddLateralsTempGateway
    /// </summary>
    public class JlAddLateralsTempGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public JlAddLateralsTempGateway() : base("JlAddLateralsTemp")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public JlAddLateralsTempGateway(DataSet data) : base(data, "JlAddLateralsTemp")
        {
        }



        /// <summary>
        /// InitData. 
        /// </summary>
        protected override void InitData()
        {
            _data = new JlAddLateralsTDS();
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
            tableMapping.DataSetTable = "JlAddLateralsTemp";
            tableMapping.ColumnMappings.Add("ID", "ID");
            tableMapping.ColumnMappings.Add("AssetID", "AssetID");
            tableMapping.ColumnMappings.Add("SectionWorkID", "SectionWorkID");
            tableMapping.ColumnMappings.Add("SectionAssetID", "SectionAssetID");
            tableMapping.ColumnMappings.Add("SectionID", "SectionID");
            tableMapping.ColumnMappings.Add("LateralID", "LateralID");
            tableMapping.ColumnMappings.Add("Address", "Address");
            tableMapping.ColumnMappings.Add("DistanceFromUSMH", "DistanceFromUSMH");
            tableMapping.ColumnMappings.Add("DistanceFromDSMH", "DistanceFromDSMH");
            tableMapping.ColumnMappings.Add("State", "State");
            tableMapping.ColumnMappings.Add("InProject", "InProject");
            tableMapping.ColumnMappings.Add("InProjectDatabase", "InProjectDatabase");
            tableMapping.ColumnMappings.Add("InDatabase", "InDatabase");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");

            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            #endregion
        }
    }
}

