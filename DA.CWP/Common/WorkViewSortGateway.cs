using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.Common
{
    /// <summary>
    /// WorkViewSortGateway
    /// </summary>
    public class WorkViewSortGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public WorkViewSortGateway()
            : base("LFS_WORK_VIEW_SORT")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public WorkViewSortGateway(DataSet data)
            : base(data, "LFS_WORK_VIEW_SORT")
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
            tableMapping.DataSetTable = "LFS_WORK_VIEW_SORT";
            tableMapping.ColumnMappings.Add("ViewID", "ViewID");
            tableMapping.ColumnMappings.Add("WorkType", "WorkType");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("SortID", "SortID");
            tableMapping.ColumnMappings.Add("Order_", "Order_");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = @"DELETE FROM [dbo].[LFS_WORK_VIEW_SORT] WHERE (([ViewID] = @Original_ViewID) AND ([WorkType] = @Original_WorkType) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND ([SortID] = @Original_SortID) AND ([Order_] = @Original_Order_) AND ([Deleted] = @Original_Deleted))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ViewID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ViewID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_WorkType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkType", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_SortID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SortID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Order_", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Order_", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            
            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_WORK_VIEW_SORT] ([ViewID], [WorkType], [COMPANY_ID], [SortID], [Order_], [Deleted]) VALUES (@ViewID, @WorkType, @COMPANY_ID, @SortID, @Order_, @Deleted);
SELECT ViewID, WorkType, COMPANY_ID, SortID, Order_, Deleted FROM LFS_WORK_VIEW_SORT WHERE (COMPANY_ID = @COMPANY_ID) AND (SortID = @SortID) AND (ViewID = @ViewID) AND (WorkType = @WorkType)";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ViewID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ViewID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@WorkType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkType", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@SortID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SortID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Order_", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Order_", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));

            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = @"UPDATE [dbo].[LFS_WORK_VIEW_SORT] SET [ViewID] = @ViewID, [WorkType] = @WorkType, [COMPANY_ID] = @COMPANY_ID, [SortID] = @SortID, [Order_] = @Order_, [Deleted] = @Deleted WHERE (([ViewID] = @Original_ViewID) AND ([WorkType] = @Original_WorkType) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND ([SortID] = @Original_SortID) AND ([Order_] = @Original_Order_) AND ([Deleted] = @Original_Deleted));
