using System;
using System.Data;
using System.Collections;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.LabourHours.Vacations;

namespace LiquiForce.LFSLive.BL.LabourHours.Vacations
{
    /// <summary>
    /// VacationsInformationRequestsInformation
    /// </summary>
    public class VacationsInformationRequestsInformation : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public VacationsInformationRequestsInformation()
            : base("RequestsInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public VacationsInformationRequestsInformation(DataSet data)
            : base(data, "RequestsInformation")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new VacationsInformationTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// LoadByRequestId
        /// </summary>
        /// <param name="requestId">requestId</param>
        /// <param name="companyId">companyId</param>
        public void LoadByRequestId(int requestId, int companyId)
        {
            VacationsInformationRequestsInformationGateway vacationsInformationRequestsInformationGateway = new VacationsInformationRequestsInformationGateway(Data);
            vacationsInformationRequestsInformationGateway.LoadByRequestId(requestId, companyId);
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="requestId">requestId</param>
        public void Delete(int requestId)
        {
            VacationsInformationTDS.RequestsInformationRow row = GetRow(requestId);
            row.Deleted = true;
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="requestId">requestId</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="totalPaidVacationDays">totalPaidVacationDays</param>
        /// <param name="comments">comments</param>
        /// <param name="details">details</param>
        public void Update(int requestId, DateTime startDate, DateTime endDate, double totalPaidVacationDays, string comments, string details)
        {
            VacationsInformationTDS.RequestsInformationRow row = GetRow(requestId);
            row.StartDate = startDate;
            row.EndDate = endDate;
            row.TotalPaidVacationDays = totalPaidVacationDays;
            row.Comments = comments.Trim();
            row.Details = details;
        }



        /// <summary>
        /// UpdateVacationsForApproval
        /// </summary>
        /// <param name="requestId"></param>
        /// <param name="state"></param>
        /// <param name="rejectReason"></param>
        public void UpdateVacationsForApproval(int requestId, string state, string rejectReason)
        {
            VacationsInformationTDS.RequestsInformationRow row = GetRow(requestId);
            row.State = state;
            if (rejectReason.Trim() != "") row.RejectReason = rejectReason.Trim(); else row.SetRejectReasonNull();
        }



        /// <summary>
        /// UpdateVacationsForApproval
        /// </summary>
        /// <param name="requestId"></param>
        /// <param name="state"></param>
        /// <param name="rejectReason"></param>
        public void UpdateVacationsForCancel(int requestId, string state, string cancelReason)
        {
            VacationsInformationTDS.RequestsInformationRow row = GetRow(requestId);
            row.State = state;
            if (cancelReason.Trim() != "") row.CancelReason = cancelReason.Trim(); else row.SetCancelReasonNull();
        }



        /// <summary>
        /// UpdateState
        /// </summary>
        /// <param name="requestId">requestId</param>
        /// <param name="state">state</param>
        public void UpdateState(int requestId, string state)
        {
            VacationsInformationTDS.RequestsInformationRow row = GetRow(requestId);
            row.State = state;
        }



        /// <summary>
        /// Save
        /// </summary>
        public void Save()
        {
            VacationsInformationTDS vacationsInformationChanges = (VacationsInformationTDS)Data.GetChanges();

            if (vacationsInformationChanges.RequestsInformation.Rows.Count > 0)
            {
                VacationsInformationRequestsInformationGateway vacationsInformationRequestsInformationGateway = new VacationsInformationRequestsInformationGateway(vacationsInformationChanges);

                foreach (VacationsInformationTDS.RequestsInformationRow row in (VacationsInformationTDS.RequestsInformationDataTable)vacationsInformationChanges.RequestsInformation)
                {
                    int requestId = row.RequestID;
                    int employeeId = row.EmployeeID;
                    bool deleted = row.Deleted;
                    int companyId = row.COMPANY_ID;
                    
                    // original values
                    DateTime originalStartDate = vacationsInformationRequestsInformationGateway.GetStartDateOriginal(requestId);
                    DateTime originalEndDate = vacationsInformationRequestsInformationGateway.GetEndDateOriginal(requestId);
                    double originalTotalPaidVacationDays = vacationsInformationRequestsInformationGateway.GetTotalPaidVacationDaysOriginal(requestId);
                    string originalState = vacationsInformationRequestsInformationGateway.GetStateOriginal(requestId);
                    string originalComments = vacationsInformationRequestsInformationGateway.GetCommentsOriginal(requestId);
                    string originalDetails = vacationsInformationRequestsInformationGateway.GetDetailsOriginal(requestId);
                    string originalRejectReason = vacationsInformationRequestsInformationGateway.GetRejectReasonOriginal(requestId);
                    string originalCancelReason = vacationsInformationRequestsInformationGateway.GetCancelReasonOriginal(requestId);
                    
                    // new values
                    DateTime newStartDate = vacationsInformationRequestsInformationGateway.GetStartDate(requestId);
                    DateTime newEndDate = vacationsInformationRequestsInformationGateway.GetEndDate(requestId);
                    double newTotalPaidVacationDays = vacationsInformationRequestsInformationGateway.GetTotalPaidVacationDays(requestId);
                    string newState = vacationsInformationRequestsInformationGateway.GetState(requestId);
                    string newComments = vacationsInformationRequestsInformationGateway.GetComments(requestId);
                    string newDetails = vacationsInformationRequestsInformationGateway.GetDetails(requestId);
                    string newRejectReason = vacationsInformationRequestsInformationGateway.GetRejectReason(requestId);
                    string newCancelReason = vacationsInformationRequestsInformationGateway.GetCancelReason(requestId);

                    if (newState == "Rejected" || newState == "Cancelled")
                    {
                        VacationsInformationBasicInformationGateway vacationsInformationBasicInformationGateway = new VacationsInformationBasicInformationGateway();
                        vacationsInformationBasicInformationGateway.LoadByEmployeeIdYear(employeeId, originalStartDate.Year, companyId);
                        double oldTotalTakenVacationDays = vacationsInformationBasicInformationGateway.GetTotalVacationDays(employeeId, originalStartDate.Year) - vacationsInformationBasicInformationGateway.GetRemainingPayVacationDays(employeeId, originalStartDate.Year);

                        VacationsEmployeeMaxPaidVacations vacationsEmployeeMaxPaidVacations = new VacationsEmployeeMaxPaidVacations();
                        double newTotalTakenVacationDays = oldTotalTakenVacationDays - originalTotalPaidVacationDays;
                        vacationsEmployeeMaxPaidVacations.UpdateTotalTakenVacationDays(row.StartDate.Year, row.EmployeeID, newTotalTakenVacationDays);
                    }
                    else
                    {
                        if (originalState == newState)
                        {
                            VacationsInformationBasicInformationGateway vacationsInformationBasicInformationGateway = new VacationsInformationBasicInformationGateway();
                            vacationsInformationBasicInformationGateway.LoadByEmployeeIdYear(employeeId, originalStartDate.Year, companyId);
                            double oldTotalTakenVacationDays = vacationsInformationBasicInformationGateway.GetTotalVacationDays(employeeId, originalStartDate.Year) - vacationsInformationBasicInformationGateway.GetRemainingPayVacationDays(employeeId, originalStartDate.Year);

                            VacationsEmployeeMaxPaidVacations vacationsEmployeeMaxPaidVacations = new VacationsEmployeeMaxPaidVacations();
                            double newTotalTakenVacationDays = oldTotalTakenVacationDays + newTotalPaidVacationDays;
                            vacationsEmployeeMaxPaidVacations.UpdateTotalTakenVacationDays(row.StartDate.Year, row.EmployeeID, newTotalTakenVacationDays);
                        }
                    }

                    VacationRequests vacationRequests = new VacationRequests(null);
                    vacationRequests.UpdateDirect(requestId, employeeId, originalStartDate, originalEndDate, originalTotalPaidVacationDays, originalState, originalComments, originalDetails, originalRejectReason, originalCancelReason, deleted, companyId, requestId, employeeId, newStartDate, newEndDate, newTotalPaidVacationDays, newState, newComments, newDetails, newRejectReason, newCancelReason, deleted, companyId);
                }
            }
        }



        /// <summary>
        /// Save
        /// </summary>
        public void SaveForEdit(double newTakenDays)
        {
            VacationsInformationTDS vacationsInformationChanges = (VacationsInformationTDS)Data.GetChanges();

            if (vacationsInformationChanges.RequestsInformation.Rows.Count > 0)
            {
                VacationsInformationRequestsInformationGateway vacationsInformationRequestsInformationGateway = new VacationsInformationRequestsInformationGateway(vacationsInformationChanges);

                foreach (VacationsInformationTDS.RequestsInformationRow row in (VacationsInformationTDS.RequestsInformationDataTable)vacationsInformationChanges.RequestsInformation)
                {
                    int requestId = row.RequestID;
                    int employeeId = row.EmployeeID;
                    bool deleted = row.Deleted;
                    int companyId = row.COMPANY_ID;

                    // original values
                    DateTime originalStartDate = vacationsInformationRequestsInformationGateway.GetStartDateOriginal(requestId);
                    DateTime originalEndDate = vacationsInformationRequestsInformationGateway.GetEndDateOriginal(requestId);
                    double originalTotalPaidVacationDays = vacationsInformationRequestsInformationGateway.GetTotalPaidVacationDaysOriginal(requestId);
                    string originalState = vacationsInformationRequestsInformationGateway.GetStateOriginal(requestId);
                    string originalComments = vacationsInformationRequestsInformationGateway.GetCommentsOriginal(requestId);
                    string originalDetails = vacationsInformationRequestsInformationGateway.GetDetailsOriginal(requestId);
                    string originalRejectReason = vacationsInformationRequestsInformationGateway.GetRejectReasonOriginal(requestId);
                    string originalCancelReason = vacationsInformationRequestsInformationGateway.GetCancelReasonOriginal(requestId);
                    bool originalDeleted = vacationsInformationRequestsInformationGateway.GetDeletedOriginal(requestId);

                    // new values
                    DateTime newStartDate = vacationsInformationRequestsInformationGateway.GetStartDate(requestId);
                    DateTime newEndDate = vacationsInformationRequestsInformationGateway.GetEndDate(requestId);
                    double newTotalPaidVacationDays = vacationsInformationRequestsInformationGateway.GetTotalPaidVacationDays(requestId);
                    string newState = vacationsInformationRequestsInformationGateway.GetState(requestId);
                    string newComments = vacationsInformationRequestsInformationGateway.GetComments(requestId);
                    string newDetails = vacationsInformationRequestsInformationGateway.GetDetails(requestId);
                    string newRejectReason = vacationsInformationRequestsInformationGateway.GetRejectReason(requestId);
                    string newCancelReason = vacationsInformationRequestsInformationGateway.GetCancelReason(requestId);
                    bool newDeleted = vacationsInformationRequestsInformationGateway.GetDeleted(requestId);

                    VacationsEmployeeMaxPaidVacations vacationsEmployeeMaxPaidVacations = new VacationsEmployeeMaxPaidVacations();
                    vacationsEmployeeMaxPaidVacations.UpdateTotalTakenVacationDays(row.StartDate.Year, row.EmployeeID, newTakenDays);

                    VacationRequests vacationRequests = new VacationRequests(null);
                    vacationRequests.UpdateDirect(requestId, employeeId, originalStartDate, originalEndDate, originalTotalPaidVacationDays, originalState, originalComments, originalDetails, originalRejectReason, originalCancelReason, originalDeleted, companyId, requestId, employeeId, newStartDate, newEndDate, newTotalPaidVacationDays, newState, newComments, newDetails, newRejectReason, newCancelReason, newDeleted, companyId);
                }
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// Get a single row. If not exists, raise an exception.
        /// </summary>
        /// <param name="requestId">requestId</param>
        /// <returns>Obtained row</returns>
        private VacationsInformationTDS.RequestsInformationRow GetRow(int requestId)
        {
            VacationsInformationTDS.RequestsInformationRow row = ((VacationsInformationTDS.RequestsInformationDataTable)Table).FindByRequestID(requestId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.LabourHours.Vacations.VacationsInformationRequestsInformation.GetRow");
            }

            return row;
        }

        

    }
}