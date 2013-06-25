using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.BL.Projects.Projects;
using LiquiForce.LFSLive.DA.Company.Organization;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.DA.Resources.Companies;
using LiquiForce.LFSLive.DA.Resources.Employees;
using LiquiForce.LFSLive.DA.Services.Services;
using Telerik.Web.UI;
using LiquiForce.LFSLive.DA.RAF;

namespace LiquiForce.LFSLive.WebUI.Projects.Projects
{
    /// <summary>
    /// project_summary
    /// </summary>
    public partial class project_summary : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected ProjectTDS projectTDS;
        protected ProjectNavigatorTDS projectNavigatorTDS;
        protected ProjectNavigatorTDS.ProjectNotesDataTable projectNotes;
        protected ProjectNavigatorTDS.ProjectServiceDataTable projectServices;
        protected ProjectNavigatorTDS.LFS_PROJECT_WORK_FUNCTION_FAIR_WAGEDataTable projectTypeOfWorkFunctionClassification;
        protected ProjectNavigatorTDS.LFS_PROJECT_JOB_CLASS_TYPE_RATEDataTable projectJobClassClassification;
        protected ProjectNavigatorTDS.ProjectWorkFunctionBudgetDataTable projectBudget;
        protected ProjectNavigatorTDS.ProjectUnitsBudgetDataTable unitsBudget;
        protected ProjectNavigatorTDS.ProjectMaterialsBudgetDataTable materialsBudget;
        protected ProjectNavigatorTDS.ProjectSubcontractorsBudgetDataTable subcontractorsBudget;
        protected ProjectNavigatorTDS.ProjectHotelsBudgetDataTable hotelsBudget;
        protected ProjectNavigatorTDS.ProjectBondingsBudgetDataTable bondingsBudget;
        protected ProjectNavigatorTDS.ProjectInsurancesBudgetDataTable insurancesBudget;
        protected ProjectNavigatorTDS.ProjectOtherCostsBudgetDataTable otherCostsBudget;        






        // ////////////////////////////////////////////////////////////////////////
        // EVENTS
        //

        protected void Page_Load(object sender, EventArgs e)
        {
            // Register client scripts
            this.RegisterClientScripts();

            if (!IsPostBack)
            {
                // Security check
                if (!Convert.ToBoolean(Session["sgLFS_PROJECTS_VIEW"]))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["project_id"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in project_summary.aspx");
                }

                // Tag page
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfProjectId.Value = Request.QueryString["project_id"];
                hdfLoginId.Value = Convert.ToInt32(Session["loginID"]).ToString();

                // Prepare initial data
                Session.Remove("projectNotesDummy");
                Session.Remove("projectServicesDummy");
                Session.Remove("projectTypeOfWorkFunctionClassificationDummy");
                Session.Remove("projectJobClassClassificationDummy");
                Session.Remove("projectBudgetDummy");
                Session.Remove("subcontractorsBudgetDummy");
                Session.Remove("hotelsBudgetDummy");
                Session.Remove("bondingsBudgetDummy");
                Session.Remove("insurancesBudgetDummy");
                Session.Remove("otherCostsBudgetDummy");                

                // ... Set initial tab
                if ((string)Session["dialogOpenedProjects"] != "1")
                {
                    hdfActiveTab.Value = Request.QueryString["active_tab"];
                }
                else
                {
                    hdfActiveTab.Value = (string)Session["activeTabProjects"];
                }
                
                // If coming from projects2.aspx or project_add.aspx
                if (Request.QueryString["source_page"] == "projects2.aspx" || Request.QueryString["source_page"] == "project_add.aspx")
                {
                    // Store Navigator State and Update control
                    StoreNavigatorState();
                    ViewState["update"] = "no";

                    // Get Project ID
                    int projectId = int.Parse(hdfProjectId.Value);

                    // Get dataset
                    projectTDS = new ProjectTDS();
                    projectNavigatorTDS = new ProjectNavigatorTDS();
                    projectNotes = new ProjectNavigatorTDS.ProjectNotesDataTable();
                    projectServices = new ProjectNavigatorTDS.ProjectServiceDataTable();
                    projectTypeOfWorkFunctionClassification = new ProjectNavigatorTDS.LFS_PROJECT_WORK_FUNCTION_FAIR_WAGEDataTable();
                    projectJobClassClassification = new ProjectNavigatorTDS.LFS_PROJECT_JOB_CLASS_TYPE_RATEDataTable();
                    projectBudget = new ProjectNavigatorTDS.ProjectWorkFunctionBudgetDataTable();
                    unitsBudget = new ProjectNavigatorTDS.ProjectUnitsBudgetDataTable();
                    materialsBudget = new ProjectNavigatorTDS.ProjectMaterialsBudgetDataTable();
                    subcontractorsBudget = new ProjectNavigatorTDS.ProjectSubcontractorsBudgetDataTable();
                    hotelsBudget = new ProjectNavigatorTDS.ProjectHotelsBudgetDataTable();
                    bondingsBudget = new ProjectNavigatorTDS.ProjectBondingsBudgetDataTable();
                    insurancesBudget = new ProjectNavigatorTDS.ProjectInsurancesBudgetDataTable();
                    otherCostsBudget = new ProjectNavigatorTDS.ProjectOtherCostsBudgetDataTable();                    
                    
                    // Get General Data
                    ProjectGateway projectGatewayForLoad = new ProjectGateway(projectTDS);
                    projectGatewayForLoad.LoadByProjectId(projectId);

                    // Get Job info
                    ProjectNavigatorProjectJobInfoGateway projectNavigatorProjectJobInfoGateway = new ProjectNavigatorProjectJobInfoGateway(projectNavigatorTDS);
                    projectNavigatorProjectJobInfoGateway.LoadAllByProjectId(projectId);

                    // Get Sale/Billing/Pricing
                    ProjectSaleBillingPricingGateway projectSaleBillingPricingGatewayForLoad = new ProjectSaleBillingPricingGateway(projectTDS);
                    projectSaleBillingPricingGatewayForLoad.LoadAllByProjectId(projectId);

                    // ... Get Sale/Billing/Pricing - Services
                    ProjectNavigatorProjectService projectNavigatorProjectService = new ProjectNavigatorProjectService(projectNavigatorTDS);
                    projectNavigatorProjectService.LoadAllByProjectId(projectId);
                    projectNavigatorProjectService.UpdateForLoad();                    

                    // Get Costing Updates
                    ProjectCostingUpdatesGateway projectCostingUpdatesGatewayForLoad = new ProjectCostingUpdatesGateway(projectTDS);
                    projectCostingUpdatesGatewayForLoad.LoadByProjectId(projectId);

                    // Get Project Terms
                    ProjectTermsPOGateway projectTermsPOGatewayForLoad = new ProjectTermsPOGateway(projectTDS);
                    projectTermsPOGatewayForLoad.LoadByProjectId(projectId);

                    // Get Technical
                    ProjectTechnicalGateway projectTechnicalGatewayForLoad = new ProjectTechnicalGateway(projectTDS);
                    projectTechnicalGatewayForLoad.LoadByProjectId(projectId);

                    // Get Engineer Subcontractors
                    ProjectEngineerSubcontractorsGateway projectEngineerSubcontractorsGatewayForLoad = new ProjectEngineerSubcontractorsGateway(projectTDS);
                    projectEngineerSubcontractorsGatewayForLoad.LoadAllByProjectId(projectId);

                    // ... Get Subcontractors
                    ProjectSubcontractorGateway projectSubcontractorGatewayForLoad = new ProjectSubcontractorGateway(projectTDS);
                    projectSubcontractorGatewayForLoad.LoadAllByProjectId(projectId);

                    // Cost Exceptions
                    // ... Get Type Of Work & Function Classification
                    ProjectNavigatorProjectWorkFunctionFairWage projectNavigatorProjectWorkFunctionFairWage = new ProjectNavigatorProjectWorkFunctionFairWage(projectNavigatorTDS);
                    projectNavigatorProjectWorkFunctionFairWage.LoadAllByProjectId(projectId);

                    // ... Get Job Class Classification
                    ProjectNavigatorProjectJobClassTypeRate projectNavigatorProjectJobClassTypeRate = new ProjectNavigatorProjectJobClassTypeRate(projectNavigatorTDS);
                    projectNavigatorProjectJobClassTypeRate.LoadAllByProjectId(projectId);

                    // Get Budget
                    ProjectNavigatorProjectWorkFunctionBudget projectNavigatorProjectWorkFunctionBudget = new ProjectNavigatorProjectWorkFunctionBudget(projectNavigatorTDS);
                    projectNavigatorProjectWorkFunctionBudget.LoadAllByProjectId(projectId);

                    // Get Units Budget
                    ProjectNavigatorProjectUnitsBudget projectNavigatorProjectUnitsBudget = new ProjectNavigatorProjectUnitsBudget(projectNavigatorTDS);
                    projectNavigatorProjectUnitsBudget.LoadAllByProjectId(projectId);

                    // Get Materials Budget
                    ProjectNavigatorProjectMaterialsBudget projectNavigatorProjectMaterialsBudget = new ProjectNavigatorProjectMaterialsBudget(projectNavigatorTDS);
                    projectNavigatorProjectMaterialsBudget.LoadAllByProjectId(projectId);

                    // Get Subcontractors Budget
                    ProjectNavigatorProjectSubcontractorsBudget projectNavigatorProjectSubcontractorsBudget = new ProjectNavigatorProjectSubcontractorsBudget(projectNavigatorTDS);
                    projectNavigatorProjectSubcontractorsBudget.LoadAllByProjectId(projectId);

                    // Get Hotels Budget
                    ProjectNavigatorProjectHotelsBudget projectNavigatorProjectHotelsBudget = new ProjectNavigatorProjectHotelsBudget(projectNavigatorTDS);
                    projectNavigatorProjectHotelsBudget.LoadAllByProjectId(projectId);

                    // Get Bondings Budget
                    ProjectNavigatorProjectBondingsBudget projectNavigatorProjectBondingsBudget = new ProjectNavigatorProjectBondingsBudget(projectNavigatorTDS);
                    projectNavigatorProjectBondingsBudget.LoadAllByProjectId(projectId);

                    // Get Insurances Budget
                    ProjectNavigatorProjectInsurancesBudget projectNavigatorProjectInsurancesBudget = new ProjectNavigatorProjectInsurancesBudget(projectNavigatorTDS);
                    projectNavigatorProjectInsurancesBudget.LoadAllByProjectId(projectId);

                    // Get Other Costs Budget
                    ProjectNavigatorProjectOtherCostsBudget projectNavigatorProjectOtherCostsBudget = new ProjectNavigatorProjectOtherCostsBudget(projectNavigatorTDS);
                    projectNavigatorProjectOtherCostsBudget.LoadAllByProjectId(projectId);

                    // Get Notes
                    ProjectNavigatorProjectNotesGateway projectNavigatorProjectNotesGateway = new ProjectNavigatorProjectNotesGateway(projectNavigatorTDS);
                    projectNavigatorProjectNotesGateway.LoadAllByProjectId(projectId);

                    // Store dataset
                    Session["lfsProjectTDS"] = projectTDS;
                    Session["projectNavigatorTDS"] = projectNavigatorTDS;                    
                    Session["projectNotes"] = projectNavigatorTDS.ProjectNotes;
                    Session["projectServices"] = projectNavigatorTDS.ProjectService;
                    Session["projectTypeOfWorkFunctionClassification"] = projectNavigatorTDS.LFS_PROJECT_WORK_FUNCTION_FAIR_WAGE;
                    Session["projectJobClassClassification"] = projectNavigatorTDS.LFS_PROJECT_JOB_CLASS_TYPE_RATE;
                    Session["projectBudget"] = projectNavigatorTDS.ProjectWorkFunctionBudget;
                    Session["unitsBudget"] = projectNavigatorTDS.ProjectUnitsBudget;
                    Session["materialsBudget"] = projectNavigatorTDS.ProjectMaterialsBudget;
                    Session["subcontractorsBudget"] = projectNavigatorTDS.ProjectSubcontractorsBudget;
                    Session["hotelsBudget"] = projectNavigatorTDS.ProjectHotelsBudget;
                    Session["bondingsBudget"] = projectNavigatorTDS.ProjectBondingsBudget;
                    Session["insurancesBudget"] = projectNavigatorTDS.ProjectInsurancesBudget;
                    Session["otherCostsBudget"] = projectNavigatorTDS.ProjectOtherCostsBudget;                    

                    projectNotes = projectNavigatorTDS.ProjectNotes;
                    projectServices = projectNavigatorTDS.ProjectService;                    
                    projectTypeOfWorkFunctionClassification = projectNavigatorTDS.LFS_PROJECT_WORK_FUNCTION_FAIR_WAGE;
                    projectJobClassClassification = projectNavigatorTDS.LFS_PROJECT_JOB_CLASS_TYPE_RATE;
                    projectBudget = projectNavigatorTDS.ProjectWorkFunctionBudget;
                    unitsBudget = projectNavigatorTDS.ProjectUnitsBudget;
                    materialsBudget = projectNavigatorTDS.ProjectMaterialsBudget;
                    hotelsBudget = projectNavigatorTDS.ProjectHotelsBudget;
                    bondingsBudget = projectNavigatorTDS.ProjectBondingsBudget;
                    insurancesBudget = projectNavigatorTDS.ProjectInsurancesBudget;
                    otherCostsBudget = projectNavigatorTDS.ProjectOtherCostsBudget;                    
                }

                // ... project_add.aspx
                if (Request.QueryString["source_page"] == "project_add.aspx")
                {
                    ViewState["update"] = "yes";
                }

                // ... left menu, project_edit.aspx, project_delete.aspx or project_state.aspx
                if ((Request.QueryString["source_page"] == "lm") || (Request.QueryString["source_page"] == "project_edit.aspx") || (Request.QueryString["source_page"] == "project_delete.aspx") || (Request.QueryString["source_page"] == "project_state.aspx"))
                {
                    // Get Project ID
                    int projectId = int.Parse(hdfProjectId.Value);

                    // Store Navigator State and Update control
                    StoreNavigatorState();
                    ViewState["update"] = Request.QueryString["update"];

                    // Restore dataset
                    projectTDS = (ProjectTDS)Session["lfsProjectTDS"];
                    projectNavigatorTDS = (ProjectNavigatorTDS)Session["projectNavigatorTDS"]; 
                   
                    Session["projectNotes"] = projectNavigatorTDS.ProjectNotes;
                    Session["projectServices"] = projectNavigatorTDS.ProjectService;

                    // Cost Exceptions
                    // ... Get Type Of Work & Function Classification
                    ProjectNavigatorProjectWorkFunctionFairWage projectNavigatorProjectWorkFunctionFairWage = new ProjectNavigatorProjectWorkFunctionFairWage(projectNavigatorTDS);
                    projectNavigatorProjectWorkFunctionFairWage.LoadAllByProjectId(projectId);

                    Session["projectTypeOfWorkFunctionClassification"] = projectNavigatorTDS.LFS_PROJECT_WORK_FUNCTION_FAIR_WAGE;
                    Session["projectJobClassClassification"] = projectNavigatorTDS.LFS_PROJECT_JOB_CLASS_TYPE_RATE;

                    //  ... Get budget
                    ProjectNavigatorProjectWorkFunctionBudget projectNavigatorProjectWorkFunctionBudget = new ProjectNavigatorProjectWorkFunctionBudget(projectNavigatorTDS);
                    projectNavigatorProjectWorkFunctionBudget.LoadAllByProjectId(projectId);

                    Session["projectBudget"] = projectNavigatorTDS.ProjectWorkFunctionBudget;

                    projectNotes = projectNavigatorTDS.ProjectNotes;
                    projectServices = projectNavigatorTDS.ProjectService;                    
                    projectTypeOfWorkFunctionClassification = projectNavigatorTDS.LFS_PROJECT_WORK_FUNCTION_FAIR_WAGE;
                    projectJobClassClassification = projectNavigatorTDS.LFS_PROJECT_JOB_CLASS_TYPE_RATE;
                    projectBudget = projectNavigatorTDS.ProjectWorkFunctionBudget;
                    unitsBudget = projectNavigatorTDS.ProjectUnitsBudget;
                    materialsBudget = projectNavigatorTDS.ProjectMaterialsBudget;
                    hotelsBudget = projectNavigatorTDS.ProjectHotelsBudget;
                    bondingsBudget = projectNavigatorTDS.ProjectBondingsBudget;
                    insurancesBudget = projectNavigatorTDS.ProjectInsurancesBudget;
                    otherCostsBudget = projectNavigatorTDS.ProjectOtherCostsBudget;
                }

                // ... Data for current project
                ProjectGateway projectGateway = new ProjectGateway(projectTDS);

                // ... for project
                int currentProjectId = Int32.Parse(hdfProjectId.Value.ToString());
                string name = projectGateway.GetName(currentProjectId);
                if (name.Length > 23) name = name.Substring(0, 20) + "...";
                lblTitleProjectName.Text = name + " (" + projectGateway.GetProjectNumber(currentProjectId) + ")";

                // ... for client
                int companyId = Int32.Parse(hdfCompanyId.Value);
                int currentClientId = projectGateway.GetClientID(Int32.Parse(hdfProjectId.Value.ToString()));
                CompaniesGateway companiesGateway = new CompaniesGateway();
                companiesGateway.LoadAllByCompaniesId(currentClientId, companyId);
                lblTitleClientName.Text = "Client: " + companiesGateway.GetName(currentClientId);

                // Load Data
                LoadData();

                // Store Dataset
                Session["lfsProjectTDS"] = projectTDS;
                Session["projectNavigatorTDS"] = projectNavigatorTDS;                
                Session["projectNotes"] = projectNavigatorTDS.ProjectNotes;
                Session["projectServices"] = projectNavigatorTDS.ProjectService;
                Session["projectTypeOfWorkFunctionClassification"] = projectNavigatorTDS.LFS_PROJECT_WORK_FUNCTION_FAIR_WAGE;
                Session["projectJobClassClassification"] = projectNavigatorTDS.LFS_PROJECT_JOB_CLASS_TYPE_RATE;
                Session["projectBudget"] = projectNavigatorTDS.ProjectWorkFunctionBudget;
                Session["unitsBudget"] = projectNavigatorTDS.ProjectUnitsBudget;
                Session["materialsBudget"] = projectNavigatorTDS.ProjectMaterialsBudget;
                Session["subcontractorsBudget"] = projectNavigatorTDS.ProjectSubcontractorsBudget;
                Session["hotelsBudget"] = projectNavigatorTDS.ProjectHotelsBudget;
                Session["bondingsBudget"] = projectNavigatorTDS.ProjectBondingsBudget;
                Session["insurancesBudget"] = projectNavigatorTDS.ProjectInsurancesBudget;
                Session["otherCostsBudget"] = projectNavigatorTDS.ProjectOtherCostsBudget;

                projectNotes = projectNavigatorTDS.ProjectNotes;
                projectServices = projectNavigatorTDS.ProjectService;                
                projectTypeOfWorkFunctionClassification = projectNavigatorTDS.LFS_PROJECT_WORK_FUNCTION_FAIR_WAGE;
                projectJobClassClassification = projectNavigatorTDS.LFS_PROJECT_JOB_CLASS_TYPE_RATE;
                projectBudget = projectNavigatorTDS.ProjectWorkFunctionBudget;
                unitsBudget = projectNavigatorTDS.ProjectUnitsBudget;
                materialsBudget = projectNavigatorTDS.ProjectMaterialsBudget;
                hotelsBudget = projectNavigatorTDS.ProjectHotelsBudget;
                bondingsBudget = projectNavigatorTDS.ProjectBondingsBudget;
                insurancesBudget = projectNavigatorTDS.ProjectInsurancesBudget;
                otherCostsBudget = projectNavigatorTDS.ProjectOtherCostsBudget;

                // ... For total cost at services
                //ProjectNavigatorProjectService projectNavigatorProjectServiceForCost = new ProjectNavigatorProjectService(projectNavigatorTDS);
                //tbxTotalCost.Text = Decimal.Round(projectNavigatorProjectServiceForCost.GetTotalCost(), 2).ToString();
            }
            else
            {
                // Restore dataset 
                projectTDS = (ProjectTDS)Session["lfsProjectTDS"];
                projectNavigatorTDS = (ProjectNavigatorTDS)Session["projectNavigatorTDS"];     
           
                Session["projectNotes"] = projectNavigatorTDS.ProjectNotes;
                Session["projectServices"] = projectNavigatorTDS.ProjectService;
                Session["projectTypeOfWorkFunctionClassification"] = projectNavigatorTDS.LFS_PROJECT_WORK_FUNCTION_FAIR_WAGE;
                Session["projectJobClassClassification"] = projectNavigatorTDS.LFS_PROJECT_JOB_CLASS_TYPE_RATE;
                Session["projectBudget"] = projectNavigatorTDS.ProjectWorkFunctionBudget;
                Session["unitsBudget"] = projectNavigatorTDS.ProjectUnitsBudget;
                Session["materialsBudget"] = projectNavigatorTDS.ProjectMaterialsBudget;
                Session["subcontractorsBudget"] = projectNavigatorTDS.ProjectSubcontractorsBudget;
                Session["hotelsBudget"] = projectNavigatorTDS.ProjectHotelsBudget;
                Session["bondingsBudget"] = projectNavigatorTDS.ProjectBondingsBudget;
                Session["insurancesBudget"] = projectNavigatorTDS.ProjectInsurancesBudget;
                Session["otherCostsBudget"] = projectNavigatorTDS.ProjectOtherCostsBudget;

                projectNotes = projectNavigatorTDS.ProjectNotes;
                projectServices = projectNavigatorTDS.ProjectService;
                projectTypeOfWorkFunctionClassification = projectNavigatorTDS.LFS_PROJECT_WORK_FUNCTION_FAIR_WAGE;
                projectJobClassClassification = projectNavigatorTDS.LFS_PROJECT_JOB_CLASS_TYPE_RATE;
                projectBudget = projectNavigatorTDS.ProjectWorkFunctionBudget;
                unitsBudget = projectNavigatorTDS.ProjectUnitsBudget;
                materialsBudget = projectNavigatorTDS.ProjectMaterialsBudget;
                hotelsBudget = projectNavigatorTDS.ProjectHotelsBudget;
                bondingsBudget = projectNavigatorTDS.ProjectBondingsBudget;
                insurancesBudget = projectNavigatorTDS.ProjectInsurancesBudget;
                otherCostsBudget = projectNavigatorTDS.ProjectOtherCostsBudget;
                
                // Grid Subcontractors
                //grdvSubcontractors.DataSource = projectTDS.LFS_PROJECT_SUBCONTRACTOR;
                //grdvSubcontractors.DataBind();
            }
        }       



