using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Resources.BondingCompanies;

namespace LiquiForce.LFSLive.BL.Resources.BondingCompanies
{
    /// <summary>
    /// BondingCompaniesAddBondingCompanies
    /// </summary>
    public class BondingCompaniesAddBondingCompanies: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public BondingCompaniesAddBondingCompanies()
            : base("BondingCompanies")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public BondingCompaniesAddBondingCompanies(DataSet data)
            : base(data, "BondingCompanies")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new BondingCompaniesAddTDS();
        }






        //// ////////////////////////////////////////////////////////////////////////
        //// PRIVATE METHODS
        ////

        /// <summary>
        /// Insert BondingCompanies
        /// </summary>
        /// <param name="companiesId">companiesId</param>
        /// <param name="date">date</param>
        /// <param name="name">name</param>
        /// <param name="companyId">companyId</param>        
        /// <param name="deleted">deleted</param>
        public void Insert(int companiesId, DateTime date, string name, bool deleted, int companyId)
        {
            BondingCompaniesAddTDS.BondingCompaniesRow row = ((BondingCompaniesAddTDS.BondingCompaniesDataTable)Table).NewBondingCompaniesRow();
            row.COMPANIES_ID = companiesId;
            row.Date = date;
            row.Name = name;            
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.InDatabase = false;

            ((BondingCompaniesAddTDS.BondingCompaniesDataTable)Table).AddBondingCompaniesRow(row);
        }






        //// ////////////////////////////////////////////////////////////////////////
        //// PRIVATE METHODS
        ////
               
        /// <summary>
        /// Save all bondingCompanies to database (direct)
        /// </summary>
        /// <param name="companyId">companyId</param>        
        public void Save(int companyId)
        {
            BondingCompaniesAddTDS bondingCompaniesChanges = (BondingCompaniesAddTDS)Data.GetChanges();

            if (bondingCompaniesChanges.BondingCompanies.Rows.Count > 0)
            {
                BondingCompaniesAddBondingCompaniesGateway bondingCompaniesAddBondingCompaniesGateway = new BondingCompaniesAddBondingCompaniesGateway(bondingCompaniesChanges);

                foreach (BondingCompaniesAddTDS.BondingCompaniesRow row in (BondingCompaniesAddTDS.BondingCompaniesDataTable)bondingCompaniesChanges.BondingCompanies)
                {
                    //Insert companies                   
                    BondingCompanies hotels = new BondingCompanies(null);
                    hotels.InsertDirect(row.COMPANIES_ID, row.Date, row.Name,  row.Deleted, row.COMPANY_ID);                    
                }
            }
        }



        /// <summary>
        /// Get a single bondingCompanies. If not exists, raise an exception
        /// </summary>
        /// <param name="companiesId">companiesId</param>
        /// <param name="date">date</param>
        /// <returns>BondingCompaniesAddTDS.BondingCompaniesRow</returns>
        private BondingCompaniesAddTDS.BondingCompaniesRow GetRow(int companiesId, DateTime date)
        {
            BondingCompaniesAddTDS.BondingCompaniesRow row = ((BondingCompaniesAddTDS.BondingCompaniesDataTable)Table).FindByCOMPANIES_IDDate(companiesId, date);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Resources.BondingCompanies.BondingCompaniesAddBondingCompanies.GetRow");
            }

            return row;
        }


    }
}
