using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.DA.Resources.Companies;
using LiquiForce.LFSLive.DA.RAF;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.BL.Projects.Projects;
using LiquiForce.LFSLive.BL.Resources.Companies;

namespace LiquiForce.LFSLive.WebUI.Projects.Projects
{   
    /// <summary>
    /// production_report
    /// </summary>
    public partial class production_report : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // EVENTS
        //

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Security check
                if (!Convert.ToBoolean(Session["sgLFS_PROJECTS_COSTINGSHEETS_ADMIN"]))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Tag page
                hdfCompanyId.Value = Convert.ToInt32(Session["companyID"]).ToString();
                
                // Databind
                // Prepare initial data 
                int companyId = Int32.Parse(hdfCompanyId.Value);
                CompaniesList companiesList = new CompaniesList();
                companiesList.LoadAndAddItem(-1, "(All)", companyId);
                ddlClient.DataSource = companiesList.Table;
                ddlClient.DataValueField = "COMPANIES_ID";
                ddlClient.DataTextField = "Name";
                ddlClient.DataBind();

                if (Request.QueryString["client_id"] != null)
                {
                    ddlClient.SelectedValue = Request.QueryString["client_id"];

                    // ... for project
                    ProjectList projectList = new ProjectList();
                    projectList.LoadProjectsAndAddItem(-1, "(All)", int.Parse(ddlClient.SelectedValue));
                    ddlProject.DataSource = projectList.Table;
                    ddlProject.DataValueField = "ProjectID";
                    ddlProject.DataTextField = "Name";
                    ddlProject.DataBind();
                    ddlProject.SelectedValue = Request.QueryString["project_id"];
                }
                else
                {
                    ddlClient.SelectedValue = "-1";

                    // ... for project
                    ProjectList projectList = new ProjectList();
                    projectList.LoadProjectsAndAddItem(-1, "(All)", -1);
                    ddlProject.DataSource = projectList.Table;
                    ddlProject.DataValueField = "ProjectID";
                    ddlProject.DataTextField = "Name";
                    ddlProject.DataBind();
                    ddlProject.SelectedValue = Request.QueryString["project_id"];
                }

                // Prepare initial data 
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
            master.Title = "Production Report";

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
            ProjectList projectList = new ProjectList();
            projectList.LoadProjectsAndAddItem(-1, "(All)", int.Parse(ddlClient.SelectedValue));
            ddlProject.DataSource = projectList.Table;
            ddlProject.DataValueField = "ProjectID";
            ddlProject.DataTextField = "Name";
            ddlProject.DataBind();
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
            DateTime startDate = DateTime.Parse(tkrdpStartDate.SelectedDate.Value.ToShortDateString());
            DateTime endDate = DateTime.Parse(tkrdpEndDate.SelectedDate.Value.ToShortDateString());
            int companyId = Int32.Parse(hdfCompanyId.Value);
            LiquiForce.LFSLive.BL.Projects.Projects.ProductionReport productionReport = new LiquiForce.LFSLive.BL.Projects.Projects.ProductionReport();

            if (ddlCountry.SelectedValue == "(All)")
            {
                if (ddlClient.SelectedValue == "-1")
                {
                    productionReport.LoadByStartDateEndDate(startDate, endDate, companyId);
                }
                else
                {
                    int clientId = int.Parse(ddlClient.SelectedValue);

                    if (ddlProject.SelectedValue == "-1")
                    {
                        productionReport.LoadByClientIdStartDateEndDate(clientId, startDate, endDate, companyId);
                    }
                    else
                    {
                        int projectId = int.Parse(ddlProject.SelectedValue);
                        productionReport.LoadByClientIdProjectIdStartDateEndDate(clientId, projectId, startDate, endDate, companyId);
                    }
                }
            }
            else
            {
                int country = Int32.Parse(ddlCountry.SelectedValue);

                if (ddlClient.SelectedValue == "-1")
                {
                    productionReport.LoadByCountryIdStartDateEndDate(country, startDate, endDate, companyId);
                }
                else
                {
                    int clientId = int.Parse(ddlClient.SelectedValue);

                    if (ddlProject.SelectedValue == "-1")
                    {
                        productionReport.LoadByCountryIdClientIdStartDateEndDate(country, clientId, startDate, endDate, companyId);
                    }
                    else
                    {
                        int projectId = int.Parse(ddlProject.SelectedValue);
                        productionReport.LoadByCountryIdClientIdProjectIdStartDateEndDate(country, clientId, projectId, startDate, endDate, companyId);
                    }
                }
            }
                        
            LiquiForce.LFSLive.DA.Projects.Projects.ProductionReportGateway productionReportGateway = new LiquiForce.LFSLive.DA.Projects.Projects.ProductionReportGateway(productionReport.Data);

            // ... set properties to master page
            master.Data = productionReportGateway.Data;
            master.Table = productionReportGateway.TableName;

            // Get report
            if (productionReportGateway.Table.Rows.Count > 0)
            {
                if (master.Format == "pdf")
                {
                    master.Report = new LiquiForce.LFSLive.WebUI.Projects.Projects.ProductionReport();
                }
                else
                {
                    master.Report = new LiquiForce.LFSLive.WebUI.Projects.Projects.ProductionReportExport();
                }

                // ... set parameters to report
                if (master.Format == "pdf")
                {
                    // ... ...  user
                    int loginId = Convert.ToInt32(Session["loginID"]);                    

                    LoginGateway loginGateway = new LoginGateway();
                    loginGateway.LoadByLoginId(loginId, companyId);
                    string user = loginGateway.GetLastName(loginId, companyId) + " " + loginGateway.GetFirstName(loginId, companyId);
                    master.SetParameter("User", user.Trim());

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
                                        
                    // ... ... Date
                    string startDateParameter = tkrdpStartDate.SelectedDate.Value.ToShortDateString();
                    master.SetParameter("StartDate", startDateParameter);

                    string endDateParameter = tkrdpEndDate.SelectedDate.Value.ToShortDateString();
                    master.SetParameter("EndDate", endDateParameter);

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
                }
                else
                {
                    // ... ... Date
                    string startDateParameter = tkrdpStartDate.SelectedDate.Value.ToShortDateString();
                    master.SetParameter("StartDate", startDateParameter);

                    string endDateParameter = tkrdpEndDate.SelectedDate.Value.ToShortDateString();
                    master.SetParameter("EndDate", endDateParameter);
                }
            }
        }
        
    

    }
}