using System;
using LiquiForce.LFSLive.DA.RAF;

namespace LiquiForce.LFSLive.WebUI.Projects.Projects
{
    /// <summary>
    /// detailed_work_on_hand_report
    /// </summary>
    public partial class detailed_work_on_hand_report : System.Web.UI.Page
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
            master.Title = "Current Active Work On Hand Report";

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
            string whereClause = "(P.Deleted = 0) AND (P.ProjectType = 'Project') AND (P.ProjectState = 'Active')";

            if (ddlCountry.SelectedValue != "(All)")
            {
                if (whereClause.Length > 0) whereClause += " AND ";
                whereClause += "(P.CountryID = " + ddlCountry.SelectedValue + ")";
            }

            LiquiForce.LFSLive.BL.Projects.Projects.DetailedWorkOnHandReport detailedWorkOnHandReport = new LiquiForce.LFSLive.BL.Projects.Projects.DetailedWorkOnHandReport();
            detailedWorkOnHandReport.LoadWhere(whereClause, ddlCountry.SelectedValue, decimal.Parse(tbxExchangeRate.Text));
            
            // ... set properties to master page
            master.Data = detailedWorkOnHandReport.Data;
            master.Table = detailedWorkOnHandReport.TableName;

            // Get report
            if (detailedWorkOnHandReport.Table.Rows.Count > 0)
            {
                if (master.Format == "pdf")
                {
                    master.Report = new  LiquiForce.LFSLive.WebUI.Projects.Projects.DetailedWorkOnHandReport();
                }
                else
                {
                    master.Report = new  LiquiForce.LFSLive.WebUI.Projects.Projects.DetailedWorkOnHandReportExport();
                }

                // ... set parameters to report
                if (master.Format == "pdf")
                {
                    // ... For report
                    master.SetParameter("ExchangeRate", decimal.Parse(tbxExchangeRate.Text.Trim()));
                    master.SetParameter("Total", "Total (" + ddlCurrency.SelectedValue.Trim() + "):");
                    master.SetParameter("Currency", ddlCurrency.SelectedValue.Trim());

                    // ... ...  user
                    LoginGateway loginGateway = new LoginGateway();
                    int loginId = Convert.ToInt32(Session["loginID"]);
                    int companyId = Convert.ToInt32(Session["companyID"]);
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
                else
                {
                    master.SetParameter("ExchangeRate", decimal.Parse(tbxExchangeRate.Text.Trim()));
                    master.SetParameter("Total", "Total (" + ddlCurrency.SelectedValue.Trim() + "):");
                }
            }            
        }



    }
}        