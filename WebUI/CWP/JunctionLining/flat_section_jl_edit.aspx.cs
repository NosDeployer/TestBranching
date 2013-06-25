using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Resources.Companies;
using LiquiForce.LFSLive.DA.CWP.JunctionLining;
using LiquiForce.LFSLive.BL.CWP.JunctionLining;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.BL.CWP.Works;
using LiquiForce.LFSLive.Tools;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.CWP.JunctionLining
{
    /// <summary>
    /// flat_section_jl_edit
    /// </summary>
    public partial class flat_section_jl_edit : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected FlatSectionJlTDS flatSectionJlTDS;






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
                if (!(Convert.ToBoolean(Session["sgLFS_CWP_JUNCTIONLINING_VIEW"]) && Convert.ToBoolean(Session["sgLFS_CWP_JUNCTIONLINING_EDIT"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["client_id"] == null) || ((string)Request.QueryString["project_id"] == null) || ((string)Request.QueryString["work_type"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in flat_section_jl_edit.aspx");
                }

                // Tag Page
                TagPage();

                // Prepare initial data
                // ... for client
                int currentClientId = Int32.Parse(hdfCurrentClientId.Value.ToString());
                int companyId = Int32.Parse(hdfCompanyId.Value);

                CompaniesGateway companiesGateway = new CompaniesGateway();
                companiesGateway.LoadByCompaniesId(currentClientId, companyId);
                lblTitleClientName.Text = "Client: " + companiesGateway.GetName(currentClientId);

                // ... for project
                int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value.ToString());
                ProjectGateway projectGateway = new ProjectGateway();
                projectGateway.LoadByProjectId(currentProjectId);
                string name = projectGateway.GetName(currentProjectId);
                if (name.Length > 23) name = name.Substring(0, 16) + "...";
                lblTitleProjectName.Text = " > Project: " + name + " (" + projectGateway.GetProjectNumber(currentProjectId) + ") > Selected Laterals";

                // If coming from 
                // ... jl_navigator2.aspx
                if (Request.QueryString["source_page"] == "jl_navigator2.aspx")
                {
                    StoreNavigatorState();
                    ViewState["update"] = "no";
                }

                // ... flat_section_jl_summary.aspx
                if (Request.QueryString["source_page"] == "flat_section_jl_summary.aspx")
                {
                    StoreNavigatorState();
                    ViewState["update"] = Request.QueryString["update"];
                }

                // Restore datasets
                flatSectionJlTDS = (FlatSectionJlTDS)Session["flatSectionJlTDS"];

                DataView dataViewFlatSectionJl = new DataView(flatSectionJlTDS.FlatSectionJl);
                dataViewFlatSectionJl.RowFilter = "(Selected = 1) AND (Deleted = 0)";
                grdvJl.DataSource = dataViewFlatSectionJl;

                //DataBind
                odsCoPitLocation.DataBind();
                odsFlange.DataBind();                
                grdvJl.DataBind();

                if (Session["rowFocus"] != null)
                {
                    this.SetFocusGridView();
                }

                // FooterMenu
                tbFooterToolbar.Visible = true;
                if (grdvJl.Rows.Count == 1)
                {
                    tbFooterToolbar.Visible = false;
                }
            }
            else
            {
                // Restore datasets
                flatSectionJlTDS = (FlatSectionJlTDS)Session["flatSectionJlTDS"];

                DataView dataViewFlatSectionJl = new DataView(flatSectionJlTDS.FlatSectionJl);
                dataViewFlatSectionJl.RowFilter = "(Selected = 1) AND (Deleted = 0)";
                grdvJl.DataSource = dataViewFlatSectionJl;                

                //DataBind                
                grdvJl.DataBind();
                
                // FooterMenu
                tbFooterToolbar.Visible = true;
                if (grdvJl.Rows.Count == 1)
                {
                    tbFooterToolbar.Visible = false;
                }
            }
        }


        
        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set active toolbar
            mForm6 master = (mForm6)this.Master;
            master.ActiveToolbar = "eSewers";
        }



        

        
        // ////////////////////////////////////////////////////////////////////////
        // AUXILIAR EVENTS
        //

        public override void Validate()
        {
            // Validate page
            base.Validate();
        }



        protected void cvDistance_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Trim() != "")
            {
                // Initialize 
                CustomValidator cvDistance = (CustomValidator)source;
                args.IsValid = true;

                // control of format
                if (!Distance.IsValidDistance(args.Value))
                {
                    cvDistance.Text = "Invalid format. (please use X'Y\", or Xft Yin, or X.Y, or X.Ym, or X.Ymm)";
                    args.IsValid = false;
                }

                // control of distance > 0
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



        protected void cvDigRequiredPriorToLiningDate_ServerValidate(object source, ServerValidateEventArgs args)
        {            
            args.IsValid = true;           

            CustomValidator cvDigRequiredPriorToLiningDate = (CustomValidator)source;
            GridViewRow gridRow = (GridViewRow)cvDigRequiredPriorToLiningDate.NamingContainer;

            bool digRequiredPriorToLining = ((CheckBox)gridRow.FindControl("cbxDigRequiredPriorToLining")).Checked;
            DateTime? digRequiredPriorToLiningDate = null; if (((RadDatePicker)gridRow.FindControl("tkrdpDigRequiredPriorToLiningCompleted")).SelectedDate.HasValue) digRequiredPriorToLiningDate = ((RadDatePicker)gridRow.FindControl("tkrdpDigRequiredPriorToLiningCompleted")).SelectedDate.Value;

            if ((!digRequiredPriorToLining) && (digRequiredPriorToLiningDate.HasValue))
            {
                args.IsValid = false;
            }
        }



        protected void cvDigRequiredAfterLiningDate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            CustomValidator cvDigRequiredPriorToLiningDate = (CustomValidator)source;
            GridViewRow gridRow = (GridViewRow)cvDigRequiredPriorToLiningDate.NamingContainer;

            bool digRequiredAfterLining = ((CheckBox)gridRow.FindControl("cbxDigRequiredAfterLining")).Checked;
            DateTime? digRequiredAfterLiningDate = null; if (((RadDatePicker)gridRow.FindControl("tkrdpDigRequiredAfterLiningCompleted")).SelectedDate.HasValue) digRequiredAfterLiningDate = ((RadDatePicker)gridRow.FindControl("tkrdpDigRequiredAfterLiningCompleted")).SelectedDate.Value;

            if ((!digRequiredAfterLining) && (digRequiredAfterLiningDate.HasValue))
            {
                args.IsValid = false;
            }
        }



        protected void cvHoldClientIssueDate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            CustomValidator cvDigRequiredPriorToLiningDate = (CustomValidator)source;
            GridViewRow gridRow = (GridViewRow)cvDigRequiredPriorToLiningDate.NamingContainer;

            bool holdClientIssue = ((CheckBox)gridRow.FindControl("cbxHoldClientIssue")).Checked;
            DateTime? holdClientIssueDate = null; if (((RadDatePicker)gridRow.FindControl("tkrdpHoldClientIssueResolved")).SelectedDate.HasValue) holdClientIssueDate = ((RadDatePicker)gridRow.FindControl("tkrdpHoldClientIssueResolved")).SelectedDate.Value;

            if ((!holdClientIssue) && (holdClientIssueDate.HasValue))
            {
                args.IsValid = false;
            }
        }



        protected void cvHoldLFSIssueDate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            CustomValidator cvDigRequiredPriorToLiningDate = (CustomValidator)source;
            GridViewRow gridRow = (GridViewRow)cvDigRequiredPriorToLiningDate.NamingContainer;

            bool holdLFSIssue = ((CheckBox)gridRow.FindControl("cbxHoldLFSIssue")).Checked;
            DateTime? holdLFSIssueDate = null; if (((RadDatePicker)gridRow.FindControl("tkrdpHoldLFSIssueResolved")).SelectedDate.HasValue) holdLFSIssueDate = ((RadDatePicker)gridRow.FindControl("tkrdpHoldLFSIssueResolved")).SelectedDate.Value;

            if ((!holdLFSIssue) && (holdLFSIssueDate.HasValue))
            {
                args.IsValid = false;
            }
        }



        protected void cvRequiresRoboticPrep_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            CustomValidator cvDigRequiredPriorToLiningDate = (CustomValidator)source;
            GridViewRow gridRow = (GridViewRow)cvDigRequiredPriorToLiningDate.NamingContainer;

            bool requiresRoboticPrep = ((CheckBox)gridRow.FindControl("cbxRequiresRoboticPrep")).Checked;
            DateTime? requiresRoboticPrepDate = null; if (((RadDatePicker)gridRow.FindControl("tkrdpRequiresRoboticPrepCompleted")).SelectedDate.HasValue) requiresRoboticPrepDate = ((RadDatePicker)gridRow.FindControl("tkrdpRequiresRoboticPrepCompleted")).SelectedDate.Value;

            if ((!requiresRoboticPrep) && (requiresRoboticPrepDate.HasValue))
            {
                args.IsValid = false;
            }
        }



        protected void ddlFlange_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                mForm6 master = (mForm6)this.Master;
                ScriptManager scriptManager = (ScriptManager)master.FindControl("ScriptManagerMaster6");

                if (scriptManager.IsInAsyncPostBack)
                {
                    // cast DropDownList control which has initiated the call:
                    DropDownList ddlFlange = (DropDownList)sender;

                    foreach (GridViewRow row in grdvJl.Rows)
                    {
                        DropDownList ddlFlange2 = (DropDownList)row.FindControl("ddlFlange");

                        if (ddlFlange2.UniqueID.Contains(ddlFlange.UniqueID))
                        {
                            DropDownList ddlGasket = (DropDownList)row.FindControl("ddlGasket");

                            try
                            {
                                WorkJunctionLiningFlangeGasketList workJunctionLiningFlangeGasketList = new WorkJunctionLiningFlangeGasketList();
                                workJunctionLiningFlangeGasketList.LoadAndAddItem(ddlFlange.SelectedValue, "", Int32.Parse(hdfCompanyId.Value));
                                ddlGasket.DataSource = workJunctionLiningFlangeGasketList.Table;
                                ddlGasket.DataValueField = "Gasket";
                                ddlGasket.DataTextField = "Gasket";
                                ddlGasket.DataBind();
                            }
                            catch
                            {
                                ddlGasket.SelectedIndex = 0;
                            }
                        }
                    }

                    Save2();
                }
            }
            catch
            {
            }
        }



        protected void grdvJl_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Comments")
            {
                this.Save2();

                int index = Convert.ToInt32(e.CommandArgument);
                Session["rowFocus"] = index;
                GridViewRow gridRow = grdvJl.Rows[index];
                HiddenField hdfAssetID = (HiddenField)gridRow.FindControl("hdfAssetID");
                HiddenField hdfSection_ = (HiddenField)gridRow.FindControl("hdfSection_");
                string script = "<script language='javascript'>";
                string url = "./jl_comments.aspx?source_page=flat_section_jl_edit.aspx&row_asset_id=" + hdfAssetID.Value + "&section_=" + hdfSection_.Value + "&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&row_focus=" + index + "&work_type=" + hdfWorkType.Value;
                script = script + string.Format("window.open('{0}', '_blank', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=795, height=640')", url);
                script = script + "</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Comments", script, false);
            }

            if (e.CommandName == "History")
            {
                this.Save2();

                int index = Convert.ToInt32(e.CommandArgument);
                Session["rowFocus"] = index;
                GridViewRow gridRow = grdvJl.Rows[index];
                HiddenField hdfAssetID = (HiddenField)gridRow.FindControl("hdfAssetID");
                HiddenField hdfSection_ = (HiddenField)gridRow.FindControl("hdfSection_");
                string script = "<script language='javascript'>";
                string url = "./jl_history.aspx?source_page=flat_section_jl_edit.aspx&row_asset_id=" + hdfAssetID.Value + "&section_=" + hdfSection_.Value + "&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&row_focus=" + index + "&work_type=" + hdfWorkType.Value;
                script = script + string.Format("window.open('{0}', '_blank', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=795, height=640')", url);
                script = script + "</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "History", script, false);
            }
        }



        protected void grdvJl_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Normal items
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Normal) || (e.Row.RowState == (DataControlRowState.Normal | DataControlRowState.Alternate))))
            {
                DropDownList ddlFlange = (DropDownList)e.Row.FindControl("ddlFlange");
                DropDownList ddlGasket = (DropDownList)e.Row.FindControl("ddlGasket");

                if (ddlFlange.Items.Count <= 0)
                {
                    ddlFlange.SelectedIndex = 0;
                    ddlGasket.SelectedIndex = 0;
                }
                else
                {
                    if (ddlFlange.SelectedValue != "")
                    {
                        try
                        {
                            WorkJunctionLiningFlangeGasketList workJunctionLiningFlangeGasketList = new WorkJunctionLiningFlangeGasketList();
                            workJunctionLiningFlangeGasketList.LoadAndAddItem(ddlFlange.SelectedValue, "", Int32.Parse(hdfCompanyId.Value));
                            ddlGasket.DataSource = workJunctionLiningFlangeGasketList.Table;
                            ddlGasket.DataValueField = "Gasket";
                            ddlGasket.DataTextField = "Gasket";
                            ddlGasket.DataBind();
                        }
                        catch
                        {
                            ddlGasket.SelectedIndex = 0;
                        }
                    }
                    else
                    {
                        ddlFlange.SelectedIndex = 0;
                    }
                }
            }
        }



        protected void grdvJl_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // ... for comments
                Button btnComments = (Button)e.Row.FindControl("btnComments");
                btnComments.CommandArgument = e.Row.RowIndex.ToString();

                // ... for history
                Button btnHistory = (Button)e.Row.FindControl("btnHistory");
                btnHistory.CommandArgument = e.Row.RowIndex.ToString();
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATION EVENTS
        //

        protected void btnChange_Click(object sender, EventArgs e)
        {
            Response.Redirect("./../Common/select_project.aspx?source_page=flat_section_jl_edit.aspx&work_type=Junction Lining");
        }



        protected void tkrpbLeftMenu_ItemClick(object sender, RadPanelBarEventArgs e)
        {
            string url = "";

            switch (e.Item.Value)
            {
                case "mLiningPlan":
                    url = "./jl_lining_plan.aspx?source_page=lm&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&work_type=" + hdfWorkType.Value;
                    break;

                case "mSearchS":
                    url = "./jls_navigator.aspx?source_page=lm&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value;
                    break;

                case "mSearch":
                    url = "./jl_navigator.aspx?source_page=lm&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&work_type=" + hdfWorkType.Value;
                    break;
            }

            if (url != "") Response.Redirect(url);
        }



        protected void tkrmTop_ItemClick(object sender, RadMenuEventArgs e)
        {
            switch (e.Item.Value)
            {
                case "mSave":
                    this.Save();
                    break;

                case "mApply":
                    this.Apply();
                    break;

                case "mCancel":
                    flatSectionJlTDS.RejectChanges();
                    string url = "";
                    if (Request.QueryString["source_page"] == "jl_navigator2.aspx")
                    {
                        url = "./jl_navigator2.aspx?source_page=flat_section_jl_edit.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + GetNavigatorState() + "&work_type=" + hdfWorkType.Value + "&update=" + (string)ViewState["update"];
                    }

                    if (Request.QueryString["source_page"] == "flat_section_jl_summary.aspx")
                    {
                        url = "./flat_section_jl_summary.aspx?source_page=flat_section_jl_edit.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&work_type=" + hdfWorkType.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    }
                    Response.Redirect(url);
                    break;
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // METHODS
        //

        protected string GetCoPitLocationSelected(object name)
        {
            string coPitLocationSelect = " ";

            if (name != DBNull.Value)
            {
                coPitLocationSelect = name.ToString();
            }

            return coPitLocationSelect;
        }



        protected string GetPrepType(object name)
        {
            string prepType = "";

            if (name != DBNull.Value)
            {
                prepType = name.ToString();
            }

            return prepType;
        }



        protected string GetLinerType(object name)
        {
            string linerType = "";

            if (name != DBNull.Value)
            {
                linerType = name.ToString();
            }

            return linerType;
        }



        protected string GetConnectionType(object name)
        {
            string connectionType = "";
            if (name != DBNull.Value)
            {
                connectionType = name.ToString();
            }

            return connectionType;
        }



        protected string GetFlange(object name)
        {
            string flange = "";

            if (name != DBNull.Value)
            {
                flange = name.ToString();
            }

            return flange;
        }



        protected string GetGasket(object name)
        {
            string gasket = "";

            if (name != DBNull.Value && name != null)
            {
                gasket = name.ToString();
            }
            return gasket;
        }



        protected string GetDistance(object distance)
        {
            if (distance != DBNull.Value)
            {
                if (Validator.IsValidDouble(distance.ToString()))
                {
                    if (distance.ToString().Contains("-"))
                    {
                        string positiveValue = distance.ToString().Replace('-', ' ').Trim();
                        return "-" + string.Format("{0:0.0}", Convert.ToDouble(positiveValue));
                    }
                    else
                    {
                        return string.Format("{0:0.0}", Convert.ToDouble(distance));
                    }
                }
                else
                {
                    return distance.ToString();
                }
            }
            else
            {
                return "";
            }
        }



        private void RegisterClientScripts()
        {
            // Publishing body's OnKeyDown event 
            HtmlGenericControl bodyUnload = (HtmlGenericControl)Page.Master.FindControl("myBody");
            bodyUnload.Attributes.Add("OnKeyDown", "OnKeyDown(event);");

            // Register content variables
            string contentVariables = "";
            contentVariables += "var hdfDataChangedId = '" + hdfDataChanged.ClientID + "';";
            contentVariables += "var hdfDataChangedMessageId = '" + hdfDataChangedMessage.ClientID + "';";
            contentVariables += "var hdfBeforeUnloadOrigenId = '" + hdfBeforeUnloadOrigen.ClientID + "';";
            contentVariables += "var hdfCurrentClientIdId = '" + hdfCurrentClientId.ClientID + "';";
            contentVariables += "var hdfCurrentProjectIdId = '" + hdfCurrentProjectId.ClientID + "';";
            contentVariables += "var tkrmTopId = '" + tkrmTop.ClientID + "';";  

            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./flat_section_jl_edit.js");
        }



        private void TagPage()
        {
            hdfCompanyId.Value = Session["companyID"].ToString();
            hdfCurrentProjectId.Value = Request.QueryString["project_id"].ToString();
            hdfCurrentClientId.Value = Request.QueryString["client_id"].ToString();
            hdfWorkType.Value = Request.QueryString["work_type"].ToString();
            hdfDataChangedMessage.Value = "Changes made to this lateral will not be saved.";

            // Get ids & location
            int projectId = Int32.Parse(hdfCurrentProjectId.Value.Trim());
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
        }



        private void StoreNavigatorState()
        {
            ViewState["navigatorState"] = "&columns_to_display=" + Request.QueryString["columns_to_display"] + "&columns_to_display2=" + Request.QueryString["columns_to_display2"] + "&search_ddlCondition1=" + Request.QueryString["search_ddlCondition1"] + "&search_ddlCondition2=" + Request.QueryString["search_ddlCondition2"] + "&search_tbxCondition1=" + Request.QueryString["search_tbxCondition1"] + "&search_tbxCondition2=" + Request.QueryString["search_tbxCondition2"] + "&search_ddlOperator1=" + Request.QueryString["search_ddlOperator1"] + "&search_ddlOperator2=" + Request.QueryString["search_ddlOperator2"] + "&search_ddlView=" + Request.QueryString["search_ddlView"] + "&search_sort_by=" + Request.QueryString["search_sort_by"] + "&search_issues=" + Request.QueryString["search_issues"] + "&search_sub_area=" + Request.QueryString["search_sub_area"] + "&btn_origin=" + Request.QueryString["btn_origin"];
        }



        private string GetNavigatorState()
        {
            return (string)ViewState["navigatorState"];
        }



        private void Save()
        {
            Page.Validate();

            if (Page.IsValid)
            {
                FlatSectionJl flatSectionJl = new FlatSectionJl(flatSectionJlTDS);

                // Update flatSectionJlTDS
                foreach (GridViewRow row in grdvJl.Rows)
                {
                    // ... Get standard fields
                    int workId = int.Parse(((HiddenField)row.FindControl("hdfWorkID")).Value);
                    int assetId = int.Parse(((HiddenField)row.FindControl("hdfAssetID")).Value);
                    int section_ = int.Parse(((HiddenField)row.FindControl("hdfSection_")).Value);
                    int companyId = int.Parse(hdfCompanyId.Value);
                    string address = ((TextBox)row.FindControl("tbxAddress")).Text.Trim();                    
                    DateTime? pipeLocated = null; if (((RadDatePicker)row.FindControl("tkrdpPipeLocated")).SelectedDate.HasValue) pipeLocated = ((RadDatePicker)row.FindControl("tkrdpPipeLocated")).SelectedDate.Value;
                    DateTime? servicesLocated = null; if (((RadDatePicker)row.FindControl("tkrdpServicesLocated")).SelectedDate.HasValue) servicesLocated = ((RadDatePicker)row.FindControl("tkrdpServicesLocated")).SelectedDate.Value;
                    DateTime? coInstalled = null; if (((RadDatePicker)row.FindControl("tkrdpCoInstalled")).SelectedDate.HasValue) coInstalled = ((RadDatePicker)row.FindControl("tkrdpCoInstalled")).SelectedDate.Value;
                    DateTime? backfilledConcrete = null; if (((RadDatePicker)row.FindControl("tkrdpBackfilledConcrete")).SelectedDate.HasValue) backfilledConcrete = ((RadDatePicker)row.FindControl("tkrdpBackfilledConcrete")).SelectedDate.Value;
                    DateTime? backfilledSoil = null; if (((RadDatePicker)row.FindControl("tkrdpBackfilledSoil")).SelectedDate.HasValue) backfilledSoil = ((RadDatePicker)row.FindControl("tkrdpBackfilledSoil")).SelectedDate.Value;
                    DateTime? grouted = null; if (((RadDatePicker)row.FindControl("tkrdpGrouted")).SelectedDate.HasValue) grouted = ((RadDatePicker)row.FindControl("tkrdpGrouted")).SelectedDate.Value;
                    DateTime? cored = null; if (((RadDatePicker)row.FindControl("tkrdpCored")).SelectedDate.HasValue) cored = ((RadDatePicker)row.FindControl("tkrdpCored")).SelectedDate.Value;
                    DateTime? prepped = null; if (((RadDatePicker)row.FindControl("tkrdpPrepped")).SelectedDate.HasValue) prepped = ((RadDatePicker)row.FindControl("tkrdpPrepped")).SelectedDate.Value;
                    DateTime? measured = null; if (((RadDatePicker)row.FindControl("tkrdpMeasured")).SelectedDate.HasValue) measured = ((RadDatePicker)row.FindControl("tkrdpMeasured")).SelectedDate.Value;
                    string linerSize = ""; if (((TextBox)row.FindControl("tbxLinerSize")).Text.Trim() != "") linerSize = ((TextBox)row.FindControl("tbxLinerSize")).Text.Trim();
                    DateTime? inProcess = null; if (((RadDatePicker)row.FindControl("tkrdpInProcess")).SelectedDate.HasValue) inProcess = ((RadDatePicker)row.FindControl("tkrdpInProcess")).SelectedDate.Value;
                    DateTime? inStock = null; if (((RadDatePicker)row.FindControl("tkrdpInStock")).SelectedDate.HasValue) inStock = ((RadDatePicker)row.FindControl("tkrdpInStock")).SelectedDate.Value;
                    DateTime? tkrdplivered = null; if (((RadDatePicker)row.FindControl("tkrdpDelivered")).SelectedDate.HasValue) tkrdplivered = ((RadDatePicker)row.FindControl("tkrdpDelivered")).SelectedDate.Value;
                    DateTime? preVideo = null; if (((RadDatePicker)row.FindControl("tkrdpPreVideo")).SelectedDate.HasValue) preVideo = ((RadDatePicker)row.FindControl("tkrdpPreVideo")).SelectedDate.Value;
                    DateTime? linerInstalled = null; if (((RadDatePicker)row.FindControl("tkrdpLinerInstalled")).SelectedDate.HasValue) linerInstalled = ((RadDatePicker)row.FindControl("tkrdpLinerInstalled")).SelectedDate.Value;
                    DateTime? finalVideo = null; if (((RadDatePicker)row.FindControl("tkrdpFinalVideo")).SelectedDate.HasValue) finalVideo = ((RadDatePicker)row.FindControl("tkrdpFinalVideo")).SelectedDate.Value;
                    string distanceFromUSMH = ""; if (((TextBox)row.FindControl("tbxDistanceFromUSMH")).Text.Trim() != "") distanceFromUSMH = ((TextBox)row.FindControl("tbxDistanceFromUSMH")).Text.Trim();
                    string comments = ""; if (((TextBox)row.FindControl("tbxComments")).Text.Trim() != "") comments = ((TextBox)row.FindControl("tbxComments")).Text.Trim();
                    string history = ""; if (((TextBox)row.FindControl("tbxHistory")).Text.Trim() != "") history = ((TextBox)row.FindControl("tbxHistory")).Text.Trim();
                    decimal? cost = null; if (((TextBox)row.FindControl("tbxCost")).Text.Trim() != "") cost = decimal.Parse(((TextBox)row.FindControl("tbxCost")).Text.Trim());
                    bool deleted = false;
                    bool selected = true;
                    DateTime? videoInspection = null; if (((RadDatePicker)row.FindControl("tkrdpVideoInspection")).SelectedDate.HasValue) videoInspection = ((RadDatePicker)row.FindControl("tkrdpVideoInspection")).SelectedDate.Value;                    
                    string coPitLocation = ""; coPitLocation = ((DropDownList)row.FindControl("ddlCoPitLocation")).SelectedValue;
                    DateTime? coCutDown = null; if (((RadDatePicker)row.FindControl("tkrdpCoCutDown")).SelectedDate.HasValue) coCutDown = ((RadDatePicker)row.FindControl("tkrdpCoCutDown")).SelectedDate.Value;
                    DateTime? finalRestoration = null; if (((RadDatePicker)row.FindControl("tkrdpFinalRestoration")).SelectedDate.HasValue) finalRestoration = ((RadDatePicker)row.FindControl("tkrdpFinalRestoration")).SelectedDate.Value;
                    string clientLateralId = ""; if (((TextBox)row.FindControl("tbxClientLateralId")).Text.Trim() != "") clientLateralId = ((TextBox)row.FindControl("tbxClientLateralId")).Text.Trim();
                    string videoLengthToPropertyLine = ""; if (((TextBox)row.FindControl("tbxVideoLengthToPropertyLine")).Text.Trim() != "") videoLengthToPropertyLine = ((TextBox)row.FindControl("tbxVideoLengthToPropertyLine")).Text.Trim();
                    DateTime? noticeDelivered = null; if (((RadDatePicker)row.FindControl("tkrdpNoticeDelivered")).SelectedDate.HasValue) noticeDelivered = ((RadDatePicker)row.FindControl("tkrdpNoticeDelivered")).SelectedDate.Value;
                    string hamiltonInspectionNumber = ""; if (((TextBox)row.FindControl("tbxHamiltonInspectionNumber")).Text.Trim() != "") hamiltonInspectionNumber = ((TextBox)row.FindControl("tbxHamiltonInspectionNumber")).Text.Trim();
                    string flange = ""; flange = ((DropDownList)row.FindControl("ddlFlange")).SelectedValue;
                    string gasket = ""; gasket = ((DropDownList)row.FindControl("ddlGasket")).SelectedValue;
                    string connectionType = ""; connectionType = ((DropDownList)row.FindControl("ddlConnectionType")).SelectedValue;
                    string distanceFromDSMH = ""; if (((TextBox)row.FindControl("tbxDistanceFromDSMH")).Text.Trim() != "") distanceFromDSMH = ((TextBox)row.FindControl("tbxDistanceFromDSMH")).Text.Trim();
                    string depthOfLocated = ""; if (((TextBox)row.FindControl("tbxDepthOfLocated")).Text.Trim() != "") depthOfLocated = ((TextBox)row.FindControl("tbxDepthOfLocated")).Text.Trim();
                    bool digRequiredPriorToLining = ((CheckBox)row.FindControl("cbxDigRequiredPriorToLining")).Checked;
                    DateTime? digRequiredPriorToLiningCompleted = null; if (((RadDatePicker)row.FindControl("tkrdpDigRequiredPriorToLiningCompleted")).SelectedDate.HasValue) digRequiredPriorToLiningCompleted = ((RadDatePicker)row.FindControl("tkrdpDigRequiredPriorToLiningCompleted")).SelectedDate.Value;
                    bool digRequiredAfterLining = ((CheckBox)row.FindControl("cbxDigRequiredAfterLining")).Checked;
                    DateTime? digRequiredAfterLiningCompleted = null; if (((RadDatePicker)row.FindControl("tkrdpDigRequiredAfterLiningCompleted")).SelectedDate.HasValue) digRequiredAfterLiningCompleted = ((RadDatePicker)row.FindControl("tkrdpDigRequiredAfterLiningCompleted")).SelectedDate.Value;
                    bool outOfScope = ((CheckBox)row.FindControl("cbxOutOfScope")).Checked;
                    bool holdClientIssue = ((CheckBox)row.FindControl("cbxHoldClientIssue")).Checked;
                    DateTime? holdClientIssueResolved = null; if (((RadDatePicker)row.FindControl("tkrdpHoldClientIssueResolved")).SelectedDate.HasValue) holdClientIssueResolved = ((RadDatePicker)row.FindControl("tkrdpHoldClientIssueResolved")).SelectedDate.Value;
                    bool holdLFSIssue = ((CheckBox)row.FindControl("cbxHoldLFSIssue")).Checked;
                    DateTime? holdLFSIssueResolved = null; if (((RadDatePicker)row.FindControl("tkrdpHoldLFSIssueResolved")).SelectedDate.HasValue) holdLFSIssueResolved = ((RadDatePicker)row.FindControl("tkrdpHoldLFSIssueResolved")).SelectedDate.Value;
                    bool requiresRoboticPrep = ((CheckBox)row.FindControl("cbxRequiresRoboticPrep")).Checked;
                    DateTime? requiresRoboticPrepCompleted = null; if (((RadDatePicker)row.FindControl("tkrdpRequiresRoboticPrepCompleted")).SelectedDate.HasValue) requiresRoboticPrepCompleted = ((RadDatePicker)row.FindControl("tkrdpRequiresRoboticPrepCompleted")).SelectedDate.Value;
                    string linerType = ""; linerType = ((DropDownList)row.FindControl("ddlLinerType")).SelectedValue;
                    string prepType = ""; prepType = ((DropDownList)row.FindControl("ddlPrepType")).SelectedValue;
                    bool dyeTestReq = ((CheckBox)row.FindControl("ckbxDyeTestReq")).Checked;
                    DateTime? dyeTestComplete = null; if (((RadDatePicker)row.FindControl("tkrdpDyeTestComplete")).SelectedDate.HasValue) dyeTestComplete = ((RadDatePicker)row.FindControl("tkrdpDyeTestComplete")).SelectedDate.Value;

                    bool coRequired = false; if (prepType == "CO Req") coRequired = true;
                    bool pitRequired = false; if (prepType == "Pit Req") pitRequired = true;
                    bool liningThruCo = true;
                    bool postContractDigRequired = true;
                    string contractYear = ""; if (((TextBox)row.FindControl("tbxContractYear")).Text.Trim() != "") contractYear = ((TextBox)row.FindControl("tbxContractYear")).Text.Trim();

                    // ... Update row
                    flatSectionJl.Update(workId, assetId, section_, companyId, address, pipeLocated, servicesLocated, coInstalled, backfilledConcrete, backfilledSoil, grouted, cored, prepped, measured, linerSize, inProcess, inStock, tkrdplivered, preVideo, linerInstalled, finalVideo, distanceFromUSMH, distanceFromDSMH, cost, deleted, selected, videoInspection, coRequired, pitRequired, coPitLocation, postContractDigRequired, coCutDown, finalRestoration, clientLateralId, videoLengthToPropertyLine, liningThruCo, noticeDelivered, hamiltonInspectionNumber, flange, gasket, connectionType, depthOfLocated, digRequiredPriorToLining, digRequiredPriorToLiningCompleted, digRequiredAfterLining, digRequiredAfterLiningCompleted, outOfScope, holdClientIssue, holdClientIssueResolved, holdLFSIssue, holdLFSIssueResolved, requiresRoboticPrep, requiresRoboticPrepCompleted, linerType, prepType, dyeTestReq, dyeTestComplete, contractYear); 
                }

                // Store datasets
                Session["flatSectionJlTDS"] = flatSectionJlTDS;

                // Update database
                UpdateDatabase();

                ViewState["update"] = "yes";

                // Redirect
                string url = "";
                if (Request.QueryString["source_page"] == "jl_navigator2.aspx")
                {
                    url = "./jl_navigator2.aspx?source_page=flat_section_jl_edit.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&work_type=" + hdfWorkType.Value + GetNavigatorState() + "&update=yes";
                }

                if (Request.QueryString["source_page"] == "flat_section_jl_summary.aspx")
                {
                    url = "./flat_section_jl_summary.aspx?source_page=flat_section_jl_edit.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&work_type=" + hdfWorkType.Value + GetNavigatorState() + "&update=yes";
                }
                Response.Redirect(url);
            }
        }



        private void Save2()
        {
            Page.Validate();

            if (Page.IsValid)
            {
                FlatSectionJl flatSectionJl = new FlatSectionJl(flatSectionJlTDS);

                // Update flatSectionJlTDS
                foreach (GridViewRow row in grdvJl.Rows)
                {
                    // ... Get standard fields
                    int workId = int.Parse(((HiddenField)row.FindControl("hdfWorkID")).Value);
                    int assetId = int.Parse(((HiddenField)row.FindControl("hdfAssetID")).Value);
                    int section_ = int.Parse(((HiddenField)row.FindControl("hdfSection_")).Value);
                    int companyId = int.Parse(hdfCompanyId.Value);
                    string address = ((TextBox)row.FindControl("tbxAddress")).Text.Trim();
                    DateTime? pipeLocated = null; if (((RadDatePicker)row.FindControl("tkrdpPipeLocated")).SelectedDate.HasValue) pipeLocated = ((RadDatePicker)row.FindControl("tkrdpPipeLocated")).SelectedDate.Value;
                    DateTime? servicesLocated = null; if (((RadDatePicker)row.FindControl("tkrdpServicesLocated")).SelectedDate.HasValue) servicesLocated = ((RadDatePicker)row.FindControl("tkrdpServicesLocated")).SelectedDate.Value;
                    DateTime? coInstalled = null; if (((RadDatePicker)row.FindControl("tkrdpCoInstalled")).SelectedDate.HasValue) coInstalled = ((RadDatePicker)row.FindControl("tkrdpCoInstalled")).SelectedDate;
                    DateTime? backfilledConcrete = null; if (((RadDatePicker)row.FindControl("tkrdpBackfilledConcrete")).SelectedDate.HasValue) backfilledConcrete = ((RadDatePicker)row.FindControl("tkrdpBackfilledConcrete")).SelectedDate.Value;
                    DateTime? backfilledSoil = null; if (((RadDatePicker)row.FindControl("tkrdpBackfilledSoil")).SelectedDate.HasValue) backfilledSoil = ((RadDatePicker)row.FindControl("tkrdpBackfilledSoil")).SelectedDate.Value;
                    DateTime? grouted = null; if (((RadDatePicker)row.FindControl("tkrdpGrouted")).SelectedDate.HasValue) grouted = ((RadDatePicker)row.FindControl("tkrdpGrouted")).SelectedDate.Value;
                    DateTime? cored = null; if (((RadDatePicker)row.FindControl("tkrdpCored")).SelectedDate.HasValue) cored = ((RadDatePicker)row.FindControl("tkrdpCored")).SelectedDate.Value;
                    DateTime? prepped = null; if (((RadDatePicker)row.FindControl("tkrdpPrepped")).SelectedDate.HasValue) prepped = ((RadDatePicker)row.FindControl("tkrdpPrepped")).SelectedDate;
                    DateTime? measured = null; if (((RadDatePicker)row.FindControl("tkrdpMeasured")).SelectedDate.HasValue) measured = ((RadDatePicker)row.FindControl("tkrdpMeasured")).SelectedDate;
                    string linerSize = ""; if (((TextBox)row.FindControl("tbxLinerSize")).Text.Trim() != "") linerSize = ((TextBox)row.FindControl("tbxLinerSize")).Text.Trim();
                    DateTime? inProcess = null; if (((RadDatePicker)row.FindControl("tkrdpInProcess")).SelectedDate.HasValue) inProcess = ((RadDatePicker)row.FindControl("tkrdpInProcess")).SelectedDate.Value;
                    DateTime? inStock = null; if (((RadDatePicker)row.FindControl("tkrdpInStock")).SelectedDate.HasValue) inStock = ((RadDatePicker)row.FindControl("tkrdpInStock")).SelectedDate.Value;
                    DateTime? tkrdplivered = null; if (((RadDatePicker)row.FindControl("tkrdpDelivered")).SelectedDate.HasValue) tkrdplivered = ((RadDatePicker)row.FindControl("tkrdpDelivered")).SelectedDate.Value;
                    DateTime? preVideo = null; if (((RadDatePicker)row.FindControl("tkrdpPreVideo")).SelectedDate.HasValue) preVideo = ((RadDatePicker)row.FindControl("tkrdpPreVideo")).SelectedDate;
                    DateTime? linerInstalled = null; if (((RadDatePicker)row.FindControl("tkrdpLinerInstalled")).SelectedDate.HasValue) linerInstalled = ((RadDatePicker)row.FindControl("tkrdpLinerInstalled")).SelectedDate.Value;
                    DateTime? finalVideo = null; if (((RadDatePicker)row.FindControl("tkrdpFinalVideo")).SelectedDate.HasValue) finalVideo = ((RadDatePicker)row.FindControl("tkrdpFinalVideo")).SelectedDate.Value;
                    string distanceFromUSMH = ""; if (((TextBox)row.FindControl("tbxDistanceFromUSMH")).Text.Trim() != "") distanceFromUSMH = ((TextBox)row.FindControl("tbxDistanceFromUSMH")).Text.Trim();
                    string comments = ""; if (((TextBox)row.FindControl("tbxComments")).Text.Trim() != "") comments = ((TextBox)row.FindControl("tbxComments")).Text.Trim();
                    string history = ""; if (((TextBox)row.FindControl("tbxHistory")).Text.Trim() != "") history = ((TextBox)row.FindControl("tbxHistory")).Text.Trim();
                    decimal? cost = null; if (((TextBox)row.FindControl("tbxCost")).Text.Trim() != "") cost = decimal.Parse(((TextBox)row.FindControl("tbxCost")).Text.Trim());
                    bool deleted = false;
                    bool selected = true;
                    DateTime? videoInspection = null; if (((RadDatePicker)row.FindControl("tkrdpVideoInspection")).SelectedDate.HasValue) videoInspection = ((RadDatePicker)row.FindControl("tkrdpVideoInspection")).SelectedDate.Value;
                    string coPitLocation = ""; coPitLocation = ((DropDownList)row.FindControl("ddlCoPitLocation")).SelectedValue;
                    DateTime? coCutDown = null; if (((RadDatePicker)row.FindControl("tkrdpCoCutDown")).SelectedDate.HasValue) coCutDown = ((RadDatePicker)row.FindControl("tkrdpCoCutDown")).SelectedDate.Value;
                    DateTime? finalRestoration = null; if (((RadDatePicker)row.FindControl("tkrdpFinalRestoration")).SelectedDate.HasValue) finalRestoration = ((RadDatePicker)row.FindControl("tkrdpFinalRestoration")).SelectedDate.Value;
                    string clientLateralId = ""; if (((TextBox)row.FindControl("tbxClientLateralId")).Text.Trim() != "") clientLateralId = ((TextBox)row.FindControl("tbxClientLateralId")).Text.Trim();
                    string videoLengthToPropertyLine = ""; if (((TextBox)row.FindControl("tbxVideoLengthToPropertyLine")).Text.Trim() != "") videoLengthToPropertyLine = ((TextBox)row.FindControl("tbxVideoLengthToPropertyLine")).Text.Trim();
                    DateTime? noticeDelivered = null; if (((RadDatePicker)row.FindControl("tkrdpNoticeDelivered")).SelectedDate.HasValue) noticeDelivered = ((RadDatePicker)row.FindControl("tkrdpNoticeDelivered")).SelectedDate.Value;
                    string hamiltonInspectionNumber = ""; if (((TextBox)row.FindControl("tbxHamiltonInspectionNumber")).Text.Trim() != "") hamiltonInspectionNumber = ((TextBox)row.FindControl("tbxHamiltonInspectionNumber")).Text.Trim();
                    string flange = ""; flange = ((DropDownList)row.FindControl("ddlFlange")).SelectedValue;
                    string gasket = ""; gasket = ((DropDownList)row.FindControl("ddlGasket")).SelectedValue;
                    string connectionType = ""; connectionType = ((DropDownList)row.FindControl("ddlConnectionType")).SelectedValue;
                    string distanceFromDSMH = ""; if (((TextBox)row.FindControl("tbxDistanceFromDSMH")).Text.Trim() != "") distanceFromDSMH = ((TextBox)row.FindControl("tbxDistanceFromDSMH")).Text.Trim();
                    string depthOfLocated = ""; if (((TextBox)row.FindControl("tbxDepthOfLocated")).Text.Trim() != "") depthOfLocated = ((TextBox)row.FindControl("tbxDepthOfLocated")).Text.Trim();
                    bool digRequiredPriorToLining = ((CheckBox)row.FindControl("cbxDigRequiredPriorToLining")).Checked;
                    DateTime? digRequiredPriorToLiningCompleted = null; if (((RadDatePicker)row.FindControl("tkrdpDigRequiredPriorToLiningCompleted")).SelectedDate.HasValue) digRequiredPriorToLiningCompleted = ((RadDatePicker)row.FindControl("tkrdpDigRequiredPriorToLiningCompleted")).SelectedDate.Value;
                    bool digRequiredAfterLining = ((CheckBox)row.FindControl("cbxDigRequiredAfterLining")).Checked;
                    DateTime? digRequiredAfterLiningCompleted = null; if (((RadDatePicker)row.FindControl("tkrdpDigRequiredAfterLiningCompleted")).SelectedDate.HasValue) digRequiredAfterLiningCompleted = ((RadDatePicker)row.FindControl("tkrdpDigRequiredAfterLiningCompleted")).SelectedDate.Value;
                    bool outOfScope = ((CheckBox)row.FindControl("cbxOutOfScope")).Checked;
                    bool holdClientIssue = ((CheckBox)row.FindControl("cbxHoldClientIssue")).Checked;
                    DateTime? holdClientIssueResolved = null; if (((RadDatePicker)row.FindControl("tkrdpHoldClientIssueResolved")).SelectedDate.HasValue) holdClientIssueResolved = ((RadDatePicker)row.FindControl("tkrdpHoldClientIssueResolved")).SelectedDate.Value;
                    bool holdLFSIssue = ((CheckBox)row.FindControl("cbxHoldLFSIssue")).Checked;
                    DateTime? holdLFSIssueResolved = null; if (((RadDatePicker)row.FindControl("tkrdpHoldLFSIssueResolved")).SelectedDate.HasValue) holdLFSIssueResolved = ((RadDatePicker)row.FindControl("tkrdpHoldLFSIssueResolved")).SelectedDate.Value;
                    bool requiresRoboticPrep = ((CheckBox)row.FindControl("cbxRequiresRoboticPrep")).Checked;
                    DateTime? requiresRoboticPrepCompleted = null; if (((RadDatePicker)row.FindControl("tkrdpRequiresRoboticPrepCompleted")).SelectedDate.HasValue) requiresRoboticPrepCompleted = ((RadDatePicker)row.FindControl("tkrdpRequiresRoboticPrepCompleted")).SelectedDate.Value;
                    string linerType = ""; linerType = ((DropDownList)row.FindControl("ddlLinerType")).SelectedValue;
                    string prepType = ""; prepType = ((DropDownList)row.FindControl("ddlPrepType")).SelectedValue;
                    bool dyeTestReq = ((CheckBox)row.FindControl("ckbxDyeTestReq")).Checked;
                    DateTime? DyeTestComplete = null; if (((RadDatePicker)row.FindControl("tkrdpDyeTestComplete")).SelectedDate.HasValue) DyeTestComplete = ((RadDatePicker)row.FindControl("tkrdpDyeTestComplete")).SelectedDate.Value;
                    bool coRequired = false; if (prepType == "CO Req") coRequired = true;
                    bool pitRequired = false; if (prepType == "Pit Req") pitRequired = true;
                    bool liningThruCo = true;
                    bool postContractDigRequired = true;
                    string contractYear = ""; if (((TextBox)row.FindControl("tbxContractYear")).Text.Trim() != "") contractYear = ((TextBox)row.FindControl("tbxContractYear")).Text.Trim();

                    // ... Update row
                    flatSectionJl.Update(workId, assetId, section_, companyId, address, pipeLocated, servicesLocated, coInstalled, backfilledConcrete, backfilledSoil, grouted, cored, prepped, measured, linerSize, inProcess, inStock, tkrdplivered, preVideo, linerInstalled, finalVideo, distanceFromUSMH, distanceFromDSMH,  cost, deleted, selected, videoInspection, coRequired, pitRequired, coPitLocation, postContractDigRequired, coCutDown, finalRestoration, clientLateralId, videoLengthToPropertyLine, liningThruCo, noticeDelivered, hamiltonInspectionNumber, flange, gasket, connectionType, depthOfLocated, digRequiredPriorToLining, digRequiredPriorToLiningCompleted, digRequiredAfterLining, digRequiredAfterLiningCompleted, outOfScope, holdClientIssue, holdClientIssueResolved, holdLFSIssue, holdLFSIssueResolved, requiresRoboticPrep, requiresRoboticPrepCompleted, linerType, prepType, dyeTestReq, DyeTestComplete, contractYear); 
                }

                // Store datasets
                Session["flatSectionJlTDS"] = flatSectionJlTDS;
            }
        }



        private void Apply()
        {
            Page.Validate();

            if (Page.IsValid)
            {
                FlatSectionJl flatSectionJl = new FlatSectionJl(flatSectionJlTDS);

                // Update flatSectionJlTDS
                foreach (GridViewRow row in grdvJl.Rows)
                {
                    // ... Get standard fields
                    int workId = int.Parse(((HiddenField)row.FindControl("hdfWorkID")).Value);
                    int assetId = int.Parse(((HiddenField)row.FindControl("hdfAssetID")).Value);
                    int section_ = int.Parse(((HiddenField)row.FindControl("hdfSection_")).Value);
                    int companyId = int.Parse(hdfCompanyId.Value);
                    string address = ((TextBox)row.FindControl("tbxAddress")).Text.Trim();
                    DateTime? pipeLocated = null; if (((RadDatePicker)row.FindControl("tkrdpPipeLocated")).SelectedDate.HasValue) pipeLocated = ((RadDatePicker)row.FindControl("tkrdpPipeLocated")).SelectedDate.Value;
                    DateTime? servicesLocated = null; if (((RadDatePicker)row.FindControl("tkrdpServicesLocated")).SelectedDate.HasValue) servicesLocated = ((RadDatePicker)row.FindControl("tkrdpServicesLocated")).SelectedDate.Value;
                    DateTime? coInstalled = null; if (((RadDatePicker)row.FindControl("tkrdpCoInstalled")).SelectedDate.HasValue) coInstalled = ((RadDatePicker)row.FindControl("tkrdpCoInstalled")).SelectedDate.Value;
                    DateTime? backfilledConcrete = null; if (((RadDatePicker)row.FindControl("tkrdpBackfilledConcrete")).SelectedDate.HasValue) backfilledConcrete = ((RadDatePicker)row.FindControl("tkrdpBackfilledConcrete")).SelectedDate.Value;
                    DateTime? backfilledSoil = null; if (((RadDatePicker)row.FindControl("tkrdpBackfilledSoil")).SelectedDate.HasValue) backfilledSoil = ((RadDatePicker)row.FindControl("tkrdpBackfilledSoil")).SelectedDate.Value;
                    DateTime? grouted = null; if (((RadDatePicker)row.FindControl("tkrdpGrouted")).SelectedDate.HasValue) grouted = ((RadDatePicker)row.FindControl("tkrdpGrouted")).SelectedDate.Value;
                    DateTime? cored = null; if (((RadDatePicker)row.FindControl("tkrdpCored")).SelectedDate.HasValue) cored = ((RadDatePicker)row.FindControl("tkrdpCored")).SelectedDate.Value;
                    DateTime? prepped = null; if (((RadDatePicker)row.FindControl("tkrdpPrepped")).SelectedDate.HasValue) prepped = ((RadDatePicker)row.FindControl("tkrdpPrepped")).SelectedDate.Value;
                    DateTime? measured = null; if (((RadDatePicker)row.FindControl("tkrdpMeasured")).SelectedDate.HasValue) measured = ((RadDatePicker)row.FindControl("tkrdpMeasured")).SelectedDate.Value;
                    string linerSize = ""; if (((TextBox)row.FindControl("tbxLinerSize")).Text.Trim() != "") linerSize = ((TextBox)row.FindControl("tbxLinerSize")).Text.Trim();
                    DateTime? inProcess = null; if (((RadDatePicker)row.FindControl("tkrdpInProcess")).SelectedDate.HasValue) inProcess = ((RadDatePicker)row.FindControl("tkrdpInProcess")).SelectedDate.Value;
                    DateTime? inStock = null; if (((RadDatePicker)row.FindControl("tkrdpInStock")).SelectedDate.HasValue) inStock = ((RadDatePicker)row.FindControl("tkrdpInStock")).SelectedDate.Value;
                    DateTime? tkrdplivered = null; if (((RadDatePicker)row.FindControl("tkrdpDelivered")).SelectedDate.HasValue) tkrdplivered = ((RadDatePicker)row.FindControl("tkrdpDelivered")).SelectedDate.Value;
                    DateTime? preVideo = null; if (((RadDatePicker)row.FindControl("tkrdpPreVideo")).SelectedDate.HasValue) preVideo = ((RadDatePicker)row.FindControl("tkrdpPreVideo")).SelectedDate.Value;
                    DateTime? linerInstalled = null; if (((RadDatePicker)row.FindControl("tkrdpLinerInstalled")).SelectedDate.HasValue) linerInstalled = ((RadDatePicker)row.FindControl("tkrdpLinerInstalled")).SelectedDate.Value;
                    DateTime? finalVideo = null; if (((RadDatePicker)row.FindControl("tkrdpFinalVideo")).SelectedDate.HasValue) finalVideo = ((RadDatePicker)row.FindControl("tkrdpFinalVideo")).SelectedDate.Value;
                    string distanceFromUSMH = ""; if (((TextBox)row.FindControl("tbxDistanceFromUSMH")).Text.Trim() != "") distanceFromUSMH = ((TextBox)row.FindControl("tbxDistanceFromUSMH")).Text.Trim();
                    string comments = ""; if (((TextBox)row.FindControl("tbxComments")).Text.Trim() != "") comments = ((TextBox)row.FindControl("tbxComments")).Text.Trim();
                    string history = ""; if (((TextBox)row.FindControl("tbxHistory")).Text.Trim() != "") history = ((TextBox)row.FindControl("tbxHistory")).Text.Trim();
                    decimal? cost = null; if (((TextBox)row.FindControl("tbxCost")).Text.Trim() != "") cost = decimal.Parse(((TextBox)row.FindControl("tbxCost")).Text.Trim());
                    bool deleted = false;
                    bool selected = true;
                    DateTime? videoInspection = null; if (((RadDatePicker)row.FindControl("tkrdpVideoInspection")).SelectedDate.HasValue) videoInspection = ((RadDatePicker)row.FindControl("tkrdpVideoInspection")).SelectedDate.Value;
                    string coPitLocation = ""; coPitLocation = ((DropDownList)row.FindControl("ddlCoPitLocation")).SelectedValue;
                    DateTime? coCutDown = null; if (((RadDatePicker)row.FindControl("tkrdpCoCutDown")).SelectedDate.HasValue) coCutDown = ((RadDatePicker)row.FindControl("tkrdpCoCutDown")).SelectedDate.Value;
                    DateTime? finalRestoration = null; if (((RadDatePicker)row.FindControl("tkrdpFinalRestoration")).SelectedDate.HasValue) finalRestoration = ((RadDatePicker)row.FindControl("tkrdpFinalRestoration")).SelectedDate.Value;
                    string clientLateralId = ""; if (((TextBox)row.FindControl("tbxClientLateralId")).Text.Trim() != "") clientLateralId = ((TextBox)row.FindControl("tbxClientLateralId")).Text.Trim();
                    string videoLengthToPropertyLine = ""; if (((TextBox)row.FindControl("tbxVideoLengthToPropertyLine")).Text.Trim() != "") videoLengthToPropertyLine = ((TextBox)row.FindControl("tbxVideoLengthToPropertyLine")).Text.Trim();
                    DateTime? noticeDelivered = null; if (((RadDatePicker)row.FindControl("tkrdpNoticeDelivered")).SelectedDate.HasValue) noticeDelivered = ((RadDatePicker)row.FindControl("tkrdpNoticeDelivered")).SelectedDate.Value;
                    string hamiltonInspectionNumber = ""; if (((TextBox)row.FindControl("tbxHamiltonInspectionNumber")).Text.Trim() != "") hamiltonInspectionNumber = ((TextBox)row.FindControl("tbxHamiltonInspectionNumber")).Text.Trim();
                    string flange = ""; flange = ((DropDownList)row.FindControl("ddlFlange")).SelectedValue;
                    string gasket = ""; gasket = ((DropDownList)row.FindControl("ddlGasket")).SelectedValue;
                    string connectionType = ""; connectionType = ((DropDownList)row.FindControl("ddlConnectionType")).SelectedValue;
                    string distanceFromDSMH = ""; if (((TextBox)row.FindControl("tbxDistanceFromDSMH")).Text.Trim() != "") distanceFromDSMH = ((TextBox)row.FindControl("tbxDistanceFromDSMH")).Text.Trim();
                    string depthOfLocated = ""; if (((TextBox)row.FindControl("tbxDepthOfLocated")).Text.Trim() != "") depthOfLocated = ((TextBox)row.FindControl("tbxDepthOfLocated")).Text.Trim();
                    bool digRequiredPriorToLining = ((CheckBox)row.FindControl("cbxDigRequiredPriorToLining")).Checked;
                    DateTime? digRequiredPriorToLiningCompleted = null; if (((RadDatePicker)row.FindControl("tkrdpDigRequiredPriorToLiningCompleted")).SelectedDate.HasValue) digRequiredPriorToLiningCompleted = ((RadDatePicker)row.FindControl("tkrdpDigRequiredPriorToLiningCompleted")).SelectedDate.Value;
                    bool digRequiredAfterLining = ((CheckBox)row.FindControl("cbxDigRequiredAfterLining")).Checked;
                    DateTime? digRequiredAfterLiningCompleted = null; if (((RadDatePicker)row.FindControl("tkrdpDigRequiredAfterLiningCompleted")).SelectedDate.HasValue) digRequiredAfterLiningCompleted = ((RadDatePicker)row.FindControl("tkrdpDigRequiredAfterLiningCompleted")).SelectedDate.Value;
                    bool outOfScope = ((CheckBox)row.FindControl("cbxOutOfScope")).Checked;
                    bool holdClientIssue = ((CheckBox)row.FindControl("cbxHoldClientIssue")).Checked;
                    DateTime? holdClientIssueResolved = null; if (((RadDatePicker)row.FindControl("tkrdpHoldClientIssueResolved")).SelectedDate.HasValue) holdClientIssueResolved = ((RadDatePicker)row.FindControl("tkrdpHoldClientIssueResolved")).SelectedDate.Value;
                    bool holdLFSIssue = ((CheckBox)row.FindControl("cbxHoldLFSIssue")).Checked;
                    DateTime? holdLFSIssueResolved = null; if (((RadDatePicker)row.FindControl("tkrdpHoldLFSIssueResolved")).SelectedDate.HasValue) holdLFSIssueResolved = ((RadDatePicker)row.FindControl("tkrdpHoldLFSIssueResolved")).SelectedDate.Value;
                    bool requiresRoboticPrep = ((CheckBox)row.FindControl("cbxRequiresRoboticPrep")).Checked;
                    DateTime? requiresRoboticPrepCompleted = null; if (((RadDatePicker)row.FindControl("tkrdpRequiresRoboticPrepCompleted")).SelectedDate.HasValue) requiresRoboticPrepCompleted = ((RadDatePicker)row.FindControl("tkrdpRequiresRoboticPrepCompleted")).SelectedDate.Value;
                    string linerType = ""; linerType = ((DropDownList)row.FindControl("ddlLinerType")).SelectedValue;
                    string prepType = ""; prepType = ((DropDownList)row.FindControl("ddlPrepType")).SelectedValue;
                    bool dyeTestReq = ((CheckBox)row.FindControl("ckbxDyeTestReq")).Checked;
                    DateTime? DyeTestComplete = null; if (((RadDatePicker)row.FindControl("tkrdpDyeTestComplete")).SelectedDate.HasValue) DyeTestComplete = ((RadDatePicker)row.FindControl("tkrdpDyeTestComplete")).SelectedDate.Value;
                   
                    bool coRequired = false; if (prepType == "CO Req") coRequired = true;
                    bool pitRequired = false; if (prepType == "Pit Req") pitRequired = true;
                    bool liningThruCo = true;
                    bool postContractDigRequired = true;
                    string contractYear = ""; if (((TextBox)row.FindControl("tbxContractYear")).Text.Trim() != "") contractYear = ((TextBox)row.FindControl("tbxContractYear")).Text.Trim();

                    // ... Update row
                    flatSectionJl.Update(workId, assetId, section_, companyId, address, pipeLocated, servicesLocated, coInstalled, backfilledConcrete, backfilledSoil, grouted, cored, prepped, measured, linerSize, inProcess, inStock, tkrdplivered, preVideo, linerInstalled, finalVideo, distanceFromUSMH, distanceFromDSMH, cost, deleted, selected, videoInspection, coRequired, pitRequired, coPitLocation, postContractDigRequired, coCutDown, finalRestoration, clientLateralId, videoLengthToPropertyLine, liningThruCo, noticeDelivered, hamiltonInspectionNumber, flange, gasket, connectionType, depthOfLocated, digRequiredPriorToLining, digRequiredPriorToLiningCompleted, digRequiredAfterLining, digRequiredAfterLiningCompleted, outOfScope, holdClientIssue, holdClientIssueResolved, holdLFSIssue, holdLFSIssueResolved, requiresRoboticPrep, requiresRoboticPrepCompleted, linerType, prepType, dyeTestReq, DyeTestComplete, contractYear); 
                }

                // Store datasets
                Session["flatSectionJlTDS"] = flatSectionJlTDS;

                // Update database
                UpdateDatabase();

                ViewState["update"] = "yes";
            }
        }



        private void UpdateDatabase()
        {
            // Get ids & location
            int projectId = Int32.Parse(hdfCurrentProjectId.Value.Trim());
            int companyId = Int32.Parse(hdfCompanyId.Value);

            // ... load project
            ProjectGateway projectGateway = new ProjectGateway();
            projectGateway.LoadByProjectId(projectId);

            // ... get location
            Int64 countryId = projectGateway.GetCountryID(projectId);
            Int64? provinceId = null; if (projectGateway.GetProvinceID(projectId).HasValue) provinceId = (Int64)projectGateway.GetProvinceID(projectId);
            Int64? countyId = null; if (projectGateway.GetCountyID(projectId).HasValue) countyId = (Int64)projectGateway.GetCountyID(projectId);
            Int64? cityId = null; if (projectGateway.GetCityID(projectId).HasValue) cityId = (Int64)projectGateway.GetCityID(projectId);

            // Save
            DB.Open();
            DB.BeginTransaction();
            try
            {
                FlatSectionJl flatSectionJl = new FlatSectionJl(flatSectionJlTDS);
                flatSectionJl.UpdateDirect(countryId, provinceId, countyId, cityId, projectId, companyId);

                DB.CommitTransaction();

                flatSectionJlTDS.AcceptChanges();

                // Store datasets
                Session["flatSectionJlTDS"] = flatSectionJlTDS;
            }
            catch (Exception ex)
            {
                DB.RollbackTransaction();

                string url = string.Format("./../../error_page.aspx?error={0}", ex.Message.Replace('\n', ' '));
                Response.Redirect(url);
            }
        }



        private void SetFocusGridView()
        {
            int index = (int)Session["rowFocus"];
            GridViewRow gridRow = grdvJl.Rows[index];
            gridRow.FindControl("tbxHistory").Focus();
        }



    }
}