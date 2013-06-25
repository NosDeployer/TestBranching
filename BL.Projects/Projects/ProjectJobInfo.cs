using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectJobInfo
    /// </summary>
    public class ProjectJobInfo : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectJobInfo()
            : base("LFS_PROJECT_JOB_INFO")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectJobInfo(DataSet data)
            : base(data, "LFS_PROJECT_JOB_INFO")
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
        /// Insert job info
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
        /// <param name="companyId">companyId</param>        
        /// <param name="agreement">agreement</param>
        /// <param name="writtenQuote">writtenQuote</param>
        /// <param name="role">role</param>
        /// <returns>CostingSheetID</returns>
        public void InsertDirect(int projectId, bool typeOfWorkMhRehab, bool typeOfWorkJuntionLining, bool typeOfWorkProjectManagement, bool typeOfWorkFullLenghtLining, bool typeOfWorkPointRepairs, bool typeOfWorkRehabAssessment, bool typeOfWorkGrout, bool typeOfWorkOther, int companyId, bool agreement, bool writtenQuote, string role)
        {
            // Insert costing sheet and get costing sheet ID
            ProjectJobInfoGateway projectJobInfoGateway = new ProjectJobInfoGateway(null);
            projectJobInfoGateway.Insert(projectId, typeOfWorkMhRehab, typeOfWorkJuntionLining, typeOfWorkProjectManagement, typeOfWorkFullLenghtLining, typeOfWorkPointRepairs, typeOfWorkRehabAssessment, typeOfWorkGrout, typeOfWorkOther, companyId, agreement, writtenQuote, role);            
        }



        /// <summary>
        /// Update job info
        /// </summary>
        /// <param name="originalProjectId">originalProjectId</param>
        /// <param name="originalTypeOfWorkMhRehab">originalTypeOfWorkMhRehab</param>
        /// <param name="originalTypeOfWorkJuntionLining">originalTypeOfWorkJuntionLining</param>
        /// <param name="originalTypeOfWorkProjectManagement">originalTypeOfWorkProjectManagement</param>
        /// <param name="originalTypeOfWorkFullLenghtLining">originalTypeOfWorkFullLenghtLining</param>
        /// <param name="originalTypeOfWorkPointRepairs">originalTypeOfWorkPointRepairs</param>
        /// <param name="originaltypeOfWorkRehabAssessment">originaltypeOfWorkRehabAssessment</param>
        /// <param name="originalTypeOfWorkGrout">originalTypeOfWorkGrout</param>
        /// <param name="originalTypeOfWorkOther">originalTypeOfWorkOther</param>
        /// <param name="originalCompanyId">originalCompanyId</param>  
        /// <param name="originalAgreement">originalAgreement</param>
        /// <param name="originalWrittenQuote">originalWrittenQuote</param>
        /// <param name="originalRole">originalRole</param>
        /// 
        /// <param name="newProjectId">newProjectId</param>
        /// <param name="newTypeOfWorkMhRehab">newTypeOfWorkMhRehab</param>
        /// <param name="newTypeOfWorkJuntionLining">newTypeOfWorkJuntionLining</param>
        /// <param name="newTypeOfWorkProjectManagement">newTypeOfWorkProjectManagement</param>
        /// <param name="newTypeOfWorkFullLenghtLining">newTypeOfWorkFullLenghtLining</param>
        /// <param name="newTypeOfWorkPointRepairs">newTypeOfWorkPointRepairs</param>
        /// <param name="newtypeOfWorkRehabAssessment">newtypeOfWorkRehabAssessment</param>
        /// <param name="newTypeOfWorkGrout">newTypeOfWorkGrout</param>
        /// <param name="newTypeOfWorkOther">newTypeOfWorkOther</param>
        /// <param name="newCompanyId">newCompanyId</param>      
        /// <param name="newAgreement">newAgreement</param>
        /// <param name="newWrittenQuote">newWrittenQuote</param>       
        /// <param name="newRole">newRole</param>
        public void UpdateDirect(int originalProjectId, bool originalTypeOfWorkMhRehab, bool originalTypeOfWorkJuntionLining, bool originalTypeOfWorkProjectManagement, bool originalTypeOfWorkFullLenghtLining, bool originalTypeOfWorkPointRepairs, bool originaltypeOfWorkRehabAssessment, bool originalTypeOfWorkGrout, bool originalTypeOfWorkOther, int originalCompanyId, bool originalAgreement, bool originalWrittenQuote, string originalRole, int newProjectId, bool newTypeOfWorkMhRehab, bool newTypeOfWorkJuntionLining, bool newTypeOfWorkProjectManagement, bool newTypeOfWorkFullLenghtLining, bool newTypeOfWorkPointRepairs, bool newtypeOfWorkRehabAssessment, bool newTypeOfWorkGrout, bool newTypeOfWorkOther, int newCompanyId, bool newAgreement, bool newWrittenQuote, string newRole)
        {
            ProjectJobInfoGateway projectJobInfoGateway = new ProjectJobInfoGateway(null);
            projectJobInfoGateway.Update(originalProjectId, originalTypeOfWorkMhRehab, originalTypeOfWorkJuntionLining, originalTypeOfWorkProjectManagement, originalTypeOfWorkFullLenghtLining, originalTypeOfWorkPointRepairs, originaltypeOfWorkRehabAssessment, originalTypeOfWorkGrout, originalTypeOfWorkOther, originalCompanyId, originalAgreement, originalWrittenQuote, originalRole, newProjectId, newTypeOfWorkMhRehab, newTypeOfWorkJuntionLining, newTypeOfWorkProjectManagement, newTypeOfWorkFullLenghtLining, newTypeOfWorkPointRepairs, newtypeOfWorkRehabAssessment, newTypeOfWorkGrout, newTypeOfWorkOther, newCompanyId, newAgreement, newWrittenQuote, newRole);
        }

      
    }
}