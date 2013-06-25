using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.BL.Projects.Projects;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.DA.Resources.Companies;
using LiquiForce.LFSLive.Server;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.Projects.Projects
{
    /// <summary>
    /// project_combined_costing_sheets_edit
    /// </summary>
    public partial class project_combined_costing_sheets_edit : System.Web.UI.Page
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
        // INITIAL EVENTS
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
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in project_combined_costing_sheets_edit.aspx");
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

                // If coming from project_combined_costing_sheets_navigator.aspx or project_combined_costing_sheets_add.aspx
                int companyId = Int32.Parse(hdfCompanyId.Value);
                if (Request.QueryString["source_page"] == "project_costing_sheets_navigator.aspx" || Request.QueryString["source_page"] == "project_combined_costing_sheets_add.aspx")
                {
                    // Store Navigator State and Update control
                    StoreNavigatorState();
                    ViewState["update"] = "no";

                    // Get Costing sheet ID                   
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

                    projectCombinedCostingSheetInformationRevenueInformationGateway projectCombinedCostingSheetInformationRevenueInformationGateway = new projectCombinedCostingSheetInformationRevenueInformationGateway(projectCostingSheetInformationTDS);
                    projectCombinedCostingSheetInformationRevenueInformationGateway.LoadByCostingSheetId(costingSheetId, companyId);

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

                // ... project_combined_costing_sheets_add.aspx
                if (Request.QueryString["source_page"] == "project_combined_costing_sheets_add.aspx")
                {
                    ViewState["update"] = "yes";
                }

                // ... left menu, project_combined_costing_sheets_edit.aspx, project_combined_costing_sheets_delete.aspx or project_combined_costing_sheets_state.aspx
                if ((Request.QueryString["source_page"] == "lm") || (Request.QueryString["source_page"] == "project_combined_costing_sheets_summary.aspx") || (Request.QueryString["source_page"] == "project_combined_costing_sheets_delete.aspx") || (Request.QueryString["source_page"] == "project_combined_costing_sheets_state.aspx"))
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

                if (!Convert.ToBoolean(Session["sgLFS_PROJECTS_COSTINGSHEETS_ADMIN"]))
                {
                    // Costing Sheet state check
                    ProjectCombinedCostingSheetInformationBasicInformationGateway projectCostingSheetInformationBasicInformationGatewayForValidate = new ProjectCombinedCostingSheetInformationBasicInformationGateway(projectCostingSheetInformationTDS);
                    string state = projectCostingSheetInformationBasicInformationGatewayForValidate.GetState(Int32.Parse(hdfCostingSheetId.Value));
                    if (state == "Approved")
                    {
                        Response.Redirect("./../../error_page.aspx?error=" + "This costing sheet is approved, you can not edit it.");
                    }
                }

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
                companiesGateway.LoadAllByCompaniesId(currentClientId, companyId);
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



        protected void grdTeamMembers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Add":
                    // Team member Gridview, if the gridview is edition mode
                    if (grdTeamMembers.EditIndex >= 0)
                    {
                        grdTeamMembers.UpdateRow(grdTeamMembers.EditIndex, true);
                    }

                    // Add New Team Member
                    int projectId = Int32.Parse(hdfProjectId.Value);
                    ProjectGateway projectGateway = new ProjectGateway();
                    projectGateway.LoadByProjectId(projectId);

                    if (projectGateway.GetCountryID(projectId) == 1) //Canada
                    {
                        Page.Validate("labourHoursCadNew");
                    }
                    else
                    {
                        Page.Validate("labourHoursUsdNew");
                    }
                    if (Page.IsValid)
                    {
                        Page.Validate("labourHoursNew");
                        if (Page.IsValid)
                        {
                            int companyId = Int32.Parse(hdfCompanyId.Value);
                            string typeOfWork = ((DropDownList)grdTeamMembers.FooterRow.FindControl("ddlTypeOfWork_New")).SelectedValue;
                            int employeeId = Int32.Parse(((DropDownList)grdTeamMembers.FooterRow.FindControl("ddlTeamMemberNew")).SelectedValue);
                            string name = ((DropDownList)grdTeamMembers.FooterRow.FindControl("ddlTeamMemberNew")).SelectedItem.Text;
                            string unitOfMeasurementLH = ((DropDownList)grdTeamMembers.FooterRow.FindControl("ddlUnitOfMeasurementLHNew")).SelectedValue;
                            double lHQuantity = double.Parse(((TextBox)grdTeamMembers.FooterRow.FindControl("tbxLHQtyNew")).Text.Trim());
                            string unitOfMeasurementMeals = ((DropDownList)grdTeamMembers.FooterRow.FindControl("ddlUnitsOfMeasurementLHMealsNew")).SelectedValue;
                            int? mealsQuantity = null; if (((TextBox)grdTeamMembers.FooterRow.FindControl("tbxMealsQtyNew")).Text.Trim() != "") mealsQuantity = Int32.Parse(((TextBox)grdTeamMembers.FooterRow.FindControl("tbxMealsQtyNew")).Text.Trim());
                            string unitOfMeasurementMotel = ((DropDownList)grdTeamMembers.FooterRow.FindControl("ddlUnitsOfMeasurementLHMotelNew")).SelectedValue;
                            int? motelQuantity = null; if (((TextBox)grdTeamMembers.FooterRow.FindControl("tbxMotelQtyNew")).Text.Trim() != "") motelQuantity = Int32.Parse(((TextBox)grdTeamMembers.FooterRow.FindControl("tbxMotelQtyNew")).Text.Trim());

                            decimal lhCostCad = 0;
                            decimal? mealsCostCad = null;
                            decimal? motelCostCad = null;
                            decimal totalCostCad = 0;
                            decimal lhCostUsd = 0;
                            decimal? mealsCostUsd = null;
                            decimal? motelCostUsd = null;
                            decimal totalCostUsd = 0;
                            if (projectGateway.GetCountryID(projectId) == 1) //Canada
                            {
                                lhCostCad = Decimal.Parse(((TextBox)grdTeamMembers.FooterRow.FindControl("tbxLHCostCADNew")).Text.Trim());
                                if (((TextBox)grdTeamMembers.FooterRow.FindControl("tbxMealsCostCADNew")).Text.Trim() != "") mealsCostCad = Decimal.Parse(((TextBox)grdTeamMembers.FooterRow.FindControl("tbxMealsCostCADNew")).Text.Trim());
                                if (((TextBox)grdTeamMembers.FooterRow.FindControl("tbxMotelCostCADNew")).Text.Trim() != "") motelCostCad = Decimal.Parse(((TextBox)grdTeamMembers.FooterRow.FindControl("tbxMotelCostCADNew")).Text.Trim());
                                totalCostCad = (lhCostCad * decimal.Parse(lHQuantity.ToString()));
                                if (mealsCostCad.HasValue && mealsQuantity.HasValue) totalCostCad = totalCostCad + (mealsCostCad.Value * decimal.Parse(mealsQuantity.Value.ToString()));
                                if (motelCostCad.HasValue && motelQuantity.HasValue) totalCostCad = totalCostCad + (motelCostCad.Value * decimal.Parse(motelQuantity.Value.ToString()));
                                totalCostCad = Decimal.Round(totalCostCad, 2);
                            }
                            else
                            {
                                lhCostUsd = Decimal.Parse(((TextBox)grdTeamMembers.FooterRow.FindControl("tbxLHCostUSDNew")).Text.Trim());
                                if (((TextBox)grdTeamMembers.FooterRow.FindControl("tbxMealsCostUSDNew")).Text.Trim() != "") mealsCostUsd = Decimal.Parse(((TextBox)grdTeamMembers.FooterRow.FindControl("tbxMealsCostUSDNew")).Text.Trim());
                                if (((TextBox)grdTeamMembers.FooterRow.FindControl("tbxMotelCostUSDNew")).Text.Trim() != "") motelCostUsd = Decimal.Parse(((TextBox)grdTeamMembers.FooterRow.FindControl("tbxMotelCostUSDNew")).Text.Trim());
                                totalCostUsd = (lhCostUsd * decimal.Parse(lHQuantity.ToString()));
                                if (mealsCostUsd.HasValue && mealsQuantity.HasValue) totalCostUsd = totalCostUsd + (mealsCostUsd.Value * decimal.Parse(mealsQuantity.Value.ToString()));
                                if (motelCostUsd.HasValue && motelQuantity.HasValue) totalCostUsd = totalCostUsd + (motelCostUsd.Value * decimal.Parse(motelQuantity.Value.ToString()));
                                totalCostUsd = Decimal.Round(totalCostUsd, 2);
                            }

                            DateTime startDate = ((RadDatePicker)grdTeamMembers.FooterRow.FindControl("tkrdpStartDateNew")).SelectedDate.Value;
                            DateTime endDate = ((RadDatePicker)grdTeamMembers.FooterRow.FindControl("tkrdpEndDateNew")).SelectedDate.Value;

                            ProjectCombinedCostingSheetInformationLabourHoursInformation model = new ProjectCombinedCostingSheetInformationLabourHoursInformation(projectCostingSheetInformationTDS);
                            model.Insert(0, typeOfWork, employeeId, lHQuantity, unitOfMeasurementLH, unitOfMeasurementMeals, mealsQuantity, unitOfMeasurementMotel, motelQuantity, lhCostCad, mealsCostCad, motelCostCad, totalCostCad, lhCostUsd, mealsCostUsd, motelCostUsd, totalCostUsd, false, companyId, name, startDate, endDate);

                            Session.Remove("labourHoursInformationDummy");
                            labourHoursInformation = (ProjectCostingSheetInformationTDS.CombinedLabourHoursInformationDataTable)model.Table;
                            Session["labourHoursInformation"] = labourHoursInformation;
                            Session["projectCostingSheetInformationTDS"] = projectCostingSheetInformationTDS;

                            grdTeamMembers.DataBind();

                            StepLabourHoursInformationProcessGrid();
                        }
                    }
                    break;
            }
        }



        protected void grdTeamMembers_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int projectId = Int32.Parse(hdfProjectId.Value);
            ProjectGateway projectGateway = new ProjectGateway();
            projectGateway.LoadByProjectId(projectId);

            if (projectGateway.GetCountryID(projectId) == 1) //Canada
            {
                Page.Validate("labourHoursCadEdit");
            }
            else
            {
                Page.Validate("labourHoursUsdEdit");
            }
            if (Page.IsValid)
            {
                Page.Validate("labourHoursEdit");
                if (Page.IsValid)
                {
                    int costingSheetId = (int)e.Keys["CostingSheetID"];
                    string work_ = (string)e.Keys["Work_"];
                    int employeeId = (int)e.Keys["EmployeeID"];
                    int companyId = Int32.Parse(hdfCompanyId.Value);
                    int refId = (int)e.Keys["RefID"];

                    string name = ((TextBox)grdTeamMembers.Rows[e.RowIndex].Cells[0].FindControl("tbxTeamMemberEdit")).Text;
                    string unitOfMeasurementLH = ((DropDownList)grdTeamMembers.Rows[e.RowIndex].Cells[0].FindControl("ddlUnitOfMeasurementLHEdit")).SelectedValue;
                    double lHQuantity = double.Parse(((TextBox)grdTeamMembers.Rows[e.RowIndex].Cells[0].FindControl("tbxLHQtyEdit")).Text.Trim());
                    string unitOfMeasurementMeals = ((DropDownList)grdTeamMembers.Rows[e.RowIndex].Cells[0].FindControl("ddlUnitsOfMeasurementLHMealsEdit")).SelectedValue;
                    int? mealsQuantity = null; if (((TextBox)grdTeamMembers.Rows[e.RowIndex].Cells[0].FindControl("tbxMealsQtyEdit")).Text.Trim() != "") mealsQuantity = Int32.Parse(((TextBox)grdTeamMembers.Rows[e.RowIndex].Cells[0].FindControl("tbxMealsQtyEdit")).Text.Trim());
                    string unitOfMeasurementMotel = ((DropDownList)grdTeamMembers.Rows[e.RowIndex].Cells[0].FindControl("ddlUnitsOfMeasurementLHMotelEdit")).SelectedValue;
                    int? motelQuantity = null; if (((TextBox)grdTeamMembers.Rows[e.RowIndex].Cells[0].FindControl("tbxMotelQtyEdit")).Text.Trim() != "") motelQuantity = Int32.Parse(((TextBox)grdTeamMembers.Rows[e.RowIndex].Cells[0].FindControl("tbxMotelQtyEdit")).Text.Trim());

                    decimal lhCostCad = 0;
                    decimal? mealsCostCad = null;
                    decimal? motelCostCad = null;
                    decimal totalCostCad = 0;
                    decimal lhCostUsd = 0;
                    decimal? mealsCostUsd = null;
                    decimal? motelCostUsd = null;
                    decimal totalCostUsd = 0;
                    if (projectGateway.GetCountryID(projectId) == 1) //Canada
                    {
                        lhCostCad = Decimal.Parse(((TextBox)grdTeamMembers.Rows[e.RowIndex].Cells[0].FindControl("tbxLHCostCADEdit")).Text.Trim());
                        if (((TextBox)grdTeamMembers.Rows[e.RowIndex].Cells[0].FindControl("tbxMealsCostCADEdit")).Text.Trim() != "") mealsCostCad = Decimal.Parse(((TextBox)grdTeamMembers.Rows[e.RowIndex].Cells[0].FindControl("tbxMealsCostCADEdit")).Text.Trim());
                        if (((TextBox)grdTeamMembers.Rows[e.RowIndex].Cells[0].FindControl("tbxMotelCostCADEdit")).Text.Trim() != "") motelCostCad = Decimal.Parse(((TextBox)grdTeamMembers.Rows[e.RowIndex].Cells[0].FindControl("tbxMotelCostCADEdit")).Text.Trim());
                        totalCostCad = (lhCostCad * decimal.Parse(lHQuantity.ToString()));
                        if (mealsCostCad.HasValue && mealsQuantity.HasValue) totalCostCad = totalCostCad + (mealsCostCad.Value * decimal.Parse(mealsQuantity.Value.ToString()));
                        if (motelCostCad.HasValue && motelQuantity.HasValue) totalCostCad = totalCostCad + (motelCostCad.Value * decimal.Parse(motelQuantity.Value.ToString()));
                        totalCostCad = Decimal.Round(totalCostCad, 2);
                    }
                    else
                    {
                        lhCostUsd = Decimal.Parse(((TextBox)grdTeamMembers.Rows[e.RowIndex].Cells[0].FindControl("tbxLHCostUSDEdit")).Text.Trim());
                        if (((TextBox)grdTeamMembers.Rows[e.RowIndex].Cells[0].FindControl("tbxMealsCostUSDEdit")).Text.Trim() != "") mealsCostUsd = Decimal.Parse(((TextBox)grdTeamMembers.Rows[e.RowIndex].Cells[0].FindControl("tbxMealsCostUSDEdit")).Text.Trim());
                        if (((TextBox)grdTeamMembers.Rows[e.RowIndex].Cells[0].FindControl("tbxMotelCostUSDEdit")).Text.Trim() != "") motelCostUsd = Decimal.Parse(((TextBox)grdTeamMembers.Rows[e.RowIndex].Cells[0].FindControl("tbxMotelCostUSDEdit")).Text.Trim());
                        totalCostUsd = (lhCostUsd * decimal.Parse(lHQuantity.ToString()));
                        if (mealsCostUsd.HasValue && mealsQuantity.HasValue) totalCostUsd = totalCostUsd + (mealsCostUsd.Value * decimal.Parse(mealsQuantity.Value.ToString()));
                        if (motelCostUsd.HasValue && motelQuantity.HasValue) totalCostUsd = totalCostUsd + (motelCostUsd.Value * decimal.Parse(motelQuantity.Value.ToString()));
                        totalCostUsd = Decimal.Round(totalCostUsd, 2);
                    }

                    DateTime startDate = ((RadDatePicker)grdTeamMembers.Rows[e.RowIndex].Cells[0].FindControl("tkrdpStartDateEdit")).SelectedDate.Value;
                    DateTime endDate = ((RadDatePicker)grdTeamMembers.Rows[e.RowIndex].Cells[0].FindControl("tkrdpEndDateEdit")).SelectedDate.Value;

                    // Update data
                    ProjectCombinedCostingSheetInformationLabourHoursInformation model = new ProjectCombinedCostingSheetInformationLabourHoursInformation(projectCostingSheetInformationTDS);
                    model.Update(costingSheetId, work_, employeeId, refId, lHQuantity, unitOfMeasurementLH, unitOfMeasurementMeals, mealsQuantity, unitOfMeasurementMotel, motelQuantity, lhCostCad, mealsCostCad, motelCostCad, totalCostCad, lhCostUsd, mealsCostUsd, motelCostUsd, totalCostUsd, false, companyId, name, startDate, endDate);

                    // Store dataset
                    labourHoursInformation = (ProjectCostingSheetInformationTDS.CombinedLabourHoursInformationDataTable)model.Table;
                    Session["labourHoursInformation"] = labourHoursInformation;
                    Session["projectCostingSheetInformationTDS"] = projectCostingSheetInformationTDS;

                    StepLabourHoursInformationProcessGrid();
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }



        protected void grdTeamMembers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Team member Gridview, if the gridview is edition mode
            if (grdTeamMembers.EditIndex >= 0)
            {
                grdTeamMembers.UpdateRow(grdTeamMembers.EditIndex, true);
            }

            // Add New Team Member
            int costingSheetId = (int)e.Keys["CostingSheetID"];
            string work_ = (string)e.Keys["Work_"];
            int employeeId = (int)e.Keys["EmployeeID"];
            int refId = (int)e.Keys["RefID"];

            ProjectCombinedCostingSheetInformationLabourHoursInformation model = new ProjectCombinedCostingSheetInformationLabourHoursInformation(projectCostingSheetInformationTDS);

            // Delete cost
            model.Delete(costingSheetId, work_, employeeId, refId);

            // Store dataset            
            labourHoursInformation = (ProjectCostingSheetInformationTDS.CombinedLabourHoursInformationDataTable)model.Table;
            Session["labourHoursInformation"] = labourHoursInformation;
            Session["projectCostingSheetInformationTDS"] = projectCostingSheetInformationTDS;

            StepLabourHoursInformationProcessGrid();
        }



        protected void grdUnits_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Add":
                    // Units Gridview, if the gridview is edition mode
                    if (grdUnits.EditIndex >= 0)
                    {
                        grdUnits.UpdateRow(grdUnits.EditIndex, true);
                    }

                    // Validate general data
                    int projectId = Int32.Parse(hdfProjectId.Value);
                    ProjectGateway projectGateway = new ProjectGateway();
                    projectGateway.LoadByProjectId(projectId);

                    if (projectGateway.GetCountryID(projectId) == 1) //Canada
                    {
                        Page.Validate("unitsCadNew");
                    }
                    else
                    {
                        Page.Validate("unitsUsdNew");
                    }
                    if (Page.IsValid)
                    {
                        Page.Validate("unitsNew");
                        if (Page.IsValid)
                        {
                            int companyId = Int32.Parse(hdfCompanyId.Value);
                            string typeOfWork = ((DropDownList)grdUnits.FooterRow.FindControl("ddlTypeOfWork_New")).SelectedValue;
                            int unitId = Int32.Parse(((DropDownList)grdUnits.FooterRow.FindControl("ddlUnitCodeNew")).SelectedValue);
                            string unitCode = ((DropDownList)grdUnits.FooterRow.FindControl("ddlUnitCodeNew")).SelectedItem.Text;
                            string unitOfMeasurement = ((DropDownList)grdUnits.FooterRow.FindControl("ddlUnitOfMeasurementUnitsNew")).SelectedValue;
                            double quantity = double.Parse(((TextBox)grdUnits.FooterRow.FindControl("tbxQuantityNew")).Text.Trim());
                            decimal costCad = 0;
                            decimal totalCostCad = 0;
                            decimal costUsd = 0;
                            decimal totalCostUsd = 0;
                            if (projectGateway.GetCountryID(projectId) == 1) //Canada
                            {
                                costCad = Decimal.Parse(((TextBox)grdUnits.FooterRow.FindControl("tbxCostCADNew")).Text.Trim());
                                totalCostCad = (costCad * decimal.Parse(quantity.ToString()));
                                totalCostCad = Decimal.Round(totalCostCad, 2);
                            }
                            else
                            {
                                costUsd = Decimal.Parse(((TextBox)grdUnits.FooterRow.FindControl("tbxCostUSDNew")).Text.Trim());
                                totalCostUsd = (costUsd * decimal.Parse(quantity.ToString()));
                                totalCostUsd = Decimal.Round(totalCostUsd, 2);
                            }

                            LFSLive.DA.FleetManagement.Units.UnitsGateway u = new LiquiForce.LFSLive.DA.FleetManagement.Units.UnitsGateway();
                            u.LoadByUnitId(unitId, companyId);
                            string unitDescription = u.GetDescription(unitId);

                            DateTime startDate = ((RadDatePicker)grdUnits.FooterRow.FindControl("tkrdpStartDateNew")).SelectedDate.Value;
                            DateTime endDate = ((RadDatePicker)grdUnits.FooterRow.FindControl("tkrdpEndDateNew")).SelectedDate.Value;

                            ProjectCombinedCostingSheetInformationUnitsInformation model = new ProjectCombinedCostingSheetInformationUnitsInformation(projectCostingSheetInformationTDS);
                            model.Insert(0, typeOfWork, unitId, unitOfMeasurement, quantity, costCad, totalCostCad, costUsd, totalCostUsd, false, companyId, unitCode, unitDescription, startDate, endDate);

                            Session.Remove("unitsInformationDummy");
                            unitsInformation = (ProjectCostingSheetInformationTDS.CombinedUnitsInformationDataTable)model.Table;
                            Session["unitsInformation"] = unitsInformation;
                            Session["projectCostingSheetInformationTDS"] = projectCostingSheetInformationTDS;

                            grdUnits.DataBind();

                            StepTrucksEquipmentInformationProcessGrid();
                        }
                    }
                    break;
            }
        }



        protected void grdUnits_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int projectId = Int32.Parse(hdfProjectId.Value);
            ProjectGateway projectGateway = new ProjectGateway();
            projectGateway.LoadByProjectId(projectId);

            if (projectGateway.GetCountryID(projectId) == 1) //Canada
            {
                Page.Validate("unitsCadEdit");
            }
            else
            {
                Page.Validate("unitsUsdEdit");
            }
            if (Page.IsValid)
            {
                Page.Validate("unitsEdit");
                if (Page.IsValid)
                {
                    int costingSheetId = (int)e.Keys["CostingSheetID"];
                    string work_ = (string)e.Keys["Work_"];
                    int unitId = (int)e.Keys["UnitID"];
                    int refId = (int)e.Keys["RefID"];
                    int companyId = Int32.Parse(hdfCompanyId.Value);
                    string unitOfMeasurement = ((DropDownList)grdUnits.Rows[e.RowIndex].Cells[0].FindControl("ddlUnitOfMeasurementUnitsEdit")).SelectedValue;
                    double quantity = double.Parse(((TextBox)grdUnits.Rows[e.RowIndex].Cells[0].FindControl("tbxQuantityEdit")).Text.Trim());
                    decimal costCad = 0;
                    decimal totalCostCad = 0;
                    decimal costUsd = 0;
                    decimal totalCostUsd = 0;
                    if (projectGateway.GetCountryID(projectId) == 1) //Canada
                    {
                        costCad = Decimal.Parse(((TextBox)grdUnits.Rows[e.RowIndex].Cells[0].FindControl("tbxCostCADEdit")).Text.Trim());
                        totalCostCad = (costCad * decimal.Parse(quantity.ToString()));
                        totalCostCad = Decimal.Round(totalCostCad, 2);
                    }
                    else
                    {
                        costUsd = Decimal.Parse(((TextBox)grdUnits.Rows[e.RowIndex].Cells[0].FindControl("tbxCostUSDEdit")).Text.Trim());
                        totalCostUsd = (costUsd * decimal.Parse(quantity.ToString()));
                        totalCostUsd = Decimal.Round(totalCostUsd, 2);
                    }
                    LFSLive.DA.FleetManagement.Units.UnitsGateway u = new LiquiForce.LFSLive.DA.FleetManagement.Units.UnitsGateway();
                    u.LoadByUnitId(unitId, companyId);
                    string unitDescription = u.GetDescription(unitId);
                    string unitCode = u.GetUnitCode(unitId);

                    DateTime startDate = ((RadDatePicker)grdUnits.Rows[e.RowIndex].Cells[0].FindControl("tkrdpStartDateEdit")).SelectedDate.Value;
                    DateTime endDate = ((RadDatePicker)grdUnits.Rows[e.RowIndex].Cells[0].FindControl("tkrdpEndDateEdit")).SelectedDate.Value;

                    // Update data
                    ProjectCombinedCostingSheetInformationUnitsInformation model = new ProjectCombinedCostingSheetInformationUnitsInformation(projectCostingSheetInformationTDS);
                    model.Update(costingSheetId, work_, unitId, refId, unitOfMeasurement, quantity, costCad, totalCostCad, costUsd, totalCostUsd, false, companyId, unitCode, unitDescription, startDate, endDate);

                    // Store dataset
                    unitsInformation = (ProjectCostingSheetInformationTDS.CombinedUnitsInformationDataTable)model.Table;
                    Session["unitsInformation"] = unitsInformation;
                    Session["projectCostingSheetInformationTDS"] = projectCostingSheetInformationTDS;

                    StepTrucksEquipmentInformationProcessGrid();
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }



        protected void grdUnits_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Units Gridview, if the gridview is edition mode
            if (grdUnits.EditIndex >= 0)
            {
                grdUnits.UpdateRow(grdUnits.EditIndex, true);
            }

            // Delete lateral
            int costingSheetId = (int)e.Keys["CostingSheetID"];
            string work_ = (string)e.Keys["Work_"];
            int unitId = (int)e.Keys["UnitID"];
            int refId = (int)e.Keys["RefID"];

            ProjectCombinedCostingSheetInformationUnitsInformation model = new ProjectCombinedCostingSheetInformationUnitsInformation(projectCostingSheetInformationTDS);

            // Delete cost
            model.Delete(costingSheetId, work_, unitId, refId);

            // Store dataset
            unitsInformation = (ProjectCostingSheetInformationTDS.CombinedUnitsInformationDataTable)model.Table;
            Session["unitsInformation"] = unitsInformation;
            Session["projectCostingSheetInformationTDS"] = projectCostingSheetInformationTDS;

            StepTrucksEquipmentInformationProcessGrid();
        }



        protected void grdMaterials_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Add":
                    // Materials Gridview, if the gridview is edition mode
                    if (grdMaterials.EditIndex >= 0)
                    {
                        grdMaterials.UpdateRow(grdMaterials.EditIndex, true);
                    }

                    // Validate general data
                    int projectId = Int32.Parse(hdfProjectId.Value);
                    ProjectGateway projectGateway = new ProjectGateway();
                    projectGateway.LoadByProjectId(projectId);

                    if (projectGateway.GetCountryID(projectId) == 1) //Canada
                    {
                        Page.Validate("materialsCadNew");
                    }
                    else
                    {
                        Page.Validate("materialsUsdNew");
                    }
                    if (Page.IsValid)
                    {
                        Page.Validate("materialsNew");
                        if (Page.IsValid)
                        {
                            int companyId = Int32.Parse(hdfCompanyId.Value);
                            string description = ((DropDownList)grdMaterials.FooterRow.FindControl("ddlDescriptionNew")).SelectedItem.Text;
                            int materialId = Int32.Parse(((DropDownList)grdMaterials.FooterRow.FindControl("ddlDescriptionNew")).SelectedValue);
                            string unitOfMeasurement = ((DropDownList)grdMaterials.FooterRow.FindControl("ddlUnitOfMeasurementMaterialsNew")).SelectedValue;
                            double quantity = double.Parse(((TextBox)grdMaterials.FooterRow.FindControl("tbxQuantityNew")).Text.Trim());
                            decimal costCad = 0;
                            decimal totalCostCad = 0;
                            decimal costUsd = 0;
                            decimal totalCostUsd = 0;
                            if (projectGateway.GetCountryID(projectId) == 1) //Canada
                            {
                                costCad = Decimal.Parse(((TextBox)grdMaterials.FooterRow.FindControl("tbxCostCADNew")).Text.Trim());
                                totalCostCad = (costCad * decimal.Parse(quantity.ToString()));
                                totalCostCad = Decimal.Round(totalCostCad, 2);
                            }
                            else
                            {
                                costUsd = Decimal.Parse(((TextBox)grdMaterials.FooterRow.FindControl("tbxCostUSDNew")).Text.Trim());
                                totalCostUsd = (costUsd * decimal.Parse(quantity.ToString()));
                                totalCostUsd = Decimal.Round(totalCostUsd, 2);
                            }

                            LFSLive.DA.Resources.Materials.MaterialsGateway m = new LiquiForce.LFSLive.DA.Resources.Materials.MaterialsGateway();
                            m.LoadByMaterialId(materialId, companyId);
                            string process = m.GetType(materialId);

                            DateTime startDate = ((RadDatePicker)grdMaterials.FooterRow.FindControl("tkrdpStartDateNew")).SelectedDate.Value;
                            DateTime endDate = ((RadDatePicker)grdMaterials.FooterRow.FindControl("tkrdpEndDateNew")).SelectedDate.Value;

                            ProjectCombinedCostingSheetInformationMaterialsInformation model = new ProjectCombinedCostingSheetInformationMaterialsInformation(projectCostingSheetInformationTDS);
                            model.Insert(0, materialId, unitOfMeasurement, quantity, costCad, totalCostCad, costUsd, totalCostUsd, false, companyId, process, description, startDate, endDate);

                            // Store tables
                            Session.Remove("materialsInformationDummy");
                            materialsInformation = (ProjectCostingSheetInformationTDS.CombinedMaterialsInformationDataTable)model.Table;
                            Session["materialsInformation"] = materialsInformation;
                            Session["projectCostingSheetInformationTDS"] = projectCostingSheetInformationTDS;

                            grdMaterials.DataBind();

                            StepMaterialInformationProcessGrid();
                        }
                    }
                    break;
            }
        }



        protected void grdMaterials_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int projectId = Int32.Parse(hdfProjectId.Value);
            ProjectGateway projectGateway = new ProjectGateway();
            projectGateway.LoadByProjectId(projectId);

            if (projectGateway.GetCountryID(projectId) == 1) //Canada
            {
                Page.Validate("materialsCadEdit");
            }
            else
            {
                Page.Validate("materialsUsEdit");
            }
            if (Page.IsValid)
            {
                Page.Validate("materialsEdit");
                if (Page.IsValid)
                {
                    int costingSheetId = (int)e.Keys["CostingSheetID"];
                    int materialId = (int)e.Keys["MaterialID"];
                    int refId = (int)e.Keys["RefID"];
                    int companyId = Int32.Parse(hdfCompanyId.Value);

                    string unitOfMeasurement = ((DropDownList)grdMaterials.Rows[e.RowIndex].Cells[0].FindControl("ddlUnitOfMeasurementMaterialsEdit")).SelectedValue;
                    double quantity = double.Parse(((TextBox)grdMaterials.Rows[e.RowIndex].Cells[0].FindControl("tbxQuantityEdit")).Text.Trim());
                    decimal costCad = 0;
                    decimal totalCostCad = 0;
                    decimal costUsd = 0;
                    decimal totalCostUsd = 0;
                    if (projectGateway.GetCountryID(projectId) == 1) //Canada
                    {
                        costCad = Decimal.Parse(((TextBox)grdMaterials.Rows[e.RowIndex].Cells[0].FindControl("tbxCostCADEdit")).Text.Trim());
                        totalCostCad = (costCad * decimal.Parse(quantity.ToString()));
                        totalCostCad = Decimal.Round(totalCostCad, 2);
                    }
                    else
                    {
                        costUsd = Decimal.Parse(((TextBox)grdMaterials.Rows[e.RowIndex].Cells[0].FindControl("tbxCostUSDEdit")).Text.Trim());
                        totalCostUsd = (costUsd * decimal.Parse(quantity.ToString()));
                        totalCostUsd = Decimal.Round(totalCostUsd, 2);
                    }

                    LFSLive.DA.Resources.Materials.MaterialsGateway m = new LiquiForce.LFSLive.DA.Resources.Materials.MaterialsGateway();
                    m.LoadByMaterialId(materialId, companyId);
                    string process = m.GetType(materialId);
                    string description = m.GetDescription(materialId);

                    DateTime startDate = ((RadDatePicker)grdMaterials.Rows[e.RowIndex].Cells[0].FindControl("tkrdpStartDateEdit")).SelectedDate.Value;
                    DateTime endDate = ((RadDatePicker)grdMaterials.Rows[e.RowIndex].Cells[0].FindControl("tkrdpEndDateEdit")).SelectedDate.Value;

                    // Update data
                    ProjectCombinedCostingSheetInformationMaterialsInformation model = new ProjectCombinedCostingSheetInformationMaterialsInformation(projectCostingSheetInformationTDS);
                    model.Update(costingSheetId, materialId, refId, unitOfMeasurement, quantity, costCad, totalCostCad, costUsd, totalCostUsd, false, companyId, process, description, startDate, endDate);

                    // Store tables
                    Session.Remove("materialsInformationDummy");
                    materialsInformation = (ProjectCostingSheetInformationTDS.CombinedMaterialsInformationDataTable)model.Table;
                    Session["materialsInformation"] = materialsInformation;
                    Session["projectCostingSheetInformationTDS"] = projectCostingSheetInformationTDS;

                    StepMaterialInformationProcessGrid();
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }



        protected void grdMaterials_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Materials Gridview, if the gridview is edition mode
            if (grdMaterials.EditIndex >= 0)
            {
                grdMaterials.UpdateRow(grdMaterials.EditIndex, true);
            }

            // Delete material
            int costingSheetId = (int)e.Keys["CostingSheetID"];
            int materialId = (int)e.Keys["MaterialID"];
            int refId = (int)e.Keys["RefID"];

            ProjectCombinedCostingSheetInformationMaterialsInformation model = new ProjectCombinedCostingSheetInformationMaterialsInformation(projectCostingSheetInformationTDS);

            // Delete cost
            model.Delete(costingSheetId, materialId, refId);

            // Store tables
            Session.Remove("materialsInformationDummy");
            materialsInformation = (ProjectCostingSheetInformationTDS.CombinedMaterialsInformationDataTable)model.Table;
            Session["materialsInformation"] = materialsInformation;
            Session["projectCostingSheetInformationTDS"] = projectCostingSheetInformationTDS;

            StepMaterialInformationProcessGrid();
        }



        protected void grdOtherCosts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Add":
                    // Other costs Gridview, if the gridview is edition mode
                    if (grdOtherCosts.EditIndex >= 0)
                    {
                        grdOtherCosts.UpdateRow(grdOtherCosts.EditIndex, true);
                    }

                    // Validate general data
                    int projectId = Int32.Parse(hdfProjectId.Value);
                    ProjectGateway projectGateway = new ProjectGateway();
                    projectGateway.LoadByProjectId(projectId);

                    if (projectGateway.GetCountryID(projectId) == 1) //Canada
                    {
                        Page.Validate("otherCostsCadNew");
                    }
                    else
                    {
                        Page.Validate("otherCostsUsdNew");
                    }
                    if (Page.IsValid)
                    {
                        Page.Validate("otherCostsNew");
                        if (Page.IsValid)
                        {
                            int companyId = Int32.Parse(hdfCompanyId.Value);
                            string description = ((TextBox)grdOtherCosts.FooterRow.FindControl("tbxDescriptionNew")).Text.Trim();
                            string unitOfMeasurement = ((DropDownList)grdOtherCosts.FooterRow.FindControl("ddlUnitOfMeasurementOthersNew")).SelectedValue;
                            double quantity = double.Parse(((TextBox)grdOtherCosts.FooterRow.FindControl("tbxQuantityNew")).Text.Trim());
                            decimal costCad = 0;
                            decimal totalCostCad = 0;
                            decimal costUsd = 0;
                            decimal totalCostUsd = 0;
                            if (projectGateway.GetCountryID(projectId) == 1) //Canada
                            {
                                costCad = Decimal.Parse(((TextBox)grdOtherCosts.FooterRow.FindControl("tbxCostCADNew")).Text.Trim());
                                totalCostCad = (costCad * decimal.Parse(quantity.ToString()));
                                totalCostCad = Decimal.Round(totalCostCad, 2);
                            }
                            else
                            {
                                costUsd = Decimal.Parse(((TextBox)grdOtherCosts.FooterRow.FindControl("tbxCostUSDNew")).Text.Trim());
                                totalCostUsd = (costUsd * decimal.Parse(quantity.ToString()));
                                totalCostUsd = Decimal.Round(totalCostUsd, 2);
                            }

                            string workFunctionConcat = "";
                            string work_ = "";
                            string function_ = "";
                            workFunctionConcat = ((DropDownList)grdOtherCosts.FooterRow.FindControl("ddlWorkFunctionNew")).SelectedValue;
                            if (workFunctionConcat != "(Select)")
                            {
                                string[] workFunction = workFunctionConcat.ToString().Trim().Split('.');
                                work_ = workFunction[0].Trim();
                                function_ = workFunction[1].Trim();
                            }

                            DateTime startDate = ((RadDatePicker)grdOtherCosts.FooterRow.FindControl("tkrdpStartDateNew")).SelectedDate.Value;
                            DateTime endDate = ((RadDatePicker)grdOtherCosts.FooterRow.FindControl("tkrdpEndDateNew")).SelectedDate.Value;

                            ProjectCombinedCostingSheetInformationOtherCostsInformation model = new ProjectCombinedCostingSheetInformationOtherCostsInformation(projectCostingSheetInformationTDS);
                            model.Insert(0, work_, function_, description, unitOfMeasurement, quantity, costCad, totalCostCad, costUsd, totalCostUsd, false, companyId, workFunctionConcat, startDate, endDate);

                            Session.Remove("otherCostsInformationDummy");
                            otherCostsInformation = (ProjectCostingSheetInformationTDS.CombinedOtherCostsInformationDataTable)model.Table;
                            Session["otherCostsInformation"] = otherCostsInformation;
                            Session["projectCostingSheetInformationTDS"] = projectCostingSheetInformationTDS;

                            grdOtherCosts.DataBind();

                            StepOtherCostsInformationProcessGrid();
                        }
                    }
                    break;
            }
        }



        protected void grdOtherCosts_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int projectId = Int32.Parse(hdfProjectId.Value);
            ProjectGateway projectGateway = new ProjectGateway();
            projectGateway.LoadByProjectId(projectId);

            if (projectGateway.GetCountryID(projectId) == 1) //Canada
            {
                Page.Validate("otherCostsCadEdit");
            }
            else
            {
                Page.Validate("otherCostsUsdEdit");
            }
            if (Page.IsValid)
            {
                Page.Validate("otherCostsEdit");
                if (Page.IsValid)
                {
                    int costingSheetId = (int)e.Keys["CostingSheetID"];
                    int refId = (int)e.Keys["RefID"];
                    int companyId = Int32.Parse(hdfCompanyId.Value);
                    string description = ((TextBox)grdOtherCosts.Rows[e.RowIndex].Cells[0].FindControl("tbxDescriptionEdit")).Text.Trim();
                    string unitOfMeasurement = ((DropDownList)grdOtherCosts.Rows[e.RowIndex].Cells[0].FindControl("ddlUnitOfMeasurementOthersEdit")).SelectedValue;
                    double quantity = double.Parse(((TextBox)grdOtherCosts.Rows[e.RowIndex].Cells[0].FindControl("tbxQuantityEdit")).Text.Trim());
                    decimal costCad = 0;
                    decimal totalCostCad = 0;
                    decimal costUsd = 0;
                    decimal totalCostUsd = 0;
                    if (projectGateway.GetCountryID(projectId) == 1) //Canada
                    {
                        costCad = Decimal.Parse(((TextBox)grdOtherCosts.Rows[e.RowIndex].Cells[0].FindControl("tbxCostCADEdit")).Text.Trim());
                        totalCostCad = (costCad * decimal.Parse(quantity.ToString()));
                        totalCostCad = Decimal.Round(totalCostCad, 2);
                    }
                    else
                    {

                        costUsd = Decimal.Parse(((TextBox)grdOtherCosts.Rows[e.RowIndex].Cells[0].FindControl("tbxCostUSDEdit")).Text.Trim());
                        totalCostUsd = (costUsd * decimal.Parse(quantity.ToString()));
                        totalCostUsd = Decimal.Round(totalCostUsd, 2);
                    }

                    string workFunctionConcat = "";
                    string work_ = "";
                    string function_ = "";
                    workFunctionConcat = ((DropDownList)grdOtherCosts.Rows[e.RowIndex].Cells[0].FindControl("ddlWorkFunctionEdit")).SelectedValue;
                    if (workFunctionConcat != "(Select)")
                    {
                        string[] workFunction = workFunctionConcat.ToString().Trim().Split('.');
                        work_ = workFunction[0].Trim();
                        function_ = workFunction[1].Trim();
                    }

                    DateTime startDate = ((RadDatePicker)grdOtherCosts.Rows[e.RowIndex].Cells[0].FindControl("tkrdpStartDateEdit")).SelectedDate.Value;
                    DateTime endDate = ((RadDatePicker)grdOtherCosts.Rows[e.RowIndex].Cells[0].FindControl("tkrdpEndDateEdit")).SelectedDate.Value;

                    // Update data
                    ProjectCombinedCostingSheetInformationOtherCostsInformation model = new ProjectCombinedCostingSheetInformationOtherCostsInformation(projectCostingSheetInformationTDS);
                    model.Update(costingSheetId, refId, work_, function_, description, unitOfMeasurement, quantity, costCad, totalCostCad, costUsd, totalCostUsd, false, companyId, workFunctionConcat, startDate, endDate);

                    otherCostsInformation = (ProjectCostingSheetInformationTDS.CombinedOtherCostsInformationDataTable)model.Table;
                    Session["otherCostsInformation"] = otherCostsInformation;
                    Session["projectCostingSheetInformationTDS"] = projectCostingSheetInformationTDS;

                    StepOtherCostsInformationProcessGrid();
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }



        protected void grdOtherCosts_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Other costs Gridview, if the gridview is edition mode
            if (grdOtherCosts.EditIndex >= 0)
            {
                grdOtherCosts.UpdateRow(grdOtherCosts.EditIndex, true);
            }

            // Delete lateral
            int costingSheetId = (int)e.Keys["CostingSheetID"];
            int refId = (int)e.Keys["RefID"];

            ProjectCombinedCostingSheetInformationOtherCostsInformation model = new ProjectCombinedCostingSheetInformationOtherCostsInformation(projectCostingSheetInformationTDS);

            // Delete cost
            model.Delete(costingSheetId, refId);

            // Store dataset
            otherCostsInformation = (ProjectCostingSheetInformationTDS.CombinedOtherCostsInformationDataTable)model.Table;
            Session["otherCostsInformation"] = otherCostsInformation;
            Session["projectCostingSheetInformationTDS"] = projectCostingSheetInformationTDS;

            StepOtherCostsInformationProcessGrid();
        }



        protected void grdSubcontractors_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Add":
                    // Subcontractors Gridview, if the gridview is edition mode
                    if (grdSubcontractors.EditIndex >= 0)
                    {
                        grdSubcontractors.UpdateRow(grdSubcontractors.EditIndex, true);
                    }

                    // Validate general data
                    Page.Validate("subcontractorsNew");
                    int projectId = Int32.Parse(hdfProjectId.Value);
                    ProjectGateway projectGateway = new ProjectGateway();

                    if (Page.IsValid)
                    {
                        // Validate costs                        
                        projectGateway.LoadByProjectId(projectId);

                        if (projectGateway.GetCountryID(projectId) == 1) //Canada
                        {
                            Page.Validate("subcontractorsCadNew");
                        }
                        else
                        {
                            Page.Validate("subcontractorsUsdNew");
                        }
                    }

                    if (Page.IsValid)
                    {
                        int companyId = Int32.Parse(hdfCompanyId.Value);
                        int subcontractorId = Int32.Parse(((DropDownList)grdSubcontractors.FooterRow.FindControl("ddlSubcontractorNew")).SelectedValue);
                        string unitOfMeasurement = ((DropDownList)grdSubcontractors.FooterRow.FindControl("ddlUnitOfMeasurementSubcontractorsNew")).SelectedValue;
                        string subcontractor = ((DropDownList)grdSubcontractors.FooterRow.FindControl("ddlSubcontractorNew")).SelectedItem.Text;
                        double quantity = double.Parse(((TextBox)grdSubcontractors.FooterRow.FindControl("tbxQuantityNew")).Text.Trim());
                        string comment = ""; if (!string.IsNullOrEmpty(((TextBox)grdSubcontractors.FooterRow.FindControl("tbxCommentNew")).Text.Trim())) comment = ((TextBox)grdSubcontractors.FooterRow.FindControl("tbxCommentNew")).Text.Trim();

                        decimal costCad = 0.0M;
                        decimal totalCostCad = 0.0M;
                        decimal costUsd = 0.0M;
                        decimal totalCostUsd = 0.0M;

                        if (projectGateway.GetCountryID(projectId) == 1) //Canada
                        {
                            costCad = Decimal.Parse(((TextBox)grdSubcontractors.FooterRow.FindControl("tbxCostCADNew")).Text.Trim());
                            totalCostCad = (costCad * decimal.Parse(quantity.ToString()));
                            totalCostCad = Decimal.Round(totalCostCad, 2);
                        }
                        else
                        {
                            costUsd = Decimal.Parse(((TextBox)grdSubcontractors.FooterRow.FindControl("tbxCostUSDNew")).Text.Trim());
                            totalCostUsd = (costUsd * decimal.Parse(quantity.ToString()));
                            totalCostUsd = Decimal.Round(totalCostUsd, 2);
                        }

                        DateTime startDate = ((RadDatePicker)grdSubcontractors.FooterRow.FindControl("tkrdpStartDateNew")).SelectedDate.Value;
                        DateTime endDate = ((RadDatePicker)grdSubcontractors.FooterRow.FindControl("tkrdpEndDateNew")).SelectedDate.Value;

                        ProjectCombinedCostingSheetInformationSubcontractorsInformation model = new ProjectCombinedCostingSheetInformationSubcontractorsInformation(projectCostingSheetInformationTDS);
                        model.Insert(0, subcontractorId, unitOfMeasurement, quantity, costCad, totalCostCad, costUsd, totalCostUsd, false, companyId, subcontractor, startDate, endDate, comment);

                        Session.Remove("subcontractorsInformationDummy");
                        subcontractorsInformation = (ProjectCostingSheetInformationTDS.CombinedSubcontractorsInformationDataTable)model.Table;
                        Session["subcontractorsInformation"] = subcontractorsInformation;
                        Session["projectCostingSheetInformationTDS"] = projectCostingSheetInformationTDS;

                        grdSubcontractors.DataBind();

                        StepSubcontractorsInformationProcessGrid();
                    }
                    break;
            }
        }



        protected void grdSubcontractors_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Validate general data
            Page.Validate("subcontractorsEdit");
            int projectId = Int32.Parse(hdfProjectId.Value);
            ProjectGateway projectGateway = new ProjectGateway();

            if (Page.IsValid)
            {
                // Validate costs               
                projectGateway.LoadByProjectId(projectId);

                if (projectGateway.GetCountryID(projectId) == 1) //Canada
                {
                    Page.Validate("subcontractorsCadEdit");
                }
                else
                {
                    Page.Validate("subcontractorsUsdEdit");
                }
            }

            if (Page.IsValid)
            {
                int costingSheetId = (int)e.Keys["CostingSheetID"];
                int subcontractorId = (int)e.Keys["SubcontractorID"];
                int refId = (int)e.Keys["RefID"];

                int companyId = Int32.Parse(hdfCompanyId.Value);
                string unitOfMeasurement = ((DropDownList)grdSubcontractors.Rows[e.RowIndex].Cells[0].FindControl("ddlUnitOfMeasurementSubcontractorsEdit")).SelectedValue;
                string subcontractor = ((TextBox)grdSubcontractors.Rows[e.RowIndex].Cells[0].FindControl("tbxSubcontractorEdit")).Text;
                double quantity = double.Parse(((TextBox)grdSubcontractors.Rows[e.RowIndex].Cells[0].FindControl("tbxQuantityEdit")).Text.Trim());

                decimal costCad = 0.0M;
                decimal totalCostCad = 0.0M;
                decimal costUsd = 0.0M;
                decimal totalCostUsd = 0.0M;

                if (projectGateway.GetCountryID(projectId) == 1) //Canada
                {
                    costCad = Decimal.Parse(((TextBox)grdSubcontractors.Rows[e.RowIndex].Cells[0].FindControl("tbxCostCADEdit")).Text.Trim());
                    totalCostCad = (costCad * decimal.Parse(quantity.ToString()));
                    totalCostCad = Decimal.Round(totalCostCad, 2);
                }
                else
                {
                    costUsd = Decimal.Parse(((TextBox)grdSubcontractors.Rows[e.RowIndex].Cells[0].FindControl("tbxCostUSDEdit")).Text.Trim());
                    totalCostUsd = (costUsd * decimal.Parse(quantity.ToString()));
                    totalCostUsd = Decimal.Round(totalCostUsd, 2);
                }

                DateTime startDate = ((RadDatePicker)grdSubcontractors.Rows[e.RowIndex].Cells[0].FindControl("tkrdpStartDateEdit")).SelectedDate.Value;
                DateTime endDate = ((RadDatePicker)grdSubcontractors.Rows[e.RowIndex].Cells[0].FindControl("tkrdpEndDateEdit")).SelectedDate.Value;

                // Update data
                ProjectCombinedCostingSheetInformationSubcontractorsInformation model = new ProjectCombinedCostingSheetInformationSubcontractorsInformation(projectCostingSheetInformationTDS);
                model.Update(costingSheetId, subcontractorId, refId, unitOfMeasurement, quantity, costCad, totalCostCad, costUsd, totalCostUsd, false, companyId, subcontractor, startDate, endDate);

                // Store dataset
                subcontractorsInformation = (ProjectCostingSheetInformationTDS.CombinedSubcontractorsInformationDataTable)model.Table;
                Session["subcontractorsInformation"] = subcontractorsInformation;
                Session["projectCostingSheetInformationTDS"] = projectCostingSheetInformationTDS;

                StepSubcontractorsInformationProcessGrid();
            }
            else
            {
                e.Cancel = true;
            }
        }



        protected void grdSubcontractors_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Subcontractors Gridview, if the gridview is edition mode
            if (grdSubcontractors.EditIndex >= 0)
            {
                grdSubcontractors.UpdateRow(grdSubcontractors.EditIndex, true);
            }

            // Delete subcontractor
            int costingSheetId = (int)e.Keys["CostingSheetID"];
            int subcontractorId = (int)e.Keys["SubcontractorID"];
            int refId = (int)e.Keys["RefID"];

            ProjectCombinedCostingSheetInformationSubcontractorsInformation model = new ProjectCombinedCostingSheetInformationSubcontractorsInformation(projectCostingSheetInformationTDS);
            model.Delete(costingSheetId, subcontractorId, refId);

            // Store dataset
            subcontractorsInformation = (ProjectCostingSheetInformationTDS.CombinedSubcontractorsInformationDataTable)model.Table;
            Session["subcontractorsInformation"] = subcontractorsInformation;
            Session["projectCostingSheetInformationTDS"] = projectCostingSheetInformationTDS;

            StepSubcontractorsInformationProcessGrid();
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
                //grdTeamMembers.Columns[15].Visible = true;
                //grdTeamMembers.Columns[16].Visible = true;
                grdTeamMembers.Columns[16].Visible = true;
                grdTeamMembers.Columns[17].Visible = false;
                //grdTeamMembers.Columns[19].Visible = false;
                //grdTeamMembers.Columns[20].Visible = false;
                grdTeamMembers.Columns[22].Visible = false;

                // Units Grid
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

                lblSubcontractorsTotalCosts.Text = "Total Cost (CAD) : ";
                tbxSubcontractorsTotalCostsCAD.Visible = true;
                tbxSubcontractorsTotalCostsUSD.Visible = false;

                lblMaterialsTotalCosts.Text = "Total Cost (CAD) : ";
                tbxMaterialsTotalCostsCAD.Visible = true;
                tbxMaterialsTotalCostsUSD.Visible = false;

                lblOtherCostsTotalCosts.Text = "Total Cost (CAD) : ";
                tbxOtherCostsTotalCostsCAD.Visible = true;
                tbxOtherCostsTotalCostsUSD.Visible = false;

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
        // AUXILIAR EVENTS
        //      

        protected void grdMaterials_DataBound(object sender, EventArgs e)
        {
            MaterialsInformationEmptyFix(grdMaterials);
        }



        protected void grdMaterials_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
        }



        protected void grdSubcontractors_DataBound(object sender, EventArgs e)
        {
            SubcontractorsInformationEmptyFix(grdSubcontractors);
        }



        protected void grSubcontractors_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
        }



        protected void grdOtherCosts_DataBound(object sender, EventArgs e)
        {
            OtherCostsInformationEmptyFix(grdOtherCosts);
        }



        protected void grdOtherCosts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }



        protected void grdTeamMembers_DataBound(object sender, EventArgs e)
        {
            LabourHoursInformationEmptyFix(grdTeamMembers);
        }



        protected void grdUnits_DataBound(object sender, EventArgs e)
        {
            UnitsInformationEmptyFix(grdUnits);
        }



        protected void grdUnits_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }



        protected void grdOtherCosts_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Edit items
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Edit) || (e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
            {
                int costingSheetId = Int32.Parse(((Label)e.Row.FindControl("lblCostingSheetIDEdit")).Text.Trim());
                int refId = Int32.Parse(((Label)e.Row.FindControl("lblRefIDEdit")).Text.Trim());

                ProjectCombinedCostingSheetInformationOtherCostsInformationGateway projectCostingSheetInformationOtherCostsInformationGateway = new ProjectCombinedCostingSheetInformationOtherCostsInformationGateway(projectCostingSheetInformationTDS);
                string unitOfMeasurement = projectCostingSheetInformationOtherCostsInformationGateway.GetUnitOfMeasurement(costingSheetId, refId);
                ((DropDownList)e.Row.FindControl("ddlUnitOfMeasurementOthersEdit")).SelectedValue = unitOfMeasurement;

                ((RadDatePicker)e.Row.FindControl("hdfFrom")).SelectedDate = Convert.ToDateTime(hdfFromDate.Value);
                ((RadDatePicker)e.Row.FindControl("hdfTo")).SelectedDate = Convert.ToDateTime(hdfToDate.Value);
            }

            // Footer Item
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                ((RadDatePicker)e.Row.FindControl("hdfFrom")).SelectedDate = Convert.ToDateTime(hdfFromDate.Value);
                ((RadDatePicker)e.Row.FindControl("hdfTo")).SelectedDate = Convert.ToDateTime(hdfToDate.Value);
            }
        }



        protected void grdMaterials_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Edit items
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Edit) || (e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
            {
                int costingSheetId = Int32.Parse(((Label)e.Row.FindControl("lblCostingSheetIDEdit")).Text.Trim());
                int materialId = Int32.Parse(((Label)e.Row.FindControl("lblMaterialIDEdit")).Text.Trim());
                int refId = Int32.Parse(((Label)e.Row.FindControl("lblRefIDEdit")).Text.Trim());

                ProjectCombinedCostingSheetInformationMaterialsInformationGateway projectCostingSheetInformationMaterialsInformationGateway = new ProjectCombinedCostingSheetInformationMaterialsInformationGateway(projectCostingSheetInformationTDS);
                string unitOfMeasurement = projectCostingSheetInformationMaterialsInformationGateway.GetUnitOfMeasurement(costingSheetId, materialId, refId);
                ((DropDownList)e.Row.FindControl("ddlUnitOfMeasurementMaterialsEdit")).SelectedValue = unitOfMeasurement;

                bool inDatabase = projectCostingSheetInformationMaterialsInformationGateway.GetInDatabase(costingSheetId, materialId, refId);

                if (inDatabase)
                {
                    ((RadDatePicker)e.Row.FindControl("tkrdpEndDateEdit")).Calendar.Enabled = false;
                    ((RadDatePicker)e.Row.FindControl("tkrdpEndDateEdit")).DateInput.ReadOnly = true;

                    ((RadDatePicker)e.Row.FindControl("tkrdpStartDateEdit")).Calendar.Enabled = false;
                    ((RadDatePicker)e.Row.FindControl("tkrdpStartDateEdit")).DateInput.ReadOnly = true;
                }

                ((RadDatePicker)e.Row.FindControl("hdfFrom")).SelectedDate = Convert.ToDateTime(hdfFromDate.Value);
                ((RadDatePicker)e.Row.FindControl("hdfTo")).SelectedDate = Convert.ToDateTime(hdfToDate.Value);
            }

            // Footer Item
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                ((RadDatePicker)e.Row.FindControl("hdfFrom")).SelectedDate = Convert.ToDateTime(hdfFromDate.Value);
                ((RadDatePicker)e.Row.FindControl("hdfTo")).SelectedDate = Convert.ToDateTime(hdfToDate.Value);
            }
        }



        protected void grdUnits_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Edit items
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Edit) || (e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
            {
                int costingSheetId = Int32.Parse(((Label)e.Row.FindControl("lblCostingSheetIDEdit")).Text.Trim());
                int unitId = Int32.Parse(((Label)e.Row.FindControl("lblUnitIDEdit")).Text.Trim());
                int refId = Int32.Parse(((Label)e.Row.FindControl("lblRefIDEdit")).Text.Trim());
                string work_ = ((Label)e.Row.FindControl("lblWork_Edit")).Text.Trim();

                ProjectCombinedCostingSheetInformationUnitsInformationGateway projectCostingSheetInformationUnitsInformationGateway = new ProjectCombinedCostingSheetInformationUnitsInformationGateway(projectCostingSheetInformationTDS);
                string unitOfMeasurement = projectCostingSheetInformationUnitsInformationGateway.GetUnitOfMeasurement(costingSheetId, work_, unitId, refId);
                ((DropDownList)e.Row.FindControl("ddlUnitOfMeasurementUnitsEdit")).SelectedValue = unitOfMeasurement;

                bool inDatabase = projectCostingSheetInformationUnitsInformationGateway.GetInDatabase(costingSheetId, work_, unitId, refId);

                if (inDatabase)
                {
                    ((RadDatePicker)e.Row.FindControl("tkrdpEndDateEdit")).Calendar.Enabled = false;
                    ((RadDatePicker)e.Row.FindControl("tkrdpEndDateEdit")).DateInput.ReadOnly = true;

                    ((RadDatePicker)e.Row.FindControl("tkrdpStartDateEdit")).Calendar.Enabled = false;
                    ((RadDatePicker)e.Row.FindControl("tkrdpStartDateEdit")).DateInput.ReadOnly = true;
                }

                ((RadDatePicker)e.Row.FindControl("hdfFrom")).SelectedDate = Convert.ToDateTime(hdfFromDate.Value);
                ((RadDatePicker)e.Row.FindControl("hdfTo")).SelectedDate = Convert.ToDateTime(hdfToDate.Value);
            }

            // Footer Item
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                ((RadDatePicker)e.Row.FindControl("hdfFrom")).SelectedDate = Convert.ToDateTime(hdfFromDate.Value);
                ((RadDatePicker)e.Row.FindControl("hdfTo")).SelectedDate = Convert.ToDateTime(hdfToDate.Value);
            }
        }



        protected void grdSubcontractors_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
        }



        protected void grdTeamMembers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Edit items
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Edit) || (e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
            {
                int costingSheetId = Int32.Parse(((Label)e.Row.FindControl("lblCostingSheetIDEdit")).Text.Trim());
                int employeeId = Int32.Parse(((Label)e.Row.FindControl("lblEmployeeIDEdit")).Text.Trim());
                int refId = Int32.Parse(((Label)e.Row.FindControl("lblRefIDEdit")).Text.Trim());
                string work_ = ((Label)e.Row.FindControl("lblWork_Edit")).Text.Trim();

                ProjectCombinedCostingSheetInformationLabourHoursInformationGateway projectCostingSheetInformationLabourHoursInformationGateway = new ProjectCombinedCostingSheetInformationLabourHoursInformationGateway(projectCostingSheetInformationTDS);
                string unitOfMeasurement = projectCostingSheetInformationLabourHoursInformationGateway.GetLHUnitOfMeasurement(costingSheetId, work_, employeeId, refId);
                ((DropDownList)e.Row.FindControl("ddlUnitOfMeasurementLHEdit")).SelectedValue = unitOfMeasurement;

                string unitOfMeasurementMeals = projectCostingSheetInformationLabourHoursInformationGateway.GetMealsUnitOfMeasurement(costingSheetId, work_, employeeId, refId);
                ((DropDownList)e.Row.FindControl("ddlUnitsOfMeasurementLHMealsEdit")).SelectedValue = unitOfMeasurementMeals;

                string unitOfMeasurementMotel = projectCostingSheetInformationLabourHoursInformationGateway.GetMotelUnitOfMeasurement(costingSheetId, work_, employeeId, refId);
                ((DropDownList)e.Row.FindControl("ddlUnitsOfMeasurementLHMotelEdit")).SelectedValue = unitOfMeasurementMotel;

                bool inDatabase = projectCostingSheetInformationLabourHoursInformationGateway.GetInDatabase(costingSheetId, work_, employeeId, refId);

                if (inDatabase)
                {
                    ((RadDatePicker)e.Row.FindControl("tkrdpEndDateEdit")).Calendar.Enabled = false;
                    ((RadDatePicker)e.Row.FindControl("tkrdpEndDateEdit")).DateInput.ReadOnly = true;

                    ((RadDatePicker)e.Row.FindControl("tkrdpStartDateEdit")).Calendar.Enabled = false;
                    ((RadDatePicker)e.Row.FindControl("tkrdpStartDateEdit")).DateInput.ReadOnly = true;
                }

                ((RadDatePicker)e.Row.FindControl("hdfFrom")).SelectedDate = Convert.ToDateTime(hdfFromDate.Value);
                ((RadDatePicker)e.Row.FindControl("hdfTo")).SelectedDate = Convert.ToDateTime(hdfToDate.Value);
            }

            // Footer Item
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                ((RadDatePicker)e.Row.FindControl("hdfFrom")).SelectedDate = Convert.ToDateTime(hdfFromDate.Value);
                ((RadDatePicker)e.Row.FindControl("hdfTo")).SelectedDate = Convert.ToDateTime(hdfToDate.Value);
            }
        }



        protected void grdTeamMembers_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Team member Gridview, if the gridview is edition mode
            if (grdTeamMembers.EditIndex >= 0)
            {
                grdTeamMembers.UpdateRow(grdTeamMembers.EditIndex, true);
            }
        }



        protected void grdUnits_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Units Gridview, if the gridview is edition mode
            if (grdUnits.EditIndex >= 0)
            {
                grdUnits.UpdateRow(grdUnits.EditIndex, true);
            }
        }



        protected void grdSubcontractors_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Units Gridview, if the gridview is edition mode
            if (grdSubcontractors.EditIndex >= 0)
            {
                grdSubcontractors.UpdateRow(grdSubcontractors.EditIndex, true);
            }
        }



        protected void grdMaterials_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Materials Gridview, if the gridview is edition mode
            if (grdMaterials.EditIndex >= 0)
            {
                grdMaterials.UpdateRow(grdMaterials.EditIndex, true);
            }
        }



        protected void grdOtherCosts_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Other costs Gridview, if the gridview is edition mode
            if (grdOtherCosts.EditIndex >= 0)
            {
                grdOtherCosts.UpdateRow(grdOtherCosts.EditIndex, true);
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATION EVENTS
        //

        protected void tkrmTop_ItemClick(object sender, RadMenuEventArgs e)
        {
            switch (e.Item.Value)
            {
                case "mSave":
                    Save();
                    break;

                case "mApply":
                    Apply();
                    break;

                case "mCancel":
                    string url = "";
                    if (Request.QueryString["source_page"] == "project_costing_sheets_navigator.aspx" || Request.QueryString["source_page"] == "project_combined_costing_sheets_add.aspx")
                    {
                        url = "./project_costing_sheets_navigator.aspx?source_page=project_combined_costing_sheets_edit.aspx&costing_sheet_id=" + hdfCostingSheetId.Value + "&project_id=" + hdfProjectId.Value + "&costing_sheet_state=Approved&active_tab=" + (string)ViewState["active_tab"] + GetNavigatorState() + "&origin=" + (string)ViewState["origin"] + "&update=" + (string)ViewState["update"] + "&data_changed=" + hdfDataChanged.Value + "&state=" + (string)ViewState["state"];
                    }

                    if (Request.QueryString["source_page"] == "project_combined_costing_sheets_summary.aspx")
                    {
                        url = "./project_combined_costing_sheets_summary.aspx?source_page=project_combined_costing_sheets_edit.aspx&costing_sheet_id=" + hdfCostingSheetId.Value + "&project_id=" + hdfProjectId.Value + "&costing_sheet_state=Approved&active_tab=" + (string)ViewState["active_tab"] + GetNavigatorState() + "&origin=" + (string)ViewState["origin"] + "&update=" + (string)ViewState["update"] + "&data_changed=" + hdfDataChanged.Value + "&state=" + (string)ViewState["state"];
                    }
                    Response.Redirect(url);
                    break;
            }
        }



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
        // PUBLIC METHODS
        //

        public ProjectCostingSheetInformationTDS.CombinedOtherCostsInformationDataTable GetOtherCostsInformation()
        {
            otherCostsInformation = (ProjectCostingSheetInformationTDS.CombinedOtherCostsInformationDataTable)Session["otherCostsInformationDummy"];

            if (otherCostsInformation == null)
            {
                otherCostsInformation = (ProjectCostingSheetInformationTDS.CombinedOtherCostsInformationDataTable)Session["otherCostsInformation"];
            }

            return otherCostsInformation;
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



        public ProjectCostingSheetInformationTDS.CombinedLabourHoursInformationDataTable GetLabourHoursInformation()
        {
            labourHoursInformation = (ProjectCostingSheetInformationTDS.CombinedLabourHoursInformationDataTable)Session["labourHoursInformationDummy"];

            if (labourHoursInformation == null)
            {
                labourHoursInformation = (ProjectCostingSheetInformationTDS.CombinedLabourHoursInformationDataTable)Session["labourHoursInformation"];
            }

            return labourHoursInformation;
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



        public ProjectCostingSheetInformationTDS.CombinedSubcontractorsInformationDataTable GetSubcontractorsInformation()
        {
            subcontractorsInformation = (ProjectCostingSheetInformationTDS.CombinedSubcontractorsInformationDataTable)Session["subcontractorsInformationDummy"];

            if (subcontractorsInformation == null)
            {
                subcontractorsInformation = (ProjectCostingSheetInformationTDS.CombinedSubcontractorsInformationDataTable)Session["subcontractorsInformation"];
            }

            return subcontractorsInformation;
        }



        public void DummyTeamMembersNew(int original_CostingSheetID, string original_Work_, int original_EmployeeID)
        {
        }



        public void DummyTeamMembersNew(int original_CostingSheetID, string original_Work_, int original_EmployeeID, int original_RefID)
        {
        }



        public void DummyTeamMembersNew(int CostingSheetID, string Work_)
        {
        }



        public void DummyTeamMembersNew(int CostingSheetID, int EmployeeID)
        {
        }



        public void DummyTeamMembersNew(int CostingSheetID)
        {
        }



        public void DummyUnitsNew(int Original_CostingSheetID, string Original_Work_, int Original_UnitID)
        {
        }



        public void DummyUnitsNew(int Original_CostingSheetID, string Original_Work_, int Original_UnitID, int original_RefID)
        {
        }



        public void DummyUnitsNew(int CostingSheetID, string Work_)
        {
        }



        public void DummyUnitsNew(int CostingSheetID, int UnitID)
        {
        }



        public void DummyUnitsNew(int CostingSheetID)
        {
        }



        public void DummySubcontractorsNew(int Original_CostingSheetID, int Original_SubcontractorID, int original_RefID)
        {
        }



        public void DummySubcontractorsNew(int CostingSheetID, int SubcontractorID)
        {
        }



        public void DummySubcontractorsNew(int CostingSheetID)
        {
        }



        public void DummyMaterialsNew(int original_CostingSheetID, int original_MaterialID, int original_RefID)
        {
        }



        public void DummyMaterialsNew(int CostingSheetID, int MaterialID)
        {
        }



        public void DummyMaterialsNew(int CostingSheetID)
        {
        }



        public void DummyOtherCostsNew(int original_CostingSheetID, int original_RefID)
        {
        }



        public void DummyOtherCostsNew(int CostingSheetID)
        {
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        private void RegisterClientScripts()
        {
            string contentVariables = "";
            contentVariables += "var hdfCostingSheetIdId = '" + hdfCostingSheetId.ClientID + "';";
            contentVariables += "var hdfProjectIdId = '" + hdfProjectId.ClientID + "';";
            contentVariables += "var hdfClientIdId = '" + hdfClientId.ClientID + "';";
            contentVariables += "var hdfDataChangedId = '" + hdfDataChanged.ClientID + "';";
            contentVariables += "var hdfDataChangedMessageId = '" + hdfDataChangedMessage.ClientID + "';";
            contentVariables += "var hdfBeforeUnloadOrigenId = '" + hdfBeforeUnloadOrigen.ClientID + "';";

            // Publishing body's OnKeyDown event 
            HtmlGenericControl bodyUnload = (HtmlGenericControl)Page.Master.FindControl("myBody");
            bodyUnload.Attributes.Add("OnKeyDown", "OnKeyDown(event);");

            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./project_combined_costing_sheets_edit.js");
        }



        private void StoreNavigatorState()
        {
            ViewState["navigatorState"] = "&search_projectnumber=" + Request.QueryString["search_projectnumber"] + "&search_projectname=" + Request.QueryString["search_projectname"] + "&search_client=" + Request.QueryString["search_client"] + "&search_type=" + Request.QueryString["search_type"] + "&search_state=" + Request.QueryString["search_state"];
        }



        private string GetNavigatorState()
        {
            // Return
            return (string)ViewState["navigatorState"];
        }



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
                hdfCostingSheetName.Value = projectCostingSheetInformationBasicInformationGateway.GetName(costingSheetId);
                hdfFromDate.Value = projectCostingSheetInformationBasicInformationGateway.GetStartDate(costingSheetId).ToString();
                hdfToDate.Value = projectCostingSheetInformationBasicInformationGateway.GetEndDate(costingSheetId).ToString();

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



        private void StepMaterialInformationProcessGrid()
        {
            decimal totalCostCadLH = 0;
            decimal totalCostUsdLH = 0;

            foreach (ProjectCostingSheetInformationTDS.CombinedMaterialsInformationRow row in (ProjectCostingSheetInformationTDS.CombinedMaterialsInformationDataTable)Session["materialsInformation"])
            {
                if (!row.Deleted)
                {
                    totalCostCadLH = totalCostCadLH + row.TotalCostCad;
                    totalCostUsdLH = totalCostUsdLH + row.TotalCostUsd;
                }
            }

            tbxMaterialsTotalCostsCAD.Text = Math.Round(totalCostCadLH, 2).ToString();
            tbxMaterialsTotalCostsUSD.Text = Math.Round(totalCostUsdLH, 2).ToString();

            tbxTotalCostCad.Text = Math.Round(Decimal.Parse(tbxTeamMembersTotalCostCAD.Text) + Decimal.Parse(tbxMaterialsTotalCostsCAD.Text) + Decimal.Parse(tbxUnitsTotalCostsCAD.Text) + Decimal.Parse(tbxOtherCostsTotalCostsCAD.Text) + Decimal.Parse(tbxSubcontractorsTotalCostsCAD.Text), 2).ToString();
            tbxTotalCostUsd.Text = Math.Round(Decimal.Parse(tbxTeamMembersTotalCostUSD.Text) + Decimal.Parse(tbxMaterialsTotalCostsUSD.Text) + Decimal.Parse(tbxUnitsTotalCostsUSD.Text) + Decimal.Parse(tbxOtherCostsTotalCostsUSD.Text) + Decimal.Parse(tbxSubcontractorsTotalCostsUSD.Text), 2).ToString();

            int projectId = Int32.Parse(hdfProjectId.Value);
            ProjectGateway projectGateway = new ProjectGateway();
            projectGateway.LoadByProjectId(projectId);

            decimal grandTotal = 0.0M;
            decimal grandRevenue = decimal.Round(decimal.Parse(tbxRevenueTotal.Text), 2);
            decimal grandProfit = 0.0M;
            decimal grandGrossMargin = 0.0M;

            if (projectGateway.GetCountryID(projectId) == 1) //Canada
            {
                grandTotal = Math.Round(Decimal.Parse(tbxTeamMembersTotalCostCAD.Text) + Decimal.Parse(tbxMaterialsTotalCostsCAD.Text) + Decimal.Parse(tbxUnitsTotalCostsCAD.Text) + Decimal.Parse(tbxOtherCostsTotalCostsCAD.Text) + Decimal.Parse(tbxSubcontractorsTotalCostsCAD.Text), 2);
            }
            else
            {
                grandTotal = Math.Round(Decimal.Parse(tbxTeamMembersTotalCostUSD.Text) + Decimal.Parse(tbxMaterialsTotalCostsUSD.Text) + Decimal.Parse(tbxUnitsTotalCostsUSD.Text) + Decimal.Parse(tbxOtherCostsTotalCostsUSD.Text) + Decimal.Parse(tbxSubcontractorsTotalCostsUSD.Text), 2);
            }

            grandProfit = grandRevenue - grandTotal;

            if (grandRevenue > 0)
            {
                grandGrossMargin = (grandProfit / grandRevenue) * 100;
            }
            else
            {
                grandGrossMargin = 0;
            }

            tbxGrandProfit.Text = grandProfit.ToString();
            tbxGrandGrossMargin.Text = decimal.Round(grandGrossMargin, 2).ToString();
        }



        private void StepLabourHoursInformationProcessGrid()
        {
            decimal totalCostCadLH = 0;
            decimal totalCostUsdLH = 0;

            foreach (ProjectCostingSheetInformationTDS.CombinedLabourHoursInformationRow row in (ProjectCostingSheetInformationTDS.CombinedLabourHoursInformationDataTable)Session["labourHoursInformation"])
            {
                if (!row.Deleted)
                {
                    totalCostCadLH = totalCostCadLH + row.TotalCostCad;
                    totalCostUsdLH = totalCostUsdLH + row.TotalCostUsd;
                }
            }

            tbxTeamMembersTotalCostCAD.Text = Math.Round(totalCostCadLH, 2).ToString();
            tbxTeamMembersTotalCostUSD.Text = Math.Round(totalCostUsdLH, 2).ToString();

            tbxTotalCostCad.Text = Math.Round(Decimal.Parse(tbxTeamMembersTotalCostCAD.Text) + Decimal.Parse(tbxMaterialsTotalCostsCAD.Text) + Decimal.Parse(tbxUnitsTotalCostsCAD.Text) + Decimal.Parse(tbxOtherCostsTotalCostsCAD.Text) + Decimal.Parse(tbxSubcontractorsTotalCostsCAD.Text), 2).ToString();
            tbxTotalCostUsd.Text = Math.Round(Decimal.Parse(tbxTeamMembersTotalCostUSD.Text) + Decimal.Parse(tbxMaterialsTotalCostsUSD.Text) + Decimal.Parse(tbxUnitsTotalCostsUSD.Text) + Decimal.Parse(tbxOtherCostsTotalCostsUSD.Text) + Decimal.Parse(tbxSubcontractorsTotalCostsUSD.Text), 2).ToString();

            int projectId = Int32.Parse(hdfProjectId.Value);
            ProjectGateway projectGateway = new ProjectGateway();
            projectGateway.LoadByProjectId(projectId);

            decimal grandTotal = 0.0M;
            decimal grandRevenue = decimal.Round(decimal.Parse(tbxRevenueTotal.Text), 2);
            decimal grandProfit = 0.0M;
            decimal grandGrossMargin = 0.0M;

            if (projectGateway.GetCountryID(projectId) == 1) //Canada
            {
                grandTotal = Math.Round(Decimal.Parse(tbxTeamMembersTotalCostCAD.Text) + Decimal.Parse(tbxMaterialsTotalCostsCAD.Text) + Decimal.Parse(tbxUnitsTotalCostsCAD.Text) + Decimal.Parse(tbxOtherCostsTotalCostsCAD.Text) + Decimal.Parse(tbxSubcontractorsTotalCostsCAD.Text), 2);
            }
            else
            {
                grandTotal = Math.Round(Decimal.Parse(tbxTeamMembersTotalCostUSD.Text) + Decimal.Parse(tbxMaterialsTotalCostsUSD.Text) + Decimal.Parse(tbxUnitsTotalCostsUSD.Text) + Decimal.Parse(tbxOtherCostsTotalCostsUSD.Text) + Decimal.Parse(tbxSubcontractorsTotalCostsUSD.Text), 2);
            }

            grandProfit = grandRevenue - grandTotal;

            if (grandRevenue > 0)
            {
                grandGrossMargin = (grandProfit / grandRevenue) * 100;
            }
            else
            {
                grandGrossMargin = 0;
            }

            tbxGrandProfit.Text = grandProfit.ToString();
            tbxGrandGrossMargin.Text = decimal.Round(grandGrossMargin, 2).ToString();
        }



        private void StepOtherCostsInformationProcessGrid()
        {
            decimal totalCostCadLH = 0;
            decimal totalCostUsdLH = 0;

            foreach (ProjectCostingSheetInformationTDS.CombinedOtherCostsInformationRow row in (ProjectCostingSheetInformationTDS.CombinedOtherCostsInformationDataTable)Session["otherCostsInformation"])
            {
                if (!row.Deleted)
                {
                    totalCostCadLH = totalCostCadLH + row.TotalCostCad;
                    totalCostUsdLH = totalCostUsdLH + row.TotalCostUsd;
                }
            }

            tbxOtherCostsTotalCostsCAD.Text = Math.Round(totalCostCadLH, 2).ToString();
            tbxOtherCostsTotalCostsUSD.Text = Math.Round(totalCostUsdLH, 2).ToString();

            tbxTotalCostCad.Text = Math.Round(Decimal.Parse(tbxTeamMembersTotalCostCAD.Text) + Decimal.Parse(tbxMaterialsTotalCostsCAD.Text) + Decimal.Parse(tbxUnitsTotalCostsCAD.Text) + Decimal.Parse(tbxOtherCostsTotalCostsCAD.Text) + Decimal.Parse(tbxSubcontractorsTotalCostsCAD.Text), 2).ToString();
            tbxTotalCostUsd.Text = Math.Round(Decimal.Parse(tbxTeamMembersTotalCostUSD.Text) + Decimal.Parse(tbxMaterialsTotalCostsUSD.Text) + Decimal.Parse(tbxUnitsTotalCostsUSD.Text) + Decimal.Parse(tbxOtherCostsTotalCostsUSD.Text) + Decimal.Parse(tbxSubcontractorsTotalCostsUSD.Text), 2).ToString();

            int projectId = Int32.Parse(hdfProjectId.Value);
            ProjectGateway projectGateway = new ProjectGateway();
            projectGateway.LoadByProjectId(projectId);

            decimal grandTotal = 0.0M;
            decimal grandRevenue = decimal.Round(decimal.Parse(tbxRevenueTotal.Text), 2);
            decimal grandProfit = 0.0M;
            decimal grandGrossMargin = 0.0M;

            if (projectGateway.GetCountryID(projectId) == 1) //Canada
            {
                grandTotal = Math.Round(Decimal.Parse(tbxTeamMembersTotalCostCAD.Text) + Decimal.Parse(tbxMaterialsTotalCostsCAD.Text) + Decimal.Parse(tbxUnitsTotalCostsCAD.Text) + Decimal.Parse(tbxOtherCostsTotalCostsCAD.Text) + Decimal.Parse(tbxSubcontractorsTotalCostsCAD.Text), 2);
            }
            else
            {
                grandTotal = Math.Round(Decimal.Parse(tbxTeamMembersTotalCostUSD.Text) + Decimal.Parse(tbxMaterialsTotalCostsUSD.Text) + Decimal.Parse(tbxUnitsTotalCostsUSD.Text) + Decimal.Parse(tbxOtherCostsTotalCostsUSD.Text) + Decimal.Parse(tbxSubcontractorsTotalCostsUSD.Text), 2);
            }

            grandProfit = grandRevenue - grandTotal;

            if (grandRevenue > 0)
            {
                grandGrossMargin = (grandProfit / grandRevenue) * 100;
            }
            else
            {
                grandGrossMargin = 0;
            }

            tbxGrandProfit.Text = grandProfit.ToString();
            tbxGrandGrossMargin.Text = decimal.Round(grandGrossMargin, 2).ToString();
        }



        private void StepTrucksEquipmentInformationProcessGrid()
        {
            decimal totalCostCadLH = 0;
            decimal totalCostUsdLH = 0;

            foreach (ProjectCostingSheetInformationTDS.CombinedUnitsInformationRow row in (ProjectCostingSheetInformationTDS.CombinedUnitsInformationDataTable)Session["unitsInformation"])
            {
                if (!row.Deleted)
                {
                    totalCostCadLH = totalCostCadLH + row.TotalCostCad;
                    totalCostUsdLH = totalCostUsdLH + row.TotalCostUsd;
                }
            }

            tbxUnitsTotalCostsCAD.Text = Math.Round(totalCostCadLH, 2).ToString();
            tbxUnitsTotalCostsUSD.Text = Math.Round(totalCostUsdLH, 2).ToString();

            tbxTotalCostCad.Text = Math.Round(Decimal.Parse(tbxTeamMembersTotalCostCAD.Text) + Decimal.Parse(tbxMaterialsTotalCostsCAD.Text) + Decimal.Parse(tbxUnitsTotalCostsCAD.Text) + Decimal.Parse(tbxOtherCostsTotalCostsCAD.Text) + Decimal.Parse(tbxSubcontractorsTotalCostsCAD.Text), 2).ToString();
            tbxTotalCostUsd.Text = Math.Round(Decimal.Parse(tbxTeamMembersTotalCostUSD.Text) + Decimal.Parse(tbxMaterialsTotalCostsUSD.Text) + Decimal.Parse(tbxUnitsTotalCostsUSD.Text) + Decimal.Parse(tbxOtherCostsTotalCostsUSD.Text) + Decimal.Parse(tbxSubcontractorsTotalCostsUSD.Text), 2).ToString();

            int projectId = Int32.Parse(hdfProjectId.Value);
            ProjectGateway projectGateway = new ProjectGateway();
            projectGateway.LoadByProjectId(projectId);

            decimal grandTotal = 0.0M;
            decimal grandRevenue = decimal.Round(decimal.Parse(tbxRevenueTotal.Text), 2);
            decimal grandProfit = 0.0M;
            decimal grandGrossMargin = 0.0M;

            if (projectGateway.GetCountryID(projectId) == 1) //Canada
            {
                grandTotal = Math.Round(Decimal.Parse(tbxTeamMembersTotalCostCAD.Text) + Decimal.Parse(tbxMaterialsTotalCostsCAD.Text) + Decimal.Parse(tbxUnitsTotalCostsCAD.Text) + Decimal.Parse(tbxOtherCostsTotalCostsCAD.Text) + Decimal.Parse(tbxSubcontractorsTotalCostsCAD.Text), 2);
            }
            else
            {
                grandTotal = Math.Round(Decimal.Parse(tbxTeamMembersTotalCostUSD.Text) + Decimal.Parse(tbxMaterialsTotalCostsUSD.Text) + Decimal.Parse(tbxUnitsTotalCostsUSD.Text) + Decimal.Parse(tbxOtherCostsTotalCostsUSD.Text) + Decimal.Parse(tbxSubcontractorsTotalCostsUSD.Text), 2);
            }

            grandProfit = grandRevenue - grandTotal;

            if (grandRevenue > 0)
            {
                grandGrossMargin = (grandProfit / grandRevenue) * 100;
            }
            else
            {
                grandGrossMargin = 0;
            }

            tbxGrandProfit.Text = grandProfit.ToString();
            tbxGrandGrossMargin.Text = decimal.Round(grandGrossMargin, 2).ToString();
        }



        private void StepSubcontractorsInformationProcessGrid()
        {
            decimal totalCostCadLH = 0;
            decimal totalCostUsdLH = 0;

            foreach (ProjectCostingSheetInformationTDS.CombinedSubcontractorsInformationRow row in (ProjectCostingSheetInformationTDS.CombinedSubcontractorsInformationDataTable)Session["subcontractorsInformation"])
            {
                if (!row.Deleted)
                {
                    totalCostCadLH = totalCostCadLH + row.TotalCostCad;
                    totalCostUsdLH = totalCostUsdLH + row.TotalCostUsd;
                }
            }

            tbxSubcontractorsTotalCostsCAD.Text = Math.Round(totalCostCadLH, 2).ToString();
            tbxSubcontractorsTotalCostsUSD.Text = Math.Round(totalCostUsdLH, 2).ToString();

            tbxTotalCostCad.Text = Math.Round(Decimal.Parse(tbxTeamMembersTotalCostCAD.Text) + Decimal.Parse(tbxMaterialsTotalCostsCAD.Text) + Decimal.Parse(tbxUnitsTotalCostsCAD.Text) + Decimal.Parse(tbxOtherCostsTotalCostsCAD.Text) + Decimal.Parse(tbxSubcontractorsTotalCostsCAD.Text), 2).ToString();
            tbxTotalCostUsd.Text = Math.Round(Decimal.Parse(tbxTeamMembersTotalCostUSD.Text) + Decimal.Parse(tbxMaterialsTotalCostsUSD.Text) + Decimal.Parse(tbxUnitsTotalCostsUSD.Text) + Decimal.Parse(tbxOtherCostsTotalCostsUSD.Text) + Decimal.Parse(tbxSubcontractorsTotalCostsUSD.Text), 2).ToString();

            int projectId = Int32.Parse(hdfProjectId.Value);
            ProjectGateway projectGateway = new ProjectGateway();
            projectGateway.LoadByProjectId(projectId);

            decimal grandTotal = 0.0M;
            decimal grandRevenue = decimal.Round(decimal.Parse(tbxRevenueTotal.Text), 2);
            decimal grandProfit = 0.0M;
            decimal grandGrossMargin = 0.0M;

            if (projectGateway.GetCountryID(projectId) == 1) //Canada
            {
                grandTotal = Math.Round(Decimal.Parse(tbxTeamMembersTotalCostCAD.Text) + Decimal.Parse(tbxMaterialsTotalCostsCAD.Text) + Decimal.Parse(tbxUnitsTotalCostsCAD.Text) + Decimal.Parse(tbxOtherCostsTotalCostsCAD.Text) + Decimal.Parse(tbxSubcontractorsTotalCostsCAD.Text), 2);
            }
            else
            {
                grandTotal = Math.Round(Decimal.Parse(tbxTeamMembersTotalCostUSD.Text) + Decimal.Parse(tbxMaterialsTotalCostsUSD.Text) + Decimal.Parse(tbxUnitsTotalCostsUSD.Text) + Decimal.Parse(tbxOtherCostsTotalCostsUSD.Text) + Decimal.Parse(tbxSubcontractorsTotalCostsUSD.Text), 2);
            }

            grandProfit = grandRevenue - grandTotal;

            if (grandRevenue > 0)
            {
                grandGrossMargin = (grandProfit / grandRevenue) * 100;
            }
            else
            {
                grandGrossMargin = 0;
            }

            tbxGrandProfit.Text = grandProfit.ToString();
            tbxGrandGrossMargin.Text = decimal.Round(grandGrossMargin, 2).ToString();
        }



        private void Save()
        {
            // Validate data
            bool validData = true;

            // Validate general data
            Page.Validate("general");

            // For valid data
            if (validData)
            {
                // Team Members Gridview, if the gridview is edition mode
                if (grdTeamMembers.EditIndex >= 0)
                {
                    grdTeamMembers.UpdateRow(grdTeamMembers.EditIndex, true);
                }

                // Units Gridview, if the gridview is edition mode
                if (grdUnits.EditIndex >= 0)
                {
                    grdUnits.UpdateRow(grdUnits.EditIndex, true);
                }

                // Materials Gridview, if the gridview is edition mode
                if (grdMaterials.EditIndex >= 0)
                {
                    grdMaterials.UpdateRow(grdMaterials.EditIndex, true);
                }

                // Other Costs Gridview, if the gridview is edition mode
                if (grdOtherCosts.EditIndex >= 0)
                {
                    grdOtherCosts.UpdateRow(grdOtherCosts.EditIndex, true);
                }

                // Subcontractors Costs Gridview, if the gridview is edition mode
                if (grdSubcontractors.EditIndex >= 0)
                {
                    grdSubcontractors.UpdateRow(grdSubcontractors.EditIndex, true);
                }

                // Basic
                int companyId = Int32.Parse(hdfCompanyId.Value);
                int costingSheetId = Int32.Parse(hdfCostingSheetId.Value);

                // General
                string state = tbxState.Text;
                decimal teamMembersTotalCostCad = decimal.Parse(tbxTeamMembersTotalCostCAD.Text);
                decimal teamMembersTotalCostUsd = decimal.Parse(tbxTeamMembersTotalCostUSD.Text);
                decimal unitsTotalCostCad = decimal.Parse(tbxUnitsTotalCostsCAD.Text);
                decimal unitsTotalCostUsd = decimal.Parse(tbxUnitsTotalCostsUSD.Text);
                decimal materialsTotalCostCad = decimal.Parse(tbxMaterialsTotalCostsCAD.Text);
                decimal materialsTotalCostUsd = decimal.Parse(tbxMaterialsTotalCostsUSD.Text);
                decimal otherCostsTotalCostCad = decimal.Parse(tbxOtherCostsTotalCostsCAD.Text);
                decimal otherCostsTotalCostUsd = decimal.Parse(tbxOtherCostsTotalCostsUSD.Text);
                decimal grandTotalCostCad = decimal.Parse(tbxTotalCostCad.Text);
                decimal grandTotalCostUsd = decimal.Parse(tbxTotalCostUsd.Text);
                decimal subcontractorsTotalCostCad = decimal.Parse(tbxSubcontractorsTotalCostsCAD.Text);
                decimal subcontractorsTotalCostUsd = decimal.Parse(tbxSubcontractorsTotalCostsUSD.Text);

                decimal grandRevenue = 0.0M; if (tbxGrandRevenue.Text != "") grandRevenue = decimal.Parse(tbxGrandRevenue.Text);
                decimal grandProfit = 0.0M; if (tbxGrandProfit.Text != "") grandProfit = decimal.Parse(tbxGrandProfit.Text);
                decimal grandGrossMargin = 0.0M; if (tbxGrandGrossMargin.Text != "") { tbxGrandGrossMargin.Text = tbxGrandGrossMargin.Text.Replace('%', ' '); grandGrossMargin = decimal.Parse(tbxGrandGrossMargin.Text.Trim()); }

                // Update unit data
                ProjectCombinedCostingSheetInformationBasicInformation projectCostingSheetInformationBasicInformation = new ProjectCombinedCostingSheetInformationBasicInformation(projectCostingSheetInformationTDS);
                projectCostingSheetInformationBasicInformation.Update(costingSheetId, hdfCostingSheetName.Value, teamMembersTotalCostCad, teamMembersTotalCostUsd, materialsTotalCostCad, materialsTotalCostUsd, unitsTotalCostCad, unitsTotalCostUsd, otherCostsTotalCostCad, otherCostsTotalCostUsd, grandTotalCostCad, grandTotalCostUsd, subcontractorsTotalCostCad, subcontractorsTotalCostUsd, grandRevenue, grandProfit, grandGrossMargin);

                // Store dataset
                Session["projectCostingSheetInformationTDS"] = projectCostingSheetInformationTDS;

                // Update database
                UpdateDatabase();

                ViewState["update"] = "yes";

                // Redirect
                string url = "";
                if (Request.QueryString["source_page"] == "project_costing_sheets_navigator.aspx" || Request.QueryString["source_page"] == "project_combined_costing_sheets_add.aspx")
                {
                    url = "./project_costing_sheets_navigator.aspx?source_page=project_combined_costing_sheets_edit.aspx&costing_sheet_id=" + hdfCostingSheetId.Value + "&project_id=" + hdfProjectId.Value + "&costing_sheet_state=Approved&active_tab=" + (string)ViewState["active_tab"] + GetNavigatorState() + "&origin=" + (string)ViewState["origin"] + "&update=" + (string)ViewState["update"] + "&data_changed=" + hdfDataChanged.Value + "&state=" + (string)ViewState["state"];
                }

                if (Request.QueryString["source_page"] == "project_combined_costing_sheets_summary.aspx")
                {
                    url = "./project_combined_costing_sheets_summary.aspx?source_page=project_combined_costing_sheets_edit.aspx&costing_sheet_id=" + hdfCostingSheetId.Value + "&project_id=" + hdfProjectId.Value + "&costing_sheet_state=Approved&active_tab=" + (string)ViewState["active_tab"] + GetNavigatorState() + "&origin=" + (string)ViewState["origin"] + "&update=" + (string)ViewState["update"] + "&data_changed=" + hdfDataChanged.Value + "&state=" + (string)ViewState["state"];
                }

                Response.Redirect(url);
            }
        }



        private void Apply()
        {
            // Validate data
            bool validData = true;

            // Validate general data
            Page.Validate("general");

            // For valid data
            if (validData)
            {
                // Team Members Gridview, if the gridview is edition mode
                if (grdTeamMembers.EditIndex >= 0)
                {
                    grdTeamMembers.UpdateRow(grdTeamMembers.EditIndex, true);
                }

                // Units Gridview, if the gridview is edition mode
                if (grdUnits.EditIndex >= 0)
                {
                    grdUnits.UpdateRow(grdUnits.EditIndex, true);
                }

                // Materials Gridview, if the gridview is edition mode
                if (grdMaterials.EditIndex >= 0)
                {
                    grdMaterials.UpdateRow(grdMaterials.EditIndex, true);
                }

                // Other Costs Gridview, if the gridview is edition mode
                if (grdOtherCosts.EditIndex >= 0)
                {
                    grdOtherCosts.UpdateRow(grdOtherCosts.EditIndex, true);
                }

                // Subcontractors Costs Gridview, if the gridview is edition mode
                if (grdSubcontractors.EditIndex >= 0)
                {
                    grdSubcontractors.UpdateRow(grdSubcontractors.EditIndex, true);
                }

                // Basic
                int companyId = Int32.Parse(hdfCompanyId.Value);
                int costingSheetId = Int32.Parse(hdfCostingSheetId.Value);

                // General
                string state = tbxState.Text;
                decimal teamMembersTotalCostCad = decimal.Parse(tbxTeamMembersTotalCostCAD.Text);
                decimal teamMembersTotalCostUsd = decimal.Parse(tbxTeamMembersTotalCostUSD.Text);
                decimal unitsTotalCostCad = decimal.Parse(tbxUnitsTotalCostsCAD.Text);
                decimal unitsTotalCostUsd = decimal.Parse(tbxUnitsTotalCostsUSD.Text);
                decimal materialsTotalCostCad = decimal.Parse(tbxMaterialsTotalCostsCAD.Text);
                decimal materialsTotalCostUsd = decimal.Parse(tbxMaterialsTotalCostsUSD.Text);
                decimal otherCostsTotalCostCad = decimal.Parse(tbxOtherCostsTotalCostsCAD.Text);
                decimal otherCostsTotalCostUsd = decimal.Parse(tbxOtherCostsTotalCostsUSD.Text);
                decimal grandTotalCostCad = decimal.Parse(tbxTotalCostCad.Text);
                decimal grandTotalCostUsd = decimal.Parse(tbxTotalCostUsd.Text);
                decimal subcontractorsTotalCostCad = decimal.Parse(tbxSubcontractorsTotalCostsCAD.Text);
                decimal subcontractorsTotalCostUsd = decimal.Parse(tbxSubcontractorsTotalCostsUSD.Text);

                decimal grandRevenue = 0.0M; if (tbxGrandRevenue.Text != "") grandRevenue = decimal.Parse(tbxGrandRevenue.Text);
                decimal grandProfit = 0.0M; if (tbxGrandProfit.Text != "") grandProfit = decimal.Parse(tbxGrandProfit.Text);
                decimal grandGrossMargin = 0.0M; if (tbxGrandGrossMargin.Text != "") { tbxGrandGrossMargin.Text = tbxGrandGrossMargin.Text.Replace('%', ' '); grandGrossMargin = decimal.Parse(tbxGrandGrossMargin.Text.Trim()); }

                // Update unit data
                ProjectCombinedCostingSheetInformationBasicInformation projectCostingSheetInformationBasicInformation = new ProjectCombinedCostingSheetInformationBasicInformation(projectCostingSheetInformationTDS);
                projectCostingSheetInformationBasicInformation.Update(costingSheetId, hdfCostingSheetName.Value, teamMembersTotalCostCad, teamMembersTotalCostUsd, materialsTotalCostCad, materialsTotalCostUsd, unitsTotalCostCad, unitsTotalCostUsd, otherCostsTotalCostCad, otherCostsTotalCostUsd, grandTotalCostCad, grandTotalCostUsd, subcontractorsTotalCostCad, subcontractorsTotalCostUsd, grandRevenue, grandProfit, grandGrossMargin);

                // Store dataset
                Session["projectCostingSheetInformationTDS"] = projectCostingSheetInformationTDS;

                // Update database
                UpdateDatabase();

                ViewState["update"] = "yes";
            }
        }



        private void UpdateDatabase()
        {
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int costingSheetId = Int32.Parse(hdfCostingSheetId.Value);

            DB.Open();
            DB.BeginTransaction();
            try
            {
                ProjectCombinedCostingSheetInformationBasicInformation projectCostingSheetInformationBasicInformation = new ProjectCombinedCostingSheetInformationBasicInformation(projectCostingSheetInformationTDS);
                projectCostingSheetInformationBasicInformation.Save(companyId);

                // Save costs information
                ProjectCombinedCostingSheetInformationLabourHoursInformation projectCostingSheetInformationLabourHoursInformation = new ProjectCombinedCostingSheetInformationLabourHoursInformation(projectCostingSheetInformationTDS);
                projectCostingSheetInformationLabourHoursInformation.Save(companyId, costingSheetId);

                ProjectCombinedCostingSheetInformationUnitsInformation projectCostingSheetInformationUnitsInformation = new ProjectCombinedCostingSheetInformationUnitsInformation(projectCostingSheetInformationTDS);
                projectCostingSheetInformationUnitsInformation.Save(companyId, costingSheetId);

                ProjectCombinedCostingSheetInformationMaterialsInformation projectCostingSheetInformationMaterialsInformation = new ProjectCombinedCostingSheetInformationMaterialsInformation(projectCostingSheetInformationTDS);
                projectCostingSheetInformationMaterialsInformation.Save(companyId, costingSheetId);

                ProjectCombinedCostingSheetInformationOtherCostsInformation projectCostingSheetInformationOtherCostsInformation = new ProjectCombinedCostingSheetInformationOtherCostsInformation(projectCostingSheetInformationTDS);
                projectCostingSheetInformationOtherCostsInformation.Save(companyId, costingSheetId);

                ProjectCombinedCostingSheetInformationSubcontractorsInformation projectCostingSheetInformationSubcontractorsInformation = new ProjectCombinedCostingSheetInformationSubcontractorsInformation(projectCostingSheetInformationTDS);
                projectCostingSheetInformationSubcontractorsInformation.Save(companyId, costingSheetId);

                DB.CommitTransaction();

                // Store datasets
                projectCostingSheetInformationTDS.AcceptChanges();
                Session["lfsProjectTDS"] = projectTDS;
                Session["projectCostingSheetInformationTDS"] = projectCostingSheetInformationTDS;
                Session["labourHoursInformation"] = projectCostingSheetInformationTDS.CombinedLabourHoursInformation;
                Session["unitsInformation"] = projectCostingSheetInformationTDS.CombinedUnitsInformation;
                Session["subcontractorsInformation"] = projectCostingSheetInformationTDS.CombinedSubcontractorsInformation;
                Session["materialsInformation"] = projectCostingSheetInformationTDS.CombinedMaterialsInformation;
                Session["otherCostsInformation"] = projectCostingSheetInformationTDS.CombinedOtherCostsInformation;
            }
            catch (Exception ex)
            {
                DB.RollbackTransaction();

                string url = string.Format("./../../error_page.aspx?error={0}", ex.Message.Replace('\n', ' '));
                Response.Redirect(url);
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PROTECTED METHODS
        //

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



        protected void grdRevenue_DataBound(object sender, EventArgs e)
        {
            RevenueInformationEmptyFix(grdRevenue);
        }



        protected void grdRevenue_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }



        protected void grdRevenue_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Revenue Gridview, if the gridview is edition mode
            if (grdRevenue.EditIndex >= 0)
            {
                grdRevenue.UpdateRow(grdRevenue.EditIndex, true);
            }
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