using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.FleetManagement.ToDoList
{
    /// <summary>
    /// ToDoListToDoListActivityGateway
    /// </summary>
    public class ToDoListToDoListActivityGateway : DataTableGateway
    {
        ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ToDoListToDoListActivityGateway()
            : base("LFS_FM_TODOLIST_ACTIVITY")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ToDoListToDoListActivityGateway(DataSet data)
            : base(data, "LFS_FM_TODOLIST_ACTIVITY")
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
            tableMapping.DataSetTable = "LFS_FM_TODOLIST_ACTIVITY";
            tableMapping.ColumnMappings.Add("ToDoID", "ToDoID");
            tableMapping.ColumnMappings.Add("RefID", "RefID");
            tableMapping.ColumnMappings.Add("EmployeeID", "EmployeeID");
            tableMapping.ColumnMappings.Add("Type_", "Type_");
            tableMapping.ColumnMappings.Add("DateTime_", "DateTime_");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("Comment", "Comment");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = @"DELETE FROM [dbo].[LFS_FM_TODOLIST_ACTIVITY] WHERE (([ToDoID] = @Original_ToDoID) AND ([RefID] = @Original_RefID) AND ([EmployeeID] = @Original_EmployeeID) AND ([Type_] = @Original_Type_) AND ([DateTime_] = @Original_DateTime_) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ToDoID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ToDoID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RefID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RefID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_EmployeeID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EmployeeID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Type_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Type_", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DateTime_", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DateTime_", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_FM_TODOLIST_ACTIVITY] ([ToDoID], [RefID], [EmployeeID], [Type_], [DateTime_], [Deleted], [COMPANY_ID], [Comment]) VALUES (@ToDoID, @RefID, @EmployeeID, @Type_, @DateTime_, @Deleted, @COMPANY_ID, @Comment);
SELECT ToDoID, RefID, EmployeeID, Type_, DateTime_, Deleted, COMPANY_ID, Comment FROM LFS_FM_TODOLIST_ACTIVITY WHERE (RefID = @RefID) AND (ToDoID = @ToDoID)";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ToDoID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ToDoID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RefID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RefID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@EmployeeID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EmployeeID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Type_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Type_", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DateTime_", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DateTime_", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Comment", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Comment", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = @"UPDATE [dbo].[LFS_FM_TODOLIST_ACTIVITY] SET [ToDoID] = @ToDoID, [RefID] = @RefID, [EmployeeID] = @EmployeeID, [Type_] = @Type_, [DateTime_] = @DateTime_, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID, [Comment] = @Comment WHERE (([ToDoID] = @Original_ToDoID) AND ([RefID] = @Original_RefID) AND ([EmployeeID] = @Original_EmployeeID) AND ([Type_] = @Original_Type_) AND ([DateTime_] = @Original_DateTime_) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID));
SELECT ToDoID, RefID, EmployeeID, Type_, DateTime_, Deleted, COMPANY_ID, Comment FROM LFS_FM_TODOLIST_ACTIVITY WHERE (RefID = @RefID) AND (ToDoID = @ToDoID)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ToDoID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ToDoID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RefID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RefID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@EmployeeID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EmployeeID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Type_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Type_", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DateTime_", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DateTime_", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Comment", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Comment", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ToDoID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ToDoID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RefID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RefID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_EmployeeID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EmployeeID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Type_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Type_", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DateTime_", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DateTime_", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            #endregion
        }

        



        
        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROWS
        //

        /// <summary>
        /// Insert a to do activity (direct to DB)
        /// </summary>
        /// <param name="toDoId">toDoId</param>
        /// <param name="refId">refId</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="type_">type_</param>
        /// <param name="dateTime_">dateTime_</param>        
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="comment">comment</param>
        /// <returns>rowsAffected</returns>
        public int Insert(int toDoId, int refId, int employeeId, string type_, DateTime dateTime_, bool deleted, int companyId, string comment)
        {
            SqlParameter toDoIdParameter = new SqlParameter("ToDoId", toDoId);
            SqlParameter refIdParameter = new SqlParameter("RefID", refId);
            SqlParameter type_Parameter = new SqlParameter("Type_", type_);
            SqlParameter employeeIdParameter = new SqlParameter("EmployeeID", employeeId);
            SqlParameter dateTime_Parameter = new SqlParameter("DateTime_", dateTime_);            
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);            
            SqlParameter commentParameter = (comment != "") ? new SqlParameter("Comment", comment) : new SqlParameter("Comment", DBNull.Value);

            string command = "INSERT INTO [dbo].[LFS_FM_TODOLIST_ACTIVITY] ([ToDoID], [RefID], [EmployeeID], [Type_], [DateTime_], [Deleted], [COMPANY_ID], [Comment]) VALUES (@ToDoID, @RefID, @EmployeeID, @Type_, @DateTime_, @Deleted, @COMPANY_ID, @Comment)";
            int rowsAffected = (int)ExecuteNonQuery(command, toDoIdParameter, refIdParameter, employeeIdParameter, type_Parameter, dateTime_Parameter, deletedParameter, companyIdParameter, commentParameter);
            return rowsAffected;
        }



        /// <summary>
        /// Update to do activity (direct to DB)
        /// </summary>
        /// <param name="originalToDoId">originalToDoId</param>
        /// <param name="originalRefId">originalRefId</param>
        /// <param name="originalEmployeeId">originalEmployeeId</param>
        /// <param name="originalType_">originalType_</param>
        /// <param name="originalDateTime_">originalDateTime_</param>        
        /// <param name="originalDeleted">originalDeleted</param> 
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalComment">originalComment</param>
        ///
        /// <param name="newToDoId">newToDoId</param>
        /// <param name="newRefId">newRefId</param>
        /// <param name="newEmployeeId">newEmployeeId</param>
        /// <param name="newType_">newType_</param>
        /// <param name="newDateTime_">newDateTime_</param>        
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newComment">newComment</param>
        /// <returns>rowsAffected</returns>
        public int Update(int originalToDoId, int originalRefId, int originalEmployeeId, string originalType_, DateTime originalDateTime_, bool originalDeleted, int originalCompanyId, string originalComment, int newToDoId, int newRefId, int newEmployeeId, string newType_, DateTime newDateTime_, bool newDeleted, int newCompanyId, string newComment)
        {
            SqlParameter originalToDoIdParameter = new SqlParameter("Original_ToDoID", originalToDoId);
            SqlParameter originalRefIdParameter = new SqlParameter("Original_RefID", originalRefId);
            SqlParameter originalEmployeeIdParameter = new SqlParameter("Original_EmployeeID", originalEmployeeId);
            SqlParameter originalType_Parameter = new SqlParameter("Original_Type_", originalType_);
            SqlParameter originalDateTime_Parameter = new SqlParameter("Original_DateTime_", originalDateTime_);            
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);            
            SqlParameter originalCommentParameter = (originalComment != "") ? new SqlParameter("Original_Comment", originalComment) : new SqlParameter("Original_Comment", DBNull.Value);

            
            SqlParameter newToDoIdParameter = new SqlParameter("ToDoID", newToDoId);
            SqlParameter newRefIdParameter = new SqlParameter("RefID", originalRefId);
            SqlParameter newEmployeeIdParameter = new SqlParameter("EmployeeID", newEmployeeId);
            SqlParameter newType_Parameter = new SqlParameter("Type_", newType_);
            SqlParameter newDateTime_Parameter = new SqlParameter("DateTime_", newDateTime_);            
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);            
            SqlParameter newCommentParameter = (newComment != "") ? new SqlParameter("Comment", newComment) : new SqlParameter("Comment", DBNull.Value);

            string command = " UPDATE [dbo].[LFS_FM_TODOLIST_ACTIVITY] SET [EmployeeID] = @EmployeeID, [Type_] = @Type_, [DateTime_] = @DateTime_, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID, [Comment] = @Comment" +
                             " WHERE (([ToDoID] = @Original_ToDoID) AND ([RefID] = @Original_RefID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalToDoIdParameter, originalRefIdParameter, originalEmployeeIdParameter, originalType_Parameter,  originalDateTime_Parameter, originalDeletedParameter, originalCompanyIdParameter, originalCommentParameter, newToDoIdParameter, newRefIdParameter, newEmployeeIdParameter, newType_Parameter, newDateTime_Parameter, newDeletedParameter, newCompanyIdParameter, newCommentParameter); 

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }



        /// <summary>
        /// Delete to do activity (direct to DB)
        /// </summary>
        /// <param name="originalToDoId">originalToDoId</param>
        /// <param name="originalRefId">originalRefId</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <returns>int</returns>
        public int Delete(int originalToDoId, int originalRefId, int originalCompanyId)
        {
            SqlParameter originalToDoIdParameter = new SqlParameter("@Original_ToDoID", originalToDoId);
            SqlParameter originalRefIdParameter = new SqlParameter("@Original_RefID", originalRefId);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_FM_TODOLIST_ACTIVITY] SET  [Deleted] = @Deleted  " +
                             " WHERE (([ToDoID] = @Original_ToDoID) AND ([RefID] = @Original_RefID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalToDoIdParameter, originalRefIdParameter, originalCompanyIdParameter, deletedParameter);

            return rowsAffected;
        }



                
        /// <summary>
        /// Delete all to do activity (direct to DB)
        /// </summary>
        /// <param name="originalToDoId">originalToDoId</param>
        /// <returns>int</returns>
        public int DeleteAll(int originalToDoId, int originalCompanyId)
        {
            SqlParameter originalToDoIdParameter = new SqlParameter("@Original_ToDoID", originalToDoId);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_FM_TODOLIST_ACTIVITY] SET  [Deleted] = @Deleted  " +
                             " WHERE (([ToDoID] = @Original_ToDoID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalToDoIdParameter, originalCompanyIdParameter, deletedParameter);

            return rowsAffected;
        }



    }
}
