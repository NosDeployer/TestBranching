using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.BL.Resources.Companies;
using LiquiForce.LFSLive.DA.Resources.Companies;
using LiquiForce.LFSLive.BL.Projects.Projects;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.BL.Assets.Assets;
using LiquiForce.LFSLive.DA.RAF;
using System.Collections;


namespace LiquiForce.LFSLive.WebUI.CWP.ManholeRehabilitation
{
    /// <summary>
    /// mr_summary_report
    /// </summary>
    public partial class mr_summary_report : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // EVENTS
        //
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Access to this page
                if (!Convert.ToBoolean(Session["sgLFS_CWP_MANHOLEREHABILITATION_VIEW"]))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if (((string)Request.QueryString["client_id"] == null) || ((string)Request.QueryString["project_id"] == null) || ((string)Request.QueryString["work_type"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in mr_summary_report.aspx");
                }

                // Prepare initial data 
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfCurrentClientId.Value = Request.QueryString["client_id"].ToString();
                hdfCurrentProjectId.Value = Request.QueryString["project_id"].ToString();
                hdfWorkType.Value = Request.QueryString["work_type"].ToString();

                int companyId = Int32.Parse(hdfCompanyId.Value);
                CompaniesList companiesList = new CompaniesList();
                companiesList.LoadAndAddItem(-1, "(All)", companyId);
                ddlClient.DataSource = companiesList.Table;
                ddlClient.DataValueField = "COMPANIES_ID";
                ddlClient.DataTextField = "Name";
                ddlClient.DataBind();


                if (Request.QueryString["client_id"] != null)
                {
                    ddlClient.SelectedValue = Request.QueryString["client_id"];

                    // ... for project
                    ProjectList projectList = new ProjectList();
                    projectList.LoadProjectsAndAddItem(-1, "(All)", int.Parse(ddlClient.SelectedValue));
                    ddlProject.DataSource = projectList.Table;
                    ddlProject.DataValueField = "ProjectID";
                    ddlProject.DataTextField = "Name";
                    ddlProject.DataBind();
                    ddlProject.SelectedValue = Request.QueryString["project_id"];
                }
                else
                {
                    ddlClient.SelectedValue = "-1";

                    // ... for project
                    ProjectList projectList = new ProjectList();
                    projectList.LoadProjectsAndAddItem(-1, "(All)", -1);
                    ddlProject.DataSource = projectList.Table;
                    ddlProject.DataValueField = "ProjectID";
                    ddlProject.DataTextField = "Name";
                    ddlProject.DataBind();
                    ddlProject.SelectedValue = Request.QueryString["project_id"];
                }

                //  Select mhsId
                AssetSewerMHList ssetSewerMHList = new AssetSewerMHList();
                ssetSewerMHList.LoadAndAddItem(Int32.Parse(hdfCurrentProjectId.Value), "-1", "(All)", Int32.Parse(hdfCompanyId.Value));
                cbxlMhId.DataSource = ssetSewerMHList.Table;
                cbxlMhId.DataValueField = "AssetID";
                cbxlMhId.DataTextField = "MHID";
                cbxlMhId.DataBind();

                cbxMhId.Checked = true;

                // ... ... if comming from lm
                if (Request.QueryString["source_page"].ToString() == "lm")
                {
                    if (Session["mhIdSelected"] != null)
                    {

                        ArrayList mhIdSelected = (ArrayList)Session["mhIdSelected"];
                        foreach (string mhId in mhIdSelected)
                        {
                            cbxlMhId.Items.FindByValue(mhId).Selected = true;
                        }
                    }
                    else
                    {
                        foreach (ListItem lst in cbxlMhId.Items)
                        {
                            lst.Selected = true;
                        }
                    }
                }
                else
                {                    
                    // ... ... if comming from mr_edit
                    string mhId = Request.QueryString["asset_id"].ToString();
                    cbxlMhId.Items.FindByValue(mhId).Selected = true;                    
                }

                // Remove session for free resources
                Session.Remove("mhIdSelected");

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
            master.Title = "Manhole Rehabilitation Summary";

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
        // AUXILIAR EVENTS
        //

        protected void ddlClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProjectList projectList = new ProjectList();
            projectList.LoadProjectsAndAddItem(-1, "(All)", int.Parse(ddlClient.SelectedValue));
            ddlProject.DataSource = projectList.Table;
            ddlProject.DataValueField = "ProjectID";
            ddlProject.DataTextField = "Name";
            ddlProject.DataBind();
            ddlProject.SelectedIndex = 0;

            AssetSewerMHList assetSewerMHList = new AssetSewerMHList();
            assetSewerMHList.LoadAndAddItem(0, "-1", "", Int32.Parse(hdfCompanyId.Value));
            cbxlMhId.DataSource = assetSewerMHList.Table;
            cbxlMhId.DataValueField = "AssetID";
            cbxlMhId.DataTextField = "MHID";
            cbxlMhId.DataBind();

            if (cbxlMhId.Items.Count > 1)
            {
                foreach (ListItem lst in cbxlMhId.Items)
                {
                    lst.Selected = true;
                }
            }

            upnlMhId.Update();
        }



        protected void ddlProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            AssetSewerMHList assetSewerMHList = new AssetSewerMHList();
            assetSewerMHList.LoadAndAddItem(Int32.Parse(ddlProject.SelectedValue), "-1", "(All)", Int32.Parse(hdfCompanyId.Value));
            cbxlMhId.DataSource = assetSewerMHList.Table;
            cbxlMhId.DataValueField = "AssetID";
            cbxlMhId.DataTextField = "MHID";
            cbxlMhId.DataBind();

            if (cbxlMhId.Items.Count > 1)
            {
                foreach (ListItem lst in cbxlMhId.Items)
                {
                    lst.Selected = true;
                }
            }

            upnlMhId.Update();
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
            LiquiForce.LFSLive.BL.CWP.ManholeRehabilitation.MrSummaryReport mrSummaryReport = new LiquiForce.LFSLive.BL.CWP.ManholeRehabilitation.MrSummaryReport();
            int companyId = Int32.Parse(hdfCompanyId.Value);

            Page.Validate();
            if (Page.IsValid)
            {
                // Get Data
                // For all clients
                if (ddlClient.SelectedValue == "-1")
                {
                    // validate checkboxes
                    if (cbxMhId.Checked)
                    {
                        ArrayList assetId = new ArrayList();
                        foreach (ListItem lst in cbxlMhId.Items)
                        {
                            if (lst.Selected)
                            {
                                assetId.Add(lst.Value);
                            }
                        }

                        mrSummaryReport.LoadByAssetId(companyId, assetId);
                    }
                }

                // For specific client
                else
                {
                    // For all projects
                    if (ddlProject.SelectedValue == "-1")
                    {
                        if (cbxMhId.Checked)
                        {
                            ArrayList assetId = new ArrayList();
                            foreach (ListItem lst in cbxlMhId.Items)
                            {
                                if (lst.Selected)
                                {
                                    assetId.Add(lst.Value);
                                }
                            }

                            mrSummaryReport.LoadByCompaniesIdAssetId(companyId, int.Parse(ddlClient.SelectedValue), assetId);
                        }
                    }
                    // For specific project
                    else
                    {
                        if (cbxMhId.Checked)
                        {
                            ArrayList assetId = new ArrayList();
                            foreach (ListItem lst in cbxlMhId.Items)
                            {
                                if (lst.Selected)
                                {
                                    assetId.Add(lst.Value);
                                }
                            }

                            mrSummaryReport.LoadByCompaniesIdProjectIdAssetId(companyId, int.Parse(ddlClient.SelectedValue), int.Parse(ddlProject.SelectedValue), assetId);
                        }
                    }
                }
            }

            // ... set properties to master page
            master.Data = mrSummaryReport.Data;
            master.Table = mrSummaryReport.TableName;

            // Get report
            if (mrSummaryReport.Table.Rows.Count > 0)
            {
                if (master.Format == "pdf")
                {
                    master.Report = new MrSummaryReport();
                }
                else
                {
                    master.Report = new MrSummaryReportExport();
                }

                // ... set parameters to report
                if (master.Format == "pdf")
                {
                    if (ddlClient.SelectedValue != "-1")
                    {
                        // ... for client
                        int currentClientId = Int32.Parse(ddlClient.SelectedValue);
                        
                        CompaniesGateway companiesGateway = new CompaniesGateway();
                        companiesGateway.LoadByCompaniesId(currentClientId, companyId);
                        master.SetParameter("Client", companiesGateway.GetName(currentClientId));
                    }
                    else
                    {
                        master.SetParameter("Client", "All");
                    }

                    if (ddlProject.SelectedValue != "-1")
                    {
                        // ... for project
                        int currentProjectId = Int32.Parse(ddlProject.SelectedValue);
                        ProjectGateway projectGateway = new ProjectGateway();
                        projectGateway.LoadByProjectId(currentProjectId);
                        string name = projectGateway.GetName(currentProjectId);
                        master.SetParameter("Project", name);
                    }
                    else
                    {
                        master.SetParameter("Project", "All");
                    }

                    int loginId = Convert.ToInt32(Session["loginID"]);

                    LoginGateway loginGateway = new LoginGateway();
                    loginGateway.LoadByLoginId(loginId, companyId);
                    string user = loginGateway.GetLastName(loginId, companyId) + " " + loginGateway.GetFirstName(loginId, companyId);
                    master.SetParameter("User", user.Trim());
                }
            }
        }
               



    }



}
