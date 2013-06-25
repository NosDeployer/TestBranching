using System;
using LiquiForce.LFSLive.DA.LabourHours.ProjectTime;
using LiquiForce.LFSLive.DA.RAF;

namespace LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime
{
    /// <summary>
    /// print_3_chart_report
    /// </summary>
    public partial class print_3_chart_report : System.Web.UI.Page
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
                ddlProjectTimeState.SelectedValue = "Approved";
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
            // Dialog title
            mReport1 master = (mReport1)this.Master;
            master.Title = "Print 3 Chart Report";

            master.ShowTitle = true;
            master.ShowToolBar = true;
            master.ShowCriteria = true;
            master.CriteriaWidth = "200px";

            if (!IsPostBack)
            {
                master.PrintDirectly = false;
                master.ExportDirectly = false;
            }

            // Access control
            // ... Labour Hours Mode
            if ((string)ViewState["LHMode"] == "Partial")
            {
                lblProjectTimeState.Visible = false;
                ddlProjectTimeState.Visible = false;
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
            string projectTimeState = (ddlProjectTimeState.SelectedValue == "(All)") ? "%" : ddlProjectTimeState.SelectedValue;
            DateTime date = DateTime.Parse(tkrdpDate.SelectedDate.Value.ToShortDateString());

            Print3ChartReportGateway print3ChartReportGateway = new Print3ChartReportGateway();
            print3ChartReportGateway.LoadByDateProjectTimeState(date, projectTimeState);

            // ... set properties to master page
            master.Data = print3ChartReportGateway.Data;
            master.Table = print3ChartReportGateway.TableName;

            // Get report
            if (print3ChartReportGateway.Table.Rows.Count > 0)
            {
                if (master.Format == "pdf")
                {
                    master.Report = new LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime.Print3ChartReport();
                }
                else
                {
                    master.Report = new LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime.Print3ChartReportExport();
                }

                // ... set parameters to report
                if (master.Format == "pdf")
                {
                    // ... For report
                    // ... ... project time state
                    if (ddlProjectTimeState.SelectedValue == "(All)")
                    {
                        master.SetParameter("projectTimeState", "All");
                    }
                    else
                    {
                        master.SetParameter("projectTimeState", ddlProjectTimeState.SelectedItem.Text);
                    }

                    // ... ...  user
                    int loginId = Convert.ToInt32(Session["loginID"]);
                    int companyId = Convert.ToInt32(Session["companyID"]);

                    LoginGateway loginGateway = new LoginGateway();
                    loginGateway.LoadByLoginId(loginId, companyId);
                    string user = loginGateway.GetLastName(loginId, companyId) + " " + loginGateway.GetFirstName(loginId, companyId);
                    master.SetParameter("User", user.Trim());

                    // ... ... Date
                    master.SetParameter("date", tkrdpDate.SelectedDate.Value.ToShortDateString());
                }
            }
        }



    }
}