using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Resources.Employees;

namespace LiquiForce.LFSLive.BL.Resources.Employees
{
    /// <summary>
    /// EmployeePersonalAgency
    /// </summary>
    public class EmployeePersonalAgency : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public EmployeePersonalAgency()
            : base("LFS_RESOURCES_EMPLOYEE_PERSONAL_AGENCIES")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public EmployeePersonalAgency(DataSet data)
            : base(data, "LFS_RESOURCES_EMPLOYEE_PERSONAL_AGENCIES")
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
        /// Insert material
        /// </summary>
        /// <param name="personalAgencyName">personalAgencyName</param>
        /// <param name="companyId">companyId</param>
        /// <param name="deleted">deleted</param>        
        public void InsertDirect(string personalAgencyName, int companyId, bool deleted)
        {
            EmployeePersonalAgencyGateway employeePersonalAgencyGateway = new EmployeePersonalAgencyGateway(null);
            employeePersonalAgencyGateway.Insert(personalAgencyName, companyId, deleted);
        }



        /// <summary>
        /// Update PersonalAgencyName (direct to DB)
        /// </summary>
        /// <param name="originalPersonalAgencyName">originalPersonalAgencyName</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalDeleted">originalDeleted</param>        
        /// 
        /// <param name="newPersonalAgencyName">newPersonalAgencyName</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newDeleted">newDeleted</param>        
        public void UpdateDirect(string originalPersonalAgencyName, int originalCompanyId, bool originalDeleted, string newPersonalAgencyName, int newCompanyId, bool newDeleted)
        {
            EmployeePersonalAgencyGateway employeePersonalAgencyGateway = new EmployeePersonalAgencyGateway(null);
            employeePersonalAgencyGateway.Update(originalPersonalAgencyName, originalCompanyId, originalDeleted, newPersonalAgencyName, newCompanyId, newDeleted);
        }



        /// <summary>
        /// Delete PersonalAgencyName
        /// </summary>
        /// <param name="personalAgencyName">personalAgencyName</param>
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(string personalAgencyName, int companyId)
        {
            EmployeePersonalAgencyGateway employeePersonalAgencyGateway = new EmployeePersonalAgencyGateway(null);
            employeePersonalAgencyGateway.Delete(personalAgencyName, companyId);
        }



        /// <summary>
        /// Undelete PersonalAgencyName
        /// </summary>
        /// <param name="personalAgencyName">personalAgencyName</param>
        /// <param name="companyId">companyId</param>
        public void UnDeleteDirect(string personalAgencyName, int companyId)
        {
            EmployeePersonalAgencyGateway employeePersonalAgencyGateway = new EmployeePersonalAgencyGateway(null);
            employeePersonalAgencyGateway.UnDelete(personalAgencyName, companyId);
        }       

        
        
    }
}