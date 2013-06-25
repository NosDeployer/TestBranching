using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.FleetManagement.ChecklistRules
{
    /// <summary>
    /// RuleCategoryGateway
    /// </summary>
    public class RuleCategoryGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public RuleCategoryGateway()
            : base("LFS_FM_RULE_CATEGORY")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public RuleCategoryGateway(DataSet data)
            : base(data, "LFS_FM_RULE_CATEGORY")
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
            tableMapping.DataSetTable = "LFS_FM_RULE_CATEGORY";
            tableMapping.ColumnMappings.Add("RuleID", "RuleID");
            tableMapping.ColumnMappings.Add("CategoryID", "CategoryID");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[LFS_FM_RULE_CATEGORY] WHERE (([RuleID] = @Original_RuleID) AND" +
                " ([CategoryID] = @Original_CategoryID) AND ([Deleted] = @Original_Deleted) AND (" +
                "[COMPANY_ID] = @Original_COMPANY_ID))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RuleID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RuleID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CategoryID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CategoryID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            
            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_FM_RULE_CATEGORY] ([RuleID], [CategoryID], [Deleted], [COMPANY_ID]) VALUES (@RuleID, @CategoryID, @Deleted, @COMPANY_ID);
SELECT RuleID, CategoryID, Deleted, COMPANY_ID FROM LFS_FM_RULE_CATEGORY WHERE (CategoryID = @CategoryID) AND (RuleID = @RuleID)";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RuleID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RuleID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CategoryID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CategoryID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            
            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = @"UPDATE [dbo].[LFS_FM_RULE_CATEGORY] SET [RuleID] = @RuleID, [CategoryID] = @CategoryID, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID WHERE (([RuleID] = @Original_RuleID) AND ([CategoryID] = @Original_CategoryID) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID));
SELECT RuleID, CategoryID, Deleted, COMPANY_ID FROM LFS_FM_RULE_CATEGORY WHERE (CategoryID = @CategoryID) AND (RuleID = @RuleID)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RuleID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RuleID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CategoryID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CategoryID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RuleID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RuleID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CategoryID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CategoryID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
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
        /// LoadByCategoryId
        /// </summary>
        /// <param name="categoryId">categoryId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>data set</returns>
        public DataSet LoadByCategoryId(int categoryId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_RULECATEGORYGATEWAY_LOADBYCATEGORYID", new SqlParameter("@categoryId", categoryId), new SqlParameter("@companyId", companyId));
            return Data;
        }





                       
        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROW
        //

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <param name="categoryId">categoryId</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void Insert(int ruleId, int categoryId, bool deleted, int companyId)
        {
            SqlParameter ruleIdParameter = new SqlParameter("RuleID", ruleId);
            SqlParameter categoryIdParameter = new SqlParameter("CategoryID", categoryId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);

            string command = "INSERT INTO [dbo].[LFS_FM_RULE_CATEGORY] ([RuleID], [CategoryID], [Deleted], [COMPANY_ID]) VALUES (@RuleID, @CategoryID, @Deleted, @COMPANY_ID)";

            ExecuteScalar(command, ruleIdParameter, categoryIdParameter, deletedParameter, companyIdParameter);            
        }



        /// <summary>
        /// delete
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <param name="categoryId">categoryId</param>
        /// <param name="companyId">companyId</param>
        public void Delete(int ruleId, int categoryId, int companyId)
        {
            SqlParameter ruleIdParameter = new SqlParameter("Original_RuleID", ruleId);
            SqlParameter categoryIdParameter = new SqlParameter("Original_CategoryID", categoryId);
            SqlParameter companyIdParameter = new SqlParameter("Original_COMPANY_ID", companyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_FM_RULE_CATEGORY] SET  [Deleted] = @Deleted WHERE (([RuleID] = @Original_RuleID) AND ([CategoryID] = @Original_CategoryID) AND ([COMPANY_ID] = @Original_COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, ruleIdParameter, categoryIdParameter, companyIdParameter, deletedParameter);
            
            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }
        }



        /// <summary>
        /// UnDelete
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <param name="categoryId">categoryId</param>
        /// <param name="companyId">companyId</param>
        public void UnDelete(int ruleId, int categoryId, int companyId)
        {
            SqlParameter ruleIdParameter = new SqlParameter("Original_RuleID", ruleId);
            SqlParameter categoryIdParameter = new SqlParameter("Original_CategoryID", categoryId);
            SqlParameter companyIdParameter = new SqlParameter("Original_COMPANY_ID", companyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", SqlDbType.Bit);
            deletedParameter.Value = 0;

            string command = "UPDATE [dbo].[LFS_FM_RULE_CATEGORY] SET  [Deleted] = @Deleted WHERE (([RuleID] = @Original_RuleID) AND ([CategoryID] = @Original_CategoryID) AND ([COMPANY_ID] = @Original_COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, ruleIdParameter, categoryIdParameter, companyIdParameter, deletedParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }
        }



        /// <summary>
        /// IsUsedInRuleCategory
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <param name="categoryId">categoryId</param>
        /// <returns>TRUE if is used</returns>
        public bool IsUsedInRuleCategory(int ruleId, int categoryId)
        {
            string commandText = "SELECT COUNT(*) FROM LFS_FM_RULE_CATEGORY WHERE (RuleID = @ruleId) AND (CategoryID = @categoryId) AND (Deleted = 0)";
            SqlCommand command = new SqlCommand(commandText, DB.Connection);
            command.Parameters.Add(new SqlParameter("@ruleId", ruleId));
            command.Parameters.Add(new SqlParameter("@categoryId", categoryId));

            return ((int)ExecuteScalar(command) > 0) ? true : false;
        }



        /// <summary>
        /// IsUsedInRuleCategory
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <param name="categoryId">categoryId</param>
        /// <param name="deleted">deleted</param>
        /// <returns>TRUE if is used</returns>
        public bool IsUsedInRuleCategory(int ruleId, int categoryId, bool deleted)
        {
            string commandText = "SELECT COUNT(*) FROM LFS_FM_RULE_CATEGORY WHERE (RuleID = @ruleId) AND (CategoryID = @categoryId)";
            SqlCommand command = new SqlCommand(commandText, DB.Connection);
            command.Parameters.Add(new SqlParameter("@ruleId", ruleId));
            command.Parameters.Add(new SqlParameter("@categoryId", categoryId));

            return ((int)ExecuteScalar(command) > 0) ? true : false;
        }

       
 
    }
}


