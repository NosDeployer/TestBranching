using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Resources.Materials
{
    /// <summary>
    /// MaterialsNotesGateway
    /// </summary>
    public class MaterialsNotesGateway: DataTableGateway
    {
        ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public MaterialsNotesGateway()
            : base("LFS_RESOURCES_MATERIAL_NOTES")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public MaterialsNotesGateway(DataSet data)
            : base(data, "LFS_RESOURCES_MATERIAL_NOTES")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new MaterialsTDS();
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
            tableMapping.DataSetTable = "LFS_RESOURCES_MATERIAL_NOTES";
            tableMapping.ColumnMappings.Add("MaterialID", "MaterialID");
            tableMapping.ColumnMappings.Add("RefID", "RefID");
            tableMapping.ColumnMappings.Add("Subject", "Subject");
            tableMapping.ColumnMappings.Add("UserID", "UserID");
            tableMapping.ColumnMappings.Add("DateTime_", "DateTime_");
            tableMapping.ColumnMappings.Add("Note", "Note");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = @"DELETE FROM [dbo].[LFS_RESOURCES_MATERIAL_NOTES] WHERE (([MaterialID] = @Original_MaterialID) AND ([RefID] = @Original_RefID) AND ([Subject] = @Original_Subject) AND ([UserID] = @Original_UserID) AND ([DateTime_] = @Original_DateTime_) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MaterialID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MaterialID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RefID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RefID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Subject", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Subject", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_UserID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UserID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DateTime_", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DateTime_", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_RESOURCES_MATERIAL_NOTES] ([MaterialID], [RefID], [Subject], [UserID], [DateTime_], [Note], [Deleted], [COMPANY_ID]) VALUES (@MaterialID, @RefID, @Subject, @UserID, @DateTime_, @Note, @Deleted, @COMPANY_ID);
SELECT MaterialID, RefID, Subject, UserID, DateTime_, Note, Deleted, COMPANY_ID FROM LFS_RESOURCES_MATERIAL_NOTES WHERE (MaterialID = @MaterialID) AND (RefID = @RefID)";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MaterialID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MaterialID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RefID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RefID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Subject", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Subject", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@UserID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UserID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DateTime_", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DateTime_", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Note", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Note", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));


            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = @"UPDATE [dbo].[LFS_RESOURCES_MATERIAL_NOTES] SET [MaterialID] = @MaterialID, [RefID] = @RefID, [Subject] = @Subject, [UserID] = @UserID, [DateTime_] = @DateTime_, [Note] = @Note, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID WHERE (([MaterialID] = @Original_MaterialID) AND ([RefID] = @Original_RefID) AND ([Subject] = @Original_Subject) AND ([UserID] = @Original_UserID) AND ([DateTime_] = @Original_DateTime_) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID));
SELECT MaterialID, RefID, Subject, UserID, DateTime_, Note, Deleted, COMPANY_ID FROM LFS_RESOURCES_MATERIAL_NOTES WHERE (MaterialID = @MaterialID) AND (RefID = @RefID)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MaterialID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MaterialID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RefID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RefID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Subject", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Subject", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@UserID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UserID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DateTime_", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DateTime_", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Note", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Note", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MaterialID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MaterialID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RefID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RefID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Subject", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Subject", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_UserID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UserID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DateTime_", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DateTime_", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            #endregion
        }

        



        
        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROWS
        //

        /// <summary>
        /// Insert a material note (direct to DB)
        /// </summary>
        /// <param name="materialId">materialId</param>
        /// <param name="refId">refId</param>
        /// <param name="subject">subject</param>
        /// <param name="userId">userId</param>
        /// <param name="dateTime_">dateTime_</param>
        /// <param name="note">note</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <returns>rowsAffected</returns>
        public int Insert(int materialId, int refId, string subject, int userId, DateTime dateTime_, string note,  bool deleted, int companyId)
        {
            SqlParameter materialIdParameter = new SqlParameter("MaterialID", materialId);
            SqlParameter refIdParameter = new SqlParameter("RefID", refId);
            SqlParameter subjectParameter = (subject.Trim() != "") ? new SqlParameter("Subject", subject.Trim()) : new SqlParameter("Subject", DBNull.Value);
            SqlParameter userIdParameter = new SqlParameter("UserID", userId);
            SqlParameter dateTime_Parameter = new SqlParameter("DateTime_", dateTime_);
            SqlParameter noteParameter = (note.Trim() != "") ? new SqlParameter("Note", note.Trim()) : new SqlParameter("Note", DBNull.Value);
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);

            string command = "INSERT INTO [dbo].[LFS_RESOURCES_MATERIAL_NOTES] ([MaterialID], [RefID], [Subject], [UserID], [DateTime_], [Note], [Deleted], [COMPANY_ID]) VALUES (@MaterialID, @RefID, @Subject, @UserID, @DateTime_, @Note, @Deleted, @COMPANY_ID)";

            int rowsAffected = (int)ExecuteNonQuery(command, materialIdParameter, refIdParameter, subjectParameter, userIdParameter, dateTime_Parameter, noteParameter, deletedParameter, companyIdParameter);

            return rowsAffected;
        }



        /// <summary>
        /// Update material note (direct to DB)
        /// </summary>
        /// <param name="originalMaterialId">originalMaterialId</param>
        /// <param name="originalRefId">originalRefId</param>
        /// <param name="originalSubject">originalSubject</param>
        /// <param name="originalUserId">originalUserId</param>
        /// <param name="originalDateTime_">originalDateTime_</param> 
        /// <param name="originalNote">originalNote</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>        

        /// <param name="newMaterialId">newMaterialId</param>
        /// <param name="newRefId">newRefId</param>
        /// <param name="newSubject">newSubject</param>
        /// <param name="newUserId">newUserId</param>
        /// <param name="newDateTime_">DateTime_</param>
        /// <param name="newNote">newNote</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <returns>rowsAffected</returns>
        public int Update(int originalMaterialId, int originalRefId, string originalSubject, int originalUserId, DateTime originalDateTime_, string originalNote, bool originalDeleted, int originalCompanyId, int newMaterialId, int newRefId, string newSubject, int newUserId,  DateTime newDateTime_, string newNote, bool newDeleted, int newCompanyId)
        {
            SqlParameter originalMaterialIdParameter = new SqlParameter("Original_MaterialID", originalMaterialId);
            SqlParameter originalRefIdParameter = new SqlParameter("Original_RefID", originalRefId);
            SqlParameter originalSubjectParameter = new SqlParameter("Original_Subject", originalSubject);
            SqlParameter originalUserIdParameter = new SqlParameter("Original_UserID", originalUserId);
            SqlParameter originalDateTime_Parameter = new SqlParameter("Original_DateTime_", originalDateTime_);
            SqlParameter originalNoteParameter = new SqlParameter("Original_Note", originalNote);
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);

            SqlParameter newMaterialIdParameter = new SqlParameter("MaterialID", newMaterialId);
            SqlParameter newRefIdParameter = new SqlParameter("RefID", originalRefId);
            SqlParameter newSubjectParameter = (newSubject.Trim() != "") ? new SqlParameter("Subject", newSubject.Trim()) : new SqlParameter("Subject", DBNull.Value);
            SqlParameter newUserIdParameter = new SqlParameter("UserID", newUserId);
            SqlParameter newDateTime_Parameter = new SqlParameter("DateTime_", newDateTime_);
            SqlParameter newNoteParameter = (newNote.Trim() != "") ? new SqlParameter("Note", newNote.Trim()) : new SqlParameter("Note", DBNull.Value);
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);

            string command = "UPDATE [dbo].[LFS_RESOURCES_MATERIAL_NOTES] SET [MaterialID] = @MaterialID, [RefID] = @RefID, " +
                " [Subject] = @Subject, [UserID] = @UserID, [DateTime_] = @DateTime_, [Note] = @Note, "+
                " [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID "+
                " WHERE (([MaterialID] = @Original_MaterialID) AND ([RefID] = @Original_RefID) "+
                " AND ([COMPANY_ID] = @Original_COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalMaterialIdParameter, originalRefIdParameter, originalSubjectParameter, originalUserIdParameter, originalDateTime_Parameter, originalNoteParameter, originalDeletedParameter, originalCompanyIdParameter, newMaterialIdParameter, newRefIdParameter, newSubjectParameter, newUserIdParameter, newDateTime_Parameter, newNoteParameter, newDeletedParameter, newCompanyIdParameter); 

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }


        
        /// <summary>
        /// Delete a material note (direct to DB)
        /// </summary>
        /// <param name="originalMaterialId">originalMaterialId</param>
        /// <param name="originalRefId">originalRefId</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <returns>int</returns>
        public int Delete(int originalMaterialId, int originalRefId, int originalCompanyId)
        {
            SqlParameter originalMaterialIdParameter = new SqlParameter("@Original_MaterialID", originalMaterialId);
            SqlParameter originalRefIdParameter = new SqlParameter("@Original_RefID", originalRefId);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_RESOURCES_MATERIAL_NOTES] SET  [Deleted] = @Deleted  " +
                             " WHERE (([MaterialID] = @Original_MaterialID) AND ([RefID] = @Original_RefID) AND " +
                             "  ([COMPANY_ID] = @Original_COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery( command, originalMaterialIdParameter, originalRefIdParameter, originalCompanyIdParameter, deletedParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }



        /// <summary>
        /// Delete all materials notes (direct to DB)
        /// </summary>
        /// <param name="originalMaterialId">originalMaterialId</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <returns>int</returns>
        public int DeleteAll(int originalMaterialId, int originalCompanyId)
        {
            SqlParameter originalMaterialIdParameter = new SqlParameter("@Original_MaterialID", originalMaterialId);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_RESOURCES_MATERIAL_NOTES] SET  [Deleted] = @Deleted  " +
                             " WHERE (([MaterialID] = @Original_MaterialID) AND  " +
                             "  ([COMPANY_ID] = @Original_COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalMaterialIdParameter, originalCompanyIdParameter, deletedParameter);

            return rowsAffected;
        }



    }
}

