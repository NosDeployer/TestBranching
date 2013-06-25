using System;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.DA.Resources.Companies;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.DA.LabourHours.ProjectTime;
using LiquiForce.LFSLive.DA.RAF;

namespace LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime
{
    /// <summary>
    /// print_hours_for_payroll_period_old
    /// </summary>
    public partial class print_hours_for_payroll_period_old : System.Web.UI.Page
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
                ddlEmployeeType.SelectedValue = "(All)";
                tkrdpStartDate.SelectedDate = DateTime.Now;
                tkrdpEndDate.SelectedDate = DateTime.Now;

                // Databind
                ddlCountry.DataBind();
                cbxlEmployee.DataBind();
                foreach (ListItem lst in cbxlEmployee.Items)
                {
                    lst.Selected = true;
                }

                ddlClient.DataBind();
                ddlProject.DataBind();

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
            master.Title = "Print Hours For Payroll Period Report (Old Version)";

            master.ShowTitle = true;
            master.ShowToolBar = true;
            master.ShowCriteria = true;
            master.CriteriaWidth = "200px";

            if (!IsPostBack)
            {
                master.PrintDirectly = false;
                master.ExportDirectly = false;
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // AUXILIAR EVENTS
        //

        protected void ddlClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            odsProject.SelectParameters.RemoveAt(2);
            odsProject.SelectParameters.Add("ClientId", ddlClient.SelectedValue);
            odsProject.Select();
            ddlProject.SelectedIndex = 0;
        }



        protected void ddlEmployeeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string employeeType = "";

            if (ddlEmployeeType.SelectedIndex > 0)
            {
                employeeType = ddlEmployeeType.SelectedValue;

                if (employeeType == "PAGCA" || employeeType == "PAGUS" || employeeType == "PAG")
                {
                    pnlPersonnelAgency.Visible = true;
                }
                else
                {
                    pnlPersonnelAgency.Visible = false;
                }
            }

