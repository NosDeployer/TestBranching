using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.BL.Projects.Projects;
using LiquiForce.LFSLive.BL.Resources.Companies;
using LiquiForce.LFSLive.BL.Resources.Employees;
using LiquiForce.LFSLive.DA.Company.Organization;
using LiquiForce.LFSLive.DA.LabourHours.TeamProjectTime;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.DA.Resources.Companies;
using LiquiForce.LFSLive.DA.Resources.Employees;
using LiquiForce.LFSLive.DA.Services.Services;
using LiquiForce.LFSLive.Tools;
using Telerik.Web.UI;
using LiquiForce.LFSLive.DA.RAF;
using LiquiForce.LFSLive.BL.RAF;

namespace LiquiForce.LFSLive.WebUI.Projects.Projects
{
    /// <summary>
    /// project_edit
    /// </summary>
    public partial class project_edit : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected ProjectTDS projectTDS;
        protected LibraryTDS libraryTDS;
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
                if (!(Convert.ToBoolean(Session["sgLFS_PROJECTS_VIEW"]) && Convert.ToBoolean(Session["sgLFS_PROJECTS_EDIT"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["project_id"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in project_edit.aspx");
                }

                // Tag page
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfProjectId.Value = Request.QueryString["project_id"];
                hdfLoginId.Value = Convert.ToInt32(Session["loginID"]).ToString();
                hdfDataChanged.Value = Request.QueryString["data_changed"];
                hdfDataChangedMessage.Value = "Changes made to this project will not be saved.";

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

                Session["fairWage"] = "None";

                // ... Set initial tab
                if ((string)Session["dialogOpenedProjects"] != "1")
                {
                    hdfActiveTab.Value = Request.QueryString["active_tab"];
                }
                else
                {
                    hdfActiveTab.Value = (string)Session["activeTabProjects"];
                }
                
                // ... For Library
                if (Session["lfsLibraryTDS"] != null)
                {
                    libraryTDS = (LibraryTDS)Session["lfsLibraryTDS"];
                }
                else
                {
                    libraryTDS = new LibraryTDS();
                }   
             
                // If coming from 
                // ... projects2.aspx or project_add.aspx
                if (Request.QueryString["source_page"] == "projects2.aspx" || Request.QueryString["source_page"] == "project_add.aspx")
                {
                    // Store Navigator State, Update control and Origin
                    StoreNavigatorState();
                    ViewState["update"] = "no";
                    ViewState["origin"] = "navigator";

                    // Get Project Id
                    int projectId = int.Parse(hdfProjectId.Value);                    

                    // ... Attachment control
                    if (Session["fromAttachment"] != null)
                    {
                        if (Session["fromAttachment"].ToString() == "yes")
                        {
                            // Restore dataset
                            projectTDS = (ProjectTDS)Session["lfsProjectTDS"];
                            projectNavigatorTDS = (ProjectNavigatorTDS)Session["projectNavigatorTDS"];
                            projectNotes = (ProjectNavigatorTDS.ProjectNotesDataTable)Session["projectNotes"];
                            projectServices = (ProjectNavigatorTDS.ProjectServiceDataTable)Session["projectServices"];
                            projectJobClassClassification = (ProjectNavigatorTDS.LFS_PROJECT_JOB_CLASS_TYPE_RATEDataTable)Session["projectJobClassClassification"];
                            projectTypeOfWorkFunctionClassification = (ProjectNavigatorTDS.LFS_PROJECT_WORK_FUNCTION_FAIR_WAGEDataTable)Session["projectTypeOfWorkFunctionClassification"];
                            projectBudget = (ProjectNavigatorTDS.ProjectWorkFunctionBudgetDataTable)Session["projectBudget"];
                            unitsBudget = (ProjectNavigatorTDS.ProjectUnitsBudgetDataTable)Session["unitsBudget"];
                            materialsBudget = (ProjectNavigatorTDS.ProjectMaterialsBudgetDataTable)Session["materialsBudget"];
                            subcontractorsBudget = (ProjectNavigatorTDS.ProjectSubcontractorsBudgetDataTable)Session["subcontractorsBudget"];
                            hotelsBudget = (ProjectNavigatorTDS.ProjectHotelsBudgetDataTable)Session["hotelsBudget"];
                            bondingsBudget = (ProjectNavigatorTDS.ProjectBondingsBudgetDataTable)Session["bondingsBudget"];
                            insurancesBudget = (ProjectNavigatorTDS.ProjectInsurancesBudgetDataTable)Session["insurancesBudget"];
                            otherCostsBudget = (ProjectNavigatorTDS.ProjectOtherCostsBudgetDataTable)Session["otherCostsBudget"];
                        }

                        Session.Remove("fromAttachment");
                    }
                    else
                    {
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

                        // Get job info
                        ProjectJobInfoGateway projectJobInfoGateway = new ProjectJobInfoGateway(projectNavigatorTDS);
                        projectJobInfoGateway.LoadAllByProjectId(projectId);

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
                        ProjectNavigatorProjectNotes projectNavigatorProjectNotes = new ProjectNavigatorProjectNotes(projectNavigatorTDS);
                        projectNavigatorProjectNotes.LoadAllByProjectId(projectId);                       

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
                    }

                    //grdNotes.DataBind();
                    //grdServices.DataBind();
                    grdTypeOfWorkFunctionClassification.DataBind();
                    grdJobClassClassification.DataBind();
                    grdBudget.DataBind();
                    /*grdSubcontractorsBudget.DataBind();
                    grdHotelsBudget.DataBind();
                    grdBondingsBudget.DataBind();
                    grdInsurancesBudget.DataBind();*/
                    grdOtherCostsBudget.DataBind();
                }

                // ... project_summary.aspx or project_edit.aspx
                if ((Request.QueryString["source_page"] == "project_summary.aspx") || (Request.QueryString["source_page"] == "project_edit.aspx") || (Request.QueryString["source_page"] == "lm"))
                {
                    // Store Navigator State, update control and origin
                    StoreNavigatorState();
                    ViewState["update"] = Request.QueryString["update"];
                    ViewState["origin"] = Request.QueryString["origin"]; //summary

                    // Restore dataset
                    projectTDS = (ProjectTDS)Session["lfsProjectTDS"];
                    projectNavigatorTDS = (ProjectNavigatorTDS)Session["projectNavigatorTDS"];
                    projectNotes = (ProjectNavigatorTDS.ProjectNotesDataTable)Session["projectNotes"];
                    projectServices = (ProjectNavigatorTDS.ProjectServiceDataTable)Session["projectServices"];
                    projectJobClassClassification = (ProjectNavigatorTDS.LFS_PROJECT_JOB_CLASS_TYPE_RATEDataTable)Session["projectJobClassClassification"];
                    projectTypeOfWorkFunctionClassification = (ProjectNavigatorTDS.LFS_PROJECT_WORK_FUNCTION_FAIR_WAGEDataTable)Session["projectTypeOfWorkFunctionClassification"];
                    projectBudget = (ProjectNavigatorTDS.ProjectWorkFunctionBudgetDataTable)Session["projectBudget"];
                    unitsBudget = (ProjectNavigatorTDS.ProjectUnitsBudgetDataTable)Session["unitsBudget"];
                    materialsBudget = (ProjectNavigatorTDS.ProjectMaterialsBudgetDataTable)Session["materialsBudget"];
                    subcontractorsBudget = (ProjectNavigatorTDS.ProjectSubcontractorsBudgetDataTable)Session["subcontractorsBudget"];
                    hotelsBudget = (ProjectNavigatorTDS.ProjectHotelsBudgetDataTable)Session["hotelsBudget"];
                    bondingsBudget = (ProjectNavigatorTDS.ProjectBondingsBudgetDataTable)Session["bondingsBudget"];
                    insurancesBudget = (ProjectNavigatorTDS.ProjectInsurancesBudgetDataTable)Session["insurancesBudget"];
                    otherCostsBudget = (ProjectNavigatorTDS.ProjectOtherCostsBudgetDataTable)Session["otherCostsBudget"];

                    // Get Project Id
                    int projectId = int.Parse(hdfProjectId.Value);    

                    if (ViewState["update"].ToString().Trim() == "yes")
                    {
                        // Get General Data
                        ProjectGateway projectGatewayForLoad = new ProjectGateway(projectTDS);
                        projectGatewayForLoad.LoadByProjectId(projectId);

                        // Get job info
                        ProjectJobInfoGateway projectJobInfoGateway = new ProjectJobInfoGateway(projectNavigatorTDS);
                        projectJobInfoGateway.LoadAllByProjectId(projectId);

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
                        ProjectNavigatorProjectNotes projectNavigatorProjectNotes = new ProjectNavigatorProjectNotes(projectNavigatorTDS);
                        projectNavigatorProjectNotes.LoadAllByProjectId(projectId);

                        //grdNotes.DataBind();
                        //grdServices.DataBind();
                        grdTypeOfWorkFunctionClassification.DataBind();
                        grdJobClassClassification.DataBind();
                        grdBudget.DataBind();
                        /*grdSubcontractorsBudget.DataBind();
                        grdHotelsBudget.DataBind();
                        grdBondingsBudget.DataBind();
                        grdInsurancesBudget.DataBind();*/
                        grdOtherCostsBudget.DataBind();

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
                    }
                }

                // Data for current project
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

                //// ... For total cost at services
                //ProjectNavigatorProjectService projectNavigatorProjectServiceForCost = new ProjectNavigatorProjectService(projectNavigatorTDS);
                //tbxTotalCost.Text = Decimal.Round(projectNavigatorProjectServiceForCost.GetTotalCost(), 2).ToString();
            }
            else
            {
                // Restore dataset 
                projectTDS = (ProjectTDS)Session["lfsProjectTDS"];
                projectNavigatorTDS = (ProjectNavigatorTDS)Session["projectNavigatorTDS"];
                projectNotes = (ProjectNavigatorTDS.ProjectNotesDataTable)Session["projectNotes"];
                projectServices = (ProjectNavigatorTDS.ProjectServiceDataTable)Session["projectServices"];
                projectJobClassClassification = (ProjectNavigatorTDS.LFS_PROJECT_JOB_CLASS_TYPE_RATEDataTable)Session["projectJobClassClassification"];
                projectTypeOfWorkFunctionClassification = (ProjectNavigatorTDS.LFS_PROJECT_WORK_FUNCTION_FAIR_WAGEDataTable)Session["projectTypeOfWorkFunctionClassification"];
                projectBudget = (ProjectNavigatorTDS.ProjectWorkFunctionBudgetDataTable)Session["projectBudget"];
                unitsBudget = (ProjectNavigatorTDS.ProjectUnitsBudgetDataTable)Session["unitsBudget"];
                materialsBudget = (ProjectNavigatorTDS.ProjectMaterialsBudgetDataTable)Session["materialsBudget"];
                subcontractorsBudget = (ProjectNavigatorTDS.ProjectSubcontractorsBudgetDataTable)Session["subcontractorsBudget"];
                hotelsBudget = (ProjectNavigatorTDS.ProjectHotelsBudgetDataTable)Session["hotelsBudget"];
                bondingsBudget = (ProjectNavigatorTDS.ProjectBondingsBudgetDataTable)Session["bondingsBudget"];
                insurancesBudget = (ProjectNavigatorTDS.ProjectInsurancesBudgetDataTable)Session["insurancesBudget"];
                otherCostsBudget = (ProjectNavigatorTDS.ProjectOtherCostsBudgetDataTable)Session["otherCostsBudget"];

                tbxProjectNumber.DataBind();

                if (Session["lfsLibraryTDS"] != null)
                {
                    libraryTDS = (LibraryTDS)Session["lfsLibraryTDS"];
                }
                else
                {
                    libraryTDS = new LibraryTDS();
                }
            }
        }



        protected void grdNotes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //// Notes Gridview, if the gridview is edition mode
            //if (grdNotes.EditIndex >= 0)
            //{
            //    grdNotes.UpdateRow(grdNotes.EditIndex, true);
            //}

            //// Delete notes
            //int projectId = (int)e.Keys["ProjectID"];
            //int refId = (int)e.Keys["RefID"];          

            //ProjectNavigatorProjectNotes model = new ProjectNavigatorProjectNotes(projectNavigatorTDS);
            //model.Delete(projectId, refId);

            //int? libraryFilesId = null;
            //if (((Label)grdNotes.Rows[e.RowIndex].Cells[3].FindControl("lblLibraryFileId")).Text.Trim() != "")
            //{
            //    libraryFilesId = Int32.Parse(((Label)grdNotes.Rows[e.RowIndex].Cells[3].FindControl("lblLibraryFileId")).Text.Trim());
            //    LibraryFilesGateway libraryFilesGateway = new LibraryFilesGateway();
            //    libraryFilesGateway.DeleteByLibraryFilesId((int)libraryFilesId);
            //}

            //// Store dataset
            //Session["projectNavigatorTDS"] = projectNavigatorTDS;
        }



        //protected void grdServices_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    // Services Gridview, if the gridview is edition mode
        //    if (grdServices.EditIndex >= 0)
        //    {
        //        grdServices.UpdateRow(grdServices.EditIndex, true);
        //    }

        //    // Delete services
        //    int projectId = (int)e.Keys["ProjectID"];
        //    int refId = (int)e.Keys["RefID"];

        //    ProjectNavigatorProjectService model = new ProjectNavigatorProjectService(projectNavigatorTDS);
        //    model.Delete(projectId, refId);

        //    // Store dataset
        //    Session["projectNavigatorTDS"] = projectNavigatorTDS;

        //    // ... Recalc total cost
        //    tbxTotalCost.Text = Decimal.Round(model.GetTotalCost(), 2).ToString();
        //}



        protected void grdJobClassClassification_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // grdJobClassClassification Gridview, if the gridview is edition mode
            if (grdJobClassClassification.EditIndex >= 0)
            {
                grdJobClassClassification.UpdateRow(grdJobClassClassification.EditIndex, true);
            }

            // Delete grdJobClassClassification
            int projectId = (int)e.Keys["ProjectID"];
            string jobClassType = (string)e.Keys["JobClassType"];
            int refId = (int)e.Keys["RefID"];

            // ... Delete
            ProjectNavigatorProjectJobClassTypeRate model = new ProjectNavigatorProjectJobClassTypeRate(projectNavigatorTDS);
            model.Delete(projectId, jobClassType, refId);
            
            // Store dataset
            Session["projectNavigatorTDS"] = projectNavigatorTDS;

            grdJobClassClassification.DataBind();
        }



        protected void grdTypeOfWorkFunctionClassification_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // grdTypeOfWorkFunctionClassification Gridview, if the gridview is edition mode
            if (grdTypeOfWorkFunctionClassification.EditIndex >= 0)
            {
                grdTypeOfWorkFunctionClassification.UpdateRow(grdTypeOfWorkFunctionClassification.EditIndex, true);
            }

            // Delete grdTypeOfWorkFunctionClassification
            int projectId = (int)e.Keys["ProjectID"];
            string work_ = (string)e.Keys["Work_"];
            string function_ = (string)e.Keys["Function_"];
            int refId = (int)e.Keys["RefID"];

            // Delete
            ProjectNavigatorProjectWorkFunctionFairWage model = new ProjectNavigatorProjectWorkFunctionFairWage(projectNavigatorTDS);
            model.Delete(projectId, work_, function_, refId);

            // Store dataset
            Session["projectNavigatorTDS"] = projectNavigatorTDS;

