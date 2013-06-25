using System;
using System.Data;
using LiquiForce.LFSLive.DA.RAF;
using LiquiForce.LFSLive.DA.Resources.Employees;

namespace LiquiForce.LFSLive.WebUI.FleetManagement.ToDoList
{
    /// <summary>
    /// toDoList_AssignedToMe_report
    /// </summary>
    public partial class toDoList_AssignedToMe_report : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // EVENTS
        //

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // ... Access to this page
                if (!Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_TODOLIST_VIEW"]))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Tag Page
                hdfCompanyId.Value = Session["companyID"].ToString();

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
            master.Title = "To Do List Assigned To Me";

            master.ShowTitle = false;
            master.ShowToolBar = false;
            master.ShowCriteria = false;
            master.CriteriaWidth = "200px";

            if (!IsPostBack)
            {
                master.PrintDirectly = true;
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

            // Get Data
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int loginId = Convert.ToInt32(Session["loginID"]);
            EmployeeGateway employeeGateway = new EmployeeGateway(new DataSet());
            int employeeId = employeeGateway.GetEmployeIdByLoginId(loginId);

            LiquiForce.LFSLive.BL.FleetManagement.ToDoList.ToDoListToDoAssignedToMeReport toDoListToDoAssignedToMeReport = new LiquiForce.LFSLive.BL.FleetManagement.ToDoList.ToDoListToDoAssignedToMeReport();

            // could see all to do lists
            toDoListToDoAssignedToMeReport.LoadToDoAssignedToMeByEmployeeId(employeeId, companyId);

            toDoListToDoAssignedToMeReport.Table.AcceptChanges();

            // ... set properties to master page
            master.Data = toDoListToDoAssignedToMeReport.Data;
            master.Table = toDoListToDoAssignedToMeReport.TableName;

            // Get report
            if (toDoListToDoAssignedToMeReport.Table.Rows.Count > 0)
            {
                if (master.Format == "pdf")
                {
                    master.Report = new ToDoListToDoAssignedToMeReport();
                }
                else
                {
                    master.Report = new ToDoListToDoAssignedToMeReportExport();
                }

                // ... set parameters to report
                if (master.Format == "pdf")
                {                    
                    LoginGateway loginGateway = new LoginGateway();
                    loginGateway.LoadByLoginId(loginId, companyId);
                    string user = loginGateway.GetLastName(loginId, companyId) + " " + loginGateway.GetFirstName(loginId, companyId);
                    master.SetParameter("User", user.Trim());
                }
            }
        }



    }
}
