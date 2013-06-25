using System;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.BL.Resources.Employees;
using LiquiForce.LFSLive.BL.LabourHours.Vacations;
using LiquiForce.LFSLive.DA.LabourHours.Vacations;
using LiquiForce.LFSLive.DA.Resources.Employees;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.LabourHours.Vacations
{
    /// <summary>
    /// vacations_all
    /// </summary>
    public partial class vacations_all : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected VacationsInformationTDS vacationsInformationTDS;
        protected VacationsInformationTDS.VacationsInformationDataTable vacationsInformation;






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
                if (((string)Request.QueryString["source_page"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in vacations_all.aspx");
                }

                // Tag page
                int companyId = Int32.Parse(Session["companyID"].ToString());
                hdfCompanyId.Value = companyId.ToString();                

                // ... For non vacation managers
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

                //... date_to_show
                if ((string)Request.QueryString["date_to_show"] == null)
                {
                    ViewState["date_to_show"] = DateTime.Now.ToString();
                }
                else
                {
                    ViewState["date_to_show"] = (string)Request.QueryString["date_to_show"];
                }

                // Load vacations
                vacationsInformationTDS = new VacationsInformationTDS();
                vacationsInformation = new VacationsInformationTDS.VacationsInformationDataTable();

                VacationsInformationGateway vacationsInformationGateway = new VacationsInformationGateway(vacationsInformationTDS);
                              
                if (hdfIsVacationManager.Value == "False")
                {                
                    EmployeeGateway employeeGateway1 = new EmployeeGateway();
                    ViewState["employee_id"] = employeeGateway1.GetEmployeIdByLoginId(Convert.ToInt32(Session["loginID"]));

                    EmployeeInformationBasicInformationGateway employeeInformationBasicInformationGateway = new EmployeeInformationBasicInformationGateway();
                    employeeInformationBasicInformationGateway.LoadByEmployeeId(Int32.Parse(ViewState["employee_id"].ToString()));

                    string employeeType = employeeInformationBasicInformationGateway.GetType(Int32.Parse(ViewState["employee_id"].ToString()));

                    if (employeeType.Contains("CA"))
                    {
                        ddlWorkingLocation.SelectedValue = "CA";

                    }
                    else
                    {
                        ddlWorkingLocation.SelectedValue = "US";
                    }

                    vacationsInformationGateway.LoadByEmployeeIdEmployeeType(Int32.Parse(ViewState["employee_id"].ToString()), employeeType, companyId);
                }
                else
                {
                    if ((string)Request.QueryString["employee_id"] == null)
                    {
                        ViewState["employee_id"] = "-1";

                        if (employeeTypeNow.Contains("CA"))
                        {
                            ddlWorkingLocation.SelectedValue = "CA";
                        }
                        else
                        {
                            ddlWorkingLocation.SelectedValue = "US";
                        }

                        vacationsInformationGateway.LoadByEmployeeType(employeeTypeNow, companyId);
                    }
                    else
                    {
                        ViewState["employee_id"] = (string)Request.QueryString["employee_id"];

                        EmployeeInformationBasicInformationGateway employeeInformationBasicInformationGateway = new EmployeeInformationBasicInformationGateway();
                        employeeInformationBasicInformationGateway.LoadByEmployeeId(Int32.Parse(ViewState["employee_id"].ToString()));

                        string employeeType = employeeInformationBasicInformationGateway.GetType(Int32.Parse(ViewState["employee_id"].ToString()));

                        if (employeeTypeNow.Contains("CA"))
                        {
                            ddlWorkingLocation.SelectedValue = "CA";
                        }
                        else
                        {
                            ddlWorkingLocation.SelectedValue = "US";
                        }

                        vacationsInformationGateway.LoadByEmployeeIdEmployeeType(Int32.Parse(ViewState["employee_id"].ToString()), employeeType, companyId);

                        ddlVacationsFor.SelectedValue = ViewState["employee_id"].ToString();
                    }
                }
                
                Session["vacationsInformationTDS"] = vacationsInformationTDS;
                Session["vacationsInformation"] = vacationsInformationTDS.VacationsInformation;

                tkrsVacations.SelectedDate = DateTime.Parse(ViewState["date_to_show"].ToString());
                lblTitle.Text = "Vacations Calendar for " + tkrsVacations.SelectedDate.ToString("MMMM") + " " + tkrsVacations.SelectedDate.Year.ToString();

                // Databind
                Page.DataBind();

                // For Open Vacation event
                if ((Request.Params["__EVENTTARGET"]) == "openVacation")
                {
                    int vacationId = Int32.Parse(Request.Params.Get("__EVENTARGUMENT").ToString()) ;
                    VacationsInformationDaysInformationGateway vacationsInformationDaysInformationGateway = new VacationsInformationDaysInformationGateway();
                    vacationsInformationDaysInformationGateway.LoadByVacationId(vacationId, companyId);
                    int requestId = vacationsInformationDaysInformationGateway.GetRequestID(vacationId);

                    Session["ddlVacationsForSelectedValue"] = ddlVacationsFor.SelectedValue;

                    Response.Redirect("./vacations_summary.aspx?source_page=vacations_all.aspx&vacation_id=" + vacationId.ToString() + "&request_id=" + requestId.ToString() + "&date_to_show=" + ViewState["date_to_show"]);
                }
            }
            else
            {
                vacationsInformationTDS = (VacationsInformationTDS)Session["vacationsInformationTDS"];
                vacationsInformation = (VacationsInformationTDS.VacationsInformationDataTable)Session["vacationsInformation"];

                // For Open Vacation event
                if ((Request.Params["__EVENTTARGET"]) == "openVacation")
                {
                    int vacationId = Int32.Parse(Request.Params.Get("__EVENTARGUMENT").ToString());
                    VacationsInformationDaysInformationGateway vacationsInformationDaysInformationGateway = new VacationsInformationDaysInformationGateway();
                    vacationsInformationDaysInformationGateway.LoadByVacationId(vacationId, Int32.Parse(hdfCompanyId.Value));
                    int requestId = vacationsInformationDaysInformationGateway.GetRequestID(vacationId);

                    DropDownList ddlVacationsFor = (DropDownList)tkrpbLeftMenuAllVacations.FindItemByValue("nbVacationsForDDL").FindControl("ddlVacationsFor");
                    Session["ddlVacationsForSelectedValue"] = ddlVacationsFor.SelectedValue;

                    Response.Redirect("./vacations_summary.aspx?source_page=vacations_all.aspx&vacation_id=" + vacationId.ToString() + "&request_id=" + requestId.ToString() + "&date_to_show=" + ViewState["date_to_show"]);
                }
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
                tkrmTop.Items[0].Visible = false;  // Add button

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

            tkrsVacations.SelectedDate = DateTime.Parse(ViewState["date_to_show"].ToString());
        }
        





        // ////////////////////////////////////////////////////////////////////////
        // AUXILIAR EVENTS
        //

        protected void ddlWorkingLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            VacationsInformationGateway vacationsInformationGateway = new VacationsInformationGateway(vacationsInformationTDS);

            if (hdfIsVacationManager.Value == "False")
            {
                vacationsInformationGateway.LoadByEmployeeIdEmployeeType(Int32.Parse(ViewState["employee_id"].ToString()), ddlWorkingLocation.SelectedValue, Int32.Parse(hdfCompanyId.Value));
            }
            else
            {
                DropDownList ddlVacationsFor = (DropDownList)tkrpbLeftMenuAllVacations.FindItemByValue("nbVacationsForDDL").FindControl("ddlVacationsFor");

                if (ddlVacationsFor.SelectedIndex > 0)
                {
                    vacationsInformationGateway.LoadByEmployeeIdEmployeeType(Int32.Parse(ddlVacationsFor.SelectedValue), ddlWorkingLocation.SelectedValue, Int32.Parse(hdfCompanyId.Value));
                }
                else
                {
                    vacationsInformationGateway.LoadByEmployeeType(ddlWorkingLocation.SelectedValue, Int32.Parse(hdfCompanyId.Value));
                }
            }

            Session["vacationsInformationTDS"] = vacationsInformationTDS;
            Session["vacationsInformation"] = vacationsInformationTDS.VacationsInformation;

            tkrsVacations.DataBind();
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
                case "mAddVacation":
                    if (hdfIsVacationManager.Value == "False")       
                    {
                        Response.Redirect("./vacations_add.aspx?source_page=vacations_all.aspx&employee_id=" + ViewState["employee_id"] + "&date_to_show=" + ViewState["date_to_show"]);
                    }
                    else
                    {
                        if (ddlVacationsFor.SelectedIndex > 0)
                        {
                            Response.Redirect("./vacations_add.aspx?source_page=vacations_all.aspx&employee_id=" + ddlVacationsFor.SelectedValue + "&date_to_show=" + ViewState["date_to_show"]);
                        }
                        else
                        {
                            Response.Redirect("./vacations_add.aspx?source_page=vacations_all.aspx&employee_id=-1&date_to_show=" + ViewState["date_to_show"]);
                        }
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
                case "nbMyViewVacations":
                    Response.Redirect("./vacations_all.aspx?source_page=vacations_all.aspx&employee_id=" + ViewState["employee_id"] + "&date_to_show=" + ViewState["date_to_show"]);
                    break;

                case "nbViewVacations":
                    if (ddlVacationsFor.SelectedIndex > 0)
                    {
                        Response.Redirect("./vacations_all.aspx?source_page=vacations_all.aspx&employee_id=" + ddlVacationsFor.SelectedValue + "&date_to_show=" + ViewState["date_to_show"]);
                    }
                    else
                    {
                        Response.Redirect("./vacations_all.aspx?source_page=vacations_all.aspx&date_to_show=" + ViewState["date_to_show"]);
                    }
                    break;

                case "nbNonWorkingDaysDefinition":
                    Response.Redirect("./vacations_non_working_days_definition.aspx?source_page=vacations_all.aspx&date_to_show=" + ViewState["date_to_show"]);
                    break;

                //case "nbApproveVacationRequests":
                //    if (ddlVacationsFor.SelectedIndex > 0)
                //    {
                //        Response.Redirect("./vacations_approve_vacation_request.aspx?source_page=vacations_all.aspx&employee_id=" + ddlVacationsFor.SelectedValue + "&date_to_show=" + ViewState["date_to_show"]);
                //    }
                //    else
                //    {
                //        Response.Redirect("./vacations_approve_vacation_request.aspx?source_page=vacations_all.aspx&date_to_show=" + ViewState["date_to_show"]);
                //    }
                //    break;

                //case "nbCancelVacationRequests":
                //    if (ddlVacationsFor.SelectedIndex > 0)
                //    {
                //        Response.Redirect("./vacations_cancel_vacation_request.aspx?source_page=vacations_all.aspx&employee_id=" + ddlVacationsFor.SelectedValue + "&date_to_show=" + ViewState["date_to_show"]);
                //    }
                //    else
                //    {
                //        Response.Redirect("./vacations_cancel_vacation_request.aspx?source_page=vacations_all.aspx&date_to_show=" + ViewState["date_to_show"]);
                //    }
                //    break;
            }
        }



        protected void tkrsVacations_NavigationComplete(object sender, SchedulerNavigationCompleteEventArgs e)
        {
            lblTitle.Text = "Vacations Calendar for " + tkrsVacations.SelectedDate.ToString("MMMM") + " " + tkrsVacations.SelectedDate.Year.ToString();
            ViewState["date_to_show"] = tkrsVacations.SelectedDate.ToString();
        }



        protected void tkrsVacations_AppointmentDataBound(object sender, SchedulerEventArgs e)
        {
            int vacationId = Int32.Parse(e.Appointment.ID.ToString());
            int companyId = Int32.Parse(hdfCompanyId.Value);

            VacationsInformationDaysInformation vacationsInformationDaysInformation = new VacationsInformationDaysInformation();
            vacationsInformationDaysInformation.LoadByVacationId(vacationId, companyId);
            VacationsInformationDaysInformationGateway vacationsInformationDaysInformationGateway = new VacationsInformationDaysInformationGateway(vacationsInformationDaysInformation.Data);
            
            int requestId = vacationsInformationDaysInformationGateway.GetRequestID(vacationId);
            string paymentType = vacationsInformationDaysInformationGateway.GetPaymentType(vacationId);

            e.Appointment.ToolTip = paymentType;

            switch (paymentType)
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
        //  PUBLIC METHODS
        //

        public VacationsInformationTDS.VacationsInformationDataTable GetVacationsNew()
        {
            vacationsInformation = ((VacationsInformationTDS)Session["vacationsInformationTDS"]).VacationsInformation;

            return vacationsInformation;
        }

        




        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        private void RegisterClientScripts()
        {
            // Publishing body's OnKeyDown event 
            HtmlGenericControl bodyUnload = (HtmlGenericControl)Page.Master.FindControl("myBody");
            bodyUnload.Attributes.Add("OnKeyDown", "OnKeyDown(event);");

            // Register content variables
            string contentVariables = "";

            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode1", "./vacations_all.js");
        }

        

    }
}