using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.CWP.Works
{
    /// <summary>
    /// WorkManholeRehabilitationGateway
    /// </summary>
    public class WorkManholeRehabilitationGateway: DataTableGateway
    {
        ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkManholeRehabilitationGateway()
            : base("LFS_WORK_MANHOLE_REHABILITATION")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkManholeRehabilitationGateway(DataSet data)
            : base(data, "LFS_WORK_MANHOLE_REHABILITATION")
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
            tableMapping.DataSetTable = "LFS_WORK_MANHOLE_REHABILITATION";
            tableMapping.ColumnMappings.Add("WorkID", "WorkID");
            tableMapping.ColumnMappings.Add("PreppedDate", "PreppedDate");
            tableMapping.ColumnMappings.Add("SprayedDate", "SprayedDate");
            tableMapping.ColumnMappings.Add("BatchID", "BatchID");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");

            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = @"DELETE FROM [dbo].[LFS_WORK_MANHOLE_REHABILITATION] WHERE (([WorkID] = @Original_WorkID) AND ((@IsNull_PreppedDate = 1 AND [PreppedDate] IS NULL) OR ([PreppedDate] = @Original_PreppedDate)) AND ((@IsNull_SprayedDate = 1 AND [SprayedDate] IS NULL) OR ([SprayedDate] = @Original_SprayedDate)) AND ((@IsNull_BatchID = 1 AND [BatchID] IS NULL) OR ([BatchID] = @Original_BatchID)) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_WorkID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_PreppedDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PreppedDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_PreppedDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PreppedDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_SprayedDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SprayedDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_SprayedDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SprayedDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_BatchID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BatchID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_BatchID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BatchID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;

            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_WORK_MANHOLE_REHABILITATION] ([WorkID], [PreppedDate], [SprayedDate], [BatchID], [Deleted], [COMPANY_ID]) VALUES (@WorkID, @PreppedDate, @SprayedDate, @BatchID, @Deleted, @COMPANY_ID);
SELECT WorkID, PreppedDate, SprayedDate, BatchID, Deleted, COMPANY_ID FROM LFS_WORK_MANHOLE_REHABILITATION WHERE (WorkID = @WorkID)";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@WorkID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PreppedDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PreppedDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@SprayedDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SprayedDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@BatchID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BatchID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            
            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = @"UPDATE [dbo].[LFS_WORK_MANHOLE_REHABILITATION] SET [WorkID] = @WorkID, [PreppedDate] = @PreppedDate, [SprayedDate] = @SprayedDate, [BatchID] = @BatchID, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID WHERE (([WorkID] = @Original_WorkID) AND ((@IsNull_PreppedDate = 1 AND [PreppedDate] IS NULL) OR ([PreppedDate] = @Original_PreppedDate)) AND ((@IsNull_SprayedDate = 1 AND [SprayedDate] IS NULL) OR ([SprayedDate] = @Original_SprayedDate)) AND ((@IsNull_BatchID = 1 AND [BatchID] IS NULL) OR ([BatchID] = @Original_BatchID)) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID));
SELECT WorkID, PreppedDate, SprayedDate, BatchID, Deleted, COMPANY_ID FROM LFS_WORK_MANHOLE_REHABILITATION WHERE (WorkID = @WorkID)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@WorkID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PreppedDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PreppedDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@SprayedDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SprayedDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@BatchID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BatchID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_WorkID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_PreppedDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PreppedDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_PreppedDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PreppedDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_SprayedDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SprayedDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_SprayedDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SprayedDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_BatchID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BatchID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_BatchID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BatchID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// LoadByWorkId
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>data set</returns>
        public DataSet LoadByWorkId(int workId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_WORKMANHOLEREHABILITATIONGATEWAY_LOADBYWORKID", new SqlParameter("@workId", workId), new SqlParameter("@companyId", companyId));
            return Data;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROWS
        //

        /// <summary>
        /// Insert a manhole rehabilitation (direct to DB)
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="preppedDate">preppedDate</param>
        /// <param name="sprayedDate">sprayedDate</param>        
        /// <param name="batchId">batchId</param>
        /// <param name="deleted">deleted</param>       
        /// <param name="companyId">companyId</param>        
        /// <returns>rowsAffected</returns>
        public int Insert(int workId, DateTime? preppedDate, DateTime? sprayedDate, int? batchId, bool deleted, int companyId)
        {
            SqlParameter workIdParameter = new SqlParameter("WorkID", workId);
            SqlParameter preppedDateParameter = (preppedDate.HasValue) ? new SqlParameter("PreppedDate", preppedDate) : new SqlParameter("PreppedDate", DBNull.Value);
            SqlParameter sprayedDateParameter = (sprayedDate.HasValue) ? new SqlParameter("SprayedDate", sprayedDate) : new SqlParameter("SprayedDate", DBNull.Value);
            SqlParameter batchIDParameter = (batchId.HasValue) ? new SqlParameter("BatchID", batchId) : new SqlParameter("BatchID", DBNull.Value);
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);

            string command = "INSERT INTO [dbo].[LFS_WORK_MANHOLE_REHABILITATION] ([WorkID], [PreppedDate], [SprayedDate], [BatchID], [Deleted], [COMPANY_ID]) VALUES (@WorkID, @PreppedDate, @SprayedDate, @BatchID, @Deleted, @COMPANY_ID)";

            int rowsAffected = (int)ExecuteNonQuery(command, workIdParameter, preppedDateParameter, sprayedDateParameter, batchIDParameter, deletedParameter, companyIdParameter);

            return rowsAffected;
        }



        /// <summary>
        /// Update manhole rehabilitation (direct to DB)
        /// </summary>
        /// <param name="originalWorkId">originalWorkId</param>
        /// <param name="originalPreppedDate">originalPreppedDate</param>
        /// <param name="originalSprayedDate">originalSprayedDate</param>        
        /// <param name="originalBatchId">originalBatchId</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// 
        /// <param name="newWorkId">newWorkId</param>
        /// <param name="newPreppedDate">newPreppedDate</param>
        /// <param name="newSprayedDate">newSprayedDate</param>        
        /// <param name="newBatchId">newBatchId</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <returns>rowsAffected</returns>
        public int Update(int originalWorkId, DateTime? originalPreppedDate, DateTime? originalSprayedDate, int? originalBatchId, bool originalDeleted, int originalCompanyId, int newWorkId, DateTime? newPreppedDate, DateTime? newSprayedDate, int? newBatchId, bool newDeleted, int newCompanyId)
        {
            SqlParameter originalWorkIdParameter = new SqlParameter("Original_WorkID", originalWorkId);
            SqlParameter originalPreppedDateParameter = (originalPreppedDate.HasValue) ? new SqlParameter("Original_PreppedDate", originalPreppedDate) : new SqlParameter("Original_PreppedDate", DBNull.Value);
            SqlParameter originalSprayedDateParameter = (originalSprayedDate.HasValue) ? new SqlParameter("Original_SprayedDate", originalSprayedDate) : new SqlParameter("Original_SprayedDate", DBNull.Value);
            SqlParameter originalBatchIdParameter = (originalBatchId.HasValue) ? new SqlParameter("Original_BatchID", originalBatchId) : new SqlParameter("Original_BatchID", DBNull.Value);
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);

            SqlParameter newWorkIdParameter = new SqlParameter("WorkID", newWorkId);
            SqlParameter newPreppedDateParameter = (newPreppedDate.HasValue) ? new SqlParameter("PreppedDate", newPreppedDate) : new SqlParameter("PreppedDate", DBNull.Value);
            SqlParameter newSprayedDateParameter = (newSprayedDate.HasValue) ? new SqlParameter("SprayedDate", newSprayedDate) : new SqlParameter("SprayedDate", DBNull.Value);
            SqlParameter newBatchIdParameter = (newBatchId.HasValue) ? new SqlParameter("BatchID", newBatchId) : new SqlParameter("BatchID", DBNull.Value);
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);

            string command = "UPDATE [dbo].[LFS_WORK_MANHOLE_REHABILITATION] " +
                " SET [PreppedDate] = @PreppedDate, [SprayedDate] = @SprayedDate, [BatchID] = @BatchID " +
                " WHERE (([WorkID] = @Original_WorkID) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID)) ";

            int rowsAffected = (int)ExecuteNonQuery(command, originalWorkIdParameter, originalPreppedDateParameter, originalSprayedDateParameter, originalBatchIdParameter, originalDeletedParameter, originalCompanyIdParameter, newWorkIdParameter, newPreppedDateParameter, newSprayedDateParameter, newBatchIdParameter, newDeletedParameter, newCompanyIdParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }



        /// <summary>
        /// Delete manhole rehabilitation (direct to DB)
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <returns>rowsAffected</returns>
        public int Delete(int workId, int originalCompanyId)
        {
            SqlParameter workIdParameter = new SqlParameter("@Original_WorkID", workId);            
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_WORK_MANHOLE_REHABILITATION] SET [Deleted] = @Deleted  " +
                             " WHERE (([WorkID] = @Original_WorkID) AND " +
                             "  ([COMPANY_ID] = @Original_COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, workIdParameter, originalCompanyIdParameter, deletedParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }



    }
}