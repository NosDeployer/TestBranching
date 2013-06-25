using System;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.BL.LabourHours.ActualCosts;
using LiquiForce.LFSLive.DA.LabourHours.ActualCosts;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.BL.Projects.Projects;
using LiquiForce.LFSLive.DA.RAF;
using LiquiForce.LFSLive.Server;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.LabourHours.ActualCosts
{
    /// <summary>
    /// actual_costs_add
    /// </summary>
    public partial class actual_costs_add : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected ActualCostsAddTDS actualCostsAddTDS;
        protected ActualCostsAddTDS.SubcontractorCostsDataTable subcontractorCosts;
        protected ActualCostsAddTDS.HotelCostsDataTable hotelCosts;
        protected ActualCostsAddTDS.BondingCompaniesCostsDataTable  bondingCompaniesCosts;
        protected ActualCostsAddTDS.InsuranceCompaniesCostsDataTable insuranceCompaniesCosts;
        protected ActualCostsAddTDS.OtherCostsDataTable otherCosts;






        // ////////////////////////////////////////////////////////////////////////
        // INITIAL EVENTS
        //

        protected void Page_Load(object sender, EventArgs e)
        {
            // Register client scripts
            this.RegisterClientScripts();

            if (!IsPostBack)
            {
                if (!(Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_ACTUAL_COSTS_ADMIN"])))
                {
                    // Security check
                    if (!(Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_ACTUAL_COSTS_ADD"])))
                    {
                        Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                    }

                    // Validate query string
                    if ((string)Request.QueryString["source_page"] == null)
                    {
                        Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in actual_costs_add.aspx");
                    }
                }

                // Tag Page                
                hdfCompanyId.Value = Session["companyID"].ToString();
                upnlSubcontractorCost.Visible = false;

                // ... Dummy values
                Session.Remove("subcontractorCostsBySubcontractorDummy");
                Session.Remove("subcontractorCostsByClientProjectDummy");
                Session.Remove("hotelCostsByClientProjectDummy");
                Session.Remove("bondingCompaniesCostsByClientProjectDummy");
                Session.Remove("insuranceCompaniesCostsByClientProjectDummy");
                Session.Remove("otherCostsByClientProjectDummy");

                // Store datasets
                actualCostsAddTDS = new ActualCostsAddTDS();
                Session["actualCostsAddTDS"] = actualCostsAddTDS;
                Session["hotelCosts"] = actualCostsAddTDS.HotelCosts;
                Session["subcontractorCosts"] = actualCostsAddTDS.SubcontractorCosts;
                Session["bondingCompaniesCosts"] = actualCostsAddTDS.BondingCompaniesCosts;
                Session["insuranceCompaniesCosts"] = actualCostsAddTDS.InsuranceCompaniesCosts;
                Session["otherCosts"] = actualCostsAddTDS.OtherCosts;                

                StoreNavigatorState();
                
                // StepSection1In
                wzActualCostsAdd.ActiveStepIndex = 0;
                StepBeginIn();
            }
            else
            {
                // Restore datasets
                actualCostsAddTDS = (ActualCostsAddTDS)Session["actualCostsAddTDS"];
                subcontractorCosts = actualCostsAddTDS.SubcontractorCosts;
                Session["subcontractorCosts"] = actualCostsAddTDS.SubcontractorCosts;
                Session["hotelCosts"] = actualCostsAddTDS.HotelCosts;
                Session["bondingCompaniesCosts"] = actualCostsAddTDS.BondingCompaniesCosts;
                Session["insuranceCompaniesCosts"] = actualCostsAddTDS.InsuranceCompaniesCosts;
                Session["otherCosts"] = actualCostsAddTDS.OtherCosts;
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
                switch (wzActualCostsAdd.ActiveStep.Name)
                {
                    case "Begin":
                        StepBeginIn();
                        break;

                    case "SubcontractorCostsBySubcontractor":
                        StepSubcontractorCostsBySubcontractorIn();
                        break;

                    case "SubcontractorCostsByClientProject":
                        StepSubcontractorCostsByClientProjectIn();
                        break;

                    case "HotelCostsByClientProject":
                        StepHotelCostsByClientProjectIn();
                        break;

                    case "BondingCompaniesCostsByClientProject":
                        StepBondingCompaniesCostsByClientProjectIn();
                        break;

                    case "InsuranceCompaniesCostsByClientProject":
                        StepInsuranceCompaniesCostsByClientProjectIn();
                        break;

                    case "OtherCostsByClientProject":
                        StepOtherCostsByClientProjectIn();
                        break;                    

                    case "Summary":
                        StepSummaryIn();
                        break;                    

                    default:
                        throw new Exception("The option for " + wzActualCostsAdd.ActiveStep.Name + " step in project_costing_sheets_add.Wizard_ActiveStepChanged function does not exist");
                }
            }
        }



        protected void Wizard_NextButtonClick(object sender, WizardNavigationEventArgs e)
        {            
            switch (wzActualCostsAdd.ActiveStep.Name)
            {
                case "Begin":
                    // Standard: Code for guider step
                    e.Cancel = !StepBeginNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "Begin";
                        if (cbxSubcontractorCosts.Checked)
                        {
                            if (rbtnSubcontractorCostsBySubcontractor.Checked)
                            {
                                wzActualCostsAdd.ActiveStepIndex = wzActualCostsAdd.WizardSteps.IndexOf(StepSubcontractorCostsBySubcontractor);
                            }
                            else
                            {
                                if (rbtnSubcontractorCostsByProjectAndClient.Checked)
                                {
                                    wzActualCostsAdd.ActiveStepIndex = wzActualCostsAdd.WizardSteps.IndexOf(StepSubcontractorCostsByClientProject);
                                }

                            }                        
                        }
                        else
                        {                         
                            if (cbxHotelCosts.Checked)
                            {
                                wzActualCostsAdd.ActiveStepIndex = wzActualCostsAdd.WizardSteps.IndexOf(StepHotelCostsByClientProject);
                            }
                            else
                            {
                                if (cbxBondingCosts.Checked)
                                {
                                    wzActualCostsAdd.ActiveStepIndex = wzActualCostsAdd.WizardSteps.IndexOf(StepBondingCompaniesCostsByClientProject);
                                }
                                else
                                {
                                    if (cbxInsuranceCosts.Checked)
                                    {
                                        wzActualCostsAdd.ActiveStepIndex = wzActualCostsAdd.WizardSteps.IndexOf(StepInsuranceCompaniesCostsByClientProject);                                                
                                    }
                                    else
                                    {
                                        if (cbxOtherCosts.Checked)
                                        {
                                            wzActualCostsAdd.ActiveStepIndex = wzActualCostsAdd.WizardSteps.IndexOf(StepOtherCostsByClientProject);                                                
                                        }
                                        else
                                        {
                                            wzActualCostsAdd.ActiveStepIndex = wzActualCostsAdd.WizardSteps.IndexOf(StepSummary);
                                        }
                                    }
                                }
                            }
                        }                                            
                    }
                    break;

                case "SubcontractorCostsBySubcontractor":                 
                    // Standard: Code for normal step
                    e.Cancel =  !StepSubcontractorCostsBySubcontractorNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "SubcontractorCostsBySubcontractor";                                                
                        if (cbxHotelCosts.Checked)
                        {
                            wzActualCostsAdd.ActiveStepIndex = wzActualCostsAdd.WizardSteps.IndexOf(StepHotelCostsByClientProject);
                        }
                        else
                        {
                            if (cbxBondingCosts.Checked)
                            {
                                wzActualCostsAdd.ActiveStepIndex = wzActualCostsAdd.WizardSteps.IndexOf(StepBondingCompaniesCostsByClientProject);
                            }
                            else
                            {
                                if (cbxInsuranceCosts.Checked)
                                {
                                    wzActualCostsAdd.ActiveStepIndex = wzActualCostsAdd.WizardSteps.IndexOf(StepInsuranceCompaniesCostsByClientProject);                                                
                                }
                                else
                                {
                                    if (cbxOtherCosts.Checked)
                                    {
                                        wzActualCostsAdd.ActiveStepIndex = wzActualCostsAdd.WizardSteps.IndexOf(StepOtherCostsByClientProject);                                                
                                    }
                                    else
                                    {
                                        wzActualCostsAdd.ActiveStepIndex = wzActualCostsAdd.WizardSteps.IndexOf(StepSummary);
                                    }
                                }
                            }                            
                        }                                            
                    }                    
                    break;

                case "SubcontractorCostsByClientProject":
                    e.Cancel = !StepSubcontractorCostsByClientProjectNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "SubcontractorCostsBySubcontractorByClientProject";                        
                        if (cbxHotelCosts.Checked)
                        {
                            wzActualCostsAdd.ActiveStepIndex = wzActualCostsAdd.WizardSteps.IndexOf(StepHotelCostsByClientProject);
                        }
                        else
                        {
                            if (cbxBondingCosts.Checked)
                            {
                                wzActualCostsAdd.ActiveStepIndex = wzActualCostsAdd.WizardSteps.IndexOf(StepBondingCompaniesCostsByClientProject);
                            }
                            else
                            {
                                if (cbxInsuranceCosts.Checked)
                                {
                                    wzActualCostsAdd.ActiveStepIndex = wzActualCostsAdd.WizardSteps.IndexOf(StepInsuranceCompaniesCostsByClientProject);                                                
                                }
                                else
                                {
                                    if (cbxOtherCosts.Checked)
                                    {
                                        wzActualCostsAdd.ActiveStepIndex = wzActualCostsAdd.WizardSteps.IndexOf(StepOtherCostsByClientProject);                                                
                                    }
                                    else
                                    {
                                        wzActualCostsAdd.ActiveStepIndex = wzActualCostsAdd.WizardSteps.IndexOf(StepSummary);
                                    }
                                }
                            }
                        }                                                                                      
                    }
                    break;

                case "HotelCostsByClientProject":
                    e.Cancel = !StepHotelCostsByClientProjectNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "HotelCostsByClientProject";                                                                  
                        if (cbxBondingCosts.Checked)
                        {
                            wzActualCostsAdd.ActiveStepIndex = wzActualCostsAdd.WizardSteps.IndexOf(StepBondingCompaniesCostsByClientProject);
                        }
                        else
                        {
                            if (cbxInsuranceCosts.Checked)
                            {
                                wzActualCostsAdd.ActiveStepIndex = wzActualCostsAdd.WizardSteps.IndexOf(StepInsuranceCompaniesCostsByClientProject);                                                
                            }
                            else
                            {
                                if (cbxOtherCosts.Checked)
                                {
                                    wzActualCostsAdd.ActiveStepIndex = wzActualCostsAdd.WizardSteps.IndexOf(StepOtherCostsByClientProject);                                                
                                }
                                else
                                {
                                    wzActualCostsAdd.ActiveStepIndex = wzActualCostsAdd.WizardSteps.IndexOf(StepSummary);
                                }
                            }
                        }                                                                                                           
                    }
                    break;

                case "BondingCompaniesCostsByClientProject":
                    e.Cancel = !StepBondingCompaniesCostsByClientProjectNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "BondingCompaniesCostsByClientProject";                        
                        if (cbxInsuranceCosts.Checked)
                        {
                            wzActualCostsAdd.ActiveStepIndex = wzActualCostsAdd.WizardSteps.IndexOf(StepInsuranceCompaniesCostsByClientProject);                                                
                        }
                        else
                        {
                            if (cbxOtherCosts.Checked)
                            {
                                wzActualCostsAdd.ActiveStepIndex = wzActualCostsAdd.WizardSteps.IndexOf(StepOtherCostsByClientProject);                                                
                            }
                            else
                            {
                                wzActualCostsAdd.ActiveStepIndex = wzActualCostsAdd.WizardSteps.IndexOf(StepSummary);
                            }
                        }                                                                                                                                                      
                    }
                    break;

                case "InsuranceCompaniesCostsByClientProject":
                    e.Cancel = !StepInsuranceCompaniesCostsByClientProjectNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "InsuranceCompaniesCostsByClientProject";                                               
                        if (cbxOtherCosts.Checked)
                        {
                            wzActualCostsAdd.ActiveStepIndex = wzActualCostsAdd.WizardSteps.IndexOf(StepOtherCostsByClientProject);
                        }
                        else
                        {
                            wzActualCostsAdd.ActiveStepIndex = wzActualCostsAdd.WizardSteps.IndexOf(StepSummary);
                        }                                                 
                    }
                    break;

                case "OtherCostsByClientProject":
                    e.Cancel = !StepOtherCostsByClientProjectNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "OtherCostsByClientProject";                        
                        wzActualCostsAdd.ActiveStepIndex = wzActualCostsAdd.WizardSteps.IndexOf(StepSummary);                        
                    }
                    break;               

                default:
                    throw new Exception("The option for " + wzActualCostsAdd.ActiveStep.Name + " step in actual_costs_add.Wizard_NextButtonClick function does not exist");
            }
        }



        protected void Wizard_PreviousButtonClick(object sender, WizardNavigationEventArgs e)
        {
            switch (wzActualCostsAdd.ActiveStep.Name)
            {
                case "SubcontractorCostsBySubcontractor":
                    e.Cancel = !StepSubcontractorCostsBySubcontractorPrevious();
                    break;

                case "SubcontractorCostsByClientProject":
                    e.Cancel = !StepSubcontractorCostsByClientProjectPrevious();
                    break;

                case "HotelCostsByClientProject":
                    e.Cancel = !StepHotelCostsByClientProjectPrevious();
                    break;

                case "BondingCompaniesCostsByClientProject":
                    e.Cancel = !StepBondingCompaniesCostsByClientProjectPrevious();
                    break;

                case "InsuranceCompaniesCostsByClientProject":
                    e.Cancel = !StepInsuranceCompaniesCostsByClientProjectPrevious();
                    break;

                case "OtherCostsByClientProject":
                    e.Cancel = !StepOtherCostsByClientProjectPrevious();
                    break;

                case "Summary":
                    e.Cancel = !StepSummaryPrevious();
                    break; 

                default:
                    throw new Exception("The option for " + wzActualCostsAdd.ActiveStep.Name + " step in actual_costs_add.Wizard_PreviousButtonClick function does not exist");
            }
            if (!e.Cancel)
            {
                ViewState["StepFrom"] = wzActualCostsAdd.ActiveStep.Name;
            }
        }



        protected void Wizard_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        {
            e.Cancel = (!StepSummaryFinish());

            if (!e.Cancel)
            {
                string script = "<script language='javascript'>";
                script += "{ window.close(); }";
                script += "</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Cancel", script, false);
            }
        }



        protected void Wizard_CancelButtonClick(object sender, EventArgs e)
        {
            string script = "<script language='javascript'>";
            script += "{ window.close(); }";
            script += "</script>";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Cancel", script, false);
        }

        #endregion






        #region STEP1 - BEGIN

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP1 - BEGIN
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP2 - TEMPLATE - AUXILIAR EVENTS
        //

        protected void cbxSubcontractorCost_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxSubcontractorCosts.Checked)
            {
                upnlSubcontractorCost.Visible = true;
                rbtnSubcontractorCostsBySubcontractor.Checked = true;
            }
            else
            {
                upnlSubcontractorCost.Visible = false;
                rbtnSubcontractorCostsByProjectAndClient.Checked = false;
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP1 - BEGIN - METHODS
        //

        private void StepBeginIn()
        {
            // Set instruction
            mWizard2 master = (mWizard2)this.Master;
            master.WizardInstruction = "What do you want to do?";            
        }



        private bool StepBeginNext()
        {
            return true;
        }
     


        #endregion






        #region STEP2 - SUBCONTRACTOR COST BY SUBCONTRACTORS

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP2 - SUBCONTRACTOR COST BY SUBCONTRACTORS
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP2 - SUBCONTRACTOR COST BY SUBCONTRACTORS -  EVENTS
        //

        protected void grdSubcontractorCostsBySubcontractor_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Add":
                    // Subcontractor Gridview, if the gridview is edition mode
                    if (grdSubcontractorCostsBySubcontractor.EditIndex >= 0)
                    {
                        grdSubcontractorCostsBySubcontractor.UpdateRow(grdSubcontractorCostsBySubcontractor.EditIndex, true);
                    }

                    // Add New Subcontractor
                    grdSubcontractorCostsBySubcontractorDetailAdd();
                    break;
            }
        }




        protected void grdSubcontractorCostsBySubcontractor_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.Validate("generalData");
            if (Page.IsValid)
            {
                Page.Validate("DataEdit");
                if (Page.IsValid)
                {
                    int companyId = Int32.Parse(hdfCompanyId.Value);                    
                    int refId = Int32.Parse(((Label)grdSubcontractorCostsBySubcontractor.Rows[e.RowIndex].FindControl("lblRefIdEdit")).Text);
                    DateTime date = (DateTime)((RadDatePicker)grdSubcontractorCostsBySubcontractor.Rows[e.RowIndex].FindControl("tkrdpDateEdit")).SelectedDate;

                    int subcontractorId = Int32.Parse(ddlSubcontractor.SelectedValue);
                    string name = ddlSubcontractor.SelectedItem.Text;

                    int projectId = Int32.Parse(((Label)grdSubcontractorCostsBySubcontractor.Rows[e.RowIndex].FindControl("lblProjectIdEdit")).Text);                    

                    string quantityString = ((TextBox)grdSubcontractorCostsBySubcontractor.Rows[e.RowIndex].FindControl("tbxQuantityEdit")).Text;
                    decimal quantity1 = decimal.Round(decimal.Parse(quantityString), 1);
                    double quantity = double.Parse(quantity1.ToString());

                    decimal rate = decimal.Round(decimal.Parse(((TextBox)grdSubcontractorCostsBySubcontractor.Rows[e.RowIndex].FindControl("tbxRateEdit")).Text), 2);
                    decimal total = decimal.Round(decimal.Parse(((TextBox)grdSubcontractorCostsBySubcontractor.Rows[e.RowIndex].FindControl("tbxTotalEdit")).Text), 2);
                    decimal rateCad = 0;
                    decimal totalCad = 0;
                    decimal rateUsd = 0;
                    decimal totalUsd = 0;

                    ProjectGateway projectGateway = new ProjectGateway();
                    projectGateway.LoadByProjectId(projectId);

                    if (projectGateway.GetCountryID(projectId) == 1) //Canada
                    {
                        rateCad = rate;
                        totalCad = total;
                    }
                    else
                    {
                        rateUsd = rate;
                        totalUsd = total;
                    }

                    string comment = ((TextBox)grdSubcontractorCostsBySubcontractor.Rows[e.RowIndex].FindControl("tbxCommentEdit")).Text;
                    bool deleted = false;

                    // Update Data
                    ActualCostsAddSubcontractorCosts subcontractorAddProjectSubcontractorsCosts = new ActualCostsAddSubcontractorCosts(actualCostsAddTDS);
                    subcontractorAddProjectSubcontractorsCosts.Update(projectId, refId, subcontractorId, date, quantity, rateCad, totalCad, rateUsd, totalUsd, comment, deleted, companyId, name);

                    // Store dataset
                    Session["actualCostsAddTDS"] = actualCostsAddTDS;
                    Session.Remove("subcontractorCostsBySubcontractorDummy");
                    subcontractorCosts = actualCostsAddTDS.SubcontractorCosts;
                    Session["subcontractorCosts"] = actualCostsAddTDS.SubcontractorCosts;
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }



        protected void grdSubcontractorCostsBySubcontractor_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Subcontractor Gridview, if the gridview is edition mode
            if (grdSubcontractorCostsBySubcontractor.EditIndex >= 0)
            {
                grdSubcontractorCostsBySubcontractor.UpdateRow(grdSubcontractorCostsBySubcontractor.EditIndex, true);
            }

            // Delete subcontractor
            int projectId = (int)e.Keys["ProjectID"];
            int refId = (int)e.Keys["RefID"];

            // Delete costs details
            ActualCostsAddSubcontractorCosts subcontractorAddProjectSubcontractorsCosts = new ActualCostsAddSubcontractorCosts(actualCostsAddTDS);
            subcontractorAddProjectSubcontractorsCosts.Delete(projectId, refId);

            // Store dataset
            Session["actualCostsAddTDS"] = actualCostsAddTDS;
            Session.Remove("subcontractorCostsBySubcontractorDummy");
            subcontractorCosts = actualCostsAddTDS.SubcontractorCosts;
            Session["subcontractorCosts"] = actualCostsAddTDS.SubcontractorCosts;
        }

        


       

        // ////////////////////////////////////////////////////////////////////////
        // STEP2 - SUBCONTRACTOR COST BY SUBCONTRACTORS - AUXILIAR EVENTS
        //      

        protected void tbxQuantityFooter_TextChanged(object sender, EventArgs e)
        {
            Page.Validate("DataNew");
            if (Page.IsValid)
            {
                string quantity = ((TextBox)grdSubcontractorCostsBySubcontractor.FooterRow.FindControl("tbxQuantityFooter")).Text;
                decimal rate = decimal.Parse(((TextBox)grdSubcontractorCostsBySubcontractor.FooterRow.FindControl("tbxRateFooter")).Text);
                ((TextBox)grdSubcontractorCostsBySubcontractor.FooterRow.FindControl("tbxTotalFooter")).Text = decimal.Round((decimal.Parse(quantity) * rate), 2).ToString();
            }
        }



        protected void tbxQuantityEdit_TextChanged(object sender, EventArgs e)
        {
            Page.Validate("DataEdit");
            if (Page.IsValid)
            {
                string quantity = ((TextBox)grdSubcontractorCostsBySubcontractor.Rows[grdSubcontractorCostsBySubcontractor.EditIndex].FindControl("tbxQuantityEdit")).Text;
                decimal rate = decimal.Parse(((TextBox)grdSubcontractorCostsBySubcontractor.Rows[grdSubcontractorCostsBySubcontractor.EditIndex].FindControl("tbxRateEdit")).Text);
                ((TextBox)grdSubcontractorCostsBySubcontractor.Rows[grdSubcontractorCostsBySubcontractor.EditIndex].FindControl("tbxTotalEdit")).Text = decimal.Round((decimal.Parse(quantity) * rate), 2).ToString();
            }
        }



        protected void tbxRateFooter_TextChanged(object sender, EventArgs e)
        {
            Page.Validate("DataNew");
            if (Page.IsValid)
            {
                string quantity = ((TextBox)grdSubcontractorCostsBySubcontractor.FooterRow.FindControl("tbxQuantityFooter")).Text;
                decimal rate = decimal.Parse(((TextBox)grdSubcontractorCostsBySubcontractor.FooterRow.FindControl("tbxRateFooter")).Text);
                ((TextBox)grdSubcontractorCostsBySubcontractor.FooterRow.FindControl("tbxTotalFooter")).Text = decimal.Round((decimal.Parse(quantity) * rate), 2).ToString();
            }
        }



        protected void tbxRateEdit_TextChanged(object sender, EventArgs e)
        {
            Page.Validate("DataEdit");
            if (Page.IsValid)
            {
                string quantity = ((TextBox)grdSubcontractorCostsBySubcontractor.Rows[grdSubcontractorCostsBySubcontractor.EditIndex].FindControl("tbxQuantityEdit")).Text;
                decimal rate = decimal.Parse(((TextBox)grdSubcontractorCostsBySubcontractor.Rows[grdSubcontractorCostsBySubcontractor.EditIndex].FindControl("tbxRateEdit")).Text);
                ((TextBox)grdSubcontractorCostsBySubcontractor.Rows[grdSubcontractorCostsBySubcontractor.EditIndex].FindControl("tbxTotalEdit")).Text = decimal.Round((decimal.Parse(quantity) * rate), 2).ToString();
            }
        }        



        protected void ddlClientFooter_SelectedIndexChanged(object sender, EventArgs e)
        {            
            DropDownList ddlClientFooter = (DropDownList)sender;
            DropDownList ddlProjectFooter = ((DropDownList)grdSubcontractorCostsBySubcontractor.FooterRow.FindControl("ddlProjectFooter"));

            ProjectList projectList = new ProjectList();
            projectList.LoadProjectsAndAddItem(-1, "(Select a project)", int.Parse(ddlClientFooter.SelectedValue));
            ddlProjectFooter.DataSource = projectList.Table;
            ddlProjectFooter.DataValueField = "ProjectID";
            ddlProjectFooter.DataTextField = "Name";
            ddlProjectFooter.DataBind();               
        }



        protected void grdSubcontractorCostsBySubcontractor_DataBound(object sender, EventArgs e)
        {
            AddSubcontractorsNewEmptyFix(grdSubcontractorCostsBySubcontractor);
        }



        protected void grdSubcontractorCostsBySubcontractor_RowDataBound(object sender, GridViewRowEventArgs e)
        {           
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Normal) || (e.Row.RowState == (DataControlRowState.Normal | DataControlRowState.Alternate))))
            {
                // Get date
                DateTime date = DateTime.Parse(((Label)e.Row.FindControl("lblDate")).Text);

                // Set new format
                ((Label)e.Row.FindControl("lblDate")).Text = date.Month.ToString() + "/" + date.Day.ToString() + "/" + date.Year.ToString();
            }
        }



        protected void grdSubcontractorCostsBySubcontractor_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Page.Validate("DataEdit");
            if (Page.IsValid)
            {
                // Subcontractor Gridview, if the gridview is edition mode
                if (grdSubcontractorCostsBySubcontractor.EditIndex >= 0)
                {
                    grdSubcontractorCostsBySubcontractor.UpdateRow(grdSubcontractorCostsBySubcontractor.EditIndex, true);
                }

            }
        }

        




        // ////////////////////////////////////////////////////////////////////////
        //  STEP2 - SUBCONTRACTOR COST BY SUBCONTRACTORS - PUBLIC METHODS
        //

        public ActualCostsAddTDS.SubcontractorCostsDataTable GetSubcontractorCostsBySubcontractorDetail()
        {
            subcontractorCosts = (ActualCostsAddTDS.SubcontractorCostsDataTable)Session["subcontractorCostsBySubcontractorDummy"];
            if (subcontractorCosts == null)
            {
                subcontractorCosts = ((ActualCostsAddTDS.SubcontractorCostsDataTable)Session["subcontractorCosts"]);
            }

            return subcontractorCosts;
        }



        public void DummySubcontractorCostsBySubcontractorDetail(int ProjectID, int RefID, int original_ProjectID, int original_RefID)
        {
        }



        public void DummySubcontractorCostsBySubcontractorDetail(int original_ProjectID, int original_RefID)
        {
        }


        
     

        
        // ////////////////////////////////////////////////////////////////////////
        // STEP2 - SUBCONTRACTOR COST BY SUBCONTRACTORS - PRIVATE METHODS
        //

        private void StepSubcontractorCostsBySubcontractorIn()
        {
            // Set instruction
            Label title = (Label)this.Master.FindControl("lblInstruction");
            title.Text = "Add Costs By Subcontractor";
        }



        private bool StepSubcontractorCostsBySubcontractorPrevious()
        {
            return true;
        }



        private bool StepSubcontractorCostsBySubcontractorNext()
        {
            Page.Validate("generalData");
            if (Page.IsValid)
            {
                return true;
            }
            else
            {
                return false;
            }            
        }



        protected void AddSubcontractorsNewEmptyFix(GridView grdSubcontractorCostsBySubcontractor)
        {
            if (grdSubcontractorCostsBySubcontractor.Rows.Count == 0)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                ActualCostsAddTDS.SubcontractorCostsDataTable dt = new ActualCostsAddTDS.SubcontractorCostsDataTable();
                dt.AddSubcontractorCostsRow(-1, -1, -1, DateTime.Now, -1, -1, -1, -1, -1, "", false, companyId, false, "", 0, 0, "", "", 1);
                Session["subcontractorCostsBySubcontractorDummy"] = dt;

                grdSubcontractorCostsBySubcontractor.DataBind();
            }

            // normally executes at all postbacks
            if (grdSubcontractorCostsBySubcontractor.Rows.Count == 1)
            {
                ActualCostsAddTDS.SubcontractorCostsDataTable dt = (ActualCostsAddTDS.SubcontractorCostsDataTable)Session["subcontractorCostsBySubcontractorDummy"];
                if (dt != null)
                {
                    grdSubcontractorCostsBySubcontractor.Rows[0].Visible = false;
                    grdSubcontractorCostsBySubcontractor.Rows[0].Controls.Clear();
                }
            }
        }



        private void grdSubcontractorCostsBySubcontractorDetailAdd()
        {
            Page.Validate("generalData");
            if (Page.IsValid)
            {
                if (FooterValidate())
                {
                    Page.Validate("DataNew");
                    if (Page.IsValid)
                    {
                        int companyId = Int32.Parse(hdfCompanyId.Value);
                        DateTime date = (DateTime)((RadDatePicker)grdSubcontractorCostsBySubcontractor.FooterRow.FindControl("tkrdpDateFooter")).SelectedDate;

                        int subcontractorId = Int32.Parse(ddlSubcontractor.SelectedValue);
                        string name = ddlSubcontractor.SelectedItem.Text;

                        int clientId = Int32.Parse(((DropDownList)grdSubcontractorCostsBySubcontractor.FooterRow.FindControl("ddlClientFooter")).SelectedValue);
                        string client = ((DropDownList)grdSubcontractorCostsBySubcontractor.FooterRow.FindControl("ddlClientFooter")).SelectedItem.Text;

                        int projectId = Int32.Parse(((DropDownList)grdSubcontractorCostsBySubcontractor.FooterRow.FindControl("ddlProjectFooter")).SelectedValue);
                        string project = ((DropDownList)grdSubcontractorCostsBySubcontractor.FooterRow.FindControl("ddlProjectFooter")).SelectedItem.Text;

                        string quantityString = ((TextBox)grdSubcontractorCostsBySubcontractor.FooterRow.FindControl("tbxQuantityFooter")).Text;
                        decimal quantity1 = decimal.Round(decimal.Parse(quantityString), 1);
                        double quantity = double.Parse(quantity1.ToString());
                        decimal rate = decimal.Round(decimal.Parse(((TextBox)grdSubcontractorCostsBySubcontractor.FooterRow.FindControl("tbxRateFooter")).Text), 2);
                        decimal total = decimal.Round(decimal.Parse(((TextBox)grdSubcontractorCostsBySubcontractor.FooterRow.FindControl("tbxTotalFooter")).Text), 2);
                        string comment = ((TextBox)grdSubcontractorCostsBySubcontractor.FooterRow.FindControl("tbxCommentFooter")).Text;
                        bool deleted = false;
                        bool inDatabase = false;
                        decimal rateCad = 0;
                        decimal totalCad = 0;
                        decimal rateUsd = 0;
                        decimal totalUsd = 0;
                        ProjectGateway projectGateway = new ProjectGateway();
                        projectGateway.LoadByProjectId(projectId);

                        if (projectGateway.GetCountryID(projectId) == 1) //Canada
                        {
                            rateCad = rate;
                            totalCad = total;
                            rateUsd = rate;
                            totalUsd = total;
                        }
                        else
                        {
                            rateCad = rate;
                            totalCad = total;
                            rateUsd = rate;
                            totalUsd = total;
                        }

                        // Insert Data
                        ActualCostsAddSubcontractorCosts actualCostsAddSubcontractorCosts = new ActualCostsAddSubcontractorCosts(actualCostsAddTDS);
                        actualCostsAddSubcontractorCosts.Insert(projectId, subcontractorId, date, quantity, rateCad, totalCad, rateUsd, totalUsd, comment, deleted, companyId, inDatabase, name, client, project, clientId);

                        // Store dataset
                        Session["actualCostsAddTDS"] = actualCostsAddTDS;
                        Session.Remove("subcontractorCostsBySubcontractorDummy");
                        subcontractorCosts = actualCostsAddTDS.SubcontractorCosts;
                        Session["subcontractorCosts"] = actualCostsAddTDS.SubcontractorCosts;

                        grdSubcontractorCostsBySubcontractor.DataBind();
                        grdSubcontractorCostsBySubcontractor.PageIndex = grdSubcontractorCostsBySubcontractor.PageCount - 1;
                    }
                }
            }
        }



        protected bool FooterValidate()
        {
            int clientId = Int32.Parse(((DropDownList)grdSubcontractorCostsBySubcontractor.FooterRow.FindControl("ddlClientFooter")).SelectedValue);
            int projectId = Int32.Parse(((DropDownList)grdSubcontractorCostsBySubcontractor.FooterRow.FindControl("ddlProjectFooter")).SelectedValue);

            if (clientId != -1 && projectId != -1)
            {
                return true;
            }

            return false;
        }



        private bool ValidatePage()
        {
            bool valid = true;

            Page.Validate("DataNew");
            if (Page.IsValid)
            {
                Page.Validate("DataEdit");
                if (!Page.IsValid) valid = false;
            }

            return valid;
        }



     


        #endregion


        
        


        #region STEP3 - SUBCONTRACTOR COST BY CLIENT AND PROJECT

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP3 - SUBCONTRACTOR COST BY CLIENT AND PROJECT
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP3 - SUBCONTRACTOR COST BY CLIENT AND PROJECT -  EVENTS
        //

        protected void grdSubcontractorCostsByClientProject_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Subcontractor Gridview, if the gridview is edition mode
            if (grdSubcontractorCostsByClientProject.EditIndex >= 0)
            {
                grdSubcontractorCostsByClientProject.UpdateRow(grdSubcontractorCostsByClientProject.EditIndex, true);
            }

            // Delete subcontractor
            int projectId = (int)e.Keys["ProjectID"];
            int refId = (int)e.Keys["RefID"];

            // Delete costs details
            ActualCostsAddSubcontractorCosts subcontractorAddProjectSubcontractorsCosts = new ActualCostsAddSubcontractorCosts(actualCostsAddTDS);
            subcontractorAddProjectSubcontractorsCosts.Delete(projectId, refId);

            // Store dataset
            Session["actualCostsAddTDS"] = actualCostsAddTDS;
            Session.Remove("subcontractorCostsByClientProjectDummy");
            subcontractorCosts = actualCostsAddTDS.SubcontractorCosts;
            Session["subcontractorCosts"] = actualCostsAddTDS.SubcontractorCosts;
        }



        protected void grdSubcontractorCostsByClientProject_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Add":
                    // Subcontractor Gridview, if the gridview is edition mode
                    if (grdSubcontractorCostsByClientProject.EditIndex >= 0)
                    {
                        grdSubcontractorCostsByClientProject.UpdateRow(grdSubcontractorCostsByClientProject.EditIndex, true);
                    }

                    // Add New Subcontractor
                    grdSubcontractorCostsByClientProjectDetailAdd();
                    break;
            }
        }



        protected void grdSubcontractorCostsByClientProject_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.Validate("generalDataByClientProject");
            if (Page.IsValid)
            {
                Page.Validate("DataEditByClientProject");
                if (Page.IsValid)
                {
                    int companyId = Int32.Parse(hdfCompanyId.Value);
                    int refId = Int32.Parse(((Label)grdSubcontractorCostsByClientProject.Rows[e.RowIndex].FindControl("lblRefIdEditByClientProject")).Text);
                    DateTime date = (DateTime)((RadDatePicker)grdSubcontractorCostsByClientProject.Rows[e.RowIndex].FindControl("tkrdpDateEditByClientProject")).SelectedDate;

                    int subcontractorId = Int32.Parse(((DropDownList)grdSubcontractorCostsByClientProject.Rows[e.RowIndex].FindControl("ddlSubcontractorEditByClientProject")).SelectedValue);
                    string name = ((DropDownList)grdSubcontractorCostsByClientProject.Rows[e.RowIndex].FindControl("ddlSubcontractorEditByClientProject")).SelectedItem.Text;

                    string quantityString = ((TextBox)grdSubcontractorCostsByClientProject.Rows[e.RowIndex].FindControl("tbxQuantityEditByClientProject")).Text;
                    decimal quantity1 = decimal.Round(decimal.Parse(quantityString), 1);
                    double quantity = double.Parse(quantity1.ToString());

                    decimal rate = decimal.Round(decimal.Parse(((TextBox)grdSubcontractorCostsByClientProject.Rows[e.RowIndex].FindControl("tbxRateEditByClientProject")).Text), 2);
                    decimal total = decimal.Round(decimal.Parse(((TextBox)grdSubcontractorCostsByClientProject.Rows[e.RowIndex].FindControl("tbxTotalEditByClientProject")).Text), 2);
                    decimal rateCad = 0;
                    decimal totalCad = 0;
                    decimal rateUsd = 0;
                    decimal totalUsd = 0;
                    int projectId = Int32.Parse(ddlProjectByClientProject.SelectedValue);
                    ProjectGateway projectGateway = new ProjectGateway();
                    projectGateway.LoadByProjectId(projectId);

                    if (projectGateway.GetCountryID(projectId) == 1) //Canada
                    {
                        rateCad = rate;
                        totalCad = total;
                    }
                    else
                    {
                        rateUsd = rate;
                        totalUsd = total;
                    }

                    string comment = ((TextBox)grdSubcontractorCostsByClientProject.Rows[e.RowIndex].FindControl("tbxCommentEditByClientProject")).Text;
                    bool deleted = false;

                    // Update Data
                    ActualCostsAddSubcontractorCosts actualCostsAddSubcontractorCosts = new ActualCostsAddSubcontractorCosts(actualCostsAddTDS);
                    actualCostsAddSubcontractorCosts.Update(projectId, refId, subcontractorId, date, quantity, rateCad, totalCad, rateUsd, totalUsd, comment, deleted, companyId, name);

                    // Store dataset
                    Session["actualCostsAddTDS"] = actualCostsAddTDS;
                    Session.Remove("subcontractorCostsByClientProjectDummy");
                    subcontractorCosts = actualCostsAddTDS.SubcontractorCosts;
                    Session["subcontractorCosts"] = actualCostsAddTDS.SubcontractorCosts;
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP3 - SUBCONTRACTOR COST BY CLIENT AND PROJECT - AUXILIAR EVENTS
        //

        protected void ddlClientByClientProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProjectList projectList = new ProjectList();
            projectList.LoadProjectsAndAddItem(-1, "(Select a project)", int.Parse(ddlClientByClientProject.SelectedValue));
            ddlProjectByClientProject.DataSource = projectList.Table;
            ddlProjectByClientProject.DataValueField = "ProjectID";
            ddlProjectByClientProject.DataTextField = "Name";
            ddlProjectByClientProject.DataBind();
            ddlProjectByClientProject.SelectedIndex = 0;
        }



        protected void tbxQuantityFooterByClientProject_TextChanged(object sender, EventArgs e)
        {
            Page.Validate("DataNewByClientProject");
            if (Page.IsValid)
            {
                string quantity = ((TextBox)grdSubcontractorCostsByClientProject.FooterRow.FindControl("tbxQuantityFooterByClientProject")).Text;
                decimal rate = decimal.Parse(((TextBox)grdSubcontractorCostsByClientProject.FooterRow.FindControl("tbxRateFooterByClientProject")).Text);
                ((TextBox)grdSubcontractorCostsByClientProject.FooterRow.FindControl("tbxTotalFooterByClientProject")).Text = decimal.Round((decimal.Parse(quantity) * rate),2).ToString();
            }
        }



        protected void tbxQuantityEditByClientProject_TextChanged(object sender, EventArgs e)
        {
            Page.Validate("DataEditByClientProject");
            if (Page.IsValid)
            {
                string quantity = ((TextBox)grdSubcontractorCostsByClientProject.Rows[grdSubcontractorCostsByClientProject.EditIndex].FindControl("tbxQuantityEditByClientProject")).Text;
                decimal rate = decimal.Parse(((TextBox)grdSubcontractorCostsByClientProject.Rows[grdSubcontractorCostsByClientProject.EditIndex].FindControl("tbxRateEditByClientProject")).Text);
                ((TextBox)grdSubcontractorCostsByClientProject.Rows[grdSubcontractorCostsByClientProject.EditIndex].FindControl("tbxTotalEditByClientProject")).Text = decimal.Round((decimal.Parse(quantity) * rate),2).ToString();
            }
        }



        protected void tbxRateFooterByClientProject_TextChanged(object sender, EventArgs e)
        {
            Page.Validate("DataNewByClientProject");
            if (Page.IsValid)
            {
                string quantity = ((TextBox)grdSubcontractorCostsByClientProject.FooterRow.FindControl("tbxQuantityFooterByClientProject")).Text;
                decimal rate = decimal.Parse(((TextBox)grdSubcontractorCostsByClientProject.FooterRow.FindControl("tbxRateFooterByClientProject")).Text);
                ((TextBox)grdSubcontractorCostsByClientProject.FooterRow.FindControl("tbxTotalFooterByClientProject")).Text = decimal.Round((decimal.Parse(quantity) * rate),2).ToString();
            }
        }



        protected void tbxRateEditByClientProject_TextChanged(object sender, EventArgs e)
        {
            Page.Validate("DataEditByClientProject");
            if (Page.IsValid)
            {
                string quantity = ((TextBox)grdSubcontractorCostsByClientProject.Rows[grdSubcontractorCostsByClientProject.EditIndex].FindControl("tbxQuantityEditByClientProject")).Text;
                decimal rate = decimal.Parse(((TextBox)grdSubcontractorCostsByClientProject.Rows[grdSubcontractorCostsByClientProject.EditIndex].FindControl("tbxRateEditByClientProject")).Text);
                ((TextBox)grdSubcontractorCostsByClientProject.Rows[grdSubcontractorCostsByClientProject.EditIndex].FindControl("tbxTotalEditByClientProject")).Text = decimal.Round((decimal.Parse(quantity) * rate),2).ToString();
            }
        }



        protected void grdSubcontractorCostsByClientProject_DataBound(object sender, EventArgs e)
        {
            AddSubcontractorCostsByClientProjectNewEmptyFix(grdSubcontractorCostsByClientProject);
        }



        protected void grdSubcontractorCostsByClientProject_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Edit) || (e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
            {
                odsSubcontractorsListEditByClientProject.DataBind();

                string teamSubcontractorsId = ((Label)e.Row.FindControl("lblHotelIdEditHotelByClientProject")).Text.Trim();

                // Load actual id
                ((DropDownList)e.Row.FindControl("ddlSubcontractorEditByClientProject")).SelectedValue = teamSubcontractorsId;
            }

            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Normal) || (e.Row.RowState == (DataControlRowState.Normal | DataControlRowState.Alternate))))
            {
                // Get date
                DateTime date = DateTime.Parse(((Label)e.Row.FindControl("lblDateByClientProject")).Text);

                // Set new format
                ((Label)e.Row.FindControl("lblDateByClientProject")).Text = date.Month.ToString() + "/" + date.Day.ToString() + "/" + date.Year.ToString();
            }
        }



        protected void grdSubcontractorCostsByClientProject_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Subcontractor Gridview, if the gridview is edition mode
            if (grdSubcontractorCostsByClientProject.EditIndex >= 0)
            {
                grdSubcontractorCostsByClientProject.UpdateRow(grdSubcontractorCostsByClientProject.EditIndex, true);
            }
        }





        
        // ////////////////////////////////////////////////////////////////////////
        //  STEP3 - SUBCONTRACTOR COST BY CLIENT AND PROJECT - PUBLIC METHODS
        //

        public ActualCostsAddTDS.SubcontractorCostsDataTable GetSubcontractorsDetailByClientProject()
        {
            subcontractorCosts = (ActualCostsAddTDS.SubcontractorCostsDataTable)Session["subcontractorCostsByClientProjectDummy"];
            if (subcontractorCosts == null)
            {
                subcontractorCosts = ((ActualCostsAddTDS.SubcontractorCostsDataTable)Session["subcontractorCosts"]);
            }

            return subcontractorCosts;
        }



        public void DummySubcontractorsDetail(int ProjectID, int RefID, int original_ProjectID, int original_RefID)
        {
        }



        public void DummySubcontractorsDetail(int original_ProjectID, int original_RefID)
        {
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP3 - SUBCONTRACTOR COST BY CLIENT AND PROJECT - PRIVATE METHODS
        //

        private void StepSubcontractorCostsByClientProjectIn()
        {
            // Set instruction
            Label title = (Label)this.Master.FindControl("lblInstruction");
            title.Text = "Please add costs for Subcontractors By Client And Project.";            
        }



        private bool StepSubcontractorCostsByClientProjectPrevious()
        {
            return true;
        }



        private bool StepSubcontractorCostsByClientProjectNext()
        {
            Page.Validate("generalDataByClientProject");
            if (Page.IsValid)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        protected void AddSubcontractorCostsByClientProjectNewEmptyFix(GridView grdSubcontractorCostsByClientProject)
        {
            if (grdSubcontractorCostsByClientProject.Rows.Count == 0)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                ActualCostsAddTDS.SubcontractorCostsDataTable dt = new ActualCostsAddTDS.SubcontractorCostsDataTable();
                dt.AddSubcontractorCostsRow(-1, -1, -1, DateTime.Now, -1, -1, -1, -1, -1, "", false, companyId, false, "", 0, 0, "", "", 1);
                Session["subcontractorCostsByClientProjectDummy"] = dt;

                grdSubcontractorCostsByClientProject.DataBind();
            }

            // normally executes at all postbacks
            if (grdSubcontractorCostsByClientProject.Rows.Count == 1)
            {
                ActualCostsAddTDS.SubcontractorCostsDataTable dt = (ActualCostsAddTDS.SubcontractorCostsDataTable)Session["subcontractorCostsByClientProjectDummy"];
                if (dt != null)
                {
                    grdSubcontractorCostsByClientProject.Rows[0].Visible = false;
                    grdSubcontractorCostsByClientProject.Rows[0].Controls.Clear();
                }
            }
        }



        private void grdSubcontractorCostsByClientProjectDetailAdd()
        {
            Page.Validate("generalDataByClientProject");
            if (Page.IsValid)
            {
                int clientId = Int32.Parse(ddlClientByClientProject.SelectedValue);
                string client = ddlClientByClientProject.SelectedItem.Text;

                int projectId = Int32.Parse(ddlProjectByClientProject.SelectedValue);
                string project = ddlProjectByClientProject.SelectedItem.Text;
                
                if (FooterValidateByClientProject())
                {
                    Page.Validate("DataNewByClientProject");
                    if (Page.IsValid)
                    {
                        int companyId = Int32.Parse(hdfCompanyId.Value);
                        DateTime date = (DateTime)((RadDatePicker)grdSubcontractorCostsByClientProject.FooterRow.FindControl("tkrdpDateFooterByClientProject")).SelectedDate;

                        int subcontractorId = Int32.Parse(((DropDownList)grdSubcontractorCostsByClientProject.FooterRow.FindControl("ddlSubcontractorFooterByClientProject")).SelectedValue);
                        string name = ((DropDownList)grdSubcontractorCostsByClientProject.FooterRow.FindControl("ddlSubcontractorFooterByClientProject")).SelectedItem.Text;

                        string quantityString = ((TextBox)grdSubcontractorCostsByClientProject.FooterRow.FindControl("tbxQuantityFooterByClientProject")).Text;
                        decimal quantity1 = decimal.Round(decimal.Parse(quantityString), 1);
                        double quantity = double.Parse(quantity1.ToString());
                        decimal rate = decimal.Round(decimal.Parse(((TextBox)grdSubcontractorCostsByClientProject.FooterRow.FindControl("tbxRateFooterByClientProject")).Text), 2);
                        decimal total = decimal.Round(decimal.Parse(((TextBox)grdSubcontractorCostsByClientProject.FooterRow.FindControl("tbxTotalFooterByClientProject")).Text), 2);
                        string comment = ((TextBox)grdSubcontractorCostsByClientProject.FooterRow.FindControl("tbxCommentFooterByClientProject")).Text;
                        bool deleted = false;
                        bool inDatabase = false;                        
                        decimal rateCad = 0;
                        decimal totalCad = 0;
                        decimal rateUsd = 0;
                        decimal totalUsd = 0;
                        ProjectGateway projectGateway = new ProjectGateway();
                        projectGateway.LoadByProjectId(projectId);

                        if (projectGateway.GetCountryID(projectId) == 1) //Canada
                        {
                            rateCad = rate;
                            totalCad = total;                           
                        }
                        else
                        {
                            rateUsd = rate;
                            totalUsd = total;
                        }

                        // Insert Data
                        ActualCostsAddSubcontractorCosts actualCostsAddSubcontractorCosts = new ActualCostsAddSubcontractorCosts(actualCostsAddTDS);
                        actualCostsAddSubcontractorCosts.Insert(projectId, subcontractorId, date, quantity, rateCad, totalCad, rateUsd, totalUsd, comment, deleted, companyId, inDatabase, name, client, project, clientId);

                        // Store dataset
                        Session["actualCostsAddTDS"] = actualCostsAddTDS;
                        Session.Remove("subcontractorCostsByClientProjectDummy");
                        subcontractorCosts = actualCostsAddTDS.SubcontractorCosts;
                        Session["subcontractorCosts"] = actualCostsAddTDS.SubcontractorCosts;                        

                        grdSubcontractorCostsByClientProject.DataBind();
                        grdSubcontractorCostsByClientProject.PageIndex = grdSubcontractorCostsByClientProject.PageCount - 1;
                    }
                }
            }
        }



        protected bool FooterValidateByClientProject()
        {
            int subcontractorId = Int32.Parse(((DropDownList)grdSubcontractorCostsByClientProject.FooterRow.FindControl("ddlSubcontractorFooterByClientProject")).SelectedValue);

            if (subcontractorId != -1)
            {
                return true;
            }

            return false;
        }



        private bool ValidatePageByClientProject()
        {
            bool valid = true;

            Page.Validate("DataNewByClientProject");
            if (Page.IsValid)
            {
                Page.Validate("DataEditByClientProject");
                if (!Page.IsValid) valid = false;
            }

            return valid;
        }





        
        #endregion






        #region STEP4 - HOTEL COST BY CLIENT AND PROJECT

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP4 - HOTEL COST BY CLIENT AND PROJECT
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP4 - HOTEL COST BY CLIENT AND PROJECT -  EVENTS
        //

        protected void grdHotelCostsByClientProject_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Add":
                    // Hotel Gridview, if the gridview is edition mode
                    if (grdHotelCostsByClientProject.EditIndex >= 0)
                    {
                        grdHotelCostsByClientProject.UpdateRow(grdHotelCostsByClientProject.EditIndex, true);
                    }

                    // Add New Hotel
                    grdHotelCostsByClientProjectDetailAdd();
                    break;
            }
        }


        
        protected void grdHotelCostsByClientProject_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {            
            Page.Validate("DataEditHotelByClientProject");
            if (Page.IsValid)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                int refId = Int32.Parse(((Label)grdHotelCostsByClientProject.Rows[e.RowIndex].FindControl("lblRefIdEditHotelByClientProject")).Text);
                DateTime date = (DateTime)((RadDatePicker)grdHotelCostsByClientProject.Rows[e.RowIndex].FindControl("tkrdpDateEditHotelByClientProject")).SelectedDate;

                int hotelId = Int32.Parse(((DropDownList)grdHotelCostsByClientProject.Rows[e.RowIndex].FindControl("ddlHotelEditHotelByClientProject")).Text);
                string name = ((DropDownList)grdHotelCostsByClientProject.Rows[e.RowIndex].FindControl("ddlHotelEditHotelByClientProject")).SelectedItem.Text;

                int projectId = Int32.Parse(((Label)grdHotelCostsByClientProject.Rows[e.RowIndex].FindControl("lblProjectIdEditHotelByClientProject")).Text);

                decimal rate = decimal.Round(decimal.Parse(((TextBox)grdHotelCostsByClientProject.Rows[e.RowIndex].FindControl("tbxRateEditHotelByClientProject")).Text), 2);                
                decimal rateCad = 0;                
                decimal rateUsd = 0;                

                ProjectGateway projectGateway = new ProjectGateway();
                projectGateway.LoadByProjectId(projectId);

                if (projectGateway.GetCountryID(projectId) == 1) //Canada
                {
                    rateCad = rate;                    
                }
                else
                {
                    rateUsd = rate;                    
                }

                string comment = ((TextBox)grdHotelCostsByClientProject.Rows[e.RowIndex].FindControl("tbxCommentEditHotelByClientProject")).Text;
                bool deleted = false;

                // Update Data
                ActualCostsAddHotelCosts actualCostsAddHotelCosts = new ActualCostsAddHotelCosts(actualCostsAddTDS);
                actualCostsAddHotelCosts.Update(projectId, refId, hotelId, date, rateCad, rateUsd, comment, deleted, companyId, name);

                // Store dataset                                
                Session.Remove("hotelCostsByClientProjectDummy");
                
                Session["actualCostsAddTDS"] = actualCostsAddTDS;                
                Session["hotelCosts"] = actualCostsAddTDS.HotelCosts;
                
                hotelCosts = actualCostsAddTDS.HotelCosts;                
            }
            else
            {
                e.Cancel = true;
            }            
        }



        protected void grdHotelCostsByClientProject_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Hotel Gridview, if the gridview is edition mode
            if (grdHotelCostsByClientProject.EditIndex >= 0)
            {
                grdHotelCostsByClientProject.UpdateRow(grdHotelCostsByClientProject.EditIndex, true);
            }

            // Delete Hotel
            int projectId = (int)e.Keys["ProjectID"];
            int refId = (int)e.Keys["RefID"];

            // Delete costs details
            ActualCostsAddHotelCosts actualCostsAddHotelCosts = new ActualCostsAddHotelCosts(actualCostsAddTDS);
            actualCostsAddHotelCosts.Delete(projectId, refId);

            // Store dataset                                
            Session.Remove("hotelCostsByClientProjectDummy");

            Session["actualCostsAddTDS"] = actualCostsAddTDS;
            Session["hotelCosts"] = actualCostsAddTDS.HotelCosts;

            hotelCosts = actualCostsAddTDS.HotelCosts; 
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP4 - HOTEL COST BY CLIENT AND PROJECT - AUXILIAR EVENTS
        //                  

        protected void ddlClientFooterHotelByClientProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlClientFooter = (DropDownList)sender;
            DropDownList ddlProjectFooterHotelByClientProject = ((DropDownList)grdHotelCostsByClientProject.FooterRow.FindControl("ddlProjectFooterHotelByClientProject"));

            ProjectList projectList = new ProjectList();
            projectList.LoadProjectsAndAddItem(-1, "(Select a project)", int.Parse(ddlClientFooter.SelectedValue));
            ddlProjectFooterHotelByClientProject.DataSource = projectList.Table;
            ddlProjectFooterHotelByClientProject.DataValueField = "ProjectID";
            ddlProjectFooterHotelByClientProject.DataTextField = "Name";
            ddlProjectFooterHotelByClientProject.DataBind();
        }



        protected void grdHotelCostsByClientProject_DataBound(object sender, EventArgs e)
        {
            AddHotelCostsNewEmptyFix(grdHotelCostsByClientProject);
        }



        protected void grdHotelCostsByClientProject_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Edit) || (e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
            {
                odsHotelListEditHotelByClientProject.DataBind();

                string hotelId = ((Label)e.Row.FindControl("lblHotelIdEditHotelByClientProject")).Text.Trim();

                // Load actual id
                ((DropDownList)e.Row.FindControl("ddlHotelEditHotelByClientProject")).SelectedValue = hotelId;
            }

            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Normal) || (e.Row.RowState == (DataControlRowState.Normal | DataControlRowState.Alternate))))
            {
                // Get date
                DateTime date = DateTime.Parse(((Label)e.Row.FindControl("lblDateHotelByClientProject")).Text);

                // Set new format
                ((Label)e.Row.FindControl("lblDateHotelByClientProject")).Text = date.Month.ToString() + "/" + date.Day.ToString() + "/" + date.Year.ToString();
            }
        }



        protected void grdHotelCostsByClientProject_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Page.Validate("DataEditHotelByClientProject");
            if (Page.IsValid)
            {
                // Hotel Gridview, if the gridview is edition mode
                if (grdHotelCostsByClientProject.EditIndex >= 0)
                {
                    grdHotelCostsByClientProject.UpdateRow(grdHotelCostsByClientProject.EditIndex, true);
                }

            }
        }






        // ////////////////////////////////////////////////////////////////////////
        //  STEP4 - HOTEL COST BY CLIENT AND PROJECT - PUBLIC METHODS
        //

        public ActualCostsAddTDS.HotelCostsDataTable GetHotelDetailHotelByClientProject()
        {
            hotelCosts = (ActualCostsAddTDS.HotelCostsDataTable)Session["hotelCostsByClientProjectDummy"];
            if (hotelCosts == null)
            {
                hotelCosts = ((ActualCostsAddTDS.HotelCostsDataTable)Session["hotelCosts"]);
            }

            return hotelCosts;
        }



        public void DummyHotelDetail(int ProjectID, int RefID, int original_ProjectID, int original_RefID)
        {
        }



        public void DummyHotelDetail(int original_ProjectID, int original_RefID)
        {
        }


        
     

        
        // ////////////////////////////////////////////////////////////////////////
        // STEP4 - HOTEL COST BY CLIENT AND PROJECT - PRIVATE METHODS
        //

        private void StepHotelCostsByClientProjectIn()
        {
            // Set instruction
            Label title = (Label)this.Master.FindControl("lblInstruction");
            title.Text = "Please add costs for Hotels By Client And Project.";            
        }



        private bool StepHotelCostsByClientProjectPrevious()
        {
            return true;
        }



        private bool StepHotelCostsByClientProjectNext()
        {
            Page.Validate("generalDataHotelByClientProject");
            if (Page.IsValid)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        protected void AddHotelCostsNewEmptyFix(GridView grdHotelCostsByClientProject)
        {            
            if (grdHotelCostsByClientProject.Rows.Count == 0)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                ActualCostsAddTDS.HotelCostsDataTable dt = new ActualCostsAddTDS.HotelCostsDataTable();
                dt.AddHotelCostsRow(-1, -1, DateTime.Now, -1, -1, "", false, companyId, false, "", 0, "", "", 1);
                Session["hotelCostsByClientProjectDummy"] = dt;

                grdHotelCostsByClientProject.DataBind();
            }

            // normally executes at all postbacks
            if (grdHotelCostsByClientProject.Rows.Count == 1)
            {
                ActualCostsAddTDS.HotelCostsDataTable dt = (ActualCostsAddTDS.HotelCostsDataTable)Session["hotelCostsByClientProjectDummy"];
                if (dt != null)
                {
                    grdHotelCostsByClientProject.Rows[0].Visible = false;
                    grdHotelCostsByClientProject.Rows[0].Controls.Clear();
                }
            }
        }



        private void grdHotelCostsByClientProjectDetailAdd()
        {            
            if (FooterValidateHotelByClientProject())
            {
                Page.Validate("DataNewHotelByClientProject");
                if (Page.IsValid)
                {
                    int companyId = Int32.Parse(hdfCompanyId.Value);
                    DateTime date = (DateTime)((RadDatePicker)grdHotelCostsByClientProject.FooterRow.FindControl("tkrdpDateFooterHotelByClientProject")).SelectedDate;

                    int hotelId = Int32.Parse(((DropDownList)grdHotelCostsByClientProject.FooterRow.FindControl("ddlHotelFooterHotelByClientProject")).Text);
                    string name = ((DropDownList)grdHotelCostsByClientProject.FooterRow.FindControl("ddlHotelFooterHotelByClientProject")).SelectedItem.Text;

                    int clientId = Int32.Parse(((DropDownList)grdHotelCostsByClientProject.FooterRow.FindControl("ddlClientFooterHotelByClientProject")).SelectedValue);
                    string client = ((DropDownList)grdHotelCostsByClientProject.FooterRow.FindControl("ddlClientFooterHotelByClientProject")).SelectedItem.Text;

                    int projectId = Int32.Parse(((DropDownList)grdHotelCostsByClientProject.FooterRow.FindControl("ddlProjectFooterHotelByClientProject")).SelectedValue);
                    string project = ((DropDownList)grdHotelCostsByClientProject.FooterRow.FindControl("ddlProjectFooterHotelByClientProject")).SelectedItem.Text;

                    decimal rate = decimal.Round(decimal.Parse(((TextBox)grdHotelCostsByClientProject.FooterRow.FindControl("tbxRateFooterHotelByClientProject")).Text), 2);
                    string comment = ((TextBox)grdHotelCostsByClientProject.FooterRow.FindControl("tbxCommentFooterHotelByClientProject")).Text;
                    bool deleted = false;
                    bool inDatabase = false;
                    decimal rateCad = 0;                        
                    decimal rateUsd = 0;                        
                    ProjectGateway projectGateway = new ProjectGateway();
                    projectGateway.LoadByProjectId(projectId);

                    if (projectGateway.GetCountryID(projectId) == 1) //Canada
                    {
                        rateCad = rate;                            
                        rateUsd = rate;                            
                    }
                    else
                    {
                        rateCad = rate;
                        rateUsd = rate;
                    }

                    // Insert Data
                    ActualCostsAddHotelCosts actualCostsAddHotelCosts = new ActualCostsAddHotelCosts(actualCostsAddTDS);
                    actualCostsAddHotelCosts.Insert(projectId, hotelId, date, rateCad, rateUsd, comment, deleted, companyId, inDatabase, name, client, project, clientId);

                    // Store dataset                                
                    Session.Remove("hotelCostsByClientProjectDummy");

                    Session["actualCostsAddTDS"] = actualCostsAddTDS;
                    Session["hotelCosts"] = actualCostsAddTDS.HotelCosts;

                    hotelCosts = actualCostsAddTDS.HotelCosts; 

                    grdHotelCostsByClientProject.DataBind();
                    grdHotelCostsByClientProject.PageIndex = grdHotelCostsByClientProject.PageCount - 1;
                }
            }            
        }



        protected bool FooterValidateHotelByClientProject()
        {
            int clientId = Int32.Parse(((DropDownList)grdHotelCostsByClientProject.FooterRow.FindControl("ddlClientFooterHotelByClientProject")).SelectedValue);
            int projectId = Int32.Parse(((DropDownList)grdHotelCostsByClientProject.FooterRow.FindControl("ddlProjectFooterHotelByClientProject")).SelectedValue);
            int hotelId = Int32.Parse(((DropDownList)grdHotelCostsByClientProject.FooterRow.FindControl("ddlHotelFooterHotelByClientProject")).SelectedValue);

            if ((clientId != -1) && (projectId != -1) && (projectId != -1))
            {
                return true;
            }

            return false;
        }



        private bool ValidatePageHotelByClientProject()
        {
            bool valid = true;

            Page.Validate("DataNewHotelByClientProject");
            if (Page.IsValid)
            {
                Page.Validate("DataEditHotelByClientProject");
                if (!Page.IsValid) valid = false;
            }

            return valid;
        }




        #endregion






        #region STEP5 - BONDING COMPANIES COST BY CLIENT AND PROJECT

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP5 - BONDING COMPANIES COST BY CLIENT AND PROJECT
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP5 - BONDING COMPANIES COST BY CLIENT AND PROJECT -  EVENTS
        //

        protected void grdBondingCompaniesCostsByClientProject_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Add":
                    // BondingCompanies Gridview, if the gridview is edition mode
                    if (grdBondingCompaniesCostsByClientProject.EditIndex >= 0)
                    {
                        grdBondingCompaniesCostsByClientProject.UpdateRow(grdBondingCompaniesCostsByClientProject.EditIndex, true);
                    }

                    // Add New BondingCompanies
                    grdBondingCompaniesCostsByClientProjectDetailAdd();
                    break;
            }
        }



        protected void grdBondingCompaniesCostsByClientProject_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.Validate("DataEditBondingCompaniesByClientProject");
            if (Page.IsValid)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                int refId = Int32.Parse(((Label)grdBondingCompaniesCostsByClientProject.Rows[e.RowIndex].FindControl("lblRefIdEditBondingCompaniesByClientProject")).Text);
                DateTime date = (DateTime)((RadDatePicker)grdBondingCompaniesCostsByClientProject.Rows[e.RowIndex].FindControl("tkrdpDateEditBondingCompaniesByClientProject")).SelectedDate;

                int bondingCompanyId = Int32.Parse(((DropDownList)grdBondingCompaniesCostsByClientProject.Rows[e.RowIndex].FindControl("ddlBondingCompaniesEditBondingCompaniesByClientProject")).Text);
                string name = ((DropDownList)grdBondingCompaniesCostsByClientProject.Rows[e.RowIndex].FindControl("ddlBondingCompaniesEditBondingCompaniesByClientProject")).SelectedItem.Text;

                int projectId = Int32.Parse(((Label)grdBondingCompaniesCostsByClientProject.Rows[e.RowIndex].FindControl("lblProjectIdEditBondingCompaniesByClientProject")).Text);

                decimal rate = decimal.Round(decimal.Parse(((TextBox)grdBondingCompaniesCostsByClientProject.Rows[e.RowIndex].FindControl("tbxRateEditBondingCompaniesByClientProject")).Text), 2);
                decimal rateCad = 0;
                decimal rateUsd = 0;

                ProjectGateway projectGateway = new ProjectGateway();
                projectGateway.LoadByProjectId(projectId);

                if (projectGateway.GetCountryID(projectId) == 1) //Canada
                {
                    rateCad = rate;
                }
                else
                {
                    rateUsd = rate;
                }

                string comment = ((TextBox)grdBondingCompaniesCostsByClientProject.Rows[e.RowIndex].FindControl("tbxCommentEditBondingCompaniesByClientProject")).Text;
                bool deleted = false;

                // Update Data
                ActualCostsAddBondingCompaniesCosts actualCostsAddBondingCompaniesCosts = new ActualCostsAddBondingCompaniesCosts(actualCostsAddTDS);
                actualCostsAddBondingCompaniesCosts.Update(projectId, refId, bondingCompanyId, date, rateCad, rateUsd, comment, deleted, companyId, name);

                // Store dataset                
                Session.Remove("subcontractorCostsBySubcontractorDummy");
                Session.Remove("bondingCompaniesCostsByClientProjectDummy");

                Session["actualCostsAddTDS"] = actualCostsAddTDS;                
                Session["bondingCompaniesCosts"] = actualCostsAddTDS.BondingCompaniesCosts;
                
                bondingCompaniesCosts = actualCostsAddTDS.BondingCompaniesCosts;
            }
            else
            {
                e.Cancel = true;
            }
        }



        protected void grdBondingCompaniesCostsByClientProject_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // BondingCompanies Gridview, if the gridview is edition mode
            if (grdBondingCompaniesCostsByClientProject.EditIndex >= 0)
            {
                grdBondingCompaniesCostsByClientProject.UpdateRow(grdBondingCompaniesCostsByClientProject.EditIndex, true);
            }

            // Delete BondingCompanies
            int projectId = (int)e.Keys["ProjectID"];
            int refId = (int)e.Keys["RefID"];

            // Delete costs details
            ActualCostsAddBondingCompaniesCosts actualCostsAddBondingCompaniesCosts = new ActualCostsAddBondingCompaniesCosts(actualCostsAddTDS);
            actualCostsAddBondingCompaniesCosts.Delete(projectId, refId);

            // Store dataset                
            Session.Remove("subcontractorCostsBySubcontractorDummy");
            Session.Remove("bondingCompaniesCostsByClientProjectDummy");

            Session["actualCostsAddTDS"] = actualCostsAddTDS;
            Session["bondingCompaniesCosts"] = actualCostsAddTDS.BondingCompaniesCosts;

            bondingCompaniesCosts = actualCostsAddTDS.BondingCompaniesCosts;
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP5 - BONDING COMPANIES COST BY CLIENT AND PROJECT - AUXILIAR EVENTS
        //

        protected void ddlClientFooterBondingCompaniesByClientProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlClientFooter = (DropDownList)sender;
            DropDownList ddlProjectFooterBondingCompaniesByClientProject = ((DropDownList)grdBondingCompaniesCostsByClientProject.FooterRow.FindControl("ddlProjectFooterBondingCompaniesByClientProject"));

            ProjectList projectList = new ProjectList();
            projectList.LoadProjectsAndAddItem(-1, "(Select a project)", int.Parse(ddlClientFooter.SelectedValue));
            ddlProjectFooterBondingCompaniesByClientProject.DataSource = projectList.Table;
            ddlProjectFooterBondingCompaniesByClientProject.DataValueField = "ProjectID";
            ddlProjectFooterBondingCompaniesByClientProject.DataTextField = "Name";
            ddlProjectFooterBondingCompaniesByClientProject.DataBind();
        }



        protected void grdBondingCompaniesCostsByClientProject_DataBound(object sender, EventArgs e)
        {
            AddBondingCompaniesCostsNewEmptyFix(grdBondingCompaniesCostsByClientProject);
        }



        protected void grdBondingCompaniesCostsByClientProject_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Edit) || (e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
            {
                odsBondingCompaniesListEditBondingCompaniesByClientProject.DataBind();

                string bondingCompanyId = ((Label)e.Row.FindControl("lblBondingCompanyIdEditBondingCompaniesByClientProject")).Text.Trim();

                // Load actual id
                ((DropDownList)e.Row.FindControl("ddlBondingCompaniesEditBondingCompaniesByClientProject")).SelectedValue = bondingCompanyId;
            }

            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Normal) || (e.Row.RowState == (DataControlRowState.Normal | DataControlRowState.Alternate))))
            {
                // Get date
                DateTime date = DateTime.Parse(((Label)e.Row.FindControl("lblDateBondingCompaniesByClientProject")).Text);

                // Set new format
                ((Label)e.Row.FindControl("lblDateBondingCompaniesByClientProject")).Text = date.Month.ToString() + "/" + date.Day.ToString() + "/" + date.Year.ToString();
            }
        }



        protected void grdBondingCompaniesCostsByClientProject_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Page.Validate("DataEditBondingCompaniesByClientProject");
            if (Page.IsValid)
            {
                // BondingCompanies Gridview, if the gridview is edition mode
                if (grdBondingCompaniesCostsByClientProject.EditIndex >= 0)
                {
                    grdBondingCompaniesCostsByClientProject.UpdateRow(grdBondingCompaniesCostsByClientProject.EditIndex, true);
                }

            }
        }







        // ////////////////////////////////////////////////////////////////////////
        //  STEP5 - BONDING COMPANIES COST BY CLIENT AND PROJECT - PUBLIC METHODS
        //

        public ActualCostsAddTDS.BondingCompaniesCostsDataTable GetBondingCompaniesDetailBondingCompaniesByClientProject()
        {
            bondingCompaniesCosts = (ActualCostsAddTDS.BondingCompaniesCostsDataTable)Session["bondingCompaniesCostsByClientProjectDummy"];
            if (bondingCompaniesCosts == null)
            {
                bondingCompaniesCosts = ((ActualCostsAddTDS.BondingCompaniesCostsDataTable)Session["bondingCompaniesCosts"]);
            }

            return bondingCompaniesCosts;
        }



        public void DummyBondingCompaniesDetail(int ProjectID, int RefID, int original_ProjectID, int original_RefID)
        {
        }



        public void DummyBondingCompaniesDetail(int original_ProjectID, int original_RefID)
        {
        }


        
         


        // ////////////////////////////////////////////////////////////////////////
        // STEP5 - BONDING COMPANIES COST BY CLIENT AND PROJECT - PRIVATE METHODS
        //

        private void StepBondingCompaniesCostsByClientProjectIn()
        {
            // Set instruction
            Label title = (Label)this.Master.FindControl("lblInstruction");
            title.Text = "Please add costs for Bonding Companies By Client And Project.";            
        }



        private bool StepBondingCompaniesCostsByClientProjectPrevious()
        {
            return true;
        }



        private bool StepBondingCompaniesCostsByClientProjectNext()
        {
            Page.Validate("generalDataBondingByClientProject");
            if (Page.IsValid)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        protected void AddBondingCompaniesCostsNewEmptyFix(GridView grdBondingCompaniesCostsByClientProject)
        {
            if (grdBondingCompaniesCostsByClientProject.Rows.Count == 0)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                ActualCostsAddTDS.BondingCompaniesCostsDataTable dt = new ActualCostsAddTDS.BondingCompaniesCostsDataTable();
                dt.AddBondingCompaniesCostsRow(-1, -1, DateTime.Now, -1, -1, "", false, companyId, false, "", 0, "", "", 1);
                Session["bondingCompaniesCostsByClientProjectDummy"] = dt;

                grdBondingCompaniesCostsByClientProject.DataBind();
            }

            // normally executes at all postbacks
            if (grdBondingCompaniesCostsByClientProject.Rows.Count == 1)
            {
                ActualCostsAddTDS.BondingCompaniesCostsDataTable dt = (ActualCostsAddTDS.BondingCompaniesCostsDataTable)Session["bondingCompaniesCostsByClientProjectDummy"];
                if (dt != null)
                {
                    grdBondingCompaniesCostsByClientProject.Rows[0].Visible = false;
                    grdBondingCompaniesCostsByClientProject.Rows[0].Controls.Clear();
                }
            }
        }



        private void grdBondingCompaniesCostsByClientProjectDetailAdd()
        {
            if (FooterValidateBondingCompaniesByClientProject())
            {
                Page.Validate("DataNewBondingCompaniesByClientProject");
                if (Page.IsValid)
                {
                    int companyId = Int32.Parse(hdfCompanyId.Value);
                    DateTime date = (DateTime)((RadDatePicker)grdBondingCompaniesCostsByClientProject.FooterRow.FindControl("tkrdpDateFooterBondingCompaniesByClientProject")).SelectedDate;

                    int bondingCompanyId = Int32.Parse(((DropDownList)grdBondingCompaniesCostsByClientProject.FooterRow.FindControl("ddlBondingCompaniesFooterBondingCompaniesByClientProject")).Text);
                    string name = ((DropDownList)grdBondingCompaniesCostsByClientProject.FooterRow.FindControl("ddlBondingCompaniesFooterBondingCompaniesByClientProject")).SelectedItem.Text;

                    int clientId = Int32.Parse(((DropDownList)grdBondingCompaniesCostsByClientProject.FooterRow.FindControl("ddlClientFooterBondingCompaniesByClientProject")).SelectedValue);
                    string client = ((DropDownList)grdBondingCompaniesCostsByClientProject.FooterRow.FindControl("ddlClientFooterBondingCompaniesByClientProject")).SelectedItem.Text;

                    int projectId = Int32.Parse(((DropDownList)grdBondingCompaniesCostsByClientProject.FooterRow.FindControl("ddlProjectFooterBondingCompaniesByClientProject")).SelectedValue);
                    string project = ((DropDownList)grdBondingCompaniesCostsByClientProject.FooterRow.FindControl("ddlProjectFooterBondingCompaniesByClientProject")).SelectedItem.Text;

                    decimal rate = decimal.Round(decimal.Parse(((TextBox)grdBondingCompaniesCostsByClientProject.FooterRow.FindControl("tbxRateFooterBondingCompaniesByClientProject")).Text), 2);
                    string comment = ((TextBox)grdBondingCompaniesCostsByClientProject.FooterRow.FindControl("tbxCommentFooterBondingCompaniesByClientProject")).Text;
                    bool deleted = false;
                    bool inDatabase = false;
                    decimal rateCad = 0;
                    decimal rateUsd = 0;
                    ProjectGateway projectGateway = new ProjectGateway();
                    projectGateway.LoadByProjectId(projectId);

                    if (projectGateway.GetCountryID(projectId) == 1) //Canada
                    {
                        rateCad = rate;
                        rateUsd = rate;
                    }
                    else
                    {
                        rateCad = rate;
                        rateUsd = rate;
                    }

                    // Insert Data
                    ActualCostsAddBondingCompaniesCosts actualCostsAddBondingCompaniesCosts = new ActualCostsAddBondingCompaniesCosts(actualCostsAddTDS);
                    actualCostsAddBondingCompaniesCosts.Insert(projectId, bondingCompanyId, date, rateCad, rateUsd, comment, deleted, companyId, inDatabase, name, client, project, clientId);

                    // Store dataset                
                    Session.Remove("subcontractorCostsBySubcontractorDummy");
                    Session.Remove("bondingCompaniesCostsByClientProjectDummy");

                    Session["actualCostsAddTDS"] = actualCostsAddTDS;
                    Session["bondingCompaniesCosts"] = actualCostsAddTDS.BondingCompaniesCosts;

                    bondingCompaniesCosts = actualCostsAddTDS.BondingCompaniesCosts;

                    grdBondingCompaniesCostsByClientProject.DataBind();
                    grdBondingCompaniesCostsByClientProject.PageIndex = grdBondingCompaniesCostsByClientProject.PageCount - 1;
                }
            }
        }



        protected bool FooterValidateBondingCompaniesByClientProject()
        {
            int clientId = Int32.Parse(((DropDownList)grdBondingCompaniesCostsByClientProject.FooterRow.FindControl("ddlClientFooterBondingCompaniesByClientProject")).SelectedValue);
            int projectId = Int32.Parse(((DropDownList)grdBondingCompaniesCostsByClientProject.FooterRow.FindControl("ddlProjectFooterBondingCompaniesByClientProject")).SelectedValue);
            int bondingCompanyId = Int32.Parse(((DropDownList)grdBondingCompaniesCostsByClientProject.FooterRow.FindControl("ddlBondingCompaniesFooterBondingCompaniesByClientProject")).SelectedValue);

            if ((clientId != -1) && (projectId != -1) && (projectId != -1))
            {
                return true;
            }

            return false;
        }



        private bool ValidatePageBondingCompaniesByClientProject()
        {
            bool valid = true;

            Page.Validate("DataNewBondingCompaniesByClientProject");
            if (Page.IsValid)
            {
                Page.Validate("DataEditBondingCompaniesByClientProject");
                if (!Page.IsValid) valid = false;
            }

            return valid;
        }






        #endregion






        #region STEP6 - INSURANCE COMPANIES COST BY SUBCONTRACTORS

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP6 - INSURANCE COMPANIES COST BY CLIENT AND PROJECT
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP6 - INSURANCE COMPANIES COST BY CLIENT AND PROJECT -  EVENTS
        //

        protected void grdInsuranceCompaniesCostsByClientProject_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Add":
                    // InsuranceCompanies Gridview, if the gridview is edition mode
                    if (grdInsuranceCompaniesCostsByClientProject.EditIndex >= 0)
                    {
                        grdInsuranceCompaniesCostsByClientProject.UpdateRow(grdInsuranceCompaniesCostsByClientProject.EditIndex, true);
                    }

                    // Add New InsuranceCompanies
                    grdInsuranceCompaniesCostsByClientProjectDetailAdd();
                    break;
            }
        }



        protected void grdInsuranceCompaniesCostsByClientProject_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.Validate("DataEditInsuranceCompaniesByClientProject");
            if (Page.IsValid)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                int refId = Int32.Parse(((Label)grdInsuranceCompaniesCostsByClientProject.Rows[e.RowIndex].FindControl("lblRefIdEditInsuranceCompaniesByClientProject")).Text);
                DateTime date = (DateTime)((RadDatePicker)grdInsuranceCompaniesCostsByClientProject.Rows[e.RowIndex].FindControl("tkrdpDateEditInsuranceCompaniesByClientProject")).SelectedDate;

                int insuranceCompanyId = Int32.Parse(((DropDownList)grdInsuranceCompaniesCostsByClientProject.Rows[e.RowIndex].FindControl("ddlInsuranceCompaniesEditInsuranceCompaniesByClientProject")).Text);
                string name = ((DropDownList)grdInsuranceCompaniesCostsByClientProject.Rows[e.RowIndex].FindControl("ddlInsuranceCompaniesEditInsuranceCompaniesByClientProject")).SelectedItem.Text;

                int projectId = Int32.Parse(((Label)grdInsuranceCompaniesCostsByClientProject.Rows[e.RowIndex].FindControl("lblProjectIdEditInsuranceCompaniesByClientProject")).Text);

                decimal rate = decimal.Round(decimal.Parse(((TextBox)grdInsuranceCompaniesCostsByClientProject.Rows[e.RowIndex].FindControl("tbxRateEditInsuranceCompaniesByClientProject")).Text), 2);
                decimal rateCad = 0;
                decimal rateUsd = 0;

                ProjectGateway projectGateway = new ProjectGateway();
                projectGateway.LoadByProjectId(projectId);

                if (projectGateway.GetCountryID(projectId) == 1) //Canada
                {
                    rateCad = rate;
                }
                else
                {
                    rateUsd = rate;
                }

                string comment = ((TextBox)grdInsuranceCompaniesCostsByClientProject.Rows[e.RowIndex].FindControl("tbxCommentEditInsuranceCompaniesByClientProject")).Text;
                bool deleted = false;

                // Update Data
                ActualCostsAddInsuranceCompaniesCosts actualCostsAddInsuranceCompaniesCosts = new ActualCostsAddInsuranceCompaniesCosts(actualCostsAddTDS);
                actualCostsAddInsuranceCompaniesCosts.Update(projectId, refId, insuranceCompanyId, date, rateCad, rateUsd, comment, deleted, companyId, name);

                // Store dataset                                
                Session.Remove("insuranceCompaniesCostsByClientProjectDummy");

                Session["actualCostsAddTDS"] = actualCostsAddTDS;                
                Session["insuranceCompaniesCosts"] = actualCostsAddTDS.InsuranceCompaniesCosts;
                
                insuranceCompaniesCosts = actualCostsAddTDS.InsuranceCompaniesCosts;
            }
            else
            {
                e.Cancel = true;
            }
        }



        protected void grdInsuranceCompaniesCostsByClientProject_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // InsuranceCompanies Gridview, if the gridview is edition mode
            if (grdInsuranceCompaniesCostsByClientProject.EditIndex >= 0)
            {
                grdInsuranceCompaniesCostsByClientProject.UpdateRow(grdInsuranceCompaniesCostsByClientProject.EditIndex, true);
            }

            // Delete InsuranceCompanies
            int projectId = (int)e.Keys["ProjectID"];
            int refId = (int)e.Keys["RefID"];

            // Delete costs details
            ActualCostsAddInsuranceCompaniesCosts actualCostsAddInsuranceCompaniesCosts = new ActualCostsAddInsuranceCompaniesCosts(actualCostsAddTDS);
            actualCostsAddInsuranceCompaniesCosts.Delete(projectId, refId);

            // Store dataset                                
            Session.Remove("insuranceCompaniesCostsByClientProjectDummy");

            Session["actualCostsAddTDS"] = actualCostsAddTDS;
            Session["insuranceCompaniesCosts"] = actualCostsAddTDS.InsuranceCompaniesCosts;

            insuranceCompaniesCosts = actualCostsAddTDS.InsuranceCompaniesCosts;
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP6 - INSURANCE COMPANIES COST BY CLIENT AND PROJECT - AUXILIAR EVENTS
        //

        protected void ddlClientFooterInsuranceCompaniesByClientProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlClientFooter = (DropDownList)sender;
            DropDownList ddlProjectFooterInsuranceCompaniesByClientProject = ((DropDownList)grdInsuranceCompaniesCostsByClientProject.FooterRow.FindControl("ddlProjectFooterInsuranceCompaniesByClientProject"));

            ProjectList projectList = new ProjectList();
            projectList.LoadProjectsAndAddItem(-1, "(Select a project)", int.Parse(ddlClientFooter.SelectedValue));
            ddlProjectFooterInsuranceCompaniesByClientProject.DataSource = projectList.Table;
            ddlProjectFooterInsuranceCompaniesByClientProject.DataValueField = "ProjectID";
            ddlProjectFooterInsuranceCompaniesByClientProject.DataTextField = "Name";
            ddlProjectFooterInsuranceCompaniesByClientProject.DataBind();
        }



        protected void grdInsuranceCompaniesCostsByClientProject_DataBound(object sender, EventArgs e)
        {
            AddInsuranceCompaniesCostsNewEmptyFix(grdInsuranceCompaniesCostsByClientProject);
        }



        protected void grdInsuranceCompaniesCostsByClientProject_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Edit) || (e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
            {
                odsInsuranceCompaniesListEditInsuranceCompaniesByClientProject.DataBind();

                string insuranceCompanyId = ((Label)e.Row.FindControl("lblInsuranceCompanyIdEditInsuranceCompaniesByClientProject")).Text.Trim();

                // Load actual id
                ((DropDownList)e.Row.FindControl("ddlInsuranceCompaniesEditInsuranceCompaniesByClientProject")).SelectedValue = insuranceCompanyId;
            }

            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Normal) || (e.Row.RowState == (DataControlRowState.Normal | DataControlRowState.Alternate))))
            {
                // Get date
                DateTime date = DateTime.Parse(((Label)e.Row.FindControl("lblDateInsuranceCompaniesByClientProject")).Text);

                // Set new format
                ((Label)e.Row.FindControl("lblDateInsuranceCompaniesByClientProject")).Text = date.Month.ToString() + "/" + date.Day.ToString() + "/" + date.Year.ToString();
            }
        }



        protected void grdInsuranceCompaniesCostsByClientProject_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Page.Validate("DataEditInsuranceCompaniesByClientProject");
            if (Page.IsValid)
            {
                // InsuranceCompanies Gridview, if the gridview is edition mode
                if (grdInsuranceCompaniesCostsByClientProject.EditIndex >= 0)
                {
                    grdInsuranceCompaniesCostsByClientProject.UpdateRow(grdInsuranceCompaniesCostsByClientProject.EditIndex, true);
                }

            }
        }





        
        // ////////////////////////////////////////////////////////////////////////
        //  STEP6 - INSURANCE COMPANIES COST BY CLIENT AND PROJECT - PUBLIC METHODS
        //

        public ActualCostsAddTDS.InsuranceCompaniesCostsDataTable GetInsuranceCompaniesDetailInsuranceCompaniesByClientProject()
        {
            insuranceCompaniesCosts = (ActualCostsAddTDS.InsuranceCompaniesCostsDataTable)Session["insuranceCompaniesCostsByClientProjectDummy"];
            if (insuranceCompaniesCosts == null)
            {
                insuranceCompaniesCosts = ((ActualCostsAddTDS.InsuranceCompaniesCostsDataTable)Session["insuranceCompaniesCosts"]);
            }

            return insuranceCompaniesCosts;
        }



        public void DummyInsuranceCompaniesDetail(int ProjectID, int RefID, int original_ProjectID, int original_RefID)
        {
        }



        public void DummyInsuranceCompaniesDetail(int original_ProjectID, int original_RefID)
        {
        }


        
     

        
        // ////////////////////////////////////////////////////////////////////////
        // STEP6 - INSURANCE COMPANIES COST BY CLIENT AND PROJECT - PRIVATE METHODS
        //

        private void StepInsuranceCompaniesCostsByClientProjectIn()
        {
            // Set instruction
            Label title = (Label)this.Master.FindControl("lblInstruction");
            title.Text = "Please add costs for Bonding Companies By Client And Project.";
        }



        private bool StepInsuranceCompaniesCostsByClientProjectPrevious()
        {
            return true;
        }



        private bool StepInsuranceCompaniesCostsByClientProjectNext()
        {
            Page.Validate("generalDataInsuranceByClientProject");
            if (Page.IsValid)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        protected void AddInsuranceCompaniesCostsNewEmptyFix(GridView grdInsuranceCompaniesCostsByClientProject)
        {
            if (grdInsuranceCompaniesCostsByClientProject.Rows.Count == 0)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                ActualCostsAddTDS.InsuranceCompaniesCostsDataTable dt = new ActualCostsAddTDS.InsuranceCompaniesCostsDataTable();
                dt.AddInsuranceCompaniesCostsRow(-1, -1, DateTime.Now, -1, -1, "", false, companyId, false, "", 0, "", "", 1);
                Session["insuranceCompaniesCostsByClientProjectDummy"] = dt;

                grdInsuranceCompaniesCostsByClientProject.DataBind();
            }

            // normally executes at all postbacks
            if (grdInsuranceCompaniesCostsByClientProject.Rows.Count == 1)
            {
                ActualCostsAddTDS.InsuranceCompaniesCostsDataTable dt = (ActualCostsAddTDS.InsuranceCompaniesCostsDataTable)Session["insuranceCompaniesCostsByClientProjectDummy"];
                if (dt != null)
                {
                    grdInsuranceCompaniesCostsByClientProject.Rows[0].Visible = false;
                    grdInsuranceCompaniesCostsByClientProject.Rows[0].Controls.Clear();
                }
            }
        }



        private void grdInsuranceCompaniesCostsByClientProjectDetailAdd()
        {
            if (FooterValidateInsuranceCompaniesByClientProject())
            {
                Page.Validate("DataNewInsuranceCompaniesByClientProject");
                if (Page.IsValid)
                {
                    int companyId = Int32.Parse(hdfCompanyId.Value);
                    DateTime date = (DateTime)((RadDatePicker)grdInsuranceCompaniesCostsByClientProject.FooterRow.FindControl("tkrdpDateFooterInsuranceCompaniesByClientProject")).SelectedDate;

                    int insuranceCompanyId = Int32.Parse(((DropDownList)grdInsuranceCompaniesCostsByClientProject.FooterRow.FindControl("ddlInsuranceCompaniesFooterInsuranceCompaniesByClientProject")).Text);
                    string name = ((DropDownList)grdInsuranceCompaniesCostsByClientProject.FooterRow.FindControl("ddlInsuranceCompaniesFooterInsuranceCompaniesByClientProject")).SelectedItem.Text;

                    int clientId = Int32.Parse(((DropDownList)grdInsuranceCompaniesCostsByClientProject.FooterRow.FindControl("ddlClientFooterInsuranceCompaniesByClientProject")).SelectedValue);
                    string client = ((DropDownList)grdInsuranceCompaniesCostsByClientProject.FooterRow.FindControl("ddlClientFooterInsuranceCompaniesByClientProject")).SelectedItem.Text;

                    int projectId = Int32.Parse(((DropDownList)grdInsuranceCompaniesCostsByClientProject.FooterRow.FindControl("ddlProjectFooterInsuranceCompaniesByClientProject")).SelectedValue);
                    string project = ((DropDownList)grdInsuranceCompaniesCostsByClientProject.FooterRow.FindControl("ddlProjectFooterInsuranceCompaniesByClientProject")).SelectedItem.Text;

                    decimal rate = decimal.Round(decimal.Parse(((TextBox)grdInsuranceCompaniesCostsByClientProject.FooterRow.FindControl("tbxRateFooterInsuranceCompaniesByClientProject")).Text), 2);
                    string comment = ((TextBox)grdInsuranceCompaniesCostsByClientProject.FooterRow.FindControl("tbxCommentFooterInsuranceCompaniesByClientProject")).Text;
                    bool deleted = false;
                    bool inDatabase = false;
                    decimal rateCad = 0;
                    decimal rateUsd = 0;
                    ProjectGateway projectGateway = new ProjectGateway();
                    projectGateway.LoadByProjectId(projectId);

                    if (projectGateway.GetCountryID(projectId) == 1) //Canada
                    {
                        rateCad = rate;
                        rateUsd = rate;
                    }
                    else
                    {
                        rateCad = rate;
                        rateUsd = rate;
                    }

                    // Insert Data
                    ActualCostsAddInsuranceCompaniesCosts actualCostsAddInsuranceCompaniesCosts = new ActualCostsAddInsuranceCompaniesCosts(actualCostsAddTDS);
                    actualCostsAddInsuranceCompaniesCosts.Insert(projectId, insuranceCompanyId, date, rateCad, rateUsd, comment, deleted, companyId, inDatabase, name, client, project, clientId);

                    // Store dataset                                
                    Session.Remove("insuranceCompaniesCostsByClientProjectDummy");

                    Session["actualCostsAddTDS"] = actualCostsAddTDS;
                    Session["insuranceCompaniesCosts"] = actualCostsAddTDS.InsuranceCompaniesCosts;

                    insuranceCompaniesCosts = actualCostsAddTDS.InsuranceCompaniesCosts;

                    grdInsuranceCompaniesCostsByClientProject.DataBind();
                    grdInsuranceCompaniesCostsByClientProject.PageIndex = grdInsuranceCompaniesCostsByClientProject.PageCount - 1;
                }
            }
        }



        protected bool FooterValidateInsuranceCompaniesByClientProject()
        {
            int clientId = Int32.Parse(((DropDownList)grdInsuranceCompaniesCostsByClientProject.FooterRow.FindControl("ddlClientFooterInsuranceCompaniesByClientProject")).SelectedValue);
            int projectId = Int32.Parse(((DropDownList)grdInsuranceCompaniesCostsByClientProject.FooterRow.FindControl("ddlProjectFooterInsuranceCompaniesByClientProject")).SelectedValue);
            int insuranceCompanyId = Int32.Parse(((DropDownList)grdInsuranceCompaniesCostsByClientProject.FooterRow.FindControl("ddlInsuranceCompaniesFooterInsuranceCompaniesByClientProject")).SelectedValue);

            if ((clientId != -1) && (projectId != -1) && (projectId != -1))
            {
                return true;
            }

            return false;
        }





        
        #endregion

        




        #region STEP7 - OTHER COST BY SUBCONTRACTORS

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP7 - OTHER COMPANIES COST BY CLIENT AND PROJECT
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP7 - OTHER COMPANIES COST BY CLIENT AND PROJECT -  EVENTS
        //

        protected void grdOtherCostsByClientProject_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Add":
                    // Other Gridview, if the gridview is edition mode
                    if (grdOtherCostsByClientProject.EditIndex >= 0)
                    {
                        grdOtherCostsByClientProject.UpdateRow(grdOtherCostsByClientProject.EditIndex, true);
                    }

                    // Add New Other
                    grdOtherCostsByClientProjectDetailAdd();
                    break;
            }
        }



        protected void grdOtherCostsByClientProject_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.Validate("DataEditOtherByClientProject");
            if (Page.IsValid)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                int refId = Int32.Parse(((Label)grdOtherCostsByClientProject.Rows[e.RowIndex].FindControl("lblRefIdEditOtherByClientProject")).Text);
                DateTime date = (DateTime)((RadDatePicker)grdOtherCostsByClientProject.Rows[e.RowIndex].FindControl("tkrdpDateEditOtherByClientProject")).SelectedDate;

                string category = ((DropDownList)grdOtherCostsByClientProject.Rows[e.RowIndex].FindControl("ddlCategoryEditOtherByClientProject")).Text;
                string name = ((DropDownList)grdOtherCostsByClientProject.Rows[e.RowIndex].FindControl("ddlCategoryEditOtherByClientProject")).SelectedItem.Text;

                int projectId = Int32.Parse(((Label)grdOtherCostsByClientProject.Rows[e.RowIndex].FindControl("lblProjectIdEditOtherByClientProject")).Text);

                decimal rate = decimal.Round(decimal.Parse(((TextBox)grdOtherCostsByClientProject.Rows[e.RowIndex].FindControl("tbxRateEditOtherByClientProject")).Text), 2);
                decimal rateCad = 0;
                decimal rateUsd = 0;

                ProjectGateway projectGateway = new ProjectGateway();
                projectGateway.LoadByProjectId(projectId);

                if (projectGateway.GetCountryID(projectId) == 1) //Canada
                {
                    rateCad = rate;
                }
                else
                {
                    rateUsd = rate;
                }

                string comment = ((TextBox)grdOtherCostsByClientProject.Rows[e.RowIndex].FindControl("tbxCommentEditOtherByClientProject")).Text;
                bool deleted = false;

                // Update Data
                ActualCostsAddOtherCosts actualCostsAddOtherCosts = new ActualCostsAddOtherCosts(actualCostsAddTDS);
                actualCostsAddOtherCosts.Update(projectId, refId, category, date, rateCad, rateUsd, comment, deleted, companyId, name);

                // Store dataset                                
                Session.Remove("otherCostsByClientProjectDummy");

                Session["actualCostsAddTDS"] = actualCostsAddTDS;                
                Session["otherCosts"] = actualCostsAddTDS.OtherCosts;                
                otherCosts = actualCostsAddTDS.OtherCosts;
            }
            else
            {
                e.Cancel = true;
            }
        }



        protected void grdOtherCostsByClientProject_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Other Gridview, if the gridview is edition mode
            if (grdOtherCostsByClientProject.EditIndex >= 0)
            {
                grdOtherCostsByClientProject.UpdateRow(grdOtherCostsByClientProject.EditIndex, true);
            }

            // Delete Other
            int projectId = (int)e.Keys["ProjectID"];
            int refId = (int)e.Keys["RefID"];

            // Delete costs details
            ActualCostsAddOtherCosts actualCostsAddOtherCosts = new ActualCostsAddOtherCosts(actualCostsAddTDS);
            actualCostsAddOtherCosts.Delete(projectId, refId);

            // Store dataset                                
            Session.Remove("otherCostsByClientProjectDummy");

            Session["actualCostsAddTDS"] = actualCostsAddTDS;
            Session["otherCosts"] = actualCostsAddTDS.OtherCosts;
            otherCosts = actualCostsAddTDS.OtherCosts;
        }





        
        // ////////////////////////////////////////////////////////////////////////
        // STEP7 - OTHER COMPANIES COST BY CLIENT AND PROJECT - AUXILIAR EVENTS
        //

        protected void ddlClientFooterOtherByClientProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlClientFooter = (DropDownList)sender;
            DropDownList ddlProjectFooterOtherByClientProject = ((DropDownList)grdOtherCostsByClientProject.FooterRow.FindControl("ddlProjectFooterOtherByClientProject"));

            ProjectList projectList = new ProjectList();
            projectList.LoadProjectsAndAddItem(-1, "(Select a project)", int.Parse(ddlClientFooter.SelectedValue));
            ddlProjectFooterOtherByClientProject.DataSource = projectList.Table;
            ddlProjectFooterOtherByClientProject.DataValueField = "ProjectID";
            ddlProjectFooterOtherByClientProject.DataTextField = "Name";
            ddlProjectFooterOtherByClientProject.DataBind();
        }



        protected void grdOtherCostsByClientProject_DataBound(object sender, EventArgs e)
        {
            AddOtherCostsNewEmptyFix(grdOtherCostsByClientProject);
        }



        protected void grdOtherCostsByClientProject_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Edit) || (e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
            {                
                string insuranceCompanyId = ((Label)e.Row.FindControl("lblCategoryEditOtherByClientProject")).Text.Trim();

                // Load actual id
                ((DropDownList)e.Row.FindControl("ddlCategoryEditOtherByClientProject")).SelectedValue = insuranceCompanyId;
            }

            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Normal) || (e.Row.RowState == (DataControlRowState.Normal | DataControlRowState.Alternate))))
            {
                // Get date
                DateTime date = DateTime.Parse(((Label)e.Row.FindControl("lblDateOtherByClientProject")).Text);

                // Set new format
                ((Label)e.Row.FindControl("lblDateOtherByClientProject")).Text = date.Month.ToString() + "/" + date.Day.ToString() + "/" + date.Year.ToString();
            }
        }



        protected void grdOtherCostsByClientProject_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Page.Validate("DataEditOtherByClientProject");
            if (Page.IsValid)
            {
                // Other Gridview, if the gridview is edition mode
                if (grdOtherCostsByClientProject.EditIndex >= 0)
                {
                    grdOtherCostsByClientProject.UpdateRow(grdOtherCostsByClientProject.EditIndex, true);
                }

            }
        }






        // ////////////////////////////////////////////////////////////////////////
        //  STEP7 - OTHER COMPANIES COST BY CLIENT AND PROJECT - PUBLIC METHODS
        //

        public ActualCostsAddTDS.OtherCostsDataTable GetOtherDetailOtherByClientProject()
        {
            otherCosts = (ActualCostsAddTDS.OtherCostsDataTable)Session["otherCostsByClientProjectDummy"];
            if (otherCosts == null)
            {
                otherCosts = ((ActualCostsAddTDS.OtherCostsDataTable)Session["otherCosts"]);
            }

            return otherCosts;
        }



        public void DummyOtherDetail(int ProjectID, int RefID, int original_ProjectID, int original_RefID)
        {
        }



        public void DummyOtherDetail(int original_ProjectID, int original_RefID)
        {
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP7 - OTHER COMPANIES COST BY CLIENT AND PROJECT - PRIVATE METHODS
        //

        private void StepOtherCostsByClientProjectIn()
        {
            // Set instruction
            Label title = (Label)this.Master.FindControl("lblInstruction");
            title.Text = "Please add other costs by Client and Project.";
        }



        private bool StepOtherCostsByClientProjectPrevious()
        {
            return true;
        }



        private bool StepOtherCostsByClientProjectNext()
        {
            Page.Validate("generalDataOtherCostsByClientProject");
            if (Page.IsValid)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        protected void AddOtherCostsNewEmptyFix(GridView grdOtherCostsByClientProject)
        {
            if (grdOtherCostsByClientProject.Rows.Count == 0)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                ActualCostsAddTDS.OtherCostsDataTable dt = new ActualCostsAddTDS.OtherCostsDataTable();
                dt.AddOtherCostsRow(-1, "", DateTime.Now, -1, -1, "", false, companyId, false, "", 0, "", "", 1);
                Session["otherCostsByClientProjectDummy"] = dt;

                grdOtherCostsByClientProject.DataBind();
            }

            // normally executes at all postbacks
            if (grdOtherCostsByClientProject.Rows.Count == 1)
            {
                ActualCostsAddTDS.OtherCostsDataTable dt = (ActualCostsAddTDS.OtherCostsDataTable)Session["otherCostsByClientProjectDummy"];
                if (dt != null)
                {
                    grdOtherCostsByClientProject.Rows[0].Visible = false;
                    grdOtherCostsByClientProject.Rows[0].Controls.Clear();
                }
            }
        }



        private void grdOtherCostsByClientProjectDetailAdd()
        {
            if (FooterValidateOtherByClientProject())
            {
                Page.Validate("DataNewOtherByClientProject");
                if (Page.IsValid)
                {
                    int companyId = Int32.Parse(hdfCompanyId.Value);
                    DateTime date = (DateTime)((RadDatePicker)grdOtherCostsByClientProject.FooterRow.FindControl("tkrdpDateFooterOtherByClientProject")).SelectedDate;

                    string category = ((DropDownList)grdOtherCostsByClientProject.FooterRow.FindControl("ddlCategoryFooterOtherByClientProject")).Text;
                    string name = ((DropDownList)grdOtherCostsByClientProject.FooterRow.FindControl("ddlCategoryFooterOtherByClientProject")).SelectedItem.Text;

                    int clientId = Int32.Parse(((DropDownList)grdOtherCostsByClientProject.FooterRow.FindControl("ddlClientFooterOtherByClientProject")).SelectedValue);
                    string client = ((DropDownList)grdOtherCostsByClientProject.FooterRow.FindControl("ddlClientFooterOtherByClientProject")).SelectedItem.Text;

                    int projectId = Int32.Parse(((DropDownList)grdOtherCostsByClientProject.FooterRow.FindControl("ddlProjectFooterOtherByClientProject")).SelectedValue);
                    string project = ((DropDownList)grdOtherCostsByClientProject.FooterRow.FindControl("ddlProjectFooterOtherByClientProject")).SelectedItem.Text;

                    decimal rate = decimal.Round(decimal.Parse(((TextBox)grdOtherCostsByClientProject.FooterRow.FindControl("tbxRateFooterOtherByClientProject")).Text), 2);
                    string comment = ((TextBox)grdOtherCostsByClientProject.FooterRow.FindControl("tbxCommentFooterOtherByClientProject")).Text;
                    bool deleted = false;
                    bool inDatabase = false;
                    decimal rateCad = 0;
                    decimal rateUsd = 0;
                    ProjectGateway projectGateway = new ProjectGateway();
                    projectGateway.LoadByProjectId(projectId);

                    if (projectGateway.GetCountryID(projectId) == 1) //Canada
                    {
                        rateCad = rate;
                        rateUsd = rate;
                    }
                    else
                    {
                        rateCad = rate;
                        rateUsd = rate;
                    }

                    // Insert Data
                    ActualCostsAddOtherCosts actualCostsAddOtherCosts = new ActualCostsAddOtherCosts(actualCostsAddTDS);
                    actualCostsAddOtherCosts.Insert(projectId, category, date, rateCad, rateUsd, comment, deleted, companyId, inDatabase, name, client, project, clientId);

                    // Store dataset                                
                    Session.Remove("otherCostsByClientProjectDummy");

                    Session["actualCostsAddTDS"] = actualCostsAddTDS;
                    Session["otherCosts"] = actualCostsAddTDS.OtherCosts;
                    otherCosts = actualCostsAddTDS.OtherCosts;

                    grdOtherCostsByClientProject.DataBind();
                    grdOtherCostsByClientProject.PageIndex = grdOtherCostsByClientProject.PageCount - 1;
                }
            }
        }



        protected bool FooterValidateOtherByClientProject()
        {
            int clientId = Int32.Parse(((DropDownList)grdOtherCostsByClientProject.FooterRow.FindControl("ddlClientFooterOtherByClientProject")).SelectedValue);
            int projectId = Int32.Parse(((DropDownList)grdOtherCostsByClientProject.FooterRow.FindControl("ddlProjectFooterOtherByClientProject")).SelectedValue);
            string category = ((DropDownList)grdOtherCostsByClientProject.FooterRow.FindControl("ddlCategoryFooterOtherByClientProject")).SelectedValue;

            if ((clientId != -1) && (projectId != -1) && (category != "-1"))
            {
                return true;
            }

            return false;
        }



        private bool ValidatePageOtherByClientProject()
        {
            bool valid = true;

            Page.Validate("DataNewOtherByClientProject");
            if (Page.IsValid)
            {
                Page.Validate("DataEditOtherByClientProject");
                if (!Page.IsValid) valid = false;
            }

            return valid;
        }



        #endregion


                
        #region STEP8 - SUMMARY

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP8 - SUMMARY
        //


        // ////////////////////////////////////////////////////////////////////////
        // STEP8 - SUMMARY - METHODS
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
            UpdateDatabase();
            return true;            
        }

        #endregion
        





        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //
        
        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set wizard title
            Label title = (Label)this.Master.FindControl("lblTitle");
            title.Text = "Add Actual Costs";
        }

        

        private void RegisterClientScripts()
        {
            // Resolve timeout problem
            ScriptManager scriptManager = (ScriptManager)this.Page.Master.FindControl("ScriptManager1");
            if (scriptManager != null)
            {
                scriptManager.AsyncPostBackTimeout = 1200;
            }

            // Register content variables
            string contentVariables = "";

            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./actual_costs_add.js");
        }



        private void UpdateDatabase()
        {
            DB.Open();
            DB.BeginTransaction();
            try
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                int loginId = Convert.ToInt32(Session["loginID"]);

                // Save costs information
                if (cbxSubcontractorCosts.Checked)
                {
                    if (rbtnSubcontractorCostsBySubcontractor.Checked)
                    {                     
                        ActualCostsAddSubcontractorCosts actualCostsAddSubcontractorCosts = new ActualCostsAddSubcontractorCosts(actualCostsAddTDS);
                        actualCostsAddSubcontractorCosts.Save(companyId);
                    }
                    else
                    {
                        if (rbtnSubcontractorCostsByProjectAndClient.Checked)
                        {
                            ActualCostsAddSubcontractorCosts actualCostsAddSubcontractorCosts = new ActualCostsAddSubcontractorCosts(actualCostsAddTDS);
                            actualCostsAddSubcontractorCosts.Save(companyId);
                        }
                    }
                }

                if (cbxHotelCosts.Checked)
                {
                    ActualCostsAddHotelCosts actualCostsAddHotelCosts = new ActualCostsAddHotelCosts(actualCostsAddTDS);
                    actualCostsAddHotelCosts.Save(companyId);
                }

                if (cbxBondingCosts.Checked)
                {
                    ActualCostsAddBondingCompaniesCosts actualCostsAddBondingCompaniesCosts = new ActualCostsAddBondingCompaniesCosts(actualCostsAddTDS);
                    actualCostsAddBondingCompaniesCosts.Save(companyId);
                }

                if (cbxInsuranceCosts.Checked)
                {
                    ActualCostsAddInsuranceCompaniesCosts actualCostsAddInsuranceCompaniesCosts = new ActualCostsAddInsuranceCompaniesCosts(actualCostsAddTDS);
                    actualCostsAddInsuranceCompaniesCosts.Save(companyId);
                }

                if (cbxOtherCosts.Checked)
                {
                    ActualCostsAddOtherCosts actualCostsAddOtherCosts = new ActualCostsAddOtherCosts(actualCostsAddTDS);
                    actualCostsAddOtherCosts.Save(companyId);
                }
                                
                DB.CommitTransaction();

                // Store datasets
                actualCostsAddTDS.AcceptChanges();
                Session["actualCostsAddTDS"] = actualCostsAddTDS;

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
            string summary = "";
            int companyId = Int32.Parse(hdfCompanyId.Value);

            // Summary for Subcontractor costs
            if (cbxSubcontractorCosts.Checked)
            {                
                if (rbtnSubcontractorCostsBySubcontractor.Checked)
                {
                    summary += "NEW SUBCONTRACTORS COSTS \n";                    
                    summary += "SUBCONTRACTOR:  " + ddlSubcontractor.SelectedItem.Text + "\n";

                    ActualCostsAddSubcontractorCosts actualCostsAddSubcontractorCosts = new ActualCostsAddSubcontractorCosts(actualCostsAddTDS);
                    summary += actualCostsAddSubcontractorCosts.GetSummary(companyId, "\n", "BySubcontractor"); 
                }
                else
                {
                    if (rbtnSubcontractorCostsByProjectAndClient.Checked)
                    {
                        summary += "NEW SUBCONTRACTORS COSTS \n";                        
                        summary += "CLIENT:  " + ddlClientByClientProject.SelectedItem.Text + "\n";
                        summary += "PROJECT:  " + ddlProjectByClientProject.SelectedItem.Text + "\n";

                        ActualCostsAddSubcontractorCosts actualCostsAddSubcontractorCosts = new ActualCostsAddSubcontractorCosts(actualCostsAddTDS);
                        summary += actualCostsAddSubcontractorCosts.GetSummary(companyId, "\n", "ByClientProject"); 
                    }
                }
            }

            if (cbxHotelCosts.Checked)
            {
                summary += "NEW HOTEL COSTS \n";

                ActualCostsAddHotelCosts actualCostsAddHotelCosts = new ActualCostsAddHotelCosts(actualCostsAddTDS);
                summary += actualCostsAddHotelCosts.GetSummary(companyId, "\n"); 
            }

            if (cbxBondingCosts.Checked)
            {
                summary += "NEW BONDING COMPANIES COSTS \n";

                ActualCostsAddBondingCompaniesCosts actualCostsAddBondingCompaniesCosts = new ActualCostsAddBondingCompaniesCosts(actualCostsAddTDS);
                summary += actualCostsAddBondingCompaniesCosts.GetSummary(companyId, "\n");
            }

            if (cbxInsuranceCosts.Checked)
            {
                summary += "NEW INSURANCE COMPANIES COSTS \n";

                ActualCostsAddInsuranceCompaniesCosts actualCostsAddInsuranceCompaniesCosts = new ActualCostsAddInsuranceCompaniesCosts(actualCostsAddTDS);
                summary += actualCostsAddInsuranceCompaniesCosts.GetSummary(companyId, "\n");
            }

            if (cbxOtherCosts.Checked)
            {
                summary += "NEW OTHER COSTS \n";

                ActualCostsAddOtherCosts actualCostsAddOtherCosts = new ActualCostsAddOtherCosts(actualCostsAddTDS);
                summary += actualCostsAddOtherCosts.GetSummary(companyId, "\n");
            }

            return summary;
        }



        private void StoreNavigatorState()
        {
            ViewState["navigatorState"] = "&search_ddlClient=" + Request.QueryString["search_ddlClient"] + "&search_ddlProject=" + Request.QueryString["search_ddlProject"] + "&search_ddlSubcontractor=" + Request.QueryString["search_ddlSubcontractor"] + "&search_sort_by=" + Request.QueryString["search_sort_by"] + "&search_tkrdpStartDate=" + Request.QueryString["search_tkrdpStartDate"] + "&search_tkrdpEndDate=" + Request.QueryString["search_tkrdpEndDate"] + "&search_cbxFilterByDateSelected=" + Request.QueryString["search_cbxFilterByDateSelected"];
        }



        private string GetNavigatorState()
        {
            return (string)ViewState["navigatorState"];
        }

        



                   
    }
}