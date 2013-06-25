using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.DA.FleetManagement.Dashboard;
using LiquiForce.LFSLive.BL.FleetManagement.Dashboard;
using LiquiForce.LFSLive.DA.Resources.Employees;
using System.Collections;

namespace LiquiForce.LFSLive.WebUI.FleetManagement.Dashboard.DashboardControls
{
    /// <summary>
    /// wucToDoListAssignedToMe
    /// </summar
    public partial class wucToDoListAssignedToMe : System.Web.UI.UserControl
    {        
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected DashboardTDS dashboardToDoListAssignedToMeTDS;
        protected DashboardTDS.DashboardToDoListAssignedToMeDataTable dashboardToDoListAssignedToMeDataTable;
        protected DashboardTDS.DashboardToDoListAssignedToMeOnHoldDataTable dashboardToDoListAssignedToMeOnHoldDataTable;





        
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
                if (!(Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_TODOLIST_VIEW"]) && Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_TODOLIST_EDIT"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if ((string)Request.QueryString["source_page"] == null)
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in wucToDoListAssignedToMe.ascx");
                }

                // Tag page
                hdfCompanyId.Value = Session["companyID"].ToString();

                // Prepare initial data
                HttpContext.Current.Session.Remove("dashboardToDoListAssignedToMeDataTableDummy");
                HttpContext.Current.Session.Remove("dashboardToDoListAssignedToMeOnHoldDataTableDummy");
                ArrayList arrayListWidgetData = (ArrayList)HttpContext.Current.Session["myToDoListAssignedToMeWidget"];
                ArrayList arrayListWidgetDataOnHold = (ArrayList)HttpContext.Current.Session["myToDoListAssignedToMeOnHoldWidget"];

                // If coming from 
                // ... Out
                if (Request.QueryString["source_page"] == "out")
                {
                    int loginId = Convert.ToInt32(Session["loginID"]);
                    EmployeeGateway employeeGateway = new EmployeeGateway(new DataSet());
                    int employeeId = employeeGateway.GetEmployeIdByLoginId(loginId);

                    // ... For Grid
                    int companyId = Int32.Parse(hdfCompanyId.Value);

                    dashboardToDoListAssignedToMeTDS = new DashboardTDS();
                    DashboardToDoListAssignedToMe model = new DashboardToDoListAssignedToMe(dashboardToDoListAssignedToMeTDS);
                    DashboardToDoListAssignedToMeOnHold modelOnHold = new DashboardToDoListAssignedToMeOnHold(dashboardToDoListAssignedToMeTDS);
                    
                    // ... Load to do list
                    model.LoadCurrentToDoListAssignedToMeByEmployeeId(employeeId, companyId);
                    modelOnHold.LoadToDoListAssignedToMeOnHoldByEmployeeId(employeeId, companyId);

                    // ... Store datasets
                    HttpContext.Current.Session.Add("dashboardToDoListAssignedToMeTDS", dashboardToDoListAssignedToMeTDS);
                }
            }
            else
            {
                // Prepare initial data
                HttpContext.Current.Session.Remove("dashboardToDoListAssignedToMeDataTableDummy");
                HttpContext.Current.Session.Remove("dashboardToDoListAssignedToMeOnHoldDataTableDummy");  

                // Restore dataset
                dashboardToDoListAssignedToMeTDS = (DashboardTDS)HttpContext.Current.Session["dashboardToDoListAssignedToMeTDS"];
            }
        }        






        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATION EVENTS
        //

        protected void lkbtnViewNavigator_Click(object sender, EventArgs e)
        {
            string url = "";
            url = "./../../FleetManagement/ToDoList/toDoList_navigator.aspx?source_page=out";            
            if (url != "") Response.Redirect(url);
        }



        public string GetUrl(object str)
        {
            int toDoId = Int32.Parse(str.ToString());

            string url = "./../../ToDolist/toDoList_summary.aspx?source_page=wucToDoListAssignedToMe.ascx&dashboard=True&toDo_id=" + toDoId + GetNavigatorState();
            return url;
        }


       
        
         
       
        // ////////////////////////////////////////////////////////////////////////
        // AUXILIAR EVENTS
        //

        protected void grdToDoListAssignedToMe_DataBound(object sender, EventArgs e)
        {
            ItemsMyToDoEmptyFix(grdToDoListAssignedToMe);

            if (!IsPostBack)
            {
                if (HttpContext.Current.Session["myToDoListAssignedToMeWidget"] != null)
                {
                    ArrayList arrayListWidgetData = (ArrayList)HttpContext.Current.Session["myToDoListAssignedToMeWidget"];
                    int pageIndex = Convert.ToInt32(arrayListWidgetData[0].ToString());

                    if (grdToDoListAssignedToMe.PageCount > pageIndex)
                    {
                        grdToDoListAssignedToMe.PageIndex = pageIndex;
                    }
                    else
                    {
                        grdToDoListAssignedToMe.PageIndex = grdToDoListAssignedToMe.PageCount - 1;
                    }
                }
            }
        }



        protected void grdToDoListAssignedToMeOnHold_DataBound(object sender, EventArgs e)
        {
            ItemsMyToDoOnHoldEmptyFix(grdToDoListAssignedToMeOnHold);

            if (!IsPostBack)
            {
                if (HttpContext.Current.Session["myToDoListAssignedToMeOnHoldWidget"] != null)
                {
                    ArrayList arrayListOnHoldWidgetData = (ArrayList)HttpContext.Current.Session["myToDoListAssignedToMeOnHoldWidget"];
                    int pageIndex = Convert.ToInt32(arrayListOnHoldWidgetData[0].ToString());

                    if (grdToDoListAssignedToMeOnHold.PageCount > pageIndex)
                    {
                        grdToDoListAssignedToMeOnHold.PageIndex = pageIndex;
                    }
                    else
                    {
                        grdToDoListAssignedToMeOnHold.PageIndex = grdToDoListAssignedToMeOnHold.PageCount - 1;
                    }
                }
            }
        }



