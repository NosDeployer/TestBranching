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
using LiquiForce.LFSLive.BL.Resources.Companies;
using LiquiForce.LFSLive.DA.Resources.Companies;
using LiquiForce.LFSLive.DA.RAF;
using LiquiForce.LFSLive.BL.CWP.FullLengthLining;
using LiquiForce.LFSLive.BL.Projects.Projects;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.WebUI.CWP.FullLengthLining
{
    /// <summary>
    /// fl_lining_completed_report
    /// </summary>
    public partial class fl_lining_completed_report : System.Web.UI.Page
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
            // Set title & criteria width
            mReport1 master = (mReport1)this.Master;
            master.Title = "Lining Completed Report";

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

            DateTime startDate = DateTime.Parse(tkrdpStartDate.SelectedDate.Value.ToShortDateString());
            DateTime endDate = DateTime.Parse(tkrdpEndDate.SelectedDate.Value.ToShortDateString());
            
            // Get Data
            LiquiForce.LFSLive.BL.CWP.FullLengthLining.FlLiningCompletedReport flLiningCompletedReport = new LiquiForce.LFSLive.BL.CWP.FullLengthLining.FlLiningCompletedReport();
            int companyId = Int32.Parse(hdfCompanyId.Value);

            if (ddlCountry.SelectedValue == "(All)")
            {
                if (ddlClient.SelectedValue == "-1")
                {
                    flLiningCompletedReport.LoadByStartDateEndDate(startDate, endDate, companyId);
                }
                else
                {
                    if (ddlProject.SelectedValue == "-1")
                    {
                        flLiningCompletedReport.LoadByCompaniesIdStartDateEndDate(int.Parse(ddlClient.SelectedValue), startDate, endDate, companyId);
                    }
                    else
                    {
                        flLiningCompletedReport.LoadByCompaniesIdProjectIdStartDateEndDate(int.Parse(ddlClient.SelectedValue), int.Parse(ddlProject.SelectedValue), startDate, endDate, companyId);
                    }
                }
            }
            else
            {
                int countryId = Int32.Parse(ddlCountry.SelectedValue);
                if (ddlClient.SelectedValue == "-1")
                {
                    flLiningCompletedReport.LoadByStartDateEndDateCountryId(startDate, endDate, countryId, companyId);
                }
                else
                {
                    if (ddlProject.SelectedValue == "-1")
                    {
                        flLiningCompletedReport.LoadByCompaniesIdStartDateEndDateCountryId(int.Parse(ddlClient.SelectedValue), startDate, endDate, countryId, companyId);
                    }
                    else
                    {
                        flLiningCompletedReport.LoadByCompaniesIdProjectIdStartDateEndDateCountryId(int.Parse(ddlClient.SelectedValue), int.Parse(ddlProject.SelectedValue), startDate, endDate, countryId, companyId);
                    }
                }
            }

            // Set properties to master page
            master.Data = flLiningCompletedReport.Data;
            master.Table = flLiningCompletedReport.TableName;

            // Get report
            if (flLiningCompletedReport.Table.Rows.Count > 0)
            {
                if (master.Format == "pdf")
                {
                    master.Report = new FlLiningCompletedReport();
                }
                else
                {
                    master.Report = new FlLiningCompletedReportExport();
                }

                // ... set parameters to report
                if (master.Format == "pdf")
                {
                    // ... ... client
                    if (ddlClient.SelectedValue != "-1")
                    {
                        int currentClientId = Int32.Parse(ddlClient.SelectedValue);
                        
                        CompaniesGateway companiesGateway = new CompaniesGateway();
                        companiesGateway.LoadByCompaniesId(currentClientId, companyId);
                        master.SetParameter("Client", companiesGateway.GetName(currentClientId));
                    }
                    else
                    {
                        master.SetParameter("Client", "All");
                    }

                    // ... ... project
                    if (ddlProject.SelectedValue != "-1")
                    {
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

                    // ... ... user
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
                }
            }           
        }



    }
}