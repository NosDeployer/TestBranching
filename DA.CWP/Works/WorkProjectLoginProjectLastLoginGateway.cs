using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.Works
{
    /// <summary>
    /// ProjectLoginProjectLastLoginGateway
    /// </summary>
    public class WorkProjectLoginProjectLastLoginGateway: DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkProjectLoginProjectLastLoginGateway()
            : base("LFS_WORK_PROJECT_LASTLOGIN")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkProjectLoginProjectLastLoginGateway(DataSet data)
            : base(data, "LFS_WORK_PROJECT_LASTLOGIN")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new WorkProjectLoginTDS();
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
            tableMapping.DataSetTable = "LFS_WORK_PROJECT_LASTLOGIN";
            tableMapping.ColumnMappings.Add("ProjectID", "ProjectID");
            tableMapping.ColumnMappings.Add("ClientID", "ClientID");
            tableMapping.ColumnMappings.Add("UserID", "UserID");
            tableMapping.ColumnMappings.Add("LastLoggedInDate", "LastLoggedInDate");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("WorkType", "WorkType");

            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = @"DELETE FROM [dbo].[LFS_WORK_PROJECT_LASTLOGIN] WHERE (([ProjectID] = @Original_ProjectID) AND ([ClientID] = @Original_ClientID) AND ([UserID] = @Original_UserID) AND ([LastLoggedInDate] = @Original_LastLoggedInDate) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND ([Deleted] = @Original_Deleted) AND ([WorkType] = @Original_WorkType))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ProjectID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ClientID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ClientID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_UserID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UserID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LastLoggedInDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LastLoggedInDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_WorkType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkType", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_WORK_PROJECT_LASTLOGIN] ([ProjectID], [ClientID], [UserID], [LastLoggedInDate], [COMPANY_ID], [Deleted], [WorkType]) VALUES (@ProjectID, @ClientID, @UserID, @LastLoggedInDate, @COMPANY_ID, @Deleted, @WorkType);
SELECT ProjectID, ClientID, UserID, LastLoggedInDate, COMPANY_ID, Deleted, WorkType FROM LFS_WORK_PROJECT_LASTLOGIN WHERE (COMPANY_ID = @COMPANY_ID) AND (ClientID = @ClientID) AND (LastLoggedInDate = @LastLoggedInDate) AND (ProjectID = @ProjectID) AND (UserID = @UserID) AND (WorkType = @WorkType)";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ProjectID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ClientID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ClientID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@UserID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UserID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LastLoggedInDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LastLoggedInDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@WorkType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkType", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            
            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = @"UPDATE [dbo].[LFS_WORK_PROJECT_LASTLOGIN] SET [ProjectID] = @ProjectID, [ClientID] = @ClientID, [UserID] = @UserID, [LastLoggedInDate] = @LastLoggedInDate, [COMPANY_ID] = @COMPANY_ID, [Deleted] = @Deleted, [WorkType] = @WorkType WHERE (([ProjectID] = @Original_ProjectID) AND ([ClientID] = @Original_ClientID) AND ([UserID] = @Original_UserID) AND ([LastLoggedInDate] = @Original_LastLoggedInDate) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND ([Deleted] = @Original_Deleted) AND ([WorkType] = @Original_WorkType));
