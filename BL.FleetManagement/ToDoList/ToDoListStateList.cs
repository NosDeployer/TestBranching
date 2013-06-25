using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.ToDoList;

namespace LiquiForce.LFSLive.BL.FleetManagement.ToDoList
{
    /// <summary>
    /// ToDoListStateList
    /// </summary
    public class ToDoListStateList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ToDoListStateList()
            : base("LFS_FM_TODOLIST_STATE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ToDoListStateList(DataSet data)
            : base(data, "LFS_FM_TODOLIST_STATE")
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
        /// <returns>DataSet</returns>
        public DataSet LoadAndAddItem(string type, int companyId)
        {
            // Add item
            CreateTableStructure();
            Insert(type);

            // Load service state list
            ToDoListStateListGateway toDoListStateListGateway = new ToDoListStateListGateway(Data);
            toDoListStateListGateway.ClearBeforeFill = false;
            toDoListStateListGateway.LoadAll(companyId);
            Insert("New & In Progress");
            toDoListStateListGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="type">type</param>
        public void Insert(string type)
        {
            // Verify structure
            if (Table == null)
            {
                CreateTableStructure();
            }

            // Insert row
            DataRow newRow = Table.NewRow();
            newRow["State"] = type;
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
            System.Data.DataTable table = new DataTable("LFS_FM_TODOLIST_STATE");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "State";
            Table.Columns.Add(column);
        }


    }
}
