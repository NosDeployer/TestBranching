using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.Assets.Assets
{
    /// <summary>
    /// AssetSewerMHGateway
    /// </summary>
    public class AssetSewerMHGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public AssetSewerMHGateway() : base("AM_ASSET_SEWER_MH")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public AssetSewerMHGateway(DataSet data) : base(data, "AM_ASSET_SEWER_MH")
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
            tableMapping.DataSetTable = "AM_ASSET_SEWER_MH";
            tableMapping.ColumnMappings.Add("AssetID", "AssetID");
            tableMapping.ColumnMappings.Add("MHID", "MHID");
            tableMapping.ColumnMappings.Add("Latitud", "Latitud");
            tableMapping.ColumnMappings.Add("Longitude", "Longitude");
            tableMapping.ColumnMappings.Add("Address", "Address");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("ManholeShape", "ManholeShape");
            tableMapping.ColumnMappings.Add("Location", "Location");
            tableMapping.ColumnMappings.Add("MaterialID", "MaterialID");
            tableMapping.ColumnMappings.Add("TopDiameter", "TopDiameter");
            tableMapping.ColumnMappings.Add("TopDepth", "TopDepth");
            tableMapping.ColumnMappings.Add("TopFloor", "TopFloor");
            tableMapping.ColumnMappings.Add("TopCeiling", "TopCeiling");
            tableMapping.ColumnMappings.Add("TopBenching", "TopBenching");
            tableMapping.ColumnMappings.Add("DownDiameter", "DownDiameter");
            tableMapping.ColumnMappings.Add("DownDepth", "DownDepth");
            tableMapping.ColumnMappings.Add("DownFloor", "DownFloor");
            tableMapping.ColumnMappings.Add("DownCeiling", "DownCeiling");
            tableMapping.ColumnMappings.Add("DownBenching", "DownBenching");
            tableMapping.ColumnMappings.Add("Rectangle1LongSide", "Rectangle1LongSide");
            tableMapping.ColumnMappings.Add("Rectangle1ShortSide", "Rectangle1ShortSide");
            tableMapping.ColumnMappings.Add("Rectangle2LongSide", "Rectangle2LongSide");
            tableMapping.ColumnMappings.Add("Rectangle2ShortSide", "Rectangle2ShortSide");
            tableMapping.ColumnMappings.Add("TopSurfaceArea", "TopSurfaceArea");
            tableMapping.ColumnMappings.Add("DownSurfaceArea", "DownSurfaceArea");
            tableMapping.ColumnMappings.Add("ManholeRugs", "ManholeRugs");
            tableMapping.ColumnMappings.Add("TotalDepth", "TotalDepth");
            tableMapping.ColumnMappings.Add("TotalSurfaceArea", "TotalSurfaceArea");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[AM_ASSET_SEWER_MH] WHERE (([AssetID] = @Original_AssetID) AND " +
                "([MHID] = @Original_MHID) AND ((@IsNull_Latitud = 1 AND [Latitud] IS NULL) OR ([" +
                "Latitud] = @Original_Latitud)) AND ((@IsNull_Longitude = 1 AND [Longitude] IS NU" +
                "LL) OR ([Longitude] = @Original_Longitude)) AND ((@IsNull_Address = 1 AND [Addre" +
                "ss] IS NULL) OR ([Address] = @Original_Address)) AND ([Deleted] = @Original_Dele" +
                "ted) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND ((@IsNull_ManholeShape = 1 AN" +
                "D [ManholeShape] IS NULL) OR ([ManholeShape] = @Original_ManholeShape)) AND ((@I" +
                "sNull_Location = 1 AND [Location] IS NULL) OR ([Location] = @Original_Location))" +
                " AND ((@IsNull_MaterialID = 1 AND [MaterialID] IS NULL) OR ([MaterialID] = @Orig" +
                "inal_MaterialID)) AND ((@IsNull_TopDiameter = 1 AND [TopDiameter] IS NULL) OR ([" +
                "TopDiameter] = @Original_TopDiameter)) AND ((@IsNull_TopDepth = 1 AND [TopDepth]" +
                " IS NULL) OR ([TopDepth] = @Original_TopDepth)) AND ((@IsNull_TopFloor = 1 AND [" +
                "TopFloor] IS NULL) OR ([TopFloor] = @Original_TopFloor)) AND ((@IsNull_TopCeilin" +
                "g = 1 AND [TopCeiling] IS NULL) OR ([TopCeiling] = @Original_TopCeiling)) AND ((" +
                "@IsNull_TopBenching = 1 AND [TopBenching] IS NULL) OR ([TopBenching] = @Original" +
                "_TopBenching)) AND ((@IsNull_DownDiameter = 1 AND [DownDiameter] IS NULL) OR ([D" +
                "ownDiameter] = @Original_DownDiameter)) AND ((@IsNull_DownDepth = 1 AND [DownDep" +
                "th] IS NULL) OR ([DownDepth] = @Original_DownDepth)) AND ((@IsNull_DownFloor = 1" +
                " AND [DownFloor] IS NULL) OR ([DownFloor] = @Original_DownFloor)) AND ((@IsNull_" +
                "DownCeiling = 1 AND [DownCeiling] IS NULL) OR ([DownCeiling] = @Original_DownCei" +
                "ling)) AND ((@IsNull_DownBenching = 1 AND [DownBenching] IS NULL) OR ([DownBench" +
                "ing] = @Original_DownBenching)) AND ((@IsNull_Rectangle1LongSide = 1 AND [Rectan" +
                "gle1LongSide] IS NULL) OR ([Rectangle1LongSide] = @Original_Rectangle1LongSide))" +
                " AND ((@IsNull_Rectangle1ShortSide = 1 AND [Rectangle1ShortSide] IS NULL) OR ([R" +
                "ectangle1ShortSide] = @Original_Rectangle1ShortSide)) AND ((@IsNull_Rectangle2Lo" +
                "ngSide = 1 AND [Rectangle2LongSide] IS NULL) OR ([Rectangle2LongSide] = @Origina" +
                "l_Rectangle2LongSide)) AND ((@IsNull_Rectangle2ShortSide = 1 AND [Rectangle2Shor" +
                "tSide] IS NULL) OR ([Rectangle2ShortSide] = @Original_Rectangle2ShortSide)) AND " +
                "((@IsNull_TopSurfaceArea = 1 AND [TopSurfaceArea] IS NULL) OR ([TopSurfaceArea] " +
                "= @Original_TopSurfaceArea)) AND ((@IsNull_DownSurfaceArea = 1 AND [DownSurfaceA" +
                "rea] IS NULL) OR ([DownSurfaceArea] = @Original_DownSurfaceArea)) AND ((@IsNull_" +
                "ManholeRugs = 1 AND [ManholeRugs] IS NULL) OR ([ManholeRugs] = @Original_Manhole" +
                "Rugs)) AND ((@IsNull_TotalDepth = 1 AND [TotalDepth] IS NULL) OR ([TotalDepth] =" +
                " @Original_TotalDepth)) AND ((@IsNull_TotalSurfaceArea = 1 AND [TotalSurfaceArea" +
                "] IS NULL) OR ([TotalSurfaceArea] = @Original_TotalSurfaceArea)))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_AssetID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AssetID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MHID", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MHID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Latitud", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Latitud", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Latitud", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Latitud", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Longitude", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Longitude", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Longitude", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Longitude", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Address", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Address", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Address", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Address", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_ManholeShape", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ManholeShape", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ManholeShape", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ManholeShape", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Location", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Location", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Location", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Location", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_MaterialID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MaterialID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MaterialID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MaterialID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_TopDiameter", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TopDiameter", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TopDiameter", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TopDiameter", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_TopDepth", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TopDepth", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TopDepth", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TopDepth", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_TopFloor", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TopFloor", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TopFloor", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TopFloor", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_TopCeiling", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TopCeiling", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TopCeiling", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TopCeiling", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_TopBenching", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TopBenching", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TopBenching", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TopBenching", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DownDiameter", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DownDiameter", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DownDiameter", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DownDiameter", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DownDepth", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DownDepth", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DownDepth", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DownDepth", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DownFloor", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DownFloor", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DownFloor", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DownFloor", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DownCeiling", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DownCeiling", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DownCeiling", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DownCeiling", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DownBenching", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DownBenching", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DownBenching", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DownBenching", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Rectangle1LongSide", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Rectangle1LongSide", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Rectangle1LongSide", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Rectangle1LongSide", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Rectangle1ShortSide", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Rectangle1ShortSide", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Rectangle1ShortSide", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Rectangle1ShortSide", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Rectangle2LongSide", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Rectangle2LongSide", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Rectangle2LongSide", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Rectangle2LongSide", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Rectangle2ShortSide", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Rectangle2ShortSide", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Rectangle2ShortSide", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Rectangle2ShortSide", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_TopSurfaceArea", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TopSurfaceArea", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TopSurfaceArea", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TopSurfaceArea", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DownSurfaceArea", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DownSurfaceArea", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DownSurfaceArea", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DownSurfaceArea", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_ManholeRugs", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ManholeRugs", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ManholeRugs", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ManholeRugs", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_TotalDepth", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalDepth", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TotalDepth", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalDepth", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_TotalSurfaceArea", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalSurfaceArea", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TotalSurfaceArea", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalSurfaceArea", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[AM_ASSET_SEWER_MH] ([AssetID], [MHID], [Latitud], [Longitude], [Address], [Deleted], [COMPANY_ID], [ManholeShape], [Location], [MaterialID], [TopDiameter], [TopDepth], [TopFloor], [TopCeiling], [TopBenching], [DownDiameter], [DownDepth], [DownFloor], [DownCeiling], [DownBenching], [Rectangle1LongSide], [Rectangle1ShortSide], [Rectangle2LongSide], [Rectangle2ShortSide], [TopSurfaceArea], [DownSurfaceArea], [ManholeRugs], [TotalDepth], [TotalSurfaceArea]) VALUES (@AssetID, @MHID, @Latitud, @Longitude, @Address, @Deleted, @COMPANY_ID, @ManholeShape, @Location, @MaterialID, @TopDiameter, @TopDepth, @TopFloor, @TopCeiling, @TopBenching, @DownDiameter, @DownDepth, @DownFloor, @DownCeiling, @DownBenching, @Rectangle1LongSide, @Rectangle1ShortSide, @Rectangle2LongSide, @Rectangle2ShortSide, @TopSurfaceArea, @DownSurfaceArea, @ManholeRugs, @TotalDepth, @TotalSurfaceArea);
SELECT AssetID, MHID, Latitud, Longitude, Address, Deleted, COMPANY_ID, ManholeShape, Location, MaterialID, TopDiameter, TopDepth, TopFloor, TopCeiling, TopBenching, DownDiameter, DownDepth, DownFloor, DownCeiling, DownBenching, Rectangle1LongSide, Rectangle1ShortSide, Rectangle2LongSide, Rectangle2ShortSide, TopSurfaceArea, DownSurfaceArea, ManholeRugs, TotalDepth, TotalSurfaceArea FROM AM_ASSET_SEWER_MH WHERE (AssetID = @AssetID)";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@AssetID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AssetID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MHID", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MHID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Latitud", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Latitud", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Longitude", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Longitude", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Address", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Address", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ManholeShape", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ManholeShape", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Location", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Location", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MaterialID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MaterialID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TopDiameter", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TopDiameter", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TopDepth", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TopDepth", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TopFloor", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TopFloor", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TopCeiling", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TopCeiling", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TopBenching", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TopBenching", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DownDiameter", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DownDiameter", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DownDepth", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DownDepth", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DownFloor", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DownFloor", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DownCeiling", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DownCeiling", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DownBenching", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DownBenching", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Rectangle1LongSide", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Rectangle1LongSide", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Rectangle1ShortSide", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Rectangle1ShortSide", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Rectangle2LongSide", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Rectangle2LongSide", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Rectangle2ShortSide", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Rectangle2ShortSide", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TopSurfaceArea", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TopSurfaceArea", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DownSurfaceArea", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DownSurfaceArea", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ManholeRugs", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ManholeRugs", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TotalDepth", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalDepth", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TotalSurfaceArea", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalSurfaceArea", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));

            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[AM_ASSET_SEWER_MH] SET [AssetID] = @AssetID, [MHID] = @MHID, [Latit" +
                "ud] = @Latitud, [Longitude] = @Longitude, [Address] = @Address, [Deleted] = @Del" +
                "eted, [COMPANY_ID] = @COMPANY_ID, [ManholeShape] = @ManholeShape, [Location] = @" +
                "Location, [MaterialID] = @MaterialID, [TopDiameter] = @TopDiameter, [TopDepth] =" +
                " @TopDepth, [TopFloor] = @TopFloor, [TopCeiling] = @TopCeiling, [TopBenching] = " +
                "@TopBenching, [DownDiameter] = @DownDiameter, [DownDepth] = @DownDepth, [DownFlo" +
                "or] = @DownFloor, [DownCeiling] = @DownCeiling, [DownBenching] = @DownBenching, " +
                "[Rectangle1LongSide] = @Rectangle1LongSide, [Rectangle1ShortSide] = @Rectangle1S" +
                "hortSide, [Rectangle2LongSide] = @Rectangle2LongSide, [Rectangle2ShortSide] = @R" +
                "ectangle2ShortSide, [TopSurfaceArea] = @TopSurfaceArea, [DownSurfaceArea] = @Dow" +
                "nSurfaceArea, [ManholeRugs] = @ManholeRugs, [TotalDepth] = @TotalDepth, [TotalSu" +
                "rfaceArea] = @TotalSurfaceArea WHERE (([AssetID] = @Original_AssetID) AND ([MHID" +
                "] = @Original_MHID) AND ((@IsNull_Latitud = 1 AND [Latitud] IS NULL) OR ([Latitu" +
                "d] = @Original_Latitud)) AND ((@IsNull_Longitude = 1 AND [Longitude] IS NULL) OR" +
                " ([Longitude] = @Original_Longitude)) AND ((@IsNull_Address = 1 AND [Address] IS" +
                " NULL) OR ([Address] = @Original_Address)) AND ([Deleted] = @Original_Deleted) A" +
                "ND ([COMPANY_ID] = @Original_COMPANY_ID) AND ((@IsNull_ManholeShape = 1 AND [Man" +
                "holeShape] IS NULL) OR ([ManholeShape] = @Original_ManholeShape)) AND ((@IsNull_" +
                "Location = 1 AND [Location] IS NULL) OR ([Location] = @Original_Location)) AND (" +
                "(@IsNull_MaterialID = 1 AND [MaterialID] IS NULL) OR ([MaterialID] = @Original_M" +
                "aterialID)) AND ((@IsNull_TopDiameter = 1 AND [TopDiameter] IS NULL) OR ([TopDia" +
                "meter] = @Original_TopDiameter)) AND ((@IsNull_TopDepth = 1 AND [TopDepth] IS NU" +
                "LL) OR ([TopDepth] = @Original_TopDepth)) AND ((@IsNull_TopFloor = 1 AND [TopFlo" +
                "or] IS NULL) OR ([TopFloor] = @Original_TopFloor)) AND ((@IsNull_TopCeiling = 1 " +
                "AND [TopCeiling] IS NULL) OR ([TopCeiling] = @Original_TopCeiling)) AND ((@IsNul" +
                "l_TopBenching = 1 AND [TopBenching] IS NULL) OR ([TopBenching] = @Original_TopBe" +
                "nching)) AND ((@IsNull_DownDiameter = 1 AND [DownDiameter] IS NULL) OR ([DownDia" +
                "meter] = @Original_DownDiameter)) AND ((@IsNull_DownDepth = 1 AND [DownDepth] IS" +
                " NULL) OR ([DownDepth] = @Original_DownDepth)) AND ((@IsNull_DownFloor = 1 AND [" +
                "DownFloor] IS NULL) OR ([DownFloor] = @Original_DownFloor)) AND ((@IsNull_DownCe" +
                "iling = 1 AND [DownCeiling] IS NULL) OR ([DownCeiling] = @Original_DownCeiling))" +
                " AND ((@IsNull_DownBenching = 1 AND [DownBenching] IS NULL) OR ([DownBenching] =" +
                " @Original_DownBenching)) AND ((@IsNull_Rectangle1LongSide = 1 AND [Rectangle1Lo" +
                "ngSide] IS NULL) OR ([Rectangle1LongSide] = @Original_Rectangle1LongSide)) AND (" +
                "(@IsNull_Rectangle1ShortSide = 1 AND [Rectangle1ShortSide] IS NULL) OR ([Rectang" +
                "le1ShortSide] = @Original_Rectangle1ShortSide)) AND ((@IsNull_Rectangle2LongSide" +
                " = 1 AND [Rectangle2LongSide] IS NULL) OR ([Rectangle2LongSide] = @Original_Rect" +
                "angle2LongSide)) AND ((@IsNull_Rectangle2ShortSide = 1 AND [Rectangle2ShortSide]" +
                " IS NULL) OR ([Rectangle2ShortSide] = @Original_Rectangle2ShortSide)) AND ((@IsN" +
                "ull_TopSurfaceArea = 1 AND [TopSurfaceArea] IS NULL) OR ([TopSurfaceArea] = @Ori" +
                "ginal_TopSurfaceArea)) AND ((@IsNull_DownSurfaceArea = 1 AND [DownSurfaceArea] I" +
                "S NULL) OR ([DownSurfaceArea] = @Original_DownSurfaceArea)) AND ((@IsNull_Manhol" +
                "eRugs = 1 AND [ManholeRugs] IS NULL) OR ([ManholeRugs] = @Original_ManholeRugs))" +
                " AND ((@IsNull_TotalDepth = 1 AND [TotalDepth] IS NULL) OR ([TotalDepth] = @Orig" +
                "inal_TotalDepth)) AND ((@IsNull_TotalSurfaceArea = 1 AND [TotalSurfaceArea] IS N" +
                "ULL) OR ([TotalSurfaceArea] = @Original_TotalSurfaceArea)));\r\nSELECT AssetID, MH" +
                "ID, Latitud, Longitude, Address, Deleted, COMPANY_ID, ManholeShape, Location, Ma" +
                "terialID, TopDiameter, TopDepth, TopFloor, TopCeiling, TopBenching, DownDiameter" +
                ", DownDepth, DownFloor, DownCeiling, DownBenching, Rectangle1LongSide, Rectangle" +
                "1ShortSide, Rectangle2LongSide, Rectangle2ShortSide, TopSurfaceArea, DownSurface" +
                "Area, ManholeRugs, TotalDepth, TotalSurfaceArea FROM AM_ASSET_SEWER_MH WHERE (As" +
                "setID = @AssetID)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@AssetID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AssetID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MHID", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MHID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Latitud", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Latitud", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Longitude", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Longitude", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Address", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Address", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ManholeShape", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ManholeShape", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Location", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Location", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MaterialID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MaterialID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TopDiameter", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TopDiameter", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TopDepth", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TopDepth", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TopFloor", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TopFloor", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TopCeiling", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TopCeiling", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TopBenching", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TopBenching", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DownDiameter", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DownDiameter", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DownDepth", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DownDepth", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DownFloor", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DownFloor", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DownCeiling", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DownCeiling", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DownBenching", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DownBenching", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Rectangle1LongSide", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Rectangle1LongSide", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Rectangle1ShortSide", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Rectangle1ShortSide", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Rectangle2LongSide", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Rectangle2LongSide", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Rectangle2ShortSide", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Rectangle2ShortSide", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TopSurfaceArea", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TopSurfaceArea", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DownSurfaceArea", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DownSurfaceArea", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ManholeRugs", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ManholeRugs", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TotalDepth", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalDepth", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TotalSurfaceArea", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalSurfaceArea", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_AssetID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AssetID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MHID", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MHID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Latitud", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Latitud", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Latitud", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Latitud", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Longitude", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Longitude", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Longitude", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Longitude", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Address", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Address", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Address", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Address", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_ManholeShape", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ManholeShape", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ManholeShape", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ManholeShape", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Location", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Location", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Location", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Location", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_MaterialID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MaterialID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MaterialID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MaterialID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_TopDiameter", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TopDiameter", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TopDiameter", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TopDiameter", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_TopDepth", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TopDepth", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TopDepth", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TopDepth", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_TopFloor", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TopFloor", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TopFloor", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TopFloor", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_TopCeiling", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TopCeiling", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TopCeiling", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TopCeiling", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_TopBenching", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TopBenching", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TopBenching", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TopBenching", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DownDiameter", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DownDiameter", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DownDiameter", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DownDiameter", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DownDepth", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DownDepth", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DownDepth", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DownDepth", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DownFloor", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DownFloor", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DownFloor", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DownFloor", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DownCeiling", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DownCeiling", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DownCeiling", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DownCeiling", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DownBenching", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DownBenching", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DownBenching", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DownBenching", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Rectangle1LongSide", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Rectangle1LongSide", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Rectangle1LongSide", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Rectangle1LongSide", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Rectangle1ShortSide", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Rectangle1ShortSide", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Rectangle1ShortSide", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Rectangle1ShortSide", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Rectangle2LongSide", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Rectangle2LongSide", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Rectangle2LongSide", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Rectangle2LongSide", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Rectangle2ShortSide", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Rectangle2ShortSide", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Rectangle2ShortSide", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Rectangle2ShortSide", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_TopSurfaceArea", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TopSurfaceArea", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TopSurfaceArea", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TopSurfaceArea", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DownSurfaceArea", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DownSurfaceArea", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DownSurfaceArea", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DownSurfaceArea", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_ManholeRugs", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ManholeRugs", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ManholeRugs", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ManholeRugs", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_TotalDepth", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalDepth", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TotalDepth", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalDepth", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_TotalSurfaceArea", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalSurfaceArea", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TotalSurfaceArea", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalSurfaceArea", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //
               
        /// <summary>
        /// LoadByAssetID
        /// </summary>
        /// <param name="assetId">assetID</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>
        public DataSet LoadByAssetId(int assetId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_ASSETS_ASSETSEWERMHGATEWAY_LOADBYASSETID", new SqlParameter("@assetId", assetId), new SqlParameter("@companyId", companyId));
            return Data;

        }



        /// <summary>
        /// LoadByCountryIdProvinceIdCountyIdCityIdMhId
        /// </summary>
        /// <param name="countryId">countryId</param>
        /// <param name="provinceId">provinceId</param>
        /// <param name="countyId">countyId</param>
        /// <param name="cityId">cityId</param>
        /// <param name="mhId">mhId</param>
        /// <param name="companyId">companyId</param>
        /// <returns></returns>
        public DataSet LoadByCountryIdProvinceIdCountyIdCityIdMhId(Int64? countryId, Int64? provinceId, Int64? countyId, Int64? cityId, string mhId, int companyId, string latitud, string longitude, string address)
        {
            string mhIdForSql = mhId.Replace("'", "''");
            string countryParameter = (countryId.HasValue) ? ("AND (AMA.CountryID = " + ((Int64)countryId).ToString() + ")") : ("AND (AMA.CountryID IS NULL)");
            string provinceParameter = (provinceId.HasValue) ? ("AND (AMA.ProvinceID = " + ((Int64)provinceId).ToString() + ")") : ("AND (AMA.ProvinceID IS NULL)");
            string countyParameter = (countyId.HasValue) ? ("AND (AMA.CountyID = " + ((Int64)countyId).ToString() + ")") : ("AND (AMA.CountyID IS NULL)");
            string cityParameter = (cityId.HasValue) ? ("AND (AMA.CityID = " + ((Int64)cityId).ToString() + ")") : ("AND (AMA.CityID IS NULL)");
            string latitudParameter = (latitud.Trim() != "") ? ("AND (AMASM.Latitud LIKE '" + latitud + "%')") : ("AND (AMASM.Latitud IS NULL)");
            string longitudeParameter = (longitude.Trim() != "") ? ("AND (AMASM.Longitude LIKE '" + longitude + "%')") : ("AND (AMASM.Longitude IS NULL)");
            string addressParameter = (address.Trim() != "") ? ("AND (AMASM.Address LIKE '" + address + "%')") : ("AND (AMASM.Address IS NULL)");

            string command = string.Format("SELECT AMASM.AssetID, AMASM.MHID, AMASM.Latitud, AMASM.Longitude, AMASM.Address, AMASM.Deleted, AMASM.COMPANY_ID, AMASM.ManholeShape, AMASM.Location, AMASM.MaterialID, AMASM.TopDiameter, AMASM.TopDepth, AMASM.TopFloor, AMASM.TopCeiling, AMASM.TopBenching, AMASM.DownDiameter, AMASM.DownDepth, AMASM.DownFloor, AMASM.DownCeiling, AMASM.DownBenching, AMASM.Rectangle1LongSide, AMASM.Rectangle1ShortSide, AMASM.Rectangle2LongSide, AMASM.Rectangle2ShortSide, AMASM.TopSurfaceArea, AMASM.DownSurfaceArea, AMASM.ManholeRugs, AMASM.TotalDepth, AMASM.TotalSurfaceArea"+
                " FROM dbo.AM_ASSET_SEWER_MH AMASM INNER JOIN dbo.AM_ASSET AMA ON AMASM.AssetID = AMA.AssetID WHERE (AMASM.Deleted = 0) AND (AMASM.MHID = '{0}') AND (AMASM.COMPANY_ID= {1}) {2} {3} {4} {5} {6} {7} {8}", mhIdForSql, companyId, countryParameter, provinceParameter, countyParameter, cityParameter, latitudParameter, longitudeParameter, addressParameter);
            FillData(command);

            return Data;
        }



        /// <summary>
        /// LoadSimilarByCountryIdProvinceIdCountyIdCityIdMhId
        /// </summary>
        /// <param name="countryId">countryId</param>
        /// <param name="provinceId">provinceId</param>
        /// <param name="countyId">countyId</param>
        /// <param name="cityId">cityId</param>
        /// <param name="mhId">mhId</param>
        /// <param name="companyId">companyId</param>
        public DataSet LoadSimilarTop12ByCountryIdProvinceIdCountyIdCityIdMhId(Int64? countryId, Int64? provinceId, Int64? countyId, Int64? cityId, string mhId, int companyId)
        {
            string countryIdParameter = "A.CountryID = " + countryId.ToString();
            string provinceIdParameter = (provinceId.HasValue) ? ("A.ProvinceID = " + ((Int64)provinceId).ToString()) : ("A.ProvinceID IS NULL");
            string countyIdParameter = (countyId.HasValue) ? ("A.CountyID = " + ((Int64)countyId).ToString()) : ("A.CountyID IS NULL");
            string cityIdParameter = (cityId.HasValue) ? ("A.CityID = " + ((Int64)cityId).ToString()) : ("A.CityID IS NULL");
            string mhIdParameter = "ASM.MHID LIKE '" + mhId + "%'";
            string companyIdParameter = "A.COMPANY_ID = " + companyId.ToString();

            string commandText = String.Format("SELECT TOP 12 ASM.AssetID, ASM.MHID, ASM.Latitud, ASM.Longitude, ASM.Address, ASM.Deleted, ASM.COMPANY_ID ASM.ManholeShape, ASM.Location, ASM.MaterialID, ASM.TopDiameter, ASM.TopDepth, ASM.TopFloor, ASM.TopCeiling, ASM.TopBenching, ASM.DownDiameter, ASM.DownDepth, ASM.DownFloor, ASM.DownCeiling, ASM.DownBenching, ASM.Rectangle1LongSide, ASM.Rectangle1ShortSide, ASM.Rectangle2LongSide, ASM.Rectangle2ShortSide, ASM.TopSurfaceArea, ASM.DownSurfaceArea, ASM.ManholeRugs, ASM.TotalDepth, ASM.TotalSurfaceArea "+
                " FROM dbo.AM_ASSET_SEWER_MH ASM INNER JOIN dbo.AM_ASSET A ON ASM.AssetID = A.AssetID WHERE (A.Deleted = 0) AND {0} AND {1} AND {2} AND {3} AND {4} AND {5} ORDER BY ASM.MHID", mhIdParameter, countryIdParameter, provinceIdParameter, countyIdParameter, cityIdParameter, companyIdParameter);
            FillData(commandText);

            return Data;
        }



        /// <summary>
        /// LoadByMhId
        /// </summary>
        /// <param name="mhId">mhId</param>
        /// <param name="companyId">companyId</param>
        /// <returns></returns>
        public DataSet LoadTop1ByMhId(string mhId, int companyId)
        {
            string command = string.Format("SELECT TOP 1 AMASM.AssetID, AMASM.MHID, AMASM.Latitud, AMASM.Longitude, AMASM.Address, AMASM.Deleted, AMASM.COMPANY_ID, AMASM.ManholeShape, AMASM.Location, AMASM.MaterialID, AMASM.TopDiameter, AMASM.TopDepth, AMASM.TopFloor, AMASM.TopCeiling, AMASM.TopBenching, AMASM.DownDiameter, AMASM.DownDepth, AMASM.DownFloor, AMASM.DownCeiling, AMASM.DownBenching, AMASM.Rectangle1LongSide, AMASM.Rectangle1ShortSide, AMASM.Rectangle2LongSide, AMASM.Rectangle2ShortSide, AMASM.TopSurfaceArea, AMASM.DownSurfaceArea, AMASM.ManholeRugs, AMASM.TotalDepth, AMASM.TotalSurfaceArea" +
                " FROM dbo.AM_ASSET_SEWER_MH AMASM INNER JOIN dbo.AM_ASSET AMA ON AMASM.AssetID = AMA.AssetID WHERE (AMASM.Deleted = 0) AND (AMASM.MHID = '{0}') AND (AMASM.COMPANY_ID= {1}) ", mhId, companyId);
            FillData(command);

            return Data;
        }



        /// <summary>
        /// LoadByMhIdProjectId
        /// </summary>
        /// <param name="mhId">mhId</param>
        /// <param name="projectId">projectId</param>
        /// <param name="companyId">companyId</param>
        /// <returns></returns>
        public DataSet LoadTop1ByMhIdProjectId(string mhId, int projectId, int companyId)
        {
            string command = string.Format("SELECT TOP 1 AMASM.AssetID, AMASM.MHID, AMASM.Latitud, AMASM.Longitude, AMASM.Address, AMASM.Deleted, AMASM.COMPANY_ID, AMASM.ManholeShape, AMASM.Location, AMASM.MaterialID, AMASM.TopDiameter, AMASM.TopDepth, "+
                        " AMASM.TopFloor, AMASM.TopCeiling, AMASM.TopBenching, AMASM.DownDiameter, AMASM.DownDepth, AMASM.DownFloor, AMASM.DownCeiling, AMASM.DownBenching, AMASM.Rectangle1LongSide, AMASM.Rectangle1ShortSide, AMASM.Rectangle2LongSide, "+
                        " AMASM.Rectangle2ShortSide, AMASM.TopSurfaceArea, AMASM.DownSurfaceArea, AMASM.ManholeRugs, AMASM.TotalDepth, AMASM.TotalSurfaceArea" +
                        " "+
                        " FROM dbo.AM_ASSET_SEWER_MH AMASM INNER JOIN "+
                        "      dbo.AM_ASSET AMA ON AMASM.AssetID = AMA.AssetID INNER JOIN "+
                        "      dbo.AM_ASSET_SEWER_SECTION AASS ON AMASM.AssetID = AASS.USMH OR AMASM.AssetID = AASS.DSMH INNER JOIN "+
                        "      dbo.LFS_WORK LW ON AASS.AssetID = LW.AssetID INNER JOIN "+
                        "      dbo.LFS_PROJECT LP ON LW.ProjectID = LP.ProjectID "+
                        " "+
                        " WHERE (AMASM.Deleted = 0) AND (AMASM.MHID = '{0}') AND (AMASM.COMPANY_ID = {1}) AND (LP.ProjectID = {2}) ", mhId, companyId, projectId);
            FillData(command);

            return Data;
        }




        /// <summary>
        ///  Get a single row. If not exists, raise an exception.
        /// </summary>
        /// <param name="mhId">mhId</param>
        /// <returns>Row obtained</returns>
        public DataRow GetRow(string mhId)
        {
            string mhIdForSql = mhId.Replace("'", "''");
            string filter = string.Format("(MHID = '{0}') ", mhId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.Assets.Assets.AssetSewerMHGateway.GetRow");
            }
        }



        /// <summary>
        ///  Get a single row. If not exists, raise an exception.
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>Row obtained</returns>
        public DataRow GetRow(int assetId)
        {
            string filter = string.Format("(AssetID = '{0}') ", assetId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.Assets.Assets.AssetSewerMHGateway.GetRow");
            }

        }

        

        /// <summary>
        /// GetAssetID. If not exists, raise an exception.
        /// </summary>
        /// <param name="mhId">mhId</param>
        /// <returns>Asset Id</returns>
        public int GetAssetID(string mhId)
        {
            return (int)GetRow(mhId)["AssetID"];
        }



        /// <summary>
        /// GetMHID. If not exists, raise an exception.
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>Asset Id</returns>
        public string GetMHID(int assetId)
        {
            if (GetRow(assetId).IsNull("MHID"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["MHID"];
            }
        }



        /// <summary>
        /// GetAddress. If not exists, raise an exception.
        /// </summary>
        /// <param name="mhId">mhId</param>
        /// <returns>Address</returns>
        public string GetAddress(string mhId)
        {
            if (GetRow(mhId).IsNull("Address"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(mhId)["Address"];
            }
        }



        /// <summary>
        /// GetLatitude. If not exists, raise an exception.
        /// </summary>
        /// <param name="mhId">mhId</param>
        /// <returns>Latitude</returns>
        public string GetLatitude(string mhId)
        {
            if (GetRow(mhId).IsNull("Latitud"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(mhId)["Latitud"];
            }
        }



        /// <summary>
        /// GetLongitude. If not exists, raise an exception.
        /// </summary>
        /// <param name="mhId">mhId</param>
        /// <returns>Longitude</returns>
        public string GetLongitude(string mhId)
        {
            if (GetRow(mhId).IsNull("Longitude"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(mhId)["Longitude"];
            }
        }



        /// <summary>
        /// GetDeleted. If section not exists, raise an exception.
        /// </summary>
        /// <param name="mhId">mhId</param>
        /// <returns>TRUE if section deleted</returns>
        public bool GetDeleted(string mhId)
        {
            return (bool)GetRow(mhId)["Deleted"];
        }



        /// <summary>
        /// GetCompanyId. If section not exists, raise an exception.
        /// </summary>
        /// <param name="mhId">mhId</param>
        /// <returns>CompanyId </returns>
        public int GetCompanyId(string mhId)
        {
            return (int)GetRow(mhId)["COMPANY_ID"];
        }



        /// <summary>
        /// GetManholeShape. If not exists, raise an exception.
        /// </summary>
        /// <param name="mhId">mhId</param>
        /// <returns>ManholeShape</returns>
        public string GetManholeShape(string mhId)
        {
            if (GetRow(mhId).IsNull("ManholeShape"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(mhId)["ManholeShape"];
            }
        }



        /// <summary>
        /// GetLocation. If not exists, raise an exception.
        /// </summary>
        /// <param name="mhId">mhId</param>
        /// <returns>Location</returns>
        public string GetLocation(string mhId)
        {
            if (GetRow(mhId).IsNull("Location"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(mhId)["Location"];
            }
        }



        /// <summary>
        /// GetMaterialID. If not exists, raise an exception.
        /// </summary>
        /// <param name="mhId">mhId</param>
        /// <returns>MaterialID</returns>
        public int? GetMaterialID(string mhId)
        {
            if (GetRow(mhId).IsNull("MaterialID"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(mhId)["MaterialID"];
            }
        }



        /// <summary>
        /// GetTopDiameter. If not exists, raise an exception.
        /// </summary>
        /// <param name="mhId">mhId</param>
        /// <returns>TopDiameter</returns>
        public string GetTopDiameter(string mhId)
        {
            if (GetRow(mhId).IsNull("TopDiameter"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(mhId)["TopDiameter"];
            }
        }



        /// <summary>
        /// GetTopDepth. If not exists, raise an exception.
        /// </summary>
        /// <param name="mhId">mhId</param>
        /// <returns>TopDepth</returns>
        public string GetTopDepth(string mhId)
        {
            if (GetRow(mhId).IsNull("TopDepth"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(mhId)["TopDepth"];
            }
        }



        /// <summary>
        /// GetTopFloor. If not exists, raise an exception.
        /// </summary>
        /// <param name="mhId">mhId</param>
        /// <returns>TopFloor</returns>
        public string GetTopFloor(string mhId)
        {
            if (GetRow(mhId).IsNull("TopFloor"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(mhId)["TopFloor"];
            }
        }



        /// <summary>
        /// GetTopCeiling. If not exists, raise an exception.
        /// </summary>
        /// <param name="mhId">mhId</param>
        /// <returns>TopCeiling</returns>
        public string GetTopCeiling(string mhId)
        {
            if (GetRow(mhId).IsNull("TopCeiling"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(mhId)["TopCeiling"];
            }
        }



        /// <summary>
        /// GetTopBenching. If not exists, raise an exception.
        /// </summary>
        /// <param name="mhId">mhId</param>
        /// <returns>TopBenching</returns>
        public string GetTopBenching(string mhId)
        {
            if (GetRow(mhId).IsNull("TopBenching"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(mhId)["TopBenching"];
            }
        }



        /// <summary>
        /// GetDownDiameter. If not exists, raise an exception.
        /// </summary>
        /// <param name="mhId">mhId</param>
        /// <returns>DownDiameter</returns>
        public string GetDownDiameter(string mhId)
        {
            if (GetRow(mhId).IsNull("DownDiameter"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(mhId)["DownDiameter"];
            }
        }



        /// <summary>
        /// GetDownDepth. If not exists, raise an exception.
        /// </summary>
        /// <param name="mhId">mhId</param>
        /// <returns>DownDepth</returns>
        public string GetDownDepth(string mhId)
        {
            if (GetRow(mhId).IsNull("DownDepth"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(mhId)["DownDepth"];
            }
        }



        /// <summary>
        /// GetDownFloor. If not exists, raise an exception.
        /// </summary>
        /// <param name="mhId">mhId</param>
        /// <returns>DownFloor</returns>
        public string GetDownFloor(string mhId)
        {
            if (GetRow(mhId).IsNull("DownFloor"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(mhId)["DownFloor"];
            }
        }



        /// <summary>
        /// GetDownCeiling. If not exists, raise an exception.
        /// </summary>
        /// <param name="mhId">mhId</param>
        /// <returns>DownCeiling</returns>
        public string GetDownCeiling(string mhId)
        {
            if (GetRow(mhId).IsNull("DownCeiling"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(mhId)["DownCeiling"];
            }
        }



        /// <summary>
        /// GetDownBenching. If not exists, raise an exception.
        /// </summary>
        /// <param name="mhId">mhId</param>
        /// <returns>DownBenching</returns>
        public string GetDownBenching(string mhId)
        {
            if (GetRow(mhId).IsNull("DownBenching"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(mhId)["DownBenching"];
            }
        }



        /// <summary>
        /// GetRectangle1LongSide. If not exists, raise an exception.
        /// </summary>
        /// <param name="mhId">mhId</param>
        /// <returns>Rectangle1LongSide</returns>
        public string GetRectangle1LongSide(string mhId)
        {
            if (GetRow(mhId).IsNull("Rectangle1LongSide"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(mhId)["Rectangle1LongSide"];
            }
        }



        /// <summary>
        /// GetRectangle1ShortSide. If not exists, raise an exception.
        /// </summary>
        /// <param name="mhId">mhId</param>
        /// <returns>Rectangle1ShortSide</returns>
        public string GetRectangle1ShortSide(string mhId)
        {
            if (GetRow(mhId).IsNull("Rectangle1ShortSide"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(mhId)["Rectangle1ShortSide"];
            }
        }



        /// <summary>
        /// GetRectangle2LongSide. If not exists, raise an exception.
        /// </summary>
        /// <param name="mhId">mhId</param>
        /// <returns>Rectangle2LongSide</returns>
        public string GetRectangle2LongSide(string mhId)
        {
            if (GetRow(mhId).IsNull("Rectangle2LongSide"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(mhId)["Rectangle2LongSide"];
            }
        }



        /// <summary>
        /// GetRectangle2ShortSide. If not exists, raise an exception.
        /// </summary>
        /// <param name="mhId">mhId</param>
        /// <returns>Rectangle2ShortSide</returns>
        public string GetRectangle2ShortSide(string mhId)
        {
            if (GetRow(mhId).IsNull("Rectangle2ShortSide"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(mhId)["Rectangle2ShortSide"];
            }
        }



        /// <summary>
        /// GetTopSurfaceArea. If not exists, raise an exception.
        /// </summary>
        /// <param name="mhId">mhId</param>
        /// <returns>TopSurfaceArea</returns>
        public string GetTopSurfaceArea(string mhId)
        {
            if (GetRow(mhId).IsNull("TopSurfaceArea"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(mhId)["TopSurfaceArea"];
            }
        }



        /// <summary>
        /// GetDownSurfaceArea. If not exists, raise an exception.
        /// </summary>
        /// <param name="mhId">mhId</param>
        /// <returns>DownSurfaceArea</returns>
        public string GetDownSurfaceArea(string mhId)
        {
            if (GetRow(mhId).IsNull("DownSurfaceArea"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(mhId)["DownSurfaceArea"];
            }
        }



        /// <summary>
        /// GetManholeRugs. If not exists, raise an exception.
        /// </summary>
        /// <param name="mhId">mhId</param>
        /// <returns>ManholeRugs</returns>
        public int? GetManholeRugs(string mhId)
        {
            if (GetRow(mhId).IsNull("ManholeRugs"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(mhId)["ManholeRugs"];
            }
        }



        /// <summary>
        /// GetTotalDepth. If not exists, raise an exception.
        /// </summary>
        /// <param name="mhId">mhId</param>
        /// <returns>TotalDepth</returns>
        public string GetTotalDepth(string mhId)
        {
            if (GetRow(mhId).IsNull("TotalDepth"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(mhId)["TotalDepth"];
            }
        }



        /// <summary>
        /// GetTotalSurfaceArea. If not exists, raise an exception.
        /// </summary>
        /// <param name="mhId">mhId</param>
        /// <returns>TotalSurfaceArea</returns>
        public string GetTotalSurfaceArea(string mhId)
        {
            if (GetRow(mhId).IsNull("TotalSurfaceArea"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(mhId)["TotalSurfaceArea"];
            }
        }




        

        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - QUERIES
        //

        /// <summary>
        /// InUseForSections
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>true or false</returns>
        public bool InUseForSections(int assetId, int companyId)
        {
            SqlParameter assetIdParameter = new SqlParameter("AssetId", assetId);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);

            string command = "SELECT COUNT(*) FROM dbo.AM_ASSET_SEWER_SECTION WHERE (Deleted = 0) AND (COMPANY_ID = @COMPANY_ID) AND ((USMH = @AssetID) OR (DSMH = @AssetID))";

            int count = (int) ExecuteScalar(command, assetIdParameter, companyIdParameter);

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
        /// USmhDsmhInUseForSections
        /// </summary>
        /// <param name="assetIdUsmh">assetIdUsmh</param>
        /// <param name="assetIdDsmh">assetIdDsmh</param>
        /// <param name="companyId">companyId</param>
        /// <returns>true or false</returns>
        public bool USmhDsmhInUseForSections(int assetIdUsmh, int assetIdDsmh, int companyId)
        {
            SqlParameter assetIdUsmhParameter = new SqlParameter("AssetIdUsmh", assetIdUsmh);
            SqlParameter assetIdDsmhParameter = new SqlParameter("AssetIdDsmh", assetIdDsmh);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);

            string command = "SELECT COUNT(*) FROM dbo.AM_ASSET_SEWER_SECTION WHERE (Deleted = 0) AND (COMPANY_ID = @COMPANY_ID) AND ( ((USMH = @AssetIdUsmh) AND (DSMH = @AssetIdDsmh)) OR ((USMH = @AssetIdDsmh) AND (DSMH = @AssetIdUsmh)) )";

            int count = (int)ExecuteScalar(command, assetIdUsmhParameter, assetIdDsmhParameter, companyIdParameter);

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
        // PUBLIC METHODS - SINGLE ROW
        //

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="mhId">mhId</param>
        /// <param name="latitude">latitude</param>
        /// <param name="longitude">longitude</param>
        /// <param name="address">address</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="manholeShape">manholeShape</param>
        /// <param name="location">location</param>
        /// <param name="materialID">materialID</param>
        /// <param name="topDiameter">topDiameter</param>
        /// <param name="topDepth">topDepth</param>
        /// <param name="topFloor">topFloor</param>
        /// <param name="topCeiling">topCeiling</param>
        /// <param name="topBenching">topBenching</param>
        /// <param name="downDiameter">downDiameter</param>
        /// <param name="downDepth">downDepth</param>
        /// <param name="downFloor">downFloor</param>
        /// <param name="downCeiling">downCeiling</param>
        /// <param name="downBenching">downBenching</param>
        /// <param name="rectangle1LongSide">rectangle1LongSide</param>
        /// <param name="rectangle1ShortSide">rectangle1ShortSide</param>
        /// <param name="rectangle2LongSide">rectangle2LongSide</param>
        /// <param name="rectangle2ShortSide">rectangle2ShortSide</param>
        /// <param name="topSurfaceArea">topSurfaceArea</param>
        /// <param name="downSurfaceArea">downSurfaceArea</param>
        /// <param name="manholeRugs">manholeRugs</param>
        /// <param name="totalDepth">totalDepth</param>
        /// <param name="totalSurfaceArea">totalSurfaceArea</param>
        public void Insert(int assetId, string mhId, string latitude, string longitude, string address, bool deleted, int companyId, string manholeShape, string location, int? materialID, string topDiameter, string topDepth, string topFloor, string topCeiling, string topBenching, string downDiameter, string downDepth, string downFloor, string downCeiling, string downBenching, string rectangle1LongSide, string rectangle1ShortSide, string rectangle2LongSide, string rectangle2ShortSide, string topSurfaceArea, string downSurfaceArea, int? manholeRugs, string totalDepth, string totalSurfaceArea)
        {
            SqlParameter assetIdParameter = new SqlParameter("AssetId", assetId);
            SqlParameter mhIdParameter = new SqlParameter("MHID", mhId);
            SqlParameter latitudeParameter = (latitude.Trim() != "") ? new SqlParameter("Latitud", latitude.Trim()) : new SqlParameter("Latitud", DBNull.Value);
            SqlParameter longitudeParameter = (longitude.Trim() != "") ? new SqlParameter("Longitude", longitude.Trim()) : new SqlParameter("Longitude", DBNull.Value);
            SqlParameter addressParameter = (address.Trim() != "") ? new SqlParameter("Address", address.Trim()) : new SqlParameter("Address", DBNull.Value);
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);

            SqlParameter manholeShapeParameter = (manholeShape.Trim() != "") ? new SqlParameter("ManholeShape", manholeShape.Trim()) : new SqlParameter("ManholeShape", DBNull.Value);
            SqlParameter locationParameter = (location.Trim() != "") ? new SqlParameter("Location", location.Trim()) : new SqlParameter("Location", DBNull.Value);
            SqlParameter materialIDParameter = (materialID.HasValue) ? new SqlParameter("MaterialID", materialID) : new SqlParameter("MaterialID", DBNull.Value);
            SqlParameter topDiameterParameter = (topDiameter.Trim() != "") ? new SqlParameter("TopDiameter", topDiameter.Trim()) : new SqlParameter("TopDiameter", DBNull.Value);
            SqlParameter topDepthParameter = (topDepth.Trim() != "") ? new SqlParameter("TopDepth", topDepth.Trim()) : new SqlParameter("TopDepth", DBNull.Value);
            SqlParameter topFloorParameter = (topFloor.Trim() != "") ? new SqlParameter("TopFloor", topFloor.Trim()) : new SqlParameter("TopFloor", DBNull.Value);
            SqlParameter topCeilingParameter = (topCeiling.Trim() != "") ? new SqlParameter("TopCeiling", topCeiling.Trim()) : new SqlParameter("TopCeiling", DBNull.Value);
            SqlParameter topBenchingParameter = (topBenching.Trim() != "") ? new SqlParameter("TopBenching", topBenching.Trim()) : new SqlParameter("TopBenching", DBNull.Value);
            SqlParameter downDiameterParameter = (downDiameter.Trim() != "") ? new SqlParameter("DownDiameter", downDiameter.Trim()) : new SqlParameter("DownDiameter", DBNull.Value);
            SqlParameter downDepthParameter = (downDepth.Trim() != "") ? new SqlParameter("DownDepth", downDepth.Trim()) : new SqlParameter("DownDepth", DBNull.Value);
            SqlParameter downFloorParameter = (downFloor.Trim() != "") ? new SqlParameter("DownFloor", downFloor.Trim()) : new SqlParameter("DownFloor", DBNull.Value);
            SqlParameter downCeilingParameter = (downCeiling.Trim() != "") ? new SqlParameter("DownCeiling", downCeiling.Trim()) : new SqlParameter("DownCeiling", DBNull.Value);
            SqlParameter downBenchingParameter = (downBenching.Trim() != "") ? new SqlParameter("DownBenching", downBenching.Trim()) : new SqlParameter("DownBenching", DBNull.Value);
            SqlParameter rectangle1LongSideParameter = (rectangle1LongSide.Trim() != "") ? new SqlParameter("Rectangle1LongSide", rectangle1LongSide.Trim()) : new SqlParameter("Rectangle1LongSide", DBNull.Value);
            SqlParameter rectangle1ShortSideParameter = (rectangle1ShortSide.Trim() != "") ? new SqlParameter("Rectangle1ShortSide", rectangle1ShortSide.Trim()) : new SqlParameter("Rectangle1ShortSide", DBNull.Value);
            SqlParameter rRectangle2LongSideParameter = (rectangle2LongSide.Trim() != "") ? new SqlParameter("Rectangle2LongSide", rectangle2LongSide.Trim()) : new SqlParameter("Rectangle2LongSide", DBNull.Value);
            SqlParameter rectangle2ShortSideParameter = (rectangle2ShortSide.Trim() != "") ? new SqlParameter("Rectangle2ShortSide", rectangle2ShortSide.Trim()) : new SqlParameter("Rectangle2ShortSide", DBNull.Value);
            SqlParameter topSurfaceAreaParameter = (topSurfaceArea.Trim() != "") ? new SqlParameter("TopSurfaceArea", topSurfaceArea.Trim()) : new SqlParameter("TopSurfaceArea", DBNull.Value);
            SqlParameter downSurfaceAreaParameter = (downSurfaceArea.Trim() != "") ? new SqlParameter("DownSurfaceArea", downSurfaceArea.Trim()) : new SqlParameter("DownSurfaceArea", DBNull.Value);
            SqlParameter manholeRugsParameter = (manholeRugs.HasValue) ? new SqlParameter("ManholeRugs", manholeRugs) : new SqlParameter("ManholeRugs", DBNull.Value);
            SqlParameter totalDepthParameter = (totalDepth.Trim() != "") ? new SqlParameter("TotalDepth", totalDepth.Trim()) : new SqlParameter("TotalDepth", DBNull.Value);
            SqlParameter totalSurfaceAreaParameter = (totalSurfaceArea.Trim() != "") ? new SqlParameter("TotalSurfaceArea", totalSurfaceArea.Trim()) : new SqlParameter("TotalSurfaceArea", DBNull.Value);
                        
            string command = "INSERT INTO [dbo].[AM_ASSET_SEWER_MH] ([AssetID], [MHID], [Latitud], [Longitude], [Address], [Deleted], [COMPANY_ID], [ManholeShape], [Location], [MaterialID], [TopDiameter], [TopDepth], [TopFloor], [TopCeiling], [TopBenching], [DownDiameter], [DownDepth], [DownFloor], [DownCeiling], [DownBenching], [Rectangle1LongSide], [Rectangle1ShortSide], [Rectangle2LongSide], [Rectangle2ShortSide], [TopSurfaceArea], [DownSurfaceArea], [ManholeRugs], [TotalDepth], [TotalSurfaceArea]) VALUES (@AssetID, @MHID, @Latitud, @Longitude, @Address, @Deleted, @COMPANY_ID, @ManholeShape, @Location, @MaterialID, @TopDiameter, @TopDepth, @TopFloor, @TopCeiling, @TopBenching, @DownDiameter, @DownDepth, @DownFloor, @DownCeiling, @DownBenching, @Rectangle1LongSide, @Rectangle1ShortSide, @Rectangle2LongSide, @Rectangle2ShortSide, @TopSurfaceArea, @DownSurfaceArea, @ManholeRugs, @TotalDepth, @TotalSurfaceArea)";

            ExecuteNonQuery(command, assetIdParameter, mhIdParameter, latitudeParameter, longitudeParameter, addressParameter, deletedParameter, companyIdParameter, manholeShapeParameter, locationParameter, materialIDParameter, topDiameterParameter, topDepthParameter, topFloorParameter, topCeilingParameter, topBenchingParameter, downDiameterParameter, downDepthParameter, downFloorParameter, downCeilingParameter, downBenchingParameter, rectangle1LongSideParameter, rectangle1ShortSideParameter, rRectangle2LongSideParameter, rectangle2ShortSideParameter, topSurfaceAreaParameter, downSurfaceAreaParameter, manholeRugsParameter, totalDepthParameter, totalSurfaceAreaParameter);
        }



        /// <summary>
        /// InsertMHProject
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="projectId">projectId</param>
        /// <param name="date_">date_</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void InsertMHProject(int assetId, int projectId, DateTime date_, bool deleted, int companyId)
        {
            SqlParameter assetIdParameter = new SqlParameter("AssetId", assetId);
            SqlParameter projectIdParameter = new SqlParameter("ProjectId", projectId);
            SqlParameter date_Parameter = new SqlParameter("Date_", date_);
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);

            string command = "INSERT INTO [dbo].[AM_ASSET_SEWER_MH_PROJECT] ([AssetID], [ProjectID], [Date_], [Deleted], [COMPANY_ID]) VALUES (@AssetID, @ProjectID, @Date_, @Deleted, @COMPANY_ID)";

            ExecuteNonQuery(command, assetIdParameter, projectIdParameter, date_Parameter, deletedParameter, companyIdParameter);
        }



        /// <summary>
        /// IsUsedInMHProject
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="assetId">assetId</param>
        /// <returns>TRUE if is used</returns>
        public bool IsUsedInMHProject(int projectId, int assetId)
        {
            string commandText = "SELECT COUNT(*) FROM AM_ASSET_SEWER_MH_PROJECT AS AASMHP WHERE (AASMHP.Deleted = 0) AND (AASMHP.ProjectID = @projectId) AND (AASMHP.AssetID = @assetId)";
            SqlCommand command = new SqlCommand(commandText, DB.Connection);
            command.Parameters.Add(new SqlParameter("@projectId", projectId));
            command.Parameters.Add(new SqlParameter("@assetId", assetId));

            return ((int)ExecuteScalar(command) > 0) ? true : false;
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="originalAssetId">originalAssetId</param>
        /// <param name="originalMhId">originalMhId</param>
        /// <param name="originalLatitud">originalLatitud</param>
        /// <param name="originalLongitude">originalLongitude</param>
        /// <param name="originalAddress">originalAddress</param>
        /// <param name="originalManholeShape">originalManholeShape</param>
        /// <param name="originalLocation">originalLocation</param>
        /// <param name="originalMaterialID">originalMaterialID</param>
        /// <param name="originalTopDiameter">originalTopDiameter</param>
        /// <param name="originalTopDepth">originalTopDepth</param>
        /// <param name="originalTopFloor">originalTopFloor</param>
        /// <param name="originalTopCeiling">originalTopCeiling</param>
        /// <param name="originalTopBenching">originalTopBenching</param>
        /// <param name="originalDownDiameter">originalDownDiameter</param>
        /// <param name="originalDownDepth">originalDownDepth</param>
        /// <param name="originalDownFloor">originalDownFloor</param>
        /// <param name="originalDownCeiling">originalDownCeiling</param>
        /// <param name="originalDownBenching">originalDownBenching</param>
        /// <param name="originalRectangle1LongSide">originalRectangle1LongSide</param>
        /// <param name="originalRectangle1ShortSide">originalRectangle1ShortSide</param>
        /// <param name="originalRectangle2LongSide">originalRectangle2LongSide</param>
        /// <param name="originalRectangle2ShortSide">originalRectangle2ShortSide</param>
        /// <param name="originalTopSurfaceArea">originalTopSurfaceArea</param>
        /// <param name="originalDownSurfaceArea">originalDownSurfaceArea</param>
        /// <param name="originalManholeRugs">originalManholeRugs</param>
        /// <param name="originalTotalDepth">originalTotalDepth</param>
        /// <param name="originalTotalSurfaceArea">originalTotalSurfaceArea</param>        
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// 
        /// <param name="newAssetId">newAssetId</param>
        /// <param name="newMhId">newMhId</param>
        /// <param name="newLatitude">newLatitude</param>
        /// <param name="newLongitude">newLongitude</param>
        /// <param name="newAddress">newAddress</param>
        /// <param name="newManholeShape">newManholeShape</param>
        /// <param name="newLocation">newLocation</param>
        /// <param name="newMaterialID">newMaterialID</param>
        /// <param name="newTopDiameter">newTopDiameter</param>
        /// <param name="newTopDepth">newTopDepth</param>
        /// <param name="newTopFloor">newTopFloor</param>
        /// <param name="newTopCeiling">newTopCeiling</param>
        /// <param name="newTopBenching">newTopBenching</param>
        /// <param name="newDownDiameter">newDownDiameter</param>
        /// <param name="newDownDepth">newDownDepth</param>
        /// <param name="newDownFloor">newDownFloor</param>
        /// <param name="newDownCeiling">newDownCeiling</param>
        /// <param name="newDownBenching">newDownBenching</param>
        /// <param name="newRectangle1LongSide">newRectangle1LongSide</param>
        /// <param name="newRectangle1ShortSide">newRectangle1ShortSide</param>
        /// <param name="newRectangle2LongSide">newRectangle2LongSide</param>
        /// <param name="newRectangle2ShortSide">newRectangle2ShortSide</param>
        /// <param name="newTopSurfaceArea">newTopSurfaceArea</param>
        /// <param name="newDownSurfaceArea">newDownSurfaceArea</param>
        /// <param name="newManholeRugs">newManholeRugs</param>
        /// <param name="newTotalDepth">newTotalDepth</param>
        /// <param name="newTotalSurfaceArea">newTotalSurfaceArea</param>             
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        public void Update(int originalAssetId, string originalMhId, string originalLatitud, string originalLongitude, string originalAddress, string originalManholeShape, string originalLocation, int? originalMaterialID, string originalTopDiameter, string originalTopDepth, string originalTopFloor, string originalTopCeiling, string originalTopBenching, string originalDownDiameter, string originalDownDepth, string originalDownFloor, string originalDownCeiling, string originalDownBenching, string originalRectangle1LongSide, string originalRectangle1ShortSide, string originalRectangle2LongSide, string originalRectangle2ShortSide, string originalTopSurfaceArea, string originalDownSurfaceArea, int? originalManholeRugs, string originalTotalDepth, string originalTotalSurfaceArea, bool originalDeleted, int originalCompanyId, int newAssetId, string newMhId, string newLatitud, string newLongitude, string newAddress, string newManholeShape, string newLocation, int? newMaterialID, string newTopDiameter, string newTopDepth, string newTopFloor, string newTopCeiling, string newTopBenching, string newDownDiameter, string newDownDepth, string newDownFloor, string newDownCeiling, string newDownBenching, string newRectangle1LongSide, string newRectangle1ShortSide, string newRectangle2LongSide, string newRectangle2ShortSide, string newTopSurfaceArea, string newDownSurfaceArea, int? newManholeRugs, string newTotalDepth, string newTotalSurfaceArea, bool newDeleted, int newCompanyId)
        {
            SqlParameter originalAssetIdParameter = new SqlParameter("Original_AssetID", originalAssetId);
            SqlParameter originalMhIdParameter = new SqlParameter("Original_MHID", originalMhId.Trim());
            SqlParameter originalLatitudeParameter = (originalLatitud.Trim() != "") ? new SqlParameter("Original_Latitud", originalLatitud.Trim()) : new SqlParameter("Original_Latitud", DBNull.Value);
            SqlParameter originalLongitudeParameter = (originalLongitude.Trim() != "") ? new SqlParameter("Original_Longitude", originalLongitude.Trim()) : new SqlParameter("Original_Longitude", DBNull.Value);
            SqlParameter originalAddressParameter = (originalAddress.Trim() != "") ? new SqlParameter("Original_Address", originalAddress.Trim()) : new SqlParameter("Original_Address", DBNull.Value);
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter originalManholeShapeParameter = (originalManholeShape.Trim() != "") ? new SqlParameter("Original_ManholeShape", originalManholeShape.Trim()) : new SqlParameter("Original_ManholeShape", DBNull.Value);
            SqlParameter originalLocationParameter = (originalLocation.Trim() != "") ? new SqlParameter("Original_Location", originalLocation.Trim()) : new SqlParameter("Original_Location", DBNull.Value);
            SqlParameter originalMaterialIDParameter = (originalMaterialID.HasValue) ? new SqlParameter("Original_MaterialID", originalMaterialID) : new SqlParameter("Original_MaterialID", DBNull.Value);
            SqlParameter originalTopDiameterParameter = (originalTopDiameter.Trim() != "") ? new SqlParameter("Original_TopDiameter", originalTopDiameter.Trim()) : new SqlParameter("Original_TopDiameter", DBNull.Value);
            SqlParameter originalTopDepthParameter = (originalTopDepth.Trim() != "") ? new SqlParameter("Original_TopDepth", originalTopDepth.Trim()) : new SqlParameter("Original_TopDepth", DBNull.Value);
            SqlParameter originalTopFloorParameter = (originalTopFloor.Trim() != "") ? new SqlParameter("Original_TopFloor", originalTopFloor.Trim()) : new SqlParameter("Original_TopFloor", DBNull.Value);
            SqlParameter originalTopCeilingParameter = (originalTopCeiling.Trim() != "") ? new SqlParameter("Original_TopCeiling", originalTopCeiling.Trim()) : new SqlParameter("Original_TopCeiling", DBNull.Value);
            SqlParameter originalTopBenchingParameter = (originalTopBenching.Trim() != "") ? new SqlParameter("Original_TopBenching", originalTopBenching.Trim()) : new SqlParameter("Original_TopBenching", DBNull.Value);
            SqlParameter originalDownDiameterParameter = (originalDownDiameter.Trim() != "") ? new SqlParameter("Original_DownDiameter", originalDownDiameter.Trim()) : new SqlParameter("Original_DownDiameter", DBNull.Value);
            SqlParameter originalDownDepthParameter = (originalDownDepth.Trim() != "") ? new SqlParameter("Original_DownDepth", originalDownDepth.Trim()) : new SqlParameter("Original_DownDepth", DBNull.Value);
            SqlParameter originalDownFloorParameter = (originalDownFloor.Trim() != "") ? new SqlParameter("Original_DownFloor", originalDownFloor.Trim()) : new SqlParameter("Original_DownFloor", DBNull.Value);
            SqlParameter originalDownCeilingParameter = (originalDownCeiling.Trim() != "") ? new SqlParameter("Original_DownCeiling", originalDownCeiling.Trim()) : new SqlParameter("Original_DownCeiling", DBNull.Value);
            SqlParameter originalDownBenchingParameter = (originalDownBenching.Trim() != "") ? new SqlParameter("Original_DownBenching", originalDownBenching.Trim()) : new SqlParameter("Original_DownBenching", DBNull.Value);
            SqlParameter originalRectangle1LongSideParameter = (originalRectangle1LongSide.Trim() != "") ? new SqlParameter("Original_Rectangle1LongSide", originalRectangle1LongSide.Trim()) : new SqlParameter("Original_Rectangle1LongSide", DBNull.Value);
            SqlParameter originalRectangle1ShortSideParameter = (originalRectangle1ShortSide.Trim() != "") ? new SqlParameter("Original_Rectangle1ShortSide", originalRectangle1ShortSide.Trim()) : new SqlParameter("Original_Rectangle1ShortSide", DBNull.Value);
            SqlParameter originalRectangle2LongSideParameter = (originalRectangle2LongSide.Trim() != "") ? new SqlParameter("Original_Rectangle2LongSide", originalRectangle2LongSide.Trim()) : new SqlParameter("Original_Rectangle2LongSide", DBNull.Value);
            SqlParameter originalRectangle2ShortSideParameter = (originalRectangle2ShortSide.Trim() != "") ? new SqlParameter("Original_Rectangle2ShortSide", originalRectangle2ShortSide.Trim()) : new SqlParameter("Original_Rectangle2ShortSide", DBNull.Value);
            SqlParameter originalTopSurfaceAreaParameter = (originalTopSurfaceArea.Trim() != "") ? new SqlParameter("Original_TopSurfaceArea", originalTopSurfaceArea.Trim()) : new SqlParameter("Original_TopSurfaceArea", DBNull.Value);
            SqlParameter originalDownSurfaceAreaParameter = (originalDownSurfaceArea.Trim() != "") ? new SqlParameter("Original_DownSurfaceArea", originalDownSurfaceArea.Trim()) : new SqlParameter("Original_DownSurfaceArea", DBNull.Value);
            SqlParameter originalManholeRugsParameter = (originalManholeRugs.HasValue) ? new SqlParameter("Original_ManholeRugs", originalManholeRugs) : new SqlParameter("Original_ManholeRugs", DBNull.Value);
            SqlParameter originalTotalDepthParameter = (originalTotalDepth.Trim() != "") ? new SqlParameter("Original_TotalDepth", originalTotalDepth.Trim()) : new SqlParameter("Original_TotalDepth", DBNull.Value);
            SqlParameter originalTotalSurfaceAreaParameter = (originalTotalSurfaceArea.Trim() != "") ? new SqlParameter("Original_TotalSurfaceArea", originalTotalSurfaceArea.Trim()) : new SqlParameter("Original_TotalSurfaceArea", DBNull.Value);                     

            SqlParameter newAssetIdParameter = new SqlParameter("AssetID", newAssetId);
            SqlParameter newMhIdParameter = new SqlParameter("MHID", newMhId.Trim());
            SqlParameter newLatitudeParameter = (newLatitud.Trim() != "") ? new SqlParameter("Latitud", newLatitud.Trim()) : new SqlParameter("Latitud", DBNull.Value);
            SqlParameter newLongitudeParameter = (newLongitude.Trim() != "") ? new SqlParameter("Longitude", newLongitude.Trim()) : new SqlParameter("Longitude", DBNull.Value);
            SqlParameter newAddressParameter = (newAddress.Trim() != "") ? new SqlParameter("Address", newAddress.Trim()) : new SqlParameter("Address", DBNull.Value);
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);
            SqlParameter newManholeShapeParameter = (newManholeShape.Trim() != "") ? new SqlParameter("ManholeShape", newManholeShape.Trim()) : new SqlParameter("ManholeShape", DBNull.Value);
            SqlParameter newLocationParameter = (newLocation.Trim() != "") ? new SqlParameter("Location", newLocation.Trim()) : new SqlParameter("Location", DBNull.Value);
            SqlParameter newMaterialIDParameter = (newMaterialID.HasValue) ? new SqlParameter("MaterialID", newMaterialID) : new SqlParameter("MaterialID", DBNull.Value);
            SqlParameter newTopDiameterParameter = (newTopDiameter.Trim() != "") ? new SqlParameter("TopDiameter", newTopDiameter.Trim()) : new SqlParameter("TopDiameter", DBNull.Value);
            SqlParameter newTopDepthParameter = (newTopDepth.Trim() != "") ? new SqlParameter("TopDepth", newTopDepth.Trim()) : new SqlParameter("TopDepth", DBNull.Value);
            SqlParameter newTopFloorParameter = (newTopFloor.Trim() != "") ? new SqlParameter("TopFloor", newTopFloor.Trim()) : new SqlParameter("TopFloor", DBNull.Value);
            SqlParameter newTopCeilingParameter = (newTopCeiling.Trim() != "") ? new SqlParameter("TopCeiling", newTopCeiling.Trim()) : new SqlParameter("TopCeiling", DBNull.Value);
            SqlParameter newTopBenchingParameter = (newTopBenching.Trim() != "") ? new SqlParameter("TopBenching", newTopBenching.Trim()) : new SqlParameter("TopBenching", DBNull.Value);
            SqlParameter newDownDiameterParameter = (newDownDiameter.Trim() != "") ? new SqlParameter("DownDiameter", newDownDiameter.Trim()) : new SqlParameter("DownDiameter", DBNull.Value);
            SqlParameter newDownDepthParameter = (newDownDepth.Trim() != "") ? new SqlParameter("DownDepth", newDownDepth.Trim()) : new SqlParameter("DownDepth", DBNull.Value);
            SqlParameter newDownFloorParameter = (newDownFloor.Trim() != "") ? new SqlParameter("DownFloor", newDownFloor.Trim()) : new SqlParameter("DownFloor", DBNull.Value);
            SqlParameter newDownCeilingParameter = (newDownCeiling.Trim() != "") ? new SqlParameter("DownCeiling", newDownCeiling.Trim()) : new SqlParameter("DownCeiling", DBNull.Value);
            SqlParameter newDownBenchingParameter = (newDownBenching.Trim() != "") ? new SqlParameter("DownBenching", newDownBenching.Trim()) : new SqlParameter("DownBenching", DBNull.Value);
            SqlParameter newRectangle1LongSideParameter = (newRectangle1LongSide.Trim() != "") ? new SqlParameter("Rectangle1LongSide", newRectangle1LongSide.Trim()) : new SqlParameter("Rectangle1LongSide", DBNull.Value);
            SqlParameter newRectangle1ShortSideParameter = (newRectangle1ShortSide.Trim() != "") ? new SqlParameter("Rectangle1ShortSide", newRectangle1ShortSide.Trim()) : new SqlParameter("Rectangle1ShortSide", DBNull.Value);
            SqlParameter newRectangle2LongSideParameter = (newRectangle2LongSide.Trim() != "") ? new SqlParameter("Rectangle2LongSide", newRectangle2LongSide.Trim()) : new SqlParameter("Rectangle2LongSide", DBNull.Value);
            SqlParameter newRectangle2ShortSideParameter = (newRectangle2ShortSide.Trim() != "") ? new SqlParameter("Rectangle2ShortSide", newRectangle2ShortSide.Trim()) : new SqlParameter("Rectangle2ShortSide", DBNull.Value);
            SqlParameter newTopSurfaceAreaParameter = (newTopSurfaceArea.Trim() != "") ? new SqlParameter("TopSurfaceArea", newTopSurfaceArea.Trim()) : new SqlParameter("TopSurfaceArea", DBNull.Value);
            SqlParameter newDownSurfaceAreaParameter = (newDownSurfaceArea.Trim() != "") ? new SqlParameter("DownSurfaceArea", newDownSurfaceArea.Trim()) : new SqlParameter("DownSurfaceArea", DBNull.Value);
            SqlParameter newManholeRugsParameter = (newManholeRugs.HasValue) ? new SqlParameter("ManholeRugs", newManholeRugs) : new SqlParameter("ManholeRugs", DBNull.Value);
            SqlParameter newTotalDepthParameter = (newTotalDepth.Trim() != "") ? new SqlParameter("TotalDepth", newTotalDepth.Trim()) : new SqlParameter("TotalDepth", DBNull.Value);
            SqlParameter newTotalSurfaceAreaParameter = (newTotalSurfaceArea.Trim() != "") ? new SqlParameter("TotalSurfaceArea", newTotalSurfaceArea.Trim()) : new SqlParameter("TotalSurfaceArea", DBNull.Value);
            
            string command = "UPDATE [dbo].[AM_ASSET_SEWER_MH]" +
                             "SET [AssetID] = @AssetID, [MHID] = @MHID, [Latitud] = @Latitud, [Longitude] = @Longitude, [Address] = @Address, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID, [ManholeShape] = @ManholeShape, [Location] = @" +
                "Location, [MaterialID] = @MaterialID, [TopDiameter] = @TopDiameter, [TopDepth] =" +
                " @TopDepth, [TopFloor] = @TopFloor, [TopCeiling] = @TopCeiling, [TopBenching] = " +
                "@TopBenching, [DownDiameter] = @DownDiameter, [DownDepth] = @DownDepth, [DownFlo" +
                "or] = @DownFloor, [DownCeiling] = @DownCeiling, [DownBenching] = @DownBenching, " +
                "[Rectangle1LongSide] = @Rectangle1LongSide, [Rectangle1ShortSide] = @Rectangle1S" +
                "hortSide, [Rectangle2LongSide] = @Rectangle2LongSide, [Rectangle2ShortSide] = @R" +
                "ectangle2ShortSide, [TopSurfaceArea] = @TopSurfaceArea, [DownSurfaceArea] = @Dow" +
                "nSurfaceArea, [ManholeRugs] = @ManholeRugs, [TotalDepth] = @TotalDepth, [TotalSu" +
                "rfaceArea] = @TotalSurfaceArea "+ 
                "WHERE ([AssetID] = @Original_AssetID)";

            int rowsAffected = (int)ExecuteNonQuery(command, originalAssetIdParameter, originalMhIdParameter, originalLatitudeParameter, originalLongitudeParameter, originalAddressParameter, originalDeletedParameter, originalCompanyIdParameter, originalManholeShapeParameter, originalLocationParameter, originalMaterialIDParameter, originalTopDiameterParameter, originalTopDepthParameter, originalTopFloorParameter, originalTopCeilingParameter, originalTopBenchingParameter, originalDownDiameterParameter, originalDownDepthParameter, originalDownFloorParameter, originalDownCeilingParameter, originalDownBenchingParameter, originalRectangle1LongSideParameter, originalRectangle1ShortSideParameter, originalRectangle2LongSideParameter, originalRectangle2ShortSideParameter, originalTopSurfaceAreaParameter, originalDownSurfaceAreaParameter, originalManholeRugsParameter, originalTotalDepthParameter, originalTotalSurfaceAreaParameter, newAssetIdParameter, newMhIdParameter, newLatitudeParameter, newLongitudeParameter, newAddressParameter, newDeletedParameter, newCompanyIdParameter, newManholeShapeParameter, newLocationParameter, newMaterialIDParameter, newTopDiameterParameter, newTopDepthParameter, newTopFloorParameter, newTopCeilingParameter, newTopBenchingParameter, newDownDiameterParameter, newDownDepthParameter, newDownFloorParameter, newDownCeilingParameter, newDownBenchingParameter, newRectangle1LongSideParameter, newRectangle1ShortSideParameter, newRectangle2LongSideParameter, newRectangle2ShortSideParameter, newTopSurfaceAreaParameter, newDownSurfaceAreaParameter, newManholeRugsParameter, newTotalDepthParameter, newTotalSurfaceAreaParameter);
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

            string command = "UPDATE [dbo].[AM_ASSET_SEWER_MH] SET  [Deleted] = @Deleted WHERE " +
                "(([AssetID] = @AssetID) AND ([COMPANY_ID] = @COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery( command, assetIdParameter, companyIdParameter, deletedParameter);
            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }
        }
    }
}
