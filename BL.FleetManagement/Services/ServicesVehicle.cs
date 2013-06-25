using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Services;

namespace LiquiForce.LFSLive.BL.FleetManagement.Services
{
    /// <summary>
    /// ServicesVehicle
    /// </summary>
    public class ServicesVehicle : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ServicesVehicle()
            : base("LFS_FM_SERVICE_VEHICLE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ServicesVehicle(DataSet data)
            : base(data, "LFS_FM_SERVICE_VEHICLE")
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
        /// Insert a new service (direct to DB)
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <param name="mileage">mileage</param>
        /// <param name="startWorkMileage">startWorkMileage</param>
        /// <param name="completeWorkMileage">completeWorkMileage</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void InsertDirect(int serviceId, string mileage, string startWorkMileage, string completeWorkMileage,  bool deleted, int companyId)
        {
            ServicesVehicleGateway servicesVehicleGateway = new ServicesVehicleGateway(null);
            servicesVehicleGateway.Insert(serviceId, mileage, startWorkMileage, completeWorkMileage, deleted, companyId);
        }



        /// <summary>
        /// Update a work (direct to DB)
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <param name="originalMileage">originalMileage</param>
        /// <param name="originalStartWorkMileage">originalStartWorkMileage</param>
        /// <param name="originalCompleteWorkMileage">originalCompleteWorkMileage</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        ///
        /// <param name="newMileage">newMileage</param> 
        /// <param name="newStartWorkMileage">newStartWorkMileage</param>
        /// <param name="newCompleteWorkMileage">newCompleteWorkMileage</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        public void UpdateDirect(int serviceId, string originalMileage, string originalStartWorkMileage, string originalCompleteWorkMileage, bool originalDeleted, int originalCompanyId, string newMileage, string newStartWorkMileage, string newCompleteWorkMileage, bool newDeleted, int newCompanyId)
        {
            ServicesVehicleGateway servicesVehicleGateway = new ServicesVehicleGateway(null);
            servicesVehicleGateway.Update(serviceId, originalMileage, originalStartWorkMileage, originalCompleteWorkMileage, originalDeleted, originalCompanyId, serviceId, newMileage, newStartWorkMileage, newCompleteWorkMileage, newDeleted, newCompanyId);
        }



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(int serviceId, int companyId)
        {
            ServicesVehicleGateway servicesVehicleGateway = new ServicesVehicleGateway(null);
            servicesVehicleGateway.Delete(serviceId, companyId);
        }



    }
}
