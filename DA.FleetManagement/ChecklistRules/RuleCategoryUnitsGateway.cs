using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.FleetManagement.ChecklistRules
{
    /// <summary>
    /// RuleCategoryUnitsGateway
    /// </summary>
    public class RuleCategoryUnitsGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public RuleCategoryUnitsGateway()
            : base("LFS_FM_RULE_CATEGORY_UNITS")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public RuleCategoryUnitsGateway(DataSet data)
            : base(data, "LFS_FM_RULE_CATEGORY_UNITS")
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
            tableMapping.DataSetTable = "LFS_FM_RULE_CATEGORY_UNITS";
            tableMapping.ColumnMappings.Add("RuleID", "RuleID");
            tableMapping.ColumnMappings.Add("CategoryID", "CategoryID");
            tableMapping.ColumnMappings.Add("UnitID", "UnitID");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = @"DELETE FROM [dbo].[LFS_FM_RULE_CATEGORY_UNITS] WHERE (([RuleID] = @Original_RuleID) AND ([CategoryID] = @Original_CategoryID) AND ([UnitID] = @Original_UnitID) AND ((@IsNull_Deleted = 1 AND [Deleted] IS NULL) OR ([Deleted] = @Original_Deleted)) AND ((@IsNull_COMPANY_ID = 1 AND [COMPANY_ID] IS NULL) OR ([COMPANY_ID] = @Original_COMPANY_ID)))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RuleID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RuleID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CategoryID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CategoryID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_UnitID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Deleted", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            
            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_FM_RULE_CATEGORY_UNITS] ([RuleID], [CategoryID], [UnitID], [Deleted], [COMPANY_ID]) VALUES (@RuleID, @CategoryID, @UnitID, @Deleted, @COMPANY_ID);
SELECT RuleID, CategoryID, UnitID, Deleted, COMPANY_ID FROM LFS_FM_RULE_CATEGORY_UNITS WHERE (CategoryID = @CategoryID) AND (RuleID = @RuleID) AND (UnitID = @UnitID)";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RuleID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RuleID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CategoryID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CategoryID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@UnitID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            
            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = @"UPDATE [dbo].[LFS_FM_RULE_CATEGORY_UNITS] SET [RuleID] = @RuleID, [CategoryID] = @CategoryID, [UnitID] = @UnitID, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID WHERE (([RuleID] = @Original_RuleID) AND ([CategoryID] = @Original_CategoryID) AND ([UnitID] = @Original_UnitID) AND ((@IsNull_Deleted = 1 AND [Deleted] IS NULL) OR ([Deleted] = @Original_Deleted)) AND ((@IsNull_COMPANY_ID = 1 AND [COMPANY_ID] IS NULL) OR ([COMPANY_ID] = @Original_COMPANY_ID)));
