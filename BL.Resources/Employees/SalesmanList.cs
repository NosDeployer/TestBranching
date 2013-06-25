using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Resources.Employees;

namespace LiquiForce.LFSLive.BL.Resources.Employees
{
    /// <summary>
    /// SalesmanList
    /// </summary>
    public class SalesmanList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public SalesmanList() : base("LFS_SALESMAN")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public SalesmanList(DataSet data) : base(data, "LFS_SALESMAN")
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
        /// <param name="salesmanId">salesmanId</param>
        /// <param name="fullName">fullName</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAndAddItem(int salesmanId, string fullName)
        {
            // Add item
            CreateTableStructure();
            Insert(salesmanId, fullName);

            // Load salesman list
            SalesmanListGateway salesmanListGateway = new SalesmanListGateway(Data);
            salesmanListGateway.ClearBeforeFill = false;
            salesmanListGateway.Load();
            salesmanListGateway.ClearBeforeFill = true;

            // Return DataSet
            return Data;
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="salesmanId">salesmanId</param>
        /// <param name="fullName">fullName</param>
        public void Insert(int salesmanId, string fullName)
        {
            // Verify structure
            if (Table == null)
            {
                CreateTableStructure();
            }

            // Insert row
            DataRow newRow = Table.NewRow();
            newRow["SalesmanID"] = salesmanId;
            newRow["FullName"] = fullName;
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
            System.Data.DataTable table = new DataTable("LFS_SALESMAN");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "SalesmanID";
            Table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "FullName";
            Table.Columns.Add(column);
        }



    }
}
