using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Assets.Assets
{
    /// <summary>
    /// AssetSewerLateralGateway
    /// </summary>
    public class AssetSewerLateralGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public AssetSewerLateralGateway() : base("AM_ASSET_SEWER_LATERAL")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public AssetSewerLateralGateway(DataSet data) : base(data, "AM_ASSET_SEWER_LATERAL")
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
            tableMapping.DataSetTable = "AM_ASSET_SEWER_LATERAL";
            tableMapping.ColumnMappings.Add("AssetID", "AssetID");
            tableMapping.ColumnMappings.Add("Section_", "Section_");
            tableMapping.ColumnMappings.Add("Address", "Address");
            tableMapping.ColumnMappings.Add("LateralID", "LateralID");
            tableMapping.ColumnMappings.Add("LatitudeAtSection", "LatitudeAtSection");
            tableMapping.ColumnMappings.Add("LongitudeAtSection", "LongitudeAtSection");
            tableMapping.ColumnMappings.Add("LatitudeAtPropertyLine", "LatitudeAtPropertyLine");
            tableMapping.ColumnMappings.Add("LongitudeAtPropertyLine", "LongitudeAtPropertyLine");
            tableMapping.ColumnMappings.Add("State", "State");
            tableMapping.ColumnMappings.Add("Size_", "Size_");
            tableMapping.ColumnMappings.Add("DistanceFromUSMH", "DistanceFromUSMH");
            tableMapping.ColumnMappings.Add("DistanceFromDSMH", "DistanceFromDSMH");
            tableMapping.ColumnMappings.Add("MapSize", "MapSize");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("ConnectionType", "ConnectionType");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = @"DELETE FROM [dbo].[AM_ASSET_SEWER_LATERAL] WHERE (([AssetID] = @Original_AssetID) AND ([Section_] = @Original_Section_) AND ((@IsNull_Address = 1 AND [Address] IS NULL) OR ([Address] = @Original_Address)) AND ([LateralID] = @Original_LateralID) AND ((@IsNull_LatitudeAtSection = 1 AND [LatitudeAtSection] IS NULL) OR ([LatitudeAtSection] = @Original_LatitudeAtSection)) AND ((@IsNull_LongitudeAtSection = 1 AND [LongitudeAtSection] IS NULL) OR ([LongitudeAtSection] = @Original_LongitudeAtSection)) AND ((@IsNull_LatitudeAtPropertyLine = 1 AND [LatitudeAtPropertyLine] IS NULL) OR ([LatitudeAtPropertyLine] = @Original_LatitudeAtPropertyLine)) AND ((@IsNull_LongitudeAtPropertyLine = 1 AND [LongitudeAtPropertyLine] IS NULL) OR ([LongitudeAtPropertyLine] = @Original_LongitudeAtPropertyLine)) AND ([State] = @Original_State) AND ((@IsNull_Size_ = 1 AND [Size_] IS NULL) OR ([Size_] = @Original_Size_)) AND ((@IsNull_DistanceFromUSMH = 1 AND [DistanceFromUSMH] IS NULL) OR ([DistanceFromUSMH] = @Original_DistanceFromUSMH)) AND ((@IsNull_DistanceFromDSMH = 1 AND [DistanceFromDSMH] IS NULL) OR ([DistanceFromDSMH] = @Original_DistanceFromDSMH)) AND ((@IsNull_MapSize = 1 AND [MapSize] IS NULL) OR ([MapSize] = @Original_MapSize)) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND ((@IsNull_ConnectionType = 1 AND [ConnectionType] IS NULL) OR ([ConnectionType] = @Original_ConnectionType)))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_AssetID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AssetID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Section_", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Section_", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Address", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Address", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Address", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Address", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LateralID", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LateralID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_LatitudeAtSection", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LatitudeAtSection", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LatitudeAtSection", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LatitudeAtSection", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_LongitudeAtSection", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LongitudeAtSection", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LongitudeAtSection", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LongitudeAtSection", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_LatitudeAtPropertyLine", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LatitudeAtPropertyLine", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LatitudeAtPropertyLine", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LatitudeAtPropertyLine", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_LongitudeAtPropertyLine", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LongitudeAtPropertyLine", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LongitudeAtPropertyLine", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LongitudeAtPropertyLine", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_State", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "State", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Size_", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Size_", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Size_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Size_", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DistanceFromUSMH", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DistanceFromUSMH", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DistanceFromUSMH", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DistanceFromUSMH", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DistanceFromDSMH", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DistanceFromDSMH", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DistanceFromDSMH", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DistanceFromDSMH", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_MapSize", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MapSize", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MapSize", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MapSize", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_ConnectionType", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ConnectionType", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ConnectionType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ConnectionType", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[AM_ASSET_SEWER_LATERAL] ([AssetID], [Section_], [Address], [LateralID], [LatitudeAtSection], [LongitudeAtSection], [LatitudeAtPropertyLine], [LongitudeAtPropertyLine], [State], [Size_], [DistanceFromUSMH], [DistanceFromDSMH], [MapSize], [Deleted], [COMPANY_ID], [ConnectionType]) VALUES (@AssetID, @Section_, @Address, @LateralID, @LatitudeAtSection, @LongitudeAtSection, @LatitudeAtPropertyLine, @LongitudeAtPropertyLine, @State, @Size_, @DistanceFromUSMH, @DistanceFromDSMH, @MapSize, @Deleted, @COMPANY_ID, @ConnectionType);
SELECT AssetID, Section_, Address, LateralID, LatitudeAtSection, LongitudeAtSection, LatitudeAtPropertyLine, LongitudeAtPropertyLine, State, Size_, DistanceFromUSMH, DistanceFromDSMH, MapSize, Deleted, COMPANY_ID, ConnectionType FROM AM_ASSET_SEWER_LATERAL WHERE (AssetID = @AssetID)";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@AssetID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AssetID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Section_", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Section_", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Address", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Address", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LateralID", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LateralID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LatitudeAtSection", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LatitudeAtSection", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LongitudeAtSection", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LongitudeAtSection", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LatitudeAtPropertyLine", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LatitudeAtPropertyLine", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LongitudeAtPropertyLine", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LongitudeAtPropertyLine", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@State", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "State", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Size_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Size_", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DistanceFromUSMH", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DistanceFromUSMH", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DistanceFromDSMH", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DistanceFromDSMH", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MapSize", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MapSize", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ConnectionType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ConnectionType", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));

            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[AM_ASSET_SEWER_LATERAL] SET [AssetID] = @AssetID, [Section_] = @Sec" +
                "tion_, [Address] = @Address, [LateralID] = @LateralID, [LatitudeAtSection] = @La" +
                "titudeAtSection, [LongitudeAtSection] = @LongitudeAtSection, [LatitudeAtProperty" +
                "Line] = @LatitudeAtPropertyLine, [LongitudeAtPropertyLine] = @LongitudeAtPropert" +
                "yLine, [State] = @State, [Size_] = @Size_, [DistanceFromUSMH] = @DistanceFromUSM" +
                "H, [DistanceFromDSMH] = @DistanceFromDSMH, [MapSize] = @MapSize, [Deleted] = @De" +
                "leted, [COMPANY_ID] = @COMPANY_ID, [ConnectionType] = @ConnectionType WHERE (([A" +
                "ssetID] = @Original_AssetID) AND ([Section_] = @Original_Section_) AND ((@IsNull" +
                "_Address = 1 AND [Address] IS NULL) OR ([Address] = @Original_Address)) AND ([La" +
                "teralID] = @Original_LateralID) AND ((@IsNull_LatitudeAtSection = 1 AND [Latitud" +
                "eAtSection] IS NULL) OR ([LatitudeAtSection] = @Original_LatitudeAtSection)) AND" +
                " ((@IsNull_LongitudeAtSection = 1 AND [LongitudeAtSection] IS NULL) OR ([Longitu" +
                "deAtSection] = @Original_LongitudeAtSection)) AND ((@IsNull_LatitudeAtPropertyLi" +
                "ne = 1 AND [LatitudeAtPropertyLine] IS NULL) OR ([LatitudeAtPropertyLine] = @Ori" +
                "ginal_LatitudeAtPropertyLine)) AND ((@IsNull_LongitudeAtPropertyLine = 1 AND [Lo" +
                "ngitudeAtPropertyLine] IS NULL) OR ([LongitudeAtPropertyLine] = @Original_Longit" +
                "udeAtPropertyLine)) AND ([State] = @Original_State) AND ((@IsNull_Size_ = 1 AND " +
                "[Size_] IS NULL) OR ([Size_] = @Original_Size_)) AND ((@IsNull_DistanceFromUSMH " +
                "= 1 AND [DistanceFromUSMH] IS NULL) OR ([DistanceFromUSMH] = @Original_DistanceF" +
                "romUSMH)) AND ((@IsNull_DistanceFromDSMH = 1 AND [DistanceFromDSMH] IS NULL) OR " +
                "([DistanceFromDSMH] = @Original_DistanceFromDSMH)) AND ((@IsNull_MapSize = 1 AND" +
                " [MapSize] IS NULL) OR ([MapSize] = @Original_MapSize)) AND ([Deleted] = @Origin" +
                "al_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND ((@IsNull_ConnectionTy" +
                "pe = 1 AND [ConnectionType] IS NULL) OR ([ConnectionType] = @Original_Connection" +
                "Type)));\r\nSELECT AssetID, Section_, Address, LateralID, LatitudeAtSection, Longi" +
                "tudeAtSection, LatitudeAtPropertyLine, LongitudeAtPropertyLine, State, Size_, Di" +
                "stanceFromUSMH, DistanceFromDSMH, MapSize, Deleted, COMPANY_ID, ConnectionType F" +
                "ROM AM_ASSET_SEWER_LATERAL WHERE (AssetID = @AssetID)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@AssetID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AssetID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Section_", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Section_", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Address", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Address", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LateralID", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LateralID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LatitudeAtSection", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LatitudeAtSection", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LongitudeAtSection", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LongitudeAtSection", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LatitudeAtPropertyLine", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LatitudeAtPropertyLine", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LongitudeAtPropertyLine", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LongitudeAtPropertyLine", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@State", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "State", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Size_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Size_", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DistanceFromUSMH", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DistanceFromUSMH", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DistanceFromDSMH", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DistanceFromDSMH", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MapSize", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MapSize", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ConnectionType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ConnectionType", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_AssetID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AssetID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Section_", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Section_", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Address", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Address", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Address", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Address", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LateralID", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LateralID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_LatitudeAtSection", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LatitudeAtSection", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LatitudeAtSection", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LatitudeAtSection", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_LongitudeAtSection", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LongitudeAtSection", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LongitudeAtSection", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LongitudeAtSection", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_LatitudeAtPropertyLine", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LatitudeAtPropertyLine", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LatitudeAtPropertyLine", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LatitudeAtPropertyLine", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_LongitudeAtPropertyLine", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LongitudeAtPropertyLine", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LongitudeAtPropertyLine", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LongitudeAtPropertyLine", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_State", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "State", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Size_", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Size_", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Size_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Size_", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DistanceFromUSMH", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DistanceFromUSMH", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DistanceFromUSMH", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DistanceFromUSMH", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DistanceFromDSMH", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DistanceFromDSMH", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DistanceFromDSMH", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DistanceFromDSMH", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_MapSize", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MapSize", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MapSize", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MapSize", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_ConnectionType", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ConnectionType", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ConnectionType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ConnectionType", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

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
            FillDataWithStoredProcedure("LFS_ASSETS_ASSETSEWERLATERALGATEWAY_LOADBYASSETID", new SqlParameter("@assetId", assetId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadBySectionId
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>data set</returns>
        public DataSet LoadBySectionId(int sectionId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_ASSETS_ASSETSEWERLATERALGATEWAY_LOADBYSECTIONID", new SqlParameter("@sectionId", sectionId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadAllBySectionId
        /// </summary>
        /// <param name="assetId">assetId</param>       
        /// <param name="companyId">companyId</param>
        /// <returns>data set</returns>
        public DataSet LoadAllBySectionId(int sectionId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_ASSETS_ASSETSEWERLATERALGATEWAY_LOADALLBYSECTIONID", new SqlParameter("@sectionId", sectionId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadBySectionLateralId
        /// </summary>
        /// <param name="section_">section_</param>
        /// <param name="lateralId">lateralId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>dataset</returns>
        public DataSet LoadBySectionLateralId(int section_, string lateralId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_ASSETS_ASSETSEWERLATERALGATEWAY_LOADBYSECTIONLATERALID", new SqlParameter("@section_", section_), new SqlParameter("@lateralId", lateralId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadBySectionProjectId
        /// </summary>
        /// <param name="section_">section_</param>
        /// <param name="projectId">projectId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>dataset</returns>
        public DataSet LoadBySectionProjectId(int section_, int projectId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_ASSETS_ASSETSEWERLATERALGATEWAY_LOADBYSECTIONPROJECTID", new SqlParameter("@section_", section_), new SqlParameter("@projectId", projectId), new SqlParameter("@companyId", companyId));
            return Data;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// Get a single laterals. If not exists, raise an exception.
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int assetId)
        {
            string filter = string.Format("AssetID = {0}", assetId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.Assets.Assets.AssetSewerLateralGateway.GetRow " + assetId);
            }
        }



        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="section_">section_</param>
        /// <param name="lateralId">lateralId</param>
        /// <returns>data</returns>
        public DataRow GetRow(int section_, string lateralId)
        {
            string filter = string.Format("(Section_ = {0}) AND (LateralID = '{1}') ", section_, lateralId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.Assets.Assets.AssetSewerLateralGateway.GetRow  Sec:" + section_ + "lat: " + lateralId);
            }

        }



        /// <summary>
        /// GetAssetID
        /// </summary>
        /// <param name="section_">section_</param>
        /// <param name="lateralId">lateralId</param>
        /// <returns>GetAssetID or EMPTY</returns>
        public int GetAssetID(int section_,string lateralId)
        {
            return (int)GetRow(section_, lateralId)["AssetID"];
        }



        /// <summary>
        /// GetLateralId
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>LateralId or EMPTY</returns>
        public string GetLateralId(int assetId)
        {
            if (GetRow(assetId).IsNull("LateralID"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["LateralID"];
            }
        }



        /// <summary>
        /// GetAddress
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>LateralId or EMPTY</returns>
        public string GetAddress(int assetId)
        {
            if (GetRow(assetId).IsNull("Address"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["Address"];
            }
        }



        /// <summary>
        /// GetLatitudeAtSection
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>LatitudeAtSection or EMPTY</returns>
        public string GetLatitudeAtSection(int assetId)
        {
            if (GetRow(assetId).IsNull("LatitudeAtSection"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["LatitudeAtSection"];
            }
        }



        /// <summary>
        /// GetLongitudeAtSection
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>LongitudeAtSection or EMPTY</returns>
        public string GetLongitudeAtSection(int assetId)
        {
            if (GetRow(assetId).IsNull("LongitudeAtSection"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["LongitudeAtSection"];
            }
        }



        /// <summary>
        /// GetLatitudeAtPropertyLine
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>LatitudeAtPropertyLine or EMPTY</returns>
        public string GetLatitudeAtPropertyLine(int assetId)
        {
            if (GetRow(assetId).IsNull("LatitudeAtPropertyLine"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["LatitudeAtPropertyLine"];
            }
        }



        /// <summary>
        /// GetLongitudeAtPropertyLine
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>LatitudeAtPropertyLine or EMPTY</returns>
        public string GetLongitudeAtPropertyLine(int assetId)
        {
            if (GetRow(assetId).IsNull("LongitudeAtPropertyLine"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["LongitudeAtPropertyLine"];
            }
        }



        /// <summary>
        /// GetState
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>State or EMPTY</returns>
        public string GetState(int assetId)
        {
            if (GetRow(assetId).IsNull("State"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["State"];
            }
        }



        /// <summary>
        /// GetSize
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>State or EMPTY</returns>
        public string GetSize(int assetId)
        {
            if (GetRow(assetId).IsNull("Size_"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["Size_"];
            }
        }



        /// <summary>
        /// GetDistanceFromUSMH
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>DistanceFromUSMH or EMPTY</returns>
        public string GetDistanceFromUSMH(int assetId)
        {
            if (GetRow(assetId).IsNull("DistanceFromUSMH"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["DistanceFromUSMH"];
            }
        }



        /// <summary>
        /// GetDistanceFromDSMH
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>DistanceFromDSMH or EMPTY</returns>
        public string GetDistanceFromDSMH(int assetId)
        {
            if (GetRow(assetId).IsNull("DistanceFromDSMH"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["DistanceFromDSMH"];
            }
        }



        /// <summary>
        /// GetMapSize
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>DistanceFromDSMH or EMPTY</returns>
        public string GetMapSize(int assetId)
        {
            if (GetRow(assetId).IsNull("MapSize"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["MapSize"];
            }
        }

        
        
        /// <summary>
        /// GetDeleted. If project not exists, raise an exception.
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>TRUE if project deleted</returns>
        public bool GetDeleted(int assetId)
        {
            return (bool)GetRow(assetId)["Deleted"];
        }



        /// <summary>
        /// GetCompanyId. If project not exists, raise an exception.
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>CompanyId </returns>
        public int GetCompanyId(int assetId)
        {
            return (int)GetRow(assetId)["COMPANY_ID"];
        }



        /// <summary>
        /// GetCompanyId. If project not exists, raise an exception.
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>CompanyId </returns>
        public int GetSection(int assetId)
        {
            return (int)GetRow(assetId)["Section_"];
        }



        /// <summary>
        /// GetConnectionType
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>ConnectionType or EMPTY</returns>
        public string GetConnectionType(int assetId)
        {
            if (GetRow(assetId).IsNull("ConnectionType"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["ConnectionType"];
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROW
        //

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="section_">section_</param>
        /// <param name="address">address</param>
        /// <param name="lateralID">lateralID</param>
        /// <param name="latitudeAtSection">latitudeAtSection</param>
        /// <param name="longitudeAtSection">longitudeAtSection</param>
        /// <param name="latitudeAtPropertyLine">latitudeAtPropertyLine</param>
        /// <param name="longitudeAtPropertyLine">longitudeAtPropertyLine</param>
        /// <param name="state">state</param>
        /// <param name="size">size</param>
        /// <param name="distanceFromUsmh">distanceFromUsmh</param>
        /// <param name="distanceFromDsmh">distanceFromDsmh</param>
        /// <param name="mapSize">mapSize</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="connectionType">connectionType</param>
        public void Insert(int assetId, int section_, string address, string lateralId, string latitudeAtSection, string longitudeAtSection, string latitudeAtPropertyLine, string longitudeAtPropertyLine, string state, string size, string distanceFromUsmh, string distanceFromDsmh, string mapSize, bool deleted, int companyId, string connectionType)
        {
            SqlParameter assetIdParameter = new SqlParameter("AssetId", assetId);
            SqlParameter section_Parameter = new SqlParameter("Section_", section_);
            SqlParameter addressParameter = (address.Trim() != "") ? new SqlParameter("Address", address.Trim()) : new SqlParameter("Address", DBNull.Value);
            SqlParameter lateralIDParameter = (lateralId.Trim() != "") ? new SqlParameter("LateralID", lateralId.Trim()) : new SqlParameter("LateralID", DBNull.Value);
            SqlParameter latitudeAtSectionParameter = (latitudeAtSection.Trim() != "") ? new SqlParameter("LatitudeAtSection", latitudeAtSection.Trim()) : new SqlParameter("LatitudeAtSection", DBNull.Value);
            SqlParameter longitudeAtSectionParameter = (longitudeAtSection.Trim() != "") ? new SqlParameter("LongitudeAtSection", longitudeAtSection.Trim()) : new SqlParameter("LongitudeAtSection", DBNull.Value);
            SqlParameter latitudeAtPropertyLineParameter = (latitudeAtPropertyLine.Trim() != "") ? new SqlParameter("LatitudeAtPropertyLine", latitudeAtPropertyLine.Trim()) : new SqlParameter("LatitudeAtPropertyLine", DBNull.Value);
            SqlParameter longitudeAtPropertyLineParameter = (longitudeAtPropertyLine.Trim() != "") ? new SqlParameter("LongitudeAtPropertyLine", longitudeAtPropertyLine.Trim()) : new SqlParameter("LongitudeAtPropertyLine", DBNull.Value);
            SqlParameter stateParameter = (state.Trim() != "") ? new SqlParameter("State", state.Trim()) : new SqlParameter("State", DBNull.Value);
            SqlParameter sizeParameter = (size.Trim() != "") ? new SqlParameter("Size_", size.Trim()) : new SqlParameter("Size_", DBNull.Value);
            SqlParameter distanceFromUsmhParameter = (distanceFromUsmh.Trim() != "") ? new SqlParameter("DistanceFromUSMH", distanceFromUsmh.Trim()) : new SqlParameter("DistanceFromUSMH", DBNull.Value);
            SqlParameter distanceFromDsmhParameter = (distanceFromDsmh.Trim() != "") ? new SqlParameter("DistanceFromDSMH", distanceFromDsmh.Trim()) : new SqlParameter("DistanceFromDSMH", DBNull.Value);
            SqlParameter mapSizeParameter = (mapSize.Trim() != "") ? new SqlParameter("MapSize", mapSize.Trim()) : new SqlParameter("MapSize", DBNull.Value);
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            SqlParameter connectionTypeParameter = (connectionType.Trim() != "") ? new SqlParameter("ConnectionType", connectionType.Trim()) : new SqlParameter("ConnectionType", DBNull.Value);

            string command = "INSERT INTO [dbo].[AM_ASSET_SEWER_LATERAL] ([AssetID], [Section_], [Address], [LateralID], [LatitudeAtSection], [LongitudeAtSection], [LatitudeAtPropertyLine], [LongitudeAtPropertyLine], [State], [Size_], [DistanceFromUSMH], [DistanceFromDSMH], [MapSize], [Deleted], [COMPANY_ID], [ConnectionType]) VALUES (@AssetID, @Section_, @Address, @LateralID, @LatitudeAtSection, @LongitudeAtSection, @LatitudeAtPropertyLine, @LongitudeAtPropertyLine, @State, @Size_, @DistanceFromUSMH, @DistanceFromDSMH, @MapSize, @Deleted, @COMPANY_ID, @ConnectionType)";

            ExecuteNonQuery(command, assetIdParameter, section_Parameter, addressParameter, lateralIDParameter, latitudeAtSectionParameter, longitudeAtSectionParameter, latitudeAtPropertyLineParameter, longitudeAtPropertyLineParameter, stateParameter, sizeParameter, distanceFromUsmhParameter, distanceFromDsmhParameter, mapSizeParameter, deletedParameter, companyIdParameter, connectionTypeParameter);
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

            string command = "UPDATE [dbo].[AM_ASSET_SEWER_LATERAL] SET [Deleted] = @Deleted WHERE (([AssetID] = @AssetID) AND " +
                            "([COMPANY_ID] = @COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery( command, assetIdParameter, companyIdParameter, deletedParameter);
            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }
        }
        

        
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="originalAssetId">originalAssetId</param>
        /// <param name="originalSection_">originalSection_</param>
        /// <param name="originalAddress">originalAddress</param>
        /// <param name="originalLateralId">originalLateralId</param>
        /// <param name="originalLatitudeAtSection">originalLatitudeAtSection</param>
        /// <param name="originalLongitudeAtSection">originalLongitudeAtSection</param>
        /// <param name="originalLatitudeAtPropertyLine">originalLatitudeAtPropertyLine</param>
        /// <param name="originalLongitudeAtPropertyLine">originalLongitudeAtPropertyLine</param>
        /// <param name="originalState">originalState</param>
        /// <param name="originalSize">originalSize</param>
        /// <param name="originalDistanceFromUsmh">originalDistanceFromUsmh</param>
        /// <param name="originalDistanceFromDsmh">originalDistanceFromDsmh</param>
        /// <param name="originalMapSize">originalMapSize</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalConnectionType">originalConnectionType</param>
        /// 
        /// <param name="newAssetId">newAssetId</param>
        /// <param name="newSection_">newSection_</param>
        /// <param name="newAddress">newAddress</param>
        /// <param name="newLateralId">newLateralId</param>
        /// <param name="newLatitudeAtSection">newLatitudeAtSection</param>
        /// <param name="newLongitudeAtSection">newLongitudeAtSection</param>
        /// <param name="newLatitudeAtPropertyLine">newLatitudeAtPropertyLine</param>
        /// <param name="newLongitudeAtPropertyLine">newLongitudeAtPropertyLine</param>
        /// <param name="newState">newState</param>
        /// <param name="newSize">newSize</param>
        /// <param name="newDistanceFromUsmh">newDistanceFromUsmh</param>
        /// <param name="newDistanceFromDsmh">newDistanceFromDsmh</param>
        /// <param name="newMapSize">newMapSize</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newConnectionType">newConnectionType</param>
        public void Update(int originalAssetId, int originalSection_, string originalAddress, string originalLateralId, string originalLatitudeAtSection, string originalLongitudeAtSection, string originalLatitudeAtPropertyLine, string originalLongitudeAtPropertyLine, string originalState, string originalSize, string originalDistanceFromUsmh, string originalDistanceFromDsmh, string originalMapSize, bool originalDeleted, int originalCompanyId, string originalConnectionType, int newAssetId, int newSection_, string newAddress, string newLateralId, string newLatitudeAtSection, string newLongitudeAtSection, string newLatitudeAtPropertyLine, string newLongitudeAtPropertyLine, string newState, string newSize, string newDistanceFromUsmh, string newDistanceFromDsmh, string newMapSize, bool newDeleted, int newCompanyId, string newConnectionType)
        {
            SqlParameter originalAssetIdParameter = new SqlParameter("Original_AssetID", originalAssetId);
            SqlParameter originalSection_Parameter = new SqlParameter("Original_Section_", newSection_);
            SqlParameter originalAddressParameter = (originalAddress.Trim() != "") ? new SqlParameter("Original_Address", originalAddress.Trim()) : new SqlParameter("Original_Address", DBNull.Value);
            SqlParameter originalLateralIdParameter = (originalLateralId.Trim() != "") ? new SqlParameter("Original_LateralID", originalLateralId.Trim()) : new SqlParameter("Original_LateralID", DBNull.Value);
            SqlParameter originalLatitudeAtSectionParameter = (originalLatitudeAtSection.Trim() != "") ? new SqlParameter("Original_LatitudeAtSection", originalLatitudeAtSection.Trim()) : new SqlParameter("Original_LatitudeAtSection", DBNull.Value);
            SqlParameter originalLongitudeAtSectionParameter = (originalLongitudeAtSection.Trim() != "") ? new SqlParameter("Original_LongitudeAtSection", originalLongitudeAtSection.Trim()) : new SqlParameter("Original_LongitudeAtSection", DBNull.Value);
            SqlParameter originalLatitudeAtPropertyLineParameter = (originalLatitudeAtPropertyLine.Trim() != "") ? new SqlParameter("Original_LatitudeAtPropertyLine", originalLatitudeAtPropertyLine.Trim()) : new SqlParameter("Original_LatitudeAtPropertyLine", DBNull.Value);
            SqlParameter originalLongitudeAtPropertyLineParameter = (originalLongitudeAtPropertyLine.Trim() != "") ? new SqlParameter("Original_LongitudeAtPropertyLine", originalLongitudeAtPropertyLine.Trim()) : new SqlParameter("Original_LongitudeAtPropertyLine", DBNull.Value);
            SqlParameter originalStateParameter = (originalState.Trim() != "") ? new SqlParameter("Original_State", originalState.Trim()) : new SqlParameter("Original_State", DBNull.Value);
            SqlParameter originalSizeParameter = (originalSize.Trim() != "") ? new SqlParameter("Original_Size_", originalSize.Trim()) : new SqlParameter("Original_Size_", DBNull.Value);
            SqlParameter originalDistanceFromUsmhParameter = (originalDistanceFromUsmh.Trim() != "") ? new SqlParameter("Original_DistanceFromUSMH", originalDistanceFromUsmh.Trim()) : new SqlParameter("Original_DistanceFromUSMH", DBNull.Value);
            SqlParameter originalDistanceFromDsmhParameter = (originalDistanceFromDsmh.Trim() != "") ? new SqlParameter("Original_DistanceFromDSMH", originalDistanceFromDsmh.Trim()) : new SqlParameter("Original_DistanceFromDSMH", DBNull.Value);
            SqlParameter originalMapSizeParameter = (originalMapSize.Trim() != "") ? new SqlParameter("Original_MapSize", originalMapSize.Trim()) : new SqlParameter("Original_MapSize", DBNull.Value);
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter originalConnectionTypeParameter = (originalConnectionType.Trim() != "") ? new SqlParameter("Original_ConnectionType", originalConnectionType.Trim()) : new SqlParameter("Original_ConnectionType", DBNull.Value);

            SqlParameter newAssetIdParameter = new SqlParameter("AssetId", newAssetId);
            SqlParameter newSection_Parameter = new SqlParameter("Section_", newSection_);
            SqlParameter newAddressParameter = (newAddress.Trim() != "") ? new SqlParameter("Address", newAddress.Trim()) : new SqlParameter("Address", DBNull.Value);
            SqlParameter newLateralIdParameter = (newLateralId.Trim() != "") ? new SqlParameter("LateralID", newLateralId.Trim()) : new SqlParameter("LateralID", DBNull.Value);
            SqlParameter newLatitudeAtSectionParameter = (newLatitudeAtSection.Trim() != "") ? new SqlParameter("LatitudeAtSection", newLatitudeAtSection.Trim()) : new SqlParameter("LatitudeAtSection", DBNull.Value);
            SqlParameter newLongitudeAtSectionParameter = (newLongitudeAtSection.Trim() != "") ? new SqlParameter("LongitudeAtSection", newLongitudeAtSection.Trim()) : new SqlParameter("LongitudeAtSection", DBNull.Value);
            SqlParameter newLatitudeAtPropertyLineParameter = (newLatitudeAtPropertyLine.Trim() != "") ? new SqlParameter("LatitudeAtPropertyLine", newLatitudeAtPropertyLine.Trim()) : new SqlParameter("LatitudeAtPropertyLine", DBNull.Value);
            SqlParameter newLongitudeAtPropertyLineParameter = (newLongitudeAtPropertyLine.Trim() != "") ? new SqlParameter("LongitudeAtPropertyLine", newLongitudeAtPropertyLine.Trim()) : new SqlParameter("LongitudeAtPropertyLine", DBNull.Value);
            SqlParameter newStateParameter = (newState.Trim() != "") ? new SqlParameter("State", newState.Trim()) : new SqlParameter("State", DBNull.Value);
            SqlParameter newSizeParameter = (newSize.Trim() != "") ? new SqlParameter("Size_", newSize.Trim()) : new SqlParameter("Size_", DBNull.Value);
            SqlParameter newDistanceFromUsmhParameter = (newDistanceFromUsmh.Trim() != "") ? new SqlParameter("DistanceFromUSMH", newDistanceFromUsmh.Trim()) : new SqlParameter("DistanceFromUSMH", DBNull.Value);
            SqlParameter newDistanceFromDsmhParameter = (newDistanceFromDsmh.Trim() != "") ? new SqlParameter("DistanceFromDSMH", newDistanceFromDsmh.Trim()) : new SqlParameter("DistanceFromDSMH", DBNull.Value);
            SqlParameter newMapSizeParameter = (newMapSize.Trim() != "") ? new SqlParameter("MapSize", newMapSize.Trim()) : new SqlParameter("MapSize", DBNull.Value);
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);
            SqlParameter newConnectionTypeParameter = (newConnectionType.Trim() != "") ? new SqlParameter("ConnectionType", newConnectionType.Trim()) : new SqlParameter("ConnectionType", DBNull.Value);

            string command = "UPDATE [dbo].[AM_ASSET_SEWER_LATERAL] " +
                             "SET [AssetID] = @AssetID, [Section_] = @Section_, [Address] = @Address,  [LateralID] = @LateralID, [LatitudeAtSection] = @LatitudeAtSection, [LongitudeAtSection] = @LongitudeAtSection, [LatitudeAtPropertyLine] = @LatitudeAtPropertyLine, [LongitudeAtPropertyLine] = @LongitudeAtPropertyLine, [State] = @State, [Size_] = @Size_, [DistanceFromUSMH] = @DistanceFromUSMH, [DistanceFromDSMH] = @DistanceFromDSMH, [MapSize] = @MapSize, [Deleted] = @Deleted, [ConnectionType] = @ConnectionType "+
                            " WHERE ([AssetID] = @Original_AssetID) AND " +
                            "([COMPANY_ID] = @COMPANY_ID)";

            int rowsAffected = (int)ExecuteNonQuery(command,originalAssetIdParameter, originalSection_Parameter, originalAddressParameter, originalLateralIdParameter, originalLatitudeAtSectionParameter, originalLongitudeAtSectionParameter, originalLatitudeAtPropertyLineParameter, originalLongitudeAtPropertyLineParameter, originalStateParameter, originalSizeParameter, originalDistanceFromUsmhParameter, originalDistanceFromDsmhParameter, originalMapSizeParameter, originalDeletedParameter, originalCompanyIdParameter, originalConnectionTypeParameter, newAssetIdParameter, newSection_Parameter, newAddressParameter, newLateralIdParameter, newLatitudeAtSectionParameter, newLongitudeAtSectionParameter, newLatitudeAtPropertyLineParameter, newLongitudeAtPropertyLineParameter, newStateParameter, newSizeParameter, newDistanceFromUsmhParameter, newDistanceFromDsmhParameter, newMapSizeParameter, newDeletedParameter, newCompanyIdParameter, newConnectionTypeParameter);
            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }
        }



    }
}