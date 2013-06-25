using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.LabourHours.ProjectTime;

namespace LiquiForce.LFSLive.BL.LabourHours.ProjectTime
{
    /// <summary>
    /// ProjectTimeWorkList
    /// </summary
    public class ProjectTimeWorkList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectTimeWorkList()
            : base("LFS_PROJECT_TIME_WORK")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectTimeWorkList(DataSet data)
            : base(data, "LFS_PROJECT_TIME_WORK")
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
        /// <returns></returns>
        public DataSet LoadAndAddItem(string work)
        {
            // Add item
            CreateTableStructure();
            Insert(work);

            // Load work list
            ProjectTimeWorkListGateway projectTimeWorkListGateway = new ProjectTimeWorkListGateway(Data);
            projectTimeWorkListGateway.ClearBeforeFill = false;
            projectTimeWorkListGateway.Load();
            projectTimeWorkListGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="work">work</param>
        public void Insert(string work)
        {
            // Verify structure
            if (Table == null)
            {
                CreateTableStructure();
            }

            // Insert row
            DataRow newRow = Table.NewRow();
            newRow["Work_"] = work;
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
            System.Data.DataTable table = new DataTable("LFS_PROJECT_TIME_WORK");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Work_";
            Table.Columns.Add(column);
        }


        
    }
}
