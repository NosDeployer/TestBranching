using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.BL.Projects.Projects;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.DA.Resources.Companies;
using LiquiForce.LFSLive.Server;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.Projects.Projects
{
    /// <summary>
    /// project_combined_costing_sheets_add
    /// </summary>
    public partial class project_combined_costing_sheets_add : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected ProjectCostingSheetAddTDS projectCostingSheetAddTDS;
        protected ProjectCostingSheetAddTDS.CombinedLabourHoursInformationDataTable labourHoursInformation;
        protected ProjectCostingSheetAddTDS.CombinedUnitsInformationDataTable unitsInformation;
        protected ProjectCostingSheetAddTDS.CombinedSubcontractorsInformationDataTable subcontractorsInformation;
        protected ProjectCostingSheetAddTDS.CombinedMaterialsInformationDataTable materialsInformation;
        protected ProjectCostingSheetAddTDS.CombinedOtherCostsInformationDataTable otherCostsInformation;
        protected ProjectCostingSheetAddTDS.CombinedRevenueInformationDataTable revenueInformation;
        protected ProjectCostingSheetAddTDS.TemplateInformationDataTable templateInformation;
        protected ArrayList projectsSelected;
        List<ListItem> projectList = new List<ListItem>();






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
                    if (!(Convert.ToBoolean(Session["sgLFS_PROJECTS_COSTINGSHEETS_VIEW"]) && Convert.ToBoolean(Session["sgLFS_PROJECTS_COSTINGSHEETS_ADD"])))
                    {
                        Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                    }
                }

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["client_id"] == null) || ((string)Request.QueryString["project_id"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in project_combined_costing_sheets_add.aspx");
                }

                if ((string)Request.QueryString["project_id"] == "0")
                {
                    if (Session["projectsSelected"] != null)
                    {
                        projectsSelected = (ArrayList)Session["projectsSelected"];
                    }
                    else
                    {
                        Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in project_combined_costing_sheets_add.aspx");
                    }
                }
                else
                {
                    projectsSelected = new ArrayList();
                    projectsSelected.Add(int.Parse((string)Request.QueryString["project_id"]));
                    Session["projectsSelected"] = projectsSelected;
                }

                // Tag Page
                TagPage();

                // Initialize viewstate variables
                ViewState["StepFrom"] = "Out";
                Session.Remove("labourHoursInformationDummy");
                Session.Remove("labourHoursInformation");
                Session.Remove("unitsInformationDummy");
                Session.Remove("unitsInformation");
                Session.Remove("subcontractorsInformationDummy");
                Session.Remove("subcontractorsInformation");
                Session.Remove("materialsInformationDummy");
                Session.Remove("materialsInformation");
                Session.Remove("otherCostsInformationDummy");
                Session.Remove("otherCostsInformation");
                Session.Remove("revenueInformationDummy");
                Session.Remove("revenueInformation");
                Session.Remove("templateInformationDummy");
                Session.Remove("templateInformation");

                // ... Initialize tables
                projectCostingSheetAddTDS = new ProjectCostingSheetAddTDS();
                labourHoursInformation = new ProjectCostingSheetAddTDS.CombinedLabourHoursInformationDataTable();
                unitsInformation = new ProjectCostingSheetAddTDS.CombinedUnitsInformationDataTable();
                subcontractorsInformation = new ProjectCostingSheetAddTDS.CombinedSubcontractorsInformationDataTable();
                materialsInformation = new ProjectCostingSheetAddTDS.CombinedMaterialsInformationDataTable();
                otherCostsInformation = new ProjectCostingSheetAddTDS.CombinedOtherCostsInformationDataTable();
                revenueInformation = new ProjectCostingSheetAddTDS.CombinedRevenueInformationDataTable();
                templateInformation = new ProjectCostingSheetAddTDS.TemplateInformationDataTable();
                
                tbxTeamMembersTotalCostCAD.Text = "0";
                tbxTeamMembersTotalCostUSD.Text = "0";
                tbxUnitsTotalCostsCAD.Text = "0";
                tbxUnitsTotalCostsUSD.Text = "0";
                tbxSubcontractorsTotalCostsCAD.Text = "0";
                tbxSubcontractorsTotalCostsUSD.Text = "0";
                tbxMaterialsTotalCostsCAD.Text = "0";
                tbxMaterialsTotalCostsUSD.Text = "0";
                tbxOtherCostsTotalCostsCAD.Text = "0";
                tbxOtherCostsTotalCostsUSD.Text = "0";
                tbxRevenueTotal.Text = "0";
                tbxGradRevenue.Text = "0";
                tbxGrandProfit.Text = "0";
                tbxGrandGrossMargin.Text = "0";

                // ... Store tables
                Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;
                Session["labourHoursInformation"] = labourHoursInformation;
                Session["unitsInformation"] = unitsInformation;
                Session["subcontractorsInformation"] = subcontractorsInformation;
                Session["materialsInformation"] = materialsInformation;
                Session["otherCostsInformation"] = otherCostsInformation;
                Session["revenueInformation"] = revenueInformation;
                Session["templateInformation"] = templateInformation;
                
                // StepGeneralInformation
                wzProjectCostinsSheetsAdd.ActiveStepIndex = 0;
            }
            else
            {
                // Restore tables
                projectCostingSheetAddTDS = (ProjectCostingSheetAddTDS)Session["projectCostingSheetAddTDS"];
                labourHoursInformation = (ProjectCostingSheetAddTDS.CombinedLabourHoursInformationDataTable)Session["labourHoursInformation"];
                unitsInformation = (ProjectCostingSheetAddTDS.CombinedUnitsInformationDataTable)Session["unitsInformation"];
                subcontractorsInformation = (ProjectCostingSheetAddTDS.CombinedSubcontractorsInformationDataTable)Session["subcontractorsInformation"];
                materialsInformation = (ProjectCostingSheetAddTDS.CombinedMaterialsInformationDataTable)Session["materialsInformation"];
                otherCostsInformation = (ProjectCostingSheetAddTDS.CombinedOtherCostsInformationDataTable)Session["otherCostsInformation"];
                revenueInformation = (ProjectCostingSheetAddTDS.CombinedRevenueInformationDataTable)Session["revenueInformation"];
                templateInformation = (ProjectCostingSheetAddTDS.TemplateInformationDataTable)Session["templateInformation"];
                projectsSelected = (ArrayList)Session["projectsSelected"];

                foreach (int projectIdSelected in projectsSelected)
                {
                    ProjectGateway projectGateway = new ProjectGateway();
                    projectGateway.LoadByProjectId(projectIdSelected);

                    string name = projectGateway.GetName(projectIdSelected);

                    projectList.Add(new ListItem(name, projectIdSelected.ToString()));
                }
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
                switch (wzProjectCostinsSheetsAdd.ActiveStep.Name)
                {
                    case "Begin":
                        StepBeginIn();
                        break;

                    case "Template":
                        StepTemplateIn();
                        break;

                    case "GeneralInformation":
                        StepGeneralInformationIn();
                        break;

                    case "LabourHourInformation":
                        StepLabourHourInformationIn();
                        break;

                    case "TrucksEquipmentInformation":
                        StepTrucksEquipmentInformationIn();
                        break;

                    case "MaterialInformation":
                        StepMaterialInformationIn();
                        break;

                    case "SubcontractorInformation":
                        StepSubcontractorsInformationIn();
                        break;

                    case "OtherCostInformation":
                        StepOtherCostInformationIn();
                        break;

                    case "RevenueInformation":
                        StepRevenueInformationIn();
                        break;

                    case "Summary":
                        StepSummaryIn();
                        break;

                    case "FinalStep":
                        StepFinalStepIn();
                        wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepFinalStep);
                        break;

                    default:
                        throw new Exception("The option for " + wzProjectCostinsSheetsAdd.ActiveStep.Name + " step in project_combined_costing_sheets_add.Wizard_ActiveStepChanged function does not exist");
                }
            }
        }



        protected void Wizard_NextButtonClick(object sender, WizardNavigationEventArgs e)
        {
            switch (wzProjectCostinsSheetsAdd.ActiveStep.Name)
            {
                case "Begin":
                    // Standard: Code for guider step
                    int stepBeginTo = StepBeginNext();
                    if (stepBeginTo == -1)
                    {
                        e.Cancel = true;
                    }
                    else
                    {
                        ViewState["StepFrom"] = "Begin";
                        wzProjectCostinsSheetsAdd.ActiveStepIndex = stepBeginTo;
                    }
                    break;

                case "Template":
                    // Standard: Code for normal step
                    e.Cancel = !StepTemplateNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "Template";
                    }
                    break;

                case "GeneralInformation":
                    e.Cancel = !StepGeneralInformationNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "GeneralInformation";

                        if (cbxEndConfirm.Checked)
                        {
                            if (cbxLabourHour.Checked)
                            {
                                wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepLabourHourInformation);
                            }
                            else
                            {
                                if (cbxTrucksEquipment.Checked)
                                {
                                    wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepTrucksEquipmentInformation);
                                }
                                else
                                {
                                    if (cbxMaterial.Checked)
                                    {
                                        wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepMaterialInformation);
                                    }
                                    else
                                    {
                                        if (cbxSubcontractor.Checked)
                                        {
                                            wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepSubcontractorInformation);
                                        }
                                        else
                                        {
                                            if (cbxOtherCost.Checked)
                                            {
                                                wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepOtherCostInformation);
                                            }
                                            else
                                            {
                                                if (cbxRevenueInformation.Checked)
                                                {
                                                    wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(stepRevenueInformation);
                                                }
                                                else
                                                {
                                                    wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepSummary);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (cbxEndSave.Checked)
                            {
                                wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepSummary);
                            }
                        }
                    }
                    break;

                case "LabourHourInformation":
                    e.Cancel = !StepLabourHourInformationNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "LabourHourInformation";

                        if (cbxTrucksEquipment.Checked)
                        {
                            wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepTrucksEquipmentInformation);
                        }
                        else
                        {
                            if (cbxMaterial.Checked)
                            {
                                wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepMaterialInformation);
                            }
                            else
                            {
                                if (cbxSubcontractor.Checked)
                                {
                                    wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepSubcontractorInformation);
                                }
                                else
                                {
                                    if (cbxOtherCost.Checked)
                                    {
                                        wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepOtherCostInformation);
                                    }
                                    else
                                    {
                                        if (cbxRevenueInformation.Checked)
                                        {
                                            wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(stepRevenueInformation);
                                        }
                                        else
                                        {
                                            wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepSummary);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    break;

                case "TrucksEquipmentInformation":
                    e.Cancel = !StepTrucksEquipmentInformationNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "TrucksEquipmentInformation";

                        if (cbxMaterial.Checked)
                        {
                            wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepMaterialInformation);
                        }
                        else
                        {
                            if (cbxSubcontractor.Checked)
                            {
                                wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepSubcontractorInformation);
                            }
                            else
                            {
                                if (cbxOtherCost.Checked)
                                {
                                    wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepOtherCostInformation);
                                }
                                else
                                {
                                    if (cbxRevenueInformation.Checked)
                                    {
                                        wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(stepRevenueInformation);
                                    }
                                    else
                                    {
                                        wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepSummary);
                                    }
                                }
                            }
                        }
                    }
                    break;

                case "MaterialInformation":
                    e.Cancel = !StepMaterialInformationNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "MaterialInformation";

                        if (cbxSubcontractor.Checked)
                        {
                            wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepSubcontractorInformation);
                        }
                        else
                        {
                            if (cbxOtherCost.Checked)
                            {
                                wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepOtherCostInformation);
                            }
                            else
                            {
                                if (cbxRevenueInformation.Checked)
                                {
                                    wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(stepRevenueInformation);
                                }
                                else
                                {
                                    wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepSummary);
                                }
                            }
                        }
                    }
                    break;

                case "SubcontractorInformation":
                    e.Cancel = !StepSubcontractorsInformationNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "SubcontractorInformation";

                        if (cbxOtherCost.Checked)
                        {
                            wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepOtherCostInformation);
                        }
                        else
                        {
                            if (cbxRevenueInformation.Checked)
                            {
                                wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(stepRevenueInformation);
                            }
                            else
                            {
                                wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepSummary);
                            }
                        }
                    }
                    break;

                case "OtherCostInformation":
                    e.Cancel = !StepOtherCostInformationNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "OtherCostInformation";

                        if (cbxRevenueInformation.Checked)
                        {
                            wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(stepRevenueInformation);
                        }
                        else
                        {
                            wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepSummary);
                        }
                    }
                    break;

                case "RevenueInformation":
                    e.Cancel = !StepRevenueInformationNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "RevenueInformation";
                    }
                    break;

                default:
                    throw new Exception("The option for " + wzProjectCostinsSheetsAdd.ActiveStep.Name + " step in project_combined_costing_sheets_add.Wizard_NextButtonClick function does not exist");
            }
        }



        protected void Wizard_PreviousButtonClick(object sender, WizardNavigationEventArgs e)
        {
            switch (wzProjectCostinsSheetsAdd.ActiveStep.Name)
            {
                case "Template":
                    e.Cancel = !StepTemplatePrevious();
                    break;

                case "GeneralInformation":
                    e.Cancel = !StepGeneralInformationPrevious();
                    break;

                case "LabourHourInformation":
                    e.Cancel = !StepLabourHourInformationPrevious();
                    break;

                case "TrucksEquipmentInformation":
                    e.Cancel = !StepTrucksEquipmentInformationPrevious();
                    break;

                case "MaterialInformation":
                    e.Cancel = !StepMaterialInformationPrevious();
                    break;

                case "SubcontractorInformation":
                    e.Cancel = !StepSubcontractorsInformationPrevious();
                    break;

                case "OtherCostInformation":
                    e.Cancel = !StepOtherCostInformationPrevious();
                    break;

                case "RevenueInformation":
                    e.Cancel = !StepRevenueInformationPrevious();
                    break;

                case "Summary":
                    e.Cancel = !StepSummaryPrevious();
                    break;

                default:
                    throw new Exception("The option for " + wzProjectCostinsSheetsAdd.ActiveStep.Name + " step in project_combined_costing_sheets_add.Wizard_PreviousButtonClick function does not exist");
            }
            if (!e.Cancel)
            {
                ViewState["StepFrom"] = wzProjectCostinsSheetsAdd.ActiveStep.Name;
            }
        }



        protected void Wizard_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        {
            e.Cancel = !StepSummaryFinish();
        }



        protected void Wizard_CancelButtonClick(object sender, EventArgs e)
        {
            string script = "<script language='javascript'>";
            script += "{ window.close(); }";
            script += "</script>";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Cancel", script, false);
        }

        #endregion






        #region STEP1 - BEGIN

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP1 - BEGIN
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP1 - BEGIN - METHODS
        //

        private void StepBeginIn()
        {
            // Set instruction
            mWizard2 master = (mWizard2)this.Master;
            master.WizardInstruction = "What do you want to do?";

            // Prepare initial data
            // ... for template
            ProjectCostingSheetTemplateInformation projectCostingSheetTemplateInformation = new ProjectCostingSheetTemplateInformation(projectCostingSheetAddTDS);
            projectCostingSheetTemplateInformation.LoadAll(Convert.ToInt32(hdfCompanyId.Value));

            // Store datasets
            Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;
            templateInformation = projectCostingSheetAddTDS.TemplateInformation;
            Session["templateInformation"] = templateInformation;
        }



        private int StepBeginNext()
        {
            // Determine appropiate step
            if (rbtnBeginNew.Checked)
            {
                // Go to StepData
                hdfNewOrTemplate.Value = "New";
                return 2;
            }

            if (rbtnBeginTemplate.Checked)
            {
                // Go to StepTemplate
                hdfNewOrTemplate.Value = "Template";
                return 1;
            }

            return -1;
        }

        #endregion






        #region STEP2 - TEMPLATE

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP2 - TEMPLATE
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP2 - TEMPLATE -  EVENTS
        //

        protected void grdTemplate_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int costingSheetTemplateID = (int)e.Keys["CostingSheetTemplateID"];

            ProjectCostingSheetTemplateInformation model = new ProjectCostingSheetTemplateInformation(projectCostingSheetAddTDS);
            model.Delete(costingSheetTemplateID);

            // Store tables
            Session.Remove("templateInformationDummy");
            Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;

            templateInformation = projectCostingSheetAddTDS.TemplateInformation;
            Session["templateInformation"] = templateInformation;

        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP2 - TEMPLATE - AUXILIAR EVENTS
        //

        protected void grdTemplate_DataBound(object sender, EventArgs e)
        {
            AddCostingSheetTemplateNewEmptyFix(grdTemplate);
        }



        public void DummyCostingSheetTemplateNew(int CostingSheetTemplateID)
        {
        }



        public void DummyCostingSheetTemplateNew(int CostingSheetTemplateID, int original_CostingSheetTemplateID)
        {
        }






        // ////////////////////////////////////////////////////////////////////////
        //  STEP2 - TEMPLATE - PUBLIC METHODS
        //

        public ProjectCostingSheetAddTDS.TemplateInformationDataTable GetCostingSheetTemplate()
        {
            templateInformation = (ProjectCostingSheetAddTDS.TemplateInformationDataTable)Session["templateInformationDummy"];
            if (templateInformation == null)
            {
                templateInformation = ((ProjectCostingSheetAddTDS.TemplateInformationDataTable)Session["templateInformation"]);
            }

            return templateInformation;
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP2 - TEMPLATE - PRIVATE METHODS
        //

        private void StepTemplateIn()
        {
            // Set instruction
            mWizard2 master = (mWizard2)this.Master;
            master.WizardInstruction = "Please select a template and click next.";

            //// Initialize  variables
            lblMessage.Visible = false;
        }



        private bool StepTemplatePrevious()
        {
            return true;
        }



        private bool StepTemplateNext()
        {
            // Template election check
            if (grdTemplate.Rows.Count > 0)
            {
                // Save selected team project time for next step
                SaveSelectedId();

                int teamProjectTimeId = Int32.Parse(hdfSelectedIdTemplate.Value);
                if (teamProjectTimeId != 0)
                {
                    return true;
                }
                else
                {
                    lblMessage.Text = "At least one template must be selected";
                    lblMessage.Visible = true;
                    return false;
                }
            }
            else
            {
                lblMessage.Text = "Template unavailable";
                return false;
            }
        }



        protected void AddCostingSheetTemplateNewEmptyFix(GridView grdTemplate)
        {
            if (grdTemplate.Rows.Count == 0)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                ProjectCostingSheetAddTDS.TemplateInformationDataTable dt = new ProjectCostingSheetAddTDS.TemplateInformationDataTable();
                dt.AddTemplateInformationRow("", false, false, false, false, false, false, false, false, false, false, false, false, false, false, companyId, "", "", false, 0, 0, 0, 0, 0, 0, false);
                Session["templateInformationDummy"] = dt;

                grdTemplate.DataBind();
            }

            // normally executes at all postbacks
            if (grdTemplate.Rows.Count == 1)
            {
                ProjectCostingSheetAddTDS.TemplateInformationDataTable dt = (ProjectCostingSheetAddTDS.TemplateInformationDataTable)Session["templateInformationDummy"];
                if (dt != null)
                {
                    grdTemplate.Rows[0].Visible = false;
                    grdTemplate.Rows[0].Controls.Clear();
                }
            }
        }



        protected void SaveSelectedId()
        {
            int idForUpdate = 0;
            bool selected = false;
            hdfSelectedIdTemplate.Value = "0";

            ProjectCostingSheetTemplateInformation projectCostingSheetTemplateInformation = new ProjectCostingSheetTemplateInformation(projectCostingSheetAddTDS);

            foreach (GridViewRow row in grdTemplate.Rows)
            {
                // ... Update all rows
                selected = ((CheckBox)row.FindControl("cbxSelected")).Checked;
                idForUpdate = Int32.Parse(((Label)row.FindControl("lblCostingSheetTemplateID")).Text.Trim());
                projectCostingSheetTemplateInformation.Update(idForUpdate, selected);

                // ... Save selected project
                if (selected)
                {
                    hdfSelectedIdTemplate.Value = idForUpdate.ToString();
                }
            }

            projectCostingSheetTemplateInformation.Data.AcceptChanges();

            // Store datasets
            Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;
            templateInformation = projectCostingSheetAddTDS.TemplateInformation;
            Session["templateInformation"] = templateInformation;
        }



        #endregion







        #region STEP3 - GENERAL INFORMATION

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP3 - GENERAL INFORMATION
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP3 - GENERAL INFORMATION - AUXILIAR EVENTS
        //

        protected void cvWorks_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (cbxRehabAssessmentData.Checked || cbxFullLengthLiningData.Checked || cbxPointRepairData.Checked || cbxJunctionLiningData.Checked || cbxManholeRehabData.Checked || cbxMobilizationData.Checked || cbxOtherData.Checked)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }



        protected void cvCostingArea_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (cbxLabourHour.Checked || cbxMaterial.Checked || cbxTrucksEquipment.Checked || cbxOtherCost.Checked || cbxSubcontractor.Checked)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }



        protected void cvProjects_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = false;
            projectsSelected.Clear();

            foreach (TreeNode nodes in tvProjectsRoot.Nodes)
            {
                GetProjectsSelected(nodes);
            }

            if (tvProjectsRoot.Nodes.Count > 0)
            {
                if (projectsSelected.Count > 0)
                {
                    args.IsValid = true;
                }
            }
            else
            {
                args.IsValid = true;
            }

            Session["projectsSelected"] = projectsSelected;
        }



        private void GetProjectsSelected(TreeNode node)
        {
            if (node.ChildNodes.Count == 0)
            {
                if (node.Checked)
                {
                    int projectId = int.Parse(node.Value);

                    projectsSelected.Add(projectId);
                    ProjectGateway projectGateway = new ProjectGateway();
                    projectGateway.LoadByProjectId(projectId);
                    string name = projectGateway.GetName(projectId);

                    projectList.Add(new ListItem(name, projectId.ToString()));
                }
            }
            else
            {
                if (node.Checked)
                {
                    projectsSelected.Add(int.Parse(node.Value));
                }

                foreach (TreeNode node2 in node.ChildNodes)
                {
                    GetProjectsSelected(node2);
                }
            }
        }



        protected void cvStartDateEndDate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;
        }



        protected void cvEnd_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (cbxEndConfirm.Checked || cbxEndSave.Checked)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }



        protected void cvEndSaveNew_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (cbxEndSave.Checked && rbtnEndSaveNew.Checked && (tbxEndSaveNew.Text.Trim() == ""))
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }



        protected void cvEndSaveNewExist_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (cbxEndSave.Checked && rbtnEndSaveNew.Checked && (tbxEndSaveNew.Text.Trim() != ""))
            {
                //TeamProjectTime2Gateway teamProjectTime2Gateway = new TeamProjectTime2Gateway(new DataSet());
                //if (teamProjectTime2Gateway.IsTemplateNameInUseByTemplateNameLoginId(args.Value, Convert.ToInt32(Session["loginID"])))
                //{
                //    args.IsValid = false;
                //}
                //else
                //{
                args.IsValid = true;
                //}
            }
        }



        protected void cvEndSaveTemplate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (cbxEndSave.Checked && rbtnEndSaveReplace.Checked && (luEndSaveTemplate.SelectedValue.ToString() == "0"))
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }



        private bool ValidateStepEnd()
        {
            cvEnd.Validate();
            cvEndSaveNew.Validate();
            //cvEndSaveNewExist.Validate();
            cvEndSaveTemplate.Validate();

            if (cvEnd.IsValid && cvEndSaveNew.IsValid && cvEndSaveTemplate.IsValid)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        // ////////////////////////////////////////////////////////////////////////
        // STEP1 - GENERAL INFORMATION - METHODS
        //

        private void StepGeneralInformationIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Please provide general information";

            if (rbtnBeginTemplate.Checked)
            {
                int costingSheetTemplateId = Int32.Parse(hdfSelectedIdTemplate.Value);

                if (costingSheetTemplateId != 0)
                {
                    // Prepare initial data
                    // ... for template
                    foreach (ProjectCostingSheetAddTDS.TemplateInformationRow row in (ProjectCostingSheetAddTDS.TemplateInformationDataTable)Session["templateInformation"])
                    {
                        if (row.CostingSheetTemplateID == costingSheetTemplateId)
                        {
                            tbxName.Text = row.Name;

                            cbxRehabAssessmentData.Checked = row.RAData;
                            cbxFullLengthLiningData.Checked = row.FLLData;
                            cbxPointRepairData.Checked = row.PRData; ;
                            cbxJunctionLiningData.Checked = row.JLData;
                            cbxManholeRehabData.Checked = row.MRData;
                            cbxMobilizationData.Checked = row.MOBData;
                            cbxOtherData.Checked = row.OtherData;

                            cbxLabourHour.Checked = row.LabourHourData;
                            cbxTrucksEquipment.Checked = row.UnitData;
                            cbxMaterial.Checked = row.MaterialData;
                            cbxSubcontractor.Checked = row.SubcontractorData;
                            cbxOtherCost.Checked = row.MiscData;

                            cbxRevenueInformation.Checked = row.RevenueIncluded;

                            luEndSaveTemplate.SelectedValue = row.CostingSheetTemplateID.ToString();

                            try
                            {
                                DateTime startDate = new DateTime(row.Year, row.Month, row.Day);
                                tkrdpFrom.SelectedDate = startDate;
                            }
                            catch { }

                            try
                            {
                                DateTime endDate = new DateTime(row.Year2, row.Month2, row.Day2);
                                tkrdpTo.SelectedDate = endDate;
                            }
                            catch { }
                        }
                    }
                }

                

                //foreach (ProjectTDS.LFS_PROJECTRow row in (ProjectTDS.LFS_PROJECTDataTable)project.Table)
                //{
                //    // step 1
                //    thisId = Convert.ToInt32(row[0].ToString());

                //    // step 2
                //    thisName = Convert.ToString(row[8].ToString());

                //    // step 3
                //    TreeNode newNode = new TreeNode(thisName, thisId.ToString());
                //    newNode.ShowCheckBox = true;
                //    newNode.SelectAction = TreeNodeSelectAction.None;

                //    // step 4
                //    nodes.Add(newNode);
                //    newNode.ToggleExpandState();
                //}
            }

            Int32 thisId;
            String thisName;
            TreeNodeCollection nodes;

            CompaniesGateway companies = new CompaniesGateway();
            companies.LoadByCompaniesId(int.Parse(hdfClientId.Value), int.Parse(hdfCompanyId.Value));
            string nameCompany = companies.GetName(int.Parse(hdfClientId.Value));

            ProjectGateway project = new ProjectGateway();
            project.LoadByClientId(int.Parse(hdfClientId.Value));

            TreeNode tnParent = new TreeNode();
            tnParent.Text = nameCompany;
            tnParent.Value = "0";
            tnParent.ShowCheckBox = true;
            tnParent.SelectAction = TreeNodeSelectAction.None;

            tvProjectsRoot.Nodes.Add(tnParent);
            tnParent.ToggleExpandState();

            PopulateNodes(project.Table, tnParent.ChildNodes);
        }



        private void PopulateNodes(DataTable dt, TreeNodeCollection nodes)
        {
            foreach (DataRow dr in dt.Rows)
            {                
                TreeNode tn = new TreeNode();
                tn.Text = dr[8].ToString();
                tn.Value = dr[0].ToString();
                tn.ShowCheckBox = true;
                tn.SelectAction = TreeNodeSelectAction.None;
                if (projectsSelected.Contains(int.Parse(dr[0].ToString())))
                {
                    tn.Checked = true;
                }

                nodes.Add(tn);
            }
        }



        private bool StepGeneralInformationNext()
        {
            if (cbxEndConfirm.Checked)
            {
                Page.Validate("StepGeneralInformation");
            }
            else
            {
                ValidateStepEnd();

                PostPageChanges2();
            }

            return (Page.IsValid) ? true : false;
        }



        private bool StepGeneralInformationPrevious()
        {
            return true;
        }

        #endregion






        #region STEP4 - LABOUR HOUR INFORMATION

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP4 - LABOUR HOUR INFORMATION
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP4 - LABOUR HOUR INFORMATION - EVENTS
        //

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
                    int projectId = 0;

                    foreach (int projectIdSelected in projectsSelected)
                    {
                        projectId = projectIdSelected;
                    }

                    ProjectGateway projectGateway = new ProjectGateway();

                    // Validate general data
                    Page.Validate("labourHoursNew");

                    if (Page.IsValid)
                    {
                        projectGateway.LoadByProjectId(projectId);

                        // Validate costs
                        if (projectGateway.GetCountryID(projectId) == 1) //Canada
                        {
                            Page.Validate("labourHoursCadNew");
                        }
                        else
                        {
                            Page.Validate("labourHoursUsdNew");
                        }
                    }

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

                        decimal lhCostCad = 0.0M;
                        decimal totalCostCad = 0.0M;
                        decimal? mealsCostCad = null;
                        decimal? motelCostCad = null;
                        decimal lhCostUsd = 0.0M;
                        decimal totalCostUsd = 0.0M;
                        decimal? mealsCostUsd = null;
                        decimal? motelCostUsd = null;

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

                        string workFunctionConcat = "";
                        string function_ = "";
                        workFunctionConcat = ((DropDownList)grdTeamMembers.FooterRow.FindControl("ddlWorkFunctionNew")).SelectedValue;
                        if (workFunctionConcat != "(Select)")
                        {
                            string[] workFunction = workFunctionConcat.ToString().Trim().Split('.');
                            function_ = workFunction[1].Trim();
                        }

                        ProjectCombinedCostingSheetAddLabourHoursInformation model = new ProjectCombinedCostingSheetAddLabourHoursInformation(projectCostingSheetAddTDS);
                        model.Insert(0, typeOfWork, employeeId, lHQuantity, unitOfMeasurementLH, unitOfMeasurementMeals, mealsQuantity, unitOfMeasurementMotel, motelQuantity, lhCostCad, mealsCostCad, motelCostCad, totalCostCad, lhCostUsd, mealsCostUsd, motelCostUsd, totalCostUsd, false, companyId, name, startDate, endDate, workFunctionConcat, function_, Int32.Parse(hdfClientId.Value), 1);

                        Session.Remove("labourHoursInformationDummy");
                        labourHoursInformation = (ProjectCostingSheetAddTDS.CombinedLabourHoursInformationDataTable)model.Table;
                        Session["labourHoursInformation"] = labourHoursInformation;
                        Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;

                        grdTeamMembers.DataBind();
                        StepLabourHoursInformationProcessGrid();
                    }
                    break;
            }
        }



        protected void grdTeamMembers_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int projectId = 0;

            foreach (int projectIdSelected in projectsSelected)
            {
                projectId = projectIdSelected;
            }

            ProjectGateway projectGateway = new ProjectGateway();

            // Validate general data
            Page.Validate("labourHoursEdit");

            if (Page.IsValid)
            {
                projectGateway.LoadByProjectId(projectId);

                // Validate costs
                if (projectGateway.GetCountryID(projectId) == 1) //Canada
                {
                    Page.Validate("labourHoursCadEdit");
                }
                else
                {
                    Page.Validate("labourHoursUsdEdit");
                }
            }

            if (Page.IsValid)
            {
                int costingSheetId = (int)e.Keys["CostingSheetID"];
                string work_ = (string)e.Keys["Work_"];
                int employeeId = (int)e.Keys["EmployeeID"];
                int refId = (int)e.Keys["RefID"];
                int companyId = Int32.Parse(hdfCompanyId.Value);

                string name = ((TextBox)grdTeamMembers.Rows[e.RowIndex].Cells[0].FindControl("tbxTeamMemberEdit")).Text;
                string unitOfMeasurementLH = ((DropDownList)grdTeamMembers.Rows[e.RowIndex].Cells[0].FindControl("ddlUnitOfMeasurementLHEdit")).SelectedValue;
                double lHQuantity = double.Parse(((TextBox)grdTeamMembers.Rows[e.RowIndex].Cells[0].FindControl("tbxLHQtyEdit")).Text.Trim());
                string unitOfMeasurementMeals = ((DropDownList)grdTeamMembers.Rows[e.RowIndex].Cells[0].FindControl("ddlUnitsOfMeasurementLHMealsEdit")).SelectedValue;
                int? mealsQuantity = null; if (((TextBox)grdTeamMembers.Rows[e.RowIndex].Cells[0].FindControl("tbxMealsQtyEdit")).Text.Trim() != "") mealsQuantity = Int32.Parse(((TextBox)grdTeamMembers.Rows[e.RowIndex].Cells[0].FindControl("tbxMealsQtyEdit")).Text.Trim());
                string unitOfMeasurementMotel = ((DropDownList)grdTeamMembers.Rows[e.RowIndex].Cells[0].FindControl("ddlUnitsOfMeasurementLHMotelEdit")).SelectedValue;
                int? motelQuantity = null; if (((TextBox)grdTeamMembers.Rows[e.RowIndex].Cells[0].FindControl("tbxMotelQtyEdit")).Text.Trim() != "") motelQuantity = Int32.Parse(((TextBox)grdTeamMembers.Rows[e.RowIndex].Cells[0].FindControl("tbxMotelQtyEdit")).Text.Trim());

                decimal lhCostCad = 0.0M;
                decimal totalCostCad = 0.0M;
                decimal? mealsCostCad = null;
                decimal? motelCostCad = null;
                decimal lhCostUsd = 0.0M;
                decimal totalCostUsd = 0.0M;
                decimal? mealsCostUsd = null;
                decimal? motelCostUsd = null;

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

                string workFunctionConcat = "";
                string function_ = "";
                workFunctionConcat = ((DropDownList)grdTeamMembers.Rows[e.RowIndex].Cells[0].FindControl("ddlWorkFunctionEdit")).SelectedValue;
                if (workFunctionConcat != "(Select)")
                {
                    string[] workFunction = workFunctionConcat.ToString().Trim().Split('.');
                    function_ = workFunction[1].Trim();
                }

                // Update data
                ProjectCombinedCostingSheetAddLabourHoursInformation model = new ProjectCombinedCostingSheetAddLabourHoursInformation(projectCostingSheetAddTDS);
                model.Update(costingSheetId, work_, employeeId, refId, lHQuantity, unitOfMeasurementLH, unitOfMeasurementMeals, mealsQuantity, unitOfMeasurementMotel, motelQuantity, lhCostCad, mealsCostCad, motelCostCad, totalCostCad, lhCostUsd, mealsCostUsd, motelCostUsd, totalCostUsd, false, companyId, name, startDate, endDate, workFunctionConcat, function_);

                // Store dataset
                labourHoursInformation = (ProjectCostingSheetAddTDS.CombinedLabourHoursInformationDataTable)model.Table;
                Session["labourHoursInformation"] = labourHoursInformation;
                Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;

                StepLabourHoursInformationProcessGrid();
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

            ProjectCombinedCostingSheetAddLabourHoursInformation model = new ProjectCombinedCostingSheetAddLabourHoursInformation(projectCostingSheetAddTDS);

            // Delete Team Member Cost
            model.Delete(costingSheetId, work_, employeeId, refId);

            // Store dataset            
            labourHoursInformation = (ProjectCostingSheetAddTDS.CombinedLabourHoursInformationDataTable)model.Table;
            Session["labourHoursInformation"] = labourHoursInformation;
            Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;

            StepLabourHoursInformationProcessGrid();
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP4 - LABOUR HOUR INFORMATION - AUXILIAR EVENTS
        //

        protected void grdTeamMembers_DataBound(object sender, EventArgs e)
        {
            LabourHoursInformationEmptyFix(grdTeamMembers);
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

                ProjectCombinedCostingSheetAddLabourHoursInformationGateway projectCostingSheetAddLabourHoursInformationGateway = new ProjectCombinedCostingSheetAddLabourHoursInformationGateway(projectCostingSheetAddTDS);
                string unitOfMeasurement = projectCostingSheetAddLabourHoursInformationGateway.GetLHUnitOfMeasurement(costingSheetId, work_, employeeId, refId);
                ((DropDownList)e.Row.FindControl("ddlUnitOfMeasurementLHEdit")).SelectedValue = unitOfMeasurement;

                string unitOfMeasurementMeals = projectCostingSheetAddLabourHoursInformationGateway.GetMealsUnitOfMeasurement(costingSheetId, work_, employeeId, refId);
                ((DropDownList)e.Row.FindControl("ddlUnitsOfMeasurementLHMealsEdit")).SelectedValue = unitOfMeasurementMeals;

                string unitOfMeasurementMotel = projectCostingSheetAddLabourHoursInformationGateway.GetMotelUnitOfMeasurement(costingSheetId, work_, employeeId, refId);
                ((DropDownList)e.Row.FindControl("ddlUnitsOfMeasurementLHMotelEdit")).SelectedValue = unitOfMeasurementMotel;

                bool fromDatabase = projectCostingSheetAddLabourHoursInformationGateway.GetFromDatabase(costingSheetId, work_, employeeId, refId);

                if (fromDatabase)
                {
                    ((RadDatePicker)e.Row.FindControl("tkrdpEndDateEdit")).Calendar.Enabled = false;
                    ((RadDatePicker)e.Row.FindControl("tkrdpEndDateEdit")).DateInput.ReadOnly = true;

                    ((RadDatePicker)e.Row.FindControl("tkrdpStartDateEdit")).Calendar.Enabled = false;
                    ((RadDatePicker)e.Row.FindControl("tkrdpStartDateEdit")).DateInput.ReadOnly = true;
                }

                ((RadDatePicker)e.Row.FindControl("hdfFrom")).SelectedDate = tkrdpFrom.SelectedDate;
                ((RadDatePicker)e.Row.FindControl("hdfTo")).SelectedDate = tkrdpTo.SelectedDate;
            }

            // Footer Item
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                ((RadDatePicker)e.Row.FindControl("hdfFrom")).SelectedDate = tkrdpFrom.SelectedDate;
                ((RadDatePicker)e.Row.FindControl("hdfTo")).SelectedDate = tkrdpTo.SelectedDate;

                DropDownList ddlProject = ((DropDownList)e.Row.FindControl("ddlProject_New"));                              
                ddlProject.DataTextField = "Text";
                ddlProject.DataValueField = "Value";
                ddlProject.DataSource = projectList;
                ddlProject.DataBind();
                ddlProject.SelectedIndex = 0;
            }
        }



        protected void grdTeamMembers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            StepLabourHoursInformationProcessGrid();
        }



        protected void grdTeamMembers_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Team member Gridview, if the gridview is edition mode
            if (grdTeamMembers.EditIndex >= 0)
            {
                grdTeamMembers.UpdateRow(grdTeamMembers.EditIndex, true);
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP4 - LABOUR HOUR INFORMATION - METHODS
        //

        private void StepLabourHourInformationIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Please verify Labour Hour information";

            int projectId = 0;

            // Load
            ProjectCombinedCostingSheetAddLabourHoursInformationGateway projectCombinedCostingSheetAddLabourHoursInformationGateway = new ProjectCombinedCostingSheetAddLabourHoursInformationGateway(projectCostingSheetAddTDS);

            projectCombinedCostingSheetAddLabourHoursInformationGateway.ClearBeforeFill = false;
            ProjectCombinedCostingSheetAddLabourHoursInformation model = new ProjectCombinedCostingSheetAddLabourHoursInformation(projectCombinedCostingSheetAddLabourHoursInformationGateway.Data);

            if (projectCostingSheetAddTDS.CombinedLabourHoursInformation.Rows.Count == 0)
            {
                foreach (int projectIdSelected in projectsSelected)
                {
                    projectId = projectIdSelected;

                    ProjectGateway projectGateway = new ProjectGateway();
                    projectGateway.LoadByProjectId(projectId);

                    ArrayList works = new ArrayList();
                    if (cbxRehabAssessmentData.Checked) works.Add("Rehab Assessment");
                    if (cbxFullLengthLiningData.Checked) works.Add("Full Length");
                    if (cbxPointRepairData.Checked) { works.Add("Point Lining"); works.Add("Grouting"); }
                    if (cbxJunctionLiningData.Checked) works.Add("Junction Lining");
                    if (cbxManholeRehabData.Checked) works.Add("MH Rehab");
                    if (cbxMobilizationData.Checked) works.Add("Mobilization");
                    if (cbxOtherData.Checked)
                    {
                        works.Add("Other");
                        works.Add("Downtime");
                        works.Add("Office");
                        works.Add("Office / Shop");
                        works.Add("R & D");
                        works.Add("Special Projects");
                        works.Add("Subcontractor");
                        works.Add("Watermain Relining");
                        works.Add("SOTA");
                    }

                    if (!projectGateway.GetFairWageApplies(projectId))
                    {
                        model.Load(works, projectId, tkrdpFrom.SelectedDate.Value, tkrdpTo.SelectedDate.Value, int.Parse(hdfCompanyId.Value), Int32.Parse(hdfClientId.Value));
                    }
                    else
                    {
                        ArrayList jobClassType = new ArrayList();
                        jobClassType.Add("Laborer Group 2");
                        jobClassType.Add("Laborer Group 6");
                        jobClassType.Add("Operator Group 1");
                        jobClassType.Add("Operator Group 2");
                        jobClassType.Add("Regular Rate");

                        model.LoadFairWageProject(works, jobClassType, projectId, tkrdpFrom.SelectedDate.Value, tkrdpTo.SelectedDate.Value, int.Parse(hdfCompanyId.Value), Int32.Parse(hdfClientId.Value));
                    }

                    projectCombinedCostingSheetAddLabourHoursInformationGateway.ClearBeforeFill = true;

                    // Store tables
                    Session.Remove("labourHoursInformationDummy");
                    labourHoursInformation = (ProjectCostingSheetAddTDS.CombinedLabourHoursInformationDataTable)model.Table;
                    Session["labourHoursInformation"] = labourHoursInformation;
                    Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;

                    grdTeamMembers.Columns[11].Visible = false;
                    grdTeamMembers.Columns[12].Visible = false;
                    grdTeamMembers.Columns[13].Visible = false;
                    grdTeamMembers.Columns[14].Visible = false;
                    grdTeamMembers.Columns[16].Visible = false;
                    grdTeamMembers.Columns[17].Visible = false;
                    grdTeamMembers.Columns[20].Visible = false;
                    grdTeamMembers.Columns[21].Visible = false;

                    // Validate grid columns
                    if (projectGateway.GetCountryID(projectId) == 1) //Canada
                    {
                        // Team Members Grid
                        grdTeamMembers.Columns[15].Visible = true;
                        grdTeamMembers.Columns[18].Visible = true;
                        grdTeamMembers.Columns[19].Visible = false;
                        grdTeamMembers.Columns[22].Visible = false;

                        // Totals
                        lblTeamMembersTotalCost.Text = "Total Cost (CAD) : ";
                        tbxTeamMembersTotalCostCAD.Visible = true;
                        tbxTeamMembersTotalCostUSD.Visible = false;
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

                            // Totals
                            lblTeamMembersTotalCost.Text = "Total Cost (USD) : ";
                            tbxTeamMembersTotalCostCAD.Visible = false;
                            tbxTeamMembersTotalCostUSD.Visible = true;
                        }
                    }
                }
            }

            grdTeamMembers.DataBind();
            StepLabourHoursInformationProcessGrid();
        }



        private bool StepLabourHourInformationNext()
        {
            StepLabourHoursInformationProcessGrid();

            // Store tables
            Session.Remove("labourHoursInformationDummy");
            Session["labourHoursInformation"] = labourHoursInformation;
            Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;

            return true;
        }



        private bool StepLabourHourInformationPrevious()
        {
            return true;
        }



        private void StepLabourHoursInformationProcessGrid()
        {
            decimal totalCostCadLH = 0;
            decimal totalCostUsdLH = 0;

            foreach (ProjectCostingSheetAddTDS.CombinedLabourHoursInformationRow row in (ProjectCostingSheetAddTDS.CombinedLabourHoursInformationDataTable)Session["labourHoursInformation"])
            {
                if (!row.Deleted)
                {
                    totalCostCadLH = totalCostCadLH + row.TotalCostCad;
                    totalCostUsdLH = totalCostUsdLH + row.TotalCostUsd;
                }
            }

            tbxTeamMembersTotalCostCAD.Text = Decimal.Round(totalCostCadLH, 2).ToString();
            tbxTeamMembersTotalCostUSD.Text = Decimal.Round(totalCostUsdLH, 2).ToString();
        }



        public ProjectCostingSheetAddTDS.CombinedLabourHoursInformationDataTable GetLabourHoursInformation()
        {
            labourHoursInformation = (ProjectCostingSheetAddTDS.CombinedLabourHoursInformationDataTable)Session["labourHoursInformationDummy"];

            if (labourHoursInformation == null)
            {
                labourHoursInformation = (ProjectCostingSheetAddTDS.CombinedLabourHoursInformationDataTable)Session["labourHoursInformation"];
            }

            return labourHoursInformation;
        }



        protected void LabourHoursInformationEmptyFix(GridView grdView)
        {
            if (grdView.Rows.Count == 0)
            {
                ProjectCostingSheetAddTDS.CombinedLabourHoursInformationDataTable dt = new ProjectCostingSheetAddTDS.CombinedLabourHoursInformationDataTable();
                dt.AddCombinedLabourHoursInformationRow(0, "", 0, 0, 0, "", "", 0, "", 0, 0, 0, 0, 0, 0, 0, 0, 0, false, 3, false, "", DateTime.Now, DateTime.Now, false, "", "", 0, 0, "");
                Session["labourHoursInformationDummy"] = dt;

                grdView.DataBind();
            }

            // Normally executes at all postbacks
            if (grdView.Rows.Count == 1)
            {
                ProjectCostingSheetAddTDS.CombinedLabourHoursInformationDataTable dt = (ProjectCostingSheetAddTDS.CombinedLabourHoursInformationDataTable)Session["labourHoursInformationDummy"];
                if (dt != null)
                {
                    // Hide row
                    grdView.Rows[0].Visible = false;
                    grdView.Rows[0].Controls.Clear();
                }
            }
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

        #endregion






        #region STEP5 - TRUCKS EQUIPMENT INFORMATION

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP5 - TRUCKS EQUIPMENT INFORMATION
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP5 - TRUCKS EQUIPMENT INFORMATION - EVENTS
        //

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
                    Page.Validate("unitsNew");

                    int projectId = 0;

                    foreach (int projectIdSelected in projectsSelected)
                    {
                        projectId = projectIdSelected;
                    }

                    ProjectGateway projectGateway = new ProjectGateway();

                    if (Page.IsValid)
                    {
                        // Validate costs                        
                        projectGateway.LoadByProjectId(projectId);

                        if (projectGateway.GetCountryID(projectId) == 1) //Canada
                        {
                            Page.Validate("unitsCadNew");
                        }
                        else
                        {
                            Page.Validate("unitsUsdNew");
                        }
                    }

                    if (Page.IsValid)
                    {
                        int companyId = Int32.Parse(hdfCompanyId.Value);
                        string typeOfWork = ((DropDownList)grdUnits.FooterRow.FindControl("ddlTypeOfWork_New")).SelectedValue;
                        int unitId = Int32.Parse(((DropDownList)grdUnits.FooterRow.FindControl("ddlUnitCodeNew")).SelectedValue);
                        string unitCode = ((DropDownList)grdUnits.FooterRow.FindControl("ddlUnitCodeNew")).SelectedItem.Text;
                        string unitOfMeasurement = ((DropDownList)grdUnits.FooterRow.FindControl("ddlUnitOfMeasurementUnitsNew")).SelectedValue;
                        double quantity = double.Parse(((TextBox)grdUnits.FooterRow.FindControl("tbxQuantityNew")).Text.Trim());

                        decimal costCad = 0.0M;
                        decimal totalCostCad = 0.0M;
                        decimal costUsd = 0.0M;
                        decimal totalCostUsd = 0.0M;

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

                        string workFunctionConcat = "";
                        string function_ = "";
                        workFunctionConcat = ((DropDownList)grdUnits.FooterRow.FindControl("ddlWorkFunctionNew")).SelectedValue;
                        if (workFunctionConcat != "(Select)")
                        {
                            string[] workFunction = workFunctionConcat.ToString().Trim().Split('.');
                            function_ = workFunction[1].Trim();
                        }

                        ProjectCombinedCostingSheetAddUnitsInformation model = new ProjectCombinedCostingSheetAddUnitsInformation(projectCostingSheetAddTDS);
                        model.Insert(0, typeOfWork, unitId, unitOfMeasurement, quantity, costCad, totalCostCad, costUsd, totalCostUsd, false, companyId, unitCode, unitDescription, startDate, endDate, workFunctionConcat, function_, 1);

                        Session.Remove("unitsInformationDummy");
                        unitsInformation = (ProjectCostingSheetAddTDS.CombinedUnitsInformationDataTable)model.Table;
                        Session["unitsInformation"] = unitsInformation;
                        Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;

                        grdUnits.DataBind();

                        StepTrucksEquipmentInformationProcessGrid();
                    }
                    break;
            }
        }



        protected void grdUnits_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Validate general data
            Page.Validate("unitsEdit");

            int projectId = 0;

            foreach (int projectIdSelected in projectsSelected)
            {
                projectId = projectIdSelected;
            }

            ProjectGateway projectGateway = new ProjectGateway();

            if (Page.IsValid)
            {
                // Validate costs               
                projectGateway.LoadByProjectId(projectId);

                if (projectGateway.GetCountryID(projectId) == 1) //Canada
                {
                    Page.Validate("unitsCadEdit");
                }
                else
                {
                    Page.Validate("unitsUsdEdit");
                }
            }

            if (Page.IsValid)
            {
                int costingSheetId = (int)e.Keys["CostingSheetID"];
                string work_ = (string)e.Keys["Work_"];
                int unitId = (int)e.Keys["UnitID"];
                int refId = (int)e.Keys["RefID"];

                int companyId = Int32.Parse(hdfCompanyId.Value);
                string unitOfMeasurement = ((DropDownList)grdUnits.Rows[e.RowIndex].Cells[0].FindControl("ddlUnitOfMeasurementUnitsEdit")).SelectedValue;
                double quantity = double.Parse(((TextBox)grdUnits.Rows[e.RowIndex].Cells[0].FindControl("tbxQuantityEdit")).Text.Trim());

                decimal costCad = 0.0M;
                decimal totalCostCad = 0.0M;
                decimal costUsd = 0.0M;
                decimal totalCostUsd = 0.0M;

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

                string workFunctionConcat = "";
                string function_ = "";
                workFunctionConcat = ((DropDownList)grdUnits.Rows[e.RowIndex].Cells[0].FindControl("ddlWorkFunctionEdit")).SelectedValue;
                if (workFunctionConcat != "(Select)")
                {
                    string[] workFunction = workFunctionConcat.ToString().Trim().Split('.');
                    function_ = workFunction[1].Trim();
                }

                // Update data
                ProjectCombinedCostingSheetAddUnitsInformation model = new ProjectCombinedCostingSheetAddUnitsInformation(projectCostingSheetAddTDS);
                model.Update(costingSheetId, work_, unitId, refId, unitOfMeasurement, quantity, costCad, totalCostCad, costUsd, totalCostUsd, false, companyId, unitCode, unitDescription, startDate, endDate, workFunctionConcat, function_);

                // Store dataset
                unitsInformation = (ProjectCostingSheetAddTDS.CombinedUnitsInformationDataTable)model.Table;
                Session["unitsInformation"] = unitsInformation;
                Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;

                StepTrucksEquipmentInformationProcessGrid();
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

            // Delete Unit Cost
            int costingSheetId = (int)e.Keys["CostingSheetID"];
            string work_ = (string)e.Keys["Work_"];
            int unitId = (int)e.Keys["UnitID"];
            int refId = (int)e.Keys["RefID"];

            ProjectCombinedCostingSheetAddUnitsInformation model = new ProjectCombinedCostingSheetAddUnitsInformation(projectCostingSheetAddTDS);
            model.Delete(costingSheetId, work_, unitId, refId);

            // Store dataset
            unitsInformation = (ProjectCostingSheetAddTDS.CombinedUnitsInformationDataTable)model.Table;
            Session["unitsInformation"] = unitsInformation;
            Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;

            StepTrucksEquipmentInformationProcessGrid();
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP5 - TRUCKS EQUIPMENT INFORMATION - AUXILIAR EVENTS
        //

        protected void grdUnits_DataBound(object sender, EventArgs e)
        {
            UnitsInformationEmptyFix(grdUnits);
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

                ProjectCombinedCostingSheetAddUnitsInformationGateway projectCostingSheetAddUnitsInformationGateway = new ProjectCombinedCostingSheetAddUnitsInformationGateway(projectCostingSheetAddTDS);
                string unitOfMeasurement = projectCostingSheetAddUnitsInformationGateway.GetUnitOfMeasurement(costingSheetId, work_, unitId, refId);
                ((DropDownList)e.Row.FindControl("ddlUnitOfMeasurementUnitsEdit")).SelectedValue = unitOfMeasurement;

                bool fromDatabase = projectCostingSheetAddUnitsInformationGateway.GetFromDatabase(costingSheetId, work_, unitId, refId);

                if (fromDatabase)
                {
                    ((RadDatePicker)e.Row.FindControl("tkrdpEndDateEdit")).Calendar.Enabled = false;
                    ((RadDatePicker)e.Row.FindControl("tkrdpEndDateEdit")).DateInput.ReadOnly = true;

                    ((RadDatePicker)e.Row.FindControl("tkrdpStartDateEdit")).Calendar.Enabled = false;
                    ((RadDatePicker)e.Row.FindControl("tkrdpStartDateEdit")).DateInput.ReadOnly = true;
                }

                ((RadDatePicker)e.Row.FindControl("hdfFrom")).SelectedDate = tkrdpFrom.SelectedDate;
                ((RadDatePicker)e.Row.FindControl("hdfTo")).SelectedDate = tkrdpTo.SelectedDate;
            }

            // Footer Item
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                ((RadDatePicker)e.Row.FindControl("hdfFrom")).SelectedDate = tkrdpFrom.SelectedDate;
                ((RadDatePicker)e.Row.FindControl("hdfTo")).SelectedDate = tkrdpTo.SelectedDate;

                DropDownList ddlProject = ((DropDownList)e.Row.FindControl("ddlProject_New"));
                ddlProject.DataTextField = "Text";
                ddlProject.DataValueField = "Value";
                ddlProject.DataSource = projectList;
                ddlProject.DataBind();
                ddlProject.SelectedIndex = 0;
            }
        }



        protected void grdUnits_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            StepTrucksEquipmentInformationProcessGrid();
        }



        protected void grdUnits_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Units Gridview, if the gridview is edition mode
            if (grdUnits.EditIndex >= 0)
            {
                grdUnits.UpdateRow(grdUnits.EditIndex, true);
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP5 - TRUCKS EQUIPMENT INFORMATION - METHODS
        //

        private void StepTrucksEquipmentInformationIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Please verify Truck / Equipment information";

            int projectId = 0;

            foreach (int projectIdSelected in projectsSelected)
            {
                projectId = projectIdSelected;
            }

            // Load
            ProjectCombinedCostingSheetAddUnitsInformation model = new ProjectCombinedCostingSheetAddUnitsInformation(projectCostingSheetAddTDS);

            if (projectCostingSheetAddTDS.CombinedUnitsInformation.Rows.Count <= 0)
            {
                ArrayList works = new ArrayList();
                if (cbxRehabAssessmentData.Checked) works.Add("Rehab Assessment");
                if (cbxFullLengthLiningData.Checked) works.Add("Full Length");
                if (cbxPointRepairData.Checked) { works.Add("Point Lining"); works.Add("Grouting"); }
                if (cbxJunctionLiningData.Checked) works.Add("Junction Lining");
                if (cbxManholeRehabData.Checked) works.Add("MH Rehab");
                if (cbxMobilizationData.Checked) works.Add("Mobilization");
                if (cbxOtherData.Checked)
                {
                    works.Add("Other");
                    works.Add("Downtime");
                    works.Add("Office");
                    works.Add("Office / Shop");
                    works.Add("R & D");
                    works.Add("Special Projects");
                    works.Add("Subcontractor");
                    works.Add("Watermain Relining");
                    works.Add("SOTA");
                }

                model.Load(works, projectsSelected, tkrdpFrom.SelectedDate.Value, tkrdpTo.SelectedDate.Value, int.Parse(hdfCompanyId.Value), Int32.Parse(hdfClientId.Value));
            }

            // Store tables
            Session.Remove("unitsInformationDummy");
            unitsInformation = (ProjectCostingSheetAddTDS.CombinedUnitsInformationDataTable)model.Table;
            Session["unitsInformation"] = unitsInformation;
            Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;

            // Validate grid columns
            ProjectGateway projectGateway = new ProjectGateway();
            projectGateway.LoadByProjectId(projectId);

            if (projectGateway.GetCountryID(projectId) == 1) //Canada
            {
                // Units Grid
                grdUnits.Columns[12].Visible = true;
                grdUnits.Columns[13].Visible = true;
                grdUnits.Columns[14].Visible = false;
                grdUnits.Columns[15].Visible = false;

                lblUnitsTotalCosts.Text = "Total Cost (CAD) : ";
                tbxUnitsTotalCostsCAD.Visible = true;
                tbxUnitsTotalCostsUSD.Visible = false;
            }
            else
            {
                // Units Grid
                grdUnits.Columns[12].Visible = false;
                grdUnits.Columns[13].Visible = false;
                grdUnits.Columns[14].Visible = true;
                grdUnits.Columns[15].Visible = true;

                lblUnitsTotalCosts.Text = "Total Cost (USD) : ";
                tbxUnitsTotalCostsCAD.Visible = false;
                tbxUnitsTotalCostsUSD.Visible = true;
            }

            grdUnits.DataBind();
            StepTrucksEquipmentInformationProcessGrid();
        }



        private bool StepTrucksEquipmentInformationNext()
        {
            StepTrucksEquipmentInformationProcessGrid();

            // Store tables
            Session.Remove("unitsInformationDummy");
            Session["unitsInformation"] = unitsInformation;
            Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;
            return true;
        }



        private bool StepTrucksEquipmentInformationPrevious()
        {
            return true;
        }



        private void StepTrucksEquipmentInformationProcessGrid()
        {
            decimal totalCostCadLH = 0;
            decimal totalCostUsdLH = 0;

            foreach (ProjectCostingSheetAddTDS.CombinedUnitsInformationRow row in (ProjectCostingSheetAddTDS.CombinedUnitsInformationDataTable)Session["unitsInformation"])
            {
                if (!row.Deleted)
                {
                    totalCostCadLH = totalCostCadLH + row.TotalCostCad;
                    totalCostUsdLH = totalCostUsdLH + row.TotalCostUsd;
                }
            }

            tbxUnitsTotalCostsCAD.Text = Decimal.Round(totalCostCadLH, 2).ToString();
            tbxUnitsTotalCostsUSD.Text = Decimal.Round(totalCostUsdLH, 2).ToString();
        }



        public ProjectCostingSheetAddTDS.CombinedUnitsInformationDataTable GetUnitsInformation()
        {
            unitsInformation = (ProjectCostingSheetAddTDS.CombinedUnitsInformationDataTable)Session["unitsInformationDummy"];

            if (unitsInformation == null)
            {
                unitsInformation = (ProjectCostingSheetAddTDS.CombinedUnitsInformationDataTable)Session["unitsInformation"];
            }

            return unitsInformation;
        }



        protected void UnitsInformationEmptyFix(GridView grdView)
        {
            if (grdView.Rows.Count == 0)
            {
                ProjectCostingSheetAddTDS.CombinedUnitsInformationDataTable dt = new ProjectCostingSheetAddTDS.CombinedUnitsInformationDataTable();
                dt.AddCombinedUnitsInformationRow(0, "", 0, 0, "", 0, 0, 0, 0, 0, false, 3, false, "", "", DateTime.Now, DateTime.Now, false, "", "", 0, 0, "");
                Session["unitsInformationDummy"] = dt;

                grdView.DataBind();
            }

            // Normally executes at all postbacks
            if (grdView.Rows.Count == 1)
            {
                ProjectCostingSheetAddTDS.CombinedUnitsInformationDataTable dt = (ProjectCostingSheetAddTDS.CombinedUnitsInformationDataTable)Session["unitsInformationDummy"];
                if (dt != null)
                {
                    // Hide row
                    grdView.Rows[0].Visible = false;
                    grdView.Rows[0].Controls.Clear();
                }
            }
        }



        public void DummyUnitsNew(int original_CostingSheetID, string original_Work_, int original_UnitID)
        {
        }



        public void DummyUnitsNew(int original_CostingSheetID, string original_Work_, int original_UnitID, int original_RefID)
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

        #endregion






        #region STEP6 - MATERIAL INFORMATION

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP6 - MATERIAL INFORMATION
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP6 - MATERIAL INFORMATION - EVENTS
        //

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
                    Page.Validate("materialsNew");
                    ProjectGateway projectGateway = new ProjectGateway();

                    int projectId = 0;

                    foreach (int projectIdSelected in projectsSelected)
                    {
                        projectId = projectIdSelected;
                    }

                    if (Page.IsValid)
                    {
                        // Validate costs
                        projectGateway.LoadByProjectId(projectId);

                        if (projectGateway.GetCountryID(projectId) == 1) //Canada
                        {
                            Page.Validate("materialsCadNew");
                        }
                        else
                        {
                            Page.Validate("materialsUsdNew");
                        }
                    }

                    if (Page.IsValid)
                    {
                        int companyId = Int32.Parse(hdfCompanyId.Value);
                        string description = ((DropDownList)grdMaterials.FooterRow.FindControl("ddlDescriptionNew")).SelectedItem.Text;
                        int materialId = Int32.Parse(((DropDownList)grdMaterials.FooterRow.FindControl("ddlDescriptionNew")).SelectedValue);
                        string unitOfMeasurement = ((DropDownList)grdMaterials.FooterRow.FindControl("ddlUnitOfMeasurementMaterialsNew")).SelectedValue;
                        double quantity = double.Parse(((TextBox)grdMaterials.FooterRow.FindControl("tbxQuantityNew")).Text.Trim());

                        decimal costCad = 0.0M;
                        decimal totalCostCad = 0.0M;
                        decimal costUsd = 0.0M;
                        decimal totalCostUsd = 0.0M;

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

                        string workFunctionConcat = "Full Length . Install";
                        string function_ = "Install";

                        ProjectCombinedCostingSheetAddMaterialsInformation model = new ProjectCombinedCostingSheetAddMaterialsInformation(projectCostingSheetAddTDS);
                        model.Insert(0, materialId, unitOfMeasurement, quantity, costCad, totalCostCad, costUsd, totalCostUsd, false, companyId, process, description, startDate, endDate, function_, workFunctionConcat, 1);

                        // Store tables
                        Session.Remove("materialsInformationDummy");
                        materialsInformation = (ProjectCostingSheetAddTDS.CombinedMaterialsInformationDataTable)model.Table;
                        Session["materialsInformation"] = materialsInformation;
                        Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;

                        grdMaterials.DataBind();

                        StepMaterialInformationProcessGrid();
                    }
                    break;
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

                ProjectCombinedCostingSheetAddMaterialsInformationGateway projectCostingSheetAddMaterialsInformationGateway = new ProjectCombinedCostingSheetAddMaterialsInformationGateway(projectCostingSheetAddTDS);
                string unitOfMeasurement = projectCostingSheetAddMaterialsInformationGateway.GetUnitOfMeasurement(costingSheetId, materialId, refId);
                ((DropDownList)e.Row.FindControl("ddlUnitOfMeasurementMaterialsEdit")).SelectedValue = unitOfMeasurement;

                bool fromDatabase = projectCostingSheetAddMaterialsInformationGateway.GetFromDatabase(costingSheetId, materialId, refId);

                if (fromDatabase)
                {
                    ((RadDatePicker)e.Row.FindControl("tkrdpEndDateEdit")).Calendar.Enabled = false;
                    ((RadDatePicker)e.Row.FindControl("tkrdpEndDateEdit")).DateInput.ReadOnly = true;

                    ((RadDatePicker)e.Row.FindControl("tkrdpStartDateEdit")).Calendar.Enabled = false;
                    ((RadDatePicker)e.Row.FindControl("tkrdpStartDateEdit")).DateInput.ReadOnly = true;
                }

                ((RadDatePicker)e.Row.FindControl("hdfFrom")).SelectedDate = tkrdpFrom.SelectedDate;
                ((RadDatePicker)e.Row.FindControl("hdfTo")).SelectedDate = tkrdpTo.SelectedDate;
            }

            // Footer Item
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                ((RadDatePicker)e.Row.FindControl("hdfFrom")).SelectedDate = tkrdpFrom.SelectedDate;
                ((RadDatePicker)e.Row.FindControl("hdfTo")).SelectedDate = tkrdpTo.SelectedDate;

                DropDownList ddlProject = ((DropDownList)e.Row.FindControl("ddlProject_New"));
                ddlProject.DataTextField = "Text";
                ddlProject.DataValueField = "Value";
                ddlProject.DataSource = projectList;
                ddlProject.DataBind();
                ddlProject.SelectedIndex = 0;
            }
        }



        protected void grdMaterials_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Validate general data
            Page.Validate("materialsEdit");

            int projectId = 0;

            foreach (int projectIdSelected in projectsSelected)
            {
                projectId = projectIdSelected;
            }

            ProjectGateway projectGateway = new ProjectGateway();

            if (Page.IsValid)
            {
                // Validate costs            
                projectGateway.LoadByProjectId(projectId);

                if (projectGateway.GetCountryID(projectId) == 1) //Canada
                {
                    Page.Validate("materialsCadEdit");
                }
                else
                {
                    Page.Validate("materialsUsdEdit");
                }
            }

            if (Page.IsValid)
            {
                int costingSheetId = (int)e.Keys["CostingSheetID"];
                int materialId = (int)e.Keys["MaterialID"];
                int refId = (int)e.Keys["RefID"];
                int companyId = Int32.Parse(hdfCompanyId.Value);

                string unitOfMeasurement = ((DropDownList)grdMaterials.Rows[e.RowIndex].Cells[0].FindControl("ddlUnitOfMeasurementMaterialsEdit")).SelectedValue;
                double quantity = double.Parse(((TextBox)grdMaterials.Rows[e.RowIndex].Cells[0].FindControl("tbxQuantityEdit")).Text.Trim());

                decimal costCad = 0.0M;
                decimal totalCostCad = 0.0M;
                decimal costUsd = 0.0M;
                decimal totalCostUsd = 0.0M;

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

                string workFunctionConcat = "Full Length . Install";
                string function_ = "Install";

                // Update data
                ProjectCombinedCostingSheetAddMaterialsInformation model = new ProjectCombinedCostingSheetAddMaterialsInformation(projectCostingSheetAddTDS);
                model.Update(costingSheetId, materialId, refId, unitOfMeasurement, quantity, costCad, totalCostCad, costUsd, totalCostUsd, false, companyId, process, description, startDate, endDate, function_, workFunctionConcat);

                // Store tables
                Session.Remove("materialsInformationDummy");
                materialsInformation = (ProjectCostingSheetAddTDS.CombinedMaterialsInformationDataTable)model.Table;
                Session["materialsInformation"] = materialsInformation;
                Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;

                StepMaterialInformationProcessGrid();
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

            ProjectCombinedCostingSheetAddMaterialsInformation model = new ProjectCombinedCostingSheetAddMaterialsInformation(projectCostingSheetAddTDS);
            model.Delete(costingSheetId, materialId, refId);

            // Store tables
            Session.Remove("materialsInformationDummy");
            materialsInformation = (ProjectCostingSheetAddTDS.CombinedMaterialsInformationDataTable)model.Table;
            Session["materialsInformation"] = materialsInformation;
            Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;

            StepMaterialInformationProcessGrid();
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP6 - MATERIAL INFORMATION -  AUXILIAR EVENTS
        //

        protected void grdMaterials_DataBound(object sender, EventArgs e)
        {
            MaterialsInformationEmptyFix(grdMaterials);
        }



        protected void grdMaterials_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            StepMaterialInformationProcessGrid();
        }



        protected void grdMaterials_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Materials Gridview, if the gridview is edition mode
            if (grdMaterials.EditIndex >= 0)
            {
                grdMaterials.UpdateRow(grdMaterials.EditIndex, true);
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP6 - MATERIAL INFORMATION - METHODS
        //

        private void StepMaterialInformationIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Please verify Material information";

            int projectId = 0;

            foreach (int projectIdSelected in projectsSelected)
            {
                projectId = projectIdSelected;
            }

            // Load
            ProjectCombinedCostingSheetAddMaterialsInformation model = new ProjectCombinedCostingSheetAddMaterialsInformation(projectCostingSheetAddTDS);

            if (projectCostingSheetAddTDS.CombinedMaterialsInformation.Rows.Count == 0)
            {
                ArrayList works = new ArrayList();
                if (cbxFullLengthLiningData.Checked) works.Add("Full Length Lining");
                if (cbxManholeRehabData.Checked) works.Add("Manhole Rehab");
                if (cbxPointRepairData.Checked) works.Add("Point Repairs");
                if (cbxJunctionLiningData.Checked) works.Add("Junction Lining");

                model.Load(works, projectsSelected, tkrdpFrom.SelectedDate.Value, tkrdpTo.SelectedDate.Value, int.Parse(hdfCompanyId.Value));
            }

            // Store tables
            Session.Remove("materialsInformationDummy");
            materialsInformation = (ProjectCostingSheetAddTDS.CombinedMaterialsInformationDataTable)model.Table;
            Session["materialsInformation"] = materialsInformation;
            Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;

            // Validate grid columns
            ProjectGateway projectGateway = new ProjectGateway();
            projectGateway.LoadByProjectId(projectId);

            if (projectGateway.GetCountryID(projectId) == 1) //Canada
            {
                // Materials grid
                grdMaterials.Columns[10].Visible = true;
                grdMaterials.Columns[11].Visible = true;
                grdMaterials.Columns[12].Visible = false;
                grdMaterials.Columns[13].Visible = false;

                lblMaterialsTotalCosts.Text = "Total Cost (CAD) : ";
                tbxMaterialsTotalCostsCAD.Visible = true;
                tbxMaterialsTotalCostsUSD.Visible = false;
            }
            else
            {
                // Materials grid
                grdMaterials.Columns[10].Visible = false;
                grdMaterials.Columns[11].Visible = false;
                grdMaterials.Columns[12].Visible = true;
                grdMaterials.Columns[13].Visible = true;

                lblMaterialsTotalCosts.Text = "Total Cost (USD) : ";
                tbxMaterialsTotalCostsCAD.Visible = false;
                tbxMaterialsTotalCostsUSD.Visible = true;
            }

            grdMaterials.DataBind();
            StepMaterialInformationProcessGrid();
        }



        private bool StepMaterialInformationNext()
        {
            StepMaterialInformationProcessGrid();

            // Store tables
            Session.Remove("materialsInformationDummy");
            Session["materialsInformation"] = materialsInformation;
            Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;

            return true;
        }



        private bool StepMaterialInformationPrevious()
        {
            return true;
        }



        private void StepMaterialInformationProcessGrid()
        {
            decimal totalCostCadLH = 0;
            decimal totalCostUsdLH = 0;

            foreach (ProjectCostingSheetAddTDS.CombinedMaterialsInformationRow row in (ProjectCostingSheetAddTDS.CombinedMaterialsInformationDataTable)Session["materialsInformation"])
            {
                if (!row.Deleted)
                {
                    totalCostCadLH = totalCostCadLH + row.TotalCostCad;
                    totalCostUsdLH = totalCostUsdLH + row.TotalCostUsd;
                }
            }

            tbxMaterialsTotalCostsCAD.Text = Decimal.Round(totalCostCadLH, 2).ToString();
            tbxMaterialsTotalCostsUSD.Text = Decimal.Round(totalCostUsdLH, 2).ToString();
        }



        protected void MaterialsInformationEmptyFix(GridView grdView)
        {
            if (grdView.Rows.Count == 0)
            {
                ProjectCostingSheetAddTDS.CombinedMaterialsInformationDataTable dt = new ProjectCostingSheetAddTDS.CombinedMaterialsInformationDataTable();
                dt.AddCombinedMaterialsInformationRow(0, 0, 0, 0, 0, 0, 0, 0, false, 3, false, "", "", "", DateTime.Now, DateTime.Now, false, "", "", 0, 0, "");
                Session["materialsInformationDummy"] = dt;

                grdView.DataBind();
            }

            // Normally executes at all postbacks
            if (grdView.Rows.Count == 1)
            {
                ProjectCostingSheetAddTDS.CombinedMaterialsInformationDataTable dt = (ProjectCostingSheetAddTDS.CombinedMaterialsInformationDataTable)Session["materialsInformationDummy"];
                if (dt != null)
                {
                    // Hide row
                    grdView.Rows[0].Visible = false;
                    grdView.Rows[0].Controls.Clear();
                }
            }
        }



        public ProjectCostingSheetAddTDS.CombinedMaterialsInformationDataTable GetMaterialsInformation()
        {
            materialsInformation = (ProjectCostingSheetAddTDS.CombinedMaterialsInformationDataTable)Session["materialsInformationDummy"];

            if (materialsInformation == null)
            {
                materialsInformation = (ProjectCostingSheetAddTDS.CombinedMaterialsInformationDataTable)Session["materialsInformation"];
            }

            return materialsInformation;
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

        #endregion






        #region STEP7 - SUBCONTRACTOR INFORMATION

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP7 - SUBCONTRACTOR INFORMATION
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP7 - SUBCONTRACTOR INFORMATION - EVENTS
        //

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

                    int projectId = 0;

                    foreach (int projectIdSelected in projectsSelected)
                    {
                        projectId = projectIdSelected;
                    }

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
                        string comment = ""; if (((TextBox)grdSubcontractors.FooterRow.FindControl("tbxCommentNew")).Text.Trim() != "") comment = ((TextBox)grdSubcontractors.FooterRow.FindControl("tbxCommentNew")).Text.Trim();

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

                        ProjectCombinedCostingSheetAddSubcontractorsInformation model = new ProjectCombinedCostingSheetAddSubcontractorsInformation(projectCostingSheetAddTDS);
                        model.Insert(0, subcontractorId, unitOfMeasurement, quantity, costCad, totalCostCad, costUsd, totalCostUsd, comment, false, companyId, startDate, endDate, subcontractor, 1);

                        Session.Remove("subcontractorsInformationDummy");
                        subcontractorsInformation = (ProjectCostingSheetAddTDS.CombinedSubcontractorsInformationDataTable)model.Table;
                        Session["subcontractorsInformation"] = subcontractorsInformation;
                        Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;

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

            int projectId = 0;

            foreach (int projectIdSelected in projectsSelected)
            {
                projectId = projectIdSelected;
            }

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
                string comment = ((TextBox)grdSubcontractors.Rows[e.RowIndex].Cells[0].FindControl("tbxCommentEdit")).Text;
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
                ProjectCombinedCostingSheetAddSubcontractorsInformation model = new ProjectCombinedCostingSheetAddSubcontractorsInformation(projectCostingSheetAddTDS);
                model.Update(costingSheetId, subcontractorId, refId, unitOfMeasurement, quantity, costCad, totalCostCad, costUsd, totalCostUsd, false, companyId, comment, startDate, endDate);

                // Store dataset
                subcontractorsInformation = (ProjectCostingSheetAddTDS.CombinedSubcontractorsInformationDataTable)model.Table;
                Session["subcontractorsInformation"] = subcontractorsInformation;
                Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;

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

            ProjectCombinedCostingSheetAddSubcontractorsInformation model = new ProjectCombinedCostingSheetAddSubcontractorsInformation(projectCostingSheetAddTDS);
            model.Delete(costingSheetId, subcontractorId, refId);

            // Store dataset
            subcontractorsInformation = (ProjectCostingSheetAddTDS.CombinedSubcontractorsInformationDataTable)model.Table;
            Session["subcontractorsInformation"] = subcontractorsInformation;
            Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;

            StepSubcontractorsInformationProcessGrid();
        }



        protected void grdSubcontractors_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                DropDownList ddlProject = ((DropDownList)e.Row.FindControl("ddlProject_New"));
                ddlProject.DataTextField = "Text";
                ddlProject.DataValueField = "Value";
                ddlProject.DataSource = projectList;
                ddlProject.DataBind();
                ddlProject.SelectedIndex = 0;
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP7 - SUBCONTRACTOR INFORMATION - AUXILIAR EVENTS
        //

        protected void grdSubcontractors_DataBound(object sender, EventArgs e)
        {
            SubcontractorsInformationEmptyFix(grdSubcontractors);
        }



        protected void grdSubcontractors_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            StepSubcontractorsInformationProcessGrid();
        }



        protected void grdSubcontractors_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Subcontractors Gridview, if the gridview is edition mode
            if (grdSubcontractors.EditIndex >= 0)
            {
                grdSubcontractors.UpdateRow(grdSubcontractors.EditIndex, true);
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP7 - SUBCONTRACTOR INFORMATION - METHODS
        //

        private void StepSubcontractorsInformationIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Please verify Subcontractors information";

            int projectId = 0;

            foreach (int projectIdSelected in projectsSelected)
            {
                projectId = projectIdSelected;
            }

            // Load
            ProjectCombinedCostingSheetAddSubcontractorsInformation model = new ProjectCombinedCostingSheetAddSubcontractorsInformation(projectCostingSheetAddTDS);

            if (projectCostingSheetAddTDS.CombinedSubcontractorsInformation.Rows.Count <= 0)
            {
                model.Load(projectsSelected, tkrdpFrom.SelectedDate.Value, tkrdpTo.SelectedDate.Value, int.Parse(hdfCompanyId.Value), Int32.Parse(hdfClientId.Value));
            }

            // Store tables
            Session.Remove("subcontractorsInformationDummy");
            subcontractorsInformation = (ProjectCostingSheetAddTDS.CombinedSubcontractorsInformationDataTable)model.Table;
            Session["subcontractorsInformation"] = subcontractorsInformation;
            Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;

            // Validate grid columns
            ProjectGateway projectGateway = new ProjectGateway();
            projectGateway.LoadByProjectId(projectId);

            if (projectGateway.GetCountryID(projectId) == 1) //Canada
            {
                // Subcontractors Grid
                grdSubcontractors.Columns[9].Visible = true;
                grdSubcontractors.Columns[10].Visible = true;
                grdSubcontractors.Columns[11].Visible = false;
                grdSubcontractors.Columns[12].Visible = false;

                lblSubcontractorsTotalCosts.Text = "Total Cost (CAD) : ";
                tbxSubcontractorsTotalCostsCAD.Visible = true;
                tbxSubcontractorsTotalCostsUSD.Visible = false;
            }
            else
            {
                // Subcontractors Grid
                grdSubcontractors.Columns[9].Visible = false;
                grdSubcontractors.Columns[10].Visible = false;
                grdSubcontractors.Columns[11].Visible = true;
                grdSubcontractors.Columns[12].Visible = true;

                lblSubcontractorsTotalCosts.Text = "Total Cost (USD) : ";
                tbxSubcontractorsTotalCostsCAD.Visible = false;
                tbxSubcontractorsTotalCostsUSD.Visible = true;
            }

            grdSubcontractors.DataBind();
            StepSubcontractorsInformationProcessGrid();
        }



        private bool StepSubcontractorsInformationNext()
        {
            StepSubcontractorsInformationProcessGrid();

            // Store tables
            Session.Remove("subcontractorsInformationDummy");
            Session["subcontractorsInformation"] = subcontractorsInformation;
            Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;
            return true;
        }



        private bool StepSubcontractorsInformationPrevious()
        {
            return true;
        }



        private void StepSubcontractorsInformationProcessGrid()
        {
            decimal totalCostCadLH = 0;
            decimal totalCostUsdLH = 0;

            foreach (ProjectCostingSheetAddTDS.CombinedSubcontractorsInformationRow row in (ProjectCostingSheetAddTDS.CombinedSubcontractorsInformationDataTable)Session["subcontractorsInformation"])
            {
                if (!row.Deleted)
                {
                    totalCostCadLH = totalCostCadLH + row.TotalCostCad;
                    totalCostUsdLH = totalCostUsdLH + row.TotalCostUsd;
                }
            }

            tbxSubcontractorsTotalCostsCAD.Text = Decimal.Round(totalCostCadLH, 2).ToString();
            tbxSubcontractorsTotalCostsUSD.Text = Decimal.Round(totalCostUsdLH, 2).ToString();
        }



        public ProjectCostingSheetAddTDS.CombinedSubcontractorsInformationDataTable GetSubcontractorsInformation()
        {
            subcontractorsInformation = (ProjectCostingSheetAddTDS.CombinedSubcontractorsInformationDataTable)Session["subcontractorsInformationDummy"];

            if (subcontractorsInformation == null)
            {
                subcontractorsInformation = (ProjectCostingSheetAddTDS.CombinedSubcontractorsInformationDataTable)Session["subcontractorsInformation"];
            }

            return subcontractorsInformation;
        }



        protected void SubcontractorsInformationEmptyFix(GridView grdView)
        {
            if (grdView.Rows.Count == 0)
            {
                ProjectCostingSheetAddTDS.CombinedSubcontractorsInformationDataTable dt = new ProjectCostingSheetAddTDS.CombinedSubcontractorsInformationDataTable();
                dt.AddCombinedSubcontractorsInformationRow(0, 0, 0, 0, 0, 0, 0, 0, false, 3, false, "", "Hour", DateTime.Now, DateTime.Now, false, "", 0, 0, "");
                Session["subcontractorsInformationDummy"] = dt;

                grdView.DataBind();
            }

            // Normally executes at all postbacks
            if (grdView.Rows.Count == 1)
            {
                ProjectCostingSheetAddTDS.CombinedSubcontractorsInformationDataTable dt = (ProjectCostingSheetAddTDS.CombinedSubcontractorsInformationDataTable)Session["subcontractorsInformationDummy"];
                if (dt != null)
                {
                    // Hide row
                    grdView.Rows[0].Visible = false;
                    grdView.Rows[0].Controls.Clear();
                }
            }
        }



        public void DummySubcontractorsNew(int original_CostingSheetID, int original_SubcontractorID, int original_RefID)
        {
        }



        public void DummySubcontractorsNew(int CostingSheetID, int SubcontractorID)
        {
        }



        public void DummySubcontractorsNew(int CostingSheetID)
        {
        }

        #endregion






        #region STEP8 - OTHER COST INFORMATION

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP8 - OTHER COST INFORMATION
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP8 - OTHER COST INFORMATION - EVENTS
        //

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
                    Page.Validate("otherCostsNew");

                    // Validate costs
                    int projectId = 0;

                    foreach (int projectIdSelected in projectsSelected)
                    {
                        projectId = projectIdSelected;
                    }

                    ProjectGateway projectGateway = new ProjectGateway();

                    if (Page.IsValid)
                    {
                        projectGateway.LoadByProjectId(projectId);

                        if (projectGateway.GetCountryID(projectId) == 1) //Canada
                        {
                            Page.Validate("otherCostsCadNew");
                        }
                        else
                        {
                            Page.Validate("otherCostsUsdNew");
                        }
                    }

                    if (Page.IsValid)
                    {
                        int companyId = Int32.Parse(hdfCompanyId.Value);
                        string description = ((TextBox)grdOtherCosts.FooterRow.FindControl("tbxDescriptionNew")).Text.Trim();
                        string unitOfMeasurement = ((DropDownList)grdOtherCosts.FooterRow.FindControl("ddlUnitOfMeasurementOthersNew")).SelectedValue;
                        double quantity = double.Parse(((TextBox)grdOtherCosts.FooterRow.FindControl("tbxQuantityNew")).Text.Trim());

                        decimal costCad = 0.0M;
                        decimal totalCostCad = 0.0M;
                        decimal costUsd = 0.0M;
                        decimal totalCostUsd = 0.0M;

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

                        ProjectCombinedCostingSheetAddOtherCostsInformation model = new ProjectCombinedCostingSheetAddOtherCostsInformation(projectCostingSheetAddTDS);
                        model.Insert(0, work_, function_, description, unitOfMeasurement, quantity, costCad, totalCostCad, costUsd, totalCostUsd, false, companyId, workFunctionConcat, startDate, endDate, 1);

                        Session.Remove("otherCostsInformationDummy");
                        otherCostsInformation = (ProjectCostingSheetAddTDS.CombinedOtherCostsInformationDataTable)model.Table;
                        Session["otherCostsInformation"] = otherCostsInformation;
                        Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;

                        grdOtherCosts.DataBind();

                        StepOtherCostsInformationProcessGrid();
                    }
                    break;
            }
        }



        protected void grdOtherCosts_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Validate general data
            Page.Validate("otherCostsEdit");

            // Validate costs
            int projectId = 0;

            foreach (int projectIdSelected in projectsSelected)
            {
                projectId = projectIdSelected;
            }

            ProjectGateway projectGateway = new ProjectGateway();

            if (Page.IsValid)
            {
                projectGateway.LoadByProjectId(projectId);

                if (projectGateway.GetCountryID(projectId) == 1) //Canada
                {
                    Page.Validate("otherCostsCadEdit");
                }
                else
                {
                    Page.Validate("otherCostsUsdEdit");
                }
            }

            if (Page.IsValid)
            {
                int costingSheetId = (int)e.Keys["CostingSheetID"];
                int refId = (int)e.Keys["RefID"];
                int companyId = Int32.Parse(hdfCompanyId.Value);

                string description = ((TextBox)grdOtherCosts.Rows[e.RowIndex].Cells[0].FindControl("tbxDescriptionEdit")).Text.Trim();
                string unitOfMeasurement = ((DropDownList)grdOtherCosts.Rows[e.RowIndex].Cells[0].FindControl("ddlUnitOfMeasurementOthersEdit")).SelectedValue;
                double quantity = double.Parse(((TextBox)grdOtherCosts.Rows[e.RowIndex].Cells[0].FindControl("tbxQuantityEdit")).Text.Trim());

                decimal costCad = 0.0M;
                decimal totalCostCad = 0.0M;
                decimal costUsd = 0.0M;
                decimal totalCostUsd = 0.0M;

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
                ProjectCombinedCostingSheetAddOtherCostsInformation model = new ProjectCombinedCostingSheetAddOtherCostsInformation(projectCostingSheetAddTDS);
                model.Update(costingSheetId, refId, work_, function_, description, unitOfMeasurement, quantity, costCad, totalCostCad, costUsd, totalCostUsd, false, companyId, workFunctionConcat, startDate, endDate);

                otherCostsInformation = (ProjectCostingSheetAddTDS.CombinedOtherCostsInformationDataTable)model.Table;
                Session["otherCostsInformation"] = otherCostsInformation;
                Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;

                StepOtherCostsInformationProcessGrid();
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

            // Delete Other Cost
            int costingSheetId = (int)e.Keys["CostingSheetID"];
            int refId = (int)e.Keys["RefID"];

            ProjectCombinedCostingSheetAddOtherCostsInformation model = new ProjectCombinedCostingSheetAddOtherCostsInformation(projectCostingSheetAddTDS);
            model.Delete(costingSheetId, refId);

            // Store dataset
            otherCostsInformation = (ProjectCostingSheetAddTDS.CombinedOtherCostsInformationDataTable)model.Table;
            Session["otherCostsInformation"] = otherCostsInformation;
            Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;

            StepOtherCostsInformationProcessGrid();
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP8 - OTHER COST INFORMATION - AUXILIAR EVENTS
        //

        protected void grdOtherCosts_DataBound(object sender, EventArgs e)
        {
            OtherCostsInformationEmptyFix(grdOtherCosts);
        }



        protected void grdOtherCosts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            StepOtherCostsInformationProcessGrid();
        }



        protected void grdOtherCosts_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Other costs Gridview, if the gridview is edition mode
            if (grdOtherCosts.EditIndex >= 0)
            {
                grdOtherCosts.UpdateRow(grdOtherCosts.EditIndex, true);
            }
        }



        protected void grdOtherCosts_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Edit items
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Edit) || (e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
            {
                int costingSheetId = Int32.Parse(((Label)e.Row.FindControl("lblCostingSheetIDEdit")).Text.Trim());
                int refId = Int32.Parse(((Label)e.Row.FindControl("lblRefIDEdit")).Text.Trim());

                ProjectCombinedCostingSheetAddOtherCostsInformationGateway projectCostingSheetAddOtherCostsInformationGateway = new ProjectCombinedCostingSheetAddOtherCostsInformationGateway(projectCostingSheetAddTDS);
                string unitOfMeasurement = projectCostingSheetAddOtherCostsInformationGateway.GetUnitOfMeasurement(costingSheetId, refId);
                ((DropDownList)e.Row.FindControl("ddlUnitOfMeasurementOthersEdit")).SelectedValue = unitOfMeasurement;

                ((RadDatePicker)e.Row.FindControl("hdfFrom")).SelectedDate = tkrdpFrom.SelectedDate;
                ((RadDatePicker)e.Row.FindControl("hdfTo")).SelectedDate = tkrdpTo.SelectedDate;
            }

            // Footer Item
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                ((RadDatePicker)e.Row.FindControl("hdfFrom")).SelectedDate = tkrdpFrom.SelectedDate;
                ((RadDatePicker)e.Row.FindControl("hdfTo")).SelectedDate = tkrdpTo.SelectedDate;

                DropDownList ddlProject = ((DropDownList)e.Row.FindControl("ddlProject_New"));
                ddlProject.DataTextField = "Text";
                ddlProject.DataValueField = "Value";
                ddlProject.DataSource = projectList;
                ddlProject.DataBind();
                ddlProject.SelectedIndex = 0;
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP8 - OTHER COST INFORMATION - METHODS
        //

        private void StepOtherCostInformationIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Please provide other costs to cost sheet";

            int projectId = 0;

            foreach (int projectIdSelected in projectsSelected)
            {
                projectId = projectIdSelected;
            }

            // Load
            ProjectCombinedCostingSheetAddOtherCostsInformation model = new ProjectCombinedCostingSheetAddOtherCostsInformation(projectCostingSheetAddTDS);

            // Store tables
            Session.Remove("otherCostsInformationDummy");
            otherCostsInformation = (ProjectCostingSheetAddTDS.CombinedOtherCostsInformationDataTable)model.Table;
            Session["otherCostsInformation"] = otherCostsInformation;
            Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;

            // Validate grid columns
            ProjectGateway projectGateway = new ProjectGateway();
            projectGateway.LoadByProjectId(projectId);

            if (projectGateway.GetCountryID(projectId) == 1) //Canada
            {
                // Other costs
                grdOtherCosts.Columns[9].Visible = true;
                grdOtherCosts.Columns[10].Visible = true;
                grdOtherCosts.Columns[11].Visible = false;
                grdOtherCosts.Columns[12].Visible = false;

                lblOtherCostsTotalCosts.Text = "Total Cost (CAD) : ";
                tbxOtherCostsTotalCostsCAD.Visible = true;
                tbxOtherCostsTotalCostsUSD.Visible = false;
            }
            else
            {
                // Other costs
                grdOtherCosts.Columns[9].Visible = false;
                grdOtherCosts.Columns[10].Visible = false;
                grdOtherCosts.Columns[11].Visible = true;
                grdOtherCosts.Columns[12].Visible = true;

                lblOtherCostsTotalCosts.Text = "Total Cost (USD) : ";
                tbxOtherCostsTotalCostsCAD.Visible = false;
                tbxOtherCostsTotalCostsUSD.Visible = true;
            }

            grdOtherCosts.DataBind();
            StepOtherCostsInformationProcessGrid();
        }



        private bool StepOtherCostInformationNext()
        {
            StepOtherCostsInformationProcessGrid();

            // Store tables
            Session.Remove("otherCostsInformationDummy");
            Session["otherCostsInformation"] = otherCostsInformation;
            Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;
            return true;
        }



        private bool StepOtherCostInformationPrevious()
        {
            return true;
        }



        private void StepOtherCostsInformationProcessGrid()
        {
            decimal totalCostCadLH = 0;
            decimal totalCostUsdLH = 0;

            foreach (ProjectCostingSheetAddTDS.CombinedOtherCostsInformationRow row in (ProjectCostingSheetAddTDS.CombinedOtherCostsInformationDataTable)Session["otherCostsInformation"])
            {
                if (!row.Deleted)
                {
                    totalCostCadLH = totalCostCadLH + row.TotalCostCad;
                    totalCostUsdLH = totalCostUsdLH + row.TotalCostUsd;
                }
            }

            tbxOtherCostsTotalCostsCAD.Text = Decimal.Round(totalCostCadLH, 2).ToString();
            tbxOtherCostsTotalCostsUSD.Text = Decimal.Round(totalCostUsdLH, 2).ToString();
        }



        protected void OtherCostsInformationEmptyFix(GridView grdView)
        {
            if (grdView.Rows.Count == 0)
            {
                ProjectCostingSheetAddTDS.CombinedOtherCostsInformationDataTable dt = new ProjectCostingSheetAddTDS.CombinedOtherCostsInformationDataTable();
                dt.AddCombinedOtherCostsInformationRow(0, 0, "", "", "", "", 0, 0, 0, 0, 0, false, 3, false, "", DateTime.Now, DateTime.Now, 0, 0, "");
                Session["otherCostsInformationDummy"] = dt;

                grdView.DataBind();
            }

            // Normally executes at all postbacks
            if (grdView.Rows.Count == 1)
            {
                ProjectCostingSheetAddTDS.CombinedOtherCostsInformationDataTable dt = (ProjectCostingSheetAddTDS.CombinedOtherCostsInformationDataTable)Session["otherCostsInformationDummy"];
                if (dt != null)
                {
                    // Hide row
                    grdView.Rows[0].Visible = false;
                    grdView.Rows[0].Controls.Clear();
                }
            }
        }



        public ProjectCostingSheetAddTDS.CombinedOtherCostsInformationDataTable GetOtherCostsInformation()
        {
            otherCostsInformation = (ProjectCostingSheetAddTDS.CombinedOtherCostsInformationDataTable)Session["otherCostsInformationDummy"];

            if (otherCostsInformation == null)
            {
                otherCostsInformation = (ProjectCostingSheetAddTDS.CombinedOtherCostsInformationDataTable)Session["otherCostsInformation"];
            }

            return otherCostsInformation;
        }



        public void DummyOtherCostsNew(int original_CostingSheetID, int original_RefID)
        {
        }



        public void DummyOtherCostsNew(int CostingSheetID)
        {
        }

        #endregion






        #region STEP9 - REVENUE INFORMATION

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP9 - REVENUE INFORMATION
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP9 - REVENUE INFORMATION - EVENTS
        //

        protected void grdRevenue_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Add":
                    // Revenue Gridview, if the gridview is edition mode
                    if (grdRevenue.EditIndex >= 0)
                    {
                        grdRevenue.UpdateRow(grdRevenue.EditIndex, true);
                    }

                    // Validate general data
                    Page.Validate("revenueNew");

                    if (Page.IsValid)
                    {
                        int companyId = Int32.Parse(hdfCompanyId.Value);
                        string comment = ""; if (((TextBox)grdRevenue.FooterRow.FindControl("tbxCommentNew")).Text.Trim() != "") comment = ((TextBox)grdRevenue.FooterRow.FindControl("tbxCommentNew")).Text.Trim();

                        decimal revenue = 0.0M;
                        revenue = Decimal.Parse(((TextBox)grdRevenue.FooterRow.FindControl("tbxRevenueNew")).Text.Trim());
                        revenue = Decimal.Round(revenue, 2);

                        DateTime startDate = ((RadDatePicker)grdRevenue.FooterRow.FindControl("tkrdpStartDateNew")).SelectedDate.Value;
                        DateTime endDate = startDate;

                        ProjectCombinedCostingSheetAddRevenueInformation model = new ProjectCombinedCostingSheetAddRevenueInformation(projectCostingSheetAddTDS);
                        model.Insert(0, revenue, false, companyId, startDate, endDate, comment, 1);

                        Session.Remove("revenueInformationDummy");
                        revenueInformation = (ProjectCostingSheetAddTDS.CombinedRevenueInformationDataTable)model.Table;
                        Session["revenueInformation"] = revenueInformation;
                        Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;

                        grdRevenue.DataBind();

                        StepRevenueInformationProcessGrid();
                    }
                    break;
            }
        }



        protected void grdRevenue_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                DropDownList ddlProject = ((DropDownList)e.Row.FindControl("ddlProject_New"));
                ddlProject.DataTextField = "Text";
                ddlProject.DataValueField = "Value";
                ddlProject.DataSource = projectList;
                ddlProject.DataBind();
                ddlProject.SelectedIndex = 0;
            }
        }



        protected void grdRevenue_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Validate general data
            Page.Validate("revenueEdit");

            if (Page.IsValid)
            {
                int costingSheetId = (int)e.Keys["CostingSheetID"];
                int refIdRevenue = (int)e.Keys["RefIDRevenue"];

                int companyId = Int32.Parse(hdfCompanyId.Value);
                string comment = ((TextBox)grdRevenue.Rows[e.RowIndex].Cells[0].FindControl("tbxCommentEdit")).Text;

                decimal revenue = 0.0M;
                revenue = Decimal.Parse(((TextBox)grdRevenue.Rows[e.RowIndex].Cells[0].FindControl("tbxRevenueEdit")).Text.Trim());
                revenue = Decimal.Round(revenue, 2);

                DateTime startDate = ((RadDatePicker)grdRevenue.Rows[e.RowIndex].Cells[0].FindControl("tkrdpStartDateEdit")).SelectedDate.Value;
                DateTime endDate = startDate;

                // Update data
                ProjectCombinedCostingSheetAddRevenueInformation model = new ProjectCombinedCostingSheetAddRevenueInformation(projectCostingSheetAddTDS);
                model.Update(costingSheetId, refIdRevenue, revenue, false, companyId, startDate, endDate, comment);

                // Store dataset
                revenueInformation = (ProjectCostingSheetAddTDS.CombinedRevenueInformationDataTable)model.Table;
                Session["revenueInformation"] = revenueInformation;
                Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;

                StepRevenueInformationProcessGrid();
            }
            else
            {
                e.Cancel = true;
            }
        }



        protected void grdRevenue_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Revenue Gridview, if the gridview is edition mode
            if (grdRevenue.EditIndex >= 0)
            {
                grdRevenue.UpdateRow(grdRevenue.EditIndex, true);
            }

            // Delete revenue
            int costingSheetId = (int)e.Keys["CostingSheetID"];
            int refIdRevenue = (int)e.Keys["RefIDRevenue"];

            ProjectCombinedCostingSheetAddRevenueInformation model = new ProjectCombinedCostingSheetAddRevenueInformation(projectCostingSheetAddTDS);
            model.Delete(costingSheetId, refIdRevenue);

            // Store dataset
            revenueInformation = (ProjectCostingSheetAddTDS.CombinedRevenueInformationDataTable)model.Table;
            Session["revenueInformation"] = revenueInformation;
            Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;

            StepRevenueInformationProcessGrid();
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP9 - REVENUE INFORMATION - AUXILIAR EVENTS
        //

        protected void grdRevenue_DataBound(object sender, EventArgs e)
        {
            RevenueInformationEmptyFix(grdRevenue);
        }



        protected void grdRevenue_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            StepRevenueInformationProcessGrid();
        }



        protected void grdRevenue_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Revenue Gridview, if the gridview is edition mode
            if (grdRevenue.EditIndex >= 0)
            {
                grdRevenue.UpdateRow(grdRevenue.EditIndex, true);
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP9 - REVENUE INFORMATION - METHODS
        //

        private void StepRevenueInformationIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Please verify Revenue information";

            // Load
            ProjectCombinedCostingSheetAddRevenueInformation model = new ProjectCombinedCostingSheetAddRevenueInformation(projectCostingSheetAddTDS);

            if (projectCostingSheetAddTDS.CombinedRevenueInformation.Rows.Count <= 0)
            {
                model.Load(projectsSelected, tkrdpFrom.SelectedDate.Value, tkrdpTo.SelectedDate.Value, int.Parse(hdfCompanyId.Value));
            }

            // Store tables
            Session.Remove("revenueInformationDummy");
            revenueInformation = (ProjectCostingSheetAddTDS.CombinedRevenueInformationDataTable)model.Table;
            Session["revenueInformation"] = revenueInformation;
            Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;

            grdRevenue.DataBind();
            StepRevenueInformationProcessGrid();

            GetRevenueSummary();
        }



        private bool StepRevenueInformationNext()
        {
            StepRevenueInformationProcessGrid();

            // Store tables
            Session.Remove("revenueInformationDummy");
            Session["revenueInformation"] = revenueInformation;
            Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;
            return true;
        }



        private bool StepRevenueInformationPrevious()
        {
            return true;
        }



        private void StepRevenueInformationProcessGrid()
        {
            decimal totalRevenue = 0;

            foreach (ProjectCostingSheetAddTDS.CombinedRevenueInformationRow row in (ProjectCostingSheetAddTDS.CombinedRevenueInformationDataTable)Session["revenueInformation"])
            {
                if (!row.Deleted)
                {
                    totalRevenue = totalRevenue + row.Revenue;
                }
            }

            tbxRevenueTotal.Text = Decimal.Round(totalRevenue, 2).ToString();
        }



        private void GetRevenueSummary()
        {
            decimal grandTotalCad = Decimal.Round(decimal.Parse(tbxTeamMembersTotalCostCAD.Text) + decimal.Parse(tbxUnitsTotalCostsCAD.Text) + decimal.Parse(tbxMaterialsTotalCostsCAD.Text) + decimal.Parse(tbxOtherCostsTotalCostsCAD.Text) + decimal.Parse(tbxSubcontractorsTotalCostsCAD.Text), 2);
            decimal grandTotalUsd = Decimal.Round(decimal.Parse(tbxTeamMembersTotalCostUSD.Text) + decimal.Parse(tbxUnitsTotalCostsUSD.Text) + decimal.Parse(tbxMaterialsTotalCostsUSD.Text) + decimal.Parse(tbxOtherCostsTotalCostsUSD.Text) + decimal.Parse(tbxSubcontractorsTotalCostsUSD.Text), 2);
            decimal grandTotal = 0.0M;
            decimal grandRevenue = decimal.Round(decimal.Parse(tbxRevenueTotal.Text), 2);
            decimal grandProfit = 0.0M;
            decimal grandGrossMargin = 0.0M;

            int projectId = 0;

            foreach (int projectIdSelected in projectsSelected)
            {
                projectId = projectIdSelected;
            }

            ProjectGateway projectGateway = new ProjectGateway();
            projectGateway.LoadByProjectId(projectId);

            if (projectGateway.GetCountryID(projectId) == 1) //Canada
            {
                lblGrandTotal.Text = "Grand Total (CAD)";
                grandTotal = grandTotalCad;
            }
            else
            {
                lblGrandTotal.Text = "Grand Total (USD)";
                grandTotal = grandTotalUsd;
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

            tbxGrandTotal.Text = grandTotal.ToString();
            tbxGradRevenue.Text = tbxRevenueTotal.Text;
            tbxGrandProfit.Text = grandProfit.ToString();
            tbxGrandGrossMargin.Text = decimal.Round(grandGrossMargin, 2).ToString();
        }



        protected void RevenueInformationEmptyFix(GridView grdView)
        {
            if (grdView.Rows.Count == 0)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                ProjectCostingSheetAddTDS.CombinedRevenueInformationDataTable dt = new ProjectCostingSheetAddTDS.CombinedRevenueInformationDataTable();
                dt.AddCombinedRevenueInformationRow(0, 0, 0, "", companyId, DateTime.Now, DateTime.Now, false, false, false, 0, 0, "");
                Session["revenueInformationDummy"] = dt;

                grdView.DataBind();
            }

            // Normally executes at all postbacks
            if (grdView.Rows.Count == 1)
            {
                ProjectCostingSheetAddTDS.CombinedRevenueInformationDataTable dt = (ProjectCostingSheetAddTDS.CombinedRevenueInformationDataTable)Session["revenueInformationDummy"];
                if (dt != null)
                {
                    // Hide row
                    grdView.Rows[0].Visible = false;
                    grdView.Rows[0].Controls.Clear();
                }
            }
        }



        public ProjectCostingSheetAddTDS.CombinedRevenueInformationDataTable GetRevenueInformation()
        {
            revenueInformation = (ProjectCostingSheetAddTDS.CombinedRevenueInformationDataTable)Session["revenueInformationDummy"];

            if (revenueInformation == null)
            {
                revenueInformation = (ProjectCostingSheetAddTDS.CombinedRevenueInformationDataTable)Session["revenueInformation"];
            }

            return revenueInformation;
        }



        public void DummyRevenueNew(int original_CostingSheetID, int original_RefIDRevenue)
        {
        }

        #endregion






        #region STEP10 - SUMMARY

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP10 - SUMMARY
        //


        // ////////////////////////////////////////////////////////////////////////
        // STEP10 - SUMMARY - METHODS
        //

        private void StepSummaryIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Summary";

            // Initialize summary
            tbxSummary.Text = GetSummary();
        }



        private bool StepSummaryPrevious()
        {
            return true;
        }



        protected bool StepSummaryFinish()
        {
            Page.Validate("");
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






        #region STEP11 - FINISH OPTIONS
        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // STEP11 - FINISH OPTIONS
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP11 - FINISH OPTIONS - METHODS
        //

        private void StepFinalStepIn()
        {
            // Set instruction
            mWizard2 master2 = (mWizard2)this.Master;
            master2.WizardInstruction = "What would you like to do?";

            lkbtnClose.Attributes.Add("onclick", "return lkbtnCloseClick();");

            if (cbxEndConfirm.Checked)
            {
                string url = "";
                int newCostingSheetId = Int32.Parse(hdfCostingSheetId.Value);
                int projectId = 0;

                if (hdfProjectId.Value == "0")
                {
                    foreach (int projectIdSelected in projectsSelected)
                    {
                        projectId = projectIdSelected;
                    }
                }
                else
                {
                    projectId = int.Parse(hdfProjectId.Value);
                }

                url = "./project_combined_costing_sheets_summary.aspx?source_page=project_combined_costing_sheets_add.aspx&project_id=" + projectId + "&costing_sheet_id=" + newCostingSheetId;
                lkbtnOpenCostingSheet.Attributes.Add("onclick", string.Format("return lkbtnOpenServiceClick('{0}');", url));

                url = "./project_combined_costing_sheets_edit.aspx?source_page=project_combined_costing_sheets_add.aspx&project_id=" + projectId + "&costing_sheet_id=" + newCostingSheetId;
                lkbtnEditCostingSheet.Attributes.Add("onclick", string.Format("return lkbtnEditServiceClick('{0}');", url));
            }
            else
            {
                lkbtnOpenCostingSheet.Visible = false;
                lkbtnEditCostingSheet.Visible = false;
            }
        }

        #endregion






        // ////////////////////////////////////////////////////////////////////////
        // FINAL EVENTS 
        //

        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set wizard title
            Label title = (Label)this.Master.FindControl("lblTitle");
            title.Text = "Add Combined Costing Sheet";
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        private void RegisterClientScripts()
        {
            // Resolve timeout problem
            ScriptManager scriptManager = (ScriptManager)this.Page.Master.FindControl("ScriptManager1");
            if (scriptManager != null)
            {
                scriptManager.AsyncPostBackTimeout = 1200;
            }

            // Register content variables
            string contentVariables = "";

            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./project_combined_costing_sheets_add.js");
        }



        private void TagPage()
        {
            hdfProjectId.Value = (string)Request.QueryString["project_Id"];
            hdfClientId.Value = (string)Request.QueryString["client_Id"];
            hdfCompanyId.Value = Convert.ToInt32(Session["companyID"]).ToString();
        }



        private void UpdateDatabase()
        {
            DB.Open();
            DB.BeginTransaction();
            try
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                int loginId = Convert.ToInt32(Session["loginID"]);

                if (cbxEndConfirm.Checked)
                {
                    ProjectCombinedCostingSheetAddBasicInformation projectCostingSheetAddBasicInformation = new ProjectCombinedCostingSheetAddBasicInformation(projectCostingSheetAddTDS);
                    int costingSheetId = projectCostingSheetAddBasicInformation.Save(companyId);
                    hdfCostingSheetId.Value = costingSheetId.ToString();

                    // Save costs information
                    ProjectCombinedCostingSheetAddLabourHoursInformation projectCostingSheetAddLabourHoursInformation = new ProjectCombinedCostingSheetAddLabourHoursInformation(projectCostingSheetAddTDS);
                    projectCostingSheetAddLabourHoursInformation.Save(companyId, costingSheetId);

                    ProjectCombinedCostingSheetAddUnitsInformation projectCostingSheetAddUnitsInformation = new ProjectCombinedCostingSheetAddUnitsInformation(projectCostingSheetAddTDS);
                    projectCostingSheetAddUnitsInformation.Save(companyId, costingSheetId);

                    ProjectCombinedCostingSheetAddMaterialsInformation projectCostingSheetAddMaterialsInformation = new ProjectCombinedCostingSheetAddMaterialsInformation(projectCostingSheetAddTDS);
                    projectCostingSheetAddMaterialsInformation.Save(companyId, costingSheetId);

                    ProjectCombinedCostingSheetAddSubcontractorsInformation projectCostingSheetAddSubcontractorsInformation = new ProjectCombinedCostingSheetAddSubcontractorsInformation(projectCostingSheetAddTDS);
                    projectCostingSheetAddSubcontractorsInformation.Save(companyId, costingSheetId);

                    ProjectCombinedCostingSheetAddOtherCostsInformation projectCostingSheetAddOtherCostsInformation = new ProjectCombinedCostingSheetAddOtherCostsInformation(projectCostingSheetAddTDS);
                    projectCostingSheetAddOtherCostsInformation.Save(companyId, costingSheetId);

                    ProjectCombinedCostingSheetAddRevenueInformation projectCostingSheetAddRevenueInformation = new ProjectCombinedCostingSheetAddRevenueInformation(projectCostingSheetAddTDS);
                    projectCostingSheetAddRevenueInformation.Save(companyId, costingSheetId);

                    if (rbtnBeginTemplate.Checked)
                    {
                        ProjectCostingSheetTemplateInformation projectCostingSheetTemplateInformation = new ProjectCostingSheetTemplateInformation(projectCostingSheetAddTDS);
                        projectCostingSheetTemplateInformation.Save(companyId);
                    }
                }
                else
                {
                    if (cbxEndSave.Checked)
                    {
                        ProjectCostingSheetTemplateInformation projectCostingSheetTemplateInformation = new ProjectCostingSheetTemplateInformation(projectCostingSheetAddTDS);
                        projectCostingSheetTemplateInformation.Save(companyId);
                    }
                    else
                    {
                        if (rbtnBeginTemplate.Checked)
                        {
                            ProjectCostingSheetTemplateInformation projectCostingSheetTemplateInformation = new ProjectCostingSheetTemplateInformation(projectCostingSheetAddTDS);
                            projectCostingSheetTemplateInformation.Save(companyId);
                        }
                    }
                }

                DB.CommitTransaction();

                // Store datasets
                projectCostingSheetAddTDS.AcceptChanges();
                Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;

            }
            catch (Exception ex)
            {
                DB.RollbackTransaction();

                string url = string.Format("./../../error_page.aspx?error={0}", ex.Message.Replace('\n', ' '));
                Response.Redirect(url);
            }
        }



        private void PostPageChanges()
        {
            if (cbxEndConfirm.Checked)
            {
                string combinedProjects = "";

                foreach (int projectId in projectsSelected)
                {
                    ProjectGateway projectGateway = new ProjectGateway();
                    projectGateway.LoadByProjectId(projectId);

                    combinedProjects = combinedProjects + ", " + projectGateway.GetName(projectId);
                }
                ProjectCombinedCostingSheetAddBasicInformation model = new ProjectCombinedCostingSheetAddBasicInformation(projectCostingSheetAddTDS);
                model.Insert(Int32.Parse(hdfClientId.Value), tbxName.Text, tkrdpFrom.SelectedDate.Value, tkrdpTo.SelectedDate.Value, decimal.Parse(tbxTeamMembersTotalCostCAD.Text), decimal.Parse(tbxTeamMembersTotalCostUSD.Text), decimal.Parse(tbxMaterialsTotalCostsCAD.Text), decimal.Parse(tbxMaterialsTotalCostsUSD.Text), decimal.Parse(tbxUnitsTotalCostsCAD.Text), decimal.Parse(tbxUnitsTotalCostsUSD.Text), decimal.Parse(tbxOtherCostsTotalCostsCAD.Text), decimal.Parse(tbxOtherCostsTotalCostsUSD.Text), 0, 0, "In Progress", false, Int32.Parse(hdfCompanyId.Value), decimal.Parse(tbxSubcontractorsTotalCostsCAD.Text), decimal.Parse(tbxSubcontractorsTotalCostsUSD.Text), decimal.Parse(tbxRevenueTotal.Text), decimal.Parse(tbxGrandProfit.Text), decimal.Parse(tbxGrandGrossMargin.Text), combinedProjects);

                Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;
            }
        }



        private void PostPageChanges2()
        {
            if (cbxEndSave.Checked)
            {
                int? month = null;
                int? day = null;
                int? year = null;

                int? month2 = null;
                int? day2 = null;
                int? year2 = null;

                if (tkrdpFrom.SelectedDate.HasValue)
                {
                    month = tkrdpFrom.SelectedDate.Value.Month;
                    day = tkrdpFrom.SelectedDate.Value.Day;
                    year = tkrdpFrom.SelectedDate.Value.Year;
                }

                if (tkrdpTo.SelectedDate.HasValue)
                {
                    month2 = tkrdpTo.SelectedDate.Value.Month;
                    day2 = tkrdpTo.SelectedDate.Value.Day;
                    year2 = tkrdpTo.SelectedDate.Value.Year;
                }

                if (rbtnEndSaveNew.Checked)
                {
                    if (tbxEndSaveNew.Text != "")
                    {
                        ProjectCostingSheetTemplateInformation projectCostingSheetTemplateInformation = new ProjectCostingSheetTemplateInformation(projectCostingSheetAddTDS);
                        projectCostingSheetTemplateInformation.Insert(tbxEndSaveNew.Text, cbxRehabAssessmentData.Checked, cbxFullLengthLiningData.Checked, cbxPointRepairData.Checked, cbxJunctionLiningData.Checked, cbxManholeRehabData.Checked, cbxMobilizationData.Checked, cbxOtherData.Checked, cbxLabourHour.Checked, cbxTrucksEquipment.Checked, cbxMaterial.Checked, cbxSubcontractor.Checked, cbxOtherCost.Checked, cbxRevenueInformation.Checked, false, Convert.ToInt32(hdfCompanyId.Value), month, day, year, month2, day2, year2);
                    }
                }

                if (rbtnEndSaveReplace.Checked)
                {
                    if (luEndSaveTemplate.SelectedIndex > 0)
                    {
                        ProjectCostingSheetTemplateInformation projectCostingSheetTemplateInformation = new ProjectCostingSheetTemplateInformation(projectCostingSheetAddTDS);
                        projectCostingSheetTemplateInformation.Update(Convert.ToInt32(luEndSaveTemplate.SelectedValue), luEndSaveTemplate.SelectedItem.Text, cbxRehabAssessmentData.Checked, cbxFullLengthLiningData.Checked, cbxPointRepairData.Checked, cbxJunctionLiningData.Checked, cbxManholeRehabData.Checked, cbxMobilizationData.Checked, cbxOtherData.Checked, cbxLabourHour.Checked, cbxTrucksEquipment.Checked, cbxMaterial.Checked, cbxSubcontractor.Checked, cbxOtherCost.Checked, cbxRevenueInformation.Checked, false, Convert.ToInt32(hdfCompanyId.Value), month, day, year, month2, day2, year2);
                    }
                }

                Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;
                templateInformation = projectCostingSheetAddTDS.TemplateInformation;
                Session["templateInformation"] = templateInformation;
            }
        }



        private string GetSummary()
        {
            string summary = "";

            if (cbxEndConfirm.Checked)
            {
                decimal grandTotalCad = Decimal.Round(decimal.Parse(tbxTeamMembersTotalCostCAD.Text) + decimal.Parse(tbxUnitsTotalCostsCAD.Text) + decimal.Parse(tbxMaterialsTotalCostsCAD.Text) + decimal.Parse(tbxOtherCostsTotalCostsCAD.Text) + decimal.Parse(tbxSubcontractorsTotalCostsCAD.Text), 2);
                decimal grandTotalUsd = Decimal.Round(decimal.Parse(tbxTeamMembersTotalCostUSD.Text) + decimal.Parse(tbxUnitsTotalCostsUSD.Text) + decimal.Parse(tbxMaterialsTotalCostsUSD.Text) + decimal.Parse(tbxOtherCostsTotalCostsUSD.Text) + decimal.Parse(tbxSubcontractorsTotalCostsUSD.Text), 2);
                summary = "GENERAL INFORMATION \n";
                summary += "Name: \t" + tbxName.Text + "\n";
                summary += "Date Range: \t" + "From " + tkrdpFrom.SelectedDate.Value.ToShortDateString() + " To " + tkrdpTo.SelectedDate.Value.ToShortDateString() + "\n";
                summary += "Labour Hours: \t Total Cost (CAD) = " + tbxTeamMembersTotalCostCAD.Text + "\t (USD) = " + tbxTeamMembersTotalCostUSD.Text + "\n";
                summary += "Trucks / Equipment Costs: \t Total Cost (CAD) = " + tbxUnitsTotalCostsCAD.Text + "\t (USD) = " + tbxUnitsTotalCostsUSD.Text + "\n";
                summary += "Materials Costs: \t Total Cost (CAD) = " + tbxMaterialsTotalCostsCAD.Text + "\t (USD) = " + tbxMaterialsTotalCostsUSD.Text + "\n";
                summary += "Subcontractors Costs: \t Total Cost (CAD) = " + tbxSubcontractorsTotalCostsCAD.Text + "\t (USD) = " + tbxSubcontractorsTotalCostsUSD.Text + "\n";
                summary += "Other Costs: \t Total Cost (CAD) = " + tbxOtherCostsTotalCostsCAD.Text + "\t (USD) = " + tbxOtherCostsTotalCostsUSD.Text + "\n";
                summary += "Grand Total (CAD) = " + grandTotalCad.ToString() + "\t (USD) = " + grandTotalUsd.ToString() + "\n";
            }
            else
            {
                if (cbxEndSave.Checked)
                {
                    summary = "GENERAL INFORMATION \n";

                    if (rbtnEndSaveNew.Checked) summary += "Name: \t" + tbxEndSaveNew.Text + "\n";
                    if (rbtnEndSaveReplace.Checked) summary += "Name: \t" + luEndSaveTemplate.SelectedItem.Text + "\n";

                    string typeOfWork = "";
                    if (cbxRehabAssessmentData.Checked) typeOfWork = "RA";
                    if (cbxFullLengthLiningData.Checked) { if (typeOfWork.Length > 0) typeOfWork = typeOfWork + "- FLL"; else typeOfWork = "FLL"; }
                    if (cbxPointRepairData.Checked) { if (typeOfWork.Length > 0) typeOfWork = typeOfWork + "- PR"; else typeOfWork = "PR"; }
                    if (cbxJunctionLiningData.Checked) { if (typeOfWork.Length > 0) typeOfWork = typeOfWork + "- JL"; else typeOfWork = "JL"; }
                    if (cbxManholeRehabData.Checked) { if (typeOfWork.Length > 0) typeOfWork = typeOfWork + "- MR"; else typeOfWork = "MR"; }
                    if (cbxMobilizationData.Checked) { if (typeOfWork.Length > 0) typeOfWork = typeOfWork + "- MOB"; else typeOfWork = "MOB"; }
                    if (cbxOtherData.Checked) { if (typeOfWork.Length > 0) typeOfWork = typeOfWork + "- Other"; else typeOfWork = "Other"; }
                    summary += "Type of Work: \t" + typeOfWork + "\n";

                    string costingArea = "";
                    if (cbxLabourHour.Checked) costingArea = "Labour Hour";
                    if (cbxTrucksEquipment.Checked) { if (costingArea.Length > 0) costingArea = costingArea + "- Unit"; else costingArea = "Unit"; }
                    if (cbxMaterial.Checked) { if (costingArea.Length > 0) costingArea = costingArea + "- Material"; else costingArea = "Material"; }
                    if (cbxSubcontractor.Checked) { if (costingArea.Length > 0) costingArea = costingArea + "- Subcontractor"; else costingArea = "Subcontractor"; }
                    if (cbxOtherCost.Checked) { if (costingArea.Length > 0) costingArea = costingArea + "- Misc."; else costingArea = "Misc."; }
                    summary += "Costing Area: \t" + costingArea + "\n";
                }
            }

            return summary;
        }



    }
}