using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.Server;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.Tools;
using LiquiForce.LFSLive.BL.CWP.ManholeRehabilitation;
using LiquiForce.LFSLive.DA.CWP.ManholeRehabilitation;
using LiquiForce.LFSLive.DA.CWP.Works;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.CWP.ManholeRehabilitation
{
    /// <summary>
    /// mr_batch_verification
    /// </summary>
    public partial class mr_batch_verification : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //
        protected MrBatchVerificationTDS mrBatchVerificationTDS;
        protected MrBatchVerificationTDS.BatchValidationDataTable mrBatchVerification;






        // ////////////////////////////////////////////////////////////////////////
        // EVENTS
        //
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Security check
                if (!(Convert.ToBoolean(Session["sgLFS_CWP_MANHOLEREHABILITATION_ADMIN"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in mr_batch_verification.aspx");
                }

                // Tag page
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfUpdate.Value = "no";
                lblBatchIdWarning.Visible = false;
                lblBatchLast.Visible = false;

                Session.Remove("mrBatchVerification");
                Session.Remove("mrBatchVerificationDummy");

                // Load information
                mrBatchVerificationTDS = new MrBatchVerificationTDS();
                if (rbtnUseLastBatch.Checked)
                {
                    int companyId = Int32.Parse(hdfCompanyId.Value);
                    MrBatchVerification mrBatchVerificationForLastRow = new MrBatchVerification(mrBatchVerificationTDS);
                    mrBatchVerificationForLastRow.LoadLastBatch(companyId);

                    if (mrBatchVerificationForLastRow.Table.Rows.Count > 0)
                    {
                        MrBatchVerificationGateway mrBatchVerificationGatewayForLastRow = new MrBatchVerificationGateway(mrBatchVerificationTDS);

                        WorkManholeRehabilitationBatchGateway workManholeRehabilitationBatchGateway = new WorkManholeRehabilitationBatchGateway();
                        hdfBatchId.Value = workManholeRehabilitationBatchGateway.GetLastId(companyId).ToString();

                        int batchId = Int32.Parse(hdfBatchId.Value);
                        DateTime date = mrBatchVerificationGatewayForLastRow.GetDate(batchId);
                        hdfBatchDate.Value = date.Month.ToString() + "/" + date.Day.ToString() + "/" + date.Year.ToString();

                        hdfBatchDescription.Value = mrBatchVerificationGatewayForLastRow.GetDescription(batchId);

                        // Show messages at wizard
                        lblBatchIdWarning.Visible = false;
                        lblBatchLast.Visible = true;
                        lblBatchLast.Text = "Last Batch used: " + hdfBatchDate.Value + "   " + hdfBatchDescription.Value;
                    }
                    else
                    {
                        lblBatchIdWarning.Visible = true;
                        lblBatchLast.Visible = false;
                    }
                } 
                
                // ... Store datasets                
                Session["mrBatchVerificationTDS"] = mrBatchVerificationTDS;
                Session["mrBatchVerification"] = mrBatchVerificationTDS.BatchValidation;

                // StepIn
                wizardBatch.ActiveStepIndex = 0;
                StepBeginIn();
            }
            else
            {
                // Restore datasets
                mrBatchVerificationTDS = (MrBatchVerificationTDS)Session["mrBatchVerificationTDS"];
                mrBatchVerification = (MrBatchVerificationTDS.BatchValidationDataTable)Session["mrBatchVerification"];
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
                switch (wizardBatch.ActiveStep.Name)
                {
                    case "Begin":
                        StepBeginIn();
                        break;

                    case "New Batch":
                        StepNewBatchIn();
                        break;

                    case "Finish":
                        StepSummaryIn();
                        break;

                    default:
                        throw new Exception("The option for " + wizardBatch.ActiveStep.Name + " step in mr_batch_verification.Wizard_ActiveStepChanged function does not exist");
                }
            }
        }



        protected void Wizard_NextButtonClick(object sender, WizardNavigationEventArgs e)
        {
            switch (wizardBatch.ActiveStep.Name)
            {
                case "Begin":
                    e.Cancel = !StepBeginNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "Begin";
                        if (rbtnUseLastBatch.Checked)
                        {
                            wizardBatch.ActiveStepIndex = wizardBatch.WizardSteps.IndexOf(Summary);
                        }
                        else
                        {
                            wizardBatch.ActiveStepIndex = wizardBatch.WizardSteps.IndexOf(StepNewBatch);
                        }
                    }
                    break;

                case "New Batch":
                    e.Cancel = !StepNewBatchNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "New Batch";
                        wizardBatch.ActiveStepIndex = wizardBatch.WizardSteps.IndexOf(Summary);
                    }
                    break;

                default:
                    throw new Exception("The option for " + wizardBatch.ActiveStep.Name + " step in mr_batch_verification.Wizard_NextButtonClick function does not exist");
            }
        }



        protected void Wizard_PreviousButtonClick(object sender, WizardNavigationEventArgs e)
        {
            switch (wizardBatch.ActiveStep.Name)
            {
                case "New Batch":
                    e.Cancel = !StepNewBatchPrevious();
                    break;

                default:
                    throw new Exception("Not exists the option for " + wizardBatch.ActiveStep.Name + " step in mr_batch_verification.Wizard_PreviousButtonClick function");
            }
        }



        protected void Wizard_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        {
            e.Cancel = (!StepSummaryFinish());

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






        #region STEP1 - BEGIN

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP1 - BEGIN
        //             

        // ////////////////////////////////////////////////////////////////////////
        // STEP - BEGIN - AUXILIAR EVENTS
        //

        protected void StartBatch_OnCheckedChanged(object sender, EventArgs e)
        {
            if (rbtnUseLastBatch.Checked)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                MrBatchVerification mrBatchVerificationForLastRow = new MrBatchVerification(mrBatchVerificationTDS);
                mrBatchVerificationForLastRow.LoadLastBatch(companyId);

                if (mrBatchVerificationForLastRow.Table.Rows.Count > 0)
                {
                    MrBatchVerificationGateway mrBatchVerificationGatewayForLastRow = new MrBatchVerificationGateway(mrBatchVerificationForLastRow.Data);
                    WorkManholeRehabilitationBatchGateway workManholeRehabilitationBatchGateway = new WorkManholeRehabilitationBatchGateway();
                    hdfBatchId.Value = workManholeRehabilitationBatchGateway.GetLastId(companyId).ToString();

                    int batchId = Int32.Parse(hdfBatchId.Value);
                    DateTime date = mrBatchVerificationGatewayForLastRow.GetDate(batchId);
                    hdfBatchDate.Value = date.Month.ToString() + "/" + date.Day.ToString() + "/" + date.Year.ToString();

                    hdfBatchDescription.Value = mrBatchVerificationGatewayForLastRow.GetDescription(batchId);

                    // Show messages at wizard
                    lblBatchIdWarning.Visible = false;
                    lblBatchLast.Visible = true;
                    lblBatchLast.Text = "Last Batch used: " + hdfBatchDate.Value + "   " + hdfBatchDescription.Value;
                }
                else
                {
                    lblBatchIdWarning.Visible = true;
                    lblBatchLast.Visible = false;
                }
            }

            if (rbtnUseNewBatch.Checked)
            {
                lblBatchIdWarning.Visible = false;
                lblBatchLast.Visible = false;
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP1 - BEGIN - METHODS
        //

        private void StepBeginIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "What do you want to do?";            
        }



        private bool StepBeginNext()
        {
            Page.Validate("Begin");

            if (Page.IsValid)
            {                
                return true;
            }
            else
            {
                return false;
            }
        }


        #endregion






        #region STEP2 - NEW BATCH

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP2 - NEW BATCH
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP2 - NEW BATCH - EVENTS
        //

        protected void grdNewBatch_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Add":
                    // Catalysts Gridview, if the gridview is edition mode
                    if (grdNewBatch.EditIndex >= 0)
                    {
                        grdNewBatch.UpdateRow(grdNewBatch.EditIndex, true);
                    }

                    // Add New Catalysts
                    GrdBatchAdd();
                    break;
            }
        }



        protected void grdNewBatch_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Catalysts Gridview, if the gridview is edition mode
            if (grdNewBatch.EditIndex >= 0)
            {
                grdNewBatch.UpdateRow(grdNewBatch.EditIndex, true);
            }

            //Delete catalysts
            int batchId = (int)e.Keys["BatchID"];
            int companyId = Int32.Parse(hdfCompanyId.Value);

            // Delete catalysts
            MrBatchVerification model = new MrBatchVerification(mrBatchVerificationTDS);
            model.Delete(batchId, companyId);

            // Store dataset
            Session["mrBatchVerificationTDS"] = mrBatchVerificationTDS;

            grdNewBatch.DataBind();
        }



        protected void grdNewBatch_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.Validate("dataEdit");
            if (Page.IsValid)
            {
                int batchId = (int)e.Keys["BatchID"];
                int companyId = Int32.Parse(hdfCompanyId.Value);

                DateTime date = (DateTime)((RadDatePicker)grdNewBatch.Rows[e.RowIndex].Cells[1].FindControl("tkrdpDateEdit")).SelectedDate;
                string description = ((TextBox)grdNewBatch.Rows[e.RowIndex].Cells[2].FindControl("tbxBatchDescriptionEdit")).Text.Trim();                       
       
                MrBatchVerification model = new MrBatchVerification(mrBatchVerificationTDS);
                model.Update(batchId, description, date);

                // Store dataset
                Session["mrBatchVerificationTDS"] = mrBatchVerificationTDS;
                Session["mrBatchVerification"] = mrBatchVerificationTDS.BatchValidation;
            }
            else
            {
                e.Cancel = true;
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP2 - NEW BATCH - AUXILIAR EVENTS
        //
        
        protected void grdNewBatch_DataBound(object sender, EventArgs e)
        {
            AddBatchNewEmptyFix(grdNewBatch);
        }



        protected void grdNewBatch_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // For dates at normal row
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Normal) || (e.Row.RowState == (DataControlRowState.Normal | DataControlRowState.Alternate))))
            {              
                int batchId = Int32.Parse(((Label)e.Row.FindControl("lblBatchId")).Text);

                if (batchId > 0)
                {
                    MrBatchVerificationGateway mrBatchVerificationGateway = new MrBatchVerificationGateway(mrBatchVerificationTDS);
                    DateTime date = mrBatchVerificationGateway.GetDate(batchId);

                    ((Label)e.Row.FindControl("lblDate")).Text = date.Month.ToString() + "/" + date.Day.ToString() + "/" + date.Year.ToString();
                }
            }

            // For edit dates
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Edit) || (e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
            {
                int batchId = Int32.Parse(((Label)e.Row.FindControl("lblBatchIdEdit")).Text);

                if (batchId > 0)
                {
                    MrBatchVerificationGateway MrBatchVerificationGateway = new MrBatchVerificationGateway(mrBatchVerificationTDS);
                    DateTime date = MrBatchVerificationGateway.GetDate(batchId);

                    ((RadDatePicker)e.Row.FindControl("tkrdpDateEdit")).SelectedDate = date;
                }
            }
        }



        protected void grdNewBatch_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Catalysts Gridview, if the gridview is edition mode
            if (grdNewBatch.EditIndex >= 0)
            {
                grdNewBatch.UpdateRow(grdNewBatch.EditIndex, true);
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP2 - NEW BATCH - METHODS
        //

        private void StepNewBatchIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Please provide information for the new batch";

            // Load
            MrBatchVerification model = new MrBatchVerification(mrBatchVerificationTDS);
            model.LoadAll(Int32.Parse(hdfCompanyId.Value));

            // Store tables
            Session["mrBatchVerification"] = mrBatchVerificationTDS.BatchValidation;
            Session["mrBatchVerificationTDS"] = mrBatchVerificationTDS;
        }



        private bool StepNewBatchNext()
        {
            Page.Validate("New Batch");

            if (Page.IsValid)
            {
                // Gridview, if the gridview is edition mode
                if (grdNewBatch.EditIndex >= 0)
                {
                    grdNewBatch.UpdateRow(grdNewBatch.EditIndex, true);
                    grdNewBatch.DataBind();
                }

                // Add if exists at footer
                if (ValidateBatchFooter())
                {
                    GrdBatchAdd();
                }

                // Store tables
                Session["mrBatchVerification"] = mrBatchVerificationTDS.BatchValidation;
                Session["mrBatchVerificationTDS"] = mrBatchVerificationTDS;
                return true;
            }
            else
            {
                return false;
            }
        }



        private bool StepNewBatchPrevious()
        {
            return true;
        }



        public MrBatchVerificationTDS.BatchValidationDataTable GetNewBatchNew()
        {
            mrBatchVerification = (MrBatchVerificationTDS.BatchValidationDataTable)Session["mrBatchVerificationDummy"];

            if (mrBatchVerification == null)
            {
                mrBatchVerification = ((MrBatchVerificationTDS.BatchValidationDataTable)Session["mrBatchVerification"]);
            }

            return mrBatchVerification;
        }



        public void DummyNewBatchNew(int BatchID)
        {
        }



        private bool ValidateBatchFooter()
        {
            string numberFooter = ((TextBox)grdNewBatch.FooterRow.FindControl("tbxBatchDescriptionFooter")).Text.Trim();

            DateTime? Date = ((RadDatePicker)grdNewBatch.FooterRow.FindControl("tkrdpDateFooter")).SelectedDate ;

            if ((numberFooter != "") || (Date.HasValue))
            {
                return true;
            }

            return false;
        }



        protected void AddBatchNewEmptyFix(GridView grdNewBatch)
        {
            if (grdNewBatch.Rows.Count == 0)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                MrBatchVerificationTDS.BatchValidationDataTable dt = new MrBatchVerificationTDS.BatchValidationDataTable();
                dt.AddBatchValidationRow(-1, "", DateTime.Now, false, companyId, false);
                Session["mrBatchVerificationDummy"] = dt;

                grdNewBatch.DataBind();
            }

            // Normally executes at all postbacks
            if (grdNewBatch.Rows.Count == 1)
            {
                MrBatchVerificationTDS.BatchValidationDataTable dt = (MrBatchVerificationTDS.BatchValidationDataTable)Session["mrBatchVerificationDummy"];
                if (dt != null)
                {
                    grdNewBatch.Rows[0].Visible = false;
                    grdNewBatch.Rows[0].Controls.Clear();
                }
            }
        }



        private void GrdBatchAdd()
        {
            if (ValidateBatchFooter())
            {
                Page.Validate("dataFooter");
                if (Page.IsValid)
                {
                    string description = ((TextBox)grdNewBatch.FooterRow.FindControl("tbxBatchDescriptionFooter")).Text.Trim();
                    DateTime date = (DateTime)((RadDatePicker)grdNewBatch.FooterRow.FindControl("tkrdpDateFooter")).SelectedDate;                        

                    int companyId = Int32.Parse(hdfCompanyId.Value);
                    bool inDatabase = false;
                    bool deleted = false;

                    MrBatchVerification model = new MrBatchVerification(mrBatchVerificationTDS);
                    model.Insert(description, date, deleted, companyId, inDatabase);

                    Session.Remove("mrBatchVerificationDummy");
                    Session["mrBatchVerificationTDS"] = mrBatchVerificationTDS;
                    Session["mrBatchVerification"] = mrBatchVerificationTDS.BatchValidation;

                    grdNewBatch.DataBind();
                    grdNewBatch.PageIndex = grdNewBatch.PageCount - 1;
                }
            }
        }


        #endregion





        #region STEP3 - SUMMARY

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP3 - SUMMARY
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
            string summary = "Selected batch: \n\n";
            if (rbtnUseLastBatch.Checked)
            { 
                DateTime date = DateTime.Parse(hdfBatchDate.Value);
                summary = summary + "Date: " + date.Month.ToString() + "/" + date.Day.ToString() + "/" + date.Year.ToString() +"\n";
           
                summary = summary + "Description: " + hdfBatchDescription.Value + "\n\n";

            }
            else
            {
                if (rbtnUseNewBatch.Checked)
                {
                    MrBatchVerification mrBatchVerification = new MrBatchVerification(mrBatchVerificationTDS);
                    summary = mrBatchVerification.GetSummary();
                }
            }

            tbxSummary.Text = summary;
        }



        private bool StepSummaryPrevious()
        {
            return true;
        }



        private bool StepSummaryFinish()
        {
            if (Page.IsValid)
            {
                Save();
                return true;
            }
            else
            {
                return false;
            }
        }


        #endregion






        // ////////////////////////////////////////////////////////////////////////
        // METHODS
        //

        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set wizardBatch title
            mWizard2 master = (mWizard2)this.Master;
            master.WizardTitle = "Batch Date Verification";
        }



        private void Save()
        {
            // save to database
            DB.Open();
            DB.BeginTransaction();
            try
            {
                MrBatchVerification model = new MrBatchVerification(mrBatchVerificationTDS);
                model.Save(Int32.Parse(hdfCompanyId.Value));

                DB.CommitTransaction();
            }
            catch (Exception ex)
            {
                DB.RollbackTransaction();

                string url = string.Format("./../../error_page.aspx?error={0}", ex.Message.Replace('\n', ' '));
                Response.Redirect(url);
            }
        }
    }
}
