using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Services;
using LiquiForce.LFSLive.DA.FleetManagement.Units;

namespace LiquiForce.LFSLive.BL.FleetManagement.Services
{
    /// <summary>
    /// Services
    /// </summary>
    public class Services : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public Services()
            : base("LFS_FM_SERVICE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public Services(DataSet data)
            : base(data, "LFS_FM_SERVICE")
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
        /// <param name="dateTime_">dateTime_</param>
        /// <param name="mto">mto</param>
        /// <param name="description">description</param>
        /// <param name="unitId">unitId</param>
        /// <param name="type">type</param>
        /// <param name="state">state</param>
        /// <param name="ownerId">ownerId</param>
        /// <param name="assignDateTime">assignDateTime</param>
        /// <param name="assignDeadlineDate">assignDeadlineDate</param>
        /// <param name="assignTeamMember">assignTeamMember</param>
        /// <param name="assignTeamMemberID">assignTeamMemberID</param>
        /// <param name="assignThirdPartyVendor">assignThirdPartyVendor</param>
        /// <param name="acceptDateTime">acceptDateTime</param>
        /// <param name="rejectDateTime">rejectDateTime</param>
        /// <param name="rejectReason">rejectReason</param>
        /// <param name="startWorkDateTime">startWorkDateTime</param>
        /// <param name="startWorkOutOfServiceDate">startWorkOutOfServiceDate</param>
        /// <param name="startWorkOutOfServiceTime">startWorkOutOfServiceTime</param>
        /// <param name="completeWorkDateTime">completeWorkDateTime</param>
        /// <param name="completeWorkBackToServiceDate">completeWorkBackToServiceDate</param>
        /// <param name="completeWorkBackToServiceTime">completeWorkBackToServiceTime</param>
        /// <param name="completeWorkDetailDescription">completeWorkDetailDescription</param>
        /// <param name="completeWorkDetailPreventable">completeWorkDetailPreventable</param>
        /// <param name="completeWorkDetailTMLabourHours">completeWorkDetailTMLabourHours</param>
        /// <param name="completeWorkDetailTMCost">completeWorkDetailTMCost</param>
        /// <param name="completeWorkDetailTPVInvoiceNumber">completeWorkDetailTPVInvoiceNumber</param>
        /// <param name="completeWorkDetailTPVInvoiceAmout">completeWorkDetailTPVInvoiceAmout</param>
        /// <param name="notes">notes</param>
        /// <param name="ruleId">ruleId</param>
        /// <param name="mileage">mileage</param>
        /// <param name="startWorkMileage">startWorkMileage</param>
        /// <param name="completeWorkMileage">completeWorkMileage</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="libraryCategoriesId">libraryCategoriesId</param>
        /// <returns>int</returns>
        public int InsertDirect(DateTime? dateTime_, bool mto, string description, int? unitId, string type, string state, int ownerId, DateTime? assignDateTime, DateTime? assignDeadlineDate, bool assignTeamMember, int? assignTeamMemberID, string assignThirdPartyVendor, DateTime? acceptDateTime, DateTime? rejectDateTime, string rejectReason, DateTime? startWorkDateTime, DateTime? startWorkOutOfServiceDate, string startWorkOutOfServiceTime, DateTime? completeWorkDateTime, DateTime? completeWorkBackToServiceDate, string completeWorkBackToServiceTime, string completeWorkDetailDescription, bool completeWorkDetailPreventable, decimal? completeWorkDetailTMLabourHours, decimal? completeWorkDetailTMCost, string completeWorkDetailTPVInvoiceNumber, decimal? completeWorkDetailTPVInvoiceAmout, string notes, int? ruleId, string mileage, string startWorkMileage, string completeWorkMileage, bool deleted, int companyId, int? libraryCategoriesId)
        {
            // Get new service number by commpany
            string number = GetServiceNumber(companyId);

            // Get serviceId and insert request
            ServicesGateway servicesGateway = new ServicesGateway(null);
            int serviceId = servicesGateway.Insert(number, dateTime_, mto, description, unitId, type, state, ownerId, assignDateTime, assignDeadlineDate, assignTeamMember, assignTeamMemberID, assignThirdPartyVendor, acceptDateTime, rejectDateTime, rejectReason, startWorkDateTime, startWorkOutOfServiceDate, startWorkOutOfServiceTime, completeWorkDateTime, completeWorkBackToServiceDate, completeWorkBackToServiceTime, completeWorkDetailDescription, completeWorkDetailPreventable, completeWorkDetailTMLabourHours, completeWorkDetailTMCost, completeWorkDetailTPVInvoiceNumber, completeWorkDetailTPVInvoiceAmout, notes, ruleId, deleted, companyId, libraryCategoriesId);
            
            // Validate unit type
            if (unitId.HasValue)
            {
                UnitsGateway unitsGateway = new UnitsGateway();
                unitsGateway.LoadByUnitId((int)unitId, companyId);
                string unitType = unitsGateway.GetType((int)unitId);

                // ... Insert vehicle info
                if (unitType == "Vehicle")
                {
                    ServicesVehicle servicesVehicle = new ServicesVehicle(null);
                    servicesVehicle.InsertDirect(serviceId, mileage, startWorkMileage, completeWorkMileage, deleted, companyId);
                }
            }

            return serviceId;
        }



        /// <summary>
        /// Update direct (direct a service to DB)
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <param name="originalNumber">originalNumber</param>
        /// <param name="originalDateTime">originalDateTime</param>
        /// <param name="originalMtoDto">originalMtoDto</param>
        /// <param name="originalDescription">originalDescription</param>
        /// <param name="originalUnitId">originalUnitId</param>
        /// <param name="originalType">originalType</param>
        /// <param name="originalState">originalState</param>
        /// <param name="originalOwnerId">originalOwnerId</param>
        /// <param name="originalAssignDateTime">originalAssignDateTime</param>
        /// <param name="originalAssignDeadlineDate">originalAssignDeadlineDate</param>
        /// <param name="originalAssignTeamMember">originalAssignTeamMember</param>
        /// <param name="originalAssignTeamMemberID">originalAssignTeamMemberID</param>
        /// <param name="originalAssignThirdPartyVendor">originalAssignThirdPartyVendor</param>
        /// <param name="originalAcceptDateTime">originalAcceptDateTime</param>
        /// <param name="originalRejectDateTime">originalRejectDateTime</param>
        /// <param name="originalRejectReason">originalRejectReason</param>
        /// <param name="originalStartWorkDateTime">originalStartWorkDateTime</param>
        /// <param name="originalStartWorkOutOfServiceDate">originalStartWorkOutOfServiceDate</param>
        /// <param name="originalStartWorkOutOfServiceTime">originalStartWorkOutOfServiceTime</param>
        /// <param name="originalCompleteWorkDateTime">originalCompleteWorkDateTime</param>
        /// <param name="originalCompleteWorkBackToServiceDate">originalCompleteWorkBackToServiceDate</param>
        /// <param name="originalCompleteWorkBackToServiceTime">originalCompleteWorkBackToServiceTime</param>
        /// <param name="originalCompleteWorkDetailDescription">originalCompleteWorkDetailDescription</param>
        /// <param name="originalCompleteWorkDetailPreventable">originalCompleteWorkDetailPreventable</param>
        /// <param name="originalCompleteWorkDetailTMLabourHours">originalCompleteWorkDetailTMLabourHours</param>
        /// <param name="originalCompleteWorkDetailTMCost">originalCompleteWorkDetailTMCost</param>
        /// <param name="originalCompleteWorkDetailTPVInvoiceNumber">originalCompleteWorkDetailTPVInvoiceNumber</param>
        /// <param name="originalCompleteWorkDetailTPVInvoiceAmout">originalCompleteWorkDetailTPVInvoiceAmout</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalNotes">originalNotes</param>
        /// <param name="originalRuleID">originalRuleID</param>
        /// <param name="originalMileage">originalMileage</param>
        /// <param name="originalStartWorkMileage">originalStartWorkMileage</param>
        /// <param name="originalCompleteWorkMileage">originalCompleteWorkMileage</param>
        /// <param name="originalLibraryCategoriesId">originalLibraryCategoriesId</param>
        /// 
        /// <param name="newNumber">newNumber</param>
        /// <param name="newDateTime">newDateTime</param>
        /// <param name="newMtoDto">newMtoDto</param>
        /// <param name="newDescription">newDescription</param>
        /// <param name="newUnitId">newUnitId</param>
        /// <param name="newType">newType</param>
        /// <param name="newState">newState</param>
        /// <param name="newOwnerId">newOwnerId</param>
        /// <param name="newAssignDateTime">newAssignDateTime</param>
        /// <param name="newAssignDeadlineDate">newAssignDeadlineDate</param>
        /// <param name="newAssignTeamMember">newAssignTeamMember</param>
        /// <param name="newAssignTeamMemberID">newAssignTeamMemberID</param>
        /// <param name="newAssignThirdPartyVendor">newAssignThirdPartyVendor</param>
        /// <param name="newAcceptDateTime">newAcceptDateTime</param>
        /// <param name="newRejectDateTime">newRejectDateTime</param>
        /// <param name="newRejectReason">newRejectReason</param>
        /// <param name="newStartWorkDateTime">newStartWorkDateTime</param>
        /// <param name="newStartWorkOutOfServiceDate">newStartWorkOutOfServiceDate</param>
        /// <param name="newStartWorkOutOfServiceTime">newStartWorkOutOfServiceTime</param>
        /// <param name="newCompleteWorkDateTime">newCompleteWorkDateTime</param>
        /// <param name="newCompleteWorkBackToServiceDate">newCompleteWorkBackToServiceDate</param>
        /// <param name="newCompleteWorkBackToServiceTime">newCompleteWorkBackToServiceTime</param>
        /// <param name="newCompleteWorkDetailDescription">newCompleteWorkDetailDescription</param>
        /// <param name="newCompleteWorkDetailPreventable">newCompleteWorkDetailPreventable</param>
        /// <param name="newCompleteWorkDetailTMLabourHours">newCompleteWorkDetailTMLabourHours</param>
        /// <param name="newCompleteWorkDetailTMCost">newCompleteWorkDetailTMCost</param>
        /// <param name="newCompleteWorkDetailTPVInvoiceNumber">newCompleteWorkDetailTPVInvoiceNumber</param>
        /// <param name="newCompleteWorkDetailTPVInvoiceAmout">newCompleteWorkDetailTPVInvoiceAmout</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newNotes">newNotes</param>
        /// <param name="newRuleID">newRuleID</param>
        /// <param name="newMileage">newMileage</param> 
        /// <param name="newStartWorkMileage">newStartWorkMileage</param>
        /// <param name="newCompleteWorkMileage">newCompleteWorkMileage</param>
        /// <param name="newLibraryCategoriesId">newLibraryCategoriesId</param>
        public void UpdateDirect(int serviceId, string originalNumber, DateTime originalDateTime, bool originalMtoDto, string originalDescription, int? originalUnitId, string originalType, string originalState, int originalOwnerId, DateTime? originalAssignDateTime, DateTime? originalAssignDeadlineDate, bool originalAssignTeamMember, int? originalAssignTeamMemberID, string originalAssignThirdPartyVendor, DateTime? originalAcceptDateTime, DateTime? originalRejectDateTime, string originalRejectReason, DateTime? originalStartWorkDateTime, DateTime? originalStartWorkOutOfServiceDate, string originalStartWorkOutOfServiceTime, DateTime? originalCompleteWorkDateTime, DateTime? originalCompleteWorkBackToServiceDate, string originalCompleteWorkBackToServiceTime, string originalCompleteWorkDetailDescription, bool originalCompleteWorkDetailPreventable, decimal? originalCompleteWorkDetailTMLabourHours, decimal? originalCompleteWorkDetailTMCost, string originalCompleteWorkDetailTPVInvoiceNumber, decimal? originalCompleteWorkDetailTPVInvoiceAmout, bool originalDeleted, int originalCompanyId, string originalNotes, int? originalRuleID, string originalMileage, string originalStartWorkMileage, string originalCompleteWorkMileage, int? originalLibraryCategoriesId, string newNumber, DateTime? newDateTime, bool newMtoDto, string newDescription, int? newUnitId, string newType, string newState, int newOwnerId, DateTime? newAssignDateTime, DateTime? newAssignDeadlineDate, bool newAssignTeamMember, int? newAssignTeamMemberID, string newAssignThirdPartyVendor, DateTime? newAcceptDateTime, DateTime? newRejectDateTime, string newRejectReason, DateTime? newStartWorkDateTime, DateTime? newStartWorkOutOfServiceDate, string newStartWorkOutOfServiceTime, DateTime? newCompleteWorkDateTime, DateTime? newCompleteWorkBackToServiceDate, string newCompleteWorkBackToServiceTime, string newCompleteWorkDetailDescription, bool newCompleteWorkDetailPreventable, decimal? newCompleteWorkDetailTMLabourHours, decimal? newCompleteWorkDetailTMCost, string newCompleteWorkDetailTPVInvoiceNumber, decimal? newCompleteWorkDetailTPVInvoiceAmout, bool newDeleted, int newCompanyId, string newNotes, int? newRuleID, string newMileage, string newStartWorkMileage, string newCompleteWorkMileage, int? newLibraryCategoriesId)
        {
            ServicesGateway servicesGateway = new ServicesGateway(null);
            servicesGateway.Update(serviceId, originalNumber, originalDateTime, originalMtoDto, originalDescription, originalUnitId, originalType, originalState, originalOwnerId, originalAssignDateTime,  originalAssignDeadlineDate, originalAssignTeamMember, originalAssignTeamMemberID, originalAssignThirdPartyVendor, originalAcceptDateTime, originalRejectDateTime, originalRejectReason, originalStartWorkDateTime, originalStartWorkOutOfServiceDate, originalStartWorkOutOfServiceTime, originalCompleteWorkDateTime, originalCompleteWorkBackToServiceDate, originalCompleteWorkBackToServiceTime, originalCompleteWorkDetailDescription, originalCompleteWorkDetailPreventable, originalCompleteWorkDetailTMLabourHours, originalCompleteWorkDetailTMCost, originalCompleteWorkDetailTPVInvoiceNumber, originalCompleteWorkDetailTPVInvoiceAmout, originalDeleted, originalCompanyId, originalNotes, originalRuleID, originalLibraryCategoriesId, newNumber, newDateTime, newMtoDto,  newDescription, newUnitId, newType, newState, newOwnerId, newAssignDateTime, newAssignDeadlineDate,  newAssignTeamMember, newAssignTeamMemberID, newAssignThirdPartyVendor, newAcceptDateTime, newRejectDateTime, newRejectReason, newStartWorkDateTime, newStartWorkOutOfServiceDate, newStartWorkOutOfServiceTime, newCompleteWorkDateTime, newCompleteWorkBackToServiceDate, newCompleteWorkBackToServiceTime, newCompleteWorkDetailDescription, newCompleteWorkDetailPreventable, newCompleteWorkDetailTMLabourHours, newCompleteWorkDetailTMCost, newCompleteWorkDetailTPVInvoiceNumber, newCompleteWorkDetailTPVInvoiceAmout, newDeleted, newCompanyId, newNotes, newRuleID, newLibraryCategoriesId);

            // Validate unit type
            if (originalUnitId.HasValue)
            {
                UnitsGateway unitsGateway = new UnitsGateway();
                unitsGateway.LoadByUnitId((int)originalUnitId, originalCompanyId);
                string unitType = unitsGateway.GetType((int)originalUnitId);

                // ... Insert vehicle info
                if (unitType == "Vehicle")
                {
                    ServicesVehicle servicesVehicle = new ServicesVehicle(null);
                    servicesVehicle.UpdateDirect(serviceId, originalMileage, originalStartWorkMileage, originalCompleteWorkMileage, originalDeleted, originalCompanyId, newMileage, newStartWorkMileage, newCompleteWorkMileage, newDeleted, newCompanyId);
                }
            }
        }



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <param name="serviceType">serviceType</param>
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(int serviceId, string unitType, int companyId)
        {
            ServicesGateway servicesGeteway = new ServicesGateway();
            servicesGeteway.LoadByServiceId(serviceId, companyId);

            if (servicesGeteway.Table.Rows.Count > 0)
            {
                // Delete vehicle info
                if (unitType == "Vehicle")
                {
                   ServicesVehicle servicesVehicle = new ServicesVehicle(null);
                   servicesVehicle.DeleteDirect(serviceId, companyId);
                }

                // Delete notes
                ServicesNote servicesNote = new ServicesNote(null);
                servicesNote.DeleteAllDirect(serviceId, companyId);

                // Delete costs
                ServicesCost servicesCost = new ServicesCost(null);
                servicesCost.DeleteAllDirect(serviceId, companyId);

                // Delete service
                servicesGeteway.Delete(serviceId, companyId);
            }
        }





        
        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// GetServiceNumber
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <remreturns>newNumber</remreturns>
        private string GetServiceNumber(int companyId)
        {
            int newNumber = 0;

            // Load last service number
            ServicesGateway servicesGateway = new ServicesGateway();
            servicesGateway.LoadTop1ByServiceId(companyId);

            if (servicesGateway.Table.Rows.Count > 0)
            {
                int lastNumber = Int32.Parse(servicesGateway.GetNumberTop1());
                newNumber = lastNumber + 1;
            }
            else
            {
                newNumber = 1;
            }

            return newNumber.ToString();
        }



    }
}
