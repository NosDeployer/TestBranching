using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Resources.InsuranceCompanies;

namespace LiquiForce.LFSLive.BL.Resources.InsuranceCompanies
{
    /// <summary>
    /// InsuranceCompaniesSetupInsuranceCompaniesSetup
    /// </summary>
    public class InsuranceCompaniesSetupInsuranceCompaniesSetup : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public InsuranceCompaniesSetupInsuranceCompaniesSetup()
            : base("InsuranceCompaniesSetup")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public InsuranceCompaniesSetupInsuranceCompaniesSetup(DataSet data)
            : base(data, "InsuranceCompaniesSetup")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new InsuranceCompaniesSetupTDS();
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
            InsuranceCompaniesSetupInsuranceCompaniesSetupGateway insuranceCompaniesSetupInsuranceCompaniesSetupGateway = new InsuranceCompaniesSetupInsuranceCompaniesSetupGateway(Data);
            insuranceCompaniesSetupInsuranceCompaniesSetupGateway.LoadAll(companyId);

            UpdateDataForNavigators();
        }



        /// <summary>
        /// Load
        /// </summary>
        /// <param name="companyId">companyId</param>
        public void Load(int companyId)
        {
            InsuranceCompaniesSetupInsuranceCompaniesSetupGateway insuranceCompaniesSetupInsuranceCompaniesSetupGateway = new InsuranceCompaniesSetupInsuranceCompaniesSetupGateway(Data);
            insuranceCompaniesSetupInsuranceCompaniesSetupGateway.Load(companyId);

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
            InsuranceCompaniesSetupTDS.InsuranceCompaniesSetupRow row = GetRow(companiesId, date);
            row.Deleted = true;
        }



        /// <summary>
        /// Save all insuranceCompanies to database (direct)
        /// </summary>
        /// <param name="companyId">companyId</param>        
        public void Save(int companyId)
        {
            InsuranceCompaniesSetupTDS subcontractorSetupChanges = (InsuranceCompaniesSetupTDS)Data.GetChanges();

            if (subcontractorSetupChanges != null)
            {
                if (subcontractorSetupChanges.InsuranceCompaniesSetup.Rows.Count > 0)
                {
                    InsuranceCompaniesSetupInsuranceCompaniesSetupGateway insuranceCompaniesSetupInsuranceCompaniesSetupGateway = new InsuranceCompaniesSetupInsuranceCompaniesSetupGateway(subcontractorSetupChanges);

                    foreach (InsuranceCompaniesSetupTDS.InsuranceCompaniesSetupRow row in (InsuranceCompaniesSetupTDS.InsuranceCompaniesSetupDataTable)subcontractorSetupChanges.InsuranceCompaniesSetup)
                    {
                        // Delete insuranceCompanies
                        if (row.Deleted)
                        {
                            InsuranceCompanies insuranceCompanies = new InsuranceCompanies(null);
                            insuranceCompanies.DeleteDirect(row.COMPANIES_ID, row.Date);
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
        /// <returns>InsuranceCompaniesSetupTDS.InsuranceCompaniesSetupRow</returns>
        private InsuranceCompaniesSetupTDS.InsuranceCompaniesSetupRow GetRow(int companiesId, DateTime date)
        {
            InsuranceCompaniesSetupTDS.InsuranceCompaniesSetupRow row = ((InsuranceCompaniesSetupTDS.InsuranceCompaniesSetupDataTable)Table).FindByCOMPANIES_IDDate(companiesId, date);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Resources.InsuranceCompanies.InsuranceCompaniesSetupInsuranceCompaniesSetup.GetRow");
            }

            return row;
        }



        /// <summary>
        /// UpdateDataForNavigators
        /// </summary>
        private void UpdateDataForNavigators()
        {
            foreach (InsuranceCompaniesSetupTDS.InsuranceCompaniesSetupRow row in (InsuranceCompaniesSetupTDS.InsuranceCompaniesSetupDataTable)Table)
            {
                row.DateString = row.Date.ToString();
            }
        }



    }
}