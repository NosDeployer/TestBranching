using System;
using LiquiForce.LFSLive.DA.RAF;
using CrystalDecisions.Shared;
using LiquiForce.LFSLive.DA.LabourHours.SubcontractorHours;

namespace LiquiForce.LFSLive.WebUI.LabourHours.SubcontractorHours
{
    /// <summary>
    /// subcontractor_hours_print_search_results_report
    /// </summary>
    public partial class subcontractor_hours_print_search_results_report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_SUBCONTRACTOR_HOURS_ADMIN"])))
            {
                // Security check
                if (!(Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_SUBCONTRACTOR_HOURS_VIEW"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }
            }

            // Register delegates
            this.RegisterDelegates();
        }
        


        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set title & criteria width
            mReport1 master = (mReport1)this.Master;
            master.Title = "Subcontractor Hours Search Results";
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

            SubcontractorHoursNavigatorTDS subcontractorHoursNavigatorTDS = (SubcontractorHoursNavigatorTDS)Session["subcontractorHoursNavigatorTDS"];
            LiquiForce.LFSLive.BL.LabourHours.SubcontractorHours.SubcontractorHoursNavigator subcontractorHoursNavigator = new LiquiForce.LFSLive.BL.LabourHours.SubcontractorHours.SubcontractorHoursNavigator(subcontractorHoursNavigatorTDS);

            // ... Set properties to master page
            master.Data = subcontractorHoursNavigator.Data;
            master.Table = subcontractorHoursNavigator.TableName;

            if (subcontractorHoursNavigator.Table.Rows.Count > 0)
            {
                if (master.Format == "pdf")
                {
                    master.Report = new LiquiForce.LFSLive.WebUI.LabourHours.SubcontractorHours.SubcontractorHoursPrintSearchResultsReport();

                    LoginGateway loginGateway = new LoginGateway();
                    int loginId = Convert.ToInt32(Session["loginID"]);
                    int companyId = Convert.ToInt32(Session["companyID"]);

                    loginGateway.LoadByLoginId(loginId, companyId);
                    string user = loginGateway.GetLastName(loginId, companyId) + " " + loginGateway.GetFirstName(loginId, companyId);
                    master.SetParameter("User", user.Trim());

                    // Report format
                    master.Report.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
                    master.Report.PrintOptions.PaperSize = PaperSize.PaperLegal;
                }
                else
                {
                    master.Report = new LiquiForce.LFSLive.WebUI.LabourHours.SubcontractorHours.SubcontractorHoursPrintSearchResultsReportExport();
                }
            }
        }



    }
}