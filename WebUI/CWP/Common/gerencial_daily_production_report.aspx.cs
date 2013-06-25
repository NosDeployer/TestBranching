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
    /// gerencial_daily_production_report
    /// </summary>
    public partial class gerencial_daily_production_report : System.Web.UI.Page
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
                tkrdpDate.SelectedDate = DateTime.Now;

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
            master.Title = "Daily Production Report";

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
            DateTime date = DateTime.Parse(tkrdpDate.SelectedDate.Value.ToShortDateString());
            int companyId = Int32.Parse(hdfCompanyId.Value);

            LiquiForce.LFSLive.BL.CWP.Common.GerencialDailyProductionReport gerencialDailyProductionReport = new LiquiForce.LFSLive.BL.CWP.Common.GerencialDailyProductionReport();
            gerencialDailyProductionReport.LoadByDate(date, companyId);

            // ... set properties to master page
            master.Data = gerencialDailyProductionReport.Data;
            master.Table = gerencialDailyProductionReport.TableName;

            // Get report
            if (gerencialDailyProductionReport.Table.Rows.Count > 0)
            {
                if (master.Format == "pdf")
                {
                    master.Report = new GerencialDailyProductionReport();
                }
                else
                {
                    master.Report = new GerencialDailyProductionReportExport();
                }

                // ... for date      
                string dateParameter = date.Month.ToString() + "/" + date.Day.ToString() + "/" + date.Year.ToString();
                master.SetParameter("Date", dateParameter);

                // ... for user
                int loginId = Convert.ToInt32(Session["loginID"]);                

                LoginGateway loginGateway = new LoginGateway();
                loginGateway.LoadByLoginId(loginId, companyId);
                string user = loginGateway.GetLastName(loginId, companyId) + " " + loginGateway.GetFirstName(loginId, companyId);
                master.SetParameter("User", user.Trim());
            }
        }
    }
}