        protected void Page_PreRender(object sender, EventArgs e)
        {
            ProjectGateway projectGateway = new ProjectGateway(projectTDS);

            // Set active toolbar
            mForm6 master = (mForm6)this.Master;
            master.ActiveToolbar = "Projects";                   

            // Security check
            if (!Convert.ToBoolean(Session["sgLFS_PROJECTS_ADMIN"]))
            {
                // ... menu reports
                tkrpbLeftMenuReports.Visible = false;

                // ... for job info tab
                tpJobInfo.Enabled = true;  
                
                // ... for values that comes from sales billing pricing tab                              
                //tpSaleBillingPricing.Enabled = false;
                upnlSaleBillingPricingValues.Visible = false;
                upnlSaleBillingPricingValues1.Visible = false;

                // ... for values that comes from costing updates
                //tpCostingUpdates.Enabled = false;
            }
            else
            {
                // ... menu reports
                tkrpbLeftMenuReports.Visible = true;
                
                // ... for job info tab
                tpJobInfo.Enabled = true;

                // ... for values that comes from sales billing pricing                 
                //tpSaleBillingPricing.Enabled = true;                
                upnlSaleBillingPricingValues.Visible = true;
                upnlSaleBillingPricingValues1.Visible = true;

                // ... for values that comes from costing updates
                //tpCostingUpdates.Enabled = true;
            }

            // Country check
            if (projectGateway.GetCountryID(int.Parse(hdfProjectId.Value)) == 1)
            {
                //lblGeneralNoticeProject.Visible = true;
                //rbtnGeneralNoticeProject.Visible = true;
                //lblGeneralForm1000.Visible = true;
                //rbtnGeneralForm1000.Visible = true;

                grdJobClassClassification.Columns[4].HeaderText = "Rate (CAD)";
                grdJobClassClassification.Columns[5].HeaderText = "Fringe Rate (CAD)";
            }
            else
            {
                //lblGeneralNoticeProject.Visible = false;
                //rbtnGeneralNoticeProject.Visible = false;
                //lblGeneralForm1000.Visible = false;
                //rbtnGeneralForm1000.Visible = false;

                grdJobClassClassification.Columns[4].HeaderText = "Rate (USD)";
                grdJobClassClassification.Columns[5].HeaderText = "Fringe Rate (USD)";
            }           

            // Project type check
            if (projectGateway.GetProjectType(int.Parse(hdfProjectId.Value)) == "Ballpark")
            {
                // Active Tab
                tcDetailedInformation.ActiveTabIndex = 1;
                
                // Left menu
                tkrpbLeftMenuCurrentProject.Items[0].Text = "Current Ballpark";
                tkrpbLeftMenuCurrentProject.Items[0].Items[0].Text = "Ballpark";
                tkrpbLeftMenuCurrentProject.Items[0].Items[2].Visible = false; //mSeparator
                tkrpbLeftMenuCurrentProject.Items[0].Items[3].Visible = false; //mSections

                // Top Menu
                tkrmTop.Items[1].Visible = false;
                tkrmTop.Items[2].Visible = false;
                tkrmTop.Items[3].Visible = false;
                tkrmTop.Items[4].Visible = true;

                lblHeaderTitle.Text = "Ballpark Summary";
                lblTitleProject.Text = " > Ballpark: ";

                // Initial section
                lblProposalDate.Text = "Ballpark Date";
                lblStartDate.Text = "Potential Start Date";
                lblEndDate.Text = "Potential End Date";
                lblStartDate.Visible = true;
                tbxStartDate.Visible = true;
                lblEndDate.Visible = true;
                tbxEndDate.Visible = true;

                // Client section
                lblClientProjectNumber.Visible = false;
                tbxClientProjectNumber.Visible = false;
                lblClientPrimaryContactId.Visible = false;
                tbxClientPrimaryContact.Visible = false;
                btnClientPrimaryContact.Visible = false;
                lblClientSecondaryContactId.Visible = false;
                tbxClientSecondaryContact.Visible = false;
                btnClientSecondaryContact.Visible = false;

                // Pricing section
                pnlPricing.Visible = true;

                // Tabs visibility                                
                tpJobInfo.Enabled = true;
                upnlTypeOfWork.Visible = false;
                
                // ... for values that comes from sales billing pricing
                //tpSaleBillingPricing.Enabled = false;
                upnlSaleBillingPricingValues.Visible = false;
                upnlSaleBillingPricingValues1.Visible = false;

                // ... for values that comes from costing update
                //tpCostingUpdates.Enabled = false;

                // ... for values that comes from terms po 
                //tpTermsPo.Enabled = false;
                upnlTermsPO.Visible = false;
                upnlTermsPO1.Visible = false;
                upnlTermsPO2.Visible = false;
                upnlTermsPO3.Visible = false;

                // ... for values that comes from technical
                //tpTechnical.Enabled = false;
                upnlTechnical.Visible = false;

                // ... for values that comes from engineer subcontractors
                // tpEngineerSubcontractors.Enabled = true;
                // Subcontractor section
                // lblNoResults.Text = "Sub-Contractors are not defined for this ballpark";
                upnlEngineerSubcontractors.Visible = false;
                upnlEngineerSubcontractors1.Visible = false;
                upnlEngineerSubcontractors2.Visible = false;
                upnlEngineerSubcontractors3.Visible = false;
                upnlEngineerSubcontractors4.Visible = false;
                upnlEngineerSubcontractors5.Visible = false;
                upnlEngineerSubcontractors6.Visible = false;
                upnlEngineerSubcontractors7.Visible = false;

                // ... for values that comes from cost exceptions
                //tpCostExceptions.Enabled = false;
                pnlCostsExceptions.Visible = false;

                // ... for values that comes from notes
                //tpNotes.Enabled = true;
                upnlNotes.Visible = true;
                
                // Project state check
                switch (projectGateway.GetProjectState(int.Parse(hdfProjectId.Value)))
                {
                    case "Active":
                        tkrmTop.Items[4].Items[0].Visible = false; //activate
                        tkrmTop.Items[4].Items[1].Visible = true; //cancel
                        tkrmTop.Items[4].Items[2].Visible = true; //hr
                        tkrmTop.Items[4].Items[3].Visible = true; //Promote to proposal
                        tkrmTop.Items[4].Items[4].Visible = true; //Promote to project
                        break;

                    case "Canceled":
                        tkrmTop.Items[4].Items[0].Visible = true; //activate
                        tkrmTop.Items[4].Items[1].Visible = false; //cancel
                        tkrmTop.Items[4].Items[2].Visible = false; //hr
                        tkrmTop.Items[4].Items[3].Visible = false; //Promote to proposal
                        tkrmTop.Items[4].Items[4].Visible = false; //Promote to project
                        break;
                }
            }

            if (projectGateway.GetProjectType(int.Parse(hdfProjectId.Value)) == "Proposal")
            {
                // Set initial tab
                tcDetailedInformation.ActiveTabIndex = Int32.Parse(hdfActiveTab.Value);

                // Left menu
                tkrpbLeftMenuCurrentProject.Items[0].Text = "Current Proposal";
                tkrpbLeftMenuCurrentProject.Items[0].Items[0].Text = "Proposal";
                tkrpbLeftMenuCurrentProject.Items[0].Items[2].Visible = false; //mSeparator
                tkrpbLeftMenuCurrentProject.Items[0].Items[3].Visible = false; //mSections

                // Top Menu
                tkrmTop.Items[1].Visible = true;
                tkrmTop.Items[2].Visible = false;
                tkrmTop.Items[3].Visible = false;
                tkrmTop.Items[4].Visible = false;

                lblHeaderTitle.Text = "Proposal Summary";
                lblTitleProject.Text = " > Proposal: ";

                lblStartDate.Text = "Potential Start Date";
                lblEndDate.Text = "Potential End Date";

                // Pricing section
                pnlPricing.Visible = false;

                // Tabs visibility               
                tpJobInfo.Enabled = true;
                upnlTypeOfWork.Visible = true;

                // ... for values that comes from sales billing pricing                
                //tpSaleBillingPricing.Enabled = true;
                upnlSaleBillingPricingValues.Visible = true;
                upnlSaleBillingPricingValues1.Visible = true;

                // ... for values that comes from costing updates
                //tpCostingUpdates.Enabled = true;

                // ... for values that comes from terms po 
                //tpTermsPo.Enabled = true;
                upnlTermsPO.Visible = true;
                upnlTermsPO1.Visible = true;
                upnlTermsPO2.Visible = true;
                upnlTermsPO3.Visible = true;

                // ... for values that comes from technical
                //tpTechnical.Enabled = true;
                upnlTechnical.Visible = true;

                // ... for values that comes from engineer subcontractors
                // tpEngineerSubcontractors.Enabled = true;
                // Subcontractor section
                // lblNoResults.Text = "Sub-Contractors are not defined for this proposal";
                upnlEngineerSubcontractors.Visible = true;
                upnlEngineerSubcontractors1.Visible = true;
                upnlEngineerSubcontractors2.Visible = true;
                upnlEngineerSubcontractors3.Visible = true;
                upnlEngineerSubcontractors4.Visible = true;
                upnlEngineerSubcontractors5.Visible = true;
                upnlEngineerSubcontractors6.Visible = true;
                upnlEngineerSubcontractors7.Visible = true;

                // ... for values that comes from cost exceptions
                //tpCostExceptions.Enabled = false;
                pnlCostsExceptions.Visible = false;

                if ((projectGateway.GetProjectState(int.Parse(hdfProjectId.Value)) == "Awarded") || (projectGateway.GetProjectState(int.Parse(hdfProjectId.Value)) == "Bidding"))
                {
                    tpJobInfo.Enabled = true;

                    //tpCostExceptions.Enabled = true;
                    pnlCostsExceptions.Visible = true;
                }

                // ... for values that comes from notes
                //tpNotes.Enabled = true;
                upnlNotes.Visible = true;

                // Project state check
                switch (projectGateway.GetProjectState(int.Parse(hdfProjectId.Value)))
                {
                    case "Bidding":
                        tkrmTop.Items[1].Items[0].Visible = true; //award
                        tkrmTop.Items[1].Items[1].Visible = true; //lost bid
                        tkrmTop.Items[1].Items[2].Visible = true; //cancel
                        tkrmTop.Items[1].Items[3].Visible = false; //bidding
                        tkrmTop.Items[1].Items[4].Visible = true; //hr
                        tkrmTop.Items[1].Items[5].Visible = true; //unpromote
                        tkrmTop.Items[1].Items[6].Visible = false; //promote
                        break;

                    case "Canceled":
                        tkrmTop.Items[1].Items[0].Visible = false;
                        tkrmTop.Items[1].Items[1].Visible = false;
                        tkrmTop.Items[1].Items[2].Visible = false;
                        tkrmTop.Items[1].Items[3].Visible = true;
                        tkrmTop.Items[1].Items[4].Visible = false;
                        tkrmTop.Items[1].Items[5].Visible = false;
                        tkrmTop.Items[1].Items[6].Visible = false;
                        break;

                    case "Lost Bid":
                        tkrmTop.Items[1].Items[0].Visible = false;
                        tkrmTop.Items[1].Items[1].Visible = false;
                        tkrmTop.Items[1].Items[2].Visible = false;
                        tkrmTop.Items[1].Items[3].Visible = true;
                        tkrmTop.Items[1].Items[4].Visible = false; //hr
                        tkrmTop.Items[1].Items[5].Visible = false;
                        tkrmTop.Items[1].Items[6].Visible = false;
                        break;

                    case "Awarded":
                        tkrmTop.Items[1].Items[0].Visible = false;
                        tkrmTop.Items[1].Items[1].Visible = false;
                        tkrmTop.Items[1].Items[2].Visible = false;
                        tkrmTop.Items[1].Items[3].Visible = true;
                        tkrmTop.Items[1].Items[4].Visible = true; //hr
                        tkrmTop.Items[1].Items[5].Visible = false;
                        if (Convert.ToBoolean(Session["sgLFS_PROJECTS_PROMOTEPROPOSALTOPROJECT"]))
                        {
                            tkrmTop.Items[1].Items[6].Visible = true;
                        }
                        else
                        {
                            tkrmTop.Items[1].Items[6].Visible = false;
                        }
                        break;
                }
            }

            if (projectGateway.GetProjectType(int.Parse(hdfProjectId.Value)) == "Project")
            {
                // Set initial tab
                tcDetailedInformation.ActiveTabIndex = Int32.Parse(hdfActiveTab.Value);
                
                // Left menu
                tkrpbLeftMenuCurrentProject.Items[0].Text = "Current Project";
                tkrpbLeftMenuCurrentProject.Items[0].Items[0].Text = "Project";

                // Top Menu
                tkrmTop.Items[1].Visible = false;
                tkrmTop.Items[2].Visible = true;
                tkrmTop.Items[3].Visible = false;
                tkrmTop.Items[4].Visible = false;

                lblHeaderTitle.Text = "Project Summary";
                lblTitleProject.Text = " > Project: ";

                lblStartDate.Text = "Start Date";
                lblEndDate.Text = "End Date";

                // Pricing section
                pnlPricing.Visible = false;

                // Tabs visibility   
                tpJobInfo.Enabled = true;
                upnlTypeOfWork.Visible = true;
                
                // ... for values that comes from sales billing pricing                                
                //tpSaleBillingPricing.Enabled = true;
                upnlSaleBillingPricingValues.Visible = true;
                upnlSaleBillingPricingValues1.Visible = true;

                // ... for values that comes from costing updates
                //tpCostingUpdates.Enabled = true;

                // ... for values that comes from terms po 
                // tpTermsPo.Enabled = true;
                upnlTermsPO.Visible = true;
                upnlTermsPO1.Visible = true;
                upnlTermsPO2.Visible = true;
                upnlTermsPO3.Visible = true;

                // ... for values that comes from technical
                // tpTechnical.Enabled = true;
                upnlTechnical.Visible = true;

                // ... for values that comes from engineer subcontractors
                // tpEngineerSubcontractors.Enabled = true;
                // Subcontractor section
                // lblNoResults.Text = "Sub-Contractors are not defined for this project";
                upnlEngineerSubcontractors.Visible = true;
                upnlEngineerSubcontractors1.Visible = true;
                upnlEngineerSubcontractors2.Visible = true;
                upnlEngineerSubcontractors3.Visible = true;
                upnlEngineerSubcontractors4.Visible = true;
                upnlEngineerSubcontractors5.Visible = true;
                upnlEngineerSubcontractors6.Visible = true;
                upnlEngineerSubcontractors7.Visible = true;

                // ... for values that comes from cost exceptions
                //tpCostExceptions.Enabled = true;
                pnlCostsExceptions.Visible = true;

                // ... for values that comes from notes
                //tpNotes.Enabled = true;                               
                upnlNotes.Visible = true;

                // Project state check
                switch (projectGateway.GetProjectState(int.Parse(hdfProjectId.Value)))
                {
                    case "Waiting":
                        tkrmTop.Items[2].Items[0].Visible = false; //waiting
                        tkrmTop.Items[2].Items[1].Visible = true; //activate
                        tkrmTop.Items[2].Items[2].Visible = false; //inactive
                        tkrmTop.Items[2].Items[3].Visible = false; //complete
                        tkrmTop.Items[2].Items[4].Visible = true; //cancel
                        tkrmTop.Items[2].Items[5].Visible = false; //hr
                        tkrmTop.Items[2].Items[6].Visible = false; //un promote to ballpark
                        tkrmTop.Items[2].Items[7].Visible = false; //un promote to proposal
                        tkrmTop.Items[2].Items[8].Visible = false; //hr
                        tkrmTop.Items[2].Items[9].Visible = false; //tag as internal
                        break;

                    case "Active":
                        tkrmTop.Items[2].Items[0].Visible = true; //waiting
                        tkrmTop.Items[2].Items[1].Visible = false; //activate
                        tkrmTop.Items[2].Items[2].Visible = true; //inactive
                        tkrmTop.Items[2].Items[3].Visible = true; //complete
                        tkrmTop.Items[2].Items[4].Visible = true; //cancel
                        tkrmTop.Items[2].Items[5].Visible = true; //hr
                        tkrmTop.Items[2].Items[6].Visible = true; //un promote to ballpark
                        tkrmTop.Items[2].Items[7].Visible = true; //un promote to proposal
                        tkrmTop.Items[2].Items[8].Visible = true; //hr
                        tkrmTop.Items[2].Items[9].Visible = true; //tag as internal
                        break;

                    case "Inactive":
                        tkrmTop.Items[2].Items[0].Visible = false; //waiting
                        tkrmTop.Items[2].Items[1].Visible = true; //activate
                        tkrmTop.Items[2].Items[2].Visible = false; //inactive
                        tkrmTop.Items[2].Items[3].Visible = false; //complete
                        tkrmTop.Items[2].Items[4].Visible = true; //cancel
                        tkrmTop.Items[2].Items[5].Visible = false; //hr
                        tkrmTop.Items[2].Items[6].Visible = false; //un promote to ballpark
                        tkrmTop.Items[2].Items[7].Visible = false; //un promote to proposal
                        tkrmTop.Items[2].Items[8].Visible = false; //hr
                        tkrmTop.Items[2].Items[9].Visible = false; //tag as internal
                        break;

                    case "Canceled":
                        tkrmTop.Items[2].Items[0].Visible = false; //waiting
                        tkrmTop.Items[2].Items[1].Visible = true; //activate
                        tkrmTop.Items[2].Items[2].Visible = false; //inactive
                        tkrmTop.Items[2].Items[3].Visible = false; //complete
                        tkrmTop.Items[2].Items[4].Visible = false; //cancel
                        tkrmTop.Items[2].Items[5].Visible = false; //hr
                        tkrmTop.Items[2].Items[6].Visible = false; //un promote to ballpark
                        tkrmTop.Items[2].Items[7].Visible = false; //un promote to proposal
                        tkrmTop.Items[2].Items[8].Visible = false; //hr
                        tkrmTop.Items[2].Items[9].Visible = false; //tag as internal
                        break;

                    case "Complete":
                        tkrmTop.Items[2].Items[0].Visible = false; //waiting
                        tkrmTop.Items[2].Items[1].Visible = true; //activate
                        tkrmTop.Items[2].Items[2].Visible = false; //inactive
                        tkrmTop.Items[2].Items[3].Visible = false; //complete
                        tkrmTop.Items[2].Items[4].Visible = false; //cancel
                        tkrmTop.Items[2].Items[5].Visible = false; //hr
                        tkrmTop.Items[2].Items[6].Visible = false; //un promote to ballpark
                        tkrmTop.Items[2].Items[7].Visible = false; //un promote to proposal
                        tkrmTop.Items[2].Items[8].Visible = false; //hr
                        tkrmTop.Items[2].Items[9].Visible = false; //tag as internal
                        break;
                }
            }

            if (projectGateway.GetProjectType(int.Parse(hdfProjectId.Value)) == "Internal")
            {
                // Active Tab
                tcDetailedInformation.ActiveTabIndex = 1;

                // Left menu
                tkrpbLeftMenuCurrentProject.Items[0].Text = "Current Internal Project";
                tkrpbLeftMenuCurrentProject.Items[0].Items[0].Text = "Internal Project";
                tkrpbLeftMenuCurrentProject.Items[0].Items[2].Visible = false; //mSeparator
                tkrpbLeftMenuCurrentProject.Items[0].Items[3].Visible = false; //mSections

                // Top Menu
                tkrmTop.Items[1].Visible = false;
                tkrmTop.Items[2].Visible = false;
                tkrmTop.Items[3].Visible = true;
                tkrmTop.Items[4].Visible = false;

                lblHeaderTitle.Text = "Internal Project Summary";
                lblTitleProject.Text = " > Internal Project: ";

                // Initial section
                lblProposalDate.Text = "Internal Project Date";
                lblStartDate.Visible = false;
                tbxStartDate.Visible = false;
                lblEndDate.Visible = false;
                tbxEndDate.Visible = false;
                tbxDescription.Width = Unit.Pixel(510);

                // Client section
                lblClientProjectNumber.Visible = false;
                tbxClientProjectNumber.Visible = false;
                lblClientPrimaryContactId.Visible = false;
                tbxClientPrimaryContact.Visible = false;
                btnClientPrimaryContact.Visible = false;
                lblClientSecondaryContactId.Visible = false;
                tbxClientSecondaryContact.Visible = false;
                btnClientSecondaryContact.Visible = false;

                // Pricing section
                pnlPricing.Visible = false;

                // Tabs visibility              
                tpJobInfo.Enabled = true;
                upnlTypeOfWork.Visible = false;
                
                // ... for values that comes from sales billing pricing                                
                //tpSaleBillingPricing.Enabled = false;
                upnlSaleBillingPricingValues.Visible = false;
                upnlSaleBillingPricingValues1.Visible = false;

                // ... for values that comes from costing updates
                // tpCostingUpdates.Enabled = false;

                // ... for values that comes from terms po 
                //tpTermsPo.Enabled = false;
                upnlTermsPO.Visible = false;
                upnlTermsPO1.Visible = false;
                upnlTermsPO2.Visible = false;
                upnlTermsPO3.Visible = false;

                // ... for values that comes from technical
                //tpTechnical.Enabled = false;
                upnlTechnical.Visible = false;

                // ... for values that comes from engineer subcontractors
                // tpEngineerSubcontractors.Enabled = true;
                // Subcontractor section
                // lblNoResults.Text = "Sub-Contractors are not defined for this internal project";
                upnlEngineerSubcontractors.Visible = false;
                upnlEngineerSubcontractors1.Visible = false;
                upnlEngineerSubcontractors2.Visible = false;
                upnlEngineerSubcontractors3.Visible = false;
                upnlEngineerSubcontractors4.Visible = false;
                upnlEngineerSubcontractors5.Visible = false;
                upnlEngineerSubcontractors6.Visible = false;
                upnlEngineerSubcontractors7.Visible = false;

                // ... for values that comes from cost exceptions
                //tpCostExceptions.Enabled = false;
                pnlCostsExceptions.Visible = false;

                // ... for values that comes from notes
                //tpNotes.Enabled = true;
                upnlNotes.Visible = true;

                // Project state check
                switch (projectGateway.GetProjectState(int.Parse(hdfProjectId.Value)))
                {
                    case "Active":
                        tkrmTop.Items[3].Items[0].Visible = false; //activate
                        tkrmTop.Items[3].Items[1].Visible = true; //cancel
                        tkrmTop.Items[3].Items[2].Visible = true; //complete
                        tkrmTop.Items[2].Items[3].Visible = true; //hr
                        tkrmTop.Items[3].Items[4].Visible = true; //promote to proposal
                        tkrmTop.Items[3].Items[5].Visible = true; //promote to project
                        break;

                    case "Canceled":
                        tkrmTop.Items[3].Items[0].Visible = true; //activate
                        tkrmTop.Items[3].Items[1].Visible = false; //cancel
                        tkrmTop.Items[3].Items[2].Visible = false; //complete
                        tkrmTop.Items[2].Items[3].Visible = false; //hr
                        tkrmTop.Items[3].Items[4].Visible = false; //promote to proposal
                        tkrmTop.Items[3].Items[5].Visible = false; //promote to project
                        break;

                    case "Complete":
                        tkrmTop.Items[3].Items[0].Visible = true; //activate
                        tkrmTop.Items[3].Items[1].Visible = false; //cancel
                        tkrmTop.Items[3].Items[2].Visible = false; //complete
                        tkrmTop.Items[2].Items[3].Visible = false; //hr
                        tkrmTop.Items[3].Items[4].Visible = false; //promote to proposal
                        tkrmTop.Items[3].Items[5].Visible = false; //promote to project
                        break;
                }
            }            
        }

        




