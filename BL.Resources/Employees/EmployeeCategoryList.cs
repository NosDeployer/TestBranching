using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Resources.Employees;

namespace LiquiForce.LFSLive.BL.Resources.Employees
{
    public class EmployeeCategoryList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public EmployeeCategoryList()
            : base("LFS_RESOURCES_EMPLOYEE_CATEGORY")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public EmployeeCategoryList(DataSet data)
            : base(data, "LFS_RESOURCES_EMPLOYEE_CATEGORY")
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
        /// <param name="category">category</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAndAddItem(string category)
        {
            // Add item
            CreateTableStructure();
            Insert(category);

            // Load category list
            EmployeeCategoryListGateway employeeCategoryListGateway = new EmployeeCategoryListGateway(Data);
            employeeCategoryListGateway.ClearBeforeFill = false;
            employeeCategoryListGateway.Load();
            employeeCategoryListGateway.ClearBeforeFill = true;

            // Return DataSet
            return Data;
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="category">category</param>
        public void Insert(string category)
        {
            // Verify structure
            if (Table == null)
            {
                CreateTableStructure();
            }

            // Insert row
            DataRow newRow = Table.NewRow();
            newRow["Category"] = category;
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
            System.Data.DataTable table = new DataTable("LFS_RESOURCES_EMPLOYEE_CATEGORY");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Category";
            Table.Columns.Add(column);
        }



    }
}