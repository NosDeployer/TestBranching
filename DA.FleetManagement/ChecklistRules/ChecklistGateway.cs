using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.FleetManagement.ChecklistRules
{
    /// <summary>
    /// ChecklistGateway
    /// </summary>
    public class ChecklistGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ChecklistGateway()
            : base("LFS_FM_CHECKLIST")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ChecklistGateway(DataSet data)
            : base(data, "LFS_FM_CHECKLIST")
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
            tableMapping.DataSetTable = "LFS_FM_CHECKLIST";
            tableMapping.ColumnMappings.Add("UnitID", "UnitID");
            tableMapping.ColumnMappings.Add("RuleID", "RuleID");
            tableMapping.ColumnMappings.Add("LastService", "LastService");
            tableMapping.ColumnMappings.Add("NextDue", "NextDue");
            tableMapping.ColumnMappings.Add("Done", "Done");
            tableMapping.ColumnMappings.Add("State", "State");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = @"DELETE FROM [dbo].[LFS_FM_CHECKLIST] WHERE (([UnitID] = @Original_UnitID) AND ([RuleID] = @Original_RuleID) AND ((@IsNull_LastService = 1 AND [LastService] IS NULL) OR ([LastService] = @Original_LastService)) AND ((@IsNull_NextDue = 1 AND [NextDue] IS NULL) OR ([NextDue] = @Original_NextDue)) AND ([Done] = @Original_Done) AND ([State] = @Original_State) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_UnitID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RuleID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RuleID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_LastService", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LastService", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LastService", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LastService", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_NextDue", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NextDue", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_NextDue", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NextDue", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Done", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Done", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_State", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "State", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            
            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_FM_CHECKLIST] ([UnitID], [RuleID], [LastService], [NextDue], [Done], [State], [Deleted], [COMPANY_ID]) VALUES (@UnitID, @RuleID, @LastService, @NextDue, @Done, @State, @Deleted, @COMPANY_ID);
SELECT UnitID, RuleID, LastService, NextDue, Done, State, Deleted, COMPANY_ID FROM LFS_FM_CHECKLIST WHERE (RuleID = @RuleID) AND (UnitID = @UnitID)";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@UnitID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RuleID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RuleID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LastService", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LastService", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@NextDue", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NextDue", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Done", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Done", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@State", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "State", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            
            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = @"UPDATE [dbo].[LFS_FM_CHECKLIST] SET [UnitID] = @UnitID, [RuleID] = @RuleID, [LastService] = @LastService, [NextDue] = @NextDue, [Done] = @Done, [State] = @State, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID WHERE (([UnitID] = @Original_UnitID) AND ([RuleID] = @Original_RuleID) AND ((@IsNull_LastService = 1 AND [LastService] IS NULL) OR ([LastService] = @Original_LastService)) AND ((@IsNull_NextDue = 1 AND [NextDue] IS NULL) OR ([NextDue] = @Original_NextDue)) AND ([Done] = @Original_Done) AND ([State] = @Original_State) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID));
