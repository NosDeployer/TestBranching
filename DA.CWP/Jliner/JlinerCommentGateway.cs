using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.DA.CWP.Section;
using LiquiForce.LFSLive.DA.RAF;

namespace LiquiForce.LFSLive.DA.CWP.Jliner
{
    /// <summary>
    /// JlinerCommentGateway
    /// </summary>
    public class JlinerCommentGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public JlinerCommentGateway()
            : base("LFS_JUNCTION_LINER2_COMMENT")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public JlinerCommentGateway(DataSet data)
            : base(data, "LFS_JUNCTION_LINER2_COMMENT")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new SectionTDS();
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
            tableMapping.DataSetTable = "LFS_JUNCTION_LINER2_COMMENT";
            tableMapping.ColumnMappings.Add("ID", "ID");
            tableMapping.ColumnMappings.Add("RefID", "RefID");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("CommentID", "CommentID");
            tableMapping.ColumnMappings.Add("DateTime_", "DateTime_");
            tableMapping.ColumnMappings.Add("LoginID", "LoginID");
            tableMapping.ColumnMappings.Add("Comment", "Comment");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = @"DELETE FROM [dbo].[LFS_JUNCTION_LINER2_COMMENT] WHERE (([ID] = @Original_ID) AND ([RefID] = @Original_RefID) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND ([CommentID] = @Original_CommentID) AND ([DateTime_] = @Original_DateTime_) AND ([LoginID] = @Original_LoginID) AND ([Deleted] = @Original_Deleted))";
            this._adapter.DeleteCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, 0, 0, "ID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RefID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "RefID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CommentID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "CommentID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DateTime_", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "DateTime_", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LoginID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LoginID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Deleted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_JUNCTION_LINER2_COMMENT] ([ID], [RefID], [COMPANY_ID], [CommentID], [DateTime_], [LoginID], [Comment], [Deleted]) VALUES (@ID, @RefID, @COMPANY_ID, @CommentID, @DateTime_, @LoginID, @Comment, @Deleted);
SELECT ID, RefID, COMPANY_ID, CommentID, DateTime_, LoginID, Comment, Deleted FROM LFS_JUNCTION_LINER2_COMMENT WHERE (COMPANY_ID = @COMPANY_ID) AND (CommentID = @CommentID) AND (ID = @ID) AND (RefID = @RefID)";
            this._adapter.InsertCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, 0, 0, "ID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RefID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "RefID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CommentID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "CommentID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DateTime_", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "DateTime_", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LoginID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LoginID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Comment", System.Data.SqlDbType.NText, 0, System.Data.ParameterDirection.Input, 0, 0, "Comment", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Deleted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Current, false, null, "", "", ""));

            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = @"UPDATE [dbo].[LFS_JUNCTION_LINER2_COMMENT] SET [ID] = @ID, [RefID] = @RefID, [COMPANY_ID] = @COMPANY_ID, [CommentID] = @CommentID, [DateTime_] = @DateTime_, [LoginID] = @LoginID, [Comment] = @Comment, [Deleted] = @Deleted WHERE (([ID] = @Original_ID) AND ([RefID] = @Original_RefID) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND ([CommentID] = @Original_CommentID) AND ([DateTime_] = @Original_DateTime_) AND ([LoginID] = @Original_LoginID) AND ([Deleted] = @Original_Deleted));
