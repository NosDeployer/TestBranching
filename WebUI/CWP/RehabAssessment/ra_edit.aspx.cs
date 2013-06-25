using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.BL.Assets.Assets;
using LiquiForce.LFSLive.BL.CWP.JunctionLining;
using LiquiForce.LFSLive.BL.CWP.RehabAssessment;
using LiquiForce.LFSLive.DA.Assets.Assets;
using LiquiForce.LFSLive.DA.CWP.Assets;
using LiquiForce.LFSLive.DA.CWP.JunctionLining;
using LiquiForce.LFSLive.DA.CWP.RehabAssessment;
using LiquiForce.LFSLive.DA.CWP.Works;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.DA.Resources.Companies;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.Tools;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.CWP.RehabAssessment
{
    /// <summary>
    /// ra_edit
    /// </summary>
    public partial class ra_edit : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected RehabAssessmentTDS rehabAssessmentTDS;
        protected RehabAssessmentTDS.LateralDetailsDataTable raAddLateralsNewDetails;
        protected FlatSectionJlTDS flatSectionJlTDSForRA;
        protected MaterialInformationTDS materialInformationTDS;
        protected MaterialInformationTDS.MaterialInformationDataTable materialInformation;






        // ////////////////////////////////////////////////////////////////////////
        // EVENTS
        //

        protected void Page_Load(object sender, EventArgs e)
        {
            // Register client scripts
            this.RegisterClientScripts();

            bool isFromTabClick = false;

            if (!IsPostBack)
            {
                if (!isFromTabClick)
                {
                    // Security check
                    if (!(Convert.ToBoolean(Session["sgLFS_CWP_REHABASSESSMENT_VIEW"]) && Convert.ToBoolean(Session["sgLFS_CWP_REHABASSESSMENT_EDIT"])))
                    {
                        Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                    }

                    // Validate query string
                    if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["client_id"] == null) || ((string)Request.QueryString["project_id"] == null) || ((string)Request.QueryString["asset_id"] == null) || ((string)Request.QueryString["active_tab"] == null))
                    {
                        Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in ra_edit.aspx");
                    }

                    // Tag Page
                    TagPage();

                    // Prepare initial data
                    Session.Remove("raAddLateralsNewDummy");
                    Session.Remove("materialInformationTDS");

                    materialInformationTDS = new MaterialInformationTDS();                    

                    // If coming from 
                    int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
                    int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value.ToString());
                    int assetId = Int32.Parse(hdfAssetId.Value.Trim());
                    int workId = Int32.Parse(hdfWorkId.Value.Trim());
                    int workIdFll = Int32.Parse(hdfWorkIdFll.Value.Trim());
                    string workType = hdfWorkType.Value;

                    // ... ra_navigator2.aspx
                    if (Request.QueryString["source_page"] == "ra_navigator2.aspx")
                    {
                        StoreNavigatorState();
                        ViewState["update"] = "no";

                        // ... Set initial tab
                        if ((string)Session["dialogOpenedRa"] != "1")
                        {
                            hdfActiveTab.Value = Request.QueryString["active_tab"];

                            rehabAssessmentTDS = new RehabAssessmentTDS();                            

                            RehabAssessmentSectionDetails rehabAssessmentSectionDetails = new RehabAssessmentSectionDetails(rehabAssessmentTDS);
                            rehabAssessmentSectionDetails.LoadByWorkId(workId, companyId);

                            RehabAssessmentWorkDetails rehabAssessmentWorkDetails = new RehabAssessmentWorkDetails(rehabAssessmentTDS);
                            rehabAssessmentWorkDetails.LoadByWorkId(workId, companyId);

                            RehabAssessmentLateralDetails rehabAssessmentLateralDetails = new RehabAssessmentLateralDetails(rehabAssessmentTDS);
                            rehabAssessmentLateralDetails.LoadForEdit(workIdFll, assetId, companyId, currentProjectId);
                        }
                        else
                        {
                            hdfActiveTab.Value = (string)Session["activeTabRa"];

                            // Restore dataset
                            rehabAssessmentTDS = (RehabAssessmentTDS)Session["rehabAssessmentTDS"];                            
                        }

                        // Store dataset
                        Session["rehabAssessmentTDS"] = rehabAssessmentTDS;
                    }

                    // ... ra_summary.aspx or ra_edit.aspx
                    if ((Request.QueryString["source_page"] == "ra_summary.aspx") || (Request.QueryString["source_page"] == "ra_edit.aspx"))
                    {
                        StoreNavigatorState();
                        ViewState["update"] = Request.QueryString["update"];

                        // ... Set initial tab
                        if ((string)Session["dialogOpenedRa"] != "1")
                        {
                            hdfActiveTab.Value = Request.QueryString["active_tab"];
                        }
                        else
                        {
                            hdfActiveTab.Value = (string)Session["activeTabRa"];
                        }

                        if (ViewState["update"].ToString().Trim() == "yes")
                        {
                            rehabAssessmentTDS = new RehabAssessmentTDS();

                            RehabAssessmentSectionDetails rehabAssessmentSectionDetails = new RehabAssessmentSectionDetails(rehabAssessmentTDS);
                            rehabAssessmentSectionDetails.LoadByWorkId(workId, companyId);

                            RehabAssessmentWorkDetails rehabAssessmentWorkDetails = new RehabAssessmentWorkDetails(rehabAssessmentTDS);
                            rehabAssessmentWorkDetails.LoadByWorkId(workId, companyId);

                            RehabAssessmentLateralDetails rehabAssessmentLateralDetails = new RehabAssessmentLateralDetails(rehabAssessmentTDS);
                            rehabAssessmentLateralDetails.LoadForEdit(workIdFll, assetId, companyId, currentProjectId);

                            // Store dataset
                            Session["rehabAssessmentTDS"] = rehabAssessmentTDS;
                        }

                        // Restore dataset
                        rehabAssessmentTDS = (RehabAssessmentTDS)Session["rehabAssessmentTDS"];
                    }

                    // Prepare initial data
                    lblMissingData.Visible = false;

                    // Set initial tab
                    int activeTab = Int32.Parse(hdfActiveTab.Value);
                    tcRaDetails.ActiveTabIndex = activeTab;

                    // ... for client
                    int currentClientId = Int32.Parse(hdfCurrentClientId.Value.ToString());
                    CompaniesGateway companiesGateway = new CompaniesGateway();
                    companiesGateway.LoadByCompaniesId(currentClientId, companyId);
                    lblTitleClientName.Text = "Client: " + companiesGateway.GetName(currentClientId);

                    // ... for project
                    ProjectGateway projectGateway = new ProjectGateway();
                    projectGateway.LoadByProjectId(currentProjectId);
                    string name = projectGateway.GetName(currentProjectId);
                    if (name.Length > 23) name = name.Substring(0, 20) + "...";
                    lblTitleProjectName.Text = " > Project: " + name + " (" + projectGateway.GetProjectNumber(currentProjectId) + ") > Selected Section";

                    // ... Data for current work                
                    LoadRehabAssessmentData(currentProjectId, assetId, companyId);

                    // Databind
                    Page.DataBind();
                    ((DropDownList)grdLaterals.FooterRow.FindControl("ddlNewMaterial")).SelectedIndex = 0;

                    // For usmh, dsmh autocomplete
                    string provinceId_ = "0"; if (hdfProvinceId.Value != "") provinceId_ = hdfProvinceId.Value;
                    string countyId_ = "0"; if (hdfCountyId.Value != "") countyId_ = hdfCountyId.Value;
                    string cityId_ = "0"; if (hdfCityId.Value != "") cityId_ = hdfCityId.Value;

                    aceUsmh.ContextKey = hdfCountryId.Value + "," + provinceId_ + "," + countyId_ + "," + cityId_ + "," + hdfCompanyId.Value;
                    aceDsmh.ContextKey = hdfCountryId.Value + "," + provinceId_ + "," + countyId_ + "," + cityId_ + "," + hdfCompanyId.Value;

                    // Load Materials
                    MaterialInformationGateway materialInformationGateway = new MaterialInformationGateway(materialInformationTDS);
                    materialInformationGateway.LoadAllByAssetId(assetId, companyId);

                    materialInformation = materialInformationTDS.MaterialInformation;
                    Session["materialInformationTDS"] = materialInformationTDS;
                }
            }
            else
            {
                // Restore datasets
                rehabAssessmentTDS = (RehabAssessmentTDS)Session["rehabAssessmentTDS"];
                flatSectionJlTDSForRA = (FlatSectionJlTDS)Session["flatSectionJlTDSForRA"];
                materialInformationTDS = (MaterialInformationTDS)Session["materialInformationTDS"];
                materialInformation = materialInformationTDS.MaterialInformation;

                // Set initial tab
                int activeTab = Int32.Parse(hdfActiveTab.Value);
                tcRaDetails.ActiveTabIndex = activeTab;
            }
        }



        protected void grdLaterals_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Add":
                    // Laterals Gridview, if the gridview is edition mode
                    if (grdLaterals.EditIndex >= 0)
                    {
                        grdLaterals.UpdateRow(grdLaterals.EditIndex, true);
                    }

                    // Add New Laterals
                    GrdRaAddLateralsNewAdd();
                    break;

                case "MaterialUpdate":
                    // Store active tab for postback
                    Session["activeTabRa"] = "2";
                    Session["dialogOpenedRa"] = "1";
                    Save2();

                    // Open Dialog
                    int index = Convert.ToInt32(e.CommandArgument);
                    Session["rowFocus"] = index;
                    GridViewRow gridRow = grdLaterals.Rows[index];
                    int lateral = int.Parse(((Label)gridRow.FindControl("lblLateral")).Text);

                    string script = "<script language='javascript'>";
                    string url = "./../Assets/asset_sewer_material.aspx?source_page=ra_edit.aspx&asset_id=" + lateral + "&work_id=" + hdfWorkId.Value;
                    script = script + string.Format("window.open('{0}', '_blank', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=490, height=540')", url);
                    script = script + "</script>";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "MaterialUpdate", script, false);
                    break;
            }
        }



        protected void grdLaterals_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Laterals Gridview, if the gridview is edition mode
            if (grdLaterals.EditIndex >= 0)
            {
                grdLaterals.UpdateRow(grdLaterals.EditIndex, true);
            }

            // Delete laterals
            int lateral = int.Parse(((Label)grdLaterals.Rows[e.RowIndex].Cells[1].FindControl("lblLateral")).Text);
            RehabAssessmentLateralDetails model = new RehabAssessmentLateralDetails(rehabAssessmentTDS);

            // Delete lateral
            model.Delete(lateral);

            tbxLaterals.Text = model.GetTotalLaterals().ToString();
            tbxLiveLaterals.Text = model.GetLiveLaterals().ToString();

            // Store dataset
            Session["rehabAssessmentTDS"] = rehabAssessmentTDS;
        }



        protected void grdLaterals_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.Validate("AddLateralsUpdate");
            if (Page.IsValid)
            {
                if (((DropDownList)grdLaterals.Rows[e.RowIndex].Cells[2].FindControl("ddlLiveEdit")).Visible == true)
                {
                    Page.Validate("AddLateralsUpdateSpecial");
                }

                if (Page.IsValid)
                {
                    int lateral = int.Parse(((Label)grdLaterals.Rows[e.RowIndex].Cells[1].FindControl("lblLateral")).Text.Trim());
                    string lateralId = ((TextBox)grdLaterals.Rows[e.RowIndex].Cells[2].FindControl("tbxLateralIdEdit")).Text.Trim();
                    string clientLateralId = ((TextBox)grdLaterals.Rows[e.RowIndex].Cells[2].FindControl("tbxClientLateralIdEdit")).Text.Trim();
                    string size = ((TextBox)grdLaterals.Rows[e.RowIndex].Cells[2].FindControl("tbxSizeEdit")).Text.Trim();

                    // Load material 
                    string material = "";
                    material = ((DropDownList)grdLaterals.Rows[e.RowIndex].Cells[2].FindControl("ddlMaterialEdit")).SelectedValue.ToString().Trim();
                    
                    // Load lateral state
                    string live = "";
                    if (((TextBox)grdLaterals.Rows[e.RowIndex].Cells[2].FindControl("tbxJlLive")).Visible == true)
                    {
                        live = "Live";
                    }
                    else
                    {
                        if (((DropDownList)grdLaterals.Rows[e.RowIndex].Cells[2].FindControl("ddlLiveEdit")).Visible == true)
                        {
                            live = ((DropDownList)grdLaterals.Rows[e.RowIndex].Cells[2].FindControl("ddlLiveEdit")).SelectedValue.Trim();
                        }
                    }

                    string videoDistance = ((TextBox)grdLaterals.Rows[e.RowIndex].Cells[2].FindControl("tbxVideoDistanceEdit")).Text.Trim();
                    string clockPosition = ((TextBox)grdLaterals.Rows[e.RowIndex].Cells[2].FindControl("tbxClockPositionEdit")).Text.Trim();
                    string distanceToCentre = ((TextBox)grdLaterals.Rows[e.RowIndex].Cells[2].FindControl("tbxDistanceToCentreEdit")).Text.Trim();
                    string timeOpened = ((TextBox)grdLaterals.Rows[e.RowIndex].Cells[2].FindControl("tbxTimeOpenedEdit")).Text.Trim();

                    // Reverse Setup calculation
                    string reverseSetup = "";

                    if (videoDistance != "")
                    {
                        Distance videoLength = new Distance(tbxVideoLength.Text.Trim());
                        Distance videoDistanceD = new Distance(videoDistance);
                        Distance reverseSetupD = videoLength - videoDistanceD;

                        switch (videoDistanceD.DistanceType)
                        {
                            case 1:
                                reverseSetup = reverseSetupD.ToStringInEng1();
                                break;
                            case 2:
                                reverseSetup = reverseSetupD.ToStringInEng2();
                                break;
                            case 3:
                                reverseSetup = reverseSetupD.ToStringInEng3();
                                break;
                            case 4:
                                reverseSetup = reverseSetupD.ToStringInMet1();
                                break;
                            case 5:
                                reverseSetup = reverseSetupD.ToStringInMil1();
                                break;
                        }
                    }

                    DateTime? reinstate = null;
                    if (((RadDatePicker)grdLaterals.Rows[e.RowIndex].Cells[2].FindControl("tkrdpReinstateEdit")).SelectedDate.HasValue)
                    {
                        reinstate = ((RadDatePicker)grdLaterals.Rows[e.RowIndex].Cells[2].FindControl("tkrdpReinstateEdit")).SelectedDate.Value;
                    }

                    string comments = ((TextBox)grdLaterals.Rows[e.RowIndex].Cells[2].FindControl("tbxCommentsEdit")).Text.Trim();
                    bool inProject = true;
                    bool inFll = true;
                    bool inJl = ((CheckBox)grdLaterals.Rows[e.RowIndex].Cells[2].FindControl("cbxJlEdit")).Checked;
                    string connectionType = ""; connectionType = ((DropDownList)grdLaterals.Rows[e.RowIndex].Cells[2].FindControl("ddlConnectionTypeEdit")).SelectedValue;
                    string mn = ""; mn = ((TextBox)grdLaterals.Rows[e.RowIndex].Cells[2].FindControl("tbxMnEdit")).Text.Trim();
                    string clientInspectionNo = ((TextBox)grdLaterals.Rows[e.RowIndex].Cells[2].FindControl("tbxClientInspectionNoEdit")).Text.Trim();
                    DateTime? v1Inspection = null;
                    if (((RadDatePicker)grdLaterals.Rows[e.RowIndex].Cells[2].FindControl("tkrdpV1InspectionEdit")).SelectedDate.HasValue)
                    {
                        v1Inspection = ((RadDatePicker)grdLaterals.Rows[e.RowIndex].Cells[2].FindControl("tkrdpV1InspectionEdit")).SelectedDate.Value;
                    }
                    bool requiredRoboticPrep = ((CheckBox)grdLaterals.Rows[e.RowIndex].Cells[2].FindControl("ckbxRequiresRoboticPrepEdit")).Checked;

                    DateTime? requiredRoboticPrepDate = null;
                    if (((RadDatePicker)grdLaterals.Rows[e.RowIndex].Cells[2].FindControl("tkrdpRequiresRoboticPrepDateEdit")).SelectedDate.HasValue)
                    {
                        requiredRoboticPrepDate = ((RadDatePicker)grdLaterals.Rows[e.RowIndex].Cells[2].FindControl("tkrdpRequiresRoboticPrepDateEdit")).SelectedDate.Value;
                    }

                    bool holdClientIssue = ((CheckBox)grdLaterals.Rows[e.RowIndex].Cells[2].FindControl("ckbxHoldClientIssueEdit")).Checked;
                    bool holdLFSIssue = ((CheckBox)grdLaterals.Rows[e.RowIndex].Cells[2].FindControl("ckbxHoldLFSIssueEdit")).Checked;
                    bool lineLateral = inJl;
                    string flange = ((DropDownList)grdLaterals.Rows[e.RowIndex].Cells[2].FindControl("ddlFlangeEdit")).SelectedValue;
                    
                    bool dyeTestReq = ((CheckBox)grdLaterals.Rows[e.RowIndex].Cells[2].FindControl("ckbxDyeTestReqEdit")).Checked;
                    DateTime? dyeTestComplete = null;
                    if (((RadDatePicker)grdLaterals.Rows[e.RowIndex].Cells[2].FindControl("tkrdpDyeTestCompleteEdit")).SelectedDate.HasValue)
                    {
                        dyeTestComplete = ((RadDatePicker)grdLaterals.Rows[e.RowIndex].Cells[2].FindControl("tkrdpDyeTestCompleteEdit")).SelectedDate.Value;
                    }

                    string contractYear = ((TextBox)grdLaterals.Rows[e.RowIndex].Cells[2].FindControl("tbxContractYearEdit")).Text.Trim();

                    // Update
                    RehabAssessmentLateralDetails lateralModel = new RehabAssessmentLateralDetails(rehabAssessmentTDS);
                    lateralModel.Update(lateral, lateralId, size, material, live, videoDistance, clockPosition, distanceToCentre, timeOpened, reverseSetup, reinstate, comments, inProject, clientLateralId, inFll, inJl, connectionType, mn, clientInspectionNo, v1Inspection, requiredRoboticPrep, requiredRoboticPrepDate, holdClientIssue, holdLFSIssue, lineLateral, flange, dyeTestReq, dyeTestComplete, contractYear);

                    tbxLaterals.Text = lateralModel.GetTotalLaterals().ToString();
                    tbxLiveLaterals.Text = lateralModel.GetLiveLaterals().ToString();

                    // Store dataset
                    Session["rehabAssessmentTDS"] = rehabAssessmentTDS;

                    // Update JL lateral issues
                    FLLateralsSave(lateralId, requiredRoboticPrep, requiredRoboticPrepDate, holdClientIssue, holdLFSIssue, dyeTestReq, dyeTestComplete, contractYear);
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



        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set active toolbar
            mForm8 master = (mForm8)this.Master;
            master.ActiveToolbar = "eSewers";

            // For error message
            hdfErrorFieldList.Value = "";

            // For Video Done From MH and Measured From MH
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int assetId = Int32.Parse(hdfAssetId.Value);
            int workId = Int32.Parse(hdfWorkId.Value);
            int workIdFll = Int32.Parse(hdfWorkIdFll.Value);
            int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value.ToString());

            RehabAssessmentWorkDetailsGateway raWorkDetailsGateway = new RehabAssessmentWorkDetailsGateway();
            raWorkDetailsGateway.LoadByWorkId(workId, companyId);
            RehabAssessmentLateralDetails raLateralDetails = new RehabAssessmentLateralDetails();
            raLateralDetails.LoadForEdit(workIdFll, assetId, companyId, currentProjectId);

            if (Int32.Parse(tbxLaterals.Text) > 0)
            {
                ddlM1DataVideoDoneFromMh.Visible = false;
                tbxM1DataVideoDoneFromMh.Visible = true;
                tbxM1DataVideoDoneFromMh.Text = ddlM1DataVideoDoneFromMh.SelectedValue;

                ddlM1DataVideoDoneToMh.Visible = false;
                tbxM1DataVideoDoneToMh.Visible = true;
                tbxM1DataVideoDoneToMh.Text = ddlM1DataVideoDoneToMh.SelectedValue;

                ddlM1DataMeasuredFromMh.Visible = false;
                tbxM1DataMeasuredFromMh.Visible = true;
                tbxM1DataMeasuredFromMh.Text = ddlM1DataMeasuredFromMh.SelectedValue;

                btnClear.Visible = false;
            }
            else
            {
                ddlM1DataVideoDoneFromMh.Visible = true;
                tbxM1DataVideoDoneFromMh.Visible = false;

                ddlM1DataVideoDoneToMh.Visible = true;
                tbxM1DataVideoDoneToMh.Visible = false;

                ddlM1DataMeasuredFromMh.Visible = true;
                tbxM1DataMeasuredFromMh.Visible = false;

                btnClear.Visible = true;
            }

            // For materials
            // ... Load material for m1
            MaterialInformationGateway materialInformationGateway = new MaterialInformationGateway();
            materialInformationGateway.LoadLastMaterialByAssetId(assetId, companyId);

            if (materialInformationGateway.Table.Rows.Count > 0)
            {
                ddlM1DataMaterial.SelectedValue = materialInformationGateway.GetLastMaterialType(assetId);
            }

            // Hide or show the Old CWP ID field
            if (tbxOldCwpId.Text == "")
            {
                lblOldCwpId.Visible = false;
                tbxOldCwpId.Visible = false;
            }

            if (tbxFlowOrderId.Text == "")
            {
                LoadRehabAssessmentData(currentProjectId, assetId, companyId);
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // AUXILIAR EVENTS
        //

        protected void btnCommentsOnClick(object sender, EventArgs e)
        {
            // Store active tab for postback
            Session["activeTabRa"] = "3";
            Session["dialogOpenedRa"] = "1";
            Save2();

            // Open Dialog
            int assetId = Int32.Parse(hdfAssetId.Value);
            int workId = Int32.Parse(hdfWorkId.Value);
            int currentClientId = Int32.Parse(hdfCurrentClientId.Value);
            int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value);

            string script = "<script language='javascript'>";
            string url = "./ra_comments.aspx?source_page=ra_edit.aspx&asset_id=" + hdfAssetId.Value + "&client_id=" + hdfCurrentClientId.Value + "&work_id=" + hdfWorkId.Value + "&project_id=" + hdfCurrentProjectId.Value;
            script = script + string.Format("window.open('{0}', '_blank', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=795, height=640')", url);
            script = script + "</script>";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Comments", script, false);
        }



        protected void btnClearOnClick(object sender, EventArgs e)
        {
            // Clear Values
            ddlM1DataVideoDoneFromMh.SelectedIndex = 0;
            tbxM1DataVideoDoneFromMh.Text = "";

            ddlM1DataVideoDoneToMh.SelectedIndex = 0;
            tbxM1DataVideoDoneToMh.Text = "";

            ddlM1DataMeasuredFromMh.SelectedIndex = 0;
            ddlM1DataMeasuredFromMh.DataBind();
            tbxM1DataMeasuredFromMh.Text = "";
        } 



        protected void btnM1MaterialOnClik(object sender, EventArgs e)
        {
            // Store active tab for postback
            Session["activeTabRa"] = "2";
            Session["dialogOpenedRa"] = "1";
            Save2();

            // Open Dialog
            int assetId = Int32.Parse(hdfAssetId.Value);
            int workId = Int32.Parse(hdfWorkIdFll.Value);
            string script = "<script language='javascript'>";
            string url = "./../Assets/asset_sewer_material.aspx?source_page=ra_edit.aspx&asset_id=" + hdfAssetId.Value + "&work_id=" + hdfWorkId.Value;
            script = script + string.Format("window.open('{0}', '_blank', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=490, height=540')", url);
            script = script + "</script>";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "MaterialUpdate", script, false);
        }        



        protected void grdLaterals_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Laterals Gridview, if the gridview is edition mode
            if (grdLaterals.EditIndex >= 0)
            {
                grdLaterals.UpdateRow(grdLaterals.EditIndex, true);
            }
        }        



        protected void cvConfirmedSize_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Trim() != "")
            {
                // Initialize 
                CustomValidator cvConfirmerSize = (CustomValidator)source;
                args.IsValid = true;

                // Control of format
                if (!Distance.IsValidDistance(args.Value))
                {
                    cvConfirmerSize.Text = "Invalid format. (please use X'Y\", or X\", or Xft Yin, or X.Y, or X.Ym, or X.Ymm)";
                    args.IsValid = false;
                    hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Confirmed Size";
                }
            }
        }



        protected void cvSteelTapeThroughSewer_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Trim() != "")
            {
                // Initialize 
                CustomValidator cvDistanceFromUsmh = (CustomValidator)source;
                args.IsValid = true;

                // Control of format
                if (!Distance.IsValidDistance(args.Value))
                {
                    cvDistanceFromUsmh.Text = "Invalid format. (please use X'Y\", or Xft Yin, or X.Y, or X.Ym, or X.Ymm)";
                    args.IsValid = false;
                    hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Steel Tape Through Sewer";
                }

                // Control of distance > 0
                if (args.IsValid)
                {
                    Distance distance = new Distance(args.Value);
                    if (distance.ToDoubleInEng3() < 0)
                    {
                        cvDistanceFromUsmh.Text = "Invalid distance. (must be equal or greater than 0)";
                        args.IsValid = false;
                        hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Steel Tape Through Sewer";
                    }
                }
            }
        }



        protected void cvMapSize_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Trim() != "")
            {
                // Initialize 
                CustomValidator cvDistanceFromUsmh = (CustomValidator)source;
                args.IsValid = true;

                // Control of format
                if (!Distance.IsValidDistance(args.Value))
                {
                    cvDistanceFromUsmh.Text = "Invalid format. (please use X'Y\", or Xft Yin, or X.Y, or X.Ym, or X.Ymm)";
                    args.IsValid = false;
                    hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Map Size";
                }

                // Control of distance > 0
                if (args.IsValid)
                {
                    Distance distance = new Distance(args.Value);
                    if (distance.ToDoubleInEng3() < 0)
                    {
                        cvDistanceFromUsmh.Text = "Invalid distance. (must be equal or greater than 0)";
                        args.IsValid = false;
                        hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Map Size";
                    }
                }
            }
        }



        protected void cvMapLength_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Trim() != "")
            {
                // Initialize 
                CustomValidator cvDistanceFromUsmh = (CustomValidator)source;
                args.IsValid = true;

                // Control of format
                if (!Distance.IsValidDistance(args.Value))
                {
                    cvDistanceFromUsmh.Text = "Invalid format. (please use X'Y\", or Xft Yin, or X.Y, or X.Ym, or X.Ymm)";
                    args.IsValid = false;
                    hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Map Length";
                }

                // Control of distance > 0
                if (args.IsValid)
                {
                    Distance distance = new Distance(args.Value);
                    if (distance.ToDoubleInEng3() < 0)
                    {
                        cvDistanceFromUsmh.Text = "Invalid distance. (must be equal or greater than 0)";
                        args.IsValid = false;
                        hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Map length";
                    }
                }
            }
        }



        protected void cvSteelTapeLengthHeader_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Trim() != "")
            {
                // Initialize 
                CustomValidator cvDistanceFromUsmh = (CustomValidator)source;
                args.IsValid = true;

                // Control of format
                if (!Distance.IsValidDistance(args.Value))
                {
                    cvDistanceFromUsmh.Text = "Invalid format. (please use X'Y\", or Xft Yin, or X.Y, or X.Ym, or X.Ymm)";
                    args.IsValid = false;
                    hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Steel Tape Length";
                }

                // Control of distance > 0
                if (args.IsValid)
                {
                    Distance distance = new Distance(args.Value);
                    if (distance.ToDoubleInEng3() < 0)
                    {
                        cvDistanceFromUsmh.Text = "Invalid distance. (must be equal or greater than 0)";
                        args.IsValid = false;
                        hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Steel Tape Length";
                    }
                }
            }
        }



        protected void cvVideoDistance_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Trim() != "")
            {
                // Initialize 
                CustomValidator cvDistanceFromUsmh = (CustomValidator)source;
                args.IsValid = true;

                // Control of format
                if (!Distance.IsValidDistance(args.Value))
                {
                    cvDistanceFromUsmh.Text = "Invalid format. (please use X'Y\", or Xft Yin, or X.Y, or X.Ym, or X.Ymm)";
                    args.IsValid = false;
                    hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Video Length";
                }

                // Control of distance > 0
                if (args.IsValid)
                {
                    Distance distance = new Distance(args.Value);
                    if (distance.ToDoubleInEng3() < 0)
                    {
                        cvDistanceFromUsmh.Text = "Invalid distance. (must be equal or greater than 0)";
                        args.IsValid = false;
                        hdfErrorFieldList.Value = hdfErrorFieldList.Value + ",Video Length";
                    }
                }
            }
        }



        protected void cvDistance_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Trim() != "")
            {
                // Initialize 
                CustomValidator cvDistanceFromUsmh = (CustomValidator)source;
                args.IsValid = true;

                // Control of format
                if (!Distance.IsValidDistance(args.Value))
                {
                    cvDistanceFromUsmh.Text = "Invalid format. (please use X'Y\", or Xft Yin, or X.Y, or X.Ym, or X.Ymm)";
                    args.IsValid = false;
                    hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Distance";
                }

                // Control of distance > 0
                if (args.IsValid)
                {
                    Distance distance = new Distance(args.Value);
                    if (distance.ToDoubleInEng3() < 0)
                    {
                        cvDistanceFromUsmh.Text = "Invalid distance. (must be equal or greater than 0)";
                        args.IsValid = false;
                        hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Distance";
                    }
                }
            }
        }



        protected void cvDistance2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Trim() != "")
            {
                // Initialize 
                CustomValidator cvDistanceFromUsmh = (CustomValidator)source;
                args.IsValid = true;

                // Control of format
                if (!Distance.IsValidDistance2(args.Value))
                {
                    cvDistanceFromUsmh.Text = "Invalid format. (please use X'Y\", or Xft Yin, or X.Y, or X.Ymm)";
                    args.IsValid = false;
                    hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Distance";
                }

                // Control of distance > 0
                if (args.IsValid)
                {
                    Distance distance = new Distance(args.Value);
                    if (distance.ToDoubleInEng3() < 0)
                    {
                        cvDistanceFromUsmh.Text = "Invalid distance. (must be equal or greater than 0)";
                        args.IsValid = false;
                        hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Distance";
                    }
                }
            }
        }



        protected void cvNewDistanceToCentreRequired_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (Int32.Parse(hdfCurrentProjectId.Value) == 278)
            {
                if (args.Value.Trim() == "")
                {
                    args.IsValid = false;
                }
                else
                {
                    args.IsValid = true;
                }
            }
            else
            {
                args.IsValid = true;
            }
        }



        protected void cvDistanceToCentreRequiredEdit_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (Int32.Parse(hdfCurrentProjectId.Value) == 278)
            {
                if (args.Value.Trim() == "")
                {
                    args.IsValid = false;
                }
                else
                {
                    args.IsValid = true;
                }
            }
            else
            {
                args.IsValid = true;
            }
        }



        protected void cvNewVideoDistanceRequired_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (Int32.Parse(hdfCurrentProjectId.Value) == 278)
            {
                if (args.Value.Trim() == "")
                {
                    args.IsValid = false;
                }
                else
                {
                    args.IsValid = true;
                }
            }
            else
            {
                args.IsValid = true;
            }
        }



        protected void cvVideoDistanceRequiredEdit_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (Int32.Parse(hdfCurrentProjectId.Value) == 278)
            {
                if (args.Value.Trim() == "")
                {
                    args.IsValid = false;
                }
                else
                {
                    args.IsValid = true;
                }
            }
            else
            {
                args.IsValid = true;
            }
        }



        protected void cvNoUsmh_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (tbxUSMH.Text == "")
            {
                args.IsValid = false;
                hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", USMH";
            }
            else
            {
                args.IsValid = true;
            }
        }



        protected void cvNoDsmh_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (tbxDSMH.Text == "")
            {
                args.IsValid = false;
                hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", DSMH";
            }
            else
            {
                args.IsValid = true;
            }
        }



        protected void cvLateralId_ServerValidate(object source, ServerValidateEventArgs args)
        {
            RehabAssessmentLateralDetails model = new RehabAssessmentLateralDetails(rehabAssessmentTDS);

            // Initialize 
            CustomValidator cvLateralId = (CustomValidator)source;
            args.IsValid = true;

            // Verify in this step
            if (model.ExistsByLateralId(args.Value))
            {
                cvLateralId.Text = "Duplicated lateral. (you already have this lateral here)";
                args.IsValid = false;
            }
        }



        protected void cvMeasuredFromMH_ServerValidate(object source, ServerValidateEventArgs args)
        {
            int assetId = Int32.Parse(hdfAssetId.Value);
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int workId = Int32.Parse(hdfWorkIdFll.Value);
            int workIdFll = Int32.Parse(hdfWorkIdFll.Value);
            int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value.ToString());

            RehabAssessmentLateralDetails raLateralDetails = new RehabAssessmentLateralDetails();
            raLateralDetails.LoadForEdit(workIdFll, assetId, companyId, currentProjectId);

            if (raLateralDetails.Table.Rows.Count > 0)
            {
                args.IsValid = true;
            }
            else
            {
                if (ddlM1DataMeasuredFromMh.SelectedValue == "")
                {
                    args.IsValid = false;
                }
                else
                {
                    args.IsValid = true;
                }
            }
        }



        protected void cvLateralsMaxNumber_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Get Measured From Mh value
            int assetId = Int32.Parse(hdfAssetId.Value);
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int workId = Int32.Parse(hdfWorkId.Value);
            int workIdFll = Int32.Parse(hdfWorkIdFll.Value);
            int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value.ToString());
            string measuredFromMh = "";

            RehabAssessmentLateralDetails raLateralDetails = new RehabAssessmentLateralDetails();
            raLateralDetails.LoadForEdit(workIdFll, assetId, companyId, currentProjectId);

            if (raLateralDetails.Table.Rows.Count > 0)
            {               
                measuredFromMh = "USMH";
            }
            else
            {
                measuredFromMh = ddlM1DataMeasuredFromMh.SelectedValue;
            }

            // Generate increment
            RehabAssessmentLateralDetails rehabAssessmentLateraldetails = new RehabAssessmentLateralDetails(rehabAssessmentTDS);

            if (measuredFromMh == "USMH" || measuredFromMh == "")
            {
                if (rehabAssessmentLateraldetails.GetMaxLateralId2() == "A[") args.IsValid = false; else args.IsValid = true;
            }
            else
            {
                if (measuredFromMh == "DSMH")
                {
                    if (rehabAssessmentLateraldetails.GetMinLateralId2() == "@") args.IsValid = false; else args.IsValid = true;
                }
            }
        }



        protected void cvValidLength_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;
        }



        protected void cvSiteDetails_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            if (tkrdpM1DataM1Date.SelectedDate.HasValue)
            {
                if (ddlM1DataSiteDetails.SelectedValue == "(Select)")
                {
                    args.IsValid = false;
                    hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Site Details (M1)";
                }
            }
        }



        protected void cvRequiresRoboticPrepDate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;
            
            bool requiresRoboticPrep = ((CheckBox)grdLaterals.Rows[grdLaterals.EditIndex].Cells[2].FindControl("ckbxRequiresRoboticPrepEdit")).Checked;
            DateTime? requiresRoboticPrepDate = null; if (((RadDatePicker)grdLaterals.Rows[grdLaterals.EditIndex].Cells[2].FindControl("tkrdpRequiresRoboticPrepDateEdit")).SelectedDate.HasValue) requiresRoboticPrepDate = ((RadDatePicker)grdLaterals.Rows[grdLaterals.EditIndex].Cells[2].FindControl("tkrdpRequiresRoboticPrepDateEdit")).SelectedDate.Value;

            if ((!requiresRoboticPrep) && (requiresRoboticPrepDate.HasValue))
            {
                args.IsValid = false;
                hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Requires Robotic Prep Date (Prep Data)";
            }
        }



        protected void cvRequiresRoboticPrepDateNew_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            bool requiresRoboticPrep = ((CheckBox)grdLaterals.FooterRow.FindControl("ckbxRequiresRoboticPrepNew")).Checked;
            DateTime? requiresRoboticPrepDate = null; if (((RadDatePicker)grdLaterals.FooterRow.FindControl("tkrdpRequiresRoboticPrepDateNew")).SelectedDate.HasValue) requiresRoboticPrepDate = ((RadDatePicker)grdLaterals.FooterRow.FindControl("tkrdpRequiresRoboticPrepDateNew")).SelectedDate.Value;

            if ((!requiresRoboticPrep) && (requiresRoboticPrepDate.HasValue))
            {
                args.IsValid = false;
                hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Requires Robotic Prep Date (Prep Data)";
            }
        }



        protected void cvRoboticPrepCompletedDate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;
            bool roboticPrepCompleted = ckbxPrepDataRoboticPrepCompleted.Checked;
            DateTime? roboticPrepCompletedDate = null; if (tkrdpPrepDataRoboticPrepCompletedDate.SelectedDate.HasValue) roboticPrepCompletedDate = tkrdpPrepDataRoboticPrepCompletedDate.SelectedDate.Value;

            if ((!roboticPrepCompleted) && (roboticPrepCompletedDate.HasValue))
            {
                args.IsValid = false;
                hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Robotic Prep Completed Date (Prep Data)";
            }
        }



        protected void ddlM1DataVideoDoneToMh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlM1DataVideoDoneToMh.SelectedValue == "USMH")
            {
                ddlM1DataVideoDoneFromMh.SelectedValue = "DSMH";
                tbxM1DataVideoDoneFromMh.Text = "DSMH";
            }
            else
            {
                if (ddlM1DataVideoDoneToMh.SelectedValue == "DSMH")
                {
                    ddlM1DataVideoDoneFromMh.SelectedValue = "USMH";
                    tbxM1DataVideoDoneFromMh.Text = "USMH";
                }
                else
                {
                    ddlM1DataVideoDoneFromMh.SelectedValue = "";
                    tbxM1DataVideoDoneFromMh.Text = "";
                }
            }
        }



        protected void ddlM1DataVideoDoneFromMh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlM1DataVideoDoneFromMh.SelectedValue == "USMH")
            {
                ddlM1DataVideoDoneToMh.SelectedValue = "DSMH";
            }
            else
            {
                if (ddlM1DataVideoDoneFromMh.SelectedValue == "DSMH")
                {
                    ddlM1DataVideoDoneToMh.SelectedValue = "USMH";
                }
                else
                {
                    ddlM1DataVideoDoneToMh.SelectedValue = "";
                }
            }
        }
        


        protected void grdLaterals_DataBound(object sender, EventArgs e)
        {
            RaAddLateralsNewEmptyFix(grdLaterals);
        }



        protected void grdLaterals_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Normal) || (e.Row.RowState == (DataControlRowState.Normal | DataControlRowState.Alternate))))
            {
                int lateral = int.Parse(((Label)e.Row.FindControl("lblLateral")).Text);

                if (lateral > 0)
                {
                    RehabAssessmentLateralDetailsGateway gateway = new RehabAssessmentLateralDetailsGateway(rehabAssessmentTDS);

                    ((TextBox)e.Row.FindControl("tbxMaterial")).Text = gateway.GetMaterialType(lateral);
                }
            }

            // Control of footer controls
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                // For Material
                ((DropDownList)e.Row.FindControl("ddlNewMaterial")).SelectedIndex = 0;
            }

            // Control of edit controls
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Edit) || (e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
            {
                int lateral = int.Parse(((Label)e.Row.FindControl("lblLateral")).Text);

                if (lateral > 0)
                {
                    RehabAssessmentLateralDetailsGateway gateway = new RehabAssessmentLateralDetailsGateway(rehabAssessmentTDS);

                    int companyId = Int32.Parse(hdfCompanyId.Value);

                    // ... Control material and connection type dropdownlists
                    ((DropDownList)e.Row.FindControl("ddlMaterialEdit")).SelectedValue = gateway.GetMaterialType(lateral);
                    ((DropDownList)e.Row.FindControl("ddlConnectionTypeEdit")).SelectedValue = gateway.GetConnectionType(lateral);

                    // .... If lateral us used in junction lining
                    if (gateway.GetInJlDatabase(lateral))
                    {
                        if (!LateralsCouldBeDeletedInJl(lateral))
                        {
                            ((CheckBox)e.Row.FindControl("cbxJlEdit")).Enabled = false;
                        }
                    }

                    // ... Control live value
                    int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value);
                    WorkGateway workGateway = new WorkGateway();
                    workGateway.LoadByProjectIdAssetIdWorkType(currentProjectId, lateral, "Junction Lining Lateral", companyId);

                    // ... If lateral is not used in junction lining
                    if (!workGateway.ExistsProjectIdAssetIdWorkTypeCompanyId(lateral, currentProjectId, "Junction Lining Lateral", companyId))
                    {
                        ((DropDownList)e.Row.FindControl("ddlLiveEdit")).Visible = true;
                        ((DropDownList)e.Row.FindControl("ddlLiveEdit")).SelectedValue = gateway.GetLive(lateral);
                        ((TextBox)e.Row.FindControl("tbxJlLive")).Visible = false;
                    }
                    else
                    {
                        ((DropDownList)e.Row.FindControl("ddlLiveEdit")).Visible = false;
                        ((TextBox)e.Row.FindControl("tbxJlLive")).Visible = true;
                    }
                }
            }
        }



        protected void tbxVideoLength_TextChanged(object sender, EventArgs e)
        {
            int workId = Int32.Parse(hdfWorkId.Value);
            int assetId = Int32.Parse(hdfAssetId.Value);
            string videoLength = tbxVideoLength.Text.Trim();

            // Update reverse setup
            RehabAssessmentLateralDetails rehabAssessmentLateralDetails = new RehabAssessmentLateralDetails(rehabAssessmentTDS);
            rehabAssessmentLateralDetails.UpdateLengthReverseSetup(workId, assetId, videoLength);

            // Store dataset
            Session["rehabAssessmentTDS"] = rehabAssessmentTDS;

            for (int i = 0; i < grdLaterals.Rows.Count; i++)
            {
                if ((grdLaterals.Rows[i].RowType == DataControlRowType.DataRow) && ((grdLaterals.Rows[i].RowState == DataControlRowState.Normal) || (grdLaterals.Rows[i].RowState == (DataControlRowState.Normal | DataControlRowState.Alternate))))
                {
                    // Reverse Setup calculation
                    string videoDistance = ((TextBox)grdLaterals.Rows[i].Cells[2].FindControl("tbxVideoDistance")).Text.Trim();
                    string reverseSetup = "";
                    if (videoDistance != "")
                    {
                        Distance videoLengthD = new Distance(tbxVideoLength.Text.Trim());
                        Distance videoDistanceD = new Distance(videoDistance);
                        Distance reverseSetupD = videoLengthD - videoDistanceD;

                        switch (videoDistanceD.DistanceType)
                        {
                            case 1:
                                reverseSetup = reverseSetupD.ToStringInEng1();
                                break;
                            case 2:
                                reverseSetup = reverseSetupD.ToStringInEng2();
                                break;
                            case 3:
                                reverseSetup = reverseSetupD.ToStringInEng3();
                                break;
                            case 4:
                                reverseSetup = reverseSetupD.ToStringInMet1();
                                break;
                            case 5:
                                reverseSetup = reverseSetupD.ToStringInMil1();
                                break;
                        }
                    }

                    ((TextBox)grdLaterals.Rows[i].Cells[2].FindControl("tbxReverseSetup")).Text = reverseSetup;
                }
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATION EVENTS
        //

        protected void btnChange_Click(object sender, EventArgs e)
        {
            Response.Redirect("./../Common/select_project.aspx?source_page=ra_edit.aspx&work_type=" + hdfWorkType.Value.Trim());
        }



        protected void tkrmTop_ItemClick(object sender, RadMenuEventArgs e)
        {
            // Store active tab for postback
            Session["activeTabRa"] = "0";
            Session["dialogOpenedRa"] = "0";
            
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
                    rehabAssessmentTDS.RejectChanges();
                    Session["rehabAssessmentTDS"] = rehabAssessmentTDS;                    
                    if (Request.QueryString["source_page"] == "ra_navigator2.aspx")
                    {
                        url = "./ra_navigator2.aspx?source_page=ra_edit.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    }

                    if (Request.QueryString["source_page"] == "ra_summary.aspx")
                    {                        
                        url = "./ra_summary.aspx?source_page=ra_edit.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"] + "&asset_id=" + hdfAssetId.Value + "&active_tab=" + activeTab;
                    }
                    break;

                case "mPrevious":
                    // Get previous record
                    int previousId = RaNavigator.GetPreviousId((RaNavigatorTDS)Session["raNavigatorTDS"], Int32.Parse(hdfAssetId.Value));
                    if (previousId != Int32.Parse(hdfAssetId.Value))
                    {
                        if (this.Apply())
                        {
                            // Redirect
                            url = "./ra_edit.aspx?source_page=" + Request.QueryString["source_page"] + "&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&asset_id=" + previousId.ToString() + "&active_tab=" + activeTab + GetNavigatorState() + "&update=yes";
                        }
                    }
                    break;

                case "mNext":
                    // Get next record
                    int nextId = RaNavigator.GetNextId((RaNavigatorTDS)Session["raNavigatorTDS"], Int32.Parse(hdfAssetId.Value));
                    if (nextId != Int32.Parse(hdfAssetId.Value))
                    {
                        if (this.Apply())
                        {
                            // Redirect
                            url = "./ra_edit.aspx?source_page=" + Request.QueryString["source_page"] + "&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&asset_id=" + nextId.ToString() + "&active_tab=" + activeTab + GetNavigatorState() + "&update=yes";
                        }
                    }

                    break;
            }

            if (url != "") Response.Redirect(url);
        }



        protected void tkrpbLeftMenu_ItemClick(object sender, RadPanelBarEventArgs e)
        {
            string url = "";

            // Store active tab for postback
            Session["activeTabRa"] = "0";
            Session["dialogOpenedRa"] = "0";

            switch (e.Item.Value)
            {
                case "mRehabAssessmentPlan":
                    url = "./ra_lining_plan.aspx?source_page=lm&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value;
                    break;

                case "mSearch":
                    url = "./ra_navigator.aspx?source_page=lm&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&work_type=" + hdfWorkType.Value;
                    break;
            }

            if (url != "") Response.Redirect(url);
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        public RehabAssessmentTDS.LateralDetailsDataTable GetLateralDetails()
        {
            raAddLateralsNewDetails = (RehabAssessmentTDS.LateralDetailsDataTable)Session["raAddLateralsNewDummy"];
            if (raAddLateralsNewDetails == null)
            {
                raAddLateralsNewDetails = ((RehabAssessmentTDS)Session["rehabAssessmentTDS"]).LateralDetails;
            }

            return raAddLateralsNewDetails;
        }



        public void DummyRaAddLateralsNew(int Lateral, int original_Lateral)
        {
        }



        public void DummyRaAddLateralsNew(int original_Lateral)
        {
        }



        private void RegisterClientScripts()
        {
            // Publishing body's OnKeyDown event 
            HtmlGenericControl bodyUnload = (HtmlGenericControl)Page.Master.FindControl("myBody");
            bodyUnload.Attributes.Add("OnKeyDown", "OnKeyDown(event);");

            // Register content variables
            string contentVariables = "";
            contentVariables += "var tbxLengthId = '" + tbxSteelTapeLength.ClientID + "';";
            contentVariables += "var tbxM1DataSteelTapeThroughSewerId = '" + tbxM1DataSteelTapeThroughSewer.ClientID + "';";             
            contentVariables += "var hdfCurrentClientIdId = '" + hdfCurrentClientId.ClientID + "';";
            contentVariables += "var hdfCurrentProjectIdId = '" + hdfCurrentProjectId.ClientID + "';";
            contentVariables += "var hdfActiveTabId = '" + hdfActiveTab.ClientID + "';";
            contentVariables += "var tbxConfirmedSizeId = '" + tbxConfirmedSize.ClientID + "';";
            contentVariables += "var ddlThicknessId = '" + ddlThickness.ClientID + "';";
            contentVariables += "var tkrmTopId = '" + tkrmTop.ClientID + "';";            

            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./ra_edit.js");
        }



        private void StoreNavigatorState()
        {
            ViewState["navigatorState"] = "&columns_to_display=" + Request.QueryString["columns_to_display"] + "&search_ddlCondition1=" + Request.QueryString["search_ddlCondition1"] + "&search_tbxCondition1=" + Request.QueryString["search_tbxCondition1"] + "&search_ddlView=" + Request.QueryString["search_ddlView"] + "&search_sort_by=" + Request.QueryString["search_sort_by"] + "&btn_origin=" + Request.QueryString["btn_origin"];
        }



        private string GetNavigatorState()
        {
            return (string)ViewState["navigatorState"];
        }



        protected void RaAddLateralsNewEmptyFix(GridView grdView)
        {
            if (grdView.Rows.Count == 0)
            {
                RehabAssessmentTDS.LateralDetailsDataTable dt = new RehabAssessmentTDS.LateralDetailsDataTable();
                int companyId = Int32.Parse(hdfCompanyId.Value);
                dt.AddLateralDetailsRow(-1, "", "", "", "", "", DateTime.Now, "", "", "", "", "", "", false, companyId, false, false, false, "", false, "", true, false, true, false, "", "", "", DateTime.Now, false, DateTime.Now, false, false, false, "", false, DateTime.Now, "");
                Session["raAddLateralsNewDummy"] = dt;

                grdView.DataBind();
            }

            // Normally executes at all postbacks
            if (grdView.Rows.Count == 1)
            {
                RehabAssessmentTDS.LateralDetailsDataTable dt = (RehabAssessmentTDS.LateralDetailsDataTable)Session["raAddLateralsNewDummy"];
                if (dt != null)
                {
                    grdView.Rows[0].Visible = false;
                    grdView.Rows[0].Controls.Clear();
                }
            }
        }



        protected string GetDistance(object distance)
        {
            if (distance != DBNull.Value)
            {
                if (Validator.IsValidDouble(distance.ToString()))
                {
                    if (distance.ToString().Contains("-"))
                    {
                        string positiveValue = distance.ToString().Replace('-', ' ').Trim();
                        return "-" + string.Format("{0:0.0}", Convert.ToDouble(positiveValue));
                    }
                    else
                    {
                        return string.Format("{0:0.0}", Convert.ToDouble(distance));
                    }
                }
                else
                {
                    return distance.ToString();
                }
            }
            else
            {
                return "";
            }
        }



        protected string GetFlange(object name)
        {
            string flange = "";

            if (name != DBNull.Value)
            {
                flange = name.ToString();
            }

            return flange;
        }



        private void GrdRaAddLateralsNewAdd()
        {
            if (ValidateLateralFooter())
            {
                Page.Validate("AddLateralsAdd");
                if (Page.IsValid)
                {
                    string size = ((TextBox)grdLaterals.FooterRow.FindControl("tbxNewSize")).Text.Trim();
                    string material = ((DropDownList)grdLaterals.FooterRow.FindControl("ddlNewMaterial")).SelectedValue.ToString().Trim();                    
                    string live = ((DropDownList)grdLaterals.FooterRow.FindControl("ddlNewLive")).SelectedValue.Trim();
                    string videoDistance = ((TextBox)grdLaterals.FooterRow.FindControl("tbxNewVideoDistance")).Text.Trim();
                    string clockPosition = ((TextBox)grdLaterals.FooterRow.FindControl("tbxNewClockPosition")).Text.Trim();
                    string distanceToCentre = ((TextBox)grdLaterals.FooterRow.FindControl("tbxNewDistanceToCentre")).Text.Trim();
                    string timeOpened = "";
                    DateTime? reinstate = null;
                    string comments = ((TextBox)grdLaterals.FooterRow.FindControl("tbxNewComments")).Text.Trim();

                    // Reverse Setup calculation
                    string reverseSetup = "";
                    if (videoDistance != "")
                    {
                        Distance videoDistanceD = new Distance(videoDistance);
                        Distance videoLength = new Distance(tbxVideoLength.Text.Trim());

                        Distance reverseSetupD = videoLength - videoDistanceD;
                        switch (videoDistanceD.DistanceType)
                        {
                            case 1:
                                reverseSetup = reverseSetupD.ToStringInEng1();
                                break;
                            case 2:
                                reverseSetup = reverseSetupD.ToStringInEng2();
                                break;
                            case 3:
                                reverseSetup = reverseSetupD.ToStringInEng3();
                                break;
                            case 4:
                                reverseSetup = reverseSetupD.ToStringInMet1();
                                break;
                            case 5:
                                reverseSetup = reverseSetupD.ToStringInMil1();
                                break;
                        }
                    }

                    bool inProject = true;
                    bool inFll = true;
                    bool inJl = ((CheckBox)grdLaterals.FooterRow.FindControl("cbxNewJl")).Checked;
                    
                    int companyId = Int32.Parse(hdfCompanyId.Value);
                    string lateralId = GetLateralIdIncrement();
                    string clientLateralId = ((TextBox)grdLaterals.FooterRow.FindControl("tbxNewClientLateralId")).Text.Trim();
                    string connectionType = ""; connectionType = ((DropDownList)grdLaterals.FooterRow.FindControl("ddlNewConnectionType")).SelectedValue;
                    string mn = ((TextBox)grdLaterals.FooterRow.FindControl("tbxNewMn")).Text.Trim();
                    string clientInspectionNo = ((TextBox)grdLaterals.FooterRow.FindControl("tbxNewClientInspectionNo")).Text.Trim();
                    DateTime? v1Inspection = null; if (((RadDatePicker)grdLaterals.FooterRow.FindControl("tkrdpNewV1Inspection")).SelectedDate.HasValue) v1Inspection = ((RadDatePicker)grdLaterals.FooterRow.FindControl("tkrdpNewV1Inspection")).SelectedDate.Value;
                    bool requiresRoboticPrep = ((CheckBox)grdLaterals.FooterRow.FindControl("ckbxRequiresRoboticPrepNew")).Checked;
                    DateTime? requiresRoboticPrepDate = null;
                    if (((RadDatePicker)grdLaterals.FooterRow.FindControl("tkrdpRequiresRoboticPrepDateNew")).SelectedDate.HasValue)
                    {
                        requiresRoboticPrepDate = ((RadDatePicker)grdLaterals.FooterRow.FindControl("tkrdpRequiresRoboticPrepDateNew")).SelectedDate.Value;
                    }

                    bool holdClientIssue = ((CheckBox)grdLaterals.FooterRow.FindControl("ckbxHoldClientIssueNew")).Checked;
                    bool holdLFSIssue = ((CheckBox)grdLaterals.FooterRow.FindControl("ckbxHoldLFSIssueNew")).Checked;
                    bool lineLateral = inJl;
                    string flange = ((DropDownList)grdLaterals.FooterRow.FindControl("ddlFlangeNew")).SelectedValue;
                    bool dyeTestReq = ((CheckBox)grdLaterals.FooterRow.FindControl("ckbxDyeTestReqNew")).Checked;
                    DateTime? dyeTestComplete = null; if (((RadDatePicker)grdLaterals.FooterRow.FindControl("tkrdpDyeTestCompleteNew")).SelectedDate.HasValue) dyeTestComplete = ((RadDatePicker)grdLaterals.FooterRow.FindControl("tkrdpDyeTestCompleteNew")).SelectedDate.Value;
                    string contractYear =((TextBox)grdLaterals.FooterRow.FindControl("tbxNewContractYear")).Text.Trim();

                    // Insert
                    RehabAssessmentLateralDetails model = new RehabAssessmentLateralDetails(rehabAssessmentTDS);
                    model.Insert(videoDistance, clockPosition, distanceToCentre, timeOpened, reverseSetup, reinstate, comments, lateralId, size, material, false, companyId, inProject, live, clientLateralId, inFll, inJl, connectionType, mn, clientInspectionNo, v1Inspection, requiresRoboticPrep, requiresRoboticPrepDate, holdClientIssue, holdLFSIssue, lineLateral, flange, dyeTestReq, dyeTestComplete, contractYear);

                    // Store datasets
                    Session.Remove("raAddLateralsNewDummy");
                    Session["rehabAssessmentTDS"] = rehabAssessmentTDS;
                    grdLaterals.DataBind();
                    grdLaterals.PageIndex = grdLaterals.PageCount - 1;

                    tbxLaterals.Text = model.GetTotalLaterals().ToString();
                    tbxLiveLaterals.Text = model.GetLiveLaterals().ToString();
                }
            }
        }



        private string GetLateralIdIncrement()
        {
            // Get Measured From Mh value
            int assetId = Int32.Parse(hdfAssetId.Value);
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int workId = Int32.Parse(hdfWorkId.Value);
            int workIdFll = Int32.Parse(hdfWorkIdFll.Value);
            int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value.ToString());
            string measuredFromMh = "";

            RehabAssessmentLateralDetails raLateralDetails = new RehabAssessmentLateralDetails();
            raLateralDetails.LoadForEdit(workIdFll, assetId, companyId, currentProjectId);

            if (raLateralDetails.Table.Rows.Count > 0)
            {                
                measuredFromMh = "USMH";
            }
            else
            {
                measuredFromMh = ddlM1DataMeasuredFromMh.SelectedValue;
            }

            // Generate increment
            string lateralIdIncrement = "";
            RehabAssessmentLateralDetails rehabAssessmentLateraldetails = new RehabAssessmentLateralDetails(rehabAssessmentTDS);

            if (measuredFromMh == "USMH" || measuredFromMh == "")
            {
                lateralIdIncrement = rehabAssessmentLateraldetails.GetMaxLateralId2();
            }
            else
            {
                if (measuredFromMh == "DSMH")
                {
                    lateralIdIncrement =rehabAssessmentLateraldetails.GetMinLateralId2();
                }
            }

            return "RA-"+lateralIdIncrement;
        }



        #region TagPage and Load Functions

        private void TagPage()
        {
            hdfCompanyId.Value = Session["companyID"].ToString();
            hdfCurrentProjectId.Value = Request.QueryString["project_id"].ToString();
            hdfCurrentClientId.Value = Request.QueryString["client_id"].ToString();
            hdfWorkType.Value = "Rehab Assessment";
            hdfAssetId.Value = Request.QueryString["asset_id"].ToString();
            hdfErrorFieldList.Value = "";

            // Get ids & location
            int projectId = Int32.Parse(hdfCurrentProjectId.Value.Trim());
            ProjectGateway projectGateway = new ProjectGateway();
            projectGateway.LoadByProjectId(projectId);

            // ... Get ids
            Int64 currentCountry = projectGateway.GetCountryID(projectId);
            Int64? currentProvince = null; if (projectGateway.GetProvinceID(projectId).HasValue) currentProvince = (Int64)projectGateway.GetProvinceID(projectId);
            Int64? currentCounty = null; if (projectGateway.GetCountyID(projectId).HasValue) currentCounty = (Int64)projectGateway.GetCountyID(projectId);
            Int64? currentCity = null; if (projectGateway.GetCityID(projectId).HasValue) currentCity = (Int64)projectGateway.GetCityID(projectId);

            hdfCountryId.Value = currentCountry.ToString();
            hdfProvinceId.Value = currentProvince.ToString();
            hdfCountyId.Value = currentCounty.ToString();
            hdfCityId.Value = currentCity.ToString();

            // Get workId            
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int assetId = Int32.Parse(hdfAssetId.Value);
            string workType = hdfWorkType.Value;

            WorkGateway workGateway = new WorkGateway();
            workGateway.LoadByProjectIdAssetIdWorkType(projectId, assetId, workType, companyId);
            hdfWorkId.Value = workGateway.GetWorkId(assetId, workType, projectId).ToString();
            hdfWorkIdFll.Value = GetWorkId(projectId, assetId, "Full Length Lining", companyId).ToString();
            hdfWorkIdJl.Value = GetWorkId(projectId, assetId, "Junction Lining Section", companyId).ToString();
        }



        private void LoadRehabAssessmentData(int projectId, int assetId, int companyId)
        {
            // Get WorkId
            string workType = hdfWorkType.Value.Trim();
            int workId = Int32.Parse(hdfWorkId.Value);

            // Load Data
            LoadSectionData(workId);
            LoadWorkData(workId, assetId);
        }



        private void LoadSectionData(int workId)
        {
            RehabAssessmentSectionDetailsGateway rehabAssessmentSectionDetailsGateway = new RehabAssessmentSectionDetailsGateway(rehabAssessmentTDS);
            if (rehabAssessmentSectionDetailsGateway.Table.Rows.Count > 0)
            {
                // Load Section Details
                tbxFlowOrderId.Text = rehabAssessmentSectionDetailsGateway.GetFlowOrderId(workId);
                hdfFlowOrderId.Value = rehabAssessmentSectionDetailsGateway.GetFlowOrderId(workId);
                hdfSectionId.Value = rehabAssessmentSectionDetailsGateway.GetSectionId(workId);
                tbxOldCwpId.Text = rehabAssessmentSectionDetailsGateway.GetOriginalSectionId(workId);                
                tbxStreet.Text = rehabAssessmentSectionDetailsGateway.GetStreet(workId);
                tbxUSMH.Text = rehabAssessmentSectionDetailsGateway.GetUsmhDescription(workId);
                tbxDSMH.Text = rehabAssessmentSectionDetailsGateway.GetDsmhDescription(workId);
                tbxMapSize.Text = rehabAssessmentSectionDetailsGateway.GetMapSize(workId);
                tbxConfirmedSize.Text = rehabAssessmentSectionDetailsGateway.GetSize_(workId);
                ddlThickness.SelectedValue = rehabAssessmentSectionDetailsGateway.GetThickness(workId);
                tbxMapLength.Text = rehabAssessmentSectionDetailsGateway.GetMapLength(workId);
                tbxSteelTapeLength.Text = rehabAssessmentSectionDetailsGateway.GetLength(workId);
                tbxLaterals.Text = "0"; if (rehabAssessmentSectionDetailsGateway.GetLaterals(workId).HasValue) tbxLaterals.Text = rehabAssessmentSectionDetailsGateway.GetLaterals(workId).ToString().Trim();
                tbxLiveLaterals.Text = "0"; if (rehabAssessmentSectionDetailsGateway.GetLiveLaterals(workId).HasValue) tbxLiveLaterals.Text = rehabAssessmentSectionDetailsGateway.GetLiveLaterals(workId).ToString().Trim();

                // For m1 data
                // ... for depths
                tbxM1DataUsmhDepth.Text = rehabAssessmentSectionDetailsGateway.GetUsmhDepth(workId);
                tbxM1DataDsmhDepth.Text = rehabAssessmentSectionDetailsGateway.GetDsmhDepth(workId);

                // ... for address
                tbxM1DataUsmhAddress.Text = rehabAssessmentSectionDetailsGateway.GetUsmhAddress(workId);
                tbxM1DataDsmhAddress.Text = rehabAssessmentSectionDetailsGateway.GetDsmhAddress(workId);

                // ... Get lfs asset sewer data
                tbxM1DataSteelTapeThroughSewer.Text = rehabAssessmentSectionDetailsGateway.GetSteelTapeThroughSewer(workId);
                tbxM1DataUsmhMouth12.Text = rehabAssessmentSectionDetailsGateway.GetUsmhMouth12(workId);
                tbxM1DataUsmhMouth1.Text = rehabAssessmentSectionDetailsGateway.GetUsmhMouth1(workId);
                tbxM1DataUsmhMouth2.Text = rehabAssessmentSectionDetailsGateway.GetUsmhMouth2(workId);
                tbxM1DataUsmhMouth3.Text = rehabAssessmentSectionDetailsGateway.GetUsmhMouth3(workId);
                tbxM1DataUsmhMouth4.Text = rehabAssessmentSectionDetailsGateway.GetUsmhMouth4(workId);
                tbxM1DataUsmhMouth5.Text = rehabAssessmentSectionDetailsGateway.GetUsmhMouth5(workId);
                tbxM1DataDsmhMouth12.Text = rehabAssessmentSectionDetailsGateway.GetDsmhMouth12(workId);
                tbxM1DataDsmhMouth1.Text = rehabAssessmentSectionDetailsGateway.GetDsmhMouth1(workId);
                tbxM1DataDsmhMouth2.Text = rehabAssessmentSectionDetailsGateway.GetDsmhMouth2(workId);
                tbxM1DataDsmhMouth3.Text = rehabAssessmentSectionDetailsGateway.GetDsmhMouth3(workId);
                tbxM1DataDsmhMouth4.Text = rehabAssessmentSectionDetailsGateway.GetDsmhMouth4(workId);
                tbxM1DataDsmhMouth5.Text = rehabAssessmentSectionDetailsGateway.GetDsmhMouth5(workId);
                tbxGeneralSubArea.Text = rehabAssessmentSectionDetailsGateway.GetSubArea(workId);
            }            
        }



        private void LoadWorkData(int workId, int assetId)
        {
            RehabAssessmentWorkDetailsGateway rehabAssessmentWorkDetailsGateway = new RehabAssessmentWorkDetailsGateway(rehabAssessmentTDS);
            
            if (rehabAssessmentWorkDetailsGateway.Table.Rows.Count > 0)
            {
                // For Header
                tbxVideoLength.Text = rehabAssessmentWorkDetailsGateway.GetVideoDistance(workId);

                // Load general data
                tbxGeneralClientId.Text = rehabAssessmentWorkDetailsGateway.GetClientId(workId);

                if (rehabAssessmentWorkDetailsGateway.GetP1Date(workId).HasValue)
                {
                    tkrdpPrepDataP1Date.SelectedDate = (DateTime)rehabAssessmentWorkDetailsGateway.GetP1Date(workId);
                }

                if (rehabAssessmentWorkDetailsGateway.GetM1Date(workId).HasValue)
                {
                    tkrdpM1DataM1Date.SelectedDate = (DateTime)rehabAssessmentWorkDetailsGateway.GetM1Date(workId);
                }

                // for RA data
                if (rehabAssessmentWorkDetailsGateway.GetPreFlushDate(workId).HasValue)
                {
                    tkrdpGeneralPreFlushDate.SelectedDate = (DateTime)rehabAssessmentWorkDetailsGateway.GetPreFlushDate(workId);
                }

                if (rehabAssessmentWorkDetailsGateway.GetPreVideoDate(workId).HasValue)
                {
                    tkrdpGeneralPreVideoDate.SelectedDate = (DateTime)rehabAssessmentWorkDetailsGateway.GetPreVideoDate(workId);
                }

                // For FullLengthLiningP1 data
                tbxPrepDataCXIsRemoved.Text = ""; if (rehabAssessmentWorkDetailsGateway.GetCxisRemoved(workId).HasValue) tbxPrepDataCXIsRemoved.Text = rehabAssessmentWorkDetailsGateway.GetCxisRemoved(workId).ToString();
                ckbxPrepDataRoboticPrepCompleted.Checked = rehabAssessmentWorkDetailsGateway.GetRoboticPrepCompleted(workId);
                if (rehabAssessmentWorkDetailsGateway.GetRoboticPrepCompletedDate(workId).HasValue)
                {
                    tkrdpPrepDataRoboticPrepCompletedDate.SelectedDate = (DateTime)rehabAssessmentWorkDetailsGateway.GetRoboticPrepCompletedDate(workId);
                }
                ckbxPrepDataP1Completed.Checked = rehabAssessmentWorkDetailsGateway.GetP1Completed(workId);

                // For FullLengthLiningM1 data
                // ... for material
                ddlM1DataMaterial.SelectedValue = rehabAssessmentWorkDetailsGateway.GetMaterial(workId);

                // ... For m1 data
                tbxM1DataMeasurementsTakenBy.Text = rehabAssessmentWorkDetailsGateway.GetMeasurementTakenBy(workId);
                ddlM1DataTrafficControl.SelectedValue = rehabAssessmentWorkDetailsGateway.GetTrafficControl(workId);
                if (rehabAssessmentWorkDetailsGateway.GetSiteDetails(workId) == "") ddlM1DataSiteDetails.SelectedIndex = 0; else ddlM1DataSiteDetails.SelectedValue = rehabAssessmentWorkDetailsGateway.GetSiteDetails(workId);
                if (rehabAssessmentWorkDetailsGateway.GetAccessType(workId) == "") ddlM1DataAccessType.SelectedIndex = 0; else ddlM1DataAccessType.SelectedValue = rehabAssessmentWorkDetailsGateway.GetAccessType(workId);
                ckbxM1DataPipeSizeChange.Checked = rehabAssessmentWorkDetailsGateway.GetPipeSizeChange(workId);
                ckbxM1DataStandardBypass.Checked = rehabAssessmentWorkDetailsGateway.GetStandardBypass(workId);
                tbxM1DataStandardBypassComments.Text = rehabAssessmentWorkDetailsGateway.GetStandardBypassComments(workId);
                tbxM1DataTrafficControlDetails.Text = rehabAssessmentWorkDetailsGateway.GetTrafficControlDetails(workId);
                ddlM1DataMeasurementType.SelectedValue = rehabAssessmentWorkDetailsGateway.GetMeasurementType(workId);
                ddlM1DataMeasuredFromMh.SelectedValue = rehabAssessmentWorkDetailsGateway.GetMeasurementFromMh(workId);
                ddlM1DataVideoDoneFromMh.SelectedValue = rehabAssessmentWorkDetailsGateway.GetVideoDoneFromMh(workId);
                tbxM1DataMeasuredFromMh.Text = rehabAssessmentWorkDetailsGateway.GetMeasurementFromMh(workId);
                tbxM1DataVideoDoneFromMh.Text = rehabAssessmentWorkDetailsGateway.GetVideoDoneFromMh(workId);                
                ddlM1DataVideoDoneToMh.SelectedValue = rehabAssessmentWorkDetailsGateway.GetVideoDoneToMh(workId);                

                // For comments
                tbxCommentsDataComments.Text = rehabAssessmentWorkDetailsGateway.GetComments(workId);
            }
        }

        #endregion



        private void Save()
        {            
            // Validate data
            bool validData = true;

            validData = ValidatePage();

            if (validData)
            {
                // Save Lateral data
                GrdRaAddLateralsNewAdd();

                // Save data
                int companyId = Int32.Parse(hdfCompanyId.Value);
                int assetId = Int32.Parse(hdfAssetId.Value);
                int workId = Int32.Parse(hdfWorkId.Value);
                int workIdFll = Int32.Parse(hdfWorkIdFll.Value);
                int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value.ToString());

                // Get Section Details
                // ... RehabAssessmentSectionDetails Data
                string newStreet = ""; if (tbxStreet.Text != "") newStreet = tbxStreet.Text.Trim();
                string newUsmh = ""; if (tbxUSMH.Text != "") newUsmh = tbxUSMH.Text.Trim();
                string newDsmh = ""; if (tbxDSMH.Text != "") newDsmh = tbxDSMH.Text.Trim();
                string newMapSize = ""; if (tbxMapSize.Text != "") newMapSize = tbxMapSize.Text.Trim();
                string newSize = ""; if (tbxConfirmedSize.Text != "") newSize = tbxConfirmedSize.Text.Trim();
                string newThickness = ""; if (ddlThickness.SelectedValue != "") newThickness = ddlThickness.SelectedValue;
                string newMapLength = ""; if (tbxMapLength.Text != "") newMapLength = tbxMapLength.Text.Trim();

                string newSteelTapeThroughSewer = "";
                string newLength = "";
                if (tbxM1DataSteelTapeThroughSewer.Text != "")
                {
                    newSteelTapeThroughSewer = tbxM1DataSteelTapeThroughSewer.Text.Trim();
                    newLength = tbxM1DataSteelTapeThroughSewer.Text.Trim();
                }

                int? newLaterals = null; if (tbxLaterals.Text != "") newLaterals = Int32.Parse(tbxLaterals.Text.Trim());
                int? newLiveLaterals = null; if (tbxLiveLaterals.Text != "") newLiveLaterals = Int32.Parse(tbxLiveLaterals.Text.Trim());

                // ... assetSewerSection data
                string newUsmhDepth = ""; if ((tbxM1DataUsmhDepth.Text != "") && (tbxUSMH.Text != "")) newUsmhDepth = tbxM1DataUsmhDepth.Text.Trim();
                string newDsmhDepth = ""; if ((tbxM1DataDsmhDepth.Text != "") && (tbxDSMH.Text != "")) newDsmhDepth = tbxM1DataDsmhDepth.Text.Trim();

                // ... lfsAssetSewerSection data
                string newUsmhMouth12 = ""; if ((tbxM1DataUsmhMouth12.Text != "") && (tbxUSMH.Text != "")) newUsmhMouth12 = tbxM1DataUsmhMouth12.Text.Trim();
                string newUsmhMouth1 = ""; if ((tbxM1DataUsmhMouth1.Text != "") && (tbxUSMH.Text != "")) newUsmhMouth1 = tbxM1DataUsmhMouth1.Text.Trim();
                string newUsmhMouth2 = ""; if ((tbxM1DataUsmhMouth2.Text != "") && (tbxUSMH.Text != "")) newUsmhMouth2 = tbxM1DataUsmhMouth2.Text.Trim();
                string newUsmhMouth3 = ""; if ((tbxM1DataUsmhMouth3.Text != "") && (tbxUSMH.Text != "")) newUsmhMouth3 = tbxM1DataUsmhMouth3.Text.Trim();
                string newUsmhMouth4 = ""; if ((tbxM1DataUsmhMouth4.Text != "") && (tbxUSMH.Text != "")) newUsmhMouth4 = tbxM1DataUsmhMouth4.Text.Trim();
                string newUsmhMouth5 = ""; if ((tbxM1DataUsmhMouth5.Text != "") && (tbxUSMH.Text != "")) newUsmhMouth5 = tbxM1DataUsmhMouth5.Text.Trim();
                string newDsmhMouth12 = ""; if ((tbxM1DataDsmhMouth12.Text != "") && (tbxDSMH.Text != "")) newDsmhMouth12 = tbxM1DataDsmhMouth12.Text.Trim();
                string newDsmhMouth1 = ""; if ((tbxM1DataDsmhMouth1.Text != "") && (tbxDSMH.Text != "")) newDsmhMouth1 = tbxM1DataDsmhMouth1.Text.Trim();
                string newDsmhMouth2 = ""; if ((tbxM1DataDsmhMouth2.Text != "") && (tbxDSMH.Text != "")) newDsmhMouth2 = tbxM1DataDsmhMouth2.Text.Trim();
                string newDsmhMouth3 = ""; if ((tbxM1DataDsmhMouth3.Text != "") && (tbxDSMH.Text != "")) newDsmhMouth3 = tbxM1DataDsmhMouth3.Text.Trim();
                string newDsmhMouth4 = ""; if ((tbxM1DataDsmhMouth4.Text != "") && (tbxDSMH.Text != "")) newDsmhMouth4 = tbxM1DataDsmhMouth4.Text.Trim();
                string newDsmhMouth5 = ""; if ((tbxM1DataDsmhMouth5.Text != "") && (tbxDSMH.Text != "")) newDsmhMouth5 = tbxM1DataDsmhMouth5.Text.Trim();
                string newGeneralSubArea = ""; if (tbxGeneralSubArea.Text != "") newGeneralSubArea = tbxGeneralSubArea.Text.Trim();

                // ... assetSewerMH data
                string newUsmhAddress = ""; if (tbxM1DataUsmhAddress.Text != "") newUsmhAddress = tbxM1DataUsmhAddress.Text.Trim();
                string newDsmhAddress = ""; if (tbxM1DataDsmhAddress.Text != "") newDsmhAddress = tbxM1DataDsmhAddress.Text.Trim();

                // Update section details
                RehabAssessmentSectionDetails rehabAssessmentSectionDetails = new RehabAssessmentSectionDetails(rehabAssessmentTDS);
                rehabAssessmentSectionDetails.Update(workId, assetId, newStreet, newMapSize, newSize, newMapLength, newLength, newLaterals, newLiveLaterals, newUsmhDepth, newDsmhDepth, newSteelTapeThroughSewer, newUsmhMouth12, newUsmhMouth1, newUsmhMouth2, newUsmhMouth3, newUsmhMouth4, newUsmhMouth5, newDsmhMouth12, newDsmhMouth1, newDsmhMouth2, newDsmhMouth3, newDsmhMouth4, newDsmhMouth5, newUsmh, newDsmh, newUsmhAddress, newDsmhAddress, newGeneralSubArea, newThickness);

                // Get General Data
                // ... FullLengthLining data
                string newGeneralClientId = ""; if (tbxGeneralClientId.Text != "") newGeneralClientId = tbxGeneralClientId.Text.Trim();

                // ... Rehab Assessment Data
                DateTime? newPreFlushDate = null; if (tkrdpGeneralPreFlushDate.SelectedDate.HasValue) newPreFlushDate = tkrdpGeneralPreFlushDate.SelectedDate.Value;
                DateTime? newPreVideoDate = null; if (tkrdpGeneralPreVideoDate.SelectedDate.HasValue) newPreVideoDate = tkrdpGeneralPreVideoDate.SelectedDate.Value;

                // ... Prep Data
                int? newPrepDataCXIsRemoved = null; if (tbxPrepDataCXIsRemoved.Text != "") newPrepDataCXIsRemoved = Int32.Parse(tbxPrepDataCXIsRemoved.Text.Trim());
                DateTime? newPrepDataP1Date = null; if (tkrdpPrepDataP1Date.SelectedDate.HasValue) newPrepDataP1Date = tkrdpPrepDataP1Date.SelectedDate.Value;
                bool newRoboticPrepCompleted = ckbxPrepDataRoboticPrepCompleted.Checked;
                DateTime? newRoboticPrepCompletedDate = null; if (tkrdpPrepDataRoboticPrepCompletedDate.SelectedDate.HasValue) newRoboticPrepCompletedDate = tkrdpPrepDataRoboticPrepCompletedDate.SelectedDate.Value;
                bool newP1Completed = ckbxPrepDataP1Completed.Checked;

                // ... M1 Data
                DateTime? newM1Date = null; if (tkrdpM1DataM1Date.SelectedDate.HasValue) newM1Date = tkrdpM1DataM1Date.SelectedDate.Value;
                string newMeasurementsTakenBy = ""; if (tbxM1DataMeasurementsTakenBy.Text != "") newMeasurementsTakenBy = tbxM1DataMeasurementsTakenBy.Text.Trim();
                string newTrafficControl = ddlM1DataTrafficControl.SelectedValue;
                string newSiteDetails = ""; if (ddlM1DataSiteDetails.SelectedValue != "(Select)") newSiteDetails = ddlM1DataSiteDetails.SelectedValue;
                bool newPipeSizeChange = ckbxM1DataPipeSizeChange.Checked;
                bool newStandardByPass = ckbxM1DataStandardBypass.Checked;
                string newStandardBypassComments = ""; if (tbxM1DataStandardBypassComments.Text != "") newStandardBypassComments = tbxM1DataStandardBypassComments.Text.Trim();
                string newTrafficControlDetails = ""; if (tbxM1DataTrafficControlDetails.Text != "") newTrafficControlDetails = tbxM1DataTrafficControlDetails.Text.Trim();
                string newMaterial = ddlM1DataMaterial.SelectedValue;
                string newMeasurementType = ddlM1DataMeasurementType.SelectedValue;
                string newMeasuredFromMh = ""; if (tbxM1DataMeasuredFromMh.Visible) newMeasuredFromMh = tbxM1DataMeasuredFromMh.Text; else newMeasuredFromMh = ddlM1DataMeasuredFromMh.SelectedValue;
                string newVideoDoneFromMh = ""; if (tbxM1DataVideoDoneFromMh.Visible) newVideoDoneFromMh = tbxM1DataVideoDoneFromMh.Text; else newVideoDoneFromMh = ddlM1DataVideoDoneFromMh.SelectedValue;
                string newVideoDoneToMh = ""; if (tbxM1DataVideoDoneToMh.Visible) newVideoDoneToMh = tbxM1DataVideoDoneToMh.Text; else newVideoDoneToMh = ddlM1DataVideoDoneToMh.SelectedValue;
                string newAccessType = ""; if (ddlM1DataAccessType.SelectedValue != "(Select)") newAccessType = ddlM1DataAccessType.SelectedValue;

                // ... M2 Data (Video Length)
                string newVideoDistanceM2 = tbxVideoLength.Text.Trim();

                // ... Update work details
                RehabAssessmentWorkDetails rehabAssessmentWorkDetails = new RehabAssessmentWorkDetails(rehabAssessmentTDS);
                rehabAssessmentWorkDetails.Update(workId, workIdFll, newGeneralClientId, newPrepDataP1Date, newM1Date, newPrepDataCXIsRemoved, newRoboticPrepCompleted, newRoboticPrepCompletedDate, newMeasurementsTakenBy, newTrafficControl, newSiteDetails, newPipeSizeChange, newStandardByPass, newStandardBypassComments, newTrafficControlDetails, newMaterial, newMeasurementType, newMeasuredFromMh, newVideoDoneFromMh, newVideoDoneToMh, newVideoDistanceM2, newPreVideoDate, newPreFlushDate, newAccessType, newP1Completed);

                if (ddlM1DataMaterial.SelectedIndex > 0)
                {
                    LfsAssetSewerLateralGateway lfsAssetSewertLateralGateway = new LfsAssetSewerLateralGateway(null);
                    if (!lfsAssetSewertLateralGateway.IsUsedInMaterials(assetId, newMaterial, companyId))
                    {
                        MaterialInformation model = new MaterialInformation(materialInformationTDS);
                        model.Insert(assetId, newMaterial, DateTime.Now, false, companyId, false);
                    }
                }
                
                // Store datasets
                Session["rehabAssessmentTDS"] = rehabAssessmentTDS;
                Session["materialInformationTDS"] = materialInformationTDS;
                
                // Update database
                UpdateDatabase();

                ViewState["update"] = "yes";

                // Redirect
                string url = "";
                if (Request.QueryString["source_page"] == "ra_navigator2.aspx")
                {
                    url = "./ra_navigator2.aspx?source_page=ra_edit.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + GetNavigatorState() + "&update=yes";
                }

                if (Request.QueryString["source_page"] == "ra_summary.aspx")
                {
                    string activeTab = hdfActiveTab.Value;
                    url = "./ra_summary.aspx?source_page=ra_edit.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&asset_id=" + hdfAssetId.Value + "&active_tab=" + activeTab + GetNavigatorState() + "&update=yes";
                }

                Response.Redirect(url);
            }
        }



        private void Save2()
        {
            // Save Lateral data
            GrdRaAddLateralsNewAdd();

            // Save data
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int assetId = Int32.Parse(hdfAssetId.Value);
            int workId = Int32.Parse(hdfWorkId.Value);
            int workIdFll = Int32.Parse(hdfWorkIdFll.Value);
            int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value.ToString());

            // Get Section Details
            // ... RehabAssessmentSectionDetails data
            string newStreet = ""; if (tbxStreet.Text != "") newStreet = tbxStreet.Text.Trim();
            string newUsmh = ""; if (tbxUSMH.Text != "") newUsmh = tbxUSMH.Text.Trim();
            string newDsmh = ""; if (tbxDSMH.Text != "") newDsmh = tbxDSMH.Text.Trim();
            string newMapSize = ""; if (tbxMapSize.Text != "") newMapSize = tbxMapSize.Text.Trim();
            string newSize = ""; if (tbxConfirmedSize.Text != "") newSize = tbxConfirmedSize.Text.Trim();
            string newThickness = ""; if (ddlThickness.SelectedValue != "") newThickness = ddlThickness.SelectedValue;
            string newMapLength = ""; if (tbxMapLength.Text != "") newMapLength = tbxMapLength.Text.Trim();

            string newSteelTapeThroughSewer = "";
            string newLength = "";
            if (tbxM1DataSteelTapeThroughSewer.Text != "")
            {
                newSteelTapeThroughSewer = tbxM1DataSteelTapeThroughSewer.Text.Trim();
                newLength = tbxM1DataSteelTapeThroughSewer.Text.Trim();
            }

            int? newLaterals = null; if (tbxLaterals.Text != "") newLaterals = Int32.Parse(tbxLaterals.Text.Trim());
            int? newLiveLaterals = null; if (tbxLiveLaterals.Text != "") newLiveLaterals = Int32.Parse(tbxLiveLaterals.Text.Trim());

            // Get m1 data
            // ... assetSewerSection data
            string newUsmhDepth = ""; if ((tbxM1DataUsmhDepth.Text != "") && (tbxUSMH.Text != "")) newUsmhDepth = tbxM1DataUsmhDepth.Text.Trim();
            string newDsmhDepth = ""; if ((tbxM1DataDsmhDepth.Text != "") && (tbxDSMH.Text != "")) newDsmhDepth = tbxM1DataDsmhDepth.Text.Trim();

            // ... lfsAssetSewerSection data
            string newUsmhMouth12 = ""; if ((tbxM1DataUsmhMouth12.Text != "") && (tbxUSMH.Text != "")) newUsmhMouth12 = tbxM1DataUsmhMouth12.Text.Trim();
            string newUsmhMouth1 = ""; if ((tbxM1DataUsmhMouth1.Text != "") && (tbxUSMH.Text != "")) newUsmhMouth1 = tbxM1DataUsmhMouth1.Text.Trim();
            string newUsmhMouth2 = ""; if ((tbxM1DataUsmhMouth2.Text != "") && (tbxUSMH.Text != "")) newUsmhMouth2 = tbxM1DataUsmhMouth2.Text.Trim();
            string newUsmhMouth3 = ""; if ((tbxM1DataUsmhMouth3.Text != "") && (tbxUSMH.Text != "")) newUsmhMouth3 = tbxM1DataUsmhMouth3.Text.Trim();
            string newUsmhMouth4 = ""; if ((tbxM1DataUsmhMouth4.Text != "") && (tbxUSMH.Text != "")) newUsmhMouth4 = tbxM1DataUsmhMouth4.Text.Trim();
            string newUsmhMouth5 = ""; if ((tbxM1DataUsmhMouth5.Text != "") && (tbxUSMH.Text != "")) newUsmhMouth5 = tbxM1DataUsmhMouth5.Text.Trim();
            string newDsmhMouth12 = ""; if ((tbxM1DataDsmhMouth12.Text != "") && (tbxDSMH.Text != "")) newDsmhMouth12 = tbxM1DataDsmhMouth12.Text.Trim();
            string newDsmhMouth1 = ""; if ((tbxM1DataDsmhMouth1.Text != "") && (tbxDSMH.Text != "")) newDsmhMouth1 = tbxM1DataDsmhMouth1.Text.Trim();
            string newDsmhMouth2 = ""; if ((tbxM1DataDsmhMouth2.Text != "") && (tbxDSMH.Text != "")) newDsmhMouth2 = tbxM1DataDsmhMouth2.Text.Trim();
            string newDsmhMouth3 = ""; if ((tbxM1DataDsmhMouth3.Text != "") && (tbxDSMH.Text != "")) newDsmhMouth3 = tbxM1DataDsmhMouth3.Text.Trim();
            string newDsmhMouth4 = ""; if ((tbxM1DataDsmhMouth4.Text != "") && (tbxDSMH.Text != "")) newDsmhMouth4 = tbxM1DataDsmhMouth4.Text.Trim();
            string newDsmhMouth5 = ""; if ((tbxM1DataDsmhMouth5.Text != "") && (tbxDSMH.Text != "")) newDsmhMouth5 = tbxM1DataDsmhMouth5.Text.Trim();
            string newGeneralSubArea = ""; if (tbxGeneralSubArea.Text != "") newGeneralSubArea = tbxGeneralSubArea.Text.Trim();

            // ... assetSewerMH Data
            string newUsmhAddress = ""; if (tbxM1DataUsmhAddress.Text != "") newUsmhAddress = tbxM1DataUsmhAddress.Text.Trim();
            string newDsmhAddress = ""; if (tbxM1DataDsmhAddress.Text != "") newDsmhAddress = tbxM1DataDsmhAddress.Text.Trim();

            // Update section details
            RehabAssessmentSectionDetails rehabAssessmentSectionDetails = new RehabAssessmentSectionDetails(rehabAssessmentTDS);
            rehabAssessmentSectionDetails.Update(workId, assetId, newStreet, newMapSize, newSize, newMapLength, newLength, newLaterals, newLiveLaterals, newUsmhDepth, newDsmhDepth, newSteelTapeThroughSewer, newUsmhMouth12, newUsmhMouth1, newUsmhMouth2, newUsmhMouth3, newUsmhMouth4, newUsmhMouth5, newDsmhMouth12, newDsmhMouth1, newDsmhMouth2, newDsmhMouth3, newDsmhMouth4, newDsmhMouth5, newUsmh, newDsmh, newUsmhAddress, newDsmhAddress, newGeneralSubArea, newThickness);

            // Get generalData
            // ... FullLengthLining Data
            string newGeneralClientId = ""; if (tbxGeneralClientId.Text != "") newGeneralClientId = tbxGeneralClientId.Text.Trim();

            // ... Rehab Assessment Data
            DateTime? newPreFlushDate = null; if (tkrdpGeneralPreFlushDate.SelectedDate.HasValue) newPreFlushDate = tkrdpGeneralPreFlushDate.SelectedDate.Value;
            DateTime? newPreVideoDate = null; if (tkrdpGeneralPreVideoDate.SelectedDate.HasValue) newPreVideoDate = tkrdpGeneralPreVideoDate.SelectedDate.Value;

            // ... Prep Data
            int? newPrepDataCXIsRemoved = null; if (tbxPrepDataCXIsRemoved.Text != "") newPrepDataCXIsRemoved = Int32.Parse(tbxPrepDataCXIsRemoved.Text.Trim());
            DateTime? newPrepDataP1Date = null; if (tkrdpPrepDataP1Date.SelectedDate.HasValue) newPrepDataP1Date = tkrdpPrepDataP1Date.SelectedDate.Value;
            bool newRoboticPrepCompleted = ckbxPrepDataRoboticPrepCompleted.Checked;
            DateTime? newRoboticPrepCompletedDate = null; if (tkrdpPrepDataRoboticPrepCompletedDate.SelectedDate.HasValue) newRoboticPrepCompletedDate = tkrdpPrepDataRoboticPrepCompletedDate.SelectedDate.Value;
            bool newP1Completed = ckbxPrepDataP1Completed.Checked;

            // ... M1 Data
            DateTime? newM1Date = null; if (tkrdpM1DataM1Date.SelectedDate.HasValue) newM1Date = tkrdpM1DataM1Date.SelectedDate.Value;
            string newMeasurementsTakenBy = ""; if (tbxM1DataMeasurementsTakenBy.Text != "") newMeasurementsTakenBy = tbxM1DataMeasurementsTakenBy.Text.Trim();
            string newTrafficControl = ddlM1DataTrafficControl.SelectedValue;
            string newSiteDetails = ""; if (ddlM1DataSiteDetails.SelectedValue != "(Select)") newSiteDetails = ddlM1DataSiteDetails.SelectedValue;
            bool newPipeSizeChange = ckbxM1DataPipeSizeChange.Checked;
            bool newStandardByPass = ckbxM1DataStandardBypass.Checked;
            string newStandardBypassComments = ""; if (tbxM1DataStandardBypassComments.Text != "") newStandardBypassComments = tbxM1DataStandardBypassComments.Text.Trim();
            string newTrafficControlDetails = ""; if (tbxM1DataTrafficControlDetails.Text != "") newTrafficControlDetails = tbxM1DataTrafficControlDetails.Text.Trim();
            string newMaterial = ddlM1DataMaterial.SelectedValue;
            string newMeasurementType = ddlM1DataMeasurementType.SelectedValue;
            string newMeasuredFromMh = "";    if (tbxM1DataMeasuredFromMh.Visible) newMeasuredFromMh = tbxM1DataMeasuredFromMh.Text; else newMeasuredFromMh = ddlM1DataMeasuredFromMh.SelectedValue;
            string newVideoDoneFromMh = "";    if (tbxM1DataVideoDoneFromMh.Visible) newVideoDoneFromMh = tbxM1DataVideoDoneFromMh.Text; else newVideoDoneFromMh = ddlM1DataVideoDoneFromMh.SelectedValue;
            string newVideoDoneToMh = ""; if (tbxM1DataVideoDoneToMh.Visible) newVideoDoneToMh = tbxM1DataVideoDoneToMh.Text; else newVideoDoneToMh = ddlM1DataVideoDoneToMh.SelectedValue;
            string newAccessType = ""; if (ddlM1DataAccessType.SelectedValue != "(Select)") newAccessType = ddlM1DataAccessType.SelectedValue;

            // ... M2 Data (Video Length)
            string newVideoDistanceM2 = tbxVideoLength.Text.Trim();

            // ... Update work details
            RehabAssessmentWorkDetails rehabAssessmentWorkDetails = new RehabAssessmentWorkDetails(rehabAssessmentTDS);
            rehabAssessmentWorkDetails.Update(workId, workIdFll, newGeneralClientId, newPrepDataP1Date, newM1Date, newPrepDataCXIsRemoved, newRoboticPrepCompleted, newRoboticPrepCompletedDate, newMeasurementsTakenBy, newTrafficControl, newSiteDetails, newPipeSizeChange, newStandardByPass, newStandardBypassComments, newTrafficControlDetails, newMaterial, newMeasurementType, newMeasuredFromMh, newVideoDoneFromMh, newVideoDoneToMh, newVideoDistanceM2, newPreVideoDate, newPreFlushDate, newAccessType, newP1Completed);

            if (ddlM1DataMaterial.SelectedIndex > 0)
            {
                LfsAssetSewerLateralGateway lfsAssetSewertLateralGateway = new LfsAssetSewerLateralGateway(null);
                if (!lfsAssetSewertLateralGateway.IsUsedInMaterials(assetId, newMaterial, companyId))
                {
                    MaterialInformation model = new MaterialInformation(materialInformationTDS);
                    model.Insert(assetId, newMaterial, DateTime.Now, false, companyId, false);
                }
            }

            // Store datasets
            Session["rehabAssessmentTDS"] = rehabAssessmentTDS;
            Session["materialInformationTDS"] = materialInformationTDS;

            ViewState["update"] = "no";            
        }



        private bool Apply()
        {
            // Validate data
            bool validData = true;

            validData = ValidatePage();

            if (validData)
            {
                // Save Lateral data
                GrdRaAddLateralsNewAdd();

                // Save data
                int companyId = Int32.Parse(hdfCompanyId.Value);
                int assetId = Int32.Parse(hdfAssetId.Value);
                int workId = Int32.Parse(hdfWorkId.Value);
                int workIdFll = Int32.Parse(hdfWorkIdFll.Value);
                int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value.ToString());

                // Get Section Details
                // ... RehabAssessmentSectionDetails data
                string newStreet = ""; if (tbxStreet.Text != "") newStreet = tbxStreet.Text.Trim();
                string newUsmh = ""; if (tbxUSMH.Text != "") newUsmh = tbxUSMH.Text.Trim();
                string newDsmh = ""; if (tbxDSMH.Text != "") newDsmh = tbxDSMH.Text.Trim();
                string newMapSize = ""; if (tbxMapSize.Text != "") newMapSize = tbxMapSize.Text.Trim();
                string newSize = ""; if (tbxConfirmedSize.Text != "") newSize = tbxConfirmedSize.Text.Trim();
                string newThickness = ""; if (ddlThickness.SelectedValue != "") newThickness = ddlThickness.SelectedValue;
                string newMapLength = ""; if (tbxMapLength.Text != "") newMapLength = tbxMapLength.Text.Trim();

                string newSteelTapeThroughSewer = "";
                string newLength = "";
                if (tbxM1DataSteelTapeThroughSewer.Text != "")
                {
                    newSteelTapeThroughSewer = tbxM1DataSteelTapeThroughSewer.Text.Trim();
                    newLength = tbxM1DataSteelTapeThroughSewer.Text.Trim();
                }

                int? newLaterals = null; if (tbxLaterals.Text != "") newLaterals = Int32.Parse(tbxLaterals.Text.Trim());
                int? newLiveLaterals = null; if (tbxLiveLaterals.Text != "") newLiveLaterals = Int32.Parse(tbxLiveLaterals.Text.Trim());

                // Get m1 data
                // ... assetSewerSection data
                string newUsmhDepth = ""; if ((tbxM1DataUsmhDepth.Text != "") && (tbxUSMH.Text != "")) newUsmhDepth = tbxM1DataUsmhDepth.Text.Trim();
                string newDsmhDepth = ""; if ((tbxM1DataDsmhDepth.Text != "") && (tbxDSMH.Text != "")) newDsmhDepth = tbxM1DataDsmhDepth.Text.Trim();

                // ... lfsAssetSewerSection data
                string newUsmhMouth12 = ""; if ((tbxM1DataUsmhMouth12.Text != "") && (tbxUSMH.Text != "")) newUsmhMouth12 = tbxM1DataUsmhMouth12.Text.Trim();
                string newUsmhMouth1 = ""; if ((tbxM1DataUsmhMouth1.Text != "") && (tbxUSMH.Text != "")) newUsmhMouth1 = tbxM1DataUsmhMouth1.Text.Trim();
                string newUsmhMouth2 = ""; if ((tbxM1DataUsmhMouth2.Text != "") && (tbxUSMH.Text != "")) newUsmhMouth2 = tbxM1DataUsmhMouth2.Text.Trim();
                string newUsmhMouth3 = ""; if ((tbxM1DataUsmhMouth3.Text != "") && (tbxUSMH.Text != "")) newUsmhMouth3 = tbxM1DataUsmhMouth3.Text.Trim();
                string newUsmhMouth4 = ""; if ((tbxM1DataUsmhMouth4.Text != "") && (tbxUSMH.Text != "")) newUsmhMouth4 = tbxM1DataUsmhMouth4.Text.Trim();
                string newUsmhMouth5 = ""; if ((tbxM1DataUsmhMouth5.Text != "") && (tbxUSMH.Text != "")) newUsmhMouth5 = tbxM1DataUsmhMouth5.Text.Trim();
                string newDsmhMouth12 = ""; if ((tbxM1DataDsmhMouth12.Text != "") && (tbxDSMH.Text != "")) newDsmhMouth12 = tbxM1DataDsmhMouth12.Text.Trim();
                string newDsmhMouth1 = ""; if ((tbxM1DataDsmhMouth1.Text != "") && (tbxDSMH.Text != "")) newDsmhMouth1 = tbxM1DataDsmhMouth1.Text.Trim();
                string newDsmhMouth2 = ""; if ((tbxM1DataDsmhMouth2.Text != "") && (tbxDSMH.Text != "")) newDsmhMouth2 = tbxM1DataDsmhMouth2.Text.Trim();
                string newDsmhMouth3 = ""; if ((tbxM1DataDsmhMouth3.Text != "") && (tbxDSMH.Text != "")) newDsmhMouth3 = tbxM1DataDsmhMouth3.Text.Trim();
                string newDsmhMouth4 = ""; if ((tbxM1DataDsmhMouth4.Text != "") && (tbxDSMH.Text != "")) newDsmhMouth4 = tbxM1DataDsmhMouth4.Text.Trim();
                string newDsmhMouth5 = ""; if ((tbxM1DataDsmhMouth5.Text != "") && (tbxDSMH.Text != "")) newDsmhMouth5 = tbxM1DataDsmhMouth5.Text.Trim();
                string newGeneralSubArea = ""; if (tbxGeneralSubArea.Text != "") newGeneralSubArea = tbxGeneralSubArea.Text.Trim();

                // ... assetSewerMH Data
                string newUsmhAddress = ""; if (tbxM1DataUsmhAddress.Text != "") newUsmhAddress = tbxM1DataUsmhAddress.Text.Trim();
                string newDsmhAddress = ""; if (tbxM1DataDsmhAddress.Text != "") newDsmhAddress = tbxM1DataDsmhAddress.Text.Trim();

                // Update section details
                RehabAssessmentSectionDetails rehabAssessmentSectionDetails = new RehabAssessmentSectionDetails(rehabAssessmentTDS);
                rehabAssessmentSectionDetails.Update(workId, assetId, newStreet, newMapSize, newSize, newMapLength, newLength, newLaterals, newLiveLaterals, newUsmhDepth, newDsmhDepth, newSteelTapeThroughSewer, newUsmhMouth12, newUsmhMouth1, newUsmhMouth2, newUsmhMouth3, newUsmhMouth4, newUsmhMouth5, newDsmhMouth12, newDsmhMouth1, newDsmhMouth2, newDsmhMouth3, newDsmhMouth4, newDsmhMouth5, newUsmh, newDsmh, newUsmhAddress, newDsmhAddress, newGeneralSubArea, newThickness);

                // Get GeneralData
                // ... FullLengthLining Data
                string newGeneralClientId = ""; if (tbxGeneralClientId.Text != "") newGeneralClientId = tbxGeneralClientId.Text.Trim();

                // ... Rehab Assessment Data
                DateTime? newPreFlushDate = null; if (tkrdpGeneralPreFlushDate.SelectedDate.HasValue) newPreFlushDate = tkrdpGeneralPreFlushDate.SelectedDate.Value;
                DateTime? newPreVideoDate = null; if (tkrdpGeneralPreVideoDate.SelectedDate.HasValue) newPreVideoDate = tkrdpGeneralPreVideoDate.SelectedDate.Value;

                // ... Prep Data
                int? newPrepDataCXIsRemoved = null; if (tbxPrepDataCXIsRemoved.Text != "") newPrepDataCXIsRemoved = Int32.Parse(tbxPrepDataCXIsRemoved.Text.Trim());
                DateTime? newPrepDataP1Date = null; if (tkrdpPrepDataP1Date.SelectedDate.HasValue) newPrepDataP1Date = tkrdpPrepDataP1Date.SelectedDate.Value;
                bool newRoboticPrepCompleted = ckbxPrepDataRoboticPrepCompleted.Checked;
                DateTime? newRoboticPrepCompletedDate = null; if (tkrdpPrepDataRoboticPrepCompletedDate.SelectedDate.HasValue) newRoboticPrepCompletedDate = tkrdpPrepDataRoboticPrepCompletedDate.SelectedDate.Value;
                bool newP1Completed = ckbxPrepDataP1Completed.Checked;

                // ... M1 Data
                DateTime? newM1Date = null; if (tkrdpM1DataM1Date.SelectedDate.HasValue) newM1Date = tkrdpM1DataM1Date.SelectedDate.Value;
                string newMeasurementsTakenBy = ""; if (tbxM1DataMeasurementsTakenBy.Text != "") newMeasurementsTakenBy = tbxM1DataMeasurementsTakenBy.Text.Trim();
                string newTrafficControl = ddlM1DataTrafficControl.SelectedValue;
                string newSiteDetails = ""; if (ddlM1DataSiteDetails.SelectedValue != "(Select)") newSiteDetails = ddlM1DataSiteDetails.SelectedValue;
                bool newPipeSizeChange = ckbxM1DataPipeSizeChange.Checked;
                bool newStandardByPass = ckbxM1DataStandardBypass.Checked;
                string newStandardBypassComments = ""; if (tbxM1DataStandardBypassComments.Text != "") newStandardBypassComments = tbxM1DataStandardBypassComments.Text.Trim();
                string newTrafficControlDetails = ""; if (tbxM1DataTrafficControlDetails.Text != "") newTrafficControlDetails = tbxM1DataTrafficControlDetails.Text.Trim();
                string newMaterial = ddlM1DataMaterial.SelectedValue;
                string newMeasurementType = ddlM1DataMeasurementType.SelectedValue;
                string newMeasuredFromMh = ""; if (tbxM1DataMeasuredFromMh.Visible) newMeasuredFromMh = tbxM1DataMeasuredFromMh.Text; else newMeasuredFromMh = ddlM1DataMeasuredFromMh.SelectedValue;
                string newVideoDoneFromMh = ""; if (tbxM1DataVideoDoneFromMh.Visible) newVideoDoneFromMh = tbxM1DataVideoDoneFromMh.Text; else newVideoDoneFromMh = ddlM1DataVideoDoneFromMh.SelectedValue;
                string newVideoDoneToMh = ""; if (tbxM1DataVideoDoneToMh.Visible) newVideoDoneToMh = tbxM1DataVideoDoneToMh.Text; else newVideoDoneToMh = ddlM1DataVideoDoneToMh.SelectedValue;
                string newAccessType = ""; if (ddlM1DataAccessType.SelectedValue != "(Select)") newAccessType = ddlM1DataAccessType.SelectedValue;

                // ... M2 Data (Video Length)
                string newVideoDistanceM2 = tbxVideoLength.Text.Trim();

                // ... Update work details
                RehabAssessmentWorkDetails rehabAssessmentWorkDetails = new RehabAssessmentWorkDetails(rehabAssessmentTDS);
                rehabAssessmentWorkDetails.Update(workId, workIdFll, newGeneralClientId, newPrepDataP1Date, newM1Date, newPrepDataCXIsRemoved, newRoboticPrepCompleted, newRoboticPrepCompletedDate, newMeasurementsTakenBy, newTrafficControl, newSiteDetails, newPipeSizeChange, newStandardByPass, newStandardBypassComments, newTrafficControlDetails, newMaterial, newMeasurementType, newMeasuredFromMh, newVideoDoneFromMh, newVideoDoneToMh, newVideoDistanceM2, newPreVideoDate, newPreFlushDate, newAccessType, newP1Completed);

                if (ddlM1DataMaterial.SelectedIndex > 0)
                {
                    LfsAssetSewerLateralGateway lfsAssetSewertLateralGateway = new LfsAssetSewerLateralGateway(null);
                    if (!lfsAssetSewertLateralGateway.IsUsedInMaterials(assetId, newMaterial, companyId))
                    {
                        MaterialInformation model = new MaterialInformation(materialInformationTDS);
                        model.Insert(assetId, newMaterial, DateTime.Now, false, companyId, false);
                    }
                }

                // Store datasets
                Session["rehabAssessmentTDS"] = rehabAssessmentTDS;
                Session["materialInformationTDS"] = materialInformationTDS;
                
                // Update database
                UpdateDatabase();

                // Restore datasets
                rehabAssessmentTDS = (RehabAssessmentTDS)Session["rehabAssessmentTDS"];

                rehabAssessmentSectionDetails.LoadByWorkId(workId, companyId);
                rehabAssessmentWorkDetails.LoadByWorkId(workId, companyId);

                int newWorkIdFll = GetWorkId(currentProjectId, assetId, "Full Length Lining", companyId);
                hdfWorkIdFll.Value = GetWorkId(currentProjectId, assetId, "Full Length Lining", companyId).ToString();

                rehabAssessmentTDS.LateralDetails.Clear();
                RehabAssessmentLateralDetails rehabAssessmentLateralDetails = new RehabAssessmentLateralDetails(rehabAssessmentTDS);
                rehabAssessmentLateralDetails.LoadForEdit(newWorkIdFll, assetId, companyId, currentProjectId);
                grdLaterals.DataBind();
                
                // ... Store dataset
                Session["rehabAssessmentTDS"] = rehabAssessmentTDS;

                ViewState["update"] = "yes";
            }

            return validData;
        }



        private bool ValidateLateralFooter()
        {
            string size = ((TextBox)grdLaterals.FooterRow.FindControl("tbxNewSize")).Text.Trim();
            string material = ((DropDownList)grdLaterals.FooterRow.FindControl("ddlNewMaterial")).SelectedValue.ToString().Trim();
            string mn = ((TextBox)grdLaterals.FooterRow.FindControl("tbxNewMn")).Text.Trim();
            string live = ((DropDownList)grdLaterals.FooterRow.FindControl("ddlNewLive")).SelectedValue.Trim();
            string videoDistance = ((TextBox)grdLaterals.FooterRow.FindControl("tbxNewVideoDistance")).Text.Trim();
            string clockPosition = ((TextBox)grdLaterals.FooterRow.FindControl("tbxNewClockPosition")).Text.Trim();
            string distanceToCentre = ((TextBox)grdLaterals.FooterRow.FindControl("tbxNewDistanceToCentre")).Text.Trim();
            string comments = ((TextBox)grdLaterals.FooterRow.FindControl("tbxNewComments")).Text.Trim();
            string connectionType = ((DropDownList)grdLaterals.FooterRow.FindControl("ddlNewConnectionType")).SelectedValue.ToString().Trim();
            
            bool requiresRoboticPrep = ((CheckBox)grdLaterals.FooterRow.FindControl("ckbxRequiresRoboticPrepNew")).Checked;
            DateTime? requiresRoboticPrepDate = null;
            if (((RadDatePicker)grdLaterals.FooterRow.FindControl("tkrdpRequiresRoboticPrepDateNew")).SelectedDate.HasValue)
            {
                requiresRoboticPrepDate = ((RadDatePicker)grdLaterals.FooterRow.FindControl("tkrdpRequiresRoboticPrepDateNew")).SelectedDate.Value;
            }
            
            bool holdClientIssue = ((CheckBox)grdLaterals.FooterRow.FindControl("ckbxHoldClientIssueNew")).Checked;
            bool holdLFSIssue = ((CheckBox)grdLaterals.FooterRow.FindControl("ckbxHoldLFSIssueNew")).Checked;

            bool dyeTestReq = ((CheckBox)grdLaterals.FooterRow.FindControl("ckbxDyeTestReqNew")).Checked;

            DateTime? dyeTestComplete = null;
            if (((RadDatePicker)grdLaterals.FooterRow.FindControl("tkrdpDyeTestCompleteNew")).SelectedDate.HasValue)
            {
                dyeTestComplete = ((RadDatePicker)grdLaterals.FooterRow.FindControl("tkrdpDyeTestCompleteNew")).SelectedDate.Value;
            }

            if ((size != "") || (material != "") || (mn != "") || (live != "(Select)") || (videoDistance != "") || (clockPosition != "") || (distanceToCentre != "") || (comments != "") || (material != "") || (connectionType != "") || (requiresRoboticPrep) || (requiresRoboticPrepDate.HasValue) || (holdClientIssue) || (holdLFSIssue) || (dyeTestReq) || (dyeTestComplete.HasValue))
            {
                return true;
            }

            return false;
        }



        private bool ValidatePage()
        {
            bool validData = true;

            // Validate general data
            Page.Validate("raData");

            if (Page.IsValid)
            {
                // Validate m1 data
                Page.Validate("raM1Data");
                if (!Page.IsValid)
                {
                    validData = false;
                }
                                
                // Validate laterals
                if (ValidateLateralFooter())
                {
                    Page.Validate("AddLateralsAdd");
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
                //// If it's not valid
                //if (!rfvM1DataAccessType.IsValid)
                //{
                //    hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Access Type (M1)";
                //}

                lblMissingData.Visible = true;
                string errorText = "Invalid or missing data. Please check";
                lblMissingData.Text = errorText + hdfErrorFieldList.Value.ToString();
            }

            return validData;
        }



        private void UpdateDatabase()
        {
            // Get ids & location
            int projectId = Int32.Parse(hdfCurrentProjectId.Value.Trim());
            ProjectGateway projectGateway = new ProjectGateway();
            projectGateway.LoadByProjectId(projectId);

            Int64 countryId = projectGateway.GetCountryID(projectId);
            Int64? provinceId = null; if (projectGateway.GetProvinceID(projectId).HasValue) provinceId = (Int64)projectGateway.GetProvinceID(projectId);
            Int64? countyId = null; if (projectGateway.GetCountyID(projectId).HasValue) countyId = (Int64)projectGateway.GetCountyID(projectId);
            Int64? cityId = null; if (projectGateway.GetCityID(projectId).HasValue) cityId = (Int64)projectGateway.GetCityID(projectId);

            string workType = hdfWorkType.Value.Trim();
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int workId = Int32.Parse(hdfWorkId.Value);
            int workIdFll = Int32.Parse(hdfWorkIdFll.Value);
            int sectionAssetId = Int32.Parse(hdfAssetId.Value);

            bool isNewMeasuredFromDsmh = false;

            RehabAssessmentLateralDetails raLateralDetails = new RehabAssessmentLateralDetails();
            raLateralDetails.LoadForEdit(workIdFll, sectionAssetId, companyId, projectId);

            if (raLateralDetails.Table.Rows.Count == 0)
            {
                if (ddlM1DataMeasuredFromMh.SelectedValue == "DSMH")
                {
                    isNewMeasuredFromDsmh = true;
                    RehabAssessmentLateralDetails raaLateralDetails = new RehabAssessmentLateralDetails(rehabAssessmentTDS);
                    raaLateralDetails.ModifyLateralId();
                }
            }

            DB.Open();
            DB.BeginTransaction();
            try
            {
                // Save lateral details
                bool roboticPrepCompleted = ckbxPrepDataRoboticPrepCompleted.Checked;
                DateTime? roboticPrepCompletedCompleted = null; if (tkrdpPrepDataRoboticPrepCompletedDate.SelectedDate.HasValue) roboticPrepCompletedCompleted = tkrdpPrepDataRoboticPrepCompletedDate.SelectedDate.Value;                

                RehabAssessmentLateralDetails rehabAssessmentLateralDetails = new RehabAssessmentLateralDetails(rehabAssessmentTDS);
                rehabAssessmentLateralDetails.Save(workIdFll, projectId, sectionAssetId, countryId, provinceId, countyId, cityId, tbxVideoLength.Text.Trim(), companyId, isNewMeasuredFromDsmh, roboticPrepCompleted, roboticPrepCompletedCompleted);

                // Save section details
                RehabAssessmentSectionDetails rehabAssessmentSectionDetails = new RehabAssessmentSectionDetails(rehabAssessmentTDS);
                rehabAssessmentSectionDetails.Save(countryId, provinceId, countyId, cityId, projectId, companyId);

                // Save work details
                RehabAssessmentWorkDetails rehabAssessmentWorkDetails = new RehabAssessmentWorkDetails(rehabAssessmentTDS);
                rehabAssessmentWorkDetails.Save(countryId, provinceId, countyId, cityId, projectId, companyId, sectionAssetId);

                // Save material details
                string newMaterial = ddlM1DataMaterial.SelectedValue;

                if (ddlM1DataMaterial.SelectedIndex > 0)
                {
                    LfsAssetSewerLateralGateway lfsAssetSewertLateralGateway = new LfsAssetSewerLateralGateway(null);
                    if (!lfsAssetSewertLateralGateway.IsUsedInMaterials(sectionAssetId, newMaterial, companyId))
                    {
                        MaterialInformation materialInformation = new MaterialInformation(materialInformationTDS);
                        materialInformation.Save(companyId);
                    }
                }

                DB.CommitTransaction();

                // Store datasets
                rehabAssessmentTDS.AcceptChanges();                
                Session["rehabAssessmentTDS"] = rehabAssessmentTDS;

                materialInformationTDS.AcceptChanges();
                Session["materialInformationTDS"] = materialInformationTDS;
            }
            catch (Exception ex)
            {
                DB.RollbackTransaction();

                string url = string.Format("./../../error_page.aspx?error={0}", ex.Message.Replace('\n', ' '));
                Response.Redirect(url);
            }
        }



        private void FLLateralsSave(string lateralId, bool requiresRoboticPrep, DateTime? equiresRoboticPrepIssueCompleted, bool holdClientIssue, bool holdLFSIssue, bool dyeTestReq, DateTime? dyeTestComplete, string contractYear)
        {
            int workIdJl = Int32.Parse(hdfWorkIdJl.Value);
            int companyId = Int32.Parse(hdfCompanyId.Value);
            flatSectionJlTDSForRA = new FlatSectionJlTDS();

            FlatSectionJlGateway flatSectionJlGateway = new FlatSectionJlGateway(flatSectionJlTDSForRA);
            flatSectionJlGateway.LoadAllByWorkId(workIdJl, companyId);

            string latId = lateralId.Substring(3, lateralId.Length - 3);

            if (flatSectionJlGateway.Table.Rows.Count > 0)
            {
                FlatSectionJl flatSectionJl = new FlatSectionJl(flatSectionJlTDSForRA);
                flatSectionJl.UpdateAllLaterals(latId, requiresRoboticPrep, equiresRoboticPrepIssueCompleted, holdClientIssue, holdLFSIssue, dyeTestReq, dyeTestComplete, contractYear);
            }

            Session["flatSectionJlTDSForRA"] = flatSectionJlTDSForRA;
            flatSectionJlTDSForRA.AcceptChanges();
        }



        private int GetWorkId(int projectId, int assetId, string workType, int companyId)
        {
            int workId = 0;
            WorkGateway workGateway = new WorkGateway();
            workGateway.LoadByProjectIdAssetIdWorkType(projectId, assetId, workType, companyId);
            if (workGateway.Table.Rows.Count > 0)
            {
                // Get WorkId
                workId = workGateway.GetWorkId(assetId, workType, projectId);
            }

            return workId;
        }



        private bool LateralsCouldBeDeletedInJl(int lateral)
        {
            bool delete = false;
                       
            // Get workId            
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int assetId = Int32.Parse(hdfAssetId.Value);
            string workType = hdfWorkType.Value;
            int projectId = Int32.Parse(hdfCurrentProjectId.Value);

            WorkGateway workGateway = new WorkGateway();
            workGateway.LoadByProjectIdAssetIdWorkType(projectId, assetId, workType, companyId);
            
            int workIdJlLateral = GetWorkId(projectId, lateral, "Junction Lining Lateral", companyId);
            
            WorkJunctionLiningLateralGateway row = new WorkJunctionLiningLateralGateway();
            row.LoadByWorkId(workIdJlLateral, companyId);

            // All fields are empty for deleting a lateral on jl
            if ((!row.GetPipeLocated(workIdJlLateral).HasValue) && (!row.GetServicesLocated(workIdJlLateral).HasValue) && (!row.GetCoInstalled(workIdJlLateral).HasValue) && (!row.GetBackfilledConcrete(workIdJlLateral).HasValue) && (!row.GetBackfilledSoil(workIdJlLateral).HasValue) && (!row.GetGrouted(workIdJlLateral).HasValue) && (!row.GetCored(workIdJlLateral).HasValue) && (!row.GetPrepped(workIdJlLateral).HasValue) && (!row.GetMeasured(workIdJlLateral).HasValue) && (!row.GetInProcess(workIdJlLateral).HasValue) && (!row.GetInStock(workIdJlLateral).HasValue) && (!row.GetDelivered(workIdJlLateral).HasValue) && (!row.GetPreVideo(workIdJlLateral).HasValue) && (!row.GetLinerInstalled(workIdJlLateral).HasValue) && (!row.GetFinalVideo(workIdJlLateral).HasValue) && (!row.GetVideoInspection(workIdJlLateral).HasValue) && (!row.GetCoCutDown(workIdJlLateral).HasValue) && (!row.GetFinalRestoration(workIdJlLateral).HasValue) && (!row.GetNoticeDelivered(workIdJlLateral).HasValue) && (!row.GetHoldClientIssueResolved(workIdJlLateral).HasValue) && (!row.GetDigRequiredPriorToLiningCompleted(workIdJlLateral).HasValue) && (!row.GetHoldLFSIssueResolved(workIdJlLateral).HasValue) && (!row.GetDigRequiredAfterLiningCompleted(workIdJlLateral).HasValue) && (!row.GetLateralRequiresRoboticPrepCompleted(workIdJlLateral).HasValue))
            {
                if ((!row.GetCoRequired(workIdJlLateral)) && (!row.GetPitRequired(workIdJlLateral)) && (!row.GetLiningThruCo(workIdJlLateral)) && (!row.GetPostContractDigRequired(workIdJlLateral)) && (!row.GetDigRequiredPriorToLining(workIdJlLateral)) && (!row.GetDigRequiredAfterLining(workIdJlLateral)) && (!row.GetOutOfScope(workIdJlLateral)) && (!row.GetHoldClientIssue(workIdJlLateral)) && (!row.GetHoldLFSIssue(workIdJlLateral)) && (!row.GetLateralRequiresRoboticPrep(workIdJlLateral)) && (row.GetLinerSize(workIdJlLateral) == "") && (row.GetFlange(workIdJlLateral) == "") && (row.GetHamiltonInspectionNumber(workIdJlLateral) == "") && (row.GetCoPitLocation(workIdJlLateral) == "") && (row.GetPrepType(workIdJlLateral) == "") && (row.GetGasket(workIdJlLateral) == "") && (row.GetDepthOfLocated(workIdJlLateral) == "") && (row.GetLinerType(workIdJlLateral) == "") && (row.GetVideoLengthToPropertyLine(workIdJlLateral) == ""))
                {
                    if ((row.GetBuildRebuild(workIdJlLateral) == 0) && (row.GetCost(workIdJlLateral) == 0.00m))
                    {
                        delete = true;
                    }
                }
            }
        
            return delete;
        }



    }
}