using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.LabourHours.Vacations;

namespace LiquiForce.LFSLive.BL.LabourHours.TimeSheet
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

            return vacationId;
        }



    }
}