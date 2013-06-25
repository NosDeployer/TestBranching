using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.LabourHours.SubcontractorHours;
using LiquiForce.LFSLive.BL.LabourHours.SubcontractorHours;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.LabourHours.SubcontractorHours
{
    /// <summary>
    /// subcontractor_hours_delete
    /// </summary>
    public partial class subcontractor_hours_delete : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected SubcontractorHoursInformationTDS subcontractorHoursInformationTDS;






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
                if (!(Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_SUBCONTRACTOR_HOURS_ADMIN"])))
                {
                    // Security check
                    if (!(Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_SUBCONTRACTOR_HOURS_VIEW"]) && Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_SUBCONTRACTOR_HOURS_DELETE"])))
                    {
                        Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                    }

                    // Validate query string
                    if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["project_id"] == null) || ((string)Request.QueryString["ref_id"] == null))
                    {
                        Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in subcontractor_hours_delete.aspx");
                    }
                }

                // Tag page
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfCurrentProjectId.Value = Request.QueryString["project_id"];
                hdfCurrentRefId.Value = Request.QueryString["ref_id"];

                // ... for subcontractor title
                int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
                int currentProjectId = int.Parse(hdfCurrentProjectId.Value);
                int currentRefId = int.Parse(hdfCurrentRefId.Value);

                SubcontractorHoursInformationBasicInformationGateway subcontractorHoursInformationBasicInformationGatewayForTitle = new SubcontractorHoursInformationBasicInformationGateway();
                subcontractorHoursInformationBasicInformationGatewayForTitle.LoadByProjectIdRefId(currentProjectId, currentRefId, companyId);
                lblTitleSubcontractor.Text = "Subcontractor: " + subcontractorHoursInformationBasicInformationGatewayForTitle.GetSubcontractor(currentProjectId, currentRefId);
                
                // If coming from 
                // ... subcontractor_hours_navigator2.aspx
                if (Request.QueryString["source_page"] == "subcontractor_hours_navigator2.aspx")
                {
                    StoreNavigatorState();
                    ViewState["update"] = "no";

                    subcontractorHoursInformationTDS = new SubcontractorHoursInformationTDS();

                    SubcontractorHoursInformationBasicInformationGateway subcontractorHoursInformationBasicInformationGateway = new SubcontractorHoursInformationBasicInformationGateway(subcontractorHoursInformationTDS);
                    subcontractorHoursInformationBasicInformationGateway.LoadByProjectIdRefId(currentProjectId, currentRefId, companyId);
                    
                    // ... Store dataset
                    Session["subcontractorHoursInformationTDS"] = subcontractorHoursInformationTDS;
                }

                // ... subcontractor_hours_summary.aspx
                if (Request.QueryString["source_page"] == "subcontractor_hours_summary.aspx")
                {
                    StoreNavigatorState();
                    ViewState["update"] = Request.QueryString["update"];

                    // Restore dataset
                    subcontractorHoursInformationTDS = (SubcontractorHoursInformationTDS)Session["subcontractorHoursInformationTDS"];
                }               

            }
            else
            {
                // Restore dataset 
                subcontractorHoursInformationTDS = (SubcontractorHoursInformationTDS)Session["subcontractorHoursInformationTDS"];
            }
        }        

                   

        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set active toolbar
            mForm6 master = (mForm6)this.Master;
            master.ActiveToolbar = "LabourHours";
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
                        if (Request.QueryString["source_page"] == "subcontractor_hours_navigator2.aspx")
                        {
                            url = "./subcontractor_hours_navigator2.aspx?source_page=subcontractor_hours_delete.aspx&project_id=" + hdfCurrentProjectId.Value + "&ref_id=" + hdfCurrentRefId.Value + GetNavigatorState() + "&update=yes";
                        }

                        if (Request.QueryString["source_page"] == "subcontractor_hours_summary.aspx")
                        {
                            url = "./subcontractor_hours_summary.aspx?source_page=subcontractor_hours_delete.aspx&project_id=" + hdfCurrentProjectId.Value + "&ref_id=" + hdfCurrentRefId.Value + GetNavigatorState() + "&update=yes" ;
                        }


                        Response.Redirect(url);
                    }
                    break;

                case "mCancel":
                    if (Request.QueryString["source_page"] == "subcontractor_hours_navigator2.aspx")
                    {
                        url = "./subcontractor_hours_navigator2.aspx?source_page=subcontractor_hours_delete.aspx&project_id=" + hdfCurrentProjectId.Value + "&ref_id=" + hdfCurrentRefId.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    }

                    if (Request.QueryString["source_page"] == "subcontractor_hours_summary.aspx")
                    {
                        url = "./subcontractor_hours_summary.aspx?source_page=subcontractor_hours_delete.aspx&project_id=" + hdfCurrentProjectId.Value + "&ref_id=" + hdfCurrentRefId.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
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
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./subcontractor_hours_delete.js");
        }



        private void StoreNavigatorState()
        {
            ViewState["navigatorState"] = "&search_ddlClient=" + Request.QueryString["search_ddlClient"] + "&search_ddlProject=" + Request.QueryString["search_ddlProject"] + "&search_ddlSubcontractor=" + Request.QueryString["search_ddlSubcontractor"] + "&search_sort_by=" + Request.QueryString["search_sort_by"] + "&search_tkrdpStartDate=" + Request.QueryString["search_tkrdpStartDate"] + "&search_tkrdpEndDate=" + Request.QueryString["search_tkrdpEndDate"] + "&search_cbxFilterByDateSelected=" + Request.QueryString["search_cbxFilterByDateSelected"];
        }



        private string GetNavigatorState()
        {
            return (string)ViewState["navigatorState"];
        }



        private void Delete()
        {
            int currentProjectId = int.Parse(hdfCurrentProjectId.Value);
            int currentRefId = int.Parse(hdfCurrentRefId.Value);

            SubcontractorHoursInformationBasicInformation subcontractorHoursInformationBasicInformation = new SubcontractorHoursInformationBasicInformation(subcontractorHoursInformationTDS);
            subcontractorHoursInformationBasicInformation.Delete(currentProjectId, currentRefId);

            // Store datasets
            Session["subcontractorHoursInformationTDS"] = subcontractorHoursInformationTDS;
        }



        private void UpdateDatabase()
        {
            // Get ids
            int companyId = int.Parse(hdfCompanyId.Value);            

            // Delete
            DB.Open();
            DB.BeginTransaction();
            try
            {
                SubcontractorHoursInformationBasicInformation subcontractorHoursInformationBasicInformation = new SubcontractorHoursInformationBasicInformation(subcontractorHoursInformationTDS);
                subcontractorHoursInformationBasicInformation.Save(companyId);              

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