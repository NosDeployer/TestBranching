using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.BL.Resources.Employees;
using LiquiForce.LFSLive.DA.LabourHours.Vacations;
using LiquiForce.LFSLive.BL.LabourHours.Vacations;
using System.Web.UI;
using LiquiForce.LFSLive.DA.Resources.Employees;

namespace LiquiForce.LFSLive.WebUI.LabourHours.Vacations
{
    /// <summary>
    /// vacations_edit
    /// </summary>
    public partial class vacations_edit : System.Web.UI.Page
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
                // Tag page
                // ... for non vacation managers
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

                // Security check
                if (hdfIsVacationManager.Value == "False")
                {                    
                    //if (!(Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_VACATIONS_EDIT"])))
                    //{
                        Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                    //}
                }

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) && ((string)Request.QueryString["vacation_id"] == null) && ((string)Request.QueryString["request_id"] == null) && ((string)Request.QueryString["date_to_show"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in vacations_edit.aspx");
                }

                // Tag page
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfVacationId.Value = (string)Request.QueryString["vacation_id"];
                hdfRequestId.Value = (string)Request.QueryString["request_id"];

                int requestId = Int32.Parse(hdfRequestId.Value);
                int companyId = Int32.Parse(hdfCompanyId.Value);

                ViewState["date_to_show"] = (string)Request.QueryString["date_to_show"];
                DateTime dateToShow = DateTime.Parse((string)Request.QueryString["date_to_show"]);

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

                // Load Data
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


        
        protected void tkrsVacations_FormCreated(object sender, SchedulerFormCreatedEventArgs e)
        {
            if (e.Container.Mode == SchedulerFormMode.Edit)
            {
                int vacationId = Convert.ToInt32(e.Appointment.ID);

                vacationsInformationTDS = (VacationsInformationTDS)Session["vacationsInformationTDS"];
                vacationDaysInformation = (VacationsInformationTDS.DaysInformationDataTable)Session["vacationDaysInformation"];

                VacationsInformationDaysInformationGateway vacationsInformationDaysInformationGateway = new VacationsInformationDaysInformationGateway(vacationsInformationTDS);
                string paymentType = vacationsInformationDaysInformationGateway.GetPaymentType(vacationId);

                RadioButtonList rbtnPaymentType = (RadioButtonList)e.Container.FindControl("rbtnPaymentType");
                rbtnPaymentType.SelectedValue = paymentType;
            }
        }



        protected void tkrsVacations_AppointmentCommand(object sender, AppointmentCommandEventArgs e)
        {
            Page.Validate();

            if (Page.IsValid)
            {
                if (e.CommandName == "Insert" || e.CommandName == "Update")
                {
                    RadioButtonList rbtnPaymentType = (RadioButtonList)e.Container.FindControl("rbtnPaymentType");
                    e.Container.Appointment.Subject = rbtnPaymentType.SelectedValue;
                }
            }
        }



        protected void tkrsVacations_AppointmentInsert(object sender, SchedulerCancelEventArgs e)
        {
            Page.Validate();

            if (Page.IsValid)
            {
                string filterExpression = string.Format("Deleted = 0 AND StartDate = '{0}'", e.Appointment.Start);
                 DataRow[] drarray = vacationsInformationTDS.DaysInformation.Select(filterExpression, "StartDate ASC", DataViewRowState.CurrentRows);
                 bool isValidVacation = true;

                 switch (e.Appointment.Subject)
                 {
                     case "Half Vacation Day":
                         if (drarray.Length > 0)
                         {
                             if ((drarray[0]["PaymentType"].ToString() != "Half Vacation Day") && (drarray[0]["PaymentType"].ToString() != "Unpaid Leave Half Day"))
                             {
                                 isValidVacation = false;
                             }
                             else
                             {
                                 if (drarray.Length > 1)
                                 {
                                     isValidVacation = false;
                                 }
                             }
                         }
                         break;

                     case "Full Vacation Day":
                         if (drarray.Length > 0)
                         {
                             isValidVacation = false;
                         }
                         break;

                     case "Unpaid Leave Full Day":
                         if (drarray.Length > 0)
                         {
                             isValidVacation = false;
                         }
                         break;

                     case "Unpaid Leave Half Day":
                         if (drarray.Length > 0)
                         {
                             if ((drarray[0]["PaymentType"].ToString() != "Unpaid Leave Half Day") && (drarray[0]["PaymentType"].ToString() != "Half Vacation Day"))
                             {
                                 isValidVacation = false;
                             }
                             else
                             {
                                 if (drarray.Length > 1)
                                 {
                                     isValidVacation = false;
                                 }
                             }
                         }
                         break;
                 }

                 // Verify non working days
                 if (isValidVacation)
                 {
                     isValidVacation = LiquiForce.LFSLive.BL.LabourHours.ProjectTime.ProjectTime.ValidateIfNonWorkingDay(e.Appointment.Start, Int32.Parse(hdfEmployeeId.Value), Int32.Parse(hdfCompanyId.Value));

                     if (!isValidVacation)
                     {
                         e.Cancel = true;
                         ScriptManager.RegisterStartupScript(Page, GetType(), "alert", "alert('You can not take vacations on this day, this is a non working day. Please verify your data.');", true);
                     }
                     else
                     {
                         // Verify existent vacations
                         isValidVacation = LiquiForce.LFSLive.BL.LabourHours.ProjectTime.ProjectTime.ValidateIfExistsAVacation(e.Appointment.Start, Int32.Parse(hdfEmployeeId.Value), Int32.Parse(hdfCompanyId.Value));

                         if (!isValidVacation)
                         {
                             e.Cancel = true;
                             ScriptManager.RegisterStartupScript(Page, GetType(), "alert", "alert('You have a vacation planned for this day. Please verify your data.');", true);
                         }
                         else
                         {
                             VacationsInformationGateway vacationsInformationGateway = new VacationsInformationGateway();
                             int amountHalfDays = vacationsInformationGateway.IsHalfVacationDay(e.Appointment.Start, Int32.Parse(hdfEmployeeId.Value), Int32.Parse(hdfCompanyId.Value));

                             if (amountHalfDays > 0)
                             {
                                 if ((e.Appointment.Subject == "Unpaid Leave Full Day") || (e.Appointment.Subject == "Full Vacation Day"))
                                 {
                                     isValidVacation = false;
                                     e.Cancel = true;
                                     ScriptManager.RegisterStartupScript(Page, GetType(), "alert", "alert('You have a half vacation day planned for this day. Please verify your data.');", true);
                                 }
                             }
                         }
                     }
                 }
                 else
                 {
                     e.Cancel = true;
                     ScriptManager.RegisterStartupScript(Page, GetType(), "alert", "alert('You already have a vacation request for this day please verify your data.');", true);
                 }
                
                 if (isValidVacation)
                 {
                     double takenDay = 0;
                     switch (e.Appointment.Subject)
                     {
                         case "Half Vacation Day":
                             takenDay = 0.5;
                             break;

                         case "Full Vacation Day":
                             takenDay = 1;
                             break;
                     }

                     VacationsInformationDaysInformation vacationsInformationDaysInformation = new VacationsInformationDaysInformation(vacationsInformationTDS);
                     vacationsInformationDaysInformation.Insert(Int32.Parse(hdfRequestId.Value), e.Appointment.Start, e.Appointment.Start, e.Appointment.Subject, e.Appointment.Subject, false, Int32.Parse(hdfCompanyId.Value));

                     // Store dataset
                     Session["vacationsInformationTDS"] = vacationsInformationTDS;
                     Session["vacationDaysInformation"] = vacationsInformationTDS.DaysInformation;

                     tkrsVacations.DataBind();

                     double newRemainingVacationDays = double.Parse(tbxRemaining.Text) - takenDay;
                     tbxRemaining.Text = newRemainingVacationDays.ToString();
                         
                     if (double.Parse(tbxRemaining.Text) < 0)
                     {
                         ScriptManager.RegisterStartupScript(Page, GetType(), "alert", "alert('You are requesting more vacation than the entitlement. If you continue this days will be discounted from next years total.');", true);
                     }
                 }
            }
            else
            {
                e.Cancel = true;
            }
        }



        protected void tkrsVacations_AppointmentUpdate(object sender, AppointmentUpdateEventArgs e)
        {
            Page.Validate();

            if (Page.IsValid)
            {
                // Validate if the user can delete older vacations
                if (!(Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_VACATIONS_FULL_EDITING"])) && (e.Appointment.Start < DateTime.Now))
                {
                    e.Appointment.AllowEdit = false;
                    ScriptManager.RegisterStartupScript(Page, GetType(), "alert", "alert('You can not edit older vacations. Please contact your system adminitrator.');", true);
                    e.Cancel = true;
                }
                else
                {
                    Page.Validate();
                    if (Page.IsValid)
                    {
                        if (e.Cancel == false)
                        {
                            // Edit information
                            int vacationId = Convert.ToInt32(e.ModifiedAppointment.ID);

                            double takenDay = 0;

                            VacationsInformationDaysInformationGateway vacationsInformationDaysInformationGateway = new VacationsInformationDaysInformationGateway(vacationsInformationTDS);
                            string oldPaymentType = vacationsInformationDaysInformationGateway.GetPaymentType(vacationId);


                            switch (e.ModifiedAppointment.Subject)
                            {
                                case "Half Vacation Day":
                                    if (oldPaymentType == "Full Vacation Day")
                                    {
                                        takenDay = -0.5;
                                    }
                                    else
                                    {
                                        if (oldPaymentType == "Unpaid Leave Full Day")
                                        {
                                            takenDay = 0.5;
                                        }
                                        else
                                        {
                                            if (oldPaymentType == "Unpaid Leave Half Day")
                                            {
                                                takenDay = 0.0;
                                            }
                                        }
                                    }
                                    break;

                                case "Full Vacation Day":
                                    if (oldPaymentType == "Half Vacation Day")
                                    {
                                        takenDay = 0.5;
                                    }
                                    else
                                    {
                                        if (oldPaymentType == "Unpaid Leave Full Day")
                                        {
                                            takenDay = 1;
                                        }
                                        else
                                        {
                                            if (oldPaymentType == "Unpaid Leave Half Day")
                                            {
                                                takenDay = 1;
                                            }
                                        }
                                    }
                                    break;

                                case "Unpaid Leave Full Day":
                                    if (oldPaymentType == "Full Vacation Day")
                                    {
                                        takenDay = -1;
                                    }
                                    else
                                    {
                                        if (oldPaymentType == "Half Vacation Day")
                                        {
                                            takenDay = -0.5;
                                        }
                                        else
                                        {
                                            if (oldPaymentType == "Unpaid Leave Half Day")
                                            {
                                                takenDay = 0.0;
                                            }
                                        }
                                    }
                                    break;

                                case "Unpaid Leave Half Day":
                                    if (oldPaymentType == "Full Vacation Day")
                                    {
                                        takenDay = -1;
                                    }
                                    else
                                    {
                                        if (oldPaymentType == "Half Vacation Day")
                                        {
                                            takenDay = -0.5;
                                        }
                                        else
                                        {
                                            if (oldPaymentType == "Unpaid Leave Full Day")
                                            {
                                                takenDay = 0.0;
                                            }
                                        }
                                    }
                                    break;
                            }

                            VacationsInformationDaysInformation vacationsInformationDaysInformation = new VacationsInformationDaysInformation(vacationsInformationTDS);
                            vacationsInformationDaysInformation.Update(vacationId, e.ModifiedAppointment.Subject);

                            // Store dataset
                            Session["vacationsInformationTDS"] = vacationsInformationTDS;
                            Session["vacationDaysInformation"] = vacationsInformationTDS.DaysInformation;

                            tkrsVacations.DataBind();

                            double newRemainingVacationDays = double.Parse(tbxRemaining.Text) - takenDay;
                            tbxRemaining.Text = newRemainingVacationDays.ToString();

                            if (double.Parse(tbxRemaining.Text) < 0)
                            {
                                ScriptManager.RegisterStartupScript(Page, GetType(), "alert", "alert('You are requesting more vacation than the assigned. If you continue this will be discounted the next year. Please review your information.');", true);
                            }
                        }
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
            }
            else
            {
                e.Cancel = true;
            }
        }



        protected void tkrsVacations_AppointmentDelete(object sender, SchedulerCancelEventArgs e)
        {
            Page.Validate();

            if (Page.IsValid)
            {
                // Validate if the user can delete older vacations
                if ((!(Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_VACATIONS_FULL_EDITING"]))) && (e.Appointment.Start < DateTime.Now))
                {
                    e.Appointment.AllowDelete = false;
                    ScriptManager.RegisterStartupScript(Page, GetType(), "alert", "alert('You can not delete older vacations. Please contact your system adminitrator.');", true);
                    e.Cancel = true;

                }
                else
                {
                    int vacationId = Convert.ToInt32(e.Appointment.ID);
                    double takenDay = 0;

                    VacationsInformationDaysInformationGateway vacationsInformationDaysInformationGateway = new VacationsInformationDaysInformationGateway(vacationsInformationTDS);
                    string oldPaymentType = vacationsInformationDaysInformationGateway.GetPaymentType(vacationId);

                    switch (oldPaymentType)
                    {
                        case "Half Vacation Day":
                            takenDay = 0.5;
                            break;

                        case "Full Vacation Day":
                            takenDay = 1;
                            break;
                    }

                    VacationsInformationDaysInformation vacationsInformationDaysInformation = new VacationsInformationDaysInformation(vacationsInformationTDS);
                    vacationsInformationDaysInformation.Delete(vacationId);

                    double newRemainingVacationDays = double.Parse(tbxRemaining.Text) + takenDay;
                    tbxRemaining.Text = newRemainingVacationDays.ToString();

                    // Store dataset
                    Session["vacationsInformationTDS"] = vacationsInformationTDS;
                    Session["vacationDaysInformation"] = vacationsInformationTDS.DaysInformation;

                    tkrsVacations.DataBind();
                }
            }
            else
            {
                e.Cancel = true;
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
                case "mSave":
                    //DataRow[] drarray;
                    //drarray = vacationsInformationTDS.DaysInformation.Select("Deleted = 0", "StartDate ASC", DataViewRowState.CurrentRows);
                    //if (drarray.Length <= 0)
                    //{                                           
                    //    int requestId = Int32.Parse(hdfRequestId.Value);
                    //    VacationsInformationRequestsInformation vacationsInformationRequestsInformation = new VacationsInformationRequestsInformation(vacationsInformationTDS);
                    //    vacationsInformationRequestsInformation.Delete(requestId);
                    //    Session["vacationsInformationTDS"] = vacationsInformationTDS;

                        Save();
                    //}
                    break;

                case "mCancel":
                    if (ddlVacationsFor.SelectedIndex > 0)
                    {
                        Response.Redirect("./vacations_summary.aspx?source_page=vacations_edit.aspx&vacation_id=" + hdfVacationId.Value + "&request_id=" + hdfRequestId.Value + "&employee_id=" + ddlVacationsFor.SelectedValue + "&date_to_show=" + ViewState["date_to_show"]);
                    }
                    else
                    {
                        Response.Redirect("./vacations_summary.aspx?source_page=vacations_edit.aspx&vacation_id=" + hdfVacationId.Value + "&request_id=" + hdfRequestId.Value + "&date_to_show=" + ViewState["date_to_show"]);
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
                        Response.Redirect("./vacations_all.aspx?source_page=vacations_edit.aspx&employee_id=" + ddlVacationsFor.SelectedValue + "&date_to_show=" + ViewState["date_to_show"]);
                    }
                    else
                    {
                        Response.Redirect("./vacations_all.aspx?source_page=vacations_edit.aspx&date_to_show=" + ViewState["date_to_show"]);
                    }
                    break;

                case "nbNonWorkingDaysDefinition":
                    Response.Redirect("./vacations_non_working_days_definition.aspx?source_page=vacations_edit.aspx" + "&date_to_show=" + ViewState["date_to_show"]);
                    break;

                case "nbApproveVacationRequests":
                    if (ddlVacationsFor.SelectedIndex > 0)
                    {
                        Response.Redirect("./vacations_approve_vacation_request.aspx?source_page=vacations_edit.aspx&employee_id=" + ddlVacationsFor.SelectedValue + "&date_to_show=" + ViewState["date_to_show"]);
                    }
                    else
                    {
                        Response.Redirect("./vacations_approve_vacation_request.aspx?source_page=vacations_edit.aspx&date_to_show=" + ViewState["date_to_show"]);
                    }
                    break;

                case "nbCancelVacationRequests":
                    if (ddlVacationsFor.SelectedIndex > 0)
                    {
                        Response.Redirect("./vacations_cancel_vacation_request.aspx?source_page=vacations_edit.aspx&employee_id=" + ddlVacationsFor.SelectedValue + "&date_to_show=" + ViewState["date_to_show"]);
                    }
                    else
                    {
                        Response.Redirect("./vacations_cancel_vacation_request.aspx?source_page=vacations_edit.aspx&date_to_show=" + ViewState["date_to_show"]);
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



        public void DummyVacationsNew(int VacationID)
        {
        }



        public void DummyVacationsNew(string PaymentType, DateTime StartDate, DateTime EndDate)
        {
        }



        public void DummyVacationsNew(string PaymentType, DateTime StartDate, DateTime EndDate, int VacationID)
        {
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
            contentVariables += "var tkrmTopId = '" + tkrmTop.ClientID + "';"; 
            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode1", "./vacations_edit.js");
        }



        private void Save()
        {
            PostPageChanges();

            // Update database
            UpdateDatabase();

            DropDownList ddlVacationsFor = (DropDownList)tkrpbLeftMenuAllVacations.FindItemByValue("nbVacationsForDDL").FindControl("ddlVacationsFor");
            Session["ddlVacationsForSelectedValue"] = ddlVacationsFor.SelectedValue;

            DataRow[] drarray;
            drarray = vacationsInformationTDS.DaysInformation.Select("Deleted = 0", "StartDate ASC", DataViewRowState.CurrentRows);
            
            // If there are no vacations
            if (drarray.Length <= 0)
            {
                Response.Redirect("./vacations_all.aspx?source_page=vacations_summary.aspx&date_to_show=" + ViewState["date_to_show"]);
            }
            else
            {
                if (ddlVacationsFor.SelectedIndex > 0)
                {
                    Response.Redirect("./vacations_summary.aspx?source_page=vacations_edit.aspx&vacation_id=" + hdfVacationId.Value + "&request_id=" + hdfRequestId.Value + "&employee_id=" + ddlVacationsFor.SelectedValue + "&date_to_show=" + ViewState["date_to_show"]);
                }
                else
                {
                    Response.Redirect("./vacations_summary.aspx?source_page=vacations_edit.aspx&vacation_id=" + hdfVacationId.Value + "&request_id=" + hdfRequestId.Value + "&date_to_show=" + ViewState["date_to_show"]);
                }
            }
        }



        private void PostPageChanges()
        {
            VacationsInformationRequestsInformation vacationsInformationRequestsInformation = new VacationsInformationRequestsInformation(vacationsInformationTDS);
            DataRow[] drarray;
            drarray = vacationsInformationTDS.DaysInformation.Select("Deleted = 0", "StartDate ASC", DataViewRowState.CurrentRows);
            
            // If there are no vacations
            if (drarray.Length <= 0)
            {
                vacationsInformationRequestsInformation.Delete(Int32.Parse(hdfRequestId.Value));
            }
            else
            {
                // If there are vacations
                vacationsInformationRequestsInformation.Update(Int32.Parse(hdfRequestId.Value), GetStartDate(), GetEndDate(), GetTotalPaidVacationDays(), tbxComments.Text, GetDetails());
            }

            // Store dataset
            Session["vacationsInformationTDS"] = vacationsInformationTDS;
            Session["vacationDaysInformation"] = vacationsInformationTDS.DaysInformation;
        }



        private DateTime GetStartDate()
        {
            DateTime startDate = new DateTime();

            DataRow[] drarray;
            drarray = vacationsInformationTDS.DaysInformation.Select("Deleted = 0", "StartDate ASC", DataViewRowState.CurrentRows);
            if (drarray.Length > 0)
            {
                startDate = DateTime.Parse(drarray[0]["StartDate"].ToString());
            }

            return startDate;
        }



        private DateTime GetEndDate()
        {
            DateTime endDate = new DateTime();

            DataRow[] drarray;
            drarray = vacationsInformationTDS.DaysInformation.Select("Deleted = 0", "EndDate DESC", DataViewRowState.CurrentRows);
            if (drarray.Length > 0)
            {
                endDate = DateTime.Parse(drarray[0]["EndDate"].ToString());
            }

            return endDate;
        }



        private double GetTotalPaidVacationDays()
        {
            double totalPaidVacationDays = 0;

            foreach (VacationsInformationTDS.DaysInformationRow row in (VacationsInformationTDS.DaysInformationDataTable)vacationsInformationTDS.DaysInformation)
            {
                if (!row.Deleted)
                {
                    switch (row.PaymentType)
                    {
                        case "Half Vacation Day":
                            totalPaidVacationDays += 0.5;
                            break;

                        case "Full Vacation Day":
                            totalPaidVacationDays++;
                            break;
                    }
                }
            }

            return totalPaidVacationDays;
        }



        private string GetDetails()
        {
            string details = "";

            DataRow[] drarray = vacationsInformationTDS.DaysInformation.Select("Deleted = 0", "StartDate ASC", DataViewRowState.CurrentRows);

            foreach (DataRow row in drarray)
            {
                if (!Convert.ToBoolean(row["Deleted"].ToString()))
                {
                    DateTime startDate = DateTime.Parse(row["StartDate"].ToString());

                    switch (row["PaymentType"].ToString())
                    {                     
                        case "Full Vacation Day":
                            details += startDate.ToString("MMM/dd") + " Full Vacation Day, ";
                            break;

                        case "Half Vacation Day":
                            details += startDate.ToString("MMM/dd") + " Half Vacation Day, ";
                            break;

                        case "Unpaid Leave Full Day":
                            details += startDate.ToString("MMM/dd") + " Unpaid Leave Full Day, ";
                            break;

                        case "Unpaid Leave Half Day":
                            details += startDate.ToString("MMM/dd") + " Unpaid Leave Half Day, ";
                            break;
                    }
                }
            }

            if (details.Length > 0)
            {
                details = details.Remove(details.Length - 2, 2);
            }

            return details;
        }



        private void UpdateDatabase()
        {
            DB.Open();
            DB.BeginTransaction();
            try
            {
                double newTakenDays = double.Parse(tbxMax.Text) - double.Parse(tbxRemaining.Text);
                VacationsInformationRequestsInformation vacationsInformationRequestsInformation = new VacationsInformationRequestsInformation(vacationsInformationTDS);
                vacationsInformationRequestsInformation.SaveForEdit(newTakenDays);

                VacationsInformationDaysInformation vacationsInformationDaysInformation = new VacationsInformationDaysInformation(vacationsInformationTDS);
                vacationsInformationDaysInformation.Save();

                vacationsInformationTDS.AcceptChanges();

                // Store dataset
                Session["vacationsInformationTDS"] = vacationsInformationTDS;
                Session["vacationDaysInformation"] = vacationsInformationTDS.DaysInformation;

                DB.CommitTransaction();
            }
            catch (Exception ex)
            {
                DB.RollbackTransaction();

                string url = string.Format("./../../error_page.aspx?error={0}", ex.Message.Replace('\n', ' '));
                Response.Redirect(url);
            }
        }

        

        



    }
}