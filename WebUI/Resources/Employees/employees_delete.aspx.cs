using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Resources.Employees;
using LiquiForce.LFSLive.BL.Resources.Employees;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.Resources.Employees
{
    /// <summary>
    /// employees_delete
    /// </summary>
    public partial class employees_delete : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected EmployeeTDS employeeTDS;
        protected EmployeeNavigatorTDS employeeNavigatorTDS;
        protected EmployeeInformationTDS employeeInformationTDS;        






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
                if (!(Convert.ToBoolean(Session["sgLFS_RESOURCES_EMPLOYEES_VIEW"]) && Convert.ToBoolean(Session["sgLFS_RESOURCES_EMPLOYEES_DELETE"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["employee_id"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in employees_delete.aspx");
                }

                // Tag page
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfCurrentEmployeeId.Value = Request.QueryString["employee_id"];
                hdfActiveTab.Value = Request.QueryString["active_tab"];

                // ... for team member title
                int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
                int employeeId = Int32.Parse(hdfCurrentEmployeeId.Value);

                EmployeeInformationTDS employeeInformationTDS = new EmployeeInformationTDS();                

                EmployeeGateway employeeGateway = new EmployeeGateway();
                employeeGateway.LoadByEmployeeId(employeeId);
                lblTitleTeamMember.Text = "Team Member: " + employeeGateway.GetFullName(employeeId);
                
                // If coming from 
                // ... employees_navigator2.aspx
                if (Request.QueryString["source_page"] == "employees_navigator2.aspx")
                {
                    StoreNavigatorState();
                    ViewState["update"] = "no";
                }

                // ... employees_summary.aspx
                if (Request.QueryString["source_page"] == "employees_summary.aspx")
                {
                    StoreNavigatorState();
                    ViewState["update"] = Request.QueryString["update"];
                }               

                // Restore dataset
                employeeNavigatorTDS = (EmployeeNavigatorTDS)Session["employeeNavigatorTDS"];
            }
            else
            {
                // Restore dataset 
                employeeNavigatorTDS = (EmployeeNavigatorTDS)Session["employeeNavigatorTDS"];
            }
        }        

                   

        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set active toolbar
            mForm6 master = (mForm6)this.Master;
            master.ActiveToolbar = "Resources";
        }






        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATION EVENTS
        //

        protected void tkrmTop_ItemClick(object sender, RadMenuEventArgs e)
        {
            string url = null;

            switch (e.Item.Value)
            {
                case "mDelete":
                    Page.Validate();

                    if (Page.IsValid)
                    {
                        Delete();
                        UpdateDatabase();

                        // Redirect
                        if (Request.QueryString["source_page"] == "employees_navigator2.aspx")
                        {
                            url = "./employees_navigator2.aspx?source_page=employees_delete.aspx&employee_id=" + hdfCurrentEmployeeId.Value + "&resource_type=" + hdfResourceType.Value + GetNavigatorState() + "&update=yes";
                        }

                        if (Request.QueryString["source_page"] == "employees_summary.aspx")
                        {
                            url = "./employees_summary.aspx?source_page=employees_delete.aspx&employee_id=" + hdfCurrentEmployeeId.Value + "&resource_type=" + hdfResourceType.Value + GetNavigatorState() + "&update=yes" + "&active_tab=" + hdfActiveTab.Value;
                        }


                        Response.Redirect(url);
                    }
                    break;

                case "mCancel":
                    if (Request.QueryString["source_page"] == "employees_navigator2.aspx")
                    {
                        url = "./employees_navigator2.aspx?source_page=employees_delete.aspx&employee_id=" + hdfCurrentEmployeeId.Value + "&resource_type=" + hdfResourceType.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    }

                    if (Request.QueryString["source_page"] == "employees_summary.aspx")
                    {
                        url = "./employees_summary.aspx?source_page=employees_delete.aspx&employee_id=" + hdfCurrentEmployeeId.Value + "&resource_type=" + hdfResourceType.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"] + "&active_tab=" + hdfActiveTab.Value;
                    }

                    if (url != "") Response.Redirect(url);
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
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./employees_delete.js");
        }



        private void StoreNavigatorState()
        {
            ViewState["navigatorState"] = "&columns_to_display=" + Request.QueryString["columns_to_display"] + "&search_ddlCondition1=" + Request.QueryString["search_ddlCondition1"] + "&search_tbxCondition1=" + Request.QueryString["search_tbxCondition1"] + "&search_sort_by=" + Request.QueryString["search_sort_by"];
        }



        private string GetNavigatorState()
        {
            return (string)ViewState["navigatorState"];
        }



        private void Delete()
        {
            int currentEmployeeId = int.Parse(hdfCurrentEmployeeId.Value);

            // Delete type history
            EmployeeInformationTDS employeeInformationTDS = new EmployeeInformationTDS();
            EmployeeInformationTypeHistoryInformation employeeInformationTypeHistoryInformation = new EmployeeInformationTypeHistoryInformation(employeeInformationTDS);
            employeeInformationTypeHistoryInformation.DeleteAll(currentEmployeeId);

            // Delete employee
            EmployeeNavigator employeeNavigator = new EmployeeNavigator(employeeNavigatorTDS);
            employeeNavigator.Delete(currentEmployeeId);           

            // Store datasets
            Session["employeeNavigatorTDS"] = employeeNavigatorTDS;
            Session["employeeInformationTDS"] = employeeInformationTDS;      
        }



        private void UpdateDatabase()
        {
            // Get ids
            int currentEmployeeId = Int32.Parse(hdfCurrentEmployeeId.Value);
            int companyId = Int32.Parse(hdfCompanyId.Value);

            // Delete
            DB.Open();
            DB.BeginTransaction();
            try
            {
                EmployeeTypeHistory employeeTypeHistory = new EmployeeTypeHistory(employeeInformationTDS);
                employeeTypeHistory.DeleteAllDirect(currentEmployeeId, companyId);

                Employee employee = new Employee(employeeTDS);
                employee.DeleteDirect(currentEmployeeId);

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