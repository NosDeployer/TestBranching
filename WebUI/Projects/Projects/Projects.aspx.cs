using System;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.BL.Projects.Projects;

namespace LiquiForce.LFSLive.WebUI.Projects.Projects
{
    /// <summary>
    /// Project Navigator
    /// </summary>
    public partial class Projects : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected ProjectSelectProjectTDS projectSelectProjectTDS;
        protected ProjectSelectProjectTDS.LastUsedProjectsDataTable lastUsedProjects;






        // ////////////////////////////////////////////////////////////////////////
        // EVENTS
        //

        protected void Page_Load(object sender, EventArgs e)
        {
            this.RegisterClientScripts();

            if (!IsPostBack)
            {
                // Security check
                if (!Convert.ToBoolean(Session["sgLFS_PROJECTS_VIEW"]))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
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

                // Validate query string
                if ((string)Request.QueryString["source_page"] == null)
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in projects.aspx");
                }

                // Prepare initial data
                hdfLoginId.Value = Convert.ToInt32(Session["loginID"]).ToString();
                hdfCompanyId.Value = Session["companyID"].ToString();
                Session.Remove("lastUsedProjectsDummy");
                Session.Remove("lfsProjectNavigatorTDS");
                Session.Remove("lfsLibraryTDS");
                Session.Remove("fromAttachment");

                Session["activeTabProjects"] = "0";
                Session["dialogOpenedProjects"] = "0";

                // If coming from 
                projectSelectProjectTDS = new ProjectSelectProjectTDS();
                ProjectSelectProjectLastUsedProjectsGateway projectSelectProjectLastUsedProjectsGateway = new ProjectSelectProjectLastUsedProjectsGateway(projectSelectProjectTDS);
                projectSelectProjectLastUsedProjectsGateway.LoadByLoginId(Int32.Parse(hdfLoginId.Value), Int32.Parse(hdfCompanyId.Value));
                
                // ... Left Menu or Out
                if ((Request.QueryString["source_page"] == "lm") || (Request.QueryString["source_page"] == "out"))
                {
                    //tdNoResults.Visible = false;
                    tNoResults.Visible = false;
                    pNoResults.Visible = false;
                }

                // ... projects2.aspx
                if (Request.QueryString["source_page"] == "projects2.aspx")
                {
                    RestoreNavigatorState();
                    if ((string)Request.QueryString["no_results"] == "yes")
                    {
                        tNoResults.Visible = true;
                        pNoResults.Visible = true;
                    }
                    else
                    {
                        tNoResults.Visible = false;
                        pNoResults.Visible = false;

                        if (!Convert.ToBoolean(Session["sgLFS_PROJECTS_ADMIN"]))
                        {
                            ddlProjectType.SelectedIndex = 0;
                            ddlProjectState.SelectedIndex = 0;
                        }
                        else
                        {
                            ddlProjectTypeAdmin.SelectedIndex = 0;
                            ddlProjectStateAdmin.SelectedIndex = 0;
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
            }
        }

        
        
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            // Get data from database gateway
            ProjectNavigatorTDS projectNavigatorTDS = SubmitSearch();
            
            // Show results
            if (projectNavigatorTDS.LFS_PROJECT_NAVIGATOR.DefaultView.Count > 0)
            {
                // ... Store data
                Session["lfsProjectNavigatorTDS"] = projectNavigatorTDS;

                // ... Go to the results page
                Response.Redirect("./projects2.aspx?source_page=projects.aspx&" + GetNavigatorState());                
            }
            else
            {
                tNoResults.Visible = true;
                pNoResults.Visible = true;
            }
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

        protected void grdProjects_DataBound(object sender, EventArgs e)
        {
            AddProjectsNewEmptyFix(grdProjects);
        }





        
        // ////////////////////////////////////////////////////////////////////////
        // METHODS
        //
        
        public string GetUrl(object str)
        {
            int projectId = Int32.Parse(str.ToString());

            string url = "";
            url = "./project_summary.aspx?source_page=projects2.aspx&project_id=" + projectId.ToString() + "&active_tab=0&" + GetNavigatorState() + "&origin=grid";

            return url;
        }



        public ProjectSelectProjectTDS.LastUsedProjectsDataTable GetProjects()
        {
            lastUsedProjects = (ProjectSelectProjectTDS.LastUsedProjectsDataTable)Session["lastUsedProjectsDummy"];
            if (lastUsedProjects == null)
            {
                lastUsedProjects = ((ProjectSelectProjectTDS.LastUsedProjectsDataTable)Session["projectLastUsedProjects"]);
            }

            return lastUsedProjects;
        }



        public void DummyCommentNew(int ProjectID, int UserID, DateTime LastLoggedInDate, int COMPANY_ID)
        {
        }



        private void RegisterClientScripts()
        {
            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./projects.js");
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

            ProjectNavigator projectNavigator = new ProjectNavigator(projectNavigatorGateway.Data);
            hdfProjectId.Value = projectNavigator.GetProjectId().ToString();

            return (ProjectNavigatorTDS) projectNavigatorGateway.Data;
        }
        
        

        protected void AddProjectsNewEmptyFix(GridView grdProject)
        {
            if (grdProject.Rows.Count == 0)
            {
                ProjectSelectProjectTDS.LastUsedProjectsDataTable dt = new ProjectSelectProjectTDS.LastUsedProjectsDataTable();
                dt.AddLastUsedProjectsRow(-1, -1,  DateTime.Now, -1, false, "", false, "", "");
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


        
    }
}