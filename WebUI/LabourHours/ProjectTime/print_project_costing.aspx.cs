using System;
using System.Data;
using LiquiForce.LFSLive.DA.Resources.Companies;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.BL.LabourHours.ProjectTime;
using LiquiForce.LFSLive.DA.RAF;

namespace LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime
{
    /// <summary>
    /// print_project_costing
    /// </summary>
    public partial class print_project_costing : System.Web.UI.Page
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

                // Tag page
                hdfCompanyId.Value = Convert.ToInt32(Session["companyID"]).ToString();

                // Databind
                ddlClient.DataBind();
                ddlProject.DataBind();

                // Prepare initial data 
                ddlProjectTimeState.SelectedValue = "(All)";
                ddlClient.SelectedIndex = 0;
                ddlProject.SelectedIndex = 0;
                tkrdpStartDate.SelectedDate = DateTime.Now;
                tkrdpEndDate.SelectedDate = DateTime.Now;

                ProjectTimeWorkList projectTimeWorkList = new ProjectTimeWorkList(new DataSet());
                projectTimeWorkList.LoadAndAddItem("(All)");
                ddlTypeOfWork.DataSource = projectTimeWorkList.Table;
                ddlTypeOfWork.DataValueField = "Work_";
                ddlTypeOfWork.DataTextField = "Work_";
                ddlTypeOfWork.DataBind();
                ddlTypeOfWork.SelectedIndex = 0;

                ProjectTimeWorkFunctionList projectTimeWorkFunctionList = new ProjectTimeWorkFunctionList(new DataSet());
                projectTimeWorkFunctionList.LoadAndAddItem("(All)", "-1");
                ddlFunction.DataSource = projectTimeWorkFunctionList.Table;
                ddlFunction.DataValueField = "Function_";
                ddlFunction.DataTextField = "Function_";
                ddlFunction.DataBind();
                ddlFunction.SelectedIndex = 0;

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
            master.Title = "Print Project Costing Report";

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



        protected void ddlTypeOfWork_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProjectTimeWorkFunctionList projectTimeWorkFunctionList = new ProjectTimeWorkFunctionList();
            projectTimeWorkFunctionList.LoadAndAddItem("(All)", ddlTypeOfWork.SelectedValue);
            ddlFunction.DataSource = projectTimeWorkFunctionList.Table;
            ddlFunction.DataValueField = "Function_";
            ddlFunction.DataTextField = "Function_";
            ddlFunction.DataBind();
            ddlFunction.SelectedIndex = 0;
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
            string work_ = "all"; if (ddlTypeOfWork.SelectedValue != "(All)") work_ = ddlTypeOfWork.SelectedValue;
            string function_ = "all"; if (ddlFunction.SelectedValue != "(All)") function_ = ddlFunction.SelectedValue;
            int companyId = Int32.Parse(hdfCompanyId.Value);

            LiquiForce.LFSLive.BL.LabourHours.ProjectTime.PrintProjectCosting printProjectCosting = new LiquiForce.LFSLive.BL.LabourHours.ProjectTime.PrintProjectCosting();

