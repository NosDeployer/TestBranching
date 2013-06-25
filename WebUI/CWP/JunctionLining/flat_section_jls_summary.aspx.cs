using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.DA.Resources.Companies;
using LiquiForce.LFSLive.DA.CWP.JunctionLining;
using LiquiForce.LFSLive.BL.CWP.JunctionLining;
using LiquiForce.LFSLive.DA.Projects.Projects;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.CWP.JunctionLining
{
    /// <summary>
    /// flat_section_jls_summary
    /// </summary>
    public partial class flat_section_jls_summary : System.Web.UI.Page
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
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in flat_section_jls_summary.aspx");
                }

                // Tag Page
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfCurrentProjectId.Value = Request.QueryString["project_id"].ToString();
                hdfCurrentClientId.Value = Request.QueryString["client_id"].ToString();

                //Restore datasets
                flatSectionJlsTDS = (FlatSectionJlsTDS)Session["flatSectionJlsTDS"];

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

                // If comming from 

                // ... jls_navigator2.aspx
                if (Request.QueryString["source_page"] == "jls_navigator2.aspx")
                {
                    StoreNavigatorState();
                }

                // ... jls_delete.aspx or flat_section_jls_edit.aspx
                if ((Request.QueryString["source_page"] == "jls_delete.aspx") || (Request.QueryString["source_page"] == "flat_section_jls_edit.aspx"))
                {
                    StoreNavigatorState();
                    ViewState["update"] = Request.QueryString["update"];
                }

                // Grid filter
                odsFlatSectionJls.FilterExpression = "(Deleted = 0)";
                if (grdvJls.Rows.Count == 0)
                {
                    Response.Redirect("./jls_navigator2.aspx?source_page=flat_section_jls_summary.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"]);
                }
            }
            else
            {
                // Restore datasets
                flatSectionJlsTDS = (FlatSectionJlsTDS)Session["flatSectionJlsTDS"];

                // Grid filter
                odsFlatSectionJls.FilterExpression = "(Deleted = 0)";
                if (grdvJls.Rows.Count == 0)
                {
                    Response.Redirect("./jls_navigator2.aspx?source_page=flat_section_jls_summary.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"]);
                }
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
        // NAVIGATION EVENTS
        //

        protected void btnChange_Click(object sender, EventArgs e)
        {
            Response.Redirect("./../common/select_project.aspx?source_page=flat_section_jls_summary.aspx&work_type=Junction Lining Section");
        }



        protected void tkrmTop_ItemClick(object sender, RadMenuEventArgs e)
        {
            string url = "";

            switch (e.Item.Value)
            {
                case "mEdit":
                    if (this.Update() > 0)
                    {
                        url = "./flat_section_jls_edit.aspx?source_page=flat_section_jls_summary.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    }
                    break;

                case "mDelete":
                    if (this.Update() > 0)
                    {
                        Session["rowFocus"] = null;
                        url = "./jls_delete.aspx?source_page=flat_section_jls_summary.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    }
                    break;

                case "mLastSearch":
                    url = "./jls_navigator2.aspx?source_page=flat_section_jls_summary.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    break;

                // Works
                case "mRehabAssessment":
                    url = "./../../CWP/RehabAssessment/ra_navigator.aspx?source_page=select_project.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&work_type=Rehab Assessment";
                    break;

                case "mFullLenghtLining":
                    url = "./../FullLengthLining/fl_navigator.aspx?source_page=select_project.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&work_type=Full Length Lining";
                    break;

                case "mPointRepairs":
                    url = "./../PointRepairs/pr_navigator.aspx?source_page=select_project.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&work_type=Point Repairs";
                    break;
            }

            if (url != "") Response.Redirect(url);

        }



        protected void tkrpbLeftMenu_ItemClick(object sender, RadPanelBarEventArgs e)
        {
            string url = "";

            switch (e.Item.Value)
            {
                case "mSearchS":
                    url = "./jls_navigator.aspx?source_page=lm&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value;
                    break;

                case "mLiningPlan":
                    url = "./jl_lining_plan.aspx?source_page=lm&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&work_type=Junction Lining";
                    break;

                case "mSearch":
                    url = "./jl_navigator.aspx?source_page=lm&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&work_type=Junction Lining";
                    break;
            }

            if (url != "") Response.Redirect(url);
        }






        // ////////////////////////////////////////////////////////////////////////
        // METHODS
        //

        private void RegisterClientScripts()
        {
            // Publishing body's OnKeyDown event 
            HtmlGenericControl bodyUnload = (HtmlGenericControl)Page.Master.FindControl("myBody");
            bodyUnload.Attributes.Add("OnKeyDown", "OnKeyDown(event);");

            // Register content variables
            string contentVariables = "";
            contentVariables += "var hdfCurrentClientIdId = '" + hdfCurrentClientId.ClientID + "';";
            contentVariables += "var hdfCurrentProjectIdId = '" + hdfCurrentProjectId.ClientID + "';";
            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./flat_section_jls_summary.js");
        }



        private void StoreNavigatorState()
        {
            ViewState["navigatorState"] = "&columns_to_display=" + Request.QueryString["columns_to_display"] + "&search_ddlCondition1=" + Request.QueryString["search_ddlCondition1"] + "&search_tbxCondition1=" + Request.QueryString["search_tbxCondition1"] + "&search_sort_by=" + Request.QueryString["search_sort_by"];
        }



        private string GetNavigatorState()
        {
            return (string)ViewState["navigatorState"];
        }



        private int Update()
        {
            FlatSectionJls flatSectionJls = new FlatSectionJls(flatSectionJlsTDS);
            int jlsSelected = 0;

            // Update flatSectionJlsTDS
            foreach (GridViewRow row in grdvJls.Rows)
            {
                int workId = Int32.Parse(((HiddenField)row.FindControl("hdfWorkID")).Value.ToString().Trim());
                bool selected = ((CheckBox)row.FindControl("cbxSelected")).Checked;

                flatSectionJls.UpdateSelected(workId, selected);

                if (selected) jlsSelected++;
            }

            // Save jliners selection
            flatSectionJlsTDS.AcceptChanges();

            // Store datasets
            Session["flatSectionJlsTDS"] = flatSectionJlsTDS;

            return jlsSelected;
        }



    }
}