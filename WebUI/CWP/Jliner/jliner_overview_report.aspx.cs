using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.BL.Resources.Companies;
using LiquiForce.LFSLive.DA.Resources.Companies;
using LiquiForce.LFSLive.DA.RAF;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace LiquiForce.LFSLive.WebUI.CWP.Jliner
{
    /// <summary>
    /// jliner_overview_report
    /// </summary>
    public partial class jliner_overview_report : System.Web.UI.Page
    {
        /// ////////////////////////////////////////////////////////////////////////
        /// EVENTS
        ///

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!IsPostBack)
            {
                //  Security check
                if (!Convert.ToBoolean(Session["sgLFS_APP_VIEW"]))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Prepare initial data 
                int companyId = Int32.Parse(Session["companyID"].ToString());
                CompaniesList companiesList = new CompaniesList();
                companiesList.LoadAndAddItem(-1, "(All)", companyId);
                ddlSelectAClient.DataSource = companiesList.Table;
                ddlSelectAClient.DataValueField = "COMPANIES_ID";
                ddlSelectAClient.DataTextField = "Name";
                
                if (Request.QueryString["client"] != null)
                {
                    ddlSelectAClient.SelectedValue = Request.QueryString["client"];
                }
                else
                {
                    ddlSelectAClient.SelectedValue = "-1";
                }

                // Databind
                ddlSelectAClient.DataBind();
               
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
            master.Title = "Laterals Overview Report";

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

            // Get Data
            LiquiForce.LFSLive.BL.CWP.Jliner.JlinerOverviewReport jlinerOverviewReport = new LiquiForce.LFSLive.BL.CWP.Jliner.JlinerOverviewReport();
            int companyId = Convert.ToInt32(Session["companyID"]);

            if (ddlSelectAClient.SelectedValue == "-1")
            {
                jlinerOverviewReport.Load(companyId); 
                jlinerOverviewReport.UpdateCommentsForReport();
            }
            else
            {
                jlinerOverviewReport.LoadByCompaniesID(Int32.Parse(ddlSelectAClient.SelectedValue), companyId);
                jlinerOverviewReport.UpdateCommentsForReport();
            }
                            
            // ... set properties to master page
            master.Data = jlinerOverviewReport.Data;
            master.Table = jlinerOverviewReport.TableName;
            
            // Get report
            if (jlinerOverviewReport.Table.Rows.Count > 0)
            {
                if (master.Format == "pdf")
                {
                    if (Convert.ToBoolean(Session["sgLFS_APP_ADMIN"]))
                    {
                        master.Report = new rJlinerOverviewReport();
                    }
                    else
                    {
                        master.Report = new rJLinerOverviewReportSimple();
                    }
                }
                else
                {
                    if (Convert.ToBoolean(Session["sgLFS_APP_ADMIN"]))
                    {                      
                        master.Report = new rJlinerOverviewReportExport();
                    }
                    else
                    {
                        master.Report = new rJlinerOverviewReportSimpleExport();
                    }
                }

                // ... set parameters to report
                if (master.Format == "pdf")
                {
                    if (ddlSelectAClient.SelectedValue != "-1")
                    {
                        // ... for client
                        int currentClientId = Int32.Parse(ddlSelectAClient.SelectedValue);
                        CompaniesGateway companiesGateway = new CompaniesGateway();
                        companiesGateway.LoadByCompaniesId(currentClientId, companyId);
                        master.SetParameter("Client", companiesGateway.GetName(currentClientId));
                    }
                    else
                    {
                        master.SetParameter("Client", "All");
                    }

                    int loginId = Convert.ToInt32(Session["loginID"]);                    
    
                    LoginGateway loginGateway = new LoginGateway();
                    loginGateway.LoadByLoginId(loginId, companyId);
                    string user = loginGateway.GetLastName(loginId, companyId) + " " + loginGateway.GetFirstName(loginId, companyId);
                    master.SetParameter("User", user.Trim());

                    // Report format
                    master.Report.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
                    master.Report.PrintOptions.PaperSize = PaperSize.PaperLegal;
                }
            }            
        }   
    }
}
