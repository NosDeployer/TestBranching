using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.Common
{
    /// <summary>
    /// WorkTypeViewDisplayGateway
    /// </summary>
    public class WorkTypeViewDisplayGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public WorkTypeViewDisplayGateway()
            : base("LFS_WORK_TYPE_VIEW_DISPLAY")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public WorkTypeViewDisplayGateway(DataSet data)
            : base(data, "LFS_WORK_TYPE_VIEW_DISPLAY")
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
        /// InitAdapter (empty)
        /// </summary>
        protected override void InitAdapter()
        {
            #region Adapter initialization

            this._adapter = new System.Data.SqlClient.SqlDataAdapter();
            System.Data.Common.DataTableMapping tableMapping = new System.Data.Common.DataTableMapping();
            tableMapping.SourceTable = "Table";
            tableMapping.DataSetTable = "LFS_WORK_TYPE_VIEW_DISPLAY";
            tableMapping.ColumnMappings.Add("WorkType", "WorkType");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("DisplayID", "DisplayID");
            tableMapping.ColumnMappings.Add("Name", "Name");
            tableMapping.ColumnMappings.Add("Always", "Always");
            tableMapping.ColumnMappings.Add("Column_", "Column_");
            tableMapping.ColumnMappings.Add("Table_", "Table_");
            tableMapping.ColumnMappings.Add("Selected", "Selected");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// LoadByWorkType
        /// </summary>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <returns></returns>
        public DataSet LoadByWorkType(string workType, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_WORKTYPEVIEWDISPLAYGATEWAY_LOADBYWORKTYPE", new SqlParameter("@workType", workType), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByWorkTypeInColumnsByDefault
        /// </summary>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inColumnsToDisplay">inColumnsToDisplay</param>
        /// <returns> Data </returns>
        public DataSet LoadByWorkTypeInColumnsByDefault(string workType, int companyId, bool inColumnsByDefault)
        {
            FillDataWithStoredProcedure("LFS_CWP_WORKTYPEVIEWDISPLAYGATEWAY_LOADBYWORKTYPEINCOLUMNSBYDEFAULT", new SqlParameter("@workType", workType), new SqlParameter("@companyId", companyId), new SqlParameter("@inColumnsByDefault", inColumnsByDefault));
            return Data;
        }



        /// <summary>
        /// LoadByWorkTypeDisplayId
        /// </summary>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="displayId">displayId</param>
        /// <returns></returns>
        public DataSet LoadByWorkTypeDisplayId(string workType, int companyId, int displayId)
        {
            FillDataWithStoredProcedure("LFS_CWP_WORKTYPEVIEWDISPLAYGATEWAY_LOADBYWORKTYPEDISPLAYID", new SqlParameter("@workType", workType), new SqlParameter("@companyId", companyId), new SqlParameter("@displayId", displayId));
            return Data;
        }


        
        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="displayId">displayId</param>
        /// <returns></returns>
        public DataRow GetRow(string workType, int companyId, int displayId)
        {
            string filter = string.Format("(WorkType = '{0}') AND (COMPANY_ID = '{1}') AND (DisplayID  = {2})", workType, companyId, displayId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.CWP.Common.WorkTypeViewDisplayGateway.GetRow");
            }

        }



        /// <summary>
        /// GetName
        /// </summary>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="displayId">displayId</param>
        /// <returns></returns>
        public string GetName(string workType, int companyId, int displayId)
        {
            return (string)GetRow(workType, companyId, displayId)["Name"];
        }



        /// <summary>
        /// GetColumn_
        /// </summary>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="displayId">displayId</param>
        /// <returns></returns>
        public string GetColumn_(string workType, int companyId, int displayId)
        {
            return (string)GetRow(workType, companyId, displayId)["Column_"];
        }



        /// <summary>
        /// GetTable_
        /// </summary>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="displayId">displayId</param>
        /// <returns></returns>
        public string GetTable_(string workType, int companyId, int displayId)
        {
            return (string)GetRow(workType, companyId, displayId)["Table_"];
        }



    }
}
