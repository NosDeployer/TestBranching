using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.DA.CWP.Common;
using LiquiForce.LFSLive.BL.CWP.Works;

namespace LiquiForce.LFSLive.BL.CWP.Common
{
    /// <summary>
    /// SelectProjectLastUsedProjects
    /// </summary>
    public class SelectProjectLastUsedProjects : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public SelectProjectLastUsedProjects()
            : base("LastUsedProjects")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public SelectProjectLastUsedProjects(DataSet data)
            : base(data, "LastUsedProjects")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new SelectProjectTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Insert a login
        /// </summary>
        /// <param name="clientId">clientId</param>
        /// <param name="projectId">rojectId</param>
        /// <param name="userId">userId</param>
        /// <param name="lastLoggedInDate">lastLoggedInDate</param>
        /// <param name="companyId">companyId</param>
        /// <param name="deleted">deleted</param>
        /// <param name="workType">workType</param>
        /// <param name="projectName">projectName</param>
        /// <param name="clientName">clientName</param>        
        /// <param name="inDataBase">inDataBase</param>
        public void Insert(int clientId, int projectId, int userId, DateTime lastLoggedInDate, int companyId, bool deleted, string workType, string projectName, string clientName, bool inDataBase)
        {
            SelectProjectTDS.LastUsedProjectsRow row = ((SelectProjectTDS.LastUsedProjectsDataTable)Table).NewLastUsedProjectsRow();

            row.ClientID = clientId;
            row.ProjectID = projectId;
            row.UserID = userId;
            row.LastLoggedInDate = lastLoggedInDate;
            row.COMPANY_ID = companyId;
            row.Deleted = deleted;
            row.WorkType = workType;
            row.ProjectName = projectName;
            row.ClientName = clientName;
            row.InDataBase = inDataBase;

            ((SelectProjectTDS.LastUsedProjectsDataTable)Table).AddLastUsedProjectsRow(row);
        }



        /// <summary>
        /// Update a project login
        /// </summary>
        /// <param name="clientId">clientId</param>
        /// <param name="projectId">rojectId</param>
        /// <param name="userId">userId</param>        
        /// <param name="companyId">companyId</param>        
        /// <param name="workType">workType</param>
        /// <param name="projectName">projectName</param>
        /// <param name="clientName">clientName</param>        
        public void Update(int clientId, int projectId, int userId, int companyId, string workType, int newClientId, int newProjectId, int newUserId, DateTime newLastLoggedInDate, int newCompanyId, bool newDeleted, string newWorkType, string newProjectName, string newClientName)
        {
            SelectProjectTDS.LastUsedProjectsRow row = GetRow(projectId, clientId, userId, companyId, workType);

            row.ClientID = newClientId;
            row.ProjectID = newProjectId;
            row.UserID = newUserId;
            row.LastLoggedInDate = newLastLoggedInDate;
            row.COMPANY_ID = newCompanyId;
            row.Deleted = newDeleted;
            row.WorkType = newWorkType;
            row.ProjectName = newProjectName;
            row.ClientName = newClientName;
        }



        /// <summary>
        /// Update a project login
        /// </summary>
        /// <param name="clientId">clientId</param>
        /// <param name="projectId">rojectId</param>
        /// <param name="userId">userId</param>
        /// <param name="lastLoggedInDate">lastLoggedInDate</param>
        /// <param name="companyId">companyId</param>
        /// <param name="deleted">deleted</param>
        /// <param name="workType">workType</param>              
        public void UpdateLogginDate(int clientId, int projectId, int userId, DateTime lastLoggedInDate, int companyId, bool deleted, string workType, DateTime newLastLoggedInDate)
        {
            SelectProjectTDS.LastUsedProjectsRow row = GetRow(projectId, clientId, userId, companyId, workType);
            row.LastLoggedInDate = newLastLoggedInDate;
        }



