using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.CWP.Works
{
    /// <summary>
    /// WorkCommentsGateway
    /// </summary>
    public class WorkCommentsGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkCommentsGateway()
            : base("LFS_WORK_COMMENT")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkCommentsGateway(DataSet data)
            : base(data, "LFS_WORK_COMMENT")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new WorkTDS();
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
            tableMapping.DataSetTable = "LFS_WORK_COMMENT";
            tableMapping.ColumnMappings.Add("WorkID", "WorkID");
            tableMapping.ColumnMappings.Add("RefID", "RefID");
            tableMapping.ColumnMappings.Add("Type", "Type");
            tableMapping.ColumnMappings.Add("Subject", "Subject");
            tableMapping.ColumnMappings.Add("UserID", "UserID");
            tableMapping.ColumnMappings.Add("DateTime_", "DateTime_");
            tableMapping.ColumnMappings.Add("Comment", "Comment");
            tableMapping.ColumnMappings.Add("LIBRARY_FILES_ID", "LIBRARY_FILES_ID");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("WorkType", "WorkType");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = @"DELETE FROM [dbo].[LFS_WORK_COMMENT] WHERE (([WorkID] = @Original_WorkID) AND ([RefID] = @Original_RefID) AND ((@IsNull_Type = 1 AND [Type] IS NULL) OR ([Type] = @Original_Type)) AND ([Subject] = @Original_Subject) AND ([UserID] = @Original_UserID) AND ((@IsNull_DateTime_ = 1 AND [DateTime_] IS NULL) OR ([DateTime_] = @Original_DateTime_)) AND ((@IsNull_LIBRARY_FILES_ID = 1 AND [LIBRARY_FILES_ID] IS NULL) OR ([LIBRARY_FILES_ID] = @Original_LIBRARY_FILES_ID)) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND ((@IsNull_WorkType = 1 AND [WorkType] IS NULL) OR ([WorkType] = @Original_WorkType)))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_WorkID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RefID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RefID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Type", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Type", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Type", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Type", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Subject", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Subject", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_UserID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UserID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DateTime_", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DateTime_", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DateTime_", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DateTime_", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_LIBRARY_FILES_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LIBRARY_FILES_ID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LIBRARY_FILES_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LIBRARY_FILES_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_WorkType", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkType", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_WorkType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkType", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_WORK_COMMENT] ([WorkID], [RefID], [Type], [Subject], [UserID], [DateTime_], [Comment], [LIBRARY_FILES_ID], [Deleted], [COMPANY_ID], [WorkType]) VALUES (@WorkID, @RefID, @Type, @Subject, @UserID, @DateTime_, @Comment, @LIBRARY_FILES_ID, @Deleted, @COMPANY_ID, @WorkType);
SELECT WorkID, RefID, Type, Subject, UserID, DateTime_, Comment, LIBRARY_FILES_ID, Deleted, COMPANY_ID, WorkType FROM LFS_WORK_COMMENT WHERE (RefID = @RefID) AND (WorkID = @WorkID)";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@WorkID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RefID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RefID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Type", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Type", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Subject", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Subject", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@UserID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UserID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DateTime_", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DateTime_", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Comment", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Comment", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LIBRARY_FILES_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LIBRARY_FILES_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@WorkType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkType", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));


            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = @"UPDATE [dbo].[LFS_WORK_COMMENT] SET [WorkID] = @WorkID, [RefID] = @RefID, [Type] = @Type, [Subject] = @Subject, [UserID] = @UserID, [DateTime_] = @DateTime_, [Comment] = @Comment, [LIBRARY_FILES_ID] = @LIBRARY_FILES_ID, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID, [WorkType] = @WorkType WHERE (([WorkID] = @Original_WorkID) AND ([RefID] = @Original_RefID) AND ((@IsNull_Type = 1 AND [Type] IS NULL) OR ([Type] = @Original_Type)) AND ([Subject] = @Original_Subject) AND ([UserID] = @Original_UserID) AND ((@IsNull_DateTime_ = 1 AND [DateTime_] IS NULL) OR ([DateTime_] = @Original_DateTime_)) AND ((@IsNull_LIBRARY_FILES_ID = 1 AND [LIBRARY_FILES_ID] IS NULL) OR ([LIBRARY_FILES_ID] = @Original_LIBRARY_FILES_ID)) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND ((@IsNull_WorkType = 1 AND [WorkType] IS NULL) OR ([WorkType] = @Original_WorkType)));
