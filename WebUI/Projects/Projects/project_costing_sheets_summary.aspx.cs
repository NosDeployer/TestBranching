using System;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.BL.Projects.Projects;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.DA.Resources.Companies;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.Projects.Projects
{
    /// <summary>
    /// project_costing_sheets_summary
    /// </summary>
    public partial class project_costing_sheets_summary : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected ProjectTDS projectTDS;
        protected ProjectCostingSheetInformationTDS projectCostingSheetInformationTDS;
        protected ProjectCostingSheetInformationTDS.LabourHoursInformationDataTable labourHoursInformation;
        protected ProjectCostingSheetInformationTDS.UnitsInformationDataTable unitsInformation;        
        protected ProjectCostingSheetInformationTDS.MaterialsInformationDataTable materialsInformation;
        protected ProjectCostingSheetInformationTDS.OtherCostsInformationDataTable otherCostsInformation;
        protected ProjectCostingSheetInformationTDS.RevenueInformationDataTable revenueInformation;
        protected ProjectCostingSheetInformationTDS.SubcontractorsInformationDataTable subcontractorsInformation;
        protected ProjectCostingSheetInformationTDS.HotelsInformationDataTable hotelsInformation;
        protected ProjectCostingSheetInformationTDS.BondingsInformationDataTable bondingsInformation;
        protected ProjectCostingSheetInformationTDS.InsurancesInformationDataTable insurancesInformation;
        protected ProjectCostingSheetInformationTDS.OtherCategoryInformationDataTable otherCategoryInformation;
                





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
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in project_costing_sheets_summary.aspx");
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
                Session.Remove("materialsInformationDummy");
                Session.Remove("otherCostsInformationDummy");
                Session.Remove("revenueInformationDummy");

                Session.Remove("subcontractorsInformationDummy");
                Session.Remove("hotelsInformationDummy");
                Session.Remove("bondingsInformationDummy");
                Session.Remove("insurancesInformationDummy");
                Session.Remove("otherCategoryInformationDummy");
                
                // If coming from project_costing_sheets_navigator.aspx or project_costing_sheets_add.aspx
                if (Request.QueryString["source_page"] == "project_costing_sheets_navigator.aspx" || Request.QueryString["source_page"] == "project_costing_sheets_add.aspx")
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
                    labourHoursInformation = new ProjectCostingSheetInformationTDS.LabourHoursInformationDataTable();
                    unitsInformation = new ProjectCostingSheetInformationTDS.UnitsInformationDataTable();                    
                    materialsInformation = new ProjectCostingSheetInformationTDS.MaterialsInformationDataTable();
                    otherCostsInformation = new ProjectCostingSheetInformationTDS.OtherCostsInformationDataTable();
                    revenueInformation = new ProjectCostingSheetInformationTDS.RevenueInformationDataTable();

                    subcontractorsInformation = new ProjectCostingSheetInformationTDS.SubcontractorsInformationDataTable();
                    hotelsInformation = new ProjectCostingSheetInformationTDS.HotelsInformationDataTable();
                    bondingsInformation = new ProjectCostingSheetInformationTDS.BondingsInformationDataTable();
                    insurancesInformation = new ProjectCostingSheetInformationTDS.InsurancesInformationDataTable();
                    otherCategoryInformation = new ProjectCostingSheetInformationTDS.OtherCategoryInformationDataTable();
                                       
                    // Get General Data
                    ProjectCostingSheetInformationBasicInformation projectCostingSheetInformationBasicInformation = new ProjectCostingSheetInformationBasicInformation(projectCostingSheetInformationTDS);
                    projectCostingSheetInformationBasicInformation.LoadByCostingSheetId(costingSheetId, companyId);

                    ProjectCostingSheetInformationLabourHoursInformationGateway projectCostingSheetInformationLabourHoursInformationGateway = new ProjectCostingSheetInformationLabourHoursInformationGateway(projectCostingSheetInformationTDS);
                    projectCostingSheetInformationLabourHoursInformationGateway.LoadByCostingSheetId(costingSheetId, companyId);

                    ProjectCostingSheetInformationUnitsInformationGateway projectCostingSheetInformationUnitsInformationGateway = new ProjectCostingSheetInformationUnitsInformationGateway(projectCostingSheetInformationTDS);
                    projectCostingSheetInformationUnitsInformationGateway.LoadByCostingSheetId(costingSheetId, companyId);                    

                    ProjectCostingSheetInformationMaterialsInformationGateway projectCostingSheetInformationMaterialsInformationGateway = new ProjectCostingSheetInformationMaterialsInformationGateway(projectCostingSheetInformationTDS);
                    projectCostingSheetInformationMaterialsInformationGateway.LoadByCostingSheetId(costingSheetId, companyId);

                    ProjectCostingSheetInformationOtherCostsInformationGateway projectCostingSheetInformationOtherCostsInformationGateway = new ProjectCostingSheetInformationOtherCostsInformationGateway(projectCostingSheetInformationTDS);
                    projectCostingSheetInformationOtherCostsInformationGateway.LoadByCostingSheetId(costingSheetId, companyId);

                    projectCostingSheetInformationRevenueInformationGateway projectCostingSheetInformationRevenueInformationGateway = new projectCostingSheetInformationRevenueInformationGateway(projectCostingSheetInformationTDS);
                    projectCostingSheetInformationRevenueInformationGateway.LoadByCostingSheetId(costingSheetId, companyId);

                    ProjectCostingSheetInformationSubcontractorsInformationGateway projectCostingSheetInformationSubcontractorsInformationGateway = new ProjectCostingSheetInformationSubcontractorsInformationGateway(projectCostingSheetInformationTDS);
                    projectCostingSheetInformationSubcontractorsInformationGateway.LoadByCostingSheetId(costingSheetId, companyId);

                    ProjectCostingSheetInformationHotelsInformationGateway projectCostingSheetInformationHotelsInformationGateway = new ProjectCostingSheetInformationHotelsInformationGateway(projectCostingSheetInformationTDS);
                    projectCostingSheetInformationHotelsInformationGateway.LoadByCostingSheetId(costingSheetId, companyId);

                    ProjectCostingSheetInformationBondingsInformationGateway projectCostingSheetInformationBondingsInformationGateway = new ProjectCostingSheetInformationBondingsInformationGateway(projectCostingSheetInformationTDS);
                    projectCostingSheetInformationBondingsInformationGateway.LoadByCostingSheetId(costingSheetId, companyId);

                    ProjectCostingSheetInformationInsurancesInformationGateway projectCostingSheetInformationInsurancesInformationGateway = new ProjectCostingSheetInformationInsurancesInformationGateway(projectCostingSheetInformationTDS);
                    projectCostingSheetInformationInsurancesInformationGateway.LoadByCostingSheetId(costingSheetId, companyId);

                    ProjectCostingSheetInformationOtherCategoryInformationGateway projectCostingSheetInformationOtherCategoryInformationGateway = new ProjectCostingSheetInformationOtherCategoryInformationGateway(projectCostingSheetInformationTDS);
                    projectCostingSheetInformationOtherCategoryInformationGateway.LoadByCostingSheetId(costingSheetId, companyId);

                    Session["lfsProjectTDS"] = projectTDS;
                    Session["projectCostingSheetInformationTDS"] = projectCostingSheetInformationTDS;
                    Session["labourHoursInformation"] = projectCostingSheetInformationTDS.LabourHoursInformation;
                    Session["unitsInformation"] = projectCostingSheetInformationTDS.UnitsInformation;                    
                    Session["materialsInformation"] = projectCostingSheetInformationTDS.MaterialsInformation;
                    Session["otherCostsInformation"] = projectCostingSheetInformationTDS.OtherCostsInformation;
                    Session["revenueInformation"] = projectCostingSheetInformationTDS.RevenueInformation;

                    Session["subcontractorsInformation"] = projectCostingSheetInformationTDS.SubcontractorsInformation;
                    Session["hotelsInformation"] = projectCostingSheetInformationTDS.HotelsInformation;
                    Session["bondingsInformation"] = projectCostingSheetInformationTDS.BondingsInformation;
                    Session["insurancesInformation"] = projectCostingSheetInformationTDS.InsurancesInformation;
                    Session["otherCategoryInformation"] = projectCostingSheetInformationTDS.OtherCategoryInformation;

                    labourHoursInformation = projectCostingSheetInformationTDS.LabourHoursInformation;
                    unitsInformation = projectCostingSheetInformationTDS.UnitsInformation;                    
                    materialsInformation = projectCostingSheetInformationTDS.MaterialsInformation;
                    otherCostsInformation = projectCostingSheetInformationTDS.OtherCostsInformation;
                    revenueInformation = projectCostingSheetInformationTDS.RevenueInformation;

                    subcontractorsInformation = projectCostingSheetInformationTDS.SubcontractorsInformation;
                    hotelsInformation = projectCostingSheetInformationTDS.HotelsInformation;
                    bondingsInformation = projectCostingSheetInformationTDS.BondingsInformation;
                    insurancesInformation = projectCostingSheetInformationTDS.InsurancesInformation;
                    otherCategoryInformation = projectCostingSheetInformationTDS.OtherCategoryInformation;
                }

                // ... project_costing_sheets_add.aspx
                if (Request.QueryString["source_page"] == "project_costing_sheets_add.aspx")
                {
                    ViewState["update"] = "yes";
                }

                // ... left menu, project_costing_sheets_edit.aspx, project_costing_sheets_delete.aspx or project_costing_sheets_state.aspx
                if ((Request.QueryString["source_page"] == "lm") || (Request.QueryString["source_page"] == "project_costing_sheets_edit.aspx") || (Request.QueryString["source_page"] == "project_costing_sheets_delete.aspx") || (Request.QueryString["source_page"] == "project_costing_sheets_state.aspx"))
                {
                    // Store Navigator State and Update control
                    StoreNavigatorState();
                    ViewState["update"] = Request.QueryString["update"];                   
                }

                // Restore dataset
                projectTDS = (ProjectTDS)Session["lfsProjectTDS"];
                projectCostingSheetInformationTDS = (ProjectCostingSheetInformationTDS)Session["projectCostingSheetInformationTDS"];

                labourHoursInformation = (ProjectCostingSheetInformationTDS.LabourHoursInformationDataTable)Session["labourHoursInformation"];
                unitsInformation = (ProjectCostingSheetInformationTDS.UnitsInformationDataTable)Session["unitsInformation"];                
                materialsInformation = (ProjectCostingSheetInformationTDS.MaterialsInformationDataTable)Session["materialsInformation"];
                otherCostsInformation = (ProjectCostingSheetInformationTDS.OtherCostsInformationDataTable)Session["otherCostsInformation"];
                revenueInformation = (ProjectCostingSheetInformationTDS.RevenueInformationDataTable)Session["revenueInformation"];

                subcontractorsInformation = (ProjectCostingSheetInformationTDS.SubcontractorsInformationDataTable)Session["subcontractorsInformation"];
                hotelsInformation = (ProjectCostingSheetInformationTDS.HotelsInformationDataTable)Session["hotelsInformation"];
                bondingsInformation = (ProjectCostingSheetInformationTDS.BondingsInformationDataTable)Session["bondingsInformation"];
                insurancesInformation = (ProjectCostingSheetInformationTDS.InsurancesInformationDataTable)Session["insurancesInformation"];
                otherCategoryInformation = (ProjectCostingSheetInformationTDS.OtherCategoryInformationDataTable)Session["otherCategoryInformation"];

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

                labourHoursInformation = (ProjectCostingSheetInformationTDS.LabourHoursInformationDataTable)Session["labourHoursInformation"];
                unitsInformation = (ProjectCostingSheetInformationTDS.UnitsInformationDataTable)Session["unitsInformation"];
                materialsInformation = (ProjectCostingSheetInformationTDS.MaterialsInformationDataTable)Session["materialsInformation"];
                otherCostsInformation = (ProjectCostingSheetInformationTDS.OtherCostsInformationDataTable)Session["otherCostsInformation"];
                revenueInformation = (ProjectCostingSheetInformationTDS.RevenueInformationDataTable)Session["revenueInformation"];

                subcontractorsInformation = (ProjectCostingSheetInformationTDS.SubcontractorsInformationDataTable)Session["subcontractorsInformation"];
                hotelsInformation = (ProjectCostingSheetInformationTDS.HotelsInformationDataTable)Session["hotelsInformation"];
                bondingsInformation = (ProjectCostingSheetInformationTDS.BondingsInformationDataTable)Session["bondingsInformation"];
                insurancesInformation = (ProjectCostingSheetInformationTDS.InsurancesInformationDataTable)Session["insurancesInformation"];
                otherCategoryInformation = (ProjectCostingSheetInformationTDS.OtherCategoryInformationDataTable)Session["otherCategoryInformation"];
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

            ProjectCostingSheetInformationBasicInformationGateway projectCostingSheetInformationBasicInformationGateway = new ProjectCostingSheetInformationBasicInformationGateway(projectCostingSheetInformationTDS);
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

            grdTeamMembers.Columns[10].Visible = false;
            grdTeamMembers.Columns[11].Visible = false;
            grdTeamMembers.Columns[12].Visible = false;
            grdTeamMembers.Columns[13].Visible = false;
            grdTeamMembers.Columns[15].Visible = false;
            grdTeamMembers.Columns[16].Visible = false;
            grdTeamMembers.Columns[19].Visible = false;
            grdTeamMembers.Columns[20].Visible = false;

            if (projectGateway.GetCountryID(projectId) == 1) //Canada
            {
                // Team Members Grid
                grdTeamMembers.Columns[14].Visible = true;
                grdTeamMembers.Columns[17].Visible = true;
                grdTeamMembers.Columns[18].Visible = false;
                grdTeamMembers.Columns[21].Visible = false;  
                
                // Units Grid
                grdUnits.Columns[11].Visible = true;
                grdUnits.Columns[12].Visible = true;
                grdUnits.Columns[13].Visible = false;
                grdUnits.Columns[14].Visible = false;

                grdUnits.Columns[11].Visible = true;
                grdUnits.Columns[12].Visible = true;
                grdUnits.Columns[13].Visible = false;
                grdUnits.Columns[14].Visible = false;

                grdSubcontractors.Columns[8].Visible = true;
                grdSubcontractors.Columns[9].Visible = true;
                grdSubcontractors.Columns[10].Visible = false;
                grdSubcontractors.Columns[11].Visible = false;

                // Materials grid
                grdMaterials.Columns[9].Visible = true;
                grdMaterials.Columns[10].Visible = true;
                grdMaterials.Columns[11].Visible = false;
                grdMaterials.Columns[12].Visible = false;

                // Other costs
                grdOtherCosts.Columns[8].Visible = true;
                grdOtherCosts.Columns[9].Visible = true;
                grdOtherCosts.Columns[10].Visible = false;
                grdOtherCosts.Columns[11].Visible = false;

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

                lblHotelsTotalCosts.Text = "Total Cost (CAD) : ";
                tbxHotelsTotalCostsCAD.Visible = true;
                tbxHotelsTotalCostsUSD.Visible = false;

                lblBondingsTotalCosts.Text = "Total Cost (CAD) : ";
                tbxBondingsTotalCostsCAD.Visible = true;
                tbxBondingsTotalCostsUSD.Visible = false;

                lblInsurancesTotalCosts.Text = "Total Cost (CAD) : ";
                tbxInsurancesTotalCostsCAD.Visible = true;
                tbxInsurancesTotalCostsUSD.Visible = false;

                lblOtherCategoryTotalCosts.Text = "Total Cost (CAD) : ";
                tbxOtherCategoryTotalCostsCAD.Visible = true;
                tbxOtherCategoryTotalCostsUSD.Visible = false;

                lblGrandTotal.Text = "Grand Total (CAD)";
            }
            else
            {
                if (projectGateway.GetCountryID(projectId) == 2) //USA
                {
                    // Team Members Grid
                    grdTeamMembers.Columns[14].Visible = false;
                    grdTeamMembers.Columns[17].Visible = false;
                    grdTeamMembers.Columns[18].Visible = true;
                    grdTeamMembers.Columns[21].Visible = true;

                    // Units Grid
                    grdUnits.Columns[11].Visible = false;
                    grdUnits.Columns[12].Visible = false;
                    grdUnits.Columns[13].Visible = true;
                    grdUnits.Columns[14].Visible = true;

                    grdSubcontractors.Columns[8].Visible = false;
                    grdSubcontractors.Columns[9].Visible = false;
                    grdSubcontractors.Columns[10].Visible = true;
                    grdSubcontractors.Columns[11].Visible = true;

                    // Materials grid
                    grdMaterials.Columns[9].Visible = false;
                    grdMaterials.Columns[10].Visible = false;
                    grdMaterials.Columns[11].Visible = true;
                    grdMaterials.Columns[12].Visible = true;

                    // Other costs
                    grdOtherCosts.Columns[8].Visible = false;
                    grdOtherCosts.Columns[9].Visible = false;
                    grdOtherCosts.Columns[10].Visible = true;
                    grdOtherCosts.Columns[11].Visible = true;

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

                    lblHotelsTotalCosts.Text = "Total Cost (USD) : ";
                    tbxHotelsTotalCostsCAD.Visible = false;
                    tbxHotelsTotalCostsUSD.Visible = true;

                    lblBondingsTotalCosts.Text = "Total Cost (USD) : ";
                    tbxBondingsTotalCostsCAD.Visible = false;
                    tbxBondingsTotalCostsUSD.Visible = true;

                    lblInsurancesTotalCosts.Text = "Total Cost (USD) : ";
                    tbxInsurancesTotalCostsCAD.Visible = false;
                    tbxInsurancesTotalCostsUSD.Visible = true;

                    lblOtherCategoryTotalCosts.Text = "Total false (USD) : ";
                    tbxOtherCategoryTotalCostsCAD.Visible = false;
                    tbxOtherCategoryTotalCostsUSD.Visible = true;

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
                    url = "./project_costing_sheets_edit.aspx?source_page=project_costing_sheets_summary.aspx&costing_sheet_id=" + hdfCostingSheetId.Value + "&project_id=" + hdfProjectId.Value + "&active_tab=" + (string)ViewState["active_tab"] + GetNavigatorState() + "&origin=" + (string)ViewState["origin"] + "&update=" + (string)ViewState["update"] + "&data_changed=" + hdfDataChanged.Value + "&state=" + (string)ViewState["state"];
                    break;

                case "mApprove":
                    url = "./project_costing_sheets_state.aspx?source_page=project_costing_sheets_summary.aspx&costing_sheet_id=" + hdfCostingSheetId.Value + "&project_id=" + hdfProjectId.Value + "&costing_sheet_state=Approved&active_tab=" + (string)ViewState["active_tab"] + GetNavigatorState() + "&origin=" + (string)ViewState["origin"] + "&update=" + (string)ViewState["update"] + "&data_changed=" + hdfDataChanged.Value + "&state=" + (string)ViewState["state"];
                    break;

                case "mSetInProgress":
                    url = "./project_costing_sheets_state.aspx?source_page=project_costing_sheets_summary.aspx&costing_sheet_id=" + hdfCostingSheetId.Value + "&project_id=" + hdfProjectId.Value + "&costing_sheet_state=In Progress&active_tab=" + (string)ViewState["active_tab"] + GetNavigatorState() + "&origin=" + (string)ViewState["origin"] + "&update=" + (string)ViewState["update"] + "&data_changed=" + hdfDataChanged.Value + "&state=" + (string)ViewState["state"];
                    break;

                case "mLastSearch":
                    url = "./project_costing_sheets_navigator.aspx?source_page=project_summary.aspx&project_id=" + hdfProjectId.Value + "&active_tab=" + (string)ViewState["active_tab"] + GetNavigatorState() + "&origin=" + (string)ViewState["origin"] + "&update=" + (string)ViewState["update"] + "&data_changed=" + hdfDataChanged.Value + "&state=" + (string)ViewState["state"];
                    break;

                case "mDelete":
                    url = "./project_costing_sheets_delete.aspx?source_page=project_costing_sheets_summary.aspx&costing_sheet_id=" + hdfCostingSheetId.Value + "&project_id=" + hdfProjectId.Value + "&active_tab=" + (string)ViewState["active_tab"] + GetNavigatorState() + "&origin=" + (string)ViewState["origin"] + "&update=" + (string)ViewState["update"] + "&data_changed=" + hdfDataChanged.Value + "&state=" + (string)ViewState["state"];
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

            ProjectCostingSheetInformationBasicInformationGateway projectCostingSheetInformationBasicInformationGateway = new ProjectCostingSheetInformationBasicInformationGateway(projectCostingSheetInformationTDS);
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
                GetOtherTotals();

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



        private void GetOtherTotals()
        {
            decimal totalCostCadLH = 0;
            decimal totalCostUsdLH = 0;

            foreach (ProjectCostingSheetInformationTDS.HotelsInformationRow row in (ProjectCostingSheetInformationTDS.HotelsInformationDataTable)Session["hotelsInformation"])
            {
                if (!row.Deleted)
                {
                    totalCostCadLH = totalCostCadLH + row.Rate;
                    totalCostUsdLH = totalCostUsdLH + row.Rate;
                }
            }

            tbxHotelsTotalCostsCAD.Text = Math.Round(totalCostCadLH, 2).ToString();
            tbxHotelsTotalCostsUSD.Text = Math.Round(totalCostUsdLH, 2).ToString();

            /////////////////
            totalCostCadLH = 0;
            totalCostUsdLH = 0;

            foreach (ProjectCostingSheetInformationTDS.BondingsInformationRow row in (ProjectCostingSheetInformationTDS.BondingsInformationDataTable)Session["bondingsInformation"])
            {
                if (!row.Deleted)
                {
                    totalCostCadLH = totalCostCadLH + row.Rate;
                    totalCostUsdLH = totalCostUsdLH + row.Rate;
                }
            }

            tbxBondingsTotalCostsCAD.Text = Math.Round(totalCostCadLH, 2).ToString();
            tbxBondingsTotalCostsUSD.Text = Math.Round(totalCostUsdLH, 2).ToString();

            /////////////////
            totalCostCadLH = 0;
            totalCostUsdLH = 0;

            foreach (ProjectCostingSheetInformationTDS.InsurancesInformationRow row in (ProjectCostingSheetInformationTDS.InsurancesInformationDataTable)Session["insurancesInformation"])
            {
                if (!row.Deleted)
                {
                    totalCostCadLH = totalCostCadLH + row.Rate;
                    totalCostUsdLH = totalCostUsdLH + row.Rate;
                }
            }

            tbxInsurancesTotalCostsCAD.Text = Math.Round(totalCostCadLH, 2).ToString();
            tbxInsurancesTotalCostsUSD.Text = Math.Round(totalCostUsdLH, 2).ToString();

            /////////////////
            totalCostCadLH = 0;
            totalCostUsdLH = 0;

            foreach (ProjectCostingSheetInformationTDS.OtherCategoryInformationRow row in (ProjectCostingSheetInformationTDS.OtherCategoryInformationDataTable)Session["otherCategoryInformation"])
            {
                if (!row.Deleted)
                {
                    totalCostCadLH = totalCostCadLH + row.Rate;
                    totalCostUsdLH = totalCostUsdLH + row.Rate;
                }
            }

            tbxOtherCategoryTotalCostsCAD.Text = Math.Round(totalCostCadLH, 2).ToString();
            tbxOtherCategoryTotalCostsUSD.Text = Math.Round(totalCostUsdLH, 2).ToString();
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
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./project_costing_sheets_summary.js");
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



        public ProjectCostingSheetInformationTDS.SubcontractorsInformationDataTable GetSubcontractorsInformation()
        {
            subcontractorsInformation = (ProjectCostingSheetInformationTDS.SubcontractorsInformationDataTable)Session["subcontractorsInformationDummy"];

            if (subcontractorsInformation == null)
            {
                subcontractorsInformation = (ProjectCostingSheetInformationTDS.SubcontractorsInformationDataTable)Session["subcontractorsInformation"];
            }

            return subcontractorsInformation;
        }



        protected void SubcontractorsInformationEmptyFix(GridView grdView)
        {
            if (grdView.Rows.Count == 0)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                ProjectCostingSheetInformationTDS.SubcontractorsInformationDataTable dt = new ProjectCostingSheetInformationTDS.SubcontractorsInformationDataTable();
                dt.AddSubcontractorsInformationRow(0, 0, 0, "", 0, 0, 0, 0, 0, false, companyId, false, "", DateTime.Now, DateTime.Now, "", 0);
                Session["subcontractorsInformationDummy"] = dt;

                grdView.DataBind();
            }

            // Normally executes at all postbacks
            if (grdView.Rows.Count == 1)
            {
                ProjectCostingSheetInformationTDS.SubcontractorsInformationDataTable dt = (ProjectCostingSheetInformationTDS.SubcontractorsInformationDataTable)Session["subcontractorsInformationDummy"];
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
                ProjectCostingSheetInformationTDS.MaterialsInformationDataTable dt = new ProjectCostingSheetInformationTDS.MaterialsInformationDataTable();
                dt.AddMaterialsInformationRow(0, 0, 0, 0, 0, 0, 0, 0, false, companyId, false, "", "", "", DateTime.Now, DateTime.Now, "", "", 0);
                Session["materialsInformationDummy"] = dt;

                grdView.DataBind();
            }

            // Normally executes at all postbacks
            if (grdView.Rows.Count == 1)
            {
                ProjectCostingSheetInformationTDS.MaterialsInformationDataTable dt = (ProjectCostingSheetInformationTDS.MaterialsInformationDataTable)Session["materialsInformationDummy"];
                if (dt != null)
                {
                    // Hide row
                    grdView.Rows[0].Visible = false;
                    grdView.Rows[0].Controls.Clear();
                }
            }
        }



        public ProjectCostingSheetInformationTDS.MaterialsInformationDataTable GetMaterialsInformation()
        {
            materialsInformation = (ProjectCostingSheetInformationTDS.MaterialsInformationDataTable)Session["materialsInformationDummy"];

            if (materialsInformation == null)
            {
                materialsInformation = (ProjectCostingSheetInformationTDS.MaterialsInformationDataTable)Session["materialsInformation"];
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



        public ProjectCostingSheetInformationTDS.OtherCostsInformationDataTable GetOtherCostsnformation()
        {
            otherCostsInformation = (ProjectCostingSheetInformationTDS.OtherCostsInformationDataTable)Session["otherCostsInformationDummy"];

            if (otherCostsInformation == null)
            {
                otherCostsInformation = (ProjectCostingSheetInformationTDS.OtherCostsInformationDataTable)Session["otherCostsInformation"];
            }

            return otherCostsInformation;
        }


        
        protected void OtherCostsInformationEmptyFix(GridView grdView)
        {
            if (grdView.Rows.Count == 0)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                ProjectCostingSheetInformationTDS.OtherCostsInformationDataTable dt = new ProjectCostingSheetInformationTDS.OtherCostsInformationDataTable();
                dt.AddOtherCostsInformationRow(0, 0, "", "", "", "", 0, 0, 0, 0, 0, false, companyId, false, "", DateTime.Now, DateTime.Now);
                Session["otherCostsInformationDummy"] = dt;

                grdView.DataBind();
            }

            // Normally executes at all postbacks
            if (grdView.Rows.Count == 1)
            {
                ProjectCostingSheetInformationTDS.OtherCostsInformationDataTable dt = (ProjectCostingSheetInformationTDS.OtherCostsInformationDataTable)Session["otherCostsInformationDummy"];
                if (dt != null)
                {
                    // Hide row
                    grdView.Rows[0].Visible = false;
                    grdView.Rows[0].Controls.Clear();
                }
            }
        }



        public ProjectCostingSheetInformationTDS.OtherCostsInformationDataTable GetOtherCostsInformation()
        {
            otherCostsInformation = (ProjectCostingSheetInformationTDS.OtherCostsInformationDataTable)Session["otherCostsInformationDummy"];

            if (otherCostsInformation == null)
            {
                otherCostsInformation = (ProjectCostingSheetInformationTDS.OtherCostsInformationDataTable)Session["otherCostsInformation"];
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
                ProjectCostingSheetInformationTDS.LabourHoursInformationDataTable dt = new ProjectCostingSheetInformationTDS.LabourHoursInformationDataTable();
                dt.AddLabourHoursInformationRow(0, "", 0, 0, 0, "", "", 0, "", 0, 0, 0, 0, 0, 0, 0, 0, 0, false, companyId, false, "", DateTime.Now, DateTime.Now, "", "", 0);
                Session["labourHoursInformationDummy"] = dt;

                grdView.DataBind();
            }

            // Normally executes at all postbacks
            if (grdView.Rows.Count == 1)
            {
                ProjectCostingSheetInformationTDS.LabourHoursInformationDataTable dt = (ProjectCostingSheetInformationTDS.LabourHoursInformationDataTable)Session["labourHoursInformationDummy"];
                if (dt != null)
                {
                    // Hide row
                    grdView.Rows[0].Visible = false;
                    grdView.Rows[0].Controls.Clear();
                }
            }
        }



        public ProjectCostingSheetInformationTDS.LabourHoursInformationDataTable GetLabourHoursInformation()
        {
            labourHoursInformation = (ProjectCostingSheetInformationTDS.LabourHoursInformationDataTable)Session["labourHoursInformationDummy"];

            if (labourHoursInformation == null)
            {
                labourHoursInformation = (ProjectCostingSheetInformationTDS.LabourHoursInformationDataTable)Session["labourHoursInformation"];
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
                ProjectCostingSheetInformationTDS.UnitsInformationDataTable dt = new ProjectCostingSheetInformationTDS.UnitsInformationDataTable();
                dt.AddUnitsInformationRow(0, "", 0, 0, "", 0, 0, 0, 0, 0, false, companyId, false, "", "", DateTime.Now, DateTime.Now, "", "",0);
                Session["unitsInformationDummy"] = dt;

                grdView.DataBind();
            }

            // Normally executes at all postbacks
            if (grdView.Rows.Count == 1)
            {
                ProjectCostingSheetInformationTDS.UnitsInformationDataTable dt = (ProjectCostingSheetInformationTDS.UnitsInformationDataTable)Session["unitsInformationDummy"];
                if (dt != null)
                {
                    // Hide row
                    grdView.Rows[0].Visible = false;
                    grdView.Rows[0].Controls.Clear();
                }
            }
        }



        public ProjectCostingSheetInformationTDS.UnitsInformationDataTable GetUnitsInformation()
        {
            unitsInformation = (ProjectCostingSheetInformationTDS.UnitsInformationDataTable)Session["unitsInformationDummy"];

            if (unitsInformation == null)
            {
                unitsInformation = (ProjectCostingSheetInformationTDS.UnitsInformationDataTable)Session["unitsInformation"];
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
                ProjectCostingSheetInformationTDS.RevenueInformationDataTable dt = new ProjectCostingSheetInformationTDS.RevenueInformationDataTable();
                dt.AddRevenueInformationRow(0, 0, 0, "", companyId, DateTime.Now, DateTime.Now, false, false);
                Session["revenueInformationDummy"] = dt;

                grdView.DataBind();
            }

            // Normally executes at all postbacks
            if (grdView.Rows.Count == 1)
            {
                ProjectCostingSheetInformationTDS.RevenueInformationDataTable dt = (ProjectCostingSheetInformationTDS.RevenueInformationDataTable)Session["revenueInformationDummy"];
                if (dt != null)
                {
                    // Hide row
                    grdView.Rows[0].Visible = false;
                    grdView.Rows[0].Controls.Clear();
                }
            }
        }



        public ProjectCostingSheetInformationTDS.RevenueInformationDataTable GetRevenueInformation()
        {
            revenueInformation = (ProjectCostingSheetInformationTDS.RevenueInformationDataTable)Session["revenueInformationDummy"];

            if (revenueInformation == null)
            {
                revenueInformation = (ProjectCostingSheetInformationTDS.RevenueInformationDataTable)Session["revenueInformation"];
            }

            return revenueInformation;
        }



        protected void grdHotels_DataBound(object sender, EventArgs e)
        {
            HotelsInformationEmptyFix(grdHotels);
        }



        protected void grdHotels_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
        }



        public ProjectCostingSheetInformationTDS.HotelsInformationDataTable GetHotelsInformation()
        {
            hotelsInformation = (ProjectCostingSheetInformationTDS.HotelsInformationDataTable)Session["hotelsInformationDummy"];

            if (hotelsInformation == null)
            {
                hotelsInformation = (ProjectCostingSheetInformationTDS.HotelsInformationDataTable)Session["hotelsInformation"];
            }

            return hotelsInformation;
        }



        protected void HotelsInformationEmptyFix(GridView grdView)
        {
            if (grdView.Rows.Count == 0)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                ProjectCostingSheetInformationTDS.HotelsInformationDataTable dt = new ProjectCostingSheetInformationTDS.HotelsInformationDataTable();
                dt.AddHotelsInformationRow(0, 0, 0, 0, false, companyId, false, "", DateTime.Now, DateTime.Now, 0, "");
                Session["hotelsInformationDummy"] = dt;

                grdView.DataBind();
            }

            // Normally executes at all postbacks
            if (grdView.Rows.Count == 1)
            {
                ProjectCostingSheetInformationTDS.HotelsInformationDataTable dt = (ProjectCostingSheetInformationTDS.HotelsInformationDataTable)Session["hotelsInformationDummy"];
                if (dt != null)
                {
                    // Hide row
                    grdView.Rows[0].Visible = false;
                    grdView.Rows[0].Controls.Clear();
                }
            }
        }



        protected void grdBondings_DataBound(object sender, EventArgs e)
        {
            BondingsInformationEmptyFix(grdBondings);
        }



        protected void grdBondings_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
        }



        public ProjectCostingSheetInformationTDS.BondingsInformationDataTable GetBondingsInformation()
        {
            bondingsInformation = (ProjectCostingSheetInformationTDS.BondingsInformationDataTable)Session["bondingsInformationDummy"];

            if (bondingsInformation == null)
            {
                bondingsInformation = (ProjectCostingSheetInformationTDS.BondingsInformationDataTable)Session["bondingsInformation"];
            }

            return bondingsInformation;
        }



        protected void BondingsInformationEmptyFix(GridView grdView)
        {
            if (grdView.Rows.Count == 0)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                ProjectCostingSheetInformationTDS.BondingsInformationDataTable dt = new ProjectCostingSheetInformationTDS.BondingsInformationDataTable();
                dt.AddBondingsInformationRow(0, 0, 0, 0, false, companyId, false, "", DateTime.Now, DateTime.Now, 0, "");
                Session["bondingsInformationDummy"] = dt;

                grdView.DataBind();
            }

            // Normally executes at all postbacks
            if (grdView.Rows.Count == 1)
            {
                ProjectCostingSheetInformationTDS.BondingsInformationDataTable dt = (ProjectCostingSheetInformationTDS.BondingsInformationDataTable)Session["bondingsInformationDummy"];
                if (dt != null)
                {
                    // Hide row
                    grdView.Rows[0].Visible = false;
                    grdView.Rows[0].Controls.Clear();
                }
            }
        }



        protected void grdInsurances_DataBound(object sender, EventArgs e)
        {
            InsurancesInformationEmptyFix(grdInsurances);
        }



        protected void grdInsurances_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
        }



        public ProjectCostingSheetInformationTDS.InsurancesInformationDataTable GetInsurancesInformation()
        {
            insurancesInformation = (ProjectCostingSheetInformationTDS.InsurancesInformationDataTable)Session["insurancesInformationDummy"];

            if (insurancesInformation == null)
            {
                insurancesInformation = (ProjectCostingSheetInformationTDS.InsurancesInformationDataTable)Session["insurancesInformation"];
            }

            return insurancesInformation;
        }



        protected void InsurancesInformationEmptyFix(GridView grdView)
        {
            if (grdView.Rows.Count == 0)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                ProjectCostingSheetInformationTDS.InsurancesInformationDataTable dt = new ProjectCostingSheetInformationTDS.InsurancesInformationDataTable();
                dt.AddInsurancesInformationRow(0, 0, 0, 0, false, companyId, false, "", DateTime.Now, DateTime.Now, 0, "");
                Session["insurancesInformationDummy"] = dt;

                grdView.DataBind();
            }

            // Normally executes at all postbacks
            if (grdView.Rows.Count == 1)
            {
                ProjectCostingSheetInformationTDS.InsurancesInformationDataTable dt = (ProjectCostingSheetInformationTDS.InsurancesInformationDataTable)Session["insurancesInformationDummy"];
                if (dt != null)
                {
                    // Hide row
                    grdView.Rows[0].Visible = false;
                    grdView.Rows[0].Controls.Clear();
                }
            }
        }



        protected void grdOtherCategory_DataBound(object sender, EventArgs e)
        {
            OtherCategoryInformationEmptyFix(grdOtherCategory);
        }



        protected void grdOtherCategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
        }



        public ProjectCostingSheetInformationTDS.OtherCategoryInformationDataTable GetOtherCategoryInformation()
        {
            otherCategoryInformation = (ProjectCostingSheetInformationTDS.OtherCategoryInformationDataTable)Session["otherCategoryInformationDummy"];

            if (otherCategoryInformation == null)
            {
                otherCategoryInformation = (ProjectCostingSheetInformationTDS.OtherCategoryInformationDataTable)Session["otherCategoryInformation"];
            }

            return otherCategoryInformation;
        }



        protected void OtherCategoryInformationEmptyFix(GridView grdView)
        {
            if (grdView.Rows.Count == 0)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                ProjectCostingSheetInformationTDS.OtherCategoryInformationDataTable dt = new ProjectCostingSheetInformationTDS.OtherCategoryInformationDataTable();
                dt.AddOtherCategoryInformationRow(0, "", 0, 0, false, companyId, false, DateTime.Now, DateTime.Now, 0, "");
                Session["otherCategoryInformationDummy"] = dt;

                grdView.DataBind();
            }

            // Normally executes at all postbacks
            if (grdView.Rows.Count == 1)
            {
                ProjectCostingSheetInformationTDS.OtherCategoryInformationDataTable dt = (ProjectCostingSheetInformationTDS.OtherCategoryInformationDataTable)Session["otherCategoryInformationDummy"];
                if (dt != null)
                {
                    // Hide row
                    grdView.Rows[0].Visible = false;
                    grdView.Rows[0].Controls.Clear();
                }
            }
        }

        
        
    }
}