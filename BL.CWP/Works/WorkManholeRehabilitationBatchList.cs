using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Works;

namespace LiquiForce.LFSLive.BL.CWP.Works
{
    /// <summary>
    /// WorkManholeRehabilitationBatchList
    /// </summary>
    public class WorkManholeRehabilitationBatchList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkManholeRehabilitationBatchList()
            : base("LFS_WORK_MANHOLE_REHABILITATION_BATCH")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkManholeRehabilitationBatchList(DataSet data)
            : base(data, "LFS_WORK_MANHOLE_REHABILITATION_BATCH")
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
        /// <param name="batchId">batchId</param>
        /// <param name="description">description</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAndAddItem(int batchId,string  description, int companyId)
        {
            // Add item
            CreateTableStructure();
            Insert(batchId, description);

            // Load list
            WorkManholeRehabilitationBatchListGateway workManholeRehabilitationBatchListGateway = new WorkManholeRehabilitationBatchListGateway(Data);
            workManholeRehabilitationBatchListGateway.ClearBeforeFill = false;
            workManholeRehabilitationBatchListGateway.Load(companyId);
            workManholeRehabilitationBatchListGateway.ClearBeforeFill = true;

            return Data;
        }
                       


        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="batchId">batchId</param>
        /// <param name="description">description</param>
        public void Insert(int batchId, string description)
        {
            // Verify structure
            if (Table == null)
            {
                CreateTableStructure();
            }

            // Insert row
            DataRow newRow = Table.NewRow();
            newRow["BatchID"] = batchId;
            newRow["Description"] = description;            

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
            System.Data.DataTable table = new DataTable("LFS_WORK_MANHOLE_REHABILITATION_BATCH");
            Data.Tables.Add(table);

            // Add columns
            DataColumn columnBatchId = new DataColumn();
            columnBatchId.DataType = Type.GetType("System.Int32");
            columnBatchId.ColumnName = "BatchID";
            
            DataColumn columnDescription = new DataColumn();
            columnDescription.DataType = Type.GetType("System.String");
            columnDescription.ColumnName = "Description";

            table.Columns.Add(columnDescription);
            table.Columns.Add(columnBatchId);
        }



    }
}