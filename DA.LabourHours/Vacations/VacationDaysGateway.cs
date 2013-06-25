using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.LabourHours.Vacations
{
    /// <summary>
    /// VacationDaysGateway
    /// </summary>
    public class VacationDaysGateway : DataTableGateway
    {
        ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public VacationDaysGateway()
            : base("LFS_VACATION_DAYS")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public VacationDaysGateway(DataSet data)
            : base(data, "LFS_VACATION_DAYS")
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
            tableMapping.DataSetTable = "LFS_VACATION_DAYS";
            tableMapping.ColumnMappings.Add("VacationID", "VacationID");
            tableMapping.ColumnMappings.Add("RequestID", "RequestID");
            tableMapping.ColumnMappings.Add("StartDate", "StartDate");
            tableMapping.ColumnMappings.Add("EndDate", "EndDate");
            tableMapping.ColumnMappings.Add("Description", "Description");
            tableMapping.ColumnMappings.Add("PaymentType", "PaymentType");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");         
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = @"DELETE FROM [dbo].[LFS_VACATION_DAYS] WHERE (([VacationID] = @Original_VacationID) AND ([RequestID] = @Original_RequestID) AND ([StartDate] = @Original_StartDate) AND ([EndDate] = @Original_EndDate) AND ([Description] = @Original_Description) AND ([PaymentType] = @Original_PaymentType) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_VacationID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VacationID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RequestID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RequestID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_StartDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StartDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_EndDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EndDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Description", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Description", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_PaymentType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PaymentType", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_VACATION_DAYS] ([RequestID], [StartDate], [EndDate], [Description], [PaymentType], [Deleted], [COMPANY_ID]) VALUES (@RequestID, @StartDate, @EndDate, @Description, @PaymentType, @Deleted, @COMPANY_ID);
SELECT VacationID, RequestID, StartDate, EndDate, Description, PaymentType, Deleted, COMPANY_ID FROM LFS_VACATION_DAYS WHERE (VacationID = SCOPE_IDENTITY())";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RequestID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RequestID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@StartDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StartDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@EndDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EndDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Description", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Description", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PaymentType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PaymentType", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));

            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = @"UPDATE [dbo].[LFS_VACATION_DAYS] SET [RequestID] = @RequestID, [StartDate] = @StartDate, [EndDate] = @EndDate, [Description] = @Description, [PaymentType] = @PaymentType, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID WHERE (([VacationID] = @Original_VacationID) AND ([RequestID] = @Original_RequestID) AND ([StartDate] = @Original_StartDate) AND ([EndDate] = @Original_EndDate) AND ([Description] = @Original_Description) AND ([PaymentType] = @Original_PaymentType) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID));