        protected void grdToDoListAssignedToMe_PageIndexChanged(object sender, EventArgs e)
        {
            StoreWidgetsState();
        }



        protected void grdToDoListAssignedToMeOnHold_PageIndexChanged(object sender, EventArgs e)
        {
            StoreOnHoldWidgetsState();
        }






        // ////////////////////////////////////////////////////////////////////////
        // METHODS
        //

        private void StoreOnHoldWidgetsState()
        {
            ArrayList arrayListOnHoldWidgetData = new ArrayList();
            arrayListOnHoldWidgetData.Insert(0, grdToDoListAssignedToMeOnHold.PageIndex);

            HttpContext.Current.Session.Add("myToDoListAssignedToMeOnHoldWidget", arrayListOnHoldWidgetData);
        }



        private void StoreWidgetsState()
        {
            ArrayList arrayListWidgetData = new ArrayList();
            arrayListWidgetData.Insert(0, grdToDoListAssignedToMe.PageIndex);

            HttpContext.Current.Session.Add("myToDoListAssignedToMeWidget", arrayListWidgetData);
        }




        private void RegisterClientScripts()
        {
            // Register client-side code
            Page.ClientScript.RegisterClientScriptInclude("clientSideCode", "./dashboard.js");
        }


        
        public DashboardTDS.DashboardToDoListAssignedToMeDataTable GetDetails()
        {
            dashboardToDoListAssignedToMeDataTable = (DashboardTDS.DashboardToDoListAssignedToMeDataTable)HttpContext.Current.Session["dashboardToDoListAssignedToMeDataTableDummy"];

            if (dashboardToDoListAssignedToMeDataTable == null)
            {
                dashboardToDoListAssignedToMeDataTable = ((DashboardTDS)HttpContext.Current.Session["dashboardToDoListAssignedToMeTDS"]).DashboardToDoListAssignedToMe;
            }

            return dashboardToDoListAssignedToMeDataTable;
        }



        public DashboardTDS.DashboardToDoListAssignedToMeOnHoldDataTable GetDetailsOnHold()
        {
            dashboardToDoListAssignedToMeOnHoldDataTable = (DashboardTDS.DashboardToDoListAssignedToMeOnHoldDataTable)HttpContext.Current.Session["dashboardToDoListAssignedToMeOnHoldDataTableDummy"];

            if (dashboardToDoListAssignedToMeOnHoldDataTable == null)
            {
                dashboardToDoListAssignedToMeOnHoldDataTable = ((DashboardTDS)HttpContext.Current.Session["dashboardToDoListAssignedToMeTDS"]).DashboardToDoListAssignedToMeOnHold;
            }

            return dashboardToDoListAssignedToMeOnHoldDataTable;
        }



        protected void ItemsMyToDoEmptyFix(GridView grdView)
        {
            if (grdToDoListAssignedToMe.Rows.Count == 0)
            {
                DashboardTDS.DashboardToDoListAssignedToMeDataTable dt = new DashboardTDS.DashboardToDoListAssignedToMeDataTable();
                dt.AddDashboardToDoListAssignedToMeRow(0, 0, "", false, "", "", "");
                Session["dashboardToDoListAssignedToMeDataTableDummy"] = dt;

                grdToDoListAssignedToMe.DataBind();
            }

            // Normally executes at all postbacks
            if (grdToDoListAssignedToMe.Rows.Count == 1)
            {
                DashboardTDS.DashboardToDoListAssignedToMeDataTable dt = (DashboardTDS.DashboardToDoListAssignedToMeDataTable)Session["dashboardToDoListAssignedToMeDataTableDummy"];
                if (dt != null)
                {
                    // Hide row
                    grdToDoListAssignedToMe.Rows[0].Visible = false;
                    grdToDoListAssignedToMe.Rows[0].Controls.Clear();
                }
            }
        }



        protected void ItemsMyToDoOnHoldEmptyFix(GridView grdView)
        {
            if (grdToDoListAssignedToMeOnHold.Rows.Count == 0)
            {
                DashboardTDS.DashboardToDoListAssignedToMeOnHoldDataTable dt = new DashboardTDS.DashboardToDoListAssignedToMeOnHoldDataTable();
                dt.AddDashboardToDoListAssignedToMeOnHoldRow(0, 0, "", false, "", "", "");
                Session["dashboardToDoListAssignedToMeOnHoldDataTableDummy"] = dt;

                grdToDoListAssignedToMeOnHold.DataBind();
            }

            // Normally executes at all postbacks
            if (grdToDoListAssignedToMeOnHold.Rows.Count == 1)
            {
                DashboardTDS.DashboardToDoListAssignedToMeOnHoldDataTable dt = (DashboardTDS.DashboardToDoListAssignedToMeOnHoldDataTable)Session["dashboardToDoListAssignedToMeOnHoldDataTableDummy"];
                if (dt != null)
                {
                    // Hide row
                    grdToDoListAssignedToMeOnHold.Rows[0].Visible = false;
                    grdToDoListAssignedToMeOnHold.Rows[0].Controls.Clear();
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