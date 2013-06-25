using System;
using LiquiForce.LFSLive.DA.RAF;

namespace LiquiForce.LFSLive.WebUI.Projects.Projects
{
    /// <summary>
    /// video_complete_report
    /// </summary>
    public partial class video_complete_report : System.Web.UI.Page
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
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Tag page
                hdfCompanyId.Value = Convert.ToInt32(Session["companyID"]).ToString();
                                
                // Prepare initial data 
                tkrdpStartDate.SelectedDate = DateTime.Now;
                tkrdpEndDate.SelectedDate = DateTime.Now;

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
            master.Title = "Video Complete Report";

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
            
            int companyId = Int32.Parse(hdfCompanyId.Value);
            LiquiForce.LFSLive.BL.Projects.Projects.VideoCompleteReport videoCompleteReport = new LiquiForce.LFSLive.BL.Projects.Projects.VideoCompleteReport();

            if (ddlCountry.SelectedValue == "(All)")
            {
                videoCompleteReport.LoadByStartDateEndDate(startDate, endDate, companyId);
            }
            else
            {
                int country = Int32.Parse(ddlCountry.SelectedValue);

                videoCompleteReport.LoadByCountryIdStartDateEndDate(country, startDate, endDate, companyId);
            }

            LiquiForce.LFSLive.DA.Projects.Projects.VideoCompleteReportGateway videoCompleteReportGateway = new LiquiForce.LFSLive.DA.Projects.Projects.VideoCompleteReportGateway(videoCompleteReport.Data);

            // ... set properties to master page
            master.Data = videoCompleteReportGateway.Data;
            master.Table = videoCompleteReportGateway.TableName;

            // Get report
            if (videoCompleteReportGateway.Table.Rows.Count > 0)
            {
                if (master.Format == "pdf")
                {
                    master.Report = new LiquiForce.LFSLive.WebUI.Projects.Projects.VideoCompleteReport();
                }
                else
                {
                    master.Report = new LiquiForce.LFSLive.WebUI.Projects.Projects.VideoCompleteReportExport();
                }

                // ... set parameters to report
                if (master.Format == "pdf")
                {
                    // ... ...  user
                    int loginId = Convert.ToInt32(Session["loginID"]);                    

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
                                       

                    // ... ... Date
                    string startDateParameter = tkrdpStartDate.SelectedDate.Value.ToShortDateString();
                    master.SetParameter("StartDate", startDateParameter);

                    string endDateParameter = tkrdpEndDate.SelectedDate.Value.ToShortDateString();
                    master.SetParameter("EndDate", endDateParameter);
                }
                else
                {
                    // ... ... Date
                    string startDateParameter = tkrdpStartDate.SelectedDate.Value.ToShortDateString();
                    master.SetParameter("StartDate", startDateParameter);

                    string endDateParameter = tkrdpEndDate.SelectedDate.Value.ToShortDateString();
                    master.SetParameter("EndDate", endDateParameter);
                }
            }
        }



    }
}