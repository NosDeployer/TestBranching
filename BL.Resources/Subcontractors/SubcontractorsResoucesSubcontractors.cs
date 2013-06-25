using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Resources.Subcontractors;

namespace LiquiForce.LFSLive.BL.Resources.Subcontractors
{
    /// <summary>
    /// LfsCompaniesCompnaies
    /// </summary>
    public class SubcontractorsResoucesSubcontractors : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public SubcontractorsResoucesSubcontractors()
            : base("LFS_RESOURCES_SUBCONTRACTORS")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public SubcontractorsResoucesSubcontractors(DataSet data)
            : base(data, "LFS_RESOURCES_SUBCONTRACTORS")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new SubcontractorsTDS();
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
        /// <param name="udf">udf</param>      
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void InsertDirect(int companiesId, DateTime date, string name,  bool active, bool udf, bool deleted, int companyId)
        {
            SubcontractorsResoucesSubcontractorsGateway subcontractorsResoucesSubcontractorsGateway = new SubcontractorsResoucesSubcontractorsGateway(null);
            subcontractorsResoucesSubcontractorsGateway.Insert(companiesId, date, name, active, udf, deleted, companyId);
        }



        /// <summary>
        /// UpdateDirect
        /// </summary>
        /// <param name="originalCompaniesId">originalCompaniesId</param>
        /// <param name="originalDate">originalDate</param>
        /// <param name="originalActive">originalActive</param>
        /// <param name="originalUdf">originalUdf</param>        
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>

        /// <param name="newCompaniesId">newCompaniesId</param>
        /// <param name="newDate">newDate</param>
        /// <param name="newActive">newActive</param>
        /// <param name="newUdf">newUdf</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        public void UpdateDirect(int originalCompaniesId, DateTime originalDate, bool originalActive, bool originalUdf, bool originalDeleted, int originalCompanyId, int newCompaniesId, DateTime newDate, bool newActive, bool newUdf, bool newDeleted, int newCompanyId)
        {
            SubcontractorsResoucesSubcontractorsGateway subcontractorsResoucesSubcontractorsGateway = new SubcontractorsResoucesSubcontractorsGateway(null);
            subcontractorsResoucesSubcontractorsGateway.Update(originalCompaniesId, originalDate, originalActive, originalUdf, originalDeleted, originalCompanyId, newCompaniesId, newDate, newActive, newUdf, newDeleted, newCompanyId);
        }



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="companiesId">companiesId</param>
        /// <param name="date">date</param>
        public void DeleteDirect(int companiesId, DateTime date)
        {
            // Delete comments
            SubcontractorsResoucesSubcontractorsGateway subcontractorsResoucesSubcontractorsGateway = new SubcontractorsResoucesSubcontractorsGateway(null);
            subcontractorsResoucesSubcontractorsGateway.Delete(companiesId, date);       
        }





    }
}
