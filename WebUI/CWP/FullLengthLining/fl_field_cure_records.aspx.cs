using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.Server;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.Tools;
using LiquiForce.LFSLive.BL.CWP.FullLengthLining;
using LiquiForce.LFSLive.DA.CWP.FullLengthLining;

namespace LiquiForce.LFSLive.WebUI.CWP.FullLengthLining
{
    /// <summary>
    /// fl_field_cure_records
    /// </summary>
    public partial class fl_field_cure_records : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //
        protected FlInversionFieldCureRecordTDS flInversionFieldCureRecordTDS;
        protected FlInversionFieldCureRecordTDS.InversionFieldCureRecordDataTable flInversionFieldCureRecord;






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
                if (!(Convert.ToBoolean(Session["sgLFS_CWP_FULLLENGTHLINING_VIEW"]) && Convert.ToBoolean(Session["sgLFS_CWP_FULLLENGTHLINING_EDIT"]) && Convert.ToBoolean(Session["sgLFS_CWP_FULLLENGTHLINING_ADD"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) && ((string)Request.QueryString["work_id"] == null) && ((string)Request.QueryString["run_details"] == null) && ((string)Request.QueryString["project_id"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in fl_field_cure_records.aspx");
                }

                // Tag page
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfWorkId.Value = Request.QueryString["work_id"].ToString();
                hdfRunDetails.Value = Request.QueryString["run_details"].ToString();
                hdfProjectId.Value = Request.QueryString["project_id"].ToString();
                hdfUpdate.Value = "no";

                Session.Remove("flInversionFieldCureRecord");
                Session.Remove("flInversionFieldCureRecordDummy");

                // ... Store datasets
                flInversionFieldCureRecordTDS = new FlInversionFieldCureRecordTDS();
                Session["flInversionFieldCureRecordTDS"] = flInversionFieldCureRecordTDS;
                Session["flInversionFieldCureRecord"] = flInversionFieldCureRecordTDS.InversionFieldCureRecord;

                // StepSection1In
                wizard.ActiveStepIndex = 0;
                StepBeginIn();
            }
            else
            {
                // Restore datasets
                flInversionFieldCureRecordTDS = (FlInversionFieldCureRecordTDS)Session["flInversionFieldCureRecordTDS"];

                // Store
                Session["flInversionFieldCureRecord"] = flInversionFieldCureRecordTDS.InversionFieldCureRecord;
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
                switch (wizard.ActiveStep.Name)
                {
                    case "Begin":
                        StepBeginIn();
                        break;

                    case "Finish":
                        StepSummaryIn();
                        break;

                    default:
                        throw new Exception("The option for " + wizard.ActiveStep.Name + " step in fl_field_cure_records.Wizard_ActiveStepChanged function does not exist");
                }
            }
        }



        protected void Wizard_NextButtonClick(object sender, WizardNavigationEventArgs e)
        {
            switch (wizard.ActiveStep.Name)
            {
                case "Begin":
                    e.Cancel = !StepBeginNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "Begin";
                        wizard.ActiveStepIndex = wizard.WizardSteps.IndexOf(Summary);
                    }
                    break;

                default:
                    throw new Exception("The option for " + wizard.ActiveStep.Name + " step in fl_field_cure_records.Wizard_NextButtonClick function does not exist");
            }
        }



        protected void Wizard_PreviousButtonClick(object sender, WizardNavigationEventArgs e)
        {

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
        // STEP1 - BEGIN - EVENTS
        //

        protected void grdFieldCureRecord_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Add":
                    // FieldCureRecord Gridview, if the gridview is edition mode
                    if (grdFieldCureRecord.EditIndex >= 0)
                    {
                        grdFieldCureRecord.UpdateRow(grdFieldCureRecord.EditIndex, true);
                    }

                    // Add New field cure record
                    GrdFieldCureRecordAdd();
                    break;
            }
        }



        protected void grdFieldCureRecord_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // FieldCureRecord Gridview, if the gridview is edition mode
            if (grdFieldCureRecord.EditIndex >= 0)
            {
                grdFieldCureRecord.UpdateRow(grdFieldCureRecord.EditIndex, true);
            }

            //Delete field cure record
            int workId = Int32.Parse(hdfWorkId.Value);
            int refId = (int)e.Keys["RefID"];
            int companyId = Int32.Parse(hdfCompanyId.Value);

