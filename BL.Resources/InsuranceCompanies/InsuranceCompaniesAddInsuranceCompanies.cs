using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Resources.InsuranceCompanies;

namespace LiquiForce.LFSLive.BL.Resources.InsuranceCompanies
{
    /// <summary>
    /// InsuranceCompaniesAddInsuranceCompanies
    /// </summary>
    public class InsuranceCompaniesAddInsuranceCompanies: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public InsuranceCompaniesAddInsuranceCompanies()
            : base("InsuranceCompanies")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public InsuranceCompaniesAddInsuranceCompanies(DataSet data)
            : base(data, "InsuranceCompanies")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new InsuranceCompaniesAddTDS();
        }






        //// ////////////////////////////////////////////////////////////////////////
        //// PRIVATE METHODS
        ////

        /// <summary>
        /// Insert InsuranceCompanies
        /// </summary>
        /// <param name="companiesId">companiesId</param>
        /// <param name="date">date</param>
        /// <param name="name">name</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>        

        public void Insert(int companiesId, DateTime date, string name, bool deleted, int companyId)
        {
            InsuranceCompaniesAddTDS.InsuranceCompaniesRow row = ((InsuranceCompaniesAddTDS.InsuranceCompaniesDataTable)Table).NewInsuranceCompaniesRow();
            row.COMPANIES_ID = companiesId;
            row.Date = date;
            row.Name = name;            
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.InDatabase = false;

            ((InsuranceCompaniesAddTDS.InsuranceCompaniesDataTable)Table).AddInsuranceCompaniesRow(row);
        }






        //// ////////////////////////////////////////////////////////////////////////
        //// PRIVATE METHODS
        ////
               
        /// <summary>
        /// Save all insuranceCompanies to database (direct)
        /// </summary>
        /// <param name="companyId">companyId</param>        
        public void Save(int companyId)
        {
            InsuranceCompaniesAddTDS insuranceCompaniesChanges = (InsuranceCompaniesAddTDS)Data.GetChanges();

            if (insuranceCompaniesChanges.InsuranceCompanies.Rows.Count > 0)
            {
                InsuranceCompaniesAddInsuranceCompaniesGateway insuranceCompaniesAddInsuranceCompaniesGateway = new InsuranceCompaniesAddInsuranceCompaniesGateway(insuranceCompaniesChanges);

                foreach (InsuranceCompaniesAddTDS.InsuranceCompaniesRow row in (InsuranceCompaniesAddTDS.InsuranceCompaniesDataTable)insuranceCompaniesChanges.InsuranceCompanies)
                {
                    //Insert companies                   
                    InsuranceCompanies hotels = new InsuranceCompanies(null);
                    hotels.InsertDirect(row.COMPANIES_ID, row.Date, row.Name,  row.Deleted, row.COMPANY_ID);                    
                }
            }
        }



        /// <summary>
        /// Get a single insuranceCompanies. If not exists, raise an exception
        /// </summary>
        /// <param name="companiesId">companiesId</param>
        /// <param name="date">date</param>
        /// <returns>InsuranceCompaniesAddTDS.InsuranceCompaniesRow</returns>
        private InsuranceCompaniesAddTDS.InsuranceCompaniesRow GetRow(int companiesId, DateTime date)
        {
            InsuranceCompaniesAddTDS.InsuranceCompaniesRow row = ((InsuranceCompaniesAddTDS.InsuranceCompaniesDataTable)Table).FindByCOMPANIES_IDDate(companiesId, date);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Resources.InsuranceCompanies.InsuranceCompaniesAddInsuranceCompanies.GetRow");
            }

            return row;
        }


    }
}
