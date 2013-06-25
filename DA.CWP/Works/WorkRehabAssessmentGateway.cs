using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.Works
{
    /// <summary>
    /// WorkGateway
    /// </summary>
    public class WorkRehabAssessmentGateway : DataTableGateway
    {
        ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkRehabAssessmentGateway() : base("LFS_WORK_REHABASSESSMENT")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkRehabAssessmentGateway(DataSet data) : base(data, "LFS_WORK_REHABASSESSMENT")
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
            tableMapping.DataSetTable = "LFS_WORK_REHABASSESSMENT";
            tableMapping.ColumnMappings.Add("WorkID", "WorkID");
            tableMapping.ColumnMappings.Add("PreFlushDate", "PreFlushDate");
            tableMapping.ColumnMappings.Add("PreVideoDate", "PreVideoDate");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = @"DELETE FROM [dbo].[LFS_WORK_REHABASSESSMENT] WHERE (([WorkID] = @Original_WorkID) AND ((@IsNull_PreFlushDate = 1 AND [PreFlushDate] IS NULL) OR ([PreFlushDate] = @Original_PreFlushDate)) AND ((@IsNull_PreVideoDate = 1 AND [PreVideoDate] IS NULL) OR ([PreVideoDate] = @Original_PreVideoDate)) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_WorkID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_PreFlushDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PreFlushDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_PreFlushDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PreFlushDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_PreVideoDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PreVideoDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_PreVideoDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PreVideoDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_WORK_REHABASSESSMENT] ([WorkID], [PreFlushDate], [PreVideoDate], [Deleted], [COMPANY_ID]) VALUES (@WorkID, @PreFlushDate, @PreVideoDate, @Deleted, @COMPANY_ID);
SELECT WorkID, PreFlushDate, PreVideoDate, Deleted, COMPANY_ID FROM LFS_WORK_REHABASSESSMENT WHERE (WorkID = @WorkID)";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@WorkID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PreFlushDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PreFlushDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PreVideoDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PreVideoDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));

            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = @"UPDATE [dbo].[LFS_WORK_REHABASSESSMENT] SET [WorkID] = @WorkID, [PreFlushDate] = @PreFlushDate, [PreVideoDate] = @PreVideoDate, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID WHERE (([WorkID] = @Original_WorkID) AND ((@IsNull_PreFlushDate = 1 AND [PreFlushDate] IS NULL) OR ([PreFlushDate] = @Original_PreFlushDate)) AND ((@IsNull_PreVideoDate = 1 AND [PreVideoDate] IS NULL) OR ([PreVideoDate] = @Original_PreVideoDate)) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID));
SELECT WorkID, PreFlushDate, PreVideoDate, Deleted, COMPANY_ID FROM LFS_WORK_REHABASSESSMENT WHERE (WorkID = @WorkID)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@WorkID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PreFlushDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PreFlushDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PreVideoDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PreVideoDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_WorkID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_PreFlushDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PreFlushDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_PreFlushDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PreFlushDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_PreVideoDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PreVideoDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_PreVideoDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PreVideoDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// LoadTop1ByProjectIdAssetIdWorkType
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="assetId">assetId</param>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>
        public DataSet LoadTop1ByProjectIdAssetIdWorkType(int projectId, int assetId, string workType, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_WORKREHABASSESSMENTGATEWAY_LOADTOP1BYPROJECTIDASSETIDWORKTYPE", new SqlParameter("@projectId", projectId), new SqlParameter("@assetId", assetId), new SqlParameter("@workType", workType), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// <returns>DataRow</returns>
        public DataRow GetRowTop1()
        {
            if (Table.Select().Length > 0)
            {
                DataRow row = Table.Select()[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.CWP.Works.RehabAssessmentWorkGateway.GetRow");
            }
        }



        /// <summary>
        /// GetWorkId. If not exists, raise an exception.
        /// </summary>
        /// <returns>GetWorkId or EMPTY</returns>
        public int GetWorkIdTop1()
        {
            return (int)GetRowTop1()["WorkID"];
        }



        /// <summary>
        /// GetPreFlushDate. If  not exists, raise an exception.
        /// </summary>
        /// <returns>GetPreFlushDate o EMPTY</returns>
        public DateTime? GetPreFlushDateTop1()
        {
            if (GetRowTop1().IsNull("PreFlushDate"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRowTop1()["PreFlushDate"];
            }
        }



        /// <summary>
        /// GetPreVideoDate. If  not exists, raise an exception.
        /// </summary>
        /// <returns>PreVideoDate o EMPTY</returns>
        public DateTime? GetPreVideoDateTop1()
        {
            if (GetRowTop1().IsNull("PreVideoDate"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRowTop1()["PreVideoDate"];
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROWS
        //

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="preFlushDate">preFlushDate</param>
        /// <param name="preVideoDate">preVideoDate</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void Insert(int workId, DateTime? preFlushDate, DateTime? preVideoDate, bool deleted, int companyId)
        {
            SqlParameter workIdParameter = new SqlParameter("WorkID", workId);
            SqlParameter preFlushDateParameter = (preFlushDate.HasValue) ? new SqlParameter("PreFlushDate", preFlushDate) : new SqlParameter("PreFlushDate", DBNull.Value);
            SqlParameter preVideoDateParameter = (preVideoDate.HasValue) ? new SqlParameter("PreVideoDate", preVideoDate) : new SqlParameter("PreVideoDate", DBNull.Value);
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);

            string command = "INSERT INTO [dbo].[LFS_WORK_REHABASSESSMENT] ([WorkID], [PreFlushDate], [PreVideoDate], [Deleted], [COMPANY_ID]) VALUES (@WorkID, @PreFlushDate, @PreVideoDate, @Deleted, @COMPANY_ID)";

            ExecuteNonQuery(command, workIdParameter, preFlushDateParameter, preVideoDateParameter, deletedParameter, companyIdParameter);
        }


        
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="originalWorkId">originalWorkId</param>
        /// <param name="originalPreFlushDate">originalPreFlushDate</param>
        /// <param name="originalPreVideoDate">originalPreVideoDate</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="newWorkId">newWorkId</param>
        /// <param name="newPreFlushDate">newPreFlushDate</param>
        /// <param name="newPreVideoDate">newPreVideoDate</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        public void Update(int originalWorkId, DateTime? originalPreFlushDate, DateTime? originalPreVideoDate, bool originalDeleted, int originalCompanyId, int newWorkId, DateTime? newPreFlushDate, DateTime? newPreVideoDate, bool newDeleted, int newCompanyId)
        {
            SqlParameter originalWorkIdParameter = new SqlParameter("Original_WorkID", originalWorkId);
            SqlParameter originalPreFlushDateParameter = (originalPreFlushDate.HasValue) ? new SqlParameter("Original_PreFlushDate", originalPreFlushDate) : new SqlParameter("Original_PreFlushDate", DBNull.Value);
            SqlParameter originalPreVideoDateParameter = (originalPreVideoDate.HasValue) ? new SqlParameter("Original_PreVideoDate", originalPreVideoDate) : new SqlParameter("Original_PreVideoDate", DBNull.Value);
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);

            SqlParameter newWorkIdParameter = new SqlParameter("WorkID", newWorkId);
            SqlParameter newPreFlushDateParameter = (newPreFlushDate.HasValue) ? new SqlParameter("PreFlushDate", newPreFlushDate) : new SqlParameter("PreFlushDate", DBNull.Value);
            SqlParameter newPreVideoDateParameter = (newPreVideoDate.HasValue) ? new SqlParameter("PreVideoDate", newPreVideoDate) : new SqlParameter("PreVideoDate", DBNull.Value);
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);

            string command = "UPDATE [dbo].[LFS_WORK_REHABASSESSMENT] " +
                             "SET [WorkID] = @WorkID, [PreFlushDate] = @PreFlushDate, [PreVideoDate] = @PreVideoDate, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID " +
                             "WHERE ([WorkID] = @Original_WorkID) ";

            int rowsAffected = (int)ExecuteNonQuery(command, originalWorkIdParameter, originalPreFlushDateParameter, originalPreVideoDateParameter, originalDeletedParameter, originalCompanyIdParameter, newWorkIdParameter, newPreFlushDateParameter, newPreVideoDateParameter, newDeletedParameter, newCompanyIdParameter);
            
            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="originalCompanyId">COMPANY_ID</param>
        /// <returns>int</returns>
        public void Delete(int workId, int companyId)
        {
            SqlParameter workIdParameter = new SqlParameter("WorkID", workId);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_WORK_REHABASSESSMENT] " +
                             "SET " +
                             "[Deleted] = @Deleted "+
                             " WHERE (([WorkID] = @WorkID) AND " +
                             "([COMPANY_ID] = @COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, workIdParameter, companyIdParameter, deletedParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }
        }



    }
}

