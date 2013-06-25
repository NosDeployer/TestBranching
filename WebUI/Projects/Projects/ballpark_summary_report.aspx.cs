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
using LiquiForce.LFSLive.BL.Resources.Employees;
using LiquiForce.LFSLive.DA.Resources.Employees;
using LiquiForce.LFSLive.BL.RAF;
using LiquiForce.LFSLive.DA.RAF;

namespace LiquiForce.LFSLive.WebUI.Projects.Projects
{
    /// <summary>
    /// ballpark_summary_report
    /// </summary>
    public partial class ballpark_summary_report : System.Web.UI.Page
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
                // ... for client
                int companyId = Int32.Parse(Session["companyID"].ToString());
                CompaniesList companiesList = new CompaniesList();
                companiesList.LoadAndAddItem(-1, "(All)", companyId);
                ddlClient.DataSource = companiesList.Table;
                ddlClient.DataTextField = "Name";
                ddlClient.DataValueField = "COMPANIES_ID";

                // ... for salesman
                SalesmanList salesmanList = new SalesmanList();
                salesmanList.LoadAndAddItem(-1, "(All)");
                ddlSalesman.DataSource = salesmanList.Table;
                ddlSalesman.DataValueField = "SalesmanID";
                ddlSalesman.DataTextField = "FullName";
                ddlSalesman.DataBind();
                
                // DataBind
                this.DataBind();

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
            master.Title = "Ballpark Summary Report";

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
        /// METHODS
        ///

        private void RegisterDelegates()
        {
            mReport1 master = (mReport1)this.Master;
            master.GenerateMethod = new mReport1.ReportMethod(Generate);
        }



        private void Generate()
        {
            mReport1 master = (mReport1)this.Master;

            // Get Data
            string orderBy = ddlOrderBy.SelectedValue;
            string whereClause = "(P.Deleted = 0) AND (P.ProjectType = 'Ballpark') AND (P.ProjectState = 'Active')";

            if (ddlCountry.SelectedValue != "(All)")
            {
                if (whereClause.Length > 0) whereClause += " AND ";
                whereClause += "(P.CountryID = " + ddlCountry.SelectedValue + ")";
            }

            if (ddlClient.SelectedValue != "-1")
            {
                if (whereClause.Length > 0) whereClause += " AND ";
                whereClause += "(P.ClientID = " + ddlClient.SelectedValue + ")";
            }

            if (ddlSalesman.SelectedValue != "-1")
            {
                if (whereClause.Length > 0) whereClause += " AND ";
                whereClause += "(P.SalesmanID = " + ddlSalesman.SelectedValue + ")";
            }

            LiquiForce.LFSLive.BL.Projects.Projects.BallparkSummaryReport ballparkSummayReport = new LiquiForce.LFSLive.BL.Projects.Projects.BallparkSummaryReport();
            ballparkSummayReport.LoadWhereOrderBy(whereClause, orderBy, ddlCurrency.SelectedValue, decimal.Parse(tbxExchangeRate.Text));
            
            // ... set properties to master page
            master.Data = ballparkSummayReport.Data;
            master.Table = ballparkSummayReport.TableName;

            // Get report
            if (ballparkSummayReport.Table.Rows.Count > 0)
            {
                if (master.Format == "pdf")
                {
                    master.Report = new LiquiForce.LFSLive.WebUI.Projects.Projects.BallparkSummaryReport();
                }
                else
                {
                    master.Report = new LiquiForce.LFSLive.WebUI.Projects.Projects.BallparkSummaryReportExport();
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

                    // ... ... client
                    if (ddlClient.SelectedValue == "-1")
                    {
                        master.SetParameter("Client", "All");
                    }
                    else
                    {
                        CompaniesGateway companiesGateway = new CompaniesGateway();
                        companiesGateway.LoadByCompaniesId(Int32.Parse(ddlClient.SelectedValue), companyId);
                        string clientName = companiesGateway.GetName(Int32.Parse(ddlClient.SelectedValue));
                        master.SetParameter("Client", clientName);
                    }

                    // ... ... salesman
                    if (ddlSalesman.SelectedValue == "-1")
                    {
                        master.SetParameter("Salesman", "All");
                    }
                    else
                    {
                        EmployeeGateway employeeGateway = new EmployeeGateway();
                        employeeGateway.LoadByEmployeeId(Int32.Parse(ddlSalesman.SelectedValue));
                        string salesman = employeeGateway.GetFullName(Int32.Parse(ddlSalesman.SelectedValue));
                        master.SetParameter("Salesman", salesman);
                    }

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

                    // ... ... order by
                    if (ddlOrderBy.SelectedValue == "P.CountryID")
                    {
                        master.SetParameter("OrderBy", "Country");
                    }
                    else
                    {
                        if (ddlOrderBy.SelectedValue == "P.ProjectNumber")
                        {
                            master.SetParameter("OrderBy", "Project Number");
                        }
                        else
                        {
                            if (ddlOrderBy.SelectedValue == "P.Name")
                            {
                                master.SetParameter("OrderBy", "Project Name");
                            }
                            else
                            {
                                if (ddlOrderBy.SelectedValue == "C.Name")
                                {
                                    master.SetParameter("OrderBy", "Client");
                                }
                                else
                                {
                                    master.SetParameter("OrderBy", "Salesman");
                                }  
                            }   
                        }
                    }
                }
                else
                {
                    master.SetParameter("ExchangeRate", decimal.Parse(tbxExchangeRate.Text.Trim()));
                    master.SetParameter("Total", "Total (" + ddlCurrency.SelectedValue.Trim() + "):");
                }
            }
        }

        
    }
}
