using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Company.Organization;

namespace LiquiForce.LFSLive.BL.Company.Organization
{
    /// <summary>
    /// OfficeList
    /// </summary>
    public class OfficeList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public OfficeList() : base("LFS_OFFICE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public OfficeList(DataSet data) : base(data, "LFS_OFFICE")
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
        /// <param name="officeId">officeId</param>
        /// <param name="name">name</param>
        /// <param name="countryId">countryId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadByCountryIdAndAddItem(int officeId, string name, int countryId)
        {
            // Add item
            CreateTableStructure();
            Insert(officeId, name);

            // Load offices list
            OfficeListGateway officeListGateway = new OfficeListGateway(Data);
            officeListGateway.ClearBeforeFill = false;
            officeListGateway.LoadByCountryId(countryId);
            officeListGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="officeId">officeId</param>
        /// <param name="name">name</param>
        public void Insert(int officeId, string name)
        {
            // Verify structure
            if (Table == null)
            {
                CreateTableStructure();
            }

            // Insert row
            DataRow newRow = Table.NewRow();
            newRow["OfficeID"] = officeId;
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
            System.Data.DataTable table = new DataTable("LFS_OFFICE");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "OfficeID";
            Table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Name";
            Table.Columns.Add(column);
        }

        

    }
}
