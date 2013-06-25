using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.BL.LabourHours.ProjectTime;
using LiquiForce.LFSLive.BL.Resources.Employees;
using LiquiForce.LFSLive.DA.LabourHours.PayPeriod;
using LiquiForce.LFSLive.DA.LabourHours.ProjectTime;
using LiquiForce.LFSLive.DA.Resources.Employees;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime
{
    /// <summary>
    /// timesheet_approve
    /// </summary>
    public partial class timesheet_approve : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // PROPERTIES AND FIELDS
        //

        protected ProjectTimeApproveTDS projectTimeApproveTDS;
        protected ProjectTimeApproveTDS.ProjectTimeApproveDataTable projectTimeApprove;






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
                if ((string)Request.QueryString["source_page"] == null)
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in timesheet_approve.aspx");
                }

                // Security check
                EmployeeGateway employeeGateway1 = new EmployeeGateway(new DataSet());
                int employeeId = employeeGateway1.GetEmployeIdByLoginId(Convert.ToInt32(Session["loginID"]));
                hdfCurrentEmployeeId.Value = employeeGateway1.GetEmployeIdByLoginId(Convert.ToInt32(Session["loginID"])).ToString();
                employeeGateway1.LoadByEmployeeId(employeeId);

                if (!employeeGateway1.GetApproveTimesheets(employeeId))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Tag page
                Session.Remove("projectTimeApproveDummy");

                // Initialize  variables
                lblError.Visible = false;

                // ... Initialize viewstate variables
                System.Configuration.AppSettingsReader appSettingReader = new System.Configuration.AppSettingsReader();
                ViewState["LHMode"] = appSettingReader.GetValue("LABOUR_HOURS_OPERATION_MODE", typeof(System.String)).ToString();

                // Labour Hours Mode check
                if ((string)ViewState["LHMode"] == "Partial")
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "The system is on partial mode. Contact your system administrator.");
                }

                ViewState["others"] = Request.QueryString["others"];

                PayPeriodGateway payPeriodGateway = new PayPeriodGateway(new DataSet());
                ViewState["period_id"] = payPeriodGateway.GetPayPeriodId(DateTime.Now);

                // Load data                                                          
                // ... Loading employees accordingly to the admins country.
                EmployeeList employeeList = new EmployeeList(new DataSet());
                string employeeType = employeeGateway1.GetType(employeeId);
                odsClient.SelectParameters.RemoveAt(2);
                if (employeeType.Contains("CA"))
                {
                    employeeList.LoadByRequestProjectTimeEmployeeTypeEmployeeIdApproveManagerAndAddItem(1, "CA", -1, "(All)", employeeId);
                    
                    odsClient.SelectParameters.Add("countryId", "1");                    
                }
                else
                {
                    if (employeeType.Contains("US"))
                    {
                        employeeList.LoadByRequestProjectTimeEmployeeTypeEmployeeIdApproveManagerAndAddItem(1, "US", -1, "(All)", employeeId);

                        odsClient.SelectParameters.Add("countryId", "2");
                    }
                    else
                    {
                        employeeList.LoadByRequestProjectTimeEmployeeTypeEmployeeIdApproveManagerAndAddItem(1, "SOTA", -1, "(All)", employeeId);

                        odsClient.SelectParameters.Add("countryId", "-1");
                    }
                }

                odsClient.Select();
                ddlClient.SelectedIndex = 0;
                upnlClient.Update();

                ddlTeamMember.DataSource = employeeList.Table;
                ddlTeamMember.DataValueField = "EmployeeID";
                ddlTeamMember.DataTextField = "FullName";
                ddlTeamMember.DataBind();
                
                odsProject.SelectParameters.RemoveAt(2);
                odsProject.SelectParameters.Add("clientId", "-1");
                odsProject.Select();
                ddlProject.DataBind();
                ddlProject.SelectedIndex = 0;
                upnlProject.Update();

                projectTimeApproveTDS = this.SubmitSearch();

                // Store Datasets
                Session["projectTimeApproveTDS"] = projectTimeApproveTDS;
                projectTimeApprove = projectTimeApproveTDS.ProjectTimeApprove;
                Session["projectTimeApprove"] = projectTimeApproveTDS.ProjectTimeApprove;

                // If coming from                 
                // ... timesheet_edit.aspx, timesheet_summary.aspx or timesheet_delete.aspx
                if ((Request.QueryString["source_page"] == "timesheet_edit.aspx") || (Request.QueryString["source_page"] == "timesheet_summary.aspx") || (Request.QueryString["source_page"] == "timesheet_delete.aspx"))
                {
                    // ... restore top values
                    RestoreNavigatorState();

                    // ... filter grid information
                    //SetFilterByCountryIdClientIdProjectId();
                    //SetFilterByEmployeeIdDate();
                    SetFilterByClientIdProjectIdEmployeeIdDate();
                }                

                ViewState["filter_expression"] = "Deleted = 0";

                SetFocus();
            }
            else
            {
                // Restore dataset
                projectTimeApproveTDS = (ProjectTimeApproveTDS)Session["projectTimeApproveTDS"];
                projectTimeApprove = projectTimeApproveTDS.ProjectTimeApprove;
                Session["projectTimeApprove"] = projectTimeApproveTDS.ProjectTimeApprove;
            }
        }



        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set active toolbar
            mForm6 master = (mForm6)this.Master;
            master.ActiveToolbar = "LabourHours";

            EmployeeGateway employeeGateway1 = new EmployeeGateway(new DataSet());
            int employeeId = Int32.Parse(hdfCurrentEmployeeId.Value);
            employeeGateway1.LoadByEmployeeId(employeeId);

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






        // ////////////////////////////////////////////////////////////////////////
        // AUXILIAR EVENTS
        //

        protected void grdProjectTimeApprove_DataBound(object sender, EventArgs e)
        {
            AddTimesheetNewEmptyFix(grdProjectTimeApprove);

            odsProjectTimeApprove.FilterExpression = (string)ViewState["filter_expression"];
        }



        protected void grdProjectTimeApprove_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Normal items
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Normal) || (e.Row.RowState == (DataControlRowState.Normal | DataControlRowState.Alternate))))
            {
                Label lblJobClass = (Label)e.Row.FindControl("lblJobClass");
                Label lblTypeOfWork = (Label)e.Row.FindControl("lblTypeOfWork");

                 EmployeeGateway employeeGateway1 = new EmployeeGateway(new DataSet());            
                int employeeId = employeeGateway1.GetEmployeIdByLoginId(Convert.ToInt32(Session["loginID"]));            
                employeeGateway1.LoadByEmployeeId(employeeId);            
                string employeeType = employeeGateway1.GetType(employeeId);
                
                if (lblTypeOfWork.Text == "Mobilization" && employeeType.Contains("US"))
                {
                    lblJobClass.Visible = false;
                }
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATION EVENTS
        //

        protected void btnOpen_Click(object sender, EventArgs e)
        {
            Session["divScrollPosition"] = hdfScrollTop.Value;
            
            DropDownList ddlOthersFor = (DropDownList)tkrpbLeftMenuOthersTimesheets.FindItemByValue("nbOthersTimesheetsDDL").FindControl("ddlOthersFor");
            Session["ddlOthersForSelectedValue"] = ddlOthersFor.SelectedValue;

            int numOfProjectTimesSelected = SaveSelectedId();
            
            int projectTimeId = Int32.Parse(hdfSelectedProjectTimeId.Value);

            if (projectTimeId != 0)
            {
                if (numOfProjectTimesSelected == 1)
                {
                    lblError.Visible = false;

                    // Open
                    Response.Redirect("./timesheet_summary.aspx?source_page=timesheet_approve.aspx&others=" + ViewState["others"] + "&employee_id=" + hdfSelectedEmployeeId.Value + "&period_id=" + hdfSelectedPeriodId.Value + "&projecttime_id=" + hdfSelectedProjectTimeId.Value + GetNavigatorState());
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
            Session["divScrollPosition"] = hdfScrollTop.Value;

            DropDownList ddlOthersFor = (DropDownList)tkrpbLeftMenuOthersTimesheets.FindItemByValue("nbOthersTimesheetsDDL").FindControl("ddlOthersFor");
            Session["ddlOthersForSelectedValue"] = ddlOthersFor.SelectedValue;

            int numOfProjectTimesSelected = SaveSelectedId();

            int projectTimeId = Int32.Parse(hdfSelectedProjectTimeId.Value);

            if (projectTimeId != 0)
            {
                if (numOfProjectTimesSelected == 1)
                {
                    lblError.Visible = false;

                    // Edit
                    Response.Redirect("./timesheet_edit.aspx?source_page=timesheet_approve.aspx&others=" + ViewState["others"] + "&employee_id=" + hdfSelectedEmployeeId.Value + "&period_id=" + hdfSelectedPeriodId.Value + "&projecttime_id=" + hdfSelectedProjectTimeId.Value + GetNavigatorState());
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
            Session["divScrollPosition"] = hdfScrollTop.Value;

            DropDownList ddlOthersFor = (DropDownList)tkrpbLeftMenuOthersTimesheets.FindItemByValue("nbOthersTimesheetsDDL").FindControl("ddlOthersFor");
            Session["ddlOthersForSelectedValue"] = ddlOthersFor.SelectedValue;

            int numOfProjectTimesSelected = SaveSelectedId();

            int projectTimeId = Int32.Parse(hdfSelectedProjectTimeId.Value);

            if (projectTimeId != 0)
            {
                if (numOfProjectTimesSelected == 1)
                {
                    lblError.Visible = false;

                    // Delete
                    Response.Redirect("./timesheet_delete.aspx?source_page=timesheet_approve.aspx&others=" + ViewState["others"] + "&employee_id=" + hdfSelectedEmployeeId.Value + "&period_id=" + hdfSelectedPeriodId.Value + "&projecttime_id=" + hdfSelectedProjectTimeId.Value + GetNavigatorState());
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



        protected void tkrmTop_ItemClick(object sender, RadMenuEventArgs e)
        {
            Session["divScrollPosition"] = hdfScrollTop.Value;

            DropDownList ddlOthersFor = (DropDownList)tkrpbLeftMenuOthersTimesheets.FindItemByValue("nbOthersTimesheetsDDL").FindControl("ddlOthersFor");
            Session["ddlOthersForSelectedValue"] = ddlOthersFor.SelectedValue;

            switch (e.Item.Value)
            {
                case "mApprove":
                    int projectTimesSelected = PostPageChanges();

                    if (projectTimesSelected > 0)
                    {
                        Response.Redirect("./timesheet_state.aspx?source_page=timesheet_approve.aspx&others=" + ViewState["others"] + "&employee_id=-1&period_id=-1");
                    }
                    break;

                case "mCancel":
                    Session.Remove("projectTimeIdSelected");
                    Session.Remove("divScrollPosition");
                    Response.Redirect("./../timesheet/timesheet.aspx?source_page=timesheet_approve.aspx&others=" + ViewState["others"] + "&employee_id=" + hdfCurrentEmployeeId.Value + "&period_id=" + ViewState["period_id"]);
                    break;
            }
        }



        protected void tkrpbLeftMenu_ItemClick(object sender, RadPanelBarEventArgs e)
        {
            Session.Remove("projectTimeIdSelected");
            Session.Remove("divScrollPosition");

            DropDownList ddlOthersFor = (DropDownList)tkrpbLeftMenuOthersTimesheets.FindItemByValue("nbOthersTimesheetsDDL").FindControl("ddlOthersFor");
            Session["ddlOthersForSelectedValue"] = ddlOthersFor.SelectedValue;

            string url = "";

            switch (e.Item.Value)
            {
                case "nbOthersTimesheetsViewCurrent":
                    lblError.Visible = false;
                    if (ddlOthersFor.SelectedIndex >= 0)
                    {
                        Response.Redirect("./../timesheet/timesheet.aspx?source_page=lm&others=yes&employee_id=" + ddlOthersFor.SelectedValue);
                    }
                    break;

                case "nbOthersTimesheetsViewAll":
                    lblError.Visible = false;
                    if (ddlOthersFor.SelectedIndex >= 0)
                    {
                        Response.Redirect("./../timesheet/timesheet_all.aspx?source_page=lm&others=yes&employee_id=" + ddlOthersFor.SelectedValue);
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



        private void ApplyFilter()
        {
            odsProjectTimeApprove.FilterExpression = (string)ViewState["filter_expression"];
            grdProjectTimeApprove.DataBind();            
        }



        protected void SetFilterByClientIdProjectIdEmployeeIdDate()
        {
            StringBuilder filterExpression = new StringBuilder();

            filterExpression.Append("Deleted = 0");

            //if (ddlCountry.SelectedIndex > 0)
            //{
            //    filterExpression.Append(string.Format(" AND CountryID = {0}", ddlCountry.SelectedValue));
            //}

            if (ddlClient.SelectedIndex > 0)
            {
                filterExpression.Append(string.Format(" AND ClientID = {0}", ddlClient.SelectedValue));
            }

            if (ddlProject.SelectedIndex > 0)
            {
                filterExpression.Append(string.Format(" AND ProjectID = {0}", ddlProject.SelectedValue));
            }

            if (ddlTeamMember.SelectedIndex > 0)
            {
                filterExpression.Append(string.Format(" AND EmployeeID = {0}", ddlTeamMember.SelectedValue));
            }

            if (tkrdpStartDate.SelectedDate.HasValue)
            {
                filterExpression.Append(string.Format(" AND Date >= '{0}' AND Date <= '{1}'", tkrdpStartDate.SelectedDate.Value.ToShortDateString(), tkrdpEndDate.SelectedDate.Value.ToShortDateString()));
            }

            ViewState["filter_expression"] = filterExpression.ToString();

            if ((ddlClient.SelectedIndex > 0) || (ddlProject.SelectedIndex > 0) || (ddlTeamMember.SelectedIndex > 0) || (tkrdpStartDate.SelectedDate.HasValue))
            {               
                ApplyFilter();
            }
        }



        //protected void SetFilterByCountryIdClientIdProjectId()
        //{
        //    StringBuilder filterExpression = new StringBuilder();

        //    filterExpression.Append("Deleted = 0");

        //    //if (ddlCountry.SelectedIndex > 0)
        //    //{
        //    //    filterExpression.Append(string.Format(" AND CountryID = {0}", ddlCountry.SelectedValue));
        //    //}

        //    if (ddlClient.SelectedIndex > 0)
        //    {
        //        filterExpression.Append(string.Format(" AND ClientID = {0}", ddlClient.SelectedValue));
        //    }

        //    if (ddlProject.SelectedIndex > 0)
        //    {
        //        filterExpression.Append(string.Format(" AND ProjectID = {0}", ddlProject.SelectedValue));
        //    }

        //    ViewState["filter_expression"] = filterExpression.ToString();

        //    if ((ddlClient.SelectedIndex > 0)|| (ddlProject.SelectedIndex > 0))
        //    {
        //        ddlTeamMember.SelectedIndex = 0;
        //        tkrdpStartDate.SelectedDate = null;
        //        tkrdpEndDate.SelectedDate = null;

        //        upnlTeamMember.Update();
        //        upnlStartDate.Update();
        //        upnlEndDate.Update();

        //        ApplyFilter();
        //    }
        //}



        //protected void SetFilterByEmployeeIdDate()
        //{
        //    StringBuilder filterExpression = new StringBuilder();

        //    filterExpression.Append("Deleted = 0");

        //    if (ddlTeamMember.SelectedIndex > 0)
        //    {
        //        filterExpression.Append(string.Format(" AND EmployeeID = {0}", ddlTeamMember.SelectedValue));
        //    }

        //    if (tkrdpStartDate.SelectedDate.HasValue)
        //    {
        //        filterExpression.Append(string.Format(" AND Date >= '{0}' AND Date <= '{1}'", tkrdpStartDate.SelectedDate.Value.ToShortDateString(), tkrdpEndDate.SelectedDate.Value.ToShortDateString()));
        //    }

        //    ViewState["filter_expression"] = filterExpression.ToString();

        //    if ((ddlTeamMember.SelectedIndex > 0) || (tkrdpStartDate.SelectedDate.HasValue))
        //    {
        //        odsClient.SelectParameters.RemoveAt(2);
        //        EmployeeGateway employeeGateway1 = new EmployeeGateway(new DataSet());
        //        int employeeId = employeeGateway1.GetEmployeIdByLoginId(Convert.ToInt32(Session["loginID"]));
        //        employeeGateway1.LoadByEmployeeId(employeeId);

        //        EmployeeList employeeList = new EmployeeList(new DataSet());
        //        string employeeType = employeeGateway1.GetType(employeeId);
        //        if (employeeType.Contains("CA"))
        //        {
        //            odsClient.SelectParameters.Add("countryId", "1");
        //        }
        //        else
        //        {
        //            odsClient.SelectParameters.Add("countryId", "2");
        //        }
        //        odsClient.Select();
        //        ddlClient.SelectedIndex = 0;
        //        upnlClient.Update();

        //        odsProject.SelectParameters.RemoveAt(2);
        //        odsProject.SelectParameters.Add("clientId", "-1");
        //        odsProject.Select();
        //        ddlProject.DataBind();
        //        ddlProject.SelectedIndex = 0;
        //        upnlProject.Update();

        //        ApplyFilter();
        //    }
        //}



        protected void SetFilterDummy()
        {
            ViewState["filter_expression"] = "Deleted = 0 AND CountryID = 0 AND ClientID = 0 AND ProjectID = 0";

            ApplyFilter();
        }



        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            //odsClient.SelectParameters.RemoveAt(2);
            //odsClient.SelectParameters.Add("countryId", ddlCountry.SelectedValue);
            //odsClient.Select();
            //ddlClient.SelectedIndex = 0;
            //upnlClient.Update();

            //odsProject.SelectParameters.RemoveAt(2);
            //odsProject.SelectParameters.Add("clientId", "-1");
            //odsProject.Select();
            //ddlProject.DataBind();
            //ddlProject.SelectedIndex = 0;
            //upnlProject.Update();

            //SetFilterByCountryIdClientIdProjectId();
        }



        protected void ddlClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            odsProject.SelectParameters.RemoveAt(2);
            odsProject.SelectParameters.Add("clientId", ddlClient.SelectedValue);
            odsProject.Select();
            ddlProject.DataBind();
            ddlProject.SelectedIndex = 0;
            upnlProject.Update();

            //SetFilterByCountryIdClientIdProjectId();
            SetFilterByClientIdProjectIdEmployeeIdDate();
        }



        protected void ddlProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SetFilterByCountryIdClientIdProjectId();
            SetFilterByClientIdProjectIdEmployeeIdDate();
        }



        protected void ddlTeamMember_SelectedIndexChanged(object sender, EventArgs e)
        {            
            //SetFilterByEmployeeIdDate();
            SetFilterByClientIdProjectIdEmployeeIdDate();
        }



        protected void tkrdpStartDate_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            if (!tkrdpEndDate.SelectedDate.HasValue)
            {
                tkrdpEndDate.SelectedDate = tkrdpStartDate.SelectedDate;
                upnlEndDate.Update();
            }

            //SetFilterByEmployeeIdDate();
            SetFilterByClientIdProjectIdEmployeeIdDate();
        }



        protected void tkrdpEndDate_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            if (!tkrdpStartDate.SelectedDate.HasValue)
            {
                tkrdpStartDate.SelectedDate = tkrdpEndDate.SelectedDate;
                upnlStartDate.Update();
            }

            //SetFilterByEmployeeIdDate();
            SetFilterByClientIdProjectIdEmployeeIdDate();
        }






        // ////////////////////////////////////////////////////////////////////////
        //  PUBLIC METHODS
        //

        public ProjectTimeApproveTDS.ProjectTimeApproveDataTable GetProjectTimeApprove()
        {
            projectTimeApprove = (ProjectTimeApproveTDS.ProjectTimeApproveDataTable)Session["projectTimeApproveDummy"];
            
            if (projectTimeApprove == null)
            {
                projectTimeApprove = ((ProjectTimeApproveTDS.ProjectTimeApproveDataTable)Session["projectTimeApprove"]);
            }

            return projectTimeApprove;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        private void RegisterClientScripts()
        {
            // Register content variables
            string contentVariables = "";
            contentVariables += "var hdfScrollTopId = '" + hdfScrollTop.ClientID + "';";

            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode1", "./timesheet_approve.js");
        }



        private ProjectTimeApproveTDS SubmitSearch()
        {
            // Load data
            ProjectTimeApproveTDS dataSet = new ProjectTimeApproveTDS();
            ProjectTimeApproveGateway projectTimeApproveGateway = new ProjectTimeApproveGateway(dataSet);

            EmployeeGateway employeeGateway1 = new EmployeeGateway(new DataSet());            
            int employeeId = employeeGateway1.GetEmployeIdByLoginId(Convert.ToInt32(Session["loginID"]));            
            employeeGateway1.LoadByEmployeeId(employeeId);            
            string employeeType = employeeGateway1.GetType(employeeId);
            
            if (employeeType.Contains("CA"))
            {
                projectTimeApproveGateway.LoadByEmployeeTypeEmployeeIdApproveManager("CA", employeeId);
            }
            else
            {
                if (employeeType.Contains("US"))
                {
                    projectTimeApproveGateway.LoadByEmployeeTypeEmployeeIdApproveManager("US", employeeId);
                }
                else
                {
                    projectTimeApproveGateway.LoadByEmployeeTypeEmployeeIdApproveManager("SOTA", employeeId);
                }
            }

            return dataSet;
        }



        private int PostPageChanges()
        {
            int numOfProjectTimesSelected = 0;

            // Clear the projectTimesIdSelected list
            Session.Remove("projectTimesIdSelected");

            bool selected = false;
            int projectTimeId = 0;
            int employeeId = 0;

            List<int> projectTimesIdSelected = new List<int>();

            ProjectTimeApprove projectTimeApprove = new ProjectTimeApprove(projectTimeApproveTDS);
            
            foreach (GridViewRow row in grdProjectTimeApprove.Rows)
            {
                // ... Update all rows
                selected = ((CheckBox)row.FindControl("cbxSelected")).Checked;
                projectTimeId = Int32.Parse(((Label)row.FindControl("lblProjectTimeID")).Text.Trim());
                employeeId = Int32.Parse(((Label)row.FindControl("lblEmployeeID")).Text.Trim());

                projectTimeApprove.Update(projectTimeId, selected);

                // ... Save selecteds project times id
                if (selected)
                {
                    numOfProjectTimesSelected++;
                    projectTimesIdSelected.Add(projectTimeId);
                }
            }

            projectTimeApproveTDS.AcceptChanges();

            // ... Store datasets
            Session["projectTimeApproveTDS"] = projectTimeApproveTDS;
            Session["projectTimeApprove"] = projectTimeApproveTDS.ProjectTimeApprove;

            // ... Store project times id list
            Session["projectTimesIdSelected"] = projectTimesIdSelected;
            
            return numOfProjectTimesSelected;
        }



        protected void AddTimesheetNewEmptyFix(GridView grdProjectTimeApprove)
        {
            if (grdProjectTimeApprove.Rows.Count == 0)
            {
                ProjectTimeApproveTDS.ProjectTimeApproveDataTable dt = new ProjectTimeApproveTDS.ProjectTimeApproveDataTable();
                dt.AddProjectTimeApproveRow(-1, DateTime.Now, "", "", "", "", DateTime.Now, DateTime.Now, 0, "", false, 0, 0, 0, false, "", "", "");
                Session["projectTimeApproveDummy"] = dt;
                SetFilterDummy();                
            }

            // normally executes at all postbacks
            if (grdProjectTimeApprove.Rows.Count == 1)
            {
                ProjectTimeApproveTDS.ProjectTimeApproveDataTable dt = (ProjectTimeApproveTDS.ProjectTimeApproveDataTable)Session["projectTimeApproveDummy"];
                if (dt != null)
                {
                    grdProjectTimeApprove.Rows[0].Visible = false;
                    grdProjectTimeApprove.Rows[0].Controls.Clear();

                    Session.Remove("projectTimeApproveDummy");
                }
            }
        }



        protected int SaveSelectedId()
        {
            int numOfProjectTimesSelected = 0;
            int idForUpdate = 0;
            int employeeIdForUpdate = 0;
            bool selected = false;
            hdfSelectedProjectTimeId.Value = "0";

            ProjectTimeApprove projectTimeApprove = new ProjectTimeApprove(projectTimeApproveTDS);

            foreach (GridViewRow row in grdProjectTimeApprove.Rows)
            {
                // ... Update all rows
                selected = ((CheckBox)row.FindControl("cbxSelected")).Checked;
                idForUpdate = Int32.Parse(((Label)row.FindControl("lblProjectTimeID")).Text.Trim());
                employeeIdForUpdate = Int32.Parse(((Label)row.FindControl("lblEmployeeID")).Text.Trim());
                
                projectTimeApprove.Update(idForUpdate, selected);

                // ... Save selected id
                if (selected)
                {
                    hdfSelectedProjectTimeId.Value = idForUpdate.ToString();
                    hdfSelectedEmployeeId.Value = employeeIdForUpdate.ToString();
                    DateTime date_ = DateTime.Parse(((Label)row.FindControl("lblDate")).Text.Trim());

                    PayPeriodGateway payPeriodGateway = new PayPeriodGateway(new DataSet());
                    hdfSelectedPeriodId.Value = payPeriodGateway.GetPayPeriodId(date_).ToString();

                    numOfProjectTimesSelected++;

                    Session["projectTimeIdSelected"] = row.RowIndex;
                }
            }

            projectTimeApprove.Data.AcceptChanges();

            // ... Store datasets
            Session["projectTimeApproveTDS"] = projectTimeApproveTDS;
            Session["projectTimeApprove"] = projectTimeApproveTDS.ProjectTimeApprove;

            return numOfProjectTimesSelected;
        }



        private void RestoreNavigatorState()
        {
            //ddlCountry.DataBind();
            //ddlCountry.SelectedValue = Request.QueryString["search_ddlCountry"];                      

            ddlClient.DataBind();
            ddlClient.SelectedValue = Request.QueryString["search_ddlClient"];

            ddlProject.DataBind();
            ddlProject.SelectedValue = Request.QueryString["search_ddlProject"];
                        
            ddlTeamMember.DataBind();
            ddlTeamMember.SelectedValue = Request.QueryString["search_ddlTeamMember"];

            tkrdpStartDate.SelectedDate = null;
            
            if (!String.IsNullOrEmpty(Request.QueryString["search_tkrdpStartDate"].ToString()))
            {
                tkrdpStartDate.SelectedDate = DateTime.Parse(Request.QueryString["search_tkrdpStartDate"]);
            }

            tkrdpEndDate.SelectedDate = null;
            if (!String.IsNullOrEmpty(Request.QueryString["search_tkrdpEndDate"].ToString()))
            {
                tkrdpEndDate.SelectedDate = DateTime.Parse(Request.QueryString["search_tkrdpEndDate"]);
            }
        }



        private string GetNavigatorState()
        {
            string searchOptions = "";
            searchOptions = searchOptions + "&search_ddlCountry=1";
            searchOptions = searchOptions + "&search_ddlClient=" + ddlClient.Text.Trim();
            searchOptions = searchOptions + "&search_ddlProject=" + ddlProject.Text.Trim();
            searchOptions = searchOptions + "&search_ddlTeamMember=" + ddlTeamMember.SelectedValue;
            searchOptions = searchOptions + "&search_tkrdpStartDate=" + tkrdpStartDate.SelectedDate;
            searchOptions = searchOptions + "&search_tkrdpEndDate=" + tkrdpEndDate.SelectedDate;

            // Return
            return searchOptions;
        }



        private void SetFocus()
        {
            if (Session["projectTimeIdSelected"] != null)
            {
                SetFocusGridView();
            }

            if (Session["divScrollPosition"] != null)
            {
                SetFocusDivScroll();
            }
        }



        private void SetFocusGridView()
        {
            try
            {
                // ... Get row
                int index = (int)Session["projectTimeIdSelected"];
                GridViewRow gridRow = grdProjectTimeApprove.Rows[index];
                
                // ... Select row
                ProjectTimeApprove projectTimeApprove = new ProjectTimeApprove(projectTimeApproveTDS);
                int idForUpdate = Int32.Parse(((Label)gridRow.FindControl("lblProjectTimeID")).Text.Trim());
                projectTimeApprove.Update(idForUpdate, true);
                projectTimeApprove.Data.AcceptChanges();

                // ... Store datasets
                Session["projectTimeApproveTDS"] = projectTimeApproveTDS;
                Session["projectTimeApprove"] = projectTimeApproveTDS.ProjectTimeApprove;
            }
            catch
            {
            }
        }



        private void SetFocusDivScroll()
        {
            try
            {
                string scrollTop = Session["divScrollPosition"].ToString();                
                System.Text.StringBuilder strBuilder = new System.Text.StringBuilder();
                strBuilder.Append("<script language='javascript'>");
                strBuilder.Append("function setFocus() {");
                strBuilder.Append("if (!document.getElementById) return;");
                strBuilder.Append("var vF = document.getElementById('" + divScroll.ClientID + "');");
                strBuilder.Append("vF.scrollTop = '" + scrollTop + "'}");
                strBuilder.Append("setFocus();");
                strBuilder.Append("</script>");
                ClientScript.RegisterStartupScript(typeof(Page), "Focus", strBuilder.ToString());
            }
            catch
            {
            }
        }



    }
}