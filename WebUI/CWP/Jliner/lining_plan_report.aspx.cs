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
using LiquiForce.LFSLive.DA.CWP.Jliner;
using LiquiForce.LFSLive.BL.CWP.Jliner;
using LiquiForce.LFSLive.BL.Resources.Companies;
using LiquiForce.LFSLive.DA.Resources.Companies;
using LiquiForce.LFSLive.BL.RAF;
using LiquiForce.LFSLive.DA.RAF;
using LiquiForce.LFSLive.BL.Projects.Projects;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.WebUI.CWP.Jliner
{
    /// <summary>
    /// linning_plan_report
    /// </summary>
    public partial class lining_plan_report : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected LinningPlanTDS linningPlanTDS;






        // ////////////////////////////////////////////////////////////////////////
        // EVENTS
        //

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Security check
                if (!Convert.ToBoolean(Session["sgLFS_APP_VIEW"]))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["client_id"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in lining_plan_report.aspx");
                }

                // Tag page
                hdfCurrentClientId.Value = Request.QueryString["client_id"].ToString();

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
            master.Title = "Lining Plan Report";

            master.ShowTitle = false;
            master.ShowToolBar = false;
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
            LinningPlanTDS linningPlanTDS = (LinningPlanTDS)Session["linningPlanTDS"];
            LiquiForce.LFSLive.BL.CWP.Jliner.LinningPlan linningPlan = new LiquiForce.LFSLive.BL.CWP.Jliner.LinningPlan();
            linningPlan.ProcessForReport(linningPlanTDS);

            // ... set properties to master page
            master.Data = linningPlan.Data;
            master.Table = linningPlan.TableName;

            // Get report
            int companyId = Convert.ToInt32(Session["companyID"]);
            if (linningPlan.Table.Rows.Count > 0)
            {
                master.Report = new LinningPlan();

                // ... for client
                int currentClientId = Int32.Parse(hdfCurrentClientId.Value);
                CompaniesGateway companiesGateway = new CompaniesGateway();
                companiesGateway.LoadByCompaniesId(currentClientId, companyId);
                master.SetParameter("Client", companiesGateway.GetName(currentClientId));

                int loginId = Convert.ToInt32(Session["loginID"]);
                

                LoginGateway loginGateway = new LoginGateway();
                loginGateway.LoadByLoginId(loginId, companyId);
                string user = loginGateway.GetLastName(loginId, companyId) + " " + loginGateway.GetFirstName(loginId, companyId);
                master.SetParameter("User", user.Trim());
            }
        }



    }
}