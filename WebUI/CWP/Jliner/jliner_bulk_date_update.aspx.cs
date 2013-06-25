using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.DA.CWP.Jliner;
using LiquiForce.LFSLive.DA.CWP.Section;
using LiquiForce.LFSLive.BL.CWP.Jliner;
using LiquiForce.LFSLive.BL.CWP.Section;

namespace LiquiForce.LFSLive.WebUI.CWP.Jliner
{
    /// <summary>
    /// jliner_bulk_date_update
    /// </summary>
    public partial class jliner_bulk_date_update : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected FlatSectionJlinerTDS flatSectionJlinerTDS;
        protected SectionTDS sectionTDS;






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
                if (!(Convert.ToBoolean(Session["sgLFS_APP_VIEW"]) && Convert.ToBoolean(Session["sgLFS_APP_EDIT"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["client"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in jliner_bulk_date_update.aspx");
                }

                // Tag page
                hdfCurrentClient.Value = (string)Request.QueryString["client"];
                hdfUpdate.Value = "no";
                ViewState["StepFrom"] = "Out";

                StepBeginIn();
                
                // Restore datasets
                flatSectionJlinerTDS = (FlatSectionJlinerTDS)Session["flatSectionJlinerTDS"];
            }
            else
            {
                // Restore datasets
                flatSectionJlinerTDS = (FlatSectionJlinerTDS)Session["flatSectionJlinerTDS"];                
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
            //UpdateDatabase();
            hdfUpdate.Value = "yes";
            Response.Write("<script language='javascript'> { window.close();}</script>");                        
        }



        protected void Wizard_CancelButtonClick(object sender, EventArgs e)
        {
            flatSectionJlinerTDS.RejectChanges();
            Response.Write("<script language='javascript'> { window.close();}</script>");
        }

        #endregion

        




        #region STEP1 - BEGIN

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // STEP1 - BEGIN
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP1 - BEGIN - METHODS
        //

        private void StepBeginIn()
        {
            // Set instruction
            mWizard2 master = (mWizard2)this.Master;
            master.WizardInstruction = "This tool will update several date fields at once";
            
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
            mWizard2 master = (mWizard2)this.Master;
            master.WizardInstruction = "Summary";

            hdfStep.Value = "Finish";
        }



        private bool StepFinishPrevious()
        {
            return true;
        }



        private bool StepFinishNext()
        {
            if (Page.IsValid)
            {
                hdfUpdate.Value = "yes";
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
            // Set title
            mWizard2 master = (mWizard2)this.Master;
            master.WizardTitle = "Bulk Date Update";
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
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./jliner_bulk_date_update.js");
        }


        
        private void Save()
        {
            FlatSectionJliner flatSectionJliner = new FlatSectionJliner(flatSectionJlinerTDS);
            DataView dataViewFlatSectionJliner = new DataView(flatSectionJlinerTDS.FlatSectionJliner);
            dataViewFlatSectionJliner.RowFilter = "(Selected = 1) AND (Deleted = 0)";
            string summary = "";
            bool existsDataModificated = false;

            foreach (DataRowView row in dataViewFlatSectionJliner)
            {
                if (row["Issue"].ToString() == "No" || row["Issue"].ToString() == "Dig Required After Lining")
                {
                    string id_ = row["ID_"].ToString();
                    DateTime? value = null; if (tbxDate.Text.ToString() != "") value = DateTime.Parse(tbxDate.Text);

                    // ... Update row
                    flatSectionJliner.UpdateField(id_, ddlFieldToUpdate.SelectedValue, value);

                    existsDataModificated = true;
                }
                else
                {
                    if (summary.Trim().Length == 0)
                    {
                        summary = "The following laterals were not updated:\n\n";
                        summary = summary + "\t - " + row["ID_"].ToString() + "\n";
                    }
                    else
                    {
                        summary = summary + "\t - " + row["ID_"].ToString() + "\n";
                    }
                }
            }

            if (summary.Trim().Length == 0)
            {
                summary = "All the laterals were updated\n\n";
            }

            tbxSummary.Text = summary;
            
            // Store datasets
            Session["flatSectionJlinerTDS"] = flatSectionJlinerTDS;

            if (existsDataModificated)
            {
                // Update section and jliners
                sectionTDS = new SectionTDS();
                flatSectionJliner.Save(sectionTDS);

                // Update database
                UpdateDatabase();
            }
        }



        private void UpdateDatabase()
        {
            try
            {
                SectionGateway sectionGateway = new SectionGateway(sectionTDS);
                sectionGateway.Update();

                sectionTDS.AcceptChanges();
                flatSectionJlinerTDS.AcceptChanges();
                Session["flatSectionJlinerTDS"] = flatSectionJlinerTDS;

                // Update IssueWithLaterals field
                Section section = new Section(sectionTDS);
                section.UpdateIssueWithLaterals();
                sectionGateway.Update2();
                sectionTDS.AcceptChanges();
            }
            catch (Exception ex)
            {
                string url = string.Format("./../../error_page.aspx?error={0}", ex.Message.Replace('\n', ' '));
                Response.Redirect(url);
            }
        }



    }
}