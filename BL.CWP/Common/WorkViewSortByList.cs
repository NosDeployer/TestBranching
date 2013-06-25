using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Common;

namespace LiquiForce.LFSLive.BL.CWP.Common
{
    /// <summary>
    /// WorkViewSortByList
    /// </summary
    public class WorkViewSortByList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkViewSortByList()
            : base("LFS_WORK_VIEW_FOR_DISPLAY")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkViewSortByList(DataSet data)
            : base(data, "LFS_WORK_VIEW_FOR_DISPLAY")
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
        /// <param name="companyId">companyId</param>
        /// <param name="inSortBy">inSortBy</param>
        /// <returns></returns>
        public DataSet LoadAndAddItem(string workType, int companyId, bool inSortBy)
        {
            // Add item
            CreateTableStructure();

            // Load viewType list
            WorkViewSortByListGateway workViewSortByListGateway = new WorkViewSortByListGateway(Data);
            workViewSortByListGateway.ClearBeforeFill = false;
            workViewSortByListGateway.LoadByWorkTypeInSortBy(workType, companyId, inSortBy);
            workViewSortByListGateway.ClearBeforeFill = true;

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
            System.Data.DataTable table = new DataTable("LFS_WORK_VIEW_FOR_DISPLAY");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Name_";
            Table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "NameForDisplay";
            Table.Columns.Add(column);
        }


    }
}
