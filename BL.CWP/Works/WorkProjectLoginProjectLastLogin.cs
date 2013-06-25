using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.DA.CWP.Works;
using LiquiForce.LFSLive.DA.RAF;

namespace LiquiForce.LFSLive.BL.CWP.Works
{
    /// <summary>
    /// WorkProjectLoginProjectLastLogin
    /// </summary>
    public class WorkProjectLoginProjectLastLogin: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkProjectLoginProjectLastLogin()
            : base("LastUsedProjects")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkProjectLoginProjectLastLogin(DataSet data)
            : base(data, "LastUsedProjects")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new WorkProjectLoginTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Insert  (direct to DB)
        /// </summary>
        /// <param name="clientId">clientId</param>
        /// <param name="projectId">projectId</param>
        /// <param name="userId">userId</param>
        /// <param name="lastLoggedInDate">lastLoggedInDate</param>
        /// <param name="companyId">companyId</param>
        /// <param name="deleted">deleted</param>
        /// <param name="workType">workType</param>
        /// <returns></returns>
        public void InsertDirect(int clientId, int projectId, int userId, DateTime lastLoggedInDate, int companyId, bool deleted, string workType)
        {
            WorkProjectLoginProjectLastLoginGateway workProjectLoginProjectLastLoginGateway = new WorkProjectLoginProjectLastLoginGateway(null);
            workProjectLoginProjectLastLoginGateway.Insert(projectId, clientId, userId, lastLoggedInDate, companyId, deleted, workType);
        }



        /// <summary>
        /// UpdateDirect
        /// </summary>
        /// <param name="originalClientId">originalClientId</param>
        /// <param name="originalProjectId">originalProjectId</param>
        /// <param name="originalUserId">originalUserId</param>
        /// <param name="originalLastLoggedInDate">originalLastLoggedInDate</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalWorkType">originalWorkType</param>
        /// <param name="newClientId">newClientId</param>
        /// <param name="newProjectId">newProjectId</param>
        /// <param name="newUserId">newUserId</param>
        /// <param name="newLastLoggedInDate">newLastLoggedInDate</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newWorkType">newWorkType</param>
        public void UpdateDirect(int originalClientId, int originalProjectId, int originalUserId, DateTime originalLastLoggedInDate, int originalCompanyId, bool originalDeleted, string originalWorkType, int newClientId, int newProjectId, int newUserId, DateTime newLastLoggedInDate, int newCompanyId, bool newDeleted, string newWorkType)
        {
            WorkProjectLoginProjectLastLoginGateway workProjectLoginProjectLastLoginGateway = new WorkProjectLoginProjectLastLoginGateway(null);
            workProjectLoginProjectLastLoginGateway.Update(originalClientId, originalProjectId, originalUserId, originalLastLoggedInDate, originalCompanyId, originalDeleted, originalWorkType, newClientId, newProjectId, newUserId, newLastLoggedInDate, newCompanyId, newDeleted, newWorkType);
        }
    }
}
