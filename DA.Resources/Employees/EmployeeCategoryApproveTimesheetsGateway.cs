using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Resources.Employees
{
    /// <summary>
    /// EmployeeCategoryApproveTimesheetsGateway
    /// </summary>
    public class EmployeeCategoryApproveTimesheetsGateway : DataTableGateway
    {
        ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public EmployeeCategoryApproveTimesheetsGateway()
            : base("LFS_RESOURCES_EMPLOYEE_CATEGORY_APPROVE_TIMESHEETS")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public EmployeeCategoryApproveTimesheetsGateway(DataSet data)
            : base(data, "LFS_RESOURCES_EMPLOYEE_CATEGORY_APPROVE_TIMESHEETS")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new EmployeeTDS();
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
            tableMapping.DataSetTable = "LFS_RESOURCES_EMPLOYEE_CATEGORY_APPROVE_TIMESHEETS";
            tableMapping.ColumnMappings.Add("EmployeeID", "EmployeeID");
            tableMapping.ColumnMappings.Add("Category", "Category");
            tableMapping.ColumnMappings.Add("ApproveTimesheets", "ApproveTimesheets");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[LFS_RESOURCES_EMPLOYEE_CATEGORY_APPROVE_TIMESHEETS] WHERE (([E" +
                "mployeeID] = @Original_EmployeeID) AND ([Category] = @Original_Category) AND ([A" +
                "pproveTimesheets] = @Original_ApproveTimesheets) AND ([Deleted] = @Original_Dele" +
                "ted))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_EmployeeID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EmployeeID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Category", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Category", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ApproveTimesheets", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ApproveTimesheets", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_RESOURCES_EMPLOYEE_CATEGORY_APPROVE_TIMESHEETS] ([EmployeeID], [Category], [ApproveTimesheets], [Deleted]) VALUES (@EmployeeID, @Category, @ApproveTimesheets, @Deleted);
SELECT EmployeeID, Category, ApproveTimesheets, Deleted FROM LFS_RESOURCES_EMPLOYEE_CATEGORY_APPROVE_TIMESHEETS WHERE (Category = @Category) AND (EmployeeID = @EmployeeID)";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@EmployeeID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EmployeeID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Category", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Category", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ApproveTimesheets", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ApproveTimesheets", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));

            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = @"UPDATE [dbo].[LFS_RESOURCES_EMPLOYEE_CATEGORY_APPROVE_TIMESHEETS] SET [EmployeeID] = @EmployeeID, [Category] = @Category, [ApproveTimesheets] = @ApproveTimesheets, [Deleted] = @Deleted WHERE (([EmployeeID] = @Original_EmployeeID) AND ([Category] = @Original_Category) AND ([ApproveTimesheets] = @Original_ApproveTimesheets) AND ([Deleted] = @Original_Deleted));
SELECT EmployeeID, Category, ApproveTimesheets, Deleted FROM LFS_RESOURCES_EMPLOYEE_CATEGORY_APPROVE_TIMESHEETS WHERE (Category = @Category) AND (EmployeeID = @EmployeeID)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@EmployeeID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EmployeeID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Category", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Category", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ApproveTimesheets", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ApproveTimesheets", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_EmployeeID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EmployeeID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Category", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Category", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ApproveTimesheets", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ApproveTimesheets", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            #endregion
        }

        



        
        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROWS
        //

        /// <summary>
        /// Insert a employee category approve timesheets (direct to DB)
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="category">category</param>
        /// <param name="approveTimesheets">approveTimesheets</param>
        /// <param name="deleted">deleted</param>
        /// <returns>rowsAffected</returns>
        public int Insert(int employeeId, string category, bool approveTimesheets, bool deleted)
        {
            SqlParameter employeeIdParameter = new SqlParameter("EmployeeID", employeeId);
            SqlParameter categoryParameter = new SqlParameter("Category", category);
            SqlParameter approveTimesheetsParameter = new SqlParameter("ApproveTimesheets", approveTimesheets);            
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);

            string command = "INSERT INTO [dbo].[LFS_RESOURCES_EMPLOYEE_CATEGORY_APPROVE_TIMESHEETS] ([EmployeeID], [Category], [ApproveTimesheets], [Deleted]) "+
                             " VALUES (@EmployeeID, @Category, @ApproveTimesheets, @Deleted)";

            int rowsAffected = (int)ExecuteNonQuery(command, employeeIdParameter, categoryParameter, approveTimesheetsParameter, deletedParameter);

            return rowsAffected;
        }



        /// <summary>
        /// Update employee category approve timesheets (direct to DB)
        /// </summary>
        /// <param name="originalEmployeeId">originalEmployeeId</param>
        /// <param name="originalCategory">originalCategory</param>
        /// <param name="originalApproveTimesheets">originalApproveTimesheets</param>
        /// <param name="originalDeleted">originalDeleted</param>
        ///
        /// <param name="newEmployeeId">newEmployeeId</param>
        /// <param name="newCategory">newCategory</param>
        /// <param name="newApproveTimesheets">newApproveTimesheets</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <returns>rowsAffected</returns>
        public int Update(int originalEmployeeId, string originalCategory, bool originalApproveTimesheets, bool originalDeleted, int newEmployeeId, string newCategory, bool newApproveTimesheets, bool newDeleted)
        {
            SqlParameter originalEmployeeIdParameter = new SqlParameter("Original_EmployeeID", originalEmployeeId);
            SqlParameter originalCategoryParameter = new SqlParameter("Original_Category", originalCategory);
            SqlParameter originalApproveTimesheetsParameter = new SqlParameter("Original_ApproveTimesheets", originalApproveTimesheets);
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);           

            SqlParameter newEmployeeIdParameter = new SqlParameter("EmployeeID", newEmployeeId);
            SqlParameter newCategoryParameter = new SqlParameter("Category", newCategory);
            SqlParameter newApproveTimesheetsParameter = new SqlParameter("ApproveTimesheets", newApproveTimesheets);
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);

            string command = "UPDATE [dbo].[LFS_RESOURCES_EMPLOYEE_CATEGORY_APPROVE_TIMESHEETS] "+
            " SET [ApproveTimesheets] = @ApproveTimesheets " +
            " WHERE (([Category] = @Original_Category) AND ([EmployeeID] = @Original_EmployeeID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalEmployeeIdParameter, originalCategoryParameter, originalApproveTimesheetsParameter, originalDeletedParameter, newEmployeeIdParameter, newCategoryParameter, newApproveTimesheetsParameter, newDeletedParameter); 

            return rowsAffected;
        }



        /// <summary>
        /// Delete all employees category approve timesheets (direct to DB)
        /// </summary>
        /// <param name="originalEmployeeId">originalEmployeeId</param>
        /// <param name="originalCategory">originalCategory</param>
        /// <returns>int</returns>
        public int DeleteAll(int originalEmployeeId, string originalCategory)
        {
            SqlParameter originalEmployeeIdParameter = new SqlParameter("@Original_EmployeeID", originalEmployeeId);
            SqlParameter originalCategoryParameter = new SqlParameter("Original_Category", originalCategory);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_RESOURCES_EMPLOYEE_CATEGORY_APPROVE_TIMESHEETS] SET  [Deleted] = @Deleted  " +
                             " WHERE (([EmployeeID] = @Original_EmployeeID) AND ([Category] = @Original_Category))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalEmployeeIdParameter, originalCategoryParameter, deletedParameter);

            return rowsAffected;
        }



    }
}