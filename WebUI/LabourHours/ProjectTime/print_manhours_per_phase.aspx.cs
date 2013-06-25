using System;
using LiquiForce.LFSLive.DA.LabourHours.ProjectTime;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.DA.RAF;
using LiquiForce.LFSLive.DA.Resources.Companies;

namespace LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime
{
    /// <summary>
    /// print_manhours_per_phase
    /// </summary>
    public partial class print_manhours_per_phase : System.Web.UI.Page
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

                // Tag page
                hdfCompanyId.Value = Convert.ToInt32(Session["companyID"]).ToString();

                // Initialize viewstate variables
                System.Configuration.AppSettingsReader appSettingReader = new System.Configuration.AppSettingsReader();
                ViewState["LHMode"] = appSettingReader.GetValue("LABOUR_HOURS_OPERATION_MODE", typeof(System.String)).ToString();

                // Databind
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
            master.Title = "KPI Report";

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



        protected void ddlPhase_SelectedIndexChanged(object sender, EventArgs e)
        {
            string work_ = "";

            if (ddlPhase.SelectedIndex > 0)
            {
                pnlMHCriterias.Visible = false;
                pnlFLLCriterias.Visible = false;
            }

            if (ddlPhase.SelectedItem.Text.Contains("Junction Lining"))
            {
                work_ = "Junction Lining";
            }
            else
            {
                if (ddlPhase.SelectedItem.Text.Contains("MH"))
                {
                    work_ = "MH Rehab";
                }
                else
                {
                    work_ = "Full Length";
                }
            }

            switch (work_)
            {
                case "Full Length":
                    pnlMHCriterias.Visible = false;
                    pnlFLLCriterias.Visible = true;
                    break;

                case "MH Rehab":
                    pnlMHCriterias.Visible = true;
                    pnlFLLCriterias.Visible = false;
                    break;
            }

            upnlMHCriterias.Update();
            upnlFLLCriterias.Update();
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
            if (ddlPhase.SelectedIndex > 0)
            {
                mReport1 master = (mReport1)this.Master;

                // Get Data
                string projectTimeState = (ddlProjectTimeState.SelectedValue == "(All)") ? "%" : ddlProjectTimeState.SelectedItem.Text;

                string confirmedSize1 = (ddlConfirmedSize.SelectedValue == "(All)") ? "%" : ddlConfirmedSize.SelectedValue;
                string confirmedSize2 = "%"; //By default
                switch (confirmedSize1)
                {
                    case "8":
                        confirmedSize1 = "8%";
                        confirmedSize2 = "200%";
                        break;
                    case "10":
                        confirmedSize1 = "10%";
                        confirmedSize2 = "250%";
                        break;
                    case "12":
                        confirmedSize1 = "12%";
                        confirmedSize2 = "300%";
                        break;
                    case "15":
                        confirmedSize1 = "15%";
                        confirmedSize2 = "375%";
                        break;
                    case "18":
                        confirmedSize1 = "18%";
                        confirmedSize2 = "450%";
                        break;
                    case "21":
                        confirmedSize1 = "21%";
                        confirmedSize2 = "525%";
                        break;
                    case "24":
                        confirmedSize1 = "24%";
                        confirmedSize2 = "600%";
                        break;
                    case "27":
                        confirmedSize1 = "27%";
                        confirmedSize2 = "675%";
                        break;
                    case "30":
                        confirmedSize1 = "30%";
                        confirmedSize2 = "750%";
                        break;
                }

                string accessType = (ddlAccessType.SelectedValue == "(All)") ? "%" : ddlAccessType.SelectedValue;
                DateTime startDate = DateTime.Parse(tkrdpStartDate.SelectedDate.Value.ToShortDateString());
                DateTime endDate = DateTime.Parse(tkrdpEndDate.SelectedDate.Value.ToShortDateString());
                string work_ = "(All)";

                if (ddlPhase.SelectedItem.Text.Contains("Junction Lining"))
                {
                    work_ = "Junction Lining";
                }
                else
                {
                    if (ddlPhase.SelectedItem.Text.Contains("MH"))
                    {
                        work_ = "MH Rehab";
                    }
                    else
                    {
                        if (ddlPhase.SelectedItem.Text.Contains("Rehab Assessment"))
                        {
                            work_ = "Rehab Assessment";
                        }
                        else
                        {
                            if (ddlPhase.SelectedItem.Text.Contains("Point Lining"))
                            {
                                work_ = "Point Lining";
                            }
                            else
                            {
                                work_ = "Full Length";
                            }
                        }
                    }
                }

                string function_ = ddlPhase.SelectedValue;
                int companyId = Int32.Parse(hdfCompanyId.Value);

                // Call Generate method according Type of work
                if (work_ == "Junction Lining")
                {
                    GenerateJL(master, projectTimeState, ref startDate, ref endDate, work_, function_);
                }
                else // FLL
                {
                    if (work_ == "Full Length")
                    {
                        GenerateFLL(master, projectTimeState, confirmedSize1, confirmedSize2, accessType, ref startDate, ref endDate, work_, ref function_, companyId);
                    }
                    else
                    {
                        // RA
                        if (work_ == "Rehab Assessment")
                        {
                            GenerateRA(master, projectTimeState, confirmedSize1, confirmedSize2, accessType, ref startDate, ref endDate, work_, ref function_, companyId);
                        }
                        else
                        {
                            // PL
                            if (work_ == "Point Lining")
                            {
                                GeneratePL(master, projectTimeState, confirmedSize1, confirmedSize2, accessType, ref startDate, ref endDate, work_, ref function_, companyId);
                            }
                            else
                            {
                                //MH
                                GenerateMH(master, projectTimeState, ref startDate, ref endDate, work_, function_, companyId);
                            }
                        }
                    }
                }
            }
            else
            {
                GenerateAll();
            }
        }



