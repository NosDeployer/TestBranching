using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.BL.Resources.Companies;
using LiquiForce.LFSLive.DA.Resources.Companies;
using LiquiForce.LFSLive.BL.Projects.Projects;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.DA.RAF;
using LiquiForce.LFSLive.BL.Assets.Assets;
using System.Collections;

namespace LiquiForce.LFSLive.WebUI.CWP.FullLengthLining
{
    /// <summary>
    /// fl_opened_brushed_report
    /// </summary>
    public partial class fl_opened_brushed_report : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // EVENTS
        //
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Access to this page
                if (!Convert.ToBoolean(Session["sgLFS_CWP_FULLLENGTHLINING_VIEW"]))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if (((string)Request.QueryString["client_id"] == null) || ((string)Request.QueryString["project_id"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in fl_opened_brushed_report.aspx");
                }

                // Prepare initial data 
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfCurrentClientId.Value = Request.QueryString["client_id"].ToString();
                hdfCurrentProjectId.Value = Request.QueryString["project_id"].ToString();

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
            // Set title & criteria width
            mReport1 master = (mReport1)this.Master;
            master.Title = "Opened And Brushed Report";

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
            string unitType = "";
            LiquiForce.LFSLive.BL.CWP.FullLengthLining.FlM1LateralSectionReport flM1Report = new LiquiForce.LFSLive.BL.CWP.FullLengthLining.FlM1LateralSectionReport();
            int companyId = Int32.Parse(hdfCompanyId.Value);

            // Get Data
            // For all clients
            if (ddlClient.SelectedValue == "-1")
            {
                flM1Report.Load(companyId, unitType);
            }
            // For specific client
            else
            {
                // For all projects
                if (ddlProject.SelectedValue == "-1")
                {
                    flM1Report.LoadByCompaniesId(companyId, int.Parse(ddlClient.SelectedValue), unitType);

                }
                // For specific project
                else
                {
                    flM1Report.LoadByCompaniesIdProjectId(companyId, int.Parse(ddlClient.SelectedValue), int.Parse(ddlProject.SelectedValue), unitType);
                }
            }

            // ... set properties to master page
            master.Data = flM1Report.Data;
            master.Table = flM1Report.TableName;

            // Get report
            if (flM1Report.Table.Rows.Count > 0)
            {
                if (master.Format == "pdf")
                {
                    master.Report = new FlM1LateralReport();
                }
                else
                {
                    master.Report = new FlM1LateralReportExport();
                }

                // ... set parameters to report
                if (master.Format == "pdf")
                {
                    if (ddlClient.SelectedValue != "-1")
                    {
                        // ... for client
                        int currentClientId = Int32.Parse(ddlClient.SelectedValue);
                        
                        CompaniesGateway companiesGateway = new CompaniesGateway();
                        companiesGateway.LoadByCompaniesId(currentClientId, companyId);
                        master.SetParameter("Client", companiesGateway.GetName(currentClientId));
                    }
                    else
                    {
                        master.SetParameter("Client", "All");
                    }

                    if (ddlProject.SelectedValue != "-1")
                    {
                        // ... for project
                        int currentProjectId = Int32.Parse(ddlProject.SelectedValue);
                        ProjectGateway projectGateway = new ProjectGateway();
                        projectGateway.LoadByProjectId(currentProjectId);
                        string name = projectGateway.GetName(currentProjectId);
                        master.SetParameter("Project", name);
                    }
                    else
                    {
                        master.SetParameter("Project", "All");
                    }

                    int loginId = Convert.ToInt32(Session["loginID"]);                    

                    LoginGateway loginGateway = new LoginGateway();
                    loginGateway.LoadByLoginId(loginId, companyId);
                    string user = loginGateway.GetLastName(loginId, companyId) + " " + loginGateway.GetFirstName(loginId, companyId);
                    master.SetParameter("User", user.Trim());
                }
            }
        }



    }
}