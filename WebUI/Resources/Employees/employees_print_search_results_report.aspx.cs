using System;
using System.Web;
using LiquiForce.LFSLive.DA.RAF;
using CrystalDecisions.Shared;
using LiquiForce.LFSLive.DA.Resources.Employees;

namespace LiquiForce.LFSLive.WebUI.Resources.Employees
{
    /// <summary>
    /// employees_print_search_results_report
    /// </summary>
    public partial class employees_print_search_results_report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // ... Access to this page
            if (!Convert.ToBoolean(Session["sgLFS_RESOURCES_EMPLOYEES_VIEW"]))
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

            EmployeeNavigatorTDS employeeNavigatorTDS = (EmployeeNavigatorTDS)Session["employeeNavigatorTDS"];
            LiquiForce.LFSLive.BL.Resources.Employees.EmployeeNavigator employeeNavigator = new LiquiForce.LFSLive.BL.Resources.Employees.EmployeeNavigator(employeeNavigatorTDS);

            // ... Set properties to master page
            master.Data = employeeNavigator.Data;
            master.Table = employeeNavigator.TableName;

            if (employeeNavigator.Table.Rows.Count > 0)
            {
                if (master.Format == "pdf")
                {
                    master.Report = new LiquiForce.LFSLive.WebUI.Resources.Employees.EmployeesPrintSearchResultsReport();
                    master.SetParameter("Title", Request.QueryString["title"]);

                    // ... Parameters
                    int j;
                    for (int i = 0; i < int.Parse(Request.QueryString["totalColumnsPreview"]); i++)
                    {
                        j = i + 1;

                        master.SetParameter("header" + j, Request.QueryString["header" + j]);
                    }

                    int loginId = Convert.ToInt32(Session["loginID"]);
                    int companyId = Convert.ToInt32(Session["companyID"]);

                    LoginGateway loginGateway = new LoginGateway();
                    loginGateway.LoadByLoginId(loginId, companyId);
                    string user = loginGateway.GetLastName(loginId, companyId) + " " + loginGateway.GetFirstName(loginId, companyId);
                    master.SetParameter("User", user.Trim());

                    // Report format
                    master.Report.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
                    master.Report.PrintOptions.PaperSize = PaperSize.PaperLegal;
                }
                else
                {
                    master.Report = new LiquiForce.LFSLive.WebUI.Resources.Employees.EmployeesPrintSearchResultsReportExport();

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