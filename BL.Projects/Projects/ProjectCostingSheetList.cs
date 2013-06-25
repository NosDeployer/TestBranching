using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectCostingSheetList
    /// </summary>
    public class ProjectCostingSheetList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectCostingSheetList()
            : base("LFS_PROJECT_COSTING_SHEET")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectCostingSheetList(DataSet data)
            : base(data, "LFS_PROJECT_COSTING_SHEET")
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
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="name">name</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAndAddItem(int costingSheetId, string name, int companyId)
        {
            // Add item
            CreateTableStructure();
            Insert(costingSheetId, name);

            // Load costing sheet list
            ProjectCostingSheetListGateway projectCostingSheetListGateway = new ProjectCostingSheetListGateway(Data);
            projectCostingSheetListGateway.ClearBeforeFill = false;
            projectCostingSheetListGateway.Load(companyId);
            projectCostingSheetListGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="name">name</param>
        public void Insert(int costingSheetId, string name)
        {
            // Verify structure
            if (Table == null)
            {
                CreateTableStructure();
            }

            // Insert row
            DataRow newRow = Table.NewRow();
            newRow["CostingSheetID"] = costingSheetId;
            newRow["Name"] = name;
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
            System.Data.DataTable table = new DataTable("LFS_PROJECT_COSTING_SHEET");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "CostingSheetID";
            Table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Name";
            Table.Columns.Add(column);
        }



    }
}