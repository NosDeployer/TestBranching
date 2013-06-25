using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Assets.Assets;

namespace LiquiForce.LFSLive.BL.Assets.Assets
{
    /// <summary>
    /// AssetSewerMHShapeList
    /// </summary
    public class AssetSewerMHShapeList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public AssetSewerMHShapeList()
            : base("AM_ASSET_SEWER_MH_SHAPE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public AssetSewerMHShapeList(DataSet data)
            : base(data, "AM_ASSET_SEWER_MH_SHAPE")
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
        /// <param name="shape">shape</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAndAddItem(string shape, int companyId)
        {
            // Add item
            CreateTableStructure();
            Insert(shape);

            // Load viewType list
            AssetSewerMHShapeListGateway assetSewerMHShapeListGateway = new AssetSewerMHShapeListGateway(Data);
            assetSewerMHShapeListGateway.ClearBeforeFill = false;
            assetSewerMHShapeListGateway.Load(companyId);
            assetSewerMHShapeListGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="shape">shape</param>
        public void Insert(string shape)
        {
            // Verify structure
            if (Table == null)
            {
                CreateTableStructure();
            }

            // Insert row
            DataRow newRow = Table.NewRow();

            newRow["ManholeShape"] = shape;
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
            System.Data.DataTable table = new DataTable("AM_ASSET_SEWER_MH_SHAPE");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "ManholeShape";
            Table.Columns.Add(column);
        }


    }
}