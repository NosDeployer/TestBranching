using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.Works
{
    /// <summary>
    /// WorkFullLengthLiningGateway
    /// </summary>
    public class WorkFullLengthLiningGateway : DataTableGateway
    {
        ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkFullLengthLiningGateway() : base("LFS_WORK_FULLLENGTHLINING")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkFullLengthLiningGateway(DataSet data) : base(data, "LFS_WORK_FULLLENGTHLINING")
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
            tableMapping.DataSetTable = "LFS_WORK_FULLLENGTHLINING";
            tableMapping.ColumnMappings.Add("WorkID", "WorkID");
            tableMapping.ColumnMappings.Add("ClientID", "ClientID");
            tableMapping.ColumnMappings.Add("ProposedLiningDate", "ProposedLiningDate");
            tableMapping.ColumnMappings.Add("DeadlineLiningDate", "DeadlineLiningDate");
            tableMapping.ColumnMappings.Add("P1Date", "P1Date");
            tableMapping.ColumnMappings.Add("M1Date", "M1Date");
            tableMapping.ColumnMappings.Add("M2Date", "M2Date");
            tableMapping.ColumnMappings.Add("InstallDate", "InstallDate");
            tableMapping.ColumnMappings.Add("FinalVideoDate", "FinalVideoDate");
            tableMapping.ColumnMappings.Add("IssueIdentified", "IssueIdentified");
            tableMapping.ColumnMappings.Add("IssueLFS", "IssueLFS");
            tableMapping.ColumnMappings.Add("IssueClient", "IssueClient");
            tableMapping.ColumnMappings.Add("IssueSales", "IssueSales");
            tableMapping.ColumnMappings.Add("IssueGivenToClient", "IssueGivenToClient");
            tableMapping.ColumnMappings.Add("IssueResolved", "IssueResolved");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("IssueInvestigation", "IssueInvestigation");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = @"DELETE FROM [dbo].[LFS_WORK_FULLLENGTHLINING] WHERE (([WorkID] = @Original_WorkID) AND ((@IsNull_ClientID = 1 AND [ClientID] IS NULL) OR ([ClientID] = @Original_ClientID)) AND ((@IsNull_ProposedLiningDate = 1 AND [ProposedLiningDate] IS NULL) OR ([ProposedLiningDate] = @Original_ProposedLiningDate)) AND ((@IsNull_DeadlineLiningDate = 1 AND [DeadlineLiningDate] IS NULL) OR ([DeadlineLiningDate] = @Original_DeadlineLiningDate)) AND ((@IsNull_P1Date = 1 AND [P1Date] IS NULL) OR ([P1Date] = @Original_P1Date)) AND ((@IsNull_M1Date = 1 AND [M1Date] IS NULL) OR ([M1Date] = @Original_M1Date)) AND ((@IsNull_M2Date = 1 AND [M2Date] IS NULL) OR ([M2Date] = @Original_M2Date)) AND ((@IsNull_InstallDate = 1 AND [InstallDate] IS NULL) OR ([InstallDate] = @Original_InstallDate)) AND ((@IsNull_FinalVideoDate = 1 AND [FinalVideoDate] IS NULL) OR ([FinalVideoDate] = @Original_FinalVideoDate)) AND ([IssueIdentified] = @Original_IssueIdentified) AND ([IssueLFS] = @Original_IssueLFS) AND ([IssueClient] = @Original_IssueClient) AND ([IssueSales] = @Original_IssueSales) AND ([IssueGivenToClient] = @Original_IssueGivenToClient) AND ([IssueResolved] = @Original_IssueResolved) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND ([IssueInvestigation] = @Original_IssueInvestigation))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_WorkID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_ClientID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ClientID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ClientID", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ClientID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_ProposedLiningDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProposedLiningDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ProposedLiningDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProposedLiningDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DeadlineLiningDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DeadlineLiningDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DeadlineLiningDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DeadlineLiningDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_P1Date", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "P1Date", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_P1Date", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "P1Date", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_M1Date", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "M1Date", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_M1Date", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "M1Date", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_M2Date", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "M2Date", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_M2Date", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "M2Date", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_InstallDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "InstallDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_InstallDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "InstallDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_FinalVideoDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FinalVideoDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_FinalVideoDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FinalVideoDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_IssueIdentified", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IssueIdentified", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_IssueLFS", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IssueLFS", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_IssueClient", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IssueClient", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_IssueSales", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IssueSales", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_IssueGivenToClient", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IssueGivenToClient", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_IssueResolved", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IssueResolved", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_IssueInvestigation", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IssueInvestigation", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_WORK_FULLLENGTHLINING] ([WorkID], [ClientID], [ProposedLiningDate], [DeadlineLiningDate], [P1Date], [M1Date], [M2Date], [InstallDate], [FinalVideoDate], [IssueIdentified], [IssueLFS], [IssueClient], [IssueSales], [IssueGivenToClient], [IssueResolved], [Deleted], [COMPANY_ID], [IssueInvestigation]) VALUES (@WorkID, @ClientID, @ProposedLiningDate, @DeadlineLiningDate, @P1Date, @M1Date, @M2Date, @InstallDate, @FinalVideoDate, @IssueIdentified, @IssueLFS, @IssueClient, @IssueSales, @IssueGivenToClient, @IssueResolved, @Deleted, @COMPANY_ID, @IssueInvestigation);
SELECT WorkID, ClientID, ProposedLiningDate, DeadlineLiningDate, P1Date, M1Date, M2Date, InstallDate, FinalVideoDate, IssueIdentified, IssueLFS, IssueClient, IssueSales, IssueGivenToClient, IssueResolved, Deleted, COMPANY_ID, IssueInvestigation FROM LFS_WORK_FULLLENGTHLINING WHERE (WorkID = @WorkID)";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@WorkID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ClientID", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ClientID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ProposedLiningDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProposedLiningDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DeadlineLiningDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DeadlineLiningDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@P1Date", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "P1Date", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@M1Date", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "M1Date", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@M2Date", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "M2Date", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@InstallDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "InstallDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@FinalVideoDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FinalVideoDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IssueIdentified", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IssueIdentified", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IssueLFS", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IssueLFS", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IssueClient", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IssueClient", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IssueSales", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IssueSales", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IssueGivenToClient", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IssueGivenToClient", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IssueResolved", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IssueResolved", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IssueInvestigation", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IssueInvestigation", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));

            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[LFS_WORK_FULLLENGTHLINING] SET [WorkID] = @WorkID, [ClientID] = @Cl" +
                "ientID, [ProposedLiningDate] = @ProposedLiningDate, [DeadlineLiningDate] = @Dead" +
                "lineLiningDate, [P1Date] = @P1Date, [M1Date] = @M1Date, [M2Date] = @M2Date, [Ins" +
                "tallDate] = @InstallDate, [FinalVideoDate] = @FinalVideoDate, [IssueIdentified] " +
                "= @IssueIdentified, [IssueLFS] = @IssueLFS, [IssueClient] = @IssueClient, [Issue" +
                "Sales] = @IssueSales, [IssueGivenToClient] = @IssueGivenToClient, [IssueResolved" +
                "] = @IssueResolved, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID, [IssueInve" +
                "stigation] = @IssueInvestigation WHERE (([WorkID] = @Original_WorkID) AND ((@IsN" +
                "ull_ClientID = 1 AND [ClientID] IS NULL) OR ([ClientID] = @Original_ClientID)) A" +
                "ND ((@IsNull_ProposedLiningDate = 1 AND [ProposedLiningDate] IS NULL) OR ([Propo" +
                "sedLiningDate] = @Original_ProposedLiningDate)) AND ((@IsNull_DeadlineLiningDate" +
                " = 1 AND [DeadlineLiningDate] IS NULL) OR ([DeadlineLiningDate] = @Original_Dead" +
                "lineLiningDate)) AND ((@IsNull_P1Date = 1 AND [P1Date] IS NULL) OR ([P1Date] = @" +
                "Original_P1Date)) AND ((@IsNull_M1Date = 1 AND [M1Date] IS NULL) OR ([M1Date] = " +
                "@Original_M1Date)) AND ((@IsNull_M2Date = 1 AND [M2Date] IS NULL) OR ([M2Date] =" +
                " @Original_M2Date)) AND ((@IsNull_InstallDate = 1 AND [InstallDate] IS NULL) OR " +
                "([InstallDate] = @Original_InstallDate)) AND ((@IsNull_FinalVideoDate = 1 AND [F" +
                "inalVideoDate] IS NULL) OR ([FinalVideoDate] = @Original_FinalVideoDate)) AND ([" +
                "IssueIdentified] = @Original_IssueIdentified) AND ([IssueLFS] = @Original_IssueL" +
                "FS) AND ([IssueClient] = @Original_IssueClient) AND ([IssueSales] = @Original_Is" +
                "sueSales) AND ([IssueGivenToClient] = @Original_IssueGivenToClient) AND ([IssueR" +
                "esolved] = @Original_IssueResolved) AND ([Deleted] = @Original_Deleted) AND ([CO" +
                "MPANY_ID] = @Original_COMPANY_ID) AND ([IssueInvestigation] = @Original_IssueInv" +
                "estigation));\r\nSELECT WorkID, ClientID, ProposedLiningDate, DeadlineLiningDate, " +
                "P1Date, M1Date, M2Date, InstallDate, FinalVideoDate, IssueIdentified, IssueLFS, " +
                "IssueClient, IssueSales, IssueGivenToClient, IssueResolved, Deleted, COMPANY_ID," +
                " IssueInvestigation FROM LFS_WORK_FULLLENGTHLINING WHERE (WorkID = @WorkID)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@WorkID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ClientID", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ClientID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ProposedLiningDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProposedLiningDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DeadlineLiningDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DeadlineLiningDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@P1Date", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "P1Date", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@M1Date", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "M1Date", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@M2Date", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "M2Date", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@InstallDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "InstallDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@FinalVideoDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FinalVideoDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IssueIdentified", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IssueIdentified", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IssueLFS", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IssueLFS", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IssueClient", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IssueClient", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IssueSales", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IssueSales", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IssueGivenToClient", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IssueGivenToClient", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IssueResolved", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IssueResolved", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IssueInvestigation", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IssueInvestigation", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_WorkID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_ClientID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ClientID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ClientID", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ClientID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_ProposedLiningDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProposedLiningDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ProposedLiningDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProposedLiningDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DeadlineLiningDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DeadlineLiningDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DeadlineLiningDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DeadlineLiningDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_P1Date", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "P1Date", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_P1Date", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "P1Date", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_M1Date", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "M1Date", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_M1Date", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "M1Date", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_M2Date", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "M2Date", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_M2Date", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "M2Date", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_InstallDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "InstallDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_InstallDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "InstallDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_FinalVideoDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FinalVideoDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_FinalVideoDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FinalVideoDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_IssueIdentified", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IssueIdentified", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_IssueLFS", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IssueLFS", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_IssueClient", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IssueClient", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_IssueSales", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IssueSales", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_IssueGivenToClient", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IssueGivenToClient", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_IssueResolved", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IssueResolved", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_IssueInvestigation", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IssueInvestigation", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

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
            FillDataWithStoredProcedure("LFS_CWP_WORKFULLLENGTHLININGGATEWAY_LOADBYWORKID", new SqlParameter("@workId", workId), new SqlParameter("@companyId", companyId));
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
            FillDataWithStoredProcedure("LFS_CWP_WORKFULLLENGTHLININGGATEWAY_LOADTOP1BYPROJECTIDASSETIDWORKTYPE", new SqlParameter("@projectId", projectId), new SqlParameter("@assetId", assetId), new SqlParameter("@workType", workType), new SqlParameter("@companyId", companyId));
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
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.CWP.Common.WorkFullLengthLiningGateway.GetRow");
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
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.CWP.Common.WorkFullLengthLiningGateway.GetRow");
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
        /// GetP1Date. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>P1 Date o EMPTY</returns>
        public DateTime? GetP1Date(int workId)
        {
            if (GetRow(workId).IsNull("P1Date"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["P1Date"];
            }
        }



        /// <summary>
        /// GetM1Date. If  not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>M1 Date o EMPTY</returns>
        public DateTime? GetM1Date(int workId)
        {
            if (GetRow(workId).IsNull("M1Date"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["M1Date"];
            }
        }




        /// <summary>
        /// GetM2Date. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>M2 Date o EMPTY</returns>
        public DateTime? GetM2Date(int workId)
        {
            if (GetRow(workId).IsNull("M2Date"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["M2Date"];
            }
        }



        /// <summary>
        /// GetInstallDate. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>InstallDate o EMPTY</returns>
        public DateTime? GetInstallDate(int workId)
        {
            if (GetRow(workId).IsNull("InstallDate"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["InstallDate"];
            }
        }



        /// <summary>
        /// GetFinalVideoDate. If  not exists, raise an exception.
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
        /// Insert a Full Length Lining Work (direct to DB)
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="clientId">clientId</param>
        /// <param name="proposedLiningDate">proposedLiningDate</param>
        /// <param name="deadlineLiningDate">deadlineLiningDate</param>
        /// <param name="p1Date">p1Date</param>
        /// <param name="m1Date">m1Date</param>
        /// <param name="m2Date">m2Date</param>
        /// <param name="finalVideoDate">finalVideoDate</param>
        /// <param name="installDate">installDate</param>
        /// <param name="finalVideoDate">finalVideoDate</param>
        /// <param name="issueIdentified">issueIdentified</param>
        /// <param name="issueLfs">issueLfs</param>
        /// <param name="issueClient">issueClient</param>
        /// <param name="issueSales">issueSales</param>
        /// <param name="issueGivenToClient">issueGivenToClient</param>
        /// <param name="issueResolved">issueResolved</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="issueInvestigation">issueInvestigation</param>
        /// <returns>rowsAffected</returns>
        public int Insert(int workId, string clientId, DateTime? proposedLiningDate, DateTime? deadlineLiningDate, DateTime? p1Date, DateTime? m1Date, DateTime? m2Date, DateTime? installDate, DateTime? finalVideoDate, bool issueIdentified, bool issueLfs, bool issueClient, bool issueSales, bool issueGivenToClient, bool issueResolved, bool deleted, int companyId, bool issueInvestigation)
        {
            SqlParameter workIdParameter = new SqlParameter("WorkID", workId);
            SqlParameter clientIdParameter = (clientId.Trim() != "") ? new SqlParameter("ClientId", clientId.Trim()) : new SqlParameter("ClientId", DBNull.Value);
            SqlParameter proposedLiningDateParameter = (proposedLiningDate.HasValue) ? new SqlParameter("ProposedLiningDate", proposedLiningDate) : new SqlParameter("ProposedLiningDate", DBNull.Value);
            SqlParameter deadlineLiningDateParameter = (deadlineLiningDate.HasValue) ? new SqlParameter("DeadlineLiningDate", deadlineLiningDate) : new SqlParameter("DeadlineLiningDate", DBNull.Value);
            SqlParameter p1DateParameter = (p1Date.HasValue) ? new SqlParameter("P1Date", p1Date) : new SqlParameter("P1Date", DBNull.Value);
            SqlParameter m1DateParameter = (m1Date.HasValue) ? new SqlParameter("M1Date", m1Date) : new SqlParameter("M1Date", DBNull.Value);
            SqlParameter m2DateParameter = (m2Date.HasValue) ? new SqlParameter("M2Date", m2Date) : new SqlParameter("M2Date", DBNull.Value);
            SqlParameter installDateParameter = (installDate.HasValue) ? new SqlParameter("InstallDate", installDate) : new SqlParameter("InstallDate", DBNull.Value);
            SqlParameter finalVideoDateParameter = (finalVideoDate.HasValue) ? new SqlParameter("FinalVideoDate", finalVideoDate) : new SqlParameter("FinalVideoDate", DBNull.Value);
            SqlParameter issueIdentifiedParameter = new SqlParameter("IssueIdentified", issueIdentified);
            SqlParameter issueLfsParameter = new SqlParameter("IssueLFS", issueLfs);
            SqlParameter issueClientParameter = new SqlParameter("IssueClient", issueClient);
            SqlParameter issueSalesParameter = new SqlParameter("IssueSales", issueSales);
            SqlParameter issueGivenToClientParameter = new SqlParameter("IssueGivenToClient", issueGivenToClient);
            SqlParameter issueResolvedParameter = new SqlParameter("IssueResolved",  issueResolved);
            SqlParameter issueInvestigationParameter = new SqlParameter("IssueInvestigation", issueInvestigation);
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);

            string command = "INSERT INTO [dbo].[LFS_WORK_FULLLENGTHLINING] "+
                " ([WorkID], [ClientID], [ProposedLiningDate], "+
                " [DeadlineLiningDate], [P1Date], [M1Date], [M2Date], [InstallDate], "+
                " [FinalVideoDate], [IssueIdentified], [IssueLFS], [IssueClient], [IssueSales], "+
                " [IssueGivenToClient], [IssueResolved], [Deleted], [COMPANY_ID], [IssueInvestigation]) " +
                " VALUES (@WorkID, @ClientID, @ProposedLiningDate, "+
                " @DeadlineLiningDate, @P1Date, @M1Date, @M2Date, @InstallDate, @FinalVideoDate, "+
                " @IssueIdentified, @IssueLFS, @IssueClient, @IssueSales, @IssueGivenToClient, @IssueResolved, "+
                " @Deleted, @COMPANY_ID, @IssueInvestigation)";

            int rowsAffected = (int)ExecuteNonQuery( command, workIdParameter, clientIdParameter, proposedLiningDateParameter, deadlineLiningDateParameter, p1DateParameter, m1DateParameter, m2DateParameter, installDateParameter, finalVideoDateParameter, issueIdentifiedParameter, issueLfsParameter, issueClientParameter, issueSalesParameter, issueGivenToClientParameter, issueResolvedParameter, issueInvestigationParameter, deletedParameter, companyIdParameter);

            return rowsAffected;
        }



        /// <summary>
        /// Update Full Length Lining Work (direct to DB)
        /// </summary>
        /// <param name="originalWorkId">originalWorkId</param>
        /// <param name="originalClientId">originalClientId</param>
        /// <param name="originalProposedLiningDate">originalProposedLiningDate</param>
        /// <param name="originalDeadlineLiningDate">originalDeadlineLiningDate</param>
        /// <param name="originalP1Date">originalP1Date</param>
        /// <param name="originalM1Date">originalM1Date</param>
        /// <param name="originalM2Date">originalM2Date</param>
        /// <param name="originalInstallDate">originalInstallDate</param>
        /// <param name="originalFinalVideo">originalFinalVideo</param>
        /// <param name="originalIssueIdentified">originalIssueIdentified</param>
        /// <param name="originalLfsIssue">originalLfsIssue</param>
        /// <param name="originalClientIssue">originalClientIssue</param>
        /// <param name="originalSalesIssue">originalSalesIssue</param>
        /// <param name="originalIssueGivenToClient">originalIssueGivenToClient</param>
        /// <param name="originalIssueResolved">originalIssueResolved</param>
        /// <param name="originalDeleted">originalDeleted</param> 
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalIssueInvestigation">originalIssueInvestigation</param>
        /// <param name="newWorkId">newWorkId</param>
        /// <param name="newClientId">newClientId</param>
        /// <param name="newProposedLiningDate">newProposedLiningDate</param>
        /// <param name="newDeadlineLiningDate">newDeadlineLiningDate</param>
        /// <param name="newP1Date">newP1Date</param>
        /// <param name="newM1Date">newM1Date</param>
        /// <param name="newM2Date">newM2Date</param>
        /// <param name="newInstallDate">newInstallDate</param>
        /// <param name="newFinalVideo">newFinalVideo</param>
        /// <param name="newIssueIdentified">newIssueIdentified</param>
        /// <param name="newLfsIssue">newLfsIssue</param>
        /// <param name="newClientIssue">newClientIssue</param>
        /// <param name="newSalesIssue">newSalesIssue</param>
        /// <param name="newIssueGivenToClient">newIssueGivenToClient</param>
        /// <param name="newIssueResolved">newIssueResolved</param>
        /// <param name="newIssueInvestigation">newIssueInvestigation</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <returns>rowsAffected</returns>
        public int Update(int originalWorkId, string originalClientId, DateTime? originalProposedLiningDate, DateTime? originalDeadlineLiningDate, DateTime? originalP1Date, DateTime? originalM1Date, DateTime? originalM2Date, DateTime? originalInstallDate, DateTime? originalFinalVideo, bool originalIssueIdentified, bool originalLfsIssue, bool originalClientIssue, bool originalSalesIssue, bool originalIssueGivenToClient, bool originalIssueResolved, bool originalDeleted, int originalCompanyId, bool originalIssueInvestigation, int newWorkId, string newClientId, DateTime? newProposedLiningDate, DateTime? newDeadlineLiningDate, DateTime? newP1Date, DateTime? newM1Date, DateTime? newM2Date, DateTime? newInstallDate, DateTime? newFinalVideo, bool newIssueIdentified, bool newLfsIssue, bool newClientIssue, bool newSalesIssue, bool newIssueGivenToClient, bool newIssueResolved, bool newIssueInvestigation, bool newDeleted, int newCompanyId)
        {
            SqlParameter originalWorkIdParameter = new SqlParameter("Original_WorkID", originalWorkId);
            SqlParameter originalClientIdParameter = (originalClientId != "") ? new SqlParameter("Original_ClientID", originalClientId) : new SqlParameter("Original_ClientID", DBNull.Value);
            SqlParameter originalProposedLiningDateParameter = (originalProposedLiningDate.HasValue) ? new SqlParameter("Original_ProposedLiningDate", originalProposedLiningDate) : new SqlParameter("Original_ProposedLiningDate", DBNull.Value);
            SqlParameter originalDeadlineLiningDateParameter = (originalDeadlineLiningDate.HasValue) ? new SqlParameter("Original_DeadlineLiningDate", originalDeadlineLiningDate) : new SqlParameter("Original_DeadlineLiningDate", DBNull.Value);
            SqlParameter originalP1DateParameter = (originalP1Date.HasValue) ? new SqlParameter("Original_P1Date", originalP1Date) : new SqlParameter("Original_P1Date", DBNull.Value);
            SqlParameter originalM1DateParameter = (originalM1Date.HasValue) ? new SqlParameter("Original_M1Date", originalM1Date) : new SqlParameter("Original_M1Date", DBNull.Value);
            SqlParameter originalM2DateParameter = (originalM2Date.HasValue) ? new SqlParameter("Original_M2Date", originalM2Date) : new SqlParameter("Original_M2Date", DBNull.Value);
            SqlParameter originalInstallDateParameter = (originalInstallDate.HasValue) ? new SqlParameter("Original_InstallDate", originalInstallDate) : new SqlParameter("Original_InstallDate", DBNull.Value);
            SqlParameter originalFinalVideoParameter = (originalFinalVideo.HasValue) ? new SqlParameter("Original_FinalVideoDate", originalFinalVideo) : new SqlParameter("Original_FinalVideoDate", DBNull.Value);
            SqlParameter originalIssueIdentifiedParameter = new SqlParameter("Original_IssueIdentified", originalIssueIdentified);
            SqlParameter originalLfsIssueParameter = new SqlParameter("Original_IssueLFS", originalLfsIssue);
            SqlParameter originalClientIssueParameter = new SqlParameter("Original_IssueClient", originalClientIssue);
            SqlParameter originalSalesIssueParameter = new SqlParameter("Original_IssueSales", originalSalesIssue);
            SqlParameter originalIssueGivenToClientParameter = new SqlParameter("Original_IssueGivenToClient", originalIssueGivenToClient);
            SqlParameter originalIssueResolvedParameter = new SqlParameter("Original_IssueResolved", originalIssueResolved);
            SqlParameter originalIssueInvestigationParameter = new SqlParameter("Original_IssueInvestigation", originalIssueInvestigation);
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);

            SqlParameter newWorkIdParameter = new SqlParameter("WorkID", newWorkId);
            SqlParameter newClientIdParameter = (newClientId != "") ? new SqlParameter("ClientID", newClientId) : new SqlParameter("ClientID", DBNull.Value);
            SqlParameter newProposedLiningDateParameter = (newProposedLiningDate.HasValue) ? new SqlParameter("ProposedLiningDate", newProposedLiningDate) : new SqlParameter("ProposedLiningDate", DBNull.Value);
            SqlParameter newDeadlineLiningDateParameter = (newDeadlineLiningDate.HasValue) ? new SqlParameter("DeadlineLiningDate", newDeadlineLiningDate) : new SqlParameter("DeadlineLiningDate", DBNull.Value);
            SqlParameter newP1DateParameter = (newP1Date.HasValue) ? new SqlParameter("P1Date", newP1Date) : new SqlParameter("P1Date", DBNull.Value);
            SqlParameter newM1DateParameter = (newM1Date.HasValue) ? new SqlParameter("M1Date", newM1Date) : new SqlParameter("M1Date", DBNull.Value);
            SqlParameter newM2DateParameter = (newM2Date.HasValue) ? new SqlParameter("M2Date", newM2Date) : new SqlParameter("M2Date", DBNull.Value);
            SqlParameter newInstallDateParameter = (newInstallDate.HasValue) ? new SqlParameter("InstallDate", newInstallDate) : new SqlParameter("InstallDate", DBNull.Value);
            SqlParameter newFinalVideoParameter = (newFinalVideo.HasValue) ? new SqlParameter("FinalVideoDate", newFinalVideo) : new SqlParameter("FinalVideoDate", DBNull.Value);
            SqlParameter newIssueIdentifiedParameter =  new SqlParameter("IssueIdentified", newIssueIdentified);
            SqlParameter newLfsIssueParameter =  new SqlParameter("IssueLFS", newLfsIssue);
            SqlParameter newClientIssueParameter =  new SqlParameter("IssueClient", newClientIssue);
            SqlParameter newSalesIssueParameter =  new SqlParameter("IssueSales", newSalesIssue);
            SqlParameter newIssueGivenToClientParameter =  new SqlParameter("IssueGivenToClient", newIssueGivenToClient);
            SqlParameter newIssueResolvedParameter =  new SqlParameter("IssueResolved", newIssueResolved);
            SqlParameter newIssueInvestigationParameter = new SqlParameter("IssueInvestigation", newIssueInvestigation);
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);

            string command = "UPDATE [dbo].[LFS_WORK_FULLLENGTHLINING] " +
                " SET [ClientID] = @ClientID, [ProposedLiningDate] = @ProposedLiningDate, [DeadlineLiningDate] = @DeadlineLiningDate, " +
                " [P1Date] = @P1Date, [M1Date] = @M1Date, [M2Date] = @M2Date, " +
                " [InstallDate] = @InstallDate, [FinalVideoDate] = @FinalVideoDate, [IssueIdentified] = @IssueIdentified," +
                " [IssueLFS] = @IssueLFS, [IssueClient] = @IssueClient, [IssueSales] = @IssueSales, " +
                " [IssueGivenToClient] = @IssueGivenToClient, [IssueResolved] = @IssueResolved, " +
                " [IssueInvestigation] = @IssueInvestigation" +
                " WHERE ([WorkID] = @Original_WorkID) AND" +
                " ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID)";

            int rowsAffected = (int)ExecuteNonQuery(command, originalWorkIdParameter, originalClientIdParameter, originalProposedLiningDateParameter, originalDeadlineLiningDateParameter, originalP1DateParameter, originalM1DateParameter, originalM2DateParameter, originalInstallDateParameter, originalFinalVideoParameter, originalIssueIdentifiedParameter, originalLfsIssueParameter, originalClientIssueParameter, originalSalesIssueParameter, originalIssueGivenToClientParameter, originalIssueResolvedParameter, originalIssueInvestigationParameter, originalDeletedParameter, originalCompanyIdParameter, newWorkIdParameter, newClientIdParameter, newProposedLiningDateParameter, newDeadlineLiningDateParameter, newP1DateParameter, newM1DateParameter, newM2DateParameter, newInstallDateParameter, newFinalVideoParameter, newIssueIdentifiedParameter, newLfsIssueParameter, newClientIssueParameter, newSalesIssueParameter, newIssueGivenToClientParameter, newIssueResolvedParameter, newIssueInvestigationParameter, newDeletedParameter, newCompanyIdParameter); 

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

            string command = "UPDATE [dbo].[LFS_WORK_FULLLENGTHLINING] SET  [Deleted] = @Deleted  " +
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
