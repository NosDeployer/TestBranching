using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.BL.FleetManagement.Common;
using LiquiForce.LFSLive.BL.FleetManagement.Services;
using LiquiForce.LFSLive.BL.Resources.Employees;
using LiquiForce.LFSLive.DA.FleetManagement.CompanyLevels;
using LiquiForce.LFSLive.DA.FleetManagement.Services;
using LiquiForce.LFSLive.DA.FleetManagement.Units;
using LiquiForce.LFSLive.DA.Resources.Employees;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.WebUI.FleetManagement.Services
{
    /// <summary>
    /// services_add_request
    /// </summary>
    public partial class services_add_request : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected ServicesAddRequestTDS servicesAddRequestTDS;
        protected ServicesAddRequestTDS.CostInformationDataTable costInformation;






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
                if (!(Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_SERVICES_ADD"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["unit_id"] == null) || ((string)Request.QueryString["dashboard"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in services_add_request.aspx");
                }

                // Tag Page
                TagPage();             

                // Initialize viewstate variables
                ViewState["StepFrom"] = "Out";
                Session.Remove("servicesAddRequestTDS");
                Session.Remove("serviceCostsDummyAddRequest");
                Session.Remove("costInformationAddRequest");

                // If coming from 
                // ... service_navigator.aspx, service_navigator2.aspx, units_summary.aspx or wucSRUnassigned.ascx
                if ((Request.QueryString["source_page"] == "services_navigator.aspx") || (Request.QueryString["source_page"] == "services_navigator2.aspx") || (Request.QueryString["source_page"] == "units_summary.aspx") || (Request.QueryString["source_page"] == "wucSRUnassigned.ascx") || (Request.QueryString["source_page"] == "wucAlarms.ascx.cs"))
                {
                    // ... Initialize tables
                    servicesAddRequestTDS = new ServicesAddRequestTDS();

                    // ... Store tables
                    Session["servicesAddRequestTDS"] = servicesAddRequestTDS;
                }

                // StepSection1In
                wzServices.ActiveStepIndex = 0;
                StepBeginIn();
            }
            else
            {
                // Restore tables
                servicesAddRequestTDS = (ServicesAddRequestTDS)Session["servicesAddRequestTDS"];
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
                switch (wzServices.ActiveStep.Name)
                {
                    case "Begin":
                        StepBeginIn();
                        break;

                    case "General Information":
                        StepGeneralInformationIn();
                        break;
                        
                    case "Summary":
                        StepSummaryIn();
                        break;

                    case "Final Step":
                        StepFinalStepIn();
                        wzServices.ActiveStepIndex = wzServices.WizardSteps.IndexOf(StepFinalStep);
                        break;

                    default:
                        throw new Exception("The option for " + wzServices.ActiveStep.Name + " step in services_add_request.Wizard_ActiveStepChanged function does not exist");
                }
            }
        }



        protected void Wizard_NextButtonClick(object sender, WizardNavigationEventArgs e)
        {
            switch (wzServices.ActiveStep.Name)
            {
                case "Begin":
                    e.Cancel = !StepBeginNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "General Information";
                    }
                    break;

                case "General Information":                    
                    e.Cancel = !StepGeneralInformationNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "General Information";
                    } 
                    break;

                default:
                    throw new Exception("The option for " + wzServices.ActiveStep.Name + " step in services_add_request.Wizard_NextButtonClick function does not exist");
            }
        }



        protected void Wizard_PreviousButtonClick(object sender, WizardNavigationEventArgs e)
        {
            switch (wzServices.ActiveStep.Name)
            {
                case "General Information":
                    e.Cancel = !StepGeneralInformationPrevious();
                    break;

                case "Summary":
                    e.Cancel = !StepSummaryPrevious();
                    break;

                default:
                    throw new Exception("The option for " + wzServices.ActiveStep.Name + " step in services_add_request.Wizard_PreviousButtonClick function does not exist");
            }
            if (!e.Cancel)
            {
                ViewState["StepFrom"] = wzServices.ActiveStep.Name;
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
            instruction.Text = "Please select a unit";           

            // Set initial unit id
            if (hdfInitialUnitId.Value != "none")
            {
                int unitId = Int32.Parse(hdfInitialUnitId.Value);
                int companyId = Int32.Parse(hdfCompanyId.Value);

                UnitsGateway unitsGateway = new UnitsGateway();
                unitsGateway.LoadByUnitId(unitId, companyId);                
                string state = unitsGateway.GetState(unitId) ;

                if (state != "Disposed") 
                {
                    try
                    {
                        ddlUnits.SelectedValue = hdfInitialUnitId.Value;
                    }
                    catch
                    {
                    }
                }

                if (hdfDashboard.Value == "True")
                {
                    try
                    {
                        ddlUnits.Enabled = false;
                    }
                    catch
                    {
                    }
                }
            }
        }



        private bool StepBeginNext()
        {
            Page.Validate("Begin");
            if (Page.IsValid)
            {
                // Tag values
                hdfUnitId.Value = ddlUnits.SelectedValue;
                hdfUnitCode.Value = ddlUnits.SelectedItem.Text;
                return true;
            }
            return false;
        }



        #endregion






        #region STEP2 - GENERAL INFORMATION

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP2 - GENERAL INFORMATION
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP2 - GENERAL INFORMATION - EVENTS
        //


        protected void grdCosts_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // grdCosts Gridview, if the gridview is edition mode
            if (grdCosts.EditIndex >= 0)
            {
                grdCosts.UpdateRow(grdCosts.EditIndex, true);
            }

            // Delete laterals
            int serviceId = (int)e.Keys["ServiceID"];
            int refId = (int)e.Keys["RefID"];
            int companyId = Int32.Parse(hdfCompanyId.Value);

            ServicesAddRequestCostInformation model = new ServicesAddRequestCostInformation(servicesAddRequestTDS);
            model.Delete(serviceId, refId);

            // Store dataset
            Session["servicesAddRequestTDS"] = servicesAddRequestTDS;
            Session["costInformationAddRequest"] = servicesAddRequestTDS.CostInformation;

            // Calc TotalCost
            tbxTotalCost.Text = Decimal.Round(model.GetTotalCost(serviceId, companyId), 2).ToString();
        }



        protected void grdCosts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Add":
                    // Costs Gridview, if the gridview is edition mode
                    if (grdCosts.EditIndex >= 0)
                    {
                        grdCosts.UpdateRow(grdCosts.EditIndex, true);
                    }

                    // Add New Costs
                    GrdCostsAdd();
                    break;
            }
        }



        protected void grdCosts_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.Validate("costsDataEdit");
            if (Page.IsValid)
            {
                int serviceId = (int)e.Keys["ServiceID"];
                int refId = (int)e.Keys["RefID"];
                int companyId = Int32.Parse(hdfCompanyId.Value);

                string partNumber = ((TextBox)grdCosts.Rows[e.RowIndex].Cells[2].FindControl("tbxPartNumber")).Text.Trim();
                string partName = ((TextBox)grdCosts.Rows[e.RowIndex].Cells[3].FindControl("tbxPartName")).Text.Trim();
                string vendor = ((TextBox)grdCosts.Rows[e.RowIndex].Cells[4].FindControl("tbxVendor")).Text.Trim();
                decimal cost = decimal.Parse(((TextBox)grdCosts.Rows[e.RowIndex].Cells[5].FindControl("tbxCost")).Text.Trim());

                // Update data
                ServicesAddRequestCostInformation model = new ServicesAddRequestCostInformation(servicesAddRequestTDS);
                model.Update(serviceId, refId, partNumber, partName, vendor, cost);

                // Store dataset
                Session["servicesAddRequestTDS"] = servicesAddRequestTDS;
                Session["costInformationAddRequest"] = servicesAddRequestTDS.CostInformation;
                
                // Calc TotalCost
                tbxTotalCost.Text = Decimal.Round(model.GetTotalCost(serviceId, companyId), 2).ToString();
            }
            else
            {
                e.Cancel = true;
            }
        }





        
        // ////////////////////////////////////////////////////////////////////////
        // STEP2 - GENERAL INFORMATION - AUXILIAR EVENTS
        //

        protected void grdCosts_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Costs Gridview, if the gridview is edition mode
            if (grdCosts.EditIndex >= 0)
            {
                grdCosts.UpdateRow(grdCosts.EditIndex, true);
            }
        }



        protected void cvMileage_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            if (ckbxMtoDto.Checked)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                int unitId = Int32.Parse(hdfUnitId.Value);

                UnitsGateway unitsGateway = new UnitsGateway();
                unitsGateway.LoadByUnitId(unitId, companyId);

                string unitType = unitsGateway.GetType(unitId);
                int companyLevel = unitsGateway.GetCompanyLevelId(unitId);

                if (unitType == "Vehicle")
                {
                    if (tbxMileage.Text == "")
                    {
                        args.IsValid = false;
                    }
                }
            }
        }



        protected void rbtnAssignToMyself_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnUnassigned.Checked)
            {
                pnlAcceptInformation.Visible = false;
                pnlStartWorkInformation.Visible = false;
                pnlCompleteWorkInformation.Visible = false;               
                pnlAssignThirdPartyVendor.Visible = false;
                pnlAssignTeamMember.Visible = false;
                acceptInformationSeparator.Visible = false;
                startWorkSeparator.Visible = false;
                completeWorkSeparator.Visible = false;
            }
            else
            {
                pnlAcceptInformation.Visible = true;
                pnlStartWorkInformation.Visible = true;
                pnlCompleteWorkInformation.Visible = true;                
                acceptInformationSeparator.Visible = true;
                startWorkSeparator.Visible = true;
                completeWorkSeparator.Visible = true;

                if ((rbtnAssignToMyself.Checked) || (rbtnAssignToTeamMember.Checked))
                {
                    pnlAssignThirdPartyVendor.Visible = false;
                    pnlAssignTeamMember.Visible = true;
                }

                if (rbtnAssignToThirdPartyVendor.Checked)
                {
                    pnlAssignThirdPartyVendor.Visible = true;
                    pnlAssignTeamMember.Visible = false;
                }

                if (tbxMileage.Text != "" && tbxStartWorkStartMileage.Text == "")
                {
                    tbxStartWorkStartMileage.Text = tbxMileage.Text;
                }

                if (tbxMileage.Text != "" && tbxCompleteWorkCompleteMileage.Text == "")
                {
                    tbxCompleteWorkCompleteMileage.Text = tbxMileage.Text;
                }
            }
        }



        protected void cvTeamMember_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;
            if ((rbtnAssignToTeamMember.Checked) && (ddlAssignToTeamMember.SelectedValue == "-1"))
            {
                args.IsValid = false;
            }
        }



        protected void cvThridPartyVendor_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;
            if ((rbtnAssignToThirdPartyVendor.Checked) && (tbxAssignToThirdPartyVendor.Text == ""))
            {
                args.IsValid = false;
            }
        }



        protected void cvCompleteSR_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;
            CustomValidator cvConditions = (CustomValidator)source;

            if ((hdfStartSR.Value == "False") && (hdfCompleteSR.Value == "True"))
            {
                args.IsValid = false;
            }
        }



        protected void cvStartSR_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;
            CustomValidator cvConditions = (CustomValidator)source;

            if ((hdfAcceptSR.Value == "False") && (hdfStartSR.Value == "True"))
            {
                args.IsValid = false;
            }
        }



        protected void cvAcceptSR_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;
            CustomValidator cvConditions = (CustomValidator)source;

            if (hdfUnassigned.Value == "True")
            {
                args.IsValid = false;
            }
        }



        protected void cvUnitOutOfServiceDate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;
            CustomValidator cvConditions = (CustomValidator)source;

            if (ckbxStartSR.Checked)
            {
                if (!tkrdpStartWorkUnitOutOfServiceDate.SelectedDate.HasValue)
                {
                    cvConditions.ErrorMessage = "Please select a date.";
                    args.IsValid = false;
                }
            }
            else
            {
                if (tkrdpStartWorkUnitOutOfServiceDate.SelectedDate.HasValue)
                {
                    cvConditions.ErrorMessage = "Please delete the out of service date";
                    args.IsValid = false;
                }
            }
        }
      
        
        
        protected void cvStartMileage_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;
            CustomValidator cvConditions = (CustomValidator)source;

            int companyId = Int32.Parse(hdfCompanyId.Value);
            int unitId = Int32.Parse(hdfUnitId.Value);

            UnitsGateway unitsGateway = new UnitsGateway();
            unitsGateway.LoadByUnitId((int)unitId, companyId);
            string unitType = unitsGateway.GetType((int)unitId);

            if (unitType == "Vehicle")
            {
                if (ckbxStartSR.Checked)
                {
                    if (tbxStartWorkStartMileage.Text == "")
                    {
                        cvConditions.ErrorMessage = "Please provide a mileage";
                        args.IsValid = false;
                    }
                }
                else
                {
                    if (tbxStartWorkStartMileage.Text != "")
                    {
                        cvConditions.ErrorMessage = "Please delete the mileage";
                        args.IsValid = false;
                    }
                }
            }
        }



        protected void cvUnitBackInServiceDate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;
            CustomValidator cvConditions = (CustomValidator)source;

            if (ckbxCompleteSR.Checked)
            {
                if (!tkrdpCompleteWorkUnitBackInServiceDate.SelectedDate.HasValue)
                {
                    cvConditions.ErrorMessage = "Please select a date.";
                    args.IsValid = false;
                }
            }
            else
            {
                if (tkrdpCompleteWorkUnitBackInServiceDate.SelectedDate.HasValue)
                {
                    cvConditions.ErrorMessage = "Please delete the out of service date.";
                    args.IsValid = false;
                }
            }
        }            



        protected void cvCompleteMileage_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;
            CustomValidator cvConditions = (CustomValidator)source;

            int companyId = Int32.Parse(hdfCompanyId.Value);
            int unitId = Int32.Parse(hdfUnitId.Value);

            UnitsGateway unitsGateway = new UnitsGateway();
            unitsGateway.LoadByUnitId((int)unitId, companyId);
            string unitType = unitsGateway.GetType((int)unitId);

            if (unitType == "Vehicle")
            {
                if (ckbxCompleteSR.Checked)
                {
                    if (tbxCompleteWorkCompleteMileage.Text == "")
                    {
                        cvConditions.ErrorMessage = "Please provide a mileage";
                        args.IsValid = false;
                    }
                }
                else
                {
                    if (tbxCompleteWorkCompleteMileage.Text != "")
                    {
                        cvConditions.ErrorMessage = "Please delete the mileage";
                        args.IsValid = false;
                    }
                }
            }
        }



        protected void grdCosts_DataBound(object sender, EventArgs e)
        {
            AddCostsNewEmptyFix(grdCosts);
        }





       
        // ////////////////////////////////////////////////////////////////////////
        // STEP2 - GENERAL INFORMATION - METHODS
        //

        private void StepGeneralInformationIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "";           

            // Validate user - admin
            if (Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_SERVICES_ADMIN"]))
            {
                rbtnAssignToTeamMember.Visible = true;
                ddlAssignToTeamMember.Visible = true;
            }
            else
            {
                rbtnAssignToTeamMember.Visible = false;
                ddlAssignToTeamMember.Visible = false;
            }

            // Validate vehicle info
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int unitId = Int32.Parse(hdfUnitId.Value); 

            UnitsGateway unitsGateway = new UnitsGateway();
            unitsGateway.LoadByUnitId(unitId, companyId);
            string unitType = unitsGateway.GetType(unitId);
            hdfUnitType.Value = unitType;
            int companyLevel = unitsGateway.GetCompanyLevelId(unitId);
            hdfCompanyLevel.Value = unitsGateway.GetCompanyLevelId(unitId).ToString();

            CompanyLevelGateway companyLevelGateway = new CompanyLevelGateway();
            companyLevelGateway.LoadByCompanyLevelId(companyLevel, companyId);
            lblMileageUnitOfMeasurement.Text = companyLevelGateway.GetUnitsUnitOfMeasurement(companyLevel);           
            hdfMileageUnitOfMeasurement.Value = lblMileageUnitOfMeasurement.Text;
            lblStartWorkStartMileageUnitOfMeasurement.Text = hdfMileageUnitOfMeasurement.Value;
            lblCompleteWorkCompleteMileageUnitOfMeasurement.Text = hdfMileageUnitOfMeasurement.Value;

            if (unitType == "Vehicle")
            {
                lblMileage.Visible = true;
                tbxMileage.Visible = true;
                lblStartWorkStartMileage.Visible = true;
                tbxStartWorkStartMileage.Visible = true;
                lblCompleteWorkCompleteMileage.Visible = true;
                tbxCompleteWorkCompleteMileage.Visible = true;
                lblMileageUnitOfMeasurement.Visible = true;
                lblStartWorkStartMileageUnitOfMeasurement.Visible = true;
                lblCompleteWorkCompleteMileageUnitOfMeasurement.Visible = true;
            }
            else
            {
                lblMileage.Visible = false;
                tbxMileage.Visible = false;
                lblMileageUnitOfMeasurement.Visible = false;                
                lblStartWorkStartMileage.Visible = false;
                tbxStartWorkStartMileage.Visible = false;
                lblStartWorkStartMileageUnitOfMeasurement.Visible = false;               
                lblCompleteWorkCompleteMileage.Visible = false;
                tbxCompleteWorkCompleteMileage.Visible = false;
                lblCompleteWorkCompleteMileageUnitOfMeasurement.Visible = false;                
            }

            // Validate panels
            if (rbtnUnassigned.Checked)
            {
                pnlAcceptInformation.Visible = false;
                pnlStartWorkInformation.Visible = false;
                pnlCompleteWorkInformation.Visible = false;
                pnlAssignThirdPartyVendor.Visible = false;
                pnlAssignTeamMember.Visible = false;
                acceptInformationSeparator.Visible = false;
                startWorkSeparator.Visible = false;
                completeWorkSeparator.Visible = false;
            }
            else
            {
                if ((rbtnAssignToMyself.Checked) || (rbtnAssignToTeamMember.Checked))
                {
                    pnlAssignThirdPartyVendor.Visible = false;
                    pnlAssignTeamMember.Visible = true;
                }
                if (rbtnAssignToThirdPartyVendor.Checked)
                {
                    pnlAssignThirdPartyVendor.Visible = true;
                    pnlAssignTeamMember.Visible = false;
                }
            }
        }



        private bool StepGeneralInformationNext()
        {
            hdfUnassigned.Value = rbtnUnassigned.Checked.ToString();
            hdfAcceptSR.Value = ckbxAcceptSR.Checked.ToString();
            hdfStartSR.Value = ckbxStartSR.Checked.ToString();
            hdfCompleteSR.Value = ckbxCompleteSR.Checked.ToString();

            bool valid = ValidatePage();
            
            if (valid)
            {
                // General Information
                hdfMtoDto.Value = ckbxMtoDto.Checked.ToString();
                hdfMileage.Value = tbxMileage.Text.Trim();                                
                hdfDescription.Value = tbxDescription.Text.Trim();

                // Assigment Information
                hdfDeadlineDate.Value = ""; if (tkrdpDeadlineDate.SelectedDate.HasValue) hdfDeadlineDate.Value = tkrdpDeadlineDate.SelectedDate.Value.ToString();

                // ... Myself
                hdfAssignToMyself.Value = rbtnAssignToMyself.Checked.ToString();
                if (rbtnAssignToMyself.Checked)
                {
                    int loginId = Convert.ToInt32(Session["loginID"]);
                    EmployeeGateway employeeGateway = new EmployeeGateway(new DataSet());
                    hdfTeamMemberId.Value = employeeGateway.GetEmployeIdByLoginId(loginId).ToString();
                    hdfThirdPartyVendor.Value = "";
                }

                // ... Team Member
                if (Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_SERVICES_ADMIN"]))
                {
                    hdfAssignToTeamMember.Value = rbtnAssignToTeamMember.Checked.ToString();
                    if (rbtnAssignToTeamMember.Checked)
                    {
                        hdfTeamMemberId.Value = ""; if (ddlAssignToTeamMember.SelectedValue != "") hdfTeamMemberId.Value = ddlAssignToTeamMember.SelectedValue;
                        hdfTeamMemberFullName.Value = ""; if (ddlAssignToTeamMember.SelectedItem.Text != "") hdfTeamMemberFullName.Value = ddlAssignToTeamMember.SelectedItem.Text;
                        hdfThirdPartyVendor.Value = "";
                    }
                }

                // ... Third party vendor
                hdfAssignToThirdPartyVendor.Value = rbtnAssignToThirdPartyVendor.Checked.ToString();
                if (rbtnAssignToThirdPartyVendor.Checked)
                {
                    hdfTeamMemberId.Value = "";
                    hdfTeamMemberFullName.Value = "";
                    hdfThirdPartyVendor.Value = ""; if (tbxAssignToThirdPartyVendor.Text != "") hdfThirdPartyVendor.Value = tbxAssignToThirdPartyVendor.Text.Trim();
                }

                // Accept information
                hdfAcceptSR.Value = ckbxAcceptSR.Checked.ToString();

                // Start work information
                hdfStartSR.Value = ckbxStartSR.Checked.ToString();

                if (ckbxStartSR.Checked)
                {
                    hdfUnitOutOfServiceDate.Value = ""; if (tkrdpStartWorkUnitOutOfServiceDate.SelectedDate.HasValue) hdfUnitOutOfServiceDate.Value = tkrdpStartWorkUnitOutOfServiceDate.SelectedDate.Value.ToString();
                    hdfUnitOutOfServiceTime.Value = "8:00 AM";
                    hdfStartMileage.Value = tbxStartWorkStartMileage.Text.Trim();
                }

                // Complete work information    
                if (ckbxCompleteSR.Checked)
                {
                    // Costs Gridview, if the gridview is edition mode
                    if (grdCosts.EditIndex >= 0)
                    {
                        grdCosts.UpdateRow(grdCosts.EditIndex, true);
                    }

                    // ... Save cost
                    GrdCostsAdd();

                    // ... Tag values                
                    hdfUnitBackInServiceDate.Value = ""; if (tkrdpCompleteWorkUnitBackInServiceDate.SelectedDate.HasValue) hdfUnitBackInServiceDate.Value = tkrdpCompleteWorkUnitBackInServiceDate.SelectedDate.Value.ToString();
                    hdfUnitBackInServiceTime.Value = "8:00 AM";
                    hdfCompleteWorkMileage.Value = tbxCompleteWorkCompleteMileage.Text.Trim();

                    if (hdfAssignToThirdPartyVendor.Value == "False")
                    {
                        hdfCompleteWorkDescription.Value = tbxCompleteWorkDataDescription.Text.Trim();
                        hdfCompleteWorkPreventable.Value = ckbxCompleteWorkDataPreventable.Checked.ToString();
                        hdfCompleteWorkLabourHours.Value = tbxCompleteWorkDataLabourHours.Text.Trim();
                        hdfCompleteWorkCosts.Value = tbxTotalCost.Text.Trim();
                        hdfInvoiceNumber.Value = "";
                        hdfInvoiceAmount.Value = "";
                    }
                    else
                    {
                        hdfCompleteWorkDescription.Value = tbxDescriptionTPV.Text.Trim();
                        hdfCompleteWorkPreventable.Value = ckbxPreventableTPV.Checked.ToString();
                        hdfInvoiceNumber.Value = tbxInvoiceNumberTPV.Text.Trim();
                        hdfInvoiceAmount.Value = tbxInvoiceAmountTPV.Text.Trim();
                        hdfCompleteWorkLabourHours.Value = "";
                        hdfCompleteWorkCosts.Value = "";
                    }
                }

                return true;
            }

            return false;
        }



        private bool StepGeneralInformationPrevious()
        {
            return true;
        }



        private bool ValidatePage()
        {
            bool valid = true;

            Page.Validate("GeneralInformation");
            if (!Page.IsValid) valid = false;

            Page.Validate("assignmentInformation");
            if (!Page.IsValid) valid = false;
            
            Page.Validate("startWorkInformation");
            if (!Page.IsValid) valid = false;            

            Page.Validate("completeInformation");
            if (Page.IsValid)
            {
                // ... Validate cost section
                if (ValidateCostsFooter())
                {
                    Page.Validate("costsDataAdd");
                    if (!Page.IsValid) valid = false;
                }

                Page.Validate("costsDataEdit");
                if (!Page.IsValid) valid = false;
            }
            else
            {
                valid = false;
            }            

            return valid;
        }



        public ServicesAddRequestTDS.CostInformationDataTable GetCostsNew()
        {
            costInformation = (ServicesAddRequestTDS.CostInformationDataTable)Session["serviceCostsDummyAddRequest"];
            if (costInformation == null)
            {
                costInformation = (ServicesAddRequestTDS.CostInformationDataTable)Session["costInformationAddRequest"];
            }

            return costInformation;
        }



        public void DummyCostsNew(int ServiceID, int RefID)
        {
        }



        private void GrdCostsAdd()
        {
            if (ValidateCostsFooter())
            {
                Page.Validate("costsDataAdd");

                if (Page.IsValid)
                {
                    int serviceId = 1;
                    int companyId = Int32.Parse(hdfCompanyId.Value);
                    string newPartNumber = ((TextBox)grdCosts.FooterRow.FindControl("tbxPartNumberNew")).Text.Trim();
                    string newPartName = ((TextBox)grdCosts.FooterRow.FindControl("tbxPartNameNew")).Text.Trim();
                    string newVendor = ((TextBox)grdCosts.FooterRow.FindControl("tbxVendorNew")).Text.Trim();
                    decimal newCost = Decimal.Round(Decimal.Parse(((TextBox)grdCosts.FooterRow.FindControl("tbxCostNew")).Text.Trim()), 2);

                    ServicesAddRequestCostInformation model = new ServicesAddRequestCostInformation(servicesAddRequestTDS);

                    model.Insert(serviceId, newPartNumber, newPartName, newVendor, newCost, false, companyId);

                    Session.Remove("serviceCostsDummyAddRequest");
                    Session["servicesAddRequestTDS"] = servicesAddRequestTDS;
                    Session["costInformationAddRequest"] = servicesAddRequestTDS.CostInformation;

                    // Calc TotalCost
                    tbxTotalCost.Text = Decimal.Round(model.GetTotalCost(serviceId, companyId), 2).ToString();

                    grdCosts.DataBind();
                    grdCosts.PageIndex = grdCosts.PageCount - 1;
                }
            }
        }



        private bool ValidateCostsFooter()
        {
            string partNumber = ((TextBox)grdCosts.FooterRow.FindControl("tbxPartNumberNew")).Text.Trim();
            string partName = ((TextBox)grdCosts.FooterRow.FindControl("tbxPartNameNew")).Text.Trim();
            string vendor = ((TextBox)grdCosts.FooterRow.FindControl("tbxVendorNew")).Text.Trim();
            string cost = ((TextBox)grdCosts.FooterRow.FindControl("tbxCostNew")).Text.Trim();

            if ((partNumber != "") || (partName != "") || (vendor != "") || (cost != ""))
            {
                return true;
            }

            return false;
        }



        protected void AddCostsNewEmptyFix(GridView grdView)
        {
            if (grdCosts.Rows.Count == 0)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                ServicesAddRequestTDS.CostInformationDataTable dt = new ServicesAddRequestTDS.CostInformationDataTable();
                dt.AddCostInformationRow(-1, -1, "", "", "", -1, false, companyId);
                Session["serviceCostsDummyAddRequest"] = dt;

                grdCosts.DataBind();
            }

            // Normally executes at all postbacks
            if (grdCosts.Rows.Count == 1)
            {
                ServicesAddRequestTDS.CostInformationDataTable dt = (ServicesAddRequestTDS.CostInformationDataTable)Session["serviceCostsDummyAddRequest"];
                if (dt != null)
                {
                    grdCosts.Rows[0].Visible = false;
                    grdCosts.Rows[0].Controls.Clear();
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
                PostPageChanges();
                UpdateDatabase();                              

                // ... If there is an assignation send mail to Assigned Personal
                if ((hdfAssignToTeamMember.Value == "True") || (hdfAssignToMyself.Value == "True"))
                {
                    SendMailTeamMember();                    
                }

                // ... Send  mail to fleet manager
                SendMailFleetManager();

                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion






        #region STEP4 - FINISH OPTIONS
        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // STEP4 - FINISH OPTIONS
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP4 - FINISH OPTIONS - METHODS
        //

        private void StepFinalStepIn()
        {
            // Set instruction
            mWizard2 master2 = (mWizard2)this.Master;
            master2.WizardInstruction = "What would you like to do?";

            string url = "";
            int newServiceId = Int32.Parse(hdfNewServiceId.Value);

            url = "./services_summary.aspx?source_page=services_add_request.aspx&dashboard=" + hdfDashboard.Value + "&service_id=" + newServiceId + "&active_tab=0" + GetNavigatorState();
            lkbtnOpenService.Attributes.Add("onclick", string.Format("return lkbtnOpenServiceClick('{0}');", url));

            url = "./services_edit.aspx?source_page=services_add_request.aspx&dashboardFromAddService=True&dashboard=" + hdfDashboard.Value + "&service_id=" + newServiceId + "&active_tab=0" + GetNavigatorState();
            lkbtnEditService.Attributes.Add("onclick", string.Format("return lkbtnEditServiceClick('{0}');", url));

            lkbtnClose.Attributes.Add("onclick", "return lkbtnCloseClick();");
        }

        #endregion






        // ////////////////////////////////////////////////////////////////////////
        // FINAL EVENTS 
        //

        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set wizard title
            Label title = (Label)this.Master.FindControl("lblTitle");
            title.Text = "Add Service Request";
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //
        
        private void RegisterClientScripts()
        {
            // Register content variables
            string contentVariables = "";
            contentVariables += "var tbxMileageId = '" + tbxMileage.ClientID + "';";
            contentVariables += "var tbxStartWorkStartMileageId = '" + tbxStartWorkStartMileage.ClientID + "';";
            contentVariables += "var tbxCompleteWorkCompleteMileageId = '" + tbxCompleteWorkCompleteMileage.ClientID + "';";

            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./services_add_request.js");
        }



        private void TagPage()
        {
            hdfInitialUnitId.Value = (string)Request.QueryString["unit_id"];
            hdfRuleId.Value = (string)Request.QueryString["rule_id"];
            hdfDashboard.Value = (string)Request.QueryString["dashboard"];
            hdfCompanyId.Value = Convert.ToInt32(Session["companyID"]).ToString();

            // Initialize general data
            hdfMtoDto.Value = "";
            hdfMileage.Value = "";
            hdfMileageUnitOfMeasurement.Value = "";
            hdfDescription.Value = "";

            // Initialize assigment data
            hdfUnassigned.Value = "";
            hdfTeamMemberId.Value = "";
            hdfTeamMemberFullName.Value = "";
            hdfThirdPartyVendor.Value = "";
            hdfDeadlineDate.Value = "";

            // Initialize variables: Accept step
            hdfAcceptSR.Value = "False";

            // Initialize variables: Start step
            hdfStartSR.Value = "False";
            hdfUnitOutOfServiceDate.Value = "";
            hdfUnitOutOfServiceTime.Value = "";
            hdfStartMileage.Value = "";

            // Initialize variables: Complete step
            hdfCompleteSR.Value = "False";
            hdfUnitBackInServiceDate.Value = "";
            hdfUnitBackInServiceTime.Value = "";
            hdfCompleteWorkMileage.Value = "";
            hdfCompleteWorkDescription.Value = "";
            hdfCompleteWorkPreventable.Value = "False";
            hdfCompleteWorkLabourHours.Value = "";
            hdfCompleteWorkCosts.Value = "";
            hdfInvoiceAmount.Value = "";
            hdfInvoiceNumber.Value = "";
        }



        private void UpdateDatabase()
        {
            DB.Open();
            DB.BeginTransaction();
            try
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                int loginId = Convert.ToInt32(Session["loginID"]);

                EmployeeGateway employeeGateway = new EmployeeGateway(new DataSet());
                int employeeId = employeeGateway.GetEmployeIdByLoginId(loginId);
                DateTime dateTime_ = DateTime.Now;

                ServicesAddRequestBasicInformation servicesAddRequestBasicInformation = new ServicesAddRequestBasicInformation(servicesAddRequestTDS);
                int? serviceId = servicesAddRequestBasicInformation.Save(dateTime_, employeeId, companyId);

                // Save costs information
                if (serviceId.HasValue)
                {
                    hdfNewServiceId.Value = serviceId.ToString();
                    ServicesAddRequestCostInformation servicesAddRequestCostInformation = new ServicesAddRequestCostInformation(servicesAddRequestTDS);
                    servicesAddRequestCostInformation.Save((int)serviceId, companyId);
                }

                DB.CommitTransaction();

                // Store datasets
                servicesAddRequestTDS.AcceptChanges();
                Session["servicesAddRequestTDS"] = servicesAddRequestTDS;

            }
            catch (Exception ex)
            {
                DB.RollbackTransaction();

                string url = string.Format("./../../error_page.aspx?error={0}", ex.Message.Replace('\n', ' '));
                Response.Redirect(url);
            }
        }



        private void PostPageChanges()
        {
            // Unit
            int unitId = Int32.Parse(hdfUnitId.Value);

            // Service state
            string serviceState = "Unassigned";
            if ((rbtnAssignToMyself.Checked) || (rbtnAssignToTeamMember.Checked) || (rbtnAssignToThirdPartyVendor.Checked)) serviceState = "Assigned";
            if (ckbxAcceptSR.Checked) serviceState = "Accepted";
            if (ckbxStartSR.Checked) serviceState = "In Progress";
            if (ckbxCompleteSR.Checked) serviceState = "Completed";

            // basic variables
            int companyId = Int32.Parse(hdfCompanyId.Value);
            bool mtoDot = Boolean.Parse(hdfMtoDto.Value);
            string serviceDescription = hdfDescription.Value;
            DateTime? assignDeadlineDate = null; if (hdfDeadlineDate.Value != "") assignDeadlineDate = DateTime.Parse(hdfDeadlineDate.Value);
            
            bool assignTeamMember = false;
            int? assignTeamMemberId = null;
            if ((hdfAssignToMyself.Value == "True") || (hdfAssignToTeamMember.Value == "True"))
            {
                assignTeamMember = true;
                assignTeamMemberId = Int32.Parse(hdfTeamMemberId.Value);
            }

            string assignThirdPartyVendor = "";
            if (hdfThirdPartyVendor.Value != "")
            {
                assignThirdPartyVendor = hdfThirdPartyVendor.Value;
            }

            DateTime? assignDateTime = null; if (!rbtnUnassigned.Checked) assignDateTime = DateTime.Now;
            DateTime? acceptDateTime = null; if (ckbxAcceptSR.Checked) acceptDateTime = DateTime.Now;
            DateTime? unitOutOfServiceDate = null; if (hdfUnitOutOfServiceDate.Value != "") unitOutOfServiceDate = DateTime.Parse(hdfUnitOutOfServiceDate.Value);
            string unitOutOfServiceTime = hdfUnitOutOfServiceTime.Value;
            
            DateTime? completeWorkDateTime = null; if (ckbxCompleteSR.Checked) completeWorkDateTime = DateTime.Now;
            DateTime? unitBackInServiceDate = null; if (hdfUnitBackInServiceDate.Value != "") unitBackInServiceDate = DateTime.Parse(hdfUnitBackInServiceDate.Value);
            string unitBackInServiceTime = hdfUnitBackInServiceTime.Value;

            string completeWorkDetailDescription = hdfCompleteWorkDescription.Value;
            bool completeWorkDetailPreventable = Boolean.Parse(hdfCompleteWorkPreventable.Value);
            Decimal? completeWorkDetailTMLabourHours = null; if (hdfCompleteWorkLabourHours.Value != "") completeWorkDetailTMLabourHours = decimal.Parse(hdfCompleteWorkLabourHours.Value);
            Decimal? completeWorkDetailTMCost = null; if (hdfCompleteWorkCosts.Value != "") completeWorkDetailTMCost = decimal.Parse(hdfCompleteWorkCosts.Value);
            string completeWorkInvoiceNumber = ""; if (hdfInvoiceNumber.Value != "") completeWorkInvoiceNumber = hdfInvoiceNumber.Value;
            Decimal? completeWorkInvoiceAmount = null; if (hdfInvoiceAmount.Value != "") completeWorkInvoiceAmount = decimal.Parse(hdfInvoiceAmount.Value);
            string mileage = ""; if (hdfMileage.Value != "") mileage = hdfMileage.Value;
            string startWorkMileage = ""; if (hdfStartMileage.Value != "") startWorkMileage = hdfStartMileage.Value;
            string completeWorkMileage = ""; if (hdfCompleteWorkMileage.Value != "") completeWorkMileage = hdfCompleteWorkMileage.Value;
            int? ruleId = null; if (hdfRuleId.Value != "") ruleId = Int32.Parse(hdfRuleId.Value);

            // Insert to dataset
            ServicesAddRequestBasicInformation servicesAddRequestBasicInformation = new ServicesAddRequestBasicInformation(servicesAddRequestTDS);
            servicesAddRequestBasicInformation.Insert(serviceState, mtoDot, serviceDescription, assignDeadlineDate, assignDateTime, assignTeamMember, assignTeamMemberId, assignThirdPartyVendor, acceptDateTime, unitOutOfServiceDate, unitOutOfServiceTime, completeWorkDateTime, unitBackInServiceDate, unitBackInServiceTime, completeWorkDetailDescription, completeWorkDetailPreventable, completeWorkDetailTMLabourHours, completeWorkDetailTMCost, completeWorkInvoiceNumber, completeWorkInvoiceAmount, unitId, mileage, startWorkMileage, completeWorkMileage, false, companyId, ruleId);

            // Store session
            Session["servicesAddRequestTDS"] = servicesAddRequestTDS;
        }



        private string GetSummary()
        {            
            string summary = "GENERAL INFORMATION \n";
            summary = summary + "Service Number: " + GetServiceNumber() + "\n";
            summary = summary + "Unit: " + hdfUnitCode.Value + "\n";
            summary = summary + "Fixed Date: ";
            if (hdfMtoDto.Value == "True") summary = summary + "Yes "; else summary = summary + "No ";
            summary = summary + "\n";

            if (hdfUnitType.Value == "Vehicle")
            {
                summary = summary + "Mileage: " +  hdfMileage.Value + " " + hdfMileageUnitOfMeasurement.Value;                
                summary = summary + "\n";
            }

            summary = summary + "Problem Description: " + hdfDescription.Value + "\n";

            // ... Assignation information
            if ((rbtnAssignToMyself.Checked) || (rbtnAssignToTeamMember.Checked) || (rbtnAssignToThirdPartyVendor.Checked))
            {
                summary = summary + "\nASSIGMENT INFORMATION \n";
                if (hdfDeadlineDate.Value != "")
                {
                    DateTime deadlineDate = DateTime.Parse(hdfDeadlineDate.Value);
                    string deadlineDateText = deadlineDate.Month.ToString() + "/" + deadlineDate.Day.ToString() + "/" + deadlineDate.Year.ToString();

                    summary = summary + "Deadline date: " + deadlineDateText + "\n";
                }
                else
                {
                    summary = summary + "Deadline date: \n";
                }

                // ... ... Assigned Personal 
                if (hdfAssignToTeamMember.Value == "True")
                {
                    summary = summary + "Assigned team member: " + hdfTeamMemberFullName.Value + "\n";
                }

                // ... ... Assigned third party vendor
                if (hdfAssignToThirdPartyVendor.Value == "True")
                {
                    summary = summary + "Assigned third party vendor: " + hdfThirdPartyVendor.Value + "\n";
                }

                // ... ... Asssigned to myself
                if (hdfAssignToMyself.Value == "True")
                {
                    summary = summary + "Assigned to myself: YES \n";
                }
            }

            if (ckbxStartSR.Checked)
            {
                summary = summary + "\nSTART WORK INFORMATION \n";
                DateTime unitOutOfServiceDate = DateTime.Parse(hdfUnitOutOfServiceDate.Value);
                string unitOutOfServiceDateText = unitOutOfServiceDate.Month.ToString() + "/" + unitOutOfServiceDate.Day.ToString() + "/" + unitOutOfServiceDate.Year.ToString();
                summary = summary + "Unit Out Of Service Date: " + unitOutOfServiceDateText + "\n";

                summary = summary + "Unit Out Of Service Time: " + hdfUnitOutOfServiceTime.Value + "\n";
                
                if (hdfUnitType.Value == "Vehicle")
                {
                    summary = summary + "Start Work Mileage: " + hdfStartMileage.Value + " "+ hdfMileageUnitOfMeasurement.Value;                    
                    summary = summary + "\n";
                }
            }

            if (ckbxCompleteSR.Checked)
            {
                summary = summary + "\nCOMPLETE WORK INFORMATION \n";
                DateTime unitBackInServiceDate = DateTime.Parse(hdfUnitBackInServiceDate.Value);
                string unitBackInServiceDateText = unitBackInServiceDate.Month.ToString() + "/" + unitBackInServiceDate.Day.ToString() + "/" + unitBackInServiceDate.Year.ToString();
                summary = summary + "Unit Back In Service Date: " + unitBackInServiceDateText + "\n";

                summary = summary + "Unit Back In Service Time: " + hdfUnitBackInServiceTime.Value + "\n";


                if (hdfUnitType.Value == "Vehicle")
                {
                    summary = summary + "Complete Work Mileage: " + hdfCompleteWorkMileage.Value + " " + hdfMileageUnitOfMeasurement.Value;                    
                    summary = summary + "\n";
                }

                summary = summary + "Complete Work Description: " + hdfCompleteWorkDescription.Value + "\n";

                summary = summary + "Preventable: ";
                if (hdfCompleteWorkPreventable.Value == "True") summary = summary + "Yes "; else summary = summary + "No ";
                summary = summary + "\n";

                if (hdfCompleteWorkLabourHours.Value != "")
                {                   
                    summary = summary + "Labour Hours: " + hdfCompleteWorkLabourHours.Value + "\n";
                }
                else
                {                    
                    summary = summary + "Invoice Number: "+ hdfInvoiceNumber.Value + "\n";

                    summary = summary + "Invoice Amount: "+ hdfInvoiceAmount.Value + "\n";                    
                }
            }

            // Service state
            string serviceState = "Unassigned";
            if ((rbtnAssignToMyself.Checked) || (rbtnAssignToTeamMember.Checked) || (rbtnAssignToThirdPartyVendor.Checked)) serviceState = "Assigned";
            if (ckbxAcceptSR.Checked) serviceState = "Accepted";
            if (ckbxStartSR.Checked) serviceState = "In Progress";
            if (ckbxCompleteSR.Checked) serviceState = "Completed";
            hdfServiceState.Value = serviceState;
            summary = summary + "\nSERVICE STATE: " + serviceState + "\n";

            return summary;
        }



        private string GetServiceNumber()
        {
            int newNumber = 0;

            // Load last service number
            ServicesGateway servicesGateway = new ServicesGateway();
            servicesGateway.LoadTop1ByServiceId(Int32.Parse(hdfCompanyId.Value));

            if (servicesGateway.Table.Rows.Count > 0)
            {
                int lastNumber = Int32.Parse(servicesGateway.GetNumberTop1());
                newNumber = lastNumber + 1;
            }
            else
            {
                newNumber = 1;
            }

            return newNumber.ToString();
        }



        private string GetNavigatorState()
        {
            // Columns to display
            int companyId = Int32.Parse(Session["companyID"].ToString());
            string fmType = "Services";
            string columnsToDisplay = "&columns_to_display=";

            FmTypeViewDisplay fmTypeViewDisplay = new FmTypeViewDisplay();
            columnsToDisplay = columnsToDisplay + fmTypeViewDisplay.GetColumnsByDefault(fmType, companyId, true);          
            
            // SearchOptions for condition 1
            string searchOptions = "";
            searchOptions = searchOptions + "&search_ddlCondition1=1";
            searchOptions = searchOptions + "&search_tbxCondition1=%";

            // For Views
            searchOptions = searchOptions + "&search_ddlView=-2";

            // Other values
            searchOptions = searchOptions + "&search_state=1";
            searchOptions = searchOptions + "&search_sort_by=1";
            searchOptions = searchOptions + "&btn_origin=Search";

            // Return
            return columnsToDisplay + searchOptions;
        }



        public void SendMailTeamMember()
        {
            // Get mail information
            string mailTo = "";
            string nameTo = "";
            string subject = "You have assigned service requests.";
            string body = "";

            if (hdfAssignToTeamMember.Value == "True")
            {
                int employeeId = Int32.Parse(hdfTeamMemberId.Value);

                EmployeeGateway employeesGateway = new EmployeeGateway();
                employeesGateway.LoadForMailsByEmployeeId(employeeId);

                if (employeesGateway.Table.Rows.Count > 0)
                {
                    // Assigned TeamMember
                    mailTo = employeesGateway.GetEMail(employeeId);
                    nameTo = employeesGateway.GetFirstName(employeeId) + " " + employeesGateway.GetLastName(employeeId);
                }

                // Mails body
                body = body + "\nHi " + nameTo + ",\n\nThe following service request has been assigned to you. \n";
                body = body + "\n Unit: " + hdfUnitCode.Value;
                body = body + "\n Fixed Date: ";
                if (hdfMtoDto.Value == "True") body = body + "Yes "; else body = body + "No ";

                if (hdfUnitType.Value == "Vehicle")
                {
                    body = body + "\n Mileage: " + hdfMileage.Value + " " + hdfMileageUnitOfMeasurement.Value;                    
                }

                body = body + "\n Problem Description: " + hdfDescription.Value;

                if (hdfDeadlineDate.Value != "")
                {
                    DateTime deadlineDate = DateTime.Parse(hdfDeadlineDate.Value);
                    string deadlineDateText = deadlineDate.Month.ToString() + "/" + deadlineDate.Day.ToString() + "/" + deadlineDate.Year.ToString();
                    body = body + "\n Deadline date: " + deadlineDateText;
                }
                else
                {
                    body = body + "\n Deadline date: ";
                }

                int registeredByLoginId = Convert.ToInt32(Session["loginID"]);
                employeesGateway.LoadByLoginId(registeredByLoginId);
                int registeredByEmployeeId = employeesGateway.GetEmployeIdByLoginId(registeredByLoginId);

                if (employeesGateway.Table.Rows.Count > 0)
                {
                    body = body + "\n Assigned By: " + employeesGateway.GetFirstName(registeredByEmployeeId) + " " + employeesGateway.GetLastName(registeredByEmployeeId);
                }
                                
                //Send Mail
                SendMail(mailTo, subject, body);
            }
        }



        public void SendMailFleetManager()
        {
            // Get mail information
            string mailTo = "";
            string nameTo = "";
            string subject = "New service request has been registered.";
            string body = "";

            // MailtTo, nameTo
            int companyLevelId = Int32.Parse(hdfCompanyLevel.Value);

            Employee employees = new Employee();
            employees.LoadByFleetManager(companyLevelId);

            mailTo = employees.GetAllFleetManagersEMails();
            nameTo = employees.GetAllFleetManagersNames();

            // Mails body
            body = body + "\nHi " + nameTo + ",\n\nThe following service request has been registered. \n";
            body = body + "\n Unit: " + hdfUnitCode.Value;
            body = body + "\n Fixed Date: ";
            if (hdfMtoDto.Value == "True") body = body + "Yes "; else body = body + "No ";

            if (hdfUnitType.Value == "Vehicle")
            {
                body = body + "\n Mileage: " + hdfMileage.Value + " " + hdfMileageUnitOfMeasurement.Value;
            }

            body = body + "\n Problem Description: " + hdfDescription.Value;

            // ... Assignation of work
            // ... ... Deadline date
            if (hdfDeadlineDate.Value != "")
            {
                DateTime deadlineDate = DateTime.Parse(hdfDeadlineDate.Value);
                string deadlineDateText = deadlineDate.Month.ToString() + "/" + deadlineDate.Day.ToString() + "/" + deadlineDate.Year.ToString();
                body = body + "\n Deadline date: " + deadlineDateText;
            }
            else
            {
                body = body + "\n Deadline date: ";
            }

            // ... ... Assigned Personal
            if (hdfAssignToTeamMember.Value == "True")
            {
                int employeeId = Int32.Parse(hdfTeamMemberId.Value);
                EmployeeGateway employeesGateway = new EmployeeGateway();
                employeesGateway.LoadForMailsByEmployeeId(employeeId);
                string assignedTo = "";
                if (employeesGateway.Table.Rows.Count > 0)
                {
                    // Assigned TeamMember
                    assignedTo = employeesGateway.GetFirstName(employeeId) + " " + employeesGateway.GetLastName(employeeId);
                }

                body = body + "\n Assigned Team Member: " + assignedTo;
            }

            // ... ... Assigned third party vendor
            if (hdfAssignToThirdPartyVendor.Value == "True")
            {
                body = body + "\n Assigned Third Party Vendor: " + hdfThirdPartyVendor.Value;
            }

            int registeredByLoginId = Convert.ToInt32(Session["loginID"]);
            EmployeeGateway employeeGateway = new EmployeeGateway();
            employeeGateway.LoadByLoginId(registeredByLoginId);
            int registeredByEmployeeId = employeeGateway.GetEmployeIdByLoginId(registeredByLoginId);

            // ... ... Assigned myself
            if (hdfAssignToMyself.Value == "True")
            {
                if (employeeGateway.Table.Rows.Count > 0)
                {
                    body = body + "\n Assigned to myself: " + employeeGateway.GetFirstName(registeredByEmployeeId) + " " + employeeGateway.GetLastName(registeredByEmployeeId);
                }
            }
            
            // Registered by
            if (employeeGateway.Table.Rows.Count > 0)
            {
                body = body + "\n Registered By: " + employeeGateway.GetFirstName(registeredByEmployeeId) + " " + employeeGateway.GetLastName(registeredByEmployeeId);
            }

            // Service State
            body = body + "\n\n Service State: " + hdfServiceState.Value;
            
            //Send Mail
            SendMail(mailTo, subject, body);
        }



        private void SendMail(string mailTo, string subject, string body)
        {
            //SendMailLiveSite(mailTo, subject, body);
            //SendMailTestSite(mailTo, subject, body);
        }



        private void SendMailLiveSite(string mailTo, string subject, string body)
        {
            string error;

            // For live site
            string entireBody = "";

            if ((mailTo != "") && (subject != "") && (body != ""))
            {
                entireBody = entireBody + body + "\n\n\n\n\nRegards,\n\n" + "LFS Admin Team.\n\n";
                LiquiForce.LFSLive.WebUI.Common.Tools.Mail.SendMail(mailTo, "sussel@nerdsonsite.com", subject, entireBody, false, out error);
            }
        }



        private void SendMailTestSite(string mailTo, string subject, string body)
        {
            string error;

            // For Test Site
            string entireBody = "--- SENT FROM THE TEST SITE --- \n";

            if ((mailTo != "") && (subject != "") && (body != ""))
            {
                entireBody = entireBody + body + "\n\n\n\n\nRegards,\n\n" + "LFS Admin Team.\n\n";
                LiquiForce.LFSLive.WebUI.Common.Tools.Mail.SendMail("humberto@nerdsonsite.com", "sussel@nerdsonsite.com, humberto@nerdsonsite.com, jacqueline.claure@nerdsonsite.com", subject, entireBody, false, out error);
            }
        }
               

           
    }
}