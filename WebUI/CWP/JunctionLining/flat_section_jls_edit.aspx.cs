using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.Tools;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Resources.Companies;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.BL.Assets.Assets;
using LiquiForce.LFSLive.DA.CWP.JunctionLining;
using LiquiForce.LFSLive.BL.CWP.JunctionLining;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.CWP.JunctionLining
{
    /// <summary>
    /// flat_section_jls_edit 
    /// </summary>
    public partial class flat_section_jls_edit : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected FlatSectionJlsTDS flatSectionJlsTDS;






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
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["client_id"] == null) || ((string)Request.QueryString["project_id"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in flat_section_jls_edit.aspx");
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
                lblTitleProjectName.Text = " > Project: " + name + " (" + projectGateway.GetProjectNumber(currentProjectId) + ") > Selected Sections";

                // If coming from 
                // ... jls_navigator2.aspx
                if (Request.QueryString["source_page"] == "jls_navigator2.aspx")
                {
                    StoreNavigatorState();
                    ViewState["update"] = "no";
                }

                // ... flat_section_jls_summary.aspx
                if (Request.QueryString["source_page"] == "flat_section_jls_summary.aspx")
                {
                    StoreNavigatorState();
                    ViewState["update"] = Request.QueryString["update"];
                }

                // Restore datasets
                flatSectionJlsTDS = (FlatSectionJlsTDS)Session["flatSectionJlsTDS"];

                DataView dataViewFlatSectionJls = new DataView(flatSectionJlsTDS.FlatSectionJls);
                dataViewFlatSectionJls.RowFilter = "(Selected = 1) AND (Deleted = 0)";
                grdvJls.DataSource = dataViewFlatSectionJls;

                //DataBind
                odsTrafficControl.DataBind();
                grdvJls.DataBind();
            }
            else
            {
                // Restore datasets
                flatSectionJlsTDS = (FlatSectionJlsTDS)Session["flatSectionJlsTDS"];

                DataView dataViewFlatSectionJls = new DataView(flatSectionJlsTDS.FlatSectionJls);
                dataViewFlatSectionJls.RowFilter = "(Selected = 1) AND (Deleted = 0)";
                grdvJls.DataSource = dataViewFlatSectionJls;

                //DataBind
                grdvJls.DataBind();
            }
        }



        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set active toolbar
            mForm6 master = (mForm6)this.Master;
            master.ActiveToolbar = "eSewers";

            // FooterMenu
            tbFooterToolbar.Visible = true;
            if (grdvJls.Rows.Count == 1)
            {
                tbFooterToolbar.Visible = false;
            }

            // Show or not show Old CWP ID field
            foreach (GridViewRow row in grdvJls.Rows)
            {
                if (((TextBox)row.FindControl("tbxOldCwpId")).Text == "")
                {
                    ((TextBox)row.FindControl("tbxOldCwpId")).Visible = false;
                    ((Label)row.FindControl("lblOldCwpId")).Visible = false;
                }
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // AUXILIAR EVENTS
        //

        protected void grdvJls_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // For usmh, dsmh autocomplete
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
            args.IsValid = Distance.IsValidDistance(args.Value.Trim());
        }



        public override void Validate()
        {
            // Validate page
            base.Validate();

            if (Page.IsValid)
            {
                foreach (GridViewRow row in grdvJls.Rows)
                {
                    // Verify new distance
                    int companyId = int.Parse(hdfCompanyId.Value);
                    int assetId = int.Parse(((HiddenField)row.FindControl("hdfAssetId")).Value);
                    string length = ((TextBox)row.FindControl("tbxLength")).Text.Trim();

                    AssetSewerSection assetSewerSection = new AssetSewerSection(null);
                    if (!assetSewerSection.VerifyNewLengthByAssetId(length, assetId, companyId))
                    {
                        ((CustomValidator)row.FindControl("cvLength2")).IsValid = false;
                    }
                }
            }
        }
        

        
        
        
        
        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATION EVENTS
        //

        protected void btnChange_Click(object sender, EventArgs e)
        {
            Response.Redirect("./../Common/select_project.aspx?source_page=flat_section_jls_edit.aspx&work_type=Junction Lining Section");
        }



        protected void tkrpbLeftMenu_ItemClick(object sender, RadPanelBarEventArgs e)
        {
            string url = "";

            switch (e.Item.Value)
            {
                case "mLiningPlan":
                    url = "./jl_lining_plan.aspx?source_page=lm&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&work_type=Junction Lining";
                    break;

                case "mSearchS":
                    url = "./jls_navigator.aspx?source_page=lm&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value;
                    break;

                case "mSearch":
                    url = "./jl_navigator.aspx?source_page=lm&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&work_type=Junction Lining";
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
                    flatSectionJlsTDS.RejectChanges();
                    string url = "";
                    if (Request.QueryString["source_page"] == "jls_navigator2.aspx")
                    {
                        url = "./jls_navigator2.aspx?source_page=flat_section_jls_edit.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    }

                    if (Request.QueryString["source_page"] == "flat_section_jls_summary.aspx")
                    {
                        url = "./flat_section_jls_summary.aspx?source_page=flat_section_jls_edit.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    }
                    Response.Redirect(url);
                    break;
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // METHODS
        //

        protected string GetTrafficControl(object name)
        {
            string trafficControl = " ";
            if (name != DBNull.Value)
            {
                trafficControl = name.ToString();
            }
            return trafficControl;
        }



        private void RegisterClientScripts()
        {
            // Publishing body's OnKeyDown event 
            HtmlGenericControl bodyUnload = (HtmlGenericControl)Page.Master.FindControl("myBody");
            bodyUnload.Attributes.Add("OnKeyDown", "OnKeyDown(event);");

            // Register content variables
            string contentVariables = "";
            contentVariables += "var hdfCurrentClientIdId = '" + hdfCurrentClientId.ClientID + "';";
            contentVariables += "var hdfCurrentProjectIdId = '" + hdfCurrentProjectId.ClientID + "';";
            contentVariables += "var tkrmTopId = '" + tkrmTop.ClientID + "';";  

            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./flat_section_jls_edit.js");
        }



        private void TagPage()
        {
            hdfCompanyId.Value = Session["companyID"].ToString();
            hdfCurrentProjectId.Value = Request.QueryString["project_id"].ToString();
            hdfCurrentClientId.Value = Request.QueryString["client_id"].ToString();

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
            ViewState["navigatorState"] = "&columns_to_display=" + Request.QueryString["columns_to_display"] + "&search_ddlCondition1=" + Request.QueryString["search_ddlCondition1"] + "&search_tbxCondition1=" + Request.QueryString["search_tbxCondition1"] + "&search_sort_by=" + Request.QueryString["search_sort_by"];
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
                FlatSectionJls flatSectionJls = new FlatSectionJls(flatSectionJlsTDS);

                // Update flatSectionJlsTDS
                foreach (GridViewRow row in grdvJls.Rows)
                {
                    // ... Get standard fields
                    int workId = int.Parse(((HiddenField)row.FindControl("hdfWorkID")).Value);
                    string street = ""; if (((TextBox)row.FindControl("tbxStreet")).Text.Trim() != "") street = ((TextBox)row.FindControl("tbxStreet")).Text.Trim();
                    string usmhId = ""; if (((TextBox)row.FindControl("tbxUSMH")).Text.Trim() != "") usmhId = ((TextBox)row.FindControl("tbxUSMH")).Text.Trim();
                    string dsmhId = ""; if (((TextBox)row.FindControl("tbxDSMH")).Text.Trim() != "") dsmhId = ((TextBox)row.FindControl("tbxDSMH")).Text.Trim();
                    string size_ = ""; if (((TextBox)row.FindControl("tbxSize_")).Text.Trim() != "") size_ = ((TextBox)row.FindControl("tbxSize_")).Text.Trim();
                    string length = ""; if (((TextBox)row.FindControl("tbxLength")).Text.Trim() != "") length = ((TextBox)row.FindControl("tbxLength")).Text.Trim();
                    string subArea = ""; if (((TextBox)row.FindControl("tbxSubArea")).Text.Trim() != "") subArea = ((TextBox)row.FindControl("tbxSubArea")).Text.Trim();
                    string trafficControl = ""; if (((DropDownList)row.FindControl("ddlTrafficControl")).SelectedValue != " ") trafficControl = ((DropDownList)row.FindControl("ddlTrafficControl")).SelectedValue;
                    string trafficControlDetails = ""; if (((TextBox)row.FindControl("tbxTrafficControlDetails")).Text.Trim() != "") trafficControlDetails = ((TextBox)row.FindControl("tbxTrafficControlDetails")).Text.Trim();
                    bool standardBypass = ((CheckBox)row.FindControl("cbxStandardBypass")).Checked;
                    string standardBypassComments = ""; if (((TextBox)row.FindControl("tbxStandardBypassComments")).Text.Trim() != "") standardBypassComments = ((TextBox)row.FindControl("tbxStandardBypassComments")).Text.Trim();

                    // ... Update row
                    flatSectionJls.Update(workId, street, usmhId, dsmhId, size_, length, subArea, trafficControl, trafficControlDetails, standardBypass, standardBypassComments);
                }

                // Store datasets
                Session["flatSectionJlsTDS"] = flatSectionJlsTDS;

                // Update database
                UpdateDatabase();

                ViewState["update"] = "yes";

                // Redirect
                string url = "";
                if (Request.QueryString["source_page"] == "jls_navigator2.aspx")
                {
                    url = "./jls_navigator2.aspx?source_page=flat_section_jls_edit.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + GetNavigatorState() + "&update=yes";
                }

                if (Request.QueryString["source_page"] == "flat_section_jls_summary.aspx")
                {
                    url = "./flat_section_jls_summary.aspx?source_page=flat_section_jls_edit.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + GetNavigatorState() + "&update=yes";
                }
                Response.Redirect(url);
            }
        }



        private void Apply()
        {
            Page.Validate();

            if (Page.IsValid)
            {
                FlatSectionJls flatSectionJls = new FlatSectionJls(flatSectionJlsTDS);

                // Update flatSectionJlsTDS
                foreach (GridViewRow row in grdvJls.Rows)
                {
                    // ... Get standard fields
                    int workId = int.Parse(((HiddenField)row.FindControl("hdfWorkID")).Value);
                    string street = ""; if (((TextBox)row.FindControl("tbxStreet")).Text.Trim() != "") street = ((TextBox)row.FindControl("tbxStreet")).Text.Trim();
                    string usmhId = ""; if (((TextBox)row.FindControl("tbxUSMH")).Text.Trim() != "") usmhId = ((TextBox)row.FindControl("tbxUSMH")).Text.Trim();
                    string dsmhId = ""; if (((TextBox)row.FindControl("tbxDSMH")).Text.Trim() != "") dsmhId = ((TextBox)row.FindControl("tbxDSMH")).Text.Trim();
                    string size_ = ""; if (((TextBox)row.FindControl("tbxSize_")).Text.Trim() != "") size_ = ((TextBox)row.FindControl("tbxSize_")).Text.Trim();
                    string length = ""; if (((TextBox)row.FindControl("tbxLength")).Text.Trim() != "") length = ((TextBox)row.FindControl("tbxLength")).Text.Trim();
                    string subArea = ""; if (((TextBox)row.FindControl("tbxSubArea")).Text.Trim() != "") subArea = ((TextBox)row.FindControl("tbxSubArea")).Text.Trim();
                    string trafficControl = ""; if (((DropDownList)row.FindControl("ddlTrafficControl")).SelectedValue != " ") trafficControl = ((DropDownList)row.FindControl("ddlTrafficControl")).SelectedValue;
                    string trafficControlDetails = ""; if (((TextBox)row.FindControl("tbxTrafficControlDetails")).Text.Trim() != "") trafficControlDetails = ((TextBox)row.FindControl("tbxTrafficControlDetails")).Text.Trim();
                    bool standardBypass = ((CheckBox)row.FindControl("cbxStandardBypass")).Checked;
                    string standardBypassComments = ""; if (((TextBox)row.FindControl("tbxStandardBypassComments")).Text.Trim() != "") standardBypassComments = ((TextBox)row.FindControl("tbxStandardBypassComments")).Text.Trim();

                    // ... Update row
                    flatSectionJls.Update(workId, street, usmhId, dsmhId, size_, length, subArea, trafficControl, trafficControlDetails, standardBypass, standardBypassComments);
                }

                // Store datasets
                Session["flatSectionJlsTDS"] = flatSectionJlsTDS;

                // Update database
                UpdateDatabase();

                ViewState["update"] = "yes";
            }
        }



        private void UpdateDatabase()
        {
            // Get Ids
            int projectId = Int32.Parse(hdfCurrentProjectId.Value.Trim());
            int companyId = Int32.Parse(hdfCompanyId.Value);
            Int64 countryId = int.Parse(hdfCountryId.Value);
            Int64? provinceId = null; if (hdfProvinceId.Value != "") provinceId = Int64.Parse(hdfProvinceId.Value);
            Int64? countyId = null; if (hdfCountyId.Value != "") countyId = Int64.Parse(hdfCountyId.Value);
            Int64? cityId = null; if (hdfCityId.Value != "") cityId = Int64.Parse(hdfCityId.Value);

            // Update DB
            DB.Open();
            DB.BeginTransaction();
            try
            {
                FlatSectionJls flatSectionJls = new FlatSectionJls(flatSectionJlsTDS);
                flatSectionJls.UpdateDirect(countryId, provinceId, countyId, cityId, projectId, companyId);

                DB.CommitTransaction();

                flatSectionJlsTDS.AcceptChanges();

                // Store datasets
                Session["flatSectionJlsTDS"] = flatSectionJlsTDS;
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