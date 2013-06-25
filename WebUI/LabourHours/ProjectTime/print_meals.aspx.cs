using System;
using LiquiForce.LFSLive.DA.RAF;
using LiquiForce.LFSLive.DA.Resources.Employees;
using LiquiForce.LFSLive.DA.LabourHours.ProjectTime;

namespace LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime
{
    /// <summary>
    /// print_meals
    /// </summary>
    public partial class print_meals : System.Web.UI.Page
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
                ddlEmployeeType.DataBind();

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
            master.Title = "Print Meals Report";

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

            PrintMealsGateway printMealsGateway = new PrintMealsGateway();
            if (ddlEmployee.SelectedValue == "-1")
            {
                if (ddlSalaried.SelectedValue == "(All)")
                {
                    printMealsGateway.LoadByEmployeeTypeStartDateEndDateProjectTimeState(employeeType, startDate, endDate, projectTimeState);
                }
                else
                {
                    printMealsGateway.LoadByEmployeeSalariedTypeStartDateEndDateProjectTimeState(employeeType, startDate, endDate, projectTimeState, int.Parse(ddlSalaried.SelectedValue));
                }
            }
            else
            {
                if (ddlSalaried.SelectedValue == "(All)")
                {
                    printMealsGateway.LoadByEmployeeTypeStartDateEndDateEmployeeIdProjectTimeState(employeeType, startDate, endDate, int.Parse(ddlEmployee.SelectedValue), projectTimeState);
                }
                else
                {
                    printMealsGateway.LoadByEmployeeTypeSalariedEmployeeIdStartDateEndDateProjectTimeState(employeeType, startDate, endDate, int.Parse(ddlEmployee.SelectedValue), projectTimeState, int.Parse(ddlSalaried.SelectedValue));
                }
            }

            // ... set properties to master page
            master.Data = printMealsGateway.Data;
            master.Table = printMealsGateway.TableName;

            // Get report
            if (printMealsGateway.Table.Rows.Count > 0)
            {
                if (master.Format == "pdf")
                {
                    master.Report = new LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime.PrintMealsReport();
                }
                else
                {
                    master.Report = new LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime.PrintMealsReportExport();
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

                    // ... ... salaried
                    if (ddlSalaried.SelectedValue == "(All)")
                    {
                        master.SetParameter("salaried", "All");
                    }
                    else
                    {
                        if (ddlSalaried.SelectedValue == "1")  master.SetParameter("salaried", "Yes");
                        if (ddlSalaried.SelectedValue == "0") master.SetParameter("salaried", "No");
                    }
                    master.SetParameter("dateFrom", tkrdpStartDate.SelectedDate.Value.ToShortDateString());
                    master.SetParameter("dateTo", tkrdpEndDate.SelectedDate.Value.ToShortDateString());
                }
                else
                {
                    master.SetParameter("dateFrom", tkrdpStartDate.SelectedDate.Value.ToShortDateString());
                    master.SetParameter("dateTo", tkrdpEndDate.SelectedDate.Value.ToShortDateString());
                }
            }
        }


        
    }
}