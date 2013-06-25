using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.JunctionLining
{
    /// <summary>
    /// JlAddLateralsNewGateway
    /// </summary>
    public class JlAddLateralsNewGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public JlAddLateralsNewGateway() : base("JlAddLateralsNew")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public JlAddLateralsNewGateway(DataSet data) : base(data, "JlAddLateralsNew")
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
            tableMapping.DataSetTable = "JlAddLateralsNew";
            tableMapping.ColumnMappings.Add("AssetID", "AssetID");
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






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// LoadBySection_ProjectID
        /// </summary>
        /// <param name="section_">section_</param>
        /// <param name="projectId">projectId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Dataset</returns>
        public DataSet LoadBySection_ProjectID(int section_, int projectId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_JLADDLATERALSNEWGATEWAY_LOADBYSECTION_PROJECTID", new SqlParameter("@section_", section_), new SqlParameter("@projectId", projectId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int assetId)
        {
            string filter = string.Format("AssetID = {0}", assetId.ToString());

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.CWP.JunctionLining.JlAddLateralsNewGateway.GetRow");
            }
        }



        /// <summary>
        /// GetState
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>State</returns>
        public string GetState(int assetId)
        {
            return (string)GetRow(assetId)["State"];
        }



        /// <summary>
        /// GetInProject
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>InProject</returns>
        public bool GetInProject(int assetId)
        {
            return (bool)GetRow(assetId)["InProject"];
        }



        /// <summary>
        /// GetInProjectDatabase
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>InProjectDatabase</returns>
        public bool GetInProjectDatabase(int assetId)
        {
            return (bool)GetRow(assetId)["InProjectDatabase"];
        }



        /// <summary>
        /// GetInDatabase
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>InDatabase</returns>
        public bool GetInDatabase(int assetId)
        {
            return (bool)GetRow(assetId)["InDatabase"];
        }







    }
}

