using System;
using System.Data;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.DA.RAF;
using LiquiForce.LFSLive.DA.Company.Organization;
using LiquiForce.LFSLive.DA.Resources.Employees;
using LiquiForce.LFSLive.DA.FleetManagement.Units;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.DA.LabourHours.SubcontractorHours;
using LiquiForce.LFSLive.BL.LabourHours.SubcontractorHours;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime
{
    /// <summary>
    /// subcontractor_hours_summary
    /// </summary>
    public partial class subcontractor_hours_summary : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // PROPERTIES AND FIELDS
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
                if (!(Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_SUBCONTRACTOR_HOURS_ADMIN"])))
                {
                    // Security check
                    if (!(Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_SUBCONTRACTOR_HOURS_VIEW"]) && Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_SUBCONTRACTOR_HOURS_EDIT"])))                    
                    {
                        Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                    }

                    // Validate query string
                    if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["project_id"] == null) || ((string)Request.QueryString["ref_id"] == null))
                    {
                        Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in subcontractor_hours_summary.aspx");
                    }
                }

                // Initialize viewstate variables
                hdfProjectId.Value = Request.QueryString["project_id"].ToString();
                hdfRefId.Value = Request.QueryString["ref_id"].ToString();
                hdfCompanyId.Value = Session["companyID"].ToString();

                 // If coming from 
                // ... subcontractor_hours_navigator2.aspx
                int refId = Int32.Parse(hdfRefId.Value);
                int projectId = Int32.Parse(hdfProjectId.Value);

                if (Request.QueryString["source_page"] == "subcontractor_hours_navigator2.aspx")
                {
                    StoreNavigatorState();
                    ViewState["update"] = "no";

                    int companyId = Int32.Parse(hdfCompanyId.Value);
                    
                    subcontractorHoursInformationTDS = new SubcontractorHoursInformationTDS();

                    SubcontractorHoursInformationBasicInformationGateway subcontractorHoursInformationBasicInformationGateway = new SubcontractorHoursInformationBasicInformationGateway(subcontractorHoursInformationTDS);
                    subcontractorHoursInformationBasicInformationGateway.LoadByProjectIdRefId(projectId, refId,companyId);
               
                    
                    // ... Store dataset
                    Session["subcontractorHoursInformationTDS"] = subcontractorHoursInformationTDS;
                }

                // ... subcontractor_hours_delete.aspx or subcontractor_hours_edit.aspx 
                if ((Request.QueryString["source_page"] == "subcontractor_hours_delete.aspx") || (Request.QueryString["source_page"] == "subcontractor_hours_edit.aspx"))
                {
                    StoreNavigatorState();
                    ViewState["update"] = Request.QueryString["update"];

                    // Restore dataset
                    subcontractorHoursInformationTDS = (SubcontractorHoursInformationTDS)Session["subcontractorHoursInformationTDS"];                  
                }

                // ... Data for current employee
                LoadData(projectId, refId);   

            }
            else
            {
                // Restore datasets
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
            string url = "";

            switch (e.Item.Value)
            {
                case "mEdit":
                    url = "./subcontractor_hours_edit.aspx?source_page=subcontractor_hours_summary.aspx&project_id=" + hdfProjectId.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"] + "&ref_id=" + hdfRefId.Value;
                    break;

                case "mDelete":
                    url = "./subcontractor_hours_delete.aspx?source_page=subcontractor_hours_summary.aspx&project_id=" + hdfProjectId.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"] + "&ref_id=" + hdfRefId.Value;
                    break;

                case "mLastSearch":
                    url = "./subcontractor_hours_navigator2.aspx?source_page=subcontractor_hours_summary.aspx&project_id=" + hdfProjectId.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    break;

                case "mPrevious":
                    // Get previous record
                    int previousId = SubcontractorHoursNavigator.GetPreviousId((SubcontractorHoursNavigatorTDS)Session["subcontractorHoursNavigatorTDS"], Int32.Parse(hdfRefId.Value));
                    if (previousId != Int32.Parse(hdfRefId.Value))
                    {
                        // Redirect
                        url = "./subcontractor_hours_summary.aspx?source_page=subcontractor_hours_navigator2.aspx&ref_id=" + previousId.ToString() + "&project_id=" + hdfProjectId.Value + GetNavigatorState();
                    }
                    break;

                case "mNext":
                    // Get next record
                    int nextId = SubcontractorHoursNavigator.GetNextId((SubcontractorHoursNavigatorTDS)Session["subcontractorHoursNavigatorTDS"], Int32.Parse(hdfRefId.Value));
                    if (nextId != Int32.Parse(hdfRefId.Value))
                    {
                        // Redirect
                        url = "./subcontractor_hours_summary.aspx?source_page=subcontractor_hours_navigator2.aspx&ref_id=" + nextId.ToString() + "&project_id=" + hdfProjectId.Value + GetNavigatorState();
                    }
                    break;
            }

            if (url != "") Response.Redirect(url);
        }



        protected void tkrpbLeftMenu_ItemClick(object sender, RadPanelBarEventArgs e)
        {
            string url = "";

            switch (e.Item.Value)
            {
                case "mAddHoursBySubcontractor":
                    url = "./../../LabourHours/SubcontractorHours/subcontractor_hours_add_by_subcontractor.aspx?source_page=lm" + GetNavigatorState();
                    Response.Redirect(url);
                    break;

                case "mAddHoursByClientProject":
                    url = "./../../LabourHours/SubcontractorHours/subcontractor_hours_add_by_client_project.aspx?source_page=lm" + GetNavigatorState();
                    Response.Redirect(url);
                    break;

                case "mSearch":
                    url = "./../../LabourHours/SubcontractorHours/subcontractor_hours_navigator.aspx?source_page=out";
                    Response.Redirect(url);
                    break;
            }
        }





        
        // ////////////////////////////////////////////////////////////////////////
        // METHODS
        //

        private void RegisterClientScripts()
        {
            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./subcontractor_hours_summary.js");
        }



        #region Load Functions

        private void LoadData(int projectId, int refId)
        {            
            // Load Data
            SubcontractorHoursInformationBasicInformationGateway subcontractorHoursInformationBasicInformationGateway = new SubcontractorHoursInformationBasicInformationGateway(subcontractorHoursInformationTDS);
            if (subcontractorHoursInformationBasicInformationGateway.Table.Rows.Count > 0)
            {
                // Load subcontractor basic data
                tbxSubcontractor.Text = subcontractorHoursInformationBasicInformationGateway.GetSubcontractor(projectId, refId);
                
                if (subcontractorHoursInformationBasicInformationGateway.GetActive(projectId, refId))
                {
                    tbxState.Text = "Active";
                }
                else
                {
                    tbxState.Text = "Inactive";
                }

                tbxClient.Text =  subcontractorHoursInformationBasicInformationGateway.GetClient(projectId, refId);
                tbxProject.Text = subcontractorHoursInformationBasicInformationGateway.GetProject(projectId, refId);

                DateTime date =  (DateTime)(subcontractorHoursInformationBasicInformationGateway.GetDate(projectId, refId));
                tbxDate.Text = date.Month.ToString() + "/" + date.Day.ToString() + "/" + date.Year.ToString();
                    
                decimal quantity = decimal.Parse(subcontractorHoursInformationBasicInformationGateway.GetQuantity(projectId, refId).ToString());
                tbxQuantity.Text = decimal.Round(quantity,1).ToString();

                if (subcontractorHoursInformationBasicInformationGateway.GetCountryId(projectId, refId) == 1) // Canada
                {
                    decimal rate = decimal.Parse(subcontractorHoursInformationBasicInformationGateway.GetRateCad(projectId, refId).ToString());
                    tbxRate.Text = decimal.Round(rate, 2).ToString();

                    decimal total = decimal.Parse(subcontractorHoursInformationBasicInformationGateway.GetTotalCad(projectId, refId).ToString());
                    tbxTotal.Text = decimal.Round(total, 2).ToString();
                }
                else // Usa
                {
                    decimal rate = decimal.Parse(subcontractorHoursInformationBasicInformationGateway.GetRateUsd(projectId, refId).ToString());
                    tbxRate.Text = decimal.Round(rate,2).ToString();

                    decimal total = decimal.Parse(subcontractorHoursInformationBasicInformationGateway.GetTotalUsd(projectId, refId).ToString());
                    tbxTotal.Text = decimal.Round(total,2).ToString();
                }

                tbxComments.Text =  subcontractorHoursInformationBasicInformationGateway.GetComment(projectId, refId);      
            }        
        }

        #endregion




        private void StoreNavigatorState()
        {
            ViewState["navigatorState"] = "&search_ddlClient=" + Request.QueryString["search_ddlClient"] + "&search_ddlProject=" + Request.QueryString["search_ddlProject"] + "&search_ddlSubcontractor=" + Request.QueryString["search_ddlSubcontractor"] + "&search_sort_by=" + Request.QueryString["search_sort_by"] + "&search_tkrdpStartDate=" + Request.QueryString["search_tkrdpStartDate"] + "&search_tkrdpEndDate=" + Request.QueryString["search_tkrdpEndDate"] + "&search_cbxFilterByDateSelected=" + Request.QueryString["search_cbxFilterByDateSelected"];
        }



        private string GetNavigatorState()
        {
            return (string)ViewState["navigatorState"];
        }



    }
}