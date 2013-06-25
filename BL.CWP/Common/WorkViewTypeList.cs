using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Common;

namespace LiquiForce.LFSLive.BL.CWP.Common
{
    /// <summary>
    /// WorkViewTypeList
    /// </summary
    public class WorkViewTypeList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkViewTypeList()
            : base("LFS_WORK_VIEW_TYPE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkViewTypeList(DataSet data)
            : base(data, "LFS_WORK_VIEW_TYPE")
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
        /// <param name="type">type</param>
        /// <param name="companyId">companyId</param>
        /// <returns></returns>
        public DataSet LoadAndAddItem(string type, int companyId)
        {
            // Add item
            CreateTableStructure();
            Insert(type);

            // Load viewType list
            WorkViewTypeListGateway workViewTypeListGateway = new WorkViewTypeListGateway(Data);
            workViewTypeListGateway.ClearBeforeFill = false;
            workViewTypeListGateway.Load(companyId);
            workViewTypeListGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="type"></param>
        public void Insert(string type)
        {
            // Verify structure
            if (Table == null)
            {
                CreateTableStructure();
            }

            // Insert row
            DataRow newRow = Table.NewRow();
            newRow["Type"] = type;
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
            System.Data.DataTable table = new DataTable("LFS_WORK_VIEW_TYPE");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Type";
            Table.Columns.Add(column);
        }



    }
}
