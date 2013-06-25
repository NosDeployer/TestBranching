using System;
using LiquiForce.LFSLive.DA.CWP.JunctionLining;
using LiquiForce.LFSLive.DA.RAF;
using LiquiForce.LFSLive.DA.Resources.Companies;
using LiquiForce.LFSLive.DA.Resources;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.WebUI.CWP.Common
{
    /// <summary>
    /// jl_lateral_location_sheet_report
    /// </summary>
    public partial class jl_lateral_location_sheet_report : System.Web.UI.Page
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
                hdfCurrentCompanyId.Value = Session["companyID"].ToString();

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
            LiquiForce.LFSLive.BL.CWP.Common.LateralLocationSheetReport lateralLocationSheetReport = new LiquiForce.LFSLive.BL.CWP.Common.LateralLocationSheetReport();
            int companyId = Int32.Parse(hdfCurrentCompanyId.Value);
            
            // Restore TDS
            JlNavigatorTDS jlNavigatorTDS = (JlNavigatorTDS)Session["jlNavigatorTDS"];

            // Get Data            
            lateralLocationSheetReport.LoadByProjectIdJlNavigatorTDS(Int32.Parse(hdfCurrentProjectId.Value), jlNavigatorTDS, companyId);

            // ... set properties to master page
            master.Data = lateralLocationSheetReport.Data;
            master.Table = lateralLocationSheetReport.TableName;

            // Get report
            if (lateralLocationSheetReport.Table.Rows.Count > 0)
            {
                master.Report = new LateralLocationSheetReport();

                // ... for client
                int currentClientId = Int32.Parse(hdfCurrentClientId.Value);
                CompaniesGateway companiesGateway = new CompaniesGateway();
                companiesGateway.LoadByCompaniesId(currentClientId, companyId);
                master.SetParameter("Client", companiesGateway.GetName(currentClientId));

                // ... for project
                int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value);
                ProjectGateway projectGateway = new ProjectGateway();
                projectGateway.LoadByProjectId(currentProjectId);
                string name = projectGateway.GetName(currentProjectId);
                master.SetParameter("Project", projectGateway.GetProjectNumber(currentProjectId));

                int loginId = Convert.ToInt32(Session["loginID"]);                

                LoginGateway loginGateway = new LoginGateway();
                loginGateway.LoadByLoginId(loginId, companyId);
                string user = loginGateway.GetLastName(loginId, companyId) + " " + loginGateway.GetFirstName(loginId, companyId);
                master.SetParameter("User", user.Trim());
            }
        }        



    }
}