using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Resources.Companies;

namespace LiquiForce.LFSLive.BL.Resources.Companies
{
    /// <summary>
    /// CompaniesList
    /// </summary>
    public class CompaniesList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public CompaniesList()
            : base("LFS_RESOURCES_COMPANIES")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public CompaniesList(DataSet data)
            : base(data, "LFS_RESOURCES_COMPANIES")
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
        /// <param name="companiesId">companiesId</param>
        /// <param name="name">name</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAndAddItem(int? companiesId, string name, int companyId)
        {
            // Add item
            CreateTableStructure();
            Insert(companiesId, name);

            // Load companies list
            CompaniesListGateway companiesListGateway = new CompaniesListGateway(Data);
            companiesListGateway.ClearBeforeFill = false;
            companiesListGateway.Load(companyId);
            companiesListGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// LoadAndAddItemByCountryId
        /// </summary>
        /// <param name="companiesId">companiesId</param>
        /// <param name="name">name</param>
        /// <param name="countryId">countryId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAndAddItemByCountryId(int? companiesId, string name, int countryId, int companyId)
        {
            // Add item
            CreateTableStructure();
            Insert(companiesId, name);

            // Load companies list
            CompaniesListGateway companiesListGateway = new CompaniesListGateway(Data);
            
            companiesListGateway.ClearBeforeFill = false;

            if (countryId == -1)
            {
                companiesListGateway.Load(companyId);
            }
            else
            {
                companiesListGateway.LoadByCountryId(countryId, companyId);
            }

            companiesListGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="companiesId">companiesId</param>
        /// <param name="name">name</param>
        public void Insert(int? companiesId, string name)
        {
            // Verify structure
            if (Table == null)
            {
                CreateTableStructure();
            }

            // Insert row
            DataRow newRow = Table.NewRow();
            if (companiesId.HasValue)
            {
                newRow["COMPANIES_ID"] = (int) companiesId;
            }
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
            System.Data.DataTable table = new DataTable("LFS_RESOURCES_COMPANIES");
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
