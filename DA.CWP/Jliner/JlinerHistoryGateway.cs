using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.DA.CWP.Section;
using LiquiForce.LFSLive.DA.RAF;



namespace LiquiForce.LFSLive.DA.CWP.Jliner
{
    /// <summary>
    /// JlinerHistoryGateway
    /// </summary>
    public class JlinerHistoryGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public JlinerHistoryGateway()
            : base("LFS_JUNCTION_LINER2_HISTORY")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public JlinerHistoryGateway(DataSet data)
            : base(data, "LFS_JUNCTION_LINER2_HISTORY")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new SectionTDS();
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
            tableMapping.DataSetTable = "LFS_JUNCTION_LINER2_HISTORY";
            tableMapping.ColumnMappings.Add("ID", "ID");
            tableMapping.ColumnMappings.Add("RefID", "RefID");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("HistoryID", "HistoryID");
            tableMapping.ColumnMappings.Add("DateTime_", "DateTime_");
            tableMapping.ColumnMappings.Add("LoginID", "LoginID");
            tableMapping.ColumnMappings.Add("History", "History");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = @"DELETE FROM [dbo].[LFS_JUNCTION_LINER2_HISTORY] WHERE (([ID] = @Original_ID) AND ([RefID] = @Original_RefID) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND ([HistoryID] = @Original_HistoryID) AND ([DateTime_] = @Original_DateTime_) AND ([LoginID] = @Original_LoginID) AND ([Deleted] = @Original_Deleted))";
            this._adapter.DeleteCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, 0, 0, "ID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RefID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "RefID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_HistoryID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "HistoryID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DateTime_", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "DateTime_", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LoginID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LoginID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Deleted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_JUNCTION_LINER2_HISTORY] ([ID], [RefID], [COMPANY_ID], [HistoryID], [DateTime_], [LoginID], [History], [Deleted]) VALUES (@ID, @RefID, @COMPANY_ID, @HistoryID, @DateTime_, @LoginID, @History, @Deleted);
SELECT ID, RefID, COMPANY_ID, HistoryID, DateTime_, LoginID, History, Deleted FROM LFS_JUNCTION_LINER2_HISTORY WHERE (COMPANY_ID = @COMPANY_ID) AND (HistoryID = @HistoryID) AND (ID = @ID) AND (RefID = @RefID)";
            this._adapter.InsertCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, 0, 0, "ID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RefID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "RefID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@HistoryID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "HistoryID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DateTime_", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "DateTime_", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LoginID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LoginID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@History", System.Data.SqlDbType.NText, 0, System.Data.ParameterDirection.Input, 0, 0, "History", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Deleted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Current, false, null, "", "", ""));

            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = @"UPDATE [dbo].[LFS_JUNCTION_LINER2_HISTORY] SET [ID] = @ID, [RefID] = @RefID, [COMPANY_ID] = @COMPANY_ID, [HistoryID] = @HistoryID, [DateTime_] = @DateTime_, [LoginID] = @LoginID, [History] = @History, [Deleted] = @Deleted WHERE (([ID] = @Original_ID) AND ([RefID] = @Original_RefID) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND ([HistoryID] = @Original_HistoryID) AND ([DateTime_] = @Original_DateTime_) AND ([LoginID] = @Original_LoginID) AND ([Deleted] = @Original_Deleted));
