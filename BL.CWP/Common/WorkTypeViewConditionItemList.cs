using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Common;

namespace LiquiForce.LFSLive.BL.CWP.Common
{
    /// <summary>
    /// WorkTypeViewConditionItemList
    /// </summary>
    public class WorkTypeViewConditionItemList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkTypeViewConditionItemList()
            : base("LFS_WORK_TYPE_VIEW_CONDITION_ITEM")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkTypeViewConditionItemList(DataSet data)
            : base(data, "LFS_WORK_TYPE_VIEW_CONDITION_ITEM")
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
        /// <param name="workType"></param>
        /// <param name="companyId"></param>
        /// <param name="conditionId"></param>
        /// <returns></returns>
        public DataSet LoadAndAddItemInView(string workType, int companyId, int conditionId)
        {
            // Add item
            CreateTableStructure();

            // Load viewType list
            WorkTypeViewConditionItemListGateway workTypeViewConditionItemListGateway = new WorkTypeViewConditionItemListGateway(Data);
            workTypeViewConditionItemListGateway.ClearBeforeFill = false;
            workTypeViewConditionItemListGateway.LoadByWorkTypeConditionId(workType, conditionId, companyId);
            workTypeViewConditionItemListGateway.ClearBeforeFill = true;

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
            System.Data.DataTable table = new DataTable("LFS_WORK_TYPE_VIEW_CONDITION_ITEM");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Name";
            Table.Columns.Add(column);
        }        



    }
}


