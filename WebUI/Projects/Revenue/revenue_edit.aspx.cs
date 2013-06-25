using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.BL.Projects.Revenue;
using LiquiForce.LFSLive.DA.RAF;
using LiquiForce.LFSLive.DA.Projects.Revenue;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.Tools;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.Projects.Revenue
{
    /// <summary>
    /// revenue_edit
    /// </summary>
    public partial class revenue_edit : System.Web.UI.Page
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
                if (!(Convert.ToBoolean(Session["sgLFS_PROJECTS_REVENUE_VIEW"]) && Convert.ToBoolean(Session["sgLFS_PROJECTS_REVENUE_EDIT"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["project_id"] == null) || ((string)Request.QueryString["ref_id"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in revenue_edit.aspx");
                }

                // Tag Page
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfCurrentProjectId.Value = Request.QueryString["project_id"];
                hdfCurrentRefId.Value = Request.QueryString["ref_id"];

                // Prepare initial data                
                // ... for title
                int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
                int projectId = Int32.Parse(hdfCurrentProjectId.Value);
                int refId = Int32.Parse(hdfCurrentRefId.Value);

                // If coming from 
                // ... revenue_navigator2.aspx, revenue_add.aspx
                if ((Request.QueryString["source_page"] == "revenue_navigator2.aspx") || (Request.QueryString["source_page"] == "revenue_add.aspx"))
                {
                    StoreNavigatorState();
                    ViewState["update"] = "no";
                    
                    revenueInformationTDS = new RevenueInformationTDS();

                    RevenueInformationBasicInformation revenueInformationBasicInformationForEdit = new RevenueInformationBasicInformation(revenueInformationTDS);
                    revenueInformationBasicInformationForEdit.LoadByProjectIdRefId(projectId, refId, companyId);                  

                    // ... Store dataset
                    Session["revenueInformationTDS"] = revenueInformationTDS;
                }

                // ... revenue_summary.aspx or revenue_edit
                if ((Request.QueryString["source_page"] == "revenue_summary.aspx") || (Request.QueryString["source_page"] == "revenue_edit.aspx") )
                {
                    StoreNavigatorState();
                    ViewState["update"] = Request.QueryString["update"];

                    // ... Restore dataset
                    revenueInformationTDS = (RevenueInformationTDS)Session["revenueInformationTDS"];                                      

                    if (ViewState["update"].ToString().Trim() == "yes")
                    {
                        RevenueInformationBasicInformation revenueInformationBasicInformationForEdit = new RevenueInformationBasicInformation(revenueInformationTDS);
                        revenueInformationBasicInformationForEdit.LoadByProjectIdRefId(projectId, refId, companyId);                  

                        // ... Store dataset
                        Session["revenueInformationTDS"] = revenueInformationTDS;
                    }
                }
                
                // Prepare initial data
                // ... Data for current revenue
                LoadData();               

                // Databind
                Page.DataBind();
            }
            else
            {
                // Restore datasets
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
            string url = "";

            switch (e.Item.Value)
            {
                case "mSave":
                    this.Save();
                    break;

                case "mApply":
                    this.Apply();
                    break;

                case "mCancel":                    
                    if (Request.QueryString["source_page"] == "revenue_navigator2.aspx")
                    {
                        url = "./revenue_navigator2.aspx?source_page=revenue_edit.aspx" + GetNavigatorState() + "&update=yes";
                    }                    
                    else
                    {
                        if (Request.QueryString["source_page"] == "revenue_summary.aspx")
                        {
                            url = "./revenue_summary.aspx?source_page=revenue_edit.aspx&project_id=" + hdfCurrentProjectId.Value + GetNavigatorState() + "&update=yes" + "&ref_id=" + hdfCurrentRefId.Value;
                        }
                    }
                    break;

                case "mPrevious":
                    // Get previous record
                    int previousProjectId = RevenueNavigator.GetPreviousProjectId((RevenueNavigatorTDS)Session["revenueNavigatorTDS"], Int32.Parse(hdfCurrentProjectId.Value), Int32.Parse(hdfCurrentRefId.Value));
                    int previousRefId = RevenueNavigator.GetPreviousRefId((RevenueNavigatorTDS)Session["revenueNavigatorTDS"], Int32.Parse(hdfCurrentProjectId.Value), Int32.Parse(hdfCurrentRefId.Value));
                    
                    // Redirect
                    url = "./revenue_edit.aspx?source_page=" + Request.QueryString["source_page"] + "&project_id=" + previousProjectId.ToString() + "&ref_id=" + previousRefId.ToString() + GetNavigatorState() + "&update=yes";                    
                    break;

                case "mNext":
                    // Get next record
                    int nextProjectId = RevenueNavigator.GetNextProjectId((RevenueNavigatorTDS)Session["revenueNavigatorTDS"], Int32.Parse(hdfCurrentProjectId.Value), Int32.Parse(hdfCurrentRefId.Value));
                    int nextRefId = RevenueNavigator.GetNextRefId((RevenueNavigatorTDS)Session["revenueNavigatorTDS"], Int32.Parse(hdfCurrentProjectId.Value), Int32.Parse(hdfCurrentRefId.Value));

                    // Redirect
                    url = "./revenue_edit.aspx?source_page=" + Request.QueryString["source_page"] + "&project_id=" + nextProjectId.ToString() + "&ref_id=" + nextRefId.ToString() + GetNavigatorState() + "&update=yes";

                    break;
            }

            if (url != "") Response.Redirect(url);
        }



        protected void tkrpbLeftMenu_ItemClick(object sender, RadPanelBarEventArgs e)
        {
            string url = "";

            switch (e.Item.Value)
            {
                case "mSearch":
                    url = "./revenue_navigator.aspx?source_page=lm";
                    break;
            }

            if (url != "") Response.Redirect(url);
        }





        
        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        private void RegisterClientScripts()
        {
            // Publishing body's OnKeyDown event 
            HtmlGenericControl bodyUnload = (HtmlGenericControl)Page.Master.FindControl("myBody");
            bodyUnload.Attributes.Add("OnKeyDown", "OnKeyDown(event);");

            // Register content variables
            string contentVariables = "";
            contentVariables += "var tkrmTopId = '" + tkrmTop.ClientID + "';"; 
            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./revenue_edit.js");
        }



        private void StoreNavigatorState()
        {
            ViewState["navigatorState"] = "&search_country_id=" + Request.QueryString["search_country_id"] + "&search_client=" + Request.QueryString["search_client"] + "&search_project=" + Request.QueryString["search_project"] + "&search_sort_by=" + Request.QueryString["search_sort_by"] + "&search_start_date=" + Request.QueryString["search_start_date"] + "&search_end_date=" + Request.QueryString["search_end_date"];
        }



        private string GetNavigatorState()
        {
            return (string)ViewState["navigatorState"];
        }



        #region Load Functions

        private void LoadData()
        {
            // Get ids
            int projectId = int.Parse(hdfCurrentProjectId.Value);
            int refId = int.Parse(hdfCurrentRefId.Value);

            // Load data
            LoadBasicData(projectId, refId);
        }



        private void LoadBasicData(int projectId, int refId)
        {
            // Load Data
            RevenueInformationBasicInformationGateway revenueInformationBasicInformationGateway = new RevenueInformationBasicInformationGateway(revenueInformationTDS);
            if (revenueInformationBasicInformationGateway.Table.Rows.Count > 0)
            {
                // Load basic data
                tbxClient.Text = revenueInformationBasicInformationGateway.GetClient(projectId, refId);
                tbxProject.Text = revenueInformationBasicInformationGateway.GetProject(projectId, refId);
                tkrdpDate.SelectedDate = revenueInformationBasicInformationGateway.GetDate(projectId, refId);
                tbxRevenue.Text = decimal.Round(revenueInformationBasicInformationGateway.GetRevenue(projectId, refId), 2).ToString();
                tbxComments.Text = revenueInformationBasicInformationGateway.GetComment(projectId, refId);

                string money = "";

                // Load the money
                if (revenueInformationBasicInformationGateway.GetCountryId(projectId, refId) == 1) // Canada
                {
                    lblRevenue.Text = "Revenue (CAD)";
                    money = " (CAD)";
                }
                else
                {
                    lblRevenue.Text = "Revenue (USD)";
                    money = " (USD)";
                }

                lblTitleRevenue.Text = "Revenue: " + tbxRevenue.Text + money + " (" + revenueInformationBasicInformationGateway.GetDate(projectId, refId).ToShortDateString() + ")";
            }
        }

        #endregion



        private void Save()
        {
            Page.Validate();
            if (Page.IsValid)
            {                                                                    
                // Save data
                int companyId = Int32.Parse(hdfCompanyId.Value);
                int projectId = Int32.Parse(hdfCurrentProjectId.Value);
                int refId = Int32.Parse(hdfCurrentRefId.Value);

                // ... Get basic revenue data
                DateTime newDate = (DateTime)tkrdpDate.SelectedDate;
                decimal newRevenue =  decimal.Round(decimal.Parse(tbxRevenue.Text.Trim()),2);
                string newComment = tbxComments.Text.Trim();
               
                // Update basic information data
                RevenueInformationBasicInformation revenueInformationBasicInformation = new RevenueInformationBasicInformation(revenueInformationTDS);
                revenueInformationBasicInformation.Update(projectId, refId, newDate, newRevenue, newComment);

                // Store datasets
                Session["revenueInformationTDS"] = revenueInformationTDS;
                
                // Update database
                UpdateDatabase();

                ViewState["update"] = "yes";

                // Redirect
                string url = "";
                if (Request.QueryString["source_page"] == "revenue_navigator2.aspx" )
                {
                    url = "./revenue_navigator2.aspx?source_page=revenue_edit.aspx&project_id=" + "&ref_id=" + refId + hdfCurrentProjectId.Value + GetNavigatorState() + "&update=yes";
                }

                if (Request.QueryString["source_page"] == "revenue_summary.aspx")
                {
                    url = "./revenue_summary.aspx?source_page=revenue_edit.aspx&project_id=" + hdfCurrentProjectId.Value + "&ref_id=" + refId + GetNavigatorState() + "&update=yes";
                }

                Response.Redirect(url);
            }
        }



        private void Apply()
        {
            Page.Validate();
            if (Page.IsValid)
            {
                // Save data
                int companyId = Int32.Parse(hdfCompanyId.Value);
                int projectId = Int32.Parse(hdfCurrentProjectId.Value);
                int refId = Int32.Parse(hdfCurrentRefId.Value);

                // ... Get basic revenue data
                DateTime newDate = (DateTime)tkrdpDate.SelectedDate;
                decimal newRevenue = decimal.Round(decimal.Parse(tbxRevenue.Text.Trim()), 2);
                string newComment = tbxComments.Text.Trim();
               
                // Update service data
                RevenueInformationBasicInformation revenueInformationBasicInformation = new RevenueInformationBasicInformation(revenueInformationTDS);
                revenueInformationBasicInformation.Update(projectId, refId, newDate, newRevenue, newComment);

                // Store datasets
                Session["revenueInformationTDS"] = revenueInformationTDS;
                
                // Update database
                UpdateDatabase();

                ViewState["update"] = "yes";
            }
        }



        private void UpdateDatabase()
        {
            int companyId = Int32.Parse(hdfCompanyId.Value);            

            DB.Open();
            DB.BeginTransaction();
            try
            {
                // Save revenue information
                RevenueInformationBasicInformation revenueInformationBasicInformation = new RevenueInformationBasicInformation(revenueInformationTDS);
                revenueInformationBasicInformation.Save(companyId);
           
                DB.CommitTransaction();

                // Store datasets
                revenueInformationTDS.AcceptChanges();
                Session["revenueInformationTDS"] = revenueInformationTDS;
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