        // ////////////////////////////////////////////////////////////////////////
        // AUXILIAR EVENTS
        //

        protected void btnNotesOnClick(object sender, EventArgs e)
        {
            // Store active tab for postback
            Session["hdfActiveTab"] = "0";
            Session["dialogOpened"] = "1";

            // Open Dialog                      
            string script = "<script language='javascript'>";
            string url = "./project_notes.aspx?source_page=project_summary.aspx&client_id=" + hdfClientId.Value + "&project_id=" + hdfProjectId.Value;
            script = script + string.Format("window.open('{0}', '_blank', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=795, height=640')", url);
            script = script + "</script>";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Comments", script, false);
        }



        // Sale/Billing/Pricing - Services
        //protected void grdServices_DataBound(object sender, EventArgs e)
        //{
        //    AddServicesNewEmptyFix(grdServices);
        //}



        // Type Of Work Function Classification - Cost Exceptions
        protected void grdTypeOfWorkFunctionClassification_DataBound(object sender, EventArgs e)
        {
            AddTypeOfWorkFunctionClassificationNewEmptyFix(grdTypeOfWorkFunctionClassification);
        }



        protected void grdSubcontractorsBudget_DataBound(object sender, EventArgs e)
        {
            //AddSubcontractorsBudgetNewEmptyFix(grdSubcontractorsBudget);
        }



