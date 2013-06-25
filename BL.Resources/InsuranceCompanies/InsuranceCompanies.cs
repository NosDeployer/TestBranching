using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Resources.InsuranceCompanies;

namespace LiquiForce.LFSLive.BL.Resources.InsuranceCompanies
{
    /// <summary>
    /// InsuranceCompanies
    /// </summary>
    public class InsuranceCompanies: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public InsuranceCompanies()
            : base("LFS_RESOURCES_INSURANCE_COMPANIES")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public InsuranceCompanies(DataSet data)
            : base(data, "LFS_RESOURCES_INSURANCE_COMPANIES")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new InsuranceCompaniesTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// InsertDirect
        /// </summary>
        /// <param name="companiesId">companiesId</param>
        /// <param name="date">date</param>
        /// <param name="name">name</param>
        /// <param name="active">active</param>        
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void InsertDirect(int companiesId, DateTime date, string name, bool deleted, int companyId)
        {
            InsuranceCompaniesGateway insuranceCompaniesGateway = new InsuranceCompaniesGateway(null);
            insuranceCompaniesGateway.Insert(companiesId, date, name, deleted, companyId);
        }



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="companiesId">companiesId</param>
        /// <param name="date">date</param>
        public void DeleteDirect(int companiesId, DateTime date)
        {
            // Delete comments
            InsuranceCompaniesGateway insuranceCompaniesGateway = new InsuranceCompaniesGateway(null);
            insuranceCompaniesGateway.Delete(companiesId, date);
        }
    }
}