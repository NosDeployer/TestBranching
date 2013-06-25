using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.LabourHours.Vacations;

namespace LiquiForce.LFSLive.BL.LabourHours.Vacations
{
    /// <summary>
    /// VacationDays
    /// </summary>
    public class VacationDays : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public VacationDays()
            : base("LFS_VACATION_DAYS")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public VacationDays(DataSet data)
            : base(data, "LFS_VACATION_DAYS")
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
        /// <param name="date">date</param>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <param name="description">description</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public int InsertDirect(int requestId, DateTime startDate, DateTime endDate, string description, string paymentType, bool deleted, int companyId)
        {
            VacationDaysGateway vacationDaysGateway = new VacationDaysGateway(Data);
            int vacationId = vacationDaysGateway.Insert(requestId, startDate, endDate, description, paymentType, deleted, companyId);

            return requestId;
        }



        /// <summary>
        /// UpdateDirect
        /// </summary>
        /// <param name="originalVacationId"></param>
        /// <param name="originalRequestId"></param>
        /// <param name="originalStartDate"></param>
        /// <param name="originalEndDate"></param>
        /// <param name="originalDescription"></param>
        /// <param name="originalPaymentType"></param>
        /// <param name="originalDeleted"></param>
        /// <param name="originalCompanyId"></param>
        /// 
        /// <param name="newVacationId"></param>
        /// <param name="newRequestId"></param>
        /// <param name="newStartDate"></param>
        /// <param name="newEndDate"></param>
        /// <param name="newDescription"></param>
        /// <param name="newPaymentType"></param>
        /// <param name="newDeleted"></param>
        /// <param name="newCompanyId"></param>
        public void UpdateDirect(int originalVacationId, int originalRequestId, DateTime originalStartDate, DateTime originalEndDate, string originalDescription, string originalPaymentType, bool originalDeleted, int originalCompanyId, int newVacationId, int newRequestId, DateTime newStartDate, DateTime newEndDate, string newDescription, string newPaymentType, bool newDeleted, int newCompanyId)
        {
            VacationDaysGateway vacationDaysGateway = new VacationDaysGateway(Data);
            vacationDaysGateway.Update(originalVacationId, originalRequestId, originalStartDate, originalEndDate, originalDescription, originalPaymentType, originalDeleted, originalCompanyId, newVacationId, newRequestId, newStartDate, newEndDate, newDescription, newPaymentType, newDeleted, newCompanyId);
        }



        /// <summary>
        /// DeleteDirect
        /// </summaryy>
        /// <param name="vacationId">vacationId></param>
        public void DeleteDirect(int vacationId)
        {
            VacationDaysGateway vacationDaysGateway = new VacationDaysGateway(Data);
            vacationDaysGateway.Delete(vacationId);
        }



    }
}