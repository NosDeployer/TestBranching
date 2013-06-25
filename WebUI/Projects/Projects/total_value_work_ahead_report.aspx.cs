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

namespace LiquiForce.LFSLive.WebUI.Projects.Projects
{
    /// <summary>
    /// total_value_work_ahead_report
    /// </summary>
    public partial class total_value_work_ahead_report : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // EVENTS
        //

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Security check
                if ( !(Convert.ToBoolean(Session["sgLFS_PROJECTS_VIEW"])  && Convert.ToBoolean(Session["sgLFS_PROJECTS_ADMIN"])))
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
            master.Title = "Total Value Of Proposals Report";

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
            string whereClause = "(P.Deleted = 0) AND (P.ProjectType = 'Proposal')";
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

            whereClause += " AND (P.ProjectType != 'Internal')";

            LiquiForce.LFSLive.BL.Projects.Projects.TotalValueWorkAheadReport totalValueWorkAheadReport = new LiquiForce.LFSLive.BL.Projects.Projects.TotalValueWorkAheadReport();
            totalValueWorkAheadReport.LoadWhere(whereClause, ddlCurrency.SelectedValue, decimal.Parse(tbxExchangeRate.Text));

            // ... set properties to master page
            master.Data = totalValueWorkAheadReport.Data;
            master.Table = totalValueWorkAheadReport.TableName;

            // Get report
            if (totalValueWorkAheadReport.Table.Rows.Count > 0)
            {
                if (master.Format == "pdf")
                {
                    master.Report = new LiquiForce.LFSLive.WebUI.Projects.Projects.TotalValueWorkAheadReport();
                }
                else
                {
                    master.Report = new LiquiForce.LFSLive.WebUI.Projects.Projects.TotalValueWorkAheadReportExport();
                }

                // ... set parameters to report
                if (master.Format == "pdf")
                {
                    // ... For report
                    master.SetParameter("ExchangeRate", decimal.Parse(tbxExchangeRate.Text.Trim()));
                    master.SetParameter("Total", "Total (" + ddlCurrency.SelectedValue.Trim() + "):");
                    master.SetParameter("GrandTotal", "GRAND TOTAL (" + ddlCurrency.SelectedValue.Trim() + "):");
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
                else
                {
                    master.SetParameter("ExchangeRate", decimal.Parse(tbxExchangeRate.Text.Trim()));
                    master.SetParameter("Total", "Total (" + ddlCurrency.SelectedValue.Trim() + "):");
                    master.SetParameter("GrandTotal", "GRAND TOTAL (" + ddlCurrency.SelectedValue.Trim() + "):");
                }
            }
        }
        
        

    }
}
