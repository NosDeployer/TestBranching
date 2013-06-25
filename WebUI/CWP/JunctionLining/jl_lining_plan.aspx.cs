using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.DA.Resources.Companies;
using LiquiForce.LFSLive.BL.CWP.JunctionLining;
using LiquiForce.LFSLive.DA.CWP.JunctionLining;
using LiquiForce.LFSLive.DA.CWP.Works;
using LiquiForce.LFSLive.DA.Projects.Projects;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.CWP.JunctionLining
{
    /// <summary>
    /// jl_lining_plan
    /// </summary>
    public partial class jl_lining_plan : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected JlLiningPlanTDS jlLiningPlanTDS;






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
                if (!Convert.ToBoolean(Session["sgLFS_CWP_JUNCTIONLINING_VIEW"]))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["client_id"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in jl_lining_plan.aspx");
                }

                // Tag Page
                hdfGeneralCompanyId.Value = Session["companyID"].ToString();
                hdfCurrentProjectId.Value = Request.QueryString["project_id"].ToString();
                hdfCurrentClientId.Value = Request.QueryString["client_id"].ToString();
                hdfWorkType.Value = Request.QueryString["work_type"].ToString();

                // Prepare initial data
                // ... for client
                int currentClientId = Int32.Parse(hdfCurrentClientId.Value.ToString());
                int companyId = Int32.Parse(Session["companyID"].ToString());

                CompaniesGateway companiesGateway = new CompaniesGateway();
                companiesGateway.LoadByCompaniesId(currentClientId, companyId);
                lblTitleClientName.Text = "Client: " + companiesGateway.GetName(currentClientId);

                // ... for project
                int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value.ToString());
                ProjectGateway projectGateway = new ProjectGateway();
                projectGateway.LoadByProjectId(currentProjectId);
                string name = projectGateway.GetName(currentProjectId);
                if (name.Length > 23) name = name.Substring(0, 20) + "...";
                lblTitleProjectName.Text = " > Project: " + name + " (" + projectGateway.GetProjectNumber(currentProjectId) + ")";

                // ... for the grid
                jlLiningPlanTDS = new JlLiningPlanTDS();
                JlLiningPlanGateway jlLiningPlanGateway = new JlLiningPlanGateway(jlLiningPlanTDS);
                jlLiningPlanGateway.ClearBeforeFill = false;
                jlLiningPlanGateway.LoadByProjectIdIssueWithLateralsNoOutOfScope(int.Parse(hdfGeneralCompanyId.Value), int.Parse(hdfCurrentProjectId.Value)); 
                jlLiningPlanGateway.LoadByProjectIdOtherIssueWithLaterals(int.Parse(hdfGeneralCompanyId.Value), int.Parse(hdfCurrentProjectId.Value)); 

                grdLiningPlan.DataSource = jlLiningPlanGateway.Table;
                grdLiningPlan.DataBind();

                // Check results
                if (jlLiningPlanTDS.JlLiningPlan.Rows.Count > 0)
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
                if (jlLiningPlanTDS.JlLiningPlan.Rows.Count == 1)
                {
                    tbFooterToolbar.Visible = false;
                }                

                // Store dataset
                Session["jlLiningPlanTDS"] = jlLiningPlanTDS;
            }
            else
            {
                // Restore dataset
                jlLiningPlanTDS = (JlLiningPlanTDS)Session["jlLiningPlanTDS"];

                // ... for the grid
                JlLiningPlanGateway jlLiningPlanGateway = new JlLiningPlanGateway(jlLiningPlanTDS);
                grdLiningPlan.DataSource = jlLiningPlanGateway.Table;
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

        protected void grdLiningPlan_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Normal) || (e.Row.RowState == (DataControlRowState.Normal | DataControlRowState.Alternate))))
            {
                
            }
        }



        protected void btnOrder_Click(object sender, EventArgs e)
        {
            PostPageChanges();
            if (ddlOrder.SelectedIndex == 0)
            {
                grdLiningPlan.Sort("AllMeasured, NumLats, SectionID", SortDirection.Descending);
            }
            else
            {
                grdLiningPlan.Sort("Selected", SortDirection.Ascending);
            }
        }



        protected void grdLiningPlan_Sorting(object sender, GridViewSortEventArgs e)
        {
            string direction = (e.SortDirection == SortDirection.Ascending) ? "ASC" : "DESC";

            DataView dataView = new DataView(jlLiningPlanTDS.JlLiningPlan);
            dataView.Sort = e.SortExpression + " " + direction;
            grdLiningPlan.DataSource = dataView;
            grdLiningPlan.DataBind();
        }






        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATION EVENTS
        //

        protected void btnChange_Click(object sender, EventArgs e)
        {
            Response.Redirect("./../Common/select_project.aspx?source_page=jl_lining_plan.aspx&work_type=Junction Lining");
        }



        protected void tkrmTop_ItemClick(object sender, RadMenuEventArgs e)
        {
            if (e.Item.Value == "mPreview")
            {
                if (jlLiningPlanTDS.JlLiningPlan.Rows.Count > 0)
                {
                    Page.Validate();
                    if (Page.IsValid)
                    {
                        PostPageChanges();
                        Response.Write("<script language='javascript'> {window.open('./jl_lining_plan_laterals.aspx?source_page=jl_lining_plan.aspx&project_id=" + hdfCurrentProjectId.Value + "&client_id=" + hdfCurrentClientId.Value + "&work_type=" + hdfWorkType.Value + "', '_blank', 'toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=yes, resizable=yes, copyhistory=no, width=800, height=680');}</script>");
                    }
                }
            }
        }



        protected void tkrpbLeftMenu_ItemClick(object sender, RadPanelBarEventArgs e)
        {
            string url = "";

            switch (e.Item.Value)
            {
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
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./jl_lining_plan.js");
        }



        private void PostPageChanges()
        {
            JlLiningPlan jlLiningPlan = new JlLiningPlan(jlLiningPlanTDS);
            
            foreach (GridViewRow row in grdLiningPlan.Rows)
            {
                // Update section-setups
                int assetId = int.Parse(((HiddenField)row.FindControl("hdfAssetId")).Value);
                int companyId = int.Parse(((HiddenField)row.FindControl("hdfCompanyId")).Value);
                DateTime? date_ = null; if (((RadDatePicker)row.FindControl("tkrdpDate_")).SelectedDate.HasValue) date_ = ((RadDatePicker)row.FindControl("tkrdpDate_")).SelectedDate.Value;
                string flusher = ((DropDownList)row.FindControl("ddlFlusher")).SelectedValue;
                string flusherMN = ((DropDownList)row.FindControl("ddlFlusherMN")).SelectedValue;
                string liner = ((DropDownList)row.FindControl("ddlLiner")).SelectedValue;
                string linerMN = ((DropDownList)row.FindControl("ddlLinerMN")).SelectedValue;
                string rotator = ((DropDownList)row.FindControl("ddlRotator")).SelectedValue;
                string rotatorMN = ((DropDownList)row.FindControl("ddlRotatorMN")).SelectedValue;
                string compressor = ((DropDownList)row.FindControl("ddlCompressor")).SelectedValue;
                string compressorMN = ((DropDownList)row.FindControl("ddlCompressorMN")).SelectedValue;
                string selected = ((DropDownList)row.FindControl("ddlSelected")).SelectedValue;
                string flowOrderId = ((TextBox)row.FindControl("tbxFlowOrderId")).Text.Trim();

                // Update comments              
                int workId = Int32.Parse(((HiddenField)row.FindControl("hdfWorkID")).Value.Trim());

                WorkJunctionLiningSectionGateway workJunctionLiningSectionGateway = new WorkJunctionLiningSectionGateway();
                workJunctionLiningSectionGateway.LoadByWorkId(workId, companyId);
                string trafficControlDetails = workJunctionLiningSectionGateway.GetTrafficControlDetails(workId);
                string standardByPassComments = workJunctionLiningSectionGateway.GetStandardBypassComments(workId);
                
                // Update fields
                jlLiningPlan.UpdateForReport(assetId, companyId, date_, flusher, flusherMN, liner, linerMN, rotator, rotatorMN, compressor, compressorMN, selected, flowOrderId, standardByPassComments, trafficControlDetails);
            }

            // Store datasets
            Session["jlLiningPlanTDS"] = jlLiningPlanTDS;
        }



    }
}