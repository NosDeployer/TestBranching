using System;
using System.Collections;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.BL.FleetManagement.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Common;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.Tools;
using LiquiForce.LFSLive.DA.FleetManagement.Categories;
using LiquiForce.LFSLive.BL.FleetManagement.Categories;

namespace LiquiForce.LFSLive.WebUI.FleetManagement.Common
{
    /// <summary>
    /// view_add
    /// </summar
    public partial class view_add : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected FmViewTDS fmViewTDS;
        protected FmViewTDS.LFS_FM_TYPE_VIEW_DISPLAYDataTable fmTypeViewDisplay;
        protected FmViewTDS.LFS_FM_TYPE_VIEW_SORTDataTable fmTypeViewSort;
        protected FmViewTDS.FmViewDisplayTempDataTable fmViewDisplayTemp;
        protected FmViewTDS.FmViewConditionNewDataTable fmViewConditionNew;
        protected FmViewTDS.FmViewSortTempDataTable fmViewSortTemp;
        protected CategoriesTDS categoriesTDS;
        protected int level = -1;






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
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["fm_type"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in view_add.aspx");
                }

                // Security check
                if (!(Convert.ToBoolean(Session["sgLFS_VIEWS_ADD"])))
                {
                    if ((string)Request.QueryString["fm_type"] == "Services")
                    {
                        if (!(Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_SERVICES_VIEW"])))
                        {
                            Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                        }
                    }

                    if ((string)Request.QueryString["fm_type"] == "Units")
                    {
                        if (!(Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_UNITS_VIEW"])))
                        {
                            Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                        }
                    }
                }
               
                // Tag page
                hdfFmType.Value = (string)Request.QueryString["fm_type"];
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfUpdate.Value = "no";
                             
                ViewState["columnsToDisplayPageIndex"] = 0;
                ViewState["sortPageIndex"] = 0;

                Session.Remove("fmTypeViewDisplay");
                Session.Remove("fmTypeViewDisplayDummy");
                Session.Remove("fmTypeViewSort");
                Session.Remove("fmTypeViewSortDummy");
                Session.Remove("fmViewDisplayTemp");
                Session.Remove("fmViewSortTemp");
                Session.Remove("fmViewConditionNew");
                Session.Remove("fmViewConditionNewDummy");
                Session.Remove("categoriesTDSForAddView");

                FmViewGateway fmViewGateway = new FmViewGateway();
                hdfViewId.Value = (fmViewGateway.GetLastViewId() + 1).ToString().Trim();

                // Prepare initial data
                // ... For view type
                FmViewTypeList fmViewTypeList = new FmViewTypeList(new DataSet());
                fmViewTypeList.LoadAndAddItem("(Select a type)", Int32.Parse(hdfCompanyId.Value));
                ddlType.DataSource = fmViewTypeList.Table;
                ddlType.DataValueField = "Type";
                ddlType.DataTextField = "Type";
                ddlType.DataBind();
                ddlType.SelectedIndex = 0;

                // ... Global Views check
                if (!Convert.ToBoolean(Session["sgLFS_GLOBALVIEWS_ADD"]))
                {
                    ddlType.Items.Remove("Global");
                }

                // If coming from 
                // ... services_navigator.aspx, services_navigator2.aspx, units_navigator.aspx or units_navigator2.aspx
                if ((Request.QueryString["source_page"] == "services_navigator.aspx") || (Request.QueryString["source_page"] == "services_navigator2.aspx") || (Request.QueryString["source_page"] == "units_navigator.aspx") || (Request.QueryString["source_page"] == "unit_navigator2.aspx"))
                {
                    // ... For Grids
                    fmViewTDS = new FmViewTDS();

                    fmTypeViewDisplay = new FmViewTDS.LFS_FM_TYPE_VIEW_DISPLAYDataTable();
                    fmTypeViewSort = new FmViewTDS.LFS_FM_TYPE_VIEW_SORTDataTable();
                    fmViewDisplayTemp = new FmViewTDS.FmViewDisplayTempDataTable();
                    fmViewSortTemp = new FmViewTDS.FmViewSortTempDataTable();
                    fmViewConditionNew = new FmViewTDS.FmViewConditionNewDataTable();

                    // ... for Categories
                    categoriesTDS = new CategoriesTDS();

                    // ... Store datasets
                    Session["fmViewTDS"] = fmViewTDS;

                    Session["fmTypeViewDisplay"] = fmTypeViewDisplay;
                    Session["fmTypeViewSort"] = fmTypeViewSort;
                    Session["fmViewDisplayTemp"] = fmViewDisplayTemp;
                    Session["fmViewSortTemp"] = fmViewSortTemp;
                    Session["fmViewConditionNew"] = fmViewConditionNew;

                    Session["categoriesTDSForAddView"] = categoriesTDS;
                }

                // StepSection1In
                wzViews.ActiveStepIndex = 0;
                StepBeginIn();
            }
            else
            {
                // Restore datasets
                fmViewTDS = (FmViewTDS)Session["fmViewTDS"];

                fmTypeViewDisplay = (FmViewTDS.LFS_FM_TYPE_VIEW_DISPLAYDataTable)Session["fmTypeViewDisplay"];
                fmTypeViewSort = (FmViewTDS.LFS_FM_TYPE_VIEW_SORTDataTable)Session["fmTypeViewSort"];
                fmViewDisplayTemp = (FmViewTDS.FmViewDisplayTempDataTable)Session["fmViewDisplayTemp"];
                fmViewSortTemp = (FmViewTDS.FmViewSortTempDataTable)Session["fmViewSortTemp"];
                fmViewConditionNew = (FmViewTDS.FmViewConditionNewDataTable)Session["fmViewConditionNew"];

                categoriesTDS = (CategoriesTDS)Session["categoriesTDSForAddView"];
            }

            // Control for postback
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
                        throw new Exception("The option for " + wzViews.ActiveStep.Name + " step in view_add.Wizard_ActiveStepChanged function does not exist");
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
                    throw new Exception("The option for " + wzViews.ActiveStep.Name + " step in view_add.Wizard_NextButtonClick function does not exist");
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
                    throw new Exception("The option for " + wzViews.ActiveStep.Name + " step in view_add.Wizard_PreviousButtonClick function does not exist");
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

            // Security check
            if (!(Convert.ToBoolean(Session["sgLFS_VIEWS_ADD"])) && ((string)Request.QueryString["fm_type"] == "Services"))
            {
                if ((Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_SERVICES_VIEW"])) && ((string)Request.QueryString["fm_type"] == "Services"))
                {
                    lblType.Visible = false;
                    ddlType.Visible = false;
                    ddlType.SelectedIndex = 1;
                }
            }

            if (!(Convert.ToBoolean(Session["sgLFS_VIEWS_ADD"])) && ((string)Request.QueryString["fm_type"] == "Units"))
            {
                if ((Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_UNITS_VIEW"])) && ((string)Request.QueryString["fm_type"] == "Units"))
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
                FmViewTDS dataSet = new FmViewTDS();
                dataSet.LFS_FM_TYPE_VIEW_DISPLAY.Merge(fmTypeViewDisplay, true);
                FmTypeViewDisplay model = new FmTypeViewDisplay(dataSet);

                if (dataSet.LFS_FM_TYPE_VIEW_DISPLAY.Rows.Count <= 0)
                {
                    model.LoadByFmType(hdfFmType.Value, int.Parse(hdfCompanyId.Value));
                }

                // Store tables
                fmTypeViewDisplay = (FmViewTDS.LFS_FM_TYPE_VIEW_DISPLAYDataTable)model.Table;
                Session["fmTypeViewDisplay"] = fmTypeViewDisplay;

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
                StepColumnsToDisplayProcessGrid();
                fmViewDisplayTemp.Rows.Clear();

                // Create dataset
                FmViewTDS dataSet = new FmViewTDS();
                dataSet.LFS_FM_TYPE_VIEW_DISPLAY.Merge(fmTypeViewDisplay, true);
                dataSet.FmViewDisplayTemp.Merge(fmViewDisplayTemp, true);

                // Process new sections
                FmViewDisplayTemp model = new FmViewDisplayTemp(dataSet);
                model.Process(int.Parse(hdfViewId.Value), hdfFmType.Value, int.Parse(hdfCompanyId.Value));

                // Get changes
                fmViewDisplayTemp.Rows.Clear();
                fmViewDisplayTemp.Merge(model.Table);

                // Store tables
                Session.Remove("fmTypeViewDisplayDummy");
                Session["fmTypeViewDisplay"] = fmTypeViewDisplay;
                Session["fmViewDisplayTemp"] = fmViewDisplayTemp;

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

            return true;
        }



        private void StepColumnsToDisplayProcessGrid()
        {
            FmViewTDS dataSet = new FmViewTDS();
            dataSet.LFS_FM_TYPE_VIEW_DISPLAY.Merge(fmTypeViewDisplay, true);
            FmTypeViewDisplay model = new FmTypeViewDisplay(dataSet);

            // Update rows
            if (Session["fmTypeViewDisplayDummy"] == null)
            {
                foreach (GridViewRow row in grdColumnsToDisplay.Rows)
                {
                    int displayId = int.Parse(grdColumnsToDisplay.DataKeys[row.RowIndex].Values["DisplayID"].ToString());
                    bool selected = ((CheckBox)row.FindControl("cbxSelected")).Checked;

                    model.Update(hdfFmType.Value, int.Parse(hdfCompanyId.Value), displayId, selected);
                }

                model.Table.AcceptChanges();

                fmTypeViewDisplay = (FmViewTDS.LFS_FM_TYPE_VIEW_DISPLAYDataTable)model.Table;
                Session["fmTypeViewDisplay"] = fmTypeViewDisplay;
            }
        }



        public FmViewTDS.LFS_FM_TYPE_VIEW_DISPLAYDataTable GetColumnsToDisplay()
        {
            fmTypeViewDisplay = (FmViewTDS.LFS_FM_TYPE_VIEW_DISPLAYDataTable)Session["fmTypeViewDisplayDummy"];
            if (fmTypeViewDisplay == null)
            {
                fmTypeViewDisplay = (FmViewTDS.LFS_FM_TYPE_VIEW_DISPLAYDataTable)Session["fmTypeViewDisplay"];
            }

            return fmTypeViewDisplay;
        }



        protected void ColumnsToDisplayEmptyFix(GridView grdView)
        {
            if (grdView.Rows.Count == 0)
            {
                FmViewTDS.LFS_FM_TYPE_VIEW_DISPLAYDataTable dt = new FmViewTDS.LFS_FM_TYPE_VIEW_DISPLAYDataTable();
                dt.AddLFS_FM_TYPE_VIEW_DISPLAYRow("", 0, 0, "", false, "", "", false);
                Session["fmTypeViewDisplayDummy"] = dt;

                grdView.DataBind();
            }

            // Normally executes at all postbacks
            if (grdView.Rows.Count == 1)
            {
                FmViewTDS.LFS_FM_TYPE_VIEW_DISPLAYDataTable dt = (FmViewTDS.LFS_FM_TYPE_VIEW_DISPLAYDataTable)Session["fmTypeViewDisplayDummy"];
                if (dt != null)
                {
                    // Hide row
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
        
        // /////////////////////////////////////////////////////////////////////////////////////////////////////
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

            FmViewTDS dataSet = new FmViewTDS();
            dataSet.FmViewConditionNew.Merge(fmViewConditionNew, true);
            FmViewConditionNew model = new FmViewConditionNew(dataSet);

            model.Delete(id);
            Session["fmViewConditionNew"] = dataSet.FmViewConditionNew;
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

                FmTypeViewConditionGateway fmTypeViewConditionGateway = new FmTypeViewConditionGateway();
                fmTypeViewConditionGateway.LoadByFmTypeConditionId(hdfFmType.Value, int.Parse(hdfCompanyId.Value), conditionId);
                string type = fmTypeViewConditionGateway.GetType(hdfFmType.Value, int.Parse(hdfCompanyId.Value), conditionId);
                string value = "";

                if ((type == "String") || (type == "Date") || (type == "Int") || (type == "Decimal") )
                {
                    value = ((TextBox)grdConditions.Rows[e.RowIndex].Cells[5].FindControl("tbxValue")).Text;
                }

                if ((type == "FixedItems") || (type == "DynamicItems"))
                {
                    value = ((DropDownList)grdConditions.Rows[e.RowIndex].Cells[5].FindControl("ddlValue")).SelectedItem.Text.Replace("-", "");
                    value = value.Trim();
                }

                if (type == "Boolean")
                {
                    if (((RadioButton)grdConditions.Rows[e.RowIndex].Cells[5].FindControl("rbtnYes")).Checked)
                        value = "Yes";
                    if (((RadioButton)grdConditions.Rows[e.RowIndex].Cells[5].FindControl("rbtnNo")).Checked)
                        value = "No";
                }
                
                FmViewTDS dataSet = new FmViewTDS();
                dataSet.FmViewConditionNew.Merge(fmViewConditionNew, true);
                FmViewConditionNew model = new FmViewConditionNew(dataSet);

                model.Update(id, conditionId, name, operator_, sign, conditionNumber, value, false, false);
                Session["fmViewConditionNew"] = dataSet.FmViewConditionNew;
                fmViewConditionNew = dataSet.FmViewConditionNew;  
            }
            else
            {
                e.Cancel = true;
            }
        }






        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP3 - CONDITIONS -  AUXILIAR EVENTS
        //

        private void GetNodeForCategory(int parentId, DropDownList ddlValue)
        {
            System.Text.StringBuilder levelString = new System.Text.StringBuilder();

            level++;

            for (int j = 0; j < level; j++)
            {
                levelString.Append("&nbsp;&nbsp;&nbsp;&nbsp;");
            }
            if (level > 0)
            {
                levelString.Append("-");
            }

            Int32 thisId;
            String thisName;

            DataRow[] children = categoriesTDS.Tables["LFS_FM_CATEGORY"].Select("ParentID='" + parentId + "'");

            // No child nodes, exit function
            if (children.Length > 0)
            {
                foreach (DataRow child in children)
                {
                    // Step 1
                    thisId = Convert.ToInt32(child.ItemArray[0]);

                    // Step 2
                    thisName = Convert.ToString(child.ItemArray[2]);

                    // Step 3
                    ListItem listItem = new ListItem(Server.HtmlDecode(levelString.ToString() + thisName), thisId.ToString());
                    ddlValue.Items.Add(listItem);

                    // Step 4
                    GetNodeForCategory(thisId, ddlValue);
                }
            }

            level--;
        }



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
                                        
                    FmViewTDS dataSet = new FmViewTDS();
                    dataSet.FmViewConditionNew.Merge(fmViewConditionNew, true);
                    FmViewConditionNew model = new FmViewConditionNew(dataSet);
                    int conditionNumber = model.GetNewConditionNumber();
                    ddlConditionNumber.SelectedValue = conditionNumber.ToString();

                    FmTypeViewConditionGateway fmTypeViewConditionGateway = new FmTypeViewConditionGateway();
                    fmTypeViewConditionGateway.LoadByFmTypeConditionId(hdfFmType.Value, int.Parse(hdfCompanyId.Value), conditionId);
                    string type = fmTypeViewConditionGateway.GetType(hdfFmType.Value, int.Parse(hdfCompanyId.Value), conditionId);

                    if (ddlOperator.SelectedItem == null)
                    {
                        FmTypeViewOperatorList fmTypeViewOperatorList = new FmTypeViewOperatorList(new DataSet());
                        fmTypeViewOperatorList.LoadAndAddItem(type, Int32.Parse(hdfCompanyId.Value));
                        ddlOperator.DataSource = fmTypeViewOperatorList.Table;
                        ddlOperator.DataValueField = "Sign";
                        ddlOperator.DataTextField = "Operator";
                        ddlOperator.DataBind();
                        ddlOperator.SelectedIndex = 0;
                    }

                    if ((type == "String") || (type == "Date") || (type == "Int") || (type == "Decimal"))
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
                FmViewTDS dataSet = new FmViewTDS();
                dataSet.FmViewConditionNew.Merge(fmViewConditionNew, true);
                FmViewConditionNewGateway gateway = new FmViewConditionNewGateway(dataSet);
                int id = int.Parse(((Label)e.Row.FindControl("lblId")).Text);

                int conditionId = gateway.GetConditionId(id);
                DropDownList ddlName = ((DropDownList)e.Row.FindControl("ddlName"));
                DropDownList ddlOperator = ((DropDownList)e.Row.FindControl("ddlOperator"));

                if (conditionId > 0)
                {
                    FmTypeViewConditionGateway fmTypeViewConditionGateway = new FmTypeViewConditionGateway();
                    fmTypeViewConditionGateway.LoadByFmTypeConditionId(hdfFmType.Value, int.Parse(hdfCompanyId.Value), conditionId);
                    string type = fmTypeViewConditionGateway.GetType(hdfFmType.Value, int.Parse(hdfCompanyId.Value), conditionId);

                    ddlName.DataBind();
                    ddlName.SelectedValue = conditionId.ToString();

                    FmTypeViewOperatorList fmTypeViewOperatorList = new FmTypeViewOperatorList(new DataSet());
                    fmTypeViewOperatorList.LoadAndAddItem(type, Int32.Parse(hdfCompanyId.Value));
                    ddlOperator.DataSource = fmTypeViewOperatorList.Table;
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
                            FmTypeViewConditionItemList fmTypeViewConditionItemList = new FmTypeViewConditionItemList(new DataSet());
                            fmTypeViewConditionItemList.LoadAndAddItemInView(hdfFmType.Value, Int32.Parse(hdfCompanyId.Value), conditionId);
                            ddlValue.DataSource = fmTypeViewConditionItemList.Table;
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
                            if (ddlName.SelectedItem.Text == "Category")
                            {
                                //Category for Units
                                Category category = new Category(categoriesTDS);
                                category.LoadAllUnitTypes(Int32.Parse(hdfCompanyId.Value));

                                Session["categoriesTDSForAddView"] = categoriesTDS;

                                if (category.Table.Rows.Count > 0)
                                {
                                    GetNodeForCategory(0, ddlValue);//Equipments
                                    level = -1;
                                    GetNodeForCategory(-1, ddlValue);//Vehicles

                                    ddlValue.DataBind();
                                    string categorySelected = gateway.GetValue_(id);

                                    foreach (ListItem li in ddlValue.Items)
                                    {
                                        if (li.Text.Contains(categorySelected))
                                        {
                                            li.Selected = true;
                                        }
                                    }
                                }
                                else
                                {
                                    ddlValue.Visible = false;
                                }
                            }
                            else
                            {
                                //State for Services
                                FmTypeViewStateList fmTypeViewStateList = new FmTypeViewStateList(new DataSet());
                                fmTypeViewStateList.LoadAndAddItem(Int32.Parse(hdfCompanyId.Value));

                                if (fmTypeViewStateList.Table.Rows.Count > 0)
                                {
                                    ddlValue.DataSource = fmTypeViewStateList.Table;
                                    ddlValue.DataValueField = "State";
                                    ddlValue.DataTextField = "State";
                                    ddlValue.DataBind();
                                    ddlValue.SelectedValue = gateway.GetValue_(id);
                                }
                                else
                                {
                                    ddlValue.Visible = false;
                                }
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

            FmTypeViewConditionGateway fmTypeViewConditionGateway = new FmTypeViewConditionGateway();
            fmTypeViewConditionGateway.LoadByFmTypeConditionId(hdfFmType.Value, int.Parse(hdfCompanyId.Value), conditionId);
            type = fmTypeViewConditionGateway.GetType(hdfFmType.Value, int.Parse(hdfCompanyId.Value), conditionId);

            //  Date fields validate
            if (type == "Date")
            {
                // For complete date and only year
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
                    cvConditions.Text = "Invalid data. (use an integer number, % or leave the field empty)";
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
                    cvConditions.ErrorMessage = "Invalid data. (use a decimal number, % or leave the field empty)";
                }
            }
        }



        protected void ddlNameNew_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label lblValidateValue = ((Label)grdConditions.FooterRow.FindControl("lblValidateValue"));
            lblValidateValue.Visible = false;

            ImageButton ibtnAdd = ((ImageButton)grdConditions.FooterRow.FindControl("ibtnAdd"));
            ibtnAdd.Visible = true;

            DropDownList ddlName = ((DropDownList)grdConditions.FooterRow.FindControl("ddlName"));
            DropDownList ddlOperator = ((DropDownList)grdConditions.FooterRow.FindControl("ddlOperator"));

            FmTypeViewConditionGateway fmTypeViewConditionGateway = new FmTypeViewConditionGateway();
            fmTypeViewConditionGateway.LoadByFmTypeConditionId(hdfFmType.Value, int.Parse(hdfCompanyId.Value), int.Parse(ddlName.SelectedValue));
            string type = fmTypeViewConditionGateway.GetType(hdfFmType.Value, int.Parse(hdfCompanyId.Value), int.Parse(ddlName.SelectedValue));

            FmTypeViewOperatorList fmTypeViewOperatorList = new FmTypeViewOperatorList(new DataSet());
            fmTypeViewOperatorList.LoadAndAddItem(type, Int32.Parse(hdfCompanyId.Value));
            ddlOperator.DataSource = fmTypeViewOperatorList.Table;
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
                    FmTypeViewConditionItemList fmTypeViewConditionItemList = new FmTypeViewConditionItemList(new DataSet());
                    fmTypeViewConditionItemList.LoadAndAddItemInView(hdfFmType.Value, Int32.Parse(hdfCompanyId.Value), int.Parse(ddlName.SelectedValue));
                    ddlValue.DataSource = fmTypeViewConditionItemList.Table;
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
                    if (ddlName.SelectedItem.Text == "Category")
                    {//Category for Units
                        Category category = new Category(categoriesTDS);
                        category.LoadAllUnitTypes(Int32.Parse(hdfCompanyId.Value));

                        Session["categoriesTDSForAddView"] = categoriesTDS;

                        if (category.Table.Rows.Count > 0)
                        {
                            GetNodeForCategory(0, ddlValue);//Equipments
                            level = -1;
                            GetNodeForCategory(-1, ddlValue);//Vehicles

                            ddlValue.DataBind();
                            ddlValue.SelectedIndex = 0;
                            ibtnAdd.Visible = true;
                            ddlValue.Visible = true;
                        }
                        else
                        {
                            ddlValue.Visible = false;
                            ibtnAdd.Visible = false;
                            lblValidateValue.Visible = true;
                        }
                    }
                    else
                    {//State for Services
                        FmTypeViewStateList fmTypeViewStateList = new FmTypeViewStateList(new DataSet());
                        fmTypeViewStateList.LoadAndAddItem(Int32.Parse(hdfCompanyId.Value));

                        if (fmTypeViewStateList.Table.Rows.Count > 0)
                        {
                            ddlValue.DataSource = fmTypeViewStateList.Table;
                            ddlValue.DataValueField = "State";
                            ddlValue.DataTextField = "State";
                            ddlValue.DataBind();
                            ddlValue.SelectedIndex = 0;
                            ibtnAdd.Visible = true;
                            ddlValue.Visible = true;
                        }
                        else
                        {
                            ddlValue.Visible = false;
                            ibtnAdd.Visible = false;
                            lblValidateValue.Visible = true;
                        }
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



        protected void ddlName_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label lblValidateValue = ((Label)grdConditions.Rows[grdConditions.EditIndex].FindControl("lblValidateValue"));
            lblValidateValue.Visible = false;

            ImageButton ibtnAdd = ((ImageButton)grdConditions.Rows[grdConditions.EditIndex].FindControl("ibtnAccept"));
            ibtnAdd.Visible = true;

            DropDownList ddlName = ((DropDownList)grdConditions.Rows[grdConditions.EditIndex].FindControl("ddlName"));
            DropDownList ddlOperator = ((DropDownList)grdConditions.Rows[grdConditions.EditIndex].FindControl("ddlOperator"));

            FmTypeViewConditionGateway fmTypeViewConditionGateway = new FmTypeViewConditionGateway();
            fmTypeViewConditionGateway.LoadByFmTypeConditionId(hdfFmType.Value, int.Parse(hdfCompanyId.Value), int.Parse(ddlName.SelectedValue));
            string type = fmTypeViewConditionGateway.GetType(hdfFmType.Value, int.Parse(hdfCompanyId.Value), int.Parse(ddlName.SelectedValue));
            int index = grdConditions.SelectedIndex;

            FmTypeViewOperatorList fmTypeViewOperatorList = new FmTypeViewOperatorList(new DataSet());
            fmTypeViewOperatorList.LoadAndAddItem(type, Int32.Parse(hdfCompanyId.Value));
            ddlOperator.DataSource = fmTypeViewOperatorList.Table;
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
                    FmTypeViewConditionItemList fmTypeViewConditionItemList = new FmTypeViewConditionItemList(new DataSet());
                    fmTypeViewConditionItemList.LoadAndAddItemInView(hdfFmType.Value, Int32.Parse(hdfCompanyId.Value), int.Parse(ddlName.SelectedValue));
                    ddlValue.DataSource = fmTypeViewConditionItemList.Table;
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
                    if (ddlName.SelectedItem.Text == "Category")
                    {//Category for Units
                        Category category = new Category(categoriesTDS);
                        category.LoadAllUnitTypes(Int32.Parse(hdfCompanyId.Value));

                        Session["categoriesTDSForAddView"] = categoriesTDS;

                        if (category.Table.Rows.Count > 0)
                        {
                            GetNodeForCategory(0, ddlValue);//Equipments
                            level = -1;
                            GetNodeForCategory(-1, ddlValue);//Vehicles

                            ddlValue.DataBind();
                            ddlValue.SelectedIndex = 0;

                            ibtnAdd.Visible = true;
                        }
                        else
                        {
                            ddlValue.Visible = false;
                            ibtnAdd.Visible = false;

                            lblValidateValue.Visible = true;
                        }
                    }
                    else
                    {
                        //State for Services
                        FmTypeViewStateList fmTypeViewStateList = new FmTypeViewStateList(new DataSet());
                        fmTypeViewStateList.LoadAndAddItem(Int32.Parse(hdfCompanyId.Value));

                        if (fmTypeViewStateList.Table.Rows.Count > 0)
                        {
                            ddlValue.DataSource = fmTypeViewStateList.Table;
                            ddlValue.DataValueField = "State";
                            ddlValue.DataTextField = "State";
                            ddlValue.DataBind();
                            ddlValue.SelectedIndex = 0;

                            ibtnAdd.Visible = true;
                        }
                        else
                        {
                            ddlValue.Visible = false;
                            ibtnAdd.Visible = false;

                            lblValidateValue.Visible = true;
                        }
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
        public FmViewTDS.FmViewConditionNewDataTable GetConditionsNew()
        {
            fmViewConditionNew = (FmViewTDS.FmViewConditionNewDataTable)Session["fmViewConditionNewDummy"];
            if (fmViewConditionNew == null)
            {
                fmViewConditionNew = (FmViewTDS.FmViewConditionNewDataTable)Session["fmViewConditionNew"];
            }

            return fmViewConditionNew;
        }



        public void DummyConditionsNew(int ID)
        {
        }



        private void StepConditionsIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Please provide the conditions";

            // Tag page
            hdfStep.Value = "StepConditions";

            // Data Bind
            grdConditions.DataBind();
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

                // create dataset                
                FmViewTDS dataSet = new FmViewTDS();
                dataSet.FmViewConditionNew.Merge(fmViewConditionNew, true);

                // Process new conditions
                FmViewConditionNew model = new FmViewConditionNew(dataSet);

                tbxLogic.Text = model.GetConditionsByDefault();

                // Get changes
                fmViewConditionNew.Rows.Clear();
                fmViewConditionNew.Merge(model.Table);

                // Store tables
                Session.Remove("fmViewConditionNewDummy");
                Session["fmViewConditionNew"] = fmViewConditionNew;
                hdfStep.Value = "StepConditions";

                return true;
            }
            else
            {
                return false;
            }
        }



        private bool StepConditionsPrevious()
        {
            hdfStep.Value = "StepConditions";
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

                    FmTypeViewConditionGateway fmTypeViewConditionGateway = new FmTypeViewConditionGateway();
                    fmTypeViewConditionGateway.LoadByFmTypeConditionId(hdfFmType.Value, int.Parse(hdfCompanyId.Value), conditionId);
                    string type = fmTypeViewConditionGateway.GetType(hdfFmType.Value, int.Parse(hdfCompanyId.Value), conditionId);
                    string value = "";

                    if ((type == "String") || (type == "Date") || (type == "Int") || (type == "Decimal"))
                    {
                        value = ((TextBox)grdConditions.FooterRow.FindControl("tbxValue")).Text;
                    }

                    if ((type == "FixedItems") || (type == "DynamicItems"))
                    {
                        value = ((DropDownList)grdConditions.FooterRow.FindControl("ddlValue")).SelectedItem.Text.Replace("-", "");
                        value = value.Trim();
                    }

                    if (type == "Boolean")
                    {
                        if (((RadioButton)grdConditions.FooterRow.FindControl("rbtnYes")).Checked)
                            value = "Yes";
                        if (((RadioButton)grdConditions.FooterRow.FindControl("rbtnNo")).Checked)
                            value = "No";
                    }

                    FmViewTDS dataSet = new FmViewTDS();
                    dataSet.FmViewConditionNew.Merge(fmViewConditionNew, true);
                    FmViewConditionNew model = new FmViewConditionNew(dataSet);

                    model.Insert(conditionId, name, operator_, sign, conditionNumber, value, false, false);

                    Session.Remove("fmViewConditionNewDummy");
                    fmViewConditionNew = dataSet.FmViewConditionNew;
                    Session["fmViewConditionNew"] = dataSet.FmViewConditionNew;                    

                    grdConditions.DataBind();
                    grdConditions.PageIndex = grdConditions.PageCount - 1;
                }
            }
        }        
        


        private bool ValidateFooterAdd()
        {
            int conditionId = int.Parse(((DropDownList)grdConditions.FooterRow.FindControl("ddlName")).SelectedValue);
            FmTypeViewConditionGateway fmTypeViewConditionGateway = new FmTypeViewConditionGateway();
            fmTypeViewConditionGateway.LoadByFmTypeConditionId(hdfFmType.Value, int.Parse(hdfCompanyId.Value), conditionId);
            string type = fmTypeViewConditionGateway.GetType(hdfFmType.Value, int.Parse(hdfCompanyId.Value), conditionId);
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
            FmTypeViewConditionGateway fmTypeViewConditionGateway = new FmTypeViewConditionGateway();
            fmTypeViewConditionGateway.LoadByFmTypeConditionId(hdfFmType.Value, int.Parse(hdfCompanyId.Value), conditionId);
            string type = fmTypeViewConditionGateway.GetType(hdfFmType.Value, int.Parse(hdfCompanyId.Value), conditionId);
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



        protected void AddConditionsNewEmptyFix(GridView grdView)
        {
            if (grdView.Rows.Count == 0)
            {
                FmViewTDS.FmViewConditionNewDataTable dt = new FmViewTDS.FmViewConditionNewDataTable();
                dt.AddFmViewConditionNewRow(-1, -1, "", -1, "", "", -1, "", false, false);
                Session["fmViewConditionNewDummy"] = dt;

                grdView.DataBind();
            }

            // Normally executes at all postbacks
            if (grdView.Rows.Count == 1)
            {
                FmViewTDS.FmViewConditionNewDataTable dt = (FmViewTDS.FmViewConditionNewDataTable)Session["fmViewConditionNewDummy"];
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

        // ////////////////////////////////////////////////////////////////////////
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

            // Create dataset
            FmViewTDS dataSet = new FmViewTDS();
            dataSet.FmViewConditionNew.Merge(fmViewConditionNew, true);

            // Process new conditions
            FmViewConditionNew model = new FmViewConditionNew(dataSet);
            conditions = model.GetConditions();

            // Get changes
            fmViewConditionNew.Rows.Clear();
            fmViewConditionNew.Merge(model.Table);

            // Store tables
            Session["fmViewConditionNew"] = fmViewConditionNew;
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

            // Tag Page
            hdfStep.Value = "Step Logic";
            grdLogic.DataBind();
        }



        private bool StepLogicNext()
        {
            Page.Validate("Logic");
            if (Page.IsValid)
            {
                // Load
                FmViewTDS dataSet = new FmViewTDS();
                dataSet.LFS_FM_TYPE_VIEW_SORT.Merge(fmTypeViewSort, true);
                
                FmTypeViewSort model = new FmTypeViewSort(dataSet);

                if (dataSet.LFS_FM_TYPE_VIEW_SORT.Rows.Count <= 0)
                {
                    model.LoadByFmTypeInView(hdfFmType.Value, int.Parse(hdfCompanyId.Value), true);
                }

                // Store tables
                fmTypeViewSort = (FmViewTDS.LFS_FM_TYPE_VIEW_SORTDataTable)model.Table;
                Session["fmTypeViewSort"] = fmTypeViewSort;
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

            // Tag Page
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
                fmViewSortTemp.Rows.Clear();

                // Create dataset
                FmViewTDS dataSet = new FmViewTDS();
                dataSet.LFS_FM_TYPE_VIEW_SORT.Merge(fmTypeViewSort, true);
                dataSet.FmViewSortTemp.Merge(fmViewSortTemp, true);

                // Process sort by
                FmViewSortTemp model = new FmViewSortTemp(dataSet);
                model.Process(int.Parse(hdfViewId.Value), hdfFmType.Value, int.Parse(hdfCompanyId.Value));

                // Get changes
                fmViewSortTemp.Rows.Clear();
                fmViewSortTemp.Merge(model.Table);

                // Store tables
                Session.Remove("fmTypeViewSortDummy");
                Session["fmTypeViewSort"] = fmTypeViewSort;
                Session["fmViewSortTemp"] = fmViewSortTemp;

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
            FmViewTDS dataSet = new FmViewTDS();
            dataSet.LFS_FM_TYPE_VIEW_SORT.Merge(fmTypeViewSort, true);
            FmTypeViewSort model = new FmTypeViewSort(dataSet);

            // Update rows
            if (Session["fmTypeViewSortDummy"] == null)
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

                    model.Update(hdfFmType.Value, int.Parse(hdfCompanyId.Value), sortId, order, selected);
                }

                model.Table.AcceptChanges();

                fmTypeViewSort = (FmViewTDS.LFS_FM_TYPE_VIEW_SORTDataTable)model.Table;
                Session["fmTypeViewSort"] = fmTypeViewSort;
            }
        }



        public FmViewTDS.LFS_FM_TYPE_VIEW_SORTDataTable GetSort()
        {
            fmTypeViewSort = (FmViewTDS.LFS_FM_TYPE_VIEW_SORTDataTable)Session["fmTypeViewSortDummy"];
            if (fmTypeViewSort == null)
            {
                fmTypeViewSort = (FmViewTDS.LFS_FM_TYPE_VIEW_SORTDataTable)Session["fmTypeViewSort"];
            }

            return fmTypeViewSort;
        }



        protected void SortEmptyFix(GridView grdSort)
        {
            if (grdSort.Rows.Count == 0)
            {
                FmViewTDS.LFS_FM_TYPE_VIEW_SORTDataTable dt = new FmViewTDS.LFS_FM_TYPE_VIEW_SORTDataTable();
                dt.AddLFS_FM_TYPE_VIEW_SORTRow("", 0, 0, "", false, true, "", "", false, 0);
                Session["fmTypeViewSortDummy"] = dt;

                grdSort.DataBind();
            }

            // Normally executes at all postbacks
            if (grdSort.Rows.Count == 1)
            {
                FmViewTDS.LFS_FM_TYPE_VIEW_SORTDataTable dt = (FmViewTDS.LFS_FM_TYPE_VIEW_SORTDataTable)Session["fmTypeViewSortDummy"];
                if (dt != null)
                {
                    // Hide row
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
            FmView fmView = new FmView(fmViewTDS);

            // Process view
            FmViewTDS dataset = new FmViewTDS();
            dataset.FmViewDisplayTemp.Merge(fmViewDisplayTemp, true);
            dataset.FmViewConditionNew.Merge(fmViewConditionNew, true);
            dataset.FmViewSortTemp.Merge(fmViewSortTemp, true);

            FmViewDisplayTemp modelFmViewDisplayTemp = new FmViewDisplayTemp(dataset);
            FmViewConditionNew modelFmViewConditionNew = new FmViewConditionNew(dataset);
            FmViewSortTemp modelFmViewSortTemp = new FmViewSortTemp(dataset);

            string summary = "";
            summary = summary + "Name: " + tbxName.Text + "\n\n";
            summary = summary + "Columns To Display; " + modelFmViewDisplayTemp.GetColumnsToDisplay() + "\n\n";
            summary = summary + "Conditions: " + modelFmViewConditionNew.GetConditionsForSummary(hdfFmType.Value, int.Parse(hdfCompanyId.Value)) + "\n\n";
            summary = summary + "Logical Expression: " + tbxLogic.Text + "\n\n";
            summary = summary + "Order by: " + modelFmViewSortTemp.GetSortForSummary() + "\n\n";

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
            title.Text = "Add View";
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
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./view_add.js");
        }



        private void Save()
        {
            // Process view
            FmViewTDS dataset = new FmViewTDS();
            dataset.FmViewDisplayTemp.Merge(fmViewDisplayTemp, true);
            dataset.FmViewConditionNew.Merge(fmViewConditionNew, true);
            dataset.FmViewSortTemp.Merge(fmViewSortTemp, true);

            FmViewDisplayTemp modelFmViewDisplayTemp = new FmViewDisplayTemp(dataset);
            FmViewConditionNew modelFmViewConditionNew = new FmViewConditionNew(dataset);
            FmViewSortTemp modelFmViewSortTemp = new FmViewSortTemp(dataset);

            // Get parameters
            int viewId = int.Parse(hdfViewId.Value);
            int companyId = int.Parse(hdfCompanyId.Value);
            int loginId = Convert.ToInt32(Session["loginID"]);
            string name = tbxName.Text;
            string type = ddlType.SelectedValue;
            string logic = tbxLogic.Text;
            string sqlCommand = GetSqlCommand();
            string fmType = hdfFmType.Value;

            if (!(Convert.ToBoolean(Session["sgLFS_VIEWS_ADD"])) && ((string)Request.QueryString["fm_type"] == "Services"))
            {
                if ((Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_SERVICES_VIEW"])) && ((string)Request.QueryString["fm_type"] == "Services"))
                {
                    type = "Personal";
                }
            }

            if (!(Convert.ToBoolean(Session["sgLFS_VIEWS_ADD"])) && ((string)Request.QueryString["fm_type"] == "Units"))
            {
                if ((Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_UNITS_VIEW"])) && ((string)Request.QueryString["fm_type"] == "Units"))
                {
                    type = "Personal";
                }
            }

            // Save to database
            DB.Open();
            DB.BeginTransaction();

            try
            {
                FmView fmView = new FmView(null);
                fmView.InsertDirect(viewId, loginId, name, type, logic, sqlCommand, fmType, false, companyId);

                modelFmViewDisplayTemp.Save();
                modelFmViewConditionNew.Save(viewId, companyId, fmType);
                modelFmViewSortTemp.Save(viewId, fmType, companyId);

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
            string fmType = hdfFmType.Value;
            string commandText = "";

            if (fmType == "Services")
            {
                commandText = String.Format("SELECT     LFS.ServiceID, LFS.Number AS ServiceNumber, LFS.MTO, LFU.UnitCode, LFU.Description AS UnitDescription, LFS.Description AS ProblemDescription, " +
                      " LFR.Name AS ChecklistRule, LEOwner.LastName + ' '+ LEOwner.FirstName AS CreatedBy, LEAssignedTo.LastName + ' '+ LEAssignedTo.FirstName AS AssignedTo, LFS.StartWorkDateTime AS StartDate, " +
                      " LFS.CompleteWorkDateTime AS CompleteDate, '' AS Notes, CAST(0 AS bit) AS Selected, LFS.COMPANY_ID, CAST(0 AS bit) AS Deleted, LFS.AssignDeadlineDate AS DeadlineDate, LFS.State, " +
                      " LFS.DateTime_, LFU.VIN, LFU.State as UnitState, LFC.State as ChecklistState, LFSV.Mileage, LFS.AssignDateTime, LFS.AcceptDateTime, LFS.StartWorkOutOfServiceDate, LFS.StartWorkOutOfServiceTime, " +
                      " LFSV.StartWorkMileage, LFS.CompleteWorkBackToServiceDate, LFS.CompleteWorkBackToServiceTime, LFSV.CompleteWorkMileage, LFS.CompleteWorkDetailDescription, LFS.CompleteWorkDetailPreventable, "+
                      " LFS.CompleteWorkDetailTMLabourHours, LFCL.Name AS WorkingLocation " +
                      " FROM LFS_FM_RULE LFR INNER JOIN " +
                      " LFS_FM_CHECKLIST LFC ON LFR.RuleID = LFC.RuleID RIGHT OUTER JOIN " +
                      " LFS_FM_SERVICE LFS LEFT JOIN LFS_FM_SERVICE_VEHICLE LFSV ON LFSV.ServiceID = LFS.ServiceID INNER JOIN " +
                      " LFS_FM_UNIT LFU ON LFS.UnitID = LFU.UnitID INNER JOIN " +
                      " LFS_FM_COMPANYLEVEL LFCL ON LFU.CompanyLevelID = LFCL.CompanyLevelID INNER JOIN " +
                      " LFS_RESOURCES_EMPLOYEE LEOwner ON LFS.OwnerID = LEOwner.EmployeeID LEFT OUTER JOIN " +
                      " LFS_RESOURCES_EMPLOYEE LEAssignedTo ON LFS.AssignTeamMemberID = LEAssignedTo.EmployeeID ON LFC.UnitID = LFS.UnitID AND " +
                      " LFC.RuleID = LFS.RuleID " +
                      " WHERE {0} {1}", where, orderBy);
            }

            if (fmType == "Units")
            {
                commandText = String.Format("SELECT FMU.UnitID, FMU.UnitCode, FMU.Description, FMU.VIN, FMU.Manufacturer, FMU.Model, FMU.Year_ as Year, " +
                    "FMU.IsTowable, CAST(0 AS bit) AS Selected, FMU.COMPANY_ID, FMU.Deleted, FMU.Categories, FMU.OwnerType, FMU.Notes, FMC.Name as CompanyLevel, " +
                    "FMU.AcquisitionDate, "+
                    " (SELECT  top 1 FMUCH1.CostCad FROM LFS_FM_UNIT_COST_HISTORY FMUCH1 WHERE FMUCH1.UnitID = FMU.UnitID ORDER BY FMUCH1.Date Desc) AS CostCad, " +
                    " (SELECT  top 1 FMUCH2.CostUsd FROM LFS_FM_UNIT_COST_HISTORY FMUCH2 WHERE FMUCH2.UnitID = FMU.UnitID ORDER BY FMUCH2.Date Desc) AS CostUsd, " +
                    "(SELECT Name FROM LFS_COUNTRY C WHERE C.CountryID = FMUV.LicenseCountry) AS LicenseCountry, " +
                    "(SELECT Name FROM LFS_PROVINCE P WHERE P.ProvinceID = FMUV.LicenseState) AS LicenseState, FMUV.LicensePlateNumbver, FMUV.AportionedTagNumber, " +
                    "FMUV.ActualWeight, FMUV.RegisteredWeight, FMUV.TireSizeFront, FMUV.TireSizeBack, FMUV.NumberOfAxes, FMUV.FuelType, FMUV.BeginningOdometer, " +
                    "FMUV.IsReeferEquipped, FMUV.IsPTOEquipped, (SELECT Name FROM LFS_COUNTRY C WHERE C.CountryID = FMU.OwnerCountry) AS OwnerCountry, " +
                    "(SELECT Name FROM LFS_PROVINCE P WHERE P.ProvinceID = FMU.OwnerState) AS OwnerState, FMU.OwnerName, FMU.OwnerContact, FMU.QualifiedDate, " +
                    "FMU.NotQualifiedDate, FMU.NotQualifiedExplain, FMU.State, FMU.InsuranceClass, FMU.InsuranceClassRyderSpecified " +
                    " FROM  LFS_FM_UNIT FMU INNER JOIN " +
                    "       LFS_FM_COMPANYLEVEL FMC ON FMU.CompanyLevelID = FMC.CompanyLevelID LEFT JOIN " +
                    "       LFS_FM_UNIT_VEHICLE FMUV ON FMU.UnitID = FMUV.UnitID LEFT JOIN " +
                    "       LFS_COUNTRY LCL ON LCL.CountryID = FMUV.LicenseCountry LEFT JOIN " +
                    "       LFS_PROVINCE LPL ON LPL.ProvinceID = FMUV.LicenseState LEFT JOIN " +
                    "       LFS_COUNTRY LCO ON LCO.CountryID = FMU.OwnerCountry LEFT JOIN " +
                    "       LFS_PROVINCE LPO ON LPO.ProvinceID = FMU.OwnerState" +    
                      " WHERE {0} {1}", where, orderBy);
            }

            return commandText;
        }



        private string GetWhere()
        {
            // Process view
            FmViewTDS dataset = new FmViewTDS();
            dataset.FmViewConditionNew.Merge(fmViewConditionNew, true);

            FmViewConditionNew modelFmViewConditionNew = new FmViewConditionNew(dataset);

            string whereClause = "";
            whereClause = modelFmViewConditionNew.ParserLogic(tbxLogic.Text, hdfFmType.Value, int.Parse(hdfCompanyId.Value));

            return whereClause;
        }



        private string GetOrder()
        {
            // Process view
            FmViewTDS dataset = new FmViewTDS();
            dataset.FmViewSortTemp.Merge(fmViewSortTemp, true);

            FmViewSortTemp modelFmSortTemp = new FmViewSortTemp(dataset);

            string orderClause = "";
            orderClause = modelFmSortTemp.GetSortForSql();

            if (orderClause == "")
            {
                if (hdfFmType.Value == "Services")
                {
                    orderClause = "LFS.ServiceID";
                }

                if (hdfFmType.Value == "Units")
                {
                    orderClause = "FMU.UnitID";
                }
            }

            return  " ORDER BY " + orderClause;
        }



    }
}