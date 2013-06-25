using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Projects.Projects
{
    /// <summary>
    /// ProjectJobClassTypeRateGateway
    /// </summary>
    public class ProjectJobClassTypeRateGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectJobClassTypeRateGateway()
            : base("LFS_PROJECT_JOB_CLASS_TYPE_RATE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectJobClassTypeRateGateway(DataSet data)
            : base(data, "LFS_PROJECT_JOB_CLASS_TYPE_RATE")
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
            tableMapping.DataSetTable = "LFS_PROJECT_JOB_CLASS_TYPE_RATE";
            tableMapping.ColumnMappings.Add("ProjectID", "ProjectID");
            tableMapping.ColumnMappings.Add("JobClassType", "JobClassType");
            tableMapping.ColumnMappings.Add("RefID", "RefID");
            tableMapping.ColumnMappings.Add("Rate", "Rate");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("FringeRate", "FringeRate");
            this._adapter.TableMappings.Add(tableMapping);
            
            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = @"DELETE FROM [dbo].[LFS_PROJECT_JOB_CLASS_TYPE_RATE] WHERE (([ProjectID] = @Original_ProjectID) AND ([JobClassType] = @Original_JobClassType) AND ([RefID] = @Original_RefID) AND ([Rate] = @Original_Rate) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND ([FringeRate] = @Original_FringeRate))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ProjectID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_JobClassType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "JobClassType", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RefID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RefID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Rate", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Rate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_FringeRate", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FringeRate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            
            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_PROJECT_JOB_CLASS_TYPE_RATE] ([ProjectID], [JobClassType], [RefID], [Rate], [Deleted], [COMPANY_ID], [FringeRate]) VALUES (@ProjectID, @JobClassType, @RefID, @Rate, @Deleted, @COMPANY_ID, @FringeRate);
SELECT ProjectID, JobClassType, RefID, Rate, Deleted, COMPANY_ID, FringeRate FROM LFS_PROJECT_JOB_CLASS_TYPE_RATE WHERE (JobClassType = @JobClassType) AND (ProjectID = @ProjectID) AND (RefID = @RefID)";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ProjectID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@JobClassType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "JobClassType", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RefID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RefID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Rate", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Rate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@FringeRate", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FringeRate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            
            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = @"UPDATE [dbo].[LFS_PROJECT_JOB_CLASS_TYPE_RATE] SET [ProjectID] = @ProjectID, [JobClassType] = @JobClassType, [RefID] = @RefID, [Rate] = @Rate, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID, [FringeRate] = @FringeRate WHERE (([ProjectID] = @Original_ProjectID) AND ([JobClassType] = @Original_JobClassType) AND ([RefID] = @Original_RefID) AND ([Rate] = @Original_Rate) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND ([FringeRate] = @Original_FringeRate));
SELECT ProjectID, JobClassType, RefID, Rate, Deleted, COMPANY_ID, FringeRate FROM LFS_PROJECT_JOB_CLASS_TYPE_RATE WHERE (JobClassType = @JobClassType) AND (ProjectID = @ProjectID) AND (RefID = @RefID)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ProjectID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@JobClassType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "JobClassType", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RefID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RefID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Rate", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Rate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@FringeRate", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FringeRate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ProjectID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_JobClassType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "JobClassType", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RefID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RefID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Rate", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Rate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_FringeRate", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FringeRate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
                        
            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

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
            FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTJOBCLASSTYPERATEGATEWAY_LOADALLBYPROJECTID", new SqlParameter("@projectId", projectId));
            return Data;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROWS
        //

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="jobClassType">jobClassType</param>
        /// <param name="refId">refId</param>
        /// <param name="rate">rate</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="fringeRate">fringeRate</param>
        /// <returns>rowsAffected</returns>
        public int Insert(int projectId, string jobClassType, int refId, decimal rate, bool deleted, int companyId, decimal fringeRate)
        {
            SqlParameter projectIdParameter = new SqlParameter("ProjectID", projectId);
            SqlParameter jobClassTypeParameter = new SqlParameter("JobClassType", jobClassType);
            SqlParameter refIdParameter = new SqlParameter("RefID", refId);
            SqlParameter rateParameter = new SqlParameter("Rate", rate);
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            SqlParameter fringeRateParameter = new SqlParameter("FringeRate", fringeRate);

            string command = "INSERT INTO [dbo].[LFS_PROJECT_JOB_CLASS_TYPE_RATE] ([ProjectID], [JobClassType], [RefID], [Rate], [Deleted], [COMPANY_ID], [FringeRate]) "+
                " VALUES (@ProjectID, @JobClassType, @RefID, @Rate, @Deleted, @COMPANY_ID, @FringeRate)";

            int rowsAffected = (int)ExecuteNonQuery(command, projectIdParameter, jobClassTypeParameter, refIdParameter, rateParameter, deletedParameter, companyIdParameter, fringeRateParameter);

            return rowsAffected;
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="originalProjectId">originalProjectId</param>
        /// <param name="originalJobClassType">originalJobClassType</param>
        /// <param name="originalRefId">originalRefId</param>
        /// <param name="originalRate">originalRate</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalFringeRate">originalFringeRate</param>
        /// 
        /// <param name="newProjectId">newProjectId</param>
        /// <param name="newJobClassType">newJobClassType</param>
        /// <param name="newRefId">newRefId</param>
        /// <param name="newRate">newRate</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newFringeRate">newFringeRate</param>
        /// <returns>rowsAffected</returns>
        public int Update(int originalProjectId, string originalJobClassType, int originalRefId, decimal originalRate, bool originalDeleted, int originalCompanyId, decimal originalFringeRate, int newProjectId, string newJobClassType, int newRefId, decimal newRate, bool newDeleted, int newCompanyId, decimal newFringeRate)
        {
            SqlParameter originalProjectIdParameter = new SqlParameter("Original_ProjectID", originalProjectId);
            SqlParameter originalJobClassTypeParameter = new SqlParameter("Original_JobClassType", originalJobClassType);
            SqlParameter originalRefIdParameter = new SqlParameter("Original_RefID", originalRefId);
            SqlParameter originalRateParameter = new SqlParameter("Original_Rate", originalRate); originalRateParameter.SqlDbType = SqlDbType.Money;
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter originalFringeRateParameter = new SqlParameter("Original_FringeRate", originalFringeRate); originalFringeRateParameter.SqlDbType = SqlDbType.Money;

            SqlParameter newProjectIdParameter = new SqlParameter("ProjectID", newProjectId);
            SqlParameter newJobClassTypeParameter = new SqlParameter("JobClassType", newJobClassType);
            SqlParameter newRefIdParameter = new SqlParameter("RefID", newRefId);
            SqlParameter newRateParameter = new SqlParameter("Rate", newRate); newRateParameter.SqlDbType = SqlDbType.Money;
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);
            SqlParameter newFringeRateParameter = new SqlParameter("FringeRate", newFringeRate); newFringeRateParameter.SqlDbType = SqlDbType.Money;

            string command = "UPDATE [dbo].[LFS_PROJECT_JOB_CLASS_TYPE_RATE] SET [Rate] = @Rate, [FringeRate] = @FringeRate " +
                " WHERE (([ProjectID] = @Original_ProjectID) AND ([RefID] = @Original_RefID) AND ([JobClassType]=@Original_JobClassType))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalProjectIdParameter, originalJobClassTypeParameter, originalRefIdParameter, originalRateParameter, originalDeletedParameter, originalCompanyIdParameter, originalFringeRateParameter, newProjectIdParameter, newJobClassTypeParameter, newRefIdParameter, newRateParameter, newDeletedParameter, newCompanyIdParameter, newFringeRateParameter);
            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }



        /// <summary>
        /// Delete a Job Class Type Rate (direct to DB)
        /// </summary>
        /// <param name="originalProjectId">originalProjectId</param>
        /// <param name="originalRefId">originalRefId</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <returns>int</returns>
        public int Delete(int originalProjectId, string originalJobClassType,  int originalRefId, int originalCompanyId)
        {
            SqlParameter originalProjectIdParameter = new SqlParameter("@Original_ProjectID", originalProjectId);
            SqlParameter originalJobClassTypeParameter = new SqlParameter("@Original_JobClassType", originalJobClassType);
            SqlParameter originalRefIdParameter = new SqlParameter("@Original_RefID", originalRefId);
            SqlParameter originalCompanyIdParameter = new SqlParameter("@Original_COMPANY_ID", originalCompanyId);
            SqlParameter deletedParameter = new SqlParameter("@Deleted", 1);

            string command = "UPDATE [dbo].[LFS_PROJECT_JOB_CLASS_TYPE_RATE] SET  [Deleted] = @Deleted  " +
                             " WHERE (([ProjectID] = @Original_ProjectID) AND ([RefID] = @Original_RefID) AND ([JobClassType]=@Original_JobClassType) AND " +
                             "  ([COMPANY_ID] = @Original_COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalProjectIdParameter, originalJobClassTypeParameter, originalRefIdParameter, originalCompanyIdParameter, deletedParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }



    }
}