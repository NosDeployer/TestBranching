using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Units;

namespace LiquiForce.LFSLive.BL.FleetManagement.Units
{
    /// <summary>
    /// UnitVehicleNumberOfAxesList
    /// </summary>
    public class UnitVehicleNumberOfAxesList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public UnitVehicleNumberOfAxesList()
            : base("LFS_FM_UNIT_VEHICLE_NUMBEROFAXES")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public UnitVehicleNumberOfAxesList(DataSet data)
            : base(data, "LFS_FM_UNIT_VEHICLE_NUMBEROFAXES")
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
        /// <param name="numberOfAxes">numberOfAxes</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAndAddItem(string numberOfAxes, int companyId)
        {
            // Add item
            CreateTableStructure();
            Insert(numberOfAxes);

            // Load Unit vehicle Number of axes list
            UnitVehicleNumberOfAxesListGateway unitVehicleNumberOfAxesListGateway = new UnitVehicleNumberOfAxesListGateway(Data);
            unitVehicleNumberOfAxesListGateway.ClearBeforeFill = false;
            unitVehicleNumberOfAxesListGateway.Load(companyId);
            unitVehicleNumberOfAxesListGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="numberOfAxes">numberOfAxes</param>
        public void Insert(string numberOfAxes)
        {
            // Verify structure
            if (Table == null)
            {
                CreateTableStructure();
            }

            // Insert row
            DataRow newRow = Table.NewRow();
            newRow["NumberOfAxes"] = numberOfAxes;
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
            System.Data.DataTable table = new DataTable("LFS_FM_UNIT_VEHICLE_NUMBEROFAXES");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "NumberOfAxes";
            Table.Columns.Add(column);
        }



    }
}


