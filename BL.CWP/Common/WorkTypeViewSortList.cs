using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Common;

namespace LiquiForce.LFSLive.BL.CWP.Common
{
    /// <summary>
    /// WorkTypeViewSortList
    /// </summary>
    public class WorkTypeViewSortList : TableModule 
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkTypeViewSortList()
            : base("LFS_WORK_TYPE_VIEW_SORT")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkTypeViewSortList(DataSet data)
            : base(data, "LFS_WORK_TYPE_VIEW_SORT")
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
        /// LoadAndAddItemInFor
        /// </summary>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inFor">inFor</param>
        /// <returns></returns>
        public DataSet LoadAndAddItemInFor(string workType, int companyId, bool inFor)
        {
            // Add item
            CreateTableStructure();

            // Load viewType list
            WorkTypeViewSortListGateway workTypeViewSortListGateway = new WorkTypeViewSortListGateway(Data);
            workTypeViewSortListGateway.ClearBeforeFill = false;
            workTypeViewSortListGateway.LoadByWorkTypeInFor(workType, companyId, inFor);
            workTypeViewSortListGateway.ClearBeforeFill = true;

            return Data;
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
            System.Data.DataTable table = new DataTable("LFS_WORK_TYPE_VIEW_SORT");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;
            
            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "SortID";
            Table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Name";
            Table.Columns.Add(column);
        }



    }
}

