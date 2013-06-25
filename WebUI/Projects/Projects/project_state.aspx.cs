using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.BL.Projects.Projects;
using LiquiForce.LFSLive.DA.Resources.Employees;
using LiquiForce.LFSLive.BL.Resources.Employees;
using LiquiForce.LFSLive.DA.Resources.Companies;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.Projects.Projects
{
    /// <summary>
    /// project_state
    /// </summary>
    public partial class project_state : System.Web.UI.Page
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
                if (!(Convert.ToBoolean(Session["sgLFS_PROJECTS_VIEW"]) && Convert.ToBoolean(Session["sgLFS_PROJECTS_EDIT"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if (((string)Request.QueryString["state"] == null) || ((string)Request.QueryString["project_id"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in project_state.aspx");
                }

                // Tag page
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfProjectId.Value = Request.QueryString["project_id"];
                
                // If coming from project_summary.aspx
                if ((string)Request.QueryString["source_page"] == "project_summary.aspx")
                {
                    // Store Navigator State and Update control
                    StoreNavigatorState();
                    ViewState["update"] = Request.QueryString["update"];

                    // Get project record
                    projectTDS = (ProjectTDS)Session["lfsProjectTDS"];
                    ProjectHistoryGateway projectHistoryGateway = new ProjectHistoryGateway(projectTDS);
                    projectHistoryGateway.LoadByProjectId(int.Parse(hdfProjectId.Value));

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

                // for employees
                cbxlEmployee.DataBind();
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
            if (projectGateway.GetProjectType(int.Parse(hdfProjectId.Value)) == "Ballpark")
            {
                lblHeaderTitle.Text = "Ballpark State";
                lblTitleProject.Text = " > Ballpark: ";
            }
            if (projectGateway.GetProjectType(int.Parse(hdfProjectId.Value)) == "Proposal")
            {
                lblHeaderTitle.Text = "Proposal State";
                lblTitleProject.Text = " > Proposal: ";
            }
            
            if (projectGateway.GetProjectType(int.Parse(hdfProjectId.Value)) == "Project")
            {
                lblHeaderTitle.Text = "Project State";
                lblTitleProject.Text = " > Project: ";
            }

            if (projectGateway.GetProjectType(int.Parse(hdfProjectId.Value)) == "Internal")
            {
                lblHeaderTitle.Text = "Internal Project State";
                lblTitleProject.Text = " > Internal Project: ";
            }
                        
            // Operation check
            switch ((string)Request.QueryString["state"])
            {
                //Proposal
                case "proposal_award":
                    // ...Proposal
                    tkrmTop.Items[0].Visible = true; //Award
                    tkrmTop.Items[1].Visible = false;//Lost Bid
                    tkrmTop.Items[2].Visible = false;//Cancel
                    tkrmTop.Items[3].Visible = false;//Bidding
                    tkrmTop.Items[4].Visible = false;//Unpromote
                    tkrmTop.Items[5].Visible = false;//Promote

                    // ...Project
                    tkrmTop.Items[6].Visible = false;//Waiting
                    tkrmTop.Items[7].Visible = false;//Active
                    tkrmTop.Items[8].Visible = false;//Inactive
                    tkrmTop.Items[9].Visible = false;//Complete
                    tkrmTop.Items[10].Visible = false;//Cancel
                    tkrmTop.Items[11].Visible = false;//Unpromote to ballpark
                    tkrmTop.Items[12].Visible = false;//Unpromote to proposal
                    tkrmTop.Items[13].Visible = false;//Tag as Internal
                    
                    // ... Internal Project
                    tkrmTop.Items[14].Visible = false;//Active
                    tkrmTop.Items[15].Visible = false;//Complete
                    tkrmTop.Items[16].Visible = false;//Cancel
                    tkrmTop.Items[17].Visible = false;//Promote to proposal
                    tkrmTop.Items[18].Visible = false;//Promote to Project

                    // ... Ballpark Project
                    tkrmTop.Items[19].Visible = false;//Active
                    tkrmTop.Items[20].Visible = false;//Cancel
                    tkrmTop.Items[21].Visible = false;//Promote to proposal
                    tkrmTop.Items[22].Visible = false;//Promote to Project
                    
                    // ...Cancel
                    tkrmTop.Items[23].Visible = true;
                    break;

                case "proposal_lost_bid":
                    // ...Proposal
                    tkrmTop.Items[0].Visible = false; //Award
                    tkrmTop.Items[1].Visible = true;//Lost Bid
                    tkrmTop.Items[2].Visible = false;//Cancel
                    tkrmTop.Items[3].Visible = false;//Bidding
                    tkrmTop.Items[4].Visible = false;//Unpromote
                    tkrmTop.Items[5].Visible = false;//Promote

                    // ...Project
                    tkrmTop.Items[6].Visible = false;//Waiting
                    tkrmTop.Items[7].Visible = false;//Active
                    tkrmTop.Items[8].Visible = false;//Inactive
                    tkrmTop.Items[9].Visible = false;//Complete
                    tkrmTop.Items[10].Visible = false;//Cancel
                    tkrmTop.Items[11].Visible = false;//Unpromote to ballpark
                    tkrmTop.Items[12].Visible = false;//Unpromote to proposal
                    tkrmTop.Items[13].Visible = false;//Tag as Internal

                    // ... Internal Project
                    tkrmTop.Items[14].Visible = false;//Active
                    tkrmTop.Items[15].Visible = false;//Complete
                    tkrmTop.Items[16].Visible = false;//Cancel
                    tkrmTop.Items[17].Visible = false;//Promote to proposal
                    tkrmTop.Items[18].Visible = false;//Promote to Project

                    // ... Ballpark Project
                    tkrmTop.Items[19].Visible = false;//Active
                    tkrmTop.Items[20].Visible = false;//Cancel
                    tkrmTop.Items[21].Visible = false;//Promote to proposal
                    tkrmTop.Items[22].Visible = false;//Promote to Project

                    // ...Cancel
                    tkrmTop.Items[23].Visible = true;
                    break;

                case "proposal_cancel":
                    // ...Proposal
                    tkrmTop.Items[0].Visible = false; //Award
                    tkrmTop.Items[1].Visible = false;//Lost Bid
                    tkrmTop.Items[2].Visible = true;//Cancel
                    tkrmTop.Items[3].Visible = false;//Bidding
                    tkrmTop.Items[4].Visible = false;//Unpromote
                    tkrmTop.Items[5].Visible = false;//Promote

                    // ...Project
                    tkrmTop.Items[6].Visible = false;//Waiting
                    tkrmTop.Items[7].Visible = false;//Active
                    tkrmTop.Items[8].Visible = false;//Inactive
                    tkrmTop.Items[9].Visible = false;//Complete
                    tkrmTop.Items[10].Visible = false;//Cancel
                    tkrmTop.Items[11].Visible = false;//Unpromote to ballpark
                    tkrmTop.Items[12].Visible = false;//Unpromote to proposal
                    tkrmTop.Items[13].Visible = false;//Tag as Internal

                    // ... Internal Project
                    tkrmTop.Items[14].Visible = false;//Active
                    tkrmTop.Items[15].Visible = false;//Complete
                    tkrmTop.Items[16].Visible = false;//Cancel
                    tkrmTop.Items[17].Visible = false;//Promote to proposal
                    tkrmTop.Items[18].Visible = false;//Promote to Project

                    // ... Ballpark Project
                    tkrmTop.Items[19].Visible = false;//Active
                    tkrmTop.Items[20].Visible = false;//Cancel
                    tkrmTop.Items[21].Visible = false;//Promote to proposal
                    tkrmTop.Items[22].Visible = false;//Promote to Project

                    // ...Cancel
                    tkrmTop.Items[23].Visible = true;
                    break;

                case "proposal_bidding":
                    // ...Proposal
                    tkrmTop.Items[0].Visible = false; //Award
                    tkrmTop.Items[1].Visible = false;//Lost Bid
                    tkrmTop.Items[2].Visible = false;//Cancel
                    tkrmTop.Items[3].Visible = true;//Bidding
                    tkrmTop.Items[4].Visible = false;//Unpromote
                    tkrmTop.Items[5].Visible = false;//Promote

                    // ...Project
                    tkrmTop.Items[6].Visible = false;//Waiting
                    tkrmTop.Items[7].Visible = false;//Active
                    tkrmTop.Items[8].Visible = false;//Inactive
                    tkrmTop.Items[9].Visible = false;//Complete
                    tkrmTop.Items[10].Visible = false;//Cancel
                    tkrmTop.Items[11].Visible = false;//Unpromote to ballpark
                    tkrmTop.Items[12].Visible = false;//Unpromote to proposal
                    tkrmTop.Items[13].Visible = false;//Tag as Internal

                    // ... Internal Project
                    tkrmTop.Items[14].Visible = false;//Active
                    tkrmTop.Items[15].Visible = false;//Complete
                    tkrmTop.Items[16].Visible = false;//Cancel
                    tkrmTop.Items[17].Visible = false;//Promote to proposal
                    tkrmTop.Items[18].Visible = false;//Promote to Project

                    // ... Ballpark Project
                    tkrmTop.Items[19].Visible = false;//Active
                    tkrmTop.Items[20].Visible = false;//Cancel
                    tkrmTop.Items[21].Visible = false;//Promote to proposal
                    tkrmTop.Items[22].Visible = false;//Promote to Project

                    // ...Cancel
                    tkrmTop.Items[23].Visible = true;
                    break;

                case "proposal_unpromote_to_ballpark":
                    // ...Proposal
                    tkrmTop.Items[0].Visible = false; //Award
                    tkrmTop.Items[1].Visible = false;//Lost Bid
                    tkrmTop.Items[2].Visible = false;//Cancel
                    tkrmTop.Items[3].Visible = false;//Bidding
                    tkrmTop.Items[4].Visible = true;//Unpromote
                    tkrmTop.Items[5].Visible = false;//Promote

                    // ...Project
                    tkrmTop.Items[6].Visible = false;//Waiting
                    tkrmTop.Items[7].Visible = false;//Active
                    tkrmTop.Items[8].Visible = false;//Inactive
                    tkrmTop.Items[9].Visible = false;//Complete
                    tkrmTop.Items[10].Visible = false;//Cancel
                    tkrmTop.Items[11].Visible = false;//Unpromote to ballpark
                    tkrmTop.Items[12].Visible = false;//Unpromote to proposal
                    tkrmTop.Items[13].Visible = false;//Tag as Internal

                    // ... Internal Project
                    tkrmTop.Items[14].Visible = false;//Active
                    tkrmTop.Items[15].Visible = false;//Complete
                    tkrmTop.Items[16].Visible = false;//Cancel
                    tkrmTop.Items[17].Visible = false;//Promote to proposal
                    tkrmTop.Items[18].Visible = false;//Promote to Project

                    // ... Ballpark Project
                    tkrmTop.Items[19].Visible = false;//Active
                    tkrmTop.Items[20].Visible = false;//Cancel
                    tkrmTop.Items[21].Visible = false;//Promote to proposal
                    tkrmTop.Items[22].Visible = false;//Promote to Project

                    // ...Cancel
                    tkrmTop.Items[23].Visible = true;
                    break;

                case "proposal_promote_to_project":
                    // ...Proposal
                    tkrmTop.Items[0].Visible = false; //Award
                    tkrmTop.Items[1].Visible = false;//Lost Bid
                    tkrmTop.Items[2].Visible = false;//Cancel
                    tkrmTop.Items[3].Visible = false;//Bidding
                    tkrmTop.Items[4].Visible = false;//Unpromote
                    tkrmTop.Items[5].Visible = true;//Promote

                    // ...Project
                    tkrmTop.Items[6].Visible = false;//Waiting
                    tkrmTop.Items[7].Visible = false;//Active
                    tkrmTop.Items[8].Visible = false;//Inactive
                    tkrmTop.Items[9].Visible = false;//Complete
                    tkrmTop.Items[10].Visible = false;//Cancel
                    tkrmTop.Items[11].Visible = false;//Unpromote to ballpark
                    tkrmTop.Items[12].Visible = false;//Unpromote to proposal
                    tkrmTop.Items[13].Visible = false;//Tag as Internal

                    // ... Internal Project
                    tkrmTop.Items[14].Visible = false;//Active
                    tkrmTop.Items[15].Visible = false;//Complete
                    tkrmTop.Items[16].Visible = false;//Cancel
                    tkrmTop.Items[17].Visible = false;//Promote to proposal
                    tkrmTop.Items[18].Visible = false;//Promote to Project

                    // ... Ballpark Project
                    tkrmTop.Items[19].Visible = false;//Active
                    tkrmTop.Items[20].Visible = false;//Cancel
                    tkrmTop.Items[21].Visible = false;//Promote to proposal
                    tkrmTop.Items[22].Visible = false;//Promote to Project

                    // ...Cancel
                    tkrmTop.Items[23].Visible = true;
                    break;

                //Project
                case "project_waiting":
                    // ...Proposal
                    tkrmTop.Items[0].Visible = false; //Award
                    tkrmTop.Items[1].Visible = false;//Lost Bid
                    tkrmTop.Items[2].Visible = false;//Cancel
                    tkrmTop.Items[3].Visible = false;//Bidding
                    tkrmTop.Items[4].Visible = false;//Unpromote
                    tkrmTop.Items[5].Visible = false;//Promote

                    // ...Project
                    tkrmTop.Items[6].Visible = true;//Waiting
                    tkrmTop.Items[7].Visible = false;//Active
                    tkrmTop.Items[8].Visible = false;//Inactive
                    tkrmTop.Items[9].Visible = false;//Complete
                    tkrmTop.Items[10].Visible = false;//Cancel
                    tkrmTop.Items[11].Visible = false;//Unpromote to ballpark
                    tkrmTop.Items[12].Visible = false;//Unpromote to proposal
                    tkrmTop.Items[13].Visible = false;//Tag as Internal

                    // ... Internal Project
                    tkrmTop.Items[14].Visible = false;//Active
                    tkrmTop.Items[15].Visible = false;//Complete
                    tkrmTop.Items[16].Visible = false;//Cancel
                    tkrmTop.Items[17].Visible = false;//Promote to proposal
                    tkrmTop.Items[18].Visible = false;//Promote to Project

                    // ... Ballpark Project
                    tkrmTop.Items[19].Visible = false;//Active
                    tkrmTop.Items[20].Visible = false;//Cancel
                    tkrmTop.Items[21].Visible = false;//Promote to proposal
                    tkrmTop.Items[22].Visible = false;//Promote to Project

                    // ...Cancel
                    tkrmTop.Items[23].Visible = true;
                    break;

                case "project_activate":
                    // ...Proposal
                    tkrmTop.Items[0].Visible = false; //Award
                    tkrmTop.Items[1].Visible = false;//Lost Bid
                    tkrmTop.Items[2].Visible = false;//Cancel
                    tkrmTop.Items[3].Visible = false;//Bidding
                    tkrmTop.Items[4].Visible = false;//Unpromote
                    tkrmTop.Items[5].Visible = false;//Promote

                    // ...Project
                    tkrmTop.Items[6].Visible = false;//Waiting
                    tkrmTop.Items[7].Visible = true;//Active
                    tkrmTop.Items[8].Visible = false;//Inactive
                    tkrmTop.Items[9].Visible = false;//Complete
                    tkrmTop.Items[10].Visible = false;//Cancel
                    tkrmTop.Items[11].Visible = false;//Unpromote to ballpark
                    tkrmTop.Items[12].Visible = false;//Unpromote to proposal
                    tkrmTop.Items[13].Visible = false;//Tag as Internal

                    // ... Internal Project
                    tkrmTop.Items[14].Visible = false;//Active
                    tkrmTop.Items[15].Visible = false;//Complete
                    tkrmTop.Items[16].Visible = false;//Cancel
                    tkrmTop.Items[17].Visible = false;//Promote to proposal
                    tkrmTop.Items[18].Visible = false;//Promote to Project

                    // ... Ballpark Project
                    tkrmTop.Items[19].Visible = false;//Active
                    tkrmTop.Items[20].Visible = false;//Cancel
                    tkrmTop.Items[21].Visible = false;//Promote to proposal
                    tkrmTop.Items[22].Visible = false;//Promote to Project

                    // ...Cancel
                    tkrmTop.Items[23].Visible = true;
                    break;

                case "project_inactivate":
                    // ...Proposal
                    tkrmTop.Items[0].Visible = false; //Award
                    tkrmTop.Items[1].Visible = false;//Lost Bid
                    tkrmTop.Items[2].Visible = false;//Cancel
                    tkrmTop.Items[3].Visible = false;//Bidding
                    tkrmTop.Items[4].Visible = false;//Unpromote
                    tkrmTop.Items[5].Visible = false;//Promote

                    // ...Project
                    tkrmTop.Items[6].Visible = false;//Waiting
                    tkrmTop.Items[7].Visible = false;//Active
                    tkrmTop.Items[8].Visible = true;//Inactive
                    tkrmTop.Items[9].Visible = false;//Complete
                    tkrmTop.Items[10].Visible = false;//Cancel
                    tkrmTop.Items[11].Visible = false;//Unpromote to ballpark
                    tkrmTop.Items[12].Visible = false;//Unpromote to proposal
                    tkrmTop.Items[13].Visible = false;//Tag as Internal

                    // ... Internal Project
                    tkrmTop.Items[14].Visible = false;//Active
                    tkrmTop.Items[15].Visible = false;//Complete
                    tkrmTop.Items[16].Visible = false;//Cancel
                    tkrmTop.Items[17].Visible = false;//Promote to proposal
                    tkrmTop.Items[18].Visible = false;//Promote to Project

                    // ... Ballpark Project
                    tkrmTop.Items[19].Visible = false;//Active
                    tkrmTop.Items[20].Visible = false;//Cancel
                    tkrmTop.Items[21].Visible = false;//Promote to proposal
                    tkrmTop.Items[22].Visible = false;//Promote to Project

                    // ...Cancel
                    tkrmTop.Items[23].Visible = true;
                    break;

                case "project_complete":
                    // ...Proposal
                    tkrmTop.Items[0].Visible = false; //Award
                    tkrmTop.Items[1].Visible = false;//Lost Bid
                    tkrmTop.Items[2].Visible = false;//Cancel
                    tkrmTop.Items[3].Visible = false;//Bidding
                    tkrmTop.Items[4].Visible = false;//Unpromote
                    tkrmTop.Items[5].Visible = false;//Promote

                    // ...Project
                    tkrmTop.Items[6].Visible = false;//Waiting
                    tkrmTop.Items[7].Visible = false;//Active
                    tkrmTop.Items[8].Visible = false;//Inactive
                    tkrmTop.Items[9].Visible = true;//Complete
                    tkrmTop.Items[10].Visible = false;//Cancel
                    tkrmTop.Items[11].Visible = false;//Unpromote to ballpark
                    tkrmTop.Items[12].Visible = false;//Unpromote to proposal
                    tkrmTop.Items[13].Visible = false;//Tag as Internal

                    // ... Internal Project
                    tkrmTop.Items[14].Visible = false;//Active
                    tkrmTop.Items[15].Visible = false;//Complete
                    tkrmTop.Items[16].Visible = false;//Cancel
                    tkrmTop.Items[17].Visible = false;//Promote to proposal
                    tkrmTop.Items[18].Visible = false;//Promote to Project

                    // ... Ballpark Project
                    tkrmTop.Items[19].Visible = false;//Active
                    tkrmTop.Items[20].Visible = false;//Cancel
                    tkrmTop.Items[21].Visible = false;//Promote to proposal
                    tkrmTop.Items[22].Visible = false;//Promote to Project

                    // ...Cancel
                    tkrmTop.Items[23].Visible = true;
                    break;

                case "project_cancel":
                    // ...Proposal
                    tkrmTop.Items[0].Visible = false; //Award
                    tkrmTop.Items[1].Visible = false;//Lost Bid
                    tkrmTop.Items[2].Visible = false;//Cancel
                    tkrmTop.Items[3].Visible = false;//Bidding
                    tkrmTop.Items[4].Visible = false;//Unpromote
                    tkrmTop.Items[5].Visible = false;//Promote

                    // ...Project
                    tkrmTop.Items[6].Visible = false;//Waiting
                    tkrmTop.Items[7].Visible = false;//Active
                    tkrmTop.Items[8].Visible = false;//Inactive
                    tkrmTop.Items[9].Visible = false;//Complete
                    tkrmTop.Items[10].Visible = true;//Cancel
                    tkrmTop.Items[11].Visible = false;//Unpromote to ballpark
                    tkrmTop.Items[12].Visible = false;//Unpromote to proposal
                    tkrmTop.Items[13].Visible = false;//Tag as Internal

                    // ... Internal Project
                    tkrmTop.Items[14].Visible = false;//Active
                    tkrmTop.Items[15].Visible = false;//Complete
                    tkrmTop.Items[16].Visible = false;//Cancel
                    tkrmTop.Items[17].Visible = false;//Promote to proposal
                    tkrmTop.Items[18].Visible = false;//Promote to Project

                    // ... Ballpark Project
                    tkrmTop.Items[19].Visible = false;//Active
                    tkrmTop.Items[20].Visible = false;//Cancel
                    tkrmTop.Items[21].Visible = false;//Promote to proposal
                    tkrmTop.Items[22].Visible = false;//Promote to Project

                    // ...Cancel
                    tkrmTop.Items[23].Visible = true;
                    break;

                case "project_unpromote_to_ballpark":
                    // ...Proposal
                    tkrmTop.Items[0].Visible = false; //Award
                    tkrmTop.Items[1].Visible = false;//Lost Bid
                    tkrmTop.Items[2].Visible = false;//Cancel
                    tkrmTop.Items[3].Visible = false;//Bidding
                    tkrmTop.Items[4].Visible = false;//Unpromote
                    tkrmTop.Items[5].Visible = false;//Promote

                    // ...Project
                    tkrmTop.Items[6].Visible = false;//Waiting
                    tkrmTop.Items[7].Visible = false;//Active
                    tkrmTop.Items[8].Visible = false;//Inactive
                    tkrmTop.Items[9].Visible = false;//Complete
                    tkrmTop.Items[10].Visible = false;//Cancel
                    tkrmTop.Items[11].Visible = true;//Unpromote to ballpark
                    tkrmTop.Items[12].Visible = false;//Unpromote to proposal
                    tkrmTop.Items[13].Visible = false;//Tag as Internal

                    // ... Internal Project
                    tkrmTop.Items[14].Visible = false;//Active
                    tkrmTop.Items[15].Visible = false;//Complete
                    tkrmTop.Items[16].Visible = false;//Cancel
                    tkrmTop.Items[17].Visible = false;//Promote to proposal
                    tkrmTop.Items[18].Visible = false;//Promote to Project

                    // ... Ballpark Project
                    tkrmTop.Items[19].Visible = false;//Active
                    tkrmTop.Items[20].Visible = false;//Cancel
                    tkrmTop.Items[21].Visible = false;//Promote to proposal
                    tkrmTop.Items[22].Visible = false;//Promote to Project

                    // ...Cancel
                    tkrmTop.Items[23].Visible = true;
                    break;

                case "project_unpromote_to_proposal":
                    // ...Proposal
                    tkrmTop.Items[0].Visible = false; //Award
                    tkrmTop.Items[1].Visible = false;//Lost Bid
                    tkrmTop.Items[2].Visible = false;//Cancel
                    tkrmTop.Items[3].Visible = false;//Bidding
                    tkrmTop.Items[4].Visible = false;//Unpromote
                    tkrmTop.Items[5].Visible = false;//Promote

                    // ...Project
                    tkrmTop.Items[6].Visible = false;//Waiting
                    tkrmTop.Items[7].Visible = false;//Active
                    tkrmTop.Items[8].Visible = false;//Inactive
                    tkrmTop.Items[9].Visible = false;//Complete
                    tkrmTop.Items[10].Visible = false;//Cancel
                    tkrmTop.Items[11].Visible = false;//Unpromote to ballpark
                    tkrmTop.Items[12].Visible = true;//Unpromote to proposal
                    tkrmTop.Items[13].Visible = false;//Tag as Internal

                    // ... Internal Project
                    tkrmTop.Items[14].Visible = false;//Active
                    tkrmTop.Items[15].Visible = false;//Complete
                    tkrmTop.Items[16].Visible = false;//Cancel
                    tkrmTop.Items[17].Visible = false;//Promote to proposal
                    tkrmTop.Items[18].Visible = false;//Promote to Project

                    // ... Ballpark Project
                    tkrmTop.Items[19].Visible = false;//Active
                    tkrmTop.Items[20].Visible = false;//Cancel
                    tkrmTop.Items[21].Visible = false;//Promote to proposal
                    tkrmTop.Items[22].Visible = false;//Promote to Project

                    // ...Cancel
                    tkrmTop.Items[23].Visible = true;
                    break;

                case "project_tagAsInternal":
                    // ...Proposal
                    tkrmTop.Items[0].Visible = false; //Award
                    tkrmTop.Items[1].Visible = false;//Lost Bid
                    tkrmTop.Items[2].Visible = false;//Cancel
                    tkrmTop.Items[3].Visible = false;//Bidding
                    tkrmTop.Items[4].Visible = false;//Unpromote
                    tkrmTop.Items[5].Visible = false;//Promote

                    // ...Project
                    tkrmTop.Items[6].Visible = false;//Waiting
                    tkrmTop.Items[7].Visible = false;//Active
                    tkrmTop.Items[8].Visible = false;//Inactive
                    tkrmTop.Items[9].Visible = false;//Complete
                    tkrmTop.Items[10].Visible = false;//Cancel
                    tkrmTop.Items[11].Visible = false;//Unpromote to ballpark
                    tkrmTop.Items[12].Visible = false;//Unpromote to proposal
                    tkrmTop.Items[13].Visible = true;//Tag as Internal

                    // ... Internal Project
                    tkrmTop.Items[14].Visible = false;//Active
                    tkrmTop.Items[15].Visible = false;//Complete
                    tkrmTop.Items[16].Visible = false;//Cancel
                    tkrmTop.Items[17].Visible = false;//Promote to proposal
                    tkrmTop.Items[18].Visible = false;//Promote to Project

                    // ... Ballpark Project
                    tkrmTop.Items[19].Visible = false;//Active
                    tkrmTop.Items[20].Visible = false;//Cancel
                    tkrmTop.Items[21].Visible = false;//Promote to proposal
                    tkrmTop.Items[22].Visible = false;//Promote to Project

                    // ...Cancel
                    tkrmTop.Items[23].Visible = true;
                    break;
                    
                //Internal Project
                case "internalProject_activate":
                    // ...Proposal
                    tkrmTop.Items[0].Visible = false; //Award
                    tkrmTop.Items[1].Visible = false;//Lost Bid
                    tkrmTop.Items[2].Visible = false;//Cancel
                    tkrmTop.Items[3].Visible = false;//Bidding
                    tkrmTop.Items[4].Visible = false;//Unpromote
                    tkrmTop.Items[5].Visible = false;//Promote

                    // ...Project
                    tkrmTop.Items[6].Visible = false;//Waiting
                    tkrmTop.Items[7].Visible = false;//Active
                    tkrmTop.Items[8].Visible = false;//Inactive
                    tkrmTop.Items[9].Visible = false;//Complete
                    tkrmTop.Items[10].Visible = false;//Cancel
                    tkrmTop.Items[11].Visible = false;//Unpromote to ballpark
                    tkrmTop.Items[12].Visible = false;//Unpromote to proposal
                    tkrmTop.Items[13].Visible = false;//Tag as Internal

                    // ... Internal Project
                    tkrmTop.Items[14].Visible = true;//Active
                    tkrmTop.Items[15].Visible = false;//Complete
                    tkrmTop.Items[16].Visible = false;//Cancel
                    tkrmTop.Items[17].Visible = false;//Promote to proposal
                    tkrmTop.Items[18].Visible = false;//Promote to Project

                    // ... Ballpark Project
                    tkrmTop.Items[19].Visible = false;//Active
                    tkrmTop.Items[20].Visible = false;//Cancel
                    tkrmTop.Items[21].Visible = false;//Promote to proposal
                    tkrmTop.Items[22].Visible = false;//Promote to Project

                    // ...Cancel
                    tkrmTop.Items[23].Visible = true;
                    break;

                case "internalProject_complete":
                    // ...Proposal
                    tkrmTop.Items[0].Visible = false; //Award
                    tkrmTop.Items[1].Visible = false;//Lost Bid
                    tkrmTop.Items[2].Visible = false;//Cancel
                    tkrmTop.Items[3].Visible = false;//Bidding
                    tkrmTop.Items[4].Visible = false;//Unpromote
                    tkrmTop.Items[5].Visible = false;//Promote

                    // ...Project
                    tkrmTop.Items[6].Visible = false;//Waiting
                    tkrmTop.Items[7].Visible = false;//Active
                    tkrmTop.Items[8].Visible = false;//Inactive
                    tkrmTop.Items[9].Visible = false;//Complete
                    tkrmTop.Items[10].Visible = false;//Cancel
                    tkrmTop.Items[11].Visible = false;//Unpromote to ballpark
                    tkrmTop.Items[12].Visible = false;//Unpromote to proposal
                    tkrmTop.Items[13].Visible = false;//Tag as Internal

                    // ... Internal Project
                    tkrmTop.Items[14].Visible = false;//Active
                    tkrmTop.Items[15].Visible = true;//Complete
                    tkrmTop.Items[16].Visible = false;//Cancel
                    tkrmTop.Items[17].Visible = false;//Promote to proposal
                    tkrmTop.Items[18].Visible = false;//Promote to Project

                    // ... Ballpark Project
                    tkrmTop.Items[19].Visible = false;//Active
                    tkrmTop.Items[20].Visible = false;//Cancel
                    tkrmTop.Items[21].Visible = false;//Promote to proposal
                    tkrmTop.Items[22].Visible = false;//Promote to Project

                    // ...Cancel
                    tkrmTop.Items[23].Visible = true;
                    break;

                case "internalProject_cancel":
                    // ...Proposal
                    tkrmTop.Items[0].Visible = false; //Award
                    tkrmTop.Items[1].Visible = false;//Lost Bid
                    tkrmTop.Items[2].Visible = false;//Cancel
                    tkrmTop.Items[3].Visible = false;//Bidding
                    tkrmTop.Items[4].Visible = false;//Unpromote
                    tkrmTop.Items[5].Visible = false;//Promote

                    // ...Project
                    tkrmTop.Items[6].Visible = false;//Waiting
                    tkrmTop.Items[7].Visible = false;//Active
                    tkrmTop.Items[8].Visible = false;//Inactive
                    tkrmTop.Items[9].Visible = false;//Complete
                    tkrmTop.Items[10].Visible = false;//Cancel
                    tkrmTop.Items[11].Visible = false;//Unpromote to ballpark
                    tkrmTop.Items[12].Visible = false;//Unpromote to proposal
                    tkrmTop.Items[13].Visible = false;//Tag as Internal

                    // ... Internal Project
                    tkrmTop.Items[14].Visible = false;//Active
                    tkrmTop.Items[15].Visible = false;//Complete
                    tkrmTop.Items[16].Visible = true;//Cancel
                    tkrmTop.Items[17].Visible = false;//Promote to proposal
                    tkrmTop.Items[18].Visible = false;//Promote to Project

                    // ... Ballpark Project
                    tkrmTop.Items[19].Visible = false;//Active
                    tkrmTop.Items[20].Visible = false;//Cancel
                    tkrmTop.Items[21].Visible = false;//Promote to proposal
                    tkrmTop.Items[22].Visible = false;//Promote to Project

                    // ...Cancel
                    tkrmTop.Items[23].Visible = true;
                    break;

                case "internalProject_promote_to_proposal":
                    // ...Proposal
                    tkrmTop.Items[0].Visible = false; //Award
                    tkrmTop.Items[1].Visible = false;//Lost Bid
                    tkrmTop.Items[2].Visible = false;//Cancel
                    tkrmTop.Items[3].Visible = false;//Bidding
                    tkrmTop.Items[4].Visible = false;//Unpromote
                    tkrmTop.Items[5].Visible = false;//Promote

                    // ...Project
                    tkrmTop.Items[6].Visible = false;//Waiting
                    tkrmTop.Items[7].Visible = false;//Active
                    tkrmTop.Items[8].Visible = false;//Inactive
                    tkrmTop.Items[9].Visible = false;//Complete
                    tkrmTop.Items[10].Visible = false;//Cancel
                    tkrmTop.Items[11].Visible = false;//Unpromote to ballpark
                    tkrmTop.Items[12].Visible = false;//Unpromote to proposal
                    tkrmTop.Items[13].Visible = false;//Tag as Internal

                    // ... Internal Project
                    tkrmTop.Items[14].Visible = false;//Active
                    tkrmTop.Items[15].Visible = false;//Complete
                    tkrmTop.Items[16].Visible = false;//Cancel
                    tkrmTop.Items[17].Visible = true;//Promote to proposal
                    tkrmTop.Items[18].Visible = false;//Promote to Project

                    // ... Ballpark Project
                    tkrmTop.Items[19].Visible = false;//Active
                    tkrmTop.Items[20].Visible = false;//Cancel
                    tkrmTop.Items[21].Visible = false;//Promote to proposal
                    tkrmTop.Items[22].Visible = false;//Promote to Project

                    // ...Cancel
                    tkrmTop.Items[23].Visible = true;
                    break;

                case "internalProject_promote_to_project":
                    // ...Proposal
                    tkrmTop.Items[0].Visible = false; //Award
                    tkrmTop.Items[1].Visible = false;//Lost Bid
                    tkrmTop.Items[2].Visible = false;//Cancel
                    tkrmTop.Items[3].Visible = false;//Bidding
                    tkrmTop.Items[4].Visible = false;//Unpromote
                    tkrmTop.Items[5].Visible = false;//Promote

                    // ...Project
                    tkrmTop.Items[6].Visible = false;//Waiting
                    tkrmTop.Items[7].Visible = false;//Active
                    tkrmTop.Items[8].Visible = false;//Inactive
                    tkrmTop.Items[9].Visible = false;//Complete
                    tkrmTop.Items[10].Visible = false;//Cancel
                    tkrmTop.Items[11].Visible = false;//Unpromote to ballpark
                    tkrmTop.Items[12].Visible = false;//Unpromote to proposal
                    tkrmTop.Items[13].Visible = false;//Tag as Internal

                    // ... Internal Project
                    tkrmTop.Items[14].Visible = false;//Active
                    tkrmTop.Items[15].Visible = false;//Complete
                    tkrmTop.Items[16].Visible = false;//Cancel
                    tkrmTop.Items[17].Visible = false;//Promote to proposal
                    tkrmTop.Items[18].Visible = true;//Promote to Project

                    // ... Ballpark Project
                    tkrmTop.Items[19].Visible = false;//Active
                    tkrmTop.Items[20].Visible = false;//Cancel
                    tkrmTop.Items[21].Visible = false;//Promote to proposal
                    tkrmTop.Items[22].Visible = false;//Promote to Project

                    // ...Cancel
                    tkrmTop.Items[23].Visible = true;
                    break;

                case "ballparkProject_activate":
                    // ...Proposal
                    tkrmTop.Items[0].Visible = false; //Award
                    tkrmTop.Items[1].Visible = false;//Lost Bid
                    tkrmTop.Items[2].Visible = false;//Cancel
                    tkrmTop.Items[3].Visible = false;//Bidding
                    tkrmTop.Items[4].Visible = false;//Unpromote
                    tkrmTop.Items[5].Visible = false;//Promote

                    // ...Project
                    tkrmTop.Items[6].Visible = false;//Waiting
                    tkrmTop.Items[7].Visible = false;//Active
                    tkrmTop.Items[8].Visible = false;//Inactive
                    tkrmTop.Items[9].Visible = false;//Complete
                    tkrmTop.Items[10].Visible = false;//Cancel
                    tkrmTop.Items[11].Visible = false;//Unpromote to ballpark
                    tkrmTop.Items[12].Visible = false;//Unpromote to proposal
                    tkrmTop.Items[13].Visible = false;//Tag as Internal

                    // ... Internal Project
                    tkrmTop.Items[14].Visible = false;//Active
                    tkrmTop.Items[15].Visible = false;//Complete
                    tkrmTop.Items[16].Visible = false;//Cancel
                    tkrmTop.Items[17].Visible = false;//Promote to proposal
                    tkrmTop.Items[18].Visible = false;//Promote to Project

                    // ... Ballpark Project
                    tkrmTop.Items[19].Visible = true;//Active
                    tkrmTop.Items[20].Visible = false;//Cancel
                    tkrmTop.Items[21].Visible = false;//Promote to proposal
                    tkrmTop.Items[22].Visible = false;//Promote to Project

                    // ...Cancel
                    tkrmTop.Items[23].Visible = true;
                    break;

                case "ballparkProject_cancel":
                    // ...Proposal
                    tkrmTop.Items[0].Visible = false; //Award
                    tkrmTop.Items[1].Visible = false;//Lost Bid
                    tkrmTop.Items[2].Visible = false;//Cancel
                    tkrmTop.Items[3].Visible = false;//Bidding
                    tkrmTop.Items[4].Visible = false;//Unpromote
                    tkrmTop.Items[5].Visible = false;//Promote

                    // ...Project
                    tkrmTop.Items[6].Visible = false;//Waiting
                    tkrmTop.Items[7].Visible = false;//Active
                    tkrmTop.Items[8].Visible = false;//Inactive
                    tkrmTop.Items[9].Visible = false;//Complete
                    tkrmTop.Items[10].Visible = false;//Cancel
                    tkrmTop.Items[11].Visible = false;//Unpromote to ballpark
                    tkrmTop.Items[12].Visible = false;//Unpromote to proposal
                    tkrmTop.Items[13].Visible = false;//Tag as Internal

                    // ... Internal Project
                    tkrmTop.Items[14].Visible = false;//Active
                    tkrmTop.Items[15].Visible = false;//Complete
                    tkrmTop.Items[16].Visible = false;//Cancel
                    tkrmTop.Items[17].Visible = false;//Promote to proposal
                    tkrmTop.Items[18].Visible = false;//Promote to Project

                    // ... Ballpark Project
                    tkrmTop.Items[19].Visible = false;//Active
                    tkrmTop.Items[20].Visible = true;//Cancel
                    tkrmTop.Items[21].Visible = false;//Promote to proposal
                    tkrmTop.Items[22].Visible = false;//Promote to Project

                    // ...Cancel
                    tkrmTop.Items[23].Visible = true;
                    break;

                case "ballparkProject_promote_to_proposal":
                    // ...Proposal
                    tkrmTop.Items[0].Visible = false; //Award
                    tkrmTop.Items[1].Visible = false;//Lost Bid
                    tkrmTop.Items[2].Visible = false;//Cancel
                    tkrmTop.Items[3].Visible = false;//Bidding
                    tkrmTop.Items[4].Visible = false;//Unpromote
                    tkrmTop.Items[5].Visible = false;//Promote

                    // ...Project
                    tkrmTop.Items[6].Visible = false;//Waiting
                    tkrmTop.Items[7].Visible = false;//Active
                    tkrmTop.Items[8].Visible = false;//Inactive
                    tkrmTop.Items[9].Visible = false;//Complete
                    tkrmTop.Items[10].Visible = false;//Cancel
                    tkrmTop.Items[11].Visible = false;//Unpromote to ballpark
                    tkrmTop.Items[12].Visible = false;//Unpromote to proposal
                    tkrmTop.Items[13].Visible = false;//Tag as Internal

                    // ... Internal Project
                    tkrmTop.Items[14].Visible = false;//Active
                    tkrmTop.Items[15].Visible = false;//Complete
                    tkrmTop.Items[16].Visible = false;//Cancel
                    tkrmTop.Items[17].Visible = false;//Promote to proposal
                    tkrmTop.Items[18].Visible = false;//Promote to Project

                    // ... Ballpark Project
                    tkrmTop.Items[19].Visible = false;//Active
                    tkrmTop.Items[20].Visible = false;//Cancel
                    tkrmTop.Items[21].Visible = true;//Promote to proposal
                    tkrmTop.Items[22].Visible = false;//Promote to Project

                    // ...Cancel
                    tkrmTop.Items[23].Visible = true;
                    break;

                case "ballparkProject_promote_to_project":
                    // ...Proposal
                    tkrmTop.Items[0].Visible = false; //Award
                    tkrmTop.Items[1].Visible = false;//Lost Bid
                    tkrmTop.Items[2].Visible = false;//Cancel
                    tkrmTop.Items[3].Visible = false;//Bidding
                    tkrmTop.Items[4].Visible = false;//Unpromote
                    tkrmTop.Items[5].Visible = false;//Promote

                    // ...Project
                    tkrmTop.Items[6].Visible = false;//Waiting
                    tkrmTop.Items[7].Visible = false;//Active
                    tkrmTop.Items[8].Visible = false;//Inactive
                    tkrmTop.Items[9].Visible = false;//Complete
                    tkrmTop.Items[10].Visible = false;//Cancel
                    tkrmTop.Items[11].Visible = false;//Unpromote to ballpark
                    tkrmTop.Items[12].Visible = false;//Unpromote to proposal
                    tkrmTop.Items[13].Visible = false;//Tag as Internal

                    // ... Internal Project
                    tkrmTop.Items[14].Visible = false;//Active
                    tkrmTop.Items[15].Visible = false;//Complete
                    tkrmTop.Items[16].Visible = false;//Cancel
                    tkrmTop.Items[17].Visible = false;//Promote to proposal
                    tkrmTop.Items[18].Visible = false;//Promote to Project

                    // ... Ballpark Project
                    tkrmTop.Items[19].Visible = false;//Active
                    tkrmTop.Items[20].Visible = false;//Cancel
                    tkrmTop.Items[21].Visible = false;//Promote to proposal
                    tkrmTop.Items[22].Visible = true;//Promote to Project

                    // ...Cancel
                    tkrmTop.Items[23].Visible = true;
                    break;
            }

            // Set instruction
            switch ((string)Request.QueryString["state"])
            {
                //Proposal
                case "proposal_award":
                    lblState.Text = "Are you sure you want to set this proposal as awarded?";
                    upPnlSendMail.Visible = false;
                    break;

                case "proposal_lost_bid":
                    lblState.Text = "Are you sure you want to set this proposal as lost bid?";
                    upPnlSendMail.Visible = false;
                    break;

                case "proposal_cancel":
                    lblState.Text = "Are you sure you want to Cancel this proposal?";
                    upPnlSendMail.Visible = false;
                    break;

                case "proposal_bidding":
                    lblState.Text = "Are you sure you want to set this proposal as bidding?";
                    upPnlSendMail.Visible = false;
                    break;

                case "proposal_unpromote_to_ballpark":
                    lblState.Text = "Are you sure you want to unpromote this proposal to ballpark?";
                    upPnlSendMail.Visible = false;
                    break;

                case "proposal_promote_to_project":
                    lblState.Text = "Are you sure you want to promote this proposal to project?";
                    upPnlSendMail.Visible = true;
                    SendMailTeamMember();
                    break;

                //Project
                case "project_waiting":
                    lblState.Text = "Are you sure you want to set this project as waiting?";
                    upPnlSendMail.Visible = false;
                    break;

                case "project_activate":
                    lblState.Text = "Are you sure you want to activate this project?";
                    upPnlSendMail.Visible = false;
                    //SendMailTeamMember();
                    break;

                case "project_inactivate":
                    lblState.Text = "Are you sure you want to inactivate this project?";
                    upPnlSendMail.Visible = false;
                    break;

                case "project_complete":
                    lblState.Text = "Are you sure you want to complete this project?";
                    upPnlSendMail.Visible = false;
                    break;

                case "project_cancel":
                    lblState.Text = "Are you sure you want to cancel this project?";
                    upPnlSendMail.Visible = false;
                    break;

                case "project_unpromote_to_ballpark":
                    lblState.Text = "Are you sure you want to unpromote this project to ballpark?";
                    upPnlSendMail.Visible = false;
                    break;

                case "project_unpromote_to_proposal":
                    lblState.Text = "Are you sure you want to unpromote this project to proposal?";
                    upPnlSendMail.Visible = false;
                    break;

                case "project_tagAsInternal":
                    lblState.Text = "Are you sure you want to tag this project as internal?";
                    upPnlSendMail.Visible = false;
                    break;

                //Internal Project
                case "internalProject_activate":
                    lblState.Text = "Are you sure you want to activate this internal project?";
                    upPnlSendMail.Visible = false;
                    break;

                case "internalProject_complete":
                    lblState.Text = "Are you sure you want to complete this internal project?";
                    upPnlSendMail.Visible = false;
                    break;

                case "internalProject_cancel":
                    lblState.Text = "Are you sure you want to cancel this internal project?";
                    upPnlSendMail.Visible = false;
                    break;

                case "internalProject_promote_to_proposal":
                    lblState.Text = "Are you sure you want to promote this internal project to proposal?";
                    upPnlSendMail.Visible = false;
                    break;

                case "internalProject_promote_to_project":
                    lblState.Text = "Are you sure you want to promote this internal project to project?";
                    upPnlSendMail.Visible = false;
                    break;

                //Ballpark
                case "ballparkProject_activate":
                    lblState.Text = "Are you sure you want to activate this ballpark?";
                    upPnlSendMail.Visible = false;
                    break;

                case "ballparkProject_cancel":
                    lblState.Text = "Are you sure you want to cancel this ballpark?";
                    upPnlSendMail.Visible = false;
                    break;

                case "ballparkProject_promote_to_proposal":
                    lblState.Text = "Are you sure you want to promote this ballpark to proposal?";
                    upPnlSendMail.Visible = false;
                    break;

                case "ballparkProject_promote_to_project":
                    lblState.Text = "Are you sure you want to promote this ballpark to project?";
                    upPnlSendMail.Visible = false;
                    break;
            }
        }





        
        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATION EVENTS
        //

        protected void tkrmTop_ItemClick(object sender, RadMenuEventArgs e)
        {
            string url = null;

            if (e.Item.Value == "mCancel")
            {
                url = string.Format("./project_summary.aspx?source_page=project_state.aspx&project_id=" + hdfProjectId.Value + "&active_tab=0" + GetNavigatorState() + "&update=" + (string)ViewState["update"]);
                Response.Redirect(url);
            }
            else
            {
                Page.Validate();

                if (Page.IsValid)
                {
                    UpdateState();
                    UpdateDatabase();

                    url = string.Format("./project_summary.aspx?source_page=project_state.aspx&project_id=" + hdfProjectId.Value + "&active_tab=0" + GetNavigatorState() + "&update=yes");

                    Response.Redirect(url);
                }
            }
        }



        protected void lkbtnState_Click(object sender, EventArgs e)
        {
            Page.Validate();

            if (Page.IsValid)
            {
                UpdateState();
                UpdateDatabase();

                string url = string.Format("./project_summary.aspx?source_page=project_state.aspx&project_id=" + hdfProjectId.Value + "&active_tab=0" + GetNavigatorState() + "&update=yes");

                Response.Redirect(url);
            }
        }



        protected void lkbtnCancel_Click(object sender, EventArgs e)
        {
            string url = string.Format("./project_summary.aspx?source_page=project_state.aspx&project_id=" + hdfProjectId.Value + "&active_tab=0" + GetNavigatorState() + "&update=" + (string)ViewState["update"]);
            Response.Redirect(url);
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
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./project_state.js");
        }



        private void StoreNavigatorState()
        {
            ViewState["navigatorState"] = "&search_projectnumber=" + Request.QueryString["search_projectnumber"] + "&search_projectname=" + Request.QueryString["search_projectname"] + "&search_client=" + Request.QueryString["search_client"] + "&search_type=" + Request.QueryString["search_type"] + "&search_state=" + Request.QueryString["search_state"];
        }



        private string GetNavigatorState()
        {
            return (string)ViewState["navigatorState"];
        }



        private void UpdateState()
        {
            ProjectGateway projectGateway = new ProjectGateway(projectTDS);
            int projectId = int.Parse(hdfProjectId.Value);
            projectGateway.LoadByProjectId(projectId);

            Int64 countryId = projectGateway.GetCountryID(projectId);
            int officeId = projectGateway.GetOfficeID(projectId);
            Int64? provinceId = projectGateway.GetProvinceID(projectId);
            Int64? cityId = projectGateway.GetCityID(projectId);
            Int64? countyId = projectGateway.GetCountyID(projectId);
            int? projectLeadId = projectGateway.GetProjectLeadID(projectId);
            int salesmanId = projectGateway.GetSalesmanID(projectId);
            string projectType = projectGateway.GetProjectType(projectId);
            string projectState = null;

            switch ((string)Request.QueryString["state"])
            {
                //Proposal
                case "proposal_award":
                    projectState = "Awarded";
                    break;

                case "proposal_lost_bid":
                    projectState = "Lost Bid";
                    break;

                case "proposal_cancel":
                    projectState = "Canceled";
                    break;

                case "proposal_bidding":
                    projectState = "Bidding";
                    break;

                case "proposal_unpromote_to_ballpark":
                    projectState = "Active";
                    projectType = "Ballpark";
                    break;

                case "proposal_promote_to_project":
                    projectState = "Active";
                    projectType = "Project";
                    break;

                //Project
                case "project_waiting":
                    projectState = "Waiting";
                    break;

                case "project_activate":
                    projectState = "Active";
                    break;

                case "project_inactivate":
                    projectState = "Inactive";
                    break;

                case "project_complete":
                    projectState = "Complete";
                    break;

                case "project_cancel":
                    projectState = "Canceled";
                    break;

                case "project_unpromote_to_ballpark":
                    projectState = "Active";
                    projectType = "Ballpark";
                    break;

                case "project_unpromote_to_proposal":
                    projectState = "Awarded";
                    projectType = "Proposal";
                    break;

                case "project_tagAsInternal":
                    projectState = "Active";
                    projectType = "Internal";
                    break;

                //Internal Project
                case "internalProject_activate":
                    projectState = "Active";
                    break;

                case "internalProject_complete":
                    projectState = "Complete";
                    break;

                case "internalProject_cancel":
                    projectState = "Canceled";
                    break;

                case "internalProject_promote_to_proposal":
                    projectState = "Awarded";
                    projectType = "Proposal";
                    break;

                case "internalProject_promote_to_project":
                    projectState = "Active";
                    projectType = "Project";
                    break;

                //Ballpark
                case "ballparkProject_activate":
                    projectState = "Active";
                    break;

                case "ballparkProject_cancel":
                    projectState = "Canceled";
                    break;

                case "ballparkProject_promote_to_proposal":
                    projectState = "Bidding";
                    projectType = "Proposal";
                    break;

                case "ballparkProject_promote_to_project":
                    projectState = "Active";
                    projectType = "Project";
                    break;
            }

            string name = projectGateway.GetName(projectId);
            string description = projectGateway.GetDescription(projectId);
            DateTime? proposalDate = projectGateway.GetProposalDate(projectId);
            DateTime? startDate = projectGateway.GetStartDate(projectId);
            DateTime? endDate = projectGateway.GetEndDate(projectId);
            int clientId = projectGateway.GetClientID(projectId);
            string clientProjectNumber = projectGateway.GetClientProjectNumber(projectId);
            int? clientPrimaryContactId = projectGateway.GetClientPrimaryContactID(projectId);
            int? clientSecondaryContactId = projectGateway.GetClientSecondaryContactID(projectId);
            bool deleted = projectGateway.GetDeleted(projectId);
            int? libraryCategoriesId = projectGateway.GetLibraryCategoriesId(projectId);
            bool fairWageApplies = projectGateway.GetFairWageApplies(projectId);

            // Update project
            Project project = new Project(projectTDS);
            string projectNumber = project.UpdateProjectNumber(projectId, salesmanId);
            project.Update(projectId, countryId, officeId, projectLeadId, salesmanId, projectNumber, projectType, projectState, name, description, proposalDate, startDate, endDate, clientId, clientProjectNumber, clientPrimaryContactId, clientSecondaryContactId, deleted, libraryCategoriesId, provinceId, cityId, Int32.Parse(hdfCompanyId.Value.Trim()), countyId, fairWageApplies);

            //Insert in history
            ProjectHistory projectHistory = new ProjectHistory(projectTDS);
            int newRefId = projectHistory.GetNewRefId();
            projectHistory.Insert(projectId, newRefId, projectState, DateTime.Now, Convert.ToInt32(Session["loginID"]), Int32.Parse(hdfCompanyId.Value.Trim()));
        }



        private void UpdateDatabase()
        {
            try
            {
                ProjectGateway projectGateway = new ProjectGateway(projectTDS);
                projectGateway.Update();

                ProjectHistoryGateway projectHistoryGateway = new ProjectHistoryGateway(projectTDS);
                projectHistoryGateway.Update();

                projectTDS.AcceptChanges();

                Session["lfsProjectTDS"] = projectTDS;
            }
            catch (Exception ex)
            {
                string url = string.Format("./../../error_page.aspx?error={0}", ex.Message.Replace('\n', ' '));
                Response.Redirect(url);
            }
        }



        public void SendMailTeamMember()
        {
            // Get mail information
            string mailTo = "";
            string nameTo = "";
            string subject = "This proposal is promoted to project.";
            string body = "";

            foreach (ListItem lst in cbxlEmployee.Items)
            {
                int employeeId = int.Parse(lst.Value);
                
                EmployeeGateway employeesGateway = new EmployeeGateway();
                employeesGateway.LoadForMailsByEmployeeId(employeeId);                                             

                if (employeesGateway.Table.Rows.Count > 0)
                {
                    // Assigned TeamMember
                    mailTo = employeesGateway.GetEMail(employeeId);
                    nameTo = employeesGateway.GetFirstName(employeeId) + " " + employeesGateway.GetLastName(employeeId);
                }
            }   

            // Mails body
            body = body + "\nHi " + nameTo + ",\n\nThe following project was promoted to active state. \n";

            // ... for client and project
            body = body + "\n " + lblTitleClientName.Text;
            body = body + "\n Project: " + lblTitleProjectName.Text;
                       
            //Send Mail
            SendMail(mailTo, subject, body);            
        }


        private void SendMail(string mailTo, string subject, string body)
        {
            SendMailLiveSite(mailTo, subject, body);
            //SendMailTestSite(mailTo, subject, body);//TODO EMAIL
        }



        private void SendMailLiveSite(string mailTo, string subject, string body)
        {
            string error;

            // For live site
            string entireBody = "";

            if ((mailTo != "") && (subject != "") && (body != ""))
            {
                entireBody = entireBody + body + "\n\n\n\n\nRegards,\n\n" + "LFS Admin Team.\n\n";
                LiquiForce.LFSLive.WebUI.Common.Tools.Mail.SendMail(mailTo, "sussel@nerdsonsite.com", subject, entireBody, false, out error);
            }
        }



        private void SendMailTestSite(string mailTo, string subject, string body)
        {
            string error;

            // For Test Site
            string entireBody = "--- SENT FROM THE TEST SITE --- \n";

            if ((mailTo != "") && (subject != "") && (body != ""))
            {
                entireBody = entireBody + body + "\n\n\n\n\nRegards,\n\n" + "LFS Admin Team.\n\n";
                LiquiForce.LFSLive.WebUI.Common.Tools.Mail.SendMail("humberto@nerdsonsite.com", "sussel@nerdsonsite.com, humberto@nerdsonsite.com, jacqueline.claure@nerdsonsite.com", subject, entireBody, false, out error);
            }
        }



    }
}