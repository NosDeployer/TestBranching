using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Works;

namespace LiquiForce.LFSLive.BL.CWP.Works
{
    /// <summary>
    /// WorkFullLengthLiningInversionPipeTypeList
    /// </summary>
    public class WorkFullLengthLiningInversionPipeTypeList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkFullLengthLiningInversionPipeTypeList()
            : base("LFS_WORK_FULLLENGTHLINING_INVERSION_PIPETYPE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkFullLengthLiningInversionPipeTypeList(DataSet data)
            : base(data, "LFS_WORK_FULLLENGTHLINING_INVERSION_PIPETYPE")
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
        /// <param name="pipeType">pipeType</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAndAddItem(string pipeType, int companyId)
        {
            // Add item
            CreateTableStructure();
            Insert(pipeType);

            // Load viewType list
            WorkFullLengthLiningInversionPipeTypeListGateway workFullLengthLiningInversionPipeTypeListGateway = new WorkFullLengthLiningInversionPipeTypeListGateway(Data);
            workFullLengthLiningInversionPipeTypeListGateway.ClearBeforeFill = false;
            workFullLengthLiningInversionPipeTypeListGateway.Load(companyId);
            workFullLengthLiningInversionPipeTypeListGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="pipeType">pipeType</param>
        public void Insert(string pipeType)
        {
            // Verify structure
            if (Table == null)
            {
                CreateTableStructure();
            }

            // Insert row
            DataRow newRow = Table.NewRow();
            newRow["PipeType"] = pipeType;
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
            System.Data.DataTable table = new DataTable("LFS_WORK_FULLLENGTHLINING_INVERSION_PIPETYPE");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "PipeType";
            Table.Columns.Add(column);
        }
    }
}
