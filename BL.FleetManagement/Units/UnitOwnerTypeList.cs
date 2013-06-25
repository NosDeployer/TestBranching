using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Units;

namespace LiquiForce.LFSLive.BL.FleetManagement.Units
{
    /// <summary>
    /// UnitOwnerTypeList
    /// </summary>
    public class UnitOwnerTypeList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public UnitOwnerTypeList()
            : base("LFS_FM_UNIT_OWNERTYPE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public UnitOwnerTypeList(DataSet data)
            : base(data, "LFS_FM_UNIT_OWNERTYPE")
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
        /// <param name="ownerType">ownerType</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAndAddItem(string ownerType, int companyId)
        {
            // Add item
            CreateTableStructure();
            Insert(ownerType);

            // Load UNIT OWNER TYPE list
            UnitOwnerTypeListGateway unitOwnerTypeListGateway = new UnitOwnerTypeListGateway(Data);
            unitOwnerTypeListGateway.ClearBeforeFill = false;
            unitOwnerTypeListGateway.Load(companyId);
            unitOwnerTypeListGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="ownerType">ownerType</param>
        public void Insert(string ownerType)
        {
            // Verify structure
            if (Table == null)
            {
                CreateTableStructure();
            }

            // Insert row
            DataRow newRow = Table.NewRow();
            newRow["OwnerType"] = ownerType;
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
            System.Data.DataTable table = new DataTable("LFS_FM_UNIT_OWNERTYPE");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "OwnerType";
            Table.Columns.Add(column);
        }



    }
}


