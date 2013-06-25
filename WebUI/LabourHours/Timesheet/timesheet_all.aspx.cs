using System;
using System.Data;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.DA.Resources.Employees;
using LiquiForce.LFSLive.DA.LabourHours.Timesheet;
using LiquiForce.LFSLive.BL.LabourHours.Timesheet;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.LabourHours.Timesheet
{
    /// <summary>
    /// timesheet_all
    /// </summary>
    public partial class timesheet_all : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // PROPERTIES AND FIELDS
        //

        protected TimesheetAllTDS timesheetAllTDS;
        protected TimesheetAllTDS.TIMESHEET_ALLDataTable timesheetAll; 






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
                    if (Request.QueryString["others"] == "no")
                    {
                        if (!Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_MY_TIMESHEETS_VIEW"]))
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
                        if (!Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_MY_TIMESHEETS_VIEW"]))
                        {
                            if (!Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_MY_TIMESHEETS_MANAGEMENT"]))
                            {
                                if (!Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_MY_TIMESHEETS_MANAGEMENT_WED"]))
                                {
                                    if (!Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_OTHERS_TIMESHEETS_VIEW"]))
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

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) && ((string)Request.QueryString["others"] == null) && ((string)Request.QueryString["employee_id"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in timesheet_all.aspx");
                }

                // Tag page
                Session.Remove("timesheetAllDummy");

                // Initialize  variables
                lblError.Visible = false;

                ViewState["others"] = Request.QueryString["others"];
                if ((string)ViewState["others"] == "yes")
                {
                    ViewState["employee_id"] = int.Parse(Request.QueryString["employee_id"]);
                }
                else
                {
                    EmployeeGateway employeeGateway1 = new EmployeeGateway(new DataSet());
                    ViewState["employee_id"] = employeeGateway1.GetEmployeIdByLoginId(Convert.ToInt32(Session["loginID"]));
                }
                System.Configuration.AppSettingsReader appSettingReader = new System.Configuration.AppSettingsReader();
                ViewState["LHMode"] = appSettingReader.GetValue("LABOUR_HOURS_OPERATION_MODE", typeof(System.String)).ToString();

                // Prepare initial data for client
                // ... Title
                if ((string)ViewState["others"] == "no")
                {
                    lblTitle.Text = "All My Timesheets";
                }
                else
                {
                    EmployeeGateway employeeGateway = new EmployeeGateway(new DataSet());
                    employeeGateway.LoadByEmployeeId((int)ViewState["employee_id"]);
                    lblTitle.Text = "All Timesheets For " + employeeGateway.GetFullName((int)ViewState["employee_id"]);
                }

                // Load data
                timesheetAllTDS = this.SubmitSearch();
                Session["timesheetAllTDS"] = timesheetAllTDS;
                timesheetAll = timesheetAllTDS.TIMESHEET_ALL;
                Session["timesheetAll"] = timesheetAll;    
            }
            else
            {
                // Restore dataset
                timesheetAllTDS = (TimesheetAllTDS)Session["timesheetAllTDS"];
                timesheetAll = timesheetAllTDS.TIMESHEET_ALL;
                Session["timesheetAll"] = timesheetAll;
            }
        }



        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set active toolbar
            mForm6 master = (mForm6)this.Master;
            master.ActiveToolbar = "LabourHours";           

            // ... Labour Hours Mode
            if ((string)ViewState["LHMode"] == "Partial")
            {
                tkrpbLeftMenuMyTimesheets.Visible = false;
                tkrpbLeftMenuOthersTimesheets.Items[0].Text = "Timesheets";
                tkrpbLeftMenuTools.Items[0].Items[1].Visible = false;

                // Access control
                // ... Employees
                EmployeeListGateway employeeListGateway = new EmployeeListGateway(new DataSet());
                employeeListGateway.LoadByRequestProjectTime(1);

                DropDownList ddlOthersFor = (DropDownList)tkrpbLeftMenuOthersTimesheets.FindItemByValue("nbOthersTimesheetsDDL").FindControl("ddlOthersFor");
                ddlOthersFor.DataSource = employeeListGateway.Table;
                ddlOthersFor.DataValueField = "EmployeeID";
                ddlOthersFor.DataTextField = "FullName";
                ddlOthersFor.DataBind();
            }
            else
            {
                EmployeeGateway employeeGateway1 = new EmployeeGateway(new DataSet());
                int employeeId = employeeGateway1.GetEmployeIdByLoginId(Convert.ToInt32(Session["loginID"]));
                employeeGateway1.LoadByEmployeeId(employeeId);

                if (!employeeGateway1.GetApproveTimesheets(employeeId))
                {
                    tkrpbLeftMenuTools.Items[0].Items[1].Visible = false; // Timesheets To Approve
                }

                if (Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_OTHERS_TIMESHEETS_VIEW"]) || Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_OTHERS_TIMESHEETS_MANAGEMENT"]) || Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_OTHERS_TIMESHEETS_MANAGEMENT_WED"]) || Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_FULL_EDITING"]))
                {
                    tkrpbLeftMenuOthersTimesheets.Visible = true;
                    tkrpbLeftMenuTools.Items[0].Items[0].Visible = true; // Add Team Project Time
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
                }
                else
                {
                    tkrpbLeftMenuOthersTimesheets.Visible = false;

                    if (!employeeGateway1.GetApproveTimesheets(employeeId))
                    {
                        tkrpbLeftMenuTools.Visible = false;
                    }

                    tkrpbLeftMenuTools.Items[0].Items[0].Visible = false; // Add Team Project Time
                    tkrpbLeftMenuTools.Items[0].Items[2].Visible = false; // Missing Project Time
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
                        tkrpbLeftMenuReports.Visible = false;
                    }
                }
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // AUXILIAR EVENTS
        //

        protected void grdTimesheet_DataBound(object sender, EventArgs e)
        {
            AddTimesheetNewEmptyFix(grdTimesheetAll);
        }






        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATION EVENTS
        //

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
                    url = "./timesheet.aspx?source_page=lm&others=no";
                    break;


                case "nbMyTimesheetsViewAll":
                    lblError.Visible = false;
                    url = "./timesheet_all.aspx?source_page=lm&others=no";
                    break;
            }

            if (url != "") Response.Redirect(url);
        }

 

        protected void btnOpen_Click(object sender, EventArgs e)
        {
            DropDownList ddlOthersFor = (DropDownList)tkrpbLeftMenuOthersTimesheets.FindItemByValue("nbOthersTimesheetsDDL").FindControl("ddlOthersFor");
            Session["ddlOthersForSelectedValue"] = ddlOthersFor.SelectedValue;

            SaveSelectedId();
            int payPeriodId = Int32.Parse(hdfSelectedId.Value);

            if (payPeriodId != 0)
            {
                lblError.Visible = false;
                Response.Redirect("./timesheet.aspx?source_page=timesheet_all.aspx&others=" + ViewState["others"] + "&employee_id=" + ViewState["employee_id"] + "&period_id=" + payPeriodId);
            }
            else
            {
                lblError.Visible = true;
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        //  PUBLIC METHODS
        //

        public TimesheetAllTDS.TIMESHEET_ALLDataTable GetTimesheets()
        {
            timesheetAll = (TimesheetAllTDS.TIMESHEET_ALLDataTable)Session["timesheetAllDummy"];
            if (timesheetAll == null)
            {
                timesheetAll = ((TimesheetAllTDS.TIMESHEET_ALLDataTable)Session["timesheetAll"]);
            }

            return timesheetAll;
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
            this.ClientScript.RegisterClientScriptInclude("clientSideCode1", "./timesheet_all.js");
        }



        private TimesheetAllTDS SubmitSearch()
        {
            // Retrive parameters
            int employeeId = (int)ViewState["employee_id"];

            // Load data
            TimesheetAllTDS dataSet = new TimesheetAllTDS();
            TimesheetAllGateway timesheetAllGateway = new TimesheetAllGateway(dataSet);
            timesheetAllGateway.LoadByEmployeeId(employeeId);

            return dataSet;
        }



        protected void AddTimesheetNewEmptyFix(GridView grdTimesheetAll)
        {
            if (grdTimesheetAll.Rows.Count == 0)
            {
                TimesheetAllTDS.TIMESHEET_ALLDataTable dt = new TimesheetAllTDS.TIMESHEET_ALLDataTable();
                dt.AddTIMESHEET_ALLRow("", DateTime.Now, DateTime.Now, -1, false);
                Session["timesheetAllDummy"] = dt;

                grdTimesheetAll.DataBind();
            }

            // normally executes at all postbacks
            if (grdTimesheetAll.Rows.Count == 1)
            {
                TimesheetAllTDS.TIMESHEET_ALLDataTable dt = (TimesheetAllTDS.TIMESHEET_ALLDataTable)Session["timesheetAllDummy"];
                if (dt != null)
                {
                    grdTimesheetAll.Rows[0].Visible = false;
                    grdTimesheetAll.Rows[0].Controls.Clear();
                }
            }
        }



        protected void SaveSelectedId()
        {
            int idForUpdate = 0;
            bool selected = false;
            hdfSelectedId.Value = "0";

            TimesheetAll timesheetAllForUpdate = new TimesheetAll(timesheetAllTDS);

            foreach (GridViewRow row in grdTimesheetAll.Rows)
            {
                // ... Update all rows
                selected = ((CheckBox)row.FindControl("cbxSelected")).Checked;
                idForUpdate = Int32.Parse(((Label)row.FindControl("lblPayPeriodID")).Text.Trim());
                timesheetAllForUpdate.Update(idForUpdate, selected);

                // ... Save selected id
                if (selected)
                {
                    hdfSelectedId.Value = idForUpdate.ToString();
                }
            }
            timesheetAllForUpdate.Data.AcceptChanges();

            // ... Store datasets
            Session["timesheetAll"] = timesheetAllTDS.TIMESHEET_ALL;
        }

        

    }
}