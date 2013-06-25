using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.Server;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.Tools;
using LiquiForce.LFSLive.BL.Resources.Employees;
using LiquiForce.LFSLive.DA.Resources.Employees;

namespace LiquiForce.LFSLive.WebUI.Resources.Employees
{
    /// <summary>
    /// employees_costing_setup
    /// </summary>
    public partial class employees_costing_setup : System.Web.UI.Page
    {

        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected EmployeeStandardCostsSetupTDS.StandardCostsSetupDataTable standardCostsSetup;






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
                if (!(Convert.ToBoolean(Session["sgLFS_RESOURCES_EMPLOYEES_ADMIN"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if ((string)Request.QueryString["source_page"] == null)
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in employees_costing_setup.aspx");
                }

                // Tag page
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfUpdate.Value = "no";

                Session.Remove("standardCostsSetup");
                Session.Remove("standardCostsSetupDummy");

                // Prepare initial data
                // ... For Grids
                standardCostsSetup = new EmployeeStandardCostsSetupTDS.StandardCostsSetupDataTable();

                // ... Store datasets
                Session["standardCostsSetup"] = standardCostsSetup;

                // StepSection1In
                wizard.ActiveStepIndex = 0;
                StepBeginIn();
            }
            else
            {
                // Restore datasets
                standardCostsSetup = (EmployeeStandardCostsSetupTDS.StandardCostsSetupDataTable)Session["standardCostsSetup"];            
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
                        throw new Exception("The option for " + wizard.ActiveStep.Name + " step in employees_costing_setup.Wizard_ActiveStepChanged function does not exist");
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
                    throw new Exception("The option for " + wizard.ActiveStep.Name + " step in employees_costing_setup.Wizard_NextButtonClick function does not exist");
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
        // STEP1 - BEGIN - METHODS
        //

        private void StepBeginIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Please provide job costing factors for each employee";

            // Initiaize data
            standardCostsSetup = new EmployeeStandardCostsSetupTDS.StandardCostsSetupDataTable();

            // Load
            EmployeeStandardCostsSetupTDS dataSet = new EmployeeStandardCostsSetupTDS();
            EmployeeStandardCostsSetup model = new EmployeeStandardCostsSetup(dataSet);

            model.LoadAll();

            // Store tables
            standardCostsSetup = (EmployeeStandardCostsSetupTDS.StandardCostsSetupDataTable)model.Table;
            Session["standardCostsSetup"] = standardCostsSetup;
        }



        private bool StepBeginNext()
        {
            Page.Validate("Begin");

            if (Page.IsValid)
            {
                StepBeginProcessGrid();

                return true;
            }
            else
            {
                return false;
            }
        }



        private void StepBeginProcessGrid()
        {
            if (ExistsDataModified())
            {
                EmployeeStandardCostsSetupTDS dataSet = new EmployeeStandardCostsSetupTDS();
                dataSet.StandardCostsSetup.Merge(standardCostsSetup, true);
                EmployeeStandardCostsSetup model = new EmployeeStandardCostsSetup(dataSet);

                // update rows
                foreach (GridViewRow row in grdCostSetup.Rows)
                {
                    int employeeId = Int32.Parse(grdCostSetup.DataKeys[row.RowIndex].Values["EmployeeID"].ToString());
                    
                    decimal? newBurdenFactor = null;
                    if (((TextBox)row.FindControl("tbxBourdenFactor")).Text != "")
                    {
                        newBurdenFactor = decimal.Round(decimal.Parse(((TextBox)row.FindControl("tbxBourdenFactor")).Text),1);
                    }

                    decimal? newUSHealthBenefitFactor = null;
                    if (((TextBox)row.FindControl("tbxUSHealthBenefitFactor")).Text != "")
                    {
                        newUSHealthBenefitFactor = decimal.Round(decimal.Parse(((TextBox)row.FindControl("tbxUSHealthBenefitFactor")).Text), 1);
                    }

                    decimal? newBenefitFactorCad = null;
                    if (((TextBox)row.FindControl("tbxBenefitFactorCad")).Text != "")
                    {
                        newBenefitFactorCad = decimal.Round(decimal.Parse(((TextBox)row.FindControl("tbxBenefitFactorCad")).Text), 2);
                    }

                    decimal? newBenefitFactorUsd = null;
                    if (((TextBox)row.FindControl("tbxBenefitFactorUsd")).Text != "")
                    {
                        newBenefitFactorUsd = decimal.Round(decimal.Parse(((TextBox)row.FindControl("tbxBenefitFactorUsd")).Text),2);
                    }

                    model.Update(employeeId, newBurdenFactor, newUSHealthBenefitFactor, newBenefitFactorCad, newBenefitFactorUsd);
                }

                standardCostsSetup = (EmployeeStandardCostsSetupTDS.StandardCostsSetupDataTable)model.Table;
                Session["standardCostsSetup"] = standardCostsSetup;

                hdfUpdate.Value = "yes";
            }
        }



        private bool ExistsDataModified()
        {
            foreach (GridViewRow row in grdCostSetup.Rows)
            {
                try
                {
                    EmployeeStandardCostsSetupTDS dataSet = new EmployeeStandardCostsSetupTDS();
                    dataSet.StandardCostsSetup.Merge(standardCostsSetup, true);
                    EmployeeStandardCostsSetupGateway model = new EmployeeStandardCostsSetupGateway(dataSet);

                    // Getting general information
                    int employeeId = Int32.Parse(grdCostSetup.DataKeys[row.RowIndex].Values["EmployeeID"].ToString());

                    // Verify BurdenRate
                    decimal? newBurdenFactor = decimal.Parse(((TextBox)row.FindControl("tbxBourdenFactor")).Text);
                    decimal? originalBurdenFactor = model.GetBourdenFactorOriginal(employeeId);

                    if (newBurdenFactor != originalBurdenFactor)
                    {
                        return true;
                    }
                    else
                    {
                        // Verify USHealthBenefitFactor
                        decimal newUSHealthBenefitFactor = decimal.Parse(((TextBox)row.FindControl("tbxUSHealthBenefitFactor")).Text);
                        decimal? originalUSHealthBenefitFactor = model.GetUSHealthBenefitFactorOriginal(employeeId);

                        if (newUSHealthBenefitFactor != originalUSHealthBenefitFactor)
                        {
                            return true;
                        }
                        else
                        {
                            // Verify BenefitFactorCad
                            decimal newBenefitFactorCad = decimal.Parse(((TextBox)row.FindControl("tbxBenefitFactorCad")).Text);
                            decimal? originalBenefitFactorCad = model.GetBenefitFactorCadOriginal(employeeId);

                            if (newBenefitFactorCad != originalBenefitFactorCad)
                            {
                                return true;
                            }
                            else
                            {
                                // Verify BenefitFactorUsd
                                decimal newBenefitFactorUsd = decimal.Parse(((TextBox)row.FindControl("tbxBenefitFactorUsd")).Text);
                                decimal? originalBenefitFactorUsd = model.GetBenefitFactorUsdOriginal(employeeId);

                                if (newBenefitFactorUsd != originalBenefitFactorUsd)
                                {
                                    return true;
                                }
                            }
                        }
                    }

                }
                catch
                {
                    return true;
                }
            }

            return false;
        }



        public EmployeeStandardCostsSetupTDS.StandardCostsSetupDataTable GetCostsSetupNew()
        {
            standardCostsSetup = (EmployeeStandardCostsSetupTDS.StandardCostsSetupDataTable)Session["standardCostsSetupDummy"];

            if (standardCostsSetup == null)
            {
                standardCostsSetup = ((EmployeeStandardCostsSetupTDS.StandardCostsSetupDataTable)Session["standardCostsSetup"]);
            }

            return standardCostsSetup;
        }



        public void DummyCatalystsNew(int CatalystID)
        {
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
            EmployeeStandardCostsSetupTDS dataSet = new EmployeeStandardCostsSetupTDS();
            dataSet.StandardCostsSetup.Merge(standardCostsSetup, true);
            EmployeeStandardCostsSetup model = new EmployeeStandardCostsSetup(dataSet);

            tbxSummary.Text = model.GetSummary();
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
            master.WizardTitle = "Job Costing Factors";
        }



        private void RegisterClientScripts()
        {
            // Register client-side events
            HtmlGenericControl body = (HtmlGenericControl)Page.Master.FindControl("myBody");
            body.Attributes.Add("onunload", "OnUnload();");

            // Register content variables
            string contentVariables = "";
            contentVariables += "var hdfUpdateId = '" + hdfUpdate.ClientID + "';";

            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./employees_costing_setup.js");
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
            // process sections
            EmployeeStandardCostsSetupTDS dataSet = new EmployeeStandardCostsSetupTDS();
            dataSet.StandardCostsSetup.Merge(standardCostsSetup, true);
            EmployeeStandardCostsSetup model = new EmployeeStandardCostsSetup(dataSet);

            // save to database
            DB.Open();
            DB.BeginTransaction();
            try
            {
                model.Save(int.Parse(hdfCompanyId.Value));

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