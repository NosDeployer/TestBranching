using System;
using LiquiForce.LFSLive.DA.LabourHours.ProjectTime;
using LiquiForce.LFSLive.DA.Resources.Employees;
using LiquiForce.LFSLive.DA.RAF;

namespace LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime
{
    /// <summary>
    /// print_employee_location
    /// </summary>
    public partial class print_employee_location : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // EVENTS
        //

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Security check
                if (!Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_FULL_EDITING"]))
                {
                    if (!Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_REPORTS"]))
                    {
                        Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                    }
                }

                // Initialize viewstate variables
                System.Configuration.AppSettingsReader appSettingReader = new System.Configuration.AppSettingsReader();
                ViewState["LHMode"] = appSettingReader.GetValue("LABOUR_HOURS_OPERATION_MODE", typeof(System.String)).ToString();

                // Prepare initial data for client
                ddlProjectTimeState.SelectedValue = "Approved";
                tkrdpStartDate.SelectedDate = DateTime.Now;
                tkrdpEndDate.SelectedDate = DateTime.Now;

                // Databind
                ddlEmployee.DataBind();

                // Register delegates
                this.RegisterDelegates();
            }
            else
            {
                // Register delegates
                this.RegisterDelegates();
            }
        }



        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Dialog title
            mReport1 master = (mReport1)this.Master;
            master.Title = "Print Team Member Location Report";

            master.ShowTitle = true;
            master.ShowToolBar = true;
            master.ShowCriteria = true;
            master.CriteriaWidth = "200px";

            if (!IsPostBack)
            {
                master.PrintDirectly = false;
                master.ExportDirectly = false;
            }

            // Access control
            // ... Labour Hours Mode
            if ((string)ViewState["LHMode"] == "Partial")
            {
                lblProjectTimeState.Visible = false;
                ddlProjectTimeState.Visible = false;
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // METHODS
        //

        private void RegisterDelegates()
        {
            mReport1 master = (mReport1)this.Master;
            master.GenerateMethod = new mReport1.ReportMethod(Generate);
        }



        private void Generate()
        {
            mReport1 master = (mReport1)this.Master;

            // Get Data
            string projectTimeState = (ddlProjectTimeState.SelectedValue == "(All)") ? "%" : ddlProjectTimeState.SelectedValue;

            PrintEmployeeLocationGateway printEmployeeLocationGateway = new PrintEmployeeLocationGateway();
            if (ddlEmployee.SelectedValue == "-1")
            {
                if (tbxLocation.Text.Trim() == "yes")
                {
                    printEmployeeLocationGateway.LoadByStartDateEndDateProjectTimeState(DateTime.Parse(tkrdpStartDate.SelectedDate.Value.ToShortDateString()), DateTime.Parse(tkrdpEndDate.SelectedDate.Value.ToShortDateString()), projectTimeState);
                }
                else
                {
                    printEmployeeLocationGateway.LoadByStartDateEndDateLocationProjectTimeState(DateTime.Parse(tkrdpStartDate.SelectedDate.Value.ToShortDateString()), DateTime.Parse(tkrdpEndDate.SelectedDate.Value.ToShortDateString()), tbxLocation.Text.Trim(), projectTimeState);
                }
            }
            else
            {
                if (tbxLocation.Text.Trim() == "yes")
                {
                    printEmployeeLocationGateway.LoadByStartDateEndDateEmployeeIdProjectTimeState(DateTime.Parse(tkrdpStartDate.SelectedDate.Value.ToShortDateString()), DateTime.Parse(tkrdpEndDate.SelectedDate.Value.ToShortDateString()), Int32.Parse(ddlEmployee.SelectedValue), projectTimeState);
                }
                else
                {
                    printEmployeeLocationGateway.LoadByStartDateEndDateEmployeeIdLocationProjectTimeState(DateTime.Parse(tkrdpStartDate.SelectedDate.Value.ToShortDateString()), DateTime.Parse(tkrdpEndDate.SelectedDate.Value.ToShortDateString()), int.Parse(ddlEmployee.SelectedValue), tbxLocation.Text.Trim(), projectTimeState);
                }
            }

            // ... set properties to master page
            master.Data = printEmployeeLocationGateway.Data;
            master.Table = printEmployeeLocationGateway.TableName;

            // Get report
            if (printEmployeeLocationGateway.Table.Rows.Count > 0)
            {
                if (master.Format == "pdf")
                {
                    master.Report = new LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime.PrintEmployeeLocationReport();
                }
                else
                {
                    master.Report = new LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime.PrintEmployeeLocationReportExport();
                }

                // ... set parameters to report
                if (master.Format == "pdf")
                {
                    // ... For report
                    // ... ... project time state
                    if (ddlProjectTimeState.SelectedValue == "(All)")
                    {
                        master.SetParameter("projectTimeState", "All");
                    }
                    else
                    {
                        master.SetParameter("projectTimeState", ddlProjectTimeState.SelectedItem.Text);
                    }

                    // ... ... team member
                    if (ddlEmployee.SelectedValue == "-1")
                    {
                        master.SetParameter("teamMember", "All");
                    }
                    else
                    {
                        int teamMemberId = Int32.Parse(ddlEmployee.SelectedValue);
                        EmployeeGateway employeeGateway = new EmployeeGateway();
                        employeeGateway.LoadByEmployeeId(teamMemberId);
                        string fullName = employeeGateway.GetFullName(teamMemberId);

                        master.SetParameter("teamMember", fullName);
                    }

                    // ... ...  user
                    int loginId = Convert.ToInt32(Session["loginID"]);
                    int companyId = Convert.ToInt32(Session["companyID"]);
                    
                    LoginGateway loginGateway = new LoginGateway();
                    loginGateway.LoadByLoginId(loginId, companyId);
                    string user = loginGateway.GetLastName(loginId, companyId) + " " + loginGateway.GetFirstName(loginId, companyId);
                    master.SetParameter("User", user.Trim());

                    master.SetParameter("location", tbxLocation.Text.Trim());
                    master.SetParameter("startTime", tkrdpStartDate.SelectedDate.Value.ToShortDateString());
                    master.SetParameter("endTime", tkrdpEndDate.SelectedDate.Value.ToShortDateString());
                }
            }
        }



    }
}