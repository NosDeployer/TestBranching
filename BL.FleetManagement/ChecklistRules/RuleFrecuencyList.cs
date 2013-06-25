using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.ChecklistRules;

namespace LiquiForce.LFSLive.BL.FleetManagement.ChecklistRules
{
    /// <summary>
    /// RuleFrecuencyList
    /// </summary>
    public class RuleFrecuencyList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public RuleFrecuencyList()
            : base("LFS_FM_RULE_FRECUENCY")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public RuleFrecuencyList(DataSet data)
            : base(data, "LFS_FM_RULE_FRECUENCY")
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
        /// <param name="frequency">frequency</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAndAddItem(string frequency, int companyId)
        {
            // Add item
            CreateTableStructure();
            Insert(frequency);

            // Load frequency list
            RuleFrecuencyListGateway ruleFrecuencyListGateway = new RuleFrecuencyListGateway(Data);
            ruleFrecuencyListGateway.ClearBeforeFill = false;
            ruleFrecuencyListGateway.Load(companyId);
            ruleFrecuencyListGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="frequency">frequency</param>
        public void Insert(string frequency)
        {
            // Verify structure
            if (Table == null)
            {
                CreateTableStructure();
            }

            // Insert row
            DataRow newRow = Table.NewRow();
            newRow["Frequency"] = frequency;
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
            System.Data.DataTable table = new DataTable("LFS_FM_RULE_FRECUENCY");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Frequency";
            Table.Columns.Add(column);
        }



    }
}

