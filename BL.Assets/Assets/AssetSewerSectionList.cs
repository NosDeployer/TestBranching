using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Assets.Assets;

namespace LiquiForce.LFSLive.BL.Assets.Assets
{
    /// <summary>
    /// AssetSewerSectionList
    /// </summary>
    public class AssetSewerSectionList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public AssetSewerSectionList()
            : base("AM_ASSET_SEWER_SECTION")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public AssetSewerSectionList(DataSet data)
            : base(data, "AM_ASSET_SEWER_SECTION")
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
        /// <param name="projectId">projectId</param>
        /// <param name="workType">workType</param>
        /// <param name="sectionId">sectionId</param>
        /// <param name="flowOrderId">flowOrderId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>
        public DataSet LoadAndAddItem(int projectId, string workType, string sectionId, string flowOrderId, int companyId)
        {
            // Add item
            CreateTableStructure();
            Insert(sectionId, flowOrderId);

            // Load sections list
            AssetSewerSectionListGateway sssetSewerSectionListGateway = new AssetSewerSectionListGateway(Data);
            sssetSewerSectionListGateway.ClearBeforeFill = false;
            sssetSewerSectionListGateway.LoadByProjectIdWorkType(projectId, workType, companyId);
            sssetSewerSectionListGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="sectionId">sectionId</param>
        /// <param name="flowOrderId">flowOrderId</param>
        public void Insert(string sectionId, string flowOrderId)
        {
            // Verify structure
            if (Table == null)
            {
                CreateTableStructure();
            }

            // Insert row
            DataRow newRow = Table.NewRow();
            newRow["SectionID"] = sectionId;
            newRow["FlowOrderID"] = flowOrderId;
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
            System.Data.DataTable table = new DataTable("AM_ASSET_SEWER_SECTION");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "SectionID";
            Table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "FlowOrderID";
            Table.Columns.Add(column);
        }



    }
}