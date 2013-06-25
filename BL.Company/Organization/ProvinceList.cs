using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Company.Organization;

namespace LiquiForce.LFSLive.BL.Company.Organization
{
    /// <summary>
    /// ProvinceList
    /// </summary>
    public class ProvinceList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProvinceList()
            : base("LFS_PROVINCE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProvinceList(DataSet data)
            : base(data, "LFS_PROVINCE")
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
        /// LoadByCountryIdAndAddItem
        /// </summary>
        /// <param name="provinceId">provinceId</param>
        /// <param name="name">name</param>
        /// <param name="countryId">countryId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadByCountryIdAndAddItem(Int64 provinceId, string name, Int64 countryId)
        {
            // Add item
            CreateTableStructure();
            Insert(provinceId, name);

            // Load offices list
            ProvinceListGateway provinceListGateway = new ProvinceListGateway(Data);
            provinceListGateway.ClearBeforeFill = false;
            provinceListGateway.LoadByCountryId(countryId);
            provinceListGateway.ClearBeforeFill = true;
            
            return Data;
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="provinceId">provinceId</param>
        /// <param name="name">name</param>
        public void Insert(Int64 provinceId, string name)
        {
            // Verify structure
            if (Table == null)
            {
                CreateTableStructure();
            }

            // Insert row
            DataRow newRow = Table.NewRow();
            newRow["ProvinceID"] = provinceId;
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
            System.Data.DataTable table = new DataTable("LFS_PROVINCE");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int64");
            column.ColumnName = "ProvinceID";
            Table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Name";
            Table.Columns.Add(column);
        }



    }
}
