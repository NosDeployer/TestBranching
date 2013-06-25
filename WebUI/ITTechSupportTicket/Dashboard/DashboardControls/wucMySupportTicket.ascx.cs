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
    /// wucMySupportTicket
    /// </summary>
    public partial class wucMySupportTicket : System.Web.UI.UserControl
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected DashboardTDS dashboardMySupportTicketTDS;
        protected DashboardTDS.DashboardMySupportTicketDataTable dashboardMySupportTicketDataTable;
        protected DashboardTDS.DashboardMySupportTicketOnHoldDataTable dashboardMySupportTicketOnHoldDataTable;






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
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in wucMySupportTicket.ascx");
                }

                // Tag page
                hdfCompanyId.Value = Session["companyID"].ToString();

                // Prepare initial data
                HttpContext.Current.Session.Remove("dashboardMySupportTicketDataTableDummy");
                HttpContext.Current.Session.Remove("dashboardMySupportTicketOnHoldDataTableDummy");
                ArrayList arrayListWidgetData = (ArrayList)HttpContext.Current.Session["mySupportTicketWidget"];
                ArrayList arrayListWidgetDataOnHold = (ArrayList)HttpContext.Current.Session["mySupportTicketOnHoldWidget"];

                // If coming from 
                // ... Out
                if (Request.QueryString["source_page"] == "out")
                {
                    int loginId = Convert.ToInt32(Session["loginID"]);
                    EmployeeGateway employeeGateway = new EmployeeGateway(new DataSet());
                    int employeeId = employeeGateway.GetEmployeIdByLoginId(loginId);
                    string state = "%"; if (ddlStateMySupportTicket.SelectedValue != "(All)") state = ddlStateMySupportTicket.SelectedValue;

                    // ... For Grid
                    int companyId = Int32.Parse(hdfCompanyId.Value);

                    dashboardMySupportTicketTDS = new DashboardTDS();
                    DashboardMySupportTicket model = new DashboardMySupportTicket(dashboardMySupportTicketTDS);
                    DashboardMySupportTicketOnHold modelOnHold = new DashboardMySupportTicketOnHold(dashboardMySupportTicketTDS);

                    if (HttpContext.Current.Session["mySupportTicketWidget"] != null)
                    {
                        ddlStateMySupportTicket.SelectedIndex = Convert.ToInt32(arrayListWidgetData[1].ToString());
                        if (ddlStateMySupportTicket.SelectedValue != "(All)") state = ddlStateMySupportTicket.SelectedValue;
                    }

                    // ... Load support ticket
                    // ... ...Load for admin
                    if (!Convert.ToBoolean(Session["sgLFS_ITTST_SUPPORTTICKET_ADMIN"]))
                    {
                        // ... Load for assigned employee 
                        model.LoadMyCurrentSupportTicketByCreatedByIdState(employeeId, state, companyId);
                        modelOnHold.LoadMyCurrentSupportTicketOnHoldByCreatedById(employeeId, companyId);
                    }
                    else
                    {
                        // ... ... Loads all  (current)
                        model.LoadCurrentSupportTicketByState(state, companyId);
                        modelOnHold.LoadCurrentSupportTicketOnHold(companyId);
                    }

                    // ... Store datasets
                    HttpContext.Current.Session.Add("dashboardMySupportTicketTDS", dashboardMySupportTicketTDS);
                }
            }
            else
            {
                // Prepare initial data
                HttpContext.Current.Session.Remove("dashboardMySupportTicketDataTableDummy");
                HttpContext.Current.Session.Remove("dashboardMySupportTicketOnHoldDataTableDummy");

                // Restore dataset
                dashboardMySupportTicketTDS = (DashboardTDS)HttpContext.Current.Session["dashboardMySupportTicketTDS"];
            }
        }



        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Initialize links for support ticket
            lkbtnAddSupportTicket.Attributes.Add("onclick", string.Format("return LkbtnAddSupportTicketClick();"));
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

        protected void grdMySupportTicket_DataBound(object sender, EventArgs e)
        {
            ItemsMySupportTicketEmptyFix(grdMySupportTicket);

            if (!IsPostBack)
            {
                if (HttpContext.Current.Session["mySupportTicketWidget"] != null)
                {
                    ArrayList arrayListWidgetData = (ArrayList)HttpContext.Current.Session["mySupportTicketWidget"];
                    int pageIndex = Convert.ToInt32(arrayListWidgetData[0].ToString());

                    if (grdMySupportTicket.PageCount > pageIndex)
                    {
                        grdMySupportTicket.PageIndex = pageIndex;
                    }
                    else
                    {
                        grdMySupportTicket.PageIndex = grdMySupportTicket.PageCount - 1;
                    }
                }
            }
        }



        protected void grdMySupportTicketOnHold_DataBound(object sender, EventArgs e)
        {
            ItemsMySupportTicketOnHoldEmptyFix(grdMySupportTicketOnHold);

            if (!IsPostBack)
            {
                if (HttpContext.Current.Session["mySupportTicketOnHoldWidget"] != null)
                {
                    ArrayList arrayListOnHoldWidgetData = (ArrayList)HttpContext.Current.Session["mySupportTicketOnHoldWidget"];
                    int pageIndex = Convert.ToInt32(arrayListOnHoldWidgetData[0].ToString());

                    if (grdMySupportTicketOnHold.PageCount > pageIndex)
                    {
                        grdMySupportTicketOnHold.PageIndex = pageIndex;
                    }
                    else
                    {
                        grdMySupportTicketOnHold.PageIndex = grdMySupportTicketOnHold.PageCount - 1;
                    }
                }
            }
        }



        protected void grdMySupportTicket_PageIndexChanged(object sender, EventArgs e)
        {
            StoreWidgetsState();
        }



        protected void grdMySupportTicketOnHold_PageIndexChanged(object sender, EventArgs e)
        {
            StoreOnHoldWidgetsState();
        }






        // ////////////////////////////////////////////////////////////////////////
        // METHODS
        //

        private void StoreOnHoldWidgetsState()
        {
            ArrayList arrayListOnHoldWidgetData = new ArrayList();
            arrayListOnHoldWidgetData.Insert(0, grdMySupportTicketOnHold.PageIndex);

            HttpContext.Current.Session.Add("mySupportTicketOnHoldWidget", arrayListOnHoldWidgetData);
        }



        private void StoreWidgetsState()
        {
            ArrayList arrayListWidgetData = new ArrayList();
            arrayListWidgetData.Insert(0, grdMySupportTicket.PageIndex);
            arrayListWidgetData.Insert(1, ddlStateMySupportTicket.SelectedIndex);

            HttpContext.Current.Session.Add("mySupportTicketWidget", arrayListWidgetData);
        }



        private void StoreWidgetsStateByDdl()
        {
            ArrayList arrayListWidgetData = new ArrayList();
            arrayListWidgetData.Insert(0, 0);
            arrayListWidgetData.Insert(1, ddlStateMySupportTicket.SelectedIndex);

            HttpContext.Current.Session.Add("mySupportTicketWidget", arrayListWidgetData);
        }



        private void RegisterClientScripts()
        {
            // Register client-side code
            Page.ClientScript.RegisterClientScriptInclude("clientSideCode", "./dashboard.js");
        }



        public DashboardTDS.DashboardMySupportTicketDataTable GetDetails()
        {
            dashboardMySupportTicketDataTable = (DashboardTDS.DashboardMySupportTicketDataTable)HttpContext.Current.Session["dashboardMySupportTicketDataTableDummy"];

            if (dashboardMySupportTicketDataTable == null)
            {
                dashboardMySupportTicketDataTable = ((DashboardTDS)HttpContext.Current.Session["dashboardMySupportTicketTDS"]).DashboardMySupportTicket;
            }

            return dashboardMySupportTicketDataTable;
        }



        public DashboardTDS.DashboardMySupportTicketOnHoldDataTable GetDetailsOnHold()
        {
            dashboardMySupportTicketOnHoldDataTable = (DashboardTDS.DashboardMySupportTicketOnHoldDataTable)HttpContext.Current.Session["dashboardMySupportTicketOnHoldDataTableDummy"];

            if (dashboardMySupportTicketOnHoldDataTable == null)
            {
                dashboardMySupportTicketOnHoldDataTable = ((DashboardTDS)HttpContext.Current.Session["dashboardMySupportTicketTDS"]).DashboardMySupportTicketOnHold;
            }

            return dashboardMySupportTicketOnHoldDataTable;
        }



        protected void ItemsMySupportTicketEmptyFix(GridView grdView)
        {
            if (grdMySupportTicket.Rows.Count == 0)
            {
                DashboardTDS.DashboardMySupportTicketDataTable dt = new DashboardTDS.DashboardMySupportTicketDataTable();
                dt.AddDashboardMySupportTicketRow(0, "", false, "", "", "");
                Session["dashboardMySupportTicketDataTableDummy"] = dt;

                grdMySupportTicket.DataBind();
            }

            // Normally executes at all postbacks
            if (grdMySupportTicket.Rows.Count == 1)
            {
                DashboardTDS.DashboardMySupportTicketDataTable dt = (DashboardTDS.DashboardMySupportTicketDataTable)Session["dashboardMySupportTicketDataTableDummy"];
                if (dt != null)
                {
                    // Hide row
                    grdMySupportTicket.Rows[0].Visible = false;
                    grdMySupportTicket.Rows[0].Controls.Clear();
                }
            }
        }



        protected void ItemsMySupportTicketOnHoldEmptyFix(GridView grdView)
        {
            if (grdMySupportTicketOnHold.Rows.Count == 0)
            {
                DashboardTDS.DashboardMySupportTicketOnHoldDataTable dt = new DashboardTDS.DashboardMySupportTicketOnHoldDataTable();
                dt.AddDashboardMySupportTicketOnHoldRow(0, "", false, "", "", "");
                Session["dashboardMySupportTicketOnHoldDataTableDummy"] = dt;

                grdMySupportTicketOnHold.DataBind();
            }

            // Normally executes at all postbacks
            if (grdMySupportTicketOnHold.Rows.Count == 1)
            {
                DashboardTDS.DashboardMySupportTicketOnHoldDataTable dt = (DashboardTDS.DashboardMySupportTicketOnHoldDataTable)Session["dashboardMySupportTicketOnHoldDataTableDummy"];
                if (dt != null)
                {
                    // Hide row
                    grdMySupportTicketOnHold.Rows[0].Visible = false;
                    grdMySupportTicketOnHold.Rows[0].Controls.Clear();
                }
            }
        }



        protected void ddlStateMySupportTicket_SelectedIndexChanged(object sender, EventArgs e)
        {
            StoreWidgetsStateByDdl();
            LoadData();
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



        private void LoadData()
        {
            dashboardMySupportTicketTDS = new DashboardTDS();
            DashboardMySupportTicket model = new DashboardMySupportTicket(dashboardMySupportTicketTDS);
            DashboardMySupportTicketOnHold modelOnHold = new DashboardMySupportTicketOnHold(dashboardMySupportTicketTDS);

            EmployeeGateway employeeGateway = new EmployeeGateway(new DataSet());

            int companyId = Int32.Parse(hdfCompanyId.Value);
            int loginId = Convert.ToInt32(Session["loginID"]);
            int employeeId = employeeGateway.GetEmployeIdByLoginId(loginId);
            string state = "%"; if (ddlStateMySupportTicket.SelectedValue != "(All)") state = ddlStateMySupportTicket.SelectedValue;

            // ... Load support ticket
            // ... ...Load for admin
            if (!Convert.ToBoolean(Session["sgLFS_ITTST_SUPPORTTICKET_ADMIN"]))
            {
                if (state == "New & In Progress")
                {
                    model.LoadMyNewAndInProgressSupportTicketByCreated(employeeId, companyId);
                }
                else
                {
                    // ... ... Load for assigned employee 
                    model.LoadMyCurrentSupportTicketByCreatedByIdState(employeeId, state, companyId);
                }

                modelOnHold.LoadMyCurrentSupportTicketOnHoldByCreatedById(employeeId, companyId);
            }
            else
            {
                if (state == "New & In Progress")
                {
                    model.LoadNewAndInProgressSupportTicket(companyId);
                }
                else
                {
                    // ... ... Loads all (current)
                    model.LoadCurrentSupportTicketByState(state, companyId);
                }

                modelOnHold.LoadCurrentSupportTicketOnHold(companyId);
            }

            HttpContext.Current.Session.Add("dashboardMySupportTicketTDS", dashboardMySupportTicketTDS);

            Page.DataBind();
        }



    }
}