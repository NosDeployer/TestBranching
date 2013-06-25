using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.Common
{
    /// <summary>
    /// WorkViewColumnGateway
    /// </summary>
    public class WorkViewColumnGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public WorkViewColumnGateway()
            : base("LFS_WORK_VIEW_COLUMN")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public WorkViewColumnGateway(DataSet data)
            : base(data, "LFS_WORK_VIEW_COLUMN")
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
            tableMapping.DataSetTable = "LFS_WORK_VIEW_COLUMN";
            tableMapping.ColumnMappings.Add("ViewID", "ViewID");
            tableMapping.ColumnMappings.Add("RefID", "RefID");
            tableMapping.ColumnMappings.Add("Name", "Name");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");

            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[LFS_WORK_VIEW_COLUMN] WHERE (([ViewID] = @Original_ViewID) AND" +
                " ([RefID] = @Original_RefID) AND ([Name] = @Original_Name) AND ([Deleted] = @Ori" +
                "ginal_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID))";
            this._adapter.DeleteCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ViewID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ViewID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RefID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "RefID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Name", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Name", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Deleted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_WORK_VIEW_COLUMN] ([ViewID], [RefID], [Name], [Deleted], [COMPANY_ID]) VALUES (@ViewID, @RefID, @Name, @Deleted, @COMPANY_ID);
SELECT ViewID, RefID, Name, Deleted, COMPANY_ID FROM LFS_WORK_VIEW_COLUMN WHERE (RefID = @RefID) AND (ViewID = @ViewID)";
            this._adapter.InsertCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ViewID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ViewID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RefID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "RefID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Name", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Name", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Deleted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Current, false, null, "", "", ""));

            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = @"UPDATE [dbo].[LFS_WORK_VIEW_COLUMN] SET [ViewID] = @ViewID, [RefID] = @RefID, [Name] = @Name, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID WHERE (([ViewID] = @Original_ViewID) AND ([RefID] = @Original_RefID) AND ([Name] = @Original_Name) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID));
SELECT ViewID, RefID, Name, Deleted, COMPANY_ID FROM LFS_WORK_VIEW_COLUMN WHERE (RefID = @RefID) AND (ViewID = @ViewID)";
            this._adapter.UpdateCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ViewID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ViewID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RefID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "RefID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Name", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Name", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Deleted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ViewID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ViewID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RefID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "RefID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Name", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Name", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Deleted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// LoadByViewIdCompanyId
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>data set</returns>
        public DataSet LoadByViewIdCompanyId(int viewId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_WORKVIEWCOLUMNGATEWAY_LOADBYVIEWIDCOMPANYID", new SqlParameter("@viewId", viewId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByViewIdNameCompanyId
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="name">name</param>
        /// <param name="companyId">companyId</param>
        /// <returns>data set</returns>
        public DataSet LoadByViewIdNameCompanyId(int viewId, string name, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_WORKVIEWCOLUMNGATEWAY_LOADBYVIEWIDNAMECOMPANYID", new SqlParameter("@viewId", viewId), new SqlParameter("@name", name), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        ///  Get a single jliner. If not exists, raise an exception.
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="name">name</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Row obtained</returns>
        public DataRow GetRow(int viewId, string name, int companyId)
        {
            string filter = string.Format("(ViewId = {0}) AND (Name = '{1}') AND (COMPANY_ID  = {2})", viewId, name, companyId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.CWP.Common.WorkViewColumnsGateway.GetRow");
            }

        }



        /// <summary>
        /// GetRefId. 
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="name">name</param>
        /// <param name="companyId">companyId</param>
        /// <returns>RefId</returns>
        public int GetRefId(int viewId, string name, int companyId)
        {
            return (int)GetRow(viewId, name, companyId)["RefID"];
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - QUERIES
        //

        /// <summary>
        /// ExistsColumnName
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="name">name</param>
        /// <param name="companyId">companyId</param>
        /// <returns>true if the column exists</returns>
        public bool ExistsColumnName(int viewId, string name, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_WORKVIEWCOLUMNGATEWAY_LOADBYVIEWIDNAMECOMPANYID", new SqlParameter("@viewId", viewId), new SqlParameter("@name", name), new SqlParameter("@companyId", companyId));
            if ((int)Table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



    }
}
