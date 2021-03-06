using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.FleetManagement.Services
{
    /// <summary>
    /// ServicesNoteGateway
    /// </summary>
    public class ServicesNoteGateway : DataTableGateway
    {
        ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ServicesNoteGateway()
            : base("LFS_FM_SERVICE_NOTE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ServicesNoteGateway(DataSet data)
            : base(data, "LFS_FM_SERVICE_NOTE")
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
            tableMapping.DataSetTable = "LFS_FM_SERVICE_NOTE";
            tableMapping.ColumnMappings.Add("ServiceID", "ServiceID");
            tableMapping.ColumnMappings.Add("RefID", "RefID");
            tableMapping.ColumnMappings.Add("Subject", "Subject");
            tableMapping.ColumnMappings.Add("UserID", "UserID");
            tableMapping.ColumnMappings.Add("DateTime_", "DateTime_");
            tableMapping.ColumnMappings.Add("Note", "Note");
            tableMapping.ColumnMappings.Add("LIBRARY_FILES_ID", "LIBRARY_FILES_ID");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = @"DELETE FROM [dbo].[LFS_FM_SERVICE_NOTE] WHERE (([ServiceID] = @Original_ServiceID) AND ([RefID] = @Original_RefID) AND ([Subject] = @Original_Subject) AND ([UserID] = @Original_UserID) AND ([DateTime_] = @Original_DateTime_) AND ((@IsNull_LIBRARY_FILES_ID = 1 AND [LIBRARY_FILES_ID] IS NULL) OR ([LIBRARY_FILES_ID] = @Original_LIBRARY_FILES_ID)) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ServiceID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ServiceID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RefID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RefID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Subject", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Subject", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_UserID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UserID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DateTime_", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DateTime_", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_LIBRARY_FILES_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LIBRARY_FILES_ID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LIBRARY_FILES_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LIBRARY_FILES_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_FM_SERVICE_NOTE] ([ServiceID], [RefID], [Subject], [UserID], [DateTime_], [Note], [LIBRARY_FILES_ID], [Deleted], [COMPANY_ID]) VALUES (@ServiceID, @RefID, @Subject, @UserID, @DateTime_, @Note, @LIBRARY_FILES_ID, @Deleted, @COMPANY_ID);
SELECT ServiceID, RefID, Subject, UserID, DateTime_, Note, LIBRARY_FILES_ID, Deleted, COMPANY_ID FROM LFS_FM_SERVICE_NOTE WHERE (RefID = @RefID) AND (ServiceID = @ServiceID)";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ServiceID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ServiceID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RefID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RefID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Subject", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Subject", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@UserID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UserID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DateTime_", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DateTime_", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Note", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Note", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LIBRARY_FILES_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LIBRARY_FILES_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand = new global::System.Data.SqlClient.SqlCommand();

            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = @"UPDATE [dbo].[LFS_FM_SERVICE_NOTE] SET [ServiceID] = @ServiceID, [RefID] = @RefID, [Subject] = @Subject, [UserID] = @UserID, [DateTime_] = @DateTime_, [Note] = @Note, [LIBRARY_FILES_ID] = @LIBRARY_FILES_ID, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID WHERE (([ServiceID] = @Original_ServiceID) AND ([RefID] = @Original_RefID) AND ([Subject] = @Original_Subject) AND ([UserID] = @Original_UserID) AND ([DateTime_] = @Original_DateTime_) AND ((@IsNull_LIBRARY_FILES_ID = 1 AND [LIBRARY_FILES_ID] IS NULL) OR ([LIBRARY_FILES_ID] = @Original_LIBRARY_FILES_ID)) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID));
SELECT ServiceID, RefID, Subject, UserID, DateTime_, Note, LIBRARY_FILES_ID, Deleted, COMPANY_ID FROM LFS_FM_SERVICE_NOTE WHERE (RefID = @RefID) AND (ServiceID = @ServiceID)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ServiceID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ServiceID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RefID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RefID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Subject", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Subject", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@UserID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UserID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DateTime_", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DateTime_", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Note", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Note", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LIBRARY_FILES_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LIBRARY_FILES_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ServiceID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ServiceID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RefID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RefID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Subject", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Subject", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_UserID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UserID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DateTime_", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DateTime_", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_LIBRARY_FILES_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LIBRARY_FILES_ID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LIBRARY_FILES_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LIBRARY_FILES_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            #endregion
        }

        



        
        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROWS
        //

        /// <summary>
        /// Insert a service note (direct to DB)
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <param name="refId">refId</param>
        /// <param name="subject">subject</param>
        /// <param name="userId">userId</param>
        /// <param name="dateTime_">dateTime_</param>
        /// <param name="note">note</param>
        /// <param name="libraryFilesId">libraryFilesId</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <returns>rowsAffected</returns>
        public int Insert(int serviceId, int refId, string subject, int userId, DateTime dateTime_, string note, int? libraryFilesId, bool deleted, int companyId)
        {
            SqlParameter serviceIdParameter = new SqlParameter("ServiceID", serviceId);
            SqlParameter refIdParameter = new SqlParameter("RefID", refId);
            SqlParameter subjectParameter = (subject.Trim() != "") ? new SqlParameter("Subject", subject.Trim()) : new SqlParameter("Subject", DBNull.Value);
            SqlParameter userIdParameter = new SqlParameter("UserID", userId);
            SqlParameter dateTime_Parameter = new SqlParameter("DateTime_", dateTime_);
            SqlParameter noteParameter = (note.Trim() != "") ? new SqlParameter("Note", note.Trim()) : new SqlParameter("Note", DBNull.Value);
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            SqlParameter libraryFilesIdParameter = (libraryFilesId.HasValue) ? new SqlParameter("LIBRARY_FILES_ID", libraryFilesId.Value) : new SqlParameter("LIBRARY_FILES_ID", DBNull.Value);

            string command = "INSERT INTO [dbo].[LFS_FM_SERVICE_NOTE] ([ServiceID], [RefID], [Subject], [UserID], [DateTime_], [Note], [LIBRARY_FILES_ID], [Deleted], [COMPANY_ID]) VALUES (@ServiceID, @RefID, @Subject, @UserID, @DateTime_, @Note, @LIBRARY_FILES_ID, @Deleted, @COMPANY_ID)";

            int rowsAffected = (int)ExecuteNonQuery(command, serviceIdParameter, refIdParameter, subjectParameter, userIdParameter, dateTime_Parameter, noteParameter, libraryFilesIdParameter, deletedParameter, companyIdParameter);

            return rowsAffected;
        }



        /// <summary>
        /// Update service note (direct to DB)
        /// </summary>
        /// <param name="originalServiceId">originalServiceId</param>
        /// <param name="originalRefId">originalRefId</param>
        /// <param name="originalSubject">originalSubject</param>
        /// <param name="originalUserId">originalUserId</param>
        /// <param name="originalDateTime_">originalDateTime_</param> 
        /// <param name="originalNote">originalNote</param>
        /// <param name="originalLibraryFilesId">originalLibraryFilesId</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>        
        ///
        /// <param name="newServiceId">newServiceId</param>
        /// <param name="newRefId">newRefId</param>
        /// <param name="newSubject">newSubject</param>
        /// <param name="newUserId">newUserId</param>
        /// <param name="newDateTime_">DateTime_</param>
        /// <param name="newNote">newNote</param>
        /// <param name="newLibraryFilesId">newLibraryFilesId</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <returns>rowsAffected</returns>
        public int Update(int originalServiceId, int originalRefId, string originalSubject, int originalUserId, DateTime originalDateTime_, string originalNote, int? originalLibraryFilesId, bool originalDeleted, int originalCompanyId, int newServiceId, int newRefId, string newSubject, int newUserId,  DateTime newDateTime_, string newNote, int? newLibraryFilesId, bool newDeleted, int newCompanyId)
        {
            SqlParameter originalServiceIdParameter = new SqlParameter("Original_ServiceID", originalServiceId);
            SqlParameter originalRefIdParameter = new SqlParameter("Original_RefID", originalRefId);
            SqlParameter originalSubjectParameter = new SqlParameter("Original_Subject", originalSubject);
            SqlParameter originalUserIdParameter = new SqlParameter("Original_UserID", originalUserId);
            SqlParameter originalDateTime_Parameter = new SqlParameter("Original_DateTime_", originalDateTime_);
            SqlParameter originalNoteParameter = new SqlParameter("Original_Note", originalNote);
            SqlParameter originalLibraryFilesIdParameter = (originalLibraryFilesId.HasValue) ? new SqlParameter("Original_LIBRARY_FILES_ID", originalLibraryFilesId) : new SqlParameter("Original_LIBRARY_FILES_ID", DBNull.Value);
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);

            SqlParameter newServiceIdParameter = new SqlParameter("ServiceID", newServiceId);
            SqlParameter newRefIdParameter = new SqlParameter("RefID", originalRefId);
            SqlParameter newSubjectParameter = (newSubject.Trim() != "") ? new SqlParameter("Subject", newSubject.Trim()) : new SqlParameter("Subject", DBNull.Value);
            SqlParameter newUserIdParameter = new SqlParameter("UserID", newUserId);
            SqlParameter newDateTime_Parameter = new SqlParameter("DateTime_", newDateTime_);
            SqlParameter newNoteParameter = (newNote.Trim() != "") ? new SqlParameter("Note", newNote.Trim()) : new SqlParameter("Note", DBNull.Value);
            SqlParameter newLibraryFilesIdParameter = (newLibraryFilesId.HasValue) ? new SqlParameter("LIBRARY_FILES_ID", newLibraryFilesId) : new SqlParameter("LIBRARY_FILES_ID", DBNull.Value);
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);

            string command = "UPDATE [dbo].[LFS_FM_SERVICE_NOTE] SET [ServiceID] = @ServiceID, [RefID] = @RefID, "+
                " [Subject] = @Subject, [UserID] = @UserID, [DateTime_] = @DateTime_, [Note] = @Note, "+
                " [LIBRARY_FILES_ID] = @LIBRARY_FILES_ID, "+
                " [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID "+
                " WHERE (([ServiceID] = @Original_ServiceID) AND ([RefID] = @Original_RefID) "+
                " AND ([COMPANY_ID] = @Original_COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalServiceIdParameter, originalRefIdParameter, originalSubjectParameter, originalUserIdParameter, originalDateTime_Parameter, originalNoteParameter, originalLibraryFilesIdParameter, originalDeletedParameter, originalCompanyIdParameter, newServiceIdParameter, newRefIdParameter, newSubjectParameter, newUserIdParameter, newDateTime_Parameter, newNoteParameter, newLibraryFilesIdParameter, newDeletedParameter, newCompanyIdParameter); 

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }


        
        /// <summary>
        /// Delete a service note (direct to DB)
        /// </summary>
        /// <param name="originalServiceId">originalServiceId</param>
        /// <param name="originalRefId">originalRefId</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <returns>int</returns>
        public int Delete(int originalServiceId, int originalRefId, int originalCompanyId)
        {
            SqlParameter originalServiceIdParameter = new SqlParameter("@Original_ServiceID", originalServiceId);
            SqlParameter originalRefIdParameter = new SqlParameter("@Original_RefID", originalRefId);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_FM_SERVICE_NOTE] SET  [Deleted] = @Deleted  " +
                             " WHERE (([ServiceID] = @Original_ServiceID) AND ([RefID] = @Original_RefID) AND " +
                             "  ([COMPANY_ID] = @Original_COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery( command, originalServiceIdParameter, originalRefIdParameter, originalCompanyIdParameter, deletedParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }



        /// <summary>
        /// Delete all service notes (direct to DB)
        /// </summary>
        /// <param name="originalServiceId">originalServiceId</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <returns>int</returns>
        public int DeleteAll(int originalServiceId, int originalCompanyId)
        {
            SqlParameter originalServiceIdParameter = new SqlParameter("@Original_ServiceID", originalServiceId);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_FM_SERVICE_NOTE] SET  [Deleted] = @Deleted  " +
                             " WHERE (([ServiceID] = @Original_ServiceID) AND  " +
                             "  ([COMPANY_ID] = @Original_COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalServiceIdParameter, originalCompanyIdParameter, deletedParameter);

            return rowsAffected;
        }



    }
}