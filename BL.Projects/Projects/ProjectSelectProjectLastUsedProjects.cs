using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectSelectProjectLastUsedProjects
    /// </summary>
    public class ProjectSelectProjectLastUsedProjects : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectSelectProjectLastUsedProjects()
            : base("LastUsedProjects")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectSelectProjectLastUsedProjects(DataSet data)
            : base(data, "LastUsedProjects")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ProjectSelectProjectTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Insert a login
        /// </summary>        
        /// <param name="projectId">projectId</param>
        /// <param name="userId">userId</param>
        /// <param name="lastLoggedInDate">lastLoggedInDate</param>
        /// <param name="companyId">companyId</param>
        /// <param name="deleted">deleted</param>        
        /// <param name="projectName">projectName</param>        
        /// <param name="inDataBase">inDataBase</param>
        public void Insert(int projectId, int userId, DateTime lastLoggedInDate, int companyId, bool deleted, string projectName, bool inDataBase)
        {
            ProjectSelectProjectTDS.LastUsedProjectsRow row = ((ProjectSelectProjectTDS.LastUsedProjectsDataTable)Table).NewLastUsedProjectsRow();
            
            row.ProjectID = projectId;
            row.UserID = userId;
            row.LastLoggedInDate = lastLoggedInDate;
            row.COMPANY_ID = companyId;
            row.Deleted = deleted;            
            row.ProjectName = projectName;            
            row.InDataBase = inDataBase;

            ((ProjectSelectProjectTDS.LastUsedProjectsDataTable)Table).AddLastUsedProjectsRow(row);
        }



        /// <summary>
        /// Update a project login
        /// </summary>        
        /// <param name="newProjectId">newProjectId</param>
        /// <param name="newUserId">newUserId</param>
        /// <param name="newLastLoggedInDate">newLastLoggedInDate</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newProjectName">newProjectName</param>
        public void Update(int newProjectId, int newUserId, DateTime newLastLoggedInDate, int newCompanyId, bool newDeleted, string newProjectName)
        {
            int count = 1;
            foreach (ProjectSelectProjectTDS.LastUsedProjectsRow row in (ProjectSelectProjectTDS.LastUsedProjectsDataTable)Table)
            {
                if (count == 5)
                {
                    row.ProjectID = newProjectId;
                    row.UserID = newUserId;
                    row.LastLoggedInDate = newLastLoggedInDate;
                    row.COMPANY_ID = newCompanyId;
                    row.Deleted = newDeleted;
                    row.ProjectName = newProjectName;
                }

                count = count + 1;
            }
        }



        /// <summary>
        /// Update a project login
        /// </summary>        
        /// <param name="newProjectId">newProjectId</param>
        /// <param name="newLastLoggedInDate">newLastLoggedInDate</param>
        public void UpdateLogginDate(int newProjectId, DateTime newLastLoggedInDate)
        {
            foreach (ProjectSelectProjectTDS.LastUsedProjectsRow row in (ProjectSelectProjectTDS.LastUsedProjectsDataTable)Table)
            {
                if (row.ProjectID == newProjectId)
                {
                    row.LastLoggedInDate = newLastLoggedInDate;
                }
            }            
        }



        /// <summary>
        /// Exist project
        /// </summary>        
        /// <param name="projectId">projectId</param>
        /// <returns>true if project exists</returns>
        public bool ExistProject(int projectId)
        {
            bool exists = false;
            foreach (ProjectSelectProjectTDS.LastUsedProjectsRow row in (ProjectSelectProjectTDS.LastUsedProjectsDataTable)Table)
            {
                if (row.ProjectID == projectId)
                {
                    exists = true;  
                }
            }

            return exists;
        }



        /// <summary>
        /// Save all last logged projects to database (direct)
        /// </summary>
        /// <param name="companyId">companyId</param>        
        public void Save(int companyId)
        {
            ProjectSelectProjectTDS lastUsedProjectsChanges = (ProjectSelectProjectTDS)Data.GetChanges();

            if (lastUsedProjectsChanges.LastUsedProjects.Rows.Count > 0)
            {
                ProjectSelectProjectLastUsedProjectsGateway projectSelectProjectLastUsedProjectsGateway = new ProjectSelectProjectLastUsedProjectsGateway(lastUsedProjectsChanges);

                foreach (ProjectSelectProjectTDS.LastUsedProjectsRow row in (ProjectSelectProjectTDS.LastUsedProjectsDataTable)lastUsedProjectsChanges.LastUsedProjects)
                {
                    // Insert project login
                    if ((!row.Deleted)&& (!row.InDataBase))
                    {
                        ProjectLoginProjectLastLogin projectLoginProjectLastLogin = new ProjectLoginProjectLastLogin(null);
                        projectLoginProjectLastLogin.InsertDirect( row.ProjectID, row.UserID, row.LastLoggedInDate, row.COMPANY_ID, row.Deleted);
                    }

                    // Update project login
                    if ((!row.Deleted) && (row.InDataBase))
                    {
                        int projectId = row.ProjectID;                        
                        int userId = row.UserID;                                                

                        // Original Values                        
                        int originalProjectId = projectSelectProjectLastUsedProjectsGateway.GetProjectIdOriginal(projectId, userId, companyId);
                        int originalUserId = projectSelectProjectLastUsedProjectsGateway.GetUserIdOriginal(projectId, userId, companyId);
                        DateTime originalLastLoggedInDate = projectSelectProjectLastUsedProjectsGateway.GetLastLoggedInDateOriginal(projectId, userId, companyId);
                        int originalCompanyId = projectSelectProjectLastUsedProjectsGateway.GetCompanyIdOriginal(projectId, userId, companyId);                        

                        // New Values                        
                        int newProjectId = projectSelectProjectLastUsedProjectsGateway.GetProjectId(projectId, userId, companyId);
                        int newUserId = projectSelectProjectLastUsedProjectsGateway.GetUserId(projectId, userId, companyId);
                        DateTime newLastLoggedInDate = projectSelectProjectLastUsedProjectsGateway.GetLastLoggedInDate(projectId, userId, companyId);
                        int newCompanyId = projectSelectProjectLastUsedProjectsGateway.GetCompanyId(projectId, userId, companyId);                        

                        ProjectLoginProjectLastLogin projectLoginProjectLastLogin = new ProjectLoginProjectLastLogin(null);
                        projectLoginProjectLastLogin.UpdateDirect(originalProjectId, originalUserId, originalLastLoggedInDate, originalCompanyId, false,  newProjectId, newUserId, newLastLoggedInDate, newCompanyId, false);
                    }
                }
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// Get a single row. If not exists, raise an exception.
        /// </summary>
        /// <param name="projectId">projectId</param>        
        /// <param name="userId">userId</param>
        /// <param name="companyId">companyId</param>        
        /// <returns>Row obtained</returns>
        private ProjectSelectProjectTDS.LastUsedProjectsRow GetRow(int projectId, int userId, int companyId)
        {
            ProjectSelectProjectTDS.LastUsedProjectsRow row = ((ProjectSelectProjectTDS.LastUsedProjectsDataTable)Table).FindByProjectIDUserIDCOMPANY_ID(projectId,  userId, companyId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Projects.Projects.SelectProjectLastUsedProjects.GetRow");
            }

            return row;
        }

                
    }
}