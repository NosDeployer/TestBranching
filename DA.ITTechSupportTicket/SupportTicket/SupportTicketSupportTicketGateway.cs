using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.ITTechSupportTicket.SupportTicket
{
    /// <summary>
    /// SupportTicketSupportTicketGateway
    /// </summary>
    public class SupportTicketSupportTicketGateway : DataTableGateway
    {
        ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public SupportTicketSupportTicketGateway()
            : base("LFS_ITTST_SUPPORTICKET")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public SupportTicketSupportTicketGateway(DataSet data)
            : base(data, "LFS_ITTST_SUPPORTICKET")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new SupportTicketTDS();
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
            tableMapping.DataSetTable = "LFS_ITTST_SUPPORTICKET";
            tableMapping.ColumnMappings.Add("SupportTicketID", "SupportTicketID");
            tableMapping.ColumnMappings.Add("CategoryID", "CategoryID");
            tableMapping.ColumnMappings.Add("Subject", "Subject");
            tableMapping.ColumnMappings.Add("CreationDate", "CreationDate");
            tableMapping.ColumnMappings.Add("CreatedByID", "CreatedByID");
            tableMapping.ColumnMappings.Add("State", "State");
            tableMapping.ColumnMappings.Add("DueDate", "DueDate");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = @"DELETE FROM [dbo].[LFS_ITTST_SUPPORTICKET] WHERE (([SupportTicketID] = @Original_SupportTicketID) AND ([CategoryID] = @Original_CategoryID) AND ([Subject] = @Original_Subject) AND ([CreationDate] = @Original_CreationDate) AND ([CreatedByID] = @Original_CreatedByID) AND ([State] = @Original_State) AND ((@IsNull_DueDate = 1 AND [DueDate] IS NULL) OR ([DueDate] = @Original_DueDate)) AND ((@IsNull_Deleted = 1 AND [Deleted] IS NULL) OR ([Deleted] = @Original_Deleted)) AND ([COMPANY_ID] = @Original_COMPANY_ID))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_SupportTicketID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SupportTicketID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CategoryID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CategoryID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Subject", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Subject", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CreationDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CreationDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CreatedByID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CreatedByID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_State", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "State", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DueDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DueDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DueDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DueDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Deleted", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_ITTST_SUPPORTICKET] ([SupportTicketID], [CategoryID], [Subject], [CreationDate], [CreatedByID], [State], [DueDate], [Deleted], [COMPANY_ID]) VALUES (@SupportTicketID, @CategoryID, @Subject, @CreationDate, @CreatedByID, @State, @DueDate, @Deleted, @COMPANY_ID);
SELECT SupportTicketID, CategoryID, Subject, CreationDate, CreatedByID, State, DueDate, Deleted, COMPANY_ID FROM LFS_ITTST_SUPPORTICKET WHERE (SupportTicketID = @SupportTicketID)";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@SupportTicketID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SupportTicketID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CategoryID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CategoryID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Subject", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Subject", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CreationDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CreationDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CreatedByID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CreatedByID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@State", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "State", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DueDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DueDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));

            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = @"UPDATE [dbo].[LFS_ITTST_SUPPORTICKET] SET [SupportTicketID] = @SupportTicketID, [CategoryID] = @CategoryID, [Subject] = @Subject, [CreationDate] = @CreationDate, [CreatedByID] = @CreatedByID, [State] = @State, [DueDate] = @DueDate, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID WHERE (([SupportTicketID] = @Original_SupportTicketID) AND ([CategoryID] = @Original_CategoryID) AND ([Subject] = @Original_Subject) AND ([CreationDate] = @Original_CreationDate) AND ([CreatedByID] = @Original_CreatedByID) AND ([State] = @Original_State) AND ((@IsNull_DueDate = 1 AND [DueDate] IS NULL) OR ([DueDate] = @Original_DueDate)) AND ((@IsNull_Deleted = 1 AND [Deleted] IS NULL) OR ([Deleted] = @Original_Deleted)) AND ([COMPANY_ID] = @Original_COMPANY_ID));