        protected void grdHotelsBudget_DataBound(object sender, EventArgs e)
        {
            //AddHotelsBudgetNewEmptyFix(grdHotelsBudget);
        }



        protected void grdBondingsBudget_DataBound(object sender, EventArgs e)
        {
            //AddBondingsBudgetNewEmptyFix(grdBondingsBudget);
        }



        protected void grdInsurancesBudget_DataBound(object sender, EventArgs e)
        {
            //AddInsurancesBudgetNewEmptyFix(grdInsurancesBudget);
        }



        protected void grdOthersBudget_DataBound(object sender, EventArgs e)
        {
            AddOtherCostsBudgetNewEmptyFix(grdOthersBudget);
        }



        protected void grdBudget_DataBound(object sender, EventArgs e)
        {
            AddTypeOfWorkFunctionBudgetNewEmptyFix(grdBudget);
        }



        // Job Class Classification - Cost Exceptions
        protected void grdJobClassClassification_DataBound(object sender, EventArgs e)
        {
            AddJobClassClassificationNewEmptyFix(grdJobClassClassification);
        }



        //protected void grdServices_RowDataBound(object sender, GridViewRowEventArgs e)
        //{           
        //    if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Normal) || (e.Row.RowState == (DataControlRowState.Normal | DataControlRowState.Alternate))))
        //    {
        //        // Initialize values                
        //        int projectId = Int32.Parse(((Label)e.Row.FindControl("lblProjectId")).Text);
        //        if (projectId >= 0)
        //        {
        //            int refId = Int32.Parse(((Label)e.Row.FindControl("lblRefId")).Text);

        //            // For Services
        //            ProjectNavigatorProjectServiceGateway projectNavigatorProjectServiceGateway = new ProjectNavigatorProjectServiceGateway(projectNavigatorTDS);
        //            int? serviceId = projectNavigatorProjectServiceGateway.GetServiceID(projectId, refId);

        //            string serviceName = "(Other)";
        //            if ((serviceId.HasValue) && ((int)serviceId != -1))
        //            {
        //                // ... Get name
        //                ServiceGateway serviceGateway = new ServiceGateway();
        //                serviceGateway.LoadByServiceId((int)serviceId, Int32.Parse(hdfCompanyId.Value));
        //                serviceName = serviceGateway.GetName((int)serviceId);
        //            }

        //            // ... Set name
        //            ((Label)e.Row.FindControl("lblService")).Text = serviceName;
        //        }
        //    }
        //}



        // Engineer - Subcontractors
        //protected void grdvSubcontractors_PreRender(object sender, EventArgs e)
        //{
        //    // Filter
        //    DataView dataViewSubcontractors = new DataView(projectTDS.LFS_PROJECT_SUBCONTRACTOR);
        //    dataViewSubcontractors.RowFilter = "(Deleted = 0)";
        //    grdvSubcontractors.DataSource = dataViewSubcontractors;

        //    grdvSubcontractors.DataBind();

        //    // Sub-Contractors
        //    if (grdvSubcontractors.Rows.Count > 0)
        //    {
        //        tNoResults.Visible = false;
        //    }
        //    else
        //    {
        //        tNoResults.Visible = true;
        //    }
        //}
        


        // Notes
        //protected void grdNotes_DataBound(object sender, EventArgs e)
        //{
        //    AddNotesNewEmptyFix(grdNotes);
        //}


                
        //protected void grdNotes_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    // Normal items
        //    if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Normal) || (e.Row.RowState == (DataControlRowState.Normal | DataControlRowState.Alternate))))
        //    {
        //        string originalFileName = ((TextBox)e.Row.FindControl("tbxNoteAttachment")).Text;
        //        string fileName = ((Label)e.Row.FindControl("lblFileName")).Text;

        //        // Button visibility
        //        if (originalFileName == "")
        //        {
        //            ((Button)e.Row.FindControl("btnNoteDownload")).Visible = false;
        //        }
        //        else
        //        {
        //            ((Button)e.Row.FindControl("btnNoteDownload")).Visible = true;
        //        }
        //    }
        //}



        //protected void grdNotes_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    switch (e.CommandName)
        //    {
        //        case "DownloadAttachment":
        //            GridViewRow rowDonwload = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
        //            string originalFileName = ((TextBox)rowDonwload.FindControl("tbxNoteAttachment")).Text;
        //            string fileName = ((Label)rowDonwload.FindControl("lblFileName")).Text;
        //            GrdNotesOpenAttachment(originalFileName, fileName);
        //            break;
        //    }
        //}






        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATION EVENTS
        //

        protected void tkrmTop_ItemClick(object sender, RadMenuEventArgs e)
        {
            // Store active tab for postback
            Session["activeTabProjects"] = "0";
            Session["dialogOpenedProjects"] = "0";
            Session.Remove("lfsLibraryTDS");
            Session.Remove("fromAttachment");

            string activeTab = hdfActiveTab.Value;
            string url = "";

            switch (e.Item.Value)
            {
                case "mAddSubcontractor":
                    Session["activeTabProjects"] = "4";
                    break;

                // Go to Works
                case "mRehabAssessment":
                    url = "./../../CWP/RehabAssessment/ra_navigator.aspx?source_page=select_project.aspx&client_id=" + hdfClientId.Value + "&project_id=" + hdfProjectId.Value + "&work_type=Rehab Assessment";
                    break;

                case "mFullLenghtLining":
                    url = "./../../CWP/FullLengthLining/fl_navigator.aspx?source_page=select_project.aspx&client_id=" + hdfClientId.Value + "&project_id=" + hdfProjectId.Value + "&work_type=Full Length Lining";
                    break;

                case "mPointRepairs":
                    url = "./../../CWP/PointRepairs/pr_navigator.aspx?source_page=select_project.aspx&client_id=" + hdfClientId.Value + "&project_id=" + hdfProjectId.Value + "&work_type=Point Repairs";
                    break;

                case "mJunctionLining":
                    url = "./../../CWP/JunctionLining/jl_navigator.aspx?source_page=select_project.aspx&client_id=" + hdfClientId.Value + "&project_id=" + hdfProjectId.Value + "&work_type=Junction Lining";
                    break;

                // Change State
                // Proposal
                case "mProposalAward":
                    url = "./project_state.aspx?source_page=project_summary.aspx&state=proposal_award&project_id=" + hdfProjectId.Value + "&active_tab=" + hdfActiveTab.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    break;

                case "mProposalLostBid":
                    url = "./project_state.aspx?source_page=project_summary.aspx&state=proposal_lost_bid&project_id=" + hdfProjectId.Value + "&active_tab=" + hdfActiveTab.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    break;

                case "mProposalCancel":
                    url = "./project_state.aspx?source_page=project_summary.aspx&state=proposal_cancel&project_id=" + hdfProjectId.Value + "&active_tab=" + hdfActiveTab.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    break;

                case "mProposalBidding":
                    url = "./project_state.aspx?source_page=project_summary.aspx&state=proposal_bidding&project_id=" + hdfProjectId.Value + "&active_tab=" + hdfActiveTab.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    break;

                case "mProposalUnpromoteToBallpark":
                    url = "./project_state.aspx?source_page=project_summary.aspx&state=proposal_unpromote_to_ballpark&project_id=" + hdfProjectId.Value + "&active_tab=" + hdfActiveTab.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    break;

                case "mProposalPromoteToProject":
                    url = "./project_state.aspx?source_page=project_summary.aspx&state=proposal_promote_to_project&project_id=" + hdfProjectId.Value + "&active_tab=" + hdfActiveTab.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    break;

                // Project
                case "mProjectSetWaiting":
                    url = "./project_state.aspx?source_page=project_summary.aspx&state=project_waiting&project_id=" + hdfProjectId.Value + "&active_tab=" + hdfActiveTab.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    break;

                case "mProjectActivate":
                    url = "./project_state.aspx?source_page=project_summary.aspx&state=project_activate&project_id=" + hdfProjectId.Value + "&active_tab=" + hdfActiveTab.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    break;

                case "mProjectInactivate":
                    url = "./project_state.aspx?source_page=project_summary.aspx&state=project_inactivate&project_id=" + hdfProjectId.Value + "&active_tab=" + hdfActiveTab.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    break;

                case "mProjectComplete":
                    url = "./project_state.aspx?source_page=project_summary.aspx&state=project_complete&project_id=" + hdfProjectId.Value + "&active_tab=" + hdfActiveTab.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    break;

                case "mProjectCancel":
                    url = "./project_state.aspx?source_page=project_summary.aspx&state=project_cancel&project_id=" + hdfProjectId.Value + "&active_tab=" + hdfActiveTab.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    break;

                case "mProjectUnpromoteToBallpark":
                    url = "./project_state.aspx?source_page=project_summary.aspx&state=project_unpromote_to_ballpark&project_id=" + hdfProjectId.Value + "&active_tab=" + hdfActiveTab.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    break;

                case "mProjectUnpromoteToProposal":
                    url = "./project_state.aspx?source_page=project_summary.aspx&state=project_unpromote_to_proposal&project_id=" + hdfProjectId.Value + "&active_tab=" + hdfActiveTab.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    break;

                case "mProjectTagAsInternal":
                    url = "./project_state.aspx?source_page=project_summary.aspx&state=project_tagAsInternal&project_id=" + hdfProjectId.Value + "&active_tab=" + hdfActiveTab.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    break;

                // Internal project
                case "mInternalProjectActivate":
                    url = "./project_state.aspx?source_page=project_summary.aspx&state=internalProject_activate&project_id=" + hdfProjectId.Value + "&active_tab=" + hdfActiveTab.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    break;

                case "mInternalProjectComplete":
                    url = "./project_state.aspx?source_page=project_summary.aspx&state=internalProject_complete&project_id=" + hdfProjectId.Value + "&active_tab=" + hdfActiveTab.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    break;

                case "mInternalProjectCancel":
                    url = "./project_state.aspx?source_page=project_summary.aspx&state=internalProject_cancel&project_id=" + hdfProjectId.Value + "&active_tab=" + hdfActiveTab.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    break;

                case "mInternalProjectPromoteToProposal":
                    url = "./project_state.aspx?source_page=project_summary.aspx&state=internalProject_promote_to_proposal&project_id=" + hdfProjectId.Value + "&active_tab=" + hdfActiveTab.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    break;

                case "mInternalProjectPromoteToProject":
                    url = "./project_state.aspx?source_page=project_summary.aspx&state=internalProject_promote_to_project&project_id=" + hdfProjectId.Value + "&active_tab=" + hdfActiveTab.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    break;

                // Ballpark
                case "mBallparkProjectActivate":
                    url = "./project_state.aspx?source_page=project_summary.aspx&state=ballparkProject_activate&project_id=" + hdfProjectId.Value + "&active_tab=" + hdfActiveTab.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    break;

                case "mBallparkProjectCancel":
                    url = "./project_state.aspx?source_page=project_summary.aspx&state=ballparkProject_cancel&project_id=" + hdfProjectId.Value + "&active_tab=" + hdfActiveTab.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    break;

                case "mBallparkProjectPromoteToProposal":
                    url = "./project_state.aspx?source_page=project_summary.aspx&state=ballparkProject_promote_to_proposal&project_id=" + hdfProjectId.Value + "&active_tab=" + hdfActiveTab.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    break;

                case "mBallparkProjectPromoteToProject":
                    url = "./project_state.aspx?source_page=project_summary.aspx&state=ballparkProject_promote_to_project&project_id=" + hdfProjectId.Value + "&active_tab=" + hdfActiveTab.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    break;

                // General
                case "mEdit":
                    url = "./project_edit.aspx?source_page=project_summary.aspx&project_id=" + hdfProjectId.Value + "&active_tab=" + hdfActiveTab.Value + GetNavigatorState() + "&origin=summary&update=" + (string)ViewState["update"] + "&data_changed=no";
                    break;

                case "mDelete":
                    url = "./project_delete.aspx?source_page=project_summary.aspx&project_id=" + hdfProjectId.Value + "&active_tab=" + hdfActiveTab.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    break;

                case "mLastSearch":
                    if (Request.QueryString["origin"] != null)
                    {
                        if (Request.QueryString["origin"].ToString() == "grid")
                        {
                            url = "./projects.aspx?source_page=projects2.aspx&" + GetNavigatorState() + "&no_results=no";
                        }
                        else
                        {
                            url = "./projects2.aspx?source_page=project_summary.aspx&project_id=" + hdfProjectId.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                        }
                    }
                    else
                    {
                        if (Session["lfsProjectNavigatorTDS"] == null)
                        {
                            url = "./projects.aspx?source_page=projects2.aspx&" + GetNavigatorState() + "&no_results=no";
                        }
                        else
                        {
                            url = "./projects2.aspx?source_page=project_summary.aspx&project_id=" + hdfProjectId.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                        }
                    }
                    break;

                case "mPrevious":
                    if (Request.QueryString["origin"] != null)
                    {
                        if (Request.QueryString["origin"].ToString() == "grid")
                        {
                            // Get previous record
                            int previousId = ProjectNavigator.GetPreviousId2((ProjectSelectProjectTDS)Session["projectSelectProjectTDS"], Int32.Parse(hdfProjectId.Value));
                            if (previousId != Int32.Parse(hdfProjectId.Value))
                            {
                                // Redirect
                                url = "./project_summary.aspx?source_page=projects2.aspx&project_id=" + previousId.ToString() + "&active_tab=" + activeTab + GetNavigatorState() + "&origin=grid";
                            }
                        }
                        else
                        {
                            // Get previous record
                            int previousId = ProjectNavigator.GetPreviousId((ProjectNavigatorTDS)Session["lfsProjectNavigatorTDS"], Int32.Parse(hdfProjectId.Value));
                            if (previousId != Int32.Parse(hdfProjectId.Value))
                            {
                                // Redirect
                                url = "./project_summary.aspx?source_page=projects2.aspx&project_id=" + previousId.ToString() + "&active_tab=" + activeTab + GetNavigatorState();
                            }
                        }
                    }
                    else
                    {
                        if (Session["lfsProjectNavigatorTDS"] == null)
                        {
                            // Get previous record
                            int previousId = ProjectNavigator.GetPreviousId2((ProjectSelectProjectTDS)Session["projectSelectProjectTDS"], Int32.Parse(hdfProjectId.Value));
                            if (previousId != Int32.Parse(hdfProjectId.Value))
                            {
                                // Redirect
                                url = "./project_summary.aspx?source_page=projects2.aspx&project_id=" + previousId.ToString() + "&active_tab=" + activeTab + GetNavigatorState() + "&origin=grid";
                            }
                        }
                        else
                        {
                            // Get previous record
                            int previousId = ProjectNavigator.GetPreviousId((ProjectNavigatorTDS)Session["lfsProjectNavigatorTDS"], Int32.Parse(hdfProjectId.Value));
                            if (previousId != Int32.Parse(hdfProjectId.Value))
                            {
                                // Redirect
                                url = "./project_summary.aspx?source_page=projects2.aspx&project_id=" + previousId.ToString() + "&active_tab=" + activeTab + GetNavigatorState();
                            }
                        }
                    }
                    break;

                case "mNext":
                    if (Request.QueryString["origin"] != null)
                    {
                        if (Request.QueryString["origin"].ToString() == "grid")
                        {
                            // Get previous record
                            int previousId = ProjectNavigator.GetNextId2((ProjectSelectProjectTDS)Session["projectSelectProjectTDS"], Int32.Parse(hdfProjectId.Value));
                            if (previousId != Int32.Parse(hdfProjectId.Value))
                            {
                                // Redirect
                                url = "./project_summary.aspx?source_page=projects2.aspx&project_id=" + previousId.ToString() + "&active_tab=" + activeTab + GetNavigatorState() + "&origin=grid";
                            }
                        }
                        else
                        {
                            // Get next record
                            int nextId = ProjectNavigator.GetNextId((ProjectNavigatorTDS)Session["lfsProjectNavigatorTDS"], Int32.Parse(hdfProjectId.Value));
                            if (nextId != Int32.Parse(hdfProjectId.Value))
                            {
                                // Redirect
                                url = "./project_summary.aspx?source_page=projects2.aspx&project_id=" + nextId.ToString() + "&active_tab=" + activeTab + GetNavigatorState();
                            }
                        }
                    }
                    else
                    {
                        if (Session["lfsProjectNavigatorTDS"] == null)
                        {
                            // Get previous record
                            int previousId = ProjectNavigator.GetNextId2((ProjectSelectProjectTDS)Session["projectSelectProjectTDS"], Int32.Parse(hdfProjectId.Value));
                            if (previousId != Int32.Parse(hdfProjectId.Value))
                            {
                                // Redirect
                                url = "./project_summary.aspx?source_page=projects2.aspx&project_id=" + previousId.ToString() + "&active_tab=" + activeTab + GetNavigatorState() + "&origin=grid";
                            }
                        }
                        else
                        {
                            // Get next record
                            int nextId = ProjectNavigator.GetNextId((ProjectNavigatorTDS)Session["lfsProjectNavigatorTDS"], Int32.Parse(hdfProjectId.Value));
                            if (nextId != Int32.Parse(hdfProjectId.Value))
                            {
                                // Redirect
                                url = "./project_summary.aspx?source_page=projects2.aspx&project_id=" + nextId.ToString() + "&active_tab=" + activeTab + GetNavigatorState();
                            }
                        }
                    }
                    break;
            }

            if (url != "") Response.Redirect(url);
        }



