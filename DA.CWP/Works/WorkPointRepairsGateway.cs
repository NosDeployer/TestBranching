using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.Works
{
    public class WorkPointRepairsGateway : DataTableGateway
    {
        ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkPointRepairsGateway() : base("LFS_WORK_POINT_REPAIRS")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkPointRepairsGateway(DataSet data)
            : base(data, "LFS_WORK_POINT_REPAIRS")
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
            tableMapping.DataSetTable = "LFS_WORK_POINT_REPAIRS";
            tableMapping.ColumnMappings.Add("WorkID", "WorkID");
            tableMapping.ColumnMappings.Add("ClientID", "ClientID");
            tableMapping.ColumnMappings.Add("MeasurementTakenBy", "MeasurementTakenBy");
            tableMapping.ColumnMappings.Add("RepairConfirmationDate", "RepairConfirmationDate");
            tableMapping.ColumnMappings.Add("BypassRequired", "BypassRequired");
            tableMapping.ColumnMappings.Add("RoboticDistances", "RoboticDistances");
            tableMapping.ColumnMappings.Add("ProposedLiningDate", "ProposedLiningDate");
            tableMapping.ColumnMappings.Add("DeadlineLiningDate", "DeadlineLiningDate");
            tableMapping.ColumnMappings.Add("FinalVideoDate", "FinalVideoDate");
            tableMapping.ColumnMappings.Add("EstimatedJoints", "EstimatedJoints");
            tableMapping.ColumnMappings.Add("JointsTestSealed", "JointsTestSealed");
            tableMapping.ColumnMappings.Add("IssueIdentified", "IssueIdentified");
            tableMapping.ColumnMappings.Add("IssueLFS", "IssueLFS");
            tableMapping.ColumnMappings.Add("IssueClient", "IssueClient");
            tableMapping.ColumnMappings.Add("IssueSales", "IssueSales");
            tableMapping.ColumnMappings.Add("IssueGivenToClient", "IssueGivenToClient");
            tableMapping.ColumnMappings.Add("IssueResolved", "IssueResolved");
            tableMapping.ColumnMappings.Add("IssueInvestigation", "IssueInvestigation");
            tableMapping.ColumnMappings.Add("RepairID", "RepairID");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[LFS_WORK_POINT_REPAIRS] WHERE (([WorkID] = @Original_WorkID) A" +
                "ND ((@IsNull_ClientID = 1 AND [ClientID] IS NULL) OR ([ClientID] = @Original_Cli" +
                "entID)) AND ((@IsNull_MeasurementTakenBy = 1 AND [MeasurementTakenBy] IS NULL) O" +
                "R ([MeasurementTakenBy] = @Original_MeasurementTakenBy)) AND ((@IsNull_RepairCon" +
                "firmationDate = 1 AND [RepairConfirmationDate] IS NULL) OR ([RepairConfirmationD" +
                "ate] = @Original_RepairConfirmationDate)) AND ([BypassRequired] = @Original_Bypa" +
                "ssRequired) AND ((@IsNull_RoboticDistances = 1 AND [RoboticDistances] IS NULL) O" +
                "R ([RoboticDistances] = @Original_RoboticDistances)) AND ((@IsNull_ProposedLinin" +
                "gDate = 1 AND [ProposedLiningDate] IS NULL) OR ([ProposedLiningDate] = @Original" +
                "_ProposedLiningDate)) AND ((@IsNull_DeadlineLiningDate = 1 AND [DeadlineLiningDa" +
                "te] IS NULL) OR ([DeadlineLiningDate] = @Original_DeadlineLiningDate)) AND ((@Is" +
                "Null_FinalVideoDate = 1 AND [FinalVideoDate] IS NULL) OR ([FinalVideoDate] = @Or" +
                "iginal_FinalVideoDate)) AND ((@IsNull_EstimatedJoints = 1 AND [EstimatedJoints] " +
                "IS NULL) OR ([EstimatedJoints] = @Original_EstimatedJoints)) AND ((@IsNull_Joint" +
                "sTestSealed = 1 AND [JointsTestSealed] IS NULL) OR ([JointsTestSealed] = @Origin" +
                "al_JointsTestSealed)) AND ([IssueIdentified] = @Original_IssueIdentified) AND ([" +
                "IssueLFS] = @Original_IssueLFS) AND ([IssueClient] = @Original_IssueClient) AND " +
                "([IssueSales] = @Original_IssueSales) AND ([IssueGivenToClient] = @Original_Issu" +
                "eGivenToClient) AND ([IssueResolved] = @Original_IssueResolved) AND ([IssueInves" +
                "tigation] = @Original_IssueInvestigation) AND ((@IsNull_RepairID = 1 AND [Repair" +
                "ID] IS NULL) OR ([RepairID] = @Original_RepairID)) AND ([Deleted] = @Original_De" +
                "leted) AND ([COMPANY_ID] = @Original_COMPANY_ID))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_WorkID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_ClientID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ClientID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ClientID", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ClientID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_MeasurementTakenBy", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MeasurementTakenBy", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MeasurementTakenBy", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MeasurementTakenBy", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_RepairConfirmationDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RepairConfirmationDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RepairConfirmationDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RepairConfirmationDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_BypassRequired", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BypassRequired", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_RoboticDistances", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RoboticDistances", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RoboticDistances", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RoboticDistances", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_ProposedLiningDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProposedLiningDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ProposedLiningDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProposedLiningDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DeadlineLiningDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DeadlineLiningDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DeadlineLiningDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DeadlineLiningDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_FinalVideoDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FinalVideoDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_FinalVideoDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FinalVideoDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_EstimatedJoints", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EstimatedJoints", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_EstimatedJoints", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EstimatedJoints", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_JointsTestSealed", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "JointsTestSealed", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_JointsTestSealed", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "JointsTestSealed", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_IssueIdentified", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IssueIdentified", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_IssueLFS", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IssueLFS", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_IssueClient", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IssueClient", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_IssueSales", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IssueSales", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_IssueGivenToClient", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IssueGivenToClient", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_IssueResolved", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IssueResolved", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_IssueInvestigation", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IssueInvestigation", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_RepairID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RepairID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RepairID", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RepairID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_WORK_POINT_REPAIRS] ([WorkID], [ClientID], [MeasurementTakenBy], [RepairConfirmationDate], [BypassRequired], [RoboticDistances], [ProposedLiningDate], [DeadlineLiningDate], [FinalVideoDate], [EstimatedJoints], [JointsTestSealed], [IssueIdentified], [IssueLFS], [IssueClient], [IssueSales], [IssueGivenToClient], [IssueResolved], [IssueInvestigation], [RepairID], [Deleted], [COMPANY_ID]) VALUES (@WorkID, @ClientID, @MeasurementTakenBy, @RepairConfirmationDate, @BypassRequired, @RoboticDistances, @ProposedLiningDate, @DeadlineLiningDate, @FinalVideoDate, @EstimatedJoints, @JointsTestSealed, @IssueIdentified, @IssueLFS, @IssueClient, @IssueSales, @IssueGivenToClient, @IssueResolved, @IssueInvestigation, @RepairID, @Deleted, @COMPANY_ID);
SELECT WorkID, ClientID, MeasurementTakenBy, RepairConfirmationDate, BypassRequired, RoboticDistances, ProposedLiningDate, DeadlineLiningDate, FinalVideoDate, EstimatedJoints, JointsTestSealed, IssueIdentified, IssueLFS, IssueClient, IssueSales, IssueGivenToClient, IssueResolved, IssueInvestigation, RepairID, Deleted, COMPANY_ID FROM LFS_WORK_POINT_REPAIRS WHERE (WorkID = @WorkID)";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@WorkID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ClientID", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ClientID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MeasurementTakenBy", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MeasurementTakenBy", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RepairConfirmationDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RepairConfirmationDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@BypassRequired", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BypassRequired", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RoboticDistances", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RoboticDistances", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ProposedLiningDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProposedLiningDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DeadlineLiningDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DeadlineLiningDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@FinalVideoDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FinalVideoDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@EstimatedJoints", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EstimatedJoints", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@JointsTestSealed", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "JointsTestSealed", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IssueIdentified", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IssueIdentified", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IssueLFS", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IssueLFS", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IssueClient", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IssueClient", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IssueSales", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IssueSales", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IssueGivenToClient", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IssueGivenToClient", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IssueResolved", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IssueResolved", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IssueInvestigation", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IssueInvestigation", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RepairID", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RepairID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            
            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[LFS_WORK_POINT_REPAIRS] SET [WorkID] = @WorkID, [ClientID] = @Clien" +
                "tID, [MeasurementTakenBy] = @MeasurementTakenBy, [RepairConfirmationDate] = @Rep" +
                "airConfirmationDate, [BypassRequired] = @BypassRequired, [RoboticDistances] = @R" +
                "oboticDistances, [ProposedLiningDate] = @ProposedLiningDate, [DeadlineLiningDate" +
                "] = @DeadlineLiningDate, [FinalVideoDate] = @FinalVideoDate, [EstimatedJoints] =" +
                " @EstimatedJoints, [JointsTestSealed] = @JointsTestSealed, [IssueIdentified] = @" +
                "IssueIdentified, [IssueLFS] = @IssueLFS, [IssueClient] = @IssueClient, [IssueSal" +
                "es] = @IssueSales, [IssueGivenToClient] = @IssueGivenToClient, [IssueResolved] =" +
                " @IssueResolved, [IssueInvestigation] = @IssueInvestigation, [RepairID] = @Repai" +
                "rID, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID WHERE (([WorkID] = @Origin" +
                "al_WorkID) AND ((@IsNull_ClientID = 1 AND [ClientID] IS NULL) OR ([ClientID] = @" +
                "Original_ClientID)) AND ((@IsNull_MeasurementTakenBy = 1 AND [MeasurementTakenBy" +
                "] IS NULL) OR ([MeasurementTakenBy] = @Original_MeasurementTakenBy)) AND ((@IsNu" +
                "ll_RepairConfirmationDate = 1 AND [RepairConfirmationDate] IS NULL) OR ([RepairC" +
                "onfirmationDate] = @Original_RepairConfirmationDate)) AND ([BypassRequired] = @O" +
                "riginal_BypassRequired) AND ((@IsNull_RoboticDistances = 1 AND [RoboticDistances" +
                "] IS NULL) OR ([RoboticDistances] = @Original_RoboticDistances)) AND ((@IsNull_P" +
                "roposedLiningDate = 1 AND [ProposedLiningDate] IS NULL) OR ([ProposedLiningDate]" +
                " = @Original_ProposedLiningDate)) AND ((@IsNull_DeadlineLiningDate = 1 AND [Dead" +
                "lineLiningDate] IS NULL) OR ([DeadlineLiningDate] = @Original_DeadlineLiningDate" +
                ")) AND ((@IsNull_FinalVideoDate = 1 AND [FinalVideoDate] IS NULL) OR ([FinalVide" +
                "oDate] = @Original_FinalVideoDate)) AND ((@IsNull_EstimatedJoints = 1 AND [Estim" +
                "atedJoints] IS NULL) OR ([EstimatedJoints] = @Original_EstimatedJoints)) AND ((@" +
                "IsNull_JointsTestSealed = 1 AND [JointsTestSealed] IS NULL) OR ([JointsTestSeale" +
                "d] = @Original_JointsTestSealed)) AND ([IssueIdentified] = @Original_IssueIdenti" +
                "fied) AND ([IssueLFS] = @Original_IssueLFS) AND ([IssueClient] = @Original_Issue" +
                "Client) AND ([IssueSales] = @Original_IssueSales) AND ([IssueGivenToClient] = @O" +
                "riginal_IssueGivenToClient) AND ([IssueResolved] = @Original_IssueResolved) AND " +
                "([IssueInvestigation] = @Original_IssueInvestigation) AND ((@IsNull_RepairID = 1" +
                " AND [RepairID] IS NULL) OR ([RepairID] = @Original_RepairID)) AND ([Deleted] = " +
                "@Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID));\r\nSELECT WorkID, C" +
                "lientID, MeasurementTakenBy, RepairConfirmationDate, BypassRequired, RoboticDist" +
                "ances, ProposedLiningDate, DeadlineLiningDate, FinalVideoDate, EstimatedJoints, " +
                "JointsTestSealed, IssueIdentified, IssueLFS, IssueClient, IssueSales, IssueGiven" +
                "ToClient, IssueResolved, IssueInvestigation, RepairID, Deleted, COMPANY_ID FROM " +
                "LFS_WORK_POINT_REPAIRS WHERE (WorkID = @WorkID)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@WorkID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ClientID", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ClientID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MeasurementTakenBy", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MeasurementTakenBy", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RepairConfirmationDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RepairConfirmationDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@BypassRequired", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BypassRequired", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RoboticDistances", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RoboticDistances", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ProposedLiningDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProposedLiningDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DeadlineLiningDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DeadlineLiningDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@FinalVideoDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FinalVideoDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@EstimatedJoints", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EstimatedJoints", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@JointsTestSealed", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "JointsTestSealed", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IssueIdentified", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IssueIdentified", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IssueLFS", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IssueLFS", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IssueClient", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IssueClient", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IssueSales", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IssueSales", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IssueGivenToClient", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IssueGivenToClient", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IssueResolved", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IssueResolved", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IssueInvestigation", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IssueInvestigation", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RepairID", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RepairID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_WorkID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_ClientID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ClientID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ClientID", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ClientID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_MeasurementTakenBy", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MeasurementTakenBy", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MeasurementTakenBy", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MeasurementTakenBy", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_RepairConfirmationDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RepairConfirmationDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RepairConfirmationDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RepairConfirmationDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_BypassRequired", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BypassRequired", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_RoboticDistances", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RoboticDistances", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RoboticDistances", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RoboticDistances", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_ProposedLiningDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProposedLiningDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ProposedLiningDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProposedLiningDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DeadlineLiningDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DeadlineLiningDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DeadlineLiningDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DeadlineLiningDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_FinalVideoDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FinalVideoDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_FinalVideoDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FinalVideoDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_EstimatedJoints", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EstimatedJoints", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_EstimatedJoints", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EstimatedJoints", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_JointsTestSealed", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "JointsTestSealed", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_JointsTestSealed", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "JointsTestSealed", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_IssueIdentified", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IssueIdentified", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_IssueLFS", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IssueLFS", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_IssueClient", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IssueClient", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_IssueSales", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IssueSales", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_IssueGivenToClient", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IssueGivenToClient", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_IssueResolved", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IssueResolved", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_IssueInvestigation", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IssueInvestigation", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_RepairID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RepairID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RepairID", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RepairID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

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
            FillDataWithStoredProcedure("LFS_CWP_WORKPOINTREPAIRSGATEWAY_LOADBYWORKID", new SqlParameter("@workId", workId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadTop1ByProjectIdAssetIdWorkType
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="assetId">assetId</param>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>
        public DataSet LoadTop1ByProjectIdAssetIdWorkType(int projectId, int assetId, string workType, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_WORKPOINTREPAIRSGATEWAY_LOADTOP1BYPROJECTIDASSETIDWORKTYPE", new SqlParameter("@projectId", projectId), new SqlParameter("@assetId", assetId), new SqlParameter("@workType", workType), new SqlParameter("@companyId", companyId));
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
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.CWP.Common.WorkPointRepairsGateway.GetRow");
            }
        }



        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// <returns>DataRow</returns>
        public DataRow GetRowTop1()
        {
            if (Table.Select().Length > 0)
            {
                DataRow row = Table.Select()[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.CWP.Common.WorkPointRepairsGateway.GetRow");
            }
        }



        /// <summary>
        /// GetWorkId. If not exists, raise an exception.
        /// </summary>
        /// <returns>GetWorkId or EMPTY</returns>
        public int GetWorkIdTop1()
        {
            return (int)GetRowTop1()["WorkID"];
        }



        /// <summary>
        /// GetClientId. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>ClientId or EMPTY</returns>
        public string GetClientId(int workId)
        {
            if (GetRow(workId).IsNull("ClientID"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["ClientID"];
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
        /// GetRepairConfirmationDate. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>RepairConfirmationDate o EMPTY</returns>
        public DateTime? GetRepairConfirmationDate(int workId)
        {
            if (GetRow(workId).IsNull("RepairConfirmationDate"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["RepairConfirmationDate"];
            }
        }



        /// <summary>
        /// GetBypassRequired.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>BypassRequired o EMPTY</returns>
        public bool GetBypassRequired(int workId)
        {
            return (bool)GetRow(workId)["BypassRequired"];
        }



        /// <summary>
        /// GetRoboticDistances. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>RoboticDistances or EMPTY</returns>
        public string GetRoboticDistances(int workId)
        {
            if (GetRow(workId).IsNull("RoboticDistances"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["RoboticDistances"];
            }
        }
        


        /// <summary>
        /// GetProposedLiningDate. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>ProposedLiningDate o EMPTY</returns>
        public DateTime? GetProposedLiningDate(int workId)
        {
            if (GetRow(workId).IsNull("ProposedLiningDate"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["ProposedLiningDate"];
            }
        }



        /// <summary>
        /// GetDeadlineLiningDate. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>ProposedLiningDate o EMPTY</returns>
        public DateTime? GetDeadlineLiningDate(int workId)
        {
            if (GetRow(workId).IsNull("DeadlineLiningDate"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["DeadlineLiningDate"];
            }
        }



        /// <summary>
        /// GetFinalVideoDate. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>FinalVideoDate o EMPTY</returns>
        public DateTime? GetFinalVideoDate(int workId)
        {
            if (GetRow(workId).IsNull("FinalVideoDate"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["FinalVideoDate"];
            }
        }



        /// <summary>
        /// GetEstimatedJoints
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>EstimatedJoints</returns>
        public int? GetEstimatedJoints(int workId)
        {
            if (GetRow(workId).IsNull("EstimatedJoints"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(workId)["EstimatedJoints"];
            }
        }



        /// <summary>
        /// GetJointsTestSealed
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>JointsTestSealed</returns>
        public int? GetJointsTestSealed(int workId)
        {
            if (GetRow(workId).IsNull("JointsTestSealed"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(workId)["JointsTestSealed"];
            }
        }



        /// <summary>
        /// GetIssueIdentified. 
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>IssueIdentified</returns>
        public bool GetIssueIdentified(int workId)
        {
            return (bool)GetRow(workId)["IssueIdentified"];
        }



        /// <summary>
        /// GetIssueLFS. 
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>IssueLFS</returns>
        public bool GetIssueLFS(int workId)
        {
            return (bool)GetRow(workId)["IssueLFS"];
        }



        /// <summary>
        /// GetIssueClient. 
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>IssueClient</returns>
        public bool GetIssueClient(int workId)
        {
            return (bool)GetRow(workId)["IssueClient"];
        }



        /// <summary>
        /// GetIssueSales. 
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>IssueSales</returns>
        public bool GetIssueSales(int workId)
        {
            return (bool)GetRow(workId)["IssueSales"];
        }



        /// <summary>
        /// GetIssueGivenToClient. 
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>IssueGivenToClient</returns>
        public bool GetIssueGivenToClient(int workId)
        {
            return (bool)GetRow(workId)["IssueGivenToClient"];
        }



        /// <summary>
        /// GetIssueResolved. 
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>IssueResolved</returns>
        public bool GetIssueResolved(int workId)
        {
            return (bool)GetRow(workId)["IssueResolved"];
        }



        /// <summary>
        /// GetIssueInvestigation. 
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>IssueInvestigation</returns>
        public bool GetIssueInvestigation(int workId)
        {
            return (bool)GetRow(workId)["IssueInvestigation"];
        }



        /// <summary>
        /// GetRepairID. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>RepairID or EMPTY</returns>
        public string GetRepairID(int workId)
        {
            if (GetRow(workId).IsNull("RepairID"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["RepairID"];
            }
        }



        /// <summary>
        /// GetDeleted. 
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>True if the section is deleted</returns>
        public bool GetDeleted(int workId)
        {
            return (bool)GetRow(workId)["Deleted"];
        }



        /// <summary>
        /// GetCompanyId. 
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>CompanyId</returns>
        public int GetCompanyId(int workId)
        {
            return (int)GetRow(workId)["COMPANY_ID"];
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROWS
        //

        /// <summary>
        /// Insert a Point Repairs Work (direct to DB)
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="clientId">clientId</param>
        /// <param name="measurementTakenBy">measurementTakenBy</param>
        /// <param name="repairConfirmationDate">repairConfirmationDate</param>
        /// <param name="bypassRequired">bypassRequired</param>
        /// <param name="roboticDistances">roboticDistances</param>
        /// <param name="proposedLiningDate">proposedLiningDate</param>
        /// <param name="deadlineLiningDate">deadlineLiningDate</param>
        /// <param name="finalVideoDate">finalVideoDate</param>        
        /// <param name="estimatedJoints">estimatedJoints</param>
        /// <param name="jointsTestSealed">jointsTestSealed</param>
        /// <param name="issueIdentified">issueIdentified</param>
        /// <param name="issueLfs">issueLfs</param>
        /// <param name="issueClient">issueClient</param>
        /// <param name="issueSales">issueSales</param>        
        /// <param name="issueGivenToClient">issueGivenToClient</param>
        /// <param name="issueResolved">issueResolved</param>
        /// <param name="issueInvestigation">issueInvestigation</param>
        /// <param name="repairId">repairId</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <returns>rowsAffected</returns>
        public int Insert(int workId, string clientId, string measurementTakenBy, DateTime? repairConfirmationDate, bool bypassRequired, string roboticDistances, DateTime? proposedLiningDate, DateTime? deadlineLiningDate, DateTime? finalVideoDate, int? estimatedJoints, int? jointsTestSealed, bool issueIdentified, bool issueLfs, bool issueClient, bool issueSales, bool issueGivenToClient, bool issueResolved, bool issueInvestigation, string repairId, bool deleted, int companyId)
        {
            SqlParameter workIdParameter = new SqlParameter("WorkID", workId);
            SqlParameter clientIdParameter = (clientId.Trim() != "") ? new SqlParameter("ClientId", clientId.Trim()) : new SqlParameter("ClientId", DBNull.Value);
            SqlParameter measurementTakenByParameter = (measurementTakenBy.Trim() != "") ? new SqlParameter("MeasurementTakenBy", measurementTakenBy.Trim()) : new SqlParameter("MeasurementTakenBy", DBNull.Value);
            SqlParameter repairConfirmationDateParameter = (repairConfirmationDate.HasValue) ? new SqlParameter("RepairConfirmationDate", repairConfirmationDate) : new SqlParameter("RepairConfirmationDate", DBNull.Value);
            SqlParameter bypassRequiredParameter = new SqlParameter("BypassRequired", bypassRequired);
            SqlParameter roboticDistancesParameter = (roboticDistances.Trim() != "") ? new SqlParameter("RoboticDistances", roboticDistances.Trim()) : new SqlParameter("RoboticDistances", DBNull.Value);
            SqlParameter proposedLiningDateParameter = (proposedLiningDate.HasValue) ? new SqlParameter("ProposedLiningDate", proposedLiningDate) : new SqlParameter("ProposedLiningDate", DBNull.Value);
            SqlParameter deadlineLiningDateParameter = (deadlineLiningDate.HasValue) ? new SqlParameter("DeadlineLiningDate", deadlineLiningDate) : new SqlParameter("DeadlineLiningDate", DBNull.Value);
            SqlParameter finalVideoDateParameter = (finalVideoDate.HasValue) ? new SqlParameter("FinalVideoDate", finalVideoDate) : new SqlParameter("FinalVideoDate", DBNull.Value);            
            SqlParameter estimatedJointsParameter = (estimatedJoints.HasValue) ? new SqlParameter("EstimatedJoints", estimatedJoints) : new SqlParameter("EstimatedJoints", DBNull.Value);
            SqlParameter jointsTestSealedParameter = (jointsTestSealed.HasValue) ? new SqlParameter("JointsTestSealed", jointsTestSealed) : new SqlParameter("JointsTestSealed", DBNull.Value);
            SqlParameter issueIdentifiedParameter = new SqlParameter("IssueIdentified", issueIdentified);
            SqlParameter issueLfsParameter = new SqlParameter("IssueLFS", issueLfs);
            SqlParameter issueClientParameter = new SqlParameter("IssueClient", issueClient);
            SqlParameter issueSalesParameter = new SqlParameter("IssueSales", issueSales);            
            SqlParameter issueGivenToClientParameter = new SqlParameter("IssueGivenToClient", issueGivenToClient);
            SqlParameter issueResolvedParameter = new SqlParameter("IssueResolved", issueResolved);
            SqlParameter issueInvestigationParameter = new SqlParameter("IssueInvestigation", issueInvestigation);
            SqlParameter repairIdParameter = (repairId.Trim() != "") ? new SqlParameter("RepairID", repairId.Trim()) : new SqlParameter("RepairID", DBNull.Value);
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);

            string command = "INSERT INTO [dbo].[LFS_WORK_POINT_REPAIRS] " +
                " ([WorkID], [ClientID], [MeasurementTakenBy], [RepairConfirmationDate], [BypassRequired], [RoboticDistances], " +
                " [ProposedLiningDate], [DeadlineLiningDate], [FinalVideoDate], [EstimatedJoints], [JointsTestSealed], " +
                " [IssueIdentified], [IssueLFS], [IssueClient], [IssueSales], [IssueGivenToClient], [IssueResolved], [IssueInvestigation], " +
                " [RepairID], [Deleted], [COMPANY_ID]) " +
                " VALUES (@WorkID, @ClientID, @MeasurementTakenBy, @RepairConfirmationDate, @BypassRequired, @RoboticDistances, " +
                " @ProposedLiningDate, @DeadlineLiningDate, @FinalVideoDate, @EstimatedJoints, @JointsTestSealed, " +
                " @IssueIdentified, @IssueLFS, @IssueClient, @IssueSales,  @IssueGivenToClient, @IssueResolved, @IssueInvestigation, " +
                " @RepairID, @Deleted, @COMPANY_ID)";

            int rowsAffected = (int)ExecuteNonQuery(command, workIdParameter, clientIdParameter, measurementTakenByParameter, repairConfirmationDateParameter, bypassRequiredParameter, roboticDistancesParameter, proposedLiningDateParameter, deadlineLiningDateParameter, finalVideoDateParameter, estimatedJointsParameter, jointsTestSealedParameter, issueIdentifiedParameter, issueLfsParameter, issueClientParameter, issueSalesParameter, issueGivenToClientParameter, issueResolvedParameter, issueInvestigationParameter, repairIdParameter, deletedParameter, companyIdParameter);

            return rowsAffected;
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="originalWorkId">originalWorkId</param>
        /// <param name="originalClientId">originalClientId</param>
        /// <param name="originalMeasurementTakenBy">originalMeasurementTakenBy</param>
        /// <param name="originalRepairConfirmationDate">originalRepairConfirmationDate</param>
        /// <param name="originalBypassRequired">originalBypassRequired</param>
        /// <param name="originalRoboticDistances">originalRoboticDistances</param>
        /// <param name="originalProposedLiningDate">originalProposedLiningDate</param>
        /// <param name="originalDeadlineLiningDate">originalDeadlineLiningDate</param>
        /// <param name="originalFinalVideoDate">originalFinalVideoDate</param>
        /// <param name="originalEstimatedJoints">originalEstimatedJoints</param>
        /// <param name="originalJointsTestSealed">originalJointsTestSealed</param>
        /// <param name="originalIssueIdentified">originalIssueIdentified</param>
        /// <param name="originalIssueLfs">originalIssueLfs</param>
        /// <param name="originalIssueClient">originalIssueClient</param>
        /// <param name="originalIssueSales">originalIssueSales</param>
        /// <param name="originalIssueGivenToClient">originalIssueGivenToClient</param>
        /// <param name="originalIssueResolved">originalIssueResolved</param>
        /// <param name="originalIssueInvestigation">originalIssueInvestigation</param>
        /// <param name="originalRepairId">originalRepairId</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// 
        /// <param name="newWorkId">newWorkId</param>
        /// <param name="newClientId">newClientId</param>
        /// <param name="newMeasurementTakenBy">newMeasurementTakenBy</param>
        /// <param name="newRepairConfirmationDate">newRepairConfirmationDate</param>
        /// <param name="newBypassRequired">newBypassRequired</param>
        /// <param name="newRoboticDistances">newRoboticDistances</param>
        /// <param name="newProposedLiningDate">newProposedLiningDate</param>
        /// <param name="newDeadlineLiningDate">newDeadlineLiningDate</param>
        /// <param name="newFinalVideoDate">newFinalVideoDate</param>
        /// <param name="newEstimatedJoints">newEstimatedJoints</param>
        /// <param name="newJointsTestSealed">newJointsTestSealed</param>
        /// <param name="newIssueIdentified">newIssueIdentified</param>
        /// <param name="newIssueLfs">newIssueLfs</param>
        /// <param name="newIssueClient">newIssueClient</param>
        /// <param name="newIssueSales">newIssueSales</param>
        /// <param name="newIssueGivenToClient">newIssueGivenToClient</param>
        /// <param name="newIssueResolved">newIssueResolved</param>
        /// <param name="newIssueInvestigation">newIssueInvestigation</param>
        /// <param name="newRepairId">newRepairId</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <returns></returns>
        public int Update(int originalWorkId, string originalClientId, string originalMeasurementTakenBy, DateTime? originalRepairConfirmationDate, bool originalBypassRequired, string originalRoboticDistances, DateTime? originalProposedLiningDate, DateTime? originalDeadlineLiningDate, DateTime? originalFinalVideoDate, int? originalEstimatedJoints, int? originalJointsTestSealed, bool originalIssueIdentified, bool originalIssueLfs, bool originalIssueClient, bool originalIssueSales, bool originalIssueGivenToClient, bool originalIssueResolved, bool originalIssueInvestigation, string originalRepairId, bool originalDeleted, int originalCompanyId, int newWorkId, string newClientId, string newMeasurementTakenBy, DateTime? newRepairConfirmationDate, bool newBypassRequired, string newRoboticDistances, DateTime? newProposedLiningDate, DateTime? newDeadlineLiningDate, DateTime? newFinalVideoDate, int? newEstimatedJoints, int? newJointsTestSealed, bool newIssueIdentified, bool newIssueLfs, bool newIssueClient, bool newIssueSales, bool newIssueGivenToClient, bool newIssueResolved, bool newIssueInvestigation, string newRepairId, bool newDeleted, int newCompanyId)
        {
            SqlParameter originalWorkIdParameter = new SqlParameter("Original_WorkID", originalWorkId);
            SqlParameter originalClientIdParameter = (originalClientId.Trim() != "") ? new SqlParameter("Original_ClientId", originalClientId.Trim()) : new SqlParameter("Original_ClientId", DBNull.Value);
            SqlParameter originalMeasurementTakenByParameter = (originalMeasurementTakenBy.Trim() != "") ? new SqlParameter("Original_MeasurementTakenBy", originalMeasurementTakenBy.Trim()) : new SqlParameter("Original_MeasurementTakenBy", DBNull.Value);
            SqlParameter originalRepairConfirmationDateParameter = (originalRepairConfirmationDate.HasValue) ? new SqlParameter("Original_RepairConfirmationDate", originalRepairConfirmationDate) : new SqlParameter("Original_RepairConfirmationDate", DBNull.Value);
            SqlParameter originalBypassRequiredParameter = new SqlParameter("Original_BypassRequired", originalBypassRequired);
            SqlParameter originalRoboticDistancesParameter = (originalRoboticDistances.Trim() != "") ? new SqlParameter("Original_RoboticDistances", originalRoboticDistances.Trim()) : new SqlParameter("Original_RoboticDistances", DBNull.Value);
            SqlParameter originalProposedLiningDateParameter = (originalProposedLiningDate.HasValue) ? new SqlParameter("Original_ProposedLiningDate", originalProposedLiningDate) : new SqlParameter("Original_ProposedLiningDate", DBNull.Value);
            SqlParameter originalDeadlineLiningDateParameter = (originalDeadlineLiningDate.HasValue) ? new SqlParameter("Original_DeadlineLiningDate", originalDeadlineLiningDate) : new SqlParameter("Original_DeadlineLiningDate", DBNull.Value);
            SqlParameter originalFinalVideoDateParameter = (originalFinalVideoDate.HasValue) ? new SqlParameter("Original_FinalVideoDate", originalFinalVideoDate) : new SqlParameter("Original_FinalVideoDate", DBNull.Value);
            SqlParameter originalEstimatedJointsParameter = (originalEstimatedJoints.HasValue) ? new SqlParameter("Original_EstimatedJoints", originalEstimatedJoints) : new SqlParameter("Original_EstimatedJoints", DBNull.Value);
            SqlParameter originalJointsTestSealedParameter = (originalJointsTestSealed.HasValue) ? new SqlParameter("Original_JointsTestSealed", originalJointsTestSealed) : new SqlParameter("Original_JointsTestSealed", DBNull.Value);
            SqlParameter originalIssueIdentifiedParameter = new SqlParameter("Original_IssueIdentified", originalIssueIdentified);
            SqlParameter originalIssueLfsParameter = new SqlParameter("Original_IssueLFS", originalIssueLfs);
            SqlParameter originalIssueClientParameter = new SqlParameter("Original_IssueClient", originalIssueClient);
            SqlParameter originalIssueSalesParameter = new SqlParameter("Original_IssueSales", originalIssueSales);
            SqlParameter originalIssueGivenToClientParameter = new SqlParameter("Original_IssueGivenToClient", originalIssueGivenToClient);
            SqlParameter originalIssueResolvedParameter = new SqlParameter("Original_IssueResolved", originalIssueResolved);
            SqlParameter originalIssueInvestigationParameter = new SqlParameter("Original_IssueInvestigation", originalIssueInvestigation);
            SqlParameter originalRepairIdParameter = (originalRepairId.Trim() != "") ? new SqlParameter("Original_RepairID", originalRepairId.Trim()) : new SqlParameter("Original_RepairID", DBNull.Value);
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);

            SqlParameter newWorkIdParameter = new SqlParameter("WorkID", newWorkId);
            SqlParameter newClientIdParameter = (newClientId.Trim() != "") ? new SqlParameter("ClientId", newClientId.Trim()) : new SqlParameter("ClientId", DBNull.Value);
            SqlParameter newMeasurementTakenByParameter = (newMeasurementTakenBy.Trim() != "") ? new SqlParameter("MeasurementTakenBy", newMeasurementTakenBy.Trim()) : new SqlParameter("MeasurementTakenBy", DBNull.Value);
            SqlParameter newRepairConfirmationDateParameter = (newRepairConfirmationDate.HasValue) ? new SqlParameter("RepairConfirmationDate", newRepairConfirmationDate) : new SqlParameter("RepairConfirmationDate", DBNull.Value);
            SqlParameter newBypassRequiredParameter = new SqlParameter("BypassRequired", newBypassRequired);
            SqlParameter newRoboticDistancesParameter = (newRoboticDistances.Trim() != "") ? new SqlParameter("RoboticDistances", newRoboticDistances.Trim()) : new SqlParameter("RoboticDistances", DBNull.Value);
            SqlParameter newProposedLiningDateParameter = (newProposedLiningDate.HasValue) ? new SqlParameter("ProposedLiningDate", newProposedLiningDate) : new SqlParameter("ProposedLiningDate", DBNull.Value);
            SqlParameter newDeadlineLiningDateParameter = (newDeadlineLiningDate.HasValue) ? new SqlParameter("DeadlineLiningDate", newDeadlineLiningDate) : new SqlParameter("DeadlineLiningDate", DBNull.Value);
            SqlParameter newFinalVideoDateParameter = (newFinalVideoDate.HasValue) ? new SqlParameter("FinalVideoDate", newFinalVideoDate) : new SqlParameter("FinalVideoDate", DBNull.Value);
            SqlParameter newEstimatedJointsParameter = (newEstimatedJoints.HasValue) ? new SqlParameter("EstimatedJoints", newEstimatedJoints) : new SqlParameter("EstimatedJoints", DBNull.Value);
            SqlParameter newJointsTestSealedParameter = (newJointsTestSealed.HasValue) ? new SqlParameter("JointsTestSealed", newJointsTestSealed) : new SqlParameter("JointsTestSealed", DBNull.Value);
            SqlParameter newIssueIdentifiedParameter = new SqlParameter("IssueIdentified", newIssueIdentified);
            SqlParameter newIssueLfsParameter = new SqlParameter("IssueLFS", newIssueLfs);
            SqlParameter newIssueClientParameter = new SqlParameter("IssueClient", newIssueClient);
            SqlParameter newIssueSalesParameter = new SqlParameter("IssueSales", newIssueSales);
            SqlParameter newIssueGivenToClientParameter = new SqlParameter("IssueGivenToClient", newIssueGivenToClient);
            SqlParameter newIssueResolvedParameter = new SqlParameter("IssueResolved", newIssueResolved);
            SqlParameter newIssueInvestigationParameter = new SqlParameter("IssueInvestigation", newIssueInvestigation);
            SqlParameter newRepairIdParameter = (newRepairId.Trim() != "") ? new SqlParameter("RepairID", newRepairId.Trim()) : new SqlParameter("RepairID", DBNull.Value);
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);
                        
            string command = "UPDATE [dbo].[LFS_WORK_POINT_REPAIRS] " + 
                " SET [WorkID] = @WorkID, [ClientID] = @ClientID, [MeasurementTakenBy] = @MeasurementTakenBy, [RepairConfirmationDate] = @RepairConfirmationDate, [BypassRequired] = @BypassRequired, [RoboticDistances] = @RoboticDistances, [ProposedLiningDate] = @ProposedLiningDate, [DeadlineLiningDate] = @DeadlineLiningDate, [FinalVideoDate] = @FinalVideoDate, [EstimatedJoints] = @EstimatedJoints, [JointsTestSealed] = @JointsTestSealed, " + 
                " [IssueIdentified] = @IssueIdentified, [IssueLFS] = @IssueLFS, [IssueClient] = @IssueClient, [IssueSales] = @IssueSales, [IssueGivenToClient] = @IssueGivenToClient, [IssueResolved] = @IssueResolved, [IssueInvestigation] = @IssueInvestigation, [RepairID] = @RepairID, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID " +
                " WHERE ([WorkID] = @Original_WorkID) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID)";

            int rowsAffected = (int)ExecuteNonQuery(command, originalWorkIdParameter, originalClientIdParameter, originalMeasurementTakenByParameter, originalRepairConfirmationDateParameter, originalBypassRequiredParameter, originalRoboticDistancesParameter, originalProposedLiningDateParameter, originalDeadlineLiningDateParameter, originalFinalVideoDateParameter, originalEstimatedJointsParameter, originalJointsTestSealedParameter, originalIssueIdentifiedParameter, originalIssueLfsParameter, originalIssueClientParameter, originalIssueSalesParameter, originalIssueGivenToClientParameter, originalIssueResolvedParameter, originalIssueInvestigationParameter, originalRepairIdParameter, originalDeletedParameter, originalCompanyIdParameter, newWorkIdParameter, newClientIdParameter, newMeasurementTakenByParameter, newRepairConfirmationDateParameter, newBypassRequiredParameter, newRoboticDistancesParameter, newProposedLiningDateParameter, newDeadlineLiningDateParameter, newFinalVideoDateParameter, newEstimatedJointsParameter, newJointsTestSealedParameter, newIssueIdentifiedParameter, newIssueLfsParameter, newIssueClientParameter, newIssueSalesParameter, newIssueGivenToClientParameter, newIssueResolvedParameter, newIssueInvestigationParameter, newRepairIdParameter, newDeletedParameter, newCompanyIdParameter);

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

            string command = "UPDATE [dbo].[LFS_WORK_POINT_REPAIRS] SET  [Deleted] = @Deleted  " +
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