using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.BL.Projects.Projects;
using LiquiForce.LFSLive.BL.Projects.Revenue;
using LiquiForce.LFSLive.DA.Projects.Revenue;
using LiquiForce.LFSLive.Server;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.Projects.Revenue
{
    /// <summary>
    /// revenue_add
    /// </summary>
    public partial class revenue_add : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected RevenueAddTDS revenueAddTDS;
        protected RevenueAddTDS.ProjectRevenueDataTable projectRevenue;







        // ////////////////////////////////////////////////////////////////////////
        // INITIAL EVENTS
        //

        protected void Page_Load(object sender, EventArgs e)
        {
            // Register client scripts
            this.RegisterClientScripts();

            if (!IsPostBack)
            {
                // Security check
                if (!(Convert.ToBoolean(Session["sgLFS_PROJECTS_REVENUE_ADD"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if ((string)Request.QueryString["source_page"] == null) 
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in revenue_add.aspx");
                }

                // Tag Page
                hdfCompanyId.Value = Convert.ToInt32(Session["companyID"]).ToString();
                Session.Remove("projectRevenueDummy");

                // If coming from 
                // ... employee_navigator.aspx
                if (Request.QueryString["source_page"] == "lm")
                {
                    // ... Initialize tables
                    revenueAddTDS = new RevenueAddTDS();

                    // ... Store tables
                    Session["revenueAddTDS"] = revenueAddTDS;
                    Session["projectRevenue"] = revenueAddTDS.ProjectRevenue;
                }                

                // StepSection1In
                wzRevenue.ActiveStepIndex = 0;                
                StepDataIn();
            }
            else
            {
                // Restore tables
                revenueAddTDS = (RevenueAddTDS)Session["revenueAddTDS"];
                projectRevenue = revenueAddTDS.ProjectRevenue;
                Session["projectRevenue"] = revenueAddTDS.ProjectRevenue;
            }
        }






        #region Wizard navigation events

        // ////////////////////////////////////////////////////////////////////////
        // WIZARD NAVIGATION EVENTS
        //

        protected void Wizard_ActiveStepChanged(object sender, EventArgs e)
        {
            if (ViewState["StepFrom"] != null)
            {
                switch (wzRevenue.ActiveStep.Name)
                {                   
                    case "Data":
                        StepDataIn();
                        break;

                    case "Summary":
                        StepSummaryIn();
                        break;

                    default:
                        throw new Exception("The option for " + wzRevenue.ActiveStep.Name + " step in revenue_add.Wizard_ActiveStepChanged function does not exist");
                }
            }
        }



        protected void Wizard_NextButtonClick(object sender, WizardNavigationEventArgs e)
        {
            switch (wzRevenue.ActiveStep.Name)
            {              
                case "Data":
                    e.Cancel = !StepDataNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "General Information";
                    }
                    break; 

                default:
                    throw new Exception("The option for " + wzRevenue.ActiveStep.Name + " step in revenue_add.Wizard_NextButtonClick function does not exist");
            }
        }



        protected void Wizard_PreviousButtonClick(object sender, WizardNavigationEventArgs e)
        {
            switch (wzRevenue.ActiveStep.Name)
            {                              
                case "Summary":
                    e.Cancel = !StepSummaryPrevious();
                    break;

                default:
                    throw new Exception("The option for " + wzRevenue.ActiveStep.Name + " step in revenue_add.Wizard_PreviousButtonClick function does not exist");
            }
            if (!e.Cancel)
            {
                ViewState["StepFrom"] = wzRevenue.ActiveStep.Name;
            }
        }



        protected void Wizard_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        {
            e.Cancel = !StepSummaryFinish();

            if (!e.Cancel)
            {
                Response.Write("<script language='javascript'> { window.close();}</script>");
            }
        }



        protected void Wizard_CancelButtonClick(object sender, EventArgs e)
        {
            Response.Write("<script language='javascript'> { window.close();}</script>");
        }

        #endregion






        #region STEP1 - DATA

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP1 - DATA
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP1 - DATA - EVENTS
        //

        protected void grdRevenue_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Revenue Gridview, if the gridview is edition mode
            if (grdRevenue.EditIndex >= 0)
            {
                grdRevenue.UpdateRow(grdRevenue.EditIndex, true);
            }

            // Delete Revenue
            int projectId = (int)e.Keys["ProjectID"];
            int refId = (int)e.Keys["RefID"];

            // Delete Revenue 
            RevenueAddProjectRevenue revenueAddProjectRevenue = new RevenueAddProjectRevenue(revenueAddTDS);
            revenueAddProjectRevenue.Delete(projectId, refId);

            // Store dataset
            Session["revenueAddTDS"] = revenueAddTDS;
            Session.Remove("projectRevenueDummy");
            projectRevenue = revenueAddTDS.ProjectRevenue;
            Session["projectRevenue"] = revenueAddTDS.ProjectRevenue;
        }



        protected void grdRevenue_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Add":
                    // Revenue Gridview, if the gridview is edition mode
                    if (grdRevenue.EditIndex >= 0)
                    {
                        grdRevenue.UpdateRow(grdRevenue.EditIndex, true);
                    }

                    // Add New Revenue
                    GrdRevenueDetailAdd();
                    break;
            }
        }



        protected void grdRevenue_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {            
            Page.Validate("DataEdit");
            if (Page.IsValid)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                int projectId = Int32.Parse(((Label)grdRevenue.Rows[e.RowIndex].Cells[0].FindControl("lblProjectIdEdit")).Text);

                int refId = Int32.Parse(((Label)grdRevenue.Rows[e.RowIndex].Cells[1].FindControl("lblRefIdEdit")).Text);
                DateTime date = (DateTime)((RadDatePicker)grdRevenue.Rows[e.RowIndex].Cells[4].FindControl("tkrdpDateEdit")).SelectedDate;

                decimal revenue = decimal.Round(decimal.Parse(((TextBox)grdRevenue.Rows[e.RowIndex].Cells[5].FindControl("tbxRevenueEdit")).Text), 2);

                string comment = ((TextBox)grdRevenue.Rows[e.RowIndex].Cells[6].FindControl("tbxCommentEdit")).Text;
                bool deleted = false;

                // Update Data
                RevenueAddProjectRevenue subcontractorAddProjectRevenueCosts = new RevenueAddProjectRevenue(revenueAddTDS);
                subcontractorAddProjectRevenueCosts.Update(projectId, refId, date, revenue, comment, deleted, companyId);

                // Store dataset
                Session["revenueAddTDS"] = revenueAddTDS;
                Session.Remove("projectRevenueDummy");
                projectRevenue = revenueAddTDS.ProjectRevenue;
                Session["projectRevenue"] = revenueAddTDS.ProjectRevenue;
            }
            else
            {
                e.Cancel = true;
            }           
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP1 - DATA - AUXILIAR EVENTS
        //
       
        protected void ddlClientFooter_SelectedIndexChanged(object sender, EventArgs e)
        {            
            DropDownList ddlClientFooter = (DropDownList)sender;
            DropDownList ddlProjectFooter = ((DropDownList)grdRevenue.FooterRow.FindControl("ddlProjectFooter"));

            ProjectList projectList = new ProjectList();
            projectList.LoadProjectsAndAddItem(-1, "(Select a project)", int.Parse(ddlClientFooter.SelectedValue));
            ddlProjectFooter.DataSource = projectList.Table;
            ddlProjectFooter.DataValueField = "ProjectID";
            ddlProjectFooter.DataTextField = "Name";
            ddlProjectFooter.DataBind();               
        }



        //protected void cvDateFooter_ServerValidate(object source, ServerValidateEventArgs args)
        //{
        //    args.IsValid = true;
        //    DateTime dateFooter = (DateTime)((RadDatePicker)grdRevenue.FooterRow.FindControl("tkrdpDateFooter")).SelectedDate;
        //    int projectIdFooter = Int32.Parse(((DropDownList)grdRevenue.FooterRow.FindControl("ddlProjectFooter")).SelectedValue);
        //    int companyId = Int32.Parse(hdfCompanyId.Value);

        //    // Validate if date is already registered in the grid
        //    RevenueAddProjectRevenue modelForReview = new RevenueAddProjectRevenue(revenueAddTDS);
        //    if (modelForReview.NotExistsByProjectIdRefIdDate(projectIdFooter, dateFooter))
        //    {
        //        args.IsValid = true;
        //    }
        //    else
        //    {
        //        args.IsValid = false;
        //    }

        //    // Validate if exists a revenue for this date in the data base
        //    ProjectRevenue projectRevenueValid = new ProjectRevenue();
        //    if (!projectRevenueValid.ValidateIfExistsARenevue(dateFooter, projectIdFooter, companyId))
        //    {
        //        args.IsValid = false;
        //    }
        //}



        //protected void cvDateEdit_ServerValidate(object source, ServerValidateEventArgs args)
        //{
        //    args.IsValid = true;
        //    DateTime dateEdit = (DateTime)((RadDatePicker)grdRevenue.Rows[grdRevenue.EditIndex].Cells[4].FindControl("tkrdpDateEdit")).SelectedDate;
        //    int projectIdEdit = Int32.Parse(((Label)grdRevenue.Rows[grdRevenue.EditIndex].Cells[0].FindControl("lblProjectIdEdit")).Text);            
        //    int companyId = Int32.Parse(hdfCompanyId.Value);

        //    // Validate if date is already registered in the grid
        //    RevenueAddProjectRevenue modelForReview = new RevenueAddProjectRevenue(revenueAddTDS);
        //    if (modelForReview.NotExistsByProjectIdRefIdDate(projectIdEdit, dateEdit))
        //    {
        //        args.IsValid = true;
        //    }
        //    else
        //    {
        //        args.IsValid = false;
        //    }

        //    // Validate if exists a revenue for this date in the data base
        //    ProjectRevenue projectRevenueValid = new ProjectRevenue();
        //    if (!projectRevenueValid.ValidateIfExistsARenevue(dateEdit, projectIdEdit, companyId))
        //    {
        //        args.IsValid = false;
        //    }
        //}



        protected void grdRevenue_DataBound(object sender, EventArgs e)
        {
            AddRevenueNewEmptyFix(grdRevenue);
        }



        protected void grdRevenue_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Normal) || (e.Row.RowState == (DataControlRowState.Normal | DataControlRowState.Alternate))))
            {
                // Get date
                DateTime date = DateTime.Parse(((Label)e.Row.FindControl("lblDate")).Text);

                // Set new format
                ((Label)e.Row.FindControl("lblDate")).Text = date.Month.ToString() + "/" + date.Day.ToString() + "/" + date.Year.ToString();
            }
        }



        protected void grdRevenue_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Revenue Gridview, if the gridview is edition mode
            if (grdRevenue.EditIndex >= 0)
            {
                grdRevenue.UpdateRow(grdRevenue.EditIndex, true);
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP1 - DATA - METHODS
        //

        private void StepDataIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Please provide the information for new revenues";
        }



        private bool StepDataPrevious()
        {
            return true;
        }



        private bool StepDataNext()
        {
            bool isValid = ValidatePage();

            if (isValid)
            {               
                return true;
            }
            else
            {
                return false;
            }
        }



        public RevenueAddTDS.ProjectRevenueDataTable GetRevenueDetail()
        {
            projectRevenue = (RevenueAddTDS.ProjectRevenueDataTable)Session["projectRevenueDummy"];
            if (projectRevenue == null)
            {
                projectRevenue = ((RevenueAddTDS.ProjectRevenueDataTable)Session["projectRevenue"]);
            }

            return projectRevenue;
        }



        public void DummyRevenueDetail(int ProjectID, int RefID, int original_ProjectID, int original_RefID)
        {
        }



        public void DummyRevenueDetail(int original_ProjectID, int original_RefID)
        {
        }



        protected void AddRevenueNewEmptyFix(GridView grdRevenue)
        {
            if (grdRevenue.Rows.Count == 0)
            {
                RevenueAddTDS.ProjectRevenueDataTable dt = new RevenueAddTDS.ProjectRevenueDataTable();
                dt.AddProjectRevenueRow(-1, -1,DateTime.Now, -1, "", false, -1, false, "", "", 1);
                Session["projectRevenueDummy"] = dt;

                grdRevenue.DataBind();
            }

            // normally executes at all postbacks
            if (grdRevenue.Rows.Count == 1)
            {
                RevenueAddTDS.ProjectRevenueDataTable dt = (RevenueAddTDS.ProjectRevenueDataTable)Session["projectRevenueDummy"];
                if (dt != null)
                {
                    grdRevenue.Rows[0].Visible = false;
                    grdRevenue.Rows[0].Controls.Clear();
                }
            }
        }



        private void GrdRevenueDetailAdd()
        {
            if (FooterValidate())
            {
                Page.Validate("DataNew");
                if (Page.IsValid)
                {
                    int companyId = Int32.Parse(hdfCompanyId.Value);
                    DateTime date = (DateTime)((RadDatePicker)grdRevenue.FooterRow.FindControl("tkrdpDateFooter")).SelectedDate;

                    int clientId = Int32.Parse(((DropDownList)grdRevenue.FooterRow.FindControl("ddlClientFooter")).SelectedValue);
                    string client = ((DropDownList)grdRevenue.FooterRow.FindControl("ddlClientFooter")).SelectedItem.Text;

                    int projectId = Int32.Parse(((DropDownList)grdRevenue.FooterRow.FindControl("ddlProjectFooter")).SelectedValue);
                    string project = ((DropDownList)grdRevenue.FooterRow.FindControl("ddlProjectFooter")).SelectedItem.Text;

                    decimal revenue = decimal.Round(decimal.Parse(((TextBox)grdRevenue.FooterRow.FindControl("tbxRevenueFooter")).Text), 2);
                    string comment = ((TextBox)grdRevenue.FooterRow.FindControl("tbxCommentFooter")).Text;
                    bool deleted = false;
                    bool inDatabase = false;                          

                    // Insert Data
                    RevenueAddProjectRevenue revenueAddProjectRevenue = new RevenueAddProjectRevenue(revenueAddTDS);
                    revenueAddProjectRevenue.Insert(projectId, date, revenue, comment, deleted, companyId, inDatabase, client, project, clientId);

                    // Store dataset
                    Session["revenueAddTDS"] = revenueAddTDS;
                    Session.Remove("projectRevenueDummy");
                    projectRevenue = revenueAddTDS.ProjectRevenue;
                    Session["projectRevenue"] = revenueAddTDS.ProjectRevenue;

                    grdRevenue.DataBind();
                    grdRevenue.PageIndex = grdRevenue.PageCount - 1;
                }
            }            
        }



        protected bool FooterValidate()
        {
            int clientId = Int32.Parse(((DropDownList)grdRevenue.FooterRow.FindControl("ddlClientFooter")).SelectedValue);
            int projectId = Int32.Parse(((DropDownList)grdRevenue.FooterRow.FindControl("ddlProjectFooter")).SelectedValue);
            decimal revenue = decimal.Round(decimal.Parse(((TextBox)grdRevenue.FooterRow.FindControl("tbxRevenueFooter")).Text), 2);
            DateTime? date = ((RadDatePicker)grdRevenue.FooterRow.FindControl("tkrdpDateFooter")).SelectedDate;

            if ((clientId != -1) && (projectId != -1) && (date.HasValue))
            {
                return true;
            }

            return false;
        }



        private bool ValidatePage()
        {
            bool valid = true;

            Page.Validate("DataNew");
            if (Page.IsValid)
            {
                Page.Validate("DataEdit");
                if (!Page.IsValid) valid = false;
            }

            return valid;
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





        
        // ////////////////////////////////////////////////////////////////////////
        // FINAL EVENTS 
        //

        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set wizard title
            Label title = (Label)this.Master.FindControl("lblTitle");
            title.Text = "Add Revenue";
        }

        




        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        private void RegisterClientScripts()
        {
            // Register content variables
            string contentVariables = "";

            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./revenue_add.js");
        }



        private void UpdateDatabase()
        {
            DB.Open();
            DB.BeginTransaction();
            try
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                RevenueAddProjectRevenue revenueAddProjectRevenue = new RevenueAddProjectRevenue(revenueAddTDS);
                revenueAddProjectRevenue.Save(companyId);                

                DB.CommitTransaction();

                // Store datasets
                revenueAddTDS.AcceptChanges();
                Session["revenueAddTDS"] = revenueAddTDS;

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
            int companyId = Int32.Parse(hdfCompanyId.Value);
            RevenueAddProjectRevenue revenueAddProjectRevenue = new RevenueAddProjectRevenue(revenueAddTDS);
            return revenueAddProjectRevenue.GetSummary(companyId, "\n");                           
        }



    }
}