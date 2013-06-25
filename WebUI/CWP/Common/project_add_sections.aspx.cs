using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.BL.CWP.Common;
using LiquiForce.LFSLive.CWP.Tools;
using LiquiForce.LFSLive.DA.Assets.Assets;
using LiquiForce.LFSLive.DA.Company.Organization;
using LiquiForce.LFSLive.DA.CWP.Common;
using LiquiForce.LFSLive.DA.CWP.Works;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.WebUI.CWP.Common
{
    /// <summary>
    /// Project_add_sections
    /// </summary>
    public partial class project_add_sections : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected ProjectAddSectionsTDS.ProjectAddSectionsNewDataTable projectAddSectionsNew;
        protected ProjectAddSectionsTDS.ProjectAddSectionsSearchDataTable projectAddSectionsSearch;
        protected ProjectAddSectionsTDS.ProjectAddSectionsTempDataTable projectAddSectionsTemp;
      





        // ////////////////////////////////////////////////////////////////////////
        // INITIAL EVENTS
        //

        protected void Page_Load(object sender, EventArgs e)
        {
            // Register client scripts
            this.RegisterClientScripts();

            if (!IsPostBack)
            {
                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["client_id"] == null) || ((string)Request.QueryString["project_id"] == null) || ((string)Request.QueryString["work_type"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in project_add_sections.aspx");
                }

                // Security check
                if ((string)Request.QueryString["work_type"] == "Rehab Assessment")
                {
                    if (!(Convert.ToBoolean(Session["sgLFS_CWP_REHABASSESSMENT_ADD"])))
                    {
                        Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                    }
                }

                if ((string)Request.QueryString["work_type"] == "Full Length Lining")
                {
                    if (!(Convert.ToBoolean(Session["sgLFS_CWP_FULLLENGTHLINING_ADD"])))
                    {
                        Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                    }
                }

                if ((string)Request.QueryString["work_type"] == "Junction Lining")
                {
                    if (!(Convert.ToBoolean(Session["sgLFS_CWP_JUNCTIONLINING_ADD"])))
                    {
                        Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                    }
                }

                if ((string)Request.QueryString["work_type"] == "Point Repairs")
                {
                    if (!(Convert.ToBoolean(Session["sgLFS_CWP_POINTREPAIRS_ADD"])))
                    {
                        Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                    }
                }

                if ((string)Request.QueryString["work_type"] == "Manhole Rehabilitation")
                {
                    if (!(Convert.ToBoolean(Session["sgLFS_CWP_MANHOLEREHABILITATION_ADD"])))
                    {
                        Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                    }
                }

                // Tag Page
                TagPage();

                // Prepare initial data
                Session.Remove("projectAddSectionsNew");
                Session.Remove("projectAddSectionsNewDummy");
                Session.Remove("projectAddSectionsSearch");
                Session.Remove("projectAddSectionsSearchDummy");
                Session.Remove("projectAddSectionsTemp");
                Session.Remove("projectAddSectionsTempDummy");

                // Initialize viewstate variables
                ViewState["StepFrom"] = "Out";
                
                // If coming from 
                // ... ra_navigator.aspx, ra_navigator2.aspx, jl_navigator.aspx, jl_navigator2.aspx, project_sections_navigator.aspx, project_sections_navigator2.aspx, fl_navigator.aspx, fl_navigator2.aspx, ra_lining_plan.aspx, fl_edit.aspx, fl_summary.aspx, ra_edit.aspx, ra_summary.aspx, flat_section_jl_summary.aspx, flat_section_jl_edit.aspx, flat_section_jls_summary.aspx, flat_section_jls_edit.aspx, jl_lining_plan.aspx, pr_navigator.aspx, pr_navigator2.aspx, pr_summay.aspx, pr_edit.aspx, pr_lining_plan, mr_navigator.aspx, mr_navigator2.aspx, mr_edit.aspx, mr_summary.aspx
                if ((Request.QueryString["source_page"] == "ra_navigator.aspx") || (Request.QueryString["source_page"] == "ra_navigator2.aspx") || (Request.QueryString["source_page"] == "jl_navigator.aspx") || (Request.QueryString["source_page"] == "jl_navigator2.aspx") || (Request.QueryString["source_page"] == "project_sections_navigator.aspx") || (Request.QueryString["source_page"] == "project_sections_navigator2.aspx") || (Request.QueryString["source_page"] == "fl_navigator.aspx") || (Request.QueryString["source_page"] == "fl_navigator2.aspx") || (Request.QueryString["source_page"] == "ra_lining_plan.aspx") || (Request.QueryString["source_page"] == "fl_edit.aspx") || (Request.QueryString["source_page"] == "fl_summary.aspx") || (Request.QueryString["source_page"] == "ra_edit.aspx") || (Request.QueryString["source_page"] == "ra_summary.aspx") || (Request.QueryString["source_page"] == "flat_section_jl_summary.aspx") || (Request.QueryString["source_page"] == "flat_section_jl_edit.aspx") || (Request.QueryString["source_page"] == "flat_section_jls_summary.aspx") || (Request.QueryString["source_page"] == "flat_section_jls_edit.aspx") || (Request.QueryString["source_page"] == "jl_lining_plan.aspx") || (Request.QueryString["source_page"] == "pr_navigator.aspx") || (Request.QueryString["source_page"] == "pr_navigator2.aspx") || (Request.QueryString["source_page"] == "pr_summary.aspx") || (Request.QueryString["source_page"] == "pr_edit.aspx") || (Request.QueryString["source_page"] == "pr_lining_plan.aspx") || (Request.QueryString["source_page"] == "mr_navigator.aspx") || (Request.QueryString["source_page"] == "mr_navigator2.aspx")  || (Request.QueryString["source_page"] == "mr_edit.aspx")  || (Request.QueryString["source_page"] == "mr_summary.aspx"))
                {                   
                    // ... Initialize tables
                    projectAddSectionsNew = new ProjectAddSectionsTDS.ProjectAddSectionsNewDataTable();
                    projectAddSectionsSearch = new ProjectAddSectionsTDS.ProjectAddSectionsSearchDataTable();
                    projectAddSectionsTemp = new ProjectAddSectionsTDS.ProjectAddSectionsTempDataTable();

                    // ... Store tables
                    Session["projectAddSectionsNew"] = projectAddSectionsNew;
                    Session["projectAddSectionsSearch"] = projectAddSectionsSearch;
                    Session["projectAddSectionsTemp"] = projectAddSectionsTemp;
                }        

                // StepSection1In
                wzSections.ActiveStepIndex = 0;
                StepBeginIn();
            }
            else
            {
                // Restore tables
                projectAddSectionsNew = (ProjectAddSectionsTDS.ProjectAddSectionsNewDataTable) Session["projectAddSectionsNew"];
                projectAddSectionsSearch = (ProjectAddSectionsTDS.ProjectAddSectionsSearchDataTable)Session["projectAddSectionsSearch"];
                projectAddSectionsTemp = (ProjectAddSectionsTDS.ProjectAddSectionsTempDataTable)Session["projectAddSectionsTemp"];
            }

            // control for postback
            hdfTag.Value = DateTime.Now.ToLongTimeString();
        }






        #region Wizard navigation events

        // ////////////////////////////////////////////////////////////////////////
        // WIZARD NAVIGATION EVENTS
        //

        protected void Wizard_ActiveStepChanged(object sender, EventArgs e)
        {
            if (ViewState["StepFrom"] != null)
            {
                switch (wzSections.ActiveStep.Name)
                {
                    case "Begin":
                        StepBeginIn();
                        break;

                    case "New Sections":
                        StepNewSectionsIn();
                        break;

                    case "Search Intermediate Sections":
                        StepSearchIntermediateSectionsIn();
                        break;

                    case "Select For Intermediate Section":
                        StepSelectForIntermediateSectionsIn();
                        break;

                    case "New Intermediate Sections":
                        StepNewIntermediateSectionsIn();
                        break;

                    case "Search Sections":
                        StepSearchSectionsIn();
                        break;

                    case "Select Sections":
                        StepSelectSectionsIn();
                        break;

                    case "Remove Sections":
                        StepRemoveSectionsIn();
                        break;

                    case "Summary":
                        StepSummaryIn();
                        break;

                    default:
                        throw new Exception("The option for " + wzSections.ActiveStep.Name + " step in project_add_section.Wizard_ActiveStepChanged function does not exist");
                }
            }
        }



        protected void Wizard_NextButtonClick(object sender, WizardNavigationEventArgs e)
        {
            switch (wzSections.ActiveStep.Name)
            {
                case "Begin":
                    e.Cancel = !StepBeginNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "Begin";
                        if (rbtnBeginNewSection.Checked)
                        {
                            wzSections.ActiveStepIndex = wzSections.WizardSteps.IndexOf(StepNewSections);
                        }
                        else
                        {
                            if (rbtnBeginNewIntermediateSection.Checked)
                            {
                                wzSections.ActiveStepIndex = wzSections.WizardSteps.IndexOf(StepSearchIntermediateSections);
                            }
                            else
                            {
                                wzSections.ActiveStepIndex = wzSections.WizardSteps.IndexOf(StepSearchSections);
                            }
                        }
                    }
                    break;

                case "New Sections":
                    e.Cancel = !StepNewSectionsNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "New Sections";
                        wzSections.ActiveStepIndex = wzSections.WizardSteps.IndexOf(StepSummary);
                    }
                    break;

                case "Search Intermediate Sections":
                    e.Cancel = !StepSearchIntermediateSectionsNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "Search Intermediate Sections";
                        wzSections.ActiveStepIndex = wzSections.WizardSteps.IndexOf(StepSelectForIntermediateSections);
                    }
                    break;

                case "Select For Intermediate Section":
                    e.Cancel = !StepSelectForIntermediateSectionsNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "Select For Intermediate Section";
                        wzSections.ActiveStepIndex = wzSections.WizardSteps.IndexOf(StepNewIntermediateSections);
                    }
                    break;

                case "New Intermediate Sections":
                    e.Cancel = !StepNewIntermediateSectionsNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "New Intermediate Sections";
                        wzSections.ActiveStepIndex = wzSections.WizardSteps.IndexOf(StepSummary);
                    }
                    break;

                case "Search Sections":
                    e.Cancel = !StepSearchSectionsNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "Search Sections";
                        wzSections.ActiveStepIndex = wzSections.WizardSteps.IndexOf(StepSearchSections);
                    }
                    break;

                case "Select Sections":
                    e.Cancel = !StepSelectSectionsNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "Select Sections";
                        wzSections.ActiveStepIndex = wzSections.WizardSteps.IndexOf(StepSummary);
                    }
                    break;

                case "Remove Sections":
                    e.Cancel = !StepRemoveSectionsNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "Remove Sections";
                        wzSections.ActiveStepIndex = wzSections.WizardSteps.IndexOf(StepSummary);
                    }
                    break;

                default:
                    throw new Exception("The option for " + wzSections.ActiveStep.Name + " step in project_add_section.Wizard_NextButtonClick function does not exist");
            }
        }



        protected void Wizard_PreviousButtonClick(object sender, WizardNavigationEventArgs e)
        {
            switch (wzSections.ActiveStep.Name)
            {
                case "New Sections":
                    e.Cancel = !StepNewSectionsPrevious();
                    break;

                case "Searh Intermediate Sections":
                    e.Cancel = !StepSearchIntermediateSectionsPrevious();
                    break;

                case "Select For Intermediate Sections":
                    e.Cancel = !StepSelectForIntermediateSectionsPrevious();
                    break;

                case "New Intermediate Sections":
                    e.Cancel = !StepNewIntermediateSectionsPrevious();
                    break;

                case "Search Sections":
                    e.Cancel = !StepSearchSectionsPrevious();
                    break;

                case "Select Sections":
                    e.Cancel = !StepSelectSectionsPrevious();
                    break;

                case "Remove Sections":
                    e.Cancel = !StepRemoveSectionsPrevious();
                    break;

                case "Summary":
                    e.Cancel = !StepSummaryPrevious();
                    break;

                default:
                    throw new Exception("The option for " + wzSections.ActiveStep.Name + " step in project_add_sections.Wizard_PreviousButtonClick function does not exist");
            }
            if (!e.Cancel)
            {
                ViewState["StepFrom"] = wzSections.ActiveStep.Name;
            }
        }



        protected void Wizard_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        {
            e.Cancel = (!StepSummaryFinish());

            if (!e.Cancel)
            {
                Response.Write("<script language='javascript'> { window.close();}</script>");
            }
        }



        protected void Wizard_CancelButtonClick(object sender, EventArgs e)
        {
            Response.Write("<script language='javascript'> { window.close();}</script>");
        }



        protected void ddlGoToStep_SelectedIndexChanged(object sender, EventArgs e)
        {
            Table table = (Table)wzSections.ActiveStep.Parent.Parent.Parent.Parent;
            ControlCollection controlCollection = table.Rows[2].Cells[0].Controls;
            Control stepNavigationTemplate = controlCollection[2];
            DropDownList ddl = (DropDownList) stepNavigationTemplate.FindControl("ddlGoToStep");

            ddlGoTo_Process(ddl);
        }



        protected void ddlGoToFinish_SelectedIndexChanged(object sender, EventArgs e)
        {
            Table table = (Table)wzSections.ActiveStep.Parent.Parent.Parent.Parent;
            ControlCollection controlCollection = table.Rows[2].Cells[0].Controls;
            Control stepNavigationTemplate = controlCollection[1];
            DropDownList ddl = (DropDownList)stepNavigationTemplate.FindControl("ddlGoToFinish");

            ddlGoTo_Process(ddl);
        }



        private void ddlGoTo_Process(DropDownList ddl)
        {
            // Get destination
            int stepDestination = 0;
            switch (ddl.SelectedValue)
            {
                case "(Go to...)":
                    break;

                case "Create New Sections":
                    stepDestination = wzSections.WizardSteps.IndexOf(StepNewSections);
                    break;

                case "Create New Intermediate Sections":
                    stepDestination = wzSections.WizardSteps.IndexOf(StepSearchIntermediateSections);
                    break;

                case "Add Existing Sections":
                    stepDestination = wzSections.WizardSteps.IndexOf(StepSearchSections);
                    break;

                case "Remove Sections":
                    stepDestination = wzSections.WizardSteps.IndexOf(StepRemoveSections);
                    break;

                default:
                    throw new Exception("Selected Value don't exists in code");
            }
            ddl.SelectedIndex = 0;

            // verify
            bool move = false;
            switch (wzSections.ActiveStep.Name)
            {
                case "New Sections":
                    if (stepDestination != wzSections.WizardSteps.IndexOf(StepNewSections))
                    {
                        move = StepNewSectionsNext();
                    }
                    break;

                case "Search Intermediate Sections":
                    if (stepDestination != wzSections.WizardSteps.IndexOf(StepSearchIntermediateSections))
                    {
                        move = true;
                    } 
                    break;

                case "Select For Intermediate Section":
                    if (stepDestination != wzSections.WizardSteps.IndexOf(StepSelectForIntermediateSections))
                    {
                        move = true;
                    }
                    break;

                case "New Intermediate Sections":
                    if (stepDestination != wzSections.WizardSteps.IndexOf(StepNewIntermediateSections))
                    {
                        move = StepNewIntermediateSectionsNext();
                    }
                    break;

                case "Search Sections":
                    if (stepDestination != wzSections.WizardSteps.IndexOf(StepSearchSections))
                    {
                        move = true;
                    }
                    break;

                case "Select Sections":
                    move = StepSelectSectionsNext();
                    break;

                case "Remove Sections":
                    if (stepDestination != wzSections.WizardSteps.IndexOf(StepRemoveSections))
                    {
                        move = StepRemoveSectionsNext();
                    }
                    break;

                case "Summary":
                    move = true;
                    break;
            }

            // move
            if (move)
            {
                ViewState["StepFrom"] = wzSections.ActiveStep.Name;
                wzSections.ActiveStepIndex = stepDestination;
            }
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
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "What would you like to do?";
        }



        private bool StepBeginNext()
        {
            return true;
        }



        #endregion






        #region STEP2 - NEW SECTIONS

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP2 - NEW SECTION
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP2 - NEW SECTION - EVENTS
        //

        protected void grdProjectAddSectionsNew_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Add":
                    // ProjectAddSections Gridview, if the gridview is edition mode
                    if (grdProjectAddSectionsNew.EditIndex >= 0)
                    {
                        grdProjectAddSectionsNew.UpdateRow(grdProjectAddSectionsNew.EditIndex, true);
                    }

                    // Add New Project Sections
                    GrdProjectAddSectionsNewAdd();
                    break;
            }
        }



        protected void grdProjectAddSectionsNew_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Edit controls
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Edit) || (e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                int id = Int32.Parse(((Label)e.Row.FindControl("lblID")).Text);

                ProjectAddSectionsTDS dataSet = new ProjectAddSectionsTDS();
                dataSet.ProjectAddSectionsNew.Merge(projectAddSectionsNew, true);
                ProjectAddSectionsNew model = new ProjectAddSectionsNew(dataSet);
                projectAddSectionsNew = dataSet.ProjectAddSectionsNew;

                ProjectAddSectionsNewGateway projectAddSectionsNewGatewayForGrid = new ProjectAddSectionsNewGateway(dataSet);

                if (projectAddSectionsNewGatewayForGrid.Table.Rows.Count > 0)
                {
                    ((DropDownList)e.Row.FindControl("ddlSectionMaterialEdit")).SelectedValue = projectAddSectionsNewGatewayForGrid.GetSectionMaterial(id).ToString();

                    ((DropDownList)e.Row.FindControl("ddlUsmhShapeEdit")).SelectedValue = projectAddSectionsNewGatewayForGrid.GetUsmhShape(id);
                    ((DropDownList)e.Row.FindControl("ddlUsmhLocationEdit")).SelectedValue = projectAddSectionsNewGatewayForGrid.GetUsmhLocation(id);
                    ((DropDownList)e.Row.FindControl("ddlUsmhConditionRatingEdit")).SelectedValue = projectAddSectionsNewGatewayForGrid.GetUsmhConditionRating(id).ToString();
                    ((DropDownList)e.Row.FindControl("ddlUsmhMaterialEdit")).SelectedValue = projectAddSectionsNewGatewayForGrid.GetUsmhMaterialId(id).ToString();

                    ((DropDownList)e.Row.FindControl("ddlDsmhShapeEdit")).SelectedValue = projectAddSectionsNewGatewayForGrid.GetDsmhShape(id);
                    ((DropDownList)e.Row.FindControl("ddlDsmhLocationEdit")).SelectedValue = projectAddSectionsNewGatewayForGrid.GetDsmhLocation(id);
                    ((DropDownList)e.Row.FindControl("ddlDsmhConditionRatingEdit")).SelectedValue = projectAddSectionsNewGatewayForGrid.GetDsmhConditionRating(id).ToString();
                    ((DropDownList)e.Row.FindControl("ddlDsmhMaterialEdit")).SelectedValue = projectAddSectionsNewGatewayForGrid.GetDsmhMaterialId(id).ToString();
                }
            }

            // Footer Item
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                switch (hdfWorkType.Value)
                {
                    case "All":
                        ((CheckBox)e.Row.FindControl("cbxRehabAssessmentWorkAdd")).Checked = true;
                        ((CheckBox)e.Row.FindControl("cbxFullLengthLiningWorkAdd")).Checked = true;
                        ((CheckBox)e.Row.FindControl("cbxPointRepairsWorkAdd")).Checked = true;
                        ((CheckBox)e.Row.FindControl("cbxJunctionLiningWorkAdd")).Checked = true;
                        ((CheckBox)e.Row.FindControl("cbxMHRehabUsmhAdd")).Checked = true;
                        ((CheckBox)e.Row.FindControl("cbxMHRehabDsmhAdd")).Checked = true;
                        break;

                    case "Rehab Assessment":
                        ((CheckBox)e.Row.FindControl("cbxRehabAssessmentWorkAdd")).Checked = true;
                        ((CheckBox)e.Row.FindControl("cbxFullLengthLiningWorkAdd")).Checked = false;
                        ((CheckBox)e.Row.FindControl("cbxPointRepairsWorkAdd")).Checked = false;
                        ((CheckBox)e.Row.FindControl("cbxJunctionLiningWorkAdd")).Checked = false;
                        ((CheckBox)e.Row.FindControl("cbxMHRehabUsmhAdd")).Checked = false;
                        ((CheckBox)e.Row.FindControl("cbxMHRehabDsmhAdd")).Checked = false;
                        break;

                    case "Full Length Lining":
                        ((CheckBox)e.Row.FindControl("cbxRehabAssessmentWorkAdd")).Checked = false;
                        ((CheckBox)e.Row.FindControl("cbxFullLengthLiningWorkAdd")).Checked = true;
                        ((CheckBox)e.Row.FindControl("cbxPointRepairsWorkAdd")).Checked = false;
                        ((CheckBox)e.Row.FindControl("cbxJunctionLiningWorkAdd")).Checked = false;
                        ((CheckBox)e.Row.FindControl("cbxMHRehabUsmhAdd")).Checked = false;
                        ((CheckBox)e.Row.FindControl("cbxMHRehabDsmhAdd")).Checked = false;
                        break;

                    case "Point Repairs":
                        ((CheckBox)e.Row.FindControl("cbxRehabAssessmentWorkAdd")).Checked = false;
                        ((CheckBox)e.Row.FindControl("cbxFullLengthLiningWorkAdd")).Checked = false;
                        ((CheckBox)e.Row.FindControl("cbxPointRepairsWorkAdd")).Checked = true;
                        ((CheckBox)e.Row.FindControl("cbxJunctionLiningWorkAdd")).Checked = false;
                        ((CheckBox)e.Row.FindControl("cbxMHRehabUsmhAdd")).Checked = false;
                        ((CheckBox)e.Row.FindControl("cbxMHRehabDsmhAdd")).Checked = false;
                        break;

                    case "Junction Lining":
                        ((CheckBox)e.Row.FindControl("cbxRehabAssessmentWorkAdd")).Checked = false;
                        ((CheckBox)e.Row.FindControl("cbxFullLengthLiningWorkAdd")).Checked = false;
                        ((CheckBox)e.Row.FindControl("cbxPointRepairsWorkAdd")).Checked = false;
                        ((CheckBox)e.Row.FindControl("cbxJunctionLiningWorkAdd")).Checked = true;
                        ((CheckBox)e.Row.FindControl("cbxMHRehabUsmhAdd")).Checked = false;
                        ((CheckBox)e.Row.FindControl("cbxMHRehabDsmhAdd")).Checked = false;
                        break;

                    case "Manhole Rehabilitation":
                        ((CheckBox)e.Row.FindControl("cbxRehabAssessmentWorkAdd")).Checked = false;
                        ((CheckBox)e.Row.FindControl("cbxFullLengthLiningWorkAdd")).Checked = false;
                        ((CheckBox)e.Row.FindControl("cbxPointRepairsWorkAdd")).Checked = false;
                        ((CheckBox)e.Row.FindControl("cbxJunctionLiningWorkAdd")).Checked = false;
                        ((CheckBox)e.Row.FindControl("cbxMHRehabUsmhAdd")).Checked = true;
                        ((CheckBox)e.Row.FindControl("cbxMHRehabDsmhAdd")).Checked = true;
                        break;
                }
            }
        }



        protected void grdProjectAddSectionsNew_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Update section
            Page.Validate("AddSectionsUpdate");
            if (Page.IsValid)
            {
                int id = (int)e.Keys["ID"];
                int companyId = Int32.Parse(hdfCompanyId.Value);
                string sectionId = ((Label)grdProjectAddSectionsNew.Rows[e.RowIndex].Cells[0].FindControl("lblSectionIdEdit")).Text;
                string street = ((TextBox)grdProjectAddSectionsNew.Rows[e.RowIndex].Cells[1].FindControl("tbxStreetEdit")).Text;
                string usmh = ((TextBox)grdProjectAddSectionsNew.Rows[e.RowIndex].Cells[1].FindControl("tbxUsmhEdit")).Text;
                string dsmh = ((TextBox)grdProjectAddSectionsNew.Rows[e.RowIndex].Cells[1].FindControl("tbxDsmhEdit")).Text;
                string mapSize = ((TextBox)grdProjectAddSectionsNew.Rows[e.RowIndex].Cells[1].FindControl("tbxMapSizeEdit")).Text;
                string mapLength = ((TextBox)grdProjectAddSectionsNew.Rows[e.RowIndex].Cells[1].FindControl("tbxMapLengthEdit")).Text;

                string clientId = "";
                if (((TextBox)grdProjectAddSectionsNew.Rows[e.RowIndex].Cells[1].FindControl("tbxClientIdEdit")).Text.Trim() != "")
                {
                    clientId = ((TextBox)grdProjectAddSectionsNew.Rows[e.RowIndex].Cells[1].FindControl("tbxClientIdEdit")).Text;
                }

                string sectionMaterial = "";
                if (((DropDownList)grdProjectAddSectionsNew.Rows[e.RowIndex].FindControl("ddlSectionMaterialEdit")).SelectedValue != "-1")
                {
                    sectionMaterial = ((DropDownList)grdProjectAddSectionsNew.Rows[e.RowIndex].FindControl("ddlSectionMaterialEdit")).SelectedValue;
                }

                bool cbxRA = ((CheckBox)grdProjectAddSectionsNew.Rows[e.RowIndex].FindControl("cbxRehabAssessmentWorkEdit")).Checked;
                bool cbxFLL = ((CheckBox)grdProjectAddSectionsNew.Rows[e.RowIndex].FindControl("cbxFullLengthLiningWorkEdit")).Checked;
                bool cbxPR = ((CheckBox)grdProjectAddSectionsNew.Rows[e.RowIndex].FindControl("cbxPointRepairsWorkEdit")).Checked;
                bool cbxJL = ((CheckBox)grdProjectAddSectionsNew.Rows[e.RowIndex].FindControl("cbxJunctionLiningWorkEdit")).Checked;

                bool cbxMHRehabUsmh = ((CheckBox)grdProjectAddSectionsNew.Rows[e.RowIndex].FindControl("cbxMHRehabUsmhEdit")).Checked;
                bool cbxMHRehabDsmh = ((CheckBox)grdProjectAddSectionsNew.Rows[e.RowIndex].FindControl("cbxMHRehabDsmhEdit")).Checked;                

                string usmhStreet = ((TextBox)grdProjectAddSectionsNew.Rows[e.RowIndex].Cells[1].FindControl("tbxUsmhStreetEdit")).Text.Trim();
                string usmhLatitude = ((TextBox)grdProjectAddSectionsNew.Rows[e.RowIndex].Cells[1].FindControl("tbxUsmhLatitudeEdit")).Text.Trim();
                string usmhLongitude = ((TextBox)grdProjectAddSectionsNew.Rows[e.RowIndex].Cells[1].FindControl("tbxUsmhLongitudeEdit")).Text.Trim();
                string usmhShape = ((DropDownList)grdProjectAddSectionsNew.Rows[e.RowIndex].Cells[1].FindControl("ddlUsmhShapeEdit")).SelectedValue;
                string usmhLocation = ((DropDownList)grdProjectAddSectionsNew.Rows[e.RowIndex].Cells[1].FindControl("ddlUsmhLocationEdit")).SelectedValue;
                int? usmhConditionRating = null;
                if (((DropDownList)grdProjectAddSectionsNew.Rows[e.RowIndex].Cells[1].FindControl("ddlUsmhConditionRatingEdit")).SelectedValue != "-1")
                {
                    usmhConditionRating = Int32.Parse(((DropDownList)grdProjectAddSectionsNew.Rows[e.RowIndex].Cells[1].FindControl("ddlUsmhConditionRatingEdit")).SelectedValue);
                }
                int? usmhMaterialId = null;
                string usmhMaterial = "";
                if (((DropDownList)grdProjectAddSectionsNew.Rows[e.RowIndex].Cells[1].FindControl("ddlUsmhMaterialEdit")).SelectedValue != "-1")
                {
                    usmhMaterialId = Int32.Parse(((DropDownList)grdProjectAddSectionsNew.Rows[e.RowIndex].Cells[1].FindControl("ddlUsmhMaterialEdit")).SelectedValue);
                    AssetSewerMHMaterialTypeGateway assetSewerMHMaterialTypeGatewayForUsmh = new AssetSewerMHMaterialTypeGateway();
                    assetSewerMHMaterialTypeGatewayForUsmh.LoadByMaterialId((int)usmhMaterialId, companyId);
                    usmhMaterial = assetSewerMHMaterialTypeGatewayForUsmh.GetMaterialType((int)usmhMaterialId);
                }

                string dsmhStreet = ((TextBox)grdProjectAddSectionsNew.Rows[e.RowIndex].Cells[1].FindControl("tbxDsmhStreetEdit")).Text.Trim();
                string dsmhLatitude = ((TextBox)grdProjectAddSectionsNew.Rows[e.RowIndex].Cells[1].FindControl("tbxDsmhLatitudeEdit")).Text.Trim();
                string dsmhLongitude = ((TextBox)grdProjectAddSectionsNew.Rows[e.RowIndex].Cells[1].FindControl("tbxDsmhLongitudeEdit")).Text.Trim();
                string dsmhShape = ((DropDownList)grdProjectAddSectionsNew.Rows[e.RowIndex].Cells[1].FindControl("ddlDsmhShapeEdit")).SelectedValue;
                string dsmhLocation = ((DropDownList)grdProjectAddSectionsNew.Rows[e.RowIndex].Cells[1].FindControl("ddlDsmhLocationEdit")).SelectedValue;
                int? dsmhConditionRating = null;
                if (((DropDownList)grdProjectAddSectionsNew.Rows[e.RowIndex].Cells[1].FindControl("ddlDsmhConditionRatingEdit")).SelectedValue != "-1")
                {
                    dsmhConditionRating = Int32.Parse(((DropDownList)grdProjectAddSectionsNew.Rows[e.RowIndex].Cells[1].FindControl("ddlDsmhConditionRatingEdit")).SelectedValue);
                }
                int? dsmhMaterialId = null;
                string dsmhMaterial = "";
                if (((DropDownList)grdProjectAddSectionsNew.Rows[e.RowIndex].Cells[1].FindControl("ddlDsmhMaterialEdit")).SelectedValue != "-1")
                {
                    dsmhMaterialId = Int32.Parse(((DropDownList)grdProjectAddSectionsNew.Rows[e.RowIndex].Cells[1].FindControl("ddlDsmhMaterialEdit")).SelectedValue);
                    AssetSewerMHMaterialTypeGateway assetSewerMHMaterialTypeGatewayForDsmh = new AssetSewerMHMaterialTypeGateway();
                    assetSewerMHMaterialTypeGatewayForDsmh.LoadByMaterialId((int)dsmhMaterialId, companyId);
                    dsmhMaterial = assetSewerMHMaterialTypeGatewayForDsmh.GetMaterialType((int)dsmhMaterialId);
                }

                // ... get structure data
                string usmhTopDiameter = "";
                string usmhTopDepth = "";
                string usmhDownDiameter = "";
                string usmhDownDepth = "";
                int? usmhManholeRugs = null;
                string usmhRectangle1LongSide = "";
                string usmhRectangle1ShortSide = "";
                string usmhRectangle2LongSide = "";
                string usmhRectangle2ShortSide = "";
                string usmhTotalSurfaceArea = "";
                string dsmhTopDiameter = "";
                string dsmhTopDepth = "";
                string dsmhDownDiameter = "";
                string dsmhDownDepth = "";
                int? dsmhManholeRugs = null;
                string dsmhRectangle1LongSide = "";
                string dsmhRectangle1ShortSide = "";
                string dsmhRectangle2LongSide = "";
                string dsmhRectangle2ShortSide = "";
                string dsmhTotalSurfaceArea = "";

                // Update datasets
                ProjectAddSectionsTDS dataSet = new ProjectAddSectionsTDS();
                dataSet.ProjectAddSectionsNew.Merge(projectAddSectionsNew, true);
                ProjectAddSectionsNew model = new ProjectAddSectionsNew(dataSet);

                // Update
                model.Update(id, sectionId, street, usmh, dsmh, cbxJL, cbxRA, cbxFLL, cbxPR, false, sectionId, mapSize, mapLength, usmhStreet, usmhLatitude, usmhLongitude, usmhShape, usmhLocation, usmhConditionRating, usmhMaterialId, usmhMaterial, usmhTopDiameter, usmhTopDepth, usmhDownDiameter, usmhDownDepth, usmhManholeRugs, usmhRectangle1LongSide, usmhRectangle1ShortSide, usmhRectangle2LongSide, usmhRectangle2ShortSide, usmhTotalSurfaceArea, dsmhStreet, dsmhLatitude, dsmhLongitude, dsmhShape, dsmhLocation, dsmhConditionRating, dsmhMaterialId, dsmhMaterial, dsmhTopDiameter, dsmhTopDepth, dsmhDownDiameter, dsmhDownDepth, dsmhManholeRugs, dsmhRectangle1LongSide, dsmhRectangle1ShortSide, dsmhRectangle2LongSide, dsmhRectangle2ShortSide, dsmhTotalSurfaceArea, sectionMaterial, clientId, cbxMHRehabUsmh, cbxMHRehabDsmh);
                Session["projectAddSectionsNew"] = dataSet.ProjectAddSectionsNew;
                projectAddSectionsNew = dataSet.ProjectAddSectionsNew;
            }
            else
            {
                e.Cancel = true;
            }
        }



        protected void grdProjectAddSectionsNew_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // ProjectAddSections Gridview, if the gridview is edition mode
            if (grdProjectAddSectionsNew.EditIndex >= 0)
            {
                grdProjectAddSectionsNew.UpdateRow(grdProjectAddSectionsNew.EditIndex, true);
            }
        }



        protected void grdProjectAddSectionsNew_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // ProjectAddSectionsNew Gridview, if the gridview is edition mode
            if (grdProjectAddSectionsNew.EditIndex >= 0)
            {
                grdProjectAddSectionsNew.UpdateRow(grdProjectAddSectionsNew.EditIndex, true);
            }
            
            // Delete section
            int id = (int)e.Keys["ID"];

            ProjectAddSectionsTDS dataSet = new ProjectAddSectionsTDS();
            dataSet.ProjectAddSectionsNew.Merge(projectAddSectionsNew, true);
            ProjectAddSectionsNew model = new ProjectAddSectionsNew(dataSet);

            model.Delete(id);
            Session["projectAddSectionsNew"] = dataSet.ProjectAddSectionsNew;
        }





        
        // ////////////////////////////////////////////////////////////////////////
        // STEP2 - NEW SECTION - AUXILIAR EVENTS
        //

        protected void grdProjectAddSectionsNew_DataBound(object sender, EventArgs e)
        {
            ProjectAddSectionsNewEmptyFix(grdProjectAddSectionsNew);
        }



        protected void grdProjectAddSectionsNew_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if ((e.Row.RowType == DataControlRowType.Footer) || (e.Row.RowType == DataControlRowType.DataRow))
            {
                // callback control
                if (hdfCountryId.Value == "")
                {
                    TagPage();
                }

                // autocomplete
                string provinceId = "0"; if (hdfProvinceId.Value != "") provinceId = hdfProvinceId.Value;
                string countyId = "0"; if (hdfCountyId.Value != "") countyId = hdfCountyId.Value;
                string cityId = "0"; if (hdfCityId.Value != "") cityId = hdfCityId.Value;

                AjaxControlToolkit.AutoCompleteExtender aceUsmh = (AjaxControlToolkit.AutoCompleteExtender)e.Row.FindControl("aceUsmh");
                if (aceUsmh != null)
                {
                    aceUsmh.ContextKey = hdfCountryId.Value + "," + provinceId + "," + countyId + "," + cityId + "," + hdfCompanyId.Value;
                }

                AjaxControlToolkit.AutoCompleteExtender aceDsmh = (AjaxControlToolkit.AutoCompleteExtender)e.Row.FindControl("aceDsmh");
                if (aceDsmh != null)
                {
                    aceDsmh.ContextKey = hdfCountryId.Value + "," + provinceId + "," + countyId + "," + cityId + "," + hdfCompanyId.Value;
                }
            }
        }



        protected void cvDistance_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Trim() != "")
            {
                // Initialize 
                CustomValidator cvDistance = (CustomValidator)source;
                args.IsValid = true;

                // Control of format
                if (!Distance.IsValidDistance(args.Value))
                {
                    cvDistance.Text = "Invalid format. (please use X'Y\", or Xft Yin, or X.Y, or X.Ym, or X.Ymm)";
                    args.IsValid = false;
                }

                // Control of distance > 0
                if (args.IsValid)
                {
                    Distance distance = new Distance(args.Value);
                    if (distance.ToDoubleInEng3() < 0)
                    {
                        cvDistance.Text = "Invalid distance. (must be equal or greater than 0)";
                        args.IsValid = false;
                    }
                }
            }
        }



        protected void cvUsmhDsmhDBAdd_ServerValidate(object source, ServerValidateEventArgs args)
        {
            bool usmhAndDsmhValid = true;
            args.IsValid = true;

            // Validate if mh already exists 
            int companyId = Int32.Parse(hdfCompanyId.Value);
            Int64? countryId = null; if (hdfCountryId.Value != "0") countryId = Int64.Parse(hdfCountryId.Value);
            Int64? provinceId = null; if (hdfProvinceId.Value != "0") provinceId = Int64.Parse(hdfProvinceId.Value);
            Int64? countyId = null; if (hdfCountyId.Value != "0") countyId = Int64.Parse(hdfCountyId.Value);
            Int64? cityId = null; if (hdfCityId.Value != "0") cityId = Int64.Parse(hdfCityId.Value);
            int projectId = int.Parse(hdfProjectId.Value);

            string usmh = ((TextBox)grdProjectAddSectionsNew.FooterRow.FindControl("tbxUsmhAdd")).Text;
            string dsmh = ((TextBox)grdProjectAddSectionsNew.FooterRow.FindControl("tbxDsmhAdd")).Text;

            AssetSewerMHGateway assetSewerMhGatewayUSMH = new AssetSewerMHGateway();
            assetSewerMhGatewayUSMH.LoadByCountryIdProvinceIdCountyIdCityIdMhId(countryId, provinceId, countyId, cityId, usmh, companyId, "", "", "");// TODO MH

            AssetSewerMHGateway assetSewerMhGatewayDSMH = new AssetSewerMHGateway();
            assetSewerMhGatewayDSMH.LoadByCountryIdProvinceIdCountyIdCityIdMhId(countryId, provinceId, countyId, cityId, dsmh, companyId, "", "", ""); // TODO MH

            if (assetSewerMhGatewayUSMH.Table.Rows.Count > 0 && assetSewerMhGatewayDSMH.Table.Rows.Count > 0)
            {
                int assetIdUsmh = assetSewerMhGatewayUSMH.GetAssetID(usmh);
                int assetIdDsmh = assetSewerMhGatewayDSMH.GetAssetID(dsmh);

                AssetSewerMHGateway assetSewerMhGateway = new AssetSewerMHGateway(null);
                if (assetSewerMhGateway.USmhDsmhInUseForSections(assetIdUsmh, assetIdDsmh, companyId))
                {
                    usmhAndDsmhValid = false;
                }
            }

            if (usmhAndDsmhValid)
            {
                foreach (GridViewRow row in grdProjectAddSectionsNew.Rows)
                {
                    string usmhRow = ((TextBox)row.FindControl("tbxUsmh")).Text;
                    string dsmhRow = ((TextBox)row.FindControl("tbxDsmh")).Text;

                    if ((usmhRow == usmh && dsmhRow == dsmh) || (usmhRow == dsmh && dsmhRow == usmh))
                    {
                        usmhAndDsmhValid = false;
                    }
                }
            }

            args.IsValid = usmhAndDsmhValid;
        }



        protected void cvUsmhDsmhDBEdit_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Initialize
            args.IsValid = true;

            // Validate if mh already exists 
            int companyId = Int32.Parse(hdfCompanyId.Value);
            Int64? countryId = null; if (hdfCountryId.Value != "0") countryId = Int64.Parse(hdfCountryId.Value);
            Int64? provinceId = null; if (hdfProvinceId.Value != "0") provinceId = Int64.Parse(hdfProvinceId.Value);
            Int64? countyId = null; if (hdfCountyId.Value != "0") countyId = Int64.Parse(hdfCountyId.Value);
            Int64? cityId = null; if (hdfCityId.Value != "0") cityId = Int64.Parse(hdfCityId.Value);
            int projectId = int.Parse(hdfProjectId.Value);

            CustomValidator cvUsmhDsmhDBEdit = (CustomValidator)source;
            GridViewRow gridRow = (GridViewRow)cvUsmhDsmhDBEdit.NamingContainer;

            string usmh = ((TextBox)gridRow.FindControl("tbxUsmhEdit")).Text;
            string dsmh = ((TextBox)gridRow.FindControl("tbxDsmhEdit")).Text;

            AssetSewerMHGateway assetSewerMhGatewayUSMH = new AssetSewerMHGateway();
            assetSewerMhGatewayUSMH.LoadByCountryIdProvinceIdCountyIdCityIdMhId(countryId, provinceId, countyId, cityId, usmh, companyId, "", "", "");//TODO MH

            AssetSewerMHGateway assetSewerMhGatewayDSMH = new AssetSewerMHGateway();
            assetSewerMhGatewayDSMH.LoadByCountryIdProvinceIdCountyIdCityIdMhId(countryId, provinceId, countyId, cityId, dsmh, companyId, "", "", "");//TODO MH

            if (assetSewerMhGatewayUSMH.Table.Rows.Count > 0 && assetSewerMhGatewayDSMH.Table.Rows.Count > 0)
            {
                int assetIdUsmh = assetSewerMhGatewayUSMH.GetAssetID(usmh);
                int assetIdDsmh = assetSewerMhGatewayDSMH.GetAssetID(dsmh);

                AssetSewerMHGateway assetSewerMhGateway = new AssetSewerMHGateway(null);
                if (assetSewerMhGateway.USmhDsmhInUseForSections(assetIdUsmh, assetIdDsmh, companyId))
                {
                    args.IsValid = false;
                }
            }
        }



        protected void ddlUsmhShapeEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                mWizard2 master = (mWizard2)this.Master;
                ScriptManager scriptManager = (ScriptManager)master.FindControl("ScriptManager1");

                if (scriptManager.IsInAsyncPostBack)
                {
                    // cast DropDownList control which has initiated the call:
                    DropDownList ddlUsmhShape = (DropDownList)sender;

                    switch (ddlUsmhShape.SelectedValue)
                    {
                        case "Round":
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationRoundMHAdd")).Visible = true;
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationRectangularMHAdd")).Visible = false;
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationMixedMHAdd")).Visible = false;
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationOtherMHAdd")).Visible = false;
                            break;

                        case "Rectangular":
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationRoundMHAdd")).Visible = false;
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationRectangularMHAdd")).Visible = true;
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationMixedMHAdd")).Visible = false;
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationOtherMHAdd")).Visible = false;
                            break;

                        case "Mixed":
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationRoundMHAdd")).Visible = false;
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationRectangularMHAdd")).Visible = false;
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationMixedMHAdd")).Visible = true;
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationOtherMHAdd")).Visible = false;
                            break;


                        case "Other":
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationRoundMHAdd")).Visible = false;
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationRectangularMHAdd")).Visible = false;
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationMixedMHAdd")).Visible = false;
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationOtherMHAdd")).Visible = true;
                            break;

                        default:
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationRoundMHAdd")).Visible = false;
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationRectangularMHAdd")).Visible = false;
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationMixedMHAdd")).Visible = false;
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationOtherMHAdd")).Visible = false;
                            break;
                    };
                }
            }
            catch
            {
            }
        }



        protected void ddlDsmhShapeEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                mWizard2 master = (mWizard2)this.Master;
                ScriptManager scriptManager = (ScriptManager)master.FindControl("ScriptManager1");

                if (scriptManager.IsInAsyncPostBack)
                {
                    // cast DropDownList control which has initiated the call:
                    DropDownList ddlDsmhShape = (DropDownList)sender;

                    switch (ddlDsmhShape.SelectedValue)
                    {
                        case "Round":
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationRoundMHAdd")).Visible = true;
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationRectangularMHAdd")).Visible = false;
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationMixedMHAdd")).Visible = false;
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationOtherMHAdd")).Visible = false;
                            break;

                        case "Rectangular":
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationRoundMHAdd")).Visible = false;
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationRectangularMHAdd")).Visible = true;
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationMixedMHAdd")).Visible = false;
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationOtherMHAdd")).Visible = false;
                            break;

                        case "Mixed":
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationRoundMHAdd")).Visible = false;
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationRectangularMHAdd")).Visible = false;
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationMixedMHAdd")).Visible = true;
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationOtherMHAdd")).Visible = false;
                            break;


                        case "Other":
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationRoundMHAdd")).Visible = false;
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationRectangularMHAdd")).Visible = false;
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationMixedMHAdd")).Visible = false;
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationOtherMHAdd")).Visible = true;
                            break;

                        default:
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationRoundMHAdd")).Visible = false;
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationRectangularMHAdd")).Visible = false;
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationMixedMHAdd")).Visible = false;
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationOtherMHAdd")).Visible = false;
                            break;
                    };
                }
            }
            catch
            {
            }
        }



        protected void ddlUsmhShapeAdd_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                mWizard2 master = (mWizard2)this.Master;
                ScriptManager scriptManager = (ScriptManager)master.FindControl("ScriptManager1");

                if (scriptManager.IsInAsyncPostBack)
                {
                    // cast DropDownList control which has initiated the call:
                    DropDownList ddlUsmhShape = (DropDownList)sender;

                    switch (ddlUsmhShape.SelectedValue)
                    {
                        case "Round":
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationRoundMHAdd")).Visible = true;
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationRectangularMHAdd")).Visible = false;
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationMixedMHAdd")).Visible = false;
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationOtherMHAdd")).Visible = false;
                            break;

                        case "Rectangular":
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationRoundMHAdd")).Visible = false;
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationRectangularMHAdd")).Visible = true;
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationMixedMHAdd")).Visible = false;
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationOtherMHAdd")).Visible = false;
                            break;

                        case "Mixed":
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationRoundMHAdd")).Visible = false;
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationRectangularMHAdd")).Visible = false;
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationMixedMHAdd")).Visible = true;
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationOtherMHAdd")).Visible = false;
                            break;
                            
                        case "Other":
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationRoundMHAdd")).Visible = false;
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationRectangularMHAdd")).Visible = false;
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationMixedMHAdd")).Visible = false;
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationOtherMHAdd")).Visible = true;
                            break;

                        default:
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationRoundMHAdd")).Visible = false;
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationRectangularMHAdd")).Visible = false;
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationMixedMHAdd")).Visible = false;
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationOtherMHAdd")).Visible = false;
                            break;
                    };
                }
            }
            catch
            {
            }
        }



        protected void ddlDsmhShapeAdd_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                mWizard2 master = (mWizard2)this.Master;
                ScriptManager scriptManager = (ScriptManager)master.FindControl("ScriptManager1");

                if (scriptManager.IsInAsyncPostBack)
                {
                    // cast DropDownList control which has initiated the call:
                    DropDownList ddlDsmhShape = (DropDownList)sender;

                    switch (ddlDsmhShape.SelectedValue)
                    {
                        case "Round":
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationRoundMHAdd")).Visible = true;
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationRectangularMHAdd")).Visible = false;
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationMixedMHAdd")).Visible = false;
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationOtherMHAdd")).Visible = false;
                            break;

                        case "Rectangular":
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationRoundMHAdd")).Visible = false;
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationRectangularMHAdd")).Visible = true;
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationMixedMHAdd")).Visible = false;
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationOtherMHAdd")).Visible = false;
                            break;

                        case "Mixed":
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationRoundMHAdd")).Visible = false;
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationRectangularMHAdd")).Visible = false;
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationMixedMHAdd")).Visible = true;
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationOtherMHAdd")).Visible = false;
                            break;
                            
                        case "Other":
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationRoundMHAdd")).Visible = false;
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationRectangularMHAdd")).Visible = false;
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationMixedMHAdd")).Visible = false;
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationOtherMHAdd")).Visible = true;
                            break;

                        default:
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationRoundMHAdd")).Visible = false;
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationRectangularMHAdd")).Visible = false;
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationMixedMHAdd")).Visible = false;
                            //((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationOtherMHAdd")).Visible = false;
                            break;
                    };
                }
            }
            catch
            {
            }
        }



        protected void cvRehabilitationDataChimneyDiameterAdd_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Trim() != "")
            {
                // Initialize 
                CustomValidator cvRehabilitationDataChimneyDiameterAdd = (CustomValidator)source;
                GridViewRow gridRow = (GridViewRow)cvRehabilitationDataChimneyDiameterAdd.NamingContainer;

                string shapeAdd = ((DropDownList)gridRow.FindControl("ddlShapeAdd")).SelectedValue;

                args.IsValid = true;

                // Control of format
                if ((!Distance.IsValidDistance(args.Value)) && (shapeAdd == "Round"))
                {
                    cvRehabilitationDataChimneyDiameterAdd.Text = "Invalid format. (please use X'Y\", or X\", or Xft Yin, or X.Y, or X.Ym, or X.Ymm)";
                    args.IsValid = false;
                }

                // Control of distance > 0
                if ((args.IsValid) && (shapeAdd == "Round"))
                {
                    Distance distance = new Distance(args.Value);
                    if (distance.ToDoubleInEng3() < 0)
                    {
                        cvRehabilitationDataChimneyDiameterAdd.Text = "Invalid measurement. (must be equal or greater than 0)";
                        args.IsValid = false;
                    }
                }
            }
        }
        





        
        // ////////////////////////////////////////////////////////////////////////
        // STEP2 - NEW SECTION - METHODS
        //

        private void StepNewSectionsIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Please create new sections";

            // grid
            grdProjectAddSectionsNew.DataBind();
        }



        private bool StepNewSectionsNext()
        {
            // Update dataset
            ProjectAddSectionsTDS dataSet = new ProjectAddSectionsTDS();
            dataSet.ProjectAddSectionsNew.Merge(projectAddSectionsNew, true);
            ProjectAddSectionsNew model = new ProjectAddSectionsNew(dataSet);

            // Conditions Gridview, if the gridview is edition mode
            if (grdProjectAddSectionsNew.EditIndex >= 0)
            {
                grdProjectAddSectionsNew.UpdateRow(grdProjectAddSectionsNew.EditIndex, false);
            }
            
            if (ValidateProjectAddSectionsFooter())
            {
                Page.Validate("AddSectionsAdd");
                if (!Page.IsValid)
                {
                    return false;
                }
                else
                {
                    bool cbxRA = ((CheckBox)grdProjectAddSectionsNew.FooterRow.FindControl("cbxRehabAssessmentWorkAdd")).Checked;
                    bool cbxFLL = ((CheckBox)grdProjectAddSectionsNew.FooterRow.FindControl("cbxFullLengthLiningWorkAdd")).Checked;
                    bool cbxPR = ((CheckBox)grdProjectAddSectionsNew.FooterRow.FindControl("cbxPointRepairsWorkAdd")).Checked;
                    bool cbxJL = ((CheckBox)grdProjectAddSectionsNew.FooterRow.FindControl("cbxJunctionLiningWorkAdd")).Checked;

                    bool cbxMHRehabUsmh = ((CheckBox)grdProjectAddSectionsNew.FooterRow.FindControl("cbxMHRehabUsmhAdd")).Checked;
                    bool cbxMHRehabDsmh = ((CheckBox)grdProjectAddSectionsNew.FooterRow.FindControl("cbxMHRehabDsmhAdd")).Checked;

                    if (cbxRA || cbxFLL || cbxJL || cbxPR)
                    {
                        // Get values
                        int companyId = Int32.Parse(hdfCompanyId.Value);
                        string street = ((TextBox)grdProjectAddSectionsNew.FooterRow.FindControl("tbxStreetAdd")).Text;
                        string usmh = ((TextBox)grdProjectAddSectionsNew.FooterRow.FindControl("tbxUsmhAdd")).Text;
                        string dsmh = ((TextBox)grdProjectAddSectionsNew.FooterRow.FindControl("tbxDsmhAdd")).Text;
                        string mapSize = ((TextBox)grdProjectAddSectionsNew.FooterRow.FindControl("tbxMapSizeAdd")).Text;
                        string mapLength = ((TextBox)grdProjectAddSectionsNew.FooterRow.FindControl("tbxMapLengthAdd")).Text;

                        string clientId = "";
                        if (((TextBox)grdProjectAddSectionsNew.FooterRow.FindControl("tbxClientIdAdd")).Text.Trim() != "")
                        {
                            clientId = ((TextBox)grdProjectAddSectionsNew.FooterRow.FindControl("tbxClientIdAdd")).Text;
                        }

                        string sectionMaterial = "";
                        if (((DropDownList)grdProjectAddSectionsNew.FooterRow.FindControl("ddlSectionMaterialAdd")).SelectedValue != "-1")
                        {
                            sectionMaterial = ((DropDownList)grdProjectAddSectionsNew.FooterRow.FindControl("ddlSectionMaterialAdd")).SelectedValue;
                        }

                        string usmhStreet = ((TextBox)grdProjectAddSectionsNew.FooterRow.FindControl("tbxUsmhStreetAdd")).Text.Trim();
                        string usmhLatitude = ((TextBox)grdProjectAddSectionsNew.FooterRow.FindControl("tbxUsmhLatitudeAdd")).Text.Trim();
                        string usmhLongitude = ((TextBox)grdProjectAddSectionsNew.FooterRow.FindControl("tbxUsmhLongitudeAdd")).Text.Trim();
                        string usmhShape = ((DropDownList)grdProjectAddSectionsNew.FooterRow.FindControl("ddlUsmhShapeAdd")).SelectedValue;
                        string usmhLocation = ((DropDownList)grdProjectAddSectionsNew.FooterRow.FindControl("ddlUsmhLocationAdd")).SelectedValue;
                        int? usmhConditionRating = null;
                        if (((DropDownList)grdProjectAddSectionsNew.FooterRow.FindControl("ddlUsmhConditionRatingAdd")).SelectedValue != "-1")
                        {
                            usmhConditionRating = Int32.Parse(((DropDownList)grdProjectAddSectionsNew.FooterRow.FindControl("ddlUsmhConditionRatingAdd")).SelectedValue);
                        }
                        int? usmhMaterialId = null;
                        string usmhMaterial = "";
                        if (((DropDownList)grdProjectAddSectionsNew.FooterRow.FindControl("ddlUsmhMaterialAdd")).SelectedValue != "-1")
                        {
                            usmhMaterialId = Int32.Parse(((DropDownList)grdProjectAddSectionsNew.FooterRow.FindControl("ddlUsmhMaterialAdd")).SelectedValue);
                            AssetSewerMHMaterialTypeGateway assetSewerMHMaterialTypeGatewayForUsmh = new AssetSewerMHMaterialTypeGateway();
                            assetSewerMHMaterialTypeGatewayForUsmh.LoadByMaterialId((int)usmhMaterialId, companyId);
                            usmhMaterial = assetSewerMHMaterialTypeGatewayForUsmh.GetMaterialType((int)usmhMaterialId);
                        }

                        string dsmhStreet = ((TextBox)grdProjectAddSectionsNew.FooterRow.FindControl("tbxDsmhStreetAdd")).Text.Trim();
                        string dsmhLatitude = ((TextBox)grdProjectAddSectionsNew.FooterRow.FindControl("tbxDsmhLatitudeAdd")).Text.Trim();
                        string dsmhLongitude = ((TextBox)grdProjectAddSectionsNew.FooterRow.FindControl("tbxDsmhLongitudeAdd")).Text.Trim();
                        string dsmhShape = ((DropDownList)grdProjectAddSectionsNew.FooterRow.FindControl("ddlDsmhShapeAdd")).SelectedValue;
                        string dsmhLocation = ((DropDownList)grdProjectAddSectionsNew.FooterRow.FindControl("ddlDsmhLocationAdd")).SelectedValue;
                        int? dsmhConditionRating = null;
                        if (((DropDownList)grdProjectAddSectionsNew.FooterRow.FindControl("ddlDsmhConditionRatingAdd")).SelectedValue != "-1")
                        {
                            dsmhConditionRating = Int32.Parse(((DropDownList)grdProjectAddSectionsNew.FooterRow.FindControl("ddlDsmhConditionRatingAdd")).SelectedValue);
                        }
                        int? dsmhMaterialId = null;
                        string dsmhMaterial = "";
                        if (((DropDownList)grdProjectAddSectionsNew.FooterRow.FindControl("ddlDsmhMaterialAdd")).SelectedValue != "-1")
                        {
                            dsmhMaterialId = Int32.Parse(((DropDownList)grdProjectAddSectionsNew.FooterRow.FindControl("ddlDsmhMaterialAdd")).SelectedValue);
                            AssetSewerMHMaterialTypeGateway assetSewerMHMaterialTypeGatewayForDsmh = new AssetSewerMHMaterialTypeGateway();
                            assetSewerMHMaterialTypeGatewayForDsmh.LoadByMaterialId((int)dsmhMaterialId, companyId);
                            dsmhMaterial = assetSewerMHMaterialTypeGatewayForDsmh.GetMaterialType((int)dsmhMaterialId);
                        }

                        // ... get structure data
                        string usmhTopDiameter = "";
                        string usmhTopDepth = "";
                        string usmhDownDiameter = "";
                        string usmhDownDepth = "";
                        int? usmhManholeRugs = null;
                        string usmhRectangle1LongSide = "";
                        string usmhRectangle1ShortSide = "";
                        string usmhRectangle2LongSide = "";
                        string usmhRectangle2ShortSide = "";
                        string usmhTotalSurfaceArea = "";
                        string dsmhTopDiameter = "";
                        string dsmhTopDepth = "";
                        string dsmhDownDiameter = "";
                        string dsmhDownDepth = "";
                        int? dsmhManholeRugs = null;
                        string dsmhRectangle1LongSide = "";
                        string dsmhRectangle1ShortSide = "";
                        string dsmhRectangle2LongSide = "";
                        string dsmhRectangle2ShortSide = "";
                        string dsmhTotalSurfaceArea = "";

                        int sectionId = model.Table.Rows.Count + 1;

                        // Insert section
                        if ((street != "") || (usmh != "") || (dsmh != "") || (mapSize != "") || (mapLength != ""))
                        {
                            model.Insert(sectionId.ToString(), street, usmh, dsmh, cbxRA, cbxFLL, cbxPR, cbxJL, false, sectionId.ToString(), mapSize, mapLength, usmhStreet, usmhLatitude, usmhLongitude, usmhShape, usmhLocation, usmhConditionRating, usmhMaterialId, usmhMaterial, usmhTopDiameter, usmhTopDepth, usmhDownDiameter, usmhDownDepth, usmhManholeRugs, usmhRectangle1LongSide, usmhRectangle1ShortSide, usmhRectangle2LongSide, usmhRectangle2ShortSide, usmhTotalSurfaceArea, dsmhStreet, dsmhLatitude, dsmhLongitude, dsmhShape, dsmhLocation, dsmhConditionRating, dsmhMaterialId, dsmhMaterial, dsmhTopDiameter, dsmhTopDepth, dsmhDownDiameter, dsmhDownDepth, dsmhManholeRugs, dsmhRectangle1LongSide, dsmhRectangle1ShortSide, dsmhRectangle2LongSide, dsmhRectangle2ShortSide, dsmhTotalSurfaceArea, sectionMaterial, clientId, cbxMHRehabUsmh, cbxMHRehabDsmh);
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            // create dataset for temp
            dataSet.ProjectAddSectionsTemp.Merge(projectAddSectionsTemp, true);

            // process new sections
            ProjectAddSectionsTemp modelTemp = new ProjectAddSectionsTemp(dataSet);
            modelTemp.ProcessNew();

            // get changes
            projectAddSectionsNew.Rows.Clear();
            projectAddSectionsTemp.Rows.Clear();
            projectAddSectionsTemp.Merge(modelTemp.Table);

            // store tables
            Session.Remove("projectAddSectionsNewDummy");
            Session["projectAddSectionsNew"] = projectAddSectionsNew;
            Session["projectAddSectionsTemp"] = projectAddSectionsTemp;

            return true;
        }



        private bool StepNewSectionsPrevious()
        {
            return true;
        }



        private bool ValidateProjectAddSectionsFooter()
        {
            string street = ((TextBox)grdProjectAddSectionsNew.FooterRow.FindControl("tbxStreetAdd")).Text;            
            string usmh = ((TextBox)grdProjectAddSectionsNew.FooterRow.FindControl("tbxUsmhAdd")).Text;            
            string dsmh = ((TextBox)grdProjectAddSectionsNew.FooterRow.FindControl("tbxDsmhAdd")).Text;            
            string usmhStreet = ((TextBox)grdProjectAddSectionsNew.FooterRow.FindControl("tbxUsmhStreetAdd")).Text.Trim();
            string usmhLatitude = ((TextBox)grdProjectAddSectionsNew.FooterRow.FindControl("tbxUsmhLatitudeAdd")).Text.Trim();
            string usmhLongitude = ((TextBox)grdProjectAddSectionsNew.FooterRow.FindControl("tbxUsmhLongitudeAdd")).Text.Trim();
            string usmhShape = ((DropDownList)grdProjectAddSectionsNew.FooterRow.FindControl("ddlUsmhShapeAdd")).SelectedValue;
            string usmhLocation = ((DropDownList)grdProjectAddSectionsNew.FooterRow.FindControl("ddlUsmhLocationAdd")).SelectedValue;
            int? usmhConditionRating = null;
            if (((DropDownList)grdProjectAddSectionsNew.FooterRow.FindControl("ddlUsmhConditionRatingAdd")).SelectedValue != "-1")
            {
                usmhConditionRating = Int32.Parse(((DropDownList)grdProjectAddSectionsNew.FooterRow.FindControl("ddlUsmhConditionRatingAdd")).SelectedValue);
            }
            int? usmhMaterialId = null;
            string usmhMaterial = "";
            if (((DropDownList)grdProjectAddSectionsNew.FooterRow.FindControl("ddlUsmhMaterialAdd")).SelectedValue != "-1")
            {
                usmhMaterialId = Int32.Parse(((DropDownList)grdProjectAddSectionsNew.FooterRow.FindControl("ddlUsmhMaterialAdd")).SelectedValue);
                AssetSewerMHMaterialTypeGateway assetSewerMHMaterialTypeGatewayForUsmh = new AssetSewerMHMaterialTypeGateway();
                assetSewerMHMaterialTypeGatewayForUsmh.LoadByMaterialId((int)usmhMaterialId, Int32.Parse(hdfCompanyId.Value));
                usmhMaterial = assetSewerMHMaterialTypeGatewayForUsmh.GetMaterialType((int)usmhMaterialId);
            }

            string dsmhStreet = ((TextBox)grdProjectAddSectionsNew.FooterRow.FindControl("tbxDsmhStreetAdd")).Text.Trim();
            string dsmhLatitude = ((TextBox)grdProjectAddSectionsNew.FooterRow.FindControl("tbxDsmhLatitudeAdd")).Text.Trim();
            string dsmhLongitude = ((TextBox)grdProjectAddSectionsNew.FooterRow.FindControl("tbxDsmhLongitudeAdd")).Text.Trim();
            string dsmhShape = ((DropDownList)grdProjectAddSectionsNew.FooterRow.FindControl("ddlDsmhShapeAdd")).SelectedValue;
            string dsmhLocation = ((DropDownList)grdProjectAddSectionsNew.FooterRow.FindControl("ddlDsmhLocationAdd")).SelectedValue;
            int? dsmhConditionRating = null;
            if (((DropDownList)grdProjectAddSectionsNew.FooterRow.FindControl("ddlDsmhConditionRatingAdd")).SelectedValue != "-1")
            {
                dsmhConditionRating = Int32.Parse(((DropDownList)grdProjectAddSectionsNew.FooterRow.FindControl("ddlDsmhConditionRatingAdd")).SelectedValue);
            }
            int? dsmhMaterialId = null;
            string dsmhMaterial = "";
            if (((DropDownList)grdProjectAddSectionsNew.FooterRow.FindControl("ddlDsmhMaterialAdd")).SelectedValue != "-1")
            {
                dsmhMaterialId = Int32.Parse(((DropDownList)grdProjectAddSectionsNew.FooterRow.FindControl("ddlDsmhMaterialAdd")).SelectedValue);
                AssetSewerMHMaterialTypeGateway assetSewerMHMaterialTypeGatewayForDsmh = new AssetSewerMHMaterialTypeGateway();
                assetSewerMHMaterialTypeGatewayForDsmh.LoadByMaterialId((int)dsmhMaterialId, Int32.Parse(hdfCompanyId.Value));
                dsmhMaterial = assetSewerMHMaterialTypeGatewayForDsmh.GetMaterialType((int)dsmhMaterialId);
            }           

            if ((street != "") || (usmh != "") || (dsmh != "") || (usmhStreet != "") || (usmhLatitude != "") || (usmhLongitude != "") || (usmhShape != "") || (usmhLocation != "") || (usmhConditionRating != null) || (usmhMaterial != "") || (dsmhStreet != "") || (dsmhLatitude != "") || (dsmhLongitude != "") || (dsmhShape != "") || (dsmhLocation != "") || (dsmhConditionRating != null) || (dsmhMaterial != ""))
            {
                return true;
            }

            return false;
        }



        private void GrdProjectAddSectionsNewAdd()
        {
            if (ValidateProjectAddSectionsFooter())
            {
                Page.Validate("AddSectionsAdd");
                if (Page.IsValid)
                {
                    // Get values
                    int companyId = Int32.Parse(hdfCompanyId.Value);
                    string street = ((TextBox)grdProjectAddSectionsNew.FooterRow.FindControl("tbxStreetAdd")).Text;
                    string usmh = ((TextBox)grdProjectAddSectionsNew.FooterRow.FindControl("tbxUsmhAdd")).Text;
                    string dsmh = ((TextBox)grdProjectAddSectionsNew.FooterRow.FindControl("tbxDsmhAdd")).Text;
                    string mapSize = ((TextBox)grdProjectAddSectionsNew.FooterRow.FindControl("tbxMapSizeAdd")).Text;
                    string mapLength = ((TextBox)grdProjectAddSectionsNew.FooterRow.FindControl("tbxMapLengthAdd")).Text;

                    string clientId = "";
                    if (((TextBox)grdProjectAddSectionsNew.FooterRow.FindControl("tbxClientIdAdd")).Text.Trim() != "")
                    {
                        clientId = ((TextBox)grdProjectAddSectionsNew.FooterRow.FindControl("tbxClientIdAdd")).Text;
                    }

                    string sectionMaterial = "";
                    if (((DropDownList)grdProjectAddSectionsNew.FooterRow.FindControl("ddlSectionMaterialAdd")).SelectedValue != "-1")
                    {
                        sectionMaterial = ((DropDownList)grdProjectAddSectionsNew.FooterRow.FindControl("ddlSectionMaterialAdd")).SelectedValue;
                    }
                    
                    bool cbxRA = ((CheckBox)grdProjectAddSectionsNew.FooterRow.FindControl("cbxRehabAssessmentWorkAdd")).Checked;
                    bool cbxFLL = ((CheckBox)grdProjectAddSectionsNew.FooterRow.FindControl("cbxFullLengthLiningWorkAdd")).Checked;
                    bool cbxPR = ((CheckBox)grdProjectAddSectionsNew.FooterRow.FindControl("cbxPointRepairsWorkAdd")).Checked;
                    bool cbxJL = ((CheckBox)grdProjectAddSectionsNew.FooterRow.FindControl("cbxJunctionLiningWorkAdd")).Checked;

                    bool cbxMHRehabUsmh = ((CheckBox)grdProjectAddSectionsNew.FooterRow.FindControl("cbxMHRehabUsmhAdd")).Checked;
                    bool cbxMHRehabDsmh = ((CheckBox)grdProjectAddSectionsNew.FooterRow.FindControl("cbxMHRehabDsmhAdd")).Checked;

                    string usmhStreet = ((TextBox)grdProjectAddSectionsNew.FooterRow.FindControl("tbxUsmhStreetAdd")).Text.Trim();
                    string usmhLatitude = ((TextBox)grdProjectAddSectionsNew.FooterRow.FindControl("tbxUsmhLatitudeAdd")).Text.Trim();
                    string usmhLongitude = ((TextBox)grdProjectAddSectionsNew.FooterRow.FindControl("tbxUsmhLongitudeAdd")).Text.Trim();
                    string usmhShape = ((DropDownList)grdProjectAddSectionsNew.FooterRow.FindControl("ddlUsmhShapeAdd")).SelectedValue;
                    string usmhLocation = ((DropDownList)grdProjectAddSectionsNew.FooterRow.FindControl("ddlUsmhLocationAdd")).SelectedValue;
                    int? usmhConditionRating = null;
                    if (((DropDownList)grdProjectAddSectionsNew.FooterRow.FindControl("ddlUsmhConditionRatingAdd")).SelectedValue != "-1")
                    {
                        usmhConditionRating = Int32.Parse(((DropDownList)grdProjectAddSectionsNew.FooterRow.FindControl("ddlUsmhConditionRatingAdd")).SelectedValue);
                    }
                    int? usmhMaterialId = null;
                    string usmhMaterial = "";
                    if (((DropDownList)grdProjectAddSectionsNew.FooterRow.FindControl("ddlUsmhMaterialAdd")).SelectedValue != "-1")
                    {
                        usmhMaterialId = Int32.Parse(((DropDownList)grdProjectAddSectionsNew.FooterRow.FindControl("ddlUsmhMaterialAdd")).SelectedValue);
                        AssetSewerMHMaterialTypeGateway assetSewerMHMaterialTypeGatewayForUsmh = new AssetSewerMHMaterialTypeGateway();
                        assetSewerMHMaterialTypeGatewayForUsmh.LoadByMaterialId((int)usmhMaterialId, companyId);
                        usmhMaterial = assetSewerMHMaterialTypeGatewayForUsmh.GetMaterialType((int)usmhMaterialId);
                    }

                    string dsmhStreet = ((TextBox)grdProjectAddSectionsNew.FooterRow.FindControl("tbxDsmhStreetAdd")).Text.Trim();
                    string dsmhLatitude = ((TextBox)grdProjectAddSectionsNew.FooterRow.FindControl("tbxDsmhLatitudeAdd")).Text.Trim();
                    string dsmhLongitude = ((TextBox)grdProjectAddSectionsNew.FooterRow.FindControl("tbxDsmhLongitudeAdd")).Text.Trim();
                    string dsmhShape = ((DropDownList)grdProjectAddSectionsNew.FooterRow.FindControl("ddlDsmhShapeAdd")).SelectedValue;
                    string dsmhLocation = ((DropDownList)grdProjectAddSectionsNew.FooterRow.FindControl("ddlDsmhLocationAdd")).SelectedValue;
                    int? dsmhConditionRating = null;
                    if (((DropDownList)grdProjectAddSectionsNew.FooterRow.FindControl("ddlDsmhConditionRatingAdd")).SelectedValue != "-1")
                    {
                        dsmhConditionRating = Int32.Parse(((DropDownList)grdProjectAddSectionsNew.FooterRow.FindControl("ddlDsmhConditionRatingAdd")).SelectedValue);
                    }
                    int? dsmhMaterialId = null;
                    string dsmhMaterial = "";
                    if (((DropDownList)grdProjectAddSectionsNew.FooterRow.FindControl("ddlDsmhMaterialAdd")).SelectedValue != "-1")
                    {
                        dsmhMaterialId = Int32.Parse(((DropDownList)grdProjectAddSectionsNew.FooterRow.FindControl("ddlDsmhMaterialAdd")).SelectedValue);
                        AssetSewerMHMaterialTypeGateway assetSewerMHMaterialTypeGatewayForDsmh = new AssetSewerMHMaterialTypeGateway();
                        assetSewerMHMaterialTypeGatewayForDsmh.LoadByMaterialId((int)dsmhMaterialId, companyId);
                        dsmhMaterial = assetSewerMHMaterialTypeGatewayForDsmh.GetMaterialType((int)dsmhMaterialId);
                    }                   

                    // ... get structure data
                    string usmhTopDiameter = "";
                    string usmhTopDepth = "";
                    string usmhDownDiameter = "";
                    string usmhDownDepth = "";
                    int? usmhManholeRugs = null;
                    string usmhRectangle1LongSide = "";
                    string usmhRectangle1ShortSide = "";
                    string usmhRectangle2LongSide = "";
                    string usmhRectangle2ShortSide = "";
                    string usmhTotalSurfaceArea = "";
                    string dsmhTopDiameter = "";
                    string dsmhTopDepth = "";
                    string dsmhDownDiameter = "";
                    string dsmhDownDepth = "";
                    int? dsmhManholeRugs = null;
                    string dsmhRectangle1LongSide = "";
                    string dsmhRectangle1ShortSide = "";
                    string dsmhRectangle2LongSide = "";
                    string dsmhRectangle2ShortSide = "";
                    string dsmhTotalSurfaceArea = "";

                    // Update datasets
                    ProjectAddSectionsTDS dataSet = new ProjectAddSectionsTDS();
                    dataSet.ProjectAddSectionsNew.Merge(projectAddSectionsNew, true);
                    ProjectAddSectionsNew model = new ProjectAddSectionsNew(dataSet);
                    int sectionId = model.Table.Rows.Count + 1;

                    // Insert section
                    model.Insert(sectionId.ToString(), street, usmh, dsmh, cbxRA, cbxFLL, cbxPR, cbxJL, false, sectionId.ToString(), mapSize, mapLength, usmhStreet, usmhLatitude, usmhLongitude, usmhShape, usmhLocation, usmhConditionRating, usmhMaterialId, usmhMaterial, usmhTopDiameter, usmhTopDepth, usmhDownDiameter, usmhDownDepth, usmhManholeRugs, usmhRectangle1LongSide, usmhRectangle1ShortSide, usmhRectangle2LongSide, usmhRectangle2ShortSide, usmhTotalSurfaceArea, dsmhStreet, dsmhLatitude, dsmhLongitude, dsmhShape, dsmhLocation, dsmhConditionRating, dsmhMaterialId, dsmhMaterial, dsmhTopDiameter, dsmhTopDepth, dsmhDownDiameter, dsmhDownDepth, dsmhManholeRugs, dsmhRectangle1LongSide, dsmhRectangle1ShortSide, dsmhRectangle2LongSide, dsmhRectangle2ShortSide, dsmhTotalSurfaceArea, sectionMaterial, clientId, cbxMHRehabUsmh, cbxMHRehabDsmh);

                    // Store data
                    Session.Remove("projectAddSectionsNewDummy");
                    Session["projectAddSectionsNew"] = dataSet.ProjectAddSectionsNew;

                    grdProjectAddSectionsNew.DataBind();

                    grdProjectAddSectionsNew.PageIndex = grdProjectAddSectionsNew.PageCount - 1;
                }
            }
        }



        public ProjectAddSectionsTDS.ProjectAddSectionsNewDataTable GetProjectAddSectionsNew()
        {
            projectAddSectionsNew = (ProjectAddSectionsTDS.ProjectAddSectionsNewDataTable)Session["projectAddSectionsNewDummy"];
            if (projectAddSectionsNew == null)
            {
                projectAddSectionsNew = (ProjectAddSectionsTDS.ProjectAddSectionsNewDataTable)Session["projectAddSectionsNew"];
            }
            
            return projectAddSectionsNew;
        }



        public void DummyProjectAddSectionsNew(int ID)
        {
        }



        protected void ProjectAddSectionsNewEmptyFix(GridView grdView)
        {
            if (grdView.Rows.Count == 0)
            {
                ProjectAddSectionsTDS.ProjectAddSectionsNewDataTable dt = new ProjectAddSectionsTDS.ProjectAddSectionsNewDataTable();
                dt.AddProjectAddSectionsNewRow(-1, "", "", "", "", false, false, false, false, "", "", "", false, "", "", "", "","", -1, "", "","","", "", -1, "", "","","","","","","","","",-1, "","","","","",-1,"","","","","", -1, -1, "", "", false, false);
                Session["projectAddSectionsNewDummy"] = dt;

                grdView.DataBind();
            }

            // normally executes at all postbacks
            if (grdView.Rows.Count == 1)
            {
                ProjectAddSectionsTDS.ProjectAddSectionsNewDataTable dt = (ProjectAddSectionsTDS.ProjectAddSectionsNewDataTable)Session["projectAddSectionsNewDummy"];
                if (dt != null)
                {
                    // hide row
                    grdView.Rows[0].Visible = false;
                    grdView.Rows[0].Controls.Clear();
                }
            }
        }




        #endregion






        #region STEP3 - SEARCH INTERMEDIATE SECTIONS

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP3 - SEARCH INTERMEDIATE SECTIONS
        //


        // ////////////////////////////////////////////////////////////////////////
        // STEP3 - SEARCH INTERMEDIATE SECTIONS - METHODS
        //

        private void StepSearchIntermediateSectionsIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Please search the section (within " +  hdfSearchTitle.Value + ") after which you would like to insert the intermediate one.";
            tbxForIntermediateSearchSectionId.Text = "%";
            tbxForIntermediateSearchStreet.Text = "%";
            tbxForIntermediateSearchUsmh.Text = "%";
            tbxForIntermediateSearchDsmh.Text = "%";
            tbxForIntermediateSearchMapSize.Text = "%";
            tbxForIntermediateSearchMapLength.Text = "%";
        }



        private bool StepSearchIntermediateSectionsNext()
        {
            // Get where clause and order by clause
            string whereClause = GetIntermediateWhereClause();

            string orderByClause = GetIntermediateOderByClause();

            // Search
            ProjectAddSectionsTDS dataSet = new ProjectAddSectionsTDS();
            dataSet.ProjectAddSectionsSearch.Merge(projectAddSectionsSearch, true);
            ProjectAddSectionsSearch model = new ProjectAddSectionsSearch(dataSet);

            model.Load(whereClause, orderByClause);

            // Store tables
            projectAddSectionsSearch = (ProjectAddSectionsTDS.ProjectAddSectionsSearchDataTable)model.Table;
            Session["projectAddSectionsSearch"] = projectAddSectionsSearch;

            return true;
        }



        private bool StepSearchIntermediateSectionsPrevious()
        {
            return true;
        }



        private string GetIntermediateWhereClause()
        {
            // general conditions
            string whereClause = string.Format("(Deleted = 0) AND (COMPANY_ID = {0}) ", hdfCompanyId.Value);

            // search conditions
            // ... SectionID field
            if (tbxForIntermediateSearchSectionId.Text.Trim() == "")
            {
                whereClause += string.Format(" AND (SectionID IS NULL) ");
            }
            else
            {
                if (tbxForIntermediateSearchSectionId.Text.Trim() == "%")
                {
                    whereClause += string.Format(" AND ((SectionID IS NULL) OR (SectionID IS NOT NULL)) ");
                }
                else
                {
                    whereClause += string.Format(" AND (SectionID LIKE '%{0}%') ", tbxForIntermediateSearchSectionId.Text.Trim());
                }
            }


            // ... Street field
            if (tbxForIntermediateSearchStreet.Text.Trim() == "")
            {
                whereClause += string.Format(" AND (Street IS NULL) ");
            }
            else
            {
                if (tbxForIntermediateSearchStreet.Text.Trim() == "%")
                {
                    whereClause += string.Format(" AND ((Street IS NULL) OR (Street IS NOT NULL)) ");
                }
                else
                {
                    whereClause += string.Format(" AND (Street LIKE '%{0}%') ", tbxForIntermediateSearchStreet.Text.Trim());
                }
            }

            // ... USMH field
            if (tbxForIntermediateSearchUsmh.Text.Trim() == "")
            {
                whereClause += string.Format(" AND (USMH IS NULL) ");
            }
            else
            {
                if (tbxForIntermediateSearchUsmh.Text.Trim() == "%")
                {
                    whereClause += string.Format(" AND ((USMH IS NULL) OR (USMH IS NOT NULL)) ");
                }
                else
                {
                    whereClause += string.Format(" AND (USMH LIKE '%{0}%') ", tbxForIntermediateSearchUsmh.Text.Trim());
                }
            }

            // ... DSMH field
            if (tbxForIntermediateSearchDsmh.Text.Trim() == "")
            {
                whereClause += string.Format(" AND (DSMH IS NULL) ");
            }
            else
            {
                if (tbxForIntermediateSearchDsmh.Text.Trim() == "%")
                {
                    whereClause += string.Format(" AND ((DSMH IS NULL) OR (DSMH IS NOT NULL)) ");
                }
                else
                {
                    whereClause += string.Format(" AND (DSMH LIKE '%{0}%') ", tbxForIntermediateSearchDsmh.Text.Trim());
                }
            }

            // ... Map Size field
            if (tbxForIntermediateSearchMapSize.Text.Trim() == "")
            {
                whereClause += string.Format(" AND (MapSize IS NULL) ");
            }
            else
            {
                if (tbxForIntermediateSearchMapSize.Text.Trim() == "%")
                {
                    whereClause += string.Format(" AND ((MapSize IS NULL) OR (MapSize IS NOT NULL)) ");
                }
                else
                {
                    whereClause += string.Format(" AND (MapSize LIKE '%{0}%') ", tbxForIntermediateSearchMapSize.Text.Trim());
                }
            }

            // ... Map Length field
            if (tbxForIntermediateSearchMapLength.Text.Trim() == "")
            {
                whereClause += string.Format(" AND (MapLength IS NULL) ");
            }
            else
            {
                if (tbxForIntermediateSearchMapLength.Text.Trim() == "%")
                {
                    whereClause += string.Format(" AND ((MapLength IS NULL) OR (MapLength IS NOT NULL)) ");
                }
                else
                {
                    whereClause += string.Format(" AND (MapLength LIKE '%{0}%') ", tbxForIntermediateSearchMapLength.Text.Trim());
                }
            }

            // location conditions
            if (hdfCountryId.Value != "")
            {
                whereClause += string.Format(" AND (CountryID = {0}) ", hdfCountryId.Value);
            }
            if (hdfProvinceId.Value != "")
            {
                whereClause += string.Format(" AND (ProvinceID = {0}) ", hdfProvinceId.Value);
            }
            if (hdfCountyId.Value != "")
            {
                whereClause += string.Format(" AND (CountyID = {0}) ", hdfCountyId.Value);
            }
            if (hdfCityId.Value != "")
            {
                whereClause += string.Format(" AND (CityID = {0}) ", hdfCityId.Value);
            }

            // project & work conditions
            return whereClause;
        }



        private string GetIntermediateOderByClause()
        {
            string orderByClause = "AssetID";

            return orderByClause;
        }


        #endregion






        #region STEP4 - SELECT FOR INTERMEDIATE SECTIONS

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP4 - SELECT FOR INTERMEDIATE SECTIONS
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP4 - SELECT FOR INTERMEDIATE SECTIONS - EVENTS
        //

        protected void grdSelectForIntermediateSectionsSearch_DataBound(object sender, EventArgs e)
        {
            IntermediateSectionsSearchEmptyFix(grdSelectForIntermediateSectionsSearch);
        }



        protected void grdSelectForIntermediateSectionsSearch_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            StepSelectForIntermediateSectionsProcessGrid();
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP4 - SELECT FOR INTERMEDIATE SECTIONS - AUXILIAR EVENTS
        //

        protected void cvGrdSelectForIntermediateSections_ServerValidate(object source, ServerValidateEventArgs args)
        {
            CustomValidator cvSelectedSections = (CustomValidator)source;
            args.IsValid = false;

            if (grdSelectForIntermediateSectionsSearch.Rows.Count > 0)
            {
                foreach (GridViewRow row in grdSelectForIntermediateSectionsSearch.Rows)
                {
                    if (((CheckBox)row.FindControl("cbxSelected_")).Checked)
                    {
                        args.IsValid = true;
                    }
                }

                if (!args.IsValid)
                {
                    cvSelectedSections.ErrorMessage = "At least one section must be selected.";
                }
            }
        }


        



        // ////////////////////////////////////////////////////////////////////////
        // STEP4 - SELECT FOR INTERMEDIATE SECTIONS - METHODS
        //

        private void StepSelectForIntermediateSectionsIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Please select the section after which you would like to insert the intermediate one.";
            grdSelectForIntermediateSectionsSearch.DataBind();
        }



        private bool StepSelectForIntermediateSectionsNext()
        {
            ProjectAddSectionsTDS dataSet = new ProjectAddSectionsTDS();
            dataSet.ProjectAddSectionsSearch.Merge(projectAddSectionsSearch, true);
            ProjectAddSectionsSearch model = new ProjectAddSectionsSearch(dataSet);

            if (model.Table.Rows.Count > 0)
            {
                Page.Validate("selectForIntermediateSection");
                if (Page.IsValid)
                {
                    StepSelectForIntermediateSectionsProcessGrid();

                    if (Session["projectAddSectionsSearchDummy"] == null)
                    {
                        foreach (GridViewRow row in grdSelectForIntermediateSectionsSearch.Rows)
                        {
                            string sectionId = ((Label)row.FindControl("lblSectionID_")).Text.Trim();
                            bool selected = ((CheckBox)row.FindControl("cbxSelected_")).Checked;
                            if (selected)
                            {
                                hdfPrimarySectionId.Value = sectionId;
                            }
                        }
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }



        private bool StepSelectForIntermediateSectionsPrevious()
        {
            return true;
        }



        private void StepSelectForIntermediateSectionsProcessGrid()
        {
            ProjectAddSectionsTDS dataSet = new ProjectAddSectionsTDS();
            dataSet.ProjectAddSectionsSearch.Merge(projectAddSectionsSearch, true);
            ProjectAddSectionsSearch model = new ProjectAddSectionsSearch(dataSet);

            // update rows
            if (Session["projectAddSectionsSearchDummy"] == null)
            {
                foreach (GridViewRow row in grdSelectForIntermediateSectionsSearch.Rows)
                {
                    string sectionId = ((Label)row.FindControl("lblSectionID_")).Text.Trim();
                    bool selected = ((CheckBox)row.FindControl("cbxSelected_")).Checked;

                    model.UpdateBySectionId(sectionId, false, false, false, false, selected, false, false, false, false);
                }

                model.Table.AcceptChanges();

                projectAddSectionsSearch = (ProjectAddSectionsTDS.ProjectAddSectionsSearchDataTable)model.Table;
                Session["projectAddSectionsSearch"] = projectAddSectionsSearch;
            }
        }



        protected void IntermediateSectionsSearchEmptyFix(GridView grdView)
        {
            if (grdView.Rows.Count == 0)
            {
                ProjectAddSectionsTDS.ProjectAddSectionsSearchDataTable dt = new ProjectAddSectionsTDS.ProjectAddSectionsSearchDataTable();
                dt.AddProjectAddSectionsSearchRow(0, "", "", "", "", false, false, false, false, false, "", "", "", false, false, false, false, false);
                Session["projectAddSectionsSearchDummy"] = dt;

                grdView.DataBind();
            }

            // normally executes at all postbacks
            if (grdView.Rows.Count == 1)
            {
                ProjectAddSectionsTDS.ProjectAddSectionsSearchDataTable dt = (ProjectAddSectionsTDS.ProjectAddSectionsSearchDataTable)Session["projectAddSectionsSearchDummy"];
                if (dt != null)
                {
                    // hide row
                    grdView.Rows[0].Visible = false;
                    grdView.Rows[0].Controls.Clear();
                }
            }
        }

        #endregion






        #region STEP5 - NEW INTERMEDIATE SECTIONS

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP5 - NEW INTERMEDIATE SECTIONS
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP5 - NEW INTERMEDIATE SECTIONS - METHODS
        //

        private void StepNewIntermediateSectionsIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Please provide data for the new intermediate section.";
            
            // SectionID
            GenerateSubSectionId();
            ddlNewIntermediateSectionId.SelectedIndex = 0;

            // autocomplete
            string provinceId = "0"; if (hdfProvinceId.Value != "") provinceId = hdfProvinceId.Value;
            string countyId = "0"; if (hdfCountyId.Value != "") countyId = hdfCountyId.Value;
            string cityId = "0"; if (hdfCityId.Value != "") cityId = hdfCityId.Value;

            aceIntermediateUsmh.ContextKey = hdfCountryId.Value + "," + provinceId + "," + countyId + "," + cityId + "," + hdfCompanyId.Value;
            aceIntermediateDsmh.ContextKey = hdfCountryId.Value + "," + provinceId + "," + countyId + "," + cityId + "," + hdfCompanyId.Value;
        }



        private bool StepNewIntermediateSectionsNext()
        {
            Page.Validate("intermediateData");
            if (Page.IsValid)
            {
                // Saving new data
                string secuentialPart = ddlNewIntermediateSectionId.SelectedValue.ToString();
                string street = tbxNewIntermediateStreet.Text.Trim();
                string usmh = tbxNewIntermediateUsmh.Text.Trim();
                string dsmh = tbxNewIntermediateDsmh.Text.Trim();
                string mapSize = tbxNewIntermediateMapSize.Text.Trim();
                string mapLength = tbxNewIntermediateMapLength.Text.Trim();

                ProjectAddSectionsTDS dataSet = new ProjectAddSectionsTDS();
                dataSet.ProjectAddSectionsNew.Merge(projectAddSectionsNew, true);
                ProjectAddSectionsNew intermediateData = new ProjectAddSectionsNew(dataSet);

                // ... Insert section
                string countryId = "0"; if (hdfCountryId.Value != "") countryId = hdfCountryId.Value;
                string provinceId = "0"; if (hdfProvinceId.Value != "") provinceId = hdfProvinceId.Value;
                string countyId = "0"; if (hdfCountyId.Value != "") countyId = hdfCountyId.Value;
                string cityId = "0"; if (hdfCityId.Value != "") cityId = hdfCityId.Value;

                string sectionId = countryId + "." + provinceId + "." + countyId + "." + cityId;
                sectionId = sectionId + "-" + secuentialPart;

                string flowOrderId = sectionId.Substring(sectionId.Length - 6, 6);

                bool rehabAssesswork = false; if (hdfWorkType.Value == "Rehab Assessment") rehabAssesswork = true;
                bool fullLengthLiningWork = false; if (hdfWorkType.Value == "Full Length Lining") fullLengthLiningWork = true;
                bool pointRepairsWork = false; if (hdfWorkType.Value == "Point Repairs") pointRepairsWork = true;
                bool junctionLiningWork = false; if (hdfWorkType.Value == "Junction Lining") junctionLiningWork = true;

                intermediateData.Insert(sectionId, street, usmh, dsmh, rehabAssesswork, fullLengthLiningWork, pointRepairsWork, junctionLiningWork, false, flowOrderId, mapSize, mapLength, "", "", "", "", "", null, null, "", "", "", "", "", null, "", "", "", "", "", "", "", "", "", "", null, null, "", "", "", "", "", null, "", "", "", "", "", "", "", false, false);

                // create temp dataset
                dataSet.ProjectAddSectionsTemp.Merge(projectAddSectionsTemp, true);

                // process new sections
                ProjectAddSectionsTemp model = new ProjectAddSectionsTemp(dataSet);
                model.ProcessNew();

                // get changes
                projectAddSectionsNew.Rows.Clear();
                projectAddSectionsTemp.Rows.Clear();
                projectAddSectionsTemp.Merge(model.Table);

                // store tables
                Session.Remove("projectAddSectionsNewDummy");
                Session["projectAddSectionsNew"] = projectAddSectionsNew;
                Session["projectAddSectionsTemp"] = projectAddSectionsTemp;
                return true;

            }
            return false;
        }



        private bool StepNewIntermediateSectionsPrevious()
        {
            return true;
        }



        private void GenerateSubSectionId()
        {
            string primarySectionId = hdfPrimarySectionId.Value;
            string[] secuentialPart = primarySectionId.Split('-');

            // For  primary sections
            if (secuentialPart.Length == 2)
            {
                for (int i = 1; i < 10; i++)
                {
                    ddlNewIntermediateSectionId.Items.Add(new ListItem(secuentialPart[1] + "-" + i, secuentialPart[1] + "-" + i));
                    ddlNewIntermediateSectionId.Items.Add(new ListItem(secuentialPart[1] + "-" + i + "5", secuentialPart[1] + "-" + i + "5"));
                }
            }
            else
            {
                // ... For intermediate sections
                //string[] intermediateSectionIdSecuentialPart = secuentialPart[1].Split('-');
                int secuentialNumber = Int32.Parse(secuentialPart[2]);
                int fistDigit = secuentialNumber;
                if (secuentialNumber.ToString().Length == 2)
                {
                    fistDigit = Int32.Parse(secuentialNumber.ToString().Substring(0, 1));
                }

                // ... Complete series for id
                if (secuentialNumber.ToString().Length == 1)
                {
                    ddlNewIntermediateSectionId.Items.Add(new ListItem(secuentialPart[1] + "-" + fistDigit + "5", secuentialPart[1] + "-" + fistDigit + "5"));
                }

                // ... Complete next ids
                for (int i = fistDigit+1; i < 10; i++)
                {
                    ddlNewIntermediateSectionId.Items.Add(new ListItem(secuentialPart[1] + "-" + i, secuentialPart[1] + "-" + i));
                    ddlNewIntermediateSectionId.Items.Add(new ListItem(secuentialPart[1] + "-" + i + "5", secuentialPart[1] + "-" + i + "5"));                  
                }
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP5 - NEW INTERMEDIATE SECTIONS - AUXILIARY EVENTS
        //
        
        protected void cvSectionId_ServerValidate(object source, ServerValidateEventArgs args)
        {
            ProjectAddSectionsTDS dataSet = new ProjectAddSectionsTDS();
            dataSet.ProjectAddSectionsNew.Merge(projectAddSectionsNew, true);
            dataSet.ProjectAddSectionsTemp.Merge(projectAddSectionsTemp, true);

            ProjectAddSectionsNew projectAddSectionsNewModel = new ProjectAddSectionsNew(dataSet);
            ProjectAddSectionsTemp projectAddSectionsTempModel = new ProjectAddSectionsTemp(dataSet);

            // Initialize 
            CustomValidator cvSectionId = (CustomValidator)source;
            args.IsValid = true;

            // verify in this step
            if (projectAddSectionsNewModel.ExistsBySectionId(args.Value))
            {
                cvSectionId.Text = "Duplicated section. (you already have this section here)";
                args.IsValid = false;
            }

            // verify before added or selected
            if (args.IsValid)
            {
                if (projectAddSectionsTempModel.ExistsBySectionId(args.Value))
                {
                    cvSectionId.Text = "Duplicated section. (this section was already created or added previously)";
                    args.IsValid = false;
                }
            }

            // verify in project with specific work
            if (args.IsValid)
            {
                string workType;
                switch (hdfWorkType.Value)
                {
                    case "All":
                        workType = "%";
                        break;

                    case "Rehab Assessment":
                        workType = "Rehab Assessment";
                        break;

                    case "Full Length Lining":
                        workType = "Full Length Lining";
                        break;

                    case "Point Repairs":
                        workType = "Point Repairs";
                        break;

                    case "Junction Lining":
                        workType = "Junction Lining Section";
                        break;

                    case "Manhole Rehabilitation":
                        workType = "%";
                        break;

                    default:
                        throw new Exception("Erroneus work type in Add Section query string.");
                }

                WorkGateway workGateway = new WorkGateway(null);
                if (workGateway.ExistsSectionByProjectIdSectionIdWorkType(int.Parse(hdfProjectId.Value), args.Value, workType, int.Parse(hdfCompanyId.Value)))
                {
                    cvSectionId.Text = "This section is already associated with this project. (if you would like to see it go to the Sections data of this project)";
                    args.IsValid = false;
                }
            }

            // verify in project general
            if (args.IsValid)
            {
                Int64? countryId = int.Parse(hdfCountryId.Value);
                Int64? provinceId = null; if (hdfProvinceId.Value != "") provinceId = Int64.Parse(hdfProvinceId.Value);
                Int64? countyId = null; if (hdfCountyId.Value != "") countyId = Int64.Parse(hdfCountyId.Value);
                Int64? cityId = null; if (hdfCityId.Value != "") cityId = Int64.Parse(hdfCityId.Value);
                int companyId = int.Parse(hdfCompanyId.Value);

                AssetSewerSectionGateway assetSewerSectionGateway = new AssetSewerSectionGateway(null);
                if (assetSewerSectionGateway.ExistsByCountryIdProvinceIdCountyIdCityIdSectionId(countryId, provinceId, countyId, cityId, args.Value, companyId))
                {
                    cvSectionId.Text = "This section is already in the database. (you can try adding it using the Add Existing Sections option)";
                    args.IsValid = false;
                }
            }
        }

        #endregion


        


        
        #region STEP6 - SEARCH SECTIONS

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP6 - SEARCH SECTIONS
        //


        // ////////////////////////////////////////////////////////////////////////
        // STEP6 - SEARCH SECTIONS - METHODS
        //

        private void StepSearchSectionsIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Please search existing sections in " + hdfSearchTitle.Value;
            tbxSearchSectionID.Text = "%";
            tbxSearchStreet.Text = "%";
            tbxSearchUSMH.Text =  "%";
            tbxSearchDSMH.Text =  "%";
            tbxSearchMapSize.Text = "%";
            tbxSearchMapLength.Text = "%";
        }



        private bool StepSearchSectionsNext()
        {
            // Get where clause and order by clasue
            string whereClause = GetWhereClause();
            string orderByClause = GetOderByClause();

            // Search
            ProjectAddSectionsTDS dataSet = new ProjectAddSectionsTDS();
            dataSet.ProjectAddSectionsSearch.Merge(projectAddSectionsSearch, true);
            ProjectAddSectionsSearch model = new ProjectAddSectionsSearch(dataSet);

            model.Load(whereClause, orderByClause);

            // Review Previous Work
            int projectId = Int32.Parse(hdfProjectId.Value);
            int companyId = Int32.Parse(hdfCompanyId.Value);
            
            model.UpdatePreviousWorks(projectId, companyId);

            // Store tables
            projectAddSectionsSearch = (ProjectAddSectionsTDS.ProjectAddSectionsSearchDataTable) model.Table;
            Session["projectAddSectionsSearch"] = projectAddSectionsSearch;

            return true;
        }



        private bool StepSearchSectionsPrevious()
        {
            return true;
        }



        private string GetWhereClause()
        {
            // define parameters
            string workType = "%";

            switch (hdfWorkType.Value)
            {
                case "All":
                    workType = "%";
                    break;

                case "Rehab Assessment":
                    workType = "Rehab Assessment";
                    break;

                case "Full Length Lining":
                    workType = "Full Length Lining";
                    break;

                case "Point Repairs":
                    workType = "Point Repairs";
                    break;

                case "Junction Lining":
                    workType = "Junction Lining Section";
                    break;

                case "Manhole Rehabilitation":
                    workType = "%";
                    break;

                default:
                    throw new Exception("Error in work type passed in query string");
            }

            // general conditions
            string whereClause = string.Format("(Deleted = 0) AND (COMPANY_ID = {0}) ", hdfCompanyId.Value);

            // search conditions
            // ... SectionID field
            if (tbxSearchSectionID.Text.Trim() == "")
            {
                whereClause += string.Format(" AND (SectionID IS NULL) ");
            }
            else
            {
                if (tbxSearchSectionID.Text.Trim() == "%")
                {
                    whereClause += string.Format(" AND ((SectionID IS NULL) OR (SectionID IS NOT NULL)) ");
                }
                else
                {
                    whereClause += string.Format(" AND (SectionID LIKE '%{0}%') ", tbxSearchSectionID.Text.Trim());
                }
            }


            // ... Street field
            if (tbxSearchStreet.Text.Trim() == "")
            {
                whereClause += string.Format(" AND (Street IS NULL) ");
            }
            else
            {
                if (tbxSearchStreet.Text.Trim() == "%")
                {
                    whereClause += string.Format(" AND ((Street IS NULL) OR (Street IS NOT NULL)) ");
                }
                else
                {
                    whereClause += string.Format(" AND (Street LIKE '%{0}%') ", tbxSearchStreet.Text.Trim());
                }
            }

            // ... USMH field
            if (tbxSearchUSMH.Text.Trim() == "")
            {
                whereClause += string.Format(" AND (USMH IS NULL) ");
            }
            else
            {
                if (tbxSearchUSMH.Text.Trim() == "%")
                {
                    whereClause += string.Format(" AND ((USMH IS NULL) OR (USMH IS NOT NULL)) ");
                }
                else
                {
                    whereClause += string.Format(" AND (USMH LIKE '%{0}%') ", tbxSearchUSMH.Text.Trim());
                }
            }

            // ... DSMH field
            if (tbxSearchDSMH.Text.Trim() == "")
            {
                whereClause += string.Format(" AND (DSMH IS NULL) ");
            }
            else
            {
                if (tbxSearchDSMH.Text.Trim() == "%")
                {
                    whereClause += string.Format(" AND ((DSMH IS NULL) OR (DSMH IS NOT NULL)) ");
                }
                else
                {
                    whereClause += string.Format(" AND (DSMH LIKE '%{0}%') ", tbxSearchDSMH.Text.Trim());
                }
            }

            // ... MapSize field
            if (tbxSearchMapSize.Text.Trim() == "")
            {
                whereClause += string.Format(" AND (MapSize IS NULL) ");
            }
            else
            {
                if (tbxSearchMapSize.Text.Trim() == "%")
                {
                    whereClause += string.Format(" AND ((MapSize IS NULL) OR (MapSize IS NOT NULL)) ");
                }
                else
                {
                    whereClause += string.Format(" AND (MapSize LIKE '%{0}%') ", tbxSearchMapSize.Text.Trim());
                }
            }

            // ... MapLength field
            if (tbxSearchMapLength.Text.Trim() == "")
            {
                whereClause += string.Format(" AND (MapLength IS NULL) ");
            }
            else
            {
                if (tbxSearchMapLength.Text.Trim() == "%")
                {
                    whereClause += string.Format(" AND ((MapLength IS NULL) OR (MapLength IS NOT NULL)) ");
                }
                else
                {
                    whereClause += string.Format(" AND (MapLength  LIKE '%{0}%') ", tbxSearchMapLength.Text.Trim());
                }
            }

            // location conditions
            if (hdfCountryId.Value != "")
            {
                whereClause += string.Format(" AND (CountryID = {0}) ", hdfCountryId.Value);
            }
            if (hdfProvinceId.Value != "")
            {
                whereClause += string.Format(" AND (ProvinceID = {0}) ", hdfProvinceId.Value);
            }
            if (hdfCountyId.Value != "")
            {
                whereClause += string.Format(" AND (CountyID = {0}) ", hdfCountyId.Value);
            }
            if (hdfCityId.Value != "")
            {
                whereClause += string.Format(" AND (CityID = {0}) ", hdfCityId.Value);
            }

            // project & work conditions
            whereClause += string.Format(" AND ((ProjectID IS NULL) OR ((ProjectID <> {0}) AND (AssetID NOT IN (SELECT AssetID FROM LFS_CWP_COMMON_PROJECTADDSECTIONSSEARCH_VIEW WHERE ProjectID = {0} AND COMPANY_ID = {2} AND WorkType LIKE '{1}'))) OR ((ProjectID = {0}) AND (AssetID NOT IN (SELECT AssetID FROM LFS_CWP_COMMON_PROJECTADDSECTIONSSEARCH_VIEW WHERE ProjectID = {0} AND COMPANY_ID = {2} AND WorkType LIKE '{1}'))))", hdfProjectId.Value, workType, hdfCompanyId.Value);

            return whereClause;
        }



        private string GetOderByClause()
        {
            string orderByClause = "AssetID";

            return orderByClause;
        }
        

        #endregion






        #region STEP7 - SELECT SECTIONS

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP7 - SELECT SECTIONS
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP7 - SELECT SECTIONS - EVENTS
        //

        protected void grdProjectAddSectionsSearch_DataBound(object sender, EventArgs e)
        {
            ProjectAddSectionsSearchEmptyFix(grdProjectAddSectionsSearch);
        }


        
        protected void grdProjectAddSectionsSearch_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            StepSelectSectionsProcessGrid();
        }



        protected void grdProjectAddSectionsSearch_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Normal) || (e.Row.RowState == (DataControlRowState.Normal | DataControlRowState.Alternate))))
            {
                ((CheckBox)e.Row.FindControl("cbxRehabAssessmentPrevWork")).Visible = true;
                ((CheckBox)e.Row.FindControl("cbxFullLengthLiningPrevWork")).Visible = true;
                ((CheckBox)e.Row.FindControl("cbxPointRepairsPrevWork")).Visible = true;
                ((CheckBox)e.Row.FindControl("cbxJunctionLiningPrevWork")).Visible = true;

                ((CheckBox)e.Row.FindControl("cbxRehabAssessmentPrevWorkReadOnly")).Visible = false;
                ((CheckBox)e.Row.FindControl("cbxFullLengthLiningPrevWorkReadOnly")).Visible = false;
                ((CheckBox)e.Row.FindControl("cbxPointRepairsPrevWorkReadOnly")).Visible = false;
                ((CheckBox)e.Row.FindControl("cbxJunctionLiningPrevWorkReadOnly")).Visible = false;

                /*
                // Validate RA checkboxes for previous work
                if (!((CheckBox)e.Row.FindControl("cbxRehabAssessmentPrevWork")).Checked) 
                {
                    ((CheckBox)e.Row.FindControl("cbxRehabAssessmentPrevWork")).Visible = false;
                    ((CheckBox)e.Row.FindControl("cbxRehabAssessmentPrevWorkReadOnly")).Visible = true;
                }
                else
                {
                    ((CheckBox)e.Row.FindControl("cbxRehabAssessmentPrevWork")).Visible = true;
                    ((CheckBox)e.Row.FindControl("cbxRehabAssessmentPrevWorkReadOnly")).Visible = false;                
                }

                // Validate FL checkboxes for previous work
                if (!((CheckBox)e.Row.FindControl("cbxFullLengthLiningPrevWork")).Checked)
                {
                    ((CheckBox)e.Row.FindControl("cbxFullLengthLiningPrevWork")).Visible = false;
                    ((CheckBox)e.Row.FindControl("cbxFullLengthLiningPrevWorkReadOnly")).Visible = true;
                }
                else
                {
                    ((CheckBox)e.Row.FindControl("cbxFullLengthLiningPrevWork")).Visible = true;
                    ((CheckBox)e.Row.FindControl("cbxFullLengthLiningPrevWorkReadOnly")).Visible = false;
                }

                // Validate PR checkboxes for previous work
                if (!((CheckBox)e.Row.FindControl("cbxPointRepairsPrevWork")).Checked)
                {
                    ((CheckBox)e.Row.FindControl("cbxPointRepairsPrevWork")).Visible = false;
                    ((CheckBox)e.Row.FindControl("cbxPointRepairsPrevWorkReadOnly")).Visible = true;
                }
                else
                {
                    ((CheckBox)e.Row.FindControl("cbxPointRepairsPrevWork")).Visible = true;
                    ((CheckBox)e.Row.FindControl("cbxPointRepairsPrevWorkReadOnly")).Visible = false;
                }

                // Validate JL checkboxes for previous work
                if (!((CheckBox)e.Row.FindControl("cbxJunctionLiningPrevWork")).Checked)
                {
                    ((CheckBox)e.Row.FindControl("cbxJunctionLiningPrevWork")).Visible = false;
                    ((CheckBox)e.Row.FindControl("cbxJunctionLiningPrevWorkReadOnly")).Visible = true;
                }
                else
                {
                    ((CheckBox)e.Row.FindControl("cbxJunctionLiningPrevWork")).Visible = true;
                    ((CheckBox)e.Row.FindControl("cbxJunctionLiningPrevWorkReadOnly")).Visible = false;
                }
                */
            }
        }

             



        // ////////////////////////////////////////////////////////////////////////
        // STEP7 - SELECT SECTIONS - METHODS
        //

        private void StepSelectSectionsIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Please select the sections you would like to add and check the previous project/work data you would like to be copied to this project.";

            grdProjectAddSectionsSearch.DataBind();
        }



        private bool StepSelectSectionsNext()
        {
            StepSelectSectionsProcessGrid();

            // create dataset
            ProjectAddSectionsTDS dataSet = new ProjectAddSectionsTDS();
            dataSet.ProjectAddSectionsSearch.Merge(projectAddSectionsSearch, true);
            dataSet.ProjectAddSectionsTemp.Merge(projectAddSectionsTemp, true);

            // process new sections
            ProjectAddSectionsTemp model = new ProjectAddSectionsTemp(dataSet);
            model.ProcessSearch();

            // get changes
            projectAddSectionsSearch.Rows.Clear();
            projectAddSectionsTemp.Rows.Clear();
            projectAddSectionsTemp.Merge(model.Table);

            // store tables
            Session.Remove("projectAddSectionsSearchDummy"); 
            Session["projectAddSectionsSearch"] = projectAddSectionsSearch;
            Session["projectAddSectionsTemp"] = projectAddSectionsTemp;

            return true;
        }



        private bool StepSelectSectionsPrevious()
        {
            return true;
        }



        private void StepSelectSectionsProcessGrid()
        {
            ProjectAddSectionsTDS dataSet = new ProjectAddSectionsTDS();
            dataSet.ProjectAddSectionsSearch.Merge(projectAddSectionsSearch, true);
            ProjectAddSectionsSearch model = new ProjectAddSectionsSearch(dataSet);

            // update rows
            if (Session["projectAddSectionsSearchDummy"] == null)
            {
                foreach (GridViewRow row in grdProjectAddSectionsSearch.Rows)
                {
                    string sectionId = ((Label)row.FindControl("lblSectionID")).Text.Trim();
                    bool selected = ((CheckBox)row.FindControl("cbxSelected")).Checked;
                    
                    bool rehabAssessment = ((CheckBox)row.FindControl("cbxRehabAssessmentPrevWork")).Checked;
                    bool fullLengthLining = ((CheckBox)row.FindControl("cbxFullLengthLiningPrevWork")).Checked;
                    bool pointRepairs = ((CheckBox)row.FindControl("cbxPointRepairsPrevWork")).Checked;
                    bool junctionLining = ((CheckBox)row.FindControl("cbxJunctionLiningPrevWork")).Checked;

                    bool rehabAssessmentPrevWork = ((CheckBox)row.FindControl("cbxRehabAssessmentPrevWorkReadOnly")).Checked;
                    bool fullLengthLiningPrevWork = ((CheckBox)row.FindControl("cbxFullLengthLiningPrevWorkReadOnly")).Checked;
                    bool pointRepairsPrevWork = ((CheckBox)row.FindControl("cbxPointRepairsPrevWorkReadOnly")).Checked;
                    bool junctionLiningPrevWork = ((CheckBox)row.FindControl("cbxJunctionLiningPrevWorkReadOnly")).Checked;

                    model.UpdateBySectionId(sectionId, rehabAssessment, fullLengthLining, pointRepairs, junctionLining, selected, rehabAssessmentPrevWork, fullLengthLiningPrevWork, pointRepairsPrevWork, junctionLiningPrevWork);
                }

                model.Table.AcceptChanges();

                projectAddSectionsSearch = (ProjectAddSectionsTDS.ProjectAddSectionsSearchDataTable)model.Table;
                Session["projectAddSectionsSearch"] = projectAddSectionsSearch;
            }
        }



        public ProjectAddSectionsTDS.ProjectAddSectionsSearchDataTable GetProjectAddSectionsSearch()
        {
            projectAddSectionsSearch = (ProjectAddSectionsTDS.ProjectAddSectionsSearchDataTable)Session["projectAddSectionsSearchDummy"];
            if (projectAddSectionsSearch == null)
            {
                projectAddSectionsSearch = (ProjectAddSectionsTDS.ProjectAddSectionsSearchDataTable)Session["projectAddSectionsSearch"];
            }

            return projectAddSectionsSearch;
        }



        protected void ProjectAddSectionsSearchEmptyFix(GridView grdView)
        {
            if (grdView.Rows.Count == 0)
            {
                ProjectAddSectionsTDS.ProjectAddSectionsSearchDataTable dt = new ProjectAddSectionsTDS.ProjectAddSectionsSearchDataTable();
                dt.AddProjectAddSectionsSearchRow(0, "", "", "", "", false, false, false, false, false, "", "", "", false, false, false, false, false);
                Session["projectAddSectionsSearchDummy"] = dt;

                grdView.DataBind();
            }

            // normally executes at all postbacks
            if (grdView.Rows.Count == 1)
            {
                ProjectAddSectionsTDS.ProjectAddSectionsSearchDataTable dt = (ProjectAddSectionsTDS.ProjectAddSectionsSearchDataTable)Session["projectAddSectionsSearchDummy"];
                if (dt != null)
                {
                    // hide row
                    grdView.Rows[0].Visible = false;
                    grdView.Rows[0].Controls.Clear();
                }
            }
        }

        #endregion






        #region STEP8 - REMOVE SECTIONS

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP8 - REMOVE SECTIONS
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP8 - REMOVE SECTIONS - EVENTS
        //

        protected void grdRemove_DataBound(object sender, EventArgs e)
        {
            RemoveEmptyFix(grdRemove);
        }



        protected void grdRemove_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = (int)e.Keys["ID"];

            ProjectAddSectionsTDS dataSet = new ProjectAddSectionsTDS();
            dataSet.ProjectAddSectionsTemp.Merge(projectAddSectionsTemp, true);
            ProjectAddSectionsTemp model = new ProjectAddSectionsTemp(dataSet);

            model.Delete(id);
            Session["projectAddSectionsTemp"] = dataSet.ProjectAddSectionsTemp;
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP8 - REMOVE SECTIONS - METHODS
        //

        private void StepRemoveSectionsIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Please select the sections you would like to remove";

            // grid
            grdRemove.DataBind();
        }



        private bool StepRemoveSectionsNext()
        {
            // store tables
            Session.Remove("projectAddSectionsTempDummy");

            return true;
        }



        private bool StepRemoveSectionsPrevious()
        {
            return true;
        }



        public ProjectAddSectionsTDS.ProjectAddSectionsTempDataTable GetRemove()
        {
            projectAddSectionsTemp = (ProjectAddSectionsTDS.ProjectAddSectionsTempDataTable)Session["projectAddSectionsTempDummy"];
            if (projectAddSectionsTemp == null)
            {
                projectAddSectionsTemp = (ProjectAddSectionsTDS.ProjectAddSectionsTempDataTable)Session["projectAddSectionsTemp"];
            }

            return projectAddSectionsTemp;
        }



        public void DummyRemove(int ID)
        {
        }



        private void RemoveEmptyFix(GridView grdView)
        {
            if (grdView.Rows.Count == 0)
            {
                ProjectAddSectionsTDS.ProjectAddSectionsTempDataTable dt = new ProjectAddSectionsTDS.ProjectAddSectionsTempDataTable();
                dt.AddProjectAddSectionsTempRow(0, 0, "", "", "", "", false, false, false, "", false, false, "", "", "", false, false, false, false, false, "", "", "", "", "", -1, "", "", "", "", "", -1, "","","","","","","","","","",-1, "","","","","",-1, "","","","","",-1,-1, "", "", false, false);
                Session["projectAddSectionsTempDummy"] = dt;

                grdView.DataBind();
            }

            // normally executes at all postbacks
            if (grdView.Rows.Count == 1)
            {
                ProjectAddSectionsTDS.ProjectAddSectionsTempDataTable dt = (ProjectAddSectionsTDS.ProjectAddSectionsTempDataTable)Session["projectAddSectionsTempDummy"];
                if (dt != null)
                {
                    // hide row
                    grdView.Rows[0].Visible = false;
                    grdView.Rows[0].Controls.Clear();
                }
            }
        }





        #endregion






        #region STEP9 - SUMMARY

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP9 - SUMMARY
        //


        // ////////////////////////////////////////////////////////////////////////
        // STEP9 - SUMMARY - AUXILIAR METHODS
        //

        protected void cvWorksAdd_ServerValidate(object source, ServerValidateEventArgs args)
        {
            bool cbxRA = ((CheckBox)grdProjectAddSectionsNew.FooterRow.FindControl("cbxRehabAssessmentWorkAdd")).Checked;
            bool cbxFLL = ((CheckBox)grdProjectAddSectionsNew.FooterRow.FindControl("cbxFullLengthLiningWorkAdd")).Checked;
            bool cbxPR = ((CheckBox)grdProjectAddSectionsNew.FooterRow.FindControl("cbxPointRepairsWorkAdd")).Checked;
            bool cbxJL = ((CheckBox)grdProjectAddSectionsNew.FooterRow.FindControl("cbxJunctionLiningWorkAdd")).Checked;

            if (cbxRA || cbxFLL || cbxJL || cbxPR)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }



        protected void cvWorksEdit_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Get row to edit
            int rowEditing = grdProjectAddSectionsNew.EditIndex;
            GridViewRow row = grdProjectAddSectionsNew.Rows[rowEditing];

            bool cbxRA = ((CheckBox)row.FindControl("cbxRehabAssessmentWorkEdit")).Checked;
            bool cbxFLL = ((CheckBox)row.FindControl("cbxFullLengthLiningWorkEdit")).Checked;
            bool cbxPR = ((CheckBox)row.FindControl("cbxPointRepairsWorkEdit")).Checked;
            bool cbxJL = ((CheckBox)row.FindControl("cbxJunctionLiningWorkEdit")).Checked;

            if (cbxRA || cbxFLL || cbxJL || cbxPR)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }



        protected void cvMHRehabAdd_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;
            CustomValidator cvMHRehabAdd = (CustomValidator)source;
            cvMHRehabAdd.Text = "";

            string tbxUsmhAdd = ((TextBox)grdProjectAddSectionsNew.FooterRow.FindControl("tbxUsmhAdd")).Text;
            string tbxDsmhAdd = ((TextBox)grdProjectAddSectionsNew.FooterRow.FindControl("tbxDsmhAdd")).Text;

            bool cbxMHRehabUsmh = ((CheckBox)grdProjectAddSectionsNew.FooterRow.FindControl("cbxMHRehabUsmhAdd")).Checked;
            bool cbxMHRehabDsmh = ((CheckBox)grdProjectAddSectionsNew.FooterRow.FindControl("cbxMHRehabDsmhAdd")).Checked;

            if (cbxMHRehabUsmh && tbxUsmhAdd.Length == 0)
            {
                args.IsValid = false;
                if (cvMHRehabAdd.Text == "")
                {
                    cvMHRehabAdd.Text = "You must enter USMH data.";
                }
                else
                {
                    cvMHRehabAdd.Text += ". You must enter USMH data.";
                }
            }

            if (cbxMHRehabDsmh && tbxDsmhAdd.Length == 0)
            {
                args.IsValid = false;
                if (cvMHRehabAdd.Text == "")
                {
                    cvMHRehabAdd.Text = "You must enter DSMH data.";
                }
                else
                {
                    cvMHRehabAdd.Text += ". You must enter DSMH data.";
                }
            }
        }



        protected void cvMHRehabEdit_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;
            CustomValidator cvMHRehabEdit = (CustomValidator)source;
            cvMHRehabEdit.Text = "";

            // Get row to edit
            int rowEditing = grdProjectAddSectionsNew.EditIndex;
            GridViewRow row = grdProjectAddSectionsNew.Rows[rowEditing];

            string tbxUsmhEdit = ((TextBox)row.FindControl("tbxUsmhEdit")).Text;
            string tbxDsmhEdit = ((TextBox)row.FindControl("tbxDsmhEdit")).Text;

            bool cbxMHRehabUsmh = ((CheckBox)row.FindControl("cbxMHRehabUsmhEdit")).Checked;
            bool cbxMHRehabDsmh = ((CheckBox)row.FindControl("cbxMHRehabDsmhEdit")).Checked;

            if (cbxMHRehabUsmh && tbxUsmhEdit.Length == 0)
            {
                args.IsValid = false;
                if (cvMHRehabEdit.Text == "")
                {
                    cvMHRehabEdit.Text = "You must enter USMH data.";
                }
                else
                {
                    cvMHRehabEdit.Text += ". You must enter USMH data.";
                }
            }

            if (cbxMHRehabDsmh && tbxDsmhEdit.Length == 0)
            {
                args.IsValid = false;
                if (cvMHRehabEdit.Text == "")
                {
                    cvMHRehabEdit.Text = "You must enter DSMH data.";
                }
                else
                {
                    cvMHRehabEdit.Text += ". You must enter DSMH data.";
                }
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP9 - SUMMARY - METHODS
        //

        private void StepSummaryIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Summary";

            // Initialize summary
            ProjectAddSectionsTDS dataSet = new ProjectAddSectionsTDS();
            dataSet.ProjectAddSectionsTemp.Merge(projectAddSectionsTemp, true);
            ProjectAddSectionsTemp model = new ProjectAddSectionsTemp(dataSet);

            tbxSummary.Text = model.GetSectionsSummary(hdfWorkType.Value);
        }



        private bool StepSummaryPrevious()
        {
            return true;
        }



        private bool StepSummaryFinish()
        {
            Page.Validate("StepSummary");
            if (Page.IsValid)
            {
                Save();
                return true;
            }
            else
            {
                return false;
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
            title.Text = "Add Sections To Project";
        }






        // ////////////////////////////////////////////////////////////////////////
        // METHODS
        //

        #region RegisterClientScript & TagPage

        private void RegisterClientScripts()
        {
            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./project_add_sections.js");
        }



        private void TagPage()
        {
            hdfWorkType.Value = Request.QueryString["work_type"].ToString();
            hdfCompanyId.Value = Session["companyID"].ToString();
            hdfProjectId.Value = Request.QueryString["project_id"].ToString();
            
            // Get ids & location
            int projectId = Int32.Parse(hdfProjectId.Value.Trim());
            ProjectGateway projectGateway = new ProjectGateway();
            projectGateway.LoadByProjectId(projectId);

            // ... Get ids
            Int64 currentCountry = projectGateway.GetCountryID(projectId);
            Int64? currentProvince = null; if (projectGateway.GetProvinceID(projectId).HasValue) currentProvince = (Int64)projectGateway.GetProvinceID(projectId);
            Int64? currentCounty = null; if (projectGateway.GetCountyID(projectId).HasValue) currentCounty = (Int64)projectGateway.GetCountyID(projectId);
            Int64? currentCity = null; if (projectGateway.GetCityID(projectId).HasValue) currentCity = (Int64)projectGateway.GetCityID(projectId);

            hdfCountryId.Value = currentCountry.ToString();
            hdfProvinceId.Value = currentProvince.ToString();
            hdfCountyId.Value = currentCounty.ToString();
            hdfCityId.Value = currentCity.ToString();

            // .. Get location
            string projectLocation = "";

            CountryGateway countryGateway = new CountryGateway();
            countryGateway.LoadByCountryId(currentCountry);
            projectLocation = projectLocation + countryGateway.GetName(currentCountry);

            if (currentProvince.HasValue)
            {
                ProvinceGateway provinceGateway = new ProvinceGateway();
                provinceGateway.LoadByProvinceId((Int64)currentProvince);
                projectLocation = projectLocation + ", " + provinceGateway.GetName((Int64)currentProvince);
            }

            if (currentCounty.HasValue)
            {
                CountyGateway countyGateway = new CountyGateway();
                countyGateway.LoadByCountyId((Int64)currentCounty);
                projectLocation = projectLocation + ", " + countyGateway.GetName((Int64)currentCounty);
            }

            if (currentCity.HasValue)
            {
                CityGateway cityGateway = new CityGateway();
                cityGateway.LoadByCityId((Int64)currentCity);
                projectLocation = projectLocation + ", " + cityGateway.GetName((Int64)currentCity);
            }

            hdfSearchTitle.Value = projectLocation;
        }

        #endregion



        private void Save()
        {
            // process works
            ProjectAddSectionsTDS dataSet = new ProjectAddSectionsTDS();
            dataSet.ProjectAddSectionsTemp.Merge(projectAddSectionsTemp, true);
            ProjectAddSectionsTemp model = new ProjectAddSectionsTemp(dataSet);

            // get parameters
            Int64 countryId = int.Parse(hdfCountryId.Value);
            Int64? provinceId = null; if (hdfProvinceId.Value != "") provinceId = Int64.Parse(hdfProvinceId.Value);
            Int64? countyId = null; if (hdfCountyId.Value != "") countyId = Int64.Parse(hdfCountyId.Value);
            Int64? cityId = null; if (hdfCityId.Value != "") cityId = Int64.Parse(hdfCityId.Value);

            // save to database
            DB.Open();
            DB.BeginTransaction();
            try
            {
                model.Save(int.Parse(hdfProjectId.Value), countryId, provinceId, countyId, cityId, int.Parse(hdfCompanyId.Value));

                DB.CommitTransaction();
            }
            catch (Exception ex)
            {
                DB.RollbackTransaction();

                string url = string.Format("./../../error_page.aspx?error={0}", ex.Message.Replace('\n', ' '));
                Response.Redirect(url);
            }
        }

        

    
    
    }
}