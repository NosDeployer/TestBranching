using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Works;

namespace LiquiForce.LFSLive.BL.CWP.Works
{
    /// <summary>
    /// WorkPointRepairsRepairPointLengthList
    /// </summary>
    public class WorkPointRepairsRepairPointLengthList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkPointRepairsRepairPointLengthList()
            : base("LFS_WORK_POINT_REPAIRS_REPAIRPOINT_LENGTH")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkPointRepairsRepairPointLengthList(DataSet data)
            : base(data, "LFS_WORK_POINT_REPAIRS_REPAIRPOINT_LENGTH")
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
        /// <param name="length">length</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>
        public DataSet LoadAndAddItem(string length, int companyId)
        {
            // Add item
            CreateTableStructure();
            Insert(length);

            // Load countries list
            WorkPointRepairsRepairPointLengthListGateway workPointRepairsRepairPointLengthListGateway = new WorkPointRepairsRepairPointLengthListGateway(Data);
            workPointRepairsRepairPointLengthListGateway.ClearBeforeFill = false;
            workPointRepairsRepairPointLengthListGateway.Load(companyId);
            workPointRepairsRepairPointLengthListGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="length">length</param>        
        public void Insert(string length)
        {
            // Verify structure
            if (Table == null)
            {
                CreateTableStructure();
            }

            // Insert row
            DataRow newRow = Table.NewRow();
            newRow["Length"] = length;
            Table.Rows.Add(newRow);
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// CreateTableStructure
        /// </summary>
        public void CreateTableStructure()
        {
            // Create table
            System.Data.DataTable table = new DataTable("LFS_WORK_POINT_REPAIRS_REPAIRPOINT_LENGTH");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Length";
            Table.Columns.Add(column);
        }
    }


}
