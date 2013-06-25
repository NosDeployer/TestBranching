using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.FleetManagement.Common
{
    /// <summary>
    /// FmViewDisplayGateway
    /// </summary>
    public class FmViewDisplayGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public FmViewDisplayGateway()
            : base("LFS_FM_VIEW_DISPLAY")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public FmViewDisplayGateway(DataSet data)
            : base(data, "LFS_FM_VIEW_DISPLAY")
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
            tableMapping.DataSetTable = "LFS_FM_VIEW_DISPLAY";
            tableMapping.ColumnMappings.Add("ViewID", "ViewID");
            tableMapping.ColumnMappings.Add("FmType", "FmType");
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
            this._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[LFS_FM_VIEW_DISPLAY] WHERE (([ViewID] = @Original_ViewID) AN" +
                "D ([FmType] = @Original_FmType) AND ([COMPANY_ID] = @Original_COMPANY_ID) AN" +
                "D ([DisplayID] = @Original_DisplayID) AND ([Deleted] = @Original_Deleted))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ViewID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ViewID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_FmType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FmType", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DisplayID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DisplayID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            
            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_FM_VIEW_DISPLAY] ([ViewID], [FmType], [COMPANY_ID], [DisplayID], [Deleted]) VALUES (@ViewID, @FmType, @COMPANY_ID, @DisplayID, @Deleted);
SELECT ViewID, FmType, COMPANY_ID, DisplayID, Deleted FROM LFS_FM_VIEW_DISPLAY WHERE (COMPANY_ID = @COMPANY_ID) AND (DisplayID = @DisplayID) AND (ViewID = @ViewID) AND (FmType = @FmType)";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ViewID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ViewID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@FmType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FmType", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DisplayID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DisplayID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));

            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = @"UPDATE [dbo].[LFS_FM_VIEW_DISPLAY] SET [ViewID] = @ViewID, [FmType] = @FmType, [COMPANY_ID] = @COMPANY_ID, [DisplayID] = @DisplayID, [Deleted] = @Deleted WHERE (([ViewID] = @Original_ViewID) AND ([FmType] = @Original_FmType) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND ([DisplayID] = @Original_DisplayID) AND ([Deleted] = @Original_Deleted));
