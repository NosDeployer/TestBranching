using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Units;

namespace LiquiForce.LFSLive.BL.FleetManagement.Units
{
    /// <summary>
    /// UnitVehicleTireSizeList
    /// </summary>
    public class UnitVehicleTireSizeList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public UnitVehicleTireSizeList()
            : base("LFS_FM_UNIT_VEHICLE_TIRESIZE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public UnitVehicleTireSizeList(DataSet data)
            : base(data, "LFS_FM_UNIT_VEHICLE_TIRESIZE")
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
        /// <param name="tireSize">tireSize</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAndAddItem(string tireSize, int companyId)
        {
            // Add item
            CreateTableStructure();
            Insert(tireSize);

            // Load Unit vvehicle tire size list
            UnitVehicleTireSizeListGateway unitVehicleTireSizeListGateway = new UnitVehicleTireSizeListGateway(Data);
            unitVehicleTireSizeListGateway.ClearBeforeFill = false;
            unitVehicleTireSizeListGateway.Load(companyId);
            unitVehicleTireSizeListGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="tireSize">tireSize</param>
        public void Insert(string tireSize)
        {
            // Verify structure
            if (Table == null)
            {
                CreateTableStructure();
            }

            // Insert row
            DataRow newRow = Table.NewRow();
            newRow["TireSize"] = tireSize;
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
            System.Data.DataTable table = new DataTable("LFS_FM_UNIT_VEHICLE_TIRESIZE");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "TireSize";
            Table.Columns.Add(column);
        }



    }
}



