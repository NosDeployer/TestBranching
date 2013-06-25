using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Works;

namespace LiquiForce.LFSLive.BL.CWP.Works
{
    /// <summary>
    /// WorkFullLengthLiningResinsList
    /// </summary
    public class WorkFullLengthLiningResinsList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkFullLengthLiningResinsList()
            : base("LFS_WORK_FULLLENGTHLINING_RESINS")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkFullLengthLiningResinsList(DataSet data)
            : base(data, "LFS_WORK_FULLLENGTHLINING_RESINS")
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
        /// <param name="id">id</param>
        /// <param name="resin">resin</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAndAddItem(int id, string resin, int companyId)
        {
            // Add item
            CreateTableStructure();
            Insert(id, resin);

            // Load viewType list
            WorkFullLengthLiningResinsListGateway workFullLengthLiningResinsListGateway = new WorkFullLengthLiningResinsListGateway(Data);
            workFullLengthLiningResinsListGateway.ClearBeforeFill = false;
            workFullLengthLiningResinsListGateway.Load(companyId);
            workFullLengthLiningResinsListGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="resin">resin</param>
        public void Insert(int id, string resin)
        {
            // Verify structure
            if (Table == null)
            {
                CreateTableStructure();
            }

            // Insert row
            DataRow newRow = Table.NewRow();
            newRow["ResinID"] = id;
            newRow["Resin"] = resin;
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
            System.Data.DataTable table = new DataTable("LFS_WORK_FULLLENGTHLINING_RESINS");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "ResinID";
            Table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Resin";
            Table.Columns.Add(column);
        }
    }
}
