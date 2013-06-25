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
using LiquiForce.LFSLive.DA.RAF;
using CrystalDecisions.CrystalReports.Engine;
using LiquiForce.LFSLive.DA.Resources.Employees;

namespace LiquiForce.LFSLive.WebUI.FleetManagement.Services
{
    /// <summary>
    /// services_myCurrentSR_report
    /// </summary>
    public partial class services_myCurrentSR_report : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        //  EVENTS
        //
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // ... Access to this page
                if (!Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_SERVICES_VIEW"]))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Tag Page
                hdfCompanyId.Value = Session["companyID"].ToString();

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
            master.Title = "My Current Service Requests";

            master.ShowTitle = true;
            master.ShowToolBar = true;
            master.ShowCriteria = false;
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
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int loginId = Convert.ToInt32(Session["loginID"]);
            EmployeeGateway employeeGateway = new EmployeeGateway(new DataSet());
            int employeeId = employeeGateway.GetEmployeIdByLoginId(loginId);

            LiquiForce.LFSLive.BL.FleetManagement.Services.ServicesMyCurrentSRReport servicesMyCurrentSRReport = new LiquiForce.LFSLive.BL.FleetManagement.Services.ServicesMyCurrentSRReport();
            servicesMyCurrentSRReport.LoadMyCurrentSRByAssignTeamMemberID(employeeId, companyId);
            
            // ... set properties to master page
            master.Data = servicesMyCurrentSRReport.Data;
            master.Table = servicesMyCurrentSRReport.TableName;

            // Get report
            if (servicesMyCurrentSRReport.Table.Rows.Count > 0)
            {
                if (master.Format == "pdf")
                {
                    master.Report = new ServicesMyCurrentSRReport();
                }
                else
                {
                    master.Report = new ServicesMyCurrentSRReportExport();
                }

                // ... set parameters to report
                if (master.Format == "pdf")
                {                   
                    LoginGateway loginGateway = new LoginGateway();
                    loginGateway.LoadByLoginId(loginId, companyId);
                    string user = loginGateway.GetLastName(loginId, companyId) + " " + loginGateway.GetFirstName(loginId, companyId);
                    master.SetParameter("User", user.Trim());
                }
            }
        }



    }
}
