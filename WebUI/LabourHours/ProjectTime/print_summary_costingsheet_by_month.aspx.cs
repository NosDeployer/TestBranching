using System;
using System.Web.UI.WebControls;
using CrystalDecisions.Shared;
using LiquiForce.LFSLive.DA.LabourHours.ProjectTime;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.DA.RAF;
using LiquiForce.LFSLive.DA.Resources.Companies;

namespace LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime
{
    /// <summary>
    /// print_summary_costingsheet_by_month
    /// </summary>
    public partial class print_summary_costingsheet_by_month : System.Web.UI.Page
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
                    if (!Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_REPORTS"]))
                    {
                        Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                    }
                }                

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
            // Dialog title
            mReport1 master = (mReport1)this.Master;

            master.Title = "Print Summary Costing Sheet By Month";

            master.ShowTitle = true;
            master.ShowToolBar = true;
            master.ShowCriteria = true;
            master.CriteriaWidth = "200px";

            if (!IsPostBack)
            {
                master.PrintDirectly = false;
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
            Page.Validate();

            if (Page.IsValid)
            {
                mReport1 master = (mReport1)this.Master;

                ProjectCostingSheetAddTDS projectCostingSheetAddTDS = new ProjectCostingSheetAddTDS();
                LiquiForce.LFSLive.BL.Projects.Projects.PrintSummaryCostingSheetByMonthDummyInformation printSummaryCostingSheetByMonthDummyInformation = new LiquiForce.LFSLive.BL.Projects.Projects.PrintSummaryCostingSheetByMonthDummyInformation(projectCostingSheetAddTDS);

                int rows = 0;
                // Get Data
                string year = ddlYear.SelectedItem.Value;
                string month = "";
                
                foreach (ListItem lst in cbxlMonth.Items)
                {
                    if (lst.Selected)
                    {
                        DateTime startDate = new DateTime(int.Parse(year), int.Parse(lst.Value), 1);
                        DateTime endDate = (startDate.AddMonths(1)).AddDays(-1);

                        rows = rows + printSummaryCostingSheetByMonthDummyInformation.LoadAll(startDate, endDate, 3, lst.Text);
                        if (lst.Text == "(All)")
                        {
                            month = "(All)";
                        }
                        else
                        {
                            month = month + ", " + lst.Text;
                        }
                    }
                }

                // ... set properties to master page
                master.Data = printSummaryCostingSheetByMonthDummyInformation.Data;
                master.Table = printSummaryCostingSheetByMonthDummyInformation.TableName;

                // Get report
                if (rows > 0)
                {
                    if (master.Format == "pdf")
                    {
                        master.Report = new PrintSummaryCostingSheetByMonthReport();

                        // ... ... user
                        LoginGateway loginGateway = new LoginGateway();
                        loginGateway.LoadByLoginId(Convert.ToInt32(Session["loginID"]), 3);
                        string user = loginGateway.GetLastName(Convert.ToInt32(Session["loginID"]), 3) + " " + loginGateway.GetFirstName(Convert.ToInt32(Session["loginID"]), 3);
                        master.SetParameter("User", user.Trim());

                        // ... for start date                                                
                        master.SetParameter("Year", year);

                        // ... for end date           
                        master.SetParameter("Month", month);
                    }
                    else
                    {
                        master.Report = new PrintSummaryCostingSheetByMonthReport();

                        // ... ... user
                        LoginGateway loginGateway = new LoginGateway();
                        loginGateway.LoadByLoginId(Convert.ToInt32(Session["loginID"]), 3);
                        string user = loginGateway.GetLastName(Convert.ToInt32(Session["loginID"]), 3) + " " + loginGateway.GetFirstName(Convert.ToInt32(Session["loginID"]), 3);
                        master.SetParameter("User", user.Trim());

                        // ... for start date                                                
                        master.SetParameter("Year", year);

                        // ... for end date           
                        master.SetParameter("Month", month);
                    }
                }
            }
        }



        private bool IsAllMonthsSelected()
        {
            foreach (ListItem lst in cbxlMonth.Items)
            {
                if (lst.Selected)
                {
                    if (lst.Value == "-1") // for (All) option
                    {
                        return true;
                    }
                }
            }

            return false;
        }



    }
}