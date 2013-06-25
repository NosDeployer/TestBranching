using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.DA.RAF;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectLoginProjectLastLogin
    /// </summary>
    public class ProjectLoginProjectLastLogin: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectLoginProjectLastLogin()
            : base("LastUsedProjects")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectLoginProjectLastLogin(DataSet data)
            : base(data, "LastUsedProjects")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ProjectTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Insert  (direct to DB)
        /// </summary>        
        /// <param name="projectId">projectId</param>
        /// <param name="userId">userId</param>
        /// <param name="lastLoggedInDate">lastLoggedInDate</param>
        /// <param name="companyId">companyId</param>
        /// <param name="deleted">deleted</param>       
        /// <returns></returns>
        public void InsertDirect(int projectId, int userId, DateTime lastLoggedInDate, int companyId, bool deleted)
        {
            ProjectLoginProjectLastLoginGateway projectLoginProjectLastLoginGateway = new ProjectLoginProjectLastLoginGateway(null);
            projectLoginProjectLastLoginGateway.Insert(projectId, userId, lastLoggedInDate, companyId, deleted);
        }



        /// <summary>
        /// UpdateDirect
        /// </summary>        
        /// <param name="originalProjectId">originalProjectId</param>
        /// <param name="originalUserId">originalUserId</param>
        /// <param name="originalLastLoggedInDate">originalLastLoggedInDate</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalDeleted">originalDeleted</param>                
        /// <param name="newProjectId">newProjectId</param>
        /// <param name="newUserId">newUserId</param>
        /// <param name="newLastLoggedInDate">newLastLoggedInDate</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newDeleted">newDeleted</param>        
        public void UpdateDirect(int originalProjectId, int originalUserId, DateTime originalLastLoggedInDate, int originalCompanyId, bool originalDeleted, int newProjectId, int newUserId, DateTime newLastLoggedInDate, int newCompanyId, bool newDeleted)
        {
            ProjectLoginProjectLastLoginGateway projectLoginProjectLastLoginGateway = new ProjectLoginProjectLastLoginGateway(null);
            projectLoginProjectLastLoginGateway.Update(originalProjectId, originalUserId, originalLastLoggedInDate, originalCompanyId, originalDeleted, newProjectId, newUserId, newLastLoggedInDate, newCompanyId, newDeleted);
        }
    }
}
