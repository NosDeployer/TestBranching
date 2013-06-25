using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Works;

namespace LiquiForce.LFSLive.BL.CWP.Works
{
    /// <summary>
    /// WorkFullLengthLiningM1TrafficControlList
    /// </summary
    public class WorkFullLengthLiningM1TrafficControlList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkFullLengthLiningM1TrafficControlList()
            : base("LFS_WORK_FULLLENGTHLINING_M1_TRAFFICCONTROL")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkFullLengthLiningM1TrafficControlList(DataSet data)
            : base(data, "LFS_WORK_FULLLENGTHLINING_M1_TRAFFICCONTROL")
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
        /// <param name="trafficControl">trafficControl</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAndAddItem( string trafficControl, int companyId)
        {
            // Add item
            CreateTableStructure();
            Insert(trafficControl);

            // Load viewType list
            WorkFullLengthLiningM1TrafficControlListGateway workFullLengthLiningM1TrafficControlListGateway = new WorkFullLengthLiningM1TrafficControlListGateway(Data);
            workFullLengthLiningM1TrafficControlListGateway.ClearBeforeFill = false;
            workFullLengthLiningM1TrafficControlListGateway.Load(companyId);
            workFullLengthLiningM1TrafficControlListGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="trafficControl">trafficControl</param>
        public void Insert(string trafficControl)
        {
            // Verify structure
            if (Table == null)
            {
                CreateTableStructure();
            }

            // Insert row
            DataRow newRow = Table.NewRow();
            newRow["TrafficControl"] = trafficControl;
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
            System.Data.DataTable table = new DataTable("LFS_WORK_FULLLENGTHLINING_M1_TRAFFICCONTROL");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "TrafficControl";
            Table.Columns.Add(column);
        }


    }
}
