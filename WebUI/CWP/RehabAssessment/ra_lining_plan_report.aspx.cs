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
using LiquiForce.LFSLive.DA.CWP.RehabAssessment;
using LiquiForce.LFSLive.BL.CWP.RehabAssessment;
using LiquiForce.LFSLive.BL.RAF;
using LiquiForce.LFSLive.DA.RAF;

namespace LiquiForce.LFSLive.WebUI.CWP.RehabAssessment
{
    /// <summary>
    /// ra_lining_plan_report
    /// </summary>
    public partial class ra_lining_plan_report : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // EVENTS
        //

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // ... Access to this page
                if (!Convert.ToBoolean(Session["sgLFS_CWP_FULLLENGTHLINING_VIEW"]))
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
            // Set title & criteria width
            mReport1 master = (mReport1)this.Master;
            master.Title = "Rehab Assessment Plan Report";

            master.ShowTitle = true;
            master.ShowToolBar = true;
            master.ShowCriteria = false;
            master.CriteriaWidth = "0px";
            master.ShowPreview = false;
            master.ShowExport = false;

            if (!IsPostBack)
            {
                master.PrintDirectly = true;
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
            RaLiningPlanTDS raLiningPlanTDS = (RaLiningPlanTDS)Session["raLiningPlanTDS"];
            RaLiningPlan raLiningPlan = new RaLiningPlan();
            raLiningPlan.ProcessForReport(raLiningPlanTDS);

            // ... set properties to master page
            master.Data = raLiningPlan.Data;
            master.Table = raLiningPlan.TableName;
                        
            // Get report
            if (raLiningPlan.Table.Rows.Count > 0)
            {
                master.Report = new RaLiningPlanReport();

                //master.SetParameter("User", Session["justeMail"].ToString());
                int loginId = Convert.ToInt32(Session["loginID"]);
                int companyId = Convert.ToInt32(Session["companyID"]);

                LoginGateway loginGateway = new LoginGateway();
                loginGateway.LoadByLoginId(loginId, companyId);
                string user = loginGateway.GetLastName(loginId, companyId) + " " + loginGateway.GetFirstName(loginId, companyId);
                master.SetParameter("User", user.Trim());
            }
        }



    }
}
