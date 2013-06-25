using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Section;
using LiquiForce.LFSLive.DA.CWP.Jliner;

namespace LiquiForce.LFSLive.BL.CWP.Section
{
    /// <summary>
    /// SectionSubArea
    /// </summary>
    public class SectionSubArea : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //
        /// <summary>
        /// Constructor
        /// </summary>
        public SectionSubArea()
            : base("LFS_MASTER_AREA")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public SectionSubArea(DataSet data)
            : base(data, "LFS_MASTER_AREA")
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
        /// <param name="companiesId">companiesId</param>
        /// <param name="subArea">subArea</param>
        /// <returns>Data</returns>
        public DataSet LoadAndAddItem(int companiesId, string subArea)
        {
            // Add item
            CreateTableStructure();
            Insert(subArea);

            // Load sub areas list
            SectionSubAreaGateway sectionSubAreaGateway = new SectionSubAreaGateway(Data);
            sectionSubAreaGateway.ClearBeforeFill = false;
            sectionSubAreaGateway.LoadByCompanyIdCompaniesId(3, companiesId); //Note: COMPANY_ID
            sectionSubAreaGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// Insert
        /// </summary>
       /// <param name="subArea">subArea</param>
        public void Insert(string subArea)
        {
            // Verify structure
            if (Table == null)
            {
                CreateTableStructure();
            }

            // Insert row All
            DataRow newRowAll = Table.NewRow();
            newRowAll["SubArea"] = subArea;
            Table.Rows.Add(newRowAll);

            // Insert row ""
            DataRow newRowNull = Table.NewRow();
            newRowNull["SubArea"] = "";
            Table.Rows.Add(newRowNull);
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
            System.Data.DataTable table = new DataTable("LFS_MASTER_AREA");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "SubArea";
            Table.Columns.Add(column);
        }



    }
}