            if (ddlClient.SelectedValue == "-1")
            {
                if (ddlTypeOfWork.SelectedValue == "(All)")
                {
                    // ... ... For all types of work and all functions
                    printProjectCosting.LoadByStartDateEndDateProjectTimeState(startDate, endDate, projectTimeState, companyId);
                }
                else
                {
                    if (ddlFunction.SelectedValue == "(All)")
                    {
                        // ... ... For specific type of work and all functions
                        printProjectCosting.LoadByStartDateEndDateProjectTimeStateWork(startDate, endDate, projectTimeState, work_, companyId);
                    }
                    else
                    {
                        // ... ... For specific type of work and specific function
                        printProjectCosting.LoadByStartDateEndDateProjectTimeStateWorkFunction(startDate, endDate, projectTimeState, work_, function_, companyId);
                    }
                }
            }
            else
            {
                if (ddlProject.SelectedValue == "-1")
                {
                    if (ddlTypeOfWork.SelectedValue == "(All)")
                    {
                        // ... ... For all types of work and all functions
                        printProjectCosting.LoadByCompaniesIdStartDateEndDateProjectTimeState(int.Parse(ddlClient.SelectedValue), startDate, endDate, projectTimeState, companyId);
                    }
                    else
                    {
                        if (ddlFunction.SelectedValue == "(All)")
                        {
                            // ... ... For specific type of work and all functions
                            printProjectCosting.LoadByCompaniesIdStartDateEndDateProjectTimeStateWork(int.Parse(ddlClient.SelectedValue), startDate, endDate, projectTimeState, work_, companyId);
                        }
                        else
                        {
                            // ... ... For specific type of work and specific function
                            printProjectCosting.LoadByCompaniesIdStartDateEndDateProjectTimeStateWorkFunction(int.Parse(ddlClient.SelectedValue), startDate, endDate, projectTimeState, work_, function_, companyId);
                        }
                    }
                }
                else
                {
                    if (ddlTypeOfWork.SelectedValue == "(All)")
                    {
                        // ... ... For all types of work and all functions
                        printProjectCosting.LoadByCompaniesIdProjectIdStartDateEndDateProjectTimeState(int.Parse(ddlClient.SelectedValue), int.Parse(ddlProject.SelectedValue), startDate, endDate, projectTimeState, companyId);
                    }
                    else
                    {
                        if (ddlFunction.SelectedValue == "(All)")
                        {
                            // ... ... For specific type of work and all functions
                            printProjectCosting.LoadByCompaniesIdProjectIdStartDateEndDateProjectTimeStateWork(int.Parse(ddlClient.SelectedValue), int.Parse(ddlProject.SelectedValue), startDate, endDate, projectTimeState, work_, companyId);
                        }
                        else
                        {
                            // ... ... For specific type of work and specific function
                            printProjectCosting.LoadByCompaniesIdProjectIdStartDateEndDateProjectTimeStateWorkFunction(int.Parse(ddlClient.SelectedValue), int.Parse(ddlProject.SelectedValue), startDate, endDate, projectTimeState, work_, function_, companyId);
                        }
                    }
                }
            }

            LiquiForce.LFSLive.DA.LabourHours.ProjectTime.PrintProjectCostingGateway printProjectCostingGateway = new LiquiForce.LFSLive.DA.LabourHours.ProjectTime.PrintProjectCostingGateway(printProjectCosting.Data);

            // ... set properties to master page
            master.Data = printProjectCostingGateway.Data;
            master.Table = printProjectCostingGateway.TableName;

            // Get report
            if (printProjectCostingGateway.Table.Rows.Count > 0)
            {
                if (master.Format == "pdf")
                {
                    master.Report = new LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime.PrintProjectCostingReport();
                }
                else
                {
                    master.Report = new LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime.PrintProjectCostingReportExport();
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

                    // ... ... type of work
                    if (ddlTypeOfWork.SelectedValue == "(All)")
                    {
                        master.SetParameter("typeOfWork", "All");
                    }
                    else
                    {
                        master.SetParameter("typeOfWork", ddlTypeOfWork.SelectedValue);
                    }

                    // ... ... function
                    if (ddlFunction.SelectedValue == "(All)")
                    {
                        master.SetParameter("function", "All");
                    }
                    else
                    {
                        master.SetParameter("function", ddlFunction.SelectedValue);
                    }

                    // ... ... Date
                    master.SetParameter("dateFrom", tkrdpStartDate.SelectedDate.Value.ToShortDateString());
                    master.SetParameter("dateTo", tkrdpEndDate.SelectedDate.Value.ToShortDateString());
                }
                else
                {
                    // ... ... Date
                    master.SetParameter("startDate", tkrdpStartDate.SelectedDate.Value.ToShortDateString());
                    master.SetParameter("endDate", tkrdpEndDate.SelectedDate.Value.ToShortDateString());
                }
            }
        }



    }
}