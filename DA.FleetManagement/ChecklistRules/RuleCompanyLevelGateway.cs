using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.FleetManagement.ChecklistRules
{
    /// <summary>
    /// RuleCompanyLevelGateway
    /// </summary>
    public class RuleCompanyLevelGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public RuleCompanyLevelGateway()
            : base("LFS_FM_RULE_COMPANYLEVEL")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public RuleCompanyLevelGateway(DataSet data)
            : base(data, "LFS_FM_RULE_COMPANYLEVEL")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new RuleTDS();
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
            tableMapping.DataSetTable = "LFS_FM_RULE_COMPANYLEVEL";
            tableMapping.ColumnMappings.Add("RuleID", "RuleID");
            tableMapping.ColumnMappings.Add("CompanyLevelID", "CompanyLevelID");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[LFS_FM_RULE_COMPANYLEVEL] WHERE (([RuleID] = @Original_RuleID)" +
                " AND ([CompanyLevelID] = @Original_CompanyLevelID) AND ([Deleted] = @Original_De" +
                "leted) AND ([COMPANY_ID] = @Original_COMPANY_ID))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RuleID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RuleID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CompanyLevelID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CompanyLevelID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            
            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_FM_RULE_COMPANYLEVEL] ([RuleID], [CompanyLevelID], [Deleted], [COMPANY_ID]) VALUES (@RuleID, @CompanyLevelID, @Deleted, @COMPANY_ID);
SELECT RuleID, CompanyLevelID, Deleted, COMPANY_ID FROM LFS_FM_RULE_COMPANYLEVEL WHERE (CompanyLevelID = @CompanyLevelID) AND (RuleID = @RuleID)";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RuleID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RuleID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CompanyLevelID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CompanyLevelID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            
            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = @"UPDATE [dbo].[LFS_FM_RULE_COMPANYLEVEL] SET [RuleID] = @RuleID, [CompanyLevelID] = @CompanyLevelID, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID WHERE (([RuleID] = @Original_RuleID) AND ([CompanyLevelID] = @Original_CompanyLevelID) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID));
SELECT RuleID, CompanyLevelID, Deleted, COMPANY_ID FROM LFS_FM_RULE_COMPANYLEVEL WHERE (CompanyLevelID = @CompanyLevelID) AND (RuleID = @RuleID)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RuleID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RuleID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CompanyLevelID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CompanyLevelID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RuleID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RuleID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CompanyLevelID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CompanyLevelID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
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
        /// LoadByCompanyLevelId
        /// </summary>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>data set</returns>
        public DataSet LoadByCompanyLevelId(int companyLevelId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_RULECOMPANYLEVELGATEWAY_LOADBYCOMPANYLEVELID", new SqlParameter("@companyLevelId", companyLevelId), new SqlParameter("@companyId", companyId));
            return Data;
        }





                       
        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROW
        //


        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void Insert(int ruleId, int companyLevelId, bool deleted, int companyId)
        {
            SqlParameter ruleIdParameter = new SqlParameter("RuleID", ruleId);
            SqlParameter companyLevelIdParameter = new SqlParameter("CompanyLevelID", companyLevelId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);

            string command = "INSERT INTO [dbo].[LFS_FM_RULE_COMPANYLEVEL] ([RuleID], [CompanyLevelID], [Deleted], [COMPANY_ID]) VALUES (@RuleID, @CompanyLevelID, @Deleted, @COMPANY_ID)";

            ExecuteScalar(command, ruleIdParameter, companyLevelIdParameter, deletedParameter, companyIdParameter);            
        }



        /// <summary>
        /// delete
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <param name="companyId">companyId</param>
        public void Delete(int ruleId, int companyLevelId, int companyId)
        {
            SqlParameter ruleIdParameter = new SqlParameter("RuleID", ruleId);
            SqlParameter companyLevelIdParameter = new SqlParameter("CompanyLevelID", companyLevelId);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_FM_RULE_COMPANYLEVEL] SET  [Deleted] = @Deleted WHERE (([RuleID] = @RuleID) AND ([CompanyLevelID] = @CompanyLevelID) AND ([COMPANY_ID] = @COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, ruleIdParameter, companyLevelIdParameter, companyIdParameter, deletedParameter);
            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }
        }



        /// <summary>
        /// delete
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <param name="companyId">companyId</param>
        public void UnDelete(int ruleId, int companyLevelId, int companyId)
        {
            SqlParameter ruleIdParameter = new SqlParameter("RuleID", ruleId);
            SqlParameter companyLevelIdParameter = new SqlParameter("CompanyLevelID", companyLevelId);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", SqlDbType.Bit);
            deletedParameter.Value = 0;

            string command = "UPDATE [dbo].[LFS_FM_RULE_COMPANYLEVEL] SET  [Deleted] = @Deleted WHERE (([RuleID] = @RuleID) AND ([CompanyLevelID] = @CompanyLevelID) AND ([COMPANY_ID] = @COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, ruleIdParameter, companyLevelIdParameter, companyIdParameter, deletedParameter);
            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }
        }



        /// <summary>
        /// IsUsedInRuleCompanyLevel
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <returns>TRUE if is used</returns>
        public bool IsUsedInRuleCompanyLevel(int ruleId, int companyLevelId)
        {
            string commandText = "SELECT COUNT(*) FROM LFS_FM_RULE_COMPANYLEVEL WHERE (RuleID = @ruleId) AND (CompanyLevelID = @companyLevelId) AND (Deleted = 0)";
            SqlCommand command = new SqlCommand(commandText, DB.Connection);
            command.Parameters.Add(new SqlParameter("@ruleId", ruleId));
            command.Parameters.Add(new SqlParameter("@companyLevelId", companyLevelId));

            return ((int)ExecuteScalar(command) > 0) ? true : false;
        }



        /// <summary>
        /// IsUsedInRuleCompanyLevel
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <param name="deleted">deleted</param>
        /// <returns>TRUE if is used</returns>
        public bool IsUsedInRuleCompanyLevel(int ruleId, int companyLevelId, bool deleted)
        {
            string commandText = "SELECT COUNT(*) FROM LFS_FM_RULE_COMPANYLEVEL WHERE (RuleID = @ruleId) AND (CompanyLevelID = @companyLevelId)";
            SqlCommand command = new SqlCommand(commandText, DB.Connection);
            command.Parameters.Add(new SqlParameter("@ruleId", ruleId));
            command.Parameters.Add(new SqlParameter("@companyLevelId", companyLevelId));

            return ((int)ExecuteScalar(command) > 0) ? true : false;
        }

       
 
    }
}



