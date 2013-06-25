using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.BL.Resources.Employees;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.BL.FleetManagement.CompanyLevels;
using LiquiForce.LFSLive.DA.FleetManagement.CompanyLevels;
using Telerik.Web.UI;
using LiquiForce.LFSLive.DA.LabourHours.Vacations;
using LiquiForce.LFSLive.BL.LabourHours.Vacations;
using System.Web.UI;
using LiquiForce.LFSLive.DA.Resources.Employees;

namespace LiquiForce.LFSLive.WebUI.LabourHours.Vacations
{
    /// <summary>
    /// vacations_non_working_days_definition
    /// </summary>
    public partial class vacations_non_working_days_definition : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected CompanyLevelsTDS companyLevels;
        protected VacationsNonWorkingDaysInformationTDS vacationsNonWorkingDaysInformationTDS;
        protected VacationsNonWorkingDaysInformationTDS.NonWorkingDaysInformationDataTable nonWorkingDaysInformation;






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
                if (!(Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_VACATIONS_HOLIDAY_FULL_EDITING"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) && ((string)Request.QueryString["date_to_show"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in vacations_non_working_days_definition.aspx");
                }

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

                // Tag page
                ViewState["date_to_show"] = (string)Request.QueryString["date_to_show"];                
                ViewState["level"] = "-1";
                int companyId = Int32.Parse(Session["companyID"].ToString());
                hdfCompanyId.Value = companyId.ToString();

                // Prepare initial data               
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

                // ... For ddl working location
                companyLevels = new CompanyLevelsTDS();
                CompanyLevel companyLevel = new CompanyLevel(companyLevels);
                companyLevel.LoadNodes(companyId);
                GetNodeForCompanyLevel(1);
                int companyLevelId = 0;
                if (employeeTypeNow.Contains("CA"))
                {
                    ddlWorkingLocation.SelectedValue = "2";//Canada
                    companyLevelId = 2;
                }
                else
                {
                    ddlWorkingLocation.SelectedValue = "3";//Canada
                    companyLevelId = 3;
                }

                // ... Load non working days
                vacationsNonWorkingDaysInformationTDS = new VacationsNonWorkingDaysInformationTDS();
                nonWorkingDaysInformation = new VacationsNonWorkingDaysInformationTDS.NonWorkingDaysInformationDataTable();

                VacationsNonWorkingDaysInformationGateway vacationsNonWorkingDaysInformationGateway = new VacationsNonWorkingDaysInformationGateway(vacationsNonWorkingDaysInformationTDS);
                vacationsNonWorkingDaysInformationGateway.LoadByCompanyLevelId(companyLevelId, companyId);

                Session["vacationsNonWorkingDaysInformationTDS"] = vacationsNonWorkingDaysInformationTDS;
                Session["nonWorkingDaysInformation"] = vacationsNonWorkingDaysInformationTDS.NonWorkingDaysInformation;

                tkrsNonWorkingDays.SelectedDate = DateTime.Parse(ViewState["date_to_show"].ToString());

