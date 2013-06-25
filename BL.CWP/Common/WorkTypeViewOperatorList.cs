using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Common;

namespace LiquiForce.LFSLive.BL.CWP.Common
{
    /// <summary>
    /// WorkTypeViewOperatorList
    /// </summary>
    public class WorkTypeViewOperatorList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkTypeViewOperatorList()
            : base("LFS_WORK_TYPE_VIEW_OPERATOR")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkTypeViewOperatorList(DataSet data)
            : base(data, "LFS_WORK_TYPE_VIEW_OPERATOR")
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
        /// <param name="type"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public DataSet LoadAndAddItem(string type, int companyId)
        {
            // Add item
            CreateTableStructure();

            // Load viewType list
            WorkTypeViewOperatorListGateway workTypeViewOperatorListGateway = new WorkTypeViewOperatorListGateway(Data);
            workTypeViewOperatorListGateway.ClearBeforeFill = false;
            workTypeViewOperatorListGateway.LoadByType(type, companyId);
            workTypeViewOperatorListGateway.ClearBeforeFill = true;

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
            System.Data.DataTable table = new DataTable("LFS_WORK_TYPE_VIEW_OPERATOR");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Operator";
            Table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Sign";
            Table.Columns.Add(column);
        }



    }
}


