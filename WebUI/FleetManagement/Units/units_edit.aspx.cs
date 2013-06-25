using System;
using System.Collections;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.BL.Company.Organization;
using LiquiForce.LFSLive.BL.FleetManagement.Categories;
using LiquiForce.LFSLive.BL.FleetManagement.Common;
using LiquiForce.LFSLive.BL.FleetManagement.CompanyLevels;
using LiquiForce.LFSLive.BL.FleetManagement.Units;
using LiquiForce.LFSLive.DA.Company.Organization;
using LiquiForce.LFSLive.DA.FleetManagement.Categories;
using LiquiForce.LFSLive.DA.FleetManagement.CompanyLevels;
using LiquiForce.LFSLive.DA.FleetManagement.Units;
using LiquiForce.LFSLive.DA.RAF;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.Tools;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.FleetManagement.Units
{
    /// <summary>
    /// units_edit
    /// </summary>
    public partial class units_edit : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected UnitInformationTDS unitInformationTDS;
        protected UnitInformationTDS.ChecklistDetailsDataTable unitsChecklistRulesTemp;
        protected UnitInformationTDS.ServiceDetailsDataTable unitsServicesTemp;
        protected UnitInformationTDS.InspectionDetailsDataTable unitsInspectionsTemp;
        protected UnitInformationTDS.NoteInformationDataTable unitsNotesTemp; 
        protected CategoriesTDS categoriesTDS;
        protected CompanyLevelsTDS companyLevelsTDS;
        protected ArrayList arrayCategoriesSelectedForEdit;
        protected ArrayList arrayCompanyLevelsSelectedForEdit;
        protected UnitInformationTDS.CostInformationDataTable unitInformationCosts;
        protected UnitInformationTDS.CostExceptionsInformationDataTable unitInformationCostsExceptions;
        protected LibraryTDS libraryTDSForUnits;






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
                if (!(Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_UNITS_VIEW"]) && (Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_UNITS_EDIT"]) || Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_UNITS_COMMENTS"]))))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["unit_id"] == null) || ((string)Request.QueryString["unit_type"] == null) || ((string)Request.QueryString["unit_state"] == null) || ((string)Request.QueryString["active_tab"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in units_edit.aspx");
                }

                // Tag Page
                hdfUnitId.Value = Request.QueryString["unit_id"].ToString();
                hdfUnitType.Value = Request.QueryString["unit_type"].ToString();
                hdfUnitState.Value = Request.QueryString["unit_state"].ToString();
                hdfActiveTab.Value = Request.QueryString["active_tab"].ToString();
                hdfCompanyId.Value = Session["companyID"].ToString();                
                hdfLoginId.Value = Convert.ToInt32(Session["loginID"]).ToString();
                
                int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
                int unitId = Int32.Parse(hdfUnitId.Value.Trim());

                aceManufacturer.ContextKey = hdfCompanyId.Value;

                // ... For Owner country
                CountryList countryList = new CountryList();
                countryList.LoadAndAddItem(-1, "(Select a country)");
                ddlOwnerCountry.DataSource = countryList.Table;
                ddlOwnerCountry.DataValueField = "CountryID";
                ddlOwnerCountry.DataTextField = "Name";
                ddlOwnerCountry.DataBind();

                // ... For License country
                ddlLicenseCountry.DataSource = countryList.Table;
                ddlLicenseCountry.DataValueField = "CountryID";
                ddlLicenseCountry.DataTextField = "Name";
                ddlLicenseCountry.DataBind();

                Session.Remove("unitsChecklistRulesTempDummy");
                Session.Remove("unitsServicesTempDummy");
                Session.Remove("unitsInspectionsTempDummy");
                Session.Remove("unitsNotesTempDummy");
                Session.Remove("unitCostsDummy");
                Session.Remove("unitCostsExceptionsDummy");
                Session.Remove("costIdSelected");
                
                // ... units_navigator2.aspx
                if (Request.QueryString["source_page"] == "units_navigator2.aspx")
                {
                    StoreNavigatorState();
                    ViewState["update"] = "no";                    

                    // ... Set initial tab
                    if ((string)Session["dialogOpenedUnits"] != "1")
                    {
                        hdfActiveTab.Value = Request.QueryString["active_tab"];

                        unitInformationTDS = new UnitInformationTDS();
                        unitsChecklistRulesTemp = new UnitInformationTDS.ChecklistDetailsDataTable();
                        unitsServicesTemp = new UnitInformationTDS.ServiceDetailsDataTable();
                        unitsInspectionsTemp = new UnitInformationTDS.InspectionDetailsDataTable();
                        unitsNotesTemp = new UnitInformationTDS.NoteInformationDataTable();

                        UnitInformationUnitDetails unitInformationUnitDetails = new UnitInformationUnitDetails(unitInformationTDS);
                        unitInformationUnitDetails.LoadByUnitId(unitId, companyId);

                        UnitInformationInspectionDetails unitInformationInspectionDetailsForEdit = new UnitInformationInspectionDetails(unitInformationTDS);
                        unitInformationInspectionDetailsForEdit.LoadByUnitId(unitId, companyId);

                        UnitInformationNoteDetails unitInformationNoteDetailsForEdit = new UnitInformationNoteDetails(unitInformationTDS);
                        unitInformationNoteDetailsForEdit.LoadByUnitId(unitId, companyId);

                        UnitInformationCostInformation unitInformationCostInformation = new UnitInformationCostInformation(unitInformationTDS);
                        unitInformationCostInformation.LoadAllByUnitId(unitId, companyId);

                        UnitInformationCostExceptionsInformation unitInformationCostExceptionsInformation = new UnitInformationCostExceptionsInformation(unitInformationTDS);
                        unitInformationCostExceptionsInformation.LoadAllByUnitId(unitId, companyId);                       
                                                
                        // ... For Categories
                        categoriesTDS = new CategoriesTDS();
                        Category category = new Category(categoriesTDS);
                        category.LoadByUnitType(hdfUnitType.Value, int.Parse(hdfCompanyId.Value));

                        // .. For Company Levels
                        companyLevelsTDS = new CompanyLevelsTDS();
                        CompanyLevel companyLevel = new CompanyLevel(companyLevelsTDS);
                        companyLevel.Load(int.Parse(hdfCompanyId.Value));
                    }
                    else
                    {
                        hdfActiveTab.Value = (string)Session["activeTabUnits"];

                        // Restore datasets
                        unitInformationTDS = (UnitInformationTDS)Session["unitInformationTDS"];
                        unitsChecklistRulesTemp = (UnitInformationTDS.ChecklistDetailsDataTable)Session["unitsChecklistRulesTemp"];
                        unitsServicesTemp = (UnitInformationTDS.ServiceDetailsDataTable)Session["unitsServicesTemp"];
                        unitsInspectionsTemp = (UnitInformationTDS.InspectionDetailsDataTable)Session["unitsInspectionsTemp"];
                        unitsNotesTemp = (UnitInformationTDS.NoteInformationDataTable)Session["unitsNotesTemp"];
                        categoriesTDS = (CategoriesTDS)Session["categoriesTDSForUnits"];
                        companyLevelsTDS = (CompanyLevelsTDS)Session["companyLevelsTDS"];
                    }

                    arrayCategoriesSelectedForEdit = new ArrayList();
                    arrayCompanyLevelsSelectedForEdit = new ArrayList();
                    Session["arrayCategoriesSelectedForEdit"] = arrayCategoriesSelectedForEdit;
                    Session["arrayCompanyLevelsSelectedForEdit"] = arrayCompanyLevelsSelectedForEdit;

                    // Store dataset
                    Session["unitInformationTDS"] = unitInformationTDS;
                    Session["unitsChecklistRulesTemp"] = unitsChecklistRulesTemp;
                    Session["unitsServicesTemp"] = unitsServicesTemp;
                    Session["unitsInspectionsTemp"] = unitsInspectionsTemp;
                    Session["unitsNotesTemp"] = unitsNotesTemp;
                    Session["categoriesTDSForUnits"] = categoriesTDS;
                    Session["companyLevelsTDS"] = companyLevelsTDS;
                }

                // ... units_summary.aspx or units_edit.aspx
                if ((Request.QueryString["source_page"] == "units_summary.aspx") || (Request.QueryString["source_page"] == "units_edit.aspx"))
                {
                    StoreNavigatorState();
                    ViewState["update"] = Request.QueryString["update"];

                    // Restore dataset
                    unitInformationTDS = (UnitInformationTDS)Session["unitInformationTDS"];
                    unitsChecklistRulesTemp = (UnitInformationTDS.ChecklistDetailsDataTable)Session["unitsChecklistRulesTemp"];
                    unitsServicesTemp = (UnitInformationTDS.ServiceDetailsDataTable)Session["unitsServicesTemp"];
                    unitsInspectionsTemp = (UnitInformationTDS.InspectionDetailsDataTable)Session["unitsInspectionsTemp"];
                    unitsNotesTemp = (UnitInformationTDS.NoteInformationDataTable)Session["unitsNotesTemp"];
                    categoriesTDS = (CategoriesTDS)Session["categoriesTDSForUnits"];
                    companyLevelsTDS = (CompanyLevelsTDS)Session["companyLevelsTDS"];

                    // ... Set initial tab
                    if ((string)Session["dialogOpenedUnits"] != "1")
                    {
                        hdfActiveTab.Value = Request.QueryString["active_tab"];

                        if (ViewState["update"].ToString().Trim() == "yes")
                        {
                            UnitInformationUnitDetails unitInformationUnitDetails = new UnitInformationUnitDetails(unitInformationTDS);
                            unitInformationUnitDetails.LoadByUnitId(unitId, companyId);

                            UnitInformationInspectionDetails unitInformationInspectionDetailsForEdit = new UnitInformationInspectionDetails(unitInformationTDS);
                            unitInformationInspectionDetailsForEdit.LoadByUnitId(unitId, companyId);

                            UnitInformationNoteDetails unitInformationNoteDetailsForEdit = new UnitInformationNoteDetails(unitInformationTDS);
                            unitInformationNoteDetailsForEdit.LoadByUnitId(unitId, companyId);

                            UnitInformationCostInformation unitInformationCostInformation = new UnitInformationCostInformation(unitInformationTDS);
                            unitInformationCostInformation.LoadAllByUnitId(unitId, companyId);

                            UnitInformationCostExceptionsInformation unitInformationCostExceptionsInformation = new UnitInformationCostExceptionsInformation(unitInformationTDS);
                            unitInformationCostExceptionsInformation.LoadAllByUnitId(unitId, companyId);

                            // Store dataset
                            Session["unitInformationTDS"] = unitInformationTDS;
                        }
                    }
                    else
                    {
                        hdfActiveTab.Value = (string)Session["activeTabUnits"];
                    }

                    arrayCategoriesSelectedForEdit = new ArrayList();
                    arrayCompanyLevelsSelectedForEdit = new ArrayList();
                    Session["arrayCategoriesSelectedForEdit"] = arrayCategoriesSelectedForEdit;
                    Session["arrayCompanyLevelsSelectedForEdit"] = arrayCompanyLevelsSelectedForEdit;
                }

                // ... units_add.aspx
                if (Request.QueryString["source_page"] == "units_add.aspx")
                {
                    ViewState["update"] = "yes";

                    unitInformationTDS = new UnitInformationTDS();
                    unitsChecklistRulesTemp = new UnitInformationTDS.ChecklistDetailsDataTable();
                    unitsServicesTemp = new UnitInformationTDS.ServiceDetailsDataTable();
                    unitsInspectionsTemp = new UnitInformationTDS.InspectionDetailsDataTable();
                    unitsNotesTemp = new UnitInformationTDS.NoteInformationDataTable();

                    UnitInformationUnitDetails unitInformationUnitDetails = new UnitInformationUnitDetails(unitInformationTDS);
                    unitInformationUnitDetails.LoadByUnitId(unitId, companyId);

                    UnitInformationNoteDetails unitInformationNoteDetailsForEdit = new UnitInformationNoteDetails(unitInformationTDS);
                    unitInformationNoteDetailsForEdit.LoadByUnitId(unitId, companyId);

                    // ... For Categories
                    categoriesTDS = new CategoriesTDS();
                    Category category = new Category(categoriesTDS);
                    category.LoadByUnitType(hdfUnitType.Value, int.Parse(hdfCompanyId.Value));

                    // .. For Company Levels
                    companyLevelsTDS = new CompanyLevelsTDS();
                    CompanyLevel companyLevel = new CompanyLevel(companyLevelsTDS);
                    companyLevel.Load(int.Parse(hdfCompanyId.Value));

                    arrayCategoriesSelectedForEdit = new ArrayList();
                    arrayCompanyLevelsSelectedForEdit = new ArrayList();
                    Session["arrayCategoriesSelectedForEdit"] = arrayCategoriesSelectedForEdit;
                    Session["arrayCompanyLevelsSelectedForEdit"] = arrayCompanyLevelsSelectedForEdit;

                    // Store dataset
                    Session["unitInformationTDS"] = unitInformationTDS;
                    Session["unitsChecklistRulesTemp"] = unitsChecklistRulesTemp;
                    Session["unitsServicesTemp"] = unitsServicesTemp;
                    Session["unitsInspectionsTemp"] = unitsInspectionsTemp;
                    Session["unitsNotesTemp"] = unitsNotesTemp;
                    Session["categoriesTDSForUnits"] = categoriesTDS;
                    Session["companyLevelsTDS"] = companyLevelsTDS;
                }

                // ... For Library
                if (Session["libraryTDSForUnits"] != null)
                {
                    libraryTDSForUnits = (LibraryTDS)Session["libraryTDSForUnits"];
                }
                else
                {
                    libraryTDSForUnits = new LibraryTDS();
                }

                Session["costIdSelected"] = 0;
                grdCostsExceptions.ShowFooter = false;
                string filterOptions = string.Format("CostID = {0} AND Deleted = {1}", 0, 0);
                odsCostsExceptions.FilterExpression = filterOptions;
                
                // Set initial tab
                int activeTabUnits = Int32.Parse(hdfActiveTab.Value);
                tcDetailedInformation.ActiveTabIndex = activeTabUnits;

                // ... ... Make panels visible
                MakePanelsVisible();
                
                // ... ... Data for current unit               
                LoadUnitData(companyId);                
            }
            else
            {
                // Restore datasets
                unitInformationTDS = (UnitInformationTDS)Session["unitInformationTDS"];
                unitsChecklistRulesTemp = (UnitInformationTDS.ChecklistDetailsDataTable)Session["unitsChecklistRulesTemp"];
                unitsServicesTemp = (UnitInformationTDS.ServiceDetailsDataTable)Session["unitsServicesTemp"];
                unitsInspectionsTemp = (UnitInformationTDS.InspectionDetailsDataTable)Session["unitsInspectionsTemp"];
                unitsNotesTemp = (UnitInformationTDS.NoteInformationDataTable)Session["unitsNotesTemp"];
                categoriesTDS = (CategoriesTDS)Session["categoriesTDSForUnits"];
                companyLevelsTDS = (CompanyLevelsTDS)Session["companyLevelsTDS"];

                arrayCategoriesSelectedForEdit = (ArrayList)Session["arrayCategoriesSelectedForEdit"];
                arrayCompanyLevelsSelectedForEdit = (ArrayList)Session["arrayCompanyLevelsSelectedForEdit"];

                // Set initial tab
                int activeTabUnits = Int32.Parse(hdfActiveTab.Value);
                tcDetailedInformation.ActiveTabIndex = activeTabUnits;

                aceManufacturer.ContextKey = hdfCompanyId.Value;

                if (Session["libraryTDSForUnits"] != null)
                {
                    libraryTDSForUnits = (LibraryTDS)Session["libraryTDSForUnits"];
                }
                else
                {
                    libraryTDSForUnits = new LibraryTDS();
                }

                LoadNotes();
            }
        }



        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set active toolbar
            mForm6 master = (mForm6)this.Master;
            master.ActiveToolbar = "FleetManagement";           

            int companyId = Int32.Parse(hdfCompanyId.Value);
            int unitId = Int32.Parse(hdfUnitId.Value);

            // Validate unit info            
            string type = hdfUnitType.Value;
            string state = hdfUnitState.Value;

            if (type == "Vehicle")
            {
                lblTitle.Text = "Vehicle Information";
            }
            else
            {
                lblTitle.Text = "Equipment Information";
            }

            if (type == "Vehicle")
            {
                lblTitle.Text = "Vehicle Information";
                tpPlateData.Enabled = true;
                tpTechnical.Enabled = true;                       
            }
            else
            {
                lblTitle.Text = "Equipment Information";
                tpPlateData.Enabled = false;
                tpTechnical.Enabled = false;                
            }

            if (state == "Disposed")
            {
                lblDispositionDate.Visible = true;
                tkrdpDispositionDate.Visible = true;

                lblDispositionReason.Visible = true;
                tbxDispositionReason.Visible = true;
            }
            else
            {
                lblDispositionDate.Visible = false;
                tkrdpDispositionDate.Visible = false;

                lblDispositionReason.Visible = false;
                tbxDispositionReason.Visible = false;
            }            
        }                                 



        protected void grdInspections_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Add":
                    // Inspections Gridview, if the gridview is edition mode
                    if (grdInspections.EditIndex >= 0)
                    {
                        grdInspections.UpdateRow(grdInspections.EditIndex, true);
                    }

                    // Add New Inspection
                    InspectionsAddNew();
                    break;                
            }
        }



        protected void grdInspections_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.Validate("inspectionsEdit");
            if (Page.IsValid)
            {
                int inspectionId = (int)e.Keys["InspectionID"];
                DateTime date_ = ((RadDatePicker)grdInspections.Rows[e.RowIndex].Cells[1].FindControl("tkrdpInspectionDateEdit")).SelectedDate.Value;

                Int64 country = Int64.Parse(((DropDownList)grdInspections.Rows[e.RowIndex].Cells[1].FindControl("ddlCountryEdit")).SelectedValue.ToString().Trim());
                Int64 state = Int64.Parse(((DropDownList)grdInspections.Rows[e.RowIndex].Cells[1].FindControl("ddlStateEdit")).SelectedValue.ToString().Trim());
                string type = ((DropDownList)grdInspections.Rows[e.RowIndex].Cells[1].FindControl("ddlTypeEdit")).SelectedValue.ToString().Trim();
                string result = "";

                if (((DropDownList)grdInspections.Rows[e.RowIndex].Cells[1].FindControl("ddlResultEdit")).SelectedValue != "")
                {
                    result = ((DropDownList)grdInspections.Rows[e.RowIndex].Cells[1].FindControl("ddlResultEdit")).SelectedValue.Trim();
                }

                decimal? cost = null;

                if (((TextBox)grdInspections.Rows[e.RowIndex].Cells[1].FindControl("tbxRepairCostEdit")).Text.Trim() != "")
                {
                    cost = decimal.Parse(((TextBox)grdInspections.Rows[e.RowIndex].Cells[1].FindControl("tbxRepairCostEdit")).Text.Trim());
                }
                                
                string notes = ((TextBox)grdInspections.Rows[e.RowIndex].Cells[1].FindControl("tbxNotesEdit")).Text.Trim();
                
                string inspectedBy = ((TextBox)grdInspections.Rows[e.RowIndex].Cells[1].FindControl("tbxInspectedByEdit")).Text.Trim();
                                
                // Update
                UnitInformationInspectionDetails model = new UnitInformationInspectionDetails(unitInformationTDS);
                model.Update(inspectionId, date_, country, state, type, result, cost, notes, inspectedBy, "", false, false);

                // Store dataset
                Session["unitInformationTDS"] = unitInformationTDS;
            }
            else
            {
                e.Cancel = true;
            }
        }



        protected void grdInspections_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Inspections Gridview, if the gridview is edition mode
            if (grdInspections.EditIndex >= 0)
            {
                grdInspections.UpdateRow(grdInspections.EditIndex, true);
            }

            // Delete inspections
            int inspectionId = (int)e.Keys["InspectionID"];
            UnitInformationInspectionDetails model = new UnitInformationInspectionDetails(unitInformationTDS);

            // Delete inspection
            model.Delete(inspectionId);

            // Store dataset
            Session["unitInformationTDS"] = unitInformationTDS;
        }        



        protected void grdNotes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Notes Gridview, if the gridview is edition mode
            if (grdNotes.EditIndex >= 0)
            {
                grdNotes.UpdateRow(grdNotes.EditIndex, true);
            }

            // Delete notes
            int unitId = (int)e.Keys["UnitID"];
            int refId = (int)e.Keys["RefID"];

            UnitInformationNoteDetails model = new UnitInformationNoteDetails(unitInformationTDS);
            model.Delete(unitId, refId);

            if (((Label)grdNotes.Rows[e.RowIndex].Cells[3].FindControl("lblLibraryFileId")).Text.Trim() != "")
            {
                int? libraryFilesId = Int32.Parse(((Label)grdNotes.Rows[e.RowIndex].Cells[3].FindControl("lblLibraryFileId")).Text.Trim());

                LibraryFilesGateway libraryFilesGateway = new LibraryFilesGateway();
                libraryFilesGateway.DeleteByLibraryFilesId((int)libraryFilesId);
            }

            // Store dataset
            Session["unitInformationTDS"] = unitInformationTDS;
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
                    Session["activeTabUnits"] = "8";
                    Session["dialogOpenedUnits"] = "1";
                    GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                    int refId = Int32.Parse(((Label)row.FindControl("lblRefIDEdit")).Text);
                    string subject = ((TextBox)row.FindControl("tbxNoteSubjectEdit")).Text.Trim();
                    GrdNotesAddAttachment(refId, subject);
                    break;

                case "AddAttachmentAdd":
                    Session["activeTabUnits"] = "8";
                    Session["dialogOpenedUnits"] = "1";
                    string newSubject = ((TextBox)grdNotes.FooterRow.FindControl("tbxNoteSubjectNew")).Text.Trim();
                    GrdNotesAddAttachment(null, newSubject);
                    break;

                case "DownloadAttachment":
                    GridViewRow rowDownload = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                    string originalFileName = ((TextBox)rowDownload.FindControl("tbxNoteAttachment")).Text;
                    string fileName = ((Label)rowDownload.FindControl("lblFileName")).Text;
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

                    UnitInformationUnitDetailsGateway unitInformationUnitDetailsGateway = new UnitInformationUnitDetailsGateway(unitInformationTDS);
                    int? libraryCategoriesId = null; if (unitInformationUnitDetailsGateway.GetLibraryCategoriesId(int.Parse(hdfUnitId.Value)).HasValue) libraryCategoriesId = (int)unitInformationUnitDetailsGateway.GetLibraryCategoriesId(int.Parse(hdfUnitId.Value));

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
                UnitInformationUnitDetailsGateway unitInformationUnitDetailsGateway = new UnitInformationUnitDetailsGateway(unitInformationTDS);
                int? libraryCategoriesId = null; if (unitInformationUnitDetailsGateway.GetLibraryCategoriesId(int.Parse(hdfUnitId.Value)).HasValue) libraryCategoriesId = (int)unitInformationUnitDetailsGateway.GetLibraryCategoriesId(int.Parse(hdfUnitId.Value));

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



        protected void grdCosts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Add":
                    Page.Validate("AddCost");
                    if (Page.IsValid)
                    {
                        // Costs Gridview, if the gridview is edition mode
                        if (grdCosts.EditIndex >= 0)
                        {
                            grdCosts.UpdateRow(grdCosts.EditIndex, true);
                        }

                        // Add New Cost
                        GrdCostsAdd();
                    }
                    break;
            }
        }



        protected void grdCostsExceptions_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Add":
                    Page.Validate("AddCostException");
                    if (Page.IsValid)
                    {
                        // Costs exception Gridview, if the gridview is edition mode
                        if (grdCostsExceptions.EditIndex >= 0)
                        {
                            grdCostsExceptions.UpdateRow(grdCostsExceptions.EditIndex, true);
                        }

                        // Add New Cost exception
                        GrdCostsExceptionsAdd();
                    }
                    break;

                case "Edit":
                    string filterOptions = string.Format("CostID = {0} AND Deleted = {1}", Convert.ToInt32(Session["costIdSelected"]), 0);
                    odsCostsExceptions.FilterExpression = filterOptions;
                    break;
            }
        }




        protected void grdCosts_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Costs Gridview, if the gridview is edition mode
            if (grdCosts.EditIndex >= 0)
            {
                grdCosts.UpdateRow(grdCosts.EditIndex, true);
            }

            // Delete cost
            int costId = (int)e.Keys["CostID"];
            int unitId = Int32.Parse(hdfUnitId.Value);

            UnitInformationCostInformation model = new UnitInformationCostInformation(unitInformationTDS);

            // Delete cost
            model.Delete(costId, unitId);

            // Store dataset
            Session["unitInformationTDS"] = unitInformationTDS;
        }



        protected void grdCostsExceptions_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Costs exception Gridview, if the gridview is edition mode
            if (grdCostsExceptions.EditIndex >= 0)
            {
                grdCostsExceptions.UpdateRow(grdCostsExceptions.EditIndex, true);
            }

            // Delete cost exception
            int costId = (int)e.Keys["CostID"];
            int refId = (int)e.Keys["RefID"];
            UnitInformationCostExceptionsInformation model = new UnitInformationCostExceptionsInformation(unitInformationTDS);

            // Delete cost exception
            model.Delete(costId, refId);

            grdCostsExceptions.DataBind();
            grdCosts.DataBind();

            // Store dataset
            Session["unitInformationTDS"] = unitInformationTDS;
        }



        protected void grdNotes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.Validate("notesDataEdit");

            if (Page.IsValid)
            {
                int unitId = (int)e.Keys["UnitID"];
                int refId = (int)e.Keys["RefID"];

                string subject = ((TextBox)grdNotes.Rows[e.RowIndex].Cells[2].FindControl("tbxNoteSubjectEdit")).Text.Trim();
                string Note = ((TextBox)grdNotes.Rows[e.RowIndex].Cells[3].FindControl("tbxNoteNoteEdit")).Text.Trim();

                int? libraryFilesId = null;
                if (((Label)grdNotes.Rows[e.RowIndex].Cells[3].FindControl("lblLibraryFileIdEdit")).Text.Trim() != "")
                {
                    libraryFilesId = Int32.Parse(((Label)grdNotes.Rows[e.RowIndex].Cells[3].FindControl("lblLibraryFileIdEdit")).Text.Trim());
                }

                // Update data
                UnitInformationNoteDetails model = new UnitInformationNoteDetails(unitInformationTDS);
                model.Update(unitId, refId, subject, Note, libraryFilesId);

                // Store dataset
                Session["unitInformationTDS"] = unitInformationTDS;
            }
            else
            {
                e.Cancel = true;
            }
        }



        protected void grdCosts_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.Validate("EditCost");
            if (Page.IsValid)
            {
                int costId = (int)e.Keys["CostID"];
                int unitId = Int32.Parse(hdfUnitId.Value);

                string unitOfMeasurement = ((DropDownList)grdCosts.Rows[e.RowIndex].Cells[0].FindControl("ddlUnitOfMeasurementUnitsEdit")).SelectedValue;
                decimal costCad = Decimal.Parse(((TextBox)grdCosts.Rows[e.RowIndex].Cells[0].FindControl("tbxCostCadEdit")).Text.Trim());
                decimal costUsd = Decimal.Parse(((TextBox)grdCosts.Rows[e.RowIndex].Cells[0].FindControl("tbxCostUsdEdit")).Text.Trim());
                DateTime date = ((RadDatePicker)grdCosts.Rows[e.RowIndex].Cells[0].FindControl("tkrdpDateEdit")).SelectedDate.Value;

                // Update data
                UnitInformationCostInformation model = new UnitInformationCostInformation(unitInformationTDS);
                model.Update(costId, unitId, unitOfMeasurement, costCad, costUsd, date);

                // Store dataset
                Session["unitInformationTDS"] = unitInformationTDS;
            }
            else
            {
                e.Cancel = true;
            }
        }



        protected void grdCostsExceptions_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.Validate("EditCostException");
            if (Page.IsValid)
            {
                int costId = Int32.Parse(((Label)grdCostsExceptions.Rows[e.RowIndex].Cells[3].FindControl("lblExceptionCostIDEdit")).Text.Trim());
                int refId = Int32.Parse(((Label)grdCostsExceptions.Rows[e.RowIndex].Cells[3].FindControl("lblExceptionRefIDEdit")).Text.Trim());
                int unitId = Int32.Parse(hdfUnitId.Value);

                string unitOfMeasurement = ((DropDownList)grdCostsExceptions.Rows[e.RowIndex].Cells[0].FindControl("ddlExceptionUnitOfMeasurementUnitsEdit")).SelectedValue;
                decimal costCad = Decimal.Parse(((TextBox)grdCostsExceptions.Rows[e.RowIndex].Cells[3].FindControl("tbxExceptionCostCadEdit")).Text.Trim());
                decimal costUsd = Decimal.Parse(((TextBox)grdCostsExceptions.Rows[e.RowIndex].Cells[3].FindControl("tbxExceptionCostUsdEdit")).Text.Trim());
                string work_ = ((DropDownList)grdCostsExceptions.Rows[e.RowIndex].Cells[0].FindControl("ddlExceptionWorkEdit")).SelectedValue;

                // Update data
                UnitInformationCostExceptionsInformation model = new UnitInformationCostExceptionsInformation(unitInformationTDS);
                model.Update(costId, refId, work_, unitOfMeasurement, costCad, costUsd);

                // Store dataset
                Session["unitInformationTDS"] = unitInformationTDS;

                string filterOptions = string.Format("CostID = {0} AND Deleted = {1}", costId, 0);
                odsCostsExceptions.FilterExpression = filterOptions;
            }
            else
            {
                e.Cancel = true;
            }
        }




        

        // ////////////////////////////////////////////////////////////////////////
        // AUXILIAR EVENTS
        //

        protected void btnAssociate_Click(object sender, EventArgs e)
        {
            Session["activeTabUnits"] = "8";
            Session["dialogOpenedUnits"] = "1";
        }



        protected void btnUnassociate_Click(object sender, EventArgs e)
        {
            Session["activeTabUnits"] = "8";
            Session["dialogOpenedUnits"] = "1";

            UnitInformationUnitDetails unitInformationUnitDetails = new UnitInformationUnitDetails(unitInformationTDS);
            unitInformationUnitDetails.UpdateLibraryCategoriesId(int.Parse(hdfUnitId.Value), null);

            ViewState["update"] = "no";

            btnUnassociate.Visible = false;
            btnAssociate.Visible = true;
            tbxCategoryAssocited.Text = "";
        }



        protected void cvForDateRange_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //For dates before 1900
            string[] date = (args.Value.Trim()).Split('/');

            if (((Validator.IsValidDate(args.Value.Trim())) && (Int32.Parse(date[2]) >= 1900)) || ((args.Value.Trim().Length == 4) && (Validator.IsValidInt32(args.Value.Trim())) && (Int32.Parse(args.Value.Trim()) >= 1900)) || (args.Value.Trim() == "%") || (args.Value.Trim() == ""))
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }



        protected void cvCategories_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = false;
            arrayCategoriesSelectedForEdit.Clear();

            foreach (TreeNode nodes in tvCategoriesRoot.Nodes)
            {
                GetCategoriesSelected(nodes);
            }

            if (tvCategoriesRoot.Nodes.Count > 0)
            {
                if (arrayCategoriesSelectedForEdit.Count > 0)
                {
                    args.IsValid = true;
                }
            }
            else
            {
                cvCategories.ErrorMessage = "There are no categories available. Contact your system administrator";
            }

            Session["arrayCategoriesSelectedForEdit"] = arrayCategoriesSelectedForEdit;
        }



        protected void cvCompanyLevels_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = false;
            arrayCompanyLevelsSelectedForEdit.Clear();

            foreach (TreeNode nodes in tvCompanyLevelsRoot.Nodes)
            {
                GetCompanyLevelsSelected(nodes);
            }

            if (tvCompanyLevelsRoot.Nodes.Count > 0)
            {
                if (arrayCompanyLevelsSelectedForEdit.Count > 0)
                {
                    if (arrayCompanyLevelsSelectedForEdit.Count < 2)
                    {
                        args.IsValid = true;
                    }
                    else
                    {
                        cvCompanyLevels.ErrorMessage = "You can select only one company level leave";
                    }
                }
                else
                {
                    cvCompanyLevels.ErrorMessage = "You must select at least one company level";
                }
            }
            else
            {
                cvCompanyLevels.ErrorMessage = "There are no company levels available. Contact your system administrator";
            }

            Session["arrayCompanyLevelsSelectedForEdit"] = arrayCompanyLevelsSelectedForEdit;
        }



        protected void cvCode_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            UnitsGateway unitsGateway = new UnitsGateway(null);
            int unitId = int.Parse(hdfUnitId.Value);

            if (unitsGateway.IsUnitCodeInUse(args.Value.Trim(), unitId))
            {
                args.IsValid = false;
            }
        }



        protected void cvEditDate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            if (((RadDatePicker)grdCosts.Rows[grdCosts.EditIndex].FindControl("tkrdpDateEdit")).SelectedDate.HasValue)
            {
                DateTime newDate = Convert.ToDateTime(((RadDatePicker)grdCosts.Rows[grdCosts.EditIndex].FindControl("tkrdpDateEdit")).SelectedDate.Value);

                if (grdCosts.Rows.Count > 0)
                {
                    foreach (GridViewRow row in grdCosts.Rows)
                    {
                        if ((row.RowType == DataControlRowType.DataRow) && ((row.RowState == DataControlRowState.Normal) || (row.RowState == (DataControlRowState.Normal | DataControlRowState.Alternate))))
                        {
                            if (Validator.IsValidDate(((Label)row.FindControl("lblDate")).Text))
                            {
                                DateTime date = Convert.ToDateTime(((Label)row.FindControl("lblDate")).Text);
                                if (date == newDate)
                                {
                                    args.IsValid = false;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                args.IsValid = false;
            }
        }



        protected void cvAddDate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            if (((RadDatePicker)grdCosts.FooterRow.FindControl("tkrdpDateNew")).SelectedDate.HasValue)
            {
                DateTime newDate = Convert.ToDateTime(((RadDatePicker)grdCosts.FooterRow.FindControl("tkrdpDateNew")).SelectedDate.Value);

                if (grdCosts.Rows.Count > 0)
                {
                    foreach (GridViewRow row in grdCosts.Rows)
                    {
                        if ((row.RowType == DataControlRowType.DataRow) && ((row.RowState == DataControlRowState.Normal) || (row.RowState == (DataControlRowState.Normal | DataControlRowState.Alternate))))
                        {
                            if (Validator.IsValidDate(((Label)row.FindControl("lblDate")).Text))
                            {
                                DateTime date = Convert.ToDateTime(((Label)row.FindControl("lblDate")).Text);
                                if (date == newDate)
                                {
                                    args.IsValid = false;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                args.IsValid = false;
            }
        }



        protected void cbxSelectedCost_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkbox = (CheckBox)sender;
            int costId = 0;
            Session["costIdSelected"] = 0;
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
            Session.Remove("unitCostsExceptionsDummy");
            grdCostsExceptions.ShowFooter = true;
            if (checkbox.Checked)
            {
                GridViewRow row = (GridViewRow)checkbox.NamingContainer;
                costId = Int32.Parse(((Label)row.FindControl("lblCostID")).Text);

                foreach (GridViewRow rowTemp in grdCosts.Rows)
                {
                    if ((rowTemp.RowType == DataControlRowType.DataRow) && ((rowTemp.RowState == DataControlRowState.Normal) || (rowTemp.RowState == (DataControlRowState.Normal | DataControlRowState.Alternate))))
                    {
                        if (Validator.IsValidInt32(((Label)rowTemp.FindControl("lblCostID")).Text))
                        {
                            int costTemp = Int32.Parse(((Label)rowTemp.FindControl("lblCostID")).Text);

                            if (costId != costTemp)
                            {
                                ((CheckBox)rowTemp.FindControl("cbxSelected")).Checked = false;
                            }
                        }
                    }
                }

                Session.Remove("costIdSelected");
                Session["costIdSelected"] = costId;
            }

            string filterOptions = string.Format("CostID = {0} AND Deleted = {1}", costId, 0);
            odsCostsExceptions.FilterExpression = filterOptions;
        }



        protected void cbxSelectedCostSummary_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkbox = (CheckBox)sender;
            int costId = 0;
            Session["costIdSelected"] = 0;
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
            Session.Remove("unitCostsExceptionsDummy");

            if (checkbox.Checked)
            {
                GridViewRow row = (GridViewRow)checkbox.NamingContainer;
                costId = Int32.Parse(((Label)row.FindControl("lblCostID")).Text);

                foreach (GridViewRow rowTemp in grdCostsSummary.Rows)
                {
                    int costTemp = Int32.Parse(((Label)rowTemp.FindControl("lblCostID")).Text);

                    if (costId != costTemp)
                    {
                        ((CheckBox)rowTemp.FindControl("cbxSelected")).Checked = false;
                    }
                }

                Session.Remove("costIdSelected");
                Session["costIdSelected"] = costId;
            }

            string filterOptions = string.Format("CostID = {0} AND Deleted = {1}", costId, 0);
            odsCostsExceptionsSummary.FilterExpression = filterOptions;            
        }



        protected void ddlInsuranceClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlInsuranceClass.SelectedValue == "Ryder Specified")
            {
                lblRyderSpecified.Visible = true;
                tbxRyderSpecified.Visible = true;

                upnlRyderSpecifiedLabel.Update();
                upnlRyderSpecified.Update();
            }
            else
            {
                lblRyderSpecified.Visible = false;
                tbxRyderSpecified.Visible = false;

                upnlRyderSpecifiedLabel.Update();
                upnlRyderSpecified.Update();
            }
        }



        protected void ddlLicenseCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbxLicenseState.Text = "";
            if (ddlLicenseCountry.SelectedValue == "1")
            {
                tbxLicenseState.Text = "Ontario";
                hdfLicenseStateId.Value = "12435";
            }
            else
            {
                if (ddlLicenseCountry.SelectedValue == "2")
                {
                    tbxLicenseState.Text = "Michigan";
                    hdfLicenseStateId.Value = "84026";
                }
            }

            tbxLicenseState.DataBind();
        }



        protected void ddlOwnerCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProvinceList provinceList = new ProvinceList();
            provinceList.LoadByCountryIdAndAddItem(-1, "(Select a state)", int.Parse(ddlOwnerCountry.SelectedValue));
            ddlOwnerState.DataSource = provinceList.Table;
            ddlOwnerState.DataValueField = "ProvinceID";
            ddlOwnerState.DataTextField = "Name";
            ddlOwnerState.DataBind();
        }



        protected void ddlCountryEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlCountry = ((DropDownList)grdInspections.Rows[grdInspections.EditIndex].FindControl("ddlCountryEdit"));
            DropDownList ddlState = ((DropDownList)grdInspections.Rows[grdInspections.EditIndex].FindControl("ddlStateEdit"));

            ProvinceList provinceList = new ProvinceList();
            provinceList.LoadByCountryIdAndAddItem(-1, "(Select a state)", int.Parse(ddlCountry.SelectedValue));
            ddlState.DataSource = provinceList.Table;
            ddlState.DataValueField = "ProvinceID";
            ddlState.DataTextField = "Name";
            ddlState.DataBind();
        }



        protected void ddlCountryNew_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlCountry = ((DropDownList)grdInspections.FooterRow.FindControl("ddlCountryNew"));
            DropDownList ddlState = ((DropDownList)grdInspections.FooterRow.FindControl("ddlStateNew"));

            ProvinceList provinceList = new ProvinceList();
            provinceList.LoadByCountryIdAndAddItem(-1, "(Select a state)", int.Parse(ddlCountry.SelectedValue));
            ddlState.DataSource = provinceList.Table;
            ddlState.DataValueField = "ProvinceID";
            ddlState.DataTextField = "Name";
            ddlState.DataBind();
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



        protected void grdCostsExceptions_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Costs exceptions Gridview, if the gridview is edition mode
            if (grdCostsExceptions.EditIndex >= 0)
            {
                grdCostsExceptions.UpdateRow(grdCostsExceptions.EditIndex, true);
            }
        }



        protected void grdCosts_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Edit items
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Edit) || (e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
            {
                int costId = Int32.Parse(((Label)e.Row.FindControl("lblCostIDEdit")).Text.Trim());

                UnitInformationCostInformationGateway unitInformationCostInformationGateway = new UnitInformationCostInformationGateway(unitInformationTDS);
                string unitOfMeasurement = unitInformationCostInformationGateway.GetUnitOfMeasurement(costId);
                ((DropDownList)e.Row.FindControl("ddlUnitOfMeasurementUnitsEdit")).SelectedValue = unitOfMeasurement;
            }
        }



        protected void grdCostsExceptions_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Normal items
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Normal) || (e.Row.RowState == (DataControlRowState.Normal | DataControlRowState.Alternate))))
            {

            }

            // Edit items
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Edit) || (e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
            {
                int refId = Int32.Parse(((Label)e.Row.FindControl("lblExceptionRefIDEdit")).Text.Trim());
                int costId = Int32.Parse(((Label)e.Row.FindControl("lblExceptionCostIDEdit")).Text.Trim());

                UnitInformationCostExceptionsInformationGateway unitInformationCostExceptionsInformationGateway = new UnitInformationCostExceptionsInformationGateway(unitInformationTDS);
                string work = unitInformationCostExceptionsInformationGateway.GetWork_(costId, refId);
                ((DropDownList)e.Row.FindControl("ddlExceptionWorkEdit")).SelectedValue = work;

                string unitOfMeasurement = unitInformationCostExceptionsInformationGateway.GetUnitOfMeasurement(costId, refId);
                ((DropDownList)e.Row.FindControl("ddlExceptionUnitOfMeasurementUnitsEdit")).SelectedValue = unitOfMeasurement;
            }
        }



        protected void grdInspections_DataBound(object sender, EventArgs e)
        {
            InspectionsEmptyFix(grdInspections);
        }



        protected void grdInspectionsSummary_DataBound(object sender, EventArgs e)
        {
            InspectionsEmptyFixSummary(grdInspectionsSummary);
        }



        protected void grdInspections_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Control of footer controls
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                // For Country
                ((DropDownList)e.Row.FindControl("ddlCountryNew")).SelectedIndex = 0;
            }

            // Control of edit controls
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Edit) || (e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
            {
                int unitId = Int32.Parse(hdfUnitId.Value);
                int inspectionId = int.Parse(((Label)e.Row.FindControl("lblInspectionIdEdit")).Text);
                int companyId = Int32.Parse(hdfCompanyId.Value);
                DropDownList ddlCountry = ((DropDownList)e.Row.FindControl("ddlCountryEdit"));
                DropDownList ddlState = ((DropDownList)e.Row.FindControl("ddlStateEdit"));

                //UnitsInspectionGateway unitsInspectionGateway = new UnitsInspectionGateway();
                //unitsInspectionGateway.LoadByUnitIdInspectionId(unitId, inspectionId, companyId);               

                //if (unitsInspectionGateway.Table.Rows.Count > 0)
                //{
                //    ((DropDownList)e.Row.FindControl("ddlCountryEdit")).SelectedValue = unitsInspectionGateway.GetCountry(unitId, inspectionId).ToString();
                //    ((RadDatePicker)e.Row.FindControl("tkrdpInspectionDateEdit")).SelectedDate = unitsInspectionGateway.GetDate_(unitId, inspectionId);
                //}
                //else
                //{
                //    ddlCountry.SelectedValue = ((DropDownList)e.Row.FindControl("ddlCountryEdit")).SelectedValue;
                //}

                UnitInformationInspectionDetailsGateway unitInformationInspectionDetailsForEdit = new UnitInformationInspectionDetailsGateway(unitInformationTDS);
                try
                {
                    ddlCountry.SelectedValue = unitInformationInspectionDetailsForEdit.GetCountry(inspectionId).ToString();
                    ((RadDatePicker)e.Row.FindControl("tkrdpInspectionDateEdit")).SelectedDate = unitInformationInspectionDetailsForEdit.GetDate_(inspectionId);
                }
                catch
                {
                }

                ProvinceList provinceList = new ProvinceList();
                provinceList.LoadByCountryIdAndAddItem(-1, "(Select a state)", int.Parse(ddlCountry.SelectedValue));
                ddlState.DataSource = provinceList.Table;
                ddlState.DataValueField = "ProvinceID";
                ddlState.DataTextField = "Name";
                ddlState.DataBind();
                try
                {
                    ddlState.SelectedValue = unitInformationInspectionDetailsForEdit.GetState(inspectionId).ToString();
                }
                catch
                {
                }
                //if (unitsInspectionGateway.Table.Rows.Count > 0)
                //{
                //    ddlState.SelectedValue = unitsInspectionGateway.GetState(unitId, inspectionId).ToString();
                //}
                //else
                //{
                //    ddlState.SelectedValue = ((DropDownList)e.Row.FindControl("ddlStateEdit")).SelectedValue;
                //}
            }
        }



        protected void grdChecklistRulesInformation_DataBound(object sender, EventArgs e)
        {
            ChecklistRulesInformationEmptyFix(grdChecklistRulesInformation);
        }



        protected void grdServices_DataBound(object sender, EventArgs e)
        {
            ServicesEmptyFix(grdServices);
        }



        protected void grdChecklistRulesInformation_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {            
        }



        protected void grdServices_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ServicesProcessGrid();
        }



        protected void grdNotes_DataBound(object sender, EventArgs e)
        {
            AddNotesNewEmptyFix(grdNotes);
        }



        protected void grdCosts_DataBound(object sender, EventArgs e)
        {
            // New Empty Fix
            AddCostsNewEmptyFix(grdCosts);

            // Check last row
            int totalRows = grdCosts.Rows.Count;
            if (totalRows != 0)
            {
                foreach (GridViewRow rowTemp1 in grdCosts.Rows)
                {
                    if (rowTemp1.RowIndex == totalRows - 1)
                    {
                        // ... Mark last row as selected
                        if ((grdCosts.Rows[0].Visible) && (rowTemp1.RowType == DataControlRowType.DataRow) && ((rowTemp1.RowState == DataControlRowState.Normal) || (rowTemp1.RowState == (DataControlRowState.Normal | DataControlRowState.Alternate))))
                        {

                            // ... Mark first row as selected
                            ((CheckBox)rowTemp1.FindControl("cbxSelected")).Checked = true;

                            // ... Show exceptions for first selected row
                            CheckBox checkbox = ((CheckBox)rowTemp1.FindControl("cbxSelected"));
                            int costId = 0;
                            Session["costIdSelected"] = 0;
                            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
                            Session.Remove("unitCostsExceptionsDummy");
                            grdCostsExceptions.ShowFooter = true;
                            if (checkbox.Checked)
                            {
                                GridViewRow row = (GridViewRow)checkbox.NamingContainer;
                                costId = Int32.Parse(((Label)row.FindControl("lblCostID")).Text);

                                foreach (GridViewRow rowTemp in grdCosts.Rows)
                                {
                                    if ((rowTemp.RowType == DataControlRowType.DataRow) && ((rowTemp.RowState == DataControlRowState.Normal) || (rowTemp.RowState == (DataControlRowState.Normal | DataControlRowState.Alternate))))
                                    {
                                        if (Validator.IsValidInt32(((Label)rowTemp.FindControl("lblCostID")).Text))
                                        {
                                            int costTemp = Int32.Parse(((Label)rowTemp.FindControl("lblCostID")).Text);

                                            if (costId != costTemp)
                                            {
                                                ((CheckBox)rowTemp.FindControl("cbxSelected")).Checked = false;
                                            }
                                        }
                                    }
                                }

                                Session.Remove("costIdSelected");
                                Session["costIdSelected"] = costId;
                            }

                            string filterOptions = string.Format("CostID = {0} AND Deleted = {1}", costId, 0);
                            odsCostsExceptions.FilterExpression = filterOptions;
                        }
                    }
                }
            }
        }



        protected void grdCostsSummary_DataBound(object sender, EventArgs e)
        {
            // New Empty Fix
            AddCostsNewEmptyFixSummary(grdCostsSummary);

            // Check last row
            int totalRows = grdCostsSummary.Rows.Count;
            if (totalRows != 0)
            {
                foreach (GridViewRow rowTemp1 in grdCostsSummary.Rows)
                {
                    if (rowTemp1.RowIndex == totalRows - 1)
                    {
                        // ... Mark last row as selected
                        if ((grdCostsSummary.Rows[0].Visible) && (rowTemp1.RowType == DataControlRowType.DataRow) && ((rowTemp1.RowState == DataControlRowState.Normal) || (rowTemp1.RowState == (DataControlRowState.Normal | DataControlRowState.Alternate))))
                        {
                            // ... Mark first row as selected
                            ((CheckBox)rowTemp1.FindControl("cbxSelected")).Checked = true;

                            // ... Show exceptions for first selected row
                            CheckBox checkbox = ((CheckBox)rowTemp1.FindControl("cbxSelected"));
                            int costId = 0;
                            Session["costIdSelected"] = 0;
                            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
                            Session.Remove("unitCostsExceptionsDummy");

                            if (checkbox.Checked)
                            {
                                GridViewRow row = (GridViewRow)checkbox.NamingContainer;
                                costId = Int32.Parse(((Label)row.FindControl("lblCostID")).Text);

                                foreach (GridViewRow rowTemp in grdCosts.Rows)
                                {
                                    int costTemp = Int32.Parse(((Label)rowTemp.FindControl("lblCostID")).Text);

                                    if (costId != costTemp)
                                    {
                                        ((CheckBox)rowTemp.FindControl("cbxSelected")).Checked = false;
                                    }
                                }

                                Session.Remove("costIdSelected");
                                Session["costIdSelected"] = costId;
                            }

                            string filterOptions = string.Format("CostID = {0} AND Deleted = {1}", costId, 0);
                            odsCostsExceptionsSummary.FilterExpression = filterOptions;
                        }
                    }
                }
            }
        }



        protected void grdCostsExceptions_DataBound(object sender, EventArgs e)
        {
            AddCostsExceptionsNewEmptyFix(grdCostsExceptions);
        }



        protected void grdCostsExceptionsSummary_DataBound(object sender, EventArgs e)
        {
            AddCostsExceptionsNewEmptyFixSummary(grdCostsExceptionsSummary);
        }



        protected void grdInspections_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Inspections Gridview, if the gridview is edition mode
            if (grdInspections.EditIndex >= 0)
            {
                grdInspections.UpdateRow(grdInspections.EditIndex, true);
            }
        }



        protected void btnChecklistOnClick(object sender, EventArgs e)
        {
            // Store active tab for postback
            Session["activeTabUnits"] = "4";
            Session["dialogOpenedUnits"] = "1";

            // Open Dialog
            string script = "<script language='javascript'>";
            string url = "./units_checklist_rules.aspx?source_page=units_edit.aspx&unit_id=" + hdfUnitId.Value;
            script = script + string.Format("window.open('{0}', '_blank', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copy=no, width=630, height=440')", url);
            script = script + "</script>";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Checklist", script, false);
        }



        protected void btnOpenServiceOnClick(object sender, EventArgs e)
        {
            foreach (GridViewRow row in grdServices.Rows)
            {
                if (((CheckBox)row.FindControl("cbxSelectedService")).Checked)
                {
                    int serviceId = Int32.Parse(((Label)row.FindControl("lblServiceId")).Text.Trim());

                    // Redirect
                    string url = "./../Services/services_summary.aspx?source_page=services_add_request.aspx&dashboard=False&service_id=" + serviceId + "&active_tab=0" + GetNavigatorStateForServices();
                    Response.Redirect(url);
                }
            }
        } 
        

        



        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATION EVENTS
        //

        protected void tkrmTop_ItemClick(object sender, RadMenuEventArgs e)
        {
            // Store active tab for postback
            Session["activeTabUnits"] = "0";
            Session["dialogOpenedUnits"] = "0";

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
                    Session.Remove("libraryTDSForUnits");

                    if (Request.QueryString["source_page"] == "units_navigator2.aspx" || Request.QueryString["source_page"] == "units_add.aspx")
                    {
                        url = "./units_navigator2.aspx?source_page=units_edit.aspx" + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    }

                    if (Request.QueryString["source_page"] == "units_summary.aspx")
                    {
                        url = "./units_summary.aspx?source_page=units_edit.aspx&unit_id=" + hdfUnitId.Value + "&unit_type=" + hdfUnitType.Value + "&unit_state=" + hdfUnitState.Value + "&active_tab=" + hdfActiveTab.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];                        
                    }
                    break;

                case "mPrevious":
                    Session.Remove("libraryTDSForUnits");

                    // Get previous record
                    int previousId = UnitsNavigator.GetPreviousId((UnitsNavigatorTDS)Session["unitsNavigatorTDS"], Int32.Parse(hdfUnitId.Value));

                    if (previousId != Int32.Parse(hdfUnitId.Value))
                    {
                        this.Apply();

                        // ... Redirect
                        int companyId = Int32.Parse(hdfCompanyId.Value);
                        int unitId = Int32.Parse(hdfUnitId.Value);
                        UnitsGateway unitsGateway = new UnitsGateway();
                        unitsGateway.LoadByUnitId(unitId, companyId);
                        string unitType = unitsGateway.GetType(unitId);
                        string unitState = unitsGateway.GetState(unitId);

                        url = "./units_edit.aspx?source_page=" + Request.QueryString["source_page"] + "&unit_id=" + previousId + "&unit_type=" + unitType + "&unit_state=" + unitState + "&active_tab=" + activeTab + GetNavigatorState() + "&update=yes";
                    }
                    break;

                case "mNext":
                    Session.Remove("libraryTDSForUnits");

                    // Get next record
                    int nextId = UnitsNavigator.GetNextId((UnitsNavigatorTDS)Session["unitsNavigatorTDS"], Int32.Parse(hdfUnitId.Value));

                    if (nextId != Int32.Parse(hdfUnitId.Value))
                    {
                        this.Apply();

                        // ... Redirect
                        int companyId = Int32.Parse(hdfCompanyId.Value);
                        int unitId = Int32.Parse(hdfUnitId.Value);
                        UnitsGateway unitsGateway = new UnitsGateway();
                        unitsGateway.LoadByUnitId(unitId, companyId);
                        string unitType = unitsGateway.GetType(unitId);
                        string unitState = unitsGateway.GetState(unitId);

                        url = "./units_edit.aspx?source_page=" + Request.QueryString["source_page"] + "&unit_id=" + nextId + "&unit_type=" + unitType + "&unit_state=" + unitState + "&active_tab=" + activeTab + GetNavigatorState() + "&update=yes";
                    }
                    break;
            }

            if (url != "") Response.Redirect(url);
        }



        protected void tkrpbLeftMenu_ItemClick(object sender, RadPanelBarEventArgs e)
        {
            // Store active tab for postback
            Session["activeTabUnits"] = "0";
            Session["dialogOpenedUnits"] = "0";
            Session.Remove("libraryTDSForUnits");

            string url = "";

            switch (e.Item.Value)
            {
                case "mSearch":
                    url = "./units_navigator.aspx?source_page=lm";
                    break;
            }

            if (url != "") Response.Redirect(url);
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        public UnitInformationTDS.ChecklistDetailsDataTable GetChecklistRulesInformation()
        {
            unitsChecklistRulesTemp = (UnitInformationTDS.ChecklistDetailsDataTable)Session["unitsChecklistRulesTempDummy"];

            if (unitsChecklistRulesTemp == null)
            {
                unitsChecklistRulesTemp = (UnitInformationTDS.ChecklistDetailsDataTable)Session["unitsChecklistRulesTemp"];
            }

            return unitsChecklistRulesTemp;
        }



        public UnitInformationTDS.ServiceDetailsDataTable GetServicesInformation()
        {
            unitsServicesTemp = (UnitInformationTDS.ServiceDetailsDataTable)Session["unitsServicesTempDummy"];

            if (unitsServicesTemp == null)
            {
                unitsServicesTemp = (UnitInformationTDS.ServiceDetailsDataTable)Session["unitsServicesTemp"];
            }

            return unitsServicesTemp;
        }



        public UnitInformationTDS.InspectionDetailsDataTable GetInspectionsInformation()
        {
            unitsInspectionsTemp = (UnitInformationTDS.InspectionDetailsDataTable)Session["unitsInspectionsTempDummy"];
            if (unitsInspectionsTemp == null)
            {
                unitsInspectionsTemp = ((UnitInformationTDS)Session["unitInformationTDS"]).InspectionDetails;
            }

            return unitsInspectionsTemp;
        }



        public UnitInformationTDS.NoteInformationDataTable GetNotesNew()
        {
            unitsNotesTemp = (UnitInformationTDS.NoteInformationDataTable)Session["unitsNotesTempDummy"];

            if (unitsNotesTemp == null)
            {
                unitsNotesTemp = ((UnitInformationTDS)Session["unitInformationTDS"]).NoteInformation;
            }

            return unitsNotesTemp;
        }



        public UnitInformationTDS.CostInformationDataTable GetCostsNew()
        {
            unitInformationCosts = (UnitInformationTDS.CostInformationDataTable)Session["unitCostsDummy"];
            if (unitInformationCosts == null)
            {
                unitInformationCosts = ((UnitInformationTDS)Session["unitInformationTDS"]).CostInformation;
            }

            return unitInformationCosts;
        }



        public UnitInformationTDS.CostExceptionsInformationDataTable GetCostsExceptionsNew()
        {
            unitInformationCostsExceptions = (UnitInformationTDS.CostExceptionsInformationDataTable)Session["unitCostsExceptionsDummy"];
            if (unitInformationCostsExceptions == null)
            {
                unitInformationCostsExceptions = ((UnitInformationTDS)Session["unitInformationTDS"]).CostExceptionsInformation;
            }

            return unitInformationCostsExceptions;
        }



        public void DummyInspectionsAddInspections(int InspectionID)
        {
        }



        public void DummyNotesNew(int UnitID, int RefID)
        {
        }



        public void DummyCostsNew(string UnitOfMeasurement, int CostID)
        {
        }



        public void DummyCostsNew(int CostID)
        {
        }



        public void DummyCostsNew(int CostID, int MaterialID)
        {
        }



        public void DummyCostsExceptionsNew(int CostID)
        {
        }



        public void DummyCostsExceptionsNew()
        {
        }



        public void DummyCostsExceptionsNew(int CostID, int RefID)
        {
        }



        public void DummyCostsExceptionsNew(int CostID, int RefID, int MaterialID)
        {
        }



        public void DummyCostsExceptionsNew(string UnitOfMeasurement, int CostID, int RefID)
        {
        }

        

        protected void ChecklistRulesInformationEmptyFix(GridView grdChecklistRulesInformation)
        {
            if (grdChecklistRulesInformation.Rows.Count == 0)
            {
                DateTime lastService = new DateTime();
                DateTime nextDue = new DateTime();
                UnitInformationTDS.ChecklistDetailsDataTable dt = new UnitInformationTDS.ChecklistDetailsDataTable();
                dt.AddChecklistDetailsRow(0, "", "", lastService, nextDue, false, "Unknown", false);
                Session["unitsChecklistRulesTempDummy"] = dt;
                btnChecklist.Visible = false;
                grdChecklistRulesInformation.DataBind();
            }

            // Normally executes at all postbacks
            if (grdChecklistRulesInformation.Rows.Count == 1)
            {
                UnitInformationTDS.ChecklistDetailsDataTable dt = (UnitInformationTDS.ChecklistDetailsDataTable)Session["unitsChecklistRulesTempDummy"];
                if (dt != null)
                {
                    // Hide row
                    grdChecklistRulesInformation.Rows[0].Visible = false;
                    grdChecklistRulesInformation.Rows[0].Controls.Clear();
                    btnChecklist.Visible = false;
                }
            }
        }



        protected void ServicesEmptyFix(GridView grdServices)
        {
            if (grdServices.Rows.Count == 0)
            {
                DateTime date = new DateTime();
                UnitInformationTDS.ServiceDetailsDataTable dt = new UnitInformationTDS.ServiceDetailsDataTable();
                dt.AddServiceDetailsRow("", date, "", "", false);
                Session["unitsServicesTempDummy"] = dt;
                btnOpenService.Visible = false;
                grdServices.DataBind();
            }

            // Normally executes at all postbacks
            if (grdServices.Rows.Count == 1)
            {
                UnitInformationTDS.ServiceDetailsDataTable dt = (UnitInformationTDS.ServiceDetailsDataTable)Session["unitsServicesTempDummy"];
                if (dt != null)
                {
                    // Hide row
                    grdServices.Rows[0].Visible = false;
                    grdServices.Rows[0].Controls.Clear();
                    btnOpenService.Visible = false;
                }
            }
        }



        protected void InspectionsEmptyFix(GridView grdInspections)
        {
            if (grdInspections.Rows.Count == 0)
            {
                UnitInformationTDS.InspectionDetailsDataTable dt = new UnitInformationTDS.InspectionDetailsDataTable();
                DateTime date = new DateTime();
                int companyId = Int32.Parse(hdfCompanyId.Value);
                dt.AddInspectionDetailsRow(-1, date, -1, -1, "", "", 0, "", "", "", false, false);
                Session["unitsInspectionsTempDummy"] = dt;

                grdInspections.DataBind();
            }

            // Normally executes at all postbacks
            if (grdInspections.Rows.Count == 1)
            {
                UnitInformationTDS.InspectionDetailsDataTable dt = (UnitInformationTDS.InspectionDetailsDataTable)Session["unitsInspectionsTempDummy"];
                if (dt != null)
                {
                    grdInspections.Rows[0].Visible = false;
                    grdInspections.Rows[0].Controls.Clear();
                }
            }
        }



        protected void InspectionsEmptyFixSummary(GridView grdInspectionsSummary)
        {
            if (grdInspectionsSummary.Rows.Count == 0)
            {
                DateTime date = new DateTime();
                UnitInformationTDS.InspectionDetailsDataTable dt = new UnitInformationTDS.InspectionDetailsDataTable();
                dt.AddInspectionDetailsRow(0, date, 0, 0, "", "", 0, "", "", "", false, false);
                Session["unitsInspectionsTempDummy"] = dt;

                grdInspectionsSummary.DataBind();
            }

            // normally executes at all postbacks
            if (grdInspectionsSummary.Rows.Count == 1)
            {
                UnitInformationTDS.InspectionDetailsDataTable dt = (UnitInformationTDS.InspectionDetailsDataTable)Session["unitsInspectionsTempDummy"];
                if (dt != null)
                {
                    // hide row
                    grdInspectionsSummary.Rows[0].Visible = false;
                    grdInspectionsSummary.Rows[0].Controls.Clear();
                }
            }
        }



        protected void AddNotesNewEmptyFix(GridView grdNotes)
        {
            if (grdNotes.Rows.Count == 0)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                UnitInformationTDS.NoteInformationDataTable dt = new UnitInformationTDS.NoteInformationDataTable();
                dt.AddNoteInformationRow(-1, -1, "", -1, DateTime.Now, "", false, companyId, false, 0, "", "");
                Session["unitsNotesTempDummy"] = dt;

                grdNotes.DataBind();
            }

            // Normally executes at all postbacks
            if (grdNotes.Rows.Count == 1)
            {
                UnitInformationTDS.NoteInformationDataTable dt = (UnitInformationTDS.NoteInformationDataTable)Session["unitsNotesTempDummy"];
                if (dt != null)
                {
                    grdNotes.Rows[0].Visible = false;
                    grdNotes.Rows[0].Controls.Clear();
                }
            }
        }



        protected void AddCostsNewEmptyFix(GridView grdView)
        {
            if (grdCosts.Rows.Count == 0)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                UnitInformationTDS.CostInformationDataTable dt = new UnitInformationTDS.CostInformationDataTable();
                dt.AddCostInformationRow(-1, -1, DateTime.Now, "", 0, 0, false, companyId, false);
                Session["unitCostsDummy"] = dt;

                grdCosts.DataBind();
            }

            // Normally executes at all postbacks
            if (grdCosts.Rows.Count == 1)
            {
                UnitInformationTDS.CostInformationDataTable dt = (UnitInformationTDS.CostInformationDataTable)Session["unitCostsDummy"];
                if (dt != null)
                {
                    grdCosts.Rows[0].Visible = false;
                    grdCosts.Rows[0].Controls.Clear();
                }
            }
        }



        protected void AddCostsNewEmptyFixSummary(GridView grdView)
        {
            if (grdCostsSummary.Rows.Count == 0)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                UnitInformationTDS.CostInformationDataTable dt = new UnitInformationTDS.CostInformationDataTable();
                dt.AddCostInformationRow(-1, -1, DateTime.Now, "", 0, 0, false, companyId, false);
                Session["unitCostsDummy"] = dt;

                grdCostsSummary.DataBind();
            }

            // Normally executes at all postbacks
            if (grdCostsSummary.Rows.Count == 1)
            {
                UnitInformationTDS.CostInformationDataTable dt = (UnitInformationTDS.CostInformationDataTable)Session["unitCostsDummy"];
                if (dt != null)
                {
                    grdCostsSummary.Rows[0].Visible = false;
                    grdCostsSummary.Rows[0].Controls.Clear();
                }
            }
        }



        protected void AddCostsExceptionsNewEmptyFix(GridView grdView)
        {
            if (grdCostsExceptions.Rows.Count == 0)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                UnitInformationTDS.CostExceptionsInformationDataTable dt = new UnitInformationTDS.CostExceptionsInformationDataTable();
                dt.AddCostExceptionsInformationRow(Convert.ToInt32(Session["costIdSelected"]), -1, -1, "", "", 0, 0, false, companyId, false);
                Session["unitCostsExceptionsDummy"] = dt;

                grdCostsExceptions.DataBind();
            }

            // Normally executes at all postbacks
            if (grdCostsExceptions.Rows.Count == 1)
            {
                UnitInformationTDS.CostExceptionsInformationDataTable dt = (UnitInformationTDS.CostExceptionsInformationDataTable)Session["unitCostsExceptionsDummy"];
                if (dt != null)
                {
                    grdCostsExceptions.Rows[0].Visible = false;
                    grdCostsExceptions.Rows[0].Controls.Clear();
                }
            }
        }



        protected void AddCostsExceptionsNewEmptyFixSummary(GridView grdView)
        {
            if (grdCostsExceptionsSummary.Rows.Count == 0)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                UnitInformationTDS.CostExceptionsInformationDataTable dt = new UnitInformationTDS.CostExceptionsInformationDataTable();
                dt.AddCostExceptionsInformationRow(Convert.ToInt32(Session["costIdSelected"]), -1, -1, "", "", 0, 0, false, companyId, false);
                Session["unitCostsExceptionsDummy"] = dt;

                grdCostsExceptionsSummary.DataBind();
            }

            // Normally executes at all postbacks
            if (grdCostsExceptionsSummary.Rows.Count == 1)
            {
                UnitInformationTDS.CostExceptionsInformationDataTable dt = (UnitInformationTDS.CostExceptionsInformationDataTable)Session["unitCostsExceptionsDummy"];
                if (dt != null)
                {
                    grdCostsExceptionsSummary.Rows[0].Visible = false;
                    grdCostsExceptionsSummary.Rows[0].Controls.Clear();
                }
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
                        string userName = loginGateway.GetLastName(Convert.ToInt32(userId),companyId) + " " + loginGateway.GetFirstName(Convert.ToInt32(userId), companyId);

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



        protected string GetRound(object value, int decimals)
        {
            if (value != DBNull.Value)
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
            else
            {
                return "";
            }
        }



        protected string GetCountry(object country)
        {
            if (country == DBNull.Value)
            {
                return "";
            }
            else
            {
                Int64 countryId = Int64.Parse(country.ToString());

                if (countryId > 0)
                {
                    CountryGateway countryGateway = new CountryGateway();
                    countryGateway.LoadByCountryId(countryId);
                    return countryGateway.GetName(countryId);
                }
                else
                {
                    return "";
                }
            }
        }



        protected string GetState(object state)
        {
            if (state == DBNull.Value)
            {
                return "";
            }
            else
            {
                Int64 stateId = Int64.Parse(state.ToString());

                if (stateId > 0)
                {
                    ProvinceGateway provinceGateway = new ProvinceGateway();
                    provinceGateway.LoadByProvinceId(stateId);
                    return provinceGateway.GetName(stateId);
                }
                else
                {
                    return "";
                }
            }
        }

        

        private void RegisterClientScripts()
        {
            // Register content variables
            string contentVariables = "";
            contentVariables += "var hdfUnitIdId = '" + hdfUnitId.ClientID + "';";
            contentVariables += "var hdfActiveTabId = '" + hdfActiveTab.ClientID + "';";
            contentVariables += "var tkrmTopId = '" + tkrmTop.ClientID + "';"; 

            // Publishing body's OnKeyDown event 
            HtmlGenericControl bodyUnload = (HtmlGenericControl)Page.Master.FindControl("myBody");
            bodyUnload.Attributes.Add("OnKeyDown", "OnKeyDown(event);");

            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./units_edit.js");
        }



        private void StoreNavigatorState()
        {
            ViewState["navigatorState"] = "&columns_to_display=" + Request.QueryString["columns_to_display"] + "&search_ddlCondition1=" + Request.QueryString["search_ddlCondition1"] + "&search_tbxCondition1=" + Request.QueryString["search_tbxCondition1"] + "&search_ddlView=" + Request.QueryString["search_ddlView"] + "&search_sort_by=" + Request.QueryString["search_sort_by"] + "&btn_origin=" + Request.QueryString["btn_origin"];
        }



        private string GetNavigatorState()
        {
            return (string)ViewState["navigatorState"];
        }



        private string GetNavigatorStateForServices()
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
               
                
        
        #region Load Functions

        private void LoadUnitData(int companyId)
        {
            // Get unitId
            int unitId = Int32.Parse(hdfUnitId.Value);

            // Load Data
            LoadBasicData(unitId);
            LoadDetailedData(unitId);
            LoadChecklitData(unitId);
            LoadServiceData(unitId);
            LoadNotes();
        }



        private void LoadBasicData(int unitId)
        {
            UnitInformationUnitDetailsGateway unitInformationUnitDetailsGateway = new UnitInformationUnitDetailsGateway(unitInformationTDS);
            if (unitInformationUnitDetailsGateway.Table.Rows.Count > 0)
            {
                // Load unit basic data
                tbxUnitState.Text = unitInformationUnitDetailsGateway.GetState(unitId);
                tbxCode.Text = unitInformationUnitDetailsGateway.GetUnitCode(unitId);
                tbxDescription.Text = unitInformationUnitDetailsGateway.GetDescription(unitId);
                tbxVinSn.Text = unitInformationUnitDetailsGateway.GetVin(unitId);
                tbxManufacturer.Text = unitInformationUnitDetailsGateway.GetManufacturer(unitId);
                tbxModel.Text = unitInformationUnitDetailsGateway.GetModel(unitId);
                tbxYear.Text = unitInformationUnitDetailsGateway.GetYear_(unitId);
                if (unitInformationUnitDetailsGateway.GetIsTowable(unitId)) cbxIsTowable.Checked = true; else cbxIsTowable.Checked = false;
                if (!String.IsNullOrEmpty(unitInformationUnitDetailsGateway.GetInsuranceClass(unitId))) ddlInsuranceClass.SelectedValue = unitInformationUnitDetailsGateway.GetInsuranceClass(unitId);
                if (unitInformationUnitDetailsGateway.GetInsuranceClass(unitId) == "Ryder Specified")
                {
                    lblRyderSpecified.Visible = true;
                    tbxRyderSpecified.Visible = true;                    
                    tbxRyderSpecified.Text = unitInformationUnitDetailsGateway.GetInsuranceClassRyderSpecified(unitId);
                    upnlRyderSpecifiedLabel.Update();
                    upnlRyderSpecified.Update();
                }

                // Load for General Tab
                if (upnlGeneralDataEdit.Visible)
                {
                    tbxPurchasePrice.Text = ""; if (unitInformationUnitDetailsGateway.GetPurchasePrice(unitId).HasValue) tbxPurchasePrice.Text = Math.Round(unitInformationUnitDetailsGateway.GetPurchasePrice(unitId).Value, 2).ToString();
                    tkrdpScrapDate.SelectedDate = null; if (unitInformationUnitDetailsGateway.GetScrapDate(unitId).HasValue) tkrdpScrapDate.SelectedDate = (DateTime)unitInformationUnitDetailsGateway.GetScrapDate(unitId);
                    tbxSaleProceeds.Text = ""; if (unitInformationUnitDetailsGateway.GetSaleProceeds(unitId).HasValue) tbxSaleProceeds.Text = Math.Round(unitInformationUnitDetailsGateway.GetSaleProceeds(unitId).Value, 2).ToString();
                }
                else
                {
                    tbxPurchasePriceSummary.Text = ""; if (unitInformationUnitDetailsGateway.GetPurchasePrice(unitId).HasValue) tbxPurchasePriceSummary.Text = Math.Round(unitInformationUnitDetailsGateway.GetPurchasePrice(unitId).Value, 2).ToString();
                    tbxScrapDateSummary.Text = ""; if (unitInformationUnitDetailsGateway.GetScrapDate(unitId).HasValue) tbxScrapDateSummary.Text = unitInformationUnitDetailsGateway.GetScrapDate(unitId).Value.ToShortDateString();
                    tbxSaleProceedsSummary.Text = ""; if (unitInformationUnitDetailsGateway.GetSaleProceeds(unitId).HasValue) tbxSaleProceedsSummary.Text = Math.Round(unitInformationUnitDetailsGateway.GetSaleProceeds(unitId).Value, 2).ToString();
                }
            }
        }



        private void LoadDetailedData(int unitId)
        {
            UnitInformationUnitDetailsGateway unitInformationUnitDetailsGateway = new UnitInformationUnitDetailsGateway(unitInformationTDS);
            if (unitInformationUnitDetailsGateway.Table.Rows.Count > 0)
            {
                // Load for General Tab
                if (upnlGeneralDataEdit.Visible)
                {
                    if (unitInformationUnitDetailsGateway.GetAcquisitionDate(unitId).HasValue)
                    {
                        tkrdpAcquisitionDate.SelectedDate = unitInformationUnitDetailsGateway.GetAcquisitionDate(unitId);
                    }

                    if (unitInformationUnitDetailsGateway.GetDispositionDate(unitId).HasValue)
                    {
                        tkrdpDispositionDate.SelectedDate = unitInformationUnitDetailsGateway.GetDispositionDate(unitId);
                    }

                    tbxDispositionReason.Text = unitInformationUnitDetailsGateway.GetDispositionReason(unitId);
                    int companyLevelId = unitInformationUnitDetailsGateway.GetCompanyLevelId(unitId);

                    GetNodeForCategory(tvCategoriesRoot.Nodes, 0);
                    GetNodeForCompanyLevels(tvCompanyLevelsRoot.Nodes, 0, companyLevelId);

                    foreach (TreeNode nodes in tvCategoriesRoot.Nodes)
                    {
                        GetCategoriesParent(nodes);
                    }

                    foreach (TreeNode nodes in tvCompanyLevelsRoot.Nodes)
                    {
                        GetCompanyLevelsParent(nodes);
                    }
                }
                else
                {
                    if (unitInformationUnitDetailsGateway.GetAcquisitionDate(unitId).HasValue) tbxAcquisitionDateSummary.Text = ((DateTime)unitInformationUnitDetailsGateway.GetAcquisitionDate(unitId)).ToShortDateString();
                    if (unitInformationUnitDetailsGateway.GetDispositionDate(unitId).HasValue) tbxDispositionDateSummary.Text = ((DateTime)unitInformationUnitDetailsGateway.GetDispositionDate(unitId)).ToShortDateString();
                    tbxDispositionReasonSummary.Text = unitInformationUnitDetailsGateway.GetDispositionReason(unitId);
                    int companyLevelId = unitInformationUnitDetailsGateway.GetCompanyLevelId(unitId);

                    GetNodeForCategory(tvCategoriesRootSummary.Nodes, 0);
                    GetNodeForCompanyLevels(tvCompanyLevelsRootSummary.Nodes, 0, companyLevelId);

                    foreach (TreeNode nodes in tvCategoriesRootSummary.Nodes)
                    {
                        GetCategoriesParent(nodes);
                    }

                    foreach (TreeNode nodes in tvCompanyLevelsRootSummary.Nodes)
                    {
                        GetCompanyLevelsParent(nodes);
                    }
                }

                // Load for Plate and Technical Tabs
                if (unitInformationUnitDetailsGateway.GetType(unitId) == "Vehicle")
                {
                    if (upnlPlateDataEdit.Visible)
                    {
                        if (unitInformationUnitDetailsGateway.GetLicenseCountry(unitId).HasValue)
                        {
                            Int64 countryId = (Int64)unitInformationUnitDetailsGateway.GetLicenseCountry(unitId);
                            ddlLicenseCountry.SelectedValue = countryId.ToString();

                            if (unitInformationUnitDetailsGateway.GetLicenseState(unitId).HasValue)
                            {
                                Int64? stateId = null;

                                stateId = unitInformationUnitDetailsGateway.GetLicenseState(unitId);

                                if (stateId.HasValue)
                                {
                                    tbxLicenseState.Text = "";
                                    hdfLicenseStateId.Value = "";

                                    if (stateId.ToString() == "12435")
                                    {
                                        tbxLicenseState.Text = "Ontario";
                                        hdfLicenseStateId.Value = "12435";
                                    }
                                    else
                                    {
                                        if (ddlLicenseCountry.SelectedValue == "2")
                                        {
                                            tbxLicenseState.Text = "Michigan";
                                            hdfLicenseStateId.Value = "84026";
                                        }
                                    }
                                }
                            }
                        }

                        tbxLicensePlateNumber.Text = unitInformationUnitDetailsGateway.GetLicensePlateNumbver(unitId);
                    }
                    else
                    {
                        if (unitInformationUnitDetailsGateway.GetLicenseCountry(unitId).HasValue)
                        {
                            Int64 countryId = (Int64)unitInformationUnitDetailsGateway.GetLicenseCountry(unitId);
                            CountryGateway countryGateway = new CountryGateway();
                            countryGateway.LoadByCountryId(countryId);
                            tbxLicenseCountrySummary.Text = countryGateway.GetName(countryId);
                        }

                        if (unitInformationUnitDetailsGateway.GetLicenseState(unitId).HasValue)
                        {
                            Int64 stateId = (Int64)unitInformationUnitDetailsGateway.GetLicenseState(unitId);
                            ProvinceGateway provinceGateway = new ProvinceGateway();
                            provinceGateway.LoadByProvinceId(stateId);
                            tbxLicenseStateSummary.Text = provinceGateway.GetName(stateId);
                        }

                        tbxLicensePlateNumberSummary.Text = unitInformationUnitDetailsGateway.GetLicensePlateNumbver(unitId);
                    }

                    if (upnlTechnicalEdit.Visible)
                    {
                        tbxActualWeight.Text = unitInformationUnitDetailsGateway.GetActualWeight(unitId);
                        tbxRegisteredWeight.Text = unitInformationUnitDetailsGateway.GetRegisteredWeight(unitId);
                        tbxTireSizeFront.Text = unitInformationUnitDetailsGateway.GetTireSizeFront(unitId);
                        tbxTireSizeBack.Text = unitInformationUnitDetailsGateway.GetTireSizeBack(unitId);
                        ddlNumberOfAxes.SelectedValue = unitInformationUnitDetailsGateway.GetNumberOfAxes(unitId);
                        ddlFuelType.SelectedValue = unitInformationUnitDetailsGateway.GetFuelType(unitId);
                        tbxBeginningOdometer.Text = unitInformationUnitDetailsGateway.GetBeginningOdometer(unitId);
                        cbxIsReeferEquipped.Checked = unitInformationUnitDetailsGateway.GetIsReeferEquipped(unitId);
                        cbxIsPtoEquipped.Checked = unitInformationUnitDetailsGateway.GetIsPTOEquipped(unitId);
                    }
                    else
                    {
                        tbxActualWeightSummary.Text = unitInformationUnitDetailsGateway.GetActualWeight(unitId);
                        tbxRegisteredWeightSummary.Text = unitInformationUnitDetailsGateway.GetRegisteredWeight(unitId);
                        tbxTireSizeFrontSummary.Text = unitInformationUnitDetailsGateway.GetTireSizeFront(unitId);
                        tbxTireSizeBackSummary.Text = unitInformationUnitDetailsGateway.GetTireSizeBack(unitId);
                        tbxNumberOfAxesSummary.Text = unitInformationUnitDetailsGateway.GetNumberOfAxes(unitId);
                        tbxFuelTypeSummary.Text = unitInformationUnitDetailsGateway.GetFuelType(unitId);
                        tbxBeginningOdometerSummary.Text = unitInformationUnitDetailsGateway.GetBeginningOdometer(unitId);
                        cbxIsReeferEquippedSummary.Checked = unitInformationUnitDetailsGateway.GetIsReeferEquipped(unitId);
                        cbxIsPtoEquippedSummary.Checked = unitInformationUnitDetailsGateway.GetIsPTOEquipped(unitId);
                    }
                }

                // Load for Ownership tab
                if (upnlOwnershipEdit.Visible)
                {
                    ddlOwnerType.SelectedValue = unitInformationUnitDetailsGateway.GetOwnerType(unitId);
                    tbxOwnerName.Text = unitInformationUnitDetailsGateway.GetOwnerName(unitId);
                    tbxOwnerContact.Text = unitInformationUnitDetailsGateway.GetOwnerContact(unitId);

                    if (unitInformationUnitDetailsGateway.GetOwnerCountry(unitId).HasValue)
                    {
                        Int64 countryId = (Int64)unitInformationUnitDetailsGateway.GetOwnerCountry(unitId);
                        ddlOwnerCountry.SelectedValue = countryId.ToString();

                        ProvinceList provinceList = new ProvinceList();
                        provinceList.LoadByCountryIdAndAddItem(-1, "(Select a state)", countryId);
                        ddlOwnerState.DataSource = provinceList.Table;
                        ddlOwnerState.DataValueField = "ProvinceID";
                        ddlOwnerState.DataTextField = "Name";
                        ddlOwnerState.DataBind();

                        if (unitInformationUnitDetailsGateway.GetOwnerState(unitId).HasValue)
                        {
                            Int64 stateId = (Int64)unitInformationUnitDetailsGateway.GetOwnerState(unitId);
                            ddlOwnerState.SelectedValue = stateId.ToString();
                        }
                    }
                }
                else
                {
                    tbxOwnerTypeSummary.Text = unitInformationUnitDetailsGateway.GetOwnerType(unitId);
                    tbxOwnerNameSummary.Text = unitInformationUnitDetailsGateway.GetOwnerName(unitId);
                    tbxContactInfoSummary.Text = unitInformationUnitDetailsGateway.GetOwnerContact(unitId);

                    if (unitInformationUnitDetailsGateway.GetOwnerCountry(unitId).HasValue)
                    {
                        Int64 countryId = (Int64)unitInformationUnitDetailsGateway.GetOwnerCountry(unitId);
                        CountryGateway countryGateway = new CountryGateway();
                        countryGateway.LoadByCountryId(countryId);
                        tbxOwnerCountrySummary.Text = countryGateway.GetName(countryId);

                        if (unitInformationUnitDetailsGateway.GetOwnerState(unitId).HasValue)
                        {
                            Int64 stateId = (Int64)unitInformationUnitDetailsGateway.GetOwnerState(unitId);
                            ProvinceGateway provinceGateway = new ProvinceGateway();
                            provinceGateway.LoadByProvinceId(stateId);
                            tbxOwnerStateSummary.Text = provinceGateway.GetName(stateId);
                        }
                    }                    
                }

                // Load for Inspection Tab (Qualification data)
                if (upnlInspectionEdit.Visible)
                {
                    if (unitInformationUnitDetailsGateway.GetQualifiedDate(unitId).HasValue)
                    {
                        tkrdpQualifiedDate.SelectedDate = unitInformationUnitDetailsGateway.GetQualifiedDate(unitId);
                    }

                    if (unitInformationUnitDetailsGateway.GetNotQualifiedDate(unitId).HasValue)
                    {
                        tkrdpNotQualifiedDate.SelectedDate = (DateTime)unitInformationUnitDetailsGateway.GetNotQualifiedDate(unitId);
                    }

                    tbxIfNotQualifiedExplain.Text = unitInformationUnitDetailsGateway.GetNotQualifiedExplain(unitId);
                }
                else
                {
                    if (unitInformationUnitDetailsGateway.GetQualifiedDate(unitId).HasValue) tbxQualifiedDateSummary.Text = ((DateTime)unitInformationUnitDetailsGateway.GetQualifiedDate(unitId)).ToShortDateString();
                    if (unitInformationUnitDetailsGateway.GetNotQualifiedDate(unitId).HasValue) tbxNotQualifiedDateSummary.Text = ((DateTime)unitInformationUnitDetailsGateway.GetNotQualifiedDate(unitId)).ToShortDateString();
                    tbxIfNotQualifiedExplainSummary.Text = unitInformationUnitDetailsGateway.GetNotQualifiedExplain(unitId);
                }
            }
        }



        private void LoadChecklitData(int unitId)
        {
            // Load
            UnitInformationTDS dataSet = new UnitInformationTDS();
            dataSet.ChecklistDetails.Merge(unitsChecklistRulesTemp, true);
            UnitInformationChecklistDetails model = new UnitInformationChecklistDetails(dataSet);

            model.Load(unitId, int.Parse(hdfCompanyId.Value));

            // Store tables
            unitsChecklistRulesTemp = (UnitInformationTDS.ChecklistDetailsDataTable)model.Table;
            Session["unitsChecklistRulesTemp"] = unitsChecklistRulesTemp;

            grdChecklistRulesInformation.DataBind();
        }



        private void LoadServiceData(int unitId)
        {
            UnitInformationTDS dataset = new UnitInformationTDS();
            dataset.ServiceDetails.Merge(unitsServicesTemp, true);
            UnitInformationServiceDetails model = new UnitInformationServiceDetails(dataset);

            model.Load(unitId, int.Parse(hdfCompanyId.Value));

            unitsServicesTemp = (UnitInformationTDS.ServiceDetailsDataTable)model.Table;
            Session["unitsServicesTemp"] = unitsServicesTemp;

            grdServices.DataBind();
        }



        private void LoadNotes()
        {
            UnitInformationUnitDetailsGateway unitInformationUnitDetailsGateway = new UnitInformationUnitDetailsGateway(unitInformationTDS);

            int? libraryCategoriesId = null; if (unitInformationUnitDetailsGateway.GetLibraryCategoriesId(int.Parse(hdfUnitId.Value)).HasValue) libraryCategoriesId = (int)unitInformationUnitDetailsGateway.GetLibraryCategoriesId(int.Parse(hdfUnitId.Value));

            if (libraryCategoriesId.HasValue)
            {
                ViewState["libraryCategoriesId"] = (int)libraryCategoriesId;
                tbxCategoryAssocited.Text = GetFullCategoryName((int)libraryCategoriesId);
                btnAssociate.Visible = false;
                btnUnassociate.Visible = true;
            }
            else
            {
                tbxCategoryAssocited.Text = "";
                btnAssociate.Visible = true;
                btnUnassociate.Visible = false;
            }
        }



        private void GrdNotesDeleteAttachment(int libraryFileId, int refId)
        {
            // Button delete functionality
            if (libraryFileId != 0)
            {
                UnitInformationNoteDetails model = new UnitInformationNoteDetails(unitInformationTDS);
                model.UpdateLibraryFilesId(int.Parse(hdfUnitId.Value), refId, null, "", "");

                LibraryFilesGateway libraryFilesGateway = new LibraryFilesGateway(libraryTDSForUnits);
                libraryFilesGateway.DeleteByLibraryFilesId(libraryFileId);

                ViewState["update"] = "no";

                Session["unitInformationTDS"] = unitInformationTDS;
                Session["libraryTDSForUnits"] = libraryTDSForUnits;

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
                string url = "./units_download_attachment.aspx?original_filename=" + Server.UrlEncode(originalFileName) + "&filename=" + Server.UrlEncode(fileName);
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
                    string url = "./units_add_attachment.aspx?source_page=units_edit.aspx&subject=" + Server.UrlEncode(subject) + "&refId=" + refId.ToString() + "&unit_id=" + hdfUnitId.Value + "&library_categories_id=" + Int32.Parse(ViewState["libraryCategoriesId"].ToString());
                    script = script + string.Format("window.open('{0}', '_blank', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=510, height=270')", url);
                    script = script + "</script>";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Notes", script, false);
                }
            }
            else
            {
                UnitInformationNoteDetails model = new UnitInformationNoteDetails(unitInformationTDS);
                refId = model.GetLastRefId();

                if (ViewState["libraryCategoriesId"] != null)
                {
                    string script = "<script language='javascript'>";
                    string url = "./units_add_attachment.aspx?source_page=units_edit.aspx&subject=" + Server.UrlEncode(subject) + "&refId=" + refId.ToString() + "&unit_id=" + hdfUnitId.Value + "&library_categories_id=" + Int32.Parse(ViewState["libraryCategoriesId"].ToString());
                    script = script + string.Format("window.open('{0}', '_blank', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=510, height=270')", url);
                    script = script + "</script>";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Notes", script, false);
                }
            }
        }



        private string GetFullCategoryName(int libraryCategoryId)
        {
            int[] libraryArray = new int[100];
            int maxDeep = 0;

            for (int index = 0; index < libraryArray.Length; index++)
            {
                libraryArray[index] = -1;
            }

            string fullCategoryName = "";
            libraryArray = GetDeepParent(libraryCategoryId, 0, maxDeep, libraryArray);

            for (int index = 0; index < 100; index++)
            {
                if (libraryArray[index] > 0)
                {
                    if (index > 0)
                    {
                        fullCategoryName = fullCategoryName + "/";
                    }

                    LibraryCategoriesGateway libraryCategoriesGateway = new LibraryCategoriesGateway();
                    libraryCategoriesGateway.LoadAllByLibraryCategoriesId(libraryArray[index], 3);//Note: COMPANY_ID
                    fullCategoryName = fullCategoryName + libraryCategoriesGateway.GetCategoryName(libraryArray[index]);
                }
            }

            return fullCategoryName;
        }



        private int[] GetDeepParent(int currentId, int deep, int maxDeep, int[] currentLibraryArray)
        {
            int[] libraryArray = currentLibraryArray;
            ViewState["currentmaxDeep"] = maxDeep;

            LibraryCategoriesGateway libraryCategoriesGateway = new LibraryCategoriesGateway();
            libraryCategoriesGateway.LoadAllByLibraryCategoriesId(currentId, 3);//Note: COMPANY_ID

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
                    libraryArray = GetDeepParent(libraryCategoriesGateway.GetParentId(currentId), deep + 1, (int)ViewState["currentmaxDeep"], libraryArray);
                    libraryArray[(int)ViewState["currentmaxDeep"] - deep] = currentId;
                    return libraryArray;
                }
            }
            else
            {
                return libraryArray;
            }
        }



        private void GetNodeForCategory(TreeNodeCollection nodes, int parentId)
        {
            Int32 thisId;
            String thisName;
            UnitsCategoryGateway unitsCategoryGateway = new UnitsCategoryGateway(null);

            DataRow[] children = categoriesTDS.Tables["LFS_FM_CATEGORY"].Select("ParentID='" + parentId + "'");

            //no child nodes, exit function
            if (children.Length == 0) return;

            foreach (DataRow child in children)
            {
                // step 1
                thisId = Convert.ToInt32(child.ItemArray[0]);

                // step 2
                thisName = Convert.ToString(child.ItemArray[2]);

                // step 3
                TreeNode newNode = new TreeNode(thisName, thisId.ToString());
                newNode.ShowCheckBox = true;
                newNode.SelectAction = TreeNodeSelectAction.None;

                //step 4
                if (unitsCategoryGateway.IsUsedInUnitCategory(Int32.Parse(hdfUnitId.Value), thisId))
                {
                    newNode.Checked = true;
                }

                // step 5
                nodes.Add(newNode);
                newNode.ToggleExpandState();

                // step 6
                GetNodeForCategory(newNode.ChildNodes, thisId);
            }
        }



        private void GetNodeForCompanyLevels(TreeNodeCollection nodes, int parentId, int companyLevelId)
        {
            Int32 thisId;
            string thisName;

            DataRow[] children = companyLevelsTDS.Tables["LFS_FM_COMPANYLEVEL"].Select("ParentID='" + parentId + "'");

            //no child nodes, exit function
            if (children.Length == 0) return;

            foreach (DataRow child in children)
            {
                // step 1
                thisId = Convert.ToInt32(child.ItemArray[0]);

                // step 2
                thisName = Convert.ToString(child.ItemArray[1]);

                // step 3
                TreeNode newNode = new TreeNode(thisName, thisId.ToString());
                newNode.ShowCheckBox = true;
                newNode.SelectAction = TreeNodeSelectAction.None;

                //step 4
                if (companyLevelId == thisId)
                {
                    newNode.Checked = true;
                }

                // step 5
                nodes.Add(newNode);
                newNode.ToggleExpandState();

                // step 6
                GetNodeForCompanyLevels(newNode.ChildNodes, thisId, companyLevelId);
            }
        }



        private void GetCategoriesParent(TreeNode node)
        {
            if (node.ChildNodes.Count > 0)
            {
                node.ShowCheckBox = false;

                foreach (TreeNode node2 in node.ChildNodes)
                {
                    GetCategoriesParent(node2);
                }
            }
        }



        private void GetCompanyLevelsParent(TreeNode node)
        {
            if (node.ChildNodes.Count > 0)
            {
                node.ShowCheckBox = false;

                foreach (TreeNode node2 in node.ChildNodes)
                {
                    GetCompanyLevelsParent(node2);
                }
            }
        }

        #endregion



        private void GetCategoriesSelected(TreeNode node)
        {
            if (node.ChildNodes.Count == 0)
            {
                if (node.Checked)
                {
                    arrayCategoriesSelectedForEdit.Add(int.Parse(node.Value));
                }
            }
            else
            {
                if (node.Checked)
                {
                    arrayCategoriesSelectedForEdit.Add(int.Parse(node.Value));
                }

                foreach (TreeNode node2 in node.ChildNodes)
                {
                    GetCategoriesSelected(node2);
                }
            }
        }



        private void GetCompanyLevelsSelected(TreeNode node)
        {
            if (node.ChildNodes.Count == 0)
            {
                if (node.Checked)
                {
                    arrayCompanyLevelsSelectedForEdit.Add(int.Parse(node.Value));
                }
            }
            else
            {
                if (node.Checked)
                {
                    arrayCompanyLevelsSelectedForEdit.Add(int.Parse(node.Value));
                }

                foreach (TreeNode node2 in node.ChildNodes)
                {
                    GetCompanyLevelsSelected(node2);
                }
            }
        }



        private void Save()
        {
            // Validate data
            bool validData = true;

            // Validate general data
            Page.Validate("general");

            if (Page.IsValid)
            {
                // Validate Ryder Specied
                if (ddlInsuranceClass.SelectedValue == "Ryder Specified")
                {
                    Page.Validate("generalSpecial");
                }

                // Validate notes tab
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

                // Validate inspections tab
                if (ValidateInspectionFooter())
                {
                    Page.Validate("inspections");
                    if (!Page.IsValid)
                    {
                        validData = false;
                    }
                }

                Page.Validate("inspectionsEdit");
                if (!Page.IsValid)
                {
                    validData = false;
                }
            }
            else
            {
                validData = false;
            }

            // For valid data
            if (validData)
            {
                // Notes Gridview, if the gridview is edition mode
                if (grdNotes.EditIndex >= 0)
                {
                    grdNotes.UpdateRow(grdNotes.EditIndex, true);
                }

                // Inspections Gridview, if the gridview is edition mode
                if (grdInspections.EditIndex >= 0)
                {
                    grdInspections.UpdateRow(grdInspections.EditIndex, true);
                }

                // Costs Gridview, if the gridview is edition mode
                if (grdCosts.EditIndex >= 0)
                {
                    grdCosts.UpdateRow(grdCosts.EditIndex, true);
                }                

                // Costs Exceptions Gridview, if the gridview is edition mode
                if (grdCostsExceptions.EditIndex >= 0)
                {
                    grdCostsExceptions.UpdateRow(grdCostsExceptions.EditIndex, true);
                }                            
                
                // If there is data at the footers
                GrdNotesAdd();
                InspectionsAddNew();
                GrdCostsAdd();
                GrdCostsExceptionsAdd();

                // Basic
                int companyId = Int32.Parse(hdfCompanyId.Value);
                int unitId = Int32.Parse(hdfUnitId.Value);

                // General
                string code = tbxCode.Text;
                string description = ""; if (tbxDescription.Text != "") description = tbxDescription.Text;
                string vin = ""; if (tbxVinSn.Text != "") vin = tbxVinSn.Text;
                string manufacturer = ""; if (tbxManufacturer.Text != "") manufacturer = tbxManufacturer.Text;
                string model = ""; if (tbxModel.Text != "") model = tbxModel.Text;
                string year = ""; if (tbxYear.Text != "") year = tbxYear.Text;
                bool isTowable = (cbxIsTowable.Checked) ? isTowable = true : isTowable = false;
                int companyLevelIdSelected = 0;
                DateTime? acquisitionDate = null; if (tkrdpAcquisitionDate.SelectedDate.HasValue) acquisitionDate = tkrdpAcquisitionDate.SelectedDate.Value;
                DateTime? dispositionDate = null; if (tkrdpDispositionDate.SelectedDate.HasValue) dispositionDate = tkrdpDispositionDate.SelectedDate.Value;
                string dispositionReason = ""; if (tbxDispositionReason.Text != "") dispositionReason = tbxDispositionReason.Text;

                foreach (int companyLevelId in arrayCompanyLevelsSelectedForEdit)
                {
                    companyLevelIdSelected = companyLevelId;
                }

                // Plate
                Int64? licenseCountry = null;
                Int64? licenceState = null;
                string licensePlateNumber = ""; if (tbxLicensePlateNumber.Text != "") licensePlateNumber = tbxLicensePlateNumber.Text;
                string apportionedTagNumber = ""; // This field will not be shown

                // Technical
                string actualWeight = "";
                string registeredWeight = "";
                string tireSizeFront = "";
                string tireSizeBack = "";
                string numberOfAxes = "";
                string fuelType = "";
                string beginningOdometer = ""; if (tbxBeginningOdometer.Text != "") beginningOdometer = tbxBeginningOdometer.Text;
                bool isRefeerEquipped = cbxIsReeferEquipped.Checked;
                bool isPtoEquipped = cbxIsPtoEquipped.Checked;

                if (hdfUnitType.Value == "Vehicle")
                {
                    if (ddlLicenseCountry.SelectedValue != "-1")
                    {
                        licenseCountry = Int64.Parse(ddlLicenseCountry.SelectedValue);

                        if (licenseCountry.ToString() == "1")
                        { 
                            // Ontario
                            hdfLicenseStateId.Value = "12435";
                            licenceState = Int64.Parse(hdfLicenseStateId.Value);
                        }
                        else
                        {
                            if (licenseCountry.ToString() == "2")
                            {
                                // Michigan
                                hdfLicenseStateId.Value = "84026";
                                licenceState = Int64.Parse(hdfLicenseStateId.Value);
                            }
                        }                                               
                    }

                    actualWeight = tbxActualWeight.Text;
                    registeredWeight = tbxRegisteredWeight.Text;
                    tireSizeFront = tbxTireSizeFront.Text;
                    tireSizeBack = tbxTireSizeBack.Text;
                    numberOfAxes = ddlNumberOfAxes.SelectedValue;
                    fuelType = ddlFuelType.SelectedValue;
                }

                // Ownership
                string ownerType = ddlOwnerType.SelectedValue;
                Int64? ownerCountry = null;
                Int64? ownerState = null;
                string ownerName = ""; if (tbxOwnerName.Text != "") ownerName = tbxOwnerName.Text;
                string ownerContact = ""; if (tbxOwnerContact.Text != "") ownerContact = tbxOwnerContact.Text;

                if (ddlOwnerCountry.SelectedValue != "-1")
                {
                    ownerCountry = Int64.Parse(ddlOwnerCountry.SelectedValue);

                    if (ddlOwnerState.SelectedValue != "-1")
                    {
                        ownerState = Int64.Parse(ddlOwnerState.SelectedValue);
                    }
                }

                // Qualification Details
                DateTime? qualifiedDate = null; if (tkrdpQualifiedDate.SelectedDate.HasValue) qualifiedDate = tkrdpQualifiedDate.SelectedDate.Value;
                DateTime? notQualifiedDate = null; if (tkrdpNotQualifiedDate.SelectedDate.HasValue) notQualifiedDate = tkrdpNotQualifiedDate.SelectedDate.Value;
                string notQualifiedExplain = ""; if (tbxIfNotQualifiedExplain.Text != "") notQualifiedExplain = tbxIfNotQualifiedExplain.Text;

                string insuranceClass = ddlInsuranceClass.SelectedValue;
                string insuranceClassRyderSpecified = "";
                if (ddlInsuranceClass.SelectedValue == "Ryder Specified")
                {
                    insuranceClassRyderSpecified = tbxRyderSpecified.Text;
                }
                decimal? purchasePrice = null; if (tbxPurchasePrice.Text != "") purchasePrice = Convert.ToDecimal(tbxPurchasePrice.Text);
                DateTime? scrapDate = null; if (tkrdpScrapDate.SelectedDate.HasValue) scrapDate = tkrdpScrapDate.SelectedDate.Value;
                decimal? saleProceeds = null; if (tbxSaleProceeds.Text != "") saleProceeds = Convert.ToDecimal(tbxSaleProceeds.Text);

                UnitInformationUnitDetailsGateway UnitInformationUnitDetailsGateway = new UnitInformationUnitDetailsGateway(unitInformationTDS);
                int? libraryCategoriesId = null; if (UnitInformationUnitDetailsGateway.GetLibraryCategoriesId(int.Parse(hdfUnitId.Value)).HasValue) libraryCategoriesId = (int)UnitInformationUnitDetailsGateway.GetLibraryCategoriesId(int.Parse(hdfUnitId.Value));

                // Update unit data
                UnitInformationUnitDetails unitInformationUnitDetails = new UnitInformationUnitDetails(unitInformationTDS);
                unitInformationUnitDetails.Update(unitId, code, description, vin, manufacturer, model, year, isTowable, companyLevelIdSelected, acquisitionDate, dispositionDate, dispositionReason, licenseCountry, licenceState, licensePlateNumber, apportionedTagNumber, actualWeight, registeredWeight, tireSizeFront, tireSizeBack, numberOfAxes, fuelType, beginningOdometer, isRefeerEquipped, isPtoEquipped, ownerType, ownerCountry, ownerState, ownerName, ownerContact, qualifiedDate, notQualifiedDate, notQualifiedExplain, insuranceClass, insuranceClassRyderSpecified, purchasePrice, scrapDate, saleProceeds, libraryCategoriesId);

                Session["arrayCategoriesSelectedForEdit"] = arrayCategoriesSelectedForEdit;
                Session["arrayCompanyLevelsSelectedForEdit"] = arrayCompanyLevelsSelectedForEdit;

                // Store dataset
                Session["unitInformationTDS"] = unitInformationTDS;
                Session["categoriesTDSForUnits"] = categoriesTDS;
                Session["companyLevelsTDS"] = companyLevelsTDS;

                Session.Remove("libraryTDSForUnits");

                // Update database
                UpdateDatabase();

                ViewState["update"] = "yes";

                // Redirect
                string url = "";
                if (Request.QueryString["source_page"] == "units_navigator2.aspx" || Request.QueryString["source_page"] == "units_add.aspx")
                {
                    url = "./units_navigator2.aspx?source_page=units_edit.aspx&unit_id=" + hdfUnitId.Value + GetNavigatorState() + "&update=yes";
                }

                if (Request.QueryString["source_page"] == "units_summary.aspx")
                {
                    url = "./units_summary.aspx?source_page=units_edit.aspx&unit_id=" + hdfUnitId.Value + "&unit_type=" + hdfUnitType.Value + "&unit_state=" + hdfUnitState.Value + "&active_tab=" + hdfActiveTab.Value + GetNavigatorState() + "&update=yes";
                }

                Response.Redirect(url);
            }            
        }



        private void Save2()
        {
            // Validate data
            bool validData = true;            

            // For valid data
            if (validData)
            {
                // Validate Ryder Specied
                if (ddlInsuranceClass.SelectedValue == "Ryder Specified")
                {
                    Page.Validate("generalSpecial");
                }

                // Notes Gridview, if the gridview is edition mode
                if (grdNotes.EditIndex >= 0)
                {
                    grdNotes.UpdateRow(grdNotes.EditIndex, true);
                }

                // Inspections Gridview, if the gridview is edition mode
                if (grdInspections.EditIndex >= 0)
                {
                    grdInspections.UpdateRow(grdInspections.EditIndex, true);
                }

                // Costs Gridview, if the gridview is edition mode
                if (grdCosts.EditIndex >= 0)
                {
                    grdCosts.UpdateRow(grdCosts.EditIndex, true);
                }

                // Costs Exceptions Gridview, if the gridview is edition mode
                if (grdCostsExceptions.EditIndex >= 0)
                {
                    grdCostsExceptions.UpdateRow(grdCostsExceptions.EditIndex, true);
                }

                // If there is data at the footers
                GrdNotesAdd();
                InspectionsAddNew();
                GrdCostsAdd();
                GrdCostsExceptionsAdd();

                // Basic
                int companyId = Int32.Parse(hdfCompanyId.Value);
                int unitId = Int32.Parse(hdfUnitId.Value);

                // General
                string code = tbxCode.Text;
                string description = ""; if (tbxDescription.Text != "") description = tbxDescription.Text;
                string vin = ""; if (tbxVinSn.Text != "") vin = tbxVinSn.Text;
                string manufacturer = ""; if (tbxManufacturer.Text != "") manufacturer = tbxManufacturer.Text;
                string model = ""; if (tbxModel.Text != "") model = tbxModel.Text;
                string year = ""; if (tbxYear.Text != "") year = tbxYear.Text;
                bool isTowable = (cbxIsTowable.Checked) ? isTowable = true : isTowable = false;
                int companyLevelIdSelected = 0;
                arrayCompanyLevelsSelectedForEdit.Clear();
                foreach (TreeNode nodes in tvCompanyLevelsRoot.Nodes)
                {
                    GetCompanyLevelsSelected(nodes);
                }
                DateTime? acquisitionDate = null; if (tkrdpAcquisitionDate.SelectedDate.HasValue) acquisitionDate = tkrdpAcquisitionDate.SelectedDate.Value;
                DateTime? dispositionDate = null; if (tkrdpDispositionDate.SelectedDate.HasValue) dispositionDate = tkrdpDispositionDate.SelectedDate.Value;
                string dispositionReason = ""; if (tbxDispositionReason.Text != "") dispositionReason = tbxDispositionReason.Text;

                foreach (int companyLevelId in arrayCompanyLevelsSelectedForEdit)
                {
                    companyLevelIdSelected = companyLevelId;
                }

                // Plate
                Int64? licenseCountry = null;
                Int64? licenceState = null;
                string licensePlateNumber = ""; if (tbxLicensePlateNumber.Text != "") licensePlateNumber = tbxLicensePlateNumber.Text;
                string apportionedTagNumber = ""; // This field will not be shown

                // Technical
                string actualWeight = "";
                string registeredWeight = "";
                string tireSizeFront = "";
                string tireSizeBack = "";
                string numberOfAxes = "";
                string fuelType = "";
                string beginningOdometer = ""; if (tbxBeginningOdometer.Text != "") beginningOdometer = tbxBeginningOdometer.Text;
                bool isRefeerEquipped = cbxIsReeferEquipped.Checked;
                bool isPtoEquipped = cbxIsPtoEquipped.Checked;

                if (hdfUnitType.Value == "Vehicle")
                {
                    if (ddlLicenseCountry.SelectedValue != "-1")
                    {
                        licenseCountry = Int64.Parse(ddlLicenseCountry.SelectedValue);

                        if (licenseCountry.ToString() == "1")
                        {
                            // Ontario
                            hdfLicenseStateId.Value = "12435";
                            licenceState = Int64.Parse(hdfLicenseStateId.Value);
                        }
                        else
                        {
                            if (licenseCountry.ToString() == "2")
                            {
                                // Michigan
                                hdfLicenseStateId.Value = "84026";
                                licenceState = Int64.Parse(hdfLicenseStateId.Value);
                            }
                        }
                    }

                    actualWeight = tbxActualWeight.Text;
                    registeredWeight = tbxRegisteredWeight.Text;
                    tireSizeFront = tbxTireSizeFront.Text;
                    tireSizeBack = tbxTireSizeBack.Text;
                    numberOfAxes = ddlNumberOfAxes.SelectedValue;
                    fuelType = ddlFuelType.SelectedValue;
                }

                // Ownership
                string ownerType = ddlOwnerType.SelectedValue;
                Int64? ownerCountry = null;
                Int64? ownerState = null;
                string ownerName = ""; if (tbxOwnerName.Text != "") ownerName = tbxOwnerName.Text;
                string ownerContact = ""; if (tbxOwnerContact.Text != "") ownerContact = tbxOwnerContact.Text;

                if (ddlOwnerCountry.SelectedValue != "-1")
                {
                    ownerCountry = Int64.Parse(ddlOwnerCountry.SelectedValue);

                    if (ddlOwnerState.SelectedValue != "-1")
                    {
                        ownerState = Int64.Parse(ddlOwnerState.SelectedValue);
                    }
                }

                // Qualification Details
                DateTime? qualifiedDate = null; if (tkrdpQualifiedDate.SelectedDate.HasValue) qualifiedDate = tkrdpQualifiedDate.SelectedDate.Value;
                DateTime? notQualifiedDate = null; if (tkrdpNotQualifiedDate.SelectedDate.HasValue) notQualifiedDate = tkrdpNotQualifiedDate.SelectedDate.Value;
                string notQualifiedExplain = ""; if (tbxIfNotQualifiedExplain.Text != "") notQualifiedExplain = tbxIfNotQualifiedExplain.Text;

                string insuranceClass = ddlInsuranceClass.SelectedValue;
                string insuranceClassRyderSpecified = "";
                if (ddlInsuranceClass.SelectedValue == "Ryder Specified")
                {
                    insuranceClassRyderSpecified = tbxRyderSpecified.Text;
                }
                decimal? purchasePrice = null; if (tbxPurchasePrice.Text != "") purchasePrice = Convert.ToDecimal(tbxPurchasePrice.Text);
                DateTime? scrapDate = null; if (tkrdpScrapDate.SelectedDate.HasValue) scrapDate = tkrdpScrapDate.SelectedDate.Value;
                decimal? saleProceeds = null; if (tbxSaleProceeds.Text != "") saleProceeds = Convert.ToDecimal(tbxSaleProceeds.Text);

                UnitInformationUnitDetailsGateway UnitInformationUnitDetailsGateway = new UnitInformationUnitDetailsGateway(unitInformationTDS);
                int? libraryCategoriesId = null; if (UnitInformationUnitDetailsGateway.GetLibraryCategoriesId(int.Parse(hdfUnitId.Value)).HasValue) libraryCategoriesId = (int)UnitInformationUnitDetailsGateway.GetLibraryCategoriesId(int.Parse(hdfUnitId.Value));

                // Update unit data
                UnitInformationUnitDetails unitInformationUnitDetails = new UnitInformationUnitDetails(unitInformationTDS);
                unitInformationUnitDetails.Update(unitId, code, description, vin, manufacturer, model, year, isTowable, companyLevelIdSelected, acquisitionDate, dispositionDate, dispositionReason, licenseCountry, licenceState, licensePlateNumber, apportionedTagNumber, actualWeight, registeredWeight, tireSizeFront, tireSizeBack, numberOfAxes, fuelType, beginningOdometer, isRefeerEquipped, isPtoEquipped, ownerType, ownerCountry, ownerState, ownerName, ownerContact, qualifiedDate, notQualifiedDate, notQualifiedExplain, insuranceClass, insuranceClassRyderSpecified, purchasePrice, scrapDate, saleProceeds, libraryCategoriesId);

                Session["arrayCategoriesSelectedForEdit"] = arrayCategoriesSelectedForEdit;
                Session["arrayCompanyLevelsSelectedForEdit"] = arrayCompanyLevelsSelectedForEdit;

                // Store dataset
                Session["unitInformationTDS"] = unitInformationTDS;
                Session["categoriesTDSForUnits"] = categoriesTDS;
                Session["companyLevelsTDS"] = companyLevelsTDS;

                ViewState["update"] = "no";
            }
        }



        private void Apply()
        {
            // Validate data
            bool validData = true;

            // Validate general data
            Page.Validate("general");

            if (Page.IsValid)
            {
                // Validate Ryder Specied
                if (ddlInsuranceClass.SelectedValue == "Ryder Specified")
                {
                    Page.Validate("generalSpecial");
                }

                // Validate notes tab
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

                // Validate inspections tab
                if (ValidateInspectionFooter())
                {
                    Page.Validate("inspections");
                    if (!Page.IsValid)
                    {
                        validData = false;
                    }
                }

                Page.Validate("inspectionsEdit");
                if (!Page.IsValid)
                {
                    validData = false;
                }
            }
            else
            {
                validData = false;
            }

            // For valid data
            if (validData)
            {
                // Notes Gridview, if the gridview is edition mode
                if (grdNotes.EditIndex >= 0)
                {
                    grdNotes.UpdateRow(grdNotes.EditIndex, true);
                }

                // Inspections Gridview, if the gridview is edition mode
                if (grdInspections.EditIndex >= 0)
                {
                    grdInspections.UpdateRow(grdInspections.EditIndex, true);
                }

                // Costs Gridview, if the gridview is edition mode
                if (grdCosts.EditIndex >= 0)
                {
                    grdCosts.UpdateRow(grdCosts.EditIndex, true);
                }

                // Costs Exceptions Gridview, if the gridview is edition mode
                if (grdCostsExceptions.EditIndex >= 0)
                {
                    grdCostsExceptions.UpdateRow(grdCostsExceptions.EditIndex, true);
                }

                // If there is data at the footers
                GrdNotesAdd();
                InspectionsAddNew();
                GrdCostsAdd();
                GrdCostsExceptionsAdd();
                
                // Basic
                int companyId = Int32.Parse(hdfCompanyId.Value);
                int unitId = Int32.Parse(hdfUnitId.Value);

                // General
                string code = tbxCode.Text;
                string description = ""; if (tbxDescription.Text != "") description = tbxDescription.Text;
                string vin = ""; if (tbxVinSn.Text != "") vin = tbxVinSn.Text;
                string manufacturer = ""; if (tbxManufacturer.Text != "") manufacturer = tbxManufacturer.Text;
                string model = ""; if (tbxModel.Text != "") model = tbxModel.Text;
                string year = ""; if (tbxYear.Text != "") year = tbxYear.Text;
                bool isTowable = (cbxIsTowable.Checked) ? isTowable = true : isTowable = false;
                int companyLevelIdSelected = 0;
                DateTime? acquisitionDate = null; if (tkrdpAcquisitionDate.SelectedDate.HasValue) acquisitionDate = tkrdpAcquisitionDate.SelectedDate.Value; //DateTime.Parse(tbxAcquisitionDate.Text);
                DateTime? dispositionDate = null; if (tkrdpDispositionDate.SelectedDate.HasValue) dispositionDate = tkrdpDispositionDate.SelectedDate.Value; //DateTime.Parse(tbxDispositionDate.Text);
                string dispositionReason = ""; if (tbxDispositionReason.Text != "") dispositionReason = tbxDispositionReason.Text;

                foreach (int companyLevelId in arrayCompanyLevelsSelectedForEdit)
                {
                    companyLevelIdSelected = companyLevelId;
                }

                // Plate
                Int64? licenseCountry = null;
                Int64? licenceState = null;
                string licensePlateNumber = ""; if (tbxLicensePlateNumber.Text != "") licensePlateNumber = tbxLicensePlateNumber.Text;
                string apportionedTagNumber = ""; 

                // Technical
                string actualWeight = "";
                string registeredWeight = "";
                string tireSizeFront = "";
                string tireSizeBack = "";
                string numberOfAxes = "";
                string fuelType = "";
                string beginningOdometer = ""; if (tbxBeginningOdometer.Text != "") beginningOdometer = tbxBeginningOdometer.Text;
                bool isRefeerEquipped = cbxIsReeferEquipped.Checked;
                bool isPtoEquipped = cbxIsPtoEquipped.Checked;

                if (hdfUnitType.Value == "Vehicle")
                {
                    if (ddlLicenseCountry.SelectedValue != "-1")
                    {
                        licenseCountry = Int64.Parse(ddlLicenseCountry.SelectedValue);

                        if (licenseCountry.ToString() == "1")
                        {
                            // Ontario
                            hdfLicenseStateId.Value = "12435";
                            licenceState = Int64.Parse(hdfLicenseStateId.Value);
                        }
                        else
                        {
                            if (licenseCountry.ToString() == "2")
                            {
                                // Michigan
                                hdfLicenseStateId.Value = "84026";
                                licenceState = Int64.Parse(hdfLicenseStateId.Value);
                            }
                        } 
                    }

                    actualWeight = tbxActualWeight.Text;
                    registeredWeight = tbxRegisteredWeight.Text;
                    tireSizeFront = tbxTireSizeFront.Text;
                    tireSizeBack = tbxTireSizeBack.Text;
                    numberOfAxes = ddlNumberOfAxes.SelectedValue;
                    fuelType = ddlFuelType.SelectedValue;
                }

                // Ownership
                string ownerType = ddlOwnerType.SelectedValue;
                Int64? ownerCountry = null;
                Int64? ownerState = null;
                string ownerName = ""; if (tbxOwnerName.Text != "") ownerName = tbxOwnerName.Text;
                string ownerContact = ""; if (tbxOwnerContact.Text != "") ownerContact = tbxOwnerContact.Text;

                if (ddlOwnerCountry.SelectedValue != "-1")
                {
                    ownerCountry = Int64.Parse(ddlOwnerCountry.SelectedValue);

                    if (ddlOwnerState.SelectedValue != "-1")
                    {
                        ownerState = Int64.Parse(ddlOwnerState.SelectedValue);
                    }
                }

                // Qualification Details
                DateTime? qualifiedDate = null; if (tkrdpQualifiedDate.SelectedDate.HasValue) qualifiedDate = tkrdpQualifiedDate.SelectedDate.Value ;
                DateTime? notQualifiedDate = null; if (tkrdpNotQualifiedDate.SelectedDate.HasValue) notQualifiedDate = tkrdpNotQualifiedDate.SelectedDate.Value;
                string notQualifiedExplain = ""; if (tbxIfNotQualifiedExplain.Text != "") notQualifiedExplain = tbxIfNotQualifiedExplain.Text;

                string insuranceClass = ddlInsuranceClass.SelectedValue;
                string insuranceClassRyderSpecified = "";
                if (ddlInsuranceClass.SelectedValue == "Ryder Specified")
                {
                    insuranceClassRyderSpecified = tbxRyderSpecified.Text;
                }
                decimal? purchasePrice = null; if (tbxPurchasePrice.Text != "") purchasePrice = Convert.ToDecimal(tbxPurchasePrice.Text);
                DateTime? scrapDate = null; if (tkrdpScrapDate.SelectedDate.HasValue) scrapDate = tkrdpScrapDate.SelectedDate.Value;
                decimal? saleProceeds = null; if (tbxSaleProceeds.Text != "") saleProceeds = Convert.ToDecimal(tbxSaleProceeds.Text);

                UnitInformationUnitDetailsGateway UnitInformationUnitDetailsGateway = new UnitInformationUnitDetailsGateway(unitInformationTDS);
                int? libraryCategoriesId = null; if (UnitInformationUnitDetailsGateway.GetLibraryCategoriesId(int.Parse(hdfUnitId.Value)).HasValue) libraryCategoriesId = (int)UnitInformationUnitDetailsGateway.GetLibraryCategoriesId(int.Parse(hdfUnitId.Value));

                // Update unit data
                UnitInformationUnitDetails unitInformationUnitDetails = new UnitInformationUnitDetails(unitInformationTDS);
                unitInformationUnitDetails.Update(unitId, code, description, vin, manufacturer, model, year, isTowable, companyLevelIdSelected, acquisitionDate, dispositionDate, dispositionReason, licenseCountry, licenceState, licensePlateNumber, apportionedTagNumber, actualWeight, registeredWeight, tireSizeFront, tireSizeBack, numberOfAxes, fuelType, beginningOdometer, isRefeerEquipped, isPtoEquipped, ownerType, ownerCountry, ownerState, ownerName, ownerContact, qualifiedDate, notQualifiedDate, notQualifiedExplain, insuranceClass, insuranceClassRyderSpecified, purchasePrice, scrapDate, saleProceeds, libraryCategoriesId);

                Session["arrayCategoriesSelectedForEdit"] = arrayCategoriesSelectedForEdit;
                Session["arrayCompanyLevelsSelectedForEdit"] = arrayCompanyLevelsSelectedForEdit;

                // Store dataset
                Session["unitInformationTDS"] = unitInformationTDS;
                Session["categoriesTDSForUnits"] = categoriesTDS;
                Session["companyLevelsTDS"] = companyLevelsTDS;

                // Update database
                UpdateDatabase();

                LoadChecklitData(unitId);

                ViewState["update"] = "yes";                
            }
        }



        private void UpdateDatabase()
        {
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int unitId = Int32.Parse(hdfUnitId.Value);

            LibraryFilesGateway libraryFilesGateway = new LibraryFilesGateway(libraryTDSForUnits);
            libraryFilesGateway.Update();

            DB.Open();
            DB.BeginTransaction();
            try
            {
                // ... if can edit everything
                if (Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_UNITS_EDIT"]))
                {
                    // Save inspection details
                    UnitInformationInspectionDetails unitInformationInspectionDetails = new UnitInformationInspectionDetails(unitInformationTDS);
                    unitInformationInspectionDetails.Save(unitId, companyId);

                    // Save notes information
                    UnitInformationNoteDetailsGateway unitInformationNoteDetailsGateway = new UnitInformationNoteDetailsGateway(unitInformationTDS);
                    UnitInformationNoteDetails unitInformationNoteDetails = new UnitInformationNoteDetails(unitInformationTDS);

                    foreach (UnitInformationTDS.NoteInformationRow rowNotes in (UnitInformationTDS.NoteInformationDataTable)unitInformationNoteDetailsGateway.Table)
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

                    unitInformationNoteDetails.Save(companyId);

                    // Save costs information
                    UnitInformationCostInformation unitInformationCostInformation = new UnitInformationCostInformation(unitInformationTDS);
                    unitInformationCostInformation.Save(companyId);

                    // Save costs exceptions information
                    UnitInformationCostExceptionsInformation unitInformationCostExceptionsInformation = new UnitInformationCostExceptionsInformation(unitInformationTDS);
                    unitInformationCostExceptionsInformation.Save(companyId, unitId);

                    // Save unit details
                    UnitInformationUnitDetails unitInformationUnitDetails = new UnitInformationUnitDetails(unitInformationTDS);
                    unitInformationUnitDetails.Save(arrayCategoriesSelectedForEdit, companyId);
                }

                // ... if could only edit notes
                if (!Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_UNITS_EDIT"]) && Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_UNITS_COMMENTS"]))
                {
                    // Save notes information
                    UnitInformationNoteDetailsGateway unitInformationNoteDetailsGateway = new UnitInformationNoteDetailsGateway(unitInformationTDS);
                    UnitInformationNoteDetails unitInformationNoteDetails = new UnitInformationNoteDetails(unitInformationTDS);

                    foreach (UnitInformationTDS.NoteInformationRow rowNotes in (UnitInformationTDS.NoteInformationDataTable)unitInformationNoteDetailsGateway.Table)
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

                    unitInformationNoteDetails.Save(companyId);
                }
            
                DB.CommitTransaction();

                // Store datasets
                unitInformationTDS.AcceptChanges();
                libraryTDSForUnits.AcceptChanges();
                Session["unitInformationTDS"] = unitInformationTDS;
                Session["libraryTDSForUnits"] = libraryTDSForUnits;
            }
            catch (Exception ex)
            {
                DB.RollbackTransaction();

                string url = string.Format("./../../error_page.aspx?error={0}", ex.Message.Replace('\n', ' '));
                Response.Redirect(url);
            }
        }



        private void ServicesProcessGrid()
        {
        }



        private void InspectionsAddNew()
        {
            if (ValidateInspectionFooter())
            {
                Page.Validate("inspections");
                if (Page.IsValid)
                {
                    DateTime date_ = ((RadDatePicker)grdInspections.FooterRow.FindControl("tkrdpInspectionDateNew")).SelectedDate.Value;
                    Int64 country = Int64.Parse(((DropDownList)grdInspections.FooterRow.FindControl("ddlCountryNew")).SelectedValue.ToString().Trim());
                    Int64 state = Int64.Parse(((DropDownList)grdInspections.FooterRow.FindControl("ddlStateNew")).SelectedValue.ToString().Trim());
                    string type = ((DropDownList)grdInspections.FooterRow.FindControl("ddlTypeNew")).SelectedValue.ToString().Trim();
                    string result = ((DropDownList)grdInspections.FooterRow.FindControl("ddlResultNew")).SelectedValue.ToString().Trim();
                    decimal? cost = null;
                    if (((TextBox)grdInspections.FooterRow.FindControl("tbxRepairCostNew")).Text.Trim() != "")
                    {
                        cost = Decimal.Parse(((TextBox)grdInspections.FooterRow.FindControl("tbxRepairCostNew")).Text.Trim());
                    }
                    string notes = ((TextBox)grdInspections.FooterRow.FindControl("tbxNotesNew")).Text.Trim();
                    string inspectedBy = ((TextBox)grdInspections.FooterRow.FindControl("tbxInspectedByNew")).Text.Trim();
                    
                    int companyId = Int32.Parse(hdfCompanyId.Value);
                    int unitId = Int32.Parse(hdfUnitId.Value);
                   
                    // Insert
                    UnitInformationInspectionDetails model = new UnitInformationInspectionDetails(unitInformationTDS);
                    model.Insert(date_, country, state, type, result, cost, notes, inspectedBy, "", false, false);

                    // Store datasets
                    Session.Remove("unitsInspectionsTempDummy");
                    Session["unitInformationTDS"] = unitInformationTDS;

                    grdInspections.DataBind();
                    grdInspections.PageIndex = grdInspections.PageCount - 1;                    
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
                    int unitId = Int32.Parse(hdfUnitId.Value);
                    int companyId = Int32.Parse(hdfCompanyId.Value);
                    string newSubject = ((TextBox)grdNotes.FooterRow.FindControl("tbxNoteSubjectNew")).Text.Trim();
                    int loginId = Convert.ToInt32(Session["loginID"]);
                    DateTime dateTime_ = DateTime.Now;
                    string newNote = ((TextBox)grdNotes.FooterRow.FindControl("tbxNoteNoteNew")).Text.Trim();
                    bool inDatabase = false;
                    int? libraryFilesId = null;
                    string fileName = ((Label)grdNotes.FooterRow.FindControl("lblFileNameNoteAttachmentNew")).Text.Trim();
                    if (fileName != "")
                    {
                        LibraryFilesGateway libraryFilesGateway = new LibraryFilesGateway();
                        libraryFilesId = libraryFilesGateway.GetlibraryFilesId(fileName);
                    }

                    UnitInformationNoteDetails model = new UnitInformationNoteDetails(unitInformationTDS);
                    model.Insert(unitId, newSubject, loginId, dateTime_, newNote, false, companyId, inDatabase, libraryFilesId);

                    Session.Remove("unitsNotesTempDummy");
                    Session["unitInformationTDS"] = unitInformationTDS;

                    grdNotes.DataBind();
                    grdNotes.PageIndex = grdNotes.PageCount - 1;
                }
            }
        }



        private void GrdCostsAdd()
        {
            if (ValidateCostsFooter())
            {
                Page.Validate("AddCost");
                if (Page.IsValid)
                {
                    int unitId = Int32.Parse(hdfUnitId.Value);
                    int companyId = Int32.Parse(hdfCompanyId.Value);
                    DateTime date_ = ((RadDatePicker)grdCosts.FooterRow.FindControl("tkrdpDateNew")).SelectedDate.Value;
                    string unitOfMeasurement = ((DropDownList)grdCosts.FooterRow.FindControl("ddlUnitOfMeasurementUnitsNew")).SelectedValue;
                    decimal costCad = Decimal.Parse(((TextBox)grdCosts.FooterRow.FindControl("tbxCostCadNew")).Text.Trim());
                    decimal costUsd = Decimal.Parse(((TextBox)grdCosts.FooterRow.FindControl("tbxCostUsdNew")).Text.Trim());

                    UnitInformationCostInformation model = new UnitInformationCostInformation(unitInformationTDS);
                    model.Insert(unitId, date_, unitOfMeasurement, costCad, costUsd, false, companyId, false);

                    Session.Remove("unitCostsDummy");
                    Session["unitInformationTDS"] = unitInformationTDS;

                    grdCosts.DataBind();
                }
            }
        }



        private void GrdCostsExceptionsAdd()
        {
            if (ValidateCostsExceptionsFooter())
            {
                Page.Validate("AddCostException");
                if (Page.IsValid)
                {
                    int costId = Convert.ToInt32(Session["costIdSelected"]);
                    int companyId = Int32.Parse(hdfCompanyId.Value);

                    string unitOfMeasurement = ((DropDownList)grdCostsExceptions.FooterRow.FindControl("ddlExceptionUnitOfMeasurementUnitsNew")).SelectedValue;
                    decimal costCad = Decimal.Parse(((TextBox)grdCostsExceptions.FooterRow.FindControl("tbxExceptionCostCadNew")).Text.Trim());
                    decimal costUsd = Decimal.Parse(((TextBox)grdCostsExceptions.FooterRow.FindControl("tbxExceptionCostUsdNew")).Text.Trim());
                    string work_ = ((DropDownList)grdCostsExceptions.FooterRow.FindControl("ddlExceptionWorkNew")).SelectedValue;

                    UnitInformationCostExceptionsInformation model = new UnitInformationCostExceptionsInformation(unitInformationTDS);
                    model.Insert(costId, work_, unitOfMeasurement, costCad, costUsd, false, companyId, false);

                    Session.Remove("unitCostsExceptionsDummy");
                    Session["unitInformationTDS"] = unitInformationTDS;

                    string filterOptions = string.Format("CostID = {0} AND Deleted = {1}", costId, 0);
                    odsCostsExceptions.FilterExpression = filterOptions;

                    grdCostsExceptions.DataBind();
                }
            }
        }


        
        private bool ValidateInspectionFooter()
        {
            string date = ""; if (((RadDatePicker)grdInspections.FooterRow.FindControl("tkrdpInspectionDateNew")).SelectedDate.HasValue) date = ((RadDatePicker)grdInspections.FooterRow.FindControl("tkrdpInspectionDateNew")).SelectedDate.Value.ToString();
            string country = ((DropDownList)grdInspections.FooterRow.FindControl("ddlCountryNew")).SelectedValue.ToString().Trim();
            string state = ((DropDownList)grdInspections.FooterRow.FindControl("ddlStateNew")).SelectedValue.ToString().Trim();
            string type = ((DropDownList)grdInspections.FooterRow.FindControl("ddlTypeNew")).SelectedValue.ToString().Trim();

            if ((date != "") || (country != "-1") || (state != "") || (type != ""))
            {
                return true;
            }

            return false;
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



        private bool ValidateCostsFooter()
        {
            DateTime? date_ = null; if (((RadDatePicker)grdCosts.FooterRow.FindControl("tkrdpDateNew")).SelectedDate.HasValue) date_ = ((RadDatePicker)grdCosts.FooterRow.FindControl("tkrdpDateNew")).SelectedDate.Value;
            string unitOfMeasurement = ((DropDownList)grdCosts.FooterRow.FindControl("ddlUnitOfMeasurementUnitsNew")).SelectedValue;
            decimal? costCad = null; if (((TextBox)grdCosts.FooterRow.FindControl("tbxCostCadNew")).Text.Trim() != "") costCad = Decimal.Parse(((TextBox)grdCosts.FooterRow.FindControl("tbxCostCadNew")).Text.Trim());
            decimal? costUsd = null; if (((TextBox)grdCosts.FooterRow.FindControl("tbxCostUsdNew")).Text.Trim() != "") costUsd = Decimal.Parse(((TextBox)grdCosts.FooterRow.FindControl("tbxCostUsdNew")).Text.Trim());

            if ((date_.HasValue) || (costCad.HasValue) || (costUsd.HasValue))
            {
                return true;
            }

            return false;
        }



        private bool ValidateCostsExceptionsFooter()
        {
            string typeOfWork = ""; if (((DropDownList)grdCostsExceptions.FooterRow.FindControl("ddlExceptionWorkNew")).SelectedValue != "(Select)") typeOfWork = ((DropDownList)grdCostsExceptions.FooterRow.FindControl("ddlExceptionWorkNew")).SelectedValue;
            string unitOfMeasurement = ((DropDownList)grdCostsExceptions.FooterRow.FindControl("ddlExceptionUnitOfMeasurementUnitsNew")).SelectedValue;
            decimal? costCad = null; if (((TextBox)grdCostsExceptions.FooterRow.FindControl("tbxExceptionCostCadNew")).Text.Trim() != "") costCad = Decimal.Parse(((TextBox)grdCostsExceptions.FooterRow.FindControl("tbxExceptionCostCadNew")).Text.Trim());
            decimal? costUsd = null; if (((TextBox)grdCostsExceptions.FooterRow.FindControl("tbxExceptionCostUsdNew")).Text.Trim() != "") costUsd = Decimal.Parse(((TextBox)grdCostsExceptions.FooterRow.FindControl("tbxExceptionCostUsdNew")).Text.Trim());

            if ((typeOfWork != "") || (costCad.HasValue) || (costUsd.HasValue))
            {
                return true;
            }

            return false;
        }



        private void MakePanelsVisible()
        {
            if (Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_UNITS_EDIT"])) 
            {
                // ... ... General tab
                upnlGeneralDataEdit.Visible = true;
                upnlGeneralDataEdit.Update();
                upnlGeneralDataSummary.Visible = false;
                upnlGeneralDataSummary.Update();

                // ... ... Plate DataEdit tab
                upnlPlateDataEdit.Visible = true;
                upnlPlateDataEdit.Update();
                upnlPlateDataSummary.Visible = false;
                upnlPlateDataSummary.Update();

                // ... ... Technical tab
                upnlTechnicalEdit.Visible = true;
                upnlTechnicalEdit.Update();
                upnlTechnicalSummary.Visible = false;
                upnlTechnicalSummary.Update();

                // ... ... Ownership tab
                upnlOwnershipEdit.Visible = true;
                upnlOwnershipEdit.Update();
                upnlOwnershipSummary.Visible = false;
                upnlOwnershipSummary.Update();

                // ... ... Checklist tab
                upnlChecklistEdit.Visible = true;
                upnlChecklistEdit.Update();
                upnlChecklistSummary.Visible = false;
                upnlChecklistSummary.Update();

                // ... ... Inspection tab
                upnlInspectionEdit.Visible = true;
                upnlInspectionEdit.Update();
                upnlInspectionSummary.Visible = false;
                upnlInspectionSummary.Update();

                // ... ... Costs tab
                upnlCostsEdit.Visible = true;
                upnlCostsEdit.Update();
                upnlCostsSummary.Visible = false;
                upnlCostsSummary.Update();
            }               
            else
            {
                if (!Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_UNITS_EDIT"]) && Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_UNITS_COMMENTS"]))
                {
                    // ... ... General tab
                    upnlGeneralDataEdit.Visible = false;
                    upnlGeneralDataEdit.Update();
                    upnlGeneralDataSummary.Visible = true;
                    upnlGeneralDataSummary.Update();

                    // ... ... Plate DataEdit tab
                    upnlPlateDataEdit.Visible = false;
                    upnlPlateDataEdit.Update();
                    upnlPlateDataSummary.Visible = true;
                    upnlPlateDataSummary.Update();

                    // ... ... Technical tab
                    upnlTechnicalEdit.Visible = false;
                    upnlTechnicalEdit.Update();
                    upnlTechnicalSummary.Visible = true;
                    upnlTechnicalSummary.Update();

                    // ... ... Ownership tab
                    upnlOwnershipEdit.Visible = false;
                    upnlOwnershipEdit.Update();
                    upnlOwnershipSummary.Visible = true;
                    upnlOwnershipSummary.Update();

                    // ... ... Checklist tab
                    upnlChecklistEdit.Visible = false;
                    upnlChecklistEdit.Update();
                    upnlChecklistSummary.Visible = true;
                    upnlChecklistSummary.Update();

                    // ... ... Inspection tab
                    upnlInspectionEdit.Visible = false;
                    upnlInspectionEdit.Update();
                    upnlInspectionSummary.Visible = true;
                    upnlInspectionSummary.Update();

                    // ... ... Costs tab
                    upnlCostsEdit.Visible = false;
                    upnlCostsEdit.Update();
                    upnlCostsSummary.Visible = true;
                    upnlCostsSummary.Update();
                }
            }
        }
        
       

    }
}