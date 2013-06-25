using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Units;

namespace LiquiForce.LFSLive.BL.FleetManagement.Units
{
    /// <summary>
    /// UnitVehicleFuelTypeList
    /// </summary>
    public class UnitVehicleFuelTypeList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public UnitVehicleFuelTypeList()
            : base("LFS_FM_UNIT_VEHICLE_FUELTYPE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public UnitVehicleFuelTypeList(DataSet data)
            : base(data, "LFS_FM_UNIT_VEHICLE_FUELTYPE")
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
        /// <param name="fuelType">fuelType</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAndAddItem(string fuelType, int companyId)
        {
            // Add item
            CreateTableStructure();
            Insert(fuelType);

            // Load Unit vehicle fueltype list
            UnitVehicleFuelTypeListGateway unitVehicleFuelTypeListGateway = new UnitVehicleFuelTypeListGateway(Data);
            unitVehicleFuelTypeListGateway.ClearBeforeFill = false;
            unitVehicleFuelTypeListGateway.Load(companyId);
            unitVehicleFuelTypeListGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="fuelType">fuelType</param>
        public void Insert(string fuelType)
        {
            // Verify structure
            if (Table == null)
            {
                CreateTableStructure();
            }

            // Insert row
            DataRow newRow = Table.NewRow();
            newRow["FuelType"] = fuelType;
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
            System.Data.DataTable table = new DataTable("LFS_FM_UNIT_VEHICLE_FUELTYPE");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "FuelType";
            Table.Columns.Add(column);
        }



    }
}

