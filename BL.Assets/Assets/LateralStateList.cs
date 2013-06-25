using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Assets.Assets;

namespace LiquiForce.LFSLive.BL.Assets.Assets
{
    /// <summary>
    /// LateralStateList
    /// </summary
    public class LateralStateList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public LateralStateList()
            : base("AM_ASSET_SEWER_LATERAL_STATE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public LateralStateList(DataSet data)
            : base(data, "AM_ASSET_SEWER_LATERAL_STATE")
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
        /// <param name="state">state</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAndAddItem(string state, int companyId)
        {
            // Add item
            CreateTableStructure();
            Insert(state);

            // Load state
            LateralStateListGateway lateralStateListGateway = new LateralStateListGateway(Data);
            lateralStateListGateway.ClearBeforeFill = false;
            lateralStateListGateway.Load(companyId);
            lateralStateListGateway.ClearBeforeFill = true;
            
            return Data;
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="state">state</param>
        public void Insert(string state)
        {
            // Verify structure
            if (Table == null)
            {
                CreateTableStructure();
            }

            // Insert row
            DataRow newRow = Table.NewRow();

            newRow["State"] = state;
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
            System.Data.DataTable table = new DataTable("AM_ASSET_SEWER_LATERAL_STATE");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "State";
            Table.Columns.Add(column);
        }


    }
}