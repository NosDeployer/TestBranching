using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.LabourHours.Vacations;

namespace LiquiForce.LFSLive.BL.LabourHours.Vacations
{
    /// <summary>
    /// VacationRequests
    /// </summary>
    public class VacationRequests : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public VacationRequests()
            : base("LFS_VACATION_REQUESTS")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public VacationRequests(DataSet data)
            : base(data, "LFS_VACATION_REQUESTS")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new VacationsTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// InsertDirect
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="totalPaidVacationDays">totalPaidVacationDays</param>
        /// <param name="state">state</param>
        /// <param name="comments">comments</param>
        /// <param name="details">details</param>
        /// <param name="rejectReason">rejectReason</param>
        /// <param name="cancelReason">cancelReason</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <returns></returns>
        public int InsertDirect(int employeeId, DateTime startDate, DateTime endDate, double totalPaidVacationDays, string state, string comments, string details, string rejectReason, string cancelReason, bool deleted, int companyId)
        {
            VacationRequestsGateway vacationRequestsGateway = new VacationRequestsGateway(Data);
            int requestId = vacationRequestsGateway.Insert(employeeId, startDate, endDate, totalPaidVacationDays, state, comments, details, rejectReason, cancelReason, deleted, companyId);

            return requestId;
        }



        /// <summary>
        /// UpdateDirect
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="originalStartDate">originalStartDate</param>
        /// <param name="originalEndDate">originalEndDate</param>
        /// <param name="originalTotalPaidVacationDays">originalTotalPaidVacationDays</param>
        /// <param name="originalState">originalState</param>
        /// <param name="originalComments"originalComments></param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// 
        /// <param name="newStartDate">newStartDate</param>
        /// <param name="newEndDate">newEndDate</param>
        /// <param name="newTotalPaidVacationDays">newTotalPaidVacationDays</param>
        /// <param name="newState">newState</param>
        /// <param name="newComments">newComments</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        public void UpdateDirect(int originalRequestId, int originalEmployeeId, DateTime originalStartDate, DateTime originalEndDate, double originalTotalPaidVacationDays, string originalState, string originalComments, string originalDetails, string originalRejectReason, string originalCancelReason, bool originalDeleted, int originalCompanyId, int newRequestId, int newEmployeeId, DateTime newStartDate, DateTime newEndDate, double newTotalPaidVacationDays, string newState, string newComments, string newDetails, string newRejectReason, string newCancelReason, bool newDeleted, int newCompanyId)
        {
            VacationRequestsGateway vacationRequestsGateway = new VacationRequestsGateway(Data);
            vacationRequestsGateway.Update(originalRequestId, originalEmployeeId, originalStartDate, originalEndDate, originalTotalPaidVacationDays, originalState, originalComments, originalDetails, originalRejectReason, originalCancelReason, originalDeleted, originalCompanyId, newRequestId, newEmployeeId, newStartDate, newEndDate, newTotalPaidVacationDays, newState, newComments, newDetails, newRejectReason, newCancelReason, newDeleted, newCompanyId);
        }



    }
}