        /// <summary>
        /// Save all comments to database (direct)
        /// </summary>
        /// <param name="companyId">companyId</param>        
        public void Save(int companyId)
        {
            SelectProjectTDS lastUsedProjectsChanges = (SelectProjectTDS)Data.GetChanges();

            if (lastUsedProjectsChanges.LastUsedProjects.Rows.Count > 0)
            {
                SelectProjectLastUsedProjectsGateway selectProjectLastUsedProjectsGateway = new SelectProjectLastUsedProjectsGateway(lastUsedProjectsChanges);

                foreach (SelectProjectTDS.LastUsedProjectsRow row in (SelectProjectTDS.LastUsedProjectsDataTable)lastUsedProjectsChanges.LastUsedProjects)
                {
                    // Insert project login
                    if ((!row.Deleted)&& (!row.InDataBase))
                    {
                        WorkProjectLoginProjectLastLogin workProjectLoginProjectLastLogin = new WorkProjectLoginProjectLastLogin(null);
                        workProjectLoginProjectLastLogin.InsertDirect(row.ClientID, row.ProjectID, row.UserID, row.LastLoggedInDate, row.COMPANY_ID, row.Deleted, row.WorkType);
                    }

                    // Update project login
                    if ((!row.Deleted) && (row.InDataBase))
                    {
                        int projectId = row.ProjectID;
                        int clientId = row.ClientID;
                        int userId = row.UserID;                        
                        string workType = row.WorkType;

                        // Original Values
                        int originalClientId = selectProjectLastUsedProjectsGateway.GetClientIdOriginal(projectId, clientId, userId, companyId, workType);
                        int originalProjectId = selectProjectLastUsedProjectsGateway.GetProjectIdOriginal(projectId, clientId, userId, companyId, workType);
                        int originalUserId = selectProjectLastUsedProjectsGateway.GetUserIdOriginal(projectId, clientId, userId, companyId, workType);
                        DateTime originalLastLoggedInDate = selectProjectLastUsedProjectsGateway.GetLastLoggedInDateOriginal(projectId, clientId, userId, companyId, workType);
                        int originalCompanyId = selectProjectLastUsedProjectsGateway.GetCompanyIdOriginal(projectId, clientId, userId, companyId, workType);
                        string originalWorkType = selectProjectLastUsedProjectsGateway.GetWorkTypeOriginal(projectId, clientId, userId, companyId, workType);

                        // New Values
                        int newClientId = selectProjectLastUsedProjectsGateway.GetClientId(projectId, clientId, userId, companyId, workType);
                        int newProjectId = selectProjectLastUsedProjectsGateway.GetProjectId(projectId, clientId, userId, companyId, workType);
                        int newUserId = selectProjectLastUsedProjectsGateway.GetUserId(projectId, clientId, userId, companyId, workType);
                        DateTime newLastLoggedInDate = selectProjectLastUsedProjectsGateway.GetLastLoggedInDate(projectId, clientId, userId, companyId, workType);
                        int newCompanyId = selectProjectLastUsedProjectsGateway.GetCompanyId(projectId, clientId, userId, companyId, workType);
                        string newWorkType = selectProjectLastUsedProjectsGateway.GetWorkType(projectId, clientId, userId, companyId, workType);

                        WorkProjectLoginProjectLastLogin workProjectLoginProjectLastLogin = new WorkProjectLoginProjectLastLogin(null);
                        workProjectLoginProjectLastLogin.UpdateDirect(originalClientId, originalProjectId, originalUserId, originalLastLoggedInDate, originalCompanyId, false, originalWorkType, newClientId, newProjectId, newUserId, newLastLoggedInDate, newCompanyId, false, newWorkType);
                    }
                }
            }
        }






        //// ////////////////////////////////////////////////////////////////////////
        //// PRIVATE METHODS
        ////

        /// <summary>
        /// Get a single row. If not exists, raise an exception.
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="clientId">clientId</param>
        /// <param name="userId">userId</param>
        /// <param name="lastloggedInDate">lastloggedInDate</param>
        /// <param name="companyId">companyId</param>
        /// <param name="workType">workType</param>
        /// <returns>Row obtained</returns>
        private SelectProjectTDS.LastUsedProjectsRow GetRow(int projectId, int clientId, int userId, int companyId, string workType)
        {
            SelectProjectTDS.LastUsedProjectsRow row = ((SelectProjectTDS.LastUsedProjectsDataTable)Table).FindByProjectIDClientIDUserIDCOMPANY_IDWorkType(projectId, clientId, userId, companyId, workType);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.CWP.Common.SelectProjectLastUsedProjects.GetRow");
            }

            return row;
        }

                
    }
}

