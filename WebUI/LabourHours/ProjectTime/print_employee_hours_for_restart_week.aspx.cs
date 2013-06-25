using System;
using LiquiForce.LFSLive.DA.RAF;
using LiquiForce.LFSLive.DA.LabourHours.ProjectTime;

namespace LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime
{
    /// <summary>
    /// print_employee_hours_for_restart_week
    /// </summary>
    public partial class print_employee_hours_for_restart_week : System.Web.UI.Page
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
            master.Title = "Print Team Member Hours For Restart Week Report";

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
            string employeeType = (ddlEmployeeType.SelectedValue == "(All)") ? "%" : ddlEmployeeType.SelectedValue + "%";
            string projectTimeState = (ddlProjectTimeState.SelectedValue == "(All)") ? "%" : ddlProjectTimeState.SelectedValue;
            DateTime startDate = DateTime.Parse(tkrdpStartDate.SelectedDate.Value.ToShortDateString());
            DateTime endDate = DateTime.Parse(tkrdpEndDate.SelectedDate.Value.ToShortDateString());

            PrintEmployeeHoursForRestartWeekGateway printEmployeeHoursForRestartWeekGateway = new PrintEmployeeHoursForRestartWeekGateway();
            printEmployeeHoursForRestartWeekGateway.LoadByEmployeeTypeStartDateEndDateProjectTimeState(employeeType, startDate, endDate, projectTimeState);

            // ... set properties to master page
            master.Data = printEmployeeHoursForRestartWeekGateway.Data;
            master.Table = printEmployeeHoursForRestartWeekGateway.TableName;

            // Get report
            if (printEmployeeHoursForRestartWeekGateway.Table.Rows.Count > 0)
            {
                if (master.Format == "pdf")
                {
                    master.Report = new LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime.PrintEmployeeHoursForRestartWeekReport();
                }
                else
                {
                    master.Report = new LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime.PrintEmployeeHoursForRestartWeekReportExport();
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

                    // ... ... team member type
                    if (ddlEmployeeType.SelectedValue == "(All)")
                    {
                        master.SetParameter("teamMemberType", "All");
                    }
                    else
                    {
                        if (ddlEmployeeType.SelectedValue == "LFSCA") master.SetParameter("teamMemberType", "LFS Canada");
                        if (ddlEmployeeType.SelectedValue == "LFSUS") master.SetParameter("teamMemberType", "LFS USA");
                        if (ddlEmployeeType.SelectedValue == "LFS") master.SetParameter("teamMemberType", "All LFS");
                        if (ddlEmployeeType.SelectedValue == "PAGCA") master.SetParameter("teamMemberType", "PAG Canada");
                        if (ddlEmployeeType.SelectedValue == "PAGUS") master.SetParameter("teamMemberType", "PAG USA");
                        if (ddlEmployeeType.SelectedValue == "PAG") master.SetParameter("teamMemberType", "All PAG");
                        if (ddlEmployeeType.SelectedValue == "SOTA") master.SetParameter("teamMemberType", "SOTA");
                        if (ddlEmployeeType.SelectedValue == "Salaried") master.SetParameter("teamMemberType", "Salaried");
                        if (ddlEmployeeType.SelectedValue == "Subcontractor") master.SetParameter("teamMemberType", "Subcontractor");
                    }

                    // ... ...  user
                    int loginId = Convert.ToInt32(Session["loginID"]);
                    int companyId = Convert.ToInt32(Session["companyID"]);

                    LoginGateway loginGateway = new LoginGateway();
                    loginGateway.LoadByLoginId(loginId, companyId);
                    string user = loginGateway.GetLastName(loginId, companyId) + " " + loginGateway.GetFirstName(loginId, companyId);
                    master.SetParameter("User", user.Trim());

                    master.SetParameter("dateFrom", tkrdpStartDate.SelectedDate.Value.ToShortDateString());
                    master.SetParameter("dateTo", tkrdpEndDate.SelectedDate.Value.ToShortDateString());
                }
            }
        }



    }
}