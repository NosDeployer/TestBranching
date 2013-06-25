using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.Works
{
    /// <summary>
    /// WorkFullLengthLiningM1LateralGateway
    /// </summary>
    public class WorkFullLengthLiningM1LateralGateway : DataTableGateway
    {
        ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkFullLengthLiningM1LateralGateway() : base("LFS_WORK_FULLLENGTHLINING_M1_LATERAL")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkFullLengthLiningM1LateralGateway(DataSet data)
            : base(data, "LFS_WORK_FULLLENGTHLINING_M1_LATERAL")
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
            tableMapping.DataSetTable = "LFS_WORK_FULLLENGTHLINING_M1_LATERAL";
            tableMapping.ColumnMappings.Add("WorkID", "WorkID");
            tableMapping.ColumnMappings.Add("Lateral", "Lateral");
            tableMapping.ColumnMappings.Add("VideoDistance", "VideoDistance");
            tableMapping.ColumnMappings.Add("ClockPosition", "ClockPosition");
            tableMapping.ColumnMappings.Add("DistanceToCentre", "DistanceToCentre");
            tableMapping.ColumnMappings.Add("TimeOpened", "TimeOpened");
            tableMapping.ColumnMappings.Add("ReverseSetup", "ReverseSetup");
            tableMapping.ColumnMappings.Add("Reinstate", "Reinstate");
            tableMapping.ColumnMappings.Add("Comments", "Comments");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("ClientInspectionNo", "ClientInspectionNo");
            tableMapping.ColumnMappings.Add("V1Inspection", "V1Inspection");
            tableMapping.ColumnMappings.Add("RequiresRoboticPrep", "RequiresRoboticPrep");
            tableMapping.ColumnMappings.Add("RequiresRoboticPrepDate", "RequiresRoboticPrepDate");
            tableMapping.ColumnMappings.Add("HoldClientIssue", "HoldClientIssue");
            tableMapping.ColumnMappings.Add("HoldLFSIssue", "HoldLFSIssue");
            tableMapping.ColumnMappings.Add("LineLateral", "LineLateral");
            tableMapping.ColumnMappings.Add("DyeTestReq", "DyeTestReq");
            tableMapping.ColumnMappings.Add("DyeTestComplete", "DyeTestComplete");
            tableMapping.ColumnMappings.Add("ContractYear", "ContractYear");

            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[LFS_WORK_FULLLENGTHLINING_M1_LATERAL] WHERE (([WorkID] = @Orig" +
                "inal_WorkID) AND ([Lateral] = @Original_Lateral) AND ((@IsNull_VideoDistance = 1" +
                " AND [VideoDistance] IS NULL) OR ([VideoDistance] = @Original_VideoDistance)) AN" +
                "D ((@IsNull_ClockPosition = 1 AND [ClockPosition] IS NULL) OR ([ClockPosition] =" +
                " @Original_ClockPosition)) AND ((@IsNull_DistanceToCentre = 1 AND [DistanceToCen" +
                "tre] IS NULL) OR ([DistanceToCentre] = @Original_DistanceToCentre)) AND ((@IsNul" +
                "l_TimeOpened = 1 AND [TimeOpened] IS NULL) OR ([TimeOpened] = @Original_TimeOpen" +
                "ed)) AND ((@IsNull_ReverseSetup = 1 AND [ReverseSetup] IS NULL) OR ([ReverseSetu" +
                "p] = @Original_ReverseSetup)) AND ((@IsNull_Reinstate = 1 AND [Reinstate] IS NUL" +
                "L) OR ([Reinstate] = @Original_Reinstate)) AND ([Deleted] = @Original_Deleted) A" +
                "ND ([COMPANY_ID] = @Original_COMPANY_ID) AND ((@IsNull_ClientInspectionNo = 1 AN" +
                "D [ClientInspectionNo] IS NULL) OR ([ClientInspectionNo] = @Original_ClientInspe" +
                "ctionNo)) AND ((@IsNull_V1Inspection = 1 AND [V1Inspection] IS NULL) OR ([V1Insp" +
                "ection] = @Original_V1Inspection)) AND ([RequiresRoboticPrep] = @Original_Requir" +
                "esRoboticPrep) AND ((@IsNull_RequiresRoboticPrepDate = 1 AND [RequiresRoboticPre" +
                "pDate] IS NULL) OR ([RequiresRoboticPrepDate] = @Original_RequiresRoboticPrepDat" +
                "e)) AND ([HoldClientIssue] = @Original_HoldClientIssue) AND ([HoldLFSIssue] = @O" +
                "riginal_HoldLFSIssue) AND ([LineLateral] = @Original_LineLateral) AND ([DyeTestR" +
                "eq] = @Original_DyeTestReq) AND ((@IsNull_DyeTestComplete = 1 AND [DyeTestComple" +
                "te] IS NULL) OR ([DyeTestComplete] = @Original_DyeTestComplete)) AND ((@IsNull_C" +
                "ontractYear = 1 AND [ContractYear] IS NULL) OR ([ContractYear] = @Original_Contr" +
                "actYear)))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_WorkID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Lateral", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Lateral", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_VideoDistance", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VideoDistance", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_VideoDistance", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VideoDistance", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_ClockPosition", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ClockPosition", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ClockPosition", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ClockPosition", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DistanceToCentre", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DistanceToCentre", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DistanceToCentre", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DistanceToCentre", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_TimeOpened", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TimeOpened", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TimeOpened", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TimeOpened", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_ReverseSetup", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ReverseSetup", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ReverseSetup", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ReverseSetup", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Reinstate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Reinstate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Reinstate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Reinstate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_ClientInspectionNo", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ClientInspectionNo", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ClientInspectionNo", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ClientInspectionNo", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_V1Inspection", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "V1Inspection", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_V1Inspection", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "V1Inspection", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RequiresRoboticPrep", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RequiresRoboticPrep", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_RequiresRoboticPrepDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RequiresRoboticPrepDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RequiresRoboticPrepDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RequiresRoboticPrepDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_HoldClientIssue", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HoldClientIssue", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_HoldLFSIssue", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HoldLFSIssue", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LineLateral", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LineLateral", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DyeTestReq", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DyeTestReq", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DyeTestComplete", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DyeTestComplete", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DyeTestComplete", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DyeTestComplete", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_ContractYear", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ContractYear", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ContractYear", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ContractYear", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_WORK_FULLLENGTHLINING_M1_LATERAL] ([WorkID], [Lateral], [VideoDistance], [ClockPosition], [DistanceToCentre], [TimeOpened], [ReverseSetup], [Reinstate], [Comments], [Deleted], [COMPANY_ID], [ClientInspectionNo], [V1Inspection], [RequiresRoboticPrep], [RequiresRoboticPrepDate], [HoldClientIssue], [HoldLFSIssue], [LineLateral], [DyeTestReq], [DyeTestComplete], [ContractYear]) VALUES (@WorkID, @Lateral, @VideoDistance, @ClockPosition, @DistanceToCentre, @TimeOpened, @ReverseSetup, @Reinstate, @Comments, @Deleted, @COMPANY_ID, @ClientInspectionNo, @V1Inspection, @RequiresRoboticPrep, @RequiresRoboticPrepDate, @HoldClientIssue, @HoldLFSIssue, @LineLateral, @DyeTestReq, @DyeTestComplete, @ContractYear);
SELECT WorkID, Lateral, VideoDistance, ClockPosition, DistanceToCentre, TimeOpened, ReverseSetup, Reinstate, Comments, Deleted, COMPANY_ID, ClientInspectionNo, V1Inspection, RequiresRoboticPrep, RequiresRoboticPrepDate, HoldClientIssue, HoldLFSIssue, LineLateral, DyeTestReq, DyeTestComplete, ContractYear FROM LFS_WORK_FULLLENGTHLINING_M1_LATERAL WHERE (Lateral = @Lateral) AND (WorkID = @WorkID)";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@WorkID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Lateral", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Lateral", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@VideoDistance", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VideoDistance", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ClockPosition", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ClockPosition", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DistanceToCentre", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DistanceToCentre", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TimeOpened", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TimeOpened", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ReverseSetup", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ReverseSetup", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Reinstate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Reinstate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Comments", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Comments", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ClientInspectionNo", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ClientInspectionNo", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@V1Inspection", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "V1Inspection", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RequiresRoboticPrep", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RequiresRoboticPrep", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RequiresRoboticPrepDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RequiresRoboticPrepDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@HoldClientIssue", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HoldClientIssue", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@HoldLFSIssue", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HoldLFSIssue", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LineLateral", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LineLateral", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DyeTestReq", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DyeTestReq", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DyeTestComplete", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DyeTestComplete", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ContractYear", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ContractYear", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));

            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[LFS_WORK_FULLLENGTHLINING_M1_LATERAL] SET [WorkID] = @WorkID, [Late" +
                "ral] = @Lateral, [VideoDistance] = @VideoDistance, [ClockPosition] = @ClockPosit" +
                "ion, [DistanceToCentre] = @DistanceToCentre, [TimeOpened] = @TimeOpened, [Revers" +
                "eSetup] = @ReverseSetup, [Reinstate] = @Reinstate, [Comments] = @Comments, [Dele" +
                "ted] = @Deleted, [COMPANY_ID] = @COMPANY_ID, [ClientInspectionNo] = @ClientInspe" +
                "ctionNo, [V1Inspection] = @V1Inspection, [RequiresRoboticPrep] = @RequiresRoboti" +
                "cPrep, [RequiresRoboticPrepDate] = @RequiresRoboticPrepDate, [HoldClientIssue] =" +
                " @HoldClientIssue, [HoldLFSIssue] = @HoldLFSIssue, [LineLateral] = @LineLateral," +
                " [DyeTestReq] = @DyeTestReq, [DyeTestComplete] = @DyeTestComplete, [ContractYear" +
                "] = @ContractYear WHERE (([WorkID] = @Original_WorkID) AND ([Lateral] = @Origina" +
                "l_Lateral) AND ((@IsNull_VideoDistance = 1 AND [VideoDistance] IS NULL) OR ([Vid" +
                "eoDistance] = @Original_VideoDistance)) AND ((@IsNull_ClockPosition = 1 AND [Clo" +
                "ckPosition] IS NULL) OR ([ClockPosition] = @Original_ClockPosition)) AND ((@IsNu" +
                "ll_DistanceToCentre = 1 AND [DistanceToCentre] IS NULL) OR ([DistanceToCentre] =" +
                " @Original_DistanceToCentre)) AND ((@IsNull_TimeOpened = 1 AND [TimeOpened] IS N" +
                "ULL) OR ([TimeOpened] = @Original_TimeOpened)) AND ((@IsNull_ReverseSetup = 1 AN" +
                "D [ReverseSetup] IS NULL) OR ([ReverseSetup] = @Original_ReverseSetup)) AND ((@I" +
                "sNull_Reinstate = 1 AND [Reinstate] IS NULL) OR ([Reinstate] = @Original_Reinsta" +
                "te)) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_I" +
                "D) AND ((@IsNull_ClientInspectionNo = 1 AND [ClientInspectionNo] IS NULL) OR ([C" +
                "lientInspectionNo] = @Original_ClientInspectionNo)) AND ((@IsNull_V1Inspection =" +
                " 1 AND [V1Inspection] IS NULL) OR ([V1Inspection] = @Original_V1Inspection)) AND" +
                " ([RequiresRoboticPrep] = @Original_RequiresRoboticPrep) AND ((@IsNull_RequiresR" +
                "oboticPrepDate = 1 AND [RequiresRoboticPrepDate] IS NULL) OR ([RequiresRoboticPr" +
                "epDate] = @Original_RequiresRoboticPrepDate)) AND ([HoldClientIssue] = @Original" +
                "_HoldClientIssue) AND ([HoldLFSIssue] = @Original_HoldLFSIssue) AND ([LineLatera" +
                "l] = @Original_LineLateral) AND ([DyeTestReq] = @Original_DyeTestReq) AND ((@IsN" +
                "ull_DyeTestComplete = 1 AND [DyeTestComplete] IS NULL) OR ([DyeTestComplete] = @" +
                "Original_DyeTestComplete)) AND ((@IsNull_ContractYear = 1 AND [ContractYear] IS " +
                "NULL) OR ([ContractYear] = @Original_ContractYear)));\r\nSELECT WorkID, Lateral, V" +
                "ideoDistance, ClockPosition, DistanceToCentre, TimeOpened, ReverseSetup, Reinsta" +
                "te, Comments, Deleted, COMPANY_ID, ClientInspectionNo, V1Inspection, RequiresRob" +
                "oticPrep, RequiresRoboticPrepDate, HoldClientIssue, HoldLFSIssue, LineLateral, D" +
                "yeTestReq, DyeTestComplete, ContractYear FROM LFS_WORK_FULLLENGTHLINING_M1_LATER" +
                "AL WHERE (Lateral = @Lateral) AND (WorkID = @WorkID)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@WorkID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Lateral", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Lateral", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@VideoDistance", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VideoDistance", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ClockPosition", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ClockPosition", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DistanceToCentre", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DistanceToCentre", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TimeOpened", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TimeOpened", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ReverseSetup", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ReverseSetup", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Reinstate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Reinstate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Comments", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Comments", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ClientInspectionNo", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ClientInspectionNo", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@V1Inspection", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "V1Inspection", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RequiresRoboticPrep", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RequiresRoboticPrep", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RequiresRoboticPrepDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RequiresRoboticPrepDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@HoldClientIssue", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HoldClientIssue", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@HoldLFSIssue", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HoldLFSIssue", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LineLateral", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LineLateral", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DyeTestReq", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DyeTestReq", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DyeTestComplete", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DyeTestComplete", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ContractYear", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ContractYear", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_WorkID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Lateral", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Lateral", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_VideoDistance", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VideoDistance", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_VideoDistance", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VideoDistance", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_ClockPosition", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ClockPosition", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ClockPosition", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ClockPosition", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DistanceToCentre", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DistanceToCentre", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DistanceToCentre", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DistanceToCentre", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_TimeOpened", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TimeOpened", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TimeOpened", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TimeOpened", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_ReverseSetup", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ReverseSetup", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ReverseSetup", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ReverseSetup", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Reinstate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Reinstate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Reinstate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Reinstate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_ClientInspectionNo", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ClientInspectionNo", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ClientInspectionNo", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ClientInspectionNo", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_V1Inspection", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "V1Inspection", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_V1Inspection", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "V1Inspection", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RequiresRoboticPrep", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RequiresRoboticPrep", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_RequiresRoboticPrepDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RequiresRoboticPrepDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RequiresRoboticPrepDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RequiresRoboticPrepDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_HoldClientIssue", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HoldClientIssue", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_HoldLFSIssue", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HoldLFSIssue", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LineLateral", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LineLateral", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DyeTestReq", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DyeTestReq", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DyeTestComplete", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DyeTestComplete", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DyeTestComplete", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DyeTestComplete", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_ContractYear", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ContractYear", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ContractYear", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ContractYear", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
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
            FillDataWithStoredProcedure("LFS_CWP_WORKFULLLENGTHLININGM1LATERALGATEWAY_LOADBYWORKID", new SqlParameter("@workId", workId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadAllByWorkIdLateral
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="lateral">lateral</param>
        /// <param name="companyId">companyId</param>
        /// <returns>data set</returns>
        public DataSet LoadAllByWorkIdLateral(int workId, int lateral, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_WORKFULLLENGTHLININGM1LATERALGATEWAY_LOADALLBYWORKIDLATERAL", new SqlParameter("@workId", workId), new SqlParameter("@lateral", lateral), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByWorkIdLateral
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="lateral">lateral</param>
        /// <param name="companyId">companyId</param>
        /// <returns>data set</returns>
        public DataSet LoadByWorkIdLateral(int workId, int lateral, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_WORKFULLLENGTHLININGM1LATERALGATEWAY_LOADBYWORKIDLATERAL", new SqlParameter("@workId", workId), new SqlParameter("@lateral", lateral), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="lateral">lateral</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int workId, int lateral)
        {
            string filter = string.Format("WorkID = {0} AND Lateral = {1}", workId, lateral);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.CWP.Common.WorkFullLengthLiningM1LateralGateway.GetRow");
            }
        }



        /// <summary>
        /// GetVideoDistance
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="lateral">lateral</param>
        /// <returns>VideoDistance or EMPTY</returns>
        public string GetVideoDistance(int workId, int lateral)
        {
            if (GetRow(workId, lateral).IsNull("VideoDistance"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId, lateral)["VideoDistance"];
            }
        }



        /// <summary>
        /// GetClockPosition. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="lateral">lateral</param>
        /// <returns>ClockPosition or EMPTY</returns>
        public string GetClockPosition(int workId, int lateral)
        {
            if (GetRow(workId, lateral).IsNull("ClockPosition"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId, lateral)["ClockPosition"];
            }
        }



        /// <summary>
        /// GetDistanceToCentre. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="lateral">lateral</param>
        /// <returns>DistanceToCentre or EMPTY</returns>
        public string GetDistanceToCentre(int workId, int lateral)
        {
            if (GetRow(workId, lateral).IsNull("DistanceToCentre"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId, lateral)["DistanceToCentre"];
            }
        }



        /// <summary>
        /// GetTimeOpened. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="lateral">lateral</param>
        /// <returns>TimeOpened or EMPTY</returns>
        public string GetTimeOpened(int workId, int lateral)
        {
            if (GetRow(workId, lateral).IsNull("TimeOpened"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId, lateral)["TimeOpened"];
            }
        }



        /// <summary>
        /// GetReverseSetup. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="lateral">lateral</param>
        /// <returns>ReverseSetup or EMPTY</returns>
        public string GetReverseSetup(int workId, int lateral)
        {
            if (GetRow(workId, lateral).IsNull("ReverseSetup"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId, lateral)["ReverseSetup"];
            }
        }



        /// <summary>
        /// GetClientInspectionNo. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="lateral">lateral</param>
        /// <returns>ClientInspectionNo or EMPTY</returns>
        public string GetClientInspectionNo(int workId, int lateral)
        {
            if (GetRow(workId, lateral).IsNull("ClientInspectionNo"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId, lateral)["ClientInspectionNo"];
            }
        }



        /// <summary>
        /// GetCompanyId. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="lateral">lateral</param>
        /// <returns>COMPANY_ID or EMPTY</returns>
        public int GetCompanyId(int workId, int lateral)
        {
            return (int)GetRow(workId, lateral)["COMPANY_ID"];            
        }



        /// <summary>
        /// GetDeleted. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="lateral">lateral</param>
        /// <returns>Deleted or EMPTY</returns>
        public bool GetDeleted(int workId, int lateral)
        {
            return (bool)GetRow(workId, lateral)["Deleted"];
        }



        /// <summary>
        /// GetReinstate. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="lateral">lateral</param>
        /// <returns>Reinstate or EMPTY</returns>
        public DateTime? GetReinstate(int workId, int lateral)
        {
            if (GetRow(workId, lateral).IsNull("Reinstate"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId, lateral)["Reinstate"];
            }
        }



        /// <summary>
        /// GetV1Inspection. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="lateral">lateral</param>
        /// <returns>V1Inspection or EMPTY</returns>
        public DateTime? GetV1Inspection(int workId, int lateral)
        {
            if (GetRow(workId, lateral).IsNull("V1Inspection"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId, lateral)["V1Inspection"];
            }
        }
        
        

        /// <summary>
        /// GetComments. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="lateral">lateral</param>
        /// <returns>Comments or EMPTY</returns>
        public string GetComments(int workId, int lateral)
        {
            if (GetRow(workId, lateral).IsNull("Comments"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId, lateral)["Comments"];
            }
        }



        /// <summary>
        /// GetRequiresRoboticPrep. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="lateral">lateral</param>
        /// <returns>RequiresRoboticPrep or EMPTY</returns>
        public bool GetRequiresRoboticPrep(int workId, int lateral)
        {
            return (bool)GetRow(workId, lateral)["RequiresRoboticPrep"];
        }



        /// <summary>
        /// GetRequiresRoboticPrepDate. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="lateral">lateral</param>
        /// <returns>RequiresRoboticPrepDate or EMPTY</returns>
        public DateTime? GetRequiresRoboticPrepDate(int workId, int lateral)
        {
            if (GetRow(workId, lateral).IsNull("RequiresRoboticPrepDate"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId, lateral)["RequiresRoboticPrepDate"];
            }
        }



        /// <summary>
        /// GetHoldClientIssue. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="lateral">lateral</param>
        /// <returns>HoldClientIssue or EMPTY</returns>
        public bool GetHoldClientIssue(int workId, int lateral)
        {
            return (bool)GetRow(workId, lateral)["HoldClientIssue"];
        }



        /// <summary>
        /// GetHoldLFSIssue. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="lateral">lateral</param>
        /// <returns>HoldLFSIssue or EMPTY</returns>
        public bool GetHoldLFSIssue(int workId, int lateral)
        {
            return (bool)GetRow(workId, lateral)["HoldLFSIssue"];
        }



        /// <summary>
        /// GetLineLateral. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="lateral">lateral</param>
        /// <returns>LineLateral or EMPTY</returns>
        public bool GetLineLateral(int workId, int lateral)
        {
            return (bool)GetRow(workId, lateral)["LineLateral"];
        }



        /// <summary>
        /// GetDyeTestReq. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="lateral">lateral</param>
        /// <returns>LineLateral or EMPTY</returns>
        public bool GetDyeTestReq(int workId, int lateral)
        {
            return (bool)GetRow(workId, lateral)["DyeTestReq"];
        }



        /// <summary>
        /// GetDyeTestComplete. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="lateral">lateral</param>
        /// <returns>DyeTestComplete or EMPTY</returns>
        public DateTime? GetDyeTestComplete(int workId, int lateral)
        {
            if (GetRow(workId, lateral).IsNull("DyeTestComplete"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId, lateral)["DyeTestComplete"];
            }
        }



        /// <summary>
        /// GetContractYear. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="lateral">lateral</param>
        /// <returns>ContractYear or EMPTY</returns>
        public string GetContractYear(int workId, int lateral)
        {
            if (GetRow(workId, lateral).IsNull("ContractYear"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId, lateral)["ContractYear"];
            }
        }
        


        

        
        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROWS
        //

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="lateral">lateral</param>
        /// <param name="videoDistance">videoDistance</param>
        /// <param name="clockPosition">clockPosition</param>
        /// <param name="distanceToCentre">distanceToCentre</param>
        /// <param name="timeOpened">timeOpened</param>
        /// <param name="reverseSetup">reverseSetup</param>
        /// <param name="reinstate">reinstate</param>
        /// <param name="comments">comments</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="clientInspectionNo">clientInspectionNo</param>
        /// <param name="v1Inspection">v1Inspection</param>
        /// <param name="requiresRoboticPrep">requiresRoboticPrep</param>
        /// <param name="requiresRoboticPrepDate">requiresRoboticPrepDate</param>
        /// <param name="holdClientIssue">holdClientIssue</param>
        /// <param name="holdLFSIssue">holdLFSIssue</param>
        /// <param name="lineLateral">lineLateral</param>
        /// <param name="dyeTestReq">dyeTestReq</param>
        /// <param name="dyeTestComplete">dyeTestComplete</param>
        /// <param name="contractYear">contractYear</param>
        /// <returns></returns>
        public int Insert(int workId, int lateral, string videoDistance, string clockPosition, string distanceToCentre, string timeOpened, string reverseSetup, DateTime? reinstate, string comments, bool deleted, int companyId, string clientInspectionNo, DateTime? v1Inspection, bool requiresRoboticPrep, DateTime? requiresRoboticPrepDate, bool holdClientIssue, bool holdLFSIssue, bool lineLateral, bool dyeTestReq, DateTime? dyeTestComplete, string contractYear)
        {
            SqlParameter workIdParameter = new SqlParameter("WorkID", workId);
            SqlParameter lateralParameter = new SqlParameter("Lateral", lateral);
            SqlParameter videoDistanceParameter = (videoDistance.Trim() != "") ? new SqlParameter("VideoDistance", videoDistance.Trim()) : new SqlParameter("VideoDistance", DBNull.Value);
            SqlParameter clockPositionParameter = (clockPosition.Trim() != "") ? new SqlParameter("ClockPosition", clockPosition.Trim()) : new SqlParameter("ClockPosition", DBNull.Value);
            SqlParameter distanceToCentreParameter = (distanceToCentre.Trim() != "") ? new SqlParameter("DistanceToCentre", distanceToCentre.Trim()) : new SqlParameter("DistanceToCentre", DBNull.Value);
            SqlParameter timeOpenedParameter = (timeOpened.Trim() != "") ? new SqlParameter("TimeOpened", timeOpened.Trim()) : new SqlParameter("TimeOpened", DBNull.Value);
            SqlParameter reverseSetupParameter = (reverseSetup.Trim() != "") ? new SqlParameter("ReverseSetup", reverseSetup.Trim()) : new SqlParameter("ReverseSetup", DBNull.Value);            
            SqlParameter reinstateParameter = (reinstate.HasValue) ? new SqlParameter("Reinstate", reinstate) : new SqlParameter("Reinstate", DBNull.Value);            
            SqlParameter commentsParameter = (comments.Trim() != "") ? new SqlParameter("Comments", comments.Trim()) : new SqlParameter("Comments", DBNull.Value);
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            SqlParameter clientInspectionNoParameter = (clientInspectionNo.Trim() != "") ? new SqlParameter("ClientInspectionNo", clientInspectionNo.Trim()) : new SqlParameter("ClientInspectionNo", DBNull.Value);
            SqlParameter v1InspectionParameter = (v1Inspection.HasValue) ? new SqlParameter("V1Inspection", v1Inspection) : new SqlParameter("V1Inspection", DBNull.Value);
            SqlParameter requiresRoboticPrepParameter = new SqlParameter("RequiresRoboticPrep", requiresRoboticPrep);
            SqlParameter requiresRoboticPrepDateParameter = (requiresRoboticPrepDate.HasValue) ? new SqlParameter("RequiresRoboticPrepDate", requiresRoboticPrepDate) : new SqlParameter("RequiresRoboticPrepDate", DBNull.Value);
            SqlParameter holdClientIssueParameter = new SqlParameter("HoldClientIssue", holdClientIssue);
            SqlParameter holdLFSIssueParameter = new SqlParameter("HoldLFSIssue", holdLFSIssue);
            SqlParameter lineLateralParameter = new SqlParameter("LineLateral", lineLateral);
            SqlParameter dyeTestReqParameter = new SqlParameter("DyeTestReq", dyeTestReq);
            SqlParameter dyeTestCompleteParameter = (dyeTestComplete.HasValue) ? new SqlParameter("DyeTestComplete", dyeTestComplete) : new SqlParameter("DyeTestComplete", DBNull.Value);
            SqlParameter contractYearParameter = (contractYear.Trim() != "") ? new SqlParameter("ContractYear", contractYear.Trim()) : new SqlParameter("ContractYear", DBNull.Value);

            string command = "INSERT INTO [dbo].[LFS_WORK_FULLLENGTHLINING_M1_LATERAL] ([WorkID], [Lateral], [VideoDistance], [ClockPosition], [DistanceToCentre], [TimeOpened], [ReverseSetup], [Reinstate], [Comments], [Deleted], [COMPANY_ID], [ClientInspectionNo], [V1Inspection], [RequiresRoboticPrep], [RequiresRoboticPrepDate], [HoldClientIssue], [HoldLFSIssue], [LineLateral], [DyeTestReq], [DyeTestComplete], [ContractYear]) VALUES (@WorkID, @Lateral, @VideoDistance, @ClockPosition, @DistanceToCentre, @TimeOpened, @ReverseSetup, @Reinstate, @Comments, @Deleted, @COMPANY_ID, @ClientInspectionNo, @V1Inspection, @RequiresRoboticPrep, @RequiresRoboticPrepDate, @HoldClientIssue, @HoldLFSIssue, @LineLateral, @DyeTestReq, @DyeTestComplete, @ContractYear);";

            int rowsAffected = (int)ExecuteNonQuery(command, workIdParameter, lateralParameter, videoDistanceParameter, clockPositionParameter, distanceToCentreParameter, timeOpenedParameter, reverseSetupParameter, reinstateParameter, commentsParameter, deletedParameter, companyIdParameter, clientInspectionNoParameter, v1InspectionParameter, requiresRoboticPrepParameter, requiresRoboticPrepDateParameter, holdClientIssueParameter, holdLFSIssueParameter, lineLateralParameter, dyeTestReqParameter, dyeTestCompleteParameter, contractYearParameter);

            return rowsAffected;
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="originalWorkId">originalWorkId</param>
        /// <param name="originalLateral">originalLateral</param>
        /// <param name="originalVideoDistance">originalVideoDistance</param>
        /// <param name="originalClockPosition">originalClockPosition</param>
        /// <param name="originalDistanceToCentre">originalDistanceToCentre</param>
        /// <param name="originalTimeOpened">originalTimeOpened</param>
        /// <param name="originalReverseSetup">originalReverseSetup</param>
        /// <param name="originalReinstate">originalReinstate</param>
        /// <param name="originalComments">originalComments</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalClientInspectionNo">originalClientInspectionNo</param>
        /// <param name="originalV1Inspection">originalV1Inspection</param>
        /// <param name="originalRequiresRoboticPrep">originalRequiresRoboticPrep</param>
        /// <param name="originalRequiresRoboticPrepDate">originalRequiresRoboticPrepDate</param>
        /// <param name="originalHoldClientIssue">originalHoldClientIssue</param>
        /// <param name="originalHoldLFSIssue">originalHoldLFSIssue</param>
        /// <param name="originalLineLateral">originalLineLateral</param>
        /// <param name="originalDyeTestReq">originalDyeTestReq</param>
        /// <param name="originalDyeTestComplete">originalDyeTestComplete</param>
        /// <param name="originalContractYear">originalContractYear</param>
        /// 
        /// <param name="newWorkId">newWorkId</param>
        /// <param name="newLateral">newLateral</param>
        /// <param name="newVideoDistance">newVideoDistance</param>
        /// <param name="newClockPosition">newClockPosition</param>
        /// <param name="newDistanceToCentre">newDistanceToCentre</param>
        /// <param name="newTimeOpened">newTimeOpened</param>
        /// <param name="newReverseSetup">newReverseSetup</param>
        /// <param name="newReinstate">newReinstate</param>
        /// <param name="newComments">newComments</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newClientInspectionNo">newClientInspectionNo</param>
        /// <param name="newV1Inspection">newV1Inspection</param>
        /// <param name="newRequiresRoboticPrep">newRequiresRoboticPrep</param>
        /// <param name="newRequiresRoboticPrepDate">newRequiresRoboticPrepDate</param>
        /// <param name="newHoldClientIssue">newHoldClientIssue</param>
        /// <param name="newHoldLFSIssue">newHoldLFSIssue</param>
        /// <param name="newLineLateral">newLineLateral</param>
        /// <param name="newDyeTestReq">newDyeTestReq</param>
        /// <param name="newDyeTestComplete">newDyeTestComplete</param>
        /// <param name="newContractYear">newContractYear</param>
        /// <returns></returns>
        public int Update(int originalWorkId, int originalLateral, string originalVideoDistance, string originalClockPosition, string originalDistanceToCentre, string originalTimeOpened, string originalReverseSetup, DateTime? originalReinstate, string originalComments, bool originalDeleted, int originalCompanyId, string originalClientInspectionNo, DateTime? originalV1Inspection, bool originalRequiresRoboticPrep, DateTime? originalRequiresRoboticPrepDate, bool originalHoldClientIssue, bool originalHoldLFSIssue, bool originalLineLateral, bool originalDyeTestReq, DateTime? originalDyeTestComplete, string originalContractYear, int newWorkId, int newLateral, string newVideoDistance, string newClockPosition, string newDistanceToCentre, string newTimeOpened, string newReverseSetup, DateTime? newReinstate, string newComments, bool newDeleted, int newCompanyId, string newClientInspectionNo, DateTime? newV1Inspection, bool newRequiresRoboticPrep, DateTime? newRequiresRoboticPrepDate, bool newHoldClientIssue, bool newHoldLFSIssue, bool newLineLateral, bool newDyeTestReq, DateTime? newDyeTestComplete, string newContractYear)
        {
            SqlParameter originalWorkIdParameter = new SqlParameter("Original_WorkID", originalWorkId);
            SqlParameter originalLateralParameter = new SqlParameter("Original_Lateral", originalLateral);
            SqlParameter originalVideoDistanceParameter = (originalVideoDistance.Trim() != "") ? new SqlParameter("Original_VideoDistance", originalVideoDistance.Trim()) : new SqlParameter("Original_VideoDistance", DBNull.Value);
            SqlParameter originalClockPositionParameter = (originalClockPosition.Trim() != "") ? new SqlParameter("Original_ClockPosition", originalClockPosition.Trim()) : new SqlParameter("Original_ClockPosition", DBNull.Value);
            SqlParameter originalDistanceToCentreParameter = (originalDistanceToCentre.Trim() != "") ? new SqlParameter("Original_DistanceToCentre", originalDistanceToCentre.Trim()) : new SqlParameter("Original_DistanceToCentre", DBNull.Value);
            SqlParameter originalTimeOpenedParameter = (originalTimeOpened.Trim() != "") ? new SqlParameter("Original_TimeOpened", originalTimeOpened.Trim()) : new SqlParameter("Original_TimeOpened", DBNull.Value);
            SqlParameter originalReverseSetupParameter = (originalReverseSetup.Trim() != "") ? new SqlParameter("Original_ReverseSetup", originalReverseSetup.Trim()) : new SqlParameter("Original_ReverseSetup", DBNull.Value);
            SqlParameter originalReinstateParameter = (originalReinstate.HasValue) ? new SqlParameter("Original_Reinstate", originalReinstate) : new SqlParameter("Original_Reinstate", DBNull.Value);
            SqlParameter originalCommentsParameter = (originalComments.Trim() != "") ? new SqlParameter("Original_Comments", originalComments.Trim()) : new SqlParameter("Original_Comments", DBNull.Value);
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter originalClientInspectionNoParameter = (originalClientInspectionNo.Trim() != "") ? new SqlParameter("Original_ClientInspectionNo", originalClientInspectionNo.Trim()) : new SqlParameter("Original_ClientInspectionNo", DBNull.Value);
            SqlParameter originalV1InspectionParameter = (originalV1Inspection.HasValue) ? new SqlParameter("Original_V1Inspection", originalV1Inspection) : new SqlParameter("Original_V1Inspection", DBNull.Value);
            SqlParameter originalRequiresRoboticPrepParameter = new SqlParameter("Original_RequiresRoboticPrep", originalRequiresRoboticPrep);
            SqlParameter originalRequiresRoboticPrepDateParameter = (originalRequiresRoboticPrepDate.HasValue) ? new SqlParameter("Original_RequiresRoboticPrepDate", originalRequiresRoboticPrepDate) : new SqlParameter("Original_RequiresRoboticPrepDate", DBNull.Value);
            SqlParameter originalHoldClientIssueParameter = new SqlParameter("Original_HoldClientIssue", originalHoldClientIssue);
            SqlParameter originalHoldLFSIssueParameter = new SqlParameter("Original_HoldLFSIssue", originalHoldLFSIssue);
            SqlParameter originalLineLateralParameter = new SqlParameter("Original_Linelateral", originalLineLateral);
            SqlParameter originalDyeTestReqParameter = new SqlParameter("Original_DyeTestReq", originalDyeTestReq);
            SqlParameter originalDyeTestCompleteParameter = (originalDyeTestComplete.HasValue) ? new SqlParameter("Original_DyeTestComplete", originalDyeTestComplete) : new SqlParameter("Original_DyeTestComplete", DBNull.Value);
            SqlParameter originalContractYearParameter = (originalContractYear.Trim() != "") ? new SqlParameter("Original_ContractYear", originalContractYear.Trim()) : new SqlParameter("Original_ContractYear", DBNull.Value);

            SqlParameter newWorkIdParameter = new SqlParameter("WorkID", newWorkId);
            SqlParameter newLateralParameter = new SqlParameter("Lateral", newLateral);
            SqlParameter newVideoDistanceParameter = (newVideoDistance.Trim() != "") ? new SqlParameter("VideoDistance", newVideoDistance.Trim()) : new SqlParameter("VideoDistance", DBNull.Value);
            SqlParameter newClockPositionParameter = (newClockPosition.Trim() != "") ? new SqlParameter("ClockPosition", newClockPosition.Trim()) : new SqlParameter("ClockPosition", DBNull.Value);
            SqlParameter newDistanceToCentreParameter = (newDistanceToCentre.Trim() != "") ? new SqlParameter("DistanceToCentre", newDistanceToCentre.Trim()) : new SqlParameter("DistanceToCentre", DBNull.Value);
            SqlParameter newTimeOpenedParameter = (newTimeOpened.Trim() != "") ? new SqlParameter("TimeOpened", newTimeOpened.Trim()) : new SqlParameter("TimeOpened", DBNull.Value);
            SqlParameter newReverseSetupParameter = (newReverseSetup.Trim() != "") ? new SqlParameter("ReverseSetup", newReverseSetup.Trim()) : new SqlParameter("ReverseSetup", DBNull.Value);
            SqlParameter newReinstateParameter = (newReinstate.HasValue) ? new SqlParameter("Reinstate", newReinstate) : new SqlParameter("Reinstate", DBNull.Value);
            SqlParameter newCommentsParameter = (newComments.Trim() != "") ? new SqlParameter("Comments", newComments.Trim()) : new SqlParameter("Comments", DBNull.Value);
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);
            SqlParameter newClientInspectionNoParameter = (newClientInspectionNo.Trim() != "") ? new SqlParameter("ClientInspectionNo", newClientInspectionNo.Trim()) : new SqlParameter("ClientInspectionNo", DBNull.Value);
            SqlParameter newV1InspectionParameter = (newV1Inspection.HasValue) ? new SqlParameter("V1Inspection", newV1Inspection) : new SqlParameter("V1Inspection", DBNull.Value);
            SqlParameter newRequiresRoboticPrepParameter = new SqlParameter("RequiresRoboticPrep", newRequiresRoboticPrep);
            SqlParameter newRequiresRoboticPrepDateParameter = (newRequiresRoboticPrepDate.HasValue) ? new SqlParameter("RequiresRoboticPrepDate", newRequiresRoboticPrepDate) : new SqlParameter("RequiresRoboticPrepDate", DBNull.Value);
            SqlParameter newHoldClientIssueParameter = new SqlParameter("HoldClientIssue", newHoldClientIssue);
            SqlParameter newHoldLFSIssueParameter = new SqlParameter("HoldLFSIssue", newHoldLFSIssue);
            SqlParameter newLineLateralParameter = new SqlParameter("LineLateral", newLineLateral);
            SqlParameter newDyeTestReqParameter = new SqlParameter("DyeTestReq", newDyeTestReq);
            SqlParameter newDyeTestCompleteParameter = (newDyeTestComplete.HasValue) ? new SqlParameter("DyeTestComplete", newDyeTestComplete) : new SqlParameter("DyeTestComplete", DBNull.Value);
            SqlParameter newContractYearParameter = (newContractYear.Trim() != "") ? new SqlParameter("ContractYear", newContractYear.Trim()) : new SqlParameter("ContractYear", DBNull.Value);

            string command = "UPDATE [dbo].[LFS_WORK_FULLLENGTHLINING_M1_LATERAL] "+
                " SET "+
                " [VideoDistance] = @VideoDistance, [ClockPosition] = @ClockPosition, "+
                " [DistanceToCentre] = @DistanceToCentre, [TimeOpened] = @TimeOpened, "+
                " [ReverseSetup] = @ReverseSetup, [Reinstate] = @Reinstate, [Comments] = @Comments, "+
                " [Deleted] = @Deleted, [ClientInspectionNo] = @ClientInspectionNo, [V1Inspection] = @V1Inspection, "+
                " [RequiresRoboticPrep] = @RequiresRoboticPrep, [RequiresRoboticPrepDate] = @RequiresRoboticPrepDate, " +
                " [HoldClientIssue] = @HoldClientIssue, [HoldLFSIssue] = @HoldLFSIssue, [LineLateral] = @LineLateral, " +
                " [DyeTestReq] = @DyeTestReq, [DyeTestComplete] = @DyeTestComplete, [ContractYear] = @ContractYear " +
                " WHERE ([WorkID] = @Original_WorkID) AND ([Lateral] = @Original_Lateral) AND "+
                " ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID)";

            int rowsAffected = (int)ExecuteNonQuery(command, originalWorkIdParameter, originalLateralParameter, originalVideoDistanceParameter, originalClockPositionParameter, originalDistanceToCentreParameter, originalTimeOpenedParameter, originalReverseSetupParameter, originalReinstateParameter, originalCommentsParameter, originalDeletedParameter, originalCompanyIdParameter, originalClientInspectionNoParameter, originalV1InspectionParameter, originalRequiresRoboticPrepParameter, originalRequiresRoboticPrepDateParameter, originalHoldClientIssueParameter, originalHoldLFSIssueParameter, originalLineLateralParameter, originalDyeTestReqParameter, originalDyeTestCompleteParameter, originalContractYearParameter, newWorkIdParameter, newLateralParameter, newVideoDistanceParameter, newClockPositionParameter, newDistanceToCentreParameter, newTimeOpenedParameter, newReverseSetupParameter, newReinstateParameter, newCommentsParameter, newDeletedParameter, newCompanyIdParameter, newClientInspectionNoParameter, newV1InspectionParameter, newRequiresRoboticPrepParameter, newRequiresRoboticPrepDateParameter, newHoldClientIssueParameter, newHoldLFSIssueParameter, newLineLateralParameter, newDyeTestReqParameter, newDyeTestCompleteParameter, newContractYearParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="originalWorkId">originalWorkId</param>
        /// <param name="originalRefID">originalLateral</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <returns></returns>
        public int Delete(int originalWorkId, int originalLateral, int originalCompanyId)
        {
            SqlParameter originalWorkIdParameter = new SqlParameter("@Original_WorkID", originalWorkId);
            SqlParameter originalLateralParameter = new SqlParameter("@Original_Lateral", originalLateral);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_WORK_FULLLENGTHLINING_M1_LATERAL] SET  [Deleted] = @Deleted  " +
                             " WHERE (([WorkID] = @Original_WorkID) AND ([Lateral] = @Original_Lateral) AND " +
                             "  ([COMPANY_ID] = @Original_COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalWorkIdParameter, originalLateralParameter, originalCompanyIdParameter, deletedParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }


        
    }
}

