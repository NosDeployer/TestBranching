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
using LiquiForce.LFSLive.DA.CWP.Common;
using LiquiForce.LFSLive.BL.CWP.Common;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using LiquiForce.LFSLive.BL.Resources.Companies;
using LiquiForce.LFSLive.DA.Resources.Companies;
using LiquiForce.LFSLive.DA.RAF;
using LiquiForce.LFSLive.BL.Projects.Projects;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.WebUI.CWP.Common
{
    /// <summary>
    /// lateral_location_sheet_report
    /// </summary>
    public partial class lateral_location_sheet_report : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // EVENTS
        //

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // ... Access to this page
                if (!Convert.ToBoolean(Session["sgLFS_CWP_FULLLENGTHLINING_VIEW"]) || !Convert.ToBoolean(Session["sgLFS_CWP_REHABASSESSMENT_VIEW"]) || !Convert.ToBoolean(Session["sgLFS_CWP_JUNCTIONLINING_VIEW"]))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                hdfCurrentClientId.Value = Request.QueryString["client_id"].ToString();
                hdfCurrentProjectId.Value = Request.QueryString["project_id"].ToString();
                hdfCurrentAssetId.Value = Request.QueryString["asset_id"].ToString();
                hdfCurrentCompanyId.Value = Session["companyID"].ToString();
                hdfCurrentWorkId.Value = Request.QueryString["work_id"].ToString();
                hdfMeasuredFrom.Value = Request.QueryString["measured_from"].ToString();
                
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
            master.Title = "Lateral Location Sheet Report";

            master.ShowTitle = false;
            master.ShowToolBar = false;
            master.ShowCriteria = false;
            master.CriteriaWidth = "0px";
            master.ShowPreview = false;
            master.ShowExport = false;

            if (!IsPostBack)
            {
                master.PrintDirectly = true;
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
            int assetId = Int32.Parse(hdfCurrentAssetId.Value);
            int workId = Int32.Parse(hdfCurrentWorkId.Value);
            int projectId = Int32.Parse(hdfCurrentProjectId.Value);
            int companyId = Int32.Parse(hdfCurrentCompanyId.Value);
            string measuredFrom = hdfMeasuredFrom.Value;

            // Get Data
            LiquiForce.LFSLive.BL.CWP.Common.LateralLocationSheetReport lateralLocationSheetReport = new LiquiForce.LFSLive.BL.CWP.Common.LateralLocationSheetReport();
            int totalLaterals = lateralLocationSheetReport.LoadByAssetIdWorkIdProjectIdMeasuredFrom(assetId, workId, projectId, measuredFrom, companyId);
            
            // ... set properties to master page
            master.Data = lateralLocationSheetReport.Data;
            master.Table = lateralLocationSheetReport.TableName;

            // Get report
            if (lateralLocationSheetReport.Table.Rows.Count > 0)
            {
                master.Report = new LateralLocationSheetReport();

                // Section to show
                if (totalLaterals <= 26)
                {
                    ((Section)master.Report.ReportDefinition.Sections["Section3"]).SectionFormat.EnableSuppress = false;
                    ((Section)master.Report.ReportDefinition.Sections["DetailSection2"]).SectionFormat.EnableSuppress = true;
                }
                else
                {
                    ((Section)master.Report.ReportDefinition.Sections["Section3"]).SectionFormat.EnableSuppress = false;
                    ((Section)master.Report.ReportDefinition.Sections["DetailSection2"]).SectionFormat.EnableSuppress = false;
                }

                // ... for client
                int currentCompanyId = Int32.Parse(hdfCurrentClientId.Value);
                CompaniesGateway companiesGateway = new CompaniesGateway();
                companiesGateway.LoadByCompaniesId(currentCompanyId, companyId);
                master.SetParameter("Client", companiesGateway.GetName(currentCompanyId));

                // ... for project
                int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value);
                ProjectGateway projectGateway = new ProjectGateway();
                projectGateway.LoadByProjectId(currentProjectId);
                string name = projectGateway.GetName(currentProjectId);
                master.SetParameter("Project", projectGateway.GetProjectNumber(currentProjectId));

                LoginGateway loginGateway = new LoginGateway();
                loginGateway.LoadByLoginId(Convert.ToInt32(Session["loginID"]), companyId);
                string user = loginGateway.GetLastName(Convert.ToInt32(Session["loginID"]), companyId) + " " + loginGateway.GetFirstName(Convert.ToInt32(Session["loginID"]), companyId);
                master.SetParameter("User", user.Trim());
            }
        }



    }
}
