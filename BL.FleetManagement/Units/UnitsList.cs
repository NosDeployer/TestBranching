using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Units;

namespace LiquiForce.LFSLive.BL.FleetManagement.Units
{
    /// <summary>
    /// UnitsList
    /// </summary
    public class UnitsList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public UnitsList()
            : base("LFS_FM_UNIT")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public UnitsList(DataSet data)
            : base(data, "LFS_FM_UNIT")
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
        /// <param name="unitId">unitId</param>
        /// <param name="description">description</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Dataset</returns>
        public DataSet LoadAndAddItem(string unitId, string description, int companyId)
        {
            // Add item
            CreateTableStructure();
            Insert(unitId, description);

            // Load unit list
            UnitsListGateway unitsListGateway = new UnitsListGateway(Data);
            unitsListGateway.ClearBeforeFill = false;
            unitsListGateway.Load(companyId);
            unitsListGateway.ClearBeforeFill = true; 
            
            return Data;
        }



        /// <summary>
        /// LoadAndAddItem
        /// </summary>        
        /// <param name="companyId">companyId</param>
        /// <returns>Dataset</returns>
        public DataSet LoadAndAddItem( int companyId)
        {
            // Load unit list
            UnitsListGateway unitsListGateway = new UnitsListGateway(Data);
            unitsListGateway.ClearBeforeFill = false;
            unitsListGateway.Load(companyId);
            unitsListGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// LoadAndAddItem
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="description">description</param>
        /// <param name="companyId">companyId</param>
        /// <param name="isWithUnitCode">isWithUnitCode</param>
        /// <returns>Dataset</returns>
        public DataSet LoadAndAddItem(string unitId, string unitCode, int companyId, bool isWithUnitCode)
        {
            // Add item
            CreateTableStructureWitUnitCode();
            InsertWithUnitCode(unitId, unitCode);

            // Load unit list
            UnitsListGateway unitsListGateway = new UnitsListGateway(Data);
            unitsListGateway.ClearBeforeFill = false;
            unitsListGateway.LoadWithUnitCode(companyId);
            unitsListGateway.ClearBeforeFill = true;           

            return Data;
        }



        /// <summary>
        /// LoadAndAddItem
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="unitCode">unitCode</param>
        /// <param name="companyId">companyId</param>
        /// <param name="isWithUnitCode">isWithUnitCode</param>
        /// <param name="isTowable">isTowable</param>
        /// <returns>Dataset</returns>
        public DataSet LoadAndAddItem(string unitId, string unitCode, int companyId, bool isWithUnitCode, int isTowable)
        {
            // Add item
            CreateTableStructureWitUnitCode();
            InsertWithUnitCode(unitId, unitCode);

            // Load unit list
            UnitsListGateway unitsListGateway = new UnitsListGateway(Data);
            unitsListGateway.ClearBeforeFill = false;
            unitsListGateway.LoadByIsTowableWithUnitCode(isTowable, companyId);
            unitsListGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// LoadAndAddItem
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="unitCode">unitCode</param>
        /// <param name="companyId">companyId</param>
        /// <param name="isWithUnitCode">isWithUnitCode</param>
        /// <param name="isTowable">isTowable</param>
        /// <param name="type">type</param>
        /// <returns>Dataset</returns>
        public DataSet LoadAndAddItem(string unitId, string unitCode, int companyId, bool isWithUnitCode, int isTowable, string type)
        {
            // Add item
            CreateTableStructureWitUnitCode();
            InsertWithUnitCode(unitId, unitCode);

            // Load unit list
            UnitsListGateway unitsListGateway = new UnitsListGateway(Data);
            unitsListGateway.ClearBeforeFill = false;
            unitsListGateway.LoadByIsTowableTypeWithUnitCode(isTowable, type, companyId);
            unitsListGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// LoadAndAddItem
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="unitCode">unitCode</param>
        /// <param name="companyId">companyId</param>
        /// <param name="isWithUnitCode">isWithUnitCode</param>
        /// <param name="category">category</param>
        /// <returns>Dataset</returns>
        public DataSet LoadAndAddItem(string unitId, string unitCode, int companyId, bool isWithUnitCode, string category)
        {
            // Add item
            CreateTableStructureWitUnitCode();
            InsertWithUnitCode(unitId, unitCode);

            // Load unit list
            UnitsListGateway unitsListGateway = new UnitsListGateway(Data);
            unitsListGateway.ClearBeforeFill = false;
            unitsListGateway.LoadByCategoryWithUnitCode(category, companyId);
            unitsListGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// LoadAndAddItemByCategoryCompanyLevelId
        /// </summary>
        /// <param name="category">category</param>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Dataset</returns>
        public DataSet LoadAndAddItemByCategoryCompanyLevelId(string category, int companyLevelId, int companyId)
        {           
            // Load unit list
            UnitsListGateway unitsListGateway = new UnitsListGateway(Data);
            unitsListGateway.ClearBeforeFill = false;
            unitsListGateway.LoadByCategoryCompanyLevelIdWithUnitCodeDescription(category, companyLevelId, companyId);
            unitsListGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="description">description</param>
        public void Insert(string unitId, string description)
        {
            // Verify structure
            if (Table == null)
            {
                CreateTableStructure();
            }

            // Insert row
            DataRow newRow = Table.NewRow();
            newRow["UnitID"] = unitId;
            newRow["Description"] = description;
            Table.Rows.Add(newRow);
        }



        /// <summary>
        /// InsertWithUnitCode
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="unitCode">unitCode</param>
        public void InsertWithUnitCode(string unitId, string unitCode)
        {
            // Verify structure
            if (Table == null)
            {
                CreateTableStructure();
            }

            // Insert row
            DataRow newRow = Table.NewRow();
            newRow["UnitID"] = unitId;
            newRow["UnitCode"] = unitCode;
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
            System.Data.DataTable table = new DataTable("LFS_FM_UNIT");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "UnitID";
            Table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Description";
            Table.Columns.Add(column);
        }



        /// <summary>
        /// CreateTableStructureWitUnitCode
        /// </summary>
        private void CreateTableStructureWitUnitCode()
        {
            // Create table
            System.Data.DataTable table = new DataTable("LFS_FM_UNIT");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "UnitID";
            Table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "UnitCode";
            Table.Columns.Add(column);
        }



    }
}
