using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.BL.CWP.Common;
using LiquiForce.LFSLive.BL.Projects.Projects;
using LiquiForce.LFSLive.BL.Resources.Companies;
using LiquiForce.LFSLive.CWP.Tools;
using LiquiForce.LFSLive.DA.Assets.Assets;
using LiquiForce.LFSLive.DA.CWP.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.WebUI.CWP.Common
{
    /// <summary>
    /// add_manhole
    /// </summary>
    public partial class add_manhole : System.Web.UI.Page
    {
        protected AddManholeTDS.AddManholeNewDataTable addManholeNew;
        protected AddManholeTDS addManholeTDS;






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
                if (!(Convert.ToBoolean(Session["sgLFS_CWP_MANHOLEREHABILITATION_ADD"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }
                
                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["client_id"] == null) || ((string)Request.QueryString["project_id"] == null) || ((string)Request.QueryString["work_type"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in add_manholes.aspx");
                }                               

                // Tag Page
                TagPage();

                // Prepare initial data
                Session.Remove("addManholeNew");
                Session.Remove("addManholeNewDummy");               

                // Initialize viewstate variables
                ViewState["StepFrom"] = "Out";

                // If coming from 
                // ... mr_navigator.aspx, mr_navigator2.aspx, mr_edit.aspx, mr_summary.aspx
                if ((Request.QueryString["source_page"] == "mr_navigator.aspx") || (Request.QueryString["source_page"] == "mr_navigator2.aspx") || (Request.QueryString["source_page"] == "mr_edit.aspx") || (Request.QueryString["source_page"] == "mr_summary.aspx"))
                {
                    // ... Store datasets
                    addManholeTDS = new AddManholeTDS();
                    Session["addManholeTDS"] = addManholeTDS;
                    Session["addManholeNew"] = addManholeTDS.AddManholeNew;

                    // StepSection1In
                    wizard.ActiveStepIndex = 0;
                    StepBeginIn();
                }

                // ...  for the client
                int companyId = Int32.Parse(hdfCompanyId.Value);
                CompaniesList companiesList = new CompaniesList();
                companiesList.LoadAndAddItem(-1, "(Select a client)", companyId);
                ddlClient.DataSource = companiesList.Table;
                ddlClient.DataValueField = "COMPANIES_ID";
                ddlClient.DataTextField = "Name";
                ddlClient.DataBind();

                if (Request.QueryString["client_id"] != null)
                {
                    ddlClient.SelectedValue = Request.QueryString["client_id"];

                    // ... for project
                    ProjectList projectList = new ProjectList();
                    projectList.LoadProjectsAndAddItem(-1, "(All)", int.Parse(ddlClient.SelectedValue));
                    ddlProject.DataSource = projectList.Table;
                    ddlProject.DataValueField = "ProjectID";
                    ddlProject.DataTextField = "Name";
                    ddlProject.DataBind();
                    ddlProject.SelectedValue = Request.QueryString["project_id"];
                }
                else
                {
                    ddlClient.SelectedIndex = 0;

                    // ... for project
                    ProjectList projectList = new ProjectList();
                    projectList.LoadProjectsAndAddItem(-1, "(Select a project)", -1);
                    ddlProject.DataSource = projectList.Table;
                    ddlProject.DataValueField = "ProjectID";
                    ddlProject.DataTextField = "Name";
                    ddlProject.DataBind();
                    ddlProject.SelectedIndex = 0;
                }

                // StepSection1In
                wizard.ActiveStepIndex = 0;
                StepBeginIn();
            }
            else
            {
                // Restore datasets
                addManholeTDS = (AddManholeTDS)Session["addManholeTDS"];

                // Store
                Session["addManholeNew"] = addManholeTDS.AddManholeNew;               
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
                switch (wizard.ActiveStep.Name)
                {
                    case "Begin":
                        StepBeginIn();
                        break;

                    case "Finish":
                        StepSummaryIn();
                        break;

                    default:
                        throw new Exception("The option for " + wizard.ActiveStep.Name + " step in add_manhole.Wizard_ActiveStepChanged function does not exist");
                }
            }
        }



        protected void Wizard_NextButtonClick(object sender, WizardNavigationEventArgs e)
        {
            switch (wizard.ActiveStep.Name)
            {
                case "Begin":
                    e.Cancel = !StepBeginNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "Begin";
                        wizard.ActiveStepIndex = wizard.WizardSteps.IndexOf(Summary);
                    }
                    break;

                default:
                    throw new Exception("The option for " + wizard.ActiveStep.Name + " step in add_manhole.Wizard_NextButtonClick function does not exist");
            }
        }



        protected void Wizard_PreviousButtonClick(object sender, WizardNavigationEventArgs e)
        {
            switch (wizard.ActiveStep.Name)
            {                

                case "Summary":
                    e.Cancel = !StepSummaryPrevious();
                    break;

                default:
                    throw new Exception("The option for " + wizard.ActiveStep.Name + " step in add_manholes.Wizard_PreviousButtonClick function does not exist");
            }
            if (!e.Cancel)
            {
                ViewState["StepFrom"] = wizard.ActiveStep.Name;
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


        #endregion






        #region STEP1 - BEGIN

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP1 - BEGIN
        //

       
        // ////////////////////////////////////////////////////////////////////////
        // STEP1 - NEW SECTION - EVENTS
        //

        protected void ddlClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProjectList projectList = new ProjectList();
            projectList.LoadProjectsAndAddItem(-1, "(Select a project)", int.Parse(ddlClient.SelectedValue));
            ddlProject.DataSource = projectList.Table;
            ddlProject.DataValueField = "ProjectID";
            ddlProject.DataTextField = "Name";
            ddlProject.DataBind();
            ddlProject.SelectedIndex = 0;

            rfvProject.Validate();
        }



        protected void ddlProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int currentProjectId = int.Parse(ddlProject.SelectedValue);

            //if ((ddlProject.SelectedValue != null) && (ddlProject.SelectedValue != "-1"))
            //{
            //    ProjectGateway projectGateway = new ProjectGateway();
            //    projectGateway.LoadByProjectId(currentProjectId);
            //}

            rfvProject.Validate();
        }



        protected void grdAddManholeNew_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Add":
                    // ProjectAddManhole Gridview, if the gridview is edition mode
                    if (grdAddManholeNew.EditIndex >= 0)
                    {
                        grdAddManholeNew.UpdateRow(grdAddManholeNew.EditIndex, true);
                    }

                    // Add New Project Sections
                    GrdAddManholeNewAdd();
                    break;
            }
        }

 

        protected void grdAddManholeNew_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Update section
            Page.Validate("AddManholeUpdate");
            if (Page.IsValid)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                int assetId = (int)e.Keys["AssetID"];
                string mhId = ((TextBox)grdAddManholeNew.Rows[e.RowIndex].Cells[1].FindControl("tbxMhIdEdit")).Text;
                string street = ((TextBox)grdAddManholeNew.Rows[e.RowIndex].Cells[1].FindControl("tbxStreetEdit")).Text.Trim();
                string latitude = ((TextBox)grdAddManholeNew.Rows[e.RowIndex].Cells[1].FindControl("tbxLatitudeEdit")).Text.Trim();
                string longitude = ((TextBox)grdAddManholeNew.Rows[e.RowIndex].Cells[1].FindControl("tbxLongitudeEdit")).Text.Trim();
                string shape = ((DropDownList)grdAddManholeNew.Rows[e.RowIndex].Cells[1].FindControl("ddlShapeEdit")).SelectedValue;
                string location = ((DropDownList)grdAddManholeNew.Rows[e.RowIndex].Cells[1].FindControl("ddlLocationEdit")).SelectedValue;

                int? conditionRating = null;
                if (Int32.Parse(((DropDownList)grdAddManholeNew.Rows[e.RowIndex].Cells[1].FindControl("ddlConditioningRatingEdit")).SelectedValue) == -1)
                {
                    conditionRating = Int32.Parse(((DropDownList)grdAddManholeNew.Rows[e.RowIndex].Cells[1].FindControl("ddlConditioningRatingEdit")).SelectedValue);
                }

                int materialId = Int32.Parse(((DropDownList)grdAddManholeNew.Rows[e.RowIndex].Cells[1].FindControl("ddlMaterialEdit")).SelectedValue);

                AssetSewerMHMaterialTypeGateway assetSewerMHMaterialTypeGateway = new AssetSewerMHMaterialTypeGateway();
                assetSewerMHMaterialTypeGateway.LoadByMaterialId((int)materialId, companyId);
                string material = ""; if (assetSewerMHMaterialTypeGateway.Table.Rows.Count > 0) material = assetSewerMHMaterialTypeGateway.GetMaterialType((int)materialId);                

                string topDiameter = "";
                string topDepth = "";
                string topFloor = "";
                string topCeiling = "";
                string topBenching = "";
                string downDiameter = "";
                string downDepth = "";
                string downFloor = "";
                string downCeiling = "";
                string downBenching = "";
                string rectangle1LongSide = "";
                string rectangle1ShortSide = "";
                string rectangle2LongSide = "";
                string rectangle2ShortSide = "";
                string topSurfaceArea = "";
                string downSurfaceArea = "";
                int? manholeRugs = null;
                string totalDepth = "";
                string totalSufaceArea = "";

                if (shape == "Round")
                {
                    topDiameter = ((TextBox)grdAddManholeNew.Rows[e.RowIndex].Cells[1].FindControl("tbxRehabilitationDataChimneyDiameterEdit")).Text.Trim();
                    topDepth = ((TextBox)grdAddManholeNew.Rows[e.RowIndex].Cells[1].FindControl("tbxRehabilitationDataChimneyDepthEdit")).Text.Trim();
                    downDiameter = ((TextBox)grdAddManholeNew.Rows[e.RowIndex].Cells[1].FindControl("tbxRehabilitationDataBarrelDiameterEdit")).Text.Trim();
                    downDepth = ((TextBox)grdAddManholeNew.Rows[e.RowIndex].Cells[1].FindControl("tbxRehabilitationDataBarrelDepthEdit")).Text.Trim();
                    if (((DropDownList)grdAddManholeNew.Rows[e.RowIndex].Cells[1].FindControl("ddlRehabilitationDataRoundManholeRugsEdit")).SelectedValue != "-1")
                    {
                        manholeRugs = Int32.Parse(((DropDownList)grdAddManholeNew.Rows[e.RowIndex].Cells[1].FindControl("ddlRehabilitationDataRoundManholeRugsEdit")).SelectedValue);
                    }
                }
                
                if (shape == "Rectangular")
                {
                    rectangle1LongSide = ((TextBox)grdAddManholeNew.Rows[e.RowIndex].Cells[1].FindControl("tbxRehabilitationDataRectangle1LongSideEdit")).Text.Trim();
                    rectangle1ShortSide = ((TextBox)grdAddManholeNew.Rows[e.RowIndex].Cells[1].FindControl("tbxRehabilitationDataRectangle1ShortSideEdit")).Text.Trim();
                    topDepth = ((TextBox)grdAddManholeNew.Rows[e.RowIndex].Cells[1].FindControl("tbxRehabilitationDataRectangle1DepthEdit")).Text.Trim();                    
                    rectangle2LongSide = ((TextBox)grdAddManholeNew.Rows[e.RowIndex].Cells[1].FindControl("tbxRehabilitationDataRectangle2LongSideEdit")).Text.Trim();
                    rectangle2ShortSide = ((TextBox)grdAddManholeNew.Rows[e.RowIndex].Cells[1].FindControl("tbxRehabilitationDataRectangle2ShortSideEdit")).Text.Trim();
                    downDepth = ((TextBox)grdAddManholeNew.Rows[e.RowIndex].Cells[1].FindControl("tbxRehabilitationDataRectangle2DepthEdit")).Text.Trim();
                    if (((DropDownList)grdAddManholeNew.Rows[e.RowIndex].Cells[1].FindControl("ddlRehabilitationDataRectangularManholeRugsEdit")).SelectedValue != "-1")
                    {
                        manholeRugs = Int32.Parse(((DropDownList)grdAddManholeNew.Rows[e.RowIndex].Cells[1].FindControl("ddlRehabilitationDataRectangularManholeRugsEdit")).SelectedValue);
                    }
                }
                if (shape == "Mixed")
                {
                    topDiameter = ((TextBox)grdAddManholeNew.Rows[e.RowIndex].Cells[1].FindControl("tbxRehabilitationDataRoundDiameterEdit")).Text.Trim();
                    topDepth = ((TextBox)grdAddManholeNew.Rows[e.RowIndex].Cells[1].FindControl("tbxRehabilitationDataRoundDepthEdit")).Text.Trim();
                    rectangle2LongSide = ((TextBox)grdAddManholeNew.Rows[e.RowIndex].Cells[1].FindControl("tbxRehabilitationDataRectangleLongSideEdit")).Text.Trim();
                    rectangle2ShortSide = ((TextBox)grdAddManholeNew.Rows[e.RowIndex].Cells[1].FindControl("tbxRehabilitationDataRectangleShortSideEdit")).Text.Trim();
                    downDepth = ((TextBox)grdAddManholeNew.Rows[e.RowIndex].Cells[1].FindControl("tbxRehabilitationDataRectangleDepthEdit")).Text.Trim();
                    if (((DropDownList)grdAddManholeNew.Rows[e.RowIndex].Cells[1].FindControl("ddlRehabilitationDataMixManholeRugsEdit")).SelectedValue != "-1")
                    {
                        manholeRugs = Int32.Parse(((DropDownList)grdAddManholeNew.Rows[e.RowIndex].Cells[1].FindControl("ddlRehabilitationDataMixManholeRugsEdit")).SelectedValue);
                    }
                }

                if (shape == "Other")
                {
                    totalSufaceArea = ((TextBox)grdAddManholeNew.Rows[e.RowIndex].Cells[1].FindControl("tbxRehabilitationDataOtherStructureEdit")).Text.Trim();
                }

                AddManholeNew model = new AddManholeNew(addManholeTDS);
                model.Update(assetId, longitude, latitude, street, shape, location, materialId, topDiameter, topDepth, topFloor, topCeiling, topBenching, downDiameter, downDepth, downFloor, downCeiling, downBenching, rectangle1LongSide, rectangle1ShortSide, rectangle2LongSide, rectangle2ShortSide, topSurfaceArea, downSurfaceArea, manholeRugs, totalDepth, totalSufaceArea, conditionRating, material);

                // Store dataset
                Session["addManholeTDS"] = addManholeTDS;
                Session["addManholeNew"] = addManholeTDS.AddManholeNew;
            }
            else
            {
                e.Cancel = true;
            }
        }



        protected void grdAddManholeNew_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // ProjectAddManhole Gridview, if the gridview is edition mode
            if (grdAddManholeNew.EditIndex >= 0)
            {
                grdAddManholeNew.UpdateRow(grdAddManholeNew.EditIndex, true);
            }
        }



        protected void grdAddManholeNew_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // AddManholeNew Gridview, if the gridview is edition mode
            if (grdAddManholeNew.EditIndex >= 0)
            {
                grdAddManholeNew.UpdateRow(grdAddManholeNew.EditIndex, true);
            }

            //Delete 
            int assetId = (int)e.Keys["AssetID"];
            int companyId = Int32.Parse(hdfCompanyId.Value);

            // Delete catalysts
            AddManholeNew model = new AddManholeNew(addManholeTDS);
            model.Delete(assetId, companyId);

            // Store dataset
            Session["addManholeTDS"] = addManholeTDS;

            grdAddManholeNew.DataBind();
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP1 - NEW SECTION - AUXILIAR EVENTS
        //

        protected void grdAddManholeNew_DataBound(object sender, EventArgs e)
        {
            AddManholeNewEmptyFix(grdAddManholeNew);
        }



        protected void grdAddManholeNew_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Edit controls
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Edit) || (e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                int assetId = Int32.Parse(((Label)e.Row.FindControl("lblAssetID")).Text);

                AddManholeNewGateway addManholeNewGatewayForGrid = new AddManholeNewGateway(addManholeTDS);

                if (addManholeNewGatewayForGrid.Table.Rows.Count > 0)
                {
                    ((DropDownList)e.Row.FindControl("ddlShapeEdit")).SelectedValue = addManholeNewGatewayForGrid.GetManholeShape(assetId);
                    ((DropDownList)e.Row.FindControl("ddlLocationEdit")).SelectedValue = addManholeNewGatewayForGrid.GetLocation(assetId);                    
                    ((DropDownList)e.Row.FindControl("ddlMaterialEdit")).SelectedValue = addManholeNewGatewayForGrid.GetMaterialID(assetId).ToString();
                    ((DropDownList)e.Row.FindControl("ddlRehabilitationDataRoundManholeRugsEdit")).SelectedValue = addManholeNewGatewayForGrid.GetManholeRugs(assetId).ToString();
                    ((DropDownList)e.Row.FindControl("ddlRehabilitationDataRectangularManholeRugsEdit")).SelectedValue = addManholeNewGatewayForGrid.GetManholeRugs(assetId).ToString();
                    ((DropDownList)e.Row.FindControl("ddlRehabilitationDataMixManholeRugsEdit")).SelectedValue = addManholeNewGatewayForGrid.GetManholeRugs(assetId).ToString();

                    if (addManholeNewGatewayForGrid.GetConditionRating(assetId).HasValue)
                    {
                        ((DropDownList)e.Row.FindControl("ddlConditioningRatingEdit")).SelectedValue = addManholeNewGatewayForGrid.GetConditionRating(assetId).ToString();
                    }
                    else
                    {
                        ((DropDownList)e.Row.FindControl("ddlConditioningRatingEdit")).SelectedValue = "-1";
                    }
                }
        
                switch (addManholeNewGatewayForGrid.GetManholeShape(assetId))
                {
                    case "Round":
                        ((Panel)e.Row.FindControl("pnlInformationRoundMHEdit")).Visible = true;
                        ((Panel)e.Row.FindControl("pnlInformationRectangularMHEdit")).Visible = false;
                        ((Panel)e.Row.FindControl("pnlInformationMixedMHEdit")).Visible = false;
                        ((Panel)e.Row.FindControl("pnlInformationOtherMHEdit")).Visible = false;
                        break;

                    case "Rectangular":
                        ((Panel)e.Row.FindControl("pnlInformationRoundMHEdit")).Visible = false;
                        ((Panel)e.Row.FindControl("pnlInformationRectangularMHEdit")).Visible = true;
                        ((Panel)e.Row.FindControl("pnlInformationMixedMHEdit")).Visible = false;
                        ((Panel)e.Row.FindControl("pnlInformationOtherMHEdit")).Visible = false;
                        break;

                    case "Mixed":
                        ((Panel)e.Row.FindControl("pnlInformationRoundMHEdit")).Visible = false;
                        ((Panel)e.Row.FindControl("pnlInformationRectangularMHEdit")).Visible = false;
                        ((Panel)e.Row.FindControl("pnlInformationMixedMHEdit")).Visible = true;
                        ((Panel)e.Row.FindControl("pnlInformationOtherMHEdit")).Visible = false;
                        break;


                    case "Other":
                        ((Panel)e.Row.FindControl("pnlInformationRoundMHEdit")).Visible = false;
                        ((Panel)e.Row.FindControl("pnlInformationRectangularMHEdit")).Visible = false;
                        ((Panel)e.Row.FindControl("pnlInformationMixedMHEdit")).Visible = false;
                        ((Panel)e.Row.FindControl("pnlInformationOtherMHEdit")).Visible = true;
                        break;

                    default:
                        ((Panel)e.Row.FindControl("pnlInformationRoundMHEdit")).Visible = false;
                        ((Panel)e.Row.FindControl("pnlInformationRectangularMHEdit")).Visible = false;
                        ((Panel)e.Row.FindControl("pnlInformationMixedMHEdit")).Visible = false;
                        ((Panel)e.Row.FindControl("pnlInformationOtherMHEdit")).Visible = false;
                        break;
                };                                         
            }

            // Normal rows
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Normal) || (e.Row.RowState == (DataControlRowState.Normal | DataControlRowState.Alternate))))
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                int assetId = Int32.Parse(((Label)e.Row.FindControl("lblAssetID")).Text);

                AddManholeNewGateway addManholeNewGatewayForGrid = new AddManholeNewGateway(addManholeTDS);

                if (addManholeNewGatewayForGrid.Table.Rows.Count > 0)
                {
                    ((TextBox)e.Row.FindControl("tbxShape")).Text = addManholeNewGatewayForGrid.GetManholeShape(assetId);
                    ((TextBox)e.Row.FindControl("tbxLocation")).Text = addManholeNewGatewayForGrid.GetLocation(assetId);

                    if (addManholeNewGatewayForGrid.GetConditionRating(assetId).HasValue)
                    {
                        ((TextBox)e.Row.FindControl("tbxConditionRating")).Text = addManholeNewGatewayForGrid.GetConditionRating(assetId).ToString();
                    }
                    else
                    {
                        ((TextBox)e.Row.FindControl("tbxConditionRating")).Text = "";
                    }
                    
                    int? materialId = addManholeNewGatewayForGrid.GetMaterialID(assetId);
                    ((TextBox)e.Row.FindControl("tbxMaterial")).Text = "";
                    if (materialId.HasValue)
                    {
                        AssetSewerMHMaterialTypeGateway assetSewerMHMaterialTypeGateway = new AssetSewerMHMaterialTypeGateway();
                        assetSewerMHMaterialTypeGateway.LoadByMaterialId((int)materialId, companyId);

                        string materialDescription = assetSewerMHMaterialTypeGateway.GetMaterialType((int)materialId);
                        ((TextBox)e.Row.FindControl("tbxMaterial")).Text = materialDescription;
                    }
                }

                switch (((TextBox)e.Row.FindControl("tbxShape")).Text)
                {
                    case "Round":
                        ((Panel)e.Row.FindControl("pnlInformationRoundMH")).Visible = true;
                        ((Panel)e.Row.FindControl("pnlInformationRectangularMH")).Visible = false;
                        ((Panel)e.Row.FindControl("pnlInformationMixedMH")).Visible = false;
                        ((Panel)e.Row.FindControl("pnlInformationOtherMH")).Visible = false;
                        break;

                    case "Rectangular":
                        ((Panel)e.Row.FindControl("pnlInformationRoundMH")).Visible = false;
                        ((Panel)e.Row.FindControl("pnlInformationRectangularMH")).Visible = true;
                        ((Panel)e.Row.FindControl("pnlInformationMixedMH")).Visible = false;
                        ((Panel)e.Row.FindControl("pnlInformationOtherMH")).Visible = false;
                        break;

                    case "Mixed":
                        ((Panel)e.Row.FindControl("pnlInformationRoundMH")).Visible = false;
                        ((Panel)e.Row.FindControl("pnlInformationRectangularMH")).Visible = false;
                        ((Panel)e.Row.FindControl("pnlInformationMixedMH")).Visible = true;
                        ((Panel)e.Row.FindControl("pnlInformationOtherMH")).Visible = false;
                        break;


                    case "Other":
                        ((Panel)e.Row.FindControl("pnlInformationRoundMH")).Visible = false;
                        ((Panel)e.Row.FindControl("pnlInformationRectangularMH")).Visible = false;
                        ((Panel)e.Row.FindControl("pnlInformationMixedMH")).Visible = false;
                        ((Panel)e.Row.FindControl("pnlInformationOtherMH")).Visible = true;
                        break;

                    default:
                        ((Panel)e.Row.FindControl("pnlInformationRoundMH")).Visible = false;
                        ((Panel)e.Row.FindControl("pnlInformationRectangularMH")).Visible = false;
                        ((Panel)e.Row.FindControl("pnlInformationMixedMH")).Visible = false;
                        ((Panel)e.Row.FindControl("pnlInformationOtherMH")).Visible = false;
                        break;
                }; 
            }

            // Footer rows            
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                switch (((DropDownList)e.Row.FindControl("ddlShapeAdd")).SelectedValue)
                {
                    case "Round":
                        ((Panel)e.Row.FindControl("pnlInformationRoundMHAdd")).Visible = true;
                        ((Panel)e.Row.FindControl("pnlInformationRectangularMHAdd")).Visible = false;
                        ((Panel)e.Row.FindControl("pnlInformationMixedMHAdd")).Visible = false;
                        ((Panel)e.Row.FindControl("pnlInformationOtherMHAdd")).Visible = false;
                        break;

                    case "Rectangular":
                        ((Panel)e.Row.FindControl("pnlInformationRoundMHAdd")).Visible = false;
                        ((Panel)e.Row.FindControl("pnlInformationRectangularMHAdd")).Visible = true;
                        ((Panel)e.Row.FindControl("pnlInformationMixedMHAdd")).Visible = false;
                        ((Panel)e.Row.FindControl("pnlInformationOtherMHAdd")).Visible = false;
                        break;

                    case "Mixed":
                        ((Panel)e.Row.FindControl("pnlInformationRoundMHAdd")).Visible = false;
                        ((Panel)e.Row.FindControl("pnlInformationRectangularMHAdd")).Visible = false;
                        ((Panel)e.Row.FindControl("pnlInformationMixedMHAdd")).Visible = true;
                        ((Panel)e.Row.FindControl("pnlInformationOtherMHAdd")).Visible = false;
                        break;


                    case "Other":
                        ((Panel)e.Row.FindControl("pnlInformationRoundMHAdd")).Visible = false;
                        ((Panel)e.Row.FindControl("pnlInformationRectangularMHAdd")).Visible = false;
                        ((Panel)e.Row.FindControl("pnlInformationMixedMHAdd")).Visible = false;
                        ((Panel)e.Row.FindControl("pnlInformationOtherMHAdd")).Visible = true;
                        break;

                    default:
                        ((Panel)e.Row.FindControl("pnlInformationRoundMHAdd")).Visible = false;
                        ((Panel)e.Row.FindControl("pnlInformationRectangularMHAdd")).Visible = false;
                        ((Panel)e.Row.FindControl("pnlInformationMixedMHAdd")).Visible = false;
                        ((Panel)e.Row.FindControl("pnlInformationOtherMHAdd")).Visible = false;
                        break;
                }; 

                //int companyId = Int32.Parse(hdfCompanyId.Value);
                //string lastShape = "";                

                //// ... load last shape used at the grid
                //foreach (GridViewRow row in grdAddManholeNew.Rows)
                //{
                //    lastShape = ((TextBox)row.FindControl("tbxShape")).Text;                    
                //}
                               
                //if (lastShape != "")
                //{
                //    ((DropDownList)e.Row.FindControl("ddlShapeAdd")).SelectedValue = lastShape;
                //}
                //else
                //{
                //    ((DropDownList)e.Row.FindControl("ddlShapeAdd")).SelectedIndex = 0;
                //}                
            }
        }



        protected void grdAddManholeNew_RowCreated(object sender, GridViewRowEventArgs e)
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

                AjaxControlToolkit.AutoCompleteExtender ace = (AjaxControlToolkit.AutoCompleteExtender)e.Row.FindControl("ace");
                if (ace != null)
                {
                    ace.ContextKey = hdfCountryId.Value + "," + provinceId + "," + countyId + "," + cityId + "," + hdfCompanyId.Value;
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



        protected void cvMhIdFooter_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Validate if mh already exists 
            int companyId = Int32.Parse(hdfCompanyId.Value);
            string mhId = ((TextBox)grdAddManholeNew.FooterRow.FindControl("tbxMhIdAdd")).Text;
            Int64? countryId = null; if (hdfCountryId.Value != "0") countryId = Int64.Parse(hdfCountryId.Value);
            Int64? provinceId = null; if (hdfProvinceId.Value != "0") provinceId = Int64.Parse(hdfProvinceId.Value);
            Int64? countyId = null; if (hdfCountyId.Value != "0") countyId = Int64.Parse(hdfCountyId.Value);
            Int64? cityId = null; if (hdfCityId.Value != "0") cityId = Int64.Parse(hdfCityId.Value);
            int projectId = Convert.ToInt32(ddlProject.SelectedValue);

            string latitud = ((TextBox)grdAddManholeNew.FooterRow.FindControl("tbxLatitudeAdd")).Text;
            string longitude = ((TextBox)grdAddManholeNew.FooterRow.FindControl("tbxLongitudeAdd")).Text;
            string address = ((TextBox)grdAddManholeNew.FooterRow.FindControl("tbxStreetAdd")).Text;

            AssetSewerMHGateway assetSewerMhGateway = new AssetSewerMHGateway();
            assetSewerMhGateway.LoadByCountryIdProvinceIdCountyIdCityIdMhId(countryId, provinceId, countyId, cityId, mhId, companyId, latitud, longitude, address);

            if (assetSewerMhGateway.Table.Rows.Count > 0)
            {
                int assetIdMh = assetSewerMhGateway.GetAssetID(mhId);

                if (assetSewerMhGateway.IsUsedInMHProject(projectId, assetIdMh))
                {
                    args.IsValid = false;
                }
                else
                {
                    assetSewerMhGateway.LoadTop1ByMhIdProjectId(mhId, Convert.ToInt32(ddlProject.SelectedValue), companyId);

                    if (assetSewerMhGateway.Table.Rows.Count > 0)
                    {
                        args.IsValid = false;
                    }
                    else
                    {
                        args.IsValid = true;
                    }
                }
            }
            else
            {
                args.IsValid = true;
            }

            //AssetSewerMHGateway assetSewerMHGateway = new AssetSewerMHGateway();

            //if (ddlProject.SelectedIndex != 0)
            //{
            //    assetSewerMHGateway.LoadTop1ByMhIdProjectId(mhId, Convert.ToInt32(ddlProject.SelectedValue), companyId);
            //}
            //else
            //{
            //    assetSewerMHGateway.LoadTop1ByMhId(mhId, companyId);
            //}

            //if (assetSewerMHGateway.Table.Rows.Count > 0)
            //{
            //    args.IsValid = false;                
            //}
            //else
            //{
            //    args.IsValid = true;
            //}
        }



        protected void cvRehabilitationDataChimneyDiameterEdit_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Trim() != "")
            {
                // Initialize 
                CustomValidator cvRehabilitationDataChimneyDiameterEdit = (CustomValidator)source;
                GridViewRow gridRow = (GridViewRow)cvRehabilitationDataChimneyDiameterEdit.NamingContainer;

                string shapeEdit = ((DropDownList)gridRow.FindControl("ddlShapeEdit")).SelectedValue;          
                
                args.IsValid = true;

                // Control of format
                if ((!Distance.IsValidDistance(args.Value)) && (shapeEdit == "Round"))
                {
                    cvRehabilitationDataChimneyDiameterEdit.Text = "Invalid format. (please use X'Y\", or X\", or Xft Yin, or X.Y, or X.Ym, or X.Ymm)";
                    args.IsValid = false;                    
                }

                // Control of distance > 0
                if ((args.IsValid) && (shapeEdit == "Round"))
                {
                    Distance distance = new Distance(args.Value);
                    if (distance.ToDoubleInEng3() < 0)
                    {
                        cvRehabilitationDataChimneyDiameterEdit.Text = "Invalid measurement. (must be equal or greater than 0)";
                        args.IsValid = false;
                    }
                }
            }
        }



        protected void cvRehabilitationDataChimneyDepthEdit_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Trim() != "")
            {
                // Initialize 
                CustomValidator cvRehabilitationDataChimneyDepthEdit = (CustomValidator)source;
                GridViewRow gridRow = (GridViewRow)cvRehabilitationDataChimneyDepthEdit.NamingContainer;

                string shapeEdit = ((DropDownList)gridRow.FindControl("ddlShapeEdit")).SelectedValue;        

                args.IsValid = true;

                // Control of format
                if ((!Distance.IsValidDistance(args.Value)) && (shapeEdit == "Round"))
                {
                    cvRehabilitationDataChimneyDepthEdit.Text = "Invalid format. (please use X'Y\", or Xft Yin, or X.Y, or X.Ym, or X.Ymm)";
                    args.IsValid = false;
                }

                // Control of distance > 0
                if ((args.IsValid) && (shapeEdit == "Round"))
                {
                    Distance distance = new Distance(args.Value);
                    if (distance.ToDoubleInEng3() < 0)
                    {
                        cvRehabilitationDataChimneyDepthEdit.Text = "Invalid measurement. (must be equal or greater than 0)";
                        args.IsValid = false;
                    }
                }
            }
        }



        protected void cvRehabilitationDataBarrelDiameterEdit_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Trim() != "")
            {
                // Initialize 
                CustomValidator cvRehabilitationDataBarrelDiameterEdit = (CustomValidator)source;
                GridViewRow gridRow = (GridViewRow)cvRehabilitationDataBarrelDiameterEdit.NamingContainer;

                string shapeEdit = ((DropDownList)gridRow.FindControl("ddlShapeEdit")).SelectedValue; 

                args.IsValid = true;

                // Control of format
                if ((!Distance.IsValidDistance(args.Value)) && (shapeEdit == "Round"))
                {
                    cvRehabilitationDataBarrelDiameterEdit.Text = "Invalid format. (please use X'Y\", or Xft Yin, or X.Y, or X.Ym, or X.Ymm)";
                    args.IsValid = false;                }

                // Control of distance > 0
                if ((args.IsValid) && (shapeEdit == "Round"))
                {
                    Distance distance = new Distance(args.Value);
                    if (distance.ToDoubleInEng3() < 0)
                    {
                        cvRehabilitationDataBarrelDiameterEdit.Text = "Invalid measurement. (must be equal or greater than 0)";
                        args.IsValid = false;
                    }
                }
            }
        }



        protected void cvRehabilitationDataBarrelDepthEdit_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Trim() != "")
            {
                // Initialize 
                CustomValidator cvRehabilitationDataBarrelDepthEdit = (CustomValidator)source;
                GridViewRow gridRow = (GridViewRow)cvRehabilitationDataBarrelDepthEdit.NamingContainer;

                string shapeEdit = ((DropDownList)gridRow.FindControl("ddlShapeEdit")).SelectedValue; 

                args.IsValid = true;

                // Control of format
                if ((!Distance.IsValidDistance(args.Value)) && (shapeEdit == "Round"))
                {
                    cvRehabilitationDataBarrelDepthEdit.Text = "Invalid format. (please use X'Y\", or Xft Yin, or X.Y, or X.Ym, or X.Ymm)";
                    args.IsValid = false;
                }

                // Control of distance > 0
                if ((args.IsValid) && (shapeEdit == "Round"))
                {
                    Distance distance = new Distance(args.Value);
                    if (distance.ToDoubleInEng3() < 0)
                    {
                        cvRehabilitationDataBarrelDepthEdit.Text = "Invalid measurement. (must be equal or greater than 0)";
                        args.IsValid = false;
                    }
                }
            }
        }



        protected void cvRehabilitationDataRectangle1LongSideEdit_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Trim() != "")
            {
                // Initialize 
                CustomValidator cvRehabilitationDataRectangle1LongSideEdit = (CustomValidator)source;
                GridViewRow gridRow = (GridViewRow)cvRehabilitationDataRectangle1LongSideEdit.NamingContainer;

                string shapeEdit = ((DropDownList)gridRow.FindControl("ddlShapeEdit")).SelectedValue; 

                args.IsValid = true;

                // Control of format
                if ((!Distance.IsValidDistance(args.Value)) && (shapeEdit == "Rectangular"))
                {
                    cvRehabilitationDataRectangle1LongSideEdit.Text = "Invalid format. (please use X'Y\", or Xft Yin, or X.Y, or X.Ym, or X.Ymm)";
                    args.IsValid = false;
                }

                // Control of distance > 0
                if ((args.IsValid) && (shapeEdit == "Rectangular"))
                {
                    Distance distance = new Distance(args.Value);
                    if (distance.ToDoubleInEng3() < 0)
                    {
                        cvRehabilitationDataRectangle1LongSideEdit.Text = "Invalid measurement. (must be equal or greater than 0)";
                        args.IsValid = false;
                    }
                }
            }
        }



        protected void cvRehabilitationDataRectangle1ShortSideEdit_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Trim() != "")
            {
                // Initialize 
                CustomValidator cvRehabilitationDataRectangle1ShortSideEdit = (CustomValidator)source;
                GridViewRow gridRow = (GridViewRow)cvRehabilitationDataRectangle1ShortSideEdit.NamingContainer;

                string shapeEdit = ((DropDownList)gridRow.FindControl("ddlShapeEdit")).SelectedValue; 

                args.IsValid = true;

                // Control of format
                if ((!Distance.IsValidDistance(args.Value)) && (shapeEdit == "Rectangular"))
                {
                    cvRehabilitationDataRectangle1ShortSideEdit.Text = "Invalid format. (please use X'Y\", or Xft Yin, or X.Y, or X.Ym, or X.Ymm)";
                    args.IsValid = false;
                }

                // Control of distance > 0
                if ((args.IsValid) && (shapeEdit == "Rectangular"))
                {
                    Distance distance = new Distance(args.Value);
                    if (distance.ToDoubleInEng3() < 0)
                    {
                        cvRehabilitationDataRectangle1ShortSideEdit.Text = "Invalid measurement. (must be equal or greater than 0)";
                        args.IsValid = false;
                    }
                }
            }
        }



        protected void cvRehabilitationDataRectangle1DepthEdit_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Trim() != "")
            {
                // Initialize 
                CustomValidator cvRehabilitationDataRectangle1DepthEdit = (CustomValidator)source;
                GridViewRow gridRow = (GridViewRow)cvRehabilitationDataRectangle1DepthEdit.NamingContainer;

                string shapeEdit = ((DropDownList)gridRow.FindControl("ddlShapeEdit")).SelectedValue;

                args.IsValid = true;

                // Control of format
                if ((!Distance.IsValidDistance(args.Value)) && (shapeEdit == "Rectangular"))
                {
                    cvRehabilitationDataRectangle1DepthEdit.Text = "Invalid format. (please use X'Y\", or Xft Yin, or X.Y, or X.Ym, or X.Ymm)";
                    args.IsValid = false;
                }

                // Control of distance > 0
                if ((args.IsValid) && (shapeEdit == "Rectangular"))
                {
                    Distance distance = new Distance(args.Value);
                    if (distance.ToDoubleInEng3() < 0)
                    {
                        cvRehabilitationDataRectangle1DepthEdit.Text = "Invalid measurement. (must be equal or greater than 0)";
                        args.IsValid = false;
                    }
                }
            }
        }



        protected void cvRehabilitationDataRectangle2LongSideEdit_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Trim() != "")
            {
                // Initialize 
                CustomValidator cvRehabilitationDataRectangle2LongSideEdit = (CustomValidator)source;
                GridViewRow gridRow = (GridViewRow)cvRehabilitationDataRectangle2LongSideEdit.NamingContainer;

                string shapeEdit = ((DropDownList)gridRow.FindControl("ddlShapeEdit")).SelectedValue;

                args.IsValid = true;

                // Control of format
                if ((!Distance.IsValidDistance(args.Value)) && (shapeEdit == "Rectangular"))
                {
                    cvRehabilitationDataRectangle2LongSideEdit.Text = "Invalid format. (please use X'Y\", or Xft Yin, or X.Y, or X.Ym, or X.Ymm)";
                    args.IsValid = false;
                }

                // Control of distance > 0
                if ((args.IsValid) && (shapeEdit == "Rectangular"))
                {
                    Distance distance = new Distance(args.Value);
                    if (distance.ToDoubleInEng3() < 0)
                    {
                        cvRehabilitationDataRectangle2LongSideEdit.Text = "Invalid measurement. (must be equal or greater than 0)";
                        args.IsValid = false;
                    }
                }
            }
        }



        protected void cvRehabilitationDataRectangle2ShortSideEdit_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Trim() != "")
            {
                // Initialize 
                CustomValidator cvRehabilitationDataRectangle2ShortSideEdit = (CustomValidator)source;
                GridViewRow gridRow = (GridViewRow)cvRehabilitationDataRectangle2ShortSideEdit.NamingContainer;

                string shapeEdit = ((DropDownList)gridRow.FindControl("ddlShapeEdit")).SelectedValue;

                args.IsValid = true;

                // Control of format
                if ((!Distance.IsValidDistance(args.Value)) && (shapeEdit == "Rectangular"))
                {
                    cvRehabilitationDataRectangle2ShortSideEdit.Text = "Invalid format. (please use X'Y\", or Xft Yin, or X.Y, or X.Ym, or X.Ymm)";
                    args.IsValid = false;
                }

                // Control of distance > 0
                if ((args.IsValid) && (shapeEdit == "Rectangular"))
                {
                    Distance distance = new Distance(args.Value);
                    if (distance.ToDoubleInEng3() < 0)
                    {
                        cvRehabilitationDataRectangle2ShortSideEdit.Text = "Invalid measurement. (must be equal or greater than 0)";
                        args.IsValid = false;
                    }
                }
            }
        }



        protected void cvRehabilitationDataRectangle2DepthEdit_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Trim() != "")
            {
                // Initialize 
                CustomValidator cvRehabilitationDataRectangle2DepthEdit = (CustomValidator)source;
                GridViewRow gridRow = (GridViewRow)cvRehabilitationDataRectangle2DepthEdit.NamingContainer;

                string shapeEdit = ((DropDownList)gridRow.FindControl("ddlShapeEdit")).SelectedValue;

                args.IsValid = true;

                // Control of format
                if ((!Distance.IsValidDistance(args.Value)) && (shapeEdit == "Rectangular"))
                {
                    cvRehabilitationDataRectangle2DepthEdit.Text = "Invalid format. (please use X'Y\", or Xft Yin, or X.Y, or X.Ym, or X.Ymm)";
                    args.IsValid = false;
                }

                // Control of distance > 0
                if ((args.IsValid) && (shapeEdit == "Rectangular"))
                {
                    Distance distance = new Distance(args.Value);
                    if (distance.ToDoubleInEng3() < 0)
                    {
                        cvRehabilitationDataRectangle2DepthEdit.Text = "Invalid measurement. (must be equal or greater than 0)";
                        args.IsValid = false;
                    }
                }
            }
        }



        protected void cvRehabilitationDataRoundDiameterEdit_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Trim() != "")
            {
                // Initialize 
                CustomValidator cvRehabilitationDataRoundDiameterEdit = (CustomValidator)source;
                GridViewRow gridRow = (GridViewRow)cvRehabilitationDataRoundDiameterEdit.NamingContainer;

                string shapeEdit = ((DropDownList)gridRow.FindControl("ddlShapeEdit")).SelectedValue;
                args.IsValid = true;

                // Control of format
                if ((!Distance.IsValidDistance(args.Value)) && (shapeEdit == "Mixed"))
                {
                    cvRehabilitationDataRoundDiameterEdit.Text = "Invalid format. (please use X'Y\", or Xft Yin, or X.Y, or X.Ym, or X.Ymm)";
                    args.IsValid = false;
                }

                // Control of distance > 0
                if ((args.IsValid) && (shapeEdit == "Mixed"))
                {
                    Distance distance = new Distance(args.Value);
                    if (distance.ToDoubleInEng3() < 0)
                    {
                        cvRehabilitationDataRoundDiameterEdit.Text = "Invalid measurement. (must be equal or greater than 0)";
                        args.IsValid = false;
                    }
                }
            }
        }



        protected void cvRehabilitationDataRoundDepthEdit_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Trim() != "")
            {
                // Initialize 
                CustomValidator cvRehabilitationDataRoundDepthEdit = (CustomValidator)source;
                GridViewRow gridRow = (GridViewRow)cvRehabilitationDataRoundDepthEdit.NamingContainer;

                string shapeEdit = ((DropDownList)gridRow.FindControl("ddlShapeEdit")).SelectedValue;

                args.IsValid = true;

                // Control of format
                if ((!Distance.IsValidDistance(args.Value)) && (shapeEdit == "Mixed"))
                {
                    cvRehabilitationDataRoundDepthEdit.Text = "Invalid format. (please use X'Y\", or Xft Yin, or X.Y, or X.Ym, or X.Ymm)";
                    args.IsValid = false;
                }

                // Control of distance > 0
                if ((args.IsValid) && (shapeEdit == "Mixed"))
                {
                    Distance distance = new Distance(args.Value);
                    if (distance.ToDoubleInEng3() < 0)
                    {
                        cvRehabilitationDataRoundDepthEdit.Text = "Invalid measurement. (must be equal or greater than 0)";
                        args.IsValid = false;
                    }
                }
            }
        }



        protected void cvRehabilitationDataRectangleLongSideEdit_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Trim() != "")
            {
                // Initialize 
                CustomValidator cvRehabilitationDataRectangleLongSideEdit = (CustomValidator)source;
                GridViewRow gridRow = (GridViewRow)cvRehabilitationDataRectangleLongSideEdit.NamingContainer;

                string shapeEdit = ((DropDownList)gridRow.FindControl("ddlShapeEdit")).SelectedValue;

                args.IsValid = true;

                // Control of format
                if ((!Distance.IsValidDistance(args.Value)) && (shapeEdit == "Mixed"))
                {
                    cvRehabilitationDataRectangleLongSideEdit.Text = "Invalid format. (please use X'Y\", or Xft Yin, or X.Y, or X.Ym, or X.Ymm)";
                    args.IsValid = false;
                }

                // Control of distance > 0
                if ((args.IsValid) && (shapeEdit == "Mixed"))
                {
                    Distance distance = new Distance(args.Value);
                    if (distance.ToDoubleInEng3() < 0)
                    {
                        cvRehabilitationDataRectangleLongSideEdit.Text = "Invalid measurement. (must be equal or greater than 0)";
                        args.IsValid = false;
                    }
                }
            }
        }



        protected void cvRehabilitationDataRectangleShortSideEdit_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Trim() != "")
            {
                // Initialize 
                CustomValidator cvRehabilitationDataRectangleShortSideEdit = (CustomValidator)source;
                GridViewRow gridRow = (GridViewRow)cvRehabilitationDataRectangleShortSideEdit.NamingContainer;

                string shapeEdit = ((DropDownList)gridRow.FindControl("ddlShapeEdit")).SelectedValue;

                args.IsValid = true;

                // Control of format
                if ((!Distance.IsValidDistance(args.Value)) && (shapeEdit == "Mixed"))
                {
                    cvRehabilitationDataRectangleShortSideEdit.Text = "Invalid format. (please use X'Y\", or Xft Yin, or X.Y, or X.Ym, or X.Ymm)";
                    args.IsValid = false;
                }

                // Control of distance > 0
                if ((args.IsValid) && (shapeEdit == "Mixed"))
                {
                    Distance distance = new Distance(args.Value);
                    if (distance.ToDoubleInEng3() < 0)
                    {
                        cvRehabilitationDataRectangleShortSideEdit.Text = "Invalid measurement. (must be equal or greater than 0)";
                        args.IsValid = false;
                    }
                }
            }
        }



        protected void cvRehabilitationDataRectangleDepthEdit_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Trim() != "")
            {
                // Initialize 
                CustomValidator cvRehabilitationDataRectangleDepthEdit = (CustomValidator)source;
                GridViewRow gridRow = (GridViewRow)cvRehabilitationDataRectangleDepthEdit.NamingContainer;

                string shapeEdit = ((DropDownList)gridRow.FindControl("ddlShapeEdit")).SelectedValue;

                args.IsValid = true;

                // Control of format
                if ((!Distance.IsValidDistance(args.Value)) && (shapeEdit == "Mixed"))
                {
                    cvRehabilitationDataRectangleDepthEdit.Text = "Invalid format. (please use X'Y\", or Xft Yin, or X.Y, or X.Ym, or X.Ymm)";
                    args.IsValid = false;
                }

                // Control of distance > 0
                if ((args.IsValid) && (shapeEdit == "Mixed"))
                {
                    Distance distance = new Distance(args.Value);
                    if (distance.ToDoubleInEng3() < 0)
                    {
                        cvRehabilitationDataRectangleDepthEdit.Text = "Invalid measurement. (must be equal or greater than 0)";
                        args.IsValid = false;
                    }
                }
            }
        }



        protected void cvRehabilitationDataOtherStructureEdit_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Trim() != "")
            {
                // Initialize 
                CustomValidator cvRehabilitationDataOtherStructureEdit = (CustomValidator)source;
                GridViewRow gridRow = (GridViewRow)cvRehabilitationDataOtherStructureEdit.NamingContainer;

                string shapeEdit = ((DropDownList)gridRow.FindControl("ddlShapeEdit")).SelectedValue;

                args.IsValid = true;

                // Control of format
                if ((!Distance.IsValidDistance(args.Value)) && (shapeEdit == "Other"))
                {
                    cvRehabilitationDataOtherStructureEdit.Text = "Invalid format. (please use X'Y\", or Xft Yin, or X.Y, or X.Ym, or X.Ymm)";
                    args.IsValid = false;
                }

                // Control of distance > 0
                if ((args.IsValid) && (shapeEdit == "Other"))
                {
                    Distance distance = new Distance(args.Value);
                    if (distance.ToDoubleInEng3() < 0)
                    {
                        cvRehabilitationDataOtherStructureEdit.Text = "Invalid measurement. (must be equal or greater than 0)";
                        args.IsValid = false;
                    }
                }
            }
        }


        
        protected void ddlShapeEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                mWizard2 master = (mWizard2)this.Master;
                ScriptManager scriptManager = (ScriptManager)master.FindControl("ScriptManager1");

                if (scriptManager.IsInAsyncPostBack)
                {
                    // cast DropDownList control which has initiated the call:
                    DropDownList ddlShape = (DropDownList)sender;

                    foreach (GridViewRow row in grdAddManholeNew.Rows)
                    {
                        DropDownList ddlShape2 = (DropDownList)row.FindControl("ddlShapeEdit");

                        switch (ddlShape2.SelectedValue)
                        {
                            case "Round":
                                ((Panel)row.FindControl("pnlInformationRoundMHEdit")).Visible = true;
                                ((Panel)row.FindControl("pnlInformationRectangularMHEdit")).Visible = false;
                                ((Panel)row.FindControl("pnlInformationMixedMHEdit")).Visible = false;
                                ((Panel)row.FindControl("pnlInformationOtherMHEdit")).Visible = false;                                    
                                break;

                            case "Rectangular":
                                ((Panel)row.FindControl("pnlInformationRoundMHEdit")).Visible = false;
                                ((Panel)row.FindControl("pnlInformationRectangularMHEdit")).Visible = true;
                                ((Panel)row.FindControl("pnlInformationMixedMHEdit")).Visible = false;
                                ((Panel)row.FindControl("pnlInformationOtherMHEdit")).Visible = false;    
                                break;

                            case "Mixed":
                                ((Panel)row.FindControl("pnlInformationRoundMHEdit")).Visible = false;
                                ((Panel)row.FindControl("pnlInformationRectangularMHEdit")).Visible = false;
                                ((Panel)row.FindControl("pnlInformationMixedMHEdit")).Visible = true;
                                ((Panel)row.FindControl("pnlInformationOtherMHEdit")).Visible = false;    
                                break;


                            case "Other":
                                ((Panel)row.FindControl("pnlInformationRoundMHEdit")).Visible = false;
                                ((Panel)row.FindControl("pnlInformationRectangularMHEdit")).Visible = false;
                                ((Panel)row.FindControl("pnlInformationMixedMHEdit")).Visible = false;
                                ((Panel)row.FindControl("pnlInformationOtherMHEdit")).Visible = true;
                                break;

                            default:
                                ((Panel)row.FindControl("pnlInformationRoundMHEdit")).Visible = false;
                                ((Panel)row.FindControl("pnlInformationRectangularMHEdit")).Visible = false;
                                ((Panel)row.FindControl("pnlInformationMixedMHEdit")).Visible = false;
                                ((Panel)row.FindControl("pnlInformationOtherMHEdit")).Visible = false;
                                break;
                        };
                    }
                }
            }
            catch
            {
            }
        }



        protected void ddlShapeAdd_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                mWizard2 master = (mWizard2)this.Master;
                ScriptManager scriptManager = (ScriptManager)master.FindControl("ScriptManager1");

                if (scriptManager.IsInAsyncPostBack)
                {
                    // cast DropDownList control which has initiated the call:
                    DropDownList ddlShape = (DropDownList)sender;
                                                               
                    switch (ddlShape.SelectedValue)
                    {
                        case "Round":
                            ((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationRoundMHAdd")).Visible = true;
                            ((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationRectangularMHAdd")).Visible = false;
                            ((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationMixedMHAdd")).Visible = false;
                            ((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationOtherMHAdd")).Visible = false;
                            break;

                        case "Rectangular":
                            ((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationRoundMHAdd")).Visible = false;
                            ((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationRectangularMHAdd")).Visible = true;
                            ((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationMixedMHAdd")).Visible = false;
                            ((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationOtherMHAdd")).Visible = false;
                            break;

                        case "Mixed":
                            ((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationRoundMHAdd")).Visible = false;
                            ((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationRectangularMHAdd")).Visible = false;
                            ((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationMixedMHAdd")).Visible = true;
                            ((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationOtherMHAdd")).Visible = false;
                            break;


                        case "Other":
                            ((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationRoundMHAdd")).Visible = false;
                            ((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationRectangularMHAdd")).Visible = false;
                            ((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationMixedMHAdd")).Visible = false;
                            ((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationOtherMHAdd")).Visible = true;
                            break;

                        default:
                            ((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationRoundMHAdd")).Visible = false;
                            ((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationRectangularMHAdd")).Visible = false;
                            ((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationMixedMHAdd")).Visible = false;
                            ((Panel)grdAddManholeNew.FooterRow.FindControl("pnlInformationOtherMHAdd")).Visible = false;
                            break;
                    };                    
                }
            }
            catch
            {
            }
        }



        protected void tbxMhIdAdd_TextChanged(object sender, EventArgs e)
        {
            try
            {
                mWizard2 master = (mWizard2)this.Master;
                ScriptManager scriptManager = (ScriptManager)master.FindControl("ScriptManager1");

                if (scriptManager.IsInAsyncPostBack)
                {
                    // cast DropDownList control which has initiated the call:
                    TextBox tbxMhIdAdd = (TextBox)sender;

                    int companyId = Int32.Parse(hdfCompanyId.Value);
                    string mhId = tbxMhIdAdd.Text;

                    Int64? countryId = null; if (hdfCountryId.Value != "0") countryId = Int64.Parse(hdfCountryId.Value);
                    Int64? provinceId = null; if (hdfProvinceId.Value != "0") provinceId = Int64.Parse(hdfProvinceId.Value);
                    Int64? countyId = null; if (hdfCountyId.Value != "0") countyId = Int64.Parse(hdfCountyId.Value);
                    Int64? cityId = null; if (hdfCityId.Value != "0") cityId = Int64.Parse(hdfCityId.Value);

                    AssetSewerMHGateway assetSewerMHGateway = new AssetSewerMHGateway();
                    assetSewerMHGateway.LoadByCountryIdProvinceIdCountyIdCityIdMhId(countryId, provinceId, countyId, cityId, mhId, companyId, "", "", ""); //TODO MH

                    if (assetSewerMHGateway.Table.Rows.Count > 0)
                    {
                        ((TextBox)grdAddManholeNew.FooterRow.FindControl("tbxStreetAdd")).Text = assetSewerMHGateway.GetAddress(mhId);
                        ((TextBox)grdAddManholeNew.FooterRow.FindControl("tbxLatitudeAdd")).Text = assetSewerMHGateway.GetLatitude(mhId);
                        ((TextBox)grdAddManholeNew.FooterRow.FindControl("tbxLongitudeAdd")).Text = assetSewerMHGateway.GetLongitude(mhId);
                    }
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



        protected void cvRehabilitationDataChimneyDepthAdd_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Trim() != "")
            {
                // Initialize 
                CustomValidator cvRehabilitationDataChimneyDepthAdd = (CustomValidator)source;
                GridViewRow gridRow = (GridViewRow)cvRehabilitationDataChimneyDepthAdd.NamingContainer;

                string shapeAdd = ((DropDownList)gridRow.FindControl("ddlShapeAdd")).SelectedValue;

                args.IsValid = true;

                // Control of format
                if ((!Distance.IsValidDistance(args.Value)) && (shapeAdd == "Round"))
                {
                    cvRehabilitationDataChimneyDepthAdd.Text = "Invalid format. (please use X'Y\", or Xft Yin, or X.Y, or X.Ym, or X.Ymm)";
                    args.IsValid = false;
                }

                // Control of distance > 0
                if ((args.IsValid) && (shapeAdd == "Round"))
                {
                    Distance distance = new Distance(args.Value);
                    if (distance.ToDoubleInEng3() < 0)
                    {
                        cvRehabilitationDataChimneyDepthAdd.Text = "Invalid measurement. (must be equal or greater than 0)";
                        args.IsValid = false;
                    }
                }
            }
        }



        protected void cvRehabilitationDataBarrelDiameterAdd_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Trim() != "")
            {
                // Initialize 
                CustomValidator cvRehabilitationDataBarrelDiameterAdd = (CustomValidator)source;
                GridViewRow gridRow = (GridViewRow)cvRehabilitationDataBarrelDiameterAdd.NamingContainer;

                string shapeAdd = ((DropDownList)gridRow.FindControl("ddlShapeAdd")).SelectedValue;

                args.IsValid = true;

                // Control of format
                if ((!Distance.IsValidDistance(args.Value)) && (shapeAdd == "Round"))
                {
                    cvRehabilitationDataBarrelDiameterAdd.Text = "Invalid format. (please use X'Y\", or Xft Yin, or X.Y, or X.Ym, or X.Ymm)";
                    args.IsValid = false;
                }

                // Control of distance > 0
                if ((args.IsValid) && (shapeAdd == "Round"))
                {
                    Distance distance = new Distance(args.Value);
                    if (distance.ToDoubleInEng3() < 0)
                    {
                        cvRehabilitationDataBarrelDiameterAdd.Text = "Invalid measurement. (must be equal or greater than 0)";
                        args.IsValid = false;
                    }
                }
            }
        }



        protected void cvRehabilitationDataBarrelDepthAdd_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Trim() != "")
            {
                // Initialize 
                CustomValidator cvRehabilitationDataBarrelDepthAdd = (CustomValidator)source;
                GridViewRow gridRow = (GridViewRow)cvRehabilitationDataBarrelDepthAdd.NamingContainer;

                string shapeAdd = ((DropDownList)gridRow.FindControl("ddlShapeAdd")).SelectedValue;

                args.IsValid = true;

                // Control of format
                if ((!Distance.IsValidDistance(args.Value)) && (shapeAdd == "Round"))
                {
                    cvRehabilitationDataBarrelDepthAdd.Text = "Invalid format. (please use X'Y\", or Xft Yin, or X.Y, or X.Ym, or X.Ymm)";
                    args.IsValid = false;
                }

                // Control of distance > 0
                if ((args.IsValid) && (shapeAdd == "Round"))
                {
                    Distance distance = new Distance(args.Value);
                    if (distance.ToDoubleInEng3() < 0)
                    {
                        cvRehabilitationDataBarrelDepthAdd.Text = "Invalid measurement. (must be equal or greater than 0)";
                        args.IsValid = false;
                    }
                }
            }
        }



        protected void cvRehabilitationDataRectangle1LongSideAdd_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Trim() != "")
            {
                // Initialize 
                CustomValidator cvRehabilitationDataRectangle1LongSideAdd = (CustomValidator)source;
                GridViewRow gridRow = (GridViewRow)cvRehabilitationDataRectangle1LongSideAdd.NamingContainer;

                string shapeAdd = ((DropDownList)gridRow.FindControl("ddlShapeAdd")).SelectedValue;

                args.IsValid = true;

                // Control of format
                if ((!Distance.IsValidDistance(args.Value)) && (shapeAdd == "Rectangular"))
                {
                    cvRehabilitationDataRectangle1LongSideAdd.Text = "Invalid format. (please use X'Y\", or Xft Yin, or X.Y, or X.Ym, or X.Ymm)";
                    args.IsValid = false;
                }

                // Control of distance > 0
                if ((args.IsValid) && (shapeAdd == "Rectangular"))
                {
                    Distance distance = new Distance(args.Value);
                    if (distance.ToDoubleInEng3() < 0)
                    {
                        cvRehabilitationDataRectangle1LongSideAdd.Text = "Invalid measurement. (must be equal or greater than 0)";
                        args.IsValid = false;
                    }
                }
            }
        }



        protected void cvRehabilitationDataRectangle1ShortSideAdd_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Trim() != "")
            {
                // Initialize 
                CustomValidator cvRehabilitationDataRectangle1ShortSideAdd = (CustomValidator)source;
                GridViewRow gridRow = (GridViewRow)cvRehabilitationDataRectangle1ShortSideAdd.NamingContainer;

                string shapeAdd = ((DropDownList)gridRow.FindControl("ddlShapeAdd")).SelectedValue;

                args.IsValid = true;

                // Control of format
                if ((!Distance.IsValidDistance(args.Value)) && (shapeAdd == "Rectangular"))
                {
                    cvRehabilitationDataRectangle1ShortSideAdd.Text = "Invalid format. (please use X'Y\", or Xft Yin, or X.Y, or X.Ym, or X.Ymm)";
                    args.IsValid = false;
                }

                // Control of distance > 0
                if ((args.IsValid) && (shapeAdd == "Rectangular"))
                {
                    Distance distance = new Distance(args.Value);
                    if (distance.ToDoubleInEng3() < 0)
                    {
                        cvRehabilitationDataRectangle1ShortSideAdd.Text = "Invalid measurement. (must be equal or greater than 0)";
                        args.IsValid = false;
                    }
                }
            }
        }



        protected void cvRehabilitationDataRectangle1DepthAdd_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Trim() != "")
            {
                // Initialize 
                CustomValidator cvRehabilitationDataRectangle1DepthAdd = (CustomValidator)source;
                GridViewRow gridRow = (GridViewRow)cvRehabilitationDataRectangle1DepthAdd.NamingContainer;

                string shapeAdd = ((DropDownList)gridRow.FindControl("ddlShapeAdd")).SelectedValue;

                args.IsValid = true;

                // Control of format
                if ((!Distance.IsValidDistance(args.Value)) && (shapeAdd == "Rectangular"))
                {
                    cvRehabilitationDataRectangle1DepthAdd.Text = "Invalid format. (please use X'Y\", or Xft Yin, or X.Y, or X.Ym, or X.Ymm)";
                    args.IsValid = false;
                }

                // Control of distance > 0
                if ((args.IsValid) && (shapeAdd == "Rectangular"))
                {
                    Distance distance = new Distance(args.Value);
                    if (distance.ToDoubleInEng3() < 0)
                    {
                        cvRehabilitationDataRectangle1DepthAdd.Text = "Invalid measurement. (must be equal or greater than 0)";
                        args.IsValid = false;
                    }
                }
            }
        }



        protected void cvRehabilitationDataRectangle2LongSideAdd_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Trim() != "")
            {
                // Initialize 
                CustomValidator cvRehabilitationDataRectangle2LongSideAdd = (CustomValidator)source;
                GridViewRow gridRow = (GridViewRow)cvRehabilitationDataRectangle2LongSideAdd.NamingContainer;

                string shapeAdd = ((DropDownList)gridRow.FindControl("ddlShapeAdd")).SelectedValue;

                args.IsValid = true;

                // Control of format
                if ((!Distance.IsValidDistance(args.Value)) && (shapeAdd == "Rectangular"))
                {
                    cvRehabilitationDataRectangle2LongSideAdd.Text = "Invalid format. (please use X'Y\", or Xft Yin, or X.Y, or X.Ym, or X.Ymm)";
                    args.IsValid = false;
                }

                // Control of distance > 0
                if ((args.IsValid) && (shapeAdd == "Rectangular"))
                {
                    Distance distance = new Distance(args.Value);
                    if (distance.ToDoubleInEng3() < 0)
                    {
                        cvRehabilitationDataRectangle2LongSideAdd.Text = "Invalid measurement. (must be equal or greater than 0)";
                        args.IsValid = false;
                    }
                }
            }
        }



        protected void cvRehabilitationDataRectangle2ShortSideAdd_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Trim() != "")
            {
                // Initialize 
                CustomValidator cvRehabilitationDataRectangle2ShortSideAdd = (CustomValidator)source;
                GridViewRow gridRow = (GridViewRow)cvRehabilitationDataRectangle2ShortSideAdd.NamingContainer;

                string shapeAdd = ((DropDownList)gridRow.FindControl("ddlShapeAdd")).SelectedValue;

                args.IsValid = true;

                // Control of format
                if ((!Distance.IsValidDistance(args.Value)) && (shapeAdd == "Rectangular"))
                {
                    cvRehabilitationDataRectangle2ShortSideAdd.Text = "Invalid format. (please use X'Y\", or Xft Yin, or X.Y, or X.Ym, or X.Ymm)";
                    args.IsValid = false;
                }

                // Control of distance > 0
                if ((args.IsValid) && (shapeAdd == "Rectangular"))
                {
                    Distance distance = new Distance(args.Value);
                    if (distance.ToDoubleInEng3() < 0)
                    {
                        cvRehabilitationDataRectangle2ShortSideAdd.Text = "Invalid measurement. (must be equal or greater than 0)";
                        args.IsValid = false;
                    }
                }
            }
        }



        protected void cvRehabilitationDataRectangle2DepthAdd_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Trim() != "")
            {
                // Initialize 
                CustomValidator cvRehabilitationDataRectangle2DepthAdd = (CustomValidator)source;
                GridViewRow gridRow = (GridViewRow)cvRehabilitationDataRectangle2DepthAdd.NamingContainer;

                string shapeAdd = ((DropDownList)gridRow.FindControl("ddlShapeAdd")).SelectedValue;

                args.IsValid = true;

                // Control of format
                if ((!Distance.IsValidDistance(args.Value)) && (shapeAdd == "Rectangular"))
                {
                    cvRehabilitationDataRectangle2DepthAdd.Text = "Invalid format. (please use X'Y\", or Xft Yin, or X.Y, or X.Ym, or X.Ymm)";
                    args.IsValid = false;
                }

                // Control of distance > 0
                if ((args.IsValid) && (shapeAdd == "Rectangular"))
                {
                    Distance distance = new Distance(args.Value);
                    if (distance.ToDoubleInEng3() < 0)
                    {
                        cvRehabilitationDataRectangle2DepthAdd.Text = "Invalid measurement. (must be equal or greater than 0)";
                        args.IsValid = false;
                    }
                }
            }
        }



        protected void cvRehabilitationDataRoundDiameterAdd_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Trim() != "")
            {
                // Initialize 
                CustomValidator cvRehabilitationDataRoundDiameterAdd = (CustomValidator)source;
                GridViewRow gridRow = (GridViewRow)cvRehabilitationDataRoundDiameterAdd.NamingContainer;

                string shapeAdd = ((DropDownList)gridRow.FindControl("ddlShapeAdd")).SelectedValue;
                args.IsValid = true;

                // Control of format
                if ((!Distance.IsValidDistance(args.Value)) && (shapeAdd == "Mixed"))
                {
                    cvRehabilitationDataRoundDiameterAdd.Text = "Invalid format. (please use X'Y\", or Xft Yin, or X.Y, or X.Ym, or X.Ymm)";
                    args.IsValid = false;
                }

                // Control of distance > 0
                if ((args.IsValid) && (shapeAdd == "Mixed"))
                {
                    Distance distance = new Distance(args.Value);
                    if (distance.ToDoubleInEng3() < 0)
                    {
                        cvRehabilitationDataRoundDiameterAdd.Text = "Invalid measurement. (must be equal or greater than 0)";
                        args.IsValid = false;
                    }
                }
            }
        }



        protected void cvRehabilitationDataRoundDepthAdd_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Trim() != "")
            {
                // Initialize 
                CustomValidator cvRehabilitationDataRoundDepthAdd = (CustomValidator)source;
                GridViewRow gridRow = (GridViewRow)cvRehabilitationDataRoundDepthAdd.NamingContainer;

                string shapeAdd = ((DropDownList)gridRow.FindControl("ddlShapeAdd")).SelectedValue;

                args.IsValid = true;

                // Control of format
                if ((!Distance.IsValidDistance(args.Value)) && (shapeAdd == "Mixed"))
                {
                    cvRehabilitationDataRoundDepthAdd.Text = "Invalid format. (please use X'Y\", or Xft Yin, or X.Y, or X.Ym, or X.Ymm)";
                    args.IsValid = false;
                }

                // Control of distance > 0
                if ((args.IsValid) && (shapeAdd == "Mixed"))
                {
                    Distance distance = new Distance(args.Value);
                    if (distance.ToDoubleInEng3() < 0)
                    {
                        cvRehabilitationDataRoundDepthAdd.Text = "Invalid measurement. (must be equal or greater than 0)";
                        args.IsValid = false;
                    }
                }
            }
        }



        protected void cvRehabilitationDataRectangleLongSideAdd_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Trim() != "")
            {
                // Initialize 
                CustomValidator cvRehabilitationDataRectangleLongSideAdd = (CustomValidator)source;
                GridViewRow gridRow = (GridViewRow)cvRehabilitationDataRectangleLongSideAdd.NamingContainer;

                string shapeAdd = ((DropDownList)gridRow.FindControl("ddlShapeAdd")).SelectedValue;

                args.IsValid = true;

                // Control of format
                if ((!Distance.IsValidDistance(args.Value)) && (shapeAdd == "Mixed"))
                {
                    cvRehabilitationDataRectangleLongSideAdd.Text = "Invalid format. (please use X'Y\", or Xft Yin, or X.Y, or X.Ym, or X.Ymm)";
                    args.IsValid = false;
                }

                // Control of distance > 0
                if ((args.IsValid) && (shapeAdd == "Mixed"))
                {
                    Distance distance = new Distance(args.Value);
                    if (distance.ToDoubleInEng3() < 0)
                    {
                        cvRehabilitationDataRectangleLongSideAdd.Text = "Invalid measurement. (must be equal or greater than 0)";
                        args.IsValid = false;
                    }
                }
            }
        }



        protected void cvRehabilitationDataRectangleShortSideAdd_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Trim() != "")
            {
                // Initialize 
                CustomValidator cvRehabilitationDataRectangleShortSideAdd = (CustomValidator)source;
                GridViewRow gridRow = (GridViewRow)cvRehabilitationDataRectangleShortSideAdd.NamingContainer;

                string shapeAdd = ((DropDownList)gridRow.FindControl("ddlShapeAdd")).SelectedValue;

                args.IsValid = true;

                // Control of format
                if ((!Distance.IsValidDistance(args.Value)) && (shapeAdd == "Mixed"))
                {
                    cvRehabilitationDataRectangleShortSideAdd.Text = "Invalid format. (please use X'Y\", or Xft Yin, or X.Y, or X.Ym, or X.Ymm)";
                    args.IsValid = false;
                }

                // Control of distance > 0
                if ((args.IsValid) && (shapeAdd == "Mixed"))
                {
                    Distance distance = new Distance(args.Value);
                    if (distance.ToDoubleInEng3() < 0)
                    {
                        cvRehabilitationDataRectangleShortSideAdd.Text = "Invalid measurement. (must be equal or greater than 0)";
                        args.IsValid = false;
                    }
                }
            }
        }



        protected void cvRehabilitationDataRectangleDepthAdd_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Trim() != "")
            {
                // Initialize 
                CustomValidator cvRehabilitationDataRectangleDepthAdd = (CustomValidator)source;
                GridViewRow gridRow = (GridViewRow)cvRehabilitationDataRectangleDepthAdd.NamingContainer;

                string shapeAdd = ((DropDownList)gridRow.FindControl("ddlShapeAdd")).SelectedValue;

                args.IsValid = true;

                // Control of format
                if ((!Distance.IsValidDistance(args.Value)) && (shapeAdd == "Mixed"))
                {
                    cvRehabilitationDataRectangleDepthAdd.Text = "Invalid format. (please use X'Y\", or Xft Yin, or X.Y, or X.Ym, or X.Ymm)";
                    args.IsValid = false;
                }

                // Control of distance > 0
                if ((args.IsValid) && (shapeAdd == "Mixed"))
                {
                    Distance distance = new Distance(args.Value);
                    if (distance.ToDoubleInEng3() < 0)
                    {
                        cvRehabilitationDataRectangleDepthAdd.Text = "Invalid measurement. (must be equal or greater than 0)";
                        args.IsValid = false;
                    }
                }
            }
        }



        protected void cvRehabilitationDataOtherStructureAdd_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Trim() != "")
            {
                // Initialize 
                CustomValidator cvRehabilitationDataOtherStructureAdd = (CustomValidator)source;
                GridViewRow gridRow = (GridViewRow)cvRehabilitationDataOtherStructureAdd.NamingContainer;

                string shapeAdd = ((DropDownList)gridRow.FindControl("ddlShapeAdd")).SelectedValue;

                args.IsValid = true;

                // Control of format
                if ((!Distance.IsValidDistance(args.Value)) && (shapeAdd == "Other"))
                {
                    cvRehabilitationDataOtherStructureAdd.Text = "Invalid format. (please use X'Y\", or Xft Yin, or X.Y, or X.Ym, or X.Ymm)";
                    args.IsValid = false;
                }

                // Control of distance > 0
                if ((args.IsValid) && (shapeAdd == "Other"))
                {
                    Distance distance = new Distance(args.Value);
                    if (distance.ToDoubleInEng3() < 0)
                    {
                        cvRehabilitationDataOtherStructureAdd.Text = "Invalid measurement. (must be equal or greater than 0)";
                        args.IsValid = false;
                    }
                }
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP1 - NEW SECTION - METHODS
        //

        private void StepBeginIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Please create new manhole";

            // grid
            grdAddManholeNew.DataBind();
        }



        private bool StepBeginNext()
        {
             Page.Validate("Begin");

            if (Page.IsValid)
            {
                // Gridview, if the gridview is edition mode
                if (grdAddManholeNew.EditIndex >= 0)
                {
                    grdAddManholeNew.UpdateRow(grdAddManholeNew.EditIndex, true);
                    grdAddManholeNew.DataBind();
                }

                // Add if exists at footer
                if (ValidateManholeFooter())
                {
                    GrdAddManholeNewAdd();
                }

                // Store tables
                Session["addManholeNew"] = addManholeTDS.AddManholeNew;
                Session["addManholeTDS"] = addManholeTDS;
                return true;
            }
            else
            {
                return false;            
            }            
        }



        private bool StepBeginPrevious()
        {
            return true;
        }




        private bool ValidateManholeFooter()
        {
            string mhId = ((TextBox)grdAddManholeNew.FooterRow.FindControl("tbxMhIdAdd")).Text.Trim();
            string street = ((TextBox)grdAddManholeNew.FooterRow.FindControl("tbxStreetAdd")).Text.Trim();
            string latitude = ((TextBox)grdAddManholeNew.FooterRow.FindControl("tbxLatitudeAdd")).Text.Trim();
            string longitude = ((TextBox)grdAddManholeNew.FooterRow.FindControl("tbxLongitudeAdd")).Text.Trim();
            string shape = ((DropDownList)grdAddManholeNew.FooterRow.FindControl("ddlShapeAdd")).SelectedValue;
            string location = ((DropDownList)grdAddManholeNew.FooterRow.FindControl("ddlLocationAdd")).SelectedValue;            
            int materialId = Int32.Parse(((DropDownList)grdAddManholeNew.FooterRow.FindControl("ddlMaterialAdd")).SelectedValue);

            if (( mhId != "") && ((street != "") || (latitude != "") || (longitude != "") || (shape != "") || (location != "") || (materialId != -1)))
            {
                return true;
            }

            return false;
        }



        private void GrdAddManholeNewAdd()
        {
            if (ValidateManholeFooter())
            {
                Page.Validate("AddManholeAdd");
                if (Page.IsValid)
                {
                    int companyId = Int32.Parse(hdfCompanyId.Value);
                    string mhId = ((TextBox)grdAddManholeNew.FooterRow.FindControl("tbxMhIdAdd")).Text.Trim();
                    string street = ((TextBox)grdAddManholeNew.FooterRow.FindControl("tbxStreetAdd")).Text.Trim();
                    string latitude = ((TextBox)grdAddManholeNew.FooterRow.FindControl("tbxLatitudeAdd")).Text.Trim();
                    string longitude = ((TextBox)grdAddManholeNew.FooterRow.FindControl("tbxLongitudeAdd")).Text.Trim();
                    string shape = ((DropDownList)grdAddManholeNew.FooterRow.FindControl("ddlShapeAdd")).SelectedValue;
                    string location = ((DropDownList)grdAddManholeNew.FooterRow.FindControl("ddlLocationAdd")).SelectedValue;
                    
                    int? conditionRating = null;
                    if (((DropDownList)grdAddManholeNew.FooterRow.FindControl("ddlConditioningRatingAdd")).SelectedValue != "-1")
                    {
                        conditionRating = Int32.Parse(((DropDownList)grdAddManholeNew.FooterRow.FindControl("ddlConditioningRatingAdd")).SelectedValue);
                    }

                    int materialId = Int32.Parse(((DropDownList)grdAddManholeNew.FooterRow.FindControl("ddlMaterialAdd")).SelectedValue);
                    AssetSewerMHMaterialTypeGateway assetSewerMHMaterialTypeGateway = new AssetSewerMHMaterialTypeGateway();
                    assetSewerMHMaterialTypeGateway.LoadByMaterialId(materialId, companyId);
                    string material = ""; if (assetSewerMHMaterialTypeGateway.Table.Rows.Count > 0) material = assetSewerMHMaterialTypeGateway.GetMaterialType(materialId);                
                    
                    string topDiameter = "";
                    string topDepth = "";
                    string topFloor = "";
                    string topCeiling = "";
                    string topBenching = "";
                    string downDiameter = "";
                    string downDepth = "";
                    string downFloor = "";
                    string downCeiling = "";
                    string downBenching = "";
                    string rectangle1LongSide = "";
                    string rectangle1ShortSide = "";
                    string rectangle2LongSide = "";
                    string rectangle2ShortSide = "";
                    string topSurfaceArea = "";
                    string downSurfaceArea = "";
                    int? manholeRugs = null;
                    string totalDepth = "";
                    string totalSufaceArea = "";

                    if (shape == "Round")
                    {
                        topDiameter = ((TextBox)grdAddManholeNew.FooterRow.FindControl("tbxRehabilitationDataChimneyDiameterAdd")).Text.Trim();
                        topDepth = ((TextBox)grdAddManholeNew.FooterRow.FindControl("tbxRehabilitationDataChimneyDepthAdd")).Text.Trim();
                        downDiameter = ((TextBox)grdAddManholeNew.FooterRow.FindControl("tbxRehabilitationDataBarrelDiameterAdd")).Text.Trim();
                        downDepth = ((TextBox)grdAddManholeNew.FooterRow.FindControl("tbxRehabilitationDataBarrelDepthAdd")).Text.Trim();
                        if (((DropDownList)grdAddManholeNew.FooterRow.FindControl("ddlRehabilitationDataRoundManholeRugsAdd")).SelectedValue != "-1")
                        {
                            manholeRugs = Int32.Parse(((DropDownList)grdAddManholeNew.FooterRow.FindControl("ddlRehabilitationDataRoundManholeRugsAdd")).SelectedValue);
                        }
                    }

                    if (shape == "Rectangular")
                    {
                        rectangle1LongSide = ((TextBox)grdAddManholeNew.FooterRow.FindControl("tbxRehabilitationDataRectangle1LongSideAdd")).Text.Trim();
                        rectangle1ShortSide = ((TextBox)grdAddManholeNew.FooterRow.FindControl("tbxRehabilitationDataRectangle1ShortSideAdd")).Text.Trim();
                        topDepth = ((TextBox)grdAddManholeNew.FooterRow.FindControl("tbxRehabilitationDataRectangle1DepthAdd")).Text.Trim();
                        rectangle2LongSide = ((TextBox)grdAddManholeNew.FooterRow.FindControl("tbxRehabilitationDataRectangle2LongSideAdd")).Text.Trim();
                        rectangle2ShortSide = ((TextBox)grdAddManholeNew.FooterRow.FindControl("tbxRehabilitationDataRectangle2ShortSideAdd")).Text.Trim();
                        downDepth = ((TextBox)grdAddManholeNew.FooterRow.FindControl("tbxRehabilitationDataRectangle2DepthAdd")).Text.Trim();
                        if (((DropDownList)grdAddManholeNew.FooterRow.FindControl("ddlRehabilitationDataRectangularManholeRugsAdd")).SelectedValue != "-1")
                        {
                            manholeRugs = Int32.Parse(((DropDownList)grdAddManholeNew.FooterRow.FindControl("ddlRehabilitationDataRectangularManholeRugsAdd")).SelectedValue);
                        }
                    }
                    if (shape == "Mixed")
                    {
                        topDiameter = ((TextBox)grdAddManholeNew.FooterRow.FindControl("tbxRehabilitationDataRoundDiameterAdd")).Text.Trim();
                        topDepth = ((TextBox)grdAddManholeNew.FooterRow.FindControl("tbxRehabilitationDataRoundDepthAdd")).Text.Trim();
                        rectangle2LongSide = ((TextBox)grdAddManholeNew.FooterRow.FindControl("tbxRehabilitationDataRectangleLongSideAdd")).Text.Trim();
                        rectangle2ShortSide = ((TextBox)grdAddManholeNew.FooterRow.FindControl("tbxRehabilitationDataRectangleShortSideAdd")).Text.Trim();
                        downDepth = ((TextBox)grdAddManholeNew.FooterRow.FindControl("tbxRehabilitationDataRectangleDepthAdd")).Text.Trim();
                        if (((DropDownList)grdAddManholeNew.FooterRow.FindControl("ddlRehabilitationDataMixManholeRugsAdd")).SelectedValue != "-1")
                        {
                            manholeRugs = Int32.Parse(((DropDownList)grdAddManholeNew.FooterRow.FindControl("ddlRehabilitationDataMixManholeRugsAdd")).SelectedValue);
                        }
                    }

                    if (shape == "Other")
                    {
                        totalSufaceArea = ((TextBox)grdAddManholeNew.FooterRow.FindControl("tbxRehabilitationDataOtherStructureAdd")).Text.Trim();
                    }

                    AddManholeNew model = new AddManholeNew(addManholeTDS);
                    model.Insert(mhId, longitude, latitude, street, shape, location, materialId, topDiameter, topDepth, topFloor, topCeiling, topBenching, downDiameter, downDepth, downFloor, downCeiling, downBenching, rectangle1LongSide, rectangle1ShortSide, rectangle2LongSide, rectangle2ShortSide, topSurfaceArea, downSurfaceArea, manholeRugs, totalDepth, totalSufaceArea, conditionRating, material, false, companyId);

                    Session.Remove("addManholeNewDummy");
                    Session["addManholeTDS"] = addManholeTDS;
                    Session["addManholeNew"] = addManholeTDS.AddManholeNew;

                    grdAddManholeNew.DataBind();
                    grdAddManholeNew.PageIndex = grdAddManholeNew.PageCount - 1;
                }
            }
        }



        public AddManholeTDS.AddManholeNewDataTable GetAddManholeNew()
        {
            addManholeNew = (AddManholeTDS.AddManholeNewDataTable)Session["addManholeNewDummy"];
            if (addManholeNew == null)
            {
                addManholeNew = (AddManholeTDS.AddManholeNewDataTable)Session["addManholeNew"];
            }

            return addManholeNew;
        }



        public void DummyManholeNew(int AssetID)
        {
        }



        public void DummyManholeNew()
        {
        }



        protected void AddManholeNewEmptyFix(GridView grdView)
        {
            if (grdView.Rows.Count == 0)
            {
                AddManholeTDS.AddManholeNewDataTable dt = new AddManholeTDS.AddManholeNewDataTable();
                dt.AddAddManholeNewRow(-1, "", "", "", "", false, -1, "", "", -1, "", "", "", "", "", "", "", "", "", "","","", "", "", "", "", -1, "","", -1, "", false);
                Session["addManholeNewDummy"] = dt;

                grdView.DataBind();
            }

            // normally executes at all postbacks
            if (grdView.Rows.Count == 1)
            {
                AddManholeTDS.AddManholeNewDataTable dt = (AddManholeTDS.AddManholeNewDataTable)Session["addManholeNewDummy"];
                if (dt != null)
                {
                    // hide row
                    grdView.Rows[0].Visible = false;
                    grdView.Rows[0].Controls.Clear();
                }
            }
        }       



        #endregion


        



        #region STE2 - SUMMARY

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP2 - SUMMARY
        //



        // ////////////////////////////////////////////////////////////////////////
        // STEP2 - SUMMARY - METHODS
        //

        private void StepSummaryIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Summary";

            // Initialize summary
            AddManholeNew addManholeNew = new AddManholeNew(addManholeTDS);
            tbxSummary.Text = addManholeNew.GetSummary();
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
            title.Text = "Add Manhole";
        }






        // ////////////////////////////////////////////////////////////////////////
        // METHODS
        //

        #region RegisterClientScript & TagPage

        private void RegisterClientScripts()
        {
            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./add_manholes.js");
        }



        private void TagPage()
        {
            //hdfWorkType.Value = Request.QueryString["work_type"].ToString();
            hdfCompanyId.Value = Session["companyID"].ToString();
            hdfProjectId.Value = Request.QueryString["project_id"].ToString();

            // Get ids & location
            int projectId = Int32.Parse(hdfProjectId.Value.Trim());
            ProjectGateway projectGateway = new ProjectGateway();
            projectGateway.LoadByProjectId(projectId);

            if (projectGateway.Table.Rows.Count > 0)
            {
                // ... Get ids
                Int64 currentCountry = projectGateway.GetCountryID(projectId);
                Int64? currentProvince = null; if (projectGateway.GetProvinceID(projectId).HasValue) currentProvince = (Int64)projectGateway.GetProvinceID(projectId);
                Int64? currentCounty = null; if (projectGateway.GetCountyID(projectId).HasValue) currentCounty = (Int64)projectGateway.GetCountyID(projectId);
                Int64? currentCity = null; if (projectGateway.GetCityID(projectId).HasValue) currentCity = (Int64)projectGateway.GetCityID(projectId);

                hdfCountryId.Value = currentCountry.ToString();
                hdfProvinceId.Value = currentProvince.ToString();
                hdfCountyId.Value = currentCounty.ToString();
                hdfCityId.Value = currentCity.ToString();
            }
            else
            {
                hdfCountryId.Value = "0";
                hdfProvinceId.Value = "0";
                hdfCountyId.Value = "0";
                hdfCityId.Value = "0";
            }
        }

        #endregion



        private void Save()
        {
            // save to database
            DB.Open();
            DB.BeginTransaction();
            try
            {
                Int64? country = null; if (hdfCountryId.Value != "0") country = Int64.Parse(hdfCountryId.Value);
                Int64? provinceId = null; if (hdfProvinceId.Value != "0") provinceId = Int64.Parse(hdfProvinceId.Value);
                Int64? countyId = null; if (hdfCountyId.Value != "0") countyId = Int64.Parse(hdfCountyId.Value);
                Int64? cityId = null; if (hdfCityId.Value != "0") cityId = Int64.Parse(hdfCityId.Value);
                int companyId = int.Parse(hdfCompanyId.Value);
                int projectId = int.Parse(ddlProject.SelectedValue);

                AddManholeNew model = new AddManholeNew(addManholeTDS);
                model.Save(country, provinceId, countyId, cityId, companyId, projectId);

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