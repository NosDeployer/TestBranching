using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.DA.Resources.Companies;
using LiquiForce.LFSLive.DA.CWP.JunctionLining;
using LiquiForce.LFSLive.BL.CWP.JunctionLining;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.Tools;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.CWP.JunctionLining
{
    /// <summary>
    /// flat_section_jl_summary
    /// </summary>
    public partial class flat_section_jl_summary : System.Web.UI.Page
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
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in flat_section_jl_summary.aspx");
                }

                // Tag Page
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfCurrentProjectId.Value = Request.QueryString["project_id"].ToString();
                hdfCurrentClientId.Value = Request.QueryString["client_id"].ToString();
                hdfWorkType.Value = Request.QueryString["work_type"].ToString();

                //Restore datasets
                flatSectionJlTDS = (FlatSectionJlTDS)Session["flatSectionJlTDS"];

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
                if (name.Length > 23) name = name.Substring(0, 20) + "...";
                lblTitleProjectName.Text = " > Project: " + name + " (" + projectGateway.GetProjectNumber(currentProjectId) + ") > Selected Laterals";

                // If coming from 

                // ... jl_navigator2.aspx
                if (Request.QueryString["source_page"] == "jl_navigator2.aspx")
                {
                    StoreNavigatorState();
                    ViewState["update"] = "no";
                }

                // ... jl_delete.aspx or flat_section_jl_edit.aspx
                if ((Request.QueryString["source_page"] == "jl_delete.aspx") || (Request.QueryString["source_page"] == "flat_section_jl_edit.aspx"))
                {
                    StoreNavigatorState();
                    ViewState["update"] = Request.QueryString["update"];
                }

                // FooterMenu
                tbFooterToolbar.Visible = true;
                if (grdvJl.Rows.Count == 1)
                {
                    tbFooterToolbar.Visible = false;
                }

                // Grid filter
                odsFlatSectionJl.FilterExpression = "(Deleted = 0)";
                odsFlatSectionJl.DataBind();
                grdvJl.DataBind();
                if (grdvJl.Rows.Count == 0)
                {
                    Response.Redirect("./jl_navigator2.aspx?source_page=flat_section_jl_summary.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + GetNavigatorState() + "&work_type=" + hdfWorkType.Value + "&update=" + (string)ViewState["update"]);
                }
            }
            else
            {
                // Restore datasets
                flatSectionJlTDS = (FlatSectionJlTDS)Session["flatSectionJlTDS"];

                // FooterMenu
                tbFooterToolbar.Visible = true;
                if (grdvJl.Rows.Count == 1)
                {
                    tbFooterToolbar.Visible = false;
                }

                // Grid filter
                odsFlatSectionJl.FilterExpression = "(Deleted = 0)";
                if (grdvJl.Rows.Count == 0)
                {
                    Response.Redirect("./jl_navigator2.aspx?source_page=flat_section_jl_summary.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + GetNavigatorState() + "&work_type=" + hdfWorkType.Value + "&update=" + (string)ViewState["update"]);
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

        protected void grdvJl_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int rowFocus = e.Row.RowIndex;
                HiddenField hdfAssetID = (HiddenField)e.Row.FindControl("hdfAssetID");
                HiddenField hdfSection_ = (HiddenField)e.Row.FindControl("hdfSection_");

                // ... for comments
                Button btnComments = (Button)e.Row.FindControl("btnComments");
                btnComments.OnClientClick = string.Format("return btnCommentsClick('{0}', '{1}', '{2}', '{3}', '{4}');", hdfAssetID.Value, hdfCompanyId.Value, rowFocus, hdfWorkType.Value, hdfSection_.Value);

                // ... for history
                Button btnHistory = (Button)e.Row.FindControl("btnHistory");
                btnHistory.OnClientClick = string.Format("return btnHistoryClick('{0}', '{1}', '{2}', '{3}', '{4}');", hdfAssetID.Value, hdfCompanyId.Value, rowFocus, hdfWorkType.Value, hdfSection_.Value);
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATION EVENTS
        //

        protected void btnChange_Click(object sender, EventArgs e)
        {
            Response.Redirect("./../Common/select_project.aspx?source_page=flat_section_jl_summary.aspx&work_type=" + hdfWorkType.Value.Trim());
        }



        protected void tkrmTop_ItemClick(object sender, RadMenuEventArgs e)
        {
            string url = "";

            switch (e.Item.Value)
            {
                case "mEdit":
                    if (this.Update() > 0)
                    {
                        Session["rowFocus"] = null;
                        url = "./flat_section_jl_edit.aspx?source_page=flat_section_jl_summary.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + GetNavigatorState() + "&work_type=" + hdfWorkType.Value + "&update=" + (string)ViewState["update"];
                    }
                    break;

                case "mDelete":
                    if (this.Update() > 0)
                    {
                        Session["rowFocus"] = null;
                        url = "./jl_delete.aspx?source_page=flat_section_jl_summary.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + GetNavigatorState() + "&work_type=" + hdfWorkType.Value + "&update=" + (string)ViewState["update"];
                    }
                    break;

                case "mLastSearch":
                    url = "./jl_navigator2.aspx?source_page=flat_section_jl_summary.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + GetNavigatorState() + "&work_type=" + hdfWorkType.Value + "&update=" + (string)ViewState["update"];
                    break;

                case "mBulkDateUpdate":
                    if (this.Update() > 0)
                    {
                        ViewState["update"] = "yes";
                        string script = "<script language='javascript'>";
                        string url2 = "./jl_bulk_date_update.aspx?source_page=flat_section_jl_summary&client=" + hdfCurrentClientId.Value + "&project=" + hdfCurrentProjectId.Value;
                        script = script + string.Format("window.open('{0}', '_blank', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=500, height=350')", url2);
                        script = script + "</script>";
                        Response.Write(script);
                    }
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






        // ////////////////////////////////////////////////////////////////////////
        // METHODS
        //

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
            contentVariables += "var hdfCurrentClientIdId = '" + hdfCurrentClientId.ClientID + "';";
            contentVariables += "var hdfCurrentProjectIdId = '" + hdfCurrentProjectId.ClientID + "';";

            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./flat_section_jl_summary.js");
        }



        private void StoreNavigatorState()
        {
            ViewState["navigatorState"] = "&columns_to_display=" + Request.QueryString["columns_to_display"] + "&columns_to_display2=" + Request.QueryString["columns_to_display2"] + "&search_ddlCondition1=" + Request.QueryString["search_ddlCondition1"] + "&search_ddlCondition2=" + Request.QueryString["search_ddlCondition2"] + "&search_tbxCondition1=" + Request.QueryString["search_tbxCondition1"] + "&search_tbxCondition2=" + Request.QueryString["search_tbxCondition2"] + "&search_ddlOperator1=" + Request.QueryString["search_ddlOperator1"] + "&search_ddlOperator2=" + Request.QueryString["search_ddlOperator2"] + "&search_ddlView=" + Request.QueryString["search_ddlView"] + "&search_sort_by=" + Request.QueryString["search_sort_by"] + "&search_sub_area=" + Request.QueryString["search_sub_area"] + "&btn_origin=" + Request.QueryString["btn_origin"];
        }



        private string GetNavigatorState()
        {
            return (string)ViewState["navigatorState"];
        }



        private int Update()
        {
            FlatSectionJl flatSectionJl = new FlatSectionJl(flatSectionJlTDS);
            int jlSelected = 0;

            // Update flatSectionJlTDS
            foreach (GridViewRow row in grdvJl.Rows)
            {
                int workId = Int32.Parse(((HiddenField)row.FindControl("hdfWorkID")).Value.ToString().Trim());
                bool selected = ((CheckBox)row.FindControl("cbxSelected")).Checked;

                flatSectionJl.UpdateSelected(workId, selected);

                if (selected) jlSelected++;
            }

            // Save jliners selection
            flatSectionJlTDS.AcceptChanges();

            // Store datasets
            Session["flatSectionJlTDS"] = flatSectionJlTDS;

            return jlSelected;
        }



        private void SetFocusGridView()
        {
            int index = (int)Session["rowFocus"];
            GridViewRow gridRow = grdvJl.Rows[index];
            gridRow.FindControl("tbxHistory").Focus();
        }



    }
}