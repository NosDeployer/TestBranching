using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Assets.Assets;

namespace LiquiForce.LFSLive.BL.Assets.Assets
{
    /// <summary>
    /// AssetSewerMHRugsList
    /// </summary
    public class AssetSewerMHRugsList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public AssetSewerMHRugsList()
            : base("AM_ASSET_SEWER_MH_RUGS")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public AssetSewerMHRugsList(DataSet data)
            : base(data, "AM_ASSET_SEWER_MH_RUGS")
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
        /// <param name="manholeRugsId">manholeRugsId</param>
        /// <param name="manholeRugs">manholeRugs</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAndAddItem(int manholeRugsId, string manholeRugs, int companyId)
        {
            // Add item
            CreateTableStructure();
            Insert(manholeRugsId, manholeRugs);

            // Load viewType list
            AssetSewerMHRugsListGateway assetSewerMHLocationListGateway = new AssetSewerMHRugsListGateway(Data);
            assetSewerMHLocationListGateway.ClearBeforeFill = false;
            assetSewerMHLocationListGateway.Load(companyId);
            assetSewerMHLocationListGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="manholeRugsId">manholeRugsId</param>
        /// <param name="manholeRugs">manholeRugs</param>
        public void Insert(int manholeRugsId, string manholeRugs)
        {
            // Verify structure
            if (Table == null)
            {
                CreateTableStructure();
            }

            // Insert row
            DataRow newRow = Table.NewRow();

            newRow["ManholeRugsId"] = manholeRugsId;
            newRow["ManholeRugs"] = manholeRugs;
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
            System.Data.DataTable table = new DataTable("AM_ASSET_SEWER_MH_RUGS");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;

            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "ManholeRugsId";
            Table.Columns.Add(column);
                       
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "ManholeRugs";
            Table.Columns.Add(column);
        }


    }
}