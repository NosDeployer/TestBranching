using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.DA.FleetManagement.Services;
using LiquiForce.LFSLive.BL.FleetManagement.Services;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.FleetManagement.Units;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.FleetManagement.Services
{
    /// <summary>
    /// services_delete
    /// </summary>
    public partial class services_delete : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //
        protected ServiceInformationTDS serviceInformationTDS;
        protected ServicesTDS servicesTDS;





                
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
                if (!(Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_SERVICES_VIEW"]) && Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_SERVICES_DELETE"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["service_id"] == null) || ((string)Request.QueryString["dashboard"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in services_delete.aspx");
                }

                // Tag Page
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfServiceId.Value = Request.QueryString["service_id"].ToString();
                hdfDashboard.Value = Request.QueryString["dashboard"].ToString();
                hdfFmType.Value = "Services";

                // If comming from 
                // ... services_navigator2.aspx
                if (Request.QueryString["source_page"] == "services_navigator2.aspx")
                {
                    StoreNavigatorState();
                    ViewState["update"] = "no";

                    serviceInformationTDS = new ServiceInformationTDS();
                    servicesTDS = new ServicesTDS();

                    int serviceId = Int32.Parse(hdfServiceId.Value);
                    int companyId = Int32.Parse(hdfCompanyId.Value);

                    ServiceInformationBasicInformation serviceInformationBasicInformation = new ServiceInformationBasicInformation(serviceInformationTDS);
                    serviceInformationBasicInformation.LoadByServiceId(serviceId, companyId);

                    ServiceInformationServiceCost serviceInformationServiceCostForEdit = new ServiceInformationServiceCost(serviceInformationTDS);
                    serviceInformationServiceCostForEdit.LoadByServiceId(serviceId, companyId);

                    ServiceInformationServiceNote serviceInformationServiceNoteForEdit = new ServiceInformationServiceNote(serviceInformationTDS);
                    serviceInformationServiceNoteForEdit.LoadByServiceId(serviceId, companyId);

                    // Store dataset
                    Session["serviceInformationTDS"] = serviceInformationTDS;
                    Session["servicesTDS"] = servicesTDS;
                }

                // ... services_summary.aspx
                if (Request.QueryString["source_page"] == "services_summary.aspx")
                {
                    StoreNavigatorState();
                    ViewState["update"] = Request.QueryString["update"];

                    // Restore dataset
                    servicesTDS = (ServicesTDS)Session["servicesTDS"];
                    serviceInformationTDS = (ServiceInformationTDS)Session["serviceInformationTDS"];
                }
            }
            else
            {
                // Restore datasets
                servicesTDS = (ServicesTDS)Session["servicesTDS"];
                serviceInformationTDS = (ServiceInformationTDS)Session["serviceInformationTDS"];
            }
        }        



        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set active toolbar
            mForm6 master = (mForm6)this.Master;
            master.ActiveToolbar = "FleetManagement";
        }






        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATION EVENTS
        //

        protected void tkrmTop_ItemClick(object sender, RadMenuEventArgs e)
        {
            switch (e.Item.Value)
            {
                case "mDelete":
                    this.Delete();
                    break;

                case "mCancel":
                    string url = "";
                    if (Request.QueryString["source_page"] == "services_navigator2.aspx")
                    {
                        url = "./services_navigator2.aspx?source_page=services_delete.aspx&service_id=" + hdfServiceId.Value + GetNavigatorState() + "&update=yes";
                    }

                    if (Request.QueryString["source_page"] == "services_summary.aspx")
                    {
                        int activeTab = 0; // load active tab
                        url = "./services_summary.aspx?source_page=services_delete.aspx&dashboard=" + hdfDashboard.Value + "&service_id=" + hdfServiceId.Value + GetNavigatorState() + "&update=yes" + "&active_tab=" + activeTab;
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
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./services_delete.js");
        }



        private void StoreNavigatorState()
        {
            ViewState["navigatorState"] = "&columns_to_display=" + Request.QueryString["columns_to_display"] + "&search_ddlCondition1=" + Request.QueryString["search_ddlCondition1"] + "&search_tbxCondition1=" + Request.QueryString["search_tbxCondition1"] + "&search_ddlView=" + Request.QueryString["search_ddlView"] + "&search_sort_by=" + Request.QueryString["search_sort_by"] + "&search_state=" + Request.QueryString["search_state"] + "&btn_origin=" + Request.QueryString["btn_origin"];
        }



        private string GetNavigatorState()
        {
            return (string)ViewState["navigatorState"];
        }



        private void Delete()
        {
            Page.Validate();

            if (Page.IsValid)
            {
                // Delete all data for service
                int serviceId = Int32.Parse(hdfServiceId.Value);

                ServiceInformationBasicInformation serviceInformationBasicInformation = new ServiceInformationBasicInformation(serviceInformationTDS);
                serviceInformationBasicInformation.Delete(serviceId);

                ServiceInformationServiceCost serviceInformationServiceCostForEdit = new ServiceInformationServiceCost(serviceInformationTDS);
                serviceInformationServiceCostForEdit.DeleteAll(serviceId);

                ServiceInformationServiceNote serviceInformationServiceNoteForEdit = new ServiceInformationServiceNote(serviceInformationTDS);
                serviceInformationServiceNoteForEdit.DeleteAll(serviceId);

                // Update databse
                UpdateDatabase();

                // Store datasets
                Session["serviceInformationTDS"] = serviceInformationTDS;

                // Redirect
                string url = "";

                if (Request.QueryString["dashboard"] == "True")
                {
                    url = "./../../FleetManagement/Dashboard/dashboard_login.aspx?source_page=out";
                }
                else
                {
                    url = "./services_navigator2.aspx?source_page=services_delete.aspx&service_id=" + hdfServiceId.Value + GetNavigatorState() + "&update=yes";
                }
                Response.Redirect(url);
            }
        }



        private void UpdateDatabase()
        {
            // Get ids
            int serviceId = Int32.Parse(hdfServiceId.Value);
            string serviceType = hdfFmType.Value;
            int companyId = Int32.Parse(hdfCompanyId.Value);

            ServiceInformationBasicInformationGateway serviceInformationBasicInformationGatewayForId = new ServiceInformationBasicInformationGateway(serviceInformationTDS);
            int? unitId = serviceInformationBasicInformationGatewayForId.GetUnitID(serviceId);

            UnitsGateway unitsGateway = new UnitsGateway();
            unitsGateway.LoadByUnitId((int)unitId, companyId);
            string unitType = unitsGateway.GetType((int)unitId);

            // Delete
            DB.Open();
            DB.BeginTransaction();
            try
            {
                ServiceInformationBasicInformation serviceInformationBasicInformation = new ServiceInformationBasicInformation(serviceInformationTDS);
                serviceInformationBasicInformation.DeleteDirect(serviceId, unitType, (int)unitId, companyId);

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