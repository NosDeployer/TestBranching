using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Common;

namespace LiquiForce.LFSLive.BL.CWP.Common
{
    /// <summary>
    /// WorkTypeViewConditionList
    /// </summary>
    public class WorkTypeViewConditionList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkTypeViewConditionList()
            : base("LFS_WORK_TYPE_VIEW_CONDITION")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkTypeViewConditionList(DataSet data)
            : base(data, "LFS_WORK_TYPE_VIEW_CONDITION")
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
        /// LoadAndAddItemInView
        /// </summary>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inView">inView</param>
        /// <returns>dataset</returns>
        public DataSet LoadAndAddItemInView(string workType, int companyId, bool inView)
        {
            // Add item
            CreateTableStructure();

            // Load viewType list
            WorkTypeViewConditionListGateway workTypeViewConditionListGateway = new WorkTypeViewConditionListGateway(Data);
            workTypeViewConditionListGateway.ClearBeforeFill = false;
            workTypeViewConditionListGateway.LoadByWorkTypeInView(workType, companyId, inView);
            workTypeViewConditionListGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// LoadAndAddItemInFor
        /// </summary>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inFor">inFor</param>
        /// <returns>dataset</returns>
        public DataSet LoadAndAddItemInFor(string workType, int companyId, bool inFor)
        {
            // Add item
            CreateTableStructure();

            // Load viewType list
            WorkTypeViewConditionListGateway workTypeViewConditionListGateway = new WorkTypeViewConditionListGateway(Data);
            workTypeViewConditionListGateway.ClearBeforeFill = false;
            workTypeViewConditionListGateway.LoadByWorkTypeInFor(workType, companyId, inFor);
            workTypeViewConditionListGateway.ClearBeforeFill = true;

            return Data;
        }






        /// <summary>
        /// LoadAndAddItemInFor
        /// </summary>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inFor">inFor</param>
        /// <param name="conditionId">conditionId</param>
        /// <param name="name">name</param>
        /// <returns>dataset</returns>
        public DataSet LoadAndAddItemInFor(string workType, int companyId, bool inFor, int conditionId, string name)
        {
            // Add item
            CreateTableStructure();
            Insert(conditionId, name);

            // Load viewType list
            WorkTypeViewConditionListGateway workTypeViewConditionListGateway = new WorkTypeViewConditionListGateway(Data);
            workTypeViewConditionListGateway.ClearBeforeFill = false;
            workTypeViewConditionListGateway.LoadByWorkTypeInFor(workType, companyId, inFor);
            workTypeViewConditionListGateway.ClearBeforeFill = true;

            return Data;
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
            System.Data.DataTable table = new DataTable("LFS_WORK_TYPE_VIEW_CONDITION");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;

            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "ConditionID";
            Table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Name";
            Table.Columns.Add(column);
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="conditionId">conditionId</param>
        /// <param name="name">name</param>
        public void Insert(int conditionId, string name)
        {
            // Verify structure
            if (Table == null)
            {
                CreateTableStructure();
            }

            // Insert row
            DataRow newRow = Table.NewRow();
            newRow["ConditionID"] = conditionId;
            newRow["Name"] = name;
            Table.Rows.Add(newRow);
        }



    }
}

