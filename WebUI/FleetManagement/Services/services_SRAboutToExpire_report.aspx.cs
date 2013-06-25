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
using LiquiForce.LFSLive.BL.RAF;
using LiquiForce.LFSLive.DA.RAF;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using LiquiForce.LFSLive.DA.Resources.Employees;

namespace LiquiForce.LFSLive.WebUI.FleetManagement.Services
{
    /// <summary>
    /// services_SRAboutToExpire_report
    /// </summary>
    public partial class services_SRAboutToExpire_report : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // EVENTS
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
            master.Title = "About To Expire Service Requests";

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
            int companyId = Int32.Parse(hdfCompanyId.Value);
            string period = ddlPeriod.SelectedItem.Value;

            int loginId = Convert.ToInt32(Session["loginID"]);
            EmployeeGateway employeeGateway = new EmployeeGateway(new DataSet());
            int employeeId = employeeGateway.GetEmployeIdByLoginId(loginId);

            LiquiForce.LFSLive.BL.FleetManagement.Services.ServicesSRAboutToExpireReport servicesSRAboutToExpireReport = new LiquiForce.LFSLive.BL.FleetManagement.Services.ServicesSRAboutToExpireReport();
            
            if (Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_SERVICES_ADMIN"]))
            {
                servicesSRAboutToExpireReport.LoadItemsAboutToExpire(period, companyId);
            }
            else
            {
                servicesSRAboutToExpireReport.LoadItemsAboutToExpireByAssignTeamMemberID(period, employeeId, companyId);
            }
                                        
            // ... set properties to master page
            master.Data = servicesSRAboutToExpireReport.Data;
            master.Table = servicesSRAboutToExpireReport.TableName;
            
            // Get report
            if (servicesSRAboutToExpireReport.Table.Rows.Count > 0)
            {
                if (master.Format == "pdf")
                {
                    master.Report = new ServicesSRAboutToExpireReport();
                    
                    // Report format
                    master.Report.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
                    master.Report.PrintOptions.PaperSize = PaperSize.PaperLegal;
                }
                else
                {
                    master.Report = new ServicesSRAboutToExpireReportExport();
                }

                // ... set parameters to report
                if (master.Format == "pdf")
                {                    
                    LoginGateway loginGateway = new LoginGateway();
                    loginGateway.LoadByLoginId(loginId, companyId);
                    string user = loginGateway.GetLastName(loginId, companyId) + " " + loginGateway.GetFirstName(loginId, companyId);
                    master.SetParameter("User", user.Trim());

                    master.SetParameter("Period", period.ToString());
                }
            }            
        }
       


    }
}
