using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Works;

namespace LiquiForce.LFSLive.BL.CWP.Works
{
    /// <summary>
    /// WorkJunctionLiningSectionTrafficControlList
    /// </summary>
    public class WorkJunctionLiningSectionTrafficControlList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkJunctionLiningSectionTrafficControlList()
            : base("LFS_WORK_JUNCTIONLINING_SECTION_TRAFFICCONTROL")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkJunctionLiningSectionTrafficControlList(DataSet data)
            : base(data, "LFS_WORK_JUNCTIONLINING_SECTION_TRAFFICCONTROL")
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
            // Recien se va utilizar en la nueva ventana de edicion de secciones
            // Add item
            CreateTableStructure();
            Insert(trafficControl);

            // Load viewType list
            WorkJunctionLiningSectionTrafficControlListGateway workJunctionLiningSectionTrafficControlListGateway = new WorkJunctionLiningSectionTrafficControlListGateway(Data);
            workJunctionLiningSectionTrafficControlListGateway.ClearBeforeFill = false;
            workJunctionLiningSectionTrafficControlListGateway.Load(companyId);
            workJunctionLiningSectionTrafficControlListGateway.ClearBeforeFill = true;

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
            System.Data.DataTable table = new DataTable("LFS_WORK_JUNCTIONLINING_SECTION_TRAFFICCONTROL");
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

