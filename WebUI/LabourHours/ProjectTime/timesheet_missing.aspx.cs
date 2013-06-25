using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime
{
    /// <summary>
    /// timesheet_missing
    /// </summary>
    public partial class timesheet_missing : System.Web.UI.Page
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
                    if (!Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_AUTOREPORT"]))
                    {
                        if (!(Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_OTHERS_TIMESHEETS_VIEW"]) && Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_OTHERS_TIMESHEETS_ADD"])))
                        {
                            if (!Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_OTHERS_TIMESHEETS_MANAGEMENT"]))
                            {
                                if (!Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_OTHERS_TIMESHEETS_MANAGEMENT_WED"]))
                                {
                                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                                }
                            }
                        }
                    }
                }

                // Validate query string
                if ((string)Request.QueryString["source_page"] == null)
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in timesheet_missing.aspx");
                }

                // Prepare initial data for client
                tkrdpStartDate.SelectedDate = DateTime.Now;
                tkrdpEndDate.SelectedDate = DateTime.Now;

                Session["OpenTimesheetMissing"] = "true";
            }
        }

        




        // ////////////////////////////////////////////////////////////////////////
        // WIZARD NAVIGATION EVENTS
        //

        protected void wzMissingProjectTime_ActiveStepChanged(object sender, EventArgs e)
        {
            mWizard2 master2 = (mWizard2)this.Master;

            switch (wzMissingProjectTime.ActiveStep.Title)
            {
                case "Start":
                    master2.WizardInstruction = "This wizard allows you to determine missing entries on your team member's project times.";
                    break;

                case "Criteria":
                    master2.WizardInstruction = "Please define your criteria.";
                    break;

                case "Format":
                    master2.WizardInstruction = "Please define the format for your report.";
                    break;
            }
        }



        protected void wzMissingProjectTime_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        {
            Page.Validate();

            if (Page.IsValid)
            {
                Response.Redirect(GetTargetUrl());
            }
        }



        protected void wzMissingProjectTime_CancelButtonClick(object sender, EventArgs e)
        {
            Response.Write("<script language='javascript'> { window.close();}</script>");
        }






        // ////////////////////////////////////////////////////////////////////////
        // FINAL EVENTS 
        //

        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set wizard title
            mWizard2 master2 = (mWizard2)this.Master;            
            Label title = (Label)this.Master.FindControl("lblTitle");
            title.Text = "Missing Project Time";           
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        private string GetTargetUrl()
        {
            // Build target url
            string url = "";

            // ... Set target page and target report
            url = "./../../viewer.aspx?target_report=TimesheetMissing";

            if (ddlCountry.SelectedValue == "-1")
            {
                url += "&all_countries=true&country_id=0";
            }
            else
            {
                url += "&all_countries=false&country_id=" + ddlCountry.SelectedValue;
            }
            // ... Append employee's criteria
            if (ddlCriteriaEmployee.SelectedValue == "-1")
            {
                url += "&all_employees=true&employee_id=0";
            }
            else
            {
                url += "&all_employees=false&employee_id=" + ddlCriteriaEmployee.SelectedValue;
            }

            if (ddlEmployeeType.SelectedValue == "(All)")
            {
                url += "&all_employee_type=true&employee_type=%";
            }
            else
            {
                url += "&all_employee_type=false&employee_type=" + ddlEmployeeType.SelectedValue + "%";
            }

            if (cbxIncludeSalaried.Checked)
            {
                url += "&include_salaried=true";
            }
            else
            {
                url += "&include_salaried=false";
            }

            url += "&employee_state=" + ddlState.SelectedValue;

            // ... Append date's criteria
            url += "&date_from=" + tkrdpStartDate.SelectedDate.Value.ToShortDateString() + "&date_to=" + tkrdpEndDate.SelectedDate.Value.ToShortDateString();

            // ... Append target
            if (rbtnFormatPdf.Checked)
            {
                url += "&format=pdf";
            }
            else
            {
                url += "&format=excel";
            }

            return url;
        }



    }
}