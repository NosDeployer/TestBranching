using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.BL.Company.Organization;
using LiquiForce.LFSLive.BL.LabourHours.ProjectTime;
using LiquiForce.LFSLive.BL.Projects.Projects;
using LiquiForce.LFSLive.BL.Resources.Companies;
using LiquiForce.LFSLive.DA.Company.Organization;
using LiquiForce.LFSLive.DA.FleetManagement.Units;
using LiquiForce.LFSLive.DA.LabourHours.ProjectTime;
using LiquiForce.LFSLive.DA.LabourHours.Timesheet;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.DA.Resources.Employees;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.Tools;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime
{
    /// <summary>
    /// timesheet_add
    /// </summary>
    public partial class timesheet_add : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // PROPERTIES AND FIELDS
        //

        protected ProjectTimeTDS projectTimeTDS;
        protected ProjectTimeTDS.LFS_PROJECT_TIME_TEMPDataTable projectTimeTemp;
        protected ProjectTimeTDS projectTimeTDSToSave;
        





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
                if (((string)Request.QueryString["source_page"] == null) && ((string)Request.QueryString["others"] == null) && ((string)Request.QueryString["employee_id"] == null) && ((string)Request.QueryString["period_id"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in timesheet_add.aspx");
                }

                // Security check
                if (!Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_FULL_EDITING"]))
                {
                    if (Request.QueryString["others"] == "no")
                    {
                        if (!(Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_MY_TIMESHEETS_VIEW"]) && Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_MY_TIMESHEETS_ADD"])))
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
                        if (!(Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_MY_TIMESHEETS_VIEW"]) && Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_MY_TIMESHEETS_ADD"])))
                        {
                            if (!Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_MY_TIMESHEETS_MANAGEMENT"]))
                            {
                                if (!Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_MY_TIMESHEETS_MANAGEMENT_WED"]))
                                {
                                    if (!(Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_OTHERS_TIMESHEETS_VIEW"]) && Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_OTHERS_TIMESHEETS_ADD"])))
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

                // Tag Page
                hdfSaveClick.Value = "false";
                hdfEmployeeID.Value = Request.QueryString["employee_id"].ToString();
                hdfPeriodId.Value = Request.QueryString["period_id"];
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfIsMoreThan15.Value = "false";
                hdfIsMoreThan15Edit.Value = "false";
                Session.Remove("projectTimeTempNewDummy");

                // Initialize viewstate variables
                ViewState["others"] = Request.QueryString["others"];
                ViewState["timesheetState"] = "For Approval";

                // Get State
                int employeeId = Int32.Parse(hdfEmployeeID.Value);
                int periodId = Int32.Parse(hdfPeriodId.Value);

                TimesheetGateway timesheet = new TimesheetGateway();
                timesheet.LoadByEmployeeIdPayPeriodId(employeeId, periodId);
                if (timesheet.Table.Rows.Count != 0)
                {
                    ViewState["timesheetState"] = timesheet.GetStateByEmployeeIdPayPeriodId(employeeId, periodId);
                }

                if (Request.QueryString["source_page"] == "timesheet_summary.aspx" || Request.QueryString["source_page"] == "timesheet_summary_from_approve_project_times.aspx")
                {
                    ViewState["projecttime_id"] = int.Parse(Request.QueryString["projecttime_id"]);
                }
                
                System.Configuration.AppSettingsReader appSettingReader = new System.Configuration.AppSettingsReader();
                ViewState["LHMode"] = appSettingReader.GetValue("LABOUR_HOURS_OPERATION_MODE", typeof(System.String)).ToString();

                // Timesheet state check
                if (((string)ViewState["LHMode"] == "Full") && (!Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_FULL_EDITING"])))
                {
                    TimesheetGateway timesheetGateway = new TimesheetGateway();
                    timesheetGateway.LoadByEmployeeIdPayPeriodId(employeeId, periodId);

                    if ((timesheetGateway.Table.Rows.Count != 0) && (timesheetGateway.GetStateByEmployeeIdPayPeriodId(employeeId, periodId) != "Rejected"))
                    {
                        Response.Redirect("./../../error_page.aspx?error=" + "You cannot add project time to an approved or submitted timesheet.");
                    }
                }

                // Prepare initial data for client
                EmployeeGateway employeeGateway = new EmployeeGateway(new DataSet());
                employeeGateway.LoadByEmployeeId(employeeId);
                tbxEmployee.Text = employeeGateway.GetFullName(employeeId);

                tbxState.Text = "For Approval";

                int companyId = Int32.Parse(hdfCompanyId.Value);
                CompaniesList companiesList = new CompaniesList(new DataSet());
                companiesList.LoadAndAddItem(-1, "(Select a client)", companyId);
                ddlClient.DataSource = companiesList.Table;
                ddlClient.DataValueField = "COMPANIES_ID";
                ddlClient.DataTextField = "Name";
                ddlClient.DataBind();
                ddlClient.SelectedIndex = 0;

                ProjectList projectList = new ProjectList();
                projectList.LoadActiveProjectsActiveInternalProjectsActiveBallparkProjectsAndAddItem(-1, "(Select a project)", -1);
                ddlProject.DataSource = projectList.Table;
                ddlProject.DataValueField = "ProjectID";
                ddlProject.DataTextField = "Name";
                ddlProject.DataBind();
                ddlProject.SelectedIndex = 0;
                                
                CountryList countryList = new CountryList(new DataSet());
                countryList.LoadAndAddItem(-1, " ");
                ddlMealsCountry.DataSource = countryList.Table;
                ddlMealsCountry.DataValueField = "CountryID";
                ddlMealsCountry.DataTextField = "Name";
                ddlMealsCountry.DataBind();

                tkrdpStartDate.SelectedDate = DateTime.Now;
                tkrdpEndDate.SelectedDate = DateTime.Now;

                // Store timesheet dataset
                projectTimeTDS = new ProjectTimeTDS();
                Session["projectTimeTDS"] = projectTimeTDS;
                projectTimeTemp = projectTimeTDS.LFS_PROJECT_TIME_TEMP;
                Session["projectTimeTemp"] = projectTimeTDS.LFS_PROJECT_TIME_TEMP; 
            }
            else
            {
                // Restore datasets
                projectTimeTDS = (ProjectTimeTDS)Session["projectTimeTDS"];
                projectTimeTemp = projectTimeTDS.LFS_PROJECT_TIME_TEMP;

                // Store datasets
                Session["projectTimeTemp"] = projectTimeTemp;
            }
        }
                          

        
        protected void grdProjectTime_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Project Time Gridview, if the gridview is edition mode
            if (grdProjectTime.EditIndex >= 0)
            {
                grdProjectTime.UpdateRow(grdProjectTime.EditIndex, true);
            }

            // Delete project time
            int projectTimeId = (int)e.Keys["ProjectTimeID"];
            
            ProjectTimeTemp model = new ProjectTimeTemp(projectTimeTDS);
            model.Delete(projectTimeId);

            // Store dataset
            Session["projectTimeTDS"] = projectTimeTDS;
            Session["projectTimeTemp"] = projectTimeTDS.LFS_PROJECT_TIME_TEMP; 
        }



        protected void grdProjectTime_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Add Range":
                    // Project Time Gridview, if the gridview is edition mode
                    if (grdProjectTime.EditIndex >= 0)
                    {
                        grdProjectTime.UpdateRow(grdProjectTime.EditIndex, true);
                    }

                    // Add New Project Time
                    GrdProjectTimeAdd();
                    break;
            }
        }



        protected void grdProjectTime_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.Validate("generalData");
            if (Page.IsValid)
            {
                Page.Validate("editValidData");
                if (Page.IsValid)
                {
                    Page.Validate("editData");
                    if (Page.IsValid)
                    {
                        int projectTimeId = (int)e.Keys["ProjectTimeID"];
                        int employeeId = Int32.Parse(hdfEmployeeID.Value);
                        int companiesId = int.Parse(ddlClient.SelectedValue);
                        int projectId = int.Parse(ddlProject.SelectedValue);
                        DateTime date_ = tkrdpStartDate.SelectedDate.Value;
                        string workingDetails = hdfWorkingDetails.Value;
                        if (projectId == 35 || projectId == 39 || projectId == 716)
                        {
                            Page.Validate("specialData");
                        }

                        if (Page.IsValid)
                        {
                            if (projectId == 35 || projectId == 39 || projectId == 716)
                            {
                                date_ = Convert.ToDateTime(((HiddenField)grdProjectTime.Rows[e.RowIndex].Cells[1].FindControl("hdfDateEdit")).Value);
                                workingDetails = ddlWorkingDetails.SelectedValue;
                            }
                            Int64? mealsCountry = null; if (ddlMealsCountry.SelectedValue != "-1") mealsCountry = Int64.Parse(ddlMealsCountry.SelectedValue);
                            
                            string startTime = "";
                            string startHoursEdit = ((DropDownList)grdProjectTime.Rows[e.RowIndex].Cells[1].FindControl("ddlStartTimeHourEdit")).SelectedValue.Trim();
                            string startMinutesEdit = ((DropDownList)grdProjectTime.Rows[e.RowIndex].Cells[1].FindControl("ddlStartTimeMinuteEdit")).SelectedValue.Trim();

                            if ((startHoursEdit != "") && (startMinutesEdit != "") )
                            {   
                                startTime = startHoursEdit + ":" + startMinutesEdit;
                            }

                            string endTime = "";
                            string endHoursEdit = ((DropDownList)grdProjectTime.Rows[e.RowIndex].Cells[1].FindControl("ddlEndTimeHourEdit")).SelectedValue.Trim();
                            string endMinutesEdit = ((DropDownList)grdProjectTime.Rows[e.RowIndex].Cells[1].FindControl("ddlEndTimeMinuteEdit")).SelectedValue.Trim();

                            if ((endHoursEdit != "") && (endMinutesEdit != ""))
                            {   
                                endTime = endHoursEdit + ":" + endMinutesEdit;
                            }

                            decimal? offset = 0; if (((DropDownList)grdProjectTime.Rows[e.RowIndex].Cells[1].FindControl("ddlLunchEdit")).SelectedValue != "0") offset = decimal.Round(Decimal.Parse(((DropDownList)grdProjectTime.Rows[e.RowIndex].Cells[1].FindControl("ddlLunchEdit")).SelectedValue), 2);
                            double? offsetFinal = null; if (offset.HasValue) offsetFinal = double.Parse(((decimal)offset).ToString());
                            bool isMealsAllowance = false;// ((CheckBox)grdProjectTime.Rows[e.RowIndex].Cells[1].FindControl("ckbxMealsAllowanceEdit")).Checked;
                            int? unitId = null; if (((DropDownList)grdProjectTime.Rows[e.RowIndex].Cells[1].FindControl("ddlUnitEdit")).SelectedValue != "-1") unitId = Int32.Parse(((DropDownList)grdProjectTime.Rows[e.RowIndex].Cells[1].FindControl("ddlUnitEdit")).SelectedValue);
                            int? towedUnitId = null; if (((DropDownList)grdProjectTime.Rows[e.RowIndex].Cells[1].FindControl("ddlTowedEdit")).SelectedValue != "-1") towedUnitId = Int32.Parse(((DropDownList)grdProjectTime.Rows[e.RowIndex].Cells[1].FindControl("ddlTowedEdit")).SelectedValue);
                            string comments = ((TextBox)grdProjectTime.Rows[e.RowIndex].Cells[1].FindControl("tbxCommentsEdit")).Text;
                            string workFunctionConcat = ((DropDownList)grdProjectTime.Rows[e.RowIndex].Cells[1].FindControl("ddlTypeOfWorkFunctionEdit")).SelectedValue;

                            ProjectGateway projectGateway = new ProjectGateway(new DataSet());
                            projectGateway.LoadByProjectId(projectId);
                            bool fairWage = projectGateway.GetFairWageApplies(projectId);

                            string work_ = "";
                            string function_ = "";
                            if (workFunctionConcat != "(Select)" && workFunctionConcat != "")
                            {
                                string[] workFunction = workFunctionConcat.ToString().Trim().Split('.');
                                work_ = workFunction[0].Trim();
                                function_ = workFunction[1].Trim();
                            }

                            CountryGateway countryGateway = new CountryGateway(new DataSet());
                            countryGateway.LoadByCountryId(projectGateway.GetCountryID(projectId));
                            string location = countryGateway.GetName(projectGateway.GetCountryID(projectId));

                            string mealsAllowanceType = ""; if (isMealsAllowance) mealsAllowanceType = "Full Day";
                            decimal mealsAllowance = MealsAllowance.GetMealsAllowance(mealsCountry, isMealsAllowance, "Full Day");

                            string jobClassType = ((DropDownList)grdProjectTime.Rows[e.RowIndex].Cells[1].FindControl("ddlJobClassTypeEdit")).SelectedValue;

                            // Update data
                            ProjectTimeTemp model = new ProjectTimeTemp(projectTimeTDS);
                            model.Update(projectTimeId, companiesId, projectId, date_, startTime, endTime, offsetFinal, workingDetails, location, mealsCountry, mealsAllowanceType, isMealsAllowance, mealsAllowance, unitId, towedUnitId, comments, work_, function_, workFunctionConcat, fairWage, jobClassType);

                            // Store dataset
                            Session.Remove("projectTimeTempNewDummy");
                            Session["projectTimeTDS"] = projectTimeTDS;
                            Session["projectTimeTemp"] = projectTimeTDS.LFS_PROJECT_TIME_TEMP;
                        }
                        else
                        {
                            e.Cancel = true;
                        }
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
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
                int employeeIdForMenu = employeeGateway1.GetEmployeIdByLoginId(Convert.ToInt32(Session["loginID"]));
                employeeGateway1.LoadByEmployeeId(employeeIdForMenu);

                if (!employeeGateway1.GetApproveTimesheets(employeeIdForMenu))
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
                        employeeListGateway.LoadByRequestProjectTimeWithoutEmployeeId(1, employeeIdForMenu);
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

                    if (!employeeGateway1.GetApproveTimesheets(employeeIdForMenu))
                    {
                        tkrpbLeftMenuTools.Visible = false;
                    }

                    tkrpbLeftMenuTools.Items[0].Items[0].Visible = false; // Add Team Project Time
                    tkrpbLeftMenuTools.Items[0].Items[2].Visible = false; // Missing Project Time
                }

                if (!((Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_MY_TIMESHEETS_VIEW"]) || Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_MY_TIMESHEETS_MANAGEMENT"]) || Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_MY_TIMESHEETS_MANAGEMENT_WED"]) || Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_FULL_EDITING"])) && (employeeGateway1.GetRequestProjectTime(employeeIdForMenu))))
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

        protected void grdProjectTime_DataBound(object sender, EventArgs e)
        {
            AddProjectTimeNewEmptyFix(grdProjectTime);
        }



        protected void grdProjectTime_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Footer Item
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                EmployeeInformationBasicInformationGateway employeeInformationBasicInformation = new EmployeeInformationBasicInformationGateway();
                employeeInformationBasicInformation.LoadByEmployeeId(Int32.Parse(hdfEmployeeID.Value));
                string jobClassType = employeeInformationBasicInformation.GetJobClassType(Int32.Parse(hdfEmployeeID.Value));

                if (jobClassType != "")
                {
                    try
                    {
                        ((DropDownList)e.Row.FindControl("ddlJobClassTypeFooter")).SelectedValue = jobClassType;
                    }
                    catch
                    {
                    }
                }
            }

            // Edit Item
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Edit) || (e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
            {
                int projectTimeId = Int32.Parse(((Label)e.Row.FindControl("lblProjectTimeIdEdit")).Text.Trim());                
                ProjectTimeTempGateway projectTimeTempGateway = new ProjectTimeTempGateway(projectTimeTDS);

                // For Start Time
                string startTime = ""; if (projectTimeTempGateway.GetStartTime(projectTimeId) != "") startTime = projectTimeTempGateway.GetStartTime(projectTimeId);
                if (startTime != "")
                {
                    string[] hoursMin1 = startTime.Split(':');

                    ((DropDownList)e.Row.FindControl("ddlStartTimeHourEdit")).SelectedValue = hoursMin1[0].Trim();
                    ((DropDownList)e.Row.FindControl("ddlStartTimeMinuteEdit")).SelectedValue = hoursMin1[1].Trim();
                }

                // For End Time
                string endTime = ""; if (projectTimeTempGateway.GetEndTime(projectTimeId) != "") endTime = projectTimeTempGateway.GetEndTime(projectTimeId);
                if (endTime != "")
                {
                    string[] endHoursMin1 = endTime.Split(':');

                    ((DropDownList)e.Row.FindControl("ddlEndTimeHourEdit")).SelectedValue = endHoursMin1[0].Trim();
                    ((DropDownList)e.Row.FindControl("ddlEndTimeMinuteEdit")).SelectedValue = endHoursMin1[1].Trim();
                }

                // For Type of work
                string workFunctionConcat = projectTimeTempGateway.GetWorkFunctionConcat(projectTimeId);
                ((DropDownList)e.Row.FindControl("ddlTypeOfWorkFunctionEdit")).SelectedValue = workFunctionConcat;

                // For UnitId
                int? unitId = null; if (projectTimeTempGateway.GetUnitId(projectTimeId).HasValue) unitId = (int)projectTimeTempGateway.GetUnitId(projectTimeId);
                if (unitId.HasValue)
                {
                    ((DropDownList)e.Row.FindControl("ddlUnitEdit")).SelectedValue = ((int)unitId).ToString();
                }

                // For TowedId
                int? towedId = null; if (projectTimeTempGateway.GetTowedUnitId(projectTimeId).HasValue) towedId = (int)projectTimeTempGateway.GetTowedUnitId(projectTimeId);
                if (towedId.HasValue)
                {
                    ((DropDownList)e.Row.FindControl("ddlTowedEdit")).SelectedValue = ((int)towedId).ToString();
                }

                string jobClassType = projectTimeTempGateway.GetJobClassType(projectTimeId);

                if (jobClassType != "")
                {
                    try
                    {
                        ((DropDownList)e.Row.FindControl("ddlJobClassTypeEdit")).SelectedValue = jobClassType;
                    }
                    catch
                    {
                    }
                }
            }
        }



        protected void grdProjectTime_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Project Time Gridview, if the gridview is edition mode
            if (grdProjectTime.EditIndex >= 0)
            {
                grdProjectTime.UpdateRow(grdProjectTime.EditIndex, true);
            }
        }



        protected void ddlClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProjectList projectList = new ProjectList();
            projectList.LoadActiveProjectsActiveInternalProjectsActiveBallparkProjectsAndAddItem(-1, "(Select a project)", int.Parse(ddlClient.SelectedValue));
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
                int companiesId = int.Parse(ddlClient.SelectedValue);
                int projectId = int.Parse(ddlProject.SelectedValue);

                ProjectGateway projectGateway = new ProjectGateway(new DataSet());
                projectGateway.LoadByProjectId(projectId);

                CountryGateway countryGateway = new CountryGateway(new DataSet());
                countryGateway.LoadByCountryId(projectGateway.GetCountryID(projectId));

                if (projectGateway.GetFairWageApplies(projectId))
                {
                    if (projectGateway.GetCountryID(Int32.Parse(ddlProject.SelectedValue)) == 1) //Canada
                    {
                        odsJobClassType.SelectParameters.Clear();
                        odsJobClassType.SelectParameters.Add("countryId", "1");
                        odsJobClassType.SelectParameters.Add("jobClassType", "(Select a Job Class Type)");
                        odsJobClassType.SelectParameters.Add("companyId", "3");
                        odsJobClassType.Select();
                    }
                    else
                    {
                        odsJobClassType.SelectParameters.Clear();
                        odsJobClassType.SelectParameters.Add("countryId", "2");
                        odsJobClassType.SelectParameters.Add("jobClassType", "(Select a Job Class Type)");
                        odsJobClassType.SelectParameters.Add("companyId", "3");
                        odsJobClassType.Select();
                    }
                }
                else
                {
                    odsJobClassType.SelectParameters.Clear();
                    odsJobClassType.SelectParameters.Add("countryId", "-1");
                    odsJobClassType.SelectParameters.Add("jobClassType", "");
                    odsJobClassType.SelectParameters.Add("companyId", "3");
                    odsJobClassType.Select();
                }

                if (projectId != 35 && projectId != 39 && projectId != 716)
                {
                    switch (projectGateway.GetCountryID(projectId))
                    {
                        case 1:
                            ddlMealsCountry.SelectedValue = "1";
                            hdfWorkingDetails.Value = "Canada";
                            break;
                        case 2:
                            ddlMealsCountry.SelectedValue = "2";
                            hdfWorkingDetails.Value = "USA";
                            break;
                    }

                    if (tkrdpEndDate.Visible)
                    {
                        lblStartDate.Text = "Date";
                        lblLastDate.Visible = false;
                        tkrdpEndDate.Visible = false;
                    }

                    odsWorkingDetails.SelectParameters.RemoveAt(0);
                    odsWorkingDetails.SelectParameters.Add("workingDetails", "");
                    odsWorkingDetails.Select();
                    ddlWorkingDetails.DataBind();
                    ddlWorkingDetails.SelectedIndex = 0;
                    lblWorkingDetails.Visible = false;
                    ddlWorkingDetails.Visible = false;
                    lblMealsCountry.Visible = true;
                    ddlMealsCountry.Visible = true;
                    grdProjectTime.Visible = true;
                    lblCommentsVacation.Visible = false;
                    tbxCommentsVacation.Visible = false;

                    odsWorkFunctionConcat.SelectParameters.RemoveAt(0);
                    odsWorkFunctionConcat.SelectParameters.Add("workFunctionConcat", "(Select)");
                    odsWorkFunctionConcat.Select();
                }
                else
                {
                    ddlMealsCountry.SelectedIndex = 0;
                    if (!tkrdpEndDate.Visible)
                    {
                        lblStartDate.Text = "Start Date";
                        lblLastDate.Visible = true;
                        tkrdpEndDate.Visible = true;
                    }

                    odsWorkingDetails.SelectParameters.RemoveAt(0);
                    odsWorkingDetails.SelectParameters.Add("workingDetails", "(Select)");
                    odsWorkingDetails.Select();
                    ddlWorkingDetails.DataBind();
                    ddlWorkingDetails.SelectedIndex = 0;
                    lblWorkingDetails.Visible = true;
                    ddlWorkingDetails.Visible = true;
                    lblMealsCountry.Visible = false;
                    ddlMealsCountry.Visible = false;
                    grdProjectTime.Visible = false;
                    lblCommentsVacation.Visible = true;
                    tbxCommentsVacation.Visible = true;

                    odsWorkFunctionConcat.SelectParameters.RemoveAt(0);
                    odsWorkFunctionConcat.SelectParameters.Add("workFunctionConcat", "");
                    odsWorkFunctionConcat.Select();
                }
            }

            grdProjectTime.DataBind();
        }



        protected void ddlStartTimeHourFooter_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlStartTimeHour = (DropDownList)grdProjectTime.FooterRow.FindControl("ddlStartTimeHourFooter");
            DropDownList ddlStartTimeMinute = (DropDownList)grdProjectTime.FooterRow.FindControl("ddlStartTimeMinuteFooter");
            DropDownList ddlEndTimeHour = (DropDownList)grdProjectTime.FooterRow.FindControl("ddlEndTimeHourFooter");
            DropDownList ddlEndTimeMinute = (DropDownList)grdProjectTime.FooterRow.FindControl("ddlEndTimeMinuteFooter");
            UpdatePanel upEndTime = (UpdatePanel)grdProjectTime.FooterRow.FindControl("upEndTimeFooter");

            if (tkrdpStartDate.SelectedDate.Value.DayOfWeek == DayOfWeek.Sunday)
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

            if (IsMoreThan15Footer())
            {
                hdfIsMoreThan15.Value = "true";
            }
            else
            {
                hdfIsMoreThan15.Value = "false";
            }

            upIsMoreThan15.Update();
        }



        protected void ddlStartTimeHourEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlStartTimeHour = (DropDownList)grdProjectTime.Rows[grdProjectTime.EditIndex].Cells[1].FindControl("ddlStartTimeHourEdit");
            DropDownList ddlStartTimeMinute = (DropDownList)grdProjectTime.Rows[grdProjectTime.EditIndex].Cells[1].FindControl("ddlStartTimeMinuteEdit");
            DropDownList ddlEndTimeHour = (DropDownList)grdProjectTime.Rows[grdProjectTime.EditIndex].Cells[1].FindControl("ddlEndTimeHourEdit");
            DropDownList ddlEndTimeMinute = (DropDownList)grdProjectTime.Rows[grdProjectTime.EditIndex].Cells[1].FindControl("ddlEndTimeMinuteEdit");
            UpdatePanel upEndTime = (UpdatePanel)grdProjectTime.Rows[grdProjectTime.EditIndex].Cells[1].FindControl("upEndTimeEdit");

            if (tkrdpStartDate.SelectedDate.Value.DayOfWeek == DayOfWeek.Sunday)
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
                    }
                }

                ddlEndTimeMinute.SelectedIndex = 1;
                upEndTime.Update();
            }

            if (IsMoreThan15Edit())
            {
                hdfIsMoreThan15Edit.Value = "true";
            }
            else
            {
                hdfIsMoreThan15Edit.Value = "false";
            }

            upIsMoreThan15Edit.Update();
        }



        protected void ddlEndTimeHourFooter_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlStartTimeHour = (DropDownList)grdProjectTime.FooterRow.FindControl("ddlStartTimeHourFooter");
            DropDownList ddlStartTimeMinute = (DropDownList)grdProjectTime.FooterRow.FindControl("ddlStartTimeMinuteFooter");
            DropDownList ddlEndTimeHour = (DropDownList)grdProjectTime.FooterRow.FindControl("ddlEndTimeHourFooter");
            DropDownList ddlEndTimeMinute = (DropDownList)grdProjectTime.FooterRow.FindControl("ddlEndTimeMinuteFooter");
            UpdatePanel upEndTime = (UpdatePanel)grdProjectTime.FooterRow.FindControl("upEndTimeFooter");

            if (tkrdpStartDate.SelectedDate.Value.DayOfWeek == DayOfWeek.Sunday)
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

                upEndTime.Update();
            }

            if (IsMoreThan15Footer())
            {
                hdfIsMoreThan15.Value = "true";
            }
            else
            {
                hdfIsMoreThan15.Value = "false";
            }

            upIsMoreThan15.Update();
        }



        protected void ddlEndTimeHourEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlStartTimeHour = (DropDownList)grdProjectTime.Rows[grdProjectTime.EditIndex].Cells[1].FindControl("ddlStartTimeHourEdit");
            DropDownList ddlStartTimeMinute = (DropDownList)grdProjectTime.Rows[grdProjectTime.EditIndex].Cells[1].FindControl("ddlStartTimeMinuteEdit");
            DropDownList ddlEndTimeHour = (DropDownList)grdProjectTime.Rows[grdProjectTime.EditIndex].Cells[1].FindControl("ddlEndTimeHourEdit");
            DropDownList ddlEndTimeMinute = (DropDownList)grdProjectTime.Rows[grdProjectTime.EditIndex].Cells[1].FindControl("ddlEndTimeMinuteEdit");
            UpdatePanel upEndTime = (UpdatePanel)grdProjectTime.Rows[grdProjectTime.EditIndex].Cells[1].FindControl("upEndTimeEdit");

            if (tkrdpStartDate.SelectedDate.Value.DayOfWeek == DayOfWeek.Sunday)
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

                upEndTime.Update();
            }

            if (IsMoreThan15Edit())
            {
                hdfIsMoreThan15Edit.Value = "true";
            }
            else
            {
                hdfIsMoreThan15Edit.Value = "false";
            }

            upIsMoreThan15Edit.Update();
        }



        protected void ddlEndTimeMinuteFooter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsMoreThan15Footer())
            {
                hdfIsMoreThan15.Value = "true";
            }
            else
            {
                hdfIsMoreThan15.Value = "false";
            }

            upIsMoreThan15.Update();
        }



        protected void ddlEndTimeMinuteEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsMoreThan15Edit())
            {
                hdfIsMoreThan15Edit.Value = "true";
            }
            else
            {
                hdfIsMoreThan15Edit.Value = "false";
            }

            upIsMoreThan15Edit.Update();
        }



        protected void cvMealsCountry_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // For footer
            bool mealsAllowance = false;// ((CheckBox)grdProjectTime.FooterRow.FindControl("ckbxMealsAllowanceFooter")).Checked;
            string mealsCountry = ddlMealsCountry.SelectedValue;

            args.IsValid = true;
            if (mealsAllowance)
            {
                if (mealsCountry == "-1")
                {
                    args.IsValid = false;
                }
            }           
        }



        protected void cvMealsCountryEdit_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            if (grdProjectTime.Rows.Count > 0)
            {
                foreach (GridViewRow row in grdProjectTime.Rows)
                {
                    if ((row.RowType == DataControlRowType.DataRow) && ((row.RowState == DataControlRowState.Edit) || (row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
                    {
                        bool mealsAllowance = false;// ((CheckBox)row.FindControl("ckbxMealsAllowanceEdit")).Checked;
                        string mealsCountry = ddlMealsCountry.SelectedValue;

                        if (mealsAllowance)
                        {
                            if (mealsCountry == "-1")
                            {
                                args.IsValid = false;
                            }
                        }
                    }
                }
            } 
        }



        protected void cvValidMealsCountryFooter_ServerValidate(object source, ServerValidateEventArgs args)
        {
            bool mealsAllowance = false;// ((CheckBox)grdProjectTime.FooterRow.FindControl("ckbxMealsAllowanceFooter")).Checked;
            string mealsCountry = ddlMealsCountry.SelectedValue;

            args.IsValid = true;
            if (mealsAllowance)
            {
                if (mealsCountry == "-1")
                {
                    args.IsValid = false;
                }
            }
        }



        protected void cvValidMealsCountryEdit_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            if (grdProjectTime.Rows.Count > 0)
            {
                foreach (GridViewRow row in grdProjectTime.Rows)
                {
                    if ((row.RowType == DataControlRowType.DataRow) && ((row.RowState == DataControlRowState.Edit) || (row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
                    {
                        bool mealsAllowance = false;// ((CheckBox)row.FindControl("ckbxMealsAllowanceEdit")).Checked;
                        string mealsCountry = ddlMealsCountry.SelectedValue;

                        if (mealsAllowance)
                        {
                            if (mealsCountry == "-1")
                            {
                                args.IsValid = false;
                            }
                        }
                    }
                }
            } 
        }        



        protected void cvValidStartTimeFooter_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = false;
            string startHoursFooter = ""; if (((DropDownList)grdProjectTime.FooterRow.FindControl("ddlStartTimeHourFooter")).SelectedValue.Trim() != "") startHoursFooter = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlStartTimeHourFooter")).SelectedValue.Trim();
            string startMinutesFooter = ""; if (((DropDownList)grdProjectTime.FooterRow.FindControl("ddlStartTimeMinuteFooter")).SelectedValue.Trim() != "") startMinutesFooter = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlStartTimeMinuteFooter")).SelectedValue.Trim();

            if ((startHoursFooter != "") && (startMinutesFooter != "" || startMinutesFooter != "00"))
            {
                args.IsValid = true;
            }

            if ((startHoursFooter == "") && (startMinutesFooter == "" || startMinutesFooter == "00"))
            {
                args.IsValid = true;
            }
        }



        protected void cvValidEndTimeFooter_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = false;
            string endHoursFooter = ""; if (((DropDownList)grdProjectTime.FooterRow.FindControl("ddlEndTimeHourFooter")).SelectedValue.Trim() != "") endHoursFooter = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlEndTimeHourFooter")).SelectedValue.Trim();
            string endMinutesFooter = ""; if (((DropDownList)grdProjectTime.FooterRow.FindControl("ddlEndTimeMinuteFooter")).SelectedValue.Trim() != "") endMinutesFooter = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlEndTimeMinuteFooter")).SelectedValue.Trim();

            if ((endHoursFooter != "") && (endMinutesFooter != "" || endMinutesFooter != "00"))
            {
                args.IsValid = true;
            }
            if ((endHoursFooter == "") && (endMinutesFooter == "" || endMinutesFooter == "00"))
            {
                args.IsValid = true;
            }
        } 



        protected void cvStartTimeDeleteFooter_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string workingDetails = ddlWorkingDetails.SelectedValue;
            string startTime = "";
            string startHoursFooter = ""; if (((DropDownList)grdProjectTime.FooterRow.FindControl("ddlStartTimeHourFooter")).SelectedValue.Trim() != "") startHoursFooter = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlStartTimeHourFooter")).SelectedValue.Trim();
            string startMinutesFooter = ""; if (((DropDownList)grdProjectTime.FooterRow.FindControl("ddlStartTimeMinuteFooter")).SelectedValue.Trim() != "") startMinutesFooter = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlStartTimeMinuteFooter")).SelectedValue.Trim();

            if ((startHoursFooter != "") && (startMinutesFooter != ""))
            {
                startTime = startHoursFooter + ":" + startMinutesFooter;
            }
            
            args.IsValid = true;

            int projectId = int.Parse(ddlProject.SelectedValue);

            if (projectId == 35 || projectId == 39 || projectId == 716)
            {
                if ((workingDetails != "USA") && (workingDetails != "Canada"))
                {
                    if (startTime.Trim() != "")
                    {
                        args.IsValid = false;
                    }
                }
            }
        }



        protected void cvValidStartTimeEdit_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = false;
            foreach (GridViewRow row in grdProjectTime.Rows)
            {
                if ((row.RowType == DataControlRowType.DataRow) && ((row.RowState == DataControlRowState.Edit) || (row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
                {
                    string startHoursEdit = ""; if (((DropDownList)row.FindControl("ddlStartTimeHourEdit")).SelectedValue.Trim() != "") startHoursEdit = ((DropDownList)row.FindControl("ddlStartTimeHourEdit")).SelectedValue.Trim();
                    string startMinutesEdit = ""; if (((DropDownList)row.FindControl("ddlStartTimeMinuteEdit")).SelectedValue.Trim() != "") startMinutesEdit = ((DropDownList)row.FindControl("ddlStartTimeMinuteEdit")).SelectedValue.Trim();
                    
                    if ((startHoursEdit != "") && (startMinutesEdit != ""))
                    {
                        args.IsValid = true;
                    }

                    if ((startHoursEdit == "") && (startMinutesEdit == ""))
                    {
                        args.IsValid = true;
                    }
                }
            }
        }



        protected void cvValidEndTimeEdit_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = false;
            foreach (GridViewRow row in grdProjectTime.Rows)
            {
                if ((row.RowType == DataControlRowType.DataRow) && ((row.RowState == DataControlRowState.Edit) || (row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
                {
                    string endHoursEdit = ""; if (((DropDownList)row.FindControl("ddlEndTimeHourEdit")).SelectedValue.Trim() != "") endHoursEdit = ((DropDownList)row.FindControl("ddlEndTimeHourEdit")).SelectedValue.Trim();
                    string endMinutesEdit = ""; if (((DropDownList)row.FindControl("ddlEndTimeMinuteEdit")).SelectedValue.Trim() != "") endMinutesEdit = ((DropDownList)row.FindControl("ddlEndTimeMinuteEdit")).SelectedValue.Trim();

                    if ((endHoursEdit != "") && (endMinutesEdit != ""))
                    {
                        args.IsValid = true;
                    }

                    if ((endHoursEdit == "") && (endMinutesEdit == ""))
                    {
                        args.IsValid = true;
                    }
                }
            }
        }



        protected void cvStartTimeDeleteEdit_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            if (grdProjectTime.Rows.Count > 0)
            {
                foreach (GridViewRow row in grdProjectTime.Rows)
                {
                    if ((row.RowType == DataControlRowType.DataRow) && ((row.RowState == DataControlRowState.Edit) || (row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
                    {
                        string workingDetails = ddlWorkingDetails.SelectedValue;
                        string startTime = "";
                        string startHoursEdit = ""; if (((DropDownList)row.FindControl("ddlStartTimeHourEdit")).SelectedValue.Trim() != "") startHoursEdit = ((DropDownList)row.FindControl("ddlStartTimeHourEdit")).SelectedValue.Trim();
                        string startMinutesEdit = ""; if (((DropDownList)row.FindControl("ddlStartTimeMinuteEdit")).SelectedValue.Trim() != "") startMinutesEdit = ((DropDownList)row.FindControl("ddlStartTimeMinuteEdit")).SelectedValue.Trim();

                        if ((startHoursEdit != "") && (startMinutesEdit != ""))
                        {   
                            startTime = startHoursEdit + ":" + startMinutesEdit;
                        }

                        int projectId = int.Parse(ddlProject.SelectedValue);

                        if (projectId == 35 || projectId == 39 || projectId == 716)
                        {
                            if ((workingDetails != "USA") && (workingDetails != "Canada"))
                            {
                                if (startTime.Trim() != "")
                                {
                                    args.IsValid = false;
                                }
                            }
                        }
                    }
                }
            } 
        }



        protected void cvEndTimeDeleteFooter_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string workingDetails = ddlWorkingDetails.SelectedValue;
            string endTime = "";
            string endHoursFooter = ""; if (((DropDownList)grdProjectTime.FooterRow.FindControl("ddlEndTimeHourFooter")).SelectedValue.Trim() != "") endHoursFooter = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlEndTimeHourFooter")).SelectedValue.Trim();
            string endMinutesFooter = ""; if (((DropDownList)grdProjectTime.FooterRow.FindControl("ddlEndTimeMinuteFooter")).SelectedValue.Trim() != "") endMinutesFooter = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlEndTimeMinuteFooter")).SelectedValue.Trim();

            if ((endHoursFooter != "") && (endMinutesFooter != ""))
            {
                endTime = endHoursFooter + ":" + endMinutesFooter;
            }

            args.IsValid = true;

            int projectId = int.Parse(ddlProject.SelectedValue);

            if (projectId == 35 || projectId == 39 || projectId == 716)
            {
                if ((workingDetails != "USA") && (workingDetails != "Canada"))
                {
                    if (endTime.Trim() != "")
                    {
                        args.IsValid = false;
                    }
                }
            }
        }



        protected void cvTypeOfWorkFunctionDeleteFooter_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string workingDetails = ddlWorkingDetails.SelectedValue;
            string typeOfWorkFooter = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlTypeOfWorkFooter")).SelectedValue;

            args.IsValid = true;

            int projectId = int.Parse(ddlProject.SelectedValue);

            if (projectId == 35 || projectId == 39 || projectId == 716)
            {
                if ((workingDetails != "USA") && (workingDetails != "Canada"))
                {
                    if (typeOfWorkFooter.Trim() != "(Select)" && typeOfWorkFooter.Trim() != "")
                    {
                        args.IsValid = false;
                    }
                }
            }
        }



        protected void cvUnitDeleteFooter_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string workingDetails = ddlWorkingDetails.SelectedValue;
            string unitFooter = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlUnitFooter")).SelectedValue;

            args.IsValid = true;

            int projectId = int.Parse(ddlProject.SelectedValue);

            if (projectId == 35 || projectId == 39 || projectId == 716)
            {
                if ((workingDetails != "USA") && (workingDetails != "Canada"))
                {
                    if (unitFooter.Trim() != "-1")
                    {
                        args.IsValid = false;
                    }
                }
            }
        }



        protected void cvTowedDeleteFooter_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string workingDetails = ddlWorkingDetails.SelectedValue;
            string towedFooter = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlTowedFooter")).SelectedValue;

            args.IsValid = true;

            int projectId = int.Parse(ddlProject.SelectedValue);

            if (projectId == 35 || projectId == 39 || projectId == 716)
            {
                if ((workingDetails != "USA") && (workingDetails != "Canada"))
                {
                    if (towedFooter.Trim() != "-1")
                    {
                        args.IsValid = false;
                    }
                }
            }
        }



        protected void cvEndTimeDeleteEdit_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            if (grdProjectTime.Rows.Count > 0)
            {
                foreach (GridViewRow row in grdProjectTime.Rows)
                {
                    if ((row.RowType == DataControlRowType.DataRow) && ((row.RowState == DataControlRowState.Edit) || (row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
                    {
                        string workingDetails = ddlWorkingDetails.SelectedValue;
                        string endTime = "";
                        string endHoursEdit = ""; if (((DropDownList)row.FindControl("ddlEndTimeHourEdit")).SelectedValue.Trim() != "") endHoursEdit = ((DropDownList)row.FindControl("ddlEndTimeHourEdit")).SelectedValue.Trim();
                        string endMinutesEdit = ""; if (((DropDownList)row.FindControl("ddlEndTimeMinuteEdit")).SelectedValue.Trim() != "") endMinutesEdit = ((DropDownList)row.FindControl("ddlEndTimeMinuteEdit")).SelectedValue.Trim();

                        if ((endHoursEdit != "") && (endMinutesEdit != ""))
                        {
                            endTime = endHoursEdit + ":" + endMinutesEdit;
                        }

                        int projectId = int.Parse(ddlProject.SelectedValue);

                        if (projectId == 35 || projectId == 39 || projectId == 716)
                        {
                            if ((workingDetails != "USA") && (workingDetails != "Canada"))
                            {
                                if (endTime.Trim() != "")
                                {
                                    args.IsValid = false;
                                }
                            }
                        }
                    }
                }
            } 
        }



        protected void cvTypeOfWorkFunctionDeleteEdit_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            if (grdProjectTime.Rows.Count > 0)
            {
                foreach (GridViewRow row in grdProjectTime.Rows)
                {
                    if ((row.RowType == DataControlRowType.DataRow) && ((row.RowState == DataControlRowState.Edit) || (row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
                    {
                        string workingDetails = ddlWorkingDetails.SelectedValue;
                        string typeOfWorkFunction = ((DropDownList)row.FindControl("ddlTypeOfWorkFunctionEdit")).SelectedValue;

                        int projectId = int.Parse(ddlProject.SelectedValue);

                        if (projectId == 35 || projectId == 39 || projectId == 716)
                        {
                            if ((workingDetails != "USA") && (workingDetails != "Canada"))
                            {
                                if (typeOfWorkFunction.Trim() != "(Select)" && typeOfWorkFunction.Trim() != "")
                                {
                                    args.IsValid = false;
                                }
                            }
                        }
                    }
                }
            }
        }



        protected void cvUnitDeleteEdit_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            if (grdProjectTime.Rows.Count > 0)
            {
                foreach (GridViewRow row in grdProjectTime.Rows)
                {
                    if ((row.RowType == DataControlRowType.DataRow) && ((row.RowState == DataControlRowState.Edit) || (row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
                    {
                        string workingDetails = ddlWorkingDetails.SelectedValue;
                        string unit = ((DropDownList)row.FindControl("ddlUnitEdit")).SelectedValue;

                        int projectId = int.Parse(ddlProject.SelectedValue);

                        if (projectId == 35 || projectId == 39 || projectId == 716)
                        {
                            if ((workingDetails != "USA") && (workingDetails != "Canada"))
                            {
                                if (unit.Trim() != "-1")
                                {
                                    args.IsValid = false;
                                }
                            }
                        }
                    }
                }
            }
        }



        protected void cvTowedDeleteEdit_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            if (grdProjectTime.Rows.Count > 0)
            {
                foreach (GridViewRow row in grdProjectTime.Rows)
                {
                    if ((row.RowType == DataControlRowType.DataRow) && ((row.RowState == DataControlRowState.Edit) || (row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
                    {
                        string workingDetails = ddlWorkingDetails.SelectedValue;
                        string towed = ((DropDownList)row.FindControl("ddlTowedEdit")).SelectedValue;

                        int projectId = int.Parse(ddlProject.SelectedValue);

                        if (projectId == 35 || projectId == 39 || projectId == 716)
                        {
                            if ((workingDetails != "USA") && (workingDetails != "Canada"))
                            {
                                if (towed.Trim() != "-1")
                                {
                                    args.IsValid = false;
                                }
                            }
                        }
                    }
                }
            }
        }



        protected void cvLunchDeleteFooter_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string workingDetails = ddlWorkingDetails.SelectedValue;
            string lunch = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlLunchFooter")).SelectedValue;

            args.IsValid = true;

            int projectId = int.Parse(ddlProject.SelectedValue);

            if (projectId == 35 || projectId == 39 || projectId == 716)
            {
                if ((workingDetails != "USA") && (workingDetails != "Canada"))
                {
                    if (lunch.Trim() != "0")
                    {
                        args.IsValid = false;
                    }
                }
            }
        }



        protected void cvLunchDeleteEdit_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            if (grdProjectTime.Rows.Count > 0)
            {
                foreach (GridViewRow row in grdProjectTime.Rows)
                {
                    if ((row.RowType == DataControlRowType.DataRow) && ((row.RowState == DataControlRowState.Edit) || (row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
                    {
                        string workingDetails = ddlWorkingDetails.SelectedValue;
                        string lunch = ((DropDownList)row.FindControl("ddlLunchEdit")).SelectedValue;

                        int projectId = int.Parse(ddlProject.SelectedValue);

                        if (projectId == 35 || projectId == 39 || projectId == 716)
                        {
                            if ((workingDetails != "USA") && (workingDetails != "Canada"))
                            {
                                if (lunch.Trim() != "0")
                                {
                                    args.IsValid = false;
                                }
                            }
                        }
                    }
                }
            } 
        }



        protected void cvStartTimeProvideFooter_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string workingDetails = ddlWorkingDetails.SelectedValue;
            string startTime = "";
            string startHoursFooter = ""; if (((DropDownList)grdProjectTime.FooterRow.FindControl("ddlStartTimeHourFooter")).SelectedValue.Trim() != "") startHoursFooter = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlStartTimeHourFooter")).SelectedValue.Trim();
            string startMinutesFooter = ""; if (((DropDownList)grdProjectTime.FooterRow.FindControl("ddlStartTimeMinuteFooter")).SelectedValue.Trim() != "") startMinutesFooter = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlStartTimeMinuteFooter")).SelectedValue.Trim();

            if ((startHoursFooter != "") && (startMinutesFooter != ""))
            {
                startTime = startHoursFooter + ":" + startMinutesFooter;
            }

            args.IsValid = true;

            int projectId = int.Parse(ddlProject.SelectedValue);

            if (projectId != 35 && projectId != 39 && projectId != 716)
            {
                if (startTime.Trim() == "")
                {
                    args.IsValid = false;
                }
            }
        }



        protected void cvStartTimeProvideEdit_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            if (grdProjectTime.Rows.Count > 0)
            {
                foreach (GridViewRow row in grdProjectTime.Rows)
                {
                    if ((row.RowType == DataControlRowType.DataRow) && ((row.RowState == DataControlRowState.Edit) || (row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
                    {
                        string workingDetails = ddlWorkingDetails.SelectedValue;
                        string startTime = "";
                        string startHoursEdit = ""; if (((DropDownList)row.FindControl("ddlStartTimeHourEdit")).SelectedValue.Trim() != "") startHoursEdit = ((DropDownList)row.FindControl("ddlStartTimeHourEdit")).SelectedValue.Trim();
                        string startMinutesEdit = ""; if (((DropDownList)row.FindControl("ddlStartTimeMinuteEdit")).SelectedValue.Trim() != "") startMinutesEdit = ((DropDownList)row.FindControl("ddlStartTimeMinuteEdit")).SelectedValue.Trim();

                        if ((startHoursEdit != "") && (startMinutesEdit != ""))
                        {
                            startTime = startHoursEdit + ":" + startMinutesEdit;
                        }

                        int projectId = int.Parse(ddlProject.SelectedValue);

                        if (projectId != 35 && projectId != 39 && projectId != 716)
                        {
                            if (startTime.Trim() == "")
                            {
                                args.IsValid = false;
                            }
                        }
                    }
                }
            }    
        }



        protected void cvProvideEndTimeFooter_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string endTime = "";
            string endHoursFooter = ""; if (((DropDownList)grdProjectTime.FooterRow.FindControl("ddlEndTimeHourFooter")).SelectedValue.Trim() != "") endHoursFooter = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlEndTimeHourFooter")).SelectedValue.Trim();
            string endMinutesFooter = ""; if (((DropDownList)grdProjectTime.FooterRow.FindControl("ddlEndTimeMinuteFooter")).SelectedValue.Trim() != "") endMinutesFooter = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlEndTimeMinuteFooter")).SelectedValue.Trim();

            if ((endHoursFooter != "") && (endMinutesFooter != ""))
            {
                endTime = endHoursFooter + ":" + endMinutesFooter ;
            }
            args.IsValid = true;

            int projectId = int.Parse(ddlProject.SelectedValue);

            if (projectId != 35 && projectId != 39 && projectId != 716)
            {
                if (endTime.Trim() == "")
                {
                    args.IsValid = false;
                }
            }
        }



        protected void cvProvideTypeOfWorkFunctionFooter_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string typeOfWork = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlTypeOfWorkFooter")).SelectedValue;

            args.IsValid = true;

            int projectId = int.Parse(ddlProject.SelectedValue);

            if (projectId != 35 && projectId != 39 && projectId != 716)
            {
                if (typeOfWork.Trim() == "(Select)")
                {
                    args.IsValid = false;
                }
            }
        }


        protected void cvProvideEndTimeEdit_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            if (grdProjectTime.Rows.Count > 0)
            {
                foreach (GridViewRow row in grdProjectTime.Rows)
                {
                    if ((row.RowType == DataControlRowType.DataRow) && ((row.RowState == DataControlRowState.Edit) || (row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
                    {
                        string workingDetails = ddlWorkingDetails.SelectedValue;
                        string endTime = "";
                        string endHoursEdit = ""; if (((DropDownList)row.FindControl("ddlEndTimeHourEdit")).SelectedValue.Trim() != "") endHoursEdit = ((DropDownList)row.FindControl("ddlEndTimeHourEdit")).SelectedValue.Trim();
                        string endMinutesEdit = ""; if (((DropDownList)row.FindControl("ddlEndTimeMinuteEdit")).SelectedValue.Trim() != "") endMinutesEdit = ((DropDownList)row.FindControl("ddlEndTimeMinuteEdit")).SelectedValue.Trim();

                        if ((endHoursEdit != "") && (endMinutesEdit != ""))
                        {
                            endTime = endHoursEdit + ":" + endMinutesEdit ;
                        }

                        int projectId = int.Parse(ddlProject.SelectedValue);

                        if (projectId != 35 && projectId != 39 && projectId != 716)
                        {
                            if (endTime.Trim() == "")
                            {
                                args.IsValid = false;
                            }
                        }
                    }
                }
            }
        }



        protected void cvProvideTypeOfWorkFunctionEdit_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            if (grdProjectTime.Rows.Count > 0)
            {
                foreach (GridViewRow row in grdProjectTime.Rows)
                {
                    if ((row.RowType == DataControlRowType.DataRow) && ((row.RowState == DataControlRowState.Edit) || (row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
                    {
                        string typeOfWorkFunction = ((DropDownList)row.FindControl("ddlTypeOfWorkFunctionEdit")).SelectedValue;

                        int projectId = int.Parse(ddlProject.SelectedValue);

                        if (projectId != 35 && projectId != 39 && projectId != 716)
                        {
                            if (typeOfWorkFunction.Trim() == "(Select)")
                            {
                                args.IsValid = false;
                            }
                        }
                    }
                }
            }
        }



        protected void cvJobClassTypeFooter_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            int projectId = int.Parse(ddlProject.SelectedValue);

            ProjectGateway projectGateway = new ProjectGateway(new DataSet());
            projectGateway.LoadByProjectId(int.Parse(ddlProject.SelectedValue));

            if (projectGateway.GetFairWageApplies(projectId))
            {
                string jobClass = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlJobClassTypeFooter")).SelectedValue;

                if (jobClass == "(Select a Job Class Type)")
                {
                    args.IsValid = false;
                }
            }
        }



        protected void cvJobClassTypeEdit_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            int projectId = int.Parse(ddlProject.SelectedValue);

            ProjectGateway projectGateway = new ProjectGateway(new DataSet());
            projectGateway.LoadByProjectId(int.Parse(ddlProject.SelectedValue));

            if (projectGateway.GetFairWageApplies(projectId))
            {
                string jobClass = ((DropDownList)grdProjectTime.Rows[grdProjectTime.EditIndex].FindControl("ddlJobClassTypeEdit")).SelectedValue;

                if (jobClass == "(Select a Job Class Type)")
                {
                    args.IsValid = false;
                }
            }
        }



        protected void cvJobClassEmptyEdit_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            int employeeId = Int32.Parse(hdfEmployeeID.Value);
            EmployeeGateway employee = new EmployeeGateway();
            employee.LoadByEmployeeId(employeeId);
            string jobClass = employee.GetJobClassType(employeeId);

            if (jobClass == "")
            {
                args.IsValid = false;
            }
        }



        protected void cvJobClassEmptyFooter_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            int employeeId = Int32.Parse(hdfEmployeeID.Value);
            EmployeeGateway employee = new EmployeeGateway();
            employee.LoadByEmployeeId(employeeId);
            string jobClass = employee.GetJobClassType(employeeId);

            if (jobClass == "")
            {
                args.IsValid = false;
            }
        }

                

        protected void cvDuplicateMealsAllowanceFooter_ServerValidate(object source, ServerValidateEventArgs args)
        {
            int employeeId = Int32.Parse(hdfEmployeeID.Value);
            bool isMealsAllowance = false;// ((CheckBox)grdProjectTime.FooterRow.FindControl("ckbxMealsAllowanceFooter")).Checked;

            ProjectTimeTemp projectTimeTemp = new ProjectTimeTemp(projectTimeTDS);
            bool validMealsAllowance1 = projectTimeTemp.ValidateMealsAllowance(employeeId, isMealsAllowance);

            args.IsValid = true;

            int projectId = int.Parse(ddlProject.SelectedValue);

            if (projectId == 35 || projectId == 39 || projectId == 716)
            {
                if (isMealsAllowance)
                {
                    args.IsValid = false;
                    CustomValidator cvAlreadyRegisterdMealsAllowanceEdit = (CustomValidator)source;
                    cvAlreadyRegisterdMealsAllowanceEdit.ErrorMessage = "Please don't select meals allowance.";
                }
            }
            else
            {
                if (!validMealsAllowance1)
                {
                    args.IsValid = false;
                }
            }
        }



        protected void cvDuplicateMealsAllowanceEdit_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            if (grdProjectTime.Rows.Count > 0)
            {
                foreach (GridViewRow row in grdProjectTime.Rows)
                {
                    if ((row.RowType == DataControlRowType.DataRow) && ((row.RowState == DataControlRowState.Edit) || (row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
                    {
                        int employeeId = Int32.Parse(hdfEmployeeID.Value);
                        bool isMealsAllowance = false;// ((CheckBox)row.FindControl("ckbxMealsAllowanceEdit")).Checked;
                        int projectTimeId = Int32.Parse(((Label)row.FindControl("lblProjectTimeIdEdit")).Text);
                        int projectId = int.Parse(ddlProject.SelectedValue);

                        if (projectId == 35 || projectId == 39 || projectId == 716)
                        {
                            if (isMealsAllowance)
                            {
                                args.IsValid = false;
                                CustomValidator cvAlreadyRegisterdMealsAllowanceEdit = (CustomValidator)source;
                                cvAlreadyRegisterdMealsAllowanceEdit.ErrorMessage = "Please don't select meals allowance.";
                            }
                        }
                        else
                        {
                            ProjectTimeTemp projectTimeTemp = new ProjectTimeTemp(projectTimeTDS);
                            bool validMealsAllowance1 = projectTimeTemp.ValidateMealsAllowanceEdit(employeeId, isMealsAllowance, projectTimeId);

                            args.IsValid = true;
                            if (!validMealsAllowance1)
                            {
                                args.IsValid = false;
                            }
                        }
                    }
                }
            }
        }



        protected void cvAlreadyRegisteredMealsAllowanceFooter_ServerValidate(object source, ServerValidateEventArgs args)
        {
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int employeeId = Int32.Parse(hdfEmployeeID.Value);
            DateTime startDate = tkrdpStartDate.SelectedDate.Value;
            DateTime lastDate = tkrdpEndDate.SelectedDate.Value;
            bool isMealsAllowance = false;// ((CheckBox)grdProjectTime.FooterRow.FindControl("ckbxMealsAllowanceFooter")).Checked;
            string mealsCountry = ddlMealsCountry.SelectedValue;
            int projectTimeId = -1;
            args.IsValid = true;

            int projectId = int.Parse(ddlProject.SelectedValue);

            if (projectId == 35 || projectId == 39 || projectId == 716)
            {
                if (isMealsAllowance)
                {
                    args.IsValid = false;
                }
            }
            else
            {
                ProjectTimeTemp projectTimeTemp = new ProjectTimeTemp(projectTimeTDS);
                bool validMealsAllowance1 = projectTimeTemp.ValidateMealsAllowance(employeeId, isMealsAllowance);
                if (validMealsAllowance1)
                {
                    if ((mealsCountry != "-1") && (isMealsAllowance))
                    {
                        ProjectTimeGateway projectTimeGateway = new ProjectTimeGateway();
                        if (projectTimeId == -1)
                        {
                            if (projectTimeGateway.ExistsMealsAllowanceByEmployeIdDate(employeeId, startDate, companyId))
                            {
                                args.IsValid = false;
                            }
                        }
                        else
                        {
                            if (projectTimeGateway.ExistsMealsAllowanceByProjectTimeIdEmployeIdDate(projectTimeId, employeeId, startDate, companyId))
                            {
                                args.IsValid = false;
                            }
                        }
                    }
                }
            }
        }



        protected void cvAlreadyRegisteredMealsAllowanceEdit_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            if (grdProjectTime.Rows.Count > 0)
            {
                foreach (GridViewRow row in grdProjectTime.Rows)
                {
                    if ((row.RowType == DataControlRowType.DataRow) && ((row.RowState == DataControlRowState.Edit) || (row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
                    {
                        int companyId = Int32.Parse(hdfCompanyId.Value);
                        int employeeId = Int32.Parse(hdfEmployeeID.Value);
                        DateTime startDate = tkrdpStartDate.SelectedDate.Value;
                        DateTime lastDate = tkrdpEndDate.SelectedDate.Value;
                        bool isMealsAllowance = false;// ((CheckBox)row.FindControl("ckbxMealsAllowanceEdit")).Checked;
                        int projectTimeId2 = Int32.Parse(((Label)row.FindControl("lblProjectTimeIdEdit")).Text);
                        int projectId = int.Parse(ddlProject.SelectedValue);

                        if (projectId == 35 || projectId == 39 || projectId == 716)
                        {
                            if (isMealsAllowance)
                            { 
                                args.IsValid = false;
                            }
                        }
                        else
                        {
                            string mealsCountry = ddlMealsCountry.SelectedValue;
                            int projectTimeId = -1;
                            args.IsValid = true;

                            ProjectTimeTemp projectTimeTemp = new ProjectTimeTemp(projectTimeTDS);
                            bool validMealsAllowance1 = projectTimeTemp.ValidateMealsAllowanceEdit(employeeId, isMealsAllowance, projectTimeId2);
                            if (validMealsAllowance1)
                            {
                                if ((mealsCountry != "-1") && (isMealsAllowance))
                                {
                                    ProjectTimeGateway projectTimeGateway = new ProjectTimeGateway();
                                    if (projectTimeId == -1)
                                    {
                                        if (projectTimeGateway.ExistsMealsAllowanceByEmployeIdDate(employeeId, startDate, companyId))
                                        {
                                            args.IsValid = false;
                                        }
                                    }
                                    else
                                    {
                                        if (projectTimeGateway.ExistsMealsAllowanceByProjectTimeIdEmployeIdDate(projectTimeId, employeeId, startDate, companyId))
                                        {
                                            args.IsValid = false;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }



        protected void cvValidProjectTimeFooter_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            // Start time
            string startTime = "";
            string startHoursFooter = ""; if (((DropDownList)grdProjectTime.FooterRow.FindControl("ddlStartTimeHourFooter")).SelectedValue.Trim() != "") startHoursFooter = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlStartTimeHourFooter")).SelectedValue.Trim();
            string startMinutesFooter = ""; if (((DropDownList)grdProjectTime.FooterRow.FindControl("ddlStartTimeMinuteFooter")).SelectedValue.Trim() != "") startMinutesFooter = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlStartTimeMinuteFooter")).SelectedValue.Trim();

            if ((startHoursFooter != "") && (startMinutesFooter != ""))
            {
                startTime = startHoursFooter + ":" + startMinutesFooter;
            }
            
            // End Time
            string endTime = "";
            string endHoursFooter = ""; if (((DropDownList)grdProjectTime.FooterRow.FindControl("ddlEndTimeHourFooter")).SelectedValue.Trim() != "") endHoursFooter = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlEndTimeHourFooter")).SelectedValue.Trim();
            string endMinutesFooter = ""; if (((DropDownList)grdProjectTime.FooterRow.FindControl("ddlEndTimeMinuteFooter")).SelectedValue.Trim() != "") endMinutesFooter = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlEndTimeMinuteFooter")).SelectedValue.Trim();

            if ((endHoursFooter != "") && (endMinutesFooter != ""))
            {
                endTime = endHoursFooter + ":" + endMinutesFooter;
            }
            
            // Offset
            string offset = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlLunchFooter")).SelectedValue;

            DateTime? startTimeToCalculate = null; if (startTime != "") startTimeToCalculate = DateTime.Parse(startTime);
            DateTime? endTimeToCalculate = null; if (endTime != "") endTimeToCalculate = DateTime.Parse(endTime);
            double? offsetToCalculate = 0; if (offset != "0") offsetToCalculate = double.Parse(offset);

            if (startTimeToCalculate.HasValue || endTimeToCalculate.HasValue)
            {
                args.IsValid =  (CalculateProjectTime(startTimeToCalculate, endTimeToCalculate, offsetToCalculate) > 0) ? true : false;
            }
        }



        private bool IsMoreThan15Footer()
        {
            bool isMoreThan15 = false;

            // Start time
            string startTime = "";
            string startHoursFooter = ""; if (((DropDownList)grdProjectTime.FooterRow.FindControl("ddlStartTimeHourFooter")).SelectedValue.Trim() != "") startHoursFooter = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlStartTimeHourFooter")).SelectedValue.Trim();
            string startMinutesFooter = ""; if (((DropDownList)grdProjectTime.FooterRow.FindControl("ddlStartTimeMinuteFooter")).SelectedValue.Trim() != "") startMinutesFooter = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlStartTimeMinuteFooter")).SelectedValue.Trim();

            if ((startHoursFooter != "") && (startMinutesFooter != ""))
            {
                startTime = startHoursFooter + ":" + startMinutesFooter;
            }

            // End Time
            string endTime = "";
            string endHoursFooter = ""; if (((DropDownList)grdProjectTime.FooterRow.FindControl("ddlEndTimeHourFooter")).SelectedValue.Trim() != "") endHoursFooter = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlEndTimeHourFooter")).SelectedValue.Trim();
            string endMinutesFooter = ""; if (((DropDownList)grdProjectTime.FooterRow.FindControl("ddlEndTimeMinuteFooter")).SelectedValue.Trim() != "") endMinutesFooter = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlEndTimeMinuteFooter")).SelectedValue.Trim();

            if ((endHoursFooter != "") && (endMinutesFooter != ""))
            {
                endTime = endHoursFooter + ":" + endMinutesFooter;
            }

            // Offset
            string offset = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlLunchFooter")).SelectedValue;

            DateTime? startTimeToCalculate = null; if (startTime != "") startTimeToCalculate = DateTime.Parse(startTime);
            DateTime? endTimeToCalculate = null; if (endTime != "") endTimeToCalculate = DateTime.Parse(endTime);
            double? offsetToCalculate = 0; if (offset != "0") offsetToCalculate = double.Parse(offset);

            if (startTimeToCalculate.HasValue || endTimeToCalculate.HasValue)
            {
                isMoreThan15 = (CalculateProjectTime(startTimeToCalculate, endTimeToCalculate, offsetToCalculate) > 15) ? true : false;
            }

            return isMoreThan15;
        }



        private bool IsMoreThan15Edit()
        {
            bool isMoreThan15 = false;

            // Start time
            string startTime = "";
            string startHoursEdit = ""; if (((DropDownList)grdProjectTime.Rows[grdProjectTime.EditIndex].Cells[1].FindControl("ddlStartTimeHourEdit")).SelectedValue.Trim() != "") startHoursEdit = ((DropDownList)grdProjectTime.Rows[grdProjectTime.EditIndex].Cells[1].FindControl("ddlStartTimeHourEdit")).SelectedValue.Trim();
            string startMinutesEdit = ""; if (((DropDownList)grdProjectTime.Rows[grdProjectTime.EditIndex].Cells[1].FindControl("ddlStartTimeMinuteEdit")).SelectedValue.Trim() != "") startMinutesEdit = ((DropDownList)grdProjectTime.Rows[grdProjectTime.EditIndex].Cells[1].FindControl("ddlStartTimeMinuteEdit")).SelectedValue.Trim();

            if ((startHoursEdit != "") && (startMinutesEdit != ""))
            {
                startTime = startHoursEdit + ":" + startMinutesEdit;
            }

            // End Time
            string endTime = "";
            string endHoursEdit = ""; if (((DropDownList)grdProjectTime.Rows[grdProjectTime.EditIndex].Cells[1].FindControl("ddlEndTimeHourEdit")).SelectedValue.Trim() != "") endHoursEdit = ((DropDownList)grdProjectTime.Rows[grdProjectTime.EditIndex].Cells[1].FindControl("ddlEndTimeHourEdit")).SelectedValue.Trim();
            string endMinutesEdit = ""; if (((DropDownList)grdProjectTime.Rows[grdProjectTime.EditIndex].Cells[1].FindControl("ddlEndTimeMinuteEdit")).SelectedValue.Trim() != "") endMinutesEdit = ((DropDownList)grdProjectTime.Rows[grdProjectTime.EditIndex].Cells[1].FindControl("ddlEndTimeMinuteEdit")).SelectedValue.Trim();

            if ((endHoursEdit != "") && (endMinutesEdit != ""))
            {
                endTime = endHoursEdit + ":" + endMinutesEdit;
            }

            // Offset
            string offset = ((DropDownList)grdProjectTime.Rows[grdProjectTime.EditIndex].FindControl("ddlLunchEdit")).SelectedValue;

            DateTime? startTimeToCalculate = null; if (startTime != "") startTimeToCalculate = DateTime.Parse(startTime);
            DateTime? endTimeToCalculate = null; if (endTime != "") endTimeToCalculate = DateTime.Parse(endTime);
            double? offsetToCalculate = 0; if (offset != "0") offsetToCalculate = double.Parse(offset);

            if (startTimeToCalculate.HasValue || endTimeToCalculate.HasValue)
            {
                isMoreThan15 = (CalculateProjectTime(startTimeToCalculate, endTimeToCalculate, offsetToCalculate) > 15) ? true : false;
            }

            return isMoreThan15;
        }

        

        protected void cvValidProjectTimeEdit_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            if (grdProjectTime.Rows.Count > 0)
            {
                foreach (GridViewRow row in grdProjectTime.Rows)
                {
                    if ((row.RowType == DataControlRowType.DataRow) && ((row.RowState == DataControlRowState.Edit) || (row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
                    {
                        string startTime = "";
                        string startHoursEdit = ""; if (((DropDownList)row.FindControl("ddlStartTimeHourEdit")).SelectedValue.Trim() != "") startHoursEdit = ((DropDownList)row.FindControl("ddlStartTimeHourEdit")).SelectedValue.Trim();
                        string startMinutesEdit = ""; if (((DropDownList)row.FindControl("ddlStartTimeMinuteEdit")).SelectedValue.Trim() != "") startMinutesEdit = ((DropDownList)row.FindControl("ddlStartTimeMinuteEdit")).SelectedValue.Trim();

                        if ((startHoursEdit != "") && (startMinutesEdit != ""))
                        {
                            startTime = startHoursEdit + ":" + startMinutesEdit;
                        }

                        string endTime = "";
                        string endHoursEdit = ""; if (((DropDownList)row.FindControl("ddlEndTimeHourEdit")).SelectedValue.Trim() != "") endHoursEdit = ((DropDownList)row.FindControl("ddlEndTimeHourEdit")).SelectedValue.Trim();
                        string endMinutesEdit = ""; if (((DropDownList)row.FindControl("ddlEndTimeMinuteEdit")).SelectedValue.Trim() != "") endMinutesEdit = ((DropDownList)row.FindControl("ddlEndTimeMinuteEdit")).SelectedValue.Trim();

                        if ((endHoursEdit != "") && (endMinutesEdit != ""))
                        {
                            endTime = endHoursEdit + ":" + endMinutesEdit;
                        }

                        string offset = ((DropDownList)row.FindControl("ddlLunchEdit")).SelectedValue;

                        DateTime? startTimeToCalculate = null; if (startTime != "") startTimeToCalculate = DateTime.Parse(startTime);
                        DateTime? endTimeToCalculate = null; if (endTime != "") endTimeToCalculate = DateTime.Parse(endTime);
                        double? offsetToCalculate = 0; if (offset != "0") offsetToCalculate = double.Parse(offset);

                        if (startTimeToCalculate.HasValue || endTimeToCalculate.HasValue)
                        {
                            args.IsValid = (CalculateProjectTime(startTimeToCalculate, endTimeToCalculate, offsetToCalculate) > 0) ? true : false;
                        }
                    }
                }
            }
        }



        protected void cvValidTimesEdit_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = false;
            
            if (grdProjectTime.Rows.Count > 0)
            {
                foreach (GridViewRow row in grdProjectTime.Rows)
                {
                    if ((row.RowType == DataControlRowType.DataRow) && ((row.RowState == DataControlRowState.Edit) || (row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
                    {
                        ProjectTimeGateway projectTimeGatewayForVerify = new ProjectTimeGateway();
                        int employeeId = Int32.Parse(hdfEmployeeID.Value);
                        int companyId = Int32.Parse(hdfCompanyId.Value);
                        DateTime date_ = tkrdpStartDate.SelectedDate.Value;
                        string startTime = "";
                        string startHoursEdit = ""; if (((DropDownList)row.FindControl("ddlStartTimeHourEdit")).SelectedValue.Trim() != "") startHoursEdit = ((DropDownList)row.FindControl("ddlStartTimeHourEdit")).SelectedValue.Trim();
                        string startMinutesEdit = ""; if (((DropDownList)row.FindControl("ddlStartTimeMinuteEdit")).SelectedValue.Trim() != "") startMinutesEdit = ((DropDownList)row.FindControl("ddlStartTimeMinuteEdit")).SelectedValue.Trim();

                        if ((startHoursEdit != "") && (startMinutesEdit != ""))
                        {
                            startTime = startHoursEdit + ":" + startMinutesEdit;
                        }

                        string endTime = "";
                        string endHoursEdit = ""; if (((DropDownList)row.FindControl("ddlEndTimeHourEdit")).SelectedValue.Trim() != "") endHoursEdit = ((DropDownList)row.FindControl("ddlEndTimeHourEdit")).SelectedValue.Trim();
                        string endMinutesEdit = ""; if (((DropDownList)row.FindControl("ddlEndTimeMinuteEdit")).SelectedValue.Trim() != "") endMinutesEdit = ((DropDownList)row.FindControl("ddlEndTimeMinuteEdit")).SelectedValue.Trim();

                        if ((endHoursEdit != "") && (endMinutesEdit != ""))
                        {
                            endTime = endHoursEdit + ":" + endMinutesEdit;
                        }

                        // Verify if the time already exists at DB
                        if (projectTimeGatewayForVerify.NotExistsByEmployeIdDate_StartTimeEndTime(employeeId, date_, startTime, endTime, companyId))
                        {
                            args.IsValid = true;
                        }

                        int cant = 0;
                        if (args.IsValid)
                        {
                            // Verify if it exist at last entered rows
                            if (grdProjectTime.Rows.Count > 0)
                            {
                                foreach (GridViewRow rowTemp in grdProjectTime.Rows)
                                {
                                    if ((rowTemp.RowType == DataControlRowType.DataRow) && ((rowTemp.RowState == DataControlRowState.Normal) || (rowTemp.RowState == (DataControlRowState.Normal | DataControlRowState.Alternate))))
                                    {
                                        TimeSpan spanGridStartTime = TimeSpan.Parse(((TextBox)rowTemp.FindControl("tbxStartTime")).Text.Trim());
                                        TimeSpan spanGridEndTime = TimeSpan.Parse(((TextBox)rowTemp.FindControl("tbxEndTime")).Text.Trim());
                                        TimeSpan spanStartTime = TimeSpan.Parse(startTime);
                                        TimeSpan spanEndTime = TimeSpan.Parse(endTime);
                                        string twentyForHours = "23:59";
                                        TimeSpan midNight = TimeSpan.Parse(twentyForHours);

                                        if ((Int32.Parse(hdfEmployeeID.Value) == employeeId) && (tkrdpStartDate.SelectedDate.Value == date_))
                                        {
                                            // When End Time < StartTime   (when they finish work the next day)
                                            if ((spanGridEndTime < spanGridStartTime) && (spanEndTime > spanStartTime))
                                            {
                                                if (((spanStartTime >= spanGridStartTime) && (spanStartTime <= midNight)) || ((spanEndTime >= spanGridStartTime) && (spanEndTime <= midNight)))
                                                {
                                                    cant++;
                                                }
                                            }
                                            else
                                            {
                                                if ((spanEndTime < spanStartTime) && (spanGridEndTime > spanGridStartTime))
                                                {
                                                    if (((spanGridStartTime >= spanStartTime) && (midNight <= spanStartTime)) || ((spanGridStartTime >= spanEndTime) && (midNight <= spanEndTime)))
                                                    {
                                                        cant++;
                                                    }
                                                }
                                                else
                                                {
                                                    if (((spanGridEndTime < spanGridStartTime) && (spanEndTime < spanStartTime)))
                                                    {
                                                        cant++;
                                                    }
                                                    else
                                                    {
                                                        // When End Time > Start Time.  (times in the same day)
                                                        // ... If it's a valid entry
                                                        if (((spanStartTime < spanGridStartTime) && (spanEndTime <= spanGridStartTime)) || (spanStartTime >= spanGridEndTime) && (spanEndTime > spanGridEndTime))
                                                        {

                                                        }
                                                        else
                                                        {
                                                            // If the range exists
                                                            cant++;
                                                        }

                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                            if (cant == 0)
                            {
                                args.IsValid = true;
                            }
                            else
                            {
                                args.IsValid = false;
                            }
                        }
                    }
                }
            }
        }



        protected void cvValidTimesFooter_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = false;

            ProjectTimeGateway projectTimeGatewayForVerify = new ProjectTimeGateway();
            int employeeId = Int32.Parse(hdfEmployeeID.Value);
            int companyId = Int32.Parse(hdfCompanyId.Value);              
            DateTime date_ = tkrdpStartDate.SelectedDate.Value;
            string startTimeFooter = "";
            string startHoursFooter = ""; if (((DropDownList)grdProjectTime.FooterRow.FindControl("ddlStartTimeHourFooter")).SelectedValue != "") startHoursFooter = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlStartTimeHourFooter")).SelectedValue.Trim();
            string startMinutesFooter = ""; if (((DropDownList)grdProjectTime.FooterRow.FindControl("ddlStartTimeMinuteFooter")).SelectedValue != "") startMinutesFooter = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlStartTimeMinuteFooter")).SelectedValue.Trim();

            string endTimeFooter = "";
            string endHoursFooter = ""; if (((DropDownList)grdProjectTime.FooterRow.FindControl("ddlEndTimeHourFooter")).SelectedValue != "") endHoursFooter = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlEndTimeHourFooter")).SelectedValue.Trim();
            string endMinutesFooter = ""; if (((DropDownList)grdProjectTime.FooterRow.FindControl("ddlEndTimeMinuteFooter")).SelectedValue != "") endMinutesFooter = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlEndTimeMinuteFooter")).SelectedValue.Trim();

            if ((startHoursFooter != "") && (startMinutesFooter != "") && (endHoursFooter != "") && (endMinutesFooter != ""))
            {
                startTimeFooter = startHoursFooter + ":" + startMinutesFooter;
                endTimeFooter = endHoursFooter + ":" + endMinutesFooter;

                // Verify if the time already exists at DB
                if (projectTimeGatewayForVerify.NotExistsByEmployeIdDate_StartTimeEndTime(employeeId, date_, startTimeFooter, endTimeFooter, companyId))
                {
                    args.IsValid = true;
                }

                if (args.IsValid)
                {
                    // Verify if it exist at last entered rows
                    ProjectTimeTemp modelForReview = new ProjectTimeTemp(projectTimeTDS);
                    if (modelForReview.NotExistsByEmployeIdDate_StartTimeEndTime(employeeId, date_, startTimeFooter, endTimeFooter))
                    {
                        args.IsValid = true;
                    }
                    else
                    {
                        args.IsValid = false;
                    }
                }
            }
        }



        protected void cvValidDateFooter_ServerValidate(object source, ServerValidateEventArgs args)
        {
            CustomValidator cvValidDateFooter = (CustomValidator)source;
            args.IsValid = true;

            args.IsValid = (tkrdpStartDate.SelectedDate != null) ? LiquiForce.LFSLive.BL.LabourHours.ProjectTime.ProjectTime.ValidateExistPayPeriod(tkrdpStartDate.SelectedDate.Value) : false;
            cvValidDateFooter.ErrorMessage = cvDatePayPeriodStartDate.ErrorMessage;

            int projectId = int.Parse(ddlProject.SelectedValue);
            if (projectId == 35 || projectId == 39 || projectId == 716)
            {
                args.IsValid = (tkrdpEndDate.SelectedDate != null) ? LiquiForce.LFSLive.BL.LabourHours.ProjectTime.ProjectTime.ValidateExistPayPeriod(tkrdpEndDate.SelectedDate.Value) : false;
                cvValidDateFooter.ErrorMessage = cvDayPayPeriodLastDate.ErrorMessage;
            }

            if (args.IsValid)
            {
                if (!Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_FULL_EDITING"]))
                {
                    if (Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_MY_TIMESHEETS_MANAGEMENT"]) || Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_OTHERS_TIMESHEETS_MANAGEMENT"]))
                    {
                        args.IsValid = (tkrdpStartDate.SelectedDate != null) ? LiquiForce.LFSLive.BL.LabourHours.ProjectTime.ProjectTime.ValidateLimitedPayPeriodToManagementEdit(tkrdpStartDate.SelectedDate.Value, projectId) : false;
                        cvValidDateFooter.ErrorMessage = cvDateLimitedPayPeriodStartDate.ErrorMessage;

                        if (projectId == 35 || projectId == 39 || projectId == 716)
                        {
                            args.IsValid = (tkrdpEndDate.SelectedDate != null) ? LiquiForce.LFSLive.BL.LabourHours.ProjectTime.ProjectTime.ValidateLimitedPayPeriodToManagementEdit(tkrdpEndDate.SelectedDate.Value, projectId) : false;
                            cvValidDateFooter.ErrorMessage = cvDateLimitedPayPeriodLastDate.ErrorMessage;
                        }
                    }

                    if (Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_MY_TIMESHEETS_MANAGEMENT_WED"]) || Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_OTHERS_TIMESHEETS_MANAGEMENT_WED"]))
                    {
                        args.IsValid = (tkrdpStartDate.SelectedDate != null) ? LiquiForce.LFSLive.BL.LabourHours.ProjectTime.ProjectTime.ValidateLimitedPayPeriodToWednesdayManagementEdit(tkrdpStartDate.SelectedDate.Value, projectId) : false;
                        cvValidDateFooter.ErrorMessage = cvDateLimitedWednesdayPayPeriodStartDate.ErrorMessage;

                        if (projectId == 35 || projectId == 39 || projectId == 716)
                        {
                            args.IsValid = (tkrdpEndDate.SelectedDate != null) ? LiquiForce.LFSLive.BL.LabourHours.ProjectTime.ProjectTime.ValidateLimitedPayPeriodToWednesdayManagementEdit(tkrdpEndDate.SelectedDate.Value, projectId) : false;
                            cvValidDateFooter.ErrorMessage = cvDateLimitedWednesdayPayPeriodStartDate.ErrorMessage;
                        }
                    }
                }
            }

            if (args.IsValid)
            {
                if (projectId == 35 || projectId == 39 || projectId == 716)
                {
                    if (tkrdpEndDate.SelectedDate.Value < tkrdpStartDate.SelectedDate.Value)
                    {
                        args.IsValid = false;
                        cvValidDateFooter.ErrorMessage = cvMinDateLastDate.ErrorMessage;
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

            int employeeId = Int32.Parse(hdfEmployeeID.Value);
            int periodId = Int32.Parse(hdfPeriodId.Value);

            switch (e.Item.Value)
            {
                case "mSave":
                    if (ValidatePage())
                    {
                        int companiesId = int.Parse(ddlClient.SelectedValue);
                        int projectId = int.Parse(ddlProject.SelectedValue);

                        if (projectId == 35 || projectId == 39 || projectId == 716)
                        {
                            Page.Validate("specialData");

                            if (Page.IsValid)
                            {
                                DateTime startDate = tkrdpStartDate.SelectedDate.Value;
                                DateTime lastDate = tkrdpEndDate.SelectedDate.Value;
                                DateTime date_ = startDate;

                                while (date_ <= lastDate)
                                {
                                    Int64? mealsCountry = null;
                                    string startTimeFooter = "";
                                    string endTimeFooter = "";
                                    double? offsetFooterFinal = 0;
                                    string typeOfWorkFooter = "";
                                    int? unitIdFooter = null;
                                    int? towedIdFooter = null;
                                    string workingDetailsFooter = ddlWorkingDetails.SelectedValue;
                                    bool isMealsAllowanceFooter = false;
                                    string commentsFooter = tbxCommentsVacation.Text;
                                    int companyId = Int32.Parse(hdfCompanyId.Value);
                                    bool fairWage = false;
                                    string projectTimeState = "For Approval"; if ((string)ViewState["LHMode"] == "Partial") projectTimeState = "Approved";
                                    string work_ = "";
                                    string function_ = "";

                                    ProjectGateway projectGateway = new ProjectGateway(new DataSet());
                                    projectGateway.LoadByProjectId(projectId);
                                    CountryGateway countryGateway = new CountryGateway(new DataSet());
                                    countryGateway.LoadByCountryId(projectGateway.GetCountryID(projectId));

                                    string location = "";
                                    if (countryGateway.Table.Rows.Count > 0)
                                    {
                                        location = countryGateway.GetName(projectGateway.GetCountryID(projectId));
                                    }

                                    string mealsAllowanceType = "";
                                    decimal mealsAllowance = MealsAllowance.GetMealsAllowance(mealsCountry, isMealsAllowanceFooter, "Full Day");

                                    string jobClassType = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlJobClassTypeFooter")).SelectedValue;

                                    // Insert Data                                       
                                    ProjectTimeTemp model = new ProjectTimeTemp(projectTimeTDS);
                                    model.Insert(employeeId, companiesId, projectId, date_, startTimeFooter, endTimeFooter, offsetFooterFinal, workingDetailsFooter, location, mealsCountry, mealsAllowanceType, isMealsAllowanceFooter, mealsAllowance, unitIdFooter, towedIdFooter, projectTimeState, commentsFooter, work_, function_, typeOfWorkFooter, fairWage, jobClassType);

                                    date_ = date_.AddDays(1);

                                    // ... ... Store Dataset
                                    Session.Remove("projectTimeTempNewDummy");
                                    Session["projectTimeTDS"] = projectTimeTDS;
                                    Session["projectTimeTemp"] = projectTimeTDS.LFS_PROJECT_TIME_TEMP;                                   
                                }

                                PostPageChanges();
                                UpdateDatabase();

                                Response.Redirect("./../timesheet/timesheet.aspx?source_page=timesheet_add.aspx&others=" + ViewState["others"] + "&employee_id=" + employeeId.ToString() + "&period_id=" + periodId.ToString() + "&projecttime_id=" + DB.GetIdentCurrent("LFS_PROJECT_TIME").ToString());
                            }
                        }
                        else
                        {
                            // Project time Gridview, if the gridview is edition mode
                            if (grdProjectTime.EditIndex >= 0)
                            {
                                grdProjectTime.UpdateRow(grdProjectTime.EditIndex, true);
                            }

                            // Insert Data
                            GrdProjectTimeAdd();

                            PostPageChanges();
                            UpdateDatabase();

                            Response.Redirect("./../timesheet/timesheet.aspx?source_page=timesheet_add.aspx&others=" + ViewState["others"] + "&employee_id=" + employeeId.ToString() + "&period_id=" + periodId.ToString() + "&projecttime_id=" + DB.GetIdentCurrent("LFS_PROJECT_TIME").ToString());
                        }                       
                    }
                    break;

                case "mCancel":
                    if (Request.QueryString["source_page"] == "timesheet.aspx")
                    {
                        Response.Redirect("./../timesheet/timesheet.aspx?source_page=timesheet_add.aspx&others=" + ViewState["others"] + "&employee_id=" + employeeId.ToString() + "&period_id=" + periodId.ToString());
                    }
                    else
                    {
                        if (Request.QueryString["source_page"] == "timesheet_summary_from_approve_project_times.aspx")
                        {
                            Response.Redirect("./timesheet_summary.aspx?source_page=timesheet_approve.aspx&others=" + ViewState["others"] + "&employee_id=" + employeeId.ToString() + "&period_id=" + periodId.ToString() + "&projecttime_id=" + ViewState["projecttime_id"]);
                        }
                        else
                        {
                            Response.Redirect("./timesheet_summary.aspx?source_page=timesheet_add.aspx&others=" + ViewState["others"] + "&employee_id=" + employeeId.ToString() + "&period_id=" + periodId.ToString() + "&projecttime_id=" + ViewState["projecttime_id"]);
                        }
                    }
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

        public ProjectTimeTDS.LFS_PROJECT_TIME_TEMPDataTable GetProjectTime()
        {
            projectTimeTemp = (ProjectTimeTDS.LFS_PROJECT_TIME_TEMPDataTable)Session["projectTimeTempNewDummy"];
            if (projectTimeTemp == null)
            {
                projectTimeTemp = ((ProjectTimeTDS.LFS_PROJECT_TIME_TEMPDataTable)Session["projectTimeTemp"]);
            }

            return projectTimeTemp;
        }



        public void DummyProjectTimeNew(int ProjectTimeID, int original_ProjectTimeID)
        {
        }



        public void DummyProjectTimeNew(int original_ProjectTimeID)
        {
        }



        private void PostPageChanges()
        {
            EmployeeGateway employeeGateway = new EmployeeGateway(new DataSet());
            int employeeId = employeeGateway.GetEmployeIdByLoginId(Convert.ToInt32(Session["loginID"]));

            projectTimeTDSToSave = new ProjectTimeTDS();
            LiquiForce.LFSLive.BL.LabourHours.ProjectTime.ProjectTime projectTime = new LiquiForce.LFSLive.BL.LabourHours.ProjectTime.ProjectTime(projectTimeTDS);
            projectTime.Insert(projectTimeTDSToSave, employeeId);
        }



        private void UpdateDatabase()
        {
            try
            {
                ProjectTimeGateway projectTimeGateway = new ProjectTimeGateway(projectTimeTDS);
                projectTimeGateway.Update2();

                //TimesheetTDS timesheetTDS = new TimesheetTDS();
                //TimesheetGateway timesheetGateway = new TimesheetGateway(timesheetTDS);
                //timesheetGateway.LoadByEmployeeIdPayPeriodId((int)ViewState["employee_id"], (int)ViewState["period_id"]);
                //if (timesheetGateway.Table.Rows.Count == 0)
                //{
                //    LiquiForce.LFSLive.BL.LabourHours.Timesheet.Timesheet timesheet = new LiquiForce.LFSLive.BL.LabourHours.Timesheet.Timesheet(timesheetTDS);
                //    timesheet.SetForApproval((int)ViewState["employee_id"], (int)ViewState["period_id"]);

                //    timesheetGateway.Update();
                //    timesheetTDS.AcceptChanges();
                //}

                projectTimeTDS.AcceptChanges();

                Session["projectTimeTDS"] = projectTimeTDS;

                //if (ViewState["timesheetState"].ToString() != "For Approval")
                //{
                //    UpdateTimesheet();
                //}
            }
            catch (Exception ex)
            {
                string url = string.Format("./../../error_page.aspx?error={0}", ex.Message.Replace('\n', ' '));
                Response.Redirect(url);
            }
        }



        private void UpdateTimesheet()
        {
            int employeeId = Int32.Parse(hdfEmployeeID.Value);
            int periodId = Int32.Parse(hdfPeriodId.Value);

            TimesheetTDS timesheetTDS = new TimesheetTDS();
            TimesheetGateway timesheetGateway = new TimesheetGateway(timesheetTDS);
            timesheetGateway.LoadByEmployeeIdPayPeriodId(employeeId, periodId);
            LiquiForce.LFSLive.BL.LabourHours.Timesheet.Timesheet timesheet = new LiquiForce.LFSLive.BL.LabourHours.Timesheet.Timesheet(timesheetTDS); 

            // Approve timesheet 
            if (ViewState["timesheetState"].ToString() == "Approved")
            {                 
                EmployeeGateway employeeGateway1 = new EmployeeGateway(new DataSet());
                ViewState["approved_by_id"] = employeeGateway1.GetEmployeIdByLoginId(Convert.ToInt32(Session["loginID"]));
                timesheet.Approve(employeeId, periodId, (int)ViewState["approved_by_id"]);
            }
            
            // Reject timesheet
            if (ViewState["timesheetState"].ToString() == "Rejected")
            {                
                timesheet.Reject(employeeId, periodId);
            }

            // Submit timesheet
            if (ViewState["timesheetState"].ToString() == "Submitted")
            {                
                timesheet.Submit(employeeId, periodId);
            }

            try
            {
                timesheetGateway.Update2();
                timesheetTDS.AcceptChanges();
            }
            catch (Exception ex)
            {
                string url = string.Format("./../../error_page.aspx?error={0}", ex.Message.Replace('\n', ' '));
                Response.Redirect(url);
            }
        }



        private void RegisterClientScripts()
        {
            // Register content variables
            string contentVariables = "";
            
            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");
                                   
            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./timesheet_add.js");
        }



        protected void AddProjectTimeNewEmptyFix(GridView grdProjectTime)
        {
            if (grdProjectTime.Rows.Count == 0)
            {
                ProjectTimeTDS.LFS_PROJECT_TIME_TEMPDataTable dt = new ProjectTimeTDS.LFS_PROJECT_TIME_TEMPDataTable();
                dt.AddLFS_PROJECT_TIME_TEMPRow(-1, -1, -1, -1, DateTime.Now, "", "", -1, -1, "", "", -1, "", -1, -1,-1, "", "", false, "", "", "", false, false, "");
                Session["projectTimeTempNewDummy"] = dt;

                grdProjectTime.DataBind();
            }

            // normally executes at all postbacks
            if (grdProjectTime.Rows.Count == 1)
            {
                ProjectTimeTDS.LFS_PROJECT_TIME_TEMPDataTable dt = (ProjectTimeTDS.LFS_PROJECT_TIME_TEMPDataTable)Session["projectTimeTempNewDummy"];
                if (dt != null)
                {
                    grdProjectTime.Rows[0].Visible = false;
                    grdProjectTime.Rows[0].Controls.Clear();
                }
            }
        }



        protected string GetLunch(object lunch)
        {
            if (lunch != DBNull.Value)
            {
                if ((Validator.IsValidDouble(lunch.ToString())) && (lunch.ToString() != "0.00"))
                {
                    return lunch.ToString();
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



        private void GrdProjectTimeAdd()
        {
            Page.Validate("generalData");

            int projectId = int.Parse(ddlProject.SelectedValue);
            
            if (Page.IsValid)
            {
                Page.Validate("footerValidData");
                if (Page.IsValid)
                {
                    Page.Validate("footerData");
                    if (Page.IsValid)
                    {
                        // Validate project times
                        if (FooterValidate())
                        {
                            // Save data
                            int employeeId = Int32.Parse(hdfEmployeeID.Value);
                            int companiesId = int.Parse(ddlClient.SelectedValue);

                            if (projectId != 35 && projectId != 39 && projectId != 716)
                            {
                                DateTime date_ = tkrdpStartDate.SelectedDate.Value;
                                Int64? mealsCountry = null; if (ddlMealsCountry.SelectedValue != "-1") mealsCountry = Int64.Parse(ddlMealsCountry.SelectedValue);

                                string startTimeFooter = "";
                                string startHoursFooter = ""; if (((DropDownList)grdProjectTime.FooterRow.FindControl("ddlStartTimeHourFooter")).SelectedValue != "") startHoursFooter = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlStartTimeHourFooter")).SelectedValue.Trim();
                                string startMinutesFooter = ""; if (((DropDownList)grdProjectTime.FooterRow.FindControl("ddlStartTimeMinuteFooter")).SelectedValue != "") startMinutesFooter = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlStartTimeMinuteFooter")).SelectedValue.Trim();

                                if ((startHoursFooter != "") && (startMinutesFooter != ""))
                                {
                                    startTimeFooter = startHoursFooter + ":" + startMinutesFooter;
                                }

                                string endTimeFooter = "";
                                string endHoursFooter = ""; if (((DropDownList)grdProjectTime.FooterRow.FindControl("ddlEndTimeHourFooter")).SelectedValue != "") endHoursFooter = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlEndTimeHourFooter")).SelectedValue.Trim();
                                string endMinutesFooter = ""; if (((DropDownList)grdProjectTime.FooterRow.FindControl("ddlEndTimeMinuteFooter")).SelectedValue != "") endMinutesFooter = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlEndTimeMinuteFooter")).SelectedValue.Trim();

                                if ((endHoursFooter != "") && (endMinutesFooter != ""))
                                {
                                    endTimeFooter = endHoursFooter + ":" + endMinutesFooter;
                                }

                                decimal? offsetFooter = 0; if (((DropDownList)grdProjectTime.FooterRow.FindControl("ddlLunchFooter")).SelectedValue != "0") offsetFooter = Decimal.Round(decimal.Parse(((DropDownList)grdProjectTime.FooterRow.FindControl("ddlLunchFooter")).SelectedValue), 2);
                                double? offsetFooterFinal = null; if (offsetFooter.HasValue) offsetFooterFinal = double.Parse(((decimal)offsetFooter).ToString());
                                string typeOfWorkFooter = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlTypeOfWorkFooter")).SelectedValue;
                                int? unitIdFooter = null; if (((DropDownList)grdProjectTime.FooterRow.FindControl("ddlUnitFooter")).SelectedValue != "-1") unitIdFooter = Int32.Parse(((DropDownList)grdProjectTime.FooterRow.FindControl("ddlUnitFooter")).SelectedValue);
                                int? towedIdFooter = null; if (((DropDownList)grdProjectTime.FooterRow.FindControl("ddlTowedFooter")).SelectedValue != "-1") towedIdFooter = Int32.Parse(((DropDownList)grdProjectTime.FooterRow.FindControl("ddlTowedFooter")).SelectedValue);
                                string workingDetailsFooter = "Canada";
                                workingDetailsFooter = hdfWorkingDetails.Value;
                                bool isMealsAllowanceFooter = false;// ((CheckBox)grdProjectTime.FooterRow.FindControl("ckbxMealsAllowanceFooter")).Checked;
                                string commentsFooter = ((TextBox)grdProjectTime.FooterRow.FindControl("tbxCommentsFooter")).Text;
                                int companyId = Int32.Parse(hdfCompanyId.Value);

                                ProjectGateway projectGateway = new ProjectGateway(new DataSet());
                                projectGateway.LoadByProjectId(projectId);
                                bool fairWage = projectGateway.GetFairWageApplies(projectId);
                                string projectTimeState = "For Approval"; if ((string)ViewState["LHMode"] == "Partial") projectTimeState = "Approved";

                                string work_ = "";
                                string function_ = "";
                                if (typeOfWorkFooter != "(Select)" && typeOfWorkFooter != "")
                                {
                                    string[] workFunction = typeOfWorkFooter.ToString().Trim().Split('.');
                                    work_ = workFunction[0].Trim();
                                    function_ = workFunction[1].Trim();
                                }

                                CountryGateway countryGateway = new CountryGateway(new DataSet());
                                countryGateway.LoadByCountryId(projectGateway.GetCountryID(projectId));

                                string location = "";
                                if (countryGateway.Table.Rows.Count > 0)
                                {
                                    location = countryGateway.GetName(projectGateway.GetCountryID(projectId));
                                }

                                string mealsAllowanceType = ""; if (isMealsAllowanceFooter) mealsAllowanceType = "Full Day";
                                decimal mealsAllowance = MealsAllowance.GetMealsAllowance(mealsCountry, isMealsAllowanceFooter, "Full Day");

                                string jobClassType = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlJobClassTypeFooter")).SelectedValue;

                                // Insert Data
                                ProjectTimeTemp model = new ProjectTimeTemp(projectTimeTDS);
                                model.Insert(employeeId, companiesId, projectId, date_, startTimeFooter, endTimeFooter, offsetFooterFinal, workingDetailsFooter, location, mealsCountry, mealsAllowanceType, isMealsAllowanceFooter, mealsAllowance, unitIdFooter, towedIdFooter, projectTimeState, commentsFooter, work_, function_, typeOfWorkFooter, fairWage, jobClassType);

                                // Store Dataset
                                Session.Remove("projectTimeTempNewDummy");
                                Session["projectTimeTDS"] = projectTimeTDS;
                                Session["projectTimeTemp"] = projectTimeTDS.LFS_PROJECT_TIME_TEMP;

                                grdProjectTime.DataBind();
                                grdProjectTime.PageIndex = grdProjectTime.PageCount - 1;
                            }
                        }
                    }
                }

                hdfIsMoreThan15.Value = "false";
                upIsMoreThan15.Update();
            }
        }



        protected bool FooterValidate()
        {
            int projectId = int.Parse(ddlProject.SelectedValue);

            if (projectId == 35 || projectId == 39 || projectId == 716)
            {
                return false;
            }
            else
            {
                string startTimeFooter = "";
                string startHoursFooter = ""; if (((DropDownList)grdProjectTime.FooterRow.FindControl("ddlStartTimeHourFooter")).SelectedValue.Trim() != "") startHoursFooter = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlStartTimeHourFooter")).SelectedValue.Trim();
                string startMinutesFooter = ""; if (((DropDownList)grdProjectTime.FooterRow.FindControl("ddlStartTimeMinuteFooter")).SelectedValue.Trim() != "") startMinutesFooter = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlStartTimeMinuteFooter")).SelectedValue.Trim();

                if ((startHoursFooter != "") && (startMinutesFooter != "" || startMinutesFooter != "00"))
                {
                    startTimeFooter = startHoursFooter + ":" + startMinutesFooter;
                }

                string endTimeFooter = "";
                string endHoursFooter = ""; if (((DropDownList)grdProjectTime.FooterRow.FindControl("ddlEndTimeHourFooter")).SelectedValue.Trim() != "") endHoursFooter = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlEndTimeHourFooter")).SelectedValue.Trim();
                string endMinutesFooter = ""; if (((DropDownList)grdProjectTime.FooterRow.FindControl("ddlEndTimeMinuteFooter")).SelectedValue.Trim() != "") endMinutesFooter = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlEndTimeMinuteFooter")).SelectedValue.Trim();

                if ((endHoursFooter != "") && (endMinutesFooter != "" || endMinutesFooter != "00"))
                {
                    endTimeFooter = endHoursFooter + ":" + endMinutesFooter;
                }

                string typeOfWorkFooter = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlTypeOfWorkFooter")).SelectedValue;
                int? unitIdFooter = null; if (((DropDownList)grdProjectTime.FooterRow.FindControl("ddlUnitFooter")).SelectedValue != "-1") unitIdFooter = Int32.Parse(((DropDownList)grdProjectTime.FooterRow.FindControl("ddlUnitFooter")).SelectedValue);
                int? towedIdFooter = null; if (((DropDownList)grdProjectTime.FooterRow.FindControl("ddlTowedFooter")).SelectedValue != "-1") towedIdFooter = Int32.Parse(((DropDownList)grdProjectTime.FooterRow.FindControl("ddlTowedFooter")).SelectedValue);
                bool isMealsAllowanceFooter = false;// ((CheckBox)grdProjectTime.FooterRow.FindControl("ckbxMealsAllowanceFooter")).Checked;
                string commentsFooter = ((TextBox)grdProjectTime.FooterRow.FindControl("tbxCommentsFooter")).Text;

                if ((startTimeFooter != "") || (endTimeFooter != "") || (typeOfWorkFooter != "(Select)" && typeOfWorkFooter != "") || (unitIdFooter.HasValue) || (towedIdFooter.HasValue) || (isMealsAllowanceFooter) || (commentsFooter != ""))
                {
                    return true;
                }
            }

            return false;
        }



        private static double CalculateProjectTime(DateTime? startTime, DateTime? endTime, double? offset)
        {
            double hours = 0;
            TimeSpan diference;

            if ((startTime.HasValue) && (endTime.HasValue))
            {
                if (!offset.HasValue)
                {
                    offset = 0;
                }

                if ((DateTime)endTime >= (DateTime)startTime)
                {
                    diference = (DateTime)endTime - (DateTime)startTime;
                    hours = (double)(((diference.Hours * 60 + diference.Minutes) - (offset * 60)) / 60);
                }
                else
                {
                    diference = (DateTime)startTime - (DateTime)endTime;
                    hours = (double)((1440 - (diference.Hours * 60 + diference.Minutes) - (offset * 60)) / 60);
                }
            }

            string hoursString = hours.ToString("f2");

            return double.Parse(hoursString);
        }



        protected string GetUnitCode(object unitId)
        {
            int companyId = Int32.Parse(hdfCompanyId.Value);
            if (unitId != DBNull.Value)
            {
                UnitsGateway unitsGateway = new UnitsGateway();
                unitsGateway.LoadByUnitId((int)unitId, companyId);

                if (unitsGateway.Table.Rows.Count > 0)
                {
                    return unitsGateway.GetUnitCode((int)unitId);
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }



        private bool ValidatePage()
        {
            bool validData = true;
            cvDatePayPeriodStartDate.IsValid = true;
            cvDayPayPeriodLastDate.IsValid = true;
            cvDateLimitedPayPeriodStartDate.IsValid = true;
            cvDateLimitedPayPeriodLastDate.IsValid = true;

            // Validate general data
            Page.Validate("generalData");

            cvDatePayPeriodStartDate.IsValid = (tkrdpStartDate.SelectedDate != null) ? LiquiForce.LFSLive.BL.LabourHours.ProjectTime.ProjectTime.ValidateExistPayPeriod(tkrdpStartDate.SelectedDate.Value) : false;

            int projectId = int.Parse(ddlProject.SelectedValue);
            if (projectId == 35 || projectId == 39 || projectId == 716)
            {
                cvDayPayPeriodLastDate.IsValid = (tkrdpEndDate.SelectedDate != null) ? LiquiForce.LFSLive.BL.LabourHours.ProjectTime.ProjectTime.ValidateExistPayPeriod(tkrdpEndDate.SelectedDate.Value) : false;
            }

            if (!Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_FULL_EDITING"]))
            {
                if (Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_MY_TIMESHEETS_MANAGEMENT"]) || Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_OTHERS_TIMESHEETS_MANAGEMENT"]))
                {
                    cvDateLimitedPayPeriodStartDate.IsValid = (tkrdpStartDate.SelectedDate != null) ? LiquiForce.LFSLive.BL.LabourHours.ProjectTime.ProjectTime.ValidateLimitedPayPeriodToManagementEdit(tkrdpStartDate.SelectedDate.Value, projectId) : false;

                    if (projectId == 35 || projectId == 39 || projectId == 716)
                    {
                        cvDateLimitedPayPeriodLastDate.IsValid = (tkrdpEndDate.SelectedDate != null) ? LiquiForce.LFSLive.BL.LabourHours.ProjectTime.ProjectTime.ValidateLimitedPayPeriodToManagementEdit(tkrdpEndDate.SelectedDate.Value, projectId) : false;
                    }
                }
                
                if (Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_MY_TIMESHEETS_MANAGEMENT_WED"]) || Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_OTHERS_TIMESHEETS_MANAGEMENT_WED"]))
                {
                    cvDateLimitedWednesdayPayPeriodStartDate.IsValid = (tkrdpStartDate.SelectedDate != null) ? LiquiForce.LFSLive.BL.LabourHours.ProjectTime.ProjectTime.ValidateLimitedPayPeriodToWednesdayManagementEdit(tkrdpStartDate.SelectedDate.Value, projectId) : false;

                    if (projectId == 35 || projectId == 39 || projectId == 716)
                    {
                        cvDateLimitedWednesdayPayPeriodStartDate.IsValid = (tkrdpEndDate.SelectedDate != null) ? LiquiForce.LFSLive.BL.LabourHours.ProjectTime.ProjectTime.ValidateLimitedPayPeriodToWednesdayManagementEdit(tkrdpEndDate.SelectedDate.Value, projectId) : false;
                    }
                }                
            }

            if (projectId == 35 || projectId == 39 || projectId == 716)
            {
                if (tkrdpStartDate.SelectedDate != null && tkrdpEndDate.SelectedDate != null)
                {
                    if (tkrdpEndDate.SelectedDate.Value >= tkrdpStartDate.SelectedDate.Value)
                    {
                        cvMinDateLastDate.IsValid = true;
                    }
                    else
                    {
                        cvMinDateLastDate.IsValid = false;
                    }
                }
                else
                {
                    cvMinDateLastDate.IsValid = false;
                }
            }
            else
            {
                cvMinDateLastDate.IsValid = true;
            }

            if (Page.IsValid)
            {
                Page.Validate("footerValidData");
                if (!Page.IsValid)
                {
                    // Validate project times
                    if (FooterValidate())
                    {
                        Page.Validate("footerData");
                        if (!Page.IsValid)
                        {
                            validData = false;
                        }
                    }

                    Page.Validate("editData");
                    if (!Page.IsValid)
                    {
                        validData = false;
                    }
                }
            }
            else
            {
                validData = false;
            }

            return validData;
        }

                   



    }
}
