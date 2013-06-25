using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Works;

namespace LiquiForce.LFSLive.BL.CWP.Works
{
    /// <summary>
    /// WorkJunctionLiningCoPitLocationList
    /// </summary>
    public class WorkJunctionLiningCoPitLocationList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkJunctionLiningCoPitLocationList()
            : base("LFS_WORK_JUNCTIONLINING_CO_PIT_LOCATION")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkJunctionLiningCoPitLocationList(DataSet data)
            : base(data, "LFS_WORK_JUNCTIONLINING_CO_PIT_LOCATION")
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
        /// <param name="name">name</param>
        /// <param name="abbreviation">abbreviation</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>
        public DataSet LoadAndAddItem(string name, string abbreviation, int companyId)
        {
            // Add item
            CreateTableStructure();
            Insert(name, abbreviation);

            // Load Co Pit Location list
            WorkJunctionLiningCoPitLocationListGateway workJunctionLiningCoPitLocationListGateway = new WorkJunctionLiningCoPitLocationListGateway(Data);
            workJunctionLiningCoPitLocationListGateway.ClearBeforeFill = false;
            workJunctionLiningCoPitLocationListGateway.Load(companyId);
            workJunctionLiningCoPitLocationListGateway.ClearBeforeFill = true;
            
            return Data;
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="name">name</param>
        /// <param name="abbreviation">abbreviation</param>
        public void Insert(string name, string abbreviation)
        {
            // Verify structure
            if (Table == null)
            {
                CreateTableStructure();
            }

            // Insert row
            DataRow newRow = Table.NewRow();
            newRow["Name"] = name;
            newRow["Abbreviation"] = abbreviation;
            Table.Rows.Add(newRow);
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// CreateTableStructure
        /// </summary>
        public void CreateTableStructure()
        {
            // Create table
            System.Data.DataTable table = new DataTable("LFS_WORK_JUNCTIONLINING_CO_PIT_LOCATION");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Name";
            Table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Abbreviation";
            Table.Columns.Add(column);
        }



    }
}

