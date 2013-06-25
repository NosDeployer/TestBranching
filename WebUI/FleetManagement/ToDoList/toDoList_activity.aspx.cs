using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.BL.FleetManagement.ToDoList;
using LiquiForce.LFSLive.DA.FleetManagement.ToDoList;
using LiquiForce.LFSLive.DA.FleetManagement.Units;
using LiquiForce.LFSLive.DA.Resources.Employees;
using LiquiForce.LFSLive.Server;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.FleetManagement.ToDoList
{
    /// <summary>
    /// toDoList_activity
    /// </summary>
    public partial class toDoList_activity : System.Web.UI.Page
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
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["toDo_id"] == null) || ((string)Request.QueryString["action"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in toDoList_activity.aspx");
                }

                // Tag Page
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfToDoId.Value = Request.QueryString["toDo_id"].ToString();                
                hdfAction.Value = Request.QueryString["action"].ToString();
                hdfDashboard.Value = Request.QueryString["dashboard"].ToString();

                // If coming from 
                int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
                int currentToDoId = Int32.Parse(hdfToDoId.Value.ToString());

                Session.Remove("activityInformationDummy");

                // ... toDoList_navigator2.aspx
                if (Request.QueryString["source_page"] == "toDoList_navigator2.aspx")
                {
                    StoreNavigatorState();
                    toDoListInformationTDS = new ToDoListInformationTDS();
                    activityInformation = new ToDoListInformationTDS.ActivityInformationDataTable();

                    ToDoListInformationBasicInformation toDoListInformationBasicInformation = new ToDoListInformationBasicInformation(toDoListInformationTDS);
                    toDoListInformationBasicInformation.LoadAllByToDoId(currentToDoId, companyId);

                    ToDoListInformationBasicInformationGateway toDoListInformationBasicInformationGatewayForState = new ToDoListInformationBasicInformationGateway(toDoListInformationBasicInformation.Data);
                    string state = toDoListInformationBasicInformationGatewayForState.GetState(currentToDoId);
                    if (state == "Completed") hdfCompleted.Value = "True";

                    ToDoListInformationActivityInformation toDoListInformationActivityInformation = new ToDoListInformationActivityInformation(toDoListInformationTDS);
                    toDoListInformationActivityInformation.LoadAllByToDoId(currentToDoId, companyId);
                                     
                    // Store dataset
                    Session["toDoListInformationTDS"] = toDoListInformationTDS;
                    Session["activityInformation"] = activityInformation;
                }

                // ... toDoList_summary.aspx or toDoList_edit.aspx 
                if ((Request.QueryString["source_page"] == "toDoList_summary.aspx") || (Request.QueryString["source_page"] == "toDoList_edit.aspx"))
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

                        ToDoListInformationBasicInformationGateway toDoListInformationBasicInformationGatewayForState = new ToDoListInformationBasicInformationGateway(toDoListInformationBasicInformation.Data);
                        string state = toDoListInformationBasicInformationGatewayForState.GetState(currentToDoId);
                        if (state == "Completed") hdfCompleted.Value = "True";

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



        protected void grdToDoList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Repair Gridview, if the gridview is edition mode
            if (grdToDoList.EditIndex >= 0)
            {
                grdToDoList.UpdateRow(grdToDoList.EditIndex, true);
            }

            // Delete repairs
            int toDoId = (int)e.Keys["ToDoID"];
            int refId = (int)e.Keys["RefID"];

            ToDoListInformationActivityInformation model = new ToDoListInformationActivityInformation(toDoListInformationTDS);

            // Delete repair
            model.Delete(toDoId, refId);

            // Store dataset
            Session["toDoListInformationTDS"] = toDoListInformationTDS;
        }



        protected void grdToDoList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Add")
            {
                // Repair Gridview, if the gridview is edition mode
                if (grdToDoList.EditIndex >= 0)
                {
                    grdToDoList.UpdateRow(grdToDoList.EditIndex, true);
                }

                // Add New to do
                GrdToDoAdd();
                mForm8 master = (mForm8)this.Master;
                ScriptManager scriptManager = (ScriptManager)master.FindControl("ScriptManagerMaster8");
                scriptManager.SetFocus(grdToDoList.FooterRow.FindControl("tbxCommentsNew"));
            }
        }



        protected void grdToDoList_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.Validate("activityDataEdit");

            if (Page.IsValid)
            {
                int toDoId = (int)e.Keys["ToDoID"];
                int refId = (int)e.Keys["RefID"];

                int employeeId = 0;
                int loginId = Convert.ToInt32(Session["loginID"]);

                EmployeeGateway employeeGateway = new EmployeeGateway();
                string comment = ((TextBox)grdToDoList.Rows[e.RowIndex].Cells[4].FindControl("tbxCommentsEdit")).Text;
                string employeeFullName = "";

                string type_ = ((Label)grdToDoList.Rows[e.RowIndex].Cells[4].FindControl("lblType")).Text;
                switch (type_)
                {
                    case "AssignUser":
                        employeeId = Int32.Parse(((DropDownList)grdToDoList.Rows[e.RowIndex].Cells[4].FindControl("ddlAssignToTeamMemberEdit")).SelectedValue);
                        employeeGateway.LoadByEmployeeId(employeeId);
                        employeeFullName = employeeGateway.GetFullName(employeeId);
                        break;

                    case "AddComment":
                        employeeId = employeeGateway.GetEmployeIdByLoginId(loginId);
                        EmployeeGateway employeeGatewayForComment = new EmployeeGateway();
                        employeeGatewayForComment.LoadByEmployeeId(employeeId);
                        employeeFullName = employeeGatewayForComment.GetFullName(employeeId);
                        break;

                    case "CloseToDo":
                        employeeId = Int32.Parse(hdfAssignedUser.Value);
                        employeeGateway.LoadByEmployeeId(employeeId);
                        employeeFullName = employeeGateway.GetFullName(employeeId);
                        hdfCompleted.Value = "True";
                        break;

                    case "OnHoldToDo":
                        employeeId = employeeGateway.GetEmployeIdByLoginId(loginId);
                        EmployeeGateway employeeGatewayForOnHold = new EmployeeGateway();
                        employeeGatewayForOnHold.LoadByEmployeeId(employeeId);
                        employeeFullName = employeeGatewayForOnHold.GetFullName(employeeId);
                        break;
                }

                ToDoListInformationActivityInformation model = new ToDoListInformationActivityInformation(toDoListInformationTDS);
                model.Update(toDoId, refId, employeeId, employeeFullName, comment);
           
                // Store dataset
                Session["toDoListInformationTDS"] = toDoListInformationTDS;
            }
            else
            {
                e.Cancel = true;
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

        protected void cvTeamMemberEdit_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            CustomValidator cvTeamMemberEdit = (CustomValidator)source;
            GridViewRow gridRow = (GridViewRow)cvTeamMemberEdit.NamingContainer;

            string employeeId = ((DropDownList)gridRow.FindControl("ddlAssignToTeamMemberEdit")).SelectedValue;

            if (employeeId == "-1")
            {
                args.IsValid = false;
            }

        }



        protected void cvProblemDescriptionEdit_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            CustomValidator cvProblemDescriptionEdit = (CustomValidator)source;
            GridViewRow gridRow = (GridViewRow)cvProblemDescriptionEdit.NamingContainer;

            string action = ((Label)gridRow.FindControl("lblType")).Text;
            string comment = ((TextBox)gridRow.FindControl("tbxCommentsEdit")).Text;

            if (action == "AssignUser")
            {
                args.IsValid = true;
            }
            else
            {
                if (comment == "")
                {
                    args.IsValid = false;
                }
            }
        }



        protected void cvTeamMemberNew_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            string employeeId = ((DropDownList)grdToDoList.FooterRow.FindControl("ddlAssignToTeamMemberNew")).SelectedValue;

            if (employeeId == "-1")
            {
                args.IsValid = false;
            }
        }



        protected void cvProblemDescriptionNew_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            string action = ((DropDownList)grdToDoList.FooterRow.FindControl("ddlActionsNew")).SelectedValue;
            string comment = ((TextBox)grdToDoList.FooterRow.FindControl("tbxCommentsNew")).Text;

            if (action == "Assign To User")
            {
                args.IsValid = true;
            }
            else
            {
                if (comment == "")
                {
                    args.IsValid = false;
                }
            }
        }



        protected void ddlActionsNew_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = grdToDoList.FooterRow;
            DropDownList action = ((DropDownList)row.FindControl("ddlActionsNew"));
            
            switch (action.SelectedValue)
            {
                case "Assign To User":
                    ((DropDownList)row.FindControl("ddlAssignToTeamMemberNew")).Visible = true;
                    ((CustomValidator)row.FindControl("cvTeamMemberNew")).Visible = true;
                    ((TextBox)row.FindControl("tbxUserNew")).Visible = false;
                    ((Label)row.FindControl("lblUserNew")).Text = "Assign To";
                    break;

                case "Add Comment":
                    int loginId = Convert.ToInt32(Session["loginID"]);
                    EmployeeGateway employeeGateway = new EmployeeGateway();
                    int employeeId = employeeGateway.GetEmployeIdByLoginId(loginId);

                    ((DropDownList)row.FindControl("ddlAssignToTeamMemberNew")).Visible = false;
                    ((CustomValidator)row.FindControl("cvTeamMemberNew")).Visible = false;
                    ((TextBox)row.FindControl("tbxUserNew")).Visible = true;
                    ((Label)row.FindControl("lblUserNew")).Text = "Comment Added By";

                    EmployeeGateway employeeGatewayForUser = new EmployeeGateway();
                    employeeGatewayForUser.LoadByEmployeeId(employeeId);
                    ((TextBox)row.FindControl("tbxUserNew")).Text = employeeGatewayForUser.GetFullName(employeeId);
                    break;
                    
                case "Complete":
                    ((DropDownList)row.FindControl("ddlAssignToTeamMemberNew")).Visible = false;
                    ((CustomValidator)row.FindControl("cvTeamMemberNew")).Visible = false;
                    ((TextBox)row.FindControl("tbxUserNew")).Visible = true;
                    ((Label)row.FindControl("lblUserNew")).Text = "To Do Completed By";

                    EmployeeGateway employeeGatewayForUserComplete = new EmployeeGateway();
                    employeeGatewayForUserComplete.LoadByEmployeeId(Int32.Parse(hdfAssignedUser.Value));
                    ((TextBox)row.FindControl("tbxUserNew")).Text = employeeGatewayForUserComplete.GetFullName(Int32.Parse(hdfAssignedUser.Value));
                    break;

                case "Put On Hold":
                    int loginIdOnHold = Convert.ToInt32(Session["loginID"]);
                    EmployeeGateway employeeGatewayOnHold = new EmployeeGateway();
                    int employeeIdOnHold = employeeGatewayOnHold.GetEmployeIdByLoginId(loginIdOnHold);

                    ((DropDownList)row.FindControl("ddlAssignToTeamMemberNew")).Visible = false;
                    ((CustomValidator)row.FindControl("cvTeamMemberNew")).Visible = false;
                    ((TextBox)row.FindControl("tbxUserNew")).Visible = true;
                    ((Label)row.FindControl("lblUserNew")).Text = "On Hold By";

                    EmployeeGateway employeeGatewayForOnHold = new EmployeeGateway();
                    employeeGatewayForOnHold.LoadByEmployeeId(employeeIdOnHold);
                    ((TextBox)row.FindControl("tbxUserNew")).Text = employeeGatewayForOnHold.GetFullName(employeeIdOnHold);
                    break;
            }
        }
        


        protected void grdToDoList_DataBound(object sender, EventArgs e)
        {
            AddToDoNewEmptyFix(grdToDoList);
        }



        protected void grdToDoList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Control of footer row
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                int loginId = Convert.ToInt32(Session["loginID"]);
                EmployeeGateway employeeGateway = new EmployeeGateway();
                int employeeId = employeeGateway.GetEmployeIdByLoginId(loginId);

                // Select action
                DropDownList actions = (DropDownList)e.Row.FindControl("ddlActionsNew");
                actions.SelectedValue = hdfAction.Value;

                // Only the assigned user could close the todo                 
                if (hdfAssignedUser.Value != employeeId.ToString())
                {
                    actions.Items.Remove("Close");
                }
                
                // Make fields visible for actions
                if (hdfAction.Value == "Assign To User")
                {
                    ((DropDownList)e.Row.FindControl("ddlAssignToTeamMemberNew")).Visible = true;
                    ((CustomValidator)e.Row.FindControl("cvTeamMemberNew")).Visible = true;
                    ((TextBox)e.Row.FindControl("tbxUserNew")).Visible = false;
                    ((Label)e.Row.FindControl("lblClosed")).Visible = false;
                    ((Label)e.Row.FindControl("lblUserNew")).Text = "Assign To";
                }

                if (hdfAction.Value == "Add Comment")
                {
                    ((DropDownList)e.Row.FindControl("ddlAssignToTeamMemberNew")).Visible = false;
                    ((CustomValidator)e.Row.FindControl("cvTeamMemberNew")).Visible = false;
                    ((TextBox)e.Row.FindControl("tbxUserNew")).Visible = true;                    

                    EmployeeGateway employeeGatewayForUser = new EmployeeGateway();
                    employeeGatewayForUser.LoadByEmployeeId(employeeId);
                    ((TextBox)e.Row.FindControl("tbxUserNew")).Text = employeeGatewayForUser.GetFullName(employeeId);
                    ((Label)e.Row.FindControl("lblClosed")).Visible = false;
                    ((Label)e.Row.FindControl("lblUserNew")).Text = "Comment Added By";
                }

                if (hdfAction.Value == "Complete")
                {
                    ((DropDownList)e.Row.FindControl("ddlAssignToTeamMemberNew")).Visible = false;
                    ((CustomValidator)e.Row.FindControl("cvTeamMemberNew")).Visible = false;
                    ((TextBox)e.Row.FindControl("tbxUserNew")).Visible = true;

                    EmployeeGateway employeeGatewayForUser = new EmployeeGateway();
                    employeeGatewayForUser.LoadByEmployeeId(Int32.Parse(hdfAssignedUser.Value));
                    ((TextBox)e.Row.FindControl("tbxUserNew")).Text = employeeGatewayForUser.GetFullName(Int32.Parse(hdfAssignedUser.Value));
                    ((Label)e.Row.FindControl("lblClosed")).Visible = false;

                    ((Label)e.Row.FindControl("lblUserNew")).Text = "To Do Completed By";
                }

                if (hdfCompleted.Value == "True")
                {
                    ((DropDownList)e.Row.FindControl("ddlActionsNew")).Visible = false;
                    ((TextBox)e.Row.FindControl("tbxDateTimeNew")).Visible = false;
                    ((DropDownList)e.Row.FindControl("ddlAssignToTeamMemberNew")).Visible = false;
                    ((CustomValidator)e.Row.FindControl("cvTeamMemberNew")).Visible = false;
                    ((TextBox)e.Row.FindControl("tbxUserNew")).Visible = false;
                    ((TextBox)e.Row.FindControl("tbxCommentsNew")).Visible = false;
                    ((Label)e.Row.FindControl("lblActionNew")).Visible = false;
                    ((Label)e.Row.FindControl("lblDateTimeNew")).Visible = false;
                    ((Label)e.Row.FindControl("lblUserNew")).Visible = false;
                    ((Label)e.Row.FindControl("lblCommentsNew")).Visible = false;
                    ((ImageButton)e.Row.FindControl("ibtnAdd")).Visible = false;
                    ((Label)e.Row.FindControl("lblClosed")).Visible = true;                    
                }

                if (hdfAction.Value == "Put On Hold")
                {
                    ((DropDownList)e.Row.FindControl("ddlAssignToTeamMemberNew")).Visible = false;
                    ((CustomValidator)e.Row.FindControl("cvTeamMemberNew")).Visible = false;
                    ((TextBox)e.Row.FindControl("tbxUserNew")).Visible = true;

                    EmployeeGateway employeeGatewayForOnHold = new EmployeeGateway();
                    employeeGatewayForOnHold.LoadByEmployeeId(employeeId);
                    ((TextBox)e.Row.FindControl("tbxUserNew")).Text = employeeGatewayForOnHold.GetFullName(employeeId);
                    ((Label)e.Row.FindControl("lblClosed")).Visible = false;
                    ((Label)e.Row.FindControl("lblUserNew")).Text = "On Hold By";
                }

                // Date and time
                DateTime creationDate = DateTime.Now;
                ((TextBox)e.Row.FindControl("tbxDateTimeNew")).Text = creationDate.ToString();
            }

            // Control of edit rows
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Edit) || (e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
            {
                // Date and time
                DateTime creationDate = DateTime.Now;
                ((TextBox)e.Row.FindControl("tbxDateTimeEdit")).Text = creationDate.ToString();
                string type_ = ((Label)e.Row.FindControl("lblType")).Text;
                int loginId = Convert.ToInt32(Session["loginID"]);
                EmployeeGateway employeeGateway = new EmployeeGateway();
                int employeeId = employeeGateway.GetEmployeIdByLoginId(loginId);
                int toDoId = Int32.Parse(((Label)e.Row.FindControl("lblToDoID")).Text);
                int refId = Int32.Parse(((Label)e.Row.FindControl("lblRefID")).Text);

                ToDoListInformationActivityInformationGateway toDoListInformationActivityInformationGateway = new ToDoListInformationActivityInformationGateway(toDoListInformationTDS);                
                
                // Make fields visible for actions
                if (type_ == "AssignUser")
                {
                    int employeeIdForAssign = toDoListInformationActivityInformationGateway.GetEmployeeID(toDoId, refId);
                    ((DropDownList)e.Row.FindControl("ddlAssignToTeamMemberEdit")).Visible = true;
                    ((DropDownList)e.Row.FindControl("ddlAssignToTeamMemberEdit")).SelectedValue = employeeIdForAssign.ToString();
                    ((CustomValidator)e.Row.FindControl("cvTeamMemberEdit")).Visible = true;
                    ((TextBox)e.Row.FindControl("tbxUserEdit")).Visible = false;
                    ((Label)e.Row.FindControl("lblUserEdit")).Text = "Assign To";
                }

                if (type_ == "AddComment")
                {
                    ((DropDownList)e.Row.FindControl("ddlAssignToTeamMemberEdit")).Visible = false;
                    ((CustomValidator)e.Row.FindControl("cvTeamMemberEdit")).Visible = false;
                    ((TextBox)e.Row.FindControl("tbxUserEdit")).Visible = true;

                    EmployeeGateway employeeGatewayForUser = new EmployeeGateway();
                    employeeGatewayForUser.LoadByEmployeeId(employeeId);
                    ((TextBox)e.Row.FindControl("tbxUserEdit")).Text = employeeGatewayForUser.GetFullName(employeeId);
                    ((Label)e.Row.FindControl("lblUserEdit")).Text = "Comment Added By";
                }

                if (type_ == "CloseToDo")
                {
                    ((DropDownList)e.Row.FindControl("ddlAssignToTeamMemberEdit")).Visible = false;
                    ((CustomValidator)e.Row.FindControl("cvTeamMemberEdit")).Visible = false;
                    ((TextBox)e.Row.FindControl("tbxUserEdit")).Visible = true;

                    EmployeeGateway employeeGatewayForUser = new EmployeeGateway();
                    employeeGatewayForUser.LoadByEmployeeId(Int32.Parse(hdfAssignedUser.Value));
                    ((TextBox)e.Row.FindControl("tbxUserEdit")).Text = employeeGatewayForUser.GetFullName(Int32.Parse(hdfAssignedUser.Value));
                    ((Label)e.Row.FindControl("lblUserEdit")).Text = "To Do Completed By";
                }

                if (type_ == "OnHoldToDo")
                {
                    ((DropDownList)e.Row.FindControl("ddlAssignToTeamMemberEdit")).Visible = false;
                    ((CustomValidator)e.Row.FindControl("cvTeamMemberEdit")).Visible = false;
                    ((TextBox)e.Row.FindControl("tbxUserEdit")).Visible = true;

                    EmployeeGateway employeeGatewayForOnHold = new EmployeeGateway();
                    employeeGatewayForOnHold.LoadByEmployeeId(employeeId);
                    ((TextBox)e.Row.FindControl("tbxUserEdit")).Text = employeeGatewayForOnHold.GetFullName(employeeId); 
                    ((Label)e.Row.FindControl("lblUserEdit")).Text = "On Hold By";
                }
            }

            // Control normal rows
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Normal) || (e.Row.RowState == (DataControlRowState.Normal | DataControlRowState.Alternate))))
            {                
                // Validate admin actions
                if ((Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_TODOLIST_ADMIN"])))
                {
                    ((ImageButton)e.Row.FindControl("ibtnEdit")).Visible = true;
                    ((ImageButton)e.Row.FindControl("ibtnDelete")).Visible = true;
                }
                else
                {
                    bool inDataBase = bool.Parse(((Label)e.Row.FindControl("lblInDataBase")).Text);
                    if (inDataBase)
                    {
                        ((ImageButton)e.Row.FindControl("ibtnEdit")).Visible = false;
                        ((ImageButton)e.Row.FindControl("ibtnDelete")).Visible = false;
                    }
                    else
                    {
                        ((ImageButton)e.Row.FindControl("ibtnEdit")).Visible = true;
                        ((ImageButton)e.Row.FindControl("ibtnDelete")).Visible = true;
                    }
                }

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



        protected void grdToDoList_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // ToDo Gridview, if the gridview is edition mode
            if (grdToDoList.EditIndex >= 0)
            {
                grdToDoList.UpdateRow(grdToDoList.EditIndex, true);
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
                    hdfAction.Value = "Save";
                    Save();
                    break;

                case "mApply":
                    hdfAction.Value = "Apply";
                    Apply();
                    break;

                case "mCancel":
                      toDoListInformationTDS.RejectChanges();

                      if (Request.QueryString["source_page"] == "toDoList_summary.aspx")
                      {
                          url = "./toDoList_summary.aspx?source_page=toDoList_activity.aspx&dashboard=" + hdfDashboard.Value + "&toDo_id=" + hdfToDoId.Value + GetNavigatorState() + "&update=yes";
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
           
            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./toDoList_activity.js");
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
                hdfCreatedById.Value = createdById.ToString();
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



        private void Save()
        {
            // Validate data
            bool validData = true;

            validData = ValidatePage();

            if (validData)
            {                
                // Update database
                UpdateDatabase();
                ViewState["update"] = "yes";

                // Redirect
                string url = "";
                if (Request.QueryString["source_page"] == "toDoList_summary.aspx")
                {
                    url = "./toDoList_summary.aspx?source_page=toDoList_activity.aspx&toDo_id=" + hdfToDoId.Value + "&dashboard=" + hdfDashboard.Value + GetNavigatorState() + "&update=yes";
                }

                Response.Redirect(url);
            }
        }



        private void Apply()
        {
            // Validate data
            bool validData = true;
            validData = ValidatePage();

            if (validData)
            {               
                // Update database
                UpdateDatabase();
                ViewState["update"] = "yes";
            }
        }



        private bool ValidatePage()
        {
            bool validData = true;
            
            // Validate todo data
            if (ValidateToDoFooter())
            {
                Page.Validate("activityDataNew");
                if (!Page.IsValid)
                {
                    validData = false;
                }
                else
                { 
                    // If the gridview is edition mode
                    if (grdToDoList.EditIndex >= 0)
                    {
                        grdToDoList.UpdateRow(grdToDoList.EditIndex, true);
                    }

                    GrdToDoAdd();
                }

                
                // Store datasets
                Session["toDoListInformationTDS"] = toDoListInformationTDS;
            }             

            return validData;
        }



        private void UpdateDatabase()
        {
            // Get ids 
            int companyId = Int32.Parse(hdfCompanyId.Value);

            DB.Open();
            DB.BeginTransaction();
            try
            {
                // ... Update general todo list state
                ToDoListInformationBasicInformation toDoListInformationBasicInformation = new ToDoListInformationBasicInformation(toDoListInformationTDS);
                toDoListInformationBasicInformation.Save(companyId);

                // ... Save to do list details
                ToDoListInformationActivityInformation toDoListInformationActivityInformation = new ToDoListInformationActivityInformation(toDoListInformationTDS);
                toDoListInformationActivityInformation.Save(companyId);
                
                // ... Send mails
                if (hdfCompleted.Value == "True")
                {
                    SendMailForCompletedToDo();
                }

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
          
   
        
        private void GrdToDoAdd()
        {
            if (ValidateToDoFooter())
            {
                Page.Validate("activityDataNew");

                if (Page.IsValid)
                {
                    int employeeId = 0;
                    EmployeeGateway employeeGateway = new EmployeeGateway();
                    string dateTime_ = ((TextBox)grdToDoList.FooterRow.FindControl("tbxDateTimeNew")).Text;
                    string comment = ((TextBox)grdToDoList.FooterRow.FindControl("tbxCommentsNew")).Text;
                    string type_ = "";
                    string employeeFullName = "";

                    GridViewRow row = grdToDoList.FooterRow;
                    DropDownList action = ((DropDownList)row.FindControl("ddlActionsNew"));
            
                    switch (action.SelectedValue)
                    {
                        case "Assign To User":
                            employeeId = Int32.Parse(((DropDownList)grdToDoList.FooterRow.FindControl("ddlAssignToTeamMemberNew")).SelectedValue);
                            employeeGateway.LoadByEmployeeId(employeeId);
                            employeeFullName = employeeGateway.GetFullName(employeeId);
                            type_ = "AssignUser";
                            hdfToDoListState.Value = "In Progress";
                            break;
                    
                        case "Add Comment":                    
                            int loginId = Convert.ToInt32(Session["loginID"]);                            
                            employeeId = employeeGateway.GetEmployeIdByLoginId(loginId);
                            type_ = "AddComment";
                            employeeFullName = employeeGateway.GetFullName(employeeId);
                            hdfToDoListState.Value = "In Progress";
                            break;                    

                        case "Complete":                    
                            employeeId = Int32.Parse(hdfAssignedUser.Value);
                            employeeGateway.LoadByEmployeeId(employeeId);
                            employeeFullName = employeeGateway.GetFullName(employeeId);
                            type_ = "CloseToDo";
                            hdfCompleted.Value = "True";
                            hdfToDoListState.Value = "Completed";
                            break;

                        case "Put On Hold":
                            int loginIdOnHold = Convert.ToInt32(Session["loginID"]);
                            employeeId = employeeGateway.GetEmployeIdByLoginId(loginIdOnHold);
                            type_ = "OnHoldToDo";
                            employeeFullName = employeeGateway.GetFullName(employeeId);
                            hdfToDoListState.Value = "On Hold";
                            break;  
                    }

                    // static values
                    int toDoId = Int32.Parse(hdfToDoId.Value);
                    int companyId = Int32.Parse(hdfCompanyId.Value);
                    bool inDatabase = false;

                    ToDoListInformationBasicInformation generalModel = new ToDoListInformationBasicInformation(toDoListInformationTDS);
                    generalModel.UpdateState(toDoId, hdfToDoListState.Value);

                    ToDoListInformationActivityInformation model = new ToDoListInformationActivityInformation(toDoListInformationTDS);
                    model.Insert(toDoId, employeeId, type_, DateTime.Parse(dateTime_), comment, false, companyId, inDatabase, employeeFullName);
                    
                    Session.Remove("activityInformationDummy");
                    Session["toDoListInformationTDS"] = toDoListInformationTDS;

                    grdToDoList.DataBind();
                }
            }
        }
              
          

        private bool ValidateToDoFooter()
        {            
            bool validFooter = false;
            int employeeId = 0;
            string comment = ((TextBox)grdToDoList.FooterRow.FindControl("tbxCommentsNew")).Text;

            if (hdfAction.Value == "Assign To User")
            {
                employeeId = Int32.Parse(((DropDownList)grdToDoList.FooterRow.FindControl("ddlAssignToTeamMemberNew")).SelectedValue);

                if (employeeId != 0)
                {
                    validFooter = true;
                }  
            }

            if (hdfAction.Value == "Add Comment")
            {
                int loginId = Convert.ToInt32(Session["loginID"]);
                EmployeeGateway employeeGateway = new EmployeeGateway();
                employeeId = employeeGateway.GetEmployeIdByLoginId(loginId);

                if ((employeeId != 0) && (comment != ""))
                {
                    validFooter = true;
                }  
            }

            if (hdfAction.Value == "Complete")
            {
                employeeId = Int32.Parse(hdfAssignedUser.Value);

                if ((employeeId != 0) && (comment != ""))
                {
                    validFooter = true;
                }  
            }

            if (hdfAction.Value == "Put On Hold")
            {
                int loginId = Convert.ToInt32(Session["loginID"]);
                EmployeeGateway employeeGateway = new EmployeeGateway();
                employeeId = employeeGateway.GetEmployeIdByLoginId(loginId);

                if ((employeeId != 0) && (comment != ""))
                {
                    validFooter = true;
                }  
            }                    

            return validFooter;
        }



        public void SendMailForCompletedToDo()
        {
            // Get mail information
            string mailTo = "";
            string nameTo = "";
            string subject = "A to do list was completed.";
            string body = "";

            // MailtTo, nameTo            
            int createdBy = Int32.Parse(hdfCreatedById.Value);
            EmployeeGateway  employeeGateway = new EmployeeGateway();
            employeeGateway.LoadByEmployeeId(createdBy);

            mailTo = employeeGateway.GetEMail(createdBy);
            nameTo = employeeGateway.GetFullName(createdBy);

            // Mails body
            body = body + "\nHi " + nameTo + ",\n\nThe following to do list was completed. \n";
            body = body + "\n Subject: "+ lblTitleSubjectName.Text;
            body = body + "\n Created By: " + tbxCreatedBy.Text;
            body = body + "\n Creation Date: " + tbxCreationDate.Text;
            body = body + "\n Assigned User: " + tbxAssignedUser.Text;
            body = body + "\n Due Date: " + tbxDueDate.Text;
            body = body + "\n Unit / Equipment: " + tbxUnit.Text;

            //Send Mail
            SendMail(mailTo, subject, body);
        }



        private void SendMail(string mailTo, string subject, string body)
        {
            SendMailLiveSite(mailTo, subject, body);
            //SendMailTestSite(mailTo, subject, body);//TODO EMAIL
        }



        private void SendMailLiveSite(string mailTo, string subject, string body)
        {
            string error;

            // For live site
            string entireBody = "";

            if ((mailTo != "") && (subject != "") && (body != ""))
            {
                entireBody = entireBody + body + "\n\n\n\n\nRegards,\n\n" + "LFS Admin Team.\n\n";
                LiquiForce.LFSLive.WebUI.Common.Tools.Mail.SendMail(mailTo, "sussel@nerdsonsite.com", subject, entireBody, false, out error);
            }
        }



        private void SendMailTestSite(string mailTo, string subject, string body)
        {
            string error;

            // For Test Site
            string entireBody = "--- SENT FROM THE TEST SITE --- \n";

            if ((mailTo != "") && (subject != "") && (body != ""))
            {
                entireBody = entireBody + body + "\n\n\n\n\nRegards,\n\n" + "LFS Admin Team.\n\n";
                LiquiForce.LFSLive.WebUI.Common.Tools.Mail.SendMail("sussel@nerdsonsite.com", "humberto@nerdsonsite.com, sussel@nerdsonsite.com, jacqueline.claure@nerdsonsite.com", subject, entireBody, false, out error);
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



        public void DummyToDoNew(int ToDoID, int RefID)
        {
        }

        

    }
}