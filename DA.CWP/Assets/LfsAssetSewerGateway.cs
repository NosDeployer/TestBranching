using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.DA.CWP.Assets;

namespace LiquiForce.LFSLive.DA.CWP.Assets
{
    /// <summary>
    /// LfsAssetSewerGateway
    /// </summary>
    public class LfsAssetSewerGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public LfsAssetSewerGateway() : base("LFS_ASSET_SEWER")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public LfsAssetSewerGateway(DataSet data) : base(data, "LFS_ASSET_SEWER")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new LfsAssetsTDS();
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
            tableMapping.DataSetTable = "LFS_ASSET_SEWER";
            tableMapping.ColumnMappings.Add("AssetID", "AssetID");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[LFS_ASSET_SEWER] WHERE (([AssetID] = @Original_AssetID) AND ([" +
                "Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID))";
            this._adapter.DeleteCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_AssetID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "AssetID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Deleted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[LFS_ASSET_SEWER] ([AssetID], [Deleted], [COMPANY_ID]) VALUES (" +
                "@AssetID, @Deleted, @COMPANY_ID);\r\nSELECT AssetID, Deleted, COMPANY_ID FROM LFS_" +
                "ASSET_SEWER WHERE (AssetID = @AssetID)";
            this._adapter.InsertCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AssetID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "AssetID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Deleted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Current, false, null, "", "", ""));

            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = @"UPDATE [dbo].[LFS_ASSET_SEWER] SET [AssetID] = @AssetID, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID WHERE (([AssetID] = @Original_AssetID) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID));
SELECT AssetID, Deleted, COMPANY_ID FROM LFS_ASSET_SEWER WHERE (AssetID = @AssetID)";
            this._adapter.UpdateCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AssetID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "AssetID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Deleted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_AssetID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "AssetID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Deleted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROW
        //

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void Insert(int assetId, bool deleted, int companyId)
        {
            SqlParameter assetIdParameter = new SqlParameter("AssetID", assetId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);

            string command = "INSERT INTO [dbo].[LFS_ASSET_SEWER] ([AssetID], [Deleted], [COMPANY_ID]) VALUES (@AssetID, @Deleted, @COMPANY_ID)";

            ExecuteNonQuery(command, assetIdParameter, deletedParameter, companyIdParameter);
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="originalAssetId">originalAssetId</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        public void Delete(int originalAssetId,  int originalCompanyId)
        {
            SqlParameter originalAssetIdParameter = new SqlParameter("Original_AssetID", originalAssetId);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_ASSET_SEWER] SET  [Deleted] = @Deleted WHERE (([AssetID] = @Original_AssetID)  " +
                             " AND ([COMPANY_ID] = @Original_COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalAssetIdParameter, originalCompanyIdParameter, deletedParameter);
            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }
        }


                  
    }
}
