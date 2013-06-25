using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Projects.Projects
{
    /// <summary>
    /// ProjectTechnicalGateway
    /// </summary>
    public class ProjectNotesGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectNotesGateway()
            : base("LFS_PROJECT_NOTE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectNotesGateway(DataSet data)
            : base(data, "LFS_PROJECT_NOTE")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ProjectTDS();
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
            tableMapping.DataSetTable = "LFS_PROJECT_NOTE";
            tableMapping.ColumnMappings.Add("ProjectID", "ProjectID");
            tableMapping.ColumnMappings.Add("RefID", "RefID");
            tableMapping.ColumnMappings.Add("Subject", "Subject");
            tableMapping.ColumnMappings.Add("DateTime", "DateTime");
            tableMapping.ColumnMappings.Add("LoginID", "LoginID");
            tableMapping.ColumnMappings.Add("Note", "Note");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("LIBRARY_FILES_ID", "LIBRARY_FILES_ID");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");

            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = @"DELETE FROM [dbo].[LFS_PROJECT_NOTE] WHERE (([ProjectID] = @Original_ProjectID) AND ([RefID] = @Original_RefID) AND ([Subject] = @Original_Subject) AND ([DateTime] = @Original_DateTime) AND ([LoginID] = @Original_LoginID) AND ([Deleted] = @Original_Deleted) AND ((@IsNull_LIBRARY_FILES_ID = 1 AND [LIBRARY_FILES_ID] IS NULL) OR ([LIBRARY_FILES_ID] = @Original_LIBRARY_FILES_ID)) AND ([COMPANY_ID] = @Original_COMPANY_ID))";
            this._adapter.DeleteCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ProjectID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ProjectID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RefID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "RefID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Subject", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Subject", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DateTime", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "DateTime", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LoginID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LoginID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Deleted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_LIBRARY_FILES_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LIBRARY_FILES_ID", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LIBRARY_FILES_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LIBRARY_FILES_ID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_PROJECT_NOTE] ([ProjectID], [RefID], [Subject], [DateTime], [LoginID], [Note], [Deleted], [LIBRARY_FILES_ID], [COMPANY_ID]) VALUES (@ProjectID, @RefID, @Subject, @DateTime, @LoginID, @Note, @Deleted, @LIBRARY_FILES_ID, @COMPANY_ID);
SELECT ProjectID, RefID, Subject, DateTime, LoginID, Note, Deleted, LIBRARY_FILES_ID, COMPANY_ID FROM LFS_PROJECT_NOTE WHERE (ProjectID = @ProjectID) AND (RefID = @RefID)";
            this._adapter.InsertCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ProjectID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ProjectID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RefID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "RefID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Subject", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Subject", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DateTime", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "DateTime", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LoginID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LoginID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Note", System.Data.SqlDbType.NText, 0, System.Data.ParameterDirection.Input, 0, 0, "Note", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Deleted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LIBRARY_FILES_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LIBRARY_FILES_ID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Current, false, null, "", "", ""));

            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = @"UPDATE [dbo].[LFS_PROJECT_NOTE] SET [ProjectID] = @ProjectID, [RefID] = @RefID, [Subject] = @Subject, [DateTime] = @DateTime, [LoginID] = @LoginID, [Note] = @Note, [Deleted] = @Deleted, [LIBRARY_FILES_ID] = @LIBRARY_FILES_ID, [COMPANY_ID] = @COMPANY_ID WHERE (([ProjectID] = @Original_ProjectID) AND ([RefID] = @Original_RefID) AND ([Subject] = @Original_Subject) AND ([DateTime] = @Original_DateTime) AND ([LoginID] = @Original_LoginID) AND ([Deleted] = @Original_Deleted) AND ((@IsNull_LIBRARY_FILES_ID = 1 AND [LIBRARY_FILES_ID] IS NULL) OR ([LIBRARY_FILES_ID] = @Original_LIBRARY_FILES_ID)) AND ([COMPANY_ID] = @Original_COMPANY_ID));
SELECT ProjectID, RefID, Subject, DateTime, LoginID, Note, Deleted, LIBRARY_FILES_ID, COMPANY_ID FROM LFS_PROJECT_NOTE WHERE (ProjectID = @ProjectID) AND (RefID = @RefID)";
            this._adapter.UpdateCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ProjectID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ProjectID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RefID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "RefID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Subject", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Subject", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DateTime", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "DateTime", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LoginID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LoginID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Note", System.Data.SqlDbType.NText, 0, System.Data.ParameterDirection.Input, 0, 0, "Note", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Deleted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LIBRARY_FILES_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LIBRARY_FILES_ID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ProjectID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ProjectID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RefID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "RefID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Subject", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Subject", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DateTime", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "DateTime", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LoginID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LoginID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Deleted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_LIBRARY_FILES_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LIBRARY_FILES_ID", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LIBRARY_FILES_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LIBRARY_FILES_ID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// LoadAllByProjectId
        /// </summary>
        /// <param name="projectId">ProjectId filter</param>
        /// <returns>Data</returns>
        public DataSet LoadAllByProjectId(int projectId)
        {
            FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTNOTESGATEWAY_LOADALLBYPROJECTID", new SqlParameter("@projectId", projectId));
            return Data;
        }



        /// <summary>
        /// LoadByProjectId
        /// </summary>
        /// <param name="projectId">ProjectId filter</param>
        /// <returns>Data</returns>
        public DataSet LoadByProjectId(int projectId)
        {
            FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTNOTESGATEWAY_LOADBYPROJECTID", new SqlParameter("@projectId", projectId));
            return Data;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROWS
        //

        /// <summary>
        /// Insert a  note (direct to DB)
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>
        /// <param name="subject">subject</param>
        /// <param name="loginId">loginId</param>
        /// <param name="dateTime">dateTime</param>
        /// <param name="note">note</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="LIBRARY_FILES_ID">LIBRARY_FILES_ID</param>
        /// <returns>rowsAffected</returns>
        public int Insert(int projectId, int refId, string subject, int loginId, DateTime dateTime, string note, bool deleted, int companyId, int? libraryFilesId)
        {
            SqlParameter projectIdParameter = new SqlParameter("ProjectID", projectId);
            SqlParameter refIdParameter = new SqlParameter("RefID", refId);
            SqlParameter subjectParameter = (subject.Trim() != "") ? new SqlParameter("Subject", subject.Trim()) : new SqlParameter("Subject", DBNull.Value);
            SqlParameter loginIdParameter = new SqlParameter("LoginID", loginId);
            SqlParameter dateTimeParameter = new SqlParameter("DateTime", dateTime);
            SqlParameter noteParameter = (note.Trim() != "") ? new SqlParameter("Note", note.Trim()) : new SqlParameter("Note", DBNull.Value);
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            SqlParameter libraryFilesIdParameter = (libraryFilesId.HasValue) ? new SqlParameter("LIBRARY_FILES_ID", libraryFilesId) : new SqlParameter("LIBRARY_FILES_ID", DBNull.Value); 

            string command = "INSERT INTO [dbo].[LFS_PROJECT_NOTE] ([ProjectID], [RefID], [Subject], [DateTime], [LoginID],  "+
                " [Note], [Deleted], [LIBRARY_FILES_ID], [COMPANY_ID]) VALUES (@ProjectID, @RefID, @Subject, @DateTime, @LoginID, "+
                " @Note, @Deleted, @LIBRARY_FILES_ID, @COMPANY_ID)";

            int rowsAffected = (int)ExecuteNonQuery(command, projectIdParameter, refIdParameter, subjectParameter, loginIdParameter, dateTimeParameter, noteParameter, deletedParameter, companyIdParameter, libraryFilesIdParameter);

            return rowsAffected;
        }



        /// <summary>
        /// Update service note (direct to DB)
        /// </summary>
        /// <param name="originalProjectId">originalProjectId</param>
        /// <param name="originalRefId">originalRefId</param>
        /// <param name="originalSubject">originalSubject</param>
        /// <param name="originalLoginId">originalLoginId</param>
        /// <param name="originalDateTime_">originalDateTime_</param>
        /// <param name="originalNote">originalNote</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalLIBRARY_FILES_ID">originalLIBRARY_FILES_ID</param>

        /// <param name="newProjectId">newProjectId</param>
        /// <param name="newRefId">newRefId</param>
        /// <param name="newSubject">newSubject</param>
        /// <param name="newLoginId">newLoginId</param>
        /// <param name="newDateTime">newDateTime</param>
        /// <param name="newNote">newNote</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newLIBRARY_FILES_ID">newLIBRARY_FILES_ID</param>
        /// <returns>rowsAffected</returns>
        public int Update(int originalProjectId, int originalRefId, string originalSubject, int originalLoginId, DateTime originalDateTime, string originalNote, bool originalDeleted, int originalCompanyId, int? originalLIBRARY_FILES_ID, int newProjectId, int newRefId, string newSubject, int newLoginId, DateTime newDateTime, string newNote, bool newDeleted, int newCompanyId, int? newLIBRARY_FILES_ID)
        {
            SqlParameter originalProjectIdParameter = new SqlParameter("Original_ProjectID", originalProjectId);
            SqlParameter originalRefIdParameter = new SqlParameter("Original_RefID", originalRefId);
            SqlParameter originalSubjectParameter = new SqlParameter("Original_Subject", originalSubject);
            SqlParameter originalLoginIdParameter = new SqlParameter("Original_LoginID", originalLoginId);
            SqlParameter originalDateTimeParameter = new SqlParameter("Original_DateTime", originalDateTime);
            SqlParameter originalNoteParameter = new SqlParameter("Original_Note", originalNote);
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter originalLibraryFilesIdParameter = (originalLIBRARY_FILES_ID.HasValue) ? new SqlParameter("Original_LIBRARY_FILES_ID", originalLIBRARY_FILES_ID) : new SqlParameter("Original_LIBRARY_FILES_ID", DBNull.Value);             

            SqlParameter newProjectIdParameter = new SqlParameter("ProjectID", newProjectId);
            SqlParameter newRefIdParameter = new SqlParameter("RefID", originalRefId);
            SqlParameter newSubjectParameter = (newSubject.Trim() != "") ? new SqlParameter("Subject", newSubject.Trim()) : new SqlParameter("Subject", DBNull.Value);
            SqlParameter newLoginIdParameter = new SqlParameter("LoginID", newLoginId);
            SqlParameter newDateTimeParameter = new SqlParameter("DateTime", newDateTime);
            SqlParameter newNoteParameter = (newNote.Trim() != "") ? new SqlParameter("Note", newNote.Trim()) : new SqlParameter("Note", DBNull.Value);
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);
            SqlParameter newLibraryFilesIdParameter = (newLIBRARY_FILES_ID.HasValue) ? new SqlParameter("LIBRARY_FILES_ID", newLIBRARY_FILES_ID) : new SqlParameter("LIBRARY_FILES_ID", DBNull.Value); 

            string command = "UPDATE [dbo].[LFS_PROJECT_NOTE] SET "+
                " [Subject] = @Subject, [Note] = @Note, "+
                " [LIBRARY_FILES_ID] = @LIBRARY_FILES_ID "+
                " WHERE (([ProjectID] = @Original_ProjectID) AND ([RefID] = @Original_RefID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalProjectIdParameter, originalRefIdParameter, originalSubjectParameter, originalLoginIdParameter, originalDateTimeParameter, originalNoteParameter, originalDeletedParameter, originalCompanyIdParameter, originalLibraryFilesIdParameter, newProjectIdParameter, newRefIdParameter, newSubjectParameter, newLoginIdParameter, newDateTimeParameter, newNoteParameter, newDeletedParameter, newCompanyIdParameter, newLibraryFilesIdParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }



        /// <summary>
        /// Delete a note (direct to DB)
        /// </summary>
        /// <param name="originalProjectId">originalProjectId</param>
        /// <param name="originalRefId">originalRefId</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <returns>int</returns>
        public int Delete(int originalProjectId, int originalRefId, int originalCompanyId)
        {
            SqlParameter originalProjectIdParameter = new SqlParameter("@Original_ProjectID", originalProjectId);
            SqlParameter originalRefIdParameter = new SqlParameter("@Original_RefID", originalRefId);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_PROJECT_NOTE] SET  [Deleted] = @Deleted  " +
                             " WHERE (([ProjectID] = @Original_ProjectID) AND ([RefID] = @Original_RefID) AND " +
                             "  ([COMPANY_ID] = @Original_COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalProjectIdParameter, originalRefIdParameter, originalCompanyIdParameter, deletedParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }




    }
}

