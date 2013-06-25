using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Resources.BondingCompanies;

namespace LiquiForce.LFSLive.BL.Resources.BondingCompanies
{
    /// <summary>
    /// BondingCompanies
    /// </summary>
    public class BondingCompanies: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public BondingCompanies()
            : base("LFS_RESOURCES_BONDING_COMPANIES")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public BondingCompanies(DataSet data)
            : base(data, "LFS_RESOURCES_BONDING_COMPANIES")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new BondingCompaniesTDS();
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
            BondingCompaniesGateway bondingCompaniesGateway = new BondingCompaniesGateway(null);
            bondingCompaniesGateway.Insert(companiesId, date, name, deleted, companyId);
        }



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="companiesId">companiesId</param>
        /// <param name="date">date</param>
        public void DeleteDirect(int companiesId, DateTime date)
        {
            // Delete comments
            BondingCompaniesGateway bondingCompaniesGateway = new BondingCompaniesGateway(null);
            bondingCompaniesGateway.Delete(companiesId, date);
        }
    }
}