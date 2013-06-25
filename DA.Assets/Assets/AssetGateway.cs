using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.Assets.Assets
{
    /// <summary>
    /// AssetGateway
    /// </summary>
    public class AssetGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public AssetGateway() : base("AM_ASSET")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public AssetGateway(DataSet data) : base(data, "AM_ASSET")
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
            tableMapping.DataSetTable = "AM_ASSET";
            tableMapping.ColumnMappings.Add("AssetID", "AssetID");
            tableMapping.ColumnMappings.Add("AssetType", "AssetType");
            tableMapping.ColumnMappings.Add("CountryID", "CountryID");
            tableMapping.ColumnMappings.Add("ProvinceID", "ProvinceID");
            tableMapping.ColumnMappings.Add("CountyID", "CountyID");
            tableMapping.ColumnMappings.Add("CityID", "CityID");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = @"DELETE FROM [dbo].[AM_ASSET] WHERE (([AssetID] = @Original_AssetID) AND ([AssetType] = @Original_AssetType) AND ((@IsNull_CountryID = 1 AND [CountryID] IS NULL) OR ([CountryID] = @Original_CountryID)) AND ((@IsNull_ProvinceID = 1 AND [ProvinceID] IS NULL) OR ([ProvinceID] = @Original_ProvinceID)) AND ((@IsNull_CountyID = 1 AND [CountyID] IS NULL) OR ([CountyID] = @Original_CountyID)) AND ((@IsNull_CityID = 1 AND [CityID] IS NULL) OR ([CityID] = @Original_CityID)) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID))";
            this._adapter.DeleteCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_AssetID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "AssetID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_AssetType", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "AssetType", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_CountryID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "CountryID", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CountryID", System.Data.SqlDbType.BigInt, 0, System.Data.ParameterDirection.Input, 0, 0, "CountryID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_ProvinceID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ProvinceID", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ProvinceID", System.Data.SqlDbType.BigInt, 0, System.Data.ParameterDirection.Input, 0, 0, "ProvinceID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_CountyID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "CountyID", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CountyID", System.Data.SqlDbType.BigInt, 0, System.Data.ParameterDirection.Input, 0, 0, "CountyID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_CityID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "CityID", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CityID", System.Data.SqlDbType.BigInt, 0, System.Data.ParameterDirection.Input, 0, 0, "CityID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Deleted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            
            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[AM_ASSET] ([AssetType], [CountryID], [ProvinceID], [CountyID], [CityID], [Deleted], [COMPANY_ID]) VALUES (@AssetType, @CountryID, @ProvinceID, @CountyID, @CityID, @Deleted, @COMPANY_ID);
SELECT AssetID, AssetType, CountryID, ProvinceID, CountyID, CityID, Deleted, COMPANY_ID FROM AM_ASSET WHERE (AssetID = SCOPE_IDENTITY())";
            this._adapter.InsertCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AssetType", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "AssetType", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CountryID", System.Data.SqlDbType.BigInt, 0, System.Data.ParameterDirection.Input, 0, 0, "CountryID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ProvinceID", System.Data.SqlDbType.BigInt, 0, System.Data.ParameterDirection.Input, 0, 0, "ProvinceID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CountyID", System.Data.SqlDbType.BigInt, 0, System.Data.ParameterDirection.Input, 0, 0, "CountyID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CityID", System.Data.SqlDbType.BigInt, 0, System.Data.ParameterDirection.Input, 0, 0, "CityID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Deleted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            
            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = @"UPDATE [dbo].[AM_ASSET] SET [AssetType] = @AssetType, [CountryID] = @CountryID, [ProvinceID] = @ProvinceID, [CountyID] = @CountyID, [CityID] = @CityID, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID WHERE (([AssetID] = @Original_AssetID) AND ([AssetType] = @Original_AssetType) AND ((@IsNull_CountryID = 1 AND [CountryID] IS NULL) OR ([CountryID] = @Original_CountryID)) AND ((@IsNull_ProvinceID = 1 AND [ProvinceID] IS NULL) OR ([ProvinceID] = @Original_ProvinceID)) AND ((@IsNull_CountyID = 1 AND [CountyID] IS NULL) OR ([CountyID] = @Original_CountyID)) AND ((@IsNull_CityID = 1 AND [CityID] IS NULL) OR ([CityID] = @Original_CityID)) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID));
SELECT AssetID, AssetType, CountryID, ProvinceID, CountyID, CityID, Deleted, COMPANY_ID FROM AM_ASSET WHERE (AssetID = @AssetID)";
            this._adapter.UpdateCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AssetType", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "AssetType", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CountryID", System.Data.SqlDbType.BigInt, 0, System.Data.ParameterDirection.Input, 0, 0, "CountryID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ProvinceID", System.Data.SqlDbType.BigInt, 0, System.Data.ParameterDirection.Input, 0, 0, "ProvinceID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CountyID", System.Data.SqlDbType.BigInt, 0, System.Data.ParameterDirection.Input, 0, 0, "CountyID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CityID", System.Data.SqlDbType.BigInt, 0, System.Data.ParameterDirection.Input, 0, 0, "CityID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Deleted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_AssetID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "AssetID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_AssetType", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "AssetType", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_CountryID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "CountryID", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CountryID", System.Data.SqlDbType.BigInt, 0, System.Data.ParameterDirection.Input, 0, 0, "CountryID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_ProvinceID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ProvinceID", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ProvinceID", System.Data.SqlDbType.BigInt, 0, System.Data.ParameterDirection.Input, 0, 0, "ProvinceID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_CountyID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "CountyID", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CountyID", System.Data.SqlDbType.BigInt, 0, System.Data.ParameterDirection.Input, 0, 0, "CountyID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_CityID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "CityID", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CityID", System.Data.SqlDbType.BigInt, 0, System.Data.ParameterDirection.Input, 0, 0, "CityID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Deleted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AssetID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, 0, 0, "AssetID", System.Data.DataRowVersion.Current, false, null, "", "", ""));

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            #endregion
        }





                       
        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROW
        //


        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="assetType">assetType</param>
        /// <param name="countryId">countryId</param>
        /// <param name="provinceId">provinceId</param>
        /// <param name="countyId">countyId</param>
        /// <param name="cityId">cityId</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <returns>asset Id</returns>
        public int Insert(string assetType, Int64? countryId, Int64? provinceId, Int64? countyId, Int64? cityId, bool deleted, int companyId)
        {
            SqlParameter assetTypeParameter = new SqlParameter("AssetType", assetType);
            SqlParameter countryIdParameter = (countryId.HasValue) ? new SqlParameter("CountryID", (Int64)countryId) : new SqlParameter("CountryID", DBNull.Value);
            SqlParameter provinceIdParameter = (provinceId.HasValue) ? new SqlParameter("ProvinceID", (Int64)provinceId) : new SqlParameter("ProvinceID", DBNull.Value);
            SqlParameter countyIdParameter = (countyId.HasValue) ? new SqlParameter("CountyID", (Int64)countyId) : new SqlParameter("CountyID", DBNull.Value);
            SqlParameter cityIdParameter = (cityId.HasValue) ? new SqlParameter("CityID", (Int64)cityId) : new SqlParameter("CityID", DBNull.Value);
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);

            string command = "INSERT INTO [dbo].[AM_ASSET] ([AssetType], [CountryID], [ProvinceID], [CountyID], [CityID], [Deleted], [COMPANY_ID]) VALUES (@AssetType, @CountryID, @ProvinceID, @CountyID, @CityID, @Deleted, @COMPANY_ID); SELECT AssetID FROM AM_ASSET WHERE (AssetID = SCOPE_IDENTITY())";

            int assetId = (int)ExecuteScalar(command, assetTypeParameter, countryIdParameter, provinceIdParameter, countyIdParameter, cityIdParameter, deletedParameter, companyIdParameter);

            return assetId;
        }



        /// <summary>
        /// delete
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="companyId">companyId</param>
        public void Delete(int assetId, int companyId)
        {
            SqlParameter assetIdParameter = new SqlParameter("AssetID", assetId);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[AM_ASSET] SET  [Deleted] = @Deleted WHERE (([AssetID] = @AssetID) AND ([COMPANY_ID] = @COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery( command, assetIdParameter, companyIdParameter, deletedParameter);
            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }
        }

        

    }
}