using System;
using LiquiForce.LFSLive.DA.Resources.Companies;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.DA.LabourHours.ProjectTime;
using LiquiForce.LFSLive.DA.RAF;

namespace LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime
{
    /// <summary>
    /// print_hours_for_project
    /// </summary>
    public partial class print_hours_for_project : System.Web.UI.Page
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

                // Tag Page
                hdfCompanyId.Value = Session["companyID"].ToString();

                // Initialize viewstate variables
                System.Configuration.AppSettingsReader appSettingReader = new System.Configuration.AppSettingsReader();
                ViewState["LHMode"] = appSettingReader.GetValue("LABOUR_HOURS_OPERATION_MODE", typeof(System.String)).ToString();

                // DataBind
                ddlClient.DataBind();
                ddlProject.DataBind();

                // Prepare initial data 
                ddlProjectTimeState.SelectedValue = "Approved";
                ddlClient.SelectedIndex = 0;
                ddlProject.SelectedIndex = 0;
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
            master.Title = "Print Hours For Project Report";

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
        // AUXILIAR EVENTS
        //

        protected void ddlClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            odsProject.SelectParameters.RemoveAt(2);
            odsProject.SelectParameters.Add("ClientId", ddlClient.SelectedValue);
            odsProject.Select();
            ddlProject.SelectedIndex = 0;
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
            DateTime startDate = DateTime.Parse(tkrdpStartDate.SelectedDate.Value.ToShortDateString());
            DateTime endDate = DateTime.Parse(tkrdpEndDate.SelectedDate.Value.ToShortDateString());
            int companyId = Int32.Parse(hdfCompanyId.Value);

            PrintHoursForProjectGateway printHoursForProjectGateway = new PrintHoursForProjectGateway();
            if (ddlEmployeeType.SelectedValue == "(All)")
            {
                if (ddlClient.SelectedValue == "-1")
                {
                    printHoursForProjectGateway.LoadByStartDateEndDateProjectTimeState(startDate, endDate, projectTimeState, companyId);
                }
                else
                {
                    if (ddlProject.SelectedValue == "-1")
                    {
                        printHoursForProjectGateway.LoadByCompaniesIdStartDateEndDateProjectTimeState(int.Parse(ddlClient.SelectedValue), startDate, endDate, projectTimeState, companyId);
                    }
                    else
                    {
                        printHoursForProjectGateway.LoadByCompaniesIdProjectIdStartDateEndDateProjectTimeState(int.Parse(ddlClient.SelectedValue), int.Parse(ddlProject.SelectedValue), startDate, endDate, projectTimeState, companyId);
                    }
                }
            }
            else
            {
                string teamMemberType = ddlEmployeeType.SelectedValue;
                if (ddlClient.SelectedValue == "-1")
                {
                    printHoursForProjectGateway.LoadByStartDateEndDateProjectTimeStateTeamMemberType(startDate, endDate, projectTimeState, teamMemberType, companyId);
                }
                else
                {
                    if (ddlProject.SelectedValue == "-1")
                    {
                        printHoursForProjectGateway.LoadByCompaniesIdStartDateEndDateProjectTimeStateTeamMemberType(Int32.Parse(ddlClient.SelectedValue), startDate, endDate, projectTimeState, teamMemberType, companyId);
                    }
                    else
                    {
                        printHoursForProjectGateway.LoadByCompaniesIdProjectIdStartDateEndDateProjectTimeStateTeamMemberType(Int32.Parse(ddlClient.SelectedValue), int.Parse(ddlProject.SelectedValue), startDate, endDate, projectTimeState, teamMemberType, companyId);
                    }
                }
            }

            // ... set properties to master page
            master.Data = printHoursForProjectGateway.Data;
            master.Table = printHoursForProjectGateway.TableName;

            // Get report
            if (printHoursForProjectGateway.Table.Rows.Count > 0)
            {
                if (master.Format == "pdf")
                {
                    master.Report = new LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime.PrintHoursForProjectReport();
                }
                else
                {
                    master.Report = new LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime.PrintHoursForProjectReportExport();
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

                    LoginGateway loginGateway = new LoginGateway();
                    loginGateway.LoadByLoginId(loginId, companyId);
                    string user = loginGateway.GetLastName(loginId, companyId) + " " + loginGateway.GetFirstName(loginId, companyId);
                    master.SetParameter("User", user.Trim());

                    // ... ... client
                    if (ddlClient.SelectedValue == "-1")
                    {
                        master.SetParameter("client", "All");
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
                        master.SetParameter("project", "All");
                    }
                    else
                    {
                        int projectId2 = Int32.Parse(ddlProject.SelectedValue);
                        ProjectGateway projectGateway = new ProjectGateway();
                        projectGateway.LoadByProjectId(projectId2);
                        string project = projectGateway.GetName(projectId2);
                        master.SetParameter("project", project);
                    }

                    master.SetParameter("dateFrom", tkrdpStartDate.SelectedDate.Value.ToShortDateString());
                    master.SetParameter("dateTo", tkrdpEndDate.SelectedDate.Value.ToShortDateString());
                }
                else
                {
                    master.SetParameter("startDate", tkrdpStartDate.SelectedDate.Value.ToShortDateString());
                    master.SetParameter("endDate", tkrdpEndDate.SelectedDate.Value.ToShortDateString());
                }
            }
        }



    }
}