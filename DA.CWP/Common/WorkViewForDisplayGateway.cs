using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.Common
{
    /// <summary>
    /// ColumnsToDisplayGateway
    /// </summary>
    public class WorkViewForDisplayGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public WorkViewForDisplayGateway()
            : base("LFS_WORK_VIEW_FOR_DISPLAY")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public WorkViewForDisplayGateway(DataSet data)
            : base(data, "LFS_WORK_VIEW_FOR_DISPLAY")
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
            tableMapping.DataSetTable = "LFS_WORK_VIEW_FOR_DISPLAY";
            tableMapping.ColumnMappings.Add("WorkType", "WorkType");
            tableMapping.ColumnMappings.Add("Name_", "Name_");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("NameForDisplay", "NameForDisplay");
            tableMapping.ColumnMappings.Add("Table_", "Table_");
            tableMapping.ColumnMappings.Add("InColumnsToDisplay", "InColumnsToDisplay");
            tableMapping.ColumnMappings.Add("InColumnsToDisplayAlways", "InColumnsToDisplayAlways");
            tableMapping.ColumnMappings.Add("InFor", "InFor");
            tableMapping.ColumnMappings.Add("InSortBy", "InSortBy");
            tableMapping.ColumnMappings.Add("OrderToDisplay", "OrderToDisplay");
            tableMapping.ColumnMappings.Add("InColumnsToDisplayByDefault", "InColumnsToDisplayByDefault");
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
        /// LoadByWorkTypeInSortBy
        /// </summary>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inFor">inFor</param>
        /// <returns> Data </returns>
        public DataSet LoadByWorkTypeInFor(string workType, int companyId, bool inFor)
        {
            FillDataWithStoredProcedure("LFS_CWP_WORKVIEWFORDISPLAYGATEWAY_LOADBYWORKTYPEINFOR", new SqlParameter("@workType", workType), new SqlParameter("@companyId", companyId), new SqlParameter("@inFor", inFor));
            return Data;
        }



        /// <summary>
        /// LoadByWorkTypeInSortBy
        /// </summary>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inSortBy">inSortBy</param>
        /// <returns> Data </returns>
        public DataSet LoadByWorkTypeInSortBy(string workType, int companyId, bool inSortBy)
        {
            FillDataWithStoredProcedure("LFS_CWP_WORKVIEWFORDISPLAYGATEWAY_LOADBYWORKTYPEINSORTBY", new SqlParameter("@workType", workType), new SqlParameter("@companyId", companyId), new SqlParameter("@inSortBy", inSortBy));
            return Data;
        }



        /// <summary>
        /// LoadByWorkTypeInColumnsToDisplay
        /// </summary>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inColumnsToDisplay">inColumnsToDisplay</param>
        /// <returns> Data </returns>
        public DataSet LoadByWorkTypeInColumnsToDisplay(string workType, int companyId, bool inColumnsToDisplay)
        {
            FillDataWithStoredProcedure("LFS_CWP_WORKVIEWFORDISPLAYGATEWAY_LOADBYWORKTYPEINCOLUMNSTODISPLAY", new SqlParameter("@workType", workType), new SqlParameter("@companyId", companyId), new SqlParameter("@inColumnsToDisplay", inColumnsToDisplay));
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
            FillDataWithStoredProcedure("LFS_CWP_WORKVIEWFORDISPLAYGATEWAY_LOADBYWORKTYPEINCOLUMNSBYDEFAULT", new SqlParameter("@workType", workType), new SqlParameter("@companyId", companyId), new SqlParameter("@inColumnsByDefault", inColumnsByDefault));
            return Data;
        }



        /// <summary>
        ///  Get a single jliner. If not exists, raise an exception.
        /// </summary>
        /// <param name="workType">workType</param>
        /// <param name="name">name</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Row obtained</returns>
        public DataRow GetRow(string workType, string name, int companyId)
        {
            string filter = string.Format("(WorkType = '{0}') AND (Name_ = '{1}') AND (COMPANY_ID  = {2})", workType, name, companyId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.CWP.Common.WorkViewForDisplayGateway.GetRow");
            }

        }



        /// <summary>
        /// GetRefId. 
        /// </summary>
        /// <param name="workType">workType</param>
        /// <param name="name">name</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Table name</returns>
        public string GetTable(string workType, string name, int companyId)
        {
            return (string)GetRow(workType, name, companyId)["Table_"];
        }
    }
}
