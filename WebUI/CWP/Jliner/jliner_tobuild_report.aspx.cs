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
using LiquiForce.LFSLive.CWP.DatabaseGateway;
using LiquiForce.LFSLive.CWP.Reports;
using LiquiForce.LFSLive.CWP.Tools;
using LiquiForce.LFSLive.DA.CWP.Jliner;
using LiquiForce.LFSLive.BL.RAF;
using LiquiForce.LFSLive.DA.Resources.Companies;
using LiquiForce.LFSLive.BL.Resources.Companies;
using LiquiForce.LFSLive.DA.RAF;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace LiquiForce.LFSLive.WebUI.CWP.Jliner
{
    /// <summary>
    /// jliner_tobuild_report
    /// </summary>
    public partial class jliner_tobuild_report : System.Web.UI.Page
    {
        /// ////////////////////////////////////////////////////////////////////////
        /// EVENTS
        ///
        
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!IsPostBack)
            {
                // Security check

                // ... Access to this page
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
            master.Title = "Liners To Build";

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






        /// ////////////////////////////////////////////////////////////////////////
        /// METHODS
        ///

        private void RegisterDelegates()
        {
            mReport1 master = (mReport1)this.Master;
            master.GenerateMethod = new mReport1.ReportMethod(Generate);
        }



        private void Generate()
        {
            mReport1 master = (mReport1)this.Master;

            // Get Data
            LiquiForce.LFSLive.BL.CWP.Jliner.JlinerToBuildReport jlinertoBuildReport = new LiquiForce.LFSLive.BL.CWP.Jliner.JlinerToBuildReport();
            int companyId = Convert.ToInt32(Session["companyID"]);

            if (ddlSelectAClient.SelectedValue == "-1")
            {
                jlinertoBuildReport.Load(companyId);
                int count = jlinertoBuildReport.Table.Rows.Count;
            }
            else
            {
                jlinertoBuildReport.LoadByCompaniesID(companyId, int.Parse(ddlSelectAClient.SelectedValue)); 
            }

            // ... Autofill liner in Process
            if (ckbxAutofillLinerInProcess.Checked)
            {
                try
                {
                    jlinertoBuildReport.UpdateForReport(companyId);
                }
                catch
                {
                    string url = string.Format("./error_page.aspx?error={0}", "Autofill Liner In Process Failed. Please check your Database");
                    Response.Redirect(url);
                }

            }

            // ... set properties to master page
            master.Data = jlinertoBuildReport.Data;
            master.Table = jlinertoBuildReport.TableName;

            // Get report
            if (jlinertoBuildReport.Table.Rows.Count > 0)
            {
                if (master.Format == "pdf")
                {                    
                    master.Report = new rJlinerToBuildReport();                                       
                }
                else
                {
                    master.Report = new rJlinerToBuildReportExport();                 
                }

                // ... set parameters to report
                if (master.Format == "pdf")
                {
                    if (ddlSelectAClient.SelectedValue != "-1")
                    {
                        // ... for client
                        int currentClientId = Int32.Parse(ddlSelectAClient.SelectedValue);
                        LiquiForce.LFSLive.DA.Resources.Companies.CompaniesGateway companiesGateway = new LiquiForce.LFSLive.DA.Resources.Companies.CompaniesGateway();
                        companiesGateway.LoadByCompaniesId(currentClientId, companyId);
                        master.SetParameter("Client", companiesGateway.GetName(currentClientId));
                    }
                    else
                    {
                        master.SetParameter("Client", "All");
                    }

                    LiquiForce.LFSLive.DA.RAF.LoginGateway loginGateway = new LiquiForce.LFSLive.DA.RAF.LoginGateway();
                    loginGateway.LoadByLoginId(Convert.ToInt32(Session["loginID"]), companyId);
                    string user = loginGateway.GetLastName(Convert.ToInt32(Session["loginID"]), companyId) + " " + loginGateway.GetFirstName(Convert.ToInt32(Session["loginID"]), companyId);
                    master.SetParameter("User", user.Trim());

                    // Report format
                    master.Report.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                    master.Report.PrintOptions.PaperSize = PaperSize.PaperLetter;
                }
            }
        }   



    }
}