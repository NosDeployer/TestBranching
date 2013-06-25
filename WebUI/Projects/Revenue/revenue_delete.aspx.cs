using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Projects.Revenue;
using LiquiForce.LFSLive.BL.Projects.Revenue;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.BL.Projects.Projects;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.Projects.Revenue
{
    /// <summary>
    /// revenue_delete
    /// </summary>
    public partial class revenue_delete : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //
        protected RevenueInformationTDS revenueInformationTDS;
        protected RevenueInformationTDS.BasicInformationDataTable revenueInformationBasicInformation;        






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
                    if (!(Convert.ToBoolean(Session["sgLFS_PROJECTS_REVENUE_VIEW"]) && Convert.ToBoolean(Session["sgLFS_PROJECTS_REVENUE_DELETE"])))
                    {
                        Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                    }

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["project_id"] == null) || ((string)Request.QueryString["ref_id"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in revenue_delete.aspx");
                }

                // Tag page
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfCurrentProjectId.Value = Request.QueryString["project_id"];
                hdfCurrentRefId.Value = Request.QueryString["ref_id"];

                // ... for team member title
                int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
                int projectId = Int32.Parse(hdfCurrentProjectId.Value);
                int refId = Int32.Parse(hdfCurrentRefId.Value);

                RevenueInformationBasicInformationGateway revenueInformationBasicInformationGatewayForTitle = new RevenueInformationBasicInformationGateway();
                revenueInformationBasicInformationGatewayForTitle.LoadByProjectIdRefId(projectId, refId, companyId);
                decimal revenue = decimal.Round(revenueInformationBasicInformationGatewayForTitle.GetRevenue(projectId, refId), 2);
                string money = "";
                if (revenueInformationBasicInformationGatewayForTitle.GetCountryId(projectId, refId) == 1) // Canada
                {
                    money = " (CAD)";
                }
                else
                {
                    money = " (USD)";
                }

                lblTitleRevenue.Text = "Revenue: " + revenue + money + " (" + revenueInformationBasicInformationGatewayForTitle.GetDate(projectId, refId).ToShortDateString() + ")";                

                // If coming from 
                // ... revenue_navigator2.aspx
                if (Request.QueryString["source_page"] == "revenue_navigator2.aspx")
                {
                    revenueInformationTDS = new RevenueInformationTDS();
                    RevenueInformationBasicInformation revenueInformationBasicInformationForEdit = new RevenueInformationBasicInformation(revenueInformationTDS);
                    revenueInformationBasicInformationForEdit.LoadByProjectIdRefId(projectId, refId, companyId);                  

                    StoreNavigatorState();
                    ViewState["update"] = "no";

                    // Store dataset
                    Session["revenueInformationTDS"] = revenueInformationTDS;
                }

                // ... revenue_summary.aspx
                if (Request.QueryString["source_page"] == "revenue_summary.aspx")
                {
                    StoreNavigatorState();
                    ViewState["update"] = Request.QueryString["update"];

                    // Restore dataset
                    revenueInformationTDS = (RevenueInformationTDS)Session["revenueInformationTDS"];                   
                }                               
            }
            else
            {
                // Restore dataset 
                revenueInformationTDS = (RevenueInformationTDS)Session["revenueInformationTDS"];
            }
        }        

                   

        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set active toolbar
            mForm6 master = (mForm6)this.Master;
            master.ActiveToolbar = "Projects";
        }






        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATION EVENTS
        //

        protected void tkrmTop_ItemClick(object sender, RadMenuEventArgs e)
        {
            string url = null;

            switch (e.Item.Value)
            {
                case "mDelete":
                    Page.Validate();

                    if (Page.IsValid)
                    {
                        Delete();
                        UpdateDatabase();

                        // Redirect
                        if (Request.QueryString["source_page"] == "revenue_navigator2.aspx")
                        {
                            url = "./revenue_navigator2.aspx?source_page=revenue_delete.aspx&project_id=" + hdfCurrentProjectId.Value + "&ref_id=" + hdfCurrentRefId.Value + GetNavigatorState() + "&update=yes";
                        }

                        if (Request.QueryString["source_page"] == "revenue_summary.aspx")
                        {
                            url = "./revenue_navigator2.aspx?source_page=revenue_delete.aspx&project_id=" + hdfCurrentProjectId.Value + "&ref_id=" + hdfCurrentRefId.Value + GetNavigatorState() + "&update=yes";
                        }


                        Response.Redirect(url);
                    }
                    break;

                case "mCancel":
                    if (Request.QueryString["source_page"] == "revenue_navigator2.aspx")
                    {
                        url = "./revenue_navigator2.aspx?source_page=revenue_delete.aspx&project_id=" + hdfCurrentProjectId.Value + "&ref_id=" + hdfCurrentRefId.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    }

                    if (Request.QueryString["source_page"] == "revenue_summary.aspx")
                    {
                        url = "./revenue_summary.aspx?source_page=revenue_delete.aspx&project_id=" + hdfCurrentProjectId.Value + "&ref_id=" + hdfCurrentRefId.Value  + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    }

                    if (url != "") Response.Redirect(url);
                    break;
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // METHODS
        //

        private void RegisterClientScripts()
        {
            // Publishing body's OnKeyDown event 
            HtmlGenericControl bodyUnload = (HtmlGenericControl)Page.Master.FindControl("myBody");
            bodyUnload.Attributes.Add("OnKeyDown", "OnKeyDown(event);");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./revenue_delete.js");
        }



        private void StoreNavigatorState()
        {
            ViewState["navigatorState"] = "&search_country_id=" + Request.QueryString["search_country_id"] + "&search_client=" + Request.QueryString["search_client"] + "&search_project=" + Request.QueryString["search_project"] + "&search_sort_by=" + Request.QueryString["search_sort_by"] + "&search_start_date=" + Request.QueryString["search_start_date"] + "&search_end_date=" + Request.QueryString["search_end_date"];
        }



        private string GetNavigatorState()
        {
            return (string)ViewState["navigatorState"];
        }



        private void Delete()
        {
            int projectId = int.Parse(hdfCurrentProjectId.Value);
            int refId = int.Parse(hdfCurrentRefId.Value);

            RevenueInformationBasicInformation revenueInformationBasicInformation = new RevenueInformationBasicInformation(revenueInformationTDS);
            revenueInformationBasicInformation.Delete(projectId, refId);

            // Store datasets
            Session["revenueInformationTDS"] = revenueInformationTDS;
        }



        private void UpdateDatabase()
        {
            // Get ids
            int projectId = int.Parse(hdfCurrentProjectId.Value);
            int refId = int.Parse(hdfCurrentRefId.Value);
            int companyId = int.Parse(hdfCompanyId.Value);

            // Delete
            DB.Open();
            DB.BeginTransaction();
            try
            {
                ProjectRevenue projectRevenue = new ProjectRevenue();
                projectRevenue.DeleteDirect(projectId, refId, companyId);

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