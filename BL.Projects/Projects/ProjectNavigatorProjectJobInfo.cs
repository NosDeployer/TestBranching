using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectNavigatorProjectJobInfo
    /// </summary>
    public class ProjectNavigatorProjectJobInfo : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectNavigatorProjectJobInfo()
            : base("ProjectJobInfo")
        {
        }

        

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectNavigatorProjectJobInfo(DataSet data)
            : base(data, "ProjectJobInfo")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ProjectNavigatorTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadAllByProjectId
        /// </summary>
        /// <param name="projectId">projectId</param>              
        public void LoadAllByProjectId(int projectId)
        {
            ProjectNavigatorProjectJobInfoGateway projectNavigatorProjectJobInfoGateway = new ProjectNavigatorProjectJobInfoGateway(Data);
            projectNavigatorProjectJobInfoGateway.LoadAllByProjectId(projectId);
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="projectId">ProjectId</param>
        /// <param name="typeOfWorkMhRehab">typeOfWorkMhRehab</param>
        /// <param name="typeOfWorkJuntionLining">typeOfWorkJuntionLining</param>
        /// <param name="typeOfWorkProjectManagement">typeOfWorkProjectManagement</param>
        /// <param name="typeOfWorkFullLenghtLining">typeOfWorkFullLenghtLining</param>
        /// <param name="typeOfWorkPointRepairs">typeOfWorkPointRepairs</param>
        /// <param name="typeOfWorkRehabAssessment">typeOfWorkRehabAssessment</param>      
        /// <param name="typeOfWorkGrout">typeOfWorkGrout</param>
        /// <param name="typeOfWorkOther">typeOfWorkOther</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inDatabase">inDatabase</param>        
        /// <param name="agreement">agreement</param>
        /// <param name="writtenQuote">writtenQuote</param>
        /// <param name="role">role</param>
        public void Insert(int projectId, bool typeOfWorkMhRehab, bool typeOfWorkJuntionLining, bool typeOfWorkProjectManagement, bool typeOfWorkFullLenghtLining, bool typeOfWorkPointRepairs, bool typeOfWorkRehabAssessment, bool typeOfWorkGrout, bool typeOfWorkOther, int companyId, bool inDatabase, bool agreement, bool writtenQuote, string role)
        {
            ProjectNavigatorTDS.ProjectJobInfoRow row = ((ProjectNavigatorTDS.ProjectJobInfoDataTable)Table).NewProjectJobInfoRow();
            row.ProjectID = projectId;            
            row.TypeOfWorkMhRehab = typeOfWorkMhRehab;            
            row.TypeOfWorkJuntionLining = typeOfWorkJuntionLining;
            row.TypeOfWorkProjectManagement = typeOfWorkProjectManagement;
            row.TypeOfWorkFullLenghtLining = typeOfWorkFullLenghtLining;
            row.TypeOfWorkPointRepairs = typeOfWorkPointRepairs;
            row.TypeOfWorkRehabAssessment = typeOfWorkRehabAssessment;
            row.TypeOfWorkGrout = typeOfWorkGrout;
            row.TypeOfWorkOther = typeOfWorkOther;       
            row.COMPANY_ID = companyId;
            row.InDatabase = inDatabase;
            row.Agreement = agreement;
            row.WrittenQuote = writtenQuote;
            row.Role = role;

            ((ProjectNavigatorTDS.ProjectJobInfoDataTable)Table).AddProjectJobInfoRow(row);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="typeOfWorkMhRehab">typeOfWorkMhRehab</param>
        /// <param name="typeOfWorkJuntionLining">typeOfWorkJuntionLining</param>
        /// <param name="typeOfWorkProjectManagement">typeOfWorkProjectManagement</param>
        /// <param name="typeOfWorkFullLenghtLining">typeOfWorkFullLenghtLining</param>
        /// <param name="typeOfWorkPointRepairs">typeOfWorkPointRepairs</param>
        /// <param name="typeOfWorkRehabAssessment">typeOfWorkRehabAssessment</param>      
        /// <param name="typeOfWorkGrout">typeOfWorkGrout</param>
        /// <param name="typeOfWorkOther">typeOfWorkOther</param>
        /// <param name="agreement">agreement</param>
        /// <param name="writtenQuote">writtenQuote</param>
        /// <param name="role">role</param>
        public void Update(int projectId, bool typeOfWorkMhRehab, bool typeOfWorkJuntionLining, bool typeOfWorkProjectManagement, bool typeOfWorkFullLenghtLining, bool typeOfWorkPointRepairs, bool typeOfWorkRehabAssessment, bool typeOfWorkGrout, bool typeOfWorkOther, bool agreement, bool writtenQuote, string role)
        {
            ProjectNavigatorTDS.ProjectJobInfoRow row = GetRow(projectId);

            row.TypeOfWorkMhRehab = typeOfWorkMhRehab;
            row.TypeOfWorkJuntionLining = typeOfWorkJuntionLining;
            row.TypeOfWorkProjectManagement = typeOfWorkProjectManagement;
            row.TypeOfWorkFullLenghtLining = typeOfWorkFullLenghtLining;
            row.TypeOfWorkPointRepairs = typeOfWorkPointRepairs;
            row.TypeOfWorkRehabAssessment = typeOfWorkRehabAssessment;
            row.TypeOfWorkGrout = typeOfWorkGrout;
            row.TypeOfWorkOther = typeOfWorkOther;
            row.Agreement = agreement;
            row.WrittenQuote = writtenQuote;
            row.Role = role;
        }

      
        
        /// <summary>
        /// Save all Job Info to database (direct)
        /// </summary>
        /// <param name="companyId">companyId</param>
        public void Save(int companyId)
        {
            ProjectNavigatorTDS jobInfoChanges = (ProjectNavigatorTDS)Data.GetChanges();

            if (jobInfoChanges != null)
            {
                if (jobInfoChanges.ProjectJobInfo.Rows.Count > 0)
                {
                    ProjectNavigatorProjectJobInfoGateway projectNavigatorProjectJobInfoGateway = new ProjectNavigatorProjectJobInfoGateway(jobInfoChanges);

                    foreach (ProjectNavigatorTDS.ProjectJobInfoRow row in (ProjectNavigatorTDS.ProjectJobInfoDataTable)jobInfoChanges.ProjectJobInfo)
                    {
                        // Insert new Job Info 
                        if (!row.InDatabase)
                        {                            
                            ProjectJobInfo projectService = new ProjectJobInfo(null);
                            projectService.InsertDirect(row.ProjectID, row.TypeOfWorkMhRehab, row.TypeOfWorkJuntionLining, row.TypeOfWorkProjectManagement, row.TypeOfWorkFullLenghtLining, row.TypeOfWorkPointRepairs, row.TypeOfWorkRehabAssessment, row.TypeOfWorkGrout, row.TypeOfWorkOther, row.COMPANY_ID, row.Agreement, row.Agreement, row.Role);
                        }

                        // Update Job Info
                        if (row.InDatabase)
                        {
                            int projectId = row.ProjectID;                           
                            int originalCompanyId = companyId;

                            // original values
                            bool originalTypeOfWorkMhRehab = projectNavigatorProjectJobInfoGateway.GetTypeOfWorkMhRehabOriginal(projectId);
                            bool originalTypeOfWorkJuntionLining = projectNavigatorProjectJobInfoGateway.GetTypeOfWorkJuntionLiningOriginal(projectId);
                            bool originalTypeOfWorkProjectManagement = projectNavigatorProjectJobInfoGateway.GetTypeOfWorkProjectManagementOriginal(projectId);
                            bool originalTypeOfWorkFullLenghtLining = projectNavigatorProjectJobInfoGateway.GetTypeOfWorkFullLenghtLiningOriginal(projectId);
                            bool originalTypeOfWorkPointRepairs = projectNavigatorProjectJobInfoGateway.GetTypeOfWorkPointRepairsOriginal(projectId);
                            bool originalTypeOfWorkRehabAssessment = projectNavigatorProjectJobInfoGateway.GetTypeOfWorkRehabAssessmentOriginal(projectId);
                            bool originalTypeOfWorkGrout = projectNavigatorProjectJobInfoGateway.GetTypeOfWorkGroutOriginal(projectId);
                            bool originalTypeOfWorkOther = projectNavigatorProjectJobInfoGateway.GetTypeOfWorkOtherOriginal(projectId);
                            bool originalAgreement = projectNavigatorProjectJobInfoGateway.GetAgreementOriginal(projectId);
                            bool originalWrittenQuote = projectNavigatorProjectJobInfoGateway.GetWrittenQuoteOriginal(projectId);
                            string originalRole = projectNavigatorProjectJobInfoGateway.GetRoleOriginal(projectId);

                            // new values
                            bool newTypeOfWorkMhRehab = projectNavigatorProjectJobInfoGateway.GetTypeOfWorkMhRehab(projectId);
                            bool newTypeOfWorkJuntionLining = projectNavigatorProjectJobInfoGateway.GetTypeOfWorkJuntionLining(projectId);
                            bool newTypeOfWorkProjectManagement = projectNavigatorProjectJobInfoGateway.GetTypeOfWorkProjectManagement(projectId);
                            bool newTypeOfWorkFullLenghtLining = projectNavigatorProjectJobInfoGateway.GetTypeOfWorkFullLenghtLining(projectId);
                            bool newTypeOfWorkPointRepairs = projectNavigatorProjectJobInfoGateway.GetTypeOfWorkPointRepairs(projectId);
                            bool newTypeOfWorkRehabAssessment = projectNavigatorProjectJobInfoGateway.GetTypeOfWorkRehabAssessment(projectId);
                            bool newTypeOfWorkGrout = projectNavigatorProjectJobInfoGateway.GetTypeOfWorkGrout(projectId);
                            bool newTypeOfWorkOther = projectNavigatorProjectJobInfoGateway.GetTypeOfWorkOther(projectId);
                            bool newAgreement = projectNavigatorProjectJobInfoGateway.GetAgreement(projectId);
                            bool newWrittenQuote = projectNavigatorProjectJobInfoGateway.GetWrittenQuote(projectId);
                            string newRole = projectNavigatorProjectJobInfoGateway.GetRole(projectId);

                            ProjectJobInfo projectService = new ProjectJobInfo(null);
                            projectService.UpdateDirect(projectId, originalTypeOfWorkMhRehab, originalTypeOfWorkJuntionLining, originalTypeOfWorkProjectManagement, originalTypeOfWorkFullLenghtLining, originalTypeOfWorkPointRepairs, originalTypeOfWorkRehabAssessment, originalTypeOfWorkGrout, originalTypeOfWorkOther, originalCompanyId, originalAgreement, originalWrittenQuote, originalRole, projectId, newTypeOfWorkMhRehab, newTypeOfWorkJuntionLining, newTypeOfWorkProjectManagement, newTypeOfWorkFullLenghtLining, newTypeOfWorkPointRepairs, newTypeOfWorkRehabAssessment, newTypeOfWorkGrout, newTypeOfWorkOther, originalCompanyId,  newAgreement, newWrittenQuote, newRole);
                        }                       
                    }
                }
            }
        }
      




        
        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //
        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="projectId">projectId</param>        
        /// <returns>ProjectNavigatorTDS.ProjectJobInfoRow</returns>
        private ProjectNavigatorTDS.ProjectJobInfoRow GetRow(int projectId)
        {
            ProjectNavigatorTDS.ProjectJobInfoRow row = ((ProjectNavigatorTDS.ProjectJobInfoDataTable)Table).FindByProjectID(projectId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Projects.Projects.ProjectNavigatorProjectJobInfo.GetRow");
            }

            return row;
        }      

    }
}
