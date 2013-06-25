using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.BL.FleetManagement.Dashboard;
using LiquiForce.LFSLive.DA.FleetManagement.Dashboard;
using LiquiForce.LFSLive.DA.Resources.Employees;

namespace LiquiForce.LFSLive.WebUI.FleetManagement.Dashboard.DashboardControls
{
    /// <summary>
    /// wucMyToDoList
    /// </summar
    public partial class wucMyToDoList : System.Web.UI.UserControl
    {        
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected DashboardTDS dashboardMyToDoListTDS;
        protected DashboardTDS.DashboardMyToDoListDataTable dashboardMyToDoListDataTable;
        protected DashboardTDS.DashboardMyToDoListOnHoldDataTable dashboardMyToDoListOnHoldDataTable;





        
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
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in wucMyToDoList.ascx");
                }

                // Tag page
                hdfCompanyId.Value = Session["companyID"].ToString();

                // Prepare initial data
                HttpContext.Current.Session.Remove("dashboardMyToDoListDataTableDummy");
                HttpContext.Current.Session.Remove("dashboardMyToDoListOnHoldDataTableDummy");
                ArrayList arrayListWidgetData = (ArrayList)HttpContext.Current.Session["myToDoListWidget"];
                ArrayList arrayListWidgetDataOnHold = (ArrayList)HttpContext.Current.Session["myToDoListOnHoldWidget"];

