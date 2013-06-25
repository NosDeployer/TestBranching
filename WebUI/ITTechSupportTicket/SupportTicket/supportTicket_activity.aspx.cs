using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.BL.ITTechSupportTicket.SupportTicket;
using LiquiForce.LFSLive.DA.ITTechSupportTicket.SupportTicket;
using LiquiForce.LFSLive.DA.Resources.Employees;
using LiquiForce.LFSLive.Server;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.ITTechSupportTicket.SupportTicket
{
    /// <summary>
    /// supportTicket_activity
    /// </summary>
    public partial class supportTicket_activity : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected SupportTicketInformationTDS supportTicketInformationTDS;
        protected SupportTicketInformationTDS.ActivityInformationDataTable activityInformation;






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
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["supportTicket_id"] == null) || ((string)Request.QueryString["action"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in supportTicket_activity.aspx");
                }

                // Tag Page
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfSupportTicketId.Value = Request.QueryString["supportTicket_id"].ToString();                
                hdfAction.Value = Request.QueryString["action"].ToString();
                hdfDashboard.Value = Request.QueryString["dashboard"].ToString();

                // If coming from 
                int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
                int currentSupportTicketId = Int32.Parse(hdfSupportTicketId.Value.ToString());

                Session.Remove("activityInformationDummyForST");

                // ... supportTicket_navigator2.aspx
                if (Request.QueryString["source_page"] == "supportTicket_navigator2.aspx")
                {
                    StoreNavigatorState();
                    supportTicketInformationTDS = new SupportTicketInformationTDS();
                    activityInformation = new SupportTicketInformationTDS.ActivityInformationDataTable();

                    SupportTicketInformationBasicInformation supportTicketInformationBasicInformation = new SupportTicketInformationBasicInformation(supportTicketInformationTDS);
                    supportTicketInformationBasicInformation.LoadAllBySupportTicketId(currentSupportTicketId, companyId);

                    SupportTicketInformationBasicInformationGateway supportTicketInformationBasicInformationGatewayForState = new SupportTicketInformationBasicInformationGateway(supportTicketInformationBasicInformation.Data);
                    string state = supportTicketInformationBasicInformationGatewayForState.GetState(currentSupportTicketId);
                    if (state == "Completed") hdfCompleted.Value = "True";

                    SupportTicketInformationActivityInformation supportTicketInformationActivityInformation = new SupportTicketInformationActivityInformation(supportTicketInformationTDS);
                    supportTicketInformationActivityInformation.LoadAllBySupportTicketId(currentSupportTicketId, companyId);
                                     
                    // Store dataset
                    Session["supportTicketInformationTDS"] = supportTicketInformationTDS;
                    Session["activityInformationForST"] = activityInformation;
                }

                // ... supportTicket_summary.aspx or supportTicket_edit.aspx 
                if ((Request.QueryString["source_page"] == "supportTicket_summary.aspx") || (Request.QueryString["source_page"] == "supportTicket_edit.aspx"))
                {
                    StoreNavigatorState();
                    ViewState["update"] = Request.QueryString["update"];

                    // Restore dataset
                    supportTicketInformationTDS = (SupportTicketInformationTDS)Session["supportTicketInformationTDS"];
                    activityInformation = (SupportTicketInformationTDS.ActivityInformationDataTable)Session["activityInformationForST"];                                       

                    if (ViewState["update"].ToString().Trim() == "yes")
                    {
                        SupportTicketInformationBasicInformation supportTicketInformationBasicInformation = new SupportTicketInformationBasicInformation(supportTicketInformationTDS);
                        supportTicketInformationBasicInformation.LoadAllBySupportTicketId(currentSupportTicketId, companyId);

                        SupportTicketInformationBasicInformationGateway supportTicketInformationBasicInformationGatewayForState = new SupportTicketInformationBasicInformationGateway(supportTicketInformationBasicInformation.Data);
                        string state = supportTicketInformationBasicInformationGatewayForState.GetState(currentSupportTicketId);
                        if (state == "Completed") hdfCompleted.Value = "True";

                        SupportTicketInformationActivityInformation supportTicketInformationActivityInformation = new SupportTicketInformationActivityInformation(supportTicketInformationTDS);
                        supportTicketInformationActivityInformation.LoadAllBySupportTicketId(currentSupportTicketId, companyId);

                        // Store dataset
                        Session["supportTicketInformationTDS"] = supportTicketInformationTDS;
                        Session["activityInformationForST"] = activityInformation;
                    }            
                }

                // Prepare initial data
                // ... for subject
                SupportTicketInformationBasicInformationGateway supportTicketInformationBasicInformationGateway = new SupportTicketInformationBasicInformationGateway();
                supportTicketInformationBasicInformationGateway.LoadAllBySupportTicketId(currentSupportTicketId, companyId);
                lblTitleSubjectName.Text = " " + supportTicketInformationBasicInformationGateway.GetSubject(currentSupportTicketId);

                // ... Data for current to do list               
                LoadSupportTicketData(currentSupportTicketId, companyId);
            }
            else
            {
                // Restore datasets
                supportTicketInformationTDS = (SupportTicketInformationTDS)Session["supportTicketInformationTDS"];
                activityInformation = (SupportTicketInformationTDS.ActivityInformationDataTable)Session["activityInformationForST"];
            }
        }



        protected void grdSupportTicket_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Repair Gridview, if the gridview is edition mode
            if (grdSupportTicket.EditIndex >= 0)
            {
                grdSupportTicket.UpdateRow(grdSupportTicket.EditIndex, true);
            }

            // Delete repairs
            int supportTicketId = (int)e.Keys["SupportTicketID"];
            int refId = (int)e.Keys["RefID"];
            bool sendMail = false;

            SupportTicketInformationActivityInformation model = new SupportTicketInformationActivityInformation(supportTicketInformationTDS);

            // Delete repair
            model.Delete(supportTicketId, refId, sendMail);

            // Store dataset
            Session["supportTicketInformationTDS"] = supportTicketInformationTDS;
        }



        protected void grdSupportTicket_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Add")
            {
                // Repair Gridview, if the gridview is edition mode
                if (grdSupportTicket.EditIndex >= 0)
                {
                    grdSupportTicket.UpdateRow(grdSupportTicket.EditIndex, true);
                }

                // Add New to do
                GrdToDoAdd();
                mForm8 master = (mForm8)this.Master;
                ScriptManager scriptManager = (ScriptManager)master.FindControl("ScriptManagerMaster8");
                scriptManager.SetFocus(grdSupportTicket.FooterRow.FindControl("tbxCommentsNew"));
            }
        }



        protected void grdSupportTicket_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.Validate("activityDataEdit");

            if (Page.IsValid)
            {
                bool sendMail = true;

                int supportTicketId = (int)e.Keys["SupportTicketID"];
                int refId = (int)e.Keys["RefID"];

                int employeeId = 0;
                int loginId = Convert.ToInt32(Session["loginID"]);

                EmployeeGateway employeeGateway = new EmployeeGateway();
                string comment = ((TextBox)grdSupportTicket.Rows[e.RowIndex].Cells[4].FindControl("tbxCommentsEdit")).Text;
                string employeeFullName = "";           

                string type_ = ((Label)grdSupportTicket.Rows[e.RowIndex].Cells[4].FindControl("lblType")).Text;
                switch (type_)
                {
                    case "AssignUser":
                        employeeId = Int32.Parse(((DropDownList)grdSupportTicket.Rows[e.RowIndex].Cells[4].FindControl("ddlAssignToTeamMemberEdit")).SelectedValue);
                        employeeGateway.LoadByEmployeeId(employeeId);
                        employeeFullName = employeeGateway.GetFullName(employeeId);
                        break;

                    case "AddComment":
                        employeeId = employeeGateway.GetEmployeIdByLoginId(loginId);
                        EmployeeGateway employeeGatewayForComment = new EmployeeGateway();
                        employeeGatewayForComment.LoadByEmployeeId(employeeId);
                        employeeFullName = employeeGatewayForComment.GetFullName(employeeId);
                        break;

                    case "CloseTicket":
                        employeeId = Int32.Parse(hdfAssignedUser.Value);
                        employeeGateway.LoadByEmployeeId(employeeId);
                        employeeFullName = employeeGateway.GetFullName(employeeId);
                        hdfCompleted.Value = "True";
                        break;

                    case "OnHold":
                        employeeId = employeeGateway.GetEmployeIdByLoginId(loginId);
                        EmployeeGateway employeeGatewayForOnHold = new EmployeeGateway();
                        employeeGatewayForOnHold.LoadByEmployeeId(employeeId);
                        employeeFullName = employeeGatewayForOnHold.GetFullName(employeeId);
                        break;
                }

                SupportTicketInformationActivityInformation model = new SupportTicketInformationActivityInformation(supportTicketInformationTDS);
                model.Update(supportTicketId, refId, employeeId, employeeFullName, comment, sendMail);
           
                // Store dataset
                Session["supportTicketInformationTDS"] = supportTicketInformationTDS;
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
            master.ActiveToolbar = "ITTechSupportTicket";
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

            string employeeId = ((DropDownList)grdSupportTicket.FooterRow.FindControl("ddlAssignToTeamMemberNew")).SelectedValue;

            if (employeeId == "-1")
            {
                args.IsValid = false;
            }
        }



        protected void cvProblemDescriptionNew_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            string action = ((DropDownList)grdSupportTicket.FooterRow.FindControl("ddlActionsNew")).SelectedValue;
            string comment = ((TextBox)grdSupportTicket.FooterRow.FindControl("tbxCommentsNew")).Text;

            if (action == "Assign To User" || action == "Assign To Owner")
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
            GridViewRow row = grdSupportTicket.FooterRow;
            DropDownList action = ((DropDownList)row.FindControl("ddlActionsNew"));
            
            switch (action.SelectedValue)
            {
                case "Assign To User":
                    ((DropDownList)row.FindControl("ddlAssignToTeamMemberNew")).Visible = true;
                    ((CustomValidator)row.FindControl("cvTeamMemberNew")).Visible = true;
                    ((TextBox)row.FindControl("tbxUserNew")).Visible = false;
                    ((Label)row.FindControl("lblUserNew")).Text = "Assign To";
                    break;

                case "Assign To Owner":
                    ((DropDownList)row.FindControl("ddlAssignToTeamMemberNew")).Visible = true;
                    ((CustomValidator)row.FindControl("cvTeamMemberNew")).Visible = true;
                    ((TextBox)row.FindControl("tbxUserNew")).Visible = false;
                    ((Label)row.FindControl("lblUserNew")).Text = "Assign To";

                    int currentSupportTicketId = Int32.Parse(hdfSupportTicketId.Value.ToString());
                    SupportTicketInformationBasicInformationGateway supportTicketInformationBasicInformationGatewayForState = new SupportTicketInformationBasicInformationGateway(supportTicketInformationTDS);
                    int ownerId = supportTicketInformationBasicInformationGatewayForState.GetCreatedByID(currentSupportTicketId);
                    ((DropDownList)row.FindControl("ddlAssignToTeamMemberNew")).SelectedValue = ownerId.ToString();
                    ((DropDownList)row.FindControl("ddlAssignToTeamMemberNew")).Enabled = false;
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
                    ((Label)row.FindControl("lblUserNew")).Text = "Support Ticket Completed By";

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
        


        protected void grdSupportTicket_DataBound(object sender, EventArgs e)
        {
            AddToDoNewEmptyFix(grdSupportTicket);
        }



        protected void grdSupportTicket_RowDataBound(object sender, GridViewRowEventArgs e)
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

                // Make fields visible for actions
                if (hdfAction.Value == "Assign To Owner")
                {
                    ((DropDownList)e.Row.FindControl("ddlAssignToTeamMemberNew")).Visible = true;
                    ((CustomValidator)e.Row.FindControl("cvTeamMemberNew")).Visible = true;
                    ((TextBox)e.Row.FindControl("tbxUserNew")).Visible = false;
                    ((Label)e.Row.FindControl("lblClosed")).Visible = false;
                    ((Label)e.Row.FindControl("lblUserNew")).Text = "Assign To";

                    int currentSupportTicketId = Int32.Parse(hdfSupportTicketId.Value.ToString());
                    SupportTicketInformationBasicInformationGateway supportTicketInformationBasicInformationGatewayForState = new SupportTicketInformationBasicInformationGateway(supportTicketInformationTDS);
                    int ownerId = supportTicketInformationBasicInformationGatewayForState.GetCreatedByID(currentSupportTicketId);
                    ((DropDownList)e.Row.FindControl("ddlAssignToTeamMemberNew")).SelectedValue = ownerId.ToString();
                    ((DropDownList)e.Row.FindControl("ddlAssignToTeamMemberNew")).Enabled = false;
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

                    ((Label)e.Row.FindControl("lblUserNew")).Text = "Support Ticket Completed By";
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
                int supportTicketId = Int32.Parse(((Label)e.Row.FindControl("lblSupportTicketID")).Text);
                int refId = Int32.Parse(((Label)e.Row.FindControl("lblRefID")).Text);

                SupportTicketInformationActivityInformationGateway supportTicketInformationActivityInformationGateway = new SupportTicketInformationActivityInformationGateway(supportTicketInformationTDS);                
                
                // Make fields visible for actions
                if (type_ == "AssignUser")
                {
                    int employeeIdForAssign = supportTicketInformationActivityInformationGateway.GetEmployeeID(supportTicketId, refId);
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

                if (type_ == "CloseTicket")
                {
                    ((DropDownList)e.Row.FindControl("ddlAssignToTeamMemberEdit")).Visible = false;
                    ((CustomValidator)e.Row.FindControl("cvTeamMemberEdit")).Visible = false;
                    ((TextBox)e.Row.FindControl("tbxUserEdit")).Visible = true;

                    EmployeeGateway employeeGatewayForUser = new EmployeeGateway();
                    employeeGatewayForUser.LoadByEmployeeId(Int32.Parse(hdfAssignedUser.Value));
                    ((TextBox)e.Row.FindControl("tbxUserEdit")).Text = employeeGatewayForUser.GetFullName(Int32.Parse(hdfAssignedUser.Value));
                    ((Label)e.Row.FindControl("lblUserEdit")).Text = "Support Ticket Completed By";
                }

                if (type_ == "OnHold")
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
                if ((Convert.ToBoolean(Session["sgLFS_ITTST_SUPPORTTICKET_ADMIN"])))
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

                if (type_ == "CloseTicket")
                {
                    ((Label)e.Row.FindControl("lblUser")).Text = "Support Ticket Completed By";
                }

                if (type_ == "OnHold")
                {
                    ((Label)e.Row.FindControl("lblUser")).Text = "On Hold By";
                }
            }
        }        



        protected void grdSupportTicket_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // ToDo Gridview, if the gridview is edition mode
            if (grdSupportTicket.EditIndex >= 0)
            {
                grdSupportTicket.UpdateRow(grdSupportTicket.EditIndex, true);
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
                      supportTicketInformationTDS.RejectChanges();

                      if (Request.QueryString["source_page"] == "supportTicket_summary.aspx")
                      {
                          url = "./supportTicket_summary.aspx?source_page=supportTicket_activity.aspx&dashboard=" + hdfDashboard.Value + "&supportTicket_id=" + hdfSupportTicketId.Value + GetNavigatorState() + "&update=no";
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
                    url = "./supportTicket_navigator.aspx?source_page=lm";
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
            contentVariables += "var tkrmTopId = '" + tkrmTop.ClientID + "';"; 
           
            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./supportTicket_activity.js");
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

        private void LoadSupportTicketData(int supportTicketId, int companyId)
        {
            // Load Data
            LoadData(supportTicketId);
            LoadActivityData(supportTicketId, companyId);
        }



        private void LoadData(int supportTicketId)
        {
            SupportTicketInformationBasicInformationGateway supportTicketInformationBasicInformationGateway = new SupportTicketInformationBasicInformationGateway(supportTicketInformationTDS);
            if (supportTicketInformationBasicInformationGateway.Table.Rows.Count > 0)
            {
                // Load to do Details
                int companyId = Int32.Parse(hdfCompanyId.Value);

                int createdById = supportTicketInformationBasicInformationGateway.GetCreatedByID(supportTicketId);
                hdfCreatedById.Value = createdById.ToString();
                EmployeeGateway employeeGateway = new EmployeeGateway();
                employeeGateway.LoadByEmployeeId(createdById);
                tbxCreatedBy.Text = employeeGateway.GetFullName(createdById);

                tbxCreationDate.Text = supportTicketInformationBasicInformationGateway.GetCreationDate(supportTicketId).ToString();
                tbxState.Text = supportTicketInformationBasicInformationGateway.GetState(supportTicketId);
                tbxCategoryName.Text = supportTicketInformationBasicInformationGateway.GetCategoryName(supportTicketId);

                if (supportTicketInformationBasicInformationGateway.GetDueDate(supportTicketId).HasValue)
                {
                    DateTime dueDateValue = (DateTime)supportTicketInformationBasicInformationGateway.GetDueDate(supportTicketId);
                    tbxDueDate.Text = dueDateValue.Month.ToString() + "/" + dueDateValue.Day.ToString() + "/" + dueDateValue.Year.ToString();
                }                               
            }
        }



        private void LoadActivityData(int supportTicketId, int companyId)
        {
            SupportTicketInformationActivityInformation supportTicketInformationActivityInformation = new SupportTicketInformationActivityInformation();
            supportTicketInformationActivityInformation.LoadAllBySupportTicketId(supportTicketId, companyId);
            int lastRefId = supportTicketInformationActivityInformation.GetLastAssignedUserRefId();

            SupportTicketInformationActivityInformationGateway supportTicketInformationActivityInformationGateway = new SupportTicketInformationActivityInformationGateway(supportTicketInformationActivityInformation.Data);
            supportTicketInformationActivityInformationGateway.LoadAllBySupportTicketId(supportTicketId, companyId);

            if (supportTicketInformationActivityInformationGateway.Table.Rows.Count > 0)
            {
                // For last assigned user
                tbxAssignedUser.Text = supportTicketInformationActivityInformationGateway.GetEmployeeFullName(supportTicketId, lastRefId);
                hdfAssignedUser.Value = supportTicketInformationActivityInformationGateway.GetEmployeeID(supportTicketId, lastRefId).ToString();
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
                if (Request.QueryString["source_page"] == "supportTicket_summary.aspx")
                {
                    url = "./supportTicket_summary.aspx?source_page=supportTicket_activity.aspx&supportTicket_id=" + hdfSupportTicketId.Value + "&dashboard=" + hdfDashboard.Value + GetNavigatorState() + "&update=yes";
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
                    if (grdSupportTicket.EditIndex >= 0)
                    {
                        grdSupportTicket.UpdateRow(grdSupportTicket.EditIndex, true);
                    }

                    GrdToDoAdd();
                }

                
                // Store datasets
                Session["supportTicketInformationTDS"] = supportTicketInformationTDS;
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
                SupportTicketInformationBasicInformation supportTicketInformationBasicInformation = new SupportTicketInformationBasicInformation(supportTicketInformationTDS);
                supportTicketInformationBasicInformation.Save(companyId);

                // ... Save to do list details
                SupportTicketInformationActivityInformation supportTicketInformationActivityInformation = new SupportTicketInformationActivityInformation(supportTicketInformationTDS);
                supportTicketInformationActivityInformation.Save(companyId);
                
                // ... Send mails         
                int createdBy = Int32.Parse(hdfCreatedById.Value);
                string mailTo = "";
                string nameTo = "";

                // ... ... MailtTo, nameTo                                           
                EmployeeGateway employeeGateway = new EmployeeGateway();
                employeeGateway.LoadByEmployeeId(createdBy);

                mailTo = employeeGateway.GetEMail(createdBy);
                nameTo = employeeGateway.GetFullName(createdBy);

                SupportTicketInformationActivityInformation supportTicketInformationActivityInformationForMails = new SupportTicketInformationActivityInformation(supportTicketInformationTDS);
                                
                foreach (GridViewRow row in grdSupportTicket.Rows)
                {
                    bool sendMail = bool.Parse(((Label)row.FindControl("lblSendMail")).Text);

                    if (sendMail)
                    {                        
                        string subject = "";
                        string body = "";
                        string comment = "";

                        string type_ = ((Label)row.FindControl("lblType")).Text;
                        switch (type_)
                        {
                            case "AssignUser":
                                // Get mail information
                                subject = "A usser was assigned to the following ticket.";                             

                                // Mails body
                                body = body + "\nHi " + nameTo + ",\n\nA usser was assigned to the following ticket. \n";
                                body = body + "\n Subject: " + lblTitleSubjectName.Text;
                                body = body + "\n Created By: " + tbxCreatedBy.Text;
                                body = body + "\n Creation Date: " + tbxCreationDate.Text;
                                body = body + "\n Category: " + tbxCategoryName.Text;
                                string assignedUser = ((TextBox)row.FindControl("tbxUser")).Text;
                                body = body + "\n Assigned User: " + assignedUser;
                                body = body + "\n Due Date: " + tbxDueDate.Text;
                                comment = ((TextBox)row.FindControl("tbxComments")).Text;
                                body = body + "\n New comment: " + comment;

                                //Send Mail
                                SendMail(mailTo, subject, body);
                                break;

                            case "AssignToOwner":
                                // Get mail information                                
                                subject = "The following ticket was assigned to it's owner.";                               

                                // Mails body
                                body = body + "\nHi " + nameTo + ",\n\nThe following ticket was assigned to it's owner. \n";
                                body = body + "\n Subject: " + lblTitleSubjectName.Text;
                                body = body + "\n Owner: " + tbxCreatedBy.Text;
                                body = body + "\n Creation Date: " + tbxCreationDate.Text;
                                body = body + "\n Category: " + tbxCategoryName.Text;
                                string assignedOwer = ((TextBox)row.FindControl("tbxUser")).Text;                                
                                body = body + "\n Assigned To Owner: " + assignedOwer;
                                body = body + "\n Due Date: " + tbxDueDate.Text;
                                comment = ((TextBox)row.FindControl("tbxComments")).Text;
                                body = body + "\n New comment: " + comment;

                                //Send Mail
                                SendMail(mailTo, subject, body);
                                break;

                            case "AddComment":
                                // Get mail information                                
                                subject = "A comment was added to the following ticket.";

                                // Mails body
                                body = body + "\nHi " + nameTo + ",\n\nA comment was added to the following ticket. \n";
                                body = body + "\n Subject: " + lblTitleSubjectName.Text;
                                body = body + "\n Created By: " + tbxCreatedBy.Text;
                                body = body + "\n Creation Date: " + tbxCreationDate.Text;
                                body = body + "\n Category: " + tbxCategoryName.Text;
                                body = body + "\n Assigned User: " + tbxAssignedUser.Text;
                                body = body + "\n Due Date: " + tbxDueDate.Text;
                                string commentAddedBy = ((TextBox)row.FindControl("tbxUser")).Text;
                                body = body + "\n Comment added by: " + commentAddedBy;
                                comment = ((TextBox)row.FindControl("tbxComments")).Text;
                                body = body + "\n New comment: " + comment;

                                //Send Mail
                                SendMail(mailTo, subject, body);
                                break;

                            case "CloseTicket":
                                // Get mail information
                                subject = "A support ticket was completed.";

                                // Mails body
                                body = body + "\nHi " + nameTo + ",\n\nThe following support ticket was completed. \n";
                                body = body + "\n Subject: " + lblTitleSubjectName.Text;
                                body = body + "\n Created By: " + tbxCreatedBy.Text;
                                body = body + "\n Creation Date: " + tbxCreationDate.Text;
                                body = body + "\n Category: " + tbxCategoryName.Text;
                                body = body + "\n Assigned User: " + tbxAssignedUser.Text;
                                body = body + "\n Due Date: " + tbxDueDate.Text;
                                string completedBy = ((TextBox)row.FindControl("tbxUser")).Text;
                                body = body + "\n Completed by: " + completedBy;
                                comment = ((TextBox)row.FindControl("tbxComments")).Text;
                                body = body + "\n New comment: " + comment;

                                //Send Mail
                                SendMail(mailTo, subject, body);
                                break;

                            case "OnHold":
                                // Get mail information                                
                                subject = "The following ticket was put on hold.";  

                                // Mails body
                                body = body + "\nHi " + nameTo + ",\n\nThe following ticket was put on hold. \n";
                                body = body + "\n Subject: " + lblTitleSubjectName.Text;
                                body = body + "\n Created By: " + tbxCreatedBy.Text;
                                body = body + "\n Creation Date: " + tbxCreationDate.Text;
                                body = body + "\n Category: " + tbxCategoryName.Text;
                                body = body + "\n Assigned User: " + tbxAssignedUser.Text;
                                body = body + "\n Due Date: " + tbxDueDate.Text;
                                string onHoldBy = ((TextBox)row.FindControl("tbxUser")).Text;
                                body = body + "\n On hold by: " + onHoldBy;
                                comment = ((TextBox)row.FindControl("tbxComments")).Text;
                                body = body + "\n New comment: " + comment;

                                //Send Mail
                                SendMail(mailTo, subject, body);
                                break;
                        }
                    }
                }

                DB.CommitTransaction();

                // Store datasets
                supportTicketInformationTDS.AcceptChanges();
                Session["supportTicketInformationTDS"] = supportTicketInformationTDS;
            }
            catch (Exception ex)
            {
                DB.RollbackTransaction();

                string url = string.Format("./../../error_page.aspx?error={0}", ex.Message.Replace('\n', ' '));
                Response.Redirect(url);
            }
        }



        protected void AddToDoNewEmptyFix(GridView grdSupportTicket)
        {
            if (grdSupportTicket.Rows.Count == 0)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                SupportTicketInformationTDS.ActivityInformationDataTable dt = new SupportTicketInformationTDS.ActivityInformationDataTable();
                dt.AddActivityInformationRow(-1, -1, "", DateTime.Now, -1, "", false, companyId, false, "", false);
                Session["activityInformationDummyForST"] = dt;
                grdSupportTicket.DataBind();
            }

            // normally executes at all postbacks
            if (grdSupportTicket.Rows.Count == 1)
            {
                SupportTicketInformationTDS.ActivityInformationDataTable dt = (SupportTicketInformationTDS.ActivityInformationDataTable)Session["activityInformationDummyForST"];
                if (dt != null)
                {
                    grdSupportTicket.Rows[0].Visible = false;
                    grdSupportTicket.Rows[0].Controls.Clear();

                    Session.Remove("activityInformationDummyForST");
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
                    string dateTime_ = ((TextBox)grdSupportTicket.FooterRow.FindControl("tbxDateTimeNew")).Text;
                    string comment = ((TextBox)grdSupportTicket.FooterRow.FindControl("tbxCommentsNew")).Text;
                    string type_ = "";
                    string employeeFullName = "";

                    GridViewRow row = grdSupportTicket.FooterRow;
                    DropDownList action = ((DropDownList)row.FindControl("ddlActionsNew"));

                    switch (action.SelectedValue)
                    {
                        case "Assign To User":
                            employeeId = Int32.Parse(((DropDownList)grdSupportTicket.FooterRow.FindControl("ddlAssignToTeamMemberNew")).SelectedValue);
                            employeeGateway.LoadByEmployeeId(employeeId);
                            employeeFullName = employeeGateway.GetFullName(employeeId);
                            type_ = "AssignUser";
                            hdfSupportTicketState.Value = "In Progress";
                            
                            break;

                        case "Assign To Owner":
                            employeeId = Int32.Parse(((DropDownList)grdSupportTicket.FooterRow.FindControl("ddlAssignToTeamMemberNew")).SelectedValue);
                            employeeGateway.LoadByEmployeeId(employeeId);
                            employeeFullName = employeeGateway.GetFullName(employeeId);
                            type_ = "AssignUser";
                            hdfSupportTicketState.Value = "In Progress";
                            break;
                    
                        case "Add Comment":                    
                            int loginId = Convert.ToInt32(Session["loginID"]);                            
                            employeeId = employeeGateway.GetEmployeIdByLoginId(loginId);
                            type_ = "AddComment";
                            employeeFullName = employeeGateway.GetFullName(employeeId);
                            hdfSupportTicketState.Value = "In Progress";
                            break;                    

                        case "Complete":                    
                            employeeId = Int32.Parse(hdfAssignedUser.Value);
                            employeeGateway.LoadByEmployeeId(employeeId);
                            employeeFullName = employeeGateway.GetFullName(employeeId);
                            type_ = "CloseTicket";
                            hdfCompleted.Value = "True";
                            hdfSupportTicketState.Value = "Completed";
                            break;

                        case "Put On Hold":
                            int loginIdOnHold = Convert.ToInt32(Session["loginID"]);
                            employeeId = employeeGateway.GetEmployeIdByLoginId(loginIdOnHold);
                            type_ = "OnHold";
                            employeeFullName = employeeGateway.GetFullName(employeeId);
                            hdfSupportTicketState.Value = "On Hold";
                            break;  
                    }

                    // static values
                    int supportTicketId = Int32.Parse(hdfSupportTicketId.Value);
                    int companyId = Int32.Parse(hdfCompanyId.Value);
                    bool inDatabase = false;
                    bool sendMail = true;

                    SupportTicketInformationBasicInformation generalModel = new SupportTicketInformationBasicInformation(supportTicketInformationTDS);
                    generalModel.UpdateState(supportTicketId, hdfSupportTicketState.Value);

                    SupportTicketInformationActivityInformation model = new SupportTicketInformationActivityInformation(supportTicketInformationTDS);
                    model.Insert(supportTicketId, employeeId, type_, DateTime.Parse(dateTime_), comment, false, companyId, inDatabase, employeeFullName, sendMail);
                    
                    Session.Remove("activityInformationDummyForST");
                    Session["supportTicketInformationTDS"] = supportTicketInformationTDS;

                    grdSupportTicket.DataBind();
                }
            }
        }
              
          

        private bool ValidateToDoFooter()
        {            
            bool validFooter = false;
            int employeeId = 0;
            string comment = ((TextBox)grdSupportTicket.FooterRow.FindControl("tbxCommentsNew")).Text;

            if (hdfAction.Value == "Assign To User")
            {
                employeeId = Int32.Parse(((DropDownList)grdSupportTicket.FooterRow.FindControl("ddlAssignToTeamMemberNew")).SelectedValue);

                if (employeeId != 0)
                {
                    validFooter = true;
                }  
            }

            if (hdfAction.Value == "Assign To Owner")
            {
                employeeId = Int32.Parse(((DropDownList)grdSupportTicket.FooterRow.FindControl("ddlAssignToTeamMemberNew")).SelectedValue);

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
                LiquiForce.LFSLive.WebUI.Common.Tools.Mail.SendMailSupportTicketSystem(mailTo, "sussel@nerdsonsite.com", subject, entireBody, false, out error);
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
                LiquiForce.LFSLive.WebUI.Common.Tools.Mail.SendMailSupportTicketSystem("sussel@nerdsonsite.com", "sussel@nerdsonsite.com, sussel@nerdsonsite.com, sussel@nerdsonsite.com", subject, entireBody, false, out error);
            }
        }
               




                                
        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        public SupportTicketInformationTDS.ActivityInformationDataTable GetToDoNew()
        {
            activityInformation = (SupportTicketInformationTDS.ActivityInformationDataTable)Session["activityInformationDummyForST"];

            if (activityInformation == null)
            {
                activityInformation = ((SupportTicketInformationTDS)Session["supportTicketInformationTDS"]).ActivityInformation;
            }

            return activityInformation;
        }



        public void DummyToDoNew(int SupportTicketID, int RefID)
        {
        }

        

    }
}