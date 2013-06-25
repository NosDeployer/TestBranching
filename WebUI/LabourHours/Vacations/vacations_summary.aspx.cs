using System;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;
using LiquiForce.LFSLive.BL.Resources.Employees;
using LiquiForce.LFSLive.DA.LabourHours.Vacations;
using LiquiForce.LFSLive.DA.Resources.Employees;

namespace LiquiForce.LFSLive.WebUI.LabourHours.Vacations
{
    /// <summary>
    /// vacations_summary
    /// </summary>
    public partial class vacations_summary : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected VacationsInformationTDS vacationsInformationTDS;
        protected VacationsInformationTDS.DaysInformationDataTable vacationDaysInformation;






        // ////////////////////////////////////////////////////////////////////////
        // EVENTS
        //

        protected void Page_Load(object sender, EventArgs e)
        {
            // Register client scripts
            this.RegisterClientScripts();

            if (!IsPostBack)
            {                
                // Security check
                if (!(Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_VACATIONS_VIEW"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }
                
                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) && ((string)Request.QueryString["vacation_id"] == null) && ((string)Request.QueryString["request_id"] == null) && ((string)Request.QueryString["date_to_show"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in vacations_summary.aspx");
                }

                // Tag page
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfVacationId.Value = (string)Request.QueryString["vacation_id"];
                hdfRequestId.Value = (string)Request.QueryString["request_id"];

                int requestId = Int32.Parse(hdfRequestId.Value);
                int companyId = Int32.Parse(hdfCompanyId.Value);

                // ...  for non vacation managers
                EmployeeGateway employeeGatewayManager = new EmployeeGateway();
                int employeeIdNow = employeeGatewayManager.GetEmployeIdByLoginId(Convert.ToInt32(Session["loginID"]));
                employeeGatewayManager.LoadByEmployeeId(employeeIdNow);

                if (employeeGatewayManager.GetIsVacationsManager(employeeIdNow))
                {
                    hdfIsVacationManager.Value = "True";
                }
                else
                {
                    hdfIsVacationManager.Value = "False";
                }

                // Load vacations
                ViewState["date_to_show"] = (string)Request.QueryString["date_to_show"];
                DateTime dateToShow = DateTime.Parse((string)Request.QueryString["date_to_show"]);

                vacationsInformationTDS = new VacationsInformationTDS();
                vacationDaysInformation = new VacationsInformationTDS.DaysInformationDataTable();

                VacationsInformationDaysInformationGateway vacationsInformationDaysInformationGateway = new VacationsInformationDaysInformationGateway(vacationsInformationTDS);
                vacationsInformationDaysInformationGateway.LoadByRequestId(requestId, companyId); 

                VacationsInformationRequestsInformationGateway vacationsInformationRequestsInformationGateway = new VacationsInformationRequestsInformationGateway(vacationsInformationTDS);
                vacationsInformationRequestsInformationGateway.LoadByRequestId(requestId, companyId);

                hdfEmployeeId.Value = vacationsInformationRequestsInformationGateway.GetEmployeeID(requestId).ToString();
                int employeeId = Int32.Parse(hdfEmployeeId.Value);

                VacationsInformationBasicInformationGateway vacationsInformationBasicInformationGateway = new VacationsInformationBasicInformationGateway(vacationsInformationTDS);
                vacationsInformationBasicInformationGateway.LoadByEmployeeIdYear(employeeId, dateToShow.Year, companyId);

                Session["vacationsInformationTDS"] = vacationsInformationTDS;
                Session["vacationDaysInformation"] = vacationsInformationTDS.DaysInformation;

                // Initialize values
                DropDownList ddlVacationsFor = (DropDownList)tkrpbLeftMenuAllVacations.FindItemByValue("nbVacationsForDDL").FindControl("ddlVacationsFor");
                EmployeeList employeeList = new EmployeeList();
                string employeeTypeNow = employeeGatewayManager.GetType(employeeIdNow);

                if (employeeTypeNow.Contains("CA"))
                {
                    employeeList.LoadBySalariedEmployeeTypeAndAddItem(1, "CA", -1, "(All)");
                }
                else
                {
                    employeeList.LoadBySalariedEmployeeTypeAndAddItem(1, "US", -1, "(All)");
                }
                ddlVacationsFor.DataSource = employeeList.Table;
                ddlVacationsFor.DataValueField = "EmployeeID";
                ddlVacationsFor.DataTextField = "FullName";
                ddlVacationsFor.DataBind();
                ddlVacationsFor.SelectedValue = Session["ddlVacationsForSelectedValue"].ToString();

                LoadData(employeeId, dateToShow.Year, requestId);

                Page.DataBind();
            }
            else
            {
                vacationsInformationTDS = (VacationsInformationTDS)Session["vacationsInformationTDS"];
                vacationDaysInformation = (VacationsInformationTDS.DaysInformationDataTable)Session["vacationDaysInformation"];
            }
        }



        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set active toolbar
            mForm6 master = (mForm6)this.Master;
            master.ActiveToolbar = "LabourHours";
            
            // for non vacation managers
            if (hdfIsVacationManager.Value == "False")
            {
                // Validate left menu
                tkrpbLeftMenuAllVacations.Visible = false; // All Vacations
                tkrpbLeftMenuMyVacations.Visible = true; // My Vacations
                
                // Validate Top menu for Admin
                tkrmTop.Items[0].Visible = false; // Edit button

                // Validate reports
                tkrpbLeftMenuReports.Visible = false;
            }
            else
            {
                // Validate reports
                if (!Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_VACATIONS_REPORTS"]))
                {
                    tkrpbLeftMenuReports.Visible = false;
                }
            }

            if (!(Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_VACATIONS_HOLIDAY_FULL_EDITING"])))
            {
                // Validate tools menu
                tkrpbLeftMenuTools.Visible = false;
                //tkrpbLeftMenuTools.Items[2].Visible = false;
                //tkrpbLeftMenuTools.Items[3].Visible = false;
            }
           

            VacationsInformationRequestsInformationGateway vacationsInformationRequestsInformationGateway = new VacationsInformationRequestsInformationGateway(vacationsInformationTDS);
            string state = vacationsInformationRequestsInformationGateway.GetState(Int32.Parse(hdfRequestId.Value));

            if (state == "Rejected" || state == "Cancelled")
            {
                tkrmTop.Items[0].Visible = false;
            }

            tkrsVacations.SelectedDate = DateTime.Parse(ViewState["date_to_show"].ToString());
        }






        // ////////////////////////////////////////////////////////////////////////
        // AUXILIAR EVENTS
        //

        protected void tkrsVacations_NavigationComplete(object sender, SchedulerNavigationCompleteEventArgs e)
        {
            DateTime dateToShowOld = DateTime.Parse((string)ViewState["date_to_show"]);

            ViewState["date_to_show"] = tkrsVacations.SelectedDate.ToString();

            DateTime dateToShowNew = DateTime.Parse((string)ViewState["date_to_show"]);

            if (dateToShowNew.Year != dateToShowOld.Year)
            {
                VacationsInformationBasicInformationGateway vacationsInformationBasicInformationGateway = new VacationsInformationBasicInformationGateway(vacationsInformationTDS);
                vacationsInformationBasicInformationGateway.LoadByEmployeeIdYear(Int32.Parse(hdfEmployeeId.Value), dateToShowNew.Year, Int32.Parse(hdfCompanyId.Value));

                if (vacationsInformationBasicInformationGateway.Table.Rows.Count == 0)
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "The team member don't have max paid day vacations defined in the system. Contact your system administrator.");
                }
                else
                {
                    LoadData(Int32.Parse(hdfEmployeeId.Value), dateToShowNew.Year, Int32.Parse(hdfRequestId.Value));
                }
            }
        }
                     


        protected void tkrsVacations_AppointmentDataBound(object sender, SchedulerEventArgs e)
        {
            switch (e.Appointment.Subject)
            {
                case "Unpaid Leave Full Day":
                    e.Appointment.CssClass = "rsCategoryRed2";
                    break;

                case "Unpaid Leave Half Day":
                    e.Appointment.CssClass = "rsCategoryRed2";
                    break;

                case "Full Vacation Day":
                    e.Appointment.CssClass = "rsCategoryGreen2";
                    break;

                case "Half Vacation Day":
                    e.Appointment.CssClass = "rsCategoryGreen2";
                    break;
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATION EVENTS
        //

        protected void tkrmTop_ItemClick(object sender, RadMenuEventArgs e)
        {
            DropDownList ddlVacationsFor = (DropDownList)tkrpbLeftMenuAllVacations.FindItemByValue("nbVacationsForDDL").FindControl("ddlVacationsFor");
            Session["ddlVacationsForSelectedValue"] = ddlVacationsFor.SelectedValue;

            switch (e.Item.Value)
            {
                case "mEdit":
                    if (ddlVacationsFor.SelectedIndex > 0)
                    {
                        Response.Redirect("./vacations_edit.aspx?source_page=vacations_summary.aspx&vacation_id=" + hdfVacationId.Value + "&request_id=" + hdfRequestId.Value + "&employee_id=" + ddlVacationsFor.SelectedValue + "&date_to_show=" + ViewState["date_to_show"]);
                    }
                    else
                    {
                        Response.Redirect("./vacations_edit.aspx?source_page=vacations_summary.aspx&vacation_id=" + hdfVacationId.Value + "&request_id=" + hdfRequestId.Value + "&date_to_show=" + ViewState["date_to_show"]);
                    }
                    break;

                case "mAllVacations":
                    if (ddlVacationsFor.SelectedIndex > 0)
                    {
                        Response.Redirect("./vacations_all.aspx?source_page=vacations_summary.aspx&employee_id=" + ddlVacationsFor.SelectedValue + "&date_to_show=" + ViewState["date_to_show"]);
                    }
                    else
                    {
                        Response.Redirect("./vacations_all.aspx?source_page=vacations_summary.aspx&date_to_show=" + ViewState["date_to_show"]);
                    }
                    break;
            }
        }



        protected void tkrpbLeftMenu_ItemClick(object sender, RadPanelBarEventArgs e)
        {
            DropDownList ddlVacationsFor = (DropDownList)tkrpbLeftMenuAllVacations.FindItemByValue("nbVacationsForDDL").FindControl("ddlVacationsFor");
            Session["ddlVacationsForSelectedValue"] = ddlVacationsFor.SelectedValue;

            switch (e.Item.Value)
            {
                case "nbViewVacations":
                    if (ddlVacationsFor.SelectedIndex > 0)
                    {
                        Response.Redirect("./vacations_all.aspx?source_page=vacations_summary.aspx&employee_id=" + ddlVacationsFor.SelectedValue + "&date_to_show=" + ViewState["date_to_show"]);
                    }
                    else
                    {
                        Response.Redirect("./vacations_all.aspx?source_page=vacations_summary.aspx&date_to_show=" + ViewState["date_to_show"]);
                    }
                    break;

                case "nbNonWorkingDaysDefinition":
                    Response.Redirect("./vacations_non_working_days_definition.aspx?source_page=vacations_summary.aspx" + "&date_to_show=" + ViewState["date_to_show"]);
                    break;

                case "nbApproveVacationRequests":
                    if (ddlVacationsFor.SelectedIndex > 0)
                    {
                        Response.Redirect("./vacations_approve_vacation_request.aspx?source_page=vacations_summary.aspx&employee_id=" + ddlVacationsFor.SelectedValue + "&date_to_show=" + ViewState["date_to_show"]);
                    }
                    else
                    {
                        Response.Redirect("./vacations_approve_vacation_request.aspx?source_page=vacations_summary.aspx&date_to_show=" + ViewState["date_to_show"]);
                    }
                    break;

                case "nbCancelVacationRequests":
                    if (ddlVacationsFor.SelectedIndex > 0)
                    {
                        Response.Redirect("./vacations_cancel_vacation_request.aspx?source_page=vacations_summary.aspx&employee_id=" + ddlVacationsFor.SelectedValue + "&date_to_show=" + ViewState["date_to_show"]);
                    }
                    else
                    {
                        Response.Redirect("./vacations_cancel_vacation_request.aspx?source_page=vacations_summary.aspx&date_to_show=" + ViewState["date_to_show"]);
                    }
                    break;
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        //  PUBLIC METHODS
        //

        public VacationsInformationTDS.DaysInformationDataTable GetVacationsNew()
        {
            vacationDaysInformation = ((VacationsInformationTDS)Session["vacationsInformationTDS"]).DaysInformation;

            return vacationDaysInformation;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        private void LoadData(int employeeId, int year, int requestId)
        {
            VacationsInformationBasicInformationGateway vacationsInformationBasicInformationGateway = new VacationsInformationBasicInformationGateway(vacationsInformationTDS);
            VacationsInformationRequestsInformationGateway vacationsInformationRequestsInformationGateway = new VacationsInformationRequestsInformationGateway(vacationsInformationTDS);

            tbxEmployee.Text = vacationsInformationBasicInformationGateway.GetEmployeeName(employeeId, year);
            tbxMax.Text = vacationsInformationBasicInformationGateway.GetTotalVacationDays(employeeId, year).ToString();
            tbxRemaining.Text = vacationsInformationBasicInformationGateway.GetRemainingPayVacationDays(employeeId, year).ToString();
            tbxComments.Text = vacationsInformationRequestsInformationGateway.GetComments(requestId);
        }



        private void RegisterClientScripts()
        {
            // Publishing body's OnKeyDown event 
            HtmlGenericControl bodyUnload = (HtmlGenericControl)Page.Master.FindControl("myBody");
            bodyUnload.Attributes.Add("OnKeyDown", "OnKeyDown(event);");

            // Register content variables
            string contentVariables = "";

            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode1", "./vacations_summary.js");
        }

        



    }
}