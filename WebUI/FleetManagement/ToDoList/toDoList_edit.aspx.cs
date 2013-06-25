using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.DA.CWP.Works;
using LiquiForce.LFSLive.DA.FleetManagement.ToDoList;
using LiquiForce.LFSLive.BL.FleetManagement.ToDoList;
using LiquiForce.LFSLive.DA.FleetManagement.Units;
using LiquiForce.LFSLive.DA.Resources.Employees;
using LiquiForce.LFSLive.DA.RAF;
using LiquiForce.LFSLive.Tools;
using LiquiForce.LFSLive.Server;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.FleetManagement.ToDoList
{
    /// <summary>
    /// toDoList_edit
    /// </summary>
    public partial class toDoList_edit : System.Web.UI.Page
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
                if (!(Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_TODOLIST_VIEW"]) && Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_TODOLIST_EDIT"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["toDo_id"] == null) || ((string)Request.QueryString["dashboard"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in toDoList_edit.aspx");
                }

                // Tag Page
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfToDoId.Value = Request.QueryString["toDo_id"].ToString();
                hdfDashboard.Value = Request.QueryString["dashboard"].ToString();

                // If coming from 
                int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
                int currentToDoId = Int32.Parse(hdfToDoId.Value.ToString());

                Session.Remove("activityInformationDummy");

                // ... toDoList_navigator2.aspx, todoList_add.aspx
                if ((Request.QueryString["source_page"] == "toDoList_navigator2.aspx") || (Request.QueryString["source_page"] == "toDoList_add.aspx"))
                {
                    StoreNavigatorState();
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

                // ... toDoList_summary.aspx or toDoList_edit.aspx, toDoList_activity.aspx
                if ((Request.QueryString["source_page"] == "toDoList_summary.aspx") || (Request.QueryString["source_page"] == "toDoList_edit.aspx")  || (Request.QueryString["source_page"] == "toDoList_activity.aspx"))
                {
                    StoreNavigatorState();
                    ViewState["update"] = Request.QueryString["update"];

                    // Restore dataset
                    toDoListInformationTDS = (ToDoListInformationTDS)Session["toDoListInformationTDS"];
                    activityInformation = (ToDoListInformationTDS.ActivityInformationDataTable)Session["activityInformation"];                                       

                    if (ViewState["update"].ToString().Trim() == "yes")
                    {
                        ToDoListInformationBasicInformation toDoListInformationBasicInformation = new ToDoListInformationBasicInformation(toDoListInformationTDS);
                        toDoListInformationBasicInformation.LoadAllByToDoId(currentToDoId, companyId);

                        ToDoListInformationActivityInformation toDoListInformationActivityInformation = new ToDoListInformationActivityInformation(toDoListInformationTDS);
                        toDoListInformationActivityInformation.LoadAllByToDoId(currentToDoId, companyId);

                        // Store dataset
                        Session["toDoListInformationTDS"] = toDoListInformationTDS;
                        Session["activityInformation"] = activityInformation;
                    }            
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
            mForm8 master = (mForm8)this.Master;
            master.ActiveToolbar = "FleetManagement";           
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
                case "mSave":
                    this.Save();
                    break;

                case "mApply":
                    this.Apply();
                    break;

                case "mCancel":
                    toDoListInformationTDS.RejectChanges();
                    
                    if (Request.QueryString["source_page"] == "toDoList_add.aspx")
                    {
                        url = "./toDoList_navigator.aspx?source_page=out";
                    }

                    if ((Request.QueryString["source_page"] == "toDoList_navigator2.aspx") || (Request.QueryString["source_page"] == "toDoList_add.aspx"))
                    {
                        url = "./toDoList_navigator2.aspx?source_page=toDoList_edit.aspx" + GetNavigatorState() + "&update=yes";
                    }

                    if (Request.QueryString["dashboard"] == "True")
                    {
                        url = "./../../FleetManagement/Dashboard/dashboard_login.aspx?source_page=out";
                    }
                    else
                    {
                        if (Request.QueryString["source_page"] == "toDoList_summary.aspx")
                        {
                            url = "./toDoList_summary.aspx?source_page=toDoList_edit.aspx&dashboard=" + hdfDashboard.Value + "&toDo_id=" + hdfToDoId.Value + GetNavigatorState() + "&update=yes";
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
            // Register content variables
            string contentVariables = "";            
            contentVariables += "var tkrmTopId = '" + tkrmTop.ClientID + "';"; 

            // Publishing body's OnKeyDown event 
            HtmlGenericControl bodyUnload = (HtmlGenericControl)Page.Master.FindControl("myBody");
            bodyUnload.Attributes.Add("OnKeyDown", "OnKeyDown(event);");
            
            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./toDoList_edit.js");
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
                    tkrdpDueDate.SelectedDate = (DateTime)toDoListInformationBasicInformationGateway.GetDueDate(toDoId);                    
                }

                int? unitId = toDoListInformationBasicInformationGateway.GetUnitID(toDoId);
                                
                if (unitId.HasValue)
                {
                    ddlUnit.SelectedValue = unitId.ToString();                    
                }
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
            }
        }



        #endregion



        private void Save()
        {                                
            // Save data                
            int toDoId = Int32.Parse(hdfToDoId.Value);
            
            DateTime? newDueDate = null; if (tkrdpDueDate.SelectedDate.HasValue) newDueDate = tkrdpDueDate.SelectedDate;                
            int? newUnitId = null; if (ddlUnit.SelectedValue != "-1") newUnitId = Int32.Parse(ddlUnit.SelectedValue);

            // Insert to dataset
            ToDoListInformationBasicInformation toDoListInformationBasicInformation = new ToDoListInformationBasicInformation(toDoListInformationTDS);
            toDoListInformationBasicInformation.Update(toDoId, newDueDate, newUnitId);

            // Store datasets
            Session["toDoListInformationTDS"] = toDoListInformationTDS;

            // Update database
            UpdateDatabase();

            ViewState["update"] = "yes";

            // Redirect
            string url = "";
            if (Request.QueryString["source_page"] == "toDoList_navigator2.aspx")
            {
                url = "./toDoList_navigator2.aspx?source_page=toDoList_edit.aspx&toDo_id=" + hdfToDoId.Value  + GetNavigatorState() + "&update=yes";
            }

            if (Request.QueryString["source_page"] == "toDoList_summary.aspx")
            {
                url = "./toDoList_summary.aspx?source_page=toDoList_edit.aspx&toDo_id=" + hdfToDoId.Value + "&dashboard=" + hdfDashboard.Value  + GetNavigatorState() + "&update=yes";
            }

            Response.Redirect(url);            
        }



        private void Apply()
        {            
            // Save data                
            int toDoId = Int32.Parse(hdfToDoId.Value);

            DateTime? newDueDate = null; if (tkrdpDueDate.SelectedDate.HasValue) newDueDate = tkrdpDueDate.SelectedDate;
            int? newUnitId = null; if (ddlUnit.SelectedValue != "-1") newUnitId = Int32.Parse(ddlUnit.SelectedValue);

            // Insert to dataset
            ToDoListInformationBasicInformation toDoListInformationBasicInformation = new ToDoListInformationBasicInformation(toDoListInformationTDS);
            toDoListInformationBasicInformation.Update(toDoId, newDueDate, newUnitId);

            // Store datasets
            Session["toDoListInformationTDS"] = toDoListInformationTDS;

            // Update database
            UpdateDatabase();

            ViewState["update"] = "yes";           
        }
                        


        private void UpdateDatabase()
        {
            // Get ids & location
            //string workType = hdfWorkType.Value.Trim();
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int toDoId = Int32.Parse(hdfToDoId.Value);

            DB.Open();
            DB.BeginTransaction();
            try
            {
                // Save toDo details
                ToDoListInformationBasicInformation toDoListInformationBasicInformation = new ToDoListInformationBasicInformation(toDoListInformationTDS);
                toDoListInformationBasicInformation.Save(companyId);

                //// Save work details
                //PointToDoWorkDetails pointToDoWorkDetails = new PointToDoWorkDetails(toDoListInformationTDS);
                //pointToDoWorkDetails.Save(countryId, provinceId, countyId, cityId, projectId, sectionAssetId, companyId);
                
                DB.CommitTransaction();

                // Store datasets
                toDoListInformationTDS.AcceptChanges();
                Session["toDoListInformationTDS"] = toDoListInformationTDS;
            }
            catch (Exception ex)
            {
                DB.RollbackTransaction();

                string url = string.Format("./../../error_page.aspx?error={0}", ex.Message.Replace('\n', ' '));
                Response.Redirect(url);
            }
        }



        protected void AddToDoNewEmptyFix(GridView grdToDoList)
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
                      




                                
        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

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