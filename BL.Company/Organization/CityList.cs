using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Company.Organization;

namespace LiquiForce.LFSLive.BL.Company.Organization
{
    /// <summary>
    /// CityList
    /// </summary>
    public class CityList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public CityList() : base("LFS_CITY")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public CityList(DataSet data)
            : base(data, "LFS_CITY")
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
        /// LoadByProvinceIdAndAddItem
        /// </summary>
        /// <param name="cityId">cityId</param>
        /// <param name="name">name</param>
        /// <param name="countyId">countyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadByCountyIdAndAddItem(Int64 cityId, string name, int countyId)
        {
            // Add item
            CreateTableStructure();
            Insert(cityId, name);

            // Load offices list
            CityListGateway cityListGateway = new CityListGateway(Data);
            cityListGateway.ClearBeforeFill = false;
            cityListGateway.LoadByCountyId(countyId);
            cityListGateway.ClearBeforeFill = true;
            
            return Data;
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="cityId">cityId</param>
        /// <param name="name">name</param>
        public void Insert(Int64 cityId, string name)
        {
            // Verify structure
            if (Table == null)
            {
                CreateTableStructure();
            }

            // Insert row
            DataRow newRow = Table.NewRow();
            newRow["CityID"] = cityId;
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
            System.Data.DataTable table = new DataTable("LFS_CITY");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int64");
            column.ColumnName = "CityID";
            Table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Name";
            Table.Columns.Add(column);
        }



    }
}
