using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.BL.Projects.Projects;
using LiquiForce.LFSLive.DA.RAF;
using LiquiForce.LFSLive.DA.Resources.Companies;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace LiquiForce.LFSLive.WebUI.Projects.Projects
{
    /// <summary>
    /// costing_sheet_report_consolidated
    /// </summary>
    public partial class costing_sheet_report_consolidated : System.Web.UI.Page
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
                    if (!(Convert.ToBoolean(Session["sgLFS_PROJECTS_COSTINGSHEETS_VIEW"]) && Convert.ToBoolean(Session["sgLFS_PROJECTS_COSTINGSHEETS_EDIT"])))
                    {
                        Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                    }
                }

                // Validate query string
                if ((string)Request.QueryString["source_page"] == null)
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in costing_sheet_report_consolidated.aspx");
                }

                //Initialize ddl
                ddlClient.DataBind();
                if ((string)Request.QueryString["client_id"] != null && (string)Request.QueryString["project_id"] != null)
                {
                    ddlClient.SelectedValue = (string)Request.QueryString["client_id"];

                    odsProject.SelectParameters.RemoveAt(2);
                    odsProject.SelectParameters.Add("ClientId", ddlClient.SelectedValue);
                    odsProject.Select();
                    ddlProject.SelectedValue = (string)Request.QueryString["project_id"];
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
            master.Title = "Consolidated Costing Sheet";
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
            int companyId = Convert.ToInt32(Session["companyID"]);

            ProjectCostingSheetInformationReportInformation projectCostingSheetInformationReportInformation = new ProjectCostingSheetInformationReportInformation();

            if (ddlClient.SelectedValue == "-1")
            {
                projectCostingSheetInformationReportInformation.Load(companyId);
            }
            else
            {
                if (ddlProject.SelectedValue == "-1")
                {
                    projectCostingSheetInformationReportInformation.LoadByCompaniesId(Int32.Parse(ddlClient.SelectedValue), companyId);
                }
                else
                {
                    projectCostingSheetInformationReportInformation.LoadByCompaniesIdProjectId(Int32.Parse(ddlClient.SelectedValue), Int32.Parse(ddlProject.SelectedValue), companyId);
                }
            }

            // ... set properties to master page
            master.Data = projectCostingSheetInformationReportInformation.Data;
            master.Table = projectCostingSheetInformationReportInformation.TableName;

            // Get report
            if (projectCostingSheetInformationReportInformation.Table.Rows.Count > 0)
            {
                if (master.Format == "pdf")
                {
                    master.Report = new ConsolidatedCostingSheetReport();
                    int loginId = Convert.ToInt32(Session["loginID"]);                    

                    LoginGateway loginGateway = new LoginGateway();
                    loginGateway.LoadByLoginId(loginId, companyId);
                    string user = loginGateway.GetLastName(loginId, companyId) + " " + loginGateway.GetFirstName(loginId, companyId);
                    master.SetParameter("User", user.Trim());

                    // For process code
                    ProjectCostingSheetInformationReportInformationGateway projectCostingSheetInformationReportInformationGateway = new ProjectCostingSheetInformationReportInformationGateway(projectCostingSheetInformationReportInformation.Data);

                    // ... ... client
                    if (ddlClient.SelectedValue == "-1")
                    {
                        master.SetParameter("client", "All");
                    }
                    else
                    {
                        CompaniesGateway companiesGateway = new CompaniesGateway();
                        companiesGateway.LoadByCompaniesId(Int32.Parse(ddlClient.SelectedValue), Int32.Parse(hdfCompanyId.Value));
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
                }
                else
                {
                    master.Report = new ConsolidatedCostingSheetPreviewReport();
                }
            }
        }



    }
}