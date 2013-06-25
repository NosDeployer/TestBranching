using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.Works
{
    /// <summary>
    /// WorkPointRepairsRepairGateway
    /// </summary>
    public class WorkPointRepairsRepairGateway : DataTableGateway
    {
        ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkPointRepairsRepairGateway()
            : base("LFS_WORK_POINT_REPAIRS_REPAIR")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkPointRepairsRepairGateway(DataSet data)
            : base(data, "LFS_WORK_POINT_REPAIRS_REPAIR")
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
            tableMapping.DataSetTable = "LFS_WORK_POINT_REPAIRS_REPAIR";
            tableMapping.ColumnMappings.Add("WorkID", "WorkID");
            tableMapping.ColumnMappings.Add("RepairPointID", "RepairPointID");
            tableMapping.ColumnMappings.Add("Type", "Type");
            tableMapping.ColumnMappings.Add("ReamDistance", "ReamDistance");
            tableMapping.ColumnMappings.Add("ReamDate", "ReamDate");
            tableMapping.ColumnMappings.Add("LinerDistance", "LinerDistance");
            tableMapping.ColumnMappings.Add("Direction", "Direction");
            tableMapping.ColumnMappings.Add("Reinstates", "Reinstates");
            tableMapping.ColumnMappings.Add("LTMH", "LTMH");
            tableMapping.ColumnMappings.Add("VTMH", "VTMH");
            tableMapping.ColumnMappings.Add("Distance", "Distance");
            tableMapping.ColumnMappings.Add("Size_", "Size_");
            tableMapping.ColumnMappings.Add("InstallDate", "InstallDate");
            tableMapping.ColumnMappings.Add("MHShot", "MHShot");
            tableMapping.ColumnMappings.Add("GroutDistance", "GroutDistance");
            tableMapping.ColumnMappings.Add("GroutDate", "GroutDate");
            tableMapping.ColumnMappings.Add("Approval", "Approval");
            tableMapping.ColumnMappings.Add("ExtraRepair", "ExtraRepair");
            tableMapping.ColumnMappings.Add("Cancelled", "Cancelled");
            tableMapping.ColumnMappings.Add("Comments", "Comments");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("DefectQualifier", "DefectQualifier");
            tableMapping.ColumnMappings.Add("DefectDetails", "DefectDetails");
            tableMapping.ColumnMappings.Add("Length", "Length");
            tableMapping.ColumnMappings.Add("ReinstateDate", "ReinstateDate");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[LFS_WORK_POINT_REPAIRS_REPAIR] WHERE (([WorkID] = @Original_Wo" +
                "rkID) AND ([RepairPointID] = @Original_RepairPointID) AND ((@IsNull_Type = 1 AND" +
                " [Type] IS NULL) OR ([Type] = @Original_Type)) AND ((@IsNull_ReamDistance = 1 AN" +
                "D [ReamDistance] IS NULL) OR ([ReamDistance] = @Original_ReamDistance)) AND ((@I" +
                "sNull_ReamDate = 1 AND [ReamDate] IS NULL) OR ([ReamDate] = @Original_ReamDate))" +
                " AND ((@IsNull_LinerDistance = 1 AND [LinerDistance] IS NULL) OR ([LinerDistance" +
                "] = @Original_LinerDistance)) AND ((@IsNull_Direction = 1 AND [Direction] IS NUL" +
                "L) OR ([Direction] = @Original_Direction)) AND ((@IsNull_Reinstates = 1 AND [Rei" +
                "nstates] IS NULL) OR ([Reinstates] = @Original_Reinstates)) AND ((@IsNull_LTMH =" +
                " 1 AND [LTMH] IS NULL) OR ([LTMH] = @Original_LTMH)) AND ((@IsNull_VTMH = 1 AND " +
                "[VTMH] IS NULL) OR ([VTMH] = @Original_VTMH)) AND ((@IsNull_Distance = 1 AND [Di" +
                "stance] IS NULL) OR ([Distance] = @Original_Distance)) AND ((@IsNull_Size_ = 1 A" +
                "ND [Size_] IS NULL) OR ([Size_] = @Original_Size_)) AND ((@IsNull_InstallDate = " +
                "1 AND [InstallDate] IS NULL) OR ([InstallDate] = @Original_InstallDate)) AND ((@" +
                "IsNull_MHShot = 1 AND [MHShot] IS NULL) OR ([MHShot] = @Original_MHShot)) AND ((" +
                "@IsNull_GroutDistance = 1 AND [GroutDistance] IS NULL) OR ([GroutDistance] = @Or" +
                "iginal_GroutDistance)) AND ((@IsNull_GroutDate = 1 AND [GroutDate] IS NULL) OR (" +
                "[GroutDate] = @Original_GroutDate)) AND ((@IsNull_Approval = 1 AND [Approval] IS" +
                " NULL) OR ([Approval] = @Original_Approval)) AND ([ExtraRepair] = @Original_Extr" +
                "aRepair) AND ([Cancelled] = @Original_Cancelled) AND ([Deleted] = @Original_Dele" +
                "ted) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND ((@IsNull_DefectQualifier = 1" +
                " AND [DefectQualifier] IS NULL) OR ([DefectQualifier] = @Original_DefectQualifie" +
                "r)) AND ((@IsNull_DefectDetails = 1 AND [DefectDetails] IS NULL) OR ([DefectDeta" +
                "ils] = @Original_DefectDetails)) AND ((@IsNull_Length = 1 AND [Length] IS NULL) " +
                "OR ([Length] = @Original_Length)))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_WorkID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RepairPointID", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RepairPointID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Type", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Type", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Type", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Type", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_ReamDistance", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ReamDistance", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ReamDistance", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ReamDistance", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_ReamDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ReamDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ReamDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ReamDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_LinerDistance", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LinerDistance", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LinerDistance", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LinerDistance", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Direction", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Direction", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Direction", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Direction", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Reinstates", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Reinstates", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Reinstates", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Reinstates", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_LTMH", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LTMH", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LTMH", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LTMH", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_VTMH", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VTMH", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_VTMH", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VTMH", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Distance", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Distance", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Distance", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Distance", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Size_", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Size_", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Size_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Size_", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_InstallDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "InstallDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_InstallDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "InstallDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_MHShot", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MHShot", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MHShot", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MHShot", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_GroutDistance", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "GroutDistance", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_GroutDistance", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "GroutDistance", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_GroutDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "GroutDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_GroutDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "GroutDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Approval", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Approval", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Approval", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Approval", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ExtraRepair", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ExtraRepair", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Cancelled", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Cancelled", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DefectQualifier", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DefectQualifier", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DefectQualifier", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DefectQualifier", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DefectDetails", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DefectDetails", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DefectDetails", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DefectDetails", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Length", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Length", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Length", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Length", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_WORK_POINT_REPAIRS_REPAIR] ([WorkID], [RepairPointID], [Type], [ReamDistance], [ReamDate], [LinerDistance], [Direction], [Reinstates], [LTMH], [VTMH], [Distance], [Size_], [InstallDate], [MHShot], [GroutDistance], [GroutDate], [Approval], [ExtraRepair], [Cancelled], [Comments], [Deleted], [COMPANY_ID], [DefectQualifier], [DefectDetails], [Length]) VALUES (@WorkID, @RepairPointID, @Type, @ReamDistance, @ReamDate, @LinerDistance, @Direction, @Reinstates, @LTMH, @VTMH, @Distance, @Size_, @InstallDate, @MHShot, @GroutDistance, @GroutDate, @Approval, @ExtraRepair, @Cancelled, @Comments, @Deleted, @COMPANY_ID, @DefectQualifier, @DefectDetails, @Length);
SELECT WorkID, RepairPointID, Type, ReamDistance, ReamDate, LinerDistance, Direction, Reinstates, LTMH, VTMH, Distance, Size_, InstallDate, MHShot, GroutDistance, GroutDate, Approval, ExtraRepair, Cancelled, Comments, Deleted, COMPANY_ID, DefectQualifier, DefectDetails, Length FROM LFS_WORK_POINT_REPAIRS_REPAIR WHERE (RepairPointID = @RepairPointID) AND (WorkID = @WorkID)";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@WorkID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RepairPointID", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RepairPointID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Type", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Type", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ReamDistance", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ReamDistance", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ReamDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ReamDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LinerDistance", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LinerDistance", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Direction", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Direction", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Reinstates", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Reinstates", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LTMH", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LTMH", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@VTMH", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VTMH", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Distance", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Distance", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Size_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Size_", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@InstallDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "InstallDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MHShot", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MHShot", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@GroutDistance", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "GroutDistance", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@GroutDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "GroutDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Approval", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Approval", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ExtraRepair", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ExtraRepair", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Cancelled", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Cancelled", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Comments", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Comments", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DefectQualifier", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DefectQualifier", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DefectDetails", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DefectDetails", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Length", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Length", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));

            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[LFS_WORK_POINT_REPAIRS_REPAIR] SET [WorkID] = @WorkID, [RepairPoint" +
                "ID] = @RepairPointID, [Type] = @Type, [ReamDistance] = @ReamDistance, [ReamDate]" +
                " = @ReamDate, [LinerDistance] = @LinerDistance, [Direction] = @Direction, [Reins" +
                "tates] = @Reinstates, [LTMH] = @LTMH, [VTMH] = @VTMH, [Distance] = @Distance, [S" +
                "ize_] = @Size_, [InstallDate] = @InstallDate, [MHShot] = @MHShot, [GroutDistance" +
                "] = @GroutDistance, [GroutDate] = @GroutDate, [Approval] = @Approval, [ExtraRepa" +
                "ir] = @ExtraRepair, [Cancelled] = @Cancelled, [Comments] = @Comments, [Deleted] " +
                "= @Deleted, [COMPANY_ID] = @COMPANY_ID, [DefectQualifier] = @DefectQualifier, [D" +
                "efectDetails] = @DefectDetails, [Length] = @Length WHERE (([WorkID] = @Original_" +
                "WorkID) AND ([RepairPointID] = @Original_RepairPointID) AND ((@IsNull_Type = 1 A" +
                "ND [Type] IS NULL) OR ([Type] = @Original_Type)) AND ((@IsNull_ReamDistance = 1 " +
                "AND [ReamDistance] IS NULL) OR ([ReamDistance] = @Original_ReamDistance)) AND ((" +
                "@IsNull_ReamDate = 1 AND [ReamDate] IS NULL) OR ([ReamDate] = @Original_ReamDate" +
                ")) AND ((@IsNull_LinerDistance = 1 AND [LinerDistance] IS NULL) OR ([LinerDistan" +
                "ce] = @Original_LinerDistance)) AND ((@IsNull_Direction = 1 AND [Direction] IS N" +
                "ULL) OR ([Direction] = @Original_Direction)) AND ((@IsNull_Reinstates = 1 AND [R" +
                "einstates] IS NULL) OR ([Reinstates] = @Original_Reinstates)) AND ((@IsNull_LTMH" +
                " = 1 AND [LTMH] IS NULL) OR ([LTMH] = @Original_LTMH)) AND ((@IsNull_VTMH = 1 AN" +
                "D [VTMH] IS NULL) OR ([VTMH] = @Original_VTMH)) AND ((@IsNull_Distance = 1 AND [" +
                "Distance] IS NULL) OR ([Distance] = @Original_Distance)) AND ((@IsNull_Size_ = 1" +
                " AND [Size_] IS NULL) OR ([Size_] = @Original_Size_)) AND ((@IsNull_InstallDate " +
                "= 1 AND [InstallDate] IS NULL) OR ([InstallDate] = @Original_InstallDate)) AND (" +
                "(@IsNull_MHShot = 1 AND [MHShot] IS NULL) OR ([MHShot] = @Original_MHShot)) AND " +
                "((@IsNull_GroutDistance = 1 AND [GroutDistance] IS NULL) OR ([GroutDistance] = @" +
                "Original_GroutDistance)) AND ((@IsNull_GroutDate = 1 AND [GroutDate] IS NULL) OR" +
                " ([GroutDate] = @Original_GroutDate)) AND ((@IsNull_Approval = 1 AND [Approval] " +
                "IS NULL) OR ([Approval] = @Original_Approval)) AND ([ExtraRepair] = @Original_Ex" +
                "traRepair) AND ([Cancelled] = @Original_Cancelled) AND ([Deleted] = @Original_De" +
                "leted) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND ((@IsNull_DefectQualifier =" +
                " 1 AND [DefectQualifier] IS NULL) OR ([DefectQualifier] = @Original_DefectQualif" +
                "ier)) AND ((@IsNull_DefectDetails = 1 AND [DefectDetails] IS NULL) OR ([DefectDe" +
                "tails] = @Original_DefectDetails)) AND ((@IsNull_Length = 1 AND [Length] IS NULL" +
                ") OR ([Length] = @Original_Length)));\r\nSELECT WorkID, RepairPointID, Type, ReamD" +
                "istance, ReamDate, LinerDistance, Direction, Reinstates, LTMH, VTMH, Distance, S" +
                "ize_, InstallDate, MHShot, GroutDistance, GroutDate, Approval, ExtraRepair, Canc" +
                "elled, Comments, Deleted, COMPANY_ID, DefectQualifier, DefectDetails, Length FRO" +
                "M LFS_WORK_POINT_REPAIRS_REPAIR WHERE (RepairPointID = @RepairPointID) AND (Work" +
                "ID = @WorkID)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@WorkID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RepairPointID", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RepairPointID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Type", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Type", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ReamDistance", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ReamDistance", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ReamDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ReamDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LinerDistance", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LinerDistance", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Direction", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Direction", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Reinstates", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Reinstates", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LTMH", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LTMH", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@VTMH", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VTMH", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Distance", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Distance", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Size_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Size_", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@InstallDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "InstallDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MHShot", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MHShot", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@GroutDistance", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "GroutDistance", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@GroutDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "GroutDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Approval", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Approval", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ExtraRepair", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ExtraRepair", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Cancelled", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Cancelled", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Comments", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Comments", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DefectQualifier", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DefectQualifier", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DefectDetails", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DefectDetails", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Length", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Length", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_WorkID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RepairPointID", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RepairPointID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Type", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Type", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Type", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Type", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_ReamDistance", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ReamDistance", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ReamDistance", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ReamDistance", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_ReamDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ReamDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ReamDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ReamDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_LinerDistance", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LinerDistance", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LinerDistance", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LinerDistance", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Direction", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Direction", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Direction", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Direction", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Reinstates", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Reinstates", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Reinstates", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Reinstates", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_LTMH", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LTMH", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LTMH", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LTMH", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_VTMH", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VTMH", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_VTMH", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VTMH", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Distance", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Distance", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Distance", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Distance", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Size_", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Size_", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Size_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Size_", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_InstallDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "InstallDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_InstallDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "InstallDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_MHShot", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MHShot", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MHShot", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MHShot", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_GroutDistance", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "GroutDistance", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_GroutDistance", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "GroutDistance", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_GroutDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "GroutDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_GroutDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "GroutDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Approval", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Approval", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Approval", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Approval", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ExtraRepair", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ExtraRepair", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Cancelled", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Cancelled", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DefectQualifier", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DefectQualifier", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DefectQualifier", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DefectQualifier", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DefectDetails", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DefectDetails", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DefectDetails", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DefectDetails", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Length", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Length", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Length", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Length", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

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
            FillDataWithStoredProcedure("LFS_CWP_WORKPOINTREPAIRSREPAIRGATEWAY_LOADBYWORKID", new SqlParameter("@workId", workId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByWorkIdRepairPointId
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="repairPointId">repairPointId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>data set</returns>
        public DataSet LoadByWorkIdRepairPointId(int workId, string repairPointId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_WORKPOINTREPAIRSREPAIRGATEWAY_LOADBYWORKIDREPAIRPOINTID", new SqlParameter("@workId", workId), new SqlParameter("@repairPointId", repairPointId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="repairPointId">repairPointId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int workId, string repairPointId)
        {
            string filter = string.Format("WorkID = {0} AND RepairPointID = '{1}'", workId, repairPointId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.CWP.Common.WorkPointRepairsRepairGateway.GetRow");
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROWS
        //

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="repairPointId">repairPointId</param>
        /// <param name="type">type</param>
        /// <param name="reamDistance">reamDistance</param>
        /// <param name="reamDate">reamDate</param>
        /// <param name="linerDistance">linerDistance</param>
        /// <param name="direction">direction</param>
        /// <param name="reinstates">reinstates</param>
        /// <param name="ltmh">ltmh</param>
        /// <param name="vtmh">vtmh</param>
        /// <param name="distance">distance</param>
        /// <param name="size_">size_</param>
        /// <param name="installDate">installDate</param>
        /// <param name="mhShot">mhShot</param>
        /// <param name="groutDistance">groutDistance</param>
        /// <param name="groutDate">groutDate</param>
        /// <param name="approval">approval</param>
        /// <param name="extraRepair">extraRepair</param>
        /// <param name="cancelled">cancelled</param>
        /// <param name="comments">comments</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="defectQualifier">defectQualifier</param>
        /// <param name="defectDetails">defectDetails</param>
        /// <param name="length">length</param>
        /// <returns>rowsAffected</returns>
        public int Insert(int workId, string repairPointId, string type, string reamDistance, DateTime? reamDate, string linerDistance, string direction, int? reinstates, string ltmh, string vtmh, string distance, string size_, DateTime? installDate, string mhShot, string groutDistance, DateTime? groutDate, string approval, bool extraRepair, bool cancelled, string comments, bool deleted, int companyId, string defectQualifier, string defectDetails, string length, DateTime? reinstateDate)
        {
            SqlParameter workIdParameter = new SqlParameter("WorkID", workId);
            SqlParameter repairPointIdParameter = new SqlParameter("RepairPointID", repairPointId);
            SqlParameter typeParameter = (type.Trim() != "") ? new SqlParameter("Type", type.Trim()) : new SqlParameter("Type", DBNull.Value);
            SqlParameter reamDistanceParameter = (reamDistance.Trim() != "") ? new SqlParameter("ReamDistance", reamDistance.Trim()) : new SqlParameter("ReamDistance", DBNull.Value);
            SqlParameter reamDateParameter = (reamDate.HasValue) ? new SqlParameter("ReamDate", reamDate) : new SqlParameter("ReamDate", DBNull.Value);
            SqlParameter linerDistanceParameter = (linerDistance.Trim() != "") ? new SqlParameter("LinerDistance", linerDistance.Trim()) : new SqlParameter("LinerDistance", DBNull.Value);
            SqlParameter directionParameter = (direction.Trim() != "") ? new SqlParameter("Direction", direction.Trim()) : new SqlParameter("Direction", DBNull.Value);
            SqlParameter reinstatesParameter = (reinstates.HasValue) ? new SqlParameter("Reinstates", reinstates) : new SqlParameter("Reinstates", DBNull.Value);
            SqlParameter ltmhParameter = (ltmh.Trim() != "") ? new SqlParameter("LTMH", ltmh.Trim()) : new SqlParameter("LTMH", DBNull.Value);
            SqlParameter vtmhParameter = (vtmh.Trim() != "") ? new SqlParameter("VTMH", vtmh.Trim()) : new SqlParameter("VTMH", DBNull.Value);
            SqlParameter distanceParameter = (distance.Trim() != "") ? new SqlParameter("Distance", distance.Trim()) : new SqlParameter("Distance", DBNull.Value);
            SqlParameter size_Parameter = (size_.Trim() != "") ? new SqlParameter("Size_", size_.Trim()) : new SqlParameter("Size_", DBNull.Value);
            SqlParameter installDateParameter = (installDate.HasValue) ? new SqlParameter("InstallDate", installDate) : new SqlParameter("InstallDate", DBNull.Value);
            SqlParameter mhShotParameter = (mhShot.Trim() != "") ? new SqlParameter("MHShot", mhShot.Trim()) : new SqlParameter("MHShot", DBNull.Value);
            SqlParameter groutDistanceParameter = (groutDistance.Trim() != "") ? new SqlParameter("GroutDistance", groutDistance.Trim()) : new SqlParameter("GroutDistance", DBNull.Value);
            SqlParameter groutDateParameter = (groutDate.HasValue) ? new SqlParameter("GroutDate", groutDate) : new SqlParameter("GroutDate", DBNull.Value);
            SqlParameter approvalParameter = (approval.Trim() != "") ? new SqlParameter("Approval", approval.Trim()) : new SqlParameter("Approval", DBNull.Value);
            SqlParameter extraRepairParamter = new SqlParameter("ExtraRepair", extraRepair);
            SqlParameter cancelledParameter = new SqlParameter("Cancelled", cancelled);
            SqlParameter commentsParameter = (comments.Trim() != "") ? new SqlParameter("Comments", comments.Trim()) : new SqlParameter("Comments", DBNull.Value);
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            SqlParameter defectQualiferParameter = (defectQualifier.Trim() != "") ? new SqlParameter("DefectQualifier", defectQualifier.Trim()) : new SqlParameter("DefectQualifier", DBNull.Value);
            SqlParameter defectDetailsParameter = (defectDetails.Trim() != "") ? new SqlParameter("DefectDetails", defectDetails.Trim()) : new SqlParameter("DefectDetails", DBNull.Value);
            SqlParameter lengthParameter = (length.Trim() != "") ? new SqlParameter("Length", length.Trim()) : new SqlParameter("Length", DBNull.Value);
            SqlParameter reinstateDateParameter = (reinstateDate.HasValue) ? new SqlParameter("ReinstateDate", reinstateDate) : new SqlParameter("ReinstateDate", DBNull.Value);

            string command = "INSERT INTO [dbo].[LFS_WORK_POINT_REPAIRS_REPAIR] ([WorkID], [RepairPointID], [Type], [ReamDistance], [ReamDate], [LinerDistance], [Direction], "+
                            " [Reinstates], [LTMH], [VTMH], [Distance], [Size_], [InstallDate], [MHShot], [GroutDistance], [GroutDate], [Approval], [ExtraRepair], [Cancelled], "+
                            " [Comments], [Deleted], [COMPANY_ID], [DefectQualifier], [DefectDetails], [Length], [ReinstateDate]) " +
                            " VALUES (@WorkID, @RepairPointID, @Type, @ReamDistance, @ReamDate, @LinerDistance, @Direction, @Reinstates, @LTMH, @VTMH, @Distance, @Size_, @InstallDate, "+
                            " @MHShot, @GroutDistance, @GroutDate, @Approval, @ExtraRepair, @Cancelled, @Comments, @Deleted, @COMPANY_ID, @DefectQualifier, @DefectDetails, @Length, @ReinstateDate)";

            int rowsAffected = (int)ExecuteNonQuery(command, workIdParameter, repairPointIdParameter, typeParameter, reamDistanceParameter, reamDateParameter, linerDistanceParameter, directionParameter, reinstatesParameter, ltmhParameter, vtmhParameter, distanceParameter, size_Parameter, installDateParameter, mhShotParameter, groutDistanceParameter, groutDateParameter, approvalParameter, extraRepairParamter, cancelledParameter, commentsParameter, deletedParameter, companyIdParameter, defectQualiferParameter, defectDetailsParameter, lengthParameter, reinstateDateParameter);

            return rowsAffected;
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="originalWorkId">originalWorkId</param>
        /// <param name="originalRepairPointId">originalRepairPointId</param>
        /// <param name="originalType">originalType</param>
        /// <param name="originalReamDistance">originalReamDistance</param>
        /// <param name="originalReamDate">originalReamDate</param>
        /// <param name="originalLinerDistance">originalLinerDistance</param>
        /// <param name="originalDirection">originalDirection</param>
        /// <param name="originalReinstates">originalReinstates</param>
        /// <param name="originalLtmh">originalLtmh</param>
        /// <param name="originalVtmh">originalVtmh</param>
        /// <param name="originalDistance">originalDistance</param>
        /// <param name="originalSize_">originalSize_</param>
        /// <param name="originalInstallDate">originalInstallDate</param>
        /// <param name="originalMhShot">originalMhShot</param>
        /// <param name="originalGroutDistance">originalGroutDistance</param>
        /// <param name="originalGroutDate">originalGroutDate</param>
        /// <param name="originalApproval">originalApproval</param>
        /// <param name="originalExtraRepair">originalExtraRepair</param>
        /// <param name="originalCancelled">originalCancelled</param>
        /// <param name="originalComments">originalComments</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalDefectQualifier">originalDefectQualifier</param>
        /// <param name="originalDefectDetails">originalDefectDetails</param>
        /// <param name="originalLength">originalLength</param>
        /// 
        /// <param name="newWorkId">newWorkId</param>
        /// <param name="newRepairPointId">newRepairPointId</param>
        /// <param name="newType">newType</param>
        /// <param name="newReamDistance">newReamDistance</param>
        /// <param name="newReamDate">newReamDate</param>
        /// <param name="newLinerDistance">newLinerDistance</param>
        /// <param name="newDirection">newDirection</param>
        /// <param name="newReinstates">newReinstates</param>
        /// <param name="newLtmh">newLtmh</param>
        /// <param name="newVtmh">newVtmh</param>
        /// <param name="newDistance">newDistance</param>
        /// <param name="newSize_">newSize_</param>
        /// <param name="newInstallDate">newInstallDate</param>
        /// <param name="newMhShot">newMhShot</param>
        /// <param name="newGroutDistance">newGroutDistance</param>
        /// <param name="newGroutDate">newGroutDate</param>
        /// <param name="newApproval">newApproval</param>
        /// <param name="newExtraRepair">newExtraRepair</param>
        /// <param name="newCancelled">newCancelled</param>
        /// <param name="newComments">newComments</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newDefectQualifier">newDefectQualifer</param>
        /// <param name="newDefectDetails">newDefectDetails</param>
        /// <param name="newLength">newLength</param>
        /// <returns>rowsAffected</returns>
        public int Update(int originalWorkId, string originalRepairPointId, string originalType, string originalReamDistance, DateTime? originalReamDate, string originalLinerDistance, string originalDirection, int? originalReinstates, string originalLtmh, string originalVtmh, string originalDistance, string originalSize_, DateTime? originalInstallDate, string originalMhShot, string originalGroutDistance, DateTime? originalGroutDate, string originalApproval, bool originalExtraRepair, bool originalCancelled, string originalComments, bool originalDeleted, int originalCompanyId, string originalDefectQualifier, string originalDefectDetails, string originalLength, int newWorkId, string newRepairPointId, string newType, string newReamDistance, DateTime? newReamDate, string newLinerDistance, string newDirection, int? newReinstates, string newLtmh, string newVtmh, string newDistance, string newSize_, DateTime? newInstallDate, string newMhShot, string newGroutDistance, DateTime? newGroutDate, string newApproval, bool newExtraRepair, bool newCancelled, string newComments, bool newDeleted, int newCompanyId, string newDefectQualifier, string newDefectDetails, string newLength, DateTime? originalReinstateDate, DateTime? newReinstateDate)
        {
            SqlParameter originalWorkIdParameter = new SqlParameter("Original_WorkID", originalWorkId);
            SqlParameter originalRepairPointIdParameter = new SqlParameter("Original_RepairPointID", originalRepairPointId);
            SqlParameter originalTypeParameter = (originalType.Trim() != "") ? new SqlParameter("Original_Type", originalType.Trim()) : new SqlParameter("Original_Type", DBNull.Value);
            SqlParameter originalReamDistanceParameter = (originalReamDistance.Trim() != "") ? new SqlParameter("Original_ReamDistance", originalReamDistance.Trim()) : new SqlParameter("Original_ReamDistance", DBNull.Value);
            SqlParameter originalReamDateParameter = (originalReamDate.HasValue) ? new SqlParameter("Original_ReamDate", originalReamDate) : new SqlParameter("Original_ReamDate", DBNull.Value);
            SqlParameter originalLinerDistanceParameter = (originalLinerDistance.Trim() != "") ? new SqlParameter("Original_LinerDistance", originalLinerDistance.Trim()) : new SqlParameter("Original_LinerDistance", DBNull.Value);
            SqlParameter originalDirectionParameter = (originalDirection.Trim() != "") ? new SqlParameter("Original_Direction", originalDirection.Trim()) : new SqlParameter("Original_Direction", DBNull.Value);
            SqlParameter originalReinstatesParameter = (originalReinstates.HasValue) ? new SqlParameter("Original_Reinstates", originalReinstates) : new SqlParameter("Original_Reinstates", DBNull.Value);
            SqlParameter originalLtmhParameter = (originalLtmh.Trim() != "") ? new SqlParameter("Original_LTMH", originalLtmh.Trim()) : new SqlParameter("Original_LTMH", DBNull.Value);
            SqlParameter originalVtmhParameter = (originalVtmh.Trim() != "") ? new SqlParameter("Original_VTMH", originalVtmh.Trim()) : new SqlParameter("Original_VTMH", DBNull.Value);
            SqlParameter originalDistanceParameter = (originalDistance.Trim() != "") ? new SqlParameter("Original_Distance", originalDistance.Trim()) : new SqlParameter("Original_Distance", DBNull.Value);
            SqlParameter originalSize_Parameter = (originalSize_.Trim() != "") ? new SqlParameter("Original_Size_", originalSize_.Trim()) : new SqlParameter("Original_Size_", DBNull.Value);
            SqlParameter originalInstallDateParameter = (originalInstallDate.HasValue) ? new SqlParameter("Original_InstallDate", originalInstallDate) : new SqlParameter("Original_InstallDate", DBNull.Value);
            SqlParameter originalMhShotParameter = (originalMhShot.Trim() != "") ? new SqlParameter("Original_MHShot", originalMhShot.Trim()) : new SqlParameter("Original_MHShot", DBNull.Value);
            SqlParameter originalGroutDistanceParameter = (originalGroutDistance.Trim() != "") ? new SqlParameter("Original_GroutDistance", originalGroutDistance.Trim()) : new SqlParameter("Original_GroutDistance", DBNull.Value);
            SqlParameter originalGroutDateParameter = (originalGroutDate.HasValue) ? new SqlParameter("Original_GroutDate", originalGroutDate) : new SqlParameter("Original_GroutDate", DBNull.Value);
            SqlParameter originalApprovalParameter = (originalApproval.Trim() != "") ? new SqlParameter("Original_Approval", originalApproval.Trim()) : new SqlParameter("Original_Approval", DBNull.Value);
            SqlParameter originalExtraRepairParamter = new SqlParameter("Original_ExtraRepair", originalExtraRepair);
            SqlParameter originalCancelledParameter = new SqlParameter("Original_Cancelled", originalCancelled);
            SqlParameter originalCommentsParameter = (originalComments.Trim() != "") ? new SqlParameter("Original_Comments", originalComments.Trim()) : new SqlParameter("Original_Comments", DBNull.Value);
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter originalDefectQualifierParameter = (originalDefectQualifier.Trim() != "") ? new SqlParameter("Original_DefectQualifier", originalDefectQualifier.Trim()) : new SqlParameter("Original_DefectQualifier", DBNull.Value);
            SqlParameter originalDefectDetailsParameter = (originalDefectDetails.Trim() != "") ? new SqlParameter("Original_DefectDetails", originalDefectDetails.Trim()) : new SqlParameter("Original_DefectDetails", DBNull.Value);
            SqlParameter originalLengthParameter = (originalLength.Trim() != "") ? new SqlParameter("Original_Length", originalLength.Trim()) : new SqlParameter("Original_Length", DBNull.Value);
            SqlParameter OriginalReinstateDateParameter = (originalReinstateDate.HasValue) ? new SqlParameter("Original_ReinstateDate", originalReinstateDate) : new SqlParameter("Original_ReinstateDate", DBNull.Value);

            SqlParameter newWorkIdParameter = new SqlParameter("WorkID", newWorkId);
            SqlParameter newRepairPointIdParameter = new SqlParameter("RepairPointID", newRepairPointId);
            SqlParameter newTypeParameter = (newType.Trim() != "") ? new SqlParameter("Type", newType.Trim()) : new SqlParameter("Type", DBNull.Value);
            SqlParameter newReamDistanceParameter = (newReamDistance.Trim() != "") ? new SqlParameter("ReamDistance", newReamDistance.Trim()) : new SqlParameter("ReamDistance", DBNull.Value);
            SqlParameter newReamDateParameter = (newReamDate.HasValue) ? new SqlParameter("ReamDate", newReamDate) : new SqlParameter("ReamDate", DBNull.Value);
            SqlParameter newLinerDistanceParameter = (newLinerDistance.Trim() != "") ? new SqlParameter("LinerDistance", newLinerDistance.Trim()) : new SqlParameter("LinerDistance", DBNull.Value);
            SqlParameter newDirectionParameter = (newDirection.Trim() != "") ? new SqlParameter("Direction", newDirection.Trim()) : new SqlParameter("Direction", DBNull.Value);
            SqlParameter newReinstatesParameter = (newReinstates.HasValue) ? new SqlParameter("Reinstates", newReinstates) : new SqlParameter("Reinstates", DBNull.Value);
            SqlParameter newLtmhParameter = (newLtmh.Trim() != "") ? new SqlParameter("LTMH", newLtmh.Trim()) : new SqlParameter("LTMH", DBNull.Value);
            SqlParameter newVtmhParameter = (newVtmh.Trim() != "") ? new SqlParameter("VTMH", newVtmh.Trim()) : new SqlParameter("VTMH", DBNull.Value);
            SqlParameter newDistanceParameter = (newDistance.Trim() != "") ? new SqlParameter("Distance", newDistance.Trim()) : new SqlParameter("Distance", DBNull.Value);
            SqlParameter newSize_Parameter = (newSize_.Trim() != "") ? new SqlParameter("Size_", newSize_.Trim()) : new SqlParameter("Size_", DBNull.Value);
            SqlParameter newInstallDateParameter = (newInstallDate.HasValue) ? new SqlParameter("InstallDate", newInstallDate) : new SqlParameter("InstallDate", DBNull.Value);
            SqlParameter newMhShotParameter = (newMhShot.Trim() != "") ? new SqlParameter("MHShot", newMhShot.Trim()) : new SqlParameter("MHShot", DBNull.Value);
            SqlParameter newGroutDistanceParameter = (newGroutDistance.Trim() != "") ? new SqlParameter("GroutDistance", newGroutDistance.Trim()) : new SqlParameter("GroutDistance", DBNull.Value);
            SqlParameter newGroutDateParameter = (newGroutDate.HasValue) ? new SqlParameter("GroutDate", newGroutDate) : new SqlParameter("GroutDate", DBNull.Value);
            SqlParameter newApprovalParameter = (newApproval.Trim() != "") ? new SqlParameter("Approval", newApproval.Trim()) : new SqlParameter("Approval", DBNull.Value);
            SqlParameter newExtraRepairParamter = new SqlParameter("ExtraRepair", newExtraRepair);
            SqlParameter newCancelledParameter = new SqlParameter("Cancelled", newCancelled);
            SqlParameter newCommentsParameter = (newComments.Trim() != "") ? new SqlParameter("Comments", newComments.Trim()) : new SqlParameter("Comments", DBNull.Value);
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);
            SqlParameter newDefectQualifierParameter = (newDefectQualifier.Trim() != "") ? new SqlParameter("DefectQualifier", newDefectQualifier.Trim()) : new SqlParameter("DefectQualifier", DBNull.Value);
            SqlParameter newDefectDetailsParameter = (newDefectDetails.Trim() != "") ? new SqlParameter("DefectDetails", newDefectDetails.Trim()) : new SqlParameter("DefectDetails", DBNull.Value);
            SqlParameter newLengthParameter = (newLength.Trim() != "") ? new SqlParameter("Length", newLength.Trim()) : new SqlParameter("Length", DBNull.Value);
            SqlParameter newReinstateDateParameter = (newReinstateDate.HasValue) ? new SqlParameter("ReinstateDate", newReinstateDate) : new SqlParameter("ReinstateDate", DBNull.Value);

            string command = "UPDATE [dbo].[LFS_WORK_POINT_REPAIRS_REPAIR] SET [WorkID] = @WorkID, [RepairPointID] = @RepairPointID, [Type] = @Type, [ReamDistance] = @ReamDistance, " +
                " [ReamDate] = @ReamDate, [LinerDistance] = @LinerDistance, [Direction] = @Direction, [Reinstates] = @Reinstates, [LTMH] = @LTMH, [VTMH] = @VTMH, " +
                " [Distance] = @Distance, [Size_] = @Size_, [InstallDate] = @InstallDate, [MHShot] = @MHShot, [GroutDistance] = @GroutDistance, [GroutDate] = @GroutDate, [Approval] = @Approval, "+
                " [ExtraRepair] = @ExtraRepair, [Cancelled] = @Cancelled, [Comments] = @Comments, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID, " +
                " [DefectQualifier] = @DefectQualifier, [DefectDetails] = @DefectDetails, [Length] = @Length, [ReinstateDate] = @ReinstateDate" +
                " WHERE (([WorkID] = @Original_WorkID) AND ([RepairPointID] = @Original_RepairPointID) AND ([COMPANY_ID] = @Original_COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalWorkIdParameter, originalRepairPointIdParameter, originalTypeParameter, originalReamDistanceParameter, originalReamDateParameter, originalLinerDistanceParameter, originalDirectionParameter, originalReinstatesParameter, originalLtmhParameter, originalVtmhParameter, originalDistanceParameter, originalSize_Parameter, originalInstallDateParameter, originalMhShotParameter, originalGroutDistanceParameter, originalGroutDateParameter, originalApprovalParameter, originalExtraRepairParamter, originalCancelledParameter, originalCommentsParameter, originalDeletedParameter, originalCompanyIdParameter, originalDefectQualifierParameter, originalDefectDetailsParameter, originalLengthParameter, newWorkIdParameter, newRepairPointIdParameter, newTypeParameter, newReamDistanceParameter, newReamDateParameter, newLinerDistanceParameter, newDirectionParameter, newReinstatesParameter, newLtmhParameter, newVtmhParameter, newDistanceParameter, newSize_Parameter, newInstallDateParameter, newMhShotParameter, newGroutDistanceParameter, newGroutDateParameter, newApprovalParameter, newExtraRepairParamter, newCancelledParameter, newCommentsParameter, newDeletedParameter, newCompanyIdParameter, newDefectQualifierParameter, newDefectDetailsParameter, newLengthParameter, OriginalReinstateDateParameter, newReinstateDateParameter);

            return rowsAffected;
        }



        /// <summary>
        /// UpdateSize
        /// </summary>
        /// <param name="originalSize_">originalSize_</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// 
        /// <param name="newSize_">newSize_</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <returns>rowsAffected</returns>
        public int UpdateSize(string originalSize_, int originalCompanyId, string newSize_, int newCompanyId)
        {
            SqlParameter originalSize_Parameter = (originalSize_.Trim() != "") ? new SqlParameter("Original_Size_", originalSize_.Trim()) : new SqlParameter("Original_Size_", DBNull.Value);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);

            SqlParameter newSize_Parameter = (newSize_.Trim() != "") ? new SqlParameter("Size_", newSize_.Trim()) : new SqlParameter("Size_", DBNull.Value);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);

            string command = "UPDATE [dbo].[LFS_WORK_POINT_REPAIRS_REPAIR] SET [Size_] = @Size_ " +
                " WHERE (([Size_] = @Original_Size_) AND ([COMPANY_ID] = @Original_COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalSize_Parameter, originalCompanyIdParameter, newSize_Parameter, newCompanyIdParameter);

            return rowsAffected;
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="originalWorkId">originalWorkId</param>
        /// <param name="originalRepairPointId">originalRepairPointId</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <returns>rowsAffected</returns>
        public int Delete(int originalWorkId, string originalRepairPointId, int originalCompanyId)
        {
            SqlParameter originalWorkIdParameter = new SqlParameter("@WorkID", originalWorkId);
            SqlParameter originalRepairPointIdParameter = new SqlParameter("@RepairPointID", originalRepairPointId);
            SqlParameter originalCompanyIdParameter = new SqlParameter("COMPANY_ID", originalCompanyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_WORK_POINT_REPAIRS_REPAIR] SET  [Deleted] = @Deleted  " +
                             " WHERE (([WorkID] = @WorkID) AND ([RepairPointID] = @RepairPointID) AND " +
                             "  ([COMPANY_ID] = @COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalWorkIdParameter, originalRepairPointIdParameter, originalCompanyIdParameter, deletedParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }



    }
}