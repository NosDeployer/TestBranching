using System;
using System.Data;
using LiquiForce.LFSLive.DA.Resources.Employees;
using LiquiForce.LFSLive.DA.LabourHours.ProjectTime;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime
{
    /// <summary>
    /// timesheet_state
    /// </summary>
    public partial class timesheet_state : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // PROPERTIES AND FIELDS
        //

        protected ProjectTimeTDS projectTimeTDSForState;






        // ////////////////////////////////////////////////////////////////////////
        // EVENTS
        //

        protected void Page_Load(object sender, EventArgs e)
        {
            // Register client scripts
            this.RegisterClientScripts();

            if (!IsPostBack)
            {
                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) && ((string)Request.QueryString["others"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in timesheet_state.aspx");
                }

                // Security check
                EmployeeGateway employeeGateway1 = new EmployeeGateway(new DataSet());
                int employeeId = employeeGateway1.GetEmployeIdByLoginId(Convert.ToInt32(Session["loginID"]));
                employeeGateway1.LoadByEmployeeId(employeeId);

                if (!employeeGateway1.GetApproveTimesheets(employeeId))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }
                else
                {
                    if (!ValidateWedManagement())
                    {
                        Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                    }
                }

                // Initialize viewstate variables
                System.Configuration.AppSettingsReader appSettingReader = new System.Configuration.AppSettingsReader();
                ViewState["LHMode"] = appSettingReader.GetValue("LABOUR_HOURS_OPERATION_MODE", typeof(System.String)).ToString();
                ViewState["others"] = Request.QueryString["others"];
                ViewState["employee_id"] = int.Parse(Request.QueryString["employee_id"]);
                ViewState["period_id"] = int.Parse(Request.QueryString["period_id"]);
                ViewState["source_page"] = Request.QueryString["source_page"];
                if ((string)ViewState["source_page"] == "timesheet_summary.aspx")
                {
                    ViewState["projecttime_id"] = int.Parse(Request.QueryString["projecttime_id"]);
                }

                // Labour Hours Mode check
                if ((string)ViewState["LHMode"] == "Partial")
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "The system is on partial mode. Contact your system administrator.");
                }

                // Timesheet state check
                projectTimeTDSForState = new ProjectTimeTDS();
                ProjectTimeGateway projectTimeGateway = new ProjectTimeGateway(projectTimeTDSForState);
                projectTimeGateway.ClearBeforeFill = false;

                if ((string)ViewState["source_page"] == "timesheet_approve.aspx")
                {
                    List<int> projectTimesIdSelected = ((List<int>)Session["projectTimesIdSelected"]);
                    foreach (int projectTimeId in projectTimesIdSelected)
                    {
                        projectTimeGateway.LoadByProjectTimeId(projectTimeId);
                    }
                }
                else
                {
                    if ((string)ViewState["source_page"] == "timesheet_summary.aspx")
                    {                        
                        int projecttime_id = Int32.Parse(ViewState["projecttime_id"].ToString());
                        projectTimeGateway.LoadByProjectTimeId(projecttime_id);
                    }
                }

                projectTimeGateway.ClearBeforeFill = true;
                
                // Store datasets
                Session["projectTimeTDSForState"] = projectTimeTDSForState;
            }
            else
            {
                // Restore datasets
                projectTimeTDSForState = (ProjectTimeTDS)Session["projectTimeTDSForState"];
            }
        }



        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set active toolbar
            mForm6 master = (mForm6)this.Master;
            master.ActiveToolbar = "LabourHours";
        }






        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATION EVENTS
        //

        protected void tkrmTop_ItemClick(object sender, RadMenuEventArgs e)
        {
            switch (e.Item.Value)
            {
                case "mApprove":
                    PostPageChanges();
                    UpdateDatabase();

                    if ((string)Request.QueryString["source_page"] == "timesheet.aspx")
                    {
                        Response.Redirect("./../timesheet/timesheet.aspx?source_page=timesheet_state.aspx&others=" + ViewState["others"] + "&employee_id=" + ViewState["employee_id"] + "&period_id=" + ViewState["period_id"]);
                    }
                    else
                    {
                        if ((string)ViewState["source_page"] == "timesheet_approve.aspx")
                        {
                            Response.Redirect("./timesheet_approve.aspx?source_page=timesheet_state.aspx&others=" + ViewState["others"] + "&employee_id=-1&period_id=-1");
                        }
                        else
                        { 
                            if ((string)ViewState["source_page"] == "timesheet_summary.aspx")
                            {
                                Response.Redirect("./timesheet_summary.aspx?source_page=timesheet_state.aspx&others=" + ViewState["others"] + "&employee_id=" + ViewState["employee_id"] + "&period_id=" + ViewState["period_id"] + "&projecttime_id=" + ViewState["projecttime_id"]);
                            }                        
                        }
                    }
                    break;

                case "mCancel":
                    if ((string)Request.QueryString["source_page"] == "timesheet.aspx")
                    {
                        Response.Redirect("./../timesheet/timesheet.aspx?source_page=timesheet_state.aspx&others=" + ViewState["others"] + "&employee_id=" + ViewState["employee_id"] + "&period_id=" + ViewState["period_id"]);
                    }
                    else
                    {
                        Response.Redirect("./timesheet_approve.aspx?source_page=timesheet_state.aspx&others=" + ViewState["others"] + "&employee_id=-1&period_id=-1");
                    }
                    break;
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // METHODS
        //

        private void RegisterClientScripts()
        {
            // Publishing body's OnKeyDown event 
            HtmlGenericControl bodyUnload = (HtmlGenericControl)Page.Master.FindControl("myBody");
            bodyUnload.Attributes.Add("OnKeyDown", "OnKeyDown(event);");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./timesheet_state.js");
        }



        private bool ValidateWedManagement()
        {
            if (!Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_FULL_EDITING"]))
            {
                if (Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_MY_TIMESHEETS_MANAGEMENT_WED"]) || Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_OTHERS_TIMESHEETS_MANAGEMENT_WED"]))
                {
                    List<int> projectTimesIdSelected = ((List<int>)Session["projectTimesIdSelected"]);

                    ProjectTimeGateway projectTimeGateway = new ProjectTimeGateway();

                    foreach (int projectTimeId in projectTimesIdSelected)
                    {
                        projectTimeGateway.LoadByProjectTimeId(projectTimeId);

                        bool isValidLimitPayPeriodToManagementEdit = LiquiForce.LFSLive.BL.LabourHours.ProjectTime.ProjectTime.ValidateLimitedPayPeriodToWednesdayManagementEdit(projectTimeGateway.GetDate_(projectTimeId), projectTimeGateway.GetProjectId(projectTimeId));

                        if (!isValidLimitPayPeriodToManagementEdit)
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }



        private void PostPageChanges()
        {
            EmployeeGateway employeeGateway1 = new EmployeeGateway(new DataSet());
            int approvedById = employeeGateway1.GetEmployeIdByLoginId(Convert.ToInt32(Session["loginID"]));

            // Approve Project Times
            LiquiForce.LFSLive.BL.LabourHours.ProjectTime.ProjectTime projectTime = new LiquiForce.LFSLive.BL.LabourHours.ProjectTime.ProjectTime(projectTimeTDSForState);
            projectTime.Approve(approvedById);           
        }



        private void UpdateDatabase()
        {
            try
            {
                DataRow[] drEmployees = projectTimeTDSForState.LFS_PROJECT_TIME.Select("ProjectTimeState = 'For Approval'", "EmployeeID ASC", DataViewRowState.OriginalRows);

                ProjectTimeGateway projectTimeGateway = new ProjectTimeGateway(projectTimeTDSForState);
                projectTimeGateway.Update();

                SendMailEmployees(drEmployees);

                projectTimeTDSForState.AcceptChanges();

                Session["projectTimeTDSForState"] = projectTimeTDSForState;                
            }
            catch (Exception ex)
            {
                string url = string.Format("./../../error_page.aspx?error={0}", ex.Message.Replace('\n', ' '));
                Response.Redirect(url);
            }
        }



        private void SendMailEmployees(DataRow[] drEmployees)
        {
            // Get mail information
            string mailTo = "";
            string nameTo = "";
            string body = "";
            string subject = "";

            List<int> employeeIds = new List<int>();
            int lastEmployeeId = 0;
            int lastApprovedById = 0;

            foreach (DataRow row in drEmployees)
            {
                lastEmployeeId = ((ProjectTimeTDS.LFS_PROJECT_TIMERow)row).EmployeeID;
                lastApprovedById = ((ProjectTimeTDS.LFS_PROJECT_TIMERow)row).ApprovedByID;

                if (!employeeIds.Contains(lastEmployeeId))
                {
                    employeeIds.Add(lastEmployeeId);
                    
                    if (body.Length > 0)
                    {
                        EmployeeGateway employeeApproved = new EmployeeGateway();
                        employeeApproved.LoadByEmployeeId(lastApprovedById);

                        if (employeeApproved.Table.Rows.Count > 0)
                        {
                            body = body + "\n\nApproved by " + employeeApproved.GetFirstName(lastApprovedById) + " " + employeeApproved.GetLastName(lastApprovedById);
                        }

                        //Send Mail
                        SendMail(mailTo, subject, body);

                        mailTo = "";
                        nameTo = "";
                        subject = "";
                        body = "";
                    }
                    
                    EmployeeGateway employeesGateway = new EmployeeGateway();
                    employeesGateway.LoadByEmployeeId(lastEmployeeId);

                    if (employeesGateway.Table.Rows.Count > 0)
                    {
                        // Assigned TeamMember
                        mailTo = employeesGateway.GetEMail(lastEmployeeId);
                        nameTo = employeesGateway.GetFirstName(lastEmployeeId) + " " + employeesGateway.GetLastName(lastEmployeeId);

                        subject = "Project Times Approved";

                        // Mails body
                        body = body + "\nHi " + nameTo + ",\n\nThe followings project time has been approved: \n\n";
                        if (!((ProjectTimeTDS.LFS_PROJECT_TIMERow)row).IsStartTimeNull() && !((ProjectTimeTDS.LFS_PROJECT_TIMERow)row).IsEndTimeNull())
                        {
                            body = body + "\t - Project Time for " + ((ProjectTimeTDS.LFS_PROJECT_TIMERow)row).Date_.ToShortDateString() + ", Start Time: " + ((ProjectTimeTDS.LFS_PROJECT_TIMERow)row).StartTime.ToShortTimeString() + ", End Time: " + ((ProjectTimeTDS.LFS_PROJECT_TIMERow)row).EndTime.ToShortTimeString() + "\n";
                        }
                        else
                        {
                            body = body + "\t - Project Time for " + ((ProjectTimeTDS.LFS_PROJECT_TIMERow)row).Date_.ToShortDateString() + ", " + ((ProjectTimeTDS.LFS_PROJECT_TIMERow)row).WorkingDetails;
                        }
                    }
                }
                else
                {
                    if (!((ProjectTimeTDS.LFS_PROJECT_TIMERow)row).IsStartTimeNull() && !((ProjectTimeTDS.LFS_PROJECT_TIMERow)row).IsEndTimeNull())
                    {
                        body = body + "\t - Project Time for " + ((ProjectTimeTDS.LFS_PROJECT_TIMERow)row).Date_.ToShortDateString() + ", Start Time: " + ((ProjectTimeTDS.LFS_PROJECT_TIMERow)row).StartTime.ToShortTimeString() + ", End Time: " + ((ProjectTimeTDS.LFS_PROJECT_TIMERow)row).EndTime.ToShortTimeString() + "\n";
                    }
                    else
                    {
                        body = body + "\t - Project Time for " + ((ProjectTimeTDS.LFS_PROJECT_TIMERow)row).Date_.ToShortDateString() + ", " + ((ProjectTimeTDS.LFS_PROJECT_TIMERow)row).WorkingDetails;
                    }
                }
            }

            if (body.Length > 0)
            {
                EmployeeGateway employeeApproved = new EmployeeGateway();
                employeeApproved.LoadByEmployeeId(lastApprovedById);

                if (employeeApproved.Table.Rows.Count > 0)
                {
                    body = body + "\n\nApproved by " + employeeApproved.GetFirstName(lastApprovedById) + " " + employeeApproved.GetLastName(lastApprovedById);
                }

                //Send Mail
                SendMail(mailTo, subject, body);

                mailTo = "";
                nameTo = "";
                subject = "";
                body = "";
            }
        }



        private void SendMail(string mailTo, string subject, string body)
        {
            SendMailLiveSite(mailTo, subject, body);
            //SendMailTestSite(mailTo, subject, body);//TODO EMAIL
        }



        private void SendMailLiveSite(string mailTo, string subject, string body)
        {
            // For Live Site 
            string error;

            if (!string.IsNullOrEmpty(mailTo) && mailTo != "alerts@liquiforce.com")
            {
                if ((subject != "") && (body != ""))
                {
                          
                    string entireBody = body + "\n\n\n\n\nRegards,\n\n" + "LFS Admin Team.\n\n";
                    LiquiForce.LFSLive.WebUI.Common.Tools.Mail.SendMailLabourHours(mailTo, "sussel@nerdsonsite.com, humberto@nerdsonsite.com", subject, entireBody, false, out error);
                }
            }
        }



        private void SendMailTestSite(string mailTo, string subject, string body)
        {
            // For Test Site
            string error;

            if (!string.IsNullOrEmpty(mailTo) && mailTo != "alerts@liquiforce.com")
            {
                if ((subject != "") && (body != ""))
                {                    
                    string entireBody = "--- SENT FROM THE TEST SITE --- \n";
                    entireBody = entireBody + body + "\n\n\n\n\nRegards,\n\n" + "LFS Admin Team.\n\n";
                    LiquiForce.LFSLive.WebUI.Common.Tools.Mail.SendMailLabourHours("sussel@nerdsonsite.com", "sussel@nerdsonsite.com, humberto@nerdsonsite.com, jacqueline.claure@nerdsonsite.com", subject, entireBody, false, out error);
                }
            }
        }
        

                
    }
}