        protected void tkrpbLeftMenu_ItemClick(object sender, RadPanelBarEventArgs e)
        {
            // Store active tab for postback
            Session["activeTabProjects"] = "0";
            Session["dialogOpenedProjects"] = "0";

            string url = "";

            switch (e.Item.Value)
            {
                case "mProjectCostingSheets":
                    url = "./project_costing_sheets_navigator.aspx?source_page=project_summary.aspx&project_id=" + hdfProjectId.Value + "&active_tab=" + hdfActiveTab.Value + GetNavigatorState() + "&origin=summary&update=" + (string)ViewState["update"] + "&data_changed=no&state=summary";
                    break;

                case "mSections":
                    url = "./project_sections_navigator.aspx?source_page=lm&project_id=" + hdfProjectId.Value + "&active_tab=" + hdfActiveTab.Value + GetNavigatorState() + "&origin=summary&update=" + (string)ViewState["update"] + "&data_changed=no&state=summary";
                    break;

                case "mSearch":
                    Session.Remove("lfsLibraryTDS");
                    Session.Remove("fromAttachment");
                    url = "./projects.aspx?source_page=lm";
                    break;
            }

            if (url != "") Response.Redirect(url);
        }






        // ////////////////////////////////////////////////////////////////////////
        //  METHODS
        //

        public ProjectNavigatorTDS.ProjectNotesDataTable GetNotesNew()
        {
            projectNotes = (ProjectNavigatorTDS.ProjectNotesDataTable)Session["projectNotesDummy"];
            if (projectNotes == null)
            {
                projectNotes = ((ProjectNavigatorTDS.ProjectNotesDataTable)Session["projectNotes"]);
            }

            return projectNotes;
        }



        public ProjectNavigatorTDS.ProjectServiceDataTable GetServiceNew()
        {
            projectServices = (ProjectNavigatorTDS.ProjectServiceDataTable)Session["projectServicesDummy"];
            if (projectServices == null)
            {
                projectServices = ((ProjectNavigatorTDS.ProjectServiceDataTable)Session["projectServices"]);
            }

            return projectServices;
        }



        public ProjectNavigatorTDS.LFS_PROJECT_WORK_FUNCTION_FAIR_WAGEDataTable GetTypeOfWorkFunctionClassificationNew()
        {
            projectTypeOfWorkFunctionClassification = (ProjectNavigatorTDS.LFS_PROJECT_WORK_FUNCTION_FAIR_WAGEDataTable)Session["projectTypeOfWorkFunctionClassificationDummy"];
            if (projectTypeOfWorkFunctionClassification == null)
            {
                projectTypeOfWorkFunctionClassification = ((ProjectNavigatorTDS.LFS_PROJECT_WORK_FUNCTION_FAIR_WAGEDataTable)Session["projectTypeOfWorkFunctionClassification"]);
            }

            return projectTypeOfWorkFunctionClassification;
        }



        public ProjectNavigatorTDS.ProjectWorkFunctionBudgetDataTable GetTypeOfWorkFunctionBudgetNew()
        {
            projectBudget = (ProjectNavigatorTDS.ProjectWorkFunctionBudgetDataTable)Session["projectBudgetDummy"];
            if (projectBudget == null)
            {
                projectBudget = ((ProjectNavigatorTDS.ProjectWorkFunctionBudgetDataTable)Session["projectBudget"]);
            }

            return projectBudget;
        }



        public ProjectNavigatorTDS.ProjectSubcontractorsBudgetDataTable GetSubcontractorsBudgetNew()
        {
            subcontractorsBudget = (ProjectNavigatorTDS.ProjectSubcontractorsBudgetDataTable)Session["subcontractorsBudgetDummy"];
            if (subcontractorsBudget == null)
            {
                subcontractorsBudget = ((ProjectNavigatorTDS.ProjectSubcontractorsBudgetDataTable)Session["subcontractorsBudget"]);
            }

            return subcontractorsBudget;
        }



        public ProjectNavigatorTDS.ProjectHotelsBudgetDataTable GetHotelsBudgetNew()
        {
            hotelsBudget = (ProjectNavigatorTDS.ProjectHotelsBudgetDataTable)Session["hotelsBudgetDummy"];
            if (hotelsBudget == null)
            {
                hotelsBudget = ((ProjectNavigatorTDS.ProjectHotelsBudgetDataTable)Session["hotelsBudget"]);
            }

            return hotelsBudget;
        }



        public ProjectNavigatorTDS.ProjectBondingsBudgetDataTable GetBondingsBudgetNew()
        {
            bondingsBudget = (ProjectNavigatorTDS.ProjectBondingsBudgetDataTable)Session["bondingsBudgetDummy"];
            if (bondingsBudget == null)
            {
                bondingsBudget = ((ProjectNavigatorTDS.ProjectBondingsBudgetDataTable)Session["bondingsBudget"]);
            }

            return bondingsBudget;
        }



        public ProjectNavigatorTDS.ProjectInsurancesBudgetDataTable GetInsurancesBudgetNew()
        {
            insurancesBudget = (ProjectNavigatorTDS.ProjectInsurancesBudgetDataTable)Session["insurancesBudgetDummy"];
            if (insurancesBudget == null)
            {
                insurancesBudget = ((ProjectNavigatorTDS.ProjectInsurancesBudgetDataTable)Session["insurancesBudget"]);
            }

            return insurancesBudget;
        }



        public ProjectNavigatorTDS.ProjectOtherCostsBudgetDataTable GetOthersBudgetNew()
        {
            otherCostsBudget = (ProjectNavigatorTDS.ProjectOtherCostsBudgetDataTable)Session["otherCostsBudgetDummy"];
            if (otherCostsBudget == null)
            {
                otherCostsBudget = ((ProjectNavigatorTDS.ProjectOtherCostsBudgetDataTable)Session["otherCostsBudget"]);
            }

            return otherCostsBudget;
        }



        public ProjectNavigatorTDS.LFS_PROJECT_JOB_CLASS_TYPE_RATEDataTable GetJobClassClassificationNew()
        {
            projectJobClassClassification = (ProjectNavigatorTDS.LFS_PROJECT_JOB_CLASS_TYPE_RATEDataTable)Session["projectJobClassClassificationDummy"];
            if (projectJobClassClassification == null)
            {
                projectJobClassClassification = ((ProjectNavigatorTDS.LFS_PROJECT_JOB_CLASS_TYPE_RATEDataTable)Session["projectJobClassClassification"]);
            }

            return projectJobClassClassification;
        }



        //protected void AddNotesNewEmptyFix(GridView grdView)
        //{
        //    if (grdNotes.Rows.Count == 0)
        //    {
        //        ProjectNavigatorTDS.ProjectNotesDataTable dt = new ProjectNavigatorTDS.ProjectNotesDataTable();
        //        dt.AddProjectNotesRow(-1, -1, "", DateTime.Now, -1, "", false,-1,  3, "", "", false);
        //        Session["projectNotesDummy"] = dt;

        //        grdNotes.DataBind();
        //    }

        //    // Normally executes at all postbacks
        //    if (grdNotes.Rows.Count == 1)
        //    {
        //        ProjectNavigatorTDS.ProjectNotesDataTable dt = (ProjectNavigatorTDS.ProjectNotesDataTable)Session["projectNotesDummy"];
        //        if (dt != null)
        //        {
        //            grdNotes.Rows[0].Visible = false;
        //            grdNotes.Rows[0].Controls.Clear();
        //        }
        //    }
        //}



        protected void AddServicesNewEmptyFix(GridView grdView)
        {
            if (grdView.Rows.Count == 0)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                ProjectNavigatorTDS.ProjectServiceDataTable dt = new ProjectNavigatorTDS.ProjectServiceDataTable();
                dt.AddProjectServiceRow(-1, -1, -1, "", "", -1, -1, false, companyId, false, -1);
                Session["projectServicesDummy"] = dt;

                grdView.DataBind();
            }

