using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.BL.CWP.PointRepairs;
using LiquiForce.LFSLive.DA.CWP.PointRepairs;
using LiquiForce.LFSLive.DA.Resources.Companies;
using LiquiForce.LFSLive.DA.Projects.Projects;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.CWP.PointRepairs
{
    /// <summary>
    /// pr_lining_plan
    /// </summary>
    public partial class pr_lining_plan : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected PlLiningPlanTDS prLiningPlanTDS;






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
                if (!Convert.ToBoolean(Session["sgLFS_CWP_POINTREPAIRS_VIEW"]))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["client_id"] == null) || ((string)Request.QueryString["project_id"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in pr_lining_plan.aspx");
                }

                // Tag Page
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfCurrentProjectId.Value = Request.QueryString["project_id"].ToString();
                hdfCurrentClientId.Value = Request.QueryString["client_id"].ToString();
                hdfWorkType.Value = "Point Repairs";

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
                lblTitleProjectName.Text = " > Project: " + name + " (" + projectGateway.GetProjectNumber(currentProjectId) + ") > Lining Plan";

                // ... for the grid
                prLiningPlanTDS = new PlLiningPlanTDS();
                int projectId = Int32.Parse(hdfCurrentProjectId.Value);
                
                PrLiningPlanGateway prLiningPlanGateway = new PrLiningPlanGateway(prLiningPlanTDS);
                prLiningPlanGateway.ClearBeforeFill = false;
                prLiningPlanGateway.Load(projectId, companyId);

                grdLiningPlan.DataSource = prLiningPlanGateway.Table;
                grdLiningPlan.DataBind();

                // Check results
                if (prLiningPlanTDS.PlLiningPlan.Rows.Count > 0)
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
                if (prLiningPlanTDS.PlLiningPlan.Rows.Count == 1)
                {
                    tbFooterToolbar.Visible = false;
                }

                // Store dataset
                Session["prLiningPlanTDS"] = prLiningPlanTDS;
            }
            else
            {
                // Restore dataset
                prLiningPlanTDS = (PlLiningPlanTDS)Session["prLiningPlanTDS"];

                // ... for the grid
                PrLiningPlanGateway prLiningPlanGateway = new PrLiningPlanGateway(prLiningPlanTDS);
                grdLiningPlan.DataSource = prLiningPlanGateway.Table;
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

            DataView dataView = new DataView(prLiningPlanTDS.PlLiningPlan);
            dataView.Sort = e.SortExpression + " " + direction;
            grdLiningPlan.DataSource = dataView;
            grdLiningPlan.DataBind();
        }



        protected void btnOrder_Click(object sender, EventArgs e)
        {
            PostPageChanges();

            string filter = "";

            switch (ddlFilter.SelectedValue)
            {
                case "(All)":
                    filter = "";
                    break;

                case "Robotic Reaming":
                    filter = "Type='Robotic Reaming'";
                    break;

                case "Point Lining":
                    filter = "Type='Point Lining'";
                    break;

                case "Grouting":
                    filter = "Type='Grouting'";
                    break;
            }

            if (ddlOrder.SelectedIndex == 0)
            {
                if (prLiningPlanTDS.PlLiningPlan.Rows.Count > 0)
                {
                    prLiningPlanTDS.PlLiningPlan.DefaultView.RowFilter = filter;
                    prLiningPlanTDS.PlLiningPlan.DefaultView.Sort = "FlowOrderID, WorkID, RepairPointID DESC";
                    grdLiningPlan.DataSource = prLiningPlanTDS.PlLiningPlan.DefaultView;
                }
            }
            else
            {
                if (prLiningPlanTDS.PlLiningPlan.Rows.Count > 0)
                {
                    prLiningPlanTDS.PlLiningPlan.DefaultView.RowFilter = filter;
                    prLiningPlanTDS.PlLiningPlan.DefaultView.Sort = "Selected ASC";
                    grdLiningPlan.DataSource = prLiningPlanTDS.PlLiningPlan.DefaultView;
                }
            }

            grdLiningPlan.DataBind();
        }



        protected void grdLiningPlan_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int workId = Int32.Parse(((HiddenField)e.Row.FindControl("hdfWorkID")).Value);
                int companyId = Int32.Parse(hdfCompanyId.Value);

                PointRepairsSectionDetailsGateway pointRepairsSectionDetailsGateway = new PointRepairsSectionDetailsGateway();
                pointRepairsSectionDetailsGateway.LoadByWorkId(workId, companyId);

                string usmh = pointRepairsSectionDetailsGateway.GetUsmhDescription(workId);
                string dsmh = pointRepairsSectionDetailsGateway.GetDsmhDescription(workId);

                DropDownList ddlVideoMN = (DropDownList)e.Row.FindControl("ddlVideoMN");
                DropDownList ddlLinerMN = (DropDownList)e.Row.FindControl("ddlLinerMN");

                ddlVideoMN.Items.Add("");
                ddlVideoMN.Items.Add(usmh);
                ddlVideoMN.Items.Add(dsmh);

                try
                {
                    ddlVideoMN.SelectedValue = ((HiddenField)e.Row.FindControl("hdfVideoMN")).Value;
                }
                catch
                {
                    ddlVideoMN.SelectedIndex = 0;
                }

                ddlLinerMN.Items.Add("");
                ddlLinerMN.Items.Add(usmh);
                ddlLinerMN.Items.Add(dsmh);

                try
                {
                    ddlLinerMN.SelectedValue = ((HiddenField)e.Row.FindControl("hdfLinerMN")).Value;
                }
                catch
                {
                    ddlLinerMN.SelectedIndex = 0;
                }
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATION EVENTS
        //

        protected void btnChange_Click(object sender, EventArgs e)
        {
            Response.Redirect("./../Common/select_project.aspx?source_page=pr_lining_plan.aspx&work_type=" + hdfWorkType.Value);
        }



        protected void tkrpbLeftMenu_ItemClick(object sender, RadPanelBarEventArgs e)
        {
            switch (e.Item.Value)
            {
                case "mSearch":
                    string url = "./pr_navigator.aspx?source_page=lm&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&work_type=" + hdfWorkType.Value;
                    Response.Redirect(url);
                    break;
            }
        }



        protected void tkrmTop_ItemClick(object sender, RadMenuEventArgs e)
        {
            if (e.Item.Value == "mPreview")
            {
                if (prLiningPlanTDS.PlLiningPlan.Rows.Count > 0)
                {
                    Page.Validate();
                    if (Page.IsValid)
                    {
                        PostPageChanges();

                        string name = "";
                        string client = "";
                        string project = "";

                        // ... for client
                        int companyId = Int32.Parse(hdfCompanyId.Value);
                        int currentClientId = Int32.Parse(hdfCurrentClientId.Value.ToString());
                        CompaniesGateway companiesGateway = new CompaniesGateway();
                        companiesGateway.LoadByCompaniesId(currentClientId, companyId);
                        client += "Client: " + companiesGateway.GetName(currentClientId);

                        // ... for project
                        int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value.ToString());
                        ProjectGateway projectGateway = new ProjectGateway();
                        projectGateway.LoadByProjectId(currentProjectId);
                        project = projectGateway.GetName(currentProjectId);
                        name = client + " > Project: " + project + " (" + projectGateway.GetProjectNumber(currentProjectId) + ")";

                        Response.Write("<script language='javascript'> {window.open('./pr_lining_plan_report.aspx?name=" + name + "', '_blank', 'toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680');}</script>");
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
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./pr_lining_plan.js");
        }



        private void PostPageChanges()
        {
            PrLiningPlan prLiningPlan = new PrLiningPlan(prLiningPlanTDS);

            // Update repair-setups
            foreach (GridViewRow row in grdLiningPlan.Rows)
            {
                int workId = int.Parse(((HiddenField)row.FindControl("hdfWorkId")).Value);
                string repairPointId = ((HiddenField)row.FindControl("hdfRepairPointId")).Value;
                DateTime? date_ = null; if (((TextBox)row.FindControl("tbxDate_")).Text.Trim() != "") date_ = DateTime.Parse(((TextBox)row.FindControl("tbxDate_")).Text.Trim());
                string selected = ((DropDownList)row.FindControl("ddlSelected")).SelectedValue;
                string liner = ((DropDownList)row.FindControl("ddlLinerTruck")).SelectedValue;
                string linerMN = ((DropDownList)row.FindControl("ddlLinerMN")).SelectedValue;
                string video = ((DropDownList)row.FindControl("ddlVideoTruck")).SelectedValue;
                string videoMN = ((DropDownList)row.FindControl("ddlVideoMN")).SelectedValue;

                prLiningPlan.UpdateForReport(workId, repairPointId, date_, selected, liner, linerMN, video, videoMN);
            }

            // Store datasets
            Session["prLiningPlanTDS"] = prLiningPlanTDS;
        }
                


    }
}