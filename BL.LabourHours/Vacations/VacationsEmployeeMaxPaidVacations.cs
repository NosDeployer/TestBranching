using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.LabourHours.Vacations;

namespace LiquiForce.LFSLive.BL.LabourHours.Vacations
{
    /// <summary>
    /// VacationsEmployeeMaxPaidVacations
    /// </summary>
    public class VacationsEmployeeMaxPaidVacations : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public VacationsEmployeeMaxPaidVacations()
            : base("LFS_VACATION_EMPLOYEE_MAX_PAID_VACATIONS")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public VacationsEmployeeMaxPaidVacations(DataSet data)
            : base(data, "LFS_VACATION_EMPLOYEE_MAX_PAID_VACATIONS")
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
        /// <param name="year">year</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="vacationDays">vacationDays</param>
        /// <param name="totalTakenVacationDays">totalTakenVacationDays</param>
        /// <param name="carryOverDays">carryOverDays</param>
        /// <param name="totalVacationDays">totalVacationDays</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void InsertDirect(int year, int employeeId, double vacationDays, double totalTakenVacationDays,  double carryOverDays, double totalVacationDays, bool deleted, int companyId)
        {
            VacationsEmployeeMaxPaidVacationsGateway vacationsEmployeeMaxPaidVacationsGateway = new VacationsEmployeeMaxPaidVacationsGateway(Data);
            vacationsEmployeeMaxPaidVacationsGateway.Insert(year, employeeId, vacationDays, totalTakenVacationDays, carryOverDays, totalVacationDays, deleted, companyId);
        }



        /// <summary>
        /// UpdateDirect
        /// </summary>        
        /// <param name="originalYear">originalYear</param>
        /// <param name="originalEmployeeId">originalEmployeeId</param>
        /// <param name="originalVacationDays">originalVacationDays</param>
        /// <param name="originalTotalTakenVacationDays">originalTotalTakenVacationDays</param>
        /// <param name="originalCarryOverDays">originalCarryOverDays</param>
        /// <param name="originalTotalVacationDays">originalTotalVacationDays</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// 
        /// <param name="newYear">newYear</param>
        /// <param name="newEmployeeId">newEmployeeId</param>
        /// <param name="newVacationDays">newVacationDays</param>
        /// <param name="newTotalTakenVacationDays">newTotalTakenVacationDays</param>
        /// <param name="newCarryOverDays">newCarryOverDays</param>
        /// <param name="newTotalVacationDays">newTotalVacationDays</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        public void UpdateDirect(int originalYear, int originalEmployeeId, double originalVacationDays, double originalTotalTakenVacationDays, double originalCarryOverDays, double originalTotalVacationDays, bool originalDeleted, int originalCompanyId, int newYear, int newEmployeeId, double newVacationDays, double newTotalTakenVacationDays, double newCarryOverDays, double newTotalVacationDays, bool newDeleted, int newCompanyId)
        {
            VacationsEmployeeMaxPaidVacationsGateway vacationsEmployeeMaxPaidVacationsGateway = new VacationsEmployeeMaxPaidVacationsGateway(Data);
            vacationsEmployeeMaxPaidVacationsGateway.Update(originalYear, originalEmployeeId, originalVacationDays, originalTotalTakenVacationDays, originalCarryOverDays, originalTotalVacationDays, originalDeleted, originalCompanyId, newYear, newEmployeeId, newVacationDays, newTotalTakenVacationDays, newCarryOverDays, newTotalVacationDays, newDeleted, newCompanyId);
        }



        /// <summary>
        /// UpdateTotalTakenVacationDays
        /// </summary>
        /// <param name="year">year</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="newTotalTakenVacationDays">newTotalTakenVacationDays</param>
        public void UpdateTotalTakenVacationDays(int year, int employeeId, double newTotalTakenVacationDays)
        {
            VacationsEmployeeMaxPaidVacationsGateway vacationsEmployeeMaxPaidVacationsGateway = new VacationsEmployeeMaxPaidVacationsGateway(Data);
            vacationsEmployeeMaxPaidVacationsGateway.UpdateTotalTakenVacationDays(year, employeeId, newTotalTakenVacationDays);
        }



    }
}