            // Normally executes at all postbacks
            if (grdView.Rows.Count == 1)
            {
                ProjectNavigatorTDS.ProjectServiceDataTable dt = (ProjectNavigatorTDS.ProjectServiceDataTable)Session["projectServicesDummy"];
                if (dt != null)
                {
                    grdView.Rows[0].Visible = false;
                    grdView.Rows[0].Controls.Clear();
                }
            }
        }



        protected void AddTypeOfWorkFunctionClassificationNewEmptyFix(GridView grdView)
        {
            if (grdView.Rows.Count == 0)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                ProjectNavigatorTDS.LFS_PROJECT_WORK_FUNCTION_FAIR_WAGEDataTable dt = new ProjectNavigatorTDS.LFS_PROJECT_WORK_FUNCTION_FAIR_WAGEDataTable();
                dt.AddLFS_PROJECT_WORK_FUNCTION_FAIR_WAGERow(0,"","",0,false,false, companyId,false,"");
                Session["projectTypeOfWorkFunctionClassificationDummy"] = dt;

                grdView.DataBind();
            }

            // Normally executes at all postbacks
            if (grdView.Rows.Count == 1)
            {
                ProjectNavigatorTDS.LFS_PROJECT_WORK_FUNCTION_FAIR_WAGEDataTable dt = (ProjectNavigatorTDS.LFS_PROJECT_WORK_FUNCTION_FAIR_WAGEDataTable)Session["projectTypeOfWorkFunctionClassificationDummy"];
                if (dt != null)
                {
                    grdView.Rows[0].Visible = false;
                    grdView.Rows[0].Controls.Clear();
                }
            }
        }



        protected void AddTypeOfWorkFunctionBudgetNewEmptyFix(GridView grdView)
        {
            if (grdView.Rows.Count == 0)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                ProjectNavigatorTDS.ProjectWorkFunctionBudgetDataTable dt = new ProjectNavigatorTDS.ProjectWorkFunctionBudgetDataTable();
                dt.AddProjectWorkFunctionBudgetRow(0,"","",0,0, false, companyId,false,"", 0);
                Session["projectBudgetDummy"] = dt;

                grdView.DataBind();
            }

            // Normally executes at all postbacks
            if (grdView.Rows.Count == 1)
            {
                ProjectNavigatorTDS.ProjectWorkFunctionBudgetDataTable dt = (ProjectNavigatorTDS.ProjectWorkFunctionBudgetDataTable)Session["projectBudgetDummy"];
                if (dt != null)
                {
                    grdView.Rows[0].Visible = false;
                    grdView.Rows[0].Controls.Clear();
                }
            }
        }



        protected void AddSubcontractorsBudgetNewEmptyFix(GridView grdView)
        {
            if (grdView.Rows.Count == 0)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                ProjectNavigatorTDS.ProjectSubcontractorsBudgetDataTable dt = new ProjectNavigatorTDS.ProjectSubcontractorsBudgetDataTable();
                dt.AddProjectSubcontractorsBudgetRow(0, 0, 0, 0, false, companyId, false, "");
                Session["subcontractorsBudgetDummy"] = dt;

                grdView.DataBind();
            }

            // Normally executes at all postbacks
            if (grdView.Rows.Count == 1)
            {
                ProjectNavigatorTDS.ProjectSubcontractorsBudgetDataTable dt = (ProjectNavigatorTDS.ProjectSubcontractorsBudgetDataTable)Session["subcontractorsBudgetDummy"];
                if (dt != null)
                {
                    grdView.Rows[0].Visible = false;
                    grdView.Rows[0].Controls.Clear();
                }
            }
        }



        protected void AddHotelsBudgetNewEmptyFix(GridView grdView)
        {
            if (grdView.Rows.Count == 0)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                ProjectNavigatorTDS.ProjectHotelsBudgetDataTable dt = new ProjectNavigatorTDS.ProjectHotelsBudgetDataTable();
                dt.AddProjectHotelsBudgetRow(0, 0, 0, 0, false, companyId, false, "");
                Session["hotelsBudgetDummy"] = dt;

                grdView.DataBind();
            }

            // Normally executes at all postbacks
            if (grdView.Rows.Count == 1)
            {
                ProjectNavigatorTDS.ProjectHotelsBudgetDataTable dt = (ProjectNavigatorTDS.ProjectHotelsBudgetDataTable)Session["hotelsBudgetDummy"];
                if (dt != null)
                {
                    grdView.Rows[0].Visible = false;
                    grdView.Rows[0].Controls.Clear();
                }
            }
        }



        protected void AddBondingsBudgetNewEmptyFix(GridView grdView)
        {
            if (grdView.Rows.Count == 0)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                ProjectNavigatorTDS.ProjectBondingsBudgetDataTable dt = new ProjectNavigatorTDS.ProjectBondingsBudgetDataTable();
                dt.AddProjectBondingsBudgetRow(0, 0, 0, 0, false, companyId, false, "");
                Session["bondingsBudgetDummy"] = dt;

                grdView.DataBind();
            }

            // Normally executes at all postbacks
            if (grdView.Rows.Count == 1)
            {
                ProjectNavigatorTDS.ProjectBondingsBudgetDataTable dt = (ProjectNavigatorTDS.ProjectBondingsBudgetDataTable)Session["bondingsBudgetDummy"];
                if (dt != null)
                {
                    grdView.Rows[0].Visible = false;
                    grdView.Rows[0].Controls.Clear();
                }
            }
        }



        protected void AddInsurancesBudgetNewEmptyFix(GridView grdView)
        {
            if (grdView.Rows.Count == 0)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                ProjectNavigatorTDS.ProjectInsurancesBudgetDataTable dt = new ProjectNavigatorTDS.ProjectInsurancesBudgetDataTable();
                dt.AddProjectInsurancesBudgetRow(0, 0, 0, 0, false, companyId, false, "");
                Session["insurancesBudgetDummy"] = dt;

                grdView.DataBind();
            }

            // Normally executes at all postbacks
            if (grdView.Rows.Count == 1)
            {
                ProjectNavigatorTDS.ProjectInsurancesBudgetDataTable dt = (ProjectNavigatorTDS.ProjectInsurancesBudgetDataTable)Session["insurancesBudgetDummy"];
                if (dt != null)
                {
                    grdView.Rows[0].Visible = false;
                    grdView.Rows[0].Controls.Clear();
                }
            }
        }



        protected void AddOtherCostsBudgetNewEmptyFix(GridView grdView)
        {
            if (grdView.Rows.Count == 0)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                ProjectNavigatorTDS.ProjectOtherCostsBudgetDataTable dt = new ProjectNavigatorTDS.ProjectOtherCostsBudgetDataTable();
                dt.AddProjectOtherCostsBudgetRow(0, "", 0, 0, false, companyId, false);
                Session["otherCostsBudgetDummy"] = dt;

                grdView.DataBind();
            }

            // Normally executes at all postbacks
            if (grdView.Rows.Count == 1)
            {
                ProjectNavigatorTDS.ProjectOtherCostsBudgetDataTable dt = (ProjectNavigatorTDS.ProjectOtherCostsBudgetDataTable)Session["otherCostsBudgetDummy"];
                if (dt != null)
                {
                    grdView.Rows[0].Visible = false;
                    grdView.Rows[0].Controls.Clear();
                }
            }
        }
        


        protected void AddJobClassClassificationNewEmptyFix(GridView grdView)
        {
            if (grdView.Rows.Count == 0)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                ProjectNavigatorTDS.LFS_PROJECT_JOB_CLASS_TYPE_RATEDataTable dt = new ProjectNavigatorTDS.LFS_PROJECT_JOB_CLASS_TYPE_RATEDataTable();
                dt.AddLFS_PROJECT_JOB_CLASS_TYPE_RATERow(0, "", 0, 0, false, companyId, false, 0);
                Session["projectJobClassClassificationDummy"] = dt;

                grdView.DataBind();
            }

            // Normally executes at all postbacks
            if (grdView.Rows.Count == 1)
            {
                ProjectNavigatorTDS.LFS_PROJECT_JOB_CLASS_TYPE_RATEDataTable dt = (ProjectNavigatorTDS.LFS_PROJECT_JOB_CLASS_TYPE_RATEDataTable)Session["projectJobClassClassificationDummy"];
                if (dt != null)
                {
                    grdView.Rows[0].Visible = false;
                    grdView.Rows[0].Controls.Clear();
                }
            }
        }



        protected string GetSubcontractorId(object value)
        {
            int companyId = Int32.Parse(Session["companyID"].ToString());
            CompaniesGateway companiesGateway = new CompaniesGateway();
            companiesGateway.LoadAllByCompaniesId((int)value, companyId);

            return companiesGateway.GetName((int)value);
        }



        private string GetFullCategoryName(int libraryCategoryId)
        {
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int[] libraryArray = new int[100];
            int maxDeep = 0;

            for (int index = 0; index < libraryArray.Length; index++)
            {
                libraryArray[index] = -1;
            }

            string fullCategoryName = "";
            libraryArray = GetDeepParent(libraryCategoryId, 0, maxDeep, libraryArray);

            for (int index = 0; index < 100; index++)
            {
                if (libraryArray[index] > 0)
                {
                    if (index > 0)
                    {
                        fullCategoryName = fullCategoryName + "/";
                    }

                    LibraryCategoriesGateway libraryCategoriesGateway = new LibraryCategoriesGateway();
                    libraryCategoriesGateway.LoadAllByLibraryCategoriesId(libraryArray[index], companyId);
                    fullCategoryName = fullCategoryName + libraryCategoriesGateway.GetCategoryName(libraryArray[index]);
                }
            }

            return fullCategoryName;
        }



        private int[] GetDeepParent(int currentId, int deep, int maxDeep, int[] currentLibraryArray)
        {
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int[] libraryArray = currentLibraryArray;
            ViewState["currentmaxDeep"] = maxDeep;

            LibraryCategoriesGateway libraryCategoriesGateway = new LibraryCategoriesGateway();
            libraryCategoriesGateway.LoadAllByLibraryCategoriesId(currentId, companyId);

            if (libraryCategoriesGateway.Table.Rows.Count > 0)
            {
                if (libraryCategoriesGateway.GetParentId(currentId) == 0)
                {
                    libraryArray[0] = currentId;
                    ViewState["currentmaxDeep"] = deep;
                    return libraryArray;
                }
                else
                {
                    libraryArray = GetDeepParent(libraryCategoriesGateway.GetParentId(currentId), deep + 1, (int)ViewState["currentmaxDeep"], libraryArray);
                    libraryArray[(int)ViewState["currentmaxDeep"] - deep] = currentId;

                    return libraryArray;
                }
            }
            else
            {
                return libraryArray;
            }
        }

        

        private void RegisterClientScripts()
        {
            // Publishing body's OnKeyDown event 
            HtmlGenericControl bodyUnload = (HtmlGenericControl)Page.Master.FindControl("myBody");
            bodyUnload.Attributes.Add("OnKeyDown", "OnKeyDown(event);");

            // Register content variables
            string contentVariables = "";
            contentVariables += "var hdfProjectIdId = '" + hdfProjectId.ClientID + "';";
            contentVariables += "var hdfClientIdId = '" + hdfClientId.ClientID + "';";
            contentVariables += "var hdfClientPrimaryContactIdId = '" + hdfClientPrimaryContactID.ClientID + "';";
            contentVariables += "var hdfClientSecondaryContactIdId = '" + hdfClientSecondaryContactID.ClientID + "';";
            contentVariables += "var hdfActiveTabId = '" + hdfActiveTab.ClientID + "';";
            //contentVariables += "var hdfEngineerIdId = '" + hdfEngineerId.ClientID + "';";
            contentVariables += "var hdfDataChangedId = '" + hdfDataChanged.ClientID + "';";
            contentVariables += "var hdfDataChangedMessageId = '" + hdfDataChangedMessage.ClientID + "';";
            contentVariables += "var hdfBeforeUnloadOrigenId = '" + hdfBeforeUnloadOrigen.ClientID + "';";
            
            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode1", "./project_summary.js");
        }



        private void StoreNavigatorState()
        {
            ViewState["navigatorState"] = "&search_projectnumber=" + Request.QueryString["search_projectnumber"] + "&search_projectname=" + Request.QueryString["search_projectname"] + "&search_client=" + Request.QueryString["search_client"] + "&search_type=" + Request.QueryString["search_type"] + "&search_state=" + Request.QueryString["search_state"] + "&search_country=" + Request.QueryString["search_country"];
        }



        private string GetNavigatorState()
        {
            return (string)ViewState["navigatorState"];
        }



        protected string GetRound(object value, int decimals)
        {
            if (value != DBNull.Value)
            {
                if (decimals == 2)
                {
                    return string.Format("{0:0.00}", Convert.ToDecimal(value));
                }
                else
                {
                    return string.Format("{0:0.0}", Convert.ToDecimal(value));
                }
            }
            else
            {
                return "";
            }
        }



        #region Load Functions

        private void LoadData()
        {
            LoadGeneralData();
            LoadJobInfoData();
            LoadSaleBillingPricing();
            LoadCostingUpdates();
            LoadTermsPo();
            LoadTechnical();
            LoadEngineerSubcontractors();
            LoadNotes();
        }



        private void LoadGeneralData()
        {
            // Data for General Data
            tbxProjectNumber.DataBind();
            tbxName.DataBind();
            tbxProposalDate.DataBind();
            tbxStartDate.DataBind();
            tbxEndDate.DataBind();
            tbxDescription.DataBind();
            cbxFairWageApplies.DataBind();

            // ... for geographical location  
            hdfCountryId.DataBind();
            if (hdfCountryId.Value != "")
            {
                CountryGateway countryGateway = new CountryGateway();
                countryGateway.LoadByCountryId(Int64.Parse(hdfCountryId.Value));
                tbxCountry.Text = countryGateway.GetName(Int64.Parse(hdfCountryId.Value));
            }
            else
            {
                tbxCountry.Text = "";
            }

            hdfProvinceStateId.DataBind();
            if (hdfProvinceStateId.Value != "")
            {
                ProvinceGateway provinceGateway = new ProvinceGateway();
                provinceGateway.LoadByProvinceId(Int64.Parse(hdfProvinceStateId.Value));
                tbxProvinceState.Text = provinceGateway.GetName(Int64.Parse(hdfProvinceStateId.Value));
            }
            else
            {
                tbxProvinceState.Text = "";
            }

            hdfCountyId.DataBind();
            if (hdfCountyId.Value != "")
            {
                CountyGateway countyGateway = new CountyGateway();
                countyGateway.LoadByCountyId(Int64.Parse(hdfCountyId.Value));
                tbxCounty.Text = countyGateway.GetName(Int64.Parse(hdfCountyId.Value));
            }
            else
            {
                tbxCounty.Text = "";
            }

            hdfCityId.DataBind();
            if (hdfCityId.Value != "")
            {
                CityGateway cityGateway = new CityGateway();
                cityGateway.LoadByCityId(Int64.Parse(hdfCityId.Value));
                tbxCity.Text = cityGateway.GetName(Int64.Parse(hdfCityId.Value));
            }
            else
            {
                tbxCity.Text = "";
            }
                        
            // ... for project
            ProjectGateway projectGateway = new ProjectGateway(projectTDS);
            int currentCompanyId = projectGateway.GetClientID(Int32.Parse(hdfProjectId.Value.ToString()));

            // ... for client
            int companyId = Int32.Parse(hdfCompanyId.Value);
            CompaniesGateway companiesGateway = new CompaniesGateway();
            companiesGateway.LoadAllByCompaniesId(currentCompanyId, companyId);

            tbxClientName.Text = companiesGateway.GetName(currentCompanyId);
            hdfClientId.Value = projectGateway.GetClientID(int.Parse(hdfProjectId.Value)).ToString();
            tbxClientProjectNumber.DataBind();
            
            // ... ... for primary contact
            if (projectGateway.GetClientPrimaryContactID(int.Parse(hdfProjectId.Value)).HasValue)
            {
                hdfClientPrimaryContactID.Value = ((int)projectGateway.GetClientPrimaryContactID(int.Parse(hdfProjectId.Value))).ToString();
                ContactsGateway contactsGatewayForPrimaryContact = new ContactsGateway();
                contactsGatewayForPrimaryContact.LoadAllByContactId(int.Parse(hdfClientPrimaryContactID.Value), companyId); 
                tbxClientPrimaryContact.Text = contactsGatewayForPrimaryContact.GetCompleteName(int.Parse(hdfClientPrimaryContactID.Value));
            }

            // ... ... for secondary contact
            if (projectGateway.GetClientSecondaryContactID(int.Parse(hdfProjectId.Value)).HasValue)
            {
                hdfClientSecondaryContactID.Value = ((int)projectGateway.GetClientSecondaryContactID(int.Parse(hdfProjectId.Value))).ToString();
                ContactsGateway contactsGatewayForSecondaryContact = new ContactsGateway();
                contactsGatewayForSecondaryContact.LoadAllByContactId(int.Parse(hdfClientSecondaryContactID.Value), companyId); 
                tbxClientSecondaryContact.Text = contactsGatewayForSecondaryContact.GetCompleteName(int.Parse(hdfClientSecondaryContactID.Value));
            }

            // ... for resources
            // ... ... for project lead
            if (projectGateway.GetProjectLeadID(int.Parse(hdfProjectId.Value)).HasValue)
            {
                EmployeeGateway employeeGateway = new EmployeeGateway();
                employeeGateway.LoadByEmployeeId((int)projectGateway.GetProjectLeadID(int.Parse(hdfProjectId.Value)));
                tbxProjectLead.Text = employeeGateway.GetFullName((int)projectGateway.GetProjectLeadID(int.Parse(hdfProjectId.Value)));
            }

            // ... ... for salesman
            SalesmanGateway salesmanGateway = new SalesmanGateway();
            salesmanGateway.LoadExpandedBySalesmanId(projectGateway.GetSalesmanID(int.Parse(hdfProjectId.Value)));
            tbxSalesman.Text = salesmanGateway.GetFullName(projectGateway.GetSalesmanID(int.Parse(hdfProjectId.Value)));

            // ... ... for Pricing
            if (projectGateway.GetProjectType(int.Parse(hdfProjectId.Value)) == "Ballpark")
            {
                ProjectSaleBillingPricingGateway projectSaleBillingPricingGateway = new ProjectSaleBillingPricingGateway(projectTDS);
                
                if (projectSaleBillingPricingGateway.Table.Rows.Count > 0)
                {
                    if (projectSaleBillingPricingGateway.GetBillPrice(int.Parse(hdfProjectId.Value)).HasValue) tbxBillPrice.Text = ((decimal)projectSaleBillingPricingGateway.GetBillPrice(int.Parse(hdfProjectId.Value))).ToString("n2");
                    tbxBillMoney.Text = projectSaleBillingPricingGateway.GetBillMoney(int.Parse(hdfProjectId.Value));
                }
                else
                {
                    if (projectGateway.GetCountryID(int.Parse(hdfProjectId.Value)) == 1)
                    {
                        tbxBillMoney.Text = "CAD";
                    }
                    else
                    {
                        tbxBillMoney.Text = "USD";
                    }
                }
            }

            // Data for unit budget tab
            ProjectNavigatorProjectUnitsBudgetGateway projectNavigatorProjectUnitsBudgetGateway = new ProjectNavigatorProjectUnitsBudgetGateway(projectNavigatorTDS);

            if (projectNavigatorProjectUnitsBudgetGateway.Table.Rows.Count > 0)
            {
                tbxUnitsBudget.Text = projectNavigatorProjectUnitsBudgetGateway.GetBudget(int.Parse(hdfProjectId.Value)).ToString("n2");
            }

            // Data for materials budget tab
            ProjectNavigatorProjectMaterialsBudgetGateway projectNavigatorProjectMaterialsBudgetGateway = new ProjectNavigatorProjectMaterialsBudgetGateway(projectNavigatorTDS);

            if (projectNavigatorProjectMaterialsBudgetGateway.Table.Rows.Count > 0)
            {
                tbxMaterialsBudget.Text = projectNavigatorProjectMaterialsBudgetGateway.GetBudget(int.Parse(hdfProjectId.Value)).ToString("n2");
            }

            // Data for subcontractors budget tab
            ProjectNavigatorProjectSubcontractorsBudgetGateway projectNavigatorProjectSubcontractorsBudgetGateway = new ProjectNavigatorProjectSubcontractorsBudgetGateway(projectNavigatorTDS);

            if (projectNavigatorProjectSubcontractorsBudgetGateway.Table.Rows.Count > 0)
            {
                tbxSubcontractorsBudget.Text = projectNavigatorProjectSubcontractorsBudgetGateway.GetBudget(int.Parse(hdfProjectId.Value), 1, 1).ToString("n2");
            }

            // Data for hotels budget tab
            ProjectNavigatorProjectHotelsBudgetGateway projectNavigatorProjectHotelsBudgetGateway = new ProjectNavigatorProjectHotelsBudgetGateway(projectNavigatorTDS);

            if (projectNavigatorProjectHotelsBudgetGateway.Table.Rows.Count > 0)
            {
                tbxHotelsBudget.Text = projectNavigatorProjectHotelsBudgetGateway.GetBudget(int.Parse(hdfProjectId.Value), 1, 1).ToString("n2");
            }
            
            // Data for bondings budget tab
            ProjectNavigatorProjectBondingsBudgetGateway projectNavigatorProjectBondingsBudgetGateway = new ProjectNavigatorProjectBondingsBudgetGateway(projectNavigatorTDS);

            if (projectNavigatorProjectBondingsBudgetGateway.Table.Rows.Count > 0)
            {
                tbxBondingsBudget.Text = projectNavigatorProjectBondingsBudgetGateway.GetBudget(int.Parse(hdfProjectId.Value), 1, 1).ToString("n2");
            }

            // Data for insurances budget tab
            ProjectNavigatorProjectInsurancesBudgetGateway projectNavigatorProjectInsurancesBudgetGateway = new ProjectNavigatorProjectInsurancesBudgetGateway(projectNavigatorTDS);

            if (projectNavigatorProjectInsurancesBudgetGateway.Table.Rows.Count > 0)
            {
                tbxInsurancesBudget.Text = projectNavigatorProjectInsurancesBudgetGateway.GetBudget(int.Parse(hdfProjectId.Value), 1, 1).ToString("n2");
            }

            CalculateTotalBudget();
        }



        private void LoadJobInfoData()
        {
            ProjectNavigatorProjectJobInfoGateway projectNavigatorProjectJobInfoGateway = new ProjectNavigatorProjectJobInfoGateway(projectNavigatorTDS);

            if (projectNavigatorProjectJobInfoGateway.Table.Rows.Count > 0)
            {
                int projectId = int.Parse(hdfProjectId.Value);
                ckbxMhRehab.Checked = projectNavigatorProjectJobInfoGateway.GetTypeOfWorkMhRehab(projectId);
                ckbxJunctionLining.Checked = projectNavigatorProjectJobInfoGateway.GetTypeOfWorkJuntionLining(projectId);
                ckbxProjectManagement.Checked = projectNavigatorProjectJobInfoGateway.GetTypeOfWorkProjectManagement(projectId);
                ckbxFullLengthLining.Checked = projectNavigatorProjectJobInfoGateway.GetTypeOfWorkFullLenghtLining(projectId);
                ckbxPointRepairs.Checked = projectNavigatorProjectJobInfoGateway.GetTypeOfWorkPointRepairs(projectId);
                ckbxRehabAssessment.Checked = projectNavigatorProjectJobInfoGateway.GetTypeOfWorkRehabAssessment(projectId);
                ckbxGrout.Checked = projectNavigatorProjectJobInfoGateway.GetTypeOfWorkGrout(projectId);
                ckbxOther.Checked = projectNavigatorProjectJobInfoGateway.GetTypeOfWorkOther(projectId);
                cbxSubcontractorAgreement.Checked = projectNavigatorProjectJobInfoGateway.GetAgreement(projectId);
                cbxSubcontractorWrittenQuote.Checked = projectNavigatorProjectJobInfoGateway.GetWrittenQuote(projectId);
                tbxSubcontractorRole.Text = projectNavigatorProjectJobInfoGateway.GetRole(projectId);
            }
        }



        private void LoadSaleBillingPricing()
        {
            // Data for Sale/Billing/Pricing tab
            ProjectSaleBillingPricingGateway projectSaleBillingPricingGateway = new ProjectSaleBillingPricingGateway(projectTDS);

            if (projectSaleBillingPricingGateway.Table.Rows.Count > 0)
            {
                //cbxSaleBidProject.Checked = projectSaleBillingPricingGateway.GetSaleBidProject(int.Parse(hdfProjectId.Value));
                //cbxSaleRFP.Checked = projectSaleBillingPricingGateway.GetSaleRFP(int.Parse(hdfProjectId.Value));
                //cbxSaleSoleSource.Checked = projectSaleBillingPricingGateway.GetSaleSoleSource(int.Parse(hdfProjectId.Value));
                //cbxSaleTermContract.Checked = projectSaleBillingPricingGateway.GetSaleTermContract(int.Parse(hdfProjectId.Value));
                //tbxSaleTermContractDetail.Text = projectSaleBillingPricingGateway.GetSaleTermContractDetail(int.Parse(hdfProjectId.Value));
                //cbxSaleOther.Checked = projectSaleBillingPricingGateway.GetSaleOther(int.Parse(hdfProjectId.Value));
                //tbxSaleOtherDetail.Text = projectSaleBillingPricingGateway.GetSaleOtherDetail(int.Parse(hdfProjectId.Value));
                //if (projectSaleBillingPricingGateway.GetSaleGettingJob(int.Parse(hdfProjectId.Value)).HasValue) tbxSaleGettingJob.Text = ((int)projectSaleBillingPricingGateway.GetSaleGettingJob(int.Parse(hdfProjectId.Value))).ToString();
                if (projectSaleBillingPricingGateway.GetBillPrice(int.Parse(hdfProjectId.Value)).HasValue) tbxBillPriceSaleBillingPricing.Text = ((decimal)projectSaleBillingPricingGateway.GetBillPrice(int.Parse(hdfProjectId.Value))).ToString("n2");
                tbxBillMoneySaleBillingPricing.Text = projectSaleBillingPricingGateway.GetBillMoney(int.Parse(hdfProjectId.Value));
                if (projectSaleBillingPricingGateway.GetBillSubcontractorAmount(int.Parse(hdfProjectId.Value)).HasValue) tbxBillSubcontractorAmount.Text = ((decimal)projectSaleBillingPricingGateway.GetBillSubcontractorAmount(int.Parse(hdfProjectId.Value))).ToString("n2");
                //tbxBillBidHardDollar.Text = projectSaleBillingPricingGateway.GetBillBidHardDollar(int.Parse(hdfProjectId.Value));
                //cbxBillPerUnit.Checked = projectSaleBillingPricingGateway.GetBillPerUnit(int.Parse(hdfProjectId.Value));
                //cbxBillHourly.Checked = projectSaleBillingPricingGateway.GetBillHourly(int.Parse(hdfProjectId.Value));
                //tbxBillExpectExtras.Text = projectSaleBillingPricingGateway.GetBillExpectExtras(int.Parse(hdfProjectId.Value));
                //cbxChargesWater.Checked = projectSaleBillingPricingGateway.GetChargesWater(int.Parse(hdfProjectId.Value));
                //if (projectSaleBillingPricingGateway.GetChargesWaterAmount(int.Parse(hdfProjectId.Value)).HasValue) tbxChargesWaterAmount.Text = ((decimal)projectSaleBillingPricingGateway.GetChargesWaterAmount(int.Parse(hdfProjectId.Value))).ToString("n2");
                //cbxChargesDisposal.Checked = projectSaleBillingPricingGateway.GetChargesDisposal(int.Parse(hdfProjectId.Value));
                //if (projectSaleBillingPricingGateway.GetChargesDisposalAmount(int.Parse(hdfProjectId.Value)).HasValue) tbxChargesDisposalAmount.Text = ((decimal)projectSaleBillingPricingGateway.GetChargesDisposalAmount(int.Parse(hdfProjectId.Value))).ToString("n2");
            }
            else
            {
                // ... for project
                ProjectGateway projectGateway = new ProjectGateway(projectTDS);

                if (projectGateway.GetCountryID(int.Parse(hdfProjectId.Value)) == 1)
                {
                    tbxBillMoneySaleBillingPricing.Text = "CAD";
                }
                else
                {
                    tbxBillMoneySaleBillingPricing.Text = "USD";
                }
            }

            // Databind Grid for Services
            //grdServices.DataBind();
        }



        private void LoadCostingUpdates()
        {
            // Data for Costing Updates tab
            ProjectCostingUpdatesGateway projectCostingUpdatesGateway = new ProjectCostingUpdatesGateway(projectTDS);
            
            if (projectCostingUpdatesGateway.Table.Rows.Count > 0)
            {
                int projectId = int.Parse(hdfProjectId.Value);
                decimal costsIncurredToDate = 0M;
                decimal invoicedToDate = 0M;
                decimal actualGrossMarginToDate = 0M;

                //if (projectCostingUpdatesGateway.GetExtrasToDate(int.Parse(hdfProjectId.Value)).HasValue) tbxExtrasToDate.Text = ((decimal)projectCostingUpdatesGateway.GetExtrasToDate(int.Parse(hdfProjectId.Value))).ToString("n2");
                //if (projectCostingUpdatesGateway.GetCostToComplete(int.Parse(hdfProjectId.Value)).HasValue) tbxCostToComplete.Text = ((decimal)projectCostingUpdatesGateway.GetCostToComplete(int.Parse(hdfProjectId.Value))).ToString("n2");
                //if (projectCostingUpdatesGateway.GetOriginalProfitEstimated(int.Parse(hdfProjectId.Value)).HasValue) tbxOriginalProfitEstimated.Text = ((decimal)projectCostingUpdatesGateway.GetOriginalProfitEstimated(int.Parse(hdfProjectId.Value))).ToString("n2");

                if (projectCostingUpdatesGateway.GetCostsIncurred(projectId).HasValue)
                {
                    costsIncurredToDate = (decimal)projectCostingUpdatesGateway.GetCostsIncurred(projectId);
                    tbxCostsIncurredToDate.Text = costsIncurredToDate.ToString("n2");
                }
                else
                {
                    tbxCostsIncurredToDate.Text = "0";
                }

                if (projectCostingUpdatesGateway.GetInvoicedToDate(projectId).HasValue)
                {
                    invoicedToDate = (decimal)projectCostingUpdatesGateway.GetInvoicedToDate(projectId);
                    tbxInvoicedToDate.Text = invoicedToDate.ToString("n2");
                }
                else
                {
                    tbxInvoicedToDate.Text = "0";
                }

                if (invoicedToDate != 0)
                {
                    actualGrossMarginToDate = ((invoicedToDate - costsIncurredToDate) / invoicedToDate) * 100;
                }

                tbxActualGrossMarginToDate.Text = actualGrossMarginToDate.ToString("n2");
            }
        }



        private void LoadTermsPo()
        {
            // Data for Terms/PO
            ProjectTermsPOGateway projectTermsPOGateway = new ProjectTermsPOGateway(projectTDS);
            
            if (projectTermsPOGateway.Table.Rows.Count > 0)
            {
                // ... Liquidated Damage
                //cbxLiquidatedDamages.Checked = projectTermsPOGateway.GetLiquidatedDamage(int.Parse(hdfProjectId.Value));
                //if (projectTermsPOGateway.GetLiquidatedRate(int.Parse(hdfProjectId.Value)).HasValue) tbxLiquidatedDamagesRate.Text = (Decimal.Round((decimal)projectTermsPOGateway.GetLiquidatedRate(int.Parse(hdfProjectId.Value)), 2)).ToString(); else tbxLiquidatedDamagesRate.Text = "";
                //tbxLiquidatedDamagesUnit.Text = projectTermsPOGateway.GetLiquidatedUnit(int.Parse(hdfProjectId.Value));

                // ... Client LFS Relationship
                //cbxWorkedBefore.Checked = projectTermsPOGateway.GetRelationshipClientWorkedBefore(int.Parse(hdfProjectId.Value));
                //tbxClientQuirks.Text = projectTermsPOGateway.GetRelationshipClientQuirks(int.Parse(hdfProjectId.Value));
                //cbxClientPromises.Checked = projectTermsPOGateway.GetRelationshipClientPromises(int.Parse(hdfProjectId.Value));
                //tbxClientPromises.Text = projectTermsPOGateway.GetRelationshipClientPromisesNotes(int.Parse(hdfProjectId.Value));
                //tbxWaterObtain.Text = projectTermsPOGateway.GetRelationshipWaterObtain(int.Parse(hdfProjectId.Value));
                //tbxMaterialDispose.Text = projectTermsPOGateway.GetRelationshipMaterialDispose(int.Parse(hdfProjectId.Value));
                //cbxRequireRPZ.Checked = projectTermsPOGateway.GetRelationshipRequireRPZ(int.Parse(hdfProjectId.Value));
                //tbxStandardHydrantFitting.Text = projectTermsPOGateway.GetRelationshipStandardHydrantFitting(int.Parse(hdfProjectId.Value));
                //cbxPreConstructionMeetingNeed.Checked = projectTermsPOGateway.GetRelationshipPreConstructionMeeting(int.Parse(hdfProjectId.Value));
                //cbxSpecificMeetingLocation.Checked = projectTermsPOGateway.GetRelationshipSpecificMeetingLocation(int.Parse(hdfProjectId.Value));
                //tbxSpecificMeetingLocation.Text = projectTermsPOGateway.GetRelationshipSpecificMeetingLocationNotes(int.Parse(hdfProjectId.Value));
                //tbxVehicleAccess.Text = projectTermsPOGateway.GetRelationshipVehicleAccess(int.Parse(hdfProjectId.Value));
                //tbxVehicleAccessNotes.Text = projectTermsPOGateway.GetRelationshipVehicleAccessNotes(int.Parse(hdfProjectId.Value));
                tbxDesireOutcomeOfProject.Text = projectTermsPOGateway.GetRelationshipProjectOutcome(int.Parse(hdfProjectId.Value));
                tbxSpecificReportingNeeds.Text = projectTermsPOGateway.GetRelationshipSpecificReportingNeeds(int.Parse(hdfProjectId.Value));

                //... Purchase Order
                //cbxPurchaseOrderAttach.Checked = projectTermsPOGateway.GetPurchaseOrderAttached(int.Parse(hdfProjectId.Value));
                tbxPurchaseOrderNumber.Text = projectTermsPOGateway.GetPurchaseOrderNumber(int.Parse(hdfProjectId.Value));
                //tbxPurchaseOrderWillNotProvided.Text = projectTermsPOGateway.GetPurchaseOrderNotes(int.Parse(hdfProjectId.Value));

                // ... Vehicle Access
                ckbxVehicleAccessRoad.Checked = projectTermsPOGateway.GetVehicleAccessRoad(int.Parse(hdfProjectId.Value));
                ckbxVehicleAccessEasement.Checked = projectTermsPOGateway.GetVehicleAccessEasement(int.Parse(hdfProjectId.Value));
                ckbxVehicleAccessOther.Checked = projectTermsPOGateway.GetVehicleAccessOther(int.Parse(hdfProjectId.Value));
            }
        }



        private void LoadTechnical()
        {
            // Data for Technical tab
            ProjectTechnicalGateway projectTechnicalGateway = new ProjectTechnicalGateway(projectTDS);
            
            if (projectTechnicalGateway.Table.Rows.Count > 0)
            {
                cbxAvailableDrawings.Checked = projectTechnicalGateway.GetDrawings(int.Parse(hdfProjectId.Value));
                cbxAvailableVideo.Checked = projectTechnicalGateway.GetVideo(int.Parse(hdfProjectId.Value));

                //cbxGroundConditions.Checked = projectTechnicalGateway.GetGroundConditions(int.Parse(hdfProjectId.Value));
                //tbxGroundCondition.Text = projectTechnicalGateway.GetGrounConditionsNotes(int.Parse(hdfProjectId.Value));
                //cbxReviewVideoInspections.Checked = projectTechnicalGateway.GetReviewVideo(int.Parse(hdfProjectId.Value));
                //cbxStrangeConfigurations.Checked = projectTechnicalGateway.GetStrangeConfigurations(int.Parse(hdfProjectId.Value));
                //tbxStrangeConfigurations.Text = projectTechnicalGateway.GetStrangeConfigurationsNotes(int.Parse(hdfProjectId.Value));
                //tbxFurtherObservations.Text = projectTechnicalGateway.GetFurtherObservations(int.Parse(hdfProjectId.Value));
                //tbxRestrictiveFactors.Text = projectTechnicalGateway.GetRestrictiveFactors(int.Parse(hdfProjectId.Value));
            }
        }



        private void CalculateTotalBudget()
        {
            decimal totalBudget = 0;

            foreach (ProjectNavigatorTDS.ProjectWorkFunctionBudgetRow row in (ProjectNavigatorTDS.ProjectWorkFunctionBudgetDataTable)Session["projectBudget"])
            {
                if (!row.Deleted)
                {
                    totalBudget = totalBudget + row.Budget_;
                }
            }

            foreach (ProjectNavigatorTDS.ProjectOtherCostsBudgetRow row in (ProjectNavigatorTDS.ProjectOtherCostsBudgetDataTable)Session["otherCostsBudget"])
            {
                if (!row.Deleted)
                {
                    totalBudget = totalBudget + row.Budget;
                }
            }

            decimal unitsBudget = 0; if (tbxUnitsBudget.Text != "") unitsBudget = decimal.Parse(tbxUnitsBudget.Text);
            decimal materialsBudget = 0; if (tbxMaterialsBudget.Text != "") materialsBudget = decimal.Parse(tbxMaterialsBudget.Text);
            decimal subcontractorsBudget = 0; if (tbxSubcontractorsBudget.Text != "") subcontractorsBudget = decimal.Parse(tbxSubcontractorsBudget.Text);
            decimal hotelsBudget = 0; if (tbxHotelsBudget.Text != "") hotelsBudget = decimal.Parse(tbxHotelsBudget.Text);
            decimal bondingsBudget = 0; if (tbxBondingsBudget.Text != "") bondingsBudget = decimal.Parse(tbxBondingsBudget.Text);
            decimal insurancesBudget = 0; if (tbxInsurancesBudget.Text != "") insurancesBudget = decimal.Parse(tbxInsurancesBudget.Text);

            totalBudget = totalBudget + unitsBudget + materialsBudget + subcontractorsBudget + hotelsBudget + bondingsBudget + insurancesBudget;

            tbxTotalBudgetForProject.Text = Decimal.Round(totalBudget, 2).ToString();

            tbxTotalProjectedRevenue.Text = "0";

            tbxTotalProjectedProfit.Text = Decimal.Round((0 - totalBudget), 2).ToString();

            tbxProjectedGrossMargin.Text = "0.00";
        }



        private void GrdNotesOpenAttachment(string originalFileName, string fileName)
        {
            // Button download functionality
            if ((originalFileName != "") && (fileName != ""))
            {
                AppSettingsReader appSettingReader = new AppSettingsReader();
                string websitePath = appSettingReader.GetValue("WebsitePath", typeof(System.String)).ToString();

                string fullPath = string.Format("{0}\\Files\\LF_DGHOUGDH\\Library\\{1}", websitePath, fileName);
                FileInfo file = new FileInfo(fullPath);

                // Checking if file exists
                if (file.Exists)
                {
                    Response.Clear();
                    Response.AddHeader("Pragma", "public");
                    Response.AddHeader("Expires", "0");
                    Response.AddHeader("Cache-Control", "mustrevalidate, post-check=0, pre-check=0");
                    Response.AddHeader("Content-Type", "application/force-download");
                    Response.AddHeader("Content-Type", "application/octet-stream");
                    Response.AddHeader("Content-Type", "application/download");
                    Response.AddHeader("Content-Disposition", string.Format("attachment; filename=\"{0}\"", originalFileName));
                    Response.AddHeader("Content-Transfer-Encoding", "binary");
                    Response.AddHeader("Content-Length", file.Length.ToString());
                    Response.WriteFile(file.FullName);
                    Response.Flush();
                    Response.End();
                }
            }
        }
       
               
                
        private void LoadEngineerSubcontractors()
        {
            // Data for Engineer/Subcontractors tab
            ProjectEngineerSubcontractorsGateway projectEngineerSubcontractorsGateway = new ProjectEngineerSubcontractorsGateway(projectTDS);

            if (projectEngineerSubcontractorsGateway.Table.Rows.Count > 0)
            {
                cbxGeneralContractor.Checked = projectEngineerSubcontractorsGateway.GetGeneralContractor(int.Parse(hdfProjectId.Value));
                cbxGeneralWSIB.Checked = projectEngineerSubcontractorsGateway.GetGeneralWSIB(int.Parse(hdfProjectId.Value));
                cbxGeneralInsuranceCertificate.Checked = projectEngineerSubcontractorsGateway.GetGeneralInsuranceCertificate(int.Parse(hdfProjectId.Value));
                tbxGeneralBondingSupplied.Text = projectEngineerSubcontractorsGateway.GetGeneralBondingSupplied(int.Parse(hdfProjectId.Value));
                tbxBondNumber.Text = projectEngineerSubcontractorsGateway.GetBondNumber(int.Parse(hdfProjectId.Value));
                //tbxGeneralMOLForm.Text = projectEngineerSubcontractorsGateway.GetGeneralMOLForm(int.Parse(hdfProjectId.Value));
                //rbtnGeneralNoticeProject.Checked = projectEngineerSubcontractorsGateway.GetGeneralNoticeProject(int.Parse(hdfProjectId.Value));
                //rbtnGeneralForm1000.Checked = projectEngineerSubcontractorsGateway.GetGeneralForm1000(int.Parse(hdfProjectId.Value));
                //int companyId = Int32.Parse(hdfCompanyId.Value);    

                //if (projectEngineerSubcontractorsGateway.GetEngineeringFirmId(int.Parse(hdfProjectId.Value)).HasValue)
                //{                                    
                //    CompaniesGateway companiesGateway = new CompaniesGateway();
                //    companiesGateway.LoadAllByCompaniesId((int)projectEngineerSubcontractorsGateway.GetEngineeringFirmId(int.Parse(hdfProjectId.Value)), companyId);
                //    tbxEngineeringFirmId.Text = companiesGateway.GetName((int)projectEngineerSubcontractorsGateway.GetEngineeringFirmId(int.Parse(hdfProjectId.Value)));
                //}

                //if (projectEngineerSubcontractorsGateway.GetEngineerId(int.Parse(hdfProjectId.Value)).HasValue)
                //{
                //    hdfEngineerId.Value = ((int)projectEngineerSubcontractorsGateway.GetEngineerId(int.Parse(hdfProjectId.Value))).ToString();
                //    ContactsGateway contactsGateway = new ContactsGateway();
                //    contactsGateway.LoadAllByContactId((int)projectEngineerSubcontractorsGateway.GetEngineerId(int.Parse(hdfProjectId.Value)), companyId); 
                //    tbxEngineerId.Text = contactsGateway.GetCompleteName((int)projectEngineerSubcontractorsGateway.GetEngineerId(int.Parse(hdfProjectId.Value)));
                //}

                //tbxEngineerNumber.Text = projectEngineerSubcontractorsGateway.GetEngineerNumber(int.Parse(hdfProjectId.Value));
                cbxSubcontractorUsed.Checked = projectEngineerSubcontractorsGateway.GetSubcontractorUsed(int.Parse(hdfProjectId.Value));
            }
            else
            {
                //tbxGeneralBondingSupplied.Text = "NA";
                //tbxGeneralMOLForm.Text = "NA";
            }

            // ... Databind Grid for subcontractors
            //grdvSubcontractors.DataSource = projectTDS.LFS_PROJECT_SUBCONTRACTOR;
            //grdvSubcontractors.DataBind();
        }



        private void LoadNotes()
        {
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int projectId = Int32.Parse(hdfProjectId.Value);

            // Data for Notes
            ProjectNotes  projectNotes = new ProjectNotes(projectTDS);
            projectNotes.LoadAllByProjectId(projectId);

            tbxNotes.Text = projectNotes.GetAllProjectNotes(projectId, companyId, projectNotes.Table.Rows.Count, "\n");


        //    // ... for Library
        //    ProjectGateway projectGateway = new ProjectGateway(projectTDS);

        //    int? libraryCategoriesId = null; if (projectGateway.GetLibraryCategoriesId(int.Parse(hdfProjectId.Value)).HasValue) libraryCategoriesId = (int)projectGateway.GetLibraryCategoriesId(int.Parse(hdfProjectId.Value));
            
        //    if (libraryCategoriesId.HasValue)
        //    {
        //        ViewState["libraryCategoriesId"] = (int)libraryCategoriesId;
        //        tbxCategoryAssocited.Text = GetFullCategoryName((int)libraryCategoriesId);
        //    }
        //    else
        //    {
        //        tbxCategoryAssocited.Text = "";
        //    }

        //    // Update Notes for process
        //    ProjectNotes projectNotes = new ProjectNotes(projectTDS);
        //    projectNotes.UpdateForProcess();
        }


        #endregion



    }
}