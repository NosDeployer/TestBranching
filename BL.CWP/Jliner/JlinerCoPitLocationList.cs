using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Section;
using LiquiForce.LFSLive.DA.CWP.Jliner;
using LiquiForce.LFSLive.DA.RAF;

namespace LiquiForce.LFSLive.BL.CWP.Jliner
{
    /// <summary>
    /// JlinerComments
    /// </summary>
    public class JlinerCoPitLocationList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public JlinerCoPitLocationList()
            : base("LFS_JUNCTION_LINER2_CO_PIT_LOCATION")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public JlinerCoPitLocationList(DataSet data)
            : base(data, "LFS_JUNCTION_LINER2_CO_PIT_LOCATION")
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
            JlinerCoPitLocationListGateway jlinerCoPitLocationListGateway = new JlinerCoPitLocationListGateway(Data);
            jlinerCoPitLocationListGateway.ClearBeforeFill = false;
            jlinerCoPitLocationListGateway.Load(companyId);
            jlinerCoPitLocationListGateway.ClearBeforeFill = true;
            
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
            System.Data.DataTable table = new DataTable("LFS_JUNCTION_LINER2_CO_PIT_LOCATION");
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
