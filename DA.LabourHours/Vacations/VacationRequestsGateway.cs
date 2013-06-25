using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.LabourHours.Vacations
{
    /// <summary>
    /// VacationRequestsGateway
    /// </summary>
    public class VacationRequestsGateway : DataTableGateway
    {
        ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public VacationRequestsGateway()
            : base("LFS_VACATION_REQUESTS")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public VacationRequestsGateway(DataSet data)
            : base(data, "LFS_VACATION_REQUESTS")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new VacationsTDS();
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
            tableMapping.DataSetTable = "LFS_VACATION_REQUESTS";
            tableMapping.ColumnMappings.Add("RequestID", "RequestID");
            tableMapping.ColumnMappings.Add("EmployeeID", "EmployeeID");
            tableMapping.ColumnMappings.Add("StartDate", "StartDate");
            tableMapping.ColumnMappings.Add("EndDate", "EndDate");
            tableMapping.ColumnMappings.Add("TotalPaidVacationDays", "TotalPaidVacationDays");
            tableMapping.ColumnMappings.Add("State", "State");
            tableMapping.ColumnMappings.Add("Comments", "Comments");
            tableMapping.ColumnMappings.Add("Details", "Details");
            tableMapping.ColumnMappings.Add("RejectReason", "RejectReason");
            tableMapping.ColumnMappings.Add("CancelReason", "CancelReason");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = @"DELETE FROM [dbo].[LFS_VACATION_REQUESTS] WHERE (([RequestID] = @Original_RequestID) AND ([EmployeeID] = @Original_EmployeeID) AND ([StartDate] = @Original_StartDate) AND ([EndDate] = @Original_EndDate) AND ([TotalPaidVacationDays] = @Original_TotalPaidVacationDays) AND ([State] = @Original_State) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RequestID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RequestID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_EmployeeID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EmployeeID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_StartDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StartDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_EndDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EndDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TotalPaidVacationDays", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalPaidVacationDays", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_State", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "State", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_VACATION_REQUESTS] ([EmployeeID], [StartDate], [EndDate], [TotalPaidVacationDays], [State], [Comments], [Details], [RejectReason], [CancelReason], [Deleted], [COMPANY_ID]) VALUES (@EmployeeID, @StartDate, @EndDate, @TotalPaidVacationDays, @State, @Comments, @Details, @RejectReason, @CancelReason, @Deleted, @COMPANY_ID);
SELECT RequestID, EmployeeID, StartDate, EndDate, TotalPaidVacationDays, State, Comments, Details, RejectReason, CancelReason, Deleted, COMPANY_ID FROM LFS_VACATION_REQUESTS WHERE (RequestID = SCOPE_IDENTITY())";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@EmployeeID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EmployeeID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@StartDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StartDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@EndDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EndDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TotalPaidVacationDays", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalPaidVacationDays", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@State", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "State", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Comments", global::System.Data.SqlDbType.Text, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Comments", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Details", global::System.Data.SqlDbType.Text, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Details", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RejectReason", global::System.Data.SqlDbType.Text, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RejectReason", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CancelReason", global::System.Data.SqlDbType.Text, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CancelReason", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));

            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = @"UPDATE [dbo].[LFS_VACATION_REQUESTS] SET [EmployeeID] = @EmployeeID, [StartDate] = @StartDate, [EndDate] = @EndDate, [TotalPaidVacationDays] = @TotalPaidVacationDays, [State] = @State, [Comments] = @Comments, [Details] = @Details, [RejectReason] = @RejectReason, [CancelReason] = @CancelReason, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID WHERE (([RequestID] = @Original_RequestID) AND ([EmployeeID] = @Original_EmployeeID) AND ([StartDate] = @Original_StartDate) AND ([EndDate] = @Original_EndDate) AND ([TotalPaidVacationDays] = @Original_TotalPaidVacationDays) AND ([State] = @Original_State) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID));
