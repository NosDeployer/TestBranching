using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.FleetManagement.ToDoList
{
    /// <summary>
    /// ToDoListToDoListGateway
    /// </summary>
    public class ToDoListToDoListGateway : DataTableGateway
    {
        ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ToDoListToDoListGateway()
            : base("LFS_FM_TODOLIST")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ToDoListToDoListGateway(DataSet data)
            : base(data, "LFS_FM_TODOLIST")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ToDoListTDS();
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
            tableMapping.DataSetTable = "LFS_FM_TODOLIST";
            tableMapping.ColumnMappings.Add("ToDoID", "ToDoID");
            tableMapping.ColumnMappings.Add("Subject", "Subject");
            tableMapping.ColumnMappings.Add("CreationDate", "CreationDate");
            tableMapping.ColumnMappings.Add("CreatedById", "CreatedById");
            tableMapping.ColumnMappings.Add("State", "State");
            tableMapping.ColumnMappings.Add("DueDate", "DueDate");
            tableMapping.ColumnMappings.Add("UnitID", "UnitID");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = @"DELETE FROM [dbo].[LFS_FM_TODOLIST] WHERE (([ToDoID] = @Original_ToDoID) AND ([Subject] = @Original_Subject) AND ([CreationDate] = @Original_CreationDate) AND ([CreatedById] = @Original_CreatedById) AND ([State] = @Original_State) AND ((@IsNull_DueDate = 1 AND [DueDate] IS NULL) OR ([DueDate] = @Original_DueDate)) AND ((@IsNull_UnitID = 1 AND [UnitID] IS NULL) OR ([UnitID] = @Original_UnitID)) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ToDoID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ToDoID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Subject", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Subject", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CreationDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CreationDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CreatedById", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CreatedById", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_State", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "State", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DueDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DueDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DueDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DueDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_UnitID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_UnitID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_FM_TODOLIST] ([Subject], [CreationDate], [CreatedById], [State], [DueDate], [UnitID], [Deleted], [COMPANY_ID]) VALUES (@Subject, @CreationDate, @CreatedById, @State, @DueDate, @UnitID, @Deleted, @COMPANY_ID);
SELECT ToDoID, Subject, CreationDate, CreatedById, State, DueDate, UnitID, Deleted, COMPANY_ID FROM LFS_FM_TODOLIST WHERE (ToDoID = SCOPE_IDENTITY())";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Subject", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Subject", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CreationDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CreationDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CreatedById", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CreatedById", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@State", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "State", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DueDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DueDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@UnitID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));

            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = @"UPDATE [dbo].[LFS_FM_TODOLIST] SET [Subject] = @Subject, [CreationDate] = @CreationDate, [CreatedById] = @CreatedById, [State] = @State, [DueDate] = @DueDate, [UnitID] = @UnitID, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID WHERE (([ToDoID] = @Original_ToDoID) AND ([Subject] = @Original_Subject) AND ([CreationDate] = @Original_CreationDate) AND ([CreatedById] = @Original_CreatedById) AND ([State] = @Original_State) AND ((@IsNull_DueDate = 1 AND [DueDate] IS NULL) OR ([DueDate] = @Original_DueDate)) AND ((@IsNull_UnitID = 1 AND [UnitID] IS NULL) OR ([UnitID] = @Original_UnitID)) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID));
