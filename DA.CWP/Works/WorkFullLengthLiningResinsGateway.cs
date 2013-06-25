using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.Works
{
    /// <summary>
    /// WorkFullLengthLiningResinsGateway
    /// </summary>
    public class WorkFullLengthLiningResinsGateway : DataTableGateway
    {
        ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkFullLengthLiningResinsGateway()
            : base("LFS_WORK_FULLLENGTHLINING_RESINS")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkFullLengthLiningResinsGateway(DataSet data)
            : base(data, "LFS_WORK_FULLLENGTHLINING_RESINS")
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
            tableMapping.DataSetTable = "LFS_WORK_FULLLENGTHLINING_RESINS";
            tableMapping.ColumnMappings.Add("ResinID", "ResinID");
            tableMapping.ColumnMappings.Add("ResinMake", "ResinMake");
            tableMapping.ColumnMappings.Add("ResinType", "ResinType");
            tableMapping.ColumnMappings.Add("ResinNumber", "ResinNumber");
            tableMapping.ColumnMappings.Add("LbUsg", "LbUsg");
            tableMapping.ColumnMappings.Add("LbDrums", "LbDrums");
            tableMapping.ColumnMappings.Add("ActiveResin", "ActiveResin");
            tableMapping.ColumnMappings.Add("ApplyCatalystTo", "ApplyCatalystTo");
            tableMapping.ColumnMappings.Add("Filter", "Filter");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");

            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = @"DELETE FROM [dbo].[LFS_WORK_FULLLENGTHLINING_RESINS] WHERE (([ResinID] = @Original_ResinID) AND ([ResinMake] = @Original_ResinMake) AND ([ResinType] = @Original_ResinType) AND ([ResinNumber] = @Original_ResinNumber) AND ([LbUsg] = @Original_LbUsg) AND ([LbDrums] = @Original_LbDrums) AND ([ActiveResin] = @Original_ActiveResin) AND ([ApplyCatalystTo] = @Original_ApplyCatalystTo) AND ([Filter] = @Original_Filter) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ResinID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ResinID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ResinMake", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ResinMake", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ResinType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ResinType", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ResinNumber", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ResinNumber", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LbUsg", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LbUsg", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LbDrums", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LbDrums", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ActiveResin", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ActiveResin", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ApplyCatalystTo", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ApplyCatalystTo", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Filter", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Filter", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_WORK_FULLLENGTHLINING_RESINS] ([ResinID], [ResinMake], [ResinType], [ResinNumber], [LbUsg], [LbDrums], [ActiveResin], [ApplyCatalystTo], [Filter], [Deleted], [COMPANY_ID]) VALUES (@ResinID, @ResinMake, @ResinType, @ResinNumber, @LbUsg, @LbDrums, @ActiveResin, @ApplyCatalystTo, @Filter, @Deleted, @COMPANY_ID);
SELECT ResinID, ResinMake, ResinType, ResinNumber, LbUsg, LbDrums, ActiveResin, ApplyCatalystTo, Filter, Deleted, COMPANY_ID FROM LFS_WORK_FULLLENGTHLINING_RESINS WHERE (ResinID = @ResinID)";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ResinID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ResinID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ResinMake", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ResinMake", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ResinType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ResinType", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ResinNumber", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ResinNumber", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LbUsg", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LbUsg", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LbDrums", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LbDrums", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ActiveResin", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ActiveResin", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ApplyCatalystTo", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ApplyCatalystTo", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Filter", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Filter", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            
            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = @"UPDATE [dbo].[LFS_WORK_FULLLENGTHLINING_RESINS] SET [ResinID] = @ResinID, [ResinMake] = @ResinMake, [ResinType] = @ResinType, [ResinNumber] = @ResinNumber, [LbUsg] = @LbUsg, [LbDrums] = @LbDrums, [ActiveResin] = @ActiveResin, [ApplyCatalystTo] = @ApplyCatalystTo, [Filter] = @Filter, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID WHERE (([ResinID] = @Original_ResinID) AND ([ResinMake] = @Original_ResinMake) AND ([ResinType] = @Original_ResinType) AND ([ResinNumber] = @Original_ResinNumber) AND ([LbUsg] = @Original_LbUsg) AND ([LbDrums] = @Original_LbDrums) AND ([ActiveResin] = @Original_ActiveResin) AND ([ApplyCatalystTo] = @Original_ApplyCatalystTo) AND ([Filter] = @Original_Filter) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID));
SELECT ResinID, ResinMake, ResinType, ResinNumber, LbUsg, LbDrums, ActiveResin, ApplyCatalystTo, Filter, Deleted, COMPANY_ID FROM LFS_WORK_FULLLENGTHLINING_RESINS WHERE (ResinID = @ResinID)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ResinID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ResinID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ResinMake", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ResinMake", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ResinType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ResinType", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ResinNumber", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ResinNumber", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LbUsg", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LbUsg", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LbDrums", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LbDrums", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ActiveResin", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ActiveResin", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ApplyCatalystTo", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ApplyCatalystTo", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Filter", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Filter", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ResinID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ResinID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ResinMake", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ResinMake", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ResinType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ResinType", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ResinNumber", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ResinNumber", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LbUsg", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LbUsg", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LbDrums", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LbDrums", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ActiveResin", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ActiveResin", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ApplyCatalystTo", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ApplyCatalystTo", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Filter", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Filter", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// LoadByResinId
        /// </summary>
        /// <param name="resinId">resinId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>data set</returns>
        public DataSet LoadByResinId(int resinId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_WORKFULLLENGTHLININGRESINSGATEWAY_LOADBYRESINID", new SqlParameter("@resinId", resinId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// <param name="resinId">resinId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int resinId)
        {
            string filter = string.Format("ResinID = {0}", resinId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.CWP.FullLengthLining.FullLengthLiningResinsGateway.GetRow");
            }
        }



        /// <summary>
        /// GetResinMake. If not exists, raise an exception.
        /// </summary>
        /// <param name="resinId">resinId</param>
        /// <returns>ResinMake or EMPTY</returns>
        public string GetResinMake(int resinId)
        {
            if (GetRow(resinId).IsNull("ResinMake"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(resinId)["ResinMake"];
            }
        }



        /// <summary>
        /// GetResinType. If not exists, raise an exception.
        /// </summary>
        /// <param name="resinId">resinId</param>
        /// <returns>ResinType or EMPTY</returns>
        public string GetResinType(int resinId)
        {
            if (GetRow(resinId).IsNull("ResinType"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(resinId)["ResinType"];
            }
        }



        /// <summary>
        /// GetResinNumber. If not exists, raise an exception.
        /// </summary>
        /// <param name="resinId">resinId</param>
        /// <returns>ResinNumber or EMPTY</returns>
        public string GetResinNumber(int resinId)
        {
            if (GetRow(resinId).IsNull("ResinNumber"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(resinId)["ResinNumber"];
            }
        }



        /// <summary>
        /// GetLbUsg. If not exists, raise an exception.
        /// </summary>
        /// <param name="resinId">resinId</param>
        /// <returns>LbUsg or EMPTY</returns>
        public double GetLbUsg(int resinId)
        {
            return (double)GetRow(resinId)["LbUsg"];            
        }



        /// <summary>
        /// GetLbDrums. If not exists, raise an exception.
        /// </summary>
        /// <param name="resinId">resinId</param>
        /// <returns>LbDrums or EMPTY</returns>
        public int GetLbDrums(int resinId)
        {
            return (int)GetRow(resinId)["LbDrums"];
        }



        /// <summary>
        /// GetActiveResin. If not exists, raise an exception.
        /// </summary>
        /// <param name="resinId">resinId</param>
        /// <returns>ActiveResin or EMPTY</returns>
        public double GetActiveResin(int resinId)
        {
            return (double)GetRow(resinId)["ActiveResin"];
        }



        /// <summary>
        /// GetFilter. If not exists, raise an exception.
        /// </summary>
        /// <param name="resinId">resinId</param>
        /// <returns>Filter or EMPTY</returns>
        public double GetFilter(int resinId)
        {
            return (double)GetRow(resinId)["Filter"];
        }



        /// <summary>
        /// GetApplyCatalystTo. If not exists, raise an exception.
        /// </summary>
        /// <param name="resinId">resinId</param>
        /// <returns>ApplyCatalystTo or EMPTY</returns>
        public string GetApplyCatalystTo(int resinId)
        {
            if (GetRow(resinId).IsNull("ApplyCatalystTo"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(resinId)["ApplyCatalystTo"];
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROWS
        //

        /// <summary>
        /// Insert a resin (direct to DB)
        /// </summary>
        /// <param name="resinId">resinId</param>
        /// <param name="resinMake">resinMake</param>
        /// <param name="resinType">resinType</param>
        /// <param name="resinNumber">resinNumber</param>
        /// <param name="lbUsg">lbUsg</param>
        /// <param name="lbDrums">lbDrums</param>
        /// <param name="activeResin">activeResin</param>
        /// <param name="applyCatalystTo">applyCatalystTo</param>
        /// <param name="filter">filter</param>
        /// <param name="deleted">deleted</param>       
        /// <param name="companyId">companyId</param>        
        /// <returns>rowsAffected</returns>
        public int Insert(int resinId, string resinMake, string resinType, string resinNumber, decimal lbUsg, int lbDrums, decimal activeResin, string applyCatalystTo, decimal filter, bool deleted, int companyId)
        {
            SqlParameter resinIdParameter = new SqlParameter("ResinID", resinId);
            SqlParameter resinMakeParameter = new SqlParameter("ResinMake", resinMake.Trim());
            SqlParameter resinTypeParameter = new SqlParameter("ResinType", resinType.Trim());
            SqlParameter resinNumberParameter = new SqlParameter("ResinNumber", resinNumber.Trim());
            SqlParameter lbUsgParameter =  new SqlParameter("LbUsg", lbUsg);
            SqlParameter lbDrumsParameter =  new SqlParameter("LbDrums", lbDrums);
            SqlParameter activeResinParameter = new SqlParameter("ActiveResin", activeResin);
            SqlParameter applyCatalystToParameter = new SqlParameter("ApplyCatalystTo", applyCatalystTo.Trim());
            SqlParameter filterParameter = new SqlParameter("Filter",filter);
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);

            string command = "INSERT INTO [dbo].[LFS_WORK_FULLLENGTHLINING_RESINS] ([ResinID], [ResinMake], "+
                " [ResinType], [ResinNumber], [LbUsg], [LbDrums], [ActiveResin], [ApplyCatalystTo], [Filter], [Deleted], [COMPANY_ID]) VALUES (@ResinID, @ResinMake, @ResinType, @ResinNumber, @LbUsg, @LbDrums, @ActiveResin, @ApplyCatalystTo, @Filter, @Deleted, @COMPANY_ID)";

            int rowsAffected = (int)ExecuteNonQuery(command, resinIdParameter, resinMakeParameter, resinTypeParameter, resinNumberParameter, lbUsgParameter, lbDrumsParameter, activeResinParameter, applyCatalystToParameter, filterParameter, deletedParameter, companyIdParameter);

            return rowsAffected;
        }



        /// <summary>
        /// Update a resin (direct to DB)
        /// </summary>
        /// <param name="originalResinId">originalResinId</param>
        /// <param name="originalResinMake">originalResinMake</param>
        /// <param name="originalResinType">originalResinType</param>
        /// <param name="originalResinNumber">originalResinNumber</param>
        /// <param name="originalLbUsg">originalLbUsg</param>
        /// <param name="originalLbDrums">originalLbDrums</param>
        /// <param name="originalActiveResin">originalActiveResin</param>
        /// <param name="originalApplyCatalystTo">originalApplyCatalystTo</param>
        /// <param name="originalFilter">originalFilter</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// 
        /// <param name="newResinId">newResinId</param>
        /// <param name="newResinMake">newResinMake</param>
        /// <param name="newResinType">newResinType</param>
        /// <param name="newResinNumber">newResinNumber</param>
        /// <param name="newLbUsg">newLbUsg</param>
        /// <param name="newLbDrums">newLbDrums</param>
        /// <param name="newActiveResin">newActiveResin</param>
        /// <param name="newApplyCatalystTo">newApplyCatalystTo</param>
        /// <param name="newFilter">newFilter</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <returns>rowsAffected</returns>
        public int Update(int originalResinId, string originalResinMake, string originalResinType, string originalResinNumber, decimal originalLbUsg, int originalLbDrums, decimal originalActiveResin, string originalApplyCatalystTo, decimal originalFilter, bool originalDeleted, int originalCompanyId, int newResinId, string newResinMake, string newResinType, string newResinNumber, decimal newLbUsg, int newLbDrums, decimal newActiveResin, string newApplyCatalystTo, decimal newFilter, bool newDeleted, int newCompanyId)
        {
            SqlParameter originalResinIdParameter = new SqlParameter("Original_ResinID", originalResinId);
            SqlParameter originalResinMakeParameter = new SqlParameter("Original_ResinMake", originalResinMake);
            SqlParameter originalResinTypeParameter = new SqlParameter("Original_ResinType", originalResinType);
            SqlParameter originalResinNumberParameter = new SqlParameter("Original_ResinNumber", originalResinNumber);
            SqlParameter originalLbUsgParameter = new SqlParameter("Original_LbUsg", originalLbUsg);
            SqlParameter originalLbDrumsParameter = new SqlParameter("Original_LbDrums", originalLbDrums);
            SqlParameter originalActiveResinParameter = new SqlParameter("Original_ActiveResin", originalActiveResin);
            SqlParameter originalApplyCatalystToParameter = new SqlParameter("Original_ApplyCatalystTo", originalApplyCatalystTo);
            SqlParameter originalFilterParameter = new SqlParameter("Original_Filter", originalFilter);
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);

            SqlParameter newResinIdParameter = new SqlParameter("ResinID", newResinId);
            SqlParameter newResinMakeParameter = new SqlParameter("ResinMake", newResinMake);
            SqlParameter newResinTypeParameter = new SqlParameter("ResinType", newResinType);
            SqlParameter newResinNumberParameter = new SqlParameter("ResinNumber", newResinNumber);
            SqlParameter newLbUsgParameter = new SqlParameter("LbUsg", newLbUsg);
            SqlParameter newLbDrumsParameter = new SqlParameter("LbDrums", newLbDrums);
            SqlParameter newActiveResinParameter = new SqlParameter("ActiveResin", newActiveResin);
            SqlParameter newApplyCatalystToParameter = new SqlParameter("ApplyCatalystTo", newApplyCatalystTo);
            SqlParameter newFilterParameter = new SqlParameter("Filter", newFilter);
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);

            string command = "UPDATE [dbo].[LFS_WORK_FULLLENGTHLINING_RESINS] SET [ResinID] = @ResinID, [ResinMake] = @ResinMake, [ResinType] = @ResinType, "+
                " [ResinNumber] = @ResinNumber, [LbUsg] = @LbUsg, [LbDrums] = @LbDrums, [ActiveResin] = @ActiveResin, [ApplyCatalystTo] = @ApplyCatalystTo, [Filter] = @Filter, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID "+
                " WHERE (([ResinID] = @Original_ResinID) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID)) ";

            int rowsAffected = (int)ExecuteNonQuery(command, originalResinIdParameter, originalResinMakeParameter, originalResinTypeParameter, originalResinNumberParameter, originalLbUsgParameter, originalLbDrumsParameter, originalActiveResinParameter, originalApplyCatalystToParameter, originalFilterParameter, originalDeletedParameter, originalCompanyIdParameter, newResinIdParameter, newResinMakeParameter, newResinTypeParameter, newResinNumberParameter, newLbUsgParameter, newLbDrumsParameter, newActiveResinParameter, newApplyCatalystToParameter, newFilterParameter, newDeletedParameter, newCompanyIdParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }



        /// <summary>
        /// Delete a resin (direct to DB)
        /// </summary>
        /// <param name="originalResinId">originalResinId</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <returns>rowsAffected</returns>
        public int Delete(int originalResinId, int originalCompanyId)
        {
            SqlParameter originalResinIdParameter = new SqlParameter("@Original_ResinID", originalResinId);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_WORK_FULLLENGTHLINING_RESINS] SET  [Deleted] = @Deleted  " +
                             " WHERE (([ResinID] = @Original_ResinID) AND " +
                             "  ([COMPANY_ID] = @Original_COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalResinIdParameter, originalCompanyIdParameter, deletedParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }




    }
}
