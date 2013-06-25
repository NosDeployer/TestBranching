using System;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.BL.Projects.Projects;
using LiquiForce.LFSLive.DA.Resources.Companies;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.Projects.Projects
{
    /// <summary>
    /// project_sections_navigator
    /// </summary>
    public partial class project_sections_navigator : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected ProjectTDS projectTDS;






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
                if ((string)Request.QueryString["source_page"] == null)
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in project_sections_navigator.aspx");
                }

                // If coming from 

                // ... Left Menu or Out
                if ((Request.QueryString["source_page"] == "lm") || (Request.QueryString["source_page"] == "out"))
                {
                    // Store Navigator State and Update control
                    StoreNavigatorState();
                    ViewState["update"] = Request.QueryString["update"];

                    projectTDS = (ProjectTDS)Session["lfsProjectTDS"];

                    tNoResults.Visible = false;
                }

                // ... project_sections_navigator2.aspx
                if (Request.QueryString["source_page"] == "project_sections_navigator2.aspx")
                {
                    RestoreNavigatorState();

                    if ((string)Request.QueryString["no_results"] == "yes")
                    {
                        tNoResults.Visible = true;
                    }
                    else
                    {
                        tNoResults.Visible = false;
                    }
                }

                // Tag page
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfProjectId.Value = Request.QueryString["project_id"];
                ViewState["origin"] = Request.QueryString["origin"];
                ViewState["state"] = Request.QueryString["state"];
                ViewState["active_tab"] = Request.QueryString["active_tab"];

                hdfDataChanged.Value = Request.QueryString["data_changed"];
                hdfDataChangedMessage.Value = "Changes made to this project will not be saved.";
                
                projectTDS = (ProjectTDS)Session["lfsProjectTDS"];

                // ... for project
                int currentProjectId = Int32.Parse(hdfProjectId.Value.ToString());
                ProjectGateway projectGateway = new ProjectGateway();
                projectGateway.LoadByProjectId(currentProjectId);
                string name = projectGateway.GetName(currentProjectId);
                if (name.Length > 23) name = name.Substring(0, 20) + "...";
                lblTitleProjectName.Text = name + " (" + projectGateway.GetProjectNumber(currentProjectId) + ")";

                // ... for client
                int currentCompanyId = projectGateway.GetClientID(Int32.Parse(hdfProjectId.Value.ToString()));
                int companyId = Int32.Parse(hdfCompanyId.Value);
                CompaniesGateway companiesGateway = new CompaniesGateway();
                companiesGateway.LoadAllByCompaniesId(currentCompanyId, companyId);
                lblTitleClientName.Text = "Client: " + companiesGateway.GetName(currentCompanyId);
                
                hdfClientId.Value = projectGateway.GetClientID(int.Parse(hdfProjectId.Value)).ToString();
            }
            else
            {
                // Restore dataset 
                projectTDS = (ProjectTDS)Session["lfsProjectTDS"];

                // ... for project
                int currentProjectId = Int32.Parse(hdfProjectId.Value.ToString());
                ProjectGateway projectGateway = new ProjectGateway();
                projectGateway.LoadByProjectId(currentProjectId);
                string name = projectGateway.GetName(currentProjectId);
                if (name.Length > 23) name = name.Substring(0, 20) + "...";
                lblTitleProjectName.Text = name + " (" + projectGateway.GetProjectNumber(currentProjectId) + ")";

                // ... for client
                int currentCompanyId = projectGateway.GetClientID(Int32.Parse(hdfProjectId.Value.ToString()));
                int companyId = Int32.Parse(hdfCompanyId.Value);
                CompaniesGateway companiesGateway = new CompaniesGateway();
                companiesGateway.LoadAllByCompaniesId(currentCompanyId, companyId);
                lblTitleClientName.Text = "Client: " + companiesGateway.GetName(currentCompanyId);
            }
        }



        protected void btnSearch_Click(object sender, EventArgs e)
        {
            // Get data from database gateway
            ProjectSectionsNavigatorTDS projectSectionsNavigatorTDS = SubmitSearch();

            // Show results
            if (projectSectionsNavigatorTDS.LFS_PROJECT_SECTIONS_NAVIGATOR.DefaultView.Count > 0)
            {
                // ... Store data
                Session["lfsProjectSectionsNavigatorTDS"] = projectSectionsNavigatorTDS;

                // ... Go to the results page
                Response.Redirect("./project_sections_navigator2.aspx?source_page=project_sections_navigator.aspx&project_id=" + hdfProjectId.Value + GetNavigatorState() + "&origin=" + (string)ViewState["origin"] + "&update=" + (string)ViewState["update"] + "&data_changed=" + hdfDataChanged.Value + "&state=" + (string)ViewState["state"] + "&update_section=no&active_tab=" + (string)ViewState["active_tab"]);
            }
            else
            {
                ProjectGateway projectGateway = new ProjectGateway(projectTDS);
                lblTitleProjectName.Text = projectGateway.GetName(int.Parse(hdfProjectId.Value)) + " (" + projectGateway.GetProjectNumber(int.Parse(hdfProjectId.Value)) + ")";
                tNoResults.Visible = true;
            }
        }        



        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set ddlTools
            DropDownList ddlTools = (DropDownList)tkrpbLeftMenuCurrentProject.FindItemByValue("Tools").FindControl("ddlTools");
            ddlTools.Attributes.Add("onchange", "return OpenTools(this);");

            // Set active toolbar
            mForm6 master = (mForm6)this.Master;
            master.ActiveToolbar = "Projects";

            lblHeaderTitle.Text = "Project Sections";

            // Project type check
            ProjectGateway projectGateway = new ProjectGateway();
            projectGateway.LoadByProjectId(int.Parse(hdfProjectId.Value));

            // ... Name for current project
            lblTitleProjectName.Text = projectGateway.GetName(int.Parse(hdfProjectId.Value)) + " (" + projectGateway.GetProjectNumber(int.Parse(hdfProjectId.Value)) + ")";

            if (projectGateway.GetProjectType(Int32.Parse(hdfProjectId.Value)) == "Proposal")
            {
                tkrpbLeftMenuCurrentProject.Items[0].Text = "Current Proposal";
                tkrpbLeftMenuCurrentProject.Items[0].Items[0].Text = "Proposal";

                lblTitleProject.Text = " > Proposal: ";

                tkrpbLeftMenuCurrentProject.Items[0].Items[3].Visible = false; //mSections
                tkrpbLeftMenuCurrentProject.Items[0].Items[4].Visible = false; //mTools
                tkrpbLeftMenuCurrentProject.Items[0].Items[5].Visible = false; //mSeparator   
            }

            if (projectGateway.GetProjectType(Int32.Parse(hdfProjectId.Value)) == "Project")
            {
                tkrpbLeftMenuCurrentProject.Items[0].Text = "Current Project";
                tkrpbLeftMenuCurrentProject.Items[0].Items[0].Text = "Project";

                lblTitleProject.Text = " > Project: ";
            }

            if (projectGateway.GetProjectType(Int32.Parse(hdfProjectId.Value)) == "Internal")
            {
                tkrpbLeftMenuCurrentProject.Items[0].Text = "Current Internal Project";
                tkrpbLeftMenuCurrentProject.Items[0].Items[0].Text = "Internal Project";

                lblTitleProject.Text = " > Internal Project: ";

                tkrpbLeftMenuCurrentProject.Items[0].Items[3].Visible = false; //mSections
                tkrpbLeftMenuCurrentProject.Items[0].Items[4].Visible = false; //mTools
                tkrpbLeftMenuCurrentProject.Items[0].Items[5].Visible = false; //mSeparator   
            }

            if (projectGateway.GetProjectType(int.Parse(hdfProjectId.Value)) == "Ballpark")
            {
                tkrpbLeftMenuCurrentProject.Items[0].Text = "Current Ballpark";
                tkrpbLeftMenuCurrentProject.Items[0].Items[0].Text = "Ballpark";

                lblTitleProject.Text = " > Ballpark: ";

                tkrpbLeftMenuCurrentProject.Items[0].Items[3].Visible = false; //mSections
                tkrpbLeftMenuCurrentProject.Items[0].Items[4].Visible = false; //mTools
                tkrpbLeftMenuCurrentProject.Items[0].Items[5].Visible = false; //mSeparator   
            }

            // Security check
            if (!Convert.ToBoolean(Session["sgLFS_PROJECTS_ADMIN"]))
            {
                tkrpbLeftMenuReports.Visible = false;
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATION EVENTS
        //

        protected void tkrmTop_ItemClick(object sender, RadMenuEventArgs e)
        {
            string url = "";

            switch (e.Item.Value)
            {
                case "mLastSearch":
                    url = "./projects2.aspx?source_page=project_sections_navigator.aspx&project_id=" + hdfProjectId.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    break;
            }

            if (url != "") Response.Redirect(url);
        }



        protected void tkrpbLeftMenu_ItemClick(object sender, RadPanelBarEventArgs e)
        {
            string url = "";

            switch (e.Item.Value)
            {
                case "mProjectCostingSheets":
                    url = "./project_costing_sheets_navigator.aspx?source_page=project_sections_navigator.aspx&project_id=" + hdfProjectId.Value + "&active_tab=" + (string)ViewState["active_tab"] + GetNavigatorState() + "&origin=" + (string)ViewState["origin"] + "&update=" + (string)ViewState["update"] + "&data_changed=" + hdfDataChanged.Value + "&state=" + (string)ViewState["state"];
                    break;

                case "mProject":
                    if (ViewState["state"].ToString() == "summary")
                    {
                        url = "./project_summary.aspx?source_page=lm&project_id=" + hdfProjectId.Value + "&active_tab=" + (string)ViewState["active_tab"] + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    }

                    if (ViewState["state"].ToString() == "edit")
                    {
                        url = "./project_edit.aspx?source_page=lm&project_id=" + hdfProjectId.Value + "&active_tab=" + (string)ViewState["active_tab"] + GetNavigatorState() + "&origin=" + (string)ViewState["origin"] + "&update=" + (string)ViewState["update"] + "&data_changed=" + hdfDataChanged.Value;
                    }
                    break;

                case "mSearch":
                    url = "./projects.aspx?source_page=lm";
                    break;
            }

            if (url != "") Response.Redirect(url);
        }



       

        
        // ////////////////////////////////////////////////////////////////////////
        // METHODS
        //

        private void RegisterClientScripts()
        {
            // Register content variables
            string contentVariables = "";
            contentVariables += "var hdfProjectIdId = '" + hdfProjectId.ClientID + "';";
            contentVariables += "var hdfClientIdId = '" + hdfClientId.ClientID + "';";
            contentVariables += "var hdfDataChangedId = '" + hdfDataChanged.ClientID + "';";
            contentVariables += "var hdfDataChangedMessageId = '" + hdfDataChangedMessage.ClientID + "';";
            contentVariables += "var hdfBeforeUnloadOrigenId = '" + hdfBeforeUnloadOrigen.ClientID + "';";

            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode1", "./project_sections_navigator.js");
        }



        private void RestoreNavigatorState()
        {
            // Search
            tbxID.Text = Request.QueryString["search_section_id"];
            tbxStreet.Text = Request.QueryString["search_street"];
            tbxUSMH.Text = Request.QueryString["search_usmh"];
            tbxDSMH.Text = Request.QueryString["search_dsmh"];
        }



        private string GetNavigatorState()
        {
            // SearchOptions
            string searchOptions = "";
            searchOptions = searchOptions + "&search_section_id=" + tbxID.Text.Trim();
            searchOptions = searchOptions + "&search_street=" + tbxStreet.Text.Trim();
            searchOptions = searchOptions + "&search_usmh=" + tbxUSMH.Text.Trim();
            searchOptions = searchOptions + "&search_dsmh=" + tbxDSMH.Text.Trim();
            
            Session["sectionNavigatorState"] = searchOptions;

            // Return
            return searchOptions + (string)ViewState["navigatorState"]; 
        }



        private void StoreNavigatorState()
        {
            ViewState["navigatorState"] = "&search_projectnumber=" + Request.QueryString["search_projectnumber"] + "&search_projectname=" + Request.QueryString["search_projectname"] + "&search_client=" + Request.QueryString["search_client"] + "&search_type=" + Request.QueryString["search_type"] + "&search_state=" + Request.QueryString["search_state"];
        }



        private ProjectSectionsNavigatorTDS SubmitSearch()
        {
            // Retrive parameters
            string sectionID = tbxID.Text.Trim();
            string street = tbxStreet.Text.Trim();
            string usmh = tbxUSMH.Text.Trim();
            string dsmh = tbxDSMH.Text.Trim();

            // Load data
            ProjectSectionsNavigator projectSectionsNavigator = new ProjectSectionsNavigator();
            projectSectionsNavigator.LoadBySectionIDStreetUsmhDsmhCompanyIdProjectId(sectionID, street, usmh, dsmh, int.Parse(hdfCompanyId.Value), int.Parse(hdfProjectId.Value));

            return (ProjectSectionsNavigatorTDS)projectSectionsNavigator.Data;
        }



    }
}