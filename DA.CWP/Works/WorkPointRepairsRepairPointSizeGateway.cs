using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.Works
{
    /// <summary>
    /// WorkPointRepairsRepairPointSizeGateway
    /// </summary>
    public class WorkPointRepairsRepairPointSizeGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkPointRepairsRepairPointSizeGateway()
            : base("LFS_WORK_POINT_REPAIRS_REPAIRPOINT_SIZE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkPointRepairsRepairPointSizeGateway(DataSet data)
            : base(data, "LFS_WORK_POINT_REPAIRS_REPAIRPOINT_SIZE")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new WorkTDS();
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
            tableMapping.DataSetTable = "LFS_WORK_POINT_REPAIRS_REPAIRPOINT_SIZE";
            tableMapping.ColumnMappings.Add("Size_", "Size_");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[LFS_WORK_POINT_REPAIRS_REPAIRPOINT_SIZE] WHERE (([Size_] = @Or" +
                "iginal_Size_) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND ([Deleted] = @Origin" +
                "al_Deleted))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Size_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Size_", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            
            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_WORK_POINT_REPAIRS_REPAIRPOINT_SIZE] ([Size_], [COMPANY_ID], [Deleted]) VALUES (@Size_, @COMPANY_ID, @Deleted);
SELECT Size_, COMPANY_ID, Deleted FROM LFS_WORK_POINT_REPAIRS_REPAIRPOINT_SIZE WHERE (COMPANY_ID = @COMPANY_ID) AND (Size_ = @Size_)";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Size_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Size_", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));

            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = @"UPDATE [dbo].[LFS_WORK_POINT_REPAIRS_REPAIRPOINT_SIZE] SET [Size_] = @Size_, [COMPANY_ID] = @COMPANY_ID, [Deleted] = @Deleted WHERE (([Size_] = @Original_Size_) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND ([Deleted] = @Original_Deleted));
SELECT Size_, COMPANY_ID, Deleted FROM LFS_WORK_POINT_REPAIRS_REPAIRPOINT_SIZE WHERE (COMPANY_ID = @COMPANY_ID) AND (Size_ = @Size_)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Size_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Size_", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Size_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Size_", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// LoadBySize_
        /// </summary>
        /// <param name="size_">size_</param>
        /// <param name="companyId">companyId</param>
        /// <returns>data set</returns>
        public DataSet LoadBySize_(string size_, int companyId)
        {
            FillDataWithStoredProcedure("LFS_WORK_POINT_REPAIRS_REPAIRPOINT_SIZE_LOADBYSIZE", new SqlParameter("@size_", size_), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadAllBySize_
        /// </summary>
        /// <param name="size_">size_</param>
        /// <param name="companyId">companyId</param>
        /// <returns>data set</returns>
        public DataSet LoadAllBySize_(string size_, int companyId)
        {
            FillDataWithStoredProcedure("LFS_WORK_POINT_REPAIRS_REPAIRPOINT_SIZE_LOADALLBYSIZE", new SqlParameter("@size_", size_), new SqlParameter("@companyId", companyId));
            return Data;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROWS
        //

        /// <summary>
        /// Insert size
        /// </summary>
        /// <param name="size_">size_</param>
        /// <param name="companyId">companyId</param>
        /// <param name="deleted">deleted</param>
        public void Insert(string size_, int companyId, bool deleted)
        {
            SqlParameter sizeParameter = (size_.Trim() != "") ? new SqlParameter("Size_", size_.Trim()) : new SqlParameter("Size_", DBNull.Value);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);

            string command = "INSERT INTO [dbo].[LFS_WORK_POINT_REPAIRS_REPAIRPOINT_SIZE] ([Size_], [COMPANY_ID], [Deleted]) VALUES (@Size_, " +
                 " @COMPANY_ID, @Deleted)";

            int rowsAffected = (int)ExecuteNonQuery(command, sizeParameter, companyIdParameter, deletedParameter);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="originalSize_">originalSize_</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// 
        /// <param name="newSize_">newSize_</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <returns>rowsAffected</returns>
        public int Update(string originalSize_, int originalCompanyId, bool originalDeleted, string newSize_, int newCompanyId, bool newDeleted)
        {
            SqlParameter originalSizeParameter = (originalSize_.Trim() != "") ? new SqlParameter("Original_Size_", originalSize_.Trim()) : new SqlParameter("Original_Size_", DBNull.Value);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);

            SqlParameter newSizeParameter = (newSize_.Trim() != "") ? new SqlParameter("Size_", newSize_.Trim()) : new SqlParameter("Size_", DBNull.Value);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);

            string command = "UPDATE [dbo].[LFS_WORK_POINT_REPAIRS_REPAIRPOINT_SIZE] " +
                " SET [Size_] = @Size_, [COMPANY_ID] = @COMPANY_ID, [Deleted] = @Deleted " +
                " WHERE (([Size_] = @Original_Size_) AND ([COMPANY_ID] = @Original_COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalSizeParameter, originalCompanyIdParameter, originalDeletedParameter, newSizeParameter, newCompanyIdParameter, newDeletedParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="originalSize_">originalSize_</param>
        /// <param name="companyId">companyId</param>
        public void Delete(string size_, int companyId)
        {
            SqlParameter sizeParameter = (size_.Trim() != "") ? new SqlParameter("Size_", size_.Trim()) : new SqlParameter("Size_", DBNull.Value);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_WORK_POINT_REPAIRS_REPAIRPOINT_SIZE] SET  [Deleted] = @Deleted " +
                " WHERE (([Size_] = @Size_) AND ([COMPANY_ID] = @COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, sizeParameter, companyIdParameter, deletedParameter);
        }



        /// <summary>
        /// UnDelete
        /// </summary>
        /// <param name="originalSize_">originalSize_</param>
        /// <param name="companyId">companyId</param>
        public void UnDelete(string size_, int companyId)
        {
            SqlParameter sizeParameter = (size_.Trim() != "") ? new SqlParameter("Size_", size_.Trim()) : new SqlParameter("Size_", DBNull.Value);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", SqlDbType.Bit);
            deletedParameter.Value = 0;

            string command = "UPDATE [dbo].[LFS_WORK_POINT_REPAIRS_REPAIRPOINT_SIZE] SET  [Deleted] = @Deleted " +
                " WHERE (([Size_] = @Size_) AND ([COMPANY_ID] = @COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, sizeParameter, companyIdParameter, deletedParameter);
        }



        /// <summary>
        /// IsUsedInPointRepair
        /// </summary>
        /// <param name="size_">size_</param>
        /// <param name="companyId">companyId</param>
        /// <returns>TRUE if is used</returns>
        public bool IsUsedInPointRepair(string size_, int companyId)
        {
            string commandText = "SELECT COUNT(*) FROM LFS_WORK_POINT_REPAIRS_REPAIR WHERE (Size_ = @size_) AND (COMPANY_ID = @companyId) AND (Deleted = 0)";
            SqlCommand command = new SqlCommand(commandText, DB.Connection);
            command.Parameters.Add(new SqlParameter("@size_", size_));
            command.Parameters.Add(new SqlParameter("@companyId", companyId));

            return ((int)ExecuteScalar(command) > 0) ? true : false;
        }

                      

    }
}