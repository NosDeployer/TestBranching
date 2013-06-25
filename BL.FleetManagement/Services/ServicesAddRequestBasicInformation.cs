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
    /// ServicesAddRequestBasicInformation
    /// </summary>
    public class ServicesAddRequestBasicInformation : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ServicesAddRequestBasicInformation()
            : base("BasicInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ServicesAddRequestBasicInformation(DataSet data)
            : base(data, "BasicInformation")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ServicesAddRequestTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Insert a service
        /// </summary>
        /// <param name="serviceState">serviceState</param>
        /// <param name="mtoDot">mtoDot</param>
        /// <param name="serviceDescription">serviceDescription</param>
        /// <param name="assignedDeadlineDate">assignedDeadlineDate</param>
        /// <param name="assignDateTime">assignDateTime</param>
        /// <param name="assignTeamMember">assignTeamMember</param>
        /// <param name="assignTeamMemberId">assignTeamMemberId</param>
        /// <param name="assignThirdPartyVendor">assignThirdPartyVendor</param>
        /// <param name="acceptDateTime">acceptDateTime</param>
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
        /// <param name="unitID">unitID</param>
        /// <param name="mileage">mileage</param>
        /// <param name="startWorkMileage">startWorkMileage</param>
        /// <param name="completeWorkMileage">completeWorkMileage</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="ruleId">ruleId</param>
        public void Insert(string serviceState, bool mtoDot, string serviceDescription, DateTime? assignedDeadlineDate, DateTime? assignDateTime, bool assignTeamMember, int? assignTeamMemberId, string assignThirdPartyVendor, DateTime? acceptDateTime, DateTime? unitOutOfServiceDate, string unitOutOfServiceTime, DateTime? completeWorkDateTime, DateTime? unitBackInServiceDate, string unitBackInServiceTime, string completeWorkDetailDescription, bool completeWorkDetailPreventable, Decimal? completeWorkDetailTMLabourHours, Decimal? completeWorkDetailTMCost, string completeWorkInvoiceNumber, decimal? completeWorkInvoiceAmount, int unitID, string mileage, string startWorkMileage, string completeWorkMileage, bool deleted, int companyId, int? ruleId)
        {
            ServicesAddRequestTDS.BasicInformationRow row = ((ServicesAddRequestTDS.BasicInformationDataTable)Table).NewBasicInformationRow();

            row.ServiceID = GetNewId();
            row.ServiceState = serviceState;
            row.MtoDot = mtoDot;
            row.ServiceDescription = serviceDescription;
            if (assignedDeadlineDate.HasValue) row.AssignedDeadlineDate = (DateTime)assignedDeadlineDate; else row.SetAssignedDeadlineDateNull();
            if (assignDateTime.HasValue) row.AssignDateTime = (DateTime)assignDateTime; else row.SetAssignDateTimeNull();
            row.AssignTeamMember = assignTeamMember;
            if (assignTeamMemberId.HasValue) row.AssignTeamMemberId = (int)assignTeamMemberId; else row.SetAssignTeamMemberIdNull();
            if (assignThirdPartyVendor != "") row.AssignThirdPartyVendor = assignThirdPartyVendor; else row.SetAssignThirdPartyVendorNull();
            if (acceptDateTime.HasValue) row.AcceptDatetime = (DateTime)acceptDateTime; else row.SetAcceptDatetimeNull();
            if (unitOutOfServiceDate.HasValue) row.UnitOutOfServiceDate = (DateTime)unitOutOfServiceDate; else row.SetUnitOutOfServiceDateNull();
            if (unitOutOfServiceTime != "") row.UnitOutOfServiceTime = unitOutOfServiceTime; else row.SetUnitOutOfServiceTimeNull();
            if (completeWorkDateTime.HasValue) row.CompleteWorkDateTime = (DateTime)completeWorkDateTime; else row.SetCompleteWorkDateTimeNull();
            if (unitBackInServiceDate.HasValue) row.UnitBackInServiceDate = (DateTime)unitBackInServiceDate; else row.SetUnitBackInServiceDateNull();
            if (unitBackInServiceTime != "") row.UnitBackInServiceTime = unitBackInServiceTime; else row.SetUnitBackInServiceTimeNull();
            if (completeWorkDetailDescription != "") row.CompleteWorkDetailDescription = completeWorkDetailDescription; else row.SetCompleteWorkDetailDescriptionNull();
            row.CompleteWorkDetailPreventable = completeWorkDetailPreventable;
            if (completeWorkDetailTMLabourHours.HasValue) row.CompleteWorkDetailTMLabourHours = (Decimal)completeWorkDetailTMLabourHours; else row.SetCompleteWorkDetailTMLabourHoursNull();
            if (completeWorkDetailTMCost.HasValue) row.CompleteWorkDetailTMCost = (Decimal)completeWorkDetailTMCost; else row.SetCompleteWorkDetailTMCostNull();
            if (completeWorkInvoiceNumber != "") row.CompleteWorkInvoiceNumber = completeWorkInvoiceNumber; else row.IsCompleteWorkInvoiceNumberNull();
            if (completeWorkInvoiceAmount.HasValue) row.CompleteWorkInvoiceAmount = (decimal)completeWorkInvoiceAmount; else row.IsCompleteWorkInvoiceAmountNull();
            row.UnitID = unitID;
            if (mileage.Trim() != "") row.Mileage = mileage; else row.SetMileageNull();
            if (startWorkMileage != "") row.StartWorkMileage = startWorkMileage; else row.SetStartWorkMileageNull();            
            if (completeWorkMileage != "") row.CompleteWorkMileage = completeWorkMileage; else row.SetCompleteWorkMileageNull();
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            if (ruleId.HasValue) row.RuleID = (int)ruleId; else row.SetRuleIDNull();
                        
            ((ServicesAddRequestTDS.BasicInformationDataTable)Table).AddBasicInformationRow(row);
        }



        /// <summary>
        /// Save services
        /// </summary>
        /// <param name="dateTime_">dateTime_</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="checklistState">checklistState</param>
        public int? Save(DateTime dateTime_, int employeeId, int companyId)
        {
            int? newServiceId = null;

            ServicesAddRequestTDS servicesAddRequestSelfAsignedChanges = (ServicesAddRequestTDS)Data.GetChanges();
            if (servicesAddRequestSelfAsignedChanges.BasicInformation.Rows.Count > 0)
            {
                ServicesGateway servicesGateway = new ServicesGateway(servicesAddRequestSelfAsignedChanges);

                foreach (ServicesAddRequestTDS.BasicInformationRow row in (ServicesAddRequestTDS.BasicInformationDataTable)servicesAddRequestSelfAsignedChanges.BasicInformation)
                {
                    DateTime? assignmentDeadlineDate = null; if (!row.IsAssignedDeadlineDateNull()) assignmentDeadlineDate = row.AssignedDeadlineDate;
                    DateTime? assignDateTime = null; if(row.IsAssignDateTimeNull()) row.AssignDateTime = DateTime.Now; 
                    DateTime? acceptDatetime = null; if (!row.IsAcceptDatetimeNull()) acceptDatetime = row.AcceptDatetime;
                    DateTime? unitOutOfServiceDate = null; if (!row.IsUnitOutOfServiceDateNull()) unitOutOfServiceDate = row.UnitOutOfServiceDate;
                    string unitOutOfServiceTime = ""; if (!row.IsUnitOutOfServiceTimeNull()) unitOutOfServiceTime = row.UnitOutOfServiceTime;
                    DateTime? completeWorkDateTime = null; if (!row.IsCompleteWorkDateTimeNull()) completeWorkDateTime = row.CompleteWorkDateTime;
                    DateTime? unitBackInServiceDate = null; if (!row.IsUnitBackInServiceDateNull()) unitBackInServiceDate = row.UnitBackInServiceDate;
                    string unitBackInServiceTime = ""; if (!row.IsUnitBackInServiceTimeNull()) unitBackInServiceTime = row.UnitBackInServiceTime;
                    string completeWorkDetailDescription = ""; if (!row.IsCompleteWorkDetailDescriptionNull()) completeWorkDetailDescription = row.CompleteWorkDetailDescription;
                    bool completeWorkDetailPreventable = row.CompleteWorkDetailPreventable;
                    Decimal? completeWorkDetailTMLabourHours = null; if (!row.IsCompleteWorkDetailTMLabourHoursNull()) completeWorkDetailTMLabourHours = row.CompleteWorkDetailTMLabourHours;
                    Decimal? completeWorkDetailTMCost = null; if (!row.IsCompleteWorkDetailTMCostNull()) completeWorkDetailTMCost = row.CompleteWorkDetailTMCost;
                    string completeWorkDetaildTPVInvoiceNumber = ""; if (!row.IsCompleteWorkInvoiceNumberNull()) completeWorkDetaildTPVInvoiceNumber = row.CompleteWorkInvoiceNumber;
                    Decimal? completeWorkDetaildTPVInvoiceAmount = null; if (!row.IsCompleteWorkInvoiceAmountNull()) completeWorkDetaildTPVInvoiceAmount = row.CompleteWorkInvoiceAmount;
                    string mileage = ""; if (!row.IsMileageNull()) mileage = row.Mileage;
                    string startWorkMileage = ""; if (!row.IsStartWorkMileageNull()) startWorkMileage = row.StartWorkMileage;
                    string completeWorkMileage = ""; if (!row.IsCompleteWorkMileageNull()) completeWorkMileage = row.CompleteWorkMileage;
                    bool assignTeamMember = row.AssignTeamMember;
                    int? assignTeamMemberId = null; if (!row.IsAssignTeamMemberIdNull()) assignTeamMemberId = row.AssignTeamMemberId;
                    string assignThirdPartyVendor = ""; if (!row.IsAssignThirdPartyVendorNull()) assignThirdPartyVendor = row.AssignThirdPartyVendor;
                    DateTime? startWorkDateTime = null; if (!row.IsUnitOutOfServiceDateNull()) startWorkDateTime =  DateTime.Now;
                    int? ruleId = null; if (!row.IsRuleIDNull()) ruleId = row.RuleID;
                    string type = ""; if (ruleId.HasValue) type = "Checklist"; else type = "Normal";
                    int? libraryCategoriesId = 3736;//Fleet Maintence Invoices folder

                    Services services = new Services(null);
                    newServiceId = services.InsertDirect(dateTime_, row.MtoDot, row.ServiceDescription, row.UnitID, type, row.ServiceState, employeeId, assignDateTime, assignmentDeadlineDate, assignTeamMember, assignTeamMemberId, assignThirdPartyVendor, acceptDatetime, null, "", startWorkDateTime, unitOutOfServiceDate, unitOutOfServiceTime, completeWorkDateTime, unitBackInServiceDate, unitBackInServiceTime, completeWorkDetailDescription, completeWorkDetailPreventable, completeWorkDetailTMLabourHours, completeWorkDetailTMCost, completeWorkDetaildTPVInvoiceNumber, completeWorkDetaildTPVInvoiceAmount, "", ruleId, mileage, startWorkMileage, completeWorkMileage, row.Deleted, row.COMPANY_ID, libraryCategoriesId);

                    // modify checklist state
                    if (ruleId.HasValue)
                    {
                        string newChecklistState = "In Progress";                        

                        if (row.ServiceState == "Completed")
                        {
                            RuleGateway ruleGateway = new RuleGateway();
                            ruleGateway.LoadAllByRuleId(row.RuleID, row.COMPANY_ID);

                            DateTime? newLastService = null; newLastService = DateTime.Now;
                            DateTime? newNextDue = null;
                            bool newDone = true;
                            newChecklistState = "Healthy";                           

                            if (newLastService.HasValue)
                            {
                                ChecklistGateway checklistGateway = new ChecklistGateway();
                                checklistGateway.LoadByUnitIdRuleId(row.UnitID, row.RuleID, companyId);

                                // ... Original values
                                DateTime? originalLastService = checklistGateway.GetLastService(row.UnitID, row.RuleID);
                                DateTime? originalNextDue = checklistGateway.GetNextDue(row.UnitID, row.RuleID);
                                bool originalDone = checklistGateway.GetDone(row.UnitID, row.RuleID);
                                string originalState = checklistGateway.GetState(row.UnitID, row.RuleID);

                                string frecuency = ruleGateway.GetFrequency(row.RuleID);

                                if (frecuency != "Only once")
                                {
                                    // Get next due
                                    DateTime timeToAdded = new DateTime(((DateTime)newLastService).Year, ((DateTime)newLastService).Month, ((DateTime)newLastService).Day);

                                    if (frecuency == "Monthly") newNextDue = timeToAdded.AddMonths(1);
                                    if (frecuency == "Every 2 months") newNextDue = timeToAdded.AddMonths(2);
                                    if (frecuency == "Every 3 months") newNextDue = timeToAdded.AddMonths(3);
                                    if (frecuency == "Every 4 months") newNextDue = timeToAdded.AddMonths(4);
                                    if (frecuency == "Every 6 months") newNextDue = timeToAdded.AddMonths(6);
                                    if (frecuency == "Yearly") newNextDue = timeToAdded.AddYears(1);

                                    newDone = false;                                    
                                }

                                Checklist checklist = new Checklist();
                                checklist.UpdateDirect(row.UnitID, row.RuleID, originalLastService, originalNextDue, originalDone, originalState, false, companyId, row.UnitID, row.RuleID, newLastService, newNextDue, newDone, newChecklistState, false, companyId);
                            }                            
                        }
                        else
                        {
                            Checklist checklist = new Checklist(null);
                            checklist.UpdateStateDirect(ruleId.Value, row.UnitID, companyId, newChecklistState);
                        }
                    }
                }
            }

            return newServiceId;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// Get a single section. If not exists, raise an exception
        /// </summary>
        /// <param name="serviceId">internal serviceId</param>
        /// <returns>Row</returns>
        private ServicesAddRequestTDS.BasicInformationRow GetRow(int serviceId)
        {
            ServicesAddRequestTDS.BasicInformationRow row = ((ServicesAddRequestTDS.BasicInformationDataTable)Table).FindByServiceID(serviceId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.FleetManagement.Services.ServicesAddRequestBasicInformation.GetRow");
            }

            return row;
        }



        /// <summary>
        /// GetNewId
        /// </summary>
        /// <returns>ServiceId</returns>
        private int GetNewId()
        {
            int newId = 0;

            foreach (ServicesAddRequestTDS.BasicInformationRow row in (ServicesAddRequestTDS.BasicInformationDataTable)Table)
            {
                if (newId < row.ServiceID)
                {
                    newId = row.ServiceID;
                }
            }

            newId++;

            return newId;
        }



    }
}