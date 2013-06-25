using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Company.Organization;

namespace LiquiForce.LFSLive.BL.Company.Organization
{
    /// <summary>
    /// CountryList
    /// </summary>
    public class CountryList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public CountryList()
            : base("LFS_COUNTRY")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public CountryList(DataSet data)
            : base(data, "LFS_COUNTRY")
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
        /// <param name="countryId">countryId</param>
        /// <param name="name">name</param>
        /// <returns>Data</returns>
        public DataSet LoadAndAddItem(Int64 countryId, string name)
        {
            // Add item
            CreateTableStructure();
            Insert(countryId, name);

            // Load countries list
            CountryListGateway countryListGateway = new CountryListGateway(Data);
            countryListGateway.ClearBeforeFill = false;
            countryListGateway.Load();
            countryListGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="countryId">countryId</param>
        /// <param name="name">name</param>
        public void Insert(Int64 countryId, string name)
        {
            // Verify structure
            if (Table == null)
            {
                CreateTableStructure();
            }

            // Insert row
            DataRow newRow = Table.NewRow();
            newRow["CountryID"] = countryId;
            newRow["Name"] = name;
            Table.Rows.Add(newRow);
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// CreateTableStructure
        /// </summary>
        public void CreateTableStructure()
        {
            // Create table
            System.Data.DataTable table = new DataTable("LFS_COUNTRY");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int64");
            column.ColumnName = "CountryID";
            Table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Name";
            Table.Columns.Add(column);
        }



    }
}
