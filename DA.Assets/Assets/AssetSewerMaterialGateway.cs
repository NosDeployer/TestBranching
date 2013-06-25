using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Assets.Assets
{
    /// <summary>
    /// AssetSewerMaterialGateway
    /// </summary>
    public class AssetSewerMaterialGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public AssetSewerMaterialGateway()
            : base("AM_ASSET_SEWER_MATERIAL")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public AssetSewerMaterialGateway(DataSet data)
            : base(data, "AM_ASSET_SEWER_MATERIAL")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new AssetsTDS();
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
            tableMapping.DataSetTable = "AM_ASSET_SEWER_MATERIAL";
            tableMapping.ColumnMappings.Add("AssetID", "AssetID");
            tableMapping.ColumnMappings.Add("RefID", "RefID");
            tableMapping.ColumnMappings.Add("MaterialType", "MaterialType");
            tableMapping.ColumnMappings.Add("Date_", "Date_");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = @"DELETE FROM [dbo].[AM_ASSET_SEWER_MATERIAL] WHERE (([AssetID] = @Original_AssetID) AND ([RefID] = @Original_RefID) AND ([MaterialType] = @Original_MaterialType) AND ([Date_] = @Original_Date_) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND ([Deleted] = @Original_Deleted))";
            this._adapter.DeleteCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_AssetID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "AssetID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RefID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "RefID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_MaterialType", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "MaterialType", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Date_", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "Date_", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Deleted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[AM_ASSET_SEWER_MATERIAL] ([AssetID], [RefID], [MaterialType], [Date_], [COMPANY_ID], [Deleted]) VALUES (@AssetID, @RefID, @MaterialType, @Date_, @COMPANY_ID, @Deleted);
SELECT AssetID, RefID, MaterialType, Date_, COMPANY_ID, Deleted FROM AM_ASSET_SEWER_MATERIAL WHERE (AssetID = @AssetID) AND (RefID = @RefID)";
            this._adapter.InsertCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AssetID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "AssetID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RefID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "RefID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MaterialType", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "MaterialType", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Date_", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "Date_", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Deleted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Current, false, null, "", "", ""));

            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = @"UPDATE [dbo].[AM_ASSET_SEWER_MATERIAL] SET [AssetID] = @AssetID, [RefID] = @RefID, [MaterialType] = @MaterialType, [Date_] = @Date_, [COMPANY_ID] = @COMPANY_ID, [Deleted] = @Deleted WHERE (([AssetID] = @Original_AssetID) AND ([RefID] = @Original_RefID) AND ([MaterialType] = @Original_MaterialType) AND ([Date_] = @Original_Date_) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND ([Deleted] = @Original_Deleted));
