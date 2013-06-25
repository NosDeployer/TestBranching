using System;
using LiquiForce.LFSLive.WebUI.export.Temp;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.BL.Resources.Companies;
using LiquiForce.LFSLive.BL.Projects.Projects;

namespace LiquiForce.LFSLive.WebUI
{
    /// <summary>
    /// comments_migration
    /// </summary>
    public partial class comments_migration : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected CommentsMigrationTDS commentsMigrationTDS;
        private int timeOut;






        // ////////////////////////////////////////////////////////////////////////
        // INITIAL EVENTS
        //

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Initialize viewstate variables
                ViewState["StepFrom"] = "Out";
                Session.Remove("commentsMigrationTDS");

                // ... Initialize tables
                commentsMigrationTDS = new CommentsMigrationTDS();

                // ... Store tables
                Session["commentsMigrationTDS"] = commentsMigrationTDS;

                hdfCompanyId.Value = Convert.ToInt32(Session["companyID"]).ToString();

                // ...  for the client                
                int companyId = Int32.Parse(hdfCompanyId.Value);
                CompaniesList companiesList = new CompaniesList();
                companiesList.LoadAndAddItem(-1, "(Select a client)", companyId);
                ddlParentClient.DataSource = companiesList.Table;
                ddlParentClient.DataValueField = "COMPANIES_ID";
                ddlParentClient.DataTextField = "Name";
                ddlParentClient.DataBind();

                ddlChildClient.DataSource = companiesList.Table;
                ddlChildClient.DataValueField = "COMPANIES_ID";
                ddlChildClient.DataTextField = "Name";
                ddlChildClient.DataBind();

                // ... for project
                ProjectList projectList = new ProjectList();
                projectList.LoadProjectsAndAddItem(-1, "(Select a project)", -1);
                ddlParentProject.DataSource = projectList.Table;
                ddlParentProject.DataValueField = "ProjectID";
                ddlParentProject.DataTextField = "Name";
                ddlParentProject.DataBind();

                ddlChildProject.DataSource = projectList.Table;
                ddlChildProject.DataValueField = "ProjectID";
                ddlChildProject.DataTextField = "Name";
                ddlChildProject.DataBind();