        private void GenerateAll()
        {
            // Get Data
            string accessType = (ddlAccessType.SelectedValue == "(All)") ? "%" : ddlAccessType.SelectedValue;
            DateTime startDate = DateTime.Parse(tkrdpStartDate.SelectedDate.Value.ToShortDateString());
            DateTime endDate = DateTime.Parse(tkrdpEndDate.SelectedDate.Value.ToShortDateString());
            string shape = "%"; if (ddlShape.SelectedIndex > 0) shape = ddlShape.SelectedValue;
            string location = "%"; if (ddlLocation.SelectedIndex > 0) location = ddlLocation.SelectedValue;
            int conditionRating = 1;
            string material = "%"; if (ddlMaterial.SelectedIndex > 0) material = ddlMaterial.SelectedItem.Text;
            string crew = "%"; if (ddlCrew.SelectedIndex > 0) crew = ddlCrew.SelectedValue;
            string projectTimeState = (ddlProjectTimeState.SelectedValue == "(All)") ? "%" : ddlProjectTimeState.SelectedItem.Text;
            int companyId = Int32.Parse(hdfCompanyId.Value);
            string confirmedSize1 = (ddlConfirmedSize.SelectedValue == "(All)") ? "%" : ddlConfirmedSize.SelectedValue;
            string confirmedSize2 = "%"; //By default
            switch (confirmedSize1)
            {
                case "8":
                    confirmedSize1 = "8%";
                    confirmedSize2 = "200%";
                    break;
                case "10":
                    confirmedSize1 = "10%";
                    confirmedSize2 = "250%";
                    break;
                case "12":
                    confirmedSize1 = "12%";
                    confirmedSize2 = "300%";
                    break;
                case "15":
                    confirmedSize1 = "15%";
                    confirmedSize2 = "375%";
                    break;
                case "18":
                    confirmedSize1 = "18%";
                    confirmedSize2 = "450%";
                    break;
                case "21":
                    confirmedSize1 = "21%";
                    confirmedSize2 = "525%";
                    break;
                case "24":
                    confirmedSize1 = "24%";
                    confirmedSize2 = "600%";
                    break;
                case "27":
                    confirmedSize1 = "27%";
                    confirmedSize2 = "675%";
                    break;
                case "30":
                    confirmedSize1 = "30%";
                    confirmedSize2 = "750%";
                    break;
            }
            //string work_ = "";
            //string function_ = "";

            int? countryId = null;

            if (ddlCountry.SelectedIndex > 0)
            {
                countryId = Convert.ToInt32(ddlCountry.SelectedValue);
            }

            mReport1 master = (mReport1)this.Master;
            PrintManhoursPerPhaseTDS printManhoursPerPhaseTDS = new PrintManhoursPerPhaseTDS(); 

            bool existData = true;

            // Get report
            if (existData)
            {
                LiquiForce.LFSLive.BL.LabourHours.ProjectTime.PrintManhoursPerPhaseGeneral printManhoursPerPhaseGeneral = new LiquiForce.LFSLive.BL.LabourHours.ProjectTime.PrintManhoursPerPhaseGeneral(printManhoursPerPhaseTDS);

                if (ddlClient.SelectedIndex == 0)
                {
                    if (ddlCountry.SelectedIndex == 0)
                    {
                        printManhoursPerPhaseGeneral.Load(companyId, startDate, endDate, projectTimeState, confirmedSize1, confirmedSize2, accessType, shape, conditionRating, location, material, crew);
                    }
                    else
                    {
                        printManhoursPerPhaseGeneral.LoadByCountryId(companyId, countryId.Value, startDate, endDate, projectTimeState, confirmedSize1, confirmedSize2, accessType, shape, conditionRating, location, material, crew);
                    }
                }
                else
                {
                    if (ddlProject.SelectedIndex == 0)
                    {
                        printManhoursPerPhaseGeneral.LoadByClientId(companyId, Convert.ToInt32(ddlClient.SelectedValue), startDate, endDate, projectTimeState, confirmedSize1, confirmedSize2, accessType, shape, conditionRating, location, material, crew);
                    }
                    else
                    {
                        printManhoursPerPhaseGeneral.LoadByProjectId(companyId, Convert.ToInt32(ddlProject.SelectedValue), startDate, endDate, projectTimeState, confirmedSize1, confirmedSize2, accessType, shape, conditionRating, location, material, crew);
                    }
                }

                // ... set properties to master page
                master.Data = printManhoursPerPhaseGeneral.Data;
                master.Table = printManhoursPerPhaseGeneral.TableName;

                if (master.Format == "pdf")
                {
                    master.Report = new LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime.PrintManhoursPerPhaseGeneralReport();

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
                        string clientName = ddlClient.SelectedItem.Text;
                        master.SetParameter("client", clientName);
                    }

                    // ... ... project
                    if (ddlProject.SelectedValue == "-1")
                    {
                        master.SetParameter("project", "All");
                    }
                    else
                    {
                        string project = ddlProject.SelectedItem.Text;
                        master.SetParameter("project", project);
                    }

                    // ... ... phase / function
                    master.SetParameter("phase", ddlPhase.SelectedItem.Text);

                    // ... ... Dates Range
                    master.SetParameter("dateFrom", tkrdpStartDate.SelectedDate.Value.ToShortDateString());
                    master.SetParameter("dateTo", tkrdpEndDate.SelectedDate.Value.ToShortDateString());

                    // ... ... MH Shape
                    if (ddlShape.SelectedValue == "(All)")
                    {
                        master.SetParameter("Shape", "All");
                    }
                    else
                    {
                        master.SetParameter("Shape", ddlShape.SelectedValue);
                    }

                    // ... ... Condition Rating
                    if (ddlConditioningRating.SelectedValue == "(All)")
                    {
                        master.SetParameter("ConditionRating", "All");
                    }
                    else
                    {
                        master.SetParameter("ConditionRating", ddlConditioningRating.SelectedValue);
                    }

                    // ... ... Location
                    if (ddlLocation.SelectedValue == "(All)")
                    {
                        master.SetParameter("Location", "All");
                    }
                    else
                    {
                        master.SetParameter("Location", ddlLocation.SelectedValue);
                    }

                    // ... ... Material
                    if (ddlMaterial.SelectedValue == "(All)")
                    {
                        master.SetParameter("Material", "All");
                    }
                    else
                    {
                        master.SetParameter("Material", ddlMaterial.SelectedItem.Text);
                    }

                    // ... ... Crew
                    if (ddlCrew.SelectedValue == "(All)")
                    {
                        master.SetParameter("Crew", "All");
                    }
                    else
                    {
                        master.SetParameter("Crew", ddlCrew.SelectedValue);
                    }

                    // ... ... Confirmed Size
                    if (ddlConfirmedSize.SelectedValue == "(All)")
                    {
                        master.SetParameter("ConfirmedSize", "All");
                    }
                    else
                    {
                        master.SetParameter("ConfirmedSize", ddlConfirmedSize.SelectedValue);
                    }

                    // ... ... Access Type
                    if (ddlAccessType.SelectedValue == "(All)")
                    {
                        master.SetParameter("AccessType", "All");
                    }
                    else
                    {
                        master.SetParameter("AccessType", ddlAccessType.SelectedValue);
                    }
                }
                else
                {
                    master.Report = new LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime.PrintManhoursPerPhaseGeneralReport();
                }
            }
        }



        private void GenerateJL(mReport1 master, string projectTimeState, ref DateTime startDate, ref DateTime endDate, string work_, string function_)
        {
            LiquiForce.LFSLive.BL.LabourHours.ProjectTime.PrintManhoursPerPhase printManhoursPerPhase = new LiquiForce.LFSLive.BL.LabourHours.ProjectTime.PrintManhoursPerPhase();

            int? countryId = null;

            if (ddlCountry.SelectedIndex > 0)
            {
                countryId = Convert.ToInt32(ddlCountry.SelectedValue);
            }

            if (ddlClient.SelectedValue == "-1")
            {
                printManhoursPerPhase.LoadByStartDateEndDateProjectTimeStateWorkFunction(countryId, startDate, endDate, projectTimeState, work_, function_);
            }
            else
            {
                if (ddlProject.SelectedValue == "-1")
                {
                    printManhoursPerPhase.LoadByCompaniesIdStartDateEndDateProjectTimeStateWorkFunction(int.Parse(ddlClient.SelectedValue), startDate, endDate, projectTimeState, work_, function_);
                }
                else
                {
                    printManhoursPerPhase.LoadByCompaniesIdProjectIdStartDateEndDateProjectTimeStateWorkFunction(int.Parse(ddlClient.SelectedValue), int.Parse(ddlProject.SelectedValue), startDate, endDate, projectTimeState, work_, function_);
                }
            }

            // ... set properties to master page
            master.Data = printManhoursPerPhase.Data;
            master.Table = printManhoursPerPhase.TableName;

            // Get report
            if (printManhoursPerPhase.Table.Rows.Count > 0)
            {
                if (master.Format == "pdf")
                {
                    switch (function_)
                    {
                        case "Install":
                            master.Report = new LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime.PrintManhoursPerPhaseReport();
                            break;

                        case "Prep from Main":
                            master.Report = new LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime.PrintManhoursPerPhaseReportJLPrepFromMain();
                            break;

                        case "Scoping":
                            master.Report = new LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime.PrintManhoursPerPhaseReportJLScoping();
                            break;
                    }
                }
                else
                {
                    switch (function_)
                    {
                        case "Install":
                            master.Report = new LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime.PrintManhoursPerPhaseReportExport();
                            break;

                        case "Prep from Main":
                            master.Report = new LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime.PrintManhoursPerPhaseReportJLPrepFromMainExport();
                            break;

                        case "Scoping":
                            master.Report = new LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime.PrintManhoursPerPhaseReportJLScopingExport();
                            break;
                    }
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

                    // ... ...  user
                    int loginId = Convert.ToInt32(Session["loginID"]);
                    int companyId = Convert.ToInt32(Session["companyID"]);

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
                        string clientName = ddlClient.SelectedItem.Text;
                        master.SetParameter("client", clientName);
                    }

                    // ... ... project
                    if (ddlProject.SelectedValue == "-1")
                    {
                        master.SetParameter("project", "All");
                    }
                    else
                    {
                        string project = ddlProject.SelectedItem.Text;
                        master.SetParameter("project", project);
                    }

                    // ... ... phase / function
                    if (ddlPhase.SelectedValue == "Scoping")
                    {
                        master.SetParameter("phase", "PreVideo & Locate (V1)");
                    }
                    else
                    {
                        master.SetParameter("phase", ddlPhase.SelectedValue);
                    }

                    // ... ... Dates Range
                    master.SetParameter("dateFrom", tkrdpStartDate.SelectedDate.Value.ToShortDateString());
                    master.SetParameter("dateTo", tkrdpEndDate.SelectedDate.Value.ToShortDateString());
                }
            }
        }



        private void GenerateMH(mReport1 master, string projectTimeState, ref DateTime startDate, ref DateTime endDate, string work_, string function_, int companyId)
        {
            LiquiForce.LFSLive.BL.LabourHours.ProjectTime.PrintManHoursPerPhaseMH printManhoursPerPhase = new LiquiForce.LFSLive.BL.LabourHours.ProjectTime.PrintManHoursPerPhaseMH();

            string shape = "%"; if (ddlShape.SelectedIndex > 0) shape = ddlShape.SelectedValue;
            string location = "%"; if (ddlLocation.SelectedIndex > 0) location = ddlLocation.SelectedValue;
            int conditionRating = 1;
            string material = "%"; if (ddlMaterial.SelectedIndex > 0) material = ddlMaterial.SelectedItem.Text;
            string crew = "%"; if (ddlCrew.SelectedIndex > 0) crew = ddlCrew.SelectedValue;

            int? countryId = null;

            if (ddlCountry.SelectedIndex > 0)
            {
                countryId = Convert.ToInt32(ddlCountry.SelectedValue);
            }

            if (ddlClient.SelectedValue == "-1")
            {
                // ... For specific type of work and specific function
                printManhoursPerPhase.LoadByStartDateEndDateProjectTimeStateWorkFunction(countryId, startDate, endDate, projectTimeState, work_, function_, companyId, shape, conditionRating, location, material, crew);
            }
            else
            {
                if (ddlProject.SelectedValue == "-1")
                {
                    // ... For specific type of work and specific function
                    printManhoursPerPhase.LoadByCompaniesIdStartDateEndDateProjectTimeStateWorkFunction(int.Parse(ddlClient.SelectedValue), startDate, endDate, projectTimeState, work_, function_, companyId, shape, conditionRating, location, material, crew);
                }
                else
                {
                    // ... For specific type of work and specific function
                    printManhoursPerPhase.LoadByCompaniesIdProjectIdStartDateEndDateProjectTimeStateWorkFunction(int.Parse(ddlClient.SelectedValue), int.Parse(ddlProject.SelectedValue), startDate, endDate, projectTimeState, work_, function_, companyId, shape, conditionRating, location, material, crew);
                }
            }

            // ... set properties to master page
            master.Data = printManhoursPerPhase.Data;
            master.Table = printManhoursPerPhase.TableName;

            // Get report
            if (printManhoursPerPhase.Table.Rows.Count > 0)
            {
                if (master.Format == "pdf")
                {
                    switch (function_)
                    {
                        case "Prep":
                            master.Report = new LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime.PrintManhoursPerPhaseReportMHGeneral();
                            break;
                        case "Spray":
                            master.Report = new LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime.PrintManhoursPerPhaseReportMHGeneral();
                            break;
                    }
                }
                else
                {
                    switch (function_)
                    {
                        case "Prep":
                            master.Report = new LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime.PrintManhoursPerPhaseReportMHGeneralExport();
                            break;
                        case "Spray":
                            master.Report = new LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime.PrintManhoursPerPhaseReportMHGeneralExport();
                            break;
                    }
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
                        CompaniesGateway companiesGateway = new CompaniesGateway();
                        companiesGateway.LoadByCompaniesId(Int32.Parse(ddlClient.SelectedValue), companyId);
                        string clientName = companiesGateway.GetName(Int32.Parse(ddlClient.SelectedValue));
                        master.SetParameter("client", clientName);
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

                    // ... ... phase / function
                    if (ddlPhase.SelectedValue == "(All)")
                    {
                        master.SetParameter("phase", "All");
                    }
                    else
                    {
                        master.SetParameter("phase", ddlPhase.SelectedItem.Text);
                    }

                    // ... ... MH Shape
                    if (ddlShape.SelectedValue == "(All)")
                    {
                        master.SetParameter("Shape", "All");
                    }
                    else
                    {
                        master.SetParameter("Shape", ddlShape.SelectedValue);
                    }

                    // ... ... Condition Rating
                    if (ddlConditioningRating.SelectedValue == "-1")
                    {
                        master.SetParameter("ConditionRating", "All");
                    }
                    else
                    {
                        master.SetParameter("ConditionRating", ddlConditioningRating.SelectedValue);
                    }

                    // ... ... Location
                    if (ddlLocation.SelectedValue == "(All)")
                    {
                        master.SetParameter("Location", "All");
                    }
                    else
                    {
                        master.SetParameter("Location", ddlLocation.SelectedValue);
                    }

                    // ... ... Material
                    if (ddlMaterial.SelectedValue == "(All)")
                    {
                        master.SetParameter("Material", "All");
                    }
                    else
                    {
                        master.SetParameter("Material", ddlMaterial.SelectedItem.Text);
                    }

                    // ... ... Crew
                    if (ddlCrew.SelectedValue == "(All)")
                    {
                        master.SetParameter("Crew", "All");
                    }
                    else
                    {
                        master.SetParameter("Crew", ddlCrew.SelectedValue);
                    }

                    master.SetParameter("dateFrom", tkrdpStartDate.SelectedDate.Value.ToShortDateString());
                    master.SetParameter("dateTo", tkrdpEndDate.SelectedDate.Value.ToShortDateString());
                }
            }
        }



        private void GenerateFLL(mReport1 master, string projectTimeState, string confirmedSize1, string confirmedSize2, string accessType, ref DateTime startDate, ref DateTime endDate, string work_, ref string function_, int companyId)
        {
            if (ddlPhase.SelectedValue == "FInstall")
            {
                function_ = "Install";
            }

            int? countryId = null;

            if (ddlCountry.SelectedIndex > 0)
            {
                countryId = Convert.ToInt32(ddlCountry.SelectedValue);
            }

            LiquiForce.LFSLive.BL.LabourHours.ProjectTime.PrintManhoursPerPhaseFLL printManhoursPerPhase = new LiquiForce.LFSLive.BL.LabourHours.ProjectTime.PrintManhoursPerPhaseFLL();

            if (ddlClient.SelectedValue == "-1")
            {
                // ... For specific type of work and specific function
                printManhoursPerPhase.LoadByStartDateEndDateProjectTimeStateWorkFunction(countryId, startDate, endDate, projectTimeState, work_, function_, companyId, confirmedSize1, confirmedSize2, accessType);
            }
            else
            {
                if (ddlProject.SelectedValue == "-1")
                {
                    // ... For specific type of work and specific function
                    printManhoursPerPhase.LoadByCompaniesIdStartDateEndDateProjectTimeStateWorkFunction(int.Parse(ddlClient.SelectedValue), startDate, endDate, projectTimeState, work_, function_, companyId, confirmedSize1, confirmedSize2, accessType);
                }
                else
                {
                    // ... For specific type of work and specific function
                    printManhoursPerPhase.LoadByCompaniesIdProjectIdStartDateEndDateProjectTimeStateWorkFunction(int.Parse(ddlClient.SelectedValue), int.Parse(ddlProject.SelectedValue), startDate, endDate, projectTimeState, work_, function_, companyId, confirmedSize1, confirmedSize2, accessType);
                }
            }

            // ... set properties to master page
            master.Data = printManhoursPerPhase.Data;
            master.Table = printManhoursPerPhase.TableName;

            // Get report
            if (printManhoursPerPhase.Table.Rows.Count > 0)
            {
                if (master.Format == "pdf")
                {
                    switch (function_)
                    {
                        case "Install":
                            master.Report = new LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime.PrintManhoursPerPhaseReportFLLInstall();
                            break;
                        case "Prep & Measure":
                            master.Report = new LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime.PrintManhoursPerPhaseReportFLLPrepMeasure();
                            break;
                        case "Reinstate & Post Video":
                            master.Report = new LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime.PrintManhoursPerPhaseReportFLLReinstatePostVideo();
                            break;
                    }
                }
                else
                {
                    switch (function_)
                    {
                        case "Install":
                            master.Report = new LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime.PrintManhoursPerPhaseReportFLLInstallExport();
                            break;
                        case "Prep & Measure":
                            master.Report = new LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime.PrintManhoursPerPhaseReportFLLPrepMeasureExport();
                            break;
                        case "Reinstate & Post Video":
                            master.Report = new LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime.PrintManhoursPerPhaseReportFLLReinstatePostVideoExport();
                            break;
                    }
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
                        CompaniesGateway companiesGateway = new CompaniesGateway();
                        companiesGateway.LoadByCompaniesId(Int32.Parse(ddlClient.SelectedValue), companyId);
                        string clientName = companiesGateway.GetName(Int32.Parse(ddlClient.SelectedValue));
                        master.SetParameter("client", clientName);
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

                    // ... ... phase / function
                    if (ddlPhase.SelectedValue == "(All)")
                    {
                        master.SetParameter("phase", "All");
                    }
                    else
                    {
                        master.SetParameter("phase", ddlPhase.SelectedItem.Text);
                    }

                    // ... ... Confirmed Size
                    if (ddlConfirmedSize.SelectedValue == "(All)")
                    {
                        master.SetParameter("ConfirmedSize", "All");
                    }
                    else
                    {
                        master.SetParameter("ConfirmedSize", ddlConfirmedSize.SelectedValue);
                    }

                    // ... ... Access Type
                    if (ddlAccessType.SelectedValue == "(All)")
                    {
                        master.SetParameter("AccessType", "All");
                    }
                    else
                    {
                        master.SetParameter("AccessType", ddlAccessType.SelectedValue);
                    }

                    master.SetParameter("dateFrom", tkrdpStartDate.SelectedDate.Value.ToShortDateString());
                    master.SetParameter("dateTo", tkrdpEndDate.SelectedDate.Value.ToShortDateString());
                }
            }
        }



        private void GenerateRA(mReport1 master, string projectTimeState, string confirmedSize1, string confirmedSize2, string accessType, ref DateTime startDate, ref DateTime endDate, string work_, ref string function_, int companyId)
        {
            LiquiForce.LFSLive.BL.LabourHours.ProjectTime.PrintManHoursPerPhaseRA printManhoursPerPhase = new LiquiForce.LFSLive.BL.LabourHours.ProjectTime.PrintManHoursPerPhaseRA();

            int? countryId = null;

            if (ddlCountry.SelectedIndex > 0)
            {
                countryId = Convert.ToInt32(ddlCountry.SelectedValue);
            }

            if (ddlClient.SelectedValue == "-1")
            {
                // ... For specific type of work and specific function
                printManhoursPerPhase.LoadByStartDateEndDateProjectTimeStateWorkFunction(countryId, startDate, endDate, projectTimeState, work_, function_, companyId, confirmedSize1, confirmedSize2, accessType);
            }
            else
            {
                if (ddlProject.SelectedValue == "-1")
                {
                    // ... For specific type of work and specific function
                    printManhoursPerPhase.LoadByCompaniesIdStartDateEndDateProjectTimeStateWorkFunction(int.Parse(ddlClient.SelectedValue), startDate, endDate, projectTimeState, work_, function_, companyId, confirmedSize1, confirmedSize2, accessType);
                }
                else
                {
                    // ... For specific type of work and specific function
                    printManhoursPerPhase.LoadByCompaniesIdProjectIdStartDateEndDateProjectTimeStateWorkFunction(int.Parse(ddlClient.SelectedValue), int.Parse(ddlProject.SelectedValue), startDate, endDate, projectTimeState, work_, function_, companyId, confirmedSize1, confirmedSize2, accessType);
                }
            }

            // ... set properties to master page
            master.Data = printManhoursPerPhase.Data;
            master.Table = printManhoursPerPhase.TableName;

            // Get report
            if (printManhoursPerPhase.Table.Rows.Count > 0)
            {
                if (master.Format == "pdf")
                {
                    switch (function_)
                    {
                        case "Flush Video and Reaming":
                            master.Report = new LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime.PrintManhoursPerPhaseReportRAPreFlush();
                            break;
                        //case "Pre-Video":
                        //    master.Report = new LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime.PrintManhoursPerPhaseReportRAPreVideo();
                        //    break;
                    }
                }
                else
                {
                    switch (function_)
                    {
                        case "Flush Video and Reaming":
                            master.Report = new LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime.PrintManhoursPerPhaseReportRAPreFlushExport();
                            break;
                        //case "Pre-Video":
                        //    master.Report = new LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime.PrintManhoursPerPhaseReportRAPreVideoExport();
                        //    break;
                    }
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

                    // ... ... phase / function
                    if (ddlPhase.SelectedValue == "(All)")
                    {
                        master.SetParameter("phase", "All");
                    }
                    else
                    {
                        master.SetParameter("phase", ddlPhase.SelectedItem.Text);
                    }

                    // ... ... Confirmed Size
                    if (ddlConfirmedSize.SelectedValue == "(All)")
                    {
                        master.SetParameter("ConfirmedSize", "All");
                    }
                    else
                    {
                        master.SetParameter("ConfirmedSize", ddlConfirmedSize.SelectedValue);
                    }

                    // ... ... Access Type
                    if (ddlAccessType.SelectedValue == "(All)")
                    {
                        master.SetParameter("AccessType", "All");
                    }
                    else
                    {
                        master.SetParameter("AccessType", ddlAccessType.SelectedValue);
                    }

                    master.SetParameter("dateFrom", tkrdpStartDate.SelectedDate.Value.ToShortDateString());
                    master.SetParameter("dateTo", tkrdpEndDate.SelectedDate.Value.ToShortDateString());
                }
            }
        }



        private void GeneratePL(mReport1 master, string projectTimeState, string confirmedSize1, string confirmedSize2, string accessType, ref DateTime startDate, ref DateTime endDate, string work_, ref string function_, int companyId)
        {
            if (ddlPhase.SelectedValue == "PLInstall")
            {
                function_ = "Install";
            }

            if (ddlPhase.SelectedValue == "PLPrep")
            {
                function_ = "Prep";
            }

            int? countryId = null;

            if (ddlCountry.SelectedIndex > 0)
            {
                countryId = Convert.ToInt32(ddlCountry.SelectedValue);
            }

            LiquiForce.LFSLive.BL.LabourHours.ProjectTime.PrintManHoursPerPhasePL printManhoursPerPhase = new LiquiForce.LFSLive.BL.LabourHours.ProjectTime.PrintManHoursPerPhasePL();

            if (ddlClient.SelectedValue == "-1")
            {
                // ... For specific type of work and specific function
                printManhoursPerPhase.LoadByStartDateEndDateProjectTimeStateWorkFunction(countryId, startDate, endDate, projectTimeState, work_, function_, companyId, confirmedSize1, confirmedSize2, accessType);
            }
            else
            {
                if (ddlProject.SelectedValue == "-1")
                {
                    // ... For specific type of work and specific function
                    printManhoursPerPhase.LoadByCompaniesIdStartDateEndDateProjectTimeStateWorkFunction(int.Parse(ddlClient.SelectedValue), startDate, endDate, projectTimeState, work_, function_, companyId, confirmedSize1, confirmedSize2, accessType);
                }
                else
                {
                    // ... For specific type of work and specific function
                    printManhoursPerPhase.LoadByCompaniesIdProjectIdStartDateEndDateProjectTimeStateWorkFunction(int.Parse(ddlClient.SelectedValue), int.Parse(ddlProject.SelectedValue), startDate, endDate, projectTimeState, work_, function_, companyId, confirmedSize1, confirmedSize2, accessType);
                }
            }

            // ... set properties to master page
            master.Data = printManhoursPerPhase.Data;
            master.Table = printManhoursPerPhase.TableName;

            // Get report
            if (printManhoursPerPhase.Table.Rows.Count > 0)
            {
                if (master.Format == "pdf")
                {
                    switch (function_)
                    {
                        case "Install":
                            master.Report = new LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime.PrintManhoursPerPhaseReportPLLInstall();
                            break;
                        case "Prep":
                            master.Report = new LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime.PrintManhoursPerPhaseReportPLLPrep();
                            break;
                        case "Reinstate":
                            master.Report = new LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime.PrintManhoursPerPhaseReportPLLReinstate();
                            break;
                    }
                }
                else
                {
                    switch (function_)
                    {
                        case "Install":
                            master.Report = new LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime.PrintManhoursPerPhaseReportPLLInstall();
                            break;
                        case "Prep":
                            master.Report = new LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime.PrintManhoursPerPhaseReportPLLPrep();
                            break;
                        case "Reinstate":
                            master.Report = new LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime.PrintManhoursPerPhaseReportPLLReinstate();
                            break;
                    }
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
                        CompaniesGateway companiesGateway = new CompaniesGateway();
                        companiesGateway.LoadByCompaniesId(Int32.Parse(ddlClient.SelectedValue), companyId);
                        string clientName = companiesGateway.GetName(Int32.Parse(ddlClient.SelectedValue));
                        master.SetParameter("client", clientName);
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

                    // ... ... phase / function
                    if (ddlPhase.SelectedValue == "(All)")
                    {
                        master.SetParameter("phase", "All");
                    }
                    else
                    {
                        master.SetParameter("phase", ddlPhase.SelectedItem.Text);
                    }

                    master.SetParameter("dateFrom", tkrdpStartDate.SelectedDate.Value.ToShortDateString());
                    master.SetParameter("dateTo", tkrdpEndDate.SelectedDate.Value.ToShortDateString());
                }
            }
        }



    }
}