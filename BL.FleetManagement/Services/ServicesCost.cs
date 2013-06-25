using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Services;

namespace LiquiForce.LFSLive.BL.FleetManagement.Services
{
    /// <summary>
    /// ServiceCost
    /// </summary>
    public class ServicesCost : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ServicesCost()
            : base("LFS_FM_SERVICE_COST")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ServicesCost(DataSet data)
            : base(data, "LFS_FM_SERVICE_COST")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ServicesTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Insert direct (direct to DB)
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <param name="refId">refId</param>
        /// <param name="partNumber">partNumber</param>
        /// <param name="partName">partName</param>
        /// <param name="vendor">vendor</param>
        /// <param name="cost">cost</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="noteId">noteId</param>
        public void InsertDirect(int serviceId, int refId, string partNumber, string partName, string vendor, decimal cost, bool deleted, int companyId, int? noteId)
        {
            ServicesCostGateway servicesCostGateway = new ServicesCostGateway(null);
            servicesCostGateway.Insert(serviceId, refId, partNumber, partName, vendor, cost, deleted, companyId, noteId);
        }



        /// <summary>
        /// Update direct - cost (direct to DB)
        /// </summary>
        /// <param name="originalServiceId">originalServiceId</param>
        /// <param name="originalRefId">originalRefId</param>
        /// <param name="originalPartNumber">originalPartNumber</param>
        /// <param name="originalPartName">originalPartName</param>
        /// <param name="originalVendor">originalVendor</param>
        /// <param name="originalCost">originalCost</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalNoteId">originalNoteId</param>
        /// 
        /// <param name="newServiceId">newServiceId</param>
        /// <param name="newRefId">newRefId</param>
        /// <param name="newPartNumber">newPartNumber</param>
        /// <param name="newPartName">newPartName</param>
        /// <param name="newVendor">newVendor</param>
        /// <param name="newCost">newCost</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <pparam name="newNoteId">newNoteId</pparam>
        public void UpdateDirect( int originalServiceId, int originalRefId, string originalPartNumber, string originalPartName, string originalVendor, decimal originalCost, bool originalDeleted, int originalCompanyId, int? originalNoteId, int newServiceId, int newRefId, string newPartNumber, string newPartName, string newVendor, decimal newCost, bool newDeleted, int newCompanyId, int? newNoteId)
        {
            ServicesCostGateway servicesCostGateway = new ServicesCostGateway(null);
            servicesCostGateway.Update(originalServiceId, originalRefId, originalPartNumber, originalPartName, originalVendor, originalCost, originalDeleted, originalCompanyId, originalNoteId, newServiceId, newRefId, newPartNumber, newPartName, newVendor, newCost, newDeleted, newCompanyId, newNoteId);
        }
        


        /// <summary>
        /// DeleteDirect (direct to DB)
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(int serviceId, int refId, int companyId)
        {
            ServicesCostGateway servicesCostGateway = new ServicesCostGateway(null);
            servicesCostGateway.Delete(serviceId, refId, companyId);
        }



        /// <summary>
        /// Delete all costs (direct to DB)
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteAllDirect(int serviceId, int companyId)
        {
            ServicesCostGateway servicesCostGateway = new ServicesCostGateway(null);
            servicesCostGateway.DeleteAll(serviceId, companyId);
        }



    }
}