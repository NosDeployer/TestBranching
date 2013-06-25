using System;
using LiquiForce.LFSLive.DA.Resources.Companies;
using LiquiForce.LFSLive.BL.Resources.Companies;
using LiquiForce.LFSLive.BL.Projects.Projects;
using LiquiForce.LFSLive.DA.RAF;

namespace LiquiForce.LFSLive.WebUI.Projects.Projects
{
    /// <summary>
    /// projects_summary_report
    /// </summary>
    public partial class projects_summary_report : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // EVENTS
        //

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Security check
                if (!(Convert.ToBoolean(Session["sgLFS_PROJECTS_VIEW"]) && Convert.ToBoolean(Session["sgLFS_PROJECTS_ADMIN"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Prepare initial data 
                int companyId = Convert.ToInt32(Session["companyID"]);
                CompaniesList companiesList = new CompaniesList();
                companiesList.LoadAndAddItem(-1, "(All)", companyId);
                ddlClient.DataSource = companiesList.Table;
                ddlClient.DataValueField = "COMPANIES_ID";
                ddlClient.DataTextField = "Name";
                ddlClient.DataBind();

                // ... for project
                ProjectList projectList = new ProjectList();
                projectList.LoadProjectsAndAddItem(-1, "(All)", -1);
                ddlProject.DataSource = projectList.Table;
                ddlProject.DataValueField = "ProjectID";
                ddlProject.DataTextField = "Name";
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
            master.Title = "Project Summary Report";

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






        /// ////////////////////////////////////////////////////////////////////////
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
            string whereClause = "(P.Deleted = 0)";

            if (ddlCountry.SelectedValue != "(All)")
            {
                if (ddlClient.SelectedValue == "-1")
                {
                    if (whereClause.Length > 0) whereClause += " AND ";
                    whereClause += "(P.CountryID = " + ddlCountry.SelectedValue + ")";
                }
                else
                {
                    if (ddlProject.SelectedValue == "-1")
                    {
                        if (whereClause.Length > 0) whereClause += " AND ";
                        whereClause += "(P.ClientID = " + ddlClient.SelectedValue + ")";
                    }
                    else
                    {
                        if (whereClause.Length > 0) whereClause += " AND ";
                        whereClause += "(P.ProjectID = " + ddlProject.SelectedValue + ")";
                    }
                }
            }
            else
            {
                if (ddlProject.SelectedValue != "-1")
                {
                    if (whereClause.Length > 0) whereClause += " AND ";
                    whereClause += "(P.ProjectID = " + ddlProject.SelectedValue + ")";
                }
                else
                {
                    if (ddlClient.SelectedValue != "-1")
                    {
                        if (whereClause.Length > 0) whereClause += " AND ";
                        whereClause += "(P.ClientID = " + ddlClient.SelectedValue + ")";
                    }
                }
            }

            if (ddlState.SelectedValue != "(All)")
            {
                if (whereClause.Length > 0) whereClause += " AND ";

                if (ddlState.SelectedValue == "AwardedBidding")
                {
                    whereClause += "((P.ProjectState = 'Bidding') OR (P.ProjectState = 'Awarded'))";
                }
                else
                {
                    whereClause += "(P.ProjectState = '" + ddlState.SelectedValue + "')";
                }
            }

            LiquiForce.LFSLive.BL.Projects.Projects.ProjectsSummaryReport projectsSummaryReport = new LiquiForce.LFSLive.BL.Projects.Projects.ProjectsSummaryReport();
            projectsSummaryReport.LoadWhere(whereClause, ddlCountry.SelectedValue, decimal.Parse(tbxExchangeRate.Text));

            // ... set properties to master page
            master.Data = projectsSummaryReport.Data;
            master.Table = projectsSummaryReport.TableName;

            // Get report
            if (projectsSummaryReport.Table.Rows.Count > 0)
            {
                if (master.Format == "pdf")
                {
                    master.Report = new LiquiForce.LFSLive.WebUI.Projects.Projects.ProjectsSummaryReport();
                }
                else
                {
                    master.Report = new LiquiForce.LFSLive.WebUI.Projects.Projects.ProjectsSummaryReportExport();
                }

                // ... set parameters to report
                if (master.Format == "pdf")
                {
                    // ... For report
                    master.SetParameter("ExchangeRate", decimal.Parse(tbxExchangeRate.Text.Trim()));
                    master.SetParameter("Total", "Total (" + ddlCurrency.SelectedValue.Trim() + "):");
                    master.SetParameter("Currency", ddlCurrency.SelectedValue.Trim());

                    // ... ...  user
                    int loginId = Convert.ToInt32(Session["loginID"]);
                    int companyId = Convert.ToInt32(Session["companyID"]);

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

                    // ... ... client
                    if (ddlClient.SelectedValue != "-1")
                    {
                        master.SetParameter("Client", ddlClient.SelectedItem.Text);
                    }
                    else
                    {
                        master.SetParameter("Client", "All");
                    }

                    // ... ... project
                    if (ddlProject.SelectedValue != "-1")
                    {
                        master.SetParameter("Project", ddlProject.SelectedItem.Text);
                    }
                    else
                    {
                        master.SetParameter("Project", "All");
                    }

                    // ... ... state
                    if (ddlState.SelectedValue == "(All)")
                    {
                        master.SetParameter("State", "All");
                    }
                    else
                    {
                        if (ddlState.SelectedValue == "AwardedBidding")
                        {
                            master.SetParameter("State", "Awarded & Bidding");
                        }
                        else
                        {
                            master.SetParameter("State", ddlState.SelectedValue);
                        }
                    }
                }
                else
                {
                    master.SetParameter("Total", "Total (" + ddlCurrency.SelectedValue.Trim() + "):");
                }
            }
        }



    }
}