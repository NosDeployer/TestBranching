using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.Common
{
    /// <summary>
    /// WorkViewDisplayGateway
    /// </summary>
    public class WorkViewDisplayGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public WorkViewDisplayGateway()
            : base("LFS_WORK_VIEW_DISPLAY")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public WorkViewDisplayGateway(DataSet data)
            : base(data, "LFS_WORK_VIEW_DISPLAY")
        {
        }



        /// <summary>
        /// InitData. 
        /// </summary>
        protected override void InitData()
        {
            _data = new WorkViewTDS();
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
            tableMapping.DataSetTable = "LFS_WORK_VIEW_DISPLAY";
            tableMapping.ColumnMappings.Add("ViewID", "ViewID");
            tableMapping.ColumnMappings.Add("WorkType", "WorkType");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("DisplayID", "DisplayID");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[LFS_WORK_VIEW_DISPLAY] WHERE (([ViewID] = @Original_ViewID) AN" +
                "D ([WorkType] = @Original_WorkType) AND ([COMPANY_ID] = @Original_COMPANY_ID) AN" +
                "D ([DisplayID] = @Original_DisplayID) AND ([Deleted] = @Original_Deleted))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ViewID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ViewID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_WorkType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkType", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DisplayID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DisplayID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            
            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_WORK_VIEW_DISPLAY] ([ViewID], [WorkType], [COMPANY_ID], [DisplayID], [Deleted]) VALUES (@ViewID, @WorkType, @COMPANY_ID, @DisplayID, @Deleted);
SELECT ViewID, WorkType, COMPANY_ID, DisplayID, Deleted FROM LFS_WORK_VIEW_DISPLAY WHERE (COMPANY_ID = @COMPANY_ID) AND (DisplayID = @DisplayID) AND (ViewID = @ViewID) AND (WorkType = @WorkType)";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ViewID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ViewID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@WorkType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkType", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DisplayID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DisplayID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));

            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = @"UPDATE [dbo].[LFS_WORK_VIEW_DISPLAY] SET [ViewID] = @ViewID, [WorkType] = @WorkType, [COMPANY_ID] = @COMPANY_ID, [DisplayID] = @DisplayID, [Deleted] = @Deleted WHERE (([ViewID] = @Original_ViewID) AND ([WorkType] = @Original_WorkType) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND ([DisplayID] = @Original_DisplayID) AND ([Deleted] = @Original_Deleted));
