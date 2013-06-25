using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.DA.CWP.Assets;

namespace LiquiForce.LFSLive.DA.CWP.Assets
{
    /// <summary>
    /// LfsAssetSewerLateralClientGateway
    /// </summary>
    public class LfsAssetSewerLateralClientGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public LfsAssetSewerLateralClientGateway() : base("LFS_ASSET_SEWER_LATERAL_CLIENT")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public LfsAssetSewerLateralClientGateway(DataSet data)
            : base(data, "LFS_ASSET_SEWER_LATERAL_CLIENT")
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
            tableMapping.DataSetTable = "LFS_ASSET_SEWER_LATERAL_CLIENT";
            tableMapping.ColumnMappings.Add("AssetID", "AssetID");
            tableMapping.ColumnMappings.Add("ClientID", "ClientID");
            tableMapping.ColumnMappings.Add("ClientLateralID", "ClientLateralID");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = @"DELETE FROM [dbo].[LFS_ASSET_SEWER_LATERAL_CLIENT] WHERE (([AssetID] = @Original_AssetID) AND ([ClientID] = @Original_ClientID) AND ((@IsNull_ClientLateralID = 1 AND [ClientLateralID] IS NULL) OR ([ClientLateralID] = @Original_ClientLateralID)) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_AssetID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AssetID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ClientID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ClientID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_ClientLateralID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ClientLateralID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ClientLateralID", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ClientLateralID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_ASSET_SEWER_LATERAL_CLIENT] ([AssetID], [ClientID], [ClientLateralID], [Deleted], [COMPANY_ID]) VALUES (@AssetID, @ClientID, @ClientLateralID, @Deleted, @COMPANY_ID);
SELECT AssetID, ClientID, ClientLateralID, Deleted, COMPANY_ID FROM LFS_ASSET_SEWER_LATERAL_CLIENT WHERE (AssetID = @AssetID) AND (ClientID = @ClientID)";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@AssetID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AssetID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ClientID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ClientID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ClientLateralID", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ClientLateralID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));

            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = @"UPDATE [dbo].[LFS_ASSET_SEWER_LATERAL_CLIENT] SET [AssetID] = @AssetID, [ClientID] = @ClientID, [ClientLateralID] = @ClientLateralID, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID WHERE (([AssetID] = @Original_AssetID) AND ([ClientID] = @Original_ClientID) AND ((@IsNull_ClientLateralID = 1 AND [ClientLateralID] IS NULL) OR ([ClientLateralID] = @Original_ClientLateralID)) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID));
