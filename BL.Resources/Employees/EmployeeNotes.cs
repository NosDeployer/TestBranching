using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Resources.Employees;

namespace LiquiForce.LFSLive.BL.Resources.Employees
{
    /// <summary>
    /// EmployeeNotes
    /// </summary>
    public class EmployeeNotes : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public EmployeeNotes()
            : base("LFS_RESOURCES_EMPLOYEE_NOTES")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public EmployeeNotes(DataSet data)
            : base(data, "LFS_RESOURCES_EMPLOYEE_NOTES")
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
        /// Insert a new employee (direct to DB)
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="refId">refId</param>
        /// <param name="subject">subject</param>
        /// <param name="userId">userId</param>
        /// <param name="dateTime_">dateTime_</param>
        /// <param name="note">note</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void InsertDirect(int employeeId, int refId, string subject, int userId, DateTime dateTime_, string note, bool deleted, int companyId)
        {
            EmployeeNotesGateway employeeNotesGateway = new EmployeeNotesGateway(null);
            employeeNotesGateway.Insert(employeeId, refId, subject, userId, dateTime_, note, deleted, companyId);
        }



        /// <summary>
        /// Update employee (direct to DB)
        /// </summary>
        /// <param name="originalEmployeeId">originalEmployeeId</param>
        /// <param name="originalRefId">originalRefId</param>
        /// <param name="originalSubject">originalSubject</param>
        /// <param name="originalUserId">originalUserId</param>
        /// <param name="originalDateTime_">originalDateTime_</param>
        /// <param name="originalNote">originalNote</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// 
        /// <param name="newEmployeeId">newEmployeeId</param>
        /// <param name="newRefId">newRefId</param>
        /// <param name="newSubject">newSubject</param>
        /// <param name="newUserId">newUserId</param>
        /// <param name="newDateTime">newDateTime</param>
        /// <param name="newNote">newNote</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        public void UpdateDirect(int originalEmployeeId, int originalRefId, string originalSubject, int originalUserId, DateTime originalDateTime_, string originalNote, bool originalDeleted, int originalCompanyId, int newEmployeeId, int newRefId, string newSubject, int newUserId, DateTime newDateTime, string newNote, bool newDeleted, int newCompanyId)
        {
            EmployeeNotesGateway employeesNotesGateway = new EmployeeNotesGateway(null);
            employeesNotesGateway.Update(originalEmployeeId, originalRefId, originalSubject, originalUserId, originalDateTime_, originalNote, originalDeleted, originalCompanyId, newEmployeeId, newRefId, newSubject, newUserId, newDateTime, newNote, newDeleted, newCompanyId);
        }



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(int employeeId, int refId, int companyId)
        {
            EmployeeNotesGateway employeeNotesGateway = new EmployeeNotesGateway(null);
            employeeNotesGateway.Delete(employeeId, refId, companyId);
        }



        /// <summary>
        /// DeleteAllDirect
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteAllDirect(int employeeId, int companyId)
        {
            EmployeeNotesGateway employeeNotesGateway = new EmployeeNotesGateway(null);
            employeeNotesGateway.DeleteAll(employeeId, companyId);
        }



    }
}
