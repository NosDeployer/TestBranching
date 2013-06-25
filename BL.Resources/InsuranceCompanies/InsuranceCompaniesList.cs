using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Resources.InsuranceCompanies;

namespace LiquiForce.LFSLive.BL.Resources.InsuranceCompanies
{
    /// <summary>
    /// InsuranceCompaniesList
    /// </summary>
    public class InsuranceCompaniesList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public InsuranceCompaniesList()
            : base("LFS_RESOURCES_INSURANCE_COMPANIES")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public InsuranceCompaniesList(DataSet data)
            : base(data, "LFS_RESOURCES_INSURANCE_COMPANIES")
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
        public DataSet LoadAndAddItem(int companyId)
        {
            // Add item
            CreateTableStructure();            

            // Load costing sheet list
            InsuranceCompaniesListGateway insuranceCompaniesListGateway = new InsuranceCompaniesListGateway(Data);
            insuranceCompaniesListGateway.ClearBeforeFill = false;
            insuranceCompaniesListGateway.Load(companyId);
            insuranceCompaniesListGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// LoadAndAddItem
        /// </summary>
        /// <param name="insuranceCompanyId">insuranceCompanyId</param>
        /// <param name="name">name</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAndAddItem(int insuranceCompanyId, string name, int companyId)
        {
            // Add item
            CreateTableStructure();
            Insert(insuranceCompanyId, name);

            // Load costing sheet list
            InsuranceCompaniesListGateway insuranceCompaniesListGateway = new InsuranceCompaniesListGateway(Data);
            insuranceCompaniesListGateway.ClearBeforeFill = false;
            insuranceCompaniesListGateway.Load(companyId);
            insuranceCompaniesListGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="insuranceCompanyId">insuranceCompanyId</param>
        /// <param name="name">name</param>
        public void Insert(int insuranceCompanyId, string name)
        {
            // Verify structure
            if (Table == null)
            {
                CreateTableStructure();
            }

            // Insert row
            DataRow newRow = Table.NewRow();
            newRow["COMPANIES_ID"] = insuranceCompanyId;
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
            System.Data.DataTable table = new DataTable("LFS_RESOURCES_INSURANCE_COMPANIES");
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