SELECT AssetID, RefID, MaterialType, Date_, COMPANY_ID, Deleted FROM AM_ASSET_SEWER_MATERIAL WHERE (AssetID = @AssetID) AND (RefID = @RefID)";
            this._adapter.UpdateCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AssetID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "AssetID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RefID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "RefID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MaterialType", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "MaterialType", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Date_", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "Date_", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Deleted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_AssetID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "AssetID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RefID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "RefID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_MaterialType", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "MaterialType", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Date_", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "Date_", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Deleted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Original, false, null, "", "", ""));

            #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROWS
        //

        /// <summary>
        /// Insert all materials
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="refId">refId</param>
        /// <param name="materialType">materialType</param>
        /// <param name="date_">date_</param>
        /// <param name="companyId">companyId</param>
        /// <param name="deleted">deleted</param>
        public void Insert(int assetId, int refId, string materialType, DateTime? date_, bool deleted, int companyId)
        {
            SqlParameter assetIdParameter = new SqlParameter("AssetID", assetId);
            SqlParameter refIdParameter = new SqlParameter("RefID", refId);
            SqlParameter materialTypeParameter = (materialType.Trim() != "") ? new SqlParameter("MaterialType", materialType.Trim()) : new SqlParameter("MaterialType", DBNull.Value);
            SqlParameter dateTypeParameter = (date_.HasValue) ? new SqlParameter("Date_", date_) : new SqlParameter("Date_", DBNull.Value);
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);

            string command = "INSERT INTO [dbo].[AM_ASSET_SEWER_MATERIAL] ([AssetID], [RefID], " +
                 " [MaterialType], [Date_], [COMPANY_ID], [Deleted]) VALUES (@AssetID, @RefID, " +
                 " @MaterialType, @Date_, @COMPANY_ID, @Deleted)";

            int rowsAffected = (int)ExecuteNonQuery(command, assetIdParameter, refIdParameter, materialTypeParameter, dateTypeParameter, companyIdParameter, deletedParameter);
        }



        /// <summary>
        /// Update material (direct to DB)
        /// </summary>
        /// <param name="originalAssetId">originalAssetId</param>
        /// <param name="originalRefId">originalRefId</param>
        /// <param name="originalMaterialType">originalMaterialType</param>
        /// <param name="originalDate">originalDate</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalDeleted">originalDeleted</param>        
        /// 
        /// <param name="newAssetId">newAssetId</param>
        /// <param name="newRefId">newRefId</param>
        /// <param name="newMaterialType">newMaterialType</param>
        /// <param name="newDate">newDate</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newDeleted">newDeleted</param>   
        /// <returns>rowsAffected</returns>
        public int Update(int originalAssetId, int originalRefId, string originalMaterialType, DateTime originalDate, int originalCompanyId, bool originalDeleted, int newAssetId, int newRefId, string newMaterialType, DateTime newDate, int newCompanyId, bool newDeleted)
        {
            SqlParameter originalAssetIdParameter = new SqlParameter("Original_AssetID", originalAssetId);
            SqlParameter originalRefIdParameter = new SqlParameter("Original_RefID", originalRefId);
            SqlParameter originalMaterialTypeParameter = new SqlParameter("Original_MaterialType", originalMaterialType);
            SqlParameter originalDateParameter = new SqlParameter("Original_Date_", originalDate);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);


            SqlParameter newAssetIdParameter = new SqlParameter("AssetID", newAssetId);
            SqlParameter newRefIdParameter = new SqlParameter("RefID", originalRefId);
            SqlParameter newMaterialTypeParameter = new SqlParameter("MaterialType", newMaterialType);
            SqlParameter newDateParameter = new SqlParameter("Date_", newDate);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);

            string command = "UPDATE [dbo].[AM_ASSET_SEWER_MATERIAL] " +
                " SET [AssetID] = @AssetID, [RefID] = @RefID, [MaterialType] = @MaterialType, " +
                " [Date_] = @Date_, [COMPANY_ID] = @COMPANY_ID, [Deleted] = @Deleted " +
                " WHERE (([AssetID] = @Original_AssetID) AND ([RefID] = @Original_RefID) AND " +
                " ([COMPANY_ID] = @Original_COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalAssetIdParameter, originalRefIdParameter, originalMaterialTypeParameter, originalDateParameter, originalDeletedParameter, originalCompanyIdParameter, newAssetIdParameter, newRefIdParameter, newMaterialTypeParameter, newDateParameter, newDeletedParameter, newCompanyIdParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }



        /// <summary>
        /// Delete all materials
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        public void Delete(int assetId, int refId, int companyId)
        {
            SqlParameter assetIdParameter = new SqlParameter("AssetID", assetId);
            SqlParameter refIdParameter = new SqlParameter("RefID", refId);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[AM_ASSET_SEWER_MATERIAL] SET  [Deleted] = @Deleted " +
                " WHERE (([AssetID] = @AssetID) AND ([RefID] = @RefID) AND ([COMPANY_ID] = @COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, assetIdParameter, refIdParameter, companyIdParameter, deletedParameter);
        }



        /// <summary>
        /// Delete all materials
        /// </summary>
        /// <param name="assetId">assetId</param>        
        /// <param name="companyId">companyId</param>
        public void DeleteAll(int assetId, int companyId)
        {
            SqlParameter assetIdParameter = new SqlParameter("AssetID", assetId);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[AM_ASSET_SEWER_MATERIAL] SET  [Deleted] = @Deleted " +
                " WHERE (([AssetID] = @AssetID) AND  ([COMPANY_ID] = @COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, assetIdParameter, companyIdParameter, deletedParameter);
        }


    }
}