SELECT ViewID, FmType, COMPANY_ID, DisplayID, Deleted FROM LFS_FM_VIEW_DISPLAY WHERE (COMPANY_ID = @COMPANY_ID) AND (DisplayID = @DisplayID) AND (ViewID = @ViewID) AND (FmType = @FmType)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ViewID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ViewID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@FmType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FmType", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DisplayID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DisplayID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ViewID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ViewID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_FmType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FmType", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DisplayID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DisplayID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// LoadByViewIdFmType
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        /// <returns></returns>
        public DataSet LoadByViewIdFmType(int viewId, string fmType, int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_FMVIEWDISPLAYGATEWAY_LOADBYVIEWIDFMTYPE", new SqlParameter("@viewId", viewId), new SqlParameter("@fmType", fmType), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadAllByViewIdFmTypeDisplayId
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="displayId">displayId</param>
        /// <returns></returns>
        public DataSet LoadAllByViewIdFmTypeDisplayId(int viewId, string fmType, int companyId, int displayId)
        {
            FillDataWithStoredProcedure("LFS_FM_FMVIEWDISPLAYGATEWAY_LOADALLBYVIEWIDFMTYPEDISPLAYID", new SqlParameter("@viewId", viewId), new SqlParameter("@fmType", fmType), new SqlParameter("@companyId", companyId), new SqlParameter("@displayId", displayId));
            return Data;
        }



        /// <summary>
        /// LoadByViewIdFmTypeDisplayId
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="displayId">displayId</param>
        /// <returns></returns>
        public DataSet LoadByViewIdFmTypeDisplayId(int viewId, string fmType, int companyId, int displayId)
        {
            FillDataWithStoredProcedure("LFS_FM_FMVIEWDISPLAYGATEWAY_LOADBYVIEWIDFMTYPEDISPLAYID", new SqlParameter("@viewId", viewId), new SqlParameter("@fmType", fmType), new SqlParameter("@companyId", companyId), new SqlParameter("@displayId", displayId));
            return Data;
        }



        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="displayId">displayId</param>
        /// <returns></returns>
        public DataRow GetRow(int viewId, string fmType, int companyId, int displayId)
        {
            string filter = string.Format("ViewID = {0} AND FmType = '{1}' AND COMPANY_ID = {2} AND DisplayID = {3}", viewId, fmType, companyId, displayId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.FleetManagement.Common.FmViewDisplayGateway.GetRow");
            }
        }



        /// <summary>
        /// GetFmType
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <returns>fmType</returns>
        public string GetFmType(int viewId, string fmType, int companyId, int displayId)
        {
            return (string)GetRow(viewId, fmType, companyId, displayId)["FmType"];
        }



        /// <summary>
        /// GetDeleted
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <returns>Deleted</returns>
        public bool GetDeleted(int viewId, string fmType, int companyId, int displayId)
        {
            return (bool)GetRow(viewId, fmType, companyId, displayId)["Deleted"];
        }


        /// <summary>
        /// GetCompanyId
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <returns>COMPANY_ID</returns>
        public int GetCompanyId(int viewId, string fmType, int companyId, int displayId)
        {
            return (int)GetRow(viewId, fmType, companyId, displayId)["COMPANY_ID"];
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

            string command = "UPDATE [dbo].[LFS_FM_VIEW_DISPLAY] " +
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
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="displayId">displayId</param>
        public void DeleteForEditView(int viewId, string fmType, int companyId, int displayId)
        {
            SqlParameter viewIdParameter = new SqlParameter("ViewID", viewId);
            SqlParameter fmTypeParameter = new SqlParameter("FmType", fmType);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            SqlParameter displayIdParameter = new SqlParameter("DisplayID", displayId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_FM_VIEW_DISPLAY] " +
                             "SET " +
                             "[Deleted] = @Deleted " +
                             " WHERE (([ViewID] = @ViewID) AND ([FmType] = @FmType) AND " +
                             "([COMPANY_ID] = @COMPANY_ID) AND ([DisplayID] = @DisplayID))";

            int rowsAffected = (int)ExecuteNonQuery(command, viewIdParameter, fmTypeParameter, companyIdParameter, displayIdParameter, deletedParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="displayId">displayId</param>
        /// <param name="deleted">deleted</param>
        public void Insert(int viewId, string fmType, int companyId, int displayId, bool deleted)
        {
            SqlParameter viewIdParameter = new SqlParameter("ViewID", viewId);
            SqlParameter fmTypeParameter = new SqlParameter("FmType", fmType);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            SqlParameter displayIdParameter = new SqlParameter("DisplayID", displayId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);

            string command = "INSERT INTO [dbo].[LFS_FM_VIEW_DISPLAY] ([ViewID], [FmType], [COMPANY_ID], [DisplayID], [Deleted]) VALUES (@ViewID, @FmType, @COMPANY_ID, @DisplayID, @Deleted)";

            ExecuteScalar(command, viewIdParameter, fmTypeParameter, companyIdParameter, displayIdParameter, deletedParameter);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="originalViewId">originalViewId</param>
        /// <param name="originalFmType">originalFmType</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalDisplayId">originalDisplayId</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="newViewId">newViewId</param>
        /// <param name="newFmType">newFmType</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newDisplayId">newDisplayId</param>
        /// <param name="newDeleted">newDeleted</param>
        public void Update(int originalViewId, string originalFmType, int originalCompanyId, int originalDisplayId, bool originalDeleted, int newViewId, string newFmType, int newCompanyId, int newDisplayId, bool newDeleted)
        {
            SqlParameter originalViewIdParameter = new SqlParameter("Original_ViewID", originalViewId);
            SqlParameter originalFmTypeParameter = new SqlParameter("Original_FmType", originalFmType);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter originalDisplayIdParameter = new SqlParameter("Original_DisplayID", originalDisplayId);
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);            

            SqlParameter newViewIdParameter = new SqlParameter("ViewID", newViewId);
            SqlParameter newFmTypeParameter = new SqlParameter("FmType", newFmType);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);
            SqlParameter newDisplayIdParameter = new SqlParameter("DisplayID", newDisplayId);
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);


            string command = "UPDATE [dbo].[LFS_FM_VIEW_DISPLAY] " +
                             "SET [ViewID] = @ViewID, [FmType] = @FmType, [COMPANY_ID] = @COMPANY_ID, [DisplayID] = @DisplayID, [Deleted] = @Deleted  " +
                             "WHERE (([ViewID] = @Original_ViewID) AND ([FmType] = @Original_FmType) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND ([DisplayID] = @Original_DisplayID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalViewIdParameter, originalFmTypeParameter, originalCompanyIdParameter, originalDisplayIdParameter, originalDeletedParameter, newViewIdParameter, newFmTypeParameter, newCompanyIdParameter, newDisplayIdParameter, newDeletedParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }
        }
        

        
    }
}