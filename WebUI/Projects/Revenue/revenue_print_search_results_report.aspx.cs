using System;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using LiquiForce.LFSLive.DA.Projects.Revenue;
using LiquiForce.LFSLive.DA.RAF;


namespace LiquiForce.LFSLive.WebUI.Projects.Revenue
{
    /// <summary>
    /// revenue_print_search_results_report
    /// </summary>
    public partial class revenue_print_search_results_report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // ... Access to this page
            if (!Convert.ToBoolean(Session["sgLFS_PROJECTS_REVENUE_VIEW"]))
            {
                Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
            }

            // Register delegates
            this.RegisterDelegates();
        }



        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set title & criteria width
            mReport1 master = (mReport1)this.Master;
            master.Title = Request.QueryString["title"].ToString();
            master.ShowTitle = false;
            master.ShowToolBar = false;
            master.ShowCriteria = false;
            master.CriteriaWidth = "0px";

            if (!IsPostBack)
            {
                if (Request.QueryString["format"] == "pdf")
                {
                    master.PrintDirectly = true;
                }
                else
                {
                    master.ExportDirectly = true;
                }
            }
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

            RevenueNavigatorTDS revenueNavigatorTDS = (RevenueNavigatorTDS)Session["revenueNavigatorTDS"];
            LiquiForce.LFSLive.BL.Projects.Revenue.RevenueNavigator revenueNavigator = new LiquiForce.LFSLive.BL.Projects.Revenue.RevenueNavigator(revenueNavigatorTDS);

            // ... Set properties to master page
            master.Data = revenueNavigator.Data;
            master.Table = revenueNavigator.TableName;

            if (revenueNavigator.Table.Rows.Count > 0)
            {
                if (master.Format == "pdf")
                {
                    master.Report = new LiquiForce.LFSLive.WebUI.Projects.Revenue.RevenuePrintSearchResultsReport();

                    // ... Parameters
                    int j;
                    for (int i = 0; i < int.Parse(Request.QueryString["totalColumnsPreview"]); i++)
                    {
                        j = i + 1;

                        master.SetParameter("header" + j, Request.QueryString["header" + j]);
                    }

                    master.SetParameter("headerComments", Request.QueryString["comments"]);
                    master.SetParameter("Title", Request.QueryString["title"]);

                    int loginId = Convert.ToInt32(Session["loginID"]);
                    int companyId = Convert.ToInt32(Session["companyID"]);

                    LoginGateway loginGateway = new LoginGateway();
                    loginGateway.LoadByLoginId(loginId, companyId);
                    string user = loginGateway.GetLastName(loginId, companyId) + " " + loginGateway.GetFirstName(loginId, companyId);
                    master.SetParameter("User", user.Trim());              

                    // Report format
                    master.Report.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
                    master.Report.PrintOptions.PaperSize = PaperSize.PaperLegal;
                }
                else
                {
                    master.Report = new LiquiForce.LFSLive.WebUI.Projects.Revenue.RevenuePrintSearchResultsReportExport();

                    // ... Parameters
                    int j;
                    for (int i = 0; i < int.Parse(Request.QueryString["totalColumnsExport"]); i++)
                    {
                        j = i + 1;

                        master.SetParameter("header" + j, Request.QueryString["header" + j]);
                    }
                }
            }
        }

    }
}