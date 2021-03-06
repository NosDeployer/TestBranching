﻿using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.BL.Resources.Companies;
using LiquiForce.LFSLive.DA.Resources.Companies;
using LiquiForce.LFSLive.DA.RAF;
using LiquiForce.LFSLive.BL.Projects.Projects;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.BL.Assets.Assets;
using System.Collections;


namespace LiquiForce.LFSLive.WebUI.CWP.FullLengthLining
{
    /// <summary>
    /// fl_inversion_report
    /// </summary>
    public partial class fl_inversion_report : System.Web.UI.Page
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
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in fl_inversion_report.aspx");
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

                //  Select sectionsId
                AssetSewerSectionList assetSewerSectionList = new AssetSewerSectionList();
                assetSewerSectionList.LoadAndAddItem(Int32.Parse(hdfCurrentProjectId.Value), hdfWorkType.Value, "-1", "(All)", Int32.Parse(hdfCompanyId.Value));
                cbxlSectionId.DataSource = assetSewerSectionList.Table;
                cbxlSectionId.DataValueField = "SectionID";
                cbxlSectionId.DataTextField = "FlowOrderID";
                cbxlSectionId.DataBind();

                cbxSectionId.Checked = true;

                // ... ... if comming from lm
                if (Request.QueryString["source_page"].ToString() == "lm")
                {
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
                }
                else
                {
                    if (Request.QueryString["source_page"].ToString() == "fl_edit.aspx")
                    {
                        // ... ... if comming from fl_edit
                        string sectionId = Request.QueryString["section_id"].ToString();
                        cbxlSectionId.Items.FindByValue(sectionId).Selected = true;
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
            mReport1 master = (mReport1)this.Master;
            master.Title = "Inversion and Cure Sheet";

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
            LiquiForce.LFSLive.BL.CWP.FullLengthLining.FlInversionReport flInversionReport = new LiquiForce.LFSLive.BL.CWP.FullLengthLining.FlInversionReport();
            int companyId = Int32.Parse(hdfCompanyId.Value);

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

                        flInversionReport.LoadBySectionId(companyId, sectionsId);
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

                            flInversionReport.LoadByCompaniesIdSectionId(companyId, int.Parse(ddlClient.SelectedValue), sectionsId);
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

                            flInversionReport.LoadByCompaniesIdProjectIdSectionId(companyId, int.Parse(ddlClient.SelectedValue), int.Parse(ddlProject.SelectedValue), sectionsId);
                        }
                    }
                }
            }

            // ... set properties to master page
            master.Data = flInversionReport.Data;
            master.Table = flInversionReport.TableName;

            // Get report
            if (flInversionReport.Table.Rows.Count > 0)
            {
                if (master.Format == "pdf")
                {
                    master.Report = new FlInversionReport();
                }
                else
                {
                    master.Report = new FlInversionReportExport();
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
