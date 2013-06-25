using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Assets.Assets;

namespace LiquiForce.LFSLive.BL.Assets.Assets
{
    /// <summary>
    /// AssetSewerMHMaterialTypeList
    /// </summary
    public class AssetSewerMHMaterialTypeList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public AssetSewerMHMaterialTypeList()
            : base("AM_ASSET_SEWER_MH_MATERIAL_TYPE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public AssetSewerMHMaterialTypeList(DataSet data)
            : base(data, "AM_ASSET_SEWER_MH_MATERIAL_TYPE")
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
        /// <param name="materialId">materialId</param>
        /// <param name="materialType">materialType</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAndAddItem(int materialId, string materialType, int companyId)
        {
            // Add item
            CreateTableStructure();
            Insert(materialId, materialType);

            // Load viewType list
            AssetSewerMHMaterialTypeListGateway assetSewerMHMaterialListGateway = new AssetSewerMHMaterialTypeListGateway(Data);
            assetSewerMHMaterialListGateway.ClearBeforeFill = false;
            assetSewerMHMaterialListGateway.Load(companyId);
            assetSewerMHMaterialListGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="materialId">materialId</param>
        /// <param name="materialType">materialType</param>
        public void Insert(int materialId, string materialType)
        {
            // Verify structure
            if (Table == null)
            {
                CreateTableStructure();
            }

            // Insert row
            DataRow newRow = Table.NewRow();

            newRow["MaterialID"] = materialId;
            newRow["MaterialType"] = materialType;
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
            System.Data.DataTable table = new DataTable("AM_ASSET_SEWER_MH_MATERIAL_TYPE");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "MaterialID";
            Table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "MaterialType";
            Table.Columns.Add(column);
        }


    }
}