            upnlPersonnelAgency.Update();
        }



        protected void cbxEmployeeState_CheckedChanged(object sender, EventArgs e)
        {
            string state = "Active";
            if (cbxEmployeeState.Checked) state = "NLE"; else state = "Active";
            odsEmployee.SelectParameters.RemoveAt(3);
            odsEmployee.SelectParameters.Add("state", state);
            odsEmployee.Select();

            cbxlEmployee.DataBind();

            foreach (ListItem lst in cbxlEmployee.Items)
            {
                lst.Selected = true;
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
            string projectTimeState = "%";
            DateTime startDate = DateTime.Parse(tkrdpStartDate.SelectedDate.Value.ToShortDateString());
            DateTime endDate = DateTime.Parse(tkrdpEndDate.SelectedDate.Value.ToShortDateString());
            int clientId = 0; if (ddlClient.SelectedValue != "-1") clientId = Int32.Parse(ddlClient.SelectedValue);
            int projectId = 0; if (ddlProject.SelectedValue != "-1") projectId = Int32.Parse(ddlProject.SelectedValue);
            string personnelAgencySelected = "%";
            if (pnlPersonnelAgency.Visible)
            {
                if (ddlPersonalAgency.SelectedIndex > 0)
                {
                    personnelAgencySelected = ddlPersonalAgency.SelectedValue + "%";
                }
            }

            PrintHoursForPayrollPeriodGateway printHoursForPayrollPeriodGateway = new PrintHoursForPayrollPeriodGateway();
            printHoursForPayrollPeriodGateway.ClearBeforeFill = false;

            foreach (ListItem lst in cbxlEmployee.Items)
            {
                if (lst.Selected)
                {
                    if (ddlCountry.SelectedValue == "-1")
                    {
                        if (ddlEmployeeType.SelectedValue != "Salaried")
                        {
                            if (ddlClient.SelectedValue == "-1")
                            {
                                printHoursForPayrollPeriodGateway.LoadByEmployeeTypeStartDateEndDateEmployeeIdProjectTimeState(employeeType, startDate, endDate, int.Parse(lst.Value), projectTimeState, false, personnelAgencySelected);
                            }
                            else
                            {
                                if (ddlProject.SelectedValue == "-1")
                                {
                                    printHoursForPayrollPeriodGateway.LoadByEmployeeTypeStartDateEndDateEmployeeIdProjectTimeStateClientId(employeeType, startDate, endDate, int.Parse(lst.Value), projectTimeState, clientId, false, personnelAgencySelected);
                                }
                                else
                                {
                                    printHoursForPayrollPeriodGateway.LoadByEmployeeTypeStartDateEndDateEmployeeIdProjectTimeStateClientIdProjectId(employeeType, startDate, endDate, int.Parse(lst.Value), projectTimeState, clientId, projectId, false, personnelAgencySelected);
                                }
                            }
                        }
                        else
                        {
                            if (ddlClient.SelectedValue == "-1")
                            {
                                printHoursForPayrollPeriodGateway.LoadBySalariedStartDateEndDateEmployeeIdProjectTimeState(startDate, endDate, int.Parse(lst.Value), projectTimeState, false);
                            }
                            else
                            {
                                if (ddlProject.SelectedValue == "-1")
                                {
                                    printHoursForPayrollPeriodGateway.LoadBySalariedStartDateEndDateEmployeeIdProjectTimeStateClientId(startDate, endDate, int.Parse(lst.Value), projectTimeState, clientId, false);
                                }
                                else
                                {
                                    printHoursForPayrollPeriodGateway.LoadBySalariedStartDateEndDateEmployeeIdProjectTimeStateClientIdProjectId(startDate, endDate, int.Parse(lst.Value), projectTimeState, clientId, projectId, false);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (ddlEmployeeType.SelectedValue != "Salaried")
                        {
                            if (ddlClient.SelectedValue == "-1")
                            {
                                printHoursForPayrollPeriodGateway.LoadByEmployeeTypeStartDateEndDateCountryIdEmployeeIdProjectTimeState(employeeType, startDate, endDate, int.Parse(ddlCountry.SelectedValue), int.Parse(lst.Value), projectTimeState, false, personnelAgencySelected);
                            }
                            else
                            {
                                if (ddlProject.SelectedValue == "-1")
                                {
                                    printHoursForPayrollPeriodGateway.LoadByEmployeeTypeStartDateEndDateCountryIdEmployeeIdProjectTimeStateClientId(employeeType, startDate, endDate, int.Parse(ddlCountry.SelectedValue), int.Parse(lst.Value), projectTimeState, clientId, false, personnelAgencySelected);
                                }
                                else
                                {
                                    printHoursForPayrollPeriodGateway.LoadByEmployeeTypeStartDateEndDateCountryIdEmployeeIdProjectTimeStateClientIdProjectId(employeeType, startDate, endDate, int.Parse(ddlCountry.SelectedValue), int.Parse(lst.Value), projectTimeState, clientId, projectId, false, personnelAgencySelected);
                                }
                            }
                        }
                        else
                        {
                            if (ddlClient.SelectedValue == "-1")
                            {
                                printHoursForPayrollPeriodGateway.LoadBySalariedStartDateEndDateCountryIdEmployeeIdProjectTimeState(startDate, endDate, int.Parse(ddlCountry.SelectedValue), int.Parse(lst.Value), projectTimeState, false);
                            }
                            else
                            {
                                if (ddlProject.SelectedValue == "-1")
                                {
                                    printHoursForPayrollPeriodGateway.LoadBySalariedStartDateEndDateCountryIdEmployeeIdProjectTimeStateClientId(startDate, endDate, int.Parse(ddlCountry.SelectedValue), int.Parse(lst.Value), projectTimeState, clientId, false);
                                }
                                else
                                {
                                    printHoursForPayrollPeriodGateway.LoadBySalariedStartDateEndDateCountryIdEmployeeIdProjectTimeStateClientIdProjectId(startDate, endDate, int.Parse(ddlCountry.SelectedValue), int.Parse(lst.Value), projectTimeState, clientId, projectId, false);
                                }
                            }
                        }
                    }
                }
            }

            printHoursForPayrollPeriodGateway.ClearBeforeFill = true;

            // ... set properties to master page
            master.Data = printHoursForPayrollPeriodGateway.Data;
            master.Table = printHoursForPayrollPeriodGateway.TableName;

            // Get report
            if (printHoursForPayrollPeriodGateway.Table.Rows.Count > 0)
            {
                if (master.Format == "pdf")
                {
                    master.Report = new LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime.PrintHoursForPayrollPeriodReportOld();
                }
                else
                {
                    master.Report = new LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime.PrintHoursForPayrollPeriodReportExportOld();
                }

                // ... set parameters to report
                if (master.Format == "pdf")
                {
                    // ... For report
                    // ... ... country
                    if (ddlCountry.SelectedValue == "2")
                    {
                        master.SetParameter("Country", "USA");
                    }
                    else
                    {
                        if (ddlCountry.SelectedValue == "1")
                        {
                            master.SetParameter("Country", "Canada");
                        }
                        else
                        {
                            master.SetParameter("Country", "All");
                        }
                    }

                    // ... ... team member
                    if (IsAllEmployeesSelected())
                    {
                        master.SetParameter("teamMember", "All");
                    }
                    else
                    {
                        string fullName = GetEmployeesSelected();

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
                    string user = loginGateway.GetLastName(loginId,companyId) + " " + loginGateway.GetFirstName(loginId, companyId);
                    master.SetParameter("User", user.Trim());

                    // ... ... client
                    if (ddlClient.SelectedValue == "-1")
                    {
                        master.SetParameter("Client", "All");
                    }
                    else
                    {
                        int currentClientId = Int32.Parse(ddlClient.SelectedValue);                        
                        CompaniesGateway companiesGateway = new CompaniesGateway();
                        companiesGateway.LoadByCompaniesId(currentClientId, companyId);
                        master.SetParameter("Client", companiesGateway.GetName(currentClientId));
                    }

                    // ... ... project
                    if (ddlProject.SelectedValue == "-1")
                    {
                        master.SetParameter("Project", "All");
                    }
                    else
                    {
                        int projectId2 = Int32.Parse(ddlProject.SelectedValue);
                        ProjectGateway projectGateway = new ProjectGateway();
                        projectGateway.LoadByProjectId(projectId2);
                        string project = projectGateway.GetName(projectId2);
                        master.SetParameter("Project", project);
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



        private bool IsAllEmployeesSelected()
        {
            foreach (ListItem lst in cbxlEmployee.Items)
            {
                if (lst.Selected)
                {
                    if (lst.Value == "-1") // for (All) option
                    {
                        return true;
                    }
                }
            }

            return false;
        }



        private string GetEmployeesSelected()
        {
            string employeesSelected = "";

            foreach (ListItem lst in cbxlEmployee.Items)
            {
                if (lst.Selected)
                {
                    employeesSelected += lst.Text + ", ";
                }
            }

            if (employeesSelected.Length > 2) { employeesSelected = employeesSelected.Substring(0, employeesSelected.Length - 2); }
            if (employeesSelected.Length > 37) { employeesSelected = employeesSelected.Substring(0, 34) + "..."; }

            return employeesSelected;
        }



    }
}