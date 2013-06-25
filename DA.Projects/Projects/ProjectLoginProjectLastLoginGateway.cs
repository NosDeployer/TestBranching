using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Projects.Projects
{
    /// <summary>
    /// ProjectLoginProjectLastLoginGateway
    /// </summary>
    public class ProjectLoginProjectLastLoginGateway: DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectLoginProjectLastLoginGateway()
            : base("LFS_PROJECT_LASTLOGIN")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectLoginProjectLastLoginGateway(DataSet data)
            : base(data, "LFS_PROJECT_LASTLOGIN")
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
            tableMapping.DataSetTable = "LFS_PROJECT_LASTLOGIN";
            tableMapping.ColumnMappings.Add("ProjectID", "ProjectID");            
            tableMapping.ColumnMappings.Add("UserID", "UserID");
            tableMapping.ColumnMappings.Add("LastLoggedInDate", "LastLoggedInDate");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");            

            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[LFS_PROJECT_LASTLOGIN] WHERE (([ProjectID] = @Original_Project" +
                "ID) AND ([UserID] = @Original_UserID) AND ([LastLoggedInDate] = @Original_LastLo" +
                "ggedInDate) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND ([Deleted] = @Original" +
                "_Deleted))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ProjectID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_UserID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UserID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LastLoggedInDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LastLoggedInDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_PROJECT_LASTLOGIN] ([ProjectID], [UserID], [LastLoggedInDate], [COMPANY_ID], [Deleted]) VALUES (@ProjectID, @UserID, @LastLoggedInDate, @COMPANY_ID, @Deleted);
SELECT ProjectID, UserID, LastLoggedInDate, COMPANY_ID, Deleted FROM LFS_PROJECT_LASTLOGIN WHERE (COMPANY_ID = @COMPANY_ID) AND (ProjectID = @ProjectID) AND (UserID = @UserID)";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ProjectID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@UserID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UserID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LastLoggedInDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LastLoggedInDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            
            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = @"UPDATE [dbo].[LFS_PROJECT_LASTLOGIN] SET [ProjectID] = @ProjectID, [UserID] = @UserID, [LastLoggedInDate] = @LastLoggedInDate, [COMPANY_ID] = @COMPANY_ID, [Deleted] = @Deleted WHERE (([ProjectID] = @Original_ProjectID) AND ([UserID] = @Original_UserID) AND ([LastLoggedInDate] = @Original_LastLoggedInDate) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND ([Deleted] = @Original_Deleted));
SELECT ProjectID, UserID, LastLoggedInDate, COMPANY_ID, Deleted FROM LFS_PROJECT_LASTLOGIN WHERE (COMPANY_ID = @COMPANY_ID) AND (ProjectID = @ProjectID) AND (UserID = @UserID)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ProjectID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@UserID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UserID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LastLoggedInDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LastLoggedInDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ProjectID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_UserID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UserID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LastLoggedInDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LastLoggedInDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
                #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROWS
        //

        /// <summary>
        /// Insert a project login
        /// </summary>
        /// <param name="projectId">projectId</param>        
        /// <param name="userId">userId</param>
        /// <param name="lastLoggedInDate">lastLoggedInDate</param>
        /// <param name="companyId">companyId</param>        
        /// <param name="deleted">deleted</param>        
        /// <returns>workId</returns>
        public int Insert(int projectId,  int userId, DateTime lastLoggedInDate, int companyId,  bool deleted)
        {
            SqlParameter projectIdParameter = new SqlParameter("ProjectID", projectId);            
            SqlParameter userIdParameter = new SqlParameter("UserID", userId);
            SqlParameter lastLoggedInDateParameter = new SqlParameter("LastLoggedInDate", lastLoggedInDate);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);            

            string command = "INSERT INTO [dbo].[LFS_PROJECT_LASTLOGIN] ([ProjectID],  [UserID], "+
            " [LastLoggedInDate], [COMPANY_ID], [Deleted]) "+
            " VALUES (@ProjectID, @UserID, @LastLoggedInDate, @COMPANY_ID, @Deleted)";

            int rowsAffected = (int)ExecuteNonQuery(command, projectIdParameter, userIdParameter, lastLoggedInDateParameter, companyIdParameter, deletedParameter);

            return rowsAffected;
        }



        /// <summary>
        /// Update logins (direct to DB)
        /// </summary>        
        /// <param name="originalProjectId">originalProjectId</param>
        /// <param name="originalUserId">originalUserId</param>
        /// <param name="originalLastLoggedInDate">originalLastLoggedInDate</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalDeleted">originalDeleted</param>                
        /// <param name="newProjectId">newProjectId</param>
        /// <param name="newUserId">newUserId</param>
        /// <param name="newLastLoggedInDate">newLastLoggedInDate</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newDeleted">newDeleted</param>        
        /// <returns>rowsAffected</returns>
        public int Update(int originalProjectId, int originalUserId, DateTime originalLastLoggedInDate, int originalCompanyId, bool originalDeleted, int newProjectId, int newUserId, DateTime newLastLoggedInDate, int newCompanyId, bool newDeleted)
        {
            SqlParameter originalProjectIdParameter = new SqlParameter("Original_ProjectID", originalProjectId);
            SqlParameter originalUserIdParameter = new SqlParameter("Original_UserID", originalUserId);
            SqlParameter originalLastLoggedInDateParameter = new SqlParameter("Original_LastLoggedInDate", originalLastLoggedInDate);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);

            SqlParameter newProjectIdParameter = new SqlParameter("ProjectID", newProjectId);
            SqlParameter newUserIdParameter = new SqlParameter("UserID", newUserId);
            SqlParameter newLastLoggedInDateParameter = new SqlParameter("LastLoggedInDate", newLastLoggedInDate);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);

            string command = "UPDATE [dbo].[LFS_PROJECT_LASTLOGIN] SET [ProjectID] = @ProjectID, "+
            " [UserID] = @UserID, [LastLoggedInDate] = @LastLoggedInDate, "+
            " [COMPANY_ID] = @COMPANY_ID, [Deleted] = @Deleted "+
            " WHERE (([ProjectID] = @Original_ProjectID) AND "+            
            "        ([UserID] = @Original_UserID) AND "+            
            "        ([COMPANY_ID] = @Original_COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalProjectIdParameter, originalUserIdParameter, originalLastLoggedInDateParameter, originalCompanyIdParameter, originalDeletedParameter, newProjectIdParameter, newUserIdParameter, newLastLoggedInDateParameter, newCompanyIdParameter, newDeletedParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }



    }
}