                // StepSection1In
                wzCommentsMigration.ActiveStepIndex = 0;
                StepBeginIn();
            }
            else
            {
                // Restore tables
                commentsMigrationTDS = (CommentsMigrationTDS)Session["commentsMigrationTDS"];
            }

            // control for postback
            hdfTag.Value = DateTime.Now.ToLongTimeString();
        }






        #region Wizard navigation events

        // ////////////////////////////////////////////////////////////////////////
        // WIZARD NAVIGATION EVENTS
        //

        protected void Wizard_ActiveStepChanged(object sender, EventArgs e)
        {
            if (ViewState["StepFrom"] != null)
            {
                switch (wzCommentsMigration.ActiveStep.Name)
                {
                    case "Begin":
                        StepBeginIn();
                        break;

                    case "Summary":
                        StepSummaryIn();
                        break;

                    case "Final Step":
                        StepFinalStepIn();
                        wzCommentsMigration.ActiveStepIndex = wzCommentsMigration.WizardSteps.IndexOf(StepFinalStep);
                        break;

                    default:
                        throw new Exception("The option for " + wzCommentsMigration.ActiveStep.Name + " step in comments_migration.Wizard_ActiveStepChanged function does not exist");
                }
            }
        }



        protected void Wizard_NextButtonClick(object sender, WizardNavigationEventArgs e)
        {
            switch (wzCommentsMigration.ActiveStep.Name)
            {
                case "Begin":
                    e.Cancel = !StepBeginNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "Summary";
                    }
                    break;

                default:
                    throw new Exception("The option for " + wzCommentsMigration.ActiveStep.Name + " step in comments_migration.Wizard_NextButtonClick function does not exist");
            }
        }



        protected void Wizard_PreviousButtonClick(object sender, WizardNavigationEventArgs e)
        {
            switch (wzCommentsMigration.ActiveStep.Name)
            {
                case "Summary":
                    e.Cancel = !StepSummaryPrevious();
                    break;

                default:
                    throw new Exception("The option for " + wzCommentsMigration.ActiveStep.Name + " step in comments_migration.Wizard_PreviousButtonClick function does not exist");
            }
            if (!e.Cancel)
            {
                ViewState["StepFrom"] = wzCommentsMigration.ActiveStep.Name;
            }
        }



        protected void Wizard_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        {
            e.Cancel = !StepSummaryFinish();
        }



        protected void Wizard_CancelButtonClick(object sender, EventArgs e)
        {
            Response.Write("<script language='javascript'> { window.close();}</script>");
        }

        #endregion





        #region STEP1 - BEGIN

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP1 - BEGIN
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP1 - BEGIN - EVENTS
        //

        protected void ddlParentClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProjectList projectList = new ProjectList();
            projectList.LoadProjectsAndAddItem(-1, "(Select a project)", int.Parse(ddlParentClient.SelectedValue));
            ddlParentProject.DataSource = projectList.Table;
            ddlParentProject.DataValueField = "ProjectID";
            ddlParentProject.DataTextField = "Name";
            ddlParentProject.DataBind();
        }



        protected void ddlChildClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProjectList projectList = new ProjectList();
            projectList.LoadProjectsAndAddItem(-1, "(Select a project)", int.Parse(ddlChildClient.SelectedValue));
            ddlChildProject.DataSource = projectList.Table;
            ddlChildProject.DataValueField = "ProjectID";
            ddlChildProject.DataTextField = "Name";
            ddlChildProject.DataBind();
        }



        // ////////////////////////////////////////////////////////////////////////
        // STEP1 - BEGIN - METHODS
        //

        private void StepBeginIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Please provide the projects information";
        }



        private bool StepBeginNext()
        {
            Page.Validate("Begin");
            if (Page.IsValid)
            {
                return true;
            }
            return false;
        }



        #endregion






        #region STEP2 - SUMMARY

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP2 - SUMMARY
        //


        // ////////////////////////////////////////////////////////////////////////
        // STEP2 - SUMMARY - METHODS
        //

        private void StepSummaryIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Summary";

            int parentProject = Convert.ToInt32(ddlParentProject.SelectedValue);
            int childProject = Convert.ToInt32(ddlChildProject.SelectedValue);
            int companyId = Convert.ToInt32(hdfCompanyId.Value);

            CommentsMigration commentsMigration = new CommentsMigration(commentsMigrationTDS);
            commentsMigration.LoadByProjectId(parentProject, childProject, companyId);

            // Initialize summary
            tbxSummary.Text = GetSummary();
        }



        private bool StepSummaryPrevious()
        {
            return true;
        }



        protected bool StepSummaryFinish()
        {
            Page.Validate("StepSummary");
            if (Page.IsValid)
            {
                UpdateDatabase();

                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion






        #region STEP3 - FINISH OPTIONS
        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // STEP3 - FINISH OPTIONS
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP3 - FINISH OPTIONS - METHODS
        //

        private void StepFinalStepIn()
        {
            // Set instruction
            mWizard2 master2 = (mWizard2)this.Master;
            master2.WizardInstruction = "What would you like to do?";

            lkbtnClose.Attributes.Add("onclick", "return lkbtnCloseClick();");
        }

        #endregion






        // ////////////////////////////////////////////////////////////////////////
        // FINAL EVENTS 
        //

        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set wizard title
            Label title = (Label)this.Master.FindControl("lblTitle");
            title.Text = "Comments Migration";
        }



        private void UpdateDatabase()
        {
            DB.Open();
            DB.BeginTransaction();
            try
            {
                int parentProject = Convert.ToInt32(ddlParentProject.SelectedValue);
                int childProject = Convert.ToInt32(ddlChildProject.SelectedValue);
                int companyId = Convert.ToInt32(hdfCompanyId.Value);

                CommentsMigration commentsMigration = new CommentsMigration(commentsMigrationTDS);
                commentsMigration.Save(parentProject, childProject, companyId);

                DB.CommitTransaction();

                // Store datasets
                commentsMigrationTDS.AcceptChanges();
                Session["commentsMigrationTDS"] = commentsMigrationTDS;
            }
            catch (Exception ex)
            {
                DB.RollbackTransaction();

                string url = string.Format("./../../error_page.aspx?error={0}", ex.Message.Replace('\n', ' '));
                Response.Redirect(url);
            }
        }



        private string GetSummary()
        {
            string summary = "GENERAL INFORMATION \n";
            summary = summary + "\n Sections: \n";

            CommentsMigration commentsMigration = new CommentsMigration(commentsMigrationTDS);
            summary += commentsMigration.GetSummary();

            return summary;
        }



    }
}