SELECT ToDoID, Subject, CreationDate, CreatedById, State, DueDate, UnitID, Deleted, COMPANY_ID FROM LFS_FM_TODOLIST WHERE (ToDoID = @ToDoID)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Subject", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Subject", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CreationDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CreationDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CreatedById", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CreatedById", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@State", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "State", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DueDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DueDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@UnitID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ToDoID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ToDoID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Subject", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Subject", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CreationDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CreationDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CreatedById", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CreatedById", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_State", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "State", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DueDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DueDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DueDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DueDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_UnitID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_UnitID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ToDoID", global::System.Data.SqlDbType.Int, 4, global::System.Data.ParameterDirection.Input, 0, 0, "ToDoID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// LoadTop1ByToDoId
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <returns>data set</returns>
        public DataSet LoadTop1ByToDoId(int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_TODOLISTTODOLISTGATEWAY_LOADTOP1BYTODOID", new SqlParameter("@companyId", companyId));
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
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.FleetManagement.ToDoList.ToDoListToDoListGateway.GetRow");
            }
        }



        /// <summary>
        /// GetToDoTop1. If not exists, raise an exception.
        /// </summary>
        /// <returns>GetNumber or EMPTY</returns>
        public string GetToDoTop1()
        {
            return (string)GetRowTop1()["ToDoID"];
        }


        



        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROWS
        //

        /// <summary>
        /// Insert a todo list (direct to DB)
        /// </summary>
        /// <param name="newToDoID">newToDoID</param>
        /// <param name="subject">subject</param>
        /// <param name="creationDate">creationDate</param>
        /// <param name="createdById">createdById</param>
        /// <param name="state">state</param>
        /// <param name="dueDate">dueDate</param>
        /// <param name="unitId">unitId</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>       
        /// <returns>ToDoID</returns>
        public int Insert(string subject, DateTime creationDate, int createdById, string state, DateTime? dueDate, int? unitId, bool deleted, int companyId)
        {
            SqlParameter subjectParameter = new SqlParameter("Subject", subject);
            SqlParameter creationDateParameter = new SqlParameter("CreationDate", creationDate);
            SqlParameter createdByIdParameter = new SqlParameter("CreatedByID", createdById);
            SqlParameter stateParameter = new SqlParameter("State", state);
            SqlParameter dueDateParameter = (dueDate.HasValue) ? new SqlParameter("DueDate", dueDate) : new SqlParameter("DueDate", DBNull.Value);
            SqlParameter unitIdParameter = (unitId.HasValue) ? new SqlParameter("UnitId", unitId.Value) : new SqlParameter("UnitId", DBNull.Value);
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);

            string command = "INSERT INTO [dbo].[LFS_FM_TODOLIST] ([Subject], [CreationDate], [CreatedByID], [State], [DueDate], [UnitID], [Deleted], [COMPANY_ID]) VALUES (@Subject, @CreationDate, @CreatedByID, @State, @DueDate, @UnitID, @Deleted, @COMPANY_ID); SELECT ToDoID FROM LFS_FM_TODOLIST WHERE (ToDoID = SCOPE_IDENTITY())";
            int toDoId = (int)ExecuteScalar(command, subjectParameter, creationDateParameter, createdByIdParameter, stateParameter, dueDateParameter, unitIdParameter, deletedParameter, companyIdParameter);
            return toDoId;
        }



        /// <summary>
        /// Update to do list (direct to DB)
        /// </summary>
        /// <param name="originalToDoId">originalToDoId</param>
        /// <param name="originalSubject">originalSubject</param>
        /// <param name="originalCreationDate">originalCreationDate</param>
        /// <param name="originalCreatedByID">originalCreatedByID</param>
        /// <param name="originalState">originalState</param>
        /// <param name="originalDueDate">originalDueDate</param>
        /// <param name="originalUnitId">originalUnitId</param>
        /// <param name="originalDeleted">originalDeleted</param> 
        /// <param name="originalCompanyId">originalCompanyId</param>
        ///
        /// <param name="newToDoId">newToDoId</param>
        /// <param name="newSubject">newSubject</param>
        /// <param name="newCreationDate">newCreationDate</param>
        /// <param name="newCreatedByID">newCreatedByID</param>
        /// <param name="newState">newState</param>
        /// <param name="newDueDate">newDueDate</param>
        /// <param name="newUnitId">newUnitId</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <returns>rowsAffected</returns>
        public int Update(int originalToDoId, string originalSubject, DateTime originalCreationDate, int originalCreatedByID, string originalState, DateTime? originalDueDate, int? originalUnitId, bool originalDeleted, int originalCompanyId, int newToDoId, string newSubject, DateTime newCreationDate, int newCreatedByID, string newState, DateTime? newDueDate, int? newUnitId, bool newDeleted, int newCompanyId)
        {
            SqlParameter originalToDoIdParameter = new SqlParameter("Original_ToDoID", originalToDoId);
            SqlParameter originalSubjectParameter = new SqlParameter("Original_Subject", originalSubject);
            SqlParameter originalCreationDateParameter = new SqlParameter("Original_CreationDate", originalCreationDate);
            SqlParameter originalCreatedByIDParameter = new SqlParameter("Original_CreatedByID", originalCreatedByID);
            SqlParameter originalStateParameter = new SqlParameter("Original_State", originalState);
            SqlParameter originalDueDateParameter = (originalDueDate.HasValue) ? new SqlParameter("Original_DueDate", originalDueDate) : new SqlParameter("Original_DueDate", DBNull.Value);
            SqlParameter originalUnitIdParameter = (originalUnitId.HasValue) ? new SqlParameter("Original_UnitID", originalUnitId) : new SqlParameter("Original_UnitID", DBNull.Value);
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);

            SqlParameter newToDoIdParameter = new SqlParameter("ToDoID", newToDoId);
            SqlParameter newSubjectParameter = new SqlParameter("Subject", newSubject);
            SqlParameter newCreationDateParameter = new SqlParameter("CreationDate", newCreationDate);
            SqlParameter newCreatedByIDParameter = new SqlParameter("CreatedByID", newCreatedByID);
            SqlParameter newStateParameter = new SqlParameter("State", newState);
            SqlParameter newDueDateParameter = (newDueDate.HasValue) ? new SqlParameter("DueDate", newDueDate) : new SqlParameter("DueDate", DBNull.Value);
            SqlParameter newUnitIdParameter = (newUnitId.HasValue) ? new SqlParameter("UnitID", newUnitId) : new SqlParameter("UnitID", DBNull.Value);
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);

            string command = "UPDATE [dbo].[LFS_FM_TODOLIST] SET [Subject] = @Subject, [CreationDate] = @CreationDate, [CreatedByID] = @CreatedByID, [State] = @State, [DueDate] = @DueDate, [UnitID] = @UnitID, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID" +
                             " WHERE (([ToDoID] = @Original_ToDoID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalToDoIdParameter, originalSubjectParameter, originalCreationDateParameter, newCreatedByIDParameter, originalStateParameter, originalDueDateParameter, originalUnitIdParameter, originalDeletedParameter, originalCompanyIdParameter, newToDoIdParameter, newSubjectParameter, newCreationDateParameter, newStateParameter, newDueDateParameter, newUnitIdParameter, newDeletedParameter, newCompanyIdParameter); 

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }


        
        /// <summary>
        /// Delete a to do list (direct to DB)
        /// </summary>
        /// <param name="toDoListId">toDoListId</param>        
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <returns>int</returns>
        public int Delete(int toDoListId, int originalCompanyId)
        {
            SqlParameter originalToDoListIdParameter = new SqlParameter("@Original_ToDoID", toDoListId);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_FM_TODOLIST] SET  [Deleted] = @Deleted " +
                             " WHERE (([ToDoID] = @Original_ToDoID) AND " +
                             "  ([COMPANY_ID] = @Original_COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalToDoListIdParameter, originalCompanyIdParameter, deletedParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }


    }
}
