using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Works;

namespace LiquiForce.LFSLive.BL.CWP.Works
{
    /// <summary>
    /// WorkFullLengthLiningWetOutLinerTubeList
    /// </summary>
    public class WorkFullLengthLiningWetOutLinerTubeList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkFullLengthLiningWetOutLinerTubeList()
            : base("LFS_WORK_FULLLENGTHLINING_WETOUT_LINERTUBE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkFullLengthLiningWetOutLinerTubeList(DataSet data)
            : base(data, "LFS_WORK_FULLLENGTHLINING_WETOUT_LINERTUBE")
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
        /// <param name="linerTube">linerTube</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAndAddItem(string linerTube, int companyId)
        {
            // Add item
            CreateTableStructure();
            Insert(linerTube);

            // Load viewType list
            WorkFullLengthLiningWetOutLinerTubeListGateway workFullLengthLiningWetOutLinerTubeListGateway = new WorkFullLengthLiningWetOutLinerTubeListGateway(Data);
            workFullLengthLiningWetOutLinerTubeListGateway.ClearBeforeFill = false;
            workFullLengthLiningWetOutLinerTubeListGateway.Load(companyId);
            workFullLengthLiningWetOutLinerTubeListGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="linerTube">linerTube</param>
        public void Insert(string linerTube)
        {
            // Verify structure
            if (Table == null)
            {
                CreateTableStructure();
            }

            // Insert row
            DataRow newRow = Table.NewRow();
            newRow["LinerTube"] = linerTube;
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
            System.Data.DataTable table = new DataTable("LFS_WORK_FULLLENGTHLINING_WETOUT_LINERTUBE");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "LinerTube";
            Table.Columns.Add(column);
        }
    }
}
