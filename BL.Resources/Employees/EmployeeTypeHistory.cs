using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Resources.Employees;

namespace LiquiForce.LFSLive.BL.Resources.Employees
{
    /// <summary>
    /// EmployeeTypeHistory
    /// </summary>
    public class EmployeeTypeHistory: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public EmployeeTypeHistory()
            : base("LFS_RESOURCES_EMPLOYEE_TYPE_HISTORY")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public EmployeeTypeHistory(DataSet data)
            : base(data, "LFS_RESOURCES_EMPLOYEE_TYPE_HISTORY")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new EmployeeTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Insert a new employee cost (direct to DB)
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="refId">refId</param>
        /// <param name="date">date</param>
        /// <param name="type">type</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void InsertDirect(int refId, int employeeId, DateTime date, string type, bool deleted, int companyId)
        {
            EmployeeTypeHistoryGateway employeeCostHistoryGateway = new EmployeeTypeHistoryGateway(null);
            employeeCostHistoryGateway.Insert(refId, employeeId, date, type, deleted, companyId);
        }



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="originalEmployeeIdId">originalEmployeeIdId</param>        
        /// <param name="originalRefId">originalRefId</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        public void DeleteDirect(int originalEmployeeIdId,int originalRefId,  int originalCompanyId)
        {
            EmployeeTypeHistoryGateway employeeCostHistoryGateway = new EmployeeTypeHistoryGateway(null);
            employeeCostHistoryGateway.Delete(originalEmployeeIdId, originalRefId, originalCompanyId);
        }



        /// <summary>
        /// DeleteAllDirect
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteAllDirect(int employeeId, int companyId)
        {                      
            EmployeeTypeHistoryGateway employeeCostHistoryGateway = new EmployeeTypeHistoryGateway(null);
            employeeCostHistoryGateway.DeleteAll(employeeId, companyId);
        }



    }
}