                // Databind
                Page.DataBind();
            }
            else
            {
                vacationsNonWorkingDaysInformationTDS = (VacationsNonWorkingDaysInformationTDS)Session["vacationsNonWorkingDaysInformationTDS"];
                nonWorkingDaysInformation = (VacationsNonWorkingDaysInformationTDS.NonWorkingDaysInformationDataTable)Session["nonWorkingDaysInformation"];
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

            tkrsNonWorkingDays.SelectedDate = DateTime.Parse(ViewState["date_to_show"].ToString());
        }






        // ////////////////////////////////////////////////////////////////////////
        // AUXILIAR EVENTS
        //

        protected void tkrsNonWorkingDays_NavigationComplete(object sender, SchedulerNavigationCompleteEventArgs e)
        {
            ViewState["date_to_show"] = tkrsNonWorkingDays.SelectedDate.ToString();
        }



        protected void tkrsNonWorkingDays_AppointmentInsert(object sender, SchedulerCancelEventArgs e)
        {
            Page.Validate();

            if (Page.IsValid)
            {                
                string filterExpression = string.Format("Deleted = 0 AND StartDate = '{0}'", e.Appointment.Start);
                DataRow[] drarray  = vacationsNonWorkingDaysInformationTDS.NonWorkingDaysInformation.Select(filterExpression, "StartDate ASC", DataViewRowState.CurrentRows);
                if (drarray.Length == 0)
                {
                    VacationsNonWorkingDaysInformation vacationsNonWorkingDaysInformation = new VacationsNonWorkingDaysInformation(vacationsNonWorkingDaysInformationTDS);
                    vacationsNonWorkingDaysInformation.Insert(e.Appointment.Start, Int32.Parse(ddlWorkingLocation.SelectedValue), e.Appointment.Subject, false, Int32.Parse(hdfCompanyId.Value), false);

                    // Store dataset
                    Session["vacationsNonWorkingDaysInformationTDS"] = vacationsNonWorkingDaysInformationTDS;
                    Session["nonWorkingDaysInformation"] = vacationsNonWorkingDaysInformationTDS.NonWorkingDaysInformation;

                    tkrsNonWorkingDays.DataBind();
                }
                else
                {
                    e.Cancel = true;
                    ScriptManager.RegisterStartupScript(Page, GetType(), "alert", "alert('You already have a non working day for this day please verify your data.');", true);
                }
            }
            else
            {
                e.Cancel = true;
            }
        }



        protected void tkrsNonWorkingDays_AppointmentUpdate(object sender, AppointmentUpdateEventArgs e)
        {
            Page.Validate();

            if (Page.IsValid)
            {
                int nonWorkingDayId = Convert.ToInt32(e.ModifiedAppointment.ID);

                VacationsNonWorkingDaysInformation vacationsNonWorkingDaysInformation = new VacationsNonWorkingDaysInformation(vacationsNonWorkingDaysInformationTDS);
                vacationsNonWorkingDaysInformation.Update(nonWorkingDayId, e.ModifiedAppointment.Subject);

                // Store dataset
                Session["vacationsNonWorkingDaysInformationTDS"] = vacationsNonWorkingDaysInformationTDS;
                Session["nonWorkingDaysInformation"] = vacationsNonWorkingDaysInformationTDS.NonWorkingDaysInformation;

                tkrsNonWorkingDays.DataBind();
            }
            else
            {
                e.Cancel = true;
            }
        }



        protected void tkrsNonWorkingDays_AppointmentDelete(object sender, SchedulerCancelEventArgs e)
        {
            Page.Validate();

            if (Page.IsValid)
            {
                int nonWorkingDayId = Convert.ToInt32(e.Appointment.ID);

                VacationsNonWorkingDaysInformation vacationsNonWorkingDaysInformation = new VacationsNonWorkingDaysInformation(vacationsNonWorkingDaysInformationTDS);
                vacationsNonWorkingDaysInformation.Delete(nonWorkingDayId);

                // Store dataset
                Session["vacationsNonWorkingDaysInformationTDS"] = vacationsNonWorkingDaysInformationTDS;
                Session["nonWorkingDaysInformation"] = vacationsNonWorkingDaysInformationTDS.NonWorkingDaysInformation;

                tkrsNonWorkingDays.DataBind();
            }
            else
            {
                e.Cancel = true;
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
                    Save();
                    break;

                case "mCancel":
                    if (ddlVacationsFor.SelectedIndex > 0)
                    {
                        Response.Redirect("./vacations_all.aspx?source_page=vacations_non_working_days_definition.aspx&employee_id=" + ddlVacationsFor.SelectedValue + "&date_to_show=" + ViewState["date_to_show"]);
                    }
                    else
                    {
                        Response.Redirect("./vacations_all.aspx?source_page=vacations_non_working_days_definition.aspx&date_to_show=" + ViewState["date_to_show"]);
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
                        Response.Redirect("./vacations_all.aspx?source_page=vacations_non_working_days_definition.aspx&employee_id=" + ddlVacationsFor.SelectedValue + "&date_to_show=" + ViewState["date_to_show"]);
                    }
                    else
                    {
                        Response.Redirect("./vacations_all.aspx?source_page=vacations_non_working_days_definition.aspx&date_to_show=" + ViewState["date_to_show"]);
                    }
                    break;

                case "nbApproveVacationRequests":
                    if (ddlVacationsFor.SelectedIndex > 0)
                    {
                        Response.Redirect("./vacations_approve_vacation_request.aspx?source_page=vacations_non_working_days_definition.aspx&employee_id=" + ddlVacationsFor.SelectedValue + "&date_to_show=" + ViewState["date_to_show"]);
                    }
                    else
                    {
                        Response.Redirect("./vacations_approve_vacation_request.aspx?source_page=vacations_non_working_days_definition.aspx&date_to_show=" + ViewState["date_to_show"]);
                    }
                    break;

                case "nbCancelVacationRequests":
                    if (ddlVacationsFor.SelectedIndex > 0)
                    {
                        Response.Redirect("./vacations_cancel_vacation_request.aspx?source_page=vacations_non_working_days_definition.aspx&employee_id=" + ddlVacationsFor.SelectedValue + "&date_to_show=" + ViewState["date_to_show"]);
                    }
                    else
                    {
                        Response.Redirect("./vacations_cancel_vacation_request.aspx?source_page=vacations_non_working_days_definition.aspx&date_to_show=" + ViewState["date_to_show"]);
                    }
                    break;
            }
        }



        protected void ddlWorkingLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            int companyId = Int32.Parse(hdfCompanyId.Value);
            VacationsNonWorkingDaysInformationGateway vacationsNonWorkingDaysInformationGateway = new VacationsNonWorkingDaysInformationGateway(vacationsNonWorkingDaysInformationTDS);
            vacationsNonWorkingDaysInformationGateway.LoadByCompanyLevelId(Int32.Parse(ddlWorkingLocation.SelectedValue), companyId);

            Session["vacationsNonWorkingDaysInformationTDS"] = vacationsNonWorkingDaysInformationTDS;
            Session["nonWorkingDaysInformation"] = vacationsNonWorkingDaysInformationTDS.NonWorkingDaysInformation;

            odsNonWorkingDaysGrid.DataBind();
            tkrsNonWorkingDays.DataBind();
        }






        // ////////////////////////////////////////////////////////////////////////
        //  PUBLIC METHODS
        //

        public VacationsNonWorkingDaysInformationTDS.NonWorkingDaysInformationDataTable GetNonWorkingDaysNew()
        {
            nonWorkingDaysInformation = ((VacationsNonWorkingDaysInformationTDS)Session["vacationsNonWorkingDaysInformationTDS"]).NonWorkingDaysInformation;

            return nonWorkingDaysInformation;
        }



        public void DummyNonWorkingDaysNew(int NonWorkingDayID)
        {
        }



        public void DummyNonWorkingDaysNew(string Description, DateTime StartDate, DateTime EndDate)
        {
        }



        public void DummyNonWorkingDaysNew(string Description, DateTime StartDate, DateTime EndDate, int NonWorkingDayID)
        {
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
            this.ClientScript.RegisterClientScriptInclude("clientSideCode1", "./vacations_non_working_days_definition.js");
        }



        private void Save()
        {
            // Update database
            UpdateDatabase();

            DropDownList ddlVacationsFor = (DropDownList)tkrpbLeftMenuAllVacations.FindItemByValue("nbVacationsForDDL").FindControl("ddlVacationsFor");
            Session["ddlVacationsForSelectedValue"] = ddlVacationsFor.SelectedValue;

            // Redirect
            if (ddlVacationsFor.SelectedIndex > 0)
            {
                Response.Redirect("./vacations_all.aspx?source_page=vacations_non_working_days_definition.aspx&employee_id=" + ddlVacationsFor.SelectedValue + "&date_to_show=" + ViewState["date_to_show"]);
            }
            else
            {
                Response.Redirect("./vacations_all.aspx?source_page=vacations_non_working_days_definition.aspx&date_to_show=" + ViewState["date_to_show"]);
            }
        }



        private void UpdateDatabase()
        {
            DB.Open();
            DB.BeginTransaction();
            try
            {
                VacationsNonWorkingDaysInformation vacationsNonWorkingDaysInformation = new VacationsNonWorkingDaysInformation(vacationsNonWorkingDaysInformationTDS);
                vacationsNonWorkingDaysInformation.Save();

                vacationsNonWorkingDaysInformationTDS.AcceptChanges();

                // Store dataset
                Session["vacationsNonWorkingDaysInformationTDS"] = vacationsNonWorkingDaysInformationTDS;
                Session["nonWorkingDaysInformation"] = vacationsNonWorkingDaysInformationTDS.NonWorkingDaysInformation;               

                DB.CommitTransaction();
            }
            catch (Exception ex)
            {
                DB.RollbackTransaction();

                string url = string.Format("./../../error_page.aspx?error={0}", ex.Message.Replace('\n', ' '));
                Response.Redirect(url);
            }
        }



        private void GetNodeForCompanyLevel(int parentId)
        {
            int level = Int32.Parse(ViewState["level"].ToString());
            level++;
            System.Text.StringBuilder levelString = new System.Text.StringBuilder();
            for (int j = 0; j < level; j++)
            {
                levelString.Append("&nbsp;&nbsp;&nbsp;&nbsp;");
            }
            if (level > 0)
            {
                levelString.Append("-");
            }

            Int32 thisId;
            String thisName;

            DataRow[] children = companyLevels.Tables["LFS_FM_COMPANYLEVEL"].Select("ParentID='" + parentId + "'");

            // No child nodes, exit function
            if (children.Length > 0)
            {
                foreach (DataRow child in children)
                {
                    // Step 1
                    thisId = Convert.ToInt32(child.ItemArray[0]);

                    // Step 2
                    thisName = Convert.ToString(child.ItemArray[1]);

                    // Step 3
                    ListItem listItem = new ListItem(Server.HtmlDecode(levelString.ToString() + thisName), thisId.ToString());
                    ddlWorkingLocation.Items.Add(listItem);

                    // Step 4
                    GetNodeForCompanyLevel(thisId);
                }
            }

            level--;
            ViewState["level"] = level;
        }



    }
}