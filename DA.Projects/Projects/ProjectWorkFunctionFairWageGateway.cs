using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Projects.Projects
{
    /// <summary>
    /// ProjectWorkFunctionFairWageGateway
    /// </summary>
    public class ProjectWorkFunctionFairWageGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectWorkFunctionFairWageGateway()
            : base("LFS_PROJECT_WORK_FUNCTION_FAIR_WAGE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectWorkFunctionFairWageGateway(DataSet data)
            : base(data, "LFS_PROJECT_WORK_FUNCTION_FAIR_WAGE")
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
            tableMapping.DataSetTable = "LFS_PROJECT_WORK_FUNCTION_FAIR_WAGE";
            tableMapping.ColumnMappings.Add("ProjectID", "ProjectID");
            tableMapping.ColumnMappings.Add("Work_", "Work_");
            tableMapping.ColumnMappings.Add("Function_", "Function_");
            tableMapping.ColumnMappings.Add("RefID", "RefID");
            tableMapping.ColumnMappings.Add("IsFairWage", "IsFairWage");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            this._adapter.TableMappings.Add(tableMapping);
            
            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = @"DELETE FROM [dbo].[LFS_PROJECT_WORK_FUNCTION_FAIR_WAGE] WHERE (([ProjectID] = @Original_ProjectID) AND ([Work_] = @Original_Work_) AND ([Function_] = @Original_Function_) AND ([RefID] = @Original_RefID) AND ([IsFairWage] = @Original_IsFairWage) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ProjectID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Work_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Work_", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Function_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Function_", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RefID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RefID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_IsFairWage", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IsFairWage", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            
            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_PROJECT_WORK_FUNCTION_FAIR_WAGE] ([ProjectID], [Work_], [Function_], [RefID], [IsFairWage], [Deleted], [COMPANY_ID]) VALUES (@ProjectID, @Work_, @Function_, @RefID, @IsFairWage, @Deleted, @COMPANY_ID);
SELECT ProjectID, Work_, Function_, RefID, IsFairWage, Deleted, COMPANY_ID FROM LFS_PROJECT_WORK_FUNCTION_FAIR_WAGE WHERE (Function_ = @Function_) AND (ProjectID = @ProjectID) AND (RefID = @RefID) AND (Work_ = @Work_)";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ProjectID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Work_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Work_", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Function_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Function_", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RefID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RefID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsFairWage", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IsFairWage", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            
            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = @"UPDATE [dbo].[LFS_PROJECT_WORK_FUNCTION_FAIR_WAGE] SET [ProjectID] = @ProjectID, [Work_] = @Work_, [Function_] = @Function_, [RefID] = @RefID, [IsFairWage] = @IsFairWage, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID WHERE (([ProjectID] = @Original_ProjectID) AND ([Work_] = @Original_Work_) AND ([Function_] = @Original_Function_) AND ([RefID] = @Original_RefID) AND ([IsFairWage] = @Original_IsFairWage) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID));
SELECT ProjectID, Work_, Function_, RefID, IsFairWage, Deleted, COMPANY_ID FROM LFS_PROJECT_WORK_FUNCTION_FAIR_WAGE WHERE (Function_ = @Function_) AND (ProjectID = @ProjectID) AND (RefID = @RefID) AND (Work_ = @Work_)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ProjectID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Work_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Work_", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Function_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Function_", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RefID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RefID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsFairWage", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IsFairWage", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ProjectID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Work_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Work_", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Function_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Function_", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RefID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RefID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_IsFairWage", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IsFairWage", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
                        
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
            FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTWORKFUNCTIONFAIRWAGEGATEWAY_LOADALLBYPROJECTID", new SqlParameter("@projectId", projectId));
            return Data;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROWS
        //

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="work_">work_</param>
        /// <param name="function_">function_</param>
        /// <param name="refId">refId</param>
        /// <param name="isFairWage">isFairWage</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <returns>rowsAffected</returns>
        public int Insert(int projectId, string work_, string function_, int refId, bool isFairWage, bool deleted, int companyId)
        {
            SqlParameter projectIdParameter = new SqlParameter("ProjectID", projectId);
            SqlParameter work_Parameter = new SqlParameter("Work_", work_);
            SqlParameter function_Parameter = new SqlParameter("Function_", function_);
            SqlParameter refIdParameter = new SqlParameter("RefID", refId);
            SqlParameter isFairWageParameter = new SqlParameter("IsFairWage", isFairWage);
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
                                                 
            string command = "INSERT INTO [dbo].[LFS_PROJECT_WORK_FUNCTION_FAIR_WAGE] ([ProjectID], [Work_], [Function_], [RefID], [IsFairWage], [Deleted], [COMPANY_ID]) "+
                " VALUES (@ProjectID, @Work_, @Function_, @RefID, @IsFairWage, @Deleted, @COMPANY_ID)";

            int rowsAffected = (int)ExecuteNonQuery(command, projectIdParameter, work_Parameter, function_Parameter, refIdParameter, isFairWageParameter, deletedParameter, companyIdParameter);

            return rowsAffected;
        }



        public int Update(int originalProjectId, string originalWork_, string originalFunction_, int originalRefId, bool originalIsFairWage, bool originalDeleted, int originalCompanyId, int newProjectId, string newWork_, string newFunction_, int newRefId, bool newIsFairWage, bool newDeleted, int newCompanyId)
        {
            SqlParameter originalProjectIdParameter = new SqlParameter("Original_ProjectID", originalProjectId);
            SqlParameter originalWork_Parameter = new SqlParameter("Original_Work_", originalWork_);
            SqlParameter originalFunction_Parameter = new SqlParameter("Original_Function_", originalFunction_);
            SqlParameter originalRefIdParameter = new SqlParameter("Original_RefID", originalRefId);
            SqlParameter originalIsFairWageParameter = new SqlParameter("Original_IsFairWage", originalIsFairWage);
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);

            SqlParameter newProjectIdParameter = new SqlParameter("ProjectID", newProjectId);
            SqlParameter newWork_Parameter = new SqlParameter("Work_", newWork_);
            SqlParameter newFunction_Parameter = new SqlParameter("Function_", newFunction_);
            SqlParameter newRefIdParameter = new SqlParameter("RefID", newRefId);
            SqlParameter newIsFairWageParameter = new SqlParameter("IsFairWage", newIsFairWage);
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);

            string command = "UPDATE [dbo].[LFS_PROJECT_WORK_FUNCTION_FAIR_WAGE] SET [IsFairWage] = @IsFairWage " +
                " WHERE (([ProjectID] = @Original_ProjectID) AND ([RefID] = @Original_RefID) AND ([Work_]=@Original_Work_) AND ([Function_]=@Original_Function_))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalProjectIdParameter, originalWork_Parameter, originalFunction_Parameter, originalRefIdParameter, originalIsFairWageParameter, originalDeletedParameter, originalCompanyIdParameter, newProjectIdParameter, newWork_Parameter, newFunction_Parameter, newRefIdParameter, newIsFairWageParameter, newDeletedParameter, newCompanyIdParameter);
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
        public int Delete(int originalProjectId, string originalWork_, string originalFunction_, int originalRefId, int originalCompanyId)
        {
            SqlParameter originalProjectIdParameter = new SqlParameter("@Original_ProjectID", originalProjectId);
            SqlParameter originalWork_Parameter = new SqlParameter("@Original_Work_", originalWork_);
            SqlParameter originalFunction_Parameter = new SqlParameter("@Original_Function_", originalFunction_);
            SqlParameter originalRefIdParameter = new SqlParameter("@Original_RefID", originalRefId);
            SqlParameter originalCompanyIdParameter = new SqlParameter("@Original_COMPANY_ID", originalCompanyId);
            SqlParameter deletedParameter = new SqlParameter("@Deleted", 1);

            string command = "UPDATE [dbo].[LFS_PROJECT_WORK_FUNCTION_FAIR_WAGE] SET  [Deleted] = @Deleted  " +
                             " WHERE (([ProjectID] = @Original_ProjectID) AND ([RefID] = @Original_RefID) AND ([Work_]=@Original_Work_) AND ([Function_]=@Original_Function_) AND " +
                             "  ([COMPANY_ID] = @Original_COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalProjectIdParameter, originalWork_Parameter, originalFunction_Parameter, originalRefIdParameter, originalCompanyIdParameter, deletedParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }



    }
}