using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.DA.Resources.Companies;
using LiquiForce.LFSLive.DA.RAF;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectSynopsisReport
    /// </summary>
    public class ProjectSynopsisEngineerSubcontractors : TableModule
    {

        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //



        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectSynopsisEngineerSubcontractors()
            : base("LFS_PROJECT_ENGINEER_SUBCONTRACTORS")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">DataSet</param>
        public ProjectSynopsisEngineerSubcontractors(DataSet data)
            : base(data, "LFS_PROJECT_ENGINEER_SUBCONTRACTORS")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ProjectSynopsisReportTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// UpdateForProcess
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="companiesId">companiesId</param>
        /// <param name="companyId">companyId</param>
        public void UpdateForReport(int projectId, int companiesId, int companyId)
        {
            CompaniesGateway companiesGateway = new CompaniesGateway();
            ContactsGateway contactsGateway = new ContactsGateway();

            ProjectSynopsisReportTDS.LFS_PROJECT_ENGINEER_SUBCONTRACTORSRow engineerSubcontractorRow = GetIngenierSubcontractorRow(projectId);


            // For LFS_PROJECT_ENGINEER_SUBCONTRACTORS
            // ... Engineering Firm Name
            if (!engineerSubcontractorRow.IsEngineeringFirmIDNull())
            {
                companiesGateway.LoadAllByCompaniesId((int)engineerSubcontractorRow.EngineeringFirmID, companyId);
                engineerSubcontractorRow.EngineerFirmName = companiesGateway.GetName((int)engineerSubcontractorRow.EngineeringFirmID);
            }

            // ... Engineering Name
            if (!engineerSubcontractorRow.IsEngineerIDNull())
            {
                contactsGateway.LoadAllByContactId((int)engineerSubcontractorRow.EngineerID, companyId); 
                engineerSubcontractorRow.EngineerName = contactsGateway.GetCompleteName((int)engineerSubcontractorRow.EngineerID);
            }

        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //
        
        /// <summary>
        /// GetIngenierSubcontractorRow
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>ProjectSynopsisReportTDS.LFS_PROJECT_ENGINEER_SUBCONTRACTORSRow</returns>

        private ProjectSynopsisReportTDS.LFS_PROJECT_ENGINEER_SUBCONTRACTORSRow GetIngenierSubcontractorRow(int projectId)
        {
            ProjectSynopsisReportTDS.LFS_PROJECT_ENGINEER_SUBCONTRACTORSRow row = ((ProjectSynopsisReportTDS.LFS_PROJECT_ENGINEER_SUBCONTRACTORSDataTable)Table).FindByProjectID(projectId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Projects.Projects.Project.GetRow");
            }

            return row;
        }



    }
}
