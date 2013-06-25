using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.WebUI.export.Temp;

namespace LiquiForce.LFSLive.WebUI
{
    /// <summary>
    /// Fix1JlinerHistoryGateway
    /// </summary>
    public class Fix1JlinerHistoryGateway : DataTableGateway
    {
    // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public Fix1JlinerHistoryGateway()
            : base("LFS_JUNCTION_LINER2_HISTORY")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public Fix1JlinerHistoryGateway(DataSet data)
            : base(data, "LFS_JUNCTION_LINER2_HISTORY")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new Fix1TDS();
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
        /// LoadByIdRefIdCompanyId
        /// </summary>
        /// <param name="id">GUID ID</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>
        public DataSet LoadByIdRefIdCompanyId(Guid id, int refId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_JLINERHISTORYGATEWAY_LOADBYIDREFIDCOMPANYID", new SqlParameter("@id", id), new SqlParameter("@refId", refId), new SqlParameter("@companyId", companyId));//Note: COMPANY_ID
            return Data;
        }


               
    }
}