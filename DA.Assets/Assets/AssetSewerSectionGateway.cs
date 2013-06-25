using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Assets.Assets
{
    /// <summary>
    /// AssetsSewerSectionGateway
    /// </summary>
    public class AssetSewerSectionGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public AssetSewerSectionGateway() : base("AM_ASSET_SEWER_SECTION")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public AssetSewerSectionGateway(DataSet data) : base(data, "AM_ASSET_SEWER_SECTION")
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
            tableMapping.DataSetTable = "AM_ASSET_SEWER_SECTION";
            tableMapping.ColumnMappings.Add("AssetID", "AssetID");
            tableMapping.ColumnMappings.Add("SectionID", "SectionID");
            tableMapping.ColumnMappings.Add("Street", "Street");
            tableMapping.ColumnMappings.Add("USMH", "USMH");
            tableMapping.ColumnMappings.Add("DSMH", "DSMH");
            tableMapping.ColumnMappings.Add("MapSize", "MapSize");
            tableMapping.ColumnMappings.Add("Size_", "Size_");
            tableMapping.ColumnMappings.Add("MapLength", "MapLength");
            tableMapping.ColumnMappings.Add("Length", "Length");
            tableMapping.ColumnMappings.Add("Laterals", "Laterals");
            tableMapping.ColumnMappings.Add("LiveLaterals", "LiveLaterals");
            tableMapping.ColumnMappings.Add("FlowDirection", "FlowDirection");
            tableMapping.ColumnMappings.Add("USMHDepth", "USMHDepth");
            tableMapping.ColumnMappings.Add("DSMHDepth", "DSMHDepth");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("FlowOrderID", "FlowOrderID");

            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = @"DELETE FROM [dbo].[AM_ASSET_SEWER_SECTION] WHERE (([AssetID] = @Original_AssetID) AND ([SectionID] = @Original_SectionID) AND ((@IsNull_Street = 1 AND [Street] IS NULL) OR ([Street] = @Original_Street)) AND ((@IsNull_USMH = 1 AND [USMH] IS NULL) OR ([USMH] = @Original_USMH)) AND ((@IsNull_DSMH = 1 AND [DSMH] IS NULL) OR ([DSMH] = @Original_DSMH)) AND ((@IsNull_MapSize = 1 AND [MapSize] IS NULL) OR ([MapSize] = @Original_MapSize)) AND ((@IsNull_Size_ = 1 AND [Size_] IS NULL) OR ([Size_] = @Original_Size_)) AND ((@IsNull_MapLength = 1 AND [MapLength] IS NULL) OR ([MapLength] = @Original_MapLength)) AND ((@IsNull_Length = 1 AND [Length] IS NULL) OR ([Length] = @Original_Length)) AND ((@IsNull_Laterals = 1 AND [Laterals] IS NULL) OR ([Laterals] = @Original_Laterals)) AND ((@IsNull_LiveLaterals = 1 AND [LiveLaterals] IS NULL) OR ([LiveLaterals] = @Original_LiveLaterals)) AND ((@IsNull_FlowDirection = 1 AND [FlowDirection] IS NULL) OR ([FlowDirection] = @Original_FlowDirection)) AND ((@IsNull_USMHDepth = 1 AND [USMHDepth] IS NULL) OR ([USMHDepth] = @Original_USMHDepth)) AND ((@IsNull_DSMHDepth = 1 AND [DSMHDepth] IS NULL) OR ([DSMHDepth] = @Original_DSMHDepth)) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND ((@IsNull_FlowOrderID = 1 AND [FlowOrderID] IS NULL) OR ([FlowOrderID] = @Original_FlowOrderID)))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_AssetID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AssetID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_SectionID", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SectionID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Street", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Street", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Street", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Street", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_USMH", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "USMH", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_USMH", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "USMH", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DSMH", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DSMH", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DSMH", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DSMH", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_MapSize", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MapSize", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MapSize", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MapSize", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Size_", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Size_", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Size_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Size_", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_MapLength", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MapLength", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MapLength", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MapLength", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Length", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Length", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Length", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Length", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Laterals", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Laterals", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Laterals", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Laterals", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_LiveLaterals", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LiveLaterals", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LiveLaterals", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LiveLaterals", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_FlowDirection", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FlowDirection", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_FlowDirection", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FlowDirection", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_USMHDepth", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "USMHDepth", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_USMHDepth", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "USMHDepth", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DSMHDepth", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DSMHDepth", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DSMHDepth", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DSMHDepth", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_FlowOrderID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FlowOrderID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_FlowOrderID", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FlowOrderID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[AM_ASSET_SEWER_SECTION] ([AssetID], [SectionID], [Street], [USMH], [DSMH], [MapSize], [Size_], [MapLength], [Length], [Laterals], [LiveLaterals], [FlowDirection], [USMHDepth], [DSMHDepth], [Deleted], [COMPANY_ID], [FlowOrderID]) VALUES (@AssetID, @SectionID, @Street, @USMH, @DSMH, @MapSize, @Size_, @MapLength, @Length, @Laterals, @LiveLaterals, @FlowDirection, @USMHDepth, @DSMHDepth, @Deleted, @COMPANY_ID, @FlowOrderID);
SELECT AssetID, SectionID, Street, USMH, DSMH, MapSize, Size_, MapLength, Length, Laterals, LiveLaterals, FlowDirection, USMHDepth, DSMHDepth, Deleted, COMPANY_ID, FlowOrderID FROM AM_ASSET_SEWER_SECTION WHERE (AssetID = @AssetID)";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@AssetID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AssetID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@SectionID", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SectionID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Street", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Street", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@USMH", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "USMH", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DSMH", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DSMH", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MapSize", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MapSize", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Size_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Size_", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MapLength", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MapLength", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Length", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Length", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Laterals", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Laterals", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LiveLaterals", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LiveLaterals", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@FlowDirection", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FlowDirection", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@USMHDepth", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "USMHDepth", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DSMHDepth", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DSMHDepth", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@FlowOrderID", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FlowOrderID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));

            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[AM_ASSET_SEWER_SECTION] SET [AssetID] = @AssetID, [SectionID] = @Se" +
                "ctionID, [Street] = @Street, [USMH] = @USMH, [DSMH] = @DSMH, [MapSize] = @MapSiz" +
                "e, [Size_] = @Size_, [MapLength] = @MapLength, [Length] = @Length, [Laterals] = " +
                "@Laterals, [LiveLaterals] = @LiveLaterals, [FlowDirection] = @FlowDirection, [US" +
                "MHDepth] = @USMHDepth, [DSMHDepth] = @DSMHDepth, [Deleted] = @Deleted, [COMPANY_" +
                "ID] = @COMPANY_ID, [FlowOrderID] = @FlowOrderID WHERE (([AssetID] = @Original_As" +
                "setID) AND ([SectionID] = @Original_SectionID) AND ((@IsNull_Street = 1 AND [Str" +
                "eet] IS NULL) OR ([Street] = @Original_Street)) AND ((@IsNull_USMH = 1 AND [USMH" +
                "] IS NULL) OR ([USMH] = @Original_USMH)) AND ((@IsNull_DSMH = 1 AND [DSMH] IS NU" +
                "LL) OR ([DSMH] = @Original_DSMH)) AND ((@IsNull_MapSize = 1 AND [MapSize] IS NUL" +
                "L) OR ([MapSize] = @Original_MapSize)) AND ((@IsNull_Size_ = 1 AND [Size_] IS NU" +
                "LL) OR ([Size_] = @Original_Size_)) AND ((@IsNull_MapLength = 1 AND [MapLength] " +
                "IS NULL) OR ([MapLength] = @Original_MapLength)) AND ((@IsNull_Length = 1 AND [L" +
                "ength] IS NULL) OR ([Length] = @Original_Length)) AND ((@IsNull_Laterals = 1 AND" +
                " [Laterals] IS NULL) OR ([Laterals] = @Original_Laterals)) AND ((@IsNull_LiveLat" +
                "erals = 1 AND [LiveLaterals] IS NULL) OR ([LiveLaterals] = @Original_LiveLateral" +
                "s)) AND ((@IsNull_FlowDirection = 1 AND [FlowDirection] IS NULL) OR ([FlowDirect" +
                "ion] = @Original_FlowDirection)) AND ((@IsNull_USMHDepth = 1 AND [USMHDepth] IS " +
                "NULL) OR ([USMHDepth] = @Original_USMHDepth)) AND ((@IsNull_DSMHDepth = 1 AND [D" +
                "SMHDepth] IS NULL) OR ([DSMHDepth] = @Original_DSMHDepth)) AND ([Deleted] = @Ori" +
                "ginal_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND ((@IsNull_FlowOrder" +
                "ID = 1 AND [FlowOrderID] IS NULL) OR ([FlowOrderID] = @Original_FlowOrderID)));\r" +
                "\nSELECT AssetID, SectionID, Street, USMH, DSMH, MapSize, Size_, MapLength, Lengt" +
                "h, Laterals, LiveLaterals, FlowDirection, USMHDepth, DSMHDepth, Deleted, COMPANY" +
                "_ID, FlowOrderID FROM AM_ASSET_SEWER_SECTION WHERE (AssetID = @AssetID)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@AssetID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AssetID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@SectionID", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SectionID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Street", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Street", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@USMH", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "USMH", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DSMH", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DSMH", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MapSize", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MapSize", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Size_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Size_", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MapLength", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MapLength", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Length", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Length", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Laterals", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Laterals", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LiveLaterals", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LiveLaterals", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@FlowDirection", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FlowDirection", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@USMHDepth", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "USMHDepth", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DSMHDepth", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DSMHDepth", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@FlowOrderID", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FlowOrderID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_AssetID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AssetID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_SectionID", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SectionID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Street", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Street", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Street", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Street", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_USMH", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "USMH", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_USMH", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "USMH", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DSMH", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DSMH", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DSMH", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DSMH", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_MapSize", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MapSize", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MapSize", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MapSize", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Size_", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Size_", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Size_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Size_", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_MapLength", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MapLength", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MapLength", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MapLength", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Length", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Length", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Length", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Length", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Laterals", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Laterals", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Laterals", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Laterals", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_LiveLaterals", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LiveLaterals", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LiveLaterals", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LiveLaterals", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_FlowDirection", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FlowDirection", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_FlowDirection", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FlowDirection", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_USMHDepth", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "USMHDepth", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_USMHDepth", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "USMHDepth", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DSMHDepth", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DSMHDepth", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DSMHDepth", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DSMHDepth", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_FlowOrderID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FlowOrderID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_FlowOrderID", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FlowOrderID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

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
            FillDataWithStoredProcedure("LFS_ASSETS_ASSETSEWERSECTIONGATEWAY_LOADBYASSETID", new SqlParameter("@assetId", assetId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadBySectionId
        /// </summary>
        /// <param name="sectionId">sectionId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>data set</returns>
        public DataSet LoadBySectionId(string sectionId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_ASSETS_ASSETSEWERSECTIONGATEWAY_LOADBYSECTIONID", new SqlParameter("@sectionId", sectionId), new SqlParameter("@companyId", companyId));
            return Data;
        }
        


        /// <summary>
        /// LoadByCountryIdProvinceIdCountyIdCityIdSectionId
        /// </summary>
        /// <param name="countryId">countryId</param>
        /// <param name="provinceId">provinceId</param>
        /// <param name="countyId">countyId</param>
        /// <param name="cityId">cityId</param>
        /// <param name="sectionId">sectionId</param>
        /// <param name="companyId">companyId</param>
        /// <returns></returns>
        public DataSet LoadByCountryIdProvinceIdCountyIdCityIdSectionId(Int64? countryId, Int64? provinceId, Int64? countyId, Int64? cityId, string sectionId, int companyId)
        {
            string countryParameter = (countryId.HasValue) ? ("AND (AMA.CountryID = " + ((Int64)countryId).ToString() + ")") : ("AND (AMA.CountryID IS NULL)");
            string provinceParameter = (provinceId.HasValue) ? ("AND (AMA.ProvinceID = " + ((Int64)provinceId).ToString() + ")") : ("AND (AMA.ProvinceID IS NULL)");
            string countyParameter = (countyId.HasValue) ? ("AND (AMA.CountyID = " + ((Int64)countyId).ToString() + ")") : ("AND (AMA.CountyID IS NULL)");
            string cityParameter = (cityId.HasValue) ? ("AND (AMA.CityID = " + ((Int64)cityId).ToString() + ")") : ("AND (AMA.CityID IS NULL)");

            string command = string.Format("SELECT AMASS.AssetID, AMASS.SectionID, AMASS.Street, AMASS.USMH, AMASS.DSMH, AMASS.MapSize, AMASS.Size_, AMASS.MapLength, AMASS.Length, AMASS.Laterals, AMASS.LiveLaterals, AMASS.FlowDirection, AMASS.USMHDepth, AMASS.DSMHDepth, AMASS.Deleted, AMASS.COMPANY_ID, AMASS.FlowOrderID "+
                " FROM dbo.AM_ASSET_SEWER_SECTION AMASS INNER JOIN dbo.AM_ASSET AMA ON AMASS.AssetID = AMA.AssetID WHERE (AMASS.SectionID = '{4}') AND (AMASS.Deleted = 0) AND (AMASS.COMPANY_ID = {5}) {0} {1} {2} {3}", countryParameter, provinceParameter, countyParameter, cityParameter, sectionId, companyId);
            FillData(command);

            return Data;
        }



        /// <summary>
        /// Get a single project. If not exists, raise an exception.
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
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.Assets.Assets.AssetSewerSectionGateway.GetRow");
            }
        }



        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="sectionId">sectionId</param>
        /// <returns>data</returns>
        public DataRow GetRow(string sectionId)
        {
            string filter = string.Format("(SectionID = '{0}') ", sectionId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.Assets.Assets.AssetSewerSectionGateway.GetRow");
            }

        }



        /// <summary>
        /// GetAssetID
        /// </summary>
        /// <param name="sectionId">sectionId</param>
        /// <returns>GetAssetID or EMPTY</returns>
        public int GetAssetID(string sectionId)
        {
            return (int)GetRow(sectionId)["AssetID"];
        }




        /// <summary>
        /// GetSectionId
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>SectionID or EMPTY</returns>
        public string GetSectionId(int assetId)
        {
            if (GetRow(assetId).IsNull("SectionID"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["SectionID"];
            }
        }



        /// <summary>
        /// GetStreet
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>Street or EMPTY</returns>
        public string GetStreet(int assetId)
        {
            if (GetRow(assetId).IsNull("Street"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["Street"];
            }
        }



        /// <summary>
        /// GetUSMH. If project not exists, raise an exception.
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>GetUSMH or EMPTY</returns>
        public int? GetUSMH(int assetId)
        {
            if (GetRow(assetId).IsNull("USMH"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(assetId)["USMH"];
            }
        }



        /// <summary>
        /// GetDSMH. If project not exists, raise an exception.
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>GetDSMH or EMPTY</returns>
        public int? GetDSMH(int assetId)
        {
            if (GetRow(assetId).IsNull("DSMH"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(assetId)["DSMH"];
            }
        }



        /// <summary>
        /// GetMapSize
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>MapSize or EMPTY</returns>
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
        /// GetSize_
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>Size_ or EMPTY</returns>
        public string GetSize_(int assetId)
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
        /// GetMapLength
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>MapLength or EMPTY</returns>
        public string GetMapLength(int assetId)
        {
            if (GetRow(assetId).IsNull("MapLength"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["MapLength"];
            }
        }



        /// <summary>
        /// GetLength
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>Length or EMPTY</returns>
        public string GetLength(int assetId)
        {
            if (GetRow(assetId).IsNull("Length"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["Length"];
            }
        }



        /// <summary>
        /// GetLaterals. If project not exists, raise an exception.
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>GetLaterals or EMPTY</returns>
        public int? GetLaterals(int assetId)
        {
            if (GetRow(assetId).IsNull("Laterals"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(assetId)["Laterals"];
            }
        }



        /// <summary>
        /// GetLiveLaterals. If project not exists, raise an exception.
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>GetLiveLaterals or EMPTY</returns>
        public int? GetLiveLaterals(int assetId)
        {
            if (GetRow(assetId).IsNull("LiveLaterals"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(assetId)["LiveLaterals"];
            }
        }



        /// <summary>
        /// GetFlowDirection
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>FlowDirection or EMPTY</returns>
        public string GetFlowDirection(int assetId)
        {
            if (GetRow(assetId).IsNull("FlowDirection"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["FlowDirection"];
            }
        }



        /// <summary>
        /// GetUSMHDepth
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>USMHDepth or EMPTY</returns>
        public string GetUSMHDepth(int assetId)
        {
            if (GetRow(assetId).IsNull("USMHDepth"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["USMHDepth"];
            }
        }



        /// <summary>
        /// GetDSMHDepth
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>DSMHDepth or EMPTY</returns>
        public string GetDSMHDepth(int assetId)
        {
            if (GetRow(assetId).IsNull("DSMHDepth"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["DSMHDepth"];
            }
        }



        /// <summary>
        /// GetDeleted. If section not exists, raise an exception.
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>TRUE if section deleted</returns>
        public bool GetDeleted(int assetId)
        {
            return (bool)GetRow(assetId)["Deleted"];
        }



        /// <summary>
        /// GetCompanyId. If section not exists, raise an exception.
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>CompanyId </returns>
        public int GetCompanyId(int assetId)
        {
            return (int)GetRow(assetId)["COMPANY_ID"];
        }



        /// <summary>
        /// GetFlowOrderID
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>Flow Order ID or EMPTY</returns>
        public string GetFlowOrderID(int assetId)
        {
            if (GetRow(assetId).IsNull("FlowOrderID"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["FlowOrderID"];
            }
        }



        /// <summary>
        /// GetFlowOrderID
        /// </summary>
        /// <param name="assetId">sectionId</param>
        /// <returns>Flow Order ID or EMPTY</returns>
        public string GetFlowOrderID(string sectionId)
        {
            if (GetRow(sectionId).IsNull("FlowOrderID"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(sectionId)["FlowOrderID"];
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - QUERIES
        //
        
        /// <summary>
        /// Verify if sectionId is already in use in country, province...
        /// </summary>
        /// <param name="countryId">countryId</param>
        /// <param name="provinceId">provinceId</param>
        /// <param name="countyId">countyId</param>
        /// <param name="cityId">cityId</param>
        /// <param name="sectionId">sectionId</param>
        /// <param name="companyId">companyId</param>
        /// <returns></returns>
        public bool ExistsByCountryIdProvinceIdCountyIdCityIdSectionId(Int64? countryId, Int64? provinceId, Int64? countyId, Int64? cityId, string sectionId, int companyId)
        {
            string countryParameter = (countryId.HasValue) ? ("AND (AMA.CountryID = " + ((Int64)countryId).ToString() + ")") : ("AND (AMA.CountryID IS NULL)");
            string provinceParameter = (provinceId.HasValue) ? ("AND (AMA.ProvinceID = " + ((Int64)provinceId).ToString() + ")") : ("AND (AMA.ProvinceID IS NULL)");
            string countyParameter = (countyId.HasValue) ? ("AND (AMA.CountyID = " + ((Int64)countyId).ToString() + ")") : ("AND (AMA.CountyID IS NULL)");
            string cityParameter = (cityId.HasValue) ? ("AND (AMA.CityID = " + ((Int64)cityId).ToString() + ")") : ("AND (AMA.CityID IS NULL)");

            SqlParameter sectionIdParameter = new SqlParameter("sectionId", sectionId);
            SqlParameter companyIdParameter = new SqlParameter("companyId", companyId);

            string command = string.Format("SELECT COUNT(*) FROM dbo.AM_ASSET_SEWER_SECTION AMASS INNER JOIN dbo.AM_ASSET AMA ON AMASS.AssetID = AMA.AssetID WHERE (AMASS.SectionID = @sectionId) AND (AMASS.Deleted = 0) AND (AMASS.COMPANY_ID = @companyId) {0} {1} {2} {3}", countryParameter, provinceParameter, countyParameter, cityParameter);

            int count = (int)ExecuteScalar(command, sectionIdParameter, companyIdParameter);

            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        
        
        /// <summary>
        /// GetLastSectionId
        /// </summary>
        /// <param name="countryId">countryId</param>
        /// <param name="provinceId">provinceId</param>
        /// <param name="countyId">countyId</param>
        /// <param name="cityId">cityId</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>Last SectionID</returns>
        public string GetLastSectionId(Int64? countryId, Int64? provinceId, Int64? countyId, Int64? cityId, int companyId)
        {
            string countryParameter = (countryId.HasValue) ? ("AND (AA.CountryID = " + ((Int64)countryId).ToString() + ")") : ("AND (AA.CountryID IS NULL)");
            string provinceParameter = (provinceId.HasValue) ? ("AND (AA.ProvinceID = " + ((Int64)provinceId).ToString() + ")") : ("AND (AA.ProvinceID IS NULL)");
            string countyParameter = (countyId.HasValue) ? ("AND (AA.CountyID = " + ((Int64)countyId).ToString() + ")") : ("AND (AA.CountyID IS NULL)");
            string cityParameter = (cityId.HasValue) ? ("AND (AA.CityID = " + ((Int64)cityId).ToString() + ")") : ("AND (AA.CityID IS NULL)");

            string commandText =string.Format( " SELECT MAX(AASS.SectionID) AS SectionID "+
                                 " FROM  AM_ASSET_SEWER_SECTION AASS INNER JOIN " +
                                 "       AM_ASSET AA ON AASS.AssetID = AA.AssetID " +
                                 " WHERE (AA.CountryID = {0}) AND AASS.COMPANY_ID = {1} {2} {3} {4} {5} " +
                                 "    AND (AASS.Deleted = 0) ", countryId, companyId, countryParameter, provinceParameter, countyParameter, cityParameter);
            SqlCommand command = new SqlCommand(commandText, DB.Connection);

            if (ExecuteScalar(command) == DBNull.Value)
            {
                return "";
            }
            else
            {
                return ((string)ExecuteScalar(command));
            }
        }





        
        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROW
        //

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="sectionId">sectionId</param>
        /// <param name="street">street</param>
        /// <param name="usmh">usmh</param>
        /// <param name="dsmh">dsmh</param>
        /// <param name="mapSize">mapSize</param>
        /// <param name="size">size</param>
        /// <param name="mapLength">mapLength</param>
        /// <param name="length">length</param>
        /// <param name="laterals">laterals</param>
        /// <param name="liveLaterals">liveLaterals</param>
        /// <param name="flowDirection">flowDirection</param>
        /// <param name="usmhDepth">usmhDepth</param>
        /// <param name="dsmhDepth">dsmhDepth</param>
        /// <param name="deleted">delete</param>
        /// <param name="companyId">companyId</param>
        /// <param name="flowOrderId">flowOrderId</param>
        public void Insert(int assetId, string sectionId, string street, int? usmh, int? dsmh, string mapSize, string size, string mapLength, string length, int? laterals, int? liveLaterals, string flowDirection, string usmhDepth, string dsmhDepth, bool deleted, int companyId, string flowOrderId)
        {
            SqlParameter assetIdParameter = new SqlParameter("AssetId", assetId);
            SqlParameter sectionIdParameter = new SqlParameter("SectionID", sectionId);
            SqlParameter streetParameter = (street.Trim() != "") ? new SqlParameter("Street", street.Trim()) : new SqlParameter("Street", DBNull.Value);
            SqlParameter usmhParameter = (usmh.HasValue) ? new SqlParameter("USMH", (int)usmh) : new SqlParameter("USMH", DBNull.Value);
            SqlParameter dsmhParameter = (dsmh.HasValue) ? new SqlParameter("DSMH", (int)dsmh) : new SqlParameter("DSMH", DBNull.Value);
            SqlParameter mapSizeParameter = (mapSize.Trim() != "") ? new SqlParameter("MapSize", mapSize.Trim()) : new SqlParameter("MapSize", DBNull.Value);
            SqlParameter sizeParameter = (size.Trim() != "") ? new SqlParameter("Size_", size.Trim()) : new SqlParameter("Size_", DBNull.Value);
            SqlParameter mapLengthParameter = (mapLength.Trim() != "") ? new SqlParameter("MapLength", mapLength.Trim()) : new SqlParameter("MapLength", DBNull.Value);
            SqlParameter lengthParameter = (length.Trim() != "") ? new SqlParameter("Length", length.Trim()) : new SqlParameter("Length", DBNull.Value);
            SqlParameter lateralsParameter = (laterals.HasValue) ? new SqlParameter("Laterals", (int)laterals) : new SqlParameter("Laterals", DBNull.Value);
            SqlParameter liveLateralsParameter = (liveLaterals.HasValue) ? new SqlParameter("LiveLaterals", (int)liveLaterals) : new SqlParameter("LiveLaterals", DBNull.Value);
            SqlParameter flowDirectionParameter = (flowDirection.Trim() != "") ? new SqlParameter("FlowDirection", flowDirection.Trim()) : new SqlParameter("FlowDirection", DBNull.Value);
            SqlParameter usmhDepthParameter = (usmhDepth.Trim() != "") ? new SqlParameter("USMHDepth", usmhDepth.Trim()) : new SqlParameter("USMHDepth", DBNull.Value);
            SqlParameter dsmhDepthParameter = (dsmhDepth.Trim() != "") ? new SqlParameter("DSMHDepth", dsmhDepth.Trim()) : new SqlParameter("DSMHDepth", DBNull.Value);
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            SqlParameter flowOrderIdParameter = (flowOrderId.Trim() != "") ? new SqlParameter("FlowOrderID", flowOrderId.Trim()) : new SqlParameter("FlowOrderID", DBNull.Value);
            
            string command = "INSERT INTO [dbo].[AM_ASSET_SEWER_SECTION] ([AssetID], [SectionID], [Street], [USMH], [DSMH], [MapSize], [Size_], [MapLength], [Length], [Laterals], [LiveLaterals], [FlowDirection], [USMHDepth], [DSMHDepth], [Deleted], [COMPANY_ID], [FlowOrderID]) VALUES (@AssetID, @SectionID, @Street, @USMH, @DSMH, @MapSize, @Size_, @MapLength, @Length, @Laterals, @LiveLaterals, @FlowDirection, @USMHDepth, @DSMHDepth, @Deleted, @COMPANY_ID, @FlowOrderID)";
            
            ExecuteNonQuery(command, assetIdParameter, sectionIdParameter, streetParameter, usmhParameter, dsmhParameter, mapSizeParameter, sizeParameter, mapLengthParameter, lengthParameter, lateralsParameter, liveLateralsParameter, flowDirectionParameter, usmhDepthParameter, dsmhDepthParameter, deletedParameter, companyIdParameter, flowOrderIdParameter);
        }


        

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="originalAssetId">originalAssetId</param>
        /// <param name="originalSectionId">originalSectionId</param>
        /// <param name="originalStreet">originalStreet</param>
        /// <param name="originalUsmh">originalUsmh</param>
        /// <param name="originalDsmh">originalDsmh</param>
        /// <param name="originalMapSize">originalMapSize</param>
        /// <param name="originalSize">originalSize</param>
        /// <param name="originalMapLength">originalMapLength</param>
        /// <param name="originalLength">originalLength</param>
        /// <param name="originalLaterals">originalLaterals</param>
        /// <param name="originalLiveLaterals">originalLiveLaterals</param>
        /// <param name="originalFlowDirection">originalFlowDirection</param>
        /// <param name="originalUsmhDepth">originalUsmhDepth</param>
        /// <param name="originalDsmhDepth">originalDsmhDepth</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalFlowOrderId">originalFlowOrderId</param>
        /// <param name="newAssetId">newAssetId</param>
        /// <param name="newSectionId">newSectionId</param>
        /// <param name="newStreet">newStreet</param>
        /// <param name="newUsmh">newUsmh</param>
        /// <param name="newDsmh">newDsmh</param>
        /// <param name="newMapSize">newMapSize</param>
        /// <param name="newSize">newSize</param>
        /// <param name="newMapLength">newMapLength</param>
        /// <param name="newLength">newLength</param>
        /// <param name="newLaterals">newLaterals</param>
        /// <param name="newLiveLaterals">newLiveLaterals</param>
        /// <param name="newFlowDirection">newFlowDirection</param>
        /// <param name="newUsmhDepth">newUsmhDepth</param>
        /// <param name="newDsmhDepth">newDsmhDepth</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newFlowOrderId">newFlowOrderId</param>
        public void Update(int originalAssetId, string originalSectionId, string originalStreet, int? originalUsmh, int? originalDsmh, string originalMapSize, string originalSize, string originalMapLength, string originalLength, int? originalLaterals, int? originalLiveLaterals, string originalFlowDirection, string originalUsmhDepth, string originalDsmhDepth, bool originalDeleted, int originalCompanyId, string originalFlowOrderId, int newAssetId, string newSectionId, string newStreet, int? newUsmh, int? newDsmh, string newMapSize, string newSize, string newMapLength, string newLength, int? newLaterals, int? newLiveLaterals, string newFlowDirection, string newUsmhDepth, string newDsmhDepth, bool newDeleted, int newCompanyId, string newFlowOrderId)
        {
            //ojo: mario - faltan parametros

            SqlParameter originalAssetIdParameter = new SqlParameter("Original_AssetId", originalAssetId);

            SqlParameter newAssetIdParameter = new SqlParameter("AssetId", newAssetId); 
            SqlParameter newSectionIdParameter = new SqlParameter("SectionID", newSectionId);
            SqlParameter newStreetParameter = (newStreet.Trim() != "") ? new SqlParameter("Street", newStreet.Trim()) : new SqlParameter("Street", DBNull.Value);
            SqlParameter newUsmhParameter = (newUsmh.HasValue) ? new SqlParameter("USMH", (int)newUsmh) : new SqlParameter("USMH", DBNull.Value);
            SqlParameter newDsmhParameter = (newDsmh.HasValue) ? new SqlParameter("DSMH", (int)newDsmh) : new SqlParameter("DSMH", DBNull.Value);
            SqlParameter newMapSizeParameter = (newMapSize.Trim() != "") ? new SqlParameter("MapSize", newMapSize.Trim()) : new SqlParameter("MapSize", DBNull.Value);
            SqlParameter newSizeParameter = (newSize.Trim() != "") ? new SqlParameter("Size_", newSize.Trim()) : new SqlParameter("Size_", DBNull.Value);
            SqlParameter newMapLengthParameter = (newMapLength.Trim() != "") ? new SqlParameter("MapLength", newMapLength.Trim()) : new SqlParameter("MapLength", DBNull.Value);
            SqlParameter newLengthParameter = (newLength.Trim() != "") ? new SqlParameter("Length", newLength.Trim()) : new SqlParameter("Length", DBNull.Value);
            SqlParameter newLateralsParameter = (newLaterals.HasValue) ? new SqlParameter("Laterals", (int)newLaterals) : new SqlParameter("Laterals", DBNull.Value);
            SqlParameter newLiveLateralsParameter = (newLiveLaterals.HasValue) ? new SqlParameter("LiveLaterals", (int)newLiveLaterals) : new SqlParameter("LiveLaterals", DBNull.Value);
            SqlParameter newFlowDirectionParameter = (newFlowDirection.Trim() != "") ? new SqlParameter("FlowDirection", newFlowDirection.Trim()) : new SqlParameter("FlowDirection", DBNull.Value);
            SqlParameter newUsmhDepthParameter = (newUsmhDepth.Trim() != "") ? new SqlParameter("USMHDepth", newUsmhDepth.Trim()) : new SqlParameter("USMHDepth", DBNull.Value);
            SqlParameter newDsmhDepthParameter = (newDsmhDepth.Trim() != "") ? new SqlParameter("DSMHDepth", newDsmhDepth.Trim()) : new SqlParameter("DSMHDepth", DBNull.Value);
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);
            SqlParameter newFlowOrderIdParameter = (newFlowOrderId.Trim() != "") ? new SqlParameter("FlowOrderID", newFlowOrderId.Trim()) : new SqlParameter("FlowOrderID", DBNull.Value);

            string command = "UPDATE [dbo].[AM_ASSET_SEWER_SECTION] " +
                             "SET [AssetID] = @AssetID, [SectionID] = @SectionID, [Street] = @Street,  "+
                             "[USMH] = @USMH, [DSMH] = @DSMH, [MapSize] = @MapSize, [Size_] = @Size_, "+
                             "[MapLength] = @MapLength, [Length] = @Length, [Laterals] = @Laterals, "+
                             "[LiveLaterals] = @LiveLaterals, [FlowDirection] = @FlowDirection, "+
                             "[USMHDepth] = @USMHDepth, [DSMHDepth] = @DSMHDepth, "+
                             "[FlowOrderID] = @FlowOrderID " +
                             "WHERE ([AssetID] = @Original_AssetID) AND ([COMPANY_ID] = @COMPANY_ID)";

            int rowsAffected = (int)ExecuteNonQuery(command, newAssetIdParameter, newSectionIdParameter, newStreetParameter, newUsmhParameter, newDsmhParameter, newMapSizeParameter, newSizeParameter, newMapLengthParameter, newLengthParameter, newLateralsParameter, newLiveLateralsParameter, newFlowDirectionParameter, newUsmhDepthParameter, newDsmhDepthParameter, newDeletedParameter, newCompanyIdParameter, originalAssetIdParameter, newFlowOrderIdParameter);
            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }
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

            string command = "UPDATE [dbo].[AM_ASSET_SEWER_SECTION]" +
                             "SET [Deleted] = @Deleted " +
                             "WHERE (([AssetID] = @AssetID) AND ([COMPANY_ID] = @COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery( command, assetIdParameter, companyIdParameter, deletedParameter);
            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }
        }



    }
}
