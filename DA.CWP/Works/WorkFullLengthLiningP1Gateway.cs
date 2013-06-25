using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.CWP.Works
{
    /// <summary>
    /// WorkFullLengthLiningP1Gateway
    /// </summary>
    public class WorkFullLengthLiningP1Gateway : DataTableGateway
    {
        ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkFullLengthLiningP1Gateway() : base("LFS_WORK_FULLLENGTHLINING_P1")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkFullLengthLiningP1Gateway(DataSet data) : base(data, "LFS_WORK_FULLLENGTHLINING_P1")
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
            tableMapping.DataSetTable = "LFS_WORK_FULLLENGTHLINING_P1";
            tableMapping.ColumnMappings.Add("WorkID", "WorkID");
            tableMapping.ColumnMappings.Add("CXIsRemoved", "CXIsRemoved");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("RoboticPrepCompleted", "RoboticPrepCompleted");
            tableMapping.ColumnMappings.Add("RoboticPrepCompletedDate", "RoboticPrepCompletedDate");
            tableMapping.ColumnMappings.Add("P1Completed", "P1Completed");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = @"DELETE FROM [dbo].[LFS_WORK_FULLLENGTHLINING_P1] WHERE (([WorkID] = @Original_WorkID) AND ((@IsNull_CXIsRemoved = 1 AND [CXIsRemoved] IS NULL) OR ([CXIsRemoved] = @Original_CXIsRemoved)) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND ([RoboticPrepCompleted] = @Original_RoboticPrepCompleted) AND ((@IsNull_RoboticPrepCompletedDate = 1 AND [RoboticPrepCompletedDate] IS NULL) OR ([RoboticPrepCompletedDate] = @Original_RoboticPrepCompletedDate)) AND ([P1Completed] = @Original_P1Completed))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_WorkID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_CXIsRemoved", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CXIsRemoved", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CXIsRemoved", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CXIsRemoved", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RoboticPrepCompleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RoboticPrepCompleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_RoboticPrepCompletedDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RoboticPrepCompletedDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RoboticPrepCompletedDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RoboticPrepCompletedDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_P1Completed", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "P1Completed", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_WORK_FULLLENGTHLINING_P1] ([WorkID], [CXIsRemoved], [Deleted], [COMPANY_ID], [RoboticPrepCompleted], [RoboticPrepCompletedDate], [P1Completed]) VALUES (@WorkID, @CXIsRemoved, @Deleted, @COMPANY_ID, @RoboticPrepCompleted, @RoboticPrepCompletedDate, @P1Completed);
SELECT WorkID, CXIsRemoved, Deleted, COMPANY_ID, RoboticPrepCompleted, RoboticPrepCompletedDate, P1Completed FROM LFS_WORK_FULLLENGTHLINING_P1 WHERE (WorkID = @WorkID)";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@WorkID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CXIsRemoved", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CXIsRemoved", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RoboticPrepCompleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RoboticPrepCompleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RoboticPrepCompletedDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RoboticPrepCompletedDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@P1Completed", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "P1Completed", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            
            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = @"UPDATE [dbo].[LFS_WORK_FULLLENGTHLINING_P1] SET [WorkID] = @WorkID, [CXIsRemoved] = @CXIsRemoved, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID, [RoboticPrepCompleted] = @RoboticPrepCompleted, [RoboticPrepCompletedDate] = @RoboticPrepCompletedDate, [P1Completed] = @P1Completed WHERE (([WorkID] = @Original_WorkID) AND ((@IsNull_CXIsRemoved = 1 AND [CXIsRemoved] IS NULL) OR ([CXIsRemoved] = @Original_CXIsRemoved)) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND ([RoboticPrepCompleted] = @Original_RoboticPrepCompleted) AND ((@IsNull_RoboticPrepCompletedDate = 1 AND [RoboticPrepCompletedDate] IS NULL) OR ([RoboticPrepCompletedDate] = @Original_RoboticPrepCompletedDate)) AND ([P1Completed] = @Original_P1Completed));
SELECT WorkID, CXIsRemoved, Deleted, COMPANY_ID, RoboticPrepCompleted, RoboticPrepCompletedDate, P1Completed FROM LFS_WORK_FULLLENGTHLINING_P1 WHERE (WorkID = @WorkID)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@WorkID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CXIsRemoved", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CXIsRemoved", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RoboticPrepCompleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RoboticPrepCompleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RoboticPrepCompletedDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RoboticPrepCompletedDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@P1Completed", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "P1Completed", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_WorkID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_CXIsRemoved", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CXIsRemoved", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CXIsRemoved", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CXIsRemoved", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RoboticPrepCompleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RoboticPrepCompleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_RoboticPrepCompletedDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RoboticPrepCompletedDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RoboticPrepCompletedDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RoboticPrepCompletedDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_P1Completed", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "P1Completed", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROWS
        //

        /// <summary>
        /// Insert a Full Length Lining - P1 Work (direct to DB)
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="cxisRemoved">cxisRemoved</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="roboticPrepCompleted">roboticPrepCompleted</param>
        /// <param name="roboticPrepCompletedDate">roboticPrepCompletedDate</param>
        /// <param name="p1Completed">p1Completed</param>
        /// <returns>rowsAffected</returns>
        public int Insert(int workId, int? cxisRemoved, bool deleted, int companyId, bool roboticPrepCompleted, DateTime? roboticPrepCompletedDate, bool p1Completed)
        {
            SqlParameter workIdParameter = new SqlParameter("WorkID", workId);
            SqlParameter cxisRemovedParameter = (cxisRemoved.HasValue) ? new SqlParameter("CXIsRemoved", cxisRemoved) : new SqlParameter("CXIsRemoved", DBNull.Value);
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            SqlParameter roboticPrepCompletedParameter = new SqlParameter("RoboticPrepCompleted", roboticPrepCompleted);
            SqlParameter roboticPrepCompletedDateParameter = (roboticPrepCompletedDate.HasValue) ? new SqlParameter("RoboticPrepCompletedDate", roboticPrepCompletedDate) : new SqlParameter("RoboticPrepCompletedDate", DBNull.Value);
            SqlParameter p1CompletedParameter = new SqlParameter("P1Completed", p1Completed);

            string command = "INSERT INTO [dbo].[LFS_WORK_FULLLENGTHLINING_P1] ([WorkID], [CXIsRemoved], [Deleted], [COMPANY_ID], [RoboticPrepCompleted], [RoboticPrepCompletedDate], [P1Completed]) VALUES (@WorkID, @CXIsRemoved, @Deleted, @COMPANY_ID, @RoboticPrepCompleted, @RoboticPrepCompletedDate, @P1Completed)";

            int rowsAffected = (int)ExecuteNonQuery(command, workIdParameter, cxisRemovedParameter, deletedParameter, companyIdParameter, roboticPrepCompletedParameter, roboticPrepCompletedDateParameter, p1CompletedParameter);

            return rowsAffected;
        }



        /// <summary>
        /// Update Full Length Lining - P1 Work (direct to DB)
        /// </summary>
        /// <param name="originalWorkId">originalWorkId</param>
        /// <param name="originalCxisRemoved">originalCxisRemoved</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalRoboticPrepCompleted">originalRoboticPrepCompleted</param>
        /// <param name="originalRoboticPrepCompletedDate">originalRoboticPrepCompletedDate</param>
        /// <param name="originalP1Completed">originalP1Completed</param>
        /// 
        /// <param name="newWorkId">newWorkId</param>
        /// <param name="newCxisRemoved">newCxisRemoved</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newRoboticPrepCompleted">newRoboticPrepCompleted</param>
        /// <param name="newRoboticPrepCompletedDate">newRoboticPrepCompletedDate</param>
        /// <param name="newP1Completed">newP1Completed</param>
        /// <returns>rowsAffected</returns>
        public int Update(int originalWorkId, int? originalCxisRemoved, bool originalDeleted, int originalCompanyId, bool originalRoboticPrepCompleted, DateTime? originalRoboticPrepCompletedDate, bool originalP1Completed, int newWorkId, int? newCxisRemoved, bool newDeleted, int newCompanyId, bool newRoboticPrepCompleted, DateTime? newRoboticPrepCompletedDate, bool newP1Completed)
        {
            SqlParameter originalWorkIdParameter = new SqlParameter("Original_WorkID", originalWorkId);
            SqlParameter originalCxisRemovedParameter = new SqlParameter("Original_CXIsRemoved", originalCxisRemoved);
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter originalRoboticPrepCompletedParameter = new SqlParameter("Original_RoboticPrepCompleted", originalRoboticPrepCompleted);
            SqlParameter originalRoboticPrepCompletedDateParameter = (originalRoboticPrepCompletedDate.HasValue) ? new SqlParameter("Original_RoboticPrepCompletedDate", originalRoboticPrepCompletedDate) : new SqlParameter("Original_RoboticPrepCompletedDate", DBNull.Value);
            SqlParameter originalP1CompletedParameter = new SqlParameter("Original_P1Completed", originalP1Completed);
            
            SqlParameter newWorkIdParameter = new SqlParameter("WorkID", newWorkId);
            SqlParameter newCxisRemovedParameter = (newCxisRemoved.HasValue) ? new SqlParameter("CXIsRemoved", newCxisRemoved) : new SqlParameter("CXIsRemoved", DBNull.Value);
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);
            SqlParameter newRoboticPrepCompletedParameter = new SqlParameter("RoboticPrepCompleted", newRoboticPrepCompleted);
            SqlParameter newRoboticPrepCompletedDateParameter = (newRoboticPrepCompletedDate.HasValue) ? new SqlParameter("RoboticPrepCompletedDate", newRoboticPrepCompletedDate) : new SqlParameter("RoboticPrepCompletedDate", DBNull.Value);
            SqlParameter newP1CompletedParameter = new SqlParameter("P1Completed", newP1Completed);
            
            string command = "UPDATE [dbo].[LFS_WORK_FULLLENGTHLINING_P1] SET "+
                " [CXIsRemoved] = @CXIsRemoved, [RoboticPrepCompleted] = @RoboticPrepCompleted, " +
                " [RoboticPrepCompletedDate] = @RoboticPrepCompletedDate, [P1Completed] = @P1Completed " +
                " WHERE ([WorkID] = @Original_WorkID) AND  ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID) ";

            int rowsAffected = (int)ExecuteNonQuery(command, originalWorkIdParameter, originalDeletedParameter, originalCompanyIdParameter, originalRoboticPrepCompletedParameter, originalRoboticPrepCompletedDateParameter, originalP1CompletedParameter, newWorkIdParameter, newCxisRemovedParameter, newDeletedParameter, newCompanyIdParameter, newRoboticPrepCompletedParameter, newRoboticPrepCompletedDateParameter, newP1CompletedParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }



        /// <summary>
        /// Delete a work (direct to DB)
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <returns>rowsAffected</returns>
        public int Delete(int originalWorkId, int originalCompanyId)
        {
            SqlParameter originalWorkIdParameter = new SqlParameter("@Original_WorkID", originalWorkId);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_WORK_FULLLENGTHLINING_P1] SET  [Deleted] = @Deleted  " +
                             " WHERE (([WorkID] = @Original_WorkID) AND " +
                             "  ([COMPANY_ID] = @Original_COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalWorkIdParameter, originalCompanyIdParameter, deletedParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }
        


    }
}