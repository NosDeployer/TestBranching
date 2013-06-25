using System;
using LiquiForce.LFSLive.DA.FleetManagement.Services;
using LiquiForce.LFSLive.DA.RAF;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace LiquiForce.LFSLive.WebUI.FleetManagement.Services
{
    /// <summary>
    /// services_print_search_results_report
    /// </summary>
    public partial class services_print_search_results_report : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // EVENTS
        //

        protected void Page_Load(object sender, EventArgs e)
        {
            // ... Access to this page
            if (!Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_SERVICES_VIEW"]))
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

            ServicesNavigatorTDS servicesNavigatorTDS = (ServicesNavigatorTDS)Session["servicesNavigatorTDS"];
            LiquiForce.LFSLive.BL.FleetManagement.Services.ServicesNavigator servicesNavigator = new LiquiForce.LFSLive.BL.FleetManagement.Services.ServicesNavigator(servicesNavigatorTDS);

            // ... Set properties to master page
            master.Data = servicesNavigator.Data;
            master.Table = servicesNavigator.TableName;

            if (servicesNavigator.Table.Rows.Count > 0)
            {
                if (master.Format == "pdf")
                {
                    master.Report = new LiquiForce.LFSLive.WebUI.FleetManagement.Services.ServicesPrintSearchResultsReport();

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

                    if (int.Parse(Request.QueryString["totalSelectedColumns"]) <= 12)
                    {
                        ((Section)master.Report.ReportDefinition.Sections["sDetail36columns"]).SectionFormat.EnableSuppress = true;
                        ((Section)master.Report.ReportDefinition.Sections["sDetail24columns"]).SectionFormat.EnableSuppress = true;
                        ((Section)master.Report.ReportDefinition.Sections["sDetail12columns"]).SectionFormat.EnableSuppress = false;
                    }
                    else
                    {
                        if ((int.Parse(Request.QueryString["totalSelectedColumns"]) > 12) && (int.Parse(Request.QueryString["totalSelectedColumns"]) <= 24))
                        {
                            ((Section)master.Report.ReportDefinition.Sections["sDetail36columns"]).SectionFormat.EnableSuppress = true;
                            ((Section)master.Report.ReportDefinition.Sections["sDetail24columns"]).SectionFormat.EnableSuppress = false;
                            ((Section)master.Report.ReportDefinition.Sections["sDetail12columns"]).SectionFormat.EnableSuppress = true;
                        }
                        else
                        {
                            if ((int.Parse(Request.QueryString["totalSelectedColumns"]) > 24) && (int.Parse(Request.QueryString["totalSelectedColumns"]) <= 36))
                            {
                                ((Section)master.Report.ReportDefinition.Sections["sDetail36columns"]).SectionFormat.EnableSuppress = false;
                                ((Section)master.Report.ReportDefinition.Sections["sDetail24columns"]).SectionFormat.EnableSuppress = true;
                                ((Section)master.Report.ReportDefinition.Sections["sDetail12columns"]).SectionFormat.EnableSuppress = true;
                            }
                        }
                    }

                    // Report format
                    master.Report.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
                    master.Report.PrintOptions.PaperSize = PaperSize.PaperLegal;
                }
                else
                {
                    master.Report = new LiquiForce.LFSLive.WebUI.FleetManagement.Services.ServicesPrintSearchResultsReportExport();

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