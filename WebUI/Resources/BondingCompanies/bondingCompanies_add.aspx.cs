using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.Server;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.BL.Resources.Common;
using LiquiForce.LFSLive.DA.RAF;
using LiquiForce.LFSLive.DA.Resources.BondingCompanies;
using LiquiForce.LFSLive.BL.Resources.BondingCompanies;
using LiquiForce.LFSLive.BL.LabourHours.ProjectTime;

namespace LiquiForce.LFSLive.WebUI.Resources.BondingCompanies
{
    /// <summary>
    /// bondingCompanies_add
    /// </summary>
    public partial class bondingCompanies_add : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected BondingCompaniesAddTDS bondingCompaniesAddTDS;






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
                if (!(Convert.ToBoolean(Session["sgLFS_RESOURCES_BONDINGCOMPANIES_ADD"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if ((string)Request.QueryString["source_page"] == null) 
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in bondingCompanies_add.aspx");
                }

                // Tag Page
                hdfCompanyId.Value = Convert.ToInt32(Session["companyID"]).ToString();
                hdfUpdate.Value = "no";

                // If coming from 
                // ... employee_navigator.aspx
                if (Request.QueryString["source_page"] == "lm")
                {
                    // ... Initialize tables
                    bondingCompaniesAddTDS = new BondingCompaniesAddTDS();

                    // ... Store tables
                    Session["bondingCompaniesAddTDS"] = bondingCompaniesAddTDS;
                }

                // StepSection1In
                wzTeamMember.ActiveStepIndex = 0;
                lblUserErrorMessage.Visible = false;
                StepBeginIn();
            }
            else
            {
                // Restore tables
                bondingCompaniesAddTDS = (BondingCompaniesAddTDS)Session["bondingCompaniesAddTDS"];                
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
                switch (wzTeamMember.ActiveStep.Name)
                {
                    case "Begin":
                        StepBeginIn();
                        break;                  

                    case "Summary":
                        StepSummaryIn();
                        break;                   

                    default:
                        throw new Exception("The option for " + wzTeamMember.ActiveStep.Name + " step in bondingCompanies_add.Wizard_ActiveStepChanged function does not exist");
                }
            }
        }



        protected void Wizard_NextButtonClick(object sender, WizardNavigationEventArgs e)
        {
            switch (wzTeamMember.ActiveStep.Name)
            {
                case "Begin":
                    e.Cancel = !StepBeginNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "Begin";
                    }
                    break;
              
                default:
                    throw new Exception("The option for " + wzTeamMember.ActiveStep.Name + " step in bondingCompanies_add.Wizard_NextButtonClick function does not exist");
            }
        }



        protected void Wizard_PreviousButtonClick(object sender, WizardNavigationEventArgs e)
        {
            switch (wzTeamMember.ActiveStep.Name)
            {                                
                case "Summary":
                    e.Cancel = !StepSummaryPrevious();
                    break;

                default:
                    throw new Exception("The option for " + wzTeamMember.ActiveStep.Name + " step in bondingCompanies_add.Wizard_PreviousButtonClick function does not exist");
            }
            if (!e.Cancel)
            {
                ViewState["StepFrom"] = wzTeamMember.ActiveStep.Name;
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
            hdfUpdate.Value = "no";
            Response.Write("<script language='javascript'> { window.close();}</script>");
        }

        #endregion






        #region STEP1 - BEGIN

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP1 - BEGIN
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP1 - BEGIN - AUXILIAR EVENTS
        //

        protected void ddlCompaniesFooter_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["selectedCompaniesId"] = ddlCompanies.SelectedValue;
            lblUserErrorMessage.Visible = false;
            lblUserErrorMessage.DataBind();
        }




        // ////////////////////////////////////////////////////////////////////////
        // STEP1 - BEGIN - METHODS
        //

        private void StepBeginIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Please select a Company";
        }



        private bool StepBeginNext()
        {
            int selectedCompaniesId = Int32.Parse(ddlCompanies.SelectedValue);
            int companyId = Int32.Parse(hdfCompanyId.Value);

            BondingCompaniesAddBondingCompaniesGateway bondingCompaniesAddBondingCompaniesGateway = new BondingCompaniesAddBondingCompaniesGateway();

            if (bondingCompaniesAddBondingCompaniesGateway.IsInLfs(selectedCompaniesId, companyId))
            {
                lblUserErrorMessage.Visible = true;
                return false;
            }
            else
            {
                lblUserErrorMessage.Visible = false;

                // Get name
                int companiesId = Int32.Parse(ddlCompanies.SelectedValue);                
                DateTime date = DateTime.Now;                          

                // Insert subcontractor
                CompaniesGatewayRAF companiesGatewayRAF = new CompaniesGatewayRAF();
                companiesGatewayRAF.LoadByCompaniesId(companiesId, companyId);

                hdfName.Value = companiesGatewayRAF.GetName(companiesId);                                
                
                BondingCompaniesAddBondingCompanies model = new BondingCompaniesAddBondingCompanies(bondingCompaniesAddTDS);
                model.Insert(companiesId, date, hdfName.Value, false, companyId);                

                // ... Store tables
                Session["bondingCompaniesAddTDS"] = bondingCompaniesAddTDS;
            }
            return true;
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
            hdfUpdate.Value = "yes";
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

                hdfStep.Value = "StepSummary";
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
            // Set wizard title
            Label title = (Label)this.Master.FindControl("lblTitle");
            title.Text = "Add Bonding Companies";
        }

        




        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        private void RegisterClientScripts()
        {
            // Register client-side events
            HtmlGenericControl body = (HtmlGenericControl)Page.Master.FindControl("myBody");
            body.Attributes.Add("onunload", "OnUnload();");

            // Register content variables
            string contentVariables = "";
            contentVariables += "var hdfUpdateId = '" + hdfUpdate.ClientID + "';";
            contentVariables += "var hdfStepId = '" + hdfStep.ClientID + "';";

            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./bondingCompanies_add.js");
        }



        private void UpdateDatabase()
        {
            DB.Open();
            DB.BeginTransaction();
            try
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);

                BondingCompaniesAddBondingCompanies bondingCompaniesAddBondingCompanies = new BondingCompaniesAddBondingCompanies(bondingCompaniesAddTDS);
                bondingCompaniesAddBondingCompanies.Save(companyId);
                
                DB.CommitTransaction();

                // Store datasets
                bondingCompaniesAddTDS.AcceptChanges();
                Session["bondingCompaniesAddTDS"] = bondingCompaniesAddTDS;

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
            string summary = "NEW BONDING COMPANY \n\n";
            summary = summary + "Name: " + hdfName.Value + "\n";            
            
            return summary;
        }




    }
}