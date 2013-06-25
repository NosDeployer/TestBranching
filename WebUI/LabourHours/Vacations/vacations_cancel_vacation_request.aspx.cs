using System;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.BL.Resources.Employees;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.LabourHours.Vacations;
using LiquiForce.LFSLive.BL.LabourHours.Vacations;
using LiquiForce.LFSLive.DA.Resources.Employees;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.LabourHours.Vacations
{
    /// <summary>
    /// vacations_cancel_vacation_request
    /// </summary>
    public partial class vacations_cancel_vacation_request : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected VacationsInformationTDS vacationsInformationTDS;






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
                EmployeeGateway employeeGateway1 = new EmployeeGateway();
                int employeeIdNow = employeeGateway1.GetEmployeIdByLoginId(Convert.ToInt32(Session["loginID"]));
                employeeGateway1.LoadByEmployeeId(employeeIdNow);

                if (!employeeGateway1.GetIsVacationsManager(employeeIdNow))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) && ((string)Request.QueryString["date_to_show"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in vacations_cancel_vacation_request.aspx");
                }

                //recibe opcionalmente el employee_id
                // Tag page
                int companyId = Int32.Parse(Session["companyID"].ToString());
                hdfCompanyId.Value = companyId.ToString();

                //recibe opcionalmente el employee_id y date_to_show
                if ((string)Request.QueryString["date_to_show"] == null)
                {
                    ViewState["date_to_show"] = DateTime.Now.ToString();
                }
                else
                {
                    ViewState["date_to_show"] = (string)Request.QueryString["date_to_show"];
                }

                if ((string)Request.QueryString["employee_id"] == null)
                {
                    hdfEmployeeId.Value = "-1";
                }
                else
                {
                    hdfEmployeeId.Value = (string)Request.QueryString["employee_id"];
                }

                EmployeeList employeeList = new EmployeeList();
                employeeList.LoadBySalariedAndAddItem(1, -1, "(All)");

                DropDownList ddlVacationsFor = (DropDownList)tkrpbLeftMenuAllVacations.FindItemByValue("nbVacationsForDDL").FindControl("ddlVacationsFor");
                ddlVacationsFor.DataSource = employeeList.Table;
                ddlVacationsFor.DataValueField = "EmployeeID";
                ddlVacationsFor.DataTextField = "FullName";
                ddlVacationsFor.DataBind();
                ddlVacationsFor.SelectedValue = Session["ddlVacationsForSelectedValue"].ToString();

                vacationsInformationTDS = new VacationsInformationTDS();
                VacationsInformationRequestsInformationGateway vacationsInformationRequestsInformationGateway = new VacationsInformationRequestsInformationGateway(vacationsInformationTDS);

                vacationsInformationRequestsInformationGateway.LoadByState("Approved", companyId);
                
                grdVacations.DataSource = vacationsInformationTDS.RequestsInformation;

                Session["vacationsInformationTDS"] = vacationsInformationTDS;

                Page.DataBind();

                // Check results
                if (vacationsInformationTDS.RequestsInformation.Rows.Count > 0)
                {
                    tdNoResults.Visible = false;
                    lblTotalRows.Visible = true;
                    lblTotalRows.Text = "Total Rows: " + vacationsInformationTDS.RequestsInformation.Rows.Count;
                }
                else
                {
                    tdNoResults.Visible = true;
                    lblTotalRows.Visible = false;
                }
            }
            else
            {
                vacationsInformationTDS = (VacationsInformationTDS)Session["vacationsInformationTDS"];
            }
        }



        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set active toolbar
            mForm6 master = (mForm6)this.Master;
            master.ActiveToolbar = "LabourHours";

            if (!Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_VACATIONS_REPORTS"]))
            {
                if (!Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_VACATIONS_ADMIN"]))
                {
                    tkrpbLeftMenuReports.Visible = false;
                }
            }

            if (!Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_VACATIONS_ADMIN"]))
            {
                tkrpbLeftMenuAllVacations.Visible = false; // All Vacations
                tkrpbLeftMenuMyVacations.Visible = true; // My Vacations

                tkrpbLeftMenuTools.Visible = false;
            }

            EmployeeGateway employeeGateway1 = new EmployeeGateway();
            int employeeIdNow = employeeGateway1.GetEmployeIdByLoginId(Convert.ToInt32(Session["loginID"]));
            employeeGateway1.LoadByEmployeeId(employeeIdNow);                       

            if (!(Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_VACATIONS_HOLIDAY_FULL_EDITING"])))
            {
                // Validate tools menu
                tkrpbLeftMenuTools.Visible = false;
                //tkrpbLeftMenuTools.Items[2].Visible = false;
                //tkrpbLeftMenuTools.Items[3].Visible = false;
            }

            if (!Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_VACATIONS_ADMIN"]) && !employeeGateway1.GetIsVacationsManager(employeeIdNow))
            {
                tkrpbLeftMenuTools.Visible = false;
            }

            // Check results
            if (vacationsInformationTDS.RequestsInformation.Rows.Count == 0)
            {
                tkrmTop.Items[0].Visible = false;
            }
            else
            {
                tkrmTop.Items[0].Visible = true;
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
                case "mCancelRequest":
                    CancelRequests();
                    break;

                case "mCancel":
                    if (ddlVacationsFor.SelectedIndex > 0)
                    {
                        Response.Redirect("./vacations_all.aspx?source_page=vacations_cancel_vacation_request.aspx&employee_id=" + ddlVacationsFor.SelectedValue + "&date_to_show=" + ViewState["date_to_show"]);
                    }
                    else
                    {
                        Response.Redirect("./vacations_all.aspx?source_page=vacations_cancel_vacation_request.aspx&date_to_show=" + ViewState["date_to_show"]);
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
                        Response.Redirect("./vacations_all.aspx?source_page=vacations_cancel_vacation_request.aspx&employee_id=" + ddlVacationsFor.SelectedValue + "&date_to_show=" + ViewState["date_to_show"]);
                    }
                    else
                    {
                        Response.Redirect("./vacations_all.aspx?source_page=vacations_cancel_vacation_request.aspx&date_to_show=" + ViewState["date_to_show"]);
                    }
                    break;

                case "nbNonWorkingDaysDefinition":
                    Response.Redirect("./vacations_non_working_days_definition.aspx?source_page=vacations_cancel_vacation_request.aspx&date_to_show=" + ViewState["date_to_show"]);
                    break;

                case "nbApproveVacationRequests":
                    if (ddlVacationsFor.SelectedIndex > 0)
                    {
                        Response.Redirect("./vacations_approve_vacation_request.aspx?source_page=vacations_cancel_vacation_request.aspx&employee_id=" + ddlVacationsFor.SelectedValue + "&date_to_show=" + ViewState["date_to_show"]);
                    }
                    else
                    {
                        Response.Redirect("./vacations_approve_vacation_request.aspx?source_page=vacations_cancel_vacation_request.aspx&date_to_show=" + ViewState["date_to_show"]);
                    }
                    break;
            }
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
            this.ClientScript.RegisterClientScriptInclude("clientSideCode1", "./vacations_cancel_vacation_request.js");
        }



        private void CancelRequests()
        {
            PostPageChanges();

            // Update database
            UpdateDatabase();

            DropDownList ddlVacationsFor = (DropDownList)tkrpbLeftMenuAllVacations.FindItemByValue("nbVacationsForDDL").FindControl("ddlVacationsFor");
            Session["ddlVacationsForSelectedValue"] = ddlVacationsFor.SelectedValue;

            // Redirect
            if (ddlVacationsFor.SelectedIndex > 0)
            {
                Response.Redirect("./vacations_all.aspx?source_page=vacations_cancel_vacation_request.aspx&employee_id=" + ddlVacationsFor.SelectedValue + "&date_to_show=" + ViewState["date_to_show"]);
            }
            else
            {
                Response.Redirect("./vacations_all.aspx?source_page=vacations_cancel_vacation_request.aspx&date_to_show=" + ViewState["date_to_show"]);
            }
        }
        


        private void UpdateDatabase()
        {
            DB.Open();
            DB.BeginTransaction();
            try
            {
                VacationsInformationRequestsInformation vacationsInformationRequestsInformation = new VacationsInformationRequestsInformation(vacationsInformationTDS);
                vacationsInformationRequestsInformation.Save();

                vacationsInformationTDS.AcceptChanges();

                DB.CommitTransaction();
            }
            catch (Exception ex)
            {
                DB.RollbackTransaction();

                string url = string.Format("./../../error_page.aspx?error={0}", ex.Message.Replace('\n', ' '));
                Response.Redirect(url);
            }
        }



        private void PostPageChanges()
        {
            VacationsInformationRequestsInformation vacationsInformationRequestsInformation = new VacationsInformationRequestsInformation(vacationsInformationTDS);

            // Update grid rows
            foreach (GridViewRow row in grdVacations.Rows)
            {
                int requestId = Int32.Parse(grdVacations.DataKeys[row.RowIndex].Values["RequestID"].ToString());
                if (((CheckBox)row.FindControl("cbxSelected")).Checked)
                {
                    vacationsInformationRequestsInformation.UpdateState(requestId, "Cancelled");
                }               
            }

            // Store datasets
            Session["vacationsInformationTDS"] = vacationsInformationTDS;
        }



    }
}