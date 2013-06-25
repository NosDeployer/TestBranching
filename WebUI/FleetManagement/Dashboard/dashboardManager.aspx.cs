using System;
using System.Web.UI;

namespace LiquiForce.LFSLive.WebUI.FleetManagement.Dashboard
{
    /// <summary>
    /// dashboardManager
    /// </summary>
    public partial class dashboardManager : System.Web.UI.Page
    {
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
                if (!(Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_SERVICES_VIEW"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if ((string)Request.QueryString["source_page"] == null)
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in dashboard.aspx");
                }
            }
        }

 
       
        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set active toolbar
            mForm4 master = (mForm4)this.Master;
            master.ActiveToolbar = "FleetManagement";

            // Disable close option for all webPartZones
            //this.wpzAlarms.CloseVerb.Visible = false;
            this.wpzSRUnassigned.CloseVerb.Visible = false;
            this.wpzAboutToExpireItems.CloseVerb.Visible = false;
            this.wpzExpiredItems.CloseVerb.Visible = false;
            this.wpzMyServiceRequest.CloseVerb.Visible = false;
            this.wpzSRInProgress.CloseVerb.Visible = false;

            // Store active tab for postback
            Session["activeTabUnits"] = "0";
            Session["dialogOpenedUnits"] = "0";
        }






        // ////////////////////////////////////////////////////////////////////////
        // METHODS
        //

        private void RegisterClientScripts()
        {
            // Register content variables
            string contentVariables = "";

            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            Page.ClientScript.RegisterClientScriptInclude("clientSideCode", "./dashboard.js");
        }



    }
}