SELECT ID, RefID, COMPANY_ID, HistoryID, DateTime_, LoginID, History, Deleted FROM LFS_JUNCTION_LINER2_HISTORY WHERE (COMPANY_ID = @COMPANY_ID) AND (HistoryID = @HistoryID) AND (ID = @ID) AND (RefID = @RefID)";
            this._adapter.UpdateCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, 0, 0, "ID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RefID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "RefID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@HistoryID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "HistoryID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DateTime_", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "DateTime_", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LoginID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LoginID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@History", System.Data.SqlDbType.NText, 0, System.Data.ParameterDirection.Input, 0, 0, "History", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Deleted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, 0, 0, "ID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RefID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "RefID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_HistoryID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "HistoryID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DateTime_", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "DateTime_", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LoginID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LoginID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Deleted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Original, false, null, "", "", ""));

            #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATSET
        //

        /// <summary>
        /// LoadById
        /// </summary>
        /// <param name="id">GUID ID</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>
        public DataSet LoadById(Guid id, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_JLINERHISTORYGATEWAY_LOADBYID", new SqlParameter("@id", id), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByIdRefId
        /// </summary>
        /// <param name="id">GUID ID</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>
        public DataSet LoadByIdRefId(Guid id, int refId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_JLINERHISTORYGATEWAY_LOADBYIDREFID", new SqlParameter("@id", id), new SqlParameter("@refId", refId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadAllByIdRefId
        /// </summary>
        /// <param name="id">GUID ID</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>
        public DataSet LoadAllByIdRefId(Guid id, int refId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_JLINERHISTORYGATEWAY_LOADALLBYIDREFID", new SqlParameter("@id", id), new SqlParameter("@refId", refId), new SqlParameter("@companyId", companyId));
            return Data;
        }      






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROW
        //

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="historyId">historyId</param>
        /// <param name="dateTime_">dateTime_</param>
        /// <param name="loginId">loginId</param>
        /// <param name="history">history</param>        
        /// <param name="deleted">deleted</param>        
        /// <returns></returns>
        public int Insert(Guid id, int refId, int companyId, int historyId, DateTime? dateTime_, int loginId, string history, bool deleted)
        {
            SqlParameter idParameter = new SqlParameter("ID", id);
            SqlParameter refIdParameter = new SqlParameter("RefID", refId);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            SqlParameter historyIdParameter = new SqlParameter("HistoryID", historyId);
            SqlParameter dateTimeParameter = (dateTime_.ToString().Trim() != "") ? new SqlParameter("DateTime_", dateTime_.ToString().Trim()) : new SqlParameter("DateTime_", DBNull.Value);
            SqlParameter loginIdParameter = (loginId.ToString().Trim() != "") ? new SqlParameter("LoginID", loginId.ToString().Trim()) : new SqlParameter("LoginID", DBNull.Value);
            SqlParameter historyParameter = (history.Trim() != "") ? new SqlParameter("History", history.Trim()) : new SqlParameter("History", DBNull.Value);
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);

            string command = "INSERT INTO [dbo].[LFS_JUNCTION_LINER2_HISTORY] ([ID], [RefID], [COMPANY_ID], [HistoryID], " +
                " [DateTime_], [LoginID], [History], [Deleted]) " +
                " VALUES (@ID, @RefID, @COMPANY_ID, @HistoryID, @DateTime_, @LoginID, @History, @Deleted)";

            int rowsAffected = (int)ExecuteNonQuery(command, idParameter, refIdParameter, companyIdParameter, historyIdParameter, loginIdParameter, dateTimeParameter, historyParameter, deletedParameter);

            return rowsAffected;
        }



        /// <summary>
        /// Update direct
        /// </summary>
        /// <param name="originalId">originalId</param>
        /// <param name="originalRefId">originalRefId</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalHistoryId">originalHistoryId</param>
        /// <param name="originalDateTime">originalDateTime</param>
        /// <param name="originalLoginId">originalLoginId</param>        
        /// <param name="originalHistory">originalHistory</param>        
        /// <param name="originalDeleted">originalDeleted</param>
        ///
        /// <param name="newId">newId</param>
        /// <param name="newRefId">newRefId</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newHistoryId">newHistoryId</param>
        /// <param name="newDateTime">newDateTime</param>
        /// <param name="newLoginId">newLoginId</param>                                
        /// <param name="newHistory">newHistory</param>       
        /// <param name="newDeleted">newDeleted</param>
        public int Update(Guid originalId, int originalRefId, int originalCompanyId, int originalHistoryId, DateTime? originalDateTime, int originalLoginId, string originalHistory, bool originalDeleted, Guid newId, int newRefId, int newCompanyId, int newHistoryId, DateTime? newDateTime, int newLoginId, string newHistory, bool newDeleted)
        {
            SqlParameter originalIdParameter = new SqlParameter("Original_ID", originalId);
            SqlParameter originalRefIdParameter = new SqlParameter("Original_RefID", originalRefId);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter originalHistoryIdParameter = new SqlParameter("Original_HistoryID", originalHistoryId);
            SqlParameter originalDateTimeParameter = (originalDateTime.ToString().Trim() != "") ? new SqlParameter("Original_DateTime_", originalDateTime.ToString().Trim()) : new SqlParameter("Original_DateTime_", DBNull.Value);
            SqlParameter originalLoginIdParameter = (originalLoginId.ToString().Trim() != "") ? new SqlParameter("Original_LoginID", originalLoginId.ToString().Trim()) : new SqlParameter("Original_LoginID", DBNull.Value);
            SqlParameter originalHistoryParameter = (originalHistory.Trim() != "") ? new SqlParameter("Original_History", originalHistory.Trim()) : new SqlParameter("Original_History", DBNull.Value);
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);

            SqlParameter newIdParameter = new SqlParameter("ID", newId);
            SqlParameter newRefIdParameter = new SqlParameter("RefID", newRefId);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);
            SqlParameter newHistoryIdParameter = new SqlParameter("HistoryID", newHistoryId);
            SqlParameter newDateTimeParameter = (newDateTime.ToString().Trim() != "") ? new SqlParameter("DateTime_", newDateTime.ToString().Trim()) : new SqlParameter("DateTime_", DBNull.Value);
            SqlParameter newLoginIdParameter = (newLoginId.ToString().Trim() != "") ? new SqlParameter("LoginID", newLoginId.ToString().Trim()) : new SqlParameter("LoginID", DBNull.Value);
            SqlParameter newHistoryParameter = (newHistory.Trim() != "") ? new SqlParameter("History", newHistory.Trim()) : new SqlParameter("History", DBNull.Value);
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);


            string command = "UPDATE [dbo].[LFS_JUNCTION_LINER2_HISTORY] " +
                " SET [History] = @History " +
                " WHERE (([ID] = @Original_ID) AND ([RefID] = @Original_RefID) AND ([COMPANY_ID] = @Original_COMPANY_ID) " +
                " AND ([HistoryID] = @Original_HistoryID) )";

            int rowsAffected = (int)ExecuteNonQuery(command, originalIdParameter, originalRefIdParameter, originalCompanyIdParameter, originalHistoryIdParameter, originalDateTimeParameter, originalLoginIdParameter, originalHistoryParameter, originalDeletedParameter, newIdParameter, newRefIdParameter, newCompanyIdParameter, newHistoryIdParameter, newDateTimeParameter, newLoginIdParameter, newHistoryParameter, newDeletedParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="originalId">originalId</param>
        /// <param name="originalRefId">originalRefId</param>        
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalHistoryId">originalHistoryId</param>
        /// <returns>int</returns>
        public int Delete(Guid originalId, int originalRefId, int originalCompanyId, int originalHistoryId)
        {
            SqlParameter originalIdParameter = new SqlParameter("@Original_ID", originalId);
            SqlParameter originalRefIdParameter = new SqlParameter("@Original_RefID", originalRefId);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter originalHistoryIdParameter = new SqlParameter("@Original_HistoryID", originalHistoryId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_JUNCTION_LINER2_HISTORY] SET  [Deleted] = @Deleted  " +
                " WHERE (([ID] = @Original_ID) AND ([RefID] = @Original_RefID) AND " +
                " ([HistoryID] = @Original_HistoryID) AND ([COMPANY_ID] = @Original_COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalIdParameter, originalRefIdParameter, originalCompanyIdParameter, originalHistoryIdParameter, deletedParameter);

            return rowsAffected;
        }


    }    
}

    