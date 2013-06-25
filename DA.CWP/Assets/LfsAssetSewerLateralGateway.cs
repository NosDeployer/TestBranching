using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.CWP.Assets
{
    /// <summary>
    /// LfsAssetSewerLateralGateway
    /// </summary>
    public class LfsAssetSewerLateralGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public LfsAssetSewerLateralGateway() : base("LFS_ASSET_SEWER_LATERAL")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public LfsAssetSewerLateralGateway(DataSet data) : base(data, "LFS_ASSET_SEWER_LATERAL")
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
            tableMapping.DataSetTable = "LFS_ASSET_SEWER_LATERAL";
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
            this._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[LFS_ASSET_SEWER_LATERAL] WHERE (([AssetID] = @Original_AssetID" +
                ") AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID))" +
                "";
            this._adapter.DeleteCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_AssetID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "AssetID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Deleted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[LFS_ASSET_SEWER_LATERAL] ([AssetID], [Deleted], [COMPANY_ID]) " +
                "VALUES (@AssetID, @Deleted, @COMPANY_ID);\r\nSELECT AssetID, Deleted, COMPANY_ID F" +
                "ROM LFS_ASSET_SEWER_LATERAL WHERE (AssetID = @AssetID)";
            this._adapter.InsertCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AssetID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "AssetID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Deleted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Current, false, null, "", "", ""));

            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = @"UPDATE [dbo].[LFS_ASSET_SEWER_LATERAL] SET [AssetID] = @AssetID, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID WHERE (([AssetID] = @Original_AssetID) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID));
SELECT AssetID, Deleted, COMPANY_ID FROM LFS_ASSET_SEWER_LATERAL WHERE (AssetID = @AssetID)";
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
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// LoadByAssetId
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>data set</returns>
        public DataSet LoadByAssetId(int assetId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_LFSASSETSEWERLATERALGATEWAY_LOADBYASSETID", new SqlParameter("@assetId", assetId), new SqlParameter("@companyId", companyId));
            return Data;
        }







        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - QUERIES
        //

        /// <summary>
        /// Verify if a lateral is in use in FLL - M1 - Lateral
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="companyId">companyId</param>
        /// <returns></returns>
        public bool InUseFLM1(int assetId, int companyId)
        {
            string commandText = "SELECT COUNT(*) AS Count FROM dbo.LFS_WORK_FULLLENGTHLINING_M1_LATERAL " +
                " WHERE (Deleted = 0) AND (Lateral = @assetId) AND (COMPANY_ID = @companyId)";

            SqlCommand command = new SqlCommand(commandText, DB.Connection);
            command.Parameters.Add(new SqlParameter("@assetId", assetId));
            command.Parameters.Add(new SqlParameter("@companyId", companyId));

            int count = (int)ExecuteScalar(command);

            return (count > 0) ? true : false;
        }



        /// <summary>
        /// IsUsedInMaterials
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="materialType">materialType</param>
        /// <param name="companyId">companyId</param>
        /// <returns>TRUE if is used</returns>
        public bool IsUsedInMaterials(int assetId, string materialType, int companyId)
        {
            string commandText = "SELECT COUNT(*) FROM AM_ASSET_SEWER_MATERIAL WHERE (AssetID = @assetId) AND (MaterialType = @materialType) AND (COMPANY_ID = @companyId) ";
            SqlCommand command = new SqlCommand(commandText, DB.Connection);
            command.Parameters.Add(new SqlParameter("@assetId", assetId));
            command.Parameters.Add(new SqlParameter("@materialType", materialType));
            command.Parameters.Add(new SqlParameter("@companyId", companyId));

            return ((int)ExecuteScalar(command) > 0) ? true : false;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROWS
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

            string command = "INSERT INTO [dbo].[LFS_ASSET_SEWER_LATERAL] ([AssetID], [Deleted], [COMPANY_ID]) VALUES (@AssetID, @Deleted, @COMPANY_ID)";

            ExecuteNonQuery(command, assetIdParameter, deletedParameter, companyIdParameter);
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="companyId">companyId</param>
        public void Delete(int assetId, int companyId)
        {
            SqlParameter assetIdParameter = new SqlParameter("AssetID", assetId);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_ASSET_SEWER_LATERAL] " +
                    " SET " +
                    "[Deleted] = @Deleted " +
                    "WHERE (([AssetID] = @AssetID) AND " +
                    "([COMPANY_ID] = @COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, assetIdParameter, companyIdParameter, deletedParameter);
            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }
        }



    }
}