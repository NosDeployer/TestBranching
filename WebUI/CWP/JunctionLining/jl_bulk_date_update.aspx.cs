using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.BL.CWP.JunctionLining;
using LiquiForce.LFSLive.BL.CWP.Works;
using LiquiForce.LFSLive.DA.CWP.JunctionLining;
using LiquiForce.LFSLive.DA.CWP.Works;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.DA.RAF;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.WebUI.CWP.JunctionLining
{
    /// <summary>
    /// jl_bulk_date_update
    /// </summary>
    public partial class jl_bulk_date_update : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected FlatSectionJlTDS flatSectionJlTDS;
        





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
                if (!(Convert.ToBoolean(Session["sgLFS_CWP_JUNCTIONLINING_VIEW"]) && Convert.ToBoolean(Session["sgLFS_CWP_JUNCTIONLINING_EDIT"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["client"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in jl_bulk_date_update.aspx");
                }

                // Tag page
                hdfCurrentClient.Value = (string)Request.QueryString["client"];
                hdfCurrentProject.Value = (string)Request.QueryString["project"];
                hdfUpdate.Value = "no";
                ViewState["StepFrom"] = "Out";
                ViewState["UpdateComments"] = false;

                StepBeginIn();

                // Restore datasets
                flatSectionJlTDS = (FlatSectionJlTDS)Session["flatSectionJlTDS"];
            }
            else
            {
                // Restore datasets
                flatSectionJlTDS = (FlatSectionJlTDS)Session["flatSectionJlTDS"];
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
                switch (Wizard.ActiveStep.Name)
                {
                    case "Begin":
                        StepBeginIn();
                        break;

                    case "Finish":
                        StepFinishIn();
                        break;
                }
            }
        }



        protected void Wizard_NextButtonClick(object sender, WizardNavigationEventArgs e)
        {
            switch (Wizard.ActiveStep.Name)
            {
                case "Begin":
                    e.Cancel = !StepBeginNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "Begin";
                    }
                    break;
            }
        }



        protected void Wizard_PreviousButtonClick(object sender, WizardNavigationEventArgs e)
        {
            switch (Wizard.ActiveStep.Name)
            {
                case "Finish":
                    e.Cancel = !StepFinishPrevious();
                    break;
            }
            if (!e.Cancel)
            {
                ViewState["StepFrom"] = Wizard.ActiveStep.Name;
            }
        }



        protected void Wizard_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        {
            hdfUpdate.Value = "yes";
            Response.Write("<script language='javascript'> { window.close();}</script>");
        }



        protected void Wizard_CancelButtonClick(object sender, EventArgs e)
        {
            flatSectionJlTDS.RejectChanges();
            Response.Write("<script language='javascript'> { window.close();}</script>");
        }

        #endregion






        #region STEP1 - BEGIN

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // STEP1 - BEGIN
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP1 - BEGIN - AUXILIAR EVENTS
        //

        protected void ddlFieldToUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Date fields
            if ((ddlFieldToUpdate.SelectedValue == "VideoInspection") || (ddlFieldToUpdate.SelectedValue == "PipeLocated") || (ddlFieldToUpdate.SelectedValue == "ServicesLocated") || (ddlFieldToUpdate.SelectedValue == "CoInstalled")
                || (ddlFieldToUpdate.SelectedValue == "BackfilledConcrete") || (ddlFieldToUpdate.SelectedValue == "BackfilledSoil") || (ddlFieldToUpdate.SelectedValue == "Grouted") || (ddlFieldToUpdate.SelectedValue == "Cored")
                || (ddlFieldToUpdate.SelectedValue == "Prepped") || (ddlFieldToUpdate.SelectedValue == "PreVideo") || (ddlFieldToUpdate.SelectedValue == "Measured") || (ddlFieldToUpdate.SelectedValue == "NoticeDelivered")
                || (ddlFieldToUpdate.SelectedValue == "InProcess") || (ddlFieldToUpdate.SelectedValue == "InStock") || (ddlFieldToUpdate.SelectedValue == "Delivered") || (ddlFieldToUpdate.SelectedValue == "LinerInstalled")
                || (ddlFieldToUpdate.SelectedValue == "FinalVideo") || (ddlFieldToUpdate.SelectedValue == "CoCutDown") || (ddlFieldToUpdate.SelectedValue == "FinalRestoration")
                || (ddlFieldToUpdate.SelectedValue == "DigRequiredPriorToLiningCompleted") || (ddlFieldToUpdate.SelectedValue == "DigRequiredAfterLiningCompleted") || (ddlFieldToUpdate.SelectedValue == "HoldClientIssueResolved")
                || (ddlFieldToUpdate.SelectedValue == "HoldLFSIssueResolved") || (ddlFieldToUpdate.SelectedValue == "LateralRequiresRoboticPrepCompleted")
               )
            {
                tkrdpValue.Visible = true;
                cbxValue.Visible = false;
                ddlCoPitLocationValue.Visible = false;
                tbxComments.Visible = false;
                ddlPrepType.Visible = false;
                ddlLinerType.Visible = false;
                tbxValue.Visible = false;
            }
            else
            {
                tbxValue.Visible = false;

                // String fields
                if (ddlFieldToUpdate.SelectedValue == "CoPitLocation")
                {
                    tkrdpValue.Visible = false;
                    cbxValue.Visible = false;
                    ddlCoPitLocationValue.Visible = true;
                    ddlPrepType.Visible = false;
                    ddlLinerType.Visible = false;
                    tbxComments.Visible = false;
                }

                // String fields
                if (ddlFieldToUpdate.SelectedValue == "PrepType")
                {
                    tkrdpValue.Visible = false;
                    cbxValue.Visible = false;
                    ddlCoPitLocationValue.Visible = false;
                    ddlPrepType.Visible = true;
                    ddlLinerType.Visible = false;
                    tbxComments.Visible = false;
                }

                // String fields
                if (ddlFieldToUpdate.SelectedValue == "LinerType")
                {
                    tkrdpValue.Visible = false;
                    cbxValue.Visible = false;
                    ddlCoPitLocationValue.Visible = false;
                    ddlPrepType.Visible = false;
                    ddlLinerType.Visible = true;
                    tbxComments.Visible = false;
                }

                // String fields
                if (ddlFieldToUpdate.SelectedValue == "ContractYear")
                {
                    tkrdpValue.Visible = false;
                    cbxValue.Visible = false;
                    ddlCoPitLocationValue.Visible = false;
                    ddlPrepType.Visible = false;
                    ddlLinerType.Visible = false;
                    tbxComments.Visible = false;
                    tbxValue.Visible = true;
                }

                // Boolean fields
                if ((ddlFieldToUpdate.SelectedValue == "CoRequired") || (ddlFieldToUpdate.SelectedValue == "OutOfScope") || (ddlFieldToUpdate.SelectedValue == "DigRequiredPriorToLining") || (ddlFieldToUpdate.SelectedValue == "DigRequiredAfterLining") || (ddlFieldToUpdate.SelectedValue == "HoldClientIssue")
                    || (ddlFieldToUpdate.SelectedValue == "HoldLFSIssue") || (ddlFieldToUpdate.SelectedValue == "LateralRequiresRoboticPrep"))
                {
                    tkrdpValue.Visible = false;
                    cbxValue.Visible = true;
                    ddlCoPitLocationValue.Visible = false;
                    ddlPrepType.Visible = false;
                    ddlLinerType.Visible = false;
                    tbxComments.Visible = false;
                }

                // Special fields - Comment
                if (ddlFieldToUpdate.SelectedValue == "Comment")
                {
                    tkrdpValue.Visible = false;
                    cbxValue.Visible = false;
                    ddlCoPitLocationValue.Visible = false;
                    ddlPrepType.Visible = false;
                    ddlLinerType.Visible = false;
                    tbxComments.Visible = true;

                    FlatSectionJlCommentDetailsGateway flatSectionJlCommentDetailsGateway = new FlatSectionJlCommentDetailsGateway(flatSectionJlTDS);
                    flatSectionJlCommentDetailsGateway.ClearBeforeFill = false;
                    FlatSectionJl flatSectionJl = new FlatSectionJl(flatSectionJlTDS);
                    DataView dataViewFlatSectionJl = new DataView(flatSectionJlTDS.FlatSectionJl);
                    dataViewFlatSectionJl.RowFilter = "(Selected = 1) AND (Deleted = 0)";

                    foreach (DataRowView row in dataViewFlatSectionJl)
                    {
                        int workId = Int32.Parse(row["WorkID"].ToString());
                        int companyId = Int32.Parse(Session["companyID"].ToString());

                        // Get comments                        
                        flatSectionJlCommentDetailsGateway.LoadAllByWorkIdWorkType(workId, companyId, "Junction Lining Lateral");
                    }
                }
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP1 - BEGIN - METHODS
        //

        private void StepBeginIn()
        {
            // Set instruction
            mWizard2 master2 = (mWizard2)this.Master;
            master2.WizardInstruction = "This tool will update several fields at once";

            hdfStep.Value = "Begin";
        }



        private bool StepBeginNext()
        {
            Page.Validate("Begin");

            if (Page.IsValid)
            {
                Save();
                hdfUpdate.Value = "yes";
                return true;
            }
            else
            {
                return false;
            }
        }        

        #endregion






        #region STEP2 - FINISH

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // STEP2 - FINISH
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP2 - FINISH - METHODS
        //

        private void StepFinishIn()
        {
            // Set instruction
            mWizard2 master2 = (mWizard2)this.Master;
            master2.WizardInstruction = "Summary";

            hdfStep.Value = "Finish";
        }



        private bool StepFinishPrevious()
        {
            return true;
        }
        
        #endregion






        // ////////////////////////////////////////////////////////////////////////
        // FINAL EVENTS
        //

        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set title
            mWizard2 master2 = (mWizard2)this.Master;
            master2.WizardTitle = "Bulk Field Update";
        }






        // ////////////////////////////////////////////////////////////////////////
        // METHODS
        //

        private void RegisterClientScripts()
        {
            // Publishing body's OnKeyDown event 
            HtmlGenericControl bodyUnload = (HtmlGenericControl)Page.Master.FindControl("myBody");
            bodyUnload.Attributes.Add("OnKeyDown", "OnKeyDown(event);");

            // Register client-side events
            HtmlGenericControl body = (HtmlGenericControl)Page.Master.FindControl("myBody");
            body.Attributes.Add("onunload", "OnUnload();");

            // Register content variables
            string contentVariables = "";
            contentVariables += "var hdfUpdateId = '" + hdfUpdate.ClientID + "';";
            contentVariables += "var hdfStepId = '" + hdfStep.ClientID + "';";

            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./jl_bulk_date_update.js");
        }



        private void Save()
        {
            FlatSectionJl flatSectionJl = new FlatSectionJl(flatSectionJlTDS);
            
            DataView dataViewFlatSectionJl = new DataView(flatSectionJlTDS.FlatSectionJl);
            dataViewFlatSectionJl.RowFilter = "(Selected = 1) AND (Deleted = 0)";
            
            string summary = "";
            bool existsDataModificated = false;
            string fieldToUpdate = ddlFieldToUpdate.SelectedValue;

            foreach (DataRowView row in dataViewFlatSectionJl)
            {
                if (IsValidLateralToUpdate(fieldToUpdate, row))
                {                    
                    int workId = Int32.Parse(row["WorkID"].ToString());

                    // Date fields
                    if ((fieldToUpdate == "VideoInspection") || (fieldToUpdate == "PipeLocated") || (fieldToUpdate == "ServicesLocated") || (fieldToUpdate == "CoInstalled")
                        || (fieldToUpdate == "BackfilledConcrete") || (fieldToUpdate == "BackfilledSoil") || (fieldToUpdate == "Grouted") || (fieldToUpdate == "Cored")
                        || (fieldToUpdate == "Prepped") || (fieldToUpdate == "PreVideo") || (fieldToUpdate == "Measured") || (fieldToUpdate == "NoticeDelivered")
                        || (fieldToUpdate == "InProcess") || (fieldToUpdate == "InStock") || (fieldToUpdate == "Delivered") || (fieldToUpdate == "LinerInstalled")
                        || (fieldToUpdate == "FinalVideo") || (fieldToUpdate == "CoCutDown") || (fieldToUpdate == "FinalRestoration")
                        || (fieldToUpdate == "DigRequiredPriorToLiningCompleted") || (fieldToUpdate == "DigRequiredAfterLiningCompleted") || (fieldToUpdate == "HoldClientIssueResolved")
                        || (fieldToUpdate == "HoldLFSIssueResolved") || (fieldToUpdate == "LateralRequiresRoboticPrepCompleted")
                       )
                    {
                        // ... Update row
                        flatSectionJl.UpdateDateField(workId, fieldToUpdate, tkrdpValue.SelectedDate);
                        existsDataModificated = true;
                    }
                    else
                    {
                        // String fields
                        if (fieldToUpdate == "CoPitLocation")
                        {
                            // ... Update row
                            flatSectionJl.UpdateStringField(workId, fieldToUpdate, ddlCoPitLocationValue.SelectedValue);
                            existsDataModificated = true;
                        }

                        // String fields
                        if (fieldToUpdate == "PrepType")
                        {
                            // ... Update row
                            flatSectionJl.UpdateStringField(workId, fieldToUpdate, ddlPrepType.SelectedValue);
                            existsDataModificated = true;
                        }

                        // String fields
                        if (fieldToUpdate == "LinerType")
                        {
                            // ... Update row
                            flatSectionJl.UpdateStringField(workId, fieldToUpdate, ddlLinerType.SelectedValue);
                            existsDataModificated = true;
                        }

                        // String fields
                        if (fieldToUpdate == "ContractYear")
                        {
                            // ... Update row
                            flatSectionJl.UpdateStringField(workId, fieldToUpdate, tbxValue.Text);
                            existsDataModificated = true;
                        }

                        // Boolean fields
                        if ((fieldToUpdate == "CoRequired") || (fieldToUpdate == "OutOfScope") || (fieldToUpdate == "DigRequiredPriorToLining") || (fieldToUpdate == "DigRequiredAfterLining") 
                            || (fieldToUpdate == "HoldClientIssue") || (fieldToUpdate == "HoldLFSIssue") || (fieldToUpdate == "LateralRequiresRoboticPrep"))
                        {
                            // ... Update row
                            flatSectionJl.UpdateBooleanField(workId, fieldToUpdate, cbxValue.Checked);
                            existsDataModificated = true;
                        }

                        // Special field - Comment
                        if (fieldToUpdate == "Comment")
                        {
                            // ... Update row
                            AddComments(workId, tbxComments.Text);
                            ViewState["UpdateComments"] = true;
                            existsDataModificated = true;
                        }
                    }
                }
                else
                {
                    string[] flowOderId = row["LateralDescription"].ToString().Split('-');

                    if (summary.Trim().Length == 0)
                    {
                        string reason = "";

                        switch (fieldToUpdate)
                        {
                            case "DigRequiredPriorToLining":
                                reason = "Dig Required Prior To Lining Completed has value.";
                                break;

                            case "DigRequiredPriorToLiningCompleted":
                                reason = "Dig Required Prior To Lining is not checked.";
                                break;

                            case "DigRequiredAfterLining":
                                reason = "Dig Required After Lining Completed has value.";
                                break;

                            case "DigRequiredAfterLiningCompleted":
                                reason = "Dig Required After Lining is not checked.";
                                break;

                            case "HoldClientIssue":
                                reason = "Hold - Client Issue Resolved has value.";
                                break;

                            case "HoldClientIssueResolved":
                                reason = "Hold - Client Issue is not checked.";
                                break;

                            case "HoldLFSIssue":
                                reason = "Hold - LFS Issue Resolved has value.";
                                break;

                            case "HoldLFSIssueResolved":
                                reason = "Hold - LFS Issue is not checked.";
                                break;

                            case "LateralRequiresRoboticPrep":
                                reason = "Requires Robotic Prep Completed has value.";
                                break;

                            case "LateralRequiresRoboticPrepCompleted":
                                reason = "Requires Robotic Prep is not checked.";
                                break;
                        }

                        summary = "The following laterals were not updated because " + reason + "\n\n";

                        summary = summary + "\t - " + flowOderId[1] + "-JL-" + flowOderId[2] + "\n";
                    }
                    else
                    {
                        summary = summary + "\t - " + flowOderId[1] + "-JL-" + flowOderId[2] + "\n";
                    }
                }               
            }

            if (summary.Trim().Length == 0)
            {
                summary = "All the laterals were updated\n\n";
            }

            tbxSummary.Text = summary;

            // Store datasets
            Session["flatSectionJlTDS"] = flatSectionJlTDS;

            if (existsDataModificated)
            {
                // Update database
                UpdateDatabase();
            }
        }



        private bool IsValidLateralToUpdate(string fieldToUpdate, DataRowView row)
        {
            switch (fieldToUpdate)
            {
                case "DigRequiredPriorToLining":
                    if (!row.Row.IsNull("DigRequiredPriorToLiningCompleted") && !cbxValue.Checked)
                    {
                        return false;
                    }
                    break;

                case "DigRequiredPriorToLiningCompleted":
                    if (!Convert.ToBoolean(row["DigRequiredPriorToLining"]))
                    {
                        return false;
                    }
                    break;

                case "DigRequiredAfterLining":
                    if (!row.Row.IsNull("DigRequiredAfterLiningCompleted") && !cbxValue.Checked)
                    {
                        return false;
                    }
                    break;

                case "DigRequiredAfterLiningCompleted":
                    if (!Convert.ToBoolean(row["DigRequiredAfterLining"]))
                    {
                        return false;
                    }
                    break;

                case "HoldClientIssue":
                    if (!row.Row.IsNull("HoldClientIssueResolved") && !cbxValue.Checked)
                    {
                        return false;
                    }
                    break;

                case "HoldClientIssueResolved":
                    if (!Convert.ToBoolean(row["HoldClientIssue"]))
                    {
                        return false;
                    }
                    break;

                case "HoldLFSIssue":
                    if (!row.Row.IsNull("HoldLFSIssueResolved") && !cbxValue.Checked)
                    {
                        return false;
                    }
                    break;

                case "HoldLFSIssueResolved":
                    if (!Convert.ToBoolean(row["HoldLFSIssue"]))
                    {
                        return false;
                    }
                    break;

                case "LateralRequiresRoboticPrep":
                    if (!row.Row.IsNull("LateralRequiresRoboticPrepCompleted") && !cbxValue.Checked)
                    {
                        return false;
                    }
                    break;

                case "LateralRequiresRoboticPrepCompleted":
                    if (!Convert.ToBoolean(row["LateralRequiresRoboticPrep"]))
                    {
                        return false;
                    }
                    break;
            }

            return true;
        }



        private void UpdateDatabase()
        {
            // Get ids & location
            int projectId = Int32.Parse(hdfCurrentProject.Value.Trim());
            int companyId = Int32.Parse(Session["companyID"].ToString());

            // Load project
            ProjectGateway projectGateway = new ProjectGateway();
            projectGateway.LoadByProjectId(projectId);

            // Get location
            Int64 countryId = projectGateway.GetCountryID(projectId);
            Int64? provinceId = null; if (projectGateway.GetProvinceID(projectId).HasValue) provinceId = (Int64)projectGateway.GetProvinceID(projectId);
            Int64? countyId = null; if (projectGateway.GetCountyID(projectId).HasValue) countyId = (Int64)projectGateway.GetCountyID(projectId);
            Int64? cityId = null; if (projectGateway.GetCityID(projectId).HasValue) cityId = (Int64)projectGateway.GetCityID(projectId);

            // Save
            DB.Open();
            DB.BeginTransaction();
            try
            {
                FlatSectionJl flatSectionJl = new FlatSectionJl(flatSectionJlTDS);

                if (Convert.ToBoolean(ViewState["UpdateComments"]))
                {
                    // Update Comments
                    FlatSectionJlCommentDetails flatSectionJlCommentDetails = new FlatSectionJlCommentDetails(flatSectionJlTDS);
                    flatSectionJlCommentDetails.Save(companyId);

                    // Update works
                    WorkUpdate();                    
                }
                else
                {
                    flatSectionJl.UpdateDirect(countryId, provinceId, countyId, cityId, projectId, companyId);
                }

                DB.CommitTransaction();

                flatSectionJlTDS.AcceptChanges();

                // Store datasets
                Session["flatSectionJlTDS"] = flatSectionJlTDS;
            }
            catch (Exception ex)
            {
                DB.RollbackTransaction();

                string url = string.Format("./../../error_page.aspx?error={0}", ex.Message.Replace('\n', ' '));
                Response.Redirect(url);
            }           
        }



        private void AddComments(int workId, string comment)
        {
            int companyId = Convert.ToInt32(Session["companyID"]);
            int loginId = Convert.ToInt32(Session["loginID"]);
            DateTime dateTime_ = DateTime.Now;
            bool inDatabase = false;
            bool deleted = false;

            string newSubject = "Bulk Field Update Comments";
            string newType = "Junction Lining Lateral";
            int? libraryFilesId = null;
            bool toHistory = false;

            LoginGateway loginGateway = new LoginGateway();
            loginGateway.LoadByLoginId(loginId, companyId);
            string userFullName = loginGateway.GetLastName(loginId, companyId) + " " + loginGateway.GetFirstName(loginId, companyId);

            FlatSectionJlCommentDetails model = new FlatSectionJlCommentDetails(flatSectionJlTDS);
            model.InsertForBulkFieldUpdate(workId, newType, newSubject, loginId, dateTime_, comment, libraryFilesId, deleted, companyId, inDatabase, userFullName, toHistory);            
        }



        private void WorkUpdate()
        {
            // Get general variables
            int projectId = Int32.Parse(hdfCurrentProject.Value.Trim());
            int companyId = Convert.ToInt32(Session["companyID"]);
            FlatSectionJl flatSectionJl = new FlatSectionJl(flatSectionJlTDS);
            DataView dataViewFlatSectionJl = new DataView(flatSectionJlTDS.FlatSectionJl);
            dataViewFlatSectionJl.RowFilter = "(Selected = 1) AND (Deleted = 0)";
            
            foreach (DataRowView row in dataViewFlatSectionJl)
            {
                int workId = Int32.Parse(row["WorkID"].ToString());
                int assetId = Int32.Parse(row["AssetID"].ToString());
                string workType = "Junction Lining Lateral";

                // Get original variables
                WorkGateway workGateway = new WorkGateway();
                workGateway.LoadByWorkId(workId, companyId);

                string originalWorkType = workGateway.GetWorkTypeOriginal(workId);
                int? originalLibraryCategoriesId = workGateway.GetLibraryCategoriesIdOriginal(workId);
                string originalComment = workGateway.GetCommentsOriginal(workId);
                string originalHistory = workGateway.GetHistoryOriginal(workId);

                // Get new comment
                WorkCommentsGateway workCommentsGateway = new WorkCommentsGateway();
                workCommentsGateway.LoadByWorkIdWorkType(workId, companyId, "Junction Lining Lateral");
                WorkComments workComments = new WorkComments(workCommentsGateway.Data);
                string newComments = workComments.GetAllComments(workId, companyId, workCommentsGateway.Table.Rows.Count, "\n");

                // Get new history
                WorkHistoryGateway workHistoryGateway = new WorkHistoryGateway();
                workHistoryGateway.LoadByWorkIdWorkType(workId, companyId, "Junction Lining Lateral");
                WorkHistory workHistory = new WorkHistory(workHistoryGateway.Data);
                string newHistory = workHistory.GetAllHistory(workId, companyId, workHistoryGateway.Table.Rows.Count, "\n");

                Work work = new Work(null);
                work.UpdateDirect(workId, projectId, assetId, originalWorkType, originalLibraryCategoriesId, false, companyId, originalComment, originalHistory, workId, projectId, assetId, originalWorkType, originalLibraryCategoriesId, false, companyId, newComments, newHistory);

                flatSectionJl.UpdateCommentsHistoryForSummaryEdit(workId, workType, companyId);
            }
        }



    }
}