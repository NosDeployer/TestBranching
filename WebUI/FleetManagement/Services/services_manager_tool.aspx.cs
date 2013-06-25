using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.DA.FleetManagement.Services;
using LiquiForce.LFSLive.BL.FleetManagement.Services;
using LiquiForce.LFSLive.DA.Resources.Employees;
using LiquiForce.LFSLive.BL.Resources.Employees;
using LiquiForce.LFSLive.BL.FleetManagement.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Units;
using LiquiForce.LFSLive.DA.FleetManagement.CompanyLevels;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.RAF;

namespace LiquiForce.LFSLive.WebUI.FleetManagement.Services
{
    /// <summary>
    /// services_manager_tool
    /// </summary>
    public partial class services_manager_tool : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected ServiceRequestsManagerToolTDS serviceRequestsManagerToolTDS;
        protected ServiceRequestsManagerToolTDS.ServiceRequestsDataTable serviceRequests;
        protected ServiceRequestsManagerToolTDS.CostInformationDataTable costInformation;
        protected ServiceInformationTDS serviceInformationTDS;
        protected ServiceInformationTDS.NoteInformationDataTable serviceInformationServiceNote;
        protected LibraryTDS libraryTDSForServices;






        // ////////////////////////////////////////////////////////////////////////
        // INITIAL EVENTS
        //

