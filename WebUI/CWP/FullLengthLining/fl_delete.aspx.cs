using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Resources.Companies;
using LiquiForce.LFSLive.DA.CWP.FullLengthLining;
using LiquiForce.LFSLive.BL.CWP.FullLengthLining;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.DA.CWP.Works;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.CWP.FullLengthLining
{
    /// <summary>
    /// fl_delete
    /// </summary>
    public partial class fl_delete : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected FullLengthLiningTDS fullLengthLiningTDS;
        





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
                if (!(Convert.ToBoolean(Session["sgLFS_CWP_FULLLENGTHLINING_VIEW"]) && Convert.ToBoolean(Session["sgLFS_CWP_FULLLENGTHLINING_DELETE"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["client_id"] == null) || ((string)Request.QueryString["project_id"] == null) || ((string)Request.QueryString["asset_id"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in fl_delete.aspx");
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
                if (name.Length > 23) name = name.Substring(0, 20) + "...";
                lblTitleProjectName.Text = " > Project: " + name + " (" + projectGateway.GetProjectNumber(currentProjectId) + ") > Selected Section";

                // If coming from 
                // ... fl_navigator2.aspx
                if (Request.QueryString["source_page"] == "fl_navigator2.aspx")
                {
                    StoreNavigatorState();
                    ViewState["update"] = "no";

                    fullLengthLiningTDS = new FullLengthLiningTDS();
                    
                    int workId = Int32.Parse(hdfWorkId.Value);
                    int assetId = Int32.Parse(hdfAssetId.Value);
                    
                    FullLengthLiningSectionDetails fullLengthLiningSectionDetails = new FullLengthLiningSectionDetails(fullLengthLiningTDS);
                    fullLengthLiningSectionDetails.LoadByWorkId(workId, companyId);

                    FullLengthLiningWorkDetails fullLengthLiningWorkDetails = new FullLengthLiningWorkDetails(fullLengthLiningTDS);
                    fullLengthLiningWorkDetails.LoadByWorkIdAssetId(workId, assetId, companyId);

                    FullLengthLiningLateralDetails fullLengthLiningLateralDetails = new FullLengthLiningLateralDetails(fullLengthLiningTDS);
                    fullLengthLiningLateralDetails.LoadAllByWorkId(workId, companyId);

                    // Store dataset
                    Session["fullLengthLiningTDS"] = fullLengthLiningTDS;
                }

                // ... fl_summary.aspx
                if (Request.QueryString["source_page"] == "fl_summary.aspx")
                {
                    StoreNavigatorState();
                    ViewState["update"] = Request.QueryString["update"];

                    // Restore dataset
                    fullLengthLiningTDS = (FullLengthLiningTDS)Session["fullLengthLiningTDS"];
                }
            }
            else
            {
                // Restore datasets
                fullLengthLiningTDS = (FullLengthLiningTDS)Session["fullLengthLiningTDS"];
            }
        }

        
        
        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set active toolbar
            mForm6 master = (mForm6)this.Master;
            master.ActiveToolbar = "eSewers";
        }






        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATION EVENTS
        //

        protected void btnChange_Click(object sender, EventArgs e)
        {
            Response.Redirect("./../Common/select_project.aspx?source_page=jl_edit.aspx&work_type=" + hdfWorkType.Value);
        }



        protected void tkrmTop_ItemClick(object sender, RadMenuEventArgs e)
        {
            switch (e.Item.Value)
            {
                case "mDelete":
                    this.Delete();
                    break;

                case "mCancel":
                    string url = "";
                    if (Request.QueryString["source_page"] == "fl_navigator2.aspx")
                    {
                        url = "./fl_navigator2.aspx?source_page=fl_delete.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + GetNavigatorState() + "&update=yes";
                    }

                    if (Request.QueryString["source_page"] == "fl_summary.aspx")
                    {
                        int activeTab = 0; // load active tab
                        url = "./fl_summary.aspx?source_page=fl_delete.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + GetNavigatorState() + "&update=yes" + "&asset_id=" + hdfAssetId.Value + "&active_tab=" + activeTab;
                    }
                    Response.Redirect(url);
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
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./fl_delete.js");
        }



        private void StoreNavigatorState()
        {
            ViewState["navigatorState"] = "&columns_to_display=" + Request.QueryString["columns_to_display"] + "&columns_to_display2=" + Request.QueryString["columns_to_display2"] + "&search_ddlCondition1=" + Request.QueryString["search_ddlCondition1"] + "&search_ddlCondition2=" + Request.QueryString["search_ddlCondition2"] + "&search_tbxCondition1=" + Request.QueryString["search_tbxCondition1"] + "&search_tbxCondition2=" + Request.QueryString["search_tbxCondition2"] + "&search_ddlOperator1=" + Request.QueryString["search_ddlOperator1"] + "&search_ddlOperator2=" + Request.QueryString["search_ddlOperator2"] + "&search_ddlView=" + Request.QueryString["search_ddlView"] + "&search_sort_by=" + Request.QueryString["search_sort_by"] + "&search_sub_area=" + Request.QueryString["search_sub_area"] + "&btn_origin=" + Request.QueryString["btn_origin"];
        }



        private string GetNavigatorState()
        {
            return (string)ViewState["navigatorState"];
        }



        private void TagPage()
        {
            hdfCompanyId.Value = Session["companyID"].ToString();
            hdfCurrentProjectId.Value = Request.QueryString["project_id"].ToString();
            hdfCurrentClientId.Value = Request.QueryString["client_id"].ToString();
            hdfWorkType.Value = "Full Length Lining";
            hdfAssetId.Value = Request.QueryString["asset_id"].ToString();

            // Get workId
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int assetId = Int32.Parse(hdfAssetId.Value);
            string workType = hdfWorkType.Value;
            int projectId = Int32.Parse(hdfCurrentProjectId.Value);

            WorkGateway workGateway = new WorkGateway();
            workGateway.LoadByProjectIdAssetIdWorkType(projectId, assetId, workType, companyId);
            hdfWorkId.Value = workGateway.GetWorkId(assetId, workType, projectId).ToString();
        }



        private void Delete()
        {
            Page.Validate();

            if (Page.IsValid)
            {
                // Delete full length lining
                int workId = Int32.Parse(hdfWorkId.Value);
                FullLengthLiningSectionDetails fullLengthLiningSectionDetails = new FullLengthLiningSectionDetails(fullLengthLiningTDS);
                fullLengthLiningSectionDetails.Delete(workId);

                FullLengthLiningLateralDetails fullLengthLiningLateralDetails = new FullLengthLiningLateralDetails(fullLengthLiningTDS);
                fullLengthLiningLateralDetails.DeleteAll(workId);

                FullLengthLiningWorkDetails fullLengthLiningWorkDetails = new FullLengthLiningWorkDetails(fullLengthLiningTDS);
                fullLengthLiningWorkDetails.Delete(workId);
                
                // Update databse
                UpdateDatabase();

                // Store datasets
                Session["fullLengthLiningTDS"] = fullLengthLiningTDS;

                // Redirect
                string url = "";
                url = "./fl_navigator2.aspx?source_page=fl_delete.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + GetNavigatorState() + "&update=yes";
                Response.Redirect(url);
            }
        }



        private void UpdateDatabase()
        {
            // Get ids
            int workId = Int32.Parse(hdfWorkId.Value);
            int assetId = Int32.Parse(hdfAssetId.Value);
            int companyId = Int32.Parse(hdfCompanyId.Value);

            // Delete
            DB.Open();
            DB.BeginTransaction();
            try
            {
                FullLengthLiningWorkDetails fullLengthLiningWorkDetails = new FullLengthLiningWorkDetails(fullLengthLiningTDS);
                fullLengthLiningWorkDetails.DeleteDirect(workId, assetId, companyId);

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