SELECT AssetID, ClientID, ClientLateralID, Deleted, COMPANY_ID FROM LFS_ASSET_SEWER_LATERAL_CLIENT WHERE (AssetID = @AssetID) AND (ClientID = @ClientID)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@AssetID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AssetID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ClientID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ClientID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ClientLateralID", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ClientLateralID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_AssetID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AssetID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ClientID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ClientID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_ClientLateralID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ClientLateralID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ClientLateralID", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ClientLateralID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// LoadAllByAssetIdClientId
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="clientId">clientId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>data set</returns>
        public DataSet LoadAllByAssetIdClientId(int assetId, int clientId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_LFSASSETSEWERLATERALCLIENTGATEWAY_LOADALLBYASSETIDCLIENTID", new SqlParameter("@assetId", assetId), new SqlParameter("@clientId", clientId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByAssetIdClientId
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="clientId">clientId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>data set</returns>
        public DataSet LoadByAssetIdClientId(int assetId, int clientId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_LFSASSETSEWERLATERALCLIENTGATEWAY_LOADBYASSETIDCLIENTID", new SqlParameter("@assetId", assetId), new SqlParameter("@clientId", clientId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="clienId">clienId</param>
        /// <returns>data</returns>
        public DataRow GetRow(int assetId, int clienId)
        {
            string filter = string.Format("(AssetID = {0}) AND (ClientID = {1}) ", assetId, clienId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.CWP.Assets.LfsAssetSewerLateralClientGateway.GetRow");
            }

        }



        /// <summary>
        /// GetClientLateralId
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="clientId">clientId</param>
        /// <returns>ClientLateralId or EMPTY</returns>
        public string GetClientLateralId(int assetId, int clientId)
        {
            if (GetRow(assetId, clientId).IsNull("ClientLateralID"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId, clientId)["ClientLateralID"];
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - QUERIES
        //

        /// <summary>
        /// Verify if a lateral has ClientLateralID
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="clientId">clientId</param>
        /// <param name="companyId">companyId</param>
        /// <returns></returns>
        public bool ExistClientLateralId(int assetId, int clientId, int companyId)
        {
            SqlParameter assetIdParameter = new SqlParameter("assetId", assetId);
            SqlParameter clientIdParameter = new SqlParameter("clientId", clientId);
            SqlParameter companyIdParameter = new SqlParameter("companyId", companyId);

            string command = "SELECT COUNT(*) FROM dbo.LFS_ASSET_SEWER_LATERAL_CLIENT WHERE (Deleted = 0) AND (AssetID = @assetId) AND (ClientID = @clientId) AND (COMPANY_ID = @companyId)";

            int count = (int)ExecuteScalar(command, assetIdParameter, clientIdParameter, companyIdParameter);

            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROWS
        //

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="clientId">clientId</param>
        /// <param name="clientLateralId">clientLateralId</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void Insert(int assetId, int clientId, string clientLateralId, bool deleted, int companyId)
        {
            SqlParameter assetIdParameter = new SqlParameter("AssetID", assetId);
            SqlParameter clientIdParameter = new SqlParameter("ClientID", clientId);
            SqlParameter clientLateralIdParameter = (clientLateralId.Trim() != "") ? new SqlParameter("ClientLateralID", clientLateralId.Trim()) : new SqlParameter("ClientLateralID", DBNull.Value);
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            
            string command = "INSERT INTO [dbo].[LFS_ASSET_SEWER_LATERAL_CLIENT] ([AssetID], [ClientID], [ClientLateralID], [Deleted], [COMPANY_ID]) VALUES (@AssetID, @ClientID, @ClientLateralID, @Deleted, @COMPANY_ID)";

            ExecuteNonQuery(command, assetIdParameter, clientIdParameter, clientLateralIdParameter, deletedParameter, companyIdParameter);
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="clientId">clientId</param>
        /// <param name="companyId">companyId</param>
        public void Delete(int assetId, int clientId, int companyId)
        {
            SqlParameter assetIdParameter = new SqlParameter("AssetID", assetId);
            SqlParameter clientIdParameter = new SqlParameter("ClientID", clientId);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_ASSET_SEWER_LATERAL_CLIENT] " +
                    " SET " +
                    "[Deleted] = @Deleted " +
                    "WHERE (([AssetID] = @AssetID) AND ([ClientID] = @ClientID) AND " +
                    "([COMPANY_ID] = @COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, assetIdParameter, clientIdParameter, companyIdParameter, deletedParameter);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="originalAssetId">originalAssetId</param>
        /// <param name="originalClientId">originalClientId</param>
        /// <param name="originalClientLateralId">originalClientLateralId</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="newAssetId">newAssetId</param>
        /// <param name="newClientId">newClientId</param>
        /// <param name="newClientLateralId">newClientLateralId</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        public void Update(int originalAssetId, int originalClientId, string originalClientLateralId, bool originalDeleted, int originalCompanyId, int newAssetId, int newClientId, string newClientLateralId, bool newDeleted, int newCompanyId)
        {
            SqlParameter originalAssetIdParameter = new SqlParameter("Original_AssetID", originalAssetId);
            SqlParameter originalClientIdParameter = new SqlParameter("Original_ClientID", originalClientId);

            SqlParameter newAssetIdParameter = new SqlParameter("AssetId", newAssetId);
            SqlParameter newClientIdParameter = new SqlParameter("ClientID", newClientId);
            SqlParameter newClientLateralIdParameter = (newClientLateralId.Trim() != "") ? new SqlParameter("ClientLateralID", newClientLateralId.Trim()) : new SqlParameter("ClientLateralID", DBNull.Value);
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);

            string command = "UPDATE [dbo].[LFS_ASSET_SEWER_LATERAL_CLIENT] " +
                             "SET [ClientLateralID] = @ClientLateralID, [Deleted] = @Deleted " +                             
                             "WHERE ([AssetID] = @Original_AssetID) AND ([ClientID] = @Original_ClientID) AND " +
                             "([COMPANY_ID] = @COMPANY_ID)";

            int rowsAffected = (int)ExecuteNonQuery(command, newAssetIdParameter, newClientIdParameter, newClientLateralIdParameter, newDeletedParameter, newCompanyIdParameter, originalAssetIdParameter, originalClientIdParameter);
        }



    }
}