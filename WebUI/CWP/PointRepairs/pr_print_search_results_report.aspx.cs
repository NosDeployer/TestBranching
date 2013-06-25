using System;
using LiquiForce.LFSLive.DA.RAF;
using LiquiForce.LFSLive.DA.CWP.PointRepairs;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace LiquiForce.LFSLive.WebUI.CWP.PointRepairs
{
    /// <summary>
    /// pr_print_search_results_report
    /// </summary>
    public partial class pr_print_search_results_report : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // EVENTS
        //

        protected void Page_Load(object sender, EventArgs e)
        {
            // ... Access to this page
            if (!Convert.ToBoolean(Session["sgLFS_CWP_POINTREPAIRS_VIEW"]))
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
            master.Title = Server.UrlDecode(Request.QueryString["title"].ToString());
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

            PrNavigatorTDS prNavigatorTDS = (PrNavigatorTDS)Session["prNavigatorTDS"];
            LiquiForce.LFSLive.BL.CWP.PointRepairs.PrNavigator prNavigator = new LiquiForce.LFSLive.BL.CWP.PointRepairs.PrNavigator(prNavigatorTDS);

            // set properties to master page
            master.Data = prNavigator.Data;
            master.Table = prNavigator.TableName;

            if (prNavigator.Table.Rows.Count > 0)
            {
                if (master.Format == "pdf")
                {
                    master.Report = new LiquiForce.LFSLive.WebUI.CWP.PointRepairs.PrPrintSearchResultsReport();
                    master.SetParameter("name", Server.UrlDecode(Request.QueryString["name"].ToString()));
                    master.SetParameter("Title", Server.UrlDecode(Request.QueryString["title"].ToString()));

                    // ... Parameters
                    int j;

                    for (int i = 0; i < int.Parse(Request.QueryString["totalColumnsPreview"]); i++)
                    {
                        j = i + 1;

                        master.SetParameter("header" + j, Request.QueryString["header" + j]);
                    }

                    master.SetParameter("headerComments", Request.QueryString["comments"]);

                    int loginId = Convert.ToInt32(Session["loginID"]);
                    int companyId = Convert.ToInt32(Session["companyID"]);

                    LoginGateway loginGateway = new LoginGateway();
                    loginGateway.LoadByLoginId(loginId, companyId);
                    string user = loginGateway.GetLastName(loginId, companyId) + " " + loginGateway.GetFirstName(loginId, companyId);
                    master.SetParameter("User", user.Trim());

                    if (int.Parse(Request.QueryString["totalSelectedColumns"]) <= 12)
                    {
                        ((Section)master.Report.ReportDefinition.Sections["sDetail12columns"]).SectionFormat.EnableSuppress = false;
                    }
                    else
                    {
                        if ((int.Parse(Request.QueryString["totalSelectedColumns"]) > 12) && (int.Parse(Request.QueryString["totalSelectedColumns"]) <= 24))
                        {
                            ((Section)master.Report.ReportDefinition.Sections["sDetail24columns"]).SectionFormat.EnableSuppress = false;
                        }
                        else
                        {
                            if ((int.Parse(Request.QueryString["totalSelectedColumns"]) > 25) && (int.Parse(Request.QueryString["totalSelectedColumns"]) <= 36))
                            {
                                ((Section)master.Report.ReportDefinition.Sections["sDetail36columns"]).SectionFormat.EnableSuppress = false;
                            }
                            else
                            {
                                if ((int.Parse(Request.QueryString["totalSelectedColumns"]) > 36) && (int.Parse(Request.QueryString["totalSelectedColumns"]) <= 48))
                                {
                                    ((Section)master.Report.ReportDefinition.Sections["sDetail48columns"]).SectionFormat.EnableSuppress = false;
                                }
                            }
                        }
                    }

                    // Report format
                    master.Report.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
                    master.Report.PrintOptions.PaperSize = PaperSize.PaperLegal;
                }
                else
                {
                    master.Report = new LiquiForce.LFSLive.WebUI.CWP.PointRepairs.PrPrintSearchResultsReportExport();

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