using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.LabourHours.Vacations;

namespace LiquiForce.LFSLive.BL.LabourHours.Vacations
{
    /// <summary>
    /// VacationsNonWorkingDays
    /// </summary>
    public class VacationsNonWorkingDays : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public VacationsNonWorkingDays()
            : base("LFS_VACATION_NONWORKING_DAYS")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public VacationsNonWorkingDays(DataSet data)
            : base(data, "LFS_VACATION_NONWORKING_DAYS")
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
        public void InsertDirect(DateTime date, int companyLevelId, string description, bool deleted, int companyId)
        {
            VacationsNonWorkingDaysGateway vacationsNonWorkingDaysGateway = new VacationsNonWorkingDaysGateway(Data);
            vacationsNonWorkingDaysGateway.Insert(date, companyLevelId, description, deleted, companyId);
        }



        /// <summary>
        /// UpdateDirect
        /// </summary>
        /// <param name="originalDate">originalDate</param>
        /// <param name="originalCompanyLevelId">originalCompanyLevelId</param>
        /// <param name="originalDescription">originalDescription</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// 
        /// <param name="newDate">newDate</param>
        /// <param name="newCompanyLevelId">newCompanyLevelId</param>
        /// <param name="newDescription">newDescription</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        public void UpdateDirect(int nonWorkingDayId, DateTime originalDate, int originalCompanyLevelId, string originalDescription, bool originalDeleted, int originalCompanyId, DateTime newDate, int newCompanyLevelId, string newDescription, bool newDeleted, int newCompanyId)
        {
            VacationsNonWorkingDaysGateway vacationsNonWorkingDaysGateway = new VacationsNonWorkingDaysGateway(Data);
            vacationsNonWorkingDaysGateway.Update(nonWorkingDayId, originalDate, originalCompanyLevelId, originalDescription, originalDeleted, originalCompanyId, newDate, newCompanyLevelId, newDescription, newDeleted, newCompanyId);
        }



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="nonWorkingDayId">nonWorkingDayId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(int nonWorkingDayId, int companyId)
        {
            VacationsNonWorkingDaysGateway vacationsNonWorkingDaysGateway = new VacationsNonWorkingDaysGateway(Data);
            vacationsNonWorkingDaysGateway.Delete(nonWorkingDayId, companyId);
        }



    }
}