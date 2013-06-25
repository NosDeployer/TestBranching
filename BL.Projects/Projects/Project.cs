using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Company.Organization;
using LiquiForce.LFSLive.DA.Resources.Employees;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// Project
    /// </summary>
    public class Project : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public Project() : base("LFS_PROJECT")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public Project(DataSet data) : base(data, "LFS_PROJECT")
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
        /// Insert project
        /// </summary>
        /// <param name="countryId">CountryId</param>
        /// <param name="officeId">OfficeId</param>
        /// <param name="projectLeadId">ProjectLeadId - EmployeeId</param>
        /// <param name="salesmanId">SalesmanId - EmployeeId</param>
        /// <param name="projectNumber">Project Number (previously generated)</param>
        /// <param name="projectType">Project Type</param>
        /// <param name="projectState">Project State</param>
        /// <param name="name">Project Name</param>
        /// <param name="description">Project Description</param>
        /// <param name="proposalDate">Proposal Date</param>
        /// <param name="starDate">Start Date</param>
        /// <param name="endDate">End Date</param>
        /// <param name="clientId">ClientId - CompaniesId (RAF)</param>
        /// <param name="clientPrimaryContactID">Client Primary Contact ID</param>
        /// <param name="clientSecondaryContactID">Client Secondary Contact ID</param>
        /// <param name="clientProjectNumber">Client Project Number</param>
        /// <param name="deleted">Deleted</param>
        /// <param name="originalProjectID">Original Project ID</param>
        /// <param name="projectNumberCopy">Project Number Copy</param>
        /// <param name="libraryCategoriesId">Library Categories ID</param>
        /// <param name="companyId">companyId</param>
        /// <param name="cityId">cityId</param>
        /// <param name="provinceId">provinceId</param>
        /// <param name="startDate">startDate</param>
        /// <param name="countyId">countyId</param>
        /// <param name="fairWageApplies">fairWageApplies</param>
        public void Insert(Int64 countryId, int officeId, int? projectLeadId, int salesmanId, string projectNumber, string projectType, string projectState, string name, string description, DateTime? proposalDate, DateTime? startDate, DateTime? endDate, int clientId, int? clientPrimaryContactID, int? clientSecondaryContactID, string clientProjectNumber, bool deleted, int? originalProjectID, int? projectNumberCopy, int? libraryCategoriesId, Int64? provinceId, Int64? cityId, int companyId, Int64? countyId, bool fairWageApplies)
        {
            // Insert new project
            ProjectTDS.LFS_PROJECTRow projectRow = ((ProjectTDS.LFS_PROJECTDataTable)Table).NewLFS_PROJECTRow();
            projectRow.CountryID = countryId;
            projectRow.OfficeID = officeId;
            if (projectLeadId.HasValue) projectRow.ProjectLeadID = (int)projectLeadId; else projectRow.SetProjectLeadIDNull();
            projectRow.SalesmanID = salesmanId;
            projectRow.ProjectNumber = projectNumber;
            projectRow.ProjectType = projectType;
            projectRow.ProjectState = projectState;
            if (name.Trim() != "") projectRow.Name = name.Trim(); else projectRow.SetNameNull();
            if (description.Trim() != "") projectRow.Description = description.Trim(); else projectRow.SetDescriptionNull();
            if (proposalDate.HasValue) projectRow.ProposalDate = (DateTime)proposalDate; else projectRow.SetProposalDateNull();
            if (startDate.HasValue) projectRow.StartDate = (DateTime)startDate; else projectRow.SetStartDateNull();
            if (endDate.HasValue) projectRow.EndDate = (DateTime)endDate; else projectRow.SetEndDateNull();
            projectRow.ClientID = clientId;
            if (clientPrimaryContactID.HasValue) projectRow.ClientPrimaryContactID = (int)clientPrimaryContactID; else projectRow.SetClientPrimaryContactIDNull();
            if (clientSecondaryContactID.HasValue) projectRow.ClientSecondaryContactID = (int)clientSecondaryContactID; else projectRow.SetClientSecondaryContactIDNull();
            if (clientProjectNumber.Trim() != "") projectRow.ClientProjectNumber = clientProjectNumber.Trim(); else projectRow.SetClientProjectNumberNull();
            projectRow.Deleted = deleted;
            if (originalProjectID.HasValue) projectRow.OriginalProjectID = (int)originalProjectID; else projectRow.SetOriginalProjectIDNull();
            if (projectNumberCopy.HasValue) projectRow.ProjectNumberCopy = (int)projectNumberCopy; else projectRow.SetProjectNumberCopyNull();
            if (libraryCategoriesId.HasValue) projectRow.LIBRARY_CATEGORIES_ID = (int)libraryCategoriesId; else projectRow.SetLIBRARY_CATEGORIES_IDNull();
            if (provinceId.HasValue) projectRow.ProvinceID = (int)provinceId; else projectRow.SetProvinceIDNull();
            if (cityId.HasValue) projectRow.CityID = (Int64)cityId; else projectRow.SetCityIDNull();
            projectRow.COMPANY_ID = companyId;
            if (countyId.HasValue) projectRow.CountyID = (Int64)countyId; else projectRow.SetCountyIDNull();
            projectRow.FairWageApplies = fairWageApplies;
            ((ProjectTDS.LFS_PROJECTDataTable)Table).AddLFS_PROJECTRow(projectRow);
        }

        

        /// <summary>
        /// Update Project
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="countryId">countryId</param>
        /// <param name="officeId">officeId</param>
        /// <param name="projectLeadId">projectLeadId</param>
        /// <param name="salesmanId">salesmanId</param>
        /// <param name="projectNumber">projectNumber</param>
        /// <param name="projectType">projectType</param>
        /// <param name="projectState">projectState</param>
        /// <param name="name">name</param>
        /// <param name="description">description</param>
        /// <param name="proposalDate">proposalDate</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="clientId">clientId</param>
        /// <param name="clientProjectNumber">clientProjectNumber</param>
        /// <param name="clientPrimaryContactId">clientPrimaryContactId</param>
        /// <param name="clientSecondaryContactId">clientSecondaryContactId</param>
        /// <param name="deleted">deleted</param>
        /// <param name="libraryCategoriesId">libraryCategoriesId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="provinceId">provinceId</param>
        /// <param name="cityId">cityId</param>
        /// <param name="countyId">countyId</param>
        /// <param name="fairWageApplies">fairWageApplies</param>
        public void Update(int projectId, Int64 countryId, int officeId, int? projectLeadId, int salesmanId, string projectNumber, string projectType, string projectState, string name, string description, DateTime? proposalDate, DateTime? startDate, DateTime? endDate, int clientId, string clientProjectNumber, int? clientPrimaryContactId, int? clientSecondaryContactId, bool deleted, int? libraryCategoriesId, Int64? provinceId, Int64? cityId, int companyId, Int64? countyId, bool fairWageApplies)
        {
            ProjectTDS.LFS_PROJECTRow projectRow = GetRow(projectId);

            projectRow.CountryID = countryId;
            projectRow.OfficeID = officeId;
            if (projectLeadId.HasValue) projectRow.ProjectLeadID = (int)projectLeadId; else projectRow.SetProjectLeadIDNull();
            projectRow.SalesmanID = salesmanId;
            projectRow.ProjectNumber = projectNumber;
            projectRow.ProjectType = projectType;
            projectRow.ProjectState = projectState;
            if (name.Trim() != "") projectRow.Name = name.Trim(); else projectRow.SetNameNull();
            if (description.Trim() != "") projectRow.Description = description.Trim(); else projectRow.SetDescriptionNull();
            if (proposalDate.HasValue) projectRow.ProposalDate = (DateTime)proposalDate; else projectRow.SetProposalDateNull();
            if (startDate.HasValue) projectRow.StartDate = (DateTime)startDate; else projectRow.SetStartDateNull();
            if (endDate.HasValue) projectRow.EndDate = (DateTime)endDate; else projectRow.SetEndDateNull();
            projectRow.ClientID = clientId;
            if (clientProjectNumber.Trim() != "") projectRow.ClientProjectNumber = clientProjectNumber.Trim(); else projectRow.SetClientProjectNumberNull();
            if (clientPrimaryContactId.HasValue) projectRow.ClientPrimaryContactID = (int)clientPrimaryContactId; else projectRow.SetClientPrimaryContactIDNull();
            if (clientSecondaryContactId.HasValue) projectRow.ClientSecondaryContactID = (int)clientSecondaryContactId; else projectRow.SetClientSecondaryContactIDNull();
            projectRow.Deleted = deleted;
            if (libraryCategoriesId.HasValue) projectRow.LIBRARY_CATEGORIES_ID = (int)libraryCategoriesId; else projectRow.SetLIBRARY_CATEGORIES_IDNull();
            if (provinceId.HasValue) projectRow.ProvinceID = (int)provinceId; else projectRow.SetProvinceIDNull();
            if (cityId.HasValue) projectRow.CityID = (Int64)cityId; else projectRow.SetCityIDNull();
            projectRow.COMPANY_ID = companyId;
            if (countyId.HasValue) projectRow.CountyID = (Int64)countyId; else projectRow.SetCountyIDNull();
            projectRow.FairWageApplies = fairWageApplies;
        }



        /// <summary>
        /// UpdateLibraryCategoriesId
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="libraryCategoriesId">libraryCategoriesId</param>
        public void UpdateLibraryCategoriesId(int projectId, int? libraryCategoriesId)
        {
            ProjectTDS.LFS_PROJECTRow projectRow = GetRow(projectId);

            if (libraryCategoriesId.HasValue) projectRow.LIBRARY_CATEGORIES_ID = (int)libraryCategoriesId; else projectRow.SetLIBRARY_CATEGORIES_IDNull();
        }
            


        /// <summary>
        /// Delete project
        /// </summary>
        /// <param name="projectId">ProjectId</param>
        /// <param name="alreadyValidated">Already Validated?</param>
        /// <returns></returns>
        public bool Delete(int projectId, bool alreadyValidated)
        {
            string errorMessage = "";
            bool isValid = (alreadyValidated) ? true : ((IsInUse(projectId, out errorMessage) == 0) ? true : false);

            if (isValid)
            {
                ProjectTDS.LFS_PROJECTRow projectRow = GetRow(projectId);

                projectRow.Deleted = true;
            }

            return isValid;
        }



        /// <summary>
        /// Generate Project Number for new Project
        /// </summary>
        /// <param name="countryId">CountryId</param>
        /// <param name="officeId">OfficeId</param>
        /// <param name="salesmanId">SalesmanId - EmployeeId</param>
        /// <param name="date">Date to generate</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Project Number generated</returns>
        public string GenerateProjectNumber(Int64 countryId, int officeId, int salesmanId, DateTime date, int companyId)
        {
            CountryGateway countryGateway = new CountryGateway(new DataSet());
            countryGateway.LoadByCountryId(countryId);
            string pnCountryId = countryGateway.GetIdForProjects(countryId);

            OfficeGateway officeGateway = new OfficeGateway(new DataSet());
            officeGateway.LoadByOfficeId(officeId);
            string pnOfficeId = officeGateway.GetIdForProjects(officeId);

            SalesmanGateway salesmanGateway = new SalesmanGateway(new DataSet());
            salesmanGateway.LoadBySalesmanId(salesmanId);
            string pnSalesmanId = salesmanGateway.GetIdForProjects(salesmanId);

            ProjectNumberGateway projectNumberGateway = new ProjectNumberGateway(Data);
            projectNumberGateway.Load();
            ProjectNumber projectNumber = new ProjectNumber(Data);
            string pnYearCode = projectNumber.GetYearCode(date.Year);
            string pnProjectIncrement = projectNumber.GetProjectIncrement(date.Year, companyId);

            string newProjectNumber = pnCountryId + pnOfficeId + pnSalesmanId + pnYearCode + pnProjectIncrement;

            return newProjectNumber;
        }


        
        /// <summary>
        /// Update Project Number for existing Project
        /// </summary>
        /// <param name="projectId">ProjectId</param>
        /// <param name="salesmasId">SalesmanId - EmployeeId</param>
        /// <returns>Project Number updated</returns>
        public string UpdateProjectNumber(int projectId, int salesmasId)
        {
            ProjectTDS.LFS_PROJECTRow projectRow = GetRow(projectId);

            // Get id for projects's salesman
            SalesmanGateway salesmanGateway = new SalesmanGateway();
            salesmanGateway.LoadBySalesmanId(salesmasId);
            string idForProjects = salesmanGateway.GetIdForProjects(salesmasId);

            // Update project number
            return projectRow.ProjectNumber.Substring(0, 4) + idForProjects + projectRow.ProjectNumber.Substring(6, 5);
        }



        /// <summary>
        /// Is In Use
        /// </summary>
        /// <param name="projectId">ProjectId</param>
        /// <param name="errorMessage">Error Message (out)</param>
        /// <returns>0 if no errors</returns>
        public int IsInUse(int projectId, out string errorMessage)
        {
            ProjectGateway projectGateway = new ProjectGateway(new DataSet());

            if (projectGateway.IsUsedInProjectTime(projectId))
            {
                errorMessage = "The project has Timesheets associated, you cannot delete it.";
                return 1;
            }

            if (projectGateway.IsUsedInTeamProjectTime(projectId))
            {
                errorMessage = "The project has been used in the Add Team Project Time wizard, you cannot delete it.";
                return 2;
            }

            if (projectGateway.IsUsedInTeamProjectTimeDetail(projectId))
            {
                errorMessage = "The project has been used in the Add Team Project Time wizard, you cannot delete it.";
                return 3;
            }

            errorMessage = "";
            return 0;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>ProjectTDS.LFS_PROJECTRow</returns>
        private ProjectTDS.LFS_PROJECTRow GetRow(int projectId)
        {
            ProjectTDS.LFS_PROJECTRow row = ((ProjectTDS.LFS_PROJECTDataTable)Table).FindByProjectID(projectId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Projects.Projects.Project.GetRow");
            }

            return row;

        }
        


    }
}