SELECT ID, RefID, COMPANY_ID, CommentID, DateTime_, LoginID, Comment, Deleted FROM LFS_JUNCTION_LINER2_COMMENT WHERE (COMPANY_ID = @COMPANY_ID) AND (CommentID = @CommentID) AND (ID = @ID) AND (RefID = @RefID)";
            this._adapter.UpdateCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, 0, 0, "ID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RefID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "RefID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CommentID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "CommentID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DateTime_", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "DateTime_", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LoginID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LoginID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Comment", System.Data.SqlDbType.NText, 0, System.Data.ParameterDirection.Input, 0, 0, "Comment", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Deleted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, 0, 0, "ID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RefID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "RefID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CommentID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "CommentID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DateTime_", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "DateTime_", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LoginID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LoginID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Deleted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Original, false, null, "", "", ""));

            #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATSET
        //

        /// <summary>
        /// LoadById
        /// </summary>
        /// <param name="id">GUID ID</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>
        public DataSet LoadById(Guid id, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_JLINERCOMMENTGATEWAY_LOADBYID", new SqlParameter("@id", id), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByIdRefId
        /// </summary>
        /// <param name="id">GUID ID</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>
        public DataSet LoadByIdRefId(Guid id, int refId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_JLINERCOMMENTGATEWAY_LOADBYIDREFID", new SqlParameter("@id", id), new SqlParameter("@refId", refId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadAllByIdRefId
        /// </summary>
        /// <param name="id">GUID ID</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>
        public DataSet LoadAllByIdRefId(Guid id, int refId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_JLINERCOMMENTGATEWAY_LOADALLBYIDREFID", new SqlParameter("@id", id), new SqlParameter("@refId", refId), new SqlParameter("@companyId", companyId));
            return Data;
        }

        
               


        
        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROW
        //

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="commentId">commentId</param>
        /// <param name="dateTime_">dateTime_</param>
        /// <param name="loginId">loginId</param>
        /// <param name="comment">comment</param>        
        /// <param name="deleted">deleted</param>        
        /// <returns></returns>
        public int Insert(Guid id, int refId, int companyId, int commentId, DateTime? dateTime_, int loginId, string comment, bool deleted)
        {
            SqlParameter idParameter = new SqlParameter("ID", id);
            SqlParameter refIdParameter = new SqlParameter("RefID", refId);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            SqlParameter commentIdParameter = new SqlParameter("CommentID", commentId);
            SqlParameter dateTimeParameter = (dateTime_.ToString().Trim() != "") ? new SqlParameter("DateTime_", dateTime_.ToString().Trim()) : new SqlParameter("DateTime_", DBNull.Value);
            SqlParameter loginIdParameter = (loginId.ToString().Trim() != "") ? new SqlParameter("LoginID", loginId.ToString().Trim()) : new SqlParameter("LoginID", DBNull.Value);
            SqlParameter commentParameter = (comment.Trim() != "") ? new SqlParameter("Comment", comment.Trim()) : new SqlParameter("Comment", DBNull.Value);            
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            
            string command = "INSERT INTO [dbo].[LFS_JUNCTION_LINER2_COMMENT] ([ID], [RefID], [COMPANY_ID], [CommentID], "+
                " [DateTime_], [LoginID], [Comment], [Deleted]) "+
                " VALUES (@ID, @RefID, @COMPANY_ID, @CommentID, @DateTime_, @LoginID, @Comment, @Deleted)";

            int rowsAffected = (int)ExecuteNonQuery(command, idParameter, refIdParameter, companyIdParameter, commentIdParameter, loginIdParameter, dateTimeParameter, commentParameter, deletedParameter);

            return rowsAffected;
        }



        /// <summary>
        /// Update direct
        /// </summary>
        /// <param name="originalId">originalId</param>
        /// <param name="originalRefId">originalRefId</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalCommentId">originalCommentId</param>
        /// <param name="originalDateTime">originalDateTime</param>
        /// <param name="originalLoginId">originalLoginId</param>        
        /// <param name="originalComment">originalComment</param>        
        /// <param name="originalDeleted">originalDeleted</param>
        ///
        /// <param name="newId">newId</param>
        /// <param name="newRefId">newRefId</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newCommentId">newCommentId</param>
        /// <param name="newDateTime">newDateTime</param>
        /// <param name="newLoginId">newLoginId</param>                                
        /// <param name="newComment">newComment</param>       
        /// <param name="newDeleted">newDeleted</param>
        public int Update(Guid originalId, int originalRefId, int originalCompanyId, int originalCommentId, DateTime? originalDateTime, int originalLoginId, string originalComment, bool originalDeleted, Guid newId, int newRefId, int newCompanyId, int newCommentId, DateTime? newDateTime, int newLoginId, string newComment, bool newDeleted)
        {
            SqlParameter originalIdParameter = new SqlParameter("Original_ID", originalId);
            SqlParameter originalRefIdParameter = new SqlParameter("Original_RefID", originalRefId);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter originalCommentIdParameter = new SqlParameter("Original_CommentID", originalCommentId);
            SqlParameter originalDateTimeParameter = (originalDateTime.ToString().Trim() != "") ? new SqlParameter("Original_DateTime_", originalDateTime.ToString().Trim()) : new SqlParameter("Original_DateTime_", DBNull.Value);
            SqlParameter originalLoginIdParameter = (originalLoginId.ToString().Trim() != "") ? new SqlParameter("Original_LoginID", originalLoginId.ToString().Trim()) : new SqlParameter("Original_LoginID", DBNull.Value);                                   
            SqlParameter originalCommentParameter = (originalComment.Trim() != "") ? new SqlParameter("Original_Comment", originalComment.Trim()) : new SqlParameter("Original_Comment", DBNull.Value);
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);
            
            SqlParameter newIdParameter = new SqlParameter("ID", newId);
            SqlParameter newRefIdParameter = new SqlParameter("RefID", newRefId);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);
            SqlParameter newCommentIdParameter = new SqlParameter("CommentID", newCommentId);
            SqlParameter newDateTimeParameter = (newDateTime.ToString().Trim() != "") ? new SqlParameter("DateTime_", newDateTime.ToString().Trim()) : new SqlParameter("DateTime_", DBNull.Value);            
            SqlParameter newLoginIdParameter = (newLoginId.ToString().Trim() != "") ? new SqlParameter("LoginID", newLoginId.ToString().Trim()) : new SqlParameter("LoginID", DBNull.Value);            
            SqlParameter newCommentParameter = (newComment.Trim() != "") ? new SqlParameter("Comment", newComment.Trim()) : new SqlParameter("Comment", DBNull.Value);            
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);


            string command = "UPDATE [dbo].[LFS_JUNCTION_LINER2_COMMENT] " +
                " SET [Comment] = @Comment " +
                " WHERE (([ID] = @Original_ID) AND ([RefID] = @Original_RefID) AND ([COMPANY_ID] = @Original_COMPANY_ID) " +
                " AND ([CommentID] = @Original_CommentID) )";

            int rowsAffected = (int)ExecuteNonQuery(command, originalIdParameter, originalRefIdParameter, originalCompanyIdParameter, originalCommentIdParameter, originalDateTimeParameter, originalLoginIdParameter, originalCommentParameter, originalDeletedParameter, newIdParameter, newRefIdParameter, newCompanyIdParameter, newCommentIdParameter, newDateTimeParameter, newLoginIdParameter, newCommentParameter,  newDeletedParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="originalId">originalId</param>
        /// <param name="originalRefId">originalRefId</param>        
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalCommentId">originalCommentId</param>
        /// <returns>int</returns>
        public int Delete(Guid originalId, int originalRefId, int originalCompanyId, int originalCommentId)
        {
            SqlParameter originalIdParameter = new SqlParameter("@Original_ID", originalId);
            SqlParameter originalRefIdParameter = new SqlParameter("@Original_RefID", originalRefId);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter originalCommentIdParameter = new SqlParameter("@Original_CommentID", originalCommentId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_JUNCTION_LINER2_COMMENT] SET  [Deleted] = @Deleted  " +
                " WHERE (([ID] = @Original_ID) AND ([RefID] = @Original_RefID) AND " +
                " ([CommentID] = @Original_CommentID) AND ([COMPANY_ID] = @Original_COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalIdParameter, originalRefIdParameter, originalCompanyIdParameter, originalCommentIdParameter, deletedParameter);

            return rowsAffected;
        }



        /// <summary>
        /// DeleteAll
        /// </summary>
        /// <param name="originalId">originalId</param>
        /// <param name="originalRefId">originalRefId</param>        
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <returns>int</returns>
        public int DeleteAll(Guid originalId, int originalRefId, int originalCompanyId)
        {
            SqlParameter originalIdParameter = new SqlParameter("@Original_ID", originalId);
            SqlParameter originalRefIdParameter = new SqlParameter("@Original_RefID", originalRefId);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_JUNCTION_LINER2_COMMENT] SET  [Deleted] = @Deleted  "+
                " WHERE (([ID] = @Original_ID) AND ([RefID] = @Original_RefID) AND " +
                " ([COMPANY_ID] = @Original_COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalIdParameter, originalRefIdParameter, originalCompanyIdParameter, deletedParameter);

            return rowsAffected;
        }
    }
}
