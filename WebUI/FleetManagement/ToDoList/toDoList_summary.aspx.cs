using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.DA.RAF;
using LiquiForce.LFSLive.DA.FleetManagement.ToDoList;
using LiquiForce.LFSLive.BL.FleetManagement.ToDoList;
using LiquiForce.LFSLive.DA.FleetManagement.Units;
using LiquiForce.LFSLive.DA.Resources.Employees;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.FleetManagement.ToDoList
{
    /// <summary>
    /// toDoList_summary
    /// </summary>
    public partial class toDoList_summary : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected ToDoListInformationTDS toDoListInformationTDS;        
        protected ToDoListInformationTDS.ActivityInformationDataTable activityInformation;
        
        

        
        
                      
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
                if (!(Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_TODOLIST_VIEW"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["toDo_id"] == null) || ((string)Request.QueryString["dashboard"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in toDoList_summary.aspx");
                }

                // Tag Page
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfToDoId.Value = Request.QueryString["toDo_id"].ToString();
                hdfDashboard.Value = Request.QueryString["dashboard"].ToString();

                // If coming from 
                int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
                int currentToDoId = Int32.Parse(hdfToDoId.Value.ToString());

                Session.Remove("activityInformationDummy");

                // ... toDoList_navigator2.aspx, todoList_add.aspx, wucMyToDoList.ascx, wucToDoListAssignedToMe.ascx
                if ((Request.QueryString["source_page"] == "toDoList_navigator2.aspx") || (Request.QueryString["source_page"] == "toDoList_add.aspx") || (Request.QueryString["source_page"] == "wucMyToDoList.ascx") || (Request.QueryString["source_page"] == "wucToDoListAssignedToMe.ascx"))
                {
                    StoreNavigatorState();
                    ViewState["update"] = "no";

                    toDoListInformationTDS = new ToDoListInformationTDS();                    
                    activityInformation = new ToDoListInformationTDS.ActivityInformationDataTable();

                    ToDoListInformationBasicInformation toDoListInformationBasicInformation = new ToDoListInformationBasicInformation(toDoListInformationTDS);
                    toDoListInformationBasicInformation.LoadAllByToDoId(currentToDoId, companyId);

                    ToDoListInformationActivityInformation toDoListInformationActivityInformation = new ToDoListInformationActivityInformation(toDoListInformationTDS);
                    toDoListInformationActivityInformation.LoadAllByToDoId(currentToDoId, companyId);
                                     
                    // Store dataset
                    Session["toDoListInformationTDS"] = toDoListInformationTDS;
                    Session["activityInformation"] = activityInformation;
                }

                // ... toDoList_delete.aspx or toDoList_edit.aspx , toDoList_activity.aspx
                if ((Request.QueryString["source_page"] == "toDoList_delete.aspx") || (Request.QueryString["source_page"] == "toDoList_edit.aspx") || (Request.QueryString["source_page"] == "toDoList_activity.aspx"))
                {
                    StoreNavigatorState();
                    ViewState["update"] = Request.QueryString["update"];

                    // Restore dataset
                    toDoListInformationTDS = (ToDoListInformationTDS)Session["toDoListInformationTDS"];
                    activityInformation = (ToDoListInformationTDS.ActivityInformationDataTable)Session["activityInformation"];                    
                }                

                // Prepare initial data
                // ... for subject
                ToDoListInformationBasicInformationGateway toDoListInformationBasicInformationGateway = new ToDoListInformationBasicInformationGateway();
                toDoListInformationBasicInformationGateway.LoadAllByToDoId(currentToDoId, companyId);
                lblTitleSubjectName.Text = " " + toDoListInformationBasicInformationGateway.GetSubject(currentToDoId);

                // ... Data for current to do list               
                LoadToDoListData(currentToDoId, companyId);                
            }
            else
            {
                // Restore datasets
                toDoListInformationTDS = (ToDoListInformationTDS)Session["toDoListInformationTDS"];
                activityInformation = (ToDoListInformationTDS.ActivityInformationDataTable)Session["activityInformation"];
            }
        }



        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set active toolbar
            mForm6 master = (mForm6)this.Master;
            master.ActiveToolbar = "FleetManagement";

            // Validate top menu, if completed no more actions could be done.          
            if (hdfState.Value == "Completed")
            {
                tkrmTop.Items[1].Visible = false;
            }            
        }






        // ////////////////////////////////////////////////////////////////////////
        // AUXILIAR EVENTS
        //    
        
        protected void grdToDoList_DataBound(object sender, EventArgs e)
        {
            AddToDoNewEmptyFix(grdToDoList);
        }



        protected void grdToDoList_RowDataBound(object sender, GridViewRowEventArgs e)
        {          
            // Control normal rows
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Normal) || (e.Row.RowState == (DataControlRowState.Normal | DataControlRowState.Alternate))))
            {               
                // Change label text
                string type_ = ((Label)e.Row.FindControl("lblType")).Text;
                if (type_ == "AssignUser")
                {
                    ((Label)e.Row.FindControl("lblUser")).Text = "Assign To";
                }

                if (type_ == "AddComment")
                {
                    ((Label)e.Row.FindControl("lblUser")).Text = "Comment Added By";
                }

                if (type_ == "CloseToDo")
                {
                    ((Label)e.Row.FindControl("lblUser")).Text = "To Do Completed By";
                }

                if (type_ == "OnHoldToDo")
                {
                    ((Label)e.Row.FindControl("lblUser")).Text = "On Hold By";
                }
            }
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
                    url = "./toDoList_edit.aspx?source_page=toDoList_summary.aspx&toDo_id=" + hdfToDoId.Value + "&dashboard=" + hdfDashboard.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    break;

                case "mAssign":
                    url = "./toDoList_activity.aspx?source_page=toDoList_summary.aspx&toDo_id=" + hdfToDoId.Value + "&action=Assign To User" + "&dashboard="+ hdfDashboard.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    break;

                case "mComment":
                    url = "./toDoList_activity.aspx?source_page=toDoList_summary.aspx&toDo_id=" + hdfToDoId.Value + "&action=Add Comment" + "&dashboard=" + hdfDashboard.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    break;

                case "mPutOnHold":
                    url = "./toDoList_activity.aspx?source_page=toDoList_summary.aspx&toDo_id=" + hdfToDoId.Value + "&action=Put On Hold" + "&dashboard=" + hdfDashboard.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    break;

                case "mComplete":
                    url = "./toDoList_activity.aspx?source_page=toDoList_summary.aspx&toDo_id=" + hdfToDoId.Value + "&action=Complete" + "&dashboard=" + hdfDashboard.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    break;

                case "mDelete":
                    url = "./toDoList_delete.aspx?source_page=toDoList_summary.aspx&toDo_id=" + hdfToDoId.Value + "&dashboard=no" + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    break;

                case "mLastSearch":
                    if (Request.QueryString["dashboard"] == "True")
                    {
                        url = "./../../FleetManagement/Dashboard/dashboard_login.aspx?source_page=out";
                    }
                    else
                    {
                        if (Request.QueryString["source_page"] == "toDoList_add.aspx")
                        {
                            url = "./toDoList_navigator.aspx?source_page=out";
                        }

                        if (Request.QueryString["source_page"] == "toDoList_navigator2.aspx")
                        {
                            url = "./toDoList_navigator2.aspx?source_page=toDoList_summary.aspx" + GetNavigatorState() + "&update=yes";
                        }
                        
                        if (Request.QueryString["source_page"] == "toDoList_edit.aspx")
                        {
                            url = "./toDoList_navigator2.aspx?source_page=toDoList_summary.aspx" + GetNavigatorState() + "&update=yes";
                        }

                        if (Request.QueryString["source_page"] == "toDoList_activity.aspx")
                        {
                            url = "./toDoList_navigator2.aspx?source_page=toDoList_summary.aspx" + GetNavigatorState() + "&update=yes";
                        }
                    }
                                        
                    break;

                case "mPrevious":
                    if ((Request.QueryString["source_page"] != "toDoList_add.aspx") && (Request.QueryString["source_page"] != "wucMyToDoList.ascx") && (Request.QueryString["source_page"] != "wucToDoListAssignedToMe.ascx"))
                    {
                        if ((ToDoListNavigatorTDS)Session["toDoListNavigatorTDS"] != null)
                        {
                            // Get previous record
                            int previousId = ToDoListNavigator.GetPreviousId((ToDoListNavigatorTDS)Session["toDoListNavigatorTDS"], Int32.Parse(hdfToDoId.Value));
                            if (previousId != Int32.Parse(hdfToDoId.Value))
                            {
                                // Redirect
                                url = "./toDoList_summary.aspx?source_page=toDoList_navigator2.aspx&dashboard=" + hdfDashboard.Value + "&toDo_id=" + previousId.ToString() + GetNavigatorState() + "&update=yes";
                            }
                        }
                    }
                    break;

                case "mNext":
                    if ((Request.QueryString["source_page"] != "toDoList_add.aspx") && (Request.QueryString["source_page"] != "wucMyToDoList.ascx") && (Request.QueryString["source_page"] != "wucToDoListAssignedToMe.ascx"))
                    {
                        if ((ToDoListNavigatorTDS)Session["toDoListNavigatorTDS"] != null)
                        {
                            // Get next record
                            int nextId = ToDoListNavigator.GetNextId((ToDoListNavigatorTDS)Session["toDoListNavigatorTDS"], Int32.Parse(hdfToDoId.Value));
                            if (nextId != Int32.Parse(hdfToDoId.Value))
                            {
                                // Redirect
                                url = "./toDoList_summary.aspx?source_page=toDoList_navigator2.aspx&dashboard=" + hdfDashboard.Value + "&toDo_id=" + nextId.ToString() + GetNavigatorState() + "&update=yes";
                            }
                        }
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
                case "mSearch":
                    url = "./toDoList_navigator.aspx?source_page=lm";
                    break;                
            }

            if (url != "") Response.Redirect(url);
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        private void RegisterClientScripts()
        {
            // Publishing body's OnKeyDown event 
            HtmlGenericControl bodyUnload = (HtmlGenericControl)Page.Master.FindControl("myBody");
            bodyUnload.Attributes.Add("OnKeyDown", "OnKeyDown(event);");

            // Register content variables
            string contentVariables = "";

            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./toDoList_summary.js");
        }



        private void StoreNavigatorState()
        {
            ViewState["navigatorState"] = "&search_ddlCondition1=" + Request.QueryString["search_ddlCondition1"] + "&search_tbxCondition1=" + Request.QueryString["search_tbxCondition1"] + "&search_sort_by=" + Request.QueryString["search_sort_by"] + "&search_state=" + Request.QueryString["search_state"];
        }



        private string GetNavigatorState()
        {
            return (string)ViewState["navigatorState"];
        }

        

        #region Load Functions

        private void LoadToDoListData(int toDoId, int companyId)
        {
            // Load Data
            LoadData(toDoId);
            LoadActivityData(toDoId, companyId);
        }



        private void LoadData(int toDoId)
        {
            ToDoListInformationBasicInformationGateway toDoListInformationBasicInformationGateway = new ToDoListInformationBasicInformationGateway(toDoListInformationTDS);
            if (toDoListInformationBasicInformationGateway.Table.Rows.Count > 0)
            {
                // Load to do Details
                int companyId = Int32.Parse(hdfCompanyId.Value);

                int createdById = toDoListInformationBasicInformationGateway.GetCreatedByID(toDoId);
                EmployeeGateway employeeGateway = new EmployeeGateway();
                employeeGateway.LoadByEmployeeId(createdById);
                tbxCreatedBy.Text = employeeGateway.GetFullName(createdById);

                tbxCreationDate.Text = toDoListInformationBasicInformationGateway.GetCreationDate(toDoId).ToString();
                tbxState.Text = toDoListInformationBasicInformationGateway.GetState(toDoId);

                if (toDoListInformationBasicInformationGateway.GetDueDate(toDoId).HasValue)
                {
                    DateTime dueDateValue = (DateTime)toDoListInformationBasicInformationGateway.GetDueDate(toDoId);
                    tbxDueDate.Text = dueDateValue.Month.ToString() + "/" + dueDateValue.Day.ToString() + "/" + dueDateValue.Year.ToString();
                }
                
                int? unitId = toDoListInformationBasicInformationGateway.GetUnitID(toDoId);                
                tbxUnit.Text = "";
                if (unitId.HasValue)
                {
                    UnitsGateway unitsGateway = new UnitsGateway();
                    unitsGateway.LoadByUnitId((int)unitId, companyId);
                    tbxUnit.Text = unitsGateway.GetUnitCode((int)unitId) + " " + unitsGateway.GetDescription((int)unitId);
                }

                hdfState.Value = toDoListInformationBasicInformationGateway.GetState(toDoId);
            }
        }



        private void LoadActivityData(int toDoId, int companyId)
        {
            ToDoListInformationActivityInformation toDoListInformationActivityInformation = new ToDoListInformationActivityInformation();
            toDoListInformationActivityInformation.LoadAllByToDoId(toDoId, companyId);
            int lastRefId = toDoListInformationActivityInformation.GetLastAssignedUserRefId();

            ToDoListInformationActivityInformationGateway toDoListInformationActivityInformationGateway = new ToDoListInformationActivityInformationGateway(toDoListInformationActivityInformation.Data);
            toDoListInformationActivityInformationGateway.LoadAllByToDoId(toDoId, companyId);
                        
            if (toDoListInformationActivityInformationGateway.Table.Rows.Count > 0)
            {
                // For last assigned user
                tbxAssignedUser.Text = toDoListInformationActivityInformationGateway.GetEmployeeFullName(toDoId, lastRefId);
                hdfAssignedUser.Value = toDoListInformationActivityInformationGateway.GetEmployeeID(toDoId, lastRefId).ToString();
            }
        }



        #endregion
        



        protected void AddToDoNewEmptyFix(GridView grdView)
        {
            if (grdToDoList.Rows.Count == 0)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                ToDoListInformationTDS.ActivityInformationDataTable dt = new ToDoListInformationTDS.ActivityInformationDataTable();
                dt.AddActivityInformationRow(-1, -1, -1, "", DateTime.Now, "", false, companyId, false, "");
                Session["activityInformationDummy"] = dt;
                grdToDoList.DataBind();
            }

            // normally executes at all postbacks
            if (grdToDoList.Rows.Count == 1)
            {
                ToDoListInformationTDS.ActivityInformationDataTable dt = (ToDoListInformationTDS.ActivityInformationDataTable)Session["activityInformationDummy"];
                if (dt != null)
                {
                    grdToDoList.Rows[0].Visible = false;
                    grdToDoList.Rows[0].Controls.Clear();

                    Session.Remove("activityInformationDummy");
                }
            }
        }          
             
                   
                
        public ToDoListInformationTDS.ActivityInformationDataTable GetToDoNew()
        {
            activityInformation = (ToDoListInformationTDS.ActivityInformationDataTable)Session["activityInformationDummy"];

            if (activityInformation == null)
            {
                activityInformation = ((ToDoListInformationTDS)Session["toDoListInformationTDS"]).ActivityInformation;
            }

            return activityInformation;
        }



    }
}