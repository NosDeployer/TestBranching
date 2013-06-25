using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.BL.Resources.Companies;
using LiquiForce.LFSLive.BL.Company.Organization;
using LiquiForce.LFSLive.BL.Resources.Employees;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.BL.Projects.Projects;

namespace LiquiForce.LFSLive.WebUI.Projects.Projects
{
    /// <summary>
    /// Project_add
    /// </summary>
    public partial class Project_add : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected ProjectTDS projectTDS;






        // ////////////////////////////////////////////////////////////////////////
        // INITIAL EVENTS
        //

        protected void Page_Load(object sender, EventArgs e)
        {
            // Register client scripts
            this.RegisterClientScripts();

            if (!IsPostBack)
            {
                // Security check
                if (!(Convert.ToBoolean(Session["sgLFS_PROJECTS_VIEW"]) && Convert.ToBoolean(Session["sgLFS_PROJECTS_ADD"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Tag page
                hdfCompanyId.Value = Session["companyID"].ToString();

                // Initialize viewstate variables
                ViewState["StepFrom"] = "Out";

                // Store navigator state
                StoreNavigatorState();

                // Prepare initial data 
                
                // ... for country
                CountryList countryList = new CountryList();
                countryList.LoadAndAddItem(-1, "(Select a country)");
                ddlCountry.DataSource = countryList.Table;
                ddlCountry.DataValueField = "CountryID";
                ddlCountry.DataTextField = "Name";
                ddlCountry.DataBind();

                // ... for office
                OfficeList officeList = new OfficeList();
                officeList.LoadByCountryIdAndAddItem(-1, "(Select an office)", -1);
                ddlOffice.DataSource = officeList.Table;
                ddlOffice.DataValueField = "OfficeID";
                ddlOffice.DataTextField = "Name";
                ddlOffice.DataBind();
                
                // ... for province
                ProvinceList provinceList = new ProvinceList();
                provinceList.LoadByCountryIdAndAddItem(-1, "(Select a province)", -1);
                ddlProvince.DataSource = provinceList.Table;
                ddlProvince.DataValueField = "ProvinceID";
                ddlProvince.DataTextField = "Name";
                ddlProvince.DataBind();

                // ... for county
                CountyList countyList = new CountyList();
                countyList.LoadByProvinceIdAndAddItem(-1, "(Select a county)", -1);
                ddlCounty.DataSource = countyList.Table;
                ddlCounty.DataValueField = "CountyID";
                ddlCounty.DataTextField = "Name";
                ddlCounty.DataBind();

                // ... for city
                CityList cityList = new CityList();
                cityList.LoadByCountyIdAndAddItem(-1, "(Select a city)", -1);
                ddlCity.DataSource = cityList.Table;
                ddlCity.DataValueField = "CityID";
                ddlCity.DataTextField = "Name";
                ddlCity.DataBind();

                // ... for employee
                EmployeeList employeeList = new EmployeeList();
                employeeList.LoadAndAddItem(-1, " ");
                ddlProjectLead.DataSource = employeeList.Table;
                ddlProjectLead.DataValueField = "EmployeeID";
                ddlProjectLead.DataTextField = "FullName";
                ddlProjectLead.DataBind();

                // ... for salesman
                SalesmanList salesmanList = new SalesmanList();
                salesmanList.LoadAndAddItem(-1, "(Select a salesman)");
                ddlSalesman.DataSource = salesmanList.Table;
                ddlSalesman.DataValueField = "SalesmanID";
                ddlSalesman.DataTextField = "FullName";
                ddlSalesman.DataBind();

                // StepLocationIn
                // StepSection1In
                Wizard.ActiveStepIndex = 0;
                StepTypeOfProjectIn();
            }
        }






        #region Wizard navigation events

        // ////////////////////////////////////////////////////////////////////////
        // WIZARD NAVIGATION EVENTS
        //

        protected void Wizard_ActiveStepChanged(object sender, EventArgs e)
        {
            if (ViewState["StepFrom"] != null)
            {
                switch (Wizard.ActiveStep.Name)
                {
                    case "Type Of Project":
                        StepTypeOfProjectIn();
                        break;
                    case "Location":
                        StepLocationIn();
                        break;

                    case "Ballpark Project Summary":
                        StepBallparkProjectSummaryIn();
                        
                        if (rbtnProposal.Checked)
                        {
                            Wizard.ActiveStepIndex = Wizard.WizardSteps.IndexOf(ProposalSummary);
                        }

                        if (rbtnInternalProject.Checked)
                        {
                            Wizard.ActiveStepIndex = Wizard.WizardSteps.IndexOf(InternalProjectSummary);
                        }
                        break;

                    case "Proposal Summary":
                        StepProposalSummaryIn();
                        
                        if (rbtnBallpark.Checked)
                        {
                            Wizard.ActiveStepIndex = Wizard.WizardSteps.IndexOf(Resources);
                        }
                        
                        if (rbtnInternalProject.Checked)
                        {
                            Wizard.ActiveStepIndex = Wizard.WizardSteps.IndexOf(Resources);
                        }
                        break;

                    case "Internal Project Summary":
                        StepInternalProjectSummaryIn();

                        
                        if (rbtnBallpark.Checked)
                        {
                            Wizard.ActiveStepIndex = Wizard.WizardSteps.IndexOf(Resources);
                        }
                        
                        if (rbtnProposal.Checked)
                        {
                            Wizard.ActiveStepIndex = Wizard.WizardSteps.IndexOf(Resources);
                        }
                        break;

                    case "Resources":
                        StepResourcesIn();
                        break;

                    case "Finish Options":
                        StepFinishOptionsIn();
                        Wizard.ActiveStepIndex = Wizard.WizardSteps.IndexOf(FinishOptions);
                        break;

                    default:
                        throw new Exception("Not exist the option for " + Wizard.ActiveStep.Name + " step in project_add.Wizard_ActiveStepChanged function");
                }
            }
        }



        protected void Wizard_NextButtonClick(object sender, WizardNavigationEventArgs e)
        {
            switch (Wizard.ActiveStep.Name)
            {
                case "Type Of Project":
                    e.Cancel = !StepTypeOfProjectNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "Type Of Project";
                    }
                    break;
                case "Location":
                    e.Cancel = !StepLocationNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "Location";
                    }
                    break;

                case "Ballpark Project Summary":
                    e.Cancel = !StepBallparkProjectSummaryNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "ProjectSummary";
                    }
                    break;

                case "Proposal Summary":
                    e.Cancel = !StepProposalSummaryNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "ProposalSummary";
                    }
                    break;

                case "Internal Project Summary":
                    e.Cancel = !StepInternalProjectSummaryNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "InternalProjectSummary";
                    }
                    break;

                default:
                    throw new Exception("Not exists the option for " + Wizard.ActiveStep.Name + " step in project_add.Wizard_NextButtonClick function");
            }
        }



        protected void Wizard_PreviousButtonClick(object sender, WizardNavigationEventArgs e)
        {
            switch (Wizard.ActiveStep.Name)
            {
                case "Location":
                    e.Cancel = !StepLocationPrevious();
                    break;

                case "Ballpark Project Summary":
                    e.Cancel = !StepBallparkProjectSummaryPrevious();
                    break;

                case "Proposal Summary":
                    e.Cancel = !StepProposalSummaryPrevious();
                    break;

                case "Internal Project Summary":
                    e.Cancel = !StepInternalProjectSummaryPrevious();
                    break;

                case "Resources":
                    e.Cancel = !StepResourcesPrevious();
                    break;

                default:
                    throw new Exception("Not exists the option for " + Wizard.ActiveStep.Name + " step in project_add.Wizard_PreviousButtonClick function");
            }
            if (!e.Cancel)
            {
                ViewState["StepFrom"] = Wizard.ActiveStep.Name;
            }
        }



        protected void Wizard_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        {
            e.Cancel = !StepResourcesFinish();
        }



        protected void Wizard_CancelButtonClick(object sender, EventArgs e)
        {
            Response.Write("<script language='javascript'> { window.close();}</script>");
        }



        #endregion






        #region STEP1 - TYPE OF PROJECT

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // STEP1 - TYPE OF PROJECT
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP1 - TYPE OF PROJECT - METHODS
        //

        private void StepTypeOfProjectIn()
        {
            mWizard2 master2 = (mWizard2)this.Master;
            // Set title for new project
            master2.WizardTitle = "Add New Projects";
            master2.WizardInstruction = "Please select the type of project you would like to add";

            Wizard.TabIndex = 4;
        }



        private bool StepTypeOfProjectNext()
        {
            return true;
        }
               
        #endregion






        #region STEP2 - LOCATION

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // STEP2 - LOCATION
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP2 - LOCATION - AUXILIAR EVENTS
        //

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            OfficeList officeList = new OfficeList();
            officeList.LoadByCountryIdAndAddItem(-1, "(Select an office)", int.Parse(ddlCountry.SelectedValue));
            ddlOffice.DataSource = officeList.Table;
            ddlOffice.DataValueField = "OfficeID";
            ddlOffice.DataTextField = "Name";
            ddlOffice.DataBind();
            ddlOffice.SelectedIndex = 0;

            ProvinceList provinceList = new ProvinceList();
            provinceList.LoadByCountryIdAndAddItem(-1, "(Select a province)", int.Parse(ddlCountry.SelectedValue));
            ddlProvince.DataSource = provinceList.Table;
            ddlProvince.DataValueField = "ProvinceID";
            ddlProvince.DataTextField = "Name";
            ddlProvince.DataBind();
            ddlProvince.SelectedIndex = 0;
            ddlCounty.SelectedIndex = 0;
            ddlCity.SelectedIndex = 0;
        }



        protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            CountyList countyList = new CountyList();
            countyList.LoadByProvinceIdAndAddItem(-1, "(Select a county)", int.Parse(ddlProvince.SelectedValue));
            ddlCounty.DataSource = countyList.Table;
            ddlCounty.DataValueField = "CountyID";
            ddlCounty.DataTextField = "Name";
            ddlCounty.DataBind();
            ddlCounty.SelectedIndex = 0;
            ddlCity.SelectedIndex = 0;
        }

        

        protected void ddlCounty_SelectedIndexChanged(object sender, EventArgs e)
        {
            CityList cityList = new CityList();
            cityList.LoadByCountyIdAndAddItem(-1, "(Select a city)", int.Parse(ddlCounty.SelectedValue));
            ddlCity.DataSource = cityList.Table;
            ddlCity.DataValueField = "CityID";
            ddlCity.DataTextField = "Name";
            ddlCity.DataBind();
            ddlCity.SelectedIndex = 0;
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP2 - LOCATION - METHODS
        //

        private void StepLocationIn()
        {
            int companyId = Int32.Parse(hdfCompanyId.Value);
            mWizard2 master2 = (mWizard2)this.Master;
            CompaniesList companiesList = new CompaniesList();
            companiesList.LoadAndAddItem(-1, "(Select a client)", companyId);

            Wizard.TabIndex = 3;
           
            // Set instruction for new ballpark
            if (rbtnBallpark.Checked)
            {
                master2.WizardTitle = "Add New Ballpark";
                master2.WizardInstruction = "Please provide the location for the ballpark";
                
                //... ... for companies
                ddlBallparkProjectClient.DataSource = companiesList.Table;
                ddlBallparkProjectClient.DataValueField = "COMPANIES_ID";
                ddlBallparkProjectClient.DataTextField = "Name";
                ddlBallparkProjectClient.DataBind();
            }

            // Set instruction for new proposal
            if (rbtnProposal.Checked)
            {
                master2.WizardTitle = "Add New Proposal";
                master2.WizardInstruction = "Please provide the location for the proposal";

                //... ... for companies
                ddlProposalClient.DataSource = companiesList.Table;
                ddlProposalClient.DataValueField = "COMPANIES_ID";
                ddlProposalClient.DataTextField = "Name";
                ddlProposalClient.DataBind();

                //... ... for proposal date
                tkrdpProposalDate.SelectedDate = DateTime.Now;
            }

            // Set instruction for new internal project
            if (rbtnInternalProject.Checked)
            {
                master2.WizardTitle = "Add New Internal Project";
                master2.WizardInstruction = "Please provide the location for the internal project";

                //... ... for companies
                ddlInternalProjectClient.DataSource = companiesList.Table;
                ddlInternalProjectClient.DataValueField = "COMPANIES_ID";
                ddlInternalProjectClient.DataTextField = "Name";
                ddlInternalProjectClient.DataBind();
            }
        }



        private bool StepLocationNext()
        {
            Page.Validate("Location");

            return (Page.IsValid) ? true : false;
        }



        private bool StepLocationPrevious()
        {
            return true;
        }

        #endregion






        #region STEP3 - BALLPARK PROJECT SUMMARY

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // STEP3 - BALLPARK PROJECT SUMMARY
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP3 - BALLPARK PROJECT SUMMARY - METHODS
        //

        private void StepBallparkProjectSummaryIn()
        {
            // Set instruction
            mWizard2 master2 = (mWizard2)this.Master;
            master2.WizardTitle = "Add New Ballpark";
            master2.WizardInstruction = "Please provide summary information for the ballpark";

            tkrdpBallparkProjectDate.SelectedDate = DateTime.Now;

            // Validate company button
            btnAddCompanyBallpark.Visible = true;
            //if (!Convert.ToBoolean(Session["sgADD_CONTACT_COMPANY"]))
            //{
            //    btnAddCompanyBallpark.Visible = false;
            //}
            
            Wizard.TabIndex = 5;
        }



        private bool StepBallparkProjectSummaryNext()
        {
            Page.Validate("BallparkProjectSummary");

            return (Page.IsValid) ? true : false;
        }



        private bool StepBallparkProjectSummaryPrevious()
        {
            return true;
        }

        #endregion






        #region STEP4 - PROPOSAL SUMMARY

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // STEP4 - PROPOSAL SUMMARY
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP4 - PROPOSAL SUMMARY - METHODS
        //

        private void StepProposalSummaryIn()
        {
            // Set instruction
            mWizard2 master2 = (mWizard2)this.Master;
            master2.WizardTitle = "Add New Proposal";
            master2.WizardInstruction = "Please provide summary information for the proposal";

            tkrdpProposalDate.SelectedDate = DateTime.Now;

            // Validate company button
            btnAddCompanyProposal.Visible = true;
            //if (!Convert.ToBoolean(Session["sgADD_CONTACT_COMPANY"]))
            //{
            //    btnAddCompanyProposal.Visible = false;
            //}

            Wizard.TabIndex = 8;
        }



        private bool StepProposalSummaryNext()
        {
            Page.Validate("ProposalSummary");

            return (Page.IsValid) ? true : false;
        }



        private bool StepProposalSummaryPrevious()
        {
            return true;
        }

        #endregion






        #region STEP5 - INTERNAL PROJECT SUMMARY

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // STEP5 - INTERNAL PROJECT SUMMARY
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP5 - INTERNAL PROJECT SUMMARY - METHODS
        //

        private void StepInternalProjectSummaryIn()
        {
            // Set instruction
            mWizard2 master2 = (mWizard2)this.Master;
            master2.WizardTitle = "Add New Internal Project";
            master2.WizardInstruction = "Please provide summary information for the internal project";

            tkrdpInternalProjectDate.SelectedDate = DateTime.Now;

            // Validate company button
            btnAddCompanyInternalProject.Visible = true;
            //if (!Convert.ToBoolean(Session["sgADD_CONTACT_COMPANY"]))
            //{
            //    btnAddCompanyInternalProject.Visible = false;
            //}

            Wizard.TabIndex = 5;
        }



        private bool StepInternalProjectSummaryNext()
        {
            Page.Validate("InternalProjectSummary");

            return (Page.IsValid) ? true : false;
        }



        private bool StepInternalProjectSummaryPrevious()
        {
            return true;
        }

        #endregion






        #region STEP6 - RESOURCES

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // STEP6 - RESOURCES
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP6 - RESOURCES - METHODS
        //

        private void StepResourcesIn()
        {
            mWizard2 master2 = (mWizard2)this.Master;

            // Set instruction for new ballpark
            if (rbtnBallpark.Checked)
            {
                master2.WizardTitle = "Add New Ballpark";
                master2.WizardInstruction = "Please select the human resources associated with the ballpark";
            }

            // Set instruction for new proposal
            if (rbtnProposal.Checked)
            {
                master2.WizardTitle = "Add New Proposal";
                master2.WizardInstruction = "Please select the human resources associated with the proposal";
            }

            // Set instruction for new internal project
            if (rbtnInternalProject.Checked)
            {
                master2.WizardTitle = "Add New Internal Project";
                master2.WizardInstruction = "Please select the human resources associated with the internal project";
            }

            Wizard.TabIndex = 3;
        }



        private bool StepResourcesPrevious()
        {
            return true;
        }



        private bool StepResourcesFinish()
        {
            Page.Validate("Resources");

            if (Page.IsValid)
            {
                PostPageChanges();
                UpdateDatabase();

                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion






        #region STEP7 - FINISH OPTIONS
        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // STEP7 - FINISH OPTIONS
        //
  
        // ////////////////////////////////////////////////////////////////////////
        // STEP7 - FINISH OPTIONS - METHODS
        //

        private void StepFinishOptionsIn()
        {
            // Set instruction
            mWizard2 master2 = (mWizard2)this.Master;
            master2.WizardInstruction = "What would you like to do?";

            Session.Remove("lfsLibraryTDS");
            Session.Remove("fromAttachment");

            // Set instruction for new ballpark
            if (rbtnBallpark.Checked)
            {
                master2.WizardTitle = "Add New Ballpark";
                lkbtnOpenProject.Text = "Open the ballpark you just created";
                lkbtnEditProject.Text = "Edit the ballpark you just created";
                lkbtnClose.Text = "Close this window";
            }

            // Set instruction for new proposal
            if (rbtnProposal.Checked)
            {
                master2.WizardTitle = "Add New Proposal";
                lkbtnOpenProject.Text = "Open the proposal you just created";
                lkbtnEditProject.Text = "Edit the proposal you just created";
                lkbtnClose.Text = "Close this window";
            }

            // Set instruction for new internal project
            if (rbtnInternalProject.Checked)
            {
                master2.WizardTitle = "Add New Internal Project";
                lkbtnOpenProject.Text = "Open the internal project you just created";
                lkbtnEditProject.Text = "Edit the internal project you just created";
                lkbtnClose.Text = "Close this window";
            }

            ProjectGateway projectGateway = new ProjectGateway(projectTDS);
                        
            string url = "";
            int projectId = projectGateway.GetLastProjectId();

            url = "./project_summary.aspx?source_page=project_add.aspx&project_id=" + projectId.ToString() + "&active_tab=0&" + GetNavigatorState();
            lkbtnOpenProject.Attributes.Add("onclick", string.Format("return lkbtnOpenProjectClick('{0}');", url));

            url = "./project_edit.aspx?source_page=project_add.aspx&project_id=" + projectId.ToString() + "&active_tab=0&" + GetNavigatorState() + "&origin=navigator";
            lkbtnEditProject.Attributes.Add("onclick", string.Format("return lkbtnEditProjectClick('{0}');", url));

            lkbtnClose.Attributes.Add("onclick", "return lkbtnCloseClick();");
        }

        #endregion






        // ////////////////////////////////////////////////////////////////////////
        // AUXILIAR EVENTS
        //

        protected void btnAddCompany_Click(object sender, EventArgs e)
        {
            string script = "<script language='javascript'>";
            string url = "./../../../Briefcase/add_company_step1.asp?TYPE=2&amp;REQUIRED=1&amp;REQUEST=0";
            script = script + string.Format("window.open('{0}', '_blank', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=440, height=300')", url);
            script = script + "</script>";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Company", script, false);
        }      






        // ////////////////////////////////////////////////////////////////////////
        // METHODS
        //

        private void StoreNavigatorState()
        {
            if (Session["navigatorState"] != null)
            {
                ViewState["navigatorState"] = Session["navigatorState"].ToString();
            }
            else
            {
                ViewState["navigatorState"] = "&search_projectnumber=&search_projectname=&search_client=&search_type=%&search_state=%";
            }
        }



        private string GetNavigatorState()
        {
            return (string)ViewState["navigatorState"];
        }



        private void PostPageChanges()
        {
            // Definition of general variables
            Int64 countryId = Int64.Parse(ddlCountry.SelectedValue);
            int officeId = int.Parse(ddlOffice.SelectedValue);
            Int64 provinceId = Int64.Parse(ddlProvince.SelectedValue);
            Int64 cityId = Int64.Parse(ddlCity.SelectedValue);
            Int64 countyId = Int64.Parse(ddlCounty.SelectedValue);
            int? projectLeadId = null; if ((ddlProjectLead.SelectedValue != "-1") && (ddlProjectLead.SelectedIndex > -1)) projectLeadId = int.Parse(ddlProjectLead.SelectedValue);
            int salesmanId = int.Parse(ddlSalesman.SelectedValue);
            bool deleted = false;
            int? clientPrimaryContactID = null;
            int? clientSecondaryContactID = null;
           
            projectTDS = new ProjectTDS();
            Project project = new Project(projectTDS);
            ProjectHistory projectHistory = new ProjectHistory(projectTDS);
            string projectNumber = project.GenerateProjectNumber(countryId, officeId, salesmanId, DateTime.Now, Int32.Parse(hdfCompanyId.Value.Trim()));

            // Insert Ballpark           
            if (rbtnBallpark.Checked)
            {
                // ... Definition of variables
                string type = "Ballpark";
                string state = "Active";                
                string ballparkProjectName = tbxBallparkProjectName.Text.Trim();
                string ballparkProjectDescription = tbxBallparkProjectDescription.Text.Trim();
                int ballparkProjectClientId = int.Parse(ddlBallparkProjectClient.SelectedValue);
                DateTime? ballparkProjectDate = null; if (tkrdpBallparkProjectDate.SelectedDate.HasValue) ballparkProjectDate = DateTime.Parse(tkrdpBallparkProjectDate.SelectedDate.Value.Month.ToString() + '/' + tkrdpBallparkProjectDate.SelectedDate.Value.Day.ToString() + '/' + tkrdpBallparkProjectDate.SelectedDate.Value.Year.ToString());
                DateTime? ballparkProjectStartDate = null; if (tkrdpBallparkProjectPotentialStartDate.SelectedDate.HasValue) ballparkProjectStartDate = DateTime.Parse(tkrdpBallparkProjectPotentialStartDate.SelectedDate.Value.Month.ToString() + '/' + tkrdpBallparkProjectPotentialStartDate.SelectedDate.Value.Day.ToString() + '/' + tkrdpBallparkProjectPotentialStartDate.SelectedDate.Value.Year.ToString());
                DateTime? ballparkProjectEndDate = null; if (tkrdpBallparkProjectPotentialEndDate.SelectedDate.HasValue) ballparkProjectEndDate = DateTime.Parse(tkrdpBallparkProjectPotentialEndDate.SelectedDate.Value.Month.ToString() + '/' + tkrdpBallparkProjectPotentialEndDate.SelectedDate.Value.Day.ToString() + '/' + tkrdpBallparkProjectPotentialEndDate.SelectedDate.Value.Year.ToString());
                
                // ... Insert
                project.Insert(countryId, officeId, projectLeadId, salesmanId, projectNumber, type, state, ballparkProjectName, ballparkProjectDescription, ballparkProjectDate, ballparkProjectStartDate, ballparkProjectEndDate, ballparkProjectClientId, clientPrimaryContactID, clientSecondaryContactID, "", deleted, null, null, null, provinceId, cityId, Int32.Parse(hdfCompanyId.Value.Trim()), countyId, false);
                projectHistory.Insert(0, 1, state, DateTime.Now, Convert.ToInt32(Session["loginID"]), Int32.Parse(hdfCompanyId.Value.Trim()));
            }

            // ... Insert Proposal
            if (rbtnProposal.Checked)
            {
                // ... Definition of variables
                string type = "Proposal";
                string state = "Bidding";
                string proposalName = tbxProposalName.Text.Trim();
                string proposalDescription = tbxProposalDescription.Text.Trim();
                int proposalClientId = int.Parse(ddlProposalClient.SelectedValue);
                string clientProposalNumber = tbxClientProposalNumber.Text.Trim();
                DateTime? proposalDate = null; if (tkrdpProposalDate.SelectedDate.HasValue) proposalDate = DateTime.Parse(tkrdpProposalDate.SelectedDate.Value.Month.ToString() + '/' + tkrdpProposalDate.SelectedDate.Value.Day.ToString() + '/' + tkrdpProposalDate.SelectedDate.Value.Year.ToString());
                DateTime? proposalStartDate = null; if (tkrdpProposalPotencialStartDate.SelectedDate.HasValue) proposalStartDate = DateTime.Parse(tkrdpProposalPotencialStartDate.SelectedDate.Value.Month.ToString() + '/' + tkrdpProposalPotencialStartDate.SelectedDate.Value.Day.ToString() + '/' + tkrdpProposalPotencialStartDate.SelectedDate.Value.Year.ToString());
                DateTime? proposalEndDate = null; if (tkrdpProposalPotencialEndDate.SelectedDate.HasValue) proposalEndDate = DateTime.Parse(tkrdpProposalPotencialEndDate.SelectedDate.Value.Month.ToString() + '/' + tkrdpProposalPotencialEndDate.SelectedDate.Value.Day.ToString() + '/' + tkrdpProposalPotencialEndDate.SelectedDate.Value.Year.ToString());

                // ... Insert
                project.Insert(countryId, officeId, projectLeadId, salesmanId, projectNumber, type, state, proposalName, proposalDescription, proposalDate, proposalStartDate, proposalEndDate, proposalClientId, clientPrimaryContactID, clientSecondaryContactID, clientProposalNumber, deleted, null, null, null, provinceId, cityId, Int32.Parse(hdfCompanyId.Value.Trim()), countyId, false);
                projectHistory.Insert(0, 1, state, DateTime.Now, Convert.ToInt32(Session["loginID"]), Int32.Parse(hdfCompanyId.Value.Trim()));
            }

            // ... Insert Internal Project
            if (rbtnInternalProject.Checked)
            {
                // ... Definition of variables
                string type = "Internal";
                string state = "Active";
                string internalProjectName = tbxInternalProjectName.Text.Trim();
                string internalProjectDescription = tbxInternalProjectDescription.Text.Trim();
                int internalProjectClientId = int.Parse(ddlInternalProjectClient.SelectedValue);
                DateTime? internalProjectDate = null; if (tkrdpInternalProjectDate.SelectedDate.HasValue) internalProjectDate = DateTime.Parse(tkrdpInternalProjectDate.SelectedDate.Value.Month.ToString() + '/' + tkrdpInternalProjectDate.SelectedDate.Value.Day.ToString() + '/' + tkrdpInternalProjectDate.SelectedDate.Value.Year.ToString());
                
                // ... Insert
                project.Insert(countryId, officeId, projectLeadId, salesmanId, projectNumber, type, state, internalProjectName, internalProjectDescription, internalProjectDate, null, null, internalProjectClientId, clientPrimaryContactID, clientSecondaryContactID, "", deleted, null, null, null, provinceId, cityId, Int32.Parse(hdfCompanyId.Value.Trim()), countyId, false);
                projectHistory.Insert(0, 1, state, DateTime.Now, Convert.ToInt32(Session["loginID"]), Int32.Parse(hdfCompanyId.Value.Trim()));
            }
        }



        private void UpdateDatabase()
        {
            try
            {
                ProjectGateway projectGateway = new ProjectGateway(projectTDS);
                projectGateway.Update2();

                projectTDS.AcceptChanges();
            }
            catch (Exception ex)
            {
                string url = string.Format("./../../error_page.aspx?error={0}", ex.Message.Replace('\n', ' '));
                Response.Redirect(url);
            }
        }



        private void RegisterClientScripts()
        {
            // Register content variables
            string contentVariables = "";
            
            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./project_add.js");
        }





         
               
            

    }
}     