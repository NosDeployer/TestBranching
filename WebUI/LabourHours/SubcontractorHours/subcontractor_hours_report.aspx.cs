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
using LiquiForce.LFSLive.BL.RAF;
using LiquiForce.LFSLive.DA.RAF;
using LiquiForce.LFSLive.BL.LabourHours.SubcontractorHours;
using LiquiForce.LFSLive.DA.LabourHours.SubcontractorHours;
using LiquiForce.LFSLive.DA.Resources.Subcontractors;
using LiquiForce.LFSLive.BL.Projects.Projects;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.WebUI.LabourHours.SubcontractorHours
{
    /// <summary>
    /// subcontractorHours_report
    /// </summary>
    public partial class subcontractorHours_report : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // EVENTS
        //
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Access to this page
                if (!Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_SUBCONTRACTOR_HOURS_VIEW"]))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Tag Page
                hdfCompanyId.Value = Session["companyID"].ToString();                               
                
                // Prepare initial data                 
                // ... For Client            
                int companyId = Int32.Parse(hdfCompanyId.Value);
                CompaniesList companiesList = new CompaniesList();
                companiesList.LoadAndAddItem(-1, "(All)", companyId);
                ddlClient.DataSource = companiesList.Table;
                ddlClient.DataValueField = "COMPANIES_ID";
                ddlClient.DataTextField = "NAME";
                ddlClient.DataBind();

                // ... for project
                ProjectList projectList = new ProjectList();
                projectList.LoadProjectsAndAddItem(-1, "(All)", int.Parse(ddlClient.SelectedValue));
                ddlProject.DataSource = projectList.Table;
                ddlProject.DataValueField = "ProjectID";
                ddlProject.DataTextField = "Name";
                ddlProject.DataBind();

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
            master.Title = "Subcontractor Hours Report";

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
            LiquiForce.LFSLive.BL.LabourHours.SubcontractorHours.SubcontractorHoursReport subcontractorHoursReport = new LiquiForce.LFSLive.BL.LabourHours.SubcontractorHours.SubcontractorHoursReport();
            int companyId = Int32.Parse(hdfCompanyId.Value);

            DateTime startDate = DateTime.Parse(tkrdpStartDate.SelectedDate.Value.ToShortDateString());
            DateTime endDate = DateTime.Parse(tkrdpEndDate.SelectedDate.Value.ToShortDateString());

            if (rbtnSearchBySubcontractor.Checked)
            {
                int subcontractorId = Int32.Parse(ddlSubcontractor.SelectedValue);
                if (!ckbxDates.Checked)
                {                    
                    if (subcontractorId == -1)
                    {
                        subcontractorHoursReport.LoadForSubcontractors(companyId);
                    }
                    else
                    {
                        subcontractorHoursReport.LoadBySubcontractorId(subcontractorId, companyId);
                    }
                }
                else
                {
                    if (subcontractorId == -1)
                    {
                        subcontractorHoursReport.LoadStartDateEndDateForSubcontractors(startDate, endDate, companyId);
                    }
                    else
                    {
                        subcontractorHoursReport.LoadBySubcontractorIdStartDateEndDate(subcontractorId, startDate, endDate, companyId);
                    }
                }
            }
            else
            {
                // Search by Client and Project
                int clientId = Int32.Parse(ddlClient.SelectedValue);
                int projectId = Int32.Parse(ddlProject.SelectedValue);

                if (!ckbxDates.Checked)
                {
                    if (clientId == -1)
                    {
                        subcontractorHoursReport.LoadForClientProject(companyId);
                    }
                    else
                    {
                        if (ddlProject.SelectedValue == "-1")
                        {
                            subcontractorHoursReport.LoadByCompaniesId(clientId, companyId);
                        }
                        else
                        {
                            subcontractorHoursReport.LoadByCompaniesIdProjectId(clientId, projectId, companyId);
                        }
                    }
                }
                else
                {
                    if (clientId == -1)
                    {
                        subcontractorHoursReport.LoadStartDateEndDateForClientProject(startDate, endDate, companyId);
                    }
                    else
                    {
                        if (ddlProject.SelectedValue == "-1")
                        {
                            subcontractorHoursReport.LoadByCompaniesIdStartDateEndDate(clientId, startDate, endDate, companyId);
                        }
                        else
                        {
                            subcontractorHoursReport.LoadByCompaniesIdProjectIdStartDateEndDate(clientId, projectId, startDate, endDate, companyId);
                        }
                    }
                }
            }     
   
            // Set properties to master page
            master.Data = subcontractorHoursReport.Data;
            master.Table = subcontractorHoursReport.TableName;

            // Get report
            if (subcontractorHoursReport.Table.Rows.Count > 0)
            {
                if (master.Format == "pdf")
                {
                    master.Report = new SubcontractorHoursReport();
                }
                else
                {
                    master.Report = new SubcontractorHoursReportExport();
                }

                // ... set parameters to report
                if (master.Format == "pdf")
                {
                    // ... ... client
                    if (ddlClient.SelectedValue != "-1")
                    {
                        int currentClientId = Int32.Parse(ddlClient.SelectedValue);
                        CompaniesGateway companiesGateway = new CompaniesGateway();
                        companiesGateway.LoadByCompaniesId(currentClientId,companyId);
                        master.SetParameter("Client", companiesGateway.GetName(currentClientId));
                    }
                    else
                    {
                        master.SetParameter("Client", "All");
                    }

                    // ... ...  project
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

                    // ... ... subcontractor
                    if (ddlSubcontractor.SelectedValue != "-1")
                    {
                        int currentSubcontractorId = Int32.Parse(ddlSubcontractor.SelectedValue);
                        CompaniesGateway companiesGateway = new CompaniesGateway();
                        companiesGateway.LoadByCompaniesId(currentSubcontractorId, companyId);
                        string name = companiesGateway.GetName(currentSubcontractorId);
                        master.SetParameter("Subcontractor", name);
                    }
                    else
                    {
                        master.SetParameter("Subcontractor", "All");
                    }

                    // ... ... user
                    LoginGateway loginGateway = new LoginGateway();
                    loginGateway.LoadByLoginId(Convert.ToInt32(Session["loginID"]), companyId);
                    string user = loginGateway.GetLastName(Convert.ToInt32(Session["loginID"]), companyId) + " " + loginGateway.GetFirstName(Convert.ToInt32(Session["loginID"]), companyId);
                    master.SetParameter("User", user.Trim());

                    // ... for start date                                                
                    string startDateParameter = startDate.Month.ToString() + "/" + startDate.Day.ToString() + "/" + startDate.Year.ToString();
                    master.SetParameter("StartDate", startDateParameter);

                    // ... for end date           
                    string endDateParameter = endDate.Month.ToString() + "/" + endDate.Day.ToString() + "/" + endDate.Year.ToString();
                    master.SetParameter("EndDate", endDateParameter);
                }
            }            
        }



    }
}