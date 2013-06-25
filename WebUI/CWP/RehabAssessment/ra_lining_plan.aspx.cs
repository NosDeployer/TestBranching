using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.DA.Resources.Companies;
using LiquiForce.LFSLive.BL.CWP.RehabAssessment;
using LiquiForce.LFSLive.DA.CWP.RehabAssessment;
using LiquiForce.LFSLive.DA.Projects.Projects;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.CWP.RehabAssessment
{
    /// <summary>
    /// ra_lining_plan
    /// </summary>
    public partial class ra_lining_plan : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected RaLiningPlanTDS raLiningPlanTDS;






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
                if (!Convert.ToBoolean(Session["sgLFS_CWP_REHABASSESSMENT_VIEW"]))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["client_id"] == null) || ((string)Request.QueryString["project_id"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in ra_lining_plan.aspx");
                }

                // Tag Page
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfCurrentProjectId.Value = Request.QueryString["project_id"].ToString();
                hdfCurrentClientId.Value = Request.QueryString["client_id"].ToString();
                hdfWorkType.Value = "Rehab Assessment";

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
                lblTitleProjectName.Text = " > Project: " + name + " (" + projectGateway.GetProjectNumber(currentProjectId) + ") > Rehab Assessment Plan";

                // ... for the grid
                raLiningPlanTDS = new RaLiningPlanTDS();
                int projectId = Int32.Parse(hdfCurrentProjectId.Value);
                
                RaLiningPlanGateway raLiningPlanGateway = new RaLiningPlanGateway(raLiningPlanTDS);
                raLiningPlanGateway.ClearBeforeFill = false;
                raLiningPlanGateway.LoadWithoutPreFlushDateWithouPreVideoDate(projectId, companyId);

                grdLiningPlan.DataSource = raLiningPlanGateway.Table;
                grdLiningPlan.DataBind();

                // Check results
                if (raLiningPlanTDS.RaLiningPlan.Rows.Count > 0)
                {
                    tPreview.Visible = true;
                    tdNoResults.Visible = false;
                    tbFooterToolbar.Visible = true;
                }
                else
                {
                    tPreview.Visible = false;
                    tdNoResults.Visible = true;
                    tbFooterToolbar.Visible = false;
                }

                // Check results
                if (raLiningPlanTDS.RaLiningPlan.Rows.Count == 1)
                {
                    tbFooterToolbar.Visible = false;
                }

                // Store dataset
                Session["raLiningPlanTDS"] = raLiningPlanTDS;
            }
            else
            {
                // Restore dataset
                raLiningPlanTDS = (RaLiningPlanTDS)Session["raLiningPlanTDS"];

                // ... for the grid
                RaLiningPlanGateway raLiningPlanGateway = new RaLiningPlanGateway(raLiningPlanTDS);
                int projectId = Int32.Parse(hdfCurrentProjectId.Value);
                int companyId = Int32.Parse(hdfCompanyId.Value);

                raLiningPlanGateway.ClearBeforeFill = false;
                raLiningPlanGateway.LoadWithoutPreFlushDateWithouPreVideoDate(projectId, companyId);

                grdLiningPlan.DataSource = raLiningPlanGateway.Table;
                grdLiningPlan.DataBind();
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

        protected void grdLiningPlan_Sorting(object sender, GridViewSortEventArgs e)
        {
            string direction = (e.SortDirection == SortDirection.Ascending) ? "ASC" : "DESC";

            DataView dataView = new DataView(raLiningPlanTDS.RaLiningPlan);
            dataView.Sort = e.SortExpression + " " + direction;
            grdLiningPlan.DataSource = dataView;
            grdLiningPlan.DataBind();
        }



        protected void btnOrder_Click(object sender, EventArgs e)
        {
            PostPageChanges();
            if (ddlOrder.SelectedIndex == 0)
            {
                grdLiningPlan.Sort("SectionID", SortDirection.Descending);
            }
            else
            {
                grdLiningPlan.Sort("Selected", SortDirection.Ascending);
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATION EVENTS
        //

        protected void btnChange_Click(object sender, EventArgs e)
        {
            Response.Redirect("./../Common/select_project.aspx?source_page=ra_lining_plan.aspx&work_type=" + hdfWorkType.Value);
        }



        protected void tkrpbLeftMenu_ItemClick(object sender, RadPanelBarEventArgs e)
        {
            string url = "";

            switch (e.Item.Value)
            {
                case "mSearch":
                    url = "./ra_navigator.aspx?source_page=lm&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&work_type=" + hdfWorkType.Value;
                    break;
            }

            if (url != "") Response.Redirect(url);
        }



        protected void tkrmTop_ItemClick(object sender, RadMenuEventArgs e)
        {
            if (e.Item.Value == "mPreview")
            {
                if (raLiningPlanTDS.RaLiningPlan.Rows.Count > 0)
                {
                    Page.Validate();
                    if (Page.IsValid)
                    {
                        PostPageChanges();
                        Response.Write("<script language='javascript'> {window.open('./ra_lining_plan_report.aspx', '_blank', 'toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680');}</script>");
                    }
                }
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // METHODS
        //

        protected string GetBooleanValue(object value)
        {
            return ((bool)value) ? "Yes" : "No";
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
            contentVariables += "var grdLiningPlanId = '" + grdLiningPlan.ClientID + "';";

            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./ra_lining_plan.js");
        }



        private void PostPageChanges()
        {
            RaLiningPlan raLiningPlan = new RaLiningPlan(raLiningPlanTDS);

            // Update section-setups
            foreach (GridViewRow row in grdLiningPlan.Rows)
            {
                int workId = int.Parse(((HiddenField)row.FindControl("hdfWorkId")).Value);
                int companyId = int.Parse(((HiddenField)row.FindControl("hdfCompanyId")).Value);
                DateTime? date_ = null; if (((RadDatePicker)row.FindControl("tkrdpDate_")).SelectedDate.HasValue) date_ = ((RadDatePicker)row.FindControl("tkrdpDate_")).SelectedDate.Value;
                string flusher = ((DropDownList)row.FindControl("ddlFlusherTruck")).SelectedValue;
                string flusherMN = ((DropDownList)row.FindControl("ddlFlusherMN")).SelectedValue;
                string video = ((DropDownList)row.FindControl("ddlVideoTruck")).SelectedValue;
                string videoMN = ((DropDownList)row.FindControl("ddlVideoMN")).SelectedValue;
                string selected = ((DropDownList)row.FindControl("ddlSelected")).SelectedValue;

                raLiningPlan.UpdateForReport(workId, companyId, date_, flusher, flusherMN, video, videoMN, selected);
            }

            // Store datasets
            Session["raLiningPlanTDS"] = raLiningPlanTDS;
        }



    }
}
