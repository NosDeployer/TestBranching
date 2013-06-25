using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Common;

namespace LiquiForce.LFSLive.BL.CWP.Common
{
    /// <summary>
    /// WorkTypeViewSubAreaList
    /// </summary>
    public class WorkTypeViewSubAreaList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkTypeViewSubAreaList()
            : base("LFS_WORK_TYPE_VIEW_SUBAREA")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkTypeViewSubAreaList(DataSet data)
            : base(data, "LFS_WORK_TYPE_VIEW_SUBAREA")
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
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="projectId">projectId</param>
        /// <returns>Dataset</returns>
        public DataSet LoadAndAddItem(string workType, int companyId, int projectId)
        {
            // Add item
            CreateTableStructure();

            // Load subarea list
            WorkTypeViewSubAreaListGateway workTypeViewSubAreaListGateway = new WorkTypeViewSubAreaListGateway(Data);
            workTypeViewSubAreaListGateway.ClearBeforeFill = false;
            workTypeViewSubAreaListGateway.LoadByWorkTypeProjectId(workType, companyId, projectId);
            workTypeViewSubAreaListGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// LoadAndAddItem
        /// </summary>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="projectId">projectId</param>
        /// <param name="subArea">subArea</param>
        /// <returns>Dataset</returns>
        public DataSet LoadAndAddItem(string workType, int companyId, int projectId, string subArea)
        {
            // Add item
            CreateTableStructure();
            Insert(subArea);

            // Load subarea list
            WorkTypeViewSubAreaListGateway workTypeViewSubAreaListGateway = new WorkTypeViewSubAreaListGateway(Data);
            workTypeViewSubAreaListGateway.ClearBeforeFill = false;
            workTypeViewSubAreaListGateway.LoadByWorkTypeProjectId(workType, companyId, projectId);
            workTypeViewSubAreaListGateway.ClearBeforeFill = true;

            return Data;
        }





        
        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="subArea">subArea</param>
        private void Insert(string subArea)
        {
            // Verify structure
            if (Table == null)
            {
                CreateTableStructure();
            }

            // Insert row
            DataRow newRow = Table.NewRow();
            newRow["SubArea"] = subArea;
            Table.Rows.Add(newRow);

            // Insert row ""
            DataRow newRowNull = Table.NewRow();
            newRowNull["SubArea"] = "";
            Table.Rows.Add(newRowNull);
        }



        /// <summary>
        /// CreateTableStructure
        /// </summary>
        private void CreateTableStructure()
        {
            // Create table
            System.Data.DataTable table = new DataTable("LFS_WORK_TYPE_VIEW_SUBAREA");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;
            
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "SubArea";
            Table.Columns.Add(column);            
        }



    }
}