SELECT WorkID, RefID, Type, Subject, UserID, DateTime_, Comment, LIBRARY_FILES_ID, Deleted, COMPANY_ID, WorkType FROM LFS_WORK_COMMENT WHERE (RefID = @RefID) AND (WorkID = @WorkID)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@WorkID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RefID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RefID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Type", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Type", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Subject", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Subject", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@UserID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UserID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DateTime_", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DateTime_", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Comment", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Comment", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LIBRARY_FILES_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LIBRARY_FILES_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@WorkType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkType", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_WorkID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RefID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RefID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Type", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Type", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Type", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Type", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Subject", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Subject", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_UserID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UserID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DateTime_", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DateTime_", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DateTime_", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DateTime_", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_LIBRARY_FILES_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LIBRARY_FILES_ID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LIBRARY_FILES_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LIBRARY_FILES_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_WorkType", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkType", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_WorkType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkType", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// LoadAllByWorkIdWorkType
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="workType">workType</param>
        /// <returns>data set</returns>
        public DataSet LoadAllByWorkIdWorkType(int workId, int companyId, string workType)
        {
            FillDataWithStoredProcedure("LFS_CWP_WORKCOMMENTSGATEWAY_LOADALLBYWORKIDWORKTYPE", new SqlParameter("@workId", workId), new SqlParameter("@companyId", companyId), new SqlParameter("@workType", workType));
            return Data;
        }



        /// <summary>
        /// LoadByWorkIdWorkType
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="workType">workType</param>
        /// <returns>data set</returns>
        public DataSet LoadByWorkIdWorkType(int workId, int companyId, string workType)
        {
            FillDataWithStoredProcedure("LFS_CWP_WORKCOMMENTSGATEWAY_LOADBYWORKIDWORKTYPE", new SqlParameter("@workId", workId), new SqlParameter("@companyId", companyId), new SqlParameter("@workType", workType));
            return Data;
        }



        /// <summary>
        /// LoadByAssetIdWorkTypeProjectId
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="workType">workType</param>
        /// <param name="projectId">projectId</param>
        /// <returns>data set</returns>
        public DataSet LoadByAssetIdWorkTypeProjectId(int assetId, int companyId, string workType, int projectId)
        {
            FillDataWithStoredProcedure("LFS_CWP_WORKCOMMENTSGATEWAY_LOADBYASSETIDWORKTYPEPROJECTID", new SqlParameter("@assetId", assetId), new SqlParameter("@companyId", companyId), new SqlParameter("@workType", workType), new SqlParameter("@projectId", projectId));
            return Data;
        }



        /// <summary>
        /// LoadByAssetIdCommentTypeProjectId
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="commentType">commentType</param>
        /// <param name="projectId">projectId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadByAssetIdCommentTypeProjectId(int assetId, int companyId, string commentType, int projectId)
        {
            FillDataWithStoredProcedure("LFS_CWP_WORKCOMMENTSGATEWAY_LOADBYASSETIDCOMMENTTYPEPROJECTID", new SqlParameter("@assetId", assetId), new SqlParameter("@companyId", companyId), new SqlParameter("@commentType", commentType), new SqlParameter("@ProjectId", projectId));
            return Data;
        }



        /// <summary>
        /// Update
        /// </summary>
        public void Update()
        {
            DataTable tableChanges = Table.GetChanges();

            if (tableChanges == null) return;

            try
            {
                Adapter.InsertCommand.Transaction = DB.Transaction;
                Adapter.UpdateCommand.Transaction = DB.Transaction;
                Adapter.DeleteCommand.Transaction = DB.Transaction;

                if ((tableChanges != null) && (tableChanges.Rows.Count > 0))
                {
                    Adapter.Update(tableChanges);
                }
            }
            catch (DBConcurrencyException dBConcurrencyException)
            {
                throw new Exception("Concurrency error: Another user already updated the data you are working on.  Your operation has been cancelled.", dBConcurrencyException);
            }
            catch (SqlException sqlException)
            {
                byte severityLevel = sqlException.Class;
                if (severityLevel <= 16)
                {
                    throw new Exception("Low severity error. Your operation has been cancelled.  SQL Error " + severityLevel + ".");
                }
                if ((severityLevel >= 17) && (severityLevel <= 19))
                {
                    throw new Exception("Mid severity error. Your operation has been cancelled.  SQL Error " + severityLevel + ".");
                }
                if (severityLevel >= 20)
                {
                    throw new Exception("High severity error. Your operation has been cancelled.  SQL Error " + severityLevel + ".");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Unknow error. Your operation has been cancelled.", e);
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROW
        //

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <param name="type">type</param>
        /// <param name="subject">subject</param>
        /// <param name="userId">userId</param>
        /// <param name="dateTime_">dateTime_</param>
        /// <param name="comment">comment</param>
        /// <param name="libraryFilesId">libraryFilesId</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="workType">workType</param>
        /// <returns></returns>
        public int Insert(int workId, int refId, string type, string subject, int userId, DateTime? dateTime_, string comment, int? libraryFilesId, bool deleted, int companyId, string workType)
        {
            SqlParameter workIdParameter = new SqlParameter("WorkID", workId);
            SqlParameter refIdParameter = new SqlParameter("RefID", refId);
            SqlParameter typeParameter = (type.Trim() != "") ? new SqlParameter("Type", type.Trim()) : new SqlParameter("Type", DBNull.Value);
            SqlParameter subjectParameter = (subject.Trim() != "") ? new SqlParameter("Subject", subject.Trim()) : new SqlParameter("Subject", DBNull.Value);
            SqlParameter userIdParameter = (userId.ToString().Trim() != "") ? new SqlParameter("UserID", userId.ToString().Trim()) : new SqlParameter("UserID", DBNull.Value);
            SqlParameter dateTimeParameter = (dateTime_.ToString().Trim() != "") ? new SqlParameter("DateTime_", dateTime_.ToString().Trim()) : new SqlParameter("DateTime_", DBNull.Value);
            SqlParameter commentParameter = (comment.Trim() != "") ? new SqlParameter("Comment", comment.Trim()) : new SqlParameter("Comment", DBNull.Value);
            SqlParameter libraryFilesIdParameter = (libraryFilesId.HasValue) ? new SqlParameter("LIBRARY_FILES_ID", libraryFilesId) : new SqlParameter("LIBRARY_FILES_ID", DBNull.Value);
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            SqlParameter workTypeParameter = (workType.Trim() != "") ? new SqlParameter("WorkType", workType.Trim()) : new SqlParameter("WorkType", DBNull.Value);

            string command = "INSERT INTO [dbo].[LFS_WORK_COMMENT] ([WorkID], [RefID], [Type], [Subject], [UserID], [DateTime_], [Comment], [LIBRARY_FILES_ID], [Deleted], [COMPANY_ID], [WorkType]) VALUES (@WorkID, @RefID, @Type, @Subject, @UserID, @DateTime_, @Comment, @LIBRARY_FILES_ID, @Deleted, @COMPANY_ID, @WorkType)";

            int rowsAffected = (int)ExecuteNonQuery(command, workIdParameter, refIdParameter, typeParameter, subjectParameter, userIdParameter, dateTimeParameter, commentParameter, libraryFilesIdParameter, deletedParameter, companyIdParameter, workTypeParameter);

            return rowsAffected;
        }



        /// <summary>
        /// Update direct
        /// </summary>
        /// <param name="originalWorkId">originalWorkId</param>
        /// <param name="originalRefId">originalRefId</param>
        /// <param name="originalType">originalType</param>
        /// <param name="originalSubject">originalSubject</param>
        /// <param name="originalUserId">originalUserId</param>
        /// <param name="originalDateTime">originalDateTime</param>
        /// <param name="originalComment">originalComment</param>
        /// <param name="originalLibraryFilesId">originalLibraryFilesId</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalWorkType">originalWorkType</param>
        /// 
        /// <param name="newWorkId">newWorkId</param>
        /// <param name="newRefId">newRefId</param>
        /// <param name="newType">newType</param>
        /// <param name="newSubject">newSubject</param>
        /// <param name="newUserId">newUserId</param>
        /// <param name="newDateTime">newDateTime</param>
        /// <param name="newComment">newComment</param>
        /// <param name="newLibraryFilesId">newLibraryFilesId</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newWorkType">newWorkType</param>
        public int Update(int originalWorkId, int originalRefId, string originalType, string originalSubject, int originalUserId, DateTime? originalDateTime, string originalComment, int? originalLibraryFilesId, bool originalDeleted, int originalCompanyId, string originalWorkType, int newWorkId, int newRefId, string newType, string newSubject, int newUserId, DateTime? newDateTime, string newComment, int? newLibraryFilesId, bool newDeleted, int newCompanyId, string newWorkType)
        {
            SqlParameter originalWorkIdParameter = new SqlParameter("Original_WorkID", originalWorkId);
            SqlParameter originalRefIdParameter = new SqlParameter("Original_RefID", originalRefId);
            SqlParameter originalTypeParameter = (originalType.Trim() != "") ? new SqlParameter("Original_Type", originalType.Trim()) : new SqlParameter("Original_Type", DBNull.Value);
            SqlParameter originalSubjectParameter = (originalSubject.Trim() != "") ? new SqlParameter("Original_Subject", originalSubject.Trim()) : new SqlParameter("Original_Subject", DBNull.Value);
            SqlParameter originalUserIdParameter = (originalUserId.ToString().Trim() != "") ? new SqlParameter("Original_UserID", originalUserId.ToString().Trim()) : new SqlParameter("Original_UserID", DBNull.Value);
            SqlParameter originalDateTimeParameter = (originalDateTime.ToString().Trim() != "") ? new SqlParameter("Original_DateTime_", originalDateTime.ToString().Trim()) : new SqlParameter("Original_DateTime_", DBNull.Value);
            SqlParameter originalCommentParameter = (originalComment.Trim() != "") ? new SqlParameter("Original_Comment", originalComment.Trim()) : new SqlParameter("Original_Comment", DBNull.Value);
            SqlParameter originalLibraryFilesIdParameter = (originalLibraryFilesId.HasValue) ? new SqlParameter("Original_LIBRARY_FILES_ID", originalLibraryFilesId) : new SqlParameter("Original_LIBRARY_FILES_ID", DBNull.Value);
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter originalWorkTypeParameter = (originalWorkType.Trim() != "") ? new SqlParameter("Original_WorkType", originalWorkType.Trim()) : new SqlParameter("Original_WorkType", DBNull.Value);

            SqlParameter newWorkIdParameter = new SqlParameter("WorkID", newWorkId);
            SqlParameter newRefIdParameter = new SqlParameter("RefID", newRefId);
            SqlParameter newTypeParameter = (newType.Trim() != "") ? new SqlParameter("Type", newType.Trim()) : new SqlParameter("Type", DBNull.Value);
            SqlParameter newSubjectParameter = (newSubject.Trim() != "") ? new SqlParameter("Subject", newSubject.Trim()) : new SqlParameter("Subject", DBNull.Value);
            SqlParameter newUserIdParameter = (newUserId.ToString().Trim() != "") ? new SqlParameter("UserID", newUserId.ToString().Trim()) : new SqlParameter("UserID", DBNull.Value);
            SqlParameter newDateTimeParameter = (newDateTime.ToString().Trim() != "") ? new SqlParameter("DateTime_", newDateTime.ToString().Trim()) : new SqlParameter("DateTime_", DBNull.Value);
            SqlParameter newCommentParameter = (newComment.Trim() != "") ? new SqlParameter("Comment", newComment.Trim()) : new SqlParameter("Comment", DBNull.Value);
            SqlParameter newLibraryFilesIdParameter = (newLibraryFilesId.HasValue) ? new SqlParameter("LIBRARY_FILES_ID", newLibraryFilesId) : new SqlParameter("LIBRARY_FILES_ID", DBNull.Value);
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);
            SqlParameter newWorkTypeParameter = (newWorkType.Trim() != "") ? new SqlParameter("WorkType", newWorkType.Trim()) : new SqlParameter("WorkType", DBNull.Value);

            string command = "UPDATE [dbo].[LFS_WORK_COMMENT] " +
                " SET [Subject] = @Subject,  [Type] = @Type, " +
                " [Comment] = @Comment, [LIBRARY_FILES_ID] = @LIBRARY_FILES_ID, [WorkType] = @WorkType " +
                " WHERE (([WorkID] = @Original_WorkID) AND ([RefID] = @Original_RefID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalWorkIdParameter, originalRefIdParameter, originalTypeParameter, originalSubjectParameter, originalUserIdParameter, originalDateTimeParameter, originalCommentParameter, originalLibraryFilesIdParameter, originalDeletedParameter, originalCompanyIdParameter, originalWorkTypeParameter, newWorkIdParameter, newRefIdParameter, newTypeParameter, newSubjectParameter, newUserIdParameter, newDateTimeParameter, newCommentParameter, newLibraryFilesIdParameter, newDeletedParameter, newCompanyIdParameter, newWorkTypeParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="originalWorkId">originalWorkId</param>
        /// <param name="originalRefId">originalRefId</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <returns>int</returns>
        public int Delete(int originalWorkId, int originalRefId, int originalCompanyId)
        {
            SqlParameter originalWorkIdParameter = new SqlParameter("@Original_WorkID", originalWorkId);
            SqlParameter originalRefIdParameter = new SqlParameter("Original_RefID", originalRefId);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_WORK_COMMENT] SET  [Deleted] = @Deleted  " +
                " WHERE (([WorkID] = @Original_WorkID) AND " +
                " ([RefID] = @Original_RefID) AND " +
                " ([COMPANY_ID] = @Original_COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalWorkIdParameter, originalRefIdParameter, originalCompanyIdParameter, deletedParameter);

            return rowsAffected;
        }



        /// <summary>
        /// DeleteAll
        /// </summary>
        /// <param name="originalWorkId">originalWorkId</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <returns>int</returns>
        public int DeleteAll(int originalWorkId, int originalCompanyId)
        {
            SqlParameter originalWorkIdParameter = new SqlParameter("@Original_WorkID", originalWorkId);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_WORK_COMMENT] SET  [Deleted] = @Deleted  WHERE (([WorkID] = @Original_WorkID) AND " +
            " ([COMPANY_ID] = @Original_COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalWorkIdParameter, originalCompanyIdParameter, deletedParameter);

            return rowsAffected;
        }



    }
}