                // If coming from 
                // ... Out
                if (Request.QueryString["source_page"] == "out")
                {
                    int loginId = Convert.ToInt32(Session["loginID"]);
                    EmployeeGateway employeeGateway = new EmployeeGateway(new DataSet());
                    int employeeId = employeeGateway.GetEmployeIdByLoginId(loginId);
                    string state = "%"; if (ddlStateMyToDo.SelectedValue != "(All)") state = ddlStateMyToDo.SelectedValue;

                    // ... For Grid
                    int companyId = Int32.Parse(hdfCompanyId.Value);

                    dashboardMyToDoListTDS = new DashboardTDS();
                    DashboardMyToDoList model = new DashboardMyToDoList(dashboardMyToDoListTDS);
                    DashboardMyToDoListOnHold modelOnHold = new DashboardMyToDoListOnHold(dashboardMyToDoListTDS);

                    if (HttpContext.Current.Session["myToDoListWidget"] != null)
                    {
                        ddlStateMyToDo.SelectedIndex = Convert.ToInt32(arrayListWidgetData[1].ToString());
                        if (ddlStateMyToDo.SelectedValue != "(All)") state = ddlStateMyToDo.SelectedValue;
                    }
                    
                    // ... Load to do list
                    // ... ...Load for admin
                    if (!Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_TODOLIST_ADMIN"]))
                    {
                        // ... Load for assigned employee 
                        model.LoadMyCurrentToDoListByCreatedByIdState(employeeId, state, companyId);
                        modelOnHold.LoadMyCurrentToDoListOnHoldByCreatedById(employeeId, companyId);
                    }
                    else
                    {
                        // ... ... Loads all  (current)
                        model.LoadCurrentToDoListByState(state, companyId);
                        modelOnHold.LoadCurrentToDoListOnHold(companyId);
                    }

                    // ... Store datasets
                    HttpContext.Current.Session.Add("dashboardMyToDoListTDS", dashboardMyToDoListTDS);
                }
            }
            else
            {
                // Prepare initial data
                HttpContext.Current.Session.Remove("dashboardMyToDoListDataTableDummy");
                HttpContext.Current.Session.Remove("dashboardMyToDoListOnHoldDataTableDummy");  

                // Restore dataset
                dashboardMyToDoListTDS = (DashboardTDS)HttpContext.Current.Session["dashboardMyToDoListTDS"];
            }
        }



        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Initialize links for to do list
            lkbtnAddToDo.Attributes.Add("onclick", string.Format("return LkbtnAddToDoClick();"));
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

            string url = "./../../ToDolist/toDoList_summary.aspx?source_page=wucMyToDoList.ascx&dashboard=True&toDo_id=" + toDoId + GetNavigatorState();
            return url;
        }


       
        
         
       
        // ////////////////////////////////////////////////////////////////////////
        // AUXILIAR EVENTS
        //

        protected void grdMyToDoList_DataBound(object sender, EventArgs e)
        {
            ItemsMyToDoEmptyFix(grdMyToDoList);

            if (!IsPostBack)
            {
                if (HttpContext.Current.Session["myToDoListWidget"] != null)
                {
                    ArrayList arrayListWidgetData = (ArrayList)HttpContext.Current.Session["myToDoListWidget"];
                    int pageIndex = Convert.ToInt32(arrayListWidgetData[0].ToString());

                    if (grdMyToDoList.PageCount > pageIndex)
                    {
                        grdMyToDoList.PageIndex = pageIndex;
                    }
                    else
                    {
                        grdMyToDoList.PageIndex = grdMyToDoList.PageCount - 1;
                    }
                }
            }
        }



        protected void grdMyToDoListOnHold_DataBound(object sender, EventArgs e)
        {
            ItemsMyToDoOnHoldEmptyFix(grdMyToDoListOnHold);

            if (!IsPostBack)
            {
                if (HttpContext.Current.Session["myToDoListOnHoldWidget"] != null)
                {
                    ArrayList arrayListOnHoldWidgetData = (ArrayList)HttpContext.Current.Session["myToDoListOnHoldWidget"];
                    int pageIndex = Convert.ToInt32(arrayListOnHoldWidgetData[0].ToString());

                    if (grdMyToDoListOnHold.PageCount > pageIndex)
                    {
                        grdMyToDoListOnHold.PageIndex = pageIndex;
                    }
                    else
                    {
                        grdMyToDoListOnHold.PageIndex = grdMyToDoListOnHold.PageCount - 1;
                    }
                }
            }
        }



        protected void grdMyToDoList_PageIndexChanged(object sender, EventArgs e)
        {
            StoreWidgetsState();
        }



        protected void grdMyToDoListOnHold_PageIndexChanged(object sender, EventArgs e)
        {
            StoreOnHoldWidgetsState();
        }






        // ////////////////////////////////////////////////////////////////////////
        // METHODS
        //

        private void StoreOnHoldWidgetsState()
        {
            ArrayList arrayListOnHoldWidgetData = new ArrayList();
            arrayListOnHoldWidgetData.Insert(0, grdMyToDoListOnHold.PageIndex);

            HttpContext.Current.Session.Add("myToDoListOnHoldWidget", arrayListOnHoldWidgetData);
        }



        private void StoreWidgetsState()
        {
            ArrayList arrayListWidgetData = new ArrayList();
            arrayListWidgetData.Insert(0, grdMyToDoList.PageIndex);
            arrayListWidgetData.Insert(1, ddlStateMyToDo.SelectedIndex);

            HttpContext.Current.Session.Add("myToDoListWidget", arrayListWidgetData);
        }



        private void StoreWidgetsStateByDdl()
        {
            ArrayList arrayListWidgetData = new ArrayList();
            arrayListWidgetData.Insert(0, 0);
            arrayListWidgetData.Insert(1, ddlStateMyToDo.SelectedIndex);

            HttpContext.Current.Session.Add("myToDoListWidget", arrayListWidgetData);
        }


        
        private void RegisterClientScripts()
        {
            // Register client-side code
            Page.ClientScript.RegisterClientScriptInclude("clientSideCode", "./dashboard.js");
        }


        
        public DashboardTDS.DashboardMyToDoListDataTable GetDetails()
        {
            dashboardMyToDoListDataTable = (DashboardTDS.DashboardMyToDoListDataTable)HttpContext.Current.Session["dashboardMyToDoListDataTableDummy"];

            if (dashboardMyToDoListDataTable == null)
            {
                dashboardMyToDoListDataTable = ((DashboardTDS)HttpContext.Current.Session["dashboardMyToDoListTDS"]).DashboardMyToDoList;
            }

            return dashboardMyToDoListDataTable;
        }



        public DashboardTDS.DashboardMyToDoListOnHoldDataTable GetDetailsOnHold()
        {
            dashboardMyToDoListOnHoldDataTable = (DashboardTDS.DashboardMyToDoListOnHoldDataTable)HttpContext.Current.Session["dashboardMyToDoListOnHoldDataTableDummy"];

            if (dashboardMyToDoListOnHoldDataTable == null)
            {
                dashboardMyToDoListOnHoldDataTable = ((DashboardTDS)HttpContext.Current.Session["dashboardMyToDoListTDS"]).DashboardMyToDoListOnHold;
            }

            return dashboardMyToDoListOnHoldDataTable;
        }



        protected void ItemsMyToDoEmptyFix(GridView grdView)
        {
            if (grdMyToDoList.Rows.Count == 0)
            {
                DashboardTDS.DashboardMyToDoListDataTable dt = new DashboardTDS.DashboardMyToDoListDataTable();
                dt.AddDashboardMyToDoListRow(0, "", false, "", "", "");
                Session["dashboardMyToDoListDataTableDummy"] = dt;

                grdMyToDoList.DataBind();
            }

            // Normally executes at all postbacks
            if (grdMyToDoList.Rows.Count == 1)
            {
                DashboardTDS.DashboardMyToDoListDataTable dt = (DashboardTDS.DashboardMyToDoListDataTable)Session["dashboardMyToDoListDataTableDummy"];
                if (dt != null)
                {
                    // Hide row
                    grdMyToDoList.Rows[0].Visible = false;
                    grdMyToDoList.Rows[0].Controls.Clear();
                }
            }
        }



        protected void ItemsMyToDoOnHoldEmptyFix(GridView grdView)
        {
            if (grdMyToDoListOnHold.Rows.Count == 0)
            {
                DashboardTDS.DashboardMyToDoListOnHoldDataTable dt = new DashboardTDS.DashboardMyToDoListOnHoldDataTable();
                dt.AddDashboardMyToDoListOnHoldRow(0, "", false, "", "", "");
                Session["dashboardMyToDoListOnHoldDataTableDummy"] = dt;

                grdMyToDoListOnHold.DataBind();
            }

            // Normally executes at all postbacks
            if (grdMyToDoListOnHold.Rows.Count == 1)
            {
                DashboardTDS.DashboardMyToDoListOnHoldDataTable dt = (DashboardTDS.DashboardMyToDoListOnHoldDataTable)Session["dashboardMyToDoListOnHoldDataTableDummy"];
                if (dt != null)
                {
                    // Hide row
                    grdMyToDoListOnHold.Rows[0].Visible = false;
                    grdMyToDoListOnHold.Rows[0].Controls.Clear();
                }
            }
        }



        protected void ddlStateMyToDo_SelectedIndexChanged(object sender, EventArgs e)
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
            dashboardMyToDoListTDS = new DashboardTDS();
            DashboardMyToDoList model = new DashboardMyToDoList(dashboardMyToDoListTDS);
            DashboardMyToDoListOnHold modelOnHold = new DashboardMyToDoListOnHold(dashboardMyToDoListTDS);

            EmployeeGateway employeeGateway = new EmployeeGateway(new DataSet());

            int companyId = Int32.Parse(hdfCompanyId.Value);
            int loginId = Convert.ToInt32(Session["loginID"]);
            int employeeId = employeeGateway.GetEmployeIdByLoginId(loginId);
            string state = "%"; if (ddlStateMyToDo.SelectedValue != "(All)") state = ddlStateMyToDo.SelectedValue;
            
            // ... Load to do list
            // ... ...Load for admin
            if (!Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_TODOLIST_ADMIN"]))
            {
                if (state == "New & In Progress")
                {
                    model.LoadMyNewAndInProgressToDoListByCreated(employeeId, companyId);
                }
                else
                {
                    // ... ... Load for assigned employee 
                    model.LoadMyCurrentToDoListByCreatedByIdState(employeeId, state, companyId);
                }

                modelOnHold.LoadMyCurrentToDoListOnHoldByCreatedById(employeeId, companyId);
            }
            else
            {
                if (state == "New & In Progress")
                {
                    model.LoadNewAndInProgressToDoList(companyId);
                }
                else
                {
                    // ... ... Loads all (current)
                    model.LoadCurrentToDoListByState(state, companyId);
                }

                modelOnHold.LoadCurrentToDoListOnHold(companyId);
            }

            HttpContext.Current.Session.Add("dashboardMyToDoListTDS", dashboardMyToDoListTDS);

            Page.DataBind();
        }
            
                

    }
}