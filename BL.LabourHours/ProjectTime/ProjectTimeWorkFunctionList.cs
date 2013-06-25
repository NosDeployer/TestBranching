using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.LabourHours.ProjectTime;

namespace LiquiForce.LFSLive.BL.LabourHours.ProjectTime
{
    /// <summary>
    /// ProjectTimeWorkFunctionList
    /// </summary
    public class ProjectTimeWorkFunctionList : TableModule
    {

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectTimeWorkFunctionList()
            : base("LFS_PROJECT_TIME_WORK_FUNCTION")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectTimeWorkFunctionList(DataSet data)
            : base(data, "LFS_PROJECT_TIME_WORK_FUNCTION")
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
        /// <param name="work">work</param>
        /// <param name="function">function</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAndAddItem(string function, string work)
        {
            // Add item
            CreateTableStructure();
            Insert(function, work);

            // Load companies list
            ProjectTimeWorkFunctionListGateway projectTimeWorkFunctionListGateway = new ProjectTimeWorkFunctionListGateway(Data);
            projectTimeWorkFunctionListGateway.ClearBeforeFill = false;
            projectTimeWorkFunctionListGateway.LoadByWork(work);
            projectTimeWorkFunctionListGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// LoadAndAddItem
        /// </summary>
        /// <param name="work">work</param>
        /// <param name="function">function</param>
        /// <returns>DataSet</returns>
        public DataSet LoadActiveForAddAndAddItem(string function, string work)
        {
            // Add item
            CreateTableStructure();
            Insert(function, work);

            // Load companies list
            ProjectTimeWorkFunctionListGateway projectTimeWorkFunctionListGateway = new ProjectTimeWorkFunctionListGateway(Data);
            projectTimeWorkFunctionListGateway.ClearBeforeFill = false;
            projectTimeWorkFunctionListGateway.LoadActiveForAddByWork(work);
            projectTimeWorkFunctionListGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="function">function</param>
        /// <param name="work">work</param>
        /// <param name="name">name</param>
        public void Insert(string function, string work)
        {
            // Verify structure
            if (Table == null)
            {
                CreateTableStructure();
            }

            // Insert row
            DataRow newRow = Table.NewRow();
            newRow["Work_"] = work;
            newRow["Function_"] = function;
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
            System.Data.DataTable table = new DataTable("LFS_PROJECT_TIME_WORK_FUNCTION");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Work_";
            Table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Function_";
            Table.Columns.Add(column);

        }




    }
}
