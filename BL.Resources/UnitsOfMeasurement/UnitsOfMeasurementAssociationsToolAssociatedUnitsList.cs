using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Resources.UnitsOfMeasurement;

namespace LiquiForce.LFSLive.BL.Resources.UnitsOfMeasurement
{
    /// <summary>
    /// UnitsOfMeasurementAssociationsToolAssociatedUnitsList
    /// </summary
    public class UnitsOfMeasurementAssociationsToolAssociatedUnitsList: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public UnitsOfMeasurementAssociationsToolAssociatedUnitsList()
            : base("LFS_RESOURCES_UNITS_OF_MEASUREMENT_ASSOCIATIONS")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public UnitsOfMeasurementAssociationsToolAssociatedUnitsList(DataSet data)
            : base(data, "LFS_RESOURCES_UNITS_OF_MEASUREMENT_ASSOCIATIONS")
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
        /// <param name="module">module</param>
        /// <param name="companyId">companyId</param>
        /// <returns></returns>
        public DataSet LoadAndAddItem(int companyId)
        {
            // Add item
            CreateTableStructure();

            // Load work list
            UnitsOfMeasurementAssociationsToolAssociatedUnitsListGateway unitsOfMeasurementAssociationsToolAssociatedUnitsListGateway = new UnitsOfMeasurementAssociationsToolAssociatedUnitsListGateway(Data);
            unitsOfMeasurementAssociationsToolAssociatedUnitsListGateway.ClearBeforeFill = false;
            unitsOfMeasurementAssociationsToolAssociatedUnitsListGateway.Load(companyId);
            unitsOfMeasurementAssociationsToolAssociatedUnitsListGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// LoadAndAddItemByModule
        /// </summary>
        /// <param name="module">module</param>
        /// <param name="companyId">companyId</param>
        /// <returns></returns>
        public DataSet LoadAndAddItemByModule(string module, int companyId)
        {
            // Add item
            CreateTableStructure();
            //Insert(unitOfMeasurementDescription);

            // Load work list
            UnitsOfMeasurementAssociationsToolAssociatedUnitsListGateway unitsOfMeasurementAssociationsToolAssociatedUnitsListGateway = new UnitsOfMeasurementAssociationsToolAssociatedUnitsListGateway(Data);
            unitsOfMeasurementAssociationsToolAssociatedUnitsListGateway.ClearBeforeFill = false;
            unitsOfMeasurementAssociationsToolAssociatedUnitsListGateway.LoadByModule(module, companyId);
            unitsOfMeasurementAssociationsToolAssociatedUnitsListGateway.ClearBeforeFill = true;

            return Data;
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
            System.Data.DataTable table = new DataTable("LFS_RESOURCES_UNITS_OF_MEASUREMENT_ASSOCIATIONS");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Description";
            Table.Columns.Add(column);
        }


        
    }
}
