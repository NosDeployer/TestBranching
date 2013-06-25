using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Works;

namespace LiquiForce.LFSLive.BL.CWP.Works
{
    /// <summary>
    /// WorkFullLengthLiningM2SurfaceGradeList
    /// </summary
    public class WorkFullLengthLiningM2SurfaceGradeList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkFullLengthLiningM2SurfaceGradeList()
            : base("LFS_WORK_FULLLENGTHLINING_M2_SURFACE_GRADE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkFullLengthLiningM2SurfaceGradeList(DataSet data)
            : base(data, "LFS_WORK_FULLLENGTHLINING_M2_SURFACE_GRADE")
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
        /// <param name="surfaceGrade">surfaceGrade</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAndAddItem(string surfaceGrade, int companyId)
        {
            // Add item
            CreateTableStructure();
            Insert(surfaceGrade);

            // Load viewType list
            WorkFullLengthLiningM2SurfaceGradeListGateway workFullLengthLiningM2SurfaceGradeListGateway = new WorkFullLengthLiningM2SurfaceGradeListGateway(Data);
            workFullLengthLiningM2SurfaceGradeListGateway.ClearBeforeFill = false;
            workFullLengthLiningM2SurfaceGradeListGateway.Load(companyId);
            workFullLengthLiningM2SurfaceGradeListGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="surfaceGrade">surfaceGrade</param>
        public void Insert(string surfaceGrade)
        {
            // Verify structure
            if (Table == null)
            {
                CreateTableStructure();
            }

            // Insert row
            DataRow newRow = Table.NewRow();
            newRow["SurfaceGrade"] = surfaceGrade;
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
            System.Data.DataTable table = new DataTable("LFS_WORK_FULLLENGTHLINING_M2_SURFACE_GRADE");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "SurfaceGrade";
            Table.Columns.Add(column);
        }

    }
}
