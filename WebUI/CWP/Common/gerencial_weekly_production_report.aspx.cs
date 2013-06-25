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
using LiquiForce.LFSLive.DA.CWP.Common;
using LiquiForce.LFSLive.BL.CWP.Common;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using LiquiForce.LFSLive.BL.RAF;
using LiquiForce.LFSLive.DA.RAF;

namespace LiquiForce.LFSLive.WebUI.CWP.Common
{
    /// <summary>
    /// gerencial_weekly_production_report
    /// </summary>
    public partial class gerencial_weekly_production_report : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // EVENTS
        //

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // ... Access to this page
                if (!Convert.ToBoolean(Session["sgLFS_CWP_GERENCIAL_PRODUCTION_REPORTS"]))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                hdfCompanyId.Value = Session["companyID"].ToString();

                // ... Find first day of the week
                DateTime sundayWeek = StartOfWeek(DateTime.Now, DayOfWeek.Sunday);
                tkrdpStartDate.SelectedDate = sundayWeek;
                lblEndDateValue.Text = sundayWeek.AddDays(7).ToShortDateString();

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
            // Set title & criteria width
            mReport1 master = (mReport1)this.Master;
            master.Title = "Weekly Production Report";

            master.ShowTitle = true;
            master.ShowToolBar = true;
            master.ShowCriteria = true;
            master.CriteriaWidth = "200px";
            master.ShowPreview = true;
            master.ShowExport = true;

            if (!IsPostBack)
            {
                master.PrintDirectly = true;
                master.ExportDirectly = false;
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // AUXILIAR EVENT
        //
        protected void tkrdpStartDate_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            // ... Find first day of the week
            DateTime sundayWeek = StartOfWeek((DateTime)tkrdpStartDate.SelectedDate, DayOfWeek.Sunday);
            tkrdpStartDate.SelectedDate = sundayWeek;
            lblEndDateValue.Text = sundayWeek.AddDays(7).ToShortDateString();
        }






        // ////////////////////////////////////////////////////////////////////////
        // METHODS
        //

        private DateTime StartOfWeek(DateTime dt, DayOfWeek startOfWeek)
        {
            System.Globalization.CultureInfo ci = System.Threading.Thread.CurrentThread.CurrentCulture;
            DayOfWeek fdow = ci.DateTimeFormat.FirstDayOfWeek;
            return dt.AddDays(-(dt.DayOfWeek - fdow));
        }


               
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
            int companyId = Int32.Parse(hdfCompanyId.Value);

            string endDateParameter = lblEndDateValue.Text;
            DateTime endDate = DateTime.Parse(endDateParameter);

            LiquiForce.LFSLive.BL.CWP.Common.GerencialWeeklyProductionReport gerencialWeeklyProductionReport = new LiquiForce.LFSLive.BL.CWP.Common.GerencialWeeklyProductionReport();
            gerencialWeeklyProductionReport.LoadByDate(startDate, companyId);

            // ... set properties to master page
            master.Data = gerencialWeeklyProductionReport.Data;
            master.Table = gerencialWeeklyProductionReport.TableName;

            // Get report
            if (gerencialWeeklyProductionReport.Table.Rows.Count > 0)
            {
                if (master.Format == "pdf")
                {
                    master.Report = new GerencialWeeklyProductionReport();
                }
                else
                {
                    master.Report = new GerencialWeeklyProductionReportExport();
                }

                // ... for start date                                                
                string startDateParameter = startDate.Month.ToString() + "/" + startDate.Day.ToString() + "/" + startDate.Year.ToString();
                master.SetParameter("StartDate", startDateParameter);

                // ... for end date                 
                master.SetParameter("EndDate", endDateParameter);
                int loginId = Convert.ToInt32(Session["loginID"]);
                
                LoginGateway loginGateway = new LoginGateway();
                loginGateway.LoadByLoginId(loginId, companyId);
                string user = loginGateway.GetLastName(loginId, companyId) + " " + loginGateway.GetFirstName(loginId, companyId);
                master.SetParameter("User", user.Trim());
            }
        }

       



    }
}