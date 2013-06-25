using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.FleetManagement.Common
{
    /// <summary>
    /// FmViewGateway
    /// </summary>
    public class FmViewGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public FmViewGateway()
            : base("LFS_FM_VIEW")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public FmViewGateway(DataSet data)
            : base(data, "LFS_FM_VIEW")
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
        /// InitAdapter (empty)
        /// </summary>
        protected override void InitAdapter()
        {
            #region Adapter initialization

            this._adapter = new System.Data.SqlClient.SqlDataAdapter();
            System.Data.Common.DataTableMapping tableMapping = new System.Data.Common.DataTableMapping();
            tableMapping.SourceTable = "Table";
            tableMapping.DataSetTable = "LFS_FM_VIEW";
            tableMapping.ColumnMappings.Add("ViewID", "ViewID");
            tableMapping.ColumnMappings.Add("LoginID", "LoginID");
            tableMapping.ColumnMappings.Add("Name", "Name");
            tableMapping.ColumnMappings.Add("Type", "Type");
            tableMapping.ColumnMappings.Add("Logic", "Logic");
            tableMapping.ColumnMappings.Add("SqlCommand", "SqlCommand");
            tableMapping.ColumnMappings.Add("FmType", "FmType");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = @"DELETE FROM [dbo].[LFS_FM_VIEW] WHERE (([ViewID] = @Original_ViewID) AND ((@IsNull_LoginID = 1 AND [LoginID] IS NULL) OR ([LoginID] = @Original_LoginID)) AND ((@IsNull_Name = 1 AND [Name] IS NULL) OR ([Name] = @Original_Name)) AND ((@IsNull_Type = 1 AND [Type] IS NULL) OR ([Type] = @Original_Type)) AND ((@IsNull_FmType = 1 AND [FmType] IS NULL) OR ([FmType] = @Original_FmType)) AND ((@IsNull_Deleted = 1 AND [Deleted] IS NULL) OR ([Deleted] = @Original_Deleted)) AND ((@IsNull_COMPANY_ID = 1 AND [COMPANY_ID] IS NULL) OR ([COMPANY_ID] = @Original_COMPANY_ID)))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ViewID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ViewID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_LoginID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LoginID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LoginID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LoginID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Name", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Name", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Name", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Name", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Type", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Type", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Type", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Type", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_FmType", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FmType", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_FmType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FmType", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Deleted", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            
            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_FM_VIEW] ([ViewID], [LoginID], [Name], [Type], [Logic], [SqlCommand], [FmType], [Deleted], [COMPANY_ID]) VALUES (@ViewID, @LoginID, @Name, @Type, @Logic, @SqlCommand, @FmType, @Deleted, @COMPANY_ID);
SELECT ViewID, LoginID, Name, Type, Logic, SqlCommand, FmType, Deleted, COMPANY_ID FROM LFS_FM_VIEW WHERE (ViewID = @ViewID)";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ViewID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ViewID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LoginID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LoginID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Name", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Name", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Type", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Type", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Logic", global::System.Data.SqlDbType.Text, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Logic", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@SqlCommand", global::System.Data.SqlDbType.Text, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SqlCommand", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@FmType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FmType", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));

            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = @"UPDATE [dbo].[LFS_FM_VIEW] SET [ViewID] = @ViewID, [LoginID] = @LoginID, [Name] = @Name, [Type] = @Type, [Logic] = @Logic, [SqlCommand] = @SqlCommand, [FmType] = @FmType, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID WHERE (([ViewID] = @Original_ViewID) AND ((@IsNull_LoginID = 1 AND [LoginID] IS NULL) OR ([LoginID] = @Original_LoginID)) AND ((@IsNull_Name = 1 AND [Name] IS NULL) OR ([Name] = @Original_Name)) AND ((@IsNull_Type = 1 AND [Type] IS NULL) OR ([Type] = @Original_Type)) AND ((@IsNull_FmType = 1 AND [FmType] IS NULL) OR ([FmType] = @Original_FmType)) AND ((@IsNull_Deleted = 1 AND [Deleted] IS NULL) OR ([Deleted] = @Original_Deleted)) AND ((@IsNull_COMPANY_ID = 1 AND [COMPANY_ID] IS NULL) OR ([COMPANY_ID] = @Original_COMPANY_ID)));
