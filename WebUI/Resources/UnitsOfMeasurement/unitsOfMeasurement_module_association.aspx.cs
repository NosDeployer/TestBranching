using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Resources.UnitsOfMeasurement;
using LiquiForce.LFSLive.BL.Resources.UnitsOfMeasurement;

namespace LiquiForce.LFSLive.WebUI.Resources.UnitsOfMeasurement
{
    /// <summary>
    /// unitsOfMeasurement_module_association
    /// </summary>
    public partial class unitsOfMeasurement_module_association : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected UnitsOfMeasurementAssociationsToolTDS unitsOfMeasurementAssociationsToolTDS;
        protected UnitsOfMeasurementAssociationsToolTDS.AssociatedUnitsDataTable associations;






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
                if (!(Convert.ToBoolean(Session["sgLFS_RESOURCES_UNITSOFMEASUREMENT_ADMIN"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if ((string)Request.QueryString["source_page"] == null) 
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in unitsOfMeasurement_module_association.aspx");
                }

                // Tag Page
                hdfCompanyId.Value = Convert.ToInt32(Session["companyID"]).ToString();
                Session.Remove("associationsDummy");
                hdfLoadDataFirstTime.Value = "True";

                // If coming from 
                // ... employee_navigator.aspx
                if (Request.QueryString["source_page"] == "lm")
                {
                    int companyId = Int32.Parse(hdfCompanyId.Value);

                    // ... Initialize tables
                    unitsOfMeasurementAssociationsToolTDS = new UnitsOfMeasurementAssociationsToolTDS();
                    Session["unitsOfMeasurementAssociationsToolTDS"] = unitsOfMeasurementAssociationsToolTDS;
                }

                // StepSection1In
                wzUnitsOfMeasurement.ActiveStepIndex = 0;             
                StepBeginIn();
            }
            else
            {
                // Restore tables
                unitsOfMeasurementAssociationsToolTDS = (UnitsOfMeasurementAssociationsToolTDS)Session["unitsOfMeasurementAssociationsToolTDS"];
                associations = unitsOfMeasurementAssociationsToolTDS.AssociatedUnits;
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
                switch (wzUnitsOfMeasurement.ActiveStep.Name)
                {
                    case "Begin":
                        StepBeginIn();
                        break;

                    case "Associations":
                        StepAssociationsIn();
                        break;

                    case "Summary":
                        StepSummaryIn();
                        break;

                    default:
                        throw new Exception("The option for " + wzUnitsOfMeasurement.ActiveStep.Name + " step in unitsOfMeasurement_module_association.Wizard_ActiveStepChanged function does not exist");
                }
            }
        }



        protected void Wizard_NextButtonClick(object sender, WizardNavigationEventArgs e)
        {
            switch (wzUnitsOfMeasurement.ActiveStep.Name)
            {
                case "Begin":
                    e.Cancel = !StepBeginNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "Begin";
                    }
                    break;

                case "Associations":
                    e.Cancel = !StepAssociationsNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "General Information";
                    }
                    break;

                default:
                    throw new Exception("The option for " + wzUnitsOfMeasurement.ActiveStep.Name + " step in unitsOfMeasurement_module_association.Wizard_NextButtonClick function does not exist");
            }
        }



        protected void Wizard_PreviousButtonClick(object sender, WizardNavigationEventArgs e)
        {
            switch (wzUnitsOfMeasurement.ActiveStep.Name)
            {
                case "Associations":
                    e.Cancel = !StepAssociationsPrevious();
                    break;

                case "Summary":
                    e.Cancel = !StepSummaryPrevious();
                    break;

                default:
                    throw new Exception("The option for " + wzUnitsOfMeasurement.ActiveStep.Name + " step in unitsOfMeasurement_module_association.Wizard_PreviousButtonClick function does not exist");
            }
            if (!e.Cancel)
            {
                ViewState["StepFrom"] = wzUnitsOfMeasurement.ActiveStep.Name;
            }
        }



        protected void Wizard_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        {
            e.Cancel = !StepSummaryFinish();
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
            instruction.Text = "Please select the module you want to associate with units";
        }



        private bool StepBeginNext()
        {
            Page.Validate("beginData");
            if (Page.IsValid)
            {
                if (hdfModule.Value != ddlModules.SelectedValue)
                {
                    hdfModule.Value = ddlModules.SelectedValue;
                    hdfLoadDataFirstTime.Value = "True";
                }
                else
                {
                    hdfModule.Value = ddlModules.SelectedValue;
                    hdfLoadDataFirstTime.Value = "False";
                }
            
                return true;
            }
            else
            {
                return false;
            }
        }



        #endregion






        #region STEP2 - ASSOCIATIONS

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP2 - ASSOCIATIONS
        //


        // ////////////////////////////////////////////////////////////////////////
        // STEP2 - COLUMNS TO DISPLAY - AUXILIAR EVENTS
        //

        protected void grdAssociations_DataBound(object sender, EventArgs e)
        {
            AssociationsEmptyFix(grdAssociations);
        }



        protected void cvgrdAssociations_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Initialize 
            args.IsValid = false;

            if (grdAssociations.Rows.Count > 0)
            {
                foreach (GridViewRow row in grdAssociations.Rows)
                {
                    if (((CheckBox)row.FindControl("cbxSelected")).Checked)
                    {
                        args.IsValid = true;
                    }
                }
            }           
        }



        protected void cvGrdAssociationsByDefault_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Initialize 
            args.IsValid = false;

            if (grdAssociations.Rows.Count > 0)
            {
                foreach (GridViewRow row in grdAssociations.Rows)
                {
                    if (((CheckBox)row.FindControl("cbxByDefault")).Checked)
                    {
                        args.IsValid = true;
                    }
                }
            }
        }



        protected void cvGrdAssociationsByDefaultSelected_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Initialize 
            args.IsValid = true;

            if (grdAssociations.Rows.Count > 0)
            {
                foreach (GridViewRow row in grdAssociations.Rows)
                {
                    if (((CheckBox)row.FindControl("cbxByDefault")).Checked)
                    {
                        if (((CheckBox)row.FindControl("cbxSelected")).Checked)
                        {
                            args.IsValid = true;
                        }
                        else
                        {
                            args.IsValid = false;
                        }
                    }
                }
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP2 - ASSOCIATIONS - METHODS
        //

        private void StepAssociationsIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Please select the Units you want to associate with the module " + hdfModule.Value + " and set one as default";

            // Load Data
            if (hdfLoadDataFirstTime.Value == "True")
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                UnitsOfMeasurementAssociationsToolAssociatedUnits unitsOfMeasurementAssociationsToolAssociatedUnits = new UnitsOfMeasurementAssociationsToolAssociatedUnits(unitsOfMeasurementAssociationsToolTDS);
                unitsOfMeasurementAssociationsToolAssociatedUnits.LoadAll(hdfModule.Value, companyId);
                hdfLoadDataFirstTime.Value = "False";
            }

            // ... Store tables
            Session["unitsOfMeasurementAssociationsToolTDS"] = unitsOfMeasurementAssociationsToolTDS;
            Session["associations"] = unitsOfMeasurementAssociationsToolTDS.AssociatedUnits;
            associations = unitsOfMeasurementAssociationsToolTDS.AssociatedUnits;

            grdAssociations.DataBind();
        }



        private bool StepAssociationsPrevious()
        {
            grdAssociations.DataBind();
            return true;
        }



        private bool StepAssociationsNext()
        {
            Page.Validate("associations");

            if (Page.IsValid)
            {
                StepAssociationsProcessGrid();
                grdAssociations.DataBind();
                return true;
            }
            else
            {
                return false;
            }
        }



        private void StepAssociationsProcessGrid()
        {
            string associationsList = "";
                        
            if (grdAssociations.Rows.Count > 0)
            {
                foreach (GridViewRow row in grdAssociations.Rows)
                {
                    // Save associations
                    int associationsId = Int32.Parse(grdAssociations.DataKeys[row.RowIndex].Values["AssociationsID"].ToString());
                    bool selected = ((CheckBox)row.FindControl("cbxSelected")).Checked;
                    bool byDefault = ((CheckBox)row.FindControl("cbxByDefault")).Checked;

                    UnitsOfMeasurementAssociationsToolAssociatedUnits unitsOfMeasurementAssociationsToolAssociatedUnits = new UnitsOfMeasurementAssociationsToolAssociatedUnits(unitsOfMeasurementAssociationsToolTDS);
                    unitsOfMeasurementAssociationsToolAssociatedUnits.Update(associationsId, byDefault, selected);
                    
                    // Get List of Associations
                    if (selected)
                    {
                        associationsList = associationsList + "    - " + ((Label)row.FindControl("lblDescription")).Text ;
                        
                        if (byDefault)
                        {
                            associationsList = associationsList + ", DEFAULT";
                        }
                        associationsList = associationsList + "\n";
                    }
                }                                                  
            }

            hdfAssociationsList.Value = associationsList;  
            Session["unitsOfMeasurementAssociationsToolTDS"] = unitsOfMeasurementAssociationsToolTDS;
            Session["associations"] = unitsOfMeasurementAssociationsToolTDS.AssociatedUnits;
            associations = unitsOfMeasurementAssociationsToolTDS.AssociatedUnits;
        }



        public UnitsOfMeasurementAssociationsToolTDS.AssociatedUnitsDataTable GetAssociations()
        {
            associations = (UnitsOfMeasurementAssociationsToolTDS.AssociatedUnitsDataTable)Session["associationsDummy"];
            if (associations == null)
            {
                associations = (UnitsOfMeasurementAssociationsToolTDS.AssociatedUnitsDataTable)Session["associations"];
            }

            return associations;
        }



        protected void AssociationsEmptyFix(GridView grdView)
        {
            if (grdView.Rows.Count == 0)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                UnitsOfMeasurementAssociationsToolTDS.AssociatedUnitsDataTable dt = new UnitsOfMeasurementAssociationsToolTDS.AssociatedUnitsDataTable();
                dt.AddAssociatedUnitsRow(-1, -1, "", false, false, companyId, false, false,  "");
                Session["associationsDummy"] = dt;

                grdView.DataBind();
            }

            // Normally executes at all postbacks
            if (grdView.Rows.Count == 1)
            {
                UnitsOfMeasurementAssociationsToolTDS.AssociatedUnitsDataTable dt = (UnitsOfMeasurementAssociationsToolTDS.AssociatedUnitsDataTable)Session["associationsDummy"];
                if (dt != null)
                {
                    // Hide row
                    grdView.Rows[0].Visible = false;
                    grdView.Rows[0].Controls.Clear();
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
        // STEP3 - SUMMARY - METHODS
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
                Response.Write("<script language='javascript'> { window.close();}</script>");
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
            title.Text = "Module Association";
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
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./unitsOfMeasurement_module_association.js");
        }



        private void UpdateDatabase()
        {
            DB.Open();
            DB.BeginTransaction();
            try
            {
                UnitsOfMeasurementAssociationsToolAssociatedUnits unitsOfMeasurementAssociationsToolAssociatedUnits = new UnitsOfMeasurementAssociationsToolAssociatedUnits(unitsOfMeasurementAssociationsToolTDS);
                unitsOfMeasurementAssociationsToolAssociatedUnits.Save();

                DB.CommitTransaction();

                // Store datasets
                Session["unitsOfMeasurementAssociationsToolTDS"] = unitsOfMeasurementAssociationsToolTDS;

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
            string summary = "ASSOCIATIONS \n\n";
            summary = summary + "Module: " + hdfModule.Value + "\n\n";
            summary = summary + "Associations: \n\n";
            summary = summary + hdfAssociationsList.Value + "\n"; ;
            return summary;
        }
            
        

    }
}