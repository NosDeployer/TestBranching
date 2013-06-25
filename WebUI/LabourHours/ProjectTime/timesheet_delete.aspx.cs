using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.DA.LabourHours.ProjectTime;
using Telerik.Web.UI;
using LiquiForce.LFSLive.DA.Resources.Employees;

namespace LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime
{
    /// <summary>
    /// timesheet_delete
    /// </summary>
    public partial class timesheet_delete : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // PROPERTIES AND FIELDS
        //

        protected ProjectTimeTDS projectTimeTDS;






        // ////////////////////////////////////////////////////////////////////////
        // EVENTS
        //

        protected void Page_Load(object sender, EventArgs e)
        {
            // Register client scripts
            this.RegisterClientScripts();

            if (!IsPostBack)
            {
                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) && ((string)Request.QueryString["others"] == null) && ((string)Request.QueryString["employee_id"] == null) && ((string)Request.QueryString["period_id"] == null) && ((string)Request.QueryString["projecttime_id"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in timesheet_delete.aspx");
                }

                // Security check
                if (!Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_FULL_EDITING"]))
                {
                    if (Request.QueryString["others"] == "no")
                    {
                        if (!(Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_MY_TIMESHEETS_VIEW"]) && Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_MY_TIMESHEETS_DELETE"])))
                        {
                            if (!Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_MY_TIMESHEETS_MANAGEMENT"]))
                            {
                                if (!Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_MY_TIMESHEETS_MANAGEMENT_WED"]))
                                {
                                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                                }
                            }
                        }
                    }
                    else
                    {
                        if (!(Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_MY_TIMESHEETS_VIEW"]) && Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_MY_TIMESHEETS_DELETE"])))
                        {
                            if (!Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_MY_TIMESHEETS_MANAGEMENT"]))
                            {
                                if (!Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_MY_TIMESHEETS_MANAGEMENT_WED"]))
                                {
                                    if (!(Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_OTHERS_TIMESHEETS_VIEW"]) && Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_OTHERS_TIMESHEETS_DELETE"])))
                                    {
                                        if (!Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_OTHERS_TIMESHEETS_MANAGEMENT"]))
                                        {
                                            if (!Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_OTHERS_TIMESHEETS_MANAGEMENT_WED"]))
                                            {
                                                Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                // Initialize viewstate variables
                ViewState["others"] = Request.QueryString["others"];
                ViewState["employee_id"] = int.Parse(Request.QueryString["employee_id"]);
                ViewState["period_id"] = int.Parse(Request.QueryString["period_id"]);
                ViewState["projecttime_id"] = int.Parse(Request.QueryString["projecttime_id"]);
                System.Configuration.AppSettingsReader appSettingReader = new System.Configuration.AppSettingsReader();
                ViewState["LHMode"] = appSettingReader.GetValue("LABOUR_HOURS_OPERATION_MODE", typeof(System.String)).ToString();

                // Get ProjectTime record
                projectTimeTDS = new ProjectTimeTDS();

                ProjectTimeGateway projectTimeGateway = new ProjectTimeGateway(projectTimeTDS);
                projectTimeGateway.LoadByProjectTimeId((int)ViewState["projecttime_id"]);

                // Project time state check
                if ((!Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_FULL_EDITING"])))
                {
                    if (projectTimeGateway.GetProjectTimeState((int)ViewState["projecttime_id"]) == "Approved")
                    {
                        Response.Redirect("./../../error_page.aspx?error=" + "You cannot delete an approved project time.");
                    }
                }

                if (!Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_FULL_EDITING"]))
                {
                    if (Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_MY_TIMESHEETS_MANAGEMENT"]) || Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_OTHERS_TIMESHEETS_MANAGEMENT"]))
                    {
                        bool isValidLimitPayPeriodToManagementEdit = LiquiForce.LFSLive.BL.LabourHours.ProjectTime.ProjectTime.ValidateLimitedPayPeriodToManagementEdit(projectTimeGateway.GetDate_((int)ViewState["projecttime_id"]), projectTimeGateway.GetProjectId((int)ViewState["projecttime_id"]));

                        if (!isValidLimitPayPeriodToManagementEdit)
                        {
                            Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                        }
                    }

                    if (Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_MY_TIMESHEETS_MANAGEMENT_WED"]) || Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_OTHERS_TIMESHEETS_MANAGEMENT_WED"]))
                    {
                        bool isValidLimitPayPeriodToManagementEdit = LiquiForce.LFSLive.BL.LabourHours.ProjectTime.ProjectTime.ValidateLimitedPayPeriodToWednesdayManagementEdit(projectTimeGateway.GetDate_((int)ViewState["projecttime_id"]), projectTimeGateway.GetProjectId((int)ViewState["projecttime_id"]));

                        if (!isValidLimitPayPeriodToManagementEdit)
                        {
                            Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                        }
                    }
                }

                // Prepare initial data for client
                StoreNavigatorState();

                // Store datasets
                Session["projectTimeTDS"] = projectTimeTDS;
            }
            else
            {
                // Restore datasets
                projectTimeTDS = (ProjectTimeTDS)Session["projectTimeTDS"];
            }
        }

        

        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set active toolbar
            mForm6 master = (mForm6)this.Master;
            master.ActiveToolbar = "LabourHours";

            if (Request.QueryString["source_page"] == "timesheet_approve.aspx")
            {
                tkrmTop.Items[2].Visible = false; //Summary
                tkrmTop.Items[3].Visible = true; //Approve Project Times
            }
            else
            {
                if (Request.QueryString["source_page"] == "timesheet_summary_from_approve_project_times.aspx")
                {
                    tkrmTop.Items[2].Visible = true; //Summary
                    tkrmTop.Items[3].Visible = true; //Approve Project Times
                }
                else
                {
                    tkrmTop.Items[2].Visible = true; //Summary
                    tkrmTop.Items[3].Visible = false; //Approve Project Times
                }
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATION EVENTS
        //

        protected void tkrmTop_ItemClick(object sender, RadMenuEventArgs e)
        {
            switch (e.Item.Value)
            {
                case "mDelete":
                    PostPageChanges();
                    UpdateDatabase();

                    if (Request.QueryString["source_page"] == "timesheet.aspx")
                    {
                        Response.Redirect("./../timesheet/timesheet.aspx?source_page=timesheet_delete.aspx&others=" + ViewState["others"] + "&employee_id=" + ViewState["employee_id"] + "&period_id=" + ViewState["period_id"]);
                    }
                    else
                    {
                        if (Request.QueryString["source_page"] == "timesheet_approve.aspx")
                        {
                            Response.Redirect("./timesheet_approve.aspx?source_page=timesheet_delete.aspx&others=" + ViewState["others"] + GetNavigatorState());
                        }
                        else
                        {
                            if (Request.QueryString["source_page"] == "timesheet_summary_from_approve_project_times.aspx")
                            {
                                Response.Redirect("./timesheet_approve.aspx?source_page=timesheet_delete.aspx&others=" + ViewState["others"] + GetNavigatorState());
                            }
                            else
                            {
                                Response.Redirect("./../timesheet/timesheet.aspx?source_page=timesheet_delete.aspx&others=" + ViewState["others"] + "&employee_id=" + ViewState["employee_id"] + "&period_id=" + ViewState["period_id"]);
                            }
                        }
                    }
                    break;

                case "mCancel":
                    if (Request.QueryString["source_page"] == "timesheet.aspx")
                    {
                        Response.Redirect("./../timesheet/timesheet.aspx?source_page=timesheet_delete.aspx&others=" + ViewState["others"] + "&employee_id=" + ViewState["employee_id"] + "&period_id=" + ViewState["period_id"] + "&projecttime_id=" + ViewState["projecttime_id"]);
                    }
                    else
                    {
                        if (Request.QueryString["source_page"] == "timesheet_approve.aspx")
                        {
                            Response.Redirect("./timesheet_approve.aspx?source_page=timesheet_delete.aspx&others=" + ViewState["others"] + GetNavigatorState());
                        }
                        else
                        {
                            if (Request.QueryString["source_page"] == "timesheet_summary_from_approve_project_times.aspx")
                            {
                                Response.Redirect("./timesheet_summary.aspx?source_page=timesheet_approve.aspx&others=" + ViewState["others"] + "&employee_id=" + ViewState["employee_id"] + "&period_id=" + ViewState["period_id"] + "&projecttime_id=" + ViewState["projecttime_id"]);
                            }
                            else
                            {
                                Response.Redirect("./timesheet_summary.aspx?source_page=timesheet_delete.aspx&others=" + ViewState["others"] + "&employee_id=" + ViewState["employee_id"] + "&period_id=" + ViewState["period_id"] + "&projecttime_id=" + ViewState["projecttime_id"]);
                            }
                        }
                    }
                    break;

                case "mSummary":
                    Response.Redirect("./timesheet_summary.aspx?source_page=timesheet_delete.aspx&others=" + ViewState["others"] + "&employee_id=" + ViewState["employee_id"] + "&period_id=" + ViewState["period_id"] + "&projecttime_id=" + ViewState["projecttime_id"]);
                    break;

                case "mApproveProjectTimes":
                    Response.Redirect("./timesheet_approve.aspx?source_page=timesheet_edit.aspx&others=" + ViewState["others"] + GetNavigatorState());
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
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./timesheet_delete.js");
        }



        private void PostPageChanges()
        {
            int projectTimeId = (int)ViewState["projecttime_id"];

            EmployeeGateway employeeGateway = new EmployeeGateway();
            int employeeId = employeeGateway.GetEmployeIdByLoginId(Convert.ToInt32(Session["loginID"]));

            // Delete project time
            LiquiForce.LFSLive.BL.LabourHours.ProjectTime.ProjectTime projectTime = new LiquiForce.LFSLive.BL.LabourHours.ProjectTime.ProjectTime(projectTimeTDS);
            projectTime.Delete(projectTimeId, employeeId);
        }



        private void UpdateDatabase()
        {
            try
            {
                ProjectTimeGateway projectTimeGateway = new ProjectTimeGateway(projectTimeTDS);
                projectTimeGateway.Update();

                projectTimeTDS.AcceptChanges();

                Session["projectTimeTDS"] = projectTimeTDS;
            }
            catch (Exception ex)
            {
                string url = string.Format("./../../error_page.aspx?error={0}", ex.Message.Replace('\n', ' '));
                Response.Redirect(url);
            }
        }



        private void StoreNavigatorState()
        {
            ViewState["navigatorState"] = "&search_ddlCountry=" + Request.QueryString["search_ddlCountry"] + "&search_ddlClient=" + Request.QueryString["search_ddlClient"] + "&search_ddlProject=" + Request.QueryString["search_ddlProject"] + "&search_ddlTeamMember=" + Request.QueryString["search_ddlTeamMember"] + "&search_tkrdpStartDate=" + Request.QueryString["search_tkrdpStartDate"] + "&search_tkrdpEndDate=" + Request.QueryString["search_tkrdpEndDate"];
        }



        private string GetNavigatorState()
        {
            return (string)ViewState["navigatorState"];
        }



    }
}