SELECT ViewID, LoginID, Name, Type, Logic, SqlCommand, FmType, Deleted, COMPANY_ID FROM LFS_FM_VIEW WHERE (ViewID = @ViewID)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ViewID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ViewID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LoginID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LoginID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Name", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Name", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Type", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Type", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Logic", global::System.Data.SqlDbType.Text, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Logic", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@SqlCommand", global::System.Data.SqlDbType.Text, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SqlCommand", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@FmType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FmType", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ViewID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ViewID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_LoginID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LoginID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LoginID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LoginID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Name", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Name", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Name", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Name", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Type", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Type", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Type", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Type", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_FmType", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FmType", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_FmType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FmType", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Deleted", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            
#endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// LoadByViewId
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>data set</returns>
        public DataSet LoadByViewId(int viewId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_FMVIEWGATEWAY_LOADBYVIEWID", new SqlParameter("@viewId", viewId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int viewId)
        {
            string filter = string.Format("ViewID = {0}", viewId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.FleetManagement.Common.FmViewGateway.GetRow");
            }
        }



        /// <summary>
        /// GetLoginId
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <returns>LoginID</returns>
        public int GetLoginId(int viewId)
        {
            return (int)GetRow(viewId)["LoginID"];
        }



        /// <summary>
        /// GetName. If project not exists, raise an exception.
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <returns>View name</returns>
        public string GetName(int viewId)
        {
            return (string)GetRow(viewId)["Name"];
        }



        /// <summary>
        /// GetType. If not exists, raise an exception.
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <returns>Type</returns>
        public string GetType(int viewId)
        {
            return (string)GetRow(viewId)["Type"];
        }



        /// <summary>
        /// GetLogic
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <returns>Logic</returns>
        public string GetLogic(int viewId)
        {
            if (GetRow(viewId).IsNull("Logic"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(viewId)["Logic"];
            }            
        }



        /// <summary>
        /// GetSqlCommand
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <returns>Sql Command</returns>
        public string GetSqlCommand(int viewId)
        {
            return (string)GetRow(viewId)["SqlCommand"];
        }



        /// <summary>
        /// GetFmType
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <returns>FmType</returns>
        public string GetFmType(int viewId)
        {
            return (string)GetRow(viewId)["FmType"];
        }



        /// <summary>
        /// GetDeleted
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <returns>Deleted</returns>
        public bool GetDeleted(int viewId)
        {
            return (bool)GetRow(viewId)["Deleted"];
        }


        /// <summary>
        /// GetCompanyId
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <returns>COMPANY_ID</returns>
        public int GetCompanyId(int viewId)
        {
            return (int)GetRow(viewId)["COMPANY_ID"];
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

            string command = "UPDATE [dbo].[LFS_FM_VIEW] " +
                             "SET " +
                             "[Deleted] = @Deleted " +
                             " WHERE (([ViewID] = @ViewID) AND " +
                             "([COMPANY_ID] = @COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, viewIdParameter, companyIdParameter, deletedParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="loginId">loginId</param>
        /// <param name="name">name</param>
        /// <param name="type">type</param>
        /// <param name="logic">logic</param>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="fmType">fmType</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void Insert(int viewId, int loginId, string name, string type, string logic, string sqlCommand, string fmType, bool deleted, int companyId)
        {
            SqlParameter viewIdParameter = new SqlParameter("ViewID", viewId);
            SqlParameter loginIdParameter = new SqlParameter("LoginID", loginId);
            SqlParameter nameParameter = new SqlParameter("Name", name);
            SqlParameter typeParameter = new SqlParameter("Type", type);
            SqlParameter logicParameter = (logic.Trim() != "") ? new SqlParameter("Logic", logic.Trim()) : new SqlParameter("Logic", DBNull.Value);
            SqlParameter sqlCommandParameter = new SqlParameter("SqlCommand", sqlCommand);
            SqlParameter fmTypeParameter = new SqlParameter("FmType", fmType);
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            
            string command = "INSERT INTO [dbo].[LFS_FM_VIEW] ([ViewID], [LoginID], [Name], [Type], [Logic], [SqlCommand], [FmType], [Deleted], [COMPANY_ID]) VALUES (@ViewID, @LoginID, @Name, @Type, @Logic, @SqlCommand, @FmType, @Deleted, @COMPANY_ID); SELECT ViewID FROM LFS_FM_VIEW WHERE (ViewID = SCOPE_IDENTITY())";

            ExecuteScalar(command, viewIdParameter, loginIdParameter, nameParameter, typeParameter, logicParameter, sqlCommandParameter, fmTypeParameter, deletedParameter, companyIdParameter);
            
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="originalViewId">originalViewId</param>
        /// <param name="originalLoginId">originalLoginId</param>
        /// <param name="originalName">originalName</param>
        /// <param name="originalType">originalType</param>
        /// <param name="orginalLogic">orginalLogic</param>
        /// <param name="originalSqlCommand">originalSqlCommand</param>
        /// <param name="originalFmType">originalFmType</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="newViewId">newViewId</param>
        /// <param name="newLoginId">newLoginId</param>
        /// <param name="newName">newName</param>
        /// <param name="newType">newType</param>
        /// <param name="newLogic">newLogic</param>
        /// <param name="newSqlCommand">newSqlCommand</param>
        /// <param name="newFmType">newFmType</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        public void Update(int originalViewId, int originalLoginId, string originalName, string originalType, string originalLogic, string originalSqlCommand, string originalFmType, bool originalDeleted, int originalCompanyId, int newViewId, int newLoginId, string newName, string newType, string newLogic, string newSqlCommand, string newFmType, bool newDeleted, int newCompanyId)
        {
            SqlParameter originalViewIdParameter = new SqlParameter("Original_ViewID", originalViewId);
            SqlParameter originalLoginIdParameter = new SqlParameter("Original_LoginID", originalLoginId);
            SqlParameter originalNameParameter = new SqlParameter("Original_Name", originalName);
            SqlParameter originalTypeParameter = new SqlParameter("Original_Type", originalType);
            SqlParameter originalLogicParameter = (originalLogic.Trim() != "") ? new SqlParameter("Original_Logic", originalLogic.Trim()) : new SqlParameter("Original_Logic", DBNull.Value);
            SqlParameter originalSqlCommandParameter = new SqlParameter("Original_SqlCommand", originalSqlCommand);
            SqlParameter originalFmTypeParameter = new SqlParameter("Original_FmType", originalFmType);
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);

            SqlParameter newViewIdParameter = new SqlParameter("ViewID", newViewId);
            SqlParameter newLoginIdParameter = new SqlParameter("LoginID", newLoginId);
            SqlParameter newNameParameter = new SqlParameter("Name", newName);
            SqlParameter newTypeParameter = new SqlParameter("Type", newType);
            SqlParameter newLogicParameter = (newLogic.Trim() != "") ? new SqlParameter("Logic", newLogic.Trim()) : new SqlParameter("Logic", DBNull.Value);
            SqlParameter newSqlCommandParameter = new SqlParameter("SqlCommand", newSqlCommand);
            SqlParameter newFmTypeParameter = new SqlParameter("FmType", newFmType);
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);

            string command = "UPDATE [dbo].[LFS_FM_VIEW] " +
                             "SET [ViewID] = @ViewID, [LoginID] = @LoginID, [Name] = @Name, [Type] = @Type, [Logic] = @Logic, [SqlCommand] = @SqlCommand, [FmType] = @FmType, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID " +
                             "WHERE ([ViewID] = @Original_ViewID)";

            int rowsAffected = (int)ExecuteNonQuery(command, originalViewIdParameter, originalLoginIdParameter, originalTypeParameter, originalLogicParameter, originalSqlCommandParameter, originalFmTypeParameter, originalDeletedParameter, originalCompanyIdParameter, newViewIdParameter, newLoginIdParameter, newNameParameter, newTypeParameter, newLogicParameter, newSqlCommandParameter, newFmTypeParameter, newDeletedParameter, newCompanyIdParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }
        }
        


        

        
        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - QUERIES
        //

        /// <summary>
        /// GetLastViewId 
        /// </summary>
        /// <returns>last view id</returns>
        public int GetLastViewId()
        {
            string commandText = "SELECT MAX(ViewID) FROM LFS_FM_VIEW";
            SqlCommand command = new SqlCommand(commandText, DB.Connection);
            object lastViewId = ExecuteScalar(command);

            return (lastViewId != DBNull.Value) ? (int)lastViewId : 0;
        }


        
    }
}