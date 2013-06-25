using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Units;

namespace LiquiForce.LFSLive.BL.FleetManagement.Units
{
    /// <summary>
    /// UnitVehicleWeightList
    /// </summary>
    public class UnitVehicleWeightList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public UnitVehicleWeightList()
            : base("LFS_FM_UNIT_VEHICLE_WEIGHT")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public UnitVehicleWeightList(DataSet data)
            : base(data, "LFS_FM_UNIT_VEHICLE_WEIGHT")
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
        /// <param name="weight">weight</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAndAddItem(string weight, int companyId)
        {
            // Add item
            CreateTableStructure();
            Insert(weight);

            // Load Unit vehicle weight list
            UnitVehicleWeightListGateway unitVehicleWeightListGateway = new UnitVehicleWeightListGateway(Data);
            unitVehicleWeightListGateway.ClearBeforeFill = false;
            unitVehicleWeightListGateway.Load(companyId);
            unitVehicleWeightListGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="weight">weight</param>
        public void Insert(string weight)
        {
            // Verify structure
            if (Table == null)
            {
                CreateTableStructure();
            }

            // Insert row
            DataRow newRow = Table.NewRow();
            newRow["Weight"] = weight;
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
            System.Data.DataTable table = new DataTable("LFS_FM_UNIT_VEHICLE_WEIGHT");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Weight";
            Table.Columns.Add(column);
        }



    }
}



