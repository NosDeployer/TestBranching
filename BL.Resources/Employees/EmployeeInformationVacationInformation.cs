using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Resources.Employees;
using System;

namespace LiquiForce.LFSLive.BL.Resources.Employees
{
    /// <summary>
    /// EmployeeInformationVacationInformation
    /// </summary>
    public class EmployeeInformationVacationInformation : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public EmployeeInformationVacationInformation()
            : base("VacationInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public EmployeeInformationVacationInformation(DataSet data)
            : base(data, "VacationInformation")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new EmployeeInformationTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadByEmployeeIdYear
        /// </summary>
        /// <param name="employeeId">employeeId</param>              
        /// <param name="year">year</param>
        public void LoadByEmployeeIdStartDateEndDate(int employeeId, DateTime startDate, DateTime endDate, int companyId)
        {
            EmployeeInformationVacationInformationGateway employeeInformationVacationInformationGateway = new EmployeeInformationVacationInformationGateway(Data);
            employeeInformationVacationInformationGateway.LoadByEmployeeIdStartDateEndDate(employeeId, startDate, endDate, companyId);
        }



    }
}