SELECT ViewID, WorkType, COMPANY_ID, SortID, Order_, Deleted FROM LFS_WORK_VIEW_SORT WHERE (COMPANY_ID = @COMPANY_ID) AND (SortID = @SortID) AND (ViewID = @ViewID) AND (WorkType = @WorkType)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ViewID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ViewID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@WorkType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkType", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@SortID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SortID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Order_", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Order_", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ViewID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ViewID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_WorkType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkType", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_SortID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SortID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Order_", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Order_", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
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
            FillDataWithStoredProcedure("LFS_CWP_WORKVIEWSORTGATEWAY_LOADBYVIEWID", new SqlParameter("@viewId", viewId), new SqlParameter("@workType", workType), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByViewIdWorkTypeSortId
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="sortId">sortId</param>
        /// <returns></returns>
        public DataSet LoadByViewIdWorkTypeSortId(int viewId, string workType, int companyId, int sortId)
        {
            FillDataWithStoredProcedure("LFS_CWP_WORKVIEWSORTGATEWAY_LOADBYVIEWIDSORTID", new SqlParameter("@viewId", viewId), new SqlParameter("@workType", workType), new SqlParameter("@companyId", companyId), new SqlParameter("@sortId", sortId));
            return Data;
        }



        /// <summary>
        /// LoadAllByViewIdWorkTypeSortId
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="sortId">sortId</param>
        /// <returns></returns>
        public DataSet LoadAllByViewIdWorkTypeSortId(int viewId, string workType, int companyId, int sortId)
        {
            FillDataWithStoredProcedure("LFS_CWP_WORKVIEWSORTGATEWAY_LOADALLBYVIEWIDSORTID", new SqlParameter("@viewId", viewId), new SqlParameter("@workType", workType), new SqlParameter("@companyId", companyId), new SqlParameter("@sortId", sortId));
            return Data;
        }



        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="sortId">sortId</param>
        /// <returns></returns>
        public DataRow GetRow(int viewId, string workType, int companyId, int sortId)
        {
            string filter = string.Format("ViewID = {0} AND WorkType = '{1}' AND COMPANY_ID = {2} AND SortID = {3}", viewId, workType, companyId, sortId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.CWP.Common.WorkViewSortGateway.GetRow");
            }
        }



        /// <summary>
        /// GetWorkType
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="sortId">sortId</param>
        /// <returns></returns>
        public string GetWorkType(int viewId, string workType, int companyId, int sortId)
        {
            return (string)GetRow(viewId, workType, companyId, sortId)["WorkType"];
        }



        /// <summary>
        /// GetDeleted
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="sortId">sortId</param>
        /// <returns></returns>
        public bool GetDeleted(int viewId, string workType, int companyId, int sortId)
        {
            return (bool)GetRow(viewId, workType, companyId, sortId)["Deleted"];
        }


        
        /// <summary>
        /// GetCompanyId
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="sortId">sortId</param>
        /// <returns></returns>
        public int GetCompanyId(int viewId, string workType, int companyId, int sortId)
        {
            return (int)GetRow(viewId, workType, companyId, sortId)["COMPANY_ID"];
        }



        /// <summary>
        /// GetOrder
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="sortId">sortId</param>
        /// <returns></returns>
        public int GetOrder(int viewId, string workType, int companyId, int sortId)
        {
            return (int)GetRow(viewId, workType, companyId, sortId)["Order_"];
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

            string command = "UPDATE [dbo].[LFS_WORK_VIEW_SORT] " +
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
        /// <param name="sortId">sortId</param>
        public void DeleteForEditView(int viewId, string workType, int companyId, int sortId)
        {
            SqlParameter viewIdParameter = new SqlParameter("ViewID", viewId);
            SqlParameter workTypeParameter = new SqlParameter("WorkType", workType);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            SqlParameter sortIdParameter = new SqlParameter("SortID", sortId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_WORK_VIEW_SORT] " +
                             "SET " +
                             "[Deleted] = @Deleted " +
                             " WHERE (([ViewID] = @ViewID) AND ([WorkType] = @WorkType) AND " +
                             "([COMPANY_ID] = @COMPANY_ID) AND ([SortID] = @SortID))";

            int rowsAffected = (int)ExecuteNonQuery(command, viewIdParameter, workTypeParameter, companyIdParameter, sortIdParameter,  deletedParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="originalViewId">originalViewId</param>
        /// <param name="originalWorkType">originalWorkType</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalSortId">originalSortId</param>
        /// <param name="originalOrder_">originalOrder_</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// 
        /// <param name="newViewId">newViewId</param>
        /// <param name="newWorkType">newWorkType</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newSortId">newSortId</param>
        /// <param name="newOrder_">newOrder_</param>
        /// <param name="newDeleted">newDeleted</param>
        public void Update(int originalViewId, string originalWorkType, int originalCompanyId, int originalSortId, int originalOrder_, bool originalDeleted, int newViewId, string newWorkType, int newCompanyId, int newSortId, int newOrder_, bool newDeleted)
        {
            SqlParameter originalViewIdParameter = new SqlParameter("Original_ViewID", originalViewId);
            SqlParameter originalWorkTypeParameter = new SqlParameter("Original_WorkType", originalWorkType);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter originalSortIdParameter = new SqlParameter("Original_SortID", originalSortId);
            SqlParameter originalOrder_Parameter = new SqlParameter("Original_Order_", originalOrder_);
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);

            SqlParameter newViewIdParameter = new SqlParameter("ViewID", newViewId);
            SqlParameter newWorkTypeParameter = new SqlParameter("WorkType", newWorkType);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);
            SqlParameter newSortIdParameter = new SqlParameter("SortID", newSortId);
            SqlParameter newOrder_Parameter = new SqlParameter("Order_", newOrder_);
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);

            string command = "UPDATE [dbo].[LFS_WORK_VIEW_SORT] " +
                             "SET [ViewID] = @ViewID, [WorkType] = @WorkType, [COMPANY_ID] = @COMPANY_ID, [SortID] = @SortID, [Order_] = @Order_, [Deleted] = @Deleted  " +
                             "WHERE (([ViewID] = @Original_ViewID) AND ([WorkType] = @Original_WorkType) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND ([SortID] = @Original_SortID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalViewIdParameter, originalWorkTypeParameter, originalCompanyIdParameter, originalSortIdParameter, originalOrder_Parameter, originalDeletedParameter, newViewIdParameter, newWorkTypeParameter, newCompanyIdParameter, newSortIdParameter, newOrder_Parameter, newDeletedParameter);

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
        /// <param name="sortId">sortId</param>
        /// <param name="order_">order_</param>
        /// <param name="deleted">deleted</param>
        public void Insert(int viewId, string workType, int companyId, int sortId, int order_, bool deleted)
        {
            SqlParameter viewIdParameter = new SqlParameter("ViewID", viewId);
            SqlParameter workTypeParameter = new SqlParameter("WorkType", workType);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            SqlParameter sortIdParameter = new SqlParameter("SortID", sortId);
            SqlParameter order_Parameter = new SqlParameter("Order_", order_);
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);

            string command = "INSERT INTO [dbo].[LFS_WORK_VIEW_SORT] ([ViewID], [WorkType], [COMPANY_ID], [SortID], [Order_], [Deleted]) VALUES (@ViewID, @WorkType, @COMPANY_ID, @SortID, @Order_, @Deleted)";

            ExecuteScalar(command, viewIdParameter, workTypeParameter, companyIdParameter, sortIdParameter, order_Parameter, deletedParameter);
        }



    }
}

