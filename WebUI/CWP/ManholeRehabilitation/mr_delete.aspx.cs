using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.BL.CWP.Assets;
using LiquiForce.LFSLive.BL.CWP.ManholeRehabilitation;
using LiquiForce.LFSLive.DA.CWP.ManholeRehabilitation;
using LiquiForce.LFSLive.DA.CWP.Works;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.DA.Resources.Companies;
using LiquiForce.LFSLive.Server;
using Telerik.Web.UI;
using LiquiForce.LFSLive.BL.Assets.Assets;

namespace LiquiForce.LFSLive.WebUI.CWP.ManholeRehabilitation
{
    /// <summary>
    /// mr_delete
    /// </summary>
    public partial class mr_delete : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected ManholeRehabilitationTDS manholeRehabilitationTDS;
        





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
                if (!(Convert.ToBoolean(Session["sgLFS_CWP_MANHOLEREHABILITATION_VIEW"]) && Convert.ToBoolean(Session["sgLFS_CWP_MANHOLEREHABILITATION_DELETE"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["client_id"] == null) || ((string)Request.QueryString["project_id"] == null) || ((string)Request.QueryString["asset_id"] == null) || ((string)Request.QueryString["in_project"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in mr_delete.aspx");
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
                // ... mr_navigator2.aspx
                if (Request.QueryString["source_page"] == "mr_navigator2.aspx")
                {
                    StoreNavigatorState();
                    ViewState["update"] = "no";

                    manholeRehabilitationTDS = new ManholeRehabilitationTDS();
                    
                    int workId = Int32.Parse(hdfWorkId.Value);
                    int assetId = Int32.Parse(hdfAssetId.Value);                    

                    ManholeRehabilitationManholeDetails manholeRehabilitationManholeDetails = new ManholeRehabilitationManholeDetails(manholeRehabilitationTDS);
                    manholeRehabilitationManholeDetails.LoadByAssetId(assetId, companyId);

                    ManholeRehabilitationWorkDetails manholeRehabilitationWorkDetails = new ManholeRehabilitationWorkDetails(manholeRehabilitationTDS);
                    manholeRehabilitationWorkDetails.LoadByWorkIdAssetId(workId, assetId, companyId);

                    // Store dataset
                    Session["manholeRehabilitationTDS"] = manholeRehabilitationTDS;
                }

                // ... mr_summary.aspx
                if (Request.QueryString["source_page"] == "mr_summary.aspx")
                {
                    StoreNavigatorState();
                    ViewState["update"] = Request.QueryString["update"];

                    // Restore dataset
                    manholeRehabilitationTDS = (ManholeRehabilitationTDS)Session["manholeRehabilitationTDS"];
                }
            }
            else
            {
                // Restore datasets
                manholeRehabilitationTDS = (ManholeRehabilitationTDS)Session["manholeRehabilitationTDS"];
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
                    if (Request.QueryString["source_page"] == "mr_navigator2.aspx")
                    {
                        url = "./mr_navigator2.aspx?source_page=mr_delete.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&in_project=" + hdfInProject.Value + GetNavigatorState() + "&update=yes";
                    }

                    if (Request.QueryString["source_page"] == "mr_summary.aspx")
                    {
                        int activeTab = 0; // load active tab
                        url = "./mr_summary.aspx?source_page=mr_delete.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&in_project=" + hdfInProject.Value + GetNavigatorState() + "&update=yes" + "&asset_id=" + hdfAssetId.Value + "&active_tab=" + activeTab;
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
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./mr_delete.js");
        }



        private void StoreNavigatorState()
        {
            ViewState["navigatorState"] = "&columns_to_display=" + Request.QueryString["columns_to_display"] + "&columns_to_display2=" + Request.QueryString["columns_to_display2"] + "&search_ddlCondition1=" + Request.QueryString["search_ddlCondition1"] + "&search_ddlCondition2=" + Request.QueryString["search_ddlCondition2"] + "&search_tbxCondition1=" + Request.QueryString["search_tbxCondition1"] + "&search_tbxCondition2=" + Request.QueryString["search_tbxCondition2"] + "&search_ddlOperator1=" + Request.QueryString["search_ddlOperator1"] + "&search_ddlOperator2=" + Request.QueryString["search_ddlOperator2"] + "&search_ddlView=" + Request.QueryString["search_ddlView"] + "&search_sort_by=" + Request.QueryString["search_sort_by"] + "&btn_origin=" + Request.QueryString["btn_origin"];
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
            hdfWorkType.Value = "Manhole Rehabilitation";
            hdfAssetId.Value = Request.QueryString["asset_id"].ToString();
            hdfInProject.Value = Request.QueryString["in_project"].ToString();

            // Get workId
            bool inProject = bool.Parse(hdfInProject.Value);
            if (inProject)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                int assetId = Int32.Parse(hdfAssetId.Value);
                string workType = hdfWorkType.Value;
                int projectId = Int32.Parse(hdfCurrentProjectId.Value);

                WorkGateway workGateway = new WorkGateway();
                hdfWorkId.Value = "0";

                workGateway.LoadByProjectIdAssetIdWorkType(projectId, assetId, workType, companyId);

                if (workGateway.Table.Rows.Count > 0)
                {
                    hdfWorkId.Value = workGateway.GetWorkId(assetId, workType, projectId).ToString();
                }
            }
        }



        private void Delete()
        {
            Page.Validate();

            if (Page.IsValid)
            {
                // Delete 
                int workId = Int32.Parse(hdfWorkId.Value);
                int companyId = Int32.Parse(hdfCompanyId.Value);
                int assetId = Int32.Parse(hdfAssetId.Value);

                AssetSewerMH assetSewerMh = new AssetSewerMH(null);
                bool usedBySection = assetSewerMh.InUse(assetId, companyId);

                if (usedBySection)
                {
                    lblDelete.Text = "The Manhole could not be deleted, it is used by sections";                    
                }
                else
                {
                    // Update databse
                    UpdateDatabase();

                    // Redirect
                    string url = "";
                    url = "./mr_navigator2.aspx?source_page=mr_delete.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&in_project=" + hdfInProject.Value + GetNavigatorState() + "&update=yes";
                    Response.Redirect(url);
                }
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
                LfsAssetSewerMH lfsAssetSewerMH = new LfsAssetSewerMH();
                lfsAssetSewerMH.DeleteDirect(assetId, companyId); 

                ManholeRehabilitationWorkDetails manholeRehabilitationWorkDetails = new ManholeRehabilitationWorkDetails(manholeRehabilitationTDS);
                manholeRehabilitationWorkDetails.DeleteDirect(workId, companyId);

                DB.CommitTransaction();

                // Store datasets
                Session["manholeRehabilitationTDS"] = manholeRehabilitationTDS;
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