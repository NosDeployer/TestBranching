using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.FleetManagement.Services;
using LiquiForce.LFSLive.BL.FleetManagement.Services;
using LiquiForce.LFSLive.DA.FleetManagement.Units;
using LiquiForce.LFSLive.DA.Resources.Employees;
using LiquiForce.LFSLive.DA.RAF;
using LiquiForce.LFSLive.DA.FleetManagement.ChecklistRules;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.FleetManagement.Services
{
    /// <summary>
    /// services_edit
    /// </summar
    public partial class services_edit : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected ServiceInformationTDS serviceInformationTDS;
        protected ServiceInformationTDS.CostInformationDataTable serviceInformationServiceCost;
        protected ServiceInformationTDS.NoteInformationDataTable serviceInformationServiceNote;
        protected LibraryTDS libraryTDSForServices;






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
                if (!(Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_SERVICES_VIEW"]) && Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_SERVICES_EDIT"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["service_id"] == null) || ((string)Request.QueryString["active_tab"] == null) || ((string)Request.QueryString["dashboard"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in services_edit.aspx");
                }

                // Tag Page
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfFmType.Value = "Services";
                hdfServiceId.Value = Request.QueryString["service_id"].ToString();
                hdfActiveTab.Value = Request.QueryString["active_tab"].ToString();
                hdfLoginId.Value = Convert.ToInt32(Session["loginID"]).ToString();
                hdfDashboard.Value = Request.QueryString["dashboard"].ToString();

                // Prepare initial data
                Session.Remove("serviceCostsDummy");
                Session.Remove("serviceNotesDummy");

                // If coming from 
                int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
                int serviceId = Int32.Parse(hdfServiceId.Value.Trim());
                string fmType = hdfFmType.Value;

                // ... services_navigator2.aspx, services_add_request.aspx, services_manager_tool.aspx
                if ((Request.QueryString["source_page"] == "services_navigator2.aspx") || (Request.QueryString["source_page"] == "services_add_request.aspx") || (Request.QueryString["source_page"] == "services_manager_tool.aspx"))
                {
                    StoreNavigatorState();
                    ViewState["update"] = "no";

                    // ... Set initial tab
                    if ((string)Session["dialogOpenedServices"] != "1")
                    {
                        hdfActiveTab.Value = Request.QueryString["active_tab"];

                        serviceInformationTDS = new ServiceInformationTDS();

                        ServiceInformationBasicInformation serviceInformationBasicInformation = new ServiceInformationBasicInformation(serviceInformationTDS);
                        serviceInformationBasicInformation.LoadByServiceId(serviceId, companyId);

                        ServiceInformationServiceCost serviceInformationServiceCostForEdit = new ServiceInformationServiceCost(serviceInformationTDS);
                        serviceInformationServiceCostForEdit.LoadByServiceId(serviceId, companyId);

                        ServiceInformationServiceNote serviceInformationServiceNoteForEdit = new ServiceInformationServiceNote(serviceInformationTDS);
                        serviceInformationServiceNoteForEdit.LoadByServiceId(serviceId, companyId);
                    }
                    else
                    {
                        hdfActiveTab.Value = (string)Session["activeTabServices"];

                        // Restore datasets
                        serviceInformationTDS = (ServiceInformationTDS)Session["serviceInformationTDS"];
                    }

                    // ... Store dataset
                    Session["serviceInformationTDS"] = serviceInformationTDS;
                }

                // ... services_summary.aspx or services_edit
                if ((Request.QueryString["source_page"] == "services_summary.aspx") || (Request.QueryString["source_page"] == "services_edit.aspx"))
                {
                    StoreNavigatorState();
                    ViewState["update"] = Request.QueryString["update"];

                    // ... Restore dataset
                    serviceInformationTDS = (ServiceInformationTDS)Session["serviceInformationTDS"];

                    // ... Set initial tab
                    if ((string)Session["dialogOpenedServices"] != "1")
                    {
                        hdfActiveTab.Value = Request.QueryString["active_tab"];

                        if (ViewState["update"].ToString().Trim() == "yes")
                        {
                            ServiceInformationBasicInformation serviceInformationBasicInformation = new ServiceInformationBasicInformation(serviceInformationTDS);
                            serviceInformationBasicInformation.LoadByServiceId(serviceId, companyId);

                            ServiceInformationServiceCost serviceInformationServiceCostForEdit = new ServiceInformationServiceCost(serviceInformationTDS);
                            serviceInformationServiceCostForEdit.LoadByServiceId(serviceId, companyId);

                            ServiceInformationServiceNote serviceInformationServiceNoteForEdit = new ServiceInformationServiceNote(serviceInformationTDS);
                            serviceInformationServiceNoteForEdit.LoadByServiceId(serviceId, companyId);

                            // ... Store dataset
                            Session["serviceInformationTDS"] = serviceInformationTDS;
                        }
                    }
                    else
                    {
                        hdfActiveTab.Value = (string)Session["activeTabServices"];
                    }
                }             

                // Prepare initial data
                lblMissingData.Visible = false;

                // ... Set initial tab
                int activeTab = Int32.Parse(hdfActiveTab.Value);
                tcDetailedInformation.ActiveTabIndex = activeTab;

                // ... For total cost
                ServiceInformationServiceCost serviceInformationServiceCostForTotalCost = new ServiceInformationServiceCost(serviceInformationTDS);
                tbxTotalCost.Text = Decimal.Round(serviceInformationServiceCostForTotalCost.GetTotalCost(serviceId, companyId), 2).ToString();

                // ... Data for current servicew
                LoadServiceData(companyId);

                // Databind
                Page.DataBind();

                ServiceInformationBasicInformationGateway serviceInformationBasicInformationGateway = new ServiceInformationBasicInformationGateway(serviceInformationTDS);
                if (serviceInformationBasicInformationGateway.GetAssignTeamMemberId(serviceId).HasValue)
                {
                    try
                    {
                        ddlAssignmentDataAssignToTeamMember.SelectedValue = ((int)serviceInformationBasicInformationGateway.GetAssignTeamMemberId(serviceId)).ToString();
                    }
                    catch
                    {
                        ddlAssignmentDataAssignToTeamMember.SelectedIndex = 0;
                    }

                    int teamMemberId = (int)serviceInformationBasicInformationGateway.GetAssignTeamMemberId(serviceId);
                    EmployeeGateway employeeGateway = new EmployeeGateway();
                    employeeGateway.LoadByEmployeeId(teamMemberId);
                    tbxAssignmentDataAssignToTeamMemberReadOnly.Text = employeeGateway.GetLastName(teamMemberId) + " " + employeeGateway.GetFirstName(teamMemberId);
                }

                // For thirds party vendor autocomplete
                aceThirdPartyVendor.ContextKey = serviceId.ToString() + "," + hdfCompanyId.Value;

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
            else
            {
                // Restore datasets
                serviceInformationTDS = (ServiceInformationTDS)Session["serviceInformationTDS"];

                // Set initial tab
                int activeTab = Int32.Parse(hdfActiveTab.Value);
                tcDetailedInformation.ActiveTabIndex = activeTab;

                if (Session["libraryTDSForServices"] != null)
                {
                    libraryTDSForServices = (LibraryTDS)Session["libraryTDSForServices"];
                }
                else
                {
                    libraryTDSForServices = new LibraryTDS();
                }

                LoadNotes();
            }
        }



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

            ServiceInformationServiceCost model = new ServiceInformationServiceCost(serviceInformationTDS);
            model.Delete(serviceId, refId);

            // Store dataset
            Session["serviceInformationTDS"] = serviceInformationTDS;

            // Calc TotalCost
            tbxTotalCost.Text = Decimal.Round(model.GetTotalCost(serviceId, companyId), 2).ToString();
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
            Session["serviceInformationTDS"] = serviceInformationTDS;
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

                case "AddAttachmentEdit":
                    Session["activeTabServices"] = "3";
                    Session["dialogOpenedServices"] = "1";
                    GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                    int refId = Int32.Parse(((Label)row.FindControl("lblRefId")).Text);
                    string subject = ((TextBox)row.FindControl("tbxPartName")).Text.Trim();
                    GrdCostsAddAttachment(refId, subject);
                    break;

                case "AddAttachmentAdd":
                    Session["activeTabServices"] = "3";
                    Session["dialogOpenedServices"] = "1";
                    string newSubject = ((TextBox)grdCosts.FooterRow.FindControl("tbxPartNameNew")).Text.Trim();
                    GrdCostsAddAttachment(null, newSubject);
                    break;

                case "DownloadAttachment":
                    GridViewRow rowDonwload = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                    string originalFileName = ((TextBox)rowDonwload.FindControl("tbxNoteAttachment")).Text;
                    string fileName = ((Label)rowDonwload.FindControl("lblFileName")).Text;
                    GrdNotesOpenAttachment(originalFileName, fileName);
                    break;

                case "DeleteAttachmentEdit":
                    GridViewRow rowDelete = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                    int refIdEdit = Int32.Parse(((Label)rowDelete.FindControl("lblNoteIDEdit")).Text);
                    int libraryFilesIdEdit = Int32.Parse(((Label)rowDelete.FindControl("lblLibraryFileIdEdit")).Text);
                    GrdNotesDeleteAttachment(libraryFilesIdEdit, refIdEdit);
                    break;
            }
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
                    Session["activeTabServices"] = "4";
                    Session["dialogOpenedServices"] = "1";
                    GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                    int refId = Int32.Parse(((Label)row.FindControl("lblRefIDEdit")).Text);
                    string subject = ((TextBox)row.FindControl("tbxNoteSubjectEdit")).Text.Trim();
                    GrdNotesAddAttachment(refId, subject);
                    break;

                case "AddAttachmentAdd":
                    Session["activeTabServices"] = "4";
                    Session["dialogOpenedServices"] = "1";
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



        protected void grdCosts_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.Validate("costsDataEdit");
            if (Page.IsValid)
            {
                int serviceId = (int)e.Keys["ServiceID"];
                int refId = (int)e.Keys["RefID"];
                int companyId = Int32.Parse(hdfCompanyId.Value);

                string partNumber = ((TextBox)grdCosts.Rows[e.RowIndex].FindControl("tbxPartNumber")).Text.Trim();
                string partName = ((TextBox)grdCosts.Rows[e.RowIndex].FindControl("tbxPartName")).Text.Trim();
                string vendor = ((TextBox)grdCosts.Rows[e.RowIndex].FindControl("tbxVendor")).Text.Trim();
                decimal cost = decimal.Parse(((TextBox)grdCosts.Rows[e.RowIndex].FindControl("tbxCost")).Text.Trim());
                int? noteId = null; if (((Label)grdCosts.Rows[e.RowIndex].FindControl("lblNoteIDEdit")).Text != "") noteId = Int32.Parse(((Label)grdCosts.Rows[e.RowIndex].FindControl("lblNoteIDEdit")).Text);

                // Update data
                ServiceInformationServiceCost model = new ServiceInformationServiceCost(serviceInformationTDS);
                model.Update(serviceId, refId, partNumber, partName, vendor, cost, noteId);

                // Store dataset
                Session["serviceInformationTDS"] = serviceInformationTDS;

                // Calc TotalCost
                tbxTotalCost.Text = Decimal.Round(model.GetTotalCost(serviceId, companyId), 2).ToString();
            }
            else
            {
                e.Cancel = true;
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
                Session["serviceInformationTDS"] = serviceInformationTDS;
            }
            else
            {
                e.Cancel = true;
            }
        }



        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set active toolbar
            mForm6 master = (mForm6)this.Master;
            master.ActiveToolbar = "FleetManagement";

            // For error message
            hdfErrorFieldList.Value = "";

            // Validate left menu if the user has admin permission
            if (Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_SERVICES_ADMIN"]))
            {
                tkrpbLeftMenuAllServiceRequests.Visible = true;
                tkrpbLeftMenuMyServiceRequests.Visible = false;
                tkrpbLeftMenuTools.Visible = true;
            }
            else
            {
                tkrpbLeftMenuAllServiceRequests.Visible = false;
                tkrpbLeftMenuMyServiceRequests.Visible = true;
                tkrpbLeftMenuTools.Visible = false;
            }

            // Tabs validation
            // ... Validate vehicle info
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int serviceId = Int32.Parse(hdfServiceId.Value);

            ServiceInformationBasicInformationGateway serviceInformationBasicInformationGatewayForId = new ServiceInformationBasicInformationGateway(serviceInformationTDS);
            int? unitId = serviceInformationBasicInformationGatewayForId.GetUnitID(serviceId);

            UnitsGateway unitsGateway = new UnitsGateway();
            unitsGateway.LoadByUnitId((int)unitId, companyId);
            string unitType = unitsGateway.GetType((int)unitId);
            int companyLevel = unitsGateway.GetCompanyLevelId((int)unitId);

            if (unitType != "Vehicle")
            {
                lblGeneralMileage.Visible = false;
                tbxGeneralMileage.Visible = false;
                lblGeneralMileageUnitOfMeasurement.Visible = false;                
                lblStartWorkDataStartMileage.Visible = false;
                tbxStartWorkDataStartMileage.Visible = false;
                lblStartWorkDataMileageUnitOfMeasurement.Visible = false;                
                lblStartWorkDataMileageUnitOfMeasurementReadOnly.Visible = false;                
                lblCompleteWorkDataCompleteMileage.Visible = false;
                tbxCompleteWorkDataCompleteMileage.Visible = false;
                lblCompleteWorkDataMileageUnitOfMeasurement.Visible = false;                
                lblCompleteWorkDataMileageUnitOfMeasurementReadOnly.Visible = false;                
            }
            else
            {
                // .. For Vehicles
                lblGeneralMileage.Visible = true;
                tbxGeneralMileage.Visible = true;
                lblStartWorkDataStartMileage.Visible = true;
                tbxStartWorkDataStartMileage.Visible = true;
                lblCompleteWorkDataCompleteMileage.Visible = true;
                tbxCompleteWorkDataCompleteMileage.Visible = true;
                lblGeneralMileageUnitOfMeasurement.Visible = true;                
                lblStartWorkDataMileageUnitOfMeasurement.Visible = true;
                lblStartWorkDataMileageUnitOfMeasurementReadOnly.Visible = true;
                lblCompleteWorkDataMileageUnitOfMeasurementReadOnly.Visible = true;
            }            

            // Assign Tab 
            // ... Assigned To
            hdfServiceState.Value = serviceInformationBasicInformationGatewayForId.GetServiceState(serviceId);
            string state = hdfServiceState.Value;
            
            if (state == "Unassigned")
            {
                // ... Princial Panels
                pnlAssignmentData.Visible = false;
                pnlAssignmentDataReadOnly.Visible = true;

                // ... ...Subpanels
                pnlAssignedTo.Visible = false;
                pnlAssignedToReadOnly.Visible = false;
                pnlAssignmentAccept.Visible = false;
                pnlAssignmentReject.Visible = false;

                pnlAssignmentAcceptReadOnly.Visible = true;
                pnlAssignmentRejectReadOnly.Visible = true;
            }

            if ((state == "Assigned") || (state == "Rejected"))
            {
                // ... ... Principal Panels
                pnlAssignmentData.Visible = true;
                pnlAssignmentDataReadOnly.Visible = false;
                
                // ... ...Subpanels
                pnlAssignedTo.Visible = true;
                pnlAssignedToReadOnly.Visible = false;
                pnlAssignmentAccept.Visible = false;
                pnlAssignmentReject.Visible = false;

                pnlAssignmentAcceptReadOnly.Visible = false;
                pnlAssignmentRejectReadOnly.Visible = false;
            }
            else
            {
                if ((state == "Accepted") || (state == "In Progress") || (state == "Completed"))
                {
                    // ... ... Principal Panels
                    pnlAssignmentData.Visible = true;
                    pnlAssignmentDataReadOnly.Visible = false;

                    // ... ...Subpanels
                    pnlAssignedTo.Visible = false;
                    pnlAssignedToReadOnly.Visible = true;
                    pnlAssignmentAccept.Visible = false;
                    pnlAssignmentReject.Visible = false;
                    pnlAssignmentAcceptReadOnly.Visible = false;
                    pnlAssignmentRejectReadOnly.Visible = false;
                }
            }

            // ... Assignation result
            if ((state == "Accepted") || (state == "In Progress") || (state == "Completed"))
            {
                // ... ... Principal Panels
                pnlAssignmentData.Visible = true;
                pnlAssignmentDataReadOnly.Visible = false;

                // ... ...Subpanels
                pnlAssignedTo.Visible = false;
                pnlAssignedToReadOnly.Visible = true;
                pnlAssignmentAccept.Visible = true;
                pnlAssignmentReject.Visible = false;
                pnlAssignmentAcceptReadOnly.Visible = false;
                pnlAssignmentRejectReadOnly.Visible = false;
            }

            // StartWork tab
            if ((state == "Unassigned") || (state == "Assigned") || (state == "Rejected") || (state == "Accepted"))
            {
                pnlStartWorkDataReadOnly.Visible = true;
                pnlStartWorkData.Visible = false;
            }
            else
            {
                pnlStartWorkDataReadOnly.Visible = false;
                pnlStartWorkData.Visible = true;
            }

            // Complete Work tab
            if ((state == "Unassigned") || (state == "Assigned") || (state == "Rejected") || (state == "Accepted") || (state == "In Progress"))
            {
                pnlCompleteWorkDataReadOnly.Visible = true;
                pnlCompleteWorkData.Visible = false;
            }
            else
            {
                pnlCompleteWorkDataReadOnly.Visible = false;
                pnlCompleteWorkData.Visible = true;
            }

            // ... Validate for assignated person
            if (serviceInformationBasicInformationGatewayForId.GetToTeamMember(serviceId))
            {
                pnlTeamMemberAssigned.Visible = true;
                pnlThirdPartyVendorAssigned.Visible = false;
                pnlTeamMemberAssignedReadOnly.Visible = true;
                pnlThirdPartyVendorAssignedReadOnly.Visible = false;
            }
            else
            {
                pnlTeamMemberAssigned.Visible = false;
                pnlThirdPartyVendorAssigned.Visible = true;
                pnlTeamMemberAssignedReadOnly.Visible = false;
                pnlThirdPartyVendorAssignedReadOnly.Visible = true;

            }
        }        






        // ////////////////////////////////////////////////////////////////////////
        // AUXILIAR EVENTS
        //      

        protected void cvOutOfServiceDate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;
            if (!tkrdpStartWorkDataUnitOutOfServiceDate.SelectedDate.HasValue)
            {
                args.IsValid = false;
                hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Out Of Service Date (Start Work)";
            }
        }        



        protected void cvBackInServiceDate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            if (!tkrdpCompleteWorkDataUnitBackInServiceDate.SelectedDate.HasValue)
            {
                args.IsValid = false;
                hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Unit Back In Service Date (Complete Work)";
            }
        }



        protected void cvGeneralDataMileage_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;           

            if (ckbxMtoDto.Checked)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                int serviceId = Int32.Parse(hdfServiceId.Value);

                ServiceInformationBasicInformationGateway serviceInformationBasicInformationGatewayForId = new ServiceInformationBasicInformationGateway(serviceInformationTDS);
                int? unitId = serviceInformationBasicInformationGatewayForId.GetUnitID(serviceId);

                UnitsGateway unitsGateway = new UnitsGateway();
                unitsGateway.LoadByUnitId((int)unitId, companyId);
                string unitType = unitsGateway.GetType((int)unitId);

                if (unitType == "Vehicle")
                {
                    if (tbxGeneralMileage.Text == "")
                    {
                        args.IsValid = false;
                        hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Mileage (General)";
                    }
                }
            }
        }
                


        protected void cvCompleteWorkDataMileage_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int serviceId = Int32.Parse(hdfServiceId.Value);

            ServiceInformationBasicInformationGateway serviceInformationBasicInformationGatewayForId = new ServiceInformationBasicInformationGateway(serviceInformationTDS);
            int? unitId = serviceInformationBasicInformationGatewayForId.GetUnitID(serviceId);

            UnitsGateway unitsGateway = new UnitsGateway();
            unitsGateway.LoadByUnitId((int)unitId, companyId);
            string unitType = unitsGateway.GetType((int)unitId);

            if (unitType == "Vehicle")
            {
                if (tbxCompleteWorkDataCompleteWorkDateTime.Text != "")
                {
                    if (tbxCompleteWorkDataCompleteMileage.Text == "")
                    {
                        args.IsValid = false;
                        hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Mileage (Complete Work)";
                    }
                }
            }            
        }



        protected void cvStartWorkDataMileage_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int serviceId = Int32.Parse(hdfServiceId.Value);

            ServiceInformationBasicInformationGateway serviceInformationBasicInformationGatewayForId = new ServiceInformationBasicInformationGateway(serviceInformationTDS);
            int? unitId = serviceInformationBasicInformationGatewayForId.GetUnitID(serviceId);

            UnitsGateway unitsGateway = new UnitsGateway();
            unitsGateway.LoadByUnitId((int)unitId, companyId);
            string unitType = unitsGateway.GetType((int)unitId);

            if (unitType == "Vehicle")
            {
                if (tbxStartWorkDataWorkStartDateTime.Text != "")
                {
                    if (tbxStartWorkDataStartMileage.Text == "")
                    {
                        args.IsValid = false;
                        hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Mileage (Start Work)";
                    }
                }
            }            
        }



        protected void cvTeamMember_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;
            if ((rbtnAssignmentDataToTeamMember.Checked) && (ddlAssignmentDataAssignToTeamMember.SelectedValue == "-1"))
            {
                args.IsValid = false;
                hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Team Member (Assignment Data)";
            }
        }



        protected void cvThridPartyVendor_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;
            if ((rbtnAssignmentDataToThirdPartyVendor.Checked) && (tbxAssignmentDataAssignToThirdPartyVendor.Text == ""))
            {
                args.IsValid = false;
                hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Third Party Vendo (Assignment Data)";
            }
        }



        protected void btnAssociate_Click(object sender, EventArgs e)
        {
            Session["activeTabServices"] = "4";
            Session["dialogOpenedServices"] = "1";
        }



        protected void btnUnassociate_Click(object sender, EventArgs e)
        {
            Session["activeTabServices"] = "4";
            Session["dialogOpenedServices"] = "1";

            ServiceInformationBasicInformation serviceInformationBasicInformation = new ServiceInformationBasicInformation(serviceInformationTDS);
            serviceInformationBasicInformation.UpdateLibraryCategoriesId(int.Parse(hdfServiceId.Value), null);

            ViewState["update"] = "no";

            btnUnassociate.Visible = false;
            btnAssociate.Visible = true;
            tbxCategoryAssocited.Text = "";
        }



        protected void btnAddAtachment_Click(object sender, EventArgs e)
        {
            Session["activeTabServices"] = "4";
            Session["dialogOpenedServices"] = "1";

            GrdNotesAddFromCost(tbxNoteNoteNew.Text, tbxNoteNoteNew.Text);//TODO

            ServiceInformationServiceNote model = new ServiceInformationServiceNote(serviceInformationTDS);
            int refId = model.GetLastRefId();

            if (ViewState["libraryCategoriesId"] != null)
            {
                string subject = "";

                // Escape single quote
                subject = tbxNoteNoteNew.Text.Replace("'", "%27");

                string script = "<script language='javascript'>";
                string url = "./services_add_attachment.aspx?source_page=services_edit.aspx&subject=" + Server.UrlEncode(subject) + "&refId=" + refId.ToString() + "&service_id=" + hdfServiceId.Value + "&library_categories_id=" + Int32.Parse(ViewState["libraryCategoriesId"].ToString());
                script = script + string.Format("window.open('{0}', '_blank', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=510, height=270')", url);
                script = script + "</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Notes", script, false);
            }
        }



        protected void grdCosts_DataBound(object sender, EventArgs e)
        {
            AddCostsNewEmptyFix(grdCosts);
        }



        protected void grdCostsReadOnly_DataBound(object sender, EventArgs e)
        {
            AddCostsReadOnlyNewEmptyFix(grdCostsReadOnly);
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

                    ServiceInformationBasicInformationGateway serviceInformationBasicInformationGateway = new ServiceInformationBasicInformationGateway(serviceInformationTDS);
                    int? libraryCategoriesId = null; if (serviceInformationBasicInformationGateway.GetLibraryCategoriesId(int.Parse(hdfServiceId.Value)).HasValue) libraryCategoriesId = (int)serviceInformationBasicInformationGateway.GetLibraryCategoriesId(int.Parse(hdfServiceId.Value));

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
                ServiceInformationBasicInformationGateway serviceInformationBasicInformationGateway = new ServiceInformationBasicInformationGateway(serviceInformationTDS);
                int? libraryCategoriesId = null; if (serviceInformationBasicInformationGateway.GetLibraryCategoriesId(int.Parse(hdfServiceId.Value)).HasValue) libraryCategoriesId = (int)serviceInformationBasicInformationGateway.GetLibraryCategoriesId(int.Parse(hdfServiceId.Value));

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



        protected void grdCosts_RowDataBound(object sender, GridViewRowEventArgs e)
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

                    ServiceInformationBasicInformationGateway serviceInformationBasicInformationGateway = new ServiceInformationBasicInformationGateway(serviceInformationTDS);
                    int? libraryCategoriesId = null; if (serviceInformationBasicInformationGateway.GetLibraryCategoriesId(int.Parse(hdfServiceId.Value)).HasValue) libraryCategoriesId = (int)serviceInformationBasicInformationGateway.GetLibraryCategoriesId(int.Parse(hdfServiceId.Value));

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
                ServiceInformationBasicInformationGateway serviceInformationBasicInformationGateway = new ServiceInformationBasicInformationGateway(serviceInformationTDS);
                int? libraryCategoriesId = null; if (serviceInformationBasicInformationGateway.GetLibraryCategoriesId(int.Parse(hdfServiceId.Value)).HasValue) libraryCategoriesId = (int)serviceInformationBasicInformationGateway.GetLibraryCategoriesId(int.Parse(hdfServiceId.Value));

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



        protected void grdCosts_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Costs Gridview, if the gridview is edition mode
            if (grdCosts.EditIndex >= 0)
            {
                grdCosts.UpdateRow(grdCosts.EditIndex, true);
            }
        }





        
        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATION EVENTS
        //

        protected void tkrmTop_ItemClick(object sender, RadMenuEventArgs e)
        {
            // Store active tab for postback
            Session["activeTabServices"] = "0";
            Session["dialogOpenedServices"] = "0";

            string activeTab = hdfActiveTab.Value;
            string url = "";

            switch (e.Item.Value)
            {
                case "mSave":
                    this.Save();                    
                    break;

                case "mApply":
                    this.Apply();
                    break;

                case "mCancel":
                    Session.Remove("libraryTDSForServices");                    
                    if ((Request.QueryString["source_page"] == "services_navigator2.aspx") || (Request.QueryString["source_page"] == "services_add_request.aspx"))
                    {
                        url = "./services_navigator2.aspx?source_page=services_edit.aspx" + GetNavigatorState() + "&update=yes";
                    }

                    if ((Request.QueryString["dashboardFromAddService"] == "True") && (Request.QueryString["dashboard"] == "True"))
                    {
                        url = "./../../FleetManagement/Dashboard/dashboard_login.aspx?source_page=out";
                    }
                    else
                    {
                        if (Request.QueryString["source_page"] == "services_summary.aspx")
                        {
                            url = "./services_summary.aspx?source_page=services_edit.aspx&dashboard=" + hdfDashboard.Value + "&service_id=" + hdfServiceId.Value + GetNavigatorState() + "&update=yes" + "&active_tab=" + activeTab;
                        }
                    }
                    break;

                case "mPrevious":
                    // Get previous record
                    int previousId = ServicesNavigator.GetPreviousId((ServicesNavigatorTDS)Session["servicesNavigatorTDS"], Int32.Parse(hdfServiceId.Value));
                    if (previousId != Int32.Parse(hdfServiceId.Value))
                    {
                        this.Apply();

                        // ... Redirect
                        url = "./services_edit.aspx?source_page=" + Request.QueryString["source_page"] + "&dashboard=False&service_id=" + previousId + "&active_tab=" + activeTab + GetNavigatorState() + "&update=yes";
                    }
                    break;

                case "mNext":
                    // Get next record
                    int nextId = ServicesNavigator.GetNextId((ServicesNavigatorTDS)Session["servicesNavigatorTDS"], Int32.Parse(hdfServiceId.Value));

                    if (nextId != Int32.Parse(hdfServiceId.Value))
                    {
                        this.Apply();

                        // ... Redirect
                        url = "./services_edit.aspx?source_page=" + Request.QueryString["source_page"] + "&dashboard=False&service_id=" + nextId + "&active_tab=" + activeTab + GetNavigatorState() + "&update=yes";
                    }
                    break;
            }

            if (url != "") Response.Redirect(url);
        }



        protected void tkrpbLeftMenu_ItemClick(object sender, RadPanelBarEventArgs e)
        {
            // Store active tab for postback
            Session["activeTabServices"] = "0";
            Session["dialogOpenedServices"] = "0";
            Session.Remove("libraryTDSForServices");

            string url = "";

            switch (e.Item.Value)
            {
                case "mSearch":
                    url = "./services_navigator.aspx?source_page=lm&fm_type=" + hdfFmType.Value;
                    break;
            }

            if (url != "") Response.Redirect(url);
        }






        // ////////////////////////////////////////////////////////////////////////
        // METHODS
        //

        public ServiceInformationTDS.CostInformationDataTable GetCostsNew()
        {
            serviceInformationServiceCost = (ServiceInformationTDS.CostInformationDataTable)Session["serviceCostsDummy"];
            if (serviceInformationServiceCost == null)
            {
                serviceInformationServiceCost = ((ServiceInformationTDS)Session["serviceInformationTDS"]).CostInformation;
            }

            return serviceInformationServiceCost;
        }



        public ServiceInformationTDS.NoteInformationDataTable GetNotesNew()
        {
            serviceInformationServiceNote = (ServiceInformationTDS.NoteInformationDataTable)Session["serviceNotesDummy"];
            if (serviceInformationServiceNote == null)
            {
                serviceInformationServiceNote = ((ServiceInformationTDS)Session["serviceInformationTDS"]).NoteInformation;
            }

            return serviceInformationServiceNote;
        }



        public void DummyCostsNew(int ServiceID, int RefID)
        {
        }



        public void DummyNotesNew(int ServiceID, int RefID)
        {
        }



        private void RegisterClientScripts()
        {
            // Register content variables
            string contentVariables = "";
            contentVariables += "var hdfServiceIdId = '" + hdfServiceId.ClientID + "';";
            contentVariables += "var hdfFmTypeId = '" + hdfFmType.ClientID + "';";
            contentVariables += "var hdfActiveTabId = '" + hdfActiveTab.ClientID + "';";
            contentVariables += "var hdfDashboardId = '" + hdfDashboard.ClientID + "';";
            contentVariables += "var tkrmTopId = '" + tkrmTop.ClientID + "';"; 

            // Publishing body's OnKeyDown event 
            HtmlGenericControl bodyUnload = (HtmlGenericControl)Page.Master.FindControl("myBody");
            bodyUnload.Attributes.Add("OnKeyDown", "OnKeyDown(event);");

            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./services_edit.js");
        }



        private void StoreNavigatorState()
        {
            ViewState["navigatorState"] = "&columns_to_display=" + Request.QueryString["columns_to_display"] + "&search_ddlCondition1=" + Request.QueryString["search_ddlCondition1"] + "&search_tbxCondition1=" + Request.QueryString["search_tbxCondition1"] + "&search_ddlView=" + Request.QueryString["search_ddlView"] + "&search_sort_by=" + Request.QueryString["search_sort_by"] + "&search_state=" + Request.QueryString["search_state"] + "&btn_origin=" + Request.QueryString["btn_origin"];
        }



        private string GetNavigatorState()
        {
            return (string)ViewState["navigatorState"];
        }



        #region Load Functions

        private void LoadServiceData(int companyId)
        {
            // Get FmId
            string fmType = hdfFmType.Value.Trim();
            int serviceId = Int32.Parse(hdfServiceId.Value);

            // Load Data
            LoadBasicData(serviceId);
            LoadDetailedData(serviceId);
            LoadNotes();
        }



        private void LoadBasicData(int serviceId)
        {
            ServiceInformationBasicInformationGateway serviceInformationBasicInformationGateway = new ServiceInformationBasicInformationGateway(serviceInformationTDS);
            if (serviceInformationBasicInformationGateway.Table.Rows.Count > 0)
            {
                // Load service basic data
                tbxServiceState.Text = serviceInformationBasicInformationGateway.GetServiceState(serviceId);
                tbxServiceNumber.Text = serviceInformationBasicInformationGateway.GetServiceNumber(serviceId);
                tbxDateTime.Text = serviceInformationBasicInformationGateway.GetDateTime_(serviceId).ToString();
                ckbxMtoDto.Checked = serviceInformationBasicInformationGateway.GetMtoDto(serviceId);
                tbxServiceDescription.Text = serviceInformationBasicInformationGateway.GetServiceDescription(serviceId);

                // Load unit basic data
                tbxUnitCode.Text = serviceInformationBasicInformationGateway.GetUnitCode(serviceId);
                tbxUnitDescription.Text = serviceInformationBasicInformationGateway.GetUnitDescription(serviceId);
                tbxVinSn.Text = serviceInformationBasicInformationGateway.GetVinSn(serviceId);
                tbxUnitState.Text = serviceInformationBasicInformationGateway.GetUnitState(serviceId);

                // Load checklist data
                tbxAssociatedChecklistRule.Text = serviceInformationBasicInformationGateway.GetAssociatedChecklistRule(serviceId);
                tbxChecklistState.Text = serviceInformationBasicInformationGateway.GetAssociatedChecklistRuleState(serviceId);

                if (serviceInformationBasicInformationGateway.GetRuleId(serviceId).HasValue)
                {
                    RuleGateway ruleGateway = new RuleGateway();
                    int? ruleId = serviceInformationBasicInformationGateway.GetRuleId(serviceId);
                    ruleGateway.LoadAllByRuleId(ruleId.Value, Int32.Parse(hdfCompanyId.Value));
                    int? serviceRequestDays = ruleGateway.GetServiceRequestDays(ruleId.Value);

                    if (ruleGateway.GetMto(ruleId.Value) && serviceInformationBasicInformationGateway.GetAssociatedChecklistLastService(serviceId).HasValue)
                    {
                        tbxChecklistNextDueDate.Text = serviceInformationBasicInformationGateway.GetAssociatedChecklistLastService(serviceId).Value.ToShortDateString();
                    }
                    else
                    {
                        if (serviceRequestDays.HasValue)
                        {
                            int negValue = -1;
                            serviceRequestDays = serviceRequestDays.Value * negValue;
                            DateTime serviceRequestCreationDate = serviceInformationBasicInformationGateway.GetDateTime_(serviceId);
                            tbxChecklistNextDueDate.Text = serviceInformationBasicInformationGateway.GetAssociatedChecklistNextDue(serviceId).Value.AddDays(Convert.ToDouble(serviceRequestDays.Value)).ToShortDateString();
                        }
                    }
                }
            }
        }



        private void LoadDetailedData(int serviceId)
        {
            ServiceInformationBasicInformationGateway serviceInformationBasicInformationGateway = new ServiceInformationBasicInformationGateway(serviceInformationTDS);
            if (serviceInformationBasicInformationGateway.Table.Rows.Count > 0)
            {
                // Load for General Tab
                tbxGeneralCreatedBy.Text = serviceInformationBasicInformationGateway.GetCreatedBy(serviceId);
                tbxGeneralMileage.Text = serviceInformationBasicInformationGateway.GetMileage(serviceId);
                lblGeneralMileageUnitOfMeasurement.Text = serviceInformationBasicInformationGateway.GetMileageUnitOfMeasurement(serviceId);

                // Load for Assginment Tab
                LoadDetailaDataAssignmentData(serviceId, serviceInformationBasicInformationGateway);

                // Load for Start Work Tab
                LoadDetailaDataStartWork(serviceId, serviceInformationBasicInformationGateway);

                // Load for Complete Work Tab
                LoadDetailaDataCompleteWork(serviceId, serviceInformationBasicInformationGateway);
            }
        }



        private void LoadDetailaDataAssignmentData(int serviceId, ServiceInformationBasicInformationGateway serviceInformationBasicInformationGateway)
        { 
            // Load for Assignment Tab
            // ... pnlAssignmentData
            tbxAssignmentDataAssignmentDateTime.Text = serviceInformationBasicInformationGateway.GetAssignmentDateTime(serviceId).ToString();

            if (serviceInformationBasicInformationGateway.GetAssignedDeadlineDate(serviceId).HasValue)
            {
                DateTime deadlineDate = (DateTime)serviceInformationBasicInformationGateway.GetAssignedDeadlineDate(serviceId);
                tkrdpAssignmentDataAssignedDeadlineDate.SelectedDate = DateTime.Parse(deadlineDate.Month.ToString() + "/" + deadlineDate.Day.ToString() + "/" + deadlineDate.Year.ToString());
            }

            if ((serviceInformationBasicInformationGateway.GetToTeamMember(serviceId)) && (serviceInformationBasicInformationGateway.GetAssignedThirdPartyVendor(serviceId)) == "")
            {
                // ... For team member
                rbtnAssignmentDataToTeamMember.Checked = true;
                rbtnAssignmentDataToTeamMemberReadOnly.Checked = true;
                
                // ... For third party vendor
                rbtnAssignmentDataToThirdPartyVendor.Checked = false;
                rbtnAssignmentDataToThirdPartyVendorReadOnly.Checked = false;
            }
            else
            {
                if ((!serviceInformationBasicInformationGateway.GetToTeamMember(serviceId)) && (serviceInformationBasicInformationGateway.GetAssignedThirdPartyVendor(serviceId)) != "")
                {
                    // ... For team member
                    rbtnAssignmentDataToTeamMember.Checked = false;
                    rbtnAssignmentDataToTeamMemberReadOnly.Checked = false;

                    // ... For third party vendor
                    rbtnAssignmentDataToThirdPartyVendor.Checked = true;
                    rbtnAssignmentDataToThirdPartyVendorReadOnly.Checked = true;

                    tbxAssignmentDataAssignToThirdPartyVendor.Text = serviceInformationBasicInformationGateway.GetAssignedThirdPartyVendor(serviceId);
                    tbxAssignmentDataAssignToThirdPartyVendorReadOnly.Text = serviceInformationBasicInformationGateway.GetAssignedThirdPartyVendor(serviceId);
                }
                else
                {
                    rbtnAssignmentDataToTeamMember.Checked = false;
                    rbtnAssignmentDataToTeamMemberReadOnly.Checked = false;
                    rbtnAssignmentDataToThirdPartyVendor.Checked = false;
                    rbtnAssignmentDataToThirdPartyVendorReadOnly.Checked = false;
                }
            }

            tbxAssignmentDataAcceptedDateTime.Text = serviceInformationBasicInformationGateway.GetAcceptedDateTime(serviceId).ToString();

            DateTime? acceptedDateTime = serviceInformationBasicInformationGateway.GetAcceptedDateTime(serviceId);
            if (acceptedDateTime.HasValue) tbxAssignmentDataAcceptedDateTime.Text = acceptedDateTime.ToString();

            DateTime? rejectedDateTime = serviceInformationBasicInformationGateway.GetRejectedDateTime(serviceId);
            if (rejectedDateTime.HasValue) tbxAssignmentDataRejectedDateTime.Text = rejectedDateTime.ToString();
            tbxAssignmentDataRejectedReason.Text = serviceInformationBasicInformationGateway.GetRejectedReason(serviceId);

            // ... pnlAssignmentDataReadOnly
            tbxAssignmentDataAssignmentDateTimeReadOnly.Text = serviceInformationBasicInformationGateway.GetAssignmentDateTime(serviceId).ToString();

            tbxAssignmentDataAssignedDeadlineDateReadOnly.Text = "";
            if (serviceInformationBasicInformationGateway.GetAssignedDeadlineDate(serviceId).HasValue)
            {
                DateTime deadlineDate = (DateTime)serviceInformationBasicInformationGateway.GetAssignedDeadlineDate(serviceId);
                tbxAssignmentDataAssignedDeadlineDateReadOnly.Text = deadlineDate.Month.ToString() + "/" + deadlineDate.Day.ToString() + "/" + deadlineDate.Year.ToString();
            }

            if ((serviceInformationBasicInformationGateway.GetToTeamMember(serviceId)) && (serviceInformationBasicInformationGateway.GetAssignedThirdPartyVendor(serviceId)) == "")
            {
                // ... For team member
                rbtnAssignmentDataReadOnlyToTeamMemberReadOnly.Checked = true;

                if (serviceInformationBasicInformationGateway.GetAssignTeamMemberId(serviceId).HasValue)
                {
                    int teamMemberId = (int)serviceInformationBasicInformationGateway.GetAssignTeamMemberId(serviceId);
                    EmployeeGateway employeeGateway = new EmployeeGateway();
                    employeeGateway.LoadByEmployeeId(teamMemberId);
                    tbxAssignmentDataReadOnlyAssignToTeamMemberReadOnly.Text = employeeGateway.GetLastName(teamMemberId) + " " + employeeGateway.GetFirstName(teamMemberId);
                }

                // ... For third party vendor
                rbtnAssignmentDataReadOnlyToThirdPartyVendorReadOnly.Checked = false;
            }
            else
            {
                if ((!serviceInformationBasicInformationGateway.GetToTeamMember(serviceId)) && (serviceInformationBasicInformationGateway.GetAssignedThirdPartyVendor(serviceId)) != "")
                {
                    // ... For team member
                    rbtnAssignmentDataReadOnlyToTeamMemberReadOnly.Checked = false;

                    // ... For third party vendor
                    rbtnAssignmentDataReadOnlyToThirdPartyVendorReadOnly.Checked = true;

                    tbxAssignmentDataReadOnlyAssignToThirdPartyVendorReadOnly.Text = serviceInformationBasicInformationGateway.GetAssignedThirdPartyVendor(serviceId);
                }
                else
                {
                    rbtnAssignmentDataReadOnlyToTeamMemberReadOnly.Checked = false;
                    rbtnAssignmentDataReadOnlyToThirdPartyVendorReadOnly.Checked = false;
                }
            }

            tbxAssignmentDataAcceptedDateTimeReadOnly.Text = serviceInformationBasicInformationGateway.GetAcceptedDateTime(serviceId).ToString();

            DateTime? acceptedDateTimeReadOnly = serviceInformationBasicInformationGateway.GetAcceptedDateTime(serviceId);
            if (acceptedDateTimeReadOnly.HasValue) tbxAssignmentDataAcceptedDateTimeReadOnly.Text = acceptedDateTimeReadOnly.ToString();

            DateTime? rejectedDateTimeReadOnly = serviceInformationBasicInformationGateway.GetRejectedDateTime(serviceId);
            if (rejectedDateTimeReadOnly.HasValue) tbxAssignmentDataRejectedDateTimeReadOnly.Text = rejectedDateTimeReadOnly.ToString();
            tbxAssignmentDataRejectedReasonReadOnly.Text = serviceInformationBasicInformationGateway.GetRejectedReason(serviceId);
        }



        private void LoadDetailaDataStartWork(int serviceId, ServiceInformationBasicInformationGateway serviceInformationBasicInformationGateway)
        {
            // Load for StartWork Tab
            // ... pnlStartWork
            tbxStartWorkDataWorkStartDateTime.Text = serviceInformationBasicInformationGateway.GetStartWorkDateTime(serviceId).ToString();

            if (serviceInformationBasicInformationGateway.GetUnitOutOfServiceDate(serviceId).HasValue)
            {
                DateTime outOfServiceDate = (DateTime)serviceInformationBasicInformationGateway.GetUnitOutOfServiceDate(serviceId);
                tkrdpStartWorkDataUnitOutOfServiceDate.SelectedDate = DateTime.Parse(outOfServiceDate.Month.ToString() + "/" + outOfServiceDate.Day.ToString() + "/" + outOfServiceDate.Year.ToString());
            }

            tbxStartWorkDataStartMileage.Text = serviceInformationBasicInformationGateway.GetStartWorkMileage(serviceId);
            lblStartWorkDataMileageUnitOfMeasurement.Text = serviceInformationBasicInformationGateway.GetMileageUnitOfMeasurement(serviceId);
            lblStartWorkDataMileageUnitOfMeasurementReadOnly.Text = serviceInformationBasicInformationGateway.GetMileageUnitOfMeasurement(serviceId);

            // ... pnlStartWorkReadOnly
            tbxStartWorkDataStartWorkDateTimeReadOnly.Text = serviceInformationBasicInformationGateway.GetStartWorkDateTime(serviceId).ToString();

            tbxStartWorkDataUnitOutOfServiceDateReadOnly.Text = "";
            if (serviceInformationBasicInformationGateway.GetUnitOutOfServiceDate(serviceId).HasValue)
            {
                DateTime outOfServiceDate = (DateTime)serviceInformationBasicInformationGateway.GetUnitOutOfServiceDate(serviceId);
                tbxStartWorkDataUnitOutOfServiceDateReadOnly.Text = outOfServiceDate.Month.ToString() + "/" + outOfServiceDate.Day.ToString() + "/" + outOfServiceDate.Year.ToString();
            }

            tbxStartWorkDataStartMileageReadOnly.Text = serviceInformationBasicInformationGateway.GetStartWorkMileage(serviceId);
        }



        private void LoadDetailaDataCompleteWork(int serviceId, ServiceInformationBasicInformationGateway serviceInformationBasicInformationGateway)
        {
            // Load for CompleteWork Tab
            // ... pnlCompleteWork
            tbxCompleteWorkDataCompleteWorkDateTime.Text = serviceInformationBasicInformationGateway.GetCompleteWorkDateTime(serviceId).ToString();

            if (serviceInformationBasicInformationGateway.GetUnitBackInServiceDate(serviceId).HasValue)
            {
                DateTime backInServiceDate = (DateTime)serviceInformationBasicInformationGateway.GetUnitBackInServiceDate(serviceId);
                tkrdpCompleteWorkDataUnitBackInServiceDate.SelectedDate = DateTime.Parse(backInServiceDate.Month.ToString() + "/" + backInServiceDate.Day.ToString() + "/" + backInServiceDate.Year.ToString());
            }

            tbxCompleteWorkDataCompleteMileage.Text = serviceInformationBasicInformationGateway.GetCompleteWorkMileage(serviceId);
            lblCompleteWorkDataMileageUnitOfMeasurement.Text = serviceInformationBasicInformationGateway.GetMileageUnitOfMeasurement(serviceId);
            lblCompleteWorkDataMileageUnitOfMeasurementReadOnly.Text = serviceInformationBasicInformationGateway.GetMileageUnitOfMeasurement(serviceId);

            // ... For team member
            tbxCompleteWorkDataDescription.Text = serviceInformationBasicInformationGateway.GetCompleteWorkDetailDescription(serviceId);
            ckbxCompleteWorkDataPreventable.Checked = serviceInformationBasicInformationGateway.GetCompleteWorkDetailPreventable(serviceId);
            tbxCompleteWorkDataLabourHours.Text = serviceInformationBasicInformationGateway.GetCompleteWorkDetailTMLabourHours(serviceId).ToString();

            // ... For third party vendor
            tbxCompleteWorkDataDescriptionThirdPartyVendor.Text = serviceInformationBasicInformationGateway.GetCompleteWorkDetailDescription(serviceId);
            ckbxCompleteWorkDataPreventableThirdPartyVendor.Checked = serviceInformationBasicInformationGateway.GetCompleteWorkDetailPreventable(serviceId);
            tbxCompleteWorkDataInvoiceNumberThirdPartyVendor.Text = serviceInformationBasicInformationGateway.GetCompleteWorkDetailTPVInvoiceNumber(serviceId);
            tbxCompleteWorkDataInvoiceAmountThirdPartyVendor.Text = serviceInformationBasicInformationGateway.GetCompleteWorkDetailTPVInvoiceAmout(serviceId).ToString();

            // ... PnlCompleteWorkReadOnly
            tbxCompleteWorkDataCompleteWorkDateTimeReadOnly.Text = serviceInformationBasicInformationGateway.GetCompleteWorkDateTime(serviceId).ToString();

            tbxCompleteWorkDataUnitBackInServiceDateReadOnly.Text = "";
            if (serviceInformationBasicInformationGateway.GetUnitBackInServiceDate(serviceId).HasValue)
            {
                DateTime backInServiceDate = (DateTime)serviceInformationBasicInformationGateway.GetUnitBackInServiceDate(serviceId);
                tbxCompleteWorkDataUnitBackInServiceDateReadOnly.Text = backInServiceDate.Month.ToString() + "/" + backInServiceDate.Day.ToString() + "/" + backInServiceDate.Year.ToString();
            }

            tbxCompleteWorkDataCompleteMileageReadOnly.Text = serviceInformationBasicInformationGateway.GetCompleteWorkMileage(serviceId);

            // ... For team member
            tbxCompleteWorkDataDescriptionReadOnly.Text = serviceInformationBasicInformationGateway.GetCompleteWorkDetailDescription(serviceId);
            ckbxCompleteWorkDataPreventableReadOnly.Checked = serviceInformationBasicInformationGateway.GetCompleteWorkDetailPreventable(serviceId);
            tbxCompleteWorkDataLabourHoursReadOnly.Text = serviceInformationBasicInformationGateway.GetCompleteWorkDetailTMLabourHours(serviceId).ToString();

            // ... For third party vendor
            tbxCompleteWorkDataDescriptionThirdPartyVendorReadOnly.Text = serviceInformationBasicInformationGateway.GetCompleteWorkDetailDescription(serviceId);
            ckbxCompleteWorkDataPreventableThirdPartyVendorReadOnly.Checked = serviceInformationBasicInformationGateway.GetCompleteWorkDetailPreventable(serviceId);
            tbxCompleteWorkDataInvoiceNumberThirdPartyVendorReadOnly.Text = serviceInformationBasicInformationGateway.GetCompleteWorkDetailTPVInvoiceNumber(serviceId);
            tbxCompleteWorkDataInvoiceAmountThirdPartyVendorReadOnly.Text = serviceInformationBasicInformationGateway.GetCompleteWorkDetailTPVInvoiceAmout(serviceId).ToString();
        }



        private void LoadNotes()
        {
            ServiceInformationBasicInformationGateway serviceInformationBasicInformationGateway = new ServiceInformationBasicInformationGateway(serviceInformationTDS);

            int? libraryCategoriesId = null; if (serviceInformationBasicInformationGateway.GetLibraryCategoriesId(int.Parse(hdfServiceId.Value)).HasValue) libraryCategoriesId = (int)serviceInformationBasicInformationGateway.GetLibraryCategoriesId(int.Parse(hdfServiceId.Value));

            if (libraryCategoriesId.HasValue)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                ViewState["libraryCategoriesId"] = (int)libraryCategoriesId;
                tbxCategoryAssocited.Text = GetFullCategoryName((int)libraryCategoriesId, companyId);
                btnAssociate.Visible = false;
                btnUnassociate.Visible = true;

                tbxNoteNoteNew.ReadOnly = false;
                btnAddAtachment.Enabled = true;
            }
            else
            {
                tbxCategoryAssocited.Text = "";
                btnAssociate.Visible = true;
                btnUnassociate.Visible = false;

                tbxNoteNoteNew.ReadOnly = true;
                btnAddAtachment.Enabled = false;
            }
        }


        #endregion



        private void Save()
        {
            // Validate data
            bool validData = true;

            validData = ValidatePage();

            // For valid data
            if (validData)
            {
                // Costs Gridview, if the gridview is edition mode
                if (grdCosts.EditIndex >= 0)
                {
                    grdCosts.UpdateRow(grdCosts.EditIndex, true);
                }

                // Notes Gridview, if the gridview is edition mode
                if (grdNotes.EditIndex >= 0)
                {
                    grdNotes.UpdateRow(grdNotes.EditIndex, true);
                }

                // Save cost and notes data
                GrdCostsAdd();
                GrdNotesAdd();

                // Save data
                int companyId = Int32.Parse(hdfCompanyId.Value);
                int serviceId = Int32.Parse(hdfServiceId.Value);

                // Unmodified data
                ServiceInformationBasicInformationGateway serviceInformationBasicInformationGatewayForEdit = new ServiceInformationBasicInformationGateway(serviceInformationTDS);
                string serviceState = serviceInformationBasicInformationGatewayForEdit.GetServiceState(serviceId);
                string associatedChecklistRuleState = serviceInformationBasicInformationGatewayForEdit.GetAssociatedChecklistRuleState(serviceId);

                // ... Get basic service data
                bool newMtoDto = ckbxMtoDto.Checked;
                string newServiceDescription = tbxServiceDescription.Text.Trim();

                // ... Get general service data
                string newMileage = tbxGeneralMileage.Text.Trim();

                // ... Get assigned data
                DateTime? newAssignmentDateTime = null;
                DateTime? newAssignmentDeadlineDate = null;
                bool newToTeamMember = false;
                int? newAssignTeamMemberID = null;
                string newThirdPartyVendor = "";
                DateTime? assignmentAcceptedDateTime = null;
                string newAssignmentRejectedReason = "";
                DateTime? assignmentRejectedDateTime = null;

                if (pnlAssignmentData.Visible)
                {
                    if (pnlAssignedToReadOnly.Visible)
                    {
                        if (serviceInformationBasicInformationGatewayForEdit.GetAssignmentDateTimeOriginal(serviceId).HasValue) newAssignmentDateTime = (DateTime)serviceInformationBasicInformationGatewayForEdit.GetAssignmentDateTimeOriginal(serviceId);
                        if (serviceInformationBasicInformationGatewayForEdit.GetAssignedDeadlineDate(serviceId).HasValue) newAssignmentDeadlineDate = (DateTime)serviceInformationBasicInformationGatewayForEdit.GetAssignedDeadlineDate(serviceId);
                        newToTeamMember = serviceInformationBasicInformationGatewayForEdit.GetToTeamMember(serviceId);
                        if (newToTeamMember) newAssignTeamMemberID = (int)serviceInformationBasicInformationGatewayForEdit.GetAssignTeamMemberId(serviceId);
                        newThirdPartyVendor = serviceInformationBasicInformationGatewayForEdit.GetAssignedThirdPartyVendor(serviceId);
                    }

                    if (pnlAssignedTo.Visible)
                    {
                        if (serviceInformationBasicInformationGatewayForEdit.GetAssignmentDateTimeOriginal(serviceId).HasValue) newAssignmentDateTime = (DateTime)serviceInformationBasicInformationGatewayForEdit.GetAssignmentDateTimeOriginal(serviceId);
                        if (tkrdpAssignmentDataAssignedDeadlineDate.SelectedDate.HasValue) newAssignmentDeadlineDate = tkrdpAssignmentDataAssignedDeadlineDate.SelectedDate.Value;
                        newToTeamMember = rbtnAssignmentDataToTeamMember.Checked;
                        if (newToTeamMember) newAssignTeamMemberID = Int32.Parse(ddlAssignmentDataAssignToTeamMember.SelectedValue);
                        newThirdPartyVendor = tbxAssignmentDataAssignToThirdPartyVendor.Text.Trim();
                    }

                    if (serviceInformationBasicInformationGatewayForEdit.GetAcceptedDateTime(serviceId).HasValue) assignmentAcceptedDateTime = (DateTime)serviceInformationBasicInformationGatewayForEdit.GetAcceptedDateTime(serviceId);
                    if (serviceInformationBasicInformationGatewayForEdit.GetRejectedDateTime(serviceId).HasValue) assignmentRejectedDateTime = (DateTime)serviceInformationBasicInformationGatewayForEdit.GetRejectedDateTime(serviceId);
                    newAssignmentRejectedReason = tbxAssignmentDataRejectedReason.Text.Trim();
                }
                else
                {
                    if (pnlAssignmentDataReadOnly.Visible)
                    {
                        if (serviceInformationBasicInformationGatewayForEdit.GetAssignmentDateTimeOriginal(serviceId).HasValue) newAssignmentDateTime = (DateTime)serviceInformationBasicInformationGatewayForEdit.GetAssignmentDateTimeOriginal(serviceId);
                        if (serviceInformationBasicInformationGatewayForEdit.GetAssignedDeadlineDate(serviceId).HasValue) newAssignmentDeadlineDate = (DateTime)serviceInformationBasicInformationGatewayForEdit.GetAssignedDeadlineDate(serviceId);
                        newToTeamMember = serviceInformationBasicInformationGatewayForEdit.GetToTeamMember(serviceId);
                        if (newToTeamMember) newAssignTeamMemberID = (int)serviceInformationBasicInformationGatewayForEdit.GetAssignTeamMemberId(serviceId);
                        newThirdPartyVendor = serviceInformationBasicInformationGatewayForEdit.GetAssignedThirdPartyVendor(serviceId);
                        if (serviceInformationBasicInformationGatewayForEdit.GetAcceptedDateTime(serviceId).HasValue) assignmentAcceptedDateTime = (DateTime)serviceInformationBasicInformationGatewayForEdit.GetAcceptedDateTime(serviceId);
                        if (serviceInformationBasicInformationGatewayForEdit.GetRejectedDateTime(serviceId).HasValue) assignmentRejectedDateTime = (DateTime)serviceInformationBasicInformationGatewayForEdit.GetRejectedDateTime(serviceId);
                        newAssignmentRejectedReason = tbxAssignmentDataRejectedReasonReadOnly.Text.Trim();
                    }
                }

                // ... Get start work data
                DateTime? startWorkDateTime = null; if (serviceInformationBasicInformationGatewayForEdit.GetStartWorkDateTime(serviceId).HasValue) startWorkDateTime = (DateTime)serviceInformationBasicInformationGatewayForEdit.GetStartWorkDateTime(serviceId);
                DateTime? newUnitOutOfServiceDate = null;
                string newUnitOutOfServiceTime = "";
                string newStartWorkMileage = "";

                if (pnlStartWorkData.Visible)
                {
                    if (tkrdpStartWorkDataUnitOutOfServiceDate.SelectedDate.HasValue) newUnitOutOfServiceDate = tkrdpStartWorkDataUnitOutOfServiceDate.SelectedDate.Value;
                    newUnitOutOfServiceTime = "8:00 AM";
                    newStartWorkMileage = tbxStartWorkDataStartMileage.Text.Trim();
                }
                else
                {
                    if (pnlStartWorkDataReadOnly.Visible)
                    {
                        if (tbxStartWorkDataUnitOutOfServiceDateReadOnly.Text.Trim() != "") newUnitOutOfServiceDate = DateTime.Parse(tbxStartWorkDataUnitOutOfServiceDateReadOnly.Text.Trim());
                        newUnitOutOfServiceTime = "8:00 AM";
                        newStartWorkMileage = tbxStartWorkDataStartMileageReadOnly.Text.Trim();
                    }
                }

                // ... Get complete work data
                DateTime? completeWorkDateTime = null; if (serviceInformationBasicInformationGatewayForEdit.GetCompleteWorkDateTime(serviceId).HasValue) completeWorkDateTime = (DateTime)serviceInformationBasicInformationGatewayForEdit.GetCompleteWorkDateTime(serviceId);
                DateTime? newUnitBackInServiceDate = null;
                string newUnitBackInServiceTime = "";
                string newCompleteWorkMileage = "";
                string newCompleteWorkDetailDescription = "";
                bool newCompleteWorkDetailPreventable = false;
                decimal? newCompleteWorkDetailTMLabourHours = 0.0M;
                string newCompleteWorkDetailTPVInvoiceNumber = "";
                decimal? newCompleteWorkDetailTPVInvoiceAmout = 0.0M;

                if (pnlCompleteWorkData.Visible)
                {
                    if (tkrdpCompleteWorkDataUnitBackInServiceDate.SelectedDate.HasValue) newUnitBackInServiceDate = tkrdpCompleteWorkDataUnitBackInServiceDate.SelectedDate.Value;
                    newUnitBackInServiceTime = "8:00 AM";
                    newCompleteWorkMileage = tbxCompleteWorkDataCompleteMileage.Text.Trim();

                    // ... ... From team member               
                    if (pnlTeamMemberAssigned.Visible)
                    {
                        if (tbxCompleteWorkDataDescription.Text.Trim() != "") newCompleteWorkDetailDescription = tbxCompleteWorkDataDescription.Text.Trim();
                        newCompleteWorkDetailPreventable = ckbxCompleteWorkDataPreventable.Checked;
                    }
                    newCompleteWorkDetailTMLabourHours = null; if (tbxCompleteWorkDataLabourHours.Text.Trim() != "") newCompleteWorkDetailTMLabourHours = decimal.Parse(tbxCompleteWorkDataLabourHours.Text.Trim());

                    // ... ... From Third party vendor
                    if (pnlThirdPartyVendorAssigned.Visible)
                    {
                        if (tbxCompleteWorkDataDescriptionThirdPartyVendor.Text.Trim() != "") newCompleteWorkDetailDescription = tbxCompleteWorkDataDescriptionThirdPartyVendor.Text.Trim();
                        newCompleteWorkDetailPreventable = ckbxCompleteWorkDataPreventableThirdPartyVendor.Checked;
                    }
                    newCompleteWorkDetailTPVInvoiceNumber = tbxCompleteWorkDataInvoiceNumberThirdPartyVendor.Text.Trim();
                    newCompleteWorkDetailTPVInvoiceAmout = null; if (tbxCompleteWorkDataInvoiceAmountThirdPartyVendor.Text.Trim() != "") newCompleteWorkDetailTPVInvoiceAmout = decimal.Parse(tbxCompleteWorkDataInvoiceAmountThirdPartyVendor.Text.Trim());
                }
                else
                {
                    if (pnlCompleteWorkDataReadOnly.Visible)
                    {
                        if (tbxCompleteWorkDataUnitBackInServiceDateReadOnly.Text.Trim() != "") newUnitBackInServiceDate = DateTime.Parse(tbxCompleteWorkDataUnitBackInServiceDateReadOnly.Text.Trim());
                        newUnitBackInServiceTime = "8:00 AM";
                        newCompleteWorkMileage = tbxCompleteWorkDataCompleteMileageReadOnly.Text.Trim();

                        // ... ... From team member               
                        if (pnlTeamMemberAssignedReadOnly.Visible)
                        {
                            if (tbxCompleteWorkDataDescriptionReadOnly.Text.Trim() != "") newCompleteWorkDetailDescription = tbxCompleteWorkDataDescriptionReadOnly.Text.Trim();
                            newCompleteWorkDetailPreventable = ckbxCompleteWorkDataPreventableReadOnly.Checked;
                        }
                        newCompleteWorkDetailTMLabourHours = null; if (tbxCompleteWorkDataLabourHoursReadOnly.Text.Trim() != "") newCompleteWorkDetailTMLabourHours = decimal.Parse(tbxCompleteWorkDataLabourHoursReadOnly.Text.Trim());

                        // ... ... From Third party vendor
                        if (pnlThirdPartyVendorAssignedReadOnly.Visible)
                        {
                            if (tbxCompleteWorkDataDescriptionThirdPartyVendorReadOnly.Text.Trim() != "") newCompleteWorkDetailDescription = tbxCompleteWorkDataDescriptionThirdPartyVendorReadOnly.Text.Trim();
                            newCompleteWorkDetailPreventable = ckbxCompleteWorkDataPreventableThirdPartyVendorReadOnly.Checked;
                        }
                        newCompleteWorkDetailTPVInvoiceNumber = tbxCompleteWorkDataInvoiceNumberThirdPartyVendorReadOnly.Text.Trim();
                        newCompleteWorkDetailTPVInvoiceAmout = null; if (tbxCompleteWorkDataInvoiceAmountThirdPartyVendorReadOnly.Text.Trim() != "") newCompleteWorkDetailTPVInvoiceAmout = decimal.Parse(tbxCompleteWorkDataInvoiceAmountThirdPartyVendorReadOnly.Text.Trim());
                    }
                }

                // Update service data
                ServiceInformationBasicInformation serviceInformationBasicInformation = new ServiceInformationBasicInformation(serviceInformationTDS);
                int? libraryCategoriesId = null; if (serviceInformationBasicInformationGatewayForEdit.GetLibraryCategoriesId(int.Parse(hdfServiceId.Value)).HasValue) libraryCategoriesId = (int)serviceInformationBasicInformationGatewayForEdit.GetLibraryCategoriesId(int.Parse(hdfServiceId.Value));
                serviceInformationBasicInformation.Update(serviceId, serviceState, newMtoDto, newServiceDescription, newMileage, newAssignmentDateTime, newAssignmentDeadlineDate, newToTeamMember, newAssignTeamMemberID, newThirdPartyVendor, assignmentAcceptedDateTime, assignmentRejectedDateTime, newAssignmentRejectedReason, startWorkDateTime, newUnitOutOfServiceDate, newUnitOutOfServiceTime, newStartWorkMileage, completeWorkDateTime, newUnitBackInServiceDate, newUnitBackInServiceTime, newCompleteWorkMileage, newCompleteWorkDetailDescription, newCompleteWorkDetailPreventable, newCompleteWorkDetailTMLabourHours, newCompleteWorkDetailTPVInvoiceNumber, newCompleteWorkDetailTPVInvoiceAmout, associatedChecklistRuleState, libraryCategoriesId);

                // Store datasets
                Session["serviceInformationTDS"] = serviceInformationTDS;

                Session.Remove("libraryTDSForServices");

                // Update database
                UpdateDatabase();

                ViewState["update"] = "yes";

                // Redirect
                string url = "";
                if (Request.QueryString["source_page"] == "services_navigator2.aspx" || Request.QueryString["source_page"] == "services_add_request.aspx")
                {
                    url = "./services_navigator2.aspx?source_page=services_edit.aspx&service_id=" + hdfServiceId.Value + GetNavigatorState() + "&update=yes";
                }

                if (Request.QueryString["source_page"] == "services_summary.aspx")
                {
                    string activeTab = hdfActiveTab.Value;
                    url = "./services_summary.aspx?source_page=services_edit.aspx&dashboard=" + hdfDashboard.Value + "&service_id=" + hdfServiceId.Value + "&active_tab=" + activeTab + GetNavigatorState() + "&update=yes";
                }

                Response.Redirect(url);
            }
        }



        private void Save2()
        {
            // Costs Gridview, if the gridview is edition mode
            if (grdCosts.EditIndex >= 0)
            {
                grdCosts.UpdateRow(grdCosts.EditIndex, true);
            }

            // Notes Gridview, if the gridview is edition mode
            if (grdNotes.EditIndex >= 0)
            {
                grdNotes.UpdateRow(grdNotes.EditIndex, true);
            }

            // Save cost and notes data
            GrdCostsAdd();
            GrdNotesAdd();

            // Save data
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int serviceId = Int32.Parse(hdfServiceId.Value);

            // Unmodified data
            ServiceInformationBasicInformationGateway serviceInformationBasicInformationGatewayForEdit = new ServiceInformationBasicInformationGateway(serviceInformationTDS);
            string serviceState = serviceInformationBasicInformationGatewayForEdit.GetServiceState(serviceId);
            string associatedChecklistRuleState = serviceInformationBasicInformationGatewayForEdit.GetAssociatedChecklistRuleState(serviceId);

            // ... Get basic service data
            bool newMtoDto = ckbxMtoDto.Checked;
            string newServiceDescription = tbxServiceDescription.Text.Trim();

            // ... Get general service data
            string newMileage = tbxGeneralMileage.Text.Trim();

            // ... Get assigned data
            DateTime? newAssignmentDateTime = null;
            DateTime? newAssignmentDeadlineDate = null;
            bool newToTeamMember = false;
            int? newAssignTeamMemberID = null;
            string newThirdPartyVendor = "";
            DateTime? assignmentAcceptedDateTime = null;
            string newAssignmentRejectedReason = "";
            DateTime? assignmentRejectedDateTime = null;

            if (pnlAssignmentData.Visible)
            {
                if (pnlAssignedToReadOnly.Visible)
                {
                    if (serviceInformationBasicInformationGatewayForEdit.GetAssignmentDateTimeOriginal(serviceId).HasValue) newAssignmentDateTime = (DateTime)serviceInformationBasicInformationGatewayForEdit.GetAssignmentDateTimeOriginal(serviceId);
                    if (serviceInformationBasicInformationGatewayForEdit.GetAssignedDeadlineDate(serviceId).HasValue) newAssignmentDeadlineDate = (DateTime)serviceInformationBasicInformationGatewayForEdit.GetAssignedDeadlineDate(serviceId);
                    newToTeamMember = serviceInformationBasicInformationGatewayForEdit.GetToTeamMember(serviceId);
                    if (newToTeamMember) newAssignTeamMemberID = (int)serviceInformationBasicInformationGatewayForEdit.GetAssignTeamMemberId(serviceId);
                    newThirdPartyVendor = serviceInformationBasicInformationGatewayForEdit.GetAssignedThirdPartyVendor(serviceId);
                }

                if (pnlAssignedTo.Visible)
                {
                    if (serviceInformationBasicInformationGatewayForEdit.GetAssignmentDateTimeOriginal(serviceId).HasValue) newAssignmentDateTime = (DateTime)serviceInformationBasicInformationGatewayForEdit.GetAssignmentDateTimeOriginal(serviceId);
                    if (tkrdpAssignmentDataAssignedDeadlineDate.SelectedDate.HasValue) newAssignmentDeadlineDate = tkrdpAssignmentDataAssignedDeadlineDate.SelectedDate.Value;
                    newToTeamMember = rbtnAssignmentDataToTeamMember.Checked;
                    if (newToTeamMember) newAssignTeamMemberID = Int32.Parse(ddlAssignmentDataAssignToTeamMember.SelectedValue);
                    newThirdPartyVendor = tbxAssignmentDataAssignToThirdPartyVendor.Text.Trim();
                }

                if (serviceInformationBasicInformationGatewayForEdit.GetAcceptedDateTime(serviceId).HasValue) assignmentAcceptedDateTime = (DateTime)serviceInformationBasicInformationGatewayForEdit.GetAcceptedDateTime(serviceId);
                if (serviceInformationBasicInformationGatewayForEdit.GetRejectedDateTime(serviceId).HasValue) assignmentRejectedDateTime = (DateTime)serviceInformationBasicInformationGatewayForEdit.GetRejectedDateTime(serviceId);
                newAssignmentRejectedReason = tbxAssignmentDataRejectedReason.Text.Trim();
            }
            else
            {
                if (pnlAssignmentDataReadOnly.Visible)
                {
                    if (serviceInformationBasicInformationGatewayForEdit.GetAssignmentDateTimeOriginal(serviceId).HasValue) newAssignmentDateTime = (DateTime)serviceInformationBasicInformationGatewayForEdit.GetAssignmentDateTimeOriginal(serviceId);
                    if (serviceInformationBasicInformationGatewayForEdit.GetAssignedDeadlineDate(serviceId).HasValue) newAssignmentDeadlineDate = (DateTime)serviceInformationBasicInformationGatewayForEdit.GetAssignedDeadlineDate(serviceId);
                    newToTeamMember = serviceInformationBasicInformationGatewayForEdit.GetToTeamMember(serviceId);
                    if (newToTeamMember) newAssignTeamMemberID = (int)serviceInformationBasicInformationGatewayForEdit.GetAssignTeamMemberId(serviceId);
                    newThirdPartyVendor = serviceInformationBasicInformationGatewayForEdit.GetAssignedThirdPartyVendor(serviceId);
                    if (serviceInformationBasicInformationGatewayForEdit.GetAcceptedDateTime(serviceId).HasValue) assignmentAcceptedDateTime = (DateTime)serviceInformationBasicInformationGatewayForEdit.GetAcceptedDateTime(serviceId);
                    if (serviceInformationBasicInformationGatewayForEdit.GetRejectedDateTime(serviceId).HasValue) assignmentRejectedDateTime = (DateTime)serviceInformationBasicInformationGatewayForEdit.GetRejectedDateTime(serviceId);
                    newAssignmentRejectedReason = tbxAssignmentDataRejectedReasonReadOnly.Text.Trim();
                }
            }

            // ... Get start work data
            DateTime? startWorkDateTime = null; if (serviceInformationBasicInformationGatewayForEdit.GetStartWorkDateTime(serviceId).HasValue) startWorkDateTime = (DateTime)serviceInformationBasicInformationGatewayForEdit.GetStartWorkDateTime(serviceId);
            DateTime? newUnitOutOfServiceDate = null;
            string newUnitOutOfServiceTime = "";
            string newStartWorkMileage = "";

            if (pnlStartWorkData.Visible)
            {
                if (tkrdpStartWorkDataUnitOutOfServiceDate.SelectedDate.HasValue) newUnitOutOfServiceDate = tkrdpStartWorkDataUnitOutOfServiceDate.SelectedDate.Value;
                newUnitOutOfServiceTime = "8:00 AM";
                newStartWorkMileage = tbxStartWorkDataStartMileage.Text.Trim();
            }
            else
            {
                if (pnlStartWorkDataReadOnly.Visible)
                {
                    newUnitOutOfServiceDate = serviceInformationBasicInformationGatewayForEdit.GetUnitOutOfServiceDate(serviceId);
                    newUnitOutOfServiceTime = serviceInformationBasicInformationGatewayForEdit.GetUnitOutOfServiceTime(serviceId);
                    newStartWorkMileage = serviceInformationBasicInformationGatewayForEdit.GetMileage(serviceId);
                }
            }

            // ... Get complete work data
            DateTime? completeWorkDateTime = null; if (serviceInformationBasicInformationGatewayForEdit.GetCompleteWorkDateTime(serviceId).HasValue) completeWorkDateTime = (DateTime)serviceInformationBasicInformationGatewayForEdit.GetCompleteWorkDateTime(serviceId);
            DateTime? newUnitBackInServiceDate = null; if (tkrdpCompleteWorkDataUnitBackInServiceDate.SelectedDate.HasValue) newUnitBackInServiceDate = tkrdpCompleteWorkDataUnitBackInServiceDate.SelectedDate.Value;
            string newUnitBackInServiceTime = "8:00 AM";
            string newCompleteWorkMileage = tbxCompleteWorkDataCompleteMileage.Text.Trim();
            string newCompleteWorkDetailDescription = "";
            bool newCompleteWorkDetailPreventable = false;

            // ... ... From team member               
            if (pnlTeamMemberAssigned.Visible)
            {
                if (tbxCompleteWorkDataDescription.Text.Trim() != "") newCompleteWorkDetailDescription = tbxCompleteWorkDataDescription.Text.Trim();
                newCompleteWorkDetailPreventable = ckbxCompleteWorkDataPreventable.Checked;
            }
            decimal? newCompleteWorkDetailTMLabourHours = null; if (tbxCompleteWorkDataLabourHours.Text.Trim() != "") newCompleteWorkDetailTMLabourHours = decimal.Parse(tbxCompleteWorkDataLabourHours.Text.Trim());

            // ... ... From Third party vendor
            if (pnlThirdPartyVendorAssigned.Visible)
            {
                if (tbxCompleteWorkDataDescriptionThirdPartyVendor.Text.Trim() != "") newCompleteWorkDetailDescription = tbxCompleteWorkDataDescriptionThirdPartyVendor.Text.Trim();
                newCompleteWorkDetailPreventable = ckbxCompleteWorkDataPreventableThirdPartyVendor.Checked;
            }
            string newCompleteWorkDetailTPVInvoiceNumber = tbxCompleteWorkDataInvoiceNumberThirdPartyVendor.Text.Trim();
            decimal? newCompleteWorkDetailTPVInvoiceAmout = null; if (tbxCompleteWorkDataInvoiceAmountThirdPartyVendor.Text.Trim() != "") newCompleteWorkDetailTPVInvoiceAmout = decimal.Parse(tbxCompleteWorkDataInvoiceAmountThirdPartyVendor.Text.Trim());

            // Update service data
            ServiceInformationBasicInformation serviceInformationBasicInformation = new ServiceInformationBasicInformation(serviceInformationTDS);
            int? libraryCategoriesId = null; if (serviceInformationBasicInformationGatewayForEdit.GetLibraryCategoriesId(int.Parse(hdfServiceId.Value)).HasValue) libraryCategoriesId = (int)serviceInformationBasicInformationGatewayForEdit.GetLibraryCategoriesId(int.Parse(hdfServiceId.Value));
            serviceInformationBasicInformation.Update(serviceId, serviceState, newMtoDto, newServiceDescription, newMileage, newAssignmentDateTime, newAssignmentDeadlineDate, newToTeamMember, newAssignTeamMemberID, newThirdPartyVendor, assignmentAcceptedDateTime, assignmentRejectedDateTime, newAssignmentRejectedReason, startWorkDateTime, newUnitOutOfServiceDate, newUnitOutOfServiceTime, newStartWorkMileage, completeWorkDateTime, newUnitBackInServiceDate, newUnitBackInServiceTime, newCompleteWorkMileage, newCompleteWorkDetailDescription, newCompleteWorkDetailPreventable, newCompleteWorkDetailTMLabourHours, newCompleteWorkDetailTPVInvoiceNumber, newCompleteWorkDetailTPVInvoiceAmout, associatedChecklistRuleState, libraryCategoriesId);

            // Store datasets
            Session["serviceInformationTDS"] = serviceInformationTDS;

            ViewState["update"] = "no";
        }

                      

        private void Apply()
        {
            // Validate data
            bool validData = true;

            validData = ValidatePage();

            if (validData)
            {
                // Costs Gridview, if the gridview is edition mode
                if (grdCosts.EditIndex >= 0)
                {
                    grdCosts.UpdateRow(grdCosts.EditIndex, true);
                }

                // Notes Gridview, if the gridview is edition mode
                if (grdNotes.EditIndex >= 0)
                {
                    grdNotes.UpdateRow(grdNotes.EditIndex, true);
                }

                // Save cost and notes data
                GrdCostsAdd();
                GrdNotesAdd();

                // Save data
                int companyId = Int32.Parse(hdfCompanyId.Value);
                int serviceId = Int32.Parse(hdfServiceId.Value);

                // Unmodified data
                ServiceInformationBasicInformationGateway serviceInformationBasicInformationGatewayForEdit = new ServiceInformationBasicInformationGateway(serviceInformationTDS);
                string serviceState = serviceInformationBasicInformationGatewayForEdit.GetServiceState(serviceId);
                string associatedChecklistRuleState = serviceInformationBasicInformationGatewayForEdit.GetAssociatedChecklistRuleState(serviceId);

                // ... Get basic service data
                bool newMtoDto = ckbxMtoDto.Checked;
                string newServiceDescription = tbxServiceDescription.Text.Trim();

                // ... Get general service data
                string newMileage = tbxGeneralMileage.Text.Trim();

                // ... Get assigned data
                DateTime? newAssignmentDateTime = null;
                DateTime? newAssignmentDeadlineDate = null;
                bool newToTeamMember = false;
                int? newAssignTeamMemberID = null;
                string newThirdPartyVendor = "";
                DateTime? assignmentAcceptedDateTime = null;
                string newAssignmentRejectedReason = "";
                DateTime? assignmentRejectedDateTime = null; 

                if (pnlAssignmentData.Visible)
                {
                    if (pnlAssignedToReadOnly.Visible)
                    {
                        if (serviceInformationBasicInformationGatewayForEdit.GetAssignmentDateTimeOriginal(serviceId).HasValue) newAssignmentDateTime = (DateTime)serviceInformationBasicInformationGatewayForEdit.GetAssignmentDateTimeOriginal(serviceId);
                        if (serviceInformationBasicInformationGatewayForEdit.GetAssignedDeadlineDate(serviceId).HasValue) newAssignmentDeadlineDate = (DateTime)serviceInformationBasicInformationGatewayForEdit.GetAssignedDeadlineDate(serviceId);
                        newToTeamMember = serviceInformationBasicInformationGatewayForEdit.GetToTeamMember(serviceId);
                        if (newToTeamMember) newAssignTeamMemberID = (int)serviceInformationBasicInformationGatewayForEdit.GetAssignTeamMemberId(serviceId);
                        newThirdPartyVendor = serviceInformationBasicInformationGatewayForEdit.GetAssignedThirdPartyVendor(serviceId);
                    }

                    if (pnlAssignedTo.Visible)
                    {
                        if (serviceInformationBasicInformationGatewayForEdit.GetAssignmentDateTimeOriginal(serviceId).HasValue) newAssignmentDateTime = (DateTime)serviceInformationBasicInformationGatewayForEdit.GetAssignmentDateTimeOriginal(serviceId);
                        if (tkrdpAssignmentDataAssignedDeadlineDate.SelectedDate.HasValue) newAssignmentDeadlineDate = tkrdpAssignmentDataAssignedDeadlineDate.SelectedDate.Value;
                        newToTeamMember = rbtnAssignmentDataToTeamMember.Checked;
                        if (newToTeamMember) newAssignTeamMemberID = Int32.Parse(ddlAssignmentDataAssignToTeamMember.SelectedValue);
                        newThirdPartyVendor = tbxAssignmentDataAssignToThirdPartyVendor.Text.Trim();
                    }

                    if (serviceInformationBasicInformationGatewayForEdit.GetAcceptedDateTime(serviceId).HasValue) assignmentAcceptedDateTime = (DateTime)serviceInformationBasicInformationGatewayForEdit.GetAcceptedDateTime(serviceId);
                    if (serviceInformationBasicInformationGatewayForEdit.GetRejectedDateTime(serviceId).HasValue) assignmentRejectedDateTime = (DateTime)serviceInformationBasicInformationGatewayForEdit.GetRejectedDateTime(serviceId);
                    newAssignmentRejectedReason = tbxAssignmentDataRejectedReason.Text.Trim();
                }
                else
                {
                    if (pnlAssignmentDataReadOnly.Visible)
                    {
                        if (serviceInformationBasicInformationGatewayForEdit.GetAssignmentDateTimeOriginal(serviceId).HasValue) newAssignmentDateTime = (DateTime)serviceInformationBasicInformationGatewayForEdit.GetAssignmentDateTimeOriginal(serviceId);
                        if (serviceInformationBasicInformationGatewayForEdit.GetAssignedDeadlineDate(serviceId).HasValue) newAssignmentDeadlineDate = (DateTime)serviceInformationBasicInformationGatewayForEdit.GetAssignedDeadlineDate(serviceId);
                        newToTeamMember = serviceInformationBasicInformationGatewayForEdit.GetToTeamMember(serviceId);
                        if (newToTeamMember) newAssignTeamMemberID = (int)serviceInformationBasicInformationGatewayForEdit.GetAssignTeamMemberId(serviceId);
                        newThirdPartyVendor = serviceInformationBasicInformationGatewayForEdit.GetAssignedThirdPartyVendor(serviceId);
                        if (serviceInformationBasicInformationGatewayForEdit.GetAcceptedDateTime(serviceId).HasValue) assignmentAcceptedDateTime = (DateTime)serviceInformationBasicInformationGatewayForEdit.GetAcceptedDateTime(serviceId);
                        if (serviceInformationBasicInformationGatewayForEdit.GetRejectedDateTime(serviceId).HasValue) assignmentRejectedDateTime = (DateTime)serviceInformationBasicInformationGatewayForEdit.GetRejectedDateTime(serviceId);
                        newAssignmentRejectedReason = tbxAssignmentDataRejectedReasonReadOnly.Text.Trim();
                    }
                }

                // ... Get start work data
                DateTime? startWorkDateTime = null; if (serviceInformationBasicInformationGatewayForEdit.GetStartWorkDateTime(serviceId).HasValue) startWorkDateTime = (DateTime)serviceInformationBasicInformationGatewayForEdit.GetStartWorkDateTime(serviceId);
                DateTime? newUnitOutOfServiceDate = null;
                string newUnitOutOfServiceTime = "";
                string newStartWorkMileage = "";

                if (pnlStartWorkData.Visible)
                {
                    if (tkrdpStartWorkDataUnitOutOfServiceDate.SelectedDate.HasValue) newUnitOutOfServiceDate = tkrdpStartWorkDataUnitOutOfServiceDate.SelectedDate.Value;
                    newUnitOutOfServiceTime = "8:00 AM";
                    newStartWorkMileage = tbxStartWorkDataStartMileage.Text.Trim();
                }
                else
                {
                    if (pnlStartWorkDataReadOnly.Visible)
                    {
                        newUnitOutOfServiceDate = serviceInformationBasicInformationGatewayForEdit.GetUnitOutOfServiceDate(serviceId);
                        newUnitOutOfServiceTime = serviceInformationBasicInformationGatewayForEdit.GetUnitOutOfServiceTime(serviceId);
                        newStartWorkMileage = serviceInformationBasicInformationGatewayForEdit.GetMileage(serviceId);
                    }
                }

                // ... Get complete work data
                DateTime? completeWorkDateTime = null; if (serviceInformationBasicInformationGatewayForEdit.GetCompleteWorkDateTime(serviceId).HasValue) completeWorkDateTime = (DateTime)serviceInformationBasicInformationGatewayForEdit.GetCompleteWorkDateTime(serviceId);
                DateTime? newUnitBackInServiceDate = null; if (tkrdpCompleteWorkDataUnitBackInServiceDate.SelectedDate.HasValue) newUnitBackInServiceDate = tkrdpCompleteWorkDataUnitBackInServiceDate.SelectedDate.Value;
                string newUnitBackInServiceTime = "8:00 AM";
                string newCompleteWorkMileage = tbxCompleteWorkDataCompleteMileage.Text.Trim();
                string newCompleteWorkDetailDescription = "";
                bool newCompleteWorkDetailPreventable = false;

                // ... ... From team member               
                if (pnlTeamMemberAssigned.Visible)
                {
                    if (tbxCompleteWorkDataDescription.Text.Trim() != "") newCompleteWorkDetailDescription = tbxCompleteWorkDataDescription.Text.Trim();
                    newCompleteWorkDetailPreventable = ckbxCompleteWorkDataPreventable.Checked;
                }
                decimal? newCompleteWorkDetailTMLabourHours = null; if (tbxCompleteWorkDataLabourHours.Text.Trim() != "") newCompleteWorkDetailTMLabourHours = decimal.Parse(tbxCompleteWorkDataLabourHours.Text.Trim());

                // ... ... From Third party vendor
                if (pnlThirdPartyVendorAssigned.Visible)
                {
                    if (tbxCompleteWorkDataDescriptionThirdPartyVendor.Text.Trim() != "") newCompleteWorkDetailDescription = tbxCompleteWorkDataDescriptionThirdPartyVendor.Text.Trim();
                    newCompleteWorkDetailPreventable = ckbxCompleteWorkDataPreventableThirdPartyVendor.Checked;
                }
                string newCompleteWorkDetailTPVInvoiceNumber = tbxCompleteWorkDataInvoiceNumberThirdPartyVendor.Text.Trim();
                decimal? newCompleteWorkDetailTPVInvoiceAmout = null; if (tbxCompleteWorkDataInvoiceAmountThirdPartyVendor.Text.Trim() != "") newCompleteWorkDetailTPVInvoiceAmout = decimal.Parse(tbxCompleteWorkDataInvoiceAmountThirdPartyVendor.Text.Trim());

                // Update service data
                ServiceInformationBasicInformation serviceInformationBasicInformation = new ServiceInformationBasicInformation(serviceInformationTDS);
                int? libraryCategoriesId = null; if (serviceInformationBasicInformationGatewayForEdit.GetLibraryCategoriesId(int.Parse(hdfServiceId.Value)).HasValue) libraryCategoriesId = (int)serviceInformationBasicInformationGatewayForEdit.GetLibraryCategoriesId(int.Parse(hdfServiceId.Value));
                serviceInformationBasicInformation.Update(serviceId, serviceState, newMtoDto, newServiceDescription, newMileage, newAssignmentDateTime, newAssignmentDeadlineDate, newToTeamMember, newAssignTeamMemberID, newThirdPartyVendor, assignmentAcceptedDateTime, assignmentRejectedDateTime, newAssignmentRejectedReason, startWorkDateTime, newUnitOutOfServiceDate, newUnitOutOfServiceTime, newStartWorkMileage, completeWorkDateTime, newUnitBackInServiceDate, newUnitBackInServiceTime, newCompleteWorkMileage, newCompleteWorkDetailDescription, newCompleteWorkDetailPreventable, newCompleteWorkDetailTMLabourHours, newCompleteWorkDetailTPVInvoiceNumber, newCompleteWorkDetailTPVInvoiceAmout, associatedChecklistRuleState, libraryCategoriesId);

                // Store datasets
                Session["serviceInformationTDS"] = serviceInformationTDS;
                
                // Update database
                UpdateDatabase();

                ViewState["update"] = "yes";
            }
        }



        private void GrdCostsAdd()
        {
            if (ValidateCostsFooter())
            {
                Page.Validate("costsDataAdd");
                if (Page.IsValid)
                {
                    int serviceId = Int32.Parse(hdfServiceId.Value);
                    int companyId = Int32.Parse(hdfCompanyId.Value);
                    string newPartNumber = ((TextBox)grdCosts.FooterRow.FindControl("tbxPartNumberNew")).Text.Trim();
                    string newPartName = ((TextBox)grdCosts.FooterRow.FindControl("tbxPartNameNew")).Text.Trim();
                    string newVendor = ((TextBox)grdCosts.FooterRow.FindControl("tbxVendorNew")).Text.Trim();
                    decimal newCost = Decimal.Round(Decimal.Parse(((TextBox)grdCosts.FooterRow.FindControl("tbxCostNew")).Text.Trim()),2);
                    bool inServiceCostDatabase = false;

                    ServiceInformationServiceCost model = new ServiceInformationServiceCost(serviceInformationTDS);

                    model.Insert(serviceId, newPartNumber, newPartName, newVendor, newCost, false, companyId, inServiceCostDatabase, null);//TODO
                  
                    Session.Remove("serviceCostsDummy");
                    Session["serviceInformationTDS"] = serviceInformationTDS;

                    // Calc TotalCost
                    tbxTotalCost.Text = Decimal.Round(model.GetTotalCost(serviceId, companyId), 2).ToString();

                    grdCosts.DataBind();
                    grdCosts.PageIndex = grdCosts.PageCount - 1;
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
                    int serviceId = Int32.Parse(hdfServiceId.Value);
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

                    Session.Remove("serviceNotesDummy");
                    Session["serviceInformationTDS"] = serviceInformationTDS;
                    
                    grdNotes.DataBind();
                    grdNotes.PageIndex = grdNotes.PageCount - 1;
                }
            }
        }



        private void GrdNotesAddFromCost(string subject, string note)
        {
            int serviceId = Int32.Parse(hdfServiceId.Value);
            int companyId = Int32.Parse(hdfCompanyId.Value);
            string newSubject = subject;
            int loginId = Convert.ToInt32(Session["loginID"]);
            DateTime dateTime_ = DateTime.Now;
            string newNote = note;
            bool inServiceNoteDatabase = false;
            int? libraryFilesId = null;

            ServiceInformationServiceNote model = new ServiceInformationServiceNote(serviceInformationTDS);
            model.Insert(serviceId, newSubject, loginId, dateTime_, newNote, libraryFilesId, false, companyId, inServiceNoteDatabase);

            Session.Remove("serviceNotesDummy");
            Session["serviceInformationTDS"] = serviceInformationTDS;
            
            grdNotes.DataBind();
            grdNotes.PageIndex = grdNotes.PageCount - 1;
        }



        private void GrdNotesDeleteAttachment(int libraryFileId, int refId)
        {
            // Button delete functionality
            if (libraryFileId != 0)
            {
                ServiceInformationServiceNote model = new ServiceInformationServiceNote(serviceInformationTDS);
                model.UpdateLibraryFilesId(int.Parse(hdfServiceId.Value), refId, null, "", "");

                LibraryFilesGateway libraryFilesGateway = new LibraryFilesGateway(libraryTDSForServices);
                libraryFilesGateway.DeleteByLibraryFilesId(libraryFileId);

                ViewState["update"] = "no";

                Session["serviceInformationTDS"] = serviceInformationTDS;
                Session["libraryTDSForServices"] = libraryTDSForServices;
                grdNotes.DataBind();
                grdCosts.DataBind();
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
            Save2();

            // Escape single quote
            subject = subject.Replace("'", "%27");

            if (refId.HasValue)
            {
                if (ViewState["libraryCategoriesId"] != null)                
                {
                    
                    string script = "<script language='javascript'>";
                    string url = "./services_add_attachment.aspx?source_page=services_edit.aspx&subject=" + Server.UrlEncode(subject) + "&refId=" + refId.ToString() + "&service_id=" + hdfServiceId.Value + "&library_categories_id=" + Int32.Parse(ViewState["libraryCategoriesId"].ToString());
                    script = script + string.Format("window.open('{0}', '_blank', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=510, height=270')", url);
                    script = script + "</script>";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Notes", script, false);
                }
            }
            else
            {
                ServiceInformationServiceNote model = new ServiceInformationServiceNote(serviceInformationTDS);
                refId = model.GetLastRefId();

                if (ViewState["libraryCategoriesId"] != null)
                {
                    string script = "<script language='javascript'>";
                    string url = "./services_add_attachment.aspx?source_page=services_edit.aspx&subject=" + Server.UrlEncode(subject) + "&refId=" + refId.ToString() + "&service_id=" + hdfServiceId.Value + "&library_categories_id=" + Int32.Parse(ViewState["libraryCategoriesId"].ToString());
                    script = script + string.Format("window.open('{0}', '_blank', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=510, height=270')", url);
                    script = script + "</script>";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Notes", script, false);
                }
            }
        }



        private void GrdCostsAddAttachment(int? refIdCost, string subject)
        {
            Save2();

            GrdNotesAddFromCost(subject, subject);

            ServiceInformationServiceNote model = new ServiceInformationServiceNote(serviceInformationTDS);
            ServiceInformationServiceCost modelCost = new ServiceInformationServiceCost(serviceInformationTDS);

            int refId = model.GetLastRefId();

            if (!refIdCost.HasValue)
            {                
                refIdCost = modelCost.GetLastRefId();
            }

            modelCost.UpdateNoteId(Int32.Parse(hdfServiceId.Value), refIdCost.Value, refId);
            
            if (ViewState["libraryCategoriesId"] != null)
            {
                // Escape single quote
                subject = subject.Replace("'", "%27");

                string script = "<script language='javascript'>";
                string url = "./services_add_attachment.aspx?source_page=services_edit.aspx&subject=" + Server.UrlEncode(subject) + "&refId=" + refId.ToString() + "&refIdCost=" + refIdCost.Value.ToString() + "&service_id=" + hdfServiceId.Value + "&library_categories_id=" + Int32.Parse(ViewState["libraryCategoriesId"].ToString());
                script = script + string.Format("window.open('{0}', '_blank', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=510, height=270')", url);
                script = script + "</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Notes", script, false);
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



        private bool ValidateNotesFooter()
        {
            string subject = ((TextBox)grdNotes.FooterRow.FindControl("tbxNoteSubjectNew")).Text.Trim();
            string note = ((TextBox)grdNotes.FooterRow.FindControl("tbxNoteNoteNew")).Text.Trim();                    

            if ((subject != "") || (note != "") )
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
                ServiceInformationTDS.CostInformationDataTable dt = new ServiceInformationTDS.CostInformationDataTable();
                dt.AddCostInformationRow(-1, -1, "", "", "", -1, false, companyId, false, 0, 0, "", "");
                Session["serviceCostsDummy"] = dt;

                grdCosts.DataBind();
            }

            // Normally executes at all postbacks
            if (grdCosts.Rows.Count == 1)
            {
                ServiceInformationTDS.CostInformationDataTable dt = (ServiceInformationTDS.CostInformationDataTable)Session["serviceCostsDummy"];
                if (dt != null)
                {
                    grdCosts.Rows[0].Visible = false;
                    grdCosts.Rows[0].Controls.Clear();
                }
            }
        }



        protected void AddCostsReadOnlyNewEmptyFix(GridView grdViewReadOnly)
        {
            if (grdViewReadOnly.Rows.Count == 0)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                ServiceInformationTDS.CostInformationDataTable dt = new ServiceInformationTDS.CostInformationDataTable();
                dt.AddCostInformationRow(-1, -1, "", "", "", -1, false, companyId, false, 0, 0, "", "");
                Session["serviceCostsDummy"] = dt;

                grdViewReadOnly.DataBind();
            }

            // Normally executes at all postbacks
            if (grdViewReadOnly.Rows.Count == 1)
            {
                ServiceInformationTDS.CostInformationDataTable dt = (ServiceInformationTDS.CostInformationDataTable)Session["serviceCostsDummy"];
                if (dt != null)
                {
                    grdViewReadOnly.Rows[0].Visible = false;
                    grdViewReadOnly.Rows[0].Controls.Clear();
                }
            }
        }



        protected void AddNotesNewEmptyFix(GridView grdView)
        {
            if (grdNotes.Rows.Count == 0)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                ServiceInformationTDS.NoteInformationDataTable dt = new ServiceInformationTDS.NoteInformationDataTable();
                dt.AddNoteInformationRow(-1, -1, "", -1, DateTime.Now, "", 0, "", "", false, companyId, false);
                Session["serviceNotesDummy"] = dt;

                grdNotes.DataBind();
            }

            // Normally executes at all postbacks
            if (grdNotes.Rows.Count == 1)
            {
                ServiceInformationTDS.NoteInformationDataTable dt = (ServiceInformationTDS.NoteInformationDataTable)Session["serviceNotesDummy"];
                if (dt != null)
                {
                    grdNotes.Rows[0].Visible = false;
                    grdNotes.Rows[0].Controls.Clear();
                }
            }
        }



        private bool ValidatePage()
        {
            bool validData = true;

            // Validate general data
            Page.Validate("serviceData");

            if (Page.IsValid)
            {
                // ... Validate complete tab
                if (ValidateCostsFooter())
                {
                    Page.Validate("costsDataAdd");

                    if (!Page.IsValid)
                    {
                        validData = false;
                    }
                }

                Page.Validate("costsDataEdit");

                if (!Page.IsValid)
                {
                    validData = false;
                }

                // ... Validate notes tab
                if (ValidateNotesFooter())
                {
                    Page.Validate("notesDataAdd");

                    if (!Page.IsValid)
                    {
                        validData = false;
                    }
                }

                Page.Validate("notesDataEdit");

                if (!Page.IsValid)
                {
                    validData = false;
                }

                // ... Validate assign  tab
                string state = hdfServiceState.Value;

                if (state == "Assigned")
                {
                    Page.Validate("assignmentInformation");

                    if (!Page.IsValid)
                    {
                        validData = false;
                    }
                }
            }
            else
            {
                validData = false;
            }

            // Show error message
            if (validData)
            {
                // If it's valid
                lblMissingData.Visible = false;
            }
            else
            {
                // If it's not valid
                lblMissingData.Visible = true;
                string errorText = "Invalid or missing data. Please check";
                if (!rfvServiceDescription.IsValid)
                {
                    hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Service Description";
                }
                if (!cvCompleteWorkDataLabourHours.IsValid)
                {
                    hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Labour Hours (Complete Work)";
                }
                if (!cvCompleteWorkDataInvoiceAmount.IsValid)
                {
                    hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Invoice Amount (Complete Work)";
                }

                lblMissingData.Text = errorText + hdfErrorFieldList.Value.ToString();
            }

            return validData;
        }



        private void UpdateDatabase()
        {
            int companyId = Int32.Parse(hdfCompanyId.Value);

            LibraryFilesGateway libraryFilesGateway = new LibraryFilesGateway(libraryTDSForServices);
            libraryFilesGateway.Update();

            DB.Open();
            DB.BeginTransaction();
            try
            {
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

                // Save costs information
                ServiceInformationServiceCost serviceInformationServiceCost = new ServiceInformationServiceCost(serviceInformationTDS);
                serviceInformationServiceCost.Save(companyId);

                // Save notes information                
                serviceInformationServiceNote.Save(companyId);

                // Save service information 
                ServiceInformationBasicInformation serviceInformationBasicInformation = new ServiceInformationBasicInformation(serviceInformationTDS);
                serviceInformationBasicInformation.Save(companyId);

                DB.CommitTransaction();

                // Store datasets
                libraryTDSForServices.AcceptChanges();
                serviceInformationTDS.AcceptChanges();
                Session["serviceInformationTDS"] = serviceInformationTDS;
                Session["libraryTDSForServices"] = libraryTDSForServices;
            }
            catch (Exception ex)
            {
                DB.RollbackTransaction();

                string url = string.Format("./../../error_page.aspx?error={0}", ex.Message.Replace('\n', ' '));
                Response.Redirect(url);
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

        
        
    }
}