            grdTypeOfWorkFunctionClassification.DataBind();
        }



        protected void grdBudget_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // grdBudget_RowDeleting Gridview, if the gridview is edition mode
            if (grdBudget.EditIndex >= 0)
            {
                grdBudget.UpdateRow(grdBudget.EditIndex, true);
            }

            // Delete grdBudget row
            int projectId = (int)e.Keys["ProjectID"];
            string work_ = (string)e.Keys["Work_"];
            string function_ = (string)e.Keys["Function_"];
            int refId = (int)e.Keys["RefID"];

            // ... Delete
            ProjectNavigatorProjectWorkFunctionBudget model = new ProjectNavigatorProjectWorkFunctionBudget(projectNavigatorTDS);
            model.Delete(projectId, work_, function_, refId);

            // Store dataset
            Session["projectNavigatorTDS"] = projectNavigatorTDS;

            grdBudget.DataBind();
        }



        protected void grdSubcontractorsBudget_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //// grdBudget_RowDeleting Gridview, if the gridview is edition mode
            //if (grdSubcontractorsBudget.EditIndex >= 0)
            //{
            //    grdSubcontractorsBudget.UpdateRow(grdSubcontractorsBudget.EditIndex, true);
            //}

            //// Delete grdBudget row
            //int projectId = (int)e.Keys["ProjectID"];
            //int subcontractorId = (int)e.Keys["SubcontractorID"];
            //int refId = (int)e.Keys["RefID"];

            //// ... Delete
            //ProjectNavigatorProjectSubcontractorsBudget model = new ProjectNavigatorProjectSubcontractorsBudget(projectNavigatorTDS);
            //model.Delete(projectId, subcontractorId, refId);

            //// Store dataset
            //Session["projectNavigatorTDS"] = projectNavigatorTDS;

            //grdSubcontractorsBudget.DataBind();
        }



        protected void grdHotelsBudget_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //// grdBudget_RowDeleting Gridview, if the gridview is edition mode
            //if (grdHotelsBudget.EditIndex >= 0)
            //{
            //    grdHotelsBudget.UpdateRow(grdHotelsBudget.EditIndex, true);
            //}

            //// Delete grdBudget row
            //int projectId = (int)e.Keys["ProjectID"];
            //int hotelId = (int)e.Keys["HolelID"];
            //int refId = (int)e.Keys["RefID"];

            //// ... Delete
            //ProjectNavigatorProjectHotelsBudget model = new ProjectNavigatorProjectHotelsBudget(projectNavigatorTDS);
            //model.Delete(projectId, hotelId, refId);

            //// Store dataset
            //Session["projectNavigatorTDS"] = projectNavigatorTDS;

            //grdHotelsBudget.DataBind();
        }



        protected void grdBondingsBudget_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //// grdBudget_RowDeleting Gridview, if the gridview is edition mode
            //if (grdBondingsBudget.EditIndex >= 0)
            //{
            //    grdBondingsBudget.UpdateRow(grdBondingsBudget.EditIndex, true);
            //}

            //// Delete grdBudget row
            //int projectId = (int)e.Keys["ProjectID"];
            //int bondingCompanyId = (int)e.Keys["BondingCompanyID"];
            //int refId = (int)e.Keys["RefID"];

            //// ... Delete
            //ProjectNavigatorProjectBondingsBudget model = new ProjectNavigatorProjectBondingsBudget(projectNavigatorTDS);
            //model.Delete(projectId, bondingCompanyId, refId);

            //// Store dataset
            //Session["projectNavigatorTDS"] = projectNavigatorTDS;

            //grdBondingsBudget.DataBind();
        }



        protected void grdInsurancesBudget_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //// grdBudget_RowDeleting Gridview, if the gridview is edition mode
            //if (grdInsurancesBudget.EditIndex >= 0)
            //{
            //    grdInsurancesBudget.UpdateRow(grdInsurancesBudget.EditIndex, true);
            //}

            //// Delete grdBudget row
            //int projectId = (int)e.Keys["ProjectID"];
            //int insuranceCompanyId = (int)e.Keys["InsuranceCompanyID"];
            //int refId = (int)e.Keys["RefID"];

            //// ... Delete
            //ProjectNavigatorProjectInsurancesBudget model = new ProjectNavigatorProjectInsurancesBudget(projectNavigatorTDS);
            //model.Delete(projectId, insuranceCompanyId, refId);

            //// Store dataset
            //Session["projectNavigatorTDS"] = projectNavigatorTDS;

            //grdInsurancesBudget.DataBind();
        }



        protected void grdOtherCostsBudget_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // grdBudget_RowDeleting Gridview, if the gridview is edition mode
            if (grdOtherCostsBudget.EditIndex >= 0)
            {
                grdOtherCostsBudget.UpdateRow(grdOtherCostsBudget.EditIndex, true);
            }

            // Delete grdBudget row
            int projectId = (int)e.Keys["ProjectID"];
            string category = (string)e.Keys["Category"];
            int refId = (int)e.Keys["RefID"];

            // ... Delete
            ProjectNavigatorProjectOtherCostsBudget model = new ProjectNavigatorProjectOtherCostsBudget(projectNavigatorTDS);
            model.Delete(projectId, category, refId);

            // Store dataset
            Session["projectNavigatorTDS"] = projectNavigatorTDS;

            grdOtherCostsBudget.DataBind();
        }



        //protected void grdNotes_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    switch (e.CommandName)
        //    {
        //        case "Add":
        //            // Notes Gridview, if the gridview is edition mode
        //            if (grdNotes.EditIndex >= 0)
        //            {
        //                grdNotes.UpdateRow(grdNotes.EditIndex, true);
        //            }

        //            // Add New Note
        //            GrdNotesAdd();
        //            break;

        //        case "AddAttachmentEdit":
        //            Session["activeTabProjects"] = "7";
        //            Session["dialogOpenedProjects"] = "1";
        //            GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
        //            int refId = Int32.Parse(((Label)row.FindControl("lblRefIDEdit")).Text);
        //            string subject = ((TextBox)row.FindControl("tbxNoteSubjectEdit")).Text.Trim();
        //            GrdNotesAddAttachment(refId, subject);
        //            break;

        //        case "AddAttachmentAdd":
        //            Session["activeTabProjects"] = "7";
        //            Session["dialogOpenedProjects"] = "1";
        //            string newSubject = ((TextBox)grdNotes.FooterRow.FindControl("tbxNoteSubjectNew")).Text.Trim();
        //            GrdNotesAddAttachment(null, newSubject);
        //            break;

        //        case "DownloadAttachment":
        //            GridViewRow rowDonwload = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
        //            string originalFileName = ((TextBox)rowDonwload.FindControl("tbxNoteAttachment")).Text;
        //            string fileName = ((Label)rowDonwload.FindControl("lblFileName")).Text;
        //            GrdNotesOpenAttachment(originalFileName, fileName);
        //            break;

        //        case "DeleteAttachmentEdit":
        //            GridViewRow rowDelete = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
        //            int refIdEdit = Int32.Parse(((Label)rowDelete.FindControl("lblRefIDEdit")).Text);
        //            int libraryFilesIdEdit = Int32.Parse(((Label)rowDelete.FindControl("lblLibraryFileIdEdit")).Text);
        //            GrdNotesDeleteAttachment(libraryFilesIdEdit, refIdEdit);
        //            break;
        //    }
        //}



        //protected void grdServices_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    switch (e.CommandName)
        //    {
        //        case "Add":
        //            // grdServices Gridview, if the gridview is edition mode
        //            if (grdServices.EditIndex >= 0)
        //            {
        //                grdServices.UpdateRow(grdServices.EditIndex, true);
        //            }

        //            // Add New services
        //            GrdServicesAdd();
        //            break;
        //    }
        //}



        protected void grdJobClassClassification_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Add":
                    // grdJobClassClassification Gridview, if the gridview is edition mode
                    if (grdJobClassClassification.EditIndex >= 0)
                    {
                        grdJobClassClassification.UpdateRow(grdJobClassClassification.EditIndex, true);
                    }

                    // Add New grdJobClassClassification
                    GrdJobClassClassificationAdd();
                    break;
            }
        }



        protected void grdTypeOfWorkFunctionClassification_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Add":
                    // grdTypeOfWorkFunctionClassification Gridview, if the gridview is edition mode
                    if (grdTypeOfWorkFunctionClassification.EditIndex >= 0)
                    {
                        grdTypeOfWorkFunctionClassification.UpdateRow(grdTypeOfWorkFunctionClassification.EditIndex, true);
                    }

                    // Add New grdTypeOfWorkFunctionClassification
                    GrdTypeOfWorkFunctionClassificationAdd();
                    break;
            }
        }



        protected void grdBudget_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Add":
                    // grdBudget Gridview, if the gridview is edition mode
                    if (grdBudget.EditIndex >= 0)
                    {
                        grdBudget.UpdateRow(grdBudget.EditIndex, true);
                    }

                    // Add New grdBudget
                    GrdTypeOfWorkFunctionBudgetAdd();
                    break;
            }
        }



        protected void grdSubcontractorsBudget_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //switch (e.CommandName)
            //{
            //    case "Add":
            //        // grdSubcontractorsBudget Gridview, if the gridview is edition mode
            //        if (grdSubcontractorsBudget.EditIndex >= 0)
            //        {
            //            grdSubcontractorsBudget.UpdateRow(grdSubcontractorsBudget.EditIndex, true);
            //        }

            //        // Add New grdBudget
            //        GrdSubcontractorsBudgetAdd();
            //        break;
            //}
        }



        protected void grdHotelsBudget_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //switch (e.CommandName)
            //{
            //    case "Add":
            //        // grdHotelsBudget Gridview, if the gridview is edition mode
            //        if (grdHotelsBudget.EditIndex >= 0)
            //        {
            //            grdHotelsBudget.UpdateRow(grdHotelsBudget.EditIndex, true);
            //        }

            //        // Add New grdBudget
            //        GrdHotelsBudgetAdd();
            //        break;
            //}
        }



        protected void grdBondingsBudget_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //switch (e.CommandName)
            //{
            //    case "Add":
            //        // grdBondingsBudget Gridview, if the gridview is edition mode
            //        if (grdBondingsBudget.EditIndex >= 0)
            //        {
            //            grdBondingsBudget.UpdateRow(grdBondingsBudget.EditIndex, true);
            //        }

            //        // Add New grdBudget
            //        GrdBondingsBudgetAdd();
            //        break;
            //}
        }



        protected void grdInsurancesBudget_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //switch (e.CommandName)
            //{
            //    case "Add":
            //        // grdInsurancesBudget Gridview, if the gridview is edition mode
            //        if (grdInsurancesBudget.EditIndex >= 0)
            //        {
            //            grdInsurancesBudget.UpdateRow(grdInsurancesBudget.EditIndex, true);
            //        }

            //        // Add New grdBudget
            //        GrdInsurancesBudgetAdd();
            //        break;
            //}
        }



        protected void grdOtherCostsBudget_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Add":
                    // grdOtherCostsBudget Gridview, if the gridview is edition mode
                    if (grdOtherCostsBudget.EditIndex >= 0)
                    {
                        grdOtherCostsBudget.UpdateRow(grdOtherCostsBudget.EditIndex, true);
                    }

                    // Add New grdBudget
                    GrdOtherCostsBudgetAdd();
                    break;
            }
        }
        


        //protected void grdNotes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        //{
        //    Page.Validate("notesDataEdit");
        //    if (Page.IsValid)
        //    {
        //        int companyId = Int32.Parse(hdfCompanyId.Value);
        //        int projectId = Int32.Parse(((Label)grdNotes.Rows[e.RowIndex].Cells[0].FindControl("lblProjectIDEdit")).Text.Trim());
        //        int refId = Int32.Parse(((Label)grdNotes.Rows[e.RowIndex].Cells[1].FindControl("lblRefIDEdit")).Text.Trim());
        //        string subject = ((TextBox)grdNotes.Rows[e.RowIndex].Cells[4].FindControl("tbxNoteSubjectEdit")).Text.Trim();
        //        string note = ((TextBox)grdNotes.Rows[e.RowIndex].Cells[5].FindControl("tbxNoteNoteEdit")).Text.Trim();                

        //        int? libraryFilesId = null;
        //        if (((Label)grdNotes.Rows[e.RowIndex].Cells[3].FindControl("lblLibraryFileIdEdit")).Text.Trim() != "")
        //        {
        //            libraryFilesId = Int32.Parse(((Label)grdNotes.Rows[e.RowIndex].Cells[3].FindControl("lblLibraryFileIdEdit")).Text.Trim());
        //        }

        //        // Update data
        //        ProjectNavigatorProjectNotes model = new ProjectNavigatorProjectNotes(projectNavigatorTDS);
        //        model.Update(projectId, refId, subject, note, libraryFilesId);

        //        // Store dataset
        //        Session["projectNavigatorTDS"] = projectNavigatorTDS;
        //    }
        //    else
        //    {
        //        e.Cancel = true;
        //    }
        //}
        


        //protected void grdServices_RowUpdating(object sender, GridViewUpdateEventArgs e)
        //{
        //    Page.Validate("serviceDataEdit");
        //    if (Page.IsValid)
        //    {
        //        int companyId = Int32.Parse(hdfCompanyId.Value);
        //        int projectId = Int32.Parse(((Label)grdServices.Rows[e.RowIndex].Cells[0].FindControl("lblProjectID")).Text.Trim());
        //        int refId = Int32.Parse(((Label)grdServices.Rows[e.RowIndex].Cells[1].FindControl("lblRefID")).Text.Trim());

        //        int? serviceId = null;
        //        if (((DropDownList)grdServices.Rows[e.RowIndex].Cells[2].FindControl("ddlServiceEdit")).SelectedValue != "-1")
        //        {
        //            serviceId = int.Parse(((DropDownList)grdServices.Rows[e.RowIndex].Cells[2].FindControl("ddlServiceEdit")).SelectedValue);
        //        }

        //        string description = ((TextBox)grdServices.Rows[e.RowIndex].Cells[3].FindControl("tbxDescriptionEdit")).Text.Trim();

        //        int quantity = 0;
        //        if (((TextBox)grdServices.Rows[e.RowIndex].Cells[4].FindControl("tbxQuantityEdit")).Text.Trim() != "")
        //        {
        //            quantity = int.Parse(((TextBox)grdServices.Rows[e.RowIndex].Cells[4].FindControl("tbxQuantityEdit")).Text.Trim());
        //        }

        //        string averageSize = ((TextBox)grdServices.Rows[e.RowIndex].Cells[5].FindControl("tbxAverageSizeEdit")).Text.Trim();

        //        decimal? averagePrice = 0.00M;
        //        decimal total = 0.00M;
        //        if (((TextBox)grdServices.Rows[e.RowIndex].Cells[6].FindControl("tbxAveragePriceEdit")).Text.Trim() != "")
        //        {
        //            averagePrice = decimal.Parse(((TextBox)grdServices.Rows[e.RowIndex].Cells[6].FindControl("tbxAveragePriceEdit")).Text.Trim());
        //            total = decimal.Round(((decimal)averagePrice * quantity), 2);
        //        }                    
                
        //        // Update data
        //        ProjectNavigatorProjectService model = new ProjectNavigatorProjectService(projectNavigatorTDS);
        //        model.Update(projectId, refId, serviceId, description, averageSize, averagePrice, quantity, total);

        //        // Store dataset
        //        Session["projectNavigatorTDS"] = projectNavigatorTDS;

        //        // ... Recalc total cost
        //        tbxTotalCost.Text = Decimal.Round(model.GetTotalCost(), 2).ToString();
        //    }
        //    else
        //    {
        //        e.Cancel = true;
        //    }
        //}



        protected void grdJobClassClassification_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.Validate("jobClassClassificationDataEdit");
            if (Page.IsValid)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                int projectId = Int32.Parse(((Label)grdJobClassClassification.Rows[e.RowIndex].Cells[0].FindControl("lblProjectIDEdit")).Text.Trim());
                string jobClassType = ((Label)grdJobClassClassification.Rows[e.RowIndex].Cells[0].FindControl("lblJobClassTypeEdit")).Text.Trim();
                int refId = Int32.Parse(((Label)grdJobClassClassification.Rows[e.RowIndex].Cells[1].FindControl("lblRefIDEdit")).Text.Trim());
                decimal rate = Decimal.Parse(((TextBox)grdJobClassClassification.Rows[e.RowIndex].Cells[1].FindControl("tbxRateEdit")).Text.Trim());
                decimal fringeRate = Decimal.Parse(((TextBox)grdJobClassClassification.Rows[e.RowIndex].Cells[1].FindControl("tbxFringeRateEdit")).Text.Trim());

                // Update data
                ProjectNavigatorProjectJobClassTypeRate model = new ProjectNavigatorProjectJobClassTypeRate(projectNavigatorTDS);
                model.Update(projectId, jobClassType, refId, rate, fringeRate);

                projectJobClassClassification = projectNavigatorTDS.LFS_PROJECT_JOB_CLASS_TYPE_RATE;
                Session["projectJobClassClassification"] = projectJobClassClassification;

                // Store dataset
                Session["projectNavigatorTDS"] = projectNavigatorTDS;
            }
            else
            {
                e.Cancel = true;
            }
        }



        protected void grdTypeOfWorkFunctionClassification_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Cancel fairWage update
            Session["fairWage"] = "None";

            // New Values
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int projectId = Int32.Parse(((Label)grdTypeOfWorkFunctionClassification.Rows[e.RowIndex].Cells[0].FindControl("lblProjectIDEdit")).Text.Trim());
            string work_ = ((Label)grdTypeOfWorkFunctionClassification.Rows[e.RowIndex].Cells[0].FindControl("lblWork_Edit")).Text.Trim();
            string function_ = ((Label)grdTypeOfWorkFunctionClassification.Rows[e.RowIndex].Cells[0].FindControl("lblFunction_Edit")).Text.Trim();
            int refId = Int32.Parse(((Label)grdTypeOfWorkFunctionClassification.Rows[e.RowIndex].Cells[1].FindControl("lblRefIDEdit")).Text.Trim());
            bool isFairWage = false; if (((CheckBox)grdTypeOfWorkFunctionClassification.Rows[e.RowIndex].Cells[0].FindControl("cbxIsFairWageEdit")).Checked) isFairWage = true;

            // Update data
            ProjectNavigatorProjectWorkFunctionFairWage model = new ProjectNavigatorProjectWorkFunctionFairWage(projectNavigatorTDS);
            model.Update(projectId, work_, function_, refId, isFairWage, false, companyId);

            // Store dataset
            Session["projectNavigatorTDS"] = projectNavigatorTDS;

            projectTypeOfWorkFunctionClassification = projectNavigatorTDS.LFS_PROJECT_WORK_FUNCTION_FAIR_WAGE;
            Session["projectTypeOfWorkFunctionClassification"] = projectTypeOfWorkFunctionClassification;
        }



        protected void grdBudget_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // New Values
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int projectId = Int32.Parse(((Label)grdBudget.Rows[e.RowIndex].Cells[0].FindControl("lblProjectIDEdit")).Text.Trim());
            string work_ = ((Label)grdBudget.Rows[e.RowIndex].Cells[0].FindControl("lblWork_Edit")).Text.Trim();
            string function_ = ((Label)grdBudget.Rows[e.RowIndex].Cells[0].FindControl("lblFunction_Edit")).Text.Trim();
            int refId = Int32.Parse(((Label)grdBudget.Rows[e.RowIndex].Cells[1].FindControl("lblRefIDEdit")).Text.Trim());
            decimal budget = decimal.Parse(((TextBox)grdBudget.Rows[e.RowIndex].Cells[0].FindControl("tbxBudgetEdit")).Text);
            decimal budget_ = decimal.Parse(((TextBox)grdBudget.Rows[e.RowIndex].Cells[0].FindControl("tbxBudget_Edit")).Text);

            // Update data
            ProjectNavigatorProjectWorkFunctionBudget model = new ProjectNavigatorProjectWorkFunctionBudget(projectNavigatorTDS);
            model.Update(projectId, work_, function_, refId, budget, false, companyId, budget_);

            // Store dataset
            Session["projectNavigatorTDS"] = projectNavigatorTDS;

            projectBudget = projectNavigatorTDS.ProjectWorkFunctionBudget;
            Session["projectBudget"] = projectBudget;
        }



        protected void grdSubcontractorsBudget_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //Page.Validate("SubcontractorsBudgetEdit");
            //if (Page.IsValid)
            //{
            //    // New Values
            //    int companyId = Int32.Parse(hdfCompanyId.Value);
            //    int projectId = Int32.Parse(((Label)grdSubcontractorsBudget.Rows[e.RowIndex].Cells[0].FindControl("lblProjectIDEdit")).Text.Trim());
            //    int subcontractorId = Int32.Parse(((DropDownList)grdSubcontractorsBudget.Rows[e.RowIndex].Cells[0].FindControl("ddlSubcontractorEdit")).SelectedValue);
            //    int refId = Int32.Parse(((Label)grdSubcontractorsBudget.Rows[e.RowIndex].Cells[1].FindControl("lblRefIDEdit")).Text.Trim());
            //    decimal budget = decimal.Parse(((TextBox)grdSubcontractorsBudget.Rows[e.RowIndex].Cells[0].FindControl("tbxBudgetEdit")).Text);

            //    // Update data
            //    ProjectNavigatorProjectSubcontractorsBudget model = new ProjectNavigatorProjectSubcontractorsBudget(projectNavigatorTDS);
            //    model.Update(projectId, subcontractorId, refId, budget, false, companyId);

            //    // Store dataset
            //    Session["projectNavigatorTDS"] = projectNavigatorTDS;

            //    subcontractorsBudget = projectNavigatorTDS.ProjectSubcontractorsBudget;
            //    Session["subcontractorsBudget"] = subcontractorsBudget;
            //}
        }



        protected void grdHotelsBudget_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //Page.Validate("HotelsBudgetEdit");
            //if (Page.IsValid)
            //{
            //    // New Values
            //    int companyId = Int32.Parse(hdfCompanyId.Value);
            //    int projectId = Int32.Parse(((Label)grdHotelsBudget.Rows[e.RowIndex].Cells[0].FindControl("lblProjectIDEdit")).Text.Trim());
            //    int hotelId = Int32.Parse(((DropDownList)grdHotelsBudget.Rows[e.RowIndex].Cells[0].FindControl("ddlHotelEdit")).SelectedValue);
            //    int refId = Int32.Parse(((Label)grdHotelsBudget.Rows[e.RowIndex].Cells[1].FindControl("lblRefIDEdit")).Text.Trim());
            //    decimal budget = decimal.Parse(((TextBox)grdHotelsBudget.Rows[e.RowIndex].Cells[0].FindControl("tbxBudgetEdit")).Text);

            //    // Update data
            //    ProjectNavigatorProjectHotelsBudget model = new ProjectNavigatorProjectHotelsBudget(projectNavigatorTDS);
            //    model.Update(projectId, hotelId, refId, budget, false, companyId);

            //    // Store dataset
            //    Session["projectNavigatorTDS"] = projectNavigatorTDS;

            //    hotelsBudget = projectNavigatorTDS.ProjectHotelsBudget;
            //    Session["hotelsBudget"] = hotelsBudget;
            //}
        }



        protected void grdBondingsBudget_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //Page.Validate("BondingsBudgetEdit");
            //if (Page.IsValid)
            //{
            //    // New Values
            //    int companyId = Int32.Parse(hdfCompanyId.Value);
            //    int projectId = Int32.Parse(((Label)grdBondingsBudget.Rows[e.RowIndex].Cells[0].FindControl("lblProjectIDEdit")).Text.Trim());
            //    int bondingId = Int32.Parse(((DropDownList)grdBondingsBudget.Rows[e.RowIndex].Cells[0].FindControl("ddlBondingEdit")).SelectedValue);
            //    int refId = Int32.Parse(((Label)grdBondingsBudget.Rows[e.RowIndex].Cells[1].FindControl("lblRefIDEdit")).Text.Trim());
            //    decimal budget = decimal.Parse(((TextBox)grdBondingsBudget.Rows[e.RowIndex].Cells[0].FindControl("tbxBudgetEdit")).Text);

            //    // Update data
            //    ProjectNavigatorProjectBondingsBudget model = new ProjectNavigatorProjectBondingsBudget(projectNavigatorTDS);
            //    model.Update(projectId, bondingId, refId, budget, false, companyId);

            //    // Store dataset
            //    Session["projectNavigatorTDS"] = projectNavigatorTDS;

            //    bondingsBudget = projectNavigatorTDS.ProjectBondingsBudget;
            //    Session["bondingsBudget"] = bondingsBudget;
            //}
        }



        protected void grdInsurancesBudget_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //Page.Validate("InsurancesBudgetEdit");
            //if (Page.IsValid)
            //{
            //    // New Values
            //    int companyId = Int32.Parse(hdfCompanyId.Value);
            //    int projectId = Int32.Parse(((Label)grdInsurancesBudget.Rows[e.RowIndex].Cells[0].FindControl("lblProjectIDEdit")).Text.Trim());
            //    int insuranceId = Int32.Parse(((DropDownList)grdInsurancesBudget.Rows[e.RowIndex].Cells[0].FindControl("ddlInsuranceEdit")).SelectedValue);
            //    int refId = Int32.Parse(((Label)grdInsurancesBudget.Rows[e.RowIndex].Cells[1].FindControl("lblRefIDEdit")).Text.Trim());
            //    decimal budget = decimal.Parse(((TextBox)grdInsurancesBudget.Rows[e.RowIndex].Cells[0].FindControl("tbxBudgetEdit")).Text);

            //    // Update data
            //    ProjectNavigatorProjectInsurancesBudget model = new ProjectNavigatorProjectInsurancesBudget(projectNavigatorTDS);
            //    model.Update(projectId, insuranceId, refId, budget, false, companyId);

            //    // Store dataset
            //    Session["projectNavigatorTDS"] = projectNavigatorTDS;

            //    insurancesBudget = projectNavigatorTDS.ProjectInsurancesBudget;
            //    Session["insurancesBudget"] = insurancesBudget;
            //}
        }



        protected void grdOtherCostsBudget_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.Validate("OtherCostsBudgetEdit");
            if (Page.IsValid)
            {
                // New Values
                int companyId = Int32.Parse(hdfCompanyId.Value);
                int projectId = Int32.Parse(((Label)grdOtherCostsBudget.Rows[e.RowIndex].Cells[0].FindControl("lblProjectIDEdit")).Text.Trim());
                string category = ((DropDownList)grdOtherCostsBudget.Rows[e.RowIndex].Cells[0].FindControl("ddlCategoryEdit")).SelectedValue;
                int refId = Int32.Parse(((Label)grdOtherCostsBudget.Rows[e.RowIndex].Cells[1].FindControl("lblRefIDEdit")).Text.Trim());
                decimal budget = decimal.Parse(((TextBox)grdOtherCostsBudget.Rows[e.RowIndex].Cells[0].FindControl("tbxBudgetEdit")).Text);

                // Update data
                ProjectNavigatorProjectOtherCostsBudget model = new ProjectNavigatorProjectOtherCostsBudget(projectNavigatorTDS);
                model.Update(projectId, category, refId, budget, false, companyId);

                // Store dataset
                Session["projectNavigatorTDS"] = projectNavigatorTDS;

                otherCostsBudget = projectNavigatorTDS.ProjectOtherCostsBudget;
                Session["otherCostsBudget"] = otherCostsBudget;
            }
        }



        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Reload data for work and functions depending if it's faire wage or not.
            grdTypeOfWorkFunctionClassification.DataBind();                    

            // Security check
            ProjectGateway projectGateway = new ProjectGateway(projectTDS);
                        
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
                //ddlGeneralMOLForm.Visible = true;
                //tbxGeneralMOLForm.Visible = false;
                //lblGeneralNoticeProject.Visible = true;
                //rbtnGeneralNoticeProject.Visible = true;
                //lblGeneralForm1000.Visible = true;
                //rbtnGeneralForm1000.Visible = true;

                grdJobClassClassification.Columns[4].HeaderText = "Rate (CAD)";
                grdJobClassClassification.Columns[5].HeaderText = "Fringe Rate (CAD)";
            }
            else
            {
                //ddlGeneralMOLForm.Visible = false;
                //tbxGeneralMOLForm.Visible = true;
                //lblGeneralNoticeProject.Visible = false;
                //rbtnGeneralNoticeProject.Visible = false;
                //lblGeneralForm1000.Visible = false;
                //rbtnGeneralForm1000.Visible = false;

                grdJobClassClassification.Columns[4].HeaderText = "Rate (USD)";
                grdJobClassClassification.Columns[5].HeaderText = "Fringe Rate (USD)";
            }

            // Set active toolbar
            mForm6 master = (mForm6)this.Master;
            master.ActiveToolbar = "Projects";            

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

                lblHeaderTitle.Text = "Ballpark Summary";
                lblTitleProject.Text = " > Ballpark: ";

                // Initial section
                lblProposalDate.Text = "Ballpark Date";
                lblStartDate.Text = "Potential Start Date";
                lblEndDate.Text = "Potential End Date";
                lblStartDate.Visible = true;
                tkrdpStartDate.Visible = true;
                lblEndDate.Visible = true;
                tkrdpEndDate.Visible = true;

                // Client section
                lblClientProjectNumber.Visible = false;
                tbxClientProjectNumber.Visible = false;
                lblClientPrimaryContactId.Visible = false;
                ddlClientPrimaryContactId.Visible = false;
                btnClientPrimaryContact.Visible = false;
                lblClientSecondaryContactId.Visible = false;
                ddlClientSecondaryContactId.Visible = false;
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
                // tpEngineerSubcontractors.Enabled = false;
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
            }

            if (projectGateway.GetProjectType(int.Parse(hdfProjectId.Value)) == "Project")
            {
                // Set initial tab
                tcDetailedInformation.ActiveTabIndex = Int32.Parse(hdfActiveTab.Value);

                // Left menu
                tkrpbLeftMenuCurrentProject.Items[0].Text = "Current Project";
                tkrpbLeftMenuCurrentProject.Items[0].Items[0].Text = "Project";

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

                lblHeaderTitle.Text = "Internal Project Summary";
                lblTitleProject.Text = " > Internal Project: ";

                // Initial section
                lblProposalDate.Text = "Internal Project Date";
                lblStartDate.Visible = false;
                tkrdpStartDate.Visible = false;
                lblEndDate.Visible = false;
                tkrdpEndDate.Visible = false;
                tbxDescription.Width = Unit.Pixel(510);

                // Client section
                lblClientProjectNumber.Visible = false;
                tbxClientProjectNumber.Visible = false;
                lblClientPrimaryContactId.Visible = false;
                ddlClientPrimaryContactId.Visible = false;
                btnClientPrimaryContact.Visible = false;
                lblClientSecondaryContactId.Visible = false;
                ddlClientSecondaryContactId.Visible = false;
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
            Save2();

            // Open Dialog                      
            string script = "<script language='javascript'>";
            string url = "./project_notes.aspx?source_page=project_edit.aspx&&client_id=" + hdfClientId.Value + "&project_id=" + hdfProjectId.Value;
            script = script + string.Format("window.open('{0}', '_blank', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=795, height=640')", url);
            script = script + "</script>";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Comments", script, false);
        }



        protected void cvFairWageApplies_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;
            int projectId = Int32.Parse(hdfProjectId.Value);

            if ((projectId != 350) && (projectId != 369) && (projectId != 332) && (projectId != 278) && (projectId != 451))
            {
                DateTime minDate = new DateTime(2010, 5, 30);

                if (cbxFairWageApplies.Checked)
                {
                    if (tkrdpProposalDate.SelectedDate.HasValue)
                    {
                        if (tkrdpProposalDate.SelectedDate.Value < minDate)
                        {
                            args.IsValid = false;
                        }
                    }
                    else
                    {
                        args.IsValid = false;
                    }
                }
            }
        }



        //protected void cvDescriptionFooter_ServerValidate(object source, ServerValidateEventArgs args)
        //{
        //    args.IsValid = true;
        //    string service = ((DropDownList)grdServices.FooterRow.FindControl("ddlServiceFooter")).SelectedValue.Trim();
        //    string description = ((TextBox)grdServices.FooterRow.FindControl("tbxDescriptionFooter")).Text.Trim();

        //    if ((service == "-1") && (description == ""))
        //    {
        //        args.IsValid = false;
        //    }
        //}



        //protected void cvDescriptionEdit_ServerValidate(object source, ServerValidateEventArgs args)
        //{
        //    args.IsValid = true;
        //    string service = ((DropDownList)grdServices.Rows[grdServices.EditIndex].Cells[2].FindControl("ddlServiceEdit")).SelectedValue.Trim();
        //    string description = ((TextBox)grdServices.Rows[grdServices.EditIndex].Cells[3].FindControl("tbxDescriptionEdit")).Text.Trim();

        //    if ((service == "-1") && (description == ""))
        //    {
        //        args.IsValid = false;
        //    }
        //}



        //protected void cvQuantityEmptyEdit_ServerValidate(object source, ServerValidateEventArgs args)
        //{
        //    args.IsValid = true;
        //    if (((TextBox)grdServices.Rows[grdServices.EditIndex].Cells[4].FindControl("tbxQuantityEdit")).Text.Trim() != "")
        //    {
        //        int quantity = int.Parse(((TextBox)grdServices.Rows[grdServices.EditIndex].Cells[4].FindControl("tbxQuantityEdit")).Text.Trim());
        //        if (quantity <= 0)
        //        {
        //            args.IsValid = false;
        //        }
        //    }
        //    else
        //    {
        //        args.IsValid = false;
        //    }
        //}



        //protected void cvQuantityEmptyFooter_ServerValidate(object source, ServerValidateEventArgs args)
        //{
        //    args.IsValid = true;
        //    if (((TextBox)grdServices.FooterRow.FindControl("tbxQuantityFooter")).Text.Trim() != "")
        //    {
        //        int quantity = int.Parse(((TextBox)grdServices.FooterRow.FindControl("tbxQuantityFooter")).Text.Trim());
        //        if (quantity <= 0)
        //        {
        //            args.IsValid = false;
        //        }
        //    }
        //    else
        //    {
        //        args.IsValid = false;
        //    }
        //}



        //protected void cvAverageSizeEdit_ServerValidate(object source, ServerValidateEventArgs args)
        //{
        //    args.IsValid = true;
        //    string averageSize = ((TextBox)grdServices.Rows[grdServices.EditIndex].Cells[5].FindControl("tbxAverageSizeEdit")).Text.Trim();
        //    if (!Distance.IsValidDistance(averageSize))            
        //    {
        //        args.IsValid = false;
        //    }
        //}



        //protected void cvAverageSizeFooter_ServerValidate(object source, ServerValidateEventArgs args)
        //{
        //    args.IsValid = true;
        //    string averageSize = ((TextBox)grdServices.FooterRow.FindControl("tbxAverageSizeFooter")).Text.Trim();
        //    if (!Distance.IsValidDistance(averageSize))
        //    {
        //        args.IsValid = false;
        //    }
        //}



        //protected void cvAveragePriceValidationEdit_ServerValidate(object source, ServerValidateEventArgs args)
        //{
        //    args.IsValid = true;
        //    if (((TextBox)grdServices.Rows[grdServices.EditIndex].Cells[6].FindControl("tbxAveragePriceEdit")).Text.Trim() != "")
        //    {
        //        decimal? averagePrice = decimal.Parse(((TextBox)grdServices.Rows[grdServices.EditIndex].Cells[6].FindControl("tbxAveragePriceEdit")).Text.Trim());
        //        if (averagePrice < 0)
        //        {
        //            args.IsValid = false;
        //        }
        //    }            
        //}



        //protected void cvAveragePriceValidationFooter_ServerValidate(object source, ServerValidateEventArgs args)
        //{
        //    args.IsValid = true;
        //    if (((TextBox)grdServices.FooterRow.FindControl("tbxAveragePriceFooter")).Text.Trim() != "")
        //    {
        //        decimal? averagePrice = decimal.Parse(((TextBox)grdServices.FooterRow.FindControl("tbxAveragePriceFooter")).Text.Trim());
        //        if (averagePrice < 0)
        //        {
        //            args.IsValid = false;
        //        }
        //    }
        //}
               


        //protected void grdvSubcontractors_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    if (e.CommandName == "deleteSubcontractor")
        //    {
        //        ProjectSubcontractor projectSubcontractor = new ProjectSubcontractor(projectTDS);
        //        projectSubcontractor.Delete(int.Parse(hdfProjectId.Value), int.Parse(e.CommandArgument.ToString()));

        //        Session["lfsProjectTDS"] = projectTDS;
        //    }
        //}



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

            // Country check
        //    ProjectGateway projectGateway = new ProjectGateway(projectTDS);
        //    foreach (GridViewRow row in grdvSubcontractors.Rows)
        //    {
        //        DropDownList ddlSubcontractorMOLForm1000 = (DropDownList)row.FindControl("ddlSubcontractorMOLForm1000");
        //        TextBox tbxSubcontractorMOLForm1000 = (TextBox)row.FindControl("tbxSubcontractorMOLForm1000");
        //        if (projectGateway.GetCountryID(int.Parse(hdfProjectId.Value)) == 1)
        //        {
        //            ddlSubcontractorMOLForm1000.Visible = true;
        //            tbxSubcontractorMOLForm1000.Visible = false;
        //        }
        //        else
        //        {
        //            ddlSubcontractorMOLForm1000.Visible = false;
        //            tbxSubcontractorMOLForm1000.Visible = true;
        //        }
        //    }
        //}



        //protected void grdNotes_DataBound(object sender, EventArgs e)
        //{
        //    AddNotesNewEmptyFix(grdNotes);
        //}



        //protected void grdServices_DataBound(object sender, EventArgs e)
        //{
        //    AddServicesNewEmptyFix(grdServices);
        //}



        protected void grdJobClassClassification_DataBound(object sender, EventArgs e)
        {
            AddJobClassClassificationNewEmptyFix(grdJobClassClassification);
        }



        protected void grdTypeOfWorkFunctionClassification_DataBound(object sender, EventArgs e)
        {
            AddTypeOfWorkFunctionClassificationNewEmptyFix(grdTypeOfWorkFunctionClassification);
        }



        protected void grdBudget_DataBound(object sender, EventArgs e)
        {
            AddTypeOfWorkFunctionBudgetNewEmptyFix(grdBudget);
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



        protected void grdOtherCostsBudget_DataBound(object sender, EventArgs e)
        {
            AddOtherCostsBudgetNewEmptyFix(grdOtherCostsBudget);
        }
        

        
        protected void grdNotes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Edit items
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Edit) || (e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
            {
                string originalFileNameEdit = ((TextBox)e.Row.FindControl("tbxNoteAttachmentEdit")).Text;
                string fileName = ((Label)e.Row.FindControl("lblFileNameEdit")).Text;
                int libraryFileId = 0; if (((Label)e.Row.FindControl("lblLibraryFileIdEdit")).Text != "") libraryFileId = Int32.Parse(((Label)e.Row.FindControl("lblLibraryFileIdEdit")).Text);

                // Button visibility
                if (originalFileNameEdit == "")
                {
                    ((Button)e.Row.FindControl("btnNoteDeleteEdit")).Visible = false;
                    ((Button)e.Row.FindControl("btnNoteAddEdit")).Visible = true;
                }
                else
                {
                    ((Button)e.Row.FindControl("btnNoteDeleteEdit")).Visible = true;
                    ((Button)e.Row.FindControl("btnNoteAddEdit")).Visible = false;
                }
            }

            // Normal items
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Normal) || (e.Row.RowState == (DataControlRowState.Normal | DataControlRowState.Alternate))))
            {
                string originalFileName = ((TextBox)e.Row.FindControl("tbxNoteAttachment")).Text;
                string fileName = ((Label)e.Row.FindControl("lblFileName")).Text;
                int libraryFileId = 0; if (((Label)e.Row.FindControl("lblLibraryFileId")).Text != "") libraryFileId = Int32.Parse(((Label)e.Row.FindControl("lblLibraryFileId")).Text);

                // Button visibility
                if (originalFileName == "")
                {
                    ((Button)e.Row.FindControl("btnNoteDownload")).Visible = false;
                }
                else
                {
                    ((Button)e.Row.FindControl("btnNoteDownload")).Visible = true;
                }                
            }
        }



        protected void grdServices_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Edit items
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Edit) || (e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
            {
                // Initialize values
                int projectId = Int32.Parse(((Label)e.Row.FindControl("lblProjectId")).Text);
                int refId = Int32.Parse(((Label)e.Row.FindControl("lblRefId")).Text);

                // For Services
                ProjectNavigatorProjectServiceGateway projectNavigatorProjectServiceGateway = new ProjectNavigatorProjectServiceGateway(projectNavigatorTDS);

                if (projectNavigatorProjectServiceGateway.GetServiceID(projectId, refId).HasValue)
                {
                    int? serviceId = projectNavigatorProjectServiceGateway.GetServiceID(projectId, refId);
                    if (serviceId.HasValue)
                    {
                        ((DropDownList)e.Row.FindControl("ddlServiceEdit")).SelectedValue = ((int)serviceId).ToString();
                    }
                }
                else
                {
                    ((DropDownList)e.Row.FindControl("ddlServiceEdit")).SelectedValue = "(Other)";
                }               
            }

            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Normal) || (e.Row.RowState == (DataControlRowState.Normal | DataControlRowState.Alternate))))
            {
                // Initialize values                
                int projectId = Int32.Parse(((Label)e.Row.FindControl("lblProjectId")).Text);
                if (projectId >= 0)
                {
                    int refId = Int32.Parse(((Label)e.Row.FindControl("lblRefId")).Text);

                    // For Services
                    ProjectNavigatorProjectServiceGateway projectNavigatorProjectServiceGateway = new ProjectNavigatorProjectServiceGateway(projectNavigatorTDS);
                    int? serviceId = projectNavigatorProjectServiceGateway.GetServiceID(projectId, refId);

                    string serviceName = "(Other)";
                    if ((serviceId.HasValue) && ((int)serviceId != -1))
                    {
                        // ... Get name
                        ServiceGateway serviceGateway = new ServiceGateway();
                        serviceGateway.LoadByServiceId((int)serviceId, Int32.Parse(hdfCompanyId.Value));
                        serviceName = serviceGateway.GetName((int)serviceId);
                    }

                    // ... Set name
                    ((Label)e.Row.FindControl("lblService")).Text = serviceName;
                }
            }
        }



        protected void grdTypeOfWorkFunctionClassification_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Validate footer if it's a fair wage
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                if (cbxFairWageApplies.Checked)
                {
                    ((CheckBox)e.Row.FindControl("cbxIsFairWageNew")).Checked = true;
                }
                else
                {
                    ((CheckBox)e.Row.FindControl("cbxIsFairWageNew")).Checked = false;
                }
            }

            // Change values if the fair wage state changes.
            if ((Session["fairWage"]).ToString() != "None")
            {
                if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Normal) || (e.Row.RowState == (DataControlRowState.Normal | DataControlRowState.Alternate))))
                {
                    if ((Session["fairWage"]).ToString() == "True")
                    {
                        ((CheckBox)e.Row.FindControl("cbxIsFairWage")).Checked = true;
                    }
                    else
                    {
                        ((CheckBox)e.Row.FindControl("cbxIsFairWage")).Checked = false;
                    }
                    
                    //Save Changes
                    int companyId = Int32.Parse(hdfCompanyId.Value);
                    int projectId = Int32.Parse(((Label)e.Row.FindControl("lblProjectID")).Text.Trim());
                    string work_ = ((Label)e.Row.FindControl("lblWork_")).Text.Trim();
                    string function_ = ((Label)e.Row.FindControl("lblFunction_")).Text.Trim();
                    int refId = Int32.Parse(((Label)e.Row.FindControl("lblRefID")).Text.Trim());
                    bool isFairWage = false; if (((CheckBox)e.Row.FindControl("cbxIsFairWage")).Checked) isFairWage = true;

                    // Update data
                    if (projectId > 0)
                    {
                        ProjectNavigatorProjectWorkFunctionFairWage model = new ProjectNavigatorProjectWorkFunctionFairWage(projectNavigatorTDS);
                        model.Update(projectId, work_, function_, refId, isFairWage, false, companyId);

                        // Store dataset
                        Session["projectNavigatorTDS"] = projectNavigatorTDS;

                        projectTypeOfWorkFunctionClassification = projectNavigatorTDS.LFS_PROJECT_WORK_FUNCTION_FAIR_WAGE;
                        Session["projectTypeOfWorkFunctionClassification"] = projectTypeOfWorkFunctionClassification;
                    }
                }
                
                if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Edit) || (e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
                {
                    if ((Session["fairWage"]).ToString() == "True")
                    {
                        ((CheckBox)e.Row.FindControl("cbxIsFairWageEdit")).Checked = true;                       
                    }
                    else
                    {
                        ((CheckBox)e.Row.FindControl("cbxIsFairWageEdit")).Checked = false;                      
                    }                    
               
                    //Save Changes
                    int companyId = Int32.Parse(hdfCompanyId.Value);
                    int projectId = Int32.Parse(((Label)e.Row.FindControl("lblProjectIDEdit")).Text.Trim());
                    string work_ = ((Label)e.Row.FindControl("lblWork_Edit")).Text.Trim();
                    string function_ = ((Label)e.Row.FindControl("lblFunction_Edit")).Text.Trim();
                    int refId = Int32.Parse(((Label)e.Row.FindControl("lblRefIDEdit")).Text.Trim());
                    bool isFairWage = false; if (((CheckBox)e.Row.FindControl("cbxIsFairWageEdit")).Checked) isFairWage = true;

                    // Update data
                    if (projectId > 0)
                    {
                        ProjectNavigatorProjectWorkFunctionFairWage model = new ProjectNavigatorProjectWorkFunctionFairWage(projectNavigatorTDS);
                        model.Update(projectId, work_, function_, refId, isFairWage, false, companyId);

                        // Store dataset
                        Session["projectNavigatorTDS"] = projectNavigatorTDS;

                        projectTypeOfWorkFunctionClassification = projectNavigatorTDS.LFS_PROJECT_WORK_FUNCTION_FAIR_WAGE;
                        Session["projectTypeOfWorkFunctionClassification"] = projectTypeOfWorkFunctionClassification;
                    }
                 }
            }
        }



        //protected void grdNotes_RowEditing(object sender, GridViewEditEventArgs e)
        //{
        //    // Notes Gridview, if the gridview is edition mode
        //    if (grdNotes.EditIndex >= 0)
        //    {
        //        grdNotes.UpdateRow(grdNotes.EditIndex, true);
        //    }
        //}



        //protected void grdServices_RowEditing(object sender, GridViewEditEventArgs e)
        //{
        //    // grdServices Gridview, if the gridview is edition mode
        //    if (grdServices.EditIndex >= 0)
        //    {
        //        grdServices.UpdateRow(grdServices.EditIndex, true);
        //    }
        //}



        protected void grdJobClassClassification_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // grdJobClassClassification Gridview, if the gridview is edition mode
            if (grdJobClassClassification.EditIndex >= 0)
            {
                grdJobClassClassification.UpdateRow(grdJobClassClassification.EditIndex, true);
            }
        }



        protected void grdTypeOfWorkFunctionClassification_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // grdTypeOfWorkFunctionClassification Gridview, if the gridview is edition mode
            if (grdTypeOfWorkFunctionClassification.EditIndex >= 0)
            {
                grdTypeOfWorkFunctionClassification.UpdateRow(grdTypeOfWorkFunctionClassification.EditIndex, true);
            }
        }



        protected void grdBudget_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // grdBudget Gridview, if the gridview is edition mode
            if (grdBudget.EditIndex >= 0)
            {
                grdBudget.UpdateRow(grdBudget.EditIndex, true);
            }
        }



        protected void grdSubcontractorsBudget_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //// grdBudget Gridview, if the gridview is edition mode
            //if (grdSubcontractorsBudget.EditIndex >= 0)
            //{
            //    grdSubcontractorsBudget.UpdateRow(grdSubcontractorsBudget.EditIndex, true);
            //}
        }



        protected void grdHotelsBudget_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //// grdBudget Gridview, if the gridview is edition mode
            //if (grdHotelsBudget.EditIndex >= 0)
            //{
            //    grdHotelsBudget.UpdateRow(grdHotelsBudget.EditIndex, true);
            //}
        }



        protected void grdBondingsBudget_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //// grdBudget Gridview, if the gridview is edition mode
            //if (grdBondingsBudget.EditIndex >= 0)
            //{
            //    grdBondingsBudget.UpdateRow(grdBondingsBudget.EditIndex, true);
            //}
        }



        protected void grdInsurancesBudget_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //// grdBudget Gridview, if the gridview is edition mode
            //if (grdInsurancesBudget.EditIndex >= 0)
            //{
            //    grdInsurancesBudget.UpdateRow(grdInsurancesBudget.EditIndex, true);
            //}
        }



        protected void grdOtherCostsBudget_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // grdBudget Gridview, if the gridview is edition mode
            if (grdOtherCostsBudget.EditIndex >= 0)
            {
                grdOtherCostsBudget.UpdateRow(grdOtherCostsBudget.EditIndex, true);
            }
        }


                
        protected void btnAssociate_Click(object sender, EventArgs e)
        {
            Session["activeTabProjects"] = "7";
            Session["dialogOpenedProjects"] = "1";
            Response.Write("<script language='javascript'> { window.open(\"./../../projects/projects/project_associate_to_category.aspx?source_page=project_notes.aspx&project_id=" + hdfProjectId.Value + "\",\"_blank\",\"toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=560, height=670\");}</script>");
        }



        //protected void btnUnassociate_Click(object sender, EventArgs e)
        //{
        //    Project project = new Project(projectTDS);
        //    project.UpdateLibraryCategoriesId(int.Parse(hdfProjectId.Value), null);

        //    UpdateDatabase();
        //    ViewState["update"] = "yes";

        //    btnUnassociate.Visible = false;
        //    btnAssociate.Visible = false;

        //    string url = "./project_edit.aspx?source_page=lm&project_id=" + hdfProjectId.Value + GetNavigatorState() + "&origin=summary&update=" + ViewState["update"] + "&data_changed=" + hdfDataChanged.Value;
        //    Response.Redirect(url);
        //}



        protected void cbxFairWageApplies_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxFairWageApplies.Checked)
            {
                Session["fairWage"] = "True";

                int companyId = Int32.Parse(hdfCompanyId.Value);
                int projectId = Int32.Parse(hdfProjectId.Value);

                TeamProjectTimeWorkFunctionConcatGateway teamProjectTimeWorkFunctionGateway = new TeamProjectTimeWorkFunctionConcatGateway();
                teamProjectTimeWorkFunctionGateway.LoadWorkFunctionConcat();

                foreach (TeamProjectTime2TDS.TEAM_PROJECT_TIME_WORK_FUNCTION_CONCATRow originalRow in (TeamProjectTime2TDS.TEAM_PROJECT_TIME_WORK_FUNCTION_CONCATDataTable)teamProjectTimeWorkFunctionGateway.Table)
                {
                    string workFunctionConcat = originalRow.WorkFunctionConcat;
                    string[] workFunction = workFunctionConcat.ToString().Trim().Split('.');
                    string work_ = workFunction[0].Trim();
                    string function_ = workFunction[1].Trim();

                    ProjectNavigatorProjectWorkFunctionFairWage model = new ProjectNavigatorProjectWorkFunctionFairWage(projectNavigatorTDS);

                    if (!model.ExistWorkFunction(work_, function_))
                    {
                        TypeOfWorkFunctionClassificationAdd(companyId, projectId, true, workFunctionConcat, work_, function_);
                    }
                }
            }
            else
            {
                Session["fairWage"] = "False";
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATION EVENTS
        //

        protected void tkrpbLeftMenu_ItemClick(object sender, RadPanelBarEventArgs e)
        {
            // Store active tab for postback
            Session["activeTabProjects"] = "0";
            Session["dialogOpenedProjects"] = "0";

            string url = "";

            switch (e.Item.Value)
            {
                case "mProjectCostingSheets":
                    this.PostPageChanges();
                    Session["lfsProjectTDS"] = projectTDS;
                    url = "./project_costing_sheets_navigator.aspx?source_page=project_edit.aspx&project_id=" + hdfProjectId.Value + "&active_tab=" + hdfActiveTab.Value + GetNavigatorState() + "&origin=" + (string)ViewState["origin"] + "&update=" + (string)ViewState["update"] + "&data_changed=" + hdfDataChanged.Value + "&state=edit";
                    break;

                case "mSections":
                    this.PostPageChanges();
                    Session["lfsProjectTDS"] = projectTDS;
                    url = "./project_sections_navigator.aspx?source_page=lm&project_id=" + hdfProjectId.Value + "&active_tab=" + hdfActiveTab.Value + GetNavigatorState() + "&origin=" + (string)ViewState["origin"] + "&update=" + (string)ViewState["update"] + "&data_changed=" + hdfDataChanged.Value + "&state=edit";
                    break;

                case "mSearch":
                    Session.Remove("lfsLibraryTDS");
                    Session.Remove("fromAttachment");
                    projectTDS.RejectChanges();
                    url = "./projects.aspx?source_page=lm";
                    break;
            }

            if (url != "") Response.Redirect(url);
        }



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
                case "mSave":
                    this.Save();
                    break;

                case "mApply":
                    this.Apply();
                    break;

                case "mCancel":
                    this.Cancel();
                    break;

                case "mPrevious":
                    // Get previous record
                    int previousId = ProjectNavigator.GetPreviousId((ProjectNavigatorTDS)Session["lfsProjectNavigatorTDS"], Int32.Parse(hdfProjectId.Value));
                    if (previousId != Int32.Parse(hdfProjectId.Value))
                    {
                        this.Apply();

                        // Redirect
                        url = "./project_edit.aspx?source_page=" + Request.QueryString["source_page"] + "&project_id=" + previousId.ToString() + "&active_tab=" + activeTab + GetNavigatorState() + "&origin=" + (string)ViewState["origin"] + "&data_changed=no&update=yes";
                    }
                    break;

                case "mNext":
                    // Get next record
                    int nextId = ProjectNavigator.GetNextId((ProjectNavigatorTDS)Session["lfsProjectNavigatorTDS"], Int32.Parse(hdfProjectId.Value));
                    if (nextId != Int32.Parse(hdfProjectId.Value))
                    {
                        this.Apply();

                        // Redirect
                        url = "./project_edit.aspx?source_page=" + Request.QueryString["source_page"] + "&project_id=" + nextId.ToString() + "&active_tab=" + activeTab + GetNavigatorState() + "&origin=" + (string)ViewState["origin"] + "&data_changed=no&update=yes";
                    }
                    break;
            }

            if (url != "") Response.Redirect(url);
        }



        

        
        // ////////////////////////////////////////////////////////////////////////
        // METHODS
        //

        public ProjectNavigatorTDS.ProjectNotesDataTable GetNotesNew()
        {
            projectNotes = (ProjectNavigatorTDS.ProjectNotesDataTable)Session["projectNotesDummy"];
            if (projectNotes == null)
            {
                projectNotes = ((ProjectNavigatorTDS)Session["projectNavigatorTDS"]).ProjectNotes;
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



        public ProjectNavigatorTDS.LFS_PROJECT_JOB_CLASS_TYPE_RATEDataTable GetJobClassClassificationNew()
        {
            projectJobClassClassification = (ProjectNavigatorTDS.LFS_PROJECT_JOB_CLASS_TYPE_RATEDataTable)Session["projectJobClassClassificationDummy"];
            if (projectJobClassClassification == null)
            {
                projectJobClassClassification = ((ProjectNavigatorTDS)Session["projectNavigatorTDS"]).LFS_PROJECT_JOB_CLASS_TYPE_RATE;
            }

            return projectJobClassClassification;
        }



        public ProjectNavigatorTDS.LFS_PROJECT_WORK_FUNCTION_FAIR_WAGEDataTable GetTypeOfWorkFunctionClassificationNew()
        {
            projectTypeOfWorkFunctionClassification = (ProjectNavigatorTDS.LFS_PROJECT_WORK_FUNCTION_FAIR_WAGEDataTable)Session["projectTypeOfWorkFunctionClassificationDummy"];
            if (projectTypeOfWorkFunctionClassification == null)
            {
                projectTypeOfWorkFunctionClassification = ((ProjectNavigatorTDS)Session["projectNavigatorTDS"]).LFS_PROJECT_WORK_FUNCTION_FAIR_WAGE;
            }

            return projectTypeOfWorkFunctionClassification;
        }



        public ProjectNavigatorTDS.ProjectWorkFunctionBudgetDataTable GetTypeOfWorkFunctionBudgetNew()
        {
            projectBudget = (ProjectNavigatorTDS.ProjectWorkFunctionBudgetDataTable)Session["projectBudgetDummy"];
            if (projectBudget == null)
            {
                projectBudget = ((ProjectNavigatorTDS)Session["projectNavigatorTDS"]).ProjectWorkFunctionBudget;
            }

            return projectBudget;
        }



        public ProjectNavigatorTDS.ProjectSubcontractorsBudgetDataTable GetSubcontractorsBudgetNew()
        {
            subcontractorsBudget = (ProjectNavigatorTDS.ProjectSubcontractorsBudgetDataTable)Session["subcontractorsBudgetDummy"];
            if (subcontractorsBudget == null)
            {
                subcontractorsBudget = ((ProjectNavigatorTDS)Session["projectNavigatorTDS"]).ProjectSubcontractorsBudget;
            }

            return subcontractorsBudget;
        }



        public ProjectNavigatorTDS.ProjectHotelsBudgetDataTable GetHotelsBudgetNew()
        {
            hotelsBudget = (ProjectNavigatorTDS.ProjectHotelsBudgetDataTable)Session["hotelsBudgetDummy"];
            if (hotelsBudget == null)
            {
                hotelsBudget = ((ProjectNavigatorTDS)Session["projectNavigatorTDS"]).ProjectHotelsBudget;
            }

            return hotelsBudget;
        }



        public ProjectNavigatorTDS.ProjectBondingsBudgetDataTable GetBondingsBudgetNew()
        {
            bondingsBudget = (ProjectNavigatorTDS.ProjectBondingsBudgetDataTable)Session["bondingsBudgetDummy"];
            if (bondingsBudget == null)
            {
                bondingsBudget = ((ProjectNavigatorTDS)Session["projectNavigatorTDS"]).ProjectBondingsBudget;
            }

            return bondingsBudget;
        }



        public ProjectNavigatorTDS.ProjectInsurancesBudgetDataTable GetInsurancesBudgetNew()
        {
            insurancesBudget = (ProjectNavigatorTDS.ProjectInsurancesBudgetDataTable)Session["insurancesBudgetDummy"];
            if (insurancesBudget == null)
            {
                insurancesBudget = ((ProjectNavigatorTDS)Session["projectNavigatorTDS"]).ProjectInsurancesBudget;
            }

            return insurancesBudget;
        }



        public ProjectNavigatorTDS.ProjectOtherCostsBudgetDataTable GetOtherCostsBudgetNew()
        {
            otherCostsBudget = (ProjectNavigatorTDS.ProjectOtherCostsBudgetDataTable)Session["otherCostsBudgetDummy"];
            if (otherCostsBudget == null)
            {
                otherCostsBudget = ((ProjectNavigatorTDS)Session["projectNavigatorTDS"]).ProjectOtherCostsBudget;
            }

            return otherCostsBudget;
        }



        public void DummyCostsNew(int ProjectID, int RefID)
        {
        }



        public void DummyNotesNew(int ProjectID, int RefID)
        {
        }



        public void DummyServiceNew(int ProjectID, int RefID)
        {
        }



        public void DummyJobClassClassificationNew(int ProjectID, string JobClassType, int RefID)
        {
        }



        public void DummyTypeOfWorkFunctionClassificationNew(int ProjectID, string Work_, string Function_, int RefID)
        {
        }



        public void DummyTypeOfWorkFunctionClassificationNew(string WorkFunction, bool IsFairWage, int ProjectID, string Work_, string Function_, int RefID)
        {
        }



        public void DummyTypeOfWorkFunctionBudgetNew(string WorkFunction, decimal Budget, int ProjectID, string Work_, string Function_, int RefID)
        {
        }



        public void DummyTypeOfWorkFunctionBudgetNew(string WorkFunction, int ProjectID, string Work_, string Function_, int RefID)
        {
        }



        public void DummyTypeOfWorkFunctionBudgetNew(int ProjectID, string Work_, string Function_, int RefID)
        {
        }



        public void DummySubcontractorsBudgetNew(int ProjectID, int SubcontractorID, int RefID)
        {
        }



        public void DummyHotelsBudgetNew(int ProjectID, int HolelID, int RefID)
        {
        }



        public void DummyBondingsBudgetNew(int ProjectID, int BondingCompanyID, int RefID)
        {
        }



        public void DummyInsurancesBudgetNew(int ProjectID, int InsuranceCompanyID, int RefID)
        {
        }



        public void DummyOtherCostsBudgetNew(int ProjectID, string Category, int RefID)
        {
        }



        //protected void AddNotesNewEmptyFix(GridView grdView)
        //{
        //    if (grdNotes.Rows.Count == 0)
        //    {
        //        int companyId = Int32.Parse(hdfCompanyId.Value);
        //        ProjectNavigatorTDS.ProjectNotesDataTable dt = new ProjectNavigatorTDS.ProjectNotesDataTable();
        //        dt.AddProjectNotesRow(-1, -1, "", DateTime.Now, -1, "", false, -1, companyId, "", "", false);
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



        //protected void AddServicesNewEmptyFix(GridView grdView)
        //{
        //    if (grdView.Rows.Count == 0)
        //    {
        //        int companyId = Int32.Parse(hdfCompanyId.Value);
        //        ProjectNavigatorTDS.ProjectServiceDataTable dt = new ProjectNavigatorTDS.ProjectServiceDataTable();
        //        dt.AddProjectServiceRow(-1, -1, -1, "", "", -1, -1, false, companyId, false, -1);
        //        Session["projectServicesDummy"] = dt;

        //        grdView.DataBind();
        //    }

        //    // Normally executes at all postbacks
        //    if (grdView.Rows.Count == 1)
        //    {
        //        ProjectNavigatorTDS.ProjectServiceDataTable dt = (ProjectNavigatorTDS.ProjectServiceDataTable)Session["projectServicesDummy"];
        //        if (dt != null)
        //        {
        //            grdView.Rows[0].Visible = false;
        //            grdView.Rows[0].Controls.Clear();
        //        }
        //    }
        //}



        protected void AddJobClassClassificationNewEmptyFix(GridView grdView)
        {
            if (grdJobClassClassification.Rows.Count == 0)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                ProjectNavigatorTDS.LFS_PROJECT_JOB_CLASS_TYPE_RATEDataTable dt = new ProjectNavigatorTDS.LFS_PROJECT_JOB_CLASS_TYPE_RATEDataTable();
                dt.AddLFS_PROJECT_JOB_CLASS_TYPE_RATERow(-1, "", 0, 0, false, companyId, false, 0);
                Session["projectJobClassClassificationDummy"] = dt;
                
                grdJobClassClassification.DataBind();
            }

            // Normally executes at all postbacks
            if (grdJobClassClassification.Rows.Count == 1)
            {
                ProjectNavigatorTDS.LFS_PROJECT_JOB_CLASS_TYPE_RATEDataTable dt = (ProjectNavigatorTDS.LFS_PROJECT_JOB_CLASS_TYPE_RATEDataTable)Session["projectJobClassClassificationDummy"];
                if (dt != null)
                {
                    grdJobClassClassification.Rows[0].Visible = false;
                    grdJobClassClassification.Rows[0].Controls.Clear();
                }
            }
        }



        protected void AddTypeOfWorkFunctionClassificationNewEmptyFix(GridView grdView)
        {
            if (grdTypeOfWorkFunctionClassification.Rows.Count == 0)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                ProjectNavigatorTDS.LFS_PROJECT_WORK_FUNCTION_FAIR_WAGEDataTable dt = new ProjectNavigatorTDS.LFS_PROJECT_WORK_FUNCTION_FAIR_WAGEDataTable();
                dt.AddLFS_PROJECT_WORK_FUNCTION_FAIR_WAGERow(-1, "", "", 0, false, false, companyId, false, "");
                Session["projectTypeOfWorkFunctionClassificationDummy"] = dt;
                
                grdTypeOfWorkFunctionClassification.DataBind();
            }

            // Normally executes at all postbacks
            if (grdTypeOfWorkFunctionClassification.Rows.Count == 1)
            {
                ProjectNavigatorTDS.LFS_PROJECT_WORK_FUNCTION_FAIR_WAGEDataTable dt = (ProjectNavigatorTDS.LFS_PROJECT_WORK_FUNCTION_FAIR_WAGEDataTable)Session["projectTypeOfWorkFunctionClassificationDummy"];
                if (dt != null)
                {
                    grdTypeOfWorkFunctionClassification.Rows[0].Visible = false;
                    grdTypeOfWorkFunctionClassification.Rows[0].Controls.Clear();
                }
            }
        }



        protected void AddTypeOfWorkFunctionBudgetNewEmptyFix(GridView grdView)
        {
            if (grdBudget.Rows.Count == 0)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                ProjectNavigatorTDS.ProjectWorkFunctionBudgetDataTable dt = new ProjectNavigatorTDS.ProjectWorkFunctionBudgetDataTable();
                dt.AddProjectWorkFunctionBudgetRow(-1, "", "", 0, 0, false, companyId, false, "", 0);
                Session["projectBudgetDummy"] = dt;

                grdBudget.DataBind();
            }

            // Normally executes at all postbacks
            if (grdBudget.Rows.Count == 1)
            {
                ProjectNavigatorTDS.ProjectWorkFunctionBudgetDataTable dt = (ProjectNavigatorTDS.ProjectWorkFunctionBudgetDataTable)Session["projectBudgetDummy"];
                if (dt != null)
                {
                    grdBudget.Rows[0].Visible = false;
                    grdBudget.Rows[0].Controls.Clear();
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



        //private void GrdNotesDeleteAttachment(int libraryFileId, int refId)
        //{
        //    // Button delete functionality
        //    if (libraryFileId != 0)
        //    {
        //        ProjectNavigatorProjectNotes projectNavigatorProjectNotes = new ProjectNavigatorProjectNotes(projectNavigatorTDS);
        //        projectNavigatorProjectNotes.UpdateLibraryFilesId(int.Parse(hdfProjectId.Value), refId, null, "", "");

        //        LibraryFilesGateway libraryFilesGateway = new LibraryFilesGateway(libraryTDS);
        //        libraryFilesGateway.DeleteByLibraryFilesId(libraryFileId);

        //        ViewState["update"] = "no";

        //        Session["lfsProjectTDS"] = projectTDS;
        //        Session["projectNavigatorTDS"] = projectNavigatorTDS;
        //        projectNotes = projectNavigatorTDS.ProjectNotes;
        //        Session["projectNotes"] = projectNavigatorTDS.ProjectNotes;
        //        Session["lfsLibraryTDS"] = libraryTDS;
                //grdNotes.DataBind();
        //    }
        //}



        //private void GrdNotesOpenAttachment(string originalFileName, string fileName)
        //{
        //    // Button download functionality
        //    if ((originalFileName != "") && (fileName != ""))
        //    {
        //        // Escape single quote
        //        originalFileName = originalFileName.Replace("'", "%27");
        //        fileName = fileName.Replace("'", "%27");

        //        string script = "<script language='javascript'>";
        //        string url = "./project_download_attachment.aspx?original_filename=" + Server.UrlEncode(originalFileName) + "&filename=" + Server.UrlEncode(fileName);
        //        script = script + string.Format("window.open('{0}', '_blank', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=0, height=0')", url);
        //        script = script + "</script>";
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "DownloadAttachment", script, false);
        //    }
        //}



        //private void GrdNotesAddAttachment(int? refId, string subject)
        //{
        //    Save2();

        //    // Escape single quote
        //    subject = subject.Replace("'", "%27");

        //    if (refId.HasValue)
        //    {
        //        if (ViewState["libraryCategoriesId"] != null)
        //        {
        //            string script = "<script language='javascript'>";
        //            string url = "./project_add_attachment.aspx?source_page=project_notes.aspx&subject=" + Server.UrlEncode(subject) + "&refId=" + refId.ToString() + "&project_id=" + hdfProjectId.Value + "&library_categories_id=" + Int32.Parse(ViewState["libraryCategoriesId"].ToString()) + "&data_changed=" + hdfDataChanged.Value;
        //            script = script + string.Format("window.open('{0}', '_blank', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=510, height=270')", url);
        //            script = script + "</script>";
        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "Notes", script, false);
        //        }
        //    }
        //    else
        //    {
        //        ProjectNavigatorProjectNotes model = new ProjectNavigatorProjectNotes(projectNavigatorTDS);
        //        refId = model.GetLastRefId();                

        //        if (ViewState["libraryCategoriesId"] != null)
        //        {
        //            string script = "<script language='javascript'>";
        //            string url = "./project_add_attachment.aspx?source_page=project_notes.aspx&subject=" + Server.UrlEncode(subject) + "&refId=" + refId.ToString() + "&project_id=" + hdfProjectId.Value + "&library_categories_id=" + Int32.Parse(ViewState["libraryCategoriesId"].ToString()) + "&data_changed=" + hdfDataChanged.Value;
        //            script = script + string.Format("window.open('{0}', '_blank', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=510, height=270')", url);
        //            script = script + "</script>";
        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "Notes", script, false);
        //        }
        //    }            
        //}



        //private void GrdNotesAdd()
        //{
        //    if (ValidateNotesFooter())
        //    {
        //        Page.Validate("notesDataAdd");
        //        if (Page.IsValid)
        //        {
        //            int companyId = Int32.Parse(hdfCompanyId.Value);
        //            int projectId = Int32.Parse(hdfProjectId.Value);
        //            string newSubject = ((TextBox)grdNotes.FooterRow.FindControl("tbxNoteSubjectNew")).Text.Trim();
        //            int loginId = Convert.ToInt32(Session["loginID"]);
        //            DateTime dateTime = DateTime.Now;
        //            string newNote = ((TextBox)grdNotes.FooterRow.FindControl("tbxNoteNoteNew")).Text.Trim();
        //            bool deleted = false;
        //            bool inNoteDatabase = false;

        //            int? libraryFilesId = null;
        //            string fileName = ((Label)grdNotes.FooterRow.FindControl("lblFileNameNoteAttachmentNew")).Text.Trim();
        //            if (fileName != "")
        //            {
        //                LibraryFilesGateway libraryFilesGateway = new LibraryFilesGateway();
        //                libraryFilesId = libraryFilesGateway.GetlibraryFilesId(fileName);
        //            }

        //            ProjectNavigatorProjectNotes model = new ProjectNavigatorProjectNotes(projectNavigatorTDS);
        //            model.Insert(projectId, newSubject, dateTime, loginId, newNote, deleted, libraryFilesId, companyId, inNoteDatabase);

        //            Session.Remove("projectNotesDummy");
        //            Session["projectNavigatorTDS"] = projectNavigatorTDS;

        //            grdNotes.DataBind();
        //            grdNotes.PageIndex = grdNotes.PageCount - 1;
        //        }
        //    }
        //}



        private void GrdJobClassClassificationAdd()
        {
            Page.Validate("jobClassClassificationDataAdd");
            if (Page.IsValid)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                int projectId = Int32.Parse(hdfProjectId.Value);
                string jobClassType = ((DropDownList)grdJobClassClassification.FooterRow.FindControl("ddlJobClassNew")).SelectedValue;
                decimal rate = decimal.Parse(((TextBox)grdJobClassClassification.FooterRow.FindControl("tbxRateNew")).Text);
                decimal fringeRate = decimal.Parse(((TextBox)grdJobClassClassification.FooterRow.FindControl("tbxFringeRateNew")).Text);
                
                ProjectNavigatorProjectJobClassTypeRate model = new ProjectNavigatorProjectJobClassTypeRate(projectNavigatorTDS);
                model.Insert(projectId, jobClassType, rate, false, companyId, false, fringeRate);

                Session.Remove("projectJobClassClassificationDummy");
                Session["projectNavigatorTDS"] = projectNavigatorTDS;

                projectJobClassClassification = projectNavigatorTDS.LFS_PROJECT_JOB_CLASS_TYPE_RATE;
                Session["projectJobClassClassification"] = projectJobClassClassification;

                grdJobClassClassification.DataBind();
            }
        }



        private void GrdTypeOfWorkFunctionClassificationAdd()
        {
            // Cancel fairWage update
            Session["fairWage"] = "None";

            // New Values
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int projectId = Int32.Parse(hdfProjectId.Value);
            bool isFairWage = false; if (((CheckBox)grdTypeOfWorkFunctionClassification.FooterRow.FindControl("cbxIsFairWageNew")).Checked) isFairWage = true;
            string workFunctionConcat = ((DropDownList)grdTypeOfWorkFunctionClassification.FooterRow.FindControl("ddlWorkFunctionNew")).SelectedValue;

            string[] workFunction = workFunctionConcat.ToString().Trim().Split('.');
            string work_ = workFunction[0].Trim();
            string function_ = workFunction[1].Trim();

            // Add new values
            TypeOfWorkFunctionClassificationAdd(companyId, projectId, isFairWage, workFunctionConcat, work_, function_);

            grdTypeOfWorkFunctionClassification.DataBind();
        }



        private void TypeOfWorkFunctionClassificationAdd(int companyId, int projectId, bool isFairWage, string workFunctionConcat, string work_, string function_)
        {
            ProjectNavigatorProjectWorkFunctionFairWage model = new ProjectNavigatorProjectWorkFunctionFairWage(projectNavigatorTDS);
            model.Insert(projectId, work_, function_, isFairWage, false, companyId, false, workFunctionConcat);

            Session.Remove("projectTypeOfWorkFunctionClassificationDummy");
            Session["projectNavigatorTDS"] = projectNavigatorTDS;

            projectTypeOfWorkFunctionClassification = projectNavigatorTDS.LFS_PROJECT_WORK_FUNCTION_FAIR_WAGE;
            Session["projectTypeOfWorkFunctionClassification"] = projectTypeOfWorkFunctionClassification;           
        }



        private void GrdTypeOfWorkFunctionBudgetAdd()
        {
            // New Values
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int projectId = Int32.Parse(hdfProjectId.Value);
            decimal budget = decimal.Parse(((TextBox)grdBudget.FooterRow.FindControl("tbxBudgetNew")).Text);
            decimal budget_ = decimal.Parse(((TextBox)grdBudget.FooterRow.FindControl("tbxBudget_New")).Text);
            string workFunctionConcat = ((DropDownList)grdBudget.FooterRow.FindControl("ddlWorkFunctionNew")).SelectedValue;

            string[] workFunction = workFunctionConcat.ToString().Trim().Split('.');
            string work_ = workFunction[0].Trim();
            string function_ = workFunction[1].Trim();

            // Add new values
            TypeOfWorkFunctionBudgetAdd(companyId, projectId, budget, workFunctionConcat, work_, function_, budget_);

            grdBudget.DataBind();

            CalculateTotalBudget();
        }



        private void GrdSubcontractorsBudgetAdd()
        {
            //Page.Validate("SubcontractorsBudgetAdd");
            //if (Page.IsValid)
            //{
            //    // New Values
            //    int companyId = Int32.Parse(hdfCompanyId.Value);
            //    int projectId = Int32.Parse(hdfProjectId.Value);
            //    decimal budget = decimal.Parse(((TextBox)grdSubcontractorsBudget.FooterRow.FindControl("tbxBudgetNew")).Text);
            //    int subcontractorId = Int32.Parse(((DropDownList)grdSubcontractorsBudget.FooterRow.FindControl("ddlSubcontractorNew")).SelectedValue);
            //    string subcontractor = ((DropDownList)grdSubcontractorsBudget.FooterRow.FindControl("ddlSubcontractorNew")).SelectedItem.Text;

            //    ProjectNavigatorProjectSubcontractorsBudget model = new ProjectNavigatorProjectSubcontractorsBudget(projectNavigatorTDS);
            //    model.Insert(projectId, subcontractorId, budget, false, companyId, false, subcontractor);

            //    Session.Remove("subcontractorsBudgetDummy");
            //    Session["projectNavigatorTDS"] = projectNavigatorTDS;

            //    subcontractorsBudget = projectNavigatorTDS.ProjectSubcontractorsBudget;
            //    Session["subcontractorsBudget"] = subcontractorsBudget;

            //    grdSubcontractorsBudget.DataBind();
            //}
        }



        private void GrdHotelsBudgetAdd()
        {
            //Page.Validate("HotelsBudgetAdd");
            //if (Page.IsValid)
            //{
            //    // New Values
            //    int companyId = Int32.Parse(hdfCompanyId.Value);
            //    int projectId = Int32.Parse(hdfProjectId.Value);
            //    decimal budget = decimal.Parse(((TextBox)grdHotelsBudget.FooterRow.FindControl("tbxBudgetNew")).Text);
            //    int hotelId = Int32.Parse(((DropDownList)grdHotelsBudget.FooterRow.FindControl("ddlHotelNew")).SelectedValue);
            //    string hotel = ((DropDownList)grdHotelsBudget.FooterRow.FindControl("ddlHotelNew")).SelectedItem.Text;

            //    ProjectNavigatorProjectHotelsBudget model = new ProjectNavigatorProjectHotelsBudget(projectNavigatorTDS);
            //    model.Insert(projectId, hotelId, budget, false, companyId, false, hotel);

            //    Session.Remove("hotelsBudgetDummy");
            //    Session["projectNavigatorTDS"] = projectNavigatorTDS;

            //    hotelsBudget = projectNavigatorTDS.ProjectHotelsBudget;
            //    Session["hotelsBudget"] = hotelsBudget;

            //    grdHotelsBudget.DataBind();
            //}
        }



        private void GrdBondingsBudgetAdd()
        {
            //Page.Validate("BondingsBudgetAdd");
            //if (Page.IsValid)
            //{
            //     New Values
            //    int companyId = Int32.Parse(hdfCompanyId.Value);
            //    int projectId = Int32.Parse(hdfProjectId.Value);
            //    decimal budget = decimal.Parse(((TextBox)grdBondingsBudget.FooterRow.FindControl("tbxBudgetNew")).Text);
            //    int bondingId = Int32.Parse(((DropDownList)grdBondingsBudget.FooterRow.FindControl("ddlBondingNew")).SelectedValue);
            //    string bonding = ((DropDownList)grdBondingsBudget.FooterRow.FindControl("ddlBondingNew")).SelectedItem.Text;

            //    ProjectNavigatorProjectBondingsBudget model = new ProjectNavigatorProjectBondingsBudget(projectNavigatorTDS);
            //    model.Insert(projectId, bondingId, budget, false, companyId, false, bonding);

            //    Session.Remove("bondingsBudgetDummy");
            //    Session["projectNavigatorTDS"] = projectNavigatorTDS;

            //    bondingsBudget = projectNavigatorTDS.ProjectBondingsBudget;
            //    Session["bondingsBudget"] = bondingsBudget;

            //    grdBondingsBudget.DataBind();
            //}
        }



        private void GrdInsurancesBudgetAdd()
        {
            //Page.Validate("InsurancesBudgetAdd");
            //if (Page.IsValid)
            //{
            //    // New Values
            //    int companyId = Int32.Parse(hdfCompanyId.Value);
            //    int projectId = Int32.Parse(hdfProjectId.Value);
            //    decimal budget = decimal.Parse(((TextBox)grdInsurancesBudget.FooterRow.FindControl("tbxBudgetNew")).Text);
            //    int insuranceId = Int32.Parse(((DropDownList)grdInsurancesBudget.FooterRow.FindControl("ddlInsuranceNew")).SelectedValue);
            //    string insurance = ((DropDownList)grdInsurancesBudget.FooterRow.FindControl("ddlInsuranceNew")).SelectedItem.Text;

            //    ProjectNavigatorProjectInsurancesBudget model = new ProjectNavigatorProjectInsurancesBudget(projectNavigatorTDS);
            //    model.Insert(projectId, insuranceId, budget, false, companyId, false, insurance);

            //    Session.Remove("insurancesBudgetDummy");
            //    Session["projectNavigatorTDS"] = projectNavigatorTDS;

            //    insurancesBudget = projectNavigatorTDS.ProjectInsurancesBudget;
            //    Session["insurancesBudget"] = insurancesBudget;

            //    grdInsurancesBudget.DataBind();
            //}
        }



        private void GrdOtherCostsBudgetAdd()
        {
            Page.Validate("OtherCostsBudgetAdd");
            if (Page.IsValid)
            {
                // New Values
                int companyId = Int32.Parse(hdfCompanyId.Value);
                int projectId = Int32.Parse(hdfProjectId.Value);
                decimal budget = decimal.Parse(((TextBox)grdOtherCostsBudget.FooterRow.FindControl("tbxBudgetNew")).Text);
                string category = ((DropDownList)grdOtherCostsBudget.FooterRow.FindControl("ddlCategoryNew")).SelectedItem.Text;

                ProjectNavigatorProjectOtherCostsBudget model = new ProjectNavigatorProjectOtherCostsBudget(projectNavigatorTDS);
                model.Insert(projectId, category, budget, false, companyId, false);

                Session.Remove("otherCostsBudgetDummy");
                Session["projectNavigatorTDS"] = projectNavigatorTDS;

                otherCostsBudget = projectNavigatorTDS.ProjectOtherCostsBudget;
                Session["otherCostsBudget"] = otherCostsBudget;

                grdOtherCostsBudget.DataBind();

                CalculateTotalBudget();
            }
        }



        private void TypeOfWorkFunctionBudgetAdd(int companyId, int projectId, decimal budget, string workFunctionConcat, string work_, string function_, decimal budget_)
        {
            ProjectNavigatorProjectWorkFunctionBudget model = new ProjectNavigatorProjectWorkFunctionBudget(projectNavigatorTDS);
            model.Insert(projectId, work_, function_, budget, false, companyId, false, workFunctionConcat, budget_);

            Session.Remove("projectBudgetDummy");
            Session["projectNavigatorTDS"] = projectNavigatorTDS;

            projectBudget = projectNavigatorTDS.ProjectWorkFunctionBudget;
            Session["projectBudget"] = projectBudget;
        }



        //private bool ValidateNotesFooter()
        //{
        //    string subject = ((TextBox)grdNotes.FooterRow.FindControl("tbxNoteSubjectNew")).Text.Trim();
        //    string note = ((TextBox)grdNotes.FooterRow.FindControl("tbxNoteNoteNew")).Text.Trim();
        //    string noteAttachment = ((TextBox)grdNotes.FooterRow.FindControl("tbxNoteAttachmentNew")).Text.Trim();

        //    if ((subject != "") || (note != "") || (noteAttachment != ""))
        //    {
        //        return true;
        //    }

        //    return false;
        //}



        //private void GrdServicesAdd()
        //{
        //    if (ValidateServicesFooter())
        //    {
        //        Page.Validate("serviceDataAdd");
        //        if (Page.IsValid)
        //        {
        //            int companyId = Int32.Parse(hdfCompanyId.Value);
        //            int projectId = Int32.Parse(hdfProjectId.Value);

        //            int? serviceId = null;
        //            if (((DropDownList)grdServices.FooterRow.FindControl("ddlServiceFooter")).SelectedValue != "-1")
        //            {
        //                serviceId = int.Parse(((DropDownList)grdServices.FooterRow.FindControl("ddlServiceFooter")).SelectedValue);
        //            }

        //            string description = ((TextBox)grdServices.FooterRow.FindControl("tbxDescriptionFooter")).Text.Trim();

        //            int quantity = 0;
        //            if (((TextBox)grdServices.FooterRow.FindControl("tbxQuantityFooter")).Text.Trim() != "")
        //            {
        //                quantity = int.Parse(((TextBox)grdServices.FooterRow.FindControl("tbxQuantityFooter")).Text.Trim());
        //            }

        //            string averageSize = ((TextBox)grdServices.FooterRow.FindControl("tbxAverageSizeFooter")).Text.Trim();

        //            decimal? averagePrice = 0.00M;
        //            decimal total = 0.00M;
        //            if (((TextBox)grdServices.FooterRow.FindControl("tbxAveragePriceFooter")).Text.Trim() != "")
        //            {
        //                averagePrice = decimal.Parse(((TextBox)grdServices.FooterRow.FindControl("tbxAveragePriceFooter")).Text.Trim());
        //                total = decimal.Round(((decimal)averagePrice * quantity), 2);
        //            }                    

        //            bool deleted = false;
        //            bool inDatabase = false;

        //            ProjectNavigatorProjectService model = new ProjectNavigatorProjectService(projectNavigatorTDS);
        //            model.Insert(projectId, serviceId, description, averageSize, averagePrice, quantity, deleted, companyId, inDatabase, total);

        //            Session.Remove("projectServicesDummy");
        //            Session["projectNavigatorTDS"] = projectNavigatorTDS;
        //            projectServices = projectNavigatorTDS.ProjectService;
        //            Session["projectServices"] = projectServices;

        //            grdServices.DataBind();
        //            grdServices.PageIndex = grdServices.PageCount - 1;

        //            // ... Recalc total cost
        //            tbxTotalCost.Text = Decimal.Round(model.GetTotalCost(), 2).ToString();
        //        }
        //    }
        //}



        //private bool ValidateServicesFooter()
        //{
        //    string description = ((TextBox)grdServices.FooterRow.FindControl("tbxDescriptionFooter")).Text.Trim();
        //    string quantity = ((TextBox)grdServices.FooterRow.FindControl("tbxQuantityFooter")).Text.Trim();
        //    string averageSize = ((TextBox)grdServices.FooterRow.FindControl("tbxAverageSizeFooter")).Text.Trim();
        //    string averagePrice = ((TextBox)grdServices.FooterRow.FindControl("tbxAveragePriceFooter")).Text.Trim();
        //    string serviceId = ((DropDownList)grdServices.FooterRow.FindControl("ddlServiceFooter")).SelectedValue.ToString().Trim();

        //    if ((quantity != "") || (description != "") || (averageSize != "") || (averagePrice != ""))
        //    {
        //        return true;
        //    }

        //    return false;
        //}

                
        
        protected int? GetEngineeringFirmId(object value)
        {
            if (value != DBNull.Value)
            {
                int companyId = Int32.Parse(Session["companyID"].ToString());
                CompaniesGateway companiesGateway = new CompaniesGateway();
                companiesGateway.LoadAllByCompaniesId((int)value, companyId);

                bool deleted = companiesGateway.GetDeleted((int)value);
                if (deleted)
                {
                    return null;
                }
                else
                {
                    return Int32.Parse(value.ToString());
                }
            }
            else
            {
                return null;
            }
        }



        protected int GetSubContratorID(object value)
        {
            if (value != DBNull.Value)
            {
                int companyId = Int32.Parse(Session["companyID"].ToString());
                CompaniesGateway companiesGateway = new CompaniesGateway();
                companiesGateway.LoadAllByCompaniesId((int)value, companyId);

                bool deleted = companiesGateway.GetDeleted((int)value);
                if (deleted)
                {
                    return -1;
                }
                else
                {
                    return Int32.Parse(value.ToString());
                }
            }
            else
            {
                return -1;
            }
        }



        private string GetFullCategoryName(int libraryCategoryId)
        {
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

                    int companyId = Int32.Parse(hdfCompanyId.Value);
                    LibraryCategoriesGateway libraryCategoriesGateway = new LibraryCategoriesGateway();
                    libraryCategoriesGateway.LoadAllByLibraryCategoriesId(libraryArray[index], companyId);
                    fullCategoryName = fullCategoryName + libraryCategoriesGateway.GetCategoryName(libraryArray[index]);

                }
            }

            return fullCategoryName;
        }



        private int[] GetDeepParent(int currentId, int deep, int maxDeep, int[] currentLibraryArray)
        {
            int[] libraryArray = currentLibraryArray;
            ViewState["currentmaxDeep"] = maxDeep;

            int companyId = Int32.Parse(hdfCompanyId.Value);
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
            // Register content variables
            string contentVariables = "";
            contentVariables += "var hdfBeforeUnloadOrigenId = '" + hdfBeforeUnloadOrigen.ClientID + "';";
            contentVariables += "var hdfProjectIdId = '" + hdfProjectId.ClientID + "';";
            contentVariables += "var hdfClientIdId = '" + hdfClientId.ClientID + "';";
            contentVariables += "var hdfCompanyIdId = '" + hdfCompanyId.ClientID + "';";
            contentVariables += "var ddlClientPrimaryContactIdId = '" + ddlClientPrimaryContactId.ClientID + "';";
            contentVariables += "var ddlClientSecondaryContactIdId = '" + ddlClientSecondaryContactId.ClientID + "';";
            contentVariables += "var hdfActiveTabId = '" + hdfActiveTab.ClientID + "';";
            //contentVariables += "var grdServicesId = '" + grdServices.UniqueID + "';";
            //contentVariables += "var ddlEngineerIdId = '" + ddlEngineerId.ClientID + "';";
            //contentVariables += "var tbxCategoryAssociatedId = '" + tbxCategoryAssocited.ClientID + "';";
            contentVariables += "var tkrmTopId = '" + tkrmTop.ClientID + "';"; 

            // Publishing body's OnKeyDown event 
            HtmlGenericControl bodyUnload = (HtmlGenericControl)Page.Master.FindControl("myBody");
            bodyUnload.Attributes.Add("OnKeyDown", "OnKeyDown(event);");

            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode1", "./project_edit.js");
        }



        private void StoreNavigatorState()
        {
            ViewState["navigatorState"] = "&search_projectnumber=" + Request.QueryString["search_projectnumber"] + "&search_projectname=" + Request.QueryString["search_projectname"] + "&search_client=" + Request.QueryString["search_client"] + "&search_type=" + Request.QueryString["search_type"] + "&search_state=" + Request.QueryString["search_state"] + "&search_country=" + Request.QueryString["search_country"];
        }



        private string GetNavigatorState()
        {
            return (string)ViewState["navigatorState"];
        }



        private void Save()
        {
            // Validate data
            bool validData = false;

            Page.Validate("projectInformation");
            if (Page.IsValid)
            {
                validData = true;

                Page.Validate("salesBilingPricingData"); if (!Page.IsValid) validData = false;
                Page.Validate("costingUpdatesData"); if (!Page.IsValid) validData = false;
                Page.Validate("termsPOData"); if (!Page.IsValid) validData = false;
                Page.Validate("costExceptionsData"); if (!Page.IsValid) validData = false;
                //Page.Validate("budgetData"); if (!Page.IsValid) validData = false; 
                //TODO

                //// ... Validate notes tab
                //if (ValidateNotesFooter())
                //{
                //    Page.Validate("notesDataAdd");
                //    if (!Page.IsValid) validData = false;
                //}

                //Page.Validate("notesDataEdit");
                //if (!Page.IsValid) validData = false;

                //// ... Validate service grid
                //if (ValidateServicesFooter())
                //{
                //    Page.Validate("serviceDataAdd");
                //    if (!Page.IsValid) validData = false;
                //}

                //Page.Validate("serviceDataEdit");
                //if (!Page.IsValid) validData = false;
            }

            if (validData)
            {
                //// Notes grid, if the gridview is edition mode
                //if (grdNotes.EditIndex >= 0)
                //{
                //    grdNotes.UpdateRow(grdNotes.EditIndex, true);
                //}

                //// Service grid, if the gridview is edition mode
                //if (grdServices.EditIndex >= 0)
                //{
                //    grdServices.UpdateRow(grdServices.EditIndex, true);
                //}

                //// Save grids data
                //GrdNotesAdd();
                //GrdServicesAdd();

                // Save data
                PostPageChanges();
                UpdateDatabase();

                ViewState["update"] = "yes";

                string url = null;

                // If coming from 
                // ... projects2.aspx
                if (Request.QueryString["origin"] == "navigator")
                {
                    url = "./projects2.aspx?source_page=project_edit.aspx&project_id=" + hdfProjectId.Value + GetNavigatorState() + "&update=yes";
                }

                // ... project_summary.aspx
                if (Request.QueryString["origin"] == "summary")
                {
                    url = "./project_summary.aspx?source_page=project_edit.aspx&project_id=" + hdfProjectId.Value + "&active_tab=" + hdfActiveTab.Value + GetNavigatorState() + "&update=yes";
                }

                Response.Redirect(url);
            }
        }



        private void Save2()
        {
            //// Notes grid, if the gridview is edition mode
            //if (grdNotes.EditIndex >= 0)
            //{
            //    grdNotes.UpdateRow(grdNotes.EditIndex, true);
            //}

            //// Save notes data
            //GrdNotesAdd();

            ViewState["update"] = "no";

            // Save data
            PostPageChanges();

            Session["lfsProjectTDS"] = projectTDS;
            Session["projectNavigatorTDS"] = projectNavigatorTDS;
            Session["lfsLibraryTDS"] = libraryTDS;
        }



        private void Apply()
        {
            // Validate data
            bool validData = false;

            Page.Validate("projectInformation");
            if (Page.IsValid)
            {
                validData = true;

                Page.Validate("salesBilingPricingData"); if (!Page.IsValid)  validData = false;
                Page.Validate("costingUpdatesData"); if (!Page.IsValid)   validData = false;
                Page.Validate("termsPOData"); if (!Page.IsValid)  validData = false;
                Page.Validate("costExceptionsData"); if (!Page.IsValid) validData = false;
                //Page.Validate("budgetData"); if (!Page.IsValid) validData = false;
                //TODO

                //// ... Validate notes tab
                //if (ValidateNotesFooter())
                //{
                //    Page.Validate("notesDataAdd");
                //    if (!Page.IsValid) validData = false;                    
                //}

                //Page.Validate("notesDataEdit");
                //if (!Page.IsValid) validData = false;

                //// ... Validate service grid
                //if (ValidateServicesFooter())
                //{
                //    Page.Validate("serviceDataAdd");
                //    if (!Page.IsValid) validData = false;
                //}

                //Page.Validate("serviceDataEdit");
                //if (!Page.IsValid) validData = false;
            }

            if (validData)
            {
                //// Notes grid, if the gridview is edition mode
                //if (grdNotes.EditIndex >= 0)
                //{
                //    grdNotes.UpdateRow(grdNotes.EditIndex, true);
                //}

                //// Service grid, if the gridview is edition mode
                //if (grdServices.EditIndex >= 0)
                //{
                //    grdServices.UpdateRow(grdServices.EditIndex, true);
                //}

                //// Save grids data
                //GrdNotesAdd();
                //GrdServicesAdd();

                // Save data
                PostPageChanges();
                UpdateDatabase();
                ViewState["update"] = "yes";
            }
        }



        private void Cancel()
        {
            projectTDS.RejectChanges();
            projectNavigatorTDS.RejectChanges();

            Session["lfsProjectTDS"] = projectTDS;
            Session["projectNavigatorTDS"] = projectNavigatorTDS;
            Session["projectNotes"] = projectNavigatorTDS.ProjectNotes;
            Session["projectServices"] = projectNavigatorTDS.ProjectService;
            Session["projectTypeOfWorkFunctionClassification"] = projectNavigatorTDS.LFS_PROJECT_WORK_FUNCTION_FAIR_WAGE;
            Session["projectJobClassClassification"] = projectNavigatorTDS.LFS_PROJECT_JOB_CLASS_TYPE_RATE;
            Session["projectBudget"] = projectNavigatorTDS.ProjectWorkFunctionBudget;
            Session["subcontractorsBudget"] = projectNavigatorTDS.ProjectSubcontractorsBudget;
            Session["hotelsBudget"] = projectNavigatorTDS.ProjectHotelsBudget;
            Session["bondingsBudget"] = projectNavigatorTDS.ProjectBondingsBudget;
            Session["insurancesBudget"] = projectNavigatorTDS.ProjectInsurancesBudget;
            Session["otherCostsBudget"] = projectNavigatorTDS.ProjectOtherCostsBudget;

            string url = null;

            // If coming from 
            // ... projects2.aspx
            if (Request.QueryString["origin"] == "navigator")
            {
                url = "./projects2.aspx?source_page=project_edit.aspx&project_id=" + hdfProjectId.Value + GetNavigatorState() + "&update=" + ViewState["update"];
            }

            // ... project_summary.aspx
            if (Request.QueryString["origin"] == "summary")
            {
                url = "./project_summary.aspx?source_page=project_edit.aspx&project_id=" + hdfProjectId.Value + "&active_tab=" + hdfActiveTab.Value + GetNavigatorState() + "&update=" + ViewState["update"];
            }

            Response.Redirect(url);
        }



        private void PostPageChanges()
        {
            ProjectGateway projectGateway = new ProjectGateway(projectTDS);
            int projectId = int.Parse(hdfProjectId.Value);

            // General Data
            Int64 countryId = projectGateway.GetCountryID(projectId);
            int officeId = projectGateway.GetOfficeID(projectId);
            Int64? provinceId = projectGateway.GetProvinceID(projectId);
            Int64? cityId = projectGateway.GetCityID(projectId);
            Int64? countyId = projectGateway.GetCountyID(projectId);
            int? projectLeadId = null; if ((ddlProjectLeadId.SelectedValue != "-1") && (ddlProjectLeadId.SelectedIndex > -1)) projectLeadId = int.Parse(ddlProjectLeadId.SelectedValue);
            int salesmanId = int.Parse(ddlSalesmanId.SelectedValue);
            string projectType = projectGateway.GetProjectType(projectId);
            string projectState = projectGateway.GetProjectState(projectId);
            string name = tbxName.Text.Trim();
            string description = tbxDescription.Text.Trim();
            DateTime? proposalDate = null; if (tkrdpProposalDate.SelectedDate.HasValue) proposalDate = tkrdpProposalDate.SelectedDate.Value;
            DateTime? startDate = null; if (tkrdpStartDate.SelectedDate.HasValue) startDate = tkrdpStartDate.SelectedDate.Value;
            DateTime? endDate = null; if (tkrdpEndDate.SelectedDate.HasValue) endDate = tkrdpEndDate.SelectedDate.Value;
            int clientId = projectGateway.GetClientID(projectId);
            string clientProjectNumber = tbxClientProjectNumber.Text.Trim();
            int? clientPrimaryContactId = null; if ((ddlClientPrimaryContactId.SelectedValue != "-1") && (ddlClientPrimaryContactId.SelectedIndex > -1)) clientPrimaryContactId = int.Parse(ddlClientPrimaryContactId.SelectedValue);
            int? clientSecondaryContactId = null; if ((ddlClientSecondaryContactId.SelectedValue != "-1") && (ddlClientSecondaryContactId.SelectedIndex > -1)) clientSecondaryContactId = int.Parse(ddlClientSecondaryContactId.SelectedValue);
            bool deleted = projectGateway.GetDeleted(projectId);
            int? libraryCategoriesId = null; if (projectGateway.GetLibraryCategoriesId(projectId).HasValue) libraryCategoriesId = (int)projectGateway.GetLibraryCategoriesId(projectId);
            bool fairWageApplies = cbxFairWageApplies.Checked;

            // ... Update Project Number
            Project project = new Project(projectTDS);
            string projectNumber;

            if (projectGateway.GetOriginalProjectID(projectId) == null)
            {
                projectNumber = project.UpdateProjectNumber(projectId, salesmanId);
            }
            else
            {
                projectNumber = projectGateway.GetProjectNumber(projectId);
            }

            // ... Update Project
            project.Update(projectId, countryId, officeId, projectLeadId, salesmanId, projectNumber, projectType, projectState, name, description, proposalDate, startDate, endDate, clientId, clientProjectNumber, clientPrimaryContactId, clientSecondaryContactId, deleted, libraryCategoriesId, provinceId, cityId, Int32.Parse(hdfCompanyId.Value.Trim()), countyId, fairWageApplies);
            
            // ... If project type is Ballpark update Bill Price and Bill Money
            if (projectType == "Ballpark")
            {
                ProjectSaleBillingPricing projectSaleBillingPricingForGeneralData = new ProjectSaleBillingPricing(projectTDS);

                decimal? billPrice = null; if (tbxBillPrice.Text != "") billPrice = Convert.ToDecimal(tbxBillPrice.Text);
                string billMoney = ddlBillMoney.SelectedValue;

                projectSaleBillingPricingForGeneralData.UpdateBillPrice(projectId, billPrice, billMoney);
            }

            if ((projectType != "Ballpark") && (projectType != "Internal"))
            {
                // Sale/Billing/Pricing
                //bool saleBidProject = cbxSaleBidProject.Checked;
                //bool saleRFP = cbxSaleRFP.Checked;
                //bool saleSoleSource = cbxSaleSoleSource.Checked;
                //bool saleTermContract = cbxSaleTermContract.Checked;
                //string saleTermContractDetail = tbxSaleTermContractDetail.Text.Trim();
                //bool saleOther = cbxSaleOther.Checked;
                //string saleOtherDetail = tbxSaleOtherDetail.Text.Trim();
                //int? saleGettingJob = null; if (tbxSaleGettingJob.Text.Trim() != "") saleGettingJob = int.Parse(tbxSaleGettingJob.Text.Trim());
                decimal? billPriceSaleBillingPricing = null; if (tbxBillPriceSaleBillingPricing.Text.Trim() != "") billPriceSaleBillingPricing = decimal.Parse(tbxBillPriceSaleBillingPricing.Text.Trim());
                string billMoneySaleBillingPricing = ddlBillMoneySaleBillingPricing.SelectedValue;
                decimal? billSubcontractorAmount = null; if (tbxBillSubcontractorAmount.Text.Trim() != "") billSubcontractorAmount = decimal.Parse(tbxBillSubcontractorAmount.Text.Trim());
                //string billBidHardDollar = tbxBillBidHardDollar.Text.Trim();
                //bool billPerUnit = cbxBillPerUnit.Checked;
                //bool billHourly = cbxBillHourly.Checked;
                //string billExpectExtras = tbxBillExpectExtras.Text.Trim();
                //bool chargesWater = cbxChargesWater.Checked;
                //decimal? chargesWaterAmount = null; if (tbxChargesWaterAmount.Text.Trim() != "") chargesWaterAmount = decimal.Parse(tbxChargesWaterAmount.Text.Trim());
                //bool chargesDisposal = cbxChargesDisposal.Checked;
                //decimal? chargesDisposalAmount = null; if (tbxChargesDisposalAmount.Text.Trim() != "") chargesDisposalAmount = decimal.Parse(tbxChargesDisposalAmount.Text.Trim());
                
                // ... Update Sale/Billing/Pricing
                ProjectSaleBillingPricing projectSaleBillingPricing = new ProjectSaleBillingPricing(projectTDS);
                //projectSaleBillingPricing.Update(projectId, saleBidProject, saleRFP, saleSoleSource, saleTermContract, saleTermContractDetail, saleOther, saleOtherDetail, saleGettingJob, billPriceSaleBillingPricing, billMoneySaleBillingPricing, billBidHardDollar, billPerUnit, billHourly, billExpectExtras, billSubcontractorAmount, chargesWater, chargesWaterAmount, chargesDisposal, chargesDisposalAmount, Int32.Parse(hdfCompanyId.Value.Trim()));
                projectSaleBillingPricing.Update(projectId, billPriceSaleBillingPricing, billMoneySaleBillingPricing, billSubcontractorAmount, Int32.Parse(hdfCompanyId.Value.Trim()));

                // ... Update job info 
                bool typeOfWorkMhRehab = ckbxMhRehab.Checked;
                bool typeOfWorkJunctionLining = ckbxJunctionLining.Checked;
                bool typeOfWorkProjectManagement = ckbxProjectManagement.Checked;
                bool typeOfWorkFullLenghtLining = ckbxFullLengthLining.Checked;
                bool typeOfWorkPointRepairs = ckbxPointRepairs.Checked;
                bool typeOfWorkRehabAssessment = ckbxRehabAssessment.Checked;
                bool typeOfWorkGrout = ckbxGrout.Checked;
                bool typeOfWorkOther = ckbxOther.Checked;
                bool agreement = cbxSubcontractorAgreement.Checked;
                bool writtenQuote = cbxSubcontractorWrittenQuote.Checked;
                string role = tbxSubcontractorRole.Text;

                ProjectNavigatorProjectJobInfo projectNavigatorProjectJobInfo = new ProjectNavigatorProjectJobInfo(projectNavigatorTDS);
                projectNavigatorProjectJobInfo.Update(projectId, typeOfWorkMhRehab, typeOfWorkJunctionLining, typeOfWorkProjectManagement, typeOfWorkFullLenghtLining, typeOfWorkPointRepairs, typeOfWorkRehabAssessment, typeOfWorkGrout, typeOfWorkOther, agreement, writtenQuote, role);

                // Costing Updates
                //decimal? extrasToDate = null; if (tbxExtrasToDate.Text.Trim() != "") extrasToDate = decimal.Parse(tbxExtrasToDate.Text.Trim());
                //decimal? costsIncurred = null; if (tbxCostsIncurred.Text.Trim() != "") costsIncurred = decimal.Parse(tbxCostsIncurred.Text.Trim());
                //decimal? costToComplete = null; if (tbxCostToComplete.Text.Trim() != "") costToComplete = decimal.Parse(tbxCostToComplete.Text.Trim());
                //decimal? originalProfitEstimated = null; if (tbxOriginalProfitEstimated.Text.Trim() != "") originalProfitEstimated = decimal.Parse(tbxOriginalProfitEstimated.Text.Trim());
                //decimal? invoicedToDate = null; if (tbxInvoicedToDate.Text.Trim() != "") invoicedToDate = decimal.Parse(tbxInvoicedToDate.Text.Trim());

                // ... Update Costing Updates
                //ProjectCostingUpdates projectCostingUpdates = new ProjectCostingUpdates(projectTDS);
                //projectCostingUpdates.Update(projectId, extrasToDate, costsIncurred, costToComplete, originalProfitEstimated, invoicedToDate, Int32.Parse(hdfCompanyId.Value.Trim()));

                // Terms/PO
                // ... Liquidated Damage
                //bool liquidateDamage = cbxLiquidatedDamages.Checked;
                //decimal? liquidatedRate = null;
                //if (tbxLiquidatedDamagesRate.Text.Trim() != "") { decimal damages = Decimal.Parse(tbxLiquidatedDamagesRate.Text.Trim()); liquidatedRate = Decimal.Round(damages, 2); }
                //string liquidatedUnit = null; if (tbxLiquidatedDamagesUnit.Text != "") liquidatedUnit = tbxLiquidatedDamagesUnit.Text.Trim();

                //// ... Client LFS Relationship
                //bool clientWorkedBefore = cbxWorkedBefore.Checked;
                //string clientQuirks = null; if (tbxClientQuirks.Text.Trim() != "") clientQuirks = tbxClientQuirks.Text.Trim();
                //bool clientPromises = cbxClientPromises.Checked;
                //string clientPromisesNotes = null; if (tbxClientPromises.Text.Trim() != "") clientPromisesNotes = tbxClientPromises.Text.Trim();
                //string waterObtain = null; if (tbxWaterObtain.Text.Trim() != "") waterObtain = tbxWaterObtain.Text.Trim();
                //string materialDispose = null; if (tbxMaterialDispose.Text.Trim() != "") materialDispose = tbxMaterialDispose.Text.Trim();
                //bool requireRPZ = cbxRequireRPZ.Checked;
                //string standardHydrantFitting = null; if (tbxStandardHydrantFitting.Text.Trim() != "") standardHydrantFitting = tbxStandardHydrantFitting.Text.Trim();
                //bool preconstructionMeeting = cbxPreConstructionMeetingNeed.Checked;
                //bool specificMeetingLocation = cbxSpecificMeetingLocation.Checked;
                //string specificMeetingLocationNotes = null; if (tbxSpecificMeetingLocation.Text.Trim() != "") specificMeetingLocationNotes = tbxSpecificMeetingLocation.Text.Trim();
                //string vehicleAccess = null; if (ddlVehicleAccess.Text.Trim() != "") vehicleAccess = ddlVehicleAccess.Text.Trim();
                //string vehicleAccessNotes = null; if (tbxVehicleAccess.Text.Trim() != "") vehicleAccessNotes = tbxVehicleAccess.Text.Trim();
                string projectOutcome = null; if (tbxDesireOutcomeOfProject.Text.Trim() != "") projectOutcome = tbxDesireOutcomeOfProject.Text.Trim();
                string specificReportingNeeds = null; if (tbxSpecificReportingNeeds.Text.Trim() != "") specificReportingNeeds = tbxSpecificReportingNeeds.Text.Trim();
                bool vehicleAccessRoad = ckbxVehicleAccessRoad.Checked;
                bool vehicleAccessEasement = ckbxVehicleAccessEasement.Checked;
                bool vehicleAccessOther = ckbxVehicleAccessOther.Checked;

                //... Purchase Order
                //bool orderAttached = cbxPurchaseOrderAttach.Checked;
                string orderNumber = null; if (tbxPurchaseOrderNumber.Text.Trim() != "") orderNumber = tbxPurchaseOrderNumber.Text.Trim();
                //string orderNotes = null; if (tbxPurchaseOrderWillNotProvided.Text.Trim() != "") orderNotes = tbxPurchaseOrderWillNotProvided.Text.Trim();

                // ... Update Term/PO
                ProjectTermsPO projectTermsPO = new ProjectTermsPO(projectTDS);
                //projectTermsPO.Update(projectId, liquidateDamage, liquidatedRate, liquidatedUnit, clientWorkedBefore, clientQuirks, clientPromises, clientPromisesNotes, waterObtain, materialDispose, requireRPZ, standardHydrantFitting, preconstructionMeeting, specificMeetingLocation, specificMeetingLocationNotes, vehicleAccess, vehicleAccessNotes, projectOutcome, specificReportingNeeds, orderNumber, orderAttached, orderNotes, Int32.Parse(hdfCompanyId.Value.Trim()));
                projectTermsPO.Update(projectId, projectOutcome, specificReportingNeeds, orderNumber,  Int32.Parse(hdfCompanyId.Value.Trim()), vehicleAccessRoad, vehicleAccessEasement, vehicleAccessOther);

                // Technical
                bool availableDrawings = cbxAvailableDrawings.Checked;
                bool availableVideo = cbxAvailableVideo.Checked;
                //bool groundConditions = cbxGroundConditions.Checked;
                //string groundConditionNotes = null; if (tbxGroundCondition.Text != "") groundConditionNotes = tbxGroundCondition.Text.Trim();
                //bool reviewVideoInspections = cbxReviewVideoInspections.Checked;
                //bool strangeConfigurations = cbxStrangeConfigurations.Checked;
                //string strangeConfigurationsNotes = null; if (tbxStrangeConfigurations.Text != "") strangeConfigurationsNotes = tbxStrangeConfigurations.Text.Trim();
                //string furtherObservations = null; if (tbxFurtherObservations.Text != "") furtherObservations = tbxFurtherObservations.Text.Trim();
                //string restrictiveFactors = null; if (tbxRestrictiveFactors.Text != "") restrictiveFactors = tbxRestrictiveFactors.Text.Trim();

                // ... Update Technical
                ProjectTechnical projectTechnical = new ProjectTechnical(projectTDS);
                //projectTechnical.Update(projectId, availableDrawings, availableVideo, groundConditions, groundConditionNotes, reviewVideoInspections, strangeConfigurations, strangeConfigurationsNotes, furtherObservations, restrictiveFactors, Int32.Parse(hdfCompanyId.Value.Trim()));
                projectTechnical.Update(projectId, availableDrawings, availableVideo,  Int32.Parse(hdfCompanyId.Value.Trim()));

                // Engineer/Subcontractors
                bool generalContractor = cbxGeneralContractor.Checked;
                bool generalWSIB = cbxGeneralWSIB.Checked;
                bool generalInsuranceCertificate = cbxGeneralInsuranceCertificate.Checked;
                string generalBondingSupplied = ddlGeneralBondingSupplied.SelectedValue;
                //string generalMOLForm = ddlGeneralMOLForm.SelectedValue;
                //bool generalNoticeProject = rbtnGeneralNoticeProject.Checked;
                //bool generalForm1000 = rbtnGeneralForm1000.Checked;
                //int? engineeringFirmId = null; if (ddlEngineeringFirmId.SelectedValue != "") engineeringFirmId = int.Parse(ddlEngineeringFirmId.SelectedValue);
                //int? engineerId = null; if (ddlEngineerId.SelectedValue != "") engineerId = int.Parse(ddlEngineerId.SelectedValue);
                //string engineerNumber = tbxEngineerNumber.Text.Trim();
                bool subcontractorUsed = cbxSubcontractorUsed.Checked;
                string bondNumber = tbxBondNumber.Text.Trim();

                // ... Update Engineer/Subcontractors
                ProjectEngineerSubcontractors projectEngineerSubcontractors = new ProjectEngineerSubcontractors(projectTDS);
                //projectEngineerSubcontractors.Update(projectId, generalContractor, generalWSIB, generalInsuranceCertificate, generalBondingSupplied, generalMOLForm, generalNoticeProject, generalForm1000, engineeringFirmId, engineerId, engineerNumber, subcontractorUsed, Int32.Parse(hdfCompanyId.Value.Trim()), bondNumber);
                projectEngineerSubcontractors.Update(projectId, generalContractor, generalWSIB, generalInsuranceCertificate, generalBondingSupplied, subcontractorUsed, Int32.Parse(hdfCompanyId.Value.Trim()), bondNumber);

                // ... Update subcontractors
                //ProjectSubcontractor projectSubcontractor = new ProjectSubcontractor(projectTDS);

                //bool subcontractorWrittenQuote = ((CheckBox)row.FindControl("cbxSubcontractorWrittenQuote")).Checked;
                //bool subcontractorAgreement = ((CheckBox)row.FindControl("cbxSubcontractorAgreement")).Checked;

                ////foreach (GridViewRow row in grdvSubcontractors.Rows)
                //{
                //    int subcontractorRefId = int.Parse(((HiddenField)row.FindControl("hdfRefId")).Value);
                //    int subcontractorId = int.Parse(((DropDownList)row.FindControl("ddlSubcontractorId")).SelectedValue);
                      
                //    bool subcontractorSurveyedSite = ((CheckBox)row.FindControl("cbxSubcontractorSurveyedSite")).Checked;
                //    bool subcontractorWorkedBefore = ((CheckBox)row.FindControl("cbxSubcontractorWorkedBefore")).Checked;
                //    string subcontractorRole = ((TextBox)row.FindControl("tbxSubcontractorRole")).Text.Trim();
                      
                //    string subcontractorIssues = ((TextBox)row.FindControl("tbxSubcontractorIssues")).Text.Trim();
                //    bool subcontractorPurchaseOrder = ((CheckBox)row.FindControl("cbxSubcontractorPurchaseOrder")).Checked;
                //    bool subcontractorInsuranceCertificate = ((CheckBox)row.FindControl("cbxSubcontractorInsuranceCertificate")).Checked;
                //    bool subcontractorWSIB = ((CheckBox)row.FindControl("cbxSubcontractorWSIB")).Checked;
                //    string subcontractorMOLForm1000 = ((DropDownList)row.FindControl("ddlSubcontractorMolForm1000")).SelectedValue;
                //    int? royalties = null;
                //    if (((TextBox)row.FindControl("tbxRoyalties")).Text != "")
                //    {
                //        royalties = Int32.Parse(((TextBox)row.FindControl("tbxRoyalties")).Text);
                //    }

                    //projectSubcontractor.Update(projectId, subcontractorRefId, subcontractorId, subcontractorWrittenQuote, subcontractorSurveyedSite, subcontractorWorkedBefore, subcontractorRole, subcontractorAgreement, subcontractorIssues, subcontractorPurchaseOrder, subcontractorInsuranceCertificate, subcontractorWSIB, subcontractorMOLForm1000, false, Int32.Parse(hdfCompanyId.Value.Trim()), royalties);
                    //projectSubcontractor.Update(projectId, 1,  subcontractorWrittenQuote, subcontractorAgreement, Int32.Parse(hdfCompanyId.Value.Trim()));
                //}

                decimal unitsBudget = 0M; if (tbxUnitsBudget.Text.Trim() != "") unitsBudget = decimal.Parse(tbxUnitsBudget.Text);
                decimal materialsBudget = 0M; if (tbxMaterialsBudget.Text.Trim() != "") materialsBudget = decimal.Parse(tbxMaterialsBudget.Text);
                decimal subcontractorsBudget = 0M; if (tbxSubcontractorsBudget.Text.Trim() != "") subcontractorsBudget = decimal.Parse(tbxSubcontractorsBudget.Text);
                decimal hotelsBudget = 0M; if (tbxHotelsBudget.Text.Trim() != "") hotelsBudget = decimal.Parse(tbxHotelsBudget.Text);
                decimal bondingsBudget = 0M; if (tbxBondingsBudget.Text.Trim() != "") bondingsBudget = decimal.Parse(tbxBondingsBudget.Text);
                decimal insurancesBudget = 0M; if (tbxInsurancesBudget.Text.Trim() != "") insurancesBudget = decimal.Parse(tbxInsurancesBudget.Text);
                
                ProjectNavigatorProjectUnitsBudget projectNavigatorProjectUnitsBudget = new ProjectNavigatorProjectUnitsBudget(projectNavigatorTDS);
                if (projectNavigatorProjectUnitsBudget.Table.Rows.Count > 0)
                {
                    projectNavigatorProjectUnitsBudget.Update(projectId, unitsBudget);
                }
                else
                {
                    projectNavigatorProjectUnitsBudget.Insert(projectId, unitsBudget, false, Int32.Parse(hdfCompanyId.Value), false);
                }

                ProjectNavigatorProjectMaterialsBudget projectNavigatorProjectMaterialsBudget = new ProjectNavigatorProjectMaterialsBudget(projectNavigatorTDS);
                if (projectNavigatorProjectMaterialsBudget.Table.Rows.Count > 0)
                {
                    projectNavigatorProjectMaterialsBudget.Update(projectId, materialsBudget);
                }
                else
                {
                    projectNavigatorProjectMaterialsBudget.Insert(projectId, materialsBudget, false, Int32.Parse(hdfCompanyId.Value), false);
                }

                ProjectNavigatorProjectSubcontractorsBudget projectNavigatorProjectSubcontractorsBudget = new ProjectNavigatorProjectSubcontractorsBudget(projectNavigatorTDS);
                if (projectNavigatorProjectSubcontractorsBudget.Table.Rows.Count > 0)
                {
                    projectNavigatorProjectSubcontractorsBudget.Update(projectId, 1, 1, subcontractorsBudget, false, Int32.Parse(hdfCompanyId.Value));
                }
                else
                {
                    projectNavigatorProjectSubcontractorsBudget.Insert(projectId, 1, subcontractorsBudget, false, Int32.Parse(hdfCompanyId.Value), false, "");
                }

                ProjectNavigatorProjectHotelsBudget projectNavigatorProjectHotelsBudget = new ProjectNavigatorProjectHotelsBudget(projectNavigatorTDS);
                if (projectNavigatorProjectHotelsBudget.Table.Rows.Count > 0)
                {
                    projectNavigatorProjectHotelsBudget.Update(projectId, 1, 1, hotelsBudget, false, Int32.Parse(hdfCompanyId.Value));
                }
                else
                {
                    projectNavigatorProjectHotelsBudget.Insert(projectId, 1, hotelsBudget, false, Int32.Parse(hdfCompanyId.Value), false, "");
                }

                ProjectNavigatorProjectBondingsBudget projectNavigatorProjectBondingsBudget = new ProjectNavigatorProjectBondingsBudget(projectNavigatorTDS);
                if (projectNavigatorProjectBondingsBudget.Table.Rows.Count > 0)
                {
                    projectNavigatorProjectBondingsBudget.Update(projectId, 1, 1, bondingsBudget, false, Int32.Parse(hdfCompanyId.Value));
                }
                else
                {
                    projectNavigatorProjectBondingsBudget.Insert(projectId, 1, bondingsBudget, false, Int32.Parse(hdfCompanyId.Value), false, "");
                }

                ProjectNavigatorProjectInsurancesBudget projectNavigatorProjectInsurancesBudget = new ProjectNavigatorProjectInsurancesBudget(projectNavigatorTDS);
                if (projectNavigatorProjectInsurancesBudget.Table.Rows.Count > 0)
                {
                    projectNavigatorProjectInsurancesBudget.Update(projectId, 1, 1, insurancesBudget, false, Int32.Parse(hdfCompanyId.Value));
                }
                else
                {
                    projectNavigatorProjectInsurancesBudget.Insert(projectId, 1, insurancesBudget, false, Int32.Parse(hdfCompanyId.Value), false, "");
                }
            }
        }



        private void UpdateDatabase()
        {
            try
            {
                ProjectGateway projectGateway = new ProjectGateway(projectTDS);

                //LibraryFilesGateway libraryFilesGateway = new LibraryFilesGateway(libraryTDS);
                //libraryFilesGateway.Update();

                //libraryTDS.AcceptChanges();

                //Getting projectId for Notes table
                ProjectNotesGateway projectNotesGateway = new ProjectNotesGateway(projectTDS);                

                projectGateway.Update3();
                projectTDS.AcceptChanges();

                // Save notes
                int companyId = Int32.Parse(hdfCompanyId.Value);
                //ProjectNavigatorProjectNotesGateway projectNavigatorNotesGateway = new ProjectNavigatorProjectNotesGateway(projectNavigatorTDS);

                //ProjectNavigatorProjectNotes projectNavigatorProjectNotes = new ProjectNavigatorProjectNotes(projectNavigatorTDS);

                //foreach (ProjectNavigatorTDS.ProjectNotesRow rowNotes in (ProjectNavigatorTDS.ProjectNotesDataTable)projectNavigatorNotesGateway.Table)
                //{
                //    if (!rowNotes.IsLIBRARY_FILES_IDNull())
                //    {
                //        if (rowNotes.LIBRARY_FILES_ID == 0 && rowNotes.FILENAME != "")
                //        {                            
                //            libraryFilesGateway.LoadByFileName(rowNotes.FILENAME, companyId);
                //            int newLibraryFilesId = libraryFilesGateway.GetlibraryFilesId(rowNotes.FILENAME);

                //            rowNotes.LIBRARY_FILES_ID = newLibraryFilesId;
                //        }
                //    }
                //}

                //projectNavigatorProjectNotes.Save(companyId);

                // Save job info
                ProjectNavigatorProjectJobInfo projectNavigatorProjectJobInfo = new ProjectNavigatorProjectJobInfo(projectNavigatorTDS);
                projectNavigatorProjectJobInfo.Save(companyId);
                
                // Save services
                ProjectNavigatorProjectService projectNavigatorProjectService = new ProjectNavigatorProjectService(projectNavigatorTDS);
                projectNavigatorProjectService.UpdateForSave();
                projectNavigatorProjectService.Save(companyId);

                // Save Cost Exceptions
                // ... Save Job Class Type Rate Classification
                ProjectNavigatorProjectJobClassTypeRate projectNavigatorProjectJobClassTypeRate = new ProjectNavigatorProjectJobClassTypeRate(projectNavigatorTDS);
                projectNavigatorProjectJobClassTypeRate.Save(companyId);

                // ... Save Work Function Fair Wage Classification
                ProjectNavigatorProjectWorkFunctionFairWage projectNavigatorProjectWorkFunctionFairWage = new ProjectNavigatorProjectWorkFunctionFairWage(projectNavigatorTDS);
                projectNavigatorProjectWorkFunctionFairWage.Save(companyId);

                // ... Save budget
                ProjectNavigatorProjectWorkFunctionBudget projectNavigatorProjectWorkFunctionBudget = new ProjectNavigatorProjectWorkFunctionBudget(projectNavigatorTDS);
                projectNavigatorProjectWorkFunctionBudget.Save(companyId);

                ProjectNavigatorProjectUnitsBudget projectNavigatorProjectUnitsBudget = new ProjectNavigatorProjectUnitsBudget(projectNavigatorTDS);
                projectNavigatorProjectUnitsBudget.Save(companyId);

                ProjectNavigatorProjectMaterialsBudget projectNavigatorProjectMaterialsBudget = new ProjectNavigatorProjectMaterialsBudget(projectNavigatorTDS);
                projectNavigatorProjectMaterialsBudget.Save(companyId);

                ProjectNavigatorProjectSubcontractorsBudget projectNavigatorProjectSubcontractorsBudget = new ProjectNavigatorProjectSubcontractorsBudget(projectNavigatorTDS);
                projectNavigatorProjectSubcontractorsBudget.Save(companyId);

                ProjectNavigatorProjectHotelsBudget projectNavigatorProjectHotelsBudget = new ProjectNavigatorProjectHotelsBudget(projectNavigatorTDS);
                projectNavigatorProjectHotelsBudget.Save(companyId);

                ProjectNavigatorProjectBondingsBudget projectNavigatorProjectBondingsBudget = new ProjectNavigatorProjectBondingsBudget(projectNavigatorTDS);
                projectNavigatorProjectBondingsBudget.Save(companyId);

                ProjectNavigatorProjectInsurancesBudget projectNavigatorProjectInsurancesBudget = new ProjectNavigatorProjectInsurancesBudget(projectNavigatorTDS);
                projectNavigatorProjectInsurancesBudget.Save(companyId);

                ProjectNavigatorProjectOtherCostsBudget projectNavigatorProjectOtherCostsBudget = new ProjectNavigatorProjectOtherCostsBudget(projectNavigatorTDS);
                projectNavigatorProjectOtherCostsBudget.Save(companyId);

                projectNavigatorTDS.AcceptChanges();
                Session["projectNavigatorTDS"] = projectNavigatorTDS;
                Session["lfsProjectTDS"] = projectTDS;                
                Session["lfsLibraryTDS"] = libraryTDS;
            }
            catch (Exception ex)
            {
                string url = string.Format("./../../error_page.aspx?error={0}", ex.Message.Replace('\n', ' '));
                Response.Redirect(url);
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
            hdfClientId.Value = projectGateway.GetClientID(Int32.Parse(hdfProjectId.Value)).ToString();

            // ... for client
            int companyId = Int32.Parse(hdfCompanyId.Value);
            CompaniesGateway companiesGateway = new CompaniesGateway();
            companiesGateway.LoadAllByCompaniesId(currentCompanyId, companyId);

            if (projectTDS.LFS_PROJECT.Rows.Count > 0)
            {
                tkrdpStartDate.DataBind();
                tkrdpEndDate.DataBind();
                tkrdpProposalDate.DataBind();                
                tbxProjectNumber.DataBind();
                tbxName.DataBind();
                tbxDescription.DataBind();
                tbxClientName.Text = companiesGateway.GetName(projectGateway.GetClientID(int.Parse(hdfProjectId.Value)));
                tbxClientProjectNumber.DataBind();

                // ... ... for primary contact
                ContactsList contactList = new ContactsList();
                contactList.LoadAllAndAddItemByCompaniesId(-1, " ", projectGateway.GetClientID(int.Parse(hdfProjectId.Value)), companyId);
                ddlClientPrimaryContactId.DataSource = contactList.Table;
                ddlClientPrimaryContactId.DataValueField = "CONTACTS_ID";
                ddlClientPrimaryContactId.DataTextField = "Name";

                if (projectGateway.GetClientPrimaryContactID(int.Parse(hdfProjectId.Value)).HasValue)
                {
                    ddlClientPrimaryContactId.SelectedValue = projectGateway.GetClientPrimaryContactID(int.Parse(hdfProjectId.Value)).ToString();
                }
                else
                {
                    ddlClientPrimaryContactId.SelectedValue = "-1";
                }

                ddlClientPrimaryContactId.DataBind();

                // ... ... for secondary contact
                ddlClientSecondaryContactId.DataSource = contactList.Table;
                ddlClientSecondaryContactId.DataValueField = "CONTACTS_ID";
                ddlClientSecondaryContactId.DataTextField = "Name";

                if (projectGateway.GetClientSecondaryContactID(int.Parse(hdfProjectId.Value)).HasValue)
                {
                    ddlClientSecondaryContactId.SelectedValue = projectGateway.GetClientSecondaryContactID(int.Parse(hdfProjectId.Value)).ToString();
                }
                else
                {
                    ddlClientSecondaryContactId.SelectedValue = "-1";
                }

                ddlClientSecondaryContactId.DataBind();

                // ... for resources
                // ...  ... for project lead
                EmployeeList employeeList = new EmployeeList();
                employeeList.LoadAndAddItem(-1, " ");
                ddlProjectLeadId.DataSource = employeeList.Table;
                ddlProjectLeadId.DataValueField = "EmployeeID";
                ddlProjectLeadId.DataTextField = "FullName";
                ddlProjectLeadId.SelectedValue = (projectGateway.GetProjectLeadID(int.Parse(hdfProjectId.Value)).HasValue) ? ((int)projectGateway.GetProjectLeadID(int.Parse(hdfProjectId.Value))).ToString() : "-1";
                ddlProjectLeadId.DataBind();

                // ... ... for salesman
                SalesmanListGateway salesmanListGateway = new SalesmanListGateway(new DataSet());
                salesmanListGateway.Load();
                ddlSalesmanId.DataSource = salesmanListGateway.Table;
                ddlSalesmanId.DataValueField = "SalesmanID";
                ddlSalesmanId.DataTextField = "FullName";
                ddlSalesmanId.SelectedValue = ((int)projectGateway.GetSalesmanID(int.Parse(hdfProjectId.Value))).ToString();
                ddlSalesmanId.DataBind();

                // ... ... for Pricing
                if (projectGateway.GetProjectType(int.Parse(hdfProjectId.Value)) == "Ballpark")
                {
                    ProjectSaleBillingPricingGateway projectSaleBillingPricingGateway = new ProjectSaleBillingPricingGateway(projectTDS);
                    
                    if (projectSaleBillingPricingGateway.Table.Rows.Count > 0)
                    {
                        tbxBillPrice.DataBind();
                        ddlBillMoney.DataBind();
                    }
                    else
                    {
                        if (projectGateway.GetCountryID(int.Parse(hdfProjectId.Value)) == 1)
                        {
                            ddlBillMoney.SelectedValue = "CAD";
                        }
                        else
                        {
                            ddlBillMoney.SelectedValue = "USD";
                        }
                    }
                }
            }

            cbxFairWageApplies.DataBind();

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

            if (projectNavigatorProjectJobInfoGateway.Table.Rows.Count == 0)
            {
                ProjectNavigatorProjectJobInfo projectNavigatorProjectJobInfo = new ProjectNavigatorProjectJobInfo(projectNavigatorTDS);
                projectNavigatorProjectJobInfo.Insert(int.Parse(hdfProjectId.Value), false, false, false, false, false, false, false, false, Int32.Parse(hdfCompanyId.Value.Trim()), false, false, false, "");

            }
            else
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
            if (projectTDS.LFS_PROJECT_SALE_BILLING_PRICING.Rows.Count == 0)
            {
                // ... If the project has no Sale/Billing/Pricing
                ProjectGateway projectGateway = new ProjectGateway(projectTDS);
                string billMoney = "CAD"; if (projectGateway.GetCountryID(int.Parse(hdfProjectId.Value)) == 2) billMoney = "USD";

                ProjectSaleBillingPricing projectSaleBillingPricing = new ProjectSaleBillingPricing(projectTDS);
                projectSaleBillingPricing.Insert(int.Parse(hdfProjectId.Value), false, false, false, false, "", false, "", null, null, billMoney, "", false, false, "", null, false, null, false, null, Int32.Parse(hdfCompanyId.Value.Trim()));
            }
            
            ddlBillMoneySaleBillingPricing.DataBind();
            //cbxBillHourly.DataBind();
            //cbxBillPerUnit.DataBind();
            //cbxChargesDisposal.DataBind();
            //cbxChargesWater.DataBind();
            //cbxSaleBidProject.DataBind();
            //cbxSaleOther.DataBind();
            //cbxSaleRFP.DataBind();
            //cbxSaleSoleSource.DataBind();
            //cbxSaleTermContract.DataBind();
            //tbxBillBidHardDollar.DataBind();
            //tbxBillExpectExtras.DataBind();
            tbxBillPriceSaleBillingPricing.DataBind();
            tbxBillSubcontractorAmount.DataBind();
            //tbxChargesDisposalAmount.DataBind();
            //tbxChargesWaterAmount.DataBind();
            //tbxSaleGettingJob.DataBind();
            //tbxSaleOtherDetail.DataBind();
            //tbxSaleTermContractDetail.DataBind();

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
            // Data for Terms/PO tab

            // ... Value for Vehicle Access
            //TermsRelationshipVehicleAccess termsRelationshipVehicleAccess = new TermsRelationshipVehicleAccess(new DataSet());
            //termsRelationshipVehicleAccess.LoadAndAddItem(" ");
            //ddlVehicleAccess.DataSource = termsRelationshipVehicleAccess.Table;
            //ddlVehicleAccess.DataValueField = "RelationshipVehicleAccess";
            //ddlVehicleAccess.DataTextField = "RelationshipVehicleAccess";
            //ddlVehicleAccess.DataBind();
            //ddlVehicleAccess.SelectedValue = "";

            // ... Data for Terms/PO
            ProjectTermsPOGateway projectTermsPOGateway = new ProjectTermsPOGateway(projectTDS);
            
            if (projectTDS.LFS_PROJECT_TERMS.Rows.Count == 0)
            {
                // ... If the project has no Terms/PO
                ProjectTermsPO projectTermsPO = new ProjectTermsPO(projectTDS);
                projectTermsPO.Insert(int.Parse(hdfProjectId.Value), false, 0.00M, null, false, null, false, null, null, null, false, null, false, false, null, null, null, null, null, null, false, null, Int32.Parse(hdfCompanyId.Value.Trim()), false, false, false);                
            }
            else
            {
                // ... If the project has Terms/PO
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
                //ddlVehicleAccess.SelectedValue = projectTermsPOGateway.GetRelationshipVehicleAccess(int.Parse(hdfProjectId.Value));
                //tbxVehicleAccess.Text = projectTermsPOGateway.GetRelationshipVehicleAccessNotes(int.Parse(hdfProjectId.Value));
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
            
            if (projectTDS.LFS_PROJECT_TECHNICAL.Rows.Count == 0)
            {
                // ... If the project has no Technical
                ProjectTechnical projectTechnical = new ProjectTechnical(projectTDS);
                projectTechnical.Insert(int.Parse(hdfProjectId.Value), false, false, false, null, false, false, null, null, null, Int32.Parse(hdfCompanyId.Value.Trim()));
            }
            else
            {
                // ... If the project has Technical
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



        private void LoadEngineerSubcontractors()
        {
            // Data for Engineer/Subcontractors tab
            if (projectTDS.LFS_PROJECT_ENGINEER_SUBCONTRACTORS.Rows.Count == 0)
            {
                // ... If the project has no Engineer/Subcontractors
                ProjectEngineerSubcontractors projectEngineerSubcontractors = new ProjectEngineerSubcontractors(projectTDS);
                projectEngineerSubcontractors.Insert(int.Parse(hdfProjectId.Value), false, false, false, "NA", "NA", false, false, null, null, "", false, Int32.Parse(hdfCompanyId.Value.Trim()), "");                
            }

            cbxGeneralContractor.DataBind();
            cbxGeneralWSIB.DataBind();
            cbxGeneralInsuranceCertificate.DataBind();
            ddlGeneralBondingSupplied.DataBind();
            tbxBondNumber.DataBind();
            //tbxGeneralMOLForm.DataBind();
            //ddlGeneralMOLForm.DataBind();
            //rbtnGeneralNoticeProject.DataBind();
            //rbtnGeneralForm1000.DataBind();

            //// ... for Engineering firm
            //int companyId = Int32.Parse(hdfCompanyId.Value);
            //CompaniesList companiesList = new CompaniesList();
            //companiesList.LoadAndAddItem(null, "", companyId);
            //ddlEngineeringFirmId.DataSource = companiesList.Table;
            //ddlEngineeringFirmId.DataTextField = "Name";
            //ddlEngineeringFirmId.DataValueField = "COMPANIES_ID";
            //ddlEngineeringFirmId.DataBind();

            //// ... for Engineer
            //ContactsList contactsList = new ContactsList();
            //contactsList.LoadAllAndAddItem(null, "", companyId);
            //ddlEngineerId.DataSource = contactsList.Table;
            //ddlEngineerId.DataTextField = "Name";
            //ddlEngineerId.DataValueField = "CONTACTS_ID";
            //ddlEngineerId.DataBind();

            //tbxEngineerNumber.DataBind();
            cbxSubcontractorUsed.DataBind();

            // Databind Grid for Subcontractors
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


        //   ProjectGateway projectGateway = new ProjectGateway(projectTDS);

        //   int? libraryCategoriesId = null; if (projectGateway.GetLibraryCategoriesId(int.Parse(hdfProjectId.Value)).HasValue) libraryCategoriesId = (int)projectGateway.GetLibraryCategoriesId(int.Parse(hdfProjectId.Value));

        //    if (libraryCategoriesId.HasValue)
        //    {
        //        ViewState["libraryCategoriesId"] = (int)libraryCategoriesId;
        //        tbxCategoryAssocited.Text = GetFullCategoryName((int)libraryCategoriesId);
        //        btnAssociate.Visible = false;
        //        btnUnassociate.Visible = true;
        //    }
        //    else
        //    {
        //        tbxCategoryAssocited.Text = "";
        //        btnAssociate.Visible = true;
        //        btnUnassociate.Visible = false;
        //    }           
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



        //protected string GetNoteCreatedBy(object userId)
        //{
        //    if (userId != DBNull.Value)
        //    {
        //        if (Convert.ToInt32(userId) != -1)
        //        {
        //            try
        //            {
        //                // Created By
        //                int companyId = Int32.Parse(hdfCompanyId.Value);

        //                LoginGateway loginGateway = new LoginGateway();
        //                loginGateway.LoadByLoginId(Convert.ToInt32(userId), companyId);
        //                string userName = loginGateway.GetLastName(Convert.ToInt32(userId), companyId) + " " + loginGateway.GetFirstName(Convert.ToInt32(userId), companyId);

        //                return userName.ToString();
        //            }
        //            catch
        //            {
        //                return "";
        //            }
        //        }
        //        else
        //        {
        //            return "";
        //        }
        //    }
        //    else
        //    {
        //        return "";
        //    }
        //}



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

        #endregion
     


    }
}