using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Assets;

namespace LiquiForce.LFSLive.BL.CWP.Assets
{
    /// <summary>
    /// LfsAssetSewerSectionThicknessList
    /// </summary>
    public class LfsAssetSewerSectionThicknessList: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public LfsAssetSewerSectionThicknessList()
            : base("LFS_ASSET_SEWER_SECTION_THICKNESS")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public LfsAssetSewerSectionThicknessList(DataSet data)
            : base(data, "LFS_ASSET_SEWER_SECTION_THICKNESS")
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
        /// <param name="thickness">thickness</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>
        public DataSet LoadAndAddItem(string thickness, int companyId)
        {
            // Add item
            CreateTableStructure();
            Insert(thickness);

            // Load countries list
            LfsAssetSewerSectionThicknessListGateway lfsAssetSewerSectionThicknessListGateway = new LfsAssetSewerSectionThicknessListGateway(Data);
            lfsAssetSewerSectionThicknessListGateway.ClearBeforeFill = false;
            lfsAssetSewerSectionThicknessListGateway.Load(companyId);
            lfsAssetSewerSectionThicknessListGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="thickness">thickness</param>        
        public void Insert(string thickness)
        {
            // Verify structure
            if (Table == null)
            {
                CreateTableStructure();
            }

            // Insert row
            DataRow newRow = Table.NewRow();
            newRow["Thickness"] = thickness;
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
            System.Data.DataTable table = new DataTable("LFS_ASSET_SEWER_SECTION_THICKNESS");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Thickness";
            Table.Columns.Add(column);
        }
    }


}
