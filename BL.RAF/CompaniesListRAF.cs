using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.RAF;

namespace LiquiForce.LFSLive.BL.RAF
{
    /// <summary>
    /// CompaniesListRAF
    /// </summary>
    public class CompaniesListRAF : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public CompaniesListRAF() : base("COMPANIES")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public CompaniesListRAF(DataSet data)
            : base(data, "COMPANIES")
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
            CompaniesListGatewayRAF companiesListGatewayRAF = new CompaniesListGatewayRAF(Data);
            companiesListGatewayRAF.ClearBeforeFill = false;
            companiesListGatewayRAF.Load(companyId);
            companiesListGatewayRAF.ClearBeforeFill = true;

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
            CompaniesListGatewayRAF companiesListGatewayRAF = new CompaniesListGatewayRAF(Data);

            companiesListGatewayRAF.ClearBeforeFill = false;

            if (countryId == -1)
            {
                companiesListGatewayRAF.Load(companyId);
            }
            else
            {
                companiesListGatewayRAF.LoadByCountryId(countryId, companyId);
            }

            companiesListGatewayRAF.ClearBeforeFill = true;

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
            newRow["NAME"] = name;
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
            System.Data.DataTable table = new DataTable("COMPANIES");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "COMPANIES_ID";
            Table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "NAME";
            Table.Columns.Add(column);
        }



    }
}
