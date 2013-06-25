using System;
using System.Data;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.DA.CWP.Common;
using LiquiForce.LFSLive.BL.CWP.Common;
using LiquiForce.LFSLive.Tools;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.WebUI.CWP.Common
{
    /// <summary>
    /// view_edit
    /// </summar
    public partial class view_edit : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected WorkViewTDS workViewTDS;
        protected WorkViewTDS.LFS_WORK_TYPE_VIEW_DISPLAYDataTable workTypeViewDisplay;
        protected WorkViewTDS.LFS_WORK_TYPE_VIEW_SORTDataTable workTypeViewSort;
        protected WorkViewTDS.WorkViewDisplayTempDataTable workViewDisplayTemp;
        protected WorkViewTDS.WorkViewConditionNewDataTable workViewConditionNew;
        protected WorkViewTDS.WorkViewConditionTempDataTable workViewConditionTemp;
        protected WorkViewTDS.WorkViewSortTempDataTable workViewSortTemp;
        





        // ////////////////////////////////////////////////////////////////////////
        // EVENTS
        //

        protected void Page_Load(object sender, EventArgs e)
        {
            // Register client scripts
            this.RegisterClientScripts();

            if (!IsPostBack)
            {
                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["work_type"] == null) || ((string)Request.QueryString["view_id"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in view_edit.aspx");
                }

                // Security check
                if (!(Convert.ToBoolean(Session["sgLFS_VIEWS_EDIT"])))
                {
                    if ((string)Request.QueryString["work_type"] == "Rehab Assessment")
                    {
                        if (!(Convert.ToBoolean(Session["sgLFS_CWP_REHABASSESSMENT_VIEW"])))
                        {
                            Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                        }
                    }

                    if ((string)Request.QueryString["work_type"] == "Full Length Lining")
                    {                       
                        if (!(Convert.ToBoolean(Session["sgLFS_CWP_FULLLENGTHLINING_VIEW"])))
                        {
                            Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                        }                      
                    }

                    if ((string)Request.QueryString["work_type"] == "Junction Lining")
                    {                        
                        if (!(Convert.ToBoolean(Session["sgLFS_CWP_JUNCTIONLINING_VIEW"])))
                        {
                            Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                        }
                    }

                    if ((string)Request.QueryString["work_type"] == "Point Repairs")
                    {                       
                        if (!(Convert.ToBoolean(Session["sgLFS_CWP_POINTREPAIRS_VIEW"])))
                        {
                            Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                        }                       
                    }

                    if ((string)Request.QueryString["work_type"] == "Manhole Rehabilitation")
                    {
                        if (!(Convert.ToBoolean(Session["sgLFS_CWP_MANHOLEREHABILITATION_VIEW"])))
                        {
                            Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                        }
                    }
                }

                // Tag page
                hdfWorkType.Value = (string)Request.QueryString["work_type"];
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfViewId.Value = (string)Request.QueryString["view_id"];
                hdfProjectId.Value = (string)Request.QueryString["project_id"];
                int viewId = int.Parse(hdfViewId.Value);
                int companyId = int.Parse(hdfCompanyId.Value);
                hdfUpdate.Value = "no";

                // Security check for global views
                if (!(Convert.ToBoolean(Session["sgLFS_GLOBALVIEWS_EDIT"])))
                {
                    if ((string)Request.QueryString["work_type"] == "Rehab Assessment")
                    {
                        if (Convert.ToBoolean(Session["sgLFS_CWP_REHABASSESSMENT_VIEW"]))
                        {
                            WorkViewGateway workViewGateway = new WorkViewGateway();
                            workViewGateway.LoadByViewId(Int32.Parse(hdfViewId.Value), Int32.Parse(hdfCompanyId.Value));
                            string viewType = workViewGateway.GetType(Int32.Parse(hdfViewId.Value));

                            if (viewType == "Global")
                            {
                                Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                            }
                        }
                    }

                    if ((string)Request.QueryString["work_type"] == "Full Length Lining")
                    {
                        if (Convert.ToBoolean(Session["sgLFS_CWP_FULLLENGTHLINING_VIEW"]))
                        {
                            WorkViewGateway workViewGateway = new WorkViewGateway();
                            workViewGateway.LoadByViewId(Int32.Parse(hdfViewId.Value), Int32.Parse(hdfCompanyId.Value));
                            string viewType = workViewGateway.GetType(Int32.Parse(hdfViewId.Value));

                            if (viewType == "Global")
                            {
                                Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                            }
                        }
                    }

                    if ((string)Request.QueryString["work_type"] == "Junction Lining")
                    {                        
                        if (Convert.ToBoolean(Session["sgLFS_CWP_JUNCTIONLINING_VIEW"]))
                        {
                            WorkViewGateway workViewGateway = new WorkViewGateway();
                            workViewGateway.LoadByViewId(Int32.Parse(hdfViewId.Value), Int32.Parse(hdfCompanyId.Value));
                            string viewType = workViewGateway.GetType(Int32.Parse(hdfViewId.Value));

                            if (viewType == "Global")
                            {
                                Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                            }
                        }
                    }

                    if ((string)Request.QueryString["work_type"] == "Point Repairs")
                    {                        
                        if (Convert.ToBoolean(Session["sgLFS_CWP_POINTREPAIRS_VIEW"]))
                        {
                            WorkViewGateway workViewGateway = new WorkViewGateway();
                            workViewGateway.LoadByViewId(Int32.Parse(hdfViewId.Value), Int32.Parse(hdfCompanyId.Value));
                            string viewType = workViewGateway.GetType(Int32.Parse(hdfViewId.Value));

                            if (viewType == "Global")
                            {
                                Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                            }
                        }
                    }


                    if ((string)Request.QueryString["work_type"] == "Manhole Rehabilitation")
                    {
                        if (Convert.ToBoolean(Session["sgLFS_CWP_MANHOLEREHABILITATION_VIEW"]))
                        {
                            WorkViewGateway workViewGateway = new WorkViewGateway();
                            workViewGateway.LoadByViewId(Int32.Parse(hdfViewId.Value), Int32.Parse(hdfCompanyId.Value));
                            string viewType = workViewGateway.GetType(Int32.Parse(hdfViewId.Value));

                            if (viewType == "Global")
                            {
                                Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                            }
                        }
                    }
                }                

                ViewState["columnsToDisplayPageIndex"] = 0;
                ViewState["sortPageIndex"] = 0;

                Session.Remove("workTypeViewDisplay");
                Session.Remove("workTypeViewDisplayDummy");
                Session.Remove("workViewDisplayTemp");
                Session.Remove("workViewDisplay");
                Session.Remove("workViewConditionNew");
                Session.Remove("workViewConditionTemp");
                Session.Remove("workViewConditionNewDummy");
                Session.Remove("workViewConditionTempDummy");

                // Prepare initial data
                // ... For view type
                WorkViewTypeList workViewTypeList = new WorkViewTypeList(new DataSet());
                workViewTypeList.LoadAndAddItem("(Select a type)", int.Parse(hdfCompanyId.Value));
                ddlType.DataSource = workViewTypeList.Table;
                ddlType.DataValueField = "Type";
                ddlType.DataTextField = "Type";
                ddlType.DataBind();
                ddlType.SelectedIndex = 0;

                // ... Global Views check
                if (!Convert.ToBoolean(Session["sgLFS_GLOBALVIEWS_VIEW"]))
                {
                    ddlType.Items.Remove("Global");
                }
                
                // If coming from 
                // ... ra_navigator.aspx, ra_navigator2.aspx, fl_navigator.aspx, fl_navigator2.aspx, jl_navigator.aspx, jl_navigator2.aspx, pr_navigator.aspx or pr_navigator2.aspx, , mr_navigator.aspx, mr_navigator2.aspx 
                if ((Request.QueryString["source_page"] == "ra_navigator.aspx") || (Request.QueryString["source_page"] == "ra_navigator2.aspx") || (Request.QueryString["source_page"] == "fl_navigator.aspx") || (Request.QueryString["source_page"] == "fl_navigator2.aspx") || (Request.QueryString["source_page"] == "jl_navigator.aspx") || (Request.QueryString["source_page"] == "jl_navigator2.aspx") || (Request.QueryString["source_page"] == "pr_navigator.aspx") || (Request.QueryString["source_page"] == "pr_navigator2.aspx") || (Request.QueryString["source_page"] == "mr_navigator.aspx") || (Request.QueryString["source_page"] == "mr_navigator2.aspx")) 
                {
                    // ... For Grids
                    workViewTDS = new WorkViewTDS();

                    workTypeViewDisplay = new WorkViewTDS.LFS_WORK_TYPE_VIEW_DISPLAYDataTable();
                    workTypeViewSort = new WorkViewTDS.LFS_WORK_TYPE_VIEW_SORTDataTable();
                    workViewDisplayTemp = new WorkViewTDS.WorkViewDisplayTempDataTable();
                    workViewSortTemp = new WorkViewTDS.WorkViewSortTempDataTable();
                    workViewConditionNew = new WorkViewTDS.WorkViewConditionNewDataTable();
                    workViewConditionTemp = new WorkViewTDS.WorkViewConditionTempDataTable();

                    // Initiaize view data
                    // ... Loading views and data
                    WorkViewGateway workViewGateway = new WorkViewGateway(workViewTDS);
                    workViewGateway.LoadByViewId(viewId, companyId); 
                    tbxName.Text = workViewGateway.GetName(viewId);
                    ddlType.SelectedValue = workViewGateway.GetType(viewId);

                    // ... Store datasets
                    Session["workTypeViewDisplay"] = workTypeViewDisplay;
                    Session["workTypeViewSort"] = workTypeViewSort;
                    Session["workViewDisplayTemp"] = workViewDisplayTemp;
                    Session["workViewSortTemp"] = workViewSortTemp;
                    Session["workViewConditionNew"] = workViewConditionNew;
                    Session["workViewConditionTemp"] = workViewConditionTemp;
                }

                // StepSection1In
                wzViews.ActiveStepIndex = 0;
                StepBeginIn();
            }
            else
            {
                // Restore datasets
                workViewTDS = (WorkViewTDS)Session["workViewTDS"];

                workTypeViewDisplay = (WorkViewTDS.LFS_WORK_TYPE_VIEW_DISPLAYDataTable)Session["workTypeViewDisplay"];
                workTypeViewSort = (WorkViewTDS.LFS_WORK_TYPE_VIEW_SORTDataTable)Session["workTypeViewSort"];
                workViewDisplayTemp = (WorkViewTDS.WorkViewDisplayTempDataTable)Session["workViewDisplayTemp"];
                workViewSortTemp = (WorkViewTDS.WorkViewSortTempDataTable)Session["workViewSortTemp"];
                workViewConditionNew = (WorkViewTDS.WorkViewConditionNewDataTable)Session["workViewConditionNew"];
                workViewConditionTemp = (WorkViewTDS.WorkViewConditionTempDataTable)Session["workViewConditionTemp"];
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
                switch (wzViews.ActiveStep.Name)
                {
                    case "Begin":
                        StepBeginIn();
                        break;

                    case "Columns To Display":
                        StepColumnsToDisplayIn();
                        break;

                    case "Conditions":
                        StepConditionsIn();
                        break;

                    case "Logic":
                        StepLogicIn();
                        break;

                    case "Sort By":
                        StepSortByIn();
                        break;

                    case "Summary":
                        StepSummaryIn();
                        break;

                    default:
                        throw new Exception("The option for " + wzViews.ActiveStep.Name + " step in view_edit.Wizard_ActiveStepChanged function does not exist");
                }
            }
        }



        protected void Wizard_NextButtonClick(object sender, WizardNavigationEventArgs e)
        {
            switch (wzViews.ActiveStep.Name)
            {
                case "Begin":
                    e.Cancel = !StepBeginNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "Columns To Display";
                    }
                    break;

                case "Columns To Display":
                    e.Cancel = !StepColumnsToDisplayNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "Conditions";
                    }
                    break;

                case "Conditions":
                    e.Cancel = !StepConditionsNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "Logic";
                    }
                    break;

                case "Logic":
                    e.Cancel = !StepLogicNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "Sort By";
                    }
                    break;

                case "Sort By":
                    e.Cancel = !StepSortByNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "Summary";
                    }
                    break;

                default:
                    throw new Exception("The option for " + wzViews.ActiveStep.Name + " step in view_edit.Wizard_NextButtonClick function does not exist");
            }
        }



        protected void Wizard_PreviousButtonClick(object sender, WizardNavigationEventArgs e)
        {
            switch (wzViews.ActiveStep.Name)
            {
                case "Columns To Display":
                    e.Cancel = !StepColumnsToDisplayPrevious();
                    break;

                case "Conditions":
                    e.Cancel = !StepConditionsPrevious();
                    break;

                case "Logic":
                    e.Cancel = !StepLogicPrevious();
                    break;

                case "Sort By":
                    e.Cancel = !StepSortByPrevious();
                    break;

                case "Summary":
                    e.Cancel = !StepSummaryPrevious();
                    break;

                default:
                    throw new Exception("The option for " + wzViews.ActiveStep.Name + " step in view_edit.Wizard_PreviousButtonClick function does not exist");
            }
            if (!e.Cancel)
            {
                ViewState["StepFrom"] = wzViews.ActiveStep.Name;
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
        // STEP1 - BEGIN - METHODS
        //

        private void StepBeginIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Please provide general information";

            // Tag Page
            hdfStep.Value = "StepBegin";

            if ((string)Request.QueryString["fm_type"] == "Rehab Assessment")
            {
                if (Convert.ToBoolean(Session["sgLFS_CWP_REHABASSESSMENT_VIEW"]))
                {
                    lblType.Visible = false;
                    ddlType.Visible = false;
                    ddlType.SelectedIndex = 1;
                }                
            }

            if ((string)Request.QueryString["fm_type"] == "Full Length Lining")
            {
                if (Convert.ToBoolean(Session["sgLFS_CWP_FULLLENGTHLINING_VIEW"]))
                {
                    lblType.Visible = false;
                    ddlType.Visible = false;
                    ddlType.SelectedIndex = 1;
                }               
            }

            if ((string)Request.QueryString["fm_type"] == "Junction Lining")
            {
                if (Convert.ToBoolean(Session["sgLFS_CWP_JUNCTIONLINING_VIEW"]))
                {
                    lblType.Visible = false;
                    ddlType.Visible = false;
                    ddlType.SelectedIndex = 1;
                }
            }

            if ((string)Request.QueryString["fm_type"] == "Point Repairs")
            {                
                if (Convert.ToBoolean(Session["sgLFS_CWP_POINTREPAIRS_VIEW"]))
                {
                    lblType.Visible = false;
                    ddlType.Visible = false;
                    ddlType.SelectedIndex = 1;
                }            
            }

            if ((string)Request.QueryString["fm_type"] == "Manhole Rehabilitation")
            {
                
                if (Convert.ToBoolean(Session["sgLFS_CWP_MANHOLEREHABILITATION_VIEW"]))
                {
                    lblType.Visible = false;
                    ddlType.Visible = false;
                    ddlType.SelectedIndex = 1;
                }                
            }
        }



        private bool StepBeginNext()
        {
            Page.Validate("StepBegin");

            if (Page.IsValid)
            {
                // Load
                WorkViewTDS dataSet = new WorkViewTDS();
                dataSet.LFS_WORK_TYPE_VIEW_DISPLAY.Merge(workTypeViewDisplay, true);
                WorkTypeViewDisplay model = new WorkTypeViewDisplay(dataSet);

                if (dataSet.LFS_WORK_TYPE_VIEW_DISPLAY.Rows.Count <= 0)
                {
                    model.LoadByWorkType(hdfWorkType.Value, int.Parse(hdfCompanyId.Value));
                    model.UpdateForEdit(int.Parse(hdfViewId.Value), hdfWorkType.Value, int.Parse(hdfCompanyId.Value));
                }

                // Store tables
                workTypeViewDisplay = (WorkViewTDS.LFS_WORK_TYPE_VIEW_DISPLAYDataTable)model.Table;
                Session["workTypeViewDisplay"] = workTypeViewDisplay;

                return true;
            }

            return false;
        }



        #endregion






        #region STEP2 - COLUMNS TO DISPLAY

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP2 - COLUMNS TO DISPLAY
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP2 - COLUMNS TO DISPLAY - AUXILIAR EVENTS
        //

        protected void grdColumnsToDisplay_DataBound(object sender, EventArgs e)
        {
            ColumnsToDisplayEmptyFix(grdColumnsToDisplay);
        }



        protected void grdColumnsToDisplay_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            StepColumnsToDisplayProcessGrid();
        }



        protected void cvgrdColumnsToDisplay_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Initialize 
            args.IsValid = false;

            StepColumnsToDisplayProcessGrid();

            int pageCount = grdColumnsToDisplay.PageCount;

            for (int i = 0; i < pageCount; i++)
            {
                grdColumnsToDisplay.PageIndex = i;
                grdColumnsToDisplay.DataBind();

                if (grdColumnsToDisplay.Rows.Count > 0)
                {
                    foreach (GridViewRow row in grdColumnsToDisplay.Rows)
                    {
                        if (((CheckBox)row.FindControl("cbxSelected")).Checked)
                        {
                            // Validate Selection
                            args.IsValid = true;
                        }
                    }                    
                }
            }

            if (!args.IsValid)
            {
                cvGrdColumnsToDisplay.ErrorMessage = "At least one option must be selected";

                if (grdColumnsToDisplay.PageIndex != int.Parse(ViewState["columnsToDisplayPageIndex"].ToString()))
                {
                    grdColumnsToDisplay.PageIndex = int.Parse(ViewState["columnsToDisplayPageIndex"].ToString());
                    grdColumnsToDisplay.DataBind();
                }
            }
        } 






        // ////////////////////////////////////////////////////////////////////////
        // STEP2 - COLUMNS TO DISPLAY - METHODS
        //

        private void StepColumnsToDisplayIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Please select the columns to be displayed";

            // Tag Page
            hdfStep.Value = "StepColumnsToDisplay";
            grdColumnsToDisplay.PageIndex = int.Parse(ViewState["columnsToDisplayPageIndex"].ToString());
            grdColumnsToDisplay.DataBind();
        }



        private bool StepColumnsToDisplayNext()
        {
            ViewState["columnsToDisplayPageIndex"] = grdColumnsToDisplay.PageIndex;

            Page.Validate("ColumsToDisplay");

            if (Page.IsValid)
            {
                hdfStep.Value = "StepColumnsToDisplay";
                StepColumnsToDisplayProcessGrid();
                workViewDisplayTemp.Rows.Clear();

                // create dataset
                WorkViewTDS dataSet = new WorkViewTDS();
                dataSet.LFS_WORK_TYPE_VIEW_DISPLAY.Merge(workTypeViewDisplay, true);
                dataSet.WorkViewDisplayTemp.Merge(workViewDisplayTemp, true);

                // process
                WorkViewDisplayTemp model = new WorkViewDisplayTemp(dataSet);
                model.ProcessForEdit(int.Parse(hdfViewId.Value), hdfWorkType.Value, int.Parse(hdfCompanyId.Value));

                // get changes
                workViewDisplayTemp.Rows.Clear();
                workViewDisplayTemp.Merge(model.Table);

                // store tables
                Session.Remove("workTypeViewDisplayDummy");
                Session["workTypeViewDisplay"] = workTypeViewDisplay;
                Session["workViewDisplayTemp"] = workViewDisplayTemp;

                // load conditions for next step
                dataSet.WorkViewConditionNew.Merge(workViewConditionNew, true);
                dataSet.WorkViewConditionTemp.Merge(workViewConditionTemp, true);

                WorkViewConditionNew modelConditionNew = new WorkViewConditionNew(dataSet);
                modelConditionNew.LoadByViewIdCompanyIdWorkType(int.Parse(hdfViewId.Value), int.Parse(hdfCompanyId.Value), hdfWorkType.Value);

                // Store tables
                workViewConditionNew = (WorkViewTDS.WorkViewConditionNewDataTable)modelConditionNew.Table;
                Session["workViewConditionNew"] = workViewConditionNew;

                return true;
            }
            else
            {
                return false;
            }
        }



        private bool StepColumnsToDisplayPrevious()
        {
            ViewState["columnsToDisplayPageIndex"] = grdColumnsToDisplay.PageIndex;
            
            hdfStep.Value = "StepColumnsToDisplay";

            return true;
        }



        private void StepColumnsToDisplayProcessGrid()
        {
            WorkViewTDS dataSet = new WorkViewTDS();
            dataSet.LFS_WORK_TYPE_VIEW_DISPLAY.Merge(workTypeViewDisplay, true);
            WorkTypeViewDisplay model = new WorkTypeViewDisplay(dataSet);

            // update rows
            if (Session["workTypeViewDisplayDummy"] == null)
            {
                foreach (GridViewRow row in grdColumnsToDisplay.Rows)
                {
                    int displayId = int.Parse(grdColumnsToDisplay.DataKeys[row.RowIndex].Values["DisplayID"].ToString());
                    bool selected = ((CheckBox)row.FindControl("cbxSelected")).Checked;

                    model.Update(hdfWorkType.Value, int.Parse(hdfCompanyId.Value), displayId, selected);
                }

                model.Table.AcceptChanges();

                workTypeViewDisplay = (WorkViewTDS.LFS_WORK_TYPE_VIEW_DISPLAYDataTable)model.Table;
                Session["workTypeViewDisplay"] = workTypeViewDisplay;
            }
        }



        public WorkViewTDS.LFS_WORK_TYPE_VIEW_DISPLAYDataTable GetColumnsToDisplay()
        {
            workTypeViewDisplay = (WorkViewTDS.LFS_WORK_TYPE_VIEW_DISPLAYDataTable)Session["workTypeViewDisplayDummy"];
            if (workTypeViewDisplay == null)
            {
                workTypeViewDisplay = (WorkViewTDS.LFS_WORK_TYPE_VIEW_DISPLAYDataTable)Session["workTypeViewDisplay"];
            }

            return workTypeViewDisplay;
        }



        protected void ColumnsToDisplayEmptyFix(GridView grdView)
        {
            if (grdView.Rows.Count == 0)
            {
                WorkViewTDS.LFS_WORK_TYPE_VIEW_DISPLAYDataTable dt = new WorkViewTDS.LFS_WORK_TYPE_VIEW_DISPLAYDataTable();
                dt.AddLFS_WORK_TYPE_VIEW_DISPLAYRow("", 0, 0, "", false, "", "", false);
                Session["workTypeViewDisplayDummy"] = dt;

                grdView.DataBind();
            }

            // normally executes at all postbacks
            if (grdView.Rows.Count == 1)
            {
                WorkViewTDS.LFS_WORK_TYPE_VIEW_DISPLAYDataTable dt = (WorkViewTDS.LFS_WORK_TYPE_VIEW_DISPLAYDataTable)Session["workTypeViewDisplayDummy"];
                if (dt != null)
                {
                    // hide row
                    grdView.Rows[0].Visible = false;
                    grdView.Rows[0].Controls.Clear();
                }
            }
        }



        #endregion






        #region STEP3 - CONDITIONS

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP3 - CONDITIONS
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP3 - CONDITIONS - EVENTS
        //

        protected void grdConditions_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Conditions Gridview, if the gridview is edition mode
            if (grdConditions.EditIndex >= 0)
            {
                grdConditions.UpdateRow(grdConditions.EditIndex, true);
            }

            // Delete conditions
            int id = (int)e.Keys["ID"];

            WorkViewTDS dataSet = new WorkViewTDS();
            dataSet.WorkViewConditionNew.Merge(workViewConditionNew, true);
            WorkViewConditionNew model = new WorkViewConditionNew(dataSet);

            model.Delete(id);
            Session["workViewConditionNew"] = dataSet.WorkViewConditionNew;

            Session["conditionsUpdate"] = "true";
        }



        protected void grdConditions_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Add":
                    // Conditions Gridview, if the gridview is edition mode
                    if (grdConditions.EditIndex >= 0)
                    {
                        grdConditions.UpdateRow(grdConditions.EditIndex, true);
                    }

                    // Add New conditions
                    GrdConditionsAdd();
                    break;
            }
        }



        protected void grdConditions_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.Validate("ConditionsUpdate");
            if (Page.IsValid)
            {
                int id = (int)e.Keys["ID"];

                int conditionId = int.Parse(((DropDownList)grdConditions.Rows[e.RowIndex].Cells[3].FindControl("ddlName")).SelectedValue);
                string name = ((DropDownList)grdConditions.Rows[e.RowIndex].Cells[3].FindControl("ddlName")).SelectedItem.Text;
                DropDownList ddlOperator = ((DropDownList)grdConditions.Rows[grdConditions.EditIndex].FindControl("ddlOperator"));
                string operator_ = ddlOperator.SelectedItem.Text;
                string sign = ddlOperator.SelectedValue;
                int conditionNumber = int.Parse(((DropDownList)grdConditions.Rows[e.RowIndex].Cells[2].FindControl("ddlConditionNumber")).SelectedValue);

                WorkTypeViewConditionGateway workTypeViewConditionGateway = new WorkTypeViewConditionGateway();
                workTypeViewConditionGateway.LoadByWorkTypeConditionId(hdfWorkType.Value, conditionId, int.Parse(hdfCompanyId.Value));
                string type = workTypeViewConditionGateway.GetType(hdfWorkType.Value, int.Parse(hdfCompanyId.Value), conditionId);
                string value = "";

                if ((type == "String") || (type == "Date") || (type == "Int") || (type == "Decimal") || (type == "Distance"))
                {
                    value = ((TextBox)grdConditions.Rows[e.RowIndex].Cells[5].FindControl("tbxValue")).Text;
                }

                if ((type == "FixedItems") || (type == "DynamicItems"))
                {
                    value = ((DropDownList)grdConditions.Rows[e.RowIndex].Cells[5].FindControl("ddlValue")).SelectedItem.Text;
                }

                if (type == "Boolean")
                {
                    if (((RadioButton)grdConditions.Rows[e.RowIndex].Cells[5].FindControl("rbtnYes")).Checked)
                        value = "Yes";
                    if (((RadioButton)grdConditions.Rows[e.RowIndex].Cells[5].FindControl("rbtnNo")).Checked)
                        value = "No";
                }

                WorkViewTDS dataSet = new WorkViewTDS();
                dataSet.WorkViewConditionNew.Merge(workViewConditionNew, true);
                WorkViewConditionNew model = new WorkViewConditionNew(dataSet);

                WorkViewConditionGateway workViewConditionGateway = new WorkViewConditionGateway();
                int refId = workViewConditionGateway.GetLastRefIdByViewIdWorkTypeConditionId(int.Parse(hdfViewId.Value), int.Parse(hdfCompanyId.Value), hdfWorkType.Value, conditionId);
                refId = refId + 1;

                model.UpdateForEdit(refId, id, conditionId, name, operator_, sign, conditionNumber, value, false, false);
                Session["workViewConditionNew"] = dataSet.WorkViewConditionNew;
                workViewConditionNew = dataSet.WorkViewConditionNew;  
            }
            else
            {
                e.Cancel = true;
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP3 - CONDITIONS - AUXILIAR EVENTS
        //

        protected void grdConditions_DataBound(object sender, EventArgs e)
        {
            AddConditionsNewEmptyFix(grdConditions);
        }



        protected void grdConditions_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                int conditionId = 0; conditionId = int.Parse(((DropDownList)e.Row.FindControl("ddlName")).SelectedValue);
                DropDownList ddlOperator = ((DropDownList)e.Row.FindControl("ddlOperator"));

                if (conditionId > 0)
                {
                    DropDownList ddlConditionNumber = ((DropDownList)e.Row.FindControl("ddlConditionNumber"));

                    WorkViewTDS dataSet = new WorkViewTDS();
                    dataSet.WorkViewConditionNew.Merge(workViewConditionNew, true);
                    WorkViewConditionNew model = new WorkViewConditionNew(dataSet);
                    int conditionNumber = model.GetNewConditionNumber();

                    ddlConditionNumber.SelectedValue = conditionNumber.ToString();

                    WorkTypeViewConditionGateway workTypeViewConditionGateway = new WorkTypeViewConditionGateway();
                    workTypeViewConditionGateway.LoadByWorkTypeConditionId(hdfWorkType.Value, conditionId, int.Parse(hdfCompanyId.Value));
                    string type = workTypeViewConditionGateway.GetType(hdfWorkType.Value, int.Parse(hdfCompanyId.Value), conditionId);
                    
                    if (ddlOperator.SelectedItem == null)
                    {
                        WorkTypeViewOperatorList workTypeViewOperatorList = new WorkTypeViewOperatorList(new DataSet());
                        workTypeViewOperatorList.LoadAndAddItem(type, Int32.Parse(hdfCompanyId.Value));
                        ddlOperator.DataSource = workTypeViewOperatorList.Table;
                        ddlOperator.DataValueField = "Sign";
                        ddlOperator.DataTextField = "Operator";
                        ddlOperator.DataBind();
                        ddlOperator.SelectedIndex = 0;
                    }

                    if ((type == "String") || (type == "Date") || (type == "Int") || (type == "Decimal") || (type == "Distance"))
                    {
                        ddlOperator.Enabled = true;

                        TextBox tbxValue = ((TextBox)e.Row.FindControl("tbxValue"));
                        tbxValue.Visible = true;

                        DropDownList ddlValue = ((DropDownList)e.Row.FindControl("ddlValue"));
                        ddlValue.Visible = false;

                        RadioButton rbtnYes = ((RadioButton)e.Row.FindControl("rbtnYes"));
                        rbtnYes.Visible = false;

                        RadioButton rbtnNo = ((RadioButton)e.Row.FindControl("rbtnNo"));
                        rbtnNo.Visible = false;
                    }

                    if ((type == "FixedItems") || (type == "DynamicItems") || (type == "Boolean"))
                    {
                        ddlOperator.Enabled = false;

                        if (type == "FixedItems")
                        {
                            DropDownList ddlValue = ((DropDownList)e.Row.FindControl("ddlValue"));
                            ddlValue.Visible = true;

                            TextBox tbxValue = ((TextBox)e.Row.FindControl("tbxValue"));
                            tbxValue.Visible = false;

                            RadioButton rbtnYes = ((RadioButton)e.Row.FindControl("rbtnYes"));
                            rbtnYes.Visible = false;

                            RadioButton rbtnNo = ((RadioButton)e.Row.FindControl("rbtnNo"));
                            rbtnNo.Visible = false;
                        }

                        if (type == "DynamicItems")
                        {
                            DropDownList ddlValue = ((DropDownList)e.Row.FindControl("ddlValue"));
                            ddlValue.Visible = true;

                            TextBox tbxValue = ((TextBox)e.Row.FindControl("tbxValue"));
                            tbxValue.Visible = false;

                            RadioButton rbtnYes = ((RadioButton)e.Row.FindControl("rbtnYes"));
                            rbtnYes.Visible = false;

                            RadioButton rbtnNo = ((RadioButton)e.Row.FindControl("rbtnNo"));
                            rbtnNo.Visible = false;
                        }

                        if (type == "Boolean")
                        {
                            DropDownList ddlValue = ((DropDownList)e.Row.FindControl("ddlValue"));
                            ddlValue.Visible = false;

                            TextBox tbxValue = ((TextBox)e.Row.FindControl("tbxValue"));
                            tbxValue.Visible = false;

                            RadioButton rbtnYes = ((RadioButton)e.Row.FindControl("rbtnYes"));
                            rbtnYes.Visible = true;

                            RadioButton rbtnNo = ((RadioButton)e.Row.FindControl("rbtnNo"));
                            rbtnNo.Visible = true;
                        }
                    }
                }
            }

            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Edit) || (e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
            {
                WorkViewTDS dataSet = new WorkViewTDS();
                dataSet.WorkViewConditionNew.Merge(workViewConditionNew, true);
                WorkViewConditionNewGateway gateway = new WorkViewConditionNewGateway(dataSet);
                int id = int.Parse(((Label)e.Row.FindControl("lblId")).Text);
                
                int conditionId = gateway.GetConditionId(id);
                DropDownList ddlName = ((DropDownList)e.Row.FindControl("ddlName"));
                DropDownList ddlOperator = ((DropDownList)e.Row.FindControl("ddlOperator"));

                if (conditionId > 0)
                {
                    WorkTypeViewConditionGateway workTypeViewConditionGateway = new WorkTypeViewConditionGateway();
                    workTypeViewConditionGateway.LoadByWorkTypeConditionId(hdfWorkType.Value, conditionId, int.Parse(hdfCompanyId.Value));
                    string type = workTypeViewConditionGateway.GetType(hdfWorkType.Value, int.Parse(hdfCompanyId.Value), conditionId);

                    ddlName.DataBind();
                    ddlName.SelectedValue = conditionId.ToString();

                    WorkTypeViewOperatorList workTypeViewOperatorList = new WorkTypeViewOperatorList(new DataSet());
                    workTypeViewOperatorList.LoadAndAddItem(type, Int32.Parse(hdfCompanyId.Value));
                    ddlOperator.DataSource = workTypeViewOperatorList.Table;
                    ddlOperator.DataValueField = "Sign";
                    ddlOperator.DataTextField = "Operator";
                    ddlOperator.DataBind();
                    ddlOperator.SelectedValue = gateway.GetSign(id);

                    if ((type == "String") || (type == "Date") || (type == "Int") || (type == "Decimal") || (type == "Distance"))
                    {
                        ddlOperator.Enabled = true;

                        TextBox tbxValue = ((TextBox)e.Row.FindControl("tbxValue"));
                        tbxValue.Visible = true;
                        tbxValue.Text = gateway.GetValue_(id);

                        DropDownList ddlValue = ((DropDownList)e.Row.FindControl("ddlValue"));
                        ddlValue.Visible = false;

                        RadioButton rbtnYes = ((RadioButton)e.Row.FindControl("rbtnYes"));
                        rbtnYes.Visible = false;

                        RadioButton rbtnNo = ((RadioButton)e.Row.FindControl("rbtnNo"));
                        rbtnNo.Visible = false;
                    }

                    if ((type == "FixedItems") || (type == "DynamicItems") || (type == "Boolean"))
                    {
                        ddlOperator.Enabled = false;

                        if (type == "FixedItems")
                        {
                            DropDownList ddlValue = ((DropDownList)e.Row.FindControl("ddlValue"));
                            ddlValue.Visible = true;

                            // Prepare initial data
                            // ... For view type
                            WorkTypeViewConditionItemList workTypeViewConditionItemList = new WorkTypeViewConditionItemList(new DataSet());
                            workTypeViewConditionItemList.LoadAndAddItemInView(hdfWorkType.Value, Int32.Parse(hdfCompanyId.Value), conditionId);
                            ddlValue.DataSource = workTypeViewConditionItemList.Table;
                            ddlValue.DataValueField = "Name";
                            ddlValue.DataTextField = "Name";
                            ddlValue.DataBind();
                            ddlValue.SelectedValue = gateway.GetValue_(id);

                            TextBox tbxValue = ((TextBox)e.Row.FindControl("tbxValue"));
                            tbxValue.Visible = false;

                            RadioButton rbtnYes = ((RadioButton)e.Row.FindControl("rbtnYes"));
                            rbtnYes.Visible = false;

                            RadioButton rbtnNo = ((RadioButton)e.Row.FindControl("rbtnNo"));
                            rbtnNo.Visible = false;
                        }

                        if (type == "DynamicItems")
                        {
                            DropDownList ddlValue = ((DropDownList)e.Row.FindControl("ddlValue"));
                            ddlValue.Visible = true;

                            // Prepare initial data
                            // ... For view type
                            WorkTypeViewSubAreaList workTypeViewSubAreaList = new WorkTypeViewSubAreaList(new DataSet());
                            workTypeViewSubAreaList.LoadAndAddItem(hdfWorkType.Value, Int32.Parse(hdfCompanyId.Value), int.Parse(hdfProjectId.Value));
                            if (workTypeViewSubAreaList.Table.Rows.Count > 0)
                            {
                                ddlValue.DataSource = workTypeViewSubAreaList.Table;
                                ddlValue.DataValueField = "SubArea";
                                ddlValue.DataTextField = "SubArea";
                                ddlValue.DataBind();
                                ddlValue.SelectedValue = gateway.GetValue_(id);
                            }
                            else
                            {
                                ddlValue.Visible = false;
                            }

                            TextBox tbxValue = ((TextBox)e.Row.FindControl("tbxValue"));
                            tbxValue.Visible = false;

                            RadioButton rbtnYes = ((RadioButton)e.Row.FindControl("rbtnYes"));
                            rbtnYes.Visible = false;

                            RadioButton rbtnNo = ((RadioButton)e.Row.FindControl("rbtnNo"));
                            rbtnNo.Visible = false;
                        }

                        if (type == "Boolean")
                        {
                            DropDownList ddlValue = ((DropDownList)e.Row.FindControl("ddlValue"));
                            ddlValue.Visible = false;

                            TextBox tbxValue = ((TextBox)e.Row.FindControl("tbxValue"));
                            tbxValue.Visible = false;

                            RadioButton rbtnYes = ((RadioButton)e.Row.FindControl("rbtnYes"));
                            rbtnYes.Visible = true;

                            RadioButton rbtnNo = ((RadioButton)e.Row.FindControl("rbtnNo"));
                            rbtnNo.Visible = true;

                            if (gateway.GetValue_(id) == "Yes")
                            {
                                rbtnYes.Checked = true;
                            }
                            else
                            {
                                rbtnNo.Checked = true;
                            }
                        }
                    }
                }
            }
        }



        protected void grdConditions_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Conditions Gridview, if the gridview is edition mode
            if (grdConditions.EditIndex >= 0)
            {
                grdConditions.UpdateRow(grdConditions.EditIndex, true);
            }
        }



        protected void cvGrdConditions_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Initialize 
            args.IsValid = true;
            string messageError = "";
            string conditionNumber = "";
            int noQuantity = 0;
            ArrayList conditions = new ArrayList();

            if (grdConditions.Rows.Count > 0)
            {
                foreach (GridViewRow row in grdConditions.Rows)
                {
                    try
                    {
                        if (grdConditions.EditIndex >= 0)
                        {
                            conditionNumber = ((DropDownList)row.FindControl("ddlConditionNumber")).SelectedValue;
                        }
                        else
                        {
                            conditionNumber = ((Label)row.FindControl("lblConditionNumber")).Text;
                        }

                        if (!conditions.Contains(conditionNumber))
                        {
                            conditions.Add(conditionNumber);
                        }
                        else
                        {
                            noQuantity = noQuantity + 1;
                        }
                    }
                    catch
                    {
                        messageError = messageError + String.Format("The Condition{0} already exists, please select another No.<br>", conditionNumber);
                        args.IsValid = false;
                    }

                    if (noQuantity >= 2)
                    {
                        messageError = messageError + String.Format("The Condition{0} already exists, please select another No.<br>", conditionNumber);
                        args.IsValid = false;
                    }
                }
            }
            else
            {
                args.IsValid = true;
            }

            cvGrdConditions.Text = messageError;
        }



        protected void cvValueData_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Initialize 
            CustomValidator cvConditions = (CustomValidator)source;
            args.IsValid = true;
            string type = "Date";
            int conditionId = 0;
            if (cvConditions.ValidationGroup == "Conditions")
            {
                conditionId = int.Parse(((DropDownList)grdConditions.FooterRow.FindControl("ddlName")).SelectedValue);
            }
            else
            {
                conditionId = int.Parse(((DropDownList)grdConditions.Rows[grdConditions.EditIndex].Cells[3].FindControl("ddlName")).SelectedValue);
            }

            WorkTypeViewConditionGateway workTypeViewConditionGateway = new WorkTypeViewConditionGateway();
            workTypeViewConditionGateway.LoadByWorkTypeConditionId(hdfWorkType.Value, conditionId, int.Parse(hdfCompanyId.Value));
            type = workTypeViewConditionGateway.GetType(hdfWorkType.Value, int.Parse(hdfCompanyId.Value), conditionId);

            //  Date fields validate
            if (type == "Date")
            {
                // for complete date or only year
                if (((Validator.IsValidDate(args.Value.Trim()) && (args.Value.Trim().Length > 7))) || ((Validator.IsValidInt32(args.Value.Trim())) && (args.Value.Trim().Length == 4)) || (args.Value.Trim() == "%") || (args.Value.Trim() == ""))
                {
                    args.IsValid = true;
                }
                else
                {
                    args.IsValid = false;
                    cvConditions.ErrorMessage = "Invalid date. (use mm/dd/yyyy, yyyy, %, or leave the field empty)";
                }

                // For dates before 1900
                if (args.IsValid)
                {
                    string[] date = (args.Value.Trim()).Split('/');
                    if (((Validator.IsValidDate(args.Value.Trim())) && (Int32.Parse(date[2]) >= 1900)) || ((args.Value.Trim().Length == 4) && (Validator.IsValidInt32(args.Value.Trim())) && (Int32.Parse(args.Value.Trim()) >= 1900)) || (args.Value.Trim() == "%") || (args.Value.Trim() == ""))
                    {
                        args.IsValid = true;
                    }
                    else
                    {
                        args.IsValid = false;
                        cvConditions.ErrorMessage = "Invalid date. (use a date over 1900)";
                    }
                }
            }

            if (type == "Int")
            {
                if (Validator.IsValidInt32(args.Value.Trim()) || (args.Value.Trim() == "%") || (args.Value.Trim() == ""))
                {
                    args.IsValid = true;
                }
                else
                {
                    args.IsValid = false;
                    cvConditions.IsValid = false;
                    cvConditions.Text = "Invalid data. (use an integer number, % or leave the field empty)";
                    cvConditions.ErrorMessage = "Invalid data. (use an integer number, % or leave the field empty)";
                }
            }

            if (type == "Decimal")
            {
                if (Validator.IsValidDecimal(args.Value.Trim()) || (args.Value.Trim() == "%") || (args.Value.Trim() == ""))
                {
                    args.IsValid = true;
                }
                else
                {
                    args.IsValid = false;
                    cvConditions.IsValid = false;
                    cvConditions.Text = "Invalid data. (use a decimal number, % or leave the field empty)";
                    cvConditions.ErrorMessage = "Invalid data. (use a decimal number, % or leave the field empty)";
                }
            }
        }



        protected void ddlNameNew_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label lblValidateValue = ((Label)grdConditions.FooterRow.FindControl("lblValidateValue"));
            lblValidateValue.Visible = false;

            DropDownList ddlName = ((DropDownList)grdConditions.FooterRow.FindControl("ddlName"));
            DropDownList ddlOperator = ((DropDownList)grdConditions.FooterRow.FindControl("ddlOperator"));

            WorkTypeViewConditionGateway workTypeViewConditionGateway = new WorkTypeViewConditionGateway();
            workTypeViewConditionGateway.LoadByWorkTypeConditionId(hdfWorkType.Value, int.Parse(ddlName.SelectedValue), int.Parse(hdfCompanyId.Value));
            string type = workTypeViewConditionGateway.GetType(hdfWorkType.Value, int.Parse(hdfCompanyId.Value), int.Parse(ddlName.SelectedValue));

            WorkTypeViewOperatorList workTypeViewOperatorList = new WorkTypeViewOperatorList(new DataSet());
            workTypeViewOperatorList.LoadAndAddItem(type, Int32.Parse(hdfCompanyId.Value));
            ddlOperator.DataSource = workTypeViewOperatorList.Table;
            ddlOperator.DataValueField = "Sign";
            ddlOperator.DataTextField = "Operator";
            ddlOperator.DataBind();
            ddlOperator.SelectedIndex = 0;

            if ((type == "String") || (type == "Date") || (type == "Int") || (type == "Decimal") || (type == "Distance"))
            {
                ddlOperator.Enabled = true;

                TextBox tbxValue = ((TextBox)grdConditions.FooterRow.FindControl("tbxValue"));
                tbxValue.Visible = true;

                DropDownList ddlValue = ((DropDownList)grdConditions.FooterRow.FindControl("ddlValue"));
                ddlValue.Visible = false;

                RadioButton rbtnYes = ((RadioButton)grdConditions.FooterRow.FindControl("rbtnYes"));
                rbtnYes.Visible = false;

                RadioButton rbtnNo = ((RadioButton)grdConditions.FooterRow.FindControl("rbtnNo"));
                rbtnNo.Visible = false;
            }

            if ((type == "FixedItems") || (type == "DynamicItems") || (type == "Boolean"))
            {
                ddlOperator.Enabled = false;

                if (type == "FixedItems")
                {
                    DropDownList ddlValue = ((DropDownList)grdConditions.FooterRow.FindControl("ddlValue"));
                    ddlValue.Visible = true;

                    // Prepare initial data
                    // ... For view type
                    WorkTypeViewConditionItemList workTypeViewConditionItemList = new WorkTypeViewConditionItemList(new DataSet());
                    workTypeViewConditionItemList.LoadAndAddItemInView(hdfWorkType.Value, Int32.Parse(hdfCompanyId.Value), int.Parse(ddlName.SelectedValue));
                    ddlValue.DataSource = workTypeViewConditionItemList.Table;
                    ddlValue.DataValueField = "Name";
                    ddlValue.DataTextField = "Name";
                    ddlValue.DataBind();
                    ddlValue.SelectedIndex = 0;

                    TextBox tbxValue = ((TextBox)grdConditions.FooterRow.FindControl("tbxValue"));
                    tbxValue.Visible = false;

                    RadioButton rbtnYes = ((RadioButton)grdConditions.FooterRow.FindControl("rbtnYes"));
                    rbtnYes.Visible = false;

                    RadioButton rbtnNo = ((RadioButton)grdConditions.FooterRow.FindControl("rbtnNo"));
                    rbtnNo.Visible = false;
                }

                if (type == "DynamicItems")
                {
                    DropDownList ddlValue = ((DropDownList)grdConditions.FooterRow.FindControl("ddlValue"));

                    // Prepare initial data
                    // ... For view type
                    WorkTypeViewSubAreaList workTypeViewSubAreaList = new WorkTypeViewSubAreaList(new DataSet());
                    workTypeViewSubAreaList.LoadAndAddItem(hdfWorkType.Value, int.Parse(hdfCompanyId.Value), int.Parse(hdfProjectId.Value));
                    if (workTypeViewSubAreaList.Table.Rows.Count > 0)
                    {
                        ddlValue.Visible = true;
                        ddlValue.DataSource = workTypeViewSubAreaList.Table;
                        ddlValue.DataValueField = "SubArea";
                        ddlValue.DataTextField = "SubArea";
                        ddlValue.DataBind();
                        ddlValue.SelectedIndex = 0;
                    }
                    else
                    {
                        ddlValue.Visible = false;
                        ImageButton ibtnAdd = ((ImageButton)grdConditions.FooterRow.FindControl("ibtnAdd"));
                        ibtnAdd.Visible = false;

                        lblValidateValue.Visible = true;
                    }

                    TextBox tbxValue = ((TextBox)grdConditions.FooterRow.FindControl("tbxValue"));
                    tbxValue.Visible = false;

                    RadioButton rbtnYes = ((RadioButton)grdConditions.FooterRow.FindControl("rbtnYes"));
                    rbtnYes.Visible = false;

                    RadioButton rbtnNo = ((RadioButton)grdConditions.FooterRow.FindControl("rbtnNo"));
                    rbtnNo.Visible = false;
                }

                if (type == "Boolean")
                {
                    DropDownList ddlValue = ((DropDownList)grdConditions.FooterRow.FindControl("ddlValue"));
                    ddlValue.Visible = false;

                    TextBox tbxValue = ((TextBox)grdConditions.FooterRow.FindControl("tbxValue"));
                    tbxValue.Visible = false;

                    RadioButton rbtnYes = ((RadioButton)grdConditions.FooterRow.FindControl("rbtnYes"));
                    rbtnYes.Visible = true;

                    RadioButton rbtnNo = ((RadioButton)grdConditions.FooterRow.FindControl("rbtnNo"));
                    rbtnNo.Visible = true;
                }
            }
        }



        // change ddl in edition
        protected void ddlName_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label lblValidateValue = ((Label)grdConditions.Rows[grdConditions.EditIndex].FindControl("lblValidateValue"));
            lblValidateValue.Visible = false;

            DropDownList ddlName = ((DropDownList)grdConditions.Rows[grdConditions.EditIndex].FindControl("ddlName"));
            DropDownList ddlOperator = ((DropDownList)grdConditions.Rows[grdConditions.EditIndex].FindControl("ddlOperator"));

            WorkTypeViewConditionGateway workTypeViewConditionGateway = new WorkTypeViewConditionGateway();
            workTypeViewConditionGateway.LoadByWorkTypeConditionId(hdfWorkType.Value, int.Parse(ddlName.SelectedValue), int.Parse(hdfCompanyId.Value));
            string type = workTypeViewConditionGateway.GetType(hdfWorkType.Value, int.Parse(hdfCompanyId.Value), int.Parse(ddlName.SelectedValue));
            int index = grdConditions.SelectedIndex;

            WorkTypeViewOperatorList workTypeViewOperatorList = new WorkTypeViewOperatorList(new DataSet());
            workTypeViewOperatorList.LoadAndAddItem(type, Int32.Parse(hdfCompanyId.Value));
            ddlOperator.DataSource = workTypeViewOperatorList.Table;
            ddlOperator.DataValueField = "Sign";
            ddlOperator.DataTextField = "Operator";
            ddlOperator.DataBind();
            ddlOperator.SelectedIndex = 0;

            if ((type == "String") || (type == "Date") || (type == "Int") || (type == "Decimal") || (type == "Distance"))
            {
                ddlOperator.Enabled = true;

                TextBox tbxValue = ((TextBox)grdConditions.Rows[grdConditions.EditIndex].FindControl("tbxValue"));
                tbxValue.Visible = true;

                DropDownList ddlValue = ((DropDownList)grdConditions.Rows[grdConditions.EditIndex].FindControl("ddlValue"));
                ddlValue.Visible = false;

                RadioButton rbtnYes = ((RadioButton)grdConditions.Rows[grdConditions.EditIndex].FindControl("rbtnYes"));
                rbtnYes.Visible = false;

                RadioButton rbtnNo = ((RadioButton)grdConditions.Rows[grdConditions.EditIndex].FindControl("rbtnNo"));
                rbtnNo.Visible = false;
            }

            if ((type == "FixedItems") || (type == "DynamicItems") || (type == "Boolean"))
            {
                ddlOperator.Enabled = false;

                if (type == "FixedItems")
                {
                    DropDownList ddlValue = ((DropDownList)grdConditions.Rows[grdConditions.EditIndex].FindControl("ddlValue"));
                    ddlValue.Visible = true;

                    // Prepare initial data
                    // ... For view type
                    WorkTypeViewConditionItemList workTypeViewConditionItemList = new WorkTypeViewConditionItemList(new DataSet());
                    workTypeViewConditionItemList.LoadAndAddItemInView(hdfWorkType.Value, Int32.Parse(hdfCompanyId.Value), int.Parse(ddlName.SelectedValue));
                    ddlValue.DataSource = workTypeViewConditionItemList.Table;
                    ddlValue.DataValueField = "Name";
                    ddlValue.DataTextField = "Name";
                    ddlValue.DataBind();
                    ddlValue.SelectedIndex = 0;

                    TextBox tbxValue = ((TextBox)grdConditions.Rows[grdConditions.EditIndex].FindControl("tbxValue"));
                    tbxValue.Visible = false;

                    RadioButton rbtnYes = ((RadioButton)grdConditions.Rows[grdConditions.EditIndex].FindControl("rbtnYes"));
                    rbtnYes.Visible = false;

                    RadioButton rbtnNo = ((RadioButton)grdConditions.Rows[grdConditions.EditIndex].FindControl("rbtnNo"));
                    rbtnNo.Visible = false;
                }

                if (type == "DynamicItems")
                {
                    DropDownList ddlValue = ((DropDownList)grdConditions.Rows[grdConditions.EditIndex].FindControl("ddlValue"));

                    // Prepare initial data
                    // ... For view type
                    WorkTypeViewSubAreaList workTypeViewSubAreaList = new WorkTypeViewSubAreaList(new DataSet());
                    workTypeViewSubAreaList.LoadAndAddItem(hdfWorkType.Value, int.Parse(hdfCompanyId.Value), int.Parse(hdfProjectId.Value));
                    if (workTypeViewSubAreaList.Table.Rows.Count > 0)
                    {
                        ddlValue.Visible = true;
                        ddlValue.DataSource = workTypeViewSubAreaList.Table;
                        ddlValue.DataValueField = "SubArea";
                        ddlValue.DataTextField = "SubArea";
                        ddlValue.DataBind();
                        ddlValue.SelectedIndex = 0;
                    }
                    else
                    {
                        ddlValue.Visible = false;
                        ImageButton ibtnAdd = ((ImageButton)grdConditions.Rows[grdConditions.EditIndex].FindControl("ibtnAdd"));
                        ibtnAdd.Visible = false;

                        lblValidateValue.Visible = true;
                    }

                    TextBox tbxValue = ((TextBox)grdConditions.Rows[grdConditions.EditIndex].FindControl("tbxValue"));
                    tbxValue.Visible = false;

                    RadioButton rbtnYes = ((RadioButton)grdConditions.Rows[grdConditions.EditIndex].FindControl("rbtnYes"));
                    rbtnYes.Visible = false;

                    RadioButton rbtnNo = ((RadioButton)grdConditions.Rows[grdConditions.EditIndex].FindControl("rbtnNo"));
                    rbtnNo.Visible = false;
                }

                if (type == "Boolean")
                {
                    DropDownList ddlValue = ((DropDownList)grdConditions.Rows[grdConditions.EditIndex].FindControl("ddlValue"));
                    ddlValue.Visible = false;

                    TextBox tbxValue = ((TextBox)grdConditions.Rows[grdConditions.EditIndex].FindControl("tbxValue"));
                    tbxValue.Visible = false;

                    RadioButton rbtnYes = ((RadioButton)grdConditions.Rows[grdConditions.EditIndex].FindControl("rbtnYes"));
                    rbtnYes.Visible = true;

                    RadioButton rbtnNo = ((RadioButton)grdConditions.Rows[grdConditions.EditIndex].FindControl("rbtnNo"));
                    rbtnNo.Visible = true;
                }
            }
        }
        




        
        // ////////////////////////////////////////////////////////////////////////
        // STEP3 - CONDITIONS - METHODS
        //

        private void StepConditionsIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Please provide the conditions";

            //Tag page
            hdfStep.Value = "StepConditions";

            // gridview
            grdConditions.DataBind();

            // Sort by ConditionNumber
            SortDirection direction = SortDirection.Ascending;
            string expression = "ConditionNumber";
            grdConditions.Sort(expression, direction);
        }



        private bool StepConditionsNext()
        {
            // Validate data
            bool validData = true;

            // Edit if there is data to save
            Page.Validate("ConditionsUpdate");
            if (!Page.IsValid) validData = false;

            if (validData)
            {
                // Conditions Gridview, if the gridview is edition mode
                if (grdConditions.EditIndex >= 0)
                {
                    grdConditions.UpdateRow(grdConditions.EditIndex, true);
                    grdConditions.DataBind();
                }
            }
            
            Page.Validate("ConditionsNext");
            if (!Page.IsValid) validData = false;

            if (validData)
            {
                // Add conditions if exists at footer
                if (ValidateFooterNext())
                {
                    GrdConditionsAdd();
                }

                WorkViewGateway workViewGateway = new WorkViewGateway();
                workViewGateway.LoadByViewId(int.Parse(hdfViewId.Value), int.Parse(hdfCompanyId.Value));

                workViewConditionTemp.Rows.Clear();

                // create dataset
                WorkViewTDS dataSet = new WorkViewTDS();
                dataSet.WorkViewConditionNew.Merge(workViewConditionNew, true);
                dataSet.WorkViewConditionTemp.Merge(workViewConditionTemp, true);

                // process conditions
                WorkViewConditionTemp model = new WorkViewConditionTemp(dataSet);
                WorkViewConditionNew modelLogic = new WorkViewConditionNew(dataSet);

                string originalLogic = workViewGateway.GetLogic(int.Parse(hdfViewId.Value));
                string newLogic = modelLogic.GetConditionsByDefault();
                
                ArrayList aConditions = new ArrayList();
                aConditions = modelLogic.GetConditions();

                bool isConditionsUpdate = false;
                
                if (originalLogic.Trim() != newLogic.Trim())
                {
                    foreach (string conditionNumber in aConditions)
                    {
                        if (!originalLogic.Contains(conditionNumber))
                        {
                            isConditionsUpdate = true;
                        }
                    }

                    if (!isConditionsUpdate)
                    {

                        if (Session["conditionsUpdate"] != null)
                        {
                            if (Session["conditionsUpdate"].ToString() == "true")
                            {
                                isConditionsUpdate = true;
                            }
                        }
                    }
                }
                else
                {
                    tbxLogic.Text = originalLogic.Trim();
                }

                if (isConditionsUpdate)
                {
                    tbxLogic.Text = newLogic.Trim();
                }
                else
                {
                    tbxLogic.Text = originalLogic.Trim();
                }

                // get changes
                workViewConditionNew.Rows.Clear();
                workViewConditionNew.Merge(modelLogic.Table);
                workViewConditionTemp.Rows.Clear();
                workViewConditionTemp.Merge(model.Table);

                //// store tables
                Session.Remove("workViewConditionNewDummy");
                Session.Remove("workViewConditionTempDummy");
                Session["workViewConditionNew"] = workViewConditionNew;
                Session["workViewConditionTemp"] = workViewConditionTemp;

                Session["conditionsUpdate"] = null;

                return true;
            }
            else
            {
                return false;
            }
        }



        private bool StepConditionsPrevious()
        {
            return true;
        }



        private void GrdConditionsAdd()
        {
            if (ValidateFooterAdd())
            {
                Page.Validate("Conditions");
                if (Page.IsValid)
                {
                    int conditionId = int.Parse(((DropDownList)grdConditions.FooterRow.FindControl("ddlName")).SelectedValue);
                    string name = ((DropDownList)grdConditions.FooterRow.FindControl("ddlName")).SelectedItem.Text;
                    string operator_ = ((DropDownList)grdConditions.FooterRow.FindControl("ddlOperator")).SelectedItem.Text;
                    string sign = ((DropDownList)grdConditions.FooterRow.FindControl("ddlOperator")).SelectedValue;
                    int conditionNumber = int.Parse(((DropDownList)grdConditions.FooterRow.FindControl("ddlConditionNumber")).SelectedValue);

                    WorkTypeViewConditionGateway workTypeViewConditionGateway = new WorkTypeViewConditionGateway();
                    workTypeViewConditionGateway.LoadByWorkTypeConditionId(hdfWorkType.Value, conditionId, int.Parse(hdfCompanyId.Value));
                    string type = workTypeViewConditionGateway.GetType(hdfWorkType.Value, int.Parse(hdfCompanyId.Value), conditionId);
                    string value = "";

                    if ((type == "String") || (type == "Date") || (type == "Int") || (type == "Decimal") || (type == "Distance"))
                    {
                        value = ((TextBox)grdConditions.FooterRow.FindControl("tbxValue")).Text;
                    }

                    if ((type == "FixedItems") || (type == "DynamicItems"))
                    {
                        value = ((DropDownList)grdConditions.FooterRow.FindControl("ddlValue")).SelectedItem.Text;
                    }

                    if (type == "Boolean")
                    {
                        if (((RadioButton)grdConditions.FooterRow.FindControl("rbtnYes")).Checked)
                            value = "Yes";
                        if (((RadioButton)grdConditions.FooterRow.FindControl("rbtnNo")).Checked)
                            value = "No";
                    }

                    WorkViewTDS dataSet = new WorkViewTDS();
                    dataSet.WorkViewConditionNew.Merge(workViewConditionNew, true);
                    WorkViewConditionNew model = new WorkViewConditionNew(dataSet);

                    WorkViewConditionGateway workViewConditionGateway = new WorkViewConditionGateway();
                    int refId = workViewConditionGateway.GetLastRefIdByViewIdWorkTypeConditionId(int.Parse(hdfViewId.Value), int.Parse(hdfCompanyId.Value), hdfWorkType.Value, conditionId);
                    refId = refId + 1;

                    model.InsertForEdit(refId, conditionId, name, operator_, sign, conditionNumber, value, false, false);

                    Session.Remove("workViewConditionNewDummy");
                    workViewConditionNew = dataSet.WorkViewConditionNew;
                    Session["workViewConditionNew"] = dataSet.WorkViewConditionNew;

                    grdConditions.DataBind();
                    grdConditions.PageIndex = grdConditions.PageCount - 1;
                }
            }
        }



        private bool ValidateFooterAdd()
        {
            int conditionId = int.Parse(((DropDownList)grdConditions.FooterRow.FindControl("ddlName")).SelectedValue);
            WorkTypeViewConditionGateway workTypeViewConditionGateway = new WorkTypeViewConditionGateway();
            workTypeViewConditionGateway.LoadByWorkTypeConditionId(hdfWorkType.Value, conditionId, int.Parse(hdfCompanyId.Value));
            string type = workTypeViewConditionGateway.GetType(hdfWorkType.Value, int.Parse(hdfCompanyId.Value), conditionId);
            string value = "";

            if ((type == "String") || (type == "Date") || (type == "Int") || (type == "Decimal"))
            {
                value = ((TextBox)grdConditions.FooterRow.FindControl("tbxValue")).Text;
            }

            if ((type == "FixedItems") || (type == "DynamicItems"))
            {
                value = ((DropDownList)grdConditions.FooterRow.FindControl("ddlValue")).SelectedItem.Text;
            }

            if (type == "Boolean")
            {
                if (((RadioButton)grdConditions.FooterRow.FindControl("rbtnYes")).Checked)
                    value = "Yes";
                if (((RadioButton)grdConditions.FooterRow.FindControl("rbtnNo")).Checked)
                    value = "No";
            }

            return true;
        }



        private bool ValidateFooterNext()
        {
            int conditionId = int.Parse(((DropDownList)grdConditions.FooterRow.FindControl("ddlName")).SelectedValue);
            WorkTypeViewConditionGateway workTypeViewConditionGateway = new WorkTypeViewConditionGateway();
            workTypeViewConditionGateway.LoadByWorkTypeConditionId(hdfWorkType.Value, conditionId, int.Parse(hdfCompanyId.Value));
            string type = workTypeViewConditionGateway.GetType(hdfWorkType.Value, int.Parse(hdfCompanyId.Value), conditionId);
            string value = "";

            if ((type == "String") || (type == "Date") || (type == "Int") || (type == "Decimal"))
            {
                value = ((TextBox)grdConditions.FooterRow.FindControl("tbxValue")).Text;
            }

            if ((type == "FixedItems") || (type == "DynamicItems"))
            {
                value = ((DropDownList)grdConditions.FooterRow.FindControl("ddlValue")).SelectedItem.Text;
            }

            if (type == "Boolean")
            {
                if (((RadioButton)grdConditions.FooterRow.FindControl("rbtnYes")).Checked)
                    value = "Yes";
                if (((RadioButton)grdConditions.FooterRow.FindControl("rbtnNo")).Checked)
                    value = "No";
            }

            if (value != "") return true; else return false;
        }



        public WorkViewTDS.WorkViewConditionNewDataTable GetConditionsNew()
        {
            workViewConditionNew = (WorkViewTDS.WorkViewConditionNewDataTable)Session["workViewConditionNewDummy"];
            if (workViewConditionNew == null)
            {
                workViewConditionNew = (WorkViewTDS.WorkViewConditionNewDataTable)Session["workViewConditionNew"];
            }

            return workViewConditionNew;
        }



        public void DummyConditionsNew(int ID)
        {
        }



        protected void AddConditionsNewEmptyFix(GridView grdView)
        {
            if (grdView.Rows.Count == 0)
            {
                WorkViewTDS.WorkViewConditionNewDataTable dt = new WorkViewTDS.WorkViewConditionNewDataTable();
                dt.AddWorkViewConditionNewRow(-1, -1, "", -1, "", "", -1, "", false, false);
                Session["workViewConditionNewDummy"] = dt;

                grdView.DataBind();
            }

            // normally executes at all postbacks
            if (grdView.Rows.Count == 1)
            {
                WorkViewTDS.WorkViewConditionNewDataTable dt = (WorkViewTDS.WorkViewConditionNewDataTable)Session["workViewConditionNewDummy"];
                if (dt != null)
                {
                    grdView.Rows[0].Visible = false;
                    grdView.Rows[0].Controls.Clear();
                }
            }
        }


                
        protected string GetConditionNumberSelected(object name)
        {
            string conditionNumberSelected = "1";
            if (name != DBNull.Value)
            {
                if (name != null)
                {
                    conditionNumberSelected = name.ToString();
                }
            }
            return conditionNumberSelected;
        }



        #endregion






        #region STEP4 - Logic

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP4 - LOGIC
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP4 - LOGIC - AUXILIAR EVENTS
        //
        protected void cvLogic_ServerValidate(object source, ServerValidateEventArgs args)
        {
            LogicValidator logicValidator = new LogicValidator();
            string message;

            ArrayList conditions = new ArrayList();

            // create dataset
            WorkViewTDS dataSet = new WorkViewTDS();
            dataSet.WorkViewConditionNew.Merge(workViewConditionNew, true);

            // process new conditions
            WorkViewConditionNew model = new WorkViewConditionNew(dataSet);
            conditions = model.GetConditions();

            // get changes
            workViewConditionNew.Rows.Clear();
            workViewConditionNew.Merge(model.Table);

            // store tables
            Session["workViewConditionNew"] = workViewConditionNew;

            if (conditions.Count > 0)
            {
                bool bOk = logicValidator.Validate(tbxLogic.Text, conditions, out message);

                if (bOk)
                {
                    args.IsValid = true;
                }
                else
                {
                    args.IsValid = false;
                    cvLogic.ErrorMessage = message;
                }
            }
            else
            {
                if (tbxLogic.Text == "")
                {
                    args.IsValid = true;
                }
                else
                {
                    args.IsValid = false;
                    cvLogic.ErrorMessage = "There are no conditions, The logical expression must be empty";
                }
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP4 - LOGIC - METHODS
        //

        private void StepLogicIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Please define the logical expression (optional)";

            //Tag Page
            hdfStep.Value = "Step Logic";
            grdLogic.DataBind();

            // Sort by ConditionNumber
            SortDirection direction = SortDirection.Ascending;
            string expression = "ConditionNumber";
            grdLogic.Sort(expression, direction);
        }



        private bool StepLogicNext()
        {
            Page.Validate("Logic");
            if (Page.IsValid)
            {
                // Load
                WorkViewTDS dataSet = new WorkViewTDS();
                dataSet.LFS_WORK_TYPE_VIEW_SORT.Merge(workTypeViewSort, true);
                WorkTypeViewSort model = new WorkTypeViewSort(dataSet);

                if (dataSet.LFS_WORK_TYPE_VIEW_SORT.Rows.Count <= 0)
                {
                    model.LoadByWorkTypeInView(hdfWorkType.Value, int.Parse(hdfCompanyId.Value), true);
                    model.UpdateForEdit(int.Parse(hdfViewId.Value), hdfWorkType.Value, int.Parse(hdfCompanyId.Value));
                }

                // Store tables
                workTypeViewSort = (WorkViewTDS.LFS_WORK_TYPE_VIEW_SORTDataTable)model.Table;
                Session["workTypeViewSort"] = workTypeViewSort;
                
                return true;
            }
            else
            {
                return false;
            }
        }



        private bool StepLogicPrevious()
        {
            return true;
        }      

        #endregion






        #region STEP5 - SORT

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP5 - SORT
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP5 - SORT - AUXILIAR EVENTS
        //

        protected void grdSort_DataBound(object sender, EventArgs e)
        {
            SortEmptyFix(grdSort);
        }



        protected void grdSort_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            StepSortProcessGrid();
        }



        protected void cvGrdSort_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Initialize 
            bool isValidData = true;
            string messageError = "";
            string column = "";
            int numOptionsSelected = 0;

            StepSortProcessGrid();

            int pageCount = grdSort.PageCount;

            for (int i = 0; i < pageCount; i++)
            {
                grdSort.PageIndex = i;
                grdSort.DataBind();

                if (grdSort.Rows.Count > 0)
                {
                    foreach (GridViewRow row in grdSort.Rows)
                    {
                        if (((CheckBox)row.FindControl("cbxSelected")).Checked)
                        {
                            numOptionsSelected++;

                            if (((DropDownList)row.FindControl("ddlOrder")).SelectedValue == " ")
                            {
                                isValidData = false;
                                column = ((Label)row.FindControl("lblColumn")).Text;
                                messageError = messageError + "The selected field (" + column.Trim() + ") need an order<br>";
                            }
                        }
                    }
                }
            }

            if (numOptionsSelected == 0)
            {
                isValidData = false;
                messageError = "At least one option must be selected<br>";
            }

            if (!isValidData)
            {
                args.IsValid = isValidData;
                cvGrdSort.ErrorMessage = messageError;

                if (grdSort.PageIndex != int.Parse(ViewState["sortPageIndex"].ToString()))
                {
                    grdSort.PageIndex = int.Parse(ViewState["sortPageIndex"].ToString());
                    grdSort.DataBind();
                }
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP5 - SORT - METHODS
        //

        private void StepSortByIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Please select the columns to order by";

            //Tag Page
            hdfStep.Value = "Step SortBy";
            grdSort.PageIndex = int.Parse(ViewState["sortPageIndex"].ToString());
            grdSort.DataBind();
        }



        private bool StepSortByNext()
        {
            ViewState["sortPageIndex"] = grdSort.PageIndex;

            Page.Validate("SortBy");

            if (Page.IsValid)
            {
                StepSortProcessGrid();
                workViewSortTemp.Rows.Clear();

                // create dataset
                WorkViewTDS dataSet = new WorkViewTDS();
                dataSet.LFS_WORK_TYPE_VIEW_SORT.Merge(workTypeViewSort, true);
                dataSet.WorkViewSortTemp.Merge(workViewSortTemp, true);

                // process sort by
                WorkViewSortTemp model = new WorkViewSortTemp(dataSet);
                model.ProcessForEdit(int.Parse(hdfViewId.Value), hdfWorkType.Value, int.Parse(hdfCompanyId.Value));

                // get changes
                workViewSortTemp.Rows.Clear();
                workViewSortTemp.Merge(model.Table);

                // store tables
                Session.Remove("workTypeViewSortDummy");
                Session["workTypeViewSort"] = workTypeViewSort;
                Session["workViewSortTemp"] = workViewSortTemp;

                return true;
            }
            else
            {
                return false;
            }
        }



        private bool StepSortByPrevious()
        {
            ViewState["sortPageIndex"] = grdSort.PageIndex;

            return true;
        }



        private void StepSortProcessGrid()
        {
            WorkViewTDS dataSet = new WorkViewTDS();
            dataSet.LFS_WORK_TYPE_VIEW_SORT.Merge(workTypeViewSort, true);
            WorkTypeViewSort model = new WorkTypeViewSort(dataSet);

            // update rows
            if (Session["workTypeViewSortDummy"] == null)
            {
                foreach (GridViewRow row in grdSort.Rows)
                {
                    int sortId = int.Parse(grdSort.DataKeys[row.RowIndex].Values["SortID"].ToString());
                    bool selected = ((CheckBox)row.FindControl("cbxSelected")).Checked;
                    int order = 0;

                    try
                    {
                        order = int.Parse(((DropDownList)row.FindControl("ddlOrder")).SelectedValue);
                    }
                    catch
                    {
                        order = 0;
                    }

                    model.Update(hdfWorkType.Value, int.Parse(hdfCompanyId.Value), sortId, order, selected);
                }

                model.Table.AcceptChanges();

                workTypeViewSort = (WorkViewTDS.LFS_WORK_TYPE_VIEW_SORTDataTable)model.Table;
                Session["workTypeViewSort"] = workTypeViewSort;
            }
        }



        public WorkViewTDS.LFS_WORK_TYPE_VIEW_SORTDataTable GetSort()
        {
            workTypeViewSort = (WorkViewTDS.LFS_WORK_TYPE_VIEW_SORTDataTable)Session["workTypeViewSortDummy"];
            if (workTypeViewSort == null)
            {
                workTypeViewSort = (WorkViewTDS.LFS_WORK_TYPE_VIEW_SORTDataTable)Session["workTypeViewSort"];
            }

            return workTypeViewSort;
        }



        protected void SortEmptyFix(GridView grdSort)
        {
            if (grdSort.Rows.Count == 0)
            {
                WorkViewTDS.LFS_WORK_TYPE_VIEW_SORTDataTable dt = new WorkViewTDS.LFS_WORK_TYPE_VIEW_SORTDataTable();
                dt.AddLFS_WORK_TYPE_VIEW_SORTRow("", 0, 0, "", false, true, "", "", false, 0);
                Session["workTypeViewSortDummy"] = dt;

                grdSort.DataBind();
            }

            // normally executes at all postbacks
            if (grdSort.Rows.Count == 1)
            {
                WorkViewTDS.LFS_WORK_TYPE_VIEW_SORTDataTable dt = (WorkViewTDS.LFS_WORK_TYPE_VIEW_SORTDataTable)Session["workTypeViewSortDummy"];
                if (dt != null)
                {
                    // hide row
                    grdSort.Rows[0].Visible = false;
                    grdSort.Rows[0].Controls.Clear();
                }
            }
        }



        protected string GetOrderSelected(object name)
        {
            string orderSelected = " ";
            if (name != DBNull.Value)
            {
                orderSelected = name.ToString();
            }
            return orderSelected;
        }



        #endregion






        #region STEP6 - SUMMARY

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP6 - SUMMARY
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP6 - SUMMARY - METHODS
        //

        private void StepSummaryIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Summary";

            // Tag Page
            hdfStep.Value = "StepSummary";
            hdfUpdate.Value = "yes";

            // Initialize summary
            WorkView workView = new WorkView(workViewTDS);

            // process view
            WorkViewTDS dataset = new WorkViewTDS();
            dataset.WorkViewDisplayTemp.Merge(workViewDisplayTemp, true);
            dataset.WorkViewConditionNew.Merge(workViewConditionNew, true);
            dataset.WorkViewSortTemp.Merge(workViewSortTemp, true);

            WorkViewDisplayTemp modelWorkViewDisplayTemp = new WorkViewDisplayTemp(dataset);
            WorkViewConditionNew modelWorkViewConditionNew = new WorkViewConditionNew(dataset);
            WorkViewSortTemp modelWorkViewSortTemp = new WorkViewSortTemp(dataset);

            string summary = "";
            summary = summary + "Name: " + tbxName.Text + "\n\n";
            summary = summary + "Columns To Display; " + modelWorkViewDisplayTemp.GetColumnsToDisplay() + "\n\n";
            summary = summary + "Conditions: " + modelWorkViewConditionNew.GetConditionsForSummary(hdfWorkType.Value, int.Parse(hdfCompanyId.Value)) + "\n\n";
            summary = summary + "Logical Expression: " + tbxLogic.Text + "\n\n";
            summary = summary + "Order by: " + modelWorkViewSortTemp.GetSortForSummary() + "\n\n";

            tbxSummary.Text = summary;
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
            title.Text = "Edit View";
        }
        



        

        // ////////////////////////////////////////////////////////////////////////
        // METHODS
        //

        private void RegisterClientScripts()
        {
            // Register client-side events
            HtmlGenericControl body = (HtmlGenericControl)Page.Master.FindControl("myBody");
            body.Attributes.Add("onunload", "OnUnload();");

            // Register content variables
            string contentVariables = "";
            contentVariables += "var hdfUpdateId = '" + hdfUpdate.ClientID + "';";
            contentVariables += "var hdfStepId = '" + hdfStep.ClientID + "';";
            
            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./view_edit.js");
        }



        private void Save()
        {
            // process view
            WorkViewTDS dataset = new WorkViewTDS();
            dataset.WorkViewDisplayTemp.Merge(workViewDisplayTemp, true);
            dataset.WorkViewConditionNew.Merge(workViewConditionNew, true);
            dataset.WorkViewSortTemp.Merge(workViewSortTemp, true);

            WorkViewDisplayTemp modelWorkViewDisplayTemp = new WorkViewDisplayTemp(dataset);
            WorkViewConditionNew modelWorkViewConditionNew = new WorkViewConditionNew(dataset);
            WorkViewSortTemp modelWorkViewSortTemp = new WorkViewSortTemp(dataset);

            // get parameters
            int viewId = int.Parse(hdfViewId.Value);
            int companyId = int.Parse(hdfCompanyId.Value);
            int loginId = Convert.ToInt32(Session["loginID"]);
            string name = tbxName.Text;
            string type = ddlType.SelectedValue;
            string logic = tbxLogic.Text;
            string sqlCommand = GetSqlCommand();
            string workType = hdfWorkType.Value;

            if (!(Convert.ToBoolean(Session["sgLFS_VIEWS_EDIT"])))
            {
                if ((string)Request.QueryString["fm_type"] == "Rehab Assessment")
                {
                    if (Convert.ToBoolean(Session["sgLFS_CWP_REHABASSESSMENT_VIEW"]))
                    {
                        type = "Personal";
                    }
                }

                if ((string)Request.QueryString["fm_type"] == "Full Length Lining")
                {                    
                    if (Convert.ToBoolean(Session["sgLFS_CWP_FULLLENGTHLINING_VIEW"]))
                    {
                        type = "Personal";
                    }
                }

                if ((string)Request.QueryString["fm_type"] == "Junction Lining")
                {                    
                    if (Convert.ToBoolean(Session["sgLFS_CWP_JUNCTIONLINING_VIEW"]))
                    {
                        type = "Personal";
                    }
                }

                if ((string)Request.QueryString["fm_type"] == "Point Repairs")
                {                    
                    if (Convert.ToBoolean(Session["sgLFS_CWP_POINTREPAIRS_VIEW"]))
                    {
                        type = "Personal";
                    }
                }

                if ((string)Request.QueryString["fm_type"] == "Manhole Rehabilitation")
                {
                    if (Convert.ToBoolean(Session["sgLFS_CWP_MANHOLEREHABILITATION_VIEW"]))
                    {
                        type = "Personal";
                    }
                }
            }

            // save to database
            DB.Open();
            DB.BeginTransaction();
            try
            {
                // Update view table
                WorkView workView = new WorkView(null);
                workView.SaveForEdit(viewId, loginId, name, type, logic, sqlCommand, workType, companyId, name, type);

                // Update other views table
                modelWorkViewDisplayTemp.SaveForEdit();
                modelWorkViewConditionNew.SaveForEdit(viewId, companyId, workType);
                modelWorkViewSortTemp.SaveForEdit();

                DB.CommitTransaction();
            }
            catch (Exception ex)
            {
                DB.RollbackTransaction();

                string url = string.Format("./../../error_page.aspx?error={0}", ex.Message.Replace('\n', ' '));
                Response.Redirect(url);
            }
        }



        private string GetSqlCommand()
        {
            string where = GetWhere();
            string orderBy = GetOrder();
            string workType = hdfWorkType.Value;
            string commandText = "";

            if (workType == "Junction Lining")
            {
                where = where + " AND " +
                   "        (AASS.AssetID NOT IN " +
                   "            ( " +
                   "                SELECT AASS2.AssetID " +
                   "                FROM AM_ASSET_SEWER_SECTION AASS2 INNER JOIN" +
                   "                LFS_WORK LW2 ON LW2.AssetID = AASS2.AssetID AND LW2.Deleted = 0 AND LW2.WorkType = 'Full Length Lining' INNER JOIN" +
                   "                LFS_WORK_FULLLENGTHLINING LWFLL ON LW2.WorkID = LWFLL.WorkID INNER JOIN " +
                   "                LFS_WORK_FULLLENGTHLINING_P1 LWFLP1 ON LWFLP1.WorkID = LW2.WorkID " +
                   "                WHERE (AASS2.AssetID = AASS.AssetID)  AND (LW2.ProjectID = LW.ProjectID) " +
                   "                AND (LWFLP1.RoboticPrepCompleted = 1) AND (LWFLP1.RoboticPrepCompletedDate is null) AND (LW2.Deleted = 0)" +
                   "            )" +
                   "        )";

                commandText = String.Format("SELECT CAST(0 AS bit) AS Selected,AASL.AssetID AS AssetID_, AASS.AssetID, AASL.Section_, AASS.SectionID, AASL.LateralID, LASS.SubArea, AASS.Street, AASS.USMH, AASS.DSMH, LW.Comments, " +
                        "(SELECT MHID FROM AM_ASSET_SEWER_MH AASMH WHERE AASMH.AssetID = AASS.USMH) AS USMHDescription, (SELECT MHID FROM AM_ASSET_SEWER_MH AASMH WHERE AASMH.AssetID = AASS.DSMH) AS DSMHDescription, AASL.Address, " +
                        "0 AS City, '' AS CityDescription, LWJLL.PipeLocated, LWJLL.ServicesLocated, LWJLL.CoInstalled, LWJLL.BackfilledConcrete, LWJLL.BackfilledSoil, LWJLL.Grouted, LWJLL.Cored, LWJLL.Prepped, LWJLL.Measured, " +
                        "LWJLL.InProcess, LWJLL.InStock, LWJLL.Delivered, LWJLL.PreVideo, LWJLL.LinerInstalled, LWJLL.FinalVideo, LW.History, LWJLL.VideoInspection, LWJLL.CoRequired, LWJLL.PitRequired, LWJLL.CoPitLocation, " +
                        "AASL.DistanceFromUSMH, AASL.DistanceFromDSMH, LWJLL.Cost, LWJLL.PostContractDigRequired, LWJLL.LinerSize, LWJLL.CoCutDown, LWJLL.FinalRestoration, AASS.FlowOrderID, LASLC.ClientLateralID, " +
                        "LWJLL.VideoLengthToPropertyLine, LWJLL.LiningThruCo, LMS.OriginalSectionID, LWJLL.NoticeDelivered, LWJLL.BuildRebuild, LWJLL.HamiltonInspectionNumber, AASL.ConnectionType, AASS.Size_ AS MainSize, LWJLL.Flange, " +
                        "LWJLL.Gasket, LWJLL.DepthOfLocated, LWJLL.DigRequiredPriorToLining, LWJLL.DigRequiredPriorToLiningCompleted, LWJLL.DigRequiredAfterLining, LWJLL.DigRequiredAfterLiningCompleted, LWJLL.OutOfScope, LWJLL.HoldClientIssue, " +
                        "LWJLL.HoldClientIssueResolved, LWJLL.HoldLFSIssue, LWJLL.HoldLFSIssueResolved, LWJLL.LateralRequiresRoboticPrep, LWJLL.LateralRequiresRoboticPrepCompleted, LWJLL.PrepType, LWJLL.LinerType, LWJLL.DyeTestReq, LWJLL.DyeTestComplete " +
                        "FROM AM_ASSET_SEWER_LATERAL AASL INNER JOIN " +
                            "LFS_WORK LW ON AASL.AssetID = LW.AssetID INNER JOIN " +
                            "LFS_PROJECT P ON LW.ProjectID = P.ProjectID LEFT JOIN " +
                            "LFS_ASSET_SEWER_LATERAL_CLIENT LASLC ON AASL.AssetID = LASLC.AssetID AND P.ClientID = LASLC.ClientID INNER JOIN " +
                            "AM_ASSET AA ON AASL.AssetID = AA.AssetID INNER JOIN " +
                            "AM_ASSET_SEWER AAS ON AASL.AssetID = AAS.AssetID INNER JOIN " +
                            "AM_ASSET_SEWER_SECTION AASS ON AASL.Section_ = AASS.AssetID INNER JOIN " +
                            "LFS_ASSET_SEWER_SECTION LASS ON AASS.AssetID = LASS.AssetID INNER JOIN " +
                            "LFS_WORK_JUNCTIONLINING_LATERAL LWJLL ON LW.WorkID = LWJLL.WorkID INNER JOIN " +
                            "LFS_WORK_JUNCTIONLINING_SECTION LWJLS ON LWJLL.SectionWorkID = LWJLS.WorkID LEFT OUTER JOIN " +
                            "AM_ASSET_SEWER_MH AASUSMH ON AASS.USMH = AASUSMH.AssetID LEFT JOIN " +
                            "AM_ASSET_SEWER_MH AASDSMH ON AASS.DSMH = AASDSMH.AssetID LEFT JOIN " +
                            "LFS_MIGRATED_SECTIONS LMS ON AASS.AssetID = LMS.NewID " +
                        "WHERE {0} ORDER BY {1}", where, orderBy);
            }

            if (workType == "Full Length Lining")
            {
                commandText = String.Format("SELECT CAST(0 AS bit) AS Selected,AASS.AssetID AS AssetID_, AASS.AssetID, " +
                        " AASS.AssetID, AASS.SectionID, LASS.SubArea, AASS.Street, AASS.USMH, AASS.DSMH, LWF.ProposedLiningDate, LWF.DeadlineLiningDate,  " +
                          " LW.Comments, " +
                          "  (SELECT MHID " +
                          "    FROM AM_ASSET_SEWER_MH AASMH " +
                          "    WHERE AASMH.AssetID = AASS.USMH) AS USMHDescription, " +
                          "  (SELECT MHID " +
                          "    FROM AM_ASSET_SEWER_MH AASMH " +
                          "    WHERE AASMH.AssetID = AASS.DSMH) AS DSMHDescription, " +
                          " AASS.FlowOrderID, LWR.PreFlushDate, LWR.PreVideoDate, AASS.MapSize, AASS.MapLength, LMS.OriginalSectionID, " +
                          " AASS.Size_, AASS.Length, LWFLLM2.VideoLength, AASS.Laterals, AASS.LiveLaterals, LWF.ClientID, LWF.P1Date, LWFLP1.CXIsRemoved, LWF.M1Date, " +
                          " (SELECT TOP 1 MaterialType FROM AM_ASSET_SEWER_MATERIAL AASM WHERE (AASM.AssetID = AASS.AssetID) AND (AASM.Deleted = 0) ORDER BY Date_ DESC) AS MaterialType, " +
                          " AASUSMH.Address AS USMHAddress, AASS.USMHDepth, LASS.USMHMouth12, LASS.USMHMouth1, LASS.USMHMouth2, LASS.USMHMouth3, LASS.USMHMouth4, LASS.USMHMouth5, " +
                          " AASDSMH.Address AS DSMHAddress, AASS.DSMHDepth, LASS.DSMHMouth12, LASS.DSMHMouth1, LASS.DSMHMouth2, LASS.DSMHMouth3, LASS.DSMHMouth4, LASS.DSMHMouth5, LWFM1.TrafficControl, LWFM1.SiteDetails, " +
                          " LWFM1.PipeSizeChange, LWFM1.StandardBypass, LWFM1.StandardBypassComments, LWFM1.TrafficControlDetails, LWFM1.MeasurementType, LWFM1.MeasurementFromMH, LWFM1.VideoDoneFromMH, LWFM1.VideoDoneToMH, " +
                          " LWF.M2Date, LWF.InstallDate, LWF.FinalVideoDate, " +
                          " LWFM1.MeasurementTakenBy as M1MeasurementTakenBy, LWFLLM2.MeasurementTakenBy as M2MeasurementTakenBy, LWFLLM2.DropPipe, LWFLLM2.DropPipeInvertDepth, LWFLLM2.CappedLaterals, LWFLLM2.LineWithID, LWFLLM2.HydrantAddress, " +
                          " LWFLLM2.DistanceToInversionMH, LWFLLM2.HydroWireWithin10FtOfInversionMH, LWFLLM2.SurfaceGrade, LWFLLM2.HydroPulley, LWFLLM2.FridgeCart, LWFLLM2.TwoPump, LWFLLM2.SixBypass, LWFLLM2.Scaffolding, LWFLLM2.WinchExtention,  " +
                          " LWFLLM2.ExtraGenerator, LWFLLM2.GreyCableExtension, LWFLLM2.EasementMats, LWFLLM2.RampRequired, LWFLLM2.CameraSkid, LWF.IssueIdentified, LWF.IssueLFS, LWF.IssueClient, LWF.IssueSales, LWF.IssueGivenToClient, LWF.IssueResolved, LWF.IssueInvestigation, LASS.Thickness, " +
                          " LWFLP1.RoboticPrepCompleted, LWFLP1.RoboticPrepCompletedDate "+
                         " FROM LFS_WORK LW INNER JOIN" +
                         "  AM_ASSET AA ON LW.AssetID = AA.AssetID INNER JOIN" +
                         "  AM_ASSET_SEWER AAS ON AA.AssetID = AAS.AssetID INNER JOIN" +
                         "  AM_ASSET_SEWER_SECTION AASS ON AAS.AssetID = AASS.AssetID INNER JOIN" +
                         "  LFS_ASSET_SEWER_SECTION LASS ON AAS.AssetID = LASS.AssetID INNER JOIN " +
                         "  LFS_WORK_FULLLENGTHLINING_M1 LWFM1 ON LW.WorkID = LWFM1.WorkID INNER JOIN " +
                         "  LFS_WORK_FULLLENGTHLINING_M2 LWFLLM2 ON LW.WorkID = LWFLLM2.WorkID INNER JOIN " +
                         "  LFS_WORK_FULLLENGTHLINING LWF ON LW.WorkID = LWF.WorkID INNER JOIN " +
                         "  LFS_WORK_FULLLENGTHLINING_P1 LWFLP1 ON LW.WorkID = LWFLP1.WorkID LEFT JOIN " +
                         "  LFS_MIGRATED_SECTIONS LMS ON AA.AssetID = LMS.NewID LEFT JOIN" +
                         "  LFS_WORK LW2 ON LW2.AssetID = AA.AssetID AND LW2.Deleted = 0 AND LW2.WorkType = 'Rehab Assessment' AND LW2.ProjectID = LW.ProjectID LEFT JOIN " +
                         "  LFS_WORK_REHABASSESSMENT LWR ON LW2.WorkID = LWR.WorkID LEFT JOIN " +
                         "  AM_ASSET_SEWER_MH AASUSMH ON AASS.USMH = AASUSMH.AssetID LEFT JOIN " +
                         "  AM_ASSET_SEWER_MH AASDSMH ON AASS.DSMH = AASDSMH.AssetID " +
                         "WHERE {0} ORDER BY {1}", where, orderBy);
            }

            if (workType == "Rehab Assessment")
            {
                commandText = String.Format("SELECT CAST(0 AS bit) AS Selected, AASS.AssetID AS AssetID_, " +
                         " AASS.AssetID, AASS.SectionID, LASS.SubArea, AASS.Street, AASS.USMH, AASS.DSMH, " +
                          " LW.Comments, " +
                          "  (SELECT MHID " +
                          "    FROM AM_ASSET_SEWER_MH AASMH " +
                          "    WHERE AASMH.AssetID = AASS.USMH) AS USMHDescription, " +
                          "  (SELECT MHID " +
                          "    FROM AM_ASSET_SEWER_MH AASMH " +
                          "    WHERE AASMH.AssetID = AASS.DSMH) AS DSMHDescription, " +
                          " AASS.FlowOrderID, LWR.PreFlushDate, LWR.PreVideoDate, AASS.MapSize, AASS.MapLength, LMS.OriginalSectionID, " +
                          " AASS.Size_, AASS.Length, LWFLLM2.VideoLength, AASS.Laterals, AASS.LiveLaterals, LWFLL.ClientID, LWFLL.P1Date, LWFLP1.CXIsRemoved, LWFLL.M1Date, LWFM1.MeasurementTakenBy, " +
                          " (SELECT TOP 1 MaterialType FROM AM_ASSET_SEWER_MATERIAL AASM WHERE (AASM.AssetID = AASS.AssetID) AND (AASM.Deleted = 0) ORDER BY Date_ DESC) AS MaterialType, " +
                          " AASUSMH.Address AS USMHAddress, AASS.USMHDepth, LASS.USMHMouth12, LASS.USMHMouth1, LASS.USMHMouth2, LASS.USMHMouth3, LASS.USMHMouth4, LASS.USMHMouth5, " +
                          " AASDSMH.Address AS DSMHAddress, AASS.DSMHDepth, LASS.DSMHMouth12, LASS.DSMHMouth1, LASS.DSMHMouth2, LASS.DSMHMouth3, LASS.DSMHMouth4, LASS.DSMHMouth5, LWFM1.TrafficControl, LWFM1.SiteDetails, " +
                          " LWFM1.PipeSizeChange, LWFM1.StandardBypass, LWFM1.StandardBypassComments, LWFM1.TrafficControlDetails, LWFM1.MeasurementType, LWFM1.MeasurementFromMH, LWFM1.VideoDoneFromMH, LWFM1.VideoDoneToMH, LASS.Thickness, " +
                          " LWFLP1.RoboticPrepCompleted, LWFLP1.RoboticPrepCompletedDate " +
                          " FROM LFS_WORK_REHABASSESSMENT LWR INNER JOIN " +
                          "      LFS_WORK LW ON LWR.WorkID = LW.WorkID INNER JOIN " +
                          "      AM_ASSET AA ON LW.AssetID = AA.AssetID INNER JOIN " +
                          "      AM_ASSET_SEWER AAS ON AA.AssetID = AAS.AssetID INNER JOIN " +
                          "      AM_ASSET_SEWER_SECTION AASS ON AAS.AssetID = AASS.AssetID INNER JOIN " +
                          "      LFS_ASSET_SEWER_SECTION LASS ON AAS.AssetID = LASS.AssetID LEFT JOIN " +
                          "      LFS_MIGRATED_SECTIONS LMS ON AA.AssetID = LMS.NewID LEFT JOIN " +
                          "      AM_ASSET_SEWER_MH AASUSMH ON AASS.USMH = AASUSMH.AssetID LEFT JOIN " +
                          "      AM_ASSET_SEWER_MH AASDSMH ON AASS.DSMH = AASDSMH.AssetID LEFT JOIN " +
                          "      LFS_WORK LW2 ON LW2.AssetID = AA.AssetID AND LW2.Deleted = 0 AND LW2.WorkType = 'Full Length Lining' AND LW2.ProjectID = LW.ProjectID LEFT JOIN " +
                          "      LFS_WORK_FULLLENGTHLINING LWFLL ON LW2.WorkID = LWFLL.WorkID LEFT JOIN " +
                          "      LFS_WORK_FULLLENGTHLINING_M1 LWFM1 ON LWFM1.WorkID = LW2.WorkID LEFT JOIN " +
                          "      LFS_WORK_FULLLENGTHLINING_M2 LWFLLM2 ON LWFLLM2.WorkID = LW2.WorkID LEFT JOIN " +
                          "      LFS_WORK_FULLLENGTHLINING_P1 LWFLP1 ON LWFLP1.WorkID = LW2.WorkID " +
                         "WHERE {0} ORDER BY {1}", where, orderBy);
            }

            if (workType == "Point Repairs")
            {
                // For Repairs (RepairPointID, Type, DefectQualifier, DefectDetails, Approval, ReamDistance, LinerDistance, Direction, LTMH, VTMH, Distance, MHShot, GroutDistance, ExtraRepair, Cancelled, Reinstates, , ReamDate, InstallDate, GroutDate)
                hdfRepairExistsInConditions.Value = "False";
                string conditionRepair = " (LWPRR.RepairPointID";

                foreach (GridViewRow row in grdConditions.Rows)
                {
                    if ((row.RowType == DataControlRowType.DataRow) && ((row.RowState == DataControlRowState.Normal) || (row.RowState == (DataControlRowState.Normal | DataControlRowState.Alternate))))
                    {
                        // Mark if there is a repair
                        string column = ((Label)row.FindControl("lblName")).Text;
                        if ((column == "ID (Repair)") || (column == "Repair Type") || (column == "Defect Qualifier") || (column == "Defect Details") || (column == "Approval") || (column == "Ream Distance") || (column == "Liner Distance") || (column == "Direction") || (column == "LT @ MH") || (column == "VT @ MH") || (column == "Distance") || (column == "MH Shot?") || (column == "Grout Distance") || (column == "Extra Repair") || (column == "Cancelled") || (column == "Reinstates") || (column == "Ream Date") || (column == "Install Date") || (column == "Grout Date") || (column == "Repair Comments") || (column == "Repair Size") || (column == "Repair Length"))
                        {
                            hdfRepairExistsInConditions.Value = "True";

                            if (column == "Repair Type") conditionRepair += " +' / '+ LWPRR.Type ";
                            if (column == "Defect Qualifier") conditionRepair += " +' / '+ LWPRR.DefectQualifier ";
                            if (column == "Defect Details") conditionRepair += " +' / '+ LWPRR.DefectDetails  ";
                            if (column == "Approval") conditionRepair += " +' / '+ LWPRR.Approval  ";
                            if (column == "Ream Distance") conditionRepair += " +' / '+ LWPRR.ReamDistance  ";
                            if (column == "Liner Distance") conditionRepair += " +' / '+ LWPRR.LinerDistance  ";
                            if (column == "Direction") conditionRepair += " +' / '+ LWPRR.Direction ";
                            if (column == "LT @ MH") conditionRepair += "  +' / '+ LWPRR.LTMH  ";
                            if (column == "VT @ MH") conditionRepair += " +' / '+ LWPRR.VTMH ";
                            if (column == "Distance") conditionRepair += " +' / '+ LWPRR.Distance  ";
                            if (column == "MH Shot?") conditionRepair += " +' / '+ LWPRR.MHShot ";
                            if (column == "Grout Distance") conditionRepair += "  +' / '+ LWPRR.GroutDistance  ";
                            if (column == "Reinstates") conditionRepair += "  +' / '+ CAST(LWPRR.Reinstates AS nvarchar) ";
                            if (column == "Ream Date") conditionRepair += "  +' / '+ CONVERT(nvarchar,LWPRR.ReamDate,101)  ";
                            if (column == "Install Date") conditionRepair += "  +' / '+ CONVERT(nvarchar,LWPRR.InstallDate,101)  ";
                            if (column == "Grout Date") conditionRepair += "  +' / '+ CONVERT(nvarchar,LWPRR.GroutDate,101)  ";
                            if (column == "Repair Comments") conditionRepair += "  +' / '+ CAST(LWPRR.Comments AS nvarchar)  ";
                            if (column == "Repair Size") conditionRepair += "  +' / '+ LWPRR.Size_  ";
                            if (column == "Repair Length") conditionRepair += "  +' / '+ LWPRR.Length  ";
                            if (column == "Extra Repair") conditionRepair += " +' / '+ (CASE WHEN LWPRR.ExtraRepair = 0 THEN 'No' ELSE 'Yes' END)  ";
                            if (column == "Cancelled") conditionRepair += " +' / '+ (CASE WHEN LWPRR.Cancelled = 0 THEN 'No' ELSE 'Yes' END)  ";
                        }
                    }
                }

                conditionRepair += ") ";

                if (hdfRepairExistsInConditions.Value == "True")
                {
                    commandText = String.Format("SELECT CAST(0 AS bit) AS Selected, " +
                         "  ( CAST(AASS.AssetID AS nvarchar) + (CASE WHEN LWPRR.RepairPointID is null THEN '' ELSE '-'+LWPRR.RepairPointID END) ) AS AssetID_, AASS.AssetID, " +
                         " AASS.SectionID, AASS.Street, AASS.USMH, AASS.DSMH, " +
                         " (SELECT MHID FROM AM_ASSET_SEWER_MH AASMH WHERE AASMH.AssetID = AASS.USMH) AS USMHDescription, " +
                         " (SELECT MHID FROM AM_ASSET_SEWER_MH AASMH WHERE AASMH.AssetID = AASS.DSMH) AS DSMHDescription, " +
                         " AASS.FlowOrderID, LASS.SubArea, LWPR.ProposedLiningDate, LWPR.DeadlineLiningDate, LWPR.FinalVideoDate, " +
                         " (SELECT TOP 1 LWFP1.CXIsRemoved FROM LFS_WORK_FULLLENGTHLINING_P1 LWFP1 INNER JOIN LFS_WORK_FULLLENGTHLINING LWFLL ON LWFP1.WorkID = LWFLL.WorkID INNER JOIN LFS_WORK LW1 ON LWFLL.WorkID = LW1.WorkID INNER JOIN LFS_WORK LW2 ON (LW2.AssetID = AA.AssetID) AND (LW2.WorkType = 'Rehab Assessment') AND (LW2.ProjectID = LW.ProjectID) WHERE (LW1.AssetID = AA.AssetID) AND (LWFLL.Deleted = 0) ORDER BY LWFLL.WorkID DESC) AS CXIsRemoved, " +
                         " LW.Comments, (SELECT Address FROM AM_ASSET_SEWER_MH AASMH WHERE AASMH.AssetID = AASS.USMH) AS USMHAddress, (SELECT Address FROM AM_ASSET_SEWER_MH AASMH WHERE AASMH.AssetID = AASS.DSMH) AS DSMHAddress, AASS.MapSize, AASS.Size_, AASS.MapLength, AASS.Length, " +
                         " (SELECT TOP 1 LWFM2.VideoLength FROM LFS_WORK_FULLLENGTHLINING_M2 LWFM2 INNER JOIN LFS_WORK_FULLLENGTHLINING LWFLL ON LWFM2.WorkID = LWFLL.WorkID INNER JOIN LFS_WORK LW ON LWFLL.WorkID = LW.WorkID INNER JOIN LFS_WORK LW2 ON (LW2.AssetID = AA.AssetID) AND (LW2.WorkType = 'Rehab Assessment') AND (LW2.ProjectID = LW.ProjectID) WHERE (LW.AssetID = AA.AssetID) AND (LWFLL.Deleted = 0) ORDER BY LWFLL.WorkID DESC) AS VideoLength, " +
                         " AASS.Laterals, AASS.LiveLaterals, LWPR.ClientID, LWPR.MeasurementTakenBy, " +
                         " (SELECT TOP 1 LWR.PreFlushDate FROM LFS_WORK_REHABASSESSMENT LWR INNER JOIN LFS_WORK LW ON LWR.WorkID = LW.WorkID WHERE (LW.AssetID = AA.AssetID) AND (LWR.Deleted = 0) ORDER BY LWR.WorkID DESC) AS PreFlushDate, " +
                         " (SELECT TOP 1 LWR.PreVideoDate FROM LFS_WORK_REHABASSESSMENT LWR INNER JOIN LFS_WORK LW ON LWR.WorkID = LW.WorkID WHERE (LW.AssetID = AA.AssetID) AND (LWR.Deleted = 0) ORDER BY LWR.WorkID DESC) AS PreVideoDate, " +
                         "  (SELECT TOP 1 LWFLL.P1Date FROM LFS_WORK_FULLLENGTHLINING LWFLL INNER JOIN LFS_WORK LW ON LWFLL.WorkID = LW.WorkID INNER JOIN LFS_WORK LW2 ON (LW2.AssetID = AA.AssetID) AND (LW2.WorkType = 'Rehab Assessment') AND (LW2.ProjectID = LW.ProjectID) WHERE (LW.AssetID = AA.AssetID) AND (LWFLL.Deleted = 0) ORDER BY LWFLL.WorkID DESC) AS P1Date, " +
                         " LWPR.RepairConfirmationDate, (SELECT TOP 1 LWFM1.TrafficControl FROM LFS_WORK_FULLLENGTHLINING_M1 LWFM1 INNER JOIN LFS_WORK_FULLLENGTHLINING LWFLL ON LWFM1.WorkID = LWFLL.WorkID INNER JOIN LFS_WORK LW ON LWFLL.WorkID = LW.WorkID INNER JOIN LFS_WORK LW2 ON (LW2.AssetID = AA.AssetID) AND (LW2.WorkType = 'Rehab Assessment') AND (LW2.ProjectID = LW.ProjectID) WHERE (LW.AssetID = AA.AssetID) AND (LWFLL.Deleted = 0) ORDER BY LWFLL.WorkID DESC) AS TrafficControl," +
                         " (SELECT TOP 1 MaterialType FROM AM_ASSET_SEWER_MATERIAL AASM WHERE (AASM.AssetID = AASS.AssetID) AND (AASM.Deleted = 0) ORDER BY Date_ DESC) AS MaterialType, LWPR.BypassRequired, " +
                         " CAST(0 AS bit) AS RoboticPrepRequired, " +
                         " LWPR.RoboticDistances, LWPR.EstimatedJoints, LWPR.JointsTestSealed, LWPR.IssueIdentified, LWPR.IssueLFS, LWPR.IssueClient, LWPR.IssueSales, LWPR.IssueGivenToClient, LWPR.IssueInvestigation, LWPR.IssueResolved, " +
                         " LWPR.WorkID, {2}  AS RepairPointID" +
                         " " +
                         " FROM LFS_WORK LW INNER JOIN " +
                         "  AM_ASSET AA ON LW.AssetID = AA.AssetID INNER JOIN " +
                         "  AM_ASSET_SEWER AAS ON AA.AssetID = AAS.AssetID INNER JOIN " +
                         "  AM_ASSET_SEWER_SECTION AASS ON AAS.AssetID = AASS.AssetID INNER JOIN " +
                         "  LFS_ASSET_SEWER_SECTION LASS ON AAS.AssetID = LASS.AssetID INNER JOIN " +
                         "  LFS_WORK_POINT_REPAIRS LWPR ON LW.WorkID = LWPR.WorkID LEFT JOIN " +
                         "  LFS_WORK_POINT_REPAIRS_REPAIR LWPRR ON LWPR.WorkID = LWPRR.WorkID" +
                         "                                               " +
                         " WHERE {0} ORDER BY {1}", where, orderBy, conditionRepair);
                }
                else
                {
                    // For normal searches
                    commandText = String.Format("SELECT CAST(0 AS bit) AS Selected, AASS.AssetID AS AssetID_, AASS.AssetID, " +
                             " AASS.SectionID, AASS.Street, AASS.USMH, AASS.DSMH, " +
                             " (SELECT MHID FROM AM_ASSET_SEWER_MH AASMH WHERE AASMH.AssetID = AASS.USMH) AS USMHDescription, " +
                             " (SELECT MHID FROM AM_ASSET_SEWER_MH AASMH WHERE AASMH.AssetID = AASS.DSMH) AS DSMHDescription, " +
                             " AASS.FlowOrderID, LASS.SubArea, LWPR.ProposedLiningDate, LWPR.DeadlineLiningDate, LWPR.FinalVideoDate, " +
                             " (SELECT TOP 1 LWFP1.CXIsRemoved FROM LFS_WORK_FULLLENGTHLINING_P1 LWFP1 INNER JOIN LFS_WORK_FULLLENGTHLINING LWFLL ON LWFP1.WorkID = LWFLL.WorkID INNER JOIN LFS_WORK LW1 ON LWFLL.WorkID = LW1.WorkID INNER JOIN LFS_WORK LW2 ON (LW2.AssetID = AA.AssetID) AND (LW2.WorkType = 'Rehab Assessment') AND (LW2.ProjectID = LW.ProjectID) WHERE (LW1.AssetID = AA.AssetID) AND (LWFLL.Deleted = 0) ORDER BY LWFLL.WorkID DESC) AS CXIsRemoved, " +
                             " LW.Comments, (SELECT Address FROM AM_ASSET_SEWER_MH AASMH WHERE AASMH.AssetID = AASS.USMH) AS USMHAddress, (SELECT Address FROM AM_ASSET_SEWER_MH AASMH WHERE AASMH.AssetID = AASS.DSMH) AS DSMHAddress, AASS.MapSize, AASS.Size_, AASS.MapLength, AASS.Length, " +
                             " (SELECT TOP 1 LWFM2.VideoLength FROM LFS_WORK_FULLLENGTHLINING_M2 LWFM2 INNER JOIN LFS_WORK_FULLLENGTHLINING LWFLL ON LWFM2.WorkID = LWFLL.WorkID INNER JOIN LFS_WORK LW ON LWFLL.WorkID = LW.WorkID INNER JOIN LFS_WORK LW2 ON (LW2.AssetID = AA.AssetID) AND (LW2.WorkType = 'Rehab Assessment') AND (LW2.ProjectID = LW.ProjectID) WHERE (LW.AssetID = AA.AssetID) AND (LWFLL.Deleted = 0) ORDER BY LWFLL.WorkID DESC) AS VideoLength, " +
                             " AASS.Laterals, AASS.LiveLaterals, LWPR.ClientID, LWPR.MeasurementTakenBy, " +
                             " (SELECT TOP 1 LWR.PreFlushDate FROM LFS_WORK_REHABASSESSMENT LWR INNER JOIN LFS_WORK LW ON LWR.WorkID = LW.WorkID WHERE (LW.AssetID = AA.AssetID) AND (LWR.Deleted = 0) ORDER BY LWR.WorkID DESC) AS PreFlushDate, " +
                             " (SELECT TOP 1 LWR.PreVideoDate FROM LFS_WORK_REHABASSESSMENT LWR INNER JOIN LFS_WORK LW ON LWR.WorkID = LW.WorkID WHERE (LW.AssetID = AA.AssetID) AND (LWR.Deleted = 0) ORDER BY LWR.WorkID DESC) AS PreVideoDate, " +
                             " (SELECT TOP 1 LWFLL.P1Date FROM LFS_WORK_FULLLENGTHLINING LWFLL INNER JOIN LFS_WORK LW ON LWFLL.WorkID = LW.WorkID INNER JOIN LFS_WORK LW2 ON (LW2.AssetID = AA.AssetID) AND (LW2.WorkType = 'Rehab Assessment') AND (LW2.ProjectID = LW.ProjectID) WHERE (LW.AssetID = AA.AssetID) AND (LWFLL.Deleted = 0) ORDER BY LWFLL.WorkID DESC) AS P1Date, " +
                             " LWPR.RepairConfirmationDate, (SELECT TOP 1 LWFM1.TrafficControl FROM LFS_WORK_FULLLENGTHLINING_M1 LWFM1 INNER JOIN LFS_WORK_FULLLENGTHLINING LWFLL ON LWFM1.WorkID = LWFLL.WorkID INNER JOIN LFS_WORK LW ON LWFLL.WorkID = LW.WorkID INNER JOIN LFS_WORK LW2 ON (LW2.AssetID = AA.AssetID) AND (LW2.WorkType = 'Rehab Assessment') AND (LW2.ProjectID = LW.ProjectID) WHERE (LW.AssetID = AA.AssetID) AND (LWFLL.Deleted = 0) ORDER BY LWFLL.WorkID DESC) AS TrafficControl," +
                             " (SELECT TOP 1 MaterialType FROM AM_ASSET_SEWER_MATERIAL AASM WHERE (AASM.AssetID = AASS.AssetID) AND (AASM.Deleted = 0) ORDER BY Date_ DESC) AS Material, LWPR.BypassRequired, " +
                             " LWPR.RoboticDistances, LWPR.EstimatedJoints, LWPR.JointsTestSealed, LWPR.IssueIdentified, LWPR.IssueLFS, LWPR.IssueClient, LWPR.IssueSales, LWPR.IssueGivenToClient, LWPR.IssueInvestigation, LWPR.IssueResolved, " +
                             " LWPR.WorkID, '' AS RepairPointID " +
                                 " " +
                             " FROM LFS_WORK LW INNER JOIN " +
                             "  AM_ASSET AA ON LW.AssetID = AA.AssetID INNER JOIN " +
                             "  AM_ASSET_SEWER AAS ON AA.AssetID = AAS.AssetID INNER JOIN " +
                             "  AM_ASSET_SEWER_SECTION AASS ON AAS.AssetID = AASS.AssetID INNER JOIN " +
                             "  LFS_ASSET_SEWER_SECTION LASS ON AAS.AssetID = LASS.AssetID INNER JOIN " +
                             "  LFS_WORK_POINT_REPAIRS LWPR ON LW.WorkID = LWPR.WorkID LEFT JOIN " +
                             "  AM_ASSET_SEWER_MH AASUSMH ON AASS.USMH = AASUSMH.AssetID LEFT JOIN " +
                             "  AM_ASSET_SEWER_MH AASDSMH ON AASS.DSMH = AASDSMH.AssetID " +
                             "                                               " +
                             " WHERE {0} ORDER BY {1}", where, orderBy);
                }                
            }

            if (workType == "Manhole Rehabilitation")
            {
                commandText = String.Format("SELECT AASMH.AssetID, AASMH.MHID, AASMH.Latitud AS Latitude, AASMH.Longitude, AASMH.Address, AASMH.Deleted, " +
                 "  AASMH.COMPANY_ID, AASMH.ManholeShape,  AASMH.Location, AASMH.MaterialID, AASMH.TotalDepth, " +
                 "  AASMH.TotalSurfaceArea, LASMH.ConditionRating, " +
                 "  LW.ProjectID, LW.WorkID,  LWMR.PreppedDate, LWMR.SprayedDate, LWMR.BatchID, " +
                 "  LWMRB.Date AS BatchDate, LWMRB.Description AS BatchDescription, LW.Comments, " +
                 "  CAST(0 AS bit) AS Selected  " +

                 " FROM         AM_ASSET AA INNER JOIN " +
                 "      AM_ASSET_SEWER AAS ON AA.AssetID = AAS.AssetID INNER JOIN " +
                 "      AM_ASSET_SEWER_MH AASMH ON AAS.AssetID = AASMH.AssetID INNER JOIN " +
                 "      LFS_ASSET_SEWER_MH LASMH ON AA.AssetID = LASMH.AssetID LEFT OUTER  JOIN " +
                 "      LFS_WORK AS LW ON AA.AssetID = LW.AssetID LEFT OUTER JOIN " +
                 "      LFS_WORK_MANHOLE_REHABILITATION AS LWMR ON LW.WorkID = LWMR.WorkID LEFT OUTER JOIN " +
                 "      LFS_WORK_MANHOLE_REHABILITATION_BATCH AS LWMRB ON LWMR.BatchID = LWMRB.BatchID INNER JOIN  " +    
		         "      AM_ASSET_SEWER_MH_PROJECT AASMHP ON AASMH.AssetID = AASMHP.AssetID  " +

                  " WHERE {0} ORDER BY {1}", where, orderBy);
            }

            return commandText;
        }



        private string GetWhere()
        {
            // process view
            WorkViewTDS dataset = new WorkViewTDS();
            dataset.WorkViewConditionNew.Merge(workViewConditionNew, true);

            WorkViewConditionNew modelWorkViewConditionNew = new WorkViewConditionNew(dataset);

            string whereClause = "";
            whereClause = modelWorkViewConditionNew.ParserLogic(tbxLogic.Text, hdfWorkType.Value, int.Parse(hdfCompanyId.Value));

            return whereClause;
        }



        private string GetOrder()
        {
            // process view
            WorkViewTDS dataset = new WorkViewTDS();
            dataset.WorkViewSortTemp.Merge(workViewSortTemp, true);
            
            WorkViewSortTemp modelWorkSortTemp = new WorkViewSortTemp(dataset);
                       
            string orderClause = "";
            orderClause = modelWorkSortTemp.GetSortForSql();

            if (orderClause == "")
            {
                orderClause = "AASS.AssetID";
            }

            return orderClause;
        }


        
    }
}