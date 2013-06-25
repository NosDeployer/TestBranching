using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.Tools;
using LiquiForce.LFSLive.DA.Resources.Companies;
using LiquiForce.LFSLive.BL.Resources.Companies;
using LiquiForce.LFSLive.BL.Company.Organization;
using LiquiForce.LFSLive.DA.Company.Organization;
using LiquiForce.LFSLive.DA.Resources.Employees;
using LiquiForce.LFSLive.BL.FleetManagement.Units;
using LiquiForce.LFSLive.BL.Projects.Projects;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.DA.LabourHours.ProjectTime;
using LiquiForce.LFSLive.BL.LabourHours.ProjectTime;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime
{
    /// <summary>
    /// timesheet_edit
    /// </summary>
    public partial class timesheet_edit : System.Web.UI.Page
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
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in timesheet_edit.aspx");
                }

                // Security check
                if (!Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_FULL_EDITING"]))
                {
                    if (Request.QueryString["others"] == "no")
                    {
                        if (!(Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_MY_TIMESHEETS_VIEW"]) && Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_MY_TIMESHEETS_EDIT"])))
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
                        if (!(Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_MY_TIMESHEETS_VIEW"]) && Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_MY_TIMESHEETS_EDIT"])))
                        {
                            if (!Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_MY_TIMESHEETS_MANAGEMENT"]))
                            {
                                if (!Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_MY_TIMESHEETS_MANAGEMENT_WED"]))
                                {
                                    if (!(Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_OTHERS_TIMESHEETS_VIEW"]) && Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_OTHERS_TIMESHEETS_EDIT"])))
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
                hdfCompanyId.Value = Session["companyID"].ToString();

                // Get ProjectTime record
                ProjectTimeGateway projectTimeGateway = new ProjectTimeGateway(projectTimeTDS);
                projectTimeGateway.LoadByProjectTimeId((int)ViewState["projecttime_id"]);

                // Project time state check
                if (!Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_FULL_EDITING"]))
                {
                    if (projectTimeGateway.GetProjectTimeState((int)ViewState["projecttime_id"]) == "Approved")
                    {
                        Response.Redirect("./../../error_page.aspx?error=" + "You cannot edit an approved project time.");
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
                    else
                    {
                        if (Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_MY_TIMESHEETS_MANAGEMENT_WED"]) || Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_OTHERS_TIMESHEETS_MANAGEMENT_WED"]))
                        {
                            bool isValidLimitPayPeriodToManagementEdit = LiquiForce.LFSLive.BL.LabourHours.ProjectTime.ProjectTime.ValidateLimitedPayPeriodToWednesdayManagementEdit(projectTimeGateway.GetDate_((int)ViewState["projecttime_id"]), projectTimeGateway.GetProjectId((int)ViewState["projecttime_id"]));

                            if (!isValidLimitPayPeriodToManagementEdit)
                            {
                                Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                            }
                        }
                    }
                }

                // Store datasets
                Session["projectTimeTDS"] = projectTimeTDS;

                // Databind
                tkrdpDate_.DataBind();
                ddlLunch.DataBind();
                tbxComments.DataBind();
                tbxState.DataBind();

                // Prepare initial data for client
                StoreNavigatorState();

                EmployeeGateway employeeGateway = new EmployeeGateway(new DataSet());
                employeeGateway.LoadByEmployeeId((int)ViewState["employee_id"]);
                tbxEmployee.Text = employeeGateway.GetFullName(int.Parse(Request.QueryString["employee_id"]));

                int companyId = Int32.Parse(hdfCompanyId.Value);
                CompaniesList companiesList = new CompaniesList();
                companiesList.LoadAndAddItem(-1, "(Select a client)", companyId);
                ddlClient.DataSource = companiesList.Table;
                ddlClient.DataValueField = "COMPANIES_ID";
                ddlClient.DataTextField = "Name";
                ddlClient.DataBind();
                                
                CompaniesGateway companiesGateway = new CompaniesGateway();
                companiesGateway.LoadAllByCompaniesId(Int32.Parse(DataBinder.Eval(projectTimeTDS, "Tables[LFS_PROJECT_TIME].DefaultView.[0].CompaniesID").ToString()), companyId);

                // ... If Company is active
                bool deleted = companiesGateway.GetDeleted(Int32.Parse(DataBinder.Eval(projectTimeTDS, "Tables[LFS_PROJECT_TIME].DefaultView.[0].CompaniesID").ToString()));

                if (deleted)
                {
                    ddlClient.SelectedIndex = -1;
                }
                else
                {
                    ddlClient.SelectedValue = DataBinder.Eval(projectTimeTDS, "Tables[LFS_PROJECT_TIME].DefaultView.[0].CompaniesID").ToString();
                }

                ProjectList projectList = new ProjectList();
                projectList.LoadProjectsInternalProjectsBallparkProjectsAndAddItem(-1, "(Select a project)", int.Parse(ddlClient.SelectedValue));
                ddlProject.DataSource = projectList.Table;
                ddlProject.DataValueField = "ProjectID";
                ddlProject.DataTextField = "Name";
                ddlProject.DataBind();

                if (!deleted)
                {
                    try
                    {
                        ddlProject.SelectedValue = DataBinder.Eval(projectTimeTDS, "Tables[LFS_PROJECT_TIME].DefaultView.[0].ProjectID").ToString();
                    }
                    catch
                    {
                        ddlProject.SelectedIndex = -1;
                    }
                }
                else
                {
                    ddlProject.SelectedIndex = -1;
                }

                if (ddlProject.SelectedIndex != 0)
                {                    
                    ProjectGateway projectGateway = new ProjectGateway();
                    projectGateway.LoadByProjectId(Int32.Parse(ddlProject.SelectedValue));

                    if (projectGateway.GetCountryID(Int32.Parse(ddlProject.SelectedValue)) == 1) //Canada
                    {
                        if (projectGateway.GetFairWageApplies(int.Parse(ddlProject.SelectedValue)))
                        {
                            ddlJobClassType.Visible = true;
                            lblJobClassType.Visible = true;

                            ProjectTimeJobClassTypeList projectTimeJobClassTypeList = new ProjectTimeJobClassTypeList();
                            projectTimeJobClassTypeList.LoadAndAddItem(1, companyId, "(Select a Job Class Type)");
                            ddlJobClassType.DataSource = projectTimeJobClassTypeList.Table;
                            ddlJobClassType.DataValueField = "JobClassType";
                            ddlJobClassType.DataTextField = "JobClassType";
                            ddlJobClassType.DataBind();

                            if (projectTimeGateway.GetJobClassType((int)ViewState["projecttime_id"]).ToString() == "")
                            {
                                ddlJobClassType.SelectedIndex = 0;
                            }
                            else
                            {
                                ddlJobClassType.SelectedValue = (string)DataBinder.Eval(projectTimeTDS, "Tables[LFS_PROJECT_TIME].DefaultView.[0].JobClassType");
                            }
                        }
                        else
                        {
                            ddlJobClassType.Visible = false;
                            lblJobClassType.Visible = false;
                        }
                    }
                    else
                    {
                        if (projectGateway.GetFairWageApplies(int.Parse(ddlProject.SelectedValue)))
                        {
                            ddlJobClassType.Visible = true;
                            lblJobClassType.Visible = true;

                            ProjectTimeJobClassTypeList projectTimeJobClassTypeList = new ProjectTimeJobClassTypeList();
                            projectTimeJobClassTypeList.LoadAndAddItem(2, companyId, "(Select a Job Class Type)");
                            ddlJobClassType.DataSource = projectTimeJobClassTypeList.Table;
                            ddlJobClassType.DataValueField = "JobClassType";
                            ddlJobClassType.DataTextField = "JobClassType";
                            ddlJobClassType.DataBind();

                            if (projectTimeGateway.GetJobClassType((int)ViewState["projecttime_id"]).ToString() == "")
                            {
                                ddlJobClassType.SelectedIndex = 0;
                            }
                            else
                            {
                                ddlJobClassType.SelectedValue = (string)DataBinder.Eval(projectTimeTDS, "Tables[LFS_PROJECT_TIME].DefaultView.[0].JobClassType");
                            }
                        }
                        else
                        {
                            ddlJobClassType.Visible = false;
                            lblJobClassType.Visible = false;
                        }
                    }
                }
                else
                {
                    ddlJobClassType.Visible = false;
                    lblJobClassType.Visible = false;
                }

                WorkingDetailsGateway workingDetailsGateway = new WorkingDetailsGateway(new DataSet());
                workingDetailsGateway.Load();
                ddlWorkingDetails.DataSource = workingDetailsGateway.Table;
                ddlWorkingDetails.DataValueField = "WorkingDetails";
                ddlWorkingDetails.DataTextField = "WorkingDetails";
                ddlWorkingDetails.DataBind();

                if (!deleted)
                {
                    ddlWorkingDetails.SelectedValue = projectTimeGateway.GetWorkingDetails((int)ViewState["projecttime_id"]);
                }
                else
                {
                    ddlWorkingDetails.SelectedIndex = -1;
                }

                ProjectTimeWorkList projectTimeWorkList = new ProjectTimeWorkList(new DataSet());

                int projectId = 0;
                try
                {
                    projectId = Int32.Parse(ddlProject.SelectedValue);
                }
                catch
                {
                }

                if (projectId == 35 || projectId == 39 || projectId == 716)
                {
                    projectTimeWorkList.LoadAndAddItem("");
                }
                else
                {
                    projectTimeWorkList.LoadAndAddItem("(Select a Type)");
                }

                // Setting start time, end time
                string startTime = DataBinder.Eval(projectTimeTDS, "Tables[LFS_PROJECT_TIME].DefaultView.[0].StartTime", "{0:H:mm}").ToString();
                if (!String.IsNullOrEmpty(startTime))
                {
                    string[] hoursMin1 = startTime.Split(':');
                    ddlStartTimeHour.SelectedValue = hoursMin1[0].Trim();
                    ddlStartTimeMinute.SelectedValue = hoursMin1[1].Trim();
                }
                else
                {
                    ddlStartTimeHour.SelectedIndex = 0;
                    ddlStartTimeMinute.SelectedIndex = 0;
                }

                string endTime = DataBinder.Eval(projectTimeTDS, "Tables[LFS_PROJECT_TIME].DefaultView.[0].EndTime", "{0:H:mm}").ToString();
                if (!String.IsNullOrEmpty(endTime))
                {
                    string[] endHoursMin1 = endTime.Split(':');
                    ddlEndTimeHour.SelectedValue = endHoursMin1[0].Trim();
                    ddlEndTimeMinute.SelectedValue = endHoursMin1[1].Trim();
                }
                else
                {
                    ddlEndTimeHour.SelectedIndex = 0;
                    ddlEndTimeMinute.SelectedIndex = 0;
                }

                // Setting type of Work
                ddlTypeOfWork.DataSource = projectTimeWorkList.Table;
                ddlTypeOfWork.DataValueField = "Work_";
                ddlTypeOfWork.DataTextField = "Work_";
                ddlTypeOfWork.DataBind();
                if (projectTimeGateway.GetWork((int)ViewState["projecttime_id"]) == "") ddlTypeOfWork.SelectedIndex = -1; else ddlTypeOfWork.SelectedValue = projectTimeGateway.GetWork((int)ViewState["projecttime_id"]);

                ProjectTimeWorkFunctionList projectTimeWorkFunctionList = new ProjectTimeWorkFunctionList(new DataSet());
                if (projectTimeGateway.GetWork((int)ViewState["projecttime_id"]) == "")
                {
                    // ... If there is no type of Work, no function should be loaded
                    projectTimeWorkFunctionList.LoadAndAddItem("", "-1");
                }
                else
                {
                    projectTimeWorkFunctionList.LoadAndAddItem("(Select a Function)", projectTimeGateway.GetWork((int)ViewState["projecttime_id"]).ToString());
                }
                ddlFunction.DataSource = projectTimeWorkFunctionList.Table;
                ddlFunction.DataValueField = "Function_";
                ddlFunction.DataTextField = "Function_";
                ddlFunction.DataBind();
                if (projectTimeGateway.GetWork((int)ViewState["projecttime_id"]).ToString() == "")
                {
                    ddlFunction.SelectedValue = "";
                }
                else
                {
                    ddlFunction.SelectedValue = (string)DataBinder.Eval(projectTimeTDS, "Tables[LFS_PROJECT_TIME].DefaultView.[0].Function_");
                }

                CountryList countryList = new CountryList(new DataSet());
                countryList.LoadAndAddItem(-1, " ");
                ddlMealsCountry.DataSource = countryList.Table;
                ddlMealsCountry.DataValueField = "CountryID";
                ddlMealsCountry.DataTextField = "Name";
                ddlMealsCountry.DataBind();

                if (!deleted)
                {
                    if (projectTimeGateway.GetMealsCountry((int)ViewState["projecttime_id"]).HasValue)
                    {
                        ddlMealsCountry.SelectedValue = projectTimeGateway.GetMealsCountry((int)ViewState["projecttime_id"]).ToString();
                    }
                    else
                    {
                        ddlMealsCountry.SelectedValue = "-1";
                    }
                }
                else
                {
                    ddlMealsCountry.SelectedIndex = -1;
                }

                //if (projectTimeGateway.GetMealsAllowance((int)ViewState["projecttime_id"]) > 0)
                //{
                //    cbxMealsAllowance.Checked = true;
                //}
                
                string unitType = "Vehicle";
                UnitsList unitsList = new UnitsList(new DataSet());
                unitsList.LoadAndAddItem("-1", " ", Int32.Parse(Session["companyID"].ToString()), true, 0, unitType);
                ddlUnit.DataSource = unitsList.Table;
                ddlUnit.DataValueField = "UnitID";
                ddlUnit.DataTextField = "UnitCode";
                ddlUnit.DataBind();
                if (projectTimeGateway.GetUnitId((int)ViewState["projecttime_id"]).HasValue)
                {
                    ddlUnit.SelectedValue = ((int)projectTimeGateway.GetUnitId((int)ViewState["projecttime_id"])).ToString();
                }

                UnitsList towed = new UnitsList(new DataSet());
                towed.LoadAndAddItem("-1", " ", Int32.Parse(Session["companyID"].ToString()), true, 1, unitType);
                ddlTowed.DataSource = towed.Table;
                ddlTowed.DataValueField = "UnitID";
                ddlTowed.DataTextField = "UnitCode";
                ddlTowed.DataBind();
                if (projectTimeGateway.GetTowedUnitId((int)ViewState["projecttime_id"]).HasValue)
                {
                    ddlTowed.SelectedValue = ((int)projectTimeGateway.GetTowedUnitId((int)ViewState["projecttime_id"])).ToString();
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

                if (!employeeGateway1.GetApproveTimesheets(employeeId))
                {
                    tkrpbLeftMenuTools.Items[0].Items[1].Visible = false; // Approve Project Times
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

        protected void cvJobClassType_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            int projectId = int.Parse(ddlProject.SelectedValue);

            ProjectGateway projectGateway = new ProjectGateway(new DataSet());
            projectGateway.LoadByProjectId(int.Parse(ddlProject.SelectedValue));

            if (projectGateway.GetFairWageApplies(projectId))
            {
                string jobClass = ddlJobClassType.SelectedValue;

                if (jobClass == "(Select a Job Class Type)")
                {
                    args.IsValid = false;
                }
            }
        }



        protected void cvLunchFormat_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = (Validator.IsValidDouble(args.Value.Trim())) ? true : false;
        }



        protected void cvValidStartTime_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = false;
            if ((ddlStartTimeHour.SelectedValue.Trim() != "") && (ddlStartTimeMinute.SelectedValue.Trim() != ""))
            {
                args.IsValid = true;
            }

            if ((ddlStartTimeHour.SelectedValue.Trim() == "") && (ddlStartTimeMinute.SelectedValue.Trim() == ""))
            {
                args.IsValid = true;
            }
        }



        protected void cvValidEndTime_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = false;
            if ((ddlEndTimeHour.SelectedValue.Trim() != "") && (ddlEndTimeMinute.SelectedValue.Trim() != "") )
            {
                args.IsValid = true;
            }

            if ((ddlEndTimeHour.SelectedValue.Trim() == "") && (ddlEndTimeMinute.SelectedValue.Trim() == "") )
            {
                args.IsValid = true;
            }
        }



        protected void cvValidTimes_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = false;

            int projectId = int.Parse(ddlProject.SelectedValue);
            if (projectId != 35 && projectId != 39 && projectId != 716)
            {
                ProjectTimeGateway projectTimeGatewayForVerify = new ProjectTimeGateway();
                int employeeId = Int32.Parse(ViewState["employee_id"].ToString());
                int companyId = Int32.Parse(hdfCompanyId.Value);
                DateTime date_ = tkrdpDate_.SelectedDate.Value;
                string startTimeFooter = "";
                string startHoursFooter = ""; if (ddlStartTimeHour.SelectedValue != "") startHoursFooter = ddlStartTimeHour.SelectedValue.Trim();
                string startMinutesFooter = ""; if (ddlStartTimeMinute.SelectedValue != "") startMinutesFooter = ddlStartTimeMinute.SelectedValue.Trim();

                string endTimeFooter = "";
                string endHoursFooter = ""; if (ddlEndTimeHour.SelectedValue != "") endHoursFooter = ddlEndTimeHour.SelectedValue.Trim();
                string endMinutesFooter = ""; if (ddlEndTimeMinute.SelectedValue != "") endMinutesFooter = ddlEndTimeMinute.SelectedValue.Trim();

                int projectTimeId = (int)ViewState["projecttime_id"];

                if ((startHoursFooter != "") && (startMinutesFooter != "") && (endHoursFooter != "") && (endMinutesFooter != ""))
                {
                    startTimeFooter = startHoursFooter + ":" + startMinutesFooter;
                    endTimeFooter = endHoursFooter + ":" + endMinutesFooter;

                    // Verify if the time already exists at DB
                    if (projectTimeGatewayForVerify.NotExistsByEmployeIdDate_StartTimeEndTimeEdit(projectTimeId, employeeId, date_, startTimeFooter, endTimeFooter, companyId))
                    {
                        args.IsValid = true;
                    }
                }
                else
                {
                    args.IsValid = true;
                }
            }
            else
            {
                args.IsValid = true;
            }
        }



        protected void cvJobClassEmpty_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;
            int employeeId = Int32.Parse(ViewState["employee_id"].ToString());
            EmployeeGateway employee = new EmployeeGateway();
            employee.LoadByEmployeeId(employeeId);
            string jobClass = employee.GetJobClassType(employeeId);

            if ((jobClass == "") && (ddlJobClassType.Visible))
            {
                args.IsValid = false;
            }
        }



        protected void ddlClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProjectList projectList = new ProjectList();
            projectList.LoadProjectsInternalProjectsBallparkProjectsAndAddItem(-1, "(Select a project)", int.Parse(ddlClient.SelectedValue));
            ddlProject.DataSource = projectList.Table;
            ddlProject.DataValueField = "ProjectID";
            ddlProject.DataTextField = "Name";
            ddlProject.DataBind();
            ddlProject.SelectedIndex = 0;
        }



        protected void ddlProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((ddlProject.SelectedValue != null) && (ddlProject.SelectedValue != "-1"))
            {
                ProjectGateway projectGateway = new ProjectGateway(new DataSet());
                ProjectTimeJobClassTypeList projectTimeJobClassTypeList = new ProjectTimeJobClassTypeList();
                ProjectTimeWorkList projectTimeWorkList = new ProjectTimeWorkList(new DataSet());

                projectGateway.LoadByProjectId(int.Parse(ddlProject.SelectedValue));

                if (int.Parse(ddlProject.SelectedValue) == 35 || int.Parse(ddlProject.SelectedValue) == 39 || int.Parse(ddlProject.SelectedValue) == 716)
                {
                    projectTimeWorkList.LoadAndAddItem("");                    
                }
                else
                {
                    projectTimeWorkList.LoadAndAddItem("(Select a Type)");
                }

                // Setting type of Work
                ddlTypeOfWork.DataSource = projectTimeWorkList.Table;
                ddlTypeOfWork.DataValueField = "Work_";
                ddlTypeOfWork.DataTextField = "Work_";
                ddlTypeOfWork.DataBind();
                ddlTypeOfWork.SelectedIndex = 0;

                switch (projectGateway.GetCountryID(int.Parse(ddlProject.SelectedValue)))
                {
                    case 1:
                        ddlWorkingDetails.SelectedValue = "Canada";
                        ddlMealsCountry.SelectedValue = "1";
                        if (projectGateway.GetFairWageApplies(int.Parse(ddlProject.SelectedValue)))
                        {
                            ddlJobClassType.Visible = true;
                            lblJobClassType.Visible = true;

                            int companyId = Int32.Parse(hdfCompanyId.Value);
                            projectTimeJobClassTypeList.LoadAndAddItem(1, companyId, "(Select a Job Class Type)");
                            ddlJobClassType.DataSource = projectTimeJobClassTypeList.Table;
                            ddlJobClassType.DataValueField = "JobClassType";
                            ddlJobClassType.DataTextField = "JobClassType";
                            ddlJobClassType.DataBind();
                        }
                        else
                        {
                            ddlJobClassType.Visible = false;
                            lblJobClassType.Visible = false;
                        }
                        break;

                    case 2:
                        ddlWorkingDetails.SelectedValue = "USA";
                        ddlMealsCountry.SelectedValue = "2";
                        if (projectGateway.GetFairWageApplies(int.Parse(ddlProject.SelectedValue)))
                        {
                            ddlJobClassType.Visible = true;
                            lblJobClassType.Visible = true;

                            int companyId = Int32.Parse(hdfCompanyId.Value);
                            projectTimeJobClassTypeList.LoadAndAddItem(2, companyId, "(Select a Job Class Type)");
                            ddlJobClassType.DataSource = projectTimeJobClassTypeList.Table;
                            ddlJobClassType.DataValueField = "JobClassType";
                            ddlJobClassType.DataTextField = "JobClassType";
                            ddlJobClassType.DataBind();
                        }
                        else
                        {
                            ddlJobClassType.Visible = false;
                            lblJobClassType.Visible = false;
                        }
                        break;
                }
            }

            upnlWorkingDetails.Update();
            upnlMealsCountry.Update();
            upnlJobClassType.Update();
            upnlJobClassTypeLabel.Update();
            upnlTypeOfWork.Update();

            rfvProject.Validate();
        }



        protected void ddlTypeOfWork_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProjectTimeWorkFunctionList projectTimeWorkFunctionList = new ProjectTimeWorkFunctionList();
            projectTimeWorkFunctionList.LoadAndAddItem("(Select a Function)", ddlTypeOfWork.SelectedValue);
            ddlFunction.DataSource = projectTimeWorkFunctionList.Table;
            ddlFunction.DataValueField = "Function_";
            ddlFunction.DataTextField = "Function_";
            ddlFunction.DataBind();
            ddlFunction.SelectedIndex = 0;

            rfvFunction.Validate();
        }



        protected void ddlStartTimeHour_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tkrdpDate_.SelectedDate.Value.DayOfWeek == DayOfWeek.Sunday)
            {
                if (ddlStartTimeHour.SelectedItem.Value == "23")
                {
                    ddlEndTimeHour.Items.Clear();
                    ddlEndTimeHour.Items.Add(new ListItem(" ", " "));
                    ddlEndTimeHour.Items.Add(new ListItem("0", "0"));

                    if (ddlStartTimeMinute.SelectedItem.Value == "45")
                    {
                        ddlEndTimeMinute.Items.Clear();
                        ddlEndTimeMinute.Items.Add(new ListItem(" ", " "));
                        ddlEndTimeMinute.Items.Add(new ListItem("00", "00"));
                    }
                    else
                    {
                        ddlEndTimeHour.Items.Add(new ListItem("23", "23"));

                        ddlEndTimeMinute.Items.Clear();
                        ddlEndTimeMinute.Items.Add(new ListItem(" ", " "));
                        ddlEndTimeMinute.Items.Add(new ListItem("00", "00"));
                        ddlEndTimeMinute.Items.Add(new ListItem("15", "15"));
                        ddlEndTimeMinute.Items.Add(new ListItem("30", "30"));
                        ddlEndTimeMinute.Items.Add(new ListItem("45", "45"));
                    }
                }
                else
                {
                    if (ddlStartTimeHour.SelectedItem.Value != " ")
                    {
                        int startTimeHour = Int32.Parse(ddlStartTimeHour.SelectedItem.Value);

                        if (ddlStartTimeMinute.SelectedItem.Value == "45")
                        {
                            startTimeHour++;
                        }

                        ddlEndTimeHour.Items.Clear();
                        ddlEndTimeHour.Items.Add(new ListItem(" ", " "));
                        ddlEndTimeHour.Items.Add(new ListItem("0", "0"));

                        for (int i = startTimeHour; i < 24; i++)
                        {
                            ddlEndTimeHour.Items.Add(new ListItem(i.ToString(), i.ToString()));
                        }

                        ddlEndTimeMinute.Items.Clear();
                        ddlEndTimeMinute.Items.Add(new ListItem(" ", " "));
                        ddlEndTimeMinute.Items.Add(new ListItem("00", "00"));
                        ddlEndTimeMinute.Items.Add(new ListItem("15", "15"));
                        ddlEndTimeMinute.Items.Add(new ListItem("30", "30"));
                        ddlEndTimeMinute.Items.Add(new ListItem("45", "45"));
                    }
                }

                ddlEndTimeMinute.SelectedIndex = 1;
                upEndTime.Update();
            }
        }



        protected void ddlEndTimeHour_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tkrdpDate_.SelectedDate.Value.DayOfWeek == DayOfWeek.Sunday)
            {
                if (ddlEndTimeHour.SelectedItem.Value != "")
                {
                    if (ddlEndTimeHour.SelectedItem.Value == "0")
                    {
                        ddlEndTimeMinute.Items.Clear();
                        ddlEndTimeMinute.Items.Add(new ListItem(" ", " "));
                        ddlEndTimeMinute.Items.Add(new ListItem("00", "00"));

                        ddlEndTimeMinute.SelectedIndex = 1;
                    }
                    else
                    {
                        if (ddlEndTimeHour.SelectedItem.Value == "23" && ddlStartTimeHour.SelectedItem.Value == "23")
                        {
                            ddlEndTimeMinute.Items.Clear();
                            ddlEndTimeMinute.Items.Add(new ListItem(" ", " "));
                            if (ddlStartTimeMinute.SelectedItem.Value == "00")
                            {
                                ddlEndTimeMinute.Items.Add(new ListItem("15", "15"));
                                ddlEndTimeMinute.Items.Add(new ListItem("30", "30"));
                                ddlEndTimeMinute.Items.Add(new ListItem("45", "45"));

                                ddlEndTimeMinute.SelectedIndex = 0;
                            }
                            else
                            {
                                if (Int32.Parse(ddlStartTimeMinute.SelectedItem.Value) < 15) ddlEndTimeMinute.Items.Add(new ListItem("15", "15"));
                                if (Int32.Parse(ddlStartTimeMinute.SelectedItem.Value) < 30) ddlEndTimeMinute.Items.Add(new ListItem("30", "30"));
                                if (Int32.Parse(ddlStartTimeMinute.SelectedItem.Value) < 45) ddlEndTimeMinute.Items.Add(new ListItem("45", "45"));

                                ddlEndTimeMinute.SelectedIndex = 0;
                            }
                        }
                        else
                        {
                            ddlEndTimeMinute.Items.Clear();
                            ddlEndTimeMinute.Items.Add(new ListItem(" ", " "));
                            ddlEndTimeMinute.Items.Add(new ListItem("00", "00"));
                            ddlEndTimeMinute.Items.Add(new ListItem("15", "15"));
                            ddlEndTimeMinute.Items.Add(new ListItem("30", "30"));
                            ddlEndTimeMinute.Items.Add(new ListItem("45", "45"));

                            ddlEndTimeMinute.SelectedIndex = 1;
                        }
                    }
                }
                else
                {
                    ddlEndTimeMinute.Items.Clear();
                    ddlEndTimeMinute.Items.Add(new ListItem(" ", " "));
                    ddlEndTimeMinute.Items.Add(new ListItem("00", "00"));
                    ddlEndTimeMinute.Items.Add(new ListItem("15", "15"));
                    ddlEndTimeMinute.Items.Add(new ListItem("30", "30"));
                    ddlEndTimeMinute.Items.Add(new ListItem("45", "45"));

                    ddlEndTimeMinute.SelectedIndex = 1;
                }
            }

            upEndTime.Update();
        }





        
        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATION EVENTS
        //

        protected void tkrmTop_ItemClick(object sender, RadMenuEventArgs e)
        {
            DropDownList ddlOthersFor = (DropDownList)tkrpbLeftMenuOthersTimesheets.FindItemByValue("nbOthersTimesheetsDDL").FindControl("ddlOthersFor");
            Session["ddlOthersForSelectedValue"] = ddlOthersFor.SelectedValue;

            switch (e.Item.Value)
            {
                case "mSave":
                    Page.Validate();

                    if (Page.IsValid)
                    {
                        PostPageChanges();
                        UpdateDatabase();

                        if (Request.QueryString["source_page"] == "timesheet.aspx")
                        {
                            Response.Redirect("./../timesheet/timesheet.aspx?source_page=timesheet_edit.aspx&others=" + ViewState["others"] + "&employee_id=" + ViewState["employee_id"] + "&period_id=" + ViewState["period_id"] + "&projecttime_id=" + ViewState["projecttime_id"]);
                        }
                        else
                        {
                            if (Request.QueryString["source_page"] == "timesheet_approve.aspx")
                            {
                                Response.Redirect("./timesheet_approve.aspx?source_page=timesheet_edit.aspx&others=" + ViewState["others"] + GetNavigatorState());
                            }
                            else
                            {
                                if (Request.QueryString["source_page"] == "timesheet_summary_from_approve_project_times.aspx")
                                {
                                    Response.Redirect("./timesheet_summary.aspx?source_page=timesheet_approve.aspx&others=" + ViewState["others"] + "&employee_id=" + ViewState["employee_id"] + "&period_id=" + ViewState["period_id"] + "&projecttime_id=" + ViewState["projecttime_id"]);
                                }
                                else
                                {
                                    Response.Redirect("./timesheet_summary.aspx?source_page=timesheet_edit.aspx&others=" + ViewState["others"] + "&employee_id=" + ViewState["employee_id"] + "&period_id=" + ViewState["period_id"] + "&projecttime_id=" + ViewState["projecttime_id"]);
                                }
                            }
                        }
                    }
                    break;

                case "mCancel":
                    if (Request.QueryString["source_page"] == "timesheet.aspx")
                    {
                        Response.Redirect("./../timesheet/timesheet.aspx?source_page=timesheet_edit.aspx&others=" + ViewState["others"] + "&employee_id=" + ViewState["employee_id"] + "&period_id=" + ViewState["period_id"] + "&projecttime_id=" + ViewState["projecttime_id"]);
                    }
                    else
                    {
                        if (Request.QueryString["source_page"] == "timesheet_approve.aspx")
                        {
                            Response.Redirect("./timesheet_approve.aspx?source_page=timesheet_edit.aspx&others=" + ViewState["others"] + GetNavigatorState());
                        }
                        else
                        {
                            if (Request.QueryString["source_page"] == "timesheet_summary_from_approve_project_times.aspx")
                            {
                                Response.Redirect("./timesheet_summary.aspx?source_page=timesheet_approve.aspx&others=" + ViewState["others"] + "&employee_id=" + ViewState["employee_id"] + "&period_id=" + ViewState["period_id"] + "&projecttime_id=" + ViewState["projecttime_id"]);
                            }
                            else
                            {
                                Response.Redirect("./timesheet_summary.aspx?source_page=timesheet_edit.aspx&others=" + ViewState["others"] + "&employee_id=" + ViewState["employee_id"] + "&period_id=" + ViewState["period_id"] + "&projecttime_id=" + ViewState["projecttime_id"]);
                            }
                        }
                    }
                    break;

                case "mSummary":
                    if (Request.QueryString["source_page"] == "timesheet_summary_from_approve_project_times.aspx")
                    {
                        Response.Redirect("./timesheet_summary.aspx?source_page=timesheet_approve.aspx&others=" + ViewState["others"] + "&employee_id=" + ViewState["employee_id"] + "&period_id=" + ViewState["period_id"] + "&projecttime_id=" + ViewState["projecttime_id"]);
                    }
                    else
                    {
                        Response.Redirect("./timesheet_summary.aspx?source_page=timesheet_edit.aspx&others=" + ViewState["others"] + "&employee_id=" + ViewState["employee_id"] + "&period_id=" + ViewState["period_id"] + "&projecttime_id=" + ViewState["projecttime_id"]);
                    }
                    break;

                case "mApproveProjectTimes":
                    Response.Redirect("./timesheet_approve.aspx?source_page=timesheet_edit.aspx&others=" + ViewState["others"] + GetNavigatorState());
                    break;
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
                    url = "./timesheet_approve.aspx?source_page=lm&others=yes";
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

            // Register content variables
            string contentVariables = "";
            contentVariables += "var tkrmTopId = '" + tkrmTop.ClientID + "';"; 
            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./timesheet_edit.js");
        }



        public override void Validate()
        {
            Page.Validate("generalValidData");
            if (Page.IsValid)
            {
                base.Validate("generalData");

                int projectId = int.Parse(ddlProject.SelectedValue);
                int employeeId = (int)ViewState["employee_id"];
                int companyId = Convert.ToInt32(Session["companyID"]);

                if (projectId != 35 && projectId != 39 && projectId != 716)
                {
                    Page.Validate("specialData");
                }

                cvDatePayPeriod.IsValid = (tkrdpDate_.SelectedDate != null) ? LiquiForce.LFSLive.BL.LabourHours.ProjectTime.ProjectTime.ValidateExistPayPeriod(tkrdpDate_.SelectedDate.Value) : false;

                if (!Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_FULL_EDITING"]))
                {
                    if (Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_MY_TIMESHEETS_MANAGEMENT"]) || Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_OTHERS_TIMESHEETS_MANAGEMENT"]))
                    {
                        cvDateLimitedPayPeriod.IsValid = (tkrdpDate_.SelectedDate != null) ? LiquiForce.LFSLive.BL.LabourHours.ProjectTime.ProjectTime.ValidateLimitedPayPeriodToManagementEdit(tkrdpDate_.SelectedDate.Value, projectId) : false;
                    }
                    else
                    {
                        cvDateLimitedPayPeriod.IsValid = true;
                    }

                    if (Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_MY_TIMESHEETS_MANAGEMENT_WED"]) || Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_OTHERS_TIMESHEETS_MANAGEMENT_WED"]))
                    {
                        cvDateLimitedWednesdayPayPeriod.IsValid = (tkrdpDate_.SelectedDate != null) ? LiquiForce.LFSLive.BL.LabourHours.ProjectTime.ProjectTime.ValidateLimitedPayPeriodToWednesdayManagementEdit(tkrdpDate_.SelectedDate.Value, projectId) : false;
                    }
                    else
                    {
                        cvDateLimitedWednesdayPayPeriod.IsValid = true;
                    }
                }
                else
                {
                    cvDateLimitedPayPeriod.IsValid = true;
                    cvDateLimitedWednesdayPayPeriod.IsValid = true;
                }

                DateTime? startTime = null;
                if ((ddlStartTimeHour.SelectedValue.Trim() != "") && (ddlStartTimeMinute.SelectedValue.Trim() != "") )
                {
                    startTime = DateTime.Parse(ddlStartTimeHour.SelectedValue.Trim() + ":" + ddlStartTimeMinute.SelectedValue.Trim() );
                }

                DateTime? endTime = null;
                if ((ddlEndTimeHour.SelectedValue.Trim() != "") && (ddlEndTimeMinute.SelectedValue.Trim() != "") )
                {
                    endTime = DateTime.Parse(ddlEndTimeHour.SelectedValue.Trim() + ":" + ddlEndTimeMinute.SelectedValue.Trim() );
                }

                cvStartTimeDelete.IsValid = LiquiForce.LFSLive.BL.LabourHours.ProjectTime.ProjectTime.ValidateNotExistFieldForWorkingDetails(ddlWorkingDetails.SelectedValue.Trim(), startTime.ToString());
                cvStartTimeProvide.IsValid = LiquiForce.LFSLive.BL.LabourHours.ProjectTime.ProjectTime.ValidateExistFieldForWorkingDetails(ddlWorkingDetails.SelectedValue.Trim(), startTime.ToString());
                cvEndTimeDelete.IsValid = LiquiForce.LFSLive.BL.LabourHours.ProjectTime.ProjectTime.ValidateNotExistFieldForWorkingDetails(ddlWorkingDetails.SelectedValue.Trim(), endTime.ToString());
                cvEndTimeProvide.IsValid = LiquiForce.LFSLive.BL.LabourHours.ProjectTime.ProjectTime.ValidateExistFieldForWorkingDetails(ddlWorkingDetails.SelectedValue.Trim(), endTime.ToString());
                cvLunchDelete.IsValid = true; if (ddlLunch.SelectedValue != "0") cvLunchDelete.IsValid = LiquiForce.LFSLive.BL.LabourHours.ProjectTime.ProjectTime.ValidateNotExistFieldForWorkingDetails(ddlWorkingDetails.SelectedValue.Trim(), ddlLunch.SelectedValue);

                //cvMealsCountry.IsValid = LiquiForce.LFSLive.BL.LabourHours.ProjectTime.ProjectTime.ValidateMealsCountry(ddlMealsCountry.SelectedValue, cbxMealsAllowance.Checked);

                int projectTimeId = (int)ViewState["projecttime_id"];

                //cvMealsAllowance.IsValid = LiquiForce.LFSLive.BL.LabourHours.ProjectTime.ProjectTime.ValidateMealsAllowance(projectTimeId, employeeId, tkrdpDate_.SelectedDate.Value, ddlMealsCountry.SelectedValue, cbxMealsAllowance.Checked, companyId);

                if (Page.IsValid)
                {
                    cvProjectTime.IsValid = LiquiForce.LFSLive.BL.LabourHours.ProjectTime.ProjectTime.ValidateProjectTime(startTime.ToString(), endTime.ToString(), ddlLunch.SelectedValue);
                }
            }
        }



        private void PostPageChanges()
        {
            int projectTimeId = (int)ViewState["projecttime_id"];
            int companiesId = int.Parse(ddlClient.SelectedValue);
            int projectId = int.Parse(ddlProject.SelectedValue);
            DateTime date_ = tkrdpDate_.SelectedDate.Value;
            string workingDetails = ""; if (ddlWorkingDetails.SelectedValue != "(Select)") workingDetails = ddlWorkingDetails.SelectedValue;

            ProjectGateway projectGateway = new ProjectGateway(new DataSet());
            projectGateway.LoadByProjectId(projectId);
            CountryGateway countryGateway = new CountryGateway(new DataSet());
            countryGateway.LoadByCountryId(projectGateway.GetCountryID(projectId));
            string location = countryGateway.GetName(projectGateway.GetCountryID(projectId));

            DateTime? startTime = null;
            if ((ddlStartTimeHour.SelectedValue.Trim() != "") && (ddlStartTimeMinute.SelectedValue.Trim() != "") )
            {
                startTime = new DateTime(date_.Year, date_.Month, date_.Day, Int32.Parse(ddlStartTimeHour.SelectedValue), Int32.Parse(ddlStartTimeMinute.SelectedValue), 0);
            }

            DateTime? endTime = null;
            if ((ddlEndTimeHour.SelectedValue.Trim() != "") && (ddlEndTimeMinute.SelectedValue.Trim() != "") )
            {
                endTime = new DateTime(date_.Year, date_.Month, date_.Day, Int32.Parse(ddlEndTimeHour.SelectedValue), Int32.Parse(ddlEndTimeMinute.SelectedValue), 0);
            }

            string work_ = ""; if (ddlTypeOfWork.SelectedValue != "(Select a Type)") work_ = ddlTypeOfWork.SelectedValue;
            string function_ = ""; if (ddlFunction.SelectedValue != "(Select a Function)") function_ = ddlFunction.SelectedValue;

            double? offset = 0; if (ddlLunch.SelectedValue != "0") offset = double.Parse(ddlLunch.SelectedValue);
            Int64? mealsCountry = null; if (ddlMealsCountry.SelectedValue != "-1") mealsCountry = Int64.Parse(ddlMealsCountry.SelectedValue);
            string mealsAllowanceType = ""; //if (cbxMealsAllowance.Checked) mealsAllowanceType = "Full Day";

            decimal mealsAllowance = MealsAllowance.GetMealsAllowance(mealsCountry, false, "Full Day");

            int? unitId = null; if (ddlUnit.SelectedValue != "-1") unitId = int.Parse(ddlUnit.SelectedValue);
            int? towedUnitId = null; if (ddlTowed.SelectedValue != "-1") towedUnitId = int.Parse(ddlTowed.SelectedValue);

            string comments = tbxComments.Text.Trim();
            bool fairWage = projectGateway.GetFairWageApplies(projectId);

            string jobClassType = ""; if (ddlJobClassType.SelectedValue != "(Select a Job Class Type)") jobClassType = ddlJobClassType.SelectedValue;

            EmployeeGateway employeeGateway = new EmployeeGateway(new DataSet());
            int employeeId = employeeGateway.GetEmployeIdByLoginId(Convert.ToInt32(Session["loginID"]));

            LiquiForce.LFSLive.BL.LabourHours.ProjectTime.ProjectTime projectTime = new LiquiForce.LFSLive.BL.LabourHours.ProjectTime.ProjectTime(projectTimeTDS);
            projectTime.Update(projectTimeId, companiesId, projectId, date_, startTime, endTime, offset, workingDetails, location, mealsCountry, mealsAllowanceType, mealsAllowance, unitId, towedUnitId, comments, work_, function_, fairWage, jobClassType, employeeId);
        }



        private void UpdateDatabase()
        {
            DropDownList ddlOthersFor = (DropDownList)tkrpbLeftMenuOthersTimesheets.FindItemByValue("nbOthersTimesheetsDDL").FindControl("ddlOthersFor");
            Session["ddlOthersForSelectedValue"] = ddlOthersFor.SelectedValue;

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

        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
        {
            InitializeComponent();
            base.OnInit(e);

            // Wire events
            this.PreRender += new EventHandler(Page_PreRender);
        }

        private void InitializeComponent()
        {
            this.projectTimeTDS = new ProjectTimeTDS();
        }

        #endregion




        private void StoreNavigatorState()
        {
            ViewState["navigatorState"] = "&search_ddlCountry=" + Request.QueryString["search_ddlCountry"] + "&search_ddlClient=" + Request.QueryString["search_ddlClient"] + "&search_ddlProject=" + Request.QueryString["search_ddlProject"] + "&search_ddlTeamMember=" + Request.QueryString["search_ddlTeamMember"] + "&search_tkrdpStartDate=" + Request.QueryString["search_tkrdpStartDate"] + "&search_tkrdpEndDate=" + Request.QueryString["search_tkrdpEndDate"];
        }



        private string GetNavigatorState()
        {
            return (string)ViewState["navigatorState"];
        }



        protected string GetLunch(object lunch)
        {
            if (lunch != DBNull.Value)
            {                
                if ( (Validator.IsValidDouble(lunch.ToString())) && (lunch.ToString() != "0.00"))
                {
                    return lunch.ToString() ;
                }
                else
                {
                    return "0";
                }
            }
            else
            {
                return "0";
            }
        }



    }
}