SELECT SupportTicketID, CategoryID, Subject, CreationDate, CreatedByID, State, DueDate, Deleted, COMPANY_ID FROM LFS_ITTST_SUPPORTICKET WHERE (SupportTicketID = @SupportTicketID)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@SupportTicketID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SupportTicketID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CategoryID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CategoryID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Subject", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Subject", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CreationDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CreationDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CreatedByID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CreatedByID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@State", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "State", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DueDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DueDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_SupportTicketID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SupportTicketID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CategoryID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CategoryID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Subject", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Subject", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CreationDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CreationDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CreatedByID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CreatedByID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_State", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "State", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DueDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DueDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DueDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DueDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Deleted", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            #endregion
        }





        
        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROWS
        //

        /// <summary>
        /// Insert a support ticket (direct to DB)
        /// </summary>
        /// <param name="categoryId">categoryId</param>
        /// <param name="newSupportTicketID">newSupportTicketID</param>
        /// <param name="subject">subject</param>
        /// <param name="creationDate">creationDate</param>
        /// <param name="createdById">createdById</param>
        /// <param name="state">state</param>
        /// <param name="dueDate">dueDate</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>       
        /// <returns>SupportTicketID</returns>
        public int Insert(int categoryId, string subject, DateTime creationDate, int createdById, string state, DateTime? dueDate, bool deleted, int companyId)
        {
            SqlParameter categoryIdParameter = new SqlParameter("CategoryID", categoryId);
            SqlParameter subjectParameter = new SqlParameter("Subject", subject);
            SqlParameter creationDateParameter = new SqlParameter("CreationDate", creationDate);
            SqlParameter createdByIdParameter = new SqlParameter("CreatedByID", createdById);
            SqlParameter stateParameter = new SqlParameter("State", state);
            SqlParameter dueDateParameter = (dueDate.HasValue) ? new SqlParameter("DueDate", dueDate) : new SqlParameter("DueDate", DBNull.Value);            
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);

            string command = "INSERT INTO [dbo].[LFS_ITTST_SUPPORTICKET]  ([CategoryID], [Subject], [CreationDate], [CreatedByID], [State], [DueDate], [Deleted], [COMPANY_ID]) "+
            " VALUES  (@CategoryID, @Subject, @CreationDate, @CreatedByID, @State, @DueDate, @Deleted, @COMPANY_ID); SELECT SupportTicketID FROM LFS_ITTST_SUPPORTICKET WHERE (SupportTicketID = SCOPE_IDENTITY())";
            int supportTicketId = (int)ExecuteScalar(command, categoryIdParameter, subjectParameter, creationDateParameter, createdByIdParameter, stateParameter, dueDateParameter, deletedParameter, companyIdParameter);
            return supportTicketId;
        }



        /// <summary>
        /// Update support ticket (direct to DB)
        /// </summary>
        /// <param name="originalSupportTicketId">originalSupportTicketId</param>
        /// <param name="originalCategoryId">originalCategoryId</param>
        /// <param name="originalSubject">originalSubject</param>
        /// <param name="originalCreationDate">originalCreationDate</param>
        /// <param name="originalCreatedById">originalCreatedById</param>
        /// <param name="originalState">originalState</param>
        /// <param name="originalDueDate">originalDueDate</param>
        /// <param name="originalDeleted">originalDeleted</param> 
        /// <param name="originalCompanyId">originalCompanyId</param>
        ///
        /// <param name="newSupportTicketId">newSupportTicketId</param>
        /// <param name="newCategoryId">newCategoryId</param>
        /// <param name="newSubject">newSubject</param>
        /// <param name="newCreationDate">newCreationDate</param>
        /// <param name="newCreatedById">newCreatedById</param>
        /// <param name="newState">newState</param>
        /// <param name="newDueDate">newDueDate</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <returns>rowsAffected</returns>
        public int Update(int originalSupportTicketId, int originalCategoryId, string originalSubject, DateTime originalCreationDate, int originalCreatedById, string originalState, DateTime? originalDueDate, bool originalDeleted, int originalCompanyId, int newSupportTicketId, int newCategoryId, string newSubject, DateTime newCreationDate, int newCreatedById, string newState, DateTime? newDueDate, bool newDeleted, int newCompanyId)
        {
            SqlParameter originalSupportTicketIdParameter = new SqlParameter("Original_SupportTicketID", originalSupportTicketId);
            SqlParameter originalCategoryIdParameter = new SqlParameter("Original_CategoryID", originalCategoryId);
            SqlParameter originalSubjectParameter = new SqlParameter("Original_Subject", originalSubject);
            SqlParameter originalCreationDateParameter = new SqlParameter("Original_CreationDate", originalCreationDate);
            SqlParameter originalCreatedByIDParameter = new SqlParameter("Original_CreatedByID", originalCreatedById);
            SqlParameter originalStateParameter = new SqlParameter("Original_State", originalState);
            SqlParameter originalDueDateParameter = (originalDueDate.HasValue) ? new SqlParameter("Original_DueDate", originalDueDate) : new SqlParameter("Original_DueDate", DBNull.Value);            
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);

            SqlParameter newSupportTicketIdParameter = new SqlParameter("SupportTicketID", newSupportTicketId);
            SqlParameter newCategoryIdParameter = new SqlParameter("CategoryID", newCategoryId);
            SqlParameter newSubjectParameter = new SqlParameter("Subject", newSubject);
            SqlParameter newCreationDateParameter = new SqlParameter("CreationDate", newCreationDate);
            SqlParameter newCreatedByIDParameter = new SqlParameter("CreatedByID", newCreatedById);
            SqlParameter newStateParameter = new SqlParameter("State", newState);
            SqlParameter newDueDateParameter = (newDueDate.HasValue) ? new SqlParameter("DueDate", newDueDate) : new SqlParameter("DueDate", DBNull.Value);            
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);

            string command = "UPDATE [dbo].[LFS_ITTST_SUPPORTICKET] SET  [CategoryID] = @CategoryID, [Subject] = @Subject, [CreationDate] = @CreationDate, [CreatedByID] = @CreatedByID, [State] = @State, [DueDate] = @DueDate" +
                             " WHERE (([SupportTicketID] = @Original_SupportTicketID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalSupportTicketIdParameter, originalCategoryIdParameter, originalSubjectParameter, originalCreationDateParameter, newCreatedByIDParameter, originalStateParameter, originalDueDateParameter, originalDeletedParameter, originalCompanyIdParameter, newSupportTicketIdParameter, newCategoryIdParameter, newSubjectParameter, newCreationDateParameter, newStateParameter, newDueDateParameter,  newDeletedParameter, newCompanyIdParameter); 

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }


        
        /// <summary>
        /// Delete support ticket (direct to DB)
        /// </summary>
        /// <param name="supportTicketId">supportTicketId</param>        
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <returns>int</returns>
        public int Delete(int supportTicketId, int originalCompanyId)
        {
            SqlParameter originalSupportTicketIdParameter = new SqlParameter("@Original_SupportTicketID", supportTicketId);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_ITTST_SUPPORTICKET] SET  [Deleted] = @Deleted " +
                             " WHERE (([SupportTicketID] = @Original_SupportTicketID) AND " +
                             "  ([COMPANY_ID] = @Original_COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalSupportTicketIdParameter, originalCompanyIdParameter, deletedParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }


    }
}