SELECT ViewID, WorkType, COMPANY_ID, DisplayID, Deleted FROM LFS_WORK_VIEW_DISPLAY WHERE (COMPANY_ID = @COMPANY_ID) AND (DisplayID = @DisplayID) AND (ViewID = @ViewID) AND (WorkType = @WorkType)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ViewID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ViewID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@WorkType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkType", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DisplayID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DisplayID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ViewID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ViewID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_WorkType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkType", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DisplayID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DisplayID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// LoadByViewIdWorkType
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <returns></returns>
        public DataSet LoadByViewIdWorkType(int viewId, string workType, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_WORKVIEWDISPLAYGATEWAY_LOADBYVIEWIDWORKTYPE", new SqlParameter("@viewId", viewId), new SqlParameter("@workType", workType), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadAllByViewIdWorkTypeDisplayId
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="displayId">displayId</param>
        /// <returns></returns>
        public DataSet LoadAllByViewIdWorkTypeDisplayId(int viewId, string workType, int companyId, int displayId)
        {
            FillDataWithStoredProcedure("LFS_CWP_WORKVIEWDISPLAYGATEWAY_LOADALLBYVIEWIDWORKTYPEDISPLAYID", new SqlParameter("@viewId", viewId), new SqlParameter("@workType", workType), new SqlParameter("@companyId", companyId), new SqlParameter("@displayId", displayId));
            return Data;
        }



        /// <summary>
        /// LoadByViewIdWorkTypeDisplayId
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="displayId">displayId</param>
        /// <returns></returns>
        public DataSet LoadByViewIdWorkTypeDisplayId(int viewId, string workType, int companyId, int displayId)
        {
            FillDataWithStoredProcedure("LFS_CWP_WORKVIEWDISPLAYGATEWAY_LOADBYVIEWIDWORKTYPEDISPLAYID", new SqlParameter("@viewId", viewId), new SqlParameter("@workType", workType), new SqlParameter("@companyId", companyId), new SqlParameter("@displayId", displayId));
            return Data;
        }



        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="displayId">displayId</param>
        /// <returns></returns>
        public DataRow GetRow(int viewId, string workType, int companyId, int displayId)
        {
            string filter = string.Format("ViewID = {0} AND WorkType = '{1}' AND COMPANY_ID = {2} AND DisplayID = {3}", viewId, workType, companyId, displayId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.CWP.Common.WorkViewDisplayGateway.GetRow");
            }
        }



        /// <summary>
        /// GetWorkType
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="displayId">displayId</param>
        /// <returns>WorkType</returns>
        public string GetWorkType(int viewId, string workType, int companyId, int displayId)
        {
            return (string)GetRow(viewId, workType, companyId, displayId)["WorkType"];
        }



        /// <summary>
        /// GetDeleted
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="displayId">displayId</param>
        /// <returns>Deleted</returns>
        public bool GetDeleted(int viewId, string workType, int companyId, int displayId)
        {
            return (bool)GetRow(viewId, workType, companyId, displayId)["Deleted"];
        }


        /// <summary>
        /// GetCompanyId
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="displayId">displayId</param>
        /// <returns>COMPANY_ID</returns>
        public int GetCompanyId(int viewId, string workType, int companyId, int displayId)
        {
            return (int)GetRow(viewId, workType, companyId, displayId)["COMPANY_ID"];
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROWS
        //

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>int</returns>
        public void Delete(int viewId, int companyId)
        {
            SqlParameter viewIdParameter = new SqlParameter("ViewID", viewId);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_WORK_VIEW_DISPLAY] " +
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
        /// DeleteForEditView
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="displayId">displayId</param>
        public void DeleteForEditView(int viewId, string workType, int companyId, int displayId)
        {
            SqlParameter viewIdParameter = new SqlParameter("ViewID", viewId);
            SqlParameter workTypeParameter = new SqlParameter("WorkType", workType);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            SqlParameter displayIdParameter = new SqlParameter("DisplayID", displayId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_WORK_VIEW_DISPLAY] " +
                             "SET " +
                             "[Deleted] = @Deleted " +
                             " WHERE (([ViewID] = @ViewID) AND ([WorkType] = @WorkType) AND " +
                             "([COMPANY_ID] = @COMPANY_ID) AND ([DisplayID] = @DisplayID))";

            int rowsAffected = (int)ExecuteNonQuery(command, viewIdParameter, workTypeParameter, companyIdParameter, displayIdParameter, deletedParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="displayId">displayId</param>
        /// <param name="deleted">deleted</param>
        public void Insert(int viewId, string workType, int companyId, int displayId, bool deleted)
        {
            SqlParameter viewIdParameter = new SqlParameter("ViewID", viewId);
            SqlParameter workTypeParameter = new SqlParameter("WorkType", workType);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            SqlParameter displayIdParameter = new SqlParameter("DisplayID", displayId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);

            string command = "INSERT INTO [dbo].[LFS_WORK_VIEW_DISPLAY] ([ViewID], [WorkType], [COMPANY_ID], [DisplayID], [Deleted]) VALUES (@ViewID, @WorkType, @COMPANY_ID, @DisplayID, @Deleted)";

            ExecuteScalar(command, viewIdParameter, workTypeParameter, companyIdParameter, displayIdParameter, deletedParameter);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="originalViewId">originalViewId</param>
        /// <param name="originalWorkType">originalWorkType</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalDisplayId">originalDisplayId</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// 
        /// <param name="newViewId">newViewId</param>
        /// <param name="newWorkType">newWorkType</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newDisplayId">newDisplayId</param>
        /// <param name="newDeleted">newDeleted</param>
        public void Update(int originalViewId, string originalWorkType, int originalCompanyId, int originalDisplayId, bool originalDeleted, int newViewId, string newWorkType, int newCompanyId, int newDisplayId, bool newDeleted)
        {
            SqlParameter originalViewIdParameter = new SqlParameter("Original_ViewID", originalViewId);
            SqlParameter originalWorkTypeParameter = new SqlParameter("Original_WorkType", originalWorkType);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter originalDisplayIdParameter = new SqlParameter("Original_DisplayID", originalDisplayId);
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);            

            SqlParameter newViewIdParameter = new SqlParameter("ViewID", newViewId);
            SqlParameter newWorkTypeParameter = new SqlParameter("WorkType", newWorkType);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);
            SqlParameter newDisplayIdParameter = new SqlParameter("DisplayID", newDisplayId);
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);


            string command = "UPDATE [dbo].[LFS_WORK_VIEW_DISPLAY] " +
                             "SET [ViewID] = @ViewID, [WorkType] = @WorkType, [COMPANY_ID] = @COMPANY_ID, [DisplayID] = @DisplayID, [Deleted] = @Deleted  " +
                             "WHERE (([ViewID] = @Original_ViewID) AND ([WorkType] = @Original_WorkType) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND ([DisplayID] = @Original_DisplayID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalViewIdParameter, originalWorkTypeParameter, originalCompanyIdParameter, originalDisplayIdParameter, originalDeletedParameter, newViewIdParameter, newWorkTypeParameter, newCompanyIdParameter, newDisplayIdParameter, newDeletedParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }
        }
        

        
    }
}

