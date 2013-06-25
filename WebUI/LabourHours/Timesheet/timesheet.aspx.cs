using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.DA.Resources.Employees;
using LiquiForce.LFSLive.DA.LabourHours.PayPeriod;
using LiquiForce.LFSLive.DA.LabourHours.Timesheet;
using LiquiForce.LFSLive.BL.LabourHours.Timesheet;
using System.Collections.Generic;
using LiquiForce.LFSLive.BL.Resources.Employees;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.LabourHours.Timesheet
{
    /// <summary>
    /// timesheet
    /// </summary>
    public partial class timesheet : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // PROPERTIES AND FIELDS
        //

        protected TimesheetNavigatorTDS timesheetNavigatorTDS;
        protected TimesheetNavigatorTDS.LFS_PROJECT_TIMEDataTable timesheetNavigator; 






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
                if (!Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_FULL_EDITING"]))
                {
                    if (!Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_MY_TIMESHEETS_VIEW"]) && !Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_OTHERS_TIMESHEETS_VIEW"]) && !Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_MY_TIMESHEETS_MANAGEMENT"]) && !Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_MY_TIMESHEETS_MANAGEMENT_WED"]) && !Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_OTHERS_TIMESHEETS_MANAGEMENT"]) && !Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_OTHERS_TIMESHEETS_MANAGEMENT_WED"]))
                    {
                        Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                    }                    
                }

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) && ((string)Request.QueryString["others"] == null) && ((string)Request.QueryString["employee_id"] == null) && ((string)Request.QueryString["period_id"] == null) && ((string)Request.QueryString["projecttime_id"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in timesheet.aspx");
                }

                // Tag page
                Session.Remove("timesheetNavigatorDummy");

                // Initialize  variables
                lblError.Visible = false;

                // ... Labour Hours Mode
                System.Configuration.AppSettingsReader appSettingReader = new System.Configuration.AppSettingsReader();
                ViewState["LHMode"] = appSettingReader.GetValue("LABOUR_HOURS_OPERATION_MODE", typeof(System.String)).ToString();

                // ... If coming from out
                if ((string)Request.QueryString["source_page"] == "out")
                {
                    Session.Remove("ddlOthersForSelectedValue");

                    // Store search parameters
                    ViewState["current"] = "yes";
                    if (Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_OTHERS_TIMESHEETS_VIEW"]) || Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_OTHERS_TIMESHEETS_MANAGEMENT"]) || Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_OTHERS_TIMESHEETS_MANAGEMENT_WED"]) || Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_FULL_EDITING"]))
                    {
                        ViewState["others"] = "yes";
                    }
                    else
                    {
                        ViewState["others"] = "no";
                    }

                    EmployeeGateway employeeGateway1 = new EmployeeGateway(new DataSet());
                    ViewState["employee_id"] = employeeGateway1.GetEmployeIdByLoginId(Convert.ToInt32(Session["loginID"]));
                   
                    PayPeriodGateway payPeriodGateway = new PayPeriodGateway(new DataSet());
                    ViewState["period_id"] = payPeriodGateway.GetPayPeriodId(DateTime.Now);

                    if (Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_AUTOREPORT"]))
                    {
                        string script = "<script language='javascript'>";
                        script += "window.open('./../projecttime/timesheet_missing.aspx?source_page=timesheet.aspx', '_blank', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=550, height=420')";
                        script += "</script>";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Report", script, false);
                    }
                }

                // ... If coming from left menu
                if ((string)Request.QueryString["source_page"] == "lm")
                {
                    // Store search parameters
                    ViewState["current"] = "yes";
                    ViewState["others"] = Request.QueryString["others"];
                  
                    if (Request.QueryString["others"] == "yes")
                    {
                        ViewState["employee_id"] = int.Parse((string)Request.QueryString["employee_id"]);
                    }
                    else
                    {
                        EmployeeGateway employeeGateway1 = new EmployeeGateway(new DataSet());
                        ViewState["employee_id"] = employeeGateway1.GetEmployeIdByLoginId(Convert.ToInt32(Session["loginID"]));
                    }
                   
                    PayPeriodGateway payPeriodGateway = new PayPeriodGateway(new DataSet());
                    ViewState["period_id"] = payPeriodGateway.GetPayPeriodId(DateTime.Now);
                }

                // ... If coming from timesheet_all.aspx
                if ((string)Request.QueryString["source_page"] == "timesheet_all.aspx")
                {
                    // Store search parameters
                    PayPeriodGateway payPeriodGateway = new PayPeriodGateway(new DataSet());
                    int currentPeriod = payPeriodGateway.GetCurrent();
                   
                    if (currentPeriod == int.Parse((string)Request.QueryString["period_id"]))
                    {
                        ViewState["current"] = "yes";
                    }
                    else
                    {
                        ViewState["current"] = "no";
                    }
                    
                    ViewState["others"] = Request.QueryString["others"];
                    ViewState["employee_id"] = int.Parse((string)Request.QueryString["employee_id"]);
                    ViewState["period_id"] = int.Parse((string)Request.QueryString["period_id"]);
                }

                // ... If coming from timesheet.aspx
                if ((string)Request.QueryString["source_page"] == "timesheet.aspx")
                {
                    // Store search parameters
                    PayPeriodGateway payPeriodGateway = new PayPeriodGateway(new DataSet());
                    int currentPeriod = payPeriodGateway.GetCurrent();
                    
                    if (currentPeriod == int.Parse((string)Request.QueryString["period_id"]))
                    {
                        ViewState["current"] = "yes";
                    }
                    else
                    {
                        ViewState["current"] = "no";
                    }
                    
                    ViewState["others"] = Request.QueryString["others"];
                    ViewState["employee_id"] = int.Parse((string)Request.QueryString["employee_id"]);
                    ViewState["period_id"] = int.Parse((string)Request.QueryString["period_id"]);

                    if (Session["OpenTimesheetMissing"] == null)
                    {
                        if (Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_AUTOREPORT"]))
                        {
                            string script = "<script language='javascript'>";
                            script += "window.open('./../projecttime/timesheet_missing.aspx?source_page=timesheet.aspx', '_blank', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=550, height=420')";
                            script += "</script>";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Report", script, false);
                        }
                    }
                }

                // ... If coming from timesheet_summary.aspx, timesheet_add.aspx, timesheet_edit.aspx, timesheet_delete.aspx or timesheet_state.aspx
                if (((string)Request.QueryString["source_page"] == "timesheet_summary.aspx") || ((string)Request.QueryString["source_page"] == "timesheet_add.aspx") || ((string)Request.QueryString["source_page"] == "timesheet_edit.aspx") || ((string)Request.QueryString["source_page"] == "timesheet_delete.aspx") || ((string)Request.QueryString["source_page"] == "timesheet_state.aspx"))
                {
                    // Store search parameters
                    PayPeriodGateway payPeriodGateway = new PayPeriodGateway(new DataSet());
                    int currentPeriod = payPeriodGateway.GetCurrent();
                    
                    if (currentPeriod == int.Parse((string)Request.QueryString["period_id"]))
                    {
                        ViewState["current"] = "yes";
                    }
                    else
                    {
                        ViewState["current"] = "no";
                    }
                    
                    ViewState["others"] = Request.QueryString["others"];
                    ViewState["employee_id"] = int.Parse((string)Request.QueryString["employee_id"]);
                    ViewState["period_id"] = int.Parse((string)Request.QueryString["period_id"]);
                }

                // ... If coming from timesheet_approve.aspx
                if ((string)Request.QueryString["source_page"] == "timesheet_approve.aspx")
                {
                    // Store search parameters
                    PayPeriodGateway payPeriodGateway = new PayPeriodGateway(new DataSet());
                    int currentPeriod = payPeriodGateway.GetCurrent();
                    EmployeeGateway employeeGateway1 = new EmployeeGateway(new DataSet());
                    
                    ViewState["current"] = "yes";
                    ViewState["others"] = "yes";
                    ViewState["employee_id"] = employeeGateway1.GetEmployeIdByLoginId(Convert.ToInt32(Session["loginID"]));
                    ViewState["period_id"] = currentPeriod;
                }
                                
                // Access control
                // ... Employees
                EmployeeListGateway employeeListGateway = new EmployeeListGateway(new DataSet());

                if (!Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_FULL_EDITING"]))
                {
                    employeeListGateway.LoadByRequestProjectTimeWithoutEmployeeId(1, (int)ViewState["employee_id"]);
                }
                else
                {
                    employeeListGateway.LoadByRequestProjectTime(1);
                }

                DropDownList ddlOthersFor = (DropDownList)tkrpbLeftMenuOthersTimesheets.FindItemByValue("nbOthersTimesheetsDDL").FindControl("ddlOthersFor");
                ddlOthersFor.DataSource = employeeListGateway.Table;
                ddlOthersFor.DataValueField = "EmployeeID";
                ddlOthersFor.DataTextField = "FullName";
                ddlOthersFor.DataBind();
                
                // ... Title
                EmployeeGateway employeeGateway = new EmployeeGateway(new DataSet());

                if ((int)ViewState["employee_id"] != 0)
                {
                    employeeGateway.LoadByEmployeeId((int)ViewState["employee_id"]);
                    if ((string)ViewState["others"] == "no")
                    {
                        if ((Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_MY_TIMESHEETS_VIEW"]) || Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_MY_TIMESHEETS_MANAGEMENT"]) || Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_MY_TIMESHEETS_MANAGEMENT_WED"]) || Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_FULL_EDITING"])) && (employeeGateway.GetRequestProjectTime((int)ViewState["employee_id"])))
                        {
                            if ((string)ViewState["current"] == "yes")
                            {
                                lblTitle.Text = "Current Timesheet For " + employeeGateway.GetFullName((int)ViewState["employee_id"]);
                            }
                            else
                            {
                                PayPeriodGateway payPeriodGateway = new PayPeriodGateway(new DataSet());
                                payPeriodGateway.LoadByPayPeriodId((int)ViewState["period_id"]);
                                lblTitle.Text = "Timesheet For " + employeeGateway.GetFullName((int)ViewState["employee_id"]) + " From " + payPeriodGateway.GetStartDate((int)ViewState["period_id"]).ToShortDateString() + " To " + payPeriodGateway.GetEndDate((int)ViewState["period_id"]).ToShortDateString();
                            }
                        }
                        else
                        {
                            Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                        }
                    }
                    else
                    {
                        EmployeeGateway employeeGateway1 = new EmployeeGateway(new DataSet());
                        int employeeIdNow = employeeGateway1.GetEmployeIdByLoginId(Convert.ToInt32(Session["loginID"]));

                        if ((int)ViewState["employee_id"] == employeeIdNow)
                        {
                            if (((Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_MY_TIMESHEETS_VIEW"]) || Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_MY_TIMESHEETS_MANAGEMENT"]) || Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_MY_TIMESHEETS_MANAGEMENT_WED"]) || Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_FULL_EDITING"])) && (employeeGateway.GetRequestProjectTime((int)ViewState["employee_id"]))))
                            {
                                if ((string)ViewState["current"] == "yes")
                                {
                                    lblTitle.Text = "Current Timesheet For " + employeeGateway.GetFullName((int)ViewState["employee_id"]);
                                }
                                else
                                {
                                    PayPeriodGateway payPeriodGateway = new PayPeriodGateway(new DataSet());
                                    payPeriodGateway.LoadByPayPeriodId((int)ViewState["period_id"]);
                                    lblTitle.Text = "Timesheet For " + employeeGateway.GetFullName((int)ViewState["employee_id"]) + " From " + payPeriodGateway.GetStartDate((int)ViewState["period_id"]).ToShortDateString() + " To " + payPeriodGateway.GetEndDate((int)ViewState["period_id"]).ToShortDateString();
                                }
                            }
                            else
                            {
                                if (ddlOthersFor.Items.Count > 0)
                                {
                                    Session["ddlOthersForSelectedValue"] = ddlOthersFor.SelectedValue;
                                    Response.Redirect("./timesheet.aspx?source_page=timesheet.aspx&others=yes&employee_id=" + ddlOthersFor.SelectedValue + "&period_id=" + ((int)ViewState["period_id"]).ToString());
                                }
                                else
                                {
                                    Response.Redirect("./../../error_page.aspx?error=" + "No team members with 'Request Timesheet' property are defined in the system. Contact your system administrator for further assistance.");
                                }
                            }
                        }
                        else
                        {
                            if ((string)ViewState["current"] == "yes")
                            {
                                lblTitle.Text = "Current Timesheet For " + employeeGateway.GetFullName((int)ViewState["employee_id"]);
                            }
                            else
                            {
                                PayPeriodGateway payPeriodGateway = new PayPeriodGateway(new DataSet());
                                payPeriodGateway.LoadByPayPeriodId((int)ViewState["period_id"]);
                                lblTitle.Text = "Timesheet For " + employeeGateway.GetFullName((int)ViewState["employee_id"]) + " From " + payPeriodGateway.GetStartDate((int)ViewState["period_id"]).ToShortDateString() + " To " + payPeriodGateway.GetEndDate((int)ViewState["period_id"]).ToShortDateString();
                            }
                        }
                    }
                }
                else
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You cannot use the Labour Hours subsystem since you are not registered as a team member in LFS Live. Please contact your system administrator for further assistance."); ;
                }

                // Load data
                timesheetNavigatorTDS = this.SubmitSearch();
                Session["timesheetNavigatorTDS"] = timesheetNavigatorTDS;
                timesheetNavigator = timesheetNavigatorTDS.LFS_PROJECT_TIME;
                Session["timesheetNavigator"] = timesheetNavigator;

                // Set Total project time
                TimesheetNavigator timesheetNavigatorForTotal = new TimesheetNavigator(timesheetNavigatorTDS);
                tbxTotalCost.Text = timesheetNavigatorForTotal.GetTotalProjectTime().ToString();
            }
            else
            {
                // Restore dataset
                timesheetNavigatorTDS = (TimesheetNavigatorTDS)Session["timesheetNavigatorTDS"];
                timesheetNavigator = timesheetNavigatorTDS.LFS_PROJECT_TIME;

                // Store datase
                Session["timesheetNavigator"] = timesheetNavigator;
            }
        }



        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set active toolbar
            mForm6 master = (mForm6)this.Master;
            master.ActiveToolbar = "LabourHours";           

            // ... Labour Hours Mode
            if ((string)ViewState["LHMode"] == "Full")
            {
                EmployeeGateway employeeGateway1 = new EmployeeGateway(new DataSet());
                int employeeId = employeeGateway1.GetEmployeIdByLoginId(Convert.ToInt32(Session["loginID"]));
                employeeGateway1.LoadByEmployeeId(employeeId);

                Employee employee = new Employee();

                if (employee.IsValidApproveTimesheetsManager((int)ViewState["employee_id"], employeeId))
                {
                    TimesheetNavigator timesheetNavigator = new TimesheetNavigator(timesheetNavigatorTDS);
                    if (timesheetNavigator.Table.Rows.Count > 0)
                    {
                        tkrmTop.Items[1].Visible = true; // Timesheets To Approve
                    }
                    else
                    {
                        tkrmTop.Items[1].Visible = false; // Timesheets To Approve
                    }
                }
                else
                {
                    tkrmTop.Items[1].Visible = false; // Timesheets To Approve
                }

                if (!employeeGateway1.GetApproveTimesheets(employeeId))
                {
                    tkrpbLeftMenuTools.Items[0].Items[1].Visible = false; ;//tkrpbLeftMenuTools.Items[1].Visible = false; // Approve Project Times
                }

                if (Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_OTHERS_TIMESHEETS_VIEW"]) || Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_OTHERS_TIMESHEETS_MANAGEMENT"]) || Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_OTHERS_TIMESHEETS_MANAGEMENT_WED"]) || Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_FULL_EDITING"]))
                {
                    tkrpbLeftMenuOthersTimesheets.Visible = true;
                    tkrpbLeftMenuTools.Items[0].Items[0].Visible = true; //.Items[0].Visible = true; // Add Team Project Time
                    tkrpbLeftMenuTools.Items[0].Items[2].Visible = true; // Missing Project Time

                    // Access control
                    // ... Employees
                    EmployeeListGateway employeeListGateway = new EmployeeListGateway(new DataSet());

                    if (!Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_FULL_EDITING"]))
                    {
                        employeeListGateway.LoadByRequestProjectTimeWithoutEmployeeId(1, employeeId);
                    }
                    else
                    {
                        employeeListGateway.LoadByRequestProjectTime(1);
                    }

                    DropDownList ddlOthersFor = (DropDownList)tkrpbLeftMenuOthersTimesheets.FindItemByValue("nbOthersTimesheetsDDL").FindControl("ddlOthersFor");
                    ddlOthersFor.DataSource = employeeListGateway.Table;
                    ddlOthersFor.DataValueField = "EmployeeID";
                    ddlOthersFor.DataTextField = "FullName";
                    ddlOthersFor.DataBind();
                    try
                    {
                        ddlOthersFor.SelectedValue = Session["ddlOthersForSelectedValue"].ToString();
                    }
                    catch
                    {
                    }

                    ViewState["others"] = "yes";
                }
                else
                {
                    tkrpbLeftMenuOthersTimesheets.Visible = false;

                    if (!employeeGateway1.GetApproveTimesheets(employeeId))
                    {
                        tkrpbLeftMenuTools.Visible = false;
                    }

                    tkrpbLeftMenuTools.Items[0].Items[0].Visible = false;//tkrpbLeftMenuTools.Items[0].Visible = false; // Add Team Project Time
                    tkrpbLeftMenuTools.Items[0].Items[2].Visible = false;//tkrpbLeftMenuTools.Items[2].Visible = false; // Missing Project Time
                }

                if (!((Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_MY_TIMESHEETS_VIEW"]) || Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_MY_TIMESHEETS_MANAGEMENT"]) || Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_MY_TIMESHEETS_MANAGEMENT_WED"]) || Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_FULL_EDITING"])) && (employeeGateway1.GetRequestProjectTime(employeeId))))
                {
                    tkrpbLeftMenuMyTimesheets.Visible = false;
                    tkrpbLeftMenuOthersTimesheets.Items[0].Text = "Timesheets";
                }

                if (!Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_FULL_EDITING"]))
                {
                    if (!Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_REPORTS"]))
                    {
                        // View Reports
                        tkrpbLeftMenuReports.Visible = false;
                    }
                }                
            }
            else
            {
                // Left menu
                tkrpbLeftMenuMyTimesheets.Visible = false;
                tkrpbLeftMenuOthersTimesheets.Items[0].Text = "Timesheets";
                tkrpbLeftMenuTools.Items[0].Items[1].Visible = false;//tkrpbLeftMenuTools.Items[1].Visible = false; // Timesheets To Approve

                // Top menu
                tkrmTop.Items[0].Visible = true;
                tkrmTop.Items[1].Visible = false;

                // Grid options
                btnEdit.Visible = true;
                btnDelete.Visible = true;
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // AUXILIAR EVENTS
        //

        protected void cvTitle_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = ((int)ViewState["employee_id"] != 0) ? true : false;
        }



        protected void grdTimesheet_DataBound(object sender, EventArgs e)
        {
            AddTimesheetNewEmptyFix(grdTimesheet);
        }





                
        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATION EVENTS
        //

        protected void tkrmTop_ItemClick(object sender, RadMenuEventArgs e)
        {
            DropDownList ddlOthersFor = (DropDownList)tkrpbLeftMenuOthersTimesheets.FindItemByValue("nbOthersTimesheetsDDL").FindControl("ddlOthersFor");
            Session["ddlOthersForSelectedValue"] = ddlOthersFor.SelectedValue;

            string url = "";

            switch (e.Item.Value)
            {
                case "mAddProjectTime":
                    url = "./../projecttime/timesheet_add.aspx?source_page=timesheet.aspx&others=" + ViewState["others"] + "&employee_id=" + ViewState["employee_id"] + "&period_id=" + ViewState["period_id"];
                    break;
                
                case "mApproveTimesheet":
                    int numOfProjectTimesSelected = PostPageChanges();

                    if (numOfProjectTimesSelected > 0)
                    {
                        url = "./../projecttime/timesheet_state.aspx?source_page=timesheet.aspx&others=" + ViewState["others"] + "&employee_id=" + ViewState["employee_id"] + "&period_id=" + ViewState["period_id"];
                    }
                    break;
            }

            if (!string.IsNullOrEmpty(url))
            {
                Response.Redirect(url);
            }
        }



        protected void tkrpbLeftMenu_ItemClick(object sender, RadPanelBarEventArgs e)
        {
            DropDownList ddlOthersFor = (DropDownList)tkrpbLeftMenuOthersTimesheets.FindItemByValue("nbOthersTimesheetsDDL").FindControl("ddlOthersFor");
            Session["ddlOthersForSelectedValue"] = ddlOthersFor.SelectedValue;

            string url = "";

            switch (e.Item.Value)
            {
                case "nbTimesheetsToolsApproveProjectTimes":
                    url = "./../projecttime/timesheet_approve.aspx?source_page=lm&others=yes";
                    break;

                case "nbOthersTimesheetsViewCurrent":
                    lblError.Visible = false;
                    if (ddlOthersFor.SelectedIndex >= 0)
                    {
                        Response.Redirect("./timesheet.aspx?source_page=lm&others=yes&employee_id=" + ddlOthersFor.SelectedValue);
                    }
                    break;

                case "nbOthersTimesheetsViewAll":
                    lblError.Visible = false;
                    if (ddlOthersFor.SelectedIndex >= 0)
                    {
                        Response.Redirect("./timesheet_all.aspx?source_page=lm&others=yes&employee_id=" + ddlOthersFor.SelectedValue);
                    }
                    break;

                case "nbMyTimesheetsViewCurrent":
                    lblError.Visible = false;
                    url = "./../timesheet/timesheet.aspx?source_page=lm&others=no";
                    break;

                case "nbMyTimesheetsViewAll":
                    lblError.Visible = false;
                    url = "./../timesheet/timesheet_all.aspx?source_page=lm&others=no";
                    break;
            }

            if (url != "") Response.Redirect(url);
        }



        protected void btnOpen_Click(object sender, EventArgs e)
        {
            int numOfProjectTimesSelected = SaveSelectedId();            
            int projectTimeId = Int32.Parse(hdfSelectedProjectTimeId.Value);

            DropDownList ddlOthersFor = (DropDownList)tkrpbLeftMenuOthersTimesheets.FindItemByValue("nbOthersTimesheetsDDL").FindControl("ddlOthersFor");
            Session["ddlOthersForSelectedValue"] = ddlOthersFor.SelectedValue;
            
            if (projectTimeId != 0)
            {
                if (numOfProjectTimesSelected == 1)
                {
                    lblError.Visible = false;
                    Response.Redirect("./../projecttime/timesheet_summary.aspx?source_page=timesheet.aspx&others=" + ViewState["others"] + "&employee_id=" + ViewState["employee_id"] + "&period_id=" + ViewState["period_id"] + "&projecttime_id=" + projectTimeId);
                }
                else
                {
                    lblError.Text = "Please select only one project time to open.";
                    lblError.Visible = true;
                }
            }
            else
            {
                lblError.Visible = true;
            }
        }



        protected void btnEdit_Click(object sender, EventArgs e)
        {
            int numOfProjectTimesSelected = SaveSelectedId();            
            int projectTimeId = Int32.Parse(hdfSelectedProjectTimeId.Value);

            DropDownList ddlOthersFor = (DropDownList)tkrpbLeftMenuOthersTimesheets.FindItemByValue("nbOthersTimesheetsDDL").FindControl("ddlOthersFor");
            Session["ddlOthersForSelectedValue"] = ddlOthersFor.SelectedValue;
            
            if (projectTimeId != 0)
            {
                if (numOfProjectTimesSelected == 1)
                {
                    lblError.Visible = false;
                    Response.Redirect("./../projecttime/timesheet_edit.aspx?source_page=timesheet.aspx&others=" + ViewState["others"] + "&employee_id=" + ViewState["employee_id"] + "&period_id=" + ViewState["period_id"] + "&projecttime_id=" + projectTimeId);
                }
                else
                {
                    lblError.Text = "Please select only one project time to edit.";
                    lblError.Visible = true;
                }
            }
            else
            {
                lblError.Visible = true;
            }
        }



        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int numOfProjectTimesSelected = SaveSelectedId();            
            int projectTimeId = Int32.Parse(hdfSelectedProjectTimeId.Value);

            DropDownList ddlOthersFor = (DropDownList)tkrpbLeftMenuOthersTimesheets.FindItemByValue("nbOthersTimesheetsDDL").FindControl("ddlOthersFor");
            Session["ddlOthersForSelectedValue"] = ddlOthersFor.SelectedValue;
            
            if (projectTimeId != 0)
            {
                if (numOfProjectTimesSelected == 1)
                {
                    lblError.Visible = false;
                    Response.Redirect("./../projecttime/timesheet_delete.aspx?source_page=timesheet.aspx&others=" + ViewState["others"] + "&employee_id=" + ViewState["employee_id"] + "&period_id=" + ViewState["period_id"] + "&projecttime_id=" + projectTimeId);
                }
                else
                {
                    lblError.Text = "Please select only one project time to delete.";
                    lblError.Visible = true;
                }
            }
            else
            {
                lblError.Visible = true;
            } 
        }



        protected void btnPriorTimesheet_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;

            DropDownList ddlOthersFor = (DropDownList)tkrpbLeftMenuOthersTimesheets.FindItemByValue("nbOthersTimesheetsDDL").FindControl("ddlOthersFor");
            Session["ddlOthersForSelectedValue"] = ddlOthersFor.SelectedValue;

            PayPeriodGateway priorPayPeriodGateway = new PayPeriodGateway();
            int priorPayPeriodId = priorPayPeriodGateway.GetPriorPayPeriodId((int)ViewState["period_id"]);
            
            if (priorPayPeriodId > 0)
            {
                Response.Redirect("./timesheet.aspx?source_page=timesheet.aspx&others=" + ViewState["others"] + "&employee_id=" + ViewState["employee_id"] + "&period_id=" + priorPayPeriodId.ToString());
            }
        }


        
        protected void btnNextTimesheet_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;
            
            if ((string)ViewState["current"] == "no")
            {
                DropDownList ddlOthersFor = (DropDownList)tkrpbLeftMenuOthersTimesheets.FindItemByValue("nbOthersTimesheetsDDL").FindControl("ddlOthersFor");
                Session["ddlOthersForSelectedValue"] = ddlOthersFor.SelectedValue;

                PayPeriodGateway nextPayPeriodGateway = new PayPeriodGateway();
                int nextPayPeriodId = nextPayPeriodGateway.GetNextPayPeriodId((int)ViewState["period_id"]);
                
                if (nextPayPeriodId > 0)
                {
                    Response.Redirect("./timesheet.aspx?source_page=timesheet.aspx&others=" + ViewState["others"] + "&employee_id=" + ViewState["employee_id"] + "&period_id=" + nextPayPeriodId.ToString());
                }
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        //  PUBLIC METHODS
        //

        public TimesheetNavigatorTDS.LFS_PROJECT_TIMEDataTable GetTimesheets()
        {
            timesheetNavigator = (TimesheetNavigatorTDS.LFS_PROJECT_TIMEDataTable)Session["timesheetNavigatorDummy"];
            if (timesheetNavigator == null)
            {
                timesheetNavigator = ((TimesheetNavigatorTDS.LFS_PROJECT_TIMEDataTable)Session["timesheetNavigator"]);
            }

            return timesheetNavigator;
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
            this.ClientScript.RegisterClientScriptInclude("clientSideCode1", "./timesheet.js");
        }



        private TimesheetNavigatorTDS SubmitSearch()
        {
            // Load data
            TimesheetNavigatorGateway timesheetNavigatorGateway = new TimesheetNavigatorGateway();
            timesheetNavigatorGateway.LoadByEmployeIdPayPeriodId((int)ViewState["employee_id"], (int)ViewState["period_id"]);

            return (TimesheetNavigatorTDS)timesheetNavigatorGateway.Data;
        }


        
        private int PostPageChanges()
        {
            int numOfProjectTimesSelected = 0;

            // Clear the projectTimesIdSelected list
            Session.Remove("projectTimesIdSelected");

            bool selected = false;
            int projectTimeId = 0;
            
            List<int> projectTimesIdSelected = new List<int>();
                 
            foreach (GridViewRow row in grdTimesheet.Rows)
            {
                // ... Update all rows
                selected = ((CheckBox)row.FindControl("cbxSelected")).Checked;
                projectTimeId = Int32.Parse(((Label)row.FindControl("lblProjectTimeID")).Text.Trim());
                
                // ... Save selecteds project times id
                if (selected)
                {
                    numOfProjectTimesSelected++;
                    projectTimesIdSelected.Add(projectTimeId);
                }
            }

            // ... Store project times id list
            Session["projectTimesIdSelected"] = projectTimesIdSelected;

            return numOfProjectTimesSelected;
        }



        protected void AddTimesheetNewEmptyFix(GridView grdTimesheet)
        {
            if (grdTimesheet.Rows.Count == 0)
            {
                TimesheetNavigatorTDS.LFS_PROJECT_TIMEDataTable dt = new TimesheetNavigatorTDS.LFS_PROJECT_TIMEDataTable();
                dt.AddLFS_PROJECT_TIMERow(-1, -1, -1, DateTime.Now, -1, false, "", "", "", DateTime.Now, DateTime.Now, false, "");
                Session["timesheetNavigatorDummy"] = dt;

                grdTimesheet.DataBind();
            }

            // normally executes at all postbacks
            if (grdTimesheet.Rows.Count == 1)
            {
                TimesheetNavigatorTDS.LFS_PROJECT_TIMEDataTable dt = (TimesheetNavigatorTDS.LFS_PROJECT_TIMEDataTable)Session["timesheetNavigatorDummy"];
                if (dt != null)
                {
                    grdTimesheet.Rows[0].Visible = false;
                    grdTimesheet.Rows[0].Controls.Clear();
                }
            }
        }



        protected int SaveSelectedId()
        {
            int numOfProjectTimesSelected = 0;
            int idForUpdate = 0;
            bool selected = false;
            hdfSelectedProjectTimeId.Value = "0";

            TimesheetNavigator timesheetNavigatorForUpdate = new TimesheetNavigator(timesheetNavigatorTDS);

            foreach (GridViewRow row in grdTimesheet.Rows)
            {
                // ... Update all rows
                selected = ((CheckBox)row.FindControl("cbxSelected")).Checked;
                idForUpdate = Int32.Parse(((Label)row.FindControl("lblProjectTimeID")).Text.Trim());
                timesheetNavigatorForUpdate.Update(idForUpdate, selected);

                // ... Save selected project
                if (selected)
                {
                    hdfSelectedProjectTimeId.Value = idForUpdate.ToString();
                    numOfProjectTimesSelected++;
                }
            }

            timesheetNavigatorForUpdate.Data.AcceptChanges();

            // ... Store datasets
            Session["timesheetNavigator"] = timesheetNavigatorTDS.LFS_PROJECT_TIME;

            return numOfProjectTimesSelected;
        }

     

    }
}