using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Works;

namespace LiquiForce.LFSLive.BL.CWP.Works
{
    /// <summary>
    /// WorkPointRepairsRepairPointSizeList
    /// </summary>
    public class WorkPointRepairsRepairPointSizeList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkPointRepairsRepairPointSizeList()
            : base("LFS_WORK_POINT_REPAIRS_REPAIRPOINT_SIZE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkPointRepairsRepairPointSizeList(DataSet data)
            : base(data, "LFS_WORK_POINT_REPAIRS_REPAIRPOINT_SIZE")
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
        /// <param name="size_">size_</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAndAddItem(string size_, int companyId)
        {
            // Add item
            CreateTableStructure();
            Insert(size_);

            // Load viewType list
            WorkPointRepairsRepairPointSizeListGateway workPointRepairsRepairPointSizeListGateway = new WorkPointRepairsRepairPointSizeListGateway(Data);
            workPointRepairsRepairPointSizeListGateway.ClearBeforeFill = false;
            workPointRepairsRepairPointSizeListGateway.Load(companyId);
            workPointRepairsRepairPointSizeListGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="size_">size_</param>
        public void Insert(string size_)
        {
            // Verify structure
            if (Table == null)
            {
                CreateTableStructure();
            }

            // Insert row
            DataRow newRow = Table.NewRow();

            newRow["Size_"] = size_;
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
            System.Data.DataTable table = new DataTable("LFS_WORK_POINT_REPAIRS_REPAIRPOINT_SIZE");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Size_";
            Table.Columns.Add(column);
        }



    }
}