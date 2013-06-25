using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Resources.Employees;

namespace LiquiForce.LFSLive.BL.Resources.Employees
{
    /// <summary>
    /// EmployeeInformationPayVacationDaysInformation
    /// </summary>
    public class EmployeeInformationPayVacationDaysInformation : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public EmployeeInformationPayVacationDaysInformation()
            : base("PayVacationDaysInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public EmployeeInformationPayVacationDaysInformation(DataSet data)
            : base(data, "PayVacationDaysInformation")
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
        public void LoadByEmployeeIdYear(int employeeId, int year)
        {
            EmployeeInformationPayVacationDaysInformationGateway employeeInformationPayVacationDaysInformationGateway = new EmployeeInformationPayVacationDaysInformationGateway(Data);
            employeeInformationPayVacationDaysInformationGateway.LoadByEmployeeIdYear(employeeId, year);
        }



    }
}