SELECT ProjectID, ClientID, UserID, LastLoggedInDate, COMPANY_ID, Deleted, WorkType FROM LFS_WORK_PROJECT_LASTLOGIN WHERE (COMPANY_ID = @COMPANY_ID) AND (ClientID = @ClientID) AND (LastLoggedInDate = @LastLoggedInDate) AND (ProjectID = @ProjectID) AND (UserID = @UserID) AND (WorkType = @WorkType)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ProjectID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ClientID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ClientID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@UserID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UserID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LastLoggedInDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LastLoggedInDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@WorkType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkType", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ProjectID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ClientID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ClientID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_UserID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UserID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LastLoggedInDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LastLoggedInDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_WorkType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkType", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROWS
        //

        /// <summary>
        /// Insert a project login
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="clientId">clientId</param>
        /// <param name="userId">userId</param>
        /// <param name="lastLoggedInDate">lastLoggedInDate</param>
        /// <param name="companyId">companyId</param>        
        /// <param name="deleted">deleted</param>
        /// <param name="workType"> workType</param>
        /// <returns>workId</returns>
        public int Insert(int projectId, int clientId, int userId, DateTime lastLoggedInDate, int companyId,  bool deleted, string workType)
        {
            SqlParameter projectIdParameter = new SqlParameter("ProjectID", projectId);
            SqlParameter clientIdParameter = new SqlParameter("ClientID", clientId);
            SqlParameter userIdParameter = new SqlParameter("UserID", userId);
            SqlParameter lastLoggedInDateParameter = new SqlParameter("LastLoggedInDate", lastLoggedInDate);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter workTypeParameter = new SqlParameter("WorkType", workType);

            string command = "INSERT INTO [dbo].[LFS_WORK_PROJECT_LASTLOGIN] ([ProjectID], [ClientID], [UserID], "+
            " [LastLoggedInDate], [COMPANY_ID], [Deleted], [WorkType]) "+
            " VALUES (@ProjectID, @ClientID, @UserID, @LastLoggedInDate, @COMPANY_ID, @Deleted, @WorkType)";

            int rowsAffected = (int)ExecuteNonQuery(command, projectIdParameter, clientIdParameter, userIdParameter, lastLoggedInDateParameter, companyIdParameter, deletedParameter, workTypeParameter);

            return rowsAffected;
        }



        /// <summary>
        /// Update logins (direct to DB)
        /// </summary>
        /// <param name="originalClientId">originalClientId</param>
        /// <param name="originalProjectId">originalProjectId</param>
        /// <param name="originalUserId">originalUserId</param>
        /// <param name="originalLastLoggedInDate">originalLastLoggedInDate</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalWorkType">originalWorkType</param>
        /// <param name="newClientId">newClientId</param>
        /// <param name="newProjectId">newProjectId</param>
        /// <param name="newUserId">newUserId</param>
        /// <param name="newLastLoggedInDate">newLastLoggedInDate</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newWorkType">newWorkType</param>
        /// <returns>rowsAffected</returns>
        public int Update(int originalClientId, int originalProjectId, int originalUserId, DateTime originalLastLoggedInDate, int originalCompanyId, bool originalDeleted, string originalWorkType, int newClientId, int newProjectId, int newUserId, DateTime newLastLoggedInDate, int newCompanyId, bool newDeleted, string newWorkType)
        {
            SqlParameter originalClientIdParameter = new SqlParameter("Original_ClientID", originalClientId);
            SqlParameter originalProjectIdParameter = new SqlParameter("Original_ProjectID", originalProjectId);
            SqlParameter originalUserIdParameter = new SqlParameter("Original_UserID", originalUserId);
            SqlParameter originalLastLoggedInDateParameter = new SqlParameter("Original_LastLoggedInDate", originalLastLoggedInDate);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);
            SqlParameter originalWorkTypeParameter = new SqlParameter("Original_WorkType", originalWorkType);

            SqlParameter newClientIdParameter = new SqlParameter("ClientID", newClientId);
            SqlParameter newProjectIdParameter = new SqlParameter("ProjectID", newProjectId);
            SqlParameter newUserIdParameter = new SqlParameter("UserID", newUserId);
            SqlParameter newLastLoggedInDateParameter = new SqlParameter("LastLoggedInDate", newLastLoggedInDate);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);
            SqlParameter newWorkTypeParameter = new SqlParameter("WorkType", newWorkType);

            string command = "UPDATE [dbo].[LFS_WORK_PROJECT_LASTLOGIN] SET [ProjectID] = @ProjectID, "+
            " [ClientID] = @ClientID, [UserID] = @UserID, [LastLoggedInDate] = @LastLoggedInDate, "+
            " [COMPANY_ID] = @COMPANY_ID, [Deleted] = @Deleted, [WorkType] = @WorkType "+
            " WHERE (([ProjectID] = @Original_ProjectID) AND "+
            "        ([ClientID] = @Original_ClientID) AND "+
            "        ([UserID] = @Original_UserID) AND "+            
            "        ([COMPANY_ID] = @Original_COMPANY_ID) AND "+            
            "        ([WorkType] = @Original_WorkType))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalClientIdParameter, originalProjectIdParameter, originalUserIdParameter, originalLastLoggedInDateParameter, originalCompanyIdParameter, originalDeletedParameter, originalWorkTypeParameter, newClientIdParameter, newProjectIdParameter, newUserIdParameter, newLastLoggedInDateParameter, newCompanyIdParameter, newDeletedParameter, newWorkTypeParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }



    }
}

