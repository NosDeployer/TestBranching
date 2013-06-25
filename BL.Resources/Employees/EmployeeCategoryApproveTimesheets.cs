using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Resources.Employees;

namespace LiquiForce.LFSLive.BL.Resources.Employees
{
    /// <summary>
    /// EmployeeCategoryApproveTimesheets
    /// </summary>
    public class EmployeeCategoryApproveTimesheets : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public EmployeeCategoryApproveTimesheets()
            : base("LFS_RESOURCES_EMPLOYEE_CATEGORY_APPROVE_TIMESHEETS")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public EmployeeCategoryApproveTimesheets(DataSet data)
            : base(data, "LFS_RESOURCES_EMPLOYEE_CATEGORY_APPROVE_TIMESHEETS")
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
        /// Insert a new employee category approve timesheets (direct to DB)
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="category">category</param>
        /// <param name="approveTimesheets">approveTimesheets</param>
        /// <param name="deleted">deleted</param>
        public void InsertDirect(int employeeId, string category, bool approveTimesheets, bool deleted)
        {
            EmployeeCategoryApproveTimesheetsGateway employeeCategoryApproveTimesheetsGateway = new EmployeeCategoryApproveTimesheetsGateway(null);
            employeeCategoryApproveTimesheetsGateway.Insert(employeeId, category, approveTimesheets, deleted);
        }



        /// <summary>
        /// Update employee category approve timesheets (direct to DB)
        /// </summary>
        /// <param name="originalEmployeeId">originalEmployeeId</param>
        /// <param name="originalCategory">originalCategory</param>
        /// <param name="originalApproveTimesheets">originalApproveTimesheets</param>
        /// <param name="originalDelete">originalDelete</param>
        ///
        /// <param name="newEmployeeId">newEmployeeId</param>
        /// <param name="newCategory">newCategory</param>
        /// <param name="newApproveTimesheets">newApproveTimesheets</param>
        /// <param name="newDelete">newDelete</param>
        public int UpdateDirect(int originalEmployeeId, string originalCategory, bool originalApproveTimesheets, bool originalDeleted, int newEmployeeId, string newCategory, bool newApproveTimesheets, bool newDeleted)
        {
            EmployeeCategoryApproveTimesheetsGateway employeeCategoryApproveTimesheetsGateway = new EmployeeCategoryApproveTimesheetsGateway(null);
            return employeeCategoryApproveTimesheetsGateway.Update(originalEmployeeId, originalCategory, originalApproveTimesheets, originalDeleted, newEmployeeId, newCategory, newApproveTimesheets, newDeleted);
        }



        /// <summary>
        /// Delete employee category approve timesheets (direct to DB)
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="category">category</param>
        public void DeleteAllDirect(int employeeId, string category)
        {
            EmployeeCategoryApproveTimesheetsGateway employeeCategoryApproveTimesheetsGateway = new EmployeeCategoryApproveTimesheetsGateway(null);
            employeeCategoryApproveTimesheetsGateway.DeleteAll(employeeId, category);
        }



    }
}