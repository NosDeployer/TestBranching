using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.DA.Resources.Companies;
using LiquiForce.LFSLive.DA.Company.Organization;
using LiquiForce.LFSLive.DA.Resources.Employees;
using LiquiForce.LFSLive.DA.FleetManagement.Units;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.DA.LabourHours.ProjectTime;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime
{
    /// <summary>
    /// timesheet_summary
    /// </summary>
    public partial class timesheet_summary : System.Web.UI.Page
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
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in timesheet_summary.aspx");
                }

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

                // Initialize viewstate's variables
                ViewState["others"] = Request.QueryString["others"];
                ViewState["employee_id"] = int.Parse(Request.QueryString["employee_id"]);
                ViewState["period_id"] = int.Parse(Request.QueryString["period_id"]);
                ViewState["projecttime_id"] = int.Parse(Request.QueryString["projecttime_id"]);
                System.Configuration.AppSettingsReader appSettingReader = new System.Configuration.AppSettingsReader();
                ViewState["LHMode"] = appSettingReader.GetValue("LABOUR_HOURS_OPERATION_MODE", typeof(System.String)).ToString();

                // Get ProjectTime record
                projectTimeTDS =  new ProjectTimeTDS();

                ProjectTimeGateway projectTimeGateway = new ProjectTimeGateway(projectTimeTDS);
                projectTimeGateway.LoadByProjectTimeId((int)ViewState["projecttime_id"]);

                // Store datasets
                Session["projectTimeTDS"] = projectTimeTDS;

                // Databind
                tbxDate.DataBind();
                tbxWorkingDetails.DataBind();
                tbxStartTime.DataBind();
                tbxEndTime.DataBind();
                tbxLunch.DataBind();
                tbxComments.DataBind();
                tbxState.DataBind();

                // Prepare initial data for client
                StoreNavigatorState();

                EmployeeGateway employeeGateway = new EmployeeGateway(new DataSet());
                employeeGateway.LoadByEmployeeId((int)ViewState["employee_id"]);
                tbxEmployee.Text = employeeGateway.GetFullName((int)ViewState["employee_id"]);

                int companyId = Int32.Parse(Session["companyID"].ToString());
                
                CompaniesGateway companiesGateway = new CompaniesGateway(new DataSet());
                companiesGateway.LoadAllByCompaniesId(projectTimeGateway.GetCompaniesId((int)ViewState["projecttime_id"]), companyId);
                tbxClient.Text = companiesGateway.GetName(projectTimeGateway.GetCompaniesId((int)ViewState["projecttime_id"]));

                ProjectGateway projectGateway = new ProjectGateway(new DataSet());
                projectGateway.LoadByProjectId(projectTimeGateway.GetProjectId((int)ViewState["projecttime_id"]));
                tbxProject.Text = projectGateway.GetName(projectTimeGateway.GetProjectId((int)ViewState["projecttime_id"])) + "(" + projectGateway.GetProjectNumber(projectTimeGateway.GetProjectId((int)ViewState["projecttime_id"])) + ")";

                if (projectGateway.GetFairWageApplies(projectTimeGateway.GetProjectId((int)ViewState["projecttime_id"])))
                {
                    tbxJobClassType.Visible = true;
                    lblJobClassType.Visible = true;
                    tbxJobClassType.Text = projectTimeGateway.GetJobClassType((int)ViewState["projecttime_id"]);
                }
                else
                {
                    tbxJobClassType.Visible = false;
                    lblJobClassType.Visible = false;
                }

                if (projectTimeGateway.GetMealsCountry((int)ViewState["projecttime_id"]).HasValue)
                {
                    CountryGateway countryGateway = new CountryGateway(new DataSet());
                    countryGateway.LoadByCountryId((Int64)projectTimeGateway.GetMealsCountry((int)ViewState["projecttime_id"]));
                    tbxMealsCountry.Text = countryGateway.GetName((Int64)projectTimeGateway.GetMealsCountry((int)ViewState["projecttime_id"]));
                }

                //if (projectTimeGateway.GetMealsAllowance((int)ViewState["projecttime_id"]) > 0)
                //{
                //    cbxMealsAllowance.Checked = true;
                //}

                //if (projectTimeGateway.GetFairWage((int)ViewState["projecttime_id"]))
                //{
                //    cbxFairWage.Checked = true;
                //}

                if (projectTimeGateway.GetUnitId((int)ViewState["projecttime_id"]).HasValue)
                {
                    UnitsGateway unitGateway = new UnitsGateway(new DataSet());
                    unitGateway.LoadByUnitId((int)projectTimeGateway.GetUnitId((int)ViewState["projecttime_id"]), Convert.ToInt32(Session["companyID"]));
                    tbxUnit.Text = unitGateway.GetUnitCode((int)projectTimeGateway.GetUnitId((int)ViewState["projecttime_id"]));
                }

                if (projectTimeGateway.GetTowedUnitId((int)ViewState["projecttime_id"]).HasValue)
                {
                    UnitsGateway unitGateway = new UnitsGateway(new DataSet());
                    unitGateway.LoadByUnitId((int)projectTimeGateway.GetTowedUnitId((int)ViewState["projecttime_id"]), Convert.ToInt32(Session["companyID"]));
                    tbxTowed.Text = unitGateway.GetUnitCode((int)projectTimeGateway.GetTowedUnitId((int)ViewState["projecttime_id"]));
                }

                tbxTypeOfWork.Text = "";
                if (projectTimeGateway.GetWork((int)ViewState["projecttime_id"]) != "")
                {
                    tbxTypeOfWork.Text = projectTimeGateway.GetWork((int)ViewState["projecttime_id"]);
                }

                tbxFunction.Text = "";
                if (projectTimeGateway.GetFunction((int)ViewState["projecttime_id"]) != "")
                {
                    tbxFunction.Text = projectTimeGateway.GetFunction((int)ViewState["projecttime_id"]);
                }
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

            // ... Labour Hours Mode
            if ((string)ViewState["LHMode"] == "Partial")
            {
                // Access control
                // ... Employees
                EmployeeListGateway employeeListGateway = new EmployeeListGateway(new DataSet());
                employeeListGateway.LoadByRequestProjectTime(1);

                DropDownList ddlOthersFor = (DropDownList)tkrpbLeftMenuOthersTimesheets.FindItemByValue("nbOthersTimesheetsDDL").FindControl("ddlOthersFor");
                ddlOthersFor.DataSource = employeeListGateway.Table;
                ddlOthersFor.DataValueField = "EmployeeID";
                ddlOthersFor.DataTextField = "FullName";
                ddlOthersFor.DataBind();

                tkrpbLeftMenuMyTimesheets.Visible = false;
                tkrpbLeftMenuOthersTimesheets.Items[0].Text = "Timesheets";
                tkrpbLeftMenuTools.Items[0].Items[1].Visible = false;
            }
            else
            {
                EmployeeGateway employeeGateway1 = new EmployeeGateway(new DataSet());
                int employeeId = employeeGateway1.GetEmployeIdByLoginId(Convert.ToInt32(Session["loginID"]));
                employeeGateway1.LoadByEmployeeId(employeeId);

                if (Request.QueryString["source_page"] == "timesheet_approve.aspx")
                {
                    tkrmTop.Items[3].Visible = false; //Timesheet
                    tkrmTop.Items[4].Visible = true; //Approve Project Times
                }
                else
                {
                    tkrmTop.Items[3].Visible = true; //Timesheet
                    
                    // Timesheet state check                    
                    ProjectTimeGateway projectTimeGatewayForState = new ProjectTimeGateway(projectTimeTDS);                   
                    int projecttime_id = Int32.Parse(ViewState["projecttime_id"].ToString());

                    if (projectTimeGatewayForState.GetProjectTimeState(projecttime_id) == "For Approval")
                    {
                        tkrmTop.Items[4].Visible = true; //Approve Project Times
                    }
                    else
                    {
                        tkrmTop.Items[4].Visible = false; //Approve Project Times
                    }
                }

                if (!employeeGateway1.GetApproveTimesheets(employeeId))
                {
                    tkrpbLeftMenuTools.Items[0].Items[1].Visible = false; //Approve Project Times
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

                // Get ProjectTime record, can't edit or delete approved timesheets
                ProjectTimeGateway projectTimeGateway = new ProjectTimeGateway(projectTimeTDS);
                projectTimeGateway.LoadByProjectTimeId((int)ViewState["projecttime_id"]);

                if (!Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_FULL_EDITING"]))
                {
                    if (projectTimeGateway.GetProjectTimeState((int)ViewState["projecttime_id"]) == "Approved")
                    {
                        tkrmTop.Items[1].Visible = false;
                        tkrmTop.Items[2].Visible = false;
                    }
                }

            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATION EVENTS
        //

        protected void tkrmTop_ItemClick(object sender, RadMenuEventArgs e)
        {
            DropDownList ddlOthersFor = (DropDownList)tkrpbLeftMenuOthersTimesheets.FindItemByValue("nbOthersTimesheetsDDL").FindControl("ddlOthersFor");
            Session["ddlOthersForSelectedValue"] = ddlOthersFor.SelectedValue;

            string url = null;

            switch (e.Item.Value)
            {
                case "mAdd":
                    if (Request.QueryString["source_page"] == "timesheet_approve.aspx")
                    {
                        url = "./timesheet_add.aspx?source_page=timesheet_summary_from_approve_project_times.aspx&others=" + ViewState["others"] + "&employee_id=" + ViewState["employee_id"] + "&period_id=" + ViewState["period_id"] + "&projecttime_id=" + ViewState["projecttime_id"];
                    }
                    else
                    {
                        url = "./timesheet_add.aspx?source_page=timesheet_summary.aspx&others=" + ViewState["others"] + "&employee_id=" + ViewState["employee_id"] + "&period_id=" + ViewState["period_id"] + "&projecttime_id=" + ViewState["projecttime_id"];
                    }
                    break;

                case "mEdit":
                    if (Request.QueryString["source_page"] == "timesheet_approve.aspx")
                    {
                        url = "./timesheet_edit.aspx?source_page=timesheet_summary_from_approve_project_times.aspx&others=" + ViewState["others"] + "&employee_id=" + ViewState["employee_id"] + "&period_id=" + ViewState["period_id"] + "&projecttime_id=" + ViewState["projecttime_id"];
                    }
                    else
                    {
                        url = "./timesheet_edit.aspx?source_page=timesheet_summary.aspx&others=" + ViewState["others"] + "&employee_id=" + ViewState["employee_id"] + "&period_id=" + ViewState["period_id"] + "&projecttime_id=" + ViewState["projecttime_id"];
                    }
                    break;

                case "mDelete":
                    if (Request.QueryString["source_page"] == "timesheet_approve.aspx")
                    {
                        url = "./timesheet_delete.aspx?source_page=timesheet_summary_from_approve_project_times.aspx&others=" + ViewState["others"] + "&employee_id=" + ViewState["employee_id"] + "&period_id=" + ViewState["period_id"] + "&projecttime_id=" + ViewState["projecttime_id"];
                    }
                    else
                    {
                        url = "./timesheet_delete.aspx?source_page=timesheet_summary.aspx&others=" + ViewState["others"] + "&employee_id=" + ViewState["employee_id"] + "&period_id=" + ViewState["period_id"] + "&projecttime_id=" + ViewState["projecttime_id"];
                    }
                    break;

                case "mTimesheet":
                    url = "./../timesheet/timesheet.aspx?source_page=timesheet_summary.aspx&others=" + ViewState["others"] + "&employee_id=" + ViewState["employee_id"] + "&period_id=" + ViewState["period_id"] + "&projecttime_id=" + ViewState["projecttime_id"];
                    break;

                case "mApproveProjectTimes":                    
                    url = "./timesheet_state.aspx?source_page=timesheet_summary.aspx&others=" + ViewState["others"] + "&employee_id=" + ViewState["employee_id"] + "&period_id=" + ViewState["period_id"] + "&projecttime_id=" + ViewState["projecttime_id"];
                    break;
            }

            Response.Redirect(url);
        }



        protected void tkrpbLeftMenu_ItemClick(object sender, RadPanelBarEventArgs e)
        {
            DropDownList ddlOthersFor = (DropDownList)tkrpbLeftMenuOthersTimesheets.FindItemByValue("nbOthersTimesheetsDDL").FindControl("ddlOthersFor");
            Session["ddlOthersForSelectedValue"] = ddlOthersFor.SelectedValue;

            string url = "";

            switch (e.Item.Value)
            {
                case "nbTimesheetsToolsApproveProjectTimes":
                    url = "./timesheet_approve.aspx?source_page=timesheet_summary.aspx&others=yes + GetNavigatorState()";
                    break;

                case "nbOthersTimesheetsViewCurrent":
                    if (ddlOthersFor.SelectedIndex >= 0)
                    {
                        Response.Redirect("./../timesheet/timesheet.aspx?source_page=lm&others=yes&employee_id=" + ddlOthersFor.SelectedValue);
                    }
                    break;

                case "nbOthersTimesheetsViewAll":
                    if (ddlOthersFor.SelectedIndex >= 0)
                    {
                        Response.Redirect("./../timesheet/timesheet_all.aspx?source_page=lm&others=yes&employee_id=" + ddlOthersFor.SelectedValue);
                    }
                    break;

                case "nbMyTimesheetsViewCurrent":
                    url = "./../timesheet/timesheet.aspx?source_page=lm&others=no";
                    break;


                case "nbMyTimesheetsViewAll":
                    url = "./../timesheet/timesheet_all.aspx?source_page=lm&others=no";
                    break;
            }

            if (url != "") Response.Redirect(url);
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
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./timesheet_summary.js");
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