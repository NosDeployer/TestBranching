using System;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.BL.Assets.Assets;
using LiquiForce.LFSLive.BL.Projects.Projects;
using LiquiForce.LFSLive.BL.Resources.Companies;
using LiquiForce.LFSLive.DA.RAF;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.DA.Resources.Companies;
using LiquiForce.LFSLive.DA.CWP.FullLengthLining;

namespace LiquiForce.LFSLive.WebUI.CWP.FullLengthLining
{
    /// <summary>
    /// fl_m12_report
    /// </summary>
    public partial class fl_m12_report : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // EVENTS
        //
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Access to this page
                if (!Convert.ToBoolean(Session["sgLFS_CWP_FULLLENGTHLINING_VIEW"]))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if (((string)Request.QueryString["client_id"] == null) || ((string)Request.QueryString["project_id"] == null) || ((string)Request.QueryString["work_type"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in fl_m1_report.aspx");
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

                tkrdpDate.SelectedDate = DateTime.Now;

                AssetSewerSectionList assetSewerSectionList = new AssetSewerSectionList();
                assetSewerSectionList.LoadAndAddItem(Int32.Parse(hdfCurrentProjectId.Value), hdfWorkType.Value, "-1", "(All)", Int32.Parse(hdfCompanyId.Value));
                cbxlSectionId.DataSource = assetSewerSectionList.Table;
                cbxlSectionId.DataValueField = "SectionID";
                cbxlSectionId.DataTextField = "FlowOrderID";
                cbxlSectionId.DataBind();

                cbxSectionId.Checked = true;

                if (Session["sectionsSelected"] != null)
                {

                    ArrayList sectionsSelected = (ArrayList)Session["sectionsSelected"];
                    foreach (string sectionId in sectionsSelected)
                    {
                        cbxlSectionId.Items.FindByValue(sectionId).Selected = true;
                    }
                }
                else
                {
                    foreach (ListItem lst in cbxlSectionId.Items)
                    {
                        lst.Selected = true;
                    }
                }

                // Remove session for free resources
                Session.Remove("sectionsSelected");

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
            mReportForM12 master = (mReportForM12)this.Master;
            master.Title = "M1 & M2 Report";

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

            AssetSewerSectionList assetSewerSectionList = new AssetSewerSectionList();
            assetSewerSectionList.LoadAndAddItem(0, hdfWorkType.Value, "-1", "", Int32.Parse(hdfCompanyId.Value));
            cbxlSectionId.DataSource = assetSewerSectionList.Table;
            cbxlSectionId.DataValueField = "SectionID";
            cbxlSectionId.DataTextField = "FlowOrderID";
            cbxlSectionId.DataBind();

            if (cbxlSectionId.Items.Count > 1)
            {
                foreach (ListItem lst in cbxlSectionId.Items)
                {
                    lst.Selected = true;
                }
            }

            upnlSectionId.Update();
        }



        protected void ddlProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            AssetSewerSectionList assetSewerSectionList = new AssetSewerSectionList();
            assetSewerSectionList.LoadAndAddItem(Int32.Parse(ddlProject.SelectedValue), hdfWorkType.Value, "-1", "(All)", Int32.Parse(hdfCompanyId.Value));
            cbxlSectionId.DataSource = assetSewerSectionList.Table;
            cbxlSectionId.DataValueField = "SectionID";
            cbxlSectionId.DataTextField = "FlowOrderID";
            cbxlSectionId.DataBind();

            if (cbxlSectionId.Items.Count > 1)
            {
                foreach (ListItem lst in cbxlSectionId.Items)
                {
                    lst.Selected = true;
                }
            }

            upnlSectionId.Update();
        }



        protected void cvCriteria_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            if (cbxDate.Checked)
            {
                if (cbxSectionId.Checked || cbxStreet.Checked || cbxSubArea.Checked) args.IsValid = false;
            }
            else
            {
                if (cbxSectionId.Checked)
                {
                    if (cbxStreet.Checked || cbxSubArea.Checked) args.IsValid = false;
                }
                else
                {
                    if (cbxStreet.Checked)
                    {
                        if (cbxSubArea.Checked) args.IsValid = false;
                    }
                }
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // METHODS
        //

        private void RegisterDelegates()
        {
            mReportForM12 master = (mReportForM12)this.Master;
            master.GenerateMethod1 = new mReportForM12.ReportMethod1(Generate);
            master.GenerateMethod2 = new mReportForM12.ReportMethod2(Generate2);
            master.GenerateMethod3 = new mReportForM12.ReportMethod3(Generate3);
        }



        private void Generate()
        {
            mReportForM12 master = (mReportForM12)this.Master;

            string unitType = ddlUnitType.SelectedValue;
            int companyId = Int32.Parse(hdfCompanyId.Value);

            LiquiForce.LFSLive.BL.CWP.FullLengthLining.FlM1Report flM1Report = new LiquiForce.LFSLive.BL.CWP.FullLengthLining.FlM1Report();            

            Page.Validate();
            if (Page.IsValid)
            {
                // Get Data
                // For all clients
                if (ddlClient.SelectedValue == "-1")
                {
                    // validate checkboxes
                    if (cbxSectionId.Checked)
                    {
                        ArrayList sectionsId = new ArrayList();
                        foreach (ListItem lst in cbxlSectionId.Items)
                        {
                            if (lst.Selected)
                            {
                                sectionsId.Add(lst.Value);
                            }
                        }

                        flM1Report.LoadBySectionId(companyId, sectionsId, unitType);
                    }
                    else
                    {
                        if (cbxDate.Checked)
                        {
                            DateTime m1Date = DateTime.Parse(tkrdpDate.SelectedDate.Value.ToShortDateString());
                            flM1Report.LoadByDate(companyId, m1Date.ToShortDateString(), unitType);
                        }
                        else
                        {
                            if (cbxStreet.Checked)
                            {
                                flM1Report.LoadByStreet(companyId, "%" + tbxStreet.Text.Trim() + "%", unitType);
                            }
                            else
                            {
                                if (cbxSubArea.Checked)
                                {
                                    flM1Report.LoadBySubArea(companyId, "%" + tbxSubArea.Text.Trim() + "%", unitType);
                                }
                                else
                                {
                                    flM1Report.Load(companyId, unitType);
                                }
                            }
                        }
                    }
                }

                // For specific client
                else
                {
                    // For all projects
                    if (ddlProject.SelectedValue == "-1")
                    {
                        if (cbxSectionId.Checked)
                        {
                            ArrayList sectionsId = new ArrayList();
                            foreach (ListItem lst in cbxlSectionId.Items)
                            {
                                if (lst.Selected)
                                {
                                    sectionsId.Add(lst.Value);
                                }
                            }

                            flM1Report.LoadByCompaniesIdSectionId(companyId, int.Parse(ddlClient.SelectedValue), unitType, sectionsId);
                        }
                        else
                        {
                            if (cbxDate.Checked)
                            {
                                DateTime m1Date = DateTime.Parse(tkrdpDate.SelectedDate.Value.ToShortDateString());
                                flM1Report.LoadByCompaniesIdDate(companyId, int.Parse(ddlClient.SelectedValue), unitType, m1Date.ToShortDateString());
                            }
                            else
                            {
                                if (cbxStreet.Checked)
                                {
                                    flM1Report.LoadByCompaniesIdStreet(companyId, int.Parse(ddlClient.SelectedValue), unitType, "%" + tbxStreet.Text.Trim() + "%");
                                }
                                else
                                {
                                    if (cbxSubArea.Checked)
                                    {
                                        flM1Report.LoadByCompaniesIdSubArea(companyId, int.Parse(ddlClient.SelectedValue), unitType, "%" + tbxSubArea.Text.Trim() + "%");
                                    }
                                    else
                                    {
                                        flM1Report.LoadByCompaniesId(companyId, int.Parse(ddlClient.SelectedValue), unitType);
                                    }
                                }
                            }
                        }
                    }
                    // For specific project
                    else
                    {
                        if (cbxSectionId.Checked)
                        {
                            ArrayList sectionsId = new ArrayList();
                            foreach (ListItem lst in cbxlSectionId.Items)
                            {
                                if (lst.Selected)
                                {
                                    sectionsId.Add(lst.Value);
                                }
                            }

                            flM1Report.LoadByCompaniesIdProjectIdSectionId(companyId, int.Parse(ddlClient.SelectedValue), int.Parse(ddlProject.SelectedValue), unitType, sectionsId);
                        }
                        else
                        {
                            if (cbxDate.Checked)
                            {
                                DateTime m1Date = DateTime.Parse(tkrdpDate.SelectedDate.Value.ToShortDateString());
                                flM1Report.LoadByCompaniesIdProjectIdDate(companyId, int.Parse(ddlClient.SelectedValue), int.Parse(ddlProject.SelectedValue), unitType, m1Date.ToShortDateString());
                            }
                            else
                            {
                                if (cbxStreet.Checked)
                                {
                                    flM1Report.LoadByCompaniesIdProjectIdStreet(companyId, int.Parse(ddlClient.SelectedValue), int.Parse(ddlProject.SelectedValue), unitType, "%" + tbxStreet.Text.Trim() + "%");
                                }
                                else
                                {
                                    if (cbxSubArea.Checked)
                                    {
                                        flM1Report.LoadByCompaniesIdProjectIdSubArea(companyId, int.Parse(ddlClient.SelectedValue), int.Parse(ddlProject.SelectedValue), unitType, "%" + tbxSubArea.Text.Trim() + "%");
                                    }
                                    else
                                    {
                                        flM1Report.LoadByCompaniesIdProjectId(companyId, int.Parse(ddlClient.SelectedValue), int.Parse(ddlProject.SelectedValue), unitType);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            // ... set properties to master page
            master.Data1 = flM1Report.Data;
            master.Table1 = flM1Report.TableName;

            // Get report
            if (flM1Report.Table.Rows.Count > 0)
            {
                if (master.Format1 == "pdf")
                {
                    master.Report1 = new FlM1Report();
                }
                else
                {
                    master.Report1 = new FlM1ReportExport();
                }

                // ... set parameters to report
                if (master.Format1 == "pdf")
                {
                    if (ddlClient.SelectedValue != "-1")
                    {
                        // ... for client
                        int currentClientId = Int32.Parse(ddlClient.SelectedValue);
                        CompaniesGateway companiesGateway = new CompaniesGateway();
                        companiesGateway.LoadByCompaniesId(currentClientId, companyId);
                        master.SetParameter1("Client", companiesGateway.GetName(currentClientId));
                    }
                    else
                    {
                        master.SetParameter1("Client", "All");
                    }

                    if (ddlProject.SelectedValue != "-1")
                    {
                        // ... for project
                        int currentProjectId = Int32.Parse(ddlProject.SelectedValue);
                        ProjectGateway projectGateway = new ProjectGateway();
                        projectGateway.LoadByProjectId(currentProjectId);
                        string name = projectGateway.GetName(currentProjectId);
                        master.SetParameter1("Project", name);
                    }
                    else
                    {
                        master.SetParameter1("Project", "All");
                    }

                    master.SetParameter1("UnitType", unitType);

                    int loginId = Convert.ToInt32(Session["loginID"]);

                    LoginGateway loginGateway = new LoginGateway();
                    loginGateway.LoadByLoginId(loginId, companyId);
                    string user = loginGateway.GetLastName(loginId, companyId) + " " + loginGateway.GetFirstName(loginId, companyId);
                    master.SetParameter1("User", user.Trim());
                }
            }
        }



        private void Generate2()
        {
            mReportForM12 master = (mReportForM12)this.Master;
            string unitType = ddlUnitType.SelectedValue;

            // Get Data
            LiquiForce.LFSLive.BL.CWP.FullLengthLining.FlM2Report flM2Report = new LiquiForce.LFSLive.BL.CWP.FullLengthLining.FlM2Report();

            if (ddlClient.SelectedValue == "-1")
            {
                if (cbxSectionId.Checked)
                {
                    ArrayList sectionsId = new ArrayList();
                    foreach (ListItem lst in cbxlSectionId.Items)
                    {
                        if (lst.Selected)
                        {
                            sectionsId.Add(lst.Value);
                        }
                    }

                    flM2Report.LoadBySectionId(int.Parse(hdfCompanyId.Value), sectionsId, unitType);
                }
                else
                {
                    if (cbxDate.Checked)
                    {
                        DateTime m1Date = DateTime.Parse(tkrdpDate.SelectedDate.Value.ToShortDateString());
                        flM2Report.LoadByDate(int.Parse(hdfCompanyId.Value), m1Date.ToShortDateString(), unitType);
                    }
                    else
                    {
                        if (cbxStreet.Checked)
                        {
                            flM2Report.LoadByStreet(int.Parse(hdfCompanyId.Value), tbxStreet.Text.Trim(), unitType);
                        }
                        else
                        {
                            if (cbxSubArea.Checked)
                            {
                                flM2Report.LoadBySubArea(int.Parse(hdfCompanyId.Value), tbxSubArea.Text.Trim(), unitType);
                            }
                            else
                            {
                                flM2Report.Load(int.Parse(hdfCompanyId.Value), unitType);
                            }
                        }
                    }
                }
            }
            else
            {
                if (ddlProject.SelectedValue == "-1")
                {
                    if (cbxSectionId.Checked)
                    {
                        ArrayList sectionsId = new ArrayList();
                        foreach (ListItem lst in cbxlSectionId.Items)
                        {
                            if (lst.Selected)
                            {
                                sectionsId.Add(lst.Value);
                            }
                        }

                        flM2Report.LoadByCompaniesIdSectionId(int.Parse(hdfCompanyId.Value), int.Parse(ddlClient.SelectedValue), unitType, sectionsId);
                    }
                    else
                    {
                        if (cbxDate.Checked)
                        {
                            DateTime m1Date = DateTime.Parse(tkrdpDate.SelectedDate.Value.ToShortDateString());
                            flM2Report.LoadByCompaniesIdDate(int.Parse(hdfCompanyId.Value), int.Parse(ddlClient.SelectedValue), unitType, m1Date.ToShortDateString());
                        }
                        else
                        {
                            if (cbxStreet.Checked)
                            {
                                flM2Report.LoadByCompaniesIdStreet(int.Parse(hdfCompanyId.Value), int.Parse(ddlClient.SelectedValue), unitType, tbxStreet.Text.Trim());
                            }
                            else
                            {
                                if (cbxSubArea.Checked)
                                {
                                    flM2Report.LoadByCompaniesIdSubArea(int.Parse(hdfCompanyId.Value), int.Parse(ddlClient.SelectedValue), unitType, tbxSubArea.Text.Trim());
                                }
                                else
                                {
                                    flM2Report.LoadByCompaniesId(int.Parse(hdfCompanyId.Value), int.Parse(ddlClient.SelectedValue), unitType);
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (cbxSectionId.Checked)
                    {
                        ArrayList sectionsId = new ArrayList();
                        foreach (ListItem lst in cbxlSectionId.Items)
                        {
                            if (lst.Selected)
                            {
                                sectionsId.Add(lst.Value);
                            }
                        }

                        flM2Report.LoadByCompaniesIdProjectIdSectionId(int.Parse(hdfCompanyId.Value), int.Parse(ddlClient.SelectedValue), int.Parse(ddlProject.SelectedValue), unitType, sectionsId);
                    }
                    else
                    {
                        if (cbxDate.Checked)
                        {
                            DateTime m1Date = DateTime.Parse(tkrdpDate.SelectedDate.Value.ToShortDateString());
                            flM2Report.LoadByCompaniesIdProjectIdDate(int.Parse(hdfCompanyId.Value), int.Parse(ddlClient.SelectedValue), int.Parse(ddlProject.SelectedValue), unitType, m1Date.ToShortDateString());
                        }
                        else
                        {
                            if (cbxStreet.Checked)
                            {
                                flM2Report.LoadByCompaniesIdProjectIdStreet(int.Parse(hdfCompanyId.Value), int.Parse(ddlClient.SelectedValue), int.Parse(ddlProject.SelectedValue), unitType, tbxStreet.Text.Trim());
                            }
                            else
                            {
                                if (cbxSubArea.Checked)
                                {
                                    flM2Report.LoadByCompaniesIdProjectIdSubArea(int.Parse(hdfCompanyId.Value), int.Parse(ddlClient.SelectedValue), int.Parse(ddlProject.SelectedValue), unitType, tbxSubArea.Text.Trim());
                                }
                                else
                                {
                                    flM2Report.LoadByCompaniesIdProjectId(int.Parse(hdfCompanyId.Value), int.Parse(ddlClient.SelectedValue), int.Parse(ddlProject.SelectedValue), unitType);
                                }
                            }
                        }
                    }
                }
            }

            // ... set properties to master page
            master.Data2 = flM2Report.Data;
            master.Table2 = flM2Report.TableName;

            // Get report
            if (flM2Report.Table.Rows.Count > 0)
            {
                if (master.Format2 == "pdf")
                {
                    master.Report2 = new FlM2Report();
                }
                else
                {
                    master.Report2 = new FlM2ReportExport();
                }

                // ... set parameters to report
                int companyId = Convert.ToInt32(Session["companyID"]);
                if (master.Format2 == "pdf")
                {
                    if (ddlClient.SelectedValue != "-1")
                    {
                        // ... for client
                        int currentCompanyId = Int32.Parse(ddlClient.SelectedValue);
                        CompaniesGateway companiesGateway = new CompaniesGateway();
                        companiesGateway.LoadByCompaniesId(currentCompanyId, companyId);
                        master.SetParameter2("Client", companiesGateway.GetName(currentCompanyId));
                    }
                    else
                    {
                        master.SetParameter2("Client", "All");
                    }

                    if (ddlProject.SelectedValue != "-1")
                    {
                        // ... for project
                        int currentProjectId = Int32.Parse(ddlProject.SelectedValue);
                        ProjectGateway projectGateway = new ProjectGateway();
                        projectGateway.LoadByProjectId(currentProjectId);
                        string name = projectGateway.GetName(currentProjectId);
                        master.SetParameter2("Project", name);
                    }
                    else
                    {
                        master.SetParameter2("Project", "All");
                    }

                    master.SetParameter2("UnitType", unitType);

                    int loginId = Convert.ToInt32(Session["loginID"]);
                    

                    LoginGateway loginGateway = new LoginGateway();
                    loginGateway.LoadByLoginId(loginId, companyId);
                    string user = loginGateway.GetLastName(loginId, companyId) + " " + loginGateway.GetFirstName(loginId, companyId);
                    master.SetParameter2("User", user.Trim());
                }
            }
        }



        private void Generate3()
        {
            mReportForM12 master = (mReportForM12)this.Master;
            string unitType = ddlUnitType.SelectedValue;
            int companyId = Convert.ToInt32(hdfCompanyId.Value);

            FlM1ReportTDS flM1ReportTDS = new FlM1ReportTDS();
            
            // Get Data            
            LiquiForce.LFSLive.BL.CWP.FullLengthLining.FlM1Report flM1Report = new LiquiForce.LFSLive.BL.CWP.FullLengthLining.FlM1Report(flM1ReportTDS);
            LiquiForce.LFSLive.BL.CWP.FullLengthLining.FlM12Report flM2Report = new LiquiForce.LFSLive.BL.CWP.FullLengthLining.FlM12Report(flM1ReportTDS);

            GetM1Data(flM1Report, unitType, companyId);
            GetM2Data(flM2Report, unitType);

            // ... set properties to master page
            //FlM1ReportTDS dataSet = new FlM1ReportTDS();
            //dataSet.M1ReportByClient.Merge(flM1Report, true);
            //dataSet.M2_SECTION.Merge(flM2Report, true);

            master.Data3 = flM1ReportTDS;
            master.Table1 = flM1Report.TableName;
            master.Table2 = flM2Report.TableName;

            // Get report
            if (flM2Report.Table.Rows.Count > 0 || flM1Report.Table.Rows.Count > 0)
            {
                if (master.Format3 == "pdf")
                {
                    master.Report3 = new FlM12Report();

                    if (ddlClient.SelectedValue != "-1")
                    {
                        // ... for client
                        int currentClientId = Int32.Parse(ddlClient.SelectedValue);

                        CompaniesGateway companiesGateway = new CompaniesGateway();
                        companiesGateway.LoadByCompaniesId(currentClientId, companyId);

                        master.SetParameter3("Client", companiesGateway.GetName(currentClientId));
                    }
                    else
                    {
                        master.SetParameter3("Client", "All");
                    }

                    if (ddlProject.SelectedValue != "-1")
                    {
                        // ... for project
                        int currentProjectId = Int32.Parse(ddlProject.SelectedValue);

                        ProjectGateway projectGateway = new ProjectGateway();
                        projectGateway.LoadByProjectId(currentProjectId);

                        string name = projectGateway.GetName(currentProjectId);
                        master.SetParameter3("Project", name);
                    }
                    else
                    {
                        master.SetParameter3("Project", "All");
                    }

                    master.SetParameter3("UnitType", unitType);

                    int loginId = Convert.ToInt32(Session["loginID"]);                    

                    LoginGateway loginGateway = new LoginGateway();
                    loginGateway.LoadByLoginId(loginId, companyId);
                    string user = loginGateway.GetLastName(loginId, companyId) + " " + loginGateway.GetFirstName(loginId, companyId);
                    master.SetParameter3("User", user.Trim());
                }
                else
                {
                    //master.Report2 = new FlM12ReportExport();
                }
            }
        }



        private void GetM2Data(LiquiForce.LFSLive.BL.CWP.FullLengthLining.FlM12Report flM2Report, string unitType)
        {
            if (ddlClient.SelectedValue == "-1")
            {
                if (cbxSectionId.Checked)
                {
                    ArrayList sectionsId = new ArrayList();
                    foreach (ListItem lst in cbxlSectionId.Items)
                    {
                        if (lst.Selected)
                        {
                            sectionsId.Add(lst.Value);
                        }
                    }

                    flM2Report.LoadBySectionId(int.Parse(hdfCompanyId.Value), sectionsId, unitType);
                }
                else
                {
                    if (cbxDate.Checked)
                    {
                        DateTime m1Date = DateTime.Parse(tkrdpDate.SelectedDate.Value.ToShortDateString());
                        flM2Report.LoadByDate(int.Parse(hdfCompanyId.Value), m1Date.ToShortDateString(), unitType);
                    }
                    else
                    {
                        if (cbxStreet.Checked)
                        {
                            flM2Report.LoadByStreet(int.Parse(hdfCompanyId.Value), tbxStreet.Text.Trim(), unitType);
                        }
                        else
                        {
                            if (cbxSubArea.Checked)
                            {
                                flM2Report.LoadBySubArea(int.Parse(hdfCompanyId.Value), tbxSubArea.Text.Trim(), unitType);
                            }
                            else
                            {
                                flM2Report.Load(int.Parse(hdfCompanyId.Value), unitType);
                            }
                        }
                    }
                }
            }
            else
            {
                if (ddlProject.SelectedValue == "-1")
                {
                    if (cbxSectionId.Checked)
                    {
                        ArrayList sectionsId = new ArrayList();
                        foreach (ListItem lst in cbxlSectionId.Items)
                        {
                            if (lst.Selected)
                            {
                                sectionsId.Add(lst.Value);
                            }
                        }

                        flM2Report.LoadByCompaniesIdSectionId(int.Parse(hdfCompanyId.Value), int.Parse(ddlClient.SelectedValue), unitType, sectionsId);
                    }
                    else
                    {
                        if (cbxDate.Checked)
                        {
                            DateTime m1Date = DateTime.Parse(tkrdpDate.SelectedDate.Value.ToShortDateString());
                            flM2Report.LoadByCompaniesIdDate(int.Parse(hdfCompanyId.Value), int.Parse(ddlClient.SelectedValue), unitType, m1Date.ToShortDateString());
                        }
                        else
                        {
                            if (cbxStreet.Checked)
                            {
                                flM2Report.LoadByCompaniesIdStreet(int.Parse(hdfCompanyId.Value), int.Parse(ddlClient.SelectedValue), unitType, tbxStreet.Text.Trim());
                            }
                            else
                            {
                                if (cbxSubArea.Checked)
                                {
                                    flM2Report.LoadByCompaniesIdSubArea(int.Parse(hdfCompanyId.Value), int.Parse(ddlClient.SelectedValue), unitType, tbxSubArea.Text.Trim());
                                }
                                else
                                {
                                    flM2Report.LoadByCompaniesId(int.Parse(hdfCompanyId.Value), int.Parse(ddlClient.SelectedValue), unitType);
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (cbxSectionId.Checked)
                    {
                        ArrayList sectionsId = new ArrayList();
                        foreach (ListItem lst in cbxlSectionId.Items)
                        {
                            if (lst.Selected)
                            {
                                sectionsId.Add(lst.Value);
                            }
                        }

                        flM2Report.LoadByCompaniesIdProjectIdSectionId(int.Parse(hdfCompanyId.Value), int.Parse(ddlClient.SelectedValue), int.Parse(ddlProject.SelectedValue), unitType, sectionsId);
                    }
                    else
                    {
                        if (cbxDate.Checked)
                        {
                            DateTime m1Date = DateTime.Parse(tkrdpDate.SelectedDate.Value.ToShortDateString());
                            flM2Report.LoadByCompaniesIdProjectIdDate(int.Parse(hdfCompanyId.Value), int.Parse(ddlClient.SelectedValue), int.Parse(ddlProject.SelectedValue), unitType, m1Date.ToShortDateString());
                        }
                        else
                        {
                            if (cbxStreet.Checked)
                            {
                                flM2Report.LoadByCompaniesIdProjectIdStreet(int.Parse(hdfCompanyId.Value), int.Parse(ddlClient.SelectedValue), int.Parse(ddlProject.SelectedValue), unitType, tbxStreet.Text.Trim());
                            }
                            else
                            {
                                if (cbxSubArea.Checked)
                                {
                                    flM2Report.LoadByCompaniesIdProjectIdSubArea(int.Parse(hdfCompanyId.Value), int.Parse(ddlClient.SelectedValue), int.Parse(ddlProject.SelectedValue), unitType, tbxSubArea.Text.Trim());
                                }
                                else
                                {
                                    flM2Report.LoadByCompaniesIdProjectId(int.Parse(hdfCompanyId.Value), int.Parse(ddlClient.SelectedValue), int.Parse(ddlProject.SelectedValue), unitType);
                                }
                            }
                        }
                    }
                }
            }
        }



        private void GetM1Data(LiquiForce.LFSLive.BL.CWP.FullLengthLining.FlM1Report flM1Report, string unitType, int companyId)
        {
            // Get Data
            // For all clients
            if (ddlClient.SelectedValue == "-1")
            {
                // validate checkboxes
                if (cbxSectionId.Checked)
                {
                    ArrayList sectionsId = new ArrayList();
                    foreach (ListItem lst in cbxlSectionId.Items)
                    {
                        if (lst.Selected)
                        {
                            sectionsId.Add(lst.Value);
                        }
                    }

                    flM1Report.LoadBySectionId(companyId, sectionsId, unitType);
                }
                else
                {
                    if (cbxDate.Checked)
                    {
                        DateTime m1Date = DateTime.Parse(tkrdpDate.SelectedDate.Value.ToShortDateString());
                        flM1Report.LoadByDate(companyId, m1Date.ToShortDateString(), unitType);
                    }
                    else
                    {
                        if (cbxStreet.Checked)
                        {
                            flM1Report.LoadByStreet(companyId, "%" + tbxStreet.Text.Trim() + "%", unitType);
                        }
                        else
                        {
                            if (cbxSubArea.Checked)
                            {
                                flM1Report.LoadBySubArea(companyId, "%" + tbxSubArea.Text.Trim() + "%", unitType);
                            }
                            else
                            {
                                flM1Report.Load(companyId, unitType);
                            }
                        }
                    }
                }
            }

            // For specific client
            else
            {
                // For all projects
                if (ddlProject.SelectedValue == "-1")
                {
                    if (cbxSectionId.Checked)
                    {
                        ArrayList sectionsId = new ArrayList();
                        foreach (ListItem lst in cbxlSectionId.Items)
                        {
                            if (lst.Selected)
                            {
                                sectionsId.Add(lst.Value);
                            }
                        }

                        flM1Report.LoadByCompaniesIdSectionId(companyId, int.Parse(ddlClient.SelectedValue), unitType, sectionsId);
                    }
                    else
                    {
                        if (cbxDate.Checked)
                        {
                            DateTime m1Date = DateTime.Parse(tkrdpDate.SelectedDate.Value.ToShortDateString());
                            flM1Report.LoadByCompaniesIdDate(companyId, int.Parse(ddlClient.SelectedValue), unitType, m1Date.ToShortDateString());
                        }
                        else
                        {
                            if (cbxStreet.Checked)
                            {
                                flM1Report.LoadByCompaniesIdStreet(companyId, int.Parse(ddlClient.SelectedValue), unitType, "%" + tbxStreet.Text.Trim() + "%");
                            }
                            else
                            {
                                if (cbxSubArea.Checked)
                                {
                                    flM1Report.LoadByCompaniesIdSubArea(companyId, int.Parse(ddlClient.SelectedValue), unitType, "%" + tbxSubArea.Text.Trim() + "%");
                                }
                                else
                                {
                                    flM1Report.LoadByCompaniesId(companyId, int.Parse(ddlClient.SelectedValue), unitType);
                                }
                            }
                        }
                    }
                }
                // For specific project
                else
                {
                    if (cbxSectionId.Checked)
                    {
                        ArrayList sectionsId = new ArrayList();
                        foreach (ListItem lst in cbxlSectionId.Items)
                        {
                            if (lst.Selected)
                            {
                                sectionsId.Add(lst.Value);
                            }
                        }

                        flM1Report.LoadByCompaniesIdProjectIdSectionId(companyId, int.Parse(ddlClient.SelectedValue), int.Parse(ddlProject.SelectedValue), unitType, sectionsId);
                    }
                    else
                    {
                        if (cbxDate.Checked)
                        {
                            DateTime m1Date = DateTime.Parse(tkrdpDate.SelectedDate.Value.ToShortDateString());
                            flM1Report.LoadByCompaniesIdProjectIdDate(companyId, int.Parse(ddlClient.SelectedValue), int.Parse(ddlProject.SelectedValue), unitType, m1Date.ToShortDateString());
                        }
                        else
                        {
                            if (cbxStreet.Checked)
                            {
                                flM1Report.LoadByCompaniesIdProjectIdStreet(companyId, int.Parse(ddlClient.SelectedValue), int.Parse(ddlProject.SelectedValue), unitType, "%" + tbxStreet.Text.Trim() + "%");
                            }
                            else
                            {
                                if (cbxSubArea.Checked)
                                {
                                    flM1Report.LoadByCompaniesIdProjectIdSubArea(companyId, int.Parse(ddlClient.SelectedValue), int.Parse(ddlProject.SelectedValue), unitType, "%" + tbxSubArea.Text.Trim() + "%");
                                }
                                else
                                {
                                    flM1Report.LoadByCompaniesIdProjectId(companyId, int.Parse(ddlClient.SelectedValue), int.Parse(ddlProject.SelectedValue), unitType);
                                }
                            }
                        }
                    }
                }
            }
        }



    }
}