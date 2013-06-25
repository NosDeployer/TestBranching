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
    /// vacations_add
    /// </summary>
    public partial class vacations_add : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected VacationsAddTDS vacationsAddTDS;
        protected VacationsAddTDS.DaysInformationDataTable vacationDaysInformation;






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
                //if (!(Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_VACATIONS_ADD"])))
                //{
                if (hdfIsVacationManager.Value == "False")
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }
                //}
                
                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) && ((string)Request.QueryString["employee_id"] == null) && ((string)Request.QueryString["date_to_show"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in vacations_add.aspx");
                }

                // Tag page
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfEmployeeId.Value = (string)Request.QueryString["employee_id"];

                Session.Remove("vacationsAddTDS");
                
                ViewState["date_to_show"] = (string)Request.QueryString["date_to_show"];
                DateTime dateToShow = DateTime.Parse((string)Request.QueryString["date_to_show"]);

                // Prepare initial data  
                // ... For employee list                

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

                DropDownList ddlVacationsFor = (DropDownList)tkrpbLeftMenuAllVacations.FindItemByValue("nbVacationsForDDL").FindControl("ddlVacationsFor");
                ddlVacationsFor.DataSource = employeeList.Table;
                ddlVacationsFor.DataValueField = "EmployeeID";
                ddlVacationsFor.DataTextField = "FullName";
                ddlVacationsFor.DataBind();
                ddlVacationsFor.SelectedValue = Session["ddlVacationsForSelectedValue"].ToString();

                // ... For employee ddl
                ddlEmployee.DataSource = employeeList.Table;
                ddlEmployee.DataValueField = "EmployeeID";
                ddlEmployee.DataTextField = "FullName";
                ddlEmployee.DataBind();

                vacationsAddTDS = new VacationsAddTDS();
                vacationDaysInformation = new VacationsAddTDS.DaysInformationDataTable();

                // If there is a selected employee
                if (hdfEmployeeId.Value != "-1")
                {
                    int companyId = Int32.Parse(hdfCompanyId.Value);
                    int employeeId = Int32.Parse(hdfEmployeeId.Value);

                    // ... Verify basic information
                    VacationsAddBasicInformationGateway vacationsAddBasicInformationGateway = new VacationsAddBasicInformationGateway(vacationsAddTDS);
                    vacationsAddBasicInformationGateway.LoadByEmployeeIdYear(employeeId, dateToShow.Year, companyId);
                    
                    if (vacationsAddBasicInformationGateway.Table.Rows.Count == 0)
                    {
                        Response.Redirect("./../../error_page.aspx?error=" + "The team member don't have total paid day vacations defined in the system. Contact your system administrator.");
                    }
                    else
                    {
                        LoadData(employeeId, dateToShow.Year);

                        // ... Load non working days
                        EmployeeGateway employeeGateway = new EmployeeGateway();
                        employeeGateway.LoadByEmployeeId(employeeId);

                        string employeeType = employeeGateway.GetType(employeeId);
                        int companyLevelId = 3; //USA

                        if (employeeType.Contains("CA"))
                        {
                            companyLevelId = 2;//Canada
                        }

                        VacationsAddDaysInformation vacationsAddDaysInformation = new VacationsAddDaysInformation(vacationsAddTDS);
                        //vacationsAddDaysInformation.LoadNonWorkingDaysByCompanyLevelId(companyLevelId, companyId);

                        // ... Load previews vacations
                        //vacationsAddDaysInformation.LoadPreviousVacations(employeeId, companyId);
                        vacationsAddDaysInformation.LoadDataForVacationsAdd(companyLevelId, employeeId, companyId);
                    }
                }

                ViewState["employee_id"] = hdfEmployeeId.Value;

                Session["vacationsAddTDS"] = vacationsAddTDS;
                Session["vacationDaysInformation"] = vacationsAddTDS.DaysInformation;

                Page.DataBind();
            }
            else
            {
                vacationsAddTDS = (VacationsAddTDS)Session["vacationsAddTDS"];
                vacationDaysInformation = (VacationsAddTDS.DaysInformationDataTable)Session["vacationDaysInformation"];

                hdfEmployeeId.Value = ViewState["employee_id"].ToString();
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

            if (hdfEmployeeId.Value == "-1")
            {
                tkrsVacations.AllowInsert = false;
                tkrsVacations.AllowEdit = false;
                tkrsVacations.AllowDelete = false;
                tbxEmployee.Visible = false;
                tbxComments.ReadOnly = true;
                ddlEmployee.Visible = true;
            }
            else
            {
                tkrsVacations.AllowInsert = true;
                tkrsVacations.AllowEdit = true;
                tkrsVacations.AllowDelete = true;
                tbxEmployee.Visible = true;
                tbxComments.ReadOnly = false;
                ddlEmployee.Visible = false;
            }

            tkrsVacations.SelectedDate = DateTime.Parse(ViewState["date_to_show"].ToString());
        }






        // ////////////////////////////////////////////////////////////////////////
        // AUXILIAR EVENTS
        //
        
        protected void ddlEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["date_to_show"] = tkrsVacations.SelectedDate.ToString();
            ViewState["employee_id"] = ddlEmployee.SelectedValue;

            DateTime dateToShow = DateTime.Parse((string)ViewState["date_to_show"]);
            int companyId = Int32.Parse(hdfCompanyId.Value);
            hdfEmployeeId.Value = ddlEmployee.SelectedValue.ToString();
            int employeeId = Int32.Parse(hdfEmployeeId.Value);

            // Reload Data
            VacationsAddBasicInformationGateway vacationsAddBasicInformationGateway = new VacationsAddBasicInformationGateway(vacationsAddTDS);
            vacationsAddBasicInformationGateway.LoadByEmployeeIdYear(employeeId, dateToShow.Year, companyId);
            
            if (vacationsAddBasicInformationGateway.Table.Rows.Count == 0)
            {
                Response.Redirect("./../../error_page.aspx?error=" + "The team member don't have total paid day vacations defined in the system. Contact your system administrator.");
            }
            else
            {
                LoadData(employeeId, dateToShow.Year);

                // ... Load non working days
                EmployeeGateway employeeGateway = new EmployeeGateway();
                employeeGateway.LoadByEmployeeId(employeeId);

                string employeeType = employeeGateway.GetType(employeeId);
                int companyLevelId = 3; //USA

                if (employeeType.Contains("CA"))
                {
                    companyLevelId = 2;//Canada
                }

                VacationsAddDaysInformation vacationsAddDaysInformation = new VacationsAddDaysInformation(vacationsAddTDS);
                //vacationsAddDaysInformation.LoadNonWorkingDaysByCompanyLevelId(companyLevelId, companyId);

                // ... Load previews vacations
                //vacationsAddDaysInformation.LoadPreviousVacations(employeeId, companyId);
                vacationsAddDaysInformation.LoadDataForVacationsAdd(companyLevelId, employeeId, companyId);
            }

            Session["vacationsAddTDS"] = vacationsAddTDS;
            Session["vacationDaysInformation"] = vacationsAddTDS.DaysInformation;
        }



        protected void tkrsVacations_NavigationComplete(object sender, SchedulerNavigationCompleteEventArgs e)
        {
            DateTime dateToShowOld = DateTime.Parse((string)ViewState["date_to_show"]);

            ViewState["date_to_show"] = tkrsVacations.SelectedDate.ToString();
            DateTime dateToShowNew = DateTime.Parse((string)ViewState["date_to_show"]);
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int employeeId = Int32.Parse(hdfEmployeeId.Value);

            if (dateToShowNew.Year != dateToShowOld.Year)
            {
                VacationsAddBasicInformationGateway vacationsAddBasicInformationGateway = new VacationsAddBasicInformationGateway(vacationsAddTDS);
                vacationsAddBasicInformationGateway.LoadByEmployeeIdYear(employeeId, dateToShowNew.Year, companyId);

                if (vacationsAddBasicInformationGateway.Table.Rows.Count == 0)
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "The team member don't have paid day vacations defined in the system. Contact your system administrator.");
                }
                else
                {
                    LoadData(Int32.Parse(hdfEmployeeId.Value), dateToShowNew.Year);

                    // ... Load non working days
                    EmployeeGateway employeeGateway = new EmployeeGateway();
                    employeeGateway.LoadByEmployeeId(employeeId);

                    string employeeType = employeeGateway.GetType(employeeId);
                    int companyLevelId = 3; //USA

                    if (employeeType.Contains("CA"))
                    {
                        companyLevelId = 2;//Canada
                    }

                    VacationsAddDaysInformation vacationsAddDaysInformation = new VacationsAddDaysInformation(vacationsAddTDS);
                    //vacationsAddDaysInformation.LoadNonWorkingDaysByCompanyLevelId(companyLevelId, companyId);

                    // ... Load previews vacations
                    //vacationsAddDaysInformation.LoadPreviousVacations(employeeId, companyId);
                    vacationsAddDaysInformation.LoadDataForVacationsAdd(companyLevelId, employeeId, companyId);                   
                }

                Session["vacationsAddTDS"] = vacationsAddTDS;
                Session["vacationDaysInformation"] = vacationsAddTDS.DaysInformation;
            }
        }
        


        protected void tkrsVacations_FormCreated(object sender, SchedulerFormCreatedEventArgs e)
        {
            if (e.Container.Mode == SchedulerFormMode.Edit)
            {
                int vacationId = Convert.ToInt32(e.Appointment.ID);

                vacationsAddTDS = (VacationsAddTDS)Session["vacationsAddTDS"];
                vacationDaysInformation = (VacationsAddTDS.DaysInformationDataTable)Session["vacationDaysInformation"];

                VacationsAddDaysInformationGateway vacationsAddDaysInformationGateway = new VacationsAddDaysInformationGateway(vacationsAddTDS);
                string paymentType = vacationsAddDaysInformationGateway.GetPaymentType(vacationId);
                
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
                 DataRow[] drarray = vacationsAddTDS.DaysInformation.Select(filterExpression, "StartDate ASC", DataViewRowState.CurrentRows);
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
                     
                     VacationsAddDaysInformation vacationsAddDaysInformation = new VacationsAddDaysInformation(vacationsAddTDS);
                     vacationsAddDaysInformation.Insert(1, e.Appointment.Start, e.Appointment.Start, e.Appointment.Subject, e.Appointment.Subject, false, Int32.Parse(hdfCompanyId.Value));

                     // Store dataset
                     Session["vacationsAddTDS"] = vacationsAddTDS;
                     Session["vacationDaysInformation"] = vacationsAddTDS.DaysInformation;

                     tkrsVacations.DataBind();

                     double newRemainingVacationDays = double.Parse(tbxRemaining.Text) - takenDay;
                     tbxRemaining.Text = newRemainingVacationDays.ToString();
                     
                     if (double.Parse(tbxRemaining.Text) < 0)
                     {
                         ScriptManager.RegisterStartupScript(Page, GetType(), "alert", "alert('You are requesting more vacation than the entitlement. If you continue these days will be discounted from next years total.');", true);
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
                int vacationId = Convert.ToInt32(e.ModifiedAppointment.ID);

                double takenDay = 0;

                VacationsAddDaysInformationGateway vacationsAddDaysInformationGateway = new VacationsAddDaysInformationGateway(vacationsAddTDS);
                string oldPaymentType = vacationsAddDaysInformationGateway.GetPaymentType(vacationId);

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
                        }
                        break;
                }

                VacationsAddDaysInformation vacationsAddDaysInformation = new VacationsAddDaysInformation(vacationsAddTDS);
                vacationsAddDaysInformation.Update(vacationId, e.ModifiedAppointment.Subject);

                // Store dataset
                Session["vacationsAddTDS"] = vacationsAddTDS;
                Session["vacationDaysInformation"] = vacationsAddTDS.DaysInformation;

                tkrsVacations.DataBind();

                double newRemainingVacationDays = double.Parse(tbxRemaining.Text) - takenDay;
                tbxRemaining.Text = newRemainingVacationDays.ToString();
                
                if (double.Parse(tbxRemaining.Text) < 0)
                {
                    ScriptManager.RegisterStartupScript(Page, GetType(), "alert", "alert('You are requesting more vacation than the entitlement. If you continue these days will be discounted from next years total .');", true);
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
                int vacationId = Convert.ToInt32(e.Appointment.ID);
                double takenDay = 0;

                VacationsAddDaysInformationGateway vacationsAddDaysInformationGateway = new VacationsAddDaysInformationGateway(vacationsAddTDS);
                string oldPaymentType = vacationsAddDaysInformationGateway.GetPaymentType(vacationId);

                switch (oldPaymentType)
                {
                    case "Half Vacation Day":
                        takenDay = 0.5;
                        break;

                    case "Full Vacation Day":
                        takenDay = 1;
                        break;
                }

                VacationsAddDaysInformation vacationsAddDaysInformation = new VacationsAddDaysInformation(vacationsAddTDS);
                vacationsAddDaysInformation.Delete(vacationId);

                double newRemainingVacationDays = double.Parse(tbxRemaining.Text) + takenDay;
                tbxRemaining.Text = newRemainingVacationDays.ToString();

                // Store dataset
                Session["vacationsAddTDS"] = vacationsAddTDS;
                Session["vacationDaysInformation"] = vacationsAddTDS.DaysInformation;

                tkrsVacations.DataBind();
            }
            else
            {
                e.Cancel = true;
            }
        }


        protected void tkrsVacations_AppointmentDataBound(object sender, SchedulerEventArgs e)
        {
            // For old vacations           
            if (e.Appointment.ToolTip != "")
            {
                int vacationId = Int32.Parse(e.Appointment.ID.ToString());
                int companyId = Int32.Parse(hdfCompanyId.Value);

                VacationsAddDaysInformationGateway vacationsAddDaysInformationGatewayForReview = new VacationsAddDaysInformationGateway(vacationsAddTDS);
                string paymentType = vacationsAddDaysInformationGatewayForReview.GetPaymentType(vacationId);
                bool inDataBase = vacationsAddDaysInformationGatewayForReview.GetInDatabase(vacationId);

                e.Appointment.ToolTip = paymentType;

                switch (paymentType)
                {
                    case "Unpaid Leave Full Day":
                        if (!inDataBase)
                        {
                            e.Appointment.CssClass = "rsCategorySkyBlue2";
                        }
                        else
                        {
                            e.Appointment.CssClass = "rsCategoryRed2";
                            e.Appointment.AllowDelete = false;
                            e.Appointment.AllowEdit = false;
                        }
                        break;

                    case "Unpaid Leave Half Day":
                        if (!inDataBase)
                        {
                            e.Appointment.CssClass = "rsCategorySkyBlue2";
                        }
                        else
                        {
                            e.Appointment.CssClass = "rsCategoryRed2";
                            e.Appointment.AllowDelete = false;
                            e.Appointment.AllowEdit = false;
                        }
                        break;

                    case "Full Vacation Day":
                        if (!inDataBase)
                        {
                            e.Appointment.CssClass = "rsCategoryBlue2";
                        }
                        else
                        {
                            e.Appointment.CssClass = "rsCategoryGreen2";
                            e.Appointment.AllowDelete = false;
                            e.Appointment.AllowEdit = false;
                        }
                        break;

                    case "Half Vacation Day":
                        if (!inDataBase)
                        {
                            e.Appointment.CssClass = "rsCategoryBlue2";
                        }
                        else
                        {
                            e.Appointment.CssClass = "rsCategoryGreen2";
                            e.Appointment.AllowDelete = false;
                            e.Appointment.AllowEdit = false;
                        }
                        break;

                    default:
                        e.Appointment.CssClass = "rsCategoryGray2";
                        e.Appointment.AllowDelete = false;
                        e.Appointment.AllowEdit = false;
                        break;
                }
            }
            else
            { 
                // For new vacations
                switch (e.Appointment.Subject)
                {
                    case "Unpaid Leave Full Day":                        
                        e.Appointment.CssClass = "rsCategorySkyBlue2";                        
                        break;

                    case "Unpaid Leave Half Day":                        
                        e.Appointment.CssClass = "rsCategorySkyBlue2";                        
                        break;

                    case "Full Vacation Day":
                         e.Appointment.CssClass = "rsCategoryBlue2";
                         break;

                    case "Half Vacation Day":                        
                        e.Appointment.CssClass = "rsCategoryBlue2";                        
                        break;

                    default:
                        e.Appointment.CssClass = "rsCategoryGray2";
                        e.Appointment.AllowDelete = false;
                        e.Appointment.AllowEdit = false;
                        break;
                }
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
                    DataRow[] drarray;
                    drarray = vacationsAddTDS.DaysInformation.Select("Deleted = 0", "StartDate ASC", DataViewRowState.CurrentRows);
                    if (drarray.Length > 0)
                    {
                        Save();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, GetType(), "alert", "alert('You do not have any vacations, this request won not be saved. Please verify your data.');", true);
                    }
                    break;

                case "mCancel":
                    if (ddlVacationsFor.SelectedIndex > 0)
                    {
                        Response.Redirect("./vacations_all.aspx?source_page=vacations_add.aspx&employee_id=" + ddlVacationsFor.SelectedValue + "&date_to_show=" + ViewState["date_to_show"]);
                    }
                    else
                    {
                        Response.Redirect("./vacations_all.aspx?source_page=vacations_add.aspx&date_to_show=" + ViewState["date_to_show"]);
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
                        Response.Redirect("./vacations_all.aspx?source_page=vacations_add.aspx&employee_id=" + ddlVacationsFor.SelectedValue + "&date_to_show=" + ViewState["date_to_show"]);
                    }
                    else
                    {
                        Response.Redirect("./vacations_all.aspx?source_page=vacations_add.aspx&date_to_show=" + ViewState["date_to_show"]);
                    }
                    break;

                case "nbNonWorkingDaysDefinition":
                    Response.Redirect("./vacations_non_working_days_definition.aspx?source_page=vacations_add.aspx" + "&date_to_show=" + ViewState["date_to_show"]);
                    break;

                case "nbApproveVacationRequests":
                    if (ddlVacationsFor.SelectedIndex > 0)
                    {
                        Response.Redirect("./vacations_approve_vacation_request.aspx?source_page=vacations_add.aspx&employee_id=" + ddlVacationsFor.SelectedValue + "&date_to_show=" + ViewState["date_to_show"]);
                    }
                    else
                    {
                        Response.Redirect("./vacations_approve_vacation_request.aspx?source_page=vacations_add.aspx&date_to_show=" + ViewState["date_to_show"]);
                    }
                    break;

                case "nbCancelVacationRequests":
                    if (ddlVacationsFor.SelectedIndex > 0)
                    {
                        Response.Redirect("./vacations_cancel_vacation_request.aspx?source_page=vacations_add.aspx&employee_id=" + ddlVacationsFor.SelectedValue + "&date_to_show=" + ViewState["date_to_show"]);
                    }
                    else
                    {
                        Response.Redirect("./vacations_cancel_vacation_request.aspx?source_page=vacations_add.aspx&date_to_show=" + ViewState["date_to_show"]);
                    }
                    break;
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        //  PUBLIC METHODS
        //

        public VacationsAddTDS.DaysInformationDataTable GetVacationsNew()
        {
            vacationDaysInformation = ((VacationsAddTDS)Session["vacationsAddTDS"]).DaysInformation;
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

        private void LoadData(int employeeId, int year)
        {
            VacationsAddBasicInformationGateway vacationsAddBasicInformationGateway = new VacationsAddBasicInformationGateway(vacationsAddTDS);

            tbxEmployee.Text = vacationsAddBasicInformationGateway.GetEmployeeName(employeeId, year);
            tbxMax.Text = vacationsAddBasicInformationGateway.GetTotalVacationDays(employeeId, year).ToString();
            tbxRemaining.Text = vacationsAddBasicInformationGateway.GetRemainingPayVacationDays(employeeId, year).ToString();           
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
            this.ClientScript.RegisterClientScriptInclude("clientSideCode1", "./vacations_add.js");
        }



        private void Save()
        {
            PostPageChanges();

            // Update database
            UpdateDatabase();

            DropDownList ddlVacationsFor = (DropDownList)tkrpbLeftMenuAllVacations.FindItemByValue("nbVacationsForDDL").FindControl("ddlVacationsFor");
            Session["ddlVacationsForSelectedValue"] = ddlVacationsFor.SelectedValue;

            // Send  mail 
            SendMail();

            // Redirect
            if (Request.QueryString["source_page"] == "vacations_all.aspx")
            {
                if (ddlVacationsFor.SelectedIndex > 0)
                {
                    Response.Redirect("./vacations_all.aspx?source_page=vacations_add.aspx&employee_id=" + ddlVacationsFor.SelectedValue + "&date_to_show=" + ViewState["date_to_show"]);
                }
                else
                {
                    Response.Redirect("./vacations_all.aspx?source_page=vacations_add.aspx&date_to_show=" + ViewState["date_to_show"]);
                }
            }
        }



        private void PostPageChanges()
        {
            // all vacations starts as approved
            VacationsAddRequestsInformation vacationsAddRequestsInformation = new VacationsAddRequestsInformation(vacationsAddTDS);
            vacationsAddRequestsInformation.Insert(Int32.Parse(hdfEmployeeId.Value), GetStartDate(), GetEndDate(), GetTotalPaidVacationDays(), "Approved", tbxComments.Text, GetDetails(), false, Int32.Parse(hdfCompanyId.Value)); 

            // Store dataset
            Session["vacationsAddTDS"] = vacationsAddTDS;
            Session["vacationDaysInformation"] = vacationsAddTDS.DaysInformation;
        }



        private DateTime GetStartDate()
        {
            DateTime startDate = new DateTime();

            DataRow[] drarray;
            drarray = vacationsAddTDS.DaysInformation.Select("Deleted = 0 AND  InDatabase = False", "StartDate ASC", DataViewRowState.CurrentRows);
            startDate = DateTime.Parse(drarray[0]["StartDate"].ToString());

            return startDate;
        }



        private DateTime GetEndDate()
        {
            DateTime endDate = new DateTime();

            DataRow[] drarray;
            drarray = vacationsAddTDS.DaysInformation.Select("Deleted = 0  AND  InDatabase = False" , "EndDate DESC", DataViewRowState.CurrentRows);
            endDate = DateTime.Parse(drarray[0]["EndDate"].ToString());

            return endDate;
        }



        private string GetDetails()
        {
            string details = "";

            DataRow[] drarray = vacationsAddTDS.DaysInformation.Select("Deleted = 0 AND  InDatabase = False", "StartDate ASC", DataViewRowState.CurrentRows);

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

            details = details.Remove(details.Length - 2, 2);

            return details;
        }



        private double GetTotalPaidVacationDays()
        {
            double totalPaidVacationDays = 0;

            foreach (VacationsAddTDS.DaysInformationRow row in (VacationsAddTDS.DaysInformationDataTable)vacationsAddTDS.DaysInformation)
            {
                if ((!row.Deleted) && (!row.InDatabase))
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


        
        private void UpdateDatabase()
        {
            DB.Open();
            DB.BeginTransaction();
            try
            {
                double oldTotalTakenVacationDays = double.Parse(tbxMax.Text) - double.Parse(tbxRemaining.Text);

                VacationsAddRequestsInformation vacationsAddRequestsInformation = new VacationsAddRequestsInformation(vacationsAddTDS);                
                int requestId = vacationsAddRequestsInformation.Save(oldTotalTakenVacationDays);

                VacationsAddDaysInformation vacationsAddDaysInformation = new VacationsAddDaysInformation(vacationsAddTDS);
                vacationsAddDaysInformation.Save(requestId);

                vacationsAddTDS.AcceptChanges();

                // Store dataset
                Session["vacationsAddTDS"] = vacationsAddTDS;
                Session["vacationDaysInformation"] = vacationsAddTDS.DaysInformation; 

                DB.CommitTransaction();
            }
            catch (Exception ex)
            {
                DB.RollbackTransaction();

                string url = string.Format("./../../error_page.aspx?error={0}", ex.Message.Replace('\n', ' '));
                Response.Redirect(url);
            }
        }



        private string GetUnpaidDaysDetails()
        {
            string details = "";

            DataRow[] drarray = vacationsAddTDS.DaysInformation.Select("Deleted = 0 AND  InDatabase = False", "StartDate ASC", DataViewRowState.CurrentRows);

            foreach (DataRow row in drarray)
            {
                if (!Convert.ToBoolean(row["Deleted"].ToString()))
                {
                    if ((row["PaymentType"].ToString() == "Unpaid Leave Full Day") || (row["PaymentType"].ToString() == "Unpaid Leave Half Day"))
                    {
                        DateTime startDate = DateTime.Parse(row["StartDate"].ToString());

                        switch (row["PaymentType"].ToString())
                        {
                            case "Unpaid Leave Full Day":
                                details += startDate.ToString("MMM/dd") + " Unpaid Leave Full Day, ";
                                break;

                            case "Unpaid Leave Half Day":
                                details += startDate.ToString("MMM/dd") + " Unpaid Leave Half Day, ";
                                break;
                        }
                    }
                }
            }

            if (details.Length > 2)
            {
                details = details.Remove(details.Length - 2, 2);
            }

            return details;
        }



        public void SendMail()
        {
            // Get mail information
            string unpaidDetails = GetUnpaidDaysDetails();
            
            // If there are unpaid vacations registered, send mail.
            if (unpaidDetails.Length > 0)
            {
                string mailTo = "";
                string nameTo = "";
                string subject = "New unpaid vacation request has been registered.";
                string body = "";           
                            
                // ... MailtTo, nameTo
                mailTo = "rfrayne@liquiforce.com";
                nameTo = "Richard Frayne";

                // ... Mails body
                body = body + "\nHi " + nameTo + ",\n\nThe following unpaid vacation request has been registered. \n";

                body = body + "\n Team Member: " + tbxEmployee.Text;
                body = body + "\n Start Date: " + GetStartDate();
                body = body + "\n End Date: " + GetEndDate();
                body = body + "\n Comments: " + tbxComments.Text;
                body = body + "\n Vacation Details: " + unpaidDetails;            

                //... Send Mail            
                SendMail(mailTo, subject, body);
            }
        }



        private void SendMail(string mailTo, string subject, string body)
        {
            SendMailLiveSite(mailTo, subject, body);
            //SendMailTestSite(mailTo, subject, body);//TODO EMAIL
        }

               

        private void SendMailLiveSite(string mailTo, string subject, string body)
        {
            string error;

            // For live site
            string entireBody = "";

            if ((mailTo != "") && (subject != "") && (body != ""))
            {
                entireBody = entireBody + body + "\n\n\n\n\nRegards,\n\n" + "LFS Admin Team.\n\n";
                LiquiForce.LFSLive.WebUI.Common.Tools.Mail.SendMailVacations(mailTo, "sussel@nerdsonsite.com", subject, entireBody, false, out error);
            }
        }



        private void SendMailTestSite(string mailTo, string subject, string body)
        {
            string error;

            // For Test Site
            string entireBody = "--- SENT FROM THE TEST SITE --- \n";

            if ((mailTo != "") && (subject != "") && (body != ""))
            {
                entireBody = entireBody + body + "\n\n\n\n\nRegards,\n\n" + "LFS Admin Team.\n\n";
                LiquiForce.LFSLive.WebUI.Common.Tools.Mail.SendMailVacations("sussel@nerdsonsite.com", "humberto@nerdsonsite.com, jacqueline.claure@nerdsonsite.com", subject, entireBody, false, out error);
            }
        }

                      

    }
}