SELECT VacationID, RequestID, StartDate, EndDate, Description, PaymentType, Deleted, COMPANY_ID FROM LFS_VACATION_DAYS WHERE (VacationID = @VacationID)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RequestID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RequestID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@StartDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StartDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@EndDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EndDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Description", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Description", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PaymentType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PaymentType", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_VacationID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VacationID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RequestID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RequestID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_StartDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StartDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_EndDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EndDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Description", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Description", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_PaymentType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PaymentType", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@VacationID", global::System.Data.SqlDbType.Int, 4, global::System.Data.ParameterDirection.Input, 0, 0, "VacationID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));

            #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROWS
        //

        /// <summary>
        /// Insert Vacation Day (direct to DB)
        /// </summary>
        /// <param name="date">date</param>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <param name="description">description</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public int Insert(int requestId, DateTime startDate, DateTime endDate, string description, string paymentType, bool deleted, int companyId)
        {
            SqlParameter requestIdParameter = new SqlParameter("RequestID", requestId);
            SqlParameter startDateParameter = new SqlParameter("StartDate", startDate);
            SqlParameter endDateParameter = new SqlParameter("EndDate", endDate);
            SqlParameter descriptionParameter = new SqlParameter("Description", description);
            SqlParameter paymentTypeParameter = new SqlParameter("PaymentType", paymentType);
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);

            string command = "INSERT INTO [dbo].[LFS_VACATION_DAYS] ([RequestID], [StartDate], [EndDate], [Description], [PaymentType], [Deleted], [COMPANY_ID]) VALUES (@RequestID, @StartDate, @EndDate, @Description, @PaymentType, @Deleted, @COMPANY_ID); " +
                             " SELECT VacationID, RequestID, StartDate, EndDate, Description, PaymentType, Deleted, COMPANY_ID FROM LFS_VACATION_DAYS WHERE (VacationID = SCOPE_IDENTITY())";

            int vacationId = (int)ExecuteScalar(command, requestIdParameter, startDateParameter, endDateParameter, descriptionParameter, paymentTypeParameter, deletedParameter, companyIdParameter);

            return vacationId;
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="originalVacationId"></param>
        /// <param name="originalRequestId"></param>
        /// <param name="originalStartDate"></param>
        /// <param name="originalEndDate"></param>
        /// <param name="originalDescription"></param>
        /// <param name="originalPaymentType"></param>
        /// <param name="originalDeleted"></param>
        /// <param name="originalCompanyId"></param>
        /// 
        /// <param name="newVacationId"></param>
        /// <param name="newRequestId"></param>
        /// <param name="newStartDate"></param>
        /// <param name="newEndDate"></param>
        /// <param name="newDescription"></param>
        /// <param name="newPaymentType"></param>
        /// <param name="newDeleted"></param>
        /// <param name="newCompanyId"></param>
        public void Update(int originalVacationId, int originalRequestId, DateTime originalStartDate, DateTime originalEndDate, string originalDescription, string originalPaymentType, bool originalDeleted, int originalCompanyId, int newVacationId, int newRequestId, DateTime newStartDate, DateTime newEndDate, string newDescription, string newPaymentType, bool newDeleted, int newCompanyId)
        {
            SqlParameter originalVacationIdParameter = new SqlParameter("Original_VacationID", originalVacationId);
            SqlParameter originalRequestIdParameter = new SqlParameter("Original_RequestID", originalRequestId);
            SqlParameter originalStartDateParameter = new SqlParameter("Original_StartDate", originalStartDate);
            SqlParameter originalEndDateParameter = new SqlParameter("Original_EndDate", originalEndDate);
            SqlParameter originalDescriptionParameter = new SqlParameter("Original_Description", originalDescription);
            SqlParameter originalPaymentTypeParameter = new SqlParameter("Original_PaymentType", originalPaymentType);
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);

            SqlParameter newVacationIdParameter = new SqlParameter("VacationID", newVacationId);
            SqlParameter newRequestIdParameter = new SqlParameter("RequestID", newRequestId);
            SqlParameter newStartDateParameter = new SqlParameter("StartDate", newStartDate);
            SqlParameter newEndDateParameter = new SqlParameter("EndDate", newEndDate);
            SqlParameter newDescriptionParameter = new SqlParameter("Description", newDescription);
            SqlParameter newPaymentTypeParameter = new SqlParameter("PaymentType", newPaymentType);
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);

            string command = "UPDATE [dbo].[LFS_VACATION_DAYS] SET [RequestID] = @RequestID, [StartDate] = @StartDate, [EndDate] = @EndDate, [Description] = @Description, [PaymentType] = @PaymentType, "+
                             "[Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID "+
                             "WHERE ([VacationID] = @Original_VacationID)";

            int rowsAffected = (int)ExecuteNonQuery(command, originalVacationIdParameter, originalRequestIdParameter, originalStartDateParameter, originalEndDateParameter, originalDescriptionParameter, originalPaymentTypeParameter, originalDeletedParameter, originalCompanyIdParameter, newVacationIdParameter, newRequestIdParameter, newStartDateParameter, newEndDateParameter, newDescriptionParameter, newPaymentTypeParameter, newDeletedParameter, newCompanyIdParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }
        }



        /// <summary>
        /// Delete Vacation Day (direct to DB)
        /// </summary>
        /// <param name="nonWorkingDayId">nonWorkingDayId</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <returns>rowsAffected</returns>
        public int Delete(int vacationId)
        {
            SqlParameter originalVacationIdParameter = new SqlParameter("Original_VacationID", vacationId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_VACATION_DAYS] SET [Deleted] = @Deleted " +
                             " WHERE ([VacationID] = @Original_VacationID)";

            int rowsAffected = (int)ExecuteNonQuery(command, originalVacationIdParameter, deletedParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }



    }
}