SELECT UnitID, RuleID, LastService, NextDue, Done, State, Deleted, COMPANY_ID FROM LFS_FM_CHECKLIST WHERE (RuleID = @RuleID) AND (UnitID = @UnitID)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@UnitID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RuleID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RuleID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LastService", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LastService", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@NextDue", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NextDue", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Done", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Done", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@State", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "State", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_UnitID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RuleID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RuleID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_LastService", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LastService", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LastService", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LastService", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_NextDue", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NextDue", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_NextDue", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NextDue", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Done", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Done", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_State", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "State", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
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
        /// LoadByUnitId
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>data set</returns>
        public DataSet LoadByUnitIdRuleId(int unitId, int ruleId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_CHECKLISTGATEWAY_LOADBYUNITIDRULEID", new SqlParameter("@unitId", unitId),  new SqlParameter("@ruleId", ruleId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// Get a single checklist
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="ruleId">ruleId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int unitId, int ruleId)
        {
            string filter = string.Format("UnitID = {0} AND RuleID = {1}", unitId, ruleId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.FleetManagement.ChecklistRules.ChecklistGateway.GetRow");
            }
        }



        /// <summary>
        /// GetLastService
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="ruleId">ruleId</param>
        /// <returns>LastService or null</returns>
        public DateTime? GetLastService(int unitId, int ruleId)
        {
            if (GetRow(unitId, ruleId).IsNull("LastService"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(unitId, ruleId)["LastService"];
            }
        }



        /// <summary>
        /// GetNextDue
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="ruleId">ruleId</param>
        /// <returns>NextDue or null</returns>
        public DateTime? GetNextDue(int unitId, int ruleId)
        {
            if (GetRow(unitId, ruleId).IsNull("NextDue"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(unitId, ruleId)["NextDue"];
            }
        }



        /// <summary>
        /// GetState
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="ruleId">ruleId</param>
        /// <returns>State or EMPTY</returns>
        public string GetState(int unitId, int ruleId)
        {
            if (GetRow(unitId, ruleId).IsNull("State"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(unitId, ruleId)["State"];
            }
        }



        /// <summary>
        /// GetDone
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="ruleId">ruleId</param>
        /// <returns>Done or EMPTY</returns>
        public Boolean GetDone(int unitId, int ruleId)
        {
            return (bool)GetRow(unitId, ruleId)["Done"];
        }





                       
        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROW
        //

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="ruleId">ruleId</param>
        /// <param name="lastService">lastService</param>
        /// <param name="nextDue">nextDue</param>
        /// <param name="done">done</param>
        /// <param name="state">state</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void Insert(int unitId, int ruleId, DateTime? lastService, DateTime? nextDue, bool done, string state, bool deleted, int companyId)
        {
            SqlParameter unitIdParameter = new SqlParameter("UnitID", unitId);
            SqlParameter ruleIdParameter = new SqlParameter("RuleID", ruleId);
            SqlParameter lastServiceParameter = (lastService.HasValue) ? new SqlParameter("LastService", lastService) : new SqlParameter("LastService", DBNull.Value);
            SqlParameter nextDueParameter = (nextDue.HasValue) ? new SqlParameter("NextDue", nextDue) : new SqlParameter("NextDue", DBNull.Value);
            SqlParameter doneParameter = new SqlParameter("Done", done);
            SqlParameter stateParameter = new SqlParameter("State", state);
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            
            string command = "INSERT INTO [dbo].[LFS_FM_CHECKLIST] ([UnitID], [RuleID], [LastService], [NextDue], [Done], [State], [Deleted], [COMPANY_ID]) VALUES (@UnitID, @RuleID, @LastService, @NextDue, @Done, @State, @Deleted, @COMPANY_ID)";

            ExecuteScalar(command, unitIdParameter, ruleIdParameter, lastServiceParameter, nextDueParameter, doneParameter, stateParameter, deletedParameter, companyIdParameter);            
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="originalUnitId">originalUnitId</param>
        /// <param name="originalRuleId">originalRuleId</param>
        /// <param name="originalLastService">originalLastService</param>
        /// <param name="originalNextDue">originalNextDue</param>
        /// <param name="originalDone">originalDone</param>
        /// <param name="originalState">originalState</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="newUnitId">newUnitId</param>
        /// <param name="newRuleId">newRuleId</param>
        /// <param name="newLastService">newLastService</param>
        /// <param name="newNextDue">newNextDue</param>
        /// <param name="newDone">newDone</param>
        /// <param name="newState">newState</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        public void Update(int originalUnitId, int originalRuleId, DateTime? originalLastService, DateTime? originalNextDue, bool originalDone, string originalState, bool originalDeleted, int originalCompanyId, int newUnitId, int newRuleId, DateTime? newLastService, DateTime? newNextDue, bool newDone, string newState, bool newDeleted, int newCompanyId)
        {
            SqlParameter originalUnitIdParameter = new SqlParameter("Original_UnitID", originalUnitId);
            SqlParameter originalRuleIdParameter = new SqlParameter("Original_RuleId", originalRuleId);
            SqlParameter originalLastServiceParameter = (originalLastService.HasValue) ? new SqlParameter("Original_LastService", originalLastService) : new SqlParameter("Original_LastService", DBNull.Value);
            SqlParameter originalNextDueParameter = (originalNextDue.HasValue) ? new SqlParameter("Original_NextDue", originalNextDue) : new SqlParameter("Original_NextDue", DBNull.Value);
            SqlParameter originalDoneParameter = new SqlParameter("Original_Done", originalDone);
            SqlParameter originalStateParameter = new SqlParameter("Original_State", originalState);
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);

            SqlParameter newUnitIdParameter = new SqlParameter("UnitID", newUnitId);
            SqlParameter newRuleIdParameter = new SqlParameter("RuleId", newRuleId);
            SqlParameter newLastServiceParameter = (newLastService.HasValue) ? new SqlParameter("LastService", newLastService) : new SqlParameter("LastService", DBNull.Value);
            SqlParameter newNextDueParameter = (newNextDue.HasValue) ? new SqlParameter("NextDue", newNextDue) : new SqlParameter("NextDue", DBNull.Value);
            SqlParameter newDoneParameter = new SqlParameter("Done", newDone);
            SqlParameter newStateParameter = new SqlParameter("State", newState);
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);

            string command = "UPDATE [dbo].[LFS_FM_CHECKLIST] SET [UnitID] = @UnitID, [RuleID] = @RuleID, [LastService] = @LastService, [NextDue] = @NextDue, [Done] = @Done, [State] = @State, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID " +
                             "WHERE (([UnitID] = @Original_UnitID) AND ([RuleID] = @Original_RuleID) " +
                             "AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalUnitIdParameter, originalRuleIdParameter, originalLastServiceParameter, originalNextDueParameter, originalDoneParameter, originalStateParameter, originalDeletedParameter, originalCompanyIdParameter, newUnitIdParameter, newRuleIdParameter, newLastServiceParameter, newNextDueParameter, newDoneParameter, newStateParameter, newDeletedParameter, newCompanyIdParameter);
            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }            
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <param name="unitId">unitId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="newState">newState</param>
        public void UpdateState(int ruleId, int unitId, int companyId, string newState)
        {
            SqlParameter ruleIdParameter = new SqlParameter("RuleID", ruleId);
            SqlParameter unitIdParameter = new SqlParameter("UnitID", unitId);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            SqlParameter newStateParameter = new SqlParameter("State", newState);

            string command = "UPDATE [dbo].[LFS_FM_CHECKLIST] SET  [State] = @State WHERE (([RuleID] = @RuleID) AND ([UnitID] = @UnitID) AND ([COMPANY_ID] = @COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, ruleIdParameter, unitIdParameter, companyIdParameter, newStateParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <param name="unitId">unitId</param>
        /// <param name="companyId">companyId</param>
        public void Delete(int ruleId, int unitId, int companyId)
        {
            SqlParameter ruleIdParameter = new SqlParameter("RuleID", ruleId);
            SqlParameter unitIdParameter = new SqlParameter("UnitID", unitId);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_FM_CHECKLIST] SET  [Deleted] = @Deleted WHERE (([RuleID] = @RuleID) AND ([UnitID] = @UnitID) AND ([COMPANY_ID] = @COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, ruleIdParameter, unitIdParameter, companyIdParameter, deletedParameter);

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
            SqlParameter ruleIdParameter = new SqlParameter("RuleID", ruleId);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_FM_CHECKLIST] SET  [Deleted] = @Deleted WHERE (([RuleID] = @RuleID) AND ([COMPANY_ID] = @COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, ruleIdParameter, companyIdParameter, deletedParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }
        }



        /// <summary>
        /// DeleteByUnitId
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteByUnitId(int unitId, int companyId)
        {
            SqlParameter unitIdParameter = new SqlParameter("UnitID", unitId);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_FM_CHECKLIST] SET  [Deleted] = @Deleted WHERE (([UnitID] = @UnitID) AND ([COMPANY_ID] = @COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, unitIdParameter, companyIdParameter, deletedParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }
        }



        /// <summary>
        /// UnDelete
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <param name="unitId">unitId</param>
        /// <param name="companyId">companyId</param>
        public void UnDelete(int ruleId, int unitId, int companyId)
        {
            SqlParameter ruleIdParameter = new SqlParameter("RuleID", ruleId);
            SqlParameter unitIdParameter = new SqlParameter("UnitID", unitId);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", SqlDbType.Bit);
            deletedParameter.Value = 0;

            string command = "UPDATE [dbo].[LFS_FM_CHECKLIST] SET  [Deleted] = @Deleted WHERE (([RuleID] = @RuleID) AND ([UnitID] = @UnitID) AND ([COMPANY_ID] = @COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, ruleIdParameter, unitIdParameter, companyIdParameter, deletedParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }
        }



        /// <summary>
        /// IsUnitUsedInChecklist
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns></returns>
        public bool IsUnitUsedInChecklist(int unitId)
        {
            string commandText = "SELECT COUNT(*) FROM LFS_FM_CHECKLIST WHERE (UnitID = @unitId) AND (Deleted = 0)";
            SqlCommand command = new SqlCommand(commandText, DB.Connection);
            command.Parameters.Add(new SqlParameter("@unitId", unitId));         

            return ((int)ExecuteScalar(command) > 0) ? true : false;
        }



        /// <summary>
        /// IsRuleUsedInChecklist
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <returns></returns>
        public bool IsRuleUsedInChecklist(int ruleId)
        {
            string commandText = "SELECT COUNT(*) FROM LFS_FM_CHECKLIST WHERE (RuleID = @ruleId)";
            SqlCommand command = new SqlCommand(commandText, DB.Connection);
            command.Parameters.Add(new SqlParameter("@ruleId", ruleId));

            return ((int)ExecuteScalar(command) > 0) ? true : false;
        }



        /// <summary>
        /// IsUsedInChecklist
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="ruleId">ruleId</param>
        /// <returns></returns>
        public bool IsUsedInChecklist(int unitId, int ruleId)
        {
            string commandText = "SELECT COUNT(*) FROM LFS_FM_CHECKLIST WHERE (UnitID = @unitId) AND (RuleID = @ruleId) AND (Deleted = 0)";
            SqlCommand command = new SqlCommand(commandText, DB.Connection);
            command.Parameters.Add(new SqlParameter("@unitId", unitId));
            command.Parameters.Add(new SqlParameter("@ruleId", ruleId));

            return ((int)ExecuteScalar(command) > 0) ? true : false;
        }



        /// <summary>
        /// IsUsedInChecklist
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="ruleId">ruleId</param>
        /// <param name="deleted">deleted</param>
        /// <returns></returns>
        public bool IsUsedInChecklist(int unitId, int ruleId, bool deleted)
        {
            string commandText = "SELECT COUNT(*) FROM LFS_FM_CHECKLIST WHERE (UnitID = @unitId) AND (RuleID = @ruleId)";
            SqlCommand command = new SqlCommand(commandText, DB.Connection);
            command.Parameters.Add(new SqlParameter("@unitId", unitId));
            command.Parameters.Add(new SqlParameter("@ruleId", ruleId));

            return ((int)ExecuteScalar(command) > 0) ? true : false;
        }

       
 
    }
}