SELECT RequestID, EmployeeID, StartDate, EndDate, TotalPaidVacationDays, State, Comments, Details, RejectReason, CancelReason, Deleted, COMPANY_ID FROM LFS_VACATION_REQUESTS WHERE (RequestID = @RequestID)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@EmployeeID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EmployeeID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@StartDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StartDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@EndDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EndDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TotalPaidVacationDays", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalPaidVacationDays", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@State", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "State", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Comments", global::System.Data.SqlDbType.Text, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Comments", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Details", global::System.Data.SqlDbType.Text, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Details", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RejectReason", global::System.Data.SqlDbType.Text, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RejectReason", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CancelReason", global::System.Data.SqlDbType.Text, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CancelReason", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RequestID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RequestID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_EmployeeID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EmployeeID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_StartDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StartDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_EndDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EndDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TotalPaidVacationDays", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalPaidVacationDays", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_State", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "State", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RequestID", global::System.Data.SqlDbType.Int, 4, global::System.Data.ParameterDirection.Input, 0, 0, "RequestID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));

            #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROWS
        //

        /// <summary>
        /// Insert vacation request (direct to DB)
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="totalPaidVacationDays">totalPaidVacationDays</param>
        /// <param name="state">state</param>
        /// <param name="comments">comments</param>
        /// <param name="details">details</param>
        /// <param name="rejectReason">rejectReason</param>
        /// <param name="cancelReason">cancelReason</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <returns></returns>
        public int Insert(int employeeId, DateTime startDate, DateTime endDate, double totalPaidVacationDays, string state, string comments, string details, string rejectReason, string cancelReason, bool deleted, int companyId)
        {
            SqlParameter employeeIdParameter = new SqlParameter("EmployeeID", employeeId);
            SqlParameter startDateParameter = new SqlParameter("StartDate", startDate);
            SqlParameter endDateParameter = new SqlParameter("EndDate", endDate);
            SqlParameter totalPaidVacationDaysParameter = new SqlParameter("TotalPaidVacationDays", totalPaidVacationDays);
            SqlParameter stateParameter = new SqlParameter("State", state);
            SqlParameter commentsParameter = new SqlParameter("Comments", comments);
            SqlParameter detailsParameter = (details != "") ? new SqlParameter("Details", details) : new SqlParameter("Details", DBNull.Value);
            SqlParameter rejectReasonParameter = (rejectReason != "") ? new SqlParameter("RejectReason", rejectReason) : new SqlParameter("RejectReason", DBNull.Value);
            SqlParameter cancelReasonParameter = (cancelReason != "") ? new SqlParameter("CancelReason", cancelReason) : new SqlParameter("CancelReason", DBNull.Value);
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);

            string command = "INSERT INTO [dbo].[LFS_VACATION_REQUESTS] ([EmployeeID], [StartDate], [EndDate], [TotalPaidVacationDays], [State], [Comments], [Details], [RejectReason], [CancelReason], [Deleted], [COMPANY_ID]) " +
                            " VALUES (@EmployeeID, @StartDate, @EndDate, @TotalPaidVacationDays, @State, @Comments, @Details, @RejectReason, @CancelReason, @Deleted, @COMPANY_ID); " +
                             " SELECT RequestID, EmployeeID, StartDate, EndDate, TotalPaidVacationDays, State, Comments, Details, RejectReason, CancelReason, Deleted, COMPANY_ID FROM LFS_VACATION_REQUESTS WHERE (RequestID = SCOPE_IDENTITY())";

            int requestId = (int)ExecuteScalar(command, employeeIdParameter, startDateParameter, endDateParameter, totalPaidVacationDaysParameter, stateParameter, commentsParameter, detailsParameter, rejectReasonParameter, cancelReasonParameter, deletedParameter, companyIdParameter);

            return requestId;
        }



        /// <summary>
        /// Update vacation request (direct to DB)
        /// </summary>
        /// <param name="originalRequestId">originalRequestId</param>
        /// <param name="originalEmployeeId">originalEmployeeId</param>
        /// <param name="originalStartDate">originalStartDate</param>
        /// <param name="originalEndDate">originalEndDate</param>
        /// <param name="originalTotalPaidVacationDays">originalTotalPaidVacationDays</param>
        /// <param name="originalState">originalState</param>
        /// <param name="originalComments">originalComments</param>
        /// <param name="originalDetails">originalDetails</param>
        /// <param name="originalRejectReason">originalRejectReason</param>
        /// <param name="originalCancelReason">originalCancelReason</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// 
        /// <param name="newRequestId">newRequestId</param>
        /// <param name="newEmployeeId">newEmployeeId</param>
        /// <param name="newStartDate">newStartDate</param>
        /// <param name="newEndDate">newEndDate</param>
        /// <param name="newTotalPaidVacationDays">newTotalPaidVacationDays</param>
        /// <param name="newState">newState</param>
        /// <param name="newComments">newComments</param>
        /// <param name="newDetails">newDetails</param>
        /// <param name="newRejectReason">newRejectReason</param>
        /// <param name="newCancelReason">newCancelReason</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <returns></returns>
        public int Update(int originalRequestId, int originalEmployeeId, DateTime originalStartDate, DateTime originalEndDate, double originalTotalPaidVacationDays, string originalState, string originalComments, string originalDetails, string originalRejectReason, string originalCancelReason, bool originalDeleted, int originalCompanyId, int newRequestId, int newEmployeeId, DateTime newStartDate, DateTime newEndDate, double newTotalPaidVacationDays, string newState, string newComments, string newDetails, string newRejectReason, string newCancelReason, bool newDeleted, int newCompanyId)
        {
            SqlParameter originalRequestIdParameter = new SqlParameter("Original_RequestID", originalRequestId);
            SqlParameter originalEmployeeIdParameter = new SqlParameter("Original_EmployeeID", originalEmployeeId);
            SqlParameter originalStartDateParameter = new SqlParameter("Original_StartDate", originalStartDate);
            SqlParameter originalEndDateParameter = new SqlParameter("Original_EndDate", originalEndDate);
            SqlParameter originalTotalPaidVacationDaysParameter = new SqlParameter("Original_TotalPaidVacationDays", originalTotalPaidVacationDays);
            SqlParameter originalStateParameter = new SqlParameter("Original_State", originalState);
            SqlParameter originalCommentsParameter = new SqlParameter("Original_Comments", originalComments);
            SqlParameter originalDetailsParameter = (originalDetails != "") ? new SqlParameter("Original_Details", originalDetails) : new SqlParameter("Original_Details", DBNull.Value);
            SqlParameter originalRejectReasonParameter = (originalRejectReason != "") ? new SqlParameter("Original_RejectReason", originalRejectReason) : new SqlParameter("Original_RejectReason", DBNull.Value);
            SqlParameter originalCancelReasonParameter = (originalCancelReason != "") ? new SqlParameter("Original_CancelReason", originalCancelReason) : new SqlParameter("Original_CancelReason", DBNull.Value);
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);

            SqlParameter newRequestIdParameter = new SqlParameter("RequestID", newRequestId);
            SqlParameter newEmployeeIdParameter = new SqlParameter("EmployeeID", newEmployeeId);
            SqlParameter newStartDateParameter = new SqlParameter("StartDate", newStartDate);
            SqlParameter newEndDateParameter = new SqlParameter("EndDate", newEndDate);
            SqlParameter newTotalPaidVacationDaysParameter = new SqlParameter("TotalPaidVacationDays", newTotalPaidVacationDays);
            SqlParameter newStateParameter = new SqlParameter("State", newState);
            SqlParameter newCommentsParameter = new SqlParameter("Comments", newComments);
            SqlParameter newDetailsParameter = (newDetails != "") ? new SqlParameter("Details", newDetails) : new SqlParameter("Details", DBNull.Value);
            SqlParameter newRejectReasonParameter = (newRejectReason != "") ? new SqlParameter("RejectReason", newRejectReason) : new SqlParameter("RejectReason", DBNull.Value);
            SqlParameter newCancelReasonParameter = (newCancelReason != "") ? new SqlParameter("CancelReason", newCancelReason) : new SqlParameter("CancelReason", DBNull.Value);
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);

            string command = "UPDATE [dbo].[LFS_VACATION_REQUESTS] SET [EmployeeID] = @EmployeeID, [StartDate] = @StartDate, [EndDate] = @EndDate, [TotalPaidVacationDays] = @TotalPaidVacationDays, "+
                             "[State] = @State, [Comments] = @Comments, [Details] = @Details, [RejectReason] = @RejectReason, [CancelReason] = @CancelReason, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID " +
                             "WHERE ([RequestID] = @Original_RequestID)";

            int rowsAffected = (int)ExecuteNonQuery(command, originalRequestIdParameter, originalEmployeeIdParameter, originalStartDateParameter, originalEndDateParameter, originalTotalPaidVacationDaysParameter, originalStateParameter, originalCommentsParameter, originalDetailsParameter, originalRejectReasonParameter, originalCancelReasonParameter, originalDeletedParameter, originalCompanyIdParameter, newRequestIdParameter, newEmployeeIdParameter, newStartDateParameter, newEndDateParameter, newTotalPaidVacationDaysParameter, newStateParameter, newCommentsParameter, newDetailsParameter, newRejectReasonParameter, newCancelReasonParameter, newDeletedParameter, newCompanyIdParameter);
            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }



    }
}