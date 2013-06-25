using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Works;

namespace LiquiForce.LFSLive.BL.CWP.Works
{
    /// <summary>
    /// WorkFullLengthLiningInversionPipeConditionList
    /// </summary>
    public class WorkFullLengthLiningInversionPipeConditionList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkFullLengthLiningInversionPipeConditionList()
            : base("LFS_WORK_FULLLENGTHLINING_INVERSION_PIPECONDITION")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkFullLengthLiningInversionPipeConditionList(DataSet data)
            : base(data, "LFS_WORK_FULLLENGTHLINING_INVERSION_PIPECONDITION")
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
        /// <param name="pipeCondition">pipeCondition</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAndAddItem(string pipeCondition, int companyId)
        {
            // Add item
            CreateTableStructure();
            Insert(pipeCondition);

            // Load viewType list
            WorkFullLengthLiningInversionPipeConditionListGateway workFullLengthLiningInversionPipeConditionListGateway = new WorkFullLengthLiningInversionPipeConditionListGateway(Data);
            workFullLengthLiningInversionPipeConditionListGateway.ClearBeforeFill = false;
            workFullLengthLiningInversionPipeConditionListGateway.Load(companyId);
            workFullLengthLiningInversionPipeConditionListGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="pipeCondition">pipeCondition</param>
        public void Insert(string pipeCondition)
        {
            // Verify structure
            if (Table == null)
            {
                CreateTableStructure();
            }

            // Insert row
            DataRow newRow = Table.NewRow();
            newRow["PipeCondition"] = pipeCondition;
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
            System.Data.DataTable table = new DataTable("LFS_WORK_FULLLENGTHLINING_INVERSION_PIPECONDITION");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "PipeCondition";
            Table.Columns.Add(column);
        }
    }
}
