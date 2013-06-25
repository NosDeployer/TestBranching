using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Works;

namespace LiquiForce.LFSLive.BL.CWP.Works
{
    /// <summary>
    /// WorkJunctionLiningFlangeGasketList
    /// </summary>
    public class WorkJunctionLiningFlangeGasketList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkJunctionLiningFlangeGasketList()
            : base("LFS_WORK_JUNCTIONLINING_FLANGE_GASKET")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkJunctionLiningFlangeGasketList(DataSet data)
            : base(data, "LFS_WORK_JUNCTIONLINING_FLANGE_GASKET")
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
        /// <param name="gasket">gasket</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAndAddItem(string flange, string gasket, int companyId)
        {
            // Add item
            CreateTableStructure();
            Insert(flange, gasket);

            // Load list
            WorkJunctionLiningFlangeGasketListGateway workJunctionLiningFlangeGasketListGateway = new WorkJunctionLiningFlangeGasketListGateway(Data);
            workJunctionLiningFlangeGasketListGateway.ClearBeforeFill = false;
            workJunctionLiningFlangeGasketListGateway.LoadByFlange(flange, companyId);
            workJunctionLiningFlangeGasketListGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// LoadAllAndAddItem
        /// </summary>
        /// <param name="flange">flange</param>
        /// <param name="gasket">gasket</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAllAndAddItem(string flange, string gasket, int companyId)
        {
            // Add item
            CreateTableStructure();
            Insert(flange, gasket);

            // Load list
            WorkJunctionLiningFlangeGasketListGateway workJunctionLiningFlangeGasketListGateway = new WorkJunctionLiningFlangeGasketListGateway(Data);
            workJunctionLiningFlangeGasketListGateway.ClearBeforeFill = false;
            workJunctionLiningFlangeGasketListGateway.LoadAll(companyId);
            workJunctionLiningFlangeGasketListGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="flange">flange</param>
        /// <param name="gasket">gasket</param>
        public void Insert(string flange, string gasket)
        {
            // Verify structure
            if (Table == null)
            {
                CreateTableStructure();
            }

            // Insert row
            DataRow newRow = Table.NewRow();
            newRow["Flange"] = flange;
            newRow["Gasket"] = gasket;

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
            System.Data.DataTable table = new DataTable("LFS_WORK_JUNCTIONLINING_FLANGE_GASKET");
            Data.Tables.Add(table);

            // Add columns
            DataColumn columnFlange = new DataColumn();
            columnFlange.DataType = Type.GetType("System.String");
            columnFlange.ColumnName = "Flange";

            DataColumn columnGasket = new DataColumn();
            columnGasket.DataType = Type.GetType("System.String");
            columnGasket.ColumnName = "Gasket";
            
            Table.Columns.Add(columnFlange);
            table.Columns.Add(columnGasket);
        }



    }
}