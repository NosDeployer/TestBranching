using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Resources.BondingCompanies;

namespace LiquiForce.LFSLive.BL.Resources.BondingCompanies
{
    /// <summary>
    /// BondingCompaniesSetupBondingCompaniesSetup
    /// </summary>
    public class BondingCompaniesSetupBondingCompaniesSetup : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public BondingCompaniesSetupBondingCompaniesSetup()
            : base("BondingCompaniesSetup")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public BondingCompaniesSetupBondingCompaniesSetup(DataSet data)
            : base(data, "BondingCompaniesSetup")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new BondingCompaniesSetupTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// LoadAll
        /// </summary>
        /// <param name="companyId">companyId</param>
        public void LoadAll(int companyId)
        {
            BondingCompaniesSetupBondingCompaniesSetupGateway bondingCompaniesSetupBondingCompaniesSetupGateway = new BondingCompaniesSetupBondingCompaniesSetupGateway(Data);
            bondingCompaniesSetupBondingCompaniesSetupGateway.LoadAll(companyId);

            UpdateDataForNavigators();
        }
        


        /// <summary>
        /// Load
        /// </summary>
        /// <param name="companyId">companyId</param>
        public void Load(int companyId)
        {
            BondingCompaniesSetupBondingCompaniesSetupGateway bondingCompaniesSetupBondingCompaniesSetupGateway = new BondingCompaniesSetupBondingCompaniesSetupGateway(Data);
            bondingCompaniesSetupBondingCompaniesSetupGateway.Load(companyId);

            UpdateDataForNavigators();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //
                
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="companiesId">companiesId</param>
        /// <param name="date">date</param>
        public void Delete(int companiesId, DateTime date)
        {
            BondingCompaniesSetupTDS.BondingCompaniesSetupRow row = GetRow(companiesId, date);
            row.Deleted = true;
        }



        /// <summary>
        /// Save all bondingCompanies to database (direct)
        /// </summary>
        /// <param name="companyId">companyId</param>        
        public void Save(int companyId)
        {
            BondingCompaniesSetupTDS subcontractorSetupChanges = (BondingCompaniesSetupTDS)Data.GetChanges();

            if (subcontractorSetupChanges != null)
            {
                if (subcontractorSetupChanges.BondingCompaniesSetup.Rows.Count > 0)
                {
                    BondingCompaniesSetupBondingCompaniesSetupGateway bondingCompaniesSetupBondingCompaniesSetupGateway = new BondingCompaniesSetupBondingCompaniesSetupGateway(subcontractorSetupChanges);

                    foreach (BondingCompaniesSetupTDS.BondingCompaniesSetupRow row in (BondingCompaniesSetupTDS.BondingCompaniesSetupDataTable)subcontractorSetupChanges.BondingCompaniesSetup)
                    {                       

                        // Delete bondingCompanies
                        if (row.Deleted)
                        {
                            BondingCompanies bondingCompanies = new BondingCompanies(null);
                            bondingCompanies.DeleteDirect(row.COMPANIES_ID, row.Date);
                        }
                    }
                }
            }
        }



        /// <summary>
        /// Get a single catalyst. If not exists, raise an exception
        /// </summary>
        /// <param name="companiesId">companiesId</param>
        /// <param name="date">date</param>
        /// <returns>BondingCompaniesSetupTDS.BondingCompaniesSetupRow</returns>
        private BondingCompaniesSetupTDS.BondingCompaniesSetupRow GetRow(int companiesId, DateTime date)
        {
            BondingCompaniesSetupTDS.BondingCompaniesSetupRow row = ((BondingCompaniesSetupTDS.BondingCompaniesSetupDataTable)Table).FindByCOMPANIES_IDDate(companiesId, date);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Resources.BondingCompanies.BondingCompaniesSetupBondingCompaniesSetup.GetRow");
            }

            return row;
        }



        /// <summary>
        /// UpdateDataForNavigators
        /// </summary>
        private void UpdateDataForNavigators()
        {
            foreach (BondingCompaniesSetupTDS.BondingCompaniesSetupRow row in (BondingCompaniesSetupTDS.BondingCompaniesSetupDataTable)Table)
            {
                row.DateString = row.Date.ToString();
            }
        }



    }
}