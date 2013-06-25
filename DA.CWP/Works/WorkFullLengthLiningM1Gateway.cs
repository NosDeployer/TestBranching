using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.CWP.Works
{
    /// <summary>
    /// WorkFullLengthLiningM1Gateway
    /// </summary>
    public class WorkFullLengthLiningM1Gateway : DataTableGateway
    {
        ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkFullLengthLiningM1Gateway() : base("LFS_WORK_FULLLENGTHLINING_M1")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkFullLengthLiningM1Gateway(DataSet data) : base(data, "LFS_WORK_FULLLENGTHLINING_M1")
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
            tableMapping.DataSetTable = "LFS_WORK_FULLLENGTHLINING_M1";
            tableMapping.ColumnMappings.Add("WorkID", "WorkID");
            tableMapping.ColumnMappings.Add("MeasurementTakenBy", "MeasurementTakenBy");
            tableMapping.ColumnMappings.Add("TrafficControl", "TrafficControl");
            tableMapping.ColumnMappings.Add("SiteDetails", "SiteDetails");
            tableMapping.ColumnMappings.Add("PipeSizeChange", "PipeSizeChange");
            tableMapping.ColumnMappings.Add("StandardBypass", "StandardBypass");
            tableMapping.ColumnMappings.Add("StandardBypassComments", "StandardBypassComments");
            tableMapping.ColumnMappings.Add("TrafficControlDetails", "TrafficControlDetails");
            tableMapping.ColumnMappings.Add("MeasurementType", "MeasurementType");
            tableMapping.ColumnMappings.Add("MeasurementFromMH", "MeasurementFromMH");
            tableMapping.ColumnMappings.Add("VideoDoneFromMH", "VideoDoneFromMH");
            tableMapping.ColumnMappings.Add("VideoDoneToMH", "VideoDoneToMH");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("AccessType", "AccessType");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = @"DELETE FROM [dbo].[LFS_WORK_FULLLENGTHLINING_M1] WHERE (([WorkID] = @Original_WorkID) AND ((@IsNull_MeasurementTakenBy = 1 AND [MeasurementTakenBy] IS NULL) OR ([MeasurementTakenBy] = @Original_MeasurementTakenBy)) AND ((@IsNull_TrafficControl = 1 AND [TrafficControl] IS NULL) OR ([TrafficControl] = @Original_TrafficControl)) AND ((@IsNull_SiteDetails = 1 AND [SiteDetails] IS NULL) OR ([SiteDetails] = @Original_SiteDetails)) AND ([PipeSizeChange] = @Original_PipeSizeChange) AND ([StandardBypass] = @Original_StandardBypass) AND ((@IsNull_MeasurementType = 1 AND [MeasurementType] IS NULL) OR ([MeasurementType] = @Original_MeasurementType)) AND ((@IsNull_MeasurementFromMH = 1 AND [MeasurementFromMH] IS NULL) OR ([MeasurementFromMH] = @Original_MeasurementFromMH)) AND ((@IsNull_VideoDoneFromMH = 1 AND [VideoDoneFromMH] IS NULL) OR ([VideoDoneFromMH] = @Original_VideoDoneFromMH)) AND ((@IsNull_VideoDoneToMH = 1 AND [VideoDoneToMH] IS NULL) OR ([VideoDoneToMH] = @Original_VideoDoneToMH)) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND ((@IsNull_AccessType = 1 AND [AccessType] IS NULL) OR ([AccessType] = @Original_AccessType)))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_WorkID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_MeasurementTakenBy", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MeasurementTakenBy", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MeasurementTakenBy", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MeasurementTakenBy", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_TrafficControl", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TrafficControl", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TrafficControl", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TrafficControl", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_SiteDetails", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SiteDetails", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_SiteDetails", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SiteDetails", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_PipeSizeChange", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PipeSizeChange", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_StandardBypass", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StandardBypass", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_MeasurementType", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MeasurementType", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MeasurementType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MeasurementType", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_MeasurementFromMH", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MeasurementFromMH", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MeasurementFromMH", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MeasurementFromMH", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_VideoDoneFromMH", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VideoDoneFromMH", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_VideoDoneFromMH", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VideoDoneFromMH", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_VideoDoneToMH", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VideoDoneToMH", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_VideoDoneToMH", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VideoDoneToMH", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_AccessType", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AccessType", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_AccessType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AccessType", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            
            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_WORK_FULLLENGTHLINING_M1] ([WorkID], [MeasurementTakenBy], [TrafficControl], [SiteDetails], [PipeSizeChange], [StandardBypass], [StandardBypassComments], [TrafficControlDetails], [MeasurementType], [MeasurementFromMH], [VideoDoneFromMH], [VideoDoneToMH], [Deleted], [COMPANY_ID], [AccessType]) VALUES (@WorkID, @MeasurementTakenBy, @TrafficControl, @SiteDetails, @PipeSizeChange, @StandardBypass, @StandardBypassComments, @TrafficControlDetails, @MeasurementType, @MeasurementFromMH, @VideoDoneFromMH, @VideoDoneToMH, @Deleted, @COMPANY_ID, @AccessType);
SELECT WorkID, MeasurementTakenBy, TrafficControl, SiteDetails, PipeSizeChange, StandardBypass, StandardBypassComments, TrafficControlDetails, MeasurementType, MeasurementFromMH, VideoDoneFromMH, VideoDoneToMH, Deleted, COMPANY_ID, AccessType FROM LFS_WORK_FULLLENGTHLINING_M1 WHERE (WorkID = @WorkID)";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@WorkID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MeasurementTakenBy", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MeasurementTakenBy", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TrafficControl", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TrafficControl", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@SiteDetails", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SiteDetails", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PipeSizeChange", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PipeSizeChange", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@StandardBypass", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StandardBypass", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@StandardBypassComments", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StandardBypassComments", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TrafficControlDetails", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TrafficControlDetails", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MeasurementType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MeasurementType", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MeasurementFromMH", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MeasurementFromMH", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@VideoDoneFromMH", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VideoDoneFromMH", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@VideoDoneToMH", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VideoDoneToMH", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@AccessType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AccessType", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));

            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[LFS_WORK_FULLLENGTHLINING_M1] SET [WorkID] = @WorkID, [MeasurementT" +
                "akenBy] = @MeasurementTakenBy, [TrafficControl] = @TrafficControl, [SiteDetails]" +
                " = @SiteDetails, [PipeSizeChange] = @PipeSizeChange, [StandardBypass] = @Standar" +
                "dBypass, [StandardBypassComments] = @StandardBypassComments, [TrafficControlDeta" +
                "ils] = @TrafficControlDetails, [MeasurementType] = @MeasurementType, [Measuremen" +
                "tFromMH] = @MeasurementFromMH, [VideoDoneFromMH] = @VideoDoneFromMH, [VideoDoneT" +
                "oMH] = @VideoDoneToMH, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID, [Access" +
                "Type] = @AccessType WHERE (([WorkID] = @Original_WorkID) AND ((@IsNull_Measureme" +
                "ntTakenBy = 1 AND [MeasurementTakenBy] IS NULL) OR ([MeasurementTakenBy] = @Orig" +
                "inal_MeasurementTakenBy)) AND ((@IsNull_TrafficControl = 1 AND [TrafficControl] " +
                "IS NULL) OR ([TrafficControl] = @Original_TrafficControl)) AND ((@IsNull_SiteDet" +
                "ails = 1 AND [SiteDetails] IS NULL) OR ([SiteDetails] = @Original_SiteDetails)) " +
                "AND ([PipeSizeChange] = @Original_PipeSizeChange) AND ([StandardBypass] = @Origi" +
                "nal_StandardBypass) AND ((@IsNull_MeasurementType = 1 AND [MeasurementType] IS N" +
                "ULL) OR ([MeasurementType] = @Original_MeasurementType)) AND ((@IsNull_Measureme" +
                "ntFromMH = 1 AND [MeasurementFromMH] IS NULL) OR ([MeasurementFromMH] = @Origina" +
                "l_MeasurementFromMH)) AND ((@IsNull_VideoDoneFromMH = 1 AND [VideoDoneFromMH] IS" +
                " NULL) OR ([VideoDoneFromMH] = @Original_VideoDoneFromMH)) AND ((@IsNull_VideoDo" +
                "neToMH = 1 AND [VideoDoneToMH] IS NULL) OR ([VideoDoneToMH] = @Original_VideoDon" +
                "eToMH)) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPAN" +
                "Y_ID) AND ((@IsNull_AccessType = 1 AND [AccessType] IS NULL) OR ([AccessType] = " +
                "@Original_AccessType)));\r\nSELECT WorkID, MeasurementTakenBy, TrafficControl, Sit" +
                "eDetails, PipeSizeChange, StandardBypass, StandardBypassComments, TrafficControl" +
                "Details, MeasurementType, MeasurementFromMH, VideoDoneFromMH, VideoDoneToMH, Del" +
                "eted, COMPANY_ID, AccessType FROM LFS_WORK_FULLLENGTHLINING_M1 WHERE (WorkID = @" +
                "WorkID)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@WorkID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MeasurementTakenBy", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MeasurementTakenBy", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TrafficControl", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TrafficControl", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@SiteDetails", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SiteDetails", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PipeSizeChange", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PipeSizeChange", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@StandardBypass", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StandardBypass", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@StandardBypassComments", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StandardBypassComments", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TrafficControlDetails", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TrafficControlDetails", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MeasurementType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MeasurementType", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MeasurementFromMH", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MeasurementFromMH", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@VideoDoneFromMH", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VideoDoneFromMH", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@VideoDoneToMH", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VideoDoneToMH", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@AccessType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AccessType", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_WorkID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_MeasurementTakenBy", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MeasurementTakenBy", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MeasurementTakenBy", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MeasurementTakenBy", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_TrafficControl", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TrafficControl", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TrafficControl", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TrafficControl", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_SiteDetails", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SiteDetails", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_SiteDetails", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SiteDetails", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_PipeSizeChange", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PipeSizeChange", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_StandardBypass", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StandardBypass", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_MeasurementType", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MeasurementType", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MeasurementType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MeasurementType", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_MeasurementFromMH", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MeasurementFromMH", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MeasurementFromMH", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MeasurementFromMH", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_VideoDoneFromMH", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VideoDoneFromMH", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_VideoDoneFromMH", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VideoDoneFromMH", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_VideoDoneToMH", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VideoDoneToMH", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_VideoDoneToMH", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VideoDoneToMH", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_AccessType", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AccessType", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_AccessType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AccessType", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
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
            FillDataWithStoredProcedure("LFS_CWP_WORKFULLLENGTHLININGM1GATEWAY_LOADBYWORKID", new SqlParameter("@workId", workId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int workId)
        {
            string filter = string.Format("WorkID = {0}", workId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.CWP.Works.WorkFullLengthLiningM1Gateway.GetRow");
            }
        }



        /// <summary>
        /// GetTrafficControl. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>TrafficControl or EMPTY</returns>
        public string GetTrafficControl(int workId)
        {
            if (GetRow(workId).IsNull("TrafficControl"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["TrafficControl"];
            }
        }



        /// <summary>
        /// GetSiteDetails. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>SiteDetails or EMPTY</returns>
        public string GetSiteDetails(int workId)
        {
            if (GetRow(workId).IsNull("SiteDetails"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["SiteDetails"];
            }
        }



        /// <summary>
        /// GetPipeSizeChange. 
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>PipeSizeChange</returns>
        public bool GetPipeSizeChange(int workId)
        {
            if (GetRow(workId).IsNull("PipeSizeChange"))
            {
                return false;
            }
            else
            {
                return (bool)GetRow(workId)["PipeSizeChange"];
            }

        }



        /// <summary>
        /// GetStandardBypass. 
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>StandardBypass</returns>
        public bool GetStandardBypass(int workId)
        {
            if (GetRow(workId).IsNull("StandardBypass"))
            {
                return false;
            }
            else
            {
                return (bool)GetRow(workId)["StandardBypass"];
            }
        }



        /// <summary>
        /// GetStandardBypassComments. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>StandardBypassComments or EMPTY</returns>
        public string GetStandardBypassComments(int workId)
        {
            if (GetRow(workId).IsNull("StandardBypassComments"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["StandardBypassComments"];
            }
        }



        /// <summary>
        /// GetTrafficControlDetails. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>TrafficControlDetails or EMPTY</returns>
        public string GetTrafficControlDetails(int workId)
        {
            if (GetRow(workId).IsNull("TrafficControlDetails"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["TrafficControlDetails"];
            }
        }



        /// <summary>
        /// GetMeasurementType. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>MeasurementType or EMPTY</returns>
        public string GetMeasurementType(int workId)
        {
            if (GetRow(workId).IsNull("MeasurementType"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["MeasurementType"];
            }
        }



        /// <summary>
        /// GetMeasurementTakenBy. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>MeasurementTakenBy or EMPTY</returns>
        public string GetMeasurementTakenBy(int workId)
        {
            if (GetRow(workId).IsNull("MeasurementTakenBy"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["MeasurementTakenBy"];
            }
        }



        /// <summary>
        /// GetMeasurementFromMh. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>MeasurementFromMH or EMPTY</returns>
        public string GetMeasurementFromMh(int workId)
        {
            if (GetRow(workId).IsNull("MeasurementFromMH"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["MeasurementFromMH"];
            }
        }



        /// <summary>
        /// GetVideoDoneFromMh. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>VideoDoneFromMH or EMPTY</returns>
        public string GetVideoDoneFromMh(int workId)
        {
            if (GetRow(workId).IsNull("VideoDoneFromMH"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["VideoDoneFromMH"];
            }
        }



        /// <summary>
        /// GetVideoDoneToMh. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>VideoDoneToMH or EMPTY</returns>
        public string GetVideoDoneToMh(int workId)
        {
            if (GetRow(workId).IsNull("VideoDoneToMH"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["VideoDoneToMH"];
            }
        }
        

        
        /// <summary>
        /// GetDeleted. 
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Deleted</returns>
        public bool GetDeleted(int workId)
        {
            return (bool)GetRow(workId)["Deleted"];
        }



        /// <summary>
        /// GetAccessType. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>AccessType or EMPTY</returns>
        public string GetAccessType(int workId)
        {
            if (GetRow(workId).IsNull("AccessType"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["AccessType"];
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROWS
        //

        /// <summary>
        /// Insert a Full Length Lining - M1 Work (direct to DB)
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="measurementTakenBy">measurementTakenBy</param>
        /// <param name="trafficControl">trafficControl</param>
        /// <param name="siteDetails">siteDetails</param>
        /// <param name="pipeSizeChange">pipeSizeChange</param>
        /// <param name="standardBypass">standardBypass</param>        
        /// <param name="standardBypassComments">standardBypassComments</param>
        /// <param name="trafficControlDetails">trafficControlDetails</param>
        /// <param name="measurementType">measurementType</param>
        /// <param name="measurementFromMh">measurementFromMh</param>
        /// <param name="videoDoneFromMh">videoDoneFromMh</param>
        /// <param name="videoDoneToMh">videoDoneToMh</param> 
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="accessType">accessType</param>
        /// <returns>rowsAffected</returns>
        public int Insert(int workId, string measurementTakenBy, string trafficControl, string siteDetails, bool pipeSizeChange, bool standardBypass, string standardBypassComments, string trafficControlDetails, string measurementType,  string measurementFromMh, string videoDoneFromMh, string videoDoneToMh, bool deleted, int companyId, string accessType)
        {
            SqlParameter workIdParameter = new SqlParameter("WorkID", workId);
            SqlParameter measurementTakenByParameter = (measurementTakenBy.Trim() != "") ? new SqlParameter("MeasurementTakenBy", measurementTakenBy.Trim()) : new SqlParameter("MeasurementTakenBy", DBNull.Value);
            SqlParameter trafficControlParameter = (trafficControl.Trim() != "") ? new SqlParameter("TrafficControl", trafficControl.Trim()) : new SqlParameter("TrafficControl", DBNull.Value);
            SqlParameter siteDetailsParameter = (siteDetails.Trim() != "") ? new SqlParameter("SiteDetails", siteDetails.Trim()) : new SqlParameter("SiteDetails", DBNull.Value);
            SqlParameter pipeSizeChangeParameter = new SqlParameter("PipeSizeChange", pipeSizeChange);
            SqlParameter standardBypassParameter = new SqlParameter("StandardBypass", standardBypass);            
            SqlParameter standardBypassCommentsParameter = (standardBypassComments.Trim() != "") ? new SqlParameter("StandardBypassComments", standardBypassComments.Trim()) : new SqlParameter("StandardBypassComments", DBNull.Value);
            SqlParameter trafficControlDetailsParameter = (trafficControlDetails.Trim() != "") ? new SqlParameter("TrafficControlDetails", trafficControlDetails.Trim()) : new SqlParameter("TrafficControlDetails", DBNull.Value);
            SqlParameter measurementTypeParameter = (measurementType.Trim() != "") ? new SqlParameter("MeasurementType", measurementType.Trim()) : new SqlParameter("MeasurementType", DBNull.Value);
            SqlParameter measurementFromMhParameter = (measurementFromMh.Trim() != "") ? new SqlParameter("MeasurementFromMH", measurementFromMh.Trim()) : new SqlParameter("MeasurementFromMH", DBNull.Value);
            SqlParameter videoDoneFromMhParameter = (videoDoneFromMh.Trim() != "") ? new SqlParameter("VideoDoneFromMH", videoDoneFromMh.Trim()) : new SqlParameter("VideoDoneFromMH", DBNull.Value);
            SqlParameter videoDoneToMhParameter = (videoDoneToMh.Trim() != "") ? new SqlParameter("VideoDoneToMH", videoDoneToMh.Trim()) : new SqlParameter("VideoDoneToMH", DBNull.Value);
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            SqlParameter accessTypeParameter = new SqlParameter("AccessType", accessType);

            string command = "INSERT INTO [dbo].[LFS_WORK_FULLLENGTHLINING_M1] ([WorkID], [MeasurementTakenBy], "+
            " [TrafficControl], [SiteDetails], [PipeSizeChange], [StandardBypass], [StandardBypassComments], "+
            " [TrafficControlDetails], [MeasurementType], [MeasurementFromMH], [VideoDoneFromMH], "+
            " [VideoDoneToMH], [Deleted], [COMPANY_ID], [AccessType]) "+
            " VALUES (@WorkID, @MeasurementTakenBy, @TrafficControl, @SiteDetails, @PipeSizeChange, "+
            " @StandardBypass, @StandardBypassComments, @TrafficControlDetails, @MeasurementType, "+
            " @MeasurementFromMH, @VideoDoneFromMH, @VideoDoneToMH, @Deleted, @COMPANY_ID, @AccessType)";

            int rowsAffected = (int)ExecuteNonQuery(command, workIdParameter, measurementTakenByParameter, trafficControlParameter, siteDetailsParameter, pipeSizeChangeParameter, standardBypassParameter, standardBypassCommentsParameter, trafficControlDetailsParameter, measurementTypeParameter, measurementFromMhParameter, videoDoneFromMhParameter, videoDoneToMhParameter, deletedParameter, companyIdParameter, accessTypeParameter); 

            return rowsAffected;
        }



        /// <summary>
        /// Update Full Length Lining M1 Work (direct to DB)
        /// </summary>
        /// <param name="originalWorkId">originalWorkId></param>
        /// <param name="originalMeasurementsTakenBy">originalMeasurementsTakenBy</param> 
        /// <param name="originalTrafficControl">originalTrafficControl</param>
        /// <param name="originalSiteDetails">originalSiteDetails</param>
        /// <param name="originalPipeSizeChange">originalPipeSizeChange</param> 
        /// <param name="originalStandardByPass">originalStandardByPass</param>         
        /// <param name="originalStandardBypassComments">originalStandardBypassComments</param> 
        /// <param name="originalTrafficControlDetails">originalTrafficControlDetails</param>  
        /// <param name="originalMeasurementType">originalMeasurementType</param>
        /// <param name="originalMeasurementFromMh">originalMeasurementFromMh</param> 
        /// <param name="originalVideoDoneFromMh">originalVideoDoneFromMh</param>
        /// <param name="originalVideoDoneFromMh">originalVideoDoneToMh</param> 
        /// <param name="originalVideoDoneToMh">originalVideoDoneToMh</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalAccessType">originalAccessType</param>
        /// 
        /// <param name="newWorkId">newWorkId</param>
        /// <param name="newMeasurementsTakenBy">newMeasurementsTakenBy</param> 
        /// <param name="newTrafficControl">newTrafficControl</param>
        /// <param name="newSiteDetails">newSiteDetails</param>
        /// <param name="newPipeSizeChange">newPipeSizeChange</param> 
        /// <param name="newStandardByPass">newStandardByPass</param>         
        /// <param name="newStandardBypassComments">newStandardBypassComments</param> 
        /// <param name="newTrafficControlDetails">newTrafficControlDetails</param> 
        /// <param name="newMeasurementType">newMeasurementType</param>
        /// <param name="newMeasurementFromMh">newMeasurementFromMh</param> 
        /// <param name="newVideoDoneFromMh">newVideoDoneFromMh</param> 
        /// <param name="newVideoDoneToMh">newVideoDoneToMh</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newAccessType">newAccessType</param>
        /// <returns>rowsAffected</returns>
        public int Update(int originalWorkId, string originalMeasurementsTakenBy, string originalTrafficControl, string originalSiteDetails, bool originalPipeSizeChange, bool originalStandardByPass, string originalStandardBypassComments, string originalTrafficControlDetails, string originalMeasurementType, string originalMeasurementFromMh, string originalVideoDoneFromMh, string originalVideoDoneToMh, bool originalDeleted, int originalCompanyId, string originalAccessType, int newWorkId, string newMeasurementsTakenBy, string newTrafficControl, string newSiteDetails, bool newPipeSizeChange, bool newStandardByPass, string newStandardBypassComments, string newTrafficControlDetails, string newMeasurementType, string newMeasurementFromMh, string newVideoDoneFromMh, string newVideoDoneToMh, bool newDeleted, int newCompanyId, string newAccessType)
        {
            SqlParameter originalWorkIdParameter = new SqlParameter("Original_WorkID", originalWorkId);
            SqlParameter originalMeasurementsTakenByParameter = (originalMeasurementsTakenBy != "") ? new SqlParameter("Original_MeasurementTakenBy", originalMeasurementsTakenBy.Trim()) : new SqlParameter("Original_MeasurementTakenBy", DBNull.Value);
            SqlParameter originalTrafficControlParameter = (originalTrafficControl != "") ? new SqlParameter("Original_TrafficControl", originalTrafficControl) : new SqlParameter("Original_TrafficControl", DBNull.Value);
            SqlParameter originalSiteDetailsParameter = (originalSiteDetails != "") ? new SqlParameter("Original_SiteDetails",originalSiteDetails) : new SqlParameter("Original_SiteDetails", DBNull.Value);
            SqlParameter originalPipeSizeChangeParameter = new SqlParameter("Original_PipeSizeChange", originalPipeSizeChange);
            SqlParameter originalStandardByPassParameter = new SqlParameter("Original_StandardBypass", originalStandardByPass);            
            SqlParameter originalStandardBypassCommentsParameter = (originalStandardBypassComments != "") ? new SqlParameter("Original_StandardBypassComments", originalStandardBypassComments.Trim()) : new SqlParameter("Original_StandardBypassComments", DBNull.Value);
            SqlParameter originalTrafficControlDetailsParameter = (originalTrafficControlDetails != "") ? new SqlParameter("Original_TrafficControlDetails", originalTrafficControlDetails.Trim()) : new SqlParameter("Original_TrafficControlDetails", DBNull.Value);
            SqlParameter originalMeasurementTypeParameter = (originalMeasurementType.Trim() != "") ? new SqlParameter("Original_MeasurementType", originalMeasurementType.Trim()) : new SqlParameter("Original_MeasurementType", DBNull.Value);
            SqlParameter originalMeasurementFromMhParameter = (originalMeasurementFromMh.Trim() != "") ? new SqlParameter("Original_MeasurementFromMH", originalMeasurementFromMh.Trim()) : new SqlParameter("Original_MeasurementFromMH", DBNull.Value);
            SqlParameter originalVideoDoneFromMhParameter = (originalVideoDoneFromMh.Trim() != "") ? new SqlParameter("Original_VideoDoneFromMH", originalVideoDoneFromMh.Trim()) : new SqlParameter("Original_VideoDoneFromMH", DBNull.Value);
            SqlParameter originalVideoDoneToMhParameter = (originalVideoDoneToMh.Trim() != "") ? new SqlParameter("Original_VideoDoneToMH", originalVideoDoneToMh.Trim()) : new SqlParameter("Original_VideoDoneToMH", DBNull.Value);
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter originalAccessTypeParameter = (originalAccessType != "") ? new SqlParameter("Original_AccessType", originalAccessType) : new SqlParameter("Original_AccessType", DBNull.Value);
                                    
            SqlParameter newWorkIdParameter = new SqlParameter("WorkID", newWorkId);                        
            SqlParameter newMeasurementsTakenByParameter = (newMeasurementsTakenBy != "") ? new SqlParameter("MeasurementTakenBy", newMeasurementsTakenBy) : new SqlParameter("MeasurementTakenBy", DBNull.Value);
            SqlParameter newTrafficControlParameter = (newTrafficControl != "") ? new SqlParameter("TrafficControl", newTrafficControl) : new SqlParameter("TrafficControl", DBNull.Value);            
            SqlParameter newSiteDetailsParameter = (newSiteDetails != "") ? new SqlParameter("SiteDetails", newSiteDetails) : new SqlParameter("SiteDetails", DBNull.Value);
            SqlParameter newPipeSizeChangeParameter = new SqlParameter("PipeSizeChange", newPipeSizeChange);
            SqlParameter newStandardByPassParameter = new SqlParameter("StandardBypass", newStandardByPass);            
            SqlParameter newStandardBypassCommentsParameter = (newStandardBypassComments != "") ? new SqlParameter("StandardBypassComments", newStandardBypassComments.Trim()) : new SqlParameter("StandardBypassComments", DBNull.Value);
            SqlParameter newTrafficControlDetailsParameter = (newTrafficControlDetails != "") ? new SqlParameter("TrafficControlDetails", newTrafficControlDetails.Trim()) : new SqlParameter("TrafficControlDetails", DBNull.Value);
            SqlParameter newMeasurementTypeParameter = (newMeasurementType.Trim() != "") ? new SqlParameter("MeasurementType", newMeasurementType.Trim()) : new SqlParameter("MeasurementType", DBNull.Value);
            SqlParameter newMeasurementFromMhParameter = (newMeasurementFromMh.Trim() != "") ? new SqlParameter("MeasurementFromMH", newMeasurementFromMh.Trim()) : new SqlParameter("MeasurementFromMH", DBNull.Value);
            SqlParameter newVideoDoneFromMhParameter = (newVideoDoneFromMh.Trim() != "") ? new SqlParameter("VideoDoneFromMH", newVideoDoneFromMh.Trim()) : new SqlParameter("VideoDoneFromMH", DBNull.Value);
            SqlParameter newVideoDoneToMhParameter = (newVideoDoneToMh.Trim() != "") ? new SqlParameter("VideoDoneToMH", newVideoDoneToMh.Trim()) : new SqlParameter("VideoDoneToMH", DBNull.Value);
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);
            SqlParameter newAccessTypeParameter = (newAccessType != "") ? new SqlParameter("AccessType", newAccessType) : new SqlParameter("AccessType", DBNull.Value);
                        
            string command = "UPDATE [dbo].[LFS_WORK_FULLLENGTHLINING_M1] SET "+
                "[MeasurementTakenBy] = @MeasurementTakenBy, [TrafficControl] = @TrafficControl, [SiteDetails]" +
                " = @SiteDetails, [PipeSizeChange] = @PipeSizeChange, [StandardBypass] = @Standar" +
                "dBypass,  [StandardBypassComments] " +
                "= @StandardBypassComments, [TrafficControlDetails] = @TrafficControlDetails, [Me" +
                "asurementType] = @MeasurementType, [MeasurementFromMH] = @MeasurementFromMH, [Vi" +
                "deoDoneFromMH] = @VideoDoneFromMH, [VideoDoneToMH] = @VideoDoneToMH, [AccessType] = @AccessType "+                
                " WHERE ([WorkID] = @Original_WorkID) AND ([Deleted] = @Original_Deleted) AND " +
                " ([COMPANY_ID] = @Original_COMPANY_ID) ";

            int rowsAffected = (int)ExecuteNonQuery(command, originalWorkIdParameter, originalMeasurementsTakenByParameter, originalTrafficControlParameter, originalSiteDetailsParameter, originalPipeSizeChangeParameter, originalStandardByPassParameter, originalStandardBypassCommentsParameter, originalTrafficControlDetailsParameter, originalMeasurementTypeParameter, originalMeasurementFromMhParameter, originalVideoDoneFromMhParameter, originalVideoDoneToMhParameter, originalDeletedParameter, originalCompanyIdParameter, originalAccessTypeParameter, newWorkIdParameter, newMeasurementsTakenByParameter, newTrafficControlParameter, newSiteDetailsParameter, newPipeSizeChangeParameter, newStandardByPassParameter, newStandardBypassCommentsParameter, newTrafficControlDetailsParameter, newMeasurementTypeParameter, newMeasurementFromMhParameter, newVideoDoneFromMhParameter, newVideoDoneToMhParameter,  newDeletedParameter, newCompanyIdParameter, newAccessTypeParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

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

            string command = "UPDATE [dbo].[LFS_WORK_FULLLENGTHLINING_M1] SET  [Deleted] = @Deleted  " +
                             " WHERE (([WorkID] = @Original_WorkID) AND " +
                             "  ([COMPANY_ID] = @Original_COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery( command, originalWorkIdParameter, originalCompanyIdParameter, deletedParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }



    }
}