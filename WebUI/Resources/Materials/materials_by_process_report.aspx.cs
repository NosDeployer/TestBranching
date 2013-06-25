using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.BL.RAF;
using LiquiForce.LFSLive.DA.RAF;
using LiquiForce.LFSLive.DA.Resources.Materials;
using LiquiForce.LFSLive.BL.Resources.Materials;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace LiquiForce.LFSLive.WebUI.Resources.Materials
{
    /// <summary>
    /// materials_by_process_report
    /// </summary>
    public partial class materials_by_process_report : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // INITIAL EVENTS
        //

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Security check
                if (!(Convert.ToBoolean(Session["sgLFS_RESOURCES_MATERIALS_VIEW"]) && Convert.ToBoolean(Session["sgLFS_RESOURCES_MATERIALS_EDIT"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if ((string)Request.QueryString["source_page"] == null)
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in materials_by_process_report.aspx");
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
            // Set title & criteria width
            mReport1 master = (mReport1)this.Master;
            master.Title = "Materials By Process Report";

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
            mReport1 master = (mReport1)this.Master;
            int companyId = Convert.ToInt32(Session["companyID"]);

            // Get Data
            LiquiForce.LFSLive.BL.Resources.Materials.MaterialsByProcessReport materialsByProcessReport = new LiquiForce.LFSLive.BL.Resources.Materials.MaterialsByProcessReport();

            if (ddlProcess.SelectedValue == "(All)")
            {
                materialsByProcessReport.Load(companyId);
            }
            else
            {
                string process = ddlProcess.SelectedValue;
                materialsByProcessReport.LoadByProcess(process, companyId);
            }

            // ... set properties to master page
            master.Data = materialsByProcessReport.Data;
            master.Table = materialsByProcessReport.TableName;

            // Get report
            if (materialsByProcessReport.Table.Rows.Count > 0)
            {
                if (master.Format == "pdf")
                {
                    master.Report = new MaterialsByProcessReport();

                    int loginId = Convert.ToInt32(Session["loginID"]);                    

                    LoginGateway loginGateway = new LoginGateway();
                    loginGateway.LoadByLoginId(loginId, companyId);
                    string user = loginGateway.GetLastName(loginId, companyId) + " " + loginGateway.GetFirstName(loginId, companyId);
                    master.SetParameter("User", user.Trim());

                    if (ddlProcess.SelectedValue != "-1")
                    {
                        // For process code
                        string process = ddlProcess.SelectedValue;
                        master.SetParameter("Process", process);
                    }
                    else
                    {
                        master.SetParameter("Process", "All");
                    }
                }
                else
                {
                    master.Report = new MaterialsByProcessReportExport();
                }
            }
        }



    }
}