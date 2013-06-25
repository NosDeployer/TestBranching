using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.LabourHours.TeamProjectTime;

namespace LiquiForce.LFSLive.BL.LabourHours.TeamProjectTime
{
    /// <summary>
    /// TeamProjectTimeWorkFunctionList
    /// </summary>
    public class TeamProjectTimeWorkFunctionConcatList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public TeamProjectTimeWorkFunctionConcatList()
            : base("TEAM_PROJECT_TIME_WORK_FUNCTION_CONCAT")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public TeamProjectTimeWorkFunctionConcatList(DataSet data)
            : base(data, "TEAM_PROJECT_TIME_WORK_FUNCTION_CONCAT")
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
        /// <param name="workFunctionConcat">Work Function concat</param>
        /// <returns></returns>
        public DataSet LoadAndAddItem(string workFunctionConcat)
        {
            // Add item
            CreateTableStructure();
            Insert(workFunctionConcat);

            // Load type of work - string function
            TeamProjectTimeWorkFunctionConcatGateway teamProjectTimeWorkFunctionGateway = new TeamProjectTimeWorkFunctionConcatGateway(Data);
            teamProjectTimeWorkFunctionGateway.ClearBeforeFill = false;
            teamProjectTimeWorkFunctionGateway.LoadWorkFunctionConcat();
            teamProjectTimeWorkFunctionGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="workFunctionConcat">workFunctionConcat</param>
        public void Insert(string workFunctionConcat)
        {
            // Verify structure
            if (Table == null)
            {
                CreateTableStructure();
            }

            // Insert row
            DataRow newRow = Table.NewRow();
            newRow["WorkFunctionConcat"] = workFunctionConcat;
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
            System.Data.DataTable table = new DataTable("TEAM_PROJECT_TIME_WORK_FUNCTION_CONCAT");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "WorkFunctionConcat";
            Table.Columns.Add(column);
        }


        
    }
}