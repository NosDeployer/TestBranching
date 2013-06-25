using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.BL.Projects.Projects;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.Server;
using Telerik.Web.UI;
using System.Collections;

namespace LiquiForce.LFSLive.WebUI.Projects.Projects
{
    /// <summary>
    /// Projects2
    /// </summary>
    public partial class Projects2 : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected ProjectNavigatorTDS projectNavigatorTDS;
        protected ProjectNavigatorTDS.LFS_PROJECT_NAVIGATORDataTable projectNavigator;
        protected ProjectSelectProjectTDS projectSelectProjectTDS;
        protected ProjectSelectProjectTDS.LastUsedProjectsDataTable lastUsedProjects;





                
        // ////////////////////////////////////////////////////////////////////////
        // EVENTS
        //

        protected void Page_Load(object sender, EventArgs e)
        {
            // Register client scripts
            this.RegisterClientScripts();

            if (!IsPostBack)
            {
                // Security check
                if (!Convert.ToBoolean(Session["sgLFS_PROJECTS_VIEW"]))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if (Request.QueryString["source_page"] == null)
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in projects2.aspx");
                }

                // Security check
                if (!Convert.ToBoolean(Session["sgLFS_PROJECTS_ADMIN"]))
                {
                    ddlProjectType.Visible = true;
                    ddlProjectTypeAdmin.Visible = false;
                    ddlProjectType.SelectedIndex = 0;

                    ddlProjectState.Visible = true;
                    ddlProjectStateAdmin.Visible = false;
                    ddlProjectState.SelectedIndex = 0;
                }
                else
                {
                    ddlProjectType.Visible = false;
                    ddlProjectTypeAdmin.Visible = true;
                    ddlProjectTypeAdmin.SelectedIndex = 0;

                    ddlProjectState.Visible = false;
                    ddlProjectStateAdmin.Visible = true;
                    ddlProjectStateAdmin.SelectedIndex = 0;
                }

                // Tag Page
                Session.Remove("projectNavigatorNewDummy");
                Session.Remove("projectNavigator");
                Session.Remove("projectsSelected");
                hdfPageIndex.Value = "0";

                // Prepare initial data
                lblError.Visible = false;                
                hdfLoginId.Value = Convert.ToInt32(Session["loginID"]).ToString();
                hdfCompanyId.Value = Session["companyID"].ToString();
                Session.Remove("lastUsedProjectsDummy");

                // If coming from 
                projectSelectProjectTDS = new ProjectSelectProjectTDS();
                ProjectSelectProjectLastUsedProjectsGateway projectSelectProjectLastUsedProjectsGateway = new ProjectSelectProjectLastUsedProjectsGateway(projectSelectProjectTDS);
                projectSelectProjectLastUsedProjectsGateway.LoadByLoginId(Int32.Parse(hdfLoginId.Value), Int32.Parse(hdfCompanyId.Value));

                // ... projects.aspx or projects2.aspx
                if ((Request.QueryString["source_page"] == "projects.aspx") || (Request.QueryString["source_page"] == "projects2.aspx"))
                {
                    // Restore navigator state
                    RestoreNavigatorState();

                    // Restore data
                    projectNavigatorTDS = (ProjectNavigatorTDS)Session["lfsProjectNavigatorTDS"];
                    projectNavigator = projectNavigatorTDS.LFS_PROJECT_NAVIGATOR;

                    // Store data
                    Session["projectNavigator"] = projectNavigatorTDS.LFS_PROJECT_NAVIGATOR;

                    //... for the total rows
                    if (projectNavigatorTDS.LFS_PROJECT_NAVIGATOR.Rows.Count > 0)
                    {
                        lblTotalRows.Text = "Total Rows: " + projectNavigatorTDS.LFS_PROJECT_NAVIGATOR.Rows.Count;
                        lblTotalRows.Visible = true;
                    }
                    else
                    {
                        lblTotalRows.Visible = false;
                    }
                }

                // ... project_summary.aspx, project_edit.aspx, project_sections_navigator.aspx or project_sections_navigator2.aspx
                if ((Request.QueryString["source_page"] == "project_summary.aspx") || (Request.QueryString["source_page"] == "project_edit.aspx") || (Request.QueryString["source_page"] == "project_sections_navigator.aspx") || (Request.QueryString["source_page"] == "project_sections_navigator2.aspx") || (Request.QueryString["source_page"] == "project_costing_sheets_navigator.aspx"))
                {
                    // Restore navigator state
                    RestoreNavigatorState();

                    if (Request.QueryString["update"] == "no")
                    {
                        projectNavigatorTDS = (ProjectNavigatorTDS)Session["lfsProjectNavigatorTDS"];
                        projectNavigator = projectNavigatorTDS.LFS_PROJECT_NAVIGATOR;

                        // Store data
                        Session["projectNavigator"] = projectNavigatorTDS.LFS_PROJECT_NAVIGATOR;
                    }
                    else
                    {
                        // ... Delete store data
                        Session.Contents.Remove("lfsProjectNavigatorTDS");

                        // ... Search data with updates
                        projectNavigatorTDS = SubmitSearch();

                        // ... store datasets
                        Session["lfsProjectNavigatorTDS"] = projectNavigatorTDS;
                        Session["projectNavigator"] = projectNavigatorTDS.LFS_PROJECT_NAVIGATOR;
                    }

                    //... for the total rows
                    if (projectNavigatorTDS.LFS_PROJECT_NAVIGATOR.Rows.Count > 0)
                    {
                        lblTotalRows.Text = "Total Rows: " + projectNavigatorTDS.LFS_PROJECT_NAVIGATOR.Rows.Count;
                        lblTotalRows.Visible = true;
                    }
                    else
                    {
                        lblTotalRows.Visible = false;
                    }
                }

                // ... project_delete.aspx
                if (Request.QueryString["source_page"] == "project_delete.aspx")
                {
                    // Restore navigator state
                    RestoreNavigatorState();

                    if (Request.QueryString["update"] == "no")
                    {
                        projectNavigatorTDS = (ProjectNavigatorTDS)Session["lfsProjectNavigatorTDS"];
                        projectNavigator = projectNavigatorTDS.LFS_PROJECT_NAVIGATOR;

                        // Store data
                        Session["projectNavigator"] = projectNavigatorTDS.LFS_PROJECT_NAVIGATOR;
                    }
                    else
                    {
                        // ... Delete store data
                        Session.Contents.Remove("lfsProjectNavigatorTDS");

                        // ... Search data with updates
                        projectNavigatorTDS = SubmitSearch();

                        // ... store datasets
                        Session["lfsProjectNavigatorTDS"] = projectNavigatorTDS;
                        Session["projectNavigator"] = projectNavigatorTDS.LFS_PROJECT_NAVIGATOR;
                    }

                    //... for the total rows
                    if (projectNavigatorTDS.LFS_PROJECT_NAVIGATOR.Rows.Count > 0)
                    {
                        lblTotalRows.Text = "Total Rows: " + projectNavigatorTDS.LFS_PROJECT_NAVIGATOR.Rows.Count;
                        lblTotalRows.Visible = true;
                    }
                    else
                    {
                        lblTotalRows.Visible = false;
                    }

                    // Databind
                    if (Request.QueryString["update"] != "no")
                    {
                        if (projectNavigatorTDS.LFS_PROJECT_NAVIGATOR.Rows.Count == 0)
                        {
                            string url = "./projects.aspx?source_page=projects2.aspx&" + GetNavigatorState() + "&no_results=no";
                            Response.Redirect(url);
                        }
                    }
                }

                // ... Store datasets                
                Session["projectSelectProjectTDS"] = projectSelectProjectTDS;
                Session["projectLastUsedProjects"] = projectSelectProjectTDS.LastUsedProjects;
            }
            else
            {
                // Restore datasets
                projectSelectProjectTDS = (ProjectSelectProjectTDS)Session["projectSelectProjectTDS"];

                // Restore searched data (if any)
                projectNavigatorTDS = (ProjectNavigatorTDS)Session["lfsProjectNavigatorTDS"];
                projectNavigator = projectNavigatorTDS.LFS_PROJECT_NAVIGATOR;

                //... for the total rows
                if (projectNavigatorTDS.LFS_PROJECT_NAVIGATOR.Rows.Count > 0)
                {
                    lblTotalRows.Text = "Total Rows: " + projectNavigatorTDS.LFS_PROJECT_NAVIGATOR.Rows.Count;
                }
                else
                {
                    lblTotalRows.Visible = false;
                }
            }
        }



        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string url = "";

            // Delete store data
            Session.Contents.Remove("lfsProjectNavigatorTDS");
            Session.Contents.Remove("projectNavigator");

            // Get data from DA gateway
            projectNavigatorTDS = SubmitSearch();

            // Show results
            if (projectNavigatorTDS.LFS_PROJECT_NAVIGATOR.Rows.Count > 0)
            {
                // ... Store data
                Session["lfsProjectNavigatorTDS"] = projectNavigatorTDS;
                Session["projectNavigator"] = projectNavigatorTDS.LFS_PROJECT_NAVIGATOR;

                // ... Go to the results page
                url = "./projects2.aspx?source_page=projects2.aspx&" + GetNavigatorState();
            }
            else
            {
                // ... Go to the search page
                url = "./projects.aspx?source_page=projects2.aspx&" + GetNavigatorState() + "&no_results=yes";
            }

            Response.Redirect(url);
        }



        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set active toolbar
            mForm5 master = (mForm5)this.Master;
            master.ActiveToolbar = "Projects";

            lblTitle.Text = "Search Projects";

            // Security check
            if (!Convert.ToBoolean(Session["sgLFS_PROJECTS_ADMIN"]))
            {
                tkrpbLeftMenuReports.Visible = false;
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // AUXILIAR EVENTS
        // 

        protected void ddlViewWorks_SelectedIndexChanged(object sender, EventArgs e)
        {
            int countOfSelectedProjects = SaveSelectedProjectId();
            int projectId = Int32.Parse(hdfSelectedProjectId.Value);
            int cliendId = Int32.Parse(hdfSelectedClientId.Value);

            if (projectId != 0)
            {
                if (countOfSelectedProjects == 1)
                {
                    lblError.Visible = false;

                    if (projectNavigatorTDS.LFS_PROJECT_NAVIGATOR.DefaultView.Count > 0)
                    {
                        string url = "";

                        switch (ddlViewWorks.SelectedItem.Value.ToString())
                        {
                            case "RehabAssessment":
                                url = "./../../CWP/RehabAssessment/ra_navigator.aspx?source_page=select_project.aspx&client_id=" + cliendId.ToString() + "&project_id=" + projectId.ToString() + "&work_type=Rehab Assessment";
                                break;

                            case "FullLengthLining":
                                url = "./../../CWP/FullLengthLining/fl_navigator.aspx?source_page=select_project.aspx&client_id=" + cliendId.ToString() + "&project_id=" + projectId.ToString() + "&work_type=Full Length Lining";
                                break;

                            case "PointRepairs":
                                url = "./../../CWP/PointRepairs/pr_navigator.aspx?source_page=select_project.aspx&client_id=" + cliendId.ToString() + "&project_id=" + projectId.ToString() + "&work_type=Point Repairs";
                                break;

                            case "JunctionLining":
                                url = "./../../CWP/JunctionLining/jl_navigator.aspx?source_page=Projects2.aspx&client_id=" + cliendId.ToString() + "&project_id=" + projectId.ToString() + "&work_type=Junction Lining";
                                break;
                        }

                        if (url != "") Response.Redirect(url);
                    }
                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = "Only one project must be selected.";
                }
            }
            else
            {
                lblError.Visible = true;
            }
        }



        protected void ddlCostingSheets_SelectedIndexChanged(object sender, EventArgs e)
        {
            int countOfSelectedProjects = SaveSelectedProjectId();

            if (countOfSelectedProjects > 1)
            {
                if (projectNavigatorTDS.LFS_PROJECT_NAVIGATOR.DefaultView.Count > 0)
                {
                    lblError.Visible = false;

                    // Store active tab for postback
                    Session["activeTabProjects"] = "0";
                    Session["dialogOpenedProjects"] = "0";

                    Session.Remove("lfsLibraryTDS");
                    Session.Remove("fromAttachment");

                    ddlCostingSheets.SelectedIndex = 0;

                    int clientId = int.Parse(hdfSelectedClientId.Value);

                    // Go to project_combined_costing_sheets_add.aspx
                    //Save();
                    string script = "<script language='javascript'>";
                    script += "window.open('./project_combined_costing_sheets_add.aspx?source_page=projects2.aspx&project_id=0&client_id=" + clientId.ToString() +"', '_blank', 'toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=1024, height=830')";
                    script += "</script>";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "combinedCostingSheet", script, false);
                }
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "At least two projects must be selected.";
            }
        }



        protected void grdNavigator_DataBound(object sender, EventArgs e)
        {
            AddProjectsNewEmptyFix(grdNavigator);
        }



        protected void grdNavigator_Sorting(object sender, GridViewSortEventArgs e)
        {
            string oldSort = projectNavigatorTDS.LFS_PROJECT_NAVIGATOR.DefaultView.Sort;

            if (!oldSort.Contains(e.SortExpression.ToString()))
            {
                projectNavigatorTDS.LFS_PROJECT_NAVIGATOR.DefaultView.Sort = e.SortExpression + " ASC";
            }
            else
            {
                if (oldSort.Contains("ASC"))
                {
                    projectNavigatorTDS.LFS_PROJECT_NAVIGATOR.DefaultView.Sort = e.SortExpression + " DESC";
                }
                else
                {
                    projectNavigatorTDS.LFS_PROJECT_NAVIGATOR.DefaultView.Sort = e.SortExpression + " ASC";
                }
            }

            // Store data
            Session["projectNavigatorTDS"] = projectNavigatorTDS;
            Session["projectNavigator"] = projectNavigatorTDS.LFS_PROJECT_NAVIGATOR;
        }


        
        protected void grdNavigator_RowCreated(object sender, GridViewRowEventArgs e)
        {
            // Security check
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (!Convert.ToBoolean(Session["sgLFS_PROJECTS_ADMIN"]))
                {
                    e.Row.Cells[8].Visible = false;
                }
                else
                {
                    e.Row.Cells[8].Visible = true;
                }
            }
            else if (e.Row.RowType == DataControlRowType.Header)
            {
                if (!Convert.ToBoolean(Session["sgLFS_PROJECTS_ADMIN"]))
                {
                    e.Row.Cells[8].Visible = false;
                }
                else
                {
                    e.Row.Cells[8].Visible = true;
                }
            }
        }





                
        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATION EVENTS
        //

        protected void btnAddCombinedCostingSheet_Click(object sender, EventArgs e)
        {
            int countOfSelectedProjects = SaveSelectedProjectId();

            if (countOfSelectedProjects > 1)
            {
                if (projectNavigatorTDS.LFS_PROJECT_NAVIGATOR.DefaultView.Count > 0)
                {
                    lblError.Visible = false;

                    // Store active tab for postback
                    Session["activeTabProjects"] = "0";
                    Session["dialogOpenedProjects"] = "0";

                    Session.Remove("lfsLibraryTDS");
                    Session.Remove("fromAttachment");

                    ddlCostingSheets.SelectedIndex = 0;

                    int clientId = int.Parse(hdfSelectedClientId.Value);

                    // Go to project_combined_costing_sheets_add.aspx
                    //Save();
                    string script = "<script language='javascript'>";
                    script += "window.open('./project_combined_costing_sheets_add.aspx?source_page=projects2.aspx&project_id=0&client_id=" + clientId.ToString() + "', '_blank', 'toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=1024, height=830')";
                    script += "</script>";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "combinedCostingSheet", script, false);
                }
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "At least two projects must be selected.";
            }
        }



        protected void btnOpen_Click(object sender, EventArgs e)
        {
            int countOfSelectedProjects = SaveSelectedProjectId();
            int projectId = Int32.Parse(hdfSelectedProjectId.Value);

            if (projectId != 0)
            {
                if (countOfSelectedProjects == 1)
                {
                    if (projectNavigatorTDS.LFS_PROJECT_NAVIGATOR.DefaultView.Count > 0)
                    {
                        lblError.Visible = false;

                        // Store active tab for postback
                        Session["activeTabProjects"] = "0";
                        Session["dialogOpenedProjects"] = "0";
                        Session.Remove("lfsLibraryTDS");
                        Session.Remove("fromAttachment");

                        // Go to project_summary.aspx
                        Save();
                        string url = "./project_summary.aspx?source_page=projects2.aspx&project_id=" + projectId.ToString() + "&active_tab=0&" + GetNavigatorState();
                        Response.Redirect(url);
                    }
                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = "Only one project must be selected.";
                }
            }
            else
            {
                lblError.Visible = true;
            }
        }



        protected void btnEdit_Click(object sender, EventArgs e)
        {
            int countOfSelectedProjects = SaveSelectedProjectId();
            int projectId = Int32.Parse(hdfSelectedProjectId.Value);

            if (projectId != 0)
            {
                if (countOfSelectedProjects == 1)
                {
                    if (projectNavigatorTDS.LFS_PROJECT_NAVIGATOR.DefaultView.Count > 0)
                    {
                        lblError.Visible = false;

                        // Store active tab for postback
                        Session["activeTabProjects"] = "0";
                        Session["dialogOpenedProjects"] = "0";
                        Session.Remove("lfsLibraryTDS");
                        Session.Remove("fromAttachment");

                        // Go to project_edit.aspx
                        Save();
                        string url = "./project_edit.aspx?source_page=projects2.aspx&project_id=" + projectId.ToString() + "&active_tab=0&" + GetNavigatorState() + "&origin=navigator&data_changed=no";
                        Response.Redirect(url);
                    }
                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = "Only one project must be selected.";
                }
            }
            else
            {
                lblError.Visible = true;
            }
        }



        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int countOfSelectedProjects = SaveSelectedProjectId();
            int projectId = Int32.Parse(hdfSelectedProjectId.Value);

            if (projectId != 0)
            {
                if (countOfSelectedProjects == 1)
                {
                    if (projectNavigatorTDS.LFS_PROJECT_NAVIGATOR.DefaultView.Count > 0)
                    {
                        lblError.Visible = false;

                        // Go to project_delete.aspx
                        Save();
                        string url = "./project_delete.aspx?source_page=projects2.aspx&project_id=" + projectId + "&" + GetNavigatorState();
                        Response.Redirect(url);
                    }
                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = "Only one project must be selected.";
                }
            }
            else
            {
                lblError.Visible = true;
            }
        }



        protected void btnClearSearch_Click(object sender, EventArgs e)
        {
            string url = "./projects.aspx?source_page=projects2.aspx&" + GetNavigatorState() + "&no_results=no";

            if (url != "") Response.Redirect(url);
        }



        protected void tkrmTop_ItemClick(object sender, RadMenuEventArgs e)
        {
            string url = "";

            switch (e.Item.Value)
            {
                case "mClearSearch":
                    url = "./projects.aspx?source_page=projects2.aspx&" + GetNavigatorState() + "&no_results=no";
                    break;
            }

            if (url != "") Response.Redirect(url);
        }






        // ////////////////////////////////////////////////////////////////////////
        //  METHODS
        //

        public ProjectNavigatorTDS.LFS_PROJECT_NAVIGATORDataTable GetProjects()
        {
            projectNavigator = (ProjectNavigatorTDS.LFS_PROJECT_NAVIGATORDataTable)Session["projectNavigatorNewDummy"];
            if (projectNavigator == null)
            {
                projectNavigator = ((ProjectNavigatorTDS.LFS_PROJECT_NAVIGATORDataTable)Session["projectNavigator"]);
            }

            return projectNavigator;
        }       
        


        private void RegisterClientScripts()
        {
            // Register content variables
            string contentVariables = "";
            contentVariables += "var ddlViewWorksId = '" + ddlViewWorks.UniqueID + "';";            

            // Register client-side code
            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./projects2.js");
        }



        private void RestoreNavigatorState()
        {
            // Search
            tbxProjectNumber.Text = Request.QueryString["search_projectnumber"];
            tbxName.Text = Request.QueryString["search_projectname"];
            tbxClient.Text = Request.QueryString["search_client"];
            ddlCountry.SelectedValue = Request.QueryString["search_country"];

            if (!Convert.ToBoolean(Session["sgLFS_PROJECTS_ADMIN"]))
            {
                ddlProjectType.SelectedValue = Request.QueryString["search_type"];
                ddlProjectState.SelectedValue = Request.QueryString["search_state"];
            }
            else
            {
                ddlProjectTypeAdmin.SelectedValue = Request.QueryString["search_type"];
                ddlProjectStateAdmin.SelectedValue = Request.QueryString["search_state"];
            }
        }



        private string GetNavigatorState()
        {
            // SearchOptions
            string searchOptions = "";
            searchOptions = searchOptions + "search_projectnumber=" + tbxProjectNumber.Text.Trim();
            searchOptions = searchOptions + "&search_projectname=" + tbxName.Text.Trim();
            searchOptions = searchOptions + "&search_client=" + tbxClient.Text.Trim();
            searchOptions = searchOptions + "&search_country=" + ddlCountry.SelectedItem.Value.ToString();

            if (!Convert.ToBoolean(Session["sgLFS_PROJECTS_ADMIN"]))
            {
                searchOptions = searchOptions + "&search_type=" + ddlProjectType.SelectedItem.Value.ToString();
                searchOptions = searchOptions + "&search_state=" + ddlProjectState.SelectedItem.Value.ToString();
            }
            else
            {
                searchOptions = searchOptions + "&search_type=" + ddlProjectTypeAdmin.SelectedItem.Value.ToString();
                searchOptions = searchOptions + "&search_state=" + ddlProjectStateAdmin.SelectedItem.Value.ToString();            
            }
            
            Session["navigatorState"] = searchOptions;

            // Return
            return searchOptions;
        }



        private ProjectNavigatorTDS SubmitSearch()
        {
            // Retrive parameters
            string projectNumber = tbxProjectNumber.Text.Trim();
            string name = tbxName.Text.Trim();
            string client = tbxClient.Text.Trim();
            string projectType = "";
            string projectState = "";
            string country = "";

            if (!Convert.ToBoolean(Session["sgLFS_PROJECTS_ADMIN"]))
            {
                projectType = ddlProjectType.SelectedItem.Value.ToString();
                projectState = ddlProjectState.SelectedItem.Value.ToString();
            }
            else
            {
                projectType = ddlProjectTypeAdmin.SelectedItem.Value.ToString();
                projectState = ddlProjectStateAdmin.SelectedItem.Value.ToString();            
            }

            if (ddlCountry.SelectedIndex > 0)
            {
                country = ddlCountry.SelectedValue;
            }

            // Load data
            ProjectNavigatorGateway projectNavigatorGateway = new ProjectNavigatorGateway();
            projectNavigatorGateway.LoadByProjectNumberNameClientProjectTypeProjectStateCountry(projectNumber, name, client, projectType, projectState, country);

            return (ProjectNavigatorTDS)projectNavigatorGateway.Data;
        }



        protected void AddProjectsNewEmptyFix(GridView grdNavigator)
        {
            if (grdNavigator.Rows.Count == 0)
            {
                ProjectNavigatorTDS.LFS_PROJECT_NAVIGATORDataTable dt = new ProjectNavigatorTDS.LFS_PROJECT_NAVIGATORDataTable();
                dt.AddLFS_PROJECT_NAVIGATORRow("", "", "", "", -1, "", false, -1, false, "");
                Session["projectNavigatorNewDummy"] = dt;

                grdNavigator.DataBind();
            }

            // normally executes at all postbacks
            if (grdNavigator.Rows.Count == 1)
            {
                ProjectNavigatorTDS.LFS_PROJECT_NAVIGATORDataTable dt = (ProjectNavigatorTDS.LFS_PROJECT_NAVIGATORDataTable)Session["projectNavigatorNewDummy"];
                if (dt != null)
                {
                    grdNavigator.Rows[0].Visible = false;
                    grdNavigator.Rows[0].Controls.Clear();
                }
            }
        }



        protected int SaveSelectedProjectId()
        {
            int projectIdForUpdate = 0;
            int clientIdForUpdate = 0;
            bool selected = false;
            hdfSelectedProjectId.Value = "0";
            int countOfSelectedProjects = 0;
            ArrayList projectsSelected = new ArrayList();

            ProjectNavigator projectNavigatorForUpdate = new ProjectNavigator(projectNavigatorTDS);

            foreach (GridViewRow row in grdNavigator.Rows)
            {
                // ... Update all rows
                selected = ((CheckBox)row.FindControl("cbxSelected")).Checked;
                projectIdForUpdate = Int32.Parse(((Label)row.FindControl("lblProjectID")).Text.Trim());
                clientIdForUpdate = Int32.Parse(((Label)row.FindControl("lblClientID")).Text.Trim());
                projectNavigatorForUpdate.Update(projectIdForUpdate, selected);

                // ... Save selected project
                if (selected)
                {
                    hdfSelectedProjectId.Value = projectIdForUpdate.ToString();
                    hdfSelectedClientId.Value = clientIdForUpdate.ToString();
                    countOfSelectedProjects++;

                    if (!projectsSelected.Contains(projectIdForUpdate))
                    {
                        projectsSelected.Add(projectIdForUpdate);
                    }
                }
            }
            projectNavigatorForUpdate.Data.AcceptChanges();

            // ... Store datasets
            Session["projectNavigator"] = projectNavigatorTDS.LFS_PROJECT_NAVIGATOR;
            Session["projectsSelected"] = projectsSelected;

            return countOfSelectedProjects;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        private void Save()
        {
            bool exists = false;

            // Validate page
            if (Page.IsValid)
            {
                int projectIdToSave = Int32.Parse(hdfSelectedProjectId.Value);

                ProjectSelectProjectLastUsedProjectsGateway projectSelectProjectLastUsedProjectsVerifyGateway = new ProjectSelectProjectLastUsedProjectsGateway(projectSelectProjectTDS);
                ProjectSelectProjectLastUsedProjects projectSelectProjectLastUsedProjectsVerify = new ProjectSelectProjectLastUsedProjects(projectSelectProjectLastUsedProjectsVerifyGateway.Data);
                exists = projectSelectProjectLastUsedProjectsVerify.ExistProject(projectIdToSave);

                if (exists)
                {                  
                    // New Data
                    DateTime newLastLoggedInDate = DateTime.Now;

                    // Update if exists
                    ProjectSelectProjectLastUsedProjects model = new ProjectSelectProjectLastUsedProjects(projectSelectProjectTDS);
                    model.UpdateLogginDate(projectIdToSave, newLastLoggedInDate);                    

                    Session["projectSelectProjectTDS"] = projectSelectProjectTDS;
                    Session["projectLastUsedProjects"] = projectSelectProjectTDS.LastUsedProjects;                    
                }

                // If doesn't exists at grid
                if (!exists)
                {
                    if (projectSelectProjectLastUsedProjectsVerifyGateway.Table.Rows.Count < 5)
                    {
                        // Add data if exist at grid's
                        ProjectAdd();
                    }
                    else
                    {
                        if (projectSelectProjectLastUsedProjectsVerifyGateway.Table.Rows.Count == 5)
                        {                            
                            // New Data                                
                            int newProjectId = Int32.Parse(hdfSelectedProjectId.Value);
                            int newCompanyId = Int32.Parse(hdfCompanyId.Value);
                            int newUserId = Convert.ToInt32(Session["loginID"]);
                            DateTime newLastLoggedInDate = DateTime.Now;

                            ProjectGateway projectGateway = new ProjectGateway();
                            projectGateway.LoadByProjectId(newProjectId);
                            string newProjectName = projectGateway.GetName(newProjectId) + " (" + projectGateway.GetProjectNumber(newProjectId) + ")";

                            // Update if exists
                            ProjectSelectProjectLastUsedProjects model = new ProjectSelectProjectLastUsedProjects(projectSelectProjectTDS);
                            model.Update(newProjectId, newUserId, newLastLoggedInDate, newCompanyId, false, newProjectName);

                            Session["projectSelectProjectTDS"] = projectSelectProjectTDS;
                            Session["projectLastUsedProjects"] = projectSelectProjectTDS.LastUsedProjects;
                        }
                    }
                }

                // Update data at bd
                UpdateDatabase();
            }
        }



        private void UpdateDatabase()
        {
            DB.Open();
            DB.BeginTransaction();
            try
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);

                // Update 
                ProjectSelectProjectLastUsedProjects projectSelectProjectLastUsedProjects = new ProjectSelectProjectLastUsedProjects(projectSelectProjectTDS);
                projectSelectProjectLastUsedProjects.Save(companyId);                

                DB.CommitTransaction();

                // Store datasets
                projectSelectProjectTDS.AcceptChanges();
                Session["projectSelectProjectTDS"] = projectSelectProjectTDS;
                Session["projectLastUsedProjects"] = projectSelectProjectTDS.LastUsedProjects;
            }
            catch (Exception ex)
            {
                DB.RollbackTransaction();

                string url = string.Format("./../../error_page.aspx?error={0}", ex.Message.Replace('\n', ' '));
                Response.Redirect(url);
            }
        }



        protected void AddLastLoggedInProjectsNewEmptyFix(GridView grdProject)
        {
            if (grdProject.Rows.Count == 0)
            {
                ProjectSelectProjectTDS.LastUsedProjectsDataTable dt = new ProjectSelectProjectTDS.LastUsedProjectsDataTable();
                dt.AddLastUsedProjectsRow(-1, -1, DateTime.Now, -1, false, "", false, "", "");
                Session["lastUsedProjectsDummy"] = dt;

                grdProject.DataBind();
            }

            // Normally executes at all postbacks
            if (grdProject.Rows.Count == 1)
            {
                ProjectSelectProjectTDS.LastUsedProjectsDataTable dt = (ProjectSelectProjectTDS.LastUsedProjectsDataTable)Session["lastUsedProjectsDummy"];
                if (dt != null)
                {
                    grdProject.Rows[0].Visible = false;
                    grdProject.Rows[0].Controls.Clear();
                }
            }
        }



        private void ProjectAdd()
        {
            if (Page.IsValid)
            {
                int projectId = Int32.Parse(hdfSelectedProjectId.Value);
                int companyId = Int32.Parse(hdfCompanyId.Value);
                int loginId = Convert.ToInt32(Session["loginID"]);
                DateTime lastLoggedInDate = DateTime.Now;
                bool deleted = false;

                ProjectGateway projectGateway = new ProjectGateway();
                projectGateway.LoadByProjectId(projectId);
                string projectName = projectGateway.GetName(projectId) + " (" + projectGateway.GetProjectNumber(projectId) + ")";

                ProjectSelectProjectLastUsedProjects model = new ProjectSelectProjectLastUsedProjects(projectSelectProjectTDS);
                model.Insert(projectId, loginId, lastLoggedInDate, companyId, deleted, projectName, false);

                Session.Remove("lastUsedProjectsDummy");
                Session["projectSelectProjectTDS"] = projectSelectProjectTDS;
                Session["projectLastUsedProjects"] = projectSelectProjectTDS.LastUsedProjects;
            }
        }

               

    }
}