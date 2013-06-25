using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.LabourHours.ActualCosts;

namespace LiquiForce.LFSLive.BL.Resources.Hotels
{
    /// <summary>
    /// ActualCostsCategoryList
    /// </summary>
    public class ActualCostsCategoryList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ActualCostsCategoryList()
            : base("LFS_LABOUR_HOURS_ACTUAL_COSTS_CATEGORY")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ActualCostsCategoryList(DataSet data)
            : base(data, "LFS_LABOUR_HOURS_ACTUAL_COSTS_CATEGORY")
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
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAndAddItem(string category, int companyId)
        {
            // Add item
            CreateTableStructure();
            Insert(category);

            // Load costing sheet list
            ActualCostsCategoryListGateway actualCostsCategoryListGateway = new ActualCostsCategoryListGateway(Data);
            actualCostsCategoryListGateway.ClearBeforeFill = false;
            actualCostsCategoryListGateway.Load(companyId);
            actualCostsCategoryListGateway.ClearBeforeFill = true;

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
            System.Data.DataTable table = new DataTable("LFS_LABOUR_HOURS_ACTUAL_COSTS_CATEGORY");
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