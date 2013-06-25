using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Company.Organization;
namespace LiquiForce.LFSLive.BL.Company.Organization
{
    /// <summary>
    /// CountyList
    /// </summary>
    public class CountyList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public CountyList()
            : base("LFS_COUNTY")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public CountyList(DataSet data)
            : base(data, "LFS_COUNTY")
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
        /// <param name="countyId">countyId</param>
        /// <param name="name">name</param>
        /// <param name="provinceId">provinceId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadByProvinceIdAndAddItem(Int64 countyId, string name, int provinceId)
        {
            // Add item
            CreateTableStructure();
            Insert(countyId, name);

            // Load offices list
            CountyListGateway countyListGateway = new CountyListGateway(Data);
            countyListGateway.ClearBeforeFill = false;
            countyListGateway.LoadByProvinceId(provinceId);
            countyListGateway.ClearBeforeFill = true;
            
            return Data;
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="countyId">countyId</param>
        /// <param name="name">name</param>
        public void Insert(Int64 countyId, string name)
        {
            // Verify structure
            if (Table == null)
            {
                CreateTableStructure();
            }

            // Insert row
            DataRow newRow = Table.NewRow();
            newRow["CountyID"] = countyId;
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
            System.Data.DataTable table = new DataTable("LFS_COUNTY");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int64");
            column.ColumnName = "CountyID";
            Table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Name";
            Table.Columns.Add(column);
        }



    }
}
