using System;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.BL.Resources.Employees;
using LiquiForce.LFSLive.DA.RAF;
using LiquiForce.LFSLive.DA.Resources.Employees;

namespace LiquiForce.LFSLive.WebUI.LabourHours.Vacations
{
    /// <summary>
    /// vacations_summary_report
    /// </summary>
    public partial class vacations_summary_report : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // INITIAL EVENTS
        //

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EmployeeGateway employeeGatewayManager = new EmployeeGateway();
                int employeeIdNow = employeeGatewayManager.GetEmployeIdByLoginId(Convert.ToInt32(Session["loginID"]));
                employeeGatewayManager.LoadByEmployeeId(employeeIdNow);
                                
                if (!employeeGatewayManager.GetIsVacationsManager(employeeIdNow))
                {
                    // Security check
                    if (!Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_VACATIONS_REPORTS"]))
                    {
                        Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                    }
                }
            
                // Validate query string
                if ((string)Request.QueryString["source_page"] == null)
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in vacations_summary_report.aspx");
                }

                EmployeeInformationPayVacationDaysInformationList employeeInformationPayVacationDaysInformationList = new EmployeeInformationPayVacationDaysInformationList();
                employeeInformationPayVacationDaysInformationList.Load();
                ddlYear.DataSource = employeeInformationPayVacationDaysInformationList.Table;
                ddlYear.DataValueField = "Year";
                ddlYear.DataTextField = "Year";
                ddlYear.DataBind();

                try
                {
                    ddlYear.SelectedValue = DateTime.Now.Year.ToString();
                }
                catch
                {
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
            master.Title = "Vacations Summary Report";

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
            int companyId = Convert.ToInt32(Session["companyID"]);
            string location = ddlLocation.SelectedValue;
            int employeeId = Int32.Parse(ddlEmployee.SelectedValue);
            int year = Int32.Parse(ddlYear.SelectedValue);

            // Get Data
            LiquiForce.LFSLive.BL.LabourHours.Vacations.VacationsSummaryReportEmployeeDetails vacationsSummaryReportEmployeeDetails = new LiquiForce.LFSLive.BL.LabourHours.Vacations.VacationsSummaryReportEmployeeDetails();

            // ... Load data
            if (ddlLocation.SelectedValue == "(All)")
            {
                if (ddlEmployee.SelectedValue == "-1")
                {
                    vacationsSummaryReportEmployeeDetails.LoadByYear(year, companyId);                    
                }
                else
                {                    
                    vacationsSummaryReportEmployeeDetails.LoadByYearEmployeeId(year, employeeId, companyId);
                }
            }
            else
            {
                if (ddlEmployee.SelectedValue == "-1")
                {                    
                    vacationsSummaryReportEmployeeDetails.LoadByYearEmployeeType(year, location, companyId);
                }
                else
                {                   
                    vacationsSummaryReportEmployeeDetails.LoadByYearEmployeeTypeEmployeeId(year, location, employeeId, companyId);
                }
            }

            // ... set properties to master page
            master.Data = vacationsSummaryReportEmployeeDetails.Data;
            master.Table = vacationsSummaryReportEmployeeDetails.TableName;

            // Get report
            if (vacationsSummaryReportEmployeeDetails.Table.Rows.Count > 0)
            {
                if (master.Format == "pdf")
                {
                    master.Report = new VacationsSummaryReport();

                    int loginId = Convert.ToInt32(Session["loginID"]);                    

                    LoginGateway loginGateway = new LoginGateway();
                    loginGateway.LoadByLoginId(loginId, companyId);
                    string user = loginGateway.GetLastName(loginId, companyId) + " " + loginGateway.GetFirstName(loginId, companyId);
                    master.SetParameter("User", user.Trim());

                    if (ddlLocation.SelectedValue == "(All)")
                    {
                        master.SetParameter("Location", "All");
                    }
                    else
                    {
                        ListItem lstI = new ListItem();
                        lstI = ddlLocation.SelectedItem;
                        master.SetParameter("Location", lstI.Text);
                    }

                    if (ddlEmployee.SelectedValue == "-1")
                    {
                        master.SetParameter("TeamMember", "All");
                    }
                    else
                    {
                        ListItem lstI = new ListItem();
                        lstI = ddlEmployee.SelectedItem;
                        master.SetParameter("TeamMember", lstI.Text);
                    }                    

                    if (ddlYear.SelectedValue == "(All)")
                    {
                        master.SetParameter("Year", "All");
                    }
                    else
                    {
                        ListItem lstI = new ListItem();
                        lstI = ddlYear.SelectedItem;
                        master.SetParameter("Year", lstI.Text);
                    }

                }
                else
                {
                    master.Report = new VacationsSummaryReportExport();
                }
            }
        }



    }
}