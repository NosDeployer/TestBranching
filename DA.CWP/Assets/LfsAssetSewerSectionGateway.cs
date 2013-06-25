using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.DA.CWP.Assets;

namespace LiquiForce.LFSLive.DA.CWP.Assets
{
    /// <summary>
    /// LfsAssetSewerSectionGateway
    /// </summary>
    public class LfsAssetSewerSectionGateway : DataTableGateway
    {

        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public LfsAssetSewerSectionGateway() : base("LFS_ASSET_SEWER_SECTION")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public LfsAssetSewerSectionGateway(DataSet data) : base(data, "LFS_ASSET_SEWER_SECTION")
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
            tableMapping.DataSetTable = "LFS_ASSET_SEWER_SECTION";
            tableMapping.ColumnMappings.Add("AssetID", "AssetID");
            tableMapping.ColumnMappings.Add("SteelTapeThroughSewer", "SteelTapeThroughSewer");
            tableMapping.ColumnMappings.Add("USMHMouth12", "USMHMouth12");
            tableMapping.ColumnMappings.Add("USMHMouth1", "USMHMouth1");
            tableMapping.ColumnMappings.Add("USMHMouth2", "USMHMouth2");
            tableMapping.ColumnMappings.Add("USMHMouth3", "USMHMouth3");
            tableMapping.ColumnMappings.Add("USMHMouth4", "USMHMouth4");
            tableMapping.ColumnMappings.Add("USMHMouth5", "USMHMouth5");
            tableMapping.ColumnMappings.Add("DSMHMouth12", "DSMHMouth12");
            tableMapping.ColumnMappings.Add("DSMHMouth1", "DSMHMouth1");
            tableMapping.ColumnMappings.Add("DSMHMouth2", "DSMHMouth2");
            tableMapping.ColumnMappings.Add("DSMHMouth3", "DSMHMouth3");
            tableMapping.ColumnMappings.Add("DSMHMouth4", "DSMHMouth4");
            tableMapping.ColumnMappings.Add("DSMHMouth5", "DSMHMouth5");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("SubArea", "SubArea");
            tableMapping.ColumnMappings.Add("Thickness", "Thickness");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[LFS_ASSET_SEWER_SECTION] WHERE (([AssetID] = @Original_AssetID" +
                ") AND ((@IsNull_SteelTapeThroughSewer = 1 AND [SteelTapeThroughSewer] IS NULL) O" +
                "R ([SteelTapeThroughSewer] = @Original_SteelTapeThroughSewer)) AND ((@IsNull_USM" +
                "HMouth12 = 1 AND [USMHMouth12] IS NULL) OR ([USMHMouth12] = @Original_USMHMouth1" +
                "2)) AND ((@IsNull_USMHMouth1 = 1 AND [USMHMouth1] IS NULL) OR ([USMHMouth1] = @O" +
                "riginal_USMHMouth1)) AND ((@IsNull_USMHMouth2 = 1 AND [USMHMouth2] IS NULL) OR (" +
                "[USMHMouth2] = @Original_USMHMouth2)) AND ((@IsNull_USMHMouth3 = 1 AND [USMHMout" +
                "h3] IS NULL) OR ([USMHMouth3] = @Original_USMHMouth3)) AND ((@IsNull_USMHMouth4 " +
                "= 1 AND [USMHMouth4] IS NULL) OR ([USMHMouth4] = @Original_USMHMouth4)) AND ((@I" +
                "sNull_USMHMouth5 = 1 AND [USMHMouth5] IS NULL) OR ([USMHMouth5] = @Original_USMH" +
                "Mouth5)) AND ((@IsNull_DSMHMouth12 = 1 AND [DSMHMouth12] IS NULL) OR ([DSMHMouth" +
                "12] = @Original_DSMHMouth12)) AND ((@IsNull_DSMHMouth1 = 1 AND [DSMHMouth1] IS N" +
                "ULL) OR ([DSMHMouth1] = @Original_DSMHMouth1)) AND ((@IsNull_DSMHMouth2 = 1 AND " +
                "[DSMHMouth2] IS NULL) OR ([DSMHMouth2] = @Original_DSMHMouth2)) AND ((@IsNull_DS" +
                "MHMouth3 = 1 AND [DSMHMouth3] IS NULL) OR ([DSMHMouth3] = @Original_DSMHMouth3))" +
                " AND ((@IsNull_DSMHMouth4 = 1 AND [DSMHMouth4] IS NULL) OR ([DSMHMouth4] = @Orig" +
                "inal_DSMHMouth4)) AND ((@IsNull_DSMHMouth5 = 1 AND [DSMHMouth5] IS NULL) OR ([DS" +
                "MHMouth5] = @Original_DSMHMouth5)) AND ([Deleted] = @Original_Deleted) AND ([COM" +
                "PANY_ID] = @Original_COMPANY_ID) AND ((@IsNull_SubArea = 1 AND [SubArea] IS NULL" +
                ") OR ([SubArea] = @Original_SubArea)) AND ((@IsNull_Thickness = 1 AND [Thickness" +
                "] IS NULL) OR ([Thickness] = @Original_Thickness)))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_AssetID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AssetID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_SteelTapeThroughSewer", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SteelTapeThroughSewer", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_SteelTapeThroughSewer", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SteelTapeThroughSewer", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_USMHMouth12", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "USMHMouth12", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_USMHMouth12", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "USMHMouth12", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_USMHMouth1", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "USMHMouth1", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_USMHMouth1", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "USMHMouth1", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_USMHMouth2", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "USMHMouth2", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_USMHMouth2", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "USMHMouth2", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_USMHMouth3", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "USMHMouth3", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_USMHMouth3", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "USMHMouth3", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_USMHMouth4", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "USMHMouth4", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_USMHMouth4", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "USMHMouth4", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_USMHMouth5", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "USMHMouth5", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_USMHMouth5", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "USMHMouth5", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DSMHMouth12", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DSMHMouth12", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DSMHMouth12", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DSMHMouth12", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DSMHMouth1", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DSMHMouth1", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DSMHMouth1", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DSMHMouth1", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DSMHMouth2", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DSMHMouth2", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DSMHMouth2", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DSMHMouth2", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DSMHMouth3", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DSMHMouth3", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DSMHMouth3", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DSMHMouth3", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DSMHMouth4", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DSMHMouth4", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DSMHMouth4", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DSMHMouth4", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DSMHMouth5", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DSMHMouth5", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DSMHMouth5", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DSMHMouth5", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_SubArea", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SubArea", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_SubArea", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SubArea", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Thickness", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Thickness", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Thickness", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Thickness", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_ASSET_SEWER_SECTION] ([AssetID], [SteelTapeThroughSewer], [USMHMouth12], [USMHMouth1], [USMHMouth2], [USMHMouth3], [USMHMouth4], [USMHMouth5], [DSMHMouth12], [DSMHMouth1], [DSMHMouth2], [DSMHMouth3], [DSMHMouth4], [DSMHMouth5], [Deleted], [COMPANY_ID], [SubArea], [Thickness]) VALUES (@AssetID, @SteelTapeThroughSewer, @USMHMouth12, @USMHMouth1, @USMHMouth2, @USMHMouth3, @USMHMouth4, @USMHMouth5, @DSMHMouth12, @DSMHMouth1, @DSMHMouth2, @DSMHMouth3, @DSMHMouth4, @DSMHMouth5, @Deleted, @COMPANY_ID, @SubArea, @Thickness);
SELECT AssetID, SteelTapeThroughSewer, USMHMouth12, USMHMouth1, USMHMouth2, USMHMouth3, USMHMouth4, USMHMouth5, DSMHMouth12, DSMHMouth1, DSMHMouth2, DSMHMouth3, DSMHMouth4, DSMHMouth5, Deleted, COMPANY_ID, SubArea, Thickness FROM LFS_ASSET_SEWER_SECTION WHERE (AssetID = @AssetID)";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@AssetID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AssetID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@SteelTapeThroughSewer", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SteelTapeThroughSewer", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@USMHMouth12", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "USMHMouth12", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@USMHMouth1", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "USMHMouth1", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@USMHMouth2", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "USMHMouth2", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@USMHMouth3", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "USMHMouth3", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@USMHMouth4", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "USMHMouth4", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@USMHMouth5", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "USMHMouth5", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DSMHMouth12", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DSMHMouth12", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DSMHMouth1", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DSMHMouth1", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DSMHMouth2", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DSMHMouth2", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DSMHMouth3", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DSMHMouth3", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DSMHMouth4", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DSMHMouth4", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DSMHMouth5", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DSMHMouth5", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@SubArea", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SubArea", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Thickness", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Thickness", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));

            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[LFS_ASSET_SEWER_SECTION] SET [AssetID] = @AssetID, [SteelTapeThroug" +
                "hSewer] = @SteelTapeThroughSewer, [USMHMouth12] = @USMHMouth12, [USMHMouth1] = @" +
                "USMHMouth1, [USMHMouth2] = @USMHMouth2, [USMHMouth3] = @USMHMouth3, [USMHMouth4]" +
                " = @USMHMouth4, [USMHMouth5] = @USMHMouth5, [DSMHMouth12] = @DSMHMouth12, [DSMHM" +
                "outh1] = @DSMHMouth1, [DSMHMouth2] = @DSMHMouth2, [DSMHMouth3] = @DSMHMouth3, [D" +
                "SMHMouth4] = @DSMHMouth4, [DSMHMouth5] = @DSMHMouth5, [Deleted] = @Deleted, [COM" +
                "PANY_ID] = @COMPANY_ID, [SubArea] = @SubArea, [Thickness] = @Thickness WHERE (([" +
                "AssetID] = @Original_AssetID) AND ((@IsNull_SteelTapeThroughSewer = 1 AND [Steel" +
                "TapeThroughSewer] IS NULL) OR ([SteelTapeThroughSewer] = @Original_SteelTapeThro" +
                "ughSewer)) AND ((@IsNull_USMHMouth12 = 1 AND [USMHMouth12] IS NULL) OR ([USMHMou" +
                "th12] = @Original_USMHMouth12)) AND ((@IsNull_USMHMouth1 = 1 AND [USMHMouth1] IS" +
                " NULL) OR ([USMHMouth1] = @Original_USMHMouth1)) AND ((@IsNull_USMHMouth2 = 1 AN" +
                "D [USMHMouth2] IS NULL) OR ([USMHMouth2] = @Original_USMHMouth2)) AND ((@IsNull_" +
                "USMHMouth3 = 1 AND [USMHMouth3] IS NULL) OR ([USMHMouth3] = @Original_USMHMouth3" +
                ")) AND ((@IsNull_USMHMouth4 = 1 AND [USMHMouth4] IS NULL) OR ([USMHMouth4] = @Or" +
                "iginal_USMHMouth4)) AND ((@IsNull_USMHMouth5 = 1 AND [USMHMouth5] IS NULL) OR ([" +
                "USMHMouth5] = @Original_USMHMouth5)) AND ((@IsNull_DSMHMouth12 = 1 AND [DSMHMout" +
                "h12] IS NULL) OR ([DSMHMouth12] = @Original_DSMHMouth12)) AND ((@IsNull_DSMHMout" +
                "h1 = 1 AND [DSMHMouth1] IS NULL) OR ([DSMHMouth1] = @Original_DSMHMouth1)) AND (" +
                "(@IsNull_DSMHMouth2 = 1 AND [DSMHMouth2] IS NULL) OR ([DSMHMouth2] = @Original_D" +
                "SMHMouth2)) AND ((@IsNull_DSMHMouth3 = 1 AND [DSMHMouth3] IS NULL) OR ([DSMHMout" +
                "h3] = @Original_DSMHMouth3)) AND ((@IsNull_DSMHMouth4 = 1 AND [DSMHMouth4] IS NU" +
                "LL) OR ([DSMHMouth4] = @Original_DSMHMouth4)) AND ((@IsNull_DSMHMouth5 = 1 AND [" +
                "DSMHMouth5] IS NULL) OR ([DSMHMouth5] = @Original_DSMHMouth5)) AND ([Deleted] = " +
                "@Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND ((@IsNull_SubAr" +
                "ea = 1 AND [SubArea] IS NULL) OR ([SubArea] = @Original_SubArea)) AND ((@IsNull_" +
                "Thickness = 1 AND [Thickness] IS NULL) OR ([Thickness] = @Original_Thickness)));" +
                "\r\nSELECT AssetID, SteelTapeThroughSewer, USMHMouth12, USMHMouth1, USMHMouth2, US" +
                "MHMouth3, USMHMouth4, USMHMouth5, DSMHMouth12, DSMHMouth1, DSMHMouth2, DSMHMouth" +
                "3, DSMHMouth4, DSMHMouth5, Deleted, COMPANY_ID, SubArea, Thickness FROM LFS_ASSE" +
                "T_SEWER_SECTION WHERE (AssetID = @AssetID)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@AssetID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AssetID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@SteelTapeThroughSewer", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SteelTapeThroughSewer", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@USMHMouth12", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "USMHMouth12", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@USMHMouth1", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "USMHMouth1", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@USMHMouth2", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "USMHMouth2", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@USMHMouth3", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "USMHMouth3", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@USMHMouth4", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "USMHMouth4", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@USMHMouth5", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "USMHMouth5", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DSMHMouth12", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DSMHMouth12", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DSMHMouth1", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DSMHMouth1", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DSMHMouth2", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DSMHMouth2", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DSMHMouth3", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DSMHMouth3", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DSMHMouth4", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DSMHMouth4", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DSMHMouth5", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DSMHMouth5", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@SubArea", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SubArea", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Thickness", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Thickness", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_AssetID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AssetID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_SteelTapeThroughSewer", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SteelTapeThroughSewer", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_SteelTapeThroughSewer", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SteelTapeThroughSewer", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_USMHMouth12", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "USMHMouth12", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_USMHMouth12", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "USMHMouth12", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_USMHMouth1", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "USMHMouth1", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_USMHMouth1", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "USMHMouth1", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_USMHMouth2", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "USMHMouth2", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_USMHMouth2", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "USMHMouth2", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_USMHMouth3", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "USMHMouth3", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_USMHMouth3", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "USMHMouth3", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_USMHMouth4", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "USMHMouth4", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_USMHMouth4", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "USMHMouth4", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_USMHMouth5", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "USMHMouth5", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_USMHMouth5", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "USMHMouth5", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DSMHMouth12", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DSMHMouth12", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DSMHMouth12", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DSMHMouth12", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DSMHMouth1", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DSMHMouth1", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DSMHMouth1", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DSMHMouth1", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DSMHMouth2", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DSMHMouth2", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DSMHMouth2", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DSMHMouth2", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DSMHMouth3", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DSMHMouth3", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DSMHMouth3", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DSMHMouth3", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DSMHMouth4", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DSMHMouth4", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DSMHMouth4", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DSMHMouth4", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DSMHMouth5", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DSMHMouth5", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DSMHMouth5", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DSMHMouth5", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_SubArea", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SubArea", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_SubArea", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SubArea", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Thickness", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Thickness", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Thickness", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Thickness", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

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
            FillDataWithStoredProcedure("LFS_CWP_LFSASSETSEWERSECTIONGATEWAY_LOADBYASSETID", new SqlParameter("@assetId", assetId), new SqlParameter("@companyId", companyId));
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
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.Assets.Assets.LfsAssetSewerSectionGateway.GetRow");
            }
        }



        /// <summary>
        /// GetSteelTapeThroughSewer
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>SteelTapeThroughSewer or EMPTY</returns>
        public string GetSteelTapeThroughSewer(int assetId)
        {
            if (GetRow(assetId).IsNull("SteelTapeThroughSewer"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["SteelTapeThroughSewer"];
            }
        }



        /// <summary>
        /// GetUSMHMouth12
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>GetUSMHMouth12 or EMPTY</returns>
        public string GetUSMHMouth12(int assetId)
        {
            if (GetRow(assetId).IsNull("USMHMouth12"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["USMHMouth12"];
            }
        }



        /// <summary>
        /// GetUSMHMouth1
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>USMHMouth1 or EMPTY</returns>
        public string GetUSMHMouth1(int assetId)
        {
            if (GetRow(assetId).IsNull("USMHMouth1"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["USMHMouth1"];
            }
        }



        /// <summary>
        /// GetUSMHMouth2
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>USMHMouth2 or EMPTY</returns>
        public string GetUSMHMouth2(int assetId)
        {
            if (GetRow(assetId).IsNull("USMHMouth2"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["USMHMouth2"];
            }
        }



        /// <summary>
        /// GetUSMHMouth3
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>USMHMouth3 or EMPTY</returns>
        public string GetUSMHMouth3(int assetId)
        {
            if (GetRow(assetId).IsNull("USMHMouth3"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["USMHMouth3"];
            }
        }



        /// <summary>
        /// GetUSMHMouth4
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>USMHMouth4 or EMPTY</returns>
        public string GetUSMHMouth4(int assetId)
        {
            if (GetRow(assetId).IsNull("USMHMouth4"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["USMHMouth4"];
            }
        }



        /// <summary>
        /// GetUSMHMouth5
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>USMHMouth5 or EMPTY</returns>
        public string GetUSMHMouth5(int assetId)
        {
            if (GetRow(assetId).IsNull("USMHMouth5"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["USMHMouth5"];
            }
        }



        /// <summary>
        /// GetDSMHMouth12
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>DSMHMouth12 or EMPTY</returns>
        public string GetDSMHMouth12(int assetId)
        {
            if (GetRow(assetId).IsNull("DSMHMouth12"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["DSMHMouth12"];
            }
        }



        /// <summary>
        /// GetDSMHMouth1
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>DSMHMouth1 or EMPTY</returns>
        public string GetDSMHMouth1(int assetId)
        {
            if (GetRow(assetId).IsNull("DSMHMouth1"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["DSMHMouth1"];
            }
        }



        /// <summary>
        /// GetDSMHMouth2
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>DSMHMouth2 or EMPTY</returns>
        public string GetDSMHMouth2(int assetId)
        {
            if (GetRow(assetId).IsNull("DSMHMouth2"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["DSMHMouth2"];
            }
        }



        /// <summary>
        /// GetDSMHMouth3
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>DSMHMouth3 or EMPTY</returns>
        public string GetDSMHMouth3(int assetId)
        {
            if (GetRow(assetId).IsNull("DSMHMouth3"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["DSMHMouth3"];
            }
        }



        /// <summary>
        /// GetDSMHMouth4
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>DSMHMouth4 or EMPTY</returns>
        public string GetDSMHMouth4(int assetId)
        {
            if (GetRow(assetId).IsNull("DSMHMouth4"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["DSMHMouth4"];
            }
        }



        /// <summary>
        /// GetDSMHMouth5
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>DSMHMouth5 or EMPTY</returns>
        public string GetDSMHMouth5(int assetId)
        {
            if (GetRow(assetId).IsNull("DSMHMouth5"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["DSMHMouth5"];
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
        /// GetSubArea
        /// </summary>
        /// <param name="assetId"></param>
        /// <returns>SubArea or empty</returns>
        public string GetSubArea(int assetId)
        {
            if (GetRow(assetId).IsNull("SubArea"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["SubArea"];
            }
        }



        /// <summary>
        /// GetThickness
        /// </summary>
        /// <param name="assetId"></param>
        /// <returns>Thickness or empty</returns>
        public string GetThickness(int assetId)
        {
            if (GetRow(assetId).IsNull("Thickness"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["Thickness"];
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROWS
        //

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="steelTapeThroughSewer">steelTapeThroughSewer</param>
        /// <param name="usmhMouth12">usmhMouth12</param>
        /// <param name="usmhMouth1">usmhMouth1</param>
        /// <param name="usmhMouth2">usmhMouth2</param>
        /// <param name="usmhMouth3">usmhMouth3</param>
        /// <param name="usmhMouth4">usmhMouth4</param>
        /// <param name="usmhMouth5">usmhMouth5</param>
        /// <param name="dsmhMouth12">dsmhMouth12</param>
        /// <param name="dsmhMouth1">dsmhMouth1</param>
        /// <param name="dsmhMouth2">dsmhMouth2</param>
        /// <param name="dsmhMouth3">dsmhMouth3</param>
        /// <param name="dsmhMouth4">dsmhMouth4</param>
        /// <param name="dsmhMouth5">dsmhMouth5</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="subArea">subArea</param>
        /// <param name="thickness">thickess</param>
        public void Insert(int assetId, string steelTapeThroughSewer, string usmhMouth12, string usmhMouth1, string usmhMouth2, string usmhMouth3, string usmhMouth4, string usmhMouth5, string dsmhMouth12, string dsmhMouth1, string dsmhMouth2, string dsmhMouth3, string dsmhMouth4, string dsmhMouth5, bool deleted, int companyId, string subArea, string thickness)
        {
            SqlParameter assetIdParameter = new SqlParameter("AssetId", assetId);
            SqlParameter steelTapeThroughSewerParameter = (steelTapeThroughSewer.Trim() != "") ? new SqlParameter("SteelTapeThroughSewer", steelTapeThroughSewer.Trim()) : new SqlParameter("SteelTapeThroughSewer", DBNull.Value);
            SqlParameter usmhMouth12Parameter = (usmhMouth12.Trim() != "") ? new SqlParameter("USMHMouth12", usmhMouth12.Trim()) : new SqlParameter("USMHMouth12", DBNull.Value);
            SqlParameter usmhMouth1Parameter = (usmhMouth1.Trim() != "") ? new SqlParameter("USMHMouth1", usmhMouth1.Trim()) : new SqlParameter("USMHMouth1", DBNull.Value);
            SqlParameter usmhMouth2Parameter = (usmhMouth2.Trim() != "") ? new SqlParameter("USMHMouth2", usmhMouth2.Trim()) : new SqlParameter("USMHMouth2", DBNull.Value);
            SqlParameter usmhMouth3Parameter = (usmhMouth3.Trim() != "") ? new SqlParameter("USMHMouth3", usmhMouth3.Trim()) : new SqlParameter("USMHMouth3", DBNull.Value);
            SqlParameter usmhMouth4Parameter = (usmhMouth4.Trim() != "") ? new SqlParameter("USMHMouth4", usmhMouth4.Trim()) : new SqlParameter("USMHMouth4", DBNull.Value);
            SqlParameter usmhMouth5Parameter = (usmhMouth5.Trim() != "") ? new SqlParameter("USMHMouth5", usmhMouth5.Trim()) : new SqlParameter("USMHMouth5", DBNull.Value);
            SqlParameter dsmhMouth12Parameter = (dsmhMouth12.Trim() != "") ? new SqlParameter("DSMHMouth12", dsmhMouth12.Trim()) : new SqlParameter("DSMHMouth12", DBNull.Value);
            SqlParameter dsmhMouth1Parameter = (dsmhMouth1.Trim() != "") ? new SqlParameter("DSMHMouth1", dsmhMouth1.Trim()) : new SqlParameter("DSMHMouth1", DBNull.Value);
            SqlParameter dsmhMouth2Parameter = (dsmhMouth2.Trim() != "") ? new SqlParameter("DSMHMouth2", dsmhMouth2.Trim()) : new SqlParameter("DSMHMouth2", DBNull.Value);
            SqlParameter dsmhMouth3Parameter = (dsmhMouth3.Trim() != "") ? new SqlParameter("DSMHMouth3", dsmhMouth3.Trim()) : new SqlParameter("DSMHMouth3", DBNull.Value);
            SqlParameter dsmhMouth4Parameter = (dsmhMouth4.Trim() != "") ? new SqlParameter("DSMHMouth4", dsmhMouth4.Trim()) : new SqlParameter("DSMHMouth4", DBNull.Value);
            SqlParameter dsmhMouth5Parameter = (dsmhMouth5.Trim() != "") ? new SqlParameter("DSMHMouth5", dsmhMouth5.Trim()) : new SqlParameter("DSMHMouth5", DBNull.Value);
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            SqlParameter subAreaParameter = (subArea.Trim() != "") ? new SqlParameter("SubArea", subArea.Trim()) : new SqlParameter("SubArea", DBNull.Value);
            SqlParameter thicknessParameter = (thickness.Trim() != "") ? new SqlParameter("Thickness", thickness.Trim()) : new SqlParameter("Thickness", DBNull.Value);

            string command = "INSERT INTO [dbo].[LFS_ASSET_SEWER_SECTION] ([AssetID], [SteelTapeThroughSewer], [USMHMouth12], [USMHMouth1], [USMHMouth2], [USMHMouth3], [USMHMouth4], [USMHMouth5], [DSMHMouth12], [DSMHMouth1], [DSMHMouth2], [DSMHMouth3], [DSMHMouth4], [DSMHMouth5], [Deleted], [COMPANY_ID], [SubArea], [Thickness]) VALUES (@AssetID, @SteelTapeThroughSewer, @USMHMouth12, @USMHMouth1, @USMHMouth2, @USMHMouth3, @USMHMouth4, @USMHMouth5, @DSMHMouth12, @DSMHMouth1, @DSMHMouth2, @DSMHMouth3, @DSMHMouth4, @DSMHMouth5, @Deleted, @COMPANY_ID, @SubArea, @Thickness)";

            ExecuteNonQuery(command, assetIdParameter, steelTapeThroughSewerParameter, usmhMouth12Parameter, usmhMouth1Parameter, usmhMouth2Parameter, usmhMouth3Parameter, usmhMouth4Parameter, usmhMouth5Parameter, dsmhMouth12Parameter, dsmhMouth1Parameter, dsmhMouth2Parameter, dsmhMouth3Parameter, dsmhMouth4Parameter, dsmhMouth5Parameter, deletedParameter, companyIdParameter, subAreaParameter, thicknessParameter);

        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="originalSteelTapeThroughSewer">originalSteelTapeThroughSewer</param>
        /// <param name="originalUsmhMouth12">originalUsmhMouth12</param>
        /// <param name="originalUsmhMouth1">originalUsmhMouth1</param>
        /// <param name="originalUsmhMouth2">originalUsmhMouth2</param>
        /// <param name="originalUsmhMouth3">originalUsmhMouth3</param>
        /// <param name="originalUsmhMouth4">originalUsmhMouth4</param>
        /// <param name="originalUsmhMouth5">originalUsmhMouth5</param>
        /// <param name="originalDsmhMouth12">originalDsmhMouth12</param>
        /// <param name="originalDsmhMouth1">originalDsmhMouth1</param>
        /// <param name="originalDsmhMouth2">originalDsmhMouth2</param>
        /// <param name="originalDsmhMouth3">originalDsmhMouth3</param>
        /// <param name="originalDsmhMouth4">originalDsmhMouth4</param>
        /// <param name="originalDsmhMouth5">originalDsmhMouth5</param>
        /// <param name="originalLfsDeleted">originalLfsDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalSubArea">originalSubArea</param>
        /// <param name="originalThickness">originalThickness</param>
        /// 
        /// <param name="newSteelTapeThroughSewer">newSteelTapeThroughSewer</param>
        /// <param name="newUsmhMouth12">newUsmhMouth12</param>
        /// <param name="newUsmhMouth1">newUsmhMouth1</param>
        /// <param name="newUsmhMouth2">newUsmhMouth2</param>
        /// <param name="newUsmhMouth3">newUsmhMouth3</param>
        /// <param name="newUsmhMouth4">newUsmhMouth4</param>
        /// <param name="newUsmhMouth5">newUsmhMouth5</param>
        /// <param name="newDsmhMouth12">newDsmhMouth12</param>
        /// <param name="newDsmhMouth1">newDsmhMouth1</param>
        /// <param name="newDsmhMouth2">newDsmhMouth2</param>
        /// <param name="newDsmhMouth3">newDsmhMouth3</param>
        /// <param name="newDsmhMouth4">newDsmhMouth4</param>
        /// <param name="newDsmhMouth5">newDsmhMouth5</param>
        /// <param name="newSubArea">newSubArea</param>
        /// <param name="newThickness">newThickness</param>
        public void Update(int originalAssetId, string originalSteelTapeThroughSewer, string originalUsmhMouth12, string originalUsmhMouth1, string originalUsmhMouth2, string originalUsmhMouth3, string originalUsmhMouth4, string originalUsmhMouth5, string originalDsmhMouth12, string originalDsmhMouth1, string originalDsmhMouth2, string originalDsmhMouth3, string originalDsmhMouth4, string originalDsmhMouth5, bool originalDeleted, int originalCompanyId, string originalSubArea, string originalThickness, int newAssetId, string newSteelTapeThroughSewer, string newUsmhMouth12, string newUsmhMouth1, string newUsmhMouth2, string newUsmhMouth3, string newUsmhMouth4, string newUsmhMouth5, string newDsmhMouth12, string newDsmhMouth1, string newDsmhMouth2, string newDsmhMouth3, string newDsmhMouth4, string newDsmhMouth5, bool newDeleted, int newCompanyId, string newSubArea, string newThickness)
        {
            //ojo: mario - faltan parametros

            SqlParameter newAssetIdParameter = new SqlParameter("AssetId", newAssetId);
            SqlParameter newSteelTapeThroughSewerParameter = (newSteelTapeThroughSewer.Trim() != "") ? new SqlParameter("SteelTapeThroughSewer", newSteelTapeThroughSewer.Trim()) : new SqlParameter("SteelTapeThroughSewer", DBNull.Value);
            SqlParameter newUsmhMouth12Parameter = (newUsmhMouth12.Trim() != "") ? new SqlParameter("USMHMouth12", newUsmhMouth12.Trim()) : new SqlParameter("USMHMouth12", DBNull.Value);
            SqlParameter newUsmhMouth1Parameter = (newUsmhMouth1.Trim() != "") ? new SqlParameter("USMHMouth1", newUsmhMouth1.Trim()) : new SqlParameter("USMHMouth1", DBNull.Value);
            SqlParameter newUsmhMouth2Parameter = (newUsmhMouth2.Trim() != "") ? new SqlParameter("USMHMouth2", newUsmhMouth2.Trim()) : new SqlParameter("USMHMouth2", DBNull.Value);
            SqlParameter newUsmhMouth3Parameter = (newUsmhMouth3.Trim() != "") ? new SqlParameter("USMHMouth3", newUsmhMouth3.Trim()) : new SqlParameter("USMHMouth3", DBNull.Value);
            SqlParameter newUsmhMouth4Parameter = (newUsmhMouth4.Trim() != "") ? new SqlParameter("USMHMouth4", newUsmhMouth4.Trim()) : new SqlParameter("USMHMouth4", DBNull.Value);
            SqlParameter newUsmhMouth5Parameter = (newUsmhMouth5.Trim() != "") ? new SqlParameter("USMHMouth5", newUsmhMouth5.Trim()) : new SqlParameter("USMHMouth5", DBNull.Value);
            SqlParameter newDsmhMouth12Parameter = (newDsmhMouth12.Trim() != "") ? new SqlParameter("DSMHMouth12", newDsmhMouth12.Trim()) : new SqlParameter("DSMHMouth12", DBNull.Value);
            SqlParameter newDsmhMouth1Parameter = (newDsmhMouth1.Trim() != "") ? new SqlParameter("DSMHMouth1", newDsmhMouth1.Trim()) : new SqlParameter("DSMHMouth1", DBNull.Value);
            SqlParameter newDsmhMouth2Parameter = (newDsmhMouth2.Trim() != "") ? new SqlParameter("DSMHMouth2", newDsmhMouth2.Trim()) : new SqlParameter("DSMHMouth2", DBNull.Value);
            SqlParameter newDsmhMouth3Parameter = (newDsmhMouth3.Trim() != "") ? new SqlParameter("DSMHMouth3", newDsmhMouth3.Trim()) : new SqlParameter("DSMHMouth3", DBNull.Value);
            SqlParameter newDsmhMouth4Parameter = (newDsmhMouth4.Trim() != "") ? new SqlParameter("DSMHMouth4", newDsmhMouth4.Trim()) : new SqlParameter("DSMHMouth4", DBNull.Value);
            SqlParameter newDsmhMouth5Parameter = (newDsmhMouth5.Trim() != "") ? new SqlParameter("DSMHMouth5", newDsmhMouth5.Trim()) : new SqlParameter("DSMHMouth5", DBNull.Value);
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);
            SqlParameter newSubAreaParameter = new SqlParameter("SubArea", newSubArea);
            SqlParameter originalAssetIdParameter = new SqlParameter("Original_AssetID", originalAssetId);
            SqlParameter newThicknessParameter = (newThickness.Trim() != "") ? new SqlParameter("Thickness", newThickness.Trim()) : new SqlParameter("Thickness", DBNull.Value);

            string command = "UPDATE [dbo].[LFS_ASSET_SEWER_SECTION]" +
                             "SET [AssetID] = @AssetID, [SteelTapeThroughSewer] = @SteelTapeThroughSewer, [USMHMouth12] = @USMHMouth12, [USMHMouth1] = @USMHMouth1, [USMHMouth2] = @USMHMouth2, [USMHMouth3] = @USMHMouth3, [USMHMouth4] = @USMHMouth4, [USMHMouth5] = @USMHMouth5, [DSMHMouth12] = @DSMHMouth12, [DSMHMouth1] = @DSMHMouth1, [DSMHMouth2] = @DSMHMouth2, [DSMHMouth3] = @DSMHMouth3, [DSMHMouth4] = @DSMHMouth4, [DSMHMouth5] = @DSMHMouth5, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID, [SubArea] = @SubArea, [Thickness] = @Thickness " +
                             "WHERE ([AssetID] = @Original_AssetID)";

            int rowsAffected = (int)ExecuteNonQuery(command, newAssetIdParameter, newSteelTapeThroughSewerParameter, newUsmhMouth12Parameter, newUsmhMouth1Parameter, newUsmhMouth2Parameter, newUsmhMouth3Parameter, newUsmhMouth4Parameter, newUsmhMouth5Parameter , newDsmhMouth12Parameter, newDsmhMouth1Parameter, newDsmhMouth2Parameter, newDsmhMouth3Parameter, newDsmhMouth4Parameter, newDsmhMouth5Parameter, newDeletedParameter, newCompanyIdParameter, newSubAreaParameter, originalAssetIdParameter, newThicknessParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        public void Delete(int assetId, int originalCompanyId)
        {
            SqlParameter originalAssetIdParameter = new SqlParameter("Original_AssetID", assetId);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);
            
            string command = "UPDATE [dbo].[LFS_ASSET_SEWER_SECTION] " +
                    " SET " +
                    "[Deleted] = @Deleted " +
                    "WHERE (([AssetID] = @Original_AssetID) AND " +
                    "([COMPANY_ID] = @Original_COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalAssetIdParameter, originalCompanyIdParameter, deletedParameter);
            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }
        }
                                  


    }
}