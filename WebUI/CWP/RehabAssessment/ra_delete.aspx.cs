using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Resources.Companies;
using LiquiForce.LFSLive.DA.CWP.RehabAssessment;
using LiquiForce.LFSLive.BL.CWP.RehabAssessment;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.DA.CWP.Works;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.CWP.RehabAssessment
{
    /// <summary>
    /// ra_delete
    /// </summary>
    public partial class ra_delete : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected RehabAssessmentTDS rehabAssessmentTDS;






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
                if (!(Convert.ToBoolean(Session["sgLFS_CWP_REHABASSESSMENT_VIEW"]) && Convert.ToBoolean(Session["sgLFS_CWP_REHABASSESSMENT_DELETE"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["client_id"] == null) || ((string)Request.QueryString["project_id"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in ra_delete.aspx");
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
                lblTitleProjectName.Text = " > Project: " + name + " (" + projectGateway.GetProjectNumber(currentProjectId) + ") > Selected Sections";
                
                // If coming from 
                // ... ra_navigator2.aspx
                if (Request.QueryString["source_page"] == "ra_navigator2.aspx")
                {
                    StoreNavigatorState();
                    ViewState["update"] = "no";

                    rehabAssessmentTDS = new RehabAssessmentTDS();

                    int workId = Int32.Parse(hdfWorkId.Value);                    

                    RehabAssessmentSectionDetails rehabAssessmentSectionDetails = new RehabAssessmentSectionDetails(rehabAssessmentTDS);
                    rehabAssessmentSectionDetails.LoadByWorkId(workId, companyId);

                    RehabAssessmentWorkDetails rehabAssessmentWorkDetails = new RehabAssessmentWorkDetails(rehabAssessmentTDS);
                    rehabAssessmentWorkDetails.LoadByWorkId(workId, companyId);

                    RehabAssessmentLateralDetails rehabAssessmentLateralDetails = new RehabAssessmentLateralDetails(rehabAssessmentTDS);
                    rehabAssessmentLateralDetails.LoadAllByWorkId(workId, companyId);
                    
                    // Store dataset
                    Session["rehabAssessmentTDS"] = rehabAssessmentTDS;
                }

                // ... ra_summary.aspx
                if (Request.QueryString["source_page"] == "ra_summary.aspx")
                {
                    StoreNavigatorState();
                    ViewState["update"] = Request.QueryString["update"];

                    // Restore dataset
                    rehabAssessmentTDS = (RehabAssessmentTDS)Session["rehabAssessmentTDS"];
                }                
            }
            else
            {
                // Restore datasets
                rehabAssessmentTDS = (RehabAssessmentTDS)Session["rehabAssessmentTDS"];
            }
        }
               
        

        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set active toolbar
            mForm6 master = (mForm6)this.Master;
            master.ActiveToolbar = "eSewers";

            // ... For Works
            WorkGateway workGateway = new WorkGateway();

            if (workGateway.ExistsProjectIdAssetIdWorkTypeCompanyId(int.Parse(hdfAssetId.Value), int.Parse(hdfCurrentProjectId.Value), "Full Length Lining", int.Parse(hdfCompanyId.Value)))
            {
                rbtnDeleteAll.Visible = true;
                rbtnDeleteRaOnly.Visible = true;
                lblDeleteDeleteAll.Visible = true;
                lblDeleteDeleteRaOnly.Visible = false;
            }
            else
            {
                rbtnDeleteAll.Visible = false;
                rbtnDeleteRaOnly.Visible = false;
                lblDeleteDeleteAll.Visible = false;
                lblDeleteDeleteRaOnly.Visible = true;
            }            
        }


        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATION EVENTS
        //

        protected void btnChange_Click(object sender, EventArgs e)
        {
            Response.Redirect("./../Common/select_project.aspx?source_page=ra_delete.aspx&work_type=Rehab Assessment");
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
                    if (Request.QueryString["source_page"] == "ra_navigator2.aspx")
                    {
                        url = "./ra_navigator2.aspx?source_page=ra_delete.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    }

                    if (Request.QueryString["source_page"] == "ra_summary.aspx")
                    {
                        url = "./ra_summary.aspx?source_page=ra_delete.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"] + "&asset_id=" + hdfAssetId.Value + "&active_tab=0";
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
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./ra_delete.js");
        }



        private void StoreNavigatorState()
        {
            ViewState["navigatorState"] = "&columns_to_display=" + Request.QueryString["columns_to_display"] + "&search_ddlCondition1=" + Request.QueryString["search_ddlCondition1"] + "&search_tbxCondition1=" + Request.QueryString["search_tbxCondition1"] + "&search_ddlView=" + Request.QueryString["search_ddlView"] + "&search_sort_by=" + Request.QueryString["search_sort_by"] + "&btn_origin=" + Request.QueryString["btn_origin"];
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
            hdfWorkType.Value = "Rehab Assessment";
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
                // Delete
                int workId = Int32.Parse(hdfWorkId.Value);
                RehabAssessmentSectionDetails rehabAssessmentSectionDetails = new RehabAssessmentSectionDetails(rehabAssessmentTDS);
                rehabAssessmentSectionDetails.Delete(workId);

                RehabAssessmentLateralDetails rehabAssessmentLateralDetails = new RehabAssessmentLateralDetails(rehabAssessmentTDS);
                rehabAssessmentLateralDetails.DeleteAll(workId);

                RehabAssessmentWorkDetails rehabAssessmentWorkDetails = new RehabAssessmentWorkDetails(rehabAssessmentTDS);
                rehabAssessmentWorkDetails.Delete(workId);

                // Update databse
                UpdateDatabase();

                // Store datasets
                Session["rehabAssessmentTDS"] = rehabAssessmentTDS;

                // Redirect
                string url = "";
                url = "./ra_navigator2.aspx?source_page=ra_delete.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + GetNavigatorState() + "&update=yes";
                Response.Redirect(url);            
            }
        }



        private void UpdateDatabase()
        {
            // Get ids
            int workId = Int32.Parse(hdfWorkId.Value);
            int projectId = Int32.Parse(hdfCurrentProjectId.Value);
            int assetId = Int32.Parse(hdfAssetId.Value);
            int companyId = Int32.Parse(hdfCompanyId.Value);

            // Delete
            DB.Open();
            DB.BeginTransaction();
            try
            {
                if ((rbtnDeleteAll.Visible) && (rbtnDeleteAll.Checked))
                {
                    RehabAssessmentWorkDetails rehabAssessmentWorkDetails = new RehabAssessmentWorkDetails(rehabAssessmentTDS);
                    rehabAssessmentWorkDetails.DeleteDirectAll(projectId, assetId, companyId);
                }
                else
                {
                    RehabAssessmentWorkDetails rehabAssessmentWorkDetails = new RehabAssessmentWorkDetails(rehabAssessmentTDS);
                    rehabAssessmentWorkDetails.DeleteDirectRaOnly(workId, assetId, companyId);
                }

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