            // Delete field cure record
            FlInversionFieldCureRecord model = new FlInversionFieldCureRecord(flInversionFieldCureRecordTDS);
            model.Delete(workId, refId, companyId);

            // Store dataset
            Session["flInversionFieldCureRecordTDS"] = flInversionFieldCureRecordTDS;

            grdFieldCureRecord.DataBind();
        }



        protected void grdFieldCureRecord_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.Validate("dataEdit");
            if (Page.IsValid)
            {
                int workId = Int32.Parse(hdfWorkId.Value);
                int refId = (int)e.Keys["RefID"];
                int companyId = Int32.Parse(hdfCompanyId.Value);

                string readingTimeText = "";
                string readingHoursEdit = ((DropDownList)grdFieldCureRecord.Rows[e.RowIndex].Cells[2].FindControl("ddlReadingTimeHourEdit")).SelectedValue.Trim();
                string readingMinutesEdit = ((DropDownList)grdFieldCureRecord.Rows[e.RowIndex].Cells[2].FindControl("ddlReadingTimeMinuteEdit")).SelectedValue.Trim();

                if ((readingHoursEdit != "") && (readingMinutesEdit != ""))
                {
                    readingTimeText = readingHoursEdit + ":" + readingMinutesEdit;
                }
                DateTime readingTime = DateTime.Parse(readingTimeText);

                decimal? headFt = null;
                if (((TextBox)grdFieldCureRecord.Rows[e.RowIndex].Cells[3].FindControl("tbxHeadFtEdit")).Text.Trim() != "")
                {
                    if (Validator.IsValidDecimal(((TextBox)grdFieldCureRecord.Rows[e.RowIndex].Cells[3].FindControl("tbxHeadFtEdit")).Text.Trim()))
                    { 
                        headFt = decimal.Round(decimal.Parse(((TextBox)grdFieldCureRecord.Rows[e.RowIndex].Cells[3].FindControl("tbxHeadFtEdit")).Text.Trim()), 2);
                    }
                }

                decimal? boilerInF = null;
                if (((TextBox)grdFieldCureRecord.Rows[e.RowIndex].Cells[4].FindControl("tbxBoilerInFEdit")).Text.Trim() != "")
                {
                    if (Validator.IsValidDecimal(((TextBox)grdFieldCureRecord.Rows[e.RowIndex].Cells[4].FindControl("tbxBoilerInFEdit")).Text.Trim()))
                    { 
                        boilerInF = decimal.Round(decimal.Parse(((TextBox)grdFieldCureRecord.Rows[e.RowIndex].Cells[4].FindControl("tbxBoilerInFEdit")).Text.Trim()), 2);
                    }
                }

                decimal? boilerOutF = null;
                if (((TextBox)grdFieldCureRecord.Rows[e.RowIndex].Cells[5].FindControl("tbxBoilerOutFEdit")).Text.Trim() != "")
                {
                    if (Validator.IsValidDecimal(((TextBox)grdFieldCureRecord.Rows[e.RowIndex].Cells[5].FindControl("tbxBoilerOutFEdit")).Text.Trim()))
                    { 
                        boilerOutF = decimal.Round(decimal.Parse(((TextBox)grdFieldCureRecord.Rows[e.RowIndex].Cells[5].FindControl("tbxBoilerOutFEdit")).Text.Trim()), 2);
                    }
                }


                decimal? pumpFlow = null;
                if (((TextBox)grdFieldCureRecord.Rows[e.RowIndex].Cells[6].FindControl("tbxPumpFlowEdit")).Text.Trim() != "")
                {
                    if ((Validator.IsValidDecimal(((TextBox)grdFieldCureRecord.Rows[e.RowIndex].Cells[6].FindControl("tbxPumpFlowEdit")).Text.Trim())))
                    {
                        pumpFlow = decimal.Round(decimal.Parse(((TextBox)grdFieldCureRecord.Rows[e.RowIndex].Cells[6].FindControl("tbxPumpFlowEdit")).Text.Trim()), 2);
                    }
                }

               decimal? pumpPsi = null;
               if (((TextBox)grdFieldCureRecord.Rows[e.RowIndex].Cells[7].FindControl("tbxPumpPsiEdit")).Text.Trim() != "")
                {
                    if ((Validator.IsValidDecimal(((TextBox)grdFieldCureRecord.Rows[e.RowIndex].Cells[7].FindControl("tbxPumpPsiEdit")).Text.Trim())))
                    {
                        pumpPsi = decimal.Round(decimal.Parse(((TextBox)grdFieldCureRecord.Rows[e.RowIndex].Cells[7].FindControl("tbxPumpPsiEdit")).Text.Trim()), 2);
                    }
                }

               decimal? mh1Top = null;
                if (((TextBox)grdFieldCureRecord.Rows[e.RowIndex].Cells[8].FindControl("tbxMH1TopEdit")).Text.Trim() != "")
                {
                    if ((Validator.IsValidDecimal(((TextBox)grdFieldCureRecord.Rows[e.RowIndex].Cells[8].FindControl("tbxMH1TopEdit")).Text.Trim())))
                    {
                        mh1Top = decimal.Round(decimal.Parse(((TextBox)grdFieldCureRecord.Rows[e.RowIndex].Cells[8].FindControl("tbxMH1TopEdit")).Text.Trim()), 2);
                    }
                }

                decimal? mh1Bot = null;
                if (((TextBox)grdFieldCureRecord.Rows[e.RowIndex].Cells[9].FindControl("tbxMH1BotEdit")).Text.Trim() != "")
                {
                    if ((Validator.IsValidDecimal(((TextBox)grdFieldCureRecord.Rows[e.RowIndex].Cells[9].FindControl("tbxMH1BotEdit")).Text.Trim())))
                    {
                        mh1Bot = decimal.Round(decimal.Parse(((TextBox)grdFieldCureRecord.Rows[e.RowIndex].Cells[9].FindControl("tbxMH1BotEdit")).Text.Trim()), 2);
                    }
                }

                decimal? mh2Top = null;
                if (((TextBox)grdFieldCureRecord.Rows[e.RowIndex].Cells[10].FindControl("tbxMH2TopEdit")).Text.Trim() != "")
                {
                    if ((Validator.IsValidDecimal(((TextBox)grdFieldCureRecord.Rows[e.RowIndex].Cells[10].FindControl("tbxMH2TopEdit")).Text.Trim())))
                    {
                        mh2Top = decimal.Round(decimal.Parse(((TextBox)grdFieldCureRecord.Rows[e.RowIndex].Cells[10].FindControl("tbxMH2TopEdit")).Text.Trim()), 2);
                    }
                }

                decimal? mh2Bot = null;
                if (((TextBox)grdFieldCureRecord.Rows[e.RowIndex].Cells[11].FindControl("tbxMH2BotEdit")).Text.Trim() != "")
                {
                    if ((Validator.IsValidDecimal(((TextBox)grdFieldCureRecord.Rows[e.RowIndex].Cells[11].FindControl("tbxMH2BotEdit")).Text.Trim())))
                    {
                        mh2Bot = decimal.Round(decimal.Parse(((TextBox)grdFieldCureRecord.Rows[e.RowIndex].Cells[11].FindControl("tbxMH2BotEdit")).Text.Trim()), 2);
                    }
                }

                decimal? mh3Top = null;
                if (((TextBox)grdFieldCureRecord.Rows[e.RowIndex].Cells[12].FindControl("tbxMH3TopEdit")).Text.Trim() != "")
                {
                    if ((Validator.IsValidDecimal(((TextBox)grdFieldCureRecord.Rows[e.RowIndex].Cells[12].FindControl("tbxMH3TopEdit")).Text.Trim())))
                    {
                        mh3Top = decimal.Round(decimal.Parse(((TextBox)grdFieldCureRecord.Rows[e.RowIndex].Cells[12].FindControl("tbxMH3TopEdit")).Text.Trim()), 2);
                    }
                }

                decimal? mh3Bot = null;
                if (((TextBox)grdFieldCureRecord.Rows[e.RowIndex].Cells[13].FindControl("tbxMH3BotEdit")).Text.Trim() != "")
                {
                    if ((Validator.IsValidDecimal(((TextBox)grdFieldCureRecord.Rows[e.RowIndex].Cells[13].FindControl("tbxMH3BotEdit")).Text.Trim())))
                    {
                        mh3Bot = decimal.Round(decimal.Parse(((TextBox)grdFieldCureRecord.Rows[e.RowIndex].Cells[13].FindControl("tbxMH3BotEdit")).Text.Trim()), 2);
                    }
                }

                decimal? mh4Top = null;
                if (((TextBox)grdFieldCureRecord.Rows[e.RowIndex].Cells[14].FindControl("tbxMH4TopEdit")).Text.Trim() != "")
                {
                    if ((Validator.IsValidDecimal(((TextBox)grdFieldCureRecord.Rows[e.RowIndex].Cells[14].FindControl("tbxMH4TopEdit")).Text.Trim())))
                    {
                        mh4Top = decimal.Round(decimal.Parse(((TextBox)grdFieldCureRecord.Rows[e.RowIndex].Cells[14].FindControl("tbxMH4TopEdit")).Text.Trim()), 2);
                    }
                }

                decimal? mh4Bot = null;
                if (((TextBox)grdFieldCureRecord.Rows[e.RowIndex].Cells[15].FindControl("tbxMH4BotEdit")).Text.Trim() != "")
                {
                    if ((Validator.IsValidDecimal(((TextBox)grdFieldCureRecord.Rows[e.RowIndex].Cells[15].FindControl("tbxMH4BotEdit")).Text.Trim())))
                    {
                        mh4Bot = decimal.Round(decimal.Parse(((TextBox)grdFieldCureRecord.Rows[e.RowIndex].Cells[15].FindControl("tbxMH4BotEdit")).Text.Trim()), 2);
                    }
                }

                string comments = ((TextBox)grdFieldCureRecord.Rows[e.RowIndex].Cells[16].FindControl("tbxCommentsEdit")).Text.Trim();

                FlInversionFieldCureRecord model = new FlInversionFieldCureRecord(flInversionFieldCureRecordTDS);
                model.Update(workId, refId, readingTime, headFt, boilerInF, boilerOutF, pumpFlow, pumpPsi, mh1Top, mh1Bot, mh2Top, mh2Bot, mh3Top, mh3Bot, mh4Top, mh4Bot,comments);

                // Store dataset
                Session["flInversionFieldCureRecordTDS"] = flInversionFieldCureRecordTDS;
                Session["flatSectionJlCommentDetails"] = flInversionFieldCureRecordTDS.InversionFieldCureRecord;
            }
            else
            {
                e.Cancel = true;
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP1 - BEGIN - AUXILIAR EVENTS
        //



        protected void grdFieldCureRecord_DataBound(object sender, EventArgs e)
        {
            AddFieldCureRecordNewEmptyFix(grdFieldCureRecord);
        }



        protected void grdFieldCureRecord_RowDataBound(object sender, GridViewRowEventArgs e)
        {          
            // Edit controls
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Edit) || (e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                int workId = Int32.Parse(((Label)e.Row.FindControl("lblWorkIdEdit")).Text);
                int refId = Int32.Parse(((Label)e.Row.FindControl("lblRefIdEdit")).Text);

                FlInversionFieldCureRecordGateway flInversionFieldCureRecordGatewayForGrid = new FlInversionFieldCureRecordGateway(flInversionFieldCureRecordTDS);

                if (flInversionFieldCureRecordGatewayForGrid.Table.Rows.Count > 0)
                {
                    string startTime = "";
                    if (flInversionFieldCureRecordGatewayForGrid.GetReadingTime(workId, refId).ToString() != "")
                    {
                        startTime = flInversionFieldCureRecordGatewayForGrid.GetReadingTime(workId, refId).ToString("H:mm");
                    }

                    if (startTime != "")
                    {
                        string[] hoursMin1 = startTime.Split(':');
                        ((DropDownList)e.Row.FindControl("ddlReadingTimeHourEdit")).SelectedValue = hoursMin1[0].Trim();
                        ((DropDownList)e.Row.FindControl("ddlReadingTimeMinuteEdit")).SelectedValue = hoursMin1[1].Trim();
                    }
                }
            }

            // Normal rows
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Normal) || (e.Row.RowState == (DataControlRowState.Normal | DataControlRowState.Alternate))))
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                int workId = Int32.Parse(((Label)e.Row.FindControl("lblWorkId")).Text);
                int refId = Int32.Parse(((Label)e.Row.FindControl("lblRefId")).Text);

                FlInversionFieldCureRecordGateway flInversionFieldCureRecordGatewayForGrid = new FlInversionFieldCureRecordGateway(flInversionFieldCureRecordTDS);

                if (flInversionFieldCureRecordGatewayForGrid.Table.Rows.Count > 0)
                {
                    // For Start Time
                    string startTime = "";
                    try
                    {
                        if (flInversionFieldCureRecordGatewayForGrid.GetReadingTime(workId,refId).ToString() != "")
                        {
                            startTime = (flInversionFieldCureRecordGatewayForGrid.GetReadingTime(workId, refId)).ToString("H:mm");
                        }
                    }
                    catch
                    {
                    }

                    if (startTime != "")
                    {
                        ((Label)e.Row.FindControl("lblReadingTime")).Text = startTime;
                    }
                }
            }
        }



        protected void grdFieldCureRecord_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // FieldCureRecord Gridview, if the gridview is edition mode
            if (grdFieldCureRecord.EditIndex >= 0)
            {
                grdFieldCureRecord.UpdateRow(grdFieldCureRecord.EditIndex, true);
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP1 - BEGIN - METHODS
        //

        private void StepBeginIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Please provide field cure record information.";

            // Load
            int workId = Int32.Parse(hdfWorkId.Value);
            int companyId = Int32.Parse(hdfCompanyId.Value);
            FlInversionFieldCureRecord model = new FlInversionFieldCureRecord(flInversionFieldCureRecordTDS);
            model.LoadAll(workId, companyId);

            // Store tables
            Session["flInversionFieldCureRecord"] = flInversionFieldCureRecordTDS.InversionFieldCureRecord;
            Session["flInversionFieldCureRecordTDS"] = flInversionFieldCureRecordTDS;
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



        public FlInversionFieldCureRecordTDS.InversionFieldCureRecordDataTable GetFieldCureRecordNew()
        {
            flInversionFieldCureRecord = (FlInversionFieldCureRecordTDS.InversionFieldCureRecordDataTable)Session["flInversionFieldCureRecordDummy"];

            if (flInversionFieldCureRecord == null)
            {
                flInversionFieldCureRecord = ((FlInversionFieldCureRecordTDS.InversionFieldCureRecordDataTable)Session["flInversionFieldCureRecord"]);
            }

            return flInversionFieldCureRecord;
        }



        public void DummyFieldCureRecordNew(int WorkID, int RefID)
        {
        }



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
            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./fl_field_cure_records.js");
        }



        private bool ValidateFieldCureRecordFooter()
        {
            string readingTimeText = "";
            string readingHoursFooter = ((DropDownList)grdFieldCureRecord.FooterRow.FindControl("ddlReadingTimeHourFooter")).SelectedValue.Trim();
            string readingMinutesFooter = ((DropDownList)grdFieldCureRecord.FooterRow.FindControl("ddlReadingTimeMinuteFooter")).SelectedValue.Trim();

            if ((readingHoursFooter != "") && (readingMinutesFooter != ""))
            {
                readingTimeText = readingHoursFooter + ":" + readingMinutesFooter;
            }            

            decimal? headFt = -1;
            if (((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxHeadFtFooter")).Text.Trim() != "")
            {
                if (Validator.IsValidDecimal(((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxHeadFtFooter")).Text.Trim()))
                {
                    headFt = decimal.Round(decimal.Parse(((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxHeadFtFooter")).Text.Trim()), 2);
                }
            }

            decimal? boilerInF = -1;
            if (((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxBoilerInFFooter")).Text.Trim() != "")
            {
                if (Validator.IsValidDecimal(((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxBoilerInFFooter")).Text.Trim()))
                {
                    boilerInF = decimal.Round(decimal.Parse(((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxBoilerInFFooter")).Text.Trim()), 2);
                }
            }

            decimal? boilerOutF = -1;
            if (((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxBoilerOutFFooter")).Text.Trim() != "")
            {
                if (Validator.IsValidDecimal(((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxBoilerOutFFooter")).Text.Trim()))
                {
                    boilerOutF = decimal.Round(decimal.Parse(((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxBoilerOutFFooter")).Text.Trim()), 2);
                }
            }


            decimal? pumpFlow = -1;
            if (((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxPumpFlowFooter")).Text.Trim() != "")
            {
                if ((Validator.IsValidDecimal(((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxPumpFlowFooter")).Text.Trim())))
                {
                    pumpFlow = decimal.Round(decimal.Parse(((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxPumpFlowFooter")).Text.Trim()), 2);
                }
            }

            decimal? pumpPsi = -1;
            if (((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxPumpPsiFooter")).Text.Trim() != "")
            {
                if ((Validator.IsValidDecimal(((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxPumpPsiFooter")).Text.Trim())))
                {
                    pumpPsi = decimal.Round(decimal.Parse(((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxPumpPsiFooter")).Text.Trim()), 2);
                }
            }

            decimal? mh1Top = -1;
            if (((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxMH1TopFooter")).Text.Trim() != "")
            {
                if ((Validator.IsValidDecimal(((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxMH1TopFooter")).Text.Trim())))
                {
                    mh1Top = decimal.Round(decimal.Parse(((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxMH1TopFooter")).Text.Trim()), 2);
                }
            }

            decimal? mh1Bot = -1;
            if (((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxMH1BotFooter")).Text.Trim() != "")
            {
                if ((Validator.IsValidDecimal(((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxMH1BotFooter")).Text.Trim())))
                {
                    mh1Bot = decimal.Round(decimal.Parse(((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxMH1BotFooter")).Text.Trim()), 2);
                }
            }

            decimal? mh2Top = -1;
            if (((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxMH2TopFooter")).Text.Trim() != "")
            {
                if ((Validator.IsValidDecimal(((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxMH2TopFooter")).Text.Trim())))
                {
                    mh2Top = decimal.Round(decimal.Parse(((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxMH2TopFooter")).Text.Trim()), 2);
                }
            }

            decimal? mh2Bot = -1;
            if (((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxMH2BotFooter")).Text.Trim() != "")
            {
                if ((Validator.IsValidDecimal(((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxMH2BotFooter")).Text.Trim())))
                {
                    mh2Bot = decimal.Round(decimal.Parse(((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxMH2BotFooter")).Text.Trim()), 2);
                }
            }

            decimal? mh3Top = -1;
            if (((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxMH3TopFooter")).Text.Trim() != "")
            {
                if ((Validator.IsValidDecimal(((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxMH3TopFooter")).Text.Trim())))
                {
                    mh3Top = decimal.Round(decimal.Parse(((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxMH3TopFooter")).Text.Trim()), 2);
                }
            }

            decimal? mh3Bot = -1;
            if (((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxMH3BotFooter")).Text.Trim() != "")
            {
                if ((Validator.IsValidDecimal(((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxMH3BotFooter")).Text.Trim())))
                {
                    mh3Bot = decimal.Round(decimal.Parse(((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxMH3BotFooter")).Text.Trim()), 2);
                }
            }

            decimal? mh4Top = -1;
            if (((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxMH4TopFooter")).Text.Trim() != "")
            {
                if ((Validator.IsValidDecimal(((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxMH4TopFooter")).Text.Trim())))
                {
                    mh4Top = decimal.Round(decimal.Parse(((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxMH4TopFooter")).Text.Trim()), 2);
                }
            }

            decimal? mh4Bot = -1;
            if (((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxMH4BotFooter")).Text.Trim() != "")
            {
                if ((Validator.IsValidDecimal(((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxMH4BotFooter")).Text.Trim())))
                {
                    mh4Bot = decimal.Round(decimal.Parse(((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxMH4BotFooter")).Text.Trim()), 2);
                }
            }

            string comments = ((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxCommentsFooter")).Text.Trim();


            if ((readingHoursFooter != "") || (readingHoursFooter != "") || (headFt != -1) || (boilerInF != -1) || (boilerOutF != -1) || (pumpFlow != -1) || (pumpPsi != -1) || (mh1Top != -1) || (mh1Bot != -1) || (mh2Top != -1) || (mh2Bot != -1) || (mh3Top != -1) || (mh3Bot != -1) || (mh4Top != -1) || (mh4Bot != -1) || (comments != ""))
            {
                return true;
            }

            return false;
        }



        protected void AddFieldCureRecordNewEmptyFix(GridView grdFieldCureRecord)
        {
            if (grdFieldCureRecord.Rows.Count == 0)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                FlInversionFieldCureRecordTDS.InversionFieldCureRecordDataTable dt = new FlInversionFieldCureRecordTDS.InversionFieldCureRecordDataTable();
                dt.AddInversionFieldCureRecordRow(-1, -1, DateTime.Now, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, "", false, companyId, false);
                Session["flInversionFieldCureRecordDummy"] = dt;

                grdFieldCureRecord.DataBind();
            }

            // Normally executes at all postbacks
            if (grdFieldCureRecord.Rows.Count == 1)
            {
                FlInversionFieldCureRecordTDS.InversionFieldCureRecordDataTable dt = (FlInversionFieldCureRecordTDS.InversionFieldCureRecordDataTable)Session["flInversionFieldCureRecordDummy"];
                if (dt != null)
                {
                    grdFieldCureRecord.Rows[0].Visible = false;
                    grdFieldCureRecord.Rows[0].Controls.Clear();
                }
            }
        }



        private void GrdFieldCureRecordAdd()
        {
            if (ValidateFieldCureRecordFooter())
            {
                Page.Validate("dataFooter");
                if (Page.IsValid)
                {                    
                    string readingTimeText = "";
                    string readingHoursFooter = ((DropDownList)grdFieldCureRecord.FooterRow.FindControl("ddlReadingTimeHourFooter")).SelectedValue.Trim();
                    string readingMinutesFooter = ((DropDownList)grdFieldCureRecord.FooterRow.FindControl("ddlReadingTimeMinuteFooter")).SelectedValue.Trim();

                    if ((readingHoursFooter != "") && (readingMinutesFooter != ""))
                    {
                        readingTimeText = readingHoursFooter + ":" + readingMinutesFooter;
                    }
                    DateTime readingTime = DateTime.Parse(readingTimeText);

                    decimal? headFt = null;
                    if (((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxHeadFtFooter")).Text.Trim() != "")
                    {
                        if (Validator.IsValidDecimal(((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxHeadFtFooter")).Text.Trim()))
                        {
                            headFt = decimal.Round(decimal.Parse(((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxHeadFtFooter")).Text.Trim()), 2);
                        }
                    }

                    decimal? boilerInF = null;
                    if (((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxBoilerInFFooter")).Text.Trim() != "")
                    {
                        if (Validator.IsValidDecimal(((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxBoilerInFFooter")).Text.Trim()))
                        {
                            boilerInF = decimal.Round(decimal.Parse(((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxBoilerInFFooter")).Text.Trim()), 2);
                        }
                    }

                    decimal? boilerOutF = null;
                    if (((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxBoilerOutFFooter")).Text.Trim() != "")
                    {
                        if (Validator.IsValidDecimal(((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxBoilerOutFFooter")).Text.Trim()))
                        {
                            boilerOutF = decimal.Round(decimal.Parse(((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxBoilerOutFFooter")).Text.Trim()), 2);
                        }
                    }


                    decimal? pumpFlow = null;
                    if (((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxPumpFlowFooter")).Text.Trim() != "")
                    {
                        if ((Validator.IsValidDecimal(((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxPumpFlowFooter")).Text.Trim())))
                        {
                            pumpFlow = decimal.Round(decimal.Parse(((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxPumpFlowFooter")).Text.Trim()), 2);
                        }
                    }

                    decimal? pumpPsi = null;
                    if (((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxPumpPsiFooter")).Text.Trim() != "")
                    {
                        if ((Validator.IsValidDecimal(((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxPumpPsiFooter")).Text.Trim())))
                        {
                            pumpPsi = decimal.Round(decimal.Parse(((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxPumpPsiFooter")).Text.Trim()), 2);
                        }
                    }

                    decimal? mh1Top = null;
                    if (((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxMH1TopFooter")).Text.Trim() != "")
                    {
                        if ((Validator.IsValidDecimal(((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxMH1TopFooter")).Text.Trim())))
                        {
                            mh1Top = decimal.Round(decimal.Parse(((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxMH1TopFooter")).Text.Trim()), 2);
                        }
                    }

                    decimal? mh1Bot = null;
                    if (((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxMH1BotFooter")).Text.Trim() != "")
                    {
                        if ((Validator.IsValidDecimal(((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxMH1BotFooter")).Text.Trim())))
                        {
                            mh1Bot = decimal.Round(decimal.Parse(((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxMH1BotFooter")).Text.Trim()), 2);
                        }
                    }

                    decimal? mh2Top = null;
                    if (((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxMH2TopFooter")).Text.Trim() != "")
                    {
                        if ((Validator.IsValidDecimal(((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxMH2TopFooter")).Text.Trim())))
                        {
                            mh2Top = decimal.Round(decimal.Parse(((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxMH2TopFooter")).Text.Trim()), 2);
                        }
                    }

                    decimal? mh2Bot = null;
                    if (((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxMH2BotFooter")).Text.Trim() != "")
                    {
                        if ((Validator.IsValidDecimal(((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxMH2BotFooter")).Text.Trim())))
                        {
                            mh2Bot = decimal.Round(decimal.Parse(((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxMH2BotFooter")).Text.Trim()), 2);
                        }
                    }

                    decimal? mh3Top = null;
                    if (((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxMH3TopFooter")).Text.Trim() != "")
                    {
                        if ((Validator.IsValidDecimal(((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxMH3TopFooter")).Text.Trim())))
                        {
                            mh3Top = decimal.Round(decimal.Parse(((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxMH3TopFooter")).Text.Trim()), 2);
                        }
                    }

                    decimal? mh3Bot = null;
                    if (((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxMH3BotFooter")).Text.Trim() != "")
                    {
                        if ((Validator.IsValidDecimal(((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxMH3BotFooter")).Text.Trim())))
                        {
                            mh3Bot = decimal.Round(decimal.Parse(((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxMH3BotFooter")).Text.Trim()), 2);
                        }
                    }

                    decimal? mh4Top = null;
                    if (((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxMH4TopFooter")).Text.Trim() != "")
                    {
                        if ((Validator.IsValidDecimal(((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxMH4TopFooter")).Text.Trim())))
                        {
                            mh4Top = decimal.Round(decimal.Parse(((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxMH4TopFooter")).Text.Trim()), 2);
                        }
                    }

                    decimal? mh4Bot = null;
                    if (((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxMH4BotFooter")).Text.Trim() != "")
                    {
                        if ((Validator.IsValidDecimal(((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxMH4BotFooter")).Text.Trim())))
                        {
                            mh4Bot = decimal.Round(decimal.Parse(((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxMH4BotFooter")).Text.Trim()), 2);
                        }
                    }

                    string comments = ((TextBox)grdFieldCureRecord.FooterRow.FindControl("tbxCommentsFooter")).Text.Trim();

                    int workId = Int32.Parse(hdfWorkId.Value);
                    int companyId = Int32.Parse(hdfCompanyId.Value);
                    bool inDatabase = false;
                    bool deleted = false;

                    FlInversionFieldCureRecord model = new FlInversionFieldCureRecord(flInversionFieldCureRecordTDS);
                    model.Insert(workId, readingTime, headFt, boilerInF, boilerOutF, pumpFlow, pumpPsi, mh1Top, mh1Bot, mh2Top, mh2Bot, mh3Top, mh3Bot, mh4Top, mh4Bot, comments, deleted, companyId, inDatabase);

                    Session.Remove("flInversionFieldCureRecordDummy");
                    Session["flInversionFieldCureRecordTDS"] = flInversionFieldCureRecordTDS;
                    Session["flInversionFieldCureRecord"] = flInversionFieldCureRecordTDS.InversionFieldCureRecord;

                    grdFieldCureRecord.DataBind();
                    grdFieldCureRecord.PageIndex = grdFieldCureRecord.PageCount - 1;
                }
            }
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
            FlInversionFieldCureRecord flInversionFieldCureRecordForSummary = new FlInversionFieldCureRecord(flInversionFieldCureRecordTDS);
            tbxSummary.Text = flInversionFieldCureRecordForSummary.GetSummary();
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
            // Set wizard title
            mWizard2 master = (mWizard2)this.Master;
            master.WizardTitle = "Field Cure Record Setup";
        }



        protected string GetRound(object value, int decimals)
        {
            if (value != DBNull.Value)
            {
                if (decimals == 3)
                {
                    return string.Format("{0:0.000}", Convert.ToDecimal(value));
                }
                else
                {
                    if (decimals == 2)
                    {
                        return string.Format("{0:0.00}", Convert.ToDecimal(value));
                    }
                    else
                    {
                        return string.Format("{0:0.0}", Convert.ToDecimal(value));
                    }
                }
            }
            else
            {
                return "";
            }
        }




        private void Save()
        {
            // save to database
            DB.Open();
            DB.BeginTransaction();
            try
            {
                string runDetails = hdfRunDetails.Value;
                int companyId = Int32.Parse(hdfCompanyId.Value);
                int projectId = Int32.Parse(hdfProjectId.Value);
                FlInversionFieldCureRecord model = new FlInversionFieldCureRecord(flInversionFieldCureRecordTDS);
                model.Save(companyId, runDetails, projectId);

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
