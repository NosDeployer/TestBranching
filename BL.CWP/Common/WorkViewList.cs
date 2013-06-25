using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Common;

namespace LiquiForce.LFSLive.BL.CWP.Common
{
    /// <summary>
    /// WorkViewList
    /// </summary
    public class WorkViewList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkViewList()
            : base("LFS_WORK_VIEW")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkViewList(DataSet data)
            : base(data, "LFS_WORK_VIEW")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new DataSet();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadAndAddItem
        /// </summary>
        /// <param name="workType">workType</param>
        /// <param name="viewTypeGlobal">viewTypeGlobal</param>
        /// <param name="viewTypePersonal">viewTypePersonal</param>
        /// <param name="loginId">loginId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Dataset</returns>
        public DataSet LoadAndAddItem(string workType, string viewTypeGlobal, string viewTypePersonal, int  loginId, int companyId)
        {
            // Add item
            CreateTableStructure();

            // Load viewType list
            WorkViewListGateway workViewListGateway = new WorkViewListGateway(Data);
            workViewListGateway.ClearBeforeFill = false;
            
            // Global views
            if (viewTypeGlobal == "Global")
            {
                // Global views
                Insert(-1, "----- GLOBAL VIEWS -----");
                workViewListGateway.LoadByWorkTypeGlobalViewType(workType, viewTypeGlobal, companyId);
            }

            //Personal Views
            Insert(-2, "----- PERSONAL VIEWS -----"); 
            workViewListGateway.LoadByWorkTypeLoginIdViewType(workType, loginId, viewTypePersonal, companyId);

            workViewListGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="comment">comment</param>
        public void Insert(int viewId, string comment)
        {
            // Verify structure
            if (Table == null)
            {
                CreateTableStructure();
            }

            // Insert row
            DataRow newRow = Table.NewRow();
            newRow["ViewID"] = viewId;
            newRow["Name"] = comment;
            Table.Rows.Add(newRow);
        }





                
        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// CreateTableStructure
        /// </summary>
        private void CreateTableStructure()
        {
            // Create table
            System.Data.DataTable table = new DataTable("LFS_WORK_VIEW");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32"); 
            column.ColumnName = "ViewID";
            Table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Name";
            Table.Columns.Add(column);
        }


    }
}
