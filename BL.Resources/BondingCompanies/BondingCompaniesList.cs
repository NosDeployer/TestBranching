using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Resources.BondingCompanies;

namespace LiquiForce.LFSLive.BL.Resources.BondingCompanies
{
    /// <summary>
    /// BondingCompaniesList
    /// </summary>
    public class BondingCompaniesList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public BondingCompaniesList()
            : base("LFS_RESOURCES_BONDING_COMPANIES")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public BondingCompaniesList(DataSet data)
            : base(data, "LFS_RESOURCES_BONDING_COMPANIES")
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
        /// <param name="bondingCompanyId">bondingCompanyId</param>
        /// <param name="name">name</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAndAddItem(int bondingCompanyId, string name, int companyId)
        {
            // Add item
            CreateTableStructure();
            Insert(bondingCompanyId, name);

            // Load costing sheet list
            BondingCompaniesListGateway bondingCompaniesListGateway = new BondingCompaniesListGateway(Data);
            bondingCompaniesListGateway.ClearBeforeFill = false;
            bondingCompaniesListGateway.Load(companyId);
            bondingCompaniesListGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// LoadAndAddItem
        /// </summary>                
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAndAddItem(int companyId)
        {
            // Add item
            CreateTableStructure();           

            // Load costing sheet list
            BondingCompaniesListGateway bondingCompaniesListGateway = new BondingCompaniesListGateway(Data);
            bondingCompaniesListGateway.ClearBeforeFill = false;
            bondingCompaniesListGateway.Load(companyId);
            bondingCompaniesListGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="bondingCompanyId">bondingCompanyId</param>
        /// <param name="name">name</param>
        public void Insert(int bondingCompanyId, string name)
        {
            // Verify structure
            if (Table == null)
            {
                CreateTableStructure();
            }

            // Insert row
            DataRow newRow = Table.NewRow();
            newRow["COMPANIES_ID"] = bondingCompanyId;
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
            System.Data.DataTable table = new DataTable("LFS_RESOURCES_BONDING_COMPANIES");
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