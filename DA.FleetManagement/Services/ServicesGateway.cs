using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.FleetManagement.Services
{
    /// <summary>
    /// ServicesGateway
    /// </summary>
    public class ServicesGateway : DataTableGateway
    {
        ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ServicesGateway()
            : base("LFS_FM_SERVICE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ServicesGateway(DataSet data)
            : base(data, "LFS_FM_SERVICE")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ServicesTDS();
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
            tableMapping.DataSetTable = "LFS_FM_SERVICE";
            tableMapping.ColumnMappings.Add("ServiceID", "ServiceID");
            tableMapping.ColumnMappings.Add("Number", "Number");
            tableMapping.ColumnMappings.Add("DateTime_", "DateTime_");
            tableMapping.ColumnMappings.Add("MTO", "MTO");
            tableMapping.ColumnMappings.Add("Description", "Description");
            tableMapping.ColumnMappings.Add("UnitID", "UnitID");
            tableMapping.ColumnMappings.Add("Type", "Type");
            tableMapping.ColumnMappings.Add("State", "State");
            tableMapping.ColumnMappings.Add("OwnerID", "OwnerID");
            tableMapping.ColumnMappings.Add("AssignDateTime", "AssignDateTime");
            tableMapping.ColumnMappings.Add("AssignDeadlineDate", "AssignDeadlineDate");
            tableMapping.ColumnMappings.Add("AssignTeamMember", "AssignTeamMember");
            tableMapping.ColumnMappings.Add("AssignTeamMemberID", "AssignTeamMemberID");
            tableMapping.ColumnMappings.Add("AssignThirdPartyVendor", "AssignThirdPartyVendor");
            tableMapping.ColumnMappings.Add("AcceptDateTime", "AcceptDateTime");
            tableMapping.ColumnMappings.Add("RejectDateTime", "RejectDateTime");
            tableMapping.ColumnMappings.Add("RejectReason", "RejectReason");
            tableMapping.ColumnMappings.Add("StartWorkDateTime", "StartWorkDateTime");
            tableMapping.ColumnMappings.Add("StartWorkOutOfServiceDate", "StartWorkOutOfServiceDate");
            tableMapping.ColumnMappings.Add("StartWorkOutOfServiceTime", "StartWorkOutOfServiceTime");
            tableMapping.ColumnMappings.Add("CompleteWorkDateTime", "CompleteWorkDateTime");
            tableMapping.ColumnMappings.Add("CompleteWorkBackToServiceDate", "CompleteWorkBackToServiceDate");
            tableMapping.ColumnMappings.Add("CompleteWorkBackToServiceTime", "CompleteWorkBackToServiceTime");
            tableMapping.ColumnMappings.Add("CompleteWorkDetailDescription", "CompleteWorkDetailDescription");
            tableMapping.ColumnMappings.Add("CompleteWorkDetailPreventable", "CompleteWorkDetailPreventable");
            tableMapping.ColumnMappings.Add("CompleteWorkDetailTMLabourHours", "CompleteWorkDetailTMLabourHours");
            tableMapping.ColumnMappings.Add("CompleteWorkDetailTMCost", "CompleteWorkDetailTMCost");
            tableMapping.ColumnMappings.Add("CompleteWorkDetailTPVInvoiceNumber", "CompleteWorkDetailTPVInvoiceNumber");
            tableMapping.ColumnMappings.Add("CompleteWorkDetailTPVInvoiceAmout", "CompleteWorkDetailTPVInvoiceAmout");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("Notes", "Notes");
            tableMapping.ColumnMappings.Add("RuleID", "RuleID");
            tableMapping.ColumnMappings.Add("LIBRARY_CATEGORIES_ID", "LIBRARY_CATEGORIES_ID");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[LFS_FM_SERVICE] WHERE (([ServiceID] = @Original_ServiceID) AND" +
                " ([Number] = @Original_Number) AND ([DateTime_] = @Original_DateTime_) AND ([MTO" +
                "] = @Original_MTO) AND ((@IsNull_UnitID = 1 AND [UnitID] IS NULL) OR ([UnitID] =" +
                " @Original_UnitID)) AND ([Type] = @Original_Type) AND ([State] = @Original_State" +
                ") AND ([OwnerID] = @Original_OwnerID) AND ((@IsNull_AssignDateTime = 1 AND [Assi" +
                "gnDateTime] IS NULL) OR ([AssignDateTime] = @Original_AssignDateTime)) AND ((@Is" +
                "Null_AssignDeadlineDate = 1 AND [AssignDeadlineDate] IS NULL) OR ([AssignDeadlin" +
                "eDate] = @Original_AssignDeadlineDate)) AND ((@IsNull_AssignTeamMember = 1 AND [" +
                "AssignTeamMember] IS NULL) OR ([AssignTeamMember] = @Original_AssignTeamMember))" +
                " AND ((@IsNull_AssignTeamMemberID = 1 AND [AssignTeamMemberID] IS NULL) OR ([Ass" +
                "ignTeamMemberID] = @Original_AssignTeamMemberID)) AND ((@IsNull_AssignThirdParty" +
                "Vendor = 1 AND [AssignThirdPartyVendor] IS NULL) OR ([AssignThirdPartyVendor] = " +
                "@Original_AssignThirdPartyVendor)) AND ((@IsNull_AcceptDateTime = 1 AND [AcceptD" +
                "ateTime] IS NULL) OR ([AcceptDateTime] = @Original_AcceptDateTime)) AND ((@IsNul" +
                "l_RejectDateTime = 1 AND [RejectDateTime] IS NULL) OR ([RejectDateTime] = @Origi" +
                "nal_RejectDateTime)) AND ((@IsNull_StartWorkDateTime = 1 AND [StartWorkDateTime]" +
                " IS NULL) OR ([StartWorkDateTime] = @Original_StartWorkDateTime)) AND ((@IsNull_" +
                "StartWorkOutOfServiceDate = 1 AND [StartWorkOutOfServiceDate] IS NULL) OR ([Star" +
                "tWorkOutOfServiceDate] = @Original_StartWorkOutOfServiceDate)) AND ((@IsNull_Sta" +
                "rtWorkOutOfServiceTime = 1 AND [StartWorkOutOfServiceTime] IS NULL) OR ([StartWo" +
                "rkOutOfServiceTime] = @Original_StartWorkOutOfServiceTime)) AND ((@IsNull_Comple" +
                "teWorkDateTime = 1 AND [CompleteWorkDateTime] IS NULL) OR ([CompleteWorkDateTime" +
                "] = @Original_CompleteWorkDateTime)) AND ((@IsNull_CompleteWorkBackToServiceDate" +
                " = 1 AND [CompleteWorkBackToServiceDate] IS NULL) OR ([CompleteWorkBackToService" +
                "Date] = @Original_CompleteWorkBackToServiceDate)) AND ((@IsNull_CompleteWorkBack" +
                "ToServiceTime = 1 AND [CompleteWorkBackToServiceTime] IS NULL) OR ([CompleteWork" +
                "BackToServiceTime] = @Original_CompleteWorkBackToServiceTime)) AND ([CompleteWor" +
                "kDetailPreventable] = @Original_CompleteWorkDetailPreventable) AND ((@IsNull_Com" +
                "pleteWorkDetailTMLabourHours = 1 AND [CompleteWorkDetailTMLabourHours] IS NULL) " +
                "OR ([CompleteWorkDetailTMLabourHours] = @Original_CompleteWorkDetailTMLabourHour" +
                "s)) AND ((@IsNull_CompleteWorkDetailTMCost = 1 AND [CompleteWorkDetailTMCost] IS" +
                " NULL) OR ([CompleteWorkDetailTMCost] = @Original_CompleteWorkDetailTMCost)) AND" +
                " ((@IsNull_CompleteWorkDetailTPVInvoiceNumber = 1 AND [CompleteWorkDetailTPVInvo" +
                "iceNumber] IS NULL) OR ([CompleteWorkDetailTPVInvoiceNumber] = @Original_Complet" +
                "eWorkDetailTPVInvoiceNumber)) AND ((@IsNull_CompleteWorkDetailTPVInvoiceAmout = " +
                "1 AND [CompleteWorkDetailTPVInvoiceAmout] IS NULL) OR ([CompleteWorkDetailTPVInv" +
                "oiceAmout] = @Original_CompleteWorkDetailTPVInvoiceAmout)) AND ([Deleted] = @Ori" +
                "ginal_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND ((@IsNull_RuleID = " +
                "1 AND [RuleID] IS NULL) OR ([RuleID] = @Original_RuleID)) AND ((@IsNull_LIBRARY_" +
                "CATEGORIES_ID = 1 AND [LIBRARY_CATEGORIES_ID] IS NULL) OR ([LIBRARY_CATEGORIES_I" +
                "D] = @Original_LIBRARY_CATEGORIES_ID)))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ServiceID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ServiceID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Number", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Number", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DateTime_", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DateTime_", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MTO", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MTO", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_UnitID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_UnitID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Type", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Type", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_State", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "State", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_OwnerID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "OwnerID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_AssignDateTime", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AssignDateTime", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_AssignDateTime", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AssignDateTime", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_AssignDeadlineDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AssignDeadlineDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_AssignDeadlineDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AssignDeadlineDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_AssignTeamMember", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AssignTeamMember", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_AssignTeamMember", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AssignTeamMember", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_AssignTeamMemberID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AssignTeamMemberID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_AssignTeamMemberID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AssignTeamMemberID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_AssignThirdPartyVendor", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AssignThirdPartyVendor", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_AssignThirdPartyVendor", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AssignThirdPartyVendor", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_AcceptDateTime", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AcceptDateTime", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_AcceptDateTime", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AcceptDateTime", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_RejectDateTime", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RejectDateTime", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RejectDateTime", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RejectDateTime", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_StartWorkDateTime", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StartWorkDateTime", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_StartWorkDateTime", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StartWorkDateTime", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_StartWorkOutOfServiceDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StartWorkOutOfServiceDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_StartWorkOutOfServiceDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StartWorkOutOfServiceDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_StartWorkOutOfServiceTime", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StartWorkOutOfServiceTime", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_StartWorkOutOfServiceTime", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StartWorkOutOfServiceTime", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_CompleteWorkDateTime", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CompleteWorkDateTime", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CompleteWorkDateTime", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CompleteWorkDateTime", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_CompleteWorkBackToServiceDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CompleteWorkBackToServiceDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CompleteWorkBackToServiceDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CompleteWorkBackToServiceDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_CompleteWorkBackToServiceTime", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CompleteWorkBackToServiceTime", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CompleteWorkBackToServiceTime", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CompleteWorkBackToServiceTime", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CompleteWorkDetailPreventable", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CompleteWorkDetailPreventable", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_CompleteWorkDetailTMLabourHours", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CompleteWorkDetailTMLabourHours", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CompleteWorkDetailTMLabourHours", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CompleteWorkDetailTMLabourHours", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_CompleteWorkDetailTMCost", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CompleteWorkDetailTMCost", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CompleteWorkDetailTMCost", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CompleteWorkDetailTMCost", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_CompleteWorkDetailTPVInvoiceNumber", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CompleteWorkDetailTPVInvoiceNumber", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CompleteWorkDetailTPVInvoiceNumber", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CompleteWorkDetailTPVInvoiceNumber", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_CompleteWorkDetailTPVInvoiceAmout", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CompleteWorkDetailTPVInvoiceAmout", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CompleteWorkDetailTPVInvoiceAmout", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CompleteWorkDetailTPVInvoiceAmout", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_RuleID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RuleID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RuleID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RuleID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_LIBRARY_CATEGORIES_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LIBRARY_CATEGORIES_ID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LIBRARY_CATEGORIES_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LIBRARY_CATEGORIES_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[LFS_FM_SERVICE] ([Number], [DateTime_], [MTO], [Description], " +
                "[UnitID], [Type], [State], [OwnerID], [AssignDateTime], [AssignDeadlineDate], [A" +
                "ssignTeamMember], [AssignTeamMemberID], [AssignThirdPartyVendor], [AcceptDateTim" +
                "e], [RejectDateTime], [RejectReason], [StartWorkDateTime], [StartWorkOutOfServic" +
                "eDate], [StartWorkOutOfServiceTime], [CompleteWorkDateTime], [CompleteWorkBackTo" +
                "ServiceDate], [CompleteWorkBackToServiceTime], [CompleteWorkDetailDescription], " +
                "[CompleteWorkDetailPreventable], [CompleteWorkDetailTMLabourHours], [CompleteWor" +
                "kDetailTMCost], [CompleteWorkDetailTPVInvoiceNumber], [CompleteWorkDetailTPVInvo" +
                "iceAmout], [Deleted], [COMPANY_ID], [Notes], [RuleID], [LIBRARY_CATEGORIES_ID]) " +
                "VALUES (@Number, @DateTime_, @MTO, @Description, @UnitID, @Type, @State, @OwnerI" +
                "D, @AssignDateTime, @AssignDeadlineDate, @AssignTeamMember, @AssignTeamMemberID," +
                " @AssignThirdPartyVendor, @AcceptDateTime, @RejectDateTime, @RejectReason, @Star" +
                "tWorkDateTime, @StartWorkOutOfServiceDate, @StartWorkOutOfServiceTime, @Complete" +
                "WorkDateTime, @CompleteWorkBackToServiceDate, @CompleteWorkBackToServiceTime, @C" +
                "ompleteWorkDetailDescription, @CompleteWorkDetailPreventable, @CompleteWorkDetai" +
                "lTMLabourHours, @CompleteWorkDetailTMCost, @CompleteWorkDetailTPVInvoiceNumber, " +
                "@CompleteWorkDetailTPVInvoiceAmout, @Deleted, @COMPANY_ID, @Notes, @RuleID, @LIB" +
                "RARY_CATEGORIES_ID);\r\nSELECT ServiceID, Number, DateTime_, MTO, Description, Uni" +
                "tID, Type, State, OwnerID, AssignDateTime, AssignDeadlineDate, AssignTeamMember," +
                " AssignTeamMemberID, AssignThirdPartyVendor, AcceptDateTime, RejectDateTime, Rej" +
                "ectReason, StartWorkDateTime, StartWorkOutOfServiceDate, StartWorkOutOfServiceTi" +
                "me, CompleteWorkDateTime, CompleteWorkBackToServiceDate, CompleteWorkBackToServi" +
                "ceTime, CompleteWorkDetailDescription, CompleteWorkDetailPreventable, CompleteWo" +
                "rkDetailTMLabourHours, CompleteWorkDetailTMCost, CompleteWorkDetailTPVInvoiceNum" +
                "ber, CompleteWorkDetailTPVInvoiceAmout, Deleted, COMPANY_ID, Notes, RuleID, LIBR" +
                "ARY_CATEGORIES_ID FROM LFS_FM_SERVICE WHERE (ServiceID = SCOPE_IDENTITY())";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Number", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Number", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DateTime_", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DateTime_", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MTO", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MTO", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Description", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Description", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@UnitID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Type", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Type", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@State", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "State", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@OwnerID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "OwnerID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@AssignDateTime", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AssignDateTime", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@AssignDeadlineDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AssignDeadlineDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@AssignTeamMember", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AssignTeamMember", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@AssignTeamMemberID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AssignTeamMemberID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@AssignThirdPartyVendor", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AssignThirdPartyVendor", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@AcceptDateTime", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AcceptDateTime", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RejectDateTime", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RejectDateTime", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RejectReason", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RejectReason", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@StartWorkDateTime", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StartWorkDateTime", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@StartWorkOutOfServiceDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StartWorkOutOfServiceDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@StartWorkOutOfServiceTime", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StartWorkOutOfServiceTime", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CompleteWorkDateTime", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CompleteWorkDateTime", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CompleteWorkBackToServiceDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CompleteWorkBackToServiceDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CompleteWorkBackToServiceTime", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CompleteWorkBackToServiceTime", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CompleteWorkDetailDescription", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CompleteWorkDetailDescription", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CompleteWorkDetailPreventable", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CompleteWorkDetailPreventable", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CompleteWorkDetailTMLabourHours", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CompleteWorkDetailTMLabourHours", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CompleteWorkDetailTMCost", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CompleteWorkDetailTMCost", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CompleteWorkDetailTPVInvoiceNumber", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CompleteWorkDetailTPVInvoiceNumber", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CompleteWorkDetailTPVInvoiceAmout", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CompleteWorkDetailTPVInvoiceAmout", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Notes", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Notes", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RuleID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RuleID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LIBRARY_CATEGORIES_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LIBRARY_CATEGORIES_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));

            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[LFS_FM_SERVICE] SET [Number] = @Number, [DateTime_] = @DateTime_, [" +
                "MTO] = @MTO, [Description] = @Description, [UnitID] = @UnitID, [Type] = @Type, [" +
                "State] = @State, [OwnerID] = @OwnerID, [AssignDateTime] = @AssignDateTime, [Assi" +
                "gnDeadlineDate] = @AssignDeadlineDate, [AssignTeamMember] = @AssignTeamMember, [" +
                "AssignTeamMemberID] = @AssignTeamMemberID, [AssignThirdPartyVendor] = @AssignThi" +
                "rdPartyVendor, [AcceptDateTime] = @AcceptDateTime, [RejectDateTime] = @RejectDat" +
                "eTime, [RejectReason] = @RejectReason, [StartWorkDateTime] = @StartWorkDateTime," +
                " [StartWorkOutOfServiceDate] = @StartWorkOutOfServiceDate, [StartWorkOutOfServic" +
                "eTime] = @StartWorkOutOfServiceTime, [CompleteWorkDateTime] = @CompleteWorkDateT" +
                "ime, [CompleteWorkBackToServiceDate] = @CompleteWorkBackToServiceDate, [Complete" +
                "WorkBackToServiceTime] = @CompleteWorkBackToServiceTime, [CompleteWorkDetailDesc" +
                "ription] = @CompleteWorkDetailDescription, [CompleteWorkDetailPreventable] = @Co" +
                "mpleteWorkDetailPreventable, [CompleteWorkDetailTMLabourHours] = @CompleteWorkDe" +
                "tailTMLabourHours, [CompleteWorkDetailTMCost] = @CompleteWorkDetailTMCost, [Comp" +
                "leteWorkDetailTPVInvoiceNumber] = @CompleteWorkDetailTPVInvoiceNumber, [Complete" +
                "WorkDetailTPVInvoiceAmout] = @CompleteWorkDetailTPVInvoiceAmout, [Deleted] = @De" +
                "leted, [COMPANY_ID] = @COMPANY_ID, [Notes] = @Notes, [RuleID] = @RuleID, [LIBRAR" +
                "Y_CATEGORIES_ID] = @LIBRARY_CATEGORIES_ID WHERE (([ServiceID] = @Original_Servic" +
                "eID) AND ([Number] = @Original_Number) AND ([DateTime_] = @Original_DateTime_) A" +
                "ND ([MTO] = @Original_MTO) AND ((@IsNull_UnitID = 1 AND [UnitID] IS NULL) OR ([U" +
                "nitID] = @Original_UnitID)) AND ([Type] = @Original_Type) AND ([State] = @Origin" +
                "al_State) AND ([OwnerID] = @Original_OwnerID) AND ((@IsNull_AssignDateTime = 1 A" +
                "ND [AssignDateTime] IS NULL) OR ([AssignDateTime] = @Original_AssignDateTime)) A" +
                "ND ((@IsNull_AssignDeadlineDate = 1 AND [AssignDeadlineDate] IS NULL) OR ([Assig" +
                "nDeadlineDate] = @Original_AssignDeadlineDate)) AND ((@IsNull_AssignTeamMember =" +
                " 1 AND [AssignTeamMember] IS NULL) OR ([AssignTeamMember] = @Original_AssignTeam" +
                "Member)) AND ((@IsNull_AssignTeamMemberID = 1 AND [AssignTeamMemberID] IS NULL) " +
                "OR ([AssignTeamMemberID] = @Original_AssignTeamMemberID)) AND ((@IsNull_AssignTh" +
                "irdPartyVendor = 1 AND [AssignThirdPartyVendor] IS NULL) OR ([AssignThirdPartyVe" +
                "ndor] = @Original_AssignThirdPartyVendor)) AND ((@IsNull_AcceptDateTime = 1 AND " +
                "[AcceptDateTime] IS NULL) OR ([AcceptDateTime] = @Original_AcceptDateTime)) AND " +
                "((@IsNull_RejectDateTime = 1 AND [RejectDateTime] IS NULL) OR ([RejectDateTime] " +
                "= @Original_RejectDateTime)) AND ((@IsNull_StartWorkDateTime = 1 AND [StartWorkD" +
                "ateTime] IS NULL) OR ([StartWorkDateTime] = @Original_StartWorkDateTime)) AND ((" +
                "@IsNull_StartWorkOutOfServiceDate = 1 AND [StartWorkOutOfServiceDate] IS NULL) O" +
                "R ([StartWorkOutOfServiceDate] = @Original_StartWorkOutOfServiceDate)) AND ((@Is" +
                "Null_StartWorkOutOfServiceTime = 1 AND [StartWorkOutOfServiceTime] IS NULL) OR (" +
                "[StartWorkOutOfServiceTime] = @Original_StartWorkOutOfServiceTime)) AND ((@IsNul" +
                "l_CompleteWorkDateTime = 1 AND [CompleteWorkDateTime] IS NULL) OR ([CompleteWork" +
                "DateTime] = @Original_CompleteWorkDateTime)) AND ((@IsNull_CompleteWorkBackToSer" +
                "viceDate = 1 AND [CompleteWorkBackToServiceDate] IS NULL) OR ([CompleteWorkBackT" +
                "oServiceDate] = @Original_CompleteWorkBackToServiceDate)) AND ((@IsNull_Complete" +
                "WorkBackToServiceTime = 1 AND [CompleteWorkBackToServiceTime] IS NULL) OR ([Comp" +
                "leteWorkBackToServiceTime] = @Original_CompleteWorkBackToServiceTime)) AND ([Com" +
                "pleteWorkDetailPreventable] = @Original_CompleteWorkDetailPreventable) AND ((@Is" +
                "Null_CompleteWorkDetailTMLabourHours = 1 AND [CompleteWorkDetailTMLabourHours] I" +
                "S NULL) OR ([CompleteWorkDetailTMLabourHours] = @Original_CompleteWorkDetailTMLa" +
                "bourHours)) AND ((@IsNull_CompleteWorkDetailTMCost = 1 AND [CompleteWorkDetailTM" +
                "Cost] IS NULL) OR ([CompleteWorkDetailTMCost] = @Original_CompleteWorkDetailTMCo" +
                "st)) AND ((@IsNull_CompleteWorkDetailTPVInvoiceNumber = 1 AND [CompleteWorkDetai" +
                "lTPVInvoiceNumber] IS NULL) OR ([CompleteWorkDetailTPVInvoiceNumber] = @Original" +
                "_CompleteWorkDetailTPVInvoiceNumber)) AND ((@IsNull_CompleteWorkDetailTPVInvoice" +
                "Amout = 1 AND [CompleteWorkDetailTPVInvoiceAmout] IS NULL) OR ([CompleteWorkDeta" +
                "ilTPVInvoiceAmout] = @Original_CompleteWorkDetailTPVInvoiceAmout)) AND ([Deleted" +
                "] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND ((@IsNull_R" +
                "uleID = 1 AND [RuleID] IS NULL) OR ([RuleID] = @Original_RuleID)) AND ((@IsNull_" +
                "LIBRARY_CATEGORIES_ID = 1 AND [LIBRARY_CATEGORIES_ID] IS NULL) OR ([LIBRARY_CATE" +
                "GORIES_ID] = @Original_LIBRARY_CATEGORIES_ID)));\r\nSELECT ServiceID, Number, Date" +
                "Time_, MTO, Description, UnitID, Type, State, OwnerID, AssignDateTime, AssignDea" +
                "dlineDate, AssignTeamMember, AssignTeamMemberID, AssignThirdPartyVendor, AcceptD" +
                "ateTime, RejectDateTime, RejectReason, StartWorkDateTime, StartWorkOutOfServiceD" +
                "ate, StartWorkOutOfServiceTime, CompleteWorkDateTime, CompleteWorkBackToServiceD" +
                "ate, CompleteWorkBackToServiceTime, CompleteWorkDetailDescription, CompleteWorkD" +
                "etailPreventable, CompleteWorkDetailTMLabourHours, CompleteWorkDetailTMCost, Com" +
                "pleteWorkDetailTPVInvoiceNumber, CompleteWorkDetailTPVInvoiceAmout, Deleted, COM" +
                "PANY_ID, Notes, RuleID, LIBRARY_CATEGORIES_ID FROM LFS_FM_SERVICE WHERE (Service" +
                "ID = @ServiceID)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Number", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Number", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DateTime_", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DateTime_", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MTO", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MTO", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Description", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Description", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@UnitID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Type", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Type", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@State", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "State", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@OwnerID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "OwnerID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@AssignDateTime", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AssignDateTime", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@AssignDeadlineDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AssignDeadlineDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@AssignTeamMember", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AssignTeamMember", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@AssignTeamMemberID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AssignTeamMemberID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@AssignThirdPartyVendor", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AssignThirdPartyVendor", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@AcceptDateTime", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AcceptDateTime", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RejectDateTime", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RejectDateTime", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RejectReason", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RejectReason", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@StartWorkDateTime", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StartWorkDateTime", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@StartWorkOutOfServiceDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StartWorkOutOfServiceDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@StartWorkOutOfServiceTime", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StartWorkOutOfServiceTime", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CompleteWorkDateTime", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CompleteWorkDateTime", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CompleteWorkBackToServiceDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CompleteWorkBackToServiceDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CompleteWorkBackToServiceTime", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CompleteWorkBackToServiceTime", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CompleteWorkDetailDescription", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CompleteWorkDetailDescription", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CompleteWorkDetailPreventable", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CompleteWorkDetailPreventable", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CompleteWorkDetailTMLabourHours", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CompleteWorkDetailTMLabourHours", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CompleteWorkDetailTMCost", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CompleteWorkDetailTMCost", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CompleteWorkDetailTPVInvoiceNumber", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CompleteWorkDetailTPVInvoiceNumber", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CompleteWorkDetailTPVInvoiceAmout", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CompleteWorkDetailTPVInvoiceAmout", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Notes", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Notes", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RuleID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RuleID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LIBRARY_CATEGORIES_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LIBRARY_CATEGORIES_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ServiceID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ServiceID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Number", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Number", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DateTime_", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DateTime_", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MTO", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MTO", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_UnitID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_UnitID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Type", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Type", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_State", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "State", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_OwnerID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "OwnerID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_AssignDateTime", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AssignDateTime", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_AssignDateTime", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AssignDateTime", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_AssignDeadlineDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AssignDeadlineDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_AssignDeadlineDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AssignDeadlineDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_AssignTeamMember", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AssignTeamMember", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_AssignTeamMember", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AssignTeamMember", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_AssignTeamMemberID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AssignTeamMemberID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_AssignTeamMemberID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AssignTeamMemberID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_AssignThirdPartyVendor", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AssignThirdPartyVendor", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_AssignThirdPartyVendor", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AssignThirdPartyVendor", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_AcceptDateTime", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AcceptDateTime", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_AcceptDateTime", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AcceptDateTime", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_RejectDateTime", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RejectDateTime", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RejectDateTime", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RejectDateTime", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_StartWorkDateTime", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StartWorkDateTime", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_StartWorkDateTime", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StartWorkDateTime", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_StartWorkOutOfServiceDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StartWorkOutOfServiceDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_StartWorkOutOfServiceDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StartWorkOutOfServiceDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_StartWorkOutOfServiceTime", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StartWorkOutOfServiceTime", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_StartWorkOutOfServiceTime", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StartWorkOutOfServiceTime", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_CompleteWorkDateTime", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CompleteWorkDateTime", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CompleteWorkDateTime", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CompleteWorkDateTime", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_CompleteWorkBackToServiceDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CompleteWorkBackToServiceDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CompleteWorkBackToServiceDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CompleteWorkBackToServiceDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_CompleteWorkBackToServiceTime", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CompleteWorkBackToServiceTime", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CompleteWorkBackToServiceTime", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CompleteWorkBackToServiceTime", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CompleteWorkDetailPreventable", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CompleteWorkDetailPreventable", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_CompleteWorkDetailTMLabourHours", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CompleteWorkDetailTMLabourHours", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CompleteWorkDetailTMLabourHours", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CompleteWorkDetailTMLabourHours", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_CompleteWorkDetailTMCost", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CompleteWorkDetailTMCost", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CompleteWorkDetailTMCost", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CompleteWorkDetailTMCost", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_CompleteWorkDetailTPVInvoiceNumber", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CompleteWorkDetailTPVInvoiceNumber", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CompleteWorkDetailTPVInvoiceNumber", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CompleteWorkDetailTPVInvoiceNumber", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_CompleteWorkDetailTPVInvoiceAmout", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CompleteWorkDetailTPVInvoiceAmout", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CompleteWorkDetailTPVInvoiceAmout", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CompleteWorkDetailTPVInvoiceAmout", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_RuleID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RuleID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RuleID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RuleID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_LIBRARY_CATEGORIES_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LIBRARY_CATEGORIES_ID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LIBRARY_CATEGORIES_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LIBRARY_CATEGORIES_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ServiceID", global::System.Data.SqlDbType.Int, 4, global::System.Data.ParameterDirection.Input, 0, 0, "ServiceID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));

            #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// LoadByServiceId
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>data set</returns>
        public DataSet LoadByServiceId(int serviceId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_SERVICESGATEWAY_LOADBYSERVICEID", new SqlParameter("@serviceId", serviceId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadTop1ByServiceId
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <returns>data set</returns>
        public DataSet LoadTop1ByServiceId(int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_SERVICESGATEWAY_LOADTOP1BYSERVICEID", new SqlParameter("@companyId", companyId));
            return Data;
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
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.FleetManagement.Services.ServicesGateway.GetRow");
            }
        }

        

        /// <summary>
        /// GetNumberTop1. If not exists, raise an exception.
        /// </summary>
        /// <returns>GetNumber or EMPTY</returns>
        public string GetNumberTop1()
        {
            return (string)GetRowTop1()["Number"];
        }



                    

                        
        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROWS
        //

        /// <summary>
        /// Insert a service (direct to DB)
        /// </summary>
        /// <param name="number">number</param>
        /// <param name="dateTime_">dateTime_</param>
        /// <param name="mto">mto</param>
        /// <param name="description">description</param>
        /// <param name="unitId">unitId</param>
        /// <param name="type">type</param>
        /// <param name="state">state</param>
        /// <param name="ownerId">ownerId</param>
        /// <param name="assignDateTime">assignDateTime</param>
        /// <param name="assignDeadlineDate">assignDeadlineDate</param>
        /// <param name="assignTeamMember">assignTeamMember</param>
        /// <param name="assignTeamMemberID">assignTeamMemberID</param>
        /// <param name="assignThirdPartyVendor">assignThirdPartyVendor</param>
        /// <param name="acceptDateTime">acceptDateTime</param>
        /// <param name="rejectDateTime">rejectDateTime</param>
        /// <param name="rejectReason">rejectReason</param>
        /// <param name="startWorkDateTime">startWorkDateTime</param>
        /// <param name="startWorkOutOfServiceDate">startWorkOutOfServiceDate</param>
        /// <param name="startWorkOutOfServiceTime">startWorkOutOfServiceTime</param>
        /// <param name="completeWorkDateTime">completeWorkDateTime</param>
        /// <param name="completeWorkBackToServiceDate">completeWorkBackToServiceDate</param>
        /// <param name="completeWorkBackToServiceTime">completeWorkBackToServiceTime</param>
        /// <param name="completeWorkDetailDescription">completeWorkDetailDescription</param>
        /// <param name="completeWorkDetailPreventable">completeWorkDetailPreventable</param>
        /// <param name="completeWorkDetailTMLabourHours">completeWorkDetailTMLabourHours</param>
        /// <param name="completeWorkDetailTMCost">completeWorkDetailTMCost</param>
        /// <param name="completeWorkDetailTPVInvoiceNumber">completeWorkDetailTPVInvoiceNumber</param>
        /// <param name="completeWorkDetailTPVInvoiceAmout">completeWorkDetailTPVInvoiceAmout</param>
        /// <param name="notes">notes</param>
        /// <param name="ruleId">ruleId</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="libraryCategoriesId">libraryCategoriesId</param>
        /// <returns>service id</returns>
        public int Insert(string number, DateTime? dateTime_, bool mto, string description, int? unitId, string type, string state, int ownerId, DateTime? assignDateTime, DateTime? assignDeadlineDate,  bool assignTeamMember, int? assignTeamMemberID, string assignThirdPartyVendor, DateTime? acceptDateTime, DateTime? rejectDateTime, string rejectReason,  DateTime? startWorkDateTime, DateTime? startWorkOutOfServiceDate, string startWorkOutOfServiceTime, DateTime? completeWorkDateTime, DateTime? completeWorkBackToServiceDate, string completeWorkBackToServiceTime, string completeWorkDetailDescription, bool completeWorkDetailPreventable, decimal? completeWorkDetailTMLabourHours, decimal? completeWorkDetailTMCost, string completeWorkDetailTPVInvoiceNumber, decimal? completeWorkDetailTPVInvoiceAmout, string notes, int? ruleId, bool deleted, int companyId, int? libraryCategoriesId)
        {
            SqlParameter numberParameter = (number.Trim() != "") ? new SqlParameter("Number", number.Trim()) : new SqlParameter("Number", DBNull.Value);
            SqlParameter dateTime_Parameter = (dateTime_.HasValue) ? new SqlParameter("DateTime_", dateTime_) : new SqlParameter("DateTime_", DBNull.Value);
            SqlParameter mtoParameter = new SqlParameter("MTO", mto);
            SqlParameter descriptionParameter = (description.Trim() != "") ? new SqlParameter("Description", description.Trim()) : new SqlParameter("Description", DBNull.Value);
            SqlParameter unitIdParameter = (unitId.HasValue) ? new SqlParameter("UnitID", unitId) : new SqlParameter("UnitID", DBNull.Value);
            SqlParameter typeParameter = (type.Trim() != "") ? new SqlParameter("Type", type.Trim()) : new SqlParameter("Type", DBNull.Value);
            SqlParameter stateParameter = (state.Trim() != "") ? new SqlParameter("State", state.Trim()) : new SqlParameter("State", DBNull.Value);
            SqlParameter ownerIdParameter = new SqlParameter("OwnerID", ownerId);
            SqlParameter assignDateTimeParameter = (assignDateTime.HasValue) ? new SqlParameter("AssignDateTime", assignDateTime) : new SqlParameter("AssignDateTime", DBNull.Value);
            SqlParameter assignDeadlineDateParameter = (assignDeadlineDate.HasValue) ? new SqlParameter("AssignDeadlineDate", assignDeadlineDate) : new SqlParameter("AssignDeadlineDate", DBNull.Value);
            SqlParameter assignTeamMemberParameter = new SqlParameter("AssignTeamMember", assignTeamMember);
            SqlParameter assignTeamMemberIDParameter = (assignTeamMemberID.HasValue) ? new SqlParameter("AssignTeamMemberID", assignTeamMemberID) : new SqlParameter("AssignTeamMemberID", DBNull.Value);
            SqlParameter assignThirdPartyVendorParameter = (assignThirdPartyVendor.Trim() != "") ? new SqlParameter("AssignThirdPartyVendor", assignThirdPartyVendor.Trim()) : new SqlParameter("AssignThirdPartyVendor", DBNull.Value);
            SqlParameter acceptDateTimeParameter = (acceptDateTime.HasValue) ? new SqlParameter("AcceptDateTime", acceptDateTime) : new SqlParameter("AcceptDateTime", DBNull.Value);
            SqlParameter rejectDateTimeParameter = (rejectDateTime.HasValue) ? new SqlParameter("RejectDateTime", rejectDateTime) : new SqlParameter("RejectDateTime", DBNull.Value);
            SqlParameter rejectReasonParameter = (rejectReason.Trim() != "") ? new SqlParameter("RejectReason", rejectReason.Trim()) : new SqlParameter("RejectReason", DBNull.Value);
            SqlParameter startWorkDateTimeParameter = (startWorkDateTime.HasValue) ? new SqlParameter("StartWorkDateTime", startWorkDateTime) : new SqlParameter("StartWorkDateTime", DBNull.Value);
            SqlParameter startWorkOutOfServiceDateParameter = (startWorkOutOfServiceDate.HasValue) ? new SqlParameter("StartWorkOutOfServiceDate", startWorkOutOfServiceDate) : new SqlParameter("StartWorkOutOfServiceDate", DBNull.Value);
            SqlParameter startWorkOutOfServiceTimeParameter = (startWorkOutOfServiceTime.Trim() != "") ? new SqlParameter("StartWorkOutOfServiceTime", startWorkOutOfServiceTime.Trim()) : new SqlParameter("StartWorkOutOfServiceTime", DBNull.Value);
            SqlParameter completeWorkDateTimeParameter = (completeWorkDateTime.HasValue) ? new SqlParameter("CompleteWorkDateTime", completeWorkDateTime) : new SqlParameter("CompleteWorkDateTime", DBNull.Value);
            SqlParameter completeWorkBackToServiceDateParameter = (completeWorkBackToServiceDate.HasValue) ? new SqlParameter("CompleteWorkBackToServiceDate", completeWorkBackToServiceDate) : new SqlParameter("CompleteWorkBackToServiceDate", DBNull.Value);
            SqlParameter completeWorkBackToServiceTimeParameter = (completeWorkBackToServiceTime.Trim() != "") ? new SqlParameter("CompleteWorkBackToServiceTime", completeWorkBackToServiceTime.Trim()) : new SqlParameter("CompleteWorkBackToServiceTime", DBNull.Value);
            SqlParameter completeWorkDetailDescriptionParameter = (completeWorkDetailDescription.Trim() != "") ? new SqlParameter("CompleteWorkDetailDescription", completeWorkDetailDescription.Trim()) : new SqlParameter("CompleteWorkDetailDescription", DBNull.Value);
            SqlParameter completeWorkDetailPreventableParameter = new SqlParameter("CompleteWorkDetailPreventable", completeWorkDetailPreventable);
            SqlParameter completeWorkDetailTMLabourHoursParameter = (completeWorkDetailTMLabourHours.HasValue) ? new SqlParameter("CompleteWorkDetailTMLabourHours", completeWorkDetailTMLabourHours) : new SqlParameter("CompleteWorkDetailTMLabourHours", DBNull.Value);
            SqlParameter completeWorkDetailTMCostParameter = (completeWorkDetailTMCost.HasValue) ? new SqlParameter("CompleteWorkDetailTMCost", completeWorkDetailTMCost) : new SqlParameter("CompleteWorkDetailTMCost", DBNull.Value);
            completeWorkDetailTMCostParameter.SqlDbType = SqlDbType.Money;           
            SqlParameter completeWorkDetailTPVInvoiceNumberParameter = (completeWorkDetailTPVInvoiceNumber.Trim() != "") ? new SqlParameter("CompleteWorkDetailTPVInvoiceNumber", completeWorkDetailTPVInvoiceNumber.Trim()) : new SqlParameter("CompleteWorkDetailTPVInvoiceNumber", DBNull.Value);
            SqlParameter completeWorkDetailTPVInvoiceAmoutParameter = (completeWorkDetailTPVInvoiceAmout.HasValue) ? new SqlParameter("CompleteWorkDetailTPVInvoiceAmout", completeWorkDetailTPVInvoiceAmout) : new SqlParameter("CompleteWorkDetailTPVInvoiceAmout", DBNull.Value);
            completeWorkDetailTPVInvoiceAmoutParameter.SqlDbType = SqlDbType.Money;
            SqlParameter notesParameter = (notes.Trim() != "") ? new SqlParameter("Notes", notes.Trim()) : new SqlParameter("Notes", DBNull.Value);
            SqlParameter ruleIdParameter = (ruleId.HasValue) ? new SqlParameter("RuleID", ruleId) : new SqlParameter("RuleID", DBNull.Value);
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            SqlParameter libraryCategoriesIdParameter = (libraryCategoriesId.HasValue) ? new SqlParameter("LIBRARY_CATEGORIES_ID", libraryCategoriesId) : new SqlParameter("LIBRARY_CATEGORIES_ID", DBNull.Value);
                                    
            string command = "INSERT INTO [dbo].[LFS_FM_SERVICE] ([Number], [DateTime_], [MTO], [Description], " +
                "[UnitID], [Type], [State], [OwnerID], [AssignDateTime], [AssignDeadlineDate], [A" +
                "ssignTeamMember], [AssignTeamMemberID], [AssignThirdPartyVendor], [AcceptDateTim" +
                "e], [RejectDateTime], [RejectReason], [StartWorkDateTime], [StartWorkOutOfServic" +
                "eDate], [StartWorkOutOfServiceTime], [CompleteWorkDateTime], [CompleteWorkBackTo" +
                "ServiceDate], [CompleteWorkBackToServiceTime], [CompleteWorkDetailDescription], " +
                "[CompleteWorkDetailPreventable], [CompleteWorkDetailTMLabourHours], [CompleteWor" +
                "kDetailTMCost], [CompleteWorkDetailTPVInvoiceNumber], [CompleteWorkDetailTPVInvo" +
                "iceAmout], [Deleted], [COMPANY_ID], [Notes], [RuleID], [LIBRARY_CATEGORIES_ID]) VALUES (@Number, @DateTim" +
                "e_, @MTO, @Description, @UnitID, @Type, @State, @OwnerID, @AssignDateTime, @Assi" +
                "gnDeadlineDate, @AssignTeamMember, @AssignTeamMemberID, @AssignThirdPartyVendor," +
                " @AcceptDateTime, @RejectDateTime, @RejectReason, @StartWorkDateTime, @StartWork" +
                "OutOfServiceDate, @StartWorkOutOfServiceTime, @CompleteWorkDateTime, @CompleteWo" +
                "rkBackToServiceDate, @CompleteWorkBackToServiceTime, @CompleteWorkDetailDescript" +
                "ion, @CompleteWorkDetailPreventable, @CompleteWorkDetailTMLabourHours, @Complete" +
                "WorkDetailTMCost, @CompleteWorkDetailTPVInvoiceNumber, @CompleteWorkDetailTPVInv" +
                "oiceAmout, @Deleted, @COMPANY_ID, @Notes, @RuleID, @LIBRARY_CATEGORIES_ID);SELECT ServiceID FROM LFS_FM_SERVICE WHERE (ServiceID = SCOPE_IDENTITY())";

            int serviceId = (int)ExecuteScalar(command, numberParameter, dateTime_Parameter, mtoParameter, descriptionParameter, unitIdParameter, typeParameter, stateParameter, ownerIdParameter, assignDateTimeParameter, assignDeadlineDateParameter, assignTeamMemberParameter, assignTeamMemberIDParameter, assignThirdPartyVendorParameter, acceptDateTimeParameter, rejectDateTimeParameter, rejectReasonParameter, startWorkDateTimeParameter, startWorkOutOfServiceDateParameter, startWorkOutOfServiceTimeParameter, completeWorkDateTimeParameter, completeWorkBackToServiceDateParameter, completeWorkBackToServiceTimeParameter, completeWorkDetailDescriptionParameter, completeWorkDetailPreventableParameter, completeWorkDetailTMLabourHoursParameter, completeWorkDetailTMCostParameter, completeWorkDetailTPVInvoiceNumberParameter, completeWorkDetailTPVInvoiceAmoutParameter, notesParameter, ruleIdParameter, deletedParameter, companyIdParameter, libraryCategoriesIdParameter); 

            return serviceId;
        }



        /// <summary>
        /// Update work (direct to DB)
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <param name="originalNumber">originalNumber</param>
        /// <param name="originalDateTime">originalDateTime</param>
        /// <param name="originalMtoDto">originalMtoDto</param>
        /// <param name="originalDescription">originalDescription</param>
        /// <param name="originalUnitId">originalUnitId</param>
        /// <param name="originalType">originalType</param>
        /// <param name="originalState">originalState</param>
        /// <param name="originalOwnerId">originalOwnerId</param>
        /// <param name="originalAssignDateTime">originalAssignDateTime</param>
        /// <param name="originalAssignDeadlineDate">originalAssignDeadlineDate</param>
        /// <param name="originalAssignTeamMember">originalAssignTeamMember</param>
        /// <param name="originalAssignTeamMemberID">originalAssignTeamMemberID</param>
        /// <param name="originalAssignThirdPartyVendor">originalAssignThirdPartyVendor</param>
        /// <param name="originalAcceptDateTime">originalAcceptDateTime</param>
        /// <param name="originalRejectDateTime">originalRejectDateTime</param>
        /// <param name="originalRejectReason">originalRejectReason</param>
        /// <param name="originalStartWorkDateTime">originalStartWorkDateTime</param>
        /// <param name="originalStartWorkOutOfServiceDate">originalStartWorkOutOfServiceDate</param>
        /// <param name="originalStartWorkOutOfServiceTime">originalStartWorkOutOfServiceTime</param>
        /// <param name="originalCompleteWorkDateTime">originalCompleteWorkDateTime</param>
        /// <param name="originalCompleteWorkBackToServiceDate">originalCompleteWorkBackToServiceDate</param>
        /// <param name="originalCompleteWorkBackToServiceTime">originalCompleteWorkBackToServiceTime</param>
        /// <param name="originalCompleteWorkDetailDescription">originalCompleteWorkDetailDescription</param>
        /// <param name="originalCompleteWorkDetailPreventable">originalCompleteWorkDetailPreventable</param>
        /// <param name="originalCompleteWorkDetailTMLabourHours">originalCompleteWorkDetailTMLabourHours</param>
        /// <param name="originalCompleteWorkDetailTMCost">originalCompleteWorkDetailTMCost</param>
        /// <param name="originalCompleteWorkDetailTPVInvoiceNumber">originalCompleteWorkDetailTPVInvoiceNumber</param>
        /// <param name="originalCompleteWorkDetailTPVInvoiceAmout">originalCompleteWorkDetailTPVInvoiceAmout</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalNotes">originalNotes</param>
        /// <param name="originalRuleID">originalRuleID</param>
        /// <param name="originalLibraryCategoriesId">originalLibraryCategoriesId</param>
        /// 
        /// <param name="newNumber">newNumber</param>
        /// <param name="newDateTime">newDateTime</param>
        /// <param name="newMtoDto">newMtoDto</param>
        /// <param name="newDescription">newDescription</param>
        /// <param name="newUnitId">newUnitId</param>
        /// <param name="newType">newType</param>
        /// <param name="newState">newState</param>
        /// <param name="newOwnerId">newOwnerId</param>
        /// <param name="newAssignDateTime">newAssignDateTime</param>
        /// <param name="newAssignDeadlineDate">newAssignDeadlineDate</param>
        /// <param name="newAssignTeamMember">newAssignTeamMember</param>
        /// <param name="newAssignTeamMemberID">newAssignTeamMemberID</param>
        /// <param name="newAssignThirdPartyVendor">newAssignThirdPartyVendor</param>
        /// <param name="newAcceptDateTime">newAcceptDateTime</param>
        /// <param name="newRejectDateTime">newRejectDateTime</param>
        /// <param name="newRejectReason">newRejectReason</param>
        /// <param name="newStartWorkDateTime">newStartWorkDateTime</param>
        /// <param name="newStartWorkOutOfServiceDate">newStartWorkOutOfServiceDate</param>
        /// <param name="newStartWorkOutOfServiceTime">newStartWorkOutOfServiceTime</param>
        /// <param name="newCompleteWorkDateTime">newCompleteWorkDateTime</param>
        /// <param name="newCompleteWorkBackToServiceDate">newCompleteWorkBackToServiceDate</param>
        /// <param name="newCompleteWorkBackToServiceTime">newCompleteWorkBackToServiceTime</param>
        /// <param name="newCompleteWorkDetailDescription">newCompleteWorkDetailDescription</param>
        /// <param name="newCompleteWorkDetailPreventable">newCompleteWorkDetailPreventable</param>
        /// <param name="newCompleteWorkDetailTMLabourHours">newCompleteWorkDetailTMLabourHours</param>
        /// <param name="newCompleteWorkDetailTMCost">newCompleteWorkDetailTMCost</param>
        /// <param name="newCompleteWorkDetailTPVInvoiceNumber">newCompleteWorkDetailTPVInvoiceNumber</param>
        /// <param name="newCompleteWorkDetailTPVInvoiceAmout">newCompleteWorkDetailTPVInvoiceAmout</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newNotes">newNotes</param>
        /// <param name="newRuleID">newRuleID</param>
        /// <param name="newLibraryCategoriesId">newLibraryCategoriesId</param>
        public int Update(int serviceId, string originalNumber, DateTime originalDateTime, bool originalMtoDto, string originalDescription, int? originalUnitId, string originalType, string originalState, int originalOwnerId, DateTime? originalAssignDateTime,  DateTime? originalAssignDeadlineDate, bool originalAssignTeamMember,  int? originalAssignTeamMemberID,  string originalAssignThirdPartyVendor, DateTime? originalAcceptDateTime, DateTime? originalRejectDateTime,  string originalRejectReason,  DateTime? originalStartWorkDateTime, DateTime? originalStartWorkOutOfServiceDate, string originalStartWorkOutOfServiceTime,  DateTime? originalCompleteWorkDateTime, DateTime? originalCompleteWorkBackToServiceDate, string originalCompleteWorkBackToServiceTime,  string originalCompleteWorkDetailDescription,  bool originalCompleteWorkDetailPreventable, decimal? originalCompleteWorkDetailTMLabourHours,  decimal? originalCompleteWorkDetailTMCost, string originalCompleteWorkDetailTPVInvoiceNumber,  decimal? originalCompleteWorkDetailTPVInvoiceAmout, bool originalDeleted, int originalCompanyId, string originalNotes, int? originalRuleID, int? originalLibraryCategoriesId, string newNumber, DateTime? newDateTime, bool newMtoDto,  string newDescription, int? newUnitId,  string newType, string newState,  int newOwnerId, DateTime? newAssignDateTime, DateTime? newAssignDeadlineDate,  bool newAssignTeamMember, int? newAssignTeamMemberID, string newAssignThirdPartyVendor,  DateTime? newAcceptDateTime,  DateTime? newRejectDateTime,  string newRejectReason,  DateTime? newStartWorkDateTime,  DateTime? newStartWorkOutOfServiceDate,  string newStartWorkOutOfServiceTime, DateTime? newCompleteWorkDateTime,  DateTime? newCompleteWorkBackToServiceDate,  string newCompleteWorkBackToServiceTime,  string newCompleteWorkDetailDescription, bool newCompleteWorkDetailPreventable, decimal? newCompleteWorkDetailTMLabourHours,  decimal? newCompleteWorkDetailTMCost, string newCompleteWorkDetailTPVInvoiceNumber, decimal? newCompleteWorkDetailTPVInvoiceAmout, bool newDeleted, int newCompanyId, string newNotes, int? newRuleID, int? newLibraryCategoriesId)
        {
            SqlParameter originalServiceIdParameter = new SqlParameter("Original_ServiceID", serviceId);
            SqlParameter originalNumberParameter = (originalNumber.Trim() != "") ? new SqlParameter("Original_Number", originalNumber.Trim()) : new SqlParameter("Original_Number", DBNull.Value);
            SqlParameter originalDateTimeParameter = new SqlParameter("Original_DateTime_", originalDateTime);
            SqlParameter originalMtoDtoParameter = new SqlParameter("Original_MTO", originalMtoDto);
            SqlParameter originalDescriptionParameter = (originalDescription.Trim() != "") ? new SqlParameter("Original_Description", originalDescription.Trim()) : new SqlParameter("Original_Description", DBNull.Value);
            SqlParameter originalUnitIdParameter = (originalUnitId.HasValue) ? new SqlParameter("Original_UnitID", originalUnitId) : new SqlParameter("Original_UnitID", DBNull.Value);
            SqlParameter originalTypeParameter = (originalType.Trim() != "") ? new SqlParameter("Original_Type", originalType.Trim()) : new SqlParameter("Original_Type", DBNull.Value);
            SqlParameter originalStateParameter = (originalState.Trim() != "") ? new SqlParameter("Original_State", originalState.Trim()) : new SqlParameter("Original_State", DBNull.Value);
            SqlParameter originalOwnerIdParameter = new SqlParameter("Original_OwnerID", originalOwnerId);
            SqlParameter originalAssignDateTimeParameter = (originalAssignDateTime.HasValue) ? new SqlParameter("Original_AssignDateTime", originalAssignDateTime) : new SqlParameter("Original_AssignDateTime", DBNull.Value);
            SqlParameter originalAssignDeadlineDateParameter = (originalAssignDeadlineDate.HasValue) ? new SqlParameter("Original_AssignDeadlineDate", originalAssignDeadlineDate) : new SqlParameter("Original_AssignDeadlineDate", DBNull.Value);
            SqlParameter originalAssignTeamMemberParameter = new SqlParameter("Original_AssignTeamMember", originalAssignTeamMember);           
            SqlParameter originalAssignTeamMemberIDParameter = (originalAssignTeamMemberID.HasValue) ? new SqlParameter("Original_AssignTeamMemberID", originalAssignTeamMemberID) : new SqlParameter("Original_AssignTeamMemberID", DBNull.Value);
            SqlParameter originalAssignThirdPartyVendorParameter = (originalAssignThirdPartyVendor.Trim() != "") ? new SqlParameter("Original_AssignThirdPartyVendor", originalAssignThirdPartyVendor.Trim()) : new SqlParameter("Original_AssignThirdPartyVendor", DBNull.Value);
            SqlParameter originalAcceptDateTimeParameter = (originalAcceptDateTime.HasValue) ? new SqlParameter("Original_AcceptDateTime", originalAcceptDateTime) : new SqlParameter("Original_AcceptDateTime", DBNull.Value);
            SqlParameter originalRejectDateTimeParameter = (originalRejectDateTime.HasValue) ? new SqlParameter("Original_RejectDateTime", originalRejectDateTime) : new SqlParameter("Original_RejectDateTime", DBNull.Value);           
            SqlParameter originalRejectReasonParameter = (originalRejectReason.Trim() != "") ? new SqlParameter("Original_RejectReason", originalRejectReason.Trim()) : new SqlParameter("Original_RejectReason", DBNull.Value);
            SqlParameter originalStartWorkDateTimeParameter = (originalStartWorkDateTime.HasValue) ? new SqlParameter("Original_StartWorkDateTime", originalStartWorkDateTime) : new SqlParameter("Original_StartWorkDateTime", DBNull.Value);
            SqlParameter originalStartWorkOutOfServiceDateParameter = (originalStartWorkOutOfServiceDate.HasValue) ? new SqlParameter("Original_StartWorkOutOfServiceDate", originalStartWorkOutOfServiceDate) : new SqlParameter("Original_StartWorkOutOfServiceDate", DBNull.Value);
            SqlParameter originalStartWorkOutOfServiceTimeParameter = (originalStartWorkOutOfServiceTime.Trim() != "") ? new SqlParameter("Original_StartWorkOutOfServiceTime", originalStartWorkOutOfServiceTime.Trim()) : new SqlParameter("Original_StartWorkOutOfServiceTime", DBNull.Value);           
            SqlParameter originalCompleteWorkDateTimeParameter = (originalCompleteWorkDateTime.HasValue) ? new SqlParameter("Original_CompleteWorkDateTime", originalCompleteWorkDateTime) : new SqlParameter("Original_CompleteWorkDateTime", DBNull.Value);
            SqlParameter originalCompleteWorkBackToServiceDateParameter = (originalCompleteWorkBackToServiceDate.HasValue) ? new SqlParameter("Original_CompleteWorkBackToServiceDate", originalCompleteWorkBackToServiceDate) : new SqlParameter("Original_CompleteWorkBackToServiceDate", DBNull.Value);
            SqlParameter originalCompleteWorkBackToServiceTimeParameter = (originalCompleteWorkBackToServiceTime.Trim() != "") ? new SqlParameter("Original_CompleteWorkBackToServiceTime", originalCompleteWorkBackToServiceTime.Trim()) : new SqlParameter("Original_CompleteWorkBackToServiceTime", DBNull.Value);          
            SqlParameter originalCompleteWorkDetailDescriptionParameter = (originalCompleteWorkDetailDescription.Trim() != "") ? new SqlParameter("Original_CompleteWorkDetailDescription", originalCompleteWorkDetailDescription.Trim()) : new SqlParameter("Original_CompleteWorkDetailDescription", DBNull.Value);
            SqlParameter originalCompleteWorkDetailPreventableParameter = new SqlParameter("Original_CompleteWorkDetailPreventable", originalCompleteWorkDetailPreventable);
            SqlParameter originalCompleteWorkDetailTMLabourHoursParameter = (originalCompleteWorkDetailTMLabourHours.HasValue) ? new SqlParameter("Original_CompleteWorkDetailTMLabourHours", originalCompleteWorkDetailTMLabourHours) : new SqlParameter("Original_CompleteWorkDetailTMLabourHours", DBNull.Value);
            SqlParameter originalCompleteWorkDetailTMCostParameter = (originalCompleteWorkDetailTMCost.HasValue) ? new SqlParameter("Original_CompleteWorkDetailTMCost", originalCompleteWorkDetailTMCost) : new SqlParameter("Original_CompleteWorkDetailTMCost", DBNull.Value);
            originalCompleteWorkDetailTMCostParameter.SqlDbType = SqlDbType.Money;           
            SqlParameter originalCompleteWorkDetailTPVInvoiceNumberParameter = (originalCompleteWorkDetailTPVInvoiceNumber.Trim() != "") ? new SqlParameter("Original_CompleteWorkDetailTPVInvoiceNumber", originalCompleteWorkDetailTPVInvoiceNumber.Trim()) : new SqlParameter("Original_CompleteWorkDetailTPVInvoiceNumber", DBNull.Value);
            SqlParameter originalCompleteWorkDetailTPVInvoiceAmoutParameter = (originalCompleteWorkDetailTPVInvoiceAmout.HasValue) ? new SqlParameter("Original_CompleteWorkDetailTPVInvoiceAmout", originalCompleteWorkDetailTPVInvoiceAmout) : new SqlParameter("Original_CompleteWorkDetailTPVInvoiceAmout", DBNull.Value);
            originalCompleteWorkDetailTPVInvoiceAmoutParameter.SqlDbType = SqlDbType.Money;           
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter originalNotesParameter = (originalNotes.Trim() != "") ? new SqlParameter("Original_Notes", originalNotes.Trim()) : new SqlParameter("Original_Notes", DBNull.Value);
            SqlParameter originalRuleIDParameter = (originalRuleID.HasValue) ? new SqlParameter("Original_RuleID", originalRuleID) : new SqlParameter("Original_RuleID", DBNull.Value);
            SqlParameter originalLibraryCategoriesIdParameter = (originalLibraryCategoriesId.HasValue) ? new SqlParameter("Original_LIBRARY_CATEGORIES_ID", originalLibraryCategoriesId) : new SqlParameter("Original_LIBRARY_CATEGORIES_ID", DBNull.Value);
            
            SqlParameter newServiceIdParameter = new SqlParameter("ServiceID", serviceId);
            SqlParameter newNumberParameter = (newNumber.Trim() != "") ? new SqlParameter("Number", newNumber.Trim()) : new SqlParameter("Number", DBNull.Value);
            SqlParameter newDateTimeParameter = new SqlParameter("DateTime_", newDateTime);
            SqlParameter newMtoDtoParameter = new SqlParameter("MTO", newMtoDto);
            SqlParameter newDescriptionParameter = (newDescription.Trim() != "") ? new SqlParameter("Description", newDescription.Trim()) : new SqlParameter("Description", DBNull.Value);
            SqlParameter newUnitIdParameter = (newUnitId.HasValue) ? new SqlParameter("UnitID", newUnitId) : new SqlParameter("UnitID", DBNull.Value);
            SqlParameter newTypeParameter = (newType.Trim() != "") ? new SqlParameter("Type", newType.Trim()) : new SqlParameter("Type", DBNull.Value);
            SqlParameter newStateParameter = (newState.Trim() != "") ? new SqlParameter("State", newState.Trim()) : new SqlParameter("State", DBNull.Value);
            SqlParameter newOwnerIdParameter = new SqlParameter("OwnerID", newOwnerId);
            SqlParameter newAssignDateTimeParameter = (newAssignDateTime.HasValue) ? new SqlParameter("AssignDateTime", newAssignDateTime) : new SqlParameter("AssignDateTime", DBNull.Value);
            SqlParameter newAssignDeadlineDateParameter = (newAssignDeadlineDate.HasValue) ? new SqlParameter("AssignDeadlineDate", newAssignDeadlineDate) : new SqlParameter("AssignDeadlineDate", DBNull.Value);
            SqlParameter newAssignTeamMemberParameter = new SqlParameter("AssignTeamMember", newAssignTeamMember);
            SqlParameter newAssignTeamMemberIDParameter = (newAssignTeamMemberID.HasValue) ? new SqlParameter("AssignTeamMemberID", newAssignTeamMemberID) : new SqlParameter("AssignTeamMemberID", DBNull.Value);
            SqlParameter newAssignThirdPartyVendorParameter = (newAssignThirdPartyVendor.Trim() != "") ? new SqlParameter("AssignThirdPartyVendor", newAssignThirdPartyVendor.Trim()) : new SqlParameter("AssignThirdPartyVendor", DBNull.Value);
            SqlParameter newAcceptDateTimeParameter = (newAcceptDateTime.HasValue) ? new SqlParameter("AcceptDateTime", newAcceptDateTime) : new SqlParameter("AcceptDateTime", DBNull.Value);
            SqlParameter newRejectDateTimeParameter = (newRejectDateTime.HasValue) ? new SqlParameter("RejectDateTime", newRejectDateTime) : new SqlParameter("RejectDateTime", DBNull.Value);
            SqlParameter newRejectReasonParameter = (newRejectReason.Trim() != "") ? new SqlParameter("RejectReason", newRejectReason.Trim()) : new SqlParameter("RejectReason", DBNull.Value);         
            SqlParameter newStartWorkDateTimeParameter = (newStartWorkDateTime.HasValue) ? new SqlParameter("StartWorkDateTime", newStartWorkDateTime) : new SqlParameter("StartWorkDateTime", DBNull.Value);
            SqlParameter newStartWorkOutOfServiceDateParameter = (newStartWorkOutOfServiceDate.HasValue) ? new SqlParameter("StartWorkOutOfServiceDate", newStartWorkOutOfServiceDate) : new SqlParameter("StartWorkOutOfServiceDate", DBNull.Value);
            SqlParameter newStartWorkOutOfServiceTimeParameter = (newStartWorkOutOfServiceTime.Trim() != "") ? new SqlParameter("StartWorkOutOfServiceTime", newStartWorkOutOfServiceTime.Trim()) : new SqlParameter("StartWorkOutOfServiceTime", DBNull.Value);
            SqlParameter newCompleteWorkDateTimeParameter = (newCompleteWorkDateTime.HasValue) ? new SqlParameter("CompleteWorkDateTime", newCompleteWorkDateTime) : new SqlParameter("CompleteWorkDateTime", DBNull.Value);
            SqlParameter newCompleteWorkBackToServiceDateParameter = (newCompleteWorkBackToServiceDate.HasValue) ? new SqlParameter("CompleteWorkBackToServiceDate", newCompleteWorkBackToServiceDate) : new SqlParameter("CompleteWorkBackToServiceDate", DBNull.Value);
            SqlParameter newCompleteWorkBackToServiceTimeParameter = (newCompleteWorkBackToServiceTime.Trim() != "") ? new SqlParameter("CompleteWorkBackToServiceTime", newCompleteWorkBackToServiceTime.Trim()) : new SqlParameter("CompleteWorkBackToServiceTime", DBNull.Value);
            SqlParameter newCompleteWorkDetailDescriptionParameter = (newCompleteWorkDetailDescription.Trim() != "") ? new SqlParameter("CompleteWorkDetailDescription", newCompleteWorkDetailDescription.Trim()) : new SqlParameter("CompleteWorkDetailDescription", DBNull.Value);
            SqlParameter newCompleteWorkDetailPreventableParameter = new SqlParameter("CompleteWorkDetailPreventable", newCompleteWorkDetailPreventable);           
            SqlParameter newCompleteWorkDetailTMLabourHoursParameter = (newCompleteWorkDetailTMLabourHours.HasValue) ? new SqlParameter("CompleteWorkDetailTMLabourHours", newCompleteWorkDetailTMLabourHours) : new SqlParameter("CompleteWorkDetailTMLabourHours", DBNull.Value);
            SqlParameter newCompleteWorkDetailTMCostParameter = (newCompleteWorkDetailTMCost.HasValue) ? new SqlParameter("CompleteWorkDetailTMCost", newCompleteWorkDetailTMCost) : new SqlParameter("CompleteWorkDetailTMCost", DBNull.Value);
            newCompleteWorkDetailTMCostParameter.SqlDbType = SqlDbType.Money;           
            SqlParameter newCompleteWorkDetailTPVInvoiceNumberParameter = (newCompleteWorkDetailTPVInvoiceNumber.Trim() != "") ? new SqlParameter("CompleteWorkDetailTPVInvoiceNumber", newCompleteWorkDetailTPVInvoiceNumber.Trim()) : new SqlParameter("CompleteWorkDetailTPVInvoiceNumber", DBNull.Value);          
            SqlParameter newCompleteWorkDetailTPVInvoiceAmoutParameter = (newCompleteWorkDetailTPVInvoiceAmout.HasValue) ? new SqlParameter("CompleteWorkDetailTPVInvoiceAmout", newCompleteWorkDetailTPVInvoiceAmout) : new SqlParameter("CompleteWorkDetailTPVInvoiceAmout", DBNull.Value);
            newCompleteWorkDetailTPVInvoiceAmoutParameter.SqlDbType = SqlDbType.Money;
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);
            SqlParameter newNotesParameter = (newNotes.Trim() != "") ? new SqlParameter("Notes", newNotes.Trim()) : new SqlParameter("Notes", DBNull.Value);
            SqlParameter newRuleIDParameter = (newRuleID.HasValue) ? new SqlParameter("RuleID", newRuleID) : new SqlParameter("RuleID", DBNull.Value);
            SqlParameter newLibraryCategoriesIdParameter = (newLibraryCategoriesId.HasValue) ? new SqlParameter("LIBRARY_CATEGORIES_ID", newLibraryCategoriesId) : new SqlParameter("LIBRARY_CATEGORIES_ID", DBNull.Value);

            string command = "UPDATE [dbo].[LFS_FM_SERVICE] SET [Number] = @Number,  "+
                " [DateTime_] = @DateTime_, [MTO] = @MTO, [Description] = @Description," +
                " [UnitID] = @UnitID, [Type] = @Type, [State] = @State, [OwnerID] = @OwnerID," +
                " [AssignDateTime] = @AssignDateTime, [AssignDeadlineDate] = @AssignDeadlineDate, " +
                " [AssignTeamMember] = @AssignTeamMember, [AssignTeamMemberID] = @AssignTeamMemberID," +
                " [AssignThirdPartyVendor] = @AssignThirdPartyVendor, [AcceptDateTime] = @AcceptDateTime," +
                " [RejectDateTime] = @RejectDateTime, [RejectReason] = @RejectReason," +
                " [StartWorkDateTime] = @StartWorkDateTime," +
                " [StartWorkOutOfServiceDate] = @StartWorkOutOfServiceDate, " +
                " [StartWorkOutOfServiceTime] = @StartWorkOutOfServiceTime, "+
                " [CompleteWorkDateTime] = @CompleteWorkDateTime, " +
                " [CompleteWorkBackToServiceDate] = @CompleteWorkBackToServiceDate, " +
                " [CompleteWorkBackToServiceTime] = @CompleteWorkBackToServiceTime,  "+
                " [CompleteWorkDetailDescription] = @CompleteWorkDetailDescription," +
                " [CompleteWorkDetailPreventable] = @CompleteWorkDetailPreventable," +
                " [CompleteWorkDetailTMLabourHours] = @CompleteWorkDetailTMLabourHours," +
                " [CompleteWorkDetailTMCost] = @CompleteWorkDetailTMCost, " +
                " [CompleteWorkDetailTPVInvoiceNumber] = @CompleteWorkDetailTPVInvoiceNumber, "+
                " [CompleteWorkDetailTPVInvoiceAmout] = @CompleteWorkDetailTPVInvoiceAmout," +
                " [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID," +
                " [Notes] = @Notes, [RuleID] = @RuleID, [LIBRARY_CATEGORIES_ID] = @LIBRARY_CATEGORIES_ID " +
                "WHERE (" +
                "([ServiceID] = @Original_ServiceID) AND ([Deleted] = @Original_Deleted) AND "+
                " ([COMPANY_ID] = @Original_COMPANY_ID)" +
                " )";

            int rowsAffected = (int)ExecuteNonQuery(command, originalServiceIdParameter, originalNumberParameter, originalDateTimeParameter, originalMtoDtoParameter, originalDescriptionParameter, originalUnitIdParameter, originalTypeParameter, originalStateParameter, originalOwnerIdParameter, originalAssignDateTimeParameter, originalAssignDeadlineDateParameter, originalAssignTeamMemberParameter, originalAssignTeamMemberIDParameter, originalAssignThirdPartyVendorParameter, originalAcceptDateTimeParameter, originalRejectDateTimeParameter, originalRejectReasonParameter, originalStartWorkDateTimeParameter, originalStartWorkOutOfServiceDateParameter, originalStartWorkOutOfServiceTimeParameter, originalCompleteWorkDateTimeParameter, originalCompleteWorkBackToServiceDateParameter, originalCompleteWorkBackToServiceTimeParameter, originalCompleteWorkDetailDescriptionParameter, originalCompleteWorkDetailPreventableParameter, originalCompleteWorkDetailTMLabourHoursParameter, originalCompleteWorkDetailTMCostParameter, originalCompleteWorkDetailTPVInvoiceNumberParameter, originalCompleteWorkDetailTPVInvoiceAmoutParameter, originalDeletedParameter, originalCompanyIdParameter, originalNotesParameter, originalRuleIDParameter, originalLibraryCategoriesIdParameter, newServiceIdParameter, newNumberParameter, newDateTimeParameter, newMtoDtoParameter, newDescriptionParameter, newUnitIdParameter, newTypeParameter, newStateParameter, newOwnerIdParameter, newAssignDateTimeParameter, newAssignDeadlineDateParameter, newAssignTeamMemberParameter, newAssignTeamMemberIDParameter, newAssignThirdPartyVendorParameter, newAcceptDateTimeParameter, newRejectDateTimeParameter, newRejectReasonParameter, newStartWorkDateTimeParameter, newStartWorkOutOfServiceDateParameter, newStartWorkOutOfServiceTimeParameter, newCompleteWorkDateTimeParameter, newCompleteWorkBackToServiceDateParameter, newCompleteWorkBackToServiceTimeParameter, newCompleteWorkDetailDescriptionParameter, newCompleteWorkDetailPreventableParameter, newCompleteWorkDetailTMLabourHoursParameter, newCompleteWorkDetailTMCostParameter, newCompleteWorkDetailTPVInvoiceNumberParameter, newCompleteWorkDetailTPVInvoiceAmoutParameter, newDeletedParameter, newCompanyIdParameter, newNotesParameter, newRuleIDParameter, newLibraryCategoriesIdParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }


        
        /// <summary>
        /// Delete service request (direct to DB)
        /// </summary>
        /// <param name="originalServiceId">originalServiceId</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <returns>int</returns>
        public int Delete(int originalServiceId, int originalCompanyId)
        {
            SqlParameter originalServiceIdParameter = new SqlParameter("@Original_ServiceID", originalServiceId);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_FM_SERVICE] SET  [Deleted] = @Deleted  " +
                             " WHERE (([ServiceID] = @Original_ServiceID) AND " +
                             "  ([COMPANY_ID] = @Original_COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery( command, originalServiceIdParameter, originalCompanyIdParameter, deletedParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }



    }
}