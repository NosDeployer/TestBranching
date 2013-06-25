using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.DA.Resources.Companies;
using LiquiForce.LFSLive.DA.RAF;
using LiquiForce.LFSLive.DA.Resources.Employees;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectSynopsisReport
    /// </summary>
    public class ProjectSynopsisReport : TableModule
    {

        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectSynopsisReport()
            : base("LFS_PROJECT")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">DataSet</param>
        public ProjectSynopsisReport(DataSet data)
            : base(data, "LFS_PROJECT")
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
        /// Load
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="companyId">companyId</param>
        /// <para>Load Original table to process data for Project Costing report without filters  </para>
        public void Load(int projectId, int companyId)
        {
            // Initialization of Gateways
            ProjectGateway projectGateway = new ProjectGateway(Data);
            projectGateway.LoadByProjectId(projectId);
            int companiesId = (int)projectGateway.GetClientID(projectId);

            ProjectJobInfoGateway projectJobInfoGateway = new ProjectJobInfoGateway(Data);
            projectJobInfoGateway.LoadAllByProjectId(projectId);

            ProjectSaleBillingPricingGateway projectSaleBillingPricingGateway = new ProjectSaleBillingPricingGateway(Data);
            projectSaleBillingPricingGateway.LoadAllByProjectId(projectId);

            ProjectTechnicalGateway projectTechnicalGateway = new ProjectTechnicalGateway(Data);
            projectTechnicalGateway.LoadByProjectId(projectId);

            ProjectTermsPOGateway projectTermsPOGateway = new ProjectTermsPOGateway(Data);
            projectTermsPOGateway.LoadByProjectId(projectId);

            ProjectSubcontractorGateway projectSubcontractorGateway = new ProjectSubcontractorGateway(Data);
            projectSubcontractorGateway.LoadByProjectId(projectId);

            ProjectEngineerSubcontractorsGateway projectEngineerSubcontractorsGateway = new ProjectEngineerSubcontractorsGateway(Data);
            projectEngineerSubcontractorsGateway.LoadAllByProjectId(projectId);

            ProjectHistoryGateway projectHistoryGateway = new ProjectHistoryGateway(Data);
            projectHistoryGateway.LoadFirstRow(projectId);

            ProjectNotesGateway projectNoteGateway = new ProjectNotesGateway(Data);
            projectNoteGateway.LoadByProjectId(projectId);

            ProjectServiceGateway projectServiceGateway = new ProjectServiceGateway(Data);
            projectServiceGateway.LoadByProjectId(projectId);

            // For Updates
            // ...Get the loginId for submitted field at report

            // ...Update LFS_PROJECT
            this.UpdateForReport(projectId, companiesId, projectGateway.GetSalesmanID(projectId), (projectGateway.GetProjectLeadID(projectId)).GetValueOrDefault(), companyId);

            // ...Update LFS_PROJECT_ENGINEER_SUBCONTRACTOR
            ProjectSynopsisEngineerSubcontractors projectSynopsisEngineerSubcontractors = new ProjectSynopsisEngineerSubcontractors(Data);
            if (projectSynopsisEngineerSubcontractors.Table.Rows.Count > 0)
            {
                projectSynopsisEngineerSubcontractors.UpdateForReport(projectId, companiesId, companyId);
            }

            // ...Update LFS_PROJECT_SUBCONTRACTOR
            ProjectSynopsisSubcontractor projectSynopsisSubcontractor = new ProjectSynopsisSubcontractor(Data);
            if (projectSynopsisSubcontractor.Table.Rows.Count > 0)
            {
                projectSynopsisSubcontractor.UpdateForReport(projectId, companiesId, companyId);
            }

            // ...Update LFS_PROJECT_NOTE
            ProjectSynopsisNote projectSynopsisNote = new ProjectSynopsisNote(Data);
            if (projectSynopsisNote.Table.Rows.Count > 0)
            {
                projectSynopsisNote.UpdateForReport(projectId, companyId);
            }

            // ...Update LFS_PROJECT_SERVICE and Total Average Price
            ProjectSynopsisService projectSynopsisService = new ProjectSynopsisService(Data);
            if (projectSynopsisService.Table.Rows.Count > 0)
            {
                ProjectSynopsisReportTDS.LFS_PROJECTRow rowTotalAveragePrice = ((ProjectSynopsisReportTDS.LFS_PROJECTDataTable)Table).FindByProjectID(projectId);
                rowTotalAveragePrice.TotalAveragePrice = projectSynopsisService.UpdateForReport(projectId, companyId);
            }
        }



        /// <summary>
        /// UpdateForProcess
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="companiesId">companiesId</param>
        /// <param name="salesmanId">salesmanId</param>
        /// <param name="projectLeadId">projectLeadId</param>
        /// <param name="companyId">companyId</param>
        public void UpdateForReport(int projectId, int companiesId, int salesmanId, int projectLeadId, int companyId)
        {
            CompaniesGateway companiesGateway = new CompaniesGateway();
            AddressGateway addressGateway = new AddressGateway();
            ContactsGateway contactsGateway = new ContactsGateway();
            PhoneGateway phoneGateway = new PhoneGateway();
            EmployeeGateway employeeGateway = new EmployeeGateway();

            ProjectSynopsisReportTDS.LFS_PROJECTRow projectRow = GetProjectRow(projectId);

            // Companies Name
            companiesGateway.LoadAllByCompaniesId(companiesId, companyId);
            projectRow.ClientName = companiesGateway.GetName(companiesId);

            // Companies Address
            addressGateway.LoadByCompaniesId(companiesId, companyId);
            projectRow.ClientAddress = addressGateway.GetAddressByCompaniesId(companiesId);

            // Submitted By            
            // ...If the project has a record at history
            employeeGateway.LoadByEmployeeId(salesmanId);
            projectRow.SubmittedBy = employeeGateway.GetLastName(salesmanId) + " " + employeeGateway.GetFirstName(salesmanId);

            // ... Leaded By
            if (projectLeadId > 0)
            {
                employeeGateway.LoadByEmployeeId(projectLeadId);
                projectRow.LeadedBy = employeeGateway.GetLastName(projectLeadId) + " " + employeeGateway.GetFirstName(projectLeadId);
            }
            else
            {
                projectRow.LeadedBy = "";
            }

            // ... Primary contact
            if (!projectRow.IsClientPrimaryContactIDNull())
            {
                // ... ... Primary contact name
                contactsGateway.LoadAllByContactId(projectRow.ClientPrimaryContactID, companyId);
                projectRow.ClientPrimaryContactName = contactsGateway.GetCompleteName(projectRow.ClientPrimaryContactID);

                // ... ... Primary contact position
                projectRow.ClientPrimaryContactPosition = contactsGateway.GetCompaniesPosition(projectRow.ClientPrimaryContactID);

                // ... ... Phone
                phoneGateway.LoadByContactId(projectRow.ClientPrimaryContactID, companyId);
                projectRow.ClientPrimaryContactPhones = phoneGateway.GetPhones(projectRow.ClientPrimaryContactID);
            }

            // ... Secondary contact
            if (!projectRow.IsClientSecondaryContactIDNull())
            {
                // ... ... Primary contact name
                contactsGateway.LoadAllByContactId(projectRow.ClientSecondaryContactID, companyId);
                projectRow.ClientSecondaryContactName = contactsGateway.GetCompleteName(projectRow.ClientSecondaryContactID);

                // ... ... Primary contact position
                projectRow.ClientSecondaryContactPosition = contactsGateway.GetCompaniesPosition(projectRow.ClientSecondaryContactID);

                // ... ... Phone
                phoneGateway.LoadByContactId(projectRow.ClientSecondaryContactID, companyId);
                projectRow.ClientSecondaryContactPhones = phoneGateway.GetPhones(projectRow.ClientSecondaryContactID);
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// GetProjectRow
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>ProjectSynopsisReportTDS.LFS_PROJECTRow</returns>
        private ProjectSynopsisReportTDS.LFS_PROJECTRow GetProjectRow(int projectId)
        {
            ProjectSynopsisReportTDS.LFS_PROJECTRow row = ((ProjectSynopsisReportTDS.LFS_PROJECTDataTable)Table).FindByProjectID(projectId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Projects.Projects.Project.GetRow");
            }

            return row;
        }



    }
}