        protected void Page_Load(object sender, EventArgs e)
        {
            // Register client scripts
            this.RegisterClientScripts();

            if (!IsPostBack)
            {
                if (Session["dialogOpenedServicesManagerTool"] == null)
                {
                    // Security check
                    if (!(Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_SERVICES_ADD"])) || !(Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_SERVICES_ADMIN"])))
                    {
                        Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                    }

                    // Validate query string
                    if ((string)Request.QueryString["source_page"] == null)
                    {
                        Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in services_manager_tool.aspx");
                    }

                    // Tag Page
                    TagPage();

                    // Initialize viewstate variables
                    ViewState["StepFrom"] = "Out";
                    Session.Remove("serviceRequests");
                    Session.Remove("serviceRequestsDummy");
                    Session.Remove("serviceRequestsManagerToolTDS");
                    Session.Remove("serviceCostsDummyManagerTool");
                    Session.Remove("costInformationManagerTool");
                    Session.Remove("serviceNotesDummyManagerTool");
                    Session.Remove("serviceInformationTDSForManagerTool");
                    Session.Remove("libraryTDSForServices");
                                        
                    serviceInformationTDS = new ServiceInformationTDS();

                    // If coming from 
                    // ... lm or services_navigator.aspx
                    if ((Request.QueryString["source_page"] == "lm") || (Request.QueryString["source_page"] == "services_navigator.aspx") || (Request.QueryString["source_page"] == "services_navigator2.aspx"))
                    {
                        // ... Initialize tables
                        serviceRequestsManagerToolTDS = new ServiceRequestsManagerToolTDS();

                        int companyId = Int32.Parse(hdfCompanyId.Value);

                        ServiceRequestsManagerToolServiceRequests serviceRequestsManagerToolServiceRequests = new ServiceRequestsManagerToolServiceRequests(serviceRequestsManagerToolTDS);
                        serviceRequestsManagerToolServiceRequests.LoadAll(companyId);

                        // ... Store tables
                        Session["serviceRequestsManagerToolTDS"] = serviceRequestsManagerToolTDS;
                        Session["serviceRequests"] = serviceRequestsManagerToolTDS.ServiceRequests;
                    }

                    // ... For Library
                    if (Session["libraryTDSForServices"] != null)
                    {
                        libraryTDSForServices = (LibraryTDS)Session["libraryTDSForServices"];
                    }
                    else
                    {
                        libraryTDSForServices = new LibraryTDS();
                    }

                    Session["serviceInformationTDSForManagerTool"] = serviceInformationTDS;

                    // StepSection1In
                    wzServices.ActiveStepIndex = 0;
                    StepBeginIn();
                }
                else
                {
                    if ((string)Session["dialogOpenedServicesManagerTool"] == "1")
                    {
                        // Tag Page
                        hdfCompanyId.Value = Convert.ToInt32(Session["companyID"]).ToString();
                        hdfDashboard.Value = (string)Request.QueryString["dashboard"];

                        hdfSelectedSRId.Value = (string)Session["selecctedServiceID"];

                        // Restore tables
                        serviceRequestsManagerToolTDS = (ServiceRequestsManagerToolTDS)Session["serviceRequestsManagerToolTDS"];
                        serviceInformationTDS = (ServiceInformationTDS)Session["serviceInformationTDSForManagerTool"];

                        // ... For Library
                        if (Session["libraryTDSForServices"] != null)
                        {
                            libraryTDSForServices = (LibraryTDS)Session["libraryTDSForServices"];
                        }
                        else
                        {
                            libraryTDSForServices = new LibraryTDS();
                        }

                        // StepSection1In
                        wzServices.ActiveStepIndex = 1;
                        StepStepsInformationIn();
                    }
                }
            }
            else
            {
                // Restore tables
                serviceRequestsManagerToolTDS = (ServiceRequestsManagerToolTDS)Session["serviceRequestsManagerToolTDS"];
                serviceInformationTDS = (ServiceInformationTDS)Session["serviceInformationTDSForManagerTool"];

                // ... For Library
                if (Session["libraryTDSForServices"] != null)
                {
                    libraryTDSForServices = (LibraryTDS)Session["libraryTDSForServices"];
                }
                else
                {
                    libraryTDSForServices = new LibraryTDS();
                }
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

                    case "Steps Information":
                        StepStepsInformationIn();
                        break;

                    case "Summary":
                        StepSummaryIn();
                        break;

                    case "Final Step":
                        StepFinalStepIn();
                        wzServices.ActiveStepIndex = wzServices.WizardSteps.IndexOf(StepFinalStep);
                        break;

                    default:
                        throw new Exception("The option for " + wzServices.ActiveStep.Name + " step in services_manager_tool.Wizard_ActiveStepChanged function does not exist");
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
                        ViewState["StepFrom"] = "Begin";
                    }
                    break;

                case "Steps Information":
                    e.Cancel = !StepStepsInformationNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "Steps Information";
                    }
                    break;


                default:
                    throw new Exception("The option for " + wzServices.ActiveStep.Name + " step in services_manager_tool.Wizard_NextButtonClick function does not exist");
            }
        }



        protected void Wizard_PreviousButtonClick(object sender, WizardNavigationEventArgs e)
        {
            switch (wzServices.ActiveStep.Name)
            {
                case "Steps Information":
                    e.Cancel = !StepStepsInformationPrevious();
                    break;

                case "Summary":
                    e.Cancel = !StepSummaryPrevious();
                    break;

                default:
                    throw new Exception("The option for " + wzServices.ActiveStep.Name + " step in services_manager_tool.Wizard_PreviousButtonClick function does not exist");
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
        // STEP1 - BEGIN - AUXILIAR EVENTS
        //
        
        protected void grdServiceRequests_DataBound(object sender, EventArgs e)
        {
            AddServiceRequestNewEmptyFix(grdServiceRequests);
        }



        protected void grdServiceRequests_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // normal items
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Normal) || (e.Row.RowState == (DataControlRowState.Normal | DataControlRowState.Alternate))))
            {
                if (((Label)e.Row.FindControl("lblState")).Text == "Completed")
                {
                    ((CheckBox)e.Row.FindControl("cbxSelected")).Visible = false;               
                }
            }
        }



        protected void grdServiceRequests_Sorting(object sender, GridViewSortEventArgs e)
        {
            string oldSort = serviceRequestsManagerToolTDS.ServiceRequests.DefaultView.Sort;

            if (!oldSort.Contains(e.SortExpression.ToString()))
            {
                serviceRequestsManagerToolTDS.ServiceRequests.DefaultView.Sort = e.SortExpression + " ASC";
            }
            else
            {
                if (oldSort.Contains("ASC"))
                {
                    serviceRequestsManagerToolTDS.ServiceRequests.DefaultView.Sort = e.SortExpression + " DESC";
                }
                else
                {
                    serviceRequestsManagerToolTDS.ServiceRequests.DefaultView.Sort = e.SortExpression + " ASC";
                }
            }

            // Store data
            Session["serviceRequestsManagerToolTDS"] = serviceRequestsManagerToolTDS;
            Session["serviceRequests"] = serviceRequestsManagerToolTDS.ServiceRequests;
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP1 - BEGIN - METHODS
        //

        private void StepBeginIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Please select the Service Request to complete";

            // Prepare initial data
            lblError.Visible = false;

            // If coming from Dashboard
            if ((string)Request.QueryString["service_id"] != null)
            {
                hdfSelectedSRId.Value = (string)Request.QueryString["service_id"];

                // Select serviceId at grid
                foreach (GridViewRow row in grdServiceRequests.Rows)
                {
                    // ... Update all rows                    
                    string srIdForUpdate = ((Label)row.FindControl("lblServiceId")).Text.Trim();
                    
                    // ... Save selected project
                    if (srIdForUpdate == hdfSelectedSRId.Value)
                    {
                        ((CheckBox)row.FindControl("cbxSelected")).Checked = true;
                    }
                }
            }
        }



        private bool StepBeginNext()
        {
            int serviceId = 0;
            SaveSelectedSRId();
            serviceId = Int32.Parse(hdfSelectedSRId.Value);

            if (serviceId != 0)
            {
                lblError.Visible = false;
                return true;                
            }

            lblError.Visible = true;
            return false;
        }



        public ServiceRequestsManagerToolTDS.ServiceRequestsDataTable GetServiceRequests()
        {
            serviceRequests = (ServiceRequestsManagerToolTDS.ServiceRequestsDataTable)Session["serviceRequestsDummy"];
            if (serviceRequests == null)
            {
                serviceRequests = ((ServiceRequestsManagerToolTDS.ServiceRequestsDataTable)Session["serviceRequests"]);
            }

            return serviceRequests;
        }



        protected void AddServiceRequestNewEmptyFix(GridView grdServiceRequests)
        {
            if (grdServiceRequests.Rows.Count == 0)
            {
                ServiceRequestsManagerToolTDS.ServiceRequestsDataTable dt = new ServiceRequestsManagerToolTDS.ServiceRequestsDataTable();
                dt.AddServiceRequestsRow(-1, -1, "", "", false, false);
                Session["serviceRequestsDummy"] = dt;

                grdServiceRequests.DataBind();
            }

            // Normally executes at all postbacks
            if (grdServiceRequests.Rows.Count == 1)
            {
                ServiceRequestsManagerToolTDS.CostInformationDataTable dt = (ServiceRequestsManagerToolTDS.CostInformationDataTable)Session["serviceRequestsDummy"];
                if (dt != null)
                {
                    grdServiceRequests.Rows[0].Visible = false;
                    grdServiceRequests.Rows[0].Controls.Clear();
                }
            }
        }



        protected void SaveSelectedSRId()
        {
            int srIdForUpdate = 0;
            bool selected = false;
            hdfSelectedSRId.Value = "0";

            ServiceRequestsManagerToolServiceRequests serviceRequestsManagerToolServiceRequests = new ServiceRequestsManagerToolServiceRequests(serviceRequestsManagerToolTDS);

            foreach (GridViewRow row in grdServiceRequests.Rows)
            {
                // ... Update all rows
                selected = ((CheckBox)row.FindControl("cbxSelected")).Checked;
                srIdForUpdate = Int32.Parse(((Label)row.FindControl("lblServiceId")).Text.Trim());
                serviceRequestsManagerToolServiceRequests.Update(srIdForUpdate, selected);

                // ... Save selected project
                if (selected)
                {
                    hdfSelectedSRId.Value = srIdForUpdate.ToString();
                }
            }

            serviceRequestsManagerToolServiceRequests.Data.AcceptChanges();

            // ... Store datasets
            Session["serviceRequestsManagerToolTDS"] = serviceRequestsManagerToolTDS;
            Session["serviceRequests"] = serviceRequestsManagerToolTDS.ServiceRequests;
        }





        #endregion






        #region STEP2 - STEPS INFORMATION

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP2 - STEPS INFORMATION
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP2 - STEPS INFORMATION - EVENTS
        //

        protected void grdCosts_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Costs Gridview, if the gridview is edition mode
            if (grdCosts.EditIndex >= 0)
            {
                grdCosts.UpdateRow(grdCosts.EditIndex, true);
            }

            // Delete costs
            int serviceId = (int)e.Keys["ServiceID"];
            int refId = (int)e.Keys["RefID"];
            int companyId = Int32.Parse(hdfCompanyId.Value);

            ServiceRequestsManagerToolCostInformation model = new ServiceRequestsManagerToolCostInformation(serviceRequestsManagerToolTDS);
            model.Delete(serviceId, refId);

            // Store dataset
            Session["serviceRequestsManagerToolTDS"] = serviceRequestsManagerToolTDS;
            Session["costInformationManagerTool"] = serviceRequestsManagerToolTDS.CostInformation;

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

                    // Add New Cost
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
                ServiceRequestsManagerToolCostInformation model = new ServiceRequestsManagerToolCostInformation(serviceRequestsManagerToolTDS);
                model.Update(serviceId, refId, partNumber, partName, vendor, cost);

                // Store dataset
                Session["serviceRequestsManagerToolTDS"] = serviceRequestsManagerToolTDS;
                Session["costInformationManagerTool"] = serviceRequestsManagerToolTDS.CostInformation;

                // Calc TotalCost
                tbxTotalCost.Text = Decimal.Round(model.GetTotalCost(serviceId, companyId), 2).ToString();
            }
            else
            {
                e.Cancel = true;
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP2 - STEPS INFORMATION - AUXILLIAR EVENTS
        //

        protected void rbtnAssignToMyself_CheckedChanged(object sender, EventArgs e)
        {
            if (hdfState.Value == "Unassigned")
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

            if ((!ckbxStartSR.Checked) && (ckbxCompleteSR.Checked) && (hdfPnlStartWorkInformation.Value == "True") && (hdfPnlCompleteWorkInformation.Value == "True"))
            {
                args.IsValid = false;
            }
        }



        protected void cvStartSR_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;
            CustomValidator cvConditions = (CustomValidator)source;

            if ((!ckbxAcceptSR.Checked) && (ckbxStartSR.Checked) && (hdfPnlStartWorkInformation.Value == "True") && (hdfAcceptInformation.Value == "True"))
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
                    cvConditions.ErrorMessage = "Please delete the out of service date.";
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
                        cvConditions.ErrorMessage = "Please provide a mileage.";
                        args.IsValid = false;
                    }
                }
                else
                {
                    if (tbxStartWorkStartMileage.Text != "")
                    {
                        cvConditions.ErrorMessage = "Please delete the mileage.";
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
                        cvConditions.ErrorMessage = "Please provide a mileage.";
                        args.IsValid = false;
                    }
                }
                else
                {
                    if (tbxCompleteWorkCompleteMileage.Text != "")
                    {
                        cvConditions.ErrorMessage = "Please delete the mileage.";
                        args.IsValid = false;
                    }
                }
            }
        }



        protected void grdCosts_DataBound(object sender, EventArgs e)
        {
            AddCostsNewEmptyFix(grdCosts);
        }



        protected void grdCosts_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Costs Gridview, if the gridview is edition mode
            if (grdCosts.EditIndex >= 0)
            {
                grdCosts.UpdateRow(grdCosts.EditIndex, true);
            }
        }



        private string GetFullCategoryName(int libraryCategoryId, int companyId)
        {
            int[] libraryArray = new int[100];
            int maxDeep = 0;

            for (int index = 0; index < libraryArray.Length; index++)
            {
                libraryArray[index] = -1;
            }

            string fullCategoryName = "";
            libraryArray = GetDeepParent(libraryCategoryId, 0, maxDeep, libraryArray, companyId);

            for (int index = 0; index < 100; index++)
            {
                if (libraryArray[index] > 0)
                {
                    if (index > 0)
                    {
                        fullCategoryName = fullCategoryName + "/";
                    }

                    LibraryCategoriesGateway libraryCategoriesGateway = new LibraryCategoriesGateway();
                    libraryCategoriesGateway.LoadAllByLibraryCategoriesId(libraryArray[index], companyId);
                    fullCategoryName = fullCategoryName + libraryCategoriesGateway.GetCategoryName(libraryArray[index]);

                }
            }

            return fullCategoryName;
        }



        private int[] GetDeepParent(int currentId, int deep, int maxDeep, int[] currentLibraryArray, int companyId)
        {
            int[] libraryArray = currentLibraryArray;
            ViewState["currentmaxDeep"] = maxDeep;

            LibraryCategoriesGateway libraryCategoriesGateway = new LibraryCategoriesGateway();
            libraryCategoriesGateway.LoadAllByLibraryCategoriesId(currentId, companyId);

            if (libraryCategoriesGateway.Table.Rows.Count > 0)
            {
                if (libraryCategoriesGateway.GetParentId(currentId) == 0)
                {
                    libraryArray[0] = currentId;
                    ViewState["currentmaxDeep"] = deep;
                    return libraryArray;
                }
                else
                {

                    libraryArray = GetDeepParent(libraryCategoriesGateway.GetParentId(currentId), deep + 1, (int)ViewState["currentmaxDeep"], libraryArray, companyId);
                    libraryArray[(int)ViewState["currentmaxDeep"] - deep] = currentId;
                    return libraryArray;
                }
            }
            else
            {
                return libraryArray;
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP2 - STEPS INFORMATION - METHODS
        //

        private void StepStepsInformationIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "";

            // Load data for selected service request
            int serviceId = Int32.Parse(hdfSelectedSRId.Value);
            int companyId = Int32.Parse(hdfCompanyId.Value);

            ServiceRequestsManagerToolBasicInformation serviceRequestsManagerToolBasicInformation = new ServiceRequestsManagerToolBasicInformation(serviceRequestsManagerToolTDS);
            ServiceRequestsManagerToolCostInformation serviceRequestsManagerToolCostInformation = new ServiceRequestsManagerToolCostInformation(serviceRequestsManagerToolTDS);
            ServiceInformationServiceNote serviceInformationServiceNoteForEdit = new ServiceInformationServiceNote(serviceInformationTDS);

            if (Session["dialogOpenedServicesManagerTool"] == null)
            {
                // ... Load basic data                
                serviceRequestsManagerToolBasicInformation.LoadByServiceId(serviceId, companyId);                

                // ... Load costs                
                serviceRequestsManagerToolCostInformation.LoadByServiceId(serviceId, companyId);

                //... Load notes                
                serviceInformationServiceNoteForEdit.LoadByServiceId(serviceId, companyId);
            }
            else
            {
                ServiceRequestsManagerToolBasicInformationGateway serviceRequestsManagerToolBasicInformationGateway2 = new ServiceRequestsManagerToolBasicInformationGateway(serviceRequestsManagerToolBasicInformation.Data);

                Session.Remove("dialogOpenedServicesManagerTool");

                if (serviceRequestsManagerToolBasicInformationGateway2.GetAcceptedDateTime(serviceId).HasValue) ckbxAcceptSR.Checked = true;
                if (serviceRequestsManagerToolBasicInformationGateway2.GetStartWorkDateTime(serviceId).HasValue) ckbxStartSR.Checked = true;
                if (serviceRequestsManagerToolBasicInformationGateway2.GetUnitOutOfServiceDate(serviceId).HasValue) tkrdpStartWorkUnitOutOfServiceDate.SelectedDate = serviceRequestsManagerToolBasicInformationGateway2.GetUnitOutOfServiceDate(serviceId);
                tbxStartWorkStartMileage.Text = serviceRequestsManagerToolBasicInformationGateway2.GetStartWorkMileage(serviceId);
                if (serviceRequestsManagerToolBasicInformationGateway2.GetCompleteWorkDateTime(serviceId).HasValue) ckbxCompleteSR.Checked = true;
                if (serviceRequestsManagerToolBasicInformationGateway2.GetUnitBackInServiceDate(serviceId).HasValue) tkrdpCompleteWorkUnitBackInServiceDate.SelectedDate = serviceRequestsManagerToolBasicInformationGateway2.GetUnitBackInServiceDate(serviceId);
                tbxCompleteWorkCompleteMileage.Text = serviceRequestsManagerToolBasicInformationGateway2.GetCompleteWorkMileage(serviceId);
                tbxCompleteWorkDataDescription.Text = serviceRequestsManagerToolBasicInformationGateway2.GetCompleteWorkDetailDescription(serviceId);
                ckbxPreventableTPV.Checked = serviceRequestsManagerToolBasicInformationGateway2.GetCompleteWorkDetailPreventable(serviceId);
                tbxCompleteWorkDataLabourHours.Text = serviceRequestsManagerToolBasicInformationGateway2.GetCompleteWorkDetailTMLabourHours(serviceId).ToString();
            }

            ServiceRequestsManagerToolBasicInformationGateway serviceRequestsManagerToolBasicInformationGateway = new ServiceRequestsManagerToolBasicInformationGateway(serviceRequestsManagerToolBasicInformation.Data);

            // Validate panels and information
            string state = serviceRequestsManagerToolBasicInformationGateway.GetServiceStateOriginal(serviceId);
            hdfState.Value = state;
            hdfServiceNumber.Value = serviceRequestsManagerToolBasicInformationGateway.GetServiceNumberOriginal(serviceId);
            hdfServiceDescription.Value = serviceRequestsManagerToolBasicInformationGateway.GetServiceDescriptionOriginal(serviceId);

            string originalThirdsPartyVendor = serviceRequestsManagerToolBasicInformationGateway.GetAssignedThirdPartyVendor(serviceId);
            int? unitId = null;
            if (serviceRequestsManagerToolBasicInformationGateway.GetUnitId(serviceId).HasValue)
            {
                unitId = (int)serviceRequestsManagerToolBasicInformationGateway.GetUnitId(serviceId);
                hdfUnitId.Value = unitId.ToString();
            }

            // ... Validate vehicle information
            if (unitId.HasValue)
            {
                UnitsGateway unitsGateway = new UnitsGateway();
                unitsGateway.LoadByUnitId((int)unitId, companyId);
                string unitType = unitsGateway.GetType((int)unitId);
                hdfUnitType.Value = unitType;
                int companyLevel = unitsGateway.GetCompanyLevelId((int)unitId);
                hdfCompanyLevel.Value = unitsGateway.GetCompanyLevelId((int)unitId).ToString();
                
                CompanyLevelGateway companyLevelGateway = new CompanyLevelGateway();
                companyLevelGateway.LoadByCompanyLevelId(companyLevel, companyId);                
                hdfMileageUnitOfMeasurement.Value = companyLevelGateway.GetUnitsUnitOfMeasurement(companyLevel);
                lblStartWorkStartMileageUnitOfMeasurement.Text = hdfMileageUnitOfMeasurement.Value;
                lblCompleteWorkCompleteMileageUnitOfMeasurement.Text = hdfMileageUnitOfMeasurement.Value;

                if (unitType == "Vehicle")
                {
                    lblStartWorkStartMileage.Visible = true;
                    tbxStartWorkStartMileage.Visible = true;
                    lblCompleteWorkCompleteMileage.Visible = true;
                    tbxCompleteWorkCompleteMileage.Visible = true;
                    lblStartWorkStartMileageUnitOfMeasurement.Visible = true;
                    lblCompleteWorkCompleteMileageUnitOfMeasurement.Visible = true;
                }
                else
                {
                    lblStartWorkStartMileage.Visible = false;
                    tbxStartWorkStartMileage.Visible = false;
                    lblStartWorkStartMileageUnitOfMeasurement.Visible = false;                    
                    lblCompleteWorkCompleteMileage.Visible = false;
                    tbxCompleteWorkCompleteMileage.Visible = false;
                    lblCompleteWorkCompleteMileageUnitOfMeasurement.Visible = false;
                }
            }

            // ... Validate visible internal panels (complete work info)
            if (state == "Unassigned")
            {
                if (!rbtnAssignToThirdPartyVendor.Checked)
                {
                    pnlAssignTeamMember.Visible = true;
                    pnlAssignThirdPartyVendor.Visible = false;
                }
                else
                {
                    pnlAssignThirdPartyVendor.Visible = true;
                    pnlAssignTeamMember.Visible = false;
                }
            }
            else
            {
                bool teamMemberAssigned = serviceRequestsManagerToolBasicInformationGateway.GetAssignTeamMember(serviceId);
                if (teamMemberAssigned)
                {
                    pnlAssignTeamMember.Visible = true;
                    pnlAssignThirdPartyVendor.Visible = false;
                }
                else
                {
                    pnlAssignThirdPartyVendor.Visible = true;
                    pnlAssignTeamMember.Visible = false;
                }
            }

            // ... Validate panels
            switch (state)
            {
                case "Unassigned":                    
                    pnlAssignmentInformation.Visible = true;
                    acceptInformationSeparator.Visible = true;
                    pnlAcceptInformation.Visible = true;
                    startWorkSeparator.Visible = true;
                    pnlStartWorkInformation.Visible = true;
                    completeWorkSeparator.Visible = true;
                    pnlCompleteWorkInformation.Visible = true;
                    break;

                case "Assigned":
                    pnlAssignmentInformation.Visible = false;
                    acceptInformationSeparator.Visible = false;
                    pnlAcceptInformation.Visible = true;
                    startWorkSeparator.Visible = true;
                    pnlStartWorkInformation.Visible = true;
                    completeWorkSeparator.Visible = true;
                    pnlCompleteWorkInformation.Visible = true;
                    break;

                case "Rejected":
                    pnlAssignmentInformation.Visible = true;
                    acceptInformationSeparator.Visible = true;
                    pnlAcceptInformation.Visible = true;
                    startWorkSeparator.Visible = true;
                    pnlStartWorkInformation.Visible = true;
                    completeWorkSeparator.Visible = true;
                    pnlCompleteWorkInformation.Visible = true;
                    break;

                case "Accepted":
                    pnlAssignmentInformation.Visible = false;
                    acceptInformationSeparator.Visible = false;
                    pnlAcceptInformation.Visible = false;
                    startWorkSeparator.Visible = false;
                    pnlStartWorkInformation.Visible = true;
                    completeWorkSeparator.Visible = true;
                    pnlCompleteWorkInformation.Visible = true;
                    break;

                case "In Progress":                 
                    pnlAssignmentInformation.Visible = false;
                    acceptInformationSeparator.Visible = false;
                    pnlAcceptInformation.Visible = false;
                    startWorkSeparator.Visible = false;
                    pnlStartWorkInformation.Visible = false;
                    completeWorkSeparator.Visible = false;
                    pnlCompleteWorkInformation.Visible = true;
                    break;

                default:
                    throw new Exception("The option for " + wzServices.ActiveStep.Name + " step in services_manager_tool.Wizard_ActiveStepChanged function does not exist");
            }

            hdfPnlAcceptInformation.Value = pnlAcceptInformation.Visible.ToString();
            hdfPnlAssignmentInformation.Value = pnlAssignmentInformation.Visible.ToString();
            hdfPnlStartWorkInformation.Value = pnlStartWorkInformation.Visible.ToString();
            hdfPnlCompleteWorkInformation.Value = pnlCompleteWorkInformation.Visible.ToString();

            // ... Load resource library
            int? libraryCategoriesId = null; if (serviceRequestsManagerToolBasicInformationGateway.GetLibraryCategoriesId(serviceId).HasValue) libraryCategoriesId = (int)serviceRequestsManagerToolBasicInformationGateway.GetLibraryCategoriesId(serviceId);

            if (libraryCategoriesId.HasValue)
            {
                ViewState["libraryCategoriesId"] = (int)libraryCategoriesId;
                tbxCategoryAssocited.Text = GetFullCategoryName((int)libraryCategoriesId, companyId);
                btnAssociate.Visible = false;
                btnUnassociate.Visible = true;
            }
            else
            {
                tbxCategoryAssocited.Text = "";
                btnAssociate.Visible = true;
                btnUnassociate.Visible = false;
            }

            // Store session
            Session["serviceRequestsManagerToolTDS"] = serviceRequestsManagerToolTDS;
        }



        private bool StepStepsInformationNext()
        {
            bool valid = ValidatePage();
            
            if (valid)
            {
                // Assigment Information
                if (pnlAssignmentInformation.Visible)
                {                    
                    hdfDeadlineDate.Value = ""; if (tkrdpDeadlineDate.SelectedDate.HasValue) hdfDeadlineDate.Value = tkrdpDeadlineDate.SelectedDate.Value.ToString();

                    // ... Myself
                    hdfAssignToMyself.Value = rbtnAssignToMyself.Checked.ToString();
                    if (rbtnAssignToMyself.Checked)
                    {
                        int loginId = Convert.ToInt32(Session["loginID"]);
                        EmployeeGateway employeeGateway = new EmployeeGateway(new DataSet());
                        hdfTeamMemberId.Value = employeeGateway.GetEmployeIdByLoginId(loginId).ToString();
                    }

                    // ... Team Member
                    hdfAssignToTeamMember.Value = rbtnAssignToTeamMember.Checked.ToString();
                    if (rbtnAssignToTeamMember.Checked)
                    {
                        hdfTeamMemberId.Value = ""; if (ddlAssignToTeamMember.SelectedValue != "") hdfTeamMemberId.Value = ddlAssignToTeamMember.SelectedValue;
                        hdfTeamMemberFullName.Value = ""; if (ddlAssignToTeamMember.SelectedItem.Text != "") hdfTeamMemberFullName.Value = ddlAssignToTeamMember.SelectedItem.Text;
                        hdfThirdPartyVendor.Value = "";
                    }

                    // ... Third party vendor
                    hdfAssignToThirdPartyVendor.Value = rbtnAssignToThirdPartyVendor.Checked.ToString();
                    if (rbtnAssignToThirdPartyVendor.Checked)
                    {
                        hdfTeamMemberId.Value = "";
                        hdfTeamMemberFullName.Value = "";
                        hdfThirdPartyVendor.Value = ""; if (tbxAssignToThirdPartyVendor.Text != "") hdfThirdPartyVendor.Value = tbxAssignToThirdPartyVendor.Text.Trim();
                    }
                }

                // Accept information
                if (pnlAcceptInformation.Visible)
                {
                    hdfAcceptSR.Value = ckbxAcceptSR.Checked.ToString();
                }
                
                // Start work information
                if (pnlStartWorkInformation.Visible)
                {
                    hdfStartSR.Value = ckbxStartSR.Checked.ToString();

                    if (ckbxStartSR.Checked)
                    {
                        hdfUnitOutOfServiceDate.Value = ""; if (tkrdpStartWorkUnitOutOfServiceDate.SelectedDate.HasValue) hdfUnitOutOfServiceDate.Value = tkrdpStartWorkUnitOutOfServiceDate.SelectedDate.Value.ToString();
                        hdfUnitOutOfServiceTime.Value = "8:00 AM";
                        hdfStartMileage.Value = tbxStartWorkStartMileage.Text.Trim();
                    }
                }
                
                // Complete work information       
                if (pnlCompleteWorkInformation.Visible)
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

                    if (hdfAssignToThirdPartyVendor.Value == "")
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

                // Notes
                // Notes Gridview, if the gridview is edition mode
                if (grdNotes.EditIndex >= 0)
                {
                    grdNotes.UpdateRow(grdNotes.EditIndex, true);
                }

                GrdNotesAdd();
            }

            return valid;
        }



        private void SaveTemp()
        {
            // Assigment Information
            if (pnlAssignmentInformation.Visible)
            {
                hdfDeadlineDate.Value = ""; if (tkrdpDeadlineDate.SelectedDate.HasValue) hdfDeadlineDate.Value = tkrdpDeadlineDate.SelectedDate.Value.ToString();

                // ... Myself
                hdfAssignToMyself.Value = rbtnAssignToMyself.Checked.ToString();
                if (rbtnAssignToMyself.Checked)
                {
                    int loginId = Convert.ToInt32(Session["loginID"]);
                    EmployeeGateway employeeGateway = new EmployeeGateway(new DataSet());
                    hdfTeamMemberId.Value = employeeGateway.GetEmployeIdByLoginId(loginId).ToString();
                }

                // ... Team Member
                hdfAssignToTeamMember.Value = rbtnAssignToTeamMember.Checked.ToString();
                if (rbtnAssignToTeamMember.Checked)
                {
                    hdfTeamMemberId.Value = ""; if (ddlAssignToTeamMember.SelectedValue != "") hdfTeamMemberId.Value = ddlAssignToTeamMember.SelectedValue;
                    hdfTeamMemberFullName.Value = ""; if (ddlAssignToTeamMember.SelectedItem.Text != "") hdfTeamMemberFullName.Value = ddlAssignToTeamMember.SelectedItem.Text;
                    hdfThirdPartyVendor.Value = "";
                }

                // ... Third party vendor
                hdfAssignToThirdPartyVendor.Value = rbtnAssignToThirdPartyVendor.Checked.ToString();
                if (rbtnAssignToThirdPartyVendor.Checked)
                {
                    hdfTeamMemberId.Value = "";
                    hdfTeamMemberFullName.Value = "";
                    hdfThirdPartyVendor.Value = ""; if (tbxAssignToThirdPartyVendor.Text != "") hdfThirdPartyVendor.Value = tbxAssignToThirdPartyVendor.Text.Trim();
                }
            }

            // Accept information
            if (pnlAcceptInformation.Visible)
            {
                hdfAcceptSR.Value = ckbxAcceptSR.Checked.ToString();
            }

            // Start work information
            if (pnlStartWorkInformation.Visible)
            {
                hdfStartSR.Value = ckbxStartSR.Checked.ToString();

                if (ckbxStartSR.Checked)
                {
                    hdfUnitOutOfServiceDate.Value = ""; if (tkrdpStartWorkUnitOutOfServiceDate.SelectedDate.HasValue) hdfUnitOutOfServiceDate.Value = tkrdpStartWorkUnitOutOfServiceDate.SelectedDate.Value.ToString();
                    hdfUnitOutOfServiceTime.Value = "8:00 AM";
                    hdfStartMileage.Value = tbxStartWorkStartMileage.Text.Trim();
                }
            }

            // Complete work information       
            if (pnlCompleteWorkInformation.Visible)
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

                if (hdfAssignToThirdPartyVendor.Value == "")
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

            //// Notes
            //// Notes Gridview, if the gridview is edition mode
            //if (grdNotes.EditIndex >= 0)
            //{
            //    grdNotes.UpdateRow(grdNotes.EditIndex, true);
            //}

            //GrdNotesAdd();
        }
                

        
        private bool StepStepsInformationPrevious()
        {
            return true;
        }
        


        private bool ValidatePage()
        {
            bool valid = true;

            if (pnlAssignmentInformation.Visible)
            {
                Page.Validate("assignmentInformation");
                if (!Page.IsValid) valid = false;
            }

            if (pnlStartWorkInformation.Visible)
            {
                Page.Validate("startWorkInformation");
                if (!Page.IsValid) valid = false; 
            }

            if (pnlCompleteWorkInformation.Visible)
            {
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
            }

            return valid;
        }
        


        public ServiceRequestsManagerToolTDS.CostInformationDataTable GetCostsNew()
        {
            costInformation = (ServiceRequestsManagerToolTDS.CostInformationDataTable)Session["serviceCostsDummyManagerTool"];
            if (costInformation == null)
            {
                costInformation = (ServiceRequestsManagerToolTDS.CostInformationDataTable)Session["costInformationManagerTool"];
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

                    ServiceRequestsManagerToolCostInformation model = new ServiceRequestsManagerToolCostInformation(serviceRequestsManagerToolTDS);

                    model.Insert(serviceId, newPartNumber, newPartName, newVendor, newCost, false, companyId);

                    Session.Remove("serviceCostsDummyManagerTool");
                    Session["serviceRequestsManagerToolTDS"] = serviceRequestsManagerToolTDS;
                    Session["costInformationManagerTool"] = serviceRequestsManagerToolTDS.CostInformation;

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
                ServiceRequestsManagerToolTDS.CostInformationDataTable dt = new ServiceRequestsManagerToolTDS.CostInformationDataTable();
                dt.AddCostInformationRow(-1, -1, "", "", "", -1, false, companyId);
                Session["serviceCostsDummyManagerTool"] = dt;

                grdCosts.DataBind();
            }

            // Normally executes at all postbacks
            if (grdCosts.Rows.Count == 1)
            {
                ServiceRequestsManagerToolTDS.CostInformationDataTable dt = (ServiceRequestsManagerToolTDS.CostInformationDataTable)Session["serviceCostsDummyManagerTool"];
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
            int serviceId = Int32.Parse(hdfSelectedSRId.Value);

            url = "./services_summary.aspx?source_page=services_manager_tool.aspx&dashboard=no&service_id=" + serviceId + "&active_tab=0" + GetNavigatorState();
            lkbtnOpenService.Attributes.Add("onclick", string.Format("return lkbtnOpenServiceClick('{0}');", url));

            url = "./services_edit.aspx?source_page=services_manager_tool.aspx&dashboardFromAddService=False&dashboard=no&service_id=" + serviceId + "&active_tab=0" + GetNavigatorState();
            lkbtnEditService.Attributes.Add("onclick", string.Format("return lkbtnEditServiceClick('{0}');", url));

            lkbtnClose.Attributes.Add("onclick", "return lkbtnCloseClick();");

            // validate if coming from Dashboard
            if ((string)Request.QueryString["dashboard"] == "True")
            {
                url = "./../../FleetManagement/Dashboard/dashboard_login.aspx?source_page=out";
                lkbtnClose.Attributes.Add("onclick", string.Format("return lkbtnReturnDashboardClick('{0}');", url));
            }
            else
            {
                lkbtnClose.Attributes.Add("onclick", "return lkbtnCloseClick();");
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
            title.Text = "Service Requests Management Tool";
        }



        protected void btnAssociate_Click(object sender, EventArgs e)
        {
            SaveTemp();
            PostPageChanges();

            Session["dialogOpenedServicesManagerTool"] = "1";
            Session["selecctedServiceID"] = hdfSelectedSRId.Value;
        }



        protected void btnUnassociate_Click(object sender, EventArgs e)
        {
            SaveTemp();
            PostPageChanges();
            
            ServiceRequestsManagerToolBasicInformation serviceRequestsManagerToolBasicInformation = new ServiceRequestsManagerToolBasicInformation(serviceRequestsManagerToolTDS);
            serviceRequestsManagerToolBasicInformation.UpdateLibraryCategoriesId(int.Parse(hdfSelectedSRId.Value), null);

            ViewState["update"] = "no";

            btnUnassociate.Visible = false;
            btnAssociate.Visible = true;
            tbxCategoryAssocited.Text = "";
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        private void RegisterClientScripts()
        {
            // Register content variables
            string contentVariables = "";
            contentVariables += "var tbxStartWorkStartMileageId = '" + tbxStartWorkStartMileage.ClientID + "';";
            contentVariables += "var tbxCompleteWorkCompleteMileageId = '" + tbxCompleteWorkCompleteMileage.ClientID + "';";
            contentVariables += "var hdfSelectedSRIdId = '" + hdfSelectedSRId.ClientID + "';";

            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./services_manager_tool.js");
        }



        private void TagPage()
        {
            hdfCompanyId.Value = Convert.ToInt32(Session["companyID"]).ToString();
            hdfDashboard.Value = (string)Request.QueryString["dashboard"];

            // Initialize assigment data
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
            LibraryFilesGateway libraryFilesGateway = new LibraryFilesGateway(libraryTDSForServices);
            libraryFilesGateway.Update();

            DB.Open();
            DB.BeginTransaction();
            try
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                int serviceId = Int32.Parse(hdfSelectedSRId.Value);

                ServiceRequestsManagerToolBasicInformation serviceRequestsManagerToolBasicInformation = new ServiceRequestsManagerToolBasicInformation(serviceRequestsManagerToolTDS);
                serviceRequestsManagerToolBasicInformation.Save(companyId);

                // Save costs information
                ServiceRequestsManagerToolCostInformation serviceRequestsManagerToolCostInformation = new ServiceRequestsManagerToolCostInformation(serviceRequestsManagerToolTDS);
                serviceRequestsManagerToolCostInformation.Save((int)serviceId, companyId);

                // Save notes information
                ServiceInformationServiceNoteGateway serviceInformationServiceNoteGateway = new ServiceInformationServiceNoteGateway(serviceInformationTDS);
                ServiceInformationServiceNote serviceInformationServiceNote = new ServiceInformationServiceNote(serviceInformationTDS);

                foreach (ServiceInformationTDS.NoteInformationRow rowNotes in (ServiceInformationTDS.NoteInformationDataTable)serviceInformationServiceNoteGateway.Table)
                {
                    if (!rowNotes.IsLIBRARY_FILES_IDNull())
                    {
                        if (rowNotes.LIBRARY_FILES_ID == 0 && rowNotes.FILENAME != "")
                        {
                            libraryFilesGateway.LoadByFileName(rowNotes.FILENAME, companyId);
                            int newLibraryFilesId = libraryFilesGateway.GetlibraryFilesId(rowNotes.FILENAME);

                            rowNotes.LIBRARY_FILES_ID = newLibraryFilesId;
                        }
                    }
                }

                // Save notes information                
                serviceInformationServiceNote.Save(companyId);

                DB.CommitTransaction();

                // Store datasets
                serviceRequestsManagerToolTDS.AcceptChanges();
                Session["serviceRequestsManagerToolTDS"] = serviceRequestsManagerToolTDS;

                // Store datasets
                libraryTDSForServices.AcceptChanges();
                serviceInformationTDS.AcceptChanges();

                Session["serviceInformationTDSForManagerTool"] = serviceInformationTDS;
                Session["libraryTDSForServices"] = libraryTDSForServices;

                Session.Remove("libraryTDSForServices");
                Session.Remove("serviceInformationTDSForManagerTool");
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
            ServiceRequestsManagerToolBasicInformationGateway serviceRequestsManagerToolBasicInformationGateway = new ServiceRequestsManagerToolBasicInformationGateway(serviceRequestsManagerToolTDS);
            
            // basic variables
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int serviceId = Int32.Parse(hdfSelectedSRId.Value);

            int? libraryCategoriesId = null; if (serviceRequestsManagerToolBasicInformationGateway.GetLibraryCategoriesId(serviceId).HasValue) libraryCategoriesId = (int)serviceRequestsManagerToolBasicInformationGateway.GetLibraryCategoriesId(serviceId);

            // Service state
            string serviceState = "Assigned";
            string checklistState = "In Progress";
            if (ckbxAcceptSR.Checked) serviceState = "Accepted";
            if (ckbxStartSR.Checked) serviceState = "In Progress";
            if (ckbxCompleteSR.Checked)
            {
                serviceState = "Completed";
                checklistState = "Healthy";
            }

            // Get Assignment information
            DateTime? assignDeadlineDate = null;
            bool assignTeamMember = false;
            int? assignTeamMemberId = null;
            string assignThirdPartyVendor = "";
            DateTime? assignDateTime = null;

            if (hdfPnlAssignmentInformation.Value == "True")
            {
                // If data is modified
                if (hdfDeadlineDate.Value != "") assignDeadlineDate = DateTime.Parse(hdfDeadlineDate.Value);

                if ((hdfAssignToMyself.Value == "True") || (hdfAssignToTeamMember.Value == "True"))
                {
                    assignTeamMember = true;
                    assignTeamMemberId = Int32.Parse(hdfTeamMemberId.Value);
                }
                                
                if (hdfThirdPartyVendor.Value != "")
                {
                    assignThirdPartyVendor = hdfThirdPartyVendor.Value;
                }

                assignDateTime = DateTime.Now;
            }
            else
            {
                // If data is not modified
                assignTeamMember = serviceRequestsManagerToolBasicInformationGateway.GetAssignTeamMember(serviceId);
                assignTeamMemberId = serviceRequestsManagerToolBasicInformationGateway.GetAssignTeamMemberId(serviceId);
                assignThirdPartyVendor = serviceRequestsManagerToolBasicInformationGateway.GetAssignedThirdPartyVendor(serviceId);
                assignDeadlineDate = serviceRequestsManagerToolBasicInformationGateway.GetAssignedDeadlineDate(serviceId);
                assignDateTime = serviceRequestsManagerToolBasicInformationGateway.GetAssignmentDateTime(serviceId);
            }

            // Get acceptance information
            DateTime? acceptDateTime = null;
            DateTime? rejectDateTime = null;
            string rejectReason = "";

            if (hdfPnlAcceptInformation.Value == "True")
            {
                // If data is modified
                if (hdfAcceptSR.Value == "True")
                {
                    acceptDateTime = DateTime.Now;
                }
            }
            else
            {
                // If data is not modified
                acceptDateTime = serviceRequestsManagerToolBasicInformationGateway.GetAcceptedDateTime(serviceId);
                rejectDateTime = serviceRequestsManagerToolBasicInformationGateway.GetRejectDateTime(serviceId);
                rejectReason = serviceRequestsManagerToolBasicInformationGateway.GetRejectReason(serviceId);
            }

            // Get start work information
            DateTime? startWorkDateTime = null;
            DateTime? unitOutOfServiceDate = null;
            string unitOutOfServiceTime = "";            
            string startWorkMileage = "";

            if (hdfPnlStartWorkInformation.Value == "True")
            {
                // If data is modified
                if (hdfStartSR.Value == "True")
                {
                    startWorkDateTime = DateTime.Now;
                    if (hdfUnitOutOfServiceDate.Value != "") unitOutOfServiceDate = DateTime.Parse(hdfUnitOutOfServiceDate.Value);
                    unitOutOfServiceTime = hdfUnitOutOfServiceTime.Value;
                    if (hdfStartMileage.Value != "") startWorkMileage = hdfStartMileage.Value;
                }
            }
            else
            {
                // If data is not modified
                startWorkDateTime = serviceRequestsManagerToolBasicInformationGateway.GetStartWorkDateTime(serviceId);
                unitOutOfServiceDate = serviceRequestsManagerToolBasicInformationGateway.GetUnitOutOfServiceDate(serviceId);
                unitOutOfServiceTime = serviceRequestsManagerToolBasicInformationGateway.GetUnitOutOfServiceTime(serviceId);
                startWorkMileage = serviceRequestsManagerToolBasicInformationGateway.GetStartWorkMileage(serviceId);
            }
            
            // Get complete work information
            DateTime? completeWorkDateTime = null;
            DateTime? unitBackInServiceDate = null;
            string unitBackInServiceTime = "";
            string completeWorkDetailDescription = "";
            bool completeWorkDetailPreventable = false;
            Decimal? completeWorkDetailTMLabourHours = null;
            Decimal? completeWorkDetailTMCost = null;
            string completeWorkInvoiceNumber = "";
            Decimal? completeWorkInvoiceAmount = null;
            string completeWorkMileage = "";

            if (hdfPnlCompleteWorkInformation.Value == "True")
            {
                // If data is modified
                if (ckbxCompleteSR.Checked)
                {
                    completeWorkDateTime = DateTime.Now;
                    if (hdfUnitBackInServiceDate.Value != "") unitBackInServiceDate = DateTime.Parse(hdfUnitBackInServiceDate.Value);
                    unitBackInServiceTime = hdfUnitBackInServiceTime.Value;
                    completeWorkDetailDescription = hdfCompleteWorkDescription.Value;
                    completeWorkDetailPreventable = Boolean.Parse(hdfCompleteWorkPreventable.Value);
                    if (hdfCompleteWorkLabourHours.Value != "") completeWorkDetailTMLabourHours = decimal.Parse(hdfCompleteWorkLabourHours.Value);
                    if (hdfCompleteWorkCosts.Value != "") completeWorkDetailTMCost = decimal.Parse(hdfCompleteWorkCosts.Value);
                    if (hdfInvoiceNumber.Value != "") completeWorkInvoiceNumber = hdfInvoiceNumber.Value;
                    if (hdfInvoiceAmount.Value != "") completeWorkInvoiceAmount = decimal.Parse(hdfInvoiceAmount.Value);
                    if (hdfCompleteWorkMileage.Value != "") completeWorkMileage = hdfCompleteWorkMileage.Value;
                }
            }
            else
            {
                // If data is not modified
                completeWorkDateTime = serviceRequestsManagerToolBasicInformationGateway.GetCompleteWorkDateTime(serviceId);
                unitBackInServiceDate = serviceRequestsManagerToolBasicInformationGateway.GetUnitBackInServiceDate(serviceId);
                unitBackInServiceTime = serviceRequestsManagerToolBasicInformationGateway.GetUnitBackInServiceTime(serviceId);
                completeWorkDetailDescription = serviceRequestsManagerToolBasicInformationGateway.GetCompleteWorkDetailDescription(serviceId);
                completeWorkDetailPreventable = serviceRequestsManagerToolBasicInformationGateway.GetCompleteWorkDetailPreventable(serviceId);
                completeWorkDetailTMLabourHours = serviceRequestsManagerToolBasicInformationGateway.GetCompleteWorkDetailTMLabourHours(serviceId);
                completeWorkDetailTMCost = serviceRequestsManagerToolBasicInformationGateway.GetCompleteWorkDetailTMCost(serviceId);
                completeWorkInvoiceNumber = serviceRequestsManagerToolBasicInformationGateway.GetCompleteWorkDetailTPVInvoiceNumber(serviceId);
                completeWorkInvoiceAmount = serviceRequestsManagerToolBasicInformationGateway.GetCompleteWorkDetailTPVInvoiceAmout(serviceId);
                completeWorkMileage = serviceRequestsManagerToolBasicInformationGateway.GetCompleteWorkMileage(serviceId);
            }
            
            // Insert to dataset
            ServiceRequestsManagerToolBasicInformation serviceRequestsManagerToolBasicInformation = new ServiceRequestsManagerToolBasicInformation(serviceRequestsManagerToolTDS);
            serviceRequestsManagerToolBasicInformation.Update(serviceId, serviceState, assignDateTime, assignDeadlineDate, assignTeamMember, assignTeamMemberId, assignThirdPartyVendor, acceptDateTime, startWorkDateTime, unitOutOfServiceDate, unitOutOfServiceTime, completeWorkDateTime, unitBackInServiceDate, unitBackInServiceTime, completeWorkDetailDescription, completeWorkDetailPreventable, completeWorkDetailTMLabourHours, completeWorkDetailTMCost, completeWorkInvoiceNumber, completeWorkInvoiceAmount, startWorkMileage, completeWorkMileage, checklistState, false, companyId, libraryCategoriesId);

            // Store session
            Session["serviceRequestsManagerToolTDS"] = serviceRequestsManagerToolTDS;
        }



        private string GetSummary()
        {
            string summary = "";

            // ... Assignation information
            if (hdfPnlAssignmentInformation.Value == "True")
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

            if (hdfPnlStartWorkInformation.Value == "True")
            {
                if (ckbxStartSR.Checked)
                {
                    summary = summary + "\nSTART WORK INFORMATION \n";
                    DateTime unitOutOfServiceDate = DateTime.Parse(hdfUnitOutOfServiceDate.Value);
                    string unitOutOfServiceDateText = unitOutOfServiceDate.Month.ToString() + "/" + unitOutOfServiceDate.Day.ToString() + "/" + unitOutOfServiceDate.Year.ToString();
                    summary = summary + "Unit Out Of Service Date: " + unitOutOfServiceDateText + "\n";

                    summary = summary + "Unit Out Of Service Time: " + hdfUnitOutOfServiceTime.Value + "\n";


                    if (hdfUnitType.Value == "Vehicle")
                    {
                        summary = summary + "Start Work Mileage: " + hdfStartMileage.Value + " " + hdfMileageUnitOfMeasurement.Value;                        
                        summary = summary + "\n";
                    }
                }
            }

            if (hdfPnlCompleteWorkInformation.Value == "True")
            {
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
                        summary = summary + "Invoice Number: " + hdfInvoiceNumber.Value + "\n";

                        summary = summary + "Invoice Amount: " + hdfInvoiceAmount.Value + "\n";
                    }
                }
            }

            // Service state
            string serviceState = "Assigned";
            if (ckbxAcceptSR.Checked) serviceState = "Accepted";
            if (ckbxStartSR.Checked) serviceState = "In Progress";
            if (ckbxCompleteSR.Checked) serviceState = "Completed";
            hdfServiceState.Value = serviceState;
            summary = summary + "\nSERVICE STATE: " + serviceState + "\n";

            return summary;
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

                body = body + "\n Service Number: " + hdfServiceNumber.Value;
                body = body + "\n Service Description: " + hdfServiceDescription.Value;

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
            string subject = "Service request has been modified.";
            string body = "";

            // MailtTo, nameTo
            int companyLevelId = Int32.Parse(hdfCompanyLevel.Value);

            Employee employees = new Employee();
            employees.LoadByFleetManager(companyLevelId);

            mailTo = employees.GetAllFleetManagersEMails();
            nameTo = employees.GetAllFleetManagersNames();

            // Mails body
            body = body + "\nHi " + nameTo + ",\n\nThe following service request has been modified. \n";

            body = body + "\n Service Number: " + hdfServiceNumber.Value;
            body = body + "\n Service Description: " + hdfServiceDescription.Value;

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
                LiquiForce.LFSLive.WebUI.Common.Tools.Mail.SendMail("sussel@nerdsonsite.com", "sussel@nerdsonsite.com, humberto@nerdsonsite.com, jacqueline.claure@nerdsonsite.com", subject, entireBody, false, out error);
            }
        } 


        //////////////////////////////////////////////////
        protected void AddNotesNewEmptyFix(GridView grdView)
        {
            if (grdNotes.Rows.Count == 0)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                ServiceInformationTDS.NoteInformationDataTable dt = new ServiceInformationTDS.NoteInformationDataTable();
                dt.AddNoteInformationRow(-1, -1, "", -1, DateTime.Now, "", 0, "", "", false, companyId, false);
                Session["serviceNotesDummyManagerTool"] = dt;

                grdNotes.DataBind();
            }

            // Normally executes at all postbacks
            if (grdNotes.Rows.Count == 1)
            {
                ServiceInformationTDS.NoteInformationDataTable dt = (ServiceInformationTDS.NoteInformationDataTable)Session["serviceNotesDummyManagerTool"];
                if (dt != null)
                {
                    grdNotes.Rows[0].Visible = false;
                    grdNotes.Rows[0].Controls.Clear();
                }
            }
        }



        private void GrdNotesAdd()
        {
            if (ValidateNotesFooter())
            {
                Page.Validate("notesDataAdd");
                if (Page.IsValid)
                {
                    int serviceId = Int32.Parse(hdfSelectedSRId.Value);
                    int companyId = Int32.Parse(hdfCompanyId.Value);
                    string newSubject = ((TextBox)grdNotes.FooterRow.FindControl("tbxNoteSubjectNew")).Text.Trim();
                    int loginId = Convert.ToInt32(Session["loginID"]);
                    DateTime dateTime_ = DateTime.Now;
                    string newNote = ((TextBox)grdNotes.FooterRow.FindControl("tbxNoteNoteNew")).Text.Trim();
                    bool inServiceNoteDatabase = false;
                    int? libraryFilesId = null;
                    string fileName = ((Label)grdNotes.FooterRow.FindControl("lblFileNameNoteAttachmentNew")).Text.Trim();
                    if (fileName != "")
                    {
                        LibraryFilesGateway libraryFilesGateway = new LibraryFilesGateway();
                        libraryFilesId = libraryFilesGateway.GetlibraryFilesId(fileName);
                    }

                    ServiceInformationServiceNote model = new ServiceInformationServiceNote(serviceInformationTDS);
                    model.Insert(serviceId, newSubject, loginId, dateTime_, newNote, libraryFilesId, false, companyId, inServiceNoteDatabase);

                    Session.Remove("serviceNotesDummyManagerTool");
                    Session["serviceInformationTDSForManagerTool"] = serviceInformationTDS;

                    grdNotes.DataBind();
                    grdNotes.PageIndex = grdNotes.PageCount - 1;
                }
            }
        }



        private void GrdNotesAddFromCost(string subject, string note)
        {
            int serviceId = Int32.Parse(hdfSelectedSRId.Value);
            int companyId = Int32.Parse(hdfCompanyId.Value);
            string newSubject = subject;
            int loginId = Convert.ToInt32(Session["loginID"]);
            DateTime dateTime_ = DateTime.Now;
            string newNote = note;
            bool inServiceNoteDatabase = false;
            int? libraryFilesId = null;

            ServiceInformationServiceNote model = new ServiceInformationServiceNote(serviceInformationTDS);
            model.Insert(serviceId, newSubject, loginId, dateTime_, newNote, libraryFilesId, false, companyId, inServiceNoteDatabase);

            Session.Remove("serviceNotesDummyManagerTool");
            Session["serviceInformationTDSForManagerTool"] = serviceInformationTDS;

            grdNotes.DataBind();
            grdNotes.PageIndex = grdNotes.PageCount - 1;
        }



        private void GrdNotesDeleteAttachment(int libraryFileId, int refId)
        {
            // Button delete functionality
            if (libraryFileId != 0)
            {
                ServiceInformationServiceNote model = new ServiceInformationServiceNote(serviceInformationTDS);
                model.UpdateLibraryFilesId(int.Parse(hdfSelectedSRId.Value), refId, null, "", "");

                LibraryFilesGateway libraryFilesGateway = new LibraryFilesGateway(libraryTDSForServices);
                libraryFilesGateway.DeleteByLibraryFilesId(libraryFileId);

                ViewState["update"] = "no";

                Session["serviceInformationTDSForManagerTool"] = serviceInformationTDS;
                Session["libraryTDSForServices"] = libraryTDSForServices;
                grdNotes.DataBind();
            }
        }



        private void GrdNotesOpenAttachment(string originalFileName, string fileName)
        {
            // Button download functionality
            if ((originalFileName != "") && (fileName != ""))
            {
                // Escape single quote
                originalFileName = originalFileName.Replace("'", "%27");
                fileName = fileName.Replace("'", "%27");

                string script = "<script language='javascript'>";
                string url = "./services_download_attachment.aspx?original_filename=" + Server.UrlEncode(originalFileName) + "&filename=" + Server.UrlEncode(fileName);
                script = script + string.Format("window.open('{0}', '_blank', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=0, height=0')", url);
                script = script + "</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "DownloadAttachment", script, false);
            }
        }



        private void GrdNotesAddAttachment(int? refId, string subject)
        {
            SaveTemp();
            PostPageChanges();

            // Escape single quote
            subject = subject.Replace("'", "%27");

            if (refId.HasValue)
            {
                if (ViewState["libraryCategoriesId"] != null)
                {
                    string script = "<script language='javascript'>";
                    string url = "./services_add_attachment.aspx?source_page=services_manager_tool.aspx&subject=" + Server.UrlEncode(subject) + "&refId=" + refId.ToString() + "&service_id=" + hdfSelectedSRId.Value + "&library_categories_id=" + Int32.Parse(ViewState["libraryCategoriesId"].ToString());
                    script = script + string.Format("window.open('{0}', '_blank', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=510, height=270')", url);
                    script = script + "</script>";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Notes", script, false);
                }
            }
            else
            {
                GrdNotesAdd();

                ServiceInformationServiceNote model = new ServiceInformationServiceNote(serviceInformationTDS);
                refId = model.GetLastRefId();

                if (ViewState["libraryCategoriesId"] != null)
                {
                    string script = "<script language='javascript'>";
                    string url = "./services_add_attachment.aspx?source_page=services_manager_tool.aspx&subject=" + Server.UrlEncode(subject) + "&refId=" + refId.ToString() + "&service_id=" + hdfSelectedSRId.Value + "&library_categories_id=" + Int32.Parse(ViewState["libraryCategoriesId"].ToString());
                    script = script + string.Format("window.open('{0}', '_blank', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=510, height=270')", url);
                    script = script + "</script>";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Notes", script, false);
                }
            }
        }



        private void GrdCostsAddAttachment(int? refIdCost, string subject)
        {            
            GrdNotesAddFromCost(subject, subject);

            ServiceInformationServiceNote model = new ServiceInformationServiceNote(serviceInformationTDS);
            ServiceInformationServiceCost modelCost = new ServiceInformationServiceCost(serviceInformationTDS);

            int refId = model.GetLastRefId();

            if (!refIdCost.HasValue)
            {
                refIdCost = modelCost.GetLastRefId();
            }

            modelCost.UpdateNoteId(Int32.Parse(hdfSelectedSRId.Value), refIdCost.Value, refId);

            if (ViewState["libraryCategoriesId"] != null)
            {
                // Escape single quote
                subject = subject.Replace("'", "%27");

                string script = "<script language='javascript'>";
                string url = "./services_add_attachment.aspx?source_page=services_edit.aspx&subject=" + Server.UrlEncode(subject) + "&refId=" + refId.ToString() + "&refIdCost=" + refIdCost.Value.ToString() + "&service_id=" + hdfSelectedSRId.Value + "&library_categories_id=" + Int32.Parse(ViewState["libraryCategoriesId"].ToString());
                script = script + string.Format("window.open('{0}', '_blank', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=510, height=270')", url);
                script = script + "</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Notes", script, false);
            }
        }



        private bool ValidateNotesFooter()
        {
            string subject = ((TextBox)grdNotes.FooterRow.FindControl("tbxNoteSubjectNew")).Text.Trim();
            string note = ((TextBox)grdNotes.FooterRow.FindControl("tbxNoteNoteNew")).Text.Trim();

            if ((subject != "") || (note != ""))
            {
                return true;
            }

            return false;
        }



        protected string GetNoteCreatedBy(object userId)
        {
            if (userId != DBNull.Value)
            {
                if (Convert.ToInt32(userId) != -1)
                {
                    try
                    {
                        // Created By
                        int companyId = Int32.Parse(hdfCompanyId.Value);

                        LoginGateway loginGateway = new LoginGateway();
                        loginGateway.LoadByLoginId(Convert.ToInt32(userId), companyId);
                        string userName = loginGateway.GetLastName(Convert.ToInt32(userId), companyId) + " " + loginGateway.GetFirstName(Convert.ToInt32(userId), companyId);

                        return userName.ToString();
                    }
                    catch
                    {
                        return "";
                    }
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }



        protected void grdNotes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Notes Gridview, if the gridview is edition mode
            if (grdNotes.EditIndex >= 0)
            {
                grdNotes.UpdateRow(grdNotes.EditIndex, true);
            }

            // Delete notes
            int serviceId = (int)e.Keys["ServiceID"];
            int refId = (int)e.Keys["RefID"];

            ServiceInformationServiceNote model = new ServiceInformationServiceNote(serviceInformationTDS);

            model.Delete(serviceId, refId);

            int? libraryFilesId = null;
            if (((Label)grdNotes.Rows[e.RowIndex].Cells[3].FindControl("lblLibraryFileId")).Text.Trim() != "")
            {
                libraryFilesId = Int32.Parse(((Label)grdNotes.Rows[e.RowIndex].Cells[3].FindControl("lblLibraryFileId")).Text.Trim());
                LibraryFilesGateway libraryFilesGateway = new LibraryFilesGateway();
                libraryFilesGateway.DeleteByLibraryFilesId((int)libraryFilesId);
            }

            // Store dataset
            Session["serviceInformationTDSForManagerTool"] = serviceInformationTDS;
        }



        protected void grdNotes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Add":
                    // Notes Gridview, if the gridview is edition mode
                    if (grdNotes.EditIndex >= 0)
                    {
                        grdNotes.UpdateRow(grdNotes.EditIndex, true);
                    }

                    // Add New Note
                    GrdNotesAdd();
                    break;

                case "AddAttachmentEdit":
                    Session["dialogOpenedServicesManagerTool"] = "1";
                    Session["selecctedServiceID"] = hdfSelectedSRId.Value;
                    GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                    int refId = Int32.Parse(((Label)row.FindControl("lblRefIDEdit")).Text);
                    string subject = ((TextBox)row.FindControl("tbxNoteSubjectEdit")).Text.Trim();
                    GrdNotesAddAttachment(refId, subject);
                    break;

                case "AddAttachmentAdd":
                    Session["dialogOpenedServicesManagerTool"] = "1";
                    Session["selecctedServiceID"] = hdfSelectedSRId.Value;
                    string newSubject = ((TextBox)grdNotes.FooterRow.FindControl("tbxNoteSubjectNew")).Text.Trim();
                    GrdNotesAddAttachment(null, newSubject);
                    break;

                case "DownloadAttachment":
                    GridViewRow rowDonwload = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                    string originalFileName = ((TextBox)rowDonwload.FindControl("tbxNoteAttachment")).Text;
                    string fileName = ((Label)rowDonwload.FindControl("lblFileName")).Text;
                    GrdNotesOpenAttachment(originalFileName, fileName);
                    break;

                case "DeleteAttachmentEdit":
                    GridViewRow rowDelete = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                    int refIdEdit = Int32.Parse(((Label)rowDelete.FindControl("lblRefIDEdit")).Text);
                    int libraryFilesIdEdit = Int32.Parse(((Label)rowDelete.FindControl("lblLibraryFileIdEdit")).Text);
                    GrdNotesDeleteAttachment(libraryFilesIdEdit, refIdEdit);
                    break;
            }
        }



        protected void grdNotes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.Validate("notesDataEdit");
            if (Page.IsValid)
            {
                int serviceId = (int)e.Keys["ServiceID"];
                int refId = (int)e.Keys["RefID"];

                string subject = ((TextBox)grdNotes.Rows[e.RowIndex].Cells[2].FindControl("tbxNoteSubjectEdit")).Text.Trim();
                string note = ((TextBox)grdNotes.Rows[e.RowIndex].Cells[3].FindControl("tbxNoteNoteEdit")).Text.Trim();
                int? libraryFilesId = null;
                if (((Label)grdNotes.Rows[e.RowIndex].Cells[3].FindControl("lblLibraryFileIdEdit")).Text.Trim() != "")
                {
                    libraryFilesId = Int32.Parse(((Label)grdNotes.Rows[e.RowIndex].Cells[3].FindControl("lblLibraryFileIdEdit")).Text.Trim());
                }

                // Update data
                ServiceInformationServiceNote model = new ServiceInformationServiceNote(serviceInformationTDS);
                model.Update(serviceId, refId, subject, note, libraryFilesId);

                // Store dataset
                Session["serviceInformationTDSForManagerTool"] = serviceInformationTDS;
            }
            else
            {
                e.Cancel = true;
            }
        }



        protected void grdNotes_DataBound(object sender, EventArgs e)
        {
            AddNotesNewEmptyFix(grdNotes);
        }



        protected void grdNotes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Edit items
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Edit) || (e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
            {
                string originalFileNameEdit = ((TextBox)e.Row.FindControl("tbxNoteAttachmentEdit")).Text;
                string fileName = ((Label)e.Row.FindControl("lblFileNameEdit")).Text;
                int libraryFileId = 0; if (((Label)e.Row.FindControl("lblLibraryFileIdEdit")).Text != "") libraryFileId = Int32.Parse(((Label)e.Row.FindControl("lblLibraryFileIdEdit")).Text);

                // Button visibility
                if (originalFileNameEdit == "")
                {
                    ((Button)e.Row.FindControl("btnNoteDeleteEdit")).Visible = false;

                    ServiceRequestsManagerToolBasicInformationGateway serviceRequestsManagerToolBasicInformationGateway = new ServiceRequestsManagerToolBasicInformationGateway(serviceRequestsManagerToolTDS);
                    int? libraryCategoriesId = null; if (serviceRequestsManagerToolBasicInformationGateway.GetLibraryCategoriesId(int.Parse(hdfSelectedSRId.Value)).HasValue) libraryCategoriesId = (int)serviceRequestsManagerToolBasicInformationGateway.GetLibraryCategoriesId(int.Parse(hdfSelectedSRId.Value));

                    if (libraryCategoriesId.HasValue)
                    {
                        ((Button)e.Row.FindControl("btnNoteAddEdit")).Visible = true;
                    }
                    else
                    {
                        ((Button)e.Row.FindControl("btnNoteAddEdit")).Visible = false;
                    }
                }
                else
                {
                    ((Button)e.Row.FindControl("btnNoteDeleteEdit")).Visible = true;
                    ((Button)e.Row.FindControl("btnNoteAddEdit")).Visible = false;
                }
            }

            // Normal items
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Normal) || (e.Row.RowState == (DataControlRowState.Normal | DataControlRowState.Alternate))))
            {
                string originalFileName = ((TextBox)e.Row.FindControl("tbxNoteAttachment")).Text;
                string fileName = ((Label)e.Row.FindControl("lblFileName")).Text;
                int libraryFileId = 0; if (((Label)e.Row.FindControl("lblLibraryFileId")).Text != "") libraryFileId = Int32.Parse(((Label)e.Row.FindControl("lblLibraryFileId")).Text);

                // Button visibility
                if (originalFileName == "")
                {
                    ((Button)e.Row.FindControl("btnNoteDownload")).Visible = false;
                }
                else
                {
                    ((Button)e.Row.FindControl("btnNoteDownload")).Visible = true;
                }
            }

            // Footer item
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                ServiceRequestsManagerToolBasicInformationGateway serviceRequestsManagerToolBasicInformationGateway = new ServiceRequestsManagerToolBasicInformationGateway(serviceRequestsManagerToolTDS);
                int? libraryCategoriesId = null; if (serviceRequestsManagerToolBasicInformationGateway.GetLibraryCategoriesId(int.Parse(hdfSelectedSRId.Value)).HasValue) libraryCategoriesId = (int)serviceRequestsManagerToolBasicInformationGateway.GetLibraryCategoriesId(int.Parse(hdfSelectedSRId.Value));

                if (libraryCategoriesId.HasValue)
                {
                    ((Button)e.Row.FindControl("btnAddFooter")).Visible = true;
                }
                else
                {
                    ((Button)e.Row.FindControl("btnAddFooter")).Visible = false;
                }
            }
        }



        protected void grdNotes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Notes Gridview, if the gridview is edition mode
            if (grdNotes.EditIndex >= 0)
            {
                grdNotes.UpdateRow(grdNotes.EditIndex, true);
            }
        }



        public ServiceInformationTDS.NoteInformationDataTable GetNotesNew()
        {
            serviceInformationServiceNote = (ServiceInformationTDS.NoteInformationDataTable)Session["serviceNotesDummyManagerTool"];
            if (serviceInformationServiceNote == null)
            {
                serviceInformationServiceNote = ((ServiceInformationTDS)Session["serviceInformationTDSForManagerTool"]).NoteInformation;
            }

            return serviceInformationServiceNote;
        }



        public void DummyNotesNew(int ServiceID, int RefID)
        {
        }

        
        
    }
}