using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Resources.UnitsOfMeasurement;


namespace LiquiForce.LFSLive.BL.Resources.UnitsOfMeasurement
{
    /// <summary>
    /// UnitsOfMeasurementModulesToAssociateList
    /// </summary
    public class UnitsOfMeasurementModulesToAssociateList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public UnitsOfMeasurementModulesToAssociateList()
            : base("LFS_RESOURCES_UNITS_OF_MEASUREMENT_MODULES_TO_ASSOCIATE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public UnitsOfMeasurementModulesToAssociateList(DataSet data)
            : base(data, "LFS_RESOURCES_UNITS_OF_MEASUREMENT_MODULES_TO_ASSOCIATE")
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
        public DataSet LoadAndAddItem(string module, int companyId)
        {
            // Add item
            CreateTableStructure();
            Insert(module);

            // Load work list
            UnitsOfMeasurementModulesToAssociateListGateway unitsOfMeasurementModulesToAssociateListGateway = new UnitsOfMeasurementModulesToAssociateListGateway(Data);
            unitsOfMeasurementModulesToAssociateListGateway.ClearBeforeFill = false;
            unitsOfMeasurementModulesToAssociateListGateway.Load(companyId);
            unitsOfMeasurementModulesToAssociateListGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="module">module</param>
        public void Insert(string module)
        {
            // Verify structure
            if (Table == null)
            {
                CreateTableStructure();
            }

            // Insert row
            DataRow newRow = Table.NewRow();
            newRow["Module"] = module;
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
            System.Data.DataTable table = new DataTable("LFS_RESOURCES_UNITS_OF_MEASUREMENT_MODULES_TO_ASSOCIATE");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Module";
            Table.Columns.Add(column);
        }


        
    }
}
