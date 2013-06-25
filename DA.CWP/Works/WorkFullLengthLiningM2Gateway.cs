using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.Works
{
    /// <summary>
    /// WorkFullLengthLiningM2Gateway
    /// </summary>
    public class WorkFullLengthLiningM2Gateway : DataTableGateway
    {
        ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkFullLengthLiningM2Gateway() : base("LFS_WORK_FULLLENGTHLINING_M2")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkFullLengthLiningM2Gateway(DataSet data) : base(data, "LFS_WORK_FULLLENGTHLINING_M2")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new WorkTDS();
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
            tableMapping.DataSetTable = "LFS_WORK_FULLLENGTHLINING_M2";
            tableMapping.ColumnMappings.Add("WorkID", "WorkID");
            tableMapping.ColumnMappings.Add("VideoLength", "VideoLength");
            tableMapping.ColumnMappings.Add("MeasurementTakenBy", "MeasurementTakenBy");
            tableMapping.ColumnMappings.Add("DropPipe", "DropPipe");
            tableMapping.ColumnMappings.Add("DropPipeInvertDepth", "DropPipeInvertDepth");
            tableMapping.ColumnMappings.Add("CappedLaterals", "CappedLaterals");
            tableMapping.ColumnMappings.Add("LineWithID", "LineWithID");
            tableMapping.ColumnMappings.Add("HydrantAddress", "HydrantAddress");
            tableMapping.ColumnMappings.Add("HydroWireWithin10FtOfInversionMH", "HydroWireWithin10FtOfInversionMH");
            tableMapping.ColumnMappings.Add("DistanceToInversionMH", "DistanceToInversionMH");
            tableMapping.ColumnMappings.Add("SurfaceGrade", "SurfaceGrade");
            tableMapping.ColumnMappings.Add("HydroPulley", "HydroPulley");
            tableMapping.ColumnMappings.Add("FridgeCart", "FridgeCart");
            tableMapping.ColumnMappings.Add("TwoPump", "TwoPump");
            tableMapping.ColumnMappings.Add("SixBypass", "SixBypass");
            tableMapping.ColumnMappings.Add("Scaffolding", "Scaffolding");
            tableMapping.ColumnMappings.Add("WinchExtention", "WinchExtention");
            tableMapping.ColumnMappings.Add("ExtraGenerator", "ExtraGenerator");
            tableMapping.ColumnMappings.Add("GreyCableExtension", "GreyCableExtension");
            tableMapping.ColumnMappings.Add("EasementMats", "EasementMats");
            tableMapping.ColumnMappings.Add("RampRequired", "RampRequired");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("CameraSkid", "CameraSkid");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[LFS_WORK_FULLLENGTHLINING_M2] WHERE (([WorkID] = @Original_Wor" +
                "kID) AND ((@IsNull_VideoLength = 1 AND [VideoLength] IS NULL) OR ([VideoLength] " +
                "= @Original_VideoLength)) AND ((@IsNull_MeasurementTakenBy = 1 AND [MeasurementT" +
                "akenBy] IS NULL) OR ([MeasurementTakenBy] = @Original_MeasurementTakenBy)) AND (" +
                "[DropPipe] = @Original_DropPipe) AND ((@IsNull_DropPipeInvertDepth = 1 AND [Drop" +
                "PipeInvertDepth] IS NULL) OR ([DropPipeInvertDepth] = @Original_DropPipeInvertDe" +
                "pth)) AND ((@IsNull_CappedLaterals = 1 AND [CappedLaterals] IS NULL) OR ([Capped" +
                "Laterals] = @Original_CappedLaterals)) AND ((@IsNull_LineWithID = 1 AND [LineWit" +
                "hID] IS NULL) OR ([LineWithID] = @Original_LineWithID)) AND ((@IsNull_HydrantAdd" +
                "ress = 1 AND [HydrantAddress] IS NULL) OR ([HydrantAddress] = @Original_HydrantA" +
                "ddress)) AND ((@IsNull_HydroWireWithin10FtOfInversionMH = 1 AND [HydroWireWithin" +
                "10FtOfInversionMH] IS NULL) OR ([HydroWireWithin10FtOfInversionMH] = @Original_H" +
                "ydroWireWithin10FtOfInversionMH)) AND ((@IsNull_DistanceToInversionMH = 1 AND [D" +
                "istanceToInversionMH] IS NULL) OR ([DistanceToInversionMH] = @Original_DistanceT" +
                "oInversionMH)) AND ((@IsNull_SurfaceGrade = 1 AND [SurfaceGrade] IS NULL) OR ([S" +
                "urfaceGrade] = @Original_SurfaceGrade)) AND ([HydroPulley] = @Original_HydroPull" +
                "ey) AND ([FridgeCart] = @Original_FridgeCart) AND ([TwoPump] = @Original_TwoPump" +
                ") AND ([SixBypass] = @Original_SixBypass) AND ([Scaffolding] = @Original_Scaffol" +
                "ding) AND ([WinchExtention] = @Original_WinchExtention) AND ([ExtraGenerator] = " +
                "@Original_ExtraGenerator) AND ([GreyCableExtension] = @Original_GreyCableExtensi" +
                "on) AND ([EasementMats] = @Original_EasementMats) AND ([RampRequired] = @Origina" +
                "l_RampRequired) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Origina" +
                "l_COMPANY_ID) AND ([CameraSkid] = @Original_CameraSkid))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_WorkID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_VideoLength", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VideoLength", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_VideoLength", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VideoLength", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_MeasurementTakenBy", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MeasurementTakenBy", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MeasurementTakenBy", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MeasurementTakenBy", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DropPipe", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DropPipe", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DropPipeInvertDepth", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DropPipeInvertDepth", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DropPipeInvertDepth", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DropPipeInvertDepth", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_CappedLaterals", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CappedLaterals", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CappedLaterals", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CappedLaterals", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_LineWithID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LineWithID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LineWithID", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LineWithID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_HydrantAddress", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HydrantAddress", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_HydrantAddress", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HydrantAddress", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_HydroWireWithin10FtOfInversionMH", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HydroWireWithin10FtOfInversionMH", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_HydroWireWithin10FtOfInversionMH", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HydroWireWithin10FtOfInversionMH", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DistanceToInversionMH", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DistanceToInversionMH", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DistanceToInversionMH", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DistanceToInversionMH", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_SurfaceGrade", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SurfaceGrade", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_SurfaceGrade", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SurfaceGrade", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_HydroPulley", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HydroPulley", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_FridgeCart", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FridgeCart", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TwoPump", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TwoPump", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_SixBypass", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SixBypass", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Scaffolding", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Scaffolding", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_WinchExtention", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WinchExtention", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ExtraGenerator", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ExtraGenerator", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_GreyCableExtension", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "GreyCableExtension", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_EasementMats", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EasementMats", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RampRequired", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RampRequired", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CameraSkid", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CameraSkid", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_WORK_FULLLENGTHLINING_M2] ([WorkID], [VideoLength], [MeasurementTakenBy], [DropPipe], [DropPipeInvertDepth], [CappedLaterals], [LineWithID], [HydrantAddress], [HydroWireWithin10FtOfInversionMH], [DistanceToInversionMH], [SurfaceGrade], [HydroPulley], [FridgeCart], [TwoPump], [SixBypass], [Scaffolding], [WinchExtention], [ExtraGenerator], [GreyCableExtension], [EasementMats], [RampRequired], [Deleted], [COMPANY_ID], [CameraSkid]) VALUES (@WorkID, @VideoLength, @MeasurementTakenBy, @DropPipe, @DropPipeInvertDepth, @CappedLaterals, @LineWithID, @HydrantAddress, @HydroWireWithin10FtOfInversionMH, @DistanceToInversionMH, @SurfaceGrade, @HydroPulley, @FridgeCart, @TwoPump, @SixBypass, @Scaffolding, @WinchExtention, @ExtraGenerator, @GreyCableExtension, @EasementMats, @RampRequired, @Deleted, @COMPANY_ID, @CameraSkid);
SELECT WorkID, VideoLength, MeasurementTakenBy, DropPipe, DropPipeInvertDepth, CappedLaterals, LineWithID, HydrantAddress, HydroWireWithin10FtOfInversionMH, DistanceToInversionMH, SurfaceGrade, HydroPulley, FridgeCart, TwoPump, SixBypass, Scaffolding, WinchExtention, ExtraGenerator, GreyCableExtension, EasementMats, RampRequired, Deleted, COMPANY_ID, CameraSkid FROM LFS_WORK_FULLLENGTHLINING_M2 WHERE (WorkID = @WorkID)";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@WorkID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@VideoLength", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VideoLength", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MeasurementTakenBy", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MeasurementTakenBy", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DropPipe", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DropPipe", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DropPipeInvertDepth", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DropPipeInvertDepth", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CappedLaterals", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CappedLaterals", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LineWithID", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LineWithID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@HydrantAddress", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HydrantAddress", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@HydroWireWithin10FtOfInversionMH", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HydroWireWithin10FtOfInversionMH", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DistanceToInversionMH", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DistanceToInversionMH", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@SurfaceGrade", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SurfaceGrade", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@HydroPulley", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HydroPulley", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@FridgeCart", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FridgeCart", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TwoPump", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TwoPump", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@SixBypass", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SixBypass", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Scaffolding", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Scaffolding", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@WinchExtention", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WinchExtention", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ExtraGenerator", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ExtraGenerator", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@GreyCableExtension", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "GreyCableExtension", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@EasementMats", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EasementMats", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RampRequired", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RampRequired", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CameraSkid", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CameraSkid", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));

            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[LFS_WORK_FULLLENGTHLINING_M2] SET [WorkID] = @WorkID, [VideoLength]" +
                " = @VideoLength, [MeasurementTakenBy] = @MeasurementTakenBy, [DropPipe] = @DropP" +
                "ipe, [DropPipeInvertDepth] = @DropPipeInvertDepth, [CappedLaterals] = @CappedLat" +
                "erals, [LineWithID] = @LineWithID, [HydrantAddress] = @HydrantAddress, [HydroWir" +
                "eWithin10FtOfInversionMH] = @HydroWireWithin10FtOfInversionMH, [DistanceToInvers" +
                "ionMH] = @DistanceToInversionMH, [SurfaceGrade] = @SurfaceGrade, [HydroPulley] =" +
                " @HydroPulley, [FridgeCart] = @FridgeCart, [TwoPump] = @TwoPump, [SixBypass] = @" +
                "SixBypass, [Scaffolding] = @Scaffolding, [WinchExtention] = @WinchExtention, [Ex" +
                "traGenerator] = @ExtraGenerator, [GreyCableExtension] = @GreyCableExtension, [Ea" +
                "sementMats] = @EasementMats, [RampRequired] = @RampRequired, [Deleted] = @Delete" +
                "d, [COMPANY_ID] = @COMPANY_ID, [CameraSkid] = @CameraSkid WHERE (([WorkID] = @Or" +
                "iginal_WorkID) AND ((@IsNull_VideoLength = 1 AND [VideoLength] IS NULL) OR ([Vid" +
                "eoLength] = @Original_VideoLength)) AND ((@IsNull_MeasurementTakenBy = 1 AND [Me" +
                "asurementTakenBy] IS NULL) OR ([MeasurementTakenBy] = @Original_MeasurementTaken" +
                "By)) AND ([DropPipe] = @Original_DropPipe) AND ((@IsNull_DropPipeInvertDepth = 1" +
                " AND [DropPipeInvertDepth] IS NULL) OR ([DropPipeInvertDepth] = @Original_DropPi" +
                "peInvertDepth)) AND ((@IsNull_CappedLaterals = 1 AND [CappedLaterals] IS NULL) O" +
                "R ([CappedLaterals] = @Original_CappedLaterals)) AND ((@IsNull_LineWithID = 1 AN" +
                "D [LineWithID] IS NULL) OR ([LineWithID] = @Original_LineWithID)) AND ((@IsNull_" +
                "HydrantAddress = 1 AND [HydrantAddress] IS NULL) OR ([HydrantAddress] = @Origina" +
                "l_HydrantAddress)) AND ((@IsNull_HydroWireWithin10FtOfInversionMH = 1 AND [Hydro" +
                "WireWithin10FtOfInversionMH] IS NULL) OR ([HydroWireWithin10FtOfInversionMH] = @" +
                "Original_HydroWireWithin10FtOfInversionMH)) AND ((@IsNull_DistanceToInversionMH " +
                "= 1 AND [DistanceToInversionMH] IS NULL) OR ([DistanceToInversionMH] = @Original" +
                "_DistanceToInversionMH)) AND ((@IsNull_SurfaceGrade = 1 AND [SurfaceGrade] IS NU" +
                "LL) OR ([SurfaceGrade] = @Original_SurfaceGrade)) AND ([HydroPulley] = @Original" +
                "_HydroPulley) AND ([FridgeCart] = @Original_FridgeCart) AND ([TwoPump] = @Origin" +
                "al_TwoPump) AND ([SixBypass] = @Original_SixBypass) AND ([Scaffolding] = @Origin" +
                "al_Scaffolding) AND ([WinchExtention] = @Original_WinchExtention) AND ([ExtraGen" +
                "erator] = @Original_ExtraGenerator) AND ([GreyCableExtension] = @Original_GreyCa" +
                "bleExtension) AND ([EasementMats] = @Original_EasementMats) AND ([RampRequired] " +
                "= @Original_RampRequired) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] " +
                "= @Original_COMPANY_ID) AND ([CameraSkid] = @Original_CameraSkid));\r\nSELECT Work" +
                "ID, VideoLength, MeasurementTakenBy, DropPipe, DropPipeInvertDepth, CappedLatera" +
                "ls, LineWithID, HydrantAddress, HydroWireWithin10FtOfInversionMH, DistanceToInve" +
                "rsionMH, SurfaceGrade, HydroPulley, FridgeCart, TwoPump, SixBypass, Scaffolding," +
                " WinchExtention, ExtraGenerator, GreyCableExtension, EasementMats, RampRequired," +
                " Deleted, COMPANY_ID, CameraSkid FROM LFS_WORK_FULLLENGTHLINING_M2 WHERE (WorkID" +
                " = @WorkID)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@WorkID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@VideoLength", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VideoLength", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MeasurementTakenBy", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MeasurementTakenBy", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DropPipe", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DropPipe", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DropPipeInvertDepth", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DropPipeInvertDepth", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CappedLaterals", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CappedLaterals", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LineWithID", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LineWithID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@HydrantAddress", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HydrantAddress", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@HydroWireWithin10FtOfInversionMH", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HydroWireWithin10FtOfInversionMH", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DistanceToInversionMH", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DistanceToInversionMH", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@SurfaceGrade", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SurfaceGrade", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@HydroPulley", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HydroPulley", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@FridgeCart", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FridgeCart", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TwoPump", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TwoPump", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@SixBypass", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SixBypass", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Scaffolding", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Scaffolding", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@WinchExtention", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WinchExtention", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ExtraGenerator", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ExtraGenerator", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@GreyCableExtension", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "GreyCableExtension", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@EasementMats", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EasementMats", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RampRequired", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RampRequired", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CameraSkid", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CameraSkid", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_WorkID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_VideoLength", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VideoLength", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_VideoLength", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VideoLength", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_MeasurementTakenBy", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MeasurementTakenBy", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MeasurementTakenBy", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MeasurementTakenBy", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DropPipe", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DropPipe", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DropPipeInvertDepth", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DropPipeInvertDepth", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DropPipeInvertDepth", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DropPipeInvertDepth", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_CappedLaterals", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CappedLaterals", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CappedLaterals", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CappedLaterals", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_LineWithID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LineWithID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LineWithID", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LineWithID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_HydrantAddress", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HydrantAddress", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_HydrantAddress", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HydrantAddress", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_HydroWireWithin10FtOfInversionMH", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HydroWireWithin10FtOfInversionMH", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_HydroWireWithin10FtOfInversionMH", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HydroWireWithin10FtOfInversionMH", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DistanceToInversionMH", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DistanceToInversionMH", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DistanceToInversionMH", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DistanceToInversionMH", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_SurfaceGrade", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SurfaceGrade", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_SurfaceGrade", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SurfaceGrade", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_HydroPulley", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HydroPulley", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_FridgeCart", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FridgeCart", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TwoPump", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TwoPump", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_SixBypass", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SixBypass", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Scaffolding", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Scaffolding", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_WinchExtention", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WinchExtention", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ExtraGenerator", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ExtraGenerator", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_GreyCableExtension", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "GreyCableExtension", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_EasementMats", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EasementMats", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RampRequired", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RampRequired", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CameraSkid", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CameraSkid", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// LoadByWorkId
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>data set</returns>
        public DataSet LoadByWorkId(int workId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_WORKFULLLENGTHLININGM2GATEWAY_LOADBYWORKID", new SqlParameter("@workId", workId), new SqlParameter("@companyId", companyId));
            return Data;
        }





        
        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROWS
        //

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="videoLength">videoLength</param>
        /// <param name="measurementTakenBy">measurementTakenBy</param>
        /// <param name="dropPipe">dropPipe</param>
        /// <param name="dropPipeInvertDepth">dropPipeInvertDepth</param>
        /// <param name="cappedLaterals">cappedLaterals</param>
        /// <param name="lineWithId">lineWithId</param> 
        /// <param name="hydrantAddress">hydrantAddress</param>
        /// <param name="hydroWireWithin10FtOfInversionMH">hydroWireWithin10FtOfInversionMH</param>
        /// <param name="distanceToInversionMh">distanceToInversionMh</param>
        /// <param name="surfaceGrade">surfaceGrade</param>
        /// <param name="hydroPulley">hydroPulley</param>
        /// <param name="fridgeCart">fridgeCart</param>
        /// <param name="twoPump">twoPump</param>
        /// <param name="sixBypass">sixBypass</param>
        /// <param name="scaffolding">scaffolding</param>
        /// <param name="WinchExtention">WinchExtention</param>
        /// <param name="extraGenerator">extraGenerator</param>
        /// <param name="greyCableExtension">greyCableExtension</param>
        /// <param name="easementMats">easementMats</param>
        /// <param name="rampRequired">rampRequired</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="cameraSkid">cameraSkid</param>
        /// <returns>rowsAffected</returns>
        public int Insert(int workId, string videoLength, string measurementTakenBy, bool dropPipe, string dropPipeInvertDepth, int? cappedLaterals, string lineWithId, string hydrantAddress, string hydroWireWithin10FtOfInversionMH, string distanceToInversionMh, string surfaceGrade, bool hydroPulley, bool fridgeCart, bool twoPump, bool sixBypass, bool scaffolding, bool winchExtention, bool extraGenerator, bool greyCableExtension, bool easementMats, bool rampRequired, bool deleted, int companyId, bool cameraSkid)
        {
            SqlParameter workIdParameter = new SqlParameter("WorkID", workId);
            SqlParameter videoLenghtParameter = (videoLength.Trim() != "") ? new SqlParameter("VideoLength", videoLength.Trim()) : new SqlParameter("VideoLength", DBNull.Value);
            SqlParameter measurementTakenByParameter = (measurementTakenBy.Trim() != "") ? new SqlParameter("MeasurementTakenBy", measurementTakenBy.Trim()) : new SqlParameter("MeasurementTakenBy", DBNull.Value);
            SqlParameter dropPipeParameter = new SqlParameter("DropPipe", dropPipe);
            SqlParameter dropPipeInvertDepthParameter = (dropPipeInvertDepth.Trim() != "") ? new SqlParameter("DropPipeInvertDepth", dropPipeInvertDepth.Trim()) : new SqlParameter("DropPipeInvertDepth", DBNull.Value);
            SqlParameter cappedLateralsParameter = (cappedLaterals.HasValue) ? new SqlParameter("CappedLaterals", cappedLaterals) : new SqlParameter("CappedLaterals", DBNull.Value);
            SqlParameter lineWithIdParameter = (lineWithId.Trim() != "") ? new SqlParameter("LineWithID", lineWithId.Trim()) : new SqlParameter("LineWithID", DBNull.Value);
            SqlParameter hydrantAddressParameter = (hydrantAddress.Trim() != "") ? new SqlParameter("HydrantAddress", hydrantAddress.Trim()) : new SqlParameter("HydrantAddress", DBNull.Value);
            SqlParameter hydroWireWithin10FtOfInversionMHParameter = (hydroWireWithin10FtOfInversionMH.Trim() != "") ? new SqlParameter("HydroWireWithin10FtOfInversionMH", hydroWireWithin10FtOfInversionMH.Trim()) : new SqlParameter("HydroWireWithin10FtOfInversionMH", DBNull.Value);
            SqlParameter distanceToInversionMhParameter = (distanceToInversionMh.Trim() != "") ? new SqlParameter("DistanceToInversionMH", distanceToInversionMh.Trim()) : new SqlParameter("DistanceToInversionMH", DBNull.Value);
            SqlParameter surfaceGradeParameter = (surfaceGrade.Trim() != "") ? new SqlParameter("SurfaceGrade", surfaceGrade.Trim()) : new SqlParameter("SurfaceGrade", DBNull.Value);
            SqlParameter hydroPulleyParameter = new SqlParameter("HydroPulley", hydroPulley);
            SqlParameter fridgeCartParameter = new SqlParameter("FridgeCart", fridgeCart);
            SqlParameter twoPumpParameter = new SqlParameter("TwoPump", twoPump);
            SqlParameter sixBypassParameter = new SqlParameter("SixBypass", sixBypass);
            SqlParameter scaffoldingParameter = new SqlParameter("Scaffolding", scaffolding);
            SqlParameter winchExtentionParameter = new SqlParameter("WinchExtention", winchExtention);
            SqlParameter extraGeneratorParameter = new SqlParameter("ExtraGenerator", extraGenerator);
            SqlParameter greyCableExtensionParameter = new SqlParameter("GreyCableExtension", greyCableExtension);
            SqlParameter easementMatsParameter = new SqlParameter("EasementMats", easementMats);
            SqlParameter rampRequiredParameter = new SqlParameter("RampRequired", rampRequired);
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            SqlParameter cameraSkidParameter = new SqlParameter("CameraSkid", cameraSkid);

            string command = "INSERT INTO [dbo].[LFS_WORK_FULLLENGTHLINING_M2] ([WorkID], [VideoLength], [MeasurementTakenBy], [DropPipe], [DropPipeInvertDepth], [CappedLaterals], [LineWithID], [HydrantAddress], [HydroWireWithin10FtOfInversionMH], [DistanceToInversionMH], [SurfaceGrade], [HydroPulley], [FridgeCart], [TwoPump], [SixBypass], [Scaffolding], [WinchExtention], [ExtraGenerator], [GreyCableExtension], [EasementMats], [RampRequired], [Deleted], [COMPANY_ID], [CameraSkid]) VALUES (@WorkID, @VideoLength, @MeasurementTakenBy, @DropPipe, @DropPipeInvertDepth, @CappedLaterals, @LineWithID, @HydrantAddress, @HydroWireWithin10FtOfInversionMH, @DistanceToInversionMH, @SurfaceGrade, @HydroPulley, @FridgeCart, @TwoPump, @SixBypass, @Scaffolding, @WinchExtention, @ExtraGenerator, @GreyCableExtension, @EasementMats, @RampRequired, @Deleted, @COMPANY_ID, @CameraSkid)";

            int rowsAffected = (int)ExecuteNonQuery(command, workIdParameter, videoLenghtParameter, measurementTakenByParameter, dropPipeParameter, dropPipeInvertDepthParameter, cappedLateralsParameter, lineWithIdParameter, hydrantAddressParameter, hydroWireWithin10FtOfInversionMHParameter, distanceToInversionMhParameter, surfaceGradeParameter, hydroPulleyParameter, fridgeCartParameter, twoPumpParameter, sixBypassParameter, scaffoldingParameter, winchExtentionParameter, extraGeneratorParameter, greyCableExtensionParameter, easementMatsParameter, rampRequiredParameter, deletedParameter, companyIdParameter, cameraSkidParameter);

            return rowsAffected;
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="originalWorkId">originalWorkId</param>
        /// <param name="originalVideoLength">originalVideoLength</param>
        /// <param name="originalMeasurementTakenBy">originalMeasurementTakenBy</param>
        /// <param name="originalDropPipe">originalDropPipe</param>
        /// <param name="originalDropPipeInvertDepth">originalDropPipeInvertDepth</param>
        /// <param name="originalCappedLaterals">originalCappedLaterals</param>
        /// <param name="originalLineWidthId">originalLineWidthId</param>
        /// <param name="originalHydrantAddress">originalHydrantAddress</param> 
        /// <param name="originalHydroWireWithin10FtOfInversionMH">originalHydroWireWithin10FtOfInversionMH</param>
        /// <param name="originalDistanceToInversionMH">originalDistanceToInversionMH</param>
        /// <param name="originalSurfaceGrade">originalSurfaceGrade</param>
        /// <param name="originalHydroPulley">originalHydroPulley</param> 
        /// <param name="originalFridgeCart">originalFridgeCart</param> 
        /// <param name="originalTwoPump">originalTwoPump</param> 
        /// <param name="originalSixBypass">originalSixBypass</param> 
        /// <param name="originalScaffolding">originalScaffolding</param> 
        /// <param name="originalWinchExtension">originalWinchExtension</param> 
        /// <param name="originalExtraGenerator">originalExtraGenerator</param> 
        /// <param name="originalGreyCableExtension">originalGreyCableExtension</param> 
        /// <param name="originalEasementMats">originalEasementMats</param> 
        /// <param name="originalRampsRequired">originalRampsRequired</param>  
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalCameraSkid">originalCameraSkid</param>
        /// 
        /// <param name="newWorkId">newWorkId</param>
        /// <param name="newVideoLength">newVideoLength</param>
        /// <param name="newMeasurementTakenBy">newMeasurementTakenBy</param>
        /// <param name="newDropPipe">newDropPipe</param>
        /// <param name="newDropPipeInvertDepth">newDropPipeInvertDepth</param>
        /// <param name="newCappedLaterals">newCappedLaterals</param>
        /// <param name="newLineWidthId">newLineWidthId</param>
        /// <param name="newHydrantAddress">newHydrantAddress</param> 
        /// <param name="newHydroWireWithin10FtOfInversionMH">newHydroWireWithin10FtOfInversionMH</param>
        /// <param name="newDistanceToInversionMH">newDistanceToInversionMH</param>
        /// <param name="newSurfaceGrade">newSurfaceGrade</param>
        /// <param name="newHydroPulley">newHydroPulley</param> 
        /// <param name="newFridgeCart">newFridgeCart</param> 
        /// <param name="newTwoPump">newTwoPump</param> 
        /// <param name="newSixBypass">newSixBypass</param> 
        /// <param name="newScaffolding">newScaffolding</param> 
        /// <param name="newWinchExtension">newWinchExtension</param> 
        /// <param name="newExtraGenerator">newExtraGenerator</param> 
        /// <param name="newGreyCableExtension">newGreyCableExtension</param> 
        /// <param name="newEasementMats">newEasementMats</param> 
        /// <param name="newRampsRequired">newRampsRequired</param>     
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newCameraSkid">newCameraSkid</param>
        /// <returns>rowsAffected</returns>
        public int Update(int originalWorkId, string originalVideoLength, string originalMeasurementTakenBy, bool originalDropPipe, string originalDropPipeInvertDepth, int? originalCappedLaterals, string originalLineWidthId, string originalHydrantAddress, string originalHydroWireWithin10FtOfInversionMH, string originalDistanceToInversionMH, string originalSurfaceGrade, bool originalHydroPulley, bool originalFridgeCart, bool originalTwoPump, bool originalSixBypass, bool originalScaffolding, bool originalWinchExtension, bool originalExtraGenerator, bool originalGreyCableExtension, bool originalEasementMats, bool originalRampsRequired, bool originalDeleted, int originalCompanyId, bool originalCameraSkid, int newWorkId, string newVideoLength, string newMeasurementTakenBy, bool newDropPipe, string newDropPipeInvertDepth, int? newCappedLaterals, string newLineWidthId, string newHydrantAddress, string newHydroWireWithin10FtOfInversionMH, string newDistanceToInversionMH, string newSurfaceGrade, bool newHydroPulley, bool newFridgeCart, bool newTwoPump, bool newSixBypass, bool newScaffolding, bool newWinchExtension, bool newExtraGenerator, bool newGreyCableExtension, bool newEasementMats, bool newRampsRequired, bool newDeleted, int newCompanyId, bool newCameraSkid)
        {       
            SqlParameter originalWorkIdParameter = new SqlParameter("Original_WorkID", originalWorkId);
            SqlParameter originalVideoLengthParameter = (originalVideoLength.Trim() != "") ? new SqlParameter("Original_VideoLenght", originalVideoLength.Trim()) : new SqlParameter("Original_VideoLength", DBNull.Value);            
            SqlParameter originalMeasurementTakenByParameter = (originalMeasurementTakenBy.Trim() != "") ? new SqlParameter("Original_MeasurementTakenBY", originalMeasurementTakenBy.Trim()) : new SqlParameter("Original_MeasurementTakenBy", DBNull.Value);
            SqlParameter originalDropPipeParameter = new SqlParameter("Original_DropPipe", originalDropPipe);
            SqlParameter originalDropPipeInvertDepthParameter = (originalDropPipeInvertDepth.Trim() != "") ? new SqlParameter("Original_DropPipeInvertDepth", originalDropPipeInvertDepth.Trim()) : new SqlParameter("Original_DropPipeInvertDepth", DBNull.Value);
            SqlParameter originalCappedLateralsParameter = (originalCappedLaterals.HasValue) ? new SqlParameter("Original_CappedLaterals", originalCappedLaterals) : new SqlParameter("Original_CappedLaterals", DBNull.Value);
            SqlParameter originalLineWidthIdParameter = (originalLineWidthId != "") ? new SqlParameter("Original_LineWithID", originalLineWidthId) : new SqlParameter("Original_LineWithID", DBNull.Value);
            SqlParameter originalHydrantAddressParameter = (originalHydrantAddress != "") ? new SqlParameter("Original_HydrantAddress", originalHydrantAddress) : new SqlParameter("Original_HydrantAddress", DBNull.Value);
            SqlParameter originalHydroWireWithin10FtOfInversionMHParameter = (originalHydroWireWithin10FtOfInversionMH != "") ? new SqlParameter("Original_HydroWireWithin10FtOfInversionMH", originalHydroWireWithin10FtOfInversionMH) : new SqlParameter("Original_HydroWireWithin10FtOfInversionMH", DBNull.Value);
            SqlParameter originalDistanceToInversionMHParameter = (originalDistanceToInversionMH != "") ? new SqlParameter("Original_DistanceToInversionMH", originalDistanceToInversionMH) : new SqlParameter("Original_DistanceToInversionMH", DBNull.Value);
            SqlParameter originalSurfaceGradeParameter = (originalSurfaceGrade != "") ? new SqlParameter("Original_SurfaceGrade", originalSurfaceGrade) : new SqlParameter("Original_SurfaceGrade", DBNull.Value);
            SqlParameter originalHydroPulleyParameter = new SqlParameter("Original_HydroPulley", originalHydroPulley);
            SqlParameter originalFridgeCartParameter = new SqlParameter("Original_FridgeCart", originalFridgeCart);
            SqlParameter originalTwoPumpParameter = new SqlParameter("Original_TwoPump", originalTwoPump);
            SqlParameter originalSixBypassParameter = new SqlParameter("Original_SixBypass", newSixBypass);
            SqlParameter originalScaffoldingParameter = new SqlParameter("Original_Scaffolding", originalScaffolding);
            SqlParameter originalWinchExtensionParameter = new SqlParameter("Original_WinchExtention", originalWinchExtension);
            SqlParameter originalExtraGeneratorParameter = new SqlParameter("Original_ExtraGenerator", originalExtraGenerator);
            SqlParameter originalGreyCableExtensionParameter = new SqlParameter("Original_GreyCableExtension", originalGreyCableExtension);
            SqlParameter originalEasementMatsParameter = new SqlParameter("Original_EasementMats", originalEasementMats);
            SqlParameter originalRampsRequiredParameter = new SqlParameter("Original_RampRequired", originalRampsRequired);
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter originalCameraSkidParameter = new SqlParameter("Original_CameraSkid", originalCameraSkid);
                    
            SqlParameter newWorkIdParameter = new SqlParameter("WorkID", newWorkId);
            SqlParameter newVideoLengthParameter = (newVideoLength.Trim() != "") ? new SqlParameter("VideoLength", newVideoLength.Trim()) : new SqlParameter("VideoLength", DBNull.Value);            
            SqlParameter newMeasurementTakenByParameter = (newMeasurementTakenBy.Trim() != "") ? new SqlParameter("MeasurementTakenBY", newMeasurementTakenBy.Trim()) : new SqlParameter("MeasurementTakenBy", DBNull.Value);
            SqlParameter newDropPipeParameter = new SqlParameter("DropPipe", newDropPipe);
            SqlParameter newDropPipeInvertDepthParameter = (newDropPipeInvertDepth.Trim() != "") ? new SqlParameter("DropPipeInvertDepth", newDropPipeInvertDepth.Trim()) : new SqlParameter("DropPipeInvertDepth", DBNull.Value);
            SqlParameter newCappedLateralsParameter = (newCappedLaterals.HasValue) ? new SqlParameter("CappedLaterals", newCappedLaterals) : new SqlParameter("CappedLaterals", DBNull.Value);
            SqlParameter newLineWidthIdParameter = (newLineWidthId != "") ? new SqlParameter("LineWithID", newLineWidthId) : new SqlParameter("LineWithID", DBNull.Value);
            SqlParameter newHydrantAddressParameter = (newHydrantAddress != "") ? new SqlParameter("HydrantAddress", newHydrantAddress) : new SqlParameter("HydrantAddress", DBNull.Value);
            SqlParameter newHydroWireWithin10FtOfInversionMHParameter = (newHydroWireWithin10FtOfInversionMH != "") ? new SqlParameter("HydroWireWithin10FtOfInversionMH", newHydroWireWithin10FtOfInversionMH) : new SqlParameter("HydroWireWithin10FtOfInversionMH", DBNull.Value);
            SqlParameter newDistanceToInversionMHParameter = (newDistanceToInversionMH != "") ? new SqlParameter("DistanceToInversionMH", newDistanceToInversionMH) : new SqlParameter("DistanceToInversionMH", DBNull.Value);
            SqlParameter newSurfaceGradeParameter = (newSurfaceGrade != "") ? new SqlParameter("SurfaceGrade", newSurfaceGrade) : new SqlParameter("SurfaceGrade", DBNull.Value);
            SqlParameter newHydroPulleyParameter = new SqlParameter("HydroPulley", newHydroPulley);
            SqlParameter newFridgeCartParameter = new SqlParameter("FridgeCart", newFridgeCart);
            SqlParameter newTwoPumpParameter = new SqlParameter("TwoPump", newTwoPump);
            SqlParameter newSixBypassParameter = new SqlParameter("SixBypass", newSixBypass);
            SqlParameter newScaffoldingParameter = new SqlParameter("Scaffolding", newScaffolding);
            SqlParameter newWinchExtensionParameter = new SqlParameter("WinchExtention", newWinchExtension);
            SqlParameter newExtraGeneratorParameter = new SqlParameter("ExtraGenerator", newExtraGenerator);
            SqlParameter newGreyCableExtensionParameter = new SqlParameter("GreyCableExtension", newGreyCableExtension);
            SqlParameter newEasementMatsParameter = new SqlParameter("EasementMats", newEasementMats);
            SqlParameter newRampsRequiredParameter = new SqlParameter("RampRequired", newRampsRequired);
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);
            SqlParameter newCameraSkidParameter = new SqlParameter("CameraSkid", newCameraSkid);

            string command = "UPDATE [dbo].[LFS_WORK_FULLLENGTHLINING_M2] SET "+
                "[VideoLength] = @VideoLength, [MeasurementTakenBy] = @MeasurementTakenBy, [DropPipe] = @D" +
                "ropPipe, [DropPipeInvertDepth] = @DropPipeInvertDepth, [CappedLaterals] = @Cappe" +
                "dLaterals, [LineWithID] = @LineWithID, [HydrantAddress] = @HydrantAddress, [Hydr" +
                "oWireWithin10FtOfInversionMH] = @HydroWireWithin10FtOfInversionMH, [DistanceToIn" +
                "versionMH] = @DistanceToInversionMH, [SurfaceGrade] = @SurfaceGrade, [HydroPulle" +
                "y] = @HydroPulley, [FridgeCart] = @FridgeCart, [TwoPump] = @TwoPump, [SixBypass]" +
                " = @SixBypass, [Scaffolding] = @Scaffolding, [WinchExtention] = @WinchExtention," +
                " [ExtraGenerator] = @ExtraGenerator, [GreyCableExtension] = @GreyCableExtension," +
                " [EasementMats] = @EasementMats, [RampRequired] = @RampRequired, [CameraSkid] = @CameraSkid" +
                " WHERE (([WorkID] = @Original_WorkID) AND ([Deleted] = @Original_Deleted) AND (" +
                "[COMPANY_ID] = @Original_COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalWorkIdParameter, originalVideoLengthParameter, originalMeasurementTakenByParameter, originalDropPipeParameter, originalDropPipeInvertDepthParameter, originalCappedLateralsParameter, originalLineWidthIdParameter, originalHydrantAddressParameter, originalHydroWireWithin10FtOfInversionMHParameter, originalDistanceToInversionMHParameter, originalSurfaceGradeParameter, originalHydroPulleyParameter,  originalFridgeCartParameter, originalTwoPumpParameter,  originalSixBypassParameter, originalScaffoldingParameter, originalWinchExtensionParameter, originalExtraGeneratorParameter, originalEasementMatsParameter, originalRampsRequiredParameter, originalDeletedParameter,  originalCompanyIdParameter, originalCameraSkidParameter, newWorkIdParameter, newVideoLengthParameter, newMeasurementTakenByParameter, newDropPipeParameter, newDropPipeInvertDepthParameter, newCappedLateralsParameter, newLineWidthIdParameter, newHydrantAddressParameter, newHydroWireWithin10FtOfInversionMHParameter, newDistanceToInversionMHParameter,  newSurfaceGradeParameter, newHydroPulleyParameter, newFridgeCartParameter, newTwoPumpParameter, newSixBypassParameter, newScaffoldingParameter, newWinchExtensionParameter, newExtraGeneratorParameter, newGreyCableExtensionParameter, newEasementMatsParameter, newRampsRequiredParameter, newDeletedParameter, newCompanyIdParameter, newCameraSkidParameter);

            return rowsAffected;
        }



        /// <summary>
        /// UpdateVideoLength
        /// </summary>
        /// <param name="originalWorkId">originalWorkId</param>
        /// <param name="originalVideoLength">originalVideoLength</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// 
        /// <param name="newWorkId">newWorkId</param>
        /// <param name="newVideoLength">newVideoLength</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <returns>rowsAffected</returns>
        public int UpdateVideoLength(int originalWorkId, string originalVideoLength, bool originalDeleted, int originalCompanyId, int newWorkId, string newVideoLength, bool newDeleted, int newCompanyId)
        {
            SqlParameter originalWorkIdParameter = new SqlParameter("Original_WorkID", originalWorkId);
            SqlParameter originalVideoLengthParameter = (originalVideoLength.Trim() != "") ? new SqlParameter("Original_VideoLenght", originalVideoLength.Trim()) : new SqlParameter("Original_VideoLength", DBNull.Value);
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);

            SqlParameter newWorkIdParameter = new SqlParameter("WorkID", newWorkId);
            SqlParameter newVideoLengthParameter = (newVideoLength.Trim() != "") ? new SqlParameter("VideoLength", newVideoLength.Trim()) : new SqlParameter("VideoLength", DBNull.Value);
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);

            string command = "UPDATE [dbo].[LFS_WORK_FULLLENGTHLINING_M2] SET " +
                "[VideoLength] = @VideoLength " +
                " WHERE (([WorkID] = @Original_WorkID) AND ([Deleted] = @Original_Deleted) AND (" +
                "[COMPANY_ID] = @Original_COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalWorkIdParameter, originalVideoLengthParameter, originalDeletedParameter, originalCompanyIdParameter, newWorkIdParameter, newVideoLengthParameter, newDeletedParameter, newCompanyIdParameter);

            return rowsAffected;
        }



        /// <summary>
        /// Delete a work (direct to DB)
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <returns>int</returns>
        public int Delete(int originalWorkId, int originalCompanyId)
        {
            SqlParameter originalWorkIdParameter = new SqlParameter("@Original_WorkID", originalWorkId);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_WORK_FULLLENGTHLINING_M2] SET  [Deleted] = @Deleted  " +
                             " WHERE (([WorkID] = @Original_WorkID) AND " +
                             "  ([COMPANY_ID] = @Original_COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalWorkIdParameter, originalCompanyIdParameter, deletedParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }


        
    }
}
