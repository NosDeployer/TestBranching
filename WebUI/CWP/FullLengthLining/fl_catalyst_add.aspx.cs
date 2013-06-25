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
    /// fl_catalyst_add
    /// </summary>
    public partial class fl_catalyst_add : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //
        protected FlCatalystsAddTDS flCatalystsAddTDS;
        protected FlCatalystsAddTDS.FlCatalystsAddDataTable flCatalystsAdd;






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
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in fl_catalysts_add.aspx");
                }

                // Tag page
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfUpdate.Value = "no";

                Session.Remove("flCatalystsAdd");
                Session.Remove("flCatalystsAddDummy");

                // ... Store datasets
                flCatalystsAddTDS = new FlCatalystsAddTDS();
                Session["flCatalystsAddTDS"] = flCatalystsAddTDS;
                Session["flCatalystsAdd"] = flCatalystsAddTDS.FlCatalystsAdd;

                // StepSection1In
                wizard.ActiveStepIndex = 0;
                StepBeginIn();
            }
            else
            {
                // Restore datasets
                flCatalystsAddTDS = (FlCatalystsAddTDS)Session["flCatalystsAddTDS"];

                // Store
                Session["flCatalystsAdd"] = flCatalystsAddTDS.FlCatalystsAdd;
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
                        throw new Exception("The option for " + wizard.ActiveStep.Name + " step in fl_catalyst_add.Wizard_ActiveStepChanged function does not exist");
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
                    throw new Exception("The option for " + wizard.ActiveStep.Name + " step in fl_catalyst_add.Wizard_NextButtonClick function does not exist");
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

        protected void grdCatalysts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Add":
                    // Catalysts Gridview, if the gridview is edition mode
                    if (grdCatalysts.EditIndex >= 0)
                    {
                        grdCatalysts.UpdateRow(grdCatalysts.EditIndex, true);
                    }

                    // Add New Catalysts
                    GrdCatalystsAdd();
                    break;
            }
        }



        protected void grdCatalysts_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Catalysts Gridview, if the gridview is edition mode
            if (grdCatalysts.EditIndex >= 0)
            {
                grdCatalysts.UpdateRow(grdCatalysts.EditIndex, true);
            }

            //Delete catalysts
            int catalystId = (int)e.Keys["CatalystID"];
            int companyId = Int32.Parse(hdfCompanyId.Value);

            // Delete catalysts
            FlCatalystsAdd model = new FlCatalystsAdd(flCatalystsAddTDS);
            model.Delete(catalystId, companyId);

            // Store dataset
            Session["flCatalystsAddTDS"] = flCatalystsAddTDS;

            grdCatalysts.DataBind();
        }



        protected void grdCatalysts_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.Validate("dataEdit");
            if (Page.IsValid)
            {
                int catalystId = (int)e.Keys["CatalystID"];
                int companyId = Int32.Parse(hdfCompanyId.Value);

                string name = ((TextBox)grdCatalysts.Rows[e.RowIndex].Cells[1].FindControl("tbxNameEdit")).Text.Trim();

                decimal defaultPercentageByWeight = -1;
                if (((TextBox)grdCatalysts.Rows[e.RowIndex].Cells[2].FindControl("tbxDefaultPercentageByWeightEdit")).Text.Trim() != "")
                {
                    if ((Validator.IsValidDecimal(((TextBox)grdCatalysts.Rows[e.RowIndex].Cells[2].FindControl("tbxDefaultPercentageByWeightEdit")).Text.Trim())))
                    {
                        defaultPercentageByWeight = decimal.Round(decimal.Parse(((TextBox)grdCatalysts.Rows[e.RowIndex].Cells[2].FindControl("tbxDefaultPercentageByWeightEdit")).Text.Trim()), 3);
                    }
                }

                FlCatalystsAdd model = new FlCatalystsAdd(flCatalystsAddTDS);
                model.Update(catalystId, name, defaultPercentageByWeight);

                // Store dataset
                Session["flCatalystsAddTDS"] = flCatalystsAddTDS;
                Session["flatSectionJlCommentDetails"] = flCatalystsAddTDS.FlCatalystsAdd;
            }
            else
            {
                e.Cancel = true;
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP1 - BEGIN - AUXILIAR EVENTS
        //



        protected void grdCatalysts_DataBound(object sender, EventArgs e)
        {
            AddCatalystsNewEmptyFix(grdCatalysts);
        }



        protected void grdCatalysts_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Catalysts Gridview, if the gridview is edition mode
            if (grdCatalysts.EditIndex >= 0)
            {
                grdCatalysts.UpdateRow(grdCatalysts.EditIndex, true);
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP1 - BEGIN - METHODS
        //

        private void StepBeginIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Please provide catalysts information";

            // Load
            FlCatalystsAdd model = new FlCatalystsAdd(flCatalystsAddTDS);
            model.LoadAll(Int32.Parse(hdfCompanyId.Value));

            // Store tables
            Session["flCatalystsAdd"] = flCatalystsAddTDS.FlCatalystsAdd;
            Session["flCatalystsAddTDS"] = flCatalystsAddTDS;
        }



        private bool StepBeginNext()
        {
            Page.Validate("Begin");

            if (Page.IsValid)
            {
                // Gridview, if the gridview is edition mode
                if (grdCatalysts.EditIndex >= 0)
                {
                    grdCatalysts.UpdateRow(grdCatalysts.EditIndex, true);
                    grdCatalysts.DataBind();
                }

                // Add if exists at footer
                if (ValidateCatalystsFooter())
                {
                    GrdCatalystsAdd();
                }

                // Store tables
                Session["flCatalystsAdd"] = flCatalystsAddTDS.FlCatalystsAdd;
                Session["flCatalystsAddTDS"] = flCatalystsAddTDS;
                return true;
            }
            else
            {
                return false;
            }
        }



        public FlCatalystsAddTDS.FlCatalystsAddDataTable GetCatalystsNew()
        {
            flCatalystsAdd = (FlCatalystsAddTDS.FlCatalystsAddDataTable)Session["flCatalystsAddDummy"];

            if (flCatalystsAdd == null)
            {
                flCatalystsAdd = ((FlCatalystsAddTDS.FlCatalystsAddDataTable)Session["flCatalystsAdd"]);
            }

            return flCatalystsAdd;
        }



        public void DummyCatalystsNew(int CatalystID)
        {
        }



        private bool ValidateCatalystsFooter()
        {
            string nameFooter = ((TextBox)grdCatalysts.FooterRow.FindControl("tbxNameFooter")).Text.Trim();

            decimal defaultPercentageByWeightFooter = -1;
            if (((TextBox)grdCatalysts.FooterRow.FindControl("tbxDefaultPercentageByWeightFooter")).Text.Trim() != "")
            {
                if ((Validator.IsValidDecimal(((TextBox)grdCatalysts.FooterRow.FindControl("tbxDefaultPercentageByWeightFooter")).Text.Trim())))
                {
                    defaultPercentageByWeightFooter = decimal.Parse(((TextBox)grdCatalysts.FooterRow.FindControl("tbxDefaultPercentageByWeightFooter")).Text.Trim());
                }
            }

            if ((nameFooter != "") || (defaultPercentageByWeightFooter != -1))
            {
                return true;
            }

            return false;
        }



        protected void AddCatalystsNewEmptyFix(GridView grdCatalysts)
        {
            if (grdCatalysts.Rows.Count == 0)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                FlCatalystsAddTDS.FlCatalystsAddDataTable dt = new FlCatalystsAddTDS.FlCatalystsAddDataTable();
                dt.AddFlCatalystsAddRow(-1, "", -1, false, companyId, false);
                Session["flCatalystsAddDummy"] = dt;

                grdCatalysts.DataBind();
            }

            // Normally executes at all postbacks
            if (grdCatalysts.Rows.Count == 1)
            {
                FlCatalystsAddTDS.FlCatalystsAddDataTable dt = (FlCatalystsAddTDS.FlCatalystsAddDataTable)Session["flCatalystsAddDummy"];
                if (dt != null)
                {
                    grdCatalysts.Rows[0].Visible = false;
                    grdCatalysts.Rows[0].Controls.Clear();
                }
            }
        }



        private void GrdCatalystsAdd()
        {
            if (ValidateCatalystsFooter())
            {
                Page.Validate("dataFooter");
                if (Page.IsValid)
                {
                    string name = ((TextBox)grdCatalysts.FooterRow.FindControl("tbxNameFooter")).Text.Trim();
                    decimal defaultPercentageByWeight = -1;
                    if (((TextBox)grdCatalysts.FooterRow.FindControl("tbxDefaultPercentageByWeightFooter")).Text.Trim() != "")
                    {
                        if ((Validator.IsValidDecimal(((TextBox)grdCatalysts.FooterRow.FindControl("tbxDefaultPercentageByWeightFooter")).Text.Trim())))
                        {
                            defaultPercentageByWeight = decimal.Round(decimal.Parse(((TextBox)grdCatalysts.FooterRow.FindControl("tbxDefaultPercentageByWeightFooter")).Text.Trim()), 2);
                        }
                    }

                    int companyId = Int32.Parse(hdfCompanyId.Value);
                    bool inDatabase = false;
                    bool deleted = false;

                    FlCatalystsAdd model = new FlCatalystsAdd(flCatalystsAddTDS);
                    model.Insert(name, defaultPercentageByWeight,deleted, companyId, inDatabase);

                    Session.Remove("flCatalystsAddDummy");
                    Session["flCatalystsAddTDS"] = flCatalystsAddTDS;
                    Session["flCatalystsAdd"] = flCatalystsAddTDS.FlCatalystsAdd;

                    grdCatalysts.DataBind();
                    grdCatalysts.PageIndex = grdCatalysts.PageCount - 1;
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
            FlCatalystsAdd flCatalystsAddForSummary = new FlCatalystsAdd(flCatalystsAddTDS);
            tbxSummary.Text = flCatalystsAddForSummary.GetSummary();
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
            master.WizardTitle = "Catalysts Setup";
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
                FlCatalystsAdd model = new FlCatalystsAdd(flCatalystsAddTDS);
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
