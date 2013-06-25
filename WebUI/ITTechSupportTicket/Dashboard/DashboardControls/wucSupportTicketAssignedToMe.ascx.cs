using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.BL.ITTechSupportTicket.Dashboard;
using LiquiForce.LFSLive.DA.ITTechSupportTicket.Dashboard;
using LiquiForce.LFSLive.DA.Resources.Employees;

namespace LiquiForce.LFSLive.WebUI.ITTechSupportTicket.Dashboard.DashboardControls
{
    /// <summary>
    /// wucSupportTicketAssignedToMe
    /// </summary>
    public partial class wucSupportTicketAssignedToMe : System.Web.UI.UserControl
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected DashboardTDS dashboardSupportTicketAssignedToMeTDS;
        protected DashboardTDS.DashboardSupportTicketAssignedToMeDataTable dashboardSupportTicketAssignedToMeDataTable;
        protected DashboardTDS.DashboardSupportTicketAssignedToMeOnHoldDataTable dashboardSupportTicketAssignedToMeOnHoldDataTable;






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
                if (!(Convert.ToBoolean(Session["sgLFS_ITTST_SUPPORTTICKET_ADMIN"])))
                {
                    if (!(Convert.ToBoolean(Session["sgLFS_ITTST_SUPPORTTICKET_VIEW"]) && Convert.ToBoolean(Session["sgLFS_ITTST_SUPPORTTICKET_EDIT"])))
                    {
                        Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                    }
                }

