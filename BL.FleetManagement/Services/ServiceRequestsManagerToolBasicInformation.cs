using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Services;
using LiquiForce.LFSLive.DA.FleetManagement.ChecklistRules;
using LiquiForce.LFSLive.BL.FleetManagement.ChecklistRules;

namespace LiquiForce.LFSLive.BL.FleetManagement.Services 
{
    /// <summary>
    /// ServiceRequestsManagerToolBasicInformation
    /// </summary>
    public class ServiceRequestsManagerToolBasicInformation : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ServiceRequestsManagerToolBasicInformation()
            : base("BasicInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ServiceRequestsManagerToolBasicInformation(DataSet data)
            : base(data, "BasicInformation")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ServiceRequestsManagerToolTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadByServiceId
        /// </summary>       
        /// <param name="serviceId">serviceId</param>
        /// <param name="companyId">companyId</param>
        public void LoadByServiceId(int serviceId, int companyId)
        {
            ServiceRequestsManagerToolBasicInformationGateway serviceRequestsManagerToolBasicInformationGateway = new ServiceRequestsManagerToolBasicInformationGateway(Data);
            serviceRequestsManagerToolBasicInformationGateway.LoadByServiceId(serviceId, companyId);
        }



        /// <summary>
        /// Update a Service
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <param name="serviceState">serviceState</param>
        /// <param name="assignDateTime">assignDateTime</param>
        /// <param name="assignedDeadlineDate">assignedDeadlineDate</param>
        /// <param name="assignTeamMember">assignTeamMember</param>
        /// <param name="assignTeamMemberId">assignTeamMemberId</param>
        /// <param name="assignThirdPartyVendor">assignThirdPartyVendor</param>
        /// <param name="acceptDateTime">acceptDateTime</param>
        /// <param name="startWorkDateTime">startWorkDateTime</param>
        /// <param name="unitOutOfServiceDate">unitOutOfServiceDate</param>
        /// <param name="unitOutOfServiceTime">unitOutOfServiceTime</param>
        /// <param name="completeWorkDateTime">completeWorkDateTime</param>
        /// <param name="unitBackInServiceDate">unitBackInServiceDate</param>
        /// <param name="unitBackInServiceTime">unitBackInServiceTime</param>
        /// <param name="completeWorkDetailDescription">completeWorkDetailDescription</param>
        /// <param name="completeWorkDetailPreventable">completeWorkDetailPreventable</param>
        /// <param name="completeWorkDetailTMLabourHours">completeWorkDetailTMLabourHours</param>
        /// <param name="completeWorkDetailTMCost">completeWorkDetailTMCost</param>
        /// <param name="completeWorkInvoiceNumber">completeWorkInvoiceNumber</param>
        /// <param name="completeWorkInvoiceAmount">completeWorkInvoiceAmount</param>
        /// <param name="startWorkMileage">startWorkMileage</param>
        /// <param name="completeWorkMileage">completeWorkMileage</param>
        /// <param name="newAssociatedChecklistRuleState">newAssociatedChecklistRuleState</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="libraryCategoriesId">libraryCategoriesId</param>
        public void Update(int serviceId, string serviceState, DateTime? assignDateTime, DateTime? assignedDeadlineDate, bool assignTeamMember, int? assignTeamMemberId, string assignThirdPartyVendor, DateTime? acceptDateTime, DateTime? startWorkDateTime, DateTime? unitOutOfServiceDate, string unitOutOfServiceTime, DateTime? completeWorkDateTime, DateTime? unitBackInServiceDate, string unitBackInServiceTime, string completeWorkDetailDescription, bool completeWorkDetailPreventable, Decimal? completeWorkDetailTMLabourHours, Decimal? completeWorkDetailTMCost, string completeWorkInvoiceNumber, decimal? completeWorkInvoiceAmount, string startWorkMileage, string completeWorkMileage, string newAssociatedChecklistRuleState, bool deleted, int companyId, int? libraryCategoriesId)
        {
            ServiceRequestsManagerToolTDS.BasicInformationRow row = GetRow(serviceId);

            row.ServiceState = serviceState;

            // Assignment information
            if (assignDateTime.HasValue) row.AssignmentDateTime = (DateTime)assignDateTime;
            if (assignedDeadlineDate.HasValue) row.AssignedDeadlineDate = (DateTime)assignedDeadlineDate;
            row.AssignTeamMember = assignTeamMember;
            if (assignTeamMemberId.HasValue) row.AssignTeamMemberID = (int)assignTeamMemberId; else row.SetAssignTeamMemberIDNull();
            if (assignThirdPartyVendor != "") row.AssignThirdPartyVendor = assignThirdPartyVendor; else row.SetAssignThirdPartyVendorNull();
            
            // Accept information
            if (acceptDateTime.HasValue) row.AcceptDateTime = (DateTime)acceptDateTime; else row.SetAcceptDateTimeNull();

            // Start work information
            if (startWorkDateTime.HasValue) row.StartWorkDateTime = (DateTime)startWorkDateTime; else row.SetStartWorkDateTimeNull();
            if (unitOutOfServiceDate.HasValue) row.UnitOutOfServiceDate = (DateTime)unitOutOfServiceDate; else row.SetUnitOutOfServiceDateNull();
            if (unitOutOfServiceTime != "") row.UnitOutOfServiceTime = unitOutOfServiceTime; else row.SetUnitOutOfServiceTimeNull();
            
            // Complete work information
            if (completeWorkDateTime.HasValue) row.CompleteWorkDateTime = (DateTime)completeWorkDateTime; else row.SetCompleteWorkDateTimeNull();
            if (unitBackInServiceDate.HasValue) row.UnitBackInServiceDate = (DateTime)unitBackInServiceDate; else row.SetUnitBackInServiceDateNull();
            if (unitBackInServiceTime != "") row.UnitBackInServiceTime = unitBackInServiceTime; else row.SetUnitBackInServiceTimeNull();
            if (completeWorkDetailDescription != "") row.CompleteWorkDetailDescription = completeWorkDetailDescription; else row.SetCompleteWorkDetailDescriptionNull();
            row.CompleteWorkDetailPreventable = completeWorkDetailPreventable;
            if (completeWorkDetailTMLabourHours.HasValue) row.CompleteWorkDetailTMLabourHours = (Decimal)completeWorkDetailTMLabourHours; else row.SetCompleteWorkDetailTMLabourHoursNull();
            if (completeWorkDetailTMCost.HasValue) row.CompleteWorkDetailTMCost = (Decimal)completeWorkDetailTMCost; else row.SetCompleteWorkDetailTMCostNull();
            if (completeWorkInvoiceNumber != "") row.CompleteWorkInvoiceNumber = completeWorkInvoiceNumber; else row.IsCompleteWorkInvoiceNumberNull();
            if (completeWorkInvoiceAmount.HasValue) row.CompleteWorkInvoiceAmount = (decimal)completeWorkInvoiceAmount; else row.IsCompleteWorkInvoiceAmountNull();
            if (startWorkMileage != "") row.StartWorkMileage = startWorkMileage; else row.SetStartWorkMileageNull();            
            if (completeWorkMileage != "") row.CompleteWorkMileage = completeWorkMileage; else row.SetCompleteWorkMileageNull();
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;

            if (libraryCategoriesId.HasValue) row.LIBRARY_CATEGORIES_ID = libraryCategoriesId.Value; else row.SetLIBRARY_CATEGORIES_IDNull();

            if (row.Type == "Checklist")
            {
                if (serviceState == "Completed")
                {
                    RuleGateway ruleGateway = new RuleGateway();
                    ruleGateway.LoadAllByRuleId(row.RuleID, row.COMPANY_ID);

                    DateTime? lastService = (DateTime)unitBackInServiceDate;
                    DateTime? nextDue = null;

                    string frecuency = ruleGateway.GetFrequency(row.RuleID);

                    if (!ruleGateway.GetMto(row.RuleID))
                    {
                        if (frecuency != "Only once")
                        {
                            // Get next due
                            DateTime timeToAdded = new DateTime(((DateTime)lastService).Year, ((DateTime)lastService).Month, ((DateTime)lastService).Day);

                            if (frecuency == "Monthly") nextDue = timeToAdded.AddMonths(1);
                            if (frecuency == "Every 2 months") nextDue = timeToAdded.AddMonths(2);
                            if (frecuency == "Every 3 months") nextDue = timeToAdded.AddMonths(3);
                            if (frecuency == "Every 4 months") nextDue = timeToAdded.AddMonths(4);
                            if (frecuency == "Every 6 months") nextDue = timeToAdded.AddMonths(6);
                            if (frecuency == "Yearly") nextDue = timeToAdded.AddYears(1);

                            row.AssociatedChecklistLastService = (DateTime)lastService;
                            row.AssociatedChecklistNextDue = (DateTime)nextDue;
                            row.AssociatedChecklistDone = false;
                            if (newAssociatedChecklistRuleState != "") row.AssociatedChecklistRuleState = newAssociatedChecklistRuleState; else row.SetAssociatedChecklistRuleStateNull();
                        }
                        else
                        {
                            row.AssociatedChecklistLastService = (DateTime)lastService;
                            row.SetAssociatedChecklistNextDueNull();
                            row.AssociatedChecklistDone = true;
                            if (newAssociatedChecklistRuleState != "") row.AssociatedChecklistRuleState = newAssociatedChecklistRuleState; else row.SetAssociatedChecklistRuleStateNull();
                        }
                    }
                    else
                    {
                        ServiceInformationBasicInformation serviceInformationBasicInformation = new ServiceInformationBasicInformation();
                        serviceInformationBasicInformation.LoadInProgressByServiceIdUnitIdRuleId(row.ServiceID, row.UnitID, row.RuleID, row.COMPANY_ID);

                        if (serviceInformationBasicInformation.Table.Rows.Count > 1)
                        {
                            row.AssociatedChecklistRuleState = "In Progress";
                        }
                        else
                        {
                            row.AssociatedChecklistRuleState = newAssociatedChecklistRuleState;
                        }

                        if (frecuency != "Only once")
                        {
                            row.AssociatedChecklistDone = false;
                        }
                        else
                        {
                            row.AssociatedChecklistDone = true;
                        }
                    }
                }        
            }
        }



        /// <summary>
        /// Save services
        /// </summary>        
        /// <param name="companyId">companyId</param>
        public void Save(int companyId)
        {
            ServiceRequestsManagerToolTDS serviceRequestsManagerToolChanges = (ServiceRequestsManagerToolTDS)Data.GetChanges();

            if (serviceRequestsManagerToolChanges.BasicInformation.Rows.Count > 0)
            {
                ServiceRequestsManagerToolBasicInformationGateway srManagerToolBasicInformationGateway = new ServiceRequestsManagerToolBasicInformationGateway(serviceRequestsManagerToolChanges);

                foreach (ServiceRequestsManagerToolTDS.BasicInformationRow row in (ServiceRequestsManagerToolTDS.BasicInformationDataTable)serviceRequestsManagerToolChanges.BasicInformation)
                {                  
                    // Unchanged values
                    int serviceId = row.ServiceID;
                    string type = srManagerToolBasicInformationGateway.GetTypeOriginal(serviceId);
                    string serviceNumber = srManagerToolBasicInformationGateway.GetServiceNumberOriginal(serviceId);
                    DateTime dateTime_ = srManagerToolBasicInformationGateway.GetDateTime_Original(serviceId);
                    int? unitID = srManagerToolBasicInformationGateway.GetUnitIdOriginal(serviceId);                    
                    int ownerId = srManagerToolBasicInformationGateway.GetOwnerIdOriginal(serviceId);
                    string serviceDescription = srManagerToolBasicInformationGateway.GetServiceDescriptionOriginal(serviceId);
                    DateTime? rejectDateTime = srManagerToolBasicInformationGateway.GetRejectDateTimeOriginal(serviceId);
                    string rejectReason = srManagerToolBasicInformationGateway.GetRejectReasonOriginal(serviceId);
                    string notes = srManagerToolBasicInformationGateway.GetNotesOriginal(serviceId);
                    int? ruleId = srManagerToolBasicInformationGateway.GetRuleIdOriginal(serviceId);
                    bool deleted = srManagerToolBasicInformationGateway.GetDeletedOriginal(serviceId);
                    bool mto = srManagerToolBasicInformationGateway.GetMtoOriginal(serviceId);

                    // Original values
                    string originalState = srManagerToolBasicInformationGateway.GetServiceStateOriginal(serviceId);
                    DateTime? originalDateTime_ = srManagerToolBasicInformationGateway.GetAssignmentDateTimeOriginal(serviceId);
                    DateTime? originalAssignmentDeadlineDate = srManagerToolBasicInformationGateway.GetAssignedDeadlineDateOriginal(serviceId);
                    bool originalAssignTeamMember = srManagerToolBasicInformationGateway.GetAssignTeamMemberOriginal(serviceId);
                    int? originalAssignTeamMemberId = srManagerToolBasicInformationGateway.GetAssignTeamMemberIdOriginal(serviceId);
                    string originalAssignThirdPartyVendor = srManagerToolBasicInformationGateway.GetAssignedThirdPartyVendorOriginal(serviceId);
                    DateTime? originalAcceptDatetime = srManagerToolBasicInformationGateway.GetAcceptedDateTimeOriginal(serviceId);
                    DateTime? originalStartWorkDateTime = srManagerToolBasicInformationGateway.GetStartWorkDateTimeOriginal(serviceId);
                    DateTime? originalUnitOutOfServiceDate = srManagerToolBasicInformationGateway.GetUnitOutOfServiceDateOriginal(serviceId);
                    string originalUnitOutOfServiceTime = srManagerToolBasicInformationGateway.GetUnitOutOfServiceTimeOriginal(serviceId);
                    DateTime? originalCompleteWorkDateTime = srManagerToolBasicInformationGateway.GetCompleteWorkDateTimeOriginal(serviceId);
                    DateTime? originalUnitBackInServiceDate = srManagerToolBasicInformationGateway.GetUnitBackInServiceDateOriginal(serviceId);
                    string originalUnitBackInServiceTime = srManagerToolBasicInformationGateway.GetUnitBackInServiceTimeOriginal(serviceId);
                    string originalCompleteWorkDetailDescription = srManagerToolBasicInformationGateway.GetCompleteWorkDetailDescriptionOriginal(serviceId);
                    bool originalCompleteWorkDetailPreventable = srManagerToolBasicInformationGateway.GetCompleteWorkDetailPreventableOriginal(serviceId);
                    Decimal? originalCompleteWorkDetailTMLabourHours = srManagerToolBasicInformationGateway.GetCompleteWorkDetailTMLabourHoursOriginal(serviceId);
                    Decimal? originalCompleteWorkDetailTMCost = srManagerToolBasicInformationGateway.GetCompleteWorkDetailTMCostOriginal(serviceId);
                    string originalCompleteWorkDetailTPVInvoiceNumber = srManagerToolBasicInformationGateway.GetCompleteWorkDetailTPVInvoiceNumberOriginal(serviceId);
                    Decimal? originalCompleteWorkDetailTPVInvoiceAmount = srManagerToolBasicInformationGateway.GetCompleteWorkDetailTPVInvoiceAmoutOriginal(serviceId);
                    string originalMileage = srManagerToolBasicInformationGateway.GetMileageOriginal(serviceId);
                    string originalStartWorkMileage = srManagerToolBasicInformationGateway.GetStartWorkMileageOriginal(serviceId);
                    string originalCompleteWorkMileage = srManagerToolBasicInformationGateway.GetCompleteWorkMileageOriginal(serviceId);
                    int? originalLibraryCategoriesId = null; if (srManagerToolBasicInformationGateway.GetLibraryCategoriesIdOriginal(serviceId).HasValue) originalLibraryCategoriesId = srManagerToolBasicInformationGateway.GetLibraryCategoriesIdOriginal(serviceId).Value;
                    
                    // New values
                    string newState = srManagerToolBasicInformationGateway.GetServiceState(serviceId);
                    DateTime? newDateTime_ = srManagerToolBasicInformationGateway.GetAssignmentDateTime(serviceId);
                    DateTime? newAssignmentDeadlineDate = srManagerToolBasicInformationGateway.GetAssignedDeadlineDate(serviceId);
                    bool newAssignTeamMember = srManagerToolBasicInformationGateway.GetAssignTeamMember(serviceId);
                    int? newAssignTeamMemberId = srManagerToolBasicInformationGateway.GetAssignTeamMemberId(serviceId);
                    string newAssignThirdPartyVendor = srManagerToolBasicInformationGateway.GetAssignedThirdPartyVendor(serviceId);
                    DateTime? newAcceptDatetime = srManagerToolBasicInformationGateway.GetAcceptedDateTime(serviceId);
                    DateTime? newStartWorkDateTime = srManagerToolBasicInformationGateway.GetStartWorkDateTime(serviceId);
                    DateTime? newUnitOutOfServiceDate = srManagerToolBasicInformationGateway.GetUnitOutOfServiceDate(serviceId);
                    string newUnitOutOfServiceTime = srManagerToolBasicInformationGateway.GetUnitOutOfServiceTime(serviceId);
                    DateTime? newCompleteWorkDateTime = srManagerToolBasicInformationGateway.GetCompleteWorkDateTime(serviceId);
                    DateTime? newUnitBackInServiceDate = srManagerToolBasicInformationGateway.GetUnitBackInServiceDate(serviceId);
                    string newUnitBackInServiceTime = srManagerToolBasicInformationGateway.GetUnitBackInServiceTime(serviceId);
                    string newCompleteWorkDetailDescription = srManagerToolBasicInformationGateway.GetCompleteWorkDetailDescription(serviceId);
                    bool newCompleteWorkDetailPreventable = srManagerToolBasicInformationGateway.GetCompleteWorkDetailPreventable(serviceId);
                    Decimal? newCompleteWorkDetailTMLabourHours = srManagerToolBasicInformationGateway.GetCompleteWorkDetailTMLabourHours(serviceId);
                    Decimal? newCompleteWorkDetailTMCost = srManagerToolBasicInformationGateway.GetCompleteWorkDetailTMCost(serviceId);
                    string newCompleteWorkDetailTPVInvoiceNumber = srManagerToolBasicInformationGateway.GetCompleteWorkDetailTPVInvoiceNumber(serviceId);
                    Decimal? newCompleteWorkDetailTPVInvoiceAmount = srManagerToolBasicInformationGateway.GetCompleteWorkDetailTPVInvoiceAmout(serviceId);
                    string newMileage = srManagerToolBasicInformationGateway.GetMileage(serviceId);
                    string newStartWorkMileage = srManagerToolBasicInformationGateway.GetStartWorkMileage(serviceId);
                    string newCompleteWorkMileage = srManagerToolBasicInformationGateway.GetCompleteWorkMileage(serviceId);
                    int? newLibraryCategoriesId = null; if (srManagerToolBasicInformationGateway.GetLibraryCategoriesId(serviceId).HasValue) newLibraryCategoriesId = srManagerToolBasicInformationGateway.GetLibraryCategoriesId(serviceId).Value;

                    Services services = new Services(null);
                    services.UpdateDirect(serviceId, serviceNumber, dateTime_, mto, serviceDescription, unitID, type, originalState, ownerId, originalDateTime_, originalAssignmentDeadlineDate, originalAssignTeamMember, originalAssignTeamMemberId, originalAssignThirdPartyVendor, originalAcceptDatetime, rejectDateTime, rejectReason, originalStartWorkDateTime, originalUnitOutOfServiceDate, originalUnitOutOfServiceTime, originalCompleteWorkDateTime, originalUnitBackInServiceDate, originalUnitBackInServiceTime, originalCompleteWorkDetailDescription, originalCompleteWorkDetailPreventable, originalCompleteWorkDetailTMLabourHours, originalCompleteWorkDetailTMCost, originalCompleteWorkDetailTPVInvoiceNumber, originalCompleteWorkDetailTPVInvoiceAmount, deleted, companyId, notes, ruleId, originalMileage, originalStartWorkMileage, originalCompleteWorkMileage, originalLibraryCategoriesId, serviceNumber, dateTime_, mto, serviceDescription, unitID, type, newState, ownerId, newDateTime_, newAssignmentDeadlineDate, newAssignTeamMember, newAssignTeamMemberId, newAssignThirdPartyVendor, newAcceptDatetime, rejectDateTime, rejectReason, newStartWorkDateTime, newUnitOutOfServiceDate, newUnitOutOfServiceTime, newCompleteWorkDateTime, newUnitBackInServiceDate, newUnitBackInServiceTime, newCompleteWorkDetailDescription, newCompleteWorkDetailPreventable, newCompleteWorkDetailTMLabourHours, newCompleteWorkDetailTMCost, newCompleteWorkDetailTPVInvoiceNumber, newCompleteWorkDetailTPVInvoiceAmount, deleted, companyId, notes, ruleId, newMileage, newStartWorkMileage, newCompleteWorkMileage, newLibraryCategoriesId);

                    if (unitID.HasValue)
                    {
                        if (newState == "In Progress")
                        {
                            LiquiForce.LFSLive.BL.FleetManagement.Units.Units units = new LiquiForce.LFSLive.BL.FleetManagement.Units.Units(null);
                            units.UpdateStateDirect((int)unitID, companyId, "Out Of Service");
                        }

                        if (newState == "Completed")
                        {
                            LiquiForce.LFSLive.BL.FleetManagement.Units.Units units = new LiquiForce.LFSLive.BL.FleetManagement.Units.Units(null);
                            units.UpdateStateDirect((int)unitID, companyId, "Active");
                        }
                    }

                    // Update checklist
                    if (type == "Checklist")
                    {
                        // ... Original values
                        DateTime? originalAssociatedChecklistLastService = srManagerToolBasicInformationGateway.GetAssociatedChecklistLastServiceOriginal(serviceId);
                        DateTime? originalAssociatedChecklistNextDue = srManagerToolBasicInformationGateway.GetAssociatedChecklistNextDueOriginal(serviceId);
                        bool originalAssociatedChecklistDone = srManagerToolBasicInformationGateway.GetAssociatedChecklistDoneOriginal(serviceId);
                        bool originalAssociatedChecklistDeleted = srManagerToolBasicInformationGateway.GetAssociatedChecklistDeletedOriginal(serviceId);
                        int originalAssociatedChecklistCompanyId = srManagerToolBasicInformationGateway.GetAssociatedChecklistCompanyIdOriginal(serviceId);
                        string originalAssociatedChecklistRuleState = srManagerToolBasicInformationGateway.GetAssociatedChecklistRuleStateOriginal(serviceId);

                        // ... New values
                        DateTime? newAssociatedChecklistLastService = srManagerToolBasicInformationGateway.GetAssociatedChecklistLastService(serviceId);
                        DateTime? newAssociatedChecklistNextDue = srManagerToolBasicInformationGateway.GetAssociatedChecklistNextDue(serviceId);
                        bool newAssociatedChecklistDone = srManagerToolBasicInformationGateway.GetAssociatedChecklistDone(serviceId);
                        bool newAssociatedChecklistDeleted = srManagerToolBasicInformationGateway.GetAssociatedChecklistDeleted(serviceId);
                        int newAssociatedChecklistCompanyId = srManagerToolBasicInformationGateway.GetAssociatedChecklistCompanyId(serviceId);
                        string newAssociatedChecklistRuleState = srManagerToolBasicInformationGateway.GetAssociatedChecklistRuleState(serviceId);

                        // ... Update
                        Checklist checklist = new Checklist();
                        checklist.UpdateDirect((int)unitID, (int)ruleId, originalAssociatedChecklistLastService, originalAssociatedChecklistNextDue, originalAssociatedChecklistDone, originalAssociatedChecklistRuleState, originalAssociatedChecklistDeleted, originalAssociatedChecklistCompanyId, (int)unitID, (int)ruleId, newAssociatedChecklistLastService, newAssociatedChecklistNextDue, newAssociatedChecklistDone, newAssociatedChecklistRuleState, originalAssociatedChecklistDeleted, originalAssociatedChecklistCompanyId);
                    }
                }
            }
        }



        /// <summary>
        /// UpdateLibraryCategoriesId
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <param name="libraryCategoriesId">libraryCategoriesId</param>
        public void UpdateLibraryCategoriesId(int serviceId, int? libraryCategoriesId)
        {
            ServiceRequestsManagerToolTDS.BasicInformationRow row = GetRow(serviceId);

            if (libraryCategoriesId.HasValue) row.LIBRARY_CATEGORIES_ID = (int)libraryCategoriesId; else row.SetLIBRARY_CATEGORIES_IDNull();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// Get a single section. If not exists, raise an exception
        /// </summary>
        /// <param name="serviceId">internal serviceId</param>
        /// <returns>Row</returns>
        private ServiceRequestsManagerToolTDS.BasicInformationRow GetRow(int serviceId)
        {
            ServiceRequestsManagerToolTDS.BasicInformationRow row = ((ServiceRequestsManagerToolTDS.BasicInformationDataTable)Table).FindByServiceID(serviceId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.FleetManagement.Services.ServiceRequestsManagerToolBasicInformation.GetRow");
            }

            return row;
        }

      

    }
}