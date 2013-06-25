using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.CWP.DatabaseGateway
{
    /// <summary>
    /// LFSRecordJuntionLinerGateway
    /// </summary>
    public class LFSRecordJuntionLinerGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public LFSRecordJuntionLinerGateway()
            : base("LFS_JUNCTION_LINER")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public LFSRecordJuntionLinerGateway(DataSet data)
            : base(data, "LFS_JUNCTION_LINER")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new TDSLFSRecord();
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
            tableMapping.DataSetTable = "LFS_JUNCTION_LINER";
            tableMapping.ColumnMappings.Add("ID", "ID");
            tableMapping.ColumnMappings.Add("RefID", "RefID");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("DetailID", "DetailID");
            tableMapping.ColumnMappings.Add("MN", "MN");
            tableMapping.ColumnMappings.Add("DistanceFromUSMH", "DistanceFromUSMH");
            tableMapping.ColumnMappings.Add("ConfirmedLatSize", "ConfirmedLatSize");
            tableMapping.ColumnMappings.Add("LateralMaterial", "LateralMaterial");
            tableMapping.ColumnMappings.Add("SharedLateral", "SharedLateral");
            tableMapping.ColumnMappings.Add("CleanoutRequired", "CleanoutRequired");
            tableMapping.ColumnMappings.Add("PitRequired", "PitRequired");
            tableMapping.ColumnMappings.Add("MHShot", "MHShot");
            tableMapping.ColumnMappings.Add("MainConnection", "MainConnection");
            tableMapping.ColumnMappings.Add("Transition", "Transition");
            tableMapping.ColumnMappings.Add("CleanoutInstalled", "CleanoutInstalled");
            tableMapping.ColumnMappings.Add("PitInstalled", "PitInstalled");
            tableMapping.ColumnMappings.Add("CleanoutGrouted", "CleanoutGrouted");
            tableMapping.ColumnMappings.Add("CleanoutCored", "CleanoutCored");
            tableMapping.ColumnMappings.Add("PrepCompleted", "PrepCompleted");
            tableMapping.ColumnMappings.Add("MeasuredLatLength", "MeasuredLatLength");
            tableMapping.ColumnMappings.Add("MeasurementsTakenBy", "MeasurementsTakenBy");
            tableMapping.ColumnMappings.Add("LinerInstalled", "LinerInstalled");
            tableMapping.ColumnMappings.Add("FinalVideo", "FinalVideo");
            tableMapping.ColumnMappings.Add("RestorationComplete", "RestorationComplete");
            tableMapping.ColumnMappings.Add("LinerOrdered", "LinerOrdered");
            tableMapping.ColumnMappings.Add("LinerInStock", "LinerInStock");
            tableMapping.ColumnMappings.Add("LinerPrice", "LinerPrice");
            tableMapping.ColumnMappings.Add("Comments", "Comments");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("Archived", "Archived");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[LFS_JUNCTION_LINER] WHERE (([ID] = @Original_ID) AND ([RefID] " +
                "= @Original_RefID) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND ([DetailID] = @" +
                "Original_DetailID) AND ((@IsNull_MN = 1 AND [MN] IS NULL) OR ([MN] = @Original_M" +
                "N)) AND ((@IsNull_DistanceFromUSMH = 1 AND [DistanceFromUSMH] IS NULL) OR ([Dist" +
                "anceFromUSMH] = @Original_DistanceFromUSMH)) AND ((@IsNull_ConfirmedLatSize = 1 " +
                "AND [ConfirmedLatSize] IS NULL) OR ([ConfirmedLatSize] = @Original_ConfirmedLatS" +
                "ize)) AND ((@IsNull_LateralMaterial = 1 AND [LateralMaterial] IS NULL) OR ([Late" +
                "ralMaterial] = @Original_LateralMaterial)) AND ((@IsNull_SharedLateral = 1 AND [" +
                "SharedLateral] IS NULL) OR ([SharedLateral] = @Original_SharedLateral)) AND ((@I" +
                "sNull_CleanoutRequired = 1 AND [CleanoutRequired] IS NULL) OR ([CleanoutRequired" +
                "] = @Original_CleanoutRequired)) AND ((@IsNull_PitRequired = 1 AND [PitRequired]" +
                " IS NULL) OR ([PitRequired] = @Original_PitRequired)) AND ((@IsNull_MHShot = 1 A" +
                "ND [MHShot] IS NULL) OR ([MHShot] = @Original_MHShot)) AND ((@IsNull_MainConnect" +
                "ion = 1 AND [MainConnection] IS NULL) OR ([MainConnection] = @Original_MainConne" +
                "ction)) AND ((@IsNull_Transition = 1 AND [Transition] IS NULL) OR ([Transition] " +
                "= @Original_Transition)) AND ((@IsNull_CleanoutInstalled = 1 AND [CleanoutInstal" +
                "led] IS NULL) OR ([CleanoutInstalled] = @Original_CleanoutInstalled)) AND ((@IsN" +
                "ull_PitInstalled = 1 AND [PitInstalled] IS NULL) OR ([PitInstalled] = @Original_" +
                "PitInstalled)) AND ((@IsNull_CleanoutGrouted = 1 AND [CleanoutGrouted] IS NULL) " +
                "OR ([CleanoutGrouted] = @Original_CleanoutGrouted)) AND ((@IsNull_CleanoutCored " +
                "= 1 AND [CleanoutCored] IS NULL) OR ([CleanoutCored] = @Original_CleanoutCored))" +
                " AND ((@IsNull_PrepCompleted = 1 AND [PrepCompleted] IS NULL) OR ([PrepCompleted" +
                "] = @Original_PrepCompleted)) AND ((@IsNull_MeasuredLatLength = 1 AND [MeasuredL" +
                "atLength] IS NULL) OR ([MeasuredLatLength] = @Original_MeasuredLatLength)) AND (" +
                "(@IsNull_MeasurementsTakenBy = 1 AND [MeasurementsTakenBy] IS NULL) OR ([Measure" +
                "mentsTakenBy] = @Original_MeasurementsTakenBy)) AND ((@IsNull_LinerInstalled = 1" +
                " AND [LinerInstalled] IS NULL) OR ([LinerInstalled] = @Original_LinerInstalled))" +
                " AND ((@IsNull_FinalVideo = 1 AND [FinalVideo] IS NULL) OR ([FinalVideo] = @Orig" +
                "inal_FinalVideo)) AND ((@IsNull_RestorationComplete = 1 AND [RestorationComplete" +
                "] IS NULL) OR ([RestorationComplete] = @Original_RestorationComplete)) AND ((@Is" +
                "Null_LinerOrdered = 1 AND [LinerOrdered] IS NULL) OR ([LinerOrdered] = @Original" +
                "_LinerOrdered)) AND ((@IsNull_LinerInStock = 1 AND [LinerInStock] IS NULL) OR ([" +
                "LinerInStock] = @Original_LinerInStock)) AND ((@IsNull_LinerPrice = 1 AND [Liner" +
                "Price] IS NULL) OR ([LinerPrice] = @Original_LinerPrice)) AND ((@IsNull_Deleted " +
                "= 1 AND [Deleted] IS NULL) OR ([Deleted] = @Original_Deleted)) AND ((@IsNull_Arc" +
                "hived = 1 AND [Archived] IS NULL) OR ([Archived] = @Original_Archived)))";
            this._adapter.DeleteCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, 0, 0, "ID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RefID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "RefID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DetailID", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "DetailID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_MN", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "MN", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_MN", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "MN", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_DistanceFromUSMH", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "DistanceFromUSMH", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DistanceFromUSMH", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "DistanceFromUSMH", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_ConfirmedLatSize", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ConfirmedLatSize", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ConfirmedLatSize", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "ConfirmedLatSize", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_LateralMaterial", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LateralMaterial", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LateralMaterial", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "LateralMaterial", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_SharedLateral", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "SharedLateral", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_SharedLateral", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "SharedLateral", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_CleanoutRequired", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "CleanoutRequired", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CleanoutRequired", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "CleanoutRequired", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_PitRequired", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "PitRequired", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PitRequired", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "PitRequired", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_MHShot", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "MHShot", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_MHShot", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "MHShot", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_MainConnection", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "MainConnection", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_MainConnection", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "MainConnection", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Transition", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Transition", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Transition", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Transition", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_CleanoutInstalled", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "CleanoutInstalled", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CleanoutInstalled", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "CleanoutInstalled", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_PitInstalled", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "PitInstalled", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PitInstalled", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "PitInstalled", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_CleanoutGrouted", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "CleanoutGrouted", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CleanoutGrouted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "CleanoutGrouted", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_CleanoutCored", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "CleanoutCored", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CleanoutCored", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "CleanoutCored", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_PrepCompleted", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "PrepCompleted", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PrepCompleted", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "PrepCompleted", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_MeasuredLatLength", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "MeasuredLatLength", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_MeasuredLatLength", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "MeasuredLatLength", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_MeasurementsTakenBy", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "MeasurementsTakenBy", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_MeasurementsTakenBy", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "MeasurementsTakenBy", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_LinerInstalled", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LinerInstalled", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LinerInstalled", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "LinerInstalled", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_FinalVideo", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "FinalVideo", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_FinalVideo", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "FinalVideo", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_RestorationComplete", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "RestorationComplete", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RestorationComplete", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "RestorationComplete", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_LinerOrdered", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LinerOrdered", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LinerOrdered", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "LinerOrdered", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_LinerInStock", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LinerInStock", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LinerInStock", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "LinerInStock", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_LinerPrice", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LinerPrice", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LinerPrice", System.Data.SqlDbType.Money, 0, System.Data.ParameterDirection.Input, 0, 0, "LinerPrice", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Deleted", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Deleted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Archived", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Archived", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Archived", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Archived", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            
            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_JUNCTION_LINER] ([ID], [RefID], [COMPANY_ID], [DetailID], [MN], [DistanceFromUSMH], [ConfirmedLatSize], [LateralMaterial], [SharedLateral], [CleanoutRequired], [PitRequired], [MHShot], [MainConnection], [Transition], [CleanoutInstalled], [PitInstalled], [CleanoutGrouted], [CleanoutCored], [PrepCompleted], [MeasuredLatLength], [MeasurementsTakenBy], [LinerInstalled], [FinalVideo], [RestorationComplete], [LinerOrdered], [LinerInStock], [LinerPrice], [Comments], [Deleted], [Archived]) VALUES (@ID, @RefID, @COMPANY_ID, @DetailID, @MN, @DistanceFromUSMH, @ConfirmedLatSize, @LateralMaterial, @SharedLateral, @CleanoutRequired, @PitRequired, @MHShot, @MainConnection, @Transition, @CleanoutInstalled, @PitInstalled, @CleanoutGrouted, @CleanoutCored, @PrepCompleted, @MeasuredLatLength, @MeasurementsTakenBy, @LinerInstalled, @FinalVideo, @RestorationComplete, @LinerOrdered, @LinerInStock, @LinerPrice, @Comments, @Deleted, @Archived);
SELECT ID, RefID, COMPANY_ID, DetailID, MN, DistanceFromUSMH, ConfirmedLatSize, LateralMaterial, SharedLateral, CleanoutRequired, PitRequired, MHShot, MainConnection, Transition, CleanoutInstalled, PitInstalled, CleanoutGrouted, CleanoutCored, PrepCompleted, MeasuredLatLength, MeasurementsTakenBy, LinerInstalled, FinalVideo, RestorationComplete, LinerOrdered, LinerInStock, LinerPrice, Comments, Deleted, Archived FROM LFS_JUNCTION_LINER WHERE (COMPANY_ID = @COMPANY_ID) AND (ID = @ID) AND (RefID = @RefID)";
            this._adapter.InsertCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, 0, 0, "ID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RefID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "RefID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DetailID", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "DetailID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MN", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "MN", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DistanceFromUSMH", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "DistanceFromUSMH", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ConfirmedLatSize", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "ConfirmedLatSize", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LateralMaterial", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "LateralMaterial", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SharedLateral", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "SharedLateral", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CleanoutRequired", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "CleanoutRequired", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PitRequired", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "PitRequired", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MHShot", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "MHShot", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MainConnection", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "MainConnection", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Transition", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Transition", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CleanoutInstalled", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "CleanoutInstalled", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PitInstalled", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "PitInstalled", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CleanoutGrouted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "CleanoutGrouted", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CleanoutCored", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "CleanoutCored", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PrepCompleted", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "PrepCompleted", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MeasuredLatLength", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "MeasuredLatLength", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MeasurementsTakenBy", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "MeasurementsTakenBy", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LinerInstalled", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "LinerInstalled", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FinalVideo", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "FinalVideo", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RestorationComplete", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "RestorationComplete", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LinerOrdered", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "LinerOrdered", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LinerInStock", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "LinerInStock", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LinerPrice", System.Data.SqlDbType.Money, 0, System.Data.ParameterDirection.Input, 0, 0, "LinerPrice", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Comments", System.Data.SqlDbType.NText, 0, System.Data.ParameterDirection.Input, 0, 0, "Comments", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Deleted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Archived", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Archived", System.Data.DataRowVersion.Current, false, null, "", "", ""));

            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[LFS_JUNCTION_LINER] SET [ID] = @ID, [RefID] = @RefID, [COMPANY_ID] " +
                "= @COMPANY_ID, [DetailID] = @DetailID, [MN] = @MN, [DistanceFromUSMH] = @Distanc" +
                "eFromUSMH, [ConfirmedLatSize] = @ConfirmedLatSize, [LateralMaterial] = @LateralM" +
                "aterial, [SharedLateral] = @SharedLateral, [CleanoutRequired] = @CleanoutRequire" +
                "d, [PitRequired] = @PitRequired, [MHShot] = @MHShot, [MainConnection] = @MainCon" +
                "nection, [Transition] = @Transition, [CleanoutInstalled] = @CleanoutInstalled, [" +
                "PitInstalled] = @PitInstalled, [CleanoutGrouted] = @CleanoutGrouted, [CleanoutCo" +
                "red] = @CleanoutCored, [PrepCompleted] = @PrepCompleted, [MeasuredLatLength] = @" +
                "MeasuredLatLength, [MeasurementsTakenBy] = @MeasurementsTakenBy, [LinerInstalled" +
                "] = @LinerInstalled, [FinalVideo] = @FinalVideo, [RestorationComplete] = @Restor" +
                "ationComplete, [LinerOrdered] = @LinerOrdered, [LinerInStock] = @LinerInStock, [" +
                "LinerPrice] = @LinerPrice, [Comments] = @Comments, [Deleted] = @Deleted, [Archiv" +
                "ed] = @Archived WHERE (([ID] = @Original_ID) AND ([RefID] = @Original_RefID) AND" +
                " ([COMPANY_ID] = @Original_COMPANY_ID) AND ([DetailID] = @Original_DetailID) AND" +
                " ((@IsNull_MN = 1 AND [MN] IS NULL) OR ([MN] = @Original_MN)) AND ((@IsNull_Dist" +
                "anceFromUSMH = 1 AND [DistanceFromUSMH] IS NULL) OR ([DistanceFromUSMH] = @Origi" +
                "nal_DistanceFromUSMH)) AND ((@IsNull_ConfirmedLatSize = 1 AND [ConfirmedLatSize]" +
                " IS NULL) OR ([ConfirmedLatSize] = @Original_ConfirmedLatSize)) AND ((@IsNull_La" +
                "teralMaterial = 1 AND [LateralMaterial] IS NULL) OR ([LateralMaterial] = @Origin" +
                "al_LateralMaterial)) AND ((@IsNull_SharedLateral = 1 AND [SharedLateral] IS NULL" +
                ") OR ([SharedLateral] = @Original_SharedLateral)) AND ((@IsNull_CleanoutRequired" +
                " = 1 AND [CleanoutRequired] IS NULL) OR ([CleanoutRequired] = @Original_Cleanout" +
                "Required)) AND ((@IsNull_PitRequired = 1 AND [PitRequired] IS NULL) OR ([PitRequ" +
                "ired] = @Original_PitRequired)) AND ((@IsNull_MHShot = 1 AND [MHShot] IS NULL) O" +
                "R ([MHShot] = @Original_MHShot)) AND ((@IsNull_MainConnection = 1 AND [MainConne" +
                "ction] IS NULL) OR ([MainConnection] = @Original_MainConnection)) AND ((@IsNull_" +
                "Transition = 1 AND [Transition] IS NULL) OR ([Transition] = @Original_Transition" +
                ")) AND ((@IsNull_CleanoutInstalled = 1 AND [CleanoutInstalled] IS NULL) OR ([Cle" +
                "anoutInstalled] = @Original_CleanoutInstalled)) AND ((@IsNull_PitInstalled = 1 A" +
                "ND [PitInstalled] IS NULL) OR ([PitInstalled] = @Original_PitInstalled)) AND ((@" +
                "IsNull_CleanoutGrouted = 1 AND [CleanoutGrouted] IS NULL) OR ([CleanoutGrouted] " +
                "= @Original_CleanoutGrouted)) AND ((@IsNull_CleanoutCored = 1 AND [CleanoutCored" +
                "] IS NULL) OR ([CleanoutCored] = @Original_CleanoutCored)) AND ((@IsNull_PrepCom" +
                "pleted = 1 AND [PrepCompleted] IS NULL) OR ([PrepCompleted] = @Original_PrepComp" +
                "leted)) AND ((@IsNull_MeasuredLatLength = 1 AND [MeasuredLatLength] IS NULL) OR " +
                "([MeasuredLatLength] = @Original_MeasuredLatLength)) AND ((@IsNull_MeasurementsT" +
                "akenBy = 1 AND [MeasurementsTakenBy] IS NULL) OR ([MeasurementsTakenBy] = @Origi" +
                "nal_MeasurementsTakenBy)) AND ((@IsNull_LinerInstalled = 1 AND [LinerInstalled] " +
                "IS NULL) OR ([LinerInstalled] = @Original_LinerInstalled)) AND ((@IsNull_FinalVi" +
                "deo = 1 AND [FinalVideo] IS NULL) OR ([FinalVideo] = @Original_FinalVideo)) AND " +
                "((@IsNull_RestorationComplete = 1 AND [RestorationComplete] IS NULL) OR ([Restor" +
                "ationComplete] = @Original_RestorationComplete)) AND ((@IsNull_LinerOrdered = 1 " +
                "AND [LinerOrdered] IS NULL) OR ([LinerOrdered] = @Original_LinerOrdered)) AND ((" +
                "@IsNull_LinerInStock = 1 AND [LinerInStock] IS NULL) OR ([LinerInStock] = @Origi" +
                "nal_LinerInStock)) AND ((@IsNull_LinerPrice = 1 AND [LinerPrice] IS NULL) OR ([L" +
                "inerPrice] = @Original_LinerPrice)) AND ((@IsNull_Deleted = 1 AND [Deleted] IS N" +
                "ULL) OR ([Deleted] = @Original_Deleted)) AND ((@IsNull_Archived = 1 AND [Archive" +
                "d] IS NULL) OR ([Archived] = @Original_Archived)));\r\nSELECT ID, RefID, COMPANY_I" +
                "D, DetailID, MN, DistanceFromUSMH, ConfirmedLatSize, LateralMaterial, SharedLate" +
                "ral, CleanoutRequired, PitRequired, MHShot, MainConnection, Transition, Cleanout" +
                "Installed, PitInstalled, CleanoutGrouted, CleanoutCored, PrepCompleted, Measured" +
                "LatLength, MeasurementsTakenBy, LinerInstalled, FinalVideo, RestorationComplete," +
                " LinerOrdered, LinerInStock, LinerPrice, Comments, Deleted, Archived FROM LFS_JU" +
                "NCTION_LINER WHERE (COMPANY_ID = @COMPANY_ID) AND (ID = @ID) AND (RefID = @RefID" +
                ")";
            this._adapter.UpdateCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, 0, 0, "ID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RefID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "RefID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DetailID", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "DetailID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MN", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "MN", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DistanceFromUSMH", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "DistanceFromUSMH", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ConfirmedLatSize", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "ConfirmedLatSize", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LateralMaterial", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "LateralMaterial", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SharedLateral", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "SharedLateral", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CleanoutRequired", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "CleanoutRequired", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PitRequired", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "PitRequired", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MHShot", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "MHShot", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MainConnection", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "MainConnection", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Transition", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Transition", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CleanoutInstalled", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "CleanoutInstalled", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PitInstalled", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "PitInstalled", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CleanoutGrouted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "CleanoutGrouted", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CleanoutCored", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "CleanoutCored", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PrepCompleted", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "PrepCompleted", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MeasuredLatLength", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "MeasuredLatLength", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MeasurementsTakenBy", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "MeasurementsTakenBy", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LinerInstalled", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "LinerInstalled", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FinalVideo", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "FinalVideo", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RestorationComplete", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "RestorationComplete", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LinerOrdered", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "LinerOrdered", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LinerInStock", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "LinerInStock", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LinerPrice", System.Data.SqlDbType.Money, 0, System.Data.ParameterDirection.Input, 0, 0, "LinerPrice", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Comments", System.Data.SqlDbType.NText, 0, System.Data.ParameterDirection.Input, 0, 0, "Comments", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Deleted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Archived", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Archived", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, 0, 0, "ID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RefID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "RefID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DetailID", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "DetailID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_MN", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "MN", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_MN", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "MN", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_DistanceFromUSMH", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "DistanceFromUSMH", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DistanceFromUSMH", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "DistanceFromUSMH", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_ConfirmedLatSize", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ConfirmedLatSize", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ConfirmedLatSize", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "ConfirmedLatSize", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_LateralMaterial", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LateralMaterial", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LateralMaterial", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "LateralMaterial", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_SharedLateral", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "SharedLateral", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_SharedLateral", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "SharedLateral", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_CleanoutRequired", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "CleanoutRequired", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CleanoutRequired", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "CleanoutRequired", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_PitRequired", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "PitRequired", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PitRequired", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "PitRequired", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_MHShot", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "MHShot", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_MHShot", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "MHShot", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_MainConnection", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "MainConnection", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_MainConnection", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "MainConnection", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Transition", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Transition", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Transition", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Transition", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_CleanoutInstalled", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "CleanoutInstalled", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CleanoutInstalled", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "CleanoutInstalled", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_PitInstalled", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "PitInstalled", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PitInstalled", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "PitInstalled", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_CleanoutGrouted", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "CleanoutGrouted", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CleanoutGrouted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "CleanoutGrouted", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_CleanoutCored", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "CleanoutCored", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CleanoutCored", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "CleanoutCored", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_PrepCompleted", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "PrepCompleted", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PrepCompleted", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "PrepCompleted", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_MeasuredLatLength", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "MeasuredLatLength", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_MeasuredLatLength", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "MeasuredLatLength", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_MeasurementsTakenBy", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "MeasurementsTakenBy", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_MeasurementsTakenBy", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "MeasurementsTakenBy", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_LinerInstalled", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LinerInstalled", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LinerInstalled", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "LinerInstalled", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_FinalVideo", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "FinalVideo", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_FinalVideo", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "FinalVideo", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_RestorationComplete", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "RestorationComplete", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RestorationComplete", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "RestorationComplete", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_LinerOrdered", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LinerOrdered", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LinerOrdered", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "LinerOrdered", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_LinerInStock", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LinerInStock", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LinerInStock", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "LinerInStock", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_LinerPrice", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LinerPrice", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LinerPrice", System.Data.SqlDbType.Money, 0, System.Data.ParameterDirection.Input, 0, 0, "LinerPrice", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Deleted", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Deleted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Archived", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Archived", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Archived", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Archived", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROWS
        //

        /// <summary>
        /// Insert  (direct to DB)
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>        
        /// <param name="detailId">detailId</param>
        /// <param name="mn">mn</param>
        /// <param name="distanceFromUSMH">distanceFromUSMH</param>
        /// <param name="confirmedLatSize">confirmedLatSize</param>
        /// <param name="lateralMaterial">lateralMaterial</param>
        /// <param name="sharedLateral">sharedLateral</param>
        /// <param name="cleanoutRequired">cleanoutRequired</param>
        /// <param name="pitRequired">pitRequired</param>
        /// <param name="mhShot">mhShot</param>
        /// <param name="mainConnection">mainConnection</param>
        /// <param name="transition">transition</param>
        /// <param name="cleanoutInstalled">cleanoutInstalled</param>
        /// <param name="pitInstalled">pitInstalled</param>
        /// <param name="cleanoutGrouted">cleanoutGrouted</param>
        /// <param name="cleanoutCored">cleanoutCored</param>
        /// <param name="prepCompleted">prepCompleted</param>
        /// <param name="measuredLatLength">measuredLatLength</param>
        /// <param name="measurementsTakenBy">measurementsTakenBy</param>
        /// <param name="linerInstalled">linerInstalled</param>
        /// <param name="finalVideo">finalVideo</param>
        /// <param name="restorationComplete">restorationComplete</param>
        /// <param name="linerOrdered">linerOrdered</param>
        /// <param name="linerInStock">linerInStock</param>
        /// <param name="deleted">deleted</param>
        /// <param name="linerPrice">linerPrice</param>
        /// <param name="comments">comments</param>
        /// <param name="archived">archived</param>
        /// <returns>rowsAffected</returns>

        public int Insert(Guid id, int refId, int companyId, string detailId, string mn, double? distanceFromUSMH, string confirmedLatSize, string lateralMaterial, string sharedLateral, bool cleanoutRequired, bool pitRequired, bool mhShot, string mainConnection, string transition, bool cleanoutInstalled, bool pitInstalled, bool cleanoutGrouted, bool cleanoutCored, DateTime? prepCompleted, string measuredLatLength, string measurementsTakenBy, DateTime? linerInstalled, DateTime? finalVideo, bool restorationComplete, bool linerOrdered, bool linerInStock, decimal? linerPrice, string comments, bool deleted, bool archived)
        {
            SqlParameter idParameter = new SqlParameter("ID", id);
            SqlParameter refIdParameter = new SqlParameter("RefID", refId);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            SqlParameter detailIdParameter = new SqlParameter("DetailID", detailId);
            SqlParameter mnParameter = (mn.Trim() != "") ? new SqlParameter("MN", mn.Trim()) : new SqlParameter("MN", DBNull.Value);
            SqlParameter distanceFromUSMHParameter = (distanceFromUSMH.HasValue) ? new SqlParameter("DistanceFromUSMH", distanceFromUSMH) : new SqlParameter("DistanceFromUSMH", DBNull.Value);
            SqlParameter confirmedLatSizeParameter = (confirmedLatSize.Trim() != "") ? new SqlParameter("ConfirmedLatSize", confirmedLatSize.Trim()) : new SqlParameter("ConfirmedLatSize", DBNull.Value);
            SqlParameter lateralMaterialParameter = (lateralMaterial.Trim() != "") ? new SqlParameter("LateralMaterial", lateralMaterial.Trim()) : new SqlParameter("LateralMaterial", DBNull.Value);
            SqlParameter sharedLateralParameter = (sharedLateral.Trim() != "") ? new SqlParameter("SharedLateral", sharedLateral.Trim()) : new SqlParameter("SharedLateral", DBNull.Value);
            SqlParameter cleanoutRequiredParameter = new SqlParameter("CleanoutRequired", cleanoutRequired);
            SqlParameter pitRequiredParameter = new SqlParameter("PitRequired", pitRequired);
            SqlParameter mhShotParameter = new SqlParameter("MHShot", mhShot);
            SqlParameter mainConnectionParameter = (mainConnection.Trim() != "") ? new SqlParameter("MainConnection", mainConnection.Trim()) : new SqlParameter("MainConnection", DBNull.Value);
            SqlParameter transitionParameter = (transition.Trim() != "") ? new SqlParameter("Transition", transition.Trim()) : new SqlParameter("Transition", DBNull.Value);
            SqlParameter cleanoutInstalledParameter = new SqlParameter("CleanoutInstalled", cleanoutInstalled);
            SqlParameter pitInstalledParameter = new SqlParameter("PitInstalled", pitInstalled);
            SqlParameter cleanoutGroutedParameter = new SqlParameter("CleanoutGrouted", cleanoutGrouted);
            SqlParameter cleanoutCoredParameter = new SqlParameter("CleanoutCored", cleanoutCored);
            SqlParameter prepCompletedParameter = (prepCompleted.HasValue) ? new SqlParameter("PrepCompleted", prepCompleted) : new SqlParameter("PrepCompleted", DBNull.Value);
            SqlParameter measuredLatLengthParameter = (measuredLatLength.Trim() != "") ? new SqlParameter("MeasuredLatLength", measuredLatLength.Trim()) : new SqlParameter("MeasuredLatLength", DBNull.Value);
            SqlParameter measurementsTakenByParameter = (measurementsTakenBy.Trim() != "") ? new SqlParameter("MeasurementsTakenBy", measurementsTakenBy.Trim()) : new SqlParameter("MeasurementsTakenBy", DBNull.Value);
            SqlParameter linerInstalledParameter = (linerInstalled.HasValue) ? new SqlParameter("LinerInstalled", linerInstalled) : new SqlParameter("LinerInstalled", DBNull.Value);
            SqlParameter finalVideoParameter = (finalVideo.HasValue) ? new SqlParameter("FinalVideo", finalVideo) : new SqlParameter("FinalVideo", DBNull.Value);
            SqlParameter restorationCompleteParameter = new SqlParameter("RestorationComplete", restorationComplete);
            SqlParameter linerOrderedParameter = new SqlParameter("LinerOrdered", linerOrdered);
            SqlParameter linerInStockParameter = new SqlParameter("LinerInStock", linerInStock);
            SqlParameter linerPriceParameter = (linerPrice.HasValue) ? new SqlParameter("LinerPrice", linerPrice) : new SqlParameter("LinerPrice", DBNull.Value);
            linerPriceParameter.SqlDbType = SqlDbType.Money;                        
            SqlParameter commentsParameter = (comments.Trim() != "") ? new SqlParameter("Comments", comments) : new SqlParameter("Comments", DBNull.Value);
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter archivedParameter = new SqlParameter("Archived", archived);

            string command = "INSERT INTO [dbo].[LFS_JUNCTION_LINER] ([ID], [RefID], [COMPANY_ID], [DetailID], [MN], [DistanceFromUSMH], [ConfirmedLatSize], [LateralMaterial], [SharedLateral], [CleanoutRequired], [PitRequired], [MHShot], [MainConnection], [Transition], [CleanoutInstalled], [PitInstalled], [CleanoutGrouted], [CleanoutCored], [PrepCompleted], [MeasuredLatLength], [MeasurementsTakenBy], [LinerInstalled], [FinalVideo], [RestorationComplete], [LinerOrdered], [LinerInStock], [LinerPrice], [Comments], [Deleted], [Archived]) VALUES (@ID, @RefID, @COMPANY_ID, @DetailID, @MN, @DistanceFromUSMH, @ConfirmedLatSize, @LateralMaterial, @SharedLateral, @CleanoutRequired, @PitRequired, @MHShot, @MainConnection, @Transition, @CleanoutInstalled, @PitInstalled, @CleanoutGrouted, @CleanoutCored, @PrepCompleted, @MeasuredLatLength, @MeasurementsTakenBy, @LinerInstalled, @FinalVideo, @RestorationComplete, @LinerOrdered, @LinerInStock, @LinerPrice, @Comments, @Deleted, @Archived)";

            int rowsAffected = (int)ExecuteNonQuery(command, idParameter, refIdParameter, companyIdParameter, detailIdParameter, mnParameter, distanceFromUSMHParameter, confirmedLatSizeParameter, lateralMaterialParameter, sharedLateralParameter, cleanoutRequiredParameter, pitRequiredParameter, mhShotParameter, mainConnectionParameter, transitionParameter, cleanoutInstalledParameter, pitInstalledParameter, cleanoutGroutedParameter, cleanoutCoredParameter, prepCompletedParameter, measuredLatLengthParameter, measurementsTakenByParameter, linerInstalledParameter, finalVideoParameter, restorationCompleteParameter, linerOrderedParameter, linerInStockParameter, linerPriceParameter, commentsParameter, deletedParameter, archivedParameter);

            return rowsAffected;
        }



        /// <summary>
        /// Update  (direct to DB)
        /// </summary>
        /// <param name="originalId">originalId</param>
        /// <param name="originalRefId">originalRefId</param>
        /// <param name="originalCompanyId">originalCOMPANY_ID</param>        
        /// <param name="originalDetailId">originalDetailId</param>
        /// <param name="originalMn">originalMn</param>
        /// <param name="originalDistanceFromUSMH">originalDistanceFromUSMH</param>
        /// <param name="originalConfirmedLatSize">originalConfirmedLatSize</param>
        /// <param name="originalLateralMaterial">originalLateralMaterial</param>
        /// <param name="originalSharedLateral">originalSharedLateral</param>
        /// <param name="originalCleanoutRequired">originalCleanoutRequired</param>
        /// <param name="originalPitRequired">originalPitRequired</param>
        /// <param name="originalMHShot">originalMHShot</param>
        /// <param name="originalMainConnection">originalMainConnection</param>
        /// <param name="originalTransition">originalTransition</param>
        /// <param name="originalCleanoutInstalled">originalCleanoutInstalled</param>
        /// <param name="originalPitInstalled">originalPitInstalled</param>
        /// <param name="originalCleanoutGrouted">originalCleanoutGrouted</param>
        /// <param name="originalCleanoutCored">originalCleanoutCored</param>
        /// <param name="originalPrepCompleted">originalPrepCompleted</param>
        /// <param name="originalMeasuredLatLength">originalMeasuredLatLength</param>
        /// <param name="originalMeasurementsTakenBy">originalMeasurementsTakenBy</param>
        /// <param name="originalLinerInstalled">originalLinerInstalled</param>
        /// <param name="originalFinalVideo">originalFinalVideo</param>
        /// <param name="originalRestorationComplete">originalRestorationComplete</param>
        /// <param name="originalLinerOrdered">originalLinerOrdered</param>
        /// <param name="originalLinerInStock">originalLinerInStock</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalLinerPrice">originalLinerPrice</param>
        /// <param name="originalComments">originalComments</param>
        /// <param name="originalArchived">originaArchived</param>
        ///  
        /// <param name="newId">newId</param>
        /// <param name="newRefId">newRefId</param>
        /// <param name="newCompanyId">newCompanyId</param>        
        /// <param name="newDetailId">newDetailId</param>
        /// <param name="newMn">newMn</param>
        /// <param name="newDistanceFromUSMH">newDistanceFromUSMH</param>
        /// <param name="newConfirmedLatSize">newConfirmedLatSize</param>
        /// <param name="newLateralMaterial">newLateralMaterial</param>
        /// <param name="newSharedLateral">newSharedLateral</param>
        /// <param name="newCleanoutRequired">newCleanoutRequired</param>
        /// <param name="newPitRequired">newPitRequired</param>
        /// <param name="newMHShot">newMHShot</param>
        /// <param name="newMainConnection">newMainConnection</param>
        /// <param name="newTransition">newTransition</param>
        /// <param name="newCleanoutInstalled">newCleanoutInstalled</param>
        /// <param name="newPitInstalled">newPitInstalled</param>
        /// <param name="newCleanoutGrouted">newCleanoutGrouted</param>
        /// <param name="newCleanoutCored">newCleanoutCored</param>
        /// <param name="newPrepCompleted">newPrepCompleted</param>
        /// <param name="newMeasuredLatLength">newMeasuredLatLength</param>
        /// <param name="newMeasurementsTakenBy">newMeasurementsTakenBy</param>
        /// <param name="newLinerInstalled">newLinerInstalled</param>
        /// <param name="newFinalVideo">newFinalVideo</param>
        /// <param name="newRestorationComplete">newRestorationComplete</param>
        /// <param name="newLinerOrdered">newLinerOrdered</param>
        /// <param name="newLinerInStock">newLinerInStock</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newLinerPrice">newLinerPrice</param>
        /// <param name="newComments">newComments</param>
        /// <param name="newArchived">newArchived</param>
        public int Update(Guid originalId, int originalRefId, int originalCompanyId, string originalDetailId, string originalMn, double? originalDistanceFromUSMH, string originalConfirmedLatSize, string originalLateralMaterial, string originalSharedLateral, bool originalCleanoutRequired, bool originalPitRequired, bool originalMHShot, string originalMainConnection, string originalTransition, bool originalCleanoutInstalled, bool originalPitInstalled, bool originalCleanoutGrouted, bool originalCleanoutCored, DateTime? originalPrepCompleted, string originalMeasuredLatLength, string originalMeasurementsTakenBy, DateTime? originalLinerInstalled, DateTime? originalFinalVideo, bool originalRestorationComplete, bool originalLinerOrdered, bool originalLinerInStock, decimal? originalLinerPrice, string originalComments, bool originalDeleted, bool originalArchived, Guid newId, int newRefId, int newCompanyId, string newDetailId, string newMn, double? newDistanceFromUSMH, string newConfirmedLatSize, string newLateralMaterial, string newSharedLateral, bool newCleanoutRequired, bool newPitRequired, bool newMHShot, string newMainConnection, string newTransition, bool newCleanoutInstalled, bool newPitInstalled, bool newCleanoutGrouted, bool newCleanoutCored, DateTime? newPrepCompleted, string newMeasuredLatLength, string newMeasurementsTakenBy, DateTime? newLinerInstalled, DateTime? newFinalVideo, bool newRestorationComplete, bool newLinerOrdered, bool newLinerInStock, decimal? newLinerPrice, string newComments, bool newDeleted, bool newArchived)
        {
            SqlParameter originalIdParameter = new SqlParameter("Original_ID", originalId);
            SqlParameter originalRefIdParameter = new SqlParameter("Original_RefID", originalRefId);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter originalDetailIdParameter = new SqlParameter("Original_DetailID", originalDetailId);
            SqlParameter originalMnParameter = (originalMn.Trim() != "") ? new SqlParameter("Original_MN", originalMn.Trim()) : new SqlParameter("Original_MN", DBNull.Value);
            SqlParameter originalDistanceFromUSMHParameter = (originalDistanceFromUSMH.HasValue) ? new SqlParameter("Original_DistanceFromUSMH", originalDistanceFromUSMH) : new SqlParameter("Original_DistanceFromUSMH", DBNull.Value);
            SqlParameter originalConfirmedLatSizeParameter = (originalConfirmedLatSize.Trim() != "") ? new SqlParameter("Original_ConfirmedLatSize", originalConfirmedLatSize.Trim()) : new SqlParameter("Original_ConfirmedLatSize", DBNull.Value);
            SqlParameter originalLateralMaterialParameter = (originalLateralMaterial.Trim() != "") ? new SqlParameter("Original_LateralMaterial", originalLateralMaterial.Trim()) : new SqlParameter("Original_LateralMaterial", DBNull.Value);
            SqlParameter originalSharedLateralParameter = (originalSharedLateral.Trim() != "") ? new SqlParameter("Original_SharedLateral", originalSharedLateral.Trim()) : new SqlParameter("Original_SharedLateral", DBNull.Value);
            SqlParameter originalCleanoutRequiredParameter = new SqlParameter("Original_CleanoutRequired", originalCleanoutRequired);
            SqlParameter originalPitRequiredParameter = new SqlParameter("Original_PitRequired", originalPitRequired);
            SqlParameter originalMHShotParameter = new SqlParameter("Original_MHShot", originalMHShot);
            SqlParameter originalMainConnectionParameter = (originalMainConnection.Trim() != "") ? new SqlParameter("Original_MainConnection", originalMainConnection.Trim()) : new SqlParameter("Original_MainConnection", DBNull.Value);
            SqlParameter originalTransitionParameter = (originalTransition.Trim() != "") ? new SqlParameter("Original_Transition", originalTransition.Trim()) : new SqlParameter("Original_Transition", DBNull.Value);
            SqlParameter originalCleanoutInstalledParameter = new SqlParameter("Original_CleanoutInstalled", originalCleanoutInstalled);
            SqlParameter originalPitInstalledParameter = new SqlParameter("Original_PitInstalled", originalPitInstalled);
            SqlParameter originalCleanoutGroutedParameter = new SqlParameter("Original_CleanoutGrouted", originalCleanoutGrouted);
            SqlParameter originalCleanoutCoredParameter = new SqlParameter("Original_CleanoutCored", originalCleanoutCored);
            SqlParameter originalPrepCompletedParameter = (originalPrepCompleted.HasValue) ? new SqlParameter("Original_PrepCompleted", originalPrepCompleted) : new SqlParameter("Original_PrepCompleted", DBNull.Value);
            SqlParameter originalMeasuredLatLengthParameter = (originalMeasuredLatLength.Trim() != "") ? new SqlParameter("Original_MeasuredLatLength", originalMeasuredLatLength.Trim()) : new SqlParameter("Original_MeasuredLatLength", DBNull.Value);
            SqlParameter originalMeasurementsTakenByParameter = (originalMeasurementsTakenBy.Trim() != "") ? new SqlParameter("Original_MeasurementsTakenBy", originalMeasurementsTakenBy.Trim()) : new SqlParameter("Original_MeasurementsTakenBy", DBNull.Value);
            SqlParameter originalLinerInstalledParameter = (originalLinerInstalled.HasValue) ? new SqlParameter("Original_LinerInstalled", originalLinerInstalled) : new SqlParameter("Original_LinerInstalled", DBNull.Value);
            SqlParameter originalFinalVideoParameter = (originalFinalVideo.HasValue) ? new SqlParameter("Original_FinalVideo", originalFinalVideo) : new SqlParameter("Original_FinalVideo", DBNull.Value);
            SqlParameter originalRestorationCompleteParameter = new SqlParameter("Original_RestorationComplete", originalRestorationComplete);
            SqlParameter originalLinerOrderedParameter = new SqlParameter("Original_LinerOrdered", originalLinerOrdered);
            SqlParameter originalLinerInStockParameter = new SqlParameter("Original_LinerInStock", originalLinerInStock);
            SqlParameter originalLinerPriceParameter = (originalLinerPrice.HasValue) ? new SqlParameter("Original_LinerPrice", originalLinerPrice) : new SqlParameter("Original_LinerPrice", DBNull.Value);
            originalLinerPriceParameter.SqlDbType = SqlDbType.Money;
            SqlParameter originalCommentsParameter = (originalComments.Trim() != "") ? new SqlParameter("Original_Comments", originalComments) : new SqlParameter("Original_Comments", DBNull.Value);
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);            
            SqlParameter originalArchivedParameter = new SqlParameter("Original_Archived", originalArchived);

            SqlParameter newIdParameter = new SqlParameter("ID", newId);
            SqlParameter newRefIdParameter = new SqlParameter("RefID", newRefId);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);
            SqlParameter newDetailIdParameter = new SqlParameter("DetailID", newDetailId);
            SqlParameter newMnParameter = (newMn.Trim() != "") ? new SqlParameter("MN", newMn.Trim()) : new SqlParameter("MN", DBNull.Value);
            SqlParameter newDistanceFromUSMHParameter = (newDistanceFromUSMH.HasValue) ? new SqlParameter("DistanceFromUSMH", newDistanceFromUSMH) : new SqlParameter("DistanceFromUSMH", DBNull.Value);
            SqlParameter newConfirmedLatSizeParameter = (newConfirmedLatSize.Trim() != "") ? new SqlParameter("ConfirmedLatSize", newConfirmedLatSize.Trim()) : new SqlParameter("ConfirmedLatSize", DBNull.Value);
            SqlParameter newLateralMaterialParameter = (newLateralMaterial.Trim() != "") ? new SqlParameter("LateralMaterial", newLateralMaterial.Trim()) : new SqlParameter("LateralMaterial", DBNull.Value);
            SqlParameter newSharedLateralParameter = (newSharedLateral.Trim() != "") ? new SqlParameter("SharedLateral", newSharedLateral.Trim()) : new SqlParameter("SharedLateral", DBNull.Value);
            SqlParameter newCleanoutRequiredParameter = new SqlParameter("CleanoutRequired", newCleanoutRequired);
            SqlParameter newPitRequiredParameter = new SqlParameter("PitRequired", newPitRequired);
            SqlParameter newMHShotParameter = new SqlParameter("MHShot", newMHShot);
            SqlParameter newMainConnectionParameter = (newMainConnection.Trim() != "") ? new SqlParameter("MainConnection", newMainConnection.Trim()) : new SqlParameter("MainConnection", DBNull.Value);
            SqlParameter newTransitionParameter = (newTransition.Trim() != "") ? new SqlParameter("Transition", newTransition.Trim()) : new SqlParameter("Transition", DBNull.Value);
            SqlParameter newCleanoutInstalledParameter = new SqlParameter("CleanoutInstalled", newCleanoutInstalled);
            SqlParameter newPitInstalledParameter = new SqlParameter("PitInstalled", newPitInstalled);
            SqlParameter newCleanoutGroutedParameter = new SqlParameter("CleanoutGrouted", newCleanoutGrouted);
            SqlParameter newCleanoutCoredParameter = new SqlParameter("CleanoutCored", newCleanoutCored);
            SqlParameter newPrepCompletedParameter = (newPrepCompleted.HasValue) ? new SqlParameter("PrepCompleted", newPrepCompleted) : new SqlParameter("PrepCompleted", DBNull.Value);
            SqlParameter newMeasuredLatLengthParameter = (newMeasuredLatLength.Trim() != "") ? new SqlParameter("MeasuredLatLength", newMeasuredLatLength.Trim()) : new SqlParameter("MeasuredLatLength", DBNull.Value);
            SqlParameter newMeasurementsTakenByParameter = (newMeasurementsTakenBy.Trim() != "") ? new SqlParameter("MeasurementsTakenBy", newMeasurementsTakenBy.Trim()) : new SqlParameter("MeasurementsTakenBy", DBNull.Value);
            SqlParameter newLinerInstalledParameter = (newLinerInstalled.HasValue) ? new SqlParameter("LinerInstalled", newLinerInstalled) : new SqlParameter("LinerInstalled", DBNull.Value);
            SqlParameter newFinalVideoParameter = (newFinalVideo.HasValue) ? new SqlParameter("FinalVideo", newFinalVideo) : new SqlParameter("FinalVideo", DBNull.Value);
            SqlParameter newRestorationCompleteParameter = new SqlParameter("RestorationComplete", newRestorationComplete);
            SqlParameter newLinerOrderedParameter = new SqlParameter("LinerOrdered", newLinerOrdered);
            SqlParameter newLinerInStockParameter = new SqlParameter("LinerInStock", newLinerInStock);
            SqlParameter newLinerPriceParameter = (newLinerPrice.HasValue) ? new SqlParameter("LinerPrice", newLinerPrice) : new SqlParameter("LinerPrice", DBNull.Value);
            newLinerPriceParameter.SqlDbType = SqlDbType.Money;
            SqlParameter newCommentsParameter = (newComments.Trim() != "") ? new SqlParameter("Comments", newComments) : new SqlParameter("Comments", DBNull.Value);
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);
            SqlParameter newArchivedParameter = new SqlParameter("Archived", newArchived);


            string command = "UPDATE [dbo].[LFS_JUNCTION_LINER] SET [ID] = @ID, [RefID] = @RefID, [COMPANY_ID] " +
                "= @COMPANY_ID, [DetailID] = @DetailID, [MN] = @MN, [DistanceFromUSMH] = @Distanc" +
                "eFromUSMH, [ConfirmedLatSize] = @ConfirmedLatSize, [LateralMaterial] = @LateralM" +
                "aterial, [SharedLateral] = @SharedLateral, [CleanoutRequired] = @CleanoutRequire" +
                "d, [PitRequired] = @PitRequired, [MHShot] = @MHShot, [MainConnection] = @MainCon" +
                "nection, [Transition] = @Transition, [CleanoutInstalled] = @CleanoutInstalled, [" +
                "PitInstalled] = @PitInstalled, [CleanoutGrouted] = @CleanoutGrouted, [CleanoutCo" +
                "red] = @CleanoutCored, [PrepCompleted] = @PrepCompleted, [MeasuredLatLength] = @" +
                "MeasuredLatLength, [MeasurementsTakenBy] = @MeasurementsTakenBy, [LinerInstalled" +
                "] = @LinerInstalled, [FinalVideo] = @FinalVideo, [RestorationComplete] = @Restor" +
                "ationComplete, [LinerOrdered] = @LinerOrdered, [LinerInStock] = @LinerInStock, [" +
                "LinerPrice] = @LinerPrice, [Comments] = @Comments, [Deleted] = @Deleted, [Archiv" +
                "ed] = @Archived " +
                "WHERE (" +
                "([RefID] = @Original_RefID) AND ([ID] = @Original_ID) AND " +
                " ([COMPANY_ID] = @Original_COMPANY_ID)" +
                " )";

            int rowsAffected = (int)ExecuteNonQuery(command, originalIdParameter, originalRefIdParameter, originalCompanyIdParameter, originalDetailIdParameter, originalMnParameter, originalDistanceFromUSMHParameter, originalConfirmedLatSizeParameter, originalLateralMaterialParameter, originalSharedLateralParameter, originalCleanoutRequiredParameter, originalPitRequiredParameter, originalMHShotParameter, originalMainConnectionParameter, originalTransitionParameter, originalCleanoutInstalledParameter, originalPitInstalledParameter, originalCleanoutGroutedParameter, originalCleanoutCoredParameter, originalPrepCompletedParameter, originalMeasuredLatLengthParameter, originalMeasurementsTakenByParameter, originalLinerInstalledParameter, originalFinalVideoParameter, originalRestorationCompleteParameter, originalLinerOrderedParameter, originalLinerInStockParameter, originalLinerPriceParameter, originalCommentsParameter, originalDeletedParameter, originalArchivedParameter,  newIdParameter, newRefIdParameter, newCompanyIdParameter, newDetailIdParameter, newMnParameter, newDistanceFromUSMHParameter, newConfirmedLatSizeParameter, newLateralMaterialParameter, newSharedLateralParameter, newCleanoutRequiredParameter, newPitRequiredParameter, newMHShotParameter, newMainConnectionParameter, newTransitionParameter, newCleanoutInstalledParameter, newPitInstalledParameter, newCleanoutGroutedParameter, newCleanoutCoredParameter, newPrepCompletedParameter, newMeasuredLatLengthParameter, newMeasurementsTakenByParameter, newLinerInstalledParameter, newFinalVideoParameter, newRestorationCompleteParameter, newLinerOrderedParameter, newLinerInStockParameter, newLinerPriceParameter, newCommentsParameter, newDeletedParameter, newArchivedParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }



        /// <summary>
        /// Delete service request (direct to DB)
        /// </summary>
        /// <param name="originalId">originalId</param>
        /// <param name="originalRefId">originalRefId</param>        
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <returns>int</returns>
        public int Delete(Guid originalId, int originalRefId, int originalCompanyId)
        {
            SqlParameter originalIdParameter = new SqlParameter("Original_ID", originalId);
            SqlParameter originalRefIdParameter = new SqlParameter("Original_RefID", originalRefId);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_JUNCTION_LINER] SET  [Deleted] = @Deleted  " +
                             " WHERE ( ([ID] = @Original_ID) AND ([RefID] = @Original_RefID) AND " +
                             "  ([COMPANY_ID] = @Original_COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalIdParameter, originalRefIdParameter, originalCompanyIdParameter, deletedParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }
    }
}