SELECT RuleID, CategoryID, UnitID, Deleted, COMPANY_ID FROM LFS_FM_RULE_CATEGORY_UNITS WHERE (CategoryID = @CategoryID) AND (RuleID = @RuleID) AND (UnitID = @UnitID)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RuleID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RuleID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CategoryID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CategoryID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@UnitID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RuleID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RuleID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CategoryID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CategoryID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_UnitID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Deleted", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROW
        //

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <param name="categoryId">categoryId</param>
        /// <param name="unitId">unitId</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void Insert(int ruleId, int categoryId, int unitId, bool deleted, int companyId)
        {
            SqlParameter ruleIdParameter = new SqlParameter("RuleID", ruleId);
            SqlParameter categoryIdParameter = new SqlParameter("CategoryID", categoryId);
            SqlParameter unitIdParameter = new SqlParameter("UnitID", unitId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);

            string command = "INSERT INTO [dbo].[LFS_FM_RULE_CATEGORY_UNITS] ([RuleID], [CategoryID], [UnitID], [Deleted], [COMPANY_ID]) VALUES (@RuleID, @CategoryID, @UnitID, @Deleted, @COMPANY_ID)";

            ExecuteScalar(command, ruleIdParameter, categoryIdParameter, unitIdParameter, deletedParameter, companyIdParameter);
        }



        /// <summary>
        /// DeleteByRuleId
        /// </summary>
        /// <param name="ruleId">ruleId</param>   
        /// <param name="categoryId">categoryId</param>
        /// <param name="unitId">unitId</param>        
        /// <param name="companyId">companyId</param>
        public void Delete (int ruleId, int categoryId, int unitId, int companyId)
        {
            SqlParameter ruleIdParameter = new SqlParameter("Original_RuleID", ruleId);
            SqlParameter categoryIdParameter = new SqlParameter("Original_CategoryID", categoryId);
            SqlParameter unitIdParameter = new SqlParameter("Original_UnitID", unitId);
            SqlParameter companyIdParameter = new SqlParameter("Original_COMPANY_ID", companyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_FM_RULE_CATEGORY_UNITS] SET  [Deleted] = @Deleted WHERE " +
                " (([RuleID] = @Original_RuleID) AND ([CategoryID] = @Original_CategoryID) AND ([UnitID] = @Original_UnitID) AND([COMPANY_ID] = @Original_COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, ruleIdParameter, categoryIdParameter, unitIdParameter, companyIdParameter, deletedParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }
        }



        /// <summary>
        /// DeleteByRuleId
        /// </summary>
        /// <param name="ruleId">ruleId</param>        
        /// <param name="companyId">companyId</param>
        public void DeleteByRuleId(int ruleId, int companyId)
        {
            SqlParameter ruleIdParameter = new SqlParameter("Original_RuleID", ruleId);
            SqlParameter companyIdParameter = new SqlParameter("Original_COMPANY_ID", companyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_FM_RULE_CATEGORY_UNITS] SET  [Deleted] = @Deleted WHERE "+
                " (([RuleID] = @Original_RuleID) AND([COMPANY_ID] = @Original_COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, ruleIdParameter, companyIdParameter, deletedParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }
        }



        /// <summary>
        /// DeleteByRuleIdCategoryId
        /// </summary>
        /// <param name="ruleId">ruleId</param>        
        /// <param name="categoryId">categoryId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteByRuleIdCategoryId(int ruleId, int categoryId, int companyId)
        {
            SqlParameter ruleIdParameter = new SqlParameter("Original_RuleID", ruleId);
            SqlParameter categoryIdParameter = new SqlParameter("Original_CategoryID", categoryId);
            SqlParameter companyIdParameter = new SqlParameter("Original_COMPANY_ID", companyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_FM_RULE_CATEGORY_UNITS] SET  [Deleted] = @Deleted WHERE " +
                " (([RuleID] = @Original_RuleID) AND ([CategoryID] = @Original_CategoryID) AND ([COMPANY_ID] = @Original_COMPANY_ID))";

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
        /// <param name="unitId">unitId</param>
        /// <param name="companyId">companyId</param>
        public void UnDelete(int ruleId, int categoryId, int unitId, int companyId)
        {
            SqlParameter ruleIdParameter = new SqlParameter("Original_RuleID", ruleId);
            SqlParameter categoryIdParameter = new SqlParameter("Original_CategoryID", categoryId);
            SqlParameter unitIdParameter = new SqlParameter("Original_UnitID", unitId);
            SqlParameter companyIdParameter = new SqlParameter("Original_COMPANY_ID", companyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", SqlDbType.Bit);
            deletedParameter.Value = 0;

            string command = "UPDATE [dbo].[LFS_FM_RULE_CATEGORY_UNITS] SET  [Deleted] = @Deleted WHERE "+
                " (([RuleID] = @Original_RuleID) AND ([CategoryID] = @Original_CategoryID) AND "+
                " ([UnitID] = @Original_UnitID) AND ([COMPANY_ID] = @Original_COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, ruleIdParameter, categoryIdParameter, unitIdParameter, companyIdParameter, deletedParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }
        }



        /// <summary>
        /// IsRuleUsed
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <returns>TRUE if is used</returns>
        public bool IsRuleUsed(int ruleId)
        {
            string commandText = "SELECT COUNT(*) FROM LFS_FM_RULE_CATEGORY_UNITS WHERE " +
                " (RuleID = @ruleId) AND (Deleted = 0)";
            SqlCommand command = new SqlCommand(commandText, DB.Connection);
            command.Parameters.Add(new SqlParameter("@ruleId", ruleId));

            return ((int)ExecuteScalar(command) > 0) ? true : false;
        }



        /// <summary>
        /// IsUsedInRuleCategoryUnits
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <param name="categoryId">categoryId</param>
        /// <param name="unitId">unitId</param>
        /// <returns>TRUE if is used</returns>
        public bool IsUsedInRuleCategoryUnits(int ruleId, int categoryId, int unitId)
        {
            string commandText = "SELECT COUNT(*) FROM LFS_FM_RULE_CATEGORY_UNITS WHERE "+
                " (RuleID = @ruleId) AND (CategoryID = @categoryId) AND (UnitID = @unitId) AND (Deleted = 0)";
            SqlCommand command = new SqlCommand(commandText, DB.Connection);
            command.Parameters.Add(new SqlParameter("@ruleId", ruleId));
            command.Parameters.Add(new SqlParameter("@categoryId", categoryId));
            command.Parameters.Add(new SqlParameter("@unitId", unitId));

            return ((int)ExecuteScalar(command) > 0) ? true : false;
        }



        /// <summary>
        /// IsUsedInRuleCategoryUnitsAsDeleted
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <param name="categoryId">categoryId</param>
        /// <param name="unitId">unitId</param>
        /// <returns>TRUE if is used</returns>
        public bool IsUsedInRuleCategoryUnitsAsDeleted(int ruleId, int categoryId, int unitId)
        {
            string commandText = "SELECT COUNT(*) FROM LFS_FM_RULE_CATEGORY_UNITS WHERE " +
                " (RuleID = @ruleId) AND (CategoryID = @categoryId) AND (UnitID = @unitId) AND (Deleted = 1)";
            SqlCommand command = new SqlCommand(commandText, DB.Connection);
            command.Parameters.Add(new SqlParameter("@ruleId", ruleId));
            command.Parameters.Add(new SqlParameter("@categoryId", categoryId));
            command.Parameters.Add(new SqlParameter("@unitId", unitId));

            return ((int)ExecuteScalar(command) > 0) ? true : false;
        }

       

    }
}