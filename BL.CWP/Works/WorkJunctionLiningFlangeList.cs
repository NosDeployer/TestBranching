using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Works;

namespace LiquiForce.LFSLive.BL.CWP.Works
{
    /// <summary>
    /// WorkJunctionLiningFlangeList
    /// </summary>
    public class WorkJunctionLiningFlangeList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkJunctionLiningFlangeList()
            : base("LFS_WORK_JUNCTIONLINING_FLANGE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkJunctionLiningFlangeList(DataSet data)
            : base(data, "LFS_WORK_JUNCTIONLINING_FLANGE")
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
        /// <param name="flange">flange</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAndAddItem(string flange, int companyId)
        {
            // Add item
            CreateTableStructure();
            Insert(flange);

            // Load viewType list
            WorkJunctionLiningFlangeListGateway workJunctionLiningFlangeListGateway = new WorkJunctionLiningFlangeListGateway(Data);
            workJunctionLiningFlangeListGateway.ClearBeforeFill = false;
            workJunctionLiningFlangeListGateway.Load(companyId);
            workJunctionLiningFlangeListGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="flange">flange</param>
        public void Insert(string flange)
        {
            // Verify structure
            if (Table == null)
            {
                CreateTableStructure();
            }

            // Insert row
            DataRow newRow = Table.NewRow();
            newRow["Flange"] = flange;
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
            System.Data.DataTable table = new DataTable("LFS_WORK_JUNCTIONLINING_FLANGE");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Flange";
            Table.Columns.Add(column);
        }



    }
}