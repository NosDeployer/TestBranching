using System;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.DA.RAF;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.DA.LabourHours.ProjectTime;
using CrystalDecisions.Shared;
using LiquiForce.LFSLive.BL.LabourHours.ProjectTime;

namespace LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime
{
    /// <summary>
    /// print_unapproved_project_times
    /// </summary>
    public partial class print_unapproved_project_times : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // EVENTS
        //

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Security check
                if (!Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_FULL_EDITING"]))
                {
                    if (!Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_REPORTS"]))
                    {
                        Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                    }
                }

                // Initialize viewstate variables
                System.Configuration.AppSettingsReader appSettingReader = new System.Configuration.AppSettingsReader();
                ViewState["LHMode"] = appSettingReader.GetValue("LABOUR_HOURS_OPERATION_MODE", typeof(System.String)).ToString();

                // Prepare initial data for client
                tkrdpStartDate.SelectedDate = DateTime.Now;
                tkrdpEndDate.SelectedDate = DateTime.Now;

                // Databind
                ddlCountry.DataBind();                

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

            master.Title = "Print Unapproved Project Times Report";

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
            DateTime startDate = DateTime.Parse(tkrdpStartDate.SelectedDate.Value.ToShortDateString());
            DateTime endDate = DateTime.Parse(tkrdpEndDate.SelectedDate.Value.ToShortDateString());

            PrintUnnapprovedProjectTimes printUnnapprovedProjectTimes = new PrintUnnapprovedProjectTimes();

            if (ddlCountry.SelectedValue == "-1")
            {
                printUnnapprovedProjectTimes.LoadByStartDateEndDate(startDate, endDate);
            }
            else
            {
                printUnnapprovedProjectTimes.LoadByStartDateEndDateCountryId(startDate, endDate, int.Parse(ddlCountry.SelectedValue));
            }

            // ... set properties to master page
            master.Data = printUnnapprovedProjectTimes.Data;
            master.Table = printUnnapprovedProjectTimes.TableName;

            // Get report
            if (printUnnapprovedProjectTimes.Table.Rows.Count > 0)
            {
                // ... set parameters to report
                if (master.Format == "pdf")
                {
                    master.Report = new LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime.PrintUnapprovedProjectTimesReport();

                    // ... For report
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
                                        
                    // ... ...  user
                    int loginId = Convert.ToInt32(Session["loginID"]);
                    int companyId = Convert.ToInt32(Session["companyID"]);

                    LoginGateway loginGateway = new LoginGateway();
                    loginGateway.LoadByLoginId(loginId, companyId);
                    string user = loginGateway.GetLastName(loginId, companyId) + " " + loginGateway.GetFirstName(loginId, companyId);
                    master.SetParameter("User", user.Trim());

                    master.SetParameter("dateFrom", tkrdpStartDate.SelectedDate.Value.ToShortDateString());
                    master.SetParameter("dateTo", tkrdpEndDate.SelectedDate.Value.ToShortDateString());
                }
                else
                {
                    master.Report = new LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime.PrintUnapprovedProjectTimesReportExport();
                }
            }
        }



    }
}