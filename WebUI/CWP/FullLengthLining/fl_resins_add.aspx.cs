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
    /// fl_resins_add
    /// </summary>
    public partial class fl_resins_add : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //
        protected FlResinsAddTDS flResinsAddTDS;
        protected FlResinsAddTDS.FlResinsAddDataTable flResinsAdd;





        
        // ////////////////////////////////////////////////////////////////////////
        // EVENTS
        //
        protected void Page_Load(object sender, EventArgs e)
        {           
            if (!IsPostBack)
            {
                // Security check
                if (!(Convert.ToBoolean(Session["sgLFS_CWP_FULLLENGTHLINING_ADMIN"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in fl_resins_add.aspx");
                }

                // Tag page
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfUpdate.Value = "no";

                Session.Remove("flResinsAdd");
                Session.Remove("flResinsAddDummy");

                // ... Store datasets
                flResinsAddTDS = new FlResinsAddTDS();
                Session["flResinsAddTDS"] = flResinsAddTDS;
                Session["flResinsAdd"] = flResinsAddTDS.FlResinsAdd;

                // StepSection1In
                wizard.ActiveStepIndex = 0;
                StepBeginIn();
            }
            else
            {
                // Restore datasets
                flResinsAddTDS = (FlResinsAddTDS)Session["flResinsAddTDS"];

                // Store
                Session["flResinsAdd"] = flResinsAddTDS.FlResinsAdd;
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
                        throw new Exception("The option for " + wizard.ActiveStep.Name + " step in fl_resins_add.Wizard_ActiveStepChanged function does not exist");
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
                    throw new Exception("The option for " + wizard.ActiveStep.Name + " step in fl_resins_add.Wizard_NextButtonClick function does not exist");
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

        protected void grdResins_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Add":
                    // Resins Gridview, if the gridview is edition mode
                    if (grdResins.EditIndex >= 0)
                    {
                        grdResins.UpdateRow(grdResins.EditIndex, true);
                    }

                    // Add New Comment
                    GrdResinsAdd();
                    break;
            }
        }



        protected void grdResins_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Resins Gridview, if the gridview is edition mode
            if (grdResins.EditIndex >= 0)
            {
                grdResins.UpdateRow(grdResins.EditIndex, true);
            }

             //Delete resins
            int resinId = (int)e.Keys["ResinID"];
            int companyId = Int32.Parse(hdfCompanyId.Value);

            // Delete resins
            FlResinsAdd model = new FlResinsAdd(flResinsAddTDS);
            model.Delete(resinId, companyId);

            // Store dataset
            Session["flResinsAddTDS"] = flResinsAddTDS;

            grdResins.DataBind();
        }



        protected void grdResins_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.Validate("dataEdit");
            if (Page.IsValid)
            {
                int resinId = (int)e.Keys["ResinID"];
                int companyId = Int32.Parse(hdfCompanyId.Value);

                string resinMake = ((TextBox)grdResins.Rows[e.RowIndex].Cells[1].FindControl("tbxResinMakeEdit")).Text.Trim();
                string resinType = ((TextBox)grdResins.Rows[e.RowIndex].Cells[2].FindControl("tbxResinTypeEdit")).Text.Trim();
                string resinNumber = ((TextBox)grdResins.Rows[e.RowIndex].Cells[3].FindControl("tbxResinNumberEdit")).Text.Trim();
                string applyCatalystTo = ((DropDownList)grdResins.Rows[e.RowIndex].Cells[7].FindControl("ddlApplyCatalystToEdit")).SelectedValue;

                decimal lbUsg = -1;
                if (((TextBox)grdResins.Rows[e.RowIndex].Cells[4].FindControl("tbxLbUsgEdit")).Text.Trim() != "")
                {
                    if ((Validator.IsValidDecimal(((TextBox)grdResins.Rows[e.RowIndex].Cells[4].FindControl("tbxLbUsgEdit")).Text.Trim())))
                    {
                        lbUsg = decimal.Round(decimal.Parse(((TextBox)grdResins.Rows[e.RowIndex].Cells[4].FindControl("tbxLbUsgEdit")).Text.Trim()), 3);
                    }
                }

                int lbDrums = -1;
                if (((TextBox)grdResins.Rows[e.RowIndex].Cells[4].FindControl("tbxLbDrumsEdit")).Text.Trim() != "")
                {
                    if ((Validator.IsValidDecimal(((TextBox)grdResins.Rows[e.RowIndex].Cells[5].FindControl("tbxLbDrumsEdit")).Text.Trim())))
                    {
                        lbDrums = Int32.Parse(((TextBox)grdResins.Rows[e.RowIndex].Cells[5].FindControl("tbxLbDrumsEdit")).Text.Trim());
                    }
                }

                decimal activeResin = -1;
                if (((TextBox)grdResins.Rows[e.RowIndex].Cells[4].FindControl("tbxActiveResinEdit")).Text.Trim() != "")
                {
                    if ((Validator.IsValidDecimal(((TextBox)grdResins.Rows[e.RowIndex].Cells[6].FindControl("tbxActiveResinEdit")).Text.Trim())))
                    {
                        activeResin = decimal.Round(decimal.Parse(((TextBox)grdResins.Rows[e.RowIndex].Cells[6].FindControl("tbxActiveResinEdit")).Text.Trim()), 1);
                    }
                }

                decimal filter = -1;
                if (((TextBox)grdResins.Rows[e.RowIndex].Cells[4].FindControl("tbxFilterEdit")).Text.Trim() != "")
                {
                    if ((Validator.IsValidDecimal(((TextBox)grdResins.Rows[e.RowIndex].Cells[8].FindControl("tbxFilterEdit")).Text.Trim())))
                    {
                        filter = decimal.Round(decimal.Parse(((TextBox)grdResins.Rows[e.RowIndex].Cells[8].FindControl("tbxFilterEdit")).Text.Trim()), 1);
                    }
                }

                FlResinsAdd model = new FlResinsAdd(flResinsAddTDS);
                model.Update(resinId, resinMake, resinType, resinNumber, lbUsg, lbDrums, activeResin, applyCatalystTo, filter);

                // Store dataset
                Session["flResinsAddTDS"] = flResinsAddTDS;
                Session["flatSectionJlCommentDetails"] = flResinsAddTDS.FlResinsAdd;
            }
            else
            {
                e.Cancel = true;
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP1 - BEGIN - AUXILIAR EVENTS
        //



        protected void grdResins_DataBound(object sender, EventArgs e)
        {
            AddResinsNewEmptyFix(grdResins);
        }



        protected void grdResins_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Normal controls
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Normal) || (e.Row.RowState == (DataControlRowState.Normal | DataControlRowState.Alternate))))
            {
                int resinId = Int32.Parse(((Label)e.Row.FindControl("lblResinId")).Text);
                
                // Validate buttons
                if ((resinId == 1) || (resinId == 2) || (resinId == 3))
                {
                    ((ImageButton)e.Row.FindControl("ibtnEdit")).Visible = false;
                    ((ImageButton)e.Row.FindControl("ibtnDelete")).Visible = false;
                }
            }

            // Edit controls
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Edit) || (e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                int resinId = Int32.Parse(((Label)e.Row.FindControl("lblResinIdEdit")).Text);

                FlResinsAddGateway flResinsAddGatewayForGrid = new FlResinsAddGateway(flResinsAddTDS);

                if (flResinsAddGatewayForGrid.Table.Rows.Count > 0)
                {
                    string applyCatalyst = flResinsAddGatewayForGrid.GetApplyCatalystTo(resinId);
                    ((DropDownList)e.Row.FindControl("ddlApplyCatalystToEdit")).SelectedValue = applyCatalyst;
                }
            }
        }



        protected void grdResins_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Resins Gridview, if the gridview is edition mode
            if (grdResins.EditIndex >= 0)
            {
                grdResins.UpdateRow(grdResins.EditIndex, true);
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP1 - BEGIN - METHODS
        //

        private void StepBeginIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Please provide resins information. Resin numbers 1 - 3 are pre-set";

            // Load
            FlResinsAdd model = new FlResinsAdd(flResinsAddTDS);
            model.LoadAll(Int32.Parse(hdfCompanyId.Value));

            // Store tables
            Session["flResinsAdd"] = flResinsAddTDS.FlResinsAdd;
            Session["flResinsAddTDS"] = flResinsAddTDS;
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



        public FlResinsAddTDS.FlResinsAddDataTable GetResinsNew()
        {
            flResinsAdd = (FlResinsAddTDS.FlResinsAddDataTable)Session["flResinsAddDummy"];

            if (flResinsAdd == null)
            {
                flResinsAdd = ((FlResinsAddTDS.FlResinsAddDataTable)Session["flResinsAdd"]);
            }

            return flResinsAdd;
        }



        public void DummyResinsNew(int ResinID)
        {
        }



        private bool ValidateResinsFooter()
        {
            string resinMakeFooter = ((TextBox)grdResins.FooterRow.FindControl("tbxResinMakeFooter")).Text.Trim();
            string resinTypeFooter = ((TextBox)grdResins.FooterRow.FindControl("tbxResinTypeFooter")).Text.Trim();
            string resinNumberFooter = ((TextBox)grdResins.FooterRow.FindControl("tbxResinNumberFooter")).Text.Trim();
            string applyCatalystToFooter = ((DropDownList)grdResins.FooterRow.FindControl("ddlApplyCatalystToFooter")).SelectedValue;

            decimal lbUsgFooter = -1;
            if (((TextBox)grdResins.FooterRow.FindControl("tbxLbUsgFooter")).Text.Trim() != "") 
            {
                if ((Validator.IsValidDecimal(((TextBox)grdResins.FooterRow.FindControl("tbxLbUsgFooter")).Text.Trim())))
                {
                    lbUsgFooter = decimal.Parse(((TextBox)grdResins.FooterRow.FindControl("tbxLbUsgFooter")).Text.Trim());
                }
            }

            int lbDrumsFooter = -1;
            if (((TextBox)grdResins.FooterRow.FindControl("tbxLbDrumsFooter")).Text.Trim() != "")
            {
                if ((Validator.IsValidDecimal(((TextBox)grdResins.FooterRow.FindControl("tbxLbDrumsFooter")).Text.Trim())))
                {
                    lbDrumsFooter = Int32.Parse(((TextBox)grdResins.FooterRow.FindControl("tbxLbDrumsFooter")).Text.Trim());
                }
            }

            decimal activeResinFooter = -1;
            if (((TextBox)grdResins.FooterRow.FindControl("tbxActiveResinFooter")).Text.Trim() != "")
            {
                if ((Validator.IsValidDecimal(((TextBox)grdResins.FooterRow.FindControl("tbxActiveResinFooter")).Text.Trim())))
                {
                    activeResinFooter = decimal.Parse(((TextBox)grdResins.FooterRow.FindControl("tbxActiveResinFooter")).Text.Trim());
                }
            }

            decimal filterFooter = -1;
            if (((TextBox)grdResins.FooterRow.FindControl("tbxFilterFooter")).Text.Trim() != "")
            {
                if ((Validator.IsValidDecimal(((TextBox)grdResins.FooterRow.FindControl("tbxFilterFooter")).Text.Trim())))
                {
                    filterFooter = decimal.Parse(((TextBox)grdResins.FooterRow.FindControl("tbxFilterFooter")).Text.Trim());
                }
            }

            if ((resinMakeFooter != "") || (resinTypeFooter != "") || (resinNumberFooter != "") || (lbUsgFooter != -1) || (lbDrumsFooter != -1) || (activeResinFooter != -1) || (applyCatalystToFooter != "(Select)") || (filterFooter != -1))
            {
                return true;
            }

            return false;
        }



        protected void AddResinsNewEmptyFix(GridView grdResins)
        {
            if (grdResins.Rows.Count == 0)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                FlResinsAddTDS.FlResinsAddDataTable dt = new FlResinsAddTDS.FlResinsAddDataTable();
                dt.AddFlResinsAddRow(-1, "", "", "", -1, -1, -1, "", -1, false, companyId, false);
                Session["flResinsAddDummy"] = dt;

                grdResins.DataBind();
            }

            // Normally executes at all postbacks
            if (grdResins.Rows.Count == 1)
            {
                FlResinsAddTDS.FlResinsAddDataTable dt = (FlResinsAddTDS.FlResinsAddDataTable)Session["flResinsAddDummy"];
                if (dt != null)
                {
                    grdResins.Rows[0].Visible = false;
                    grdResins.Rows[0].Controls.Clear();
                }
            }
        }



        private void GrdResinsAdd()
        {
            if (ValidateResinsFooter())
            {
                Page.Validate("dataFooter");
                if (Page.IsValid)
                {
                    string resinMake = ((TextBox)grdResins.FooterRow.FindControl("tbxResinMakeFooter")).Text.Trim();
                    string resinType = ((TextBox)grdResins.FooterRow.FindControl("tbxResinTypeFooter")).Text.Trim();
                    string resinNumber = ((TextBox)grdResins.FooterRow.FindControl("tbxResinNumberFooter")).Text.Trim();
                    string applyCatalystTo = ((DropDownList)grdResins.FooterRow.FindControl("ddlApplyCatalystToFooter")).SelectedValue;

                    decimal lbUsg = -1;
                    if (((TextBox)grdResins.FooterRow.FindControl("tbxLbUsgFooter")).Text.Trim() != "")
                    {
                        if ((Validator.IsValidDecimal(((TextBox)grdResins.FooterRow.FindControl("tbxLbUsgFooter")).Text.Trim())))
                        {
                            lbUsg = decimal.Round(decimal.Parse(((TextBox)grdResins.FooterRow.FindControl("tbxLbUsgFooter")).Text.Trim()),3);                                              
                        }
                    }

                    int lbDrums = -1;
                    if (((TextBox)grdResins.FooterRow.FindControl("tbxLbDrumsFooter")).Text.Trim() != "")
                    {
                        if ((Validator.IsValidDecimal(((TextBox)grdResins.FooterRow.FindControl("tbxLbDrumsFooter")).Text.Trim())))
                        {
                            lbDrums = Int32.Parse(((TextBox)grdResins.FooterRow.FindControl("tbxLbDrumsFooter")).Text.Trim());
                        }
                    }

                    decimal activeResin = -1;
                    if (((TextBox)grdResins.FooterRow.FindControl("tbxActiveResinFooter")).Text.Trim() != "")
                    {
                        if ((Validator.IsValidDecimal(((TextBox)grdResins.FooterRow.FindControl("tbxActiveResinFooter")).Text.Trim())))
                        {
                            activeResin = decimal.Round(decimal.Parse(((TextBox)grdResins.FooterRow.FindControl("tbxActiveResinFooter")).Text.Trim()),1);
                        }
                    }

                    decimal filter = -1;
                    if (((TextBox)grdResins.FooterRow.FindControl("tbxFilterFooter")).Text.Trim() != "")
                    {
                        if ((Validator.IsValidDecimal(((TextBox)grdResins.FooterRow.FindControl("tbxFilterFooter")).Text.Trim())))
                        {
                            filter = decimal.Round(decimal.Parse(((TextBox)grdResins.FooterRow.FindControl("tbxFilterFooter")).Text.Trim()),1);
                        }
                    }

                    int companyId = Int32.Parse(hdfCompanyId.Value);
                    bool inDatabase = false;
                    bool deleted = false;

                    FlResinsAdd model = new FlResinsAdd(flResinsAddTDS);
                    model.Insert(resinMake, resinType, resinNumber, lbUsg, lbDrums, activeResin, applyCatalystTo, filter, deleted, companyId, inDatabase);

                    Session.Remove("flResinsAddDummy");
                    Session["flResinsAddTDS"] = flResinsAddTDS;
                    Session["flResinsAdd"] = flResinsAddTDS.FlResinsAdd;

                    grdResins.DataBind();
                    grdResins.PageIndex = grdResins.PageCount - 1;
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
            FlResinsAdd flResinsAddForSummary = new FlResinsAdd(flResinsAddTDS);
            tbxSummary.Text = flResinsAddForSummary.GetSummary();
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
            master.WizardTitle = "Resins Setup";
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
                FlResinsAdd model = new FlResinsAdd(flResinsAddTDS);
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