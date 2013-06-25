using System;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.BL.Projects.Projects;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.DA.Resources.Companies;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.Projects.Projects
{
    /// <summary>
    /// project_combined_costing_sheets_summary
    /// </summary>
    public partial class project_combined_costing_sheets_summary : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected ProjectTDS projectTDS;
        protected ProjectCostingSheetInformationTDS projectCostingSheetInformationTDS;
        protected ProjectCostingSheetInformationTDS.CombinedLabourHoursInformationDataTable labourHoursInformation;
        protected ProjectCostingSheetInformationTDS.CombinedUnitsInformationDataTable unitsInformation;
        protected ProjectCostingSheetInformationTDS.CombinedSubcontractorsInformationDataTable subcontractorsInformation;
        protected ProjectCostingSheetInformationTDS.CombinedMaterialsInformationDataTable materialsInformation;
        protected ProjectCostingSheetInformationTDS.CombinedOtherCostsInformationDataTable otherCostsInformation;
        protected ProjectCostingSheetInformationTDS.CombinedRevenueInformationDataTable revenueInformation;






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
                if (!Convert.ToBoolean(Session["sgLFS_PROJECTS_COSTINGSHEETS_ADMIN"]))
                {
                    if (!(Convert.ToBoolean(Session["sgLFS_PROJECTS_COSTINGSHEETS_VIEW"]) && Convert.ToBoolean(Session["sgLFS_PROJECTS_COSTINGSHEETS_EDIT"])))
                    {
                        Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                    }
                }

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["costing_sheet_id"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in project_combined_costing_sheets_summary.aspx");
                }

                // Tag Page
                hdfCostingSheetId.Value = Request.QueryString["costing_sheet_id"].ToString();
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfProjectId.Value = Request.QueryString["project_id"];
                hdfDataChanged.Value = Request.QueryString["data_changed"];
                hdfDataChangedMessage.Value = "Changes made to this project will not be saved.";

                ViewState["state"] = Request.QueryString["state"];
                ViewState["active_tab"] = Request.QueryString["active_tab"];
                ViewState["origin"] = Request.QueryString["origin"];
                ViewState["update"] = Request.QueryString["update"];

                projectTDS = (ProjectTDS)Session["lfsProjectTDS"];

                Session.Remove("labourHoursInformationDummy");
                Session.Remove("unitsInformationDummy");
                Session.Remove("subcontractorsInformationDummy");
                Session.Remove("materialsInformationDummy");
                Session.Remove("otherCostsInformationDummy");
                Session.Remove("revenueInformationDummy");
                
                // If coming from project_costing_sheets_navigator.aspx or project_costing_sheets_add.aspx
                if (Request.QueryString["source_page"] == "project_costing_sheets_navigator.aspx" || Request.QueryString["source_page"] == "project_combined_costing_sheets_add.aspx")
                {
                    // Store Navigator State and Update control
                    StoreNavigatorState();
                    ViewState["update"] = "no";

                    // Get Costing sheet ID
                    int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
                    int costingSheetId = Int32.Parse(hdfCostingSheetId.Value.Trim());

                    // Get dataset
                    projectTDS = (ProjectTDS)Session["lfsProjectTDS"];
                    projectCostingSheetInformationTDS = new ProjectCostingSheetInformationTDS();
                    labourHoursInformation = new ProjectCostingSheetInformationTDS.CombinedLabourHoursInformationDataTable();
                    unitsInformation = new ProjectCostingSheetInformationTDS.CombinedUnitsInformationDataTable();
                    subcontractorsInformation = new ProjectCostingSheetInformationTDS.CombinedSubcontractorsInformationDataTable();
                    materialsInformation = new ProjectCostingSheetInformationTDS.CombinedMaterialsInformationDataTable();
                    otherCostsInformation = new ProjectCostingSheetInformationTDS.CombinedOtherCostsInformationDataTable();
                    revenueInformation = new ProjectCostingSheetInformationTDS.CombinedRevenueInformationDataTable();
                                       
                    // Get General Data
                    ProjectCombinedCostingSheetInformationBasicInformation projectCostingSheetInformationBasicInformation = new ProjectCombinedCostingSheetInformationBasicInformation(projectCostingSheetInformationTDS);
                    projectCostingSheetInformationBasicInformation.LoadByCostingSheetId(costingSheetId, companyId);

                    ProjectCombinedCostingSheetInformationLabourHoursInformationGateway projectCostingSheetInformationLabourHoursInformationGateway = new ProjectCombinedCostingSheetInformationLabourHoursInformationGateway(projectCostingSheetInformationTDS);
                    projectCostingSheetInformationLabourHoursInformationGateway.LoadByCostingSheetId(costingSheetId, companyId);

                    ProjectCombinedCostingSheetInformationUnitsInformationGateway projectCostingSheetInformationUnitsInformationGateway = new ProjectCombinedCostingSheetInformationUnitsInformationGateway(projectCostingSheetInformationTDS);
                    projectCostingSheetInformationUnitsInformationGateway.LoadByCostingSheetId(costingSheetId, companyId);

                    ProjectCombinedCostingSheetInformationSubcontractorsInformationGateway projectCostingSheetInformationSubcontractorsInformationGateway = new ProjectCombinedCostingSheetInformationSubcontractorsInformationGateway(projectCostingSheetInformationTDS);
                    projectCostingSheetInformationSubcontractorsInformationGateway.LoadByCostingSheetId(costingSheetId, companyId);

                    ProjectCombinedCostingSheetInformationMaterialsInformationGateway projectCostingSheetInformationMaterialsInformationGateway = new ProjectCombinedCostingSheetInformationMaterialsInformationGateway(projectCostingSheetInformationTDS);
                    projectCostingSheetInformationMaterialsInformationGateway.LoadByCostingSheetId(costingSheetId, companyId);

                    ProjectCombinedCostingSheetInformationOtherCostsInformationGateway projectCostingSheetInformationOtherCostsInformationGateway = new ProjectCombinedCostingSheetInformationOtherCostsInformationGateway(projectCostingSheetInformationTDS);
                    projectCostingSheetInformationOtherCostsInformationGateway.LoadByCostingSheetId(costingSheetId, companyId);

                    projectCostingSheetInformationRevenueInformationGateway projectCostingSheetInformationRevenueInformationGateway = new projectCostingSheetInformationRevenueInformationGateway(projectCostingSheetInformationTDS);
                    projectCostingSheetInformationRevenueInformationGateway.LoadByCostingSheetId(costingSheetId, companyId);

                    Session["lfsProjectTDS"] = projectTDS;
                    Session["projectCostingSheetInformationTDS"] = projectCostingSheetInformationTDS;
                    Session["labourHoursInformation"] = projectCostingSheetInformationTDS.CombinedLabourHoursInformation;
                    Session["unitsInformation"] = projectCostingSheetInformationTDS.CombinedUnitsInformation;
                    Session["subcontractorsInformation"] = projectCostingSheetInformationTDS.CombinedSubcontractorsInformation;
                    Session["materialsInformation"] = projectCostingSheetInformationTDS.CombinedMaterialsInformation;
                    Session["otherCostsInformation"] = projectCostingSheetInformationTDS.CombinedOtherCostsInformation;
                    Session["revenueInformation"] = projectCostingSheetInformationTDS.CombinedRevenueInformation;

                    labourHoursInformation = projectCostingSheetInformationTDS.CombinedLabourHoursInformation;
                    unitsInformation = projectCostingSheetInformationTDS.CombinedUnitsInformation;
                    subcontractorsInformation = projectCostingSheetInformationTDS.CombinedSubcontractorsInformation;
                    materialsInformation = projectCostingSheetInformationTDS.CombinedMaterialsInformation;
                    otherCostsInformation = projectCostingSheetInformationTDS.CombinedOtherCostsInformation;
                    revenueInformation = projectCostingSheetInformationTDS.CombinedRevenueInformation;
                }

                // ... project_costing_sheets_add.aspx
                if (Request.QueryString["source_page"] == "project_combined_costing_sheets_add.aspx")
                {
                    ViewState["update"] = "yes";
                }

                // ... left menu, project_costing_sheets_edit.aspx, project_costing_sheets_delete.aspx or project_costing_sheets_state.aspx
                if ((Request.QueryString["source_page"] == "lm") || (Request.QueryString["source_page"] == "project_combined_costing_sheets_edit.aspx") || (Request.QueryString["source_page"] == "project_combined_costing_sheets_delete.aspx") || (Request.QueryString["source_page"] == "project_combined_costing_sheets_state.aspx"))
                {
                    // Store Navigator State and Update control
                    StoreNavigatorState();
                    ViewState["update"] = Request.QueryString["update"];                   
                }

                // Restore dataset
                projectTDS = (ProjectTDS)Session["lfsProjectTDS"];
                projectCostingSheetInformationTDS = (ProjectCostingSheetInformationTDS)Session["projectCostingSheetInformationTDS"];

                labourHoursInformation = (ProjectCostingSheetInformationTDS.CombinedLabourHoursInformationDataTable)Session["labourHoursInformation"];
                unitsInformation = (ProjectCostingSheetInformationTDS.CombinedUnitsInformationDataTable)Session["unitsInformation"];
                subcontractorsInformation = (ProjectCostingSheetInformationTDS.CombinedSubcontractorsInformationDataTable)Session["subcontractorsInformation"];
                materialsInformation = (ProjectCostingSheetInformationTDS.CombinedMaterialsInformationDataTable)Session["materialsInformation"];
                otherCostsInformation = (ProjectCostingSheetInformationTDS.CombinedOtherCostsInformationDataTable)Session["otherCostsInformation"];
                revenueInformation = (ProjectCostingSheetInformationTDS.CombinedRevenueInformationDataTable)Session["revenueInformation"];

                ProjectGateway projectGateway = new ProjectGateway(projectTDS);
                hdfClientId.Value = projectGateway.GetClientID(Int32.Parse(hdfProjectId.Value.ToString())).ToString();

                // ... for project
                int currentProjectId = Int32.Parse(hdfProjectId.Value.ToString());
                string name = projectGateway.GetName(currentProjectId);
                if (name.Length > 23) name = name.Substring(0, 20) + "...";
                lblTitleProjectName.Text = name + " (" + projectGateway.GetProjectNumber(currentProjectId) + ")";

                // ... for client
                int currentClientId = projectGateway.GetClientID(Int32.Parse(hdfProjectId.Value.ToString()));                
                CompaniesGateway companiesGateway = new CompaniesGateway();
                companiesGateway.LoadAllByCompaniesId(currentClientId, Int32.Parse(hdfCompanyId.Value));
                lblTitleClientName.Text = "Client: " + companiesGateway.GetName(currentClientId);

                LoadBasicData();
            }
            else
            {
                // Restore dataset
                projectTDS = (ProjectTDS)Session["lfsProjectTDS"];
                projectCostingSheetInformationTDS = (ProjectCostingSheetInformationTDS)Session["projectCostingSheetInformationTDS"];

                labourHoursInformation = (ProjectCostingSheetInformationTDS.CombinedLabourHoursInformationDataTable)Session["labourHoursInformation"];
                unitsInformation = (ProjectCostingSheetInformationTDS.CombinedUnitsInformationDataTable)Session["unitsInformation"];
                subcontractorsInformation = (ProjectCostingSheetInformationTDS.CombinedSubcontractorsInformationDataTable)Session["subcontractorsInformation"];
                materialsInformation = (ProjectCostingSheetInformationTDS.CombinedMaterialsInformationDataTable)Session["materialsInformation"];
                otherCostsInformation = (ProjectCostingSheetInformationTDS.CombinedOtherCostsInformationDataTable)Session["otherCostsInformation"];
                revenueInformation = (ProjectCostingSheetInformationTDS.CombinedRevenueInformationDataTable)Session["revenueInformation"];
            }
        }        



        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set active toolbar
            mForm6 master = (mForm6)this.Master;
            master.ActiveToolbar = "Projects";

            // Security check
            if (!Convert.ToBoolean(Session["sgLFS_PROJECTS_ADMIN"]))
            {
                tkrpbLeftMenuReports.Visible = false;
            }

            ProjectCombinedCostingSheetInformationBasicInformationGateway projectCostingSheetInformationBasicInformationGateway = new ProjectCombinedCostingSheetInformationBasicInformationGateway(projectCostingSheetInformationTDS);
            string state = projectCostingSheetInformationBasicInformationGateway.GetState(Int32.Parse(hdfCostingSheetId.Value));

            if (state == "In Progress")
            {
                tkrmTop.Items[3].Visible = false; //Set In Progress
                tkrmTop.Items[4].Visible = true; //Set Approved
            }

            if (state == "Approved")
            {
                tkrmTop.Items[3].Visible = false; //Set In Progress
                tkrmTop.Items[4].Visible = false; //Set Approved

                if (!Convert.ToBoolean(Session["sgLFS_PROJECTS_COSTINGSHEETS_ADMIN"]))
                {
                    tkrmTop.Items[0].Visible = false; //Edit
                    tkrmTop.Items[1].Visible = false; //Delete
                }
            }

            // Validate grid columns
            int projectId = Int32.Parse(hdfProjectId.Value);
            ProjectGateway projectGateway = new ProjectGateway();
            projectGateway.LoadByProjectId(projectId);

            grdTeamMembers.Columns[11].Visible = false;
            grdTeamMembers.Columns[12].Visible = false;
            grdTeamMembers.Columns[13].Visible = false;
            grdTeamMembers.Columns[14].Visible = false;
            grdTeamMembers.Columns[16].Visible = false;
            grdTeamMembers.Columns[17].Visible = false;
            grdTeamMembers.Columns[20].Visible = false;
            grdTeamMembers.Columns[21].Visible = false;

            if (projectGateway.GetCountryID(projectId) == 1) //Canada
            {
                // Team Members Grid
                grdTeamMembers.Columns[15].Visible = true;
                grdTeamMembers.Columns[18].Visible = true;
                grdTeamMembers.Columns[19].Visible = false;
                grdTeamMembers.Columns[22].Visible = false;  
                
                // Units Grid
                grdUnits.Columns[12].Visible = true;
                grdUnits.Columns[13].Visible = true;
                grdUnits.Columns[14].Visible = false;
                grdUnits.Columns[15].Visible = false;

                grdUnits.Columns[12].Visible = true;
                grdUnits.Columns[13].Visible = true;
                grdUnits.Columns[14].Visible = false;
                grdUnits.Columns[15].Visible = false;

                grdSubcontractors.Columns[9].Visible = true;
                grdSubcontractors.Columns[10].Visible = true;
                grdSubcontractors.Columns[11].Visible = false;
                grdSubcontractors.Columns[12].Visible = false;

                // Materials grid
                grdMaterials.Columns[10].Visible = true;
                grdMaterials.Columns[11].Visible = true;
                grdMaterials.Columns[12].Visible = false;
                grdMaterials.Columns[13].Visible = false;

                // Other costs
                grdOtherCosts.Columns[9].Visible = true;
                grdOtherCosts.Columns[10].Visible = true;
                grdOtherCosts.Columns[11].Visible = false;
                grdOtherCosts.Columns[12].Visible = false;

                // Totals
                lblGrandTotalCost.Text = "Total Cost (CAD) : ";                
                tbxTotalCostCad.Visible = true;
                tbxTotalCostUsd.Visible = false;

                lblTeamMembersTotalCost.Text = "Total Cost (CAD) : ";
                tbxTeamMembersTotalCostCAD.Visible = true;
                tbxTeamMembersTotalCostUSD.Visible = false;
                
                lblUnitsTotalCosts.Text = "Total Cost (CAD) : ";
                tbxUnitsTotalCostsCAD.Visible = true;
                tbxUnitsTotalCostsUSD.Visible = false;

                lblMaterialsTotalCosts.Text = "Total Cost (CAD) : ";
                tbxMaterialsTotalCostsCAD.Visible = true;
                tbxMaterialsTotalCostsUSD.Visible = false;

                lblOtherCostsTotalCosts.Text = "Total Cost (CAD) : ";
                tbxOtherCostsTotalCostsCAD.Visible = true;
                tbxOtherCostsTotalCostsUSD.Visible = false;

                lblSubcontractorsTotalCosts.Text = "Total Cost (CAD) : ";
                tbxSubcontractorsTotalCostsCAD.Visible = true;
                tbxSubcontractorsTotalCostsUSD.Visible = false;

                lblGrandTotal.Text = "Grand Total (CAD)";
            }
            else
            {
                if (projectGateway.GetCountryID(projectId) == 2) //USA
                {
                    // Team Members Grid
                    grdTeamMembers.Columns[15].Visible = false;
                    grdTeamMembers.Columns[18].Visible = false;
                    grdTeamMembers.Columns[19].Visible = true;
                    grdTeamMembers.Columns[22].Visible = true;

                    // Units Grid
                    grdUnits.Columns[12].Visible = false;
                    grdUnits.Columns[13].Visible = false;
                    grdUnits.Columns[14].Visible = true;
                    grdUnits.Columns[15].Visible = true;

                    grdSubcontractors.Columns[9].Visible = false;
                    grdSubcontractors.Columns[10].Visible = false;
                    grdSubcontractors.Columns[11].Visible = true;
                    grdSubcontractors.Columns[12].Visible = true;

                    // Materials grid
                    grdMaterials.Columns[10].Visible = false;
                    grdMaterials.Columns[11].Visible = false;
                    grdMaterials.Columns[12].Visible = true;
                    grdMaterials.Columns[13].Visible = true;

                    // Other costs
                    grdOtherCosts.Columns[9].Visible = false;
                    grdOtherCosts.Columns[10].Visible = false;
                    grdOtherCosts.Columns[11].Visible = true;
                    grdOtherCosts.Columns[12].Visible = true;

                    // Totals
                    lblGrandTotalCost.Text = "Total Cost (USD) : ";
                    tbxTotalCostCad.Visible = false;
                    tbxTotalCostUsd.Visible = true;

                    lblTeamMembersTotalCost.Text = "Total Cost (USD) : ";
                    tbxTeamMembersTotalCostCAD.Visible = false;
                    tbxTeamMembersTotalCostUSD.Visible = true;

                    lblUnitsTotalCosts.Text = "Total Cost (USD) : ";
                    tbxUnitsTotalCostsCAD.Visible = false;
                    tbxUnitsTotalCostsUSD.Visible = true;

                    lblSubcontractorsTotalCosts.Text = "Total Cost (USD) : ";
                    tbxSubcontractorsTotalCostsCAD.Visible = false;
                    tbxSubcontractorsTotalCostsUSD.Visible = true;

                    lblMaterialsTotalCosts.Text = "Total Cost (USD) : ";
                    tbxMaterialsTotalCostsCAD.Visible = false;
                    tbxMaterialsTotalCostsUSD.Visible = true;

                    lblOtherCostsTotalCosts.Text = "Total Cost (USD) : ";
                    tbxOtherCostsTotalCostsCAD.Visible = false;
                    tbxOtherCostsTotalCostsUSD.Visible = true;

                    lblGrandTotal.Text = "Grand Total (USD)";
                }
            }

            if (projectGateway.GetProjectType(Int32.Parse(hdfProjectId.Value)) == "Proposal")
            {
                tkrpbLeftMenuCurrentProject.Items[0].Text = "Current Proposal";
                tkrpbLeftMenuCurrentProject.Items[0].Items[0].Text = "Proposal";

                lblTitleProject.Text = " > Proposal: ";

                tkrpbLeftMenuCurrentProject.Items[0].Items[3].Visible = false; //mSections
                tkrpbLeftMenuCurrentProject.Items[0].Items[4].Visible = false; //mTools
                tkrpbLeftMenuCurrentProject.Items[0].Items[5].Visible = false; //mSeparator   
            }

            if (projectGateway.GetProjectType(Int32.Parse(hdfProjectId.Value)) == "Project")
            {
                tkrpbLeftMenuCurrentProject.Items[0].Text = "Current Project";
                tkrpbLeftMenuCurrentProject.Items[0].Items[0].Text = "Project";

                lblTitleProject.Text = " > Project: ";
            }

            if (projectGateway.GetProjectType(Int32.Parse(hdfProjectId.Value)) == "Internal")
            {
                tkrpbLeftMenuCurrentProject.Items[0].Text = "Current Internal Project";
                tkrpbLeftMenuCurrentProject.Items[0].Items[0].Text = "Internal Project";

                lblTitleProject.Text = " > Internal Project: ";

                tkrpbLeftMenuCurrentProject.Items[0].Items[3].Visible = false; //mSections
                tkrpbLeftMenuCurrentProject.Items[0].Items[4].Visible = false; //mTools
                tkrpbLeftMenuCurrentProject.Items[0].Items[5].Visible = false; //mSeparator   
            }

            if (projectGateway.GetProjectType(int.Parse(hdfProjectId.Value)) == "Ballpark")
            {
                tkrpbLeftMenuCurrentProject.Items[0].Text = "Current Ballpark";
                tkrpbLeftMenuCurrentProject.Items[0].Items[0].Text = "Ballpark";

                lblTitleProject.Text = " > Ballpark: ";

                tkrpbLeftMenuCurrentProject.Items[0].Items[3].Visible = false; //mSections
                tkrpbLeftMenuCurrentProject.Items[0].Items[4].Visible = false; //mTools
                tkrpbLeftMenuCurrentProject.Items[0].Items[5].Visible = false; //mSeparator   
            }

            // Security check
            if (!Convert.ToBoolean(Session["sgLFS_PROJECTS_ADMIN"]))
            {
                tkrpbLeftMenuReports.Visible = false;
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATOR EVENTS
        //

        protected void tkrmTop_ItemClick(object sender, RadMenuEventArgs e)
        {
            string url = "";

            switch (e.Item.Value)
            {
                case "mEdit":
                    url = "./project_combined_costing_sheets_edit.aspx?source_page=project_combined_costing_sheets_summary.aspx&costing_sheet_id=" + hdfCostingSheetId.Value + "&project_id=" + hdfProjectId.Value + "&active_tab=" + (string)ViewState["active_tab"] + GetNavigatorState() + "&origin=" + (string)ViewState["origin"] + "&update=" + (string)ViewState["update"] + "&data_changed=" + hdfDataChanged.Value + "&state=" + (string)ViewState["state"];
                    break;

                case "mApprove":
                    url = "./project_combined_costing_sheets_state.aspx?source_page=project_combined_costing_sheets_summary.aspx&costing_sheet_id=" + hdfCostingSheetId.Value + "&project_id=" + hdfProjectId.Value + "&costing_sheet_state=Approved&active_tab=" + (string)ViewState["active_tab"] + GetNavigatorState() + "&origin=" + (string)ViewState["origin"] + "&update=" + (string)ViewState["update"] + "&data_changed=" + hdfDataChanged.Value + "&state=" + (string)ViewState["state"];
                    break;

                case "mSetInProgress":
                    url = "./project_combined_costing_sheets_state.aspx?source_page=project_combined_costing_sheets_summary.aspx&costing_sheet_id=" + hdfCostingSheetId.Value + "&project_id=" + hdfProjectId.Value + "&costing_sheet_state=In Progress&active_tab=" + (string)ViewState["active_tab"] + GetNavigatorState() + "&origin=" + (string)ViewState["origin"] + "&update=" + (string)ViewState["update"] + "&data_changed=" + hdfDataChanged.Value + "&state=" + (string)ViewState["state"];
                    break;

                case "mLastSearch":
                    url = "./project_costing_sheets_navigator.aspx?source_page=project_summary.aspx&project_id=" + hdfProjectId.Value + "&active_tab=" + (string)ViewState["active_tab"] + GetNavigatorState() + "&origin=" + (string)ViewState["origin"] + "&update=" + (string)ViewState["update"] + "&data_changed=" + hdfDataChanged.Value + "&state=" + (string)ViewState["state"];
                    break;

                case "mDelete":
                    url = "./project_combined_costing_sheets_delete.aspx?source_page=project_combined_costing_sheets_summary.aspx&costing_sheet_id=" + hdfCostingSheetId.Value + "&project_id=" + hdfProjectId.Value + "&active_tab=" + (string)ViewState["active_tab"] + GetNavigatorState() + "&origin=" + (string)ViewState["origin"] + "&update=" + (string)ViewState["update"] + "&data_changed=" + hdfDataChanged.Value + "&state=" + (string)ViewState["state"];
                    break;
            }

            if (url != "") Response.Redirect(url);
        }






        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATION EVENTS
        //

        protected void tkrpbLeftMenu_ItemClick(object sender, RadPanelBarEventArgs e)
        {
            string url = "";

            switch (e.Item.Value)
            {
                case "mSections":
                    url = "./project_sections_navigator.aspx?source_page=lm&project_id=" + hdfProjectId.Value + "&active_tab=" + (string)ViewState["active_tab"] + GetNavigatorState() + "&origin=" + (string)ViewState["origin"] + "&update=" + (string)ViewState["update"] + "&data_changed=" + hdfDataChanged.Value + "&state=" + (string)ViewState["state"];
                    break;

                case "mProject":
                    if (ViewState["state"].ToString() == "summary")
                    {
                        url = "./project_summary.aspx?source_page=lm&project_id=" + hdfProjectId.Value + "&active_tab=" + (string)ViewState["active_tab"] + GetNavigatorState() + "&update=" + (string)ViewState["update"] + "&state=" + (string)ViewState["state"];
                    }

                    if (ViewState["state"].ToString() == "edit")
                    {
                        url = "./project_edit.aspx?source_page=lm&project_id=" + hdfProjectId.Value + "&active_tab=" + (string)ViewState["active_tab"] + GetNavigatorState() + "&origin=" + (string)ViewState["origin"] + "&update=" + (string)ViewState["update"] + "&data_changed=" + hdfDataChanged.Value + "&state=" + (string)ViewState["state"];
                    }
                    break;

                case "mProjectCostingSheets":
                    url = "./project_costing_sheets_navigator.aspx?source_page=project_summary.aspx&project_id=" + hdfProjectId.Value + "&active_tab=" + (string)ViewState["active_tab"] + GetNavigatorState() + "&origin=" + (string)ViewState["origin"] + "&update=" + (string)ViewState["update"] + "&data_changed=" + hdfDataChanged.Value + "&state=" + (string)ViewState["state"];
                    break;

                case "mSearch":
                    url = "./projects.aspx?source_page=lm";
                    break;
            }

            if (url != "") Response.Redirect(url);
        }






        // ////////////////////////////////////////////////////////////////////////
        // METHODS
        //

        private void LoadBasicData()
        {
            int costingSheetId = Int32.Parse(hdfCostingSheetId.Value);

            ProjectCombinedCostingSheetInformationBasicInformationGateway projectCostingSheetInformationBasicInformationGateway = new ProjectCombinedCostingSheetInformationBasicInformationGateway(projectCostingSheetInformationTDS);
            if (projectCostingSheetInformationBasicInformationGateway.Table.Rows.Count > 0)
            {
                // Load costing sheet basic data
                tbxState.Text = projectCostingSheetInformationBasicInformationGateway.GetState(costingSheetId);
                tbxTeamMembersTotalCostCAD.Text = Math.Round(projectCostingSheetInformationBasicInformationGateway.GetTotalLabourHoursCad(costingSheetId), 2).ToString();
                tbxTeamMembersTotalCostUSD.Text = Math.Round(projectCostingSheetInformationBasicInformationGateway.GetTotalLabourHoursUsd(costingSheetId), 2).ToString();
                tbxUnitsTotalCostsCAD.Text = Math.Round(projectCostingSheetInformationBasicInformationGateway.GetTotalUnitsCad(costingSheetId), 2).ToString();
                tbxUnitsTotalCostsUSD.Text = Math.Round(projectCostingSheetInformationBasicInformationGateway.GetTotalUnitsUsd(costingSheetId), 2).ToString();
                tbxMaterialsTotalCostsCAD.Text = Math.Round(projectCostingSheetInformationBasicInformationGateway.GetTotalMaterialsCad(costingSheetId), 2).ToString();
                tbxMaterialsTotalCostsUSD.Text = Math.Round(projectCostingSheetInformationBasicInformationGateway.GetTotalMaterialsUsd(costingSheetId), 2).ToString();
                tbxOtherCostsTotalCostsCAD.Text = Math.Round(projectCostingSheetInformationBasicInformationGateway.GetTotalOtherCostsCad(costingSheetId), 2).ToString();
                tbxOtherCostsTotalCostsUSD.Text = Math.Round(projectCostingSheetInformationBasicInformationGateway.GetTotalOtherCostsUsd(costingSheetId), 2).ToString();
                tbxSubcontractorsTotalCostsCAD.Text = Math.Round(projectCostingSheetInformationBasicInformationGateway.GetTotalSubcontractorsCad(costingSheetId), 2).ToString();
                tbxSubcontractorsTotalCostsUSD.Text = Math.Round(projectCostingSheetInformationBasicInformationGateway.GetTotalSubcontractorsUsd(costingSheetId), 2).ToString();
                tbxTotalCostCad.Text = Math.Round(projectCostingSheetInformationBasicInformationGateway.GetGrandTotalCad(costingSheetId), 2).ToString();
                tbxTotalCostUsd.Text = Math.Round(projectCostingSheetInformationBasicInformationGateway.GetGrandTotalUsd(costingSheetId), 2).ToString();

                // Validate grid columns
                int projectId = Int32.Parse(hdfProjectId.Value);
                ProjectGateway projectGateway = new ProjectGateway();
                projectGateway.LoadByProjectId(projectId);

                if (projectGateway.GetCountryID(projectId) == 1) //Canada
                {
                    tbxGrandTotal.Text = Math.Round(projectCostingSheetInformationBasicInformationGateway.GetGrandTotalCad(costingSheetId), 2).ToString();
                }
                else
                {
                    tbxGrandTotal.Text = Math.Round(projectCostingSheetInformationBasicInformationGateway.GetGrandTotalUsd(costingSheetId), 2).ToString();
                }

                tbxGrandRevenue.Text = Math.Round(projectCostingSheetInformationBasicInformationGateway.GetGrandRevenue(costingSheetId), 2).ToString();
                tbxRevenueTotal.Text = Math.Round(projectCostingSheetInformationBasicInformationGateway.GetGrandRevenue(costingSheetId), 2).ToString();
                tbxGrandProfit.Text = Math.Round(projectCostingSheetInformationBasicInformationGateway.GetGrandProfit(costingSheetId), 2).ToString();
                tbxGrandGrossMargin.Text = Math.Round(projectCostingSheetInformationBasicInformationGateway.GetGrandGrossMargin(costingSheetId), 2).ToString() + " %";
            }
        }



        private void RegisterClientScripts()
        {
            string contentVariables = "";
            contentVariables += "var hdfCostingSheetIdId = '" + hdfCostingSheetId.ClientID + "';";
            contentVariables += "var hdfProjectIdId = '" + hdfProjectId.ClientID + "';";
            contentVariables += "var hdfClientIdId = '" + hdfClientId.ClientID + "';";
            contentVariables += "var hdfDataChangedId = '" + hdfDataChanged.ClientID + "';";
            contentVariables += "var hdfDataChangedMessageId = '" + hdfDataChangedMessage.ClientID + "';";
            contentVariables += "var hdfBeforeUnloadOrigenId = '" + hdfBeforeUnloadOrigen.ClientID + "';";

            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./project_combined_costing_sheets_summary.js");
        }



        private void StoreNavigatorState()
        {
            ViewState["navigatorState"] = "&search_projectnumber=" + Request.QueryString["search_projectnumber"] + "&search_projectname=" + Request.QueryString["search_projectname"] + "&search_client=" + Request.QueryString["search_client"] + "&search_type=" + Request.QueryString["search_type"] + "&search_state=" + Request.QueryString["search_state"];
        }



        private string GetNavigatorState()
        {
            return (string)ViewState["navigatorState"];
        }



        protected void grdSubcontractors_DataBound(object sender, EventArgs e)
        {
            SubcontractorsInformationEmptyFix(grdSubcontractors);
        }



        protected void grdSubcontractors_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
        }



        public ProjectCostingSheetInformationTDS.CombinedSubcontractorsInformationDataTable GetSubcontractorsInformation()
        {
            subcontractorsInformation = (ProjectCostingSheetInformationTDS.CombinedSubcontractorsInformationDataTable)Session["subcontractorsInformationDummy"];

            if (subcontractorsInformation == null)
            {
                subcontractorsInformation = (ProjectCostingSheetInformationTDS.CombinedSubcontractorsInformationDataTable)Session["subcontractorsInformation"];
            }

            return subcontractorsInformation;
        }



        protected void SubcontractorsInformationEmptyFix(GridView grdView)
        {
            if (grdView.Rows.Count == 0)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                ProjectCostingSheetInformationTDS.CombinedSubcontractorsInformationDataTable dt = new ProjectCostingSheetInformationTDS.CombinedSubcontractorsInformationDataTable();
                dt.AddCombinedSubcontractorsInformationRow(0, 0, 0, "", 0, 0, 0, 0, 0, false, companyId, false, "", DateTime.Now, DateTime.Now, "", 0, "");
                Session["subcontractorsInformationDummy"] = dt;

                grdView.DataBind();
            }

            // Normally executes at all postbacks
            if (grdView.Rows.Count == 1)
            {
                ProjectCostingSheetInformationTDS.CombinedSubcontractorsInformationDataTable dt = (ProjectCostingSheetInformationTDS.CombinedSubcontractorsInformationDataTable)Session["subcontractorsInformationDummy"];
                if (dt != null)
                {
                    // Hide row
                    grdView.Rows[0].Visible = false;
                    grdView.Rows[0].Controls.Clear();
                }
            }
        }
        
        

        protected void grdMaterials_DataBound(object sender, EventArgs e)
        {
            MaterialsInformationEmptyFix(grdMaterials);
        }



        protected void grdMaterials_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
        }



        protected void MaterialsInformationEmptyFix(GridView grdView)
        {
            if (grdView.Rows.Count == 0)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                ProjectCostingSheetInformationTDS.CombinedMaterialsInformationDataTable dt = new ProjectCostingSheetInformationTDS.CombinedMaterialsInformationDataTable();
                dt.AddCombinedMaterialsInformationRow(0, 0, 0, 0, 0, 0, 0, 0, false, companyId, false, "", "", "", DateTime.Now, DateTime.Now, "", "", 0, "");
                Session["materialsInformationDummy"] = dt;

                grdView.DataBind();
            }

            // Normally executes at all postbacks
            if (grdView.Rows.Count == 1)
            {
                ProjectCostingSheetInformationTDS.CombinedMaterialsInformationDataTable dt = (ProjectCostingSheetInformationTDS.CombinedMaterialsInformationDataTable)Session["materialsInformationDummy"];
                if (dt != null)
                {
                    // Hide row
                    grdView.Rows[0].Visible = false;
                    grdView.Rows[0].Controls.Clear();
                }
            }
        }



        public ProjectCostingSheetInformationTDS.CombinedMaterialsInformationDataTable GetMaterialsInformation()
        {
            materialsInformation = (ProjectCostingSheetInformationTDS.CombinedMaterialsInformationDataTable)Session["materialsInformationDummy"];

            if (materialsInformation == null)
            {
                materialsInformation = (ProjectCostingSheetInformationTDS.CombinedMaterialsInformationDataTable)Session["materialsInformation"];
            }

            return materialsInformation;
        }



        protected void grdOtherCosts_DataBound(object sender, EventArgs e)
        {
            OtherCostsInformationEmptyFix(grdOtherCosts);
        }



        protected void grdOtherCosts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            
        }



        public ProjectCostingSheetInformationTDS.CombinedOtherCostsInformationDataTable GetOtherCostsnformation()
        {
            otherCostsInformation = (ProjectCostingSheetInformationTDS.CombinedOtherCostsInformationDataTable)Session["otherCostsInformationDummy"];

            if (otherCostsInformation == null)
            {
                otherCostsInformation = (ProjectCostingSheetInformationTDS.CombinedOtherCostsInformationDataTable)Session["otherCostsInformation"];
            }

            return otherCostsInformation;
        }


        
        protected void OtherCostsInformationEmptyFix(GridView grdView)
        {
            if (grdView.Rows.Count == 0)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                ProjectCostingSheetInformationTDS.CombinedOtherCostsInformationDataTable dt = new ProjectCostingSheetInformationTDS.CombinedOtherCostsInformationDataTable();
                dt.AddCombinedOtherCostsInformationRow(0, 0, "", "", "", "", 0, 0, 0, 0, 0, false, companyId, false, "", DateTime.Now, DateTime.Now, 0, "");
                Session["otherCostsInformationDummy"] = dt;

                grdView.DataBind();
            }

            // Normally executes at all postbacks
            if (grdView.Rows.Count == 1)
            {
                ProjectCostingSheetInformationTDS.CombinedOtherCostsInformationDataTable dt = (ProjectCostingSheetInformationTDS.CombinedOtherCostsInformationDataTable)Session["otherCostsInformationDummy"];
                if (dt != null)
                {
                    // Hide row
                    grdView.Rows[0].Visible = false;
                    grdView.Rows[0].Controls.Clear();
                }
            }
        }



        public ProjectCostingSheetInformationTDS.CombinedOtherCostsInformationDataTable GetOtherCostsInformation()
        {
            otherCostsInformation = (ProjectCostingSheetInformationTDS.CombinedOtherCostsInformationDataTable)Session["otherCostsInformationDummy"];

            if (otherCostsInformation == null)
            {
                otherCostsInformation = (ProjectCostingSheetInformationTDS.CombinedOtherCostsInformationDataTable)Session["otherCostsInformation"];
            }

            return otherCostsInformation;
        }



        protected void grdTeamMembers_DataBound(object sender, EventArgs e)
        {
            LabourHoursInformationEmptyFix(grdTeamMembers);
        }



        protected void LabourHoursInformationEmptyFix(GridView grdView)
        {
            if (grdView.Rows.Count == 0)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                ProjectCostingSheetInformationTDS.CombinedLabourHoursInformationDataTable dt = new ProjectCostingSheetInformationTDS.CombinedLabourHoursInformationDataTable();
                dt.AddCombinedLabourHoursInformationRow(0, "", 0, 0, 0, "", "", 0, "", 0, 0, 0, 0, 0, 0, 0, 0, 0, false, companyId, false, "", DateTime.Now, DateTime.Now, "", "", 0, "");
                Session["labourHoursInformationDummy"] = dt;

                grdView.DataBind();
            }

            // Normally executes at all postbacks
            if (grdView.Rows.Count == 1)
            {
                ProjectCostingSheetInformationTDS.CombinedLabourHoursInformationDataTable dt = (ProjectCostingSheetInformationTDS.CombinedLabourHoursInformationDataTable)Session["labourHoursInformationDummy"];
                if (dt != null)
                {
                    // Hide row
                    grdView.Rows[0].Visible = false;
                    grdView.Rows[0].Controls.Clear();
                }
            }
        }



        public ProjectCostingSheetInformationTDS.CombinedLabourHoursInformationDataTable GetLabourHoursInformation()
        {
            labourHoursInformation = (ProjectCostingSheetInformationTDS.CombinedLabourHoursInformationDataTable)Session["labourHoursInformationDummy"];

            if (labourHoursInformation == null)
            {
                labourHoursInformation = (ProjectCostingSheetInformationTDS.CombinedLabourHoursInformationDataTable)Session["labourHoursInformation"];
            }

            return labourHoursInformation;           
        }
               


        protected void grdUnits_DataBound(object sender, EventArgs e)
        {
            UnitsInformationEmptyFix(grdUnits);
        }



        protected void grdUnits_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
           
        }



        protected void UnitsInformationEmptyFix(GridView grdView)
        {
            if (grdView.Rows.Count == 0)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                ProjectCostingSheetInformationTDS.CombinedUnitsInformationDataTable dt = new ProjectCostingSheetInformationTDS.CombinedUnitsInformationDataTable();
                dt.AddCombinedUnitsInformationRow(0, "", 0, 0, "", 0, 0, 0, 0, 0, false, companyId, false, "", "", DateTime.Now, DateTime.Now, "", "", 0, "");
                Session["unitsInformationDummy"] = dt;

                grdView.DataBind();
            }

            // Normally executes at all postbacks
            if (grdView.Rows.Count == 1)
            {
                ProjectCostingSheetInformationTDS.CombinedUnitsInformationDataTable dt = (ProjectCostingSheetInformationTDS.CombinedUnitsInformationDataTable)Session["unitsInformationDummy"];
                if (dt != null)
                {
                    // Hide row
                    grdView.Rows[0].Visible = false;
                    grdView.Rows[0].Controls.Clear();
                }
            }
        }



        public ProjectCostingSheetInformationTDS.CombinedUnitsInformationDataTable GetUnitsInformation()
        {
            unitsInformation = (ProjectCostingSheetInformationTDS.CombinedUnitsInformationDataTable)Session["unitsInformationDummy"];

            if (unitsInformation == null)
            {
                unitsInformation = (ProjectCostingSheetInformationTDS.CombinedUnitsInformationDataTable)Session["unitsInformation"];
            }

            return unitsInformation;
        }



        protected void grdRevenue_DataBound(object sender, EventArgs e)
        {
            RevenueInformationEmptyFix(grdRevenue);
        }



        protected void grdRevenue_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
        }



        protected void RevenueInformationEmptyFix(GridView grdView)
        {
            if (grdView.Rows.Count == 0)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                ProjectCostingSheetInformationTDS.CombinedRevenueInformationDataTable dt = new ProjectCostingSheetInformationTDS.CombinedRevenueInformationDataTable();
                dt.AddCombinedRevenueInformationRow(0, 0, 0, "", companyId, DateTime.Now, DateTime.Now, false, false, 0, "");
                Session["revenueInformationDummy"] = dt;

                grdView.DataBind();
            }

            // Normally executes at all postbacks
            if (grdView.Rows.Count == 1)
            {
                ProjectCostingSheetInformationTDS.CombinedRevenueInformationDataTable dt = (ProjectCostingSheetInformationTDS.CombinedRevenueInformationDataTable)Session["revenueInformationDummy"];
                if (dt != null)
                {
                    // Hide row
                    grdView.Rows[0].Visible = false;
                    grdView.Rows[0].Controls.Clear();
                }
            }
        }



        public ProjectCostingSheetInformationTDS.CombinedRevenueInformationDataTable GetRevenueInformation()
        {
            revenueInformation = (ProjectCostingSheetInformationTDS.CombinedRevenueInformationDataTable)Session["revenueInformationDummy"];

            if (revenueInformation == null)
            {
                revenueInformation = (ProjectCostingSheetInformationTDS.CombinedRevenueInformationDataTable)Session["revenueInformation"];
            }

            return revenueInformation;
        }

        
        
    }
}