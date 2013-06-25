using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.FleetManagement.Common
{
    /// <summary>
    /// FmViewConditionGateway
    /// </summary>
    public class FmViewConditionGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public FmViewConditionGateway()
            : base("LFS_FM_VIEW_CONDITION")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public FmViewConditionGateway(DataSet data)
            : base(data, "LFS_FM_VIEW_CONDITION")
        {
        }



        /// <summary>
        /// InitData. 
        /// </summary>
        protected override void InitData()
        {
            _data = new FmViewTDS();
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
            tableMapping.DataSetTable = "LFS_FM_VIEW_CONDITION";
            tableMapping.ColumnMappings.Add("ViewID", "ViewID");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("FmType", "FmType");
            tableMapping.ColumnMappings.Add("ConditionID", "ConditionID");
            tableMapping.ColumnMappings.Add("RefID", "RefID");
            tableMapping.ColumnMappings.Add("Operator", "Operator");
            tableMapping.ColumnMappings.Add("ConditionNumber", "ConditionNumber");
            tableMapping.ColumnMappings.Add("Value_", "Value_");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = @"DELETE FROM [dbo].[LFS_FM_VIEW_CONDITION] WHERE (([ViewID] = @Original_ViewID) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND ([FmType] = @Original_FmType) AND ([ConditionID] = @Original_ConditionID) AND ([RefID] = @Original_RefID) AND ([Operator] = @Original_Operator) AND ([ConditionNumber] = @Original_ConditionNumber) AND ((@IsNull_Value_ = 1 AND [Value_] IS NULL) OR ([Value_] = @Original_Value_)) AND ([Deleted] = @Original_Deleted))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ViewID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ViewID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_FmType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FmType", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ConditionID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ConditionID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RefID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RefID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Operator", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Operator", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ConditionNumber", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ConditionNumber", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Value_", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Value_", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Value_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Value_", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            
            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_FM_VIEW_CONDITION] ([ViewID], [COMPANY_ID], [FmType], [ConditionID], [RefID], [Operator], [ConditionNumber], [Value_], [Deleted]) VALUES (@ViewID, @COMPANY_ID, @FmType, @ConditionID, @RefID, @Operator, @ConditionNumber, @Value_, @Deleted);
SELECT ViewID, COMPANY_ID, FmType, ConditionID, RefID, Operator, ConditionNumber, Value_, Deleted FROM LFS_FM_VIEW_CONDITION WHERE (COMPANY_ID = @COMPANY_ID) AND (ConditionID = @ConditionID) AND (RefID = @RefID) AND (ViewID = @ViewID) AND (FmType = @FmType)";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ViewID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ViewID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@FmType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FmType", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ConditionID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ConditionID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RefID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RefID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Operator", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Operator", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ConditionNumber", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ConditionNumber", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Value_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Value_", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));

            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = @"UPDATE [dbo].[LFS_FM_VIEW_CONDITION] SET [ViewID] = @ViewID, [COMPANY_ID] = @COMPANY_ID, [FmType] = @FmType, [ConditionID] = @ConditionID, [RefID] = @RefID, [Operator] = @Operator, [ConditionNumber] = @ConditionNumber, [Value_] = @Value_, [Deleted] = @Deleted WHERE (([ViewID] = @Original_ViewID) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND ([FmType] = @Original_FmType) AND ([ConditionID] = @Original_ConditionID) AND ([RefID] = @Original_RefID) AND ([Operator] = @Original_Operator) AND ([ConditionNumber] = @Original_ConditionNumber) AND ((@IsNull_Value_ = 1 AND [Value_] IS NULL) OR ([Value_] = @Original_Value_)) AND ([Deleted] = @Original_Deleted));
SELECT ViewID, COMPANY_ID, FmType, ConditionID, RefID, Operator, ConditionNumber, Value_, Deleted FROM LFS_FM_VIEW_CONDITION WHERE (COMPANY_ID = @COMPANY_ID) AND (ConditionID = @ConditionID) AND (RefID = @RefID) AND (ViewID = @ViewID) AND (FmType = @FmType)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ViewID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ViewID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@FmType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FmType", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ConditionID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ConditionID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RefID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RefID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Operator", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Operator", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ConditionNumber", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ConditionNumber", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Value_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Value_", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ViewID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ViewID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_FmType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FmType", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ConditionID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ConditionID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RefID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RefID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Operator", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Operator", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ConditionNumber", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ConditionNumber", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Value_", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Value_", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Value_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Value_", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //
        
        /// <summary>
        /// LoadAllByViewIdFmTypeConditionIdRefId
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="fmType">fmType</param>
        /// <param name="conditionId">conditionId</param>
        /// <param name="refId">refId</param>
        /// <returns></returns>
        public DataSet LoadAllByViewIdFmTypeConditionIdRefId(int viewId, int companyId, string fmType, int conditionId, int refId)
        {
            FillDataWithStoredProcedure("LFS_FM_FMVIEWCONDITIONGATEWAY_LOADALLBYVIEWIDFMTYPECONDITIONIDREFID", new SqlParameter("@viewId", viewId), new SqlParameter("@companyId", companyId), new SqlParameter("@fmType", fmType), new SqlParameter("@conditionId", conditionId), new SqlParameter("@refId", refId));
            return Data;
        }



        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="conditionId">conditionId</param>
        /// <param name="refId">refId</param>
        /// <returns></returns>
        public DataRow GetRow(int viewId, string fmType, int companyId, int conditionId, int refId)
        {
            string filter = string.Format("ViewID = {0} AND FmType = '{1}' AND COMPANY_ID = {2} AND ConditionID = {3} AND RefID = {4}", viewId, fmType, companyId, conditionId, refId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.FleetManagement.Common.FmViewConditionGateway.GetRow");
            }
        }

        

        /// <summary>
        /// GetCompanyId
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="condtionId">condtionId</param>
        /// <param name="refId">refId</param>
        /// <returns>COMPANY_ID</returns>
        public int GetCompanyId(int viewId, string fmType, int companyId, int condtionId, int refId)
        {
            return (int)GetRow(viewId, fmType, companyId, condtionId, refId)["COMPANY_ID"];
        }



        /// <summary>
        /// GetWorkType
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="condtionId">condtionId</param>
        /// <param name="refId">refId</param>
        /// <returns>WorkType</returns>
        public string GetWorkType(int viewId, string fmType, int companyId, int condtionId, int refId)
        {
            return (string)GetRow(viewId, fmType, companyId, condtionId, refId)["WorkType"];
        }



        /// <summary>
        /// GetConditionId
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="condtionId">condtionId</param>
        /// <param name="refId">refId</param>
        /// <returns>ConditionId</returns>
        public int GetConditionId(int viewId, string fmType, int companyId, int condtionId, int refId)
        {
            return (int)GetRow(viewId, fmType, companyId, condtionId, refId)["ConditionID"];
        }



        /// <summary>
        /// GetRefId
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="condtionId">condtionId</param>
        /// <param name="refId">refId</param>
        /// <returns>RefId</returns>
        public int GetRefId(int viewId, string fmType, int companyId, int condtionId, int refId)
        {
            return (int)GetRow(viewId, fmType, companyId, condtionId, refId)["RefID"];
        }



        /// <summary>
        /// GetOperator
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="condtionId">condtionId</param>
        /// <param name="refId">refId</param>
        /// <returns>Operator</returns>
        public string GetOperator(int viewId, string fmType, int companyId, int condtionId, int refId)
        {
            return (string)GetRow(viewId, fmType, companyId, condtionId, refId)["Operator"];
        }



        /// <summary>
        /// GetConditionNumber
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="condtionId">condtionId</param>
        /// <param name="refId">refId</param>
        /// <returns>ConditionNumber</returns>
        public int GetConditionNumber(int viewId, string fmType, int companyId, int condtionId, int refId)
        {
            return (int)GetRow(viewId, fmType, companyId, condtionId, refId)["ConditionNumber"];
        }



        /// <summary>
        /// GetValue_
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="condtionId">condtionId</param>
        /// <param name="refId">refId</param>
        /// <returns>Value_</returns>
        public string GetValue_(int viewId, string fmType, int companyId, int condtionId, int refId)
        {
            return (string)GetRow(viewId, fmType, companyId, condtionId, refId)["Value_"];
        }



        /// <summary>
        /// GetDeleted
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="condtionId">condtionId</param>
        /// <param name="refId">refId</param>
        /// <returns>Deleted</returns>
        public bool GetDeleted(int viewId, string fmType, int companyId, int condtionId, int refId)
        {
            return (bool)GetRow(viewId, fmType, companyId, condtionId, refId)["Deleted"];
        }



                


        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROWS
        //

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="originalCompanyId">COMPANY_ID</param>
        /// <returns>int</returns>
        public void Delete(int viewId, int companyId)
        {
            SqlParameter viewIdParameter = new SqlParameter("ViewID", viewId);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_FM_VIEW_CONDITION] " +
                             "SET " +
                             "[Deleted] = @Deleted " +
                             " WHERE (([ViewID] = @ViewID) AND " +
                             "([COMPANY_ID] = @COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, viewIdParameter, companyIdParameter, deletedParameter);
        }



        /// <summary>
        /// DeleteForEditView
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="fmType">fmType</param>
        /// <param name="conditionId">conditionId</param>
        /// <param name="refId">refId</param>
        public void DeleteForEditView(int viewId, int companyId, string fmType, int conditionId, int refId)
        {
            SqlParameter viewIdParameter = new SqlParameter("ViewID", viewId);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            SqlParameter fmTypeParameter = new SqlParameter("FmType", fmType);
            SqlParameter conditionIdParameter = new SqlParameter("ConditionID", conditionId);
            SqlParameter refIdParameter = new SqlParameter("RefID", refId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_FM_VIEW_CONDITION] " +
                             "SET " +
                             "[Deleted] = @Deleted " +
                             " WHERE (([ViewID] = @ViewID) AND " +
                             "([COMPANY_ID] = @COMPANY_ID) AND ([FmType] = @FmType) AND ([ConditionID] = @ConditionID) AND ([RefID] = @RefID))";

            int rowsAffected = (int)ExecuteNonQuery(command, viewIdParameter, companyIdParameter, fmTypeParameter, conditionIdParameter, refIdParameter, deletedParameter);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="originalViewId">originalViewId</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalFmType">originalFmType</param>
        /// <param name="originalConditionId">originalConditionId</param>
        /// <param name="originalRefId">originalRefId</param>
        /// <param name="originalOperator">originalOperator</param>
        /// <param name="originalConditionNumber">originalConditionNumber</param>
        /// <param name="originalValue_">originalValue_</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="newViewId">newViewId</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newfmType">newfmType</param>
        /// <param name="newConditionId">newConditionId</param>
        /// <param name="newRefId">newRefId</param>
        /// <param name="newOperator">newOperator</param>
        /// <param name="newConditionNumber">newConditionNumber</param>
        /// <param name="newValue_">newValue_</param>
        /// <param name="newDeleted">newDeleted</param>
        public void Update(int originalViewId, int originalCompanyId, string originalFmType, int originalConditionId, int originalRefId, string originalOperator, int originalConditionNumber, string originalValue_, bool originalDeleted, int newViewId, int newCompanyId, string newFmType, int newConditionId, int newRefId, string newOperator, int newConditionNumber, string newValue_, bool newDeleted)
        {
            SqlParameter originalViewIdParameter = new SqlParameter("Original_ViewID", originalViewId);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter originalFmTypeParameter = new SqlParameter("Original_FmType", originalFmType);            
            SqlParameter originalConditionIdParameter = new SqlParameter("Original_ConditionID", originalConditionId);
            SqlParameter originalRefIdParameter = new SqlParameter("Original_RefID", originalRefId);
            SqlParameter originalOperatorParameter = new SqlParameter("Original_Operator", originalOperator);
            SqlParameter originalConditionNumberParameter = new SqlParameter("Original_ConditionNumber", originalConditionNumber);
            SqlParameter originalValue_Parameter = new SqlParameter("Original_Value_", originalValue_);
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);

            SqlParameter newViewIdParameter = new SqlParameter("ViewID", newViewId);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);
            SqlParameter newFmTypeParameter = new SqlParameter("FmType", newFmType);
            SqlParameter newConditionIdParameter = new SqlParameter("ConditionID", newConditionId);
            SqlParameter newRefIdParameter = new SqlParameter("RefID", newRefId);
            SqlParameter newOperatorParameter = new SqlParameter("Operator", newOperator);
            SqlParameter newConditionNumberParameter = new SqlParameter("ConditionNumber", newConditionNumber);
            SqlParameter newValue_Parameter = new SqlParameter("Value_", newValue_);
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);

            string command = "UPDATE [dbo].[LFS_FM_VIEW_CONDITION] " +
                             "SET [ViewID] = @ViewID, [COMPANY_ID] = @COMPANY_ID, [FmType] = @FmType, [ConditionID] = @ConditionID, [RefID] = @RefID, [Operator] = @Operator, [ConditionNumber] = @ConditionNumber, [Value_] = @Value_, [Deleted] = @Deleted  " +
                             "WHERE (([ViewID] = @Original_ViewID) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND ([FmType] = @Original_FmType) AND ([ConditionID] = @Original_ConditionID) AND ([RefID] = @Original_RefID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalViewIdParameter, originalCompanyIdParameter, originalFmTypeParameter, originalConditionIdParameter, originalRefIdParameter, originalOperatorParameter, originalConditionNumberParameter, originalValue_Parameter, originalDeletedParameter, newViewIdParameter, newCompanyIdParameter, newFmTypeParameter, newConditionIdParameter, newRefIdParameter, newOperatorParameter, newConditionNumberParameter, newValue_Parameter, newDeletedParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="fmType">fmType</param>
        /// <param name="conditionId">conditionId</param>
        /// <param name="refId">refId</param>
        /// <param name="operator_">operator_</param>
        /// <param name="conditionNumber">conditionNumber</param>
        /// <param name="value_">value_</param>
        /// <param name="deleted">deleted</param>
        public void Insert(int viewId, int companyId, string fmType, int conditionId, int refId, string operator_, int conditionNumber, string value_, bool deleted)
        {
            SqlParameter viewIdParameter = new SqlParameter("ViewID", viewId);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            SqlParameter fmTypeParameter = new SqlParameter("FmType", fmType);            
            SqlParameter conditionIdParameter = new SqlParameter("ConditionID", conditionId);
            SqlParameter refIdParameter = new SqlParameter("RefID", refId);
            SqlParameter operatorParameter = new SqlParameter("Operator", operator_);
            SqlParameter conditionNumberParameter = new SqlParameter("ConditionNumber", conditionNumber);
            SqlParameter value_Parameter = new SqlParameter("Value_", value_);
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);

            string command = "INSERT INTO [dbo].[LFS_FM_VIEW_CONDITION] ([ViewID], [COMPANY_ID], [FmType], [ConditionID], [RefID], [Operator], [ConditionNumber], [Value_], [Deleted]) VALUES (@ViewID, @COMPANY_ID, @FmType, @ConditionID, @RefID, @Operator, @ConditionNumber, @Value_, @Deleted)";

            ExecuteScalar(command, viewIdParameter, companyIdParameter, fmTypeParameter, conditionIdParameter, refIdParameter, operatorParameter, conditionNumberParameter, value_Parameter, deletedParameter);
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - QUERIES
        //

        /// <summary>
        /// GetLastRefIdByViewIdCompanyIdFmTypeConditionId
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="fmType">fmType</param>
        /// <param name="condtionId">condtionId</param>
        /// <returns></returns>
        public int GetLastRefIdByViewIdCompanyIdFmTypeConditionId(int viewId, int companyId, string fmType, int condition_Id)
        {
            string commandText = String.Format("SELECT MAX(RefID) FROM LFS_FM_VIEW_CONDITION WHERE (ViewID = {0}) AND (COMPANY_ID = {1}) AND (FmType = '{2}') AND (ConditionID = {3})", viewId, companyId, fmType, condition_Id);
            SqlCommand command = new SqlCommand(commandText, DB.Connection);
            object lastRefId = ExecuteScalar(command);

            return (lastRefId != DBNull.Value) ? (int)lastRefId : 0;
        }



    }
}