using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.BL.Projects.Projects;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.DA.Resources.Companies;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.Projects.Projects
{
    /// <summary>
    /// project_delete
    /// </summary>
    public partial class project_delete : System.Web.UI.Page
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
                if (!(Convert.ToBoolean(Session["sgLFS_PROJECTS_VIEW"]) && Convert.ToBoolean(Session["sgLFS_PROJECTS_DELETE"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["project_id"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in project_delete.aspx");
                }

                // Tag page
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfProjectId.Value = Request.QueryString["project_id"];

                // If coming from project_summary.aspx or projects2.aspx
                if (((string)Request.QueryString["source_page"] == "project_summary.aspx") || ((string)Request.QueryString["source_page"] == "projects2.aspx"))
                {
                    // Store Navigator State and Update control
                    StoreNavigatorState();
                    ViewState["update"] = Request.QueryString["update"];

                    // Get project record
                    projectTDS = new ProjectTDS();
                    ProjectGateway projectGatewayForLoad = new ProjectGateway(projectTDS);
                    projectGatewayForLoad.LoadByProjectId(int.Parse(hdfProjectId.Value));

                    // Store datasets
                    Session["lfsProjectTDS"] = projectTDS;
                }

                // Restore dataset
                projectTDS = (ProjectTDS)Session["lfsProjectTDS"];

                // Prepare initial data

                // ... for project
                int currentProjectId = Int32.Parse(hdfProjectId.Value.ToString());
                ProjectGateway projectGateway = new ProjectGateway();
                projectGateway.LoadByProjectId(currentProjectId);
                string name = projectGateway.GetName(currentProjectId);
                if (name.Length > 23) name = name.Substring(0, 20) + "...";
                lblTitleProjectName.Text = name + " (" + projectGateway.GetProjectNumber(currentProjectId) + ")";

                // ... for client
                int currentClientId = projectGateway.GetClientID(Int32.Parse(hdfProjectId.Value.ToString()));
                int companyId = Int32.Parse(hdfCompanyId.Value);
                CompaniesGateway companiesGateway = new CompaniesGateway();
                companiesGateway.LoadAllByCompaniesId(currentClientId, companyId);
                lblTitleClientName.Text = "Client: " + companiesGateway.GetName(currentClientId);
            }
            else
            {
                // Restore dataset 
                projectTDS = (ProjectTDS)Session["lfsProjectTDS"];
            }
        }        

        
        
        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set active toolbar
            mForm6 master = (mForm6)this.Master;
            master.ActiveToolbar = "Projects";

            // Project type check
            ProjectGateway projectGateway = new ProjectGateway(projectTDS);
            if (projectGateway.GetProjectType(int.Parse(hdfProjectId.Value)) == "Proposal")
            {
                lblHeaderTitle.Text = "Delete Proposal";
                lblTitleProject.Text = " > Proposal: ";
            }

            if (projectGateway.GetProjectType(int.Parse(hdfProjectId.Value)) == "Project")
            {
                lblHeaderTitle.Text = "Delete Project";
                lblTitleProject.Text = " > Project: ";
            }

            if (projectGateway.GetProjectType(int.Parse(hdfProjectId.Value)) == "Internal")
            {
                lblHeaderTitle.Text = "Delete Internal Project";
                lblTitleProject.Text = " > Internal Project: ";
            }

            if (projectGateway.GetProjectType(int.Parse(hdfProjectId.Value)) == "Ballpark")
            {
                lblHeaderTitle.Text = "Delete Ballpark";
                lblTitleProject.Text = " > Ballpark: ";
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATION EVENTS
        //

        protected void tkrmTop_ItemClick(object sender, RadMenuEventArgs e)
        {
            string url = null;

            switch (e.Item.Value)
            {
                case "mDelete":
                    Page.Validate();

                    if (Page.IsValid)
                    {
                        Delete();
                        UpdateDatabase();

                        // If coming from projects2.aspx or project_summary.aspx
                        if ((Request.QueryString["source_page"] == "projects2.aspx") || (Request.QueryString["source_page"] == "project_summary.aspx"))
                        {
                            url = string.Format("./projects2.aspx?source_page=project_delete.aspx&project_id=" + hdfProjectId.Value + GetNavigatorState() + "&update=yes");
                        }

                        Response.Redirect(url);
                    }
                    break;

                case "mCancel":
                    // If coming from projects2.aspx
                    if (Request.QueryString["source_page"] == "projects2.aspx")
                    {
                        url = "./projects2.aspx?source_page=project_delete.aspx&project_id=" + hdfProjectId.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    }

                    // If coming from project_summary.aspx
                    if (Request.QueryString["source_page"] == "project_summary.aspx")
                    {
                        url = "./project_summary.aspx?source_page=project_delete.aspx&project_id=" + hdfProjectId.Value + "&active_tab=0" + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    }

                    if (url != "") Response.Redirect(url);
                    break;
            }
        }



        protected void lkbtnDelete_Click(object sender, EventArgs e)
        {
            Page.Validate();

            if (Page.IsValid)
            {
                Delete();
                UpdateDatabase();

                string url = null;

                // If coming from projects2.aspx or project_summary.aspx
                if ((Request.QueryString["source_page"] == "projects2.aspx") || (Request.QueryString["source_page"] == "project_summary.aspx"))
                {
                    url = string.Format("./projects2.aspx?source_page=project_delete.aspx&project_id=" + hdfProjectId.Value + GetNavigatorState() + "&update=yes");
                }

                Response.Redirect(url);
            }
        }



        protected void lkbtnCancel_Click(object sender, EventArgs e)
        {
            string url = null;

            // If coming from projects2.aspx
            if (Request.QueryString["source_page"] == "projects2.aspx")
            {
                url = "./projects2.aspx?source_page=project_delete.aspx&project_id=" + hdfProjectId.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
            }

            // If coming from project_summary.aspx
            if (Request.QueryString["source_page"] == "project_summary.aspx")
            {
                url = "./project_summary.aspx?source_page=project_delete.aspx&project_id=" + hdfProjectId.Value + "&active_tab=0" + GetNavigatorState() + "&update=" + (string)ViewState["update"];
            }

            if (url != "") Response.Redirect(url);
        }



        public override void Validate()
        {
            base.Validate();

            string errorMessage = "";
            int projectId = int.Parse(hdfProjectId.Value);

            Project project = new Project(projectTDS);
            cvDelete.IsValid = (project.IsInUse(projectId, out errorMessage) == 0) ? true : false;
            cvDelete.ErrorMessage = errorMessage;
        }






        // ////////////////////////////////////////////////////////////////////////
        // METHODS
        //

        private void RegisterClientScripts()
        {
            // Publishing body's OnKeyDown event 
            HtmlGenericControl bodyUnload = (HtmlGenericControl)Page.Master.FindControl("myBody");
            bodyUnload.Attributes.Add("OnKeyDown", "OnKeyDown(event);");

            // Register content variables
            string contentVariables = "";
            contentVariables += "var hdfProjectIdId = '" + hdfProjectId.ClientID + "';";

            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./project_delete.js");
        }



        private void StoreNavigatorState()
        {
            ViewState["navigatorState"] = "&search_projectnumber=" + Request.QueryString["search_projectnumber"] + "&search_projectname=" + Request.QueryString["search_projectname"] + "&search_client=" + Request.QueryString["search_client"] + "&search_type=" + Request.QueryString["search_type"] + "&search_state=" + Request.QueryString["search_state"] + "&search_country=" + Request.QueryString["search_country"];
        }



        private string GetNavigatorState()
        {
            return (string)ViewState["navigatorState"];
        }



        private void Delete()
        {
            int projectId = int.Parse(hdfProjectId.Value);

            Project project = new Project(projectTDS);
            project.Delete(projectId, true);
        }



        private void UpdateDatabase()
        {
            try
            {
                ProjectGateway projectGateway = new ProjectGateway(projectTDS);
                projectGateway.Update();

                projectTDS.AcceptChanges();

                Session["lfsProjectTDS"] = projectTDS;
            }
            catch (Exception ex)
            {
                string url = string.Format("./../../error_page.aspx?error={0}", ex.Message.Replace('\n', ' '));
                Response.Redirect(url);
            }
        }



    }
}