                // Validate query string
                if ((string)Request.QueryString["source_page"] == null)
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in wucSupportTicketAssignedToMe.ascx");
                }

                // Tag page
                hdfCompanyId.Value = Session["companyID"].ToString();

                // Prepare initial data
                HttpContext.Current.Session.Remove("dashboardSupportTicketAssignedToMeDataTableDummy");
                HttpContext.Current.Session.Remove("dashboardSupportTicketAssignedToMeOnHoldDataTableDummy");
                ArrayList arrayListWidgetData = (ArrayList)HttpContext.Current.Session["mySupportTicketAssignedToMeWidget"];
                ArrayList arrayListWidgetDataOnHold = (ArrayList)HttpContext.Current.Session["mySupportTicketAssignedToMeOnHoldWidget"];

                // If coming from 
                // ... Out
                if (Request.QueryString["source_page"] == "out")
                {
                    int loginId = Convert.ToInt32(Session["loginID"]);
                    EmployeeGateway employeeGateway = new EmployeeGateway(new DataSet());
                    int employeeId = employeeGateway.GetEmployeIdByLoginId(loginId);

                    // ... For Grid
                    int companyId = Int32.Parse(hdfCompanyId.Value);

                    dashboardSupportTicketAssignedToMeTDS = new DashboardTDS();
                    DashboardSupportTicketAssignedToMe model = new DashboardSupportTicketAssignedToMe(dashboardSupportTicketAssignedToMeTDS);
                    DashboardSupportTicketAssignedToMeOnHold modelOnHold = new DashboardSupportTicketAssignedToMeOnHold(dashboardSupportTicketAssignedToMeTDS);

                    // ... Load support ticket
                    model.LoadCurrentSupportTicketAssignedToMeByEmployeeId(employeeId, companyId);
                    modelOnHold.LoadSupportTicketAssignedToMeOnHoldByEmployeeId(employeeId, companyId);

                    // ... Store datasets
                    HttpContext.Current.Session.Add("dashboardSupportTicketAssignedToMeTDS", dashboardSupportTicketAssignedToMeTDS);
                }
            }
            else
            {
                // Prepare initial data
                HttpContext.Current.Session.Remove("dashboardSupportTicketAssignedToMeDataTableDummy");
                HttpContext.Current.Session.Remove("dashboardSupportTicketAssignedToMeOnHoldDataTableDummy");

                // Restore dataset
                dashboardSupportTicketAssignedToMeTDS = (DashboardTDS)HttpContext.Current.Session["dashboardSupportTicketAssignedToMeTDS"];
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATION EVENTS
        //

        protected void lkbtnViewNavigator_Click(object sender, EventArgs e)
        {
            string url = "";
            url = "./../../ITTechSupportTicket/SupportTicket/supportTicket_navigator.aspx?source_page=out";
            if (url != "") Response.Redirect(url);
        }



        public string GetUrl(object str)
        {
            int supportTicketId = Int32.Parse(str.ToString());

            string url = "./../../SupportTicket/supportTicket_summary.aspx?source_page=wucMySupportTicket.ascx&dashboard=True&supportTicket_id=" + supportTicketId + GetNavigatorState();
            return url;
        }






        // ////////////////////////////////////////////////////////////////////////
        // AUXILIAR EVENTS
        //

        protected void grdSupportTicketAssignedToMe_DataBound(object sender, EventArgs e)
        {
            ItemsMyToDoEmptyFix(grdSupportTicketAssignedToMe);

            if (!IsPostBack)
            {
                if (HttpContext.Current.Session["mySupportTicketAssignedToMeWidget"] != null)
                {
                    ArrayList arrayListWidgetData = (ArrayList)HttpContext.Current.Session["mySupportTicketAssignedToMeWidget"];
                    int pageIndex = Convert.ToInt32(arrayListWidgetData[0].ToString());

                    if (grdSupportTicketAssignedToMe.PageCount > pageIndex)
                    {
                        grdSupportTicketAssignedToMe.PageIndex = pageIndex;
                    }
                    else
                    {
                        grdSupportTicketAssignedToMe.PageIndex = grdSupportTicketAssignedToMe.PageCount - 1;
                    }
                }
            }
        }



        protected void grdSupportTicketAssignedToMeOnHold_DataBound(object sender, EventArgs e)
        {
            ItemsMyToDoOnHoldEmptyFix(grdSupportTicketAssignedToMeOnHold);

            if (!IsPostBack)
            {
                if (HttpContext.Current.Session["mySupportTicketAssignedToMeOnHoldWidget"] != null)
                {
                    ArrayList arrayListOnHoldWidgetData = (ArrayList)HttpContext.Current.Session["mySupportTicketAssignedToMeOnHoldWidget"];
                    int pageIndex = Convert.ToInt32(arrayListOnHoldWidgetData[0].ToString());

                    if (grdSupportTicketAssignedToMeOnHold.PageCount > pageIndex)
                    {
                        grdSupportTicketAssignedToMeOnHold.PageIndex = pageIndex;
                    }
                    else
                    {
                        grdSupportTicketAssignedToMeOnHold.PageIndex = grdSupportTicketAssignedToMeOnHold.PageCount - 1;
                    }
                }
            }
        }



        protected void grdSupportTicketAssignedToMe_PageIndexChanged(object sender, EventArgs e)
        {
            StoreWidgetsState();
        }



        protected void grdSupportTicketAssignedToMeOnHold_PageIndexChanged(object sender, EventArgs e)
        {
            StoreOnHoldWidgetsState();
        }






        // ////////////////////////////////////////////////////////////////////////
        // METHODS
        //

        private void StoreOnHoldWidgetsState()
        {
            ArrayList arrayListOnHoldWidgetData = new ArrayList();
            arrayListOnHoldWidgetData.Insert(0, grdSupportTicketAssignedToMeOnHold.PageIndex);

            HttpContext.Current.Session.Add("mySupportTicketAssignedToMeOnHoldWidget", arrayListOnHoldWidgetData);
        }



        private void StoreWidgetsState()
        {
            ArrayList arrayListWidgetData = new ArrayList();
            arrayListWidgetData.Insert(0, grdSupportTicketAssignedToMe.PageIndex);

            HttpContext.Current.Session.Add("mySupportTicketAssignedToMeWidget", arrayListWidgetData);
        }




        private void RegisterClientScripts()
        {
            // Register client-side code
            Page.ClientScript.RegisterClientScriptInclude("clientSideCode", "./dashboard.js");
        }



        public DashboardTDS.DashboardSupportTicketAssignedToMeDataTable GetDetails()
        {
            dashboardSupportTicketAssignedToMeDataTable = (DashboardTDS.DashboardSupportTicketAssignedToMeDataTable)HttpContext.Current.Session["dashboardSupportTicketAssignedToMeDataTableDummy"];

            if (dashboardSupportTicketAssignedToMeDataTable == null)
            {
                dashboardSupportTicketAssignedToMeDataTable = ((DashboardTDS)HttpContext.Current.Session["dashboardSupportTicketAssignedToMeTDS"]).DashboardSupportTicketAssignedToMe;
            }

            return dashboardSupportTicketAssignedToMeDataTable;
        }



        public DashboardTDS.DashboardSupportTicketAssignedToMeOnHoldDataTable GetDetailsOnHold()
        {
            dashboardSupportTicketAssignedToMeOnHoldDataTable = (DashboardTDS.DashboardSupportTicketAssignedToMeOnHoldDataTable)HttpContext.Current.Session["dashboardSupportTicketAssignedToMeOnHoldDataTableDummy"];

            if (dashboardSupportTicketAssignedToMeOnHoldDataTable == null)
            {
                dashboardSupportTicketAssignedToMeOnHoldDataTable = ((DashboardTDS)HttpContext.Current.Session["dashboardSupportTicketAssignedToMeTDS"]).DashboardSupportTicketAssignedToMeOnHold;
            }

            return dashboardSupportTicketAssignedToMeOnHoldDataTable;
        }



        protected void ItemsMyToDoEmptyFix(GridView grdView)
        {
            if (grdSupportTicketAssignedToMe.Rows.Count == 0)
            {
                DashboardTDS.DashboardSupportTicketAssignedToMeDataTable dt = new DashboardTDS.DashboardSupportTicketAssignedToMeDataTable();
                dt.AddDashboardSupportTicketAssignedToMeRow(0, 0, "", false, "", "", "");
                Session["dashboardSupportTicketAssignedToMeDataTableDummy"] = dt;

                grdSupportTicketAssignedToMe.DataBind();
            }

            // Normally executes at all postbacks
            if (grdSupportTicketAssignedToMe.Rows.Count == 1)
            {
                DashboardTDS.DashboardSupportTicketAssignedToMeDataTable dt = (DashboardTDS.DashboardSupportTicketAssignedToMeDataTable)Session["dashboardSupportTicketAssignedToMeDataTableDummy"];
                if (dt != null)
                {
                    // Hide row
                    grdSupportTicketAssignedToMe.Rows[0].Visible = false;
                    grdSupportTicketAssignedToMe.Rows[0].Controls.Clear();
                }
            }
        }



        protected void ItemsMyToDoOnHoldEmptyFix(GridView grdView)
        {
            if (grdSupportTicketAssignedToMeOnHold.Rows.Count == 0)
            {
                DashboardTDS.DashboardSupportTicketAssignedToMeOnHoldDataTable dt = new DashboardTDS.DashboardSupportTicketAssignedToMeOnHoldDataTable();
                dt.AddDashboardSupportTicketAssignedToMeOnHoldRow(0, 0, "", false, "", "", "");
                Session["dashboardSupportTicketAssignedToMeOnHoldDataTableDummy"] = dt;

                grdSupportTicketAssignedToMeOnHold.DataBind();
            }

            // Normally executes at all postbacks
            if (grdSupportTicketAssignedToMeOnHold.Rows.Count == 1)
            {
                DashboardTDS.DashboardSupportTicketAssignedToMeOnHoldDataTable dt = (DashboardTDS.DashboardSupportTicketAssignedToMeOnHoldDataTable)Session["dashboardSupportTicketAssignedToMeOnHoldDataTableDummy"];
                if (dt != null)
                {
                    // Hide row
                    grdSupportTicketAssignedToMeOnHold.Rows[0].Visible = false;
                    grdSupportTicketAssignedToMeOnHold.Rows[0].Controls.Clear();
                }
            }
        }



        private string GetNavigatorState()
        {
            // Search and sort
            string searchOptions = "";
            searchOptions = searchOptions + "&search_ddlCondition1=1";
            searchOptions = searchOptions + "&search_tbxCondition1=%";
            searchOptions = searchOptions + "&search_sort_by=1";
            searchOptions = searchOptions + "&search_state=1";

            // Return
            return searchOptions;
        }



    }
}