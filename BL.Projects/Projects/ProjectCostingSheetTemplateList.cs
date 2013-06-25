using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectCostingSheetTemplateList
    /// </summary>
    public class ProjectCostingSheetTemplateList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectCostingSheetTemplateList()
            : base("LFS_PROJECT_COSTING_SHEET_TEMPLATE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectCostingSheetTemplateList(DataSet data)
            : base(data, "LFS_PROJECT_COSTING_SHEET_TEMPLATE")
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
        /// <param name="costingTemplateSheetId">costingTemplateSheetId</param>
        /// <param name="name">name</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAndAddItem(int costingTemplateSheetId, string name, int companyId)
        {
            // Add item
            CreateTableStructure();
            Insert(costingTemplateSheetId, name);

            // Load costing sheet list
            ProjectCostingSheetTemplateListGateway projectCostingSheetTemplateListGateway = new ProjectCostingSheetTemplateListGateway(Data);
            projectCostingSheetTemplateListGateway.ClearBeforeFill = false;
            projectCostingSheetTemplateListGateway.Load(companyId);
            projectCostingSheetTemplateListGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="costingTemplateSheetId">costingTemplateSheetId</param>
        /// <param name="name">name</param>
        public void Insert(int costingTemplateSheetId, string name)
        {
            // Verify structure
            if (Table == null)
            {
                CreateTableStructure();
            }

            // Insert row
            DataRow newRow = Table.NewRow();
            newRow["CostingSheetTemplateID"] = costingTemplateSheetId;
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
            System.Data.DataTable table = new DataTable("LFS_PROJECT_COSTING_SHEET_TEMPLATE");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "CostingSheetTemplateID";
            Table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Name";
            Table.Columns.Add(column);
        }



    }
}