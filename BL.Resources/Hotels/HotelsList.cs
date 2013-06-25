using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Resources.Hotels;

namespace LiquiForce.LFSLive.BL.Resources.Hotels
{
    /// <summary>
    /// HotelsList
    /// </summary>
    public class HotelsList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public HotelsList()
            : base("LFS_RESOURCES_HOTELS")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public HotelsList(DataSet data)
            : base(data, "LFS_RESOURCES_HOTELS")
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
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAndAddItem( int companyId)
        {
            // Add item
            CreateTableStructure();            

            // Load costing sheet list
            HotelsListGateway hotelsListGateway = new HotelsListGateway(Data);
            hotelsListGateway.ClearBeforeFill = false;
            hotelsListGateway.Load(companyId);
            hotelsListGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// LoadAndAddItem
        /// </summary>
        /// <param name="hotelId">hotelId</param>
        /// <param name="name">name</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAndAddItem(int hotelId, string name, int companyId)
        {
            // Add item
            CreateTableStructure();
            Insert(hotelId, name);

            // Load costing sheet list
            HotelsListGateway hotelsListGateway = new HotelsListGateway(Data);
            hotelsListGateway.ClearBeforeFill = false;
            hotelsListGateway.Load(companyId);
            hotelsListGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="hotelId">hotelId</param>
        /// <param name="name">name</param>
        public void Insert(int hotelId, string name)
        {
            // Verify structure
            if (Table == null)
            {
                CreateTableStructure();
            }

            // Insert row
            DataRow newRow = Table.NewRow();
            newRow["COMPANIES_ID"] = hotelId;
            newRow["Name"] = name;
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
            System.Data.DataTable table = new DataTable("LFS_RESOURCES_HOTELS");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "COMPANIES_ID";
            Table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Name";
            Table.Columns.Add(column);
        }



    }
}