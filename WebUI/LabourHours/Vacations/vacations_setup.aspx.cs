using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.DA.LabourHours.Vacations;
using LiquiForce.LFSLive.BL.LabourHours.Vacations;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Resources.Employees;
using System.Web.UI.HtmlControls;

namespace LiquiForce.LFSLive.WebUI.LabourHours.Vacations
{
    /// <summary>
    /// vacations_setup
    /// </summary>
    public partial class vacations_setup : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected VacationsSetupTDS.VacationsSetupDataTable vacationsSetup;






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
                if (!(Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_VACATIONS_HOLIDAY_FULL_EDITING"]))) 
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if ((string)Request.QueryString["source_page"] == null)
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in vacations_setup.aspx");
                }
                
                // Tag page
                // ... for non vacation managers
                EmployeeGateway employeeGatewayManager = new EmployeeGateway();
                int employeeIdNow = employeeGatewayManager.GetEmployeIdByLoginId(Convert.ToInt32(Session["loginID"]));
                employeeGatewayManager.LoadByEmployeeId(employeeIdNow);
                               

                if (employeeGatewayManager.GetIsVacationsManager(employeeIdNow))
                {
                    hdfIsVacationManager.Value = "True";
                }
                else
                {
                    hdfIsVacationManager.Value = "False";
                }
                
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfUpdate.Value = "no";

                Session.Remove("vacationsSetup");
                Session.Remove("vacationsSetupDummy");

                // Prepare initial data

                // ... For Grids
                vacationsSetup = new VacationsSetupTDS.VacationsSetupDataTable();

                // ... Store datasets
                Session["vacationsSetup"] = vacationsSetup;

                // StepSection1In
                wizard.ActiveStepIndex = 0;
                StepBeginIn();
            }
            else
            {
                // Restore datasets
                vacationsSetup = (VacationsSetupTDS.VacationsSetupDataTable)Session["vacationsSetup"];
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
                        throw new Exception("The option for " + wizard.ActiveStep.Name + " step in vacations_setup.Wizard_ActiveStepChanged function does not exist");
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
                    throw new Exception("The option for " + wizard.ActiveStep.Name + " step in vacations_setup.Wizard_NextButtonClick function does not exist");
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
        // STEP1 - BEGIN - AUXILIAR EVENTS
        //

        protected void ddlSelectAPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            Page.Validate("Begin");

            if (Page.IsValid)
            {
                StepBeginProcessGrid();

                // Load
                VacationsSetupTDS dataSet = new VacationsSetupTDS();
                dataSet.VacationsSetup.Merge(vacationsSetup, true);
                VacationsSetup model = new VacationsSetup(dataSet);

                if (dataSet.VacationsSetup.Select(string.Format("Year = {0}", Int32.Parse(ddlSelectAPeriod.SelectedValue))).Length == 0)
                {
                    // ... Load                    
                    model.LoadByYear(Int32.Parse(ddlSelectAPeriod.SelectedValue), Int32.Parse(hdfCompanyId.Value));
                    
                    dataSet.VacationsSetup.Merge(vacationsSetup, true);
                    odsVacationsSetup.FilterExpression = string.Format("Year = {0}", Int32.Parse(ddlSelectAPeriod.SelectedValue));
                }
                else
                {
                    odsVacationsSetup.FilterExpression = string.Format("Year = {0}", Int32.Parse(ddlSelectAPeriod.SelectedValue));
                }

                // Store tables
                vacationsSetup = (VacationsSetupTDS.VacationsSetupDataTable)model.Table;
                Session["vacationsSetup"] = vacationsSetup;
            }

            grdVacationsSetup.DataBind();
        }



        protected void tbxTotalDays_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < grdVacationsSetup.Rows.Count; i++)
            {
                if ((grdVacationsSetup.Rows[i].RowType == DataControlRowType.DataRow) && ((grdVacationsSetup.Rows[i].RowState == DataControlRowState.Normal) || (grdVacationsSetup.Rows[i].RowState == (DataControlRowState.Normal | DataControlRowState.Alternate))))
                {
                    float carryOver = float.Parse(((TextBox)grdVacationsSetup.Rows[i].Cells[2].FindControl("tbxCarryOverDays")).Text);
                    float vacationDays = float.Parse(((TextBox)grdVacationsSetup.Rows[i].Cells[2].FindControl("tbxVacationDays")).Text);
                    ((TextBox)grdVacationsSetup.Rows[i].Cells[2].FindControl("tbxTotalDays")).Text = (carryOver + vacationDays).ToString();
                }
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP1 - BEGIN - METHODS
        //

        private void StepBeginIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Please provide paid vacation days information";

            // Initiaize data
            vacationsSetup = new VacationsSetupTDS.VacationsSetupDataTable();

            // Load
            VacationsSetupTDS dataSet = new VacationsSetupTDS();
            VacationsSetup model = new VacationsSetup(dataSet);

            model.LoadByYear(Int32.Parse(ddlSelectAPeriod.SelectedValue), Int32.Parse(hdfCompanyId.Value));
            
            // Store tables
            vacationsSetup = (VacationsSetupTDS.VacationsSetupDataTable)model.Table;
            Session["vacationsSetup"] = vacationsSetup;
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
                VacationsSetupTDS dataSet = new VacationsSetupTDS();
                dataSet.VacationsSetup.Merge(vacationsSetup, true);
                VacationsSetup model = new VacationsSetup(dataSet);

                // update rows
                foreach (GridViewRow row in grdVacationsSetup.Rows)
                {
                    int year = Int32.Parse(grdVacationsSetup.DataKeys[row.RowIndex].Values["Year"].ToString());
                    int employeeId = Int32.Parse(grdVacationsSetup.DataKeys[row.RowIndex].Values["EmployeeID"].ToString());
                    double newVacationDays = double.Parse(((TextBox)row.FindControl("tbxVacationDays")).Text);
                    double newCarryOverDays = double.Parse(((TextBox)row.FindControl("tbxCarryOverDays")).Text);

                    model.Update(year, employeeId, newVacationDays, newCarryOverDays);
                }

                vacationsSetup = (VacationsSetupTDS.VacationsSetupDataTable)model.Table;
                Session["vacationsSetup"] = vacationsSetup;

                hdfUpdate.Value = "yes";
            }
        }



        private bool ExistsDataModified()
        {
            foreach (GridViewRow row in grdVacationsSetup.Rows)
            {
                try
                {
                    VacationsSetupTDS dataSet = new VacationsSetupTDS();
                    dataSet.VacationsSetup.Merge(vacationsSetup, true);
                    VacationsSetupGateway model = new VacationsSetupGateway(dataSet);
                    
                    // Getting general information
                    int year = Int32.Parse(grdVacationsSetup.DataKeys[row.RowIndex].Values["Year"].ToString());
                    int employeeId = Int32.Parse(grdVacationsSetup.DataKeys[row.RowIndex].Values["EmployeeID"].ToString());

                    // Verify vacation Days
                    double newVacationDays = double.Parse(((TextBox)row.FindControl("tbxVacationDays")).Text);
                    double originalVacationDays = model.GetVacationDaysOriginal(year, employeeId);

                    if (newVacationDays != originalVacationDays)
                    {
                        return true;
                    }
                    else
                    { 
                        // Verify carryOver days
                        double newCarryOverDays = double.Parse(((TextBox)row.FindControl("tbxCarryOverDays")).Text);
                        double originalCarryOverDays = model.GetCarryOverDaysOriginal(year, employeeId);

                        if (newCarryOverDays != originalCarryOverDays)
                        {
                            return true;
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
        


        public VacationsSetupTDS.VacationsSetupDataTable GetVacationsSetupNew()
        {
            vacationsSetup = (VacationsSetupTDS.VacationsSetupDataTable)Session["vacationsSetupDummy"];

            if (vacationsSetup == null)
            {
                vacationsSetup = ((VacationsSetupTDS.VacationsSetupDataTable)Session["vacationsSetup"]);
            }

            return vacationsSetup;
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
            VacationsSetupTDS dataSet = new VacationsSetupTDS();
            dataSet.VacationsSetup.Merge(vacationsSetup, true);
            VacationsSetup model = new VacationsSetup(dataSet);

            tbxSummary.Text = model.GetSummary(Int32.Parse(ddlSelectAPeriod.SelectedValue));
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
            master.WizardTitle = "Vacations Setup";
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
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./vacations_setup.js");
        }



        private void Save()
        {
            // process sections
            VacationsSetupTDS dataSet = new VacationsSetupTDS();
            dataSet.VacationsSetup.Merge(vacationsSetup, true);
            VacationsSetup model = new VacationsSetup(dataSet);

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