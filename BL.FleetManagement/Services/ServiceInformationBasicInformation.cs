using System;
using System.Data;
using System.Collections;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Services;
using LiquiForce.LFSLive.DA.FleetManagement.Units;
using LiquiForce.LFSLive.BL.FleetManagement.ChecklistRules;
using LiquiForce.LFSLive.DA.FleetManagement.ChecklistRules;
using LiquiForce.LFSLive.BL.FleetManagement.Units;

namespace LiquiForce.LFSLive.BL.FleetManagement.Services
{
    /// <summary>
    /// ServiceInformationBasicInformation
    /// </summary>
    public class ServiceInformationBasicInformation : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ServiceInformationBasicInformation()
            : base("BasicInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ServiceInformationBasicInformation(DataSet data)
            : base(data, "BasicInformation")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ServiceInformationTDS();
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
            ServiceInformationBasicInformationGateway serviceInformationBasicInformationGateway = new ServiceInformationBasicInformationGateway(Data);
            serviceInformationBasicInformationGateway.LoadByServiceId(serviceId, companyId);
        }



        /// <summary>
        /// LoadInProgressByRuleId
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <param name="companyId">companyId</param>
        public void LoadInProgressByRuleId(int ruleId, int companyId)
        {
            ServiceInformationBasicInformationGateway serviceInformationBasicInformationGateway = new ServiceInformationBasicInformationGateway(Data);
            serviceInformationBasicInformationGateway.LoadInProgressByRuleId(ruleId, companyId);
        }



        /// <summary>
        /// LoadInProgressByUnitId
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="companyId">companyId</param>
        public void LoadInProgressByUnitId(int unitId, int companyId)
        {
            ServiceInformationBasicInformationGateway serviceInformationBasicInformationGateway = new ServiceInformationBasicInformationGateway(Data);
            serviceInformationBasicInformationGateway.LoadInProgressByUnitId(unitId, companyId);
        }


        
        /// <summary>
        /// LoadInProgressByUnitIdRuleId
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="ruleId">ruleId</param>
        /// <param name="companyId">companyId</param>
        public void LoadInProgressByUnitIdRuleId(int unitId, int ruleId, int companyId)
        {
            ServiceInformationBasicInformationGateway serviceInformationBasicInformationGateway = new ServiceInformationBasicInformationGateway(Data);
            serviceInformationBasicInformationGateway.LoadInProgressByUnitIdRuleId(unitId, ruleId, companyId);
        }



        /// <summary>
        /// LoadInProgressByServiceIdUnitIdRuleId
        /// </summary>
        /// <param name="serviceId">serviceId</param>              
        /// <param name="companyId">companyId</param>
        public void LoadInProgressByServiceIdUnitIdRuleId(int serviceId, int unitId, int ruleId, int companyId)
        {
            ServiceInformationBasicInformationGateway serviceInformationBasicInformationGateway = new ServiceInformationBasicInformationGateway(Data);
            serviceInformationBasicInformationGateway.LoadInProgressByServiceIdUnitIdRuleId(serviceId, unitId, ruleId, companyId);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <param name="serviceState">serviceState</param>
        /// <param name="mtoDto">mtoDto</param>
        /// <param name="serviceDescription">serviceDescription</param>
        /// <param name="mileage">mileage</param>
        /// <param name="assignmentDateTime">assignmentDateTime</param>
        /// <param name="assignmentDeadlineDate"></param>
        /// <param name="toTeamMember">toTeamMember</param>
        /// <param name="assignTeamMemberID">assignTeamMemberID</param>
        /// <param name="thirdPartyVendor">thirdPartyVendor</param>
        /// <param name="assignmentAcceptedDateTime">assignmentAcceptedDateTime</param>
        /// <param name="assignmentRejectedDateTime">assignmentRejectedDateTime</param>
        /// <param name="assignmentRejectedReason">assignmentRejectedReason</param>
        /// <param name="startWorkDateTime">startWorkDateTime</param>
        /// <param name="unitOutOfServiceDate">unitOutOfServiceDate</param>
        /// <param name="unitOutOfServiceTime">unitOutOfServiceTime</param>
        /// <param name="startWorkMileage">startWorkMileage</param>
        /// <param name="completeWorkDateTime">completeWorkDateTime</param>
        /// <param name="unitBackInServiceDate">unitBackInServiceDate</param>
        /// <param name="unitBackInServiceTime">unitBackInServiceTime</param>
        /// <param name="completeWorkMileage">completeWorkMileage</param>
        /// <param name="completeWorkDetailDescription">completeWorkDetailDescription</param>
        /// <param name="completeWorkDetailPreventable">completeWorkDetailPreventable</param>
        /// <param name="completeWorkDetailTMLabourHours">completeWorkDetailTMLabourHours</param>
        /// <param name="completeWorkDetailTPVInvoiceNumber">completeWorkDetailTPVInvoiceNumber</param>
        /// <param name="completeWorkDetailTPVInvoiceAmout">completeWorkDetailTPVInvoiceAmout</param>
        /// <param name="newAssociatedChecklistRuleState">newAssociatedChecklistRuleState</param>
        /// <param name="libraryCategoriesId">libraryCategoriesId</param>
        public void Update(int serviceId, string serviceState, bool mtoDto, string serviceDescription, string mileage, DateTime? assignmentDateTime, DateTime? assignmentDeadlineDate, bool toTeamMember, int? assignTeamMemberID, string thirdPartyVendor, DateTime? assignmentAcceptedDateTime, DateTime? assignmentRejectedDateTime, string assignmentRejectedReason, DateTime? startWorkDateTime, DateTime? unitOutOfServiceDate, string unitOutOfServiceTime, string startWorkMileage, DateTime? completeWorkDateTime, DateTime? unitBackInServiceDate, string unitBackInServiceTime, string completeWorkMileage, string completeWorkDetailDescription, bool completeWorkDetailPreventable, decimal? completeWorkDetailTMLabourHours, string completeWorkDetailTPVInvoiceNumber, decimal? completeWorkDetailTPVInvoiceAmout, string newAssociatedChecklistRuleState, int? libraryCategoriesId)
        {
            ServiceInformationTDS.BasicInformationRow row = GetRow(serviceId);
 
            // General Data
            string originalServiceState = row.ServiceState;
            DateTime? originalUnitBackInServiceDate = null; if (!row.IsUnitBackInServiceDateNull()) originalUnitBackInServiceDate = row.UnitBackInServiceDate;
            row.ServiceState = serviceState;
            row.MtoDto = mtoDto;
            if (serviceDescription.Trim() != "") row.ServiceDescription = serviceDescription; else row.SetServiceDescriptionNull();
            if (mileage.Trim() != "") row.Mileage = mileage; else row.SetMileageNull();
            if (assignmentDateTime.HasValue) row.AssignmentDateTime = (DateTime)assignmentDateTime; else row.SetAssignmentDateTimeNull();
            if (assignmentDeadlineDate.HasValue) row.AssignedDeadlineDate = (DateTime)assignmentDeadlineDate;
            row.ToTeamMember = toTeamMember;
            if (assignTeamMemberID.HasValue) row.AssignTeamMemberID = (int)assignTeamMemberID; else row.SetAssignTeamMemberIDNull();
            if (thirdPartyVendor != "") row.AssignedThirdPartyVendor = thirdPartyVendor; else row.SetAssignedThirdPartyVendorNull();
            if (assignmentAcceptedDateTime.HasValue) row.AcceptedDateTime = (DateTime)assignmentAcceptedDateTime; else row.SetAcceptedDateTimeNull();
            if (assignmentRejectedDateTime.HasValue) row.RejectedDateTime = (DateTime)assignmentRejectedDateTime; else row.SetRejectedDateTimeNull();
            if (assignmentRejectedReason != "") row.RejectedReason = assignmentRejectedReason; else row.SetRejectedReasonNull();
            if (startWorkDateTime.HasValue) row.StartWorkDateTime = (DateTime)startWorkDateTime; else row.SetStartWorkDateTimeNull();
            if (unitOutOfServiceDate.HasValue) row.UnitOutOfServiceDate = (DateTime)unitOutOfServiceDate; else row.SetUnitOutOfServiceDateNull();
            if (unitOutOfServiceTime != "") row.UnitOutOfServiceTime = unitOutOfServiceTime; else row.SetUnitOutOfServiceTimeNull();
            if (startWorkMileage != "") row.StartWorkMileage = startWorkMileage; else row.SetStartWorkMileageNull();
            if (completeWorkDateTime.HasValue) row.CompleteWorkDateTime = (DateTime)completeWorkDateTime; else row.SetCompleteWorkDateTimeNull();
            if (unitBackInServiceDate.HasValue) row.UnitBackInServiceDate = (DateTime)unitBackInServiceDate; else row.SetUnitBackInServiceDateNull();
            if (unitBackInServiceTime != "") row.UnitBackInServiceTime = unitBackInServiceTime; else row.SetUnitBackInServiceTimeNull();
            if (completeWorkMileage != "") row.CompleteWorkMileage = completeWorkMileage; else row.SetCompleteWorkMileageNull();
            if (completeWorkDetailDescription != "") row.CompleteWorkDetailDescription = completeWorkDetailDescription; else row.SetCompleteWorkDetailDescriptionNull();
            row.CompleteWorkDetailPreventable = completeWorkDetailPreventable;
            if (completeWorkDetailTMLabourHours.HasValue) row.CompleteWorkDetailTMLabourHours = (Decimal)completeWorkDetailTMLabourHours; else row.SetCompleteWorkDetailTMLabourHoursNull();
            if (completeWorkDetailTPVInvoiceNumber != "") row.CompleteWorkDetailTPVInvoiceNumber = completeWorkDetailTPVInvoiceNumber; else row.SetCompleteWorkDetailTPVInvoiceNumberNull();
            if (completeWorkDetailTPVInvoiceAmout.HasValue) row.CompleteWorkDetailTPVInvoiceAmout = (Decimal)completeWorkDetailTPVInvoiceAmout; else row.SetCompleteWorkDetailTPVInvoiceAmoutNull();
            if (libraryCategoriesId.HasValue) row.LIBRARY_CATEGORIES_ID = libraryCategoriesId.Value; else row.SetLIBRARY_CATEGORIES_IDNull();

            if (row.Type == "Checklist")
            {
                if ((originalServiceState != "Completed") && (serviceState == "Completed"))
                {
                    RuleGateway ruleGateway = new RuleGateway();
                    ruleGateway.LoadAllByRuleId(row.RuleID, row.COMPANY_ID);

                    DateTime? lastService = (DateTime)unitBackInServiceDate;
                    DateTime? nextDue = null;

                    string frecuency = ruleGateway.GetFrequency(row.RuleID);

                    if (!ruleGateway.GetMto(row.RuleID))
                    {
                        if (ruleGateway.GetFrequency(row.RuleID) != "Only once")
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
                else
                {
                    if ((originalServiceState == "Completed") && (originalUnitBackInServiceDate != unitBackInServiceDate))
                    {
                        RuleGateway ruleGateway = new RuleGateway();
                        ruleGateway.LoadAllByRuleId(row.RuleID, row.COMPANY_ID);

                        DateTime? lastService = (DateTime)unitBackInServiceDate;
                        DateTime? nextDue = null;

                        string frecuency = ruleGateway.GetFrequency(row.RuleID);

                        if (!ruleGateway.GetMto(row.RuleID))
                        {
                            if (ruleGateway.GetFrequency(row.RuleID) != "Only once")
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
        }



        /// <summary>
        /// UpdateLibraryCategoriesId
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <param name="libraryCategoriesId">libraryCategoriesId</param>
        public void UpdateLibraryCategoriesId(int serviceId, int? libraryCategoriesId)
        {
            ServiceInformationTDS.BasicInformationRow row = GetRow(serviceId);

            if (libraryCategoriesId.HasValue) row.LIBRARY_CATEGORIES_ID = (int)libraryCategoriesId; else row.SetLIBRARY_CATEGORIES_IDNull();
        }



        /// <summary>
        /// Save
        /// </summary>
        /// <param name="companyId">companyId</param>
        public void Save(int companyId)
        {
            ServiceInformationTDS servicesInformationChanges = (ServiceInformationTDS)Data.GetChanges();

            if (servicesInformationChanges.BasicInformation.Rows.Count > 0)
            {
                ServiceInformationBasicInformationGateway serviceInformationBasicInformationGateway = new ServiceInformationBasicInformationGateway(servicesInformationChanges);

                // Update services
                foreach (ServiceInformationTDS.BasicInformationRow basicInformationRow in (ServiceInformationTDS.BasicInformationDataTable)servicesInformationChanges.BasicInformation)
                {
                    // Unchanged values
                    int serviceId = basicInformationRow.ServiceID;
                    string number = serviceInformationBasicInformationGateway.GetServiceNumber(serviceId);
                    DateTime dateTime_ = serviceInformationBasicInformationGateway.GetDateTime_(serviceId);
                    int? unitId = null; if (serviceInformationBasicInformationGateway.GetUnitID(serviceId).HasValue) unitId = serviceInformationBasicInformationGateway.GetUnitID(serviceId);
                    string type = serviceInformationBasicInformationGateway.GetType(serviceId);
                    int ownerId = serviceInformationBasicInformationGateway.GetOwnerID(serviceId);

                    // Original values
                    bool originalMtoDto = serviceInformationBasicInformationGateway.GetMtoDtoOriginal(serviceId);
                    string originalDescription = serviceInformationBasicInformationGateway.GetServiceDescriptionOriginal(serviceId);
                    string originalState = serviceInformationBasicInformationGateway.GetServiceStateOriginal(serviceId);
                    DateTime? originalAssignDateTime = null; if (serviceInformationBasicInformationGateway.GetAssignmentDateTimeOriginal(serviceId).HasValue) originalAssignDateTime = (DateTime)serviceInformationBasicInformationGateway.GetAssignmentDateTimeOriginal(serviceId);
                    DateTime? originalAssignDeadlineDate = null; if (serviceInformationBasicInformationGateway.GetAssignedDeadlineDateOriginal(serviceId).HasValue) originalAssignDeadlineDate = (DateTime)serviceInformationBasicInformationGateway.GetAssignedDeadlineDateOriginal(serviceId);
                    bool originalAssignTeamMember = serviceInformationBasicInformationGateway.GetToTeamMemberOriginal(serviceId);
                    int? originalAssignTeamMemberID = null; if (serviceInformationBasicInformationGateway.GetAssignTeamMemberIdOriginal(serviceId).HasValue) originalAssignTeamMemberID = (int)serviceInformationBasicInformationGateway.GetAssignTeamMemberIdOriginal(serviceId);
                    string originalAssignThirdPartyVendor = serviceInformationBasicInformationGateway.GetAssignedThirdPartyVendorOriginal(serviceId);
                    DateTime? originalAcceptDateTime = null; if (serviceInformationBasicInformationGateway.GetAcceptedDateTimeOriginal(serviceId).HasValue) originalAcceptDateTime = (DateTime)serviceInformationBasicInformationGateway.GetAcceptedDateTimeOriginal(serviceId);
                    DateTime? originalRejectDateTime = null; if (serviceInformationBasicInformationGateway.GetRejectedDateTimeOriginal(serviceId).HasValue) originalRejectDateTime = (DateTime)serviceInformationBasicInformationGateway.GetRejectedDateTimeOriginal(serviceId);
                    string originalRejectReason = serviceInformationBasicInformationGateway.GetRejectedReasonOriginal(serviceId);
                    DateTime? originalStartWorkDateTime = null; if (serviceInformationBasicInformationGateway.GetStartWorkDateTimeOriginal(serviceId).HasValue) originalStartWorkDateTime = (DateTime)serviceInformationBasicInformationGateway.GetStartWorkDateTimeOriginal(serviceId);
                    DateTime? originalStartWorkOutOfServiceDate = null; if (serviceInformationBasicInformationGateway.GetUnitOutOfServiceDateOriginal(serviceId).HasValue) originalStartWorkOutOfServiceDate = (DateTime)serviceInformationBasicInformationGateway.GetUnitOutOfServiceDateOriginal(serviceId);
                    string originalStartWorkOutOfServiceTime = serviceInformationBasicInformationGateway.GetUnitOutOfServiceTimeOriginal(serviceId);
                    DateTime? originalCompleteWorkDateTime = null; if (serviceInformationBasicInformationGateway.GetCompleteWorkDateTimeOriginal(serviceId).HasValue) originalCompleteWorkDateTime = (DateTime)serviceInformationBasicInformationGateway.GetCompleteWorkDateTimeOriginal(serviceId);
                    DateTime? originalCompleteWorkBackToServiceDate = null; if (serviceInformationBasicInformationGateway.GetUnitBackInServiceDateOriginal(serviceId).HasValue) originalCompleteWorkBackToServiceDate = (DateTime)serviceInformationBasicInformationGateway.GetUnitBackInServiceDateOriginal(serviceId);
                    string originalCompleteWorkBackToServiceTime = serviceInformationBasicInformationGateway.GetUnitBackInServiceTimeOriginal(serviceId);
                    string originalCompleteWorkDetailDescription = serviceInformationBasicInformationGateway.GetCompleteWorkDetailDescriptionOriginal(serviceId);
                    bool originalCompleteWorkDetailPreventable = serviceInformationBasicInformationGateway.GetCompleteWorkDetailPreventableOriginal(serviceId);
                    decimal? originalCompleteWorkDetailTMLabourHours = null; if (serviceInformationBasicInformationGateway.GetCompleteWorkDetailTMLabourHoursOriginal(serviceId).HasValue) originalCompleteWorkDetailTMLabourHours = (decimal)serviceInformationBasicInformationGateway.GetCompleteWorkDetailTMLabourHoursOriginal(serviceId);
                    decimal? originalCompleteWorkDetailTMCost = null; if (serviceInformationBasicInformationGateway.GetCompleteWorkDetailTMCostOriginal(serviceId).HasValue) originalCompleteWorkDetailTMCost = (decimal)serviceInformationBasicInformationGateway.GetCompleteWorkDetailTMCostOriginal(serviceId);
                    string originalCompleteWorkDetailTPVInvoiceNumber = serviceInformationBasicInformationGateway.GetCompleteWorkDetailTPVInvoiceNumberOriginal(serviceId);
                    decimal? originalCompleteWorkDetailTPVInvoiceAmout = null; if (serviceInformationBasicInformationGateway.GetCompleteWorkDetailTPVInvoiceAmoutOriginal(serviceId).HasValue) originalCompleteWorkDetailTPVInvoiceAmout = (decimal)serviceInformationBasicInformationGateway.GetCompleteWorkDetailTPVInvoiceAmoutOriginal(serviceId);
                    string originalNotes = serviceInformationBasicInformationGateway.GetNotesOriginal(serviceId);
                    int? originalRuleId = null; if (serviceInformationBasicInformationGateway.GetRuleIdOriginal(serviceId).HasValue) originalRuleId = (int)serviceInformationBasicInformationGateway.GetRuleIdOriginal(serviceId);
                    string originalMileage = serviceInformationBasicInformationGateway.GetMileageOriginal(serviceId);
                    string originalStartWorkMileage = serviceInformationBasicInformationGateway.GetStartWorkMileageOriginal(serviceId);
                    string originalCompleteWorkMileage = serviceInformationBasicInformationGateway.GetCompleteWorkMileageOriginal(serviceId);
                    bool originalDeleted = serviceInformationBasicInformationGateway.GetDeletedOriginal(serviceId);
                    int? originalLibraryCategoriesId = null; if (serviceInformationBasicInformationGateway.GetLibraryCategoriesIdOriginal(serviceId).HasValue) originalLibraryCategoriesId = serviceInformationBasicInformationGateway.GetLibraryCategoriesIdOriginal(serviceId).Value;

                    // New variables
                    bool newMtoDto = serviceInformationBasicInformationGateway.GetMtoDto(serviceId);
                    string newDescription = serviceInformationBasicInformationGateway.GetServiceDescription(serviceId);
                    string newState = serviceInformationBasicInformationGateway.GetServiceState(serviceId);
                    DateTime? newAssignDateTime = null; if(serviceInformationBasicInformationGateway.GetAssignmentDateTime(serviceId).HasValue) newAssignDateTime = (DateTime)serviceInformationBasicInformationGateway.GetAssignmentDateTime(serviceId);
                    DateTime? newAssignDeadlineDate = null; if (serviceInformationBasicInformationGateway.GetAssignedDeadlineDate(serviceId).HasValue) newAssignDeadlineDate = (DateTime)serviceInformationBasicInformationGateway.GetAssignedDeadlineDate(serviceId);
                    bool newAssignTeamMember = serviceInformationBasicInformationGateway.GetToTeamMember(serviceId);
                    int? newAssignTeamMemberId = null; if (serviceInformationBasicInformationGateway.GetAssignTeamMemberId(serviceId).HasValue) newAssignTeamMemberId = (int)serviceInformationBasicInformationGateway.GetAssignTeamMemberId(serviceId);
                    string newAssignThirdPartyVendor = serviceInformationBasicInformationGateway.GetAssignedThirdPartyVendor(serviceId);
                    DateTime? newAcceptDateTime = null; if(serviceInformationBasicInformationGateway.GetAcceptedDateTime(serviceId).HasValue) newAcceptDateTime = (DateTime)serviceInformationBasicInformationGateway.GetAcceptedDateTime(serviceId);
                    DateTime? newRejectDateTime = null; if(serviceInformationBasicInformationGateway.GetRejectedDateTime(serviceId).HasValue) newRejectDateTime = (DateTime)serviceInformationBasicInformationGateway.GetRejectedDateTime(serviceId);
                    string newRejectReason = serviceInformationBasicInformationGateway.GetRejectedReason(serviceId);
                    DateTime? newStartWorkDateTime = null;  if( serviceInformationBasicInformationGateway.GetStartWorkDateTime(serviceId).HasValue) newStartWorkDateTime = (DateTime) serviceInformationBasicInformationGateway.GetStartWorkDateTime(serviceId);
                    DateTime? newStartWorkOutOfServiceDate = null; if (serviceInformationBasicInformationGateway.GetUnitOutOfServiceDate(serviceId).HasValue) newStartWorkOutOfServiceDate = (DateTime)serviceInformationBasicInformationGateway.GetUnitOutOfServiceDate(serviceId);
                    string newStartWorkOutOfServiceTime = serviceInformationBasicInformationGateway.GetUnitOutOfServiceTime(serviceId);
                    DateTime? newCompleteWorkDateTime = null; if (serviceInformationBasicInformationGateway.GetCompleteWorkDateTime(serviceId).HasValue) newCompleteWorkDateTime = (DateTime)serviceInformationBasicInformationGateway.GetCompleteWorkDateTime(serviceId);
                    DateTime? newCompleteWorkBackToServiceDate = null; if (serviceInformationBasicInformationGateway.GetUnitBackInServiceDate(serviceId).HasValue) newCompleteWorkBackToServiceDate = (DateTime)serviceInformationBasicInformationGateway.GetUnitBackInServiceDate(serviceId);
                    string newCompleteWorkBackToServiceTime = serviceInformationBasicInformationGateway.GetUnitBackInServiceTime(serviceId);
                    string newCompleteWorkDetailDescription = serviceInformationBasicInformationGateway.GetCompleteWorkDetailDescription(serviceId);
                    bool newCompleteWorkDetailPreventable = serviceInformationBasicInformationGateway.GetCompleteWorkDetailPreventable(serviceId);
                    decimal? newCompleteWorkDetailTMLabourHours = null; if (serviceInformationBasicInformationGateway.GetCompleteWorkDetailTMLabourHours(serviceId).HasValue) newCompleteWorkDetailTMLabourHours = (decimal)serviceInformationBasicInformationGateway.GetCompleteWorkDetailTMLabourHours(serviceId);
                    decimal? newCompleteWorkDetailTMCost = null; if (serviceInformationBasicInformationGateway.GetCompleteWorkDetailTMCost(serviceId).HasValue) newCompleteWorkDetailTMCost = (decimal)serviceInformationBasicInformationGateway.GetCompleteWorkDetailTMCost(serviceId);
                    string newCompleteWorkDetailTPVInvoiceNumber = serviceInformationBasicInformationGateway.GetCompleteWorkDetailTPVInvoiceNumber(serviceId);
                    decimal? newCompleteWorkDetailTPVInvoiceAmout = null; if (serviceInformationBasicInformationGateway.GetCompleteWorkDetailTPVInvoiceAmout(serviceId).HasValue) newCompleteWorkDetailTPVInvoiceAmout = (decimal)serviceInformationBasicInformationGateway.GetCompleteWorkDetailTPVInvoiceAmout(serviceId);
                    string newNotes = serviceInformationBasicInformationGateway.GetNotes(serviceId);
                    int? newRuleId = null; if (serviceInformationBasicInformationGateway.GetRuleId(serviceId).HasValue) newRuleId = (int)serviceInformationBasicInformationGateway.GetRuleId(serviceId);
                    string newMileage = serviceInformationBasicInformationGateway.GetMileage(serviceId);
                    string newStartWorkMileage = serviceInformationBasicInformationGateway.GetStartWorkMileage(serviceId);
                    string newCompleteWorkMileage = serviceInformationBasicInformationGateway.GetCompleteWorkMileage(serviceId);
                    int? newLibraryCategoriesId = null; if (serviceInformationBasicInformationGateway.GetLibraryCategoriesId(serviceId).HasValue) newLibraryCategoriesId = serviceInformationBasicInformationGateway.GetLibraryCategoriesId(serviceId).Value;
                    bool newDeleted = serviceInformationBasicInformationGateway.GetDeleted(serviceId);

                    // ... Update 
                    UpdateService(serviceId, number, dateTime_, originalMtoDto, originalDescription, unitId, type, originalState, ownerId, originalAssignDateTime, originalAssignDeadlineDate, originalAssignTeamMember, originalAssignTeamMemberID, originalAssignThirdPartyVendor, originalAcceptDateTime, originalRejectDateTime, originalRejectReason, originalStartWorkDateTime, originalStartWorkOutOfServiceDate, originalStartWorkOutOfServiceTime, originalCompleteWorkDateTime, originalCompleteWorkBackToServiceDate, originalCompleteWorkBackToServiceTime, originalCompleteWorkDetailDescription, originalCompleteWorkDetailPreventable, originalCompleteWorkDetailTMLabourHours, originalCompleteWorkDetailTMCost, originalCompleteWorkDetailTPVInvoiceNumber, originalCompleteWorkDetailTPVInvoiceAmout, originalDeleted, companyId, originalNotes, originalRuleId, originalMileage, originalStartWorkMileage, originalCompleteWorkMileage, originalLibraryCategoriesId, number, dateTime_, newMtoDto, newDescription, unitId, type, newState, ownerId, newAssignDateTime, newAssignDeadlineDate, newAssignTeamMember, newAssignTeamMemberId, newAssignThirdPartyVendor, newAcceptDateTime, newRejectDateTime, newRejectReason, newStartWorkDateTime, newStartWorkOutOfServiceDate, newStartWorkOutOfServiceTime, newCompleteWorkDateTime, newCompleteWorkBackToServiceDate, newCompleteWorkBackToServiceTime, newCompleteWorkDetailDescription, newCompleteWorkDetailPreventable, newCompleteWorkDetailTMLabourHours, newCompleteWorkDetailTMCost, newCompleteWorkDetailTPVInvoiceNumber, newCompleteWorkDetailTPVInvoiceAmout, newDeleted, companyId, newNotes, newRuleId, newMileage, newStartWorkMileage, newCompleteWorkMileage, newLibraryCategoriesId);
                                        
                    // Update checklist
                    if (type == "Checklist")
                    {
                        // ... Original values
                        DateTime? originalAssociatedChecklistLastService = serviceInformationBasicInformationGateway.GetAssociatedChecklistLastServiceOriginal(serviceId);
                        DateTime? originalAssociatedChecklistNextDue = serviceInformationBasicInformationGateway.GetAssociatedChecklistNextDueOriginal(serviceId);
                        bool originalAssociatedChecklistDone = serviceInformationBasicInformationGateway.GetAssociatedChecklistDoneOriginal(serviceId);
                        bool originalAssociatedChecklistDeleted = serviceInformationBasicInformationGateway.GetAssociatedChecklistDeletedOriginal(serviceId);
                        int originalAssociatedChecklistCompanyId = serviceInformationBasicInformationGateway.GetAssociatedChecklistCompanyIdOriginal(serviceId);
                        string originalAssociatedChecklistRuleState = serviceInformationBasicInformationGateway.GetAssociatedChecklistRuleStateOriginal(serviceId);

                        // ... New values
                        DateTime? newAssociatedChecklistLastService = serviceInformationBasicInformationGateway.GetAssociatedChecklistLastService(serviceId);
                        DateTime? newAssociatedChecklistNextDue = serviceInformationBasicInformationGateway.GetAssociatedChecklistNextDue(serviceId);
                        bool newAssociatedChecklistDone = serviceInformationBasicInformationGateway.GetAssociatedChecklistDone(serviceId);
                        bool newAssociatedChecklistDeleted = serviceInformationBasicInformationGateway.GetAssociatedChecklistDeleted(serviceId);
                        int newAssociatedChecklistCompanyId = serviceInformationBasicInformationGateway.GetAssociatedChecklistCompanyId(serviceId);
                        string newAssociatedChecklistRuleState = serviceInformationBasicInformationGateway.GetAssociatedChecklistRuleState(serviceId);
                        
                        // ... Update
                        Checklist checklist = new Checklist();
                        checklist.UpdateDirect((int)unitId, (int)originalRuleId, originalAssociatedChecklistLastService, originalAssociatedChecklistNextDue, originalAssociatedChecklistDone, originalAssociatedChecklistRuleState, originalAssociatedChecklistDeleted, originalAssociatedChecklistCompanyId, (int)unitId, (int)originalRuleId, newAssociatedChecklistLastService, newAssociatedChecklistNextDue, newAssociatedChecklistDone, newAssociatedChecklistRuleState, originalAssociatedChecklistDeleted, originalAssociatedChecklistCompanyId);
                    }
                }
            }
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        public void Delete(int serviceId)
        {
            ServiceInformationTDS.BasicInformationRow row = GetRow(serviceId);
            row.Deleted = true;
        }



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <param name="unitType">unitType</param>
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(int serviceId, string unitType, int unitId, int companyId)
        {
            // Delete service
            Services services = new Services(null);
            services.DeleteDirect(serviceId, unitType, companyId);

            UpdateUnitState(unitId, "Active", companyId);
        }





                
        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// UpdateService
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
        /// <param name="originalRuleId">originalRuleId</param>
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
        /// <param name="newRuleId">newRuleId</param>
        /// <param name="newMileage">newMileage</param> 
        /// <param name="newStartWorkMileage">newStartWorkMileage</param>
        /// <param name="newCompleteWorkMileage">newCompleteWorkMileage</param>
        /// <param name="newLibraryCategoriesId">newLibraryCategoriesId</param>
        private void UpdateService(int serviceId, string originalNumber, DateTime originalDateTime, bool originalMtoDto, string originalDescription, int? originalUnitId, string originalType, string originalState, int originalOwnerId, DateTime? originalAssignDateTime, DateTime? originalAssignDeadlineDate, bool originalAssignTeamMember, int? originalAssignTeamMemberID, string originalAssignThirdPartyVendor, DateTime? originalAcceptDateTime, DateTime? originalRejectDateTime, string originalRejectReason, DateTime? originalStartWorkDateTime, DateTime? originalStartWorkOutOfServiceDate, string originalStartWorkOutOfServiceTime, DateTime? originalCompleteWorkDateTime, DateTime? originalCompleteWorkBackToServiceDate, string originalCompleteWorkBackToServiceTime, string originalCompleteWorkDetailDescription, bool originalCompleteWorkDetailPreventable, decimal? originalCompleteWorkDetailTMLabourHours, decimal? originalCompleteWorkDetailTMCost, string originalCompleteWorkDetailTPVInvoiceNumber, decimal? originalCompleteWorkDetailTPVInvoiceAmout, bool originalDeleted, int originalCompanyId, string originalNotes, int? originalRuleId, string originalMileage, string originalStartWorkMileage, string originalCompleteWorkMileage, int? originalLibraryCategoriesId, string newNumber, DateTime? newDateTime, bool newMtoDto, string newDescription, int? newUnitId, string newType, string newState, int newOwnerId, DateTime? newAssignDateTime, DateTime? newAssignDeadlineDate, bool newAssignTeamMember, int? newAssignTeamMemberID, string newAssignThirdPartyVendor, DateTime? newAcceptDateTime, DateTime? newRejectDateTime, string newRejectReason, DateTime? newStartWorkDateTime, DateTime? newStartWorkOutOfServiceDate, string newStartWorkOutOfServiceTime, DateTime? newCompleteWorkDateTime, DateTime? newCompleteWorkBackToServiceDate, string newCompleteWorkBackToServiceTime, string newCompleteWorkDetailDescription, bool newCompleteWorkDetailPreventable, decimal? newCompleteWorkDetailTMLabourHours, decimal? newCompleteWorkDetailTMCost, string newCompleteWorkDetailTPVInvoiceNumber, decimal? newCompleteWorkDetailTPVInvoiceAmout, bool newDeleted, int newCompanyId, string newNotes, int? newRuleId, string newMileage, string newStartWorkMileage, string newCompleteWorkMileage, int? newLibraryCategoriesId)
        {
            Services services = new Services(null);
            services.UpdateDirect(serviceId, originalNumber, originalDateTime, originalMtoDto, originalDescription, originalUnitId, originalType, originalState, originalOwnerId, originalAssignDateTime, originalAssignDeadlineDate, originalAssignTeamMember, originalAssignTeamMemberID, originalAssignThirdPartyVendor, originalAcceptDateTime, originalRejectDateTime, originalRejectReason, originalStartWorkDateTime, originalStartWorkOutOfServiceDate, originalStartWorkOutOfServiceTime, originalCompleteWorkDateTime, originalCompleteWorkBackToServiceDate, originalCompleteWorkBackToServiceTime, originalCompleteWorkDetailDescription, originalCompleteWorkDetailPreventable, originalCompleteWorkDetailTMLabourHours, originalCompleteWorkDetailTMCost, originalCompleteWorkDetailTPVInvoiceNumber, originalCompleteWorkDetailTPVInvoiceAmout, originalDeleted, originalCompanyId, originalNotes, originalRuleId, originalMileage, originalStartWorkMileage, originalCompleteWorkMileage, originalLibraryCategoriesId, newNumber, newDateTime, newMtoDto, newDescription, newUnitId, newType, newState, newOwnerId, newAssignDateTime, newAssignDeadlineDate, newAssignTeamMember, newAssignTeamMemberID, newAssignThirdPartyVendor, newAcceptDateTime, newRejectDateTime, newRejectReason, newStartWorkDateTime, newStartWorkOutOfServiceDate, newStartWorkOutOfServiceTime, newCompleteWorkDateTime, newCompleteWorkBackToServiceDate, newCompleteWorkBackToServiceTime, newCompleteWorkDetailDescription, newCompleteWorkDetailPreventable, newCompleteWorkDetailTMLabourHours, newCompleteWorkDetailTMCost, newCompleteWorkDetailTPVInvoiceNumber, newCompleteWorkDetailTPVInvoiceAmout, newDeleted, newCompanyId, newNotes, newRuleId, newMileage, newStartWorkMileage, newCompleteWorkMileage, newLibraryCategoriesId);

            if (originalUnitId.HasValue)
            {
                if (newState == "In Progress")
                {
                    UpdateUnitState((int)originalUnitId, "Out Of Service", originalCompanyId);
                }

                if (newState == "Completed")
                {
                    UpdateUnitState((int)originalUnitId, "Active", originalCompanyId);
                }
            }
        }



        /// <summary>
        /// UpdateUnitState
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="state">state</param>
        /// <param name="companyId">companyId</param>
        private void UpdateUnitState(int unitId, string state, int companyId)
        {
            ServiceInformationBasicInformation serviceInformationBasicInformation = new ServiceInformationBasicInformation();
            serviceInformationBasicInformation.LoadInProgressByUnitId(unitId, companyId);

            if (serviceInformationBasicInformation.Table.Rows.Count == 0)
            {
                LiquiForce.LFSLive.BL.FleetManagement.Units.Units units = new LiquiForce.LFSLive.BL.FleetManagement.Units.Units(null);
                units.UpdateStateDirect(unitId, companyId, state);
            }
        }



        /// <summary>
        /// Get a single row. If not exists, raise an exception.
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>Obtained row</returns>
        private ServiceInformationTDS.BasicInformationRow GetRow(int serviceId)
        {
            ServiceInformationTDS.BasicInformationRow row = ((ServiceInformationTDS.BasicInformationDataTable)Table).FindByServiceID(serviceId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.FleetManagement.Services.ServiceInformationBasicInformation.GetRow");
            }

            return row;
        }



    }
}