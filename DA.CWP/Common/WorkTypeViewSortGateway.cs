using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.Common
{
    /// <summary>
    /// WorkTypeViewSortGateway
    /// </summary>
    public class WorkTypeViewSortGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public WorkTypeViewSortGateway()
            : base("LFS_WORK_TYPE_VIEW_SORT")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public WorkTypeViewSortGateway(DataSet data)
            : base(data, "LFS_WORK_TYPE_VIEW_SORT")
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
            tableMapping.DataSetTable = "LFS_WORK_TYPE_VIEW_SORT";
            tableMapping.ColumnMappings.Add("WorkType", "WorkType");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("SortID", "SortID");
            tableMapping.ColumnMappings.Add("Name", "Name");
            tableMapping.ColumnMappings.Add("InFor", "InFor");
            tableMapping.ColumnMappings.Add("InView", "InView");
            tableMapping.ColumnMappings.Add("Column_", "Column_");
            tableMapping.ColumnMappings.Add("Table_", "Table_");
            tableMapping.ColumnMappings.Add("Selected", "Selected");
            tableMapping.ColumnMappings.Add("Order_", "Order_");
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
        /// LoadByWorkTypeInView
        /// </summary>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inView">inView</param>
        /// <returns>data set</returns>
        public DataSet LoadByWorkTypeInView(string workType, int companyId, bool inView)
        {
            FillDataWithStoredProcedure("LFS_CWP_WORKTYPEVIEWSORTGATEWAY_LOADBYWORKTYPEINVIEW", new SqlParameter("@workType", workType), new SqlParameter("@companyId", companyId), new SqlParameter("@inView", inView));
            return Data;
        }



        /// <summary>
        /// LoadByWorkTypeSortId
        /// </summary>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="sortId">sortId</param>
        /// <returns>data set</returns>
        public DataSet LoadByWorkTypeSortId(string workType, int companyId, int sortId)
        {
            FillDataWithStoredProcedure("LFS_CWP_WORKTYPEVIEWSORTGATEWAY_LOADBYWORKTYPESORTID", new SqlParameter("@workType", workType), new SqlParameter("@companyId", companyId), new SqlParameter("@sortId", sortId));
            return Data;
        }



        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="sortId">sortId</param>
        /// <returns></returns>
        public DataRow GetRow(string workType, int companyId, int sortId)
        {
            string filter = string.Format("(WorkType = '{0}') AND (COMPANY_ID = '{1}') AND (SortID  = {2})", workType, companyId, sortId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.CWP.Common.WorkTypeViewSortGateway.GetRow");
            }

        }



        /// <summary>
        /// GetName
        /// </summary>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="sortId">sortId</param>
        /// <returns>Name</returns>
        public string GetName(string workType, int companyId, int sortId)
        {
            return (string)GetRow(workType, companyId, sortId)["Name"];
        }



        /// <summary>
        /// GetColumn_
        /// </summary>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="sortId">sortId</param>
        /// <returns>Column_</returns>
        public string GetColumn_(string workType, int companyId, int sortId)
        {
            return (string)GetRow(workType, companyId, sortId)["Column_"];
        }



        /// <summary>
        /// GetTable_
        /// </summary>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="sortId">sortId</param>
        /// <returns>Table_</returns>
        public string GetTable_(string workType, int companyId, int sortId)
        {
            if (GetRow(workType, companyId, sortId).IsNull("Table_"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workType, companyId